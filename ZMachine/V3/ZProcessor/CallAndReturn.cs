using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMachine.V3
{
    public partial class ZProcessor : ZBase
    {
        public ushort call(ushort address, ushort? param1 = null, ushort? param2 = null, ushort? param3 = null)
        {
            // if address is 0, return value is false
            if (address == 0)
            {
                return 0;
            }

            var locals = new List<ushort>();
            if (param1 != null) locals.Add((ushort)param1);
            if (param2 != null) locals.Add((ushort)param2);
            if (param3 != null) locals.Add((ushort)param3);

            var newFrame = new CallStackFrame()
            {
                RoutineAddress = (int)address * 2,
                Locals = locals
            };

            // push the current frame back on to the stack, then switch to the new frame
            this.CallStack.Push(this.CurrentFrame);
            this.CallStack.Push(newFrame);
            this.CurrentFrame = null;

            return 0;

        }

        public ushort ret(ushort value)
        {
            this.CurrentFrame = null;
            return value;
        }

        public ushort ret_popped()
        {
            var result = CurrentFrame.Stack.Pop();
            this.CurrentFrame = null;
            return result;
        }

        public ushort rtrue()
        {
            this.CurrentFrame = null;
            return 1;
        }

        public ushort rfalse()
        {
            this.CurrentFrame = null;
            return 0;
        }
    }
}
