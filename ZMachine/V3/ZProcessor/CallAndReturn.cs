using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMachine.V3
{
    public partial class ZProcessor : ZBase
    {
        public ushort call(ushort routineAddress, ushort param1, ushort param2, ushort param3, CallState state)
        {
            // get the routine for the specified address. (the address in routineAddress is the relative address to the routine to call
            // but CurrentInstruction.GetCallRoutineAddress() calculates it properly for us
            var address = state.Instruction.GetCallRoutineAddress();

            var routine = GetRoutineByAddress(address);

            return routine.Run(param1, param2, param3);
        }

        public ushort ret(ushort value, CallState state)
        {
            return value;
        }

        public ushort rtrue(CallState state)
        {
            return 1;
        }

        public ushort rfalse(CallState state)
        {
            return 0;
        }
    }
}
