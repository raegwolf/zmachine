using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            if (obj == 0)
            {
                Debugger.Break(); // possible unsafe attempt to access object 0
                return 0;
            }

            if (attributeNumber > 31)
            {
                throw new Exception("Invalid attribute number.");
            }

            var objectEntry = Resources.Objects[obj].GetObjectEntry(Resources.Stream);

            var attributes = (objectEntry.attributes1 << 24) + (objectEntry.attributes2 << 16) + (objectEntry.attributes3 << 8) + objectEntry.attributes4;

            var mask = (1 << (31 - attributeNumber));

            var isSet = ((attributes & mask) == mask);

            return isSet ? (ushort)1 : (ushort)0;
        }

        public ushort set_attr(ushort obj, ushort attributeNumber, CallState state)
        {
            if (obj == 0)
            {
                throw new Exception("Object 0 is invalid.");
            }

            if (attributeNumber > 31)
            {
                throw new Exception("Invalid attribute number.");
            }

            var objectEntry = Resources.Objects[obj].GetObjectEntry(Resources.Stream);

            var attributes = ((objectEntry.attributes1 << 24) + (objectEntry.attributes2 << 16) + (objectEntry.attributes3 << 8) + objectEntry.attributes4);

            var mask = (1 << (31 - attributeNumber));

            var newAttributes = (attributes | mask);

            Resources.Objects[obj].GoToObjectEntry(Resources.Stream);
            Resources.Stream.WriteInt((uint)newAttributes);

            return 0;
        }

        public ushort clear_attr(ushort obj, ushort attributeNumber, CallState state)
        {
            if (obj == 0)
            {
                throw new Exception("Object 0 is invalid.");
            }

            if (attributeNumber > 31)
            {
                throw new Exception("Invalid attribute number.");
            }

            var objectEntry = Resources.Objects[obj].GetObjectEntry(Resources.Stream);

            var attributes = ((objectEntry.attributes1 << 24) + (objectEntry.attributes2 << 16) + (objectEntry.attributes3 << 8) + objectEntry.attributes4);

            var mask = (int)(0xffffffff - (1 << (31 - attributeNumber)));

            var newAttributes = (attributes & mask);

            Resources.Objects[obj].GoToObjectEntry(Resources.Stream);
            Resources.Stream.WriteInt((uint)newAttributes);

            return 0;
        }


        public ushort get_prop_addr(ushort obj, ushort property, CallState state)
        {
            if (obj == 0)
            {
                // returning 0 for property 0 complies with standard
                return 0;
            }

            byte propertyLength;

            // address will be 0 if property doesn't exist which is exactly what this instruction is supposed to do
            var address = Resources.Objects[obj].GoToObjectPropertyValue(Resources.Stream, property, false, out propertyLength);

            if (address == 0)
            {
                return 0;
            }
            else
            {
                // return the address of the data for the property NOT the address of the header for the property
                return (ushort)(address);
            }
        }


        public ushort get_prop_len(ushort propertyAddress, CallState state)
        {
            if (propertyAddress == 0)
            {
                return 0;
            }

            // this opcode is usually called after get_prop_addr which should return the position of the data of the property.
            // therefore, we move back 1 byte to access the property header
            Resources.Stream.Position = propertyAddress - 1;
            var propertyHeader = Resources.Stream.ReadByte();
            var propertyLength = (ushort)(((propertyHeader & 0b11100000) >> 5) + 1);

            return (ushort)(propertyLength);
        }


        public ushort get_prop(ushort obj, ushort property, CallState state)
        {
            if (obj == 0)
            {
                throw new Exception("Object 0 is invalid.");
            }

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
            else if (propertyLength == 2)
            {
                return (ushort)Resources.Stream.ReadWord();
            }
            else
            {
                throw new NotSupportedException("Property value for properties longer than 2 bytes can't be read with this opcode.");
            }

        }

        public ushort get_next_prop(ushort obj, ushort property, CallState state)
        {
            Debugger.Break();// not tested

            return Resources.Objects[obj].GetNextProperty(Resources.Stream, property);
        }

        public ushort put_prop(ushort obj, ushort property, ushort value, CallState state)
        {
            if (obj == 0)
            {
                throw new Exception("Object 0 is invalid.");
            }

            byte propertyLength;
            Resources.Objects[obj].GoToObjectPropertyValue(Resources.Stream, property, true, out propertyLength);

            if (propertyLength == 1)
            {
                // write only LSB
                Resources.Stream.WriteByte((byte)(value & 0xff));
            }
            else if (propertyLength == 2)
            {
                // write ushort. no idea why some props are > 2 bytes because there doesn't seem to be a way to read or write it.
                // perhaps, they contain specialised data that the game itself will read with the load* opcodes
                Resources.Stream.WriteWord(value);
            }
            else
            {
                throw new NotSupportedException("Property value for properties longer than 2 bytes can't be written with this opcode.");
            }

            return 0;
        }

        public ushort insert_obj(ushort obj, ushort destination, CallState state)
        {
            if (obj == 0)
            {
                throw new Exception("Object 0 is invalid.");
            }

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
                    // if the object was not the first child, it is linked as a sibling, remove it from the sibling chain
                    ZObjectEntry siblingEntry = new ZObjectEntry()
                    {
                        sibling = oldParentEntry.child
                    };
                    var siblingObj = 0;

                    while (siblingEntry.sibling != obj)
                    {
                        siblingObj = siblingEntry.sibling;
                        siblingEntry = Resources.Objects[siblingEntry.sibling].GetObjectEntry(Resources.Stream);

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

        public ushort remove_obj(ushort obj, CallState state)
        {
            var entry = Resources.Objects[obj].GetObjectEntry(Resources.Stream);

            // detach from parent
            var parentEntry = Resources.Objects[entry.parent].GetObjectEntry(Resources.Stream);
            parentEntry.child = entry.sibling; // if the item being removed had a sibling, attach that to the parent directly
            Resources.Objects[entry.parent].SetObjectEntry(Resources.Stream, parentEntry);

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


    }

}
