using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMachine.V3
{
    public partial class ZProcessor : ZBase
    {
        public ushort call(ushort dynamicAddress, ushort param1, ushort param2, ushort param3, CallState state)
        {
            // offset to the routine to call but CurrentInstruction.GetCallRoutineAddress() calculates it properly for us.
            // this will return the dynamicAddress if appropriate
            var address = state.Instruction.GetCallRoutineAddress(dynamicAddress);

            if (address == 0)
            {
                // routine calls to address 0 are legal and return false
                return 0;
            }

            var routine = GetRoutineByAddress(address);

            // operandcount -1 is the number of params being passed as first param is the routine address
            return routine.Run(param1, param2, param3, (ushort)(state.Instruction.OperandCount - 1));
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
