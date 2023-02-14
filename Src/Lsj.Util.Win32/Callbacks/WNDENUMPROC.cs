using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// WNDENUMPROC
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms633498(v%3Dvs.85)"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct WNDENUMPROC
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator Wndenumproc(WNDENUMPROC val) => (Wndenumproc)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(Wndenumproc));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator WNDENUMPROC(Wndenumproc val) => new WNDENUMPROC { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(WNDENUMPROC val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator WNDENUMPROC(IntPtr val) => new WNDENUMPROC { _ptr = val };
    }
}
