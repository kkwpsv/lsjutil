using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a pipeline state stream.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_pipeline_state_stream_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use this structure with the <see cref="ID3D12Device2.CreatePipelineState"/> method to create pipeline state objects.
    /// </para>
    /// <para>
    /// The format of the provided stream should consist of an alternating set of <see cref="D3D12_PIPELINE_STATE_SUBOBJECT_TYPE"/>,
    /// and the corresponding subobject types for them (for example,
    /// <see cref="D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_RASTERIZER"/> pairs with <see cref="D3D12_RASTERIZER_DESC"/>.
    /// In terms of alignment, the D3D12 runtime expects subobjects to be individual struct pairs of enum-struct,
    /// rather than a continuous set of fields.
    /// It also expects them to be aligned to the natural word alignment of the system.
    /// This can be achieved either using <c>alignas(void*)</c>, or making a <c>union</c> of the enum + subobject and a <c>void*</c>.
    /// </para>
    /// <para>
    /// Important
    /// </para>
    /// <para>
    /// It isn't sufficient to simply union the <see cref="D3D12_PIPELINE_STATE_SUBOBJECT_TYPE"/> with a <c>void*</c>,
    /// because this will result in certain subobjects being misaligned.
    /// For example, <see cref="D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_PRIMITIVE_TOPOLOGY"/>
    /// is followed by a <see cref="D3D12_PRIMITIVE_TOPOLOGY_TYPE"/> enum.
    /// If the subobject type is unioned with a <c>void*</c>,
    /// then there will be additional padding between these 2 members, resulting in corruption of the stream.
    /// Because of this, you should union the entire subobject struct with a <c>void*</c>, when <c>alignas</c> is not available
    /// </para>
    /// <para>
    /// An example of a suitable subobject for use with <see cref="D3D12_RASTERIZER_DESC"/> is shown here:
    /// </para>
    /// <code>
    /// struct alignas(void*) StreamingRasterizerDesc
    /// {
    /// private:
    ///   D3D12_PIPELINE_STATE_SUBOBJECT_TYPE Type = D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_RASTERIZER;
    /// public:
    ///   D3D12_RASTERIZER_DESC Desc;
    /// }
    /// </code>
    /// <para>
    /// The runtime will determine the type of a pipeline stream
    /// (valid types being <c>COMPUTE</c>, <c>GRAPHICS</c>, and <c>MESH</c>), by which subobject type,
    /// out of <c>VS</c> (vertex shader), <c>CS</c> (compute shader), and <c>MS</c> (mesh shader), is found.
    /// If the runtime finds none of these shaders, it will fail pipeline creation.
    /// If it finds multiple of these shaders which are not null, it will also fail.
    /// This means it is legal to have both, for example, a <c>CS</c> and <c>VS</c> in your stream object,
    /// provided only one has a non-null pointer for the shader bytecode
    /// for any given call to <see cref="ID3D12Device2.CreatePipelineState"/>.
    /// Subobject types irrelevant to the pipeline (e.g a compute shader subobject in a graphics stream) will be ignored.
    /// If a subobject is not provided (excluding the above required subobjects),
    /// the runtime will provide a default value for it.
    /// </para>
    /// <para>
    /// Consider using the <c>d3dx12.h</c> extensions for C++,
    /// which provide a set of helper structs for all pipeline subobjects
    /// (for example, the above struct is very similar to <c>CD3DX12_PIPELINE_STATE_STREAM_RASTERIZER</c>).
    /// This header can be found under the DirectX-Headers repo on github.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_PIPELINE_STATE_STREAM_DESC
    {
        /// <summary>
        /// Specifies the size of the opaque data structure pointed to by the <see cref="pPipelineStateSubobjectStream"/> member, in bytes.
        /// </summary>
        public SIZE_T SizeInBytes;

        /// <summary>
        /// Specifies the address of a data structure that describes as a bytestream an arbitrary pipeline state subobject.
        /// </summary>
        public IntPtr pPipelineStateSubobjectStream;
    }
}
