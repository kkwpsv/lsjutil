using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Constants;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the format, width, height, depth, and row-pitch of the subresource into the parent resource.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_subresource_footprint"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use this structure in the <see cref="D3D12_PLACED_SUBRESOURCE_FOOTPRINT"/> structure.
    /// </para>
    /// <para>
    /// The helper structure is <c>CD3DX12_SUBRESOURCE_FOOTPRINT</c>.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_SUBRESOURCE_FOOTPRINT
    {
        /// <summary>
        /// A <see cref="DXGI_FORMAT"/>-typed value that specifies the viewing format.
        /// </summary>
        public DXGI_FORMAT Format;

        /// <summary>
        /// The width of the subresource.
        /// </summary>
        public UINT Width;

        /// <summary>
        /// The height of the subresource.
        /// </summary>
        public UINT Height;

        /// <summary>
        /// The depth of the subresource.
        /// </summary>
        public UINT Depth;

        /// <summary>
        /// The row pitch, or width, or physical size, in bytes, of the subresource data.
        /// This must be a multiple of <see cref="D3D12_TEXTURE_DATA_PITCH_ALIGNMENT"/> (256),
        /// and must be greater than or equal to the size of the data within a row.
        /// </summary>
        public UINT RowPitch;
    }
}
