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

        public static void WriteBytes(this MemoryStream stream, byte[] buffer)
        {

            stream.Write(buffer, 0, buffer.Length);

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

        public static void WriteWordBe(this MemoryStream stream, ushort word)
        {
            var byte1 = (byte)((word & 0xff00) >> 8);
            var byte2 = (byte)((word & 0xff));

            stream.WriteByte(byte1);
            stream.WriteByte(byte2);

        }

        public static void WriteIntBe(this MemoryStream stream, uint value)
        {
            stream.WriteByte((byte)((value & 0xff000000) >> 24));
            stream.WriteByte((byte)((value & 0xff0000) >> 16));
            stream.WriteByte((byte)((value & 0xff00) >> 8));
            stream.WriteByte((byte)((value & 0xff) >> 0));
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

        public static T ReadStructBe<T>(this MemoryStream stream) where T : struct
        {
            var obj = readStructInternal<T>(stream);

            swapEndianness(ref obj);

            return obj;

        }

        public static void WriteStructBe<T>(this MemoryStream stream, T obj) where T : struct
        {
            swapEndianness<T>(ref obj);

            writeStructInternal<T>(stream, obj);
        }


        static T readStructInternal<T>(this MemoryStream stream) where T : struct
        {
            var bufferSize = Marshal.SizeOf(typeof(T));

            var byteArray = new byte[bufferSize];
            stream.Read(byteArray, 0, bufferSize);

            IntPtr handle = Marshal.AllocHGlobal(bufferSize);
            Marshal.Copy(byteArray, 0, handle, bufferSize);

            return Marshal.PtrToStructure<T>(handle);
        }

        static void writeStructInternal<T>(this MemoryStream stream, T obj) where T : struct
        {
            int size = Marshal.SizeOf(typeof(T));
            byte[] buffer = new byte[size];

            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(obj, ptr, true);
            Marshal.Copy(ptr, buffer, 0, size);
            Marshal.FreeHGlobal(ptr);

            stream.Write(buffer, 0, size);
        }

        static void swapEndianness<T>(ref T obj) where T : struct
        {
            // get a list of fields of type short/ushort
            // note that only public fields are included here
            var fields = obj.GetType().GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                .Where(f =>
                    f.FieldType.Equals(typeof(ushort)) ||
                    f.FieldType.Equals(typeof(short)) ||
                    f.FieldType.Equals(typeof(uint)) ||
                    f.FieldType.Equals(typeof(int))
                );

            foreach (var field in fields)
            {
                if (field.FieldType == typeof(ushort))
                {
                    var value = Convert.ToUInt16(field.GetValue(obj));

                    var newValue = (ushort)(
                        ((value & 0xff00) >> 8) +
                        ((value & 0xff) << 8)
                    );

                    field.SetValueDirect(__makeref(obj), newValue);
                }
                else
                {
                    throw new NotSupportedException("Only unsigned words (ushort) are supported.");
                }
            }

        }
    }
}
