using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// C type 1 flags
    /// </summary>
    [Flags]
    public enum CType1Flags : ushort
    {
        /// <summary>
        /// C1_UPPER
        /// </summary>
        C1_UPPER = 0x0001,

        /// <summary>
        /// C1_LOWER
        /// </summary>
        C1_LOWER = 0x0002,

        /// <summary>
        /// C1_DIGIT
        /// </summary>
        C1_DIGIT = 0x0004,

        /// <summary>
        /// C1_SPACE
        /// </summary>
        C1_SPACE = 0x0008,

        /// <summary>
        /// C1_PUNCT
        /// </summary>
        C1_PUNCT = 0x0010,

        /// <summary>
        /// C1_CNTRL
        /// </summary>
        C1_CNTRL = 0x0020,

        /// <summary>
        /// C1_BLANK
        /// </summary>
        C1_BLANK = 0x0040,

        /// <summary>
        /// C1_XDIGIT
        /// </summary>
        C1_XDIGIT = 0x0080,

        /// <summary>
        /// C1_ALPHA
        /// </summary>
        C1_ALPHA = 0x0100,

        /// <summary>
        /// C1_DEFINED
        /// </summary>
        C1_DEFINED = 0x0200,
    }
}
