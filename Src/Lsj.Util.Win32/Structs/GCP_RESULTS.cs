using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.CharacterTypeFlags;
using static Lsj.Util.Win32.Enums.ExtTextOutFlags;
using static Lsj.Util.Win32.Enums.GCPCLASS;
using static Lsj.Util.Win32.Enums.GetCharacterPlacementFlags;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="GCP_RESULTS"/> structure contains information about characters in a string.
    /// This structure receives the results of the <see cref="GetCharacterPlacement"/> function.
    /// For some languages, the first element in the arrays may contain more, language-dependent information.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-gcp_resultsw"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Whether the <see cref="lpGlyphs"/>, <see cref="lpOutString"/>, or neither is required
    /// depends on the results of the <see cref="GetFontLanguageInfo"/> call.
    /// In the case of a font for a language such as English, in which none of the <see cref="GCP_DBCS"/>,
    /// <see cref="GCP_REORDER"/>, <see cref="GCP_GLYPHSHAPE"/>, <see cref="GCP_LIGATE"/>, <see cref="GCP_DIACRITIC"/>,
    /// or <see cref="GCP_KASHIDA"/> flags are returned, neither of the arrays is required for proper operation.
    /// (Though not required, they can still be used. If the <see cref="lpOutString"/> array is used,
    /// it will be exactly the same as the lpInputString passed to <see cref="GetCharacterPlacement"/>.)
    /// Note, however, that if <see cref="GCP_MAXEXTENT"/> is used, then <see cref="lpOutString"/> will contain
    /// the truncated string if it is used, NOT an exact copy of the original.
    /// In the case of fonts for languages such as Hebrew, which DO have reordering
    /// but do not typically have extra glyph shapes, <see cref="lpOutString"/> should be used.
    /// This will give the string on the screen-readable order.
    /// However, the <see cref="lpGlyphs"/> array is not typically needed.
    /// (Hebrew can have extra glyphs, if the font is a TrueType/Open font.)
    /// In the case of languages such as Thai or Arabic, in which <see cref="GetFontLanguageInfo"/>
    /// returns the <see cref="GCP_GLYPHSHAPE"/> flag, the <see cref="lpOutString"/> will give the display-readable order
    /// of the string passed to <see cref="GetCharacterPlacement"/>, but the values will still be the unshaped characters.
    /// For proper display, the <see cref="lpGlyphs"/> array must be used.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct GCP_RESULTS
    {
        /// <summary>
        /// The size, in bytes, of the structure.
        /// </summary>
        public DWORD lStructSize;

        /// <summary>
        /// A pointer to the buffer that receives the output string or is <see cref="NULL"/> if the output string is not needed. 
        /// The output string is a version of the original string that is in the order that will be displayed on a specified device.
        /// Typically the output string is identical to the original string, but may be different
        /// if the string needs reordering and the <see cref="GCP_REORDER"/> flag is set
        /// or if the original string exceeds the maximum extent and the <see cref="GCP_MAXEXTENT"/> flag is set.
        /// </summary>
        public IntPtr lpOutString;

        /// <summary>
        /// A pointer to the array that receives ordering indexes or is <see cref="NULL"/> if the ordering indexes are not needed.
        /// However, its meaning depends on the other elements of <see cref="GCP_RESULTS"/>.
        /// If glyph indexes are to be returned, the indexes are for the <see cref="lpGlyphs"/> array;
        /// if glyphs indexes are not returned and <see cref="lpOrder"/> is requested, the indexes are for <see cref="lpOutString"/>.
        /// For example, in the latter case the value of lpOrder[i] is the position of lpString[i] in the output string lpOutString.
        /// This is typically used when <see cref="GetFontLanguageInfo"/> returns the <see cref="GCP_REORDER"/> flag,
        /// which indicates that the original string needs reordering.
        /// For example, in Hebrew, in which the text runs from right to left,
        /// the <see cref="lpOrder"/> array gives the exact locations of each element in the original string.
        /// </summary>
        public IntPtr lpOrder;

        /// <summary>
        /// A pointer to the array that receives the distances between adjacent character cells
        /// or is <see cref="NULL"/> if these distances are not needed.
        /// If glyph rendering is done, the distances are for the glyphs not the characters,
        /// so the resulting array can be used with the <see cref="ExtTextOut"/> function.
        /// The distances in this array are in display order.
        /// To find the distance for the ith character in the original string, use the <see cref="lpOrder"/> array as follows:
        /// <code>
        /// width = lpDx[lpOrder[i]];
        /// </code>
        /// </summary>
        public IntPtr lpDx;

        /// <summary>
        /// A pointer to the array that receives the caret position values or is <see cref="NULL"/> if caret positions are not needed.
        /// Each value specifies the caret position immediately before the corresponding character.
        /// In some languages the position of the caret for each character may not be immediately to the left of the character.
        /// For example, in Hebrew, in which the text runs from right to left, the caret position is to the right of the character.
        /// If glyph ordering is done, <see cref="lpCaretPos"/> matches the original string, not the output string.
        /// This means that some adjacent values may be the same.
        /// The values in this array are in input order.
        /// To find the caret position value for the ith character in the original string, use the array as follows:
        /// <code>
        /// position = lpCaretPos[i];
        /// </code>
        /// </summary>
        public IntPtr lpCaretPos;

        /// <summary>
        /// A pointer to the array that contains and/or receives character classifications.
        /// The values indicate how to lay out characters in the string and are similar (but not identical)
        /// to the <see cref="CT_CTYPE2"/> values returned by the <see cref="GetStringTypeEx"/> function.
        /// Each element of the array can be set to zero or one of the following values.
        /// <see cref="GCPCLASS_ARABIC"/>: Arabic character.
        /// <see cref="GCPCLASS_HEBREW"/>: Hebrew character.
        /// <see cref="GCPCLASS_LATIN"/>: Character from a Latin or other single-byte character set for a left-to-right language.
        /// <see cref="GCPCLASS_LATINNUMBER"/>: Digit from a Latin or other single-byte character set for a left-to-right language.
        /// <see cref="GCPCLASS_LOCALNUMBER"/>: Digit from the character set associated with the current font.
        /// In addition, the following can be used when supplying values in the <see cref="lpClass"/> array with the <see cref="GCP_CLASSIN"/> flag.
        /// <see cref="GCPCLASS_LATINNUMERICSEPARATOR"/>:
        /// Input only. Character used to separate Latin digits, such as a comma or decimal point.
        /// <see cref="GCPCLASS_LATINNUMERICTERMINATOR"/>:
        /// Input only. Character used to terminate Latin digits, such as a plus or minus sign.
        /// <see cref="GCPCLASS_NEUTRAL"/>:
        /// Input only. Character has no specific classification.
        /// <see cref="GCPCLASS_NUMERICSEPARATOR"/>:
        /// Input only. Character used to separate digits, such as a comma or decimal point.
        /// For languages that use the <see cref="GCP_REORDER"/> flag,
        /// the following values can also be used with the <see cref="GCP_CLASSIN"/> flag.
        /// Unlike the preceding values, which can be used anywhere in the <see cref="lpClass"/> array,
        /// all of the following values are used only in the first location in the array.
        /// All combine with other classifications.
        /// Note that <see cref="GCPCLASS_PREBOUNDLTR"/> and <see cref="GCPCLASS_PREBOUNDRTL"/> are mutually exclusive,
        /// as are <see cref="GCPCLASS_POSTBOUNDLTR"/> and <see cref="GCPCLASS_POSTBOUNDRTL"/>.
        /// <see cref="GCPCLASS_PREBOUNDLTR"/>:
        /// Set <code>lpClass[0]</code> to <see cref="GCPCLASS_PREBOUNDLTR"/> to bind the string to left-to-right reading order before the string.
        /// <see cref="GCPCLASS_PREBOUNDRTL"/>:
        /// Set <code>lpClass[0]</code> to <see cref="GCPCLASS_PREBOUNDRTL"/> to bind the string to right-to-left reading order before the string.
        /// <see cref="GCPCLASS_POSTBOUNDLTR"/>:
        /// Set <code>lpClass[0]</code> to <see cref="GCPCLASS_POSTBOUNDLTR"/> to bind the string to left-to-right reading order after the string.
        /// <see cref="GCPCLASS_POSTBOUNDRTL"/>:
        /// Set <code>lpClass[0]</code> to <see cref="GCPCLASS_POSTBOUNDRTL"/> to bind the string to right-to-left reading order after the string.
        /// To force the layout of a character to be carried out in a specific way,
        /// preset the classification for the corresponding array element;
        /// the function leaves such preset classifications unchanged and computes classifications only
        /// for array elements that have been set to zero.
        /// Preset classifications are used only if the <see cref="GCP_CLASSIN"/> flag is set and the <see cref="lpClass"/> array is supplied.
        /// If <see cref="GetFontLanguageInfo"/> does not return <see cref="GCP_REORDER"/> for the current font,
        /// only the <see cref="GCPCLASS_LATIN"/> value is meaningful.
        /// </summary>
        public IntPtr lpClass;

        /// <summary>
        /// A pointer to the array that receives the values identifying the glyphs used for rendering the string
        /// or is <see cref="NULL"/> if glyph rendering is not needed.
        /// The number of glyphs in the array may be less than the number of characters in the original string
        /// if the string contains ligated glyphs.
        /// Also if reordering is required, the order of the glyphs may not be sequential.
        /// This array is useful if more than one operation is being done on a string
        /// which has any form of ligation, kerning or order-switching.
        /// Using the values in this array for subsequent operations saves the time otherwise required to generate the glyph indices each time.
        /// This array always contains glyph indices and the <see cref="ETO_GLYPH_INDEX"/> value must always be used
        /// when this array is used with the <see cref="ExtTextOut"/> function.
        /// When <see cref="GCP_LIGATE"/> is used, you can limit the number of characters that will be ligated together.
        /// (In Arabic for example, three-character ligations are common).
        /// This is done by setting the maximum required in <code>lpGcpResults->lpGlyphs[0]</code>.
        /// If no maximum is required, you should set this field to zero.
        /// For languages such as Arabic, where <see cref="GetFontLanguageInfo"/> returns the <see cref="GCP_GLYPHSHAPE"/> flag,
        /// the glyphs for a character will be different depending on whether the character is at the beginning, middle, or end of a word.
        /// Typically, the first character in the input string will also be the first character in a word,
        /// and the last character in the input string will be treated as the last character in a word.
        /// However, if the displayed string is a subset of the complete string,
        /// such as when displaying a section of scrolled text, this may not be true.
        /// In these cases, it is desirable to force the first or last characters to be shaped as not being initial or final forms.
        /// To do this, again, the first location in the <see cref="lpGlyphs"/> array is used
        /// by performing an OR operation of the ligation value above
        /// with the values <see cref="GCPGLYPH_LINKBEFORE"/> and/or <see cref="GCPGLYPH_LINKAFTER"/>.
        /// For example, a value of <code>GCPGLYPH_LINKBEFORE | 2</code> means that two-character ligatures are the maximum required,
        /// and the first character in the string should be treated as if it is in the middle of a word.
        /// </summary>
        public IntPtr lpGlyphs;

        /// <summary>
        /// On input, this member must be set to the size of the arrays pointed to by the array pointer members.
        /// On output, this is set to the number of glyphs filled in, in the output arrays.
        /// If glyph substitution is not required (that is, each input character maps to exactly one glyph),
        /// this member is the same as it is on input.
        /// </summary>
        public UINT nGlyphs;

        /// <summary>
        /// The number of characters that fit within the extents specified
        /// by the nMaxExtent parameter of the <see cref="GetCharacterPlacement"/> function.
        /// If the <see cref="GCP_MAXEXTENT"/> or <see cref="GCP_JUSTIFY"/> value is set,
        /// this value may be less than the number of characters in the original string.
        /// This member is set regardless of whether the <see cref="GCP_MAXEXTENT"/> or <see cref="GCP_JUSTIFY"/> value is specified.
        /// Unlike <see cref="nGlyphs"/>, which specifies the number of output glyphs,
        /// <see cref="nMaxFit"/> refers to the number of characters from the input string.
        /// For Latin SBCS languages, this will be the same.
        /// </summary>
        public int nMaxFit;
    }
}
