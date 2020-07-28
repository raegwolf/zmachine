using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMachine.V3
{
    public partial class ZProcessor : ZBase
    {
        public ushort call(ushort ignoredRoutineAddress, ushort param1, ushort param2, ushort param3, CallState state)
        {
            // get the routine for the specified address. (the address in ignoredRoutineAddress is the relative
            // offset to the routine to call but CurrentInstruction.GetCallRoutineAddress() calculates it properly for us
            var address = state.Instruction.GetCallRoutineAddress();

            if (address == 0)
            {
                // routine calls to address 0 are legal return false
                return 0;
            }

            var routine = GetRoutineByAddress(address);

            return routine.Run(param1, param2, param3);
        }

        public ushort ret(ushort value, CallState state)
        {
            return value;
        }

        public ushort ret_popped(CallState state)
        {
            return state.Stack.Pop();
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
