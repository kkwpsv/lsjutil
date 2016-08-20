using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.Simulate.Interfaces;

namespace Lsj.Util.Simulate.CPUs
{
    public class Intel8086 : ICPU
    {

        public enum eRegister16 : byte
        {
            AX, BX, CX, DX, SI, DI, BP, SP, CS, DS, ES, SS, IP, FLAG
        }
        public enum eRegister8 : byte
        {
            AH, AL, BH, BL, CH, CL, DH, DL
        }



        public VirtualMachine machine
        {
            get;
            set;
        }



        ushort ax;
        ushort bx;
        ushort cx;
        ushort dx;

        ushort si;
        ushort di;
        ushort bp;
        ushort sp;

        ushort cs;
        ushort ds;
        ushort es;
        ushort ss;

        ushort ip;
        ushort flag;



        public ushort AX
        {
            get
            {
                return ax;
            }
            set
            {
                ax = value;
            }
        }
        public ushort BX
        {
            get
            {
                return bx;
            }
            set
            {
                bx = value;
            }
        }
        public ushort CX
        {
            get
            {
                return cx;
            }
            set
            {
                cx = value;
            }
        }
        public ushort DX
        {
            get
            {
                return dx;
            }
            set
            {
                dx = value;
            }
        }
        public byte AH
        {
            get
            {
                return (byte)(AX >> 8);
            }
            set
            {
                AX = (ushort)((ushort)(value << 8) + AL);
            }
        }
        public byte AL
        {
            get
            {
                return (byte)AX;
            }
            set
            {
                AX = (ushort)((ushort)AH << 8 + value);
            }
        }
        public byte BH
        {
            get
            {
                return (byte)(BX >> 8);
            }
            set
            {
                BX = (ushort)((ushort)(value << 8) + BL);
            }
        }
        public byte BL
        {
            get
            {
                return (byte)BX;
            }
            set
            {
                BX = (ushort)((ushort)BH << 8 + value);
            }
        }
        public byte CH
        {
            get
            {
                return (byte)(CX >> 8);
            }
            set
            {
                CX = (ushort)((ushort)(value << 8) + CL);
            }
        }
        public byte CL
        {
            get
            {
                return (byte)CX;
            }
            set
            {
                CX = (ushort)((ushort)CH << 8 + value);
            }
        }
        public byte DH
        {
            get
            {
                return (byte)(DX >> 8);
            }
            set
            {
                DX = (ushort)((ushort)(value << 8) + DL);
            }
        }
        public byte DL
        {
            get
            {
                return (byte)DX;
            }
            set
            {
                DX = (ushort)((ushort)DH << 8 + value);
            }
        }
        public ushort SI
        {
            get
            {
                return si;
            }
            set
            {
                si = value;
            }
        }
        public ushort DI
        {
            get
            {
                return di;
            }
            set
            {
                di = value;
            }
        }
        public ushort BP
        {
            get
            {
                return bp;
            }
            set
            {
                bp = value;
            }
        }
        public ushort SP
        {
            get
            {
                return sp;
            }
            set
            {
                sp = value;
            }
        }
        public ushort CS
        {
            get
            {
                return cs;
            }
            set
            {
                cs = value;
            }
        }
        public ushort DS
        {
            get
            {
                return ds;
            }
            set
            {
                ds = value;
            }
        }
        public ushort ES
        {
            get
            {
                return es;
            }
            set
            {
                es = value;
            }
        }
        public ushort SS
        {
            get
            {
                return ss;
            }
            set
            {
                ss = value;
            }
        }
        public ushort IP
        {
            get
            {
                return ip;
            }
            set
            {
                ip = value;
            }
        }
        public ushort FLAG
        {
            get
            {
                return flag;
            }
            set
            {
                flag = value;
            }
        }






        MemoryAddress GetRamAddress(eRegister16 a, eRegister16 b) => GetRamAddress(a, b, 0);
        MemoryAddress GetRamAddress(eRegister16 a, eRegister16 b, byte c) => GetRamAddress(a, b, c);
        MemoryAddress GetRamAddress(eRegister16 a, eRegister16 b, ushort c)
        {
            switch (a)
            {
                case eRegister16.BX:
                    switch (b)
                    {
                        case eRegister16.SI:
                            return GetRamAddress(BX + SI + c);
                        case eRegister16.DI:
                            return GetRamAddress(BX + DI + c);
                        default:
                            throw new InvalidOperationException();
                    }
                case eRegister16.BP:
                    switch (b)
                    {
                        case eRegister16.SI:
                            return GetRamAddress(BP + SI + c);
                        case eRegister16.DI:
                            return GetRamAddress(BP + DI + c);
                        default:
                            throw new InvalidOperationException();
                    }
                default:
                    throw new InvalidOperationException();
            }
        }
        MemoryAddress GetRamAddress(eRegister16 a) => GetRamAddress(a, 0);
        MemoryAddress GetRamAddress(eRegister16 a, int b)
        {
            switch (a)
            {
                case eRegister16.SI:
                    return GetRamAddress(SI + b);
                case eRegister16.DI:
                    return GetRamAddress(DI + b);
                case eRegister16.BP:
                    return GetRamAddress(BP + b);
                case eRegister16.BX:
                    return GetRamAddress(SI + b);
                default:
                    throw new InvalidOperationException();
            }
        }
        MemoryAddress GetRamAddress(int x)=> new MemoryAddress(BX << 4 + x);







