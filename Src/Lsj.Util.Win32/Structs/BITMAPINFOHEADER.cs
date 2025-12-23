using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.BitmapCompressions;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="BITMAPINFOHEADER"/> structure contains information about the dimensions and color format of a device-independent bitmap (DIB).
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-bitmapinfoheader"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Color Tables
    /// </para>
    /// <para>
    /// The <see cref="BITMAPINFOHEADER"/> structure may be followed by an array of palette entries or color masks.
    /// The rules depend on the value of <see cref="biCompression"/>.
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// If <see cref="biCompression"/> equals <see cref="BI_RGB"/> and the bitmap uses 8 bpp or less,
    /// the bitmap has a color table immediately following the <see cref="BITMAPINFOHEADER"/> structure.
    /// The color table consists of an array of <see cref="RGBQUAD"/> values.
    /// The size of the array is given by the <see cref="biClrUsed"/> member.
    /// If <see cref="biClrUsed"/> is zero, the array contains the maximum number of colors for the given bitdepth; that is, 2^<see cref="biBitCount"/> colors.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// If <see cref="biCompression"/> equals <see cref="BI_BITFIELDS"/>,
    /// the bitmap uses three <see cref="DWORD"/> color masks (red, green, and blue, respectively), which specify the byte layout of the pixels.
    /// The 1 bits in each mask indicate the bits for that color within the pixel.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// If <see cref="biCompression"/> is a video FOURCC, the presence of a color table is implied by the video format.
    /// You should not assume that a color table exists when the bit depth is 8 bpp or less.
    /// However, some legacy components might assume that a color table is present.
    /// Therefore, if you are allocating a <see cref="BITMAPINFOHEADER"/> structure,
    /// it is recommended to allocate space for a color table when the bit depth is 8 bpp or less, even if the color table is not used.
    /// </description>
    /// </item>
    /// </list>
    /// <para>
    /// When the <see cref="BITMAPINFOHEADER"/> is followed by a color table or a set of color masks,
    /// you can use the <see cref="BITMAPINFO"/> structure to reference the color table of the color masks.
    /// The <see cref="BITMAPINFO"/> structure is defined as follows:
    /// </para>
    /// <code>
    /// typedef struct tagBITMAPINFO {
    ///     BITMAPINFOHEADER bmiHeader;
    ///     RGBQUAD bmiColors[1];
    /// } BITMAPINFO;
    /// </code>
    /// <para>
    /// If you cast the <see cref="BITMAPINFOHEADER"/> to a <see cref="BITMAPINFO"/>,
    /// the <see cref="BITMAPINFO.bmiHeader"/> member refers to the <see cref="BITMAPINFOHEADER"/> and
    /// the <see cref="BITMAPINFO.bmiColors"/> member refers to the first entry in the color table, or the first color mask.
    /// </para>
    /// <para>
    /// Be aware that if the bitmap uses a color table or color masks,
    /// then the size of the entire format structure (the <see cref="BITMAPINFOHEADER"/> plus the color information)
    /// is not equal to <code>sizeof(BITMAPINFOHEADER)</code> or <code>sizeof(BITMAPINFO)</code>.
    /// You must calculate the actual size for each instance.
    /// </para>
    /// <para>
    /// Calculating Surface Stride
    /// </para>
    /// <para>
    /// In an uncompressed bitmap, the stride is the number of bytes needed to go from the start of one row of pixels to the start of the next row.
    /// The image format defines a minimum stride for an image.
    /// In addition, the graphics hardware might require a larger stride for the surface that contains the image.
    /// </para>
    /// <para>
    /// For uncompressed RGB formats, the minimum stride is always the image width in bytes, rounded up to the nearest <see cref="DWORD"/>.
    /// To calculate the stride and image size, you can use the <see cref="GDI_DIBWIDTHBYTES"/> and/or <see cref="GDI_DIBSIZE"/> macros,
    /// or the following formula:
    /// </para>
    /// <code>
    /// stride = ((((biWidth * biBitCount) + 31) &amp; ~31) >> 3);
    /// biSizeImage = abs(biHeight) * stride;
    /// </code>
    /// <para>
    /// For YUV formats, there is no general rule for calculating the minimum stride.
    /// You must understand the rules for the particular YUV format.
    /// For a description of the most common YUV formats, see Recommended 8-Bit YUV Formats for Video Rendering.
    /// </para>
    /// <para>
    /// Decoders and video sources should propose formats where biWidth is the width of the image in pixels.
    /// If the video renderer requires a surface stride that is larger than the default image stride,
    /// it modifies the proposed media type by setting the following values:
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// It sets <see cref="biWidth"/> equal to the surface stride in pixels.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// It sets the <see cref="rcTarget"/> member of the <see cref="VIDEOINFOHEADER"/> or <see cref="VIDEOINFOHEADER2"/> structure equal to the image width, in pixels.
    /// </description>
    /// </item>
    /// </list>
    /// <para>
    /// Then the video renderer proposes the modified format by calling <see cref="IPin.QueryAccept"/> on the upstream pin.
    /// For more information about this mechanism, see Dynamic Format Changes.
    /// </para>
    /// <para>
    /// If there is padding in the image buffer, never dereference a pointer into the memory that has been reserved for the padding.
    /// If the image buffer has been allocated in video memory, the padding might not be readable memory.
    /// </para>
    /// </remarks>
    [Obsolete("The feature associated with this page, DirectShow, is a legacy feature. " +
            "It has been superseded by MediaPlayer, IMFMediaEngine, and Audio/Video Capture in Media Foundation. " +
            "Those features have been optimized for Windows 10 and Windows 11. " +
            "Microsoft strongly recommends that new code use MediaPlayer, " +
            "IMFMediaEngine and Audio/Video Capture in Media Foundation instead of DirectShow, when possible. " +
            "Microsoft suggests that existing code that uses the legacy APIs be rewritten to use the new APIs if possible.")]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct BITMAPINFOHEADER
    {
        /// <summary>
        /// Specifies the number of bytes required by the structure.
        /// This value does not include the size of the color table or the size of the color masks,
        /// if they are appended to the end of structure.
        /// See Remarks.
        /// </summary>
        public DWORD biSize;

        /// <summary>
        /// Specifies the width of the bitmap, in pixels.
        /// For information about calculating the stride of the bitmap, see Remarks.
        /// </summary>
        public LONG biWidth;

        /// <summary>
        /// <para>
        /// Specifies the height of the bitmap, in pixels.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// For uncompressed RGB bitmaps, if <see cref="biHeight"/> is positive, the bitmap is a bottom-up DIB with the origin at the lower left corner.
        /// If <see cref="biHeight"/> is negative, the bitmap is a top-down DIB with the origin at the upper left corner.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// For YUV bitmaps, the bitmap is always top-down, regardless of the sign of <see cref="biHeight"/>.
        /// Decoders should offer YUV formats with positive <see cref="biHeight"/>,
        /// but for backward compatibility they should accept YUV formats with either positive or negative <see cref="biHeight"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// For compressed formats, <see cref="biHeight"/> must be positive, regardless of image orientation.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        public LONG biHeight;

        /// <summary>
        /// Specifies the number of planes for the target device.
        /// This value must be set to 1.
        /// </summary>
        public WORD biPlanes;

        /// <summary>
        /// Specifies the number of bits per pixel (bpp).
        /// For uncompressed formats, this value is the average number of bits per pixel.
        /// For compressed formats, this value is the implied bit depth of the uncompressed image, after the image has been decoded.
        /// </summary>
        public WORD biBitCount;

        /// <summary>
        /// <para>
        /// For compressed video and YUV formats, this member is a FOURCC code, specified as a <see cref="DWORD"/> in little-endian order.
        /// For example, YUYV video has the FOURCC 'VYUY' or 0x56595559.
        /// For more information, see FOURCC Codes.
        /// </para>
        /// <para>
        /// For uncompressed RGB formats, the following values are possible:
        /// </para>
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
        /// <see cref="BI_RGB"/>
        /// </term>
        /// <term>
        /// Uncompressed RGB.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BI_BITFIELDS"/>
        /// </term>
        /// <term>
        /// Uncompressed RGB with color masks. Valid for 16-bpp and 32-bpp bitmaps.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// See Remarks for more information. Note that <see cref="BI_JPEG"/> and <see cref="BI_PNG"/> are not valid video formats.
        /// </para>
        /// <para>
        /// For 16-bpp bitmaps, if <see cref="biCompression"/> equals <see cref="BI_RGB"/>, the format is always RGB 555.
        /// If <see cref="biCompression"/> equals <see cref="BI_BITFIELDS"/>, the format is either RGB 555 or RGB 565.
        /// Use the subtype GUID in the <see cref="AM_MEDIA_TYPE"/> structure to determine the specific RGB type.
        /// </para>
        /// </summary>
        public BitmapCompressions biCompression;

        /// <summary>
        /// Specifies the size, in bytes, of the image.
        /// This can be set to 0 for uncompressed RGB bitmaps.
        /// </summary>
        public DWORD biSizeImage;

        /// <summary>
        /// Specifies the horizontal resolution, in pixels per meter, of the target device for the bitmap.
        /// </summary>
        public LONG biXPelsPerMeter;

        /// <summary>
        /// Specifies the vertical resolution, in pixels per meter, of the target device for the bitmap.
        /// </summary>
        public LONG biYPelsPerMeter;

        /// <summary>
        /// Specifies the number of color indices in the color table that are actually used by the bitmap.
        /// See Remarks for more information.
        /// </summary>
        public DWORD biClrUsed;

        /// <summary>
        /// Specifies the number of color indices that are considered important for displaying the bitmap.
        /// If this value is zero, all colors are important.
        /// </summary>
        public DWORD biClrImportant;
    }
}
