using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// TIMEFMT_ENUMPROC
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnls/nf-winnls-enumtimeformatsw"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TIMEFMT_ENUMPROC
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator EnumTimeFormatsProc(TIMEFMT_ENUMPROC val) => (EnumTimeFormatsProc)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(EnumTimeFormatsProc));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator TIMEFMT_ENUMPROC(EnumTimeFormatsProc val) => new TIMEFMT_ENUMPROC { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(TIMEFMT_ENUMPROC val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator TIMEFMT_ENUMPROC(IntPtr val) => new TIMEFMT_ENUMPROC { _ptr = val };
    }
}
