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
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>, indicating that no display device context is available.
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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "BeginPaint", SetLastError = true)]
        public static extern IntPtr BeginPaint([In]IntPtr hWnd, [Out]out PAINTSTRUCT lpPaint);

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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DrawFocusRect", SetLastError = true)]
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
        /// The return value is always <see langword="true"/>.
        /// </returns>
        /// <remarks>
        /// If the caret was hidden by <see cref="BeginPaint"/>, <see cref="EndPaint"/> restores the caret to the screen.
        /// <see cref="EndPaint"/> releases the display device context that <see cref="BeginPaint"/> retrieved.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EndPaint", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EndPaint([In]IntPtr hWnd, [In]in PAINTSTRUCT lpPaint);

        /// <summary>
        /// <para>
        /// The GetDC function retrieves a handle to a device context (DC) for the client area of a specified window or for the entire screen.
        /// You can use the returned handle in subsequent GDI functions to draw in the DC.
        /// The device context is an opaque data structure, whose values are used internally by GDI.
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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDC", SetLastError = true)]
        public static extern IntPtr GetDC([In]IntPtr hwnd);

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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadBitmapW", SetLastError = true)]
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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadCursorW", SetLastError = true)]
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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadCursorW", SetLastError = true)]
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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadIconW", SetLastError = true)]
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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadIconW", SetLastError = true)]
        public static extern HICON LoadIcon([In]IntPtr hInstance, [In]SystemIcons lpIconName);

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
        /// <param name="hWnd">A handle to the window whose DC is to be released.</param>
        /// <param name="hDC">A handle to the DC to be released.</param>
        /// <returns>
        /// The return value indicates whether the DC was released. If the DC was released, the return value is <see langword="true"/>.
        /// If the DC was not released, the return value is <see langword="false"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ReleaseDC", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReleaseDC([In]IntPtr hWnd, [In]IntPtr hDC);
    }
}
