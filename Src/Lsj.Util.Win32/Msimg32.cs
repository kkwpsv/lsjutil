using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Enums.StretchBltModes;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.Structs.BLENDFUNCTION;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Msimg32.dll
    /// </summary>
    public static class Msimg32
    {
        /// <summary>
        /// <para>
        /// The <see cref="AlphaBlend"/> function displays bitmaps that have transparent or semitransparent pixels.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-alphablend"/>
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
        /// </returns>
        /// <remarks>
        /// If the source rectangle and destination rectangle are not the same size,
        /// the source bitmap is stretched to match the destination rectangle.
        /// If the <see cref="SetStretchBltMode"/> function is used, the iStretchMode value is automatically
        /// converted to <see cref="COLORONCOLOR"/> for this function (that is, <see cref="BLACKONWHITE"/>,
        /// <see cref="WHITEONBLACK"/>, and <see cref="HALFTONE"/> are changed to <see cref="COLORONCOLOR"/>).
        /// The destination coordinates are transformed by using the transformation currently specified for the destination device context.
        /// The source coordinates are transformed by using the transformation currently specified for the source device context.
        /// An error occurs (and the function returns <see cref="FALSE"/>) 
        /// if the source device context identifies an enhanced metafile device context.
        /// If destination and source bitmaps do not have the same color format,
        /// <see cref="AlphaBlend"/> converts the source bitmap to match the destination bitmap.
        /// <see cref="AlphaBlend"/> does not support mirroring.
        /// If either the width or height of the source or destination is negative, this call will fail.
        /// When rendering to a printer, first call <see cref="GetDeviceCaps"/> with <see cref="SHADEBLENDCAPS"/> to determine
        /// if the printer supports blending with <see cref="AlphaBlend"/>.
        /// Note that, for a display DC, all blending operations are supported and these flags represent whether the operations are accelerated.
        /// If the source and destination are the same surface, that is, they are both the screen or the same memory bitmap
        /// and the source and destination rectangles overlap, an error occurs and the function returns <see cref="FALSE"/>.
        /// The source rectangle must lie completely within the source surface,
        /// otherwise an error occurs and the function returns <see cref="FALSE"/>.
        /// <see cref="AlphaBlend"/> fails if the width or height of the source or destination is negative.
        /// The <see cref="BLENDFUNCTION.SourceConstantAlpha"/> member of <see cref="BLENDFUNCTION"/>
        /// specifies an alpha transparency value to be used on the entire source bitmap.
        /// The <see cref="BLENDFUNCTION.SourceConstantAlpha"/> value is combined with any per-pixel alpha values.
        /// If <see cref="BLENDFUNCTION.SourceConstantAlpha"/> is 0, it is assumed that the image is transparent.
        /// Set the <see cref="BLENDFUNCTION.SourceConstantAlpha"/> value to 255 (which indicates that the image is opaque)
        /// when you only want to use per-pixel alpha values.
        /// </remarks>
        [DllImport("Msimg32.dll", CharSet = CharSet.Unicode, EntryPoint = "AlphaBlend", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AlphaBlend([In] HDC hdcDest, [In] int xoriginDest, [In] int yoriginDest, [In] int wDest, [In] int hDest,
            [In] HDC hdcSrc, [In] int xoriginSrc, [In] int yoriginSrc, [In] int wSrc, [In] int hSrc, [In] BLENDFUNCTION ftn);
    }
}
