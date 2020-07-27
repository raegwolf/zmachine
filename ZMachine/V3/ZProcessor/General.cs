using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMachine.V3
{
    public partial class ZProcessor : ZBase
    {

        public ushort push(ushort value, CallState state)
        {
            state.Stack.Push(value);

            return 0;
        }

        public ushort pull(ref ushort variable, CallState state)
        {
            variable= state.Stack.Pop();

            return 0;
        }
    }
}
