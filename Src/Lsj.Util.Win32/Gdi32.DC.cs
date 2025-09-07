using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.COLORREF;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.BitmapCompressions;
using static Lsj.Util.Win32.Enums.CombineRgnModes;
using static Lsj.Util.Win32.Enums.DeviceCapIndexes;
using static Lsj.Util.Win32.Enums.DIBColorTableUsages;
using static Lsj.Util.Win32.Enums.EscapeFunctions;
using static Lsj.Util.Win32.Enums.ICMModes;
using static Lsj.Util.Win32.Enums.RasterCapabilities;
using static Lsj.Util.Win32.Enums.RasterCodes;
using static Lsj.Util.Win32.Enums.RasterOps;
using static Lsj.Util.Win32.Enums.RegionFlags;
using static Lsj.Util.Win32.Enums.StretchBltModes;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Msimg32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32
{
    public static partial class Gdi32
    {
        /// <summary>
        /// <para>
        /// The <see cref="BitBlt"/> function performs a bit-block transfer of the color data corresponding to
        /// a rectangle of pixels from the specified source device context into a destination device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-bitblt"/>
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
        /// <para>
        /// A raster-operation code.
        /// These codes define how the color data for the source rectangle is to be combined
        /// with the color data for the destination rectangle to achieve the final color.
        /// </para>
        /// <para>
        /// The following list shows some common raster operation codes.
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
        /// <see cref="BLACKNESS"/>
        /// </term>
        /// <term>
        /// Fills the destination rectangle using the color associated with index 0 in the physical palette.
        /// (This color is black for the default physical palette.)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CAPTUREBLT"/>
        /// </term>
        /// <term>
        /// Includes any windows that are layered on top of your window in the resulting image.
        /// By default, the image only contains your window.
        /// Note that this generally cannot be used for printing device contexts.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DSTINVERT"/>
        /// </term>
        /// <term>
        /// Inverts the destination rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MERGECOPY"/>
        /// </term>
        /// <term>
        /// Merges the colors of the source rectangle with the brush
        /// currently selected in <paramref name="hdc"/>, by using the Boolean AND operator.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MERGEPAINT"/>
        /// </term>
        /// <term>
        /// Merges the colors of the inverted source rectangle
        /// with the colors of the destination rectangle by using the Boolean OR operator.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="NOMIRRORBITMAP"/>
        /// </term>
        /// <term>
        /// Prevents the bitmap from being mirrored.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="NOTSRCCOPY"/>
        /// </term>
        /// <term>
        /// Copies the inverted source rectangle to the destination.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="NOTSRCERASE"/>
        /// </term>
        /// <term>
        /// Combines the colors of the source and destination rectangles
        /// by using the Boolean OR operator and then inverts the resultant color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PATCOPY"/>
        /// </term>
        /// <term>
        /// Copies the brush currently selected in <paramref name="hdc"/>, into the destination bitmap.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PATINVERT"/>
        /// </term>
        /// <term>
        /// Combines the colors of the brush currently selected in <paramref name="hdc"/>,
        /// with the colors of the destination rectangle by using the Boolean XOR operator.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PATPAINT"/>
        /// </term>
        /// <term>
        /// Combines the colors of the brush currently selected in <paramref name="hdc"/>,
        /// with the colors of the inverted source rectangle by using the Boolean OR operator.
        /// The result of this operation is combined with the colors
        /// of the destination rectangle by using the Boolean OR operator.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SRCAND"/>
        /// </term>
        /// <term>
        /// Combines the colors of the source and destination rectangles by using the Boolean AND operator.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SRCCOPY"/>
        /// </term>
        /// <term>
        /// Copies the source rectangle directly to the destination rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SRCERASE"/>
        /// </term>
        /// <term>
        /// Combines the inverted colors of the destination rectangle
        /// with the colors of the source rectangle by using the Boolean AND operator.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SRCINVERT"/>
        /// </term>
        /// <term>
        /// Combines the colors of the source and destination rectangles by using the Boolean XOR operator.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SRCPAINT"/>
        /// </term>
        /// <term>
        /// Combines the colors of the source and destination rectangles by using the Boolean OR operator.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WHITENESS"/>
        /// </term>
        /// <term>
        /// Fills the destination rectangle using the color associated with index 1 in the physical palette.
        /// (This color is white for the default physical palette.)
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
        /// <see cref="BitBlt"/> only does clipping on the destination DC.
        /// </para>
        /// <para>
        /// If a rotation or shear transformation is in effect in the source device context,
        /// <see cref="BitBlt"/> returns an error.
        /// If other transformations exist in the source device context
        /// (and a matching transformation is not in effect in the destination device context),
        /// the rectangle in the destination device context is stretched, compressed, or rotated, as necessary.
        /// </para>
        /// <para>
        /// If the color formats of the source and destination device contexts do not match,
        /// the <see cref="BitBlt"/> function converts the source color format to match the destination format.
        /// </para>
        /// <para>
        /// When an enhanced metafile is being recorded,
        /// an error occurs if the source device context identifies an enhanced-metafile device context.
        /// </para>
        /// <para>
        /// Not all devices support the <see cref="BitBlt"/> function.
        /// For more information, see the <see cref="RC_BITBLT"/> raster capability entry
        /// in the <see cref="GetDeviceCaps"/> function as well as the following functions:
        /// <see cref="MaskBlt"/>, <see cref="PlgBlt"/>, and <see cref="StretchBlt"/>.
        /// </para>
        /// <para>
        /// <see cref="BitBlt"/> returns an error if the source and destination device contexts represent different devices.
        /// To transfer data between DCs for different devices,
        /// convert the memory bitmap to a DIB by calling <see cref="GetDIBits"/>.
        /// To display the DIB to the second device, call <see cref="SetDIBits"/> or <see cref="StretchDIBits"/>.
        /// </para>
        /// <para>
        /// ICM: No color management is performed when blits occur.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "BitBlt", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL BitBlt([In] HDC hdc, [In] int x, [In] int y, [In] int cx, [In] int cy, [In] HDC hdcSrc,
            [In] int x1, [In] int y1, [In] RasterCodes rop);

        /// <summary>
        /// <para>
        /// The <see cref="ExcludeClipRect"/> function creates a new clipping region
        /// that consists of the existing clipping region minus the specified rectangle.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-excludecliprect"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="left">
        /// The x-coordinate, in logical units, of the upper-left corner of the rectangle.
        /// </param>
        /// <param name="top">
        /// The y-coordinate, in logical units, of the upper-left corner of the rectangle.
        /// </param>
        /// <param name="right">
        /// The x-coordinate, in logical units, of the lower-right corner of the rectangle.
        /// </param>
        /// <param name="bottom">
        /// The y-coordinate, in logical units, of the lower-right corner of the rectangle.
        /// </param>
        /// <returns>
        /// <para>
        /// The return value specifies the new clipping region's complexity;
        /// it can be one of the following values.
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
        /// <see cref="NULLREGION"/>
        /// </term>
        /// <term>
        /// Region is empty.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SIMPLEREGION"/>
        /// </term>
        /// <term>
        /// Region is a single rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="COMPLEXREGION"/>
        /// </term>
        /// <term>
        /// Region is more than one rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR"/>
        /// </term>
        /// <term>
        /// No region was created.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// The lower and right edges of the specified rectangle are not excluded from the clipping region.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ExcludeClipRect", ExactSpelling = true, SetLastError = true)]
        public static extern RegionFlags ExcludeClipRect([In] HDC hdc, [In] int left, [In] int top, [In] int right, [In] int bottom);

        /// <summary>
        /// <para>
        /// The <see cref="ExtSelectClipRgn"/> function combines the specified region
        /// with the current clipping region using the specified mode.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-extselectcliprgn"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="hrgn">
        /// A handle to the region to be selected. 
        /// This handle must not be <see cref="NULL"/> unless the <see cref="RGN_COPY"/> mode is specified.
        /// </param>
        /// <param name="mode">
        /// <para>
        /// The operation to be performed.
        /// It must be one of the following values.
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
        /// <see cref="RGN_AND"/>
        /// </term>
        /// <term>
        /// The new clipping region combines the overlapping areas of the current clipping region and the region identified by <paramref name="hrgn"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RGN_COPY"/>
        /// </term>
        /// <term>
        /// The new clipping region is a copy of the region identified by <paramref name="hrgn"/>.
        /// This is identical to <see cref="SelectClipRgn"/>.
        /// If the region identified by <paramref name="hrgn"/> is <see cref="NULL"/>,
        /// the new clipping region is the default clipping region (the default clipping region is a null region).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RGN_DIFF"/>
        /// </term>
        /// <term>
        /// The new clipping region combines the areas of the current clipping region
        /// with those areas excluded from the region identified by <paramref name="hrgn"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RGN_OR"/>
        /// </term>
        /// <term>
        /// The new clipping region combines the current clipping region
        /// and the region identified by <paramref name="hrgn"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RGN_XOR"/>
        /// </term>
        /// <term>
        /// The new clipping region combines the current clipping region
        /// and the region identified by <paramref name="hrgn"/> but excludes any overlapping areas.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// The return value specifies the new clipping region's complexity;
        /// it can be one of the following values.
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
        /// <see cref="NULLREGION"/>
        /// </term>
        /// <term>
        /// Region is empty.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SIMPLEREGION"/>
        /// </term>
        /// <term>
        /// Region is a single rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="COMPLEXREGION"/>
        /// </term>
        /// <term>
        /// Region is more than one rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR"/>
        /// </term>
        /// <term>
        /// An error occurred.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If an error occurs when this function is called, the previous clipping region for the specified device context is not affected.
        /// </para>
        /// <para>
        /// The <see cref="ExtSelectClipRgn"/> function assumes that the coordinates for the specified region are specified in device units.
        /// </para>
        /// <para>
        /// Only a copy of the region identified by the <paramref name="hrgn"/> parameter is used.
        /// The region itself can be reused after this call or it can be deleted.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ExtSelectClipRgn", ExactSpelling = true, SetLastError = true)]
        public static extern RegionFlags ExtSelectClipRgn([In] HDC hdc, [In] HRGN hrgn, [In] CombineRgnModes mode);

        /// <summary>
        /// <para>
        /// The <see cref="GdiAlphaBlend"/> function displays bitmaps that have transparent or semitransparent pixels.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gdialphablend"/>
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
        /// <para>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// This function can return the following value.
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
        /// <see cref="ERROR_INVALID_PARAMETER"/>
        /// </term>
        /// <term>
        /// One or more of the input parameters is invalid.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This function is the same as <see cref="AlphaBlend"/>.
        /// </para>
        /// <para>
        /// If the source rectangle and destination rectangle are not the same size,
        /// the source bitmap is stretched to match the destination rectangle.
        /// If the <see cref="SetStretchBltMode"/> function is used,
        /// the iStretchMode value is automatically converted to <see cref="COLORONCOLOR"/> for this function
        /// (that is, <see cref="BLACKONWHITE"/>, <see cref="WHITEONBLACK"/>,
        /// and <see cref="HALFTONE"/> are changed to <see cref="COLORONCOLOR"/>).
        /// </para>
        /// <para>
        /// The destination coordinates are transformed
        /// by using the transformation currently specified for the destination device context.
        /// The source coordinates are transformed
        /// by using the transformation currently specified for the source device context.
        /// </para>
        /// <para>
        /// An error occurs (and the function returns <see cref="FALSE"/>) 
        /// if the source device context identifies an enhanced metafile device context.
        /// </para>
        /// <para>
        /// If destination and source bitmaps do not have the same color format,
        /// <see cref="GdiAlphaBlend"/> converts the source bitmap to match the destination bitmap.
        /// </para>
        /// <para>
        /// <see cref="GdiAlphaBlend"/> does not support mirroring.
        /// If either the width or height of the source or destination is negative, this call will fail.
        /// </para>
        /// <para>
        /// When rendering to a printer, first call <see cref="GetDeviceCaps"/> with <see cref="SHADEBLENDCAPS"/>
        /// to determine if the printer supports blending with <see cref="GdiAlphaBlend"/>.
        /// Note that, for a display DC, all blending operations are supported
        /// and these flags represent whether the operations are accelerated.
        /// </para>
        /// <para>
        /// If the source and destination are the same surface, that is,
        /// they are both the screen or the same memory bitmap and the source and destination rectangles overlap,
        /// an error occurs and the function returns <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// The source rectangle must lie completely within the source surface,
        /// otherwise an error occurs and the function returns <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// <see cref="GdiAlphaBlend"/> fails if the width or height of the source or destination is negative.
        /// </para>
        /// <para>
        /// The <see cref="BLENDFUNCTION.SourceConstantAlpha"/> member of <see cref="BLENDFUNCTION"/>
        /// specifies an alpha transparency value to be used on the entire source bitmap.
        /// The <see cref="BLENDFUNCTION.SourceConstantAlpha"/> value is combined with any per-pixel alpha values.
        /// If <see cref="BLENDFUNCTION.SourceConstantAlpha"/> is 0, it is assumed that the image is transparent.
        /// Set the <see cref="BLENDFUNCTION.SourceConstantAlpha"/> value to 255
        /// (which indicates that the image is opaque) when you only want to use per-pixel alpha values.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GdiAlphaBlend", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GdiAlphaBlend([In] HDC hdcDest, [In] int xoriginDest, [In] int yoriginDest, [In] int wDest,
            [In] int hDest, [In] HDC hdcSrc, [In] int xoriginSrc, [In] int yoriginSrc, [In] int wSrc, [In] int hSrc, [In] BLENDFUNCTION ftn);

        /// <summary>
        /// <para>
        /// The <see cref="GdiTransparentBlt"/> function performs a bit-block transfer of the color data
        /// corresponding to a rectangle of pixels from the specified source device context into a destination device context.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This function is the same as <see cref="TransparentBlt"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gditransparentblt"/>
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
        /// The x-coordinate, in logical units, of the source rectangle.
        /// </param>
        /// <param name="yoriginSrc">
        /// The y-coordinate, in logical units, of the source rectangle.
        /// </param>
        /// <param name="wSrc">
        /// The width, in logical units, of the source rectangle.
        /// </param>
        /// <param name="hSrc">
        /// The height, in logical units, of the source rectangle.
        /// </param>
        /// <param name="crTransparent">
        /// The RGB color in the source bitmap to treat as transparent.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="GdiTransparentBlt"/> function works with compatible bitmaps (DDBs).
        /// </para>
        /// <para>
        /// The <see cref="GdiTransparentBlt"/> function supports all formats of source bitmaps.
        /// However, for 32 bpp bitmaps, it just copies the alpha value over.
        /// Use <see cref="AlphaBlend"/> to specify 32 bits-per-pixel bitmaps with transparency.
        /// </para>
        /// <para>
        /// If the source and destination rectangles are not the same size,
        /// the source bitmap is stretched to match the destination rectangle.
        /// When the <see cref="SetStretchBltMode"/> function is used,
        /// the iStretchMode modes of <see cref="BLACKONWHITE"/> and <see cref="WHITEONBLACK"/>
        /// are converted to <see cref="COLORONCOLOR"/> for the <see cref="GdiTransparentBlt"/> function.
        /// </para>
        /// <para>
        /// The destination device context specifies the transformation type for the destination coordinates.
        /// The source device context specifies the transformation type for the source coordinates.
        /// </para>
        /// <para>
        /// <see cref="GdiTransparentBlt"/> does not mirror a bitmap
        /// if either the width or height, of either the source or destination, is negative.
        /// </para>
        /// <para>
        /// When used in a multiple monitor system,
        /// both <paramref name="hdcSrc"/> and <paramref name="hdcDest"/> must refer to the same device or the function will fail.
        /// To transfer data between DCs for different devices,
        /// convert the memory bitmap to a DIB by calling <see cref="GetDIBits"/>.
        /// To display the DIB to the second device, call <see cref="SetDIBits"/> or <see cref="StretchDIBits"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GdiTransparentBlt", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GdiTransparentBlt([In] HDC hdcDest, [In] int xoriginDest, [In] int yoriginDest, [In] int wDest,
            [In] int hDest, [In] HDC hdcSrc, [In] int xoriginSrc, [In] int yoriginSrc, [In] int wSrc, [In] int hSrc, [In] UINT crTransparent);

        /// <summary>
        /// <para>
        /// The <see cref="GetClipBox"/> function retrieves the dimensions of the tightest bounding rectangle that can be drawn
        /// around the current visible area on the device.
        /// The visible area is defined by the current clipping region or clip path, as well as any overlapping windows.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getclipbox"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lprect">
        /// A pointer to a <see cref="RECT"/> structure that is to receive the rectangle dimensions, in logical units.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value specifies the clipping box's complexity and can be one of the following values.
        /// </para>
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
        /// <see cref="NULLREGION"/>
        /// </term>
        /// <term>
        /// Region is empty.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SIMPLEREGION"/>
        /// </term>
        /// <term>
        /// Region is a single rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="COMPLEXREGION"/>
        /// </term>
        /// <term>
        /// Region is more than one rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR"/>
        /// </term>
        /// <term>
        /// An error occurred.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// <see cref="GetClipBox"/> returns logical coordinates based on the given device context.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetClipBox", ExactSpelling = true, SetLastError = true)]
        public static extern RegionFlags GetClipBox([In] HDC hdc, [Out] out RECT lprect);

        /// <summary>
        /// <para>
        /// The <see cref="GetClipRgn"/> function retrieves a handle identifying
        /// the current application-defined clipping region for the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getcliprgn"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="hrgn">
        /// A handle to an existing region before the function is called.
        /// After the function returns, this parameter is a handle to a copy of the current clipping region.
        /// </param>
        /// <returns>
        /// If the function succeeds and there is no clipping region for the given device context, the return value is zero.
        /// If the function succeeds and there is a clipping region for the given device context, the return value is 1.
        /// If an error occurs, the return value is -1.
        /// </returns>
        /// <remarks>
        /// <para>
        /// An application-defined clipping region is a clipping region identified by the <see cref="SelectClipRgn"/> function.
        /// It is not a clipping region created when the application calls the <see cref="BeginPaint"/> function.
        /// </para>
        /// <para>
        /// If the function succeeds, the <paramref name="hrgn"/> parameter is a handle to a copy of the current clipping region.
        /// Subsequent changes to this copy will not affect the current clipping region.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetClipRgn", ExactSpelling = true, SetLastError = true)]
        public static extern int GetClipRgn([In] HDC hdc, [In] HRGN hrgn);

        /// <summary>
        /// <para>
        /// The <see cref="GetDCBrushColor"/> function retrieves the current brush color for the specified device context (DC).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getdcbrushcolor"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the DC whose brush color is to be returned.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the <see cref="COLORREF"/> value for the current DC brush color.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="CLR_INVALID"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// For information on setting the brush color, see <see cref="SetDCBrushColor"/>.
        /// </para>
        /// <para>
        /// ICM: Color management is performed if ICM is enabled.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDCBrushColor", ExactSpelling = true, SetLastError = true)]
        public static extern COLORREF GetDCBrushColor([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="GetPixel"/> function retrieves the red, green, blue (RGB) color value of the pixel at the specified coordinates.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getpixel"/>
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
        /// If the pixel is outside of the current clipping region,
        /// the return value is <see cref="CLR_INVALID"/> (0xFFFFFFFF defined in Wingdi.h).
        /// </returns>
        /// <remarks>
        /// <para>
        /// The pixel must be within the boundaries of the current clipping region.
        /// </para>
        /// <para>
        /// Not all devices support <see cref="GetPixel"/>.
        /// An application should call <see cref="GetDeviceCaps"/> to determine whether a specified device supports this function.
        /// </para>
        /// <para>
        /// A bitmap must be selected within the device context,
        /// otherwise, <see cref="CLR_INVALID"/> is returned on all pixels.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPixel", ExactSpelling = true, SetLastError = true)]
        public static extern COLORREF GetPixel([In] HDC hdc, [In] int x, [In] int y);

        /// <summary>
        /// <para>
        /// The <see cref="GetROP2"/> function retrieves the foreground mix mode of the specified device context.
        /// The mix mode specifies how the pen or interior color and the color already on the screen are combined to yield a new color.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getrop2"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to the device context.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value specifies the foreground mix mode.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Following are the foreground mix modes.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Mix mode
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="R2_BLACK"/>
        /// </term>
        /// <term>
        /// Pixel is always 0.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_COPYPEN"/>
        /// </term>
        /// <term>
        /// Pixel is the pen color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_MASKNOTPEN"/>
        /// </term>
        /// <term>
        /// Pixel is a combination of the colors common to both the screen and the inverse of the pen.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_MASKPEN"/>
        /// </term>
        /// <term>
        /// Pixel is a combination of the colors common to both the pen and the screen.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_MASKPENNOT"/>
        /// </term>
        /// <term>
        /// Pixel is a combination of the colors common to both the pen and the inverse of the screen.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_MERGENOTPEN"/>
        /// </term>
        /// <term>
        /// Pixel is a combination of the screen color and the inverse of the pen color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_MERGEPEN"/>
        /// </term>
        /// <term>
        /// Pixel is a combination of the pen color and the screen color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_MERGEPENNOT"/>
        /// </term>
        /// <term>
        /// Pixel is a combination of the pen color and the inverse of the screen color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_NOP"/>
        /// </term>
        /// <term>
        /// Pixel remains unchanged.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_NOT"/>
        /// </term>
        /// <term>
        /// Pixel is the inverse of the screen color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_NOTCOPYPEN"/>
        /// </term>
        /// <term>
        /// Pixel is the inverse of the pen color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_NOTMASKPEN"/>
        /// </term>
        /// <term>
        /// Pixel is the inverse of the <see cref="R2_MASKPEN"/> color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_NOTMERGEPEN"/>
        /// </term>
        /// <term>
        /// Pixel is the inverse of the <see cref="R2_MERGEPEN"/> color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_NOTXORPEN"/>
        /// </term>
        /// <term>
        /// Pixel is the inverse of the <see cref="R2_XORPEN"/> color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_WHITE"/>
        /// </term>
        /// <term>
        /// Pixel is always 1.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_XORPEN"/>
        /// </term>
        /// <term>
        /// Pixel is a combination of the colors in the pen and in the screen, but not in both.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetROP2", ExactSpelling = true, SetLastError = true)]
        public static extern RasterOps GetROP2([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="GetStretchBltMode"/> function retrieves the current stretching mode.
        /// The stretching mode defines how color data is added to or removed from bitmaps that are stretched or compressed
        /// when the <see cref="StretchBlt"/> function is called.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getstretchbltmode"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the current stretching mode.
        /// This can be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="BLACKONWHITE"/>
        /// </term>
        /// <term>
        /// Performs a Boolean AND operation using the color values for the eliminated and existing pixels.
        /// If the bitmap is a monochrome bitmap, this mode preserves black pixels at the expense of white pixels.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="COLORONCOLOR"/>
        /// </term>
        /// <term>
        /// Deletes the pixels.
        /// This mode deletes all eliminated lines of pixels without trying to preserve their information.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HALFTONE"/>
        /// </term>
        /// <term>
        /// Maps pixels from the source rectangle into blocks of pixels in the destination rectangle.
        /// The average color over the destination block of pixels approximates the color of the source pixels.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="STRETCH_ANDSCANS"/>
        /// </term>
        /// <term>
        /// Same as <see cref="BLACKONWHITE"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="STRETCH_DELETESCANS"/>
        /// </term>
        /// <term>
        /// Same as <see cref="COLORONCOLOR"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="STRETCH_HALFTONE"/>
        /// </term>
        /// <term>
        /// Same as <see cref="HALFTONE"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="STRETCH_ORSCANS"/>
        /// </term>
        /// <term>
        /// Same as <see cref="WHITEONBLACK"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WHITEONBLACK"/>
        /// </term>
        /// <term>
        /// Performs a Boolean OR operation using the color values for the eliminated and existing pixels.
        /// If the bitmap is a monochrome bitmap, this mode preserves white pixels at the expense of black pixels.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetStretchBltMode", ExactSpelling = true, SetLastError = true)]
        public static extern StretchBltModes GetStretchBltMode([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="IntersectClipRect"/> function creates a new clipping region from the intersection of the current clipping region
        /// and the specified rectangle.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-intersectcliprect"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="left">
        /// The x-coordinate, in logical units, of the upper-left corner of the rectangle.
        /// </param>
        /// <param name="top">
        /// The y-coordinate, in logical units, of the upper-left corner of the rectangle.
        /// </param>
        /// <param name="right">
        /// The x-coordinate, in logical units, of the lower-right corner of the rectangle.
        /// </param>
        /// <param name="bottom">
        /// The y-coordinate, in logical units, of the lower-right corner of the rectangle.
        /// </param>
        /// <returns>
        /// <para>
        /// The return value specifies the new clipping region's type and can be one of the following values.
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
        /// <see cref="NULLREGION"/>
        /// </term>
        /// <term>
        /// Region is empty.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SIMPLEREGION"/>
        /// </term>
        /// <term>
        /// Region is a single rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="COMPLEXREGION"/>
        /// </term>
        /// <term>
        /// Region is more than one rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR"/>
        /// </term>
        /// <term>
        /// An error occurred. (The current clipping region is unaffected.)
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The lower and right-most edges of the given rectangle are excluded from the clipping region.
        /// </para>
        /// <para>
        /// If a clipping region does not already exist then the system may apply a default clipping region to the specified <see cref="HDC"/>.
        /// A clipping region is then created from the intersection of that default clipping region
        /// and the rectangle specified in the function parameters.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "IntersectClipRect", ExactSpelling = true, SetLastError = true)]
        public static extern RegionFlags IntersectClipRect([In] HDC hdc, [In] int left, [In] int top, [In] int right, [In] int bottom);

        /// <summary>
        /// <para>
        /// The <see cref="MaskBlt"/> function combines the color data for the source and destination bitmaps
        /// using the specified mask and raster operation.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-maskblt"/>
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
        /// It must be zero if the <paramref name="rop"/> parameter specifies a raster operation that does not include a source.
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
        /// <para>
        /// The foreground and background ternary raster operation codes (ROPs) that the function uses
        /// to control the combination of source and destination data.
        /// The background raster operation code is stored in the high-order byte of the high-order word of this value;
        /// the foreground raster operation code is stored in the low-order byte of the high-order word of this value;
        /// the low-order word of this value is ignored, and should be zero.
        /// The macro <see cref="MAKEROP4"/> creates such combinations of foreground and background raster operation codes.
        /// </para>
        /// <para>
        /// For a discussion of foreground and background in the context of this function, see the following Remarks section.
        /// </para>
        /// <para>
        /// For a list of common raster operation codes (ROPs), see the <see cref="BitBlt"/> function.
        /// Note that the <see cref="CAPTUREBLT"/> ROP generally cannot be used for printing device contexts.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="MaskBlt"/> function uses device-dependent bitmaps.
        /// </para>
        /// <para>
        /// A value of 1 in the mask specified by <paramref name="hbmMask"/> indicates that
        /// the foreground raster operation code specified by <paramref name="rop"/> should be applied at that location.
        /// A value of 0 in the mask indicates that the background raster operation code
        /// specified by <paramref name="rop"/> should be applied at that location.
        /// </para>
        /// <para>
        /// If the raster operations require a source, the mask rectangle must cover the source rectangle.
        /// If it does not, the function will fail.
        /// If the raster operations do not require a source, the mask rectangle must cover the destination rectangle.
        /// If it does not, the function will fail.
        /// </para>
        /// <para>
        /// If a rotation or shear transformation is in effect for the source device context
        /// when this function is called, an error occurs.
        /// However, other types of transformation are allowed.
        /// </para>
        /// <para>
        /// If the color formats of the source, pattern, and destination bitmaps differ,
        /// this function converts the pattern or source format, or both, to match the destination format.
        /// </para>
        /// <para>
        /// If the mask bitmap is not a monochrome bitmap, an error occurs.
        /// </para>
        /// <para>
        /// When an enhanced metafile is being recorded, an error occurs (and the function returns <see cref="FALSE"/>)
        /// if the source device context identifies an enhanced-metafile device context.
        /// </para>
        /// <para>
        /// Not all devices support the <see cref="MaskBlt"/> function.
        /// An application should call the <see cref="GetDeviceCaps"/> function with the nIndex parameter
        /// as <see cref="RC_BITBLT"/> to determine whether a device supports this function.
        /// </para>
        /// <para>
        /// If no mask bitmap is supplied, this function behaves exactly like <see cref="BitBlt"/>, using the foreground raster operation code.
        /// </para>
        /// <para>
        /// ICM: No color management is performed when blits occur.
        /// </para>
        /// <para>
        /// When used in a multiple monitor system, both <paramref name="hdcSrc"/> and <paramref name="hdcDest"/>
        /// must refer to the same device or the function will fail.
        /// To transfer data between DCs for different devices,
        /// convert the memory bitmap (compatible bitmap, or DDB) to a DIB by calling <see cref="GetDIBits"/>.
        /// To display the DIB to the second device, call <see cref="SetDIBits"/> or <see cref="StretchDIBits"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "MaskBlt", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL MaskBlt([In] HDC hdcDest, [In] int xDest, [In] int yDest, [In] int width, [In] int height, [In] HDC hdcSrc,
            [In] int xSrc, [In] int ySrc, [In] HBITMAP hbmMask, [In] int xMask, [In] int yMask, [In] RasterCodes rop);

        /// <summary>
        /// <para>
        /// The <see cref="OffsetClipRgn"/> function moves the clipping region of a device context by the specified offsets.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-offsetcliprgn"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="x">
        /// The number of logical units to move left or right.
        /// </param>
        /// <param name="y">
        /// The number of logical units to move up or down.
        /// </param>
        /// <returns>
        /// <para>
        /// The return value specifies the new region's complexity and can be one of the following values.
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
        /// <see cref="NULLREGION"/>
        /// </term>
        /// <term>
        /// Region is empty.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SIMPLEREGION"/>
        /// </term>
        /// <term>
        /// Region is a single rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="COMPLEXREGION"/>
        /// </term>
        /// <term>
        /// Region is more than one rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR"/>
        /// </term>
        /// <term>
        /// An error occurred. (The current clipping region is unaffected.)
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "OffsetClipRgn", ExactSpelling = true, SetLastError = true)]
        public static extern RegionFlags OffsetClipRgn([In] HDC hdc, [In] int x, [In] int y);

        /// <summary>
        /// <para>
        /// The <see cref="PatBlt"/> function paints the specified rectangle
        /// using the brush that is currently selected into the specified device context.
        /// The brush color and the surface color or colors are combined by using the specified raster operation.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-patblt"/>
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
        /// <para>
        /// The raster operation code. This code can be one of the following values.
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
        /// <see cref="PATCOPY"/>
        /// </term>
        /// <term>
        /// Copies the specified pattern into the destination bitmap.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PATINVERT"/>
        /// </term>
        /// <term>
        /// Combines the colors of the specified pattern with the colors of the destination rectangle by using the Boolean XOR operator.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DSTINVERT"/>
        /// </term>
        /// <term>
        /// Inverts the destination rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BLACKNESS"/>
        /// </term>
        /// <term>
        /// Fills the destination rectangle using the color associated with index 0 in the physical palette.
        /// (This color is black for the default physical palette.)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WHITENESS"/>
        /// </term>
        /// <term>
        /// Fills the destination rectangle using the color associated with index 1 in the physical palette.
        /// (This color is white for the default physical palette.)
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
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The values of the <paramref name="rop"/> parameter for this function
        /// are a limited subset of the full 256 ternary raster-operation codes;
        /// in particular, an operation code that refers to a source rectangle cannot be used.
        /// </para>
        /// <para>
        /// Not all devices support the <see cref="PatBlt"/> function.
        /// For more information, see the description of the <see cref="RC_BITBLT"/> capability in the <see cref="GetDeviceCaps"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "PatBlt", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL PatBlt([In] HDC hdc, [In] int x, [In] int y, [In] int w, [In] int h, [In] RasterCodes rop);

        /// <summary>
        /// <para>
        /// The <see cref="PlgBlt"/> function performs a bit-block transfer of the bits of color data
        /// from the specified rectangle in the source device context
        /// to the specified parallelogram in the destination device context.
        /// If the given bitmask handle identifies a valid monochrome bitmap,
        /// the function uses this bitmap to mask the bits of color data from the source rectangle.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-plgblt"/>
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
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="PlgBlt"/> function works with device-dependent bitmaps.
        /// </para>
        /// <para>
        /// The fourth vertex of the parallelogram (D) is defined
        /// by treating the first three points (A, B, and C ) as vectors and computing D = B +CA.
        /// </para>
        /// <para>
        /// If the bitmask exists, a value of one in the mask indicates that the source pixel color should be copied to the destination.
        /// A value of zero in the mask indicates that the destination pixel color is not to be changed.
        /// If the mask rectangle is smaller than the source and destination rectangles, the function replicates the mask pattern.
        /// </para>
        /// <para>
        /// Scaling, translation, and reflection transformations are allowed in the source device context;
        /// however, rotation and shear transformations are not.
        /// If the mask bitmap is not a monochrome bitmap, an error occurs.
        /// The stretching mode for the destination device context is used to determine
        /// how to stretch or compress the pixels, if that is necessary.
        /// </para>
        /// <para>
        /// When an enhanced metafile is being recorded,
        /// an error occurs if the source device context identifies an enhanced-metafile device context.
        /// </para>
        /// <para>
        /// The destination coordinates are transformed according to the destination device context;
        /// the source coordinates are transformed according to the source device context.
        /// If the source transformation has a rotation or shear, an error is returned.
        /// </para>
        /// <para>
        /// If the destination and source rectangles do not have the same color format,
        /// <see cref="PlgBlt"/> converts the source rectangle to match the destination rectangle.
        /// </para>
        /// <para>
        /// Not all devices support the <see cref="PlgBlt"/> function.
        /// For more information, see the description of the <see cref="RC_BITBLT"/> raster capability
        /// in the <see cref="GetDeviceCaps"/> function.
        /// </para>
        /// <para>
        /// If the source and destination device contexts represent incompatible devices, <see cref="PlgBlt"/> returns an error.
        /// </para>
        /// <para>
        /// When used in a multiple monitor system,
        /// both <paramref name="hdcSrc"/> and <paramref name="hdcDest"/> must refer to the same device or the function will fail.
        /// To transfer data between DCs for different devices,
        /// convert the memory bitmap to a DIB by calling <see cref="GetDIBits"/>.
        /// To display the DIB to the second device, call <see cref="SetDIBits"/> or <see cref="StretchDIBits"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "PlgBlt", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL PlgBlt([In] HDC hdcDest, [In] POINT[] lpPoint, [In] HDC hdcSrc, [In] int xSrc, [In] int ySrc,
            [In] int width, [In] int height, [In] HBITMAP hbmMask, [In] int xMask, [In] int yMask);

        /// <summary>
        /// <para>
        /// The <see cref="PtVisible"/> function determines whether the specified point is within the clipping region of a device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-ptvisible"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="x">
        /// The x-coordinate, in logical units, of the point.
        /// </param>
        /// <param name="y">
        /// The y-coordinate, in logical units, of the point.
        /// </param>
        /// <returns>
        /// <para>
        /// If the specified point is within the clipping region of the device context, the return value is <see cref="TRUE"/>(1).
        /// </para>
        /// <para>
        /// If the specified point is not within the clipping region of the device context, the return value is <see cref="FALSE"/>(0).
        /// </para>
        /// <para>
        /// If the <see cref="HDC"/> is not valid, the return value is (BOOL)-1.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "PtVisible", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL PtVisible([In] HDC hdc, [In] int x, [In] int y);

        /// <summary>
        /// <para>
        /// The <see cref="RectVisible"/> function determines
        /// whether any part of the specified rectangle lies within the clipping region of a device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-rectvisible"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lprect">
        /// A pointer to a <see cref="RECT"/> structure that contains the logical coordinates of the specified rectangle.
        /// </param>
        /// <returns>
        /// <para>
        /// If the current transform does not have a rotation and the rectangle lies within the clipping region,
        /// the return value is <see cref="TRUE"/> (1).
        /// </para>
        /// <para>
        /// If the current transform does not have a rotation and the rectangle does not lie within the clipping region,
        /// the return value is <see cref="FALSE"/> (0).
        /// </para>
        /// <para>
        /// If the current transform has a rotation and the rectangle lies within the clipping region, the return value is 2.
        /// </para>
        /// <para>
        /// If the current transform has a rotation and the rectangle does not lie within the clipping region, the return value is 1.
        /// </para>
        /// <para>
        /// All other return values are considered error codes. If the any parameter is not valid, the return value is undefined.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RectVisible", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL RectVisible([In] HDC hdc, [In] in RECT lprect);

        /// <summary>
        /// <para>
        /// The <see cref="SelectClipPath"/> function selects the current path as a clipping region for a device context,
        /// combining the new region with any existing clipping region using the specified mode.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-selectclippath"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context of the path.
        /// </param>
        /// <param name="mode">
        /// <para>
        /// The way to use the path. This parameter can be one of the following values.
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
        /// <see cref="RGN_AND"/>
        /// </term>
        /// <term>
        /// The new clipping region includes the intersection (overlapping areas) of the current clipping region and the current path.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RGN_COPY"/>
        /// </term>
        /// <term>
        /// The new clipping region is the current path.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RGN_DIFF"/>
        /// </term>
        /// <term>
        /// The new clipping region includes the areas of the current clipping region with those of the current path excluded.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RGN_OR"/>
        /// </term>
        /// <term>
        /// The new clipping region includes the union (combined areas) of the current clipping region and the current path.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RGN_XOR"/>
        /// </term>
        /// <term>
        /// The new clipping region includes the union of the current clipping region and the current path but without the overlapping areas.
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
        /// </para>
        /// </returns>
        /// <remarks>
        /// The device context identified by the <paramref name="hdc"/> parameter must contain a closed path.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SelectClipPath", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SelectClipPath([In] HDC hdc, [In] CombineRgnModes mode);

        /// <summary>
        /// <para>
        /// The <see cref="SelectClipRgn"/> function selects a region as the current clipping region for the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-selectcliprgn"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="hrgn">
        /// A handle to the region to be selected.
        /// </param>
        /// <returns>
        /// <para>
        /// The return value specifies the region's complexity and can be one of the following values.
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
        /// <see cref="NULLREGION"/>
        /// </term>
        /// <term>
        /// Region is empty.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SIMPLEREGION"/>
        /// </term>
        /// <term>
        /// Region is a single rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="COMPLEXREGION"/>
        /// </term>
        /// <term>
        /// Region is more than one rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR"/>
        /// </term>
        /// <term>
        /// An error occurred. (The previous clipping region is unaffected.)
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Only a copy of the selected region is used.
        /// The region itself can be selected for any number of other device contexts or it can be deleted.
        /// </para>
        /// <para>
        /// The <see cref="SelectClipRgn"/> function assumes that the coordinates for a region are specified in device units.
        /// </para>
        /// <para>
        /// To remove a device-context's clipping region, specify a <see cref="NULL"/> region handle.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SelectClipRgn", ExactSpelling = true, SetLastError = true)]
        public static extern RegionFlags SelectClipRgn([In] HDC hdc, [In] HRGN hrgn);

        /// <summary>
        /// <para>
        /// The <see cref="SetDIBitsToDevice"/> function sets the pixels in the specified rectangle on the device
        /// that is associated with the destination device context using color data from a DIB, JPEG, or PNG image.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setdibitstodevice"/>
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
        /// <para>
        /// Indicates whether the <see cref="BITMAPINFO.bmiColors"/> member of the <see cref="BITMAPINFO"/> structure
        /// contains explicit red, green, blue (RGB) values or indexes into a palette.
        /// For more information, see the following Remarks section.
        /// </para>
        /// <para>
        /// The <paramref name="ColorUse"/> parameter must be one of the following values.
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
        /// <see cref="DIB_PAL_COLORS"/>
        /// </term>
        /// <term>
        /// The color table consists of an array of 16-bit indexes into the currently selected logical palette.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DIB_RGB_COLORS"/>
        /// </term>
        /// <term>
        /// The color table contains literal RGB values.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the number of scan lines set.
        /// </para>
        /// <para>
        /// If zero scan lines are set (such as when <paramref name="h"/> is 0) or the function fails, the function returns zero.
        /// </para>
        /// <para>
        /// If the driver cannot support the JPEG or PNG file image passed to <see cref="SetDIBitsToDevice"/>,
        /// the function will fail and return <see cref="GDI_ERROR"/>.
        /// If failure does occur, the application must fall back on its own JPEG or PNG support 
        /// to decompress the image into a bitmap, and then pass the bitmap to <see cref="SetDIBitsToDevice"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Optimal bitmap drawing speed is obtained when the bitmap bits are indexes into the system palette.
        /// </para>
        /// <para>
        /// Applications can retrieve the system palette colors and indexes by calling the <see cref="GetSystemPaletteEntries"/> function.
        /// After the colors and indexes are retrieved, the application can create the DIB.
        /// For more information about the system palette, see Colors.
        /// </para>
        /// <para>
        /// The scan lines must be aligned on a <see cref="DWORD"/> except for RLE-compressed bitmaps.
        /// </para>
        /// <para>
        /// The origin of a bottom-up DIB is the lower-left corner of the bitmap; the origin of a top-down DIB is the upper-left corner.
        /// </para>
        /// <para>
        /// To reduce the amount of memory required to set bits from a large DIB on a device surface,
        /// an application can band the output by repeatedly calling <see cref="SetDIBitsToDevice"/>,
        /// placing a different portion of the bitmap into the <paramref name="lpvBits"/> array each time.
        /// The values of the <paramref name="StartScan"/> and <paramref name="cLines"/> parameters
        /// identify the portion of the bitmap contained in the <paramref name="lpvBits"/> array.
        /// </para>
        /// <para>
        /// The <see cref="SetDIBitsToDevice"/> function returns an error if it is called by a process
        /// that is running in the background while a full-screen MS-DOS session runs in the foreground.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// If the <see cref="BITMAPINFOHEADER.biCompression"/> member of <see cref="BITMAPINFOHEADER"/>
        /// is <see cref="BI_JPEG"/> or <see cref="BI_PNG"/>, <paramref name="lpvBits"/> points to a buffer containing a JPEG or PNG image.
        /// The <see cref="BITMAPINFOHEADER.biSizeImage"/> member of specifies the size of the buffer.
        /// The <paramref name="ColorUse"/> parameter must be set to <see cref="DIB_RGB_COLORS"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// To ensure proper metafile spooling while printing,
        /// applications must call the <see cref="CHECKJPEGFORMAT"/> or <see cref="CHECKPNGFORMAT"/> escape
        /// to verify that the printer recognizes the JPEG or PNG image, respectively, before calling <see cref="SetDIBitsToDevice"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// ICM: Color management is performed if color management has been enabled
        /// with a call to <see cref="SetICMMode"/> with the iEnableICM parameter set to <see cref="ICM_ON"/>.
        /// If the bitmap specified by <paramref name="lpbmi"/> has a <see cref="BITMAPV4HEADER"/> that specifies the gamma and endpoints members,
        /// or a <see cref="BITMAPV5HEADER"/> that specifies either the gamma and endpoints members or the profileData and profileSize members,
        /// then the call treats the bitmap's pixels as being expressed in the color space described by those members,
        /// rather than in the device context's source color space.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetDIBitsToDevice", ExactSpelling = true, SetLastError = true)]
        public static extern int SetDIBitsToDevice([In] HDC hdc, [In] int xDest, [In] int yDest, [In] DWORD w, [In] DWORD h, [In] int xSrc, [In] int ySrc,
            [In] UINT StartScan, [In] UINT cLines, [In] IntPtr lpvBits, [In] in BITMAPINFO lpbmi, [In] UINT ColorUse);

        /// <summary>
        /// <para>
        /// The <see cref="SetPixel"/> function sets the pixel at the specified coordinates to the specified color.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setpixel"/>
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
        /// <para>
        /// If the function succeeds, the return value is the RGB value that the function sets the pixel to.
        /// This value may differ from the color specified by <paramref name="color"/>;
        /// that occurs when an exact match for the specified color cannot be found.
        /// </para>
        /// <para>
        /// If the function fails, the return value is -1.
        /// </para>
        /// <para>
        /// This can be the following value.
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
        /// <see cref="ERROR_INVALID_PARAMETER"/>
        /// </term>
        /// <term>
        /// One or more of the input parameters is invalid.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The function fails if the pixel coordinates lie outside of the current clipping region.
        /// </para>
        /// <para>
        /// Not all devices support the <see cref="SetPixel"/> function.
        /// For more information, see <see cref="GetDeviceCaps"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetPixel", ExactSpelling = true, SetLastError = true)]
        public static extern COLORREF SetPixel([In] HDC hdc, [In] int x, [In] int y, [In] COLORREF color);

        /// <summary>
        /// <para>
        /// The <see cref="SetPixelV"/> function sets the pixel at the specified coordinates to the closest approximation of the specified color.
        /// The point must be in the clipping region and the visible part of the device surface.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setpixelv"/>
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
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Not all devices support the <see cref="SetPixelV"/> function.
        /// For more information, see the description of the <see cref="RC_BITBLT"/> capability in the <see cref="GetDeviceCaps"/> function.
        /// </para>
        /// <para>
        /// <see cref="SetPixelV"/> is faster than <see cref="SetPixel"/>
        /// because it does not need to return the color value of the point actually painted.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetPixelV", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetPixelV([In] HDC hdc, [In] int x, [In] int y, [In] COLORREF color);

        /// <summary>
        /// <para>
        /// The <see cref="SetROP2"/> function sets the current foreground mix mode.
        /// GDI uses the foreground mix mode to combine pens and interiors of filled objects with the colors already on the screen.
        /// The foreground mix mode defines how colors from the brush or pen and the colors in the existing image are to be combined.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setrop2"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="rop2">
        /// <para>
        /// The mix mode. This parameter can be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Mix mode
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="R2_BLACK"/>
        /// </term>
        /// <term>
        /// Pixel is always 0.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_COPYPEN"/>
        /// </term>
        /// <term>
        /// Pixel is the pen color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_MASKNOTPEN"/>
        /// </term>
        /// <term>
        /// Pixel is a combination of the colors common to both the screen and the inverse of the pen.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_MASKPEN"/>
        /// </term>
        /// <term>
        /// Pixel is a combination of the colors common to both the pen and the screen.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_MASKPENNOT"/>
        /// </term>
        /// <term>
        /// Pixel is a combination of the colors common to both the pen and the inverse of the screen.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_MERGENOTPEN"/>
        /// </term>
        /// <term>
        /// Pixel is a combination of the screen color and the inverse of the pen color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_MERGEPEN"/>
        /// </term>
        /// <term>
        /// Pixel is a combination of the pen color and the screen color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_MERGEPENNOT"/>
        /// </term>
        /// <term>
        /// Pixel is a combination of the pen color and the inverse of the screen color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_NOP"/>
        /// </term>
        /// <term>
        /// Pixel remains unchanged.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_NOT"/>
        /// </term>
        /// <term>
        /// Pixel is the inverse of the screen color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_NOTCOPYPEN"/>
        /// </term>
        /// <term>
        /// Pixel is the inverse of the pen color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_NOTMASKPEN"/>
        /// </term>
        /// <term>
        /// Pixel is the inverse of the <see cref="R2_MASKPEN"/> color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_NOTMERGEPEN"/>
        /// </term>
        /// <term>
        /// Pixel is the inverse of the <see cref="R2_MERGEPEN"/> color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_NOTXORPEN"/>
        /// </term>
        /// <term>
        /// Pixel is the inverse of the <see cref="R2_XORPEN"/> color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_WHITE"/>
        /// </term>
        /// <term>
        /// Pixel is always 1.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_XORPEN"/>
        /// </term>
        /// <term>
        /// Pixel is a combination of the colors in the pen and in the screen, but not in both.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value specifies the previous mix mode.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// Mix modes define how GDI combines source and destination colors when drawing with the current pen.
        /// The mix modes are binary raster operation codes, representing all possible Boolean functions of two variables,
        /// using the binary operations AND, OR, and XOR (exclusive OR), and the unary operation NOT.
        /// The mix mode is for raster devices only; it is not available for vector devices.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetROP2", ExactSpelling = true, SetLastError = true)]
        public static extern int SetROP2([In] HDC hdc, [In] RasterOps rop2);

        /// <summary>
        /// <para>
        /// The <see cref="SetStretchBltMode"/> function sets the bitmap stretching mode in the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setstretchbltmode"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="mode">
        /// <para>
        /// The stretching mode. This parameter can be one of the following values.
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
        /// <see cref="BLACKONWHITE"/>
        /// </term>
        /// <term>
        /// Performs a Boolean AND operation using the color values for the eliminated and existing pixels.
        /// If the bitmap is a monochrome bitmap, this mode preserves black pixels at the expense of white pixels.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="COLORONCOLOR"/>
        /// </term>
        /// <term>
        /// Deletes the pixels.
        /// This mode deletes all eliminated lines of pixels without trying to preserve their information.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HALFTONE"/>
        /// </term>
        /// <term>
        /// <para>
        /// Maps pixels from the source rectangle into blocks of pixels in the destination rectangle.
        /// The average color over the destination block of pixels approximates the color of the source pixels.
        /// </para>
        /// <para>
        /// After setting the <see cref="HALFTONE"/> stretching mode,
        /// an application must call the <see cref="SetBrushOrgEx"/> function to set the brush origin.
        /// If it fails to do so, brush misalignment occurs.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="STRETCH_ANDSCANS"/>
        /// </term>
        /// <term>
        /// Same as <see cref="BLACKONWHITE"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="STRETCH_DELETESCANS"/>
        /// </term>
        /// <term>
        /// Same as <see cref="COLORONCOLOR"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="STRETCH_HALFTONE"/>
        /// </term>
        /// <term>
        /// Same as <see cref="HALFTONE"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="STRETCH_ORSCANS"/>
        /// </term>
        /// <term>
        /// Same as <see cref="WHITEONBLACK"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WHITEONBLACK"/>
        /// </term>
        /// <term>
        /// Performs a Boolean OR operation using the color values for the eliminated and existing pixels.
        /// If the bitmap is a monochrome bitmap, this mode preserves white pixels at the expense of black pixels.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the previous stretching mode.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// <para>
        /// This function can return the following value.
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
        /// <see cref="ERROR_INVALID_PARAMETER"/>
        /// </term>
        /// <term>
        /// One or more of the input parameters is invalid.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The stretching mode defines how the system combines rows or columns of a bitmap
        /// with existing pixels on a display device when an application calls the <see cref="StretchBlt"/> function.
        /// </para>
        /// <para>
        /// The <see cref="BLACKONWHITE"/> (<see cref="STRETCH_ANDSCANS"/>) and <see cref="WHITEONBLACK"/> (<see cref="STRETCH_ORSCANS"/>) modes
        /// are typically used to preserve foreground pixels in monochrome bitmaps.
        /// The <see cref="COLORONCOLOR"/> (<see cref="STRETCH_DELETESCANS"/>) mode is typically used to preserve color in color bitmaps.
        /// </para>
        /// <para>
        /// The <see cref="HALFTONE"/> mode is slower and requires more processing of the source image than the other three modes;
        /// but produces higher quality images.
        /// Also note that <see cref="SetBrushOrgEx"/> must be called after setting the <see cref="HALFTONE"/> mode to avoid brush misalignment.
        /// </para>
        /// <para>
        /// Additional stretching modes might also be available depending on the capabilities of the device driver.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetStretchBltMode", ExactSpelling = true, SetLastError = true)]
        public static extern int SetStretchBltMode([In] HDC hdc, [In] StretchBltModes mode);

        /// <summary>
        /// <para>
        /// The <see cref="StretchBlt"/> function copies a bitmap from a source rectangle into a destination rectangle,
        /// stretching or compressing the bitmap to fit the dimensions of the destination rectangle, if necessary.
        /// The system stretches or compresses the bitmap according to the stretching mode currently set in the destination device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-stretchblt"/>
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
        /// <para>
        /// The raster operation to be performed.
        /// Raster operation codes define how the system combines colors in output operations
        /// that involve a brush, a source bitmap, and a destination bitmap.
        /// </para>
        /// <para>
        /// See <see cref="BitBlt"/> for a list of common raster operation codes (ROPs).
        /// Note that the <see cref="CAPTUREBLT"/> ROP generally cannot be used for printing device contexts.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="StretchBlt"/> stretches or compresses the source bitmap in memory
        /// and then copies the result to the destination rectangle.
        /// This bitmap can be either a compatible bitmap (DDB) or the output from <see cref="CreateDIBSection"/>.
        /// The color data for pattern or destination pixels is merged after the stretching or compression occurs.
        /// </para>
        /// <para>
        /// When an enhanced metafile is being recorded, an error occurs (and the function returns <see cref="FALSE"/>)
        /// if the source device context identifies an enhanced-metafile device context.
        /// </para>
        /// <para>
        /// If the specified raster operation requires a brush,
        /// the system uses the brush currently selected into the destination device context.
        /// </para>
        /// <para>
        /// The destination coordinates are transformed by using the transformation currently specified for the destination device context;
        /// the source coordinates are transformed by using the transformation currently specified for the source device context.
        /// </para>
        /// <para>
        /// If the source transformation has a rotation or shear, an error occurs.
        /// </para>
        /// <para>
        /// If destination, source, and pattern bitmaps do not have the same color format,
        /// <see cref="StretchBlt"/> converts the source and pattern bitmaps to match the destination bitmap.
        /// </para>
        /// <para>
        /// If <see cref="StretchBlt"/> must convert a monochrome bitmap to a color bitmap,
        /// it sets white bits (1) to the background color and black bits (0) to the foreground color.
        /// To convert a color bitmap to a monochrome bitmap,
        /// it sets pixels that match the background color to white (1) and sets all other pixels to black (0).
        /// The foreground and background colors of the device context with color are used.
        /// </para>
        /// <para>
        /// <see cref="StretchBlt"/> creates a mirror image of a bitmap
        /// if the signs of the <paramref name="wSrc"/> and <paramref name="wDest"/> parameters
        /// or if the <paramref name="hSrc"/> and <paramref name="hDest"/> parameters differ.
        /// If <paramref name="wSrc"/> and <paramref name="wDest"/> have different signs,
        /// the function creates a mirror image of the bitmap along the x-axis.
        /// If <paramref name="hSrc"/> and <paramref name="hDest"/> have different signs,
        /// the function creates a mirror image of the bitmap along the y-axis.
        /// </para>
        /// <para>
        /// Not all devices support the <see cref="StretchBlt"/> function.
        /// For more information, see the <see cref="GetDeviceCaps"/>.
        /// </para>
        /// <para>
        /// ICM: No color management is performed when a blit operation occurs.
        /// </para>
        /// <para>
        /// When used in a multiple monitor system,
        /// both <paramref name="hdcSrc"/> and <paramref name="hdcDest"/> must refer to the same device or the function will fail.
        /// To transfer data between DCs for different devices, convert the memory bitmap to a DIB by calling <see cref="GetDIBits"/>.
        /// To display the DIB to the second device, call <see cref="SetDIBits"/> or <see cref="StretchDIBits"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "StretchBlt", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL StretchBlt([In] HDC hdcDest, [In] int xDest, [In] int yDest, [In] int wDest, [In] int hDest, [In] HDC hdcSrc,
            [In] int xSrc, [In] int ySrc, [In] int wSrc, [In] int hSrc, [In] RasterCodes rop);

        /// <summary>
        /// <para>
        /// The <see cref="StretchDIBits"/> function copies the color data
        /// for a rectangle of pixels in a DIB, JPEG, or PNG image to the specified destination rectangle.
        /// If the destination rectangle is larger than the source rectangle,
        /// this function stretches the rows and columns of color data to fit the destination rectangle.
        /// If the destination rectangle is smaller than the source rectangle,
        /// this function compresses the rows and columns by using the specified raster operation.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-stretchdibits"/>
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
        /// <para>
        /// Specifies whether the <see cref="BITMAPINFO.bmiColors"/> member of the <see cref="BITMAPINFO"/> structure was provided and,
        /// if so, whether <see cref="BITMAPINFO.bmiColors"/> contains explicit red, green, blue (RGB) values or indexes.
        /// The <paramref name="iUsage"/> parameter must be one of the following values.
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
        /// <see cref="DIB_PAL_COLORS"/>
        /// </term>
        /// <term>
        /// The array contains 16-bit indexes into the logical palette of the source device context.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DIB_RGB_COLORS"/>
        /// </term>
        /// <term>
        /// The color table contains literal RGB values.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        ///  
        /// </para>
        /// <para>
        /// For more information, see the Remarks section.
        /// </para>
        /// </param>
        /// <param name="rop">
        /// A raster-operation code that specifies how the source pixels, the destination device context's current brush,
        /// and the destination pixels are to be combined to form the new image.
        /// For a list of some common raster operation codes, see <see cref="BitBlt"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the number of scan lines copied.
        /// Note that this value can be negative for mirrored content.
        /// </para>
        /// <para>
        /// If the function fails, or no scan lines are copied, the return value is 0.
        /// </para>
        /// <para>
        /// If the driver cannot support the JPEG or PNG file image passed to <see cref="StretchDIBits"/>,
        /// the function will fail and return <see cref="GDI_ERROR"/>.
        /// If failure does occur, the application must fall back on its own JPEG or PNG support to decompress the image into a bitmap,
        /// and then pass the bitmap to <see cref="StretchDIBits"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The origin of a bottom-up DIB is the lower-left corner; the origin of a top-down DIB is the upper-left corner.
        /// </para>
        /// <para>
        /// <see cref="StretchDIBits"/> creates a mirror image of a bitmap
        /// if the signs of the <paramref name="SrcWidth"/> and <paramref name="DestWidth"/> parameters,
        /// or if the <paramref name="SrcHeight"/> and <paramref name="DestHeight"/> parameters differ.
        /// If <paramref name="SrcWidth"/> and <paramref name="DestWidth"/> have different signs,
        /// the function creates a mirror image of the bitmap along the x-axis.
        /// If <paramref name="SrcHeight"/> and <paramref name="DestHeight"/> have different signs,
        /// the function creates a mirror image of the bitmap along the y-axis.
        /// </para>
        /// <para>
        /// <see cref="StretchDIBits"/> creates a top-down image if the sign of the <see cref="BITMAPINFOHEADER.biHeight"/> member
        /// of the <see cref="BITMAPINFOHEADER"/> structure for the DIB is negative.
        /// For a code example, see Sizing a JPEG or PNG Image.
        /// </para>
        /// <para>
        /// This function allows a JPEG or PNG image to be passed as the source image. How each parameter is used remains the same, except:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// If the <see cref="BITMAPINFOHEADER.biCompression"/> member
        /// of <see cref="BITMAPINFOHEADER"/> is <see cref="BI_JPEG"/> or <see cref="BI_PNG"/>,
        /// <paramref name="lpBits"/> points to a buffer containing a JPEG or PNG image, respectively.
        /// The <see cref="BITMAPINFOHEADER.biSizeImage"/> member of the <see cref="BITMAPINFOHEADER"/> structure specifies the size of the buffer.
        /// The <paramref name="iUsage"/> parameter must be set to <see cref="DIB_RGB_COLORS"/>.
        /// The <paramref name="rop"/> parameter must be set to <see cref="SRCCOPY"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// To ensure proper metafile spooling while printing,
        /// applications must call the <see cref="CHECKJPEGFORMAT"/> or <see cref="CHECKPNGFORMAT"/> escape
        /// to verify that the printer recognizes the JPEG or PNG image, respectively, before calling <see cref="StretchDIBits"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// ICM: Color management is performed if color management has been enabled
        /// with a call to <see cref="SetICMMode"/> with the iEnableICM parameter set to <see cref="ICM_ON"/>.
        /// If the bitmap specified by <paramref name="lpbmi"/> has a <see cref="BITMAPV4HEADER"/> that specifies the gamma and endpoints members,
        /// or a <see cref="BITMAPV5HEADER"/> that specifies either the gamma and endpoints members or the profileData and profileSize members,
        /// then the call treats the bitmap's pixels as being expressed in the color space described by those members,
        /// rather than in the device context's source color space.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "StretchDIBits", ExactSpelling = true, SetLastError = true)]
        public static extern int StretchDIBits([In] HDC hdc, [In] int xDest, [In] int yDest, [In] int DestWidth, [In] int DestHeight, [In] int xSrc,
            [In] int ySrc, [In] int SrcWidth, [In] int SrcHeight, [In] IntPtr lpBits, [In] in BITMAPINFO lpbmi,
            [In] UINT iUsage, [In] RasterCodes rop);
    }
}
