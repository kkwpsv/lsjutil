using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// These flags identify the type of resource that will be viewed as a shader resource.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ff476217(v=vs.85)"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// These flags are used by a shader-resource-view description (see <see cref="D3D11_SHADER_RESOURCE_VIEW_DESC"/>).
    /// </para>
    /// <para>
    /// The <see cref="D3D11_SRV_DIMENSION"/> enumeration is type defined in the D3D11.h header file as a <see cref="D3D_SRV_DIMENSION"/> enumeration,
    /// which is fully defined in the D3DCommon.h header file.
    /// </para>
    /// </remarks>
    public enum D3D11_SRV_DIMENSION
    {
        /// <summary>
        /// The type is unknown.
        /// </summary>
        D3D11_SRV_DIMENSION_UNKNOWN = 0,

        /// <summary>
        /// The resource is a buffer.
        /// </summary>
        D3D11_SRV_DIMENSION_BUFFER = 1,

        /// <summary>
        /// The resource is a 1D texture.
        /// </summary>
        D3D11_SRV_DIMENSION_TEXTURE1D = 2,

        /// <summary>
        /// The resource is an array of 1D textures.
        /// </summary>
        D3D11_SRV_DIMENSION_TEXTURE1DARRAY = 3,

        /// <summary>
        /// The resource is a 2D texture.
        /// </summary>
        D3D11_SRV_DIMENSION_TEXTURE2D = 4,

        /// <summary>
        /// The resource is an array of 2D textures.
        /// </summary>
        D3D11_SRV_DIMENSION_TEXTURE2DARRAY = 5,

        /// <summary>
        /// The resource is a multisampling 2D texture.
        /// </summary>
        D3D11_SRV_DIMENSION_TEXTURE2DMS = 6,

        /// <summary>
        /// The resource is an array of multisampling 2D textures.
        /// </summary>
        D3D11_SRV_DIMENSION_TEXTURE2DMSARRAY = 7,

        /// <summary>
        /// The resource is a 3D texture.
        /// </summary>
        D3D11_SRV_DIMENSION_TEXTURE3D = 8,

        /// <summary>
        /// The resource is a cube texture.
        /// </summary>
        D3D11_SRV_DIMENSION_TEXTURECUBE = 9,

        /// <summary>
        /// The resource is an array of cube textures.
        /// </summary>
        D3D11_SRV_DIMENSION_TEXTURECUBEARRAY = 10,

        /// <summary>
        /// The resource is a raw buffer.
        /// For more info about raw viewing of buffers, see Raw Views of Buffers.
        /// </summary>
        D3D11_SRV_DIMENSION_BUFFEREX = 11,
    }
}
