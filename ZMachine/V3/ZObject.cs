using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ZMachine.V3.Structs;

namespace ZMachine.V3
{
    /// <summary>
    /// represents a cache of immutable components of properties 
    /// </summary>
    public class ZObject
    {
        public string Name { get; set; }

        public uint ObjectAddress { get; set; }

        public uint PropertyTableAddress { get; set; }

        /// <summary>
        /// The address of the first property of the object
        /// </summary>
        public uint FirstPropertyAddress { get; set; }

        public void GoToObjectEntry(ZMemoryStream stream)
        {

            //ZUtility.WriteLine($"    Moving to object entry for object {Name}.", true);
            stream.Position = ObjectAddress;
        }

        public ZObjectEntry GetObjectEntry(ZMemoryStream stream)
        {

            //ZUtility.WriteLine($"    Getting object entry for object {Name}.", true);
            stream.Position = ObjectAddress;
            return stream.ReadStruct<ZObjectEntry>();

        }

        public void SetObjectEntry(ZMemoryStream stream, ZObjectEntry entry)
        {

            //ZUtility.WriteLine($"    Setting object entry for object {Name}.", true);
            stream.Position = ObjectAddress;
            stream.WriteStruct<ZObjectEntry>(entry);

        }

        public int GoToObjectPropertyValue(ZMemoryStream stream, ushort property, bool throwIfMissing, out byte propertyLength)
        {
            //ZUtility.WriteDebugLine($"    Moving to property {property} for object {Name}.");

            stream.Position = FirstPropertyAddress;

            var currentProperty = 0xffff;

            propertyLength = 0;

            // scan downwards through properties (they're ordered ascending) until we reach the desired one
            while (currentProperty != property)
            {
                var propertyHeader = stream.ReadByte();

                if (propertyHeader == 0)
                {
                    if (throwIfMissing)
                    {
                        throw new Exception("Property doesn't exist.");
                    }
                    else
                    {
                        return -1;
                    }
                }

                // top 3 bits contain the length of the property value - 1 (that's why we add + 1 to the number of bytes we need to read)
                propertyLength = (byte)(((propertyHeader & 0b11100000) >> 5) + 1);

                // bottom 5 bits indicate property number
                currentProperty = (propertyHeader & 0b11111);

                // if we've hit the right property, return. cursor is positioned just before property value
                if (currentProperty != property)
                {
                    stream.Position = stream.Position + propertyLength;
                }
            }

            return (int)stream.Position;
        }

        public ushort GetNextProperty(ZMemoryStream stream, ushort property)
        {
            //ZUtility.WriteLine($"    Moving to property {property} for object {Name}.", true);

            stream.Position = FirstPropertyAddress;

            var currentProperty = (ushort)0xffff;

            if (property == 0)
            {
                property = 999;
            }

            // scan downwards through properties (they're ordered ascending) until we reach the desired one
            while (currentProperty > property)
            {
                var propertyHeader = stream.ReadByte();

                if (propertyHeader == 0)
                {
                    throw new Exception("Property doesn't exist.");
                }

                // top 3 bits contain the length of the property value - 1 (that's why we add + 1 to the number of bytes we need to read)
                var propertyLength = (byte)(((propertyHeader & 0b11100000) >> 5) + 1);

                // bottom 5 bits indicate property number
                currentProperty = (ushort)(propertyHeader & 0b11111);

                // if we've hit the right property, return. cursor is positioned just before property value
                if (currentProperty != property)
                {
                    stream.Position = stream.Position + propertyLength;
                }
            }

            return currentProperty;
        }

    }
}
