using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a vertex buffer view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_vertex_buffer_view"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Use this structure with the <see cref="ID3D12GraphicsCommandList.IASetVertexBuffers"/> method.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_VERTEX_BUFFER_VIEW
    {
        /// <summary>
        /// Specifies a <see cref="D3D12_GPU_VIRTUAL_ADDRESS"/> that identifies the address of the buffer.
        /// </summary>
        public D3D12_GPU_VIRTUAL_ADDRESS BufferLocation;

        /// <summary>
        /// Specifies the size in bytes of the buffer.
        /// </summary>
        public UINT SizeInBytes;

        /// <summary>
        /// Specifies the size in bytes of each vertex entry.
        /// </summary>
        public UINT StrideInBytes;
    }
}
