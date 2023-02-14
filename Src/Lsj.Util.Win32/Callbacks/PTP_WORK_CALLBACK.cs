using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// PTP_WORK_CALLBACK
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms687396(v=vs.85)"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PTP_WORK_CALLBACK
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator Ptpworkcallback(PTP_WORK_CALLBACK val) => (Ptpworkcallback)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(Ptpworkcallback));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PTP_WORK_CALLBACK(Ptpworkcallback val) => new PTP_WORK_CALLBACK { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(PTP_WORK_CALLBACK val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator PTP_WORK_CALLBACK(IntPtr val) => new PTP_WORK_CALLBACK { _ptr = val };
    }
}
