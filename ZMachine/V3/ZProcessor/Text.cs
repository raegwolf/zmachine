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

            ZUtility.Write(state.Instruction.Text, false);

            return 0;
        }

        public ushort print_num(ushort value, CallState state)
        {
            ZUtility.Write(value.ToString(), false);

            return 0;
        }

        public ushort print_char(ushort value, CallState state)
        {
            ZUtility.Write(((char)value).ToString(), false);

            return 0;
        }

        public ushort new_line(CallState state)
        {
            ZUtility.WriteLine("", false);

            return 0;
        }

        public ushort print_obj(ushort obj, CallState state)
        {
            ZUtility.Write(Resources.Objects[obj].Name, false);

            return 0;
        }


    }
}
