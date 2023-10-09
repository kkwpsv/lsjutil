using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// These flags identify the type of resource that will be viewed as a render target.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_rtv_dimension"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enumeration is used in <see cref="D3D11_RENDER_TARGET_VIEW_DESC"/> to create a render-target view.
    /// </remarks>
    public enum D3D11_RTV_DIMENSION
    {
        /// <summary>
        /// Do not use this value, as it will cause <see cref="ID3D11Device.CreateRenderTargetView"/> to fail.
        /// </summary>
        D3D11_RTV_DIMENSION_UNKNOWN = 0,

        /// <summary>
        /// The resource will be accessed as a buffer.
        /// </summary>
        D3D11_RTV_DIMENSION_BUFFER = 1,

        /// <summary>
        /// The resource will be accessed as a 1D texture.
        /// </summary>
        D3D11_RTV_DIMENSION_TEXTURE1D = 2,

        /// <summary>
        /// The resource will be accessed as an array of 1D textures.
        /// </summary>
        D3D11_RTV_DIMENSION_TEXTURE1DARRAY = 3,

        /// <summary>
        /// The resource will be accessed as a 2D texture.
        /// </summary>
        D3D11_RTV_DIMENSION_TEXTURE2D = 4,

        /// <summary>
        /// The resource will be accessed as an array of 2D textures.
        /// </summary>
        D3D11_RTV_DIMENSION_TEXTURE2DARRAY = 5,

        /// <summary>
        /// The resource will be accessed as a 2D texture with multisampling.
        /// </summary>
        D3D11_RTV_DIMENSION_TEXTURE2DMS = 6,

        /// <summary>
        /// The resource will be accessed as an array of 2D textures with multisampling.
        /// </summary>
        D3D11_RTV_DIMENSION_TEXTURE2DMSARRAY = 7,

        /// <summary>
        /// The resource will be accessed as a 3D texture.
        /// </summary>
        D3D11_RTV_DIMENSION_TEXTURE3D = 8,
    }
}
