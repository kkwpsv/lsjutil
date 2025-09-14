using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// CODEPAGE_ENUMPROC
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/dd317809(v=vs.85)"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CODEPAGE_ENUMPROC
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator EnumCodePagesProc(CODEPAGE_ENUMPROC val) => (EnumCodePagesProc)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(EnumCodePagesProc));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator CODEPAGE_ENUMPROC(EnumCodePagesProc val) => new CODEPAGE_ENUMPROC { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(CODEPAGE_ENUMPROC val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator CODEPAGE_ENUMPROC(IntPtr val) => new CODEPAGE_ENUMPROC { _ptr = val };
    }
}
