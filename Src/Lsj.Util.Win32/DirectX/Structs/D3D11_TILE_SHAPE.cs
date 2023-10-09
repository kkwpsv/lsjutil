using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the shape of a tile by specifying its dimensions.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11_2/ns-d3d11_2-d3d11_tile_shape"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Texels are equivalent to pixels.
    /// For untyped buffer resources, a texel is just a byte.
    /// For multisample antialiasing (MSAA) surfaces, the numbers are still in terms of pixels/texels.
    /// The values here are independent of the surface dimensions.
    /// Even if the surface is smaller than what would fit in a tile, the full tile dimensions are reported here.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_TILE_SHAPE
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
