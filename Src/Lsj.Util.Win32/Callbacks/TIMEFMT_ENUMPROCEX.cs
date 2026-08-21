using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// TIMEFMT_ENUMPROCEX
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/dd317833(v=vs.85)"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TIMEFMT_ENUMPROCEX
    {
        private nint _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator EnumTimeFormatsProcEx(TIMEFMT_ENUMPROCEX val) => (EnumTimeFormatsProcEx)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(EnumTimeFormatsProcEx));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator TIMEFMT_ENUMPROCEX(EnumTimeFormatsProcEx val) => new TIMEFMT_ENUMPROCEX { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator nint(TIMEFMT_ENUMPROCEX val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator TIMEFMT_ENUMPROCEX(nint val) => new TIMEFMT_ENUMPROCEX { _ptr = val };
    }
}
