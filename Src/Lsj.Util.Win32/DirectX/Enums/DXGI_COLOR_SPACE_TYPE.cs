using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies color space types.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgicommon/ne-dxgicommon-dxgi_color_space_type"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This enum is used within DXGI in the <see cref="IDXGISwapChain3.CheckColorSpaceSupport"/>,
    /// <see cref="IDXGISwapChain3.SetColorSpace1"/> and <see cref="IDXGIOutput4.CheckOverlayColorSpaceSupport"/> methods.
    /// It is also referenced in D3D11 video methods such as <see cref="ID3D11VideoContext1.VideoProcessorSetOutputColorSpace1"/>,
    /// and D2D methods such as <see cref="ID2D1DeviceContext2.CreateImageSourceFromDxgi"/>.
    /// </para>
    /// <para>
    /// The following color parameters are defined:
    /// </para>
    /// <para>
    /// Colorspace
    /// </para>
    /// <para>
    /// Defines the color space of the color channel data. 
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Defined Values
    /// </term>
    /// <term>
    /// Notation in color space enumeration
    /// </term>
    /// <term>
    /// Comments
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// RGB
    /// </term>
    /// <term>
    /// _RGB_
    /// </term>
    /// <term>
    /// The red/green/blue color space color channel.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// YCbCr
    /// </term>
    /// <term>
    /// _YCbCr_
    /// </term>
    /// <term>
    /// Three channel color model which splits luma (brightness) from chroma (color).
    /// YUV technically refers to analog signals and YCbCr to digital, but they are used interchangeably.
    /// </term>
    /// </item>
    /// </list>
    /// <para>
    /// Range
    /// </para>
    /// <para>
    /// Indicates which integer range corresponds to the floating point [0..1] range of the data.
    /// For video, integer YCbCr data with ranges of [16..235] or [8..247] are usually mapped to normalized YCbCr with ranges of [0..1] or [-0.5..0.5]. 
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Defined_Values
    /// </term>
    /// <term>
    /// Notation in color space numeration
    /// </term>
    /// <term>
    /// Comments
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// <para>
    /// 8 bit: 0-255
    /// </para>
    /// <para>
    /// 10 bit: 0-1023
    /// </para>
    /// <para>
    /// 12 bit: 0-4095
    /// </para>
    /// </term>
    /// <term>
    /// _FULL_
    /// </term>
    /// <term>
    /// PC desktop content and images.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <para>
    /// 8 bit:16-235
    /// </para>
    /// <para>
    /// 10 bit: 64-940
    /// </para>
    /// <para>
    /// 12 bit: 256 - 3760
    /// </para>
    /// </term>
    /// <term>
    /// _STUDIO_
    /// </term>
    /// <term>
    /// Often used in video. Enables the calibration of white and black between displays.
    /// </term>
    /// </item>
    /// </list>
    /// <para>
    /// Gamma
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Defined Values
    /// </term>
    /// <term>
    /// Notation in color space numeration
    /// </term>
    /// <term>
    /// Comments
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// 1.0
    /// </term>
    /// <term>
    /// _G10_
    /// </term>
    /// <term>
    /// Linear light levels.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// 2.2
    /// </term>
    /// <term>
    /// _G22_
    /// </term>
    /// <term>
    /// Commonly used for sRGB and BT.709 (linear segment + 2.4).
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// 2084
    /// </term>
    /// <term>
    /// _G2084_
    /// </term>
    /// <term>
    /// See SMPTE ST.2084 (Perceptual Quantization)
    /// </term>
    /// </item>
    /// </list>
    /// <para>
    /// Siting
    /// </para>
    /// <para>
    /// "Siting" indicates a horizontal or vertical shift of the chrominance channels relative to the luminance channel.
    /// "Cositing" indicates values are sited between pixels in the vertical or horizontal direction (also known as being "sited interstitially"). 
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Defined Values
    /// </term>
    /// <term>
    /// Notation in color space enumeration
    /// </term>
    /// <term>
    /// Comments
    /// </term>
    /// <term>
    /// For Example
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// Image
    /// </term>
    /// <term>
    /// _NONE_
    /// </term>
    /// <term>
    /// The U and V planes are aligned vertically.
    /// </term>
    /// <term>
    /// MPEG1, JPG
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Video
    /// </term>
    /// <term>
    /// _LEFT_
    /// </term>
    /// <term>
    /// Chroma samples are aligned horizontally with the luma samples, or with multiples of the luma samples.
    /// The U and V planes are aligned vertically.
    /// </term>
    /// <term>
    /// MPEG2, MPEG4
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Video
    /// </term>
    /// <term>
    /// _TOPLEFT_
    /// </term>
    /// <term>
    /// "Top left" means that the sampling point is the top left pixel (usually of a 2x2 pixel block).
    /// Chroma samples are aligned horizontally with the luma samples, or with multiples of the luma samples.
    /// Chroma samples are also aligned vertically with the luma samples, or with multiples of the luma samples.
    /// </term>
    /// <term>
    /// UHD Blu-Ray
    /// </term>
    /// </item>
    /// </list>
    /// <para>
    /// For more information on siting, refer to the <see cref="MFVideoChromaSubsampling"/> enum.
    /// </para>
    /// <para>
    /// Primaries
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Defined Values
    /// </term>
    /// <term>
    /// Notation in color space enumeration
    /// </term>
    /// <term>
    /// Comments
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// BT.601
    /// </term>
    /// <term>
    /// _P601
    /// </term>
    /// <term>
    /// Standard defining digital encoding of SDTV video.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// BT.709
    /// </term>
    /// <term>
    /// _P709
    /// </term>
    /// <term>
    /// Standard defining digital encoding of HDTV video.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// BT.2020
    /// </term>
    /// <term>
    /// _P2020
    /// </term>
    /// <term>
    /// Standard defining ultra-high definition television (UHDTV).
    /// </term>
    /// </item>
    /// </list>
    /// <para>
    /// Transfer Matrix
    /// </para>
    /// <para>
    /// In most cases, the transfer matrix can be determined from the primaries. For some cases it must be explicitly specified as described below: 
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Defined Values
    /// </term>
    /// <term>
    /// Notation in color space enumeration
    /// </term>
    /// <term>
    /// <see cref="Comments"/>
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// BT.601
    /// </term>
    /// <term>
    /// _X601
    /// </term>
    /// <term>
    /// Standard defining digital encoding of SDTV video.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// BT.709
    /// </term>
    /// <term>
    /// _X709
    /// </term>
    /// <term>
    /// Standard defining digital encoding of HDTV video.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// BT.2020
    /// </term>
    /// <term>
    /// _X2020
    /// </term>
    /// <term>
    /// Standard defining ultra-high definition television (UHDTV).
    /// </term>
    /// </item>
    /// </list>
    /// <para>
    /// Subsampling and the layout of the color channels are inferred from the surface format.
    /// </para>
    /// </remarks>
    public enum DXGI_COLOR_SPACE_TYPE
    {
        /// <summary>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Property
        /// </term>
        /// <term>
        /// Value
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Colorspace
        /// </term>
        /// <term>
        /// RGB
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Range
        /// </term>
        /// <term>
        /// 0-255
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Gamma
        /// </term>
        /// <term>
        /// 2.2
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Siting
        /// </term>
        /// <term>
        /// Image
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Primaries
        /// </term>
        /// <term>
        /// BT.709
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// This is the standard definition for sRGB.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This is intended to be implemented with sRGB gamma (linear segment + 2.4 power), which is approximately aligned with a gamma 2.2 curve.
        /// </para>
        /// <para>
        /// This is usually used with 8 or 10 bit color channels.
        /// </para>
        /// </summary>
        DXGI_COLOR_SPACE_RGB_FULL_G22_NONE_P709 = 0,

        /// <summary>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Property
        /// </term>
        /// <term>
        /// Value
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Colorspace
        /// </term>
        /// <term>
        /// RGB
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Range
        /// </term>
        /// <term>
        /// 0-255
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Gamma
        /// </term>
        /// <term>
        /// 1.0
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Siting
        /// </term>
        /// <term>
        /// Image
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Primaries
        /// </term>
        /// <term>
        /// BT.709
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// This is the standard definition for scRGB, and is usually used with 16 bit integer, 16 bit floating point, or 32 bit floating point color channels.
        /// </para>
        /// </summary>
        DXGI_COLOR_SPACE_RGB_FULL_G10_NONE_P709 = 1,

        /// <summary>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Property
        /// </term>
        /// <term>
        /// Value
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Colorspace
        /// </term>
        /// <term>
        /// RGB
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Range
        /// </term>
        /// <term>
        /// 16-235
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Gamma
        /// </term>
        /// <term>
        /// 2.2
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Siting
        /// </term>
        /// <term>
        /// Image
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Primaries
        /// </term>
        /// <term>
        /// BT.709
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// This is the standard definition for ITU-R Recommendation BT.709.
        /// Note that due to the inclusion of a linear segment, the transfer curve looks similar to a pure exponential gamma of 1.9.
        /// </para>
        /// <para>
        /// This is usually used with 8 or 10 bit color channels.
        /// </para>
        /// </summary>
        DXGI_COLOR_SPACE_RGB_STUDIO_G22_NONE_P709 = 2,

        /// <summary>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Property
        /// </term>
        /// <term>
        /// Value
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Colorspace
        /// </term>
        /// <term>
        /// RGB
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Range
        /// </term>
        /// <term>
        /// 16-235
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Gamma
        /// </term>
        /// <term>
        /// 2.2
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Siting
        /// </term>
        /// <term>
        /// Image
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Primaries
        /// </term>
        /// <term>
        /// BT.2020
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// This is usually used with 10 or 12 bit color channels.
        /// </para>
        /// </summary>
        DXGI_COLOR_SPACE_RGB_STUDIO_G22_NONE_P2020 = 3,

        /// <summary>
        /// Reserved.
        /// </summary>
        DXGI_COLOR_SPACE_RESERVED = 4,

        /// <summary>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Property
        /// </term>
        /// <term>
        /// Value
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Colorspace
        /// </term>
        /// <term>
        /// YCbCr
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Range
        /// </term>
        /// <term>
        /// 0-255
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Gamma
        /// </term>
        /// <term>
        /// 2.2
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Siting
        /// </term>
        /// <term>
        /// Image
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Primaries
        /// </term>
        /// <term>
        /// BT.709
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Transfer Matrix
        /// </term>
        /// <term>
        /// BT.601
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// This definition is commonly used for JPG, and is usually used with 8, 10, or 12 bit color channels.
        /// </para>
        /// </summary>
        DXGI_COLOR_SPACE_YCBCR_FULL_G22_NONE_P709_X601 = 5,

        /// <summary>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Property
        /// </term>
        /// <term>
        /// Value
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Colorspace
        /// </term>
        /// <term>
        /// YCbCr
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Range
        /// </term>
        /// <term>
        /// 16-235
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Gamma
        /// </term>
        /// <term>
        /// 2.2
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Siting
        /// </term>
        /// <term>
        /// Video
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Primaries
        /// </term>
        /// <term>
        /// BT.601
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// This definition is commonly used for MPEG2, and is usually used with 8, 10, or 12 bit color channels.
        /// </para>
        /// </summary>
        DXGI_COLOR_SPACE_YCBCR_STUDIO_G22_LEFT_P601 = 6,

        /// <summary>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Property
        /// </term>
        /// <term>
        /// Value
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Colorspace
        /// </term>
        /// <term>
        /// YCbCr
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Range
        /// </term>
        /// <term>
        /// 0-255
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Gamma
        /// </term>
        /// <term>
        /// 2.2
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Siting
        /// </term>
        /// <term>
        /// Video
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Primaries
        /// </term>
        /// <term>
        /// BT.601
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// This is sometimes used for H.264 camera capture, and is usually used with 8, 10, or 12 bit color channels.
        /// </para>
        /// </summary>
        DXGI_COLOR_SPACE_YCBCR_FULL_G22_LEFT_P601 = 7,

        /// <summary>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Property
        /// </term>
        /// <term>
        /// Value
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Colorspace
        /// </term>
        /// <term>
        /// YCbCr
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Range
        /// </term>
        /// <term>
        /// 16-235
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Gamma
        /// </term>
        /// <term>
        /// 2.2
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Siting
        /// </term>
        /// <term>
        /// Video
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Primaries
        /// </term>
        /// <term>
        /// BT.709
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// This definition is commonly used for H.264 and HEVC, and is usually used with 8, 10, or 12 bit color channels.
        /// </para>
        /// </summary>
        DXGI_COLOR_SPACE_YCBCR_STUDIO_G22_LEFT_P709 = 8,

        /// <summary>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Property
        /// </term>
        /// <term>
        /// Value
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Colorspace
        /// </term>
        /// <term>
        /// YCbCr
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Range
        /// </term>
        /// <term>
        /// 0-255
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Gamma
        /// </term>
        /// <term>
        /// 2.2
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Siting
        /// </term>
        /// <term>
        /// Video
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Primaries
        /// </term>
        /// <term>
        /// BT.709
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// This is sometimes used for H.264 camera capture, and is usually used with 8, 10, or 12 bit color channels.
        /// </para>
        /// </summary>
        DXGI_COLOR_SPACE_YCBCR_FULL_G22_LEFT_P709 = 9,

        /// <summary>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Property
        /// </term>
        /// <term>
        /// Value
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Colorspace
        /// </term>
        /// <term>
        /// YCbCr
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Range
        /// </term>
        /// <term>
        /// 16-235
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Gamma
        /// </term>
        /// <term>
        /// 2.2
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Siting
        /// </term>
        /// <term>
        /// Video
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Primaries
        /// </term>
        /// <term>
        /// BT.2020
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// This definition may be used by HEVC, and is usually used with 10 or 12 bit color channels.
        /// </para>
        /// </summary>
        DXGI_COLOR_SPACE_YCBCR_STUDIO_G22_LEFT_P2020 = 10,

        /// <summary>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Property
        /// </term>
        /// <term>
        /// Value
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Colorspace
        /// </term>
        /// <term>
        /// YCbCr
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Range
        /// </term>
        /// <term>
        /// 0-255
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Gamma
        /// </term>
        /// <term>
        /// 2.2
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Siting
        /// </term>
        /// <term>
        /// Video
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Primaries
        /// </term>
        /// <term>
        /// BT.2020
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// This is usually used with 10 or 12 bit color channels.
        /// </para>
        /// </summary>
        DXGI_COLOR_SPACE_YCBCR_FULL_G22_LEFT_P2020 = 11,

        /// <summary>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Property
        /// </term>
        /// <term>
        /// Value
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Colorspace
        /// </term>
        /// <term>
        /// RGB
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Range
        /// </term>
        /// <term>
        /// 0-255
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Gamma
        /// </term>
        /// <term>
        /// 2084
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Siting
        /// </term>
        /// <term>
        /// Image
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Primaries
        /// </term>
        /// <term>
        /// BT.2020
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// This is usually used with 10 or 12 bit color channels.
        /// </para>
        /// </summary>
        DXGI_COLOR_SPACE_RGB_FULL_G2084_NONE_P2020 = 12,

        /// <summary>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Property
        /// </term>
        /// <term>
        /// Value
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Colorspace
        /// </term>
        /// <term>
        /// YCbCr
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Range
        /// </term>
        /// <term>
        /// 16-235
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Gamma
        /// </term>
        /// <term>
        /// 2084
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Siting
        /// </term>
        /// <term>
        /// Video
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Primaries
        /// </term>
        /// <term>
        /// BT.2020
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// This is usually used with 10 or 12 bit color channels.
        /// </para>
        /// </summary>
        DXGI_COLOR_SPACE_YCBCR_STUDIO_G2084_LEFT_P2020 = 13,

        /// <summary>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Property
        /// </term>
        /// <term>
        /// Value
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Colorspace
        /// </term>
        /// <term>
        /// RGB
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Range
        /// </term>
        /// <term>
        /// 16-235
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Gamma
        /// </term>
        /// <term>
        /// 2084
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Siting
        /// </term>
        /// <term>
        /// Image
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Primaries
        /// </term>
        /// <term>
        /// BT.2020
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// This is usually used with 10 or 12 bit color channels.
        /// </para>
        /// </summary>
        DXGI_COLOR_SPACE_RGB_STUDIO_G2084_NONE_P2020 = 14,

        /// <summary>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Property
        /// </term>
        /// <term>
        /// Value
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Colorspace
        /// </term>
        /// <term>
        /// YCbCr
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Range
        /// </term>
        /// <term>
        /// 16-235
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Gamma
        /// </term>
        /// <term>
        /// 2.2
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Siting
        /// </term>
        /// <term>
        /// Video
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Primaries
        /// </term>
        /// <term>
        /// BT.2020
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// This is usually used with 10 or 12 bit color channels.
        /// </para>
        /// </summary>
        DXGI_COLOR_SPACE_YCBCR_STUDIO_G22_TOPLEFT_P2020 = 15,

        /// <summary>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Property
        /// </term>
        /// <term>
        /// Value
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Colorspace
        /// </term>
        /// <term>
        /// YCbCr
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Range
        /// </term>
        /// <term>
        /// 16-235
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Gamma
        /// </term>
        /// <term>
        /// 2084
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Siting
        /// </term>
        /// <term>
        /// Video
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Primaries
        /// </term>
        /// <term>
        /// BT.2020
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// This is usually used with 10 or 12 bit color channels.
        /// </para>
        /// </summary>
        DXGI_COLOR_SPACE_YCBCR_STUDIO_G2084_TOPLEFT_P2020 = 16,

        /// <summary>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Property
        /// </term>
        /// <term>
        /// Value
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Colorspace
        /// </term>
        /// <term>
        /// RGB
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Range
        /// </term>
        /// <term>
        /// 0-255
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Gamma
        /// </term>
        /// <term>
        /// 2.2
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Siting
        /// </term>
        /// <term>
        /// Image
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Primaries
        /// </term>
        /// <term>
        /// BT.2020
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// This is usually used with 10 or 12 bit color channels.
        /// </para>
        /// </summary>
        DXGI_COLOR_SPACE_RGB_FULL_G22_NONE_P2020 = 17,

        /// <summary>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Property
        /// </term>
        /// <term>
        /// Value
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Colorspace
        /// </term>
        /// <term>
        /// YCBCR
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Range
        /// </term>
        /// <term>
        /// 16-235
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Gamma
        /// </term>
        /// <term>
        /// HLG
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Siting
        /// </term>
        /// <term>
        /// Video
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Primaries
        /// </term>
        /// <term>
        /// BT.2020
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// This is usually used with 10 or 12 bit color channels.
        /// </para>
        /// </summary>
        DXGI_COLOR_SPACE_YCBCR_STUDIO_GHLG_TOPLEFT_P2020 = 18,

        /// <summary>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Property
        /// </term>
        /// <term>
        /// Value
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Colorspace
        /// </term>
        /// <term>
        /// YCBCR
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Range
        /// </term>
        /// <term>
        /// 0-255
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Gamma
        /// </term>
        /// <term>
        /// HLG
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Siting
        /// </term>
        /// <term>
        /// Video
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Primaries
        /// </term>
        /// <term>
        /// BT.2020
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// This is usually used with 10 or 12 bit color channels.
        /// </para>
        /// </summary>
        DXGI_COLOR_SPACE_YCBCR_FULL_GHLG_TOPLEFT_P2020 = 19,

        /// <summary>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Property
        /// </term>
        /// <term>
        /// Value
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Colorspace
        /// </term>
        /// <term>
        /// RGB
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Range
        /// </term>
        /// <term>
        /// 16-235
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Gamma
        /// </term>
        /// <term>
        /// 2.4
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Siting
        /// </term>
        /// <term>
        /// Image
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Primaries
        /// </term>
        /// <term>
        /// BT.709
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// This is usually used with 8, 10, or 12 bit color channels.
        /// </para>
        /// </summary>
        DXGI_COLOR_SPACE_RGB_STUDIO_G24_NONE_P709 = 20,

        /// <summary>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Property
        /// </term>
        /// <term>
        /// Value
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Colorspace
        /// </term>
        /// <term>
        /// RGB
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Range
        /// </term>
        /// <term>
        /// 16-235
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Gamma
        /// </term>
        /// <term>
        /// 2.4
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Siting
        /// </term>
        /// <term>
        /// Image
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Primaries
        /// </term>
        /// <term>
        /// BT.2020
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// This is usually used with 10 or 12 bit color channels.
        /// </para>
        /// </summary>
        DXGI_COLOR_SPACE_RGB_STUDIO_G24_NONE_P2020 = 21,

        /// <summary>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Property
        /// </term>
        /// <term>
        /// Value
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Colorspace
        /// </term>
        /// <term>
        /// YCBCR
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Range
        /// </term>
        /// <term>
        /// 16-235
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Gamma
        /// </term>
        /// <term>
        /// 2.4
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Siting
        /// </term>
        /// <term>
        /// Video
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Primaries
        /// </term>
        /// <term>
        /// BT.709
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// This is usually used with 8, 10, or 12 bit color channels.
        /// </para>
        /// </summary>
        DXGI_COLOR_SPACE_YCBCR_STUDIO_G24_LEFT_P709 = 22,

        /// <summary>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Property
        /// </term>
        /// <term>
        /// Value
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Colorspace
        /// </term>
        /// <term>
        /// YCBCR
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Range
        /// </term>
        /// <term>
        /// 16-235
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Gamma
        /// </term>
        /// <term>
        /// 2.4
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Siting
        /// </term>
        /// <term>
        /// Video
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Primaries
        /// </term>
        /// <term>
        /// BT.2020
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// This is usually used with 10 or 12 bit color channels.
        /// </para>
        /// </summary>
        DXGI_COLOR_SPACE_YCBCR_STUDIO_G24_LEFT_P2020 = 23,

        /// <summary>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Property
        /// </term>
        /// <term>
        /// Value
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Colorspace
        /// </term>
        /// <term>
        /// YCBCR
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Range
        /// </term>
        /// <term>
        /// 16-235
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Gamma
        /// </term>
        /// <term>
        /// 2.4
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Siting
        /// </term>
        /// <term>
        /// Video
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Primaries
        /// </term>
        /// <term>
        /// BT.2020
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// This is usually used with 10 or 12 bit color channels.
        /// </para>
        /// </summary>
        DXGI_COLOR_SPACE_YCBCR_STUDIO_G24_TOPLEFT_P2020 = 24,

        /// <summary>
        /// A custom color definition is used.
        /// </summary>
        DXGI_COLOR_SPACE_CUSTOM = unchecked((int)0xFFFFFFFF),
    }
}
