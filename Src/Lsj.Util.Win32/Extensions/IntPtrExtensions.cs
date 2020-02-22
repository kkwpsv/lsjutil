using System;
using System.Collections.Generic;
using System.Text;

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
        public static uint SafeToUInt32(this IntPtr ptr) => unchecked((uint)ptr.SafeToInt32());

        /// <summary>
        /// Safe Convert To <see cref="long"/>
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static long SafeToInt64(this IntPtr ptr) => ptr.ToInt64();

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
        public static UIntPtr SafeToUIntPtr(this IntPtr ptr) => (UIntPtr)ptr.SafeToUInt64();
    }
}
