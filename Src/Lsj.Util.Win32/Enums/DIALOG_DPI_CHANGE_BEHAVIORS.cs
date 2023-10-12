using System;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// In Per Monitor v2 contexts, dialogs will automatically respond to DPI changes
    /// by resizing themselves and re-computing the positions of their child windows (here referred to as re-layouting).
    /// This enum works in conjunction with <see cref="SetDialogDpiChangeBehavior"/> in order to override the default DPI scaling behavior for dialogs.
    /// This does not affect DPI scaling behavior for the child windows of dialogs (beyond re-layouting),
    /// which is controlled by <see cref="DIALOG_CONTROL_DPI_CHANGE_BEHAVIORS"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ne-winuser-dialog_dpi_change_behaviors"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum DIALOG_DPI_CHANGE_BEHAVIORS
    {
        /// <summary>
        /// The default behavior of the dialog manager.
        /// In response to a DPI change, the dialog manager will re-layout each control,
        /// update the font on each control, resize the dialog, and update the dialog's own font.
        /// </summary>
        DDC_DEFAULT = 0x0000,

        /// <summary>
        /// Prevents the dialog manager from responding to <see cref="WM_GETDPISCALEDSIZE"/> and <see cref="WM_DPICHANGED"/>,
        /// disabling all default DPI scaling behavior.
        /// </summary>
        DDC_DISABLE_ALL = 0x0001,

        /// <summary>
        /// Prevents the dialog manager from resizing the dialog in response to a DPI change.
        /// </summary>
        DDC_DISABLE_RESIZE = 0x0002,

        /// <summary>
        /// Prevents the dialog manager from re-layouting all of the dialogue's immediate children HWNDs in response to a DPI change.
        /// </summary>
        DDC_DISABLE_CONTROL_RELAYOUT = 0x0004
    }
}
