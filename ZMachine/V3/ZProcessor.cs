using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMachine.V3
{
    public class ZProcessor : ZBase
    {

        public ZInstruction CurrentInstruction { get; set; }

        public void call(ushort routineAddress, ushort param1 = 0, ushort param2 = 0, ushort param3 = 0)
        {
            // get the routine for the specified address. (the address in routineAddress is the relative address to the routine to call
            // but CurrentInstruction.GetCallRoutineAddress() calculates it properly for us
            var address = CurrentInstruction.GetCallRoutineAddress();

            var routine = GetRoutineByAddress(address);

            routine.Run(param1, param2, param3);
        }

        public ushort add(ushort a, ushort b)
        {
            return (ushort)(((short)a) + ((short)b));

        }

        public ushort je(ushort a, ushort b, ushort c, ushort d)
        {
            if ((a == b) || (a == c) || (a == d))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public ZProcessor(ZResources resources) : base(resources)
        {
        }

        public ZRoutine GetRoutineByAddress(int address)
        {
            var routine = Resources.Routines.FirstOrDefault(r => r.RoutineAddress == address);

            if (routine == null)
            {
                Console.WriteLine("Loading routine for address " + address.ToString("X4"));

                routine = new ZRoutine(Resources, Resources.Routines.Count());
                Resources.Routines.Add(routine);
                routine.Parse();
            }

            return routine;

        }

    }
}
