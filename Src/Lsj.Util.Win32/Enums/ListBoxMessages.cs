using static Lsj.Util.Win32.Enums.ListBoxStyles;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// List Box Messages
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/controls/bumper-list-box-control-reference-messages"/>
    /// </para>
    /// </summary>
    public enum ListBoxMessages
    {
        /// <summary>
        /// Adds the specified filename to a list box that contains a directory listing.
        /// </summary>
        LB_ADDFILE = 0x0196,

        /// <summary>
        /// Adds a string to a list box.
        /// If the list box does not have the <see cref="LBS_SORT"/> style, the string is added to the end of the list.
        /// Otherwise, the string is inserted into the list and the list is sorted.
        /// </summary>
        LB_ADDSTRING = 0x0180,

        /// <summary>
        /// Deletes a string in a list box.
        /// </summary>
        LB_DELETESTRING = 0x0182,

        /// <summary>
        /// Adds names to the list displayed by a list box.
        /// The message adds the names of directories and files that match a specified string and set of file attributes.
        /// <see cref="LB_DIR"/> can also add mapped drive letters to the list box.
        /// </summary>
        LB_DIR = 0x018D,

        /// <summary>
        /// Finds the first string in a list box that begins with the specified string.
        /// </summary>
        LB_FINDSTRING = 0x018F,

        /// <summary>
        /// Finds the first list box string that exactly matches the specified string, except that the search is not case sensitive.
        /// </summary>
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
        LB_GETCARETINDEX = 0x019F,

        /// <summary>
        /// Gets the number of items in a list box.
        /// </summary>
        LB_GETCOUNT = 0x018B,

        /// <summary>
        /// Gets the index of the currently selected item, if any, in a single-selection list box.
        /// </summary>
        LB_GETCURSEL = 0x0188,

        /// <summary>
        /// Gets the width, in pixels, that a list box can be scrolled horizontally (the scrollable width) if the list box has a horizontal scroll bar.
        /// </summary>
        LB_GETHORIZONTALEXTENT = 0x0193,

        /// <summary>
        /// Gets the application-defined value associated with the specified list box item.
        /// </summary>
        LB_GETITEMDATA = 0x0199,

        /// <summary>
        /// Gets the height of items in a list box.
        /// </summary>
        LB_GETITEMHEIGHT = 0x01A1,

        /// <summary>
        /// Gets the dimensions of the rectangle that bounds a list box item as it is currently displayed in the list box.
        /// </summary>
        LB_GETITEMRECT = 0x0198,

        /// <summary>
        /// Gets the number of items per column in a specified list box.
        /// </summary>
        LB_GETLISTBOXINFO = 0x01B2,

        /// <summary>
        /// Gets the current locale of the list box.
        /// You can use the locale to determine the correct sorting order of displayed text (for list boxes with the <see cref="LBS_SORT"/> style)
        /// and of text added by the <see cref="LB_ADDSTRING"/> message.
        /// </summary>
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
        LB_GETTEXT = 0x0189,

        /// <summary>
        /// Gets the length of a string in a list box.
        /// </summary>
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
        LB_INITSTORAGE = 0x01A8,

        /// <summary>
        /// Inserts a string or item data into a list box.
        /// Unlike the <see cref="LB_ADDSTRING"/> message, the <see cref="LB_INSERTSTRING"/> message does not cause a list
        /// with the <see cref="LBS_SORT"/> style to be sorted.
        /// </summary>
        LB_INSERTSTRING = 0x0181,

        /// <summary>
        /// Gets the zero-based index of the item nearest the specified point in a list box.
        /// </summary>
        LB_ITEMFROMPOINT = 0x01A9,

        /// <summary>
        /// Removes all items from a list box.
        /// </summary>
        LB_RESETCONTENT = 0x0184,

        /// <summary>
        /// Searches a list box for an item that begins with the characters in a specified string.
        /// If a matching item is found, the item is selected.
        /// </summary>
        LB_SELECTSTRING = 0x018C,

        /// <summary>
        /// Selects or deselects one or more consecutive items in a multiple-selection list box.
        /// </summary>
        LB_SELITEMRANGE = 0x019B,

        /// <summary>
        /// Selects one or more consecutive items in a multiple-selection list box.
        /// </summary>
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
        LB_SETCARETINDEX = 0x019E,

        /// <summary>
        /// Sets the width, in pixels, of all columns in a multiple-column list box.
        /// </summary>
        LB_SETCOLUMNWIDTH = 0x0195,

        /// <summary>
        /// Sets the count of items in a list box created with the <see cref="LBS_NODATA"/> style
        /// and not created with the <see cref="LBS_HASSTRINGS"/> style.
        /// </summary>
        LB_SETCOUNT = 0x01A7,

        /// <summary>
        /// Selects a string and scrolls it into view, if necessary.
        /// When the new string is selected, the list box removes the highlight from the previously selected string.
        /// </summary>
        LB_SETCURSEL = 0x0186,

        /// <summary>
        /// Sets the width, in pixels, by which a list box can be scrolled horizontally (the scrollable width).
        /// If the width of the list box is smaller than this value, the horizontal scroll bar horizontally scrolls items in the list box.
        /// If the width of the list box is equal to or greater than this value, the horizontal scroll bar is hidden.
        /// </summary>
        LB_SETHORIZONTALEXTENT = 0x0194,

        /// <summary>
        /// Sets a value associated with the specified item in a list box.
        /// </summary>
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
        LB_SETLOCALE = 0x01A5,

        /// <summary>
        /// Selects an item in a multiple-selection list box and, if necessary, scrolls the item into view.
        /// </summary>
        LB_SETSEL = 0x0185,

        /// <summary>
        /// Sets the tab-stop positions in a list box.
        /// </summary>
        LB_SETTABSTOPS = 0x0192,

        /// <summary>
        /// Ensures that the specified item in a list box is visible.
        /// </summary>
        LB_SETTOPINDEX = 0x0197,
    }
}
