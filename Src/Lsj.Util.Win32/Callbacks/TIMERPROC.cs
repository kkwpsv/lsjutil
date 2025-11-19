using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// TIMERPROC
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nc-winuser-timerproc"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TIMERPROC
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator Timerproc(TIMERPROC val) => (Timerproc)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(Timerproc));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator TIMERPROC(Timerproc val) => new TIMERPROC { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(TIMERPROC val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator TIMERPROC(IntPtr val) => new TIMERPROC { _ptr = val };
    }
}
