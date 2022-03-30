using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.COLORREF;
using static Lsj.Util.Win32.Enums.BackgroundModes;
using static Lsj.Util.Win32.Enums.ExtTextOutFlags;
using static Lsj.Util.Win32.Enums.GraphicsModes;
using static Lsj.Util.Win32.Enums.MappingModes;
using static Lsj.Util.Win32.Enums.TextAlignments;
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
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-exttextoutw"/>
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
        /// Specifies how to use the application-defined rectangle.
        /// This parameter can be one or more of the following values.
        /// <see cref="ETO_CLIPPED"/>, <see cref="ETO_GLYPH_INDEX"/>, <see cref="ETO_IGNORELANGUAGE"/>, <see cref="ETO_NUMERICSLATIN"/>,
        /// <see cref="ETO_NUMERICSLOCAL"/>, <see cref="ETO_OPAQUE"/>, <see cref="ETO_PDY"/>, <see cref="ETO_RTLREADING"/>
        /// The <see cref="ETO_GLYPH_INDEX"/> and <see cref="ETO_RTLREADING"/> values cannot be used together.
        /// Because <see cref="ETO_GLYPH_INDEX"/> implies that all language processing has been completed,
        /// the function ignores the <see cref="ETO_RTLREADING"/> flag if also specified.
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
        /// If the string is drawn, the return value is <see cref="TRUE"/>.
        /// However, if the ANSI version of <see cref="ExtTextOut"/> is called with <see cref="ETO_GLYPH_INDEX"/>,
        /// the function returns <see cref="TRUE"/> even though the function does nothing.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The current text-alignment settings for the specified device context determine how the reference point is used to position the text.
        /// The text-alignment settings are retrieved by calling the <see cref="GetTextAlign"/> function.
        /// The text-alignment settings are altered by calling the <see cref="SetTextAlign"/> function.
        /// You can use the following values for text alignment.
        /// Only one flag can be chosen from those that affect horizontal and vertical alignment.
        /// In addition, only one of the two flags that alter the current position can be chosen.
        /// <see cref="TA_BASELINE"/>, <see cref="TA_BOTTOM"/>, <see cref="TA_TOP"/>, <see cref="TA_CENTER"/>, <see cref="TA_LEFT"/>,
        /// <see cref="TA_RIGHT"/>, <see cref="TA_NOUPDATECP"/>, <see cref="TA_RTLREADING"/>, <see cref="TA_UPDATECP"/>
        /// If the <paramref name="lpDx"/> parameter is <see cref="IntPtr.Zero"/>,
        /// the <see cref="ExtTextOut"/> function uses the default spacing between characters.
        /// The character-cell origins and the contents of the array pointed to by the <paramref name="lpDx"/> parameter are specified in logical units.
        /// A character-cell origin is defined as the upper-left corner of the character cell.
        /// By default, the current position is not used or updated by this function.
        /// However, an application can call the <see cref="SetTextAlign"/> function with the fMode parameter set to <see cref="TA_UPDATECP"/>
        /// to permit the system to use and update the current position each time
        /// the application calls <see cref="ExtTextOut"/> for a specified device context.
        /// When this flag is set, the system ignores the X and Y parameters on subsequent <see cref="ExtTextOut"/> calls.
        /// For the ANSI version of <see cref="ExtTextOut"/>, the <paramref name="lpDx"/> array has the same number of INT values
        /// as there are bytes in <paramref name="lpString"/>.
        /// For DBCS characters, you can apportion the dx in the <paramref name="lpDx"/> entries between the lead byte and the trail byte,
        /// as long as the sum of the two bytes adds up to the desired dx.
        /// For DBCS characters with the Unicode version of <see cref="ExtTextOut"/>, each Unicode glyph gets a single pdx entry.
        /// Note, the alpDx values from <see cref="GetTextExtentExPoint"/> are not the same as
        /// the <paramref name="lpDx"/> values for <see cref="ExtTextOut"/>.
        /// To use the alpDx values in <paramref name="lpDx"/>, you must first process them.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ExtTextOutW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ExtTextOut([In] IntPtr hdc, [In] int x, [In] int y, [In] ExtTextOutFlags options,
            [In] in RECT lprect, [In] LPCWSTR lpString, [In] uint c, [In] IntPtr lpDx);

        /// <summary>
        /// <para>
        /// The <see cref="GetBkColor"/> function returns the current background color for the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getbkcolor"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to the device context whose background color is to be returned.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a <see cref="COLORREF"/> value for the current background color.
        /// If the function fails, the return value is <see cref="CLR_INVALID"/>.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetBkColor", ExactSpelling = true, SetLastError = true)]
        public static extern COLORREF GetBkColor([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="GetBkMode"/> function returns the current background mix mode for a specified device context.
        /// The background mix mode of a device context affects text, hatched brushes, and pen styles that are not solid lines.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getbkmode"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to the device context whose background mode is to be returned.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value specifies the current background mix mode, either <see cref="OPAQUE"/> or <see cref="TRANSPARENT"/>.
        /// If the function fails, the return value is zero.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetBkMode", ExactSpelling = true, SetLastError = true)]
        public static extern BackgroundModes GetBkMode([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="GetCharWidth"/> function retrieves the widths, in logical coordinates,
        /// of consecutive characters in a specified range from the current font.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getcharwidthw"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="iFirst">
        /// The first character in the group of consecutive characters.
        /// </param>
        /// <param name="iLast">
        /// The last character in the group of consecutive characters, which must not precede the specified first character.
        /// </param>
        /// <param name="lpBuffer">
        /// A pointer to a buffer that receives the character widths, in logical coordinates.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// GetCharWidth cannot be used on TrueType fonts.
        /// To retrieve character widths for TrueType fonts, use <see cref="GetCharABCWidths"/>.
        /// The range is inclusive; that is, the returned widths include the widths of the characters
        /// specified by the <paramref name="iFirst"/> and <paramref name="iLast"/> parameters.
        /// If a character does not exist in the current font, it is assigned the width of the default character.
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit versions of Windows." +
            "Applications should call the GetCharWidth32 function, which provides more accurate results.")]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCharWidthW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetCharWidth([In] HDC hdc, [In] UINT iFirst, [In] UINT iLast, [Out] out int lpBuffer);

        /// <summary>
        /// <para>
        /// The <see cref="GetTextAlign"/> function retrieves the text-alignment setting for the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-gettextalign"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the status of the text-alignment flags.
        /// For more information about the return value, see the Remarks section.
        /// The return value is a combination of the following values.
        /// <see cref="TA_BASELINE"/>, <see cref="TA_BOTTOM"/>, <see cref="TA_TOP"/>, <see cref="TA_CENTER"/>, <see cref="TA_LEFT"/>,
        /// <see cref="TA_RIGHT"/>, <see cref="TA_RTLREADING"/>, <see cref="TA_NOUPDATECP"/>, <see cref="TA_UPDATECP"/>
        /// When the current font has a vertical default base line (as with Kanji),
        /// the following values are used instead of <see cref="TA_BASELINE"/> and <see cref="TA_CENTER"/>.
        /// <see cref="VTA_BASELINE"/>, <see cref="VTA_CENTER"/>
        /// If the function fails, the return value is <see cref="GDI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// The bounding rectangle is a rectangle bounding all of the character cells in a string of text.
        /// Its dimensions can be obtained by calling the <see cref="GetTextExtentPoint32"/> function.
        /// The text-alignment flags determine how the <see cref="TextOut"/> and <see cref="ExtTextOut"/> functions align a string of text
        /// in relation to the string's reference point provided to <see cref="TextOut"/> or <see cref="ExtTextOut"/>.
        /// The text-alignment flags are not necessarily single bit flags and may be equal to zero.
        /// The flags must be examined in groups of related flags, as shown in the following list.
        /// <see cref="TA_LEFT"/>, <see cref="TA_RIGHT"/>, and <see cref="TA_CENTER"/>
        /// <see cref="TA_BOTTOM"/>, <see cref="TA_TOP"/>, and <see cref="TA_BASELINE"/>
        /// <see cref="TA_NOUPDATECP"/> and <see cref="TA_UPDATECP"/>
        /// If the current font has a vertical default base line, the related flags are as shown in the following list.
        /// <see cref="TA_LEFT"/>, <see cref="TA_RIGHT"/>, and <see cref="VTA_BASELINE"/>
        /// <see cref="TA_BOTTOM"/>, <see cref="TA_TOP"/>, and <see cref="VTA_CENTER"/>
        /// <see cref="TA_NOUPDATECP"/> and <see cref="TA_UPDATECP"/>
        /// To verify that a particular flag is set in the return value of this function:
        /// 1. Apply the bitwise OR operator to the flag and its related flags.
        /// 2. Apply the bitwise AND operator to the result and the return value.
        /// 3. Test for the equality of this result and the flag.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTextAlign", ExactSpelling = true, SetLastError = true)]
        public static extern TextAlignments GetTextAlign([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="GetTextCharacterExtra"/> function retrieves the current intercharacter spacing for the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-gettextcharacterextra"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to the device context.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the current intercharacter spacing, in logical coordinates.
        /// If the function fails, the return value is 0x8000000.
        /// </returns>
        /// <remarks>
        /// The intercharacter spacing defines the extra space, in logical units along the base line,
        /// that the <see cref="TextOut"/> or <see cref="ExtTextOut"/> functions add to each character as a line is written.
        /// The spacing is used to expand lines of text.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTextCharacterExtra", ExactSpelling = true, SetLastError = true)]
        public static extern int GetTextCharacterExtra([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="GetTextColor"/> function retrieves the current text color for the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-gettextcolor"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to the device context.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the current text color as a <see cref="COLORREF"/> value.
        /// If the function fails, the return value is <see cref="CLR_INVALID"/>.
        /// No extended error information is available.
        /// </returns>
        /// <remarks>
        /// The text color defines the foreground color of characters drawn by using the <see cref="TextOut"/> or <see cref="ExtTextOut"/> function.
        /// </remarks>
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
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-gettextextentexpointw"/>
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
        /// A pointer to an array of integers that receives partial string extents.
        /// Each element in the array gives the distance, in logical units, between the beginning of the string and one of the characters
        /// that fits in the space specified by the <paramref name="nMaxExtent"/> parameter.
        /// This array must have at least as many elements as characters specified by the <paramref name="cchString"/> parameter
        /// because the entire array is used internally.
        /// The function fills the array with valid extents for as many characters as are specified by the <paramref name="lpnFit"/> parameter.
        /// Any values in the rest of the array should be ignored.
        /// If <paramref name="lpnDx"/> is <see cref="NullRef{INT}"/>, the function does not compute partial string widths.
        /// For complex scripts, where a sequence of characters may be represented by any number of glyphs,
        /// the values in the alpDx array up to the number specified by the <paramref name="lpnFit"/> parameter match one-to-one with code points.
        /// Again, you should ignore the rest of the values in the <paramref name="lpnDx"/> array.
        /// </param>
        /// <param name="lpSize">
        /// A pointer to a <see cref="SIZE"/> structure that receives the dimensions of the string, in logical units.
        /// This parameter cannot be <see cref="NullRef{SIZE}"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// If both the <paramref name="lpnFit"/> and <paramref name="lpnDx"/> parameters are <see langword="null"/>,
        /// calling the <see cref="GetTextExtentExPoint"/> function is equivalent to calling the <see cref="GetTextExtentPoint"/> function.
        /// For the ANSI version of <see cref="GetTextExtentExPoint"/>, the <paramref name="lpnDx"/> array
        /// has the same number of <see cref="INT"/> values as there are bytes in <paramref name="lpszString"/>.
        /// The <see cref="INT"/> values that correspond to the two bytes of a DBCS character are each the extent of the entire composite character.
        /// Note, the <paramref name="lpnDx"/> values for <see cref="GetTextExtentExPoint"/> are
        /// not the same as the <paramref name="lpnDx"/> values for <see cref="ExtTextOut"/>.
        /// To use the <paramref name="lpnDx"/> values in <paramref name="lpnDx"/>, you must first process them.
        /// When this function returns the text extent, it assumes that the text is horizontal, that is, that the escapement is always 0.
        /// This is true for both the horizontal and vertical measurements of the text.
        /// Even if you use a font that specifies a nonzero escapement, this function doesn't use the angle while it computes the text extent.
        /// The app must convert it explicitly.
        /// However, when the graphics mode is set to <see cref="GM_ADVANCED"/> and the character orientation is 90 degrees from the print orientation,
        /// the values that this function return do not follow this rule.
        /// When the character orientation and the print orientation match for a given string,
        /// this function returns the dimensions of the string in the <see cref="SIZE"/> structure as { cx : 116, cy : 18 }.
        /// When the character orientation and the print orientation are 90 degrees apart for the same string,
        /// this function returns the dimensions of the string in the <see cref="SIZE"/> structure as { cx : 18, cy : 116 }.
        /// This function returns the extent of each successive character in a string.
        /// When these are rounded to logical units, you get different results than what is returned from the <see cref="GetCharWidth"/>,
        /// which returns the width of each individual character rounded to logical units.
        /// Note
        /// The wingdi.h header defines <see cref="GetTextExtentExPoint"/> as an alias which automatically selects
        /// the ANSI or Unicode version of this function based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral
        /// can lead to mismatches that result in compilation or runtime errors.
        /// For more information, see Conventions for Function Prototypes.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTextExtentExPointW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetTextExtentExPoint([In] HDC hdc, [MarshalAs(UnmanagedType.LPWStr)] string lpszString, [In] int cchString,
            [In] int nMaxExtent, [Out] out INT lpnFit, [MarshalAs(UnmanagedType.LPArray)][Out] INT[] lpnDx, [Out] out SIZE lpSize);

        /// <summary>
        /// <para>
        /// The <see cref="GetTextExtentPoint"/> function computes the width and height of the specified string of text.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-gettextextentpointw"/>
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
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="GetTextExtentPoint"/> function uses the currently selected font to compute the dimensions of the string.
        /// The width and height, in logical units, are computed without considering any clipping.
        /// Also, this function assumes that the text is horizontal, that is, that the escapement is always 0.
        /// This is true for both the horizontal and vertical measurements of the text. Even if using a font specifying a nonzero escapement,
        /// this function will not use the angle while computing the text extent.
        /// The application must convert it explicitly.
        /// Because some devices kern characters, the sum of the extents of the characters in a string may not be equal to the extent of the string.
        /// The calculated string width takes into account the intercharacter spacing set by the <see cref="SetTextCharacterExtra"/> function.
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit versions of Windows." +
            "Applications should call the GetTextExtentPoint32 function, which provides more accurate results.")]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTextExtentPointW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetTextExtentPoint([In] HDC hdc, [MarshalAs(UnmanagedType.LPWStr)] string lpString, [In] int c, [Out] out SIZE lpsz);

        /// <summary>
        /// <para>
        /// The <see cref="SetBkColor"/> function sets the current background color to the specified color value,
        /// or to the nearest physical color if the device cannot represent the specified color value.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setbkcolor"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="color">
        /// The new background color.
        /// To make a <see cref="COLORREF"/> value, use the <see cref="RGB"/> macro.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value specifies the previous background color as a <see cref="COLORREF"/> value.
        /// If the function fails, the return value is <see cref="CLR_INVALID"/>.
        /// </returns>
        /// <remarks>
        /// This function fills the gaps between styled lines drawn using a pen created by the <see cref="CreatePen"/> function;
        /// it does not fill the gaps between styled lines drawn using a pen created by the <see cref="ExtCreatePen"/> function.
        /// The <see cref="SetBkColor"/> function also sets the background colors for <see cref="TextOut"/> and <see cref="ExtTextOut"/>.
        /// If the background mode is <see cref="OPAQUE"/>, the background color is used to fill gaps between styled lines,
        /// gaps between hatched lines in brushes, and character cells.
        /// The background color is also used when converting bitmaps from color to monochrome and vice versa.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetBkColor", ExactSpelling = true, SetLastError = true)]
        public static extern COLORREF SetBkColor([In] HDC hdc, [In] COLORREF color);

        /// <summary>
        /// <para>
        /// The <see cref="SetBkMode"/> function sets the background mix mode of the specified device context.
        /// The background mix mode is used with text, hatched brushes, and pen styles that are not solid lines.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setbkmode"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="mode">
        /// The background mode.
        /// This parameter can be one of the following values.
        /// <see cref="OPAQUE"/>, <see cref="TRANSPARENT"/>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value specifies the previous background mode.
        /// If the function fails, the return value is zero.
        /// </returns>
        /// <remarks>
        /// The <see cref="SetBkMode"/> function affects the line styles for lines drawn using a pen created by the <see cref="CreatePen"/> function.
        /// <see cref="SetBkMode"/> does not affect lines drawn using a pen created by the <see cref="ExtCreatePen"/> function.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetBkMode", ExactSpelling = true, SetLastError = true)]
        public static extern BackgroundModes SetBkMode([In] HDC hdc, [In] BackgroundModes mode);

        /// <summary>
        /// <para>
        /// The <see cref="SetTextAlign"/> function sets the text-alignment flags for the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-settextalign"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="align">
        /// The text alignment by using a mask of the values in the following list.
        /// Only one flag can be chosen from those that affect horizontal and vertical alignment.
        /// In addition, only one of the two flags that alter the current position can be chosen.
        /// <see cref="TA_BASELINE"/>, <see cref="TA_BOTTOM"/>, <see cref="TA_TOP"/>, <see cref="TA_CENTER"/>,
        /// <see cref="TA_LEFT"/>, <see cref="TA_RIGHT"/>, <see cref="TA_NOUPDATECP"/>, <see cref="TA_RTLREADING"/>, <see cref="TA_UPDATECP"/>
        /// When the current font has a vertical default base line, as with Kanji,
        /// the following values must be used instead of <see cref="TA_BASELINE"/> and <see cref="TA_CENTER"/>.
        /// <see cref="VTA_BASELINE"/>, <see cref="VTA_CENTER"/>
        /// The default values are <see cref="TA_LEFT"/>, <see cref="TA_TOP"/>, and <see cref="TA_NOUPDATECP"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the previous text-alignment setting.
        /// If the function fails, the return value is <see cref="GDI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="TextOut"/> and <see cref="ExtTextOut"/> functions use the text-alignment flags
        /// to position a string of text on a display or other device.
        /// The flags specify the relationship between a reference point and a rectangle that bounds the text.
        /// The reference point is either the current position or a point passed to a text output function.
        /// The rectangle that bounds the text is formed by the character cells in the text string.
        /// The best way to get left-aligned text is to use either
        /// <code>
        /// SetTextAlign (hdc, GetTextAlign(hdc) &amp; (~TA_CENTER))
        /// </code>
        /// or
        /// <code>
        /// SetTextAlign (hdc,TA_LEFT | &lt;other flags&gt;)
        /// </code>
        /// You can also use <code>SetTextAlign(hdc, TA_LEFT)</code> for this purpose, but this loses any vertical or right-to-left settings.
        /// Note
        /// You should not use <see cref="SetTextAlign"/> with <see cref="TA_UPDATECP"/> when you are using <see cref="ScriptStringOut"/>,
        /// because selected text is not rendered correctly.
        /// If you must use this flag, you can unset and reset it as necessary to avoid the problem.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetTextAlign", ExactSpelling = true, SetLastError = true)]
        public static extern TextAlignments SetTextAlign([In] HDC hdc, [In] TextAlignments align);

        /// <summary>
        /// <para>
        /// The <see cref="SetTextColor"/> function sets the text color for the specified device context to the specified color.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-settextcolor"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="color">
        /// The color of the text.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a color reference for the previous text color as a <see cref="COLORREF"/> value.
        /// If the function fails, the return value is <see cref="CLR_INVALID"/>.
        /// </returns>
        /// <remarks>
        /// The text color is used to draw the face of each character written by the <see cref="TextOut"/> and <see cref="ExtTextOut"/> functions.
        /// The text color is also used in converting bitmaps from color to monochrome and vice versa.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetTextColor", ExactSpelling = true, SetLastError = true)]
        public static extern COLORREF SetTextColor([In] HDC hdc, [In] COLORREF color);

        /// <summary>
        /// The SetTextCharacterExtra function sets the intercharacter spacing.
        /// Intercharacter spacing is added to each character, including break characters, when the system writes a line of text.
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="extra">
        /// The amount of extra space, in logical units, to be added to each character.
        /// If the current mapping mode is not <see cref="MM_TEXT"/>, the nCharExtra parameter is transformed and rounded to the nearest pixel.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the previous intercharacter spacing.
        /// If the function fails, the return value is 0x80000000.
        /// </returns>
        /// <remarks>
        /// This function is supported mainly for compatibility with existing applications.
        /// New applications should generally avoid calling this function, because it is incompatible with complex scripts
        /// (scripts that require text shaping; Arabic script is an example of this).
        /// The recommended approach is that instead of calling this function and then <see cref="TextOut"/>,
        /// applications should call <see cref="ExtTextOut"/> and use its lpDx parameter to supply widths.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetTextCharacterExtra", ExactSpelling = true, SetLastError = true)]
        public static extern int SetTextCharacterExtra([In] HDC hdc, [In] int extra);

        /// <summary>
        /// <para>
        /// The <see cref="SetTextJustification"/> function specifies the amount of space the system should add to the break characters in a string of text.
        /// The space is added when an application calls the <see cref="TextOut"/> or <see cref="ExtTextOut"/> functions.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-settextjustification"/>
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
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The break character is usually the space character (ASCII 32), but it may be defined by a font as some other character.
        /// The <see cref="GetTextMetrics"/> function can be used to retrieve a font's break character.
        /// The <see cref="TextOut"/> function distributes the specified extra space evenly among the break characters in the line.
        /// The <see cref="GetTextExtentPoint32"/> function is always used with the <see cref="SetTextJustification"/> function.
        /// Sometimes the <see cref="GetTextExtentPoint32"/> function takes justification into account
        /// when computing the width of a specified line before justification, and sometimes it does not.
        /// For more details on this, see <see cref="GetTextExtentPoint32"/>.
        /// This width must be known before an appropriate nBreakExtra value can be computed.
        /// <see cref="SetTextJustification"/> can be used to justify a line that contains multiple strings in different fonts.
        /// In this case, each string must be justified separately.
        /// Because rounding errors can occur during justification, the system keeps a running error term that defines the current error value.
        /// When justifying a line that contains multiple runs, <see cref="GetTextExtentPoint"/> automatically uses this error term
        /// when it computes the extent of the next run, allowing <see cref="TextOut"/> to blend the error into the new run.
        /// After each line has been justified, this error term must be cleared to prevent it from being incorporated into the next line.
        /// The term can be cleared by calling <see cref="SetTextJustification"/> with nBreakExtra set to zero.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetTextJustification", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetTextJustification([In] HDC hdc, [In] int extra, [In] int count);

        /// <summary>
        /// <para>
        /// The <see cref="TextOut"/> function writes a character string at the specified location, using the currently selected font,
        /// background color, and text color.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-textoutw"/>
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
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The interpretation of the reference point depends on the current text-alignment mode.
        /// An application can retrieve this mode by calling the <see cref="GetTextAlign"/> function;
        /// an application can alter this mode by calling the <see cref="SetTextAlign"/> function.
        /// You can use the following values for text alignment.
        /// Only one flag can be chosen from those that affect horizontal and vertical alignment.
        /// In addition, only one of the two flags that alter the current position can be chosen.
        /// <see cref="TA_BASELINE"/>: The reference point will be on the base line of the text.
        /// <see cref="TA_BOTTOM"/>: The reference point will be on the bottom edge of the bounding rectangle.
        /// <see cref="TA_TOP"/>: The reference point will be on the top edge of the bounding rectangle.
        /// <see cref="TA_CENTER"/>: The reference point will be aligned horizontally with the center of the bounding rectangle.
        /// <see cref="TA_LEFT"/>: The reference point will be on the left edge of the bounding rectangle.
        /// <see cref="TA_RIGHT"/>: The reference point will be on the right edge of the bounding rectangle.
        /// <see cref="TA_NOUPDATECP"/>:
        /// The current position is not updated after each text output call.
        /// The reference point is passed to the text output function.
        /// <see cref="TA_RTLREADING"/>:
        /// Middle East language edition of Windows: The text is laid out in right to left reading order, as opposed to the default left to right order.
        /// This applies only when the font selected into the device context is either Hebrew or Arabic.
        /// <see cref="TA_UPDATECP"/>: The current position is updated after each text output call. The current position is used as the reference point.
        /// By default, the current position is not used or updated by this function.
        /// However, an application can call the <see cref="SetTextAlign"/> function with the fMode parameter set to <see cref="TA_UPDATECP"/>
        /// to permit the system to use and update the current position each time the application calls <see cref="TextOut"/> for a specified device context.
        /// When this flag is set, the system ignores the <paramref name="x"/> and nYStart parameters on subsequent <see cref="TextOut"/> calls.
        /// When the <see cref="TextOut"/> function is placed inside a path bracket, the system generates a path for the TrueType text
        /// that includes each character plus its character box.
        /// The region generated is the character box minus the text, rather than the text itself.
        /// You can obtain the region enclosed by the outline of the TrueType text by setting the background mode to transparent
        /// before placing the <see cref="TextOut"/> function in the path bracket.
        /// Following is sample code that demonstrates this procedure.
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "TextOutW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL TextOut([In] HDC hdc, [In] int x, [In] int y, [MarshalAs(UnmanagedType.LPWStr)][In] string lpString, [In] int c);
    }
}
