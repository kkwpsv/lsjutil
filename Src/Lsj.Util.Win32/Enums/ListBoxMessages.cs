using  Lsj.Util.Win32.BaseTypes;
using static Lsj.Util.Win32.BaseTypes.LCID;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.CodePages;
using static Lsj.Util.Win32.Enums.ComboBoxControlMessages;
using static Lsj.Util.Win32.Enums.DialogDirectoryListFlags;
using static Lsj.Util.Win32.Enums.ListBoxStyles;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Enums.WindowStyles;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// List Box Messages
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/controls/bumper-list-box-control-reference-messages"/>
    /// </para>
    /// </summary>
    public enum ListBoxMessages
    {
        /// <summary>
        /// Adds the specified filename to a list box that contains a directory listing.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The list box to which lParam is added must have been filled by the <see cref="DlgDirList"/> function.
        /// </para>
        /// <para>
        /// The <see cref="LB_INITSTORAGE"/> message helps speed up the initialization of list boxes that have a large number of items (more than 100).
        /// It reserves the specified amount of memory so that subsequent <see cref="LB_ADDFILE"/> messages take the shortest possible time.
        /// You can use estimates for the wParam and lParam parameters.
        /// If you overestimate, the extra memory is allocated; if you underestimate, the normal allocation is used for items that exceed the requested amount.
        /// </para>
        /// <para>
        /// For an ANSI application, the system converts the text in a list box to Unicode using <see cref="CP_ACP"/>.
        /// This can cause problems.
        /// For example, accented Roman characters in a non-Unicode list box in Japanese Windows will come out garbled.
        /// To fix this, either compile the application as Unicode or use an owner-drawn list box.
        /// </para>
        /// </remarks>
        LB_ADDFILE = 0x0196,

        /// <summary>
        /// Adds a string to a list box.
        /// If the list box does not have the <see cref="LBS_SORT"/> style, the string is added to the end of the list.
        /// Otherwise, the string is inserted into the list and the list is sorted.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If the list box has an owner-drawn style and the <see cref="LBS_SORT"/> style,
        /// but not the <see cref="LBS_HASSTRINGS"/> style, the system sends the <see cref="WM_COMPAREITEM"/> message
        /// one or more times to the owner of the list box to place the new item properly in the list box.
        /// </para>
        /// <para>
        /// The <see cref="LB_INITSTORAGE"/> message helps speed up the initialization of list boxes that have a large number of items (more than 100).
        /// It reserves the specified amount of memory so that subsequent <see cref="LB_ADDSTRING"/> messages take the shortest possible time.
        /// You can use estimates for the wParam and lParam parameters.
        /// If you overestimate, the extra memory is allocated;
        /// if you underestimate, the normal allocation is used for items that exceed the requested amount.
        /// </para>
        /// <para>
        /// If the list box has the <see cref="WS_HSCROLL"/> style and you add a string wider than the list box,
        /// send an <see cref="LB_SETHORIZONTALEXTENT"/> message to ensure the horizontal scroll bar appears.
        /// </para>
        /// <para>
        /// For an ANSI application, the system converts the text in a list box to Unicode using <see cref="CP_ACP"/>.
        /// This can cause problems.
        /// For example, accented Roman characters in a non-Unicode list box in Japanese Windows will come out garbled.
        /// To fix this, either compile the application as Unicode or use an owner-drawn list box.
        /// </para>
        /// </remarks>
        LB_ADDSTRING = 0x0180,

        /// <summary>
        /// Deletes a string in a list box.
        /// </summary>
        /// <remarks>
        /// If an application creates the list box with an owner-drawn style but without the <see cref="LBS_HASSTRINGS"/> style,
        /// the system sends a <see cref="WM_DELETEITEM"/> message to the owner of the list box
        /// so the application can free any additional data associated with the item.
        /// </remarks>
        LB_DELETESTRING = 0x0182,

        /// <summary>
        /// Adds names to the list displayed by a list box.
        /// The message adds the names of directories and files that match a specified string and set of file attributes.
        /// <see cref="LB_DIR"/> can also add mapped drive letters to the list box.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <see cref="LB_INITSTORAGE"/> message helps speed up the initialization of list boxes that have a large number of items (more than 100).
        /// It reserves the specified amount of memory so that subsequent <see cref="LB_DIR"/> messages take the shortest possible time.
        /// You can use estimates for the wParam and lParam parameters.
        /// If you overestimate, the extra memory is allocated;
        /// if you underestimate, the normal allocation is used for items that exceed the requested amount.
        /// </para>
        /// <para>
        /// If wParam includes the <see cref="DDL_DIRECTORY"/> flag and lParam specifies all the subdirectories of a first-level directory,
        /// such as C:\TEMP\*, the list box will always include a ".." entry for the root directory.
        /// This is true even if the root directory has hidden or system attributes
        /// and the <see cref="DDL_HIDDEN"/> and <see cref="DDL_SYSTEM"/> flags are not specified.
        /// The root directory of an NTFS volume has hidden and system attributes.
        /// </para>
        /// <para>
        /// The list displays long filenames, if any.
        /// </para>
        /// <para>
        /// For an ANSI application, the system converts the text in a list box to Unicode using <see cref="CP_ACP"/>.
        /// This can cause problems.
        /// For example, accented Roman characters in a non-Unicode list box in Japanese Windows will come out garbled.
        /// To fix this, either compile the application as Unicode or use an owner-drawn list box.
        /// </para>
        /// </remarks>
        LB_DIR = 0x018D,

        /// <summary>
        /// Finds the first string in a list box that begins with the specified string.
        /// </summary>
        /// <remarks>
        /// If the list box has the owner-drawn style but not the <see cref="LBS_HASSTRINGS"/> style,
        /// the action taken by <see cref="LB_FINDSTRING"/> depends on whether the <see cref="LBS_SORT"/> style is used.
        /// If <see cref="LBS_SORT"/> is used, the system sends <see cref="WM_COMPAREITEM"/> messages
        /// to the list box owner to determine which item matches the specified string.
        /// Otherwise, <see cref="LB_FINDSTRING"/> attempts to find an item that has a long value
        /// (supplied as the lParam parameter of the <see cref="LB_ADDSTRING"/> or <see cref="LB_INSERTSTRING"/> message)
        /// that matches the lParam parameter.
        /// </remarks>
        LB_FINDSTRING = 0x018F,

        /// <summary>
        /// Finds the first list box string that exactly matches the specified string, except that the search is not case sensitive.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This function is only successful if the specified string and a list box item have the same length
        /// (except for the null at the end of the specified string) and have exactly the same characters.
        /// </para>
        /// <para>
        /// If the list box has the owner-drawn style but not the <see cref="LBS_HASSTRINGS"/> style,
        /// the action taken by <see cref="LB_FINDSTRINGEXACT"/> depends on whether the <see cref="LBS_SORT"/> style is used.
        /// If <see cref="LBS_SORT"/> is used, the system sends <see cref="WM_COMPAREITEM"/> messages
        /// to the list box owner to determine which item matches the specified string.
        /// Otherwise, <see cref="LB_FINDSTRINGEXACT"/> attempts to find an item that has a long value
        /// (supplied as the lParam parameter of the <see cref="LB_ADDSTRING"/> or <see cref="LB_INSERTSTRING"/> message)
        /// that matches the lParam parameter.
        /// </para>
        /// </remarks>
        LB_FINDSTRINGEXACT = 0x01A2,

        /// <summary>
        /// Gets the index of the anchor item that is, the item from which a multiple selection starts.
        /// A multiple selection spans all items from the anchor item to the caret item.
        /// </summary>
        LB_GETANCHORINDEX = 0x019D,

        /// <summary>
        /// Retrieves the index of the item that has the focus in a multiple-selection list box.
        /// The item may or may not be selected.
        /// </summary>
        /// <remarks>
        /// This message can also be used to get the index of the item that is currently selected in a single-selection list box.
        /// </remarks>
        LB_GETCARETINDEX = 0x019F,

        /// <summary>
        /// Gets the number of items in a list box.
        /// </summary>
        /// <remarks>
        /// The returned count is one greater than the index value of the last item (the index is zero-based).
        /// </remarks>
        LB_GETCOUNT = 0x018B,

        /// <summary>
        /// Gets the index of the currently selected item, if any, in a single-selection list box.
        /// </summary>
        /// <remarks>
        /// <para>
        /// To retrieve the indexes of the selected items in a multiple-selection list box, use the <see cref="LB_GETSELITEMS"/> message.
        /// To determine whether the item that has the focus rectangle in a multiple selection list box is selected, use the <see cref="LB_GETSEL"/> message.
        /// </para>
        /// <para>
        /// If sent to a multiple-selection list box, <see cref="LB_GETCURSEL"/> returns the index of the item that has the focus rectangle.
        /// If no items are selected, it returns zero.
        /// </para>
        /// </remarks>
        LB_GETCURSEL = 0x0188,

        /// <summary>
        /// Gets the width, in pixels, that a list box can be scrolled horizontally (the scrollable width) if the list box has a horizontal scroll bar.
        /// </summary>
        /// <remarks>
        /// <para>
        /// To respond to the <see cref="LB_GETHORIZONTALEXTENT"/> message,
        /// the list box must have been defined with the <see cref="WS_HSCROLL"/> style.
        /// </para>
        /// <para>
        /// If the application does not set the horizontal extent of the list box (using <see cref="LB_SETHORIZONTALEXTENT"/>),
        /// the default horizontal extent is zero.
        /// Note that the list box does not update its horizontal extent dynamically.
        /// </para>
        /// </remarks>
        LB_GETHORIZONTALEXTENT = 0x0193,

        /// <summary>
        /// Gets the application-defined value associated with the specified list box item.
        /// </summary>
        /// <remarks>
        /// The return value is the value associated with the item, or <see cref="LB_ERR"/> if an error occurs.
        /// If the item is in an owner-drawn list box and was created without the <see cref="LBS_HASSTRINGS"/> style,
        /// this value was in the lParam parameter of the <see cref="LB_ADDSTRING"/> or <see cref="LB_INSERTSTRING"/> message
        /// that added the item to the list box.
        /// Otherwise, it is the value in the lParam of the <see cref="LB_SETITEMDATA"/> message.
        /// </remarks>
        LB_GETITEMDATA = 0x0199,

        /// <summary>
        /// Gets the height of items in a list box.
        /// </summary>
        /// <remarks>
        /// The return value is the height, in pixels, of each item in the list box.
        /// The return value is the height of the item specified by the wParam parameter
        /// if the list box has the <see cref="LBS_OWNERDRAWVARIABLE"/> style.
        /// The return value is <see cref="LB_ERR"/> if an error occurs.
        /// </remarks>
        LB_GETITEMHEIGHT = 0x01A1,

        /// <summary>
        /// Gets the dimensions of the rectangle that bounds a list box item as it is currently displayed in the list box.
        /// </summary>
        /// <remarks>
        /// If an error occurs, the return value is <see cref="LB_ERR"/>.
        /// </remarks>
        LB_GETITEMRECT = 0x0198,

        /// <summary>
        /// Gets the number of items per column in a specified list box.
        /// </summary>
        /// <remarks>
        /// This message is equivalent to <see cref="GetListBoxInfo"/>.
        /// </remarks>
        LB_GETLISTBOXINFO = 0x01B2,

        /// <summary>
        /// Gets the current locale of the list box.
        /// You can use the locale to determine the correct sorting order of displayed text (for list boxes with the <see cref="LBS_SORT"/> style)
        /// and of text added by the <see cref="LB_ADDSTRING"/> message.
        /// </summary>
        /// <remarks>
        /// The language identifier consists of a sublanguage identifier and a primary language identifier.
        /// Use the <see cref="PRIMARYLANGID"/> macro to extract the primary language identifier
        /// from the <see cref="LOWORD"/> of the return value, and the <see cref="SUBLANGID"/> macro to extract the sublanguage identifier.
        /// </remarks>
        LB_GETLOCALE = 0x01A6,

        /// <summary>
        /// Gets the selection state of an item.
        /// </summary>
        LB_GETSEL = 0x0187,

        /// <summary>
        /// Gets the total number of selected items in a multiple-selection list box.
        /// </summary>
        LB_GETSELCOUNT = 0x0190,

        /// <summary>
        /// Fills a buffer with an array of integers that specify the item numbers of selected items in a multiple-selection list box.
        /// </summary>
        LB_GETSELITEMS = 0x0191,

        /// <summary>
        /// Gets a string from a list box.
        /// </summary>
        /// <remarks>
        /// If the list box has an owner-drawn style but not the <see cref="LBS_HASSTRINGS"/> style,
        /// the buffer pointed to by the lParam parameter receives the value associated with the item (the item data).
        /// </remarks>
        LB_GETTEXT = 0x0189,

        /// <summary>
        /// Gets the length of a string in a list box.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Under certain conditions, the return value is larger than the actual length of the text.
        /// This occurs with certain mixtures of ANSI and Unicode, and is due to the operating system
        /// allowing for the possible existence of double-byte character set (DBCS) characters within the text.
        /// The return value, however, will always be at least as large as the actual length of the text;
        /// you can thus always use it to guide buffer allocation.
        /// This behavior can occur when an application uses both ANSI functions and common dialogs, which use Unicode.
        /// </para>
        /// <para>
        /// To obtain the exact length of the text, use the <see cref="WM_GETTEXT"/>, <see cref="LB_GETTEXT"/>,
        /// or <see cref="CB_GETLBTEXT"/> messages, or the <see cref="GetWindowText"/> function.
        /// </para>
        /// <para>
        /// If the list box has an owner-drawn style, but not the <see cref="LBS_HASSTRINGS"/> style,
        /// the return value is always the size, in bytes, of a <see cref="DWORD"/>.
        /// </para>
        /// </remarks>
        LB_GETTEXTLEN = 0x018A,

        /// <summary>
        /// Gets the index of the first visible item in a list box.
        /// Initially the item with index 0 is at the top of the list box, but if the list box contents have been scrolled another item may be at the top.
        /// The first visible item in a multiple-column list box is the top-left item.
        /// </summary>
        LB_GETTOPINDEX = 0x018E,

        /// <summary>
        /// Allocates memory for storing list box items.
        /// This message is used before an application adds a large number of items to a list box.
        /// </summary>
        /// <remarks>
        /// The <see cref="LB_INITSTORAGE"/> message helps speed up the initialization of list boxes that have a large number of items (more than 100).
        /// It reserves the specified amount of memory so that subsequent <see cref="LB_ADDSTRING"/>,
        /// <see cref="LB_INSERTSTRING"/>, <see cref="LB_DIR"/>, and <see cref="LB_ADDFILE"/> messages take the shortest possible time.
        /// You can use estimates for the wParam and lParam parameters.
        /// If you overestimate, the extra memory is allocated;
        /// if you underestimate, the normal allocation is used for items that exceed the requested amount.
        /// </remarks>
        LB_INITSTORAGE = 0x01A8,

        /// <summary>
        /// Inserts a string or item data into a list box.
        /// Unlike the <see cref="LB_ADDSTRING"/> message, the <see cref="LB_INSERTSTRING"/> message does not cause a list
        /// with the <see cref="LBS_SORT"/> style to be sorted.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <see cref="LB_INITSTORAGE"/> message helps speed up the initialization of list boxes that have a large number of items (more than 100).
        /// It reserves the specified amount of memory so that subsequent <see cref="LB_INSERTSTRING"/> messages take the shortest possible time.
        /// You can use estimates for the wParam and lParam parameters.
        /// If you overestimate, the extra memory is allocated;
        /// if you underestimate, the normal allocation is used for items that exceed the requested amount.
        /// </para>
        /// <para>
        /// If the list box has <see cref="WS_HSCROLL"/> style and you insert a string wider than the list box,
        /// send an <see cref="LB_SETHORIZONTALEXTENT"/> message to ensure the horizontal scroll bar appears.
        /// </para>
        /// <para>
        /// For an ANSI application, the system converts the text in a list box to Unicode using <see cref="CP_ACP"/>.
        /// This can cause problems.
        /// For example, accented Roman characters in a non-Unicode list box in Japanese Windows will come out garbled.
        /// To fix this, either compile the application as Unicode or use an owner-drawn list box.
        /// </para>
        /// </remarks>
        LB_INSERTSTRING = 0x0181,

        /// <summary>
        /// Gets the zero-based index of the item nearest the specified point in a list box.
        /// </summary>
        LB_ITEMFROMPOINT = 0x01A9,

        /// <summary>
        /// Removes all items from a list box.
        /// </summary>
        /// <remarks>
        /// If the list box has an owner-drawn style but not the <see cref="LBS_HASSTRINGS"/> style,
        /// the owner of the list box receives a <see cref="WM_DELETEITEM"/> message for each item in the list box.
        /// </remarks>
        LB_RESETCONTENT = 0x0184,

        /// <summary>
        /// Searches a list box for an item that begins with the characters in a specified string.
        /// If a matching item is found, the item is selected.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The list box is scrolled, if necessary, to bring the selected item into view.
        /// </para>
        /// <para>
        /// Do not use this message with a list box that has the <see cref="LBS_MULTIPLESEL"/> or the <see cref="LBS_EXTENDEDSEL"/> styles.
        /// </para>
        /// <para>
        /// An item is selected only if its initial characters from the starting point match the characters in the string specified by the lParam parameter.
        /// </para>
        /// <para>
        /// If the list box has the owner-drawn style but not the <see cref="LBS_HASSTRINGS"/> style,
        /// the action taken by <see cref="LB_SELECTSTRING"/> depends on whether the <see cref="LBS_SORT"/> style is used.
        /// If <see cref="LBS_SORT"/> is used, the system sends <see cref="WM_COMPAREITEM"/> messages
        /// to the list box owner to determine which item matches the specified string.
        /// Otherwise, <see cref="LB_SELECTSTRING"/> attempts to find an item that has a long value
        /// (supplied as the lParam parameter of the <see cref="LB_ADDSTRING"/> or <see cref="LB_INSERTSTRING"/> message) that matches the lParam parameter.
        /// </para>
        /// </remarks>
        LB_SELECTSTRING = 0x018C,

        /// <summary>
        /// Selects or deselects one or more consecutive items in a multiple-selection list box.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Use this message only with multiple-selection list boxes.
        /// </para>
        /// <para>
        /// This message can select a range only within the first 65,536 items.
        /// </para>
        /// </remarks>
        LB_SELITEMRANGE = 0x019B,

        /// <summary>
        /// Selects one or more consecutive items in a multiple-selection list box.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If the wParam parameter is less than the lParam parameter, the specified range of items is selected.
        /// If wParam is greater than or equal to lParam, the range is removed from the specified range of items.
        /// To select only one item, select two items and then deselect the unwanted item.
        /// </para>
        /// <para>
        /// Use this message only with multiple-selection list boxes.
        /// </para>
        /// <para>
        /// This message can select a range only within the first 65,536 items.
        /// </para>
        /// </remarks>
        LB_SELITEMRANGEEX = 0x0183,

        /// <summary>
        /// Sets the anchor item that is, the item from which a multiple selection starts.
        /// A multiple selection spans all items from the anchor item to the caret item.
        /// </summary>
        LB_SETANCHORINDEX = 0x019C,

        /// <summary>
        /// Sets the focus rectangle to the item at the specified index in a multiple-selection list box.
        /// If the item is not visible, it is scrolled into view.
        /// </summary>
        /// <remarks>
        /// If this message is sent to a single-selection list box that does not contain a selected item,
        /// the caret index is set to the item specified by the wParam parameter.
        /// If the single-selection list box does contain a selected item, the list box returns <see cref="LB_ERR"/>.
        /// </remarks>
        LB_SETCARETINDEX = 0x019E,

        /// <summary>
        /// Sets the width, in pixels, of all columns in a multiple-column list box.
        /// </summary>
        LB_SETCOLUMNWIDTH = 0x0195,

        /// <summary>
        /// Sets the count of items in a list box created with the <see cref="LBS_NODATA"/> style
        /// and not created with the <see cref="LBS_HASSTRINGS"/> style.
        /// </summary>
        /// <remarks>
        /// The <see cref="LB_SETCOUNT"/> message is supported only by list boxes
        /// created with the <see cref="LBS_NODATA"/> style and not created with the <see cref="LBS_HASSTRINGS"/> style.
        /// All other list boxes return <see cref="LB_ERR"/>.
        /// </remarks>
        LB_SETCOUNT = 0x01A7,

        /// <summary>
        /// Selects a string and scrolls it into view, if necessary.
        /// When the new string is selected, the list box removes the highlight from the previously selected string.
        /// </summary>
        /// <remarks>
        /// Use this message only with single-selection list boxes.
        /// You cannot use it to set or remove a selection in a multiple-selection list box.
        /// </remarks>
        LB_SETCURSEL = 0x0186,

        /// <summary>
        /// Sets the width, in pixels, by which a list box can be scrolled horizontally (the scrollable width).
        /// If the width of the list box is smaller than this value, the horizontal scroll bar horizontally scrolls items in the list box.
        /// If the width of the list box is equal to or greater than this value, the horizontal scroll bar is hidden.
        /// </summary>
        /// <remarks>
        /// <para>
        /// To respond to the <see cref="LB_SETHORIZONTALEXTENT"/> message,
        /// the list box must have been defined with the <see cref="WS_HSCROLL"/> style.
        /// </para>
        /// <para>
        /// Note that a list box does not update its horizontal extent dynamically.
        /// </para>
        /// <para>
        /// This message has no effect on a multiple-column list box.
        /// </para>
        /// </remarks>
        LB_SETHORIZONTALEXTENT = 0x0194,

        /// <summary>
        /// Sets a value associated with the specified item in a list box.
        /// </summary>
        /// <remarks>
        /// If the item is in an owner-drawn list box created without the <see cref="LBS_HASSTRINGS"/> style,
        /// this message replaces the value contained in the lParam parameter
        /// of the <see cref="LB_ADDSTRING"/> or <see cref="LB_INSERTSTRING"/> message that added the item to the list box.
        /// </remarks>
        LB_SETITEMDATA = 0x019A,

        /// <summary>
        /// Sets the height, in pixels, of items in a list box.
        /// If the list box has the <see cref="LBS_OWNERDRAWVARIABLE"/> style, this message sets the height of the item specified by the wParam parameter.
        /// Otherwise, this message sets the height of all items in the list box.
        /// </summary>
        LB_SETITEMHEIGHT = 0x01A0,

        /// <summary>
        /// Sets the current locale of the list box.
        /// You can use the locale to determine the correct sorting order of displayed text (for list boxes with the <see cref="LBS_SORT"/> style)
        /// and of text added by the <see cref="LB_ADDSTRING"/> message.
        /// </summary>
        /// <remarks>
        /// Use the <see cref="MAKELCID"/> macro to construct a locale identifier.
        /// </remarks>
        LB_SETLOCALE = 0x01A5,

        /// <summary>
        /// Selects an item in a multiple-selection list box and, if necessary, scrolls the item into view.
        /// </summary>
        /// <remarks>
        /// Use this message only with multiple-selection list boxes.
        /// </remarks>
        LB_SETSEL = 0x0185,

        /// <summary>
        /// Sets the tab-stop positions in a list box.
        /// </summary>
        /// <remarks>
        /// <para>
        /// To respond to the <see cref="LB_SETTABSTOPS"/> message, the list box must have been created with the <see cref="LBS_USETABSTOPS"/> style.
        /// </para>
        /// <para>
        /// If wParam is 0 and lParam is <see cref="NULL"/>, the default tab stop is two dialog template units.
        /// If wParam is 1, the list box will have tab stops separated by the distance specified by lParam.
        /// </para>
        /// <para>
        /// If lParam points to more than a single value, a tab stop will be set for each value in lParam, up to the number specified by wParam.
        /// </para>
        /// <para>
        /// The values specified by lParam are in dialog template units, which are the device-independent units used in dialog box templates.
        /// To convert measurements from dialog template units to screen units (pixels), use the <see cref="MapDialogRect"/> function.
        /// </para>
        /// <para>
        /// Windows 95/Windows 98/Windows Millennium Edition (Windows Me) :
        /// The buffer pointed to by lParam must reside in writable memory, even though the message does not modify the array.
        /// </para>
        /// </remarks>
        LB_SETTABSTOPS = 0x0192,

        /// <summary>
        /// Ensures that the specified item in a list box is visible.
        /// </summary>
        /// <remarks>
        /// The system scrolls the list box contents
        /// so that either the specified item appears at the top of the list box or the maximum scroll range has been reached.
        /// </remarks>
        LB_SETTOPINDEX = 0x0197,
    }
}
