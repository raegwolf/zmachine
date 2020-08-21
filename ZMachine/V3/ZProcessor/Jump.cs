using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ZMachine.V3
{
    public partial class ZProcessor : ZBase
    {

        public ushort jump(ushort address)
        {
            this.CurrentFrame.PC = this.CurrentInstruction.InstructionAddress + this.CurrentInstruction.InstructionLength + ((short)address) - 2;

            return 0;
        }

        public ushort jz(ushort a)
        {
            var result = (a == 0);

            return handleBranchForCurrentInstruction(result);
        }

        public ushort je(ushort a, ushort b, ushort? c = null, ushort? d = null)
        {
            var result = false;

            if (c == null)
            {
                // 2 operands
                result = (a == b);
            }
            else if (d == null)
            {
                // 3 operands
                result = ((a == b) || (a == c));
            }
            else
            {
                // 4 operands
                result = ((a == b) || (a == c) || (a == d));
            }

            return handleBranchForCurrentInstruction(result);

        }

        public ushort jg(ushort a, ushort b)
        {
            var result = ((ushort)a) > ((ushort)b);

            return handleBranchForCurrentInstruction(result);
        }

        public ushort jl(ushort a, ushort b)
        {
            var result = (((ushort)a) < ((ushort)b));

            return handleBranchForCurrentInstruction(result);
        }

        public ushort jin(ushort obj1, ushort obj2)
        {
            var entry = Resources.Objects[obj1].GetObjectEntry(Resources.Stream);

            var isDirectChild = (entry.parent == obj2);

            return handleBranchForCurrentInstruction(isDirectChild);
        }
    }
}
