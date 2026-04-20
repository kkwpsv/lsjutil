using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines constants that specify a Direct3D 12 feature or feature set to query about.
    /// When you want to query for the level to which an adapter supports a feature,
    /// pass one of these values to <see cref="ID3D12Device.CheckFeatureSupport"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_feature"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Use a constant from this enumeration in a call to <see cref="ID3D12Device.CheckFeatureSupport"/>
    /// to query a driver about support for various Direct3D 12 features.
    /// Each value in this enumeration has a corresponding data structure that you must pass (by pointer reference)
    /// in the <c>pFeatureSupportData</c> parameter of <see cref="ID3D12Device.CheckFeatureSupport"/>.
    /// </remarks>
    public enum D3D12_FEATURE
    {
        /// <summary>
        /// Indicates a query for the level of support for basic Direct3D 12 feature options.
        /// The corresponding data structure for this value is <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS"/>.
        /// </summary>
        D3D12_FEATURE_D3D12_OPTIONS = 0,

        /// <summary>
        /// <para>
        /// Indicates a query for the adapter's architectural details,
        /// so that your application can better optimize for certain adapter properties.
        /// The corresponding data structure for this value is <see cref="D3D12_FEATURE_DATA_ARCHITECTURE"/>.
        /// </para>
        /// <para>
        /// Note  This value has been superseded by the <see cref="D3D_FEATURE_DATA_ARCHITECTURE1"/> value.
        /// If your application targets Windows 10, version 1703 (Creators' Update) or higher,
        /// then use the <see cref="D3D_FEATURE_DATA_ARCHITECTURE1"/> value instead.
        /// </para>
        /// </summary>
        D3D12_FEATURE_ARCHITECTURE = 1,

        /// <summary>
        /// Indicates a query for info about the feature levels supported.
        /// The corresponding data structure for this value is <see cref="D3D12_FEATURE_DATA_FEATURE_LEVELS"/>.
        /// </summary>
        D3D12_FEATURE_FEATURE_LEVELS = 2,

        /// <summary>
        /// Indicates a query for the resources supported by the current graphics driver for a given format.
        /// The corresponding data structure for this value is <see cref="D3D12_FEATURE_DATA_FORMAT_SUPPORT"/>.
        /// </summary>
        D3D12_FEATURE_FORMAT_SUPPORT = 3,

        /// <summary>
        /// Indicates a query for the image quality levels for a given format and sample count.
        /// The corresponding data structure for this value is <see cref="D3D12_FEATURE_DATA_MULTISAMPLE_QUALITY_LEVELS"/>.
        /// </summary>
        D3D12_FEATURE_MULTISAMPLE_QUALITY_LEVELS = 4,

        /// <summary>
        /// Indicates a query for the DXGI data format.
        /// The corresponding data structure for this value is <see cref="D3D12_FEATURE_DATA_FORMAT_INFO"/>.
        /// </summary>
        D3D12_FEATURE_FORMAT_INFO = 5,

        /// <summary>
        /// Indicates a query for the GPU's virtual address space limitations.
        /// The corresponding data structure for this value is <see cref="D3D12_FEATURE_DATA_GPU_VIRTUAL_ADDRESS_SUPPORT"/>.
        /// </summary>
        D3D12_FEATURE_GPU_VIRTUAL_ADDRESS_SUPPORT = 6,

        /// <summary>
        /// Indicates a query for the supported shader model.
        /// The corresponding data structure for this value is <see cref="D3D12_FEATURE_DATA_SHADER_MODEL"/>.
        /// </summary>
        D3D12_FEATURE_SHADER_MODEL = 7,

        /// <summary>
        /// Indicates a query for the level of support for HLSL 6.0 wave operations.
        /// The corresponding data structure for this value is <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS1"/>.
        /// </summary>
        D3D12_FEATURE_D3D12_OPTIONS1 = 8,

        /// <summary>
        /// Indicates a query for the level of support for protected resource sessions.
        /// The corresponding data structure for this value is <see cref="D3D12_FEATURE_DATA_PROTECTED_RESOURCE_SESSION_SUPPORT"/>.
        /// </summary>
        D3D12_FEATURE_PROTECTED_RESOURCE_SESSION_SUPPORT = 10,

        /// <summary>
        /// Indicates a query for root signature version support.
        /// The corresponding data structure for this value is <see cref="D3D12_FEATURE_DATA_ROOT_SIGNATURE"/>.
        /// </summary>
        D3D12_FEATURE_ROOT_SIGNATURE = 12,

        /// <summary>
        /// <para>
        /// Indicates a query for each adapter's architectural details,
        /// so that your application can better optimize for certain adapter properties.
        /// The corresponding data structure for this value is <see cref="D3D12_FEATURE_DATA_ARCHITECTURE1"/>.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This value supersedes the <see cref="D3D_FEATURE_DATA_ARCHITECTURE"/> value.
        /// If your application targets Windows 10, version 1703 (Creators' Update) or higher,
        /// then use <see cref="D3D_FEATURE_DATA_ARCHITECTURE1"/>.
        /// </para>
        /// </summary>
        D3D12_FEATURE_ARCHITECTURE1 = 16,

        /// <summary>
        /// Indicates a query for the level of support for depth-bounds tests and programmable sample positions.
        /// The corresponding data structure for this value is <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS2"/>.
        /// </summary>
        D3D12_FEATURE_D3D12_OPTIONS2 = 18,

        /// <summary>
        /// Indicates a query for the level of support for shader caching.
        /// The corresponding data structure for this value is <see cref="D3D12_FEATURE_DATA_SHADER_CACHE"/>.
        /// </summary>
        D3D12_FEATURE_SHADER_CACHE = 19,

        /// <summary>
        /// Indicates a query for the adapter's support for prioritization of different command queue types.
        /// The corresponding data structure for this value is <see cref="D3D12_FEATURE_DATA_COMMAND_QUEUE_PRIORITY"/>.
        /// </summary>
        D3D12_FEATURE_COMMAND_QUEUE_PRIORITY = 20,

        /// <summary>
        /// Indicates a query for the level of support for timestamp queries, format-casting,
        /// immediate write, view instancing, and barycentrics.
        /// The corresponding data structure for this value is <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS3"/>.
        /// </summary>
        D3D12_FEATURE_D3D12_OPTIONS3 = 21,

        /// <summary>
        /// Indicates a query for whether or not the adapter supports creating heaps from existing system memory.
        /// The corresponding data structure for this value is <see cref="D3D12_FEATURE_DATA_EXISTING_HEAPS"/>.
        /// </summary>
        D3D12_FEATURE_EXISTING_HEAPS = 22,

        /// <summary>
        /// Indicates a query for the level of support for 64KB-aligned MSAA textures,
        /// cross-API sharing, and native 16-bit shader operations.
        /// The corresponding data structure for this value is <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS4"/>.
        /// </summary>
        D3D12_FEATURE_D3D12_OPTIONS4 = 23,

        /// <summary>
        /// Indicates a query for the level of support for heap serialization.
        /// The corresponding data structure for this value is <see cref="D3D12_FEATURE_DATA_SERIALIZATION"/>.
        /// </summary>
        D3D12_FEATURE_SERIALIZATION = 24,

        /// <summary>
        /// Indicates a query for the level of support for the sharing of resources between different adapters—for example, multiple GPUs.
        /// The corresponding data structure for this value is <see cref="D3D12_FEATURE_DATA_CROSS_NODE"/>.
        /// </summary>
        D3D12_FEATURE_CROSS_NODE = 25,

        /// <summary>
        /// Starting with Windows 10, version 1809 (10.0; Build 17763),
        /// indicates a query for the level of support for render passes, ray tracing,
        /// and shader-resource view tier 3 tiled resources.
        /// The corresponding data structure for this value is <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS5"/>.
        /// </summary>
        D3D12_FEATURE_D3D12_OPTIONS5 = 27,

        /// <summary>
        /// Starting with Windows 11 (Build 10.0.22000.194).
        /// The corresponding data structure for this value is <see cref="D3D12_FEATURE_DATA_DISPLAYABLE"/>.
        /// </summary>
        D3D12_FEATURE_DISPLAYABLE = 28,

        /// <summary>
        /// <para>
        /// Starting with Windows 10, version 1903 (10.0; Build 18362),
        /// indicates a query for the level of support for variable-rate shading (VRS),
        /// and indicates whether or not background processing is supported.
        /// The corresponding data structure for this value is <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS6"/>.
        /// </para>
        /// <para>
        /// For more info, see Variable-rate shading (VRS), and the Direct3D 12 background processing spec.
        /// </para>
        /// </summary>
        D3D12_FEATURE_D3D12_OPTIONS6 = 30,

        /// <summary>
        /// Indicates a query for the level of support for metacommands.
        /// The corresponding data structure for this value is <see cref="D3D12_FEATURE_DATA_QUERY_META_COMMAND"/>.
        /// </summary>
        D3D12_FEATURE_QUERY_META_COMMAND = 31,

        /// <summary>
        /// <para>
        /// Starting with Windows 10, version 2004 (10.0; Build 19041),
        /// indicates a query for the level of support for mesh and amplification shaders, and for sampler feedback.
        /// The corresponding data structure for this value is <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS7"/>.
        /// </para>
        /// <para>
        /// For more info, see the Mesh shader and Sampler feedback specs.
        /// </para>
        /// </summary>
        D3D12_FEATURE_D3D12_OPTIONS7 = 32,

        /// <summary>
        /// Starting with Windows 10, version 2004 (10.0; Build 19041),
        /// indicates a query to retrieve the count of protected resource session types.
        /// The corresponding data structure for this value is <see cref="D3D12_FEATURE_DATA_PROTECTED_RESOURCE_SESSION_TYPE_COUNT"/>.
        /// </summary>
        D3D12_FEATURE_PROTECTED_RESOURCE_SESSION_TYPE_COUNT = 33,

        /// <summary>
        /// Starting with Windows 10, version 2004 (10.0; Build 19041),
        /// indicates a query to retrieve the list of protected resource session types.
        /// The corresponding data structure for this value is <see cref="D3D12_FEATURE_DATA_PROTECTED_RESOURCE_SESSION_TYPES"/>.
        /// </summary>
        D3D12_FEATURE_PROTECTED_RESOURCE_SESSION_TYPES = 34,

        /// <summary>
        /// Starting with Windows 11 (Build 10.0.22000.194),
        /// indicates whether or not unaligned block-compressed textures are supported.
        /// The corresponding data structure for this value is <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS8"/>.
        /// </summary>
        D3D12_FEATURE_D3D12_OPTIONS8 = 36,

        /// <summary>
        /// Starting with Windows 11 (Build 10.0.22000.194), indicates whether or not support exists for mesh shaders,
        /// values of <c>SV_RenderTargetArrayIndex</c> that are 8 or greater,
        /// typed resource 64-bit integer atomics, derivative and derivative-dependent texture sample operations,
        /// and the level of support for WaveMMA (wave_matrix) operations.
        /// The corresponding data structure for this value is <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS9"/>.
        /// </summary>
        D3D12_FEATURE_D3D12_OPTIONS9 = 37,

        /// <summary>
        /// Starting with Windows 11 (Build 10.0.22000.194), indicates whether or not the SUM combiner can be used,
        /// and whether or not <c>SV_ShadingRate</c> can be set from a mesh shader.
        /// The corresponding data structure for this value is <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS10"/>.
        /// </summary>
        D3D12_FEATURE_D3D12_OPTIONS10 = 39,

        /// <summary>
        /// Starting with Windows 11 (Build 10.0.22000.194),
        /// indicates whether or not 64-bit integer atomics on resources in descriptor heaps are supported.
        /// The corresponding data structure for this value is <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS11"/>.
        /// </summary>
        D3D12_FEATURE_D3D12_OPTIONS11 = 40,

        /// <summary>
        /// 
        /// </summary>
        D3D12_FEATURE_D3D12_OPTIONS12 = 41,

        /// <summary>
        /// 
        /// </summary>
        D3D12_FEATURE_D3D12_OPTIONS13 = 42,

        /// <summary>
        /// 
        /// </summary>
        D3D12_FEATURE_D3D12_OPTIONS14 = 43,

        /// <summary>
        /// 
        /// </summary>
        D3D12_FEATURE_D3D12_OPTIONS15 = 44,

        /// <summary>
        /// 
        /// </summary>
        D3D12_FEATURE_D3D12_OPTIONS16 = 45,

        /// <summary>
        /// 
        /// </summary>
        D3D12_FEATURE_D3D12_OPTIONS17 = 46,

        /// <summary>
        /// 
        /// </summary>
        D3D12_FEATURE_D3D12_OPTIONS18 = 47,

        /// <summary>
        /// 
        /// </summary>
        D3D12_FEATURE_D3D12_OPTIONS19 = 48,

        /// <summary>
        /// 
        /// </summary>
        D3D12_FEATURE_D3D12_OPTIONS20 = 49,

        /// <summary>
        /// 
        /// </summary>
        D3D12_FEATURE_PREDICATION = 50,

        /// <summary>
        /// 
        /// </summary>
        D3D12_FEATURE_PLACED_RESOURCE_SUPPORT_INFO = 51,

        /// <summary>
        /// 
        /// </summary>
        D3D12_FEATURE_HARDWARE_COPY = 52,

        /// <summary>
        /// 
        /// </summary>
        D3D12_FEATURE_D3D12_OPTIONS21 = 53,

        /// <summary>
        /// 
        /// </summary>
        D3D12_FEATURE_APPLICATION_SPECIFIC_DRIVER_STATE = 56,

        /// <summary>
        /// 
        /// </summary>
        D3D12_FEATURE_BYTECODE_BYPASS_HASH_SUPPORTED = 57,

        /// <summary>
        /// 
        /// </summary>
        D3D12_FEATURE_SHADER_CACHE_ABI_SUPPORT = 61
    }
}
