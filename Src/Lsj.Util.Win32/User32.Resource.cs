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
        /// Creates a new image (icon, cursor, or bitmap) and copies the attributes of the specified image to the new one.
        /// If necessary, the function stretches the bits to fit the desired size of the new image.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-copyimage"/>
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
        /// Loads an icon, cursor, animated cursor, or bitmap.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-loadimagew"/>
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
    }
}
