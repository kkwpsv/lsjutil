using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.DIBColorTableIdentifiers;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="BITMAPINFO"/> structure defines the dimensions and color information for a DIB.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/ns-wingdi-bitmapinfo
    /// </para>
    /// </summary>
    /// <remarks>
    /// A DIB consists of two distinct parts: a <see cref="BITMAPINFO"/> structure describing the dimensions and colors of the bitmap,
    /// and an array of bytes defining the pixels of the bitmap.
    /// The bits in the array are packed together, but each scan line must be padded with zeros to end on a LONG data-type boundary.
    /// If the height of the bitmap is positive, the bitmap is a bottom-up DIB and its origin is the lower-left corner.
    /// If the height is negative, the bitmap is a top-down DIB and its origin is the upper left corner.
    /// A bitmap is packed when the bitmap array immediately follows the <see cref="BITMAPINFO"/> header.
    /// Packed bitmaps are referenced by a single pointer.
    /// For packed bitmaps, the <see cref="BITMAPINFOHEADER.biClrUsed"/> member must be set to an even number
    /// when using the <see cref="DIB_PAL_COLORS"/> mode so that the DIB bitmap array starts on a DWORD boundary.
    /// Note
    /// The <see cref="bmiColors"/> member should not contain palette indexes if the bitmap is to be stored in a file or transferred to another application.
    /// Unless the application has exclusive use and control of the bitmap, the bitmap color table should contain explicit RGB values.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct BITMAPINFO
    {
        /// <summary>
        /// A <see cref="BITMAPINFOHEADER"/> structure that contains information about the dimensions of color format.
        /// </summary>
        public BITMAPINFOHEADER bmiHeader;

        /// <summary>
        /// The <see cref="bmiColors"/> member contains one of the following:
        /// An array of <see cref="RGBQUAD"/>. The elements of the array that make up the color table.
        /// An array of 16-bit unsigned integers that specifies indexes into the currently realized logical palette.
        /// This use of <see cref="DIB_PAL_COLORS"/> is allowed for functions that use DIBs.
        /// When <see cref="bmiColors"/> elements contain indexes to a realized logical palette,
        /// they must also call the following bitmap functions: <see cref="CreateDIBitmap"/>
        /// <see cref="CreateDIBPatternBrush"/>
        /// <see cref="CreateDIBSection"/>
        /// The iUsage parameter of <see cref="CreateDIBSection"/> must be set to <see cref="DIB_PAL_COLORS"/>.
        /// The number of entries in the array depends on the values of the <see cref="BITMAPINFOHEADER.biBitCount"/>
        /// and <see cref="BITMAPINFOHEADER.biClrUsed"/> members of the <see cref="BITMAPINFOHEADER"/> structure.
        /// The colors in the <see cref="bmiColors"/> table appear in order of importance.
        /// For more information, see the Remarks section.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public RGBQUAD[] bmiColors;
    }
}
