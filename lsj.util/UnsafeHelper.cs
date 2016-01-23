using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util
{
    /// <summary>
    /// UnsafeHelper
    /// </summary>
    public unsafe static class UnsafeHelper
    {
        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="length"></param>
        public static void Copy(byte[] src, byte[] dst, long length)
        {
            fixed(byte* pts=src)
            {
                var ptr = pts;
                Copy(ptr, dst, length);
            }
        }
        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="length"></param>
        public static void Copy(byte* src, byte[] dst, long length)
        {
            fixed(byte* pts = dst)
            {
                var ptr = pts;
                Copy(src, ptr, length);
            }

        }
        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="length"></param>
        public static void Copy(byte[] src, byte* dst, long length)
        {
            fixed (byte* pts = src)
            {
                var ptr = pts;
                Copy(ptr, dst, length);
            }
        }
        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="length"></param>
        public static void Copy(byte* src, byte* dst, long length)
        {
            while (length >= 8)
            {
                copylong(src, dst);
                src += 8;
                dst += 8;
                length -= 8;
            }
            if (length >= 4)
            {
                copyint(src, dst);
                src += 4;
                dst += 4;
                length -= 4;
            }
            if (length >= 2)
            {
                copyshort(src, dst);
                src += 2;
                dst += 2;
                length -= 2;
            }
            if (length == 1)
            {
                copybyte(src, dst);
            }

        }
        /// <summary>
        /// Contact
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <returns></returns>
        public static byte[] Contact(byte[] src1, byte[] src2)
        {
            var result = new byte[src1.Length + src2.Length];
            Copy(src1, result, src1.Length);
            Copy(src2, result, src2.Length);
            return result;
        }
        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="length"></param>
        public static void Copy(int* src, int* dst, int length)
        {
            while (length >= 2)
            {
                src += 2;
                dst += 2;
                copylong(src, dst);
                length -= 2;
            }
            if (length == 1)
            {
                copyint(src, dst);
            }
        }
       /// <summary>
       /// Copy
       /// </summary>
       /// <param name="src"></param>
       /// <param name="dst"></param>
       /// <param name="length"></param>
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
            *((long*)dst) = *((long*)src);
        }
        static void copyint(void* src, void* dst)
        {
            *((int*)dst) = *((int*)src);
        }
        static void copyshort(void* src, void* dst)
        {
            *((short*)dst) = *((short*)src);
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
