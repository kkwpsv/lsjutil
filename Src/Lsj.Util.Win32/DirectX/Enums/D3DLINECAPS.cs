using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// D3DLINECAPS
    /// </summary>
    public enum D3DLINECAPS : uint
    {
        /// <summary>
        /// D3DLINECAPS_TEXTURE
        /// </summary>
        D3DLINECAPS_TEXTURE = 0x00000001,

        /// <summary>
        /// D3DLINECAPS_ZTEST
        /// </summary>
        D3DLINECAPS_ZTEST = 0x00000002,

        /// <summary>
        /// D3DLINECAPS_BLEND
        /// </summary>
        D3DLINECAPS_BLEND = 0x00000004,

        /// <summary>
        /// D3DLINECAPS_ALPHACMP
        /// </summary>
        D3DLINECAPS_ALPHACMP = 0x00000008,

        /// <summary>
        /// D3DLINECAPS_FOG
        /// </summary>
        D3DLINECAPS_FOG = 0x00000010,

        /// <summary>
        /// D3DLINECAPS_ANTIALIAS
        /// </summary>
        D3DLINECAPS_ANTIALIAS = 0x00000020,
    }
}
