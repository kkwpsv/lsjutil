using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// MFENUMPROC
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/dd162630(v=vs.85)"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MFENUMPROC
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator Mfenumproc(MFENUMPROC val) => (Mfenumproc)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(Mfenumproc));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator MFENUMPROC(Mfenumproc val) => new MFENUMPROC { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(MFENUMPROC val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator MFENUMPROC(IntPtr val) => new MFENUMPROC { _ptr = val };
    }
}
