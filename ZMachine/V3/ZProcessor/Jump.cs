using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMachine.V3
{
    public partial class ZProcessor : ZBase
    {

        public ushort jump(ushort address)
        {
            // dummy method - jump action is handled in ZRoutine
            return 0;
        }

        public ushort jz(ushort a)
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

        public ushort je(ushort a, ushort b, ushort? c = null, ushort? d = null)
        {
            if (c == null)
            {
                // 2 operands
                if (a == b)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else if (d == null)
            {
                // 3 operands
                if ((a == b) || (a == c))
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                // 4 operands
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

        public ushort jg(ushort a, ushort b)
        {
            if (((ushort)a) > ((ushort)b))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public ushort jl(ushort a, ushort b)
        {
            if (((ushort)a) < ((ushort)b))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public ushort jin(ushort obj1, ushort obj2)
        {

            var entry = Resources.Objects[obj1].GetObjectEntry(Resources.Stream);

            var isDirectChild = (entry.parent == obj2);

            return isDirectChild ? (ushort)1 : (ushort)0;
        }
    }
}
