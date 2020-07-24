using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ZMachine
{
    public static class MemoryStreamExtensions
    {


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

        public static ushort[] ReadWordsBe(this MemoryStream stream, int count)
        {
            var words = new ushort[count];
            for (int i = 0; i < count; i++)
            {
                words[i] = (ushort)stream.ReadWordBe();
            }
            return words;

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
    }
}
