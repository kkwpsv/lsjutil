using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about a menu.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-menuinfo"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct MENUINFO
    {
        /// <summary>
        /// The size of the structure, in bytes.
        /// The caller must set this member to <code>sizeof(MENUINFO)</code>.
        /// </summary>
        public DWORD cbSize;

        /// <summary>
        /// Indicates the members to be retrieved or set (except for <see cref="MIM_APPLYTOSUBMENUS"/>).
        /// This member can be one or more of the following values.
        /// <see cref="MIM_APPLYTOSUBMENUS"/>:
        /// Settings apply to the menu and all of its submenus.
        /// <see cref="SetMenuInfo"/> uses this flag and <see cref="GetMenuInfo"/> ignores this flag
        /// <see cref="MIM_BACKGROUND"/>:
        /// Retrieves or sets the <see cref="hbrBack"/> member.
        /// <see cref="MIM_HELPID"/>:
        /// Retrieves or sets the <see cref="dwContextHelpID"/> member.
        /// <see cref="MIM_MAXHEIGHT"/>:
        /// Retrieves or sets the <see cref="cyMax"/> member.
        /// <see cref="MIM_MENUDATA"/>:
        /// Retrieves or sets the <see cref="dwMenuData"/> member.
        /// <see cref="MIM_STYLE"/>:
        /// Retrieves or sets the <see cref="dwStyle"/> member.
        /// </summary>
        public DWORD fMask;

        /// <summary>
        /// The menu style.
        /// This member can be one or more of the following values.
        /// <see cref="MNS_AUTODISMISS"/>:
        /// Menu automatically ends when mouse is outside the menu for approximately 10 seconds.
        /// <see cref="MNS_CHECKORBMP"/>:
        /// The same space is reserved for the check mark and the bitmap.
        /// If the check mark is drawn, the bitmap is not.
        /// All checkmarks and bitmaps are aligned.
        /// Used for menus where some items use checkmarks and some use bitmaps.
        /// <see cref="MNS_DRAGDROP"/>:
        /// Menu items are OLE drop targets or drag sources.
        /// Menu owner receives <see cref="WM_MENUDRAG"/> and <see cref="WM_MENUGETOBJECT"/> messages.
        /// <see cref="MNS_MODELESS"/>:
        /// Menu is modeless; that is, there is no menu modal message loop while the menu is active.
        /// <see cref="MNS_NOCHECK"/>:
        /// No space is reserved to the left of an item for a check mark.
        /// The item can still be selected, but the check mark will not appear next to the item.
        /// <see cref="MNS_NOTIFYBYPOS"/>:
        /// Menu owner receives a <see cref="WM_MENUCOMMAND"/> message instead of a <see cref="WM_COMMAND"/> message when the user makes a selection.
        /// <see cref="MNS_NOTIFYBYPOS"/> is a menu header style and has no effect when applied to individual sub menus.
        /// </summary>
        public DWORD dwStyle;

        /// <summary>
        /// The maximum height of the menu in pixels.
        /// When the menu items exceed the space available, scroll bars are automatically used. The default (0) is the screen height.
        /// </summary>
        public UINT cyMax;

        /// <summary>
        /// A handle to the brush to be used for the menu's background.
        /// </summary>
        public HBRUSH hbrBack;

        /// <summary>
        /// The context help identifier.
        /// This is the same value used in the <see cref="GetMenuContextHelpId"/> and <see cref="SetMenuContextHelpId"/> functions.
        /// </summary>
        public DWORD dwContextHelpID;

        /// <summary>
        /// An application-defined value.
        /// </summary>
        public ULONG_PTR dwMenuData;
    }
}
