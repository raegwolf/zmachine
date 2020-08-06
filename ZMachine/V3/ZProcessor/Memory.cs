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
        public ushort load(ref ushort variable, CallState state)
        {
            return variable;
        }

        public ushort store(ref ushort variable, ushort value, CallState state)
        {

            variable = value;
            return 0;
        }

        public ushort loadb(ushort arrayAddress, ushort byteIndex, CallState state)
        {
            Resources.Stream.Position = arrayAddress + byteIndex;
            return (ushort)Resources.Stream.ReadByte();
        }

        public ushort loadw(ushort arrayAddress, ushort wordIndex, CallState state)
        {
            Resources.Stream.Position = arrayAddress + 2 * wordIndex;
            return (ushort)Resources.Stream.ReadWord();
        }

        public ushort storeb(ushort arrayAddress, ushort byteIndex, ushort value, CallState state)
        {
            Resources.Stream.Position = arrayAddress + byteIndex;
            Resources.Stream.WriteByte((byte)value);
            return 0;
        }

        public ushort storew(ushort arrayAddress, ushort wordIndex, ushort value, CallState state)
        {
            Resources.Stream.Position = arrayAddress + 2 * wordIndex;
            Resources.Stream.WriteWord(value);
            return 0;
        }



    }
}
