using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Status Bar Styles
    /// </para>
    /// <para>
    /// <see href="https://learn.microsoft.com/en-us/windows/win32/controls/status-bar-styles"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum StatusBarStyles : uint
    {
        /// <summary>
        /// The status bar control will include a sizing grip at the right end of the status bar.
        /// A sizing grip is similar to a sizing border; it is a rectangular area that the user can click and drag to resize the parent window.
        /// </summary>
        SBARS_SIZEGRIP = 0x0100,

        /// <summary>
        /// Version 4.71.
        /// Use this style to enable tooltips.
        /// </summary>
        SBT_TOOLTIPS = 0x0800,

        /// <summary>
        /// Version 5.80.
        /// Identical to <see cref="SBT_TOOLTIPS"/>.
        /// Use this flag for versions 5.00 or later.
        /// </summary>
        SBARS_TOOLTIPS = 0x0800,
    }
}
