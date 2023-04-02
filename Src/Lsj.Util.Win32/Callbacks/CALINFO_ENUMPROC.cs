using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// CALINFO_ENUMPROC
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/dd317806(v=vs.85)"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CALINFO_ENUMPROC
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator EnumCalendarInfoProc(CALINFO_ENUMPROC val) => (EnumCalendarInfoProc)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(EnumCalendarInfoProc));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator CALINFO_ENUMPROC(EnumCalendarInfoProc val) => new CALINFO_ENUMPROC { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(CALINFO_ENUMPROC val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator CALINFO_ENUMPROC(IntPtr val) => new CALINFO_ENUMPROC { _ptr = val };
    }
}
