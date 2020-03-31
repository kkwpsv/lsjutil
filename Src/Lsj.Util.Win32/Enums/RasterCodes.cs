using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Raster Codes
    /// </summary>
    [Flags]
    public enum RasterCodes : uint
    {
        /// <summary>
        /// BLACKNESS
        /// </summary>
        BLACKNESS = 0x00000042,

        /// <summary>
        /// CAPTUREBLT
        /// </summary>
        CAPTUREBLT = 0x40000000,

        /// <summary>
        /// DSTINVERT
        /// </summary>
        DSTINVERT = 0x00550009,

        /// <summary>
        /// MERGECOPY
        /// </summary>
        MERGECOPY = 0x00C000CA,

        /// <summary>
        /// MERGEPAINT
        /// </summary>
        MERGEPAINT = 0x00BB0226,

        /// <summary>
        ///  NOMIRRORBITMAP
        /// </summary>
        NOMIRRORBITMAP = 0x80000000,

        /// <summary>
        /// NOTSRCCOPY
        /// </summary>
        NOTSRCCOPY = 0x00330008,

        /// <summary>
        /// NOTSRCERASE
        /// </summary>
        NOTSRCERASE = 0x001100A6,

        /// <summary>
        /// PATCOPY
        /// </summary>
        PATCOPY = 0x00F00021,

        /// <summary>
        /// PATINVERT
        /// </summary>
        PATINVERT = 0x005A0049,

        /// <summary>
        /// PATPAINT
        /// </summary>
        PATPAINT = 0x00FB0A09,

        /// <summary>
        /// SRCAND
        /// </summary>
        SRCAND = 0x008800C6,

        /// <summary>
        /// SRCCOPY
        /// </summary>
        SRCCOPY = 0x00CC0020,

        /// <summary>
        /// SRCERASE
        /// </summary>
        SRCERASE = 0x00440328,

        /// <summary>
        /// SRCINVERT
        /// </summary>
        SRCINVERT = 0x00660046,

        /// <summary>
        /// SRCPAINT
        /// </summary>
        SRCPAINT = 0x00EE0086,

        /// <summary>
        /// WHITENESS
        /// </summary>
        WHITENESS = 0x00FF0062,
    }
}
