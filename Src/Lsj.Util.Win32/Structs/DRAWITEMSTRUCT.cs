using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.ListBoxMessages;
using static Lsj.Util.Win32.Enums.ListBoxStyles;
using static Lsj.Util.Win32.Enums.OwnerDrawActions;
using static Lsj.Util.Win32.Enums.OwnerDrawControlTypes;
using static Lsj.Util.Win32.Enums.OwnerDrawStates;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Provides information that the owner window uses to determine how to paint an owner-drawn control or menu item.
    /// The owner window of the owner-drawn control or menu item receives a pointer
    /// to this structure as the lParam parameter of the <see cref="WM_DRAWITEM"/> message.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-drawitemstruct
    /// </para>
    /// </summary>
    /// <remarks>
    /// Some control types, such as status bars, do not set the value of <see cref="CtlType"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DRAWITEMSTRUCT
    {
        /// <summary>
        /// The control type. This member can be one of the following values. See Remarks.
        /// <see cref="ODT_BUTTON"/>, <see cref="ODT_COMBOBOX"/>, <see cref="ODT_LISTBOX"/>,
        /// <see cref="ODT_LISTVIEW"/>, <see cref="ODT_MENU"/>, <see cref="ODT_STATIC"/>,
        /// <see cref="ODT_TAB"/>
        /// </summary>
        public OwnerDrawControlTypes CtlType;

        /// <summary>
        /// The identifier of the combo box, list box, button, or static control. This member is not used for a menu item.
        /// </summary>
        public uint CtlID;

        /// <summary>
        /// The menu item identifier for a menu item or the index of the item in a list box or combo box.
        /// For an empty list box or combo box, this member can be -1.
        /// This allows the application to draw only the focus rectangle at the coordinates specified by the <see cref="rcItem"/> member
        /// even though there are no items in the control.
        /// This indicates to the user whether the list box or combo box has the focus.
        /// How the bits are set in the <see cref="itemAction"/> member determines whether the rectangle is to be drawn
        /// as though the list box or combo box has the focus.
        /// </summary>
        public uint itemID;

        /// <summary>
        /// The required drawing action. This member can be one or more of the values.
        /// <see cref="ODA_DRAWENTIRE"/>, <see cref="ODA_FOCUS"/>, <see cref="ODA_SELECT"/>
        /// </summary>
        public OwnerDrawActions itemAction;

        /// <summary>
        /// The visual state of the item after the current drawing action takes place.
        /// This member can be a combination of the values shown in the following table.
        /// <see cref="ODS_CHECKED"/>, <see cref="ODS_COMBOBOXEDIT"/>, <see cref="ODS_DEFAULT"/>,
        /// <see cref="ODS_DISABLED"/>, <see cref="ODS_FOUCUS"/>, <see cref="ODS_GRAYED"/>,
        /// <see cref="ODS_HOTLIGHT"/>, <see cref="ODS_INACTIVE"/>, <see cref="ODS_NOACCEL"/>,
        /// <see cref="ODS_NOFOCUSRECT"/>, <see cref="ODS_SELECTED"/>
        /// </summary>
        public OwnerDrawStates itemState;

        /// <summary>
        /// A handle to the control for combo boxes, list boxes, buttons, and static controls.
        /// For menus, this member is a handle to the menu that contains the item.
        /// </summary>
        public IntPtr hwndItem;

        /// <summary>
        /// A handle to a device context; this device context must be used when performing drawing operations on the control.
        /// </summary>
        public IntPtr hDC;

        /// <summary>
        /// A rectangle that defines the boundaries of the control to be drawn.
        /// This rectangle is in the device context specified by the <see cref="hDC"/> member.
        /// The system automatically clips anything that the owner window draws in the device context for combo boxes, list boxes,
        /// and buttons, but does not clip menu items.
        /// When drawing menu items, the owner window must not draw outside the boundaries of the rectangle defined by the <see cref="rcItem"/> member.
        /// </summary>
        public RECT rcItem;

        /// <summary>
        /// The application-defined value associated with the menu item.
        /// For a control, this parameter specifies the value last assigned to the list box or combo box
        /// by the <see cref="LB_SETITEMDATA"/> or <see cref="ComboBoxControlMessages.CB_SETITEMDATA"/> message.
        /// If the list box or combo box has the <see cref="LBS_HASSTRINGS"/> or <see cref="ComboBoxStyles.CBS_HASSTRINGS"/> style,
        /// this value is initially zero.
        /// Otherwise, this value is initially the value that was passed to the list box or combo box in the lParam parameter of
        /// one of the following messages:
        /// <see cref="ComboBoxControlMessages.CB_ADDSTRING"/>, <see cref="ComboBoxControlMessages.CB_INSERTSTRING"/>,
        /// <see cref="LB_ADDSTRING"/>, <see cref="LB_INSERTSTRING"/>
        /// If <see cref="CtlType"/> is <see cref="ODT_BUTTON"/> or
        /// <see cref="ODT_STATIC"/>, <see cref="itemData"/> is zero.
        /// </summary>
        public UIntPtr itemData;
    }
}
