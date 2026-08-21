using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// PINIT_ONCE_FN
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nc-synchapi-pinit_once_fn"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PINIT_ONCE_FN
    {
        private nint _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PinitOnceFn(PINIT_ONCE_FN val) => (PinitOnceFn)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(PinitOnceFn));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PINIT_ONCE_FN(PinitOnceFn val) => new PINIT_ONCE_FN { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator nint(PINIT_ONCE_FN val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator PINIT_ONCE_FN(nint val) => new PINIT_ONCE_FN { _ptr = val };
    }
}
