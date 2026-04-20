using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a tiled subresource volume.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_subresource_tiling"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is used by the <see cref="ID3D12Device.GetResourceTiling"/> method.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_SUBRESOURCE_TILING
    {
        /// <summary>
        /// The width in tiles of the subresource.
        /// </summary>
        public UINT WidthInTiles;

        /// <summary>
        /// The height in tiles of the subresource.
        /// </summary>
        public UINT16 HeightInTiles;

        /// <summary>
        /// The depth in tiles of the subresource.
        /// </summary>
        public UINT16 DepthInTiles;

        /// <summary>
        /// The index of the tile in the overall tiled subresource to start with.
        /// </summary>
        public UINT StartTileIndexInOverallResource;
    }
}
