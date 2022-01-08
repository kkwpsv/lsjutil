using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// LPTOP_LEVEL_EXCEPTION_FILTER
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LPTOP_LEVEL_EXCEPTION_FILTER
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator TOP_LEVEL_EXCEPTION_FILTER(LPTOP_LEVEL_EXCEPTION_FILTER val) => (TOP_LEVEL_EXCEPTION_FILTER)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(TOP_LEVEL_EXCEPTION_FILTER));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPTOP_LEVEL_EXCEPTION_FILTER(TOP_LEVEL_EXCEPTION_FILTER val) => new LPTOP_LEVEL_EXCEPTION_FILTER { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(LPTOP_LEVEL_EXCEPTION_FILTER val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator LPTOP_LEVEL_EXCEPTION_FILTER(IntPtr val) => new LPTOP_LEVEL_EXCEPTION_FILTER { _ptr = val };
    }
}
