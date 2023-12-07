using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.DrawingFlags;
using static Lsj.Util.Win32.Enums.ImageTypes;
using static Lsj.Util.Win32.Enums.LoadImageFlags;
using static Lsj.Util.Win32.Enums.ResourceTypes;
using static Lsj.Util.Win32.Enums.SystemColors;
using static Lsj.Util.Win32.Enums.SystemCursors;
using static Lsj.Util.Win32.Enums.SystemIcons;
using static Lsj.Util.Win32.Enums.SystemMetric;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32
{
    public partial class User32
    {
        /// <summary>
        /// <para>
        /// Copies the specified icon from another module to the current module.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-copyicon"/>
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
        public static extern HICON CopyIcon([In] HICON hIcon);

        /// <summary>
        /// <para>
        /// Creates an icon that has the specified size, colors, and bit patterns.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-createicon"/>
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
        public static extern HICON CreateIcon([In] HINSTANCE hInstance, [In] int nWidth, [In] int nHeight, [In] BYTE cPlanes, [In] BYTE cBitsPixel,
            [In] IntPtr lpbANDbits, [In] IntPtr lpbXORbits);

        /// <summary>
        /// <para>
        /// Creates an icon or cursor from resource bits describing the icon.
        /// To specify a desired height or width, use the <see cref="CreateIconFromResourceEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-createiconfromresource"/>
        /// </para>
        /// </summary>
        /// <param name="presbits">
        /// The buffer containing the icon or cursor resource bits.
        /// These bits are typically loaded by calls to the <see cref="LookupIconIdFromDirectory"/>,
        /// <see cref="LookupIconIdFromDirectoryEx"/>, and <see cref="LoadResource"/> functions.
        /// </param>
        /// <param name="dwResSize">
        /// The size, in bytes, of the set of bits pointed to by the <paramref name="presbits"/> parameter.
        /// </param>
        /// <param name="fIcon">
        /// Indicates whether an icon or a cursor is to be created.
        /// If this parameter is <see cref="TRUE"/>, an icon is to be created.
        /// If it is <see cref="FALSE"/>, a cursor is to be created.
        /// </param>
        /// <param name="dwVer">
        /// The version number of the icon or cursor format for the resource bits pointed to by the presbits parameter.
        /// The value must be greater than or equal to 0x00020000 and less than or equal to 0x00030000.
        /// This parameter is generally set to 0x00030000.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the icon or cursor.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="CreateIconFromResource"/>, <see cref="CreateIconFromResourceEx"/>, <see cref="CreateIconIndirect"/>,
        /// <see cref="GetIconInfo"/>, <see cref="LookupIconIdFromDirectory"/>, and <see cref="LookupIconIdFromDirectoryEx"/> functions
        /// allow shell applications and icon browsers to examine and use resources throughout the system.
        /// The <see cref="CreateIconFromResource"/> function calls <see cref="CreateIconFromResourceEx"/>
        /// passing <code>LR_DEFAULTSIZE|LR_SHARED</code> as flags.
        /// When you are finished using the icon, destroy it using the <see cref="DestroyIcon"/> function.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateIconFromResource", ExactSpelling = true, SetLastError = true)]
        public static extern HICON CreateIconFromResource([In] IntPtr presbits, [In] DWORD dwResSize, [In] BOOL fIcon, [In] DWORD dwVer);

        /// <summary>
        /// <para>
        /// Creates an icon or cursor from resource bits describing the icon.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-createiconfromresourceex"/>
        /// </para>
        /// </summary>
        /// <param name="presbits">
        /// The icon or cursor resource bits.
        /// These bits are typically loaded by calls to the <see cref="LookupIconIdFromDirectoryEx"/> and <see cref="LoadResource"/> functions.
        /// </param>
        /// <param name="dwResSize">
        /// The size, in bytes, of the set of bits pointed to by the <paramref name="presbits"/> parameter.
        /// </param>
        /// <param name="fIcon">
        /// Indicates whether an icon or a cursor is to be created.
        /// If this parameter is <see cref="TRUE"/>, an icon is to be created.
        /// If it is <see cref="FALSE"/>, a cursor is to be created.
        /// </param>
        /// <param name="dwVer">
        /// The version number of the icon or cursor format for the resource bits pointed to by the <paramref name="presbits"/> parameter.
        /// The value must be greater than or equal to 0x00020000 and less than or equal to 0x00030000.
        /// This parameter is generally set to 0x00030000.
        /// </param>
        /// <param name="cxDesired">
        /// The desired width, in pixels, of the icon or cursor.
        /// If this parameter is zero, the function uses the <see cref="SM_CXICON"/> or <see cref="SM_CXCURSOR"/> system metric value to set the width.
        /// </param>
        /// <param name="cyDesired">
        /// The desired height, in pixels, of the icon or cursor.
        /// If this parameter is zero, the function uses the <see cref="SM_CYICON"/> or <see cref="SM_CYCURSOR"/> system metric value to set the height.
        /// </param>
        /// <param name="Flags">
        /// A combination of the following values.
        /// <see cref="LR_DEFAULTCOLOR"/>: Uses the default color format.
        /// <see cref="LR_DEFAULTSIZE"/>:
        /// Uses the width or height specified by the system metric values for cursors or icons,
        /// if the <paramref name="cxDesired"/> or <paramref name="cyDesired"/> values are set to zero.
        /// If this flag is not specified and <paramref name="cxDesired"/> and <paramref name="cyDesired"/> are set to zero,
        /// the function uses the actual resource size.
        /// If the resource contains multiple images, the function uses the size of the first image.
        /// <see cref="LR_MONOCHROME"/>: Creates a monochrome icon or cursor.
        /// <see cref="LR_SHARED"/>:
        /// Shares the icon or cursor handle if the icon or cursor is created multiple times.
        /// If <see cref="LR_SHARED"/> is not set, a second call to <see cref="CreateIconFromResourceEx"/> for the same resource
        /// will create the icon or cursor again and return a different handle
        /// When you use this flag, the system will destroy the resource when it is no longer needed.
        /// Do not use <see cref="LR_SHARED"/> for icons or cursors that have non-standard sizes,
        /// that may change after loading, or that are loaded from a file.
        /// When loading a system icon or cursor, you must use <see cref="LR_SHARED"/> or the function will fail to load the resource.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the icon or cursor.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="CreateIconFromResource"/>, <see cref="CreateIconFromResourceEx"/>, <see cref="CreateIconIndirect"/>,
        /// <see cref="GetIconInfo"/>, and <see cref="LookupIconIdFromDirectoryEx"/> functions allow shell applications
        /// and icon browsers to examine and use resources throughout the system.
        /// You should call DestroyIcon for icons created with <see cref="CreateIconFromResourceEx"/>.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateIconFromResourceEx", ExactSpelling = true, SetLastError = true)]
        public static extern HICON CreateIconFromResourceEx([In] IntPtr presbits, [In] DWORD dwResSize, [In] BOOL fIcon, [In] DWORD dwVer,
            [In] int cxDesired, [In] int cyDesired, [In] LoadImageFlags Flags);

        /// <summary>
        /// <para>
        /// Creates an icon or cursor from an <see cref="ICONINFO"/> structure.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-createiconindirect"/>
        /// </para>
        /// </summary>
        /// <param name="piconinfo">
        /// A pointer to an <see cref="ICONINFO"/> structure the function uses to create the icon or cursor.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the icon or cursor that is created.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The system copies the bitmaps in the <see cref="ICONINFO"/> structure before creating the icon or cursor.
        /// Because the system may temporarily select the bitmaps in a device context,
        /// the <see cref="ICONINFO.hbmMask"/> and <see cref="ICONINFO.hbmColor"/> members of the <see cref="ICONINFO"/> structure
        /// should not already be selected into a device context.
        /// The application must continue to manage the original bitmaps and delete them when they are no longer necessary.
        /// When you are finished using the icon, destroy it using the <see cref="DestroyIcon"/> function.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateIconIndirect", ExactSpelling = true, SetLastError = true)]
        public static extern HICON CreateIconIndirect([In] in ICONINFO piconinfo);

        /// <summary>
        /// <para>
        /// Destroys an icon and frees any memory the icon occupied.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-destroyicon"/>
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
        public static extern BOOL DestroyIcon([In] HICON hIcon);

        /// <summary>
        /// <para>
        /// Draws an icon or cursor into the specified device context.
        /// To specify additional drawing options, use the <see cref="DrawIconEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-drawicon"/>
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
        public static extern BOOL DrawIcon([In] HDC hDC, [In] int X, [In] int Y, [In] HICON hIcon);

        /// <summary>
        /// <para>
        /// Draws an icon or cursor into the specified device context, performing the specified raster operations,
        /// and stretching or compressing the icon or cursor as specified.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-drawiconex"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context into which the icon or cursor will be drawn.
        /// </param>
        /// <param name="xLeft">
        /// The logical x-coordinate of the upper-left corner of the icon or cursor.
        /// </param>
        /// <param name="yTop">
        /// The logical y-coordinate of the upper-left corner of the icon or cursor.
        /// </param>
        /// <param name="hIcon">
        /// A handle to the icon or cursor to be drawn. This parameter can identify an animated cursor.
        /// </param>
        /// <param name="cxWidth">
        /// The logical width of the icon or cursor.
        /// If this parameter is zero and the <paramref name="diFlags"/> parameter is <see cref="DI_DEFAULTSIZE"/>,
        /// the function uses the <see cref="SM_CXICON"/> system metric value to set the width.
        /// If this parameter is zero and <see cref="DI_DEFAULTSIZE"/> is not used, the function uses the actual resource width.
        /// </param>
        /// <param name="cyWidth">
        /// The logical height of the icon or cursor.
        /// If this parameter is zero and the <paramref name="diFlags"/> parameter is <see cref="DI_DEFAULTSIZE"/>,
        /// the function uses the <see cref="SM_CYICON"/> system metric value to set the width.
        /// If this parameter is zero and <see cref="DI_DEFAULTSIZE"/> is not used, the function uses the actual resource height.
        /// </param>
        /// <param name="istepIfAniCur">
        /// The index of the frame to draw, if hIcon identifies an animated cursor.
        /// This parameter is ignored if hIcon does not identify an animated cursor.
        /// </param>
        /// <param name="hbrFlickerFreeDraw">
        /// A handle to a brush that the system uses for flicker-free drawing.
        /// If <paramref name="hbrFlickerFreeDraw"/> is a valid brush handle,
        /// the system creates an offscreen bitmap using the specified brush for the background color,
        /// draws the icon or cursor into the bitmap, and then copies the bitmap into the device context identified by <paramref name="hdc"/>.
        /// If <paramref name="hbrFlickerFreeDraw"/> is <see cref="NULL"/>, the system draws the icon or cursor directly into the device context.
        /// </param>
        /// <param name="diFlags">
        /// The drawing flags.
        /// This parameter can be one of the following values.
        /// <see cref="DI_COMPAT"/>: This flag is ignored.
        /// <see cref="DI_DEFAULTSIZE"/>:
        /// Draws the icon or cursor using the width and height specified by the system metric values for icons,
        /// if the <paramref name="cxWidth"/> and <paramref name="cyWidth"/> parameters are set to zero.
        /// If this flag is not specified and <paramref name="cxWidth"/> and <paramref name="cyWidth"/> are set to zero,
        /// the function uses the actual resource size.
        /// <see cref="DI_IMAGE"/>: Draws the icon or cursor using the image.
        /// <see cref="DI_MASK"/>: Draws the icon or cursor using the mask.
        /// <see cref="DI_NOMIRROR"/>: Draws the icon as an unmirrored icon. By default, the icon is drawn as a mirrored icon if hdc is mirrored.
        /// <see cref="DI_NORMAL"/>: Combination of <see cref="DI_IMAGE"/> and <see cref="DI_MASK"/>. 
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="DrawIconEx"/> function places the icon's upper-left corner
        /// at the location specified by the <paramref name="xLeft"/> and <paramref name="yTop"/> parameters.
        /// The location is subject to the current mapping mode of the device context.
        /// To duplicate <code>DrawIcon (hDC, X, Y, hIcon)</code>, call <see cref="DrawIconEx"/> as follows:
        /// <code>DrawIconEx (hDC, X, Y, hIcon, 0, 0, 0, NULL, DI_NORMAL | DI_COMPAT | DI_DEFAULTSIZE); </code>
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DrawIconEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DrawIconEx([In] HDC hdc, [In] int xLeft, [In] int yTop, [In] HICON hIcon, [In] int cxWidth, [In] int cyWidth,
            [In] UINT istepIfAniCur, [In] HBRUSH hbrFlickerFreeDraw, [In] DrawingFlags diFlags);

        /// <summary>
        /// <para>
        /// Retrieves information about the specified icon or cursor.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-geticoninfo"/>
        /// </para>
        /// </summary>
        /// <param name="hIcon">
        /// A handle to the icon or cursor.
        /// To retrieve information about a standard icon or cursor, specify one of the following values.
        /// <see cref="IDC_APPSTARTING"/>: Standard arrow and small hourglass cursor.
        /// <see cref="IDC_ARROW"/>: Standard arrow cursor.
        /// <see cref="IDC_CROSS"/>: Crosshair cursor.
        /// <see cref="IDC_HAND"/>: Hand cursor.
        /// <see cref="IDC_HELP"/>: Arrow and question mark cursor.
        /// <see cref="IDC_IBEAM"/>: I-beam cursor.
        /// <see cref="IDC_NO"/>: Slashed circle cursor.
        /// <see cref="IDC_SIZEALL"/>: Four-pointed arrow cursor pointing north, south, east, and west.
        /// <see cref="IDC_SIZENESW"/>: Double-pointed arrow cursor pointing northeast and southwest.
        /// <see cref="IDC_SIZENS"/>: Double-pointed arrow cursor pointing north and south.
        /// <see cref="IDC_SIZENWSE"/>: Double-pointed arrow cursor pointing northwest and southeast.
        /// <see cref="IDC_SIZEWE"/>: Double-pointed arrow cursor pointing west and east.
        /// <see cref="IDC_UPARROW"/>: Vertical arrow cursor.
        /// <see cref="IDC_WAIT"/>: Hourglass cursor.
        /// <see cref="IDI_APPLICATION"/>: Application icon.
        /// <see cref="IDI_ASTERISK"/>: Asterisk icon.
        /// <see cref="IDI_EXCLAMATION"/>: Exclamation point icon.
        /// <see cref="IDI_HAND"/>: Stop sign icon.
        /// <see cref="IDI_QUESTION"/>: Question-mark icon.
        /// <see cref="IDI_WINLOGO"/>:
        /// Application icon.
        /// Windows 2000: Windows logo icon.
        /// </param>
        /// <param name="piconinfo">
        /// A pointer to an <see cref="ICONINFO"/> structure.
        /// The function fills in the structure's members.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>
        /// and the function fills in the members of the specified <see cref="ICONINFO"/> structure.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="GetIconInfo"/> creates bitmaps for the <see cref="ICONINFO.hbmMask"/>
        /// and <see cref="ICONINFO.hbmColor"/> members of <see cref="ICONINFO"/>.
        /// The calling application must manage these bitmaps and delete them when they are no longer necessary.
        /// DPI Virtualization
        /// This API does not participate in DPI virtualization.
        /// The output returned is not affected by the DPI of the calling thread. 
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetIconInfo", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetIconInfo([In] HICON hIcon, [Out] out ICONINFO piconinfo);

        /// <summary>
        /// <para>
        /// Retrieves information about the specified icon or cursor.
        /// <see cref="GetIconInfoEx"/> extends <see cref="GetIconInfo"/> by using the newer <see cref="ICONINFOEX"/> structure.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-geticoninfoexw"/>
        /// </para>
        /// </summary>
        /// <param name="hIcon">
        /// A handle to the icon or cursor.
        /// To retrieve information about a standard icon or cursor,
        /// specify the identifier beginning with the IDI_ prefix or the identifier beginning with the IDC_ prefix in this parameter.
        /// </param>
        /// <param name="piconinfo">
        /// When this method returns, contains a pointer to an <see cref="ICONINFOEX"/> structure.
        /// The function fills in the structure's members.
        /// </param>
        /// <returns>
        /// <see cref="TRUE"/> indicates success, <see cref="FALSE"/> indicates failure.
        /// </returns>
        /// <remarks>
        /// <see cref="GetIconInfoEx"/> creates bitmaps for the <see cref="ICONINFOEX.hbmMask"/>
        /// and <see cref="ICONINFOEX.hbmColor"/> or members of <see cref="ICONINFOEX"/>.
        /// The calling application must manage these bitmaps and delete them with <see cref="DeleteObject"/> call when they are no longer necessary.
        /// DPI Virtualization
        /// This API does not participate in DPI virtualization.
        /// The output returned is not affected by the DPI of the calling thread. 
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetIconInfoExW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetIconInfoEx([In] HICON hIcon, [Out] out ICONINFOEX piconinfo);

        /// <summary>
        /// <para>
        /// Loads the specified icon resource from the executable (.exe) file associated with an application instance.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-loadiconw"/>
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
        [Obsolete("This function has been superseded by the LoadImage function (with LR_DEFAULTSIZE and LR_SHARED flags set).")]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadIconW", ExactSpelling = true, SetLastError = true)]
        public static extern HICON LoadIcon([In] HINSTANCE hInstance, [In] LPCWSTR lpIconName);

        /// <summary>
        /// <para>
        /// Searches through icon or cursor data for the icon or cursor that best fits the current display device.
        /// To specify a desired height or width, use the <see cref="LookupIconIdFromDirectoryEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-lookupiconidfromdirectory"/>
        /// </para>
        /// </summary>
        /// <param name="presbits">
        /// The icon or cursor directory data.
        /// Because this function does not validate the resource data,
        /// it causes a general protection (GP) fault or returns an undefined value if presbits is not pointing to valid resource data.
        /// </param>
        /// <param name="fIcon">
        /// Indicates whether an icon or a cursor is sought.
        /// If this parameter is <see cref="TRUE"/>, the function is searching for an icon;
        /// if the parameter is <see cref="FALSE"/>, the function is searching for a cursor.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is an integer resource identifier
        /// for the icon or cursor that best fits the current display device.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// A resource file of type <see cref="RT_GROUP_ICON"/> (<see cref="RT_GROUP_CURSOR"/> indicates cursors)
        /// contains icon (or cursor) data in several device-dependent and device-independent formats.
        /// <see cref="LookupIconIdFromDirectory"/> searches the resource file for the icon (or cursor)
        /// that best fits the current display device and returns its integer identifier.
        /// The <see cref="FindResource"/> and <see cref="FindResourceEx"/> functions
        /// use the <see cref="MAKEINTRESOURCE"/> macro with this identifier to locate the resource in the module.
        /// The icon directory is loaded from a resource file with resource type <see cref="RT_GROUP_ICON"/>
        /// (or <see cref="RT_GROUP_CURSOR"/> for cursors), and an integer resource name for the specific icon to be loaded.
        /// <see cref="LookupIconIdFromDirectory"/> returns an integer identifier
        /// that is the resource name of the icon that best fits the current display device.
        /// The <see cref="LoadIcon"/>, <see cref="LoadCursor"/>, and <see cref="LoadImage"/> functions
        /// use this function to search the specified resource data for the icon or cursor that best fits the current display device.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LookupIconIdFromDirectory", ExactSpelling = true, SetLastError = true)]
        public static extern int LookupIconIdFromDirectory([In] IntPtr presbits, [In] BOOL fIcon);

        /// <summary>
        /// <para>
        /// Searches through icon or cursor data for the icon or cursor that best fits the current display device.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-lookupiconidfromdirectoryex"/>
        /// </para>
        /// </summary>
        /// <param name="presbits">
        /// The icon or cursor directory data.
        /// Because this function does not validate the resource data, it causes a general protection (GP) fault
        /// or returns an undefined value if presbits is not pointing to valid resource data.
        /// </param>
        /// <param name="fIcon">
        /// Indicates whether an icon or a cursor is sought.
        /// If this parameter is <see cref="TRUE"/>, the function is searching for an icon;
        /// if the parameter is <see cref="FALSE"/>, the function is searching for a cursor.
        /// </param>
        /// <param name="cxDesired">
        /// The desired width, in pixels, of the icon
        /// If this parameter is zero, the function uses the <see cref="SM_CXICON"/> or <see cref="SM_CXCURSOR"/> system metric value.
        /// </param>
        /// <param name="cyDesired">
        /// The desired height, in pixels, of the icon.
        /// If this parameter is zero, the function uses the <see cref="SM_CYICON"/> or <see cref="SM_CYCURSOR"/> system metric value.
        /// </param>
        /// <param name="Flags">
        /// A combination of the following values.
        /// <see cref="LR_DEFAULTCOLOR"/>: Uses the default color format.
        /// <see cref="LR_MONOCHROME"/>: Creates a monochrome icon or cursor.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is an integer resource identifier for the icon
        /// or cursor that best fits the current display device.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// A resource file of type <see cref="RT_GROUP_ICON"/> (<see cref="RT_GROUP_CURSOR"/> indicates cursors)
        /// contains icon (or cursor) data in several device-dependent and device-independent formats.
        /// <see cref="LookupIconIdFromDirectoryEx"/> searches the resource file for the icon (or cursor) that best fits
        /// the current display device and returns its integer identifier.
        /// The <see cref="FindResource"/> and <see cref="FindResourceEx"/> functions use the <see cref="MAKEINTRESOURCE"/> macro
        /// with this identifier to locate the resource in the module.
        /// The icon directory is loaded from a resource file with resource type <see cref="RT_GROUP_ICON"/>
        /// (or <see cref="RT_GROUP_CURSOR"/> for cursors), and an integer resource name for the specific icon to be loaded.
        /// <see cref="LookupIconIdFromDirectoryEx"/> returns an integer identifier that is the resource name
        /// of the icon that best fits the current display device.
        /// The <see cref="LoadIcon"/>, <see cref="LoadImage"/>, and <see cref="LoadCursor"/> functions use this function
        /// to search the specified resource data for the icon or cursor that best fits the current display device.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LookupIconIdFromDirectoryEx", ExactSpelling = true, SetLastError = true)]
        public static extern int LookupIconIdFromDirectoryEx([In] IntPtr presbits, [In] BOOL fIcon, [In] int cxDesired,
            [In] int cyDesired, [In] LoadImageFlags Flags);

        /// <summary>
        /// <para>
        /// Creates an array of handles to icons that are extracted from a specified file.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-privateextracticonsw"/>
        /// </para>
        /// </summary>
        /// <param name="szFileName">
        /// The path and name of the file from which the icon(s) are to be extracted.
        /// </param>
        /// <param name="nIconIndex">
        /// The zero-based index of the first icon to extract.
        /// For example, if this value is zero, the function extracts the first icon in the specified file.
        /// </param>
        /// <param name="cxIcon">
        /// The horizontal icon size wanted.
        /// See Remarks.
        /// </param>
        /// <param name="cyIcon">
        /// The vertical icon size wanted.
        /// See Remarks.
        /// </param>
        /// <param name="phicon">
        /// A pointer to the returned array of icon handles.
        /// </param>
        /// <param name="piconid">
        /// A pointer to a returned resource identifier for the icon that best fits the current display device.
        /// The returned identifier is 0xFFFFFFFF if the identifier is not available for this format.
        /// The returned identifier is 0 if the identifier cannot otherwise be obtained.
        /// </param>
        /// <param name="nIcons">
        /// The number of icons to extract from the file.
        /// This parameter is only valid when extracting from .exe and .dll files.
        /// </param>
        /// <param name="flags">
        /// Specifies flags that control this function.
        /// These flags are the LR_* flags used by the <see cref="LoadImage"/> function.
        /// </param>
        /// <returns>
        /// If the <paramref name="phicon"/> parameter is <see langword="null"/> and this function succeeds,
        /// then the return value is the number of icons in the file.
        /// If the function fails then the return value is 0.
        /// If the <paramref name="phicon"/> parameter is not <see langword="null"/> and the function succeeds,
        /// then the return value is the number of icons extracted.
        /// Otherwise, the return value is 0xFFFFFFFF if the file is not found.
        /// </returns>
        /// <remarks>
        /// This function extracts from executable (.exe), DLL (.dll), icon (.ico), cursor (.cur), animated cursor (.ani), and bitmap (.bmp) files.
        /// Extractions from Windows 3.x 16-bit executables (.exe or .dll) are also supported.
        /// The <paramref name="cxIcon"/> and <paramref name="cyIcon"/> parameters specify the size of the icons to extract.
        /// Two sizes can be extracted by putting the first size in the LOWORD of the parameter and the second size in the HIWORD.
        /// For example, <code>MAKELONG(24, 48)</code> for both the <paramref name="cxIcon"/> and <paramref name="cyIcon"/> parameters
        /// would extract both 24 and 48 size icons.
        /// You must destroy all icons extracted by <see cref="PrivateExtractIcons"/> by calling the <see cref="DestroyIcon"/> function.
        /// This function was not included in the SDK headers and libraries until Windows XP Service Pack 1 (SP1) and Windows Server 2003.
        /// If you do not have a header file and import library for this function,
        /// you can call the function using <see cref="LoadLibrary"/> and <see cref="GetProcAddress"/>.
        /// </remarks>
        [Obsolete("This function is not intended for general use. It may be altered or unavailable in subsequent versions of Windows.")]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "PrivateExtractIconsW", ExactSpelling = true, SetLastError = true)]
        public static extern UINT PrivateExtractIcons([In] LPCWSTR szFileName, [In] int nIconIndex, [In] int cxIcon, [In] int cyIcon,
            [Out] HICON[] phicon, [Out] out UINT piconid, [In] UINT nIcons, [In] LoadImageFlags flags);
    }
}
