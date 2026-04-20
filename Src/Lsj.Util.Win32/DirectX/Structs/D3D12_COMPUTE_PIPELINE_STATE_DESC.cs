using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a compute pipeline state object.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_compute_pipeline_state_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is used by <see cref="ID3D12Device.CreateComputePipelineState"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_COMPUTE_PIPELINE_STATE_DESC
    {
        /// <summary>
        /// A pointer to the <see cref="ID3D12RootSignature"/> object.
        /// </summary>
        public P<ID3D12RootSignature> pRootSignature;

        /// <summary>
        /// A <see cref="D3D12_SHADER_BYTECODE"/> structure that describes the compute shader.
        /// </summary>
        public D3D12_SHADER_BYTECODE CS;

        /// <summary>
        /// For single GPU operation, set this to zero.
        /// If there are multiple GPU nodes, set bits to identify the nodes (the device's physical adapters)
        /// for which the compute pipeline state is to apply.
        /// Each bit in the mask corresponds to a single node.
        /// Refer to Multi-adapter systems.
        /// </summary>
        public UINT NodeMask;

        /// <summary>
        /// A cached pipeline state object, as a <see cref="D3D12_CACHED_PIPELINE_STATE"/> structure.
        /// <see cref="D3D12_CACHED_PIPELINE_STATE.pCachedBlob"/> and <see cref="D3D12_CACHED_PIPELINE_STATE.CachedBlobSizeInBytes"/>
        /// may be set to <see cref="NULL"/> and 0 respectively.
        /// </summary>
        public D3D12_CACHED_PIPELINE_STATE CachedPSO;

        /// <summary>
        /// A D3D12_PIPELINE_STATE_FLAGS enumeration constant such as for "tool debug".
        /// </summary>
        public D3D12_PIPELINE_STATE_FLAGS Flags;
    }
}
