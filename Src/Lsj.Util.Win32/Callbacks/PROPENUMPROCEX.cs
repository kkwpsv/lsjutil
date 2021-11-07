using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// PROPENUMPROCEX
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nc-winuser-propenumprocexw"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PROPENUMPROCEX
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator Propenumprocex(PROPENUMPROCEX val) => (Propenumprocex)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(Propenumprocex));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PROPENUMPROCEX(Propenumprocex val) => new PROPENUMPROCEX { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(PROPENUMPROCEX val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator PROPENUMPROCEX(IntPtr val) => new PROPENUMPROCEX { _ptr = val };
    }
}
