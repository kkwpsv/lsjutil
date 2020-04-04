using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.CharacterSets;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The TEXTMETRIC structure contains basic information about a physical font.
    /// All sizes are specified in logical units; that is, they depend on the current mapping mode of the display context.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/ns-wingdi-textmetricw
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct TEXTMETRIC
    {
        /// <summary>
        /// The height (ascent + descent) of characters.
        /// </summary>
        public LONG tmHeight;

        /// <summary>
        /// The ascent (units above the base line) of characters.
        /// </summary>
        public LONG tmAscent;

        /// <summary>
        /// The descent (units below the base line) of characters.
        /// </summary>
        public LONG tmDescent;

        /// <summary>
        /// The amount of leading (space) inside the bounds set by the tmHeight member.
        /// Accent marks and other diacritical characters may occur in this area.
        /// The designer may set this member to zero.
        /// </summary>
        public LONG tmInternalLeading;

        /// <summary>
        /// The amount of extra leading (space) that the application adds between rows.
        /// Since this area is outside the font, it contains no marks and is not altered
        /// by text output calls in either <see cref="OPAQUE"/> or <see cref="TRANSPARENT"/> mode.
        /// The designer may set this member to zero.
        /// </summary>
        public LONG tmExternalLeading;

        /// <summary>
        /// The average width of characters in the font (generally defined as the width of the letter x ).
        /// This value does not include the overhang required for bold or italic characters.
        /// </summary>
        public LONG tmAveCharWidth;

        /// <summary>
        /// The width of the widest character in the font.
        /// </summary>
        public LONG tmMaxCharWidth;

        /// <summary>
        /// The weight of the font.
        /// </summary>
        public LONG tmWeight;

        /// <summary>
        /// The extra width per string that may be added to some synthesized fonts.
        /// When synthesizing some attributes, such as bold or italic, graphics device interface (GDI) or a device
        /// may have to add width to a string on both a per-character and per-string basis.
        /// For example, GDI makes a string bold by expanding the spacing of each character and overstriking by an offset value;
        /// it italicizes a font by shearing the string.
        /// In either case, there is an overhang past the basic string.
        /// For bold strings, the overhang is the distance by which the overstrike is offset.
        /// For italic strings, the overhang is the amount the top of the font is sheared past the bottom of the font.
        /// The <see cref="tmOverhang"/> member enables the application to determine how much of the character width
        /// returned by a <see cref="GetTextExtentPoint32"/> function call on a single character is the actual character width
        /// and how much is the per-string extra width.
        /// The actual width is the extent minus the overhang.
        /// </summary>
        public LONG tmOverhang;

        /// <summary>
        /// The horizontal aspect of the device for which the font was designed.
        /// </summary>
        public LONG tmDigitizedAspectX;

        /// <summary>
        /// The vertical aspect of the device for which the font was designed.
        /// The ratio of the <see cref="tmDigitizedAspectX"/> and <see cref="tmDigitizedAspectY"/> members is the aspect ratio of the device
        /// for which the font was designed.
        /// </summary>
        public LONG tmDigitizedAspectY;

        /// <summary>
        /// The value of the first character defined in the font.
        /// </summary>
        public WCHAR tmFirstChar;

        /// <summary>
        /// The value of the last character defined in the font.
        /// </summary>
        public WCHAR tmLastChar;

        /// <summary>
        /// The value of the character to be substituted for characters not in the font.
        /// </summary>
        public WCHAR tmDefaultChar;

        /// <summary>
        /// The value of the character that will be used to define word breaks for text justification.
        /// </summary>
        public WCHAR tmBreakChar;

        /// <summary>
        /// Specifies an italic font if it is nonzero.
        /// </summary>
        public BYTE tmItalic;

        /// <summary>
        /// Specifies an underlined font if it is nonzero.
        /// </summary>
        public BYTE tmUnderlined;

        /// <summary>
        /// A strikeout font if it is nonzero.
        /// </summary>
        public BYTE tmStruckOut;

        /// <summary>
        /// Specifies information about the pitch, the technology, and the family of a physical font.
        /// The four low-order bits of this member specify information about the pitch and the technology of the font.
        /// A constant is defined for each of the four bits.
        /// <see cref="TMPF_FIXED_PITCH"/>:
        /// If this bit is set the font is a variable pitch font.
        /// If this bit is clear the font is a fixed pitch font.
        /// Note very carefully that those meanings are the opposite of what the constant name implies.
        /// <see cref="TMPF_VECTOR"/>: 	If this bit is set the font is a vector font.
        /// <see cref="TMPF_TRUETYPE"/>: If this bit is set the font is a TrueType font.
        /// <see cref="TMPF_DEVICE"/>: If this bit is set the font is a device font.
        /// An application should carefully test for qualities encoded in these low-order bits, making no arbitrary assumptions.
        /// For example, besides having their own bits set, TrueType and PostScript fonts set the <see cref="TMPF_VECTOR"/> bit.
        /// A monospace bitmap font has all of these low-order bits clear; a proportional bitmap font sets the <see cref="TMPF_FIXED_PITCH"/> bit.
        /// A Postscript printer device font sets the <see cref="TMPF_DEVICE"/>, <see cref="TMPF_VECTOR"/>, and <see cref="TMPF_FIXED_PITCH"/> bits.
        /// The four high-order bits of <see cref="tmPitchAndFamily"/> designate the font's font family.
        /// An application can use the value 0xF0 and the bitwise AND operator to mask out the four low-order bits of <see cref="tmPitchAndFamily"/>,
        /// thus obtaining a value that can be directly compared with font family names to find an identical match.
        /// For information about font families, see the description of the <see cref="LOGFONT"/> structure.
        /// </summary>
        public BYTE tmPitchAndFamily;

        /// <summary>
        /// The character set of the font.
        /// The character set can be one of the following values.
        /// <see cref="ANSI_CHARSET"/>, <see cref="BALTIC_CHARSET"/>, <see cref="CHINESEBIG5_CHARSET"/>, <see cref="DEFAULT_CHARSET"/>,
        /// <see cref="EASTEUROPE_CHARSET"/>, <see cref="GB2312_CHARSET"/>, <see cref="GREEK_CHARSET"/>, <see cref="HANGUL_CHARSET"/>,
        /// <see cref="MAC_CHARSET"/>, <see cref="OEM_CHARSET"/>, <see cref="RUSSIAN_CHARSET"/>, <see cref="SHIFTJIS_CHARSET"/>,
        /// <see cref="SYMBOL_CHARSET"/>, <see cref="TURKISH_CHARSET"/>, <see cref="VIETNAMESE_CHARSET"/>
        /// Korean language edition of Windows:
        /// <see cref="JOHAB_CHARSET"/>
        /// Middle East language edition of Windows:
        /// <see cref="ARABIC_CHARSET"/>, <see cref="HEBREW_CHARSET"/>
        /// Thai language edition of Windows:
        /// <see cref="THAI_CHARSET"/>
        /// </summary>
        public BYTE tmCharSet;
    }
}
