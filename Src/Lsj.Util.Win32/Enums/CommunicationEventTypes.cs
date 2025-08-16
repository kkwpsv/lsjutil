using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Communication event types
    /// </summary>
    [Flags]
    public enum CommunicationEventTypes : uint
    {
        /// <summary>
        /// EV_BREAK
        /// </summary>
        EV_BREAK = 0x0040,

        /// <summary>
        /// EV_CTS
        /// </summary>
        EV_CTS = 0x0008,

        /// <summary>
        /// EV_DSR
        /// </summary>
        EV_DSR = 0x0010,

        /// <summary>
        /// EV_ERR
        /// </summary>
        EV_ERR = 0x0080,

        /// <summary>
        /// EV_RING
        /// </summary>
        EV_RING = 0x0100,

        /// <summary>
        /// EV_RLSD
        /// </summary>
        EV_RLSD = 0x0020,

        /// <summary>
        /// EV_RXCHAR
        /// </summary>
        EV_RXCHAR = 0x0001,

        /// <summary>
        /// EV_RXFLAG
        /// </summary>
        EV_RXFLAG = 0x0002,

        /// <summary>
        /// EV_TXEMPTY
        /// </summary>
        EV_TXEMPTY = 0x0004,
    }
}
