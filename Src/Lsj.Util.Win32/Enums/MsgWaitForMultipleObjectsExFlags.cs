using System;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="MsgWaitForMultipleObjectsExFlags"/> Flags
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-msgwaitformultipleobjectsex
    /// </para>
    /// </summary>
    [Flags]
    public enum MsgWaitForMultipleObjectsExFlags : uint
    {
        /// <summary>
        /// The function also returns if an APC has been queued to the thread with <see cref="QueueUserAPC"/> while the thread is in the waiting state.
        /// </summary>
        MWMO_ALERTABLE = 0x0002,

        /// <summary>
        /// The function returns if input exists for the queue, even if the input has been seen (but not removed) using a call to another function,
        /// such as <see cref="PeekMessage"/>.
        /// </summary>
        MWMO_INPUTAVAILABLE = 0x0004,

        /// <summary>
        /// The function returns when all objects in the pHandles array are signaled and an input event has been received, all at the same time.
        /// </summary>
        MWMO_WAITALL = 0x0001,
    }
}
