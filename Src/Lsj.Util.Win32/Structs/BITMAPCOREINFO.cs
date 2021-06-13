using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.DIBColorTableIdentifiers;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="BITMAPCOREINFO"/> structure defines the dimensions and color information for a DIB.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/ns-wingdi-bitmapcoreinfo"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// A DIB consists of two parts:
    /// a <see cref="BITMAPCOREINFO"/> structure describing the dimensions and colors of the bitmap,
    /// and an array of bytes defining the pixels of the bitmap.
    /// The bits in the array are packed together, but each scan line must be padded with zeros to end on a <see cref="LONG"/> boundary.
    /// The origin of the bitmap is the lower-left corner.
    /// The <see cref="BITMAPCOREHEADER.bcBitCount"/> member of the <see cref="BITMAPCOREHEADER"/> structure determines the number of bits
    /// that define each pixel and the maximum number of colors in the bitmap.
    /// This member can be one of the following values.
    /// 1:
    /// The bitmap is monochrome, and the <see cref="bmciColors"/> member contains two entries.
    /// Each bit in the bitmap array represents a pixel.
    /// If the bit is clear, the pixel is displayed with the color of the first entry in the <see cref="bmciColors"/> table;
    /// if the bit is set, the pixel has the color of the second entry in the table.
    /// 4
    /// The bitmap has a maximum of 16 colors, and the <see cref="bmciColors"/> member contains up to 16 entries.
    /// Each pixel in the bitmap is represented by a 4-bit index into the color table.
    /// For example, if the first byte in the bitmap is 0x1F, the byte represents two pixels.
    /// The first pixel contains the color in the second table entry, and the second pixel contains the color in the sixteenth table entry.
    /// 8
    /// The bitmap has a maximum of 256 colors, and the <see cref="bmciColors"/> member contains up to 256 entries.
    /// In this case, each byte in the array represents a single pixel.
    /// 24
    /// The bitmap has a maximum of 2 (24) colors, and the <see cref="bmciColors"/> member is <see langword="null"/>.
    /// Each three-byte triplet in the bitmap array represents the relative intensities of blue, green, and red, respectively, for a pixel.
    /// The colors in the <see cref="bmciColors"/> table should appear in order of importance.
    /// Alternatively, for functions that use DIBs, the <see cref="bmciColors"/> member can be an array of 16-bit unsigned integers
    /// that specify indexes into the currently realized logical palette, instead of explicit RGB values.
    /// In this case, an application using the bitmap must call the DIB functions(<see cref="CreateDIBitmap"/>,
    /// <see cref="CreateDIBPatternBrush"/>, and <see cref="CreateDIBSection"/>) with the iUsage parameter set to <see cref="DIB_PAL_COLORS"/>.
    /// The <see cref="bmciColors"/> member should not contain palette indexes
    /// if the bitmap is to be stored in a file or transferred to another application.
    /// Unless the application has exclusive use and control of the bitmap, the bitmap color table should contain explicit RGB values.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct BITMAPCOREINFO
    {
        /// <summary>
        /// A <see cref="BITMAPCOREHEADER"/> structure that contains information about the dimensions and color format of a DIB.
        /// </summary>
        public BITMAPCOREHEADER bmciHeader;

        /// <summary>
        /// Specifies an array of <see cref="RGBTRIPLE"/> structures that define the colors in the bitmap.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public RGBTRIPLE[] bmciColors;
    }
}
