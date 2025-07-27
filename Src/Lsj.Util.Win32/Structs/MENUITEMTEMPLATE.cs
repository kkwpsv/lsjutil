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
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-menuitemtemplate"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct MENUITEMTEMPLATE
    {
        /// <summary>
        /// <para>
        /// One or more of the following predefined menu options that control the appearance of the menu item as shown in the following table.
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
        /// <para>
        /// <see cref="MF_CHECKED"/>
        /// </para>
        /// <para>
        /// 0x00000008L
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that the menu item has a check mark next to it.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_GRAYED"/>
        /// </para>
        /// <para>
        /// 0x00000001L
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that the menu item is initially inactive and drawn with a gray effect.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_HELP"/>
        /// </para>
        /// <para>
        /// 0x00004000L
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that the menu item has a vertical separator to its left.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_MENUBARBREAK"/>
        /// </para>
        /// <para>
        /// 0x00000020L
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that the menu item is placed in a new column.
        /// The old and new columns are separated by a bar.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_MENUBREAK"/>
        /// </para>
        /// <para>
        /// 0x00000040L
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that the menu item is placed in a new column.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_OWNERDRAW"/>
        /// </para>
        /// <para>
        /// 0x00000100L
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that the owner window of the menu is responsible for drawing all visual aspects of the menu item,
        /// including highlighted, selected, and inactive states.
        /// This option is not valid for an item in a menu bar.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_POPUP"/>
        /// </para>
        /// <para>
        /// 0x00000010L
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that the item is one that opens a drop-down menu or submenu.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public WORD mtOption;

        /// <summary>
        /// The menu item identifier of a command item; a command item sends a command message to its owner window.
        /// The <see cref="MENUITEMTEMPLATE"/> structure for an item
        /// that opens a drop-down menu or submenu does not contain the <see cref="mtID"/> member.
        /// </summary>
        public WORD mtID;

        /// <summary>
        /// The menu item.
        /// </summary>
        public WCHAR mtString;
    }
}
