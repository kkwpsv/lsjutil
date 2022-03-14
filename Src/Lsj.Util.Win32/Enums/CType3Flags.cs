using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// CType 3 Flags
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/stringapiset/nf-stringapiset-getstringtypew"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum CType3Flags : ushort
    {
        /// <summary>
        /// Nonspacing mark
        /// </summary>
        C3_NONSPACING = 0x0001,

        /// <summary>
        /// Diacritic nonspacing mark
        /// </summary>
        C3_DIACRITIC = 0x0002,

        /// <summary>
        /// Vowel nonspacing mark
        /// </summary>
        C3_VOWELMARK = 0x0004,

        /// <summary>
        /// Symbol
        /// </summary>
        C3_SYMBOL = 0x0008,

        /// <summary>
        /// Katakana character
        /// </summary>
        C3_KATAKANA = 0x0010,

        /// <summary>
        /// Hiragana character
        /// </summary>
        C3_HIRAGANA = 0x0020,

        /// <summary>
        /// Half-width (narrow) character
        /// </summary>
        C3_HALFWIDTH = 0x0040,

        /// <summary>
        /// Full-width (wide) character
        /// </summary>
        C3_FULLWIDTH = 0x0080,

        /// <summary>
        /// Ideographic character
        /// </summary>
        C3_IDEOGRAPH = 0x0100,

        /// <summary>
        /// Arabic kashida character
        /// </summary>
        C3_KASHIDA = 0x0200,

        /// <summary>
        /// Punctuation which is counted as part of the word (kashida, hyphen, feminine/masculine ordinal indicators, equal sign, and so forth)
        /// </summary>
        C3_LEXICAL = 0x0400,

        /// <summary>
        /// Windows Vista: High surrogate code unit
        /// </summary>
        C3_HIGHSURROGATE = 0x0800,

        /// <summary>
        /// Windows Vista: Low surrogate code unit
        /// </summary>
        C3_LOWSURROGATE = 0x1000,

        /// <summary>
        /// All linguistic characters (alphabetical, syllabary, and ideographic)
        /// </summary>
        C3_ALPHA = 0x8000,

        /// <summary>
        /// Not applicable
        /// </summary>
        C3_NOTAPPLICABLE = 0x0000,
    }
}
