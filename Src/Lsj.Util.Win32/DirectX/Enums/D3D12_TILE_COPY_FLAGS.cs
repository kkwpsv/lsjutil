using Lsj.Util.Win32.DirectX.ComInterfaces;
using System;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies how to copy a tile.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_tile_copy_flags"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by the <see cref="ID3D12GraphicsCommandList.CopyTiles"/> method.
    /// </remarks>
    [Flags]
    public enum D3D12_TILE_COPY_FLAGS
    {
        /// <summary>
        /// No tile-copy flags are specified.
        /// </summary>
        D3D12_TILE_COPY_FLAG_NONE = 0,

        /// <summary>
        /// Indicates that the GPU isn't currently referencing any of the portions of destination memory being written.
        /// </summary>
        D3D12_TILE_COPY_FLAG_NO_HAZARD = 0x1,

        /// <summary>
        /// <para>
        /// Indicates that the <see cref="ID3D12GraphicsCommandList.CopyTiles"/> operation
        /// involves copying a linear buffer to a swizzled tiled resource.
        /// This means to copy tile data from the specified buffer location, reading tiles sequentially,
        /// to the specified tile region (in x,y,z order if the region is a box), swizzling to optimal hardware memory layout as needed.
        /// </para>
        /// <para>
        /// In this <see cref="ID3D12GraphicsCommandList.CopyTiles"/> call,
        /// you specify the source data with the <c>pBuffer</c> parameter and the destination with the <c>pTiledResource</c> parameter.
        /// </para>
        /// </summary>
        D3D12_TILE_COPY_FLAG_LINEAR_BUFFER_TO_SWIZZLED_TILED_RESOURCE = 0x2,

        /// <summary>
        /// <para>
        /// Indicates that the <see cref="ID3D12GraphicsCommandList.CopyTiles"/> operation
        /// involves copying a swizzled tiled resource to a linear buffer.
        /// This means to copy tile data from the tile region, reading tiles sequentially (in x,y,z order if the region is a box),
        /// to the specified buffer location, deswizzling to linear memory layout as needed.
        /// </para>
        /// <para>
        /// In this <see cref="ID3D12GraphicsCommandList.CopyTiles"/> call,
        /// you specify the source data with the <c>pTiledResource</c> parameter and the destination with the <c>pBuffer</c> parameter.
        /// </para>
        /// </summary>
        D3D12_TILE_COPY_FLAG_SWIZZLED_TILED_RESOURCE_TO_LINEAR_BUFFER = 0x4
    }
}
