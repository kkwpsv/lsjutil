using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.Compression;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="BITMAPV4HEADER"/> structure is the bitmap information header file.
    /// It is an extended version of the <see cref="BITMAPINFOHEADER"/> structure.
    /// Applications can use the <see cref="BITMAPV5HEADER"/> structure for added functionality.
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="BITMAPV4HEADER"/> structure is extended to allow a JPEG or PNG image to be passed as the source image to <see cref="StretchDIBits"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct BITMAPV4HEADER
    {
        /// <summary>
        /// The number of bytes required by the structure.
        /// Applications should use this member to determine which bitmap information header structure is being used.
        /// </summary>
        public DWORD bV4Size;

        /// <summary>
        /// The width of the bitmap, in pixels.
        /// If <see cref="bV4V4Compression"/> is <see cref="BI_JPEG"/> or <see cref="BI_PNG"/>,
        /// <see cref="bV4Width"/> specifies the width of the JPEG or PNG image in pixels.
        /// </summary>
        public LONG bV4Width;

        /// <summary>
        /// The height of the bitmap, in pixels.
        /// If <see cref="bV4Height"/> is positive, the bitmap is a bottom-up DIB and its origin is the lower-left corner.
        /// If <see cref="bV4Height"/> is negative, the bitmap is a top-down DIB and its origin is the upper-left corner.
        /// If <see cref="bV4Height"/> is negative, indicating a top-down DIB,
        /// <see cref="bV4V4Compression"/> must be either <see cref="BI_RGB"/> or <see cref="BI_BITFIELDS"/>.
        /// Top-down DIBs cannot be compressed.
        /// If <see cref="bV4V4Compression"/> is <see cref="BI_JPEG"/> or <see cref="BI_PNG"/>,
        /// <see cref="bV4Height"/> specifies the height of the JPEG or PNG image in pixels.
        /// </summary>
        public LONG bV4Height;

        /// <summary>
        /// The number of planes for the target device. This value must be set to 1.
        /// </summary>
        public WORD bV4Planes;

        /// <summary>
        /// The number of bits-per-pixel.
        /// The <see cref="bV4BitCount"/> member of the <see cref="BITMAPV4HEADER"/> structure determines the number of bits
        /// that define each pixel and the maximum number of colors in the bitmap.
        /// This member must be one of the following values.
        /// 0: The number of bits-per-pixel is specified or is implied by the JPEG or PNG file format.
        /// 1:
        /// The bitmap is monochrome, and the <see cref="BITMAPINFO.bmiColors"/> member of <see cref="BITMAPINFO"/> contains two entries.
        /// Each bit in the bitmap array represents a pixel.
        /// If the bit is clear, the pixel is displayed with the color of the first entry in the <see cref="BITMAPINFO.bmiColors"/> table;
        /// if the bit is set, the pixel has the color of the second entry in the table.
        /// 4:
        /// The bitmap has a maximum of 16 colors, and the <see cref="BITMAPINFO.bmiColors"/> member of <see cref="BITMAPINFO"/> contains up to 16 entries.
        /// Each pixel in the bitmap is represented by a 4-bit index into the color table.
        /// For example, if the first byte in the bitmap is 0x1F, the byte represents two pixels.
        /// The first pixel contains the color in the second table entry, and the second pixel contains the color in the sixteenth table entry.
        /// 8:
        /// The bitmap has a maximum of 256 colors, and the <see cref="BITMAPINFO.bmiColors"/> member of <see cref="BITMAPINFO"/> contains up to 256 entries.
        /// In this case, each byte in the array represents a single pixel.
        /// 16:
        /// The bitmap has a maximum of 2^16 colors.
        /// If the <see cref="bV4V4Compression"/> member of the <see cref="BITMAPV4HEADER"/> structure is <see cref="BI_RGB"/>,
        /// the <see cref="BITMAPINFO.bmiColors"/> member of <see cref="BITMAPINFO"/> is <see cref="NULL"/>.
        /// Each WORD in the bitmap array represents a single pixel.
        /// The relative intensities of red, green, and blue are represented with five bits for each color component.
        /// The value for blue is in the least significant five bits, followed by five bits each for green and red, respectively.
        /// The most significant bit is not used.
        /// The <see cref="BITMAPINFO.bmiColors"/> color table is used for optimizing colors used on palette-based devices,
        /// and must contain the number of entries specified by the <see cref="bV4ClrUsed"/> member of the <see cref="BITMAPV4HEADER"/>.
        /// If the <see cref="bV4V4Compression"/> member of the <see cref="BITMAPV4HEADER"/> is <see cref="BI_BITFIELDS"/>,
        /// the <see cref="BITMAPINFO.bmiColors"/> member contains three DWORD color masks that specify the red, green, and blue components of each pixel.
        /// Each WORD in the bitmap array represents a single pixel.
        /// 24:
        /// The bitmap has a maximum of 2^24 colors, and the <see cref="BITMAPINFO.bmiColors"/> member of <see cref="BITMAPINFO"/> is <see cref="NULL"/>.
        /// Each 3-byte triplet in the bitmap array represents the relative intensities of blue, green, and red for a pixel.
        /// The <see cref="BITMAPINFO.bmiColors"/> color table is used for optimizing colors used on palette-based devices,
        /// and must contain the number of entries specified by the <see cref="bV4ClrUsed"/> member of the <see cref="BITMAPV4HEADER"/>.
        /// 32:
        /// The bitmap has a maximum of 2^32 colors.
        /// If the <see cref="bV4V4Compression"/> member of the <see cref="BITMAPV4HEADER"/> is <see cref="BI_RGB"/>,
        /// the <see cref="BITMAPINFO.bmiColors"/> member of <see cref="BITMAPINFO"/> is <see cref="NULL"/>.
        /// Each DWORD in the bitmap array represents the relative intensities of blue, green, and red for a pixel.
        /// The value for blue is in the least significant 8 bits, followed by 8 bits each for green and red.
        /// The high byte in each DWORD is not used.
        /// The bmiColors color table is used for optimizing colors used on palette-based devices,
        /// and must contain the number of entries specified by the <see cref="bV4ClrUsed"/> member of the <see cref="BITMAPV4HEADER"/>.
        /// If the <see cref="bV4V4Compression"/> member of the <see cref="BITMAPV4HEADER"/> is <see cref="BI_BITFIELDS"/>,
        /// the <see cref="BITMAPINFO.bmiColors"/> member contains three DWORD color masks that specify the red, green, and blue components of each pixel.
        /// Each DWORD in the bitmap array represents a single pixel.
        /// </summary>
        public WORD bV4BitCount;

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
        /// Specifies that the bitmap is not compressed.
        /// The members <see cref="bV4RedMask"/>, <see cref="bV4GreenMask"/>, and <see cref="bV4BlueMask"/>
        /// specify the red, green, and blue components for each pixel.
        /// This is valid when used with 16- and 32-bpp bitmaps.
        /// <see cref="BI_JPEG"/>:
        /// Specifies that the image is compressed using the JPEG file interchange format.
        /// JPEG compression trades off compression against loss; it can achieve a compression ratio of 20:1 with little noticeable loss.
        /// <see cref="BI_PNG"/>:
        /// Specifies that the image is compressed using the PNG file interchange format.
        /// </summary>
        public Compression bV4V4Compression;

        /// <summary>
        /// The size, in bytes, of the image.
        /// This may be set to zero for <see cref="BI_RGB"/> bitmaps.
        /// If <see cref="bV4V4Compression"/> is <see cref="BI_JPEG"/> or <see cref="BI_PNG"/>,
        /// <see cref="bV4SizeImage"/> is the size of the JPEG or PNG image buffer.
        /// </summary>
        public DWORD bV4SizeImage;

        /// <summary>
        /// The horizontal resolution, in pixels-per-meter, of the target device for the bitmap.
        /// An application can use this value to select a bitmap from a resource group that best matches the characteristics of the current device.
        /// </summary>
        public LONG bV4XPelsPerMeter;

        /// <summary>
        /// The vertical resolution, in pixels-per-meter, of the target device for the bitmap.
        /// </summary>
        public LONG bV4YPelsPerMeter;

        /// <summary>
        /// The number of color indexes in the color table that are actually used by the bitmap.
        /// If this value is zero, the bitmap uses the maximum number of colors corresponding
        /// to the value of the <see cref="bV4BitCount"/> member for the compression mode specified by <see cref="bV4V4Compression"/>.
        /// If <see cref="bV4ClrUsed"/> is nonzero and the <see cref="bV4BitCount"/> member is less than 16,
        /// the <see cref="bV4ClrUsed"/> member specifies the actual number of colors the graphics engine or device driver accesses.
        /// If <see cref="bV4BitCount"/> is 16 or greater, the <see cref="bV4ClrUsed"/> member specifies the size of the color table
        /// used to optimize performance of the system color palettes.
        /// If <see cref="bV4BitCount"/> equals 16 or 32, the optimal color palette starts immediately following the <see cref="BITMAPV4HEADER"/>.
        /// </summary>
        public DWORD bV4ClrUsed;

        /// <summary>
        /// The number of color indexes that are required for displaying the bitmap.
        /// If this value is zero, all colors are important.
        /// </summary>
        public DWORD bV4ClrImportant;

        /// <summary>
        /// Color mask that specifies the red component of each pixel, valid only if <see cref="bV4V4Compression"/> is set to <see cref="BI_BITFIELDS"/>.
        /// </summary>
        public DWORD bV4RedMask;

        /// <summary>
        /// Color mask that specifies the green component of each pixel, valid only if <see cref="bV4V4Compression"/> is set to <see cref="BI_BITFIELDS"/>.
        /// </summary>
        public DWORD bV4GreenMask;

        /// <summary>
        /// Color mask that specifies the blue component of each pixel, valid only if <see cref="bV4V4Compression"/> is set to <see cref="BI_BITFIELDS"/>.
        /// </summary>
        public DWORD bV4BlueMask;

        /// <summary>
        /// Color mask that specifies the alpha component of each pixel.
        /// </summary>
        public DWORD bV4AlphaMask;

        /// <summary>
        /// The color space of the DIB. The following table lists the value for <see cref="bV4CSType"/>.
        /// <see cref="LCS_CALIBRATED_RGB"/>: This value indicates that endpoints and gamma values are given in the appropriate fields.
        /// See the <see cref="LOGCOLORSPACE"/> structure for information that defines a logical color space.
        /// </summary>
        public DWORD bV4CSType;

        /// <summary>
        /// A <see cref="CIEXYZTRIPLE"/> structure that specifies the x, y, and z coordinates of the three colors
        /// that correspond to the red, green, and blue endpoints for the logical color space associated with the bitmap.
        /// This member is ignored unless the <see cref="bV4CSType"/> member specifies <see cref="LCS_CALIBRATED_RGB"/>.
        /// Note
        /// A color space is a model for representing color numerically in terms of three or more coordinates.
        /// For example, the RGB color space represents colors in terms of the red, green, and blue coordinates.
        /// </summary>
        public CIEXYZTRIPLE bV4Endpoints;

        /// <summary>
        /// Tone response curve for red.
        /// This member is ignored unless color values are calibrated RGB values and <see cref="bV4CSType"/> is set to <see cref="LCS_CALIBRATED_RGB"/>.
        /// Specify in unsigned fixed 16.16 format. The upper 16 bits are the unsigned integer value. The lower 16 bits are the fractional part.
        /// </summary>
        public DWORD bV4GammaRed;

        /// <summary>
        /// Tone response curve for green.
        /// Used if <see cref="bV4CSType"/> is set to <see cref="LCS_CALIBRATED_RGB"/>.
        /// Specify in unsigned fixed 16.16 format. The upper 16 bits are the unsigned integer value.
        /// The lower 16 bits are the fractional part.
        /// </summary>
        public DWORD bV4GammaGreen;

        /// <summary>
        /// Tone response curve for blue.
        /// Used if <see cref="bV4CSType"/> is set to <see cref="LCS_CALIBRATED_RGB"/>.
        /// Specify in unsigned fixed 16.16 format. The upper 16 bits are the unsigned integer value. The lower 16 bits are the fractional part.
        /// </summary>
        public DWORD bV4GammaBlue;
    }
}
