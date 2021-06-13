using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// ComboBox Control Messages
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/controls/bumper-combobox-control-reference-messages"/>
    /// </para>
    /// </summary>
    public enum ComboBoxControlMessages
    {
        /// <summary>
        /// CBM_FIRST
        /// </summary>
        CBM_FIRST = 0x1700,

        /// <summary>
        /// Adds a string to the list box of a combo box.
        /// If the combo box does not have the <see cref="ComboBoxStyles.CBS_SORT"/> style, the string is added to the end of the list.
        /// Otherwise, the string is inserted into the list, and the list is sorted.
        /// </summary>
        CB_ADDSTRING = 0x0143,

        /// <summary>
        /// Deletes a string in the list box of a combo box.
        /// </summary>
        CB_DELETESTRING = 0x0144,

        /// <summary>
        /// Adds names to the list displayed by the combo box.
        /// The message adds the names of directories and files that match a specified string and set of file attributes.
        /// <see cref="CB_DIR"/> can also add mapped drive letters to the list.
        /// </summary>
        CB_DIR = 0x0145,

        /// <summary>
        /// Searches the list box of a combo box for an item beginning with the characters in a specified string.
        /// </summary>
        CB_FINDSTRING = 0x014C,

        /// <summary>
        /// Finds the first list box string in a combo box that matches the string specified in the lParam parameter.
        /// </summary>
        CB_FINDSTRINGEXACT = 0x0158,

        /// <summary>
        /// Gets information about the specified combo box.
        /// </summary>
        CB_GETCOMBOBOXINFO = 0x0164,

        /// <summary>
        /// Gets the number of items in the list box of a combo box.
        /// </summary>
        CB_GETCOUNT = 0x0146,

        /// <summary>
        /// Gets the cue banner text displayed in the edit control of a combo box.
        /// Send this message explicitly or by using the <see cref="ComboBox_GetCueBannerText"/> macro.
        /// </summary>
        CB_GETCUEBANNER = CBM_FIRST + 4,

        /// <summary>
        /// An application sends a <see cref="CB_GETCURSEL"/> message to retrieve the index of the currently selected item,
        /// if any, in the list box of a combo box.
        /// </summary>
        CB_GETCURSEL = 0x0147,

        /// <summary>
        /// An application sends a <see cref="CB_GETDROPPEDCONTROLRECT"/> message to retrieve
        /// the screen coordinates of a combo box in its dropped-down state.
        /// </summary>
        CB_GETDROPPEDCONTROLRECT = 0x0152,

        /// <summary>
        /// Determines whether the list box of a combo box is dropped down.
        /// </summary>
        CB_GETDROPPEDSTATE = 0x0157,

        /// <summary>
        /// Gets the minimum allowable width, in pixels, of the list box of a combo box
        /// with the <see cref="ComboBoxStyles.CBS_DROPDOWN"/> or <see cref="ComboBoxStyles.CBS_DROPDOWNLIST"/> style.
        /// </summary>
        CB_GETDROPPEDWIDTH = 0x015F,

        /// <summary>
        /// Gets the starting and ending character positions of the current selection in the edit control of a combo box.
        /// </summary>
        CB_GETEDITSEL = 0x0140,

        /// <summary>
        /// Determines whether a combo box has the default user interface or the extended user interface.
        /// </summary>
        CB_GETEXTENDEDUI = 0x0156,

        /// <summary>
        /// Gets the width, in pixels, that the list box can be scrolled horizontally (the scrollable width).
        /// This is applicable only if the list box has a horizontal scroll bar.
        /// </summary>
        CB_GETHORIZONTALEXTENT = 0x015D,

        /// <summary>
        /// An application sends a <see cref="CB_GETITEMDATA"/> message to a combo box to retrieve
        /// the application-supplied value associated with the specified item in the combo box.
        /// </summary>
        CB_GETITEMDATA = 0x0150,

        /// <summary>
        /// Determines the height of list items or the selection field in a combo box.
        /// </summary>
        CB_GETITEMHEIGHT = 0x0154,

        /// <summary>
        /// Gets a string from the list of a combo box.
        /// </summary>
        CB_GETLBTEXT = 0x0148,

        /// <summary>
        /// Gets the length, in characters, of a string in the list of a combo box.
        /// </summary>
        CB_GETLBTEXTLEN = 0x0149,

        /// <summary>
        /// Gets the current locale of the combo box.
        /// The locale is used to determine the correct sorting order of displayed text for combo boxes
        /// with the <see cref="ComboBoxStyles.CBS_SORT"/> style and text added by using the <see cref="CB_ADDSTRING"/> message.
        /// </summary>
        CB_GETLOCALE = 0x015A,

        /// <summary>
        /// Gets the minimum number of visible items in the drop-down list of a combo box.
        /// </summary>
        CB_GETMINVISIBLE = CBM_FIRST + 2,

        /// <summary>
        /// An application sends the <see cref="CB_GETTOPINDEX"/> message to retrieve the zero-based index
        /// of the first visible item in the list box portion of a combo box.
        /// Initially, the item with index 0 is at the top of the list box, but if the list box contents have been scrolled,
        /// another item may be at the top.
        /// </summary>
        CB_GETTOPINDEX = 0x015B,

        /// <summary>
        /// An application sends the <see cref="CB_INITSTORAGE"/> message before adding a large number of items to the list box portion of a combo box.
        /// This message allocates memory for storing list box items.
        /// </summary>
        CB_INITSTORAGE = 0x0161,

        /// <summary>
        /// Inserts a string or item data into the list of a combo box.
        /// Unlike the <see cref="CB_ADDSTRING"/> message, the <see cref="CB_INSERTSTRING"/> message does not cause 
        /// a list with the <see cref="ComboBoxStyles.CBS_SORT"/> style to be sorted.
        /// </summary>
        CB_INSERTSTRING = 0x014A,

        /// <summary>
        /// Limits the length of the text the user may type into the edit control of a combo box.
        /// </summary>
        CB_LIMITTEXT = 0x0141,

        /// <summary>
        /// Removes all items from the list box and edit control of a combo box.
        /// </summary>
        CB_RESETCONTENT = 0x014B,

        /// <summary>
        /// Searches the list of a combo box for an item that begins with the characters in a specified string.
        /// If a matching item is found, it is selected and copied to the edit control.
        /// </summary>
        CB_SELECTSTRING = 0x014D,

        /// <summary>
        /// Sets the cue banner text that is displayed for the edit control of a combo box.
        /// </summary>
        CB_SETCUEBANNER = CBM_FIRST + 3,

        /// <summary>
        /// An application sends a <see cref="CB_SETCURSEL"/> message to select a string in the list of a combo box.
        /// If necessary, the list scrolls the string into view.
        /// The text in the edit control of the combo box changes to reflect the new selection, and any previous selection in the list is removed.
        /// </summary>
        CB_SETCURSEL = 0x014E,

        /// <summary>
        /// An application sends the <see cref="CB_SETDROPPEDWIDTH"/> message to set the minimum allowable width, in pixels,
        /// of the list box of a combo box with the <see cref="ComboBoxStyles.CBS_DROPDOWN"/> or <see cref="ComboBoxStyles.CBS_DROPDOWNLIST"/> style.
        /// </summary>
        CB_SETDROPPEDWIDTH = 0x0160,

        /// <summary>
        /// An application sends a <see cref="CB_SETEDITSEL"/> message to select characters in the edit control of a combo box.
        /// </summary>
        CB_SETEDITSEL = 0x0142,

        /// <summary>
        /// An application sends a <see cref="CB_SETEXTENDEDUI"/> message to select either the default UI or the extended UI
        /// for a combo box that has the <see cref="ComboBoxStyles.CBS_DROPDOWN"/> or <see cref="ComboBoxStyles.CBS_DROPDOWNLIST"/> style.
        /// </summary>
        CB_SETEXTENDEDUI = 0x0155,

        /// <summary>
        /// An application sends the <see cref="CB_SETHORIZONTALEXTENT"/> message to set the width, in pixels,
        /// by which a list box can be scrolled horizontally (the scrollable width).
        /// If the width of the list box is smaller than this value, the horizontal scroll bar horizontally scrolls items in the list box.
        /// If the width of the list box is equal to or greater than this value, the horizontal scroll bar is hidden or,
        /// if the combo box has the <see cref="ComboBoxStyles.CBS_DISABLENOSCROLL"/> style, disabled.
        /// </summary>
        CB_SETHORIZONTALEXTENT = 0x015E,

        /// <summary>
        /// An application sends a <see cref="CB_SETITEMDATA"/> message to set the value associated with the specified item in a combo box.
        /// </summary>
        CB_SETITEMDATA = 0x0151,

        /// <summary>
        /// An application sends a <see cref="CB_SETITEMHEIGHT"/> message to set the height of list items or the selection field in a combo box.
        /// </summary>
        CB_SETITEMHEIGHT = 0x0153,

        /// <summary>
        /// An application sends a <see cref="CB_SETLOCALE"/> message to set the current locale of the combo box.
        /// If the combo box has the <see cref="ComboBoxStyles.CBS_SORT"/> style and strings are added using <see cref="CB_ADDSTRING"/>,
        /// the locale of a combo box affects how list items are sorted.
        /// </summary>
        CB_SETLOCALE = 0x0159,

        /// <summary>
        /// An application sends a <see cref="CB_SETMINVISIBLE"/> message to set the minimum number of visible items in the drop-down list of a combo box.
        /// </summary>
        CB_SETMINVISIBLE = CBM_FIRST + 1,

        /// <summary>
        /// An application sends the <see cref="CB_SETTOPINDEX"/> message to ensure that a particular item is visible in the list box of a combo box.
        /// The system scrolls the list box contents so that either the specified item appears at the top of the list box
        /// or the maximum scroll range has been reached.
        /// </summary>
        CB_SETTOPINDEX = 0x015C,

        /// <summary>
        /// An application sends a <see cref="CB_SHOWDROPDOWN"/> message to show or hide the list box of a combo box
        /// that has the <see cref="ComboBoxStyles.CBS_DROPDOWN"/> or <see cref="ComboBoxStyles.CBS_DROPDOWNLIST"/> style.
        /// </summary>
        CB_SHOWDROPDOWN = 0x014F,
    }
}
