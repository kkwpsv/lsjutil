using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the elements in a buffer to use in a unordered-access view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_buffer_uav"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is used by a <see cref="D3D11_UNORDERED_ACCESS_VIEW_DESC"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_BUFFER_UAV
    {
        /// <summary>
        /// The zero-based index of the first element to be accessed.
        /// </summary>
        public UINT FirstElement;

        /// <summary>
        /// The number of elements in the resource.
        /// For structured buffers, this is the number of structures in the buffer.
        /// </summary>
        public UINT ElementOffset;

        /// <summary>
        /// View options for the resource (see <see cref="D3D11_BUFFER_UAV_FLAG"/>).
        /// </summary>
        public D3D11_BUFFER_UAV_FLAG Flags;
    }
}
