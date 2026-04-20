using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the shape of a tile by specifying its dimensions.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tile_shape"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is used by the <see cref="ID3D12Device.GetResourceTiling"/> method.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_TILE_SHAPE
    {
        /// <summary>
        /// The width in texels of the tile.
        /// </summary>
        public UINT WidthInTexels;

        /// <summary>
        /// The height in texels of the tile.
        /// </summary>
        public UINT HeightInTexels;

        /// <summary>
        /// The depth in texels of the tile.
        /// </summary>
        public UINT DepthInTexels;
    }
}
