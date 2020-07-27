using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMachine.V3
{
    public partial class ZProcessor : ZBase
    {
        public ushort print(CallState state)
        {

            Utility.Write(state.Instruction.Text, false);

            return 0;
        }

        public ushort print_num(ushort value, CallState state)
        {
            Utility.Write(value.ToString(), false);

            return 0;
        }

        public ushort print_char(ushort value, CallState state)
        {
            Utility.Write(((char)value).ToString(), false);

            return 0;
        }

        public ushort new_line(CallState state)
        {
            Utility.WriteLine("", false);

            return 0;
        }

    }
}
