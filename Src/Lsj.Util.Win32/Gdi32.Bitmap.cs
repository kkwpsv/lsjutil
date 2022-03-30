using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.COLORREF;
using static Lsj.Util.Win32.BaseTypes.HBITMAP;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.Compression;
using static Lsj.Util.Win32.Enums.CreateDIBitmapFlags;
using static Lsj.Util.Win32.Enums.DIBColorTableIdentifiers;
using static Lsj.Util.Win32.Enums.GDIEscapes;
using static Lsj.Util.Win32.Enums.ICMModes;
using static Lsj.Util.Win32.Enums.MemoryProtectionConstants;
using static Lsj.Util.Win32.Enums.RasterCapabilities;
using static Lsj.Util.Win32.Enums.RasterCodes;
using static Lsj.Util.Win32.Enums.RasterOps;
using static Lsj.Util.Win32.Enums.StretchBltModes;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Msimg32;

namespace Lsj.Util.Win32
{
    public partial class Gdi32
    {
        /// <summary>
        /// <para>
        /// The <see cref="BitBlt"/> function performs a bit-block transfer of the color data corresponding to a rectangle of pixels
        /// from the specified source device context into a destination device context.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-bitblt"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the destination device context.
        /// </param>
        /// <param name="x">
        /// The x-coordinate, in logical units, of the upper-left corner of the destination rectangle.
        /// </param>
        /// <param name="y">
        /// The y-coordinate, in logical units, of the upper-left corner of the destination rectangle.
        /// </param>
        /// <param name="cx">
        /// The width, in logical units, of the source and destination rectangles.
        /// </param>
        /// <param name="cy">
        /// The height, in logical units, of the source and the destination rectangles.
        /// </param>
        /// <param name="hdcSrc">
        /// A handle to the source device context.
        /// </param>
        /// <param name="x1">
        /// The x-coordinate, in logical units, of the upper-left corner of the source rectangle.
        /// </param>
        /// <param name="y1">
        /// The y-coordinate, in logical units, of the upper-left corner of the source rectangle.
        /// </param>
        /// <param name="rop">
        /// A raster-operation code.
        /// These codes define how the color data for the source rectangle is to be combined with the color data
        /// for the destination rectangle to achieve the final color.
        /// The following list shows some common raster operation codes.
        /// <see cref="BLACKNESS"/>:
        /// Fills the destination rectangle using the color associated with index 0 in the physical palette.
        /// (This color is black for the default physical palette.)
        /// <see cref="CAPTUREBLT"/>:
        /// Includes any windows that are layered on top of your window in the resulting image.
        /// By default, the image only contains your window.
        /// Note that this generally cannot be used for printing device contexts.
        /// <see cref="DSTINVERT"/>:
        /// Inverts the destination rectangle.
        /// <see cref="MERGECOPY"/>:
        /// Merges the colors of the source rectangle with the brush currently selected in <paramref name="hdc"/>, by using the Boolean AND operator.
        /// <see cref="MERGEPAINT"/>:
        /// Merges the colors of the inverted source rectangle with the colors of the destination rectangle by using the Boolean OR operator.
        /// <see cref="NOMIRRORBITMAP"/>:
        /// Prevents the bitmap from being mirrored.
        /// <see cref="NOTSRCCOPY"/>:
        /// Copies the inverted source rectangle to the destination.
        /// <see cref="NOTSRCERASE"/>:
        /// Combines the colors of the source and destination rectangles by using the Boolean OR operator and then inverts the resultant color.
        /// <see cref="PATCOPY"/>:
        /// Copies the brush currently selected in <paramref name="hdc"/>, into the destination bitmap.
        /// <see cref="PATINVERT"/>:
        /// Combines the colors of the brush currently selected in <paramref name="hdc"/>, with the colors of the destination rectangle
        /// by using the Boolean XOR operator.
        /// <see cref="PATPAINT"/>:
        /// Combines the colors of the brush currently selected in <paramref name="hdc"/>, with the colors of the inverted source rectangle
        /// by using the Boolean OR operator.
        /// The result of this operation is combined with the colors of the destination rectangle by using the Boolean OR operator.
        /// <see cref="SRCAND"/>:
        /// Combines the colors of the source and destination rectangles by using the Boolean AND operator.
        /// <see cref="SRCCOPY"/>:
        /// Copies the source rectangle directly to the destination rectangle.
        /// <see cref="SRCERASE"/>:
        ///  Combines the inverted colors of the destination rectangle with the colors of the source rectangle by using the Boolean AND operator.
        /// <see cref="SRCINVERT"/>:
        /// Combines the colors of the source and destination rectangles by using the Boolean XOR operator.
        /// <see cref="SRCPAINT"/>:
        /// Combines the colors of the source and destination rectangles by using the Boolean OR operator.
        /// <see cref="WHITENESS"/>:
        /// Fills the destination rectangle using the color associated with index 1 in the physical palette.
        /// (This color is white for the default physical palette.)
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// BitBlt only does clipping on the destination DC.
        /// If a rotation or shear transformation is in effect in the source device context, <see cref="BitBlt"/> returns an error.
        /// If other transformations exist in the source device context (and a matching transformation is not in effect in the destination device context),
        /// the rectangle in the destination device context is stretched, compressed, or rotated, as necessary.
        /// If the color formats of the source and destination device contexts do not match,
        /// the <see cref="BitBlt"/> function converts the source color format to match the destination format.
        /// When an enhanced metafile is being recorded, an error occurs if the source device context identifies an enhanced-metafile device context.
        /// Not all devices support the <see cref="BitBlt"/> function.
        /// For more information, see the <see cref="RC_BITBLT"/> raster capability entry in the <see cref="GetDeviceCaps"/> function
        /// as well as the following functions: <see cref="MaskBlt"/>, <see cref="PlgBlt"/>, and <see cref="StretchBlt"/>.
        /// <see cref="BitBlt"/> returns an error if the source and destination device contexts represent different devices.
        /// To transfer data between DCs for different devices, convert the memory bitmap to a DIB by calling <see cref="GetDIBits"/>.
        /// To display the DIB to the second device, call <see cref="SetDIBits"/> or <see cref="StretchDIBits"/>.
        /// ICM: No color management is performed when blits occur.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "BitBlt", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL BitBlt([In] HDC hdc, [In] int x, [In] int y, [In] int cx, [In] int cy, [In] HDC hdcSrc, [In] int x1, [In] int y1,
            [In] RasterCodes rop);

        /// <summary>
        /// <para>
        /// The <see cref="CreateBitmap"/> function creates a bitmap with the specified width, height, and color format (color planes and bits-per-pixel).
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createbitmap"/>
        /// </para>
        /// </summary>
        /// <param name="nWidth">
        /// The bitmap width, in pixels.
        /// </param>
        /// <param name="nHeight">
        /// The bitmap height, in pixels.
        /// </param>
        /// <param name="nPlanes">
        /// The number of color planes used by the device.
        /// </param>
        /// <param name="nBitCount">
        /// The number of bits required to identify the color of a single pixel.
        /// </param>
        /// <param name="lpBits">
        /// A pointer to an array of color data used to set the colors in a rectangle of pixels.
        /// Each scan line in the rectangle must be word aligned (scan lines that are not word aligned must be padded with zeros).
        /// If this parameter is <see cref="NULL"/>, the contents of the new bitmap is undefined.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to a bitmap.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// This function can return the following value.
        /// <see cref="ERROR_INVALID_BITMAP"/>: The calculated size of the bitmap is less than zero.
        /// </returns>
        /// <remarks>
        /// The <see cref="CreateBitmap"/> function creates a device-dependent bitmap.
        /// After a bitmap is created, it can be selected into a device context by calling the <see cref="SelectObject"/> function.
        /// However, the bitmap can only be selected into a device context if the bitmap and the DC have the same format.
        /// The <see cref="CreateBitmap"/> function can be used to create color bitmaps.
        /// However, for performance reasons applications should use <see cref="CreateBitmap"/> to create monochrome bitmaps
        /// and <see cref="CreateCompatibleBitmap"/> to create color bitmaps.
        /// Whenever a color bitmap returned from <see cref="CreateBitmap"/> is selected into a device context,
        /// the system checks that the bitmap matches the format of the device context it is being selected into.
        /// Because <see cref="CreateCompatibleBitmap"/> takes a device context, it returns a bitmap that has the same format as the specified device context.
        /// Thus, subsequent calls to <see cref="SelectObject"/> are faster with a color bitmap from <see cref="CreateCompatibleBitmap"/>
        /// than with a color bitmap returned from <see cref="CreateBitmap"/>.
        /// If the bitmap is monochrome, zeros represent the foreground color and ones represent the background color for the destination device context.
        /// If an application sets the nWidth or nHeight parameters to zero, <see cref="CreateBitmap"/> returns the handle to a 1-by-1 pixel, monochrome bitmap.
        /// When you no longer need the bitmap, call the <see cref="DeleteObject"/> function to delete it.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateBitmap", ExactSpelling = true, SetLastError = true)]
        public static extern HBITMAP CreateBitmap([In] int nWidth, [In] int nHeight, [In] UINT nPlanes, [In] UINT nBitCount, [In] IntPtr lpBits);

