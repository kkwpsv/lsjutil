using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the coordinates of a tiled resource.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tiled_resource_coordinate"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is used by the <see cref="ID3D12GraphicsCommandList.CopyTiles"/>,
    /// <see cref="ID3D12CommandQueue.CopyTileMappings"/> and <see cref="ID3D12CommandQueue.UpdateTileMappings"/> methods.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_TILED_RESOURCE_COORDINATE
    {
        /// <summary>
        /// The x-coordinate of the tiled resource.
        /// </summary>
        public UINT X;

        /// <summary>
        /// The y-coordinate of the tiled resource.
        /// </summary>
        public UINT Y;

        /// <summary>
        /// The z-coordinate of the tiled resource.
        /// </summary>
        public UINT Z;

        /// <summary>
        /// <para>
        /// The index of the subresource for the tiled resource.
        /// </para>
        /// <para>
        /// For mipmaps that use nonstandard tiling, or are packed, or both use nonstandard tiling and are packed,
        /// any subresource value that indicates any of the packed mipmaps all refer to the same tile.
        /// Additionally, the X coordinate is used to indicate a tile within the packed mip region,
        /// rather than a logical region of a single subresource.
        /// The Y and Z coordinates must be zero.
        /// </para>
        /// </summary>
        public UINT Subresource;
    }
}
