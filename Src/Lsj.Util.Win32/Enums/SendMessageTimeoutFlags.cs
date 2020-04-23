﻿using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="SendMessageTimeout"/> Flags
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-sendmessagetimeoutw
    /// </para>
    /// </summary>
    public enum SendMessageTimeoutFlags : uint
    {
        /// <summary>
        /// The function returns without waiting for the time-out period to elapse if the receiving thread appears to not respond or "hangs."
        /// </summary>
        SMTO_ABORTIFHUNG = 0x0002,

        /// <summary>
        /// Prevents the calling thread from processing any other requests until the function returns.
        /// </summary>
        SMTO_BLOCK = 0x0001,

        /// <summary>
        /// The calling thread is not prevented from processing other requests while waiting for the function to return.
        /// </summary>
        SMTO_NORMAL = 0x0000,

        /// <summary>
        /// The function does not enforce the time-out period as long as the receiving thread is processing messages.
        /// </summary>
        SMTO_NOTIMEOUTIFNOTHUNG = 0x0008,

        /// <summary>
        /// The function should return 0 if the receiving window is destroyed or its owning thread dies while the message is being processed.
        /// </summary>
        SMTO_ERRORONEXIT = 0x0020,
    }
}
