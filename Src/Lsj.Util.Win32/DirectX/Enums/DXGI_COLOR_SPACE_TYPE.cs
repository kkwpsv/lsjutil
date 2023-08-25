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
    /// This enum is used within DXGI in the <see cref="IDXGISwapChain3.CheckColorSpaceSupport"/>, <see cref="IDXGISwapChain3.SetColorSpace1"/>
    /// and <see cref="IDXGIOutput4.CheckOverlayColorSpaceSupport"/> methods.
    /// It is also referenced in D3D11 video methods such as <see cref="ID3D11VideoContext1.VideoProcessorSetOutputColorSpace1"/>,
    /// and D2D methods such as <see cref="ID2D1DeviceContext2.CreateImageSourceFromDxgi"/>.
    /// </remarks>
    public enum DXGI_COLOR_SPACE_TYPE
    {
        /// <summary>
        /// Property	Value
        /// Colorspace  RGB
        /// Range	    0-255
        /// Gamma	    2.2
        /// Siting      Image
        /// Primaries   BT.709
        /// This is the standard definition for sRGB.
        /// Note
        /// This is intended to be implemented with sRGB gamma (linear segment + 2.4 power), which is approximately aligned with a gamma 2.2 curve.
        /// This is usually used with 8 or 10 bit color channels.
        /// </summary>
        DXGI_COLOR_SPACE_RGB_FULL_G22_NONE_P709 = 0,

        /// <summary>
        /// Property	Value
        /// Colorspace  RGB
        /// Range	    0-255
        /// Gamma	    1.0
        /// Siting      Image
        /// Primaries   BT.709
        /// This is the standard definition for scRGB, and is usually used with 16 bit integer, 16 bit floating point, or 32 bit floating point color channels.
        /// </summary>
        DXGI_COLOR_SPACE_RGB_FULL_G10_NONE_P709 = 1,

        /// <summary>
        /// Property	Value
        /// Colorspace  RGB
        /// Range	    16-235
        /// Gamma	    2.2
        /// Siting      Image
        /// Primaries   BT.709
        /// This is the standard definition for ITU-R Recommendation BT.709.
        /// Note that due to the inclusion of a linear segment, the transfer curve looks similar to a pure exponential gamma of 1.9.
        /// This is usually used with 8 or 10 bit color channels.
        /// </summary>
        DXGI_COLOR_SPACE_RGB_STUDIO_G22_NONE_P709 = 2,

        /// <summary>
        /// Property	Value
        /// Colorspace  RGB
        /// Range	    16-235
        /// Gamma	    2.2
        /// Siting      Image
        /// Primaries   BT.2020
        /// This is usually used with 10 or 12 bit color channels.
        /// </summary>
        DXGI_COLOR_SPACE_RGB_STUDIO_G22_NONE_P2020 = 3,

        /// <summary>
        /// Reserved.
        /// </summary>
        DXGI_COLOR_SPACE_RESERVED = 4,

        /// <summary>
        /// Property	    Value
        /// Colorspace      YCbCr
        /// Range	        0-255
        /// Gamma	        1.0
        /// Siting          Image
        /// Primaries       BT.709
        /// Transfer Matrix	BT.601
        /// This definition is commonly used for JPG, and is usually used with 8, 10, or 12 bit color channels.
        /// </summary>
        DXGI_COLOR_SPACE_YCBCR_FULL_G22_NONE_P709_X601 = 5,

        /// <summary>
        /// Property	    Value
        /// Colorspace      YCbCr
        /// Range	        16-235
        /// Gamma	        2.2
        /// Siting          Video
        /// Primaries       BT.601
        /// This definition is commonly used for MPEG2, and is usually used with 8, 10, or 12 bit color channels.
        /// </summary>
        DXGI_COLOR_SPACE_YCBCR_STUDIO_G22_LEFT_P601 = 6,

        /// <summary>
        /// Property	    Value
        /// Colorspace      YCbCr
        /// Range	        0-255
        /// Gamma	        2.2
        /// Siting          Video
        /// Primaries       BT.601
        /// This is sometimes used for H.264 camera capture, and is usually used with 8, 10, or 12 bit color channels.
        /// </summary>
        DXGI_COLOR_SPACE_YCBCR_FULL_G22_LEFT_P601 = 7,

        /// <summary>
        /// Property	    Value
        /// Colorspace      YCbCr
        /// Range	        16-235
        /// Gamma	        2.2
        /// Siting          Video
        /// Primaries       BT.709
        /// This definition is commonly used for H.264 and HEVC, and is usually used with 8, 10, or 12 bit color channels.
        /// </summary>
        DXGI_COLOR_SPACE_YCBCR_STUDIO_G22_LEFT_P709 = 8,

        /// <summary>
        /// Property	    Value
        /// Colorspace      YCbCr
        /// Range	        0-255
        /// Gamma	        2.2
        /// Siting          Video
        /// Primaries       BT.709
        /// This is sometimes used for H.264 camera capture, and is usually used with 8, 10, or 12 bit color channels.
        /// </summary>
        DXGI_COLOR_SPACE_YCBCR_FULL_G22_LEFT_P709 = 9,

        /// <summary>
        /// Property	    Value
        /// Colorspace      YCbCr
        /// Range	        16-235
        /// Gamma	        2.2
        /// Siting          Video
        /// Primaries       BT.2020
        /// This definition may be used by HEVC, and is usually used with 10 or 12 bit color channels.
        /// </summary>
        DXGI_COLOR_SPACE_YCBCR_STUDIO_G22_LEFT_P2020 = 10,

        /// <summary>
        /// Property	    Value
        /// Colorspace      YCbCr
        /// Range	        0-255
        /// Gamma	        2.2
        /// Siting          Video
        /// Primaries       BT.2020
        /// This is usually used with 10 or 12 bit color channels.
        /// </summary>
        DXGI_COLOR_SPACE_YCBCR_FULL_G22_LEFT_P2020 = 11,

        /// <summary>
        /// Property	Value
        /// Colorspace  RGB
        /// Range	    0-255
        /// Gamma	    2084
        /// Siting      Image
        /// Primaries   BT.2020
        /// This is usually used with 10 or 12 bit color channels.
        /// </summary>
        DXGI_COLOR_SPACE_RGB_FULL_G2084_NONE_P2020 = 12,

        /// <summary>
        /// Property	    Value
        /// Colorspace      YCbCr
        /// Range	        16-235
        /// Gamma	        2084
        /// Siting          Video
        /// Primaries       BT.2020
        /// This is usually used with 10 or 12 bit color channels.
        /// </summary>
        DXGI_COLOR_SPACE_YCBCR_STUDIO_G2084_LEFT_P2020 = 13,

        /// <summary>
        /// Property	Value
        /// Colorspace  RGB
        /// Range	    16-235
        /// Gamma	    2084
        /// Siting      Image
        /// Primaries   BT.2020
        /// This is usually used with 10 or 12 bit color channels.
        /// </summary>
        DXGI_COLOR_SPACE_RGB_STUDIO_G2084_NONE_P2020 = 14,

        /// <summary>
        /// Property	    Value
        /// Colorspace      YCbCr
        /// Range	        16-235
        /// Gamma	        2.2
        /// Siting          Video
        /// Primaries       BT.2020
        /// This is usually used with 10 or 12 bit color channels.
        /// </summary>
        DXGI_COLOR_SPACE_YCBCR_STUDIO_G22_TOPLEFT_P2020 = 15,

        /// <summary>
        /// Property	    Value
        /// Colorspace      YCbCr
        /// Range	        16-235
        /// Gamma	        2084
        /// Siting          Video
        /// Primaries       BT.2020
        /// This is usually used with 10 or 12 bit color channels.
        /// </summary>
        DXGI_COLOR_SPACE_YCBCR_STUDIO_G2084_TOPLEFT_P2020 = 16,

        /// <summary>
        /// Property	Value
        /// Colorspace  RGB
        /// Range	    0-255
        /// Gamma	    2.2
        /// Siting      Image
        /// Primaries   BT.2020
        /// This is usually used with 10 or 12 bit color channels.
        /// </summary>
        DXGI_COLOR_SPACE_RGB_FULL_G22_NONE_P2020 = 17,

        /// <summary>
        /// Property	    Value
        /// Colorspace      YCbCr
        /// Range	        16-235
        /// Gamma	        HLG
        /// Siting          Video
        /// Primaries       BT.2020
        /// This is usually used with 10 or 12 bit color channels.
        /// </summary>
        DXGI_COLOR_SPACE_YCBCR_STUDIO_GHLG_TOPLEFT_P2020 = 18,

        /// <summary>
        /// Property	    Value
        /// Colorspace      YCbCr
        /// Range	        0-255
        /// Gamma	        HLG
        /// Siting          Video
        /// Primaries       BT.2020
        /// This is usually used with 10 or 12 bit color channels.
        /// </summary>
        DXGI_COLOR_SPACE_YCBCR_FULL_GHLG_TOPLEFT_P2020 = 19,

        /// <summary>
        /// Property	Value
        /// Colorspace  RGB
        /// Range	    16-235
        /// Gamma	    2.4
        /// Siting      Image
        /// Primaries   BT.709
        /// This is usually used with 8, 10, or 12 bit color channels.
        /// </summary>
        DXGI_COLOR_SPACE_RGB_STUDIO_G24_NONE_P709 = 20,

        /// <summary>
        /// Property	Value
        /// Colorspace  RGB
        /// Range	    16-235
        /// Gamma	    2.4
        /// Siting      Image
        /// Primaries   BT.2020
        /// This is usually used with 10 or 12 bit color channels.
        /// </summary>
        DXGI_COLOR_SPACE_RGB_STUDIO_G24_NONE_P2020 = 21,

        /// <summary>
        /// Property	    Value
        /// Colorspace      YCBCR
        /// Range	        16-235
        /// Gamma	        2.4
        /// Siting          Video
        /// Primaries       BT.709
        /// This is usually used with 8, 10, or 12 bit color channels.
        /// </summary>
        DXGI_COLOR_SPACE_YCBCR_STUDIO_G24_LEFT_P709 = 22,

        /// <summary>
        /// Property	    Value
        /// Colorspace      YCBCR
        /// Range	        16-235
        /// Gamma	        2.4
        /// Siting          Video
        /// Primaries       BT.2020
        /// This is usually used with 10 or 12 bit color channels.
        /// </summary>
        DXGI_COLOR_SPACE_YCBCR_STUDIO_G24_LEFT_P2020 = 23,

        /// <summary>
        /// Property	    Value
        /// Colorspace      YCBCR
        /// Range	        16-235
        /// Gamma	        2.4
        /// Siting          Video
        /// Primaries       BT.2020
        ///This is usually used with 10 or 12 bit color channels.
        /// </summary>
        DXGI_COLOR_SPACE_YCBCR_STUDIO_G24_TOPLEFT_P2020 = 24,

        /// <summary>
        /// A custom color definition is used.
        /// </summary>
        DXGI_COLOR_SPACE_CUSTOM = unchecked((int)0xFFFFFFFF),
    }
}
