using System;
using static Lsj.Util.Win32.Enums.HeaderControlMessages;
using static Lsj.Util.Win32.Enums.HeaderControlStyles;
using static Lsj.Util.Win32.Enums.WindowMessages;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Header Control Notifications
    /// </para>
    /// <para>
    /// <see href="https://learn.microsoft.com/en-us/windows/win32/controls/bumper-header-control-reference-notifications"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum HeaderControlNotifications : uint
    {
        /// <summary>
        /// HDN_FIRST
        /// </summary>
        HDN_FIRST = unchecked((uint)-300),

        /// <summary>
        /// HDN_LAST
        /// </summary>
        HDN_LAST = unchecked((uint)-399),

        /// <summary>
        /// Sent by a header control when a drag operation has begun on one of its items.
        /// This notification code is sent only by header controls that are set to the <see cref="HDS_DRAGDROP"/> style. 
        /// This notification code is sent in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        HDN_BEGINDRAG = HDN_FIRST - 10,

        /// <summary>
        /// Notifies a header control's parent window that a filter edit has begun.
        /// This notification code is sent in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        HDN_BEGINFILTEREDIT = HDN_FIRST - 14,

        /// <summary>
        /// Notifies a header control's parent window that the user has begun dragging a divider in the control
        /// (that is, the user has pressed the left mouse button while the mouse cursor is on a divider in the header control).
        /// This notification code is sent in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        HDN_BEGINTRACK = HDN_FIRST - 26,

        /// <summary>
        /// Notifies a header control's parent window that the user double-clicked the divider area of the control.
        /// This notification code is sent in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        HDN_DIVIDERDBLCLICK = HDN_FIRST - 25,

        /// <summary>
        /// Sent by a header control to its parent when the drop-down arrow on the header control is clicked.
        /// This notification code is sent in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        HDN_DROPDOWN = HDN_FIRST - 18,

        /// <summary>
        /// Sent by a header control when a drag operation has ended on one of its items.
        /// This notification code is sent as a <see cref="WM_NOTIFY"/> message.
        /// Only header controls that are set to the <see cref="HDS_DRAGDROP"/> style send this notification code.
        /// </summary>
        HDN_ENDDRAG = HDN_FIRST - 11,

        /// <summary>
        /// Notifies a header control's parent window that a filter edit has ended.
        /// This notification code is sent in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        HDN_ENDFILTEREDIT = HDN_FIRST - 15,

        /// <summary>
        /// Notifies a header control's parent window that the user has finished dragging a divider.
        /// This notification code sent in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        HDN_ENDTRACK = HDN_FIRST - 27,

        /// <summary>
        /// Notifies the header control's parent window when the filter button is clicked or in response to an <see cref="HDM_SETITEM"/> message.
        /// This notification code sent in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        HDN_FILTERBTNCLICK = HDN_FIRST - 13,

        /// <summary>
        /// Notifies the header control's parent window that the attributes of a header control filter are being changed or edited.
        /// This notification code sent in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        HDN_FILTERCHANGE = HDN_FIRST - 12,

        /// <summary>
        /// Sent to the owner of a header control when the control needs information about a callback header item.
        /// This notification code is sent as a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        HDN_GETDISPINFO = HDN_FIRST - 29,

        /// <summary>
        /// Notifies a header control's parent window that the attributes of a header item have changed.
        /// This notification code is sent in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        HDN_ITEMCHANGED = HDN_FIRST - 21,

        /// <summary>
        /// Notifies a header control's parent window that the attributes of a header item are about to change.
        /// This notification code is sent in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        HDN_ITEMCHANGING = HDN_FIRST - 20,

        /// <summary>
        /// Notifies a header control's parent window that the user clicked the control.
        /// This notification code is sent in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        HDN_ITEMCLICK = HDN_FIRST - 22,

        /// <summary>
        /// Notifies a header control's parent window that the user double-clicked the control.
        /// This notification code is sent in the form of a <see cref="WM_NOTIFY"/> message.
        /// Only header controls that are set to the <see cref="HDS_BUTTONS"/> style send this notification code.
        /// </summary>
        HDN_ITEMDBLCLICK = HDN_FIRST - 23,

        /// <summary>
        /// Notifies a header control's parent window that a key has been pressed with an item selected.
        /// This notification code is sent in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        HDN_ITEMKEYDOWN = HDN_FIRST - 17,

        /// <summary>
        /// Notifies a header control's parent window that the user clicked an item's state icon.
        /// This notification code is sent in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        HDN_ITEMSTATEICONCLICK = HDN_FIRST - 16,

        /// <summary>
        /// Sent by a header control to its parent when the header's overflow button is clicked.
        /// This notification code is sent in the form of an <see cref="WM_NOTIFY"/> message.
        /// </summary>
        HDN_OVERFLOWCLICK = HDN_FIRST - 19,

        /// <summary>
        /// Notifies a header control's parent window that the user is dragging a divider in the header control.
        /// This notification code is sent in the form of a <see cref="WM_NOTIFY"/> message.
        /// </summary>
        HDN_TRACKW = HDN_FIRST - 28,
    }
}
