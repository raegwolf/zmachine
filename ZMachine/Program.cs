

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace ZMachine
{
    public static class MemoryStreamExtensions
    {
        [StructLayout(LayoutKind.Explicit)]
        struct ZMachineHeader
        {
            [FieldOffset(0x00)]
            public byte version;

            [FieldOffset(0x08)]
            public ushort dictionaryOffset;

            [FieldOffset(0x2a)]
            public ushort staticStringsOffset; // must be multiplied by 8

        }

        public static byte[] ReadBytes(this MemoryStream stream, int count)
        {
            var buffer = new byte[count];
            if (stream.Read(buffer, 0, count) != count)
            {
                return null;

            }

            return buffer;
        }

        public static char[] ReadChars(this MemoryStream stream, int count)
        {
            var buffer = new byte[count];
            stream.Read(buffer, 0, count);

            return System.Text.Encoding.UTF8.GetString(buffer).ToCharArray();
        }

        /// <summary>
        /// Reads an unsigned word big-endian style
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static long ReadWordBe(this MemoryStream stream)
        {
            var b1 = stream.ReadByte();
            if (b1 == -1)
            {
                return -1;
            }

            var b2 = stream.ReadByte();
            if (b2 == -1)
            {
                return -1;
            }
            return (ushort)((b1 << 8) + b2);
        }


        public static T ReadStruct<T>(this MemoryStream stream) where T : struct
        {
            var bufferSize = Marshal.SizeOf(typeof(T));

            var byteArray = new byte[bufferSize];
            stream.Read(byteArray, 0, bufferSize);

            IntPtr handle = Marshal.AllocHGlobal(bufferSize);
            Marshal.Copy(byteArray, 0, handle, bufferSize);

            return Marshal.PtrToStructure<T>(handle);
        }

        public static T ReadStructBe<T>(this MemoryStream stream) where T : struct
        {
            var obj = ReadStruct<T>(stream);

            // get a list of fields of type short/ushort
            // note that only public fields are included here
            var fields = obj.GetType().GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                .Where(f => (f.FieldType.Equals(typeof(ushort)) || (f.FieldType.Equals(typeof(short)))));

            foreach (var field in fields)
            {
                if (field.FieldType == typeof(short))
                {
                    throw new NotSupportedException("Only unsigned words (ushort) are supported.");
                }

                // read the current word (little endian ordered)
                var value = Convert.ToUInt16(field.GetValue(obj));

                // convert this in to a big endian word by swapping the two bytes around
                var newValue = (UInt16)(((value & 0xff00) >> 8) + ((value & 0xff) << 8));

                // write it back. we must use SetValueDirect not SetValue
                field.SetValueDirect(__makeref(obj), newValue);
            }

            return obj;

        }

        class Program

        {
            static byte[] getZCharacters(byte byte1, byte byte2)
            {
                var chars = new byte[3];

                chars[0] = (byte)((byte1 & 0b01111100) >> 2);
                chars[1] = (byte)(((byte1 & 0b00000011) << 3) + ((byte2 & 0b11100000) >> 5));
                chars[2] = (byte)(byte2 & 0b0011111);

                return chars;

            }

            static string wordFromBytes(byte[] zchars)
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

            static Dictionary<int, string> getWords(MemoryStream stream, int count, int wordEntryLength)
            {
                var list = new Dictionary<int, string>();


                // read the words
                for (int i = 0; i < count; i++)
                {
                    // read a word
                    var wordBytes = stream.ReadBytes(wordEntryLength);

                    var words1 = getZCharacters(wordBytes[0], wordBytes[1]);
                    var words2 = getZCharacters(wordBytes[2], wordBytes[3]);

                    var wordsCombined = new byte[6];
                    wordsCombined[0] = (byte)(words1[0]);
                    wordsCombined[1] = (byte)(words1[1]);
                    wordsCombined[2] = (byte)(words1[2]);
                    wordsCombined[3] = (byte)(words2[0]);
                    wordsCombined[4] = (byte)(words2[1]);
                    wordsCombined[5] = (byte)(words2[2]);

                    var word = wordFromBytes(wordsCombined);

                    list.Add(i, word);
                }

                return list;
            }

            static void getStrings(MemoryStream stream)
            {

            }

            static void Main(string[] args)
            {

                var machineBytes = File.ReadAllBytes(@"D:\data\src\ZMachine\ZMachine\data\zork1.dat");

                var stream = new MemoryStream(machineBytes);
                stream.Position = 0;

                var header = stream.ReadStructBe<ZMachineHeader>();

                if (header.version != 3)
                {
                    throw new NotSupportedException("We only support version 3.");
                }

                stream.Position = header.dictionaryOffset;
                var wordSeparatorCount = stream.ReadByte(); // number of separators chars defined (separators break words apart for lexical parsing)
                var wordSeparators = stream.ReadChars(wordSeparatorCount); // characters that are separators (should be period, comma, quote)

                var wordEntryLength = stream.ReadByte(); // length of a single word in the dictionary in bytes

                var wordCount = stream.ReadWordBe(); // number of words in the dictionary

                var words = getWords(stream, (ushort)wordCount, wordEntryLength);

                var l = words.Where(f => f.Value.Contains("cor"));

                stream.Position = header.staticStringsOffset * 8;
                getStrings(stream);


                stream.Position = 0;

                var combined = new StringBuilder();

                var eof = false;
                while (!eof)
                {
                    var b = stream.ReadBytes(2);
                    if (b == null)
                    {
                        eof = true;
                        break;
                    }

                    combined.Append(wordFromBytes(getZCharacters(b[0], b[1])));

                }

                var path = @"D:\data\src\ZMachine\ZMachine\data\words.txt";
                if (File.Exists(path)) File.Delete(path);
                File.AppendAllText(path, combined.ToString());



                var done = true;

            }
        }
    }
}
