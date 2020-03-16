using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="BITMAPINFOHEADER"/> structure contains information about the dimensions and color format of a DIB.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/previous-versions/dd183376(v=vs.85)
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="BITMAPINFO"/> structure combines the <see cref="BITMAPINFOHEADER"/> structure and a color table
    /// to provide a complete definition of the dimensions and colors of a DIB.
    /// For more information about DIBs, see Device-Independent Bitmaps and <see cref="BITMAPINFO"/>.
    /// An application should use the information stored in the <see cref="biSize"/> member
    /// to locate the color table in a <see cref="BITMAPINFO"/> structure, as follows:
    /// <code>
    /// pColor = ((LPSTR)pBitmapInfo + (WORD)(pBitmapInfo-&gt;bmiHeader.biSize));
    /// </code>
    /// The <see cref="BITMAPINFOHEADER"/> structure is extended to allow a JPEG or PNG image
    /// to be passed as the source image to <see cref="StretchDIBits"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct BITMAPINFOHEADER
    {
        /// <summary>
        /// The number of bytes required by the structure.
        /// </summary>
        public uint biSize;

        /// <summary>
        /// The width of the bitmap, in pixels.
        /// If <see cref="biCompression"/> is <see cref="BI_JPEG"/> or <see cref="BI_PNG"/>,
        /// the <see cref="biWidth"/> member specifies the width of the decompressed JPEG or PNG image file, respectively.
        /// </summary>
        public int biWidth;

        /// <summary>
        /// The height of the bitmap, in pixels.
        /// If <see cref="biHeight"/> is positive, the bitmap is a bottom-up DIB and its origin is the lower-left corner.
        /// If <see cref="biHeight"/> is negative, the bitmap is a top-down DIB and its origin is the upper-left corner.
        /// If <see cref="biHeight"/> is negative, indicating a top-down DIB,
        /// <see cref="biCompression"/> must be either <see cref="BI_RGB"/> or <see cref="BI_BITFIELDS"/>.
        /// Top-down DIBs cannot be compressed.
        /// If <see cref="biCompression"/> is <see cref="BI_JPEG"/> or <see cref="BI_PNG"/>,
        /// the <see cref="biHeight"/> member specifies the height of the decompressed JPEG or PNG image file, respectively.
        /// </summary>
        public int biHeight;

        /// <summary>
        /// The number of planes for the target device.
        /// This value must be set to 1.
        /// </summary>
        public ushort biPlanes;

        /// <summary>
        /// The number of bits-per-pixel.
        /// The <see cref="biBitCount"/> member of the <see cref="BITMAPINFOHEADER"/> structure determines the number of bits
        /// that define each pixel and the maximum number of colors in the bitmap.
        /// This member must be one of the following values.
        /// 0:
        /// The number of bits-per-pixel is specified or is implied by the JPEG or PNG format.
        /// 1:
        /// The bitmap is monochrome, and the <see cref="bmiColors"/> member of <see cref="BITMAPINFO"/> contains two entries.
        /// Each bit in the bitmap array represents a pixel.
        /// If the bit is clear, the pixel is displayed with the color of the first entry in the <see cref="bmiColors"/> table;
        /// if the bit is set, the pixel has the color of the second entry in the table.
        /// 4:
        /// The bitmap has a maximum of 16 colors, and the <see cref="bmiColors"/> member of <see cref="BITMAPINFO"/> contains up to 16 entries.
        /// Each pixel in the bitmap is represented by a 4-bit index into the color table.
        /// For example, if the first byte in the bitmap is 0x1F, the byte represents two pixels.
        /// The first pixel contains the color in the second table entry, and the second pixel contains the color in the sixteenth table entry.
        /// 8:
        /// The bitmap has a maximum of 256 colors, and the <see cref="bmiColors"/> member of <see cref="BITMAPINFO"/> contains up to 256 entries.
        /// In this case, each byte in the array represents a single pixel.
        /// 16:
        /// The bitmap has a maximum of 2^16 colors.
        /// If the <see cref="biCompression"/> member of the <see cref="BITMAPINFOHEADER"/> is <see cref="BI_RGB"/>,
        /// the <see cref="bmiColors"/> member of <see cref="BITMAPINFO"/> is <see langword="null"/>.
        /// Each WORD in the bitmap array represents a single pixel.
        /// The relative intensities of red, green, and blue are represented with five bits for each color component.
        /// The value for blue is in the least significant five bits, followed by five bits each for green and red.
        /// The most significant bit is not used.
        /// The <see cref="bmiColors"/> color table is used for optimizing colors used on palette-based devices,
        /// and must contain the number of entries specified by the <see cref="biClrUsed"/> member of the <see cref="BITMAPINFOHEADER"/>.
        /// If the <see cref="biCompression"/> member of the <see cref="BITMAPINFOHEADER"/> is <see cref="BI_BITFIELDS"/>,
        /// the <see cref="bmiColors"/> member contains three DWORD color masks that specify the red, green, and blue components,
        /// respectively, of each pixel.
        /// Each WORD in the bitmap array represents a single pixel.
        /// When the <see cref="biCompression"/> member is <see cref="BI_BITFIELDS"/>,
        /// bits set in each DWORD mask must be contiguous and should not overlap the bits of another mask.
        /// All the bits in the pixel do not have to be used.
        /// 24:
        /// The bitmap has a maximum of 2^24 colors, and the <see cref="bmiColors"/> member of <see cref="BITMAPINFO"/> is <see langword="null"/>.
        /// Each 3-byte triplet in the bitmap array represents the relative intensities of blue, green, and red, respectively, for a pixel.
        /// The <see cref="bmiColors"/> color table is used for optimizing colors used on palette-based devices,
        /// and must contain the number of entries specified by the <see cref="biClrUsed"/> member of the <see cref="BITMAPINFOHEADER"/>.
        /// 32:
        /// The bitmap has a maximum of 2^32 colors.
        /// If the <see cref="biCompression"/> member of the <see cref="BITMAPINFOHEADER"/> is <see cref="BI_RGB"/>,
        /// the <see cref="bmiColors"/> member of <see cref="BITMAPINFO"/> is <see langword="null"/>.
        /// Each DWORD in the bitmap array represents the relative intensities of blue, green, and red for a pixel.
        /// The value for blue is in the least significant 8 bits, followed by 8 bits each for green and red.
        /// The high byte in each DWORD is not used.
        /// The <see cref="bmiColors"/> color table is used for optimizing colors used on palette-based devices,
        /// and must contain the number of entries specified by the <see cref="biClrUsed"/> member of the <see cref="BITMAPINFOHEADER"/>.
        /// If the <see cref="biCompression"/> member of the <see cref="BITMAPINFOHEADER"/> is <see cref="BI_BITFIELDS"/>,
        /// the <see cref="bmiColors"/> member contains three DWORD color masks that specify the red, green, and blue components,
        /// respectively, of each pixel.
        /// Each DWORD in the bitmap array represents a single pixel.
        /// When the <see cref="biCompression"/> member is <see cref="BI_BITFIELDS"/>,
        /// bits set in each DWORD mask must be contiguous and should not overlap the bits of another mask.
        /// All the bits in the pixel do not need to be used.
        /// </summary>
        public ushort biBitCount;

        /// <summary>
        /// The type of compression for a compressed bottom-up bitmap (top-down DIBs cannot be compressed).
        /// This member can be one of the following values.
        /// <see cref="BI_RGB"/>: An uncompressed format.
        /// <see cref="BI_RLE8"/>:
        /// A run-length encoded (RLE) format for bitmaps with 8 bpp.
        /// The compression format is a 2-byte format consisting of a count byte followed by a byte containing a color index.
        /// For more information, see Bitmap Compression.
        /// <see cref="BI_RLE4"/>:
        /// An RLE format for bitmaps with 4 bpp.
        /// The compression format is a 2-byte format consisting of a count byte followed by two word-length color indexes.
        /// For more information, see Bitmap Compression.
        /// <see cref="BI_BITFIELDS"/>:
        /// Specifies that the bitmap is not compressed and that the color table consists of three DWORD color masks that specify the red,
        /// green, and blue components, respectively, of each pixel.
        /// This is valid when used with 16- and 32-bpp bitmaps.
        /// <see cref="BI_JPEG"/>: Indicates that the image is a JPEG image.
        /// <see cref="BI_PNG"/>: Indicates that the image is a PNG image.
        /// </summary>
        public Compression biCompression;

        /// <summary>
        /// The size, in bytes, of the image. This may be set to zero for <see cref="BI_RGB"/> bitmaps.
        /// If <see cref="biCompression"/> is <see cref="BI_JPEG"/> or <see cref="BI_PNG"/>,
        /// <see cref="biSizeImage"/> indicates the size of the JPEG or PNG image buffer, respectively.
        /// </summary>
        public uint biSizeImage;

        /// <summary>
        /// The horizontal resolution, in pixels-per-meter, of the target device for the bitmap.
        /// An application can use this value to select a bitmap from a resource group that best matches the characteristics of the current device.
        /// </summary>
        public int biXPelsPerMeter;

        /// <summary>
        /// The vertical resolution, in pixels-per-meter, of the target device for the bitmap.
        /// </summary>
        public int biYPelsPerMeter;

        /// <summary>
        /// The number of color indexes in the color table that are actually used by the bitmap.
        /// If this value is zero, the bitmap uses the maximum number of colors corresponding to the value of the <see cref="biBitCount"/> member
        /// for the compression mode specified by <see cref="biCompression"/>.
        /// If <see cref="biClrUsed"/> is nonzero and the <see cref="biBitCount"/> member is less than 16,
        /// the <see cref="biClrUsed"/> member specifies the actual number of colors the graphics engine or device driver accesses.
        /// If <see cref="biBitCount"/> is 16 or greater, the <see cref="biClrUsed"/> member specifies the size of the color table
        /// used to optimize performance of the system color palettes.
        /// If <see cref="biBitCount"/> equals 16 or 32, the optimal color palette starts immediately following the three DWORD masks.
        /// When the bitmap array immediately follows the <see cref="BITMAPINFO"/> structure, it is a packed bitmap.
        /// Packed bitmaps are referenced by a single pointer.
        /// Packed bitmaps require that the <see cref="biClrUsed"/> member must be either zero or the actual size of the color table.
        /// </summary>
        public int biClrUsed;

        /// <summary>
        /// The number of color indexes that are required for displaying the bitmap.
        /// If this value is zero, all colors are required.
        /// </summary>
        public int biClrImportant;
    }
}
