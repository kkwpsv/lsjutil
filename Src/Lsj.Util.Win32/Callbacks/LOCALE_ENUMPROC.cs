using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// LOCALE_ENUMPROC
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LOCALE_ENUMPROC
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator EnumLocalesProc(LOCALE_ENUMPROC val) => (EnumLocalesProc)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(EnumLocalesProc));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LOCALE_ENUMPROC(EnumLocalesProc val) => new LOCALE_ENUMPROC { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(LOCALE_ENUMPROC val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator LOCALE_ENUMPROC(IntPtr val) => new LOCALE_ENUMPROC { _ptr = val };
    }
}
