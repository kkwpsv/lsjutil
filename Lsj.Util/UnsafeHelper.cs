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
        /// Contact
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <returns></returns>
        public static byte[] Contact(byte[] src1, byte[] src2)
        {
            var result = new byte[src1.Length + src2.Length];
            Copy(src1, result, src1.Length);
            Copy(src2, 0, result, src1.Length, src2.Length);
            return result;
        }

        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="length"></param>
        public static void Copy(byte[] src, byte[] dst, long length)
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
        /// <param name="srcoffset"></param>
        /// <param name="dst"></param>
        /// <param name="dstoffset"></param>
        /// <param name="length"></param>
        public static void Copy(byte[] src, long srcoffset, byte[] dst, long dstoffset, long length)
        {
            fixed (byte* pts = src, pts2 = dst)
            {
                Copy(pts, srcoffset, pts2, dstoffset, length);
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
            fixed (byte* pts = dst)
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
        public static void Copy(byte* src, long srcoffset, byte* dst, long dstoffset, long length) => Copy(src + srcoffset, dst + dstoffset, length);
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
                CopyLong(src, dst);
                src += 8;
                dst += 8;
                length -= 8;
            }
            if (length >= 4)
            {
                CopyInt(src, dst);
                src += 4;
                dst += 4;
                length -= 4;
            }
            if (length >= 2)
            {
                CopyShort(src, dst);
                src += 2;
                dst += 2;
                length -= 2;
            }
            if (length == 1)
            {
                CopyByte(src, dst);
            }
        }

        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="length"></param>
        public static void Copy(short[] src, short[] dst, long length)
        {
            fixed (short* pts = src)
            {
                var ptr = pts;
                Copy(ptr, dst, length);
            }
        }
        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="src"></param>
        /// <param name="srcoffset"></param>
        /// <param name="dst"></param>
        /// <param name="dstoffset"></param>
        /// <param name="length"></param>
        public static void Copy(short[] src, long srcoffset, short[] dst, long dstoffset, long length)
        {
            fixed (short* pts = src, pts2 = dst)
            {
                Copy(pts, srcoffset, pts2, dstoffset, length);
            }
        }
        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="length"></param>
        public static void Copy(short* src, short[] dst, long length)
        {
            fixed (short* pts = dst)
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
        public static void Copy(short[] src, short* dst, long length)
        {
            fixed (short* pts = src)
            {
                var ptr = pts;
                Copy(ptr, dst, length);
            }
        }
        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="src"></param>
        /// <param name="srcoffset"></param>
        /// <param name="dst"></param>
        /// <param name="dstoffset"></param>
        /// <param name="length"></param>
        public static void Copy(short* src, long srcoffset, short* dst, long dstoffset, long length) => Copy(src + srcoffset, dst + dstoffset, length);
        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="length"></param>
        public static void Copy(short* src, short* dst, long length) => Copy((char*)src, (char*)dst, length);

        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="length"></param>
        public static void Copy(char[] src, char[] dst, long length)
        {
            fixed (char* pts = src)
            {
                var ptr = pts;
                Copy(ptr, dst, length);
            }
        }
        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="src"></param>
        /// <param name="srcoffset"></param>
        /// <param name="dst"></param>
        /// <param name="dstoffset"></param>
        /// <param name="length"></param>
        public static void Copy(char[] src, long srcoffset, char[] dst, long dstoffset, long length)
        {
            fixed (char* pts = src, pts2 = dst)
            {
                Copy(pts, srcoffset, pts2, dstoffset, length);
            }
        }
        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="length"></param>
        public static void Copy(char* src, char[] dst, long length)
        {
            fixed (char* pts = dst)
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
        public static void Copy(char[] src, char* dst, long length)
        {
            fixed (char* pts = src)
            {
                var ptr = pts;
                Copy(ptr, dst, length);
            }
        }
        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="src"></param>
        /// <param name="srcoffset"></param>
        /// <param name="dst"></param>
        /// <param name="dstoffset"></param>
        /// <param name="length"></param>
        public static void Copy(char* src, long srcoffset, char* dst, long dstoffset, long length) => Copy(src + srcoffset, dst + dstoffset, length);
        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="length"></param>
        public static void Copy(char* src, char* dst, long length)
        {
            while (length >= 4)
            {
                CopyLong(src, dst);
                src += 4;
                dst += 4;
                length -= 4;
            }
            if (length >= 2)
            {
                CopyInt(src, dst);
                src += 2;
                dst += 2;
                length -= 2;
            }
            if (length == 1)
            {
                CopyShort(src, dst);
            }
        }

        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="length"></param>
        public static void Copy(int[] src, int[] dst, long length)
        {
            fixed (int* pts = src)
            {
                var ptr = pts;
                Copy(ptr, dst, length);
            }
        }
        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="src"></param>
        /// <param name="srcoffset"></param>
        /// <param name="dst"></param>
        /// <param name="dstoffset"></param>
        /// <param name="length"></param>
        public static void Copy(int[] src, long srcoffset, int[] dst, long dstoffset, long length)
        {
            fixed (int* pts = src, pts2 = dst)
            {
                Copy(pts, srcoffset, pts2, dstoffset, length);
            }
        }
        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="length"></param>
        public static void Copy(int* src, int[] dst, long length)
        {
            fixed (int* pts = dst)
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
        public static void Copy(int[] src, int* dst, long length)
        {
            fixed (int* pts = src)
            {
                var ptr = pts;
                Copy(ptr, dst, length);
            }
        }
        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="src"></param>
        /// <param name="srcoffset"></param>
        /// <param name="dst"></param>
        /// <param name="dstoffset"></param>
        /// <param name="length"></param>
        public static void Copy(int* src, long srcoffset, int* dst, long dstoffset, long length) => Copy(src + srcoffset, dst + dstoffset, length);
        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="length"></param>
        public static void Copy(int* src, int* dst, long length)
        {
            while (length >= 2)
            {
                CopyLong(src, dst);
                src += 2;
                dst += 2;
                length -= 2;
            }
            if (length == 1)
            {
                CopyInt(src, dst);
            }
        }

        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="length"></param>
        public static void Copy(long[] src, long[] dst, long length)
        {
            fixed (long* pts = src)
            {
                var ptr = pts;
                Copy(ptr, dst, length);
            }
        }
        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="src"></param>
        /// <param name="srcoffset"></param>
        /// <param name="dst"></param>
        /// <param name="dstoffset"></param>
        /// <param name="length"></param>
        public static void Copy(long[] src, long srcoffset, long[] dst, long dstoffset, long length)
        {
            fixed (long* pts = src, pts2 = dst)
            {
                Copy(pts, srcoffset, pts2, dstoffset, length);
            }
        }
        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="length"></param>
        public static void Copy(long* src, long[] dst, long length)
        {
            fixed (long* pts = dst)
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
        public static void Copy(long[] src, long* dst, long length)
        {
            fixed (long* pts = src)
            {
                var ptr = pts;
                Copy(ptr, dst, length);
            }
        }
        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="src"></param>
        /// <param name="srcoffset"></param>
        /// <param name="dst"></param>
        /// <param name="dstoffset"></param>
        /// <param name="length"></param>
        public static void Copy(long* src, long srcoffset, long* dst, long dstoffset, long length) => Copy(src + srcoffset, dst + dstoffset, length);
        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="length"></param>
        public static void Copy(long* src, long* dst, long length)
        {
            while (length >= 1)
            {
                CopyLong(src, dst);
                src += 1;
                dst += 1;
                length -= 1;
            }
        }





        private static void CopyLong(void* src, void* dst) => *((long*)dst) = *((long*)src);
        private static void CopyInt(void* src, void* dst) => *((int*)dst) = *((int*)src);
        private static void CopyShort(void* src, void* dst) => *((short*)dst) = *((short*)src);
        private static void CopyByte(void* src, void* dst) => *((byte*)dst) = *((byte*)src);
        private static void CopyBool(void* src, void* dst) => *((bool*)dst) = *((bool*)src);

    }
}
