using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace Lsj.Util.Text
{
    /// <summary>
    /// Variable string.
    /// </summary>
    public unsafe sealed class VariableString :DisposableClass, IDisposable, ICloneable, IComparable, IComparable<VariableString>, IEnumerable<char>
    {

        internal class VariableStringEnumerator :IEnumerator<char>
        {
            VariableString str;
            int length;
            int current;
            internal VariableStringEnumerator(VariableString str)
            {
                this.str = str;
                this.length = str.Length;
                this.current = 0;
            }

            public char Current => str[current];

            object IEnumerator.Current => Current;

            public void Dispose()
            {

            }
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



        char* handle;
        int bufferlength;
        int stringlength;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Text.VariableString"/> class.
        /// </summary>
        public VariableString()
        {
            this.stringlength = 0;
            this.bufferlength = 10;
            Alloc();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Text.VariableString"/> class.
        /// </summary>
        /// <param name="bufferlength">Bufferlength.</param>
        public VariableString(int bufferlength)
        {
            this.stringlength = 0;
            this.bufferlength = bufferlength;
            Alloc();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Text.VariableString"/> class.
        /// </summary>
        /// <param name="src">Source.</param>
        public VariableString(VariableString src)
        {
            this.stringlength = src.stringlength;
            this.bufferlength = src.bufferlength;
            Alloc();
            UnsafeHelper.Copy(src.handle, this.handle, this.bufferlength);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Text.VariableString"/> class.
        /// </summary>
        /// <param name="value">Value.</param>
        public VariableString(string value)
        {
            var chars = value.ToCharArray();
            this.stringlength = chars.Length;
            this.bufferlength = this.stringlength < 10 ? 10 : this.stringlength;
            Alloc();
            fixed (char* src = chars)
            {
                UnsafeHelper.Copy(src, handle, stringlength);
            }
        }


        private void Alloc()
        {
            this.handle = (char*)Marshal.AllocHGlobal(bufferlength).ToPointer();
        }
        private void ReAlloc(int newbufferlength)
        {
            var oldhandle = this.handle;
            this.bufferlength = newbufferlength;
            this.handle = (char*)Marshal.AllocHGlobal(newbufferlength).ToPointer();
            UnsafeHelper.Copy(oldhandle, handle, stringlength > newbufferlength ? newbufferlength : stringlength);
            Marshal.FreeHGlobal((IntPtr)oldhandle);
        }
        /// <summary>
        /// Cleans up unmanaged resources.
        /// </summary>
        protected override void CleanUpUnmanagedResources()
        {
            Marshal.FreeHGlobal((IntPtr)handle);
        }
        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Lsj.Util.Text.VariableString"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Lsj.Util.Text.VariableString"/>.</returns>
        public override string ToString()
        {
            var chars = new char[this.stringlength];
            fixed (char* src = chars)
            {
                UnsafeHelper.Copy(handle, src, stringlength);
            }
            return new string(chars);
        }
        /// <summary>
        /// Clone this instance.
        /// </summary>
        /// <returns>The clone.</returns>
        public object Clone() => new VariableString(this);

        /// <summary>
        /// Gets the length.
        /// </summary>
        /// <value>The length.</value>
        public int Length => stringlength;


        /// <summary>
        /// Gets the char with the specified index.
        /// </summary>
        /// <param name="i">The index.</param>
        public char this[int i]
        {
            get
            {
                if (i >= stringlength)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    return *(handle + i);
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
        /// Compares to.
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
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="T:Lsj.Util.Text.VariableString"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="T:Lsj.Util.Text.VariableString"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current
        /// <see cref="T:Lsj.Util.Text.VariableString"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            return ((IComparable)(this)).CompareTo(obj) == 0;
        }
        /// <summary>
        /// Determines whether the specified <see cref="Lsj.Util.Text.VariableString"/> is equal to the current <see cref="T:Lsj.Util.Text.VariableString"/>.
        /// </summary>
        /// <param name="str">The <see cref="Lsj.Util.Text.VariableString"/> to compare with the current <see cref="T:Lsj.Util.Text.VariableString"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="Lsj.Util.Text.VariableString"/> is equal to the current
        /// <see cref="T:Lsj.Util.Text.VariableString"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(VariableString str)
        {
            return CompareTo(str) == 0;
        }

        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator<char> GetEnumerator() => new VariableStringEnumerator(this);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        /// <summary>
        /// Contains the specified char.
        /// </summary>
        /// <returns></returns>
        /// <param name="x">The char.</param>
        public bool Contains(char x) => IndexOf(x) >= 0;
        private int IndexOf(char x)
        {
            for (int i = 0; i < stringlength; i++)
            {
                if (x == *(handle + i))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Contains the specified VariableString.
        /// </summary>
        /// <returns></returns>
        /// <param name="x">The VariableString.</param>
        public bool Contains(VariableString x) => IndexOf(x) >= 0;
        private int IndexOf(VariableString x)
        {
            int xlength = x.Length;
            bool flag = true;
            for (int i = 0; i < stringlength - xlength; i++)
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
        /// Substring from startIndex.
        /// </summary>
        /// <returns></returns>
        /// <param name="startIndex">Start index.</param>
        public VariableString Substring(int startIndex) => Substring(startIndex, stringlength - startIndex);
        /// <summary>
        /// Substring the specified startIndex and length.
        /// </summary>
        /// <returns>The substring.</returns>
        /// <param name="startIndex">Start index.</param>
        /// <param name="length">Length.</param>
        public VariableString Substring(int startIndex, int length)
        {
            if (startIndex + length > stringlength)
            {
                throw new ArgumentOutOfRangeException();
            }
            var result = new VariableString(length);
            result.stringlength = length;
            UnsafeHelper.Copy(handle, startIndex, result.handle, 0, length);
            return result;
        }
        /// <summary>
        /// Adds a <see cref="Lsj.Util.Text.VariableString"/> to a <see cref="Lsj.Util.Text.VariableString"/>
        /// </summary>
        /// <param name="a">The <see cref="Lsj.Util.Text.VariableString"/> to be added.</param>
        /// <param name="b">The <see cref="Lsj.Util.Text.VariableString"/> to add.</param>
        public static VariableString operator +(VariableString a, VariableString b)
        {
            var total = a.Length + b.Length;
            if (a.bufferlength < total)
            {
                a.ReAlloc(total);
            }
            UnsafeHelper.Copy(b.handle, 0, a.handle, a.stringlength, b.Length);
            a.stringlength = total;
            return a;
        }
        /// <summary>
        /// Determines whether a specified instance of <see cref="Lsj.Util.Text.VariableString"/> is equal to another
        /// specified <see cref="Lsj.Util.Text.VariableString"/>.
        /// </summary>
        /// <param name="a">The first <see cref="Lsj.Util.Text.VariableString"/> to compare.</param>
        /// <param name="b">The second <see cref="Lsj.Util.Text.VariableString"/> to compare.</param>
        /// <returns><c>true</c> if <c>a</c> and <c>b</c> are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(VariableString a, VariableString b)
        {
            return a.Equals(b);
        }
        /// <summary>
        /// Determines whether a specified instance of <see cref="Lsj.Util.Text.VariableString"/> is not equal to another
        /// specified <see cref="Lsj.Util.Text.VariableString"/>.
        /// </summary>
        /// <param name="a">The first <see cref="Lsj.Util.Text.VariableString"/> to compare.</param>
        /// <param name="b">The second <see cref="Lsj.Util.Text.VariableString"/> to compare.</param>
        /// <returns><c>true</c> if <c>a</c> and <c>b</c> are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(VariableString a, VariableString b)
        {
            return !(a == b);
        }
        /// <summary>
        /// Serves as a hash function for a <see cref="T:Lsj.Util.Text.VariableString"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a hash table.</returns>
        public override int GetHashCode()
        {
            //TODO: hashcode
            return base.GetHashCode();
        }
    }
}
