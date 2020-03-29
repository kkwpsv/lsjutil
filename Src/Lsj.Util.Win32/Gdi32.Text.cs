using Lsj.Util.Win32.BaseTypes;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32
{
    public partial class Gdi32
    {
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
