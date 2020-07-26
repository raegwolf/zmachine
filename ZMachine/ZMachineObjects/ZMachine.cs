using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZMachine.ZMachineObjects;

namespace ZMachine.ZMachineObjects
{
    class ZMachine:ZMachineObjectBase
    {
   
        Header Header { get; set; }

        Dictionary<short, Routine> Routines { get; set; } = new Dictionary<short, Routine>();

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var routine in Routines)
            {
                sb.Append(routine.ToString());
            }

            return sb.ToString();
        }

        public ZMachine(MemoryStream stream):base(stream)
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

            if (Routines.ContainsKey(routine.RoutineAddress))
            {
                return;
            }

            Routines.Add(routine.RoutineAddress, routine);




        }

    }
}
