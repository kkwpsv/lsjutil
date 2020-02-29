using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="NEWTEXTMETRIC"/> structure contains data that describes a physical font.
    /// </para>
    /// <para>
    /// From: 
    /// </para>
    /// </summary>
    /// <remarks>
    /// The last four members of the <see cref="NEWTEXTMETRIC"/> structure are not included in the <see cref="TEXTMETRIC"/> structure;
    /// in all other respects, the structures are identical.
    /// The sizes in the <see cref="NEWTEXTMETRIC"/> structure are typically specified in logical units;
    /// that is, they depend on the current mapping mode of the display context.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct NEWTEXTMETRIC
    {
        /// <summary>
        /// The height (ascent + descent) of characters.
        /// </summary>
        public int tmHeight;

        /// <summary>
        /// The ascent (units above the base line) of characters.
        /// </summary>
        public int tmAscent;

        /// <summary>
        /// The descent (units below the base line) of characters.
        /// </summary>
        public int tmDescent;

        /// <summary>
        /// The amount of leading (space) inside the bounds set by the <see cref="tmHeight"/> member.
        /// Accent marks and other diacritical characters may occur in this area.
        /// The designer may set this member to zero.
        /// </summary>
        public int tmInternalLeading;

        /// <summary>
        /// The amount of extra leading (space) that the application adds between rows.
        /// Since this area is outside the font, it contains no marks and is not altered
        /// by text output calls in either OPAQUE or TRANSPARENT mode.
        /// The designer may set this member to zero.
        /// </summary>
        public int tmExternalLeading;

        /// <summary>
        /// The average width of characters in the font (generally defined as the width of the letter x).
        /// This value does not include overhang required for bold or italic characters.
        /// </summary>
        public int tmAveCharWidth;

        /// <summary>
        /// The width of the widest character in the font.
        /// </summary>
        public int tmMaxCharWidth;

        /// <summary>
        /// The weight of the font.
        /// </summary>
        public int tmWeight;

        /// <summary>
        /// The extra width per string that may be added to some synthesized fonts.
        /// When synthesizing some attributes, such as bold or italic,
        /// graphics device interface (GDI) or a device may have to add width to a string on both a per-character and per-string basis.
        /// For example, GDI makes a string bold by expanding the spacing of each character and overstriking by an offset value;
        /// it italicizes a font by shearing the string.
        /// In either case, there is an overhang past the basic string.
        /// For bold strings, the overhang is the distance by which the overstrike is offset.
        /// For italic strings, the overhang is the amount the top of the font is sheared past the bottom of the font.
        /// The tmOverhang member enables the application to determine how much of the character width
        /// returned by a <see cref="GetTextExtentPoint32"/> function call on a single character
        /// is the actual character width and how much is the per-string extra width.
        /// The actual width is the extent minus the overhang.
        /// </summary>
        public int tmOverhang;

        /// <summary>
        /// The horizontal aspect of the device for which the font was designed.
        /// </summary>
        public int tmDigitizedAspectX;

        /// <summary>
        /// The vertical aspect of the device for which the font was designed.
        /// The ratio of the <see cref="tmDigitizedAspectX"/> and <see cref="tmDigitizedAspectY"/> members
        /// is the aspect ratio of the device for which the font was designed.
        /// </summary>
        public int tmDigitizedAspectY;

        /// <summary>
        /// The value of the first character defined in the font.
        /// </summary>
        public char tmFirstChar;

        /// <summary>
        /// The value of the last character defined in the font.
        /// </summary>
        public char tmLastChar;

        /// <summary>
        /// The value of the character to be substituted for characters that are not in the font.
        /// </summary>
        public char tmDefaultChar;

        /// <summary>
        /// The value of the character to be used to define word breaks for text justification.
        /// </summary>
        public char tmBreakChar;

        /// <summary>
        /// An italic font if it is nonzero.
        /// </summary>
        public byte tmItalic;

        /// <summary>
        /// An underlined font if it is nonzero.
        /// </summary>
        public byte tmUnderlined;

        /// <summary>
        /// A strikeout font if it is nonzero.
        /// </summary>
        public byte tmStruckOut;

        /// <summary>
        /// The pitch and family of the selected font.
        /// The low-order bit (bit 0) specifies the pitch of the font.
        /// If it is 1, the font is variable pitch (or proportional).
        /// If it is 0, the font is fixed pitch (or monospace).
        /// Bits 1 and 2 specify the font type.
        /// If both bits are 0, the font is a raster font; if bit 1 is 1 and bit 2 is 0, the font is a vector font;
        /// if bit 1 is 0 and bit 2 is set, or if both bits are 1, the font is some other type.
        /// Bit 3 is 1 if the font is a device font; otherwise, it is 0.
        /// The four high-order bits designate the font family.
        /// The <see cref="tmPitchAndFamily"/> member can be combined with the hexadecimal value 0xF0
        /// by using the bitwise AND operator and can then be compared with the font family names for an identical match.
        /// For more information about the font families, see <see cref="LOGFONT"/>.
        /// </summary>
        public byte tmPitchAndFamily;

        /// <summary>
        /// The character set of the font.
        /// </summary>
        public byte tmCharSet;

        /// <summary>
        /// Specifies whether the font is italic, underscored, outlined, bold, and so forth.
        /// May be any reasonable combination of the following values.
        /// Bit Name                                Meaning
        /// 0   <see cref="NTM_ITALIC"/>            italic
        /// 5   <see cref="NTM_BOLD"/>              bold
        /// 8   <see cref="NTM_REGULAR"/>           regular
        /// 16  <see cref="NTM_NONNEGATIVE_AC"/>    no glyph in a font at any size has a negative A or C space.
        /// 17  <see cref="NTM_PS_OPENTYPE"/>       PostScript OpenType font
        /// 18  <see cref="NTM_TT_OPENTYPE"/>       TrueType OpenType font
        /// 19  <see cref="NTM_MULTIPLEMASTER"/>    multiple master font
        /// 20  <see cref="NTM_TYPE1"/>             Type 1 font
        /// 21  <see cref="NTM_DSIG"/>              font with a digital signature. This allows traceability and ensures that the font has been tested and is not corrupted
        /// </summary>
        public uint ntmFlags;

        /// <summary>
        /// The size of the em square for the font.
        /// This value is in notional units (that is, the units for which the font was designed).
        /// </summary>
        public uint ntmSizeEM;

        /// <summary>
        /// The height, in notional units, of the font.
        /// This value should be compared with the value of the ntmSizeEM member.
        /// </summary>
        public uint ntmCellHeight;

        /// <summary>
        /// The average width of characters in the font, in notional units.
        /// This value should be compared with the value of the <see cref="ntmSizeEM"/> member.
        /// </summary>
        public uint ntmAvgWidth;
    }
}
