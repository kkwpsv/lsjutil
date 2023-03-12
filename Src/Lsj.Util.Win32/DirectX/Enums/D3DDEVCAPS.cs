using System;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// D3DDEVCAPS
    /// </summary>
    [Flags]
    public enum D3DDEVCAPS
    {
        /// <summary>
        /// D3DDEVCAPS_EXECUTESYSTEMMEMORY
        /// </summary>
        D3DDEVCAPS_EXECUTESYSTEMMEMORY = 0x00000010,

        /// <summary>
        /// D3DDEVCAPS_EXECUTEVIDEOMEMORY
        /// </summary>
        D3DDEVCAPS_EXECUTEVIDEOMEMORY = 0x00000020,

        /// <summary>
        /// D3DDEVCAPS_TLVERTEXSYSTEMMEMORY
        /// </summary>
        D3DDEVCAPS_TLVERTEXSYSTEMMEMORY = 0x00000040,

        /// <summary>
        /// D3DDEVCAPS_TLVERTEXVIDEOMEMORY
        /// </summary>
        D3DDEVCAPS_TLVERTEXVIDEOMEMORY = 0x00000080,

        /// <summary>
        /// D3DDEVCAPS_TEXTURESYSTEMMEMORY
        /// </summary>
        D3DDEVCAPS_TEXTURESYSTEMMEMORY = 0x00000100,

        /// <summary>
        /// D3DDEVCAPS_TEXTUREVIDEOMEMORY
        /// </summary>
        D3DDEVCAPS_TEXTUREVIDEOMEMORY = 0x00000200,

        /// <summary>
        /// D3DDEVCAPS_DRAWPRIMTLVERTEX
        /// </summary>
        D3DDEVCAPS_DRAWPRIMTLVERTEX = 0x00000400,

        /// <summary>
        /// D3DDEVCAPS_CANRENDERAFTERFLIP
        /// </summary>
        D3DDEVCAPS_CANRENDERAFTERFLIP = 0x00000800,

        /// <summary>
        /// D3DDEVCAPS_TEXTURENONLOCALVIDMEM
        /// </summary>
        D3DDEVCAPS_TEXTURENONLOCALVIDMEM = 0x00001000,

        /// <summary>
        /// D3DDEVCAPS_DRAWPRIMITIVES2
        /// </summary>
        D3DDEVCAPS_DRAWPRIMITIVES2 = 0x00002000,

        /// <summary>
        /// D3DDEVCAPS_SEPARATETEXTUREMEMORIES
        /// </summary>
        D3DDEVCAPS_SEPARATETEXTUREMEMORIES = 0x00004000,

        /// <summary>
        /// D3DDEVCAPS_DRAWPRIMITIVES2EX
        /// </summary>
        D3DDEVCAPS_DRAWPRIMITIVES2EX = 0x00008000,

        /// <summary>
        /// D3DDEVCAPS_HWTRANSFORMANDLIGHT
        /// </summary>
        D3DDEVCAPS_HWTRANSFORMANDLIGHT = 0x00010000,

        /// <summary>
        /// D3DDEVCAPS_CANBLTSYSTONONLOCAL
        /// </summary>
        D3DDEVCAPS_CANBLTSYSTONONLOCAL = 0x00020000,

        /// <summary>
        /// D3DDEVCAPS_HWRASTERIZATION
        /// </summary>
        D3DDEVCAPS_HWRASTERIZATION = 0x00080000,

        /// <summary>
        /// D3DDEVCAPS_PUREDEVICE
        /// </summary>
        D3DDEVCAPS_PUREDEVICE = 0x00100000,

        /// <summary>
        /// D3DDEVCAPS_QUINTICRTPATCHES
        /// </summary>
        D3DDEVCAPS_QUINTICRTPATCHES = 0x00200000,

        /// <summary>
        /// D3DDEVCAPS_RTPATCHES
        /// </summary>
        D3DDEVCAPS_RTPATCHES = 0x00400000,

        /// <summary>
        /// D3DDEVCAPS_RTPATCHHANDLEZERO
        /// </summary>
        D3DDEVCAPS_RTPATCHHANDLEZERO = 0x00800000,

        /// <summary>
        /// D3DDEVCAPS_NPATCHES
        /// </summary>
        D3DDEVCAPS_NPATCHES = 0x01000000,
    }
}
