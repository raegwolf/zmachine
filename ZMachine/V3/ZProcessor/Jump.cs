using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMachine.V3
{
    public partial class ZProcessor : ZBase
    {

        public ushort jump(ushort address, CallState state)
        {
            // dummy method - jump action is handled in ZRoutine
            return 0;
        }

        public ushort jz(ushort a, CallState state)
        {
            if (a == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public ushort je(ushort a, ushort b, ushort c, ushort d, CallState state)
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
    }
}
