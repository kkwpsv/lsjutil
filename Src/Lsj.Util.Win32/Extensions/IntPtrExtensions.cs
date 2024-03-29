﻿using Lsj.Util.Win32.BaseTypes;
using System;

namespace Lsj.Util.Win32.Extensions
{
    /// <summary>
    /// <see cref="IntPtr"/> Extensions
    /// </summary>
    public static class IntPtrExtensions
    {
        /// <summary>
        /// Safe Convert To <see cref="int"/>
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static int SafeToInt32(this IntPtr ptr) => IntPtr.Size == 8 ? (int)(ptr.ToInt64()) : ptr.ToInt32();

        /// <summary>
        /// Safe Convert To <see cref="uint"/>
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static int SafeToInt32(this UIntPtr ptr) => unchecked((int)ptr.SafeToUInt32());

        /// <summary>
        /// Safe Convert To <see cref="int"/>
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static int SafeToInt32(this IPointer ptr) => SafeToInt32(ptr.ToIntPtr());

        /// <summary>
        /// Safe Convert To <see cref="uint"/>
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static uint SafeToUInt32(this IntPtr ptr) => unchecked((uint)ptr.SafeToInt32());

        /// <summary>
        /// Safe Convert To <see cref="uint"/>
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static uint SafeToUInt32(this UIntPtr ptr) => UIntPtr.Size == 8 ? (uint)ptr.ToUInt64() : ptr.ToUInt32();

        /// <summary>
        /// Safe Convert To <see cref="uint"/>
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static uint SafeToUInt32(this IPointer ptr) => SafeToUInt32(ptr.ToIntPtr());

        /// <summary>
        /// Safe Convert To <see cref="long"/>
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static long SafeToInt64(this IntPtr ptr) => ptr.ToInt64();

        /// <summary>
        /// Safe Convert To <see cref="long"/>
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static long SafeToInt64(this UIntPtr ptr) => unchecked((long)ptr.ToUInt64());

        /// <summary>
        /// Safe Convert To <see cref="long"/>
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static long SafeToInt64(this IPointer ptr) => SafeToInt64(ptr.ToIntPtr());

        /// <summary>
        /// Safe Convert To <see cref="ulong"/>
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static ulong SafeToUInt64(this IntPtr ptr) => unchecked((ulong)ptr.ToInt64());

        /// <summary>
        /// Safe Convert To <see cref="ulong"/>
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static ulong SafeToUInt64(this UIntPtr ptr) => ptr.ToUInt64();

        /// <summary>
        /// Safe Convert To <see cref="ulong"/>
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static ulong SafeToUInt64(this IPointer ptr) => SafeToUInt64(ptr.ToIntPtr());

        /// <summary>
        /// Safe Convert To <see cref="IntPtr"/>
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static IntPtr SafeToIntPtr(this UIntPtr ptr) => (IntPtr)ptr.SafeToInt64();

        /// <summary>
        /// Safe Convert To <see cref="UIntPtr"/>
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static UIntPtr SafeToUIntPtr(this IntPtr ptr) => (UIntPtr)ptr.SafeToUInt64();

        /// <summary>
        /// Safe Convert To <see cref="IntPtr"/>
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static UIntPtr SafeToUIntPtr(this IPointer ptr) => SafeToUIntPtr(ptr.ToIntPtr());
    }
}
