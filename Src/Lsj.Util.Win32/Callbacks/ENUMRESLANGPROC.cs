using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// ENUMRESLANGPROC
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ENUMRESLANGPROC
    {
        private nint _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator EnumResLangProc(ENUMRESLANGPROC val) => (EnumResLangProc)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(EnumResLangProc));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator ENUMRESLANGPROC(EnumResLangProc val) => new ENUMRESLANGPROC { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator nint(ENUMRESLANGPROC val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator ENUMRESLANGPROC(nint val) => new ENUMRESLANGPROC { _ptr = val };
    }
}
