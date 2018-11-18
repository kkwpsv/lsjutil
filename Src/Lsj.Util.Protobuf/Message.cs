using Lsj.Util.Reflection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lsj.Util.Protobuf
{
    /// <summary>
    /// Message
    /// </summary>
    public abstract class Message : DisposableClass, IDisposable
    {
        private int offset = 0;
        private byte[] buffer;
        private MemoryStream stream;
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
            var requires = this.GetType().GetProperties().Where(x => x.GetAttribute<FieldAttribute>() != null && x.GetAttribute<FieldAttribute>().IsRequired).ToDictionary(x => x.GetAttribute<FieldAttribute>().FieldNumber, x => false);
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
                    if (requires.ContainsKey(fieldnumber))
                    {
                        requires[fieldnumber] = true;
                    }
                }
            }
            if (!requires.All(x => x.Value))
            {
                throw new InvalidDataException("Some required field is null");
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
                if (FieldType == typeof(float))
                {
                    return this.ReadSingle();
                }
            }
            else if (Type == Protobuf.FieldType.Bit64)
            {
                if (FieldType == typeof(double))
                {
                    return this.ReadDouble();
                }
            }
            throw new InvalidCastException($"Bad data");
        }
        private delegate object VarintSetMethodDelegate();
        private VarintSetMethodDelegate GetVarintSetMethodByType(Type type)
        {
            if (type == typeof(bool))
            {
                return () => (this.ReadBoolean());
            }
            else if (type == typeof(sbyte))
            {
                return () => (this.ReadSByte());
            }
            else if (type == typeof(byte))
            {
                return () => (this.ReadByte());
            }
            else if (type == typeof(short))
            {
                return () => (this.ReadInt16());
            }
            else if (type == typeof(ushort))
            {
                return () => (this.ReadUInt16());
            }
            else if (type == typeof(int))
            {
                return () => (this.ReadInt32());
            }
            else if (type == typeof(uint))
            {
                return () => (this.ReadUInt32());
            }
            else if (type == typeof(long))
            {
                return () => (this.ReadInt64());
            }
            else if (type == typeof(ulong))
            {
                return () => (this.ReadUInt64());
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        private bool ReadBoolean()
        {
            if (offset + 1 <= buffer.Length)
            {
                var x = buffer[offset++];
                return (x & 0x7f) != 0;
            }
            throw new InvalidOperationException("Buffer is too short");
        }
        private sbyte ReadSByte()
        {
            sbyte result = 0;
            int l = 0;
            int p = 0;
            while (offset < buffer.Length)
            {
                while (l < 8)
                {
                    var x = buffer[offset++];
                    result |= (sbyte)((sbyte)(x & 0x7f) << p);
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
        private byte ReadByte()
        {
            byte result = 0;
            int l = 0;
            int p = 0;
            while (offset < buffer.Length)
            {
                while (l < 8)
                {
                    var x = buffer[offset++];
                    result |= (byte)((byte)(x & 0x7f) << p);
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
        private short ReadInt16()
        {
            short result = 0;
            int l = 0;
            int p = 0;
            while (offset < buffer.Length)
            {
                while (l < 16)
                {
                    var x = buffer[offset++];
                    result |= (short)((short)(x & 0x7f) << p);
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
        private ushort ReadUInt16()
        {
            ushort result = 0;
            int l = 0;
            int p = 0;
            while (offset < buffer.Length)
            {
                while (l < 16)
                {
                    var x = buffer[offset++];
                    result |= (ushort)((ushort)(x & 0x7f) << p);
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
        private int ReadInt32()
        {
            Int32 result = 0;
            int l = 0;
            int p = 0;
            while (offset < buffer.Length)
            {
                while (l < 32)
                {
                    var x = buffer[offset++];
                    result |= (x & 0x7f) << p;
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
        private uint ReadUInt32()
        {
            uint result = 0;
            int l = 0;
            int p = 0;
            while (offset < buffer.Length)
            {
                while (l < 32)
                {
                    var x = buffer[offset++];
                    result |= (uint)(x & 0x7f) << p;
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
        private long ReadInt64()
        {
            long result = 0;
            int l = 0;
            int p = 0;
            while (offset < buffer.Length)
            {
                while (l < 64)
                {
                    var x = buffer[offset++];
                    result |= (long)(x & 0x7f) << p;
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
        private ulong ReadUInt64()
        {
            ulong result = 0;
            int l = 0;
            int p = 0;
            while (offset < buffer.Length)
            {
                while (l < 64)
                {
                    var x = buffer[offset++];
                    result |= (ulong)(x & 0x7f) << p;
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
        private string ReadString()
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
        private float ReadSingle()
        {
            if (offset + 4 <= buffer.Length)
            {
                var result = BitConverter.ToSingle(this.buffer, offset);
                offset += 4;
                return result;
            }
            throw new InvalidOperationException("Buffer is too short");
        }
        private double ReadDouble()
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
                else if (attribute.IsRequired)
                {
                    throw new InvalidDataException("Null value for required field");
                }

            }
            return stream.ReadAll();


        }
        private delegate void VarintWriteMethodDelegate(object data);
        private VarintWriteMethodDelegate GetVarintWriteMethodByType(Type type)
        {
            if (type == typeof(bool))
            {
                return (object o) => { this.WriteBoolean((bool)o); };
            }
            else if (type == typeof(sbyte))
            {
                return (object o) => { this.WriteSByte((sbyte)o); };
            }
            else if (type == typeof(byte))
            {
                return (object o) => { this.WriteByte((byte)o); };
            }
            else if (type == typeof(short))
            {
                return (object o) => { this.WriteInt16((short)o); };
            }
            else if (type == typeof(ushort))
            {
                return (object o) => { this.WriteUInt16((ushort)o); };
            }
            else if (type == typeof(int))
            {
                return (object o) => { this.WriteInt32((int)o); };
            }
            else if (type == typeof(uint))
            {
                return (object o) => { this.WriteUInt32((uint)o); };
            }
            else if (type == typeof(long))
            {
                return (object o) => { this.WriteInt64((long)o); };
            }
            else if (type == typeof(ulong))
            {
                return (object o) => { this.WriteUInt64((ulong)o); };
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
                    this.WriteString((string)data);
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
                if (FieldType == typeof(float))
                {
                    this.WriteSingle((float)data);
                    return;
                }
            }
            else if (Type == Protobuf.FieldType.Bit64)
            {
                if (FieldType == typeof(double))
                {
                    this.WriteDouble((double)data);
                    return;
                }
            }
            throw new InvalidCastException($"Bad data");
        }
        private void WriteBoolean(bool value)
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
        private void WriteSByte(sbyte value)
        {
            if (value == 0)
            {
                stream.WriteByte(0);
                return;
            }
            while (value != 0)
            {
                var cur = (byte)(value & 0x7f);
                value = (sbyte)(value >> 7);
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
        private void WriteByte(byte value)
        {
            if (value == 0)
            {
                stream.WriteByte(0);
                return;
            }
            while (value != 0)
            {
                var cur = (byte)(value & 0x7f);
                value = (byte)(value >> 7);
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
        private void WriteInt16(short value)
        {
            if (value == 0)
            {
                stream.WriteByte(0);
                return;
            }
            while (value != 0)
            {
                var cur = (byte)(value & 0x7f);
                value = (short)(value >> 7);
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
        private void WriteUInt16(ushort value)
        {
            if (value == 0)
            {
                stream.WriteByte(0);
                return;
            }
            while (value != 0)
            {
                var cur = (byte)(value & 0x7f);
                value = (ushort)(value >> 7);
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
        private void WriteInt32(int value)
        {
            if (value == 0)
            {
                stream.WriteByte(0);
                return;
            }
            while (value != 0)
            {
                var cur = (byte)(value & 0x7f);
                value = value >> 7;
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
        private void WriteUInt32(uint value)
        {
            if (value == 0)
            {
                stream.WriteByte(0);
                return;
            }
            while (value != 0)
            {
                var cur = (byte)(value & 0x7f);
                value = value >> 7;
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
        private void WriteInt64(long value)
        {
            if (value == 0)
            {
                stream.WriteByte(0);
                return;
            }
            while (value != 0)
            {
                var cur = (byte)(value & 0x7f);
                value = value >> 7;
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
        private void WriteUInt64(ulong value)
        {
            if (value == 0)
            {
                stream.WriteByte(0);
                return;
            }
            while (value != 0)
            {
                var cur = (byte)(value & 0x7f);
                value = value >> 7;
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
        private void WriteString(string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            WriteByteArray(bytes);
        }
        private void WriteByteArray(byte[] value)
        {
            this.WriteUInt32((uint)value.Length);
            stream.Write(value);
        }
        private void WriteMessage(Message value) => this.WriteByteArray(value.ToArray());
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
        private void WriteSingle(float value)
        {
            var result = BitConverter.GetBytes(value);
            stream.Write(result);
        }
        private void WriteDouble(double value)
        {
            var result = BitConverter.GetBytes(value);
            stream.Write(result);
        }
        /// <summary>
        /// Clean Up Managed Resource
        /// </summary>
        protected override void CleanUpManagedResources()
        {
            if (this.stream != null)
            {
                this.stream.Dispose();
            }
            base.CleanUpManagedResources();
        }
    }
}
