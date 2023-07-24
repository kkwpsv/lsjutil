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

        private char* _handle;
        private int _bufferlength;

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableString"/> class.
        /// </summary>
        public VariableString()
        {
            Length = 0;
            _bufferlength = 10;
            Alloc();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableString"/> class.
        /// </summary>
        /// <param name="bufferlength">Buffer Length</param>
        public VariableString(int bufferlength)
        {
            Length = 0;
            _bufferlength = bufferlength;
            Alloc();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableString"/> class.
        /// </summary>
        /// <param name="src">Source</param>
        public VariableString(VariableString src)
        {
            Length = src.Length;
            _bufferlength = src._bufferlength;
            Alloc();
            UnsafeHelper.Copy(src._handle, _handle, _bufferlength);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableString"/> class.
        /// </summary>
        /// <param name="str">Source String</param>
        public VariableString(string str)
        {
            var chars = str.ToCharArray();
            Length = chars.Length;
            _bufferlength = Length < 10 ? 10 : Length;
            Alloc();
            fixed (char* src = chars)
            {
                UnsafeHelper.Copy(src, _handle, Length);
            }
        }

        private void Alloc()
        {
            _handle = (char*)Marshal.AllocHGlobal(_bufferlength * 2).ToPointer();
        }

        private void ReAlloc(int newbufferlength)
        {
            var oldhandle = _handle;
            _bufferlength = newbufferlength;
            _handle = (char*)Marshal.AllocHGlobal(newbufferlength * 2).ToPointer();
            UnsafeHelper.Copy(oldhandle, _handle, (Length > newbufferlength ? newbufferlength : Length) * 2);
            Marshal.FreeHGlobal((IntPtr)oldhandle);
        }

        /// <summary>
        /// Cleans up unmanaged resources
        /// </summary>
        protected override void CleanUpUnmanagedResources()
        {
            Marshal.FreeHGlobal((IntPtr)_handle);
        }

        /// <summary>
        /// Convert To String
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var chars = new char[Length];
            fixed (char* src = chars)
            {
                UnsafeHelper.Copy(_handle, src, Length);
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
                    return *(_handle + index);
                }
            }
        }

        int IComparable.CompareTo(object? obj)
        {
            if (obj is string str)
            {
                using (var x = new VariableString(str))
                {
                    return CompareTo(x);
                }
            }
            else if (obj is VariableString variableStr)
            {
                return CompareTo(variableStr);
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
        public int CompareTo(VariableString? other)
        {
            if (other is null)
            {
                return 1;
            }
            else if (Length > other.Length)
            {
                return 1;
            }
            else if (Length < other.Length)
            {
                return -1;
            }
            else
            {
                for (int i = 0; i < Length; i++)
                {
                    if (*(_handle + i) != *(other._handle + i))
                    {
                        return *(_handle + i) - *(other._handle + i) > 0 ? 1 : -1;
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
        public override bool Equals(object? obj)
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
                if (x == *(_handle + i))
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
            UnsafeHelper.Copy(_handle, startIndex, result._handle, 0, length);
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
            if (a._bufferlength < total)
            {
                a.ReAlloc(total);
            }
            UnsafeHelper.Copy(b._handle, 0, a._handle, a.Length, b.Length);
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
