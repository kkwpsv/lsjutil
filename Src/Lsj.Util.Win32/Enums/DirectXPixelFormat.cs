using Lsj.Util.Win32.DirectX.Enums;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Specifies pixel formats, which includes fully-typed and type-less formats.
    /// This is a Windows Runtime equivalent of the Desktop <see cref="DXGI_FORMAT"/> enumeration.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/uwp/api/windows.graphics.directx.directxpixelformat"/>
    /// </para>
    /// </summary>
    public enum DirectXPixelFormat : int
    {
        /// <summary>
        /// See <see cref="DXGI_FORMAT_UNKNOWN"/>.
        /// </summary>
        DirectXPixelFormat_Unknown = 0,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R32G32B32A32_TYPELESS"/>.
        /// </summary>
        DirectXPixelFormat_R32G32B32A32Typeless = 1,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R32G32B32A32_FLOAT"/>.
        /// </summary>
        DirectXPixelFormat_R32G32B32A32Float = 2,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R32G32B32A32_UINT"/>.
        /// </summary>
        DirectXPixelFormat_R32G32B32A32UInt = 3,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R32G32B32A32_SINT"/>.
        /// </summary>
        DirectXPixelFormat_R32G32B32A32Int = 4,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R32G32B32_TYPELESS"/>.
        /// </summary>
        DirectXPixelFormat_R32G32B32Typeless = 5,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R32G32B32_FLOAT"/>.
        /// </summary>
        DirectXPixelFormat_R32G32B32Float = 6,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R32G32B32_UINT"/>.
        /// </summary>
        DirectXPixelFormat_R32G32B32UInt = 7,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R32G32B32_SINT"/>.
        /// </summary>
        DirectXPixelFormat_R32G32B32Int = 8,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R16G16B16A16_TYPELESS"/>.
        /// </summary>
        DirectXPixelFormat_R16G16B16A16Typeless = 9,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R16G16B16A16_FLOAT"/>.
        /// </summary>
        DirectXPixelFormat_R16G16B16A16Float = 10,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R16G16B16A16_UNORM"/>.
        /// </summary>
        DirectXPixelFormat_R16G16B16A16UIntNormalized = 11,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R16G16B16A16_UINT"/>.
        /// </summary>
        DirectXPixelFormat_R16G16B16A16UInt = 12,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R16G16B16A16_SNORM"/>.
        /// </summary>
        DirectXPixelFormat_R16G16B16A16IntNormalized = 13,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R16G16B16A16_SINT"/>.
        /// </summary>
        DirectXPixelFormat_R16G16B16A16Int = 14,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R32G32_TYPELESS"/>.
        /// </summary>
        DirectXPixelFormat_R32G32Typeless = 15,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R32G32_FLOAT"/>.
        /// </summary>
        DirectXPixelFormat_R32G32Float = 16,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R32G32_UINT"/>.
        /// </summary>
        DirectXPixelFormat_R32G32UInt = 17,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R32G32_SINT"/>.
        /// </summary>
        DirectXPixelFormat_R32G32Int = 18,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R32G8X24_TYPELESS"/>.
        /// </summary>
        DirectXPixelFormat_R32G8X24Typeless = 19,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_D32_FLOAT_S8X24_UINT"/>.
        /// </summary>
        DirectXPixelFormat_D32FloatS8X24UInt = 20,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R32_FLOAT_X8X24_TYPELESS"/>.
        /// </summary>
        DirectXPixelFormat_R32FloatX8X24Typeless = 21,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_X32_TYPELESS_G8X24_UINT"/>.
        /// </summary>
        DirectXPixelFormat_X32TypelessG8X24UInt = 22,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R10G10B10A2_TYPELESS"/>.
        /// </summary>
        DirectXPixelFormat_R10G10B10A2Typeless = 23,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R10G10B10A2_UNORM"/>.
        /// </summary>
        DirectXPixelFormat_R10G10B10A2UIntNormalized = 24,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R10G10B10A2_UINT"/>.
        /// </summary>
        DirectXPixelFormat_R10G10B10A2UInt = 25,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R11G11B10_FLOAT"/>.
        /// </summary>
        DirectXPixelFormat_R11G11B10Float = 26,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R8G8B8A8_TYPELESS"/>.
        /// </summary>
        DirectXPixelFormat_R8G8B8A8Typeless = 27,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R8G8B8A8_UNORM"/>.
        /// </summary>
        DirectXPixelFormat_R8G8B8A8UIntNormalized = 28,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R8G8B8A8_UNORM_SRGB"/>.
        /// </summary>
        DirectXPixelFormat_R8G8B8A8UIntNormalizedSrgb = 29,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R8G8B8A8_UINT"/>.
        /// </summary>
        DirectXPixelFormat_R8G8B8A8UInt = 30,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R8G8B8A8_SNORM"/>.
        /// </summary>
        DirectXPixelFormat_R8G8B8A8IntNormalized = 31,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R8G8B8A8_SINT"/>.
        /// </summary>
        DirectXPixelFormat_R8G8B8A8Int = 32,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R16G16_TYPELESS"/>.
        /// </summary>
        DirectXPixelFormat_R16G16Typeless = 33,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R16G16_FLOAT"/>.
        /// </summary>
        DirectXPixelFormat_R16G16Float = 34,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R16G16_UNORM"/>.
        /// </summary>
        DirectXPixelFormat_R16G16UIntNormalized = 35,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R16G16_UINT"/>.
        /// </summary>
        DirectXPixelFormat_R16G16UInt = 36,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R16G16_SNORM"/>.
        /// </summary>
        DirectXPixelFormat_R16G16IntNormalized = 37,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R16G16_SINT"/>.
        /// </summary>
        DirectXPixelFormat_R16G16Int = 38,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R32_TYPELESS"/>.
        /// </summary>
        DirectXPixelFormat_R32Typeless = 39,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_D32_FLOAT"/>.
        /// </summary>
        DirectXPixelFormat_D32Float = 40,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R32_FLOAT"/>.
        /// </summary>
        DirectXPixelFormat_R32Float = 41,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R32_UINT"/>.
        /// </summary>
        DirectXPixelFormat_R32UInt = 42,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R32_SINT"/>.
        /// </summary>
        DirectXPixelFormat_R32Int = 43,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R24G8_TYPELESS"/>.
        /// </summary>
        DirectXPixelFormat_R24G8Typeless = 44,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_D24_UNORM_S8_UINT"/>.
        /// </summary>
        DirectXPixelFormat_D24UIntNormalizedS8UInt = 45,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R24_UNORM_X8_TYPELESS"/>.
        /// </summary>
        DirectXPixelFormat_R24UIntNormalizedX8Typeless = 46,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_X24_TYPELESS_G8_UINT"/>.
        /// </summary>
        DirectXPixelFormat_X24TypelessG8UInt = 47,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R8G8_TYPELESS"/>.
        /// </summary>
        DirectXPixelFormat_R8G8Typeless = 48,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R8G8_UNORM"/>.
        /// </summary>
        DirectXPixelFormat_R8G8UIntNormalized = 49,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R8G8_UINT"/>.
        /// </summary>
        DirectXPixelFormat_R8G8UInt = 50,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R8G8_SNORM"/>.
        /// </summary>
        DirectXPixelFormat_R8G8IntNormalized = 51,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R8G8_SINT"/>.
        /// </summary>
        DirectXPixelFormat_R8G8Int = 52,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R16_TYPELESS"/>.
        /// </summary>
        DirectXPixelFormat_R16Typeless = 53,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R16_FLOAT"/>.
        /// </summary>
        DirectXPixelFormat_R16Float = 54,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_D16_UNORM"/>.
        /// </summary>
        DirectXPixelFormat_D16UIntNormalized = 55,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R16_UNORM"/>.
        /// </summary>
        DirectXPixelFormat_R16UIntNormalized = 56,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R16_UINT"/>.
        /// </summary>
        DirectXPixelFormat_R16UInt = 57,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R16_SNORM"/>.
        /// </summary>
        DirectXPixelFormat_R16IntNormalized = 58,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R16_SINT"/>.
        /// </summary>
        DirectXPixelFormat_R16Int = 59,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R8_TYPELESS"/>.
        /// </summary>
        DirectXPixelFormat_R8Typeless = 60,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R8_UNORM"/>.
        /// </summary>
        DirectXPixelFormat_R8UIntNormalized = 61,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R8_UINT"/>.
        /// </summary>
        DirectXPixelFormat_R8UInt = 62,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R8_SNORM"/>.
        /// </summary>
        DirectXPixelFormat_R8IntNormalized = 63,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R8_SINT"/>.
        /// </summary>
        DirectXPixelFormat_R8Int = 64,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_A8_UNORM"/>.
        /// </summary>
        DirectXPixelFormat_A8UIntNormalized = 65,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R1_UNORM"/>.
        /// </summary>
        DirectXPixelFormat_R1UIntNormalized = 66,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R9G9B9E5_SHAREDEXP"/>.
        /// </summary>
        DirectXPixelFormat_R9G9B9E5SharedExponent = 67,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R8G8_B8G8_UNORM"/>.
        /// </summary>
        DirectXPixelFormat_R8G8B8G8UIntNormalized = 68,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_G8R8_G8B8_UNORM"/>.
        /// </summary>
        DirectXPixelFormat_G8R8G8B8UIntNormalized = 69,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_BC1_TYPELESS"/>.
        /// </summary>
        DirectXPixelFormat_BC1Typeless = 70,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_BC1_UNORM"/>.
        /// </summary>
        DirectXPixelFormat_BC1UIntNormalized = 71,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_BC1_UNORM_SRGB"/>.
        /// </summary>
        DirectXPixelFormat_BC1UIntNormalizedSrgb = 72,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_BC2_TYPELESS"/>.
        /// </summary>
        DirectXPixelFormat_BC2Typeless = 73,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_BC2_UNORM"/>.
        /// </summary>
        DirectXPixelFormat_BC2UIntNormalized = 74,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_BC2_UNORM_SRGB"/>.
        /// </summary>
        DirectXPixelFormat_BC2UIntNormalizedSrgb = 75,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_BC3_TYPELESS"/>.
        /// </summary>
        DirectXPixelFormat_BC3Typeless = 76,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_BC3_UNORM"/>.
        /// </summary>
        DirectXPixelFormat_BC3UIntNormalized = 77,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_BC3_UNORM_SRGB"/>.
        /// </summary>
        DirectXPixelFormat_BC3UIntNormalizedSrgb = 78,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_BC4_TYPELESS"/>.
        /// </summary>
        DirectXPixelFormat_BC4Typeless = 79,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_BC4_UNORM"/>.
        /// </summary>
        DirectXPixelFormat_BC4UIntNormalized = 80,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_BC4_SNORM"/>.
        /// </summary>
        DirectXPixelFormat_BC4IntNormalized = 81,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_BC5_TYPELESS"/>.
        /// </summary>
        DirectXPixelFormat_BC5Typeless = 82,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_BC5_UNORM"/>.
        /// </summary>
        DirectXPixelFormat_BC5UIntNormalized = 83,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_BC5_SNORM"/>.
        /// </summary>
        DirectXPixelFormat_BC5IntNormalized = 84,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_B5G6R5_UNORM"/>.
        /// </summary>
        DirectXPixelFormat_B5G6R5UIntNormalized = 85,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_B5G5R5A1_UNORM"/>.
        /// </summary>
        DirectXPixelFormat_B5G5R5A1UIntNormalized = 86,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_B8G8R8A8_UNORM"/>.
        /// </summary>
        DirectXPixelFormat_B8G8R8A8UIntNormalized = 87,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_B8G8R8X8_UNORM"/>.
        /// </summary>
        DirectXPixelFormat_B8G8R8X8UIntNormalized = 88,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_R10G10B10_XR_BIAS_A2_UNORM"/>.
        /// </summary>
        DirectXPixelFormat_R10G10B10XRBiasA2UIntNormalized = 89,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_B8G8R8A8_TYPELESS"/>.
        /// </summary>
        DirectXPixelFormat_B8G8R8A8Typeless = 90,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_B8G8R8A8_UNORM_SRGB"/>.
        /// </summary>
        DirectXPixelFormat_B8G8R8A8UIntNormalizedSrgb = 91,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_B8G8R8X8_TYPELESS"/>.
        /// </summary>
        DirectXPixelFormat_B8G8R8X8Typeless = 92,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_B8G8R8X8_UNORM_SRGB"/>.
        /// </summary>
        DirectXPixelFormat_B8G8R8X8UIntNormalizedSrgb = 93,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_BC6H_TYPELESS"/>.
        /// </summary>
        DirectXPixelFormat_BC6HTypeless = 94,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_BC6H_UF16"/>.
        /// </summary>
        DirectXPixelFormat_BC6H16UnsignedFloat = 95,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_BC6H_SF16"/>.
        /// </summary>
        DirectXPixelFormat_BC6H16Float = 96,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_BC7_TYPELESS"/>.
        /// </summary>
        DirectXPixelFormat_BC7Typeless = 97,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_BC7_UNORM"/>.
        /// </summary>
        DirectXPixelFormat_BC7UIntNormalized = 98,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_BC7_UNORM_SRGB"/>.
        /// </summary>
        DirectXPixelFormat_BC7UIntNormalizedSrgb = 99,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_AYUV"/>.
        /// </summary>
        DirectXPixelFormat_Ayuv = 100,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_Y410"/>.
        /// </summary>
        DirectXPixelFormat_Y410 = 101,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_Y416"/>.
        /// </summary>
        DirectXPixelFormat_Y416 = 102,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_NV12"/>.
        /// </summary>
        DirectXPixelFormat_NV12 = 103,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_P010"/>.
        /// </summary>
        DirectXPixelFormat_P010 = 104,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_P016"/>.
        /// </summary>
        DirectXPixelFormat_P016 = 105,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_420_OPAQUE"/>.
        /// </summary>
        DirectXPixelFormat_Opaque420 = 106,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_YUY2"/>.
        /// </summary>
        DirectXPixelFormat_Yuy2 = 107,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_Y210"/>.
        /// </summary>
        DirectXPixelFormat_Y210 = 108,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_Y216"/>.
        /// </summary>
        DirectXPixelFormat_Y216 = 109,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_NV11"/>.
        /// </summary>
        DirectXPixelFormat_NV11 = 110,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_AI44"/>.
        /// </summary>
        DirectXPixelFormat_AI44 = 111,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_IA44"/>.
        /// </summary>
        DirectXPixelFormat_IA44 = 112,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_P8"/>.
        /// </summary>
        DirectXPixelFormat_P8 = 113,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_A8P8"/>.
        /// </summary>
        DirectXPixelFormat_A8P8 = 114,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_B4G4R4A4_UNORM"/>.
        /// </summary>
        DirectXPixelFormat_B4G4R4A4UIntNormalized = 115,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_P208"/>.
        /// </summary>
        DirectXPixelFormat_P208 = 130,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_V208"/>.
        /// </summary>
        DirectXPixelFormat_V208 = 131,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_V408"/>.
        /// </summary>
        DirectXPixelFormat_V408 = 132,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_SAMPLER_FEEDBACK_MIN_MIP_OPAQUE"/>.
        /// </summary>
        DirectXPixelFormat_SamplerFeedbackMinMipOpaque = 189,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_SAMPLER_FEEDBACK_MIP_REGION_USED_OPAQUE"/>.
        /// </summary>
        DirectXPixelFormat_SamplerFeedbackMipRegionUsedOpaque = 190,

        /// <summary>
        /// See <see cref="DXGI_FORMAT_A4B4G4R4_UNORM"/>.
        /// </summary>
        DirectXPixelFormat_A4B4G4R4 = 191,

    }
}
