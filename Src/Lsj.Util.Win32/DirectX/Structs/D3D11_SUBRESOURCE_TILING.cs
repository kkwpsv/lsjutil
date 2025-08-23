using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a tiled subresource volume.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11_2/ns-d3d11_2-d3d11_subresource_tiling"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Each packed mipmap is individually reported as 0 for <see cref="WidthInTiles"/>,
    /// <see cref="HeightInTiles"/> and <see cref="DepthInTiles"/>.
    /// </para>
    /// <para>
    /// The total number of tiles in subresources is <see cref="WidthInTiles"/>*<see cref="HeightInTiles"/>*<see cref="DepthInTiles"/>.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_SUBRESOURCE_TILING
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
        /// <see cref="ID3D11Device2.GetResourceTiling"/> sets <see cref="StartTileIndexInOverallResource"/> to <see cref="D3D11_PACKED_TILE"/> (0xffffffff)
        /// to indicate that the whole <see cref="D3D11_SUBRESOURCE_TILING"/> structure is meaningless,
        /// and the info to which the pPackedMipDesc parameter of <see cref="ID3D11Device2.GetResourceTiling"/> points applies.
        /// For packed tiles, the description of the packed mipmaps comes from a <see cref="D3D11_PACKED_MIP_DESC"/> structure instead.
        /// </summary>
        public UINT StartTileIndexInOverallResource;
    }
}
