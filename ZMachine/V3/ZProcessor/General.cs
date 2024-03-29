﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMachine.V3
{
    public partial class ZProcessor : ZBase
    {

        public ushort push(ushort value)
        {
            this.CurrentFrame.Stack.Push(value);

            return 0;
        }

        public ushort pull(ref ushort variable)
        {
            variable = this.CurrentFrame.Stack.Pop();

            return 0;
        }

        public ushort quit()
        {
            this.CurrentFrame = null;
            this.CallStack.Clear();

            return 0;

        }

        public ushort restart()
        {
            throw new NotImplementedException();
        }

        public ushort restore()
        {
            throw new NotImplementedException();
        }

        public ushort save()
        {
            throw new NotImplementedException();
        }

        public ushort verify()
        {
            throw new NotImplementedException();
        }
    }
}
