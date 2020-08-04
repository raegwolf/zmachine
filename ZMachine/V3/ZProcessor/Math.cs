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
        public ushort inc(ref ushort variable, CallState state)
        {
            variable = (ushort)(((short)variable) + 1);

            return 0;
        }

        public ushort dec(ref ushort variable, CallState state)
        {

            variable = (ushort)(((short)variable) - 1);

            return 0;
        }

        public ushort inc_chk(ref ushort variable, ushort value, CallState state)
        {
            variable++;

            if ((short)variable > (short)value)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public ushort dec_chk(ref ushort variable, ushort value, CallState state)
        {

            variable--;

            if ((short)variable < (short)value)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public ushort and(ushort a, ushort b, CallState state)
        {
            return (ushort)(a & b);
        }

        public ushort or(ushort a, ushort b, CallState state)
        {
            Debugger.Break(); // untested

            return (ushort)(a | b);
        }

        public ushort add(ushort a, ushort b, CallState state)
        {
            return (ushort)((short)a + (short)b);

        }

        public ushort sub(ushort a, ushort b, CallState state)
        {
            return (ushort)((short)a - (short)b);

        }

        public ushort mul(ushort a, ushort b, CallState state)
        {
            return (ushort)((short)a * (short)b);

        }

        public ushort div(ushort a, ushort b, CallState state)
        {
            return (ushort)((short)a / (short)b);

        }

        public ushort mod(ushort a, ushort b, CallState state)
        {
            return (ushort)((short)a % (short)b);

        }

        public ushort test(ushort bitmap, ushort flags, CallState state)
        {
            if ((bitmap & flags) == flags)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public ushort random(ushort range, CallState state)
        {
            var signedRange = (short)range;

            if (signedRange > 0)
            {
                return (ushort)(new Random().Next(signedRange) + 1);
            }
            else
            {
                Debugger.Break(); // untested
                return 0;
            }


        }



    }
}
