using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ZMachine.V3
{
    public class ZMemoryStream : MemoryStream
    {
        static int[] WATCHED_MEMORY_ADDRESSES = {

            0x00,
            // 0x30A, // object memory for cretin
            //0x45C,
            //0x6AE,
            //0x6EB,
            //0x885,
            //0x886

        };

        static int[] WATCHED_MEMORY_ADDRESSES_ALL ={

            0x0000045C,
            0x000006AE,
            0x000006EB,
            0x00000885,
            0x00000886,
            0x00002276,
            0x0000233D,
            0x0000233E,
            0x00002340,
            0x00002344,
            0x00002348,
            0x00002355,
            0x00002356,
            0x0000235E,
            0x0000236C,
            0x0000236E,
            0x00002370,
            0x0000248E,
            0x0000249A,
            0x0000255A,
            0x00002646,
            0x00002647,
            0x00002648,
            0x00002649,
            0x0000264A,
            0x0000264B,
            0x0000264C,
            0x0000264D,
            0x0000271E,
            0x0000271F,
            0x00002720,
            0x00002729,
            0x0000272A,
            0x0000272B,
            0x0000272C,
            0x0000273C,
            0x0000273E,
            0x000028CA,
            0x000028CB,
        };

        public bool Watch { get; set; }

        public override int ReadByte()
        {

            return base.ReadByte();
        }

        public override void WriteByte(byte value)
        {
            writeAlertCheck(1);
            base.WriteByte(value);
        }

        public byte[] ReadBytes(int count)
        {
            var buffer = new byte[count];
            if (base.Read(buffer, 0, count) != count)
            {
                return null;

            }

            return buffer;
        }

        public void WriteBytes(byte[] buffer)
        {
            writeAlertCheck(buffer.Length);

            base.Write(buffer, 0, buffer.Length);

        }

        public char[] ReadChars(int count)
        {
            var buffer = new byte[count];
            base.Read(buffer, 0, count);

            return System.Text.Encoding.UTF8.GetString(buffer).ToCharArray();
        }

        /// <summary>
        /// Reads an unsigned word big-endian style
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public long ReadWord()
        {
            var b1 = base.ReadByte();
            if (b1 == -1)
            {
                return -1;
            }

            var b2 = base.ReadByte();
            if (b2 == -1)
            {
                return -1;
            }
            return (ushort)((b1 << 8) + b2);
        }

        public void WriteWord(ushort word)
        {
            writeAlertCheck(2);

            var byte1 = (byte)((word & 0xff00) >> 8);
            var byte2 = (byte)((word & 0xff));

            base.WriteByte(byte1);
            base.WriteByte(byte2);

        }

        public void WriteInt(uint value)
        {
            writeAlertCheck(4);

            base.WriteByte((byte)((value & 0xff000000) >> 24));
            base.WriteByte((byte)((value & 0xff0000) >> 16));
            base.WriteByte((byte)((value & 0xff00) >> 8));
            base.WriteByte((byte)((value & 0xff) >> 0));
        }


        public ushort[] ReadWords(int count)
        {
            var words = new ushort[count];
            for (int i = 0; i < count; i++)
            {
                words[i] = (ushort)ReadWord();
            }
            return words;

        }

        public T ReadStruct<T>() where T : struct
        {
            var obj = readStructInternal<T>();

            swapEndianness(ref obj);

            return obj;

        }

        public void WriteStruct<T>(T obj) where T : struct
        {
            writeAlertCheck(Marshal.SizeOf(typeof(T)));

            swapEndianness<T>(ref obj);

            writeStructInternal<T>(obj);
        }

        public ZMemoryStream(byte[] buffer) : base(buffer)
        {
        }

        T readStructInternal<T>() where T : struct
        {
            var bufferSize = Marshal.SizeOf(typeof(T));

            var byteArray = new byte[bufferSize];
            base.Read(byteArray, 0, bufferSize);

            IntPtr handle = Marshal.AllocHGlobal(bufferSize);
            Marshal.Copy(byteArray, 0, handle, bufferSize);

            return Marshal.PtrToStructure<T>(handle);
        }

        void writeStructInternal<T>(T obj) where T : struct
        {
            int size = Marshal.SizeOf(typeof(T));
            byte[] buffer = new byte[size];

            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(obj, ptr, true);
            Marshal.Copy(ptr, buffer, 0, size);
            Marshal.FreeHGlobal(ptr);

            base.Write(buffer, 0, size);
        }

        void swapEndianness<T>(ref T obj) where T : struct
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

        private void writeAlertCheck(int length)
        {
            if (!Watch) return;

            var min = base.Position;
            var max = base.Position + length;

            foreach (var watchedAddress in WATCHED_MEMORY_ADDRESSES)
            {
                if ((watchedAddress >= min) && (watchedAddress <= max))
                {
                    Console.WriteLine("Writing watched memory " + watchedAddress.ToString("X"));
                    Debugger.Break();
                }
            }

        }

    }
}
