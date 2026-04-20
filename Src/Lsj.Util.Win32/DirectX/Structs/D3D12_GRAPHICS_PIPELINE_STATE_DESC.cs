using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_PRIMITIVE_TOPOLOGY_TYPE;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a graphics pipeline state object.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_graphics_pipeline_state_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This structure is used by the <see cref="ID3D12Device.CreateGraphicsPipelineState"/> method.
    /// </para>
    /// <para>
    /// The runtime validates:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// Whether the linkage between the shader stages is correct.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// If the <see cref="HS"/> and <see cref="DS"/> members are specified,
    /// the <see cref="PrimitiveTopologyType"/> member for topology type
    /// must be set to <see cref="D3D12_PRIMITIVE_TOPOLOGY_TYPE_PATCH"/>.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Whether sample frequency execution isn't allowed with the center multi-sample anti-aliasing (MSAA) pattern.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Whether anti-aliasing lines aren't allowed with the center MSAA pattern.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <para>
    /// If the <see cref="D3D12_RASTERIZER_DESC.ForcedSampleCount"/> member of <see cref="D3D12_RASTERIZER_DESC"/>
    /// that <see cref="RasterizerState"/> specifies isn't zero:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// Depth/stencil must be disabled.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Pixel shader can't output depth.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Pixel shader can't run at sample frequency.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Render target sample count must be 1.
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Whether blend state is compatible with render target formats.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Whether pixel shader output type is compatible with render target format.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Whether the sample count and quality are supported for the render target/depth stencil formats.
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_GRAPHICS_PIPELINE_STATE_DESC
    {
        /// <summary>
        /// A pointer to the <see cref="ID3D12RootSignature"/> object.
        /// </summary>
        public P<ID3D12RootSignature> pRootSignature;

        /// <summary>
        /// A <see cref="D3D12_SHADER_BYTECODE"/> structure that describes the vertex shader.
        /// </summary>
        public D3D12_SHADER_BYTECODE VS;

        /// <summary>
        /// A <see cref="D3D12_SHADER_BYTECODE"/> structure that describes the pixel shader.
        /// </summary>
        public D3D12_SHADER_BYTECODE PS;

        /// <summary>
        /// A <see cref="D3D12_SHADER_BYTECODE"/> structure that describes the domain shader.
        /// </summary>
        public D3D12_SHADER_BYTECODE DS;

        /// <summary>
        /// A <see cref="D3D12_SHADER_BYTECODE"/> structure that describes the hull shader.
        /// </summary>
        public D3D12_SHADER_BYTECODE HS;

        /// <summary>
        /// A <see cref="D3D12_SHADER_BYTECODE"/> structure that describes the geometry shader.
        /// </summary>
        public D3D12_SHADER_BYTECODE GS;

        /// <summary>
        /// A <see cref="D3D12_STREAM_OUTPUT_DESC"/> structure that describes a streaming output buffer.
        /// </summary>
        public D3D12_STREAM_OUTPUT_DESC StreamOutput;

        /// <summary>
        /// A <see cref="D3D12_BLEND_DESC"/> structure that describes the blend state.
        /// </summary>
        public D3D12_BLEND_DESC BlendState;

        /// <summary>
        /// The sample mask for the blend state.
        /// </summary>
        public UINT SampleMask;

        /// <summary>
        /// A <see cref="D3D12_RASTERIZER_DESC"/> structure that describes the rasterizer state.
        /// </summary>
        public D3D12_RASTERIZER_DESC RasterizerState;

        /// <summary>
        /// A <see cref="D3D12_DEPTH_STENCIL_DESC"/> structure that describes the depth-stencil state.
        /// </summary>
        public D3D12_DEPTH_STENCIL_DESC DepthStencilState;

        /// <summary>
        /// A <see cref="D3D12_INPUT_LAYOUT_DESC"/> structure that describes the input-buffer data for the input-assembler stage.
        /// </summary>
        public D3D12_INPUT_LAYOUT_DESC InputLayout;

        /// <summary>
        /// Specifies the properties of the index buffer in a <see cref="D3D12_INDEX_BUFFER_STRIP_CUT_VALUE"/> structure.
        /// </summary>
        public D3D12_INDEX_BUFFER_STRIP_CUT_VALUE IBStripCutValue;

        /// <summary>
        /// A <see cref="D3D12_PRIMITIVE_TOPOLOGY_TYPE"/>-typed value for the type of primitive, and ordering of the primitive data.
        /// </summary>
        public D3D12_PRIMITIVE_TOPOLOGY_TYPE PrimitiveTopologyType;

        /// <summary>
        /// The number of render target formats in the RTVFormats member.
        /// </summary>
        public UINT NumRenderTargets;

        /// <summary>
        /// An array of <see cref="DXGI_FORMAT"/>-typed values for the render target formats.
        /// </summary>
        public ByValDXGI_FORMATArrayStructForSize8 RTVFormatt;

        /// <summary>
        /// A <see cref="DXGI_FORMAT"/>-typed value for the depth-stencil format.
        /// </summary>
        public DXGI_FORMAT DSVFormat;

        /// <summary>
        /// A <see cref="DXGI_SAMPLE_DESC"/> structure that specifies multisampling parameters.
        /// </summary>
        public DXGI_SAMPLE_DESC SampleDesc;

        /// <summary>
        /// For single GPU operation, set this to zero.
        /// If there are multiple GPU nodes, set bits to identify the nodes (the device's physical adapters)
        /// for which the graphics pipeline state is to apply.
        /// Each bit in the mask corresponds to a single node.
        /// Refer to Multi-adapter systems.
        /// </summary>
        public UINT NodeMask;

        /// <summary>
        /// A cached pipeline state object, as a <see cref="D3D12_CACHED_PIPELINE_STATE"/> structure.
        /// <see cref="D3D12_CACHED_PIPELINE_STATE.pCachedBlob "/> and <see cref="D3D12_CACHED_PIPELINE_STATE.CachedBlobSizeInBytes"/>
        /// may be set to <see cref="NULL"/> and 0 respectively.
        /// </summary>
        public D3D12_CACHED_PIPELINE_STATE CachedPSO;

        /// <summary>
        /// A <see cref="D3D12_PIPELINE_STATE_FLAGS"/> enumeration constant such as for "tool debug".
        /// </summary>
        public D3D12_PIPELINE_STATE_FLAGS Flags;
    }
}
