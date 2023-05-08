using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// LOCALE_ENUMPROCEX
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LOCALE_ENUMPROCEX
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator EnumLocalesProcEx(LOCALE_ENUMPROCEX val) => (EnumLocalesProcEx)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(EnumLocalesProcEx));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LOCALE_ENUMPROCEX(EnumLocalesProcEx val) => new LOCALE_ENUMPROCEX { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(LOCALE_ENUMPROCEX val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator LOCALE_ENUMPROCEX(IntPtr val) => new LOCALE_ENUMPROCEX { _ptr = val };
    }
}
