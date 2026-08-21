using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// DATEFMT_ENUMPROCEX
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/dd317814(v=vs.85)"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DATEFMT_ENUMPROCEX
    {
        private nint _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator EnumDateFormatsProc(DATEFMT_ENUMPROCEX val) => (EnumDateFormatsProc)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(EnumDateFormatsProc));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator DATEFMT_ENUMPROCEX(EnumDateFormatsProc val) => new DATEFMT_ENUMPROCEX { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator nint(DATEFMT_ENUMPROCEX val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator DATEFMT_ENUMPROCEX(nint val) => new DATEFMT_ENUMPROCEX { _ptr = val };
    }
}
