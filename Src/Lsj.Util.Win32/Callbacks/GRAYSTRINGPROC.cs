using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// GRAYSTRINGPROC
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nc-winuser-graystringproc"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct GRAYSTRINGPROC
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator Graystringproc(GRAYSTRINGPROC val) => (Graystringproc)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(Graystringproc));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator GRAYSTRINGPROC(Graystringproc val) => new GRAYSTRINGPROC { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(GRAYSTRINGPROC val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator GRAYSTRINGPROC(IntPtr val) => new GRAYSTRINGPROC { _ptr = val };
    }
}
