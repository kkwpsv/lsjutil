using System;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// D3DPTEXTURECAPS
    /// </summary>
    [Flags]
    public enum D3DPTEXTURECAPS : uint
    {
        /// <summary>
        /// D3DPTEXTURECAPS_PERSPECTIVE
        /// </summary>
        D3DPTEXTURECAPS_PERSPECTIVE = 0x00000001,

        /// <summary>
        /// D3DPTEXTURECAPS_POW2
        /// </summary>
        D3DPTEXTURECAPS_POW2 = 0x00000002,

        /// <summary>
        /// D3DPTEXTURECAPS_ALPHA
        /// </summary>
        D3DPTEXTURECAPS_ALPHA = 0x00000004,

        /// <summary>
        /// D3DPTEXTURECAPS_SQUAREONLY
        /// </summary>
        D3DPTEXTURECAPS_SQUAREONLY = 0x00000020,

        /// <summary>
        /// D3DPTEXTURECAPS_TEXREPEATNOTSCALEDBYSIZE
        /// </summary>
        D3DPTEXTURECAPS_TEXREPEATNOTSCALEDBYSIZE = 0x00000040,

        /// <summary>
        /// D3DPTEXTURECAPS_ALPHAPALETTE
        /// </summary>
        D3DPTEXTURECAPS_ALPHAPALETTE = 0x00000080,

        /// <summary>
        /// D3DPTEXTURECAPS_NONPOW2CONDITIONAL
        /// </summary>
        D3DPTEXTURECAPS_NONPOW2CONDITIONAL = 0x00000100,

        /// <summary>
        /// D3DPTEXTURECAPS_PROJECTED
        /// </summary>
        D3DPTEXTURECAPS_PROJECTED = 0x00000400,

        /// <summary>
        /// D3DPTEXTURECAPS_CUBEMAP
        /// </summary>
        D3DPTEXTURECAPS_CUBEMAP = 0x00000800,

        /// <summary>
        /// D3DPTEXTURECAPS_VOLUMEMAP
        /// </summary>
        D3DPTEXTURECAPS_VOLUMEMAP = 0x00002000,

        /// <summary>
        /// D3DPTEXTURECAPS_MIPMAP
        /// </summary>
        D3DPTEXTURECAPS_MIPMAP = 0x00004000,

        /// <summary>
        /// D3DPTEXTURECAPS_MIPVOLUMEMAP
        /// </summary>
        D3DPTEXTURECAPS_MIPVOLUMEMAP = 0x00008000,

        /// <summary>
        /// D3DPTEXTURECAPS_MIPCUBEMAP
        /// </summary>
        D3DPTEXTURECAPS_MIPCUBEMAP = 0x00010000,

        /// <summary>
        /// D3DPTEXTURECAPS_CUBEMAP_POW2
        /// </summary>
        D3DPTEXTURECAPS_CUBEMAP_POW2 = 0x00020000,

        /// <summary>
        /// D3DPTEXTURECAPS_VOLUMEMAP_POW2
        /// </summary>
        D3DPTEXTURECAPS_VOLUMEMAP_POW2 = 0x00040000,

        /// <summary>
        /// D3DPTEXTURECAPS_NOPROJECTEDBUMPENV
        /// </summary>
        D3DPTEXTURECAPS_NOPROJECTEDBUMPENV = 0x00200000,
    }
}
