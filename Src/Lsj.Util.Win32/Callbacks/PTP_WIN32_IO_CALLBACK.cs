using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// PTP_WIN32_IO_CALLBACK
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms684124(v=vs.85)"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PTP_WIN32_IO_CALLBACK
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IoCompletionCallback(PTP_WIN32_IO_CALLBACK val) => (IoCompletionCallback)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(IoCompletionCallback));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PTP_WIN32_IO_CALLBACK(IoCompletionCallback val) => new PTP_WIN32_IO_CALLBACK { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(PTP_WIN32_IO_CALLBACK val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator PTP_WIN32_IO_CALLBACK(IntPtr val) => new PTP_WIN32_IO_CALLBACK { _ptr = val };
    }
}
