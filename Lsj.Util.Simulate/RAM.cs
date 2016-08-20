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
        public byte GetByte(MemoryAddress address)
        {
            if (address.Value <= ram.Length)
            {
                return ram[address.Value];
            }
            throw new IndexOutOfRangeException();
        }

        public ushort GetWord(MemoryAddress address)
        {
            if (address.Value + 1 <= ram.Length)
            {
                return (ushort)(ram[address.Value] << 8 + ram[address.Value + 1]);
            }
            throw new IndexOutOfRangeException();
        }

        public void SetByte(MemoryAddress address, byte x)
        {
            if (address.Value <= ram.Length)
            {
                ram[address.Value] = x;
            }
            throw new IndexOutOfRangeException();
        }

        public void SetWord(MemoryAddress address, ushort x)
        {
            if (address.Value + 1 <= ram.Length)
            {
                ram[address.Value] = (byte)(x >> 8);
                ram[address.Value + 1] = (byte)(x);
            }
            throw new IndexOutOfRangeException();
        }
    }
}