        /// <summary>
        /// <para>
        /// The <see cref="CreateBitmapIndirect"/> function creates a bitmap with the specified width, height, and color format (color planes and bits-per-pixel).
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createbitmapindirect"/>
        /// </para>
        /// </summary>
        /// <param name="pbm">
        /// A pointer to a <see cref="BITMAP"/> structure that contains information about the bitmap.
        /// If an application sets the <see cref="BITMAP.bmWidth"/> or <see cref="BITMAP.bmHeight"/> members to zero,
        /// <see cref="CreateBitmapIndirect"/> returns the handle to a 1-by-1 pixel, monochrome bitmap.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the bitmap.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// This function can return the following values.
        /// <see cref="ERROR_INVALID_PARAMETER"/>: One or more of the input parameters is invalid.
        /// <see cref="ERROR_NOT_ENOUGH_MEMORY"/>: The bitmap is too big for memory to be allocated.
        /// </returns>
        /// <remarks>
        /// The <see cref="CreateBitmapIndirect"/> function creates a device-dependent bitmap.
        /// After a bitmap is created, it can be selected into a device context by calling the <see cref="SelectObject"/> function.
        /// However, the bitmap can only be selected into a device context if the bitmap and the DC have the same format.
        /// While the <see cref="CreateBitmapIndirect"/> function can be used to create color bitmaps,
        /// for performance reasons applications should use <see cref="CreateBitmapIndirect"/> to create monochrome bitmaps
        /// and <see cref="CreateCompatibleBitmap"/> to create color bitmaps.
        /// Whenever a color bitmap from <see cref="CreateBitmapIndirect"/> is selected into a device context,
        /// the system must ensure that the bitmap matches the format of the device context it is being selected into.
        /// Because <see cref="CreateCompatibleBitmap"/> takes a device context, it returns a bitmap that has the same format as the specified device context.
        /// Thus, subsequent calls to <see cref="SelectObject"/> are faster with a color bitmap
        /// from <see cref="CreateCompatibleBitmap"/> than with a color bitmap returned from <see cref="CreateBitmapIndirect"/>.
        /// If the bitmap is monochrome, zeros represent the foreground color and ones represent the background color for the destination device context.
        /// When you no longer need the bitmap, call the <see cref="DeleteObject"/> function to delete it.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateBitmapIndirect", ExactSpelling = true, SetLastError = true)]
        public static extern HBITMAP CreateBitmapIndirect([In] in BITMAP pbm);

        /// <summary>
        /// <para>
        /// The <see cref="CreateCompatibleBitmap"/> function creates a bitmap compatible with the device that is associated with the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createcompatiblebitmap"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">A handle to a device context.</param>
        /// <param name="nWidth">The bitmap width, in pixels.</param>
        /// <param name="nHeight">The bitmap height, in pixels.</param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the compatible bitmap (DDB).
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateCompatibleBitmap", ExactSpelling = true, SetLastError = true)]
        public static extern HBITMAP CreateCompatibleBitmap([In] HDC hdc, [In] int nWidth, [In] int nHeight);

