using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// LINEDDAPROC
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nc-wingdi-lineddaproc"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LINEDDAPROC
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator Lineddaproc(LINEDDAPROC val) => (Lineddaproc)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(Lineddaproc));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LINEDDAPROC(Lineddaproc val) => new LINEDDAPROC { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(LINEDDAPROC val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator LINEDDAPROC(IntPtr val) => new LINEDDAPROC { _ptr = val };
    }
}
