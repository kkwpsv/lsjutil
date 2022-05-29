using System;

namespace Lsj.Util.Win32.Extensions
{
    /// <summary>
    /// COM Extensions
    /// </summary>
    public static class ComExtensions
    {
        /// <summary>
        /// <para>
        /// Get com interface struct from pointer
        /// </para>
        /// <para>
        /// ONLY use return value directly.
        /// DON'T copy return value (like assign it to local variables), which will crash.
        /// </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pointer"></param>
        /// <returns></returns>
        public static unsafe ref T InterfaceFromPointer<T>(IntPtr pointer) where T : struct
        {
            return ref UnsafePInvokeExtensions.AsStructRef<T>(pointer);
        }
    }
}
