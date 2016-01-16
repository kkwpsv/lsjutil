using Lsj.Util.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lsj.Util.Net.Async
{
    public class PacketIn
    {
        private Log log;
        public static readonly ushort HDR_SIZE = 20;
        public static readonly short HEADER = 29099;
        
        protected int m_parameter1;
        protected int m_parameter2;

        public short CheckSum
        {
            get;
            private  set;
        }
        public short Code
        {
            get;
            private set;
        }
        protected int m_cliendId;
        public int ClientID
        {
            get
            {
                return this.m_cliendId;
            }
            set
            {
                if (value != this.m_cliendId)
                {
                    this.m_cliendId = value;
                    this.ClearChecksum();
                }
            }
        }
        public int Parameter1
        {
            get
            {
                return this.m_parameter1;
            }
            set
            {
                if (value != this.m_parameter1)
                {
                    this.m_parameter1 = value;
                    this.ClearChecksum();
                }
            }
        }
        public int Parameter2
        {
            get
            {
                return this.m_parameter2;
            }
            set
            {
                if (value != this.m_parameter2)
                {
                    this.m_parameter2 = value;
                    this.ClearChecksum();
                }
            }
        }
        public PacketIn(short code) : this(code, 0, 2048)
        {
        }
        public PacketIn(short code, int clientId) : this(code, clientId, 2048)
        {
        }
        public PacketIn(byte[] buf, int len):(0,0,buf,len)
        {

        }
        public PacketIn(short code, int clientId, int size) : this(code, clientId, new byte[size], (int)HDR_SIZE)
        {
        }
        public PacketIn(short code, int clientId, byte[] buf, int len)
        {
            this.m_buffer = buf;
            this.m_length = ((len > this.m_buffer.Length) ? this.m_buffer.Length : len);
            this.m_offset = 0;
            this.Code = code;
            this.m_cliendId = clientId;
            this.m_offset = (int)HDR_SIZE;
        }





        public void ReadHeader()
        {
            Monitor.Enter(this);
            try
            {
                this.m_offset = 0;
                this.ReadShort();
                this.m_length = (int)this.ReadShort();
                this.CheckSum = this.ReadShort();
                this.Code = this.ReadShort();
                this.m_cliendId = this.ReadInt();
                this.m_parameter1 = this.ReadInt();
                this.m_parameter2 = this.ReadInt();
            }
            finally
            {
                Monitor.Exit(this);
            }
        }
        public void WriteHeader()
        {
            Monitor.Enter(this);
            try
            {
                int old = this.m_offset;
                this.m_offset = 0;
                base.WriteShort(GSPacketIn.HEADER);
                base.WriteShort((short)this.m_length);
                this.m_offset = 6;
                base.WriteShort(this.Code);
                base.WriteInt(this.m_cliendId);
                base.WriteInt(this.m_parameter1);
                base.WriteInt(this.m_parameter2);
                if (this.CheckSum == 0)
                {
                    this.CheckSum = this.CalculateChecksum();
                }
                this.m_offset = 4;
                base.WriteShort(this.CheckSum);
                this.m_offset = old;
            }
            finally
            {
                Monitor.Exit(this);
            }
        }
        public void ClearChecksum()
        {
            this.CheckSum = 0;
        }
        public short CalculateChecksum()
        {
            byte[] pak = this.m_buffer;
            int val = 119;
            int i = 6;
            int len = this.m_length;
            while (i < len)
            {
                val += (int)pak[i++];
            }
            return (short)(val & 32639);
        }
        public void WritePacket(GSPacketIn content)
        {
            content.WriteHeader();
            this.WriteShort((short)content.Length);
            this.WriteShort(0);
            this.Write(content.Buffer, 2, content.Length - 2);
        }
        public GSPacketIn ReadPacket()
        {
            int length = (int)this.ReadShort();
            byte[] data = this.ReadBytes(length);
            data[0] = 113;
            data[1] = 171;
            GSPacketIn content = new GSPacketIn(data, length);
            content.ReadHeader();
            if (content.Length != length)
            {
                throw new Exception(string.Format("Error packet in ReadPacket,data length didn't equal packet length, data:{0}, packet:{1}", length, content.Length));
            }
            return content;
        }
        public void Compress()
        {
            byte[] temp = Marshal.Compress(this.m_buffer, (int)GSPacketIn.HDR_SIZE, base.Length - (int)GSPacketIn.HDR_SIZE);
            this.m_offset = (int)GSPacketIn.HDR_SIZE;
            this.Write(temp);
            this.m_length = temp.Length + (int)GSPacketIn.HDR_SIZE;
        }
        public void UnCompress()
        {
        }
        public void ClearContext()
        {
            this.m_offset = (int)GSPacketIn.HDR_SIZE;
            this.m_length = (int)GSPacketIn.HDR_SIZE;
            this.CheckSum = 0;
        }
        public GSPacketIn Clone()
        {
            GSPacketIn pkg = new GSPacketIn(this.m_buffer, this.m_length);
            pkg.ReadHeader();
            pkg.Offset = this.m_length;
            pkg.ClearChecksum();
            return pkg;
        }

            protected byte[] m_buffer;
            protected int m_length;
            protected int m_offset;
            public byte[] Buffer
            {
                get
                {
                    return this.m_buffer;
                }
            }
            public int Length
            {
                get
                {
                    return this.m_length;
                }
            }
            public int Offset
            {
                get
                {
                    return this.m_offset;
                }
                set
                {
                    this.m_offset = value;
                }
            }
            public int DataLeft
            {
                get
                {
                    return this.m_length - this.m_offset;
                }
            }
            
            public void Skip(int num)
            {
                this.m_offset += num;
            }
            public virtual bool ReadBoolean()
            {
                return this.m_buffer[this.m_offset++] != 0;
            }
            public virtual byte ReadByte()
            {
                return this.m_buffer[this.m_offset++];
            }
            public virtual short ReadShort()
            {
                byte v = this.ReadByte();
                byte v2 = this.ReadByte();
                return Marshal.ConvertToInt16(v, v2);
            }
            public virtual short ReadShortLowEndian()
            {
                byte v = this.ReadByte();
                byte v2 = this.ReadByte();
                return Marshal.ConvertToInt16(v2, v);
            }
            public virtual int ReadInt()
            {
                byte v = this.ReadByte();
                byte v2 = this.ReadByte();
                byte v3 = this.ReadByte();
                byte v4 = this.ReadByte();
                return Marshal.ConvertToInt32(v, v2, v3, v4);
            }

            public virtual uint ReadUInt()
            {
                byte v = this.ReadByte();
                byte v2 = this.ReadByte();
                byte v3 = this.ReadByte();
                byte v4 = this.ReadByte();
                return Marshal.ConvertToUInt32(v, v2, v3, v4);
            }

            public virtual long ReadLong()
            {
                int v = this.ReadInt();
                uint v2 = this.ReadUInt();
                return Marshal.ConvertToInt64(v, v2);
            }

            public virtual float ReadFloat()
            {
                byte[] v = new byte[4];
                for (int i = 0; i < v.Length; i++)
                {
                    v[i] = this.ReadByte();
                }
                return BitConverter.ToSingle(v, 0);
            }
            public virtual double ReadDouble()
            {
                byte[] v = new byte[8];
                for (int i = 0; i < v.Length; i++)
                {
                    v[i] = this.ReadByte();
                }
                return BitConverter.ToDouble(v, 0);
            }
            public virtual string ReadString()
            {
                short len = this.ReadShort();
                string temp = Encoding.UTF8.GetString(this.m_buffer, this.m_offset, (int)len);
                this.m_offset += (int)len;
                return temp.Replace("\0", "");
            }
            public virtual byte[] ReadBytes(int maxLen)
            {
                byte[] data = new byte[maxLen];
                Array.Copy(this.m_buffer, this.m_offset, data, 0, maxLen);
                this.m_offset += maxLen;
                return data;
            }
            public virtual byte[] ReadBytes()
            {
                return this.ReadBytes(this.m_length - this.m_offset);
            }

            public DateTime ReadDateTime()
            {
                return new DateTime((int)this.ReadShort(), (int)this.ReadByte(), (int)this.ReadByte(), (int)this.ReadByte(), (int)this.ReadByte(), (int)this.ReadByte());
            }
            public virtual int CopyTo(byte[] dst, int dstOffset, int offset)
            {
                int len = (this.m_length - offset < dst.Length - dstOffset) ? (this.m_length - offset) : (dst.Length - dstOffset);
                if (len > 0)
                {
                    System.Buffer.BlockCopy(this.m_buffer, offset, dst, dstOffset, len);
                }
                return len;
            }
            public virtual int CopyTo(byte[] dst, int dstOffset, int offset, int key)
            {
                int len = (this.m_length - offset < dst.Length - dstOffset) ? (this.m_length - offset) : (dst.Length - dstOffset);
                if (len > 0)
                {
                    for (int i = 0; i < len; i++)
                    {
                        dst[dstOffset + i] = (byte)((int)this.m_buffer[offset + i] ^ (key++ & 16711680) >> 16);
                    }
                }
                return len;
            }
            public virtual int CopyFrom(byte[] src, int srcOffset, int offset, int count)
            {
                int result;
                if (count <= this.m_buffer.Length && count - srcOffset <= src.Length)
                {
                    System.Buffer.BlockCopy(src, srcOffset, this.m_buffer, offset, count);
                    result = count;
                }
                else
                {
                    result = -1;
                }
                return result;
            }
            public virtual int CopyFrom(byte[] src, int srcOffset, int offset, int count, int key)
            {
                int result;
                if (count < this.m_buffer.Length && count - srcOffset < src.Length)
                {
                    for (int i = 0; i < count; i++)
                    {
                        this.m_buffer[offset + i] = (byte)((int)src[srcOffset + i] ^ (key++ & 16711680) >> 16);
                    }
                    result = count;
                }
                else
                {
                    result = -1;
                }
                return result;
            }
            public virtual void WriteBoolean(bool val)
            {
                if (this.m_offset == this.m_buffer.Length)
                {
                    byte[] temp = this.m_buffer;
                    this.m_buffer = new byte[this.m_buffer.Length * 2];
                    Array.Copy(temp, this.m_buffer, temp.Length);
                }
                this.m_buffer[this.m_offset++] = (val ? (byte)1 : (byte)0);
                this.m_length = ((this.m_offset > this.m_length) ? this.m_offset : this.m_length);
            }
            public virtual void WriteByte(byte val)
            {
                if (this.m_offset == this.m_buffer.Length)
                {
                    byte[] temp = this.m_buffer;
                    this.m_buffer = new byte[this.m_buffer.Length * 2];
                    Array.Copy(temp, this.m_buffer, temp.Length);
                }
                this.m_buffer[this.m_offset++] = val;
                this.m_length = ((this.m_offset > this.m_length) ? this.m_offset : this.m_length);
            }
            public virtual void Write(byte[] src)
            {
                this.Write(src, 0, src.Length);
            }
            public virtual void Write(byte[] src, int offset, int len)
            {
                if (this.m_offset + len >= this.m_buffer.Length)
                {
                    byte[] temp = this.m_buffer;
                    this.m_buffer = new byte[this.m_buffer.Length * 2];
                    Array.Copy(temp, this.m_buffer, temp.Length);
                    this.Write(src, offset, len);
                }
                else
                {
                    Array.Copy(src, offset, this.m_buffer, this.m_offset, len);
                    this.m_offset += len;
                    this.m_length = ((this.m_offset > this.m_length) ? this.m_offset : this.m_length);
                }
            }
            public virtual void WriteShort(short val)
            {
                this.WriteByte((byte)(val >> 8));
                this.WriteByte((byte)(val & 255));
            }
            public virtual void WriteShortLowEndian(short val)
            {
                this.WriteByte((byte)(val & 255));
                this.WriteByte((byte)(val >> 8));
            }
            public virtual void WriteInt(int val)
            {
                this.WriteByte((byte)(val >> 24));
                this.WriteByte((byte)(val >> 16 & 255));
                this.WriteByte((byte)((val & 65535) >> 8));
                this.WriteByte((byte)(val & 65535 & 255));
            }

            public virtual void WriteUInt(uint val)
            {
                this.WriteByte((byte)(val >> 24));
                this.WriteByte((byte)(val >> 16 & 255u));
                this.WriteByte((byte)((val & 65535u) >> 8));
                this.WriteByte((byte)(val & 65535u & 255u));
            }

            public virtual void WriteLong(long val)
            {
                this.WriteInt((int)(((ulong)(val >> 0x20)) & 0xffffffffL));
                this.WriteUInt((uint)(((ulong)val) & 0xffffffffL));
            }


            public virtual void WriteFloat(float val)
            {
                byte[] src = BitConverter.GetBytes(val);
                this.Write(src);
            }
            public virtual void WriteDouble(double val)
            {
                byte[] src = BitConverter.GetBytes(val);
                this.Write(src);
            }
            public virtual void Fill(byte val, int num)
            {
                for (int i = 0; i < num; i++)
                {
                    this.WriteByte(val);
                }
            }
            public virtual void WriteString(string str)
            {
                if (!string.IsNullOrEmpty(str))
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(str);
                    this.WriteShort((short)(bytes.Length + 1));
                    this.Write(bytes, 0, bytes.Length);
                    this.WriteByte(0);
                }
                else
                {
                    this.WriteShort(1);
                    this.WriteByte(0);
                }
            }
            public virtual void WriteString(string str, int maxlen)
            {
                byte[] bytes = Encoding.UTF8.GetBytes(str);
                int len = (bytes.Length < maxlen) ? bytes.Length : maxlen;
                this.WriteShort((short)len);
                this.Write(bytes, 0, len);
            }
            public void WriteDateTime(DateTime date)
            {
                this.WriteShort((short)date.Year);
                this.WriteByte((byte)date.Month);
                this.WriteByte((byte)date.Day);
                this.WriteByte((byte)date.Hour);
                this.WriteByte((byte)date.Minute);
                this.WriteByte((byte)date.Second);
            }
        }
    }
}
