using System;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="PeekMessage"/> Flags
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-peekmessagew
    /// </para>
    /// </summary>
    [Flags]
    public enum PeekMessageFlags
    {
        /// <summary>
        /// Messages are not removed from the queue after processing by <see cref="PeekMessage"/>.
        /// </summary>
        PM_NOREMOVE = 0x0000,

        /// <summary>
        /// Messages are removed from the queue after processing by <see cref="PeekMessage"/>.
        /// </summary>
        PM_REMOVE = 0x0001,

        /// <summary>
        /// Prevents the system from releasing any thread that is waiting for the caller to go idle (see <see cref="WaitForInputIdle"/>).
        /// Combine this value with either <see cref="PM_NOREMOVE"/> or <see cref="PM_REMOVE"/>.
        /// </summary>
        PM_NOYIELD = 0x0002,

        /// <summary>
        /// Process mouse and keyboard messages.
        /// </summary>
        PM_QS_INPUT = QueueStatus.QS_INPUT << 16,

        /// <summary>
        /// Process paint messages.
        /// </summary>
        PM_QS_PAINT = QueueStatus.QS_PAINT << 16,

        /// <summary>
        /// Process all posted messages, including timers and hotkeys.
        /// </summary>
        PM_QS_POSTMESSAGE = (QueueStatus.QS_POSTMESSAGE | QueueStatus.QS_HOTKEY | QueueStatus.QS_TIMER) << 16,

        /// <summary>
        /// Process all sent messages.
        /// </summary>
        PM_QS_SENDMESSAGE = QueueStatus.QS_SENDMESSAGE<<16,
    }
}
