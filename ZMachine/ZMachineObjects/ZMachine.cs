#define PARSEBYSTATICANALYSIS_DISABLED // can't fully enumerate routines because some routine addresses are dynamically computed

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZMachine.ZMachineObjects;

namespace ZMachine.ZMachineObjects
{
    class ZMachine : ZMachineObjectBase
    {

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var routine in Routines)
            {
                sb.Append(routine.ToString());
            }

            return sb.ToString();
        }


        public ZMachine(MemoryStream stream)
        {
            base.Stream = stream;

            parseHeader();

            parseAbbreviations();

#if PARSEBYSTATICANALYSIS
            // -1 because offset points to first instruction rather than start of routing
            parseRoutinesByStaticAnalysis(Header.mainRoutineEntryPointAddress - 1);
#else
             parseRoutinesSequentially();
#endif



        }

        void parseHeader()
        {
            Stream.Position = 0;

            Header = Stream.ReadStructBe<Header>();

            if (Header.version != 3)
            {
                throw new NotSupportedException("We only support version 3.");
            }
        }

        void parseAbbreviations()
        {
            Stream.Position = Header.abbreviationsTableAddress;

            var abbreviationAddresses = new List<ushort>();
            for (var i = 0; i < 96; i++)
            {
                abbreviationAddresses.Add((ushort)Stream.ReadWordBe());
            }

            foreach (var abbreviationAddress in abbreviationAddresses)
            {
                Stream.Position = abbreviationAddress * 2;

                var isEnd = false;
                var zcharacters = new List<byte>();
                while (!isEnd)
                {
                    zcharacters.AddRange(Utility.GetZCharacters((byte)Stream.ReadByte(), (byte)Stream.ReadByte(), out isEnd));
                }
                var abbreviation = Utility.TextFromZCharacters(zcharacters.ToArray(), null);

                Abbreviations.Add(abbreviation);
            }
        }

        void parseRoutinesSequentially()
        {
            var address = 0x4e38;

            while (address< 0x10b16)
            {
                parseRoutine(address);

                if (this.Routines.Last().RoutineAddress == 0x8484)
                {
                    // game contains an orphan code fragment
                    address = 0x8500;
                }
                else
                {
                    address = this.Routines.Last().Instructions.Last().InstructionAddress + this.Routines.Last().Instructions.Last().InstructionLength;

                    // if address is an odd number, add 1 because address calls are packed as /2 so they can stuff in to a short
                    if ((address % 2) == 1) address++;
                }
            }

        }

        void parseRoutinesByStaticAnalysis(int routineAddress)
        {
            parseRoutine(routineAddress);

            var routine = this.Routines.Last();

            // enumerate all the 'call' instructions in this routine, get their destination address
            // and then recursively parse those routines if we don't yet have them cached
            var callInstructions = routine.Instructions
                .Where(i => ((Enums.InstructionMetadata[i.Opcode] & Enums.InstructionSpecialTypes.Call) == Enums.InstructionSpecialTypes.Call))
                .Select(a => a);

            foreach (var callInstruction in callInstructions)
            {
                var childRoutineAddress = callInstruction.GetCallRoutineAddress();

                if (childRoutineAddress == 0)
                {
                    Console.WriteLine("Skipping call to dynamic routine at " + callInstruction.InstructionAddress.ToString("X4"));
                    continue;
                }

                if (Routines.FirstOrDefault(r => r.RoutineAddress == childRoutineAddress) == null)
                {
                    Console.WriteLine("Analysing routine call at 0x" + childRoutineAddress.ToString("X4") + " called from 0x" + callInstruction.InstructionAddress.ToString("X4"));
                    parseRoutinesByStaticAnalysis(childRoutineAddress);
                }
            }
        }


        void parseRoutine(int routineAddress)
        {

            Stream.Position = routineAddress;
            var routine = new Routine(this, this.Routines.Count());

            Routines.Add(routine);

            routine.Parse();



        }

    }
}
