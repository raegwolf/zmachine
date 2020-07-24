using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMachine
{
    class Utility
    {
       public  static byte[] getZCharacters(byte byte1, byte byte2)
        {
            var chars = new byte[3];

            chars[0] = (byte)((byte1 & 0b01111100) >> 2);
            chars[1] = (byte)(((byte1 & 0b00000011) << 3) + ((byte2 & 0b11100000) >> 5));
            chars[2] = (byte)(byte2 & 0b0011111);

            return chars;

        }

        public static string wordFromBytes(byte[] zchars)
        {
            var s = "";

            foreach (var zchar in zchars)
            {
                var c = '.';

                switch (zchar)
                {
                    case 0x06: c = 'a'; break;
                    case 0x07: c = 'b'; break;
                    case 0x08: c = 'c'; break;
                    case 0x09: c = 'd'; break;
                    case 0x0a: c = 'e'; break;
                    case 0x0b: c = 'f'; break;
                    case 0x0c: c = 'g'; break;
                    case 0x0d: c = 'h'; break;
                    case 0x0e: c = 'i'; break;
                    case 0x0f: c = 'j'; break;
                    case 0x10: c = 'k'; break;
                    case 0x11: c = 'l'; break;
                    case 0x12: c = 'm'; break;
                    case 0x13: c = 'n'; break;
                    case 0x14: c = 'o'; break;
                    case 0x15: c = 'p'; break;
                    case 0x16: c = 'q'; break;
                    case 0x17: c = 'r'; break;
                    case 0x18: c = 's'; break;
                    case 0x19: c = 't'; break;
                    case 0x1a: c = 'u'; break;
                    case 0x1b: c = 'v'; break;
                    case 0x1c: c = 'w'; break;
                    case 0x1d: c = 'x'; break;
                    case 0x1e: c = 'y'; break;
                    case 0x1f: c = 'z'; break;
                    default: c = '_'; break;
                }

                s += c;
            }

            return s;
        }

       
    }
}
