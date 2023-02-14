using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Comdlg32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// LPFRHOOKPROC
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commdlg/nc-commdlg-lpfrhookproc"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LPFRHOOKPROC
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator Lpfrhookproc(LPFRHOOKPROC val) => (Lpfrhookproc)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(Lpfrhookproc));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPFRHOOKPROC(Lpfrhookproc val) => new LPFRHOOKPROC { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(LPFRHOOKPROC val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator LPFRHOOKPROC(IntPtr val) => new LPFRHOOKPROC { _ptr = val };
    }
}
