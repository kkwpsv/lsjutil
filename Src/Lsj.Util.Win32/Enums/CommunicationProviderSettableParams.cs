using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Communication provider settable params
    /// </summary>
    [Flags]
    public enum CommunicationProviderSettableParams : uint
    {
        /// <summary>
        /// SP_PARITY
        /// </summary>
        SP_PARITY = 0x0001,

        /// <summary>
        /// SP_BAUD
        /// </summary>
        SP_BAUD = 0x0002,

        /// <summary>
        /// SP_DATABITS
        /// </summary>
        SP_DATABITS = 0x0004,

        /// <summary>
        /// SP_STOPBITS
        /// </summary>
        SP_STOPBITS = 0x0008,

        /// <summary>
        /// SP_HANDSHAKING
        /// </summary>
        SP_HANDSHAKING = 0x0010,

        /// <summary>
        /// SP_PARITY_CHECK
        /// </summary>
        SP_PARITY_CHECK = 0x0020,

        /// <summary>
        /// SP_RLSD
        /// </summary>
        SP_RLSD = 0x0040,
    }
}
