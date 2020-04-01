using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

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
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-bitblt
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "BitBlt", SetLastError = true)]
        public static extern BOOL BitBlt([In]HDC hdc, [In]int x, [In]int y, [In]int cx, [In]int cy, [In]HDC hdcSrc, [In]int x1, [In]int y1, [In]RasterCodes rop);

        /// <summary>
        /// <para>
        /// The <see cref="CreateBitmap"/> function creates a bitmap with the specified width, height, and color format (color planes and bits-per-pixel).
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createbitmap
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateCompatibleBitmap", SetLastError = true)]
        public static extern HBITMAP CreateBitmap([In]int nWidth, [In]int nHeight, [In]UINT nPlanes, [In]UINT nBitCount, [In]IntPtr lpBits);

        /// <summary>
        /// <para>
        /// The <see cref="CreateBitmapIndirect"/> function creates a bitmap with the specified width, height, and color format (color planes and bits-per-pixel).
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createbitmapindirect
        /// </para>
        /// </summary>
        /// <param name="pbm">
        /// A pointer to a <see cref="BITMAP"/> structure that contains information about the bitmap.
        /// If an application sets the <see cref="bmWidth"/> or <see cref="bmHeight"/> members to zero,
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateBitmapIndirect", SetLastError = true)]
        public static extern HBITMAP CreateBitmapIndirect([MarshalAs(UnmanagedType.LPStruct)][In]BITMAP pbm);

        /// <summary>
        /// <para>
        /// The <see cref="CreateCompatibleBitmap"/> function creates a bitmap compatible with the device that is associated with the specified device context.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createcompatiblebitmap
        /// </para>
        /// </summary>
        /// <param name="hdc">A handle to a device context.</param>
        /// <param name="nWidth">The bitmap width, in pixels.</param>
        /// <param name="nHeight">The bitmap height, in pixels.</param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the compatible bitmap (DDB).
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateCompatibleBitmap", SetLastError = true)]
        public static extern HBITMAP CreateCompatibleBitmap([In]HDC hdc, [In]int nWidth, [In]int nHeight);

        /// <summary>
        /// <para>
        /// The <see cref="CreateDiscardableBitmap"/> function creates a discardable bitmap that is compatible with the specified device.
        /// The bitmap has the same bits-per-pixel format and the same color palette as the device.
        /// An application can select this bitmap as the current bitmap for a memory device that is compatible with the specified device.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-creatediscardablebitmap
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDiscardableBitmap", SetLastError = true)]
        public static extern HBITMAP CreateDiscardableBitmap([In]HDC hdc, [In]int cx, [In]int cy);

        /// <summary>
        /// <para>
        /// The <see cref="CreateDIBitmap"/> function creates a compatible bitmap (DDB) from a DIB and, optionally, sets the bitmap bits.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createdibitmap
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
        /// The format of the data depends on the <see cref="BITMAPINFO.biBitCount"/> member of the <see cref="BITMAPINFO"/> structure
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
        /// The <see cref="CBM_CREATDIB"/> flag for the fdwInit parameter is no longer supported.
        /// When you no longer need the bitmap, call the <see cref="DeleteObject"/> function to delete it.
        /// ICM: No color management is performed. The contents of the resulting bitmap are not color matched after the bitmap has been created.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDIBitmap", SetLastError = true)]
        public static extern HBITMAP CreateDIBitmap([In]HDC hdc, [MarshalAs(UnmanagedType.LPStruct)][In]BITMAPINFOHEADER pbmih, [In]DWORD flInit,
            [In]IntPtr pjBits, [MarshalAs(UnmanagedType.LPStruct)][In]BITMAPINFO pbmi, [In]UINT iUsage);

        /// <summary>
        /// <para>
        /// The <see cref="GetBitmapBits"/> function copies the bitmap bits of a specified device-dependent bitmap into a buffer.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getbitmapbits
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetBitmapBits", SetLastError = true)]
        public static extern LONG GetBitmapBits([In]HBITMAP hbit, [In]LONG cb, [In]LPVOID lpvBits);

        /// <summary>
        /// <para>
        /// The <see cref="GetBitmapDimensionEx"/> function retrieves the dimensions of a compatible bitmap.
        /// The retrieved dimensions must have been set by the <see cref="SetBitmapDimensionEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getbitmapdimensionex
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetBitmapDimensionEx", SetLastError = true)]
        public static extern BOOL GetBitmapDimensionEx([In]HBITMAP hbit, [Out]out SIZE lpsize);

        /// <summary>
        /// <para>
        /// The <see cref="GetPixel"/> function retrieves the red, green, blue (RGB) color value of the pixel at the specified coordinates.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getpixel
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPixel", SetLastError = true)]
        public static extern COLORREF GetPixel([In]HDC hdc, [In]int x, [In]int y);

        /// <summary>
        /// <para>
        /// The <see cref="GetROP2"/> function retrieves the foreground mix mode of the specified device context.
        /// The mix mode specifies how the pen or interior color and the color already on the screen are combined to yield a new color.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getrop2
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetROP2", SetLastError = true)]
        public static extern RasterOps GetROP2([In]HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="GetStretchBltMode"/> function retrieves the current stretching mode.
        /// The stretching mode defines how color data is added to or removed from bitmaps that are stretched or compressed
        /// when the <see cref="StretchBlt"/> function is called.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getstretchbltmode
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetStretchBltMode", SetLastError = true)]
        public static extern StretchBltModes GetStretchBltMode([In]HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="LoadBitmap"/> function loads the specified bitmap resource from a module's executable file.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-loadbitmapw
        /// </para>
        /// </summary>
        /// <param name="hInstance">
        /// A handle to the instance of the module whose executable file contains the bitmap to be loaded.
        /// </param>
        /// <param name="lpBitmapName">
        /// A pointer to a null-terminated string that contains the name of the bitmap resource to be loaded.
        /// Alternatively, this parameter can consist of the resource identifier in the low-order word and zero in the high-order word.
        /// The <see cref="MAKEINTRESOURCE"/> macro can be used to create this value.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the specified bitmap.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// If the bitmap pointed to by the <paramref name="lpBitmapName"/> parameter does not exist or
        /// there is insufficient memory to load the bitmap, the function fails.
        /// <see cref="LoadBitmap"/> creates a compatible bitmap of the display, which cannot be selected to a printer.
        /// To load a bitmap that you can select to a printer, call <see cref="LoadImage"/> and specify <see cref="LR_CREATEDIBSECTION"/> to create a DIB section.
        /// A DIB section can be selected to any device.
        /// An application can use the <see cref="LoadBitmap"/> function to access predefined bitmaps.
        /// To do so, the application must set the <paramref name="hInstance"/> parameter to <see cref="NULL"/>
        /// and the <paramref name="lpBitmapName"/> parameter to one of the following values.
        /// OBM_BTNCORNERS, OBM_BTSIZE, OBM_CHECK, OBM_CHECKBOXES, OBM_CLOSE, OBM_COMBO, OBM_DNARROW, OBM_DNARROWD, OBM_DNARROWI, OBM_LFARROW,
        /// OBM_LFARROWD, OBM_LFARROWI, OBM_MNARROW, OBM_OLD_CLOSE, OBM_OLD_DNARROW, OBM_OLD_LFARROW, OBM_OLD_REDUCE, OBM_OLD_RESTORE,
        /// OBM_OLD_RGARROW, OBM_OLD_UPARROW, OBM_OLD_ZOOM, OBM_REDUCE, OBM_REDUCED, OBM_RESTORE, OBM_RESTORED, OBM_RGARROW, OBM_RGARROWD,
        /// OBM_RGARROWI, OBM_SIZE, OBM_UPARROW, OBM_UPARROWD, OBM_UPARROWI, OBM_ZOOM, OBM_ZOOMD
        /// Bitmap names that begin with OBM_OLD represent bitmaps used by 16-bit versions of Windows earlier than 3.0.
        /// For an application to use any of the OBM_ constants,
        /// the constant <see cref="OEMRESOURCE"/> must be defined before the Windows.h header file is included.
        /// The application must call the <see cref="DeleteObject"/> function to delete each bitmap handle returned by the <see cref="LoadBitmap"/> function.
        /// </remarks>
        [Obsolete("LoadBitmap is available for use in the operating systems specified in the Requirements section." +
            "It may be altered or unavailable in subsequent versions. Instead, use LoadImage and DrawFrameControl.")]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadBitmapW", SetLastError = true)]
        public static extern HBITMAP LoadBitmap([In]HINSTANCE hInstance, [MarshalAs(UnmanagedType.LPWStr)][In]string lpBitmapName);

        /// <summary>
        /// <para>
        /// The <see cref="PatBlt"/> function paints the specified rectangle using the brush that is currently selected into the specified device context.
        /// The brush color and the surface color or colors are combined by using the specified raster operation.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-patblt
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "PatBlt", SetLastError = true)]
        public static extern BOOL PatBlt([In]HDC hdc, [In]int x, [In]int y, [In]int w, [In]int h, [In]RasterCodes rop);

        /// <summary>
        /// <para>
        /// The <see cref="SetBitmapBits"/> function sets the bits of color data for a bitmap to the specified values.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setbitmapbits
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetBitmapBits", SetLastError = true)]
        public static extern LONG SetBitmapBits([In]HBITMAP hbm, [In]DWORD cb, [In]IntPtr pvBits);

        /// <summary>
        /// <para>
        /// The <see cref="SetBitmapDimensionEx"/> function assigns preferred dimensions to a bitmap.
        /// These dimensions can be used by applications; however, they are not used by the system.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setbitmapdimensionex
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetBitmapDimensionEx", SetLastError = true)]
        public static extern BOOL SetBitmapDimensionEx([In]HBITMAP hbm, [In]int w, [In]int h, [Out]out SIZE lpsz);

        /// <summary>
        /// <para>
        /// The <see cref="SetDIBits"/> function sets the pixels in a compatible bitmap (DDB) using the color data found in the specified DIB.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setdibits
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
        /// The format of the bitmap values depends on the <see cref="BITMAPINFO.biBitCount"/> member of the <see cref="BITMAPINFO"/> structure
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
        /// If the bitmap specified by <paramref name="lpbmi"/> has a <see cref="BITMAPV4HEADER"/> that specifies the gamma and endpoints members,
        /// or a <see cref="BITMAPV5HEADER"/> that specifies either the <see cref="gamma"/> and <see cref="endpoints"/> members
        /// or the <see cref="profileData"/> and <see cref="profileSize"/> members,
        /// then the call treats the bitmap's pixels as being expressed in the color space described by those members,
        /// rather than in the device context's source color space.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetDIBits", SetLastError = true)]
        public static extern int SetDIBits([In]HDC hdc, [In]HBITMAP hbm, [In]UINT start, [In]UINT cLines, [In]IntPtr lpBits,
            [MarshalAs(UnmanagedType.LPStruct)][In]BITMAPINFO lpbmi, [In]UINT ColorUse);

        /// <summary>
        /// <para>
        /// The <see cref="SetPixel"/> function sets the pixel at the specified coordinates to the specified color.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setpixel
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetPixel", SetLastError = true)]
        public static extern COLORREF SetPixel([In]HDC hdc, [In]int x, [In]int y, [In]COLORREF color);

        /// <summary>
        /// <para>
        /// The <see cref="SetROP2"/> function sets the current foreground mix mode.
        /// GDI uses the foreground mix mode to combine pens and interiors of filled objects with the colors already on the screen.
        /// The foreground mix mode defines how colors from the brush or pen and the colors in the existing image are to be combined.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setrop2
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetROP2", SetLastError = true)]
        public static extern int SetROP2([In]HDC hdc, [In]RasterOps rop2);

        /// <summary>
        /// <para>
        /// The <see cref="SetStretchBltMode"/> function sets the bitmap stretching mode in the specified device context.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setstretchbltmode
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetStretchBltMode", SetLastError = true)]
        public static extern int SetStretchBltMode([In]HDC hdc, [In]StretchBltModes mode);

        /// <summary>
        /// <para>
        /// The <see cref="StretchBlt"/> function copies a bitmap from a source rectangle into a destination rectangle,
        /// stretching or compressing the bitmap to fit the dimensions of the destination rectangle, if necessary.
        /// The system stretches or compresses the bitmap according to the stretching mode currently set in the destination device context.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-stretchblt
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "StretchBlt", SetLastError = true)]
        public static extern BOOL StretchBlt([In]HDC hdcDest, [In]int xDest, [In]int yDest, [In]int wDest, [In]int hDest, [In]HDC hdcSrc,
            [In]int xSrc, [In]int ySrc, [In]int wSrc, [In]int hSrc, [In]RasterCodes rop);

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
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-stretchdibits
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
        /// The <see cref="iUsage"/> parameter must be one of the following values.
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
        /// To ensure proper metafile spooling while printing, applications must call the <see cref="CHECKJPEGFORMAT"/> or <see cref="CHECKPNGFORMAT"/> escape
        /// to verify that the printer recognizes the JPEG or PNG image, respectively, before calling <see cref="StretchDIBits"/>.
        /// ICM: Color management is performed if color management has been enabled with a call to <see cref="SetICMMode"/>
        /// with the iEnableICM parameter set to <see cref="ICM_ON"/>.
        /// If the bitmap specified by <paramref name="lpbmi"/> has a <see cref="BITMAPV4HEADER"/> that specifies the gamma and endpoints members,
        /// or a <see cref="BITMAPV5HEADER"/> that specifies either the <see cref="gamma"/> and <see cref="endpoints"/> members
        /// or the <see cref="profileData"/> and <see cref="profileSize"/> members,
        /// then the call treats the bitmap's pixels as being expressed in the color space described by those members,
        /// rather than in the device context's source color space.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "StretchDIBits", SetLastError = true)]
        public static extern int StretchDIBits([In]HDC hdc, [In]int xDest, [In]int yDest, [In]int DestWidth, [In]int DestHeight, [In]int xSrc,
            [In]int ySrc, [In]int SrcWidth, [In]int SrcHeight, [In]IntPtr lpBits, [MarshalAs(UnmanagedType.LPStruct)][In]BITMAPINFO lpbmi,
            [In]UINT iUsage, [In]RasterCodes rop);
    }
}
