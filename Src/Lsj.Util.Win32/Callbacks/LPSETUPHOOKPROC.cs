using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Comdlg32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// LPSETUPHOOKPROC
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commdlg/nc-commdlg-lpsetuphookproc"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LPSETUPHOOKPROC
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator Lpsetuphookproc(LPSETUPHOOKPROC val) => (Lpsetuphookproc)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(Lpsetuphookproc));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPSETUPHOOKPROC(Lpsetuphookproc val) => new LPSETUPHOOKPROC { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(LPSETUPHOOKPROC val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator LPSETUPHOOKPROC(IntPtr val) => new LPSETUPHOOKPROC { _ptr = val };
    }
}
