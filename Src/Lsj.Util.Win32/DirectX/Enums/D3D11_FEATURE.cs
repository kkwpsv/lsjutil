using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Direct3D 11 feature options.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_feature"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enumeration is used when querying a driver about support for these features by calling <see cref="ID3D11Device.CheckFeatureSupport"/>.
    /// Each value in this enumeration has a corresponding data structure that is required to be passed
    /// to the pFeatureSupportData parameter of <see cref="ID3D11Device.CheckFeatureSupport"/>.
    /// </remarks>
    public enum D3D11_FEATURE
    {
        /// <summary>
        /// The driver supports multithreading.
        /// To see an example of testing a driver for multithread support, see How To: Check for Driver Support.
        /// Refer to <see cref="D3D11_FEATURE_DATA_THREADING"/>.
        /// </summary>
        D3D11_FEATURE_THREADING = 0,

        /// <summary>
        /// Supports the use of the double-precision shaders in HLSL.
        /// Refer to <see cref="D3D11_FEATURE_DATA_DOUBLES"/>.
        /// </summary>
        D3D11_FEATURE_DOUBLES,

        /// <summary>
        /// Supports the formats in <see cref="D3D11_FORMAT_SUPPORT"/>.
        /// Refer to <see cref="D3D11_FEATURE_DATA_FORMAT_SUPPORT"/>.
        /// </summary>
        D3D11_FEATURE_FORMAT_SUPPORT,

        /// <summary>
        /// Supports the formats in <see cref="D3D11_FORMAT_SUPPORT2"/>.
        /// Refer to <see cref="D3D11_FEATURE_DATA_FORMAT_SUPPORT2"/>.
        /// </summary>
        D3D11_FEATURE_FORMAT_SUPPORT2,

        /// <summary>
        /// Supports compute shaders and raw and structured buffers.
        /// Refer to <see cref="D3D11_FEATURE_DATA_D3D10_X_HARDWARE_OPTIONS"/>.
        /// </summary>
        D3D11_FEATURE_D3D10_X_HARDWARE_OPTIONS,

        /// <summary>
        /// <para>
        /// Supports Direct3D 11.1 feature options.
        /// Refer to <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS"/>.
        /// </para>
        /// <para>
        /// Direct3D 11:
        /// This value is not supported until Direct3D 11.1.
        /// </para>
        /// </summary>
        D3D11_FEATURE_D3D11_OPTIONS,

        /// <summary>
        /// <para>
        /// Supports specific adapter architecture.
        /// Refer to <see cref="D3D11_FEATURE_DATA_ARCHITECTURE_INFO"/>.
        /// </para>
        /// <para>
        /// Direct3D 11:
        /// This value is not supported until Direct3D 11.1.
        /// </para>
        /// </summary>
        D3D11_FEATURE_ARCHITECTURE_INFO,

        /// <summary>
        /// <para>
        /// Supports Direct3D 9 feature options.
        /// Refer to <see cref="D3D11_FEATURE_DATA_D3D9_OPTIONS"/>.
        /// </para>
        /// <para>
        /// Direct3D 11:
        /// This value is not supported until Direct3D 11.1.
        /// </para>
        /// </summary>
        D3D11_FEATURE_D3D9_OPTIONS,

        /// <summary>
        /// <para>
        /// Supports minimum precision of shaders.
        /// For more info about HLSL minimum precision, see using HLSL minimum precision.
        /// Refer to <see cref="D3D11_FEATURE_DATA_SHADER_MIN_PRECISION_SUPPORT"/>.
        /// </para>
        /// <para>
        /// Direct3D 11:
        /// This value is not supported until Direct3D 11.1.
        /// </para>
        /// </summary>
        D3D11_FEATURE_SHADER_MIN_PRECISION_SUPPORT,

        /// <summary>
        /// <para>
        /// Supports Direct3D 9 shadowing feature.
        /// Refer to <see cref="D3D11_FEATURE_DATA_D3D9_SHADOW_SUPPORT"/>.
        /// </para>
        /// <para>
        /// Direct3D 11:
        /// This value is not supported until Direct3D 11.1.
        /// </para>
        /// </summary>
        D3D11_FEATURE_D3D9_SHADOW_SUPPORT,

        /// <summary>
        /// <para>
        /// Supports Direct3D 11.2 feature options.
        /// Refer to <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/>.
        /// </para>
        /// <para>
        /// Direct3D 11:
        /// This value is not supported until Direct3D 11.2.
        /// </para>
        /// </summary>
        D3D11_FEATURE_D3D11_OPTIONS1,

        /// <summary>
        /// <para>
        /// Supports Direct3D 11.2 instancing options.
        /// Refer to <see cref="D3D11_FEATURE_DATA_D3D9_SIMPLE_INSTANCING_SUPPORT"/>.
        /// </para>
        /// <para>
        /// Direct3D 11:
        /// This value is not supported until Direct3D 11.2.
        /// </para>
        /// </summary>
        D3D11_FEATURE_D3D9_SIMPLE_INSTANCING_SUPPORT,

        /// <summary>
        /// <para>
        /// Supports Direct3D 11.2 marker options.
        /// Refer to <see cref="D3D11_FEATURE_DATA_MARKER_SUPPORT"/>.
        /// </para>
        /// <para>
        /// Direct3D 11:
        /// This value is not supported until Direct3D 11.2.
        /// </para>
        /// </summary>
        D3D11_FEATURE_MARKER_SUPPORT,

        /// <summary>
        /// <para>
        /// Supports Direct3D 9 feature options, which includes the Direct3D 9 shadowing feature and instancing support.
        /// Refer to <see cref="D3D11_FEATURE_DATA_D3D9_OPTIONS1"/>.
        /// </para>
        /// <para>
        /// Direct3D 11:
        /// This value is not supported until Direct3D 11.2.
        /// </para>
        /// </summary>
        D3D11_FEATURE_D3D9_OPTIONS1,

        /// <summary>
        /// <para>
        /// Supports Direct3D 11.3 conservative rasterization feature options.
        /// Refer to <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS2"/>.
        /// </para>
        /// <para>
        /// Direct3D 11: 
        /// This value is not supported until Direct3D 11.3.
        /// </para>
        /// </summary>
        D3D11_FEATURE_D3D11_OPTIONS2,

        /// <summary>
        /// <para>
        /// Supports Direct3D 11.4 conservative rasterization feature options.
        /// Refer to <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS3"/>.
        /// </para>
        /// <para>
        /// Direct3D 11:
        /// This value is not supported until Direct3D 11.4.
        /// </para>
        /// </summary>
        D3D11_FEATURE_D3D11_OPTIONS3,

        /// <summary>
        /// Supports GPU virtual addresses.
        /// Refer to <see cref="D3D11_FEATURE_DATA_GPU_VIRTUAL_ADDRESS_SUPPORT"/>.
        /// </summary>
        D3D11_FEATURE_GPU_VIRTUAL_ADDRESS_SUPPORT,

        /// <summary>
        /// <para>
        /// Supports a single boolean for NV12 shared textures.
        /// Refer to <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS4"/>.
        /// </para>
        /// <para>
        /// Direct3D 11:  This value is not supported until Direct3D 11.4.
        /// </para>
        /// </summary>
        D3D11_FEATURE_D3D11_OPTIONS4,

        /// <summary>
        /// Supports shader cache, described in <see cref="D3D11_FEATURE_DATA_SHADER_CACHE"/>.
        /// </summary>
        D3D11_FEATURE_SHADER_CACHE,

        /// <summary>
        /// Supports a <see cref="D3D11_SHARED_RESOURCE_TIER"/> to indicate
        /// the level of support for shared resources in the current graphics driver.
        /// Refer to <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS5"/>.
        /// </summary>
        D3D11_FEATURE_D3D11_OPTIONS5,

        /// <summary>
        /// Supports displayable surfaces, described in <see cref="D3D11_FEATURE_DATA_DISPLAYABLE"/>.
        /// </summary>
        D3D11_FEATURE_DISPLAYABLE,

        /// <summary>
        /// 
        /// </summary>
        D3D11_FEATURE_D3D11_OPTIONS6,
    }
}
