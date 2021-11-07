using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Comdlg32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// LPOFNHOOKPROC
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commdlg/nc-commdlg-lpofnhookproc"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LPOFNHOOKPROC
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator Lpofnhookproc(LPOFNHOOKPROC val) => (Lpofnhookproc)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(Lpofnhookproc));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPOFNHOOKPROC(Lpofnhookproc val) => new LPOFNHOOKPROC { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(LPOFNHOOKPROC val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator LPOFNHOOKPROC(IntPtr val) => new LPOFNHOOKPROC { _ptr = val };
    }
}
