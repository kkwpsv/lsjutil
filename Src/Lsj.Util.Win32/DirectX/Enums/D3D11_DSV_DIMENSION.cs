using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies how to access a resource used in a depth-stencil view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_dsv_dimension"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enumeration is used in <see cref="D3D11_DEPTH_STENCIL_VIEW_DESC"/> to create a depth-stencil view.
    /// </remarks>
    public enum D3D11_DSV_DIMENSION
    {
        /// <summary>
        /// <see cref="D3D11_DSV_DIMENSION_UNKNOWN"/> is not a valid value for <see cref="D3D11_DEPTH_STENCIL_VIEW_DESC"/> and is not used.
        /// </summary>
        D3D11_DSV_DIMENSION_UNKNOWN = 0,

        /// <summary>
        /// The resource will be accessed as a 1D texture.
        /// </summary>
        D3D11_DSV_DIMENSION_TEXTURE1D = 1,

        /// <summary>
        /// The resource will be accessed as an array of 1D textures.
        /// </summary>
        D3D11_DSV_DIMENSION_TEXTURE1DARRAY = 2,

        /// <summary>
        /// The resource will be accessed as a 2D texture.
        /// </summary>
        D3D11_DSV_DIMENSION_TEXTURE2D = 3,

        /// <summary>
        /// The resource will be accessed as an array of 2D textures.
        /// </summary>
        D3D11_DSV_DIMENSION_TEXTURE2DARRAY = 4,

        /// <summary>
        /// The resource will be accessed as a 2D texture with multisampling.
        /// </summary>
        D3D11_DSV_DIMENSION_TEXTURE2DMS = 5,

        /// <summary>
        /// The resource will be accessed as an array of 2D textures with multisampling.
        /// </summary>
        D3D11_DSV_DIMENSION_TEXTURE2DMSARRAY = 6,
    }
}
