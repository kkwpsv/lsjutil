using Lsj.Util.Win32.DirectX.Structs;
using System;
using static Lsj.Util.Win32.DirectX.Enums.D3DTEXTUREFILTERTYPE;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Texture filtering constants.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dptfiltercaps"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// These constants are used by <see cref="D3DCAPS9.TextureFilterCaps"/>, <see cref="D3DCAPS9.CubeTextureFilterCaps"/>,
    /// <see cref="D3DCAPS9.VolumeTextureFilterCaps"/>, and <see cref="D3DCAPS9.VertexTextureFilterCaps"/> members of <see cref="D3DCAPS9"/>.
    /// </remarks>
    [Flags]
    public enum D3DPTFILTERCAPS : uint
    {
        /// <summary>
        /// <para>
        /// Device supports monochrome convolution filtering.
        /// This filter is represented by the <see cref="D3DTEXF_CONVOLUTIONMONO"/> member of the <see cref="D3DTEXTUREFILTERTYPE"/> enumerated type.
        /// </para>
        /// <para>
        /// Differences between Direct3D 9 and Direct3D 9Ex:
        /// </para>
        /// <para>
        /// This flag is available in Direct3D 9Ex only.
        /// </para>
        /// </summary>
        D3DPTFILTERCAPS_CONVOLUTIONMONO = 0x00040000,

        /// <summary>
        /// Device supports per-stage point-sample filtering for magnifying textures.
        /// The point-sample magnification filter is represented by the <see cref="D3DTEXF_POINT"/> member of the <see cref="D3DTEXTUREFILTERTYPE"/> enumerated type.
        /// </summary>
        D3DPTFILTERCAPS_MAGFPOINT = 0x01000000,

        /// <summary>
        /// Device supports per-stage bilinear interpolation filtering for magnifying mipmaps.
        /// The bilinear interpolation mipmapping filter is represented by the <see cref="D3DTEXF_LINEAR"/> member of the <see cref="D3DTEXTUREFILTERTYPE"/> enumerated type.
        /// </summary>
        D3DPTFILTERCAPS_MAGFLINEAR = 0x02000000,

        /// <summary>
        /// Device supports per-stage anisotropic filtering for magnifying textures.
        /// The anisotropic magnification filter is represented by the <see cref="D3DTEXF_ANISOTROPIC"/> member of the <see cref="D3DTEXTUREFILTERTYPE"/> enumerated type.
        /// </summary>
        D3DPTFILTERCAPS_MAGFANISOTROPIC = 0x04000000,

        /// <summary>
        /// Device supports per-stage pyramidal sample filtering for magnifying textures.
        /// The pyramidal magnifying filter is represented by the <see cref="D3DTEXF_PYRAMIDALQUAD"/> member of the <see cref="D3DTEXTUREFILTERTYPE"/> enumerated type.
        /// </summary>
        D3DPTFILTERCAPS_MAGFPYRAMIDALQUAD = 0x08000000,

        /// <summary>
        /// Device supports per-stage Gaussian quad filtering for magnifying textures.
        /// </summary>
        D3DPTFILTERCAPS_MAGFGAUSSIANQUAD = 0x10000000,

        /// <summary>
        /// Device supports per-stage point-sample filtering for minifying textures.
        /// The point-sample minification filter is represented by the <see cref="D3DTEXF_POINT"/> member of the <see cref="D3DTEXTUREFILTERTYPE"/> enumerated type.
        /// </summary>
        D3DPTFILTERCAPS_MINFPOINT = 0x00000100,

        /// <summary>
        /// Device supports per-stage linear filtering for minifying textures.
        /// The linear minification filter is represented by the <see cref="D3DTEXF_LINEAR"/> member of the <see cref="D3DTEXTUREFILTERTYPE"/> enumerated type.
        /// </summary>
        D3DPTFILTERCAPS_MINFLINEAR = 0x00000200,

        /// <summary>
        /// Device supports per-stage anisotropic filtering for minifying textures.
        /// The anisotropic minification filter is represented by the <see cref="D3DTEXF_ANISOTROPIC"/> member of the <see cref="D3DTEXTUREFILTERTYPE"/> enumerated type.
        /// </summary>
        D3DPTFILTERCAPS_MINFANISOTROPIC = 0x00000400,

        /// <summary>
        /// Device supports per-stage pyramidal sample filtering for minifying textures.
        /// </summary>
        D3DPTFILTERCAPS_MINFPYRAMIDALQUAD = 0x00000800,

        /// <summary>
        /// Device supports per-stage Gaussian quad filtering for minifying textures.
        /// </summary>
        D3DPTFILTERCAPS_MINFGAUSSIANQUAD = 0x00001000,

        /// <summary>
        /// Device supports per-stage point-sample filtering for mipmaps.
        /// The point-sample mipmapping filter is represented by the <see cref="D3DTEXF_POINT"/> member of the <see cref="D3DTEXTUREFILTERTYPE"/> enumerated type.
        /// </summary>
        D3DPTFILTERCAPS_MIPFPOINT = 0x00010000,

        /// <summary>
        /// Device supports per-stage bilinear interpolation filtering for mipmaps.
        /// The bilinear interpolation mipmapping filter is represented by the <see cref="D3DTEXF_LINEAR"/> member of the <see cref="D3DTEXTUREFILTERTYPE"/> enumerated type.
        /// </summary>
        D3DPTFILTERCAPS_MIPFLINEAR = 0x00020000,

        /// <summary>
        /// D3DPTFILTERCAPS_NEAREST
        /// </summary>
        D3DPTFILTERCAPS_NEAREST = 0x00000001,

        /// <summary>
        /// D3DPTFILTERCAPS_LINEAR
        /// </summary>
        D3DPTFILTERCAPS_LINEAR = 0x00000002,

        /// <summary>
        /// D3DPTFILTERCAPS_MIPNEAREST
        /// </summary>
        D3DPTFILTERCAPS_MIPNEAREST = 0x00000004,

        /// <summary>
        /// D3DPTFILTERCAPS_LINEARMIPNEAREST
        /// </summary>
        D3DPTFILTERCAPS_LINEARMIPNEAREST = 0x00000010,

        /// <summary>
        /// D3DPTFILTERCAPS_LINEARMIPLINEAR
        /// </summary>
        D3DPTFILTERCAPS_LINEARMIPLINEAR = 0x00000020,
    }
}
