using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// C type 3 flags
    /// </summary>
    [Flags]
    public enum CType3Flags : ushort
    {
        /// <summary>
        /// C3_NONSPACING
        /// </summary>
        C3_NONSPACING = 0x0001,

        /// <summary>
        /// C3_DIACRITIC
        /// </summary>
        C3_DIACRITIC = 0x0002,

        /// <summary>
        /// C3_VOWELMARK
        /// </summary>
        C3_VOWELMARK = 0x0004,

        /// <summary>
        /// C3_SYMBOL
        /// </summary>
        C3_SYMBOL = 0x0008,

        /// <summary>
        /// C3_KATAKANA
        /// </summary>
        C3_KATAKANA = 0x0010,

        /// <summary>
        /// C3_HIRAGANA
        /// </summary>
        C3_HIRAGANA = 0x0020,

        /// <summary>
        /// C3_HALFWIDTH
        /// </summary>
        C3_HALFWIDTH = 0x0040,

        /// <summary>
        /// C3_FULLWIDTH
        /// </summary>
        C3_FULLWIDTH = 0x0080,

        /// <summary>
        /// C3_IDEOGRAPH
        /// </summary>
        C3_IDEOGRAPH = 0x0100,

        /// <summary>
        /// C3_KASHIDA
        /// </summary>
        C3_KASHIDA = 0x0200,

        /// <summary>
        /// C3_LEXICAL
        /// </summary>
        C3_LEXICAL = 0x0400,

        /// <summary>
        /// C3_HIGHSURROGATE
        /// </summary>
        C3_HIGHSURROGATE = 0x0800,

        /// <summary>
        /// C3_LOWSURROGATE
        /// </summary>
        C3_LOWSURROGATE = 0x1000,

        /// <summary>
        /// C3_ALPHA
        /// </summary>
        C3_ALPHA = 0x8000,

        /// <summary>
        /// C3_NOTAPPLICABLE
        /// </summary>
        C3_NOTAPPLICABLE = 0x0000,
    }
}
