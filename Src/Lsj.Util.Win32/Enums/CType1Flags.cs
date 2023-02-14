using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// CType 1 Flags
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/stringapiset/nf-stringapiset-getstringtypew"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum CType1Flags : ushort
    {
        /// <summary>
        /// Uppercase
        /// </summary>
        C1_UPPER = 0x0001,

        /// <summary>
        /// Lowercase
        /// </summary>
        C1_LOWER = 0x0002,

        /// <summary>
        /// Decimal digits
        /// </summary>
        C1_DIGIT = 0x0004,

        /// <summary>
        /// Space characters
        /// </summary>
        C1_SPACE = 0x0008,

        /// <summary>
        /// Punctuation
        /// </summary>
        C1_PUNCT = 0x0010,

        /// <summary>
        /// Control characters
        /// </summary>
        C1_CNTRL = 0x0020,

        /// <summary>
        /// Blank characters
        /// </summary>
        C1_BLANK = 0x0040,

        /// <summary>
        /// Hexadecimal digits
        /// </summary>
        C1_XDIGIT = 0x0080,

        /// <summary>
        /// Any linguistic character: alphabetical, syllabary, or ideographic
        /// </summary>
        C1_ALPHA = 0x0100,

        /// <summary>
        /// A defined character, but not one of the other C1_* types
        /// </summary>
        C1_DEFINED = 0x0200,
    }
}
