using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// DATEFMT_ENUMPROCEXEX
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/dd317815(v=vs.85)"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DATEFMT_ENUMPROCEXEX
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator EnumDateFormatsProcExEx(DATEFMT_ENUMPROCEXEX val) => (EnumDateFormatsProcExEx)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(EnumDateFormatsProcExEx));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator DATEFMT_ENUMPROCEXEX(EnumDateFormatsProcExEx val) => new DATEFMT_ENUMPROCEXEX { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(DATEFMT_ENUMPROCEXEX val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator DATEFMT_ENUMPROCEXEX(IntPtr val) => new DATEFMT_ENUMPROCEXEX { _ptr = val };
    }
}
