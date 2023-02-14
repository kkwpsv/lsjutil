using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// PTP_CLEANUP_GROUP_CANCEL_CALLBACK
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/nc-winnt-ptp_cleanup_group_cancel_callback"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PTP_CLEANUP_GROUP_CANCEL_CALLBACK
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PtpCleanupGroupCancelCallback(PTP_CLEANUP_GROUP_CANCEL_CALLBACK val) => (PtpCleanupGroupCancelCallback)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(PtpCleanupGroupCancelCallback));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PTP_CLEANUP_GROUP_CANCEL_CALLBACK(PtpCleanupGroupCancelCallback val) => new PTP_CLEANUP_GROUP_CANCEL_CALLBACK { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(PTP_CLEANUP_GROUP_CANCEL_CALLBACK val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator PTP_CLEANUP_GROUP_CANCEL_CALLBACK(IntPtr val) => new PTP_CLEANUP_GROUP_CANCEL_CALLBACK { _ptr = val };
    }
}
