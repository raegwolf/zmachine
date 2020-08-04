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
            // this opcode has a variable number of operands
            switch (state.Instruction.OperandCount)
            {
                case 2:
                    if (a == b)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }


                case 3:
                    if ((a == b) || (a == c))
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }

                case 4:
                    if ((a == b) || (a == c) || (a == d))
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }

                default:
                    throw new NotSupportedException();

            }

        }

        public ushort jg(ushort a, ushort b, CallState state)
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

        public ushort jl(ushort a, ushort b, CallState state)
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

        public ushort jin(ushort obj1, ushort obj2, CallState state)
        {

            var entry = Resources.Objects[obj1].GetObjectEntry(Resources.Stream);
            
                        var isDirectChild = (entry.parent == obj2);

            if (isDirectChild)
            {
               // Console.WriteLine(Resources.Objects[obj1].Name + " is a child of " + Resources.Objects[obj2].Name);
                return 1;
            }
            else
            {
               // Console.WriteLine(Resources.Objects[obj1].Name + " is not a child of " + Resources.Objects[obj2].Name);
                return 0;
            }
        }
    }
}
