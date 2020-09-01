using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.PaletteEntryFlags;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="PALETTEENTRY"/> structure specifies the color and usage of an entry in a logical palette.
    /// A logical palette is defined by a <see cref="LOGPALETTE"/> structure.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/previous-versions/dd162769(v=vs.85)
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PALETTEENTRY
    {
        /// <summary>
        /// The red intensity value for the palette entry.
        /// </summary>
        public BYTE peRed;

        /// <summary>
        /// The green intensity value for the palette entry.
        /// </summary>
        public BYTE peGreen;

        /// <summary>
        /// The blue intensity value for the palette entry.
        /// </summary>
        public BYTE peBlue;

        /// <summary>
        /// Indicates how the palette entry is to be used.
        /// This member may be set to 0 or one of the following values.
        /// <see cref="PC_EXPLICIT"/>, <see cref="PC_NOCOLLAPSE"/>,<see cref="PC_RESERVED"/>
        /// </summary>
        public PaletteEntryFlags peFlags;
    }
}
