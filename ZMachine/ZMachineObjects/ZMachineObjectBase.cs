using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMachine.ZMachineObjects
{
    class ZMachineObjectBase
    {
        protected MemoryStream Stream { get;  set; }

        public ZMachineObjectBase(MemoryStream stream)
        {
            this.Stream = stream;
        }
    }
}
