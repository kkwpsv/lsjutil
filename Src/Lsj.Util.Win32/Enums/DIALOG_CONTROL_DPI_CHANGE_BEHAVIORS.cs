using System;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Describes per-monitor DPI scaling behavior overrides for child windows within dialogs.
    /// The values in this enumeration are bitfields and can be combined.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ne-winuser-dialog_control_dpi_change_behaviors"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This enum is used with <see cref="SetDialogControlDpiChangeBehavior"/> in order to
    /// override the default per-monitor DPI scaling behavior for a child window within a dialog.
    /// </para>
    /// <para>
    /// These settings only apply to individual controls within dialogs.
    /// The dialog-wide per-monitor DPI scaling behavior of a dialog is controlled by <see cref="DIALOG_DPI_CHANGE_BEHAVIORS"/>.
    /// </para>
    /// </remarks>
    [Flags]
    public enum DIALOG_CONTROL_DPI_CHANGE_BEHAVIORS
    {
        /// <summary>
        /// The default behavior of the dialog manager.
        /// The dialog managed will update the font, size, and position of the child window on DPI changes.
        /// </summary>
        DCDC_DEFAULT = 0x0000,

        /// <summary>
        /// Prevents the dialog manager from sending an updated font to the child window via <see cref="WM_SETFONT"/> in response to a DPI change.
        /// </summary>
        DCDC_DISABLE_FONT_UPDATE = 0x0001,

        /// <summary>
        /// Prevents the dialog manager from resizing and repositioning the child window in response to a DPI change.
        /// </summary>
        DCDC_DISABLE_RELAYOUT = 0x0002
    }
}
