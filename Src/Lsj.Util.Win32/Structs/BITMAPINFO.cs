using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.DIBColorTableUsages;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="BITMAPINFO"/> structure defines the dimensions and color information for a DIB.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-bitmapinfo"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// A DIB consists of two distinct parts: a <see cref="BITMAPINFO"/> structure describing the dimensions and colors of the bitmap,
    /// and an array of bytes defining the pixels of the bitmap.
    /// The bits in the array are packed together, but each scan line must be padded with zeros to end on a <see cref="LONG"/> data-type boundary.
    /// If the height of the bitmap is positive, the bitmap is a bottom-up DIB and its origin is the lower-left corner.
    /// If the height is negative, the bitmap is a top-down DIB and its origin is the upper left corner.
    /// </para>
    /// <para>
    /// A bitmap is packed when the bitmap array immediately follows the <see cref="BITMAPINFO"/> header.
    /// Packed bitmaps are referenced by a single pointer.
    /// For packed bitmaps, the <see cref="BITMAPINFOHEADER.biClrUsed"/> member must be set to an even number
    /// when using the <see cref="DIB_PAL_COLORS"/> mode so that the DIB bitmap array starts on a <see cref="DWORD"/> boundary.
    /// </para>
    /// <para>
    /// The <see cref="bmiColors"/> member should not contain palette indexes
    /// if the bitmap is to be stored in a file or transferred to another application.
    /// </para>
    /// <para>
    /// Unless the application has exclusive use and control of the bitmap,
    /// the bitmap color table should contain explicit RGB values.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct BITMAPINFO
    {
        /// <summary>
        /// A <see cref="BITMAPINFOHEADER"/> structure that contains information about the dimensions of color format.
        /// </summary>
        public BITMAPINFOHEADER bmiHeader;

        /// <summary>
        /// <para>
        /// The <see cref="bmiColors"/> member contains one of the following:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// An array of <see cref="RGBQUAD"/>. The elements of the array that make up the color table.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// An array of 16-bit unsigned integers that specifies indexes into the currently realized logical palette.
        /// This use of <see cref="DIB_PAL_COLORS"/> is allowed for functions that use DIBs.
        /// When <see cref="bmiColors"/> elements contain indexes to a realized logical palette,
        /// they must also call the following bitmap functions:
        /// </para>
        /// <para>
        /// <see cref="CreateDIBitmap"/>
        /// </para>
        /// <para>
        /// <see cref="CreateDIBPatternBrush"/>
        /// </para>
        /// <para>
        /// <see cref="CreateDIBSection"/>
        /// </para>
        /// <para>
        /// The iUsage parameter of <see cref="CreateDIBSection"/> must be set to <see cref="DIB_PAL_COLORS"/>.
        /// </para>
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// The number of entries in the array depends on the values of the <see cref="BITMAPINFOHEADER.biBitCount"/>
        /// and <see cref="BITMAPINFOHEADER.biClrUsed"/> members of the <see cref="BITMAPINFOHEADER"/> structure.
        /// </para>
        /// <para>
        /// The colors in the <see cref="bmiColors"/> table appear in order of importance. For more information, see the Remarks section.
        /// </para>
        /// </summary>
        public RGBQUAD bmiColors;
    }
}
