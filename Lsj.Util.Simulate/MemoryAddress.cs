using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Simulate
{
    public struct MemoryAddress
    {
        public MemoryAddress(int value)
        {
            this.value = value;
        }
        int value;

        public int Value => value;
    }
}
