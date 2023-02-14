using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Owner draw actions
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-drawitemstruct"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum OwnerDrawStates : uint
    {
        /// <summary>
        /// The menu item is to be checked. This bit is used only in a menu.
        /// </summary>
        ODS_CHECKED = 0x0008,

        /// <summary>
        /// The drawing takes place in the selection field (edit control) of an owner-drawn combo box.
        /// </summary>
        ODS_COMBOBOXEDIT = 0x1000,

        /// <summary>
        /// The item is the default item.
        /// </summary>
        ODS_DEFAULT = 0x0020,

        /// <summary>
        /// The item is to be drawn as disabled.
        /// </summary>
        ODS_DISABLED = 0x0004,

        /// <summary>
        /// The item has the keyboard focus.
        /// </summary>
        ODS_FOUCUS = 0x0010,

        /// <summary>
        /// The item is to be grayed. This bit is used only in a menu.
        /// </summary>
        ODS_GRAYED = 0x0002,

        /// <summary>
        /// The item is being hot-tracked, that is, the item will be highlighted when the mouse is on the item.
        /// </summary>
        ODS_HOTLIGHT = 0x0040,

        /// <summary>
        /// The item is inactive and the window associated with the menu is inactive.
        /// </summary>
        ODS_INACTIVE = 0x0080,

        /// <summary>
        /// The control is drawn without the keyboard accelerator cues.
        /// </summary>
        ODS_NOACCEL = 0x0100,

        /// <summary>
        /// The control is drawn without focus indicator cues.
        /// </summary>
        ODS_NOFOCUSRECT = 0x0200,

        /// <summary>
        /// The menu item's status is selected.
        /// </summary>
        ODS_SELECTED = 0x0001,
    }
}
