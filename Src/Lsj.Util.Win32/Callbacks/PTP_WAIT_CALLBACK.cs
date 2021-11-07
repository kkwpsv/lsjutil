using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// PTP_WAIT_CALLBACK
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/previous-versions/windows/desktop/legacy/ms687017(v=vs.85)"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PTP_WAIT_CALLBACK
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator Ptpwaitcallback(PTP_WAIT_CALLBACK val) => (Ptpwaitcallback)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(Ptpwaitcallback));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PTP_WAIT_CALLBACK(Ptpwaitcallback val) => new PTP_WAIT_CALLBACK { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(PTP_WAIT_CALLBACK val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator PTP_WAIT_CALLBACK(IntPtr val) => new PTP_WAIT_CALLBACK { _ptr = val };
    }
}
