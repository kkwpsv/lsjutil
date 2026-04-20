using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Identifies the type of resource to view as a render target.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_rtv_dimension"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Specify one of the values in this enumeration in the <see cref="D3D12_RENDER_TARGET_VIEW_DESC.ViewDimension"/> member
    /// of a <see cref="D3D12_RENDER_TARGET_VIEW_DESC"/> structure.
    /// </remarks>
    public enum D3D12_RTV_DIMENSION
    {
        /// <summary>
        /// Do not use this value, as it will cause <see cref="ID3D12Device.CreateRenderTargetView"/> to fail.
        /// </summary>
        D3D12_RTV_DIMENSION_UNKNOWN = 0,

        /// <summary>
        /// The resource will be accessed as a buffer.
        /// </summary>
        D3D12_RTV_DIMENSION_BUFFER = 1,

        /// <summary>
        /// The resource will be accessed as a 1D texture.
        /// </summary>
        D3D12_RTV_DIMENSION_TEXTURE1D = 2,

        /// <summary>
        /// The resource will be accessed as an array of 1D textures.
        /// </summary>
        D3D12_RTV_DIMENSION_TEXTURE1DARRAY = 3,

        /// <summary>
        /// The resource will be accessed as a 2D texture.
        /// </summary>
        D3D12_RTV_DIMENSION_TEXTURE2D = 4,

        /// <summary>
        /// The resource will be accessed as an array of 2D textures.
        /// </summary>
        D3D12_RTV_DIMENSION_TEXTURE2DARRAY = 5,

        /// <summary>
        /// The resource will be accessed as a 2D texture with multisampling.
        /// </summary>
        D3D12_RTV_DIMENSION_TEXTURE2DMS = 6,

        /// <summary>
        /// The resource will be accessed as an array of 2D textures with multisampling.
        /// </summary>
        D3D12_RTV_DIMENSION_TEXTURE2DMSARRAY = 7,

        /// <summary>
        /// The resource will be accessed as a 3D texture.
        /// </summary>
        D3D12_RTV_DIMENSION_TEXTURE3D = 8
    }
}
