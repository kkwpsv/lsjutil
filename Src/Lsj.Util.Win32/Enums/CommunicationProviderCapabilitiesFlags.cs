using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Communication provider capabilities flags
    /// </summary>
    [Flags]
    public enum CommunicationProviderCapabilitiesFlags : uint
    {
        /// <summary>
        /// PCF_DTRDSR
        /// </summary>
        PCF_DTRDSR = 0x0001,

        /// <summary>
        /// PCF_RTSCTS
        /// </summary>
        PCF_RTSCTS = 0x0002,

        /// <summary>
        /// PCF_RLSD
        /// </summary>
        PCF_RLSD = 0x0004,

        /// <summary>
        /// PCF_PARITY_CHECK
        /// </summary>
        PCF_PARITY_CHECK = 0x0008,

        /// <summary>
        /// PCF_XONXOFF
        /// </summary>
        PCF_XONXOFF = 0x0010,

        /// <summary>
        /// PCF_SETXCHAR
        /// </summary>
        PCF_SETXCHAR = 0x0020,

        /// <summary>
        /// PCF_TOTALTIMEOUTS
        /// </summary>
        PCF_TOTALTIMEOUTS = 0x0040,

        /// <summary>
        /// PCF_INTTIMEOUTS
        /// </summary>
        PCF_INTTIMEOUTS = 0x0080,

        /// <summary>
        /// PCF_SPECIALCHARS
        /// </summary>
        PCF_SPECIALCHARS = 0x0100,

        /// <summary>
        /// PCF_16BITMODE
        /// </summary>
        PCF_16BITMODE = 0x0200,
    }
}
