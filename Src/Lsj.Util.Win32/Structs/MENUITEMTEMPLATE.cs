using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.MenuFlags;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Defines a menu item in a menu template.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-menuitemtemplate"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct MENUITEMTEMPLATE
    {
        /// <summary>
        /// One or more of the following predefined menu options that control the appearance of the menu item as shown in the following table.
        /// <see cref="MF_CHECKED"/>:
        /// Indicates that the menu item has a check mark next to it.
        /// <see cref="MF_GRAYED"/>:
        /// Indicates that the menu item is initially inactive and drawn with a gray effect.
        /// <see cref="MF_HELP"/>:
        /// Indicates that the menu item has a vertical separator to its left.
        /// <see cref="MF_MENUBARBREAK"/>:
        /// Indicates that the menu item is placed in a new column. The old and new columns are separated by a bar.
        /// <see cref="MF_MENUBREAK"/>:
        /// Indicates that the menu item is placed in a new column.
        /// <see cref="MF_OWNERDRAW"/>:
        /// Indicates that the owner window of the menu is responsible for drawing all visual aspects of the menu item,
        /// including highlighted, selected, and inactive states.
        /// This option is not valid for an item in a menu bar.
        /// <see cref="MF_POPUP"/>:
        /// Indicates that the item is one that opens a drop-down menu or submenu. 
        /// </summary>
        public WORD mtOption;

        /// <summary>
        /// The menu item identifier of a command item; a command item sends a command message to its owner window.
        /// The <see cref="MENUITEMTEMPLATE"/> structure for an item
        /// that opens a drop-down menu or submenu does not contain the <see cref="mtID"/> member.
        /// </summary>
        public WORD mtID;

        ///// <summary>
        ///// The menu item.
        ///// </summary>
        //public WCHAR[1] mtString;
    }
}
