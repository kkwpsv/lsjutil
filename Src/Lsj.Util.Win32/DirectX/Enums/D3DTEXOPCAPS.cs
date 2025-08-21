using System;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// D3DTEXOPCAPS
    /// </summary>
    [Flags]
    public enum D3DTEXOPCAPS : uint
    {
        /// <summary>
        /// D3DTEXOPCAPS_DISABLE
        /// </summary>
        D3DTEXOPCAPS_DISABLE = 0x00000001,

        /// <summary>
        /// D3DTEXOPCAPS_SELECTARG1
        /// </summary>
        D3DTEXOPCAPS_SELECTARG1 = 0x00000002,

        /// <summary>
        /// D3DTEXOPCAPS_SELECTARG2
        /// </summary>
        D3DTEXOPCAPS_SELECTARG2 = 0x00000004,

        /// <summary>
        /// D3DTEXOPCAPS_MODULATE
        /// </summary>
        D3DTEXOPCAPS_MODULATE = 0x00000008,

        /// <summary>
        /// D3DTEXOPCAPS_MODULATE2X
        /// </summary>
        D3DTEXOPCAPS_MODULATE2X = 0x00000010,

        /// <summary>
        /// D3DTEXOPCAPS_MODULATE4X
        /// </summary>
        D3DTEXOPCAPS_MODULATE4X = 0x00000020,

        /// <summary>
        /// D3DTEXOPCAPS_ADD
        /// </summary>
        D3DTEXOPCAPS_ADD = 0x00000040,

        /// <summary>
        /// D3DTEXOPCAPS_ADDSIGNED
        /// </summary>
        D3DTEXOPCAPS_ADDSIGNED = 0x00000080,

        /// <summary>
        /// D3DTEXOPCAPS_ADDSIGNED2X
        /// </summary>
        D3DTEXOPCAPS_ADDSIGNED2X = 0x00000100,

        /// <summary>
        /// D3DTEXOPCAPS_SUBTRACT
        /// </summary>
        D3DTEXOPCAPS_SUBTRACT = 0x00000200,

        /// <summary>
        /// D3DTEXOPCAPS_ADDSMOOTH
        /// </summary>
        D3DTEXOPCAPS_ADDSMOOTH = 0x00000400,

        /// <summary>
        /// D3DTEXOPCAPS_BLENDDIFFUSEALPHA
        /// </summary>
        D3DTEXOPCAPS_BLENDDIFFUSEALPHA = 0x00000800,

        /// <summary>
        /// D3DTEXOPCAPS_BLENDTEXTUREALPHA
        /// </summary>
        D3DTEXOPCAPS_BLENDTEXTUREALPHA = 0x00001000,

        /// <summary>
        /// D3DTEXOPCAPS_BLENDFACTORALPHA
        /// </summary>
        D3DTEXOPCAPS_BLENDFACTORALPHA = 0x00002000,

        /// <summary>
        /// D3DTEXOPCAPS_BLENDTEXTUREALPHAPM
        /// </summary>
        D3DTEXOPCAPS_BLENDTEXTUREALPHAPM = 0x00004000,

        /// <summary>
        /// D3DTEXOPCAPS_BLENDCURRENTALPHA
        /// </summary>
        D3DTEXOPCAPS_BLENDCURRENTALPHA = 0x00008000,

        /// <summary>
        /// D3DTEXOPCAPS_PREMODULATE
        /// </summary>
        D3DTEXOPCAPS_PREMODULATE = 0x00010000,

        /// <summary>
        /// D3DTEXOPCAPS_MODULATEALPHA_ADDCOLOR
        /// </summary>
        D3DTEXOPCAPS_MODULATEALPHA_ADDCOLOR = 0x00020000,

        /// <summary>
        /// D3DTEXOPCAPS_MODULATECOLOR_ADDALPHA
        /// </summary>
        D3DTEXOPCAPS_MODULATECOLOR_ADDALPHA = 0x00040000,

        /// <summary>
        /// D3DTEXOPCAPS_MODULATEINVALPHA_ADDCOLOR
        /// </summary>
        D3DTEXOPCAPS_MODULATEINVALPHA_ADDCOLOR = 0x00080000,

        /// <summary>
        /// D3DTEXOPCAPS_MODULATEINVCOLOR_ADDALPHA
        /// </summary>
        D3DTEXOPCAPS_MODULATEINVCOLOR_ADDALPHA = 0x00100000,

        /// <summary>
        /// D3DTEXOPCAPS_BUMPENVMAP
        /// </summary>
        D3DTEXOPCAPS_BUMPENVMAP = 0x00200000,

        /// <summary>
        /// D3DTEXOPCAPS_BUMPENVMAPLUMINANCE
        /// </summary>
        D3DTEXOPCAPS_BUMPENVMAPLUMINANCE = 0x00400000,

        /// <summary>
        /// D3DTEXOPCAPS_DOTPRODUCT3
        /// </summary>
        D3DTEXOPCAPS_DOTPRODUCT3 = 0x00800000,

        /// <summary>
        /// D3DTEXOPCAPS_MULTIPLYADD
        /// </summary>
        D3DTEXOPCAPS_MULTIPLYADD = 0x01000000,

        /// <summary>
        /// D3DTEXOPCAPS_LERP
        /// </summary>
        D3DTEXOPCAPS_LERP = 0x02000000,
    }
}
