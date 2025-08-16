using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Data bits
    /// </summary>
    [Flags]
    public enum DATABITS : ushort
    {
        /// <summary>
        /// DATABITS_5
        /// </summary>
        DATABITS_5 = 0x0001,

        /// <summary>
        /// DATABITS_6
        /// </summary>
        DATABITS_6 = 0x0002,

        /// <summary>
        /// DATABITS_7
        /// </summary>
        DATABITS_7 = 0x0004,

        /// <summary>
        /// DATABITS_8
        /// </summary>
        DATABITS_8 = 0x0008,

        /// <summary>
        /// DATABITS_16
        /// </summary>
        DATABITS_16 = 0x0010,

        /// <summary>
        /// DATABITS_16X
        /// </summary>
        DATABITS_16X = 0x0020,
    }
}
