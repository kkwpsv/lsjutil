using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Enums.FontWeights;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// FontType
    /// </para>
    /// <para>
    /// From: 
    /// </para>
    /// </summary>
    public enum FontType : ushort
    {
        /// <summary>
        /// The font weight is bold.
        /// This information is duplicated in the <see cref="LOGFONT.lfWeight"/> member of the <see cref="LOGFONT"/> structure
        /// and is equivalent to <see cref="FW_BOLD"/>.
        /// </summary>
        BOLD_FONTTYPE = 0x0100,

        /// <summary>
        /// The italic font attribute is set.
        /// This information is duplicated in the <see cref="LOGFONT.lfItalic"/> member of the <see cref="LOGFONT"/> structure.
        /// </summary>
        ITALIC_FONTTYPE = 0x0200,

        /// <summary>
        /// The font is a printer font.
        /// </summary>
        PRINTER_FONTTYPE = 0x4000,

        /// <summary>
        /// The font weight is normal.
        /// This information is duplicated in the <see cref="LOGFONT.lfWeight"/> member of the <see cref="LOGFONT"/> structure 
        /// and is equivalent to <see cref="FW_REGULAR"/>.
        /// </summary>
        REGULAR_FONTTYPE = 0x0400,

        /// <summary>
        /// The font is a screen font.
        /// </summary>
        SCREEN_FONTTYPE = 0x2000,

        /// <summary>
        /// The font is simulated by the graphics device interface (GDI).
        /// </summary>
        SIMULATED_FONTTYPE = 0x8000,
    }
}
