using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.WindowsMessages;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32
{
    public static partial class User32
    {
        /// <summary>
        /// <para>
        /// The <see cref="BeginPaint"/> function prepares the specified window for painting
        /// and fills a <see cref="PAINTSTRUCT"/> structure with information about the painting.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-beginpaint
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
        public static extern HDC BeginPaint([In]HWND hWnd, [Out]out PAINTSTRUCT lpPaint);

        /// <summary>
        /// <para>
        /// The <see cref="ClientToScreen"/> function converts the client-area coordinates of a specified point to screen coordinates.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-clienttoscreen
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
        public static extern BOOL ClientToScreen([In]HWND hWnd, [In][Out]ref POINT lpPoint);

        /// <summary>
        /// <para>
        /// The <see cref="DrawFocusRect"/> function draws a rectangle in the style used to indicate that the rectangle has the focus.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-drawfocusrect
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
        /// This is handled by the <see cref="SystemParametersInfoParameters.SPI_SETFOCUSBORDERWIDTH"/> and
        /// <see cref="SystemParametersInfoParameters.SPI_SETFOCUSBORDERHEIGHT"/> in <see cref="SystemParametersInfo"/>.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DrawFocusRect", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DrawFocusRect([In]IntPtr hDC, [In]in RECT lprc);

        /// <summary>
        /// <para>
        /// The EndPaint function marks the end of painting in the specified window.
        /// This function is required for each call to the <see cref="BeginPaint"/> function, but only after painting is complete.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-endpaint
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// Handle to the window that has been repainted.
        /// </param>
        /// <param name="lpPaint">
        /// Pointer to a <see cref="PAINTSTRUCT"/> structure that contains the painting information retrieved by <see cref="BeginPaint"/>.
        /// </param>
        /// <returns>
        /// The return value is always <see cref="BOOL"/>.
        /// </returns>
        /// <remarks>
        /// If the caret was hidden by <see cref="BeginPaint"/>, <see cref="EndPaint"/> restores the caret to the screen.
        /// <see cref="EndPaint"/> releases the display device context that <see cref="BeginPaint"/> retrieved.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EndPaint", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EndPaint([In]HWND hWnd, [In]in PAINTSTRUCT lpPaint);

        /// <summary>
        /// <para>
        /// The <see cref="GetDC"/> function retrieves a handle to a device context (DC) for the client area of a specified window or for the entire screen.
        /// You can use the returned handle in subsequent GDI functions to draw in the DC.
        /// The device context is an opaque data structure, whose values are used internally by GDI.
        /// The <see cref="GetDCEx"/> function is an extension to <see cref="GetDC"/>,
        /// which gives an application more control over how and whether clipping occurs in the client area.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getdc
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
        public static extern HDC GetDC([In]HWND hwnd);

        /// <summary>
        /// <para>
        /// The <see cref="GetDCEx"/> function retrieves a handle to a device context (DC) for the client area of a specified window or for the entire screen.
        /// You can use the returned handle in subsequent GDI functions to draw in the DC.
        /// The device context is an opaque data structure, whose values are used internally by GDI.
        /// This function is an extension to the <see cref="GetDC"/> function,
        /// which gives an application more control over how and whether clipping occurs in the client area.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getdcex
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
        public static extern HDC GetDCEx([In]HWND hWnd, [In]HRGN hrgnClip, [In]GetDCExFlags flags);

        /// <summary>
        /// <para>
        /// The <see cref="GetWindowDC"/> function retrieves the device context (DC) for the entire window, including title bar, menus, and scroll bars.
        /// A window device context permits painting anywhere in a window,
        /// because the origin of the device context is the upper-left corner of the window instead of the client area.
        /// <see cref="GetWindowDC"/> assigns default attributes to the window device context each time it retrieves the device context.
        /// Previous attributes are lost.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getwindowdc
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
        public static extern HDC GetWindowDC([In]HWND hWnd);

        /// <summary>
        /// <para>
        /// The <see cref="LoadBitmap"/> function loads the specified bitmap resource from a module's executable file.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-loadbitmapw
        /// </para>
        /// </summary>
        /// <param name="hInstance">A handle to the instance of the module whose executable file contains the bitmap to be loaded.</param>
        /// <param name="lpBitmapName">A pointer to a null-terminated string that contains the name of the bitmap resource to be loaded.</param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the specified bitmap.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadBitmapW", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr LoadBitmap([In]IntPtr hInstance, [MarshalAs(UnmanagedType.LPWStr)][In]string lpBitmapName);

        /// <summary>
        /// <para>
        /// Loads the specified cursor resource from the executable (.EXE) file associated with an application instance.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-loadcursorw
        /// </para>
        /// </summary>
        /// <param name="hInstance">A handle to an instance of the module whose executable file contains the cursor to be loaded.</param>
        /// <param name="lpCursorName">The name of the cursor resource to be loaded.</param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the newly loaded cursor.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadCursorW", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr LoadCursor([In]IntPtr hInstance, [MarshalAs(UnmanagedType.LPWStr)][In]string lpCursorName);

        /// <summary>
        /// <para>
        /// Loads the specified cursor resource from the executable (.EXE) file associated with an application instance.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-loadcursorw
        /// </para>
        /// </summary>
        /// <param name="hInstance">Must be <see cref="IntPtr.Zero"/>.</param>
        /// <param name="lpCursorName">The resource identifier in the low-order word and zero in the high-order word.</param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the newly loaded cursor.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadCursorW", ExactSpelling = true, SetLastError = true)]
        public static extern HCURSOR LoadCursor([In]IntPtr hInstance, [In]SystemCursors lpCursorName);

        /// <summary>
        /// <para>
        /// Loads the specified icon resource from the executable (.exe) file associated with an application instance.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-loadiconw
        /// </para>
        /// </summary>
        /// <param name="hInstance">
        /// A handle to an instance of the module whose executable file contains the icon to be loaded.
        /// This parameter must be NULL when a standard icon is being loaded.
        /// </param>
        /// <param name="lpIconName">The name of the icon resource to be loaded.</param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the newly loaded icon.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadIconW", ExactSpelling = true, SetLastError = true)]
        public static extern HICON LoadIcon([In]IntPtr hInstance, [MarshalAs(UnmanagedType.LPWStr)][In]string lpIconName);

        /// <summary>
        /// <para>
        /// Loads the specified icon resource from the executable (.exe) file associated with an application instance.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-loadiconw
        /// </para>
        /// </summary>
        /// <param name="hInstance">Must be <see cref="IntPtr.Zero"/>.</param>
        /// <param name="lpIconName">he resource identifier in the low-order word and zero in the high-order word.</param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the newly loaded icon.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadIconW", ExactSpelling = true, SetLastError = true)]
        public static extern HICON LoadIcon([In]IntPtr hInstance, [In]SystemIcons lpIconName);

        /// <summary>
        /// <para>
        /// The <see cref="MapWindowPoints"/> function converts (maps) a set of points from a coordinate space relative
        /// to one window to a coordinate space relative to another window.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-mapwindowpoints
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
        /// for(int i = 0; i < (sizeof(rc)/sizeof(rc[0])); i++)
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
        public static extern int MapWindowPoints([In]HWND hWndFrom, [In]HWND hWndTo, [MarshalAs(UnmanagedType.LPArray)][In][Out]POINT[] lpPoints,
            [In]UINT cPoints);

        /// <summary>
        /// <para>
        /// The <see cref="ReleaseDC"/> function releases a device context (DC), freeing it for use by other applications.
        /// The effect of the <see cref="ReleaseDC"/> function depends on the type of DC. It frees only common and window DCs.
        /// It has no effect on class or private DCs.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-releasedc
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
        public static extern int ReleaseDC([In]HWND hWnd, [In]HDC hDC);

        /// <summary>
        /// <para>
        /// The <see cref="ScreenToClient"/> function converts the screen coordinates of a specified point on the screen to client-area coordinates.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-screentoclient
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
        public static extern BOOL ScreenToClient([In]HWND hWnd, [In][Out]ref POINT lpPoint);

        /// <summary>
        /// <para>
        /// The <see cref="UpdateWindow"/> function updates the client area of the specified window
        /// by sending a <see cref="WM_PAINT"/> message to the window if the window's update region is not empty.
        /// The function sends a <see cref="WM_PAINT"/> message directly to the window procedure of the specified window,
        /// bypassing the application queue.
        /// If the update region is empty, no message is sent.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-updatewindow
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
        public static extern BOOL UpdateWindow([In]HWND hWnd);
    }
}
