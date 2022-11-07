using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HWND;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.BorderFlags;
using static Lsj.Util.Win32.Enums.BorderStyles;
using static Lsj.Util.Win32.Enums.ClassStyles;
using static Lsj.Util.Win32.Enums.DrawFrameControlStates;
using static Lsj.Util.Win32.Enums.DrawFrameControlTypes;
using static Lsj.Util.Win32.Enums.DrawTextFormatFlags;
using static Lsj.Util.Win32.Enums.GetDCExFlags;
using static Lsj.Util.Win32.Enums.MappingModes;
using static Lsj.Util.Win32.Enums.PrintWindowFlags;
using static Lsj.Util.Win32.Enums.RasterCodes;
using static Lsj.Util.Win32.Enums.RedrawWindowFlags;
using static Lsj.Util.Win32.Enums.RegionFlags;
using static Lsj.Util.Win32.Enums.SystemColors;
using static Lsj.Util.Win32.Enums.SystemParametersInfoParameters;
using static Lsj.Util.Win32.Enums.TextAlignments;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Enums.WindowStyles;
using static Lsj.Util.Win32.Enums.WindowStylesEx;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32
{
    public static partial class User32
    {
        /// <summary>
        /// <para>
        /// The OutputProc function is an application-defined callback function used with the <see cref="GrayString"/> function.
        /// It is used to draw a string.
        /// The <see cref="GRAYSTRINGPROC"/> type defines a pointer to this callback function.
        /// OutputProc is a placeholder for the application-defined or library-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nc-winuser-graystringproc"/>
        /// </para>
        /// </summary>
        /// <param name="Arg1">
        /// A handle to a device context with a bitmap of at least the width and height
        /// specified by the nWidth and nHeight parameters passed to <see cref="GrayString"/>.
        /// </param>
        /// <param name="Arg2">
        /// A pointer to the string to be drawn.
        /// </param>
        /// <param name="Arg3">
        /// The length, in characters, of the string.
        /// </param>
        /// <returns>
        /// If it succeeds, the callback function should return <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The callback function must draw an image relative to the coordinates (0,0).
        /// </remarks>
        public delegate BOOL Graystringproc([In] HDC Arg1, [In] LPARAM Arg2, [In] int Arg3);


        /// <summary>
        /// <para>
        /// The <see cref="BeginPaint"/> function prepares the specified window for painting
        /// and fills a <see cref="PAINTSTRUCT"/> structure with information about the painting.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-beginpaint"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// Handle to the window to be repainted.
        /// </param>
        /// <param name="lpPaint">
        /// Pointer to the <see cref="PAINTSTRUCT"/> structure that will receive painting information.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to a display device context for the specified window.
        /// If the function fails, the return value is <see cref="NULL"/>, indicating that no display device context is available.
        /// </returns>
        /// <remarks>
        /// The <see cref="BeginPaint"/> function automatically sets the clipping region of the device context to
        /// exclude any area outside the update region.
        /// The update region is set by the <see cref="InvalidateRect"/> or <see cref="InvalidateRgn"/> function and by the system
        /// after sizing, moving, creating, scrolling, or any other operation that affects the client area.
        /// If the update region is marked for erasing, <see cref="BeginPaint"/> sends a <see cref="WM_ERASEBKGND"/> message to the window.
        /// An application should not call <see cref="BeginPaint"/> except in response to a <see cref="WM_PAINT"/> message
        /// .Each call to BeginPaint must have a corresponding call to the <see cref="EndPaint"/> function.
        /// If the caret is in the area to be painted, <see cref="BeginPaint"/> automatically hides the caret to prevent it from being erased.
        /// If the window's class has a background brush, BeginPaint uses that brush to erase the background of the update region before returning.
        /// DPI Virtualization
        /// This API does not participate in DPI virtualization. The output returned is always in terms of physical pixels.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "BeginPaint", ExactSpelling = true, SetLastError = true)]
        public static extern HDC BeginPaint([In] HWND hWnd, [Out] out PAINTSTRUCT lpPaint);

        /// <summary>
        /// <para>
        /// The <see cref="ClientToScreen"/> function converts the client-area coordinates of a specified point to screen coordinates.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-clienttoscreen"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose client area is used for the conversion.
        /// </param>
        /// <param name="lpPoint">
        /// A pointer to a <see cref="POINT"/> structure that contains the client coordinates to be converted.
        /// The new screen coordinates are copied into this structure if the function succeeds.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="ClientToScreen"/> function replaces the client-area coordinates in the <see cref="POINT"/> structure with the screen coordinates.
        /// The screen coordinates are relative to the upper-left corner of the screen.
        /// Note, a screen-coordinate point that is above the window's client area has a negative y-coordinate.
        /// Similarly, a screen coordinate to the left of a client area has a negative x-coordinate.
        /// All coordinates are device coordinates.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ClientToScreen", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ClientToScreen([In] HWND hWnd, [In][Out] ref POINT lpPoint);

        /// <summary>
        /// <para>
        /// The <see cref="DrawEdge"/> function draws one or more edges of rectangle.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-drawedge"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="qrc">
        /// A pointer to a <see cref="RECT"/> structure that contains the logical coordinates of the rectangle.
        /// </param>
        /// <param name="edge">
        /// The type of inner and outer edges to draw.
        /// This parameter must be a combination of one inner-border flag and one outer-border flag.
        /// The inner-border flags are as follows.
        /// <see cref="BDR_RAISEDINNER"/>: Raised inner edge.
        /// <see cref="BDR_SUNKENINNER"/>: Sunken inner edge.
        /// The outer-border flags are as follows.
        /// <see cref="BDR_RAISEDOUTER"/>: Raised outer edge.
        /// <see cref="BDR_SUNKENOUTER"/>: Sunken outer edge.
        /// Alternatively, the <paramref name="edge"/> parameter can specify one of the following flags.
        /// <see cref="EDGE_BUMP"/>: Combination of <see cref="BDR_RAISEDOUTER"/> and <see cref="BDR_SUNKENINNER"/>.
        /// <see cref="EDGE_ETCHED"/>: Combination of <see cref="BDR_SUNKENOUTER"/> and <see cref="BDR_RAISEDINNER"/>.
        /// <see cref="EDGE_RAISED"/>: Combination of <see cref="BDR_RAISEDOUTER"/> and <see cref="BDR_RAISEDINNER"/>.
        /// <see cref="EDGE_SUNKEN"/>: Combination of <see cref="BDR_SUNKENOUTER"/> and <see cref="BDR_SUNKENINNER"/>.
        /// </param>
        /// <param name="grfFlags">
        /// The type of border. This parameter can be a combination of the following values.
        /// <see cref="BF_ADJUST"/>:
        /// If this flag is passed, shrink the rectangle pointed to by the qrc parameter to exclude the edges that were drawn.
        /// If this flag is not passed, then do not change the rectangle pointed to by the <paramref name="qrc"/> parameter.
        /// <see cref="BF_BOTTOM"/>: Bottom of border rectangle.
        /// <see cref="BF_BOTTOMLEFT"/>: Bottom and left side of border rectangle.
        /// <see cref="BF_BOTTOMRIGHT"/>: Bottom and right side of border rectangle.
        /// <see cref="BF_DIAGONAL"/>: Diagonal border.
        /// <see cref="BF_DIAGONAL_ENDBOTTOMLEFT"/>:
        /// Diagonal border. The end point is the lower-left corner of the rectangle; the origin is top-right corner.
        /// <see cref="BF_DIAGONAL_ENDBOTTOMRIGHT"/>:
        /// Diagonal border. The end point is the lower-right corner of the rectangle; the origin is top-left corner.
        /// <see cref="BF_DIAGONAL_ENDTOPLEFT"/>:
        /// Diagonal border. The end point is the top-left corner of the rectangle; the origin is lower-right corner.
        /// <see cref="BF_DIAGONAL_ENDTOPRIGHT"/>:
        /// Diagonal border. The end point is the top-right corner of the rectangle; the origin is lower-left corner.
        /// <see cref="BF_FLAT"/>: Flat border.
        /// <see cref="BF_LEFT"/>: Left side of border rectangle.
        /// <see cref="BF_MIDDLE"/>: Interior of rectangle to be filled.
        /// <see cref="BF_MONO"/>: One-dimensional border.
        /// <see cref="BF_RECT"/>: Entire border rectangle.
        /// <see cref="BF_RIGHT"/>: Right side of border rectangle.
        /// <see cref="BF_SOFT"/>: Soft buttons instead of tiles.
        /// <see cref="BF_TOP"/>: Top of border rectangle.
        /// <see cref="BF_TOPLEFT"/>: Top and left side of border rectangle.
        /// <see cref="BF_TOPRIGHT"/>: Top and right side of border rectangle.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DrawEdge", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DrawEdge([In] HDC hdc, [In] in RECT qrc, [In] BorderStyles edge, [In] BorderFlags grfFlags);

        /// <summary>
        /// <para>
        /// The <see cref="DrawFocusRect"/> function draws a rectangle in the style used to indicate that the rectangle has the focus.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-drawfocusrect"/>
        /// </para>
        /// </summary>
        /// <param name="hDC">
        /// A handle to the device context.
        /// </param>
        /// <param name="lprc">
        /// A pointer to a <see cref="RECT"/> structure that specifies the logical coordinates of the rectangle.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="DrawFocusRect"/> works only in <see cref="MM_TEXT"/> mode.
        /// Because <see cref="DrawFocusRect"/> is an XOR function, calling it a second time with the same rectangle removes the rectangle from the screen.
        /// This function draws a rectangle that cannot be scrolled.
        /// To scroll an area containing a rectangle drawn by this function, call <see cref="DrawFocusRect"/> to remove the rectangle from the screen,
        /// scroll the area, and then call <see cref="DrawFocusRect"/> again to draw the rectangle in the new position.
        /// Windows XP: The focus rectangle can now be thicker than 1 pixel, so it is more visible for high-resolution, high-density displays and accessibility needs.
        /// This is handled by the <see cref="SPI_SETFOCUSBORDERWIDTH"/> and
        /// <see cref="SPI_SETFOCUSBORDERHEIGHT"/> in <see cref="SystemParametersInfo"/>.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DrawFocusRect", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DrawFocusRect([In] HDC hDC, [In] in RECT lprc);

        /// <summary>
        /// <para>
        /// The <see cref="DrawFrameControl"/> function draws a frame control of the specified type and style.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-drawframecontrol"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1">
        /// A handle to the device context of the window in which to draw the control.
        /// </param>
        /// <param name="unnamedParam2">
        /// A pointer to a <see cref="RECT"/> structure that contains the logical coordinates of the bounding rectangle for frame control.
        /// </param>
        /// <param name="unnamedParam3">
        /// The type of frame control to draw.
        /// This parameter can be one of the following values.
        /// <see cref="DFC_BUTTON"/>, <see cref="DFC_CAPTION"/>, <see cref="DFC_MENU"/>, <see cref="DFC_POPUPMENU"/>, <see cref="DFC_SCROLL"/>
        /// </param>
        /// <param name="unnamedParam4">
        /// The initial state of the frame control.
        /// If <paramref name="unnamedParam3"/> is <see cref="DFC_BUTTON"/>, <paramref name="unnamedParam4"/> can be one of the following values.
        /// <see cref="DFCS_BUTTON3STATE"/>, <see cref="DFCS_BUTTONCHECK"/>, <see cref="DFCS_BUTTONPUSH"/>, <see cref="DFCS_BUTTONRADIO"/>,
        /// <see cref="DFCS_BUTTONRADIOIMAGE"/>, <see cref="DFCS_BUTTONRADIOMASK"/>
        /// If paramref name="unnamedParam3"/> is <see cref="DFC_CAPTION"/>, <paramref name="unnamedParam4"/> can be one of the following values.
        /// <see cref="DFCS_CAPTIONCLOSE"/>, <see cref="DFCS_CAPTIONHELP"/>, <see cref="DFCS_CAPTIONMAX"/>, <see cref="DFCS_CAPTIONMIN"/>,
        /// <see cref="DFCS_CAPTIONRESTORE"/>,
        /// If paramref name="unnamedParam3"/> is <see cref="DFC_MENU"/>, <paramref name="unnamedParam4"/> can be one of the following values.
        /// <see cref="DFCS_MENUARROW"/>, <see cref="DFCS_MENUARROWRIGHT"/>, <see cref="DFCS_MENUBULLET"/>, <see cref="DFCS_MENUCHECK"/>
        /// If paramref name="unnamedParam3"/> is <see cref="DFC_SCROLL"/>, <paramref name="unnamedParam4"/> can be one of the following values.
        /// <see cref="DFCS_SCROLLCOMBOBOX"/>, <see cref="DFCS_SCROLLDOWN"/>, <see cref="DFCS_SCROLLLEFT"/>, <see cref="DFCS_SCROLLRIGHT"/>,
        /// <see cref="DFCS_SCROLLSIZEGRIP"/>, <see cref="DFCS_SCROLLSIZEGRIPRIGHT"/>, <see cref="DFCS_SCROLLUP"/>
        /// The following style can be used to adjust the bounding rectangle of the push button.
        /// <see cref="DFCS_ADJUSTRECT"/>
        /// One or more of the following values can be used to set the state of the control to be drawn.
        /// <see cref="DFCS_CHECKED"/>, <see cref="DFCS_FLAT"/>, <see cref="DFCS_HOT"/>, <see cref="DFCS_INACTIVE"/>, <see cref="DFCS_MONO"/>,
        /// <see cref="DFCS_PUSHED"/>, <see cref="DFCS_TRANSPARENT"/>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// If <paramref name="unnamedParam3"/> is either <see cref="DFC_MENU"/> or <see cref="DFC_BUTTON"/>
        /// and <paramref name="unnamedParam4"/> is not <see cref="DFCS_BUTTONPUSH"/>,
        /// the frame control is a black-on-white mask (that is, a black frame control on a white background).
        /// In such cases, the application must pass a handle to a bitmap memory device control.
        /// The application can then use the associated bitmap as the hbmMask parameter to the MaskBlt function,
        /// or it can use the device context as a parameter to the <see cref="BitBlt"/> function using ROPs such as <see cref="SRCAND"/> and <see cref="SRCINVERT"/>.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DrawFrameControl", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DrawFrameControl([In] HDC unnamedParam1, [In] in RECT unnamedParam2,
            [In] DrawFrameControlTypes unnamedParam3, [In] DrawFrameControlStates unnamedParam4);

        /// <summary>
        /// <para>
        /// The <see cref="DrawText"/> function draws formatted text in the specified rectangle.
        /// It formats the text according to the specified method (expanding tabs, justifying characters, breaking lines, and so forth).
        /// To specify additional formatting options, use the <see cref="DrawTextEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-drawtext"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lpchText">
        /// A pointer to the string that specifies the text to be drawn.
        /// If the <paramref name="cchText"/> parameter is -1, the string must be null-terminated.
        /// If <paramref name="format"/> includes <see cref="DT_MODIFYSTRING"/>, the function could add up to four additional characters to this string.
        /// The buffer containing the string should be large enough to accommodate these extra characters.
        /// </param>
        /// <param name="cchText">
        /// The length, in characters, of the string.
        /// If <paramref name="cchText"/> is -1, then the <paramref name="lpchText"/> parameter is assumed to be a pointer to a null-terminated string
        /// and <see cref="DrawText"/> computes the character count automatically.
        /// </param>
        /// <param name="lprc">
        /// A pointer to a <see cref="RECT"/> structure that contains the rectangle (in logical coordinates) in which the text is to be formatted.
        /// </param>
        /// <param name="format">
        /// The method of formatting the text. This parameter can be one or more of the following values.
        /// <see cref="DT_BOTTOM"/>, <see cref="DT_CALCRECT"/>, <see cref="DT_CENTER"/>, <see cref="DT_EDITCONTROL"/>, <see cref="DT_END_ELLIPSIS"/>,
        /// <see cref="DT_EXPANDTABS"/>, <see cref="DT_EXTERNALLEADING"/>, <see cref="DT_HIDEPREFIX"/>, <see cref="DT_INTERNAL"/>, <see cref="DT_LEFT"/>,
        /// <see cref="DT_MODIFYSTRING"/>, <see cref="DT_NOCLIP"/>, <see cref="DT_NOFULLWIDTHCHARBREAK"/>, <see cref="DT_NOPREFIX"/>,
        /// <see cref="DT_PATH_ELLIPSIS"/>, <see cref="DT_PREFIXONLY"/>, <see cref="DT_RIGHT"/>, <see cref="DT_RTLREADING"/>, <see cref="DT_SINGLELINE"/>,
        /// <see cref="DT_TABSTOP"/>, <see cref="DT_TOP"/>, <see cref="DT_VCENTER"/>, <see cref="DT_WORDBREAK"/>, <see cref="DT_WORD_ELLIPSIS"/>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the height of the text in logical units.
        /// If <see cref="DT_VCENTER"/> or <see cref="DT_BOTTOM"/> is specified, the return value is the offset
        /// from lpRect->top to the bottom of the drawn text
        /// If the function fails, the return value is zero.
        /// </returns>
        /// <remarks>
        /// The <see cref="DrawText"/> function uses the device context's selected font, text color, and background color to draw the text.
        /// Unless the <see cref="DT_NOCLIP"/> format is used, <see cref="DrawText"/> clips the text so that it does not appear outside the specified rectangle.
        /// Note that text with significant overhang may be clipped, for example, an initial "W" in the text string or text that is in italics.
        /// All formatting is assumed to have multiple lines unless the <see cref="DT_SINGLELINE"/> format is specified.
        /// If the selected font is too large for the specified rectangle, the <see cref="DrawText"/> function does not attempt to substitute a smaller font.
        /// The text alignment mode for the device context must include the <see cref="TA_LEFT"/>, <see cref="TA_TOP"/>, and <see cref="TA_NOUPDATECP"/> flags.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DrawTextW", ExactSpelling = true, SetLastError = true)]
        public static extern int DrawText([In] HDC hdc, [In] LPCWSTR lpchText, [In] int cchText,
            [In] in RECT lprc, [In] DrawTextFormatFlags format);

        /// <summary>
        /// <para>
        /// The <see cref="DrawTextEx"/> function draws formatted text in the specified rectangle.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-drawtextexw"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context in which to draw.
        /// </param>
        /// <param name="lpchText">
        /// A pointer to the string that contains the text to draw.
        /// If the <paramref name="cchText"/> parameter is -1, the string must be null-terminated.
        /// If <paramref name="format"/> includes <see cref="DT_MODIFYSTRING"/>, the function could add up to four additional characters to this string.
        /// The buffer containing the string should be large enough to accommodate these extra characters.
        /// </param>
        /// <param name="cchText">
        /// The length of the string pointed to by <paramref name="lpchText"/>.
        /// If <paramref name="cchText"/> is -1, then the <paramref name="lpchText"/> parameter is assumed to be a pointer to a null-terminated string
        /// and <see cref="DrawTextEx"/> computes the character count automatically.
        /// </param>
        /// <param name="lprc">
        /// A pointer to a <see cref="RECT"/> structure that contains the rectangle, in logical coordinates, in which the text is to be formatted.
        /// </param>
        /// <param name="format">
        /// The formatting options. This parameter can be one or more of the following values.
        /// <see cref="DT_BOTTOM"/>, <see cref="DT_CALCRECT"/>, <see cref="DT_CENTER"/>, <see cref="DT_EDITCONTROL"/>, <see cref="DT_END_ELLIPSIS"/>,
        /// <see cref="DT_EXPANDTABS"/>, <see cref="DT_EXTERNALLEADING"/>, <see cref="DT_HIDEPREFIX"/>, <see cref="DT_INTERNAL"/>,
        /// <see cref="DT_LEFT"/>, <see cref="DT_MODIFYSTRING"/>, <see cref="DT_NOCLIP"/>, <see cref="DT_NOFULLWIDTHCHARBREAK"/>,
        /// <see cref="DT_NOPREFIX"/>, <see cref="DT_PATH_ELLIPSIS"/>, <see cref="DT_PREFIXONLY"/>, <see cref="DT_RIGHT"/>,
        /// <see cref="DT_RTLREADING"/>, <see cref="DT_SINGLELINE"/>, <see cref="DT_TABSTOP"/>, <see cref="DT_TOP"/>, <see cref="DT_VCENTER"/>,
        /// <see cref="DT_WORDBREAK"/>, <see cref="DT_WORD_ELLIPSIS"/>
        /// </param>
        /// <param name="lpdtp">
        /// A pointer to a <see cref="DRAWTEXTPARAMS"/> structure that specifies additional formatting options.
        /// This parameter can be <see cref="NullRef{DRAWTEXTPARAMS}"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the text height in logical units.
        /// If <see cref="DT_VCENTER"/> or <see cref="DT_BOTTOM"/> is specified,
        /// the return value is the offset from lprc->top to the bottom of the drawn text
        /// If the function fails, the return value is zero.
        /// </returns>
        /// <remarks>
        /// The DrawTextEx function supports only fonts whose escapement and orientation are both zero.
        /// The text alignment mode for the device context must
        /// include the <see cref="TA_LEFT"/>, <see cref="TA_TOP"/>, and <see cref="TA_NOUPDATECP"/> flags.
        /// Note
        /// The winuser.h header defines DrawTextEx as an alias which automatically selects the ANSI or Unicode version
        /// of this function based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral
        /// can lead to mismatches that result in compilation or runtime errors.
        /// For more information, see Conventions for Function Prototypes.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DrawTextExW", ExactSpelling = true, SetLastError = true)]
        public static extern int DrawTextEx([In] HDC hdc, [In] LPCWSTR lpchText, [In] int cchText,
            [In] in RECT lprc, [In] DrawTextFormatFlags format, [In] in DRAWTEXTPARAMS lpdtp);

        /// <summary>
        /// <para>
        /// The EndPaint function marks the end of painting in the specified window.
        /// This function is required for each call to the <see cref="BeginPaint"/> function, but only after painting is complete.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-endpaint"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// Handle to the window that has been repainted.
        /// </param>
        /// <param name="lpPaint">
        /// Pointer to a <see cref="PAINTSTRUCT"/> structure that contains the painting information retrieved by <see cref="BeginPaint"/>.
        /// </param>
        /// <returns>
        /// The return value is always <see cref="TRUE"/>.
        /// </returns>
        /// <remarks>
        /// If the caret was hidden by <see cref="BeginPaint"/>, <see cref="EndPaint"/> restores the caret to the screen.
        /// <see cref="EndPaint"/> releases the display device context that <see cref="BeginPaint"/> retrieved.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EndPaint", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EndPaint([In] HWND hWnd, [In] in PAINTSTRUCT lpPaint);

        /// <summary>
        /// <para>
        /// The <see cref="ExcludeUpdateRgn"/> function prevents drawing within invalid areas of a window
        /// by excluding an updated region in the window from a clipping region.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-excludeupdatergn"/>
        /// </para>
        /// </summary>
        /// <param name="hDC">
        /// Handle to the device context associated with the clipping region.
        /// </param>
        /// <param name="hWnd">
        /// Handle to the window to update.
        /// </param>
        /// <returns>
        /// The return value specifies the complexity of the excluded region; it can be any one of the following values.
        /// <see cref="COMPLEXREGION"/>: Region consists of more than one rectangle.
        /// <see cref="ERROR"/>: An error occurred.
        /// <see cref="NULLREGION"/>: Region is empty.
        /// <see cref="SIMPLEREGION"/>: Region is a single rectangle.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ExcludeUpdateRgn", ExactSpelling = true, SetLastError = true)]
        public static extern int ExcludeUpdateRgn([In] HDC hDC, [In] HWND hWnd);

        /// <summary>
        /// <para>
        /// The <see cref="FillRect"/> function fills a rectangle by using the specified brush.
        /// This function includes the left and top borders, but excludes the right and bottom borders of the rectangle.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-fillrect"/>
        /// </para>
        /// </summary>
        /// <param name="hDC">
        /// A handle to the device context.
        /// </param>
        /// <param name="lprc">
        /// A pointer to a <see cref="RECT"/> structure that contains the logical coordinates of the rectangle to be filled.
        /// </param>
        /// <param name="hbr">
        /// A handle to the brush used to fill the rectangle.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The brush identified by the hbr parameter may be either a handle to a logical brush or a color value.
        /// If specifying a handle to a logical brush, call one of the following functions to obtain the handle:
        /// <see cref="CreateHatchBrush"/>, <see cref="CreatePatternBrush"/>, or <see cref="CreateSolidBrush"/>.
        /// Additionally, you may retrieve a handle to one of the stock brushes by using the <see cref="GetStockObject"/> function.
        /// If specifying a color value for the <paramref name="hbr"/> parameter, it must be one of the standard system colors
        /// (the value 1 must be added to the chosen color).
        /// For example:
        /// <code>FillRect(hdc, &amp;rect, (HBRUSH) (COLOR_WINDOW+1));</code>
        /// For a list of all the standard system colors, see GetSysColor.
        /// When filling the specified rectangle, <see cref="FillRect"/> does not include the rectangle's right and bottom sides.
        /// GDI fills a rectangle up to, but not including, the right column and bottom row, regardless of the current mapping mode.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "FillRect", ExactSpelling = true, SetLastError = true)]
        public static extern int FillRect([In] HDC hDC, [In] in RECT lprc, [In] HBRUSH hbr);

        /// <summary>
        /// <para>
        /// The <see cref="FrameRect"/> function draws a border around the specified rectangle by using the specified brush.
        /// The width and height of the border are always one logical unit.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-framerect"/>
        /// </para>
        /// </summary>
        /// <param name="hDC">
        /// A handle to the device context in which the border is drawn.
        /// </param>
        /// <param name="lprc">
        /// A pointer to a <see cref="RECT"/> structure that contains the logical coordinates of the upper-left and lower-right corners of the rectangle.
        /// </param>
        /// <param name="hbr">
        /// A handle to the brush used to draw the border.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The brush identified by the hbr parameter must have been created by using the <see cref="CreateHatchBrush"/>, <see cref="CreatePatternBrush"/>,
        /// or <see cref="CreateSolidBrush"/> function, or retrieved by using the <see cref="GetStockObject"/> function.
        /// If the <see cref="RECT.bottom"/> member of the <see cref="RECT"/> structure is less than the top member,
        /// or if the right member is less than the left member, the function does not draw the rectangle.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "FrameRect", ExactSpelling = true, SetLastError = true)]
        public static extern int FrameRect([In] HDC hDC, [In][Out] ref RECT lprc, [In] HBRUSH hbr);

        /// <summary>
        /// <para>
        /// The <see cref="GetDC"/> function retrieves a handle to a device context (DC) for the client area of a specified window or for the entire screen.
        /// You can use the returned handle in subsequent GDI functions to draw in the DC.
        /// The device context is an opaque data structure, whose values are used internally by GDI.
        /// The <see cref="GetDCEx"/> function is an extension to <see cref="GetDC"/>,
        /// which gives an application more control over how and whether clipping occurs in the client area.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getdc"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window whose DC is to be retrieved.
        /// If this value is <see cref="IntPtr.Zero"/>, <see cref="GetDC"/> retrieves the DC for the entire screen.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the DC for the specified window's client area.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDC", ExactSpelling = true, SetLastError = true)]
        public static extern HDC GetDC([In] HWND hwnd);

        /// <summary>
        /// <para>
        /// The <see cref="GetDCEx"/> function retrieves a handle to a device context (DC) for the client area of a specified window or for the entire screen.
        /// You can use the returned handle in subsequent GDI functions to draw in the DC.
        /// The device context is an opaque data structure, whose values are used internally by GDI.
        /// This function is an extension to the <see cref="GetDC"/> function,
        /// which gives an application more control over how and whether clipping occurs in the client area.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getdcex"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose DC is to be retrieved.
        /// If this value is <see cref="NULL"/>, <see cref="GetDCEx"/> retrieves the DC for the entire screen.
        /// </param>
        /// <param name="hrgnClip">
        /// A clipping region that may be combined with the visible region of the DC.
        /// If the value of flags is <see cref="DCX_INTERSECTRGN"/> or <see cref="DCX_EXCLUDERGN"/>,
        /// then the operating system assumes ownership of the region and will automatically delete it when it is no longer needed.
        /// In this case, the application should not use or delete the region after a successful call to <see cref="GetDCEx"/>.
        /// </param>
        /// <param name="flags">
        /// Specifies how the DC is created. This parameter can be one or more of the following values.
        /// <see cref="DCX_WINDOW"/>, <see cref="DCX_CACHE"/>, <see cref="DCX_PARENTCLIP"/>, <see cref="DCX_CLIPSIBLINGS"/>,
        /// <see cref="DCX_CLIPCHILDREN"/>, <see cref="DCX_NORESETATTRS"/>, <see cref="DCX_LOCKWINDOWUPDATE"/>,
        /// <see cref="DCX_EXCLUDERGN"/>, <see cref="DCX_INTERSECTRGN"/>, <see cref="DCX_INTERSECTUPDATE"/>,
        /// <see cref="DCX_VALIDATE"/>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the DC for the specified window.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// An invalid value for the <paramref name="hWnd"/> parameter will cause the function to fail.
        /// </returns>
        /// <remarks>
        /// Unless the display DC belongs to a window class, the <see cref="ReleaseDC"/> function must be called to release the DC after painting.
        /// Also, <see cref="ReleaseDC"/> must be called from the same thread that called <see cref="GetDCEx"/>.
        /// The number of DCs is limited only by available memory.
        /// The function returns a handle to a DC that belongs to the window's class if <see cref="CS_CLASSDC"/>,
        /// <see cref="CS_OWNDC"/> or <see cref="CS_PARENTDC"/> was specified as a style in the <see cref="WNDCLASS"/> structure when the class was registered.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDCEx", ExactSpelling = true, SetLastError = true)]
        public static extern HDC GetDCEx([In] HWND hWnd, [In] HRGN hrgnClip, [In] GetDCExFlags flags);

        /// <summary>
        /// <para>
        /// The <see cref="GetTabbedTextExtent"/> function computes the width and height of a character string.
        /// If the string contains one or more tab characters, the width of the string is based upon the specified tab stops.
        /// The <see cref="GetTabbedTextExtent"/> function uses the currently selected font to compute the dimensions of the string.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-gettabbedtextextentw"/>
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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTabbedTextExtentW", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetTabbedTextExtent([In] HDC hdc, [In] LPCWSTR lpString, [In] int chCount,
            [In] int nTabPositions, [MarshalAs(UnmanagedType.LPArray)][In] INT[] lpnTabStopPositions);

        /// <summary>
        /// <para>
        /// The <see cref="GetWindowDC"/> function retrieves the device context (DC) for the entire window, including title bar, menus, and scroll bars.
        /// A window device context permits painting anywhere in a window,
        /// because the origin of the device context is the upper-left corner of the window instead of the client area.
        /// <see cref="GetWindowDC"/> assigns default attributes to the window device context each time it retrieves the device context.
        /// Previous attributes are lost.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getwindowdc"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window with a device context that is to be retrieved.
        /// If this value is <see cref="NULL"/>, <see cref="GetWindowDC"/> retrieves the device context for the entire screen.
        /// If this parameter is <see cref="NULL"/>, <see cref="GetWindowDC"/> retrieves the device context for the primary display monitor.
        /// To get the device context for other display monitors, use the <see cref="EnumDisplayMonitors"/> and <see cref="CreateDC"/> functions.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to a device context for the specified window.
        /// If the function fails, the return value is <see cref="NULL"/>, indicating an error or an invalid <paramref name="hWnd"/> parameter.
        /// </returns>
        /// <remarks>
        /// <see cref="GetWindowDC"/> is intended for special painting effects within a window's nonclient area.
        /// Painting in nonclient areas of any window is not recommended.
        /// The <see cref="GetSystemMetrics"/> function can be used to retrieve the dimensions of various parts of the nonclient area,
        /// such as the title bar, menu, and scroll bars.
        /// The <see cref="GetDC"/> function can be used to retrieve a device context for the entire screen.
        /// After painting is complete, the <see cref="ReleaseDC"/> function must be called to release the device context.
        /// Not releasing the window device context has serious effects on painting requested by applications.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowDC", ExactSpelling = true, SetLastError = true)]
        public static extern HDC GetWindowDC([In] HWND hWnd);

        /// <summary>
        /// <para>
        /// The <see cref="GetUpdateRect"/> function retrieves the coordinates of the smallest rectangle
        /// that completely encloses the update region of the specified window.
        /// <see cref="GetUpdateRect"/> retrieves the rectangle in logical coordinates. If there is no update region,
        /// <see cref="GetUpdateRect"/> retrieves an empty rectangle (sets all coordinates to zero).
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getupdaterect"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// Handle to the window whose update region is to be retrieved.
        /// </param>
        /// <param name="lpRect">
        /// Pointer to the <see cref="RECT"/> structure that receives the coordinates, in device units, of the enclosing rectangle.
        /// An application can set this parameter to NULL to determine whether an update region exists for the window.
        /// If this parameter is <see cref="NULL"/>, <see cref="GetUpdateRect"/> returns nonzero if an update region exists, and zero if one does not.
        /// This provides a simple and efficient means of determining whether a <see cref="WM_PAINT"/> message resulted from an invalid area.
        /// </param>
        /// <param name="bErase">
        /// Specifies whether the background in the update region is to be erased.
        /// If this parameter is <see cref="TRUE"/> and the update region is not empty,
        /// <see cref="GetUpdateRect"/> sends a <see cref="WM_ERASEBKGND"/> message to the specified window to erase the background.
        /// </param>
        /// <returns>
        /// If the update region is not empty, the return value is <see cref="TRUE"/>.
        /// If there is no update region, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The update rectangle retrieved by the <see cref="BeginPaint"/> function is identical to that retrieved by <see cref="GetUpdateRect"/>.
        /// <see cref="BeginPaint"/> automatically validates the update region, so any call to <see cref="GetUpdateRect"/> made immediately
        /// after the call to <see cref="BeginPaint"/> retrieves an empty update region.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetUpdateRect", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetUpdateRect([In] HWND hWnd, [In][Out] ref RECT lpRect, [In] BOOL bErase);

        /// <summary>
        /// <para>
        /// The <see cref="GetUpdateRgn"/> function retrieves the update region of a window by copying it into the specified region.
        /// The coordinates of the update region are relative to the upper-left corner of the window (that is, they are client coordinates).
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getupdatergn"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// Handle to the window with an update region that is to be retrieved.
        /// </param>
        /// <param name="hRgn">
        /// Handle to the region to receive the update region.
        /// </param>
        /// <param name="bErase">
        /// Specifies whether the window background should be erased and whether nonclient areas of child windows should be drawn.
        /// If this parameter is <see cref="FALSE"/>, no drawing is done.
        /// </param>
        /// <returns>
        /// The return value indicates the complexity of the resulting region; it can be one of the following values.
        /// <see cref="COMPLEXREGION"/>: Region consists of more than one rectangle.
        /// <see cref="ERROR"/>: An error occurred.
        /// <see cref="NULLREGION"/>: Region is empty.
        /// <see cref="SIMPLEREGION"/>: Region is a single rectangle.
        /// </returns>
        /// <remarks>
        /// The <see cref="BeginPaint"/> function automatically validates the update region,
        /// so any call to <see cref="GetUpdateRgn"/> made immediately after the call to <see cref="BeginPaint"/> retrieves an empty update region.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetUpdateRgn", ExactSpelling = true, SetLastError = true)]
        public static extern int GetUpdateRgn([In] HWND hWnd, [In] HRGN hRgn, [In] BOOL bErase);

        /// <summary>
        /// <para>
        /// The <see cref="GrayString"/> function draws gray text at the specified location.
        /// The function draws the text by copying it into a memory bitmap, graying the bitmap, and then copying the bitmap to the screen.
        /// The function grays the text regardless of the selected brush and background.
        /// <see cref="GrayString"/> uses the font currently selected for the specified device context.
        /// If the <paramref name="lpOutputFunc"/> parameter is <see langword="null"/>, GDI uses the <see cref="TextOut"/> function,
        /// and the <paramref name="lpData"/> parameter is assumed to be a pointer to the character string to be output.
        /// If the characters to be output cannot be handled by <see cref="TextOut"/> (for example, the string is stored as a bitmap),
        /// the application must supply its own output function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-graystringw"/>
        /// </para>
        /// </summary>
        /// <param name="hDC">
        /// A handle to the device context.
        /// </param>
        /// <param name="hBrush">
        /// A handle to the brush to be used for graying.
        /// If this parameter is <see cref="NULL"/>, the text is grayed with the same brush that was used to draw window text.
        /// </param>
        /// <param name="lpOutputFunc">
        /// A pointer to the application-defined function that will draw the string, or,
        /// if <see cref="TextOut"/> is to be used to draw the string, it is a <see langword="null"/> pointer.
        /// For details, see the GRAYSTRINGPROC callback function.
        /// </param>
        /// <param name="lpData">
        /// A pointer to data to be passed to the output function.
        /// If the <paramref name="lpOutputFunc"/> parameter is <see langword="null"/>, <paramref name="lpData"/> must be a pointer to the string to be output.
        /// </param>
        /// <param name="nCount">
        /// The number of characters to be output.
        /// If the <paramref name="nCount"/> parameter is zero, <see cref="GrayString"/> calculates the length of the string
        /// (assuming lpData is a pointer to the string).
        /// If <paramref name="nCount"/> is 1 and the function pointed to by <paramref name="lpOutputFunc"/> returns <see cref="FALSE"/>,
        /// the image is shown but not grayed.
        /// </param>
        /// <param name="X">
        /// The device x-coordinate of the starting position of the rectangle that encloses the string.
        /// </param>
        /// <param name="Y">
        /// The device y-coordinate of the starting position of the rectangle that encloses the string.
        /// </param>
        /// <param name="nWidth">
        /// The width, in device units, of the rectangle that encloses the string.
        /// If this parameter is zero, <see cref="GrayString"/> calculates the width of the area, assuming <paramref name="lpData"/> is a pointer to the string.
        /// </param>
        /// <param name="nHeight">
        /// The height, in device units, of the rectangle that encloses the string.
        /// If this parameter is zero, <see cref="GrayString"/> calculates the height of the area, assuming <paramref name="lpData"/> is a pointer to the string.
        /// </param>
        /// <returns>
        /// If the string is drawn, the return value is <see cref="TRUE"/>.
        /// If either the <see cref="TextOut"/> function or the application-defined output function returned <see cref="FALSE"/>,
        /// or there was insufficient memory to create a memory bitmap for graying, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// Without calling <see cref="GrayString"/>, an application can draw grayed strings on devices that support a solid gray color.
        /// The system color <see cref="COLOR_GRAYTEXT"/> is the solid-gray system color used to draw disabled text.
        /// The application can call the <see cref="GetSysColor"/> function to retrieve the color value of <see cref="COLOR_GRAYTEXT"/>.
        /// If the color is other than zero (black), the application can call the <see cref="SetTextColor"/> function
        /// to set the text color to the color value and then draw the string directly.
        /// If the retrieved color is black, the application must call <see cref="GrayString"/> to gray the text.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GrayStringW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GrayString([In] HDC hDC, [In] HBRUSH hBrush, [In] GRAYSTRINGPROC lpOutputFunc, [In] LPARAM lpData, [In] int nCount,
            [In] int X, [In] int Y, [In] int nWidth, [In] int nHeight);

        /// <summary>
        /// <para>
        /// The <see cref="InvalidateRect"/> function adds a rectangle to the specified window's update region.
        /// The update region represents the portion of the window's client area that must be redrawn.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-invalidaterect "/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose update region has changed.
        /// If this parameter is <see cref="NULL"/>, the system invalidates and redraws all windows, not just the windows for this application,
        /// and sends the <see cref="WM_ERASEBKGND"/> and <see cref="WM_NCPAINT"/> messages before the function returns.
        /// Setting this parameter to <see cref="NULL"/> is not recommended.
        /// </param>
        /// <param name="lpRect">
        /// A pointer to a <see cref="RECT"/> structure that contains the client coordinates of the rectangle to be added to the update region.
        /// If this parameter is <see cref="NULL"/>, the entire client area is added to the update region.
        /// </param>
        /// <param name="bErase">
        /// Specifies whether the background within the update region is to be erased when the update region is processed.
        /// If this parameter is <see cref="TRUE"/>, the background is erased when the <see cref="BeginPaint"/> function is called.
        /// If this parameter is <see cref="FALSE"/>, the background remains unchanged.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The invalidated areas accumulate in the update region until the region is processed when the next <see cref="WM_PAINT"/> message occurs
        /// or until the region is validated by using the <see cref="ValidateRect"/> or <see cref="ValidateRgn"/> function.
        /// The system sends a <see cref="WM_PAINT"/> message to a window whenever its update region is not empty
        /// and there are no other messages in the application queue for that window.
        /// If the <paramref name="bErase"/> parameter is <see cref="TRUE"/> for any part of the update region,
        /// the background is erased in the entire region, not just in the specified part.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "InvalidateRect", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL InvalidateRect([In] HWND hWnd, [In] in RECT lpRect, [In] BOOL bErase);

        /// <summary>
        /// <para>
        /// The <see cref="InvalidateRgn"/> function invalidates the client area within the specified region
        /// by adding it to the current update region of a window.
        /// The invalidated region, along with all other areas in the update region,
        /// is marked for painting when the next <see cref="WM_PAINT"/> message occurs.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-invalidatergn"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window with an update region that is to be modified.
        /// </param>
        /// <param name="hRgn">
        /// A handle to the region to be added to the update region.
        /// The region is assumed to have client coordinates.
        /// If this parameter is <see cref="NULL"/>, the entire client area is added to the update region.
        /// </param>
        /// <param name="bErase">
        /// Specifies whether the background within the update region should be erased when the update region is processed.
        /// If this parameter is <see cref="TRUE"/>, the background is erased when the <see cref="BeginPaint"/> function is called.
        /// If the parameter is <see cref="FALSE"/>, the background remains unchanged.
        /// </param>
        /// <returns>
        /// The return value is always <see cref="TRUE"/>.
        /// </returns>
        /// <remarks>
        /// Invalidated areas accumulate in the update region until the next <see cref="WM_PAINT"/> message is processed
        /// or until the region is validated by using the <see cref="ValidateRect"/> or <see cref="ValidateRgn"/> function.
        /// The system sends a <see cref="WM_PAINT"/> message to a window whenever its update region is not empty
        /// and there are no other messages in the application queue for that window.
        /// The specified region must have been created by using one of the region functions.
        /// If the <paramref name="bErase"/> parameter is <see cref="TRUE"/> for any part of the update region,
        /// the background in the entire region is erased, not just in the specified part.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "InvalidateRgn", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL InvalidateRgn([In] HWND hWnd, [In] HRGN hRgn, [In] BOOL bErase);

        /// <summary>
        /// <para>
        /// The <see cref="InvertRect"/> function inverts a rectangle in a window by performing a logical NOT operation on the color values
        /// for each pixel in the rectangle's interior.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-invertrect"/>
        /// </para>
        /// </summary>
        /// <param name="hDC">
        /// A handle to the device context.
        /// </param>
        /// <param name="lprc">
        /// A pointer to a <see cref="RECT"/> structure that contains the logical coordinates of the rectangle to be inverted.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// On monochrome screens, <see cref="InvertRect"/> makes white pixels black and black pixels white.
        /// On color screens, the inversion depends on how colors are generated for the screen.
        /// Calling <see cref="InvertRect"/> twice for the same rectangle restores the display to its previous colors.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "InvertRect", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL InvertRect([In] HDC hDC, [In] in RECT lprc);

        /// <summary>
        /// <para>
        /// The <see cref="LoadBitmap"/> function loads the specified bitmap resource from a module's executable file.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-loadbitmapw"/>
        /// </para>
        /// </summary>
        /// <param name="hInstance">A handle to the instance of the module whose executable file contains the bitmap to be loaded.</param>
        /// <param name="lpBitmapName">A pointer to a null-terminated string that contains the name of the bitmap resource to be loaded.</param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the specified bitmap.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadBitmapW", ExactSpelling = true, SetLastError = true)]
        public static extern HBITMAP LoadBitmap([In] HINSTANCE hInstance, [MarshalAs(UnmanagedType.LPWStr)][In] string lpBitmapName);

        /// <summary>
        /// <para>
        /// The <see cref="LockWindowUpdate"/> function disables or enables drawing in the specified window.
        /// Only one window can be locked at a time.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-lockwindowupdate"/>
        /// </para>
        /// </summary>
        /// <param name="hWndLock">
        /// The window in which drawing will be disabled.
        /// If this parameter is <see cref="NULL"/>, drawing in the locked window is enabled.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>, indicating that an error occurred or another window was already locked.
        /// </returns>
        /// <remarks>
        /// The purpose of the <see cref="LockWindowUpdate"/> function is to permit drag/drop feedback to be drawn over a window
        /// without interference from the window itself.
        /// The intent is that the window is locked when feedback is drawn and unlocked when feedback is complete.
        /// <see cref="LockWindowUpdate"/> is not intended for general-purpose suppression of window redraw.
        /// Use the <see cref="WM_SETREDRAW"/> message to disable redrawing of a particular window.
        /// If an application with a locked window (or any locked child windows) calls the <see cref="GetDC"/>,
        /// <see cref="GetDCEx"/>, or <see cref="BeginPaint"/> function, the called function returns a device context with a visible region that is empty.
        /// This will occur until the application unlocks the window by calling <see cref="LockWindowUpdate"/>,
        /// specifying a value of <see cref="NULL"/> for <paramref name="hWndLock"/>.
        /// If an application attempts to draw within a locked window, the system records the extent of the attempted operation in a bounding rectangle.
        /// When the window is unlocked, the system invalidates the area within this bounding rectangle,
        /// forcing an eventual <see cref="WM_PAINT"/> message to be sent to the previously locked window and its child windows.
        /// If no drawing has occurred while the window updates were locked, no area is invalidated.
        /// LockWindowUpdate does not make the specified window invisible and does not clear the <see cref="WS_VISIBLE"/> style bit.
        /// A locked window cannot be moved.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LockWindowUpdate", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL LockWindowUpdate([In] HWND hWndLock);

        /// <summary>
        /// <para>
        /// The <see cref="MapWindowPoints"/> function converts (maps) a set of points from a coordinate space relative
        /// to one window to a coordinate space relative to another window.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-mapwindowpoints"/>
        /// </para>
        /// </summary>
        /// <param name="hWndFrom">
        /// A handle to the window from which points are converted.
        /// If this parameter is <see cref="NULL"/> or <see cref="HWND_DESKTOP"/>, the points are presumed to be in screen coordinates.
        /// </param>
        /// <param name="hWndTo">
        /// A handle to the window to which points are converted.
        /// If this parameter is <see cref="NULL"/> or <see cref="HWND_DESKTOP"/>, the points are converted to screen coordinates.
        /// </param>
        /// <param name="lpPoints">
        /// A pointer to an array of <see cref="POINT"/> structures that contain the set of points to be converted.
        /// The points are in device units.
        /// This parameter can also point to a <see cref="RECT"/> structure, in which case the <paramref name="cPoints"/> parameter should be set to 2.
        /// </param>
        /// <param name="cPoints">
        /// The number of <see cref="POINT"/> structures in the array pointed to by the <paramref name="lpPoints"/> parameter.
        /// </param>
        /// <returns>
        /// If the function succeeds, the low-order word of the return value is the number of pixels added to the horizontal coordinate
        /// of each source point in order to compute the horizontal coordinate of each destination point.
        /// (In addition to that, if precisely one of hWndFrom and hWndTo is mirrored, then each resulting horizontal coordinate is multiplied by -1.)
        /// The high-order word is the number of pixels added to the vertical coordinate of each source point in order
        /// to compute the vertical coordinate of each destination point.
        /// If the function fails, the return value is zero.
        /// Call <see cref="SetLastError"/> prior to calling this method to differentiate an error return value from a legitimate "0" return value.
        /// </returns>
        /// <remarks>
        /// If <paramref name="hWndFrom"/> or <paramref name="hWndTo"/> (or both) are mirrored windows
        /// (that is, have <see cref="WS_EX_LAYOUTRTL"/> extended style) and precisely two points are passed in <paramref name="lpPoints"/>,
        /// <see cref="MapWindowPoints"/> will interpret those two points as a <see cref="RECT"/> and possibly automatically
        /// swap the left and right fields of that rectangle to ensure that left is not greater than right.
        /// If any number of points other than 2 is passed in <paramref name="lpPoints"/>,
        /// then <see cref="MapWindowPoints"/> will correctly map the coordinates of each of those points separately,
        /// so if you pass in a pointer to an array of more than one rectangle in <paramref name="lpPoints"/>,
        /// the new rectangles may get their left field greater than right.
        /// Thus, to guarantee the correct transformation of rectangle coordinates,
        /// you must call <see cref="MapWindowPoints"/> with one <see cref="RECT"/> pointer at a time,
        /// as shown in the following example:
        /// <code>
        /// RECT        rc[10];
        /// for(int i = 0; i &lt; (sizeof(rc)/sizeof(rc[0])); i++)
        /// {
        ///     MapWindowPoints(hWnd1, hWnd2, (LPPOINT)(&amp;rc[i]), (sizeof(RECT)/sizeof(POINT)) );
        /// }
        /// </code>
        /// Also, if you need to map precisely two independent points and don't want the <see cref="RECT"/> logic
        /// applied to them by <see cref="MapWindowPoints"/>, to guarantee the correct result you must call <see cref="MapWindowPoints"/>
        /// with one <see cref="POINT"/> pointer at a time, as shown in the following example:
        /// <code>
        ///  POINT pt[2];
        ///  MapWindowPoints(hWnd1, hWnd2, &amp;pt[0], 1);
        ///  MapWindowPoints(hWnd1, hWnd2, &amp;pt[1], 1);
        /// </code>
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "MapWindowPoints", ExactSpelling = true, SetLastError = true)]
        public static extern int MapWindowPoints([In] HWND hWndFrom, [In] HWND hWndTo, [MarshalAs(UnmanagedType.LPArray)][In][Out] POINT[] lpPoints,
            [In] UINT cPoints);

        /// <summary>
        /// <para>
        /// The <see cref="PrintWindow"/> function copies a visual window into the specified device context (DC), typically a printer DC.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-printwindow"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window that will be copied.
        /// </param>
        /// <param name="hdcBlt">
        /// A handle to the device context.
        /// </param>
        /// <param name="nFlags">
        /// The drawing options. It can be one of the following values.
        /// <see cref="PW_CLIENTONLY"/>
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns a <see cref="TRUE"/> value.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// Note  This is a blocking or synchronous function and might not return immediately.
        /// How quickly this function returns depends on run-time factors such as network status, print server configuration,
        /// and printer driver implementation—factors that are difficult to predict when writing an application.
        /// Calling this function from a thread that manages interaction with the user interface could make the application appear to be unresponsive.
        /// The application that owns the window referenced by <paramref name="hwnd"/> processes the <see cref="PrintWindow"/> call
        /// and renders the image in the device context that is referenced by <paramref name="hdcBlt"/>.
        /// The application receives a <see cref="WM_PRINT"/> message or,
        /// if the <see cref="PW_CLIENTONLY"/> flag is specified, a <see cref="WM_PRINTCLIENT"/> message.
        /// For more information, see <see cref="WM_PRINT"/> and <see cref="WM_PRINTCLIENT"/>. 
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "PrintWindow", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL PrintWindow([In] HWND hwnd, [In] HDC hdcBlt, [In] PrintWindowFlags nFlags);

        /// <summary>
        /// <para>
        /// The <see cref="RedrawWindow"/> function updates the specified rectangle or region in a window's client area.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-redrawwindow"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window to be redrawn.
        /// If this parameter is <see cref="NULL"/>, the desktop window is updated.
        /// </param>
        /// <param name="lprcUpdate">
        /// A pointer to a <see cref="RECT"/> structure containing the coordinates, in device units, of the update rectangle.
        /// This parameter is ignored if the <paramref name="hrgnUpdate"/> parameter identifies a region.
        /// </param>
        /// <param name="hrgnUpdate">
        /// A handle to the update region.
        /// If both the <paramref name="hrgnUpdate"/> and <paramref name="lprcUpdate"/> parameters are <see cref="NULL"/>,
        /// the entire client area is added to the update region.
        /// </param>
        /// <param name="flags">
        /// One or more redraw flags.
        /// This parameter can be used to invalidate or validate a window, control repainting,
        /// and control which windows are affected by <see cref="RedrawWindow"/>.
        /// The following flags are used to invalidate the window.
        /// <see cref="RDW_ERASE"/>, <see cref="RDW_FRAME"/>, <see cref="RDW_INTERNALPAINT"/>, <see cref="RDW_INVALIDATE"/>
        /// The following flags are used to validate the window.
        /// <see cref="RDW_NOERASE"/>, <see cref="RDW_NOFRAME"/>, <see cref="RDW_NOINTERNALPAINT"/>, <see cref="RDW_VALIDATE"/>
        /// The following flags control when repainting occurs. <see cref="RedrawWindow"/> will not repaint unless one of these flags is specified.
        /// <see cref="RDW_ERASENOW"/>, <see cref="RDW_UPDATENOW"/>
        /// By default, the windows affected by <see cref="RedrawWindow"/> depend on whether the specified window has the <see cref="WS_CLIPCHILDREN"/> style.
        /// Child windows that are not the <see cref="WS_CLIPCHILDREN"/> style are unaffected;
        /// non-<see cref="WS_CLIPCHILDREN"/> windows are recursively validated or invalidated until a <see cref="WS_CLIPCHILDREN"/> window is encountered.
        /// The following flags control which windows are affected by the <see cref="RedrawWindow"/> function.
        /// <see cref="RDW_ALLCHILDREN"/>, <see cref="RDW_NOCHILDREN"/>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// When <see cref="RedrawWindow"/> is used to invalidate part of the desktop window,
        /// the desktop window does not receive a <see cref="WM_PAINT"/> message.
        /// To repaint the desktop, an application uses the <see cref="RDW_ERASE"/> flag to generate a <see cref="WM_ERASEBKGND"/> message.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "RedrawWindow", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL RedrawWindow([In] HWND hWnd, [In] in RECT lprcUpdate, [In] HRGN hrgnUpdate, [In] RedrawWindowFlags flags);

        /// <summary>
        /// <para>
        /// The <see cref="ReleaseDC"/> function releases a device context (DC), freeing it for use by other applications.
        /// The effect of the <see cref="ReleaseDC"/> function depends on the type of DC. It frees only common and window DCs.
        /// It has no effect on class or private DCs.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-releasedc"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose DC is to be released.
        /// </param>
        /// <param name="hDC">
        /// A handle to the DC to be released.
        /// </param>
        /// <returns>
        /// The return value indicates whether the DC was released.
        /// If the DC was released, the return value is 1.
        /// If the DC was not released, the return value is 0.
        /// </returns>
        /// <remarks>
        /// The application must call the <see cref="ReleaseDC"/> function for each call to the <see cref="GetWindowDC"/> function
        /// and for each call to the GetDC function that retrieves a common DC.
        /// An application cannot use the <see cref="ReleaseDC"/> function to release a DC that was created by calling the <see cref="CreateDC"/> function;
        /// instead, it must use the <see cref="DeleteDC"/> function.
        /// <see cref="ReleaseDC"/> must be called from the same thread that called <see cref="GetDC"/>.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ReleaseDC", ExactSpelling = true, SetLastError = true)]
        public static extern int ReleaseDC([In] HWND hWnd, [In] HDC hDC);

        /// <summary>
        /// <para>
        /// The <see cref="ScreenToClient"/> function converts the screen coordinates of a specified point on the screen to client-area coordinates.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-screentoclient"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose client area will be used for the conversion.
        /// </param>
        /// <param name="lpPoint">
        /// A pointer to a <see cref="POINT"/> structure that specifies the screen coordinates to be converted.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The function uses the window identified by the <paramref name="hWnd"/> parameter
        /// and the screen coordinates given in the <see cref="POINT"/> structure to compute client coordinates.
        /// It then replaces the screen coordinates with the client coordinates.
        /// The new coordinates are relative to the upper-left corner of the specified window's client area.
        /// The <see cref="ScreenToClient"/> function assumes the specified point is in screen coordinates.
        /// All coordinates are in device units.
        /// Do not use <see cref="ScreenToClient"/> when in a mirroring situation, that is, when changing from left-to-right layout to right-to-left layout.
        /// Instead, use <see cref="MapWindowPoints"/>.
        /// For more information, see "Window Layout and Mirroring" in Window Features.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ScreenToClient", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ScreenToClient([In] HWND hWnd, [In][Out] ref POINT lpPoint);

        /// <summary>
        /// <para>
        /// The <see cref="TabbedTextOut"/> function writes a character string at a specified location,
        /// expanding tabs to the values specified in an array of tab-stop positions.
        /// Text is written in the currently selected font, background color, and text color.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-tabbedtextoutw"/>
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
        /// If the <paramref name="nTabPositions"/> parameter is zero and the <paramref name="lpnTabStopPositions"/> parameter is <see cref="NULL"/>,
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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "TabbedTextOutW", ExactSpelling = true, SetLastError = true)]
        public static extern LONG TabbedTextOut([In] HDC hdc, [In] int x, [In] int y, [In] LPCWSTR lpString,
            [In] int chCount, [In] int nTabPositions, [MarshalAs(UnmanagedType.LPArray)][In] INT[] lpnTabStopPositions, [In] int nTabOrigin);

        /// <summary>
        /// <para>
        /// The <see cref="UpdateWindow"/> function updates the client area of the specified window
        /// by sending a <see cref="WM_PAINT"/> message to the window if the window's update region is not empty.
        /// The function sends a <see cref="WM_PAINT"/> message directly to the window procedure of the specified window,
        /// bypassing the application queue.
        /// If the update region is empty, no message is sent.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-updatewindow"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// Handle to the window to be updated.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "UpdateWindow", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL UpdateWindow([In] HWND hWnd);

        /// <summary>
        /// <para>
        /// The <see cref="ValidateRect"/> function validates the client area within a rectangle
        /// by removing the rectangle from the update region of the specified window.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-validaterect"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// Handle to the window whose update region is to be modified.
        /// If this parameter is <see cref="NULL"/>, the system invalidates and redraws all windows
        /// and sends the <see cref="WM_ERASEBKGND"/> and <see cref="WM_NCPAINT"/> messages to the window procedure before the function returns.
        /// </param>
        /// <param name="lpRect">
        /// Pointer to a <see cref="RECT"/> structure that contains the client coordinates of the rectangle to be removed from the update region.
        /// If this parameter is <see cref="NULL"/>, the entire client area is removed.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="BeginPaint"/> function automatically validates the entire client area.
        /// Neither the <see cref="ValidateRect"/> nor <see cref="ValidateRgn"/> function should be called
        /// if a portion of the update region must be validated before the next <see cref="WM_PAINT"/> message is generated.
        /// The system continues to generate <see cref="WM_PAINT"/> messages until the current update region is validated.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ValidateRect", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ValidateRect([In] HWND hWnd, [In] in RECT lpRect);

        /// <summary>
        /// <para>
        /// The <see cref="ValidateRgn"/> function validates the client area within a region
        /// by removing the region from the current update region of the specified window.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-validatergn"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// Handle to the window whose update region is to be modified.
        /// </param>
        /// <param name="hRgn">
        /// Handle to a region that defines the area to be removed from the update region.
        /// If this parameter is <see cref="NULL"/>, the entire client area is removed.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The specified region must have been created by a region function.
        /// The region coordinates are assumed to be client coordinates.
        /// The <see cref="BeginPaint"/> function automatically validates the entire client area.
        /// Neither the <see cref="ValidateRect"/> nor <see cref="ValidateRgn"/> function should be called
        /// if a portion of the update region must be validated before the next <see cref="WM_PAINT"/> message is generated.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ValidateRgn", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ValidateRgn([In] HWND hWnd, [In] HRGN hRgn);
    }
}
