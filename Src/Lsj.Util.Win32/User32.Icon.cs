using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.DrawIconFlags;
using static Lsj.Util.Win32.Enums.LoadResourceFlags;
using static Lsj.Util.Win32.Enums.ResourceTypes;
using static Lsj.Util.Win32.Enums.StandardCursors;
using static Lsj.Util.Win32.Enums.SystemIcons;
using static Lsj.Util.Win32.Enums.RasterCodes;
using static Lsj.Util.Win32.Enums.SystemMetricIndexes;
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
        /// <para>
        /// If the function succeeds, the return value is a handle to the duplicate icon.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="CopyIcon"/> function enables an application or DLL to get its own handle to an icon owned by another module.
        /// If the other module is freed, the application icon will still be able to use the icon.
        /// </para>
        /// <para>
        /// Before closing, an application must call the <see cref="DestroyIcon"/> function to free any system resources associated with the icon.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CopyIcon", ExactSpelling = true, SetLastError = true)]
        public static extern HICON CopyIcon([In] HICON hIcon);

        /// <summary>
        /// <para>
        /// Creates an icon that has the specified size, colors, and bit patterns.
        /// </para>
        /// <para>
        /// To create a colored icon at run time you can use the <see cref="CreateIconIndirect"/> function,
        /// which creates a icon based on the content of an <see cref="ICONINFO"/> structure.
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
        /// See remarks.
        /// </param>
        /// <param name="lpbXORbits">
        /// An array of bytes that contains the bit values for the XOR bitmask of the icon.
        /// This bitmask describes a monochrome or device-dependent color bitmap.
        /// See remarks.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to an icon.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To determine the nominal size of the icon, use the <see cref="GetSystemMetrics"/> function,
        /// specifying the <see cref="SM_CXICON"/> or <see cref="SM_CYICON"/> value.
        /// Also, you can use the DPI-aware version of this API, see <see cref="GetSystemMetricsForDpi"/>.
        /// For more information see Icon Sizes and High DPI Desktop Application Development on Windows.
        /// </para>
        /// <para>
        /// For more information about <paramref name="lpbANDbits"/> and <paramref name="lpbXORbits"/> parameters
        /// see description of <c>lpBits</c> parameter of <see cref="CreateBitmap"/> function.
        /// </para>
        /// <para>
        /// In case of monochrome icon <see cref="CreateIcon"/> applies the following truth table to the AND and XOR bitmasks:
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
        /// When you are finished using the icon, destroy it using the <see cref="DestroyIcon"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateIcon", ExactSpelling = true, SetLastError = true)]
        public static extern HICON CreateIcon([In] HINSTANCE hInstance, [In] int nWidth, [In] int nHeight, [In] BYTE cPlanes, [In] BYTE cBitsPixel,
            [In] nint lpbANDbits, [In] nint lpbXORbits);

        /// <summary>
        /// <para>
        /// Creates an icon or cursor from resource bits describing the icon.
        /// </para>
        /// <para>
        /// To specify a desired height or width, use the <see cref="CreateIconFromResourceEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-createiconfromresource"/>
        /// </para>
        /// </summary>
        /// <param name="presbits">
        /// <para>
        /// The <see cref="DWORD"/>-aligned buffer pointer containing the icon or cursor resource bits.
        /// These bits are typically loaded by calls to the <see cref="LookupIconIdFromDirectory"/>,
        /// <see cref="LookupIconIdFromDirectoryEx"/>, and <see cref="LoadResource"/> functions.
        /// </para>
        /// <para>
        /// See Cursor and Icon Resources for more info on icon and cursor resource format.
        /// </para>
        /// </param>
        /// <param name="dwResSize">
        /// The size, in bytes, of the set of bits pointed to by the <paramref name="presbits"/> parameter.
        /// </param>
        /// <param name="fIcon">
        /// <para>
        /// Indicates whether an icon or a cursor is to be created.
        /// If this parameter is <see cref="TRUE"/>, an icon is to be created.
        /// If it is <see cref="FALSE"/>, a cursor is to be created.
        /// </para>
        /// <para>
        /// The <see cref="LOCALHEADER"/> structure defines cursor hotspot and is the first data read from the cursor resource bits.
        /// </para>
        /// </param>
        /// <param name="dwVer">
        /// The version number of the icon or cursor format for the resource bits pointed to by the presbits parameter.
        /// The value must be greater than or equal to 0x00020000 and less than or equal to 0x00030000.
        /// This parameter is generally set to 0x00030000.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the icon or cursor.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="CreateIconFromResource"/>, <see cref="CreateIconFromResourceEx"/>, <see cref="CreateIconIndirect"/>,
        /// <see cref="GetIconInfo"/>, <see cref="LookupIconIdFromDirectory"/>, and <see cref="LookupIconIdFromDirectoryEx"/> functions
        /// allow shell applications and icon browsers to examine and use resources throughout the system.
        /// </para>
        /// <para>
        /// The <see cref="CreateIconFromResource"/> function calls <see cref="CreateIconFromResourceEx"/> passing <c>LR_DEFAULTSIZE|LR_SHARED</c> as flags.
        /// </para>
        /// <para>
        /// You should call <see cref="DestroyIcon"/> for icons or <see cref="DestroyCursor"/> for cursors created with <see cref="CreateIconFromResource"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateIconFromResource", ExactSpelling = true, SetLastError = true)]
        public static extern HICON CreateIconFromResource(
#if NETFRAMEWORK
            [In] nint presbits,
#else
            [In] P<BYTE> presbits,
#endif
            [In] DWORD dwResSize, [In] BOOL fIcon, [In] DWORD dwVer);

        /// <summary>
        /// <para>
        /// Creates an icon or cursor from resource bits describing the icon.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-createiconfromresourceex"/>
        /// </para>
        /// </summary>
        /// <param name="presbits">
        /// <para>
        /// The DWORD-aligned buffer pointer containing the icon (<see cref="RT_ICON"/>) or cursor (<see cref="RT_CURSOR"/>) resource bits.
        /// These bits are typically loaded by calls to the <see cref="LookupIconIdFromDirectoryEx"/> and <see cref="LoadResource"/> functions.
        /// </para>
        /// <para>
        /// See Cursor and Icon Resources for more info on icon and cursor resource format.
        /// </para>
        /// </param>
        /// <param name="dwResSize">
        /// The size, in bytes, of the set of bits pointed to by the <paramref name="presbits"/> parameter.
        /// </param>
        /// <param name="fIcon">
        /// <para>
        /// Indicates whether an icon or a cursor is to be created.
        /// If this parameter is <see cref="TRUE"/>, an icon is to be created.
        /// If it is <see cref="FALSE"/>, a cursor is to be created.
        /// </para>
        /// <para>
        /// The <see cref="LOCALHEADER"/> structure defines cursor hotspot and is the first data read from the cursor resource bits.
        /// </para>
        /// </param>
        /// <param name="dwVer">
        /// The version number of the icon or cursor format for the resource bits pointed to by the <paramref name="presbits"/> parameter.
        /// The value must be greater than or equal to 0x00020000 and less than or equal to 0x00030000.
        /// This parameter is generally set to 0x00030000.
        /// </param>
        /// <param name="cxDesired">
        /// The width, in pixels, of the icon or cursor.
        /// If this parameter is zero and the <paramref name="Flags"/> parameter is <see cref="LR_DEFAULTSIZE"/>,
        /// the function uses the <see cref="SM_CXICON"/> or <see cref="SM_CXCURSOR"/> system metric value to set the width.
        /// If this parameter is zero and <see cref="LR_DEFAULTSIZE"/> is not used, the function uses the actual resource width.
        /// </param>
        /// <param name="cyDesired">
        /// The height, in pixels, of the icon or cursor.
        /// If this parameter is zero and the <paramref name="Flags"/> parameter is <see cref="LR_DEFAULTSIZE"/>,
        /// the function uses the <see cref="SM_CYICON"/> or <see cref="SM_CYCURSOR"/> system metric value to set the height.
        /// If this parameter is zero and <see cref="LR_DEFAULTSIZE"/> is not used, the function uses the actual resource height.
        /// </param>
        /// <param name="Flags">
        /// <para>
        /// A combination of the following values.
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
        /// <see cref="LR_DEFAULTCOLOR"/>
        /// </para>
        /// <para>
        /// 0x00000000
        /// </para>
        /// </term>
        /// <term>
        /// Uses the default color format.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="LR_DEFAULTSIZE"/>
        /// </para>
        /// <para>
        /// 0x00000040
        /// </para>
        /// </term>
        /// <term>
        /// Uses the width or height specified by the system metric values for cursors or icons,
        /// if the <paramref name="cxDesired"/> or <paramref name="cyDesired"/> values are set to zero.
        /// If this flag is not specified and <paramref name="cxDesired"/> and <paramref name="cyDesired"/> are set to zero,
        /// the function uses the actual resource size.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="LR_MONOCHROME"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// Creates a monochrome icon or cursor.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="LR_SHARED"/>
        /// </para>
        /// <para>
        /// 0x00008000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Shares the icon or cursor handle if the icon or cursor is created multiple times.
        /// If <see cref="LR_SHARED"/> is not set, a second call to <see cref="CreateIconFromResourceEx"/>
        /// for the same resource will create the icon or cursor again and return a different handle.
        /// </para>
        /// <para>
        /// When you use this flag, the system will destroy the resource when it is no longer needed.
        /// </para>
        /// <para>
        /// Do not use <see cref="LR_SHARED"/> for icons or cursors that have non-standard sizes,
        /// that may change after loading, or that are loaded from a file.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the icon or cursor.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="CreateIconFromResource"/>, <see cref="CreateIconFromResourceEx"/>, <see cref="CreateIconIndirect"/>,
        /// <see cref="GetIconInfo"/>, and <see cref="LookupIconIdFromDirectoryEx"/> functions
        /// allow shell applications and icon browsers to examine and use resources throughout the system.
        /// </para>
        /// <para>
        /// You should call <see cref="DestroyIcon"/> for icons or <see cref="DestroyCursor"/> for cursors created with <see cref="CreateIconFromResourceEx"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateIconFromResourceEx", ExactSpelling = true, SetLastError = true)]
        public static extern HICON CreateIconFromResourceEx(
#if NETFRAMEWORK
            [In] nint presbits,
#else
            [In] P<BYTE> presbits,
#endif
            [In] DWORD dwResSize, [In] BOOL fIcon, [In] DWORD dwVer,
            [In] int cxDesired, [In] int cyDesired, [In] LoadResourceFlags Flags);

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
        /// <para>
        /// If the function succeeds, the return value is a handle to the icon or cursor that is created.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The system copies the bitmaps in the <see cref="ICONINFO"/> structure before creating the icon or cursor.
        /// Because the system may temporarily select the bitmaps in a device context,
        /// the <see cref="ICONINFO.hbmMask"/> and <see cref="ICONINFO.hbmColor"/> members of the <see cref="ICONINFO"/> structure
        /// should not already be selected into a device context.
        /// The application must continue to manage the original bitmaps and delete them when they are no longer necessary.
        /// </para>
        /// <para>
        /// When you are finished using the icon, destroy it using the <see cref="DestroyIcon"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
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
        /// A handle to the icon to be destroyed.
        /// The icon must not be in use.
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
        /// It is only necessary to call <see cref="DestroyIcon"/> for icons and cursors created with the following functions:
        /// <see cref="CreateIconFromResourceEx"/> (if called without the <see cref="LR_SHARED"/> flag),
        /// <see cref="CreateIconIndirect"/>, and <see cref="CopyIcon"/>.
        /// Do not use this function to destroy a shared icon.
        /// A shared icon is valid as long as the module from which it was loaded remains in memory.
        /// The following functions obtain a shared icon.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="LoadIcon"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LoadImage"/> (if you use the <see cref="LR_SHARED"/> flag)
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CopyImage"/> (if you use the <see cref="LR_COPYRETURNORG"/> flag and the <c>hImage</c> parameter is a shared icon)
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CreateIconFromResource"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CreateIconFromResourceEx"/> (if you use the <see cref="LR_SHARED"/> flag)
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DestroyIcon", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DestroyIcon([In] HICON hIcon);

        /// <summary>
        /// <para>
        /// Draws an icon or cursor into the specified device context.
        /// </para>
        /// <para>
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
        /// <see cref="DrawIcon"/> places the icon's upper-left corner at the location specified by the <paramref name="X"/> and <paramref name="Y"/> parameters.
        /// The location is subject to the current mapping mode of the device context.
        /// </para>
        /// <para>
        /// <see cref="DrawIcon"/> draws the icon or cursor using the width and height specified by the system metric values for icons;
        /// for more information, see <see cref="GetSystemMetrics"/>.
        /// </para>
        /// <para>
        /// The <see cref="DrawIcon"/> function calls <see cref="DrawIconEx"/> passing <c>DI_NORMAL|DI_DEFAULTSIZE</c> as flags.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
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
        /// A handle to the icon or cursor to be drawn.
        /// This parameter can identify an animated cursor.
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
        /// The index of the frame to draw, if <paramref name="hIcon"/> identifies an animated cursor.
        /// This parameter is ignored if <paramref name="hIcon"/> does not identify an animated cursor.
        /// </param>
        /// <param name="hbrFlickerFreeDraw">
        /// A handle to a brush that the system uses for flicker-free drawing.
        /// If <paramref name="hbrFlickerFreeDraw"/> is a valid brush handle,
        /// the system creates an offscreen bitmap using the specified brush for the background color,
        /// draws the icon or cursor into the bitmap, and then copies the bitmap into the device context identified by <paramref name="hdc"/>.
        /// If <paramref name="hbrFlickerFreeDraw"/> is <see cref="NULL"/>, the system draws the icon or cursor directly into the device context.
        /// </param>
        /// <param name="diFlags">
        /// <para>
        /// The drawing flags. This parameter can be one of the following values.
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
        /// <see cref="DI_COMPAT"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// This flag is ignored.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DI_DEFAULTSIZE"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// Draws the icon or cursor using the width and height specified by the system metric values for icons,
        /// if the <paramref name="cxWidth"/> and <paramref name="cyWidth"/> parameters are set to zero.
        /// If this flag is not specified and <paramref name="cxWidth"/> and <paramref name="cyWidth"/> are set to zero,
        /// the function uses the actual resource size.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DI_IMAGE"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// Draws the icon or cursor using the image. See Remarks.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DI_MASK"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// Draws the icon or cursor using the mask. See Remarks.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DI_NOMIRROR"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// Draws the icon as an unmirrored icon.
        /// By default, the icon is drawn as a mirrored icon if <paramref name="hdc"/> is mirrored.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DI_NORMAL"/>
        /// </para>
        /// <para>
        /// 0x0003
        /// </para>
        /// </term>
        /// <term>
        /// Combination of <see cref="DI_IMAGE"/> and <see cref="DI_MASK"/>. See Remarks.
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
        /// <para>
        /// The <see cref="DrawIconEx"/> function places the icon's upper-left corner at the location
        /// specified by the <paramref name="xLeft"/> and <paramref name="yTop"/> parameters.
        /// The location is subject to the current mapping mode of the device context.
        /// </para>
        /// <para>
        /// If only one of the <see cref="DI_IMAGE"/> and <see cref="DI_MASK"/> flags is set,
        /// then the corresponding bitmap is drawn with the <see cref="SRCCOPY"/> raster operation code.
        /// </para>
        /// <para>
        /// If both the <see cref="DI_IMAGE"/> and <see cref="DI_MASK"/> flags are set:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// If the icon or cursor is a 32-bit alpha-blended icon or cursor,
        /// then the image is drawn with <see cref="AC_SRC_OVER"/> blend function and the mask is ignored.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// For all other icons or cursors, the mask is drawn with the <see cref="SRCAND"/> raster operation code,
        /// and the image is drawn with the <see cref="SRCINVERT"/> raster operation code
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// To duplicate <c>DrawIcon (hDC, X, Y, hIcon)</c>, call <see cref="DrawIconEx"/> as follows:
        /// </para>
        /// <code>
        /// DrawIconEx (hDC, X, Y, hIcon, 0, 0, 0, NULL, DI_NORMAL | DI_COMPAT | DI_DEFAULTSIZE);
        /// </code>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DrawIconEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DrawIconEx([In] HDC hdc, [In] int xLeft, [In] int yTop, [In] HICON hIcon, [In] int cxWidth, [In] int cyWidth,
            [In] UINT istepIfAniCur, [In] HBRUSH hbrFlickerFreeDraw, [In] DrawIconFlags diFlags);

        /// <summary>
        /// <para>
        /// Retrieves information about the specified icon or cursor.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-geticoninfo"/>
        /// </para>
        /// </summary>
        /// <param name="hIcon">
        /// <para>
        /// A handle to the icon or cursor.
        /// </para>
        /// <para>
        /// To retrieve information about a standard icon or cursor,
        /// specify the identifier beginning with the <c>IDI_</c> prefix or the identifier beginning with the <c>IDC_</c> prefix in this parameter.
        /// </para>
        /// </param>
        /// <param name="piconinfo">
        /// A pointer to an <see cref="ICONINFO"/> structure.
        /// The function fills in the structure's members.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero
        /// and the function fills in the members of the specified <see cref="ICONINFO"/> structure.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="GetIconInfo"/> creates bitmaps for the <see cref="ICONINFO.hbmMask"/> and <see cref="ICONINFO.hbmColor"/> or members of <see cref="ICONINFO"/>.
        /// The calling application must manage these bitmaps and delete them with <see cref="DeleteObject"/> call when they are no longer necessary.
        /// </para>
        /// <para>
        /// DPI Virtualization
        /// </para>
        /// <para>
        /// This API does not participate in DPI virtualization.
        /// The output returned is not affected by the DPI of the calling thread.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
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
        /// specify the identifier beginning with the <c>IDI_</c> prefix or the identifier beginning with the <c>IDC_</c> prefix in this parameter.
        /// </param>
        /// <param name="piconinfo">
        /// When this method returns, contains a pointer to an <see cref="ICONINFOEX"/> structure.
        /// The function fills in the structure's members.
        /// </param>
        /// <returns>
        /// <see cref="TRUE"/> indicates success, <see cref="FALSE"/> indicates failure.
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="GetIconInfoEx"/> creates bitmaps for the <see cref="ICONINFOEX.hbmMask"/> and <see cref="ICONINFOEX.hbmColor"/> or members of <see cref="ICONINFOEX"/>.
        /// The calling application must manage these bitmaps and delete them with <see cref="DeleteObject"/> call when they are no longer necessary.
        /// </para>
        /// <para>
        /// DPI Virtualization
        /// </para>
        /// <para>
        /// This API does not participate in DPI virtualization.
        /// The output returned is not affected by the DPI of the calling thread.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetIconInfoExW", ExactSpelling = true)]
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
        /// <para>
        /// A handle to the module of either a DLL or executable (.exe) file that contains the icon to be loaded.
        /// For more information, see <see cref="GetModuleHandle"/>.
        /// </para>
        /// <para>
        /// To load a predefined system icon, set this parameter to <see cref="NULL"/>.
        /// </para>
        /// </param>
        /// <param name="lpIconName">
        /// <para>
        /// If <paramref name="hInstance"/> is non-<see cref="NULL"/>,
        /// <paramref name="lpIconName"/> specifies the icon resource either by name or ordinal.
        /// This ordinal must be packaged by using the <see cref="MAKEINTRESOURCE"/> macro.
        /// </para>
        /// <para>
        /// If <paramref name="hInstance"/> is <see cref="NULL"/>,
        /// <paramref name="lpIconName"/> specifies the identifier (beginning with the <c>IDI_</c> prefix) of a predefined system icon to load.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the newly loaded icon.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="LoadIcon"/> loads the icon resource only if it has not been loaded; otherwise, it retrieves a handle to the existing resource.
        /// The function searches the icon resource for the icon most appropriate for the current display.
        /// The icon resource can be a color or monochrome bitmap.
        /// </para>
        /// <para>
        /// <see cref="LoadIcon"/> can only load an icon whose size conforms to the <see cref="SM_CXICON"/> and <see cref="SM_CYICON"/> system metric values.
        /// Use the <see cref="LoadImage"/> function to load icons of other sizes.
        /// </para>
        /// </remarks>
        [Obsolete("This function has been superseded by the LoadImage function (with LR_DEFAULTSIZE and LR_SHARED flags set).")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadIconW", ExactSpelling = true, SetLastError = true)]
        public static extern HICON LoadIcon([In] HINSTANCE hInstance, [In] LPCWSTR lpIconName);

        /// <summary>
        /// <para>
        /// Searches through icon (<see cref="RT_GROUP_ICON"/>) or cursor (<see cref="RT_GROUP_CURSOR"/>) resource data for the icon or cursor that best fits the current display device.
        /// </para>
        /// <para>
        /// To specify a desired height or width, use the <see cref="LookupIconIdFromDirectoryEx"/> function.
        /// This function calls it by passing zero in the <c>cxDesired</c>/<c>cyDesired</c> parameters.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-lookupiconidfromdirectory"/>
        /// </para>
        /// </summary>
        /// <param name="presbits">
        /// The icon or cursor directory data.
        /// Because this function does not validate the resource data,
        /// it causes a general protection (GP) fault or returns an undefined value if <paramref name="presbits"/> is not pointing to valid resource data.
        /// </param>
        /// <param name="fIcon">
        /// Indicates whether an icon or a cursor is sought.
        /// If this parameter is <see cref="TRUE"/>, the function is searching for an icon;
        /// if the parameter is <see cref="FALSE"/>, the function is searching for a cursor.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is an integer resource identifier
        /// for the icon (<see cref="RT_ICON"/>) or cursor (<see cref="RT_CURSOR"/>) that best fits the current display device.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// A resource file of type <see cref="RT_GROUP_ICON"/> (<see cref="RT_GROUP_CURSOR"/> indicates cursors)
        /// contains icon (or cursor) data in several device-dependent and device-independent formats.
        /// <see cref="LookupIconIdFromDirectory"/> searches the resource file for the icon (or cursor)
        /// that best fits the current display device and returns its integer identifier.
        /// The <see cref="FindResource"/> and <see cref="FindResourceEx"/> functions
        /// use the <see cref="MAKEINTRESOURCE"/> macro with this identifier to locate the resource in the module.
        /// </para>
        /// <para>
        /// The icon directory is loaded from a resource file with resource type <see cref="RT_GROUP_ICON"/> (or <see cref="RT_GROUP_CURSOR"/> for cursors),
        /// and an integer resource name for the specific icon to be loaded.
        /// <see cref="LookupIconIdFromDirectory"/> returns an integer identifier that is the resource name of the icon that best fits the current display device.
        /// </para>
        /// <para>
        /// The <see cref="LoadIcon"/>, <see cref="LoadCursor"/>, and <see cref="LoadImage"/> functions use this function
        /// to search the specified resource data for the icon or cursor that best fits the current display device.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LookupIconIdFromDirectory", ExactSpelling = true, SetLastError = true)]
        public static extern int LookupIconIdFromDirectory(
#if NETFRAMEWORK
            [In] nint presbits,
#else
            [In] P<BYTE> presbits,
#endif
            [In] BOOL fIcon);

        /// <summary>
        /// <para>
        /// Searches through icon (<see cref="RT_GROUP_ICON"/>) or cursor (<see cref="RT_GROUP_CURSOR"/>) resource data
        /// for the icon or cursor that best fits the current display device.
        /// </para>
        /// <para>
        /// If more than one image exists in resource group, this method uses the following criteria to choose an image:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The image closest but not exceed the requested size is selected.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If two or more images of that size are present, the one that matches the color depth of the display is chosen.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If no images exactly match the color depth of the display,
        /// the image with the greatest color depth that does not exceed the color depth of the display is chosen.
        /// If all exceed the color depth, the one with the lowest color depth is chosen.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-lookupiconidfromdirectoryex"/>
        /// </para>
        /// </summary>
        /// <param name="presbits">
        /// The icon or cursor directory data.
        /// Because this function does not validate the resource data, it causes a general protection (GP) fault
        /// or returns an undefined value if <paramref name="presbits"/> is not pointing to valid resource data.
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
        /// <para>
        /// A combination of the following values.
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
        /// <see cref="LR_DEFAULTCOLOR"/>
        /// </para>
        /// <para>
        /// 0x00000000
        /// </para>
        /// </term>
        /// <term>
        /// Uses the default color format.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="LR_MONOCHROME"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// Creates a monochrome icon or cursor.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is an integer resource identifier
        /// for the icon (<see cref="RT_ICON"/>) or cursor (<see cref="RT_CURSOR"/>) that best fits the current display device.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// A resource file of type <see cref="RT_GROUP_ICON"/> (<see cref="RT_GROUP_CURSOR"/> indicates cursors)
        /// contains icon (or cursor) data in several device-dependent and device-independent formats.
        /// <see cref="LookupIconIdFromDirectoryEx"/> searches the resource file for the icon (or cursor)
        /// that best fits the current display device and returns its integer identifier.
        /// The <see cref="FindResource"/> and <see cref="FindResourceEx"/> functions
        /// use the <see cref="MAKEINTRESOURCE"/> macro with this identifier to locate the resource in the module.
        /// </para>
        /// <para>
        /// The icon directory is loaded from a resource file with resource type <see cref="RT_GROUP_ICON"/> (or <see cref="RT_GROUP_CURSOR"/> for cursors),
        /// and an integer resource name for the specific icon (<see cref="RT_ICON"/>) or cursor (<see cref="RT_CURSOR"/>) to be loaded.
        /// <see cref="LoadResource"/> and <see cref="CreateIconFromResourceEx"/> functions may be used to create a corresponding icon or cursor.
        /// </para>
        /// <para>
        /// The <see cref="LoadIcon"/>, <see cref="LoadImage"/>, and <see cref="LoadCursor"/> functions use this function
        /// to search the specified resource data for the icon or cursor that best fits the current display device.
        /// <see cref="LoadIconWithScaleDown"/> uses alternative search criteria for a best fit.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LookupIconIdFromDirectoryEx", ExactSpelling = true, SetLastError = true)]
        public static extern int LookupIconIdFromDirectoryEx(
#if NETFRAMEWORK
            [In] nint presbits,
#else
            [In] P<BYTE> presbits,
#endif
            [In] BOOL fIcon, [In] int cxDesired,
            [In] int cyDesired, [In] LoadResourceFlags Flags);

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
        /// These flags are the <c>LR_*</c> flags used by the <see cref="LoadImage"/> function.
        /// </param>
        /// <returns>
        /// <para>
        /// If the <paramref name="phicon"/> parameter is <see langword="null"/> and this function succeeds,
        /// then the return value is the number of icons in the file.
        /// If the function fails then the return value is 0.
        /// </para>
        /// <para>
        /// If the <paramref name="phicon"/> parameter is not <see langword="null"/> and the function succeeds,
        /// then the return value is the number of icons extracted.
        /// Otherwise, the return value is 0xFFFFFFFF if the file is not found.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function extracts from executable (.exe), DLL (.dll), icon (.ico), cursor (.cur), animated cursor (.ani), and bitmap (.bmp) files.
        /// Extractions from Windows 3.x 16-bit executables (.exe or .dll) are also supported.
        /// </para>
        /// <para>
        /// The <paramref name="cxIcon"/> and <paramref name="cyIcon"/> parameters specify the size of the icons to extract.
        /// Two sizes can be extracted by putting the first size in the <see cref="LOWORD"/> of the parameter and the second size in the <see cref="HIWORD"/>.
        /// For example, <c>MAKELONG(24, 48)</c> for both the <paramref name="cxIcon"/> and <paramref name="cyIcon"/> parameters would extract both 24 and 48 size icons.
        /// </para>
        /// <para>
        /// You must destroy all icons extracted by <see cref="PrivateExtractIcons"/> by calling the <see cref="DestroyIcon"/> function.
        /// </para>
        /// <para>
        /// This function was not included in the SDK headers and libraries until Windows XP Service Pack 1 (SP1) and Windows Server 2003.
        /// If you do not have a header file and import library for this function,
        /// you can call the function using <see cref="LoadLibrary"/> and <see cref="GetProcAddress"/>.
        /// </para>
        /// </remarks>
        [Obsolete("This function is not intended for general use. It may be altered or unavailable in subsequent versions of Windows.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "PrivateExtractIconsW", ExactSpelling = true, SetLastError = true)]
        public static extern UINT PrivateExtractIcons([In] LPCWSTR szFileName, [In] int nIconIndex, [In] int cxIcon, [In] int cyIcon,
            [Out] HICON[] phicon, [Out] out UINT piconid, [In] UINT nIcons, [In] LoadResourceFlags flags);
    }
}
