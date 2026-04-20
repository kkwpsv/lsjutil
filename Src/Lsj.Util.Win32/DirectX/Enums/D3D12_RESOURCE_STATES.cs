using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_SRV_DIMENSION;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines constants that specify the state of a resource regarding how the resource is being used.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_resource_states"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This enum is used by the following methods:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="ID3D12Device.CreateCommittedResource"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="ID3D12Device.CreatePlacedResource"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="ID3D12Device.CreateReservedResource"/>
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// </remarks>
    [Flags]
    public enum D3D12_RESOURCE_STATES : uint
    {
        /// <summary>
        /// <para>
        /// Your application should transition to this state only for accessing a resource across different graphics engine types.
        /// </para>
        /// <para>
        /// Specifically, a resource must be in the COMMON state before being used on a COPY queue
        /// (when previously used on DIRECT/COMPUTE), and before being used on DIRECT/COMPUTE (when previously used on COPY).
        /// This restriction doesn't exist when accessing data between DIRECT and COMPUTE queues.
        /// </para>
        /// <para>
        /// The COMMON state can be used for all usages on a Copy queue using the implicit state transitions.
        /// For more info, in Multi-engine synchronization, find "common".
        /// </para>
        /// <para>
        /// Additionally, textures must be in the COMMON state for CPU access to be legal,
        /// assuming the texture was created in a CPU-visible heap in the first place.
        /// </para>
        /// </summary>
        D3D12_RESOURCE_STATE_COMMON = 0,

        /// <summary>
        /// A subresource must be in this state when it is accessed by the GPU as a vertex buffer or constant buffer.
        /// This is a read-only state.
        /// </summary>
        D3D12_RESOURCE_STATE_VERTEX_AND_CONSTANT_BUFFER = 0x1,

        /// <summary>
        /// A subresource must be in this state when it is accessed by the 3D pipeline as an index buffer.
        /// This is a read-only state.
        /// </summary>
        D3D12_RESOURCE_STATE_INDEX_BUFFER = 0x2,

        /// <summary>
        /// <para>
        /// The resource is used as a render target.
        /// A subresource must be in this state when it is rendered to,
        /// or when it is cleared with <see cref="ID3D12GraphicsCommandList.ClearRenderTargetView"/>.
        /// </para>
        /// <para>
        /// This is a write-only state. To read from a render target as a shader resource,
        /// the resource must be in either <see cref="D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE"/>
        /// or <see cref="D3D12_RESOURCE_STATE_PIXEL_SHADER_RESOURCE"/>.
        /// </para>
        /// </summary>
        D3D12_RESOURCE_STATE_RENDER_TARGET = 0x4,

        /// <summary>
        /// The resource is used for unordered access.
        /// A subresource must be in this state when it is accessed by the GPU via an unordered access view.
        /// A subresource must also be in this state when it is cleared
        /// with <see cref="ID3D12GraphicsCommandList.ClearUnorderedAccessViewUint"/>
        /// or <see cref="ID3D12GraphicsCommandList.ClearUnorderedAccessViewFloat"/>.
        /// This is a read/write state.
        /// </summary>
        D3D12_RESOURCE_STATE_UNORDERED_ACCESS = 0x8,

        /// <summary>
        /// <see cref="D3D12_RESOURCE_STATE_DEPTH_WRITE"/> is a state that is mutually exclusive with other states.
        /// You should use it for <see cref="ID3D12GraphicsCommandList.ClearDepthStencilView"/>
        /// when the flags (see <see cref="D3D12_CLEAR_FLAGS"/>) indicate a given subresource should be cleared
        /// (otherwise the subresource state doesn't matter),
        /// or when using it in a writable depth stencil view (see <see cref="D3D12_DSV_FLAGS"/>)
        /// when the PSO has depth write enabled (see <see cref="D3D12_DEPTH_STENCIL_DESC"/>).
        /// </summary>
        D3D12_RESOURCE_STATE_DEPTH_WRITE = 0x10,

        /// <summary>
        /// <see cref="D3D12_RESOURCE_STATE_DEPTH_READ"/> is a state that can be combined with other states.
        /// It should be used when the subresource is in a read-only depth stencil view,
        /// or when depth write of <see cref="D3D12_DEPTH_STENCIL_DESC"/> is disabled.
        /// It can be combined with other read states (for example, <see cref="D3D12_RESOURCE_STATE_PIXEL_SHADER_RESOURCE"/>),
        /// such that the resource can be used for the depth or stencil test, and accessed by a shader within the same draw call.
        /// Using it when depth will be written by a draw call or clear command is invalid.
        /// </summary>
        D3D12_RESOURCE_STATE_DEPTH_READ = 0x20,

        /// <summary>
        /// The resource is used with a shader other than the pixel shader.
        /// A subresource must be in this state before being read by any stage
        /// (except for the pixel shader stage) via a shader resource view.
        /// You can still use the resource in a pixel shader with this flag
        /// as long as it also has the flag <see cref="D3D12_RESOURCE_STATE_PIXEL_SHADER_RESOURCE"/> set.
        /// This is a read-only state.
        /// </summary>
        D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE = 0x40,

        /// <summary>
        /// The resource is used with a pixel shader.
        /// A subresource must be in this state before being read by the pixel shader via a shader resource view.
        /// This is a read-only state.
        /// </summary>
        D3D12_RESOURCE_STATE_PIXEL_SHADER_RESOURCE = 0x80,

        /// <summary>
        /// The resource is used with stream output.
        /// A subresource must be in this state when it is accessed by the 3D pipeline as a stream-out target.
        /// This is a write-only state.
        /// </summary>
        D3D12_RESOURCE_STATE_STREAM_OUT = 0x100,

        /// <summary>
        /// <para>
        /// The resource is used as an indirect argument.
        /// </para>
        /// <para>
        /// Subresources must be in this state when they are used as the argument buffer
        /// passed to the indirect drawing method <see cref="ID3D12GraphicsCommandList.ExecuteIndirect"/>.
        /// </para>
        /// <para>
        /// This is a read-only state.
        /// </para>
        /// </summary>
        D3D12_RESOURCE_STATE_INDIRECT_ARGUMENT = 0x200,

        /// <summary>
        /// <para>
        /// The resource is used as the destination in a copy operation.
        /// </para>
        /// <para>
        /// Subresources must be in this state when they are used as the destination of copy operation, or a blt operation.
        /// </para>
        /// <para>
        /// This is a write-only state.
        /// </para>
        /// </summary>
        D3D12_RESOURCE_STATE_COPY_DEST = 0x400,

        /// <summary>
        /// <para>
        /// The resource is used as the source in a copy operation.
        /// </para>
        /// <para>
        /// Subresources must be in this state when they are used as the source of copy operation, or a blt operation.
        /// </para>
        /// <para>
        /// This is a read-only state.
        /// </para>
        /// </summary>
        D3D12_RESOURCE_STATE_COPY_SOURCE = 0x800,

        /// <summary>
        /// The resource is used as the destination in a resolve operation.
        /// </summary>
        D3D12_RESOURCE_STATE_RESOLVE_DEST = 0x1000,

        /// <summary>
        /// The resource is used as the source in a resolve operation.
        /// </summary>
        D3D12_RESOURCE_STATE_RESOLVE_SOURCE = 0x2000,

        /// <summary>
        /// <para>
        /// When a buffer is created with this as its initial state,
        /// it indicates that the resource is a raytracing acceleration structure,
        /// for use in <see cref="ID3D12GraphicsCommandList4.BuildRaytracingAccelerationStructure"/>,
        /// <see cref="ID3D12GraphicsCommandList4.CopyRaytracingAccelerationStructure"/>,
        /// or <see cref="ID3D12Device.CreateShaderResourceView"/>
        /// for the <see cref="D3D12_SRV_DIMENSION_RAYTRACING_ACCELERATION_STRUCTURE"/> dimension.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// A resource to be used for the <see cref="D3D12_RESOURCE_STATE_RAYTRACING_ACCELERATION_STRUCTURE"/> state
        /// must be created in that state, and then never transitioned out of it.
        /// Nor may a resource that was created not in that state be transitioned into it.
        /// For more info, see Acceleration structure memory restrictions
        /// in the DirectX raytracing (DXR) functional specification on GitHub.
        /// </para>
        /// </summary>
        D3D12_RESOURCE_STATE_RAYTRACING_ACCELERATION_STRUCTURE = 0x400000,

        /// <summary>
        /// Starting with Windows 10, version 1903 (10.0; Build 18362),
        /// indicates that the resource is a screen-space shading-rate image for variable-rate shading (VRS).
        /// For more info, see Variable-rate shading (VRS).
        /// </summary>
        D3D12_RESOURCE_STATE_SHADING_RATE_SOURCE = 0x1000000,

        /// <summary>
        /// 
        /// </summary>
        D3D12_RESOURCE_STATE_RESERVED_INTERNAL_8000 = 0x8000,

        /// <summary>
        /// 
        /// </summary>
        D3D12_RESOURCE_STATE_RESERVED_INTERNAL_4000 = 0x4000,

        /// <summary>
        /// 
        /// </summary>
        D3D12_RESOURCE_STATE_RESERVED_INTERNAL_100000 = 0x100000,

        /// <summary>
        /// 
        /// </summary>
        D3D12_RESOURCE_STATE_RESERVED_INTERNAL_40000000 = 0x40000000,

        /// <summary>
        /// 
        /// </summary>
        D3D12_RESOURCE_STATE_RESERVED_INTERNAL_80000000 = 0x80000000,

        /// <summary>
        /// <see cref="D3D12_RESOURCE_STATE_GENERIC_READ"/> is a logically OR'd combination of other read-state bits.
        /// This is the required starting state for an upload heap.
        /// Your application should generally avoid transitioning to <see cref="D3D12_RESOURCE_STATE_GENERIC_READ"/> when possible,
        /// since that can result in premature cache flushes, or resource layout changes (for example, compress/decompress),
        /// causing unnecessary pipeline stalls.
        /// You should instead transition resources only to the actually-used states.
        /// </summary>
        D3D12_RESOURCE_STATE_GENERIC_READ = (((((0x1 | 0x2) | 0x40) | 0x80) | 0x200) | 0x800),

        /// <summary>
        /// Equivalent to <c>D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE | D3D12_RESOURCE_STATE_PIXEL_SHADER_RESOURCE</c>.
        /// </summary>
        D3D12_RESOURCE_STATE_ALL_SHADER_RESOURCE = (0x40 | 0x80),

        /// <summary>
        /// Synonymous with <see cref="D3D12_RESOURCE_STATE_COMMON"/>.
        /// </summary>
        D3D12_RESOURCE_STATE_PRESENT = 0,

        /// <summary>
        /// The resource is used for Predication.
        /// </summary>
        D3D12_RESOURCE_STATE_PREDICATION = 0x200,

        /// <summary>
        /// The resource is used as a source in a decode operation.
        /// Examples include reading the compressed bitstream and reading from decode references.
        /// </summary>
        D3D12_RESOURCE_STATE_VIDEO_DECODE_READ = 0x10000,

        /// <summary>
        /// The resource is used as a destination in the decode operation.
        /// This state is used for decode output and histograms.
        /// </summary>
        D3D12_RESOURCE_STATE_VIDEO_DECODE_WRITE = 0x20000,

        /// <summary>
        /// The resource is used to read video data during video processing;
        /// that is, the resource is used as the source in a processing operation such as video encoding (compression).
        /// </summary>
        D3D12_RESOURCE_STATE_VIDEO_PROCESS_READ = 0x40000,

        /// <summary>
        /// The resource is used to write video data during video processing;
        /// that is, the resource is used as the destination in a processing operation such as video encoding (compression).
        /// </summary>
        D3D12_RESOURCE_STATE_VIDEO_PROCESS_WRITE = 0x80000,

        /// <summary>
        /// The resource is used as the source in an encode operation.
        /// This state is used for the input and reference of motion estimation.
        /// </summary>
        D3D12_RESOURCE_STATE_VIDEO_ENCODE_READ = 0x200000,

        /// <summary>
        /// This resource is used as the destination in an encode operation.
        /// This state is used for the destination texture of a resolve motion vector heap operation.
        /// </summary>
        D3D12_RESOURCE_STATE_VIDEO_ENCODE_WRITE = 0x800000
    }
}
