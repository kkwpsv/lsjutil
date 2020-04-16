using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Raster Capabilities
    /// </summary>
    [Flags]
    public enum RasterCapabilities : uint
    {
        /// <summary>
        /// RC_NONE
        /// </summary>
        RC_NONE = 0,

        /// <summary>
        /// RC_BITBLT
        /// </summary>
        RC_BITBLT = 1,

        /// <summary>
        /// RC_BANDING
        /// </summary>
        RC_BANDING = 2,

        /// <summary>
        /// RC_SCALING
        /// </summary>
        RC_SCALING = 4,

        /// <summary>
        /// RC_BITMAP64
        /// </summary>
        RC_BITMAP64 = 8,

        /// <summary>
        /// RC_GDI20_OUTPUT
        /// </summary>
        RC_GDI20_OUTPUT = 0x0010,

        /// <summary>
        /// RC_GDI20_STATE
        /// </summary>
        RC_GDI20_STATE = 0x0020,

        /// <summary>
        /// RC_SAVEBITMAP
        /// </summary>
        RC_SAVEBITMAP = 0x0040,

        /// <summary>
        /// RC_DI_BITMAP
        /// </summary>
        RC_DI_BITMAP = 0x0080,

        /// <summary>
        /// RC_PALETTE
        /// </summary>
        RC_PALETTE = 0x0100,

        /// <summary>
        /// RC_DIBTODEV
        /// </summary>
        RC_DIBTODEV = 0x0200,

        /// <summary>
        /// RC_BIGFONT
        /// </summary>
        RC_BIGFONT = 0x0400,

        /// <summary>
        /// RC_STRETCHBLT
        /// </summary>
        RC_STRETCHBLT = 0x0800,

        /// <summary>
        /// RC_FLOODFILL
        /// </summary>
        RC_FLOODFILL = 0x1000,

        /// <summary>
        /// RC_STRETCHDIB
        /// </summary>
        RC_STRETCHDIB = 0x2000,

        /// <summary>
        /// RC_OP_DX_OUTPUT
        /// </summary>
        RC_OP_DX_OUTPUT = 0x4000,

        /// <summary>
        /// RC_DEVBITS
        /// </summary>
        RC_DEVBITS = 0x8000,
    }
}
