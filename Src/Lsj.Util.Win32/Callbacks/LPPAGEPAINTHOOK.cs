using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Comdlg32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// LPPAGEPAINTHOOK
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commdlg/nc-commdlg-lppagepainthook"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LPPAGEPAINTHOOK
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator Lppagepainthook(LPPAGEPAINTHOOK val) => (Lppagepainthook)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(Lppagepainthook));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPPAGEPAINTHOOK(Lppagepainthook val) => new LPPAGEPAINTHOOK { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(LPPAGEPAINTHOOK val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator LPPAGEPAINTHOOK(IntPtr val) => new LPPAGEPAINTHOOK { _ptr = val };
    }
}
