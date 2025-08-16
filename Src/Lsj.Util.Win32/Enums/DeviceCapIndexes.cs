using static Lsj.Util.Win32.Enums.RasterCapabilities;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="GetDeviceCaps"/> indexes
    /// </summary>
    public enum DeviceCapIndexes
    {
        /// <summary>
        /// DRIVERVERSION
        /// </summary>
        DRIVERVERSION = 0,

        /// <summary>
        /// TECHNOLOGY
        /// </summary>
        TECHNOLOGY = 2,

        /// <summary>
        /// HORZSIZE
        /// </summary>
        HORZSIZE = 4,

        /// <summary>
        /// VERTSIZE
        /// </summary>
        VERTSIZE = 6,

        /// <summary>
        /// HORZRES
        /// </summary>
        HORZRES = 8,

        /// <summary>
        /// VERTRES
        /// </summary>
        VERTRES = 10,

        /// <summary>
        /// LOGPIXELSX
        /// </summary>
        LOGPIXELSX = 88,

        /// <summary>
        /// LOGPIXELSY
        /// </summary>
        LOGPIXELSY = 90,

        /// <summary>
        /// BITSPIXEL
        /// </summary>
        BITSPIXEL = 12,

        /// <summary>
        /// PLANES
        /// </summary>
        PLANES = 14,

        /// <summary>
        /// NUMBRUSHES
        /// </summary>
        NUMBRUSHES = 16,

        /// <summary>
        /// NUMPENS
        /// </summary>
        NUMPENS = 18,

        /// <summary>
        /// NUMFONTS
        /// </summary>
        NUMFONTS = 22,

        /// <summary>
        /// NUMCOLORS
        /// </summary>
        NUMCOLORS = 24,

        /// <summary>
        /// ASPECTX
        /// </summary>
        ASPECTX = 40,

        /// <summary>
        /// ASPECTY
        /// </summary>
        ASPECTY = 42,

        /// <summary>
        /// ASPECTXY
        /// </summary>
        ASPECTXY = 44,

        /// <summary>
        /// PDEVICESIZE
        /// </summary>
        PDEVICESIZE = 26,

        /// <summary>
        /// CLIPCAPS
        /// </summary>
        CLIPCAPS = 36,

        /// <summary>
        /// SIZEPALETTE
        /// </summary>
        SIZEPALETTE = 104,

        /// <summary>
        /// NUMRESERVED
        /// </summary>
        NUMRESERVED = 106,

        /// <summary>
        /// COLORRES
        /// </summary>
        COLORRES = 108,

        /// <summary>
        /// PHYSICALWIDTH
        /// </summary>
        PHYSICALWIDTH = 110,

        /// <summary>
        /// PHYSICALHEIGHT
        /// </summary>
        PHYSICALHEIGHT = 111,

        /// <summary>
        /// PHYSICALOFFSETX
        /// </summary>
        PHYSICALOFFSETX = 112,

        /// <summary>
        /// PHYSICALOFFSETY
        /// </summary>
        PHYSICALOFFSETY = 113,

        /// <summary>
        /// VREFRESH
        /// </summary>
        VREFRESH = 116,

        /// <summary>
        /// SCALINGFACTORX
        /// </summary>
        SCALINGFACTORX = 114,

        /// <summary>
        /// SCALINGFACTORY
        /// </summary>
        SCALINGFACTORY = 115,

        /// <summary>
        /// BLTALIGNMENT
        /// </summary>
        BLTALIGNMENT = 119,

        /// <summary>
        /// SHADEBLENDCAPS
        /// </summary>
        SHADEBLENDCAPS = 45,

        /// <summary>
        /// RASTERCAPS
        /// </summary>
        RASTERCAPS = 38,

        /// <summary>
        /// CURVECAPS
        /// </summary>
        CURVECAPS = 28,

        /// <summary>
        /// LINECAPS
        /// </summary>
        LINECAPS = 30,

        /// <summary>
        /// POLYGONALCAPS
        /// </summary>
        POLYGONALCAPS = 32,

        /// <summary>
        /// TEXTCAPS
        /// </summary>
        TEXTCAPS = 34,

        /// <summary>
        /// COLORMGMTCAPS
        /// </summary>
        COLORMGMTCAPS = 121,

        /// <summary>
        /// DESKTOPVERTRES
        /// </summary>
        DESKTOPVERTRES = 117,

        /// <summary>
        /// DESKTOPHORZRES
        /// </summary>
        DESKTOPHORZRES = 118,
    }

}

