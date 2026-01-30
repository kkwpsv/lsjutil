using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// LANGUAGEGROUP_ENUMPROC
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/dd317821(v=vs.85)"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LANGUAGEGROUP_ENUMPROC
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator EnumLanguageGroupsProc(LANGUAGEGROUP_ENUMPROC val) => (EnumLanguageGroupsProc)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(EnumLanguageGroupsProc));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LANGUAGEGROUP_ENUMPROC(EnumLanguageGroupsProc val) => new LANGUAGEGROUP_ENUMPROC { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(LANGUAGEGROUP_ENUMPROC val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator LANGUAGEGROUP_ENUMPROC(IntPtr val) => new LANGUAGEGROUP_ENUMPROC { _ptr = val };
    }
}
