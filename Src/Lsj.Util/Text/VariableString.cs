using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Lsj.Util.Text
{
    /// <summary>
    /// Variable String
    /// </summary>
    public sealed unsafe class VariableString : DisposableClass, ICloneable, IComparable, IComparable<VariableString>, IEnumerable<char>
    {
        internal class VariableStringEnumerator : IEnumerator<char>
        {
            private readonly VariableString str;
            private readonly int length;
            private int current;

            internal VariableStringEnumerator(VariableString str)
            {
                this.str = str;
                this.length = str.Length;
                this.current = 0;
            }

            public char Current => str[current];

            object IEnumerator.Current => Current;

            public void Dispose() => Static.DoNothing();

            public bool MoveNext()
            {
                if (current < length)
                {
                    current++;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Reset()
            {
                current = 0;
            }
        }

        private char* handle;
        private int bufferlength;

        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Text.VariableString"/> class.
        /// </summary>
        public VariableString()
        {
            this.Length = 0;
            this.bufferlength = 10;
            Alloc();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Text.VariableString"/> class.
        /// </summary>
        /// <param name="bufferlength">Buffer Length</param>
        public VariableString(int bufferlength)
        {
            this.Length = 0;
            this.bufferlength = bufferlength;
            Alloc();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Text.VariableString"/> class.
        /// </summary>
        /// <param name="src">Source</param>
        public VariableString(VariableString src)
        {
            this.Length = src.Length;
            this.bufferlength = src.bufferlength;
            Alloc();
            UnsafeHelper.Copy(src.handle, this.handle, this.bufferlength);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Text.VariableString"/> class.
        /// </summary>
        /// <param name="str">Source String</param>
        public VariableString(string str)
        {
            var chars = str.ToCharArray();
            this.Length = chars.Length;
            this.bufferlength = this.Length < 10 ? 10 : this.Length;
            Alloc();
            fixed (char* src = chars)
            {
                UnsafeHelper.Copy(src, handle, Length);
            }
        }

        private void Alloc()
        {
            this.handle = (char*)Marshal.AllocHGlobal(bufferlength * 2).ToPointer();
        }

        private void ReAlloc(int newbufferlength)
        {
            var oldhandle = this.handle;
            this.bufferlength = newbufferlength;
            this.handle = (char*)Marshal.AllocHGlobal(newbufferlength * 2).ToPointer();
            UnsafeHelper.Copy(oldhandle, handle, (Length > newbufferlength ? newbufferlength : Length) * 2);
            Marshal.FreeHGlobal((IntPtr)oldhandle);
        }

        /// <summary>
        /// Cleans up unmanaged resources
        /// </summary>
        protected override void CleanUpUnmanagedResources()
        {
            Marshal.FreeHGlobal((IntPtr)handle);
        }

        /// <summary>
        /// Convert To String
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var chars = new char[this.Length];
            fixed (char* src = chars)
            {
                UnsafeHelper.Copy(handle, src, Length);
            }
            return new string(chars);
        }

        /// <summary>
        /// Clone
        /// </summary>
        public object Clone() => new VariableString(this);

        /// <summary>
        /// Length
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// Get the char with the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        public char this[int index]
        {
            get
            {
                if (index >= Length)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    return *(handle + index);
                }
            }
        }

        int IComparable.CompareTo(object obj)
        {
            if (obj is string)
            {
                using (var x = new VariableString(obj as string))
                {
                    return CompareTo(x);
                }
            }
            else if (obj is VariableString)
            {
                return CompareTo(obj as VariableString);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Compare to
        /// </summary>
        /// <returns></returns>
        /// <param name="other">Other.</param>
        public int CompareTo(VariableString other)
        {
            if (other == null)
            {
                return 1;
            }
            else if (this.Length > other.Length)
            {
                return 1;
            }
            else if (this.Length < other.Length)
            {
                return -1;
            }
            else
            {
                for (int i = 0; i < this.Length; i++)
                {
                    if (*(this.handle + i) != *(other.handle + i))
                    {
                        return *(this.handle + i) - *(other.handle + i) > 0 ? 1 : -1;
                    }
                }
                return 0;
            }
        }

        /// <summary>
        /// Equal
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return ((IComparable)(this)).CompareTo(obj) == 0;
        }

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool Equals(VariableString str)
        {
            return CompareTo(str) == 0;
        }

        /// <summary>
        /// Gets the enumerator
        /// </summary>
        public IEnumerator<char> GetEnumerator() => new VariableStringEnumerator(this);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// If contain the specified char
        /// </summary>
        /// <param name="x">The character</param>
        public bool Contains(char x) => IndexOf(x) >= 0;

        private int IndexOf(char x)
        {
            for (int i = 0; i < Length; i++)
            {
                if (x == *(handle + i))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// If contain the specified string
        /// </summary>
        /// <param name="x">The string</param>
        public bool Contains(VariableString x) => IndexOf(x) >= 0;

        private int IndexOf(VariableString x)
        {
            int xlength = x.Length;
            bool flag = true;
            for (int i = 0; i < Length - xlength; i++)
            {
                flag = true;
                for (int j = 0; j < xlength; j++)
                {
                    if (x[i + j] != this[i + j])
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Substring
        /// </summary>
        /// <param name="startIndex">Start index</param>
        public VariableString Substring(int startIndex) => Substring(startIndex, Length - startIndex);

        /// <summary>
        /// Substring
        /// </summary>
        /// <param name="startIndex">Start index</param>
        /// <param name="length">Length</param>
        public VariableString Substring(int startIndex, int length)
        {
            if (startIndex + length > Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            var result = new VariableString(length)
            {
                Length = length
            };
            UnsafeHelper.Copy(handle, startIndex, result.handle, 0, length);
            return result;
        }

        /// <summary>
        /// Concat
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static VariableString operator +(VariableString a, VariableString b)
        {
            var total = a.Length + b.Length;
            if (a.bufferlength < total)
            {
                a.ReAlloc(total);
            }
            UnsafeHelper.Copy(b.handle, 0, a.handle, a.Length, b.Length);
            a.Length = total;
            return a;
        }

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(VariableString a, VariableString b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// NotEquals
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(VariableString a, VariableString b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Get Hashcode
        /// </summary>
        public override int GetHashCode()
        {
            //TODO: hashcode
            return base.GetHashCode();
        }
    }
}
