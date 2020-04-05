using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.SystemMetric;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32
{
    public partial class User32
    {
        /// <summary>
        /// <para>
        /// Confines the cursor to a rectangular area on the screen.
        /// If a subsequent cursor position (set by the <see cref="SetCursorPos"/> function or the mouse) lies outside the rectangle,
        /// the system automatically adjusts the position to keep the cursor inside the rectangular area.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-clipcursor
        /// </para>
        /// </summary>
        /// <param name="lpRect">
        /// A pointer to the structure that contains the screen coordinates of the upper-left and lower-right corners of the confining rectangle.
        /// If this parameter is <see cref="NULL"/>, the cursor is free to move anywhere on the screen.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The cursor is a shared resource.
        /// If an application confines the cursor, it must release the cursor by using <see cref="ClipCursor"/>
        /// before relinquishing control to another application.
        /// The calling process must have <see cref="WINSTA_WRITEATTRIBUTES"/> access to the window station.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ClipCursor", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ClipCursor([In]in RECT lpRect);

        /// <summary>
        /// <para>
        /// Creates a cursor having the specified size, bit patterns, and hot spot.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-createcursor
        /// </para>
        /// </summary>
        /// <param name="hInst">
        /// A handle to the current instance of the application creating the cursor.
        /// </param>
        /// <param name="xHotSpot">
        /// The horizontal position of the cursor's hot spot.
        /// </param>
        /// <param name="yHotSpot">
        /// The vertical position of the cursor's hot spot.
        /// </param>
        /// <param name="nWidth">
        /// The width of the cursor, in pixels.
        /// </param>
        /// <param name="nHeight">
        /// The height of the cursor, in pixels.
        /// </param>
        /// <param name="pvANDPlane">
        /// An array of bytes that contains the bit values for the AND mask of the cursor, as in a device-dependent monochrome bitmap.
        /// </param>
        /// <param name="pvXORPlane">
        /// An array of bytes that contains the bit values for the XOR mask of the cursor, as in a device-dependent monochrome bitmap.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the cursor.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <paramref name="nWidth"/> and <paramref name="nHeight"/> parameters must specify a width and height
        /// that are supported by the current display driver, because the system cannot create cursors of other sizes.
        /// To determine the width and height supported by the display driver, use the <see cref="GetSystemMetrics"/> function,
        /// specifying the <see cref="SM_CXCURSOR"/> or <see cref="SM_CYCURSOR"/> value.
        /// Before closing, an application must call the <see cref="DestroyCursor"/> function to free any system resources associated with the cursor.
        /// DPI Virtualization
        /// This API does not participate in DPI virtualization.
        /// The output returned is in terms of physical coordinates, and is not affected by the DPI of the calling thread.
        /// Note that the cursor created may still be scaled to match the DPI of any given window it is drawn into.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateCursor", ExactSpelling = true, SetLastError = true)]
        public static extern HCURSOR CreateCursor([In]HINSTANCE hInst, [In]int xHotSpot, [In]int yHotSpot, [In]int nWidth, [In]int nHeight,
            [In]IntPtr pvANDPlane, [In]IntPtr pvXORPlane);

        /// <summary>
        /// <para>
        /// Creates an icon that has the specified size, colors, and bit patterns.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-createicon
        /// </para>
        /// </summary>
        /// <param name="hInstance">
        /// A handle to the instance of the module creating the icon.
        /// </param>
        /// <param name="nWidth">
        /// The width, in pixels, of the icon.
        /// </param>
        /// <param name="nHeight">
        /// The height, in pixels, of the icon.
        /// </param>
        /// <param name="cPlanes">
        /// The number of planes in the XOR bitmask of the icon.
        /// </param>
        /// <param name="cBitsPixel">
        /// The number of bits-per-pixel in the XOR bitmask of the icon.
        /// </param>
        /// <param name="lpbANDbits">
        /// An array of bytes that contains the bit values for the AND bitmask of the icon.
        /// This bitmask describes a monochrome bitmap.
        /// </param>
        /// <param name="lpbXORbits">
        /// An array of bytes that contains the bit values for the XOR bitmask of the icon.
        /// This bitmask describes a monochrome or device-dependent color bitmap.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to an icon.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <paramref name="nWidth"/> and <paramref name="nHeight"/> parameters must specify a width and height supported by the current display driver,
        /// because the system cannot create icons of other sizes.
        /// To determine the width and height supported by the display driver, use the <see cref="GetSystemMetrics"/> function,
        /// specifying the <see cref="SM_CXICON"/> or <see cref="SM_CYICON"/> value.
        /// CreateIcon applies the following truth table to the AND and XOR bitmasks.
        /// AND bitmask     XOR bitmask     Display
        /// 0               0               Black
        /// 0               1               White
        /// 1               0               Screen
        /// 1               1               Reverse screen
        /// When you are finished using the icon, destroy it using the <see cref="DestroyIcon"/> function.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateIcon", ExactSpelling = true, SetLastError = true)]
        public static extern HICON CreateIcon([In]HINSTANCE hInstance, [In]int nWidth, [In]int nHeight, [In]BYTE cPlanes, [In]BYTE cBitsPixel,
            [In]IntPtr lpbANDbits, [In]IntPtr lpbXORbits);

        /// <summary>
        /// <para>
        /// Copies the specified cursor.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-copycursor
        /// </para>
        /// </summary>
        /// <param name="pcur">
        /// A handle to the cursor to be copied.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// <see cref="CopyCursor"/> enables an application or DLL to obtain the handle to a cursor shape owned by another module.
        /// Then if the other module is freed, the application is still able to use the cursor shape.
        /// Before closing, an application must call the <see cref="DestroyCursor"/> function to free any system resources associated with the cursor.
        /// Do not use the <see cref="CopyCursor"/> function for animated cursors.
        /// Instead, use the <see cref="CopyImage"/> function.
        /// <see cref="CopyCursor"/> is implemented as a call to the <see cref="CopyIcon"/> function.
        /// <code>
        /// #define CopyCursor(pcur) ((HCURSOR)CopyIcon((HICON)(pcur)))
        /// </code>
        /// </remarks>
        public static HCURSOR CopyCursor(HCURSOR pcur) => CopyIcon(pcur);

        /// <summary>
        /// <para>
        /// Copies the specified icon from another module to the current module.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-copyicon
        /// </para>
        /// </summary>
        /// <param name="hIcon">
        /// A handle to the icon to be copied.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the duplicate icon.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="CopyIcon"/> function enables an application or DLL to get its own handle to an icon owned by another module.
        /// If the other module is freed, the application icon will still be able to use the icon.
        /// Before closing, an application must call the <see cref="DestroyIcon"/> function to free any system resources associated with the icon.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CopyIcon", ExactSpelling = true, SetLastError = true)]
        public static extern HICON CopyIcon([In]HICON hIcon);

        /// <summary>
        /// <para>
        /// Destroys a cursor and frees any memory the cursor occupied.
        /// Do not use this function to destroy a shared cursor.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-destroycursor
        /// </para>
        /// </summary>
        /// <param name="hCursor">
        /// A handle to the cursor to be destroyed.
        /// The cursor must not be in use.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The DestroyCursor function destroys a nonshared cursor.
        /// Do not use this function to destroy a shared cursor. 
        /// A shared cursor is valid as long as the module from which it was loaded remains in memory.
        /// The following functions obtain a shared cursor:
        /// <see cref="LoadCursor"/>
        /// <see cref="LoadCursorFromFile"/>
        /// <see cref="LoadImage"/> (if you use the <see cref="LR_SHARED"/> flag)
        /// <see cref="CopyImage"/> (if you use the <see cref="LR_COPYRETURNORG"/> flag and the hImage parameter is a shared cursor)
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DestroyCursor", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DestroyCursor([In]HCURSOR hCursor);

        /// <summary>
        /// <para>
        /// Destroys an icon and frees any memory the icon occupied.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-destroyicon
        /// </para>
        /// </summary>
        /// <param name="hIcon">
        /// A handle to the icon to be destroyed. The icon must not be in use.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// It is only necessary to call <see cref="DestroyIcon"/> for icons and cursors created with the following functions:
        /// <see cref="CreateIconFromResourceEx"/> (if called without the <see cref="LR_SHARED"/> flag),
        /// <see cref="CreateIconIndirect"/>, and <see cref="CopyIcon"/>.
        /// Do not use this function to destroy a shared icon.
        /// A shared icon is valid as long as the module from which it was loaded remains in memory.
        /// The following functions obtain a shared icon.
        /// <see cref="LoadIcon"/>
        /// <see cref="LoadImage"/> (if you use the <see cref="LR_SHARED"/> flag)
        /// <see cref="CopyImage"/> (if you use the <see cref="LR_COPYRETURNORG"/> flag and the hImage parameter is a shared icon)
        /// <see cref="CreateIconFromResource"/>
        /// <see cref="CreateIconFromResourceEx"/> (if you use the <see cref="LR_SHARED"/> flag)
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DestroyIcon", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DestroyIcon([In]HICON hIcon);

        /// <summary>
        /// <para>
        /// Draws an icon or cursor into the specified device context.
        /// To specify additional drawing options, use the <see cref="DrawIconEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-drawicon
        /// </para>
        /// </summary>
        /// <param name="hDC">
        /// A handle to the device context into which the icon or cursor will be drawn.
        /// </param>
        /// <param name="X">
        /// The logical x-coordinate of the upper-left corner of the icon.
        /// </param>
        /// <param name="Y">
        /// The logical y-coordinate of the upper-left corner of the icon.
        /// </param>
        /// <param name="hIcon">
        /// A handle to the icon to be drawn.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="DrawIcon"/> places the icon's upper-left corner
        /// at the location specified by the <paramref name="X"/> and <paramref name="Y"/> parameters.
        /// The location is subject to the current mapping mode of the device context.
        /// <see cref="DrawIcon"/> draws the icon or cursor using the width and height specified by the system metric values for icons;
        /// for more information, see <see cref="GetSystemMetrics"/>.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DrawIcon", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DrawIcon([In]HDC hDC, [In]int X, [In]int Y, [In]HICON hIcon);

        /// <summary>
        /// <para>
        /// Retrieves the screen coordinates of the rectangular area to which the cursor is confined.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getclipcursor
        /// </para>
        /// </summary>
        /// <param name="lpRect">
        /// A pointer to a <see cref="RECT"/> structure that receives the screen coordinates of the confining rectangle.
        /// The structure receives the dimensions of the screen if the cursor is not confined to a rectangle.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The cursor is a shared resource.
        /// If an application confines the cursor with the <see cref="ClipCursor"/> function,
        /// it must later release the cursor by using <see cref="ClipCursor"/> before relinquishing control to another application.
        /// The calling process must have <see cref="WINSTA_READATTRIBUTES"/> access to the window station.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetClipCursor", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetClipCursor([Out]out RECT lpRect);

        /// <summary>
        /// <para>
        /// Retrieves a handle to the current cursor.
        /// To get information on the global cursor, even if it is not owned by the current thread, use <see cref="GetCursorInfo"/>.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getcursor
        /// </para>
        /// </summary>
        /// <returns>
        /// The return value is the handle to the current cursor.
        /// If there is no cursor, the return value is <see cref="NULL"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCursor", ExactSpelling = true, SetLastError = true)]
        public static extern HCURSOR GetCursor();

        /// <summary>
        /// <para>
        /// Retrieves the position of the mouse cursor, in screen coordinates.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getcursorpos
        /// </para>
        /// </summary>
        /// <param name="lpPoint">
        /// A pointer to a <see cref="POINT"/> structure that receives the screen coordinates of the cursor.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful or <see cref="FALSE"/> otherwise.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The cursor position is always specified in screen coordinates and is not affected by the mapping mode of the window that contains the cursor.
        /// The calling process must have <see cref="WINSTA_READATTRIBUTES"/> access to the window station.
        /// The input desktop must be the current desktop when you call <see cref="GetCursorPos"/>.
        /// Call <see cref="OpenInputDesktop"/> to determine whether the current desktop is the input desktop.
        /// If it is not, call <see cref="SetThreadDesktop"/> with the <see cref="HDESK"/> returned by <see cref="OpenInputDesktop"/> to switch to that desktop.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCursorPos", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetCursorPos([Out]out POINT lpPoint);

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
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [Obsolete("This function has been superseded by the LoadImage function.")]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadCursorW", ExactSpelling = true, SetLastError = true)]
        public static extern HCURSOR LoadCursor([In]IntPtr hInstance, [MarshalAs(UnmanagedType.LPWStr)][In]string lpCursorName);

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
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [Obsolete("This function has been superseded by the LoadImage function.")]
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
        /// <param name="lpIconName">
        /// The name of the icon resource to be loaded.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the newly loaded icon.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [Obsolete("This function has been superseded by the LoadImage function.")]
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
        /// <param name="hInstance">
        /// Must be <see cref="NULL"/>.
        /// </param>
        /// <param name="lpIconName">
        /// The resource identifier in the low-order word and zero in the high-order word.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the newly loaded icon.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [Obsolete("This function has been superseded by the LoadImage function.")]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadIconW", ExactSpelling = true, SetLastError = true)]
        public static extern HICON LoadIcon([In]IntPtr hInstance, [In]SystemIcons lpIconName);

        /// <summary>
        /// <para>
        /// Sets the cursor shape.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setcursor
        /// </para>
        /// </summary>
        /// <param name="hCursor">
        /// A handle to the cursor.
        /// The cursor must have been created by the <see cref="CreateCursor"/> function
        /// or loaded by the <see cref="LoadCursor"/> or <see cref="LoadImage"/> function.
        /// If this parameter is <see cref="NULL"/>, the cursor is removed from the screen.
        /// </param>
        /// <returns>
        /// The return value is the handle to the previous cursor, if there was one.
        /// If there was no previous cursor, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// The cursor is set only if the new cursor is different from the previous cursor; otherwise, the function returns immediately.
        /// The cursor is a shared resource.
        /// A window should set the cursor shape only when the cursor is in its client area or when the window is capturing mouse input.
        /// In systems without a mouse, the window should restore the previous cursor before the cursor leaves the client area
        /// or before it relinquishes control to another window.
        /// If your application must set the cursor while it is in a window, make sure the class cursor
        /// for the specified window's class is set to <see cref="NULL"/>.
        /// If the class cursor is not <see cref="NULL"/>, the system restores the class cursor each time the mouse is moved.
        /// The cursor is not shown on the screen if the internal cursor display count is less than zero.
        /// This occurs if the application uses the <see cref="ShowCursor"/> function to hide the cursor more times than to show the cursor.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetCursor", ExactSpelling = true, SetLastError = true)]
        public static extern HCURSOR SetCursor([In]HCURSOR hCursor);

        /// <summary>
        /// <para>
        /// Moves the cursor to the specified screen coordinates.
        /// If the new coordinates are not within the screen rectangle set by the most recent <see cref="ClipCursor"/> function call,
        /// the system automatically adjusts the coordinates so that the cursor stays within the rectangle.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setcursorpos
        /// </para>
        /// </summary>
        /// <param name="X">
        /// The new x-coordinate of the cursor, in screen coordinates.
        /// </param>
        /// <param name="Y">
        /// The new y-coordinate of the cursor, in screen coordinates.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful or <see cref="FALSE"/> otherwise.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The cursor is a shared resource.
        /// A window should move the cursor only when the cursor is in the window's client area.
        /// The calling process must have <see cref="WINSTA_WRITEATTRIBUTES"/> access to the window station.
        /// The input desktop must be the current desktop when you call <see cref="SetCursorPos"/>.
        /// Call <see cref="OpenInputDesktop"/> to determine whether the current desktop is the input desktop.
        /// If it is not, call <see cref="SetThreadDesktop"/> with the <see cref="HDESK"/> returned by <see cref="OpenInputDesktop"/> to switch to that desktop.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetCursorPos", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetCursorPos([In]int X, [In]int Y);

        /// <summary>
        /// <para>
        /// Displays or hides the cursor.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-showcursor
        /// </para>
        /// </summary>
        /// <param name="bShow">
        /// If <paramref name="bShow"/> is <see cref="TRUE"/>, the display count is incremented by one.
        /// If <paramref name="bShow"/> is <see cref="FALSE"/>, the display count is decremented by one.
        /// </param>
        /// <returns>
        /// The return value specifies the new display counter.
        /// </returns>
        /// <remarks>
        /// Windows 8: Call <see cref="GetCursorInfo"/> to determine the cursor visibility.
        /// This function sets an internal display counter that determines whether the cursor should be displayed.
        /// The cursor is displayed only if the display count is greater than or equal to 0.
        /// If a mouse is installed, the initial display count is 0.
        /// If no mouse is installed, the display count is –1.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShowCursor", ExactSpelling = true, SetLastError = true)]
        public static extern int ShowCursor([In]BOOL bShow);
    }
}
