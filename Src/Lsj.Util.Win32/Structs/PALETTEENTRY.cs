using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.PaletteEntryFlags;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Specifies the color and usage of an entry in a logical palette.
    /// In GDI, a logical palette is defined by a <see cref="LOGPALETTE"/> structure.
    /// In Direct3D, logical palettes are used in a <see cref="D3DHAL_DP2UPDATEPALETTE"/> structure.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-paletteentry"/>
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
        /// <para>
        /// For the GDI use case of logical palettes, <see cref="peFlags"/> indicates how the palette entry is to be used.
        /// This member may be set to zero or one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="PC_EXPLICIT"/>
        /// </term>
        /// <term>
        /// Specifies that the low-order word of the logical palette entry designates a hardware palette index.
        /// This flag allows the application to show the contents of the display device palette.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PC_NOCOLLAPSE"/>
        /// </term>
        /// <term>
        /// Specifies that the color be placed in an unused entry in the system palette
        /// instead of being matched to an existing color in the system palette.
        /// If there are no unused entries in the system palette, the color is matched normally.
        /// Once this color is in the system palette, colors in other logical palettes can be matched to this color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PC_RESERVED"/>
        /// </term>
        /// <term>
        /// Specifies that the logical palette entry be used for palette animation.
        /// This flag prevents other windows from matching colors to the palette entry since the color frequently changes.
        /// If an unused system-palette entry is available, the color is placed in that entry.
        /// Otherwise, the color is not available for animation.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// For the Direct3D use case of logical palettes, <see cref="peFlags"/> represents the alpha intensity value for the palette entry..
        /// </para>
        /// </summary>
        public PaletteEntryFlags peFlags;
    }
}
