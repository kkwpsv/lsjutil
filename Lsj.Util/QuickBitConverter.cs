﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util
{
    /// <summary>
    /// Quick Bit Converter
    /// </summary>
    public static class QuickBitConverter
    {
        /// <summary>
        /// Convert To Int
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static int ConvertToInt(this byte[] src) => ConvertToInt(src, 0);
        /// <summary>
        /// Convert To Int
        /// </summary>
        /// <param name="src"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static int ConvertToInt(this byte[] src, int offset)
        {
            if (offset >= 0 && offset + 4 <= src.Length)
            {
                unsafe
                {
                    fixed (byte* ptr = src)
                    {
                        var x = ptr + offset;
                        return ConvertToInt(x);
                    }
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        /// <summary>
        /// Convert To Int
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public unsafe static int ConvertToInt(byte* src)
        {
            return *(int*)src;
        }
        /// <summary>
        /// Convert To Short
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static int ConvertToShort(this byte[] src) => ConvertToShort(src, 0);
        /// <summary>
        /// Convert To Short
        /// </summary>
        /// <param name="src"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static int ConvertToShort(this byte[] src, int offset)
        {
            if (offset >= 0 && offset + 2 <= src.Length)
            {
                unsafe
                {
                    fixed (byte* ptr = src)
                    {
                        var x = ptr + offset;
                        return ConvertToShort(x);
                    }
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        /// <summary>
        /// Convert To Short
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public unsafe static int ConvertToShort(byte* src)
        {
            return *(short*)src;
        }
        /// <summary>
        /// Convert To Bytes
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static byte[] ConvertToBytes(this int val)
        {
            var result = new byte[4];
            unsafe
            {
                fixed (byte* ptr = result)
                {
                    *(int*)ptr = val;
                }
            }
            return result;
        }
        /// <summary>
        /// Convert To Bytes
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static byte[] ConvertToBytes(this short val)
        {
            var result = new byte[2];
            unsafe
            {
                fixed (byte* ptr = result)
                {
                    *(short*)ptr = val;
                }
            }
            return result;
        }
    }

}
