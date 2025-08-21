using System;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// D3DPSHADECAPS
    /// </summary>
    [Flags]
    public enum D3DPSHADECAPS
    {
        /// <summary>
        /// D3DPSHADECAPS_COLORFLATMONO
        /// </summary>
        D3DPSHADECAPS_COLORFLATMONO = 0x00000001,

        /// <summary>
        /// D3DPSHADECAPS_COLORFLATRGB
        /// </summary>
        D3DPSHADECAPS_COLORFLATRGB = 0x00000002,

        /// <summary>
        /// D3DPSHADECAPS_COLORGOURAUDMONO
        /// </summary>
        D3DPSHADECAPS_COLORGOURAUDMONO = 0x00000004,

        /// <summary>
        /// D3DPSHADECAPS_COLORGOURAUDRGB
        /// </summary>
        D3DPSHADECAPS_COLORGOURAUDRGB = 0x00000008,

        /// <summary>
        /// D3DPSHADECAPS_COLORPHONGMONO
        /// </summary>
        D3DPSHADECAPS_COLORPHONGMONO = 0x00000010,

        /// <summary>
        /// D3DPSHADECAPS_COLORPHONGRGB
        /// </summary>
        D3DPSHADECAPS_COLORPHONGRGB = 0x00000020,

        /// <summary>
        /// D3DPSHADECAPS_SPECULARFLATMONO
        /// </summary>
        D3DPSHADECAPS_SPECULARFLATMONO = 0x00000040,

        /// <summary>
        /// D3DPSHADECAPS_SPECULARFLATRGB
        /// </summary>
        D3DPSHADECAPS_SPECULARFLATRGB = 0x00000080,

        /// <summary>
        /// D3DPSHADECAPS_SPECULARGOURAUDMONO
        /// </summary>
        D3DPSHADECAPS_SPECULARGOURAUDMONO = 0x00000100,

        /// <summary>
        /// D3DPSHADECAPS_SPECULARGOURAUDRGB
        /// </summary>
        D3DPSHADECAPS_SPECULARGOURAUDRGB = 0x00000200,

        /// <summary>
        /// D3DPSHADECAPS_SPECULARPHONGMONO
        /// </summary>
        D3DPSHADECAPS_SPECULARPHONGMONO = 0x00000400,

        /// <summary>
        /// D3DPSHADECAPS_SPECULARPHONGRGB
        /// </summary>
        D3DPSHADECAPS_SPECULARPHONGRGB = 0x00000800,

        /// <summary>
        /// D3DPSHADECAPS_ALPHAFLATBLEND
        /// </summary>
        D3DPSHADECAPS_ALPHAFLATBLEND = 0x00001000,

        /// <summary>
        /// D3DPSHADECAPS_ALPHAFLATSTIPPLED
        /// </summary>
        D3DPSHADECAPS_ALPHAFLATSTIPPLED = 0x00002000,

        /// <summary>
        /// D3DPSHADECAPS_ALPHAGOURAUDBLEND
        /// </summary>
        D3DPSHADECAPS_ALPHAGOURAUDBLEND = 0x00004000,

        /// <summary>
        /// D3DPSHADECAPS_ALPHAGOURAUDSTIPPLED
        /// </summary>
        D3DPSHADECAPS_ALPHAGOURAUDSTIPPLED = 0x00008000,

        /// <summary>
        /// D3DPSHADECAPS_ALPHAPHONGBLEND
        /// </summary>
        D3DPSHADECAPS_ALPHAPHONGBLEND = 0x00010000,

        /// <summary>
        /// D3DPSHADECAPS_ALPHAPHONGSTIPPLED
        /// </summary>
        D3DPSHADECAPS_ALPHAPHONGSTIPPLED = 0x00020000,

        /// <summary>
        /// D3DPSHADECAPS_FOGFLAT
        /// </summary>
        D3DPSHADECAPS_FOGFLAT = 0x00040000,

        /// <summary>
        /// D3DPSHADECAPS_FOGGOURAUD
        /// </summary>
        D3DPSHADECAPS_FOGGOURAUD = 0x00080000,

        /// <summary>
        /// D3DPSHADECAPS_FOGPHONG
        /// </summary>
        D3DPSHADECAPS_FOGPHONG = 0x00100000,
    }
}
