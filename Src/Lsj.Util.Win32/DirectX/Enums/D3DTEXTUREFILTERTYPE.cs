using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines texture filtering modes for a texture stage.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dtexturefiltertype"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <see cref="D3DTEXTUREFILTERTYPE"/> is used by <see cref="IDirect3DDevice9.SetSamplerState"/> along
    /// with <see cref="D3DSAMPLERSTATETYPE"/> to define texture filtering modes for a texture stage.
    /// To check if a format supports texture filter types other than <see cref="D3DTEXF_POINT"/> (which is always supported),
    /// call <see cref="IDirect3D9.CheckDeviceFormat"/> with <see cref="D3DUSAGE_QUERY_FILTER"/>.
    /// Set a texture stage's magnification filter by calling <see cref="IDirect3DDevice9.SetSamplerState"/>
    /// with the <see cref="D3DSAMP_MAGFILTER"/> value as the second parameter and one member of this enumeration as the third parameter.
    /// Set a texture stage's minification filter by calling <see cref="IDirect3DDevice9.SetSamplerState"/>
    /// with the <see cref="D3DSAMP_MINFILTER"/> value as the second parameter and one member of this enumeration as the third parameter.
    /// Set the texture filter to use between-mipmap levels by calling <see cref="IDirect3DDevice9.SetSamplerState"/>
    /// with the <see cref="D3DSAMP_MIPFILTER"/> value as the second parameter and one member of this enumeration as the third parameter.
    /// Not all valid filtering modes for a device will apply to volume maps.
    /// In general, <see cref="D3DTEXF_POINT"/> and <see cref="D3DTEXF_LINEAR"/> magnification filters will be supported for volume maps.
    /// If <see cref="D3DPTEXTURECAPS_MIPVOLUMEMAP"/> is set, then the <see cref="D3DTEXF_POINT"/> mipmap filter
    /// and <see cref="D3DTEXF_POINT"/> and <see cref="D3DTEXF_LINEAR"/> minification filters will be supported for volume maps.
    /// The device may or may not support the <see cref="D3DTEXF_LINEAR"/> mipmap filter for volume maps.
    /// Devices that support anisotropic filtering for 2D maps do not necessarily support anisotropic filtering for volume maps.
    /// However, applications that enable anisotropic filtering will receive the best available filtering (probably linear) if anisotropic filtering is not supported.
    /// </remarks>
    public enum D3DTEXTUREFILTERTYPE
    {
        /// <summary>
        /// When used with <see cref="D3DSAMP_MIPFILTER"/>, disables mipmapping.
        /// </summary>
        D3DTEXF_NONE = 0,

        /// <summary>
        /// When used with <see cref="D3DSAMP_MAGFILTER"/> or <see cref="D3DSAMP_MINFILTER"/>, specifies that point filtering
        /// is to be used as the texture magnification or minification filter respectively.
        /// When used with <see cref="D3DSAMP_MIPFILTER"/>, enables mipmapping and specifies that the rasterizer
        /// chooses the color from the texel of the nearest mip level.
        /// </summary>
        D3DTEXF_POINT = 1,

        /// <summary>
        /// When used with <see cref="D3DSAMP_MAGFILTER"/> or <see cref="D3DSAMP_MINFILTER"/>, specifies that linear filtering
        /// is to be used as the texture magnification or minification filter respectively.
        /// When used with <see cref="D3DSAMP_MIPFILTER"/>, enables mipmapping and trilinear filtering;
        /// it specifies that the rasterizer interpolates between the two nearest mip levels.
        /// </summary>
        D3DTEXF_LINEAR = 2,

        /// <summary>
        /// When used with <see cref="D3DSAMP_MAGFILTER"/> or <see cref="D3DSAMP_MINFILTER"/>,
        /// specifies that anisotropic texture filtering used as a texture magnification or minification filter respectively.
        /// Compensates for distortion caused by the difference in angle between the texture polygon and the plane of the screen.
        /// Use with <see cref="D3DSAMP_MIPFILTER"/> is undefined.
        /// </summary>
        D3DTEXF_ANISOTROPIC = 3,

        /// <summary>
        /// A 4-sample tent filter used as a texture magnification or minification filter.
        /// Use with <see cref="D3DSAMP_MIPFILTER"/> is undefined.
        /// </summary>
        D3DTEXF_PYRAMIDALQUAD = 6,

        /// <summary>
        /// A 4-sample Gaussian filter used as a texture magnification or minification filter.
        /// Use with <see cref="D3DSAMP_MIPFILTER"/> is undefined.
        /// </summary>
        D3DTEXF_GAUSSIANQUAD = 7,

        /// <summary>
        /// Convolution filter for monochrome textures. See <see cref="D3DFMT_A1"/>.
        /// Differences between Direct3D 9 and Direct3D 9Ex:
        /// This flag is available in Direct3D 9Ex only.
        /// Use with <see cref="D3DSAMP_MIPFILTER"/> is undefined.
        /// </summary>
        D3DTEXF_CONVOLUTIONMONO = 8,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// This value is not used.
        /// </summary>
        D3DTEXF_FORCE_DWORD = 0x7fffffff
    }
}
