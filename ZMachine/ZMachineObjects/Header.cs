using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ZMachine.ZMachineObjects
{

    [StructLayout(LayoutKind.Explicit)]
    public struct Header
    {
        [FieldOffset(0x00)]
        public byte version;

        [FieldOffset(0x08)]
        public ushort dictionaryOffset;

        [FieldOffset(0x06)]
        public ushort entryPointOffset;

        [FieldOffset(0x0a)]
        public ushort objectTableOffset;


    }

}
