using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMachine.V3
{
    public partial class ZProcessor : ZBase
    {
        public class CallState
        {
            public ZInstruction Instruction { get; set; }

            public Stack<ushort> Stack { get; set; }

            /// <summary>
            /// Used for indenting debug output
            /// </summary>
            public int CallDepth { get; set; }
        }

        public ZProcessor(ZResources resources) : base(resources)
        {
        }

        public ZRoutine GetRoutineByAddress(int address)
        {
            var routine = Resources.Routines.FirstOrDefault(r => r.RoutineAddress == address);

            if (routine == null)
            {
                //ZUtility.WriteLine("Loading routine for address " + address.ToString("X4"), true);

                Resources.Stream.Position = address;
                routine = new ZRoutine(Resources, Resources.Routines.Count());
                Resources.Routines.Add(routine);
                routine.Parse();
            }

            return routine;

        }

    }
}
