using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMachine.V3
{
    public abstract class ZBase
    {
        public ZResources Resources { get; set; }


        public ZBase()
        {
            this.Resources = new ZResources();
        } 

        public ZBase(ZResources resources)
        {
            this.Resources = resources;
        }
    }
}