        /// <summary>
        /// <para>
        /// The <see cref="CreateDiscardableBitmap"/> function creates a discardable bitmap that is compatible with the specified device.
        /// The bitmap has the same bits-per-pixel format and the same color palette as the device.
        /// An application can select this bitmap as the current bitmap for a memory device that is compatible with the specified device.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-creatediscardablebitmap"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to a device context.
        /// </param>
        /// <param name="cx">
        /// The width, in pixels, of the bitmap.
        /// </param>
        /// <param name="cy">
        /// The height, in pixels, of the bitmap.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the compatible bitmap (DDB).
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// When you no longer need the bitmap, call the <see cref="DeleteObject"/> function to delete it.
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit versions of Windows." +
            "Applications should use the CreateCompatibleBitmap function.")]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDiscardableBitmap", ExactSpelling = true, SetLastError = true)]
        public static extern HBITMAP CreateDiscardableBitmap([In] HDC hdc, [In] int cx, [In] int cy);

        /// <summary>
        /// <para>
        /// The <see cref="CreateDIBitmap"/> function creates a compatible bitmap (DDB) from a DIB and, optionally, sets the bitmap bits.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createdibitmap"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to a device context.
        /// </param>
        /// <param name="pbmih">
        /// A pointer to a bitmap information header structure, <see cref="BITMAPV5HEADER"/>.
        /// If <paramref name="flInit"/> is <see cref="CBM_INIT"/>, the function uses the bitmap information header structure
        /// to obtain the desired width and height of the bitmap as well as other information.
        /// Note that a positive value for the height indicates a bottom-up DIB while a negative value for the height indicates a top-down DIB.
        /// Calling <see cref="CreateDIBitmap"/> with <paramref name="flInit"/> as <see cref="CBM_INIT"/> is equivalent
        /// to calling the <see cref="CreateCompatibleBitmap"/> function to create a DDB in the format of the device and
        /// then calling the <see cref="SetDIBits"/> function to translate the DIB bits to the DDB.
        /// </param>
        /// <param name="flInit">
        /// Specifies how the system initializes the bitmap bits. The following value is defined.
        /// <see cref="CBM_INIT"/>:
        /// If this flag is set, the system uses the data pointed to by the <paramref name="pjBits"/> and <paramref name="pbmi"/> parameters
        /// to initialize the bitmap bits.
        /// If this flag is clear, the data pointed to by those parameters is not used.
        /// If <paramref name="flInit"/> is zero, the system does not initialize the bitmap bits.
        /// </param>
        /// <param name="pjBits">
        /// A pointer to an array of bytes containing the initial bitmap data.
        /// The format of the data depends on the <see cref="BITMAPINFOHEADER.biBitCount"/> member of the <see cref="BITMAPINFO"/> structure
        /// to which the <paramref name="pbmi"/> parameter points.
        /// </param>
        /// <param name="pbmi">
        /// A pointer to a <see cref="BITMAPINFO"/> structure that describes the dimensions and color format of the array
        /// pointed to by the <paramref name="pjBits"/> parameter.
        /// </param>
        /// <param name="iUsage">
        /// Specifies whether the <see cref="BITMAPINFO.bmiColors"/> member of the <see cref="BITMAPINFO"/> structure was initialized and,
        /// if so, whether <see cref="BITMAPINFO.bmiColors"/> contains explicit red, green, blue (RGB) values or palette indexes.
        /// The <paramref name="iUsage"/> parameter must be one of the following values.
        /// <see cref="DIB_PAL_COLORS"/>:
        /// A color table is provided and consists of an array of 16-bit indexes into the logical palette of the device context into
        /// which the bitmap is to be selected.
        /// <see cref="DIB_RGB_COLORS"/>:
        /// A color table is provided and contains literal RGB values.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the compatible bitmap.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// The DDB that is created will be whatever bit depth your reference DC is.
        /// To create a bitmap that is of different bit depth, use <see cref="CreateDIBSection"/>.
        /// For a device to reach optimal bitmap-drawing speed, specify fdwInit as <see cref="CBM_INIT"/>.
        /// Then, use the same color depth DIB as the video mode.
        /// When the video is running 4- or 8-bpp, use <see cref="DIB_PAL_COLORS"/>.
        /// The CBM_CREATDIB flag for the <paramref name="flInit"/> parameter is no longer supported.
        /// When you no longer need the bitmap, call the <see cref="DeleteObject"/> function to delete it.
        /// ICM: No color management is performed. The contents of the resulting bitmap are not color matched after the bitmap has been created.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDIBitmap", ExactSpelling = true, SetLastError = true)]
        public static extern HBITMAP CreateDIBitmap([In] HDC hdc, [In] in BITMAPINFOHEADER pbmih, [In] CreateDIBitmapFlags flInit,
            [In] IntPtr pjBits, [In] in BITMAPINFO pbmi, [In] UINT iUsage);

        /// <summary>
        /// <para>
        /// The <see cref="CreateDIBSection"/> function creates a DIB that applications can write to directly.
        /// The function gives you a pointer to the location of the bitmap bit values.
        /// You can supply a handle to a file-mapping object that the function will use to create the bitmap,
        /// or you can let the system allocate the memory for the bitmap.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createdibsection"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to a device context.
        /// If the value of <paramref name="usage"/> is <see cref="DIB_PAL_COLORS"/>,
        /// the function uses this device context's logical palette to initialize the DIB colors.
        /// </param>
        /// <param name="pbmi">
        /// A pointer to a <see cref="BITMAPINFO"/> structure that specifies various attributes of the DIB, including the bitmap dimensions and colors.
        /// </param>
        /// <param name="usage">
        /// The type of data contained in the <see cref="BITMAPINFO.bmiColors"/> array member of the <see cref="BITMAPINFO"/> structure
        /// pointed to by <paramref name="pbmi"/> (either logical palette indexes or literal RGB values).
        /// The following values are defined.
        /// <see cref="DIB_PAL_COLORS"/>:
        /// The <see cref="BITMAPINFO.bmiColors"/> member is an array of 16-bit indexes
        /// into the logical palette of the device context specified by <paramref name="hdc"/>.
        /// <see cref="DIB_RGB_COLORS"/>:
        /// The <see cref="BITMAPINFO"/> structure contains an array of literal RGB values.
        /// </param>
        /// <param name="ppvBits">
        /// A pointer to a variable that receives a pointer to the location of the DIB bit values.
        /// </param>
        /// <param name="hSection">
        /// A handle to a file-mapping object that the function will use to create the DIB.
        /// This parameter can be <see cref="NULL"/>.
        /// If <paramref name="hSection"/> is not <see cref="NULL"/>, it must be a handle to a file-mapping object
        /// created by calling the <see cref="CreateFileMapping"/> function with the <see cref="PAGE_READWRITE"/> or <see cref="PAGE_WRITECOPY"/> flag.
        /// Read-only DIB sections are not supported.
        /// Handles created by other means will cause <see cref="CreateDIBSection"/> to fail.
        /// If <paramref name="hSection"/> is not <see cref="NULL"/>, the <see cref="CreateDIBSection"/> function locates the bitmap bit values
        /// at offset <paramref name="offset"/> in the file-mapping object referred to by <paramref name="hSection"/>.
        /// An application can later retrieve the <paramref name="hSection"/> handle by calling the <see cref="GetObject"/> function
        /// with the <see cref="HBITMAP"/> returned by <see cref="CreateDIBSection"/>.
        /// If <paramref name="hSection"/> is <see cref="NULL"/>, the system allocates memory for the DIB.
        /// In this case, the <see cref="CreateDIBSection"/> function ignores the <paramref name="offset"/> parameter.
        /// An application cannot later obtain a handle to this memory.
        /// The <see cref="DIBSECTION.dshSection"/> member of the <see cref="DIBSECTION"/> structure filled in
        /// by calling the <see cref="GetObject"/> function will be <see cref="NULL"/>.
        /// </param>
        /// <param name="offset">
        /// The offset from the beginning of the file-mapping object referenced by <paramref name="hSection"/>
        /// where storage for the bitmap bit values is to begin.
        /// This value is ignored if <paramref name="hSection"/> is <see cref="NULL"/>.
        /// The bitmap bit values are aligned on doubleword boundaries, so <paramref name="offset"/> must be a multiple of the size of a <see cref="DWORD"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the newly created DIB, and <paramref name="ppvBits"/> points to the bitmap bit values.
        /// If the function fails, the return value is <see cref="NULL"/>, and <paramref name="ppvBits"/> is <see cref="NULL"/>.
        /// This function can return the following value.
        /// <see cref="ERROR_INVALID_PARAMETER"/>: One or more of the input parameters is invalid.
        /// </returns>
        /// <remarks>
        /// As noted above, if <paramref name="hSection"/> is <see cref="NULL"/>, the system allocates memory for the DIB.
        /// The system closes the handle to that memory when you later delete the DIB by calling the <see cref="DeleteObject"/> function.
        /// If <paramref name="hSection"/> is not <see cref="NULL"/>, you must close the <paramref name="hSection"/> memory handle yourself
        /// after calling <see cref="DeleteObject"/> to delete the bitmap.
        /// You cannot paste a DIB section from one application into another application.
        /// <see cref="CreateDIBSection"/> does not use the <see cref="BITMAPINFOHEADER"/> parameters <see cref="BITMAPINFOHEADER.biXPelsPerMeter"/>
        /// or <see cref="BITMAPINFOHEADER.biYPelsPerMeter"/> and will not provide resolution information in the <see cref="BITMAPINFO"/> structure.
        /// You need to guarantee that the GDI subsystem has completed any drawing to a bitmap created by <see cref="CreateDIBSection"/>
        /// before you draw to the bitmap yourself.
        /// Access to the bitmap must be synchronized.
        /// Do this by calling the <see cref="GdiFlush"/> function.
        /// This applies to any use of the pointer to the bitmap bit values,
        /// including passing the pointer in calls to functions such as <see cref="SetDIBits"/>.
        /// ICM: No color management is done.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDIBSection", ExactSpelling = true, SetLastError = true)]
        public static extern HBITMAP CreateDIBSection([In] HDC hdc, [In] in BITMAPINFO pbmi, [In] DIBColorTableIdentifiers usage,
            [Out] out IntPtr ppvBits, [In] HANDLE hSection, [In] DWORD offset);

        /// <summary>
        /// <para>
        /// The <see cref="GdiAlphaBlend"/> function displays bitmaps that have transparent or semitransparent pixels.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-gdialphablend"/>
        /// </para>
        /// </summary>
        /// <param name="hdcDest">
        /// A handle to the destination device context.
        /// </param>
        /// <param name="xoriginDest">
        /// The x-coordinate, in logical units, of the upper-left corner of the destination rectangle.
        /// </param>
        /// <param name="yoriginDest">
        /// The y-coordinate, in logical units, of the upper-left corner of the destination rectangle.
        /// </param>
        /// <param name="wDest">
        /// The width, in logical units, of the destination rectangle.
        /// </param>
        /// <param name="hDest">
        /// The height, in logical units, of the destination rectangle.
        /// </param>
        /// <param name="hdcSrc">
        /// A handle to the source device context.
        /// </param>
        /// <param name="xoriginSrc">
        /// The x-coordinate, in logical units, of the upper-left corner of the source rectangle.
        /// </param>
        /// <param name="yoriginSrc">
        /// The y-coordinate, in logical units, of the upper-left corner of the source rectangle.
        /// </param>
        /// <param name="wSrc">
        /// The width, in logical units, of the source rectangle.
        /// </param>
        /// <param name="hSrc">
        /// The height, in logical units, of the source rectangle.
        /// </param>
        /// <param name="ftn">
        /// The alpha-blending function for source and destination bitmaps, a global alpha value
        /// to be applied to the entire source bitmap, and format information for the source bitmap.
        /// The source and destination blend functions are currently limited to <see cref="AC_SRC_OVER"/>.
        /// See the <see cref="BLENDFUNCTION"/> and <see cref="EMRALPHABLEND"/> structures.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// This function can return the following value.
        /// <see cref="ERROR_INVALID_PARAMETER"/>: One or more of the input parameters is invalid.
        /// </returns>
        /// <remarks>
        /// This function is the same as <see cref="AlphaBlend"/>.
        /// If the source rectangle and destination rectangle are not the same size,
        /// the source bitmap is stretched to match the destination rectangle.
        /// If the <see cref="SetStretchBltMode"/> function is used, the iStretchMode value is automatically
        /// converted to <see cref="COLORONCOLOR"/> for this function (that is, <see cref="BLACKONWHITE"/>,
        /// <see cref="WHITEONBLACK"/>, and <see cref="HALFTONE"/> are changed to <see cref="COLORONCOLOR"/>).
        /// The destination coordinates are transformed by using the transformation currently specified for the destination device context.
        /// The source coordinates are transformed by using the transformation currently specified for the source device context.
        /// An error occurs (and the function returns <see cref="FALSE"/>) if the source device context identifies an enhanced metafile device context.
        /// If destination and source bitmaps do not have the same color format,
        /// <see cref="GdiAlphaBlend"/> converts the source bitmap to match the destination bitmap.
        /// <see cref="GdiAlphaBlend"/> does not support mirroring.
        /// If either the width or height of the source or destination is negative, this call will fail.
        /// When rendering to a printer, first call <see cref="GetDeviceCaps"/> with <see cref="SHADEBLENDCAPS"/> to determine
        /// if the printer supports blending with <see cref="GdiAlphaBlend"/>.
        /// Note that, for a display DC, all blending operations are supported and these flags represent whether the operations are accelerated.
        /// If the source and destination are the same surface, that is, they are both the screen or the same memory bitmap
        /// and the source and destination rectangles overlap, an error occurs and the function returns <see cref="FALSE"/>.
        /// The source rectangle must lie completely within the source surface,
        /// otherwise an error occurs and the function returns <see cref="FALSE"/>.
        /// <see cref="GdiAlphaBlend"/> fails if the width or height of the source or destination is negative.
        /// The <see cref="BLENDFUNCTION.SourceConstantAlpha"/> member of <see cref="BLENDFUNCTION"/> specifies
        /// an alpha transparency value to be used on the entire source bitmap.
        /// The <see cref="BLENDFUNCTION.SourceConstantAlpha"/> value is combined with any per-pixel alpha values.
        /// If <see cref="BLENDFUNCTION.SourceConstantAlpha"/> is 0, it is assumed that the image is transparent.
        /// Set the <see cref="BLENDFUNCTION.SourceConstantAlpha"/> value to 255 (which indicates that the image is opaque)
        /// when you only want to use per-pixel alpha values.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GdiAlphaBlend", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GdiAlphaBlend([In] HDC hdcDest, [In] int xoriginDest, [In] int yoriginDest, [In] int wDest,
            [In] int hDest, [In] HDC hdcSrc, [In] int xoriginSrc, [In] int yoriginSrc, [In] int wSrc, [In] int hSrc, [In] BLENDFUNCTION ftn);

        /// <summary>
        /// <para>
        /// The <see cref="GetBitmapBits"/> function copies the bitmap bits of a specified device-dependent bitmap into a buffer.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getbitmapbits"/>
        /// </para>
        /// </summary>
        /// <param name="hbit">
        /// A handle to the device-dependent bitmap.
        /// </param>
        /// <param name="cb">
        /// The number of bytes to copy from the bitmap into the buffer.
        /// </param>
        /// <param name="lpvBits">
        /// A pointer to a buffer to receive the bitmap bits.
        /// The bits are stored as an array of byte values.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the number of bytes copied to the buffer.
        /// If the function fails, the return value is zero.
        /// </returns>
        [Obsolete("This function is provided only for compatibility with 16-bit versions of Windows." +
            "Applications should use the GetDIBits function.")]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetBitmapBits", ExactSpelling = true, SetLastError = true)]
        public static extern LONG GetBitmapBits([In] HBITMAP hbit, [In] LONG cb, [In] LPVOID lpvBits);

        /// <summary>
        /// <para>
        /// The <see cref="GetBitmapDimensionEx"/> function retrieves the dimensions of a compatible bitmap.
        /// The retrieved dimensions must have been set by the <see cref="SetBitmapDimensionEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getbitmapdimensionex"/>
        /// </para>
        /// </summary>
        /// <param name="hbit">
        /// A handle to a compatible bitmap (DDB).
        /// </param>
        /// <param name="lpsize">
        /// A pointer to a <see cref="SIZE"/> structure to receive the bitmap dimensions.
        /// For more information, see Remarks.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The function returns a data structure that contains fields for the height and width of the bitmap, in .01-mm units.
        /// If those dimensions have not yet been set, the structure that is returned will have zeros in those fields.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetBitmapDimensionEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetBitmapDimensionEx([In] HBITMAP hbit, [Out] out SIZE lpsize);

        /// <summary>
        /// <para>
        /// The <see cref="GetDIBits"/> function retrieves the bits of the specified compatible bitmap and copies them into a buffer as a DIB
        /// using the specified format.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getdibits"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="hbm">
        /// A handle to the bitmap.
        /// This must be a compatible bitmap (DDB).
        /// </param>
        /// <param name="start">
        /// The first scan line to retrieve.
        /// </param>
        /// <param name="cLines">
        /// The number of scan lines to retrieve.
        /// </param>
        /// <param name="lpvBits">
        /// A pointer to a buffer to receive the bitmap data.
        /// If this parameter is <see cref="NULL"/>, the function passes the dimensions and format of the bitmap
        /// to the <see cref="BITMAPINFO"/> structure pointed to by the <paramref name="lpbmi"/> parameter.
        /// </param>
        /// <param name="lpbmi">
        /// A pointer to a <see cref="BITMAPINFO"/> structure that specifies the desired format for the DIB data.
        /// </param>
        /// <param name="usage">
        /// The format of the <see cref="BITMAPINFO.bmiColors"/> member of the <see cref="BITMAPINFO"/> structure.
        /// It must be one of the following values.
        /// <see cref="DIB_PAL_COLORS"/>:
        /// The color table should consist of an array of 16-bit indexes into the current logical palette.
        /// <see cref="DIB_RGB_COLORS"/>:
        /// The color table should consist of literal red, green, blue (RGB) values.
        /// </param>
        /// <returns>
        /// If the <paramref name="lpvBits"/> parameter is non-NULL and the function succeeds,
        /// the return value is the number of scan lines copied from the bitmap.
        /// If the <paramref name="lpvBits"/> parameter is <see langword="null"/> and <see cref="GetDIBits"/> successfully
        /// fills the <see cref="BITMAPINFO"/> structure, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// This function can return the following value.
        /// <see cref="ERROR_INVALID_PARAMETER"/>: One or more of the input parameters is invalid.
        /// </returns>
        /// <remarks>
        /// If the requested format for the DIB matches its internal format, the RGB values for the bitmap are copied.
        /// If the requested format doesn't match the internal format, a color table is synthesized.
        /// The following table describes the color table synthesized for each format.
        /// 1_BPP: The color table consists of a black and a white entry.
        /// 4_BPP: The color table consists of a mix of colors identical to the standard VGA palette.
        /// 8_BPP: The color table consists of a general mix of 256 colors defined by GDI.
        /// (Included in these 256 colors are the 20 colors found in the default logical palette.)
        /// 24_BPP: No color table is returned.
        /// If the <paramref name="lpvBits"/> parameter is a valid pointer, the first six members of the <see cref="BITMAPINFOHEADER"/> structure
        /// must be initialized to specify the size and format of the DIB.
        /// The scan lines must be aligned on a <see cref="DWORD"/> except for RLE compressed bitmaps.
        /// A bottom-up DIB is specified by setting the height to a positive number,
        /// while a top-down DIB is specified by setting the height to a negative number.
        /// The bitmap color table will be appended to the <see cref="BITMAPINFO"/> structure.
        /// If <paramref name="lpvBits"/> is <see cref="NULL"/>, <see cref="GetDIBits"/> examines the first member
        /// of the first structure pointed to by <paramref name="lpbmi"/>.
        /// This member must specify the size, in bytes, of a <see cref="BITMAPCOREHEADER"/> or a <see cref="BITMAPINFOHEADER"/> structure.
        /// The function uses the specified size to determine how the remaining members should be initialized.
        /// If <paramref name="lpvBits"/> is <see cref="NULL"/> and the bit count member of <see cref="BITMAPINFO"/> is initialized to zero,
        /// <see cref="GetDIBits"/> fills in a <see cref="BITMAPINFOHEADER"/> structure or <see cref="BITMAPCOREHEADER"/> without the color table.
        /// This technique can be used to query bitmap attributes.
        /// The bitmap identified by the hbmp parameter must not be selected into a device context when the application calls this function.
        /// The origin for a bottom-up DIB is the lower-left corner of the bitmap; the origin for a top-down DIB is the upper-left corner.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDIBits", ExactSpelling = true, SetLastError = true)]
        public static extern int GetDIBits([In] HDC hdc, [In] HBITMAP hbm, [In] UINT start, [In] UINT cLines, [In] LPVOID lpvBits,
            [In] in BITMAPINFO lpbmi, [In] UINT usage);

        /// <summary>
        /// <para>
        /// The <see cref="GetPixel"/> function retrieves the red, green, blue (RGB) color value of the pixel at the specified coordinates.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getpixel"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="x">
        /// The x-coordinate, in logical units, of the pixel to be examined.
        /// </param>
        /// <param name="y">
        /// The y-coordinate, in logical units, of the pixel to be examined.
        /// </param>
        /// <returns>
        /// The return value is the <see cref="COLORREF"/> value that specifies the RGB of the pixel.
        /// If the pixel is outside of the current clipping region, the return value is <see cref="CLR_INVALID"/> (0xFFFFFFFF defined in Wingdi.h).
        /// </returns>
        /// <remarks>
        /// The pixel must be within the boundaries of the current clipping region.
        /// Not all devices support <see cref="GetPixel"/>.
        /// An application should call <see cref="GetDeviceCaps"/> to determine whether a specified device supports this function.
        /// A bitmap must be selected within the device context, otherwise, <see cref="CLR_INVALID"/> is returned on all pixels.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPixel", ExactSpelling = true, SetLastError = true)]
        public static extern COLORREF GetPixel([In] HDC hdc, [In] int x, [In] int y);

        /// <summary>
        /// <para>
        /// The <see cref="GetROP2"/> function retrieves the foreground mix mode of the specified device context.
        /// The mix mode specifies how the pen or interior color and the color already on the screen are combined to yield a new color.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getrop2"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to the device context.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value specifies the foreground mix mode.
        /// If the function fails, the return value is zero.
        /// </returns>
        /// <remarks>
        /// Following are the foreground mix modes.
        /// <see cref="R2_BLACK"/>: Pixel is always 0.
        /// <see cref="R2_COPYPEN"/>: Pixel is the pen color.
        /// <see cref="R2_MASKNOTPEN"/>: Pixel is a combination of the colors common to both the screen and the inverse of the pen.
        /// <see cref="R2_MASKPEN"/>: Pixel is a combination of the colors common to both the pen and the screen.
        /// <see cref="R2_MASKPENNOT"/>: Pixel is a combination of the colors common to both the pen and the inverse of the screen.
        /// <see cref="R2_MERGENOTPEN"/>: Pixel is a combination of the screen color and the inverse of the pen color.
        /// <see cref="R2_MERGEPEN"/>: Pixel is a combination of the pen color and the screen color.
        /// <see cref="R2_MERGEPENNOT"/>: Pixel is a combination of the pen color and the inverse of the screen color.
        /// <see cref="R2_NOP"/>: Pixel remains unchanged.
        /// <see cref="R2_NOT"/>: Pixel is the inverse of the screen color.
        /// <see cref="R2_NOTCOPYPEN"/>: Pixel is the inverse of the pen color.
        /// <see cref="R2_NOTMASKPEN"/>: Pixel is the inverse of the <see cref="R2_MASKPEN"/> color.
        /// <see cref="R2_NOTMERGEPEN"/>: Pixel is the inverse of the <see cref="R2_MERGEPEN"/> color.
        /// <see cref="R2_NOTXORPEN"/>: Pixel is the inverse of the <see cref="R2_XORPEN"/> color.
        /// <see cref="R2_WHITE"/>: Pixel is always 1.
        /// <see cref="R2_XORPEN"/>: Pixel is a combination of the colors in the pen and in the screen, but not in both.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetROP2", ExactSpelling = true, SetLastError = true)]
        public static extern RasterOps GetROP2([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="GetStretchBltMode"/> function retrieves the current stretching mode.
        /// The stretching mode defines how color data is added to or removed from bitmaps that are stretched or compressed
        /// when the <see cref="StretchBlt"/> function is called.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getstretchbltmode"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the current stretching mode. This can be one of the following values.
        /// <see cref="BLACKONWHITE"/>:
        /// Performs a Boolean AND operation using the color values for the eliminated and existing pixels.
        /// If the bitmap is a monochrome bitmap, this mode preserves black pixels at the expense of white pixels.
        /// <see cref="COLORONCOLOR"/>:
        /// Deletes the pixels. This mode deletes all eliminated lines of pixels without trying to preserve their information.
        /// <see cref="HALFTONE"/>:
        /// Maps pixels from the source rectangle into blocks of pixels in the destination rectangle.
        /// The average color over the destination block of pixels approximates the color of the source pixels.
        /// <see cref="STRETCH_ANDSCANS"/>:
        /// Same as <see cref="BLACKONWHITE"/>.
        /// <see cref="STRETCH_DELETESCANS"/>:
        /// Same as <see cref="COLORONCOLOR"/>.
        /// <see cref="STRETCH_HALFTONE"/>:
        /// Same as <see cref="HALFTONE"/>.
        /// <see cref="STRETCH_ORSCANS"/>:
        /// Same as <see cref="WHITEONBLACK"/>.
        /// <see cref="WHITEONBLACK"/>:
        /// Performs a Boolean OR operation using the color values for the eliminated and existing pixels.
        /// If the bitmap is a monochrome bitmap, this mode preserves white pixels at the expense of black pixels.
        /// If the function fails, the return value is zero.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetStretchBltMode", ExactSpelling = true, SetLastError = true)]
        public static extern StretchBltModes GetStretchBltMode([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="MaskBlt"/> function combines the color data for the source and destination bitmaps
        /// using the specified mask and raster operation.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-maskblt"/>
        /// </para>
        /// </summary>
        /// <param name="hdcDest">
        /// A handle to the destination device context.
        /// </param>
        /// <param name="xDest">
        /// The x-coordinate, in logical units, of the upper-left corner of the destination rectangle.
        /// </param>
        /// <param name="yDest">
        /// The y-coordinate, in logical units, of the upper-left corner of the destination rectangle.
        /// </param>
        /// <param name="width">
        /// The width, in logical units, of the destination rectangle and source bitmap.
        /// </param>
        /// <param name="height">
        /// The height, in logical units, of the destination rectangle and source bitmap.
        /// </param>
        /// <param name="hdcSrc">
        /// A handle to the device context from which the bitmap is to be copied.
        /// It must be zero if the dwRop parameter specifies a raster operation that does not include a source.
        /// </param>
        /// <param name="xSrc">
        /// The x-coordinate, in logical units, of the upper-left corner of the source bitmap.
        /// </param>
        /// <param name="ySrc">
        /// The y-coordinate, in logical units, of the upper-left corner of the source bitmap.
        /// </param>
        /// <param name="hbmMask">
        /// A handle to the monochrome mask bitmap combined with the color bitmap in the source device context.
        /// </param>
        /// <param name="xMask">
        /// The horizontal pixel offset for the mask bitmap specified by the hbmMask parameter.
        /// </param>
        /// <param name="yMask">
        /// The vertical pixel offset for the mask bitmap specified by the hbmMask parameter.
        /// </param>
        /// <param name="rop">
        /// The foreground and background ternary raster operation codes (ROPs) that
        /// the function uses to control the combination of source and destination data.
        /// The background raster operation code is stored in the high-order byte of the high-order word of this value;
        /// the foreground raster operation code is stored in the low-order byte of the high-order word of this value;
        /// the low-order word of this value is ignored, and should be zero.
        /// The macro <see cref="MAKEROP4"/> creates such combinations of foreground and background raster operation codes.
        /// For a discussion of foreground and background in the context of this function, see the following Remarks section.
        /// For a list of common raster operation codes (ROPs), see the <see cref="BitBlt"/> function.
        /// Note that the CAPTUREBLT ROP generally cannot be used for printing device contexts.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="MaskBlt"/> function uses device-dependent bitmaps.
        /// A value of 1 in the mask specified by <paramref name="hbmMask"/> indicates that the foreground raster operation code
        /// specified by <paramref name="rop"/> should be applied at that location.
        /// A value of 0 in the mask indicates that the background raster operation code
        /// specified by <paramref name="rop"/> should be applied at that location.
        /// If the raster operations require a source, the mask rectangle must cover the source rectangle.
        /// If it does not, the function will fail.
        /// If the raster operations do not require a source, the mask rectangle must cover the destination rectangle.
        /// If it does not, the function will fail.
        /// If a rotation or shear transformation is in effect for the source device context when this function is called, an error occurs.
        /// However, other types of transformation are allowed.
        /// If the color formats of the source, pattern, and destination bitmaps differ,
        /// this function converts the pattern or source format, or both, to match the destination format.
        /// If the mask bitmap is not a monochrome bitmap, an error occurs.
        /// When an enhanced metafile is being recorded, an error occurs (and the function returns <see cref="FALSE"/>)
        /// if the source device context identifies an enhanced-metafile device context.
        /// Not all devices support the <see cref="MaskBlt"/> function.
        /// An application should call the <see cref="GetDeviceCaps"/> function with the nIndex parameter as <see cref="RC_BITBLT"/>
        /// to determine whether a device supports this function.
        /// If no mask bitmap is supplied, this function behaves exactly like BitBlt, using the foreground raster operation code.
        /// ICM: No color management is performed when blits occur.
        /// When used in a multiple monitor system, both <paramref name="hdcSrc"/> and <paramref name="hdcDest"/> must
        /// refer to the same device or the function will fail.
        /// To transfer data between DCs for different devices, convert the memory bitmap (compatible bitmap, or DDB) to a DIB by calling <see cref="GetDIBits"/>.
        /// To display the DIB to the second device, call <see cref="SetDIBits"/> or <see cref="StretchDIBits"/>.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "MaskBlt", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL MaskBlt([In] HDC hdcDest, [In] int xDest, [In] int yDest, [In] int width, [In] int height, [In] HDC hdcSrc,
            [In] int xSrc, [In] int ySrc, [In] HBITMAP hbmMask, [In] int xMask, [In] int yMask, [In] RasterCodes rop);

        /// <summary>
        /// <para>
        /// The <see cref="PatBlt"/> function paints the specified rectangle using the brush that is currently selected into the specified device context.
        /// The brush color and the surface color or colors are combined by using the specified raster operation.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-patblt"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="x">
        /// The x-coordinate, in logical units, of the upper-left corner of the rectangle to be filled.
        /// </param>
        /// <param name="y">
        /// The y-coordinate, in logical units, of the upper-left corner of the rectangle to be filled.
        /// </param>
        /// <param name="w">
        /// The width, in logical units, of the rectangle.
        /// </param>
        /// <param name="h">
        /// The height, in logical units, of the rectangle.
        /// </param>
        /// <param name="rop">
        /// The raster operation code. This code can be one of the following values.
        /// <see cref="PATCOPY"/>:
        /// Copies the specified pattern into the destination bitmap.
        /// <see cref="PATINVERT"/>:
        /// Combines the colors of the specified pattern with the colors of the destination rectangle by using the Boolean XOR operator.
        /// <see cref="DSTINVERT"/>:
        /// Inverts the destination rectangle.
        /// <see cref="BLACKNESS"/>:
        /// Fills the destination rectangle using the color associated with index 0 in the physical palette.
        /// (This color is black for the default physical palette.)
        /// <see cref="WHITENESS"/>:
        /// Fills the destination rectangle using the color associated with index 1 in the physical palette.
        /// (This color is white for the default physical palette.)
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The values of the <paramref name="rop"/> parameter for this function are a limited subset of the full 256 ternary raster-operation codes;
        /// in particular, an operation code that refers to a source rectangle cannot be used.
        /// Not all devices support the <see cref="PatBlt"/> function.
        /// For more information, see the description of the <see cref="RC_BITBLT"/> capability in the <see cref="GetDeviceCaps"/> function.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "PatBlt", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL PatBlt([In] HDC hdc, [In] int x, [In] int y, [In] int w, [In] int h, [In] RasterCodes rop);

        /// <summary>
        /// <para>
        /// The <see cref="PlgBlt"/> function performs a bit-block transfer of the bits of color data from the specified rectangle
        /// in the source device context to the specified parallelogram in the destination device context.
        /// If the given bitmask handle identifies a valid monochrome bitmap,
        /// the function uses this bitmap to mask the bits of color data from the source rectangle.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-plgblt"/>
        /// </para>
        /// </summary>
        /// <param name="hdcDest">
        /// A handle to the destination device context.
        /// </param>
        /// <param name="lpPoint">
        /// A pointer to an array of three points in logical space that identify three corners of the destination parallelogram.
        /// The upper-left corner of the source rectangle is mapped to the first point in this array,
        /// the upper-right corner to the second point in this array, and the lower-left corner to the third point.
        /// The lower-right corner of the source rectangle is mapped to the implicit fourth point in the parallelogram.
        /// </param>
        /// <param name="hdcSrc">
        /// A handle to the source device context.
        /// </param>
        /// <param name="xSrc">
        /// The x-coordinate, in logical units, of the upper-left corner of the source rectangle.
        /// </param>
        /// <param name="ySrc">
        /// The y-coordinate, in logical units, of the upper-left corner of the source rectangle.
        /// </param>
        /// <param name="width">
        /// The width, in logical units, of the source rectangle.
        /// </param>
        /// <param name="height">
        /// The height, in logical units, of the source rectangle.
        /// </param>
        /// <param name="hbmMask">
        /// A handle to an optional monochrome bitmap that is used to mask the colors of the source rectangle.
        /// </param>
        /// <param name="xMask">
        /// The x-coordinate, in logical units, of the upper-left corner of the monochrome bitmap.
        /// </param>
        /// <param name="yMask">
        /// The y-coordinate, in logical units, of the upper-left corner of the monochrome bitmap.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="PlgBlt"/> function works with device-dependent bitmaps.
        /// The fourth vertex of the parallelogram (D) is defined by treating the first three points (A, B, and C ) as vectors and computing D = B +CA.
        /// If the bitmask exists, a value of one in the mask indicates that the source pixel color should be copied to the destination.
        /// A value of zero in the mask indicates that the destination pixel color is not to be changed.
        /// If the mask rectangle is smaller than the source and destination rectangles, the function replicates the mask pattern.
        /// Scaling, translation, and reflection transformations are allowed in the source device context;
        /// however, rotation and shear transformations are not.
        /// If the mask bitmap is not a monochrome bitmap, an error occurs.
        /// The stretching mode for the destination device context is used to determine how to stretch or compress the pixels, if that is necessary.
        /// When an enhanced metafile is being recorded, an error occurs if the source device context identifies an enhanced-metafile device context.
        /// The destination coordinates are transformed according to the destination device context;
        /// the source coordinates are transformed according to the source device context.
        /// If the source transformation has a rotation or shear, an error is returned.
        /// If the destination and source rectangles do not have the same color format,
        /// <see cref="PlgBlt"/> converts the source rectangle to match the destination rectangle.
        /// Not all devices support the <see cref="PlgBlt"/> function.
        /// For more information, see the description of the <see cref="RC_BITBLT"/> raster capability in the <see cref="GetDeviceCaps"/> function.
        /// If the source and destination device contexts represent incompatible devices, <see cref="PlgBlt"/> returns an error.
        /// When used in a multiple monitor system, both <paramref name="height"/> and <paramref name="hdcDest"/>
        /// must refer to the same device or the function will fail.
        /// To transfer data between DCs for different devices, convert the memory bitmap to a DIB by calling <see cref="GetDIBits"/>.
        /// To display the DIB to the second device, call <see cref="SetDIBits"/> or <see cref="StretchDIBits"/>.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "PlgBlt", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL PlgBlt([In] HDC hdcDest, [MarshalAs(UnmanagedType.LPArray)][In] POINT[] lpPoint, [In] HDC hdcSrc,
            [In] int xSrc, [In] int ySrc, [In] int width, [In] int height, [In] HBITMAP hbmMask, [In] int xMask, [In] int yMask);

        /// <summary>
        /// <para>
        /// The <see cref="SetBitmapBits"/> function sets the bits of color data for a bitmap to the specified values.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setbitmapbits"/>
        /// </para>
        /// </summary>
        /// <param name="hbm">
        /// A handle to the bitmap to be set.
        /// This must be a compatible bitmap (DDB).
        /// </param>
        /// <param name="cb">
        /// The number of bytes pointed to by the <paramref name="pvBits"/> parameter.
        /// </param>
        /// <param name="pvBits">
        /// A pointer to an array of bytes that contain color data for the specified bitmap.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the number of bytes used in setting the bitmap bits.
        /// If the function fails, the return value is zero.
        /// </returns>
        /// <remarks>
        /// The array identified by <paramref name="pvBits"/> must be WORD aligned.
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit versions of Windows." +
            "Applications should use the SetDIBits function.")]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetBitmapBits", ExactSpelling = true, SetLastError = true)]
        public static extern LONG SetBitmapBits([In] HBITMAP hbm, [In] DWORD cb, [In] IntPtr pvBits);

        /// <summary>
        /// <para>
        /// The <see cref="SetBitmapDimensionEx"/> function assigns preferred dimensions to a bitmap.
        /// These dimensions can be used by applications; however, they are not used by the system.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setbitmapdimensionex"/>
        /// </para>
        /// </summary>
        /// <param name="hbm">
        /// A handle to the bitmap. The bitmap cannot be a DIB-section bitmap.
        /// </param>
        /// <param name="w">
        /// The width, in 0.1-millimeter units, of the bitmap.
        /// </param>
        /// <param name="h">
        /// The height, in 0.1-millimeter units, of the bitmap.
        /// </param>
        /// <param name="lpsz">
        /// A pointer to a <see cref="SIZE"/> structure to receive the previous dimensions of the bitmap.
        /// This pointer can be <see cref="NULL"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// An application can retrieve the dimensions assigned to a bitmap with the <see cref="SetBitmapDimensionEx"/> function
        /// by calling the <see cref="GetBitmapDimensionEx"/> function.
        /// The bitmap identified by hBitmap cannot be a DIB section, which is a bitmap created by the <see cref="CreateDIBSection"/> function.
        /// If the bitmap is a DIB section, the <see cref="SetBitmapDimensionEx"/> function fails.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetBitmapDimensionEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetBitmapDimensionEx([In] HBITMAP hbm, [In] int w, [In] int h, [Out] out SIZE lpsz);

        /// <summary>
        /// <para>
        /// The <see cref="SetDIBits"/> function sets the pixels in a compatible bitmap (DDB) using the color data found in the specified DIB.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setdibits"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to a device context.
        /// </param>
        /// <param name="hbm">
        /// A handle to the compatible bitmap (DDB) that is to be altered using the color data from the specified DIB.
        /// </param>
        /// <param name="start">
        /// The starting scan line for the device-independent color data in the array pointed to by the <paramref name="lpBits"/> parameter.
        /// </param>
        /// <param name="cLines">
        /// The number of scan lines found in the array containing device-independent color data.
        /// </param>
        /// <param name="lpBits">
        /// A pointer to the DIB color data, stored as an array of bytes.
        /// The format of the bitmap values depends on the <see cref="BITMAPINFOHEADER.biBitCount"/> member of the <see cref="BITMAPINFO"/> structure
        /// pointed to by the <paramref name="lpbmi"/> parameter.
        /// </param>
        /// <param name="lpbmi">
        /// A pointer to a <see cref="BITMAPINFO"/> structure that contains information about the DIB.
        /// </param>
        /// <param name="ColorUse">
        /// Indicates whether the <see cref="BITMAPINFO.bmiColors"/> member of the <see cref="BITMAPINFO"/> structure was provided and, if so,
        /// whether <see cref="BITMAPINFO.bmiColors"/> contains explicit red, green, blue (RGB) values or palette indexes.
        /// The <paramref name="ColorUse"/> parameter must be one of the following values.
        /// <see cref="DIB_PAL_COLORS"/>:
        /// The color table consists of an array of 16-bit indexes into the logical palette of the device context
        /// identified by the <paramref name="hdc"/> parameter.
        /// <see cref="DIB_RGB_COLORS"/>:
        /// The color table is provided and contains literal RGB values.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the number of scan lines copied.
        /// If the function fails, the return value is zero.
        /// This can be the following value.
        /// <see cref="ERROR_INVALID_PARAMETER"/>: One or more of the input parameters is invalid.
        /// </returns>
        /// <remarks>
        /// Optimal bitmap drawing speed is obtained when the bitmap bits are indexes into the system palette.
        /// Applications can retrieve the system palette colors and indexes by calling the <see cref="GetSystemPaletteEntries"/> function.
        /// After the colors and indexes are retrieved, the application can create the DIB. For more information, see System Palette.
        /// The device context identified by the <paramref name="hdc"/> parameter is used
        /// only if the <see cref="DIB_PAL_COLORS"/> constant is set for the <paramref name="ColorUse"/> parameter; otherwise it is ignored.
        /// The bitmap identified by the hbmp parameter must not be selected into a device context when the application calls this function.
        /// The scan lines must be aligned on a <see cref="DWORD"/> except for RLE-compressed bitmaps.
        /// The origin for bottom-up DIBs is the lower-left corner of the bitmap; the origin for top-down DIBs is the upper-left corner of the bitmap.
        /// ICM: Color management is performed if color management has been enabled with a call to <see cref="SetICMMode"/>
        /// with the iEnableICM parameter set to <see cref="ICM_ON"/>.
        /// If the bitmap specified by <paramref name="lpbmi"/> has a <see cref="BITMAPV4HEADER"/>
        /// that specifies the <see cref="BITMAPV4HEADER.bV4GammaRed"/>, <see cref="BITMAPV4HEADER.bV4GammaGreen"/>,
        /// <see cref="BITMAPV4HEADER.bV4GammaBlue"/> and <see cref="BITMAPV4HEADER.bV4Endpoints"/> members,
        /// or a <see cref="BITMAPV5HEADER"/> that specifies either the <see cref="BITMAPV5HEADER.bV5GammaRed"/>,
        /// <see cref="BITMAPV5HEADER.bV5GammaGreen"/>, <see cref="BITMAPV5HEADER.bV5GammaBlue"/> and <see cref="BITMAPV5HEADER.bV5Endpoints"/> members
        /// or the <see cref="BITMAPV5HEADER.bV5ProfileData"/> and <see cref="BITMAPV5HEADER.bV5ProfileSize"/> members,
        /// then the call treats the bitmap's pixels as being expressed in the color space described by those members,
        /// rather than in the device context's source color space.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetDIBits", ExactSpelling = true, SetLastError = true)]
        public static extern int SetDIBits([In] HDC hdc, [In] HBITMAP hbm, [In] UINT start, [In] UINT cLines, [In] IntPtr lpBits,
            [In] in BITMAPINFO lpbmi, [In] UINT ColorUse);

        /// <summary>
        /// <para>
        /// The <see cref="SetDIBitsToDevice"/> function sets the pixels in the specified rectangle on the device
        /// that is associated with the destination device context using color data from a DIB, JPEG, or PNG image.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setdibitstodevice"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="xDest">
        /// The x-coordinate, in logical units, of the upper-left corner of the destination rectangle.
        /// </param>
        /// <param name="yDest">
        /// The y-coordinate, in logical units, of the upper-left corner of the destination rectangle.
        /// </param>
        /// <param name="w">
        /// The width, in logical units, of the image.
        /// </param>
        /// <param name="h">
        /// The height, in logical units, of the image.
        /// </param>
        /// <param name="xSrc">
        /// The x-coordinate, in logical units, of the lower-left corner of the image.
        /// </param>
        /// <param name="ySrc">
        /// The y-coordinate, in logical units, of the lower-left corner of the image.
        /// </param>
        /// <param name="StartScan">
        /// The starting scan line in the image.
        /// </param>
        /// <param name="cLines">
        /// The number of DIB scan lines contained in the array pointed to by the <paramref name="lpvBits"/> parameter.
        /// </param>
        /// <param name="lpvBits">
        /// A pointer to the color data stored as an array of bytes.
        /// For more information, see the following Remarks section.
        /// </param>
        /// <param name="lpbmi">
        /// A pointer to a <see cref="BITMAPINFO"/> structure that contains information about the DIB.
        /// </param>
        /// <param name="ColorUse">
        /// Indicates whether the <see cref="BITMAPINFO.bmiColors"/> member of the <see cref="BITMAPINFO"/> structure contains
        /// explicit red, green, blue (RGB) values or indexes into a palette.
        /// For more information, see the following Remarks section.
        /// The <paramref name="ColorUse"/> parameter must be one of the following values.
        /// <see cref="DIB_PAL_COLORS"/>: The color table consists of an array of 16-bit indexes into the currently selected logical palette.
        /// <see cref="DIB_RGB_COLORS"/>: The color table contains literal RGB values.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the number of scan lines set.
        /// If zero scan lines are set (such as when <paramref name="h"/> is 0) or the function fails, the function returns zero.
        /// If the driver cannot support the JPEG or PNG file image passed to <see cref="SetDIBitsToDevice"/>,
        /// the function will fail and return <see cref="GDI_ERROR"/>.
        /// If failure does occur, the application must fall back on its own JPEG or PNG support to decompress the image into a bitmap,
        /// and then pass the bitmap to <see cref="SetDIBitsToDevice"/>.
        /// </returns>
        /// <remarks>
        /// Optimal bitmap drawing speed is obtained when the bitmap bits are indexes into the system palette.
        /// Applications can retrieve the system palette colors and indexes by calling the <see cref="GetSystemPaletteEntries"/> function.
        /// After the colors and indexes are retrieved, the application can create the DIB.
        /// For more information about the system palette, see Colors.
        /// The scan lines must be aligned on a DWORD except for RLE-compressed bitmaps.
        /// The origin of a bottom-up DIB is the lower-left corner of the bitmap; the origin of a top-down DIB is the upper-left corner.
        /// To reduce the amount of memory required to set bits from a large DIB on a device surface,
        /// an application can band the output by repeatedly calling <see cref="SetDIBitsToDevice"/>,
        /// placing a different portion of the bitmap into the <paramref name="lpvBits"/> array each time.
        /// The values of the <paramref name="StartScan"/> and <paramref name="cLines"/> parameters identify the portion of the bitmap
        /// contained in the <paramref name="lpvBits"/> array.
        /// The <see cref="SetDIBitsToDevice"/> function returns an error if it is called by a process that is running in the background
        /// while a full-screen MS-DOS session runs in the foreground.
        /// If the <see cref="BITMAPINFOHEADER.biCompression"/> member of <see cref="BITMAPINFOHEADER"/> is <see cref="BI_JPEG"/> or <see cref="BI_PNG"/>,
        /// <paramref name="lpvBits"/> points to a buffer containing a JPEG or PNG image.
        /// The <see cref="BITMAPINFOHEADER.biSizeImage"/> member of specifies the size of the buffer.
        /// The <paramref name="ColorUse"/> parameter must be set to <see cref="DIB_RGB_COLORS"/>.
        /// To ensure proper metafile spooling while printing, applications must call the <see cref="CHECKJPEGFORMAT"/>
        /// or <see cref="CHECKPNGFORMAT"/> escape to verify that the printer recognizes the JPEG or PNG image,
        /// respectively, before calling <see cref="SetDIBitsToDevice"/>.
        /// ICM: Color management is performed if color management has been enabled with a call to <see cref="SetICMMode"/>
        /// with the iEnableICM parameter set to <see cref="ICM_ON"/>.
        /// If the bitmap specified by <paramref name="lpbmi"/> has a <see cref="BITMAPV4HEADER"/>
        /// that specifies the <see cref="BITMAPV4HEADER.bV4GammaRed"/>, <see cref="BITMAPV4HEADER.bV4GammaGreen"/>,
        /// <see cref="BITMAPV4HEADER.bV4GammaBlue"/> and <see cref="BITMAPV4HEADER.bV4Endpoints"/> members,
        /// or a <see cref="BITMAPV5HEADER"/> that specifies either the <see cref="BITMAPV5HEADER.bV5GammaRed"/>,
        /// <see cref="BITMAPV5HEADER.bV5GammaGreen"/>, <see cref="BITMAPV5HEADER.bV5GammaBlue"/> and <see cref="BITMAPV5HEADER.bV5Endpoints"/> members
        /// or the <see cref="BITMAPV5HEADER.bV5ProfileData"/> and <see cref="BITMAPV5HEADER.bV5ProfileSize"/> members,
        /// then the call treats the bitmap's pixels as being expressed in the color space described by those members,
        /// rather than in the device context's source color space.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetDIBitsToDevice", ExactSpelling = true, SetLastError = true)]
        public static extern int SetDIBitsToDevice([In] HDC hdc, [In] int xDest, [In] int yDest, [In] DWORD w, [In] DWORD h, [In] int xSrc, [In] int ySrc,
            [In] UINT StartScan, [In] UINT cLines, [In] IntPtr lpvBits, [In] in BITMAPINFO lpbmi, [In] UINT ColorUse);

        /// <summary>
        /// <para>
        /// The <see cref="SetPixel"/> function sets the pixel at the specified coordinates to the specified color.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setpixel"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="x">
        /// The x-coordinate, in logical units, of the point to be set.
        /// </param>
        /// <param name="y">
        /// The y-coordinate, in logical units, of the point to be set.
        /// </param>
        /// <param name="color">
        /// The color to be used to paint the point.
        /// To create a <see cref="COLORREF"/> color value, use the <see cref="RGB"/> macro.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the RGB value that the function sets the pixel to.
        /// This value may differ from the color specified by <paramref name="color"/>; that occurs when an exact match for the specified color cannot be found.
        /// If the function fails, the return value is -1.
        /// This can be the following value.
        /// <see cref="ERROR_INVALID_PARAMETER"/>: One or more of the input parameters is invalid.
        /// </returns>
        /// <remarks>
        /// The function fails if the pixel coordinates lie outside of the current clipping region.
        /// Not all devices support the <see cref="SetPixel"/> function.
        /// For more information, see <see cref="GetDeviceCaps"/>.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetPixel", ExactSpelling = true, SetLastError = true)]
        public static extern COLORREF SetPixel([In] HDC hdc, [In] int x, [In] int y, [In] COLORREF color);

        /// <summary>
        /// <para>
        /// The <see cref="SetROP2"/> function sets the current foreground mix mode.
        /// GDI uses the foreground mix mode to combine pens and interiors of filled objects with the colors already on the screen.
        /// The foreground mix mode defines how colors from the brush or pen and the colors in the existing image are to be combined.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setrop2"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="rop2">
        /// The mix mode. This parameter can be one of the following values.
        /// <see cref="R2_BLACK"/>: Pixel is always 0.
        /// <see cref="R2_COPYPEN"/>: Pixel is the pen color.
        /// <see cref="R2_MASKNOTPEN"/>: Pixel is a combination of the colors common to both the screen and the inverse of the pen.
        /// <see cref="R2_MASKPEN"/>: Pixel is a combination of the colors common to both the pen and the screen.
        /// <see cref="R2_MASKPENNOT"/>: Pixel is a combination of the colors common to both the pen and the inverse of the screen.
        /// <see cref="R2_MERGENOTPEN"/>: Pixel is a combination of the screen color and the inverse of the pen color.
        /// <see cref="R2_MERGEPEN"/>: Pixel is a combination of the pen color and the screen color.
        /// <see cref="R2_MERGEPENNOT"/>: Pixel is a combination of the pen color and the inverse of the screen color.
        /// <see cref="R2_NOP"/>: Pixel remains unchanged.
        /// <see cref="R2_NOT"/>: Pixel is the inverse of the screen color.
        /// <see cref="R2_NOTCOPYPEN"/>: Pixel is the inverse of the pen color.
        /// <see cref="R2_NOTMASKPEN"/>: Pixel is the inverse of the <see cref="R2_MASKPEN"/> color.
        /// <see cref="R2_NOTMERGEPEN"/>: Pixel is the inverse of the <see cref="R2_MERGEPEN"/> color.
        /// <see cref="R2_NOTXORPEN"/>: Pixel is the inverse of the <see cref="R2_XORPEN"/> color.
        /// <see cref="R2_WHITE"/>: Pixel is always 1.
        /// <see cref="R2_XORPEN"/>: Pixel is a combination of the colors in the pen and in the screen, but not in both.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value specifies the previous mix mode.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// Mix modes define how GDI combines source and destination colors when drawing with the current pen.
        /// The mix modes are binary raster operation codes, representing all possible Boolean functions of two variables,
        /// using the binary operations AND, OR, and XOR (exclusive OR), and the unary operation NOT.
        /// The mix mode is for raster devices only; it is not available for vector devices.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetROP2", ExactSpelling = true, SetLastError = true)]
        public static extern int SetROP2([In] HDC hdc, [In] RasterOps rop2);

        /// <summary>
        /// <para>
        /// The <see cref="SetStretchBltMode"/> function sets the bitmap stretching mode in the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setstretchbltmode"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="mode">
        /// The stretching mode. This parameter can be one of the following values.
        /// <see cref="BLACKONWHITE"/>:
        /// Performs a Boolean AND operation using the color values for the eliminated and existing pixels.
        /// If the bitmap is a monochrome bitmap, this mode preserves black pixels at the expense of white pixels.
        /// <see cref="COLORONCOLOR"/>:
        /// Deletes the pixels.
        /// This mode deletes all eliminated lines of pixels without trying to preserve their information.
        /// <see cref="HALFTONE"/>:
        /// Maps pixels from the source rectangle into blocks of pixels in the destination rectangle.
        /// The average color over the destination block of pixels approximates the color of the source pixels.
        /// After setting the <see cref="HALFTONE"/> stretching mode, an application must call the <see cref="SetBrushOrgEx"/> function to set the brush origin.
        /// If it fails to do so, brush misalignment occurs.
        /// <see cref="STRETCH_ANDSCANS"/>:
        /// Same as <see cref="BLACKONWHITE"/>.
        /// <see cref="STRETCH_DELETESCANS"/>:
        /// Same as <see cref="COLORONCOLOR"/>.
        /// <see cref="STRETCH_HALFTONE"/>:
        /// Same as <see cref="HALFTONE"/>.
        /// <see cref="STRETCH_ORSCANS"/>:
        /// Same as <see cref="WHITEONBLACK"/>.
        /// <see cref="WHITEONBLACK"/>:
        /// Performs a Boolean OR operation using the color values for the eliminated and existing pixels.
        /// If the bitmap is a monochrome bitmap, this mode preserves white pixels at the expense of black pixels.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the previous stretching mode.
        /// If the function fails, the return value is zero.
        /// This function can return the following value.
        /// <see cref="ERROR_INVALID_PARAMETER"/>: One or more of the input parameters is invalid.
        /// </returns>
        /// <remarks>
        /// The stretching mode defines how the system combines rows or columns of a bitmap with existing pixels on a display device
        /// when an application calls the <see cref="StretchBlt"/> function.
        /// The <see cref="BLACKONWHITE"/> (<see cref="STRETCH_ANDSCANS"/>) and <see cref="WHITEONBLACK"/> (<see cref="STRETCH_ORSCANS"/>) modes
        /// are typically used to preserve foreground pixels in monochrome bitmaps.
        /// The <see cref="COLORONCOLOR"/> (<see cref="STRETCH_DELETESCANS"/>) mode is typically used to preserve color in color bitmaps.
        /// The <see cref="HALFTONE"/> mode is slower and requires more processing of the source image than the other three modes;
        /// but produces higher quality images.
        /// Also note that <see cref="SetBrushOrgEx"/> must be called after setting the <see cref="HALFTONE"/> mode to avoid brush misalignment.
        /// Additional stretching modes might also be available depending on the capabilities of the device driver.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetStretchBltMode", ExactSpelling = true, SetLastError = true)]
        public static extern int SetStretchBltMode([In] HDC hdc, [In] StretchBltModes mode);

        /// <summary>
        /// <para>
        /// The <see cref="StretchBlt"/> function copies a bitmap from a source rectangle into a destination rectangle,
        /// stretching or compressing the bitmap to fit the dimensions of the destination rectangle, if necessary.
        /// The system stretches or compresses the bitmap according to the stretching mode currently set in the destination device context.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-stretchblt"/>
        /// </para>
        /// </summary>
        /// <param name="hdcDest">
        /// A handle to the destination device context.
        /// </param>
        /// <param name="xDest">
        /// The x-coordinate, in logical units, of the upper-left corner of the destination rectangle.
        /// </param>
        /// <param name="yDest">
        /// The y-coordinate, in logical units, of the upper-left corner of the destination rectangle.
        /// </param>
        /// <param name="wDest">
        /// The width, in logical units, of the destination rectangle.
        /// </param>
        /// <param name="hDest">
        /// The height, in logical units, of the destination rectangle.
        /// </param>
        /// <param name="hdcSrc">
        /// A handle to the source device context.
        /// </param>
        /// <param name="xSrc">
        /// The x-coordinate, in logical units, of the upper-left corner of the source rectangle.
        /// </param>
        /// <param name="ySrc">
        /// The y-coordinate, in logical units, of the upper-left corner of the source rectangle.
        /// </param>
        /// <param name="wSrc">
        /// The width, in logical units, of the source rectangle.
        /// </param>
        /// <param name="hSrc">
        /// The height, in logical units, of the source rectangle.
        /// </param>
        /// <param name="rop">
        /// The raster operation to be performed.
        /// Raster operation codes define how the system combines colors in output operations that involve a brush, a source bitmap, and a destination bitmap.
        /// See <see cref="BitBlt"/> for a list of common raster operation codes (ROPs).
        /// Note that the CAPTUREBLT ROP generally cannot be used for printing device contexts.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="StretchBlt"/> stretches or compresses the source bitmap in memory and then copies the result to the destination rectangle.
        /// This bitmap can be either a compatible bitmap (DDB) or the output from <see cref="CreateDIBSection"/>.
        /// The color data for pattern or destination pixels is merged after the stretching or compression occurs.
        /// When an enhanced metafile is being recorded, an error occurs (and the function returns <see cref="FALSE"/>)
        /// if the source device context identifies an enhanced-metafile device context.
        /// If the specified raster operation requires a brush, the system uses the brush currently selected into the destination device context.
        /// The destination coordinates are transformed by using the transformation currently specified for the destination device context;
        /// the source coordinates are transformed by using the transformation currently specified for the source device context.
        /// If the source transformation has a rotation or shear, an error occurs.
        /// If destination, source, and pattern bitmaps do not have the same color format,
        /// <see cref="StretchBlt"/> converts the source and pattern bitmaps to match the destination bitmap.
        /// If <see cref="StretchBlt"/> must convert a monochrome bitmap to a color bitmap,
        /// it sets white bits (1) to the background color and black bits (0) to the foreground color.
        /// To convert a color bitmap to a monochrome bitmap, it sets pixels that match the background color to white (1) and sets all other pixels to black (0).
        /// The foreground and background colors of the device context with color are used.
        /// <see cref="StretchBlt"/> creates a mirror image of a bitmap if the signs of the <paramref name="wSrc"/> and <paramref name="wDest"/> parameters 
        /// or if the <paramref name="hSrc"/> and <paramref name="hDest"/> parameters differ.
        /// If <paramref name="wSrc"/> and <paramref name="wDest"/> have different signs, the function creates a mirror image of the bitmap along the x-axis.
        /// If <paramref name="hSrc"/> and <paramref name="hDest"/> have different signs, the function creates a mirror image of the bitmap along the y-axis.
        /// Not all devices support the <see cref="StretchBlt"/> function.
        /// For more information, see the <see cref="GetDeviceCaps"/>.
        /// ICM: No color management is performed when a blit operation occurs.
        /// When used in a multiple monitor system, both <paramref name="hdcSrc"/> and <paramref name="hdcDest"/> must refer to the same device
        /// or the function will fail.
        /// To transfer data between DCs for different devices, convert the memory bitmap to a DIB by calling <see cref="GetDIBits"/>.
        /// To display the DIB to the second device, call <see cref="SetDIBits"/> or <see cref="StretchDIBits"/>.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "StretchBlt", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL StretchBlt([In] HDC hdcDest, [In] int xDest, [In] int yDest, [In] int wDest, [In] int hDest, [In] HDC hdcSrc,
            [In] int xSrc, [In] int ySrc, [In] int wSrc, [In] int hSrc, [In] RasterCodes rop);

        /// <summary>
        /// <para>
        /// The <see cref="StretchDIBits"/> function copies the color data for a rectangle of pixels in a DIB, JPEG, or PNG image
        /// to the specified destination rectangle.
        /// If the destination rectangle is larger than the source rectangle, this function stretches the rows and columns of color data
        /// to fit the destination rectangle.
        /// If the destination rectangle is smaller than the source rectangle, this function compresses the rows and columns
        /// by using the specified raster operation.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-stretchdibits"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the destination device context.
        /// </param>
        /// <param name="xDest">
        /// The x-coordinate, in logical units, of the upper-left corner of the destination rectangle.
        /// </param>
        /// <param name="yDest">
        /// The y-coordinate, in logical units, of the upper-left corner of the destination rectangle.
        /// </param>
        /// <param name="DestWidth">
        /// The width, in logical units, of the destination rectangle.
        /// </param>
        /// <param name="DestHeight">
        /// The height, in logical units, of the destination rectangle.
        /// </param>
        /// <param name="xSrc">
        /// The x-coordinate, in pixels, of the source rectangle in the image.
        /// </param>
        /// <param name="ySrc">
        /// The y-coordinate, in pixels, of the source rectangle in the image.
        /// </param>
        /// <param name="SrcWidth">
        /// The width, in pixels, of the source rectangle in the image.
        /// </param>
        /// <param name="SrcHeight">
        /// The height, in pixels, of the source rectangle in the image.
        /// </param>
        /// <param name="lpBits">
        /// A pointer to the image bits, which are stored as an array of bytes.
        /// For more information, see the Remarks section.
        /// </param>
        /// <param name="lpbmi">
        /// A pointer to a <see cref="BITMAPINFO"/> structure that contains information about the DIB.
        /// </param>
        /// <param name="iUsage">
        /// Specifies whether the <see cref="BITMAPINFO.bmiColors"/> member of the <see cref="BITMAPINFO"/> structure was provided and,
        /// if so, whether <see cref="BITMAPINFO.bmiColors"/> contains explicit red, green, blue (RGB) values or indexes.
        /// The <paramref name="iUsage"/> parameter must be one of the following values.
        /// <see cref="DIB_PAL_COLORS"/>:
        /// The array contains 16-bit indexes into the logical palette of the source device context.
        /// <see cref="DIB_RGB_COLORS"/>:
        /// The color table contains literal RGB values.
        /// For more information, see the Remarks section.
        /// </param>
        /// <param name="rop">
        /// A raster-operation code that specifies how the source pixels, the destination device context's current brush,
        /// and the destination pixels are to be combined to form the new image.
        /// For a list of some common raster operation codes, see <see cref="BitBlt"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the number of scan lines copied.
        /// Note that this value can be negative for mirrored content.
        /// If the function fails, or no scan lines are copied, the return value is 0.
        /// If the driver cannot support the JPEG or PNG file image passed to <see cref="StretchDIBits"/>,
        /// the function will fail and return <see cref="GDI_ERROR"/>.
        /// If failure does occur, the application must fall back on its own JPEG or PNG support to decompress the image into a bitmap,
        /// and then pass the bitmap to <see cref="StretchDIBits"/>.
        /// </returns>
        /// <remarks>
        /// The origin of a bottom-up DIB is the lower-left corner; the origin of a top-down DIB is the upper-left corner.
        /// <see cref="StretchDIBits"/> creates a mirror image of a bitmap if the signs of the <paramref name="SrcWidth"/>
        /// and <paramref name="DestWidth"/> parameters, or if the <paramref name="SrcHeight"/> and <paramref name="DestHeight"/> parameters differ.
        /// If <paramref name="SrcWidth"/> and <paramref name="DestWidth"/> have different signs,
        /// the function creates a mirror image of the bitmap along the x-axis.
        /// If <paramref name="SrcHeight"/> and <paramref name="DestHeight"/> have different signs,
        /// the function creates a mirror image of the bitmap along the y-axis.
        /// <see cref="StretchDIBits"/> creates a top-down image if the sign of the <see cref="BITMAPINFOHEADER.biHeight"/> member
        /// of the <see cref="BITMAPINFOHEADER"/> structure for the DIB is negative.
        /// For a code example, see Sizing a JPEG or PNG Image.
        /// This function allows a JPEG or PNG image to be passed as the source image.
        /// How each parameter is used remains the same, except:
        /// If the <see cref="BITMAPINFOHEADER.biCompression"/> member of <see cref="BITMAPINFOHEADER"/> is BI_JPEG or BI_PNG,
        /// <paramref name="lpBits"/> points to a buffer containing a JPEG or PNG image, respectively.
        /// The <see cref="BITMAPINFOHEADER.biSizeImage"/> member of the <see cref="BITMAPINFOHEADER"/> structure specifies the size of the buffer.
        /// The <paramref name="iUsage"/> parameter must be set to <see cref="DIB_RGB_COLORS"/>.
        /// The <paramref name="rop"/> parameter must be set to <see cref="SRCCOPY"/>.
        /// To ensure proper metafile spooling while printing, applications must call the <see cref="CHECKJPEGFORMAT"/>
        /// or <see cref="CHECKPNGFORMAT"/> escape to verify that the printer recognizes the JPEG or PNG image,
        /// respectively, before calling <see cref="StretchDIBits"/>.
        /// ICM: Color management is performed if color management has been enabled with a call to <see cref="SetICMMode"/>
        /// with the iEnableICM parameter set to <see cref="ICM_ON"/>.
        /// If the bitmap specified by <paramref name="lpbmi"/> has a <see cref="BITMAPV4HEADER"/> that specifies the gamma and endpoints members,
        /// or a <see cref="BITMAPV5HEADER"/> that specifies either the <see cref="BITMAPV5HEADER.bV5GammaRed"/>,
        /// <see cref="BITMAPV5HEADER.bV5GammaGreen"/>, <see cref="BITMAPV5HEADER.bV5GammaBlue"/> and <see cref="BITMAPV5HEADER.bV5Endpoints"/> members
        /// or the <see cref="BITMAPV5HEADER.bV5ProfileData"/> and <see cref="BITMAPV5HEADER.bV5ProfileSize"/> members,
        /// then the call treats the bitmap's pixels as being expressed in the color space described by those members,
        /// rather than in the device context's source color space.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "StretchDIBits", ExactSpelling = true, SetLastError = true)]
        public static extern int StretchDIBits([In] HDC hdc, [In] int xDest, [In] int yDest, [In] int DestWidth, [In] int DestHeight, [In] int xSrc,
            [In] int ySrc, [In] int SrcWidth, [In] int SrcHeight, [In] IntPtr lpBits, [In] in BITMAPINFO lpbmi,
            [In] UINT iUsage, [In] RasterCodes rop);
    }
}
