using System;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// Pointer Extensions
    /// </summary>
    public static class PointerExtensions
    {
        /// <summary>
        /// Safe Convert To <see cref="int"/>
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static int SafeToInt32(this IntPtr ptr) => (int)ptr;

        /// <summary>
        /// Safe Convert To <see cref="uint"/>
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static int SafeToInt32(this UIntPtr ptr) => (int)ptr;

        /// <summary>
        /// Safe Convert To <see cref="int"/>
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static int SafeToInt32(this IPointer ptr) => (int)ptr.ToNint();

        /// <summary>
        /// Safe Convert To <see cref="uint"/>
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static uint SafeToUInt32(this IntPtr ptr) => (uint)ptr;

        /// <summary>
        /// Safe Convert To <see cref="uint"/>
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static uint SafeToUInt32(this UIntPtr ptr) => (uint)ptr;

        /// <summary>
        /// Safe Convert To <see cref="uint"/>
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static uint SafeToUInt32(this IPointer ptr) => (uint)ptr.ToNint();

        /// <summary>
        /// Safe Convert To <see cref="long"/>
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static long SafeToInt64(this IntPtr ptr) => (long)ptr;

        /// <summary>
        /// Safe Convert To <see cref="long"/>
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static long SafeToInt64(this UIntPtr ptr) => (long)ptr;

        /// <summary>
        /// Safe Convert To <see cref="long"/>
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static long SafeToInt64(this IPointer ptr) => (long)ptr.ToNint();

        /// <summary>
        /// Safe Convert To <see cref="ulong"/>
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static ulong SafeToUInt64(this IntPtr ptr) => (ulong)ptr;

        /// <summary>
        /// Safe Convert To <see cref="ulong"/>
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static ulong SafeToUInt64(this UIntPtr ptr) => (ulong)ptr;

        /// <summary>
        /// Safe Convert To <see cref="ulong"/>
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static ulong SafeToUInt64(this IPointer ptr) => (ulong)ptr.ToNint();

        /// <summary>
        /// Safe Convert To <see cref="IntPtr"/>
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static IntPtr SafeToIntPtr(this UIntPtr ptr) => (nint)(nuint)ptr;

        /// <summary>
        /// Safe Convert To <see cref="UIntPtr"/>
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static UIntPtr SafeToUIntPtr(this IntPtr ptr) => (nuint)(nint)ptr;

        /// <summary>
        /// Safe Convert To <see cref="IntPtr"/>
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static UIntPtr SafeToUIntPtr(this IPointer ptr) => (nuint)ptr.ToNint();
    }
}
