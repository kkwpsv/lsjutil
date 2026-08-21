using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// WAITORTIMERCALLBACK
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms687066(v=vs.85)"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct WAITORTIMERCALLBACK
    {
        private nint _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator WaitOrTimerCallback(WAITORTIMERCALLBACK val) => (WaitOrTimerCallback)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(WaitOrTimerCallback));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator WAITORTIMERCALLBACK(WaitOrTimerCallback val) => new WAITORTIMERCALLBACK { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator nint(WAITORTIMERCALLBACK val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator WAITORTIMERCALLBACK(nint val) => new WAITORTIMERCALLBACK { _ptr = val };
    }
}
