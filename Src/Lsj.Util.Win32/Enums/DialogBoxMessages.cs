using static Lsj.Util.Win32.Enums.WindowMessages;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Dialog Box Messages
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/dlgbox/dialog-box-messages"/>
    /// </para>
    /// </summary>
    public enum DialogBoxMessages : uint
    {
        /// <summary>
        /// Retrieves the identifier of the default push button control for a dialog box.
        /// </summary>
        DM_GETDEFID = WM_USER + 0,

        /// <summary>
        /// Repositions a top-level dialog box so that it fits within the desktop area.
        /// An application can send this message to a dialog box after resizing it to ensure that the entire dialog box remains visible.
        /// </summary>
        DM_REPOSITION = WM_USER + 2,

        /// <summary>
        /// Changes the identifier of the default push button for a dialog box.
        /// </summary>
        DM_SETDEFID = WM_USER + 1,
    }
}
