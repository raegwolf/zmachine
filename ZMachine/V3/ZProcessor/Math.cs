using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace ZMachine.V3
{
    public partial class ZProcessor : ZBase
    {

        public ushort inc(ref ushort variable)
        {
            var result = (ushort)(((short)variable) + 1);

            variable = result;

            return 0;
        }

        public ushort dec(ref ushort variable)
        {

            var result = (ushort)(((short)variable) - 1);

            variable = result;
            return 0;
        }

        public ushort inc_chk(ref ushort variable, ushort value)
        {
            var result = (ushort)(variable + 1);

            variable = result;

            var conditionMet = ((short)variable > (short)value);

            return handleBranchForCurrentInstruction(conditionMet);
        }

        public ushort dec_chk(ref ushort variable, ushort value)
        {

            var result = (ushort)(variable - 1);

            variable = result;

            var conditionMet = ((short)variable < (short)value);

            return handleBranchForCurrentInstruction(conditionMet);
        }

        public ushort and(ushort a, ushort b)
        {
            return (ushort)(a & b);
        }

        public ushort or(ushort a, ushort b)
        {
            return (ushort)(a | b);
        }

        public ushort add(ushort a, ushort b)
        {
            var result = (ushort)((short)a + (short)b);

            return result;

        }

        public ushort sub(ushort a, ushort b)
        {
            var result = (ushort)((short)a - (short)b);

            return result;

        }

        public ushort mul(ushort a, ushort b)
        {
            var result = (ushort)((short)a * (short)b);

            return result;

        }

        public ushort div(ushort a, ushort b)
        {
            var result = (ushort)((short)a / (short)b);

            return result;

        }

        public ushort mod(ushort a, ushort b)
        {
            var result = (ushort)((short)a % (short)b);

            return result;

        }

        public ushort test(ushort bitmap, ushort flags)
        {
            var result = ((bitmap & flags) == flags);

            return handleBranchForCurrentInstruction(result);
        }

        public ushort random(ushort range)
        {
            if (Resources.GetRandom != null)
            {
                var result = Resources.GetRandom(1, range);

                // if 0 is returned, execute a normal random function
                if (result > 0)
                {
                    return result;
                }
            }


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
