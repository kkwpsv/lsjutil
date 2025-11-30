using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.LoadResourceFlags;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.SystemMetricIndexes;
using static Lsj.Util.Win32.Enums.WindowStationAccessRights;
using static Lsj.Util.Win32.Gdi32;
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
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-clipcursor"/>
        /// </para>
        /// </summary>
        /// <param name="lpRect">
        /// A pointer to the structure that contains the screen coordinates of the upper-left and lower-right corners of the confining rectangle.
        /// If this parameter is <see cref="NULL"/>, the cursor is free to move anywhere on the screen.
        /// </param>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <remarks>
        /// <para>
        /// The cursor is a shared resource.
        /// If an application confines the cursor, it must release the cursor by using <see cref="ClipCursor"/>
        /// before relinquishing control to another application.
        /// </para>
        /// <para>
        /// The calling process must have <see cref="WINSTA_WRITEATTRIBUTES"/> access to the window station.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ClipCursor", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ClipCursor([In] in RECT lpRect);

        /// <summary>
        /// <para>
        /// Copies the specified cursor.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-copycursor"/>
        /// </para>
        /// </summary>
        /// <param name="pcur">
        /// A handle to the cursor to be copied.
        /// </param>
        /// <returns>
        /// <para>
        /// If the call succeeds, the return value is a handle to the duplicate cursor.
        /// </para>
        /// <para>
        /// If the call fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="CopyCursor"/> enables an application or DLL to obtain the handle to a cursor shape owned by another module.
        /// Then if the other module is freed, the application is still able to use the cursor shape.
        /// </para>
        /// <para>
        /// Before closing, an application must call the <see cref="DestroyCursor"/> function to free any system resources associated with the cursor.
        /// </para>
        /// <para>
        /// Do not use the <see cref="CopyCursor"/> function for animated cursors.
        /// Instead, use the <see cref="CopyImage"/> function.
        /// </para>
        /// <para>
        /// <see cref="CopyCursor"/> is implemented as a call to the <see cref="CopyIcon"/> function.
        /// </para>
        /// <code>
        /// #define CopyCursor(pcur) ((HCURSOR)CopyIcon((HICON)(pcur)))
        /// </code>
        /// </remarks>
        public static HCURSOR CopyCursor(HCURSOR pcur) => CopyIcon(pcur);

        /// <summary>
        /// <para>
        /// Creates a monochrome cursor having the specified size, bit patterns, and hot spot.
        /// </para>
        /// <para>
        /// To create a colored cursor at run time you can use the <see cref="CreateIconIndirect"/> function,
        /// which creates a cursor based on the content of an <see cref="ICONINFO"/> structure.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-createcursor"/>
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
        /// An array of bytes that contains the bit values for the AND mask of the cursor, as in a monochrome bitmap.
        /// See remarks.
        /// </param>
        /// <param name="pvXORPlane">
        /// An array of bytes that contains the bit values for the XOR mask of the cursor, as in a monochrome bitmap.
        /// See remarks.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the cursor.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To determine the nominal size of a cursor, use the <see cref="GetSystemMetrics"/> function,
        /// specifying the <see cref="SM_CXCURSOR"/> or <see cref="SM_CYCURSOR"/> value.
        /// Also, you can use the DPI-aware version of this API, see <see cref="GetSystemMetricsForDpi"/>.
        /// For more information see High DPI Desktop Application Development on Windows.
        /// </para>
        /// <para>
        /// For more information about <paramref name="pvANDPlane"/> and <paramref name="pvXORPlane"/> parameters
        /// see description of <c>lpBits</c> parameter of <see cref="CreateBitmap"/> function.
        /// </para>
        /// <para>
        /// <see cref="CreateCursor"/> applies the following truth table to the AND and XOR bitmasks:
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// AND bitmask
        /// </term>
        /// <term>
        /// XOR bitmask
        /// </term>
        /// <term>
        /// Display
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0
        /// </term>
        /// <term>
        /// 0
        /// </term>
        /// <term>
        /// Black
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 0
        /// </term>
        /// <term>
        /// 1
        /// </term>
        /// <term>
        /// White
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 1
        /// </term>
        /// <term>
        /// 0
        /// </term>
        /// <term>
        /// Screen
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 1
        /// </term>
        /// <term>
        /// 1
        /// </term>
        /// <term>
        /// Reverse screen
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Before closing, an application must call the <see cref="DestroyCursor"/> function to free any system resources associated with the cursor.
        /// </para>
        /// <para>
        /// DPI Virtualization
        /// </para>
        /// <para>
        /// This API does not participate in DPI virtualization.
        /// The output returned is in terms of physical coordinates, and is not affected by the DPI of the calling thread.
        /// Note that the cursor created may still be scaled to match the DPI of any given window it is drawn into.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateCursor", ExactSpelling = true, SetLastError = true)]
        public static extern HCURSOR CreateCursor([In] HINSTANCE hInst, [In] int xHotSpot, [In] int yHotSpot, [In] int nWidth, [In] int nHeight,
            [In] IntPtr pvANDPlane, [In] IntPtr pvXORPlane);

        /// <summary>
        /// <para>
        /// Destroys a cursor and frees any memory the cursor occupied.
        /// Do not use this function to destroy a shared cursor.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-destroycursor"/>
        /// </para>
        /// </summary>
        /// <param name="hCursor">
        /// A handle to the cursor to be destroyed.
        /// The cursor must not be in use.
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
        /// The <see cref="DestroyCursor"/> function destroys a nonshared cursor.
        /// Do not use this function to destroy a shared cursor.
        /// A shared cursor is valid as long as the module from which it was loaded remains in memory.
        /// The following functions obtain a shared cursor:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="LoadCursor"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LoadCursorFromFile"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LoadImage"/> (if you use the <see cref="LR_SHARED"/> flag)
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CopyImage"/> (if you use the <see cref="LR_COPYRETURNORG"/> flag and the <c>hImage</c> parameter is a shared cursor)
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DestroyCursor", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DestroyCursor([In] HCURSOR hCursor);

        /// <summary>
        /// <para>
        /// Retrieves the screen coordinates of the rectangular area to which the cursor is confined.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getclipcursor"/>
        /// </para>
        /// </summary>
        /// <param name="lpRect">
        /// A pointer to a <see cref="RECT"/> structure that receives the screen coordinates of the confining rectangle.
        /// The structure receives the dimensions of the screen if the cursor is not confined to a rectangle.
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
        /// The cursor is a shared resource.
        /// If an application confines the cursor with the <see cref="ClipCursor"/> function,
        /// it must later release the cursor by using <see cref="ClipCursor"/> before relinquishing control to another application.
        /// </para>
        /// <para>
        /// The calling process must have <see cref="WINSTA_READATTRIBUTES"/> access to the window station.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetClipCursor", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetClipCursor([Out] out RECT lpRect);

        /// <summary>
        /// <para>
        /// Retrieves a handle to the current cursor.
        /// </para>
        /// <para>
        /// To get information on the global cursor, even if it is not owned by the current thread, use <see cref="GetCursorInfo"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getcursor"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// The return value is the handle to the current cursor.
        /// If there is no cursor, the return value is <see cref="NULL"/>.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCursor", ExactSpelling = true, SetLastError = true)]
        public static extern HCURSOR GetCursor();

        /// <summary>
        /// <para>
        /// Retrieves information about the global cursor.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getcursorinfo"/>
        /// </para>
        /// </summary>
        /// <param name="pci">
        /// A pointer to a <see cref="CURSORINFO"/> structure that receives the information.
        /// Note that you must set the <see cref="CURSORINFO.cbSize"/> member to <c>sizeof(CURSORINFO)</c> before calling this function.
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
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCursorInfo", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetCursorInfo([In][Out] ref CURSORINFO pci);

        /// <summary>
        /// <para>
        /// Retrieves the position of the mouse cursor, in screen coordinates.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getcursorpos"/>
        /// </para>
        /// </summary>
        /// <param name="lpPoint">
        /// A pointer to a <see cref="POINT"/> structure that receives the screen coordinates of the cursor.
        /// </param>
        /// <returns>
        /// Returns nonzero if successful or zero otherwise.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The cursor position is always specified in screen coordinates and is not affected by the mapping mode of the window that contains the cursor.
        /// </para>
        /// <para>
        /// The calling process must have <see cref="WINSTA_READATTRIBUTES"/> access to the window station.
        /// </para>
        /// <para>
        /// The input desktop must be the current desktop when you call <see cref="GetCursorPos"/>.
        /// Call <see cref="OpenInputDesktop"/> to determine whether the current desktop is the input desktop.
        /// If it is not, call <see cref="SetThreadDesktop"/> with the <see cref="HDESK"/> returned by <see cref="OpenInputDesktop"/> to switch to that desktop.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCursorPos", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetCursorPos([Out] out POINT lpPoint);

        /// <summary>
        /// <para>
        /// Retrieves the position of the cursor in physical coordinates.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getphysicalcursorpos"/>
        /// </para>
        /// </summary>
        /// <param name="lpPoint">
        /// The position of the cursor, in physical coordinates.
        /// </param>
        /// <returns>
        /// <para>
        /// <see cref="TRUE"/> if successful; otherwise <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// <see cref="GetLastError"/> can be called to get more information about any error that is generated.
        /// </para>
        /// </returns>
        /// <remarks>
        /// For a description of the difference between logical coordinates and physical coordinates, see <see cref="PhysicalToLogicalPoint"/>.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPhysicalCursorPos", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetPhysicalCursorPos([Out] out POINT lpPoint);

        /// <summary>
        /// <para>
        /// Loads the specified cursor resource from the executable (.EXE) file associated with an application instance.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-loadcursorw"/>
        /// </para>
        /// </summary>
        /// <param name="hInstance">
        /// <para>
        /// A handle to the module of either a DLL or executable (.exe) file that contains the cursor to be loaded.
        /// For more information, see <see cref="GetModuleHandle"/>.
        /// </para>
        /// <para>
        /// To load a predefined system cursor, set this parameter to <see cref="NULL"/>.
        /// </para>
        /// </param>
        /// <param name="lpCursorName">
        /// <para>
        /// If <paramref name="hInstance"/> is non-<see cref="NULL"/>,
        /// <paramref name="lpCursorName"/> specifies the cursor resource either by name or ordinal.
        /// This ordinal must be packaged by using the <see cref="MAKEINTRESOURCE"/> macro.
        /// </para>
        /// <para>
        /// If <paramref name="hInstance"/> is <see cref="NULL"/>,
        /// <paramref name="lpCursorName"/> specifies the identifier that begins with the <c>IDC_</c> prefix of a predefined system cursor to load.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the handle to the newly loaded cursor.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="LoadCursor"/> function loads the cursor resource only if it has not been loaded;
        /// otherwise, it retrieves the handle to the existing resource.
        /// This function returns a valid cursor handle only if the <paramref name="lpCursorName"/> parameter is a pointer to a cursor resource.
        /// If <paramref name="lpCursorName"/> is a pointer to any type of resource other than a cursor (such as an icon),
        /// the return value is not <see cref="NULL"/>, even though it is not a valid cursor handle.
        /// </para>
        /// <para>
        /// The <see cref="LoadCursor"/> function searches the cursor resource most appropriate for the cursor for the current display device.
        /// The cursor resource can be a color or monochrome bitmap.
        /// </para>
        /// <para>
        /// DPI Virtualization
        /// </para>
        /// <para>
        /// This API does not participate in DPI virtualization.
        /// The output returned is not affected by the DPI of the calling thread.
        /// </para>
        /// </remarks>
        [Obsolete("This function has been superseded by the LoadImage function (with LR_DEFAULTSIZE and LR_LOADFROMFILE flags set).")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadCursorW", ExactSpelling = true, SetLastError = true)]
        public static extern HCURSOR LoadCursor([In] HINSTANCE hInstance, [In] LPWSTR lpCursorName);

        /// <summary>
        /// <para>
        /// Creates a cursor based on data contained in a file.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-loadcursorfromfilew"/>
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// <para>
        /// The source of the file data to be used to create the cursor.
        /// The data in the file must be in either .CUR or .ANI format.
        /// </para>
        /// <para>
        /// If the high-order word of <paramref name="lpFileName"/> is nonzero,
        /// it is a pointer to a string that is a fully qualified name of a file containing cursor data.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function is successful, the return value is a handle to the new cursor.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// <see cref="GetLastError"/> may return the following value.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_FILE_NOT_FOUND"/>
        /// </term>
        /// <term>
        /// The specified file cannot be found.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// DPI Virtualization
        /// </para>
        /// <para>
        /// This API does not participate in DPI virtualization.
        /// The output returned is not affected by the DPI of the calling thread.
        /// </para>
        /// </remarks>
        [Obsolete("This function has been superseded by the LoadImage function (with LR_DEFAULTSIZE and LR_LOADFROMFILE flags set).")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadCursorFromFileW", ExactSpelling = true, SetLastError = true)]
        public static extern HCURSOR LoadCursorFromFile([In] LPCWSTR lpFileName);

        /// <summary>
        /// <para>
        /// Sets the cursor shape.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setcursor"/>
        /// </para>
        /// </summary>
        /// <param name="hCursor">
        /// <para>
        /// A handle to the cursor.
        /// </para>
        /// <para>
        /// The cursor must have been created by either the <see cref="CreateCursor"/> or the <see cref="CreateIconIndirect"/> function,
        /// or loaded by either the <see cref="LoadCursor"/> or the <see cref="LoadImage"/> function.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NULL"/>, the cursor is removed from the screen.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// The return value is the handle to the previous cursor, if there was one.
        /// </para>
        /// <para>
        /// If there was no previous cursor, the return value is <see cref="NULL"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The cursor is set only if the new cursor is different from the previous cursor; otherwise, the function returns immediately.
        /// </para>
        /// <para>
        /// The cursor is a shared resource.
        /// A window should set the cursor shape only when the cursor is in its client area or when the window is capturing mouse input.
        /// In systems without a mouse, the window should restore the previous cursor
        /// before the cursor leaves the client area or before it relinquishes control to another window.
        /// </para>
        /// <para>
        /// If your application must set the cursor while it is in a window,
        /// make sure the class cursor for the specified window's class is set to <see cref="NULL"/>.
        /// If the class cursor is not <see cref="NULL"/>, the system restores the class cursor each time the mouse is moved.
        /// </para>
        /// <para>
        /// The cursor is not shown on the screen if the internal cursor display count is less than zero.
        /// This occurs if the application uses the <see cref="ShowCursor"/> function to hide the cursor more times than to show the cursor.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetCursor", ExactSpelling = true)]
        public static extern HCURSOR SetCursor([In] HCURSOR hCursor);

        /// <summary>
        /// <para>
        /// Moves the cursor to the specified screen coordinates.
        /// If the new coordinates are not within the screen rectangle set by the most recent <see cref="ClipCursor"/> function call,
        /// the system automatically adjusts the coordinates so that the cursor stays within the rectangle.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setcursorpos"/>
        /// </para>
        /// </summary>
        /// <param name="X">
        /// The new x-coordinate of the cursor, in screen coordinates.
        /// </param>
        /// <param name="Y">
        /// The new y-coordinate of the cursor, in screen coordinates.
        /// </param>
        /// <returns>
        /// Returns nonzero if successful or zero otherwise.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The cursor is a shared resource.
        /// A window should move the cursor only when the cursor is in the window's client area.
        /// </para>
        /// <para>
        /// The calling process must have <see cref="WINSTA_WRITEATTRIBUTES"/> access to the window station.
        /// </para>
        /// <para>
        /// The input desktop must be the current desktop when you call <see cref="SetCursorPos"/>.
        /// Call <see cref="OpenInputDesktop"/> to determine whether the current desktop is the input desktop.
        /// If it is not, call <see cref="SetThreadDesktop"/> with the <see cref="HDESK"/> returned by <see cref="OpenInputDesktop"/> to switch to that desktop.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetCursorPos", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetCursorPos([In] int X, [In] int Y);

        /// <summary>
        /// <para>
        /// Sets the position of the cursor in physical coordinates.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setphysicalcursorpos"/>
        /// </para>
        /// </summary>
        /// <param name="X">
        /// The new x-coordinate of the cursor, in physical coordinates.
        /// </param>
        /// <param name="Y">
        /// The new y-coordinate of the cursor, in physical coordinates.
        /// </param>
        /// <returns>
        /// <see cref="TRUE"/> if successful; otherwise <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// For a description of the difference between logical coordinates and physical coordinates, see <see cref="PhysicalToLogicalPoint"/>.
        /// </para>
        /// <para>
        /// <see cref="GetLastError"/> can be called to get more information about any error that is generated.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetPhysicalCursorPos", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetPhysicalCursorPos([In] int X, [In] int Y);

        /// <summary>
        /// <para>
        /// Enables an application to customize the system cursors.
        /// It replaces the contents of the system cursor specified by the id parameter with the contents of the cursor
        /// specified by the <paramref name="hcur"/> parameter and then destroys <paramref name="hcur"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setsystemcursor"/>
        /// </para>
        /// </summary>
        /// <param name="hcur">
        /// <para>
        /// A handle to the cursor.
        /// The function replaces the contents of the system cursor specified by <paramref name="id"/>
        /// with the contents of the cursor handled by <paramref name="hcur"/>.
        /// </para>
        /// <para>
        /// The system destroys <paramref name="hcur"/> by calling the <see cref="DestroyCursor"/> function.
        /// Therefore, <paramref name="hcur"/> cannot be a cursor loaded using the <see cref="LoadCursor"/> function.
        /// To specify a cursor loaded from a resource, copy the cursor using the <see cref="CopyCursor"/> function,
        /// then pass the copy to <see cref="SetSystemCursor"/>.
        /// </para>
        /// </param>
        /// <param name="id">
        /// <para>
        /// The system cursor to replace with the contents of <paramref name="hcur"/>.
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
        /// <para>
        /// <see cref="OCR_NORMAL"/>
        /// </para>
        /// <para>
        /// <c>32512</c>
        /// </para>
        /// </term>
        /// <term>
        /// Normal select
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OCR_IBEAM"/>
        /// </para>
        /// <para>
        /// <c>32513</c>
        /// </para>
        /// </term>
        /// <term>
        /// Text select
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OCR_WAIT"/>
        /// </para>
        /// <para>
        /// <c>32514</c>
        /// </para>
        /// </term>
        /// <term>
        /// Busy
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OCR_CROSS"/>
        /// </para>
        /// <para>
        /// <c>32515</c>
        /// </para>
        /// </term>
        /// <term>
        /// Precision select
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OCR_UP"/>
        /// </para>
        /// <para>
        /// <c>32516</c>
        /// </para>
        /// </term>
        /// <term>
        /// Alternate select
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OCR_SIZENWSE"/>
        /// </para>
        /// <para>
        /// <c>32642</c>
        /// </para>
        /// </term>
        /// <term>
        /// Diagonal resize 1
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OCR_SIZENESW"/>
        /// </para>
        /// <para>
        /// <c>32643</c>
        /// </para>
        /// </term>
        /// <term>
        /// Diagonal resize 2
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OCR_SIZEWE"/>
        /// </para>
        /// <para>
        /// <c>32644</c>
        /// </para>
        /// </term>
        /// <term>
        /// Horizontal resize
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OCR_SIZENS"/>
        /// </para>
        /// <para>
        /// <c>32645</c>
        /// </para>
        /// </term>
        /// <term>
        /// Vertical resize
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OCR_SIZEALL"/>
        /// </para>
        /// <para>
        /// <c>32646</c>
        /// </para>
        /// </term>
        /// <term>
        /// Move
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OCR_NO"/>
        /// </para>
        /// <para>
        /// <c>32648</c>
        /// </para>
        /// </term>
        /// <term>
        /// Unavailable
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OCR_HAND"/>
        /// </para>
        /// <para>
        /// <c>32649</c>
        /// </para>
        /// </term>
        /// <term>
        /// Link select
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OCR_APPSTARTING"/>
        /// </para>
        /// <para>
        /// <c>32650</c>
        /// </para>
        /// </term>
        /// <term>
        /// Working in background
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
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// For an application to use any of the <c>OCR_</c> constants,
        /// the constant <c>OEMRESOURCE</c> must be defined before the Windows.h header file is included.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetSystemCursor", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetSystemCursor([In] HCURSOR hcur, [In] DWORD id);

        /// <summary>
        /// <para>
        /// Displays or hides the cursor.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-showcursor"/>
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
        /// <para>
        /// Windows 8: Call <see cref="GetCursorInfo"/> to determine the cursor visibility.
        /// </para>
        /// <para>
        /// This function sets an internal display counter that determines whether the cursor should be displayed.
        /// The cursor is displayed only if the display count is greater than or equal to 0.
        /// If a mouse is installed, the initial display count is 0.
        /// If no mouse is installed, the display count is –1.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShowCursor", ExactSpelling = true)]
        public static extern int ShowCursor([In] BOOL bShow);
    }
}
