using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Simulate.Interfaces
{
    public interface IRAM
    {
        VirtualMachine machine
        {
            get;
            set;
        }
        byte GetByte(MemoryAddress address);
        ushort GetWord(MemoryAddress address);
        void SetByte(MemoryAddress address, byte x);
        void SetWord(MemoryAddress address, ushort x);



    }
}
