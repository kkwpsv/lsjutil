using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// SENDASYNCPROC
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nc-winuser-sendasyncproc"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SENDASYNCPROC
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator Sendasyncproc(SENDASYNCPROC val) => (Sendasyncproc)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(Sendasyncproc));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator SENDASYNCPROC(Sendasyncproc val) => new SENDASYNCPROC { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(SENDASYNCPROC val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator SENDASYNCPROC(IntPtr val) => new SENDASYNCPROC { _ptr = val };
    }
}
