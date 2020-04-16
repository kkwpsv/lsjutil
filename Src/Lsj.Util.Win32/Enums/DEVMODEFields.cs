using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="DEVMODE"/> Fields
    /// </summary>
    public enum DEVMODEFields : uint
    {
        /// <summary>
        /// DM_ORIENTATION
        /// </summary>
        DM_ORIENTATION = 0x00000001,

        /// <summary>
        /// DM_PAPERSIZE
        /// </summary>
        DM_PAPERSIZE = 0x00000002,

        /// <summary>
        /// DM_PAPERLENGTH
        /// </summary>
        DM_PAPERLENGTH = 0x00000004,

        /// <summary>
        /// DM_PAPERWIDTH
        /// </summary>
        DM_PAPERWIDTH = 0x00000008,

        /// <summary>
        /// DM_SCALE
        /// </summary>
        DM_SCALE = 0x00000010,

        /// <summary>
        /// DM_POSITION
        /// </summary>
        DM_POSITION = 0x00000020,

        /// <summary>
        /// DM_NUP
        /// </summary>
        DM_NUP = 0x00000040,

        /// <summary>
        /// DM_DISPLAYORIENTATION
        /// </summary>
        DM_DISPLAYORIENTATION = 0x00000080,

        /// <summary>
        /// DM_COPIES
        /// </summary>
        DM_COPIES = 0x00000100,

        /// <summary>
        /// DM_DEFAULTSOURCE
        /// </summary>
        DM_DEFAULTSOURCE = 0x00000200,

        /// <summary>
        /// DM_PRINTQUALITY
        /// </summary>
        DM_PRINTQUALITY = 0x00000400,

        /// <summary>
        /// DM_COLOR
        /// </summary>
        DM_COLOR = 0x00000800,

        /// <summary>
        /// DM_DUPLEX
        /// </summary>
        DM_DUPLEX = 0x00001000,

        /// <summary>
        /// DM_YRESOLUTION
        /// </summary>
        DM_YRESOLUTION = 0x00002000,

        /// <summary>
        /// DM_TTOPTION
        /// </summary>
        DM_TTOPTION = 0x00004000,

        /// <summary>
        /// DM_COLLATE
        /// </summary>
        DM_COLLATE = 0x00008000,

        /// <summary>
        /// DM_FORMNAME
        /// </summary>
        DM_FORMNAME = 0x00010000,

        /// <summary>
        /// DM_LOGPIXELS
        /// </summary>
        DM_LOGPIXELS = 0x00020000,

        /// <summary>
        /// DM_BITSPERPEL
        /// </summary>
        DM_BITSPERPEL = 0x00040000,

        /// <summary>
        /// DM_PELSWIDTH
        /// </summary>
        DM_PELSWIDTH = 0x00080000,

        /// <summary>
        /// DM_PELSHEIGHT
        /// </summary>
        DM_PELSHEIGHT = 0x00100000,

        /// <summary>
        /// DM_DISPLAYFLAGS
        /// </summary>
        DM_DISPLAYFLAGS = 0x00200000,

        /// <summary>
        /// DM_DISPLAYFREQUENCY
        /// </summary>
        DM_DISPLAYFREQUENCY = 0x00400000,

        /// <summary>
        /// DM_ICMMETHOD
        /// </summary>
        DM_ICMMETHOD = 0x00800000,

        /// <summary>
        /// DM_ICMINTENT
        /// </summary>
        DM_ICMINTENT = 0x01000000,

        /// <summary>
        /// DM_MEDIATYPE
        /// </summary>
        DM_MEDIATYPE = 0x02000000,

        /// <summary>
        /// DM_DITHERTYPE
        /// </summary>
        DM_DITHERTYPE = 0x04000000,

        /// <summary>
        /// DM_PANNINGWIDTH
        /// </summary>
        DM_PANNINGWIDTH = 0x08000000,

        /// <summary>
        /// DM_PANNINGHEIGHT
        /// </summary>
        DM_PANNINGHEIGHT = 0x10000000,

        /// <summary>
        /// DM_DISPLAYFIXEDOUTPUT
        /// </summary>
        DM_DISPLAYFIXEDOUTPUT = 0x20000000,
    }
}
