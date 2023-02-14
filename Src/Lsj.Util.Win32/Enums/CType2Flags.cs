using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// CType 2 Flags
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/stringapiset/nf-stringapiset-getstringtypew"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum CType2Flags : ushort
    {
        /// <summary>
        /// Left to right
        /// </summary>
        C2_LEFTTORIGHT = 0x0001,

        /// <summary>
        /// Right to left
        /// </summary>
        C2_RIGHTTOLEFT = 0x0002,

        /// <summary>
        /// European number, European digit
        /// </summary>
        C2_EUROPENUMBER = 0x0003,

        /// <summary>
        /// European numeric separator
        /// </summary>
        C2_EUROPESEPARATOR = 0x0004,

        /// <summary>
        /// European numeric terminator
        /// </summary>
        C2_EUROPETERMINATOR = 0x0005,

        /// <summary>
        /// Arabic number
        /// </summary>
        C2_ARABICNUMBER = 0x0006,

        /// <summary>
        /// Common numeric separator
        /// </summary>
        C2_COMMONSEPARATOR = 0x0007,

        /// <summary>
        /// Block separator
        /// </summary>
        C2_BLOCKSEPARATOR = 0x0008,

        /// <summary>
        /// Segment separator
        /// </summary>
        C2_SEGMENTSEPARATOR = 0x0009,

        /// <summary>
        /// White space
        /// </summary>
        C2_WHITESPACE = 0x000A,

        /// <summary>
        /// Other neutrals
        /// </summary>
        C2_OTHERNEUTRAL = 0x000B,

        /// <summary>
        /// No implicit directionality (for example, control codes)
        /// </summary>
        C2_NOTAPPLICABLE = 0x0000,
    }
}
