using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// ENHMFENUMPROC
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/dd162606(v=vs.85)"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ENHMFENUMPROC
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator Enhmfenumproc(ENHMFENUMPROC val) => (Enhmfenumproc)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(Enhmfenumproc));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator ENHMFENUMPROC(Enhmfenumproc val) => new ENHMFENUMPROC { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(ENHMFENUMPROC val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator ENHMFENUMPROC(IntPtr val) => new ENHMFENUMPROC { _ptr = val };
    }
}
