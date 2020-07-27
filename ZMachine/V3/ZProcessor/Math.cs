using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMachine.V3
{
    public partial class ZProcessor : ZBase
    {
        public ushort and(ushort a, ushort b, CallState state)
        {
            return (ushort)(a & b);
        }


        public ushort add(ushort a, ushort b, CallState state)
        {
            return (ushort)(((short)a) + ((short)b));

        }

        public ushort sub(ushort a, ushort b, CallState state)
        {
            return (ushort)(((short)a) - ((short)b));

        }

        public ushort inc_chk(ref ushort variable, ushort value, CallState state)
        {
            variable++;

            if (variable > value)
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
