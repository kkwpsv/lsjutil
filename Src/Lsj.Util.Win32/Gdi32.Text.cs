using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.COLORREF;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.CharacterSets;
using static Lsj.Util.Win32.Enums.ExtTextOutOptions;
using static Lsj.Util.Win32.Enums.GraphicsModes;
using static Lsj.Util.Win32.Enums.MappingModes;
using static Lsj.Util.Win32.Enums.TextAlignments;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32
{
    public partial class Gdi32
    {
        /// <summary>
        /// <para>
        /// The <see cref="ExtTextOut"/> function draws text using the currently selected font, background color, and text color.
        /// You can optionally provide dimensions to be used for clipping, opaquing, or both.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-exttextoutw"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="x">
        /// The x-coordinate, in logical coordinates, of the reference point used to position the string.
        /// </param>
        /// <param name="y">
        /// The y-coordinate, in logical coordinates, of the reference point used to position the string.
        /// </param>
        /// <param name="options">
        /// <para>
        /// Specifies how to use the application-defined rectangle. This parameter can be one or more of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ETO_CLIPPED"/>
        /// </term>
        /// <term>
        /// The text will be clipped to the rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ETO_GLYPH_INDEX"/>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpString"/> array refers to an array returned from <see cref="GetCharacterPlacement"/>
        /// and should be parsed directly by GDI as no further language-specific processing is required.
        /// Glyph indexing only applies to TrueType fonts, but the flag can be used for bitmap and vector fonts to indicate
        /// that no further language processing is necessary and GDI should process the string directly.
        /// Note that all glyph indexes are 16-bit values even though the string is assumed to be an array of 8-bit values for raster fonts.
        /// </para>
        /// <para>
        /// For <see cref="ExtTextOut"/>, the glyph indexes are saved to a metafile.
        /// However, to display the correct characters the metafile must be played back using the same font.
        /// For ExtTextOutA, the glyph indexes are not saved.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ETO_IGNORELANGUAGE"/>
        /// </term>
        /// <term>
        /// Reserved for system use.
        /// If an application sets this flag, it loses international scripting support and in some cases it may display no text at all.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ETO_NUMERICSLATIN"/>
        /// </term>
        /// <term>
        /// To display numbers, use European digits.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ETO_NUMERICSLOCAL"/>
        /// </term>
        /// <term>
        /// To display numbers, use digits appropriate to the locale.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ETO_OPAQUE"/>
        /// </term>
        /// <term>
        /// The current background color should be used to fill the rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ETO_PDY"/>
        /// </term>
        /// <term>
        /// When this is set, the array pointed to by <paramref name="lpDx"/> contains pairs of values.
        /// The first value of each pair is, as usual, the distance between origins of adjacent character cells,
        /// but the second value is the displacement along the vertical direction of the font.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ETO_RTLREADING"/>
        /// </term>
        /// <term>
        /// Middle East language edition of Windows:
        /// If this value is specified and a Hebrew or Arabic font is selected into the device context,
        /// the string is output using right-to-left reading order.
        /// If this value is not specified, the string is output in left-to-right order.
        /// The same effect can be achieved by setting the <see cref="TA_RTLREADING"/> value in <see cref="SetTextAlign"/>.
        /// This value is preserved for backward compatibility.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The <see cref="ETO_GLYPH_INDEX"/> and <see cref="ETO_RTLREADING"/> values cannot be used together.
        /// Because <see cref="ETO_GLYPH_INDEX"/> implies that all language processing has been completed,
        /// the function ignores the <see cref="ETO_RTLREADING"/> flag if also specified.
        /// </para>
        /// </param>
        /// <param name="lprect">
        /// A pointer to an optional <see cref="RECT"/> structure that specifies the dimensions, in logical coordinates,
        /// of a rectangle that is used for clipping, opaquing, or both.
        /// </param>
        /// <param name="lpString">
        /// A pointer to a string that specifies the text to be drawn
        /// The string does not need to be zero-terminated, since <paramref name="c"/> specifies the length of the string.
        /// </param>
        /// <param name="c">
        /// The length of the string pointed to by <paramref name="lpString"/>.
        /// This value may not exceed 8192.
        /// </param>
        /// <param name="lpDx">
        /// A pointer to an optional array of values that indicate the distance between origins of adjacent character cells.
        /// For example, lpDx[i] logical units separate the origins of character cell i and character cell i + 1.
        /// </param>
        /// <returns>
        /// <para>
        /// If the string is drawn, the return value is nonzero.
        /// However, if the ANSI version of <see cref="ExtTextOut"/> is called with <see cref="ETO_GLYPH_INDEX"/>,
        /// the function returns <see cref="TRUE"/> even though the function does nothing.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The current text-alignment settings for the specified device context determine how the reference point is used to position the text.
        /// The text-alignment settings are retrieved by calling the <see cref="GetTextAlign"/> function.
        /// The text-alignment settings are altered by calling the <see cref="SetTextAlign"/> function.
        /// You can use the following values for text alignment.
        /// Only one flag can be chosen from those that affect horizontal and vertical alignment.
        /// In addition, only one of the two flags that alter the current position can be chosen.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Term
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="TA_BASELINE"/>
        /// </term>
        /// <term>
        /// The reference point will be on the base line of the text.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TA_BOTTOM"/>
        /// </term>
        /// <term>
        /// The reference point will be on the bottom edge of the bounding rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TA_TOP"/>
        /// </term>
        /// <term>
        /// The reference point will be on the top edge of the bounding rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TA_CENTER"/>
        /// </term>
        /// <term>
        /// The reference point will be aligned horizontally with the center of the bounding rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TA_LEFT"/>
        /// </term>
        /// <term>
        /// The reference point will be on the left edge of the bounding rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TA_RIGHT"/>
        /// </term>
        /// <term>
        /// The reference point will be on the right edge of the bounding rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TA_NOUPDATECP"/>
        /// </term>
        /// <term>
        /// The current position is not updated after each text output call.
        /// The reference point is passed to the text output function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TA_RTLREADING"/>
        /// </term>
        /// <term>
        /// Middle East language edition of Windows:
        /// The text is laid out in right to left reading order, as opposed to the default left to right order.
        /// This applies only when the font selected into the device context is either Hebrew or Arabic.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TA_UPDATECP"/>
        /// </term>
        /// <term>
        /// The current position is updated after each text output call. The current position is used as the reference point.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If the <paramref name="lpDx"/> parameter is <see cref="NULL"/>,
        /// the <see cref="ExtTextOut"/> function uses the default spacing between characters.
        /// The character-cell origins and the contents of the array pointed to by the <paramref name="lpDx"/> parameter are specified in logical units.
        /// A character-cell origin is defined as the upper-left corner of the character cell.
        /// </para>
        /// <para>
        /// By default, the current position is not used or updated by this function.
        /// However, an application can call the <see cref="SetTextAlign"/> function with the fMode parameter set to <see cref="TA_UPDATECP"/>
        /// to permit the system to use and update the current position each time the application calls <see cref="ExtTextOut"/> for a specified device context.
        /// When this flag is set, the system ignores the <paramref name="x"/> and <paramref name="y"/> parameters on subsequent <see cref="ExtTextOut"/> calls.
        /// </para>
        /// <para>
        /// For the ANSI version of <see cref="ExtTextOut"/>, the <paramref name="lpDx"/> array
        /// has the same number of <see cref="INT"/> values as there are bytes in <paramref name="lpString"/>.
        /// For DBCS characters, you can apportion the dx in the <paramref name="lpDx"/> entries between the lead byte and the trail byte,
        /// as long as the sum of the two bytes adds up to the desired dx.
        /// For DBCS characters with the Unicode version of <see cref="ExtTextOut"/>, each Unicode glyph gets a single <paramref name="lpDx"/> entry.
        /// </para>
        /// <para>
        /// Note, the alpDx values from <see cref="GetTextExtentExPoint"/> are not
        /// the same as the <paramref name="lpDx"/> values for <see cref="ExtTextOut"/>.
        /// To use the alpDx values in <paramref name="lpDx"/>, you must first process them.
        /// </para>
        /// <para>
        /// <see cref="ExtTextOut"/> will use Uniscribe when necessary resulting in font fallback.
        /// The <see cref="ETO_IGNORELANGUAGE"/> flag will inhibit this behavior and should not be passed.
        /// </para>
        /// <para>
        /// Additionally, <see cref="ExtTextOut"/> will perform internal batching of calls before transitioning to kernel mode,
        /// mitigating some of the performance concerns when weighing usage of <see cref="PolyTextOut"/> versus <see cref="ExtTextOut"/>.
        /// </para>
        /// <para>
        /// Tip
        /// </para>
        /// <para>
        /// <see cref="ExtTextOut"/> is strongly recommended over <see cref="PolyTextOut"/> for modern development
        /// due to its ability to handle display of different languages.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ExtTextOutW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ExtTextOut([In] HDC hdc, [In] int x, [In] int y, [In] ExtTextOutOptions options,
            [In] in RECT lprect, [In] LPCWSTR lpString, [In] uint c, [In] in INT[] lpDx);

        /// <summary>
        /// <para>
        /// The <see cref="GetTextAlign"/> function retrieves the text-alignment setting for the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gettextalign"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the status of the text-alignment flags.
        /// For more information about the return value, see the Remarks section.
        /// The return value is a combination of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="TA_BASELINE"/>
        /// </term>
        /// <term>
        /// The reference point is on the base line of the text.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TA_BOTTOM"/>
        /// </term>
        /// <term>
        /// The reference point is on the bottom edge of the bounding rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TA_TOP"/>
        /// </term>
        /// <term>
        /// The reference point is on the top edge of the bounding rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TA_CENTER"/>
        /// </term>
        /// <term>
        /// The reference point is aligned horizontally with the center of the bounding rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TA_LEFT"/>
        /// </term>
        /// <term>
        /// The reference point is on the left edge of the bounding rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TA_RIGHT"/>
        /// </term>
        /// <term>
        /// The reference point is on the right edge of the bounding rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TA_RTLREADING"/>
        /// </term>
        /// <term>
        /// Middle East language edition of Windows:
        /// The text is laid out in right to left reading order, as opposed to the default left to right order.
        /// This only applies when the font selected into the device context is either Hebrew or Arabic.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TA_NOUPDATECP"/>
        /// </term>
        /// <term>
        /// The current position is not updated after each text output call.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TA_UPDATECP"/>
        /// </term>
        /// <term>
        /// The current position is updated after each text output call.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// When the current font has a vertical default base line (as with Kanji),
        /// the following values are used instead of <see cref="TA_BASELINE"/> and <see cref="TA_CENTER"/>.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="VTA_BASELINE"/>
        /// </term>
        /// <term>
        /// The reference point is on the base line of the text.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="VTA_CENTER"/>
        /// </term>
        /// <term>
        /// The reference point is aligned vertically with the center of the bounding rectangle.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="GDI_ERROR"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The bounding rectangle is a rectangle bounding all of the character cells in a string of text.
        /// Its dimensions can be obtained by calling the <see cref="GetTextExtentPoint32"/> function.
        /// </para>
        /// <para>
        /// The text-alignment flags determine how the <see cref="TextOut"/> and <see cref="ExtTextOut"/> functions
        /// align a string of text in relation to the string's reference point provided to <see cref="TextOut"/> or <see cref="ExtTextOut"/>.
        /// </para>
        /// <para>
        /// The text-alignment flags are not necessarily single bit flags and may be equal to zero.
        /// The flags must be examined in groups of related flags, as shown in the following list.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="TA_LEFT"/>, <see cref="TA_RIGHT"/>, and <see cref="TA_CENTER"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="TA_BOTTOM"/>, <see cref="TA_TOP"/>, and <see cref="TA_BASELINE"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="TA_NOUPDATECP"/> and <see cref="TA_UPDATECP"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If the current font has a vertical default base line, the related flags are as shown in the following list.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="TA_LEFT"/>, <see cref="TA_RIGHT"/>, and <see cref="VTA_BASELINE"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="TA_BOTTOM"/>, <see cref="TA_TOP"/>, and <see cref="VTA_CENTER"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="TA_NOUPDATECP"/> and <see cref="TA_UPDATECP"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// To verify that a particular flag is set in the return value of this function:
        /// </para>
        /// <para>
        /// <list type="number">
        /// <item>
        /// <description>
        /// Apply the bitwise OR operator to the flag and its related flags.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Apply the bitwise AND operator to the result and the return value.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Test for the equality of this result and the flag.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTextAlign", ExactSpelling = true, SetLastError = true)]
        public static extern TextAlignments GetTextAlign([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="GetTextCharacterExtra"/> function retrieves the current intercharacter spacing for the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gettextcharacterextra"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to the device context.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the current intercharacter spacing, in logical coordinates.
        /// </para>
        /// <para>
        /// If the function fails, the return value is 0x8000000.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The intercharacter spacing defines the extra space, in logical units along the base line,
        /// that the <see cref="TextOut"/> or <see cref="ExtTextOut"/> functions add to each character as a line is written.
        /// The spacing is used to expand lines of text.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTextCharacterExtra", ExactSpelling = true, SetLastError = true)]
        public static extern int GetTextCharacterExtra([In] HDC hdc);

        /// <summary>
        /// <para>
        /// Retrieves a character set identifier for the font that is currently selected into a specified device context.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// A call to this function is equivalent to a call to <see cref="GetTextCharsetInfo"/>
        /// passing <see cref="NULL"/> for the data buffer.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gettextcharset"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to a device context.
        /// The function obtains a character set identifier for the font that is selected into this device context.
        /// </param>
        /// <returns>
        /// <para>
        /// If successful, returns a value identifying the character set of the font
        /// that is currently selected into the specified device context.
        /// </para>
        /// <para>
        /// For a list of possible values, see <see cref="LOGFONT.lfCharSet"/> field of the <see cref="LOGFONT"/> structure.
        /// </para>
        /// <para>
        /// If the function fails, it returns <see cref="DEFAULT_CHARSET"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTextCharset", ExactSpelling = true)]
        public static extern int GetTextCharset([In] HDC hdc);

        /// <summary>
        /// <para>
        /// Retrieves information about the character set of the font that is currently selected into a specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gettextcharsetinfo"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to a device context.
        /// The function obtains information about the font that is selected into this device context.
        /// </param>
        /// <param name="lpSig">
        /// <para>
        /// Pointer to a <see cref="FONTSIGNATURE"/> data structure that receives font-signature information.
        /// </para>
        /// <para>
        /// If a TrueType font is currently selected into the device context,
        /// the <see cref="FONTSIGNATURE"/> structure receives information
        /// that identifies the code page and Unicode subranges for which the font provides glyphs.
        /// </para>
        /// <para>
        /// If a font other than TrueType is currently selected into the device context,
        /// the <see cref="FONTSIGNATURE"/> structure receives zeros.
        /// In this case, the application should use the <see cref="TranslateCharsetInfo"/> function
        /// to obtain generic font-signature information for the character set.
        /// </para>
        /// <para>
        /// The <paramref name="lpSig"/> parameter specifies <see cref="NULL"/>
        /// if the application does not require the <see cref="FONTSIGNATURE"/> information.
        /// In this case, the application can also call the <see cref="GetTextCharset"/> function,
        /// which is equivalent to calling <see cref="GetTextCharsetInfo"/> with <paramref name="lpSig"/> set to <see cref="NULL"/>.
        /// </para>
        /// </param>
        /// <param name="dwFlags">
        /// Reserved; must be set to 0.
        /// </param>
        /// <returns>
        /// <para>
        /// If successful, returns a value identifying the character set of the font
        /// currently selected into the specified device context.
        /// </para>
        /// <para>
        /// For a list of possible values, see <see cref="LOGFONT.lfCharSet"/> field of the <see cref="LOGFONT"/> structure.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="DEFAULT_CHARSET"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTextCharsetInfo", ExactSpelling = true)]
        public static extern int GetTextCharsetInfo([In] HDC hdc, [Out] out FONTSIGNATURE lpSig, [In] DWORD dwFlags);

        /// <summary>
        /// <para>
        /// The <see cref="GetTextColor"/> function retrieves the current text color for the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gettextcolor"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to the device context.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the current text color as a <see cref="COLORREF"/> value.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="CLR_INVALID"/>.
        /// No extended error information is available.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The text color defines the foreground color of characters drawn
        /// by using the <see cref="TextOut"/> or <see cref="ExtTextOut"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTextColor", ExactSpelling = true, SetLastError = true)]
        public static extern COLORREF GetTextColor([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="GetTextExtentExPoint"/> function retrieves the number of characters in a specified string
        /// that will fit within a specified space and fills an array with the text extent for each of those characters.
        /// (A text extent is the distance between the beginning of the space and a character that will fit in the space.)
        /// This information is useful for word-wrapping calculations.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gettextextentexpointw"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lpszString">
        /// A pointer to the null-terminated string for which extents are to be retrieved.
        /// </param>
        /// <param name="cchString">
        /// The number of characters in the string pointed to by the <paramref name="lpszString"/> parameter.
        /// For an ANSI call it specifies the string length in bytes and for a Unicode it specifies the string length in WORDs.
        /// Note that for the ANSI function, characters in SBCS code pages take one byte each,
        /// while most characters in DBCS code pages take two bytes; for the Unicode function,
        /// most currently defined Unicode characters (those in the Basic Multilingual Plane (BMP)) are one WORD while Unicode surrogates are two WORDs.
        /// </param>
        /// <param name="nMaxExtent">
        /// The maximum allowable width, in logical units, of the formatted string.
        /// </param>
        /// <param name="lpnFit">
        /// A pointer to an integer that receives a count of the maximum number of characters
        /// that will fit in the space specified by the <paramref name="nMaxExtent"/> parameter.
        /// When the <paramref name="lpnFit"/> parameter is <see cref="NullRef{INT}"/>, the <paramref name="nMaxExtent"/> parameter is ignored.
        /// </param>
        /// <param name="lpnDx">
        /// <para>
        /// A pointer to an array of integers that receives partial string extents.
        /// Each element in the array gives the distance, in logical units,
        /// between the beginning of the string and one of the characters that fits in the space
        /// specified by the <paramref name="nMaxExtent"/> parameter.
        /// This array must have at least as many elements as characters specified
        /// by the <paramref name="cchString"/> parameter because the entire array is used internally.
        /// The function fills the array with valid extents for as many characters as are specified by the <paramref name="lpnFit"/> parameter.
        /// Any values in the rest of the array should be ignored.
        /// If <paramref name="lpnDx"/> is <see langword="null"/>, the function does not compute partial string widths.
        /// </para>
        /// <para>
        /// For complex scripts, where a sequence of characters may be represented by any number of glyphs,
        /// the values in the <paramref name="lpnDx"/> array up to the number
        /// specified by the <paramref name="lpnFit"/> parameter match one-to-one with code points.
        /// Again, you should ignore the rest of the values in the <paramref name="lpnDx"/> array.
        /// </para>
        /// </param>
        /// <param name="lpSize">
        /// A pointer to a <see cref="SIZE"/> structure that receives the dimensions of the string, in logical units.
        /// This parameter cannot be <see cref="NullRef{SIZE}"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If both the <paramref name="lpnFit"/> and <paramref name="lpnDx"/> parameters are <see cref="NULL"/>,
        /// calling the <see cref="GetTextExtentExPoint"/> function is equivalent to calling the <see cref="GetTextExtentPoint"/> function.
        /// </para>
        /// <para>
        /// For the ANSI version of <see cref="GetTextExtentExPoint"/>, the <paramref name="lpnDx"/> array
        /// has the same number of <see cref="INT"/> values as there are bytes in <paramref name="lpszString"/>.
        /// The INT values that correspond to the two bytes of a DBCS character are each the extent of the entire composite character.
        /// </para>
        /// <para>
        /// Note, the <paramref name="lpnDx"/> values for <see cref="GetTextExtentExPoint"/>
        /// are not the same as the lpDx values for <see cref="ExtTextOut"/>.
        /// To use the <paramref name="lpnDx"/> values in lpDx, you must first process them.
        /// </para>
        /// <para>
        /// When this function returns the text extent, it assumes that the text is horizontal, that is, that the escapement is always 0.
        /// This is true for both the horizontal and vertical measurements of the text.
        /// Even if you use a font that specifies a nonzero escapement, this function doesn't use the angle while it computes the text extent.
        /// The app must convert it explicitly.
        /// However, when the graphics mode is set to <see cref="GM_ADVANCED"/> and the character orientation is 90 degrees from the print orientation,
        /// the values that this function return do not follow this rule.
        /// When the character orientation and the print orientation match for a given string,
        /// this function returns the dimensions of the string in the <see cref="SIZE"/> structure as { cx : 116, cy : 18 }.
        /// When the character orientation and the print orientation are 90 degrees apart for the same string,
        /// this function returns the dimensions of the string in the <see cref="SIZE"/> structure as { cx : 18, cy : 116 }.
        /// </para>
        /// <para>
        /// This function returns the extent of each successive character in a string.
        /// When these are rounded to logical units, you get different results than what is returned from the <see cref="GetCharWidth"/>,
        /// which returns the width of each individual character rounded to logical units.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTextExtentExPointW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetTextExtentExPoint([In] HDC hdc, [In] LPCWSTR lpszString, [In] int cchString,
            [In] int nMaxExtent, [Out] out INT lpnFit, [Out] INT[] lpnDx, [Out] out SIZE lpSize);

        /// <summary>
        /// <para>
        /// The <see cref="GetTextExtentExPointI"/> function retrieves the number of characters in a specified string
        /// that will fit within a specified space and fills an array with the text extent for each of those characters.
        /// (A text extent is the distance between the beginning of the space and a character that will fit in the space.)
        /// This information is useful for word-wrapping calculations.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gettextextentexpointi"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lpwszString">
        /// A pointer to an array of glyph indices for which extents are to be retrieved.
        /// </param>
        /// <param name="cwchString">
        /// The number of glyphs in the array pointed to by the pgiIn parameter.
        /// </param>
        /// <param name="nMaxExtent">
        /// The maximum allowable width, in logical units, of the formatted string.
        /// </param>
        /// <param name="lpnFit">
        /// A pointer to an integer that receives a count of the maximum number of characters
        /// that will fit in the space specified by the <paramref name="nMaxExtent"/> parameter.
        /// When the <paramref name="lpnFit"/> parameter is <see cref="NullRef{INT}"/>,
        /// the <paramref name="nMaxExtent"/> parameter is ignored.
        /// </param>
        /// <param name="lpnDx">
        /// A pointer to an array of integers that receives partial glyph extents.
        /// Each element in the array gives the distance, in logical units,
        /// between the beginning of the glyph indices array and one of the glyphs
        /// that fits in the space specified by the <paramref name="nMaxExtent"/> parameter.
        /// Although this array should have at least as many elements as glyph indices specified by the cgi parameter, 
        /// the function fills the array with extents only for as many glyph indices as
        /// are specified by the <paramref name="lpnFit"/> parameter.
        /// If <paramref name="lpnFit"/> is <see cref="NullRef{INT}"/>, the function does not compute partial string widths.
        /// </param>
        /// <param name="lpSize">
        /// A pointer to a <see cref="SIZE"/> structure that receives the dimensions of the glyph indices array, in logical units.
        /// This value cannot be <see cref="NullRef{SIZE}"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// If both the <paramref name="lpnFit"/> and <paramref name="lpnDx"/> parameters are <see cref="NULL"/>,
        /// calling the <see cref="GetTextExtentExPointI"/> function is equivalent to calling the <see cref="GetTextExtentPointI"/> function.
        /// </para>
        /// <para>
        /// When this function returns the text extent, it assumes that the text is horizontal, that is, that the escapement is always 0.
        /// This is true for both the horizontal and vertical measurements of the text.
        /// Even if you use a font that specifies a nonzero escapement, this function doesn't use the angle while it computes the text extent.
        /// The app must convert it explicitly.
        /// However, when the graphics mode is set to <see cref="GM_ADVANCED"/>
        /// and the character orientation is 90 degrees from the print orientation, the values that this function return do not follow this rule.
        /// When the character orientation and the print orientation match for a given string,
        /// this function returns the dimensions of the string in the <see cref="SIZE"/> structure as { cx : 116, cy : 18 }.
        /// When the character orientation and the print orientation are 90 degrees apart for the same string,
        /// this function returns the dimensions of the string in the <see cref="SIZE"/> structure as { cx : 18, cy : 116 }.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTextExtentExPointI", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetTextExtentExPointI([In] HDC hdc, [In] WORD[] lpwszString, [In] int cwchString,
            [In] int nMaxExtent, [Out] out INT lpnFit, [Out] INT[] lpnDx, [Out] out SIZE lpSize);

        /// <summary>
        /// <para>
        /// The <see cref="GetTextExtentPoint"/> function computes the width and height of the specified string of text.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gettextextentpointw"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lpString">
        /// A pointer to the string that specifies the text.
        /// The string does not need to be zero-terminated, since <paramref name="c"/> specifies the length of the string.
        /// </param>
        /// <param name="c">
        /// The length of the string pointed to by <paramref name="lpString"/>.
        /// </param>
        /// <param name="lpsz">
        /// A pointer to a <see cref="SIZE"/> structure that receives the dimensions of the string, in logical units.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="GetTextExtentPoint"/> function uses the currently selected font to compute the dimensions of the string.
        /// The width and height, in logical units, are computed without considering any clipping.
        /// Also, this function assumes that the text is horizontal, that is, that the escapement is always 0.
        /// This is true for both the horizontal and vertical measurements of the text.
        /// Even if using a font specifying a nonzero escapement, this function will not use the angle while computing the text extent.
        /// The application must convert it explicitly.
        /// </para>
        /// <para>
        /// Because some devices kern characters, the sum of the extents of the characters in a string
        /// may not be equal to the extent of the string.
        /// </para>
        /// <para>
        /// The calculated string width takes into account the intercharacter spacing set by the <see cref="SetTextCharacterExtra"/> function.
        /// </para>
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit versions of Windows." +
            "Applications should call the GetTextExtentPoint32 function, which provides more accurate results.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTextExtentPointW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetTextExtentPoint([In] HDC hdc, [In] LPCWSTR lpString, [In] int c, [Out] out SIZE lpsz);

        /// <summary>
        /// <para>
        /// The <see cref="GetTextExtentPoint32"/> function computes the width and height of the specified string of text.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gettextextentpoint32w"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lpString">
        /// A pointer to a buffer that specifies the text string.
        /// The string does not need to be null-terminated, because the c parameter specifies the length of the string.
        /// </param>
        /// <param name="c">
        /// The length of the string pointed to by <paramref name="lpString"/>.
        /// </param>
        /// <param name="psizl">
        /// A pointer to a <see cref="SIZE"/> structure that receives the dimensions of the string, in logical units.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="GetTextExtentPoint32"/> function uses the currently selected font to compute the dimensions of the string.
        /// The width and height, in logical units, are computed without considering any clipping.
        /// </para>
        /// <para>
        /// Because some devices kern characters, the sum of the extents of the characters in a string may not be equal to the extent of the string.
        /// </para>
        /// <para>
        /// The calculated string width takes into account the intercharacter spacing set by the <see cref="SetTextCharacterExtra"/> function
        /// and the justification set by <see cref="SetTextJustification"/>.
        /// This is true for both displaying on a screen and for printing.
        /// However, if lpDx is set in <see cref="ExtTextOut"/>,
        /// <see cref="GetTextExtentPoint32"/> does not take into account either intercharacter spacing or justification.
        /// In addition, for EMF, the print result always takes both intercharacter spacing and justification into account.
        /// </para>
        /// <para>
        /// When dealing with text displayed on a screen, the calculated string width takes into account the intercharacter spacing
        /// set by the <see cref="SetTextCharacterExtra"/> function and the justification set by <see cref="SetTextJustification"/>.
        /// However, if lpDx is set in <see cref="ExtTextOut"/>, <see cref="GetTextExtentPoint32"/> does not take into account
        /// either intercharacter spacing or justification.
        /// However, when printing with EMF:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The print result ignores intercharacter spacing, although <see cref="GetTextExtentPoint32"/> takes it into account.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The print result takes justification into account, although <see cref="GetTextExtentPoint32"/> ignores it.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// When this function returns the text extent, it assumes that the text is horizontal, that is, that the escapement is always 0.
        /// This is true for both the horizontal and vertical measurements of the text.
        /// Even if you use a font that specifies a nonzero escapement, this function doesn't use the angle while it computes the text extent.
        /// The app must convert it explicitly.
        /// However, when the graphics mode is set to <see cref="GM_ADVANCED"/>
        /// and the character orientation is 90 degrees from the print orientation, the values that this function return do not follow this rule.
        /// When the character orientation and the print orientation match for a given string,
        /// this function returns the dimensions of the string in the <see cref="SIZE"/> structure as { cx : 116, cy : 18 }.
        /// When the character orientation and the print orientation are 90 degrees apart for the same string,
        /// this function returns the dimensions of the string in the <see cref="SIZE"/> structure as { cx : 18, cy : 116 }.
        /// </para>
        /// <para>
        /// <see cref="GetTextExtentPoint32"/> doesn't consider "\n" (new line) or "\r\n" (carriage return and new line) characters when it computes the height of a text string.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTextExtentPoint32W", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetTextExtentPoint32([In] HDC hdc, [In] LPCWSTR lpString, [In] int c, [Out] out SIZE psizl);

        /// <summary>
        /// <para>
        /// The <see cref="GetTextExtentPointI"/> function computes the width and height of the specified array of glyph indices.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gettextextentpointi"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to the device context.
        /// </param>
        /// <param name="pgiIn">
        /// Pointer to array of glyph indices.
        /// </param>
        /// <param name="cgi">
        /// Specifies the number of glyph indices.
        /// </param>
        /// <param name="psize">
        /// Pointer to a <see cref="SIZE"/> structure that receives the dimensions of the string, in logical units.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="GetTextExtentPointI"/> function uses the currently selected font
        /// to compute the dimensions of the array of glyph indices.
        /// The width and height, in logical units, are computed without considering any clipping.
        /// </para>
        /// <para>
        /// When this function returns the text extent, it assumes that the text is horizontal, that is, that the escapement is always 0.
        /// This is true for both the horizontal and vertical measurements of the text.
        /// Even if you use a font that specifies a nonzero escapement, this function doesn't use the angle while it computes the text extent.
        /// The app must convert it explicitly.
        /// However, when the graphics mode is set to <see cref="GM_ADVANCED"/>
        /// and the character orientation is 90 degrees from the print orientation, the values that this function return do not follow this rule.
        /// When the character orientation and the print orientation match for a given string,
        /// this function returns the dimensions of the string in the <see cref="SIZE"/> structure as { cx : 116, cy : 18 }.
        /// When the character orientation and the print orientation are 90 degrees apart for the same string,
        /// this function returns the dimensions of the string in the <see cref="SIZE"/> structure as { cx : 18, cy : 116 }.
        /// </para>
        /// <para>
        /// Because some devices kern characters, the sum of the extents of the individual glyph indices
        /// may not be equal to the extent of the entire array of glyph indices.
        /// </para>
        /// <para>
        /// The calculated string width takes into account the intercharacter spacing set by the <see cref="SetTextCharacterExtra"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTextExtentPointI", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetTextExtentPointI([In] HDC hdc, [In] in WORD[] pgiIn, [In] int cgi, [Out] out SIZE psize);

        /// <summary>
        /// <para>
        /// The <see cref="PolyTextOut"/> function draws several strings
        /// using the font and text colors currently selected in the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-polytextoutw"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="ppt">
        /// A pointer to an array of <see cref="POLYTEXT"/> structures describing the strings to be drawn.
        /// The array contains one structure for each string to be drawn.
        /// </param>
        /// <param name="nstrings">
        /// The number of <see cref="POLYTEXT"/> structures in the pptxt array.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Each <see cref="POLYTEXT"/> structure contains the coordinates of a reference point
        /// that Windows uses to align the corresponding string of text.
        /// An application can specify how the reference point is used by calling the <see cref="SetTextAlign"/> function.
        /// An application can determine the current text-alignment setting for the specified device context
        /// by calling the <see cref="GetTextAlign"/> function.
        /// </para>
        /// <para>
        /// To draw a single string of text, the application should call the <see cref="ExtTextOut"/> function.
        /// </para>
        /// <para>
        /// <see cref="PolyTextOut"/> will not handle international scripting support automatically.
        /// To get international scripting support, use <see cref="ExtTextOut"/> instead.
        /// <see cref="ExtTextOut"/> will use Uniscribe when necessary resulting in font fallback.
        /// Additionally, <see cref="ExtTextOut"/> will perform internal batching of calls before transitioning to kernel mode,
        /// mitigating some of the performance concerns when weighing usage of <see cref="PolyTextOut"/> versus <see cref="ExtTextOut"/>.
        /// </para>
        /// <para>
        /// Tip
        /// </para>
        /// <para>
        /// <see cref="ExtTextOut"/> is strongly recommended over <see cref="PolyTextOut"/> for modern development
        /// due to its ability to handle display of different languages.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "PolyTextOutW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL PolyTextOut([In] HDC hdc, [In] in POLYTEXT[] ppt, [In] int nstrings);

        /// <summary>
        /// <para>
        /// The <see cref="SetTextAlign"/> function sets the text-alignment flags for the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-settextalign"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="align">
        /// <para>
        /// The text alignment by using a mask of the values in the following list.
        /// Only one flag can be chosen from those that affect horizontal and vertical alignment.
        /// In addition, only one of the two flags that alter the current position can be chosen.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="TA_BASELINE"/>
        /// </term>
        /// <term>
        /// The reference point will be on the base line of the text.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TA_BOTTOM"/>
        /// </term>
        /// <term>
        /// The reference point will be on the bottom edge of the bounding rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TA_TOP"/>
        /// </term>
        /// <term>
        /// The reference point will be on the top edge of the bounding rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TA_CENTER"/>
        /// </term>
        /// <term>
        /// The reference point will be aligned horizontally with the center of the bounding rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TA_LEFT"/>
        /// </term>
        /// <term>
        /// The reference point will be on the left edge of the bounding rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TA_RIGHT"/>
        /// </term>
        /// <term>
        /// The reference point will be on the right edge of the bounding rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TA_NOUPDATECP"/>
        /// </term>
        /// <term>
        /// The current position is not updated after each text output call. The reference point is passed to the text output function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TA_RTLREADING"/>
        /// </term>
        /// <term>
        /// Middle East language edition of Windows: The text is laid out in right to left reading order, 
        /// opposed to the default left to right order.
        /// This applies only when the font selected into the device context is either Hebrew or Arabic.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TA_UPDATECP"/>
        /// </term>
        /// <term>
        /// The current position is updated after each text output call. The current position is used as the reference point.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// When the current font has a vertical default base line, as with Kanji,
        /// the following values must be used instead of <see cref="TA_BASELINE"/> and <see cref="TA_CENTER"/>.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="VTA_BASELINE"/>
        /// </term>
        /// <term>
        /// The reference point will be on the base line of the text.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="VTA_CENTER"/>
        /// </term>
        /// <term>
        /// The reference point will be aligned vertically with the center of the bounding rectangle.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// </para>
        /// <para>
        /// The default values are <see cref="TA_LEFT"/>, <see cref="TA_TOP"/>, and <see cref="TA_NOUPDATECP"/>.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the previous text-alignment setting.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="GDI_ERROR"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="TextOut"/> and <see cref="ExtTextOut"/> functions use the text-alignment flags
        /// to position a string of text on a display or other device.
        /// The flags specify the relationship between a reference point and a rectangle that bounds the text.
        /// The reference point is either the current position or a point passed to a text output function.
        /// </para>
        /// <para>
        /// The rectangle that bounds the text is formed by the character cells in the text string.
        /// </para>
        /// <para>
        /// The best way to get left-aligned text is to use either
        /// </para>
        /// <code>
        /// SetTextAlign (hdc, GetTextAlign(hdc) &amp; (~TA_CENTER))
        /// </code>
        /// <para>
        /// or
        /// </para>
        /// <code>
        /// SetTextAlign (hdc,TA_LEFT | &lt;other flags&gt;)
        /// </code>
        /// <para>
        /// You can also use <c>SetTextAlign (hdc, TA_LEFT)</c> for this purpose, but this loses any vertical or right-to-left settings.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// You should not use <see cref="SetTextAlign"/> with <see cref="TA_UPDATECP"/>
        /// when you are using <see cref="ScriptStringOut"/>, because selected text is not rendered correctly.
        /// If you must use this flag, you can unset and reset it as necessary to avoid the problem.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetTextAlign", ExactSpelling = true, SetLastError = true)]
        public static extern TextAlignments SetTextAlign([In] HDC hdc, [In] TextAlignments align);

        /// <summary>
        /// The <see cref="SetTextCharacterExtra"/> function sets the intercharacter spacing.
        /// Intercharacter spacing is added to each character, including break characters, when the system writes a line of text.
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="extra">
        /// The amount of extra space, in logical units, to be added to each character.
        /// If the current mapping mode is not <see cref="MM_TEXT"/>,
        /// the <paramref name="extra"/> parameter is transformed and rounded to the nearest pixel.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the previous intercharacter spacing.
        /// </para>
        /// <para>
        /// If the function fails, the return value is 0x80000000.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function is supported mainly for compatibility with existing applications.
        /// New applications should generally avoid calling this function,
        /// because it is incompatible with complex scripts (scripts that require text shaping; Arabic script is an example of this).
        /// </para>
        /// <para>
        /// The recommended approach is that instead of calling this function and then <see cref="TextOut"/>,
        /// applications should call <see cref="ExtTextOut"/> and use its lpDx parameter to supply widths.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetTextCharacterExtra", ExactSpelling = true, SetLastError = true)]
        public static extern int SetTextCharacterExtra([In] HDC hdc, [In] int extra);

        /// <summary>
        /// <para>
        /// The <see cref="SetTextColor"/> function sets the text color for the specified device context to the specified color.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-settextcolor"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="color">
        /// The color of the text.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a color reference for the previous text color as a <see cref="COLORREF"/> value.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="CLR_INVALID"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The text color is used to draw the face of each character written by the <see cref="TextOut"/> and <see cref="ExtTextOut"/> functions.
        /// The text color is also used in converting bitmaps from color to monochrome and vice versa.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetTextColor", ExactSpelling = true, SetLastError = true)]
        public static extern COLORREF SetTextColor([In] HDC hdc, [In] COLORREF color);

        /// <summary>
        /// <para>
        /// The <see cref="SetTextJustification"/> function specifies the amount of space the system should add to the break characters in a string of text.
        /// The space is added when an application calls the <see cref="TextOut"/> or <see cref="ExtTextOut"/> functions.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-settextjustification"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="extra">
        /// The total extra space, in logical units, to be added to the line of text.
        /// If the current mapping mode is not <see cref="MM_TEXT"/>, the value identified by the nBreakExtra parameter
        /// is transformed and rounded to the nearest pixel.
        /// </param>
        /// <param name="count">
        /// The number of break characters in the line.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The break character is usually the space character (ASCII 32), but it may be defined by a font as some other character.
        /// The <see cref="GetTextMetrics"/> function can be used to retrieve a font's break character.
        /// </para>
        /// <para>
        /// The <see cref="TextOut"/> function distributes the specified extra space evenly among the break characters in the line.
        /// </para>
        /// <para>
        /// The <see cref="GetTextExtentPoint32"/> function is always used with the <see cref="SetTextJustification"/> function.
        /// Sometimes the <see cref="GetTextExtentPoint32"/> function takes justification into account
        /// when computing the width of a specified line before justification, and sometimes it does not.
        /// For more details on this, see <see cref="GetTextExtentPoint32"/>.
        /// This width must be known before an appropriate <paramref name="extra"/> value can be computed.
        /// </para>
        /// <para>
        /// <see cref="SetTextJustification"/> can be used to justify a line that contains multiple strings in different fonts.
        /// In this case, each string must be justified separately.
        /// </para>
        /// <para>
        /// Because rounding errors can occur during justification, the system keeps a running error term that defines the current error value.
        /// When justifying a line that contains multiple runs, <see cref="GetTextExtentPoint"/> automatically uses this error term
        /// when it computes the extent of the next run, allowing <see cref="TextOut"/> to blend the error into the new run.
        /// After each line has been justified, this error term must be cleared to prevent it from being incorporated into the next line.
        /// The term can be cleared by calling <see cref="SetTextJustification"/> with <paramref name="extra"/> set to zero.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetTextJustification", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetTextJustification([In] HDC hdc, [In] int extra, [In] int count);

        /// <summary>
        /// <para>
        /// The <see cref="TextOut"/> function writes a character string at the specified location, using the currently selected font,
        /// background color, and text color.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-textoutw"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="x">
        /// The x-coordinate, in logical coordinates, of the reference point that the system uses to align the string.
        /// </param>
        /// <param name="y">
        /// The y-coordinate, in logical coordinates, of the reference point that the system uses to align the string.
        /// </param>
        /// <param name="lpString">
        /// A pointer to the string to be drawn.
        /// The string does not need to be zero-terminated, because <paramref name="c"/> specifies the length of the string.
        /// </param>
        /// <param name="c">
        /// The length of the string pointed to by <paramref name="lpString"/>, in characters.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The interpretation of the reference point depends on the current text-alignment mode.
        /// An application can retrieve this mode by calling the <see cref="GetTextAlign"/> function;
        /// an application can alter this mode by calling the <see cref="SetTextAlign"/> function.
        /// You can use the following values for text alignment.
        /// Only one flag can be chosen from those that affect horizontal and vertical alignment.
        /// In addition, only one of the two flags that alter the current position can be chosen.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Term
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="TA_BASELINE"/>
        /// </term>
        /// <term>
        /// The reference point will be on the base line of the text.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TA_BOTTOM"/>
        /// </term>
        /// <term>
        /// The reference point will be on the bottom edge of the bounding rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TA_TOP"/>
        /// </term>
        /// <term>
        /// The reference point will be on the top edge of the bounding rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TA_CENTER"/>
        /// </term>
        /// <term>
        /// The reference point will be aligned horizontally with the center of the bounding rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TA_LEFT"/>
        /// </term>
        /// <term>
        /// The reference point will be on the left edge of the bounding rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TA_RIGHT"/>
        /// </term>
        /// <term>
        /// The reference point will be on the right edge of the bounding rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TA_NOUPDATECP"/>
        /// </term>
        /// <term>
        /// The current position is not updated after each text output call. The reference point is passed to the text output function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TA_RTLREADING"/>
        /// </term>
        /// <term>
        /// Middle East language edition of Windows: The text is laid out in right to left reading order,
        /// as opposed to the default left to right order.
        /// This applies only when the font selected into the device context is either Hebrew or Arabic.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TA_UPDATECP"/>
        /// </term>
        /// <term>
        /// The current position is updated after each text output call. The current position is used as the reference point.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// By default, the current position is not used or updated by this function.
        /// However, an application can call the <see cref="SetTextAlign"/> function
        /// with the fMode parameter set to <see cref="TA_UPDATECP"/> to permit the system to use and update the current position
        /// each time the application calls <see cref="TextOut"/> for a specified device context.
        /// When this flag is set, the system ignores the <paramref name="x"/> and <paramref name="y"/> parameters on subsequent <see cref="TextOut"/> calls.
        /// </para>
        /// <para>
        /// When the <see cref="TextOut"/> function is placed inside a path bracket,
        /// the system generates a path for the TrueType text that includes each character plus its character box.
        /// The region generated is the character box minus the text, rather than the text itself.
        /// You can obtain the region enclosed by the outline of the TrueType text
        /// by setting the background mode to transparent before placing the <see cref="TextOut"/> function in the path bracket.
        /// Following is sample code that demonstrates this procedure.
        /// </para>
        /// <code>
        /// // Obtain the window's client rectangle 
        /// GetClientRect(hwnd, &amp;r);
        /// 
        /// // THE FIX: by setting the background mode 
        /// // to transparent, the region is the text itself 
        /// // SetBkMode(hdc, TRANSPARENT); 
        /// 
        /// // Bracket begin a path 
        /// BeginPath(hdc);
        /// 
        /// // Send some text out into the world 
        /// TCHAR text[ ] = "Defenestration can be hazardous";
        /// TextOut(hdc,r.left,r.top,text, ARRAYSIZE(text));
        /// 
        /// // Bracket end a path 
        /// EndPath(hdc);
        /// 
        /// // Derive a region from that path 
        /// SelectClipPath(hdc, RGN_AND);
        /// 
        /// // This generates the same result as SelectClipPath() 
        /// // SelectClipRgn(hdc, PathToRegion(hdc)); 
        /// 
        /// // Fill the region with grayness 
        /// FillRect(hdc, &amp;r, GetStockObject(GRAY_BRUSH));
        /// </code>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "TextOutW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL TextOut([In] HDC hdc, [In] int x, [In] int y, [In] LPCWSTR lpString, [In] int c);

        /// <summary>
        /// <para>
        /// Translates character set information and sets all members of a destination structure to appropriate values.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-translatecharsetinfo"/>
        /// </para>
        /// </summary>
        /// <param name="lpSrc">
        /// Pointer to the <see cref="FONTSIGNATURE.fsCsb"/> member of a <see cref="FONTSIGNATURE"/> structure
        /// if <paramref name="dwFlags"/> is set to <see cref="TCI_SRCFONTSIG"/>.
        /// Otherwise, this parameter is set to a <see cref="DWORD"/> value indicating the source.
        /// </param>
        /// <param name="lpCs">
        /// Pointer to a <see cref="CHARSETINFO"/> structure that receives the translated character set information.
        /// </param>
        /// <param name="dwFlags">
        /// <para>
        /// Flags specifying how to perform the translation. This parameter can be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="TCI_SRCCHARSET"/>
        /// </term>
        /// <term>
        /// Source contains the character set value in the low word, and 0 in the high word.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TCI_SRCCODEPAGE"/>
        /// </term>
        /// <term>
        /// Source is a code page identifier in the low word and 0 in the high word.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TCI_SRCFONTSIG"/>
        /// </term>
        /// <term>
        /// <para>
        /// Source is the code page bitfield portion of a <see cref="FONTSIGNATURE"/> structure.
        /// On input this should have only one Windows code-page bit set,
        /// either for an ANSI code page value or for a common ANSI and OEM value
        /// (for OEM values, bits 32-63 must be clear).
        /// On output, this has only one bit set.
        /// </para>
        /// <para>
        /// If the <see cref="TCI_SRCFONTSIG"/> value is given,
        /// the <paramref name="lpSrc"/> parameter must be the address of the code-page bitfield.
        /// If any other TCI_ value is given, the <paramref name="lpSrc"/> parameter must be a value not an address.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TCI_SRCLOCALE"/>
        /// </term>
        /// <term>
        /// Windows 2000: Source is the locale identifier (LCID) or language identifier of the keyboard layout.
        /// If it is a language identifier, the value is in the low word.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// Returns a nonzero value if successful, or 0 otherwise.
        /// To get extended error information, the application can call <see cref="GetLastError"/>.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "TranslateCharsetInfo", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL TranslateCharsetInfo([In] ref DWORD lpSrc, [Out] out CHARSETINFO lpCs, [In] DWORD dwFlags);
    }
}
