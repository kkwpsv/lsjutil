using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines the various types of surface formats.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dformat"/>
    /// </para>
    /// </summary>
    public enum D3DFORMAT
    {
        /// <summary>
        /// Surface format is unknown
        /// </summary>
        D3DFMT_UNKNOWN = 0,

        /// <summary>
        /// 24-bit RGB pixel format with 8 bits per channel.
        /// </summary>
        D3DFMT_R8G8B8 = 20,

        /// <summary>
        /// 32-bit ARGB pixel format with alpha, using 8 bits per channel.
        /// </summary>
        D3DFMT_A8R8G8B8 = 21,

        /// <summary>
        /// 32-bit RGB pixel format, where 8 bits are reserved for each color.
        /// </summary>
        D3DFMT_X8R8G8B8 = 22,

        /// <summary>
        /// 16-bit RGB pixel format with 5 bits for red, 6 bits for green, and 5 bits for blue.
        /// </summary>
        D3DFMT_R5G6B5 = 23,

        /// <summary>
        /// 16-bit pixel format where 5 bits are reserved for each color.
        /// </summary>
        D3DFMT_X1R5G5B5 = 24,

        /// <summary>
        /// 16-bit pixel format where 5 bits are reserved for each color.
        /// </summary>
        D3DFMT_A1R5G5B5 = 25,

        /// <summary>
        /// 16-bit ARGB pixel format with 4 bits for each channel.
        /// </summary>
        D3DFMT_A4R4G4B4 = 26,

        /// <summary>
        /// 8-bit RGB texture format using 3 bits for red, 3 bits for green, and 2 bits for blue.
        /// </summary>
        D3DFMT_R3G3B2 = 27,

        /// <summary>
        /// 8-bit alpha only.
        /// </summary>
        D3DFMT_A8 = 28,

        /// <summary>
        /// 16-bit ARGB texture format using 8 bits for alpha, 3 bits each for red and green, and 2 bits for blue.
        /// </summary>
        D3DFMT_A8R3G3B2 = 29,

        /// <summary>
        /// 16-bit RGB pixel format using 4 bits for each color.
        /// </summary>
        D3DFMT_X4R4G4B4 = 30,

        /// <summary>
        /// 32-bit pixel format using 10 bits for each color and 2 bits for alpha.
        /// </summary>
        D3DFMT_A2B10G10R10 = 31,

        /// <summary>
        /// 32-bit ARGB pixel format with alpha, using 8 bits per channel.
        /// </summary>
        D3DFMT_A8B8G8R8 = 32,

        /// <summary>
        /// 32-bit RGB pixel format, where 8 bits are reserved for each color.
        /// </summary>
        D3DFMT_X8B8G8R8 = 33,

        /// <summary>
        /// 32-bit pixel format using 16 bits each for green and red.
        /// </summary>
        D3DFMT_G16R16 = 34,

        /// <summary>
        /// 32-bit pixel format using 10 bits each for red, green, and blue, and 2 bits for alpha.
        /// </summary>
        D3DFMT_A2R10G10B10 = 35,

        /// <summary>
        /// 64-bit pixel format using 16 bits for each component.
        /// </summary>
        D3DFMT_A16B16G16R16 = 36,

        /// <summary>
        /// 8-bit color indexed with 8 bits of alpha.
        /// </summary>
        D3DFMT_A8P8 = 40,

        /// <summary>
        /// 8-bit color indexed.
        /// </summary>
        D3DFMT_P8 = 41,

        /// <summary>
        /// 8-bit luminance only.
        /// </summary>
        D3DFMT_L8 = 50,

        /// <summary>
        /// 16-bit using 8 bits each for alpha and luminance.
        /// </summary>
        D3DFMT_A8L8 = 51,

        /// <summary>
        /// 	8-bit using 4 bits each for alpha and luminance.
        /// </summary>
        D3DFMT_A4L4 = 52,

        /// <summary>
        /// 16-bit bump-map format using 8 bits each for u and v data.
        /// </summary>
        D3DFMT_V8U8 = 60,

        /// <summary>
        /// 16-bit bump-map format with luminance using 6 bits for luminance, and 5 bits each for v and u.
        /// </summary>
        D3DFMT_L6V5U5 = 61,

        /// <summary>
        /// 32-bit bump-map format with luminance using 8 bits for each channel.
        /// </summary>
        D3DFMT_X8L8V8U8 = 62,

        /// <summary>
        /// 32-bit bump-map format using 8 bits for each channel.
        /// </summary>
        D3DFMT_Q8W8V8U8 = 63,

        /// <summary>
        /// 32-bit bump-map format using 16 bits for each channel.
        /// </summary>
        D3DFMT_V16U16 = 64,

        /// <summary>
        /// 32-bit bump-map format using 2 bits for alpha and 10 bits each for w, v, and u.
        /// </summary>
        D3DFMT_A2W10V10U10 = 67,

        /// <summary>
        /// UYVY format (PC98 compliance)
        /// </summary>
        D3DFMT_UYVY = 0x59565955,

        /// <summary>
        /// A 16-bit packed RGB format analogous to UYVY (U0Y0, V0Y1, U2Y2, and so on).
        /// It requires a pixel pair in order to properly represent the color value.
        /// The first pixel in the pair contains 8 bits of green (in the low 8 bits) and 8 bits of red (in the high 8 bits).
        /// The second pixel contains 8 bits of green (in the low 8 bits) and 8 bits of blue (in the high 8 bits).
        /// Together, the two pixels share the red and blue components, while each has a unique green component (R0G0, B0G1, R2G2, and so on).
        /// The texture sampler does not normalize the colors when looking up into a pixel shader; they remain in the range of 0.0f to 255.0f.
        /// This is true for all programmable pixel shader models.
        /// For the fixed function pixel shader, the hardware should normalize to the 0.f to 1.f range and essentially treat it as the YUY2 texture.
        /// Hardware that exposes this format must have <see cref="D3DCAPS9.PixelShader1xMaxValue"/> member 
        /// of <see cref="D3DCAPS9"/> set to a value capable of handling that range.
        /// </summary>
        D3DFMT_R8G8_B8G8 = 0x47424752,

        /// <summary>
        /// YUY2 format (PC98 compliance)
        /// </summary>
        D3DFMT_YUY2 = 0x32565559,

        /// <summary>
        /// A 16-bit packed RGB format analogous to YUY2 (Y0U0, Y1V0, Y2U2, and so on).
        /// It requires a pixel pair in order to properly represent the color value.
        /// The first pixel in the pair contains 8 bits of green (in the high 8 bits) and 8 bits of red (in the low 8 bits).
        /// The second pixel contains 8 bits of green (in the high 8 bits) and 8 bits of blue (in the low 8 bits).
        /// Together, the two pixels share the red and blue components, while each has a unique green component (G0R0, G1B0, G2R2, and so on).
        /// The texture sampler does not normalize the colors when looking up into a pixel shader; they remain in the range of 0.0f to 255.0f.
        /// This is true for all programmable pixel shader models.
        /// For the fixed function pixel shader, the hardware should normalize to the 0.f to 1.f range and essentially treat it as the YUY2 texture.
        /// Hardware that exposes this format must have the <see cref="D3DCAPS9.PixelShader1xMaxValue"/> member
        /// of <see cref="D3DCAPS9"/> set to a value capable of handling that range.
        /// </summary>
        D3DFMT_G8R8_G8B8 = 0x42475247,

        /// <summary>
        /// DXT1 compression texture format
        /// </summary>
        D3DFMT_DXT1 = 0x31545844,

        /// <summary>
        /// DXT2 compression texture format
        /// </summary>
        D3DFMT_DXT2 = 0x32545844,

        /// <summary>
        /// DXT3 compression texture format
        /// </summary>
        D3DFMT_DXT3 = 0x33545844,

        /// <summary>
        /// DXT4 compression texture format
        /// </summary>
        D3DFMT_DXT4 = 0x34545844,

        /// <summary>
        /// DXT5 compression texture format
        /// </summary>
        D3DFMT_DXT5 = 0x35545844,

        /// <summary>
        /// 16-bit z-buffer bit depth.
        /// </summary>
        D3DFMT_D16_LOCKABLE = 70,

        /// <summary>
        /// 32-bit z-buffer bit depth.
        /// </summary>
        D3DFMT_D32 = 71,

        /// <summary>
        /// 16-bit z-buffer bit depth where 15 bits are reserved for the depth channel and 1 bit is reserved for the stencil channel.
        /// </summary>
        D3DFMT_D15S1 = 73,

        /// <summary>
        /// 32-bit z-buffer bit depth using 24 bits for the depth channel and 8 bits for the stencil channel.
        /// </summary>
        D3DFMT_D24S8 = 75,

        /// <summary>
        /// 32-bit z-buffer bit depth using 24 bits for the depth channel.
        /// </summary>
        D3DFMT_D24X8 = 77,

        /// <summary>
        /// 32-bit z-buffer bit depth using 24 bits for the depth channel and 4 bits for the stencil channel.
        /// </summary>
        D3DFMT_D24X4S4 = 79,

        /// <summary>
        /// 16-bit z-buffer bit depth.
        /// </summary>
        D3DFMT_D16 = 80,

        /// <summary>
        /// A lockable format where the depth value is represented as a standard IEEE floating-point number.
        /// </summary>
        D3DFMT_D32F_LOCKABLE = 82,

        /// <summary>
        /// A non-lockable format that contains 24 bits of depth (in a 24-bit floating point format - 20e4) and 8 bits of stencil.
        /// </summary>
        D3DFMT_D24FS8 = 83,

        /// <summary>
        /// A lockable 32-bit depth buffer.
        /// Differences between Direct3D 9 and Direct3D 9Ex: This flag is available in Direct3D 9Ex only.
        /// </summary>
        D3DFMT_D32_LOCKABLE = 84,

        /// <summary>
        /// A lockable 8-bit stencil buffer.
        /// Differences between Direct3D 9 and Direct3D 9Ex: This flag is available in Direct3D 9Ex only.
        /// </summary>
        D3DFMT_S8_LOCKABLE = 85,

        /// <summary>
        /// 16-bit luminance only.
        /// </summary>
        D3DFMT_L16 = 81,

        /// <summary>
        /// Describes a vertex buffer surface.
        /// </summary>
        D3DFMT_VERTEXDATA = 100,

        /// <summary>
        /// 16-bit index buffer bit depth.
        /// </summary>
        D3DFMT_INDEX16 = 101,

        /// <summary>
        /// 32-bit index buffer bit depth.
        /// </summary>
        D3DFMT_INDEX32 = 102,

        /// <summary>
        /// 64-bit bump-map format using 16 bits for each component.
        /// </summary>
        D3DFMT_Q16W16V16U16 = 110,

        /// <summary>
        /// MultiElement texture (not compressed)
        /// </summary>
        D3DFMT_MULTI2_ARGB8 = 0x3154454d,

        /// <summary>
        /// 16-bit float format using 16 bits for the red channel.
        /// </summary>
        D3DFMT_R16F = 111,

        /// <summary>
        /// 32-bit float format using 16 bits for the red channel and 16 bits for the green channel.
        /// </summary>
        D3DFMT_G16R16F = 112,

        /// <summary>
        /// 64-bit float format using 16 bits for the each channel (alpha, blue, green, red).
        /// </summary>
        D3DFMT_A16B16G16R16F = 113,

        /// <summary>
        /// 32-bit float format using 32 bits for the red channel.
        /// </summary>
        D3DFMT_R32F = 114,

        /// <summary>
        /// 64-bit float format using 32 bits for the red channel and 32 bits for the green channel.
        /// </summary>
        D3DFMT_G32R32F = 115,

        /// <summary>
        /// 128-bit float format using 32 bits for the each channel (alpha, blue, green, red).
        /// </summary>
        D3DFMT_A32B32G32R32F = 116,

        /// <summary>
        /// 16-bit normal compression format.
        /// The texture sampler computes the C channel from: C = sqrt(1 - U² - V²).
        /// </summary>
        D3DFMT_CxV8U8 = 117,

        /// <summary>
        /// 1-bit monochrome.
        /// Differences between Direct3D 9 and Direct3D 9Ex: This flag is available in Direct3D 9Ex only.
        /// </summary>
        D3DFMT_A1 = 118,

        /// <summary>
        /// 2.8-biased fixed point.
        /// Differences between Direct3D 9 and Direct3D 9Ex: This flag is available in Direct3D 9Ex only.
        /// </summary>
        D3DFMT_A2B10G10R10_XR_BIAS = 119,

        /// <summary>
        /// Binary format indicating that the data has no inherent type.
        /// Differences between Direct3D 9 and Direct3D 9Ex: This flag is available in Direct3D 9Ex only.
        /// </summary>
        D3DFMT_BINARYBUFFER = 199,

        /// <summary>
        /// D3DFMT_FORCE_DWORD
        /// </summary>
        D3DFMT_FORCE_DWORD = 0x7fffffff
    }
}
