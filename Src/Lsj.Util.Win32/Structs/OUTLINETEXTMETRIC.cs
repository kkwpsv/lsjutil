using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="OUTLINETEXTMETRIC"/> structure contains metrics describing a TrueType font.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/ns-wingdi-outlinetextmetricw
    /// </para>
    /// </summary>
    /// <remarks>
    /// The sizes returned in <see cref="OUTLINETEXTMETRIC"/> are specified in logical units; that is,
    /// they depend on the current mapping mode of the specified display context.
    /// Note, <see cref="OUTLINETEXTMETRIC"/> is defined using the current pack setting.
    /// To avoid problems, make sure that the application is built using the platform default packing.
    /// For example, 32-bit Windows uses a default of 8-byte packing.
    /// For more information, see the MSDN topic "C-Compiler Packing Issues".
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct OUTLINETEXTMETRIC
    {
        /// <summary>
        /// The size, in bytes, of the <see cref="OUTLINETEXTMETRIC"/> structure.
        /// </summary>
        public UINT otmSize;

        /// <summary>
        /// A <see cref="TEXTMETRIC"/> structure containing further information about the font.
        /// </summary>
        public TEXTMETRIC otmTextMetrics;

        /// <summary>
        /// A value that causes the structure to be byte-aligned.
        /// </summary>
        public BYTE otmFiller;

        /// <summary>
        /// The <see cref="PANOSE"/> number for this font.
        /// </summary>
        public PANOSE otmPanoseNumber;

        /// <summary>
        /// The nature of the font pattern. This member can be a combination of the following bits.
        /// Bit Meaning
        /// 0   Italic
        /// 1   Underscore
        /// 2   Negative
        /// 3   Outline
        /// 4   Strikeout
        /// 5   Bold
        /// </summary>
        public UINT otmfsSelection;

        /// <summary>
        /// Indicates whether the font is licensed.
        /// Licensed fonts must not be modified or exchanged.
        /// If bit 1 is set, the font may not be embedded in a document.
        /// If bit 1 is clear, the font can be embedded.
        /// If bit 2 is set, the embedding is read-only.
        /// </summary>
        public UINT otmfsType;

        /// <summary>
        /// The slope of the cursor.
        /// This value is 1 if the slope is vertical. Applications can use this value and the value of the <see cref="otmsCharSlopeRun"/> member
        /// to create an italic cursor that has the same slope as the main italic angle (specified by the <see cref="otmItalicAngle"/> member).
        /// </summary>
        public int otmsCharSlopeRise;

        /// <summary>
        /// The slope of the cursor.
        /// This value is zero if the slope is vertical. Applications can use this value and the value of the <see cref="otmsCharSlopeRise"/> member
        /// to create an italic cursor that has the same slope as the main italic angle (specified by the <see cref="otmItalicAngle"/> member).
        /// </summary>
        public int otmsCharSlopeRun;

        /// <summary>
        /// The main italic angle of the font, in tenths of a degree counterclockwise from vertical.
        /// Regular (roman) fonts have a value of zero.
        /// Italic fonts typically have a negative italic angle (that is, they lean to the right).
        /// </summary>
        public int otmItalicAngle;

        /// <summary>
        /// The number of logical units defining the x- or y-dimension of the em square for this font.
        /// (The number of units in the x- and y-directions are always the same for an em square.)
        /// </summary>
        public UINT otmEMSquare;

        /// <summary>
        /// The maximum distance characters in this font extend above the base line.
        /// This is the typographic ascent for the font.
        /// </summary>
        public int otmAscent;

        /// <summary>
        /// The maximum distance characters in this font extend below the base line. This is the typographic descent for the font.
        /// </summary>
        public int otmDescent;

        /// <summary>
        /// The typographic line spacing.
        /// </summary>
        public UINT otmLineGap;

        /// <summary>
        /// Not supported.
        /// </summary>
        public UINT otmsCapEmHeight;

        /// <summary>
        /// Not supported.
        /// </summary>
        public UINT otmsXHeight;

        /// <summary>
        /// The bounding box for the font.
        /// </summary>
        public RECT otmrcFontBox;

        /// <summary>
        /// The maximum distance characters in this font extend above the base line for the Macintosh computer.
        /// </summary>
        public int otmMacAscent;

        /// <summary>
        /// The maximum distance characters in this font extend below the base line for the Macintosh computer.
        /// </summary>
        public int otmMacDescent;

        /// <summary>
        /// The line-spacing information for the Macintosh computer.
        /// </summary>
        public UINT otmMacLineGap;

        /// <summary>
        /// The smallest recommended size for this font, in pixels per em-square.
        /// </summary>
        public UINT otmusMinimumPPEM;

        /// <summary>
        /// The recommended horizontal and vertical size for subscripts in this font.
        /// </summary>
        public POINT otmptSubscriptSize;

        /// <summary>
        /// The recommended horizontal and vertical offset for subscripts in this font.
        /// The subscript offset is measured from the character origin to the origin of the subscript character.
        /// </summary>
        public POINT otmptSubscriptOffset;

        /// <summary>
        /// The recommended horizontal and vertical size for superscripts in this font.
        /// </summary>
        public POINT otmptSuperscriptSize;

        /// <summary>
        /// The recommended horizontal and vertical offset for superscripts in this font.
        /// The superscript offset is measured from the character base line to the base line of the superscript character.
        /// </summary>
        public POINT otmptSuperscriptOffset;

        /// <summary>
        /// The width of the strikeout stroke for this font. Typically, this is the width of the em dash for the font.
        /// </summary>
        public UINT otmsStrikeoutSize;

        /// <summary>
        /// The position of the strikeout stroke relative to the base line for this font.
        /// Positive values are above the base line and negative values are below.
        /// </summary>
        public int otmsStrikeoutPosition;

        /// <summary>
        /// The thickness of the underscore character for this font.
        /// </summary>
        public int otmsUnderscoreSize;

        /// <summary>
        /// The position of the underscore character for this font.
        /// </summary>
        public int otmsUnderscorePosition;

        /// <summary>
        /// The offset from the beginning of the structure to a string specifying the family name for the font.
        /// </summary>
        public string otmpFamilyName;

        /// <summary>
        /// The offset from the beginning of the structure to a string specifying the typeface name for the font.
        /// (This typeface name corresponds to the name specified in the <see cref="LOGFONT"/> structure.)
        /// </summary>
        public string otmpFaceName;

        /// <summary>
        /// The offset from the beginning of the structure to a string specifying the style name for the font.
        /// </summary>
        public string otmpStyleName;

        /// <summary>
        /// The offset from the beginning of the structure to a string specifying the full name for the font.
        /// This name is unique for the font and often contains a version number or other identifying information.
        /// </summary>
        public string otmpFullName;
    }
}
