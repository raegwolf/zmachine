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

        Header Header { get; set; }

        Dictionary<ushort, Routine> Routines { get; set; } = new Dictionary<ushort, Routine>();

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var routine in Routines)
            {
                sb.Append(routine.Value.ToString());
            }

            return sb.ToString();
        }

        public ZMachine(MemoryStream stream) : base(stream)
        {

            parseHeader();

            // parse the entry point routine
            // -1 because offset points to first instruction rather than start of routing
            parseRoutine(Header.entryPointOffset - 1);

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

        private void parseRoutine(int routineAddress)
        {
            Stream.Position = routineAddress;
            var routine = new Routine(Stream);

            Routines.Add(routine.RoutineAddress, routine);

            // enumerate all the 'call' instructions in this routine, get their destination address
            // and then recursively parse those routines if we don't yet have them cached
            var routineAddresses = routine.Instructions
                .Where(i => ((Enums.InstructionMetadata[i.Opcode] & Enums.InstructionSpecialTypes.Call) == Enums.InstructionSpecialTypes.Call))
                .Select(a => a.GetCallRoutineAddress());

            foreach (var calledRoutineAddress in routineAddresses)
            {
                if (!Routines.ContainsKey(calledRoutineAddress))
                {
                    parseRoutine(calledRoutineAddress);
                }
            }

        }

    }
}
