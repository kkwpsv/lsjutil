using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the elements in a buffer resource to use in a shader-resource view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_buffer_srv"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This structure is used by <see cref="D3D12_SHADER_RESOURCE_VIEW_DESC"/> to create a view of a buffer.
    /// </para>
    /// <para>
    /// If the value of <see cref="StructureByteStride"/> is not 0, then a view of a structured buffer is created,
    /// and then the <see cref="D3D12_SHADER_RESOURCE_VIEW_DESC.Format"/> field must be <see cref="DXGI_FORMAT_UNKNOWN"/>.
    /// If <see cref="StructureByteStride"/> is 0, then a typed view of a buffer is created, and then a format must be supplied.
    /// The specified format for the typed view must be supported by the hardware.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_BUFFER_SRV
    {
        /// <summary>
        /// The index of the first element to be accessed by the view.
        /// </summary>
        public UINT64 FirstElement;

        /// <summary>
        /// The number of elements in the resource.
        /// </summary>
        public UINT NumElements;

        /// <summary>
        /// The size of each element in the buffer structure (in bytes) when the buffer represents a structured buffer.
        /// The size must match the struct size declared in shaders that access the view.
        /// </summary>
        public UINT StructureByteStride;

        /// <summary>
        /// A <see cref="D3D12_BUFFER_SRV_FLAGS"/>-typed value that identifies view options for the buffer.
        /// Currently, the only option is to identify a raw view of the buffer.
        /// For more info about raw viewing of buffers, see Raw Views of Buffers.
        /// </summary>
        public D3D12_BUFFER_SRV_FLAGS Flags;
    }
}
