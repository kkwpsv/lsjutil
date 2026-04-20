using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the elements in a buffer to use in a unordered-access view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_buffer_uav"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use this structure with a <see cref="D3D12_UNORDERED_ACCESS_VIEW_DESC"/> structure to view the resource as a buffer.
    /// </para>
    /// <para>
    /// If <see cref="StructureByteStride"/> value is not 0, a view of a structured buffer is created
    /// and the <see cref="D3D12_UNORDERED_ACCESS_VIEW_DESC.Format"/> field must be <see cref="DXGI_FORMAT_UNKNOWN"/>.
    /// If <see cref="StructureByteStride"/> is 0, a typed view of a buffer is created and a format must be supplied.
    /// The specified format for the typed view must be supported by the hardware.
    /// More information on this topic can be found in the Typed unordered access view (UAV) loads page.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_BUFFER_UAV
    {
        /// <summary>
        /// The zero-based index of the first element to be accessed.
        /// </summary>
        public UINT64 FirstElement;

        /// <summary>
        /// The number of elements in the resource. For structured buffers, this is the number of structures in the buffer.
        /// </summary>
        public UINT NumElements;

        /// <summary>
        /// The size of each element in the buffer structure (in bytes) when the buffer represents a structured buffer.
        /// </summary>
        public UINT StructureByteStride;

        /// <summary>
        /// The counter offset, in bytes.
        /// </summary>
        public UINT64 CounterOffsetInBytes;

        /// <summary>
        /// A <see cref="D3D12_BUFFER_UAV_FLAGS"/>-typed value that specifies the view options for the resource.
        /// </summary>
        public D3D12_BUFFER_UAV_FLAGS Flags;
    }
}
