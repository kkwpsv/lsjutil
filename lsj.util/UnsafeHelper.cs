using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util
{
    public unsafe static class UnsafeHelper
    {
        public static void Copy(byte[] src, byte[] dst, int length)
        {
            fixed(byte* ptr=src)
            {
                Copy(ptr, dst, length);
            }
        }
        public static void Copy(byte* src, byte[] dst, int length)
        {
            fixed(byte* ptr = dst)
            {
                Copy(src, ptr, length);
            }
        }
        public static void Copy(byte[] src, byte* dst, int length)
        {
            fixed (byte* ptr = src)
            {
                Copy(ptr, dst, length);
            }
        }
        public static void Copy(byte* src, byte* dst, int length)
        {
            while (length >= 4)
            {
                copylong(src, dst);
                length -= 4;
            }
            if (length >= 2)
            {
                copyint(src, dst);
                length -= 2;
            }
            if (length == 1)
            {
                copybyte(src, dst);
            }
        }
        public static void Copy(int* src, int* dst, int length)
        {
            while (length >= 2)
            {
                copylong(src, dst);
                length -= 2;
            }
            if (length == 1)
            {
                copyint(src, dst);
            }
        }
        public static void Copy(long* src, long* dst, int length)
        {
            while (length >= 1)
            {
                copylong(src, dst);
                length -= 1;
            }
        }
        static  void copylong(void* src,void* dst)
        {
            *((long*)dst) = *(long*)src;
        }
        static void copyint(void* src, void* dst)
        {
            *((int*)dst) = *(int*)src;
        }
        static void copybyte(void* src, void* dst)
        {
            *((byte*)dst) = *((byte*)src);
        }
        static void copybool(void* src, void* dst)
        {
            *((bool*)dst) = *((bool*)src);
        }
    }
}
