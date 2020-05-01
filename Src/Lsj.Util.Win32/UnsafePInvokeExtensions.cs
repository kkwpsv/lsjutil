using System;
using System.Collections.Generic;
using System.Text;
using Lsj.Util.IL;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Some Unsafe Extensions for PInvoke
    /// </summary>
    public unsafe static class UnsafePInvokeExtensions
    {
        /// <summary>
        /// Null Ref
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static ref T NullRef<T>() => ref Unsafe.AsRef<T>(null);

        /// <summary>
        /// As Pointer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <returns></returns>
        public static IntPtr AsPointer<T>(ref T o) => (IntPtr)Unsafe.AsPointer(ref o);
    }
}
