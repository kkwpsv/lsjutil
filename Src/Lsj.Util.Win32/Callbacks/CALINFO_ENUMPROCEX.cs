using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// CALINFO_ENUMPROCEX
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/dd317807(v=vs.85)"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CALINFO_ENUMPROCEX
    {
        private nint _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator EnumCalendarInfoProcEx(CALINFO_ENUMPROCEX val) => (EnumCalendarInfoProcEx)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(EnumCalendarInfoProcEx));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator CALINFO_ENUMPROCEX(EnumCalendarInfoProcEx val) => new CALINFO_ENUMPROCEX { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator nint(CALINFO_ENUMPROCEX val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator CALINFO_ENUMPROCEX(nint val) => new CALINFO_ENUMPROCEX { _ptr = val };
    }
}
