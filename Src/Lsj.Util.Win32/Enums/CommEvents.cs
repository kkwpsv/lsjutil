using System;
using static Lsj.Util.Win32.Enums.CommErrors;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Comm Events
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-waitcommevent"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum CommEvents : uint
    {
        /// <summary>
        /// A break was detected on input.
        /// </summary>
        EV_BREAK = 0x0040,

        /// <summary>
        /// The CTS (clear-to-send) signal changed state.
        /// </summary>
        EV_CTS = 0x0008,

        /// <summary>
        /// The DSR (data-set-ready) signal changed state.
        /// </summary>
        EV_DSR = 0x0010,

        /// <summary>
        /// A line-status error occurred.
        /// Line-status errors are <see cref="CE_FRAME"/>, <see cref="CE_OVERRUN"/>, and <see cref="CE_RXPARITY"/>.
        /// </summary>
        EV_ERR = 0x0080,

        /// <summary>
        /// A ring indicator was detected.
        /// </summary>
        EV_RING = 0x0100,

        /// <summary>
        /// The RLSD (receive-line-signal-detect) signal changed state.
        /// </summary>
        EV_RLSD = 0x0020,

        /// <summary>
        /// A character was received and placed in the input buffer.
        /// </summary>
        EV_RXCHAR = 0x0001,

        /// <summary>
        /// The event character was received and placed in the input buffer.
        /// The event character is specified in the device's DCB structure,
        /// which is applied to a serial port by using the <see cref="SetCommState"/> function.
        /// </summary>
        EV_RXFLAG = 0x0002,

        /// <summary>
        /// The last character in the output buffer was sent.
        /// </summary>
        EV_TXEMPTY = 0x0004,
    }
}
