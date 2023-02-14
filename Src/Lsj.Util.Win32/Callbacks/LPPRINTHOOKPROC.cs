using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Comdlg32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// LPPRINTHOOKPROC
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commdlg/nc-commdlg-lpprinthookproc"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LPPRINTHOOKPROC
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator Lpprinthookproc(LPPRINTHOOKPROC val) => (Lpprinthookproc)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(Lpprinthookproc));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPPRINTHOOKPROC(Lpprinthookproc val) => new LPPRINTHOOKPROC { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(LPPRINTHOOKPROC val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator LPPRINTHOOKPROC(IntPtr val) => new LPPRINTHOOKPROC { _ptr = val };
    }
}
