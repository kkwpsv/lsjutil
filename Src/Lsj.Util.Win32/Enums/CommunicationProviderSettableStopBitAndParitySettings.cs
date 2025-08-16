using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Communication provider settable stop bit and parity settings
    /// </summary>
    [Flags]
    public enum CommunicationProviderSettableStopBitAndParitySettings : ushort
    {
        /// <summary>
        /// STOPBITS_10
        /// </summary>
        STOPBITS_10 = 0x0001,

        /// <summary>
        /// STOPBITS_15
        /// </summary>
        STOPBITS_15 = 0x0002,

        /// <summary>
        /// STOPBITS_20
        /// </summary>
        STOPBITS_20 = 0x0004,

        /// <summary>
        /// PARITY_NONE
        /// </summary>
        PARITY_NONE = 0x0100,

        /// <summary>
        /// PARITY_ODD
        /// </summary>
        PARITY_ODD = 0x0200,

        /// <summary>
        /// PARITY_EVEN
        /// </summary>
        PARITY_EVEN = 0x0400,

        /// <summary>
        /// PARITY_MARK
        /// </summary>
        PARITY_MARK = 0x0800,

        /// <summary>
        /// PARITY_SPACE
        /// </summary>
        PARITY_SPACE = 0x1000,
    }
}
