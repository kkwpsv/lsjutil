using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// CALINFO_ENUMPROCEXEX
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/dd317808(v=vs.85)"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CALINFO_ENUMPROCEXEX
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator EnumCalendarInfoProcExEx(CALINFO_ENUMPROCEXEX val) => (EnumCalendarInfoProcExEx)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(EnumCalendarInfoProcExEx));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator CALINFO_ENUMPROCEXEX(EnumCalendarInfoProcExEx val) => new CALINFO_ENUMPROCEXEX { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(CALINFO_ENUMPROCEXEX val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator CALINFO_ENUMPROCEXEX(IntPtr val) => new CALINFO_ENUMPROCEXEX { _ptr = val };
    }
}
