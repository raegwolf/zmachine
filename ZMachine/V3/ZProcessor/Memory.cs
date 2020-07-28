using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMachine.V3
{
    public partial class ZProcessor : ZBase
    {

        public ushort loadb(ushort arrayAddress, ushort wordIndex, CallState state)
        {
            Resources.Stream.Position = arrayAddress * 2 + wordIndex;
            return (ushort)Resources.Stream.ReadByte();
        }

        public ushort loadw(ushort arrayAddress, ushort wordIndex, CallState state)
        {
            Resources.Stream.Position = arrayAddress * 2 + wordIndex;
            return (ushort)Resources.Stream.ReadWordBe();
        }

        public ushort storeb(ushort arrayAddress, ushort wordIndex, ushort value, CallState state)
        {
            Resources.Stream.Position = arrayAddress * 2 + wordIndex;
            Resources.Stream.WriteByte((byte)value);
            return 0;
        }

        public ushort storew(ushort arrayAddress, ushort wordIndex, ushort value, CallState state)
        {
            Resources.Stream.Position = arrayAddress * 2 + wordIndex;
            Resources.Stream.WriteWordBe(value);
            return 0;
        }

        public ushort store(ref ushort variable, ushort value, CallState state)
        {
            variable = value;
            return 0;
        }

    }
}
