using Lsj.Util.Win32.Attributes;
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
using static Lsj.Util.Win32.Enums.DrawEdgeBorderTypes;
using static Lsj.Util.Win32.Enums.DrawEdgeTypes;
using static Lsj.Util.Win32.Enums.DrawFrameControlStates;
using static Lsj.Util.Win32.Enums.DrawFrameControlTypes;
using static Lsj.Util.Win32.Enums.DrawTextFormatFlags;
using static Lsj.Util.Win32.Enums.ExtendedWindowStyles;
using static Lsj.Util.Win32.Enums.GetDCExFlags;
using static Lsj.Util.Win32.Enums.LoadResourceFlags;
using static Lsj.Util.Win32.Enums.MappingModes;
using static Lsj.Util.Win32.Enums.PrintWindowFlags;
using static Lsj.Util.Win32.Enums.RasterCodes;
using static Lsj.Util.Win32.Enums.RedrawWindowFlags;
using static Lsj.Util.Win32.Enums.RegionFlags;
using static Lsj.Util.Win32.Enums.SystemColors;
using static Lsj.Util.Win32.Enums.SystemParametersInfoParameters;
using static Lsj.Util.Win32.Enums.TextAlignments;
using static Lsj.Util.Win32.Enums.WindowClassStyles;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Enums.WindowStyles;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32
{
    public static partial class User32
    {
        /// <summary>
        /// <para>
        /// An application-defined callback function used with the <see cref="GrayString"/> function. It is used to draw a string.
        /// The <see cref="GRAYSTRINGPROC"/> type defines a pointer to this callback function.
        /// <c>GrayStringProc</c> (or <c>OutputProc</c>) is a placeholder for the application-defined or library-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nc-winuser-graystringproc"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1">
        /// A handle to a device context with a bitmap of at least the width and height
        /// specified by the <c>nWidth</c> and <c>nHeight</c> parameters passed to <see cref="GrayString"/>.
        /// This parameter is typically named <c>hDc</c>.
        /// </param>
        /// <param name="unnamedParam2">
        /// A pointer to the string to be drawn.
        /// This parameter is typically named <c>lpData</c>.
        /// </param>
        /// <param name="unnamedParam3">
        /// The length, in characters, of the string.
        /// This parameter is typically named <c>nCount</c>.
        /// </param>
        /// <returns>
        /// If it succeeds, the callback function should return <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// The parameters are defined in the header with no names: <c>typedef BOOL (CALLBACK* GRAYSTRINGPROC)(HDC, LPARAM, int);</c>.
        /// Therefore, the syntax block lists them as <c>unnamedParam1</c> - <c>unnamedParam3</c>.
        /// You can name these parameters anything in your app.
        /// However, they are usually named as shown in the parameter descriptions.
        /// </para>
        /// <para>
        /// The callback function must draw an image relative to the coordinates (0,0).
        /// </para>
        /// </remarks>
        public delegate BOOL Graystringproc([In] HDC unnamedParam1, [In] LPARAM unnamedParam2, [In] int unnamedParam3);


        /// <summary>
        /// <para>
        /// The <see cref="BeginPaint"/> function prepares the specified window for painting
        /// and fills a <see cref="PAINTSTRUCT"/> structure with information about the painting.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-beginpaint"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// Handle to the window to be repainted.
        /// </param>
        /// <param name="lpPaint">
        /// Pointer to the <see cref="PAINTSTRUCT"/> structure that will receive painting information.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the handle to a display device context for the specified window.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>, indicating that no display device context is available.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="BeginPaint"/> function automatically sets the clipping region of the device context to exclude any area outside the update region.
        /// The update region is set by the <see cref="InvalidateRect"/> or <see cref="InvalidateRgn"/> function
        /// and by the system after sizing, moving, creating, scrolling, or any other operation that affects the client area.
        /// If the update region is marked for erasing, <see cref="BeginPaint"/> sends a <see cref="WM_ERASEBKGND"/> message to the window.
        /// </para>
        /// <para>
        /// An application should not call <see cref="BeginPaint"/> except in response to a <see cref="WM_PAINT"/> message.
        /// Each call to <see cref="BeginPaint"/> must have a corresponding call to the <see cref="EndPaint"/> function.
        /// </para>
        /// <para>
        /// If the caret is in the area to be painted, <see cref="BeginPaint"/> automatically hides the caret to prevent it from being erased.
        /// </para>
        /// <para>
        /// If the window's class has a background brush,
        /// <see cref="BeginPaint"/> uses that brush to erase the background of the update region before returning.
        /// </para>
        /// <para>
        /// DPI Virtualization
        /// </para>
        /// <para>
        /// This API does not participate in DPI virtualization.
        /// The output returned is always in terms of physical pixels.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "BeginPaint", ExactSpelling = true)]
        public static extern HDC BeginPaint([In] HWND hWnd, [Out] out PAINTSTRUCT lpPaint);

        /// <summary>
        /// <para>
        /// The <see cref="ClientToScreen"/> function converts the client-area coordinates of a specified point to screen coordinates.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-clienttoscreen"/>
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
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="ClientToScreen"/> function replaces the client-area coordinates in the <see cref="POINT"/> structure with the screen coordinates.
        /// The screen coordinates are relative to the upper-left corner of the screen.
        /// Note, a screen-coordinate point that is above the window's client area has a negative y-coordinate.
        /// Similarly, a screen coordinate to the left of a client area has a negative x-coordinate.
        /// </para>
        /// <para>
        /// All coordinates are device coordinates.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ClientToScreen", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ClientToScreen([In] HWND hWnd, [In][Out] ref POINT lpPoint);

        /// <summary>
        /// <para>
        /// The <see cref="DrawEdge"/> function draws one or more edges of rectangle.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-drawedge"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="qrc">
        /// A pointer to a <see cref="RECT"/> structure that contains the logical coordinates of the rectangle.
        /// </param>
        /// <param name="edge">
        /// <para>
        /// The type of inner and outer edges to draw.
        /// This parameter must be a combination of one inner-border flag and one outer-border flag.
        /// The inner-border flags are as follows.
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
        /// <see cref="BDR_RAISEDINNER"/>
        /// </term>
        /// <term>
        /// Raised inner edge.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BDR_SUNKENINNER"/>
        /// </term>
        /// <term>
        /// Sunken inner edge.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The outer-border flags are as follows.
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
        /// <see cref="BDR_RAISEDOUTER"/>
        /// </term>
        /// <term>
        /// Raised outer edge.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BDR_SUNKENOUTER"/>
        /// </term>
        /// <term>
        /// Sunken outer edge.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Alternatively, the <paramref name="edge"/> parameter can specify one of the following flags.
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
        /// <see cref="EDGE_BUMP"/>
        /// </term>
        /// <term>
        /// Combination of <see cref="BDR_RAISEDOUTER"/> and <see cref="BDR_SUNKENINNER"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="EDGE_ETCHED"/>
        /// </term>
        /// <term>
        /// Combination of <see cref="BDR_SUNKENOUTER"/> and <see cref="BDR_RAISEDINNER"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="EDGE_RAISED"/>
        /// </term>
        /// <term>
        /// Combination of <see cref="BDR_RAISEDOUTER"/> and <see cref="BDR_RAISEDINNER"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="EDGE_SUNKEN"/>
        /// </term>
        /// <term>
        /// Combination of <see cref="BDR_SUNKENOUTER"/> and <see cref="BDR_SUNKENINNER"/>.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="grfFlags">
        /// <para>
        /// The type of border.
        /// This parameter can be a combination of the following values.
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
        /// <see cref="BF_ADJUST"/>
        /// </term>
        /// <term>
        /// <para>
        /// If this flag is passed, shrink the rectangle pointed to by the <paramref name="qrc"/> parameter to exclude the edges that were drawn.
        /// </para>
        /// <para>
        /// If this flag is not passed, then do not change the rectangle pointed to by the <paramref name="qrc"/> parameter.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BF_BOTTOM"/>
        /// </term>
        /// <term>
        /// Bottom of border rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BF_BOTTOMLEFT"/>
        /// </term>
        /// <term>
        /// Bottom and left side of border rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BF_BOTTOMRIGHT"/>
        /// </term>
        /// <term>
        /// Bottom and right side of border rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BF_DIAGONAL"/>
        /// </term>
        /// <term>
        /// Diagonal border.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BF_DIAGONAL_ENDBOTTOMLEFT"/>
        /// </term>
        /// <term>
        /// Diagonal border.
        /// The end point is the lower-left corner of the rectangle; the origin is top-right corner.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BF_DIAGONAL_ENDBOTTOMRIGHT"/>
        /// </term>
        /// <term>
        /// Diagonal border.
        /// The end point is the lower-right corner of the rectangle; the origin is top-left corner.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BF_DIAGONAL_ENDTOPLEFT"/>
        /// </term>
        /// <term>
        /// Diagonal border.
        /// The end point is the top-left corner of the rectangle; the origin is lower-right corner.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BF_DIAGONAL_ENDTOPRIGHT"/>
        /// </term>
        /// <term>
        /// Diagonal border.
        /// The end point is the top-right corner of the rectangle; the origin is lower-left corner.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BF_FLAT"/>
        /// </term>
        /// <term>
        /// Flat border.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BF_LEFT"/>
        /// </term>
        /// <term>
        /// Left side of border rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BF_MIDDLE"/>
        /// </term>
        /// <term>
        /// Interior of rectangle to be filled.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BF_MONO"/>
        /// </term>
        /// <term>
        /// One-dimensional border.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BF_RECT"/>
        /// </term>
        /// <term>
        /// Entire border rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BF_RIGHT"/>
        /// </term>
        /// <term>
        /// Right side of border rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BF_SOFT"/>
        /// </term>
        /// <term>
        /// Soft buttons instead of tiles.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BF_TOP"/>
        /// </term>
        /// <term>
        /// Top of border rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BF_TOPLEFT"/>
        /// </term>
        /// <term>
        /// Top and left side of border rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BF_TOPRIGHT"/>
        /// </term>
        /// <term>
        /// Top and right side of border rectangle.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DrawEdge", ExactSpelling = true)]
        public static extern BOOL DrawEdge([In] HDC hdc, [In] in RECT qrc, [In] DrawEdgeTypes edge, [In] DrawEdgeBorderTypes grfFlags);

        /// <summary>
        /// <para>
        /// The <see cref="DrawFocusRect"/> function draws a rectangle in the style used to indicate that the rectangle has the focus.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-drawfocusrect"/>
        /// </para>
        /// </summary>
        /// <param name="hDC">
        /// A handle to the device context.
        /// </param>
        /// <param name="lprc">
        /// A pointer to a <see cref="RECT"/> structure that specifies the logical coordinates of the rectangle.
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
        /// <see cref="DrawFocusRect"/> works only in <see cref="MM_TEXT"/> mode.
        /// </para>
        /// <para>
        /// Because <see cref="DrawFocusRect"/> is an XOR function, calling it a second time with the same rectangle removes the rectangle from the screen.
        /// </para>
        /// <para>
        /// This function draws a rectangle that cannot be scrolled.
        /// To scroll an area containing a rectangle drawn by this function, call <see cref="DrawFocusRect"/> to remove the rectangle from the screen,
        /// scroll the area, and then call <see cref="DrawFocusRect"/> again to draw the rectangle in the new position.
        /// </para>
        /// <para>
        /// Windows XP:
        /// The focus rectangle can now be thicker than 1 pixel, so it is more visible for high-resolution, high-density displays and accessibility needs.
        /// This is handled by the <see cref="SPI_SETFOCUSBORDERWIDTH"/> and <see cref="SPI_SETFOCUSBORDERHEIGHT"/> in <see cref="SystemParametersInfo"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DrawFocusRect", ExactSpelling = true)]
        public static extern BOOL DrawFocusRect([In] HDC hDC, [In] in RECT lprc);

        /// <summary>
        /// <para>
        /// The <see cref="DrawFrameControl"/> function draws a frame control of the specified type and style.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-drawframecontrol"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context of the window in which to draw the control.
        /// </param>
        /// <param name="lprc">
        /// A pointer to a <see cref="RECT"/> structure that contains the logical coordinates of the bounding rectangle for frame control.
        /// </param>
        /// <param name="uType">
        /// <para>
        /// The type of frame control to draw.
        /// This parameter can be one of the following values.
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
        /// <see cref="DFC_BUTTON"/>
        /// </term>
        /// <term>
        /// Standard button
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DFC_CAPTION"/>
        /// </term>
        /// <term>
        /// Title bar
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DFC_MENU"/>
        /// </term>
        /// <term>
        /// Menu bar
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DFC_POPUPMENU"/>
        /// </term>
        /// <term>
        /// Popup menu item.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DFC_SCROLL"/>
        /// </term>
        /// <term>
        /// Scroll bar
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="uState">
        /// <para>
        /// The initial state of the frame control.
        /// If <paramref name="uType"/> is <see cref="DFC_BUTTON"/>, <paramref name="uState"/> can be one of the following values.
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
        /// <see cref="DFCS_BUTTON3STATE"/>
        /// </term>
        /// <term>
        /// Three-state button
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DFCS_BUTTONCHECK"/>
        /// </term>
        /// <term>
        /// Check box
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DFCS_BUTTONPUSH"/>
        /// </term>
        /// <term>
        /// Push button
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DFCS_BUTTONRADIO"/>
        /// </term>
        /// <term>
        /// Radio button
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DFCS_BUTTONRADIOIMAGE"/>
        /// </term>
        /// <term>
        /// Image for radio button (nonsquare needs image)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DFCS_BUTTONRADIOMASK"/>
        /// </term>
        /// <term>
        /// Mask for radio button (nonsquare needs mask)
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If <paramref name="uType"/> is <see cref="DFC_CAPTION"/>, <paramref name="uState"/> can be one of the following values.
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
        /// <see cref="DFCS_CAPTIONCLOSE"/>
        /// </term>
        /// <term>
        /// <c>Close</c> button
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DFCS_CAPTIONHELP"/>
        /// </term>
        /// <term>
        /// <c>Help</c> button
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DFCS_CAPTIONMAX"/>
        /// </term>
        /// <term>
        /// <c>Maximize</c> button
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DFCS_CAPTIONMIN"/>
        /// </term>
        /// <term>
        /// <c>Minimize</c> button
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DFCS_CAPTIONRESTORE"/>
        /// </term>
        /// <term>
        /// <c>Restore</c> button
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If <paramref name="uType"/> is <see cref="DFC_MENU"/>, <paramref name="uState"/> can be one of the following values.
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
        /// <see cref="DFCS_MENUARROW"/>
        /// </term>
        /// <term>
        /// Submenu arrow
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DFCS_MENUARROWRIGHT"/>
        /// </term>
        /// <term>
        /// Submenu arrow pointing left.
        /// This is used for the right-to-left cascading menus used with right-to-left languages such as Arabic or Hebrew.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DFCS_MENUBULLET"/>
        /// </term>
        /// <term>
        /// Bullet
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DFCS_MENUCHECK"/>
        /// </term>
        /// <term>
        /// Check mark
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If <paramref name="uType"/> is <see cref="DFC_SCROLL"/>, <paramref name="uState"/> can be one of the following values.
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
        /// <see cref="DFCS_SCROLLCOMBOBOX"/>
        /// </term>
        /// <term>
        /// Combo box scroll bar
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DFCS_SCROLLDOWN"/>
        /// </term>
        /// <term>
        /// Down arrow of scroll bar
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DFCS_SCROLLLEFT"/>
        /// </term>
        /// <term>
        /// Left arrow of scroll bar
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DFCS_SCROLLRIGHT"/>
        /// </term>
        /// <term>
        /// Right arrow of scroll bar
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DFCS_SCROLLSIZEGRIP"/>
        /// </term>
        /// <term>
        /// Size grip in lower-right corner of window
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DFCS_SCROLLSIZEGRIPRIGHT"/>
        /// </term>
        /// <term>
        /// Size grip in lower-left corner of window.
        /// This is used with right-to-left languages such as Arabic or Hebrew.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DFCS_SCROLLUP"/>
        /// </term>
        /// <term>
        /// Up arrow of scroll bar
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The following style can be used to adjust the bounding rectangle of the push button.
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
        /// <see cref="DFCS_ADJUSTRECT"/>
        /// </term>
        /// <term>
        /// Bounding rectangle is adjusted to exclude the surrounding edge of the push button.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// One or more of the following values can be used to set the state of the control to be drawn.
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
        /// <see cref="DFCS_CHECKED"/>
        /// </term>
        /// <term>
        /// Button is checked.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DFCS_FLAT"/>
        /// </term>
        /// <term>
        /// Button has a flat border.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DFCS_HOT"/>
        /// </term>
        /// <term>
        /// Button is hot-tracked.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DFCS_INACTIVE"/>
        /// </term>
        /// <term>
        /// Button is inactive (grayed).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DFCS_MONO"/>
        /// </term>
        /// <term>
        /// Button has a monochrome border.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DFCS_PUSHED"/>
        /// </term>
        /// <term>
        /// Button is pushed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DFCS_TRANSPARENT"/>
        /// </term>
        /// <term>
        /// The background remains untouched.
        /// This flag can only be combined with <see cref="DFCS_MENUARROWUP"/> or <see cref="DFCS_MENUARROWDOWN"/>.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
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
        /// If <paramref name="uType"/> is either <see cref="DFC_MENU"/> or <see cref="DFC_BUTTON"/> and <paramref name="uState"/> is not <see cref="DFCS_BUTTONPUSH"/>,
        /// the frame control is a black-on-white mask (that is, a black frame control on a white background).
        /// In such cases, the application must pass a handle to a bitmap memory device control.
        /// The application can then use the associated bitmap as the hbmMask parameter to the MaskBlt function,
        /// or it can use the device context as a parameter to the <see cref="BitBlt"/> function using ROPs such as <see cref="SRCAND"/> and <see cref="SRCINVERT"/>.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DrawFrameControl", ExactSpelling = true)]
        public static extern BOOL DrawFrameControl([In] HDC hdc, [In] in RECT lprc, [In] DrawFrameControlTypes uType, [In] DrawFrameControlStates uState);

        /// <summary>
        /// <para>
        /// The <see cref="DrawText"/> function draws formatted text in the specified rectangle.
        /// It formats the text according to the specified method (expanding tabs, justifying characters, breaking lines, and so forth).
        /// To specify additional formatting options, use the <see cref="DrawTextEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-drawtextw"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lpchText">
        /// <para>
        /// A pointer to the string that specifies the text to be drawn.
        /// If the <paramref name="cchText"/> parameter is -1, the string must be null-terminated.
        /// </para>
        /// <para>
        /// If <paramref name="format"/> includes <see cref="DT_MODIFYSTRING"/>, the function could add up to four additional characters to this string.
        /// The buffer containing the string should be large enough to accommodate these extra characters.
        /// </para>
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
        /// <para>
        /// The method of formatting the text. This parameter can be one or more of the following values.
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
        /// <see cref="DT_BOTTOM"/>
        /// </term>
        /// <term>
        /// Justifies the text to the bottom of the rectangle.
        /// This value is used only with the <see cref="DT_SINGLELINE"/> value.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_CALCRECT"/>
        /// </term>
        /// <term>
        /// Determines the width and height of the rectangle.
        /// If there are multiple lines of text, <see cref="DrawText"/> uses the width of the rectangle pointed to by the <paramref name="lprc"/> parameter
        /// and extends the base of the rectangle to bound the last line of text.
        /// If the largest word is wider than the rectangle, the width is expanded.
        /// If the text is less than the width of the rectangle, the width is reduced.
        /// If there is only one line of text, <see cref="DrawText"/> modifies the right side of the rectangle so that it bounds the last character in the line.
        /// In either case, <see cref="DrawText"/> returns the height of the formatted text but does not draw the text.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_CENTER"/>
        /// </term>
        /// <term>
        /// Centers text horizontally in the rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_EDITCONTROL"/>
        /// </term>
        /// <term>
        /// Duplicates the text-displaying characteristics of a multiline edit control.
        /// Specifically, the average character width is calculated in the same manner as for an edit control,
        /// and the function does not display a partially visible last line.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_END_ELLIPSIS"/>
        /// </term>
        /// <term>
        /// <para>
        /// For displayed text, if the end of a string does not fit in the rectangle, it is truncated and ellipses are added.
        /// If a word that is not at the end of the string goes beyond the limits of the rectangle, it is truncated without ellipses.
        /// </para>
        /// <para>
        /// The string is not modified unless the <see cref="DT_MODIFYSTRING"/> flag is specified.
        /// </para>
        /// <para>
        /// Compare with <see cref="DT_PATH_ELLIPSIS"/> and <see cref="DT_WORD_ELLIPSIS"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_EXPANDTABS"/>
        /// </term>
        /// <term>
        /// Expands tab characters.
        /// The default number of characters per tab is eight.
        /// The <see cref="DT_WORD_ELLIPSIS"/>, <see cref="DT_PATH_ELLIPSIS"/>,
        /// and <see cref="DT_END_ELLIPSIS"/> values cannot be used with the <see cref="DT_EXPANDTABS"/> value.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_EXTERNALLEADING"/>
        /// </term>
        /// <term>
        /// Includes the font external leading in line height.
        /// Normally, external leading is not included in the height of a line of text.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_HIDEPREFIX"/>
        /// </term>
        /// <term>
        /// <para>
        /// Ignores the ampersand (&amp;) prefix character in the text.
        /// The letter that follows will not be underlined, but other mnemonic-prefix characters are still processed.
        /// </para>
        /// <para>
        /// Example:
        /// </para>
        /// <para>
        /// input string: "A&amp;bc&amp;&amp;d"
        /// </para>
        /// <para>
        /// normal: "Ac&amp;d"
        /// </para>
        /// <para>
        /// <see cref="DT_HIDEPREFIX"/>: "Abc&amp;d"
        /// </para>
        /// <para>
        /// Compare with <see cref="DT_NOPREFIX"/> and <see cref="DT_PREFIXONLY"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_INTERNAL"/>
        /// </term>
        /// <term>
        /// Uses the system font to calculate text metrics.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_LEFT"/>
        /// </term>
        /// <term>
        /// Aligns text to the left.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_MODIFYSTRING"/>
        /// </term>
        /// <term>
        /// Modifies the specified string to match the displayed text.
        /// This value has no effect unless <see cref="DT_END_ELLIPSIS"/> or <see cref="DT_PATH_ELLIPSIS"/> is specified.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_NOCLIP"/>
        /// </term>
        /// <term>
        /// Draws without clipping.
        /// <see cref="DrawText"/> is somewhat faster when <see cref="DT_NOCLIP"/> is used.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_NOFULLWIDTHCHARBREAK"/>
        /// </term>
        /// <term>
        /// Prevents a line break at a DBCS (double-wide character string), so that the line breaking rule is equivalent to SBCS strings.
        /// For example, this can be used in Korean windows, for more readability of icon labels.
        /// This value has no effect unless <see cref="DT_WORDBREAK"/> is specified.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_NOPREFIX"/>
        /// </term>
        /// <term>
        /// <para>
        /// Turns off processing of prefix characters.
        /// Normally, <see cref="DrawText"/> interprets the mnemonic-prefix character &amp;
        /// as a directive to underscore the character that follows,
        /// and the mnemonic-prefix characters &amp;&amp; as a directive to print a single &amp;.
        /// By specifying <see cref="DT_NOPREFIX"/>, this processing is turned off.
        /// For example,
        /// </para>
        /// <para>
        /// Example:
        /// </para>
        /// <para>
        /// input string: "A&amp;bc&amp;&amp;d"
        /// </para>
        /// <para>
        /// normal: "Ac&amp;d"
        /// </para>
        /// <para>
        /// <see cref="DT_NOPREFIX"/>: "A&amp;bc&amp;&amp;d"
        /// </para>
        /// <para>
        /// Compare with <see cref="DT_HIDEPREFIX"/> and <see cref="DT_PREFIXONLY"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_PATH_ELLIPSIS"/>
        /// </term>
        /// <term>
        /// <para>
        /// For displayed text, replaces characters in the middle of the string with ellipses so that the result fits in the specified rectangle.
        /// If the string contains backslash (\\) characters, <see cref="DT_PATH_ELLIPSIS"/> preserves as much as possible of the text after the last backslash.
        /// </para>
        /// <para>
        /// The string is not modified unless the <see cref="DT_MODIFYSTRING"/> flag is specified.
        /// </para>
        /// <para>
        /// Compare with <see cref="DT_END_ELLIPSIS"/> and <see cref="DT_WORD_ELLIPSIS"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_PREFIXONLY"/>
        /// </term>
        /// <term>
        /// <para>
        /// Draws only an underline at the position of the character following the ampersand (&amp;) prefix character.
        /// Does not draw any other characters in the string.
        /// For example,
        /// </para>
        /// <para>
        /// Example:
        /// </para>
        /// <para>
        /// input string: "A&amp;bc&amp;&amp;d"n
        /// </para>
        /// <para>
        /// normal: "Ac&amp;d"
        /// </para>
        /// <para>
        /// <see cref="DT_PREFIXONLY"/>: " _ "
        /// </para>
        /// <para>
        /// Compare with <see cref="DT_HIDEPREFIX"/> and <see cref="DT_NOPREFIX"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_RIGHT"/>
        /// </term>
        /// <term>
        /// Aligns text to the right.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_RTLREADING"/>
        /// </term>
        /// <term>
        /// Layout in right-to-left reading order for bidirectional text when the font selected into the <paramref name="hdc"/> is a Hebrew or Arabic font.
        /// The default reading order for all text is left-to-right.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_SINGLELINE"/>
        /// </term>
        /// <term>
        /// Displays text on a single line only.
        /// Carriage returns and line feeds do not break the line.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_TABSTOP"/>
        /// </term>
        /// <term>
        /// Sets tab stops. Bits 15-8 (high-order byte of the low-order word) of the <paramref name="format"/> parameter specify the number of characters for each tab.
        /// The default number of characters per tab is eight.
        /// The <see cref="DT_CALCRECT"/>, <see cref="DT_EXTERNALLEADING"/>, <see cref="DT_INTERNAL"/>,
        /// <see cref="DT_NOCLIP"/>, and <see cref="DT_NOPREFIX"/> values cannot be used with the <see cref="DT_TABSTOP"/> value.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_TOP"/>
        /// </term>
        /// <term>
        /// Justifies the text to the top of the rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_VCENTER"/>
        /// </term>
        /// <term>
        /// Centers text vertically.
        /// This value is used only with the <see cref="DT_SINGLELINE"/> value.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_WORDBREAK"/>
        /// </term>
        /// <term>
        /// <para>
        /// Breaks words.
        /// Lines are automatically broken between words if a word would extend past the edge of the rectangle specified by the <paramref name="lprc"/> parameter.
        /// A carriage return-line feed sequence also breaks the line.
        /// </para>
        /// <para>
        /// If this is not specified, output is on one line.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_WORD_ELLIPSIS"/>
        /// </term>
        /// <term>
        /// <para>
        /// Truncates any word that does not fit in the rectangle and adds ellipses.
        /// </para>
        /// <para>
        /// Compare with <see cref="DT_END_ELLIPSIS"/> and <see cref="DT_PATH_ELLIPSIS"/>.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the height of the text in logical units.
        /// If <see cref="DT_VCENTER"/> or <see cref="DT_BOTTOM"/> is specified,
        /// the return value is the offset from <c>lpRect-&gt;top</c> to the bottom of the drawn text
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="DrawText"/> function uses the device context's selected font, text color, and background color to draw the text.
        /// Unless the <see cref="DT_NOCLIP"/> format is used, <see cref="DrawText"/> clips the text so that it does not appear outside the specified rectangle.
        /// Note that text with significant overhang may be clipped, for example, an initial "W" in the text string or text that is in italics.
        /// All formatting is assumed to have multiple lines unless the <see cref="DT_SINGLELINE"/> format is specified.
        /// </para>
        /// <para>
        /// If the selected font is too large for the specified rectangle,
        /// the <see cref="DrawText"/> function does not attempt to substitute a smaller font.
        /// </para>
        /// <para>
        /// The text alignment mode for the device context must include the <see cref="TA_LEFT"/>, <see cref="TA_TOP"/>, and <see cref="TA_NOUPDATECP"/> flags.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DrawTextW", ExactSpelling = true)]
        public static extern int DrawText([In] HDC hdc, [In] LPCWSTR lpchText, [In] int cchText,
            [In] in RECT lprc, [In] DrawTextFormatFlags format);

        /// <summary>
        /// <para>
        /// The <see cref="DrawTextEx"/> function draws formatted text in the specified rectangle.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-drawtextexw"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context in which to draw.
        /// </param>
        /// <param name="lpchText">
        /// <para>
        /// A pointer to the string that contains the text to draw. If the <paramref name="cchText"/> parameter is -1, the string must be null-terminated.
        /// </para>
        /// <para>
        /// If <paramref name="format"/> includes <see cref="DT_MODIFYSTRING"/>, the function could add up to four additional characters to this string.
        /// The buffer containing the string should be large enough to accommodate these extra characters.
        /// </para>
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
        /// <para>
        /// The formatting options. This parameter can be one or more of the following values.
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
        /// <see cref="DT_BOTTOM"/>
        /// </term>
        /// <term>
        /// Justifies the text to the bottom of the rectangle.
        /// This value is used only with the <see cref="DT_SINGLELINE"/> value.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_CALCRECT"/>
        /// </term>
        /// <term>
        /// Determines the width and height of the rectangle.
        /// If there are multiple lines of text, <see cref="DrawTextEx"/> uses the width of the rectangle pointed to by the <paramref name="lprc"/> parameter
        /// and extends the base of the rectangle to bound the last line of text.
        /// If there is only one line of text, <see cref="DrawTextEx"/> modifies the right side of the rectangle
        /// so that it bounds the last character in the line.
        /// In either case, <see cref="DrawTextEx"/> returns the height of the formatted text, but does not draw the text.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_CENTER"/>
        /// </term>
        /// <term>
        /// Centers text horizontally in the rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_EDITCONTROL"/>
        /// </term>
        /// <term>
        /// Duplicates the text-displaying characteristics of a multiline edit control.
        /// Specifically, the average character width is calculated in the same manner as for an edit control,
        /// and the function does not display a partially visible last line.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_END_ELLIPSIS"/>
        /// </term>
        /// <term>
        /// <para>
        /// For displayed text, replaces the end of a string with ellipses so that the result fits in the specified rectangle.
        /// Any word (not at the end of the string) that goes beyond the limits of the rectangle is truncated without ellipses.
        /// The string is not modified unless the <see cref="DT_MODIFYSTRING"/> flag is specified.
        /// </para>
        /// <para>
        /// Compare with <see cref="DT_PATH_ELLIPSIS"/> and <see cref="DT_WORD_ELLIPSIS"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_EXPANDTABS"/>
        /// </term>
        /// <term>
        /// Expands tab characters.
        /// The default number of characters per tab is eight.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_EXTERNALLEADING"/>
        /// </term>
        /// <term>
        /// Includes the font external leading in line height.
        /// Normally, external leading is not included in the height of a line of text.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_HIDEPREFIX"/>
        /// </term>
        /// <term>
        /// <para>
        /// Ignores the ampersand (&amp;) prefix character in the text.
        /// The letter that follows will not be underlined, but other mnemonic-prefix characters are still processed.
        /// </para>
        /// <para>
        /// Example:
        /// </para>
        /// <para>
        /// input string: "A&amp;bc&amp;&amp;d"
        /// </para>
        /// <para>
        /// normal: "Ac&amp;d"
        /// </para>
        /// <para>
        /// <see cref="DT_HIDEPREFIX"/>: "Abc&amp;d"
        /// </para>
        /// <para>
        /// Compare with <see cref="DT_NOPREFIX"/> and <see cref="DT_PREFIXONLY"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_INTERNAL"/>
        /// </term>
        /// <term>
        /// Uses the system font to calculate text metrics.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_LEFT"/>
        /// </term>
        /// <term>
        /// Aligns text to the left.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_MODIFYSTRING"/>
        /// </term>
        /// <term>
        /// Modifies the specified string to match the displayed text.
        /// This value has no effect unless <see cref="DT_END_ELLIPSIS"/> or <see cref="DT_PATH_ELLIPSIS"/> is specified.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_NOCLIP"/>
        /// </term>
        /// <term>
        /// Draws without clipping.
        /// <see cref="DrawTextEx"/> is somewhat faster when <see cref="DT_NOCLIP"/> is used.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_NOFULLWIDTHCHARBREAK"/>
        /// </term>
        /// <term>
        /// Prevents a line break at a DBCS (double-wide character string), so that the line-breaking rule is equivalent to SBCS strings.
        /// For example, this can be used in Korean windows, for more readability of icon labels.
        /// This value has no effect unless <see cref="DT_WORDBREAK"/> is specified.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_NOPREFIX"/>
        /// </term>
        /// <term>
        /// Turns off processing of prefix characters.
        /// Normally, <see cref="DrawTextEx"/> interprets the ampersand (&amp;) mnemonic-prefix character as a directive to underscore the character that follows,
        /// and the double-ampersand (&amp;&amp;) mnemonic-prefix characters as a directive to print a single ampersand.
        /// By specifying <see cref="DT_NOPREFIX"/>, this processing is turned off.
        /// Compare with <see cref="DT_HIDEPREFIX"/> and <see cref="DT_PREFIXONLY"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_PATH_ELLIPSIS"/>
        /// </term>
        /// <term>
        /// <para>
        /// For displayed text, replaces characters in the middle of the string with ellipses so that the result fits in the specified rectangle.
        /// If the string contains backslash (\\) characters, <see cref="DT_PATH_ELLIPSIS"/> preserves as much as possible of the text after the last backslash.
        /// The string is not modified unless the <see cref="DT_MODIFYSTRING"/> flag is specified.
        /// </para>
        /// <para>
        /// Compare with <see cref="DT_END_ELLIPSIS"/> and <see cref="DT_WORD_ELLIPSIS"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_PREFIXONLY"/>
        /// </term>
        /// <term>
        /// <para>
        /// Draws only an underline at the position of the character following the ampersand (&amp;) prefix character.
        /// Does not draw any character in the string.
        /// </para>
        /// <para>
        /// Example:
        /// </para>
        /// <para>
        /// input string: "A&amp;bc&amp;&amp;d"
        /// </para>
        /// <para>
        /// normal: "Ac&amp;d"
        /// </para>
        /// <para>
        /// <see cref="DT_PREFIXONLY"/>: " _ "
        /// </para>
        /// <para>
        /// Compare with <see cref="DT_NOPREFIX"/> and <see cref="DT_HIDEPREFIX"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_RIGHT"/>
        /// </term>
        /// <term>
        /// Aligns text to the right.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_RTLREADING"/>
        /// </term>
        /// <term>
        /// Layout in right-to-left reading order for bidirectional text when the font selected into the <paramref name="hdc"/> is a Hebrew or Arabic font.
        /// The default reading order for all text is left-to-right.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_SINGLELINE"/>
        /// </term>
        /// <term>
        /// Displays text on a single line only.
        /// Carriage returns and line feeds do not break the line.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_TABSTOP"/>
        /// </term>
        /// <term>
        /// Sets tab stops.
        /// The <see cref="DRAWTEXTPARAMS"/> structure pointed to by the <paramref name="lpdtp"/> parameter specifies the number of average character widths per tab stop.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_TOP"/>
        /// </term>
        /// <term>
        /// Justifies the text to the top of the rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_VCENTER"/>
        /// </term>
        /// <term>
        /// Centers text vertically.
        /// This value is used only with the <see cref="DT_SINGLELINE"/> value.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_WORDBREAK"/>
        /// </term>
        /// <term>
        /// Breaks words. Lines are automatically broken between words
        /// if a word extends past the edge of the rectangle specified by the <paramref name="lprc"/> parameter.
        /// A carriage return-line feed sequence also breaks the line.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_WORD_ELLIPSIS"/>
        /// </term>
        /// <term>
        /// <para>
        /// Truncates any word that does not fit in the rectangle and adds ellipses.
        /// </para>
        /// <para>
        /// Compare with <see cref="DT_END_ELLIPSIS"/> and <see cref="DT_PATH_ELLIPSIS"/>.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpdtp">
        /// A pointer to a <see cref="DRAWTEXTPARAMS"/> structure that specifies additional formatting options.
        /// This parameter can be <see cref="NullRef{DRAWTEXTPARAMS}"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the text height in logical units.
        /// If <see cref="DT_VCENTER"/> or <see cref="DT_BOTTOM"/> is specified,
        /// the return value is the offset from <c>lprc-&gt;top</c> to the bottom of the drawn text.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="DrawTextEx"/> function supports only fonts whose escapement and orientation are both zero.
        /// </para>
        /// <para>
        /// The text alignment mode for the device context must include the <see cref="TA_LEFT"/>, <see cref="TA_TOP"/>, and <see cref="TA_NOUPDATECP"/> flags.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DrawTextExW", ExactSpelling = true)]
        public static extern int DrawTextEx([In] HDC hdc, [In] LPCWSTR lpchText, [In] int cchText,
            [In] in RECT lprc, [In] DrawTextFormatFlags format, [In] in DRAWTEXTPARAMS lpdtp);

        /// <summary>
        /// <para>
        /// The <see cref="EndPaint"/> function marks the end of painting in the specified window.
        /// This function is required for each call to the <see cref="BeginPaint"/> function, but only after painting is complete.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-endpaint"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// Handle to the window that has been repainted.
        /// </param>
        /// <param name="lpPaint">
        /// Pointer to a <see cref="PAINTSTRUCT"/> structure that contains the painting information retrieved by <see cref="BeginPaint"/>.
        /// </param>
        /// <returns>
        /// The return value is always nonzero.
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the caret was hidden by <see cref="BeginPaint"/>, <see cref="EndPaint"/> restores the caret to the screen.
        /// </para>
        /// <para>
        /// <see cref="EndPaint"/> releases the display device context that <see cref="BeginPaint"/> retrieved.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EndPaint", ExactSpelling = true)]
        public static extern BOOL EndPaint([In] HWND hWnd, [In] in PAINTSTRUCT lpPaint);

        /// <summary>
        /// <para>
        /// The <see cref="ExcludeUpdateRgn"/> function prevents drawing within invalid areas of a window
        /// by excluding an updated region in the window from a clipping region.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-excludeupdatergn"/>
        /// </para>
        /// </summary>
        /// <param name="hDC">
        /// Handle to the device context associated with the clipping region.
        /// </param>
        /// <param name="hWnd">
        /// Handle to the window to update.
        /// </param>
        /// <returns>
        /// <para>
        /// The return value specifies the complexity of the excluded region; it can be any one of the following values.
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
        /// <see cref="COMPLEXREGION"/>
        /// </term>
        /// <term>
        /// Region consists of more than one rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR"/>
        /// </term>
        /// <term>
        /// An error occurred.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="NULLREGION"/>
        /// </term>
        /// <term>
        /// Region is empty.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SIMPLEREGION"/>
        /// </term>
        /// <term>
        /// Region is a single rectangle.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ExcludeUpdateRgn", ExactSpelling = true)]
        public static extern RegionFlags ExcludeUpdateRgn([In] HDC hDC, [In] HWND hWnd);

        /// <summary>
        /// <para>
        /// The <see cref="FillRect"/> function fills a rectangle by using the specified brush.
        /// This function includes the left and top borders, but excludes the right and bottom borders of the rectangle.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-fillrect"/>
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
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The brush identified by the <paramref name="hbr"/> parameter may be either a handle to a logical brush or a color value.
        /// If specifying a handle to a logical brush, call one of the following functions to obtain the handle:
        /// <see cref="CreateHatchBrush"/>, <see cref="CreatePatternBrush"/>, or <see cref="CreateSolidBrush"/>.
        /// Additionally, you may retrieve a handle to one of the stock brushes by using the <see cref="GetStockObject"/> function.
        /// If specifying a color value for the <paramref name="hbr"/> parameter,
        /// it must be one of the standard system colors (the value 1 must be added to the chosen color).
        /// For example:
        /// </para>
        /// <code>
        /// FillRect(hdc, &amp;rect, (HBRUSH) (COLOR_WINDOW+1));
        /// </code>
        /// <para>
        /// For a list of all the standard system colors, see <see cref="GetSysColor"/>.
        /// </para>
        /// <para>
        /// When filling the specified rectangle, <see cref="FillRect"/> does not include the rectangle's right and bottom sides.
        /// GDI fills a rectangle up to, but not including, the right column and bottom row, regardless of the current mapping mode.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "FillRect", ExactSpelling = true)]
        public static extern int FillRect([In] HDC hDC, [In] in RECT lprc, [In] HBRUSH hbr);

        /// <summary>
        /// <para>
        /// The <see cref="FrameRect"/> function draws a border around the specified rectangle by using the specified brush.
        /// The width and height of the border are always one logical unit.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-framerect"/>
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
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The brush identified by the <paramref name="hbr"/> parameter must have been created
        /// by using the <see cref="CreateHatchBrush"/>, <see cref="CreatePatternBrush"/>, or <see cref="CreateSolidBrush"/> function,
        /// or retrieved by using the <see cref="GetStockObject"/> function.
        /// </para>
        /// <para>
        /// If the <see cref="RECT.bottom"/> member of the <see cref="RECT"/> structure is less than the <see cref="RECT.top"/> member,
        /// or if the <see cref="RECT.right"/> member is less than the <see cref="RECT.left"/> member, the function does not draw the rectangle.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "FrameRect", ExactSpelling = true)]
        public static extern int FrameRect([In] HDC hDC, [In][Out] ref RECT lprc, [In] HBRUSH hbr);

        /// <summary>
        /// <para>
        /// The <see cref="GetDC"/> function retrieves a handle to a device context (DC) for the client area of a specified window or for the entire screen.
        /// You can use the returned handle in subsequent GDI functions to draw in the DC.
        /// The device context is an opaque data structure, whose values are used internally by GDI.
        /// </para>
        /// <para>
        /// The <see cref="GetDCEx"/> function is an extension to <see cref="GetDC"/>,
        /// which gives an application more control over how and whether clipping occurs in the client area.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getdc"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window whose DC is to be retrieved.
        /// If this value is <see cref="NULL"/>, <see cref="GetDC"/> retrieves the DC for the entire screen.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the DC for the specified window's client area.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="GetDC"/> function retrieves a common, class, or private DC depending on the class style of the specified window.
        /// For class and private DCs, <see cref="GetDC"/> leaves the previously assigned attributes unchanged.
        /// However, for common DCs, <see cref="GetDC"/> assigns default attributes to the DC each time it is retrieved.
        /// For example, the default font is System, which is a bitmap font.
        /// Because of this, the handle to a common DC returned by <see cref="GetDC"/> does not tell you what font, color, or brush was used when the window was drawn.
        /// To determine the font, call <see cref="GetTextFace"/>.
        /// </para>
        /// <para>
        /// Note that the handle to the DC can only be used by a single thread at any one time.
        /// </para>
        /// <para>
        /// After painting with a common DC, the <see cref="ReleaseDC"/> function must be called to release the DC.
        /// Class and private DCs do not have to be released.
        /// <see cref="ReleaseDC"/> must be called from the same thread that called <see cref="GetDC"/>.
        /// The number of DCs is limited only by available memory.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDC", ExactSpelling = true)]
        public static extern HDC GetDC([In] HWND hwnd);

        /// <summary>
        /// <para>
        /// The <see cref="GetDCEx"/> function retrieves a handle to a device context (DC) for the client area of a specified window or for the entire screen.
        /// You can use the returned handle in subsequent GDI functions to draw in the DC.
        /// The device context is an opaque data structure, whose values are used internally by GDI.
        /// </para>
        /// <para>
        /// This function is an extension to the <see cref="GetDC"/> function,
        /// which gives an application more control over how and whether clipping occurs in the client area.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getdcex"/>
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
        /// <para>
        /// Specifies how the DC is created.
        /// This parameter can be one or more of the following values.
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
        /// <see cref="DCX_WINDOW"/>
        /// </term>
        /// <term>
        /// Returns a DC that corresponds to the window rectangle rather than the client rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DCX_CACHE"/>
        /// </term>
        /// <term>
        /// Returns a DC from the cache, rather than the OWNDC or CLASSDC window.
        /// Essentially overrides <see cref="CS_OWNDC"/> and <see cref="CS_CLASSDC"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DCX_PARENTCLIP"/>
        /// </term>
        /// <term>
        /// Uses the visible region of the parent window.
        /// The parent's <see cref="WS_CLIPCHILDREN"/> and <see cref="CS_PARENTDC"/> style bits are ignored.
        /// The origin is set to the upper-left corner of the window identified by <paramref name="hWnd"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DCX_CLIPSIBLINGS"/>
        /// </term>
        /// <term>
        /// Excludes the visible regions of all sibling windows above the window identified by <paramref name="hWnd"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DCX_CLIPCHILDREN"/>
        /// </term>
        /// <term>
        /// Excludes the visible regions of all child windows below the window identified by <paramref name="hWnd"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DCX_NORESETATTRS"/>
        /// </term>
        /// <term>
        /// This flag is ignored.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DCX_LOCKWINDOWUPDATE"/>
        /// </term>
        /// <term>
        /// Allows drawing even if there is a <see cref="LockWindowUpdate"/> call in effect that would otherwise exclude this window.
        /// Used for drawing during tracking.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DCX_EXCLUDERGN"/>
        /// </term>
        /// <term>
        /// The clipping region identified by <paramref name="hrgnClip"/> is excluded from the visible region of the returned DC.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DCX_INTERSECTRGN"/>
        /// </term>
        /// <term>
        /// The clipping region identified by <paramref name="hrgnClip"/> is intersected with the visible region of the returned DC.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DCX_INTERSECTUPDATE"/>
        /// </term>
        /// <term>
        /// Reserved; do not use.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DCX_VALIDATE"/>
        /// </term>
        /// <term>
        /// Reserved; do not use.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the handle to the DC for the specified window.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// An invalid value for the <paramref name="hWnd"/> parameter will cause the function to fail.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Unless the display DC belongs to a window class, the <see cref="ReleaseDC"/> function must be called to release the DC after painting.
        /// Also, <see cref="ReleaseDC"/> must be called from the same thread that called <see cref="GetDCEx"/>.
        /// The number of DCs is limited only by available memory.
        /// </para>
        /// <para>
        /// The function returns a handle to a DC that belongs to the window's class
        /// if <see cref="CS_CLASSDC"/>, <see cref="CS_OWNDC"/> or <see cref="CS_PARENTDC"/> was specified as a style
        /// in the <see cref="WNDCLASS"/> structure when the class was registered.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDCEx", ExactSpelling = true)]
        public static extern HDC GetDCEx([In] HWND hWnd, [In] HRGN hrgnClip, [In] GetDCExFlags flags);

        /// <summary>
        /// <para>
        /// The <see cref="GetTabbedTextExtent"/> function computes the width and height of a character string.
        /// If the string contains one or more tab characters, the width of the string is based upon the specified tab stops.
        /// The <see cref="GetTabbedTextExtent"/> function uses the currently selected font to compute the dimensions of the string.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-gettabbedtextextentw"/>
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
        /// <para>
        /// If the function succeeds, the return value is the dimensions of the string in logical units.
        /// The height is in the high-order word and the width is in the low-order word.
        /// </para>
        /// <para>
        /// If the function fails, the return value is 0.
        /// <see cref="GetTabbedTextExtent"/> will fail if <paramref name="hdc"/> is invalid and if <paramref name="nTabPositions"/> is less than 0.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The current clipping region does not affect the width and height returned by the <see cref="GetTabbedTextExtent"/> function.
        /// </para>
        /// <para>
        /// Because some devices do not place characters in regular cell arrays (that is, they kern the characters),
        /// the sum of the extents of the characters in a string may not be equal to the extent of the string.
        /// </para>
        /// <para>
        /// If the <paramref name="nTabPositions"/> parameter is zero and the <paramref name="lpnTabStopPositions"/> parameter is <see cref="NULL"/>,
        /// tabs are expanded to eight times the average character width.
        /// </para>
        /// <para>
        /// If <paramref name="nTabPositions"/> is 1, the tab stops are separated by the distance
        /// specified by the first value in the array to which <paramref name="lpnTabStopPositions"/> points.
        /// </para>

        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTabbedTextExtentW", ExactSpelling = true)]
        public static extern DWORD GetTabbedTextExtent([In] HDC hdc, [In] LPCWSTR lpString, [In] int chCount, [In] int nTabPositions, [In] INT[] lpnTabStopPositions);

        /// <summary>
        /// <para>
        /// The <see cref="GetUpdateRect"/> function retrieves the coordinates of the smallest rectangle
        /// that completely encloses the update region of the specified window.
        /// <see cref="GetUpdateRect"/> retrieves the rectangle in logical coordinates. If there is no update region,
        /// <see cref="GetUpdateRect"/> retrieves an empty rectangle (sets all coordinates to zero).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getupdaterect"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// Handle to the window whose update region is to be retrieved.
        /// </param>
        /// <param name="lpRect">
        /// <para>
        /// Pointer to the <see cref="RECT"/> structure that receives the coordinates, in device units, of the enclosing rectangle.
        /// </para>
        /// <para>
        /// An application can set this parameter to <see cref="NULL"/> to determine whether an update region exists for the window.
        /// If this parameter is <see cref="NULL"/>, <see cref="GetUpdateRect"/> returns nonzero if an update region exists, and zero if one does not.
        /// This provides a simple and efficient means of determining whether a <see cref="WM_PAINT"/> message resulted from an invalid area.
        /// </para>
        /// </param>
        /// <param name="bErase">
        /// Specifies whether the background in the update region is to be erased.
        /// If this parameter is <see cref="TRUE"/> and the update region is not empty,
        /// <see cref="GetUpdateRect"/> sends a <see cref="WM_ERASEBKGND"/> message to the specified window to erase the background.
        /// </param>
        /// <returns>
        /// <para>
        /// If the update region is not empty, the return value is nonzero.
        /// </para>
        /// <para>
        /// If there is no update region, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The update rectangle retrieved by the <see cref="BeginPaint"/> function is identical to that retrieved by <see cref="GetUpdateRect"/>.
        /// </para>
        /// <para>
        /// <see cref="BeginPaint"/> automatically validates the update region,
        /// so any call to <see cref="GetUpdateRect"/> made immediately after the call to <see cref="BeginPaint"/> retrieves an empty update region.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetUpdateRect", ExactSpelling = true)]
        public static extern BOOL GetUpdateRect([In] HWND hWnd, [In][Out] ref RECT lpRect, [In] BOOL bErase);

        /// <summary>
        /// <para>
        /// The <see cref="GetUpdateRgn"/> function retrieves the update region of a window by copying it into the specified region.
        /// The coordinates of the update region are relative to the upper-left corner of the window (that is, they are client coordinates).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getupdatergn"/>
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
        /// <para>
        /// The return value indicates the complexity of the resulting region; it can be one of the following values.
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
        /// <see cref="COMPLEXREGION"/>
        /// </term>
        /// <term>
        /// Region consists of more than one rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR"/>
        /// </term>
        /// <term>
        /// An error occurred.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="NULLREGION"/>
        /// </term>
        /// <term>
        /// Region is empty.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SIMPLEREGION"/>
        /// </term>
        /// <term>
        /// Region is a single rectangle.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// The <see cref="BeginPaint"/> function automatically validates the update region,
        /// so any call to <see cref="GetUpdateRgn"/> made immediately after the call to <see cref="BeginPaint"/> retrieves an empty update region.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetUpdateRgn", ExactSpelling = true)]
        public static extern RegionFlags GetUpdateRgn([In] HWND hWnd, [In] HRGN hRgn, [In] BOOL bErase);

        /// <summary>
        /// <para>
        /// The <see cref="GetWindowDC"/> function retrieves the device context (DC) for the entire window, including title bar, menus, and scroll bars.
        /// A window device context permits painting anywhere in a window,
        /// because the origin of the device context is the upper-left corner of the window instead of the client area.
        /// </para>
        /// <para>
        /// <see cref="GetWindowDC"/> assigns default attributes to the window device context each time it retrieves the device context.
        /// Previous attributes are lost.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowdc"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// <para>
        /// A handle to the window with a device context that is to be retrieved.
        /// If this value is <see cref="NULL"/>, <see cref="GetWindowDC"/> retrieves the device context for the entire screen.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NULL"/>, <see cref="GetWindowDC"/> retrieves the device context for the primary display monitor.
        /// To get the device context for other display monitors, use the <see cref="EnumDisplayMonitors"/> and <see cref="CreateDC"/> functions.
        /// </para>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to a device context for the specified window.
        /// If the function fails, the return value is <see cref="NULL"/>, indicating an error or an invalid <paramref name="hWnd"/> parameter.
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="GetWindowDC"/> is intended for special painting effects within a window's nonclient area.
        /// Painting in nonclient areas of any window is not recommended.
        /// </para>
        /// <para>
        /// The <see cref="GetSystemMetrics"/> function can be used to retrieve the dimensions of various parts of the nonclient area,
        /// such as the title bar, menu, and scroll bars.
        /// </para>
        /// <para>
        /// The <see cref="GetDC"/> function can be used to retrieve a device context for the entire screen.
        /// </para>
        /// <para>
        /// After painting is complete, the <see cref="ReleaseDC"/> function must be called to release the device context.
        /// Not releasing the window device context has serious effects on painting requested by applications.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowDC", ExactSpelling = true)]
        public static extern HDC GetWindowDC([In] HWND hWnd);

        /// <summary>
        /// <para>
        /// <para>
        /// The <see cref="GrayString"/> function draws gray text at the specified location.
        /// The function draws the text by copying it into a memory bitmap, graying the bitmap, and then copying the bitmap to the screen.
        /// The function grays the text regardless of the selected brush and background.
        /// <see cref="GrayString"/> uses the font currently selected for the specified device context.
        /// </para>
        /// <para>
        /// If the <paramref name="lpOutputFunc"/> parameter is <see cref="NULL"/>, GDI uses the <see cref="TextOut"/> function,
        /// and the <paramref name="lpData"/> parameter is assumed to be a pointer to the character string to be output.
        /// If the characters to be output cannot be handled by <see cref="TextOut"/> (for example, the string is stored as a bitmap),
        /// the application must supply its own output function.
        /// </para>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-graystringw"/>
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
        /// if <see cref="TextOut"/> is to be used to draw the string, it is a <see cref="NULL"/> pointer.
        /// For details, see the <c>OutputProc</c> callback function.
        /// </param>
        /// <param name="lpData">
        /// A pointer to data to be passed to the output function.
        /// If the <paramref name="lpOutputFunc"/> parameter is <see cref="NULL"/>, <paramref name="lpData"/> must be a pointer to the string to be output.
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
        /// <para>
        /// If the string is drawn, the return value is nonzero.
        /// </para>
        /// <para>
        /// If either the <see cref="TextOut"/> function or the application-defined output function returned zero,
        /// or there was insufficient memory to create a memory bitmap for graying, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// Without calling <see cref="GrayString"/>, an application can draw grayed strings on devices that support a solid gray color.
        /// The system color <see cref="COLOR_GRAYTEXT"/> is the solid-gray system color used to draw disabled text.
        /// The application can call the <see cref="GetSysColor"/> function to retrieve the color value of <see cref="COLOR_GRAYTEXT"/>.
        /// If the color is other than zero (black), the application can call the <see cref="SetTextColor"/> function
        /// to set the text color to the color value and then draw the string directly.
        /// If the retrieved color is black, the application must call <see cref="GrayString"/> to gray the text.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GrayStringW", ExactSpelling = true)]
        public static extern BOOL GrayString([In] HDC hDC, [In] HBRUSH hBrush, [In] GRAYSTRINGPROC lpOutputFunc, [In] LPARAM lpData, [In] int nCount,
            [In] int X, [In] int Y, [In] int nWidth, [In] int nHeight);

        /// <summary>
        /// <para>
        /// The <see cref="InvalidateRect"/> function adds a rectangle to the specified window's update region.
        /// The update region represents the portion of the window's client area that must be redrawn.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-invalidaterect "/>
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
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The invalidated areas accumulate in the update region until the region is processed
        /// when the next <see cref="WM_PAINT"/> message occurs or until the region is validated
        /// by using the <see cref="ValidateRect"/> or <see cref="ValidateRgn"/> function.
        /// </para>
        /// <para>
        /// The system sends a <see cref="WM_PAINT"/> message to a window
        /// whenever its update region is not empty and there are no other messages in the application queue for that window.
        /// </para>
        /// <para>
        /// If the <paramref name="bErase"/> parameter is <see cref="TRUE"/> for any part of the update region,
        /// the background is erased in the entire region, not just in the specified part.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "InvalidateRect", ExactSpelling = true)]
        public static extern BOOL InvalidateRect([In] HWND hWnd, [In] in RECT lpRect, [In] BOOL bErase);

        /// <summary>
        /// <para>
        /// The <see cref="InvalidateRgn"/> function invalidates the client area within the specified region
        /// by adding it to the current update region of a window.
        /// The invalidated region, along with all other areas in the update region,
        /// is marked for painting when the next <see cref="WM_PAINT"/> message occurs.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-invalidatergn"/>
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
        /// The return value is always nonzero.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Invalidated areas accumulate in the update region until the next <see cref="WM_PAINT"/> message is processed
        /// or until the region is validated by using the <see cref="ValidateRect"/> or <see cref="ValidateRgn"/> function.
        /// </para>
        /// <para>
        /// The system sends a <see cref="WM_PAINT"/> message to a window
        /// whenever its update region is not empty and there are no other messages in the application queue for that window.
        /// </para>
        /// <para>
        /// The specified region must have been created by using one of the region functions.
        /// </para>
        /// <para>
        /// If the <paramref name="bErase"/> parameter is <see cref="TRUE"/> for any part of the update region,
        /// the background in the entire region is erased, not just in the specified part.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "InvalidateRgn", ExactSpelling = true)]
        public static extern BOOL InvalidateRgn([In] HWND hWnd, [In] HRGN hRgn, [In] BOOL bErase);

        /// <summary>
        /// <para>
        /// The <see cref="LoadBitmap"/> function loads the specified bitmap resource from a module's executable file.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-loadbitmapw"/>
        /// </para>
        /// </summary>
        /// <param name="hInstance"
        /// >A handle to the instance of the module whose executable file contains the bitmap to be loaded.
        /// </param>
        /// <param name="lpBitmapName">
        /// A pointer to a null-terminated string that contains the name of the bitmap resource to be loaded.
        /// Alternatively, this parameter can consist of the resource identifier in the low-order word and zero in the high-order word.
        /// The <see cref="MAKEINTRESOURCE"/> macro can be used to create this value.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the handle to the specified bitmap.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the bitmap pointed to by the <paramref name="lpBitmapName"/> parameter does not exist or there is insufficient memory to load the bitmap, the function fails.
        /// </para>
        /// <para>
        /// <see cref="LoadBitmap"/> creates a compatible bitmap of the display, which cannot be selected to a printer.
        /// To load a bitmap that you can select to a printer, call <see cref="LoadImage"/> and specify <see cref="LR_CREATEDIBSECTION"/> to create a DIB section.
        /// A DIB section can be selected to any device.
        /// </para>
        /// <para>
        /// An application can use the <see cref="LoadBitmap"/> function to access predefined bitmaps.
        /// To do so, the application must set the <paramref name="hInstance"/> parameter to <see cref="NULL"/>
        /// and the <paramref name="lpBitmapName"/> parameter to one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Bitmap name
        /// </term>
        /// <term>
        /// Bitmap name
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="OBM_BTNCORNERS"/>
        /// </term>
        /// <term>
        /// <see cref="OBM_OLD_RESTORE"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OBM_BTSIZE"/>
        /// </term>
        /// <term>
        /// <see cref="OBM_OLD_RGARROW"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OBM_CHECK"/>
        /// </term>
        /// <term>
        /// <see cref="OBM_OLD_UPARROW"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OBM_CHECKBOXES"/>
        /// </term>
        /// <term>
        /// <see cref="OBM_OLD_ZOOM"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OBM_CLOSE"/>
        /// </term>
        /// <term>
        /// <see cref="OBM_REDUCE"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OBM_COMBO"/>
        /// </term>
        /// <term>
        /// <see cref="OBM_REDUCED"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OBM_DNARROW"/>
        /// </term>
        /// <term>
        /// <see cref="OBM_RESTORE"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OBM_DNARROWD"/>
        /// </term>
        /// <term>
        /// <see cref="OBM_RESTORED"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OBM_DNARROWI"/>
        /// </term>
        /// <term>
        /// <see cref="OBM_RGARROW"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OBM_LFARROW"/>
        /// </term>
        /// <term>
        /// <see cref="OBM_RGARROWD"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OBM_LFARROWD"/>
        /// </term>
        /// <term>
        /// <see cref="OBM_RGARROWI"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OBM_LFARROWI"/>
        /// </term>
        /// <term>
        /// <see cref="OBM_SIZE"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OBM_MNARROW"/>
        /// </term>
        /// <term>
        /// <see cref="OBM_UPARROW"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OBM_OLD_CLOSE"/>
        /// </term>
        /// <term>
        /// <see cref="OBM_UPARROWD"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OBM_OLD_DNARROW"/>
        /// </term>
        /// <term>
        /// <see cref="OBM_UPARROWI"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OBM_OLD_LFARROW"/>
        /// </term>
        /// <term>
        /// <see cref="OBM_ZOOM"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OBM_OLD_REDUCE"/>
        /// </term>
        /// <term>
        /// <see cref="OBM_ZOOMD"/>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Bitmap names that begin with <see cref="OBM_OLD"/> represent bitmaps used by 16-bit versions of Windows earlier than 3.0.
        /// </para>
        /// <para>
        /// For an application to use any of the <c>OBM_</c> constants, the constant <c>OEMRESOURCE</c> must be defined before the Windows.h header file is included.
        /// </para>
        /// <para>
        /// The application must call the <see cref="DeleteObject"/> function to delete each bitmap handle returned by the <see cref="LoadBitmap"/> function.
        /// </para>
        /// </remarks>
        [Obsolete("LoadBitmap is available for use in the operating systems specified in the Requirements section. " +
            "It may be altered or unavailable in subsequent versions. Instead, use LoadImage and DrawFrameControl.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadBitmapW", ExactSpelling = true)]
        public static extern HBITMAP LoadBitmap([In] HINSTANCE hInstance, [In] LPCWSTR lpBitmapName);

        /// <summary>
        /// <para>
        /// The <see cref="LockWindowUpdate"/> function disables or enables drawing in the specified window.
        /// Only one window can be locked at a time.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-lockwindowupdate"/>
        /// </para>
        /// </summary>
        /// <param name="hWndLock">
        /// The window in which drawing will be disabled.
        /// If this parameter is <see cref="NULL"/>, drawing in the locked window is enabled.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero, indicating that an error occurred or another window was already locked.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The purpose of the <see cref="LockWindowUpdate"/> function is to permit drag/drop feedback to be drawn over a window without interference from the window itself.
        /// The intent is that the window is locked when feedback is drawn and unlocked when feedback is complete.
        /// <see cref="LockWindowUpdate"/> is not intended for general-purpose suppression of window redraw.
        /// Use the <see cref="WM_SETREDRAW"/> message to disable redrawing of a particular window.
        /// </para>
        /// <para>
        /// If an application with a locked window (or any locked child windows) calls the <see cref="GetDC"/>, <see cref="GetDCEx"/>,
        /// or <see cref="BeginPaint"/> function, the called function returns a device context with a visible region that is empty.
        /// This will occur until the application unlocks the window by calling <see cref="LockWindowUpdate"/>,
        /// specifying a value of <see cref="NULL"/> for <paramref name="hWndLock"/>.
        /// </para>
        /// <para>
        /// If an application attempts to draw within a locked window, the system records the extent of the attempted operation in a bounding rectangle.
        /// When the window is unlocked, the system invalidates the area within this bounding rectangle,
        /// forcing an eventual <see cref="WM_PAINT"/> message to be sent to the previously locked window and its child windows.
        /// If no drawing has occurred while the window updates were locked, no area is invalidated.
        /// </para>
        /// <para>
        /// <see cref="LockWindowUpdate"/> does not make the specified window invisible and does not clear the <see cref="WS_VISIBLE"/> style bit.
        /// </para>
        /// <para>
        /// A locked window cannot be moved.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LockWindowUpdate", ExactSpelling = true)]
        public static extern BOOL LockWindowUpdate([In] HWND hWndLock);

        /// <summary>
        /// <para>
        /// The <see cref="MapWindowPoints"/> function converts (maps) a set of points from a coordinate space relative
        /// to one window to a coordinate space relative to another window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-mapwindowpoints"/>
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
        /// <para>
        /// If the function succeeds, the low-order word of the return value is the number of pixels added to the horizontal coordinate of each source point
        /// in order to compute the horizontal coordinate of each destination point.
        /// (In addition to that, if precisely one of <paramref name="hWndFrom"/> and <paramref name="hWndTo"/> is mirrored,
        /// then each resulting horizontal coordinate is multiplied by -1.)
        /// The high-order word is the number of pixels added to the vertical coordinate of each source point
        /// in order to compute the vertical coordinate of each destination point.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero. 
        /// Call <see cref="SetLastError"/> prior to calling this method to differentiate an error return value from a legitimate "0" return value.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
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
        /// </para>
        /// <code>
        /// RECT        rc[10];
        /// for(int i = 0; i &lt; (sizeof(rc)/sizeof(rc[0])); i++)
        /// {
        ///     MapWindowPoints(hWnd1, hWnd2, (LPPOINT)(&amp;rc[i]), (sizeof(RECT)/sizeof(POINT)) );
        /// }
        /// </code>
        /// <para>
        /// Also, if you need to map precisely two independent points and don't want the <see cref="RECT"/> logic
        /// applied to them by <see cref="MapWindowPoints"/>, to guarantee the correct result you must call <see cref="MapWindowPoints"/>
        /// with one <see cref="POINT"/> pointer at a time, as shown in the following example:
        /// </para>
        /// <code>
        ///  POINT pt[2];
        ///  MapWindowPoints(hWnd1, hWnd2, &amp;pt[0], 1);
        ///  MapWindowPoints(hWnd1, hWnd2, &amp;pt[1], 1);
        /// </code>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "MapWindowPoints", ExactSpelling = true, SetLastError = true)]
        public static extern int MapWindowPoints([In] HWND hWndFrom, [In] HWND hWndTo, [In][Out] POINT[] lpPoints, [In] UINT cPoints);

        /// <summary>
        /// <para>
        /// The <see cref="PrintWindow"/> function copies a visual window into the specified device context (DC), typically a printer DC.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-printwindow"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window that will be copied.
        /// </param>
        /// <param name="hdcBlt">
        /// A handle to the device context.
        /// </param>
        /// <param name="nFlags">
        /// <para>
        /// The drawing options.
        /// It can be one of the following values.
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
        /// <see cref="PW_CLIENTONLY"/>
        /// </term>
        /// <term>
        /// Only the client area of the window is copied to <paramref name="hdcBlt"/>.
        /// By default, the entire window is copied.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, it returns a nonzero value.
        /// </para>
        /// <para>
        /// If the function fails, it returns zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This is a blocking or synchronous function and might not return immediately.
        /// How quickly this function returns depends on run-time factors such as network status, print server configuration,
        /// and printer driver implementation—factors that are difficult to predict when writing an application.
        /// Calling this function from a thread that manages interaction with the user interface could make the application appear to be unresponsive.
        /// The application that owns the window referenced by <paramref name="hwnd"/> processes the <see cref="PrintWindow"/> call
        /// and renders the image in the device context that is referenced by <paramref name="hdcBlt"/>.
        /// </para>
        /// <para>
        /// The application receives a <see cref="WM_PRINT"/> message or,
        /// if the <see cref="PW_CLIENTONLY"/> flag is specified, a <see cref="WM_PRINTCLIENT"/> message.
        /// For more information, see <see cref="WM_PRINT"/> and <see cref="WM_PRINTCLIENT"/>. 
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "PrintWindow", ExactSpelling = true)]
        public static extern BOOL PrintWindow([In] HWND hwnd, [In] HDC hdcBlt, [In] PrintWindowFlags nFlags);

        /// <summary>
        /// <para>
        /// The <see cref="RedrawWindow"/> function updates the specified rectangle or region in a window's client area.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-redrawwindow"/>
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
        /// <para>
        /// One or more redraw flags.
        /// This parameter can be used to invalidate or validate a window, control repainting, and control which windows are affected by <see cref="RedrawWindow"/>.
        /// </para>
        /// <para>
        /// The following flags are used to invalidate the window.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Flag (invalidation)
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="RDW_ERASE"/>
        /// </term>
        /// <term>
        /// Causes the window to receive a <see cref="WM_ERASEBKGND"/> message when the window is repainted.
        /// The <see cref="RDW_INVALIDATE"/> flag must also be specified; otherwise, <see cref="RDW_ERASE"/> has no effect.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RDW_FRAME"/>
        /// </term>
        /// <term>
        /// Causes any part of the nonclient area of the window that intersects the update region to receive a <see cref="WM_NCPAINT"/> message.
        /// The <see cref="RDW_INVALIDATE"/> flag must also be specified; otherwise, <see cref="RDW_FRAME"/> has no effect.
        /// The <see cref="WM_NCPAINT"/> message is typically not sent during the execution of <see cref="RedrawWindow"/>
        /// unless either <see cref="RDW_UPDATENOW"/> or <see cref="RDW_ERASENOW"/> is specified.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RDW_INTERNALPAINT"/>
        /// </term>
        /// <term>
        /// Causes a <see cref="WM_PAINT"/> message to be posted to the window regardless of whether any portion of the window is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RDW_INVALIDATE"/>
        /// </term>
        /// <term>
        /// Invalidates <paramref name="lprcUpdate"/> or <paramref name="hrgnUpdate"/> (only one may be non-<see cref="NULL"/>).
        /// If both are <see cref="NULL"/>, the entire window is invalidated.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The following flags are used to validate the window.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Flag (validation)
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="RDW_NOERASE"/>
        /// </term>
        /// <term>
        /// Suppresses any pending <see cref="WM_ERASEBKGND"/> messages.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RDW_NOFRAME"/>
        /// </term>
        /// <term>
        /// Suppresses any pending <see cref="WM_NCPAINT"/> messages.
        /// This flag must be used with <see cref="RDW_VALIDATE"/> and is typically used with <see cref="RDW_NOCHILDREN"/>.
        /// <see cref="RDW_NOFRAME"/> should be used with care, as it could cause parts of a window to be painted improperly.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RDW_NOINTERNALPAINT"/>
        /// </term>
        /// <term>
        /// Suppresses any pending internal <see cref="WM_PAINT"/> messages.
        /// This flag does not affect <see cref="WM_PAINT"/> messages resulting from a non-<see cref="NULL"/> update area.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RDW_VALIDATE"/>
        /// </term>
        /// <term>
        /// Validates <paramref name="lprcUpdate"/> or <paramref name="hrgnUpdate"/> (only one may be non-<see cref="NULL"/>).
        /// If both are <see cref="NULL"/>, the entire window is validated.
        /// This flag does not affect internal <see cref="WM_PAINT"/> messages.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The following flags control when repainting occurs.
        /// <see cref="RedrawWindow"/> will not repaint unless one of these flags is specified.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Flag
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="RDW_ERASENOW"/>
        /// </term>
        /// <term>
        /// Causes the affected windows (as specified by the <see cref="RDW_ALLCHILDREN"/> and <see cref="RDW_NOCHILDREN"/> flags)
        /// to receive <see cref="WM_NCPAINT"/> and <see cref="WM_ERASEBKGND"/> messages, if necessary, before the function returns.
        /// <see cref="WM_PAINT"/> messages are received at the ordinary time.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RDW_UPDATENOW"/>
        /// </term>
        /// <term>
        /// Causes the affected windows (as specified by the <see cref="RDW_ALLCHILDREN"/> and <see cref="RDW_NOCHILDREN"/> flags)
        /// to receive <see cref="WM_NCPAINT"/>, <see cref="WM_ERASEBKGND"/>, and <see cref="WM_PAINT"/> messages, if necessary, before the function returns.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// By default, the windows affected by <see cref="RedrawWindow"/> depend on whether the specified window has the <see cref="WS_CLIPCHILDREN"/> style.
        /// Child windows that are not the <see cref="WS_CLIPCHILDREN"/> style are unaffected;
        /// non-<see cref="WS_CLIPCHILDREN"/> windows are recursively validated or invalidated until a <see cref="WS_CLIPCHILDREN"/> window is encountered.
        /// The following flags control which windows are affected by the <see cref="RedrawWindow"/> function.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Flag
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="RDW_ALLCHILDREN"/>
        /// </term>
        /// <term>
        /// Includes child windows, if any, in the repainting operation.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RDW_NOCHILDREN"/>
        /// </term>
        /// <term>
        /// Excludes child windows, if any, from the repainting operation.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
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
        /// When <see cref="RedrawWindow"/> is used to invalidate part of the desktop window,
        /// the desktop window does not receive a <see cref="WM_PAINT"/> message.
        /// To repaint the desktop, an application uses the <see cref="RDW_ERASE"/> flag to generate a <see cref="WM_ERASEBKGND"/> message.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "RedrawWindow", ExactSpelling = true)]
        public static extern BOOL RedrawWindow([In] HWND hWnd, [In] in RECT lprcUpdate, [In] HRGN hrgnUpdate, [In] RedrawWindowFlags flags);

        /// <summary>
        /// <para>
        /// The <see cref="ReleaseDC"/> function releases a device context (DC), freeing it for use by other applications.
        /// The effect of the <see cref="ReleaseDC"/> function depends on the type of DC. It frees only common and window DCs.
        /// It has no effect on class or private DCs.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-releasedc"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose DC is to be released.
        /// </param>
        /// <param name="hDC">
        /// A handle to the DC to be released.
        /// </param>
        /// <returns>
        /// <para>
        /// The return value indicates whether the DC was released.
        /// If the DC was released, the return value is 1.
        /// </para>
        /// <para>
        /// If the DC was not released, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The application must call the <see cref="ReleaseDC"/> function for each call to the <see cref="GetWindowDC"/> function
        /// and for each call to the <see cref="GetDC"/> function that retrieves a common DC.
        /// </para>
        /// <para>
        /// An application cannot use the <see cref="ReleaseDC"/> function to release a DC that was created
        /// by calling the <see cref="CreateDC"/> function; instead, it must use the <see cref="DeleteDC"/> function.
        /// <see cref="ReleaseDC"/> must be called from the same thread that called <see cref="GetDC"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ReleaseDC", ExactSpelling = true)]
        public static extern int ReleaseDC([In] HWND hWnd, [In] HDC hDC);

        /// <summary>
        /// <para>
        /// The <see cref="ScreenToClient"/> function converts the screen coordinates of a specified point on the screen to client-area coordinates.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-screentoclient"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose client area will be used for the conversion.
        /// </param>
        /// <param name="lpPoint">
        /// A pointer to a <see cref="POINT"/> structure that specifies the screen coordinates to be converted.
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
        /// The function uses the window identified by the <paramref name="hWnd"/> parameter and the screen coordinates
        /// given in the <see cref="POINT"/> structure to compute client coordinates.
        /// It then replaces the screen coordinates with the client coordinates.
        /// The new coordinates are relative to the upper-left corner of the specified window's client area.
        /// </para>
        /// <para>
        /// The <see cref="ScreenToClient"/> function assumes the specified point is in screen coordinates.
        /// </para>
        /// <para>
        /// All coordinates are in device units.
        /// </para>
        /// <para>
        /// Do not use <see cref="ScreenToClient"/> when in a mirroring situation,
        /// that is, when changing from left-to-right layout to right-to-left layout.
        /// Instead, use <see cref="MapWindowPoints"/>. For more information, see "Window Layout and Mirroring" in Window Features.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ScreenToClient", ExactSpelling = true)]
        public static extern BOOL ScreenToClient([In] HWND hWnd, [In][Out] ref POINT lpPoint);

        /// <summary>
        /// <para>
        /// The <see cref="ScrollDC"/> function scrolls a rectangle of bits horizontally and vertically.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-scrolldc"/>
        /// </para>
        /// </summary>
        /// <param name="hDC">
        /// Handle to the device context that contains the bits to be scrolled.
        /// </param>
        /// <param name="dx">
        /// Specifies the amount, in device units, of horizontal scrolling.
        /// This parameter must be a negative value to scroll to the left.
        /// </param>
        /// <param name="dy">
        /// Specifies the amount, in device units, of vertical scrolling.
        /// This parameter must be a negative value to scroll up.
        /// </param>
        /// <param name="lprcScroll">
        /// Pointer to a <see cref="RECT"/> structure containing the coordinates of the bits to be scrolled.
        /// The only bits affected by the scroll operation are bits in the intersection of this rectangle
        /// and the rectangle specified by <paramref name="lprcClip"/>.
        /// If <paramref name="lprcScroll"/> is <see cref="NullRef{RECT}"/>, the entire client area is used.
        /// </param>
        /// <param name="lprcClip">
        /// Pointer to a <see cref="RECT"/> structure containing the coordinates of the clipping rectangle.
        /// The only bits that will be painted are the bits that remain inside this rectangle after the scroll operation has been completed.
        /// If <paramref name="lprcClip"/> is <see cref="NullRef{RECT}"/>, the entire client area is used.
        /// </param>
        /// <param name="hrgnUpdate">
        /// Handle to the region uncovered by the scrolling process.
        /// <see cref="ScrollDC"/> defines this region; it is not necessarily a rectangle.
        /// </param>
        /// <param name="lprcUpdate">
        /// Pointer to a <see cref="RECT"/> structure that receives the coordinates of the rectangle bounding the scrolling update region.
        /// This is the largest rectangular area that requires repainting.
        /// When the function returns, the values in the structure are in client coordinates, regardless of the mapping mode for the specified device context.
        /// This allows applications to use the update region in a call to the <see cref="InvalidateRgn"/> function, if required.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the <paramref name="lprcUpdate"/> parameter is <see cref="NullRef{RECT}"/>, the system does not compute the update rectangle.
        /// If both the <paramref name="hrgnUpdate"/> and <paramref name="lprcUpdate"/> parameters are <see cref="NULL"/>,
        /// the system does not compute the update region.
        /// If <paramref name="hrgnUpdate"/> is not <see cref="NULL"/>,
        /// the system proceeds as though it contains a valid handle to the region uncovered by the scrolling process (defined by <see cref="ScrollDC"/>).
        /// </para>
        /// <para>
        /// When you must scroll the entire client area of a window, use the <see cref="ScrollWindowEx"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ScrollDC", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ScrollDC([In] HDC hDC, [In] int dx, [In] int dy, [In] in RECT lprcScroll, [In] in RECT lprcClip,
            [In] HRGN hrgnUpdate, [Out] out RECT lprcUpdate);

        /// <summary>
        /// <para>
        /// The <see cref="TabbedTextOut"/> function writes a character string at a specified location,
        /// expanding tabs to the values specified in an array of tab-stop positions.
        /// Text is written in the currently selected font, background color, and text color.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-tabbedtextoutw"/>
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
        /// <para>
        /// If the function succeeds, the return value is the dimensions, in logical units, of the string.
        /// The height is in the high-order word and the width is in the low-order word.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the <paramref name="nTabPositions"/> parameter is zero and the <paramref name="lpnTabStopPositions"/> parameter is <see langword="null"/>,
        /// tabs are expanded to eight times the average character width.
        /// </para>
        /// <para>
        /// If <paramref name="nTabPositions"/> is 1, the tab stops are separated by the distance
        /// specified by the first value in the <paramref name="lpnTabStopPositions"/> array.
        /// </para>
        /// <para>
        /// If the <paramref name="lpnTabStopPositions"/> array contains more than one value,
        /// a tab stop is set for each value in the array, up to the number specified by <paramref name="nTabPositions"/>.
        /// </para>
        /// <para>
        /// The <paramref name="nTabOrigin"/> parameter allows an application to call the <see cref="TabbedTextOut"/> function several times for a single line.
        /// If the application calls <see cref="TabbedTextOut"/> more than once with the <paramref name="nTabOrigin"/> set to the same value each time,
        /// the function expands all tabs relative to the position specified by <paramref name="nTabOrigin"/>.
        /// </para>
        /// <para>
        /// By default, the current position is not used or updated by the <see cref="TabbedTextOut"/> function.
        /// If an application needs to update the current position when it calls <see cref="TabbedTextOut"/>,
        /// the application can call the <see cref="SetTextAlign"/> function with the <c>wFlags</c> parameter set to <see cref="TA_UPDATECP"/>.
        /// When this flag is set, the system ignores the <paramref name="x"/> and <paramref name="y"/> parameters
        /// on subsequent calls to the <see cref="TabbedTextOut"/> function, using the current position instead.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// For Windows Vista and later, <see cref="TabbedTextOut"/> ignores text alignment when it draws text.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "TabbedTextOutW", ExactSpelling = true)]
        public static extern LONG TabbedTextOut([In] HDC hdc, [In] int x, [In] int y, [In] LPCWSTR lpString,
            [In] int chCount, [In] int nTabPositions, [In] INT[] lpnTabStopPositions, [In] int nTabOrigin);

        /// <summary>
        /// <para>
        /// The <see cref="UpdateWindow"/> function updates the client area of the specified window
        /// by sending a <see cref="WM_PAINT"/> message to the window if the window's update region is not empty.
        /// The function sends a <see cref="WM_PAINT"/> message directly to the window procedure of the specified window,
        /// bypassing the application queue.
        /// If the update region is empty, no message is sent.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-updatewindow"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// Handle to the window to be updated.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "UpdateWindow", ExactSpelling = true)]
        public static extern BOOL UpdateWindow([In] HWND hWnd);

        /// <summary>
        /// <para>
        /// The <see cref="ValidateRect"/> function validates the client area within a rectangle
        /// by removing the rectangle from the update region of the specified window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-validaterect"/>
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
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="BeginPaint"/> function automatically validates the entire client area.
        /// Neither the <see cref="ValidateRect"/> nor <see cref="ValidateRgn"/> function should be called
        /// if a portion of the update region must be validated before the next <see cref="WM_PAINT"/> message is generated.
        /// </para>
        /// <para>
        /// The system continues to generate <see cref="WM_PAINT"/> messages until the current update region is validated.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ValidateRect", ExactSpelling = true)]
        public static extern BOOL ValidateRect([In] HWND hWnd, [In] in RECT lpRect);

        /// <summary>
        /// <para>
        /// The <see cref="ValidateRgn"/> function validates the client area within a region
        /// by removing the region from the current update region of the specified window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-validatergn"/>
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
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The specified region must have been created by a region function. The region coordinates are assumed to be client coordinates.
        /// </para>
        /// <para>
        /// The <see cref="BeginPaint"/> function automatically validates the entire client area.
        /// Neither the <see cref="ValidateRect"/> nor <see cref="ValidateRgn"/> function should be called
        /// if a portion of the update region must be validated before the next <see cref="WM_PAINT"/> message is generated.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ValidateRgn", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ValidateRgn([In] HWND hWnd, [In] HRGN hRgn);
    }
}
