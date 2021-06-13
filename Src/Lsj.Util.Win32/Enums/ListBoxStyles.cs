using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Enums.ListBoxMessages;
using static Lsj.Util.Win32.Enums.ListBoxNotifications;
using static Lsj.Util.Win32.Enums.WindowsMessages;
using static Lsj.Util.Win32.Enums.WindowStyles;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// List Box Styles
    /// To create a list box by using the <see cref="CreateWindow"/> or <see cref="CreateWindowEx"/> function, use the LISTBOX class,
    /// appropriate window style constants, and the following style constants to define the list box.
    /// After the control has been created, these styles cannot be modified, except as noted.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/controls/list-box-styles"/>
    /// </para>
    /// </summary>
    public enum ListBoxStyles : uint
    {
        /// <summary>
        /// Notifies a list box that it is part of a combo box.
        /// This allows coordination between the two controls so that they present a unified UI.
        /// The combo box itself must set this style.
        /// If the style is set by anything but the combo box, the list box will regard itself incorrectly
        /// as a child of a combo box and a failure will result.
        /// </summary>
        LBS_COMBOBOX = 0x8000,

        /// <summary>
        /// Shows a disabled horizontal or vertical scroll bar when the list box does not contain enough items to scroll.
        /// If you do not specify this style, the scroll bar is hidden when the list box does not contain enough items.
        /// This style must be used with the <see cref="WS_VSCROLL"/> or <see cref="WS_HSCROLL"/> style.
        /// </summary>
        LBS_DISABLENOSCROLL = 0x1000,

        /// <summary>
        /// Allows multiple items to be selected by using the SHIFT key and the mouse or special key combinations.
        /// </summary>
        LBS_EXTENDEDSEL = 0x0800,

        /// <summary>
        /// Specifies that a list box contains items consisting of strings.
        /// The list box maintains the memory and addresses for the strings so that the application can use the <see cref="LB_GETTEXT"/> message
        /// to retrieve the text for a particular item.
        /// By default, all list boxes except owner-drawn list boxes have this style.
        /// You can create an owner-drawn list box either with or without this style.
        /// For owner-drawn list boxes without this style, the <see cref="LB_GETTEXT"/> message retrieves the value associated with an item (the item data).
        /// </summary>
        LBS_HASSTRINGS = 0x0040,

        /// <summary>
        /// Specifies a multi-column list box that is scrolled horizontally.
        /// The list box automatically calculates the width of the columns,
        /// or an application can set the width by using the <see cref="LB_SETCOLUMNWIDTH"/> message.
        /// If a list box has the <see cref="LBS_OWNERDRAWFIXED"/> style,
        /// an application can set the width when the list box sends the <see cref="WM_MEASUREITEM"/> message.
        /// A list box with the <see cref="LBS_MULTICOLUMN"/> style cannot scroll vertically it ignores any <see cref="WM_VSCROLL"/> messages it receives.
        /// The <see cref="LBS_MULTICOLUMN"/> and <see cref="LBS_OWNERDRAWVARIABLE"/> styles cannot be combined.
        /// If both are specified, <see cref="LBS_OWNERDRAWVARIABLE"/> is ignored.
        /// </summary>
        LBS_MULTICOLUMN = 0x0200,

        /// <summary>
        /// Turns string selection on or off each time the user clicks or double-clicks a string in the list box.
        /// The user can select any number of strings.
        /// </summary>
        LBS_MULTIPLESEL = 0x0008,

        /// <summary>
        /// Specifies a no-data list box.
        /// Specify this style when the count of items in the list box will exceed one thousand.
        /// A no-data list box must also have the <see cref="LBS_OWNERDRAWFIXED"/> style,
        /// but must not have the <see cref="LBS_SORT"/> or <see cref="LBS_HASSTRINGS"/> style.
        /// A no-data list box resembles an owner-drawn list box except that it contains no string or bitmap data for an item.
        /// Commands to add, insert, or delete an item always ignore any specified item data; requests to find a string within the list box always fail.
        /// The system sends the <see cref="WM_DRAWITEM"/> message to the owner window when an item must be drawn.
        /// The itemID member of the <see cref="DRAWITEMSTRUCT"/> structure passed with the <see cref="WM_DRAWITEM"/> message
        /// specifies the line number of the item to be drawn.
        /// A no-data list box does not send a <see cref="WM_DELETEITEM"/> message.
        /// </summary>
        LBS_NODATA = 0x2000,

        /// <summary>
        /// Specifies that the size of the list box is exactly the size specified by the application when it created the list box.
        /// Normally, the system sizes a list box so that the list box does not display partial items.
        /// For list boxes with the <see cref="LBS_OWNERDRAWVARIABLE"/> style, the <see cref="LBS_NOINTEGRALHEIGHT"/> style is always enforced.
        /// </summary>
        LBS_NOINTEGRALHEIGHT = 0x0100,

        /// <summary>
        /// Specifies that the list box's appearance is not updated when changes are made.
        /// To change the redraw state of the control, use the <see cref="WM_SETREDRAW"/> message.
        /// </summary>
        LBS_NOREDRAW = 0x0004,

        /// <summary>
        /// Specifies that the list box contains items that can be viewed but not selected.
        /// </summary>
        LBS_NOSEL = 0x4000,

        /// <summary>
        /// Causes the list box to send a notification code to the parent window whenever the user clicks a list box item (<see cref="LBN_SELCHANGE"/>),
        /// double-clicks an item (<see cref="LBN_DBLCLK"/>), or cancels the selection (<see cref="LBN_SELCANCEL"/>).
        /// </summary>
        LBS_NOTIFY = 0x0001,

        /// <summary>
        /// Specifies that the owner of the list box is responsible for drawing its contents and that the items in the list box are the same height.
        /// The owner window receives a <see cref="WM_MEASUREITEM"/> message when the list box is created and a <see cref="WM_DRAWITEM"/> message
        /// when a visual aspect of the list box has changed.
        /// </summary>
        LBS_OWNERDRAWFIXED = 0x0010,

        /// <summary>
        /// Specifies that the owner of the list box is responsible for drawing its contents and that the items in the list box are variable in height.
        /// The owner window receives a <see cref="WM_MEASUREITEM"/> message for each item in the box when the list box is created
        /// and a <see cref="WM_DRAWITEM"/> message when a visual aspect of the list box has changed.
        /// This style causes the <see cref="LBS_NOINTEGRALHEIGHT"/> style to be enabled.
        /// This style is ignored if the <see cref="LBS_MULTICOLUMN"/> style is specified.
        /// </summary>
        LBS_OWNERDRAWVARIABLE = 0x0020,

        /// <summary>
        /// Sorts strings in the list box alphabetically.
        /// </summary>
        LBS_SORT = 0x0002,

        /// <summary>
        /// Sorts strings in the list box alphabetically.
        /// The parent window receives a notification code whenever the user clicks a list box item, double-clicks an item, or or cancels the selection.
        /// The list box has a vertical scroll bar, and it has borders on all sides.
        /// This style combines the <see cref="LBS_NOTIFY"/>, <see cref="LBS_SORT"/>, <see cref="WS_VSCROLL"/>, and <see cref="WS_BORDER"/> styles.
        /// </summary>
        LBS_STANDARD = LBS_NOTIFY | LBS_SORT | WS_VSCROLL | WS_BORDER,

        /// <summary>
        /// Enables a list box to recognize and expand tab characters when drawing its strings.
        /// You can use the <see cref="LB_SETTABSTOPS"/> message to specify tab stop positions.
        /// The default tab positions are 32 dialog template units apart.
        /// Dialog template units are the device-independent units used in dialog box templates.
        /// To convert measurements from dialog template units to screen units (pixels), use the <see cref="MapDialogRect"/> function.
        /// </summary>
        LBS_USETABSTOPS = 0x0080,

        /// <summary>
        /// Specifies that the owner of the list box receives <see cref="WM_VKEYTOITEM"/> messages whenever the user presses a key
        /// and the list box has the input focus.
        /// This enables an application to perform special processing on the keyboard input.
        /// </summary>
        LBS_WANTKEYBOARDINPUT = 0x0400,
    }
}
