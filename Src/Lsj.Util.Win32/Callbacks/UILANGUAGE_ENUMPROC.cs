using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// UILANGUAGE_ENUMPROC
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/dd317821(v=vs.85)"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct UILANGUAGE_ENUMPROC
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator UilanguageEnumproc(UILANGUAGE_ENUMPROC val) => (UilanguageEnumproc)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(UilanguageEnumproc));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator UILANGUAGE_ENUMPROC(UilanguageEnumproc val) => new UILANGUAGE_ENUMPROC { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(UILANGUAGE_ENUMPROC val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator UILANGUAGE_ENUMPROC(IntPtr val) => new UILANGUAGE_ENUMPROC { _ptr = val };
    }
}
