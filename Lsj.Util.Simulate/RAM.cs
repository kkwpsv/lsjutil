using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.Simulate.Interfaces;

namespace Lsj.Util.Simulate
{
    public class RAM : IRAM
    {
        private byte[] ram;

        public RAM(int size)
        {
            this.ram = new byte[size];
        }

        public VirtualMachine machine
        {
            get;
            set;
        }
    }
}
