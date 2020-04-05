using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="StretchBlt"/> Modes
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setstretchbltmode
    /// </para>
    /// </summary>
    public enum StretchBltModes
    {
        /// <summary>
        /// BLACKONWHITE
        /// </summary>
        BLACKONWHITE = 1,

        /// <summary>
        /// WHITEONBLACK
        /// </summary>
        WHITEONBLACK = 2,

        /// <summary>
        /// COLORONCOLOR
        /// </summary>
        COLORONCOLOR = 3,

        /// <summary>
        /// HALFTONE
        /// </summary>
        HALFTONE = 4,

        /// <summary>
        /// MAXSTRETCHBLTMODE
        /// </summary>
        MAXSTRETCHBLTMODE = 4,

        /// <summary>
        /// STRETCH_ANDSCANS
        /// </summary>
        STRETCH_ANDSCANS = BLACKONWHITE,

        /// <summary>
        /// STRETCH_ORSCANS
        /// </summary>
        STRETCH_ORSCANS = WHITEONBLACK,

        /// <summary>
        /// STRETCH_DELETESCANS
        /// </summary>
        STRETCH_DELETESCANS = COLORONCOLOR,

        /// <summary>
        /// STRETCH_HALFTONE
        /// </summary>
        STRETCH_HALFTONE = HALFTONE,
    }
}
