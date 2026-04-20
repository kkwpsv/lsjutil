using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes Direct3D 12 feature options in the current graphics driver.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_d3d12_options"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// See <see cref="D3D12_FEATURE"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_FEATURE_DATA_D3D12_OPTIONS
    {
        /// <para>
        /// Specifies whether <c>double</c> types are allowed for shader operations.
        /// If <see cref="TRUE"/>, double types are allowed; otherwise <see cref="FALSE"/>.
        /// The supported operations are equivalent to Direct3D 11's
        /// <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS.ExtendedDoublesShaderInstructions"/> member
        /// of the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS"/> structure.
        /// </para>
        /// <para>
        /// To use any HLSL shader that is compiled with a <c>double</c> type,
        /// the runtime must set <see cref="DoublePrecisionFloatShaderOps"/> to <see cref="TRUE"/>.
        /// </para>
        public BOOL DoublePrecisionFloatShaderOps;

        /// <summary>
        /// Specifies whether logic operations are available in blend state.
        /// The runtime sets this member to <see cref="TRUE"/> if logic operations are available in blend state
        /// and <see cref="FALSE"/> otherwise.
        /// This member is <see cref="FALSE"/> for feature level 9.1, 9.2, and 9.3.
        /// This member is optional for feature level 10, 10.1, and 11.
        /// This member is <see cref="TRUE"/> for feature level 11.1 and 12.
        /// </summary>
        public BOOL OutputMergerLogicOp;

        /// <summary>
        /// A combination of <see cref="D3D12_SHADER_MIN_PRECISION_SUPPORT"/>-typed values
        /// that are combined by using a bitwise OR operation.
        /// The resulting value specifies minimum precision levels that the driver supports for shader stages.
        /// A value of zero indicates that the driver supports only full 32-bit precision for all shader stages.
        /// </summary>
        public D3D12_SHADER_MIN_PRECISION_SUPPORT MinPrecisionSupport;

        /// <summary>
        /// Specifies whether the hardware and driver support tiled resources.
        /// The runtime sets this member to a <see cref="D3D12_TILED_RESOURCES_TIER"/>-typed value
        /// that indicates if the hardware and driver support tiled resources and at what tier level.
        /// </summary>
        public D3D12_TILED_RESOURCES_TIER TiledResourcesTier;

        /// <summary>
        /// Specifies the level at which the hardware and driver support resource binding.
        /// The runtime sets this member to a <see cref="D3D12_RESOURCE_BINDING_TIER"/>-typed value that indicates the tier level.
        /// </summary>
        public D3D12_RESOURCE_BINDING_TIER ResourceBindingTier;

        /// <summary>
        /// Specifies whether pixel shader stencil ref is supported.
        /// If <see cref="TRUE"/>, it's supported; otherwise <see cref="FALSE"/>.
        /// </summary>
        public BOOL PSSpecifiedStencilRefSupported;

        /// <summary>
        /// Specifies whether the loading of additional formats for typed unordered-access views (UAVs) is supported.
        /// If <see cref="TRUE"/>, it's supported; otherwise <see cref="FALSE"/>.
        /// </summary>
        public BOOL TypedUAVLoadAdditionalFormats;

        /// <summary>
        /// Specifies whether Rasterizer Order Views (ROVs) are supported.
        /// If <see cref="TRUE"/>, they're supported; otherwise <see cref="FALSE"/>.
        /// </summary>
        public BOOL ROVsSupported;

        /// <summary>
        /// Specifies the level at which the hardware and driver support conservative rasterization.
        /// The runtime sets this member to a <see cref="D3D12_CONSERVATIVE_RASTERIZATION_TIER"/>-typed value that indicates the tier level.
        /// </summary>
        public D3D12_CONSERVATIVE_RASTERIZATION_TIER ConservativeRasterizationTier;

        /// <summary>
        /// Don't use this field; instead, use the <see cref="D3D12_FEATURE_DATA_GPU_VIRTUAL_ADDRESS_SUPPORT"/> query
        /// (a structure with a <see cref="MaxGPUVirtualAddressBitsPerResource"/> member), which is more accurate.
        /// </summary>
        public UINT MaxGPUVirtualAddressBitsPerResource;

        /// <summary>
        /// <see cref="TRUE"/> if the hardware supports textures with the 64KB standard swizzle pattern.
        /// Support for this pattern enables zero-copy texture optimizations
        /// while providing near-equilateral locality for each dimension within the texture.
        /// For texture swizzle options and restrictions, see <see cref="D3D12_TEXTURE_LAYOUT"/>.
        /// </summary>
        public BOOL StandardSwizzle64KBSupported;

        /// <summary>
        /// A <see cref="D3D12_CROSS_NODE_SHARING_TIER"/> enumeration constant
        /// that specifies the level of sharing across nodes of an adapter that has multiple nodes,
        /// such as Tier 1 Emulated, Tier 1, or Tier 2.
        /// </summary>
        public D3D12_CROSS_NODE_SHARING_TIER CrossNodeSharingTier;

        /// <summary>
        /// <see cref="FALSE"/> means the device only supports copy operations to and from cross-adapter row-major textures.
        /// <see cref="TRUE"/> means the device supports shader resource views, unordered access views,
        /// and render target views of cross-adapter row-major textures.
        /// "Cross-adapter" means between multiple adapters (even from different IHVs).
        /// </summary>
        public BOOL CrossAdapterRowMajorTextureSupported;

        /// <summary>
        /// Whether the viewport (VP) and Render Target (RT) array index
        /// from any shader feeding the rasterizer are supported without geometry shader emulation.
        /// Compare the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS3.VPAndRTArrayIndexFromAnyShaderFeedingRasterizer"/> member
        /// of the <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS3"/> structure.
        /// In <see cref="ID3D12ShaderReflection.GetRequiresFlags"/>,
        /// see the <c>#define D3D_SHADER_REQUIRES_VIEWPORT_AND_RT_ARRAY_INDEX_FROM_ANY_SHADER_FEEDING_RASTERIZER</c>.
        /// </summary>
        public BOOL VPAndRTArrayIndexFromAnyShaderFeedingRasterizerSupportedWithoutGSEmulation;

        /// <summary>
        /// Specifies the level at which the hardware and driver require heap attribution related to resource type.
        /// The runtime sets this member to a <see cref="D3D12_RESOURCE_HEAP_TIER"/> enumeration constant.
        /// </summary>
        public D3D12_RESOURCE_HEAP_TIER ResourceHeapTier;
    }
}
