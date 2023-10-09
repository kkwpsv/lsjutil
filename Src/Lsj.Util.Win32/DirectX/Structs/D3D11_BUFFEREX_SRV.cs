using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the elements in a raw buffer resource to use in a shader-resource view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_bufferex_srv"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is used by <see cref="D3D11_SHADER_RESOURCE_VIEW_DESC"/> to create a raw view of a buffer.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_BUFFEREX_SRV
    {
        /// <summary>
        /// The index of the first element to be accessed by the view.
        /// </summary>
        public UINT FirstElement;

        /// <summary>
        /// The number of elements in the resource.
        /// </summary>
        public UINT NumElements;

        /// <summary>
        /// A <see cref="D3D11_BUFFEREX_SRV_FLAG"/>-typed value that identifies view options for the buffer.
        /// Currently, the only option is to identify a raw view of the buffer.
        /// For more info about raw viewing of buffers, see Raw Views of Buffers.
        /// </summary>
        public D3D11_BUFFEREX_SRV_FLAG Flags;
    }
}
