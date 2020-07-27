#define PARSEBYSTATICANALYSIS_DISABLED // can't fully enumerate routines because some routine addresses are dynamically computed

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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


        public void Load(MemoryStream stream)
        {
            Resources.Stream = stream;

            parseHeader();

            parseGlobalVariables();

            parseAbbreviations();

#if PARSEBYSTATICANALYSIS
            // -1 because offset points to first instruction rather than start of routing
            parseRoutinesByStaticAnalysis(Header.mainRoutineEntryPointAddress - 1);
#else
            parseRoutinesSequentially();
#endif
        }

        public void Run()
        {
            Resources.Processor = new ZProcessor(Resources);

            var entryRoutine = Resources.Processor.GetRoutineByAddress(Resources.Header.mainRoutineEntryPointAddress - 1);

            entryRoutine.Run();
        }

        public ZMachine()
        {

        }

        void parseHeader()
        {
            Resources.Stream.Position = 0;

            Resources.Header = Resources.Stream.ReadStructBe<ZHeader>();

            if (Resources.Header.version != 3)
            {
                throw new NotSupportedException("We only support version 3.");
            }
        }

        void parseGlobalVariables()
        {

            Resources.Stream.Position = Resources.Header.globalVariablesTableAddress;

            for (int i = 0; i < 240; i++)
            {
                Resources.GlobalVariables.Add((ushort)Resources.Stream.ReadWordBe());
            }
        }

        void parseAbbreviations()
        {
            Resources.Stream.Position = Resources.Header.abbreviationsTableAddress;

            var abbreviationAddresses = new List<ushort>();
            for (var i = 0; i < 96; i++)
            {
                abbreviationAddresses.Add((ushort)Resources.Stream.ReadWordBe());
            }

            foreach (var abbreviationAddress in abbreviationAddresses)
            {
                Resources.Stream.Position = abbreviationAddress * 2;

                var isEnd = false;
                var zcharacters = new List<byte>();
                while (!isEnd)
                {
                    zcharacters.AddRange(Utility.GetZCharacters((byte)Resources.Stream.ReadByte(), (byte)Resources.Stream.ReadByte(), out isEnd));
                }
                var abbreviation = Utility.TextFromZCharacters(zcharacters.ToArray(), null);

                Resources.Abbreviations.Add(abbreviation);
            }
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
                var childRoutineAddress = callInstruction.GetCallRoutineAddress();

                if (childRoutineAddress == 0)
                {
                    Utility.WriteLine("Skipping call to dynamic routine at " + callInstruction.InstructionAddress.ToString("X4"), true);
                    continue;
                }

                if (Resources.Routines.FirstOrDefault(r => r.RoutineAddress == childRoutineAddress) == null)
                {
                    Utility.WriteLine("Analysing routine call at 0x" + childRoutineAddress.ToString("X4") + " called from 0x" + callInstruction.InstructionAddress.ToString("X4"), true);
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

    }
}
