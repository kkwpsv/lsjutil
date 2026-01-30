using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// LANGGROUPLOCALE_ENUMPROC
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnls/nc-winnls-langgrouplocale_enumprocw"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LANGGROUPLOCALE_ENUMPROC
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LanggrouplocaleEnumproc(LANGGROUPLOCALE_ENUMPROC val) => (LanggrouplocaleEnumproc)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(LanggrouplocaleEnumproc));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LANGGROUPLOCALE_ENUMPROC(LanggrouplocaleEnumproc val) => new LANGGROUPLOCALE_ENUMPROC { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(LANGGROUPLOCALE_ENUMPROC val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator LANGGROUPLOCALE_ENUMPROC(IntPtr val) => new LANGGROUPLOCALE_ENUMPROC { _ptr = val };
    }
}
