using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.Compression;
using static Lsj.Util.Win32.Enums.GamutMappingIntent;
using static Lsj.Util.Win32.Enums.LogicalColorSpace;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="BITMAPV5HEADER"/> structure is the bitmap information header file.
    /// It is an extended version of the <see cref="BITMAPINFOHEADER"/> structure.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/ns-wingdi-bitmapv5header"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// If <see cref="bV5Height"/> is negative, indicating a top-down DIB,
    /// <see cref="bV5Compression"/> must be either <see cref="BI_RGB"/> or <see cref="BI_BITFIELDS"/>.
    /// Top-down DIBs cannot be compressed.
    /// The Independent Color Management interface (ICM) 2.0 allows International Color Consortium (ICC) color profiles
    /// to be linked or embedded in DIBs (DIBs).
    /// See Using Structures for more information.
    /// When a DIB is loaded into memory, the profile data (if present) should follow the color table,
    /// and the <see cref="bV5ProfileData"/> should provide the offset of the profile data from the beginning of the <see cref="BITMAPV5HEADER"/> structure.
    /// The value stored in <see cref="bV5ProfileData"/> will be different from the value returned
    /// by the sizeof operator given the <see cref="BITMAPV5HEADER"/> argument,
    /// because <see cref="bV5ProfileData"/> is the offset in bytes
    /// from the beginning of the <see cref="BITMAPV5HEADER"/> structure to the start of the profile data.
    /// (Bitmap bits do not follow the color table in memory).
    /// Applications should modify the <see cref="bV5ProfileData"/> member after loading the DIB into memory.
    /// For packed DIBs, the profile data should follow the bitmap bits similar to the file format.
    /// The <see cref="bV5ProfileData"/> member should still give the offset of the profile data from the beginning of the <see cref="BITMAPV5HEADER"/>.
    /// Applications should access the profile data only when <see cref="bV5Size"/> equals the size of the <see cref="BITMAPV5HEADER"/>
    /// and <see cref="bV5CSType"/> equals <see cref="PROFILE_EMBEDDED"/> or <see cref="PROFILE_LINKED"/>.
    /// If a profile is linked, the path of the profile can be any fully qualified name (including a network path)
    /// that can be opened using the <see cref="CreateFile"/> function.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct BITMAPV5HEADER
    {
        /// <summary>
        /// The number of bytes required by the structure.
        /// Applications should use this member to determine which bitmap information header structure is being used.
        /// </summary>
        public DWORD bV5Size;

        /// <summary>
        /// The width of the bitmap, in pixels.
        /// If <see cref="bV5Compression"/> is <see cref="BI_JPEG"/> or <see cref="BI_PNG"/>,
        /// the <see cref="bV5Width"/> member specifies the width of the decompressed JPEG or PNG image in pixels.
        /// </summary>
        public LONG bV5Width;

        /// <summary>
        /// The height of the bitmap, in pixels.
        /// If the value of <see cref="bV5Height"/> is positive, the bitmap is a bottom-up DIB and its origin is the lower-left corner.
        /// If <see cref="bV5Height"/> value is negative, the bitmap is a top-down DIB and its origin is the upper-left corner.
        /// If <see cref="bV5Height"/> is negative, indicating a top-down DIB, <see cref="bV5Compression"/>
        /// must be either <see cref="BI_RGB"/> or <see cref="BI_BITFIELDS"/>.
        /// Top-down DIBs cannot be compressed.
        /// If <see cref="bV5Compression"/> is <see cref="BI_JPEG"/> or <see cref="BI_PNG"/>,
        /// the <see cref="bV5Height"/> member specifies the height of the decompressed JPEG or PNG image in pixels.
        /// </summary>
        public LONG bV5Height;

        /// <summary>
        /// The number of planes for the target device. This value must be set to 1.
        /// </summary>
        public WORD bV5Planes;

        /// <summary>
        /// The number of bits that define each pixel and the maximum number of colors in the bitmap.
        /// This member must be one of the following values.
        /// 0:
        /// The number of bits-per-pixel is specified or is implied by the JPEG or PNG format.
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
        /// If the <see cref="bV5Compression"/> member of the <see cref="BITMAPV5HEADER"/> is <see cref="BI_RGB"/>,
        /// the <see cref="BITMAPINFO.bmiColors"/> member of <see cref="BITMAPINFO"/> is <see langword="null"/>.
        /// Each WORD in the bitmap array represents a single pixel.
        /// The relative intensities of red, green, and blue are represented with five bits for each color component.
        /// The value for blue is in the least significant five bits, followed by five bits each for green and red.
        /// The most significant bit is not used.
        /// The <see cref="BITMAPINFO.bmiColors"/> color table is used for optimizing colors used on palette-based devices,
        /// and must contain the number of entries specified by the <see cref="bV5ClrUsed"/> member of the <see cref="BITMAPINFOHEADER"/>.
        /// If the <see cref="bV5Compression"/> member of the <see cref="BITMAPINFOHEADER"/> is <see cref="BI_BITFIELDS"/>,
        /// the <see cref="BITMAPINFO.bmiColors"/> member contains three DWORD color masks that specify the red, green, and blue components,
        /// respectively, of each pixel.
        /// Each WORD in the bitmap array represents a single pixel.
        /// When the <see cref="bV5Compression"/> member is <see cref="BI_BITFIELDS"/>,
        /// bits set in each DWORD mask must be contiguous and should not overlap the bits of another mask.
        /// All the bits in the pixel do not have to be used.
        /// 24:
        /// The bitmap has a maximum of 2^24 colors, and the <see cref="BITMAPINFO.bmiColors"/> member of <see cref="BITMAPINFO"/> is <see langword="null"/>.
        /// Each 3-byte triplet in the bitmap array represents the relative intensities of blue, green, and red, respectively, for a pixel.
        /// The <see cref="BITMAPINFO.bmiColors"/> color table is used for optimizing colors used on palette-based devices,
        /// and must contain the number of entries specified by the <see cref="bV5ClrUsed"/> member of the <see cref="BITMAPV5HEADER "/>.
        /// 32:
        /// The bitmap has a maximum of 2^32 colors.
        /// If the <see cref="bV5ClrUsed"/> member of the <see cref="BITMAPV5HEADER"/> is <see cref="BI_RGB"/>,
        /// the <see cref="BITMAPINFO.bmiColors"/> member of <see cref="BITMAPINFO"/> is <see langword="null"/>.
        /// Each DWORD in the bitmap array represents the relative intensities of blue, green, and red for a pixel.
        /// The value for blue is in the least significant 8 bits, followed by 8 bits each for green and red.
        /// The high byte in each DWORD is not used.
        /// The <see cref="BITMAPINFO.bmiColors"/> color table is used for optimizing colors used on palette-based devices,
        /// and must contain the number of entries specified by the <see cref="bV5ClrUsed "/> member of the <see cref="BITMAPV5HEADER"/>.
        /// If the <see cref="bV5Compression "/> member of the <see cref="BITMAPV5HEADER"/> is <see cref="BI_BITFIELDS"/>,
        /// the <see cref="BITMAPINFO.bmiColors"/> member contains three DWORD color masks that specify the red, green, and blue components,
        /// respectively, of each pixel.
        /// Each DWORD in the bitmap array represents a single pixel.
        /// </summary>
        public WORD bV5BitCount;

        /// <summary>
        /// Specifies that the bitmap is not compressed.
        /// The <see cref="bV5RedMask"/>, <see cref="bV5GreenMask"/>, and <see cref="bV5BlueMask"/> members
        /// specify the red, green, and blue components of each pixel.
        /// This is valid when used with 16- and 32-bpp bitmaps.
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
        public Compression bV5Compression;

        /// <summary>
        /// The size, in bytes, of the image.
        /// This may be set to zero for <see cref="BI_RGB"/> bitmaps.
        /// If <see cref="bV5Compression"/> is <see cref="BI_JPEG"/> or <see cref="BI_PNG"/>,
        /// <see cref="bV5SizeImage"/> is the size of the JPEG or PNG image buffer.
        /// </summary>
        public DWORD bV5SizeImage;

        /// <summary>
        /// The horizontal resolution, in pixels-per-meter, of the target device for the bitmap.
        /// An application can use this value to select a bitmap from a resource group that best matches the characteristics of the current device.
        /// </summary>
        public LONG bV5XPelsPerMeter;

        /// <summary>
        /// The vertical resolution, in pixels-per-meter, of the target device for the bitmap.
        /// </summary>
        public LONG bV5YPelsPerMeter;

        /// <summary>
        /// The number of color indexes in the color table that are actually used by the bitmap.
        /// If this value is zero, the bitmap uses the maximum number of colors corresponding to the value of the <see cref="bV5BitCount"/> member
        /// for the compression mode specified by <see cref="bV5Compression"/>.
        /// If <see cref="bV5ClrUsed"/> is nonzero and <see cref="bV5BitCount"/> is less than 16,
        /// the <see cref="bV5ClrUsed"/> member specifies the actual number of colors the graphics engine or device driver accesses.
        /// If <see cref="bV5BitCount"/> is 16 or greater, the <see cref="bV5ClrUsed"/> member specifies the size of the color table
        /// used to optimize performance of the system color palettes.
        /// If <see cref="bV5BitCount"/> equals 16 or 32, the optimal color palette starts immediately following the <see cref="BITMAPV5HEADER"/>.
        /// If <see cref="bV5ClrUsed"/> is nonzero, the color table is used on palettized devices,
        /// and <see cref="bV5ClrUsed"/> specifies the number of entries.
        /// </summary>
        public DWORD bV5ClrUsed;

        /// <summary>
        /// The number of color indexes that are required for displaying the bitmap.
        /// If this value is zero, all colors are required.
        /// </summary>
        public DWORD bV5ClrImportant;

        /// <summary>
        /// Color mask that specifies the red component of each pixel, valid only if <see cref="bV5Compression"/> is set to <see cref="BI_BITFIELDS"/>.
        /// </summary>
        public DWORD bV5RedMask;

        /// <summary>
        /// Color mask that specifies the green component of each pixel, valid only if <see cref="bV5Compression"/> is set to <see cref="BI_BITFIELDS"/>.
        /// </summary>
        public DWORD bV5GreenMask;

        /// <summary>
        /// Color mask that specifies the blue component of each pixel, valid only if <see cref="bV5Compression"/> is set to <see cref="BI_BITFIELDS"/>.
        /// </summary>
        public DWORD bV5BlueMask;

        /// <summary>
        /// Color mask that specifies the alpha component of each pixel.
        /// </summary>
        public DWORD bV5AlphaMask;

        /// <summary>
        /// The color space of the DIB.
        /// The following table specifies the values for <see cref="bV5CSType"/>.
        /// <see cref="LCS_CALIBRATED_RGB"/>: This value implies that endpoints and gamma values are given in the appropriate fields.
        /// <see cref="LCS_sRGB"/>: Specifies that the bitmap is in sRGB color space.
        /// <see cref="LCS_WINDOWS_COLOR_SPACE"/>: 	This value indicates that the bitmap is in the system default color space, sRGB.
        /// <see cref="PROFILE_LINKED"/>:
        /// This value indicates that <see cref="bV5ProfileData"/> points to the file name of the profile to use (gamma and endpoints values are ignored).
        /// <see cref="PROFILE_EMBEDDED"/>:
        /// This value indicates that <see cref="bV5ProfileData"/> points to a memory buffer
        /// that contains the profile to be used (gamma and endpoints values are ignored).
        /// See the <see cref="LOGCOLORSPACE"/> structure for information that defines a logical color space.
        /// </summary>
        public LogicalColorSpace bV5CSType;

        /// <summary>
        /// A <see cref="CIEXYZTRIPLE"/> structure that specifies the x, y, and z coordinates of the three colors
        /// that correspond to the red, green, and blue endpoints for the logical color space associated with the bitmap.
        /// This member is ignored unless the <see cref="bV5CSType"/> member specifies <see cref="LCS_CALIBRATED_RGB"/>.
        /// </summary>
        public CIEXYZTRIPLE bV5Endpoints;

        /// <summary>
        /// Toned response curve for red.
        /// Used if <see cref="bV5CSType"/> is set to <see cref="LCS_CALIBRATED_RGB"/>.
        /// Specify in unsigned fixed 16.16 format.
        /// The upper 16 bits are the unsigned integer value.
        /// The lower 16 bits are the fractional part.
        /// </summary>
        public DWORD bV5GammaRed;

        /// <summary>
        /// Toned response curve for green.
        /// Used if <see cref="bV5CSType"/> is set to <see cref="LCS_CALIBRATED_RGB"/>.
        /// Specify in unsigned fixed 16.16 format.
        /// The upper 16 bits are the unsigned integer value.
        /// The lower 16 bits are the fractional part.
        /// </summary>
        public DWORD bV5GammaGreen;

        /// <summary>
        /// Toned response curve for blue.
        /// Used if <see cref="bV5CSType"/> is set to <see cref="LCS_CALIBRATED_RGB"/>.
        /// Specify in unsigned fixed 16.16 format.
        /// The upper 16 bits are the unsigned integer value.
        /// The lower 16 bits are the fractional part.
        /// </summary>
        public DWORD bV5GammaBlue;

        /// <summary>
        /// Rendering intent for bitmap. This can be one of the following values.
        /// <see cref="LCS_GM_ABS_COLORIMETRIC"/>   Match       Absolute Colorimetric
        /// Maintains the white point. Matches the colors to their nearest color in the destination gamut.
        /// <see cref="LCS_GM_BUSINESS"/>           Graphic     Saturation
        /// Maintains saturation. Used for business charts and other situations in which undithered colors are required.
        /// <see cref="LCS_GM_GRAPHICS"/>           Proof       Relative Colorimetric
        /// Maintains colorimetric match. Used for graphic designs and named colors.
        /// <see cref="LCS_GM_IMAGES"/>             Picture     Perceptual
        /// Maintains contrast. Used for photographs and natural images.
        /// </summary>
        public GamutMappingIntent bV5Intent;

        /// <summary>
        /// The offset, in bytes, from the beginning of the <see cref="BITMAPV5HEADER"/> structure to the start of the profile data.
        /// If the profile is embedded, profile data is the actual profile, and it is linked.
        /// (The profile data is the null-terminated file name of the profile.)
        /// This cannot be a Unicode string.
        /// It must be composed exclusively of characters from the Windows character set (code page 1252).
        /// These profile members are ignored unless the <see cref="bV5CSType"/> member
        /// specifies <see cref="PROFILE_LINKED"/> or <see cref="PROFILE_EMBEDDED"/>.
        /// </summary>
        public DWORD bV5ProfileData;

        /// <summary>
        /// Size, in bytes, of embedded profile data.
        /// </summary>
        public DWORD bV5ProfileSize;

        /// <summary>
        /// This member has been reserved. Its value should be set to zero.
        /// </summary>
        public DWORD bV5Reserved;
    }
}
