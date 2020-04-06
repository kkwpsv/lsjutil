﻿using static Lsj.Util.Win32.Enums.WindowsMessages;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// To create a combo box using the <see cref="CreateWindow"/> or <see cref="CreateWindowEx"/> function,
    /// specify the COMBOBOX class, appropriate window style constants, and a combination of the following combo box styles.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/controls/combo-box-styles
    /// </para>
    /// </summary>
    public enum ComboBoxStyles
    {
        /// <summary>
        /// Automatically scrolls the text in an edit control to the right when the user types a character at the end of the line.
        /// If this style is not set, only text that fits within the rectangular boundary is allowed.
        /// </summary>
        CBS_AUTOHSCROLL = 0x0040,

        /// <summary>
        /// Shows a disabled vertical scroll bar in the list box when the box does not contain enough items to scroll.
        /// Without this style, the scroll bar is hidden when the list box does not contain enough items.
        /// </summary>
        CBS_DISABLENOSCROLL = 0x0800,

        /// <summary>
        /// Similar to <see cref="CBS_SIMPLE"/>, except that the list box is not displayed unless the user selects an icon next to the edit control.
        /// </summary>
        CBS_DROPDOWN = 0x0002,

        /// <summary>
        /// Similar to <see cref="CBS_DROPDOWN"/>, except that the edit control is replaced by a static text item
        /// that displays the current selection in the list box.
        /// </summary>
        CBS_DROPDOWNLIST = 0x0003,

        /// <summary>
        /// Specifies that an owner-drawn combo box contains items consisting of strings.
        /// The combo box maintains the memory and address for the strings so the application can use
        /// the <see cref="ComboBoxControlMessages.CB_GETLBTEXT"/> message to retrieve the text for a particular item.
        /// For accessibility issues, see Exposing Owner-Drawn Combo Box Items
        /// </summary>
        CBS_HASSTRINGS = 0x0200,

        /// <summary>
        /// Converts to lowercase all text in both the selection field and the list.
        /// </summary>
        CBS_LOWERCASE = 0x4000,

        /// <summary>
        /// Specifies that the size of the combo box is exactly the size specified by the application when it created the combo box.
        /// Normally, the system sizes a combo box so that it does not display partial items.
        /// </summary>
        CBS_NOINTEGRALHEIGHT = 0x0400,

        /// <summary>
        /// Converts text entered in the combo box edit control from the Windows character set to the OEM character set and
        /// then back to the Windows character set.
        /// This ensures proper character conversion when the application calls the <see cref="CharToOem"/> function
        /// to convert a Windows string in the combo box to OEM characters.
        /// This style is most useful for combo boxes that contain file names and applies only to
        /// combo boxes created with the <see cref="CBS_SIMPLE"/> or <see cref="CBS_DROPDOWN"/> style.
        /// </summary>
        CBS_OEMCONVERT = 0x0800,

        /// <summary>
        /// Specifies that the owner of the list box is responsible for drawing its contents and that the items in the list box are all the same height.
        /// The owner window receives a <see cref="WM_MEASUREITEM"/> message when the combo box is created
        /// and a <see cref="WM_DRAWITEM"/> message when a visual aspect of the combo box has changed.
        /// </summary>
        CBS_OWNERDRAWFIXED = 0x0010,

        /// <summary>
        /// Specifies that the owner of the list box is responsible for drawing its contents and that the items in the list box are variable in height.
        /// The owner window receives a <see cref="WM_MEASUREITEM"/> message for each item in the combo box 
        /// when you create the combo box and a <see cref="WM_DRAWITEM"/> message when a visual aspect of the combo box has changed.
        /// </summary>
        CBS_OWNERDRAWVARIABLE = 0x0020,

        /// <summary>
        /// Displays the list box at all times. The current selection in the list box is displayed in the edit control.
        /// </summary>
        CBS_SIMPLE = 0x0001,

        /// <summary>
        /// Automatically sorts strings added to the list box.
        /// </summary>
        CBS_SORT = 0x0100,

        /// <summary>
        /// Converts to uppercase all text in both the selection field and the list.
        /// </summary>
        CBS_UPPERCASE = 0x4000,
    }
}