        void MOV(eRegister16 a, ushort b)
        {
            switch (a)
            {
                case eRegister16.AX:
                    AX = b;
                    break;
                case eRegister16.BX:
                    BX = b;
                    break;
                case eRegister16.CX:
                    CX = b;
                    break;
                case eRegister16.DX:
                    DX = b;
                    break;
                case eRegister16.DI:
                    DI = b;
                    break;
                case eRegister16.SI:
                    SI = b;
                    break;
                case eRegister16.BP:
                    BP = b;
                    break;
                case eRegister16.SP:
                    SP = b;
                    break;
                case eRegister16.DS:
                    DS = b;
                    break;
                case eRegister16.ES:
                    ES = b;
                    break;
                case eRegister16.SS:
                    SS = b;
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }
        void MOV(eRegister8 a, byte b)
        {
            switch (a)
            {
                case eRegister8.AH:
                    AH = b;
                    break;
                case eRegister8.AL:
                    AL = b;
                    break;
                case eRegister8.BH:
                    BH = b;
                    break;
                case eRegister8.BL:
                    BL = b;
                    break;
                case eRegister8.CH:
                    CH = b;
                    break;
                case eRegister8.CL:
                    CL = b;
                    break;
                case eRegister8.DH:
                    DH = b;
                    break;
                case eRegister8.DL:
                    DL = b;
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }
        void MOV(eRegister16 x, eRegister16 y)
        {
            switch (y)
            {
                case eRegister16.AX:
                    MOV(x, AX);
                    break;
                case eRegister16.BX:
                    MOV(x, BX);
                    break;
                case eRegister16.CX:
                    MOV(x, CX);
                    break;
                case eRegister16.DX:
                    MOV(x, DX);
                    break;
                case eRegister16.DI:
                    MOV(x, DI);
                    break;
                case eRegister16.SI:
                    MOV(x, SI);
                    break;
                case eRegister16.BP:
                    MOV(x, BP);
                    break;
                case eRegister16.SP:
                    MOV(x, SP);
                    break;
                case eRegister16.DS:
                    MOV(x, DS);
                    break;
                case eRegister16.SS:
                    MOV(x, SS);
                    break;
                case eRegister16.ES:
                    MOV(x, ES);
                    break;
                case eRegister16.CS:
                    MOV(x, CS);
                    break;

                default:
                    throw new InvalidOperationException();
            }
        }
        void MOV(eRegister8 x, eRegister8 y)
        {
            switch (y)
            {
                case eRegister8.AH:
                    MOV(x, AH);
                    break;
                case eRegister8.AL:
                    MOV(x, AL);
                    break;
                case eRegister8.BH:
                    MOV(x, BH);
                    break;
                case eRegister8.BL:
                    MOV(x, BL);
                    break;
                case eRegister8.CH:
                    MOV(x, CH);
                    break;
                case eRegister8.CL:
                    MOV(x, CL);
                    break;
                case eRegister8.DH:
                    MOV(x, DH);
                    break;
                case eRegister8.DL:
                    MOV(x, DL);
                    break;

                default:
                    throw new InvalidOperationException();
            }
        }
        void MOV(MemoryAddress address, eRegister16 x)
        {
            switch (x)
            {
                case eRegister16.AX:
                    MOV(address, AX);
                    break;
                case eRegister16.BX:
                    MOV(address, BX);
                    break;
                case eRegister16.CX:
                    MOV(address, CX);
                    break;
                case eRegister16.DX:
                    MOV(address, DX);
                    break;
                case eRegister16.DI:
                    MOV(address, DI);
                    break;
                case eRegister16.SI:
                    MOV(address, SI);
                    break;
                case eRegister16.BP:
                    MOV(address, BP);
                    break;
                case eRegister16.SP:
                    MOV(address, SP);
                    break;
                case eRegister16.DS:
                    MOV(address, DS);
                    break;
                case eRegister16.SS:
                    MOV(address, SS);
                    break;
                case eRegister16.ES:
                    MOV(address, ES);
                    break;
                case eRegister16.CS:
                    MOV(address, CS);
                    break;

                default:
                    throw new InvalidOperationException();
            }
        }
        void MOV(MemoryAddress address, ushort x)
        {
            this.machine.RAM.SetWord(address,x);
        }
        void MOV(MemoryAddress address, byte x)
        {
            this.machine.RAM.SetByte(address, x);
        }
        void MOV(eRegister16 a ,MemoryAddress address)
        {
            MOV(a, this.machine.RAM.GetWord(address));
        }
        void MOV(eRegister8 a, MemoryAddress address)
        {
            MOV(a, this.machine.RAM.GetByte(address));
        }


    }
}
