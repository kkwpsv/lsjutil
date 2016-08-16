using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.Simulate.Interfaces;

namespace Lsj.Util.Simulate.CPUs
{
    public class Intel8086 : ICPU
    {

        public enum eRegister16
        {
            AX, BX, CX, DX, SI, DI, BP, SP, CS, DS, ES, SS, IP, FLAG
        }
        public enum eRegister8
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






        int GetRamOffset(eRegister16 a, eRegister16 b) => GetRamOffset(a, b, 0);
        int GetRamOffset(eRegister16 a, eRegister16 b, byte c) => GetRamOffset(a, b, c);
        int GetRamOffset(eRegister16 a, eRegister16 b, ushort c)
        {
            switch (a)
            {
                case eRegister16.BX:
                    switch (b)
                    {
                        case eRegister16.SI:
                            return BX + SI + c;
                        case eRegister16.DI:
                            return BX << 4 + DI + c;
                        default:
                            throw new InvalidOperationException();
                    }
                case eRegister16.BP:
                    switch (b)
                    {
                        case eRegister16.SI:
                            return BP << 4 + SI + c;
                        case eRegister16.DI:
                            return BP << 4 + DI + c;
                        default:
                            throw new InvalidOperationException();
                    }
                default:
                    throw new InvalidOperationException();
            }
        }






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
        void MOV()
        {
        }

    }
}
