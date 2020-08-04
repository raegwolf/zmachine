using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
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

            // choose one of the following for how to load routines

            // load just the entry point (routines will be discovered dynamically at runtime)
            parseRoutine(Resources.Header.mainRoutineEntryPointAddress - 1); // -1 is actually the location of the routine

            // load by static analysis (doesn't discover all routines)
            // parseRoutinesByStaticAnalysis(Resources.Header.mainRoutineEntryPointAddress - 1);

            // load by parsing routines sequentially (works with manual skip of bad memory)
            // parseRoutinesSequentially();

            // findMissingOpcodes();
        }

        public void Run()
        {
            Resources.Processor = new ZProcessor(Resources);

            var entryRoutine = Resources.Processor.GetRoutineByAddress(Resources.Header.mainRoutineEntryPointAddress - 1);

            entryRoutine.Run(0, 0, 0, 0);
        }

        public ZMachine()
        {

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

        /// <summary>
        /// attempts to discover routines by looking up call locations. Unfortunately, a lot of routines can't be reached
        /// this way because their call addresses are calculated at runtime
        /// </summary>
        /// <param name="routineAddress"></param>
        void parseRoutinesByStaticAnalysis(int routineAddress)
        {
            parseRoutine(routineAddress);

            var routine = Resources.Routines.Last();

            // enumerate all the 'call' instructions in this routine, get their destination address
            // and then recursively parse those routines if we don't yet have them cached
            var callInstructions = routine.Instructions
                .Where(i => ((ZEnums.InstructionMetadata[i.Opcode] & ZEnums.InstructionSpecialTypes.Call) == ZEnums.InstructionSpecialTypes.Call))
                .Select(a => a);

            foreach (var callInstruction in callInstructions)
            {
                var childRoutineAddress = callInstruction.GetCallRoutineAddress(0);

                if (childRoutineAddress == 0)
                {
                    ZUtility.WriteLine("Skipping call to dynamic routine at " + callInstruction.InstructionAddress.ToString("X4"), true);
                    continue;
                }

                if (Resources.Routines.FirstOrDefault(r => r.RoutineAddress == childRoutineAddress) == null)
                {
                    ZUtility.WriteLine("Analysing routine call at 0x" + childRoutineAddress.ToString("X4") + " called from 0x" + callInstruction.InstructionAddress.ToString("X4"), true);
                    parseRoutinesByStaticAnalysis(childRoutineAddress);
                }
            }
        }


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
