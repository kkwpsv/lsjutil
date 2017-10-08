using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Lsj.Util.Reflection;

namespace Lsj.Util.Protobuf
{
    /// <summary>
    /// Message
    /// </summary>
    public abstract class Message
    {
        int offset = 0;
        byte[] buffer;
        MemoryStream stream;
        /// <summary>
        /// Read
        /// </summary>
        /// <param name="data"></param>
        public void Read(byte[] data) => Read(data, 0, data.Length);
        /// <summary>
        /// Read
        /// </summary>
        /// <param name="data"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        public void Read(byte[] data, int offset, int length)
        {
            this.buffer = new byte[length];
            UnsafeHelper.Copy(data, offset, buffer, 0, length);
            var fields = this.GetType().GetProperties().Where(x => x.GetAttribute<FieldAttribute>() != null).ToDictionary(x => x.GetAttribute<FieldAttribute>().FieldNumber, x => x);
            var flags = new List<int>();
            while (this.offset < this.buffer.Length)
            {
                var x = (int)this.ReadUInt32();
                var fieldnumber = x >> 3;
                var type = (FieldType)(x & 0x07);
                if (fields.ContainsKey(fieldnumber))
                {
                    var field = fields[fieldnumber];
                    var attribute = field.GetAttribute<FieldAttribute>();
                    if (attribute.FieldType != type)
                    {
                        throw new InvalidCastException($"Bad data : {field.Name} wire_type not match");
                    }
                    if (flags.Contains(fieldnumber))
                    {
                        throw new InvalidCastException($"Bad data : {field.Name} cannot be set twice.");
                    }
                    field.SetValue(this, GetData(type, field.PropertyType), null);

                }
            }
        }
        private object GetData(FieldType Type, Type FieldType)
        {
            if (Type == Protobuf.FieldType.Varint)
            {
                var setmethod = this.GetVarintSetMethodByType(FieldType);
                return setmethod();
            }
            else if (Type == Protobuf.FieldType.LengthDelimited)
            {
                if (FieldType == typeof(string))
                {
                    return this.ReadString();
                }
                else if (FieldType == typeof(byte[]))
                {
                    return this.ReadByteArray();
                }
                else if (typeof(Message).IsAssignableFrom(FieldType))
                {
                    return this.ReadMessage(FieldType);
                }
                else if (FieldType.IsArray)
                {
                    return this.ReadPackedRepeated(FieldType.GetElementType());
                }
            }
            else if (Type == Protobuf.FieldType.Bit32)
            {
                if (FieldType == typeof(Single))
                {
                    return this.ReadSingle();
                }
            }
            else if (Type == Protobuf.FieldType.Bit64)
            {
                if (FieldType == typeof(Double))
                {
                    return this.ReadDouble();
                }
            }
            throw new InvalidCastException($"Bad data");
        }
        private delegate object VarintSetMethodDelegate();
        private VarintSetMethodDelegate GetVarintSetMethodByType(Type type)
        {
            if (type == typeof(Boolean))
            {
                return () => (this.ReadBoolean());
            }
            else if (type == typeof(SByte))
            {
                return () => (this.ReadSByte());
            }
            else if (type == typeof(Byte))
            {
                return () => (this.ReadByte());
            }
            else if (type == typeof(Int16))
            {
                return () => (this.ReadInt16());
            }
            else if (type == typeof(UInt16))
            {
                return () => (this.ReadUInt16());
            }
            else if (type == typeof(Int32))
            {
                return () => (this.ReadInt32());
            }
            else if (type == typeof(UInt32))
            {
                return () => (this.ReadUInt32());
            }
            else if (type == typeof(Int64))
            {
                return () => (this.ReadInt64());
            }
            else if (type == typeof(UInt64))
            {
                return () => (this.ReadUInt64());
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        private Boolean ReadBoolean()
        {
            if (offset + 1 <= buffer.Length)
            {
                var x = buffer[offset++];
                return (x & 0x7f) != 0;
            }
            throw new InvalidOperationException("Buffer is too short");
        }
        private SByte ReadSByte()
        {
            SByte result = 0;
            int l = 0;
            int p = 0;
            while (offset < buffer.Length)
            {
                while (l < 8)
                {
                    var x = buffer[offset++];
                    result |= (SByte)((SByte)(x & 0x7f) << p);
                    if (x >> 7 == 1)
                    {
                        p += 7;
                    }
                    else
                    {
                        break;
                    }
                }
                return result;
            }
            throw new InvalidOperationException("Buffer is too short");
        }
        private Byte ReadByte()
        {
            Byte result = 0;
            int l = 0;
            int p = 0;
            while (offset < buffer.Length)
            {
                while (l < 8)
                {
                    var x = buffer[offset++];
                    result |= (Byte)((Byte)(x & 0x7f) << p);
                    if (x >> 7 == 1)
                    {
                        p += 7;
                    }
                    else
                    {
                        break;
                    }
                }
                return result;
            }
            throw new InvalidOperationException("Buffer is too short");
        }
        private Int16 ReadInt16()
        {
            Int16 result = 0;
            int l = 0;
            int p = 0;
            while (offset < buffer.Length)
            {
                while (l < 16)
                {
                    var x = buffer[offset++];
                    result |= (Int16)((Int16)(x & 0x7f) << p);
                    if (x >> 7 == 1)
                    {
                        p += 7;
                    }
                    else
                    {
                        break;
                    }
                }
                return result;
            }
            throw new InvalidOperationException("Buffer is too short");
        }
        private UInt16 ReadUInt16()
        {
            UInt16 result = 0;
            int l = 0;
            int p = 0;
            while (offset < buffer.Length)
            {
                while (l < 16)
                {
                    var x = buffer[offset++];
                    result |= (UInt16)((UInt16)(x & 0x7f) << p);
                    if (x >> 7 == 1)
                    {
                        p += 7;
                    }
                    else
                    {
                        break;
                    }
                }
                return result;
            }
            throw new InvalidOperationException("Buffer is too short");
        }
        private Int32 ReadInt32()
        {
            Int32 result = 0;
            int l = 0;
            int p = 0;
            while (offset < buffer.Length)
            {
                while (l < 32)
                {
                    var x = buffer[offset++];
                    result |= (Int32)((Int32)(x & 0x7f) << p);
                    if (x >> 7 == 1)
                    {
                        p += 7;
                    }
                    else
                    {
                        break;
                    }
                }
                return result;
            }
            throw new InvalidOperationException("Buffer is too short");
        }
        private UInt32 ReadUInt32()
        {
            UInt32 result = 0;
            int l = 0;
            int p = 0;
            while (offset < buffer.Length)
            {
                while (l < 32)
                {
                    var x = buffer[offset++];
                    result |= (UInt32)((UInt32)(x & 0x7f) << p);
                    if (x >> 7 == 1)
                    {
                        p += 7;
                    }
                    else
                    {
                        break;
                    }
                }
                return result;
            }
            throw new InvalidOperationException("Buffer is too short");
        }
        private Int64 ReadInt64()
        {
            Int64 result = 0;
            int l = 0;
            int p = 0;
            while (offset < buffer.Length)
            {
                while (l < 64)
                {
                    var x = buffer[offset++];
                    result |= (Int64)((Int64)(x & 0x7f) << p);
                    if (x >> 7 == 1)
                    {
                        p += 7;
                    }
                    else
                    {
                        break;
                    }
                }
                return result;
            }
            throw new InvalidOperationException("Buffer is too short");
        }
        private UInt64 ReadUInt64()
        {
            UInt64 result = 0;
            int l = 0;
            int p = 0;
            while (offset < buffer.Length)
            {
                while (l < 64)
                {
                    var x = buffer[offset++];
                    result |= (UInt64)((UInt64)(x & 0x7f) << p);
                    if (x >> 7 == 1)
                    {
                        p += 7;
                    }
                    else
                    {
                        break;
                    }
                }
                return result;
            }
            throw new InvalidOperationException("Buffer is too short");
        }
        private String ReadString()
        {
            UInt32 length = this.ReadUInt32();
            if (offset + length <= this.buffer.Length)
            {
                var result = Encoding.UTF8.GetString(buffer, offset, (int)length);
                offset += (int)length;
                return result;
            }
            throw new InvalidOperationException("Buffer is too short");
        }
        private byte[] ReadByteArray()
        {
            UInt32 length = this.ReadUInt32();
            if (offset + length <= this.buffer.Length)
            {
                var result = new byte[length];
                UnsafeHelper.Copy(this.buffer, offset, result, 0, length);
                offset += (int)length;
                return result;
            }
            throw new InvalidOperationException("Buffer is too short");
        }
        private Message ReadMessage(Type x)
        {
            UInt32 length = this.ReadUInt32();
            if (offset + length <= this.buffer.Length)
            {
                var result = x.CreateInstance<Message>();
                var data = new byte[length];
                UnsafeHelper.Copy(this.buffer, offset, data, 0, length);
                result.Read(data);
                offset += (int)length;
                return result;
            }
            throw new InvalidOperationException("Buffer is too short");
        }
        private object ReadPackedRepeated(Type x)
        {
            UInt32 length = this.ReadUInt32();
            var end = offset + length;
            var result = x.CreateListOfType();
            while (offset < end)
            {
                if (typeof(Message).IsAssignableFrom(x))
                {
                    var v = GetData(FieldType.LengthDelimited, x);
                    result.GetType().GetMethod("Add").Invoke(result, new object[] { v });
                }
                else
                {
                    var v = GetData(FieldType.Varint, x);
                    result.GetType().GetMethod("Add").Invoke(result, new object[] { v });
                }
            }
            return result.GetType().GetMethod("ToArray").Invoke(result, null);
            throw new InvalidOperationException("Buffer is too short");
        }
        private Single ReadSingle()
        {
            if (offset + 4 <= buffer.Length)
            {
                var result = BitConverter.ToSingle(this.buffer, offset);
                offset += 4;
                return result;
            }
            throw new InvalidOperationException("Buffer is too short");
        }
        private Double ReadDouble()
        {
            if (offset + 8 <= buffer.Length)
            {
                var result = BitConverter.ToDouble(this.buffer, offset);
                offset += 8;
                return result;
            }
            throw new InvalidOperationException("Buffer is too short");
        }
        /// <summary>
        /// Convert To BinaryArray
        /// </summary>
        /// <returns></returns>
        public byte[] ToArray()
        {
            stream = new MemoryStream();
            var fields = this.GetType().GetProperties().Where(x => x.GetAttribute<FieldAttribute>() != null).ToDictionary(x => x.GetAttribute<FieldAttribute>().FieldNumber, x => x);
            foreach (var field in fields)
            {
                var attribute = field.Value.GetAttribute<FieldAttribute>();
                var type = attribute.FieldType;

                var value = field.Value.GetValue(this, null);
                if (value != null)
                {
                    this.WriteUInt32((uint)((field.Key << 3) | (byte)type));
                    this.WriteData(value, type, field.Value.PropertyType);
                }

            }
            return stream.ReadAll();


        }
        private delegate void VarintWriteMethodDelegate(object data);
        private VarintWriteMethodDelegate GetVarintWriteMethodByType(Type type)
        {
            if (type == typeof(Boolean))
            {
                return (Object o) => { this.WriteBoolean((Boolean)o); };
            }
            else if (type == typeof(SByte))
            {
                return (Object o) => { this.WriteSByte((SByte)o); };
            }
            else if (type == typeof(Byte))
            {
                return (Object o) => { this.WriteByte((Byte)o); };
            }
            else if (type == typeof(Int16))
            {
                return (Object o) => { this.WriteInt16((Int16)o); };
            }
            else if (type == typeof(UInt16))
            {
                return (Object o) => { this.WriteUInt16((UInt16)o); };
            }
            else if (type == typeof(Int32))
            {
                return (Object o) => { this.WriteInt32((Int32)o); };
            }
            else if (type == typeof(UInt32))
            {
                return (Object o) => { this.WriteUInt32((UInt32)o); };
            }
            else if (type == typeof(Int64))
            {
                return (Object o) => { this.WriteInt64((Int64)o); };
            }
            else if (type == typeof(UInt64))
            {
                return (Object o) => { this.WriteUInt64((UInt64)o); };
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        private void WriteData(object data, FieldType Type, Type FieldType)
        {
            if (Type == Protobuf.FieldType.Varint)
            {
                var writemethod = this.GetVarintWriteMethodByType(FieldType);
                writemethod(data);
                return;
            }
            else if (Type == Protobuf.FieldType.LengthDelimited)
            {
                if (FieldType == typeof(string))
                {
                    this.WriteString((String)data);
                    return;
                }
                else if (FieldType == typeof(byte[]))
                {
                    this.WriteByteArray((byte[])data);
                    return;
                }
                else if (typeof(Message).IsAssignableFrom(FieldType))
                {
                    this.WriteMessage((Message)data);
                    return;
                }
                else if (FieldType.IsArray)
                {
                    this.WritePackedRepeated(data, FieldType.GetElementType());
                    return;
                }
            }
            else if (Type == Protobuf.FieldType.Bit32)
            {
                if (FieldType == typeof(Single))
                {
                    this.WriteSingle((Single)data);
                    return;
                }
            }
            else if (Type == Protobuf.FieldType.Bit64)
            {
                if (FieldType == typeof(Double))
                {
                    this.WriteDouble((Double)data);
                    return;
                }
            }
            throw new InvalidCastException($"Bad data");
        }
        private void WriteBoolean(Boolean value)
        {
            if (value)
            {
                stream.WriteByte(1);
            }
            else
            {
                stream.WriteByte(0);
            }
        }
        private void WriteSByte(SByte value)
        {
            if (value == 0)
            {
                stream.WriteByte(0);
                return;
            }
            while (value != 0)
            {
                var cur = (byte)(value & 0x7f);
                value = (SByte)(value >> 7);
                if (value == 0)
                {
                    stream.WriteByte(cur);
                }
                else
                {
                    stream.WriteByte((byte)(cur | 0x80));
                }
            }
        }
        private void WriteByte(Byte value)
        {
            if (value == 0)
            {
                stream.WriteByte(0);
                return;
            }
            while (value != 0)
            {
                var cur = (byte)(value & 0x7f);
                value = (Byte)(value >> 7);
                if (value == 0)
                {
                    stream.WriteByte(cur);
                }
                else
                {
                    stream.WriteByte((byte)(cur | 0x80));
                }
            }
        }
        private void WriteInt16(Int16 value)
        {
            if (value == 0)
            {
                stream.WriteByte(0);
                return;
            }
            while (value != 0)
            {
                var cur = (byte)(value & 0x7f);
                value = (Int16)(value >> 7);
                if (value == 0)
                {
                    stream.WriteByte(cur);
                }
                else
                {
                    stream.WriteByte((byte)(cur | 0x80));
                }
            }
        }
        private void WriteUInt16(UInt16 value)
        {
            if (value == 0)
            {
                stream.WriteByte(0);
                return;
            }
            while (value != 0)
            {
                var cur = (byte)(value & 0x7f);
                value = (UInt16)(value >> 7);
                if (value == 0)
                {
                    stream.WriteByte(cur);
                }
                else
                {
                    stream.WriteByte((byte)(cur | 0x80));
                }
            }
        }
        private void WriteInt32(Int32 value)
        {
            if (value == 0)
            {
                stream.WriteByte(0);
                return;
            }
            while (value != 0)
            {
                var cur = (byte)(value & 0x7f);
                value = (Int32)(value >> 7);
                if (value == 0)
                {
                    stream.WriteByte(cur);
                }
                else
                {
                    stream.WriteByte((byte)(cur | 0x80));
                }
            }
        }
        private void WriteUInt32(UInt32 value)
        {
            if (value == 0)
            {
                stream.WriteByte(0);
                return;
            }
            while (value != 0)
            {
                var cur = (byte)(value & 0x7f);
                value = (UInt32)(value >> 7);
                if (value == 0)
                {
                    stream.WriteByte(cur);
                }
                else
                {
                    stream.WriteByte((byte)(cur | 0x80));
                }
            }
        }
        private void WriteInt64(Int64 value)
        {
            if (value == 0)
            {
                stream.WriteByte(0);
                return;
            }
            while (value != 0)
            {
                var cur = (byte)(value & 0x7f);
                value = (Int64)(value >> 7);
                if (value == 0)
                {
                    stream.WriteByte(cur);
                }
                else
                {
                    stream.WriteByte((byte)(cur | 0x80));
                }
            }
        }
        private void WriteUInt64(UInt64 value)
        {
            if (value == 0)
            {
                stream.WriteByte(0);
                return;
            }
            while (value != 0)
            {
                var cur = (byte)(value & 0x7f);
                value = (UInt64)(value >> 7);
                if (value == 0)
                {
                    stream.WriteByte(cur);
                }
                else
                {
                    stream.WriteByte((byte)(cur | 0x80));
                }
            }
        }
        private void WriteString(String value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            WriteByteArray(bytes);
        }
        private void WriteByteArray(Byte[] value)
        {
            this.WriteUInt32((uint)value.Length);
            stream.Write(value);
        }
        private void WriteMessage(Message value)
        {
            this.WriteByteArray(value.ToArray());
        }
        private void WritePackedRepeated(object value, Type FieldType)
        {
            var oldstream = this.stream;
            var newstream = new MemoryStream();
            this.stream = newstream;
            int l = (int)(value.GetType().GetProperty("Length").GetValue(value, null));
            for (int i = 0; i < l; i++)
            {
                var v = value.GetType().GetMethod("GetValue", new Type[] { typeof(int) }).Invoke(value, new object[] { i });
                this.WriteData(v, Protobuf.FieldType.Varint, FieldType);
            }
            this.stream = oldstream;
            this.WriteByteArray(newstream.ReadAll());
        }
        private void WriteSingle(Single value)
        {
            var result = BitConverter.GetBytes(value);
            stream.Write(result);
        }
        private void WriteDouble(Double value)
        {
            var result = BitConverter.GetBytes(value);
            stream.Write(result);
        }
    }
}
