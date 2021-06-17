#define SANDBOX_SAFE

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
        public override int ReadByte()
        {
            return base.ReadByte();
        }

        public override void WriteByte(byte value)
        {
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
            var byte1 = (byte)((word & 0xff00) >> 8);
            var byte2 = (byte)((word & 0xff));

            base.WriteByte(byte1);
            base.WriteByte(byte2);

        }

        public void WriteInt(uint value)
        {
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
            swapEndianness<T>(ref obj);

            writeStructInternal<T>(obj);
        }

        public static byte[] CloneByteArray(byte[] buffer)
        {
            var buffer2 = new byte[buffer.Length];
            buffer.CopyTo(buffer2, 0);
            return buffer2;
        }

        public ZMemoryStream(byte[] buffer) : base(CloneByteArray(buffer))
        {
        }

        T readStructInternal<T>() where T : struct
        {
            var bufferSize = Marshal.SizeOf(typeof(T));

            var byteArray = new byte[bufferSize];
            base.Read(byteArray, 0, bufferSize);

#if SANDBOX_SAFE
            if (typeof(T) == typeof(Objects.ZHeader))
            {
                var header = new Objects.ZHeader();
                header.version = byteArray[0x00];
                header.mainRoutineEntryPointAddress = (ushort)((int)byteArray[0x06] + ((int)byteArray[0x07] << 8));
                header.dictionaryAddress = (ushort)((int)byteArray[0x08] + ((int)byteArray[0x09] << 8));
                header.objectTableAddress = (ushort)((int)byteArray[0x0a] + ((int)byteArray[0x0b] << 8));
                header.globalVariablesTableAddress = (ushort)((int)byteArray[0x0c] + ((int)byteArray[0x0d] << 8));
                header.abbreviationsTableAddress = (ushort)((int)byteArray[0x18] + ((int)byteArray[0x19] << 8));

                return (T)(header as object);

            }
            else if (typeof(T) == typeof(Objects.ZObjectEntry))
            {
                var entry = new Objects.ZObjectEntry();
                entry.attributes1 = byteArray[0x00];
                entry.attributes2 = byteArray[0x01];
                entry.attributes3 = byteArray[0x02];
                entry.attributes4 = byteArray[0x03];
                entry.parent = byteArray[0x04];
                entry.sibling = byteArray[0x05];
                entry.child = byteArray[0x06];
                entry.propertyTableAddress = (ushort)((int)byteArray[0x07] + ((int)byteArray[0x08] << 8));

                return (T)(entry as object);
            }
            else
            {
                throw new NotImplementedException();
            }
#else
            IntPtr handle = Marshal.AllocHGlobal(bufferSize);
            Marshal.Copy(byteArray, 0, handle, bufferSize);

            return Marshal.PtrToStructure<T>(handle);
#endif
        }

        void writeStructInternal<T>(T obj) where T : struct
        {
            int size = Marshal.SizeOf(typeof(T));
            byte[] buffer = new byte[size];

#if SANDBOX_SAFE

            if (typeof(T) == typeof(Objects.ZHeader))
            {
                throw new NotImplementedException();
            }
            else if (typeof(T) == typeof(Objects.ZObjectEntry))
            {
                var entry = (Objects.ZObjectEntry)(obj as object);

                buffer[0] = entry.attributes1;
                buffer[1] = entry.attributes2;
                buffer[2] = entry.attributes3;
                buffer[3] = entry.attributes4;
                buffer[4] = entry.parent;
                buffer[5] = entry.sibling;
                buffer[6] = entry.child;

                buffer[7] = (byte)((entry.propertyTableAddress & 0xff));
                buffer[8] = (byte)((entry.propertyTableAddress & 0xff00) >> 8); 
            }
            else
            {
                throw new NotImplementedException();
            }

            
#else
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(obj, ptr, true);
            Marshal.Copy(ptr, buffer, 0, size);
            Marshal.FreeHGlobal(ptr);
#endif
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

    }
}
