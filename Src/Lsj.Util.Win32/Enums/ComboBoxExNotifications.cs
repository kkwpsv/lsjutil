using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Enums.COMBOBOXEXITEMFlags;
using static Lsj.Util.Win32.Enums.WindowsMessages;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// ComboBoxEx Notifications
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/controls/bumper-comboboxex-control-reference-notifications"/>
    /// </para>
    /// </summary>
    public enum ComboBoxExNotifications : uint
    {
        /// <summary>
        /// CBEN_FIRST
        /// </summary>
        CBEN_FIRST = unchecked(0U - 800U),

        /// <summary>
        /// Sent when the user activates the drop-down list or clicks in the control's edit box.
        /// This notification code is sent in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        CBEN_BEGINEDIT = CBEN_FIRST - 4,

        /// <summary>
        /// Sent when an item has been deleted.
        /// This notification code is sent in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        CBEN_DELETEITEM = CBEN_FIRST - 2,

        /// <summary>
        /// Sent when the user begins dragging the image of the item displayed in the edit portion of the control.
        /// This notification code is sent in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        CBEN_DRAGBEGIN = CBEN_FIRST - 9,

        /// <summary>
        /// Sent when the user has concluded an operation within the edit box or has selected an item from the control's drop-down list.
        /// This notification code is sent in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        CBEN_ENDEDIT = CBEN_FIRST - 6,

        /// <summary>
        /// Sent to retrieve display information about a callback item.
        /// This notification code is sent in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        /// <remarks>
        /// The <see cref="NMCOMBOBOXEX"/> structure contains a <see cref="COMBOBOXEXITEM"/> structure.
        /// The <see cref="mask"/> member specifies the information being requested by the control.
        /// Fill the appropriate members of the structure to return the requested information to the control.
        /// If your message handler sets the <see cref="COMBOBOXEXITEM.mask"/> member of the <see cref="COMBOBOXEXITEM"/> structure to <see cref="CBEIF_DI_SETITEM"/>,
        /// the control stores the information and will not request it again.
        /// </remarks>
        CBEN_GETDISPINFO = CBEN_FIRST - 7,

        /// <summary>
        /// Sent when a new item has been inserted in the control.
        /// This notification code is sent in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        CBEN_INSERTITEM = CBEN_FIRST - 1,
    }
}
