using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// PTP_SIMPLE_CALLBACK
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms686295(v=vs.85)"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PTP_SIMPLE_CALLBACK
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator Ptpsimplecallback(PTP_SIMPLE_CALLBACK val) => (Ptpsimplecallback)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(Ptpsimplecallback));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PTP_SIMPLE_CALLBACK(Ptpsimplecallback val) => new PTP_SIMPLE_CALLBACK { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(PTP_SIMPLE_CALLBACK val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator PTP_SIMPLE_CALLBACK(IntPtr val) => new PTP_SIMPLE_CALLBACK { _ptr = val };
    }
}
