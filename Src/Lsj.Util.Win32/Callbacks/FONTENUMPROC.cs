using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// FONTENUMPROC
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/dd162618(v=vs.85)"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct FONTENUMPROC
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator Fontenumproc(FONTENUMPROC val) => (Fontenumproc)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(Fontenumproc));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator FONTENUMPROC(Fontenumproc val) => new FONTENUMPROC { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(FONTENUMPROC val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator FONTENUMPROC(IntPtr val) => new FONTENUMPROC { _ptr = val };
    }
}
