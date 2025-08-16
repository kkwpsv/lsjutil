using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// C type 2 flags
    /// </summary>
    [Flags]
    public enum CType2Flags : ushort
    {
        /// <summary>
        /// C2_LEFTTORIGHT
        /// </summary>
        C2_LEFTTORIGHT = 0x0001,

        /// <summary>
        /// C2_RIGHTTOLEFT
        /// </summary>
        C2_RIGHTTOLEFT = 0x0002,

        /// <summary>
        /// C2_EUROPENUMBER
        /// </summary>
        C2_EUROPENUMBER = 0x0003,

        /// <summary>
        /// C2_EUROPESEPARATOR
        /// </summary>
        C2_EUROPESEPARATOR = 0x0004,

        /// <summary>
        /// C2_EUROPETERMINATOR
        /// </summary>
        C2_EUROPETERMINATOR = 0x0005,

        /// <summary>
        /// C2_ARABICNUMBER
        /// </summary>
        C2_ARABICNUMBER = 0x0006,

        /// <summary>
        /// C2_COMMONSEPARATOR
        /// </summary>
        C2_COMMONSEPARATOR = 0x0007,

        /// <summary>
        /// C2_BLOCKSEPARATOR
        /// </summary>
        C2_BLOCKSEPARATOR = 0x0008,

        /// <summary>
        /// C2_SEGMENTSEPARATOR
        /// </summary>
        C2_SEGMENTSEPARATOR = 0x0009,

        /// <summary>
        /// C2_WHITESPACE
        /// </summary>
        C2_WHITESPACE = 0x000A,

        /// <summary>
        /// C2_OTHERNEUTRAL
        /// </summary>
        C2_OTHERNEUTRAL = 0x000B,

        /// <summary>
        /// C2_NOTAPPLICABLE
        /// </summary>
        C2_NOTAPPLICABLE = 0x0000,
    }
}
