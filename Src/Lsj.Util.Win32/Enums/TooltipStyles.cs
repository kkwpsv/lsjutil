using System;
using static Lsj.Util.Win32.Enums.WindowStyles;
using static Lsj.Util.Win32.Enums.WindowStylesEx;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Tooltip Styles
    /// </para>
    /// <para>
    /// <see href="https://learn.microsoft.com/en-us/windows/win32/controls/tooltip-styles"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// A tooltip control always has the <see cref="WS_POPUP"/> and <see cref="WS_EX_TOOLWINDOW"/> window styles, regardless of whether you specify them when creating the control.
    /// </remarks>
    [Flags]
    public enum TooltipStyles : uint
    {
        /// <summary>
        /// Indicates that the tooltip control appears when the cursor is on a tool, even if the tooltip control's owner window is inactive.
        /// Without this style, the tooltip appears only when the tool's owner window is active.
        /// </summary>
        TTS_ALWAYSTIP = 0x01,

        /// <summary>
        /// Version 5.80.
        /// Indicates that the tooltip control has the appearance of a cartoon "balloon," with rounded corners and a stem pointing to the item.
        /// </summary>
        TTS_BALLOON = 0x40,

        /// <summary>
        /// Displays a Close button on the tooltip.
        /// Valid only when the tooltip has the <see cref="TTS_BALLOON"/> style and a title; see <see cref="TTM_SETTITLE"/>.
        /// </summary>
        TTS_CLOSE = 0x80,

        /// <summary>
        /// Version 5.80.
        /// Disables sliding tooltip animation on Windows 98 and Windows 2000 systems.
        /// This style is ignored on earlier systems.
        /// </summary>
        TTS_NOANIMATE = 0x10,

        /// <summary>
        /// Version 5.80.
        /// Disables fading tooltip animation.
        /// </summary>
        TTS_NOFADE = 0x20,

        /// <summary>
        /// Prevents the system from stripping ampersand characters from a string or terminating a string at a tab character.
        /// Without this style, the system automatically strips ampersand characters and terminates a string at the first tab character.
        /// This allows an application to use the same string as both a menu item and as text in a tooltip control.
        /// </summary>
        TTS_NOPREFIX = 0x02,

        /// <summary>
        /// Uses themed hyperlinks.
        /// The theme will define the styles for any links in the tooltip.
        /// This style always requires <see cref="TTF_PARSELINKS"/> to be set.
        /// </summary>
        TTS_USEVISUALSTYLE = 0x100,
    }
}
