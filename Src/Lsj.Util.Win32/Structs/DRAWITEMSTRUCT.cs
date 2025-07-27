using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.ComboBoxControlMessages;
using static Lsj.Util.Win32.Enums.ComboBoxStyles;
using static Lsj.Util.Win32.Enums.ListBoxMessages;
using static Lsj.Util.Win32.Enums.ListBoxStyles;
using static Lsj.Util.Win32.Enums.OwnerDrawActions;
using static Lsj.Util.Win32.Enums.OwnerDrawControlTypes;
using static Lsj.Util.Win32.Enums.OwnerDrawStates;
using static Lsj.Util.Win32.Enums.WindowMessages;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Provides information that the owner window uses to determine how to paint an owner-drawn control or menu item.
    /// The owner window of the owner-drawn control or menu item receives a pointer
    /// to this structure as the lParam parameter of the <see cref="WM_DRAWITEM"/> message.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-drawitemstruct"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Some control types, such as status bars, do not set the value of <see cref="CtlType"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DRAWITEMSTRUCT
    {
        /// <summary>
        /// <para>
        /// The control type. This member can be one of the following values. See Remarks.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ODT_BUTTON"/>
        /// </term>
        /// <term>
        /// Owner-drawn button
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ODT_COMBOBOX"/>
        /// </term>
        /// <term>
        /// Owner-drawn combo box
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ODT_LISTBOX"/>
        /// </term>
        /// <term>
        /// Owner-drawn list box
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ODT_LISTVIEW"/>
        /// </term>
        /// <term>
        /// List-view control
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ODT_MENU"/>
        /// </term>
        /// <term>
        /// Owner-drawn menu item
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ODT_STATIC"/>
        /// </term>
        /// <term>
        /// Owner-drawn static control
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ODT_TAB"/>
        /// </term>
        /// <term>
        /// Tab control
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public OwnerDrawControlTypes CtlType;

        /// <summary>
        /// The identifier of the combo box, list box, button, or static control. This member is not used for a menu item.
        /// </summary>
        public UINT CtlID;

        /// <summary>
        /// The menu item identifier for a menu item or the index of the item in a list box or combo box.
        /// For an empty list box or combo box, this member can be -1.
        /// This allows the application to draw only the focus rectangle at the coordinates specified by the <see cref="rcItem"/> member
        /// even though there are no items in the control.
        /// This indicates to the user whether the list box or combo box has the focus.
        /// How the bits are set in the <see cref="itemAction"/> member determines whether the rectangle is to be drawn
        /// as though the list box or combo box has the focus.
        /// </summary>
        public UINT itemID;

        /// <summary>
        /// <para>
        /// The required drawing action. This member can be one or more of the values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ODA_DRAWENTIRE"/>
        /// </term>
        /// <term>
        /// The entire control needs to be drawn.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ODA_FOCUS"/>
        /// </term>
        /// <term>
        /// The control has lost or gained the keyboard focus.
        /// The <see cref="itemState"/> member should be checked to determine whether the control has the focus.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ODA_SELECT"/>
        /// </term>
        /// <term>
        /// The selection status has changed.
        /// The <see cref="itemState"/> member should be checked to determine the new selection state.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public OwnerDrawActions itemAction;

        /// <summary>
        /// <para>
        /// The visual state of the item after the current drawing action takes place. This member can be a combination of the values shown in the following table.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ODS_CHECKED"/>
        /// </term>
        /// <term>
        /// The menu item is to be checked. This bit is used only in a menu.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ODS_COMBOBOXEDIT"/>
        /// </term>
        /// <term>
        /// The drawing takes place in the selection field (edit control) of an owner-drawn combo box.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ODS_DEFAULT"/>
        /// </term>
        /// <term>
        /// The item is the default item.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ODS_DISABLED"/>
        /// </term>
        /// <term>
        /// The item is to be drawn as disabled.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ODS_FOCUS"/>
        /// </term>
        /// <term>
        /// The item has the keyboard focus.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ODS_GRAYED"/>
        /// </term>
        /// <term>
        /// The item is to be grayed. This bit is used only in a menu.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ODS_HOTLIGHT"/>
        /// </term>
        /// <term>
        /// The item is being hot-tracked, that is, the item will be highlighted when the mouse is on the item.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ODS_INACTIVE"/>
        /// </term>
        /// <term>
        /// The item is inactive and the window associated with the menu is inactive.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ODS_NOACCEL"/>
        /// </term>
        /// <term>
        /// The control is drawn without the keyboard accelerator cues.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ODS_NOFOCUSRECT"/>
        /// </term>
        /// <term>
        /// The control is drawn without focus indicator cues.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ODS_SELECTED"/>
        /// </term>
        /// <term>
        /// The menu item's status is selected.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public OwnerDrawStates itemState;

        /// <summary>
        /// A handle to the control for combo boxes, list boxes, buttons, and static controls.
        /// For menus, this member is a handle to the menu that contains the item.
        /// </summary>
        public HWND hwndItem;

        /// <summary>
        /// A handle to a device context; this device context must be used when performing drawing operations on the control.
        /// </summary>
        public HDC hDC;

        /// <summary>
        /// A rectangle that defines the boundaries of the control to be drawn.
        /// This rectangle is in the device context specified by the <see cref="hDC"/> member.
        /// The system automatically clips anything that the owner window draws in the device context for combo boxes, list boxes,
        /// and buttons, but does not clip menu items.
        /// When drawing menu items, the owner window must not draw outside the boundaries of the rectangle defined by the <see cref="rcItem"/> member.
        /// </summary>
        public RECT rcItem;

        /// <summary>
        /// <para>
        /// The application-defined value associated with the menu item.
        /// For a control, this parameter specifies the value last assigned to the list box or combo box
        /// by the <see cref="LB_SETITEMDATA"/> or <see cref="CB_SETITEMDATA"/> message.
        /// If the list box or combo box has the <see cref="LBS_HASSTRINGS"/> or <see cref="CBS_HASSTRINGS"/> style,
        /// this value is initially zero.
        /// Otherwise, this value is initially the value that was passed to the list box or combo box
        /// in the <see cref="MSG.lParam"/> parameter of one of the following messages:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="CB_ADDSTRING"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CB_INSERTSTRING"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LB_ADDSTRING"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LB_INSERTSTRING"/>
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// If <see cref="CtlType"/> is <see cref="ODT_BUTTON"/> or <see cref="ODT_STATIC"/>, <see cref="itemData"/> is zero.
        /// </para>
        /// </summary>
        public ULONG_PTR itemData;
    }
}
