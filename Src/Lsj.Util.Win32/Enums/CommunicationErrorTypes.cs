using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Communication error types
    /// </summary>
    [Flags]
    public enum CommunicationErrorTypes : uint
    {
        /// <summary>
        /// CE_BREAK
        /// </summary>
        CE_BREAK = 0x0010,

        /// <summary>
        /// CE_FRAME
        /// </summary>
        CE_FRAME = 0x0008,

        /// <summary>
        /// CE_OVERRUN
        /// </summary>
        CE_OVERRUN = 0x0002,

        /// <summary>
        /// CE_RXOVER
        /// </summary>
        CE_RXOVER = 0x0001,

        /// <summary>
        /// CE_RXPARITY
        /// </summary>
        CE_RXPARITY = 0x0004,
    }
}
