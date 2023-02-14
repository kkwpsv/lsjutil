using Lsj.Util.Win32.Structs;
using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="BUTTON_SPLITINFO.mask"/> Flags.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commctrl/ns-commctrl-button_splitinfo"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum BUTTON_SPLITINFOMaskFlags : uint
    {
        /// <summary>
        /// <see cref="BUTTON_SPLITINFO.himlGlyph"/> is valid.
        /// </summary>
        BCSIF_GLYPH = 0x0001,

        /// <summary>
        /// <see cref="BUTTON_SPLITINFO.himlGlyph"/> is valid.
        /// Use when <see cref="BUTTON_SPLITINFO.uSplitStyle"/> is set to <see cref="SplitButtonStyles.BCSS_IMAGE"/>.
        /// </summary>
        BCSIF_IMAGE = 0x0002,

        /// <summary>
        /// <see cref="BUTTON_SPLITINFO.size"/> is valid.
        /// </summary>
        BCSIF_SIZE = 0x0008,

        /// <summary>
        /// <see cref="BUTTON_SPLITINFO.uSplitStyle"/> is valid.
        /// </summary>
        BCSIF_STYLE = 0x0004,
    }
}
