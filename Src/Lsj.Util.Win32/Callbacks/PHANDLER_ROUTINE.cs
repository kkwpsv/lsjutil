using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// PHANDLER_ROUTINE
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/console/handlerroutine"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PHANDLER_ROUTINE
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator HandlerRoutine(PHANDLER_ROUTINE val) => (HandlerRoutine)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(HandlerRoutine));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PHANDLER_ROUTINE(HandlerRoutine val) => new PHANDLER_ROUTINE { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(PHANDLER_ROUTINE val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator PHANDLER_ROUTINE(IntPtr val) => new PHANDLER_ROUTINE { _ptr = val };
    }
}
