using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ZMachine.V3.Structs
{

    [StructLayout(LayoutKind.Sequential, Pack = 1)] // Pack is required because struct is an odd number of bytes
    public struct ZObjectEntry
    {
        public byte attributes1;
        public byte attributes2;
        public byte attributes3;
        public byte attributes4;

        public byte parent;

        public byte sibling;

        public byte child;

        public ushort propertyTableAddress;
    }

}
