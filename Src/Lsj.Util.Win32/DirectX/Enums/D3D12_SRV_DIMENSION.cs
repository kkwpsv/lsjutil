using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Identifies the type of resource that will be viewed as a shader resource.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_srv_dimension"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// These values are used by a shader-resource-view description, <see cref="D3D12_SHADER_RESOURCE_VIEW_DESC"/>.
    /// </remarks>
    public enum D3D12_SRV_DIMENSION
    {
        /// <summary>
        /// The type is unknown.
        /// </summary>
        D3D12_SRV_DIMENSION_UNKNOWN = 0,

        /// <summary>
        /// The resource is a buffer.
        /// </summary>
        D3D12_SRV_DIMENSION_BUFFER = 1,

        /// <summary>
        /// The resource is a 1D texture.
        /// </summary>
        D3D12_SRV_DIMENSION_TEXTURE1D = 2,

        /// <summary>
        /// The resource is an array of 1D textures.
        /// </summary>
        D3D12_SRV_DIMENSION_TEXTURE1DARRAY = 3,

        /// <summary>
        /// The resource is a 2D texture.
        /// </summary>
        D3D12_SRV_DIMENSION_TEXTURE2D = 4,

        /// <summary>
        /// The resource is an array of 2D textures.
        /// </summary>
        D3D12_SRV_DIMENSION_TEXTURE2DARRAY = 5,

        /// <summary>
        /// The resource is a multisampling 2D texture.
        /// </summary>
        D3D12_SRV_DIMENSION_TEXTURE2DMS = 6,

        /// <summary>
        /// The resource is an array of multisampling 2D textures.
        /// </summary>
        D3D12_SRV_DIMENSION_TEXTURE2DMSARRAY = 7,

        /// <summary>
        /// The resource is a 3D texture.
        /// </summary>
        D3D12_SRV_DIMENSION_TEXTURE3D = 8,

        /// <summary>
        /// The resource is a cube texture.
        /// </summary>
        D3D12_SRV_DIMENSION_TEXTURECUBE = 9,

        /// <summary>
        /// The resource is an array of cube textures.
        /// </summary>
        D3D12_SRV_DIMENSION_TEXTURECUBEARRAY = 10,

        /// <summary>
        /// The resource is a raytracing acceleration structure.
        /// </summary>
        D3D12_SRV_DIMENSION_RAYTRACING_ACCELERATION_STRUCTURE = 11
    }
}
