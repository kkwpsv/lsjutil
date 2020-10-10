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
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.SystemIcons;
using static Lsj.Util.Win32.Enums.SystemMetric;
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
        public static extern BOOL ClipCursor([In] in RECT lpRect);

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
        public static extern HICON CopyIcon([In] HICON hIcon);

        /// <summary>
        /// <para>
        /// Creates a new image (icon, cursor, or bitmap) and copies the attributes of the specified image to the new one.
        /// If necessary, the function stretches the bits to fit the desired size of the new image.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-copyimage
        /// </para>
        /// </summary>
        /// <param name="h">
        /// A handle to the image to be copied.
        /// </param>
        /// <param name="type">
        /// The type of image to be copied. This parameter can be one of the following values.
        /// <see cref="IMAGE_BITMAP"/>: Copies a bitmap.
        /// <see cref="IMAGE_CURSOR"/>: Copies a cursor.
        /// <see cref="IMAGE_ICON"/>: Copies an icon.
        /// </param>
        /// <param name="cx">
        /// The desired width, in pixels, of the image.
        /// If this is zero, then the returned image will have the same width as the original <paramref name="h"/>.
        /// </param>
        /// <param name="cy">
        /// The desired height, in pixels, of the image.
        /// If this is zero, then the returned image will have the same height as the original <paramref name="h"/>.
        /// </param>
        /// <param name="flags">
        /// This parameter can be one or more of the following values.
        /// <see cref="LR_COPYDELETEORG"/>: Deletes the original image after creating the copy.
        /// <see cref="LR_COPYFROMRESOURCE"/>:
        /// Tries to reload an icon or cursor resource from the original resource file rather than simply copying the current image.
        /// This is useful for creating a different-sized copy when the resource file contains multiple sizes of the resource.
        /// Without this flag, <see cref="CopyImage"/> stretches the original image to the new size.
        /// If this flag is set, <see cref="CopyImage"/> uses the size in the resource file closest to the desired size.
        /// This will succeed only if <paramref name="h"/> was loaded by <see cref="LoadIcon"/> or <see cref="LoadCursor"/>,
        /// or by <see cref="LoadImage"/> with the <see cref="LR_SHARED"/> flag.
        /// <see cref="LR_COPYRETURNORG"/>:
        /// Returns the original hImage if it satisfies the criteria for the copy—that is,
        /// correct dimensions and color depth—in which case the <see cref="LR_COPYDELETEORG"/> flag is ignored.
        /// If this flag is not specified, a new object is always created.
        /// <see cref="LR_CREATEDIBSECTION"/>:
        /// If this is set and a new bitmap is created, the bitmap is created as a DIB section.
        /// Otherwise, the bitmap image is created as a device-dependent bitmap.
        /// This flag is only valid if <paramref name="type"/> is <see cref="IMAGE_BITMAP"/>.
        /// <see cref="LR_DEFAULTSIZE"/>:
        /// Uses the width or height specified by the system metric values for cursors or icons,
        /// if the <paramref name="cx"/> or <paramref name="cy"/> values are set to zero.
        /// If this flag is not specified and <paramref name="cx"/> and <paramref name="cy"/> are set to zero,
        /// the function uses the actual resource size.
        /// If the resource contains multiple images, the function uses the size of the first image.
        /// <see cref="LR_MONOCHROME"/>: Creates a new monochrome image.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the newly created image.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// When you are finished using the resource, you can release its associated memory by calling one of the functions in the following table.
        /// Bitmap: <see cref="DeleteObject"/>
        /// Cursor: <see cref="DestroyCursor"/>
        /// Icon: <see cref="DestroyIcon"/>
        /// The system automatically deletes the resource when its process terminates, however,
        /// calling the appropriate function saves memory and decreases the size of the process's working set.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CopyImage", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE CopyImage([In] HANDLE h, [In] ImageTypes type, [In] int cx, [In] int cy, [In] LoadImageFlags flags);

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
        public static extern HCURSOR CreateCursor([In] HINSTANCE hInst, [In] int xHotSpot, [In] int yHotSpot, [In] int nWidth, [In] int nHeight,
            [In] IntPtr pvANDPlane, [In] IntPtr pvXORPlane);

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
        public static extern HICON CreateIcon([In] HINSTANCE hInstance, [In] int nWidth, [In] int nHeight, [In] BYTE cPlanes, [In] BYTE cBitsPixel,
            [In] IntPtr lpbANDbits, [In] IntPtr lpbXORbits);

        /// <summary>
        /// <para>
        /// Creates an icon or cursor from resource bits describing the icon.
        /// To specify a desired height or width, use the <see cref="CreateIconFromResourceEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-createiconfromresource
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
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-createiconfromresourceex
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
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-createiconindirect
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
        public static extern BOOL DestroyCursor([In] HCURSOR hCursor);

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
        public static extern BOOL DestroyIcon([In] HICON hIcon);

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
        public static extern BOOL DrawIcon([In] HDC hDC, [In] int X, [In] int Y, [In] HICON hIcon);

        /// <summary>
        /// <para>
        /// Draws an icon or cursor into the specified device context, performing the specified raster operations,
        /// and stretching or compressing the icon or cursor as specified.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-drawiconex
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
        public static extern BOOL GetClipCursor([Out] out RECT lpRect);

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
        /// Retrieves information about the global cursor.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getcursorinfo
        /// </para>
        /// </summary>
        /// <param name="pci">
        /// A pointer to a <see cref="CURSORINFO"/> structure that receives the information.
        /// Note that you must set the <see cref="CURSORINFO.cbSize"/> member to <code>sizeof(CURSORINFO)</code> before calling this function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCursorInfo", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetCursorInfo([In][Out] ref CURSORINFO pci);

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
        /// If it is not, call <see cref="SetThreadDesktop"/> with the <see cref="HDESK"/>
        /// returned by <see cref="OpenInputDesktop"/> to switch to that desktop.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCursorPos", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetCursorPos([Out] out POINT lpPoint);

        /// <summary>
        /// <para>
        /// Retrieves information about the specified icon or cursor.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-geticoninfo
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
        public static extern HCURSOR LoadCursor([In] HINSTANCE hInstance, [MarshalAs(UnmanagedType.LPWStr)][In] string lpCursorName);

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
        public static extern HCURSOR LoadCursor([In] HINSTANCE hInstance, [In] SystemCursors lpCursorName);

        /// <summary>
        /// <para>
        /// Creates a cursor based on data contained in a file.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-loadcursorfromfilew
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// The source of the file data to be used to create the cursor.
        /// The data in the file must be in either .CUR or .ANI format.
        /// If the high-order word of <paramref name="lpFileName"/> is nonzero,
        /// it is a pointer to a string that is a fully qualified name of a file containing cursor data.
        /// </param>
        /// <returns>
        /// If the function is successful, the return value is a handle to the new cursor.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// <see cref="GetLastError"/> may return the following value.
        /// <see cref="ERROR_FILE_NOT_FOUND"/>: The specified file cannot be found. 
        /// </returns>
        /// <remarks>
        /// DPI Virtualization
        /// This API does not participate in DPI virtualization. The output returned is not affected by the DPI of the calling thread.
        /// Note
        /// The winuser.h header defines <see cref="LoadCursorFromFile"/> as an alias which automatically
        /// selects the ANSI or Unicode version of this function based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead to mismatches
        /// that result in compilation or runtime errors.
        /// For more information, see Conventions for Function Prototypes.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadCursorFromFileW", ExactSpelling = true, SetLastError = true)]
        public static extern HCURSOR LoadCursorFromFile([In] StringHandle lpFileName);

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
        public static extern HICON LoadIcon([In] HINSTANCE hInstance, [MarshalAs(UnmanagedType.LPWStr)][In] string lpIconName);

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
        public static extern HICON LoadIcon([In] HINSTANCE hInstance, [In] SystemIcons lpIconName);

        /// <summary>
        /// <para>
        /// Loads an icon, cursor, animated cursor, or bitmap.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-loadimagew
        /// </para>
        /// </summary>
        /// <param name="hInst">
        /// A handle to the module of either a DLL or executable (.exe) that contains the image to be loaded.
        /// For more information, see <see cref="GetModuleHandle"/>.
        /// Note that as of 32-bit Windows, an instance handle (<see cref="HINSTANCE"/>),
        /// such as the application instance handle exposed by system function call of WinMain,
        /// and a module handle (<see cref="HMODULE"/>) are the same thing.
        /// To load an OEM image, set this parameter to <see cref="NULL"/>.
        /// To load a stand-alone resource (icon, cursor, or bitmap file)—for example, c:\myimage.bmp—set this parameter to <see cref="NULL"/>.
        /// </param>
        /// <param name="name">
        /// The image to be loaded.
        /// If the hinst parameter is non-<see cref="NULL"/> and the <paramref name="fuLoad"/> parameter omits <see cref="LR_LOADFROMFILE"/>,
        /// <paramref name="name"/> specifies the image resource in the <paramref name="hInst"/> module.
        /// If the image resource is to be loaded by name from the module,
        /// the <paramref name="name"/> parameter is a pointer to a null-terminated string that contains the name of the image resource.
        /// If the image resource is to be loaded by ordinal from the module,
        /// use the <see cref="MAKEINTRESOURCE"/> macro to convert the image ordinal into a form that can be passed to the <see cref="LoadImage"/> function.
        /// For more information, see the Remarks section below.
        /// If the <paramref name="hInst"/> parameter is <see cref="NULL"/>
        /// and the <paramref name="fuLoad"/> parameter omits the <see cref="LR_LOADFROMFILE"/> value,
        /// the <paramref name="name"/> specifies the OEM image to load.
        /// The OEM image identifiers are defined in Winuser.h and have the following prefixes.
        /// OBM_: OEM bitmaps
        /// OIC_: OEM icons
        /// OCR: OEM cursors
        /// To pass these constants to the <see cref="LoadImage"/> function, use the <see cref="MAKEINTRESOURCE"/> macro.
        /// For example, to load the OCR_NORMAL cursor, pass <code>MAKEINTRESOURCE(OCR_NORMAL)</code>
        /// as the <paramref name="name"/> parameter, <see cref="NULL"/> as the <paramref name="hInst"/> parameter,
        /// and <see cref="LR_SHARED"/> as one of the flags to the <paramref name="fuLoad"/> parameter.
        /// If the <paramref name="fuLoad"/> parameter includes the <see cref="LR_LOADFROMFILE"/> value,
        /// <paramref name="name"/> is the name of the file that contains the stand-alone resource (icon, cursor, or bitmap file).
        /// Therefore, set <paramref name="hInst"/> to <see cref="NULL"/>.
        /// </param>
        /// <param name="type">
        /// The type of image to be loaded. This parameter can be one of the following values.
        /// <see cref="IMAGE_BITMAP"/>: Loads a bitmap.
        /// <see cref="IMAGE_CURSOR"/>: Loads a cursor.
        /// <see cref="IMAGE_ICON"/>: Loads an icon.
        /// </param>
        /// <param name="cx">
        /// The width, in pixels, of the icon or cursor.
        /// If this parameter is zero and the <paramref name="fuLoad"/> parameter is <see cref="LR_DEFAULTSIZE"/>,
        /// the function uses the <see cref="SM_CXICON"/> or <see cref="SM_CXCURSOR"/> system metric value to set the width.
        /// If this parameter is zero and <see cref="LR_DEFAULTSIZE"/> is not used, the function uses the actual resource width.
        /// </param>
        /// <param name="cy">
        /// The height, in pixels, of the icon or cursor.
        /// If this parameter is zero and the <paramref name="fuLoad"/> parameter is <see cref="LR_DEFAULTSIZE"/>,
        /// the function uses the <see cref="SM_CYICON"/> or <see cref="SM_CYCURSOR"/> system metric value to set the height.
        /// If this parameter is zero and <see cref="LR_DEFAULTSIZE"/> is not used, the function uses the actual resource height.
        /// </param>
        /// <param name="fuLoad">
        /// This parameter can be one or more of the following values.
        /// <see cref="LR_CREATEDIBSECTION"/>:
        /// When the <paramref name="type"/> parameter specifies <see cref="IMAGE_BITMAP"/>,
        /// causes the function to return a DIB section bitmap rather than a compatible bitmap.
        /// This flag is useful for loading a bitmap without mapping it to the colors of the display device.
        /// <see cref="LR_DEFAULTCOLOR"/>:
        /// The default flag; it does nothing. All it means is "not <see cref="LR_MONOCHROME"/>".
        /// <see cref="LR_DEFAULTSIZE"/>:
        /// Uses the width or height specified by the system metric values for cursors or icons,
        /// if the <paramref name="cx"/> or <paramref name="cy"/> values are set to zero.
        /// If this flag is not specified and <paramref name="cx"/> and <paramref name="cy"/> are set to zero,
        /// the function uses the actual resource size.
        /// If the resource contains multiple images, the function uses the size of the first image.
        /// <see cref="LR_LOADFROMFILE"/>:
        /// Loads the stand-alone image from the file specified by <paramref name="name"/> (icon, cursor, or bitmap file).
        /// <see cref="LR_LOADMAP3DCOLORS"/>:
        /// Searches the color table for the image and replaces the following shades of gray with the corresponding 3-D color.
        /// Dk Gray, RGB(128,128,128) with <see cref="COLOR_3DSHADOW"/>
        /// Gray, RGB(192,192,192) with <see cref="COLOR_3DFACE"/>
        /// Lt Gray, RGB(223,223,223) with <see cref="COLOR_3DLIGHT"/>
        /// Do not use this option if you are loading a bitmap with a color depth greater than 8bpp.
        /// <see cref="LR_LOADTRANSPARENT"/>:
        /// Retrieves the color value of the first pixel in the image and replaces the corresponding entry in the color table
        /// with the default window color (<see cref="COLOR_WINDOW"/>).
        /// All pixels in the image that use that entry become the default window color.
        /// This value applies only to images that have corresponding color tables.
        /// Do not use this option if you are loading a bitmap with a color depth greater than 8bpp.
        /// If <paramref name="fuLoad"/> includes both the <see cref="LR_LOADTRANSPARENT"/> and <see cref="LR_LOADMAP3DCOLORS"/> values,
        /// <see cref="LR_LOADTRANSPARENT"/> takes precedence.
        /// However, the color table entry is replaced with <see cref="COLOR_3DFACE"/> rather than <see cref="COLOR_WINDOW"/>.
        /// <see cref="LR_MONOCHROME"/>:
        /// Loads the image in black and white.
        /// <see cref="LR_SHARED"/>:
        /// Shares the image handle if the image is loaded multiple times.
        /// If <see cref="LR_SHARED"/> is not set, a second call to <see cref="LoadImage"/> for the same resource
        /// will load the image again and return a different handle.
        /// When you use this flag, the system will destroy the resource when it is no longer needed.
        /// Do not use <see cref="LR_SHARED"/> for images that have non-standard sizes, that may change after loading, or that are loaded from a file.
        /// When loading a system icon or cursor, you must use <see cref="LR_SHARED"/> or the function will fail to load the resource.
        /// This function finds the first image in the cache with the requested resource name, regardless of the size requested.
        /// <see cref="LR_VGACOLOR"/>:
        /// Uses true VGA colors.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle of the newly loaded image.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If <code>IS_INTRESOURCE(lpszname)</code> is <see cref="TRUE"/>, then <paramref name="name"/> specifies the integer identifier
        /// of the given resource. Otherwise, it is a pointer to a null-terminated string.
        /// If the first character of the string is a pound sign (#), then the remaining characters represent a decimal number
        /// that specifies the integer identifier of the resource. For example, the string "#258" represents the identifier 258.
        /// When you are finished using a bitmap, cursor, or icon you loaded without specifying the <see cref="LR_SHARED"/> flag,
        /// you can release its associated memory by calling one of the functions in the following table.
        /// Bitmap: <see cref="DeleteObject"/>
        /// Cursor: <see cref="DestroyCursor"/>
        /// Icon: <see cref="DestroyIcon"/>
        /// The system automatically deletes these resources when the process that created them terminates;
        /// however, calling the appropriate function saves memory and decreases the size of the process's working set.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadImageW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE LoadImage([In] HINSTANCE hInst, [In] StringHandle name, [In] ImageTypes type,
            [In] int cx, [In] int cy, [In] LoadImageFlags fuLoad);

        /// <summary>
        /// <para>
        /// Searches through icon or cursor data for the icon or cursor that best fits the current display device.
        /// To specify a desired height or width, use the <see cref="LookupIconIdFromDirectoryEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-lookupiconidfromdirectory
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
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-lookupiconidfromdirectoryex
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
        public static extern HCURSOR SetCursor([In] HCURSOR hCursor);

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
        public static extern BOOL SetCursorPos([In] int X, [In] int Y);

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
        public static extern int ShowCursor([In] BOOL bShow);
    }
}
