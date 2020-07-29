using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using ZMachine.V3.Structs;

namespace ZMachine.V3
{
    public partial class ZProcessor : ZBase
    {
        public ushort test_attr(ushort obj, ushort attributeNumber, CallState state)
        {
            var objectEntry = Resources.Objects[obj].GetObjectEntry(Resources.Stream);

            var attributes = (uint)(objectEntry.attributes1 << 24) + (objectEntry.attributes2 << 16) + (objectEntry.attributes3 << 8) + objectEntry.attributes4;

            var mask = 1 << (int)(31 - attributeNumber);

            var isSet = ((attributes & mask) == mask);

            return isSet ? (ushort)1 : (ushort)0;
        }

        public ushort set_attr(ushort obj, ushort attributeNumber, CallState state)
        {
            var objectEntry = Resources.Objects[obj].GetObjectEntry(Resources.Stream);

            var attributes = (uint)((objectEntry.attributes1 << 24) + (objectEntry.attributes2 << 16) + (objectEntry.attributes3 << 8) + objectEntry.attributes4);

            var mask = (uint)(1 << (int)(31 - attributeNumber));

            attributes = (uint)(attributes | mask);

            Resources.Objects[obj].GoToObjectEntry(Resources.Stream);
            Resources.Stream.WriteIntBe(attributes);

            return 0;
        }

        public ushort clear_attr(ushort obj, ushort attributeNumber, CallState state)
        {
            // TODO: untested
            var objectEntry = Resources.Objects[obj].GetObjectEntry(Resources.Stream);

            var attributes = (uint)((objectEntry.attributes1 << 24) + (objectEntry.attributes2 << 16) + (objectEntry.attributes3 << 8) + objectEntry.attributes4);

            var mask = (uint)(0xffffffff - (1 << (int)(31 - attributeNumber)));

            attributes = (uint)(attributes & mask);

            Resources.Objects[obj].GoToObjectEntry(Resources.Stream);
            Resources.Stream.WriteIntBe(attributes);

            return 0;
        }


        public ushort get_prop(ushort obj, ushort property, CallState state)
        {
            // if prop doesn't exist, return prop default
            byte propertyLength;
            var exists = (Resources.Objects[obj].GoToObjectPropertyValue(Resources.Stream, property, false, out propertyLength) > 0);

            if (!exists)
            {
                return Resources.PropertyDefaults[property];
            }

            if (propertyLength == 1)
            {
                return (ushort)Resources.Stream.ReadByte();
            }
            else
            {
                return (ushort)Resources.Stream.ReadWordBe();
            }
        }

        public ushort get_prop_len(ushort propertyAddress, CallState state)
        {
            if (propertyAddress == 0)
            {
                return 0;
            }

            Resources.Stream.Position = propertyAddress;
            var propertyHeader = Resources.Stream.ReadByte();
            var propertyLength = (byte)(((propertyHeader & 0b11100000) >> 5) + 1);

            return (ushort)(propertyLength + 1);

        }

        public ushort put_prop(ushort obj, ushort property, ushort value, CallState state)
        {
            byte propertyLength;
            Resources.Objects[obj].GoToObjectPropertyValue(Resources.Stream, property, true, out propertyLength);

            if (propertyLength == 1)
            {
                // write only LSB
                Resources.Stream.WriteByte((byte)(value & 0xff));
            }
            else
            {
                // write ushort. no idea why some props are > 2 bytes because there doesn't seem to be a way to read or write it.
                // perhaps, they contain specialised data that the game itself will read with the load* opcodes
                Resources.Stream.WriteWordBe(value);
            }

            return 0;
        }

        public ushort insert_obj(ushort obj, ushort destination, CallState state)
        {
            // get the object entry
            var entry = Resources.Objects[obj].GetObjectEntry(Resources.Stream);

            // remove the object properly from the parent. this includes removing it out of the sibling list if it had siblings
            if (entry.parent != 0)
            {
                var oldParentEntry = Resources.Objects[entry.parent].GetObjectEntry(Resources.Stream);

                // if the object was the first child of the parent, detach it and point it to the sibling of the object
                // so this means that the sibling of the object now becomes the first child of the parent
                if (oldParentEntry.child == obj)
                {
                    oldParentEntry.child = entry.sibling;
                    Resources.Objects[entry.parent].SetObjectEntry(Resources.Stream, oldParentEntry);
                }
                else
                {
                    // TODO untested
                    throw new Exception("not tested");
                    // if the object was not the first child, it is linked as a sibling, remove it from the sibling chain
                    var siblingObj = oldParentEntry.child;
                    ZObjectEntry siblingEntry = new ZObjectEntry();

                    while (siblingEntry.sibling != obj)
                    {
                        siblingObj = siblingEntry.sibling;

                        siblingEntry = Resources.Objects[siblingObj].GetObjectEntry(Resources.Stream);
                    }

                    // siblingEntry now contains the upstream sibling for the object, link it to the downstream sibling of the object
                    siblingEntry.sibling = entry.sibling;
                    Resources.Objects[siblingObj].SetObjectEntry(Resources.Stream, siblingEntry);
                }
            }

            // read the new parent
            var newParentEntry = Resources.Objects[destination].GetObjectEntry(Resources.Stream);

            var saveSibling = newParentEntry.child;

            // update the parent to have the object as it's first child
            newParentEntry.child = (byte)obj;

            // save the new parent
            Resources.Objects[destination].SetObjectEntry(Resources.Stream, newParentEntry);

            // update the object to have a new parent and a sibling if there was an existing child on the parent
            entry.parent = (byte)destination;
            entry.sibling = saveSibling;

            // save the object
            Resources.Objects[obj].SetObjectEntry(Resources.Stream, entry);

            return 0;
        }

        public ushort get_parent(ushort obj, CallState state)
        {
            var entry = Resources.Objects[obj].GetObjectEntry(Resources.Stream);

            return entry.parent;

        }

        public ushort get_child(ushort obj, CallState state)
        {
            var entry = Resources.Objects[obj].GetObjectEntry(Resources.Stream);

            return entry.child;
        }

        public ushort get_sibling(ushort obj, CallState state)
        {
            var entry = Resources.Objects[obj].GetObjectEntry(Resources.Stream);

            return entry.sibling;
        }

        public ushort get_prop_addr(ushort obj, ushort property, CallState state) {

            byte propertyLength;

            // address will be 0 if property doesn't exist which is exactly what this instruction is supposed to do
            var address = Resources.Objects[obj].GoToObjectPropertyValue(Resources.Stream, property, false, out propertyLength);

            // TODO: don't know whether we should return the offset of the start of the property block or the start of the value of the property (+1 byte after block)
            if (address == 0)
            {
                return 0;
            }
            else
            {
                // TODO: untested
                return (ushort)address;
            }
        }

    }

}
