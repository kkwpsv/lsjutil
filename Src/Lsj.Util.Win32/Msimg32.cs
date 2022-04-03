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

        /// <summary>
        /// <para>
        /// The <see cref="GradientFill"/> function fills rectangle and triangle structures.
        /// </para>
        /// <para>
        /// From： <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-gradientfill"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the destination device context.
        /// </param>
        /// <param name="pVertex">
        /// A pointer to an array of <see cref="TRIVERTEX"/> structures that each define a triangle vertex.
        /// </param>
        /// <param name="nVertex">
        /// The number of vertices in <paramref name="pVertex"/>.
        /// </param>
        /// <param name="pMesh">
        /// An array of <see cref="GRADIENT_TRIANGLE"/> structures in triangle mode,
        /// or an array of <see cref="GRADIENT_RECT"/> structures in rectangle mode.
        /// </param>
        /// <param name="nCount">
        /// The number of elements (triangles or rectangles) in <paramref name="pMesh"/>.
        /// </param>
        /// <param name="ulMode">
        /// The gradient fill mode. This parameter can be one of the following values.
        /// <see cref="GRADIENT_FILL_RECT_H"/>:
        /// In this mode, two endpoints describe a rectangle.
        /// The rectangle is defined to have a constant color (specified by the <see cref="TRIVERTEX"/> structure) for the left and right edges.
        /// GDI interpolates the color from the left to right edge and fills the interior.
        /// <see cref="GRADIENT_FILL_RECT_V"/>:
        /// In this mode, two endpoints describe a rectangle.
        /// The rectangle is defined to have a constant color (specified by the <see cref="TRIVERTEX"/> structure) for the top and bottom edges.
        /// GDI interpolates the color from the top to bottom edge and fills the interior.
        /// <see cref="GRADIENT_FILL_TRIANGLE"/>:
        /// In this mode, an array of <see cref="TRIVERTEX"/> structures is passed to GDI
        /// along with a list of array indexes that describe separate triangles.
        /// GDI performs linear interpolation between triangle vertices and fills the interior.
        /// Drawing is done directly in 24- and 32-bpp modes.
        /// Dithering is performed in 16-, 8-, 4-, and 1-bpp mode.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// To add smooth shading to a triangle, call the <see cref="GradientFill"/> function with the three triangle endpoints.
        /// GDI will linearly interpolate and fill the triangle.
        /// Here is the drawing output of a shaded triangle.
        /// To add smooth shading to a rectangle, call <see cref="GradientFill"/>
        /// with the upper-left and lower-right coordinates of the rectangle.
        /// There are two shading modes used when drawing a rectangle.
        /// In horizontal mode, the rectangle is shaded from left-to-right.
        /// In vertical mode, the rectangle is shaded from top-to-bottom.
        /// Here is the drawing output of two shaded rectangles - one in horizontal mode, the other in vertical mode.
        /// The <see cref="GradientFill"/> function uses a mesh method to specify the endpoints of the object to draw.
        /// All vertices are passed to <see cref="GradientFill"/> in the <paramref name="pVertex"/> array.
        /// The <paramref name="pMesh"/> parameter specifies how these vertices are connected to form an object.
        /// When filling a rectangle, <paramref name="pMesh"/> points to an array of <see cref="GRADIENT_RECT"/> structures.
        /// Each <see cref="GRADIENT_RECT"/> structure specifies the index of two vertices in the <paramref name="pVertex"/> array.
        /// These two vertices form the upper-left and lower-right boundary of one rectangle.
        /// In the case of filling a triangle, <paramref name="pMesh"/> points to an array of <see cref="GRADIENT_TRIANGLE"/> structures.
        /// Each <see cref="GRADIENT_TRIANGLE"/> structure specifies the index of three vertices in the <paramref name="pVertex"/> array.
        /// These three vertices form one triangle.
        /// To simplify hardware acceleration, this routine is not required to be pixel-perfect in the triangle interior.
        /// Note that <see cref="GradientFill"/> does not use
        /// the <see cref="TRIVERTEX.Alpha"/> member of the <see cref="TRIVERTEX"/> structure.
        /// To use <see cref="GradientFill"/> with transparency, call <see cref="GradientFill"/>
        /// and then call <see cref="AlphaBlend"/> with the desired values for the alpha channel of each vertex.
        /// For more information, see Smooth Shading, Drawing a Shaded Triangle, and Drawing a Shaded Rectangle.
        /// </remarks>
        [DllImport("Msimg32.dll", CharSet = CharSet.Unicode, EntryPoint = "GradientFill", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GradientFill([In] HDC hdc, [In] TRIVERTEX[] pVertex, [In] ULONG nVertex,
            [In] PVOID pMesh, [In] ULONG nCount, [In] ULONG ulMode);

        /// <summary>
        /// <para>
        /// The <see cref="TransparentBlt"/> function performs a bit-block transfer of the color data
        /// corresponding to a rectangle of pixels from the specified source device context into a destination device context.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-transparentblt"/>
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
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="TransparentBlt"/> function works with compatible bitmaps (DDBs).
        /// The <see cref="TransparentBlt"/> function supports all formats of source bitmaps.
        /// However, for 32 bpp bitmaps, it just copies the alpha value over.
        /// Use <see cref="AlphaBlend"/> to specify 32 bits-per-pixel bitmaps with transparency.
        /// If the source and destination rectangles are not the same size,
        /// the source bitmap is stretched to match the destination rectangle.
        /// When the <see cref="SetStretchBltMode"/> function is used,
        /// the iStretchMode modes of <see cref="BLACKONWHITE"/> and <see cref="WHITEONBLACK"/> are converted
        /// to <see cref="COLORONCOLOR"/> for the <see cref="TransparentBlt"/> function.
        /// The destination device context specifies the transformation type for the destination coordinates.
        /// The source device context specifies the transformation type for the source coordinates.
        /// <see cref="TransparentBlt"/> does not mirror a bitmap if either the width or height,
        /// of either the source or destination, is negative.
        /// When used in a multiple monitor system, both <paramref name="hdcSrc"/> and <paramref name="hdcDest"/>
        /// must refer to the same device or the function will fail.
        /// To transfer data between DCs for different devices, convert the memory bitmap to a DIB by calling <see cref="GetDIBits"/>.
        /// To display the DIB to the second device, call <see cref="SetDIBits"/> or <see cref="StretchDIBits"/>.
        /// </remarks>
        [DllImport("Msimg32.dll", CharSet = CharSet.Unicode, EntryPoint = "TransparentBlt", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL TransparentBlt([In] HDC hdcDest, [In] int xoriginDest, [In] int yoriginDest, [In] int wDest,
            [In] int hDest, [In] HDC hdcSrc, [In] int xoriginSrc, [In] int yoriginSrc, [In] int wSrc, [In] int hSrc, [In] UINT crTransparent);
    }
}
