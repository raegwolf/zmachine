using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using ZMachine.V3.Structs;

namespace ZMachine.V3
{
    public class ZMachine : ZBase
    {

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var routine in Resources.Routines)
            {
                sb.Append(routine.ToString());
            }

            return sb.ToString();
        }


        public void Load(ZMemoryStream stream)
        {
            Resources.Stream = stream;

            parseHeader();

            parseDictionary();

            parseAbbreviations();

            // must be done after abbreviations
            parseObjects();
        }

        public void Run()
        {
            ZProcessor processor = new ZProcessor(this.Resources);
            processor.CallStack.Push(new CallStackFrame()
            {
                RoutineAddress = Resources.Header.mainRoutineEntryPointAddress - 1
            });

            ushort result = 0;

            while (processor.CallStack.Count() > 0)
            {
                processor.CurrentFrame = processor.CallStack.Pop();

                var routine = getRoutineByAddress(processor.CurrentFrame.RoutineAddress);

                if (!processor.CurrentFrame.IsReturn)
                {
                    // this is a new call, initialise the PC and locals
                    processor.CurrentFrame.PC = routine.Instructions.First().InstructionAddress;

                    // prepare the local vars by taking the defaults for the routine and then overriding them with those passed in callstackframe.locals
                    processor.CurrentFrame.Locals = prepareLocals(processor.CurrentFrame.Locals, routine.InitialLocalVariables, routine.LocalVariableCount);
                }
                else
                {
#if WRITEDEBUGTEXT
                    var debugIndent = new string(' ', processor.CallStack.Count() * 4);
                    ZUtility.WriteDebugLine(debugIndent + "  => " + result.ToString("X4"));
                    ZUtility.WriteDebugLine("");
#endif
                    // this is a return from a call, store the result from the previous call
                    handleStoreResult(processor.CurrentFrame, result);
                }


                while (processor.CurrentFrame.PC > CallStackFrame.PC_EXIT)
                {
                    processor.CurrentFrame.CurrentInstruction = getInstructionByAddress(routine, processor.CurrentFrame.PC);

                    // if there is a next instruction, move the PC to it
                    var instructionIndex = routine.Instructions.IndexOf(processor.CurrentFrame.CurrentInstruction);
                    if (instructionIndex < routine.Instructions.Count() - 1)
                    {
                        processor.CurrentFrame.PC = routine.Instructions[instructionIndex + 1].InstructionAddress;
                    }

                    var operands = new object[processor.CurrentFrame.CurrentInstruction.OperandCount]; // these must contain ushort's because reflection requires us to pass them that way

                    processor.AssignOperandValues(processor.CurrentFrame.CurrentInstruction, operands);

                    var saveCallFrame = processor.CurrentFrame;

                    result = processor.Execute(processor.CurrentFrame.CurrentInstruction, operands);

                    // instruction may have null'd the frame to signal a return so we work with saveCallFrame from this point on

                    var type = ZEnums.InstructionMetadata[saveCallFrame.CurrentInstruction.Opcode];
                    if ((type & ZEnums.InstructionSpecialTypes.Store) == ZEnums.InstructionSpecialTypes.Store)
                    {
                        handleStoreResult(saveCallFrame, result);
                    }

                    processor.ReturnOperandValues(saveCallFrame, operands);

                    // if the frame has changed (i.e. a call has been made to another routine), exit this routine
                    if (processor.CurrentFrame == null)
                    {
                        saveCallFrame.IsReturn = true;
                        saveCallFrame.ReturnStore = saveCallFrame.CurrentInstruction.Store;
                        break;
                    }
                }

            }

        }

        public ZMachine()
        {

        }

        private List<ushort> prepareLocals(List<ushort> locals, ushort[] defaults, int count)
        {
            var newLocals = new List<ushort>();

            for (int i = 0; i < count; i++)
            {
                newLocals.Add(defaults[i]);
            }

            for (int i = 0; i < locals.Count(); i++)
            {
                if (i >= count)
                {
                    throw new Exception("Too many parameters passed to routine.");
                }

                newLocals[i] = locals[i];
            }

            return newLocals;

        }

        private void handleStoreResult(CallStackFrame frame,ushort result)
        {
            var store = frame.CurrentInstruction.Store;

            // store the result (this should happen before we update var by ref but can't remember what bug this resolved!)
            // if this is a store instruction, store the result

            if (store == 0x0)
            {
                // push the result on to the stack
                frame.Stack.Push(result);
            }
            else if (store <= 0xf)
            {
                // set the value to the local variable at this index
                frame.Locals[store - 1] = result;
            }
            else
            {
                // set the value to the global variable at this index
                ZUtility.SetGlobalVariable(Resources.Stream, Resources.Header, store - 0xf - 1, result);
            }

        }


        private ZInstruction getInstructionByAddress(ZRoutine routine, int address)
        {
            var instruction = routine.Instructions.FirstOrDefault(i => i.InstructionAddress == address);

            if (instruction == null)
            {
                throw new Exception("No instruction at this address.");
            }

            return instruction;

        }
        private ZRoutine getRoutineByAddress(int address)
        {
            var routine = Resources.Routines.FirstOrDefault(r => r.RoutineAddress == address);

            if (routine == null)
            {
                Resources.Stream.Position = address;
                routine = new ZRoutine(Resources, Resources.Routines.Count());
                Resources.Routines.Add(routine);
                routine.Parse();
            }

            return routine;

        }

        void parseHeader()
        {
            Resources.Stream.Position = 0;

            Resources.Header = Resources.Stream.ReadStruct<Structs.ZHeader>();

            if (Resources.Header.version != 3)
            {
                throw new NotSupportedException("We only support version 3.");
            }
        }

        void parseDictionary()
        {

            Resources.Stream.Position = Resources.Header.dictionaryAddress;

            var wordSeparatorCount = Resources.Stream.ReadByte();
            Resources.WordSeparators = Resources.Stream.ReadBytes(wordSeparatorCount).Select(b => ((char)b).ToString()).ToList();

            var entryLength = Resources.Stream.ReadByte();
            var entryCount = Resources.Stream.ReadWord();

            var words = new Dictionary<ushort, string>();

            for (var i = 0; i < entryCount; i++)
            {
                var wordAddress = (ushort)Resources.Stream.Position;

                var wordbytes = Resources.Stream.ReadBytes(4);

                var zcharacters = ZUtility.ZCharactersFromBytes(wordbytes);

                var word = ZUtility.TextFromZCharacters(zcharacters, null);

                words.Add(wordAddress, word);

                Resources.Stream.Position = Resources.Stream.Position + (entryLength - 4);
            }

            Resources.Dictionary = words;
        }

        void parseAbbreviations()
        {
            Resources.Stream.Position = Resources.Header.abbreviationsTableAddress;

            var abbreviationAddresses = new List<ushort>();
            for (var i = 0; i < 96; i++)
            {
                abbreviationAddresses.Add((ushort)Resources.Stream.ReadWord());
            }

            foreach (var abbreviationAddress in abbreviationAddresses)
            {
                Resources.Stream.Position = abbreviationAddress * 2;

                var isEnd = false;
                var zcharacters = new List<byte>();
                while (!isEnd)
                {
                    zcharacters.AddRange(ZUtility.ZCharactersFromBytes((byte)Resources.Stream.ReadByte(), (byte)Resources.Stream.ReadByte(), out isEnd));
                }
                var abbreviation = ZUtility.TextFromZCharacters(zcharacters.ToArray(), null);

                Resources.Abbreviations.Add(abbreviation);
            }
        }

        void parseObjects()
        {
            const int OBJECT_COUNT = 31;

            // we need to leave property values, atts and other meta in the stream as the game may access them directly.
            // however what is immutable (for our implementation at least) are the object names, default values and addresses of the object table
            Resources.Stream.Position = Resources.Header.objectTableAddress;

            // read default values
            var propertyDefaultsArray = Resources.Stream.ReadWords(OBJECT_COUNT);
            var propertyDefaults = new Dictionary<int, ushort>();
            for (int i = 0; i < propertyDefaultsArray.Length; i++)
            {
                // nb: properties are 1-based
                propertyDefaults.Add(i + 1, propertyDefaultsArray[i]);
            }
            Resources.PropertyDefaults = propertyDefaults;

            var objectAddresses = new List<Tuple<uint, uint>>();

            var objects = new Dictionary<int, ZObject>();
            var stopAddress = 0xffffffff;

            // object count isn't stored anywhere. instead, we determine it by stopping once we've reached the offset of the first object entry
            while (Resources.Stream.Position < stopAddress)
            {
                var objectAddress = (uint)Resources.Stream.Position;
                var header = Resources.Stream.ReadStruct<ZObjectEntry>();

                objectAddresses.Add(new Tuple<uint, uint>(objectAddress, header.propertyTableAddress));

                if (stopAddress == 0xffffffff)
                {
                    stopAddress = header.propertyTableAddress;
                }
            }

            for (int i = 0; i < objectAddresses.Count(); i++)
            {
                Resources.Stream.Position = objectAddresses[i].Item2;

                var propertyNameLength = Resources.Stream.ReadByte();

                var textBytes = Resources.Stream.ReadBytes(propertyNameLength * 2);

                var propertyName = ZUtility.TextFromZCharacters(ZUtility.ZCharactersFromBytes(textBytes), Resources.Abbreviations);

                var obj = new ZObject()
                {
                    Name = propertyName,
                    ObjectAddress = objectAddresses[i].Item1,
                    PropertyTableAddress = objectAddresses[i].Item2,
                    FirstPropertyAddress = (uint)(objectAddresses[i].Item2 + propertyNameLength * 2 + 1)
                };

                // objects are 1-based
                objects.Add(i + 1, obj);
            }

            Resources.Objects = objects;
        }

        /// <summary>
        /// hardcoded address offsets to verify our routine & instruction parsing
        /// </summary>
        void parseRoutinesSequentially()
        {
            var address = 0x4e38;

            while (address < 0x10b16)
            {
                parseRoutine(address);

                if (Resources.Routines.Last().RoutineAddress == 0x8484)
                {
                    // game contains an orphan code fragment
                    address = 0x8500;
                }
                else
                {
                    address = Resources.Routines.Last().Instructions.Last().InstructionAddress + Resources.Routines.Last().Instructions.Last().InstructionLength;

                    // if address is an odd number, add 1 because address calls are packed as /2 so they can stuff in to a short
                    if ((address % 2) == 1) address++;
                }
            }

        }

        ///// <summary>
        ///// attempts to discover routines by looking up call locations. Unfortunately, a lot of routines can't be reached
        ///// this way because their call addresses are calculated at runtime
        ///// </summary>
        ///// <param name="routineAddress"></param>
        //void parseRoutinesByStaticAnalysis(int routineAddress)
        //{
        //    parseRoutine(routineAddress);

        //    var routine = Resources.Routines.Last();

        //    // enumerate all the 'call' instructions in this routine, get their destination address
        //    // and then recursively parse those routines if we don't yet have them cached
        //    var callInstructions = routine.Instructions
        //        .Where(i => ((ZEnums.InstructionMetadata[i.Opcode] & ZEnums.InstructionSpecialTypes.Call) == ZEnums.InstructionSpecialTypes.Call))
        //        .Select(a => a);

        //    foreach (var callInstruction in callInstructions)
        //    {
        //        var childRoutineAddress = callInstruction.GetCallRoutineAddress(0);

        //        if (childRoutineAddress == 0)
        //        {
        //            Debugger.Break();
        //            ZUtility.WriteDebugLine("Skipping call to dynamic routine at " + callInstruction.InstructionAddress.ToString("X4"));
        //            continue;
        //        }

        //        if (Resources.Routines.FirstOrDefault(r => r.RoutineAddress == childRoutineAddress) == null)
        //        {
        //            ZUtility.WriteDebugLine("Analysing routine call at 0x" + childRoutineAddress.ToString("X4") + " called from 0x" + callInstruction.InstructionAddress.ToString("X4"));
        //            parseRoutinesByStaticAnalysis(childRoutineAddress);
        //        }
        //    }
        //}


        void parseRoutine(int routineAddress)
        {

            Resources.Stream.Position = routineAddress;
            var routine = new ZRoutine(Resources, Resources.Routines.Count());

            Resources.Routines.Add(routine);

            routine.Parse();
        }

        /// <summary>
        /// Generates a list of opcodes that aren't implemented based on the known routine & instructions
        /// </summary>
        string findMissingOpcodes()
        {
            var opcodes = new List<string>();

            foreach (var routine in Resources.Routines)
            {
                foreach (var instruction in routine.Instructions)
                {
                    if (!opcodes.Contains(instruction.Opcode.ToString()))
                    {
                        opcodes.Add(instruction.Opcode.ToString());
                    }
                }
            }


            for (var i = opcodes.Count() - 1; i >= 0; i--)
            {
                var method = typeof(ZProcessor).GetMethod(opcodes[i]);

                if (method != null)
                {
                    opcodes.RemoveAt(i);
                }
            }

            var missingOpcodes = string.Join("\r\n", opcodes.ToArray());

            return missingOpcodes;

        }

    }
}
