using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Baud rates
    /// </summary>
    [Flags]
    public enum BaudRates : uint
    {
        /// <summary>
        /// BAUD_075
        /// </summary>
        BAUD_075 = 0x00000001,

        /// <summary>
        /// BAUD_110
        /// </summary>
        BAUD_110 = 0x00000002,

        /// <summary>
        /// BAUD_134_5
        /// </summary>
        BAUD_134_5 = 0x00000004,

        /// <summary>
        /// BAUD_150
        /// </summary>
        BAUD_150 = 0x00000008,

        /// <summary>
        /// BAUD_300
        /// </summary>
        BAUD_300 = 0x00000010,

        /// <summary>
        /// BAUD_600
        /// </summary>
        BAUD_600 = 0x00000020,

        /// <summary>
        /// BAUD_1200
        /// </summary>
        BAUD_1200 = 0x00000040,

        /// <summary>
        /// BAUD_1800
        /// </summary>
        BAUD_1800 = 0x00000080,

        /// <summary>
        /// BAUD_2400
        /// </summary>
        BAUD_2400 = 0x00000100,

        /// <summary>
        /// BAUD_4800
        /// </summary>
        BAUD_4800 = 0x00000200,

        /// <summary>
        /// BAUD_7200
        /// </summary>
        BAUD_7200 = 0x00000400,

        /// <summary>
        /// BAUD_9600
        /// </summary>
        BAUD_9600 = 0x00000800,

        /// <summary>
        /// BAUD_14400
        /// </summary>
        BAUD_14400 = 0x00001000,

        /// <summary>
        /// BAUD_19200
        /// </summary>
        BAUD_19200 = 0x00002000,

        /// <summary>
        /// BAUD_38400
        /// </summary>
        BAUD_38400 = 0x00004000,

        /// <summary>
        /// BAUD_56K
        /// </summary>
        BAUD_56K = 0x00008000,

        /// <summary>
        /// BAUD_128K
        /// </summary>
        BAUD_128K = 0x00010000,

        /// <summary>
        /// BAUD_115200
        /// </summary>
        BAUD_115200 = 0x00020000,

        /// <summary>
        /// BAUD_57600
        /// </summary>
        BAUD_57600 = 0x00040000,

        /// <summary>
        /// BAUD_USER
        /// </summary>
        BAUD_USER = 0x10000000,
    }
}
