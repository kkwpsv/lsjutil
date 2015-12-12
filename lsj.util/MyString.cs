using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util
{
    public unsafe struct MyString
    {
        char* chars;
        public int Length;
        public MyString(string str) : this(str.ToCharArray())
        {
        }
        public MyString(char[] x)
        {
            this.Length = x.Length;
            char* z = stackalloc char[Length];
            fixed (char* ps = x)
            {
                var pt = ps;
                for (int i = 0; i < Length; i++)
                {
                    z = pt;
                    z++;
                    pt++;
                }
            }
            this.chars = z-Length;
        }
        public MyString(char* chars, int length)
        {
            this.chars = chars;
            this.Length = length;
        }
        public override string ToString()
        {
            return new string(chars, 0, Length);
        }
        public override bool Equals(object obj)
        {
            return (obj is MyString) && this == (MyString)obj;
        }
        public bool Equals(MyString str)
        {
            return this == str;
        }
        public static bool operator ==(MyString str1, MyString str2)
        {
            return str1.Length == str2.Length && (str1.chars == str2.chars || UnSafeEquals(str1, str2));
        }
        private unsafe static bool UnSafeEquals(MyString str1, MyString str2)
        {
            var i = str1.Length;
            char* ptr1 = str1.chars;
            char* ptr2 = str2.chars;
            while (i >= 12)
            {
                if (*(long*)ptr1 != *(long*)ptr2)
                {
                    return false;
                }
                if (*(long*)(ptr1 + 4) != *(long*)(ptr2 + 4))
                {
                    return false;
                }
                if (*(long*)(ptr1 + 8) != *(long*)(ptr2 + 8))
                {
                    return false;
                }
                ptr1 += 12;
                ptr2 += 12;
                i -= 12;
            }
            while (i > 0 && *(int*)ptr1 == *(int*)ptr2)
            {
                ptr1 += 2;
                ptr2 += 2;
                i -= 2;
            }
            return i <= 0;
        }
        public static bool operator !=(MyString str1, MyString str2)
        {
            return !(str1 == str2);
        }
        public MyString Clone()
        {
            return new MyString(chars,Length);
        }
        public void Append(string src) => UnsafeAppend(src.ToCharArray());
        public void Append(MyString src) => UnsafeAppend(src.chars,Length);
        private unsafe void UnsafeAppend(char[] x)
        {
            fixed (char* ps = x)
            {
                char* pt = ps;
                UnsafeAppend(pt, x.Length);
            }
        }
        private unsafe void UnsafeAppend(char* x, int length)
        {
            int all = this.Length + length;
            char* z = stackalloc char[all];
            char* pt = this.chars;
            int i = 0;
            for (; i < this.Length; i++)
            {
                *(z) = *(pt);
                z++;
                pt++;
            }
            for (; i < all; i++)
            {
                *(z) = *(x);
                z++;
                x++;
            }
            this.chars = z-all;
          //  System.Runtime.InteropServices.Marshal.AllocHGlobal()
            this.Length = all;
        }
    }
}
