using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Comdlg32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// LPPAGESETUPHOOK
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commdlg/nc-commdlg-lppagesetuphook"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LPPAGESETUPHOOK
    {
        private nint _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator Lppagesetuphook(LPPAGESETUPHOOK val) => (Lppagesetuphook)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(Lppagesetuphook));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPPAGESETUPHOOK(Lppagesetuphook val) => new LPPAGESETUPHOOK { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator nint(LPPAGESETUPHOOK val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator LPPAGESETUPHOOK(nint val) => new LPPAGESETUPHOOK { _ptr = val };
    }
}
