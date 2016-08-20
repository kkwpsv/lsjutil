using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.Simulate.Interfaces;

namespace Lsj.Util.Simulate
{
    public class VirtualMachine
    {
        private ICPU cpu;
        private IRAM ram;

        public VirtualMachine(ICPU cpu,IRAM ram)
        {
            this.cpu = cpu;
            this.ram = ram;
            cpu.machine = this;
            ram.machine = this;
        }
        public ICPU CPU=>cpu;
        public IRAM RAM => ram;


    }
}
