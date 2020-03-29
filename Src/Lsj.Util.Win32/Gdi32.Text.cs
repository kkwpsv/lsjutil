using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;

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
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-exttextoutw
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ExtTextOutW", SetLastError = true)]
        public static extern BOOL ExtTextOut([In]IntPtr hdc, [In]int x, [In]int y, [In]ExtTextOutFlags options,
            [MarshalAs(UnmanagedType.LPStruct)][In]RECT lprect, [MarshalAs(UnmanagedType.LPWStr)]string lpString, [In]uint c, [In]IntPtr lpDx);

        /// <summary>
        /// <para>
        /// The <see cref="GetTabbedTextExtent"/> function computes the width and height of a character string.
        /// If the string contains one or more tab characters, the width of the string is based upon the specified tab stops.
        /// The <see cref="GetTabbedTextExtent"/> function uses the currently selected font to compute the dimensions of the string.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-gettabbedtextextentw
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lpString">
        /// A pointer to a character string.
        /// </param>
        /// <param name="chCount">
        /// The length of the text string.
        /// For the ANSI function it is a <see cref="BYTE"/> count and for the Unicode function it is a <see cref="WORD"/> count.
        /// Note that for the ANSI function, characters in SBCS code pages take one byte each, while most characters in DBCS code pages take two bytes;
        /// for the Unicode function, most currently defined Unicode characters (those in the Basic Multilingual Plane (BMP)) are one <see cref="WORD"/>
        /// while Unicode surrogates are two <see cref="WORD"/>s.
        /// </param>
        /// <param name="nTabPositions">
        /// The number of tab-stop positions in the array pointed to by the <paramref name="lpnTabStopPositions"/> parameter.
        /// </param>
        /// <param name="lpnTabStopPositions">
        /// A pointer to an array containing the tab-stop positions, in device units.
        /// The tab stops must be sorted in increasing order; the smallest x-value should be the first item in the array.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the dimensions of the string in logical units.
        /// The height is in the high-order word and the width is in the low-order word.
        /// If the function fails, the return value is 0.
        /// <see cref="GetTabbedTextExtent"/> will fail if <paramref name="hdc"/> is invalid and if <paramref name="nTabPositions"/> is less than 0.
        /// </returns>
        /// <remarks>
        /// The current clipping region does not affect the width and height returned by the <see cref="GetTabbedTextExtent"/> function.
        /// Because some devices do not place characters in regular cell arrays (that is, they kern the characters),
        /// the sum of the extents of the characters in a string may not be equal to the extent of the string.
        /// If the <paramref name="nTabPositions"/> parameter is zero and the <paramref name="lpnTabStopPositions"/> parameter is <see langword="null"/>,
        /// tabs are expanded to eight times the average character width.
        /// If <paramref name="nTabPositions"/> is 1, the tab stops are separated by the distance specified
        /// by the first value in the array to which <paramref name="lpnTabStopPositions"/> points.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTabbedTextExtentW", SetLastError = true)]
        public static extern DWORD GetTabbedTextExtent([In]HDC hdc, [MarshalAs(UnmanagedType.LPWStr)]string lpString, [In]int chCount,
            [In]int nTabPositions, [MarshalAs(UnmanagedType.LPArray)][In]INT[] lpnTabStopPositions);

        /// <summary>
        /// <para>
        /// The <see cref="GetTextExtentPoint"/> function computes the width and height of the specified string of text.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-gettextextentpointw
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTextExtentPointW", SetLastError = true)]
        public static extern BOOL GetTextExtentPoint([In]HDC hdc, [MarshalAs(UnmanagedType.LPWStr)]string lpString, [In] int c, [Out]out SIZE lpsz);

        /// <summary>
        /// <para>
        /// The <see cref="TabbedTextOut"/> function writes a character string at a specified location,
        /// expanding tabs to the values specified in an array of tab-stop positions.
        /// Text is written in the currently selected font, background color, and text color.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-tabbedtextoutw
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="x">
        /// The x-coordinate of the starting point of the string, in logical units.
        /// </param>
        /// <param name="y">
        /// The y-coordinate of the starting point of the string, in logical units.
        /// </param>
        /// <param name="lpString">
        /// A pointer to the character string to draw.
        /// The string does not need to be zero-terminated, since <paramref name="chCount"/> specifies the length of the string.
        /// </param>
        /// <param name="chCount">
        /// The length of the string pointed to by <paramref name="lpString"/>.
        /// </param>
        /// <param name="nTabPositions">
        /// The number of values in the array of tab-stop positions.
        /// </param>
        /// <param name="lpnTabStopPositions">
        /// A pointer to an array containing the tab-stop positions, in logical units.
        /// The tab stops must be sorted in increasing order; the smallest x-value should be the first item in the array.
        /// </param>
        /// <param name="nTabOrigin">
        /// The x-coordinate of the starting position from which tabs are expanded, in logical units.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the dimensions, in logical units, of the string.
        /// The height is in the high-order word and the width is in the low-order word.
        /// If the function fails, the return value is zero.
        /// </returns>
        /// <remarks>
        /// If the <paramref name="nTabPositions"/> parameter is zero and the <paramref name="lpnTabStopPositions"/> parameter is <see cref="null"/>,
        /// tabs are expanded to eight times the average character width.
        /// If <paramref name="nTabPositions"/> is 1, the tab stops are separated by the distance specified
        /// by the first value in the <paramref name="lpnTabStopPositions"/> array.
        /// If the <paramref name="lpnTabStopPositions"/> array contains more than one value, a tab stop is set for each value in the array,
        /// up to the number specified by <paramref name="nTabPositions"/>.
        /// The <paramref name="nTabOrigin"/> parameter allows an application to call the <see cref="TabbedTextOut"/> function several times for a single line.
        /// If the application calls <see cref="TabbedTextOut"/> more than once with the <paramref name="nTabOrigin"/> set to the same value each time,
        /// the function expands all tabs relative to the position specified by <paramref name="nTabOrigin"/>.
        /// By default, the current position is not used or updated by the <see cref="TabbedTextOut"/> function.
        /// If an application needs to update the current position when it calls <see cref="TabbedTextOut"/>,
        /// the application can call the <see cref="SetTextAlign"/> function with the wFlags parameter set to <see cref="TA_UPDATECP"/>.
        /// When this flag is set, the system ignores the <paramref name="x"/> and <paramref name="y"/> parameters
        /// on subsequent calls to the <see cref="TabbedTextOut"/> function, using the current position instead.
        /// Note For Windows Vista and later, <see cref="TabbedTextOut"/> ignores text alignment when it draws text.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "TabbedTextOutW", SetLastError = true)]
        public static extern LONG TabbedTextOut([In]HDC hdc, [In]int x, [In]int y, [MarshalAs(UnmanagedType.LPWStr)][In]string lpString,
            [In]int chCount, [In]int nTabPositions, [MarshalAs(UnmanagedType.LPArray)][In]INT[] lpnTabStopPositions, [In]int nTabOrigin);

        /// <summary>
        /// <para>
        /// The <see cref="TextOut"/> function writes a character string at the specified location, using the currently selected font,
        /// background color, and text color.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-textoutw
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "TextOutW", SetLastError = true)]
        public static extern BOOL TextOut([In]HDC hdc, [In]int x, [In]int y, [MarshalAs(UnmanagedType.LPWStr)][In]string lpString, [In]int c);
    }
}
