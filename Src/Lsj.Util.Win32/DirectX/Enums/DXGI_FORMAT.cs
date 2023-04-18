using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Resource data formats, including fully-typed and typeless formats.
    /// A list of modifiers at the bottom of the page more fully describes each format type.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgiformat/ne-dxgiformat-dxgi_format"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Byte Order (LSB/MSB)
    /// Most formats have byte-aligned components, and the components are in C-array order(the least address comes first).
    /// For those formats that don't have power-of-2-aligned components, the first named component is in the least-significant bits.
    /// Portable Coding for Endian-Independence
    /// Rather than adjusting for whether a system uses big-endian or little-endian byte ordering, you should write portable code, as follows.
    /// <code>
    /// // DXGI_FORMAT_R32G32B32A32_FLOAT
    /// FLOAT* pR32G32B32A32 = ...;
    /// pR32G32B32A32[0] = 1.f;  // R
    /// pR32G32B32A32[1] = 0.f;  // G
    /// pR32G32B32A32[2] = 0.f;  // B
    /// pR32G32B32A32[3] = 0.5f; // A
    /// 
    /// // DXGI_FORMAT_R10G10B10A2_UNORM
    /// UINT32* pR10G10B10A2 = ...;
    /// pR10G10B10A2 = (0x3ff) | (0x1 &lt;&lt; 30);  // R=0x3ff, and A=0x1
    /// </code>
    /// Restrictions and notes on formats
    /// A few formats have additional restrictions and implied behavior:
    /// 1. A resource declared with the <see cref="DXGI_FORMAT_R32G32B32"/> family of formats cannot be used simultaneously for vertex and texture data.
    /// That is, you may not create a buffer resource with the <see cref="DXGI_FORMAT_R32G32B32"/> family of formats that uses any of the following bind flags:
    /// <see cref="D3D10_BIND_VERTEX_BUFFER"/>, <see cref="D3D10_BIND_INDEX_BUFFER"/>, <see cref="D3D10_BIND_CONSTANT_BUFFER"/>,
    /// or <see cref="D3D10_BIND_STREAM_OUTPUT"/> (see <see cref="D3D10_BIND_FLAG"/>).
    /// 2. <see cref="DXGI_FORMAT_R1_UNORM"/> is designed specifically for text filtering, and must be used with a format-specific,
    /// configurable 8x8 filter mode. When calling an HLSL sampling function using this format, the address offset parameter must be set to (0,0).
    /// 3. A resource using a sub-sampled format (such as DXGI_FORMAT_R8G8_B8G8) must have a size that is a multiple of 2 in the x dimension.
    /// 4. Format is not available in Direct3D 10 and Direct3D 10.1
    /// 5. These float formats have an implied 1 added to their mantissa. If the exponent is not 0, 1.0 is added to the mantissa before applying the exponent.
    /// 6. These float formats do not have an implied 1 added to their mantissa.
    /// 7. Denorm support: the 9, 10, 11 and 16 bit float formats support denorms.
    /// 8. No denorm support: the 32 and 64 bit float formats flush denorms to zero.
    /// The following topics provide lists of the formats that particular hardware feature levels support:
    /// DXGI Format Support for Direct3D Feature Level 12.1 Hardware
    /// DXGI Format Support for Direct3D Feature Level 12.0 Hardware
    /// DXGI Format Support for Direct3D Feature Level 11.1 Hardware
    /// DXGI Format Support for Direct3D Feature Level 11.0 Hardware
    /// Hardware Support for Direct3D 10Level9 Formats
    /// Hardware Support for Direct3D 10.1 Formats
    /// Hardware Support for Direct3D 10 Formats
    /// For a list of the DirectXMath types that map to <see cref="DXGI_FORMAT"/> values, see DirectXMath Library Internals.
    /// Each enumeration value contains a format modifier which describes the data type.
    /// _FLOAT:
    /// A floating-point value; 32-bit floating-point formats use IEEE 754 single-precision (s23e8 format): sign bit, 8-bit biased (127) exponent, and 23-bit mantissa.
    /// 16-bit floating-point formats use half-precision (s10e5 format): sign bit, 5-bit biased (15) exponent, and 10-bit mantissa.
    /// _SINT:
    /// Two's complement signed integer. For example, a 3-bit SINT represents the values -4, -3, -2, -1, 0, 1, 2, 3.
    /// _SNORM:
    /// Signed normalized integer; which is interpreted in a resource as a signed integer,
    /// and is interpreted in a shader as a signed normalized floating-point value in the range [-1, 1].
    /// For a 2's complement number, the maximum value is 1.0f (a 5-bit value 01111 maps to 1.0f),
    /// and the minimum value is -1.0f (a 5-bit value 10000 maps to -1.0f).
    /// In addition, the second-minimum number maps to -1.0f (a 5-bit value 10001 maps to -1.0f).
    /// The resulting integer representations are evenly spaced floating-point values in the range (-1.0f...0.0f),
    /// and also a complementary set of representations for numbers in the range (0.0f...1.0f).
    /// _SRGB:
    /// Standard RGB data, which roughly displays colors in a linear ramp of luminosity levels such that an average observer,
    /// under average viewing conditions, can view them on an average display.
    /// All 0's maps to 0.0f, and all 1's maps to 1.0f.
    /// The sequence of unsigned integer encodings between all 0's and all 1's represent a nonlinear progression
    /// in the floating-point interpretation of the numbers between 0.0f to 1.0f.
    /// For more detail, see the SRGB color standard, IEC 61996-2-1, at IEC (International Electrotechnical Commission).
    /// Conversion to or from sRGB space is automatically done by D3DX10 or D3DX9 texture-load functions.
    /// If a format with _SRGB has an A channel, the A channel is stored in Gamma 1.0f data;
    /// the R, G, and B channels in the format are stored in Gamma 2.2f data.
    /// _TYPELESS:
    /// Typeless data, with a defined number of bits.
    /// Typeless formats are designed for creating typeless resources; that is, a resource whose size is known, but whose data type is not yet fully defined.
    /// When a typeless resource is bound to a shader, the application or shader must resolve the format type
    /// (which must match the number of bits per component in the typeless format).
    /// A typeless format contains one or more subformats; each subformat resolves the data type.
    /// For example, in the R32G32B32 group, which defines types for three-component 96-bit data,
    /// there is one typeless format and three fully typed subformats.
    /// <see cref="DXGI_FORMAT_R32G32B32_TYPELESS"/>, <see cref="DXGI_FORMAT_R32G32B32_FLOAT"/>,
    /// <see cref="DXGI_FORMAT_R32G32B32_UINT"/>, <see cref="DXGI_FORMAT_R32G32B32_SINT"/>
    /// _UINT:
    /// Unsigned integer.
    /// For instance, a 3-bit UINT represents the values 0, 1, 2, 3, 4, 5, 6, 7.
    /// _UNORM:
    /// Unsigned normalized integer; which is interpreted in a resource as an unsigned integer,
    /// and is interpreted in a shader as an unsigned normalized floating-point value in the range [0, 1].
    /// All 0's maps to 0.0f, and all 1's maps to 1.0f. A sequence of evenly spaced floating-point values from 0.0f to 1.0f are represented.
    /// For instance, a 2-bit UNORM represents 0.0f, 1/3, 2/3, and 1.0f.
    /// _SHAREDEXP:
    /// A shared exponent.
    /// All the floating point representations in the format share the one exponent.
    /// New Resource Formats
    /// Direct3D 10 offers new data compression formats for compressing high-dynamic range (HDR) lighting data,
    /// normal maps and heightfields to a fraction of their original size.
    /// These compression types include:
    /// Shared-Exponent high-dynamic range (HDR) format (RGBE)
    /// New Block-Compressed 1-2 channel UNORM/SNORM formats
    /// The block compression formats can be used for any of the 2D or 3D texture types ( Texture2D, Texture2DArray, Texture3D, or TextureCube) including mipmap surfaces.
    /// The block compression techniques require texture dimensions to be a multiple of 4 (since the implementation compresses on blocks of 4x4 texels).
    /// In the texture sampler, compressed formats are always decompressed before texture filtering.
    /// </remarks>
    public enum DXGI_FORMAT
    {
        /// <summary>
        /// The format is not known.
        /// </summary>
        DXGI_FORMAT_UNKNOWN = 0,

        /// <summary>
        /// A four-component, 128-bit typeless format that supports 32 bits per channel including alpha. ¹
        /// </summary>
        DXGI_FORMAT_R32G32B32A32_TYPELESS = 1,

        /// <summary>
        /// A four-component, 128-bit floating-point format that supports 32 bits per channel including alpha. 1,5,8
        /// </summary>
        DXGI_FORMAT_R32G32B32A32_FLOAT = 2,

        /// <summary>
        /// A four-component, 128-bit unsigned-integer format that supports 32 bits per channel including alpha. ¹
        /// </summary>
        DXGI_FORMAT_R32G32B32A32_UINT = 3,

        /// <summary>
        /// A four-component, 128-bit signed-integer format that supports 32 bits per channel including alpha. ¹
        /// </summary>
        DXGI_FORMAT_R32G32B32A32_SINT = 4,

        /// <summary>
        /// A three-component, 96-bit typeless format that supports 32 bits per color channel.
        /// </summary>
        DXGI_FORMAT_R32G32B32_TYPELESS = 5,

        /// <summary>
        /// A three-component, 96-bit floating-point format that supports 32 bits per color channel.5,8
        /// </summary>
        DXGI_FORMAT_R32G32B32_FLOAT = 6,

        /// <summary>
        /// A three-component, 96-bit unsigned-integer format that supports 32 bits per color channel.
        /// </summary>
        DXGI_FORMAT_R32G32B32_UINT = 7,

        /// <summary>
        /// A three-component, 96-bit signed-integer format that supports 32 bits per color channel.
        /// </summary>
        DXGI_FORMAT_R32G32B32_SINT = 8,

        /// <summary>
        /// A four-component, 64-bit typeless format that supports 16 bits per channel including alpha.
        /// </summary>
        DXGI_FORMAT_R16G16B16A16_TYPELESS = 9,

        /// <summary>
        /// A four-component, 64-bit floating-point format that supports 16 bits per channel including alpha.5,7
        /// </summary>
        DXGI_FORMAT_R16G16B16A16_FLOAT = 10,

        /// <summary>
        /// A four-component, 64-bit unsigned-normalized-integer format that supports 16 bits per channel including alpha.
        /// </summary>
        DXGI_FORMAT_R16G16B16A16_UNORM = 11,

        /// <summary>
        /// A four-component, 64-bit unsigned-integer format that supports 16 bits per channel including alpha.
        /// </summary>
        DXGI_FORMAT_R16G16B16A16_UINT = 12,

        /// <summary>
        /// A four-component, 64-bit signed-normalized-integer format that supports 16 bits per channel including alpha.
        /// </summary>
        DXGI_FORMAT_R16G16B16A16_SNORM = 13,

        /// <summary>
        /// A four-component, 64-bit signed-integer format that supports 16 bits per channel including alpha.
        /// </summary>
        DXGI_FORMAT_R16G16B16A16_SINT = 14,

        /// <summary>
        /// A two-component, 64-bit typeless format that supports 32 bits for the red channel and 32 bits for the green channel.
        /// </summary>
        DXGI_FORMAT_R32G32_TYPELESS = 15,

        /// <summary>
        /// A two-component, 64-bit floating-point format that supports 32 bits for the red channel and 32 bits for the green channel.5,8
        /// </summary>
        DXGI_FORMAT_R32G32_FLOAT = 16,

        /// <summary>
        /// A two-component, 64-bit unsigned-integer format that supports 32 bits for the red channel and 32 bits for the green channel.
        /// </summary>
        DXGI_FORMAT_R32G32_UINT = 17,

        /// <summary>
        /// A two-component, 64-bit signed-integer format that supports 32 bits for the red channel and 32 bits for the green channel.
        /// </summary>
        DXGI_FORMAT_R32G32_SINT = 18,

        /// <summary>
        /// A two-component, 64-bit typeless format that supports 32 bits for the red channel, 8 bits for the green channel, and 24 bits are unused.
        /// </summary>
        DXGI_FORMAT_R32G8X24_TYPELESS = 19,

        /// <summary>
        /// A 32-bit floating-point component, and two unsigned-integer components (with an additional 32 bits).
        /// This format supports 32-bit depth, 8-bit stencil, and 24 bits are unused.⁵
        /// </summary>
        DXGI_FORMAT_D32_FLOAT_S8X24_UINT = 20,

        /// <summary>
        /// A 32-bit floating-point component, and two typeless components (with an additional 32 bits).
        /// This format supports 32-bit red channel, 8 bits are unused, and 24 bits are unused.⁵
        /// </summary>
        DXGI_FORMAT_R32_FLOAT_X8X24_TYPELESS = 21,

        /// <summary>
        /// A 32-bit typeless component, and two unsigned-integer components (with an additional 32 bits).
        /// This format has 32 bits unused, 8 bits for green channel, and 24 bits are unused.
        /// </summary>
        DXGI_FORMAT_X32_TYPELESS_G8X24_UINT = 22,

        /// <summary>
        /// A four-component, 32-bit typeless format that supports 10 bits for each color and 2 bits for alpha.
        /// </summary>
        DXGI_FORMAT_R10G10B10A2_TYPELESS = 23,

        /// <summary>
        /// A four-component, 32-bit unsigned-normalized-integer format that supports 10 bits for each color and 2 bits for alpha.
        /// </summary>
        DXGI_FORMAT_R10G10B10A2_UNORM = 24,

        /// <summary>
        /// A four-component, 32-bit unsigned-integer format that supports 10 bits for each color and 2 bits for alpha.
        /// </summary>
        DXGI_FORMAT_R10G10B10A2_UINT = 25,

        /// <summary>
        /// Three partial-precision floating-point numbers encoded into a single 32-bit value
        /// (a variant of s10e5, which is sign bit, 10-bit mantissa, and 5-bit biased (15) exponent).
        /// There are no sign bits, and there is a 5-bit biased (15) exponent for each channel, 6-bit mantissa for R and G,
        /// and a 5-bit mantissa for B, as shown in the following illustration.5,7
        /// </summary>
        DXGI_FORMAT_R11G11B10_FLOAT = 26,

        /// <summary>
        ///A four-component, 32-bit typeless format that supports 8 bits per channel including alpha.
        /// </summary>
        DXGI_FORMAT_R8G8B8A8_TYPELESS = 27,

        /// <summary>
        /// A four-component, 32-bit unsigned-normalized-integer format that supports 8 bits per channel including alpha.
        /// </summary>
        DXGI_FORMAT_R8G8B8A8_UNORM = 28,

        /// <summary>
        /// A four-component, 32-bit unsigned-normalized integer sRGB format that supports 8 bits per channel including alpha.
        /// </summary>
        DXGI_FORMAT_R8G8B8A8_UNORM_SRGB = 29,

        /// <summary>
        /// A four-component, 32-bit unsigned-normalized integer sRGB format that supports 8 bits per channel including alpha.
        /// </summary>
        DXGI_FORMAT_R8G8B8A8_UINT = 30,

        /// <summary>
        /// A four-component, 32-bit signed-normalized-integer format that supports 8 bits per channel including alpha.
        /// </summary>
        DXGI_FORMAT_R8G8B8A8_SNORM = 31,

        /// <summary>
        /// A four-component, 32-bit signed-integer format that supports 8 bits per channel including alpha.
        /// </summary>
        DXGI_FORMAT_R8G8B8A8_SINT = 32,

        /// <summary>
        /// A two-component, 32-bit typeless format that supports 16 bits for the red channel and 16 bits for the green channel.
        /// </summary>
        DXGI_FORMAT_R16G16_TYPELESS = 33,

        /// <summary>
        /// A two-component, 32-bit floating-point format that supports 16 bits for the red channel and 16 bits for the green channel.5,7
        /// </summary>
        DXGI_FORMAT_R16G16_FLOAT = 34,

        /// <summary>
        /// A two-component, 32-bit unsigned-normalized-integer format that supports 16 bits each for the green and red channels.
        /// </summary>
        DXGI_FORMAT_R16G16_UNORM = 35,

        /// <summary>
        /// A two-component, 32-bit unsigned-integer format that supports 16 bits for the red channel and 16 bits for the green channel.
        /// </summary>
        DXGI_FORMAT_R16G16_UINT = 36,

        /// <summary>
        /// A two-component, 32-bit signed-normalized-integer format that supports 16 bits for the red channel and 16 bits for the green channel.
        /// </summary>
        DXGI_FORMAT_R16G16_SNORM = 37,

        /// <summary>
        /// A two-component, 32-bit signed-integer format that supports 16 bits for the red channel and 16 bits for the green channel.
        /// </summary>
        DXGI_FORMAT_R16G16_SINT = 38,

        /// <summary>
        /// A single-component, 32-bit typeless format that supports 32 bits for the red channel.
        /// </summary>
        DXGI_FORMAT_R32_TYPELESS = 39,

        /// <summary>
        /// A single-component, 32-bit floating-point format that supports 32 bits for depth.5,8
        /// </summary>
        DXGI_FORMAT_D32_FLOAT = 40,

        /// <summary>
        /// A single-component, 32-bit floating-point format that supports 32 bits for the red channel.5,8
        /// </summary>
        DXGI_FORMAT_R32_FLOAT = 41,

        /// <summary>
        /// A single-component, 32-bit unsigned-integer format that supports 32 bits for the red channel.
        /// </summary>
        DXGI_FORMAT_R32_UINT = 42,

        /// <summary>
        /// A single-component, 32-bit signed-integer format that supports 32 bits for the red channel.
        /// </summary>
        DXGI_FORMAT_R32_SINT = 43,

        /// <summary>
        /// A two-component, 32-bit typeless format that supports 24 bits for the red channel and 8 bits for the green channel.
        /// </summary>
        DXGI_FORMAT_R24G8_TYPELESS = 44,

        /// <summary>
        /// A 32-bit z-buffer format that supports 24 bits for depth and 8 bits for stencil.
        /// </summary>
        DXGI_FORMAT_D24_UNORM_S8_UINT = 45,

        /// <summary>
        /// A 32-bit format, that contains a 24 bit, single-component, unsigned-normalized integer, with an additional typeless 8 bits.
        /// This format has 24 bits red channel and 8 bits unused.
        /// </summary>
        DXGI_FORMAT_R24_UNORM_X8_TYPELESS = 46,

        /// <summary>
        /// A 32-bit format, that contains a 24 bit, single-component, typeless format, with an additional 8 bit unsigned integer component.
        /// This format has 24 bits unused and 8 bits green channel.
        /// </summary>
        DXGI_FORMAT_X24_TYPELESS_G8_UINT = 47,

        /// <summary>
        /// A two-component, 16-bit typeless format that supports 8 bits for the red channel and 8 bits for the green channel.
        /// </summary>
        DXGI_FORMAT_R8G8_TYPELESS = 48,

        /// <summary>
        /// A two-component, 16-bit unsigned-normalized-integer format that supports 8 bits for the red channel and 8 bits for the green channel.
        /// </summary>
        DXGI_FORMAT_R8G8_UNORM = 49,

        /// <summary>
        /// A two-component, 16-bit unsigned-integer format that supports 8 bits for the red channel and 8 bits for the green channel.
        /// </summary>
        DXGI_FORMAT_R8G8_UINT = 50,

        /// <summary>
        /// A two-component, 16-bit signed-normalized-integer format that supports 8 bits for the red channel and 8 bits for the green channel.
        /// </summary>
        DXGI_FORMAT_R8G8_SNORM = 51,

        /// <summary>
        /// A two-component, 16-bit signed-integer format that supports 8 bits for the red channel and 8 bits for the green channel.
        /// </summary>
        DXGI_FORMAT_R8G8_SINT = 52,

        /// <summary>
        /// A single-component, 16-bit typeless format that supports 16 bits for the red channel.
        /// </summary>
        DXGI_FORMAT_R16_TYPELESS = 53,

        /// <summary>
        /// A single-component, 16-bit floating-point format that supports 16 bits for the red channel.5,7
        /// </summary>
        DXGI_FORMAT_R16_FLOAT = 54,

        /// <summary>
        /// A single-component, 16-bit unsigned-normalized-integer format that supports 16 bits for depth.
        /// </summary>
        DXGI_FORMAT_D16_UNORM = 55,

        /// <summary>
        /// A single-component, 16-bit unsigned-normalized-integer format that supports 16 bits for the red channel.
        /// </summary>
        DXGI_FORMAT_R16_UNORM = 56,

        /// <summary>
        /// A single-component, 16-bit unsigned-integer format that supports 16 bits for the red channel.
        /// </summary>
        DXGI_FORMAT_R16_UINT = 57,

        /// <summary>
        /// A single-component, 16-bit signed-normalized-integer format that supports 16 bits for the red channel.
        /// </summary>
        DXGI_FORMAT_R16_SNORM = 58,

        /// <summary>
        /// A single-component, 16-bit signed-integer format that supports 16 bits for the red channel.
        /// </summary>
        DXGI_FORMAT_R16_SINT = 59,

        /// <summary>
        /// A single-component, 8-bit typeless format that supports 8 bits for the red channel.
        /// </summary>
        DXGI_FORMAT_R8_TYPELESS = 60,

        /// <summary>
        /// A single-component, 8-bit unsigned-normalized-integer format that supports 8 bits for the red channel.
        /// </summary>
        DXGI_FORMAT_R8_UNORM = 61,

        /// <summary>
        /// A single-component, 8-bit unsigned-integer format that supports 8 bits for the red channel.
        /// </summary>
        DXGI_FORMAT_R8_UINT = 62,

        /// <summary>
        /// A single-component, 8-bit signed-normalized-integer format that supports 8 bits for the red channel.
        /// </summary>
        DXGI_FORMAT_R8_SNORM = 63,

        /// <summary>
        /// A single-component, 8-bit signed-integer format that supports 8 bits for the red channel.
        /// </summary>
        DXGI_FORMAT_R8_SINT = 64,

        /// <summary>
        /// A single-component, 8-bit unsigned-normalized-integer format for alpha only.
        /// </summary>
        DXGI_FORMAT_A8_UNORM = 65,

        /// <summary>
        /// A single-component, 8-bit unsigned-normalized-integer format for alpha only.
        /// </summary>
        DXGI_FORMAT_R1_UNORM = 66,

        /// <summary>
        /// Three partial-precision floating-point numbers encoded into a single 32-bit value all sharing the same 5-bit exponent
        /// (variant of s10e5, which is sign bit, 10-bit mantissa, and 5-bit biased (15) exponent).
        /// There is no sign bit, and there is a shared 5-bit biased (15) exponent and a 9-bit mantissa for each channel, as shown in the following illustration. 6,7.
        /// </summary>
        DXGI_FORMAT_R9G9B9E5_SHAREDEXP = 67,

        /// <summary>
        /// A four-component, 32-bit unsigned-normalized-integer format.
        /// This packed RGB format is analogous to the UYVY format. Each 32-bit block describes a pair of pixels: (R8, G8, B8) and (R8, G8, B8)
        /// where the R8/B8 values are repeated, and the G8 values are unique to each pixel. ³
        /// Width must be even.
        /// </summary>
        DXGI_FORMAT_R8G8_B8G8_UNORM = 68,

        /// <summary>
        /// A four-component, 32-bit unsigned-normalized-integer format.
        /// This packed RGB format is analogous to the YUY2 format. Each 32-bit block describes a pair of pixels: (R8, G8, B8) and (R8, G8, B8)
        /// where the R8/B8 values are repeated, and the G8 values are unique to each pixel. ³
        /// Width must be even.
        /// </summary>
        DXGI_FORMAT_G8R8_G8B8_UNORM = 69,

        /// <summary>
        /// Four-component typeless block-compression format.
        /// For information about block-compression formats, see Texture Block Compression in Direct3D 11.
        /// </summary>
        DXGI_FORMAT_BC1_TYPELESS = 70,

        /// <summary>
        /// Four-component block-compression format.
        /// For information about block-compression formats, see Texture Block Compression in Direct3D 11.
        /// </summary>
        DXGI_FORMAT_BC1_UNORM = 71,

        /// <summary>
        /// Four-component block-compression format for sRGB data.
        /// For information about block-compression formats, see Texture Block Compression in Direct3D 11.
        /// </summary>
        DXGI_FORMAT_BC1_UNORM_SRGB = 72,

        /// <summary>
        /// Four-component typeless block-compression format.
        /// For information about block-compression formats, see Texture Block Compression in Direct3D 11.
        /// </summary>
        DXGI_FORMAT_BC2_TYPELESS = 73,

        /// <summary>
        /// Four-component block-compression format.
        /// For information about block-compression formats, see Texture Block Compression in Direct3D 11.
        /// </summary>
        DXGI_FORMAT_BC2_UNORM = 74,

        /// <summary>
        /// Four-component block-compression format for sRGB data.
        /// For information about block-compression formats, see Texture Block Compression in Direct3D 11.
        /// </summary>
        DXGI_FORMAT_BC2_UNORM_SRGB = 75,

        /// <summary>
        /// Four-component typeless block-compression format.
        /// For information about block-compression formats, see Texture Block Compression in Direct3D 11.
        /// </summary>
        DXGI_FORMAT_BC3_TYPELESS = 76,

        /// <summary>
        /// Four-component block-compression format.
        /// For information about block-compression formats, see Texture Block Compression in Direct3D 11.
        /// </summary>
        DXGI_FORMAT_BC3_UNORM = 77,

        /// <summary>
        /// Four-component block-compression format for sRGB data.
        /// For information about block-compression formats, see Texture Block Compression in Direct3D 11.
        /// </summary>
        DXGI_FORMAT_BC3_UNORM_SRGB = 78,

        /// <summary>
        /// One-component typeless block-compression format.
        /// For information about block-compression formats, see Texture Block Compression in Direct3D 11.
        /// </summary>
        DXGI_FORMAT_BC4_TYPELESS = 79,

        /// <summary>
        /// One-component block-compression format.
        /// For information about block-compression formats, see Texture Block Compression in Direct3D 11.
        /// </summary>
        DXGI_FORMAT_BC4_UNORM = 80,

        /// <summary>
        /// One-component block-compression format.
        /// For information about block-compression formats, see Texture Block Compression in Direct3D 11.
        /// </summary>
        DXGI_FORMAT_BC4_SNORM = 81,

        /// <summary>
        /// Two-component typeless block-compression format.
        /// For information about block-compression formats, see Texture Block Compression in Direct3D 11.
        /// </summary>
        DXGI_FORMAT_BC5_TYPELESS = 82,

        /// <summary>
        /// Two-component block-compression format.
        /// For information about block-compression formats, see Texture Block Compression in Direct3D 11.
        /// </summary>
        DXGI_FORMAT_BC5_UNORM = 83,

        /// <summary>
        /// Two-component block-compression format.
        /// For information about block-compression formats, see Texture Block Compression in Direct3D 11.
        /// </summary>
        DXGI_FORMAT_BC5_SNORM = 84,

        /// <summary>
        /// A three-component, 16-bit unsigned-normalized-integer format that supports 5 bits for blue, 6 bits for green, and 5 bits for red.
        /// Direct3D 10 through Direct3D 11:
        /// This value is defined for DXGI. However, Direct3D 10, 10.1, or 11 devices do not support this format.
        /// Direct3D 11.1:
        /// This value is not supported until Windows 8.
        /// </summary>
        DXGI_FORMAT_B5G6R5_UNORM = 85,

        /// <summary>
        /// A four-component, 16-bit unsigned-normalized-integer format that supports 5 bits for each color channel and 1-bit alpha.
        /// Direct3D 10 through Direct3D 11:
        /// This value is defined for DXGI. However, Direct3D 10, 10.1, or 11 devices do not support this format.
        /// Direct3D 11.1:
        /// This value is not supported until Windows 8.
        /// </summary>
        DXGI_FORMAT_B5G5R5A1_UNORM = 86,

        /// <summary>
        /// A four-component, 32-bit unsigned-normalized-integer format that supports 8 bits for each color channel and 8-bit alpha.
        /// </summary>
        DXGI_FORMAT_B8G8R8A8_UNORM = 87,

        /// <summary>
        /// A four-component, 32-bit unsigned-normalized-integer format that supports 8 bits for each color channel and 8 bits unused.
        /// </summary>
        DXGI_FORMAT_B8G8R8X8_UNORM = 88,

        /// <summary>
        /// A four-component, 32-bit 2.8-biased fixed-point format that supports 10 bits for each color channel and 2-bit alpha.
        /// </summary>
        DXGI_FORMAT_R10G10B10_XR_BIAS_A2_UNORM = 89,

        /// <summary>
        /// A four-component, 32-bit typeless format that supports 8 bits for each channel including alpha. ⁴
        /// </summary>
        DXGI_FORMAT_B8G8R8A8_TYPELESS = 90,

        /// <summary>
        /// A four-component, 32-bit unsigned-normalized standard RGB format that supports 8 bits for each channel including alpha. ⁴
        /// </summary>
        DXGI_FORMAT_B8G8R8A8_UNORM_SRGB = 91,

        /// <summary>
        /// A four-component, 32-bit typeless format that supports 8 bits for each color channel, and 8 bits are unused. ⁴
        /// </summary>
        DXGI_FORMAT_B8G8R8X8_TYPELESS = 92,

        /// <summary>
        /// A four-component, 32-bit unsigned-normalized standard RGB format that supports 8 bits for each color channel, and 8 bits are unused. ⁴
        /// </summary>
        DXGI_FORMAT_B8G8R8X8_UNORM_SRGB = 93,

        /// <summary>
        /// A typeless block-compression format. ⁴
        /// For information about block-compression formats, see Texture Block Compression in Direct3D 11.
        /// </summary>
        DXGI_FORMAT_BC6H_TYPELESS = 94,

        /// <summary>
        /// A block-compression format. ⁴
        /// For information about block-compression formats, see Texture Block Compression in Direct3D 11.⁵
        /// </summary>
        DXGI_FORMAT_BC6H_UF16 = 95,

        /// <summary>
        /// A block-compression format. ⁴
        /// For information about block-compression formats, see Texture Block Compression in Direct3D 11.⁵
        /// </summary>
        DXGI_FORMAT_BC6H_SF16 = 96,

        /// <summary>
        /// A typeless block-compression format. ⁴
        /// For information about block-compression formats, see Texture Block Compression in Direct3D 11.
        /// </summary>
        DXGI_FORMAT_BC7_TYPELESS = 97,

        /// <summary>
        /// A typeless block-compression format. ⁴
        /// For information about block-compression formats, see Texture Block Compression in Direct3D 11.
        /// </summary>
        DXGI_FORMAT_BC7_UNORM = 98,

        /// <summary>
        /// A block-compression format. ⁴
        /// For information about block-compression formats, see Texture Block Compression in Direct3D 11.
        /// </summary>
        DXGI_FORMAT_BC7_UNORM_SRGB = 99,

        /// <summary>
        /// Most common YUV 4:4:4 video resource format.
        /// Valid view formats for this video resource format are <see cref="DXGI_FORMAT_R8G8B8A8_UNORM"/> and <see cref="DXGI_FORMAT_R8G8B8A8_UINT"/>.
        /// For UAVs, an additional valid view format is <see cref="DXGI_FORMAT_R32_UINT"/>.
        /// By using <see cref="DXGI_FORMAT_R32_UINT"/> for UAVs, you can both read and write as opposed
        /// to just write for <see cref="DXGI_FORMAT_R8G8B8A8_UNORM"/> and <see cref="DXGI_FORMAT_R8G8B8A8_UINT"/>.
        /// Supported view types are SRV, RTV, and UAV. One view provides a straightforward mapping of the entire surface.
        /// The mapping to the view channel is V->R8, U->G8, Y->B8, and A->A8.
        /// For more info about YUV formats for video rendering, see Recommended 8-Bit YUV Formats for Video Rendering.
        /// irect3D 11.1:  This value is not supported until Windows 8.
        /// </summary>
        DXGI_FORMAT_AYUV = 100,

        /// <summary>
        /// 10-bit per channel packed YUV 4:4:4 video resource format.
        /// Valid view formats for this video resource format are <see cref="DXGI_FORMAT_R10G10B10A2_UNORM"/> and <see cref="DXGI_FORMAT_R10G10B10A2_UINT"/>.
        /// For UAVs, an additional valid view format is <see cref="DXGI_FORMAT_R32_UINT"/>.
        /// By using <see cref="DXGI_FORMAT_R32_UINT"/> for UAVs, you can both read and write as opposed
        /// to just write for <see cref="DXGI_FORMAT_R10G10B10A2_UNORM"/> and <see cref="DXGI_FORMAT_R10G10B10A2_UINT"/>.
        /// Supported view types are SRV and UAV. One view provides a straightforward mapping of the entire surface.
        /// The mapping to the view channel is U->R10, Y->G10, V->B10, and A->A2.
        /// For more info about YUV formats for video rendering, see Recommended 8-Bit YUV Formats for Video Rendering.
        /// Direct3D 11.1:  This value is not supported until Windows 8.
        /// </summary>
        DXGI_FORMAT_Y410 = 101,

        /// <summary>
        /// 16-bit per channel packed YUV 4:4:4 video resource format.
        /// Valid view formats for this video resource format are <see cref="DXGI_FORMAT_R16G16B16A16_UNORM"/> and <see cref="DXGI_FORMAT_R16G16B16A16_UINT"/>.
        /// Supported view types are SRV and UAV. One view provides a straightforward mapping of the entire surface.
        /// The mapping to the view channel is U->R16, Y->G16, V->B16, and A->A16.
        /// For more info about YUV formats for video rendering, see Recommended 8-Bit YUV Formats for Video Rendering.
        /// Direct3D 11.1:  This value is not supported until Windows 8.
        /// </summary>
        DXGI_FORMAT_Y416 = 102,

        /// <summary>
        /// Most common YUV 4:2:0 video resource format.
        /// Valid luminance data view formats for this video resource format are <see cref="DXGI_FORMAT_R8_UNORM"/> and <see cref="DXGI_FORMAT_R8_UINT"/>.
        /// Valid chrominance data view formats (width and height are each 1/2 of luminance view)
        /// for this video resource format are <see cref="DXGI_FORMAT_R8G8_UNORM"/> and <see cref="DXGI_FORMAT_R8G8_UINT"/>.
        /// Supported view types are SRV, RTV, and UAV. For luminance data view, the mapping to the view channel is Y->R8.
        /// For chrominance data view, the mapping to the view channel is U->R8 and
        /// V->G8.
        /// For more info about YUV formats for video rendering, see Recommended 8-Bit YUV Formats for Video Rendering.
        /// Width and height must be even.
        /// Direct3D 11 staging resources and initData parameters for this format use (rowPitch * (height + (height / 2))) bytes.
        /// The first (SysMemPitch * height) bytes are the Y plane, the remaining (SysMemPitch * (height / 2)) bytes are the UV plane.
        /// An app using the YUY 4:2:0 formats must map the luma(Y) plane separately from the chroma(UV) planes.
        /// Developers do this by calling <see cref="ID3D12Device.CreateShaderResourceView"/> twice for the same texture and passing in 1-channel and 2-channel formats.
        /// Passing in a 1-channel format compatible with the Y plane maps only the Y plane.
        /// Passing in a 2-channel format compatible with the UV planes (together) maps only the U and V planes as a single resource view.
        /// Direct3D 11.1:  This value is not supported until Windows 8.
        /// </summary>
        DXGI_FORMAT_NV12 = 103,

        /// <summary>
        /// 10-bit per channel planar YUV 4:2:0 video resource format.
        /// Valid luminance data view formats for this video resource format are <see cref="DXGI_FORMAT_R16_UNORM"/> and <see cref="DXGI_FORMAT_R16_UINT"/>.
        /// The runtime does not enforce whether the lowest 6 bits are 0 (given that this video resource format is a 10-bit format that uses 16 bits).
        /// If required, application shader code would have to enforce this manually. From the runtime's point of view,
        /// <see cref="DXGI_FORMAT_P010"/> is no different than <see cref="DXGI_FORMAT_P016"/>. 
        /// Valid chrominance data view formats (width and height are each 1/2 of luminance view)
        /// for this video resource format are <see cref="DXGI_FORMAT_R16G16_UNORM"/> and <see cref="DXGI_FORMAT_R16G16_UINT"/>.
        /// For UAVs, an additional valid chrominance data view format is <see cref="DXGI_FORMAT_R32_UINT"/>.
        /// By using <see cref="DXGI_FORMAT_R32_UINT"/> for UAVs, you can both read and write as opposed
        /// to just write for <see cref="DXGI_FORMAT_R16G16_UNORM"/> and <see cref="DXGI_FORMAT_R16G16_UINT"/>.
        /// Supported view types are SRV, RTV, and UAV. For luminance data view, the mapping to the view channel is Y->R16.
        /// For chrominance data view, the mapping to the view channel is U->R16 and V->G16.
        /// For more info about YUV formats for video rendering, see Recommended 8-Bit YUV Formats for Video Rendering.
        /// Width and height must be even. Direct3D 11 staging resources and initData parameters for this format use (rowPitch * (height + (height / 2))) bytes.
        /// The first (SysMemPitch * height) bytes are the Y plane, the remaining (SysMemPitch * (height / 2)) bytes are the UV plane.
        /// An app using the YUY 4:2:0 formats must map the luma (Y) plane separately from the chroma (UV) planes.
        /// Developers do this by calling <see cref="ID3D12Device.CreateShaderResourceView"/> twice for the same texture and passing in 1-channel and 2-channel formats.
        /// Passing in a 1-channel format compatible with the Y plane maps only the Y plane.
        /// Passing in a 2-channel format compatible with the UV planes (together) maps only the U and V planes as a single resource view.
        /// Direct3D 11.1:  This value is not supported until Windows 8.
        /// </summary>
        DXGI_FORMAT_P010 = 104,

        /// <summary>
        /// 16-bit per channel planar YUV 4:2:0 video resource format.
        /// Valid luminance data view formats for this video resource format are <see cref="DXGI_FORMAT_R16_UNORM"/> and <see cref="DXGI_FORMAT_R16_UINT"/>.
        /// Valid chrominance data view formats (width and height are each 1/2 of luminance view)
        /// for this video resource format are <see cref="DXGI_FORMAT_R16G16_UNORM"/> and <see cref="DXGI_FORMAT_R16G16_UINT"/>.
        /// For UAVs, an additional valid chrominance data view format is <see cref="DXGI_FORMAT_R32_UINT"/>.
        /// By using <see cref="DXGI_FORMAT_R32_UINT"/> for UAVs, you can both read and write as opposed
        /// to just write for <see cref="DXGI_FORMAT_R16G16_UNORM"/> and <see cref="DXGI_FORMAT_R16G16_UINT"/>.
        /// Supported view types are SRV, RTV, and UAV. For luminance data view, the mapping to the view channel is Y->R16.
        /// For chrominance data view, the mapping to the view channel is U->R16 and V->G16.
        /// For more info about YUV formats for video rendering, see Recommended 8-Bit YUV Formats for Video Rendering.
        /// Width and height must be even. Direct3D 11 staging resources and initData parameters for this format use (rowPitch * (height + (height / 2))) bytes.
        /// The first (SysMemPitch * height) bytes are the Y plane, the remaining (SysMemPitch * (height / 2)) bytes are the UV plane.
        /// An app using the YUY 4:2:0 formats must map the luma (Y) plane separately from the chroma (UV) planes.
        /// Developers do this by calling <see cref="ID3D12Device.CreateShaderResourceView"/> twice for the same texture and passing in 1-channel and 2-channel formats.
        /// Passing in a 1-channel format compatible with the Y plane maps only the Y plane.
        /// Passing in a 2-channel format compatible with the UV planes (together) maps only the U and V planes as a single resource view.
        /// Direct3D 11.1:  This value is not supported until Windows 8.
        /// </summary>
        DXGI_FORMAT_P016 = 105,

        /// <summary>
        /// 8-bit per channel planar YUV 4:2:0 video resource format.
        /// This format is subsampled where each pixel has its own Y value, but each 2x2 pixel block shares a single U and V value.
        /// The runtime requires that the width and height of all resources that are created with this format are multiples of 2.
        /// The runtime also requires that the left, right, top, and bottom members of any RECT that are used for this format are multiples of 2.
        /// This format differs from <see cref="DXGI_FORMAT_NV12"/> in that the layout of the data within the resource is completely opaque to applications.
        /// Applications cannot use the CPU to map the resource and then access the data within the resource.
        /// You cannot use shaders with this format.
        /// Because of this behavior, legacy hardware that supports a non-NV12 4:2:0 layout (for example, YV12, and so on) can be used.
        /// Also, new hardware that has a 4:2:0 implementation better than NV12 can be used when the application does not need the data to be in a standard layout.
        /// For more info about YUV formats for video rendering, see Recommended 8-Bit YUV Formats for Video Rendering.
        /// Width and height must be even.
        /// Direct3D 11 staging resources and initData parameters for this format use (rowPitch * (height + (height / 2))) bytes.
        /// An app using the YUY 4:2:0 formats must map the luma (Y) plane separately from the chroma (UV) planes.
        /// Developers do this by calling <see cref="ID3D12Device.CreateShaderResourceView"/> twice for the same texture and passing in 1-channel and 2-channel formats.
        /// Passing in a 1-channel format compatible with the Y plane maps only the Y plane.
        /// Passing in a 2-channel format compatible with the UV planes (together) maps only the U and V planes as a single resource view.
        /// Direct3D 11.1:  This value is not supported until Windows 8.
        /// </summary>
        DXGI_FORMAT_420_OPAQUE = 106,

        /// <summary>
        /// Most common YUV 4:2:2 video resource format.
        /// Valid view formats for this video resource format are <see cref="DXGI_FORMAT_R8G8B8A8_UNORM"/> and <see cref="DXGI_FORMAT_R8G8B8A8_UINT"/>.
        /// For UAVs, an additional valid view format is <see cref="DXGI_FORMAT_R32_UINT"/>.
        /// By using <see cref="DXGI_FORMAT_R32_UINT"/> for UAVs, you can both read and write as opposed
        /// to just write for <see cref="DXGI_FORMAT_R8G8B8A8_UNORM"/> and <see cref="DXGI_FORMAT_R8G8B8A8_UINT"/>.
        /// Supported view types are SRV and UAV. One view provides a straightforward mapping of the entire surface.
        /// The mapping to the view channel is Y0->R8, U0->G8, Y1->B8, and V0->A8.
        /// A unique valid view format for this video resource format is <see cref="DXGI_FORMAT_R8G8_B8G8_UNORM"/>.
        /// With this view format, the width of the view appears to be twice 
        /// what the <see cref="DXGI_FORMAT_R8G8B8A8_UNORM"/> or <see cref="DXGI_FORMAT_R8G8B8A8_UINT"/> view
        /// would be when hardware reconstructs RGBA automatically on read and before filtering.
        /// This Direct3D hardware behavior is legacy and is likely not useful any more.
        /// With this view format, the mapping to the view channel is Y0->R8, U0->G8[0], Y1->B8, and V0->G8[1].
        /// For more info about YUV formats for video rendering, see Recommended 8-Bit YUV Formats for Video Rendering.
        /// Width must be even.
        /// Direct3D 11.1:  This value is not supported until Windows 8.
        /// </summary>
        DXGI_FORMAT_YUY2 = 107,

        /// <summary>
        /// 10-bit per channel packed YUV 4:2:2 video resource format.
        /// Valid view formats for this video resource format are <see cref="DXGI_FORMAT_R16G16B16A16_UNORM"/> and <see cref="DXGI_FORMAT_R16G16B16A16_UINT"/>.
        /// The runtime does not enforce whether the lowest 6 bits are 0 (given that this video resource format is a 10-bit format that uses 16 bits).
        /// If required, application shader code would have to enforce this manually.
        /// From the runtime's point of view, <see cref="DXGI_FORMAT_Y210"/> is no different than <see cref="DXGI_FORMAT_Y216"/>.
        /// Supported view types are SRV and UAV. One view provides a straightforward mapping of the entire surface.
        /// The mapping to the view channel is Y0->R16, U->G16, Y1->B16, and V->A16.
        /// For more info about YUV formats for video rendering, see Recommended 8-Bit YUV Formats for Video Rendering.
        /// Width must be even.
        /// Direct3D 11.1:  This value is not supported until Windows 8.
        /// </summary>
        DXGI_FORMAT_Y210 = 108,

        /// <summary>
        /// 16-bit per channel packed YUV 4:2:2 video resource format.
        /// Valid view formats for this video resource format are <see cref="DXGI_FORMAT_R16G16B16A16_UNORM"/> and <see cref="DXGI_FORMAT_R16G16B16A16_UINT"/>.
        /// Supported view types are SRV and UAV. One view provides a straightforward mapping of the entire surface.
        /// The mapping to the view channel is Y0->R16, U->G16, Y1->B16, and V->A16.
        /// For more info about YUV formats for video rendering, see Recommended 8-Bit YUV Formats for Video Rendering.
        /// Width must be even.
        /// Direct3D 11.1:  This value is not supported until Windows 8.
        /// </summary>
        DXGI_FORMAT_Y216 = 109,

        /// <summary>
        /// Most common planar YUV 4:1:1 video resource format.
        /// Valid luminance data view formats for this video resource format are <see cref="DXGI_FORMAT_R8_UNORM"/> and <see cref="DXGI_FORMAT_R8_UINT"/>.
        /// Valid chrominance data view formats (width and height are each 1/4 of luminance view)
        /// for this video resource format are <see cref="DXGI_FORMAT_R8G8_UNORM"/> and <see cref="DXGI_FORMAT_R8G8_UINT"/>.
        /// Supported view types are SRV, RTV, and UAV.
        /// For luminance data view, the mapping to the view channel is Y->R8.
        /// For chrominance data view, the mapping to the view channel is U->R8 and V->G8.
        /// For more info about YUV formats for video rendering, see Recommended 8-Bit YUV Formats for Video Rendering.
        /// Width must be a multiple of 4
        /// . Direct3D11 staging resources and initData parameters for this format use (rowPitch * height * 2) bytes.
        /// The first (SysMemPitch * height) bytes are the Y plane, the next ((SysMemPitch / 2) * height) bytes are the UV plane, and the remainder is padding.
        /// Direct3D 11.1:  This value is not supported until Windows 8.
        /// </summary>
        DXGI_FORMAT_NV11 = 110,

        /// <summary>
        /// 4-bit palletized YUV format that is commonly used for DVD subpicture.
        /// For more info about YUV formats for video rendering, see Recommended 8-Bit YUV Formats for Video Rendering.
        /// Direct3D 11.1:  This value is not supported until Windows 8.
        /// </summary>
        DXGI_FORMAT_AI44 = 111,

        /// <summary>
        /// 4-bit palletized YUV format that is commonly used for DVD subpicture.
        /// For more info about YUV formats for video rendering, see Recommended 8-Bit YUV Formats for Video Rendering.
        /// Direct3D 11.1:  This value is not supported until Windows 8.
        /// </summary>
        DXGI_FORMAT_IA44 = 112,

        /// <summary>
        /// 8-bit palletized format that is used for palletized RGB data when the processor processes ISDB-T data
        /// and for palletized YUV data when the processor processes BluRay data.
        /// For more info about YUV formats for video rendering, see Recommended 8-Bit YUV Formats for Video Rendering.
        /// Direct3D 11.1:  This value is not supported until Windows 8.
        /// </summary>
        DXGI_FORMAT_P8 = 113,

        /// <summary>
        /// 8-bit palletized format with 8 bits of alpha that is used for palletized YUV data when the processor processes BluRay data.
        /// For more info about YUV formats for video rendering, see Recommended 8-Bit YUV Formats for Video Rendering.
        /// Direct3D 11.1:  This value is not supported until Windows 8.
        /// </summary>
        DXGI_FORMAT_A8P8 = 114,

        /// <summary>
        /// A four-component, 16-bit unsigned-normalized integer format that supports 4 bits for each channel including alpha.
        /// Direct3D 11.1:  This value is not supported until Windows 8.
        /// </summary>
        DXGI_FORMAT_B4G4R4A4_UNORM = 115,

        /// <summary>
        /// A video format; an 8-bit version of a hybrid planar 4:2:2 format.
        /// </summary>
        DXGI_FORMAT_P208 = 130,

        /// <summary>
        /// An 8 bit YCbCrA 4:4 rendering format.
        /// </summary>
        DXGI_FORMAT_V208 = 131,

        /// <summary>
        /// An 8 bit YCbCrA 4:4 rendering format.
        /// </summary>
        DXGI_FORMAT_V408 = 132,

        /// <summary>
        /// 
        /// </summary>
        DXGI_FORMAT_SAMPLER_FEEDBACK_MIN_MIP_OPAQUE,

        /// <summary>
        /// 
        /// </summary>
        DXGI_FORMAT_SAMPLER_FEEDBACK_MIP_REGION_USED_OPAQUE,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits. This value is not used.
        /// </summary>
        DXGI_FORMAT_FORCE_UINT = unchecked((int)0xffffffff),
    }
}
