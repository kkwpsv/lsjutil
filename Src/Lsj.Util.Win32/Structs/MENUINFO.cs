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
        /// <para>
        /// Indicates the members to be retrieved or set (except for <see cref="MIM_APPLYTOSUBMENUS"/>).
        /// This member can be one or more of the following values.
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
        /// <see cref="MIM_APPLYTOSUBMENUS"/>
        /// </para>
        /// <para>
        /// 0x80000000
        /// </para>
        /// </term>
        /// <term>
        /// Settings apply to the menu and all of its submenus.
        /// <see cref="SetMenuInfo"/> uses this flag and <see cref="GetMenuInfo"/> ignores this flag
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MIM_BACKGROUND"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves or sets the <see cref="hbrBack"/> member.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MIM_HELPID"/>
        /// </para>
        /// <para>
        /// 0x00000004
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves or sets the <see cref="dwContextHelpID"/> member.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MIM_MAXHEIGHT"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves or sets the <see cref="cyMax"/> member.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MIM_MENUDATA"/>
        /// </para>
        /// <para>
        /// 0x00000008
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves or sets the <see cref="dwMenuData"/> member.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MIM_STYLE"/>
        /// </para>
        /// <para>
        /// 0x00000010
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves or sets the <see cref="dwStyle"/> member.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public DWORD fMask;

        /// <summary>
        /// <para>
        /// The menu style.
        /// This member can be one or more of the following values.
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
        /// <see cref="MNS_AUTODISMISS"/>
        /// </para>
        /// <para>
        /// 0x10000000
        /// </para>
        /// </term>
        /// <term>
        /// Menu automatically ends when mouse is outside the menu for approximately 10 seconds.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MNS_CHECKORBMP"/>
        /// </para>
        /// <para>
        /// 0x04000000
        /// </para>
        /// </term>
        /// <term>
        /// The same space is reserved for the check mark and the bitmap.
        /// If the check mark is drawn, the bitmap is not.
        /// All checkmarks and bitmaps are aligned.
        /// Used for menus where some items use checkmarks and some use bitmaps.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MNS_DRAGDROP"/>
        /// </para>
        /// <para>
        /// 0x20000000
        /// </para>
        /// </term>
        /// <term>
        /// Menu items are OLE drop targets or drag sources.
        /// Menu owner receives <see cref="WM_MENUDRAG"/> and <see cref="WM_MENUGETOBJECT"/> messages.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MNS_MODELESS"/>
        /// </para>
        /// <para>
        /// 0x40000000
        /// </para>
        /// </term>
        /// <term>
        /// Menu is modeless; that is, there is no menu modal message loop while the menu is active.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MNS_NOCHECK"/>
        /// </para>
        /// <para>
        /// 0x80000000
        /// </para>
        /// </term>
        /// <term>
        /// No space is reserved to the left of an item for a check mark.
        /// The item can still be selected, but the check mark will not appear next to the item.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MNS_NOTIFYBYPOS"/>
        /// </para>
        /// <para>
        /// 0x08000000
        /// </para>
        /// </term>
        /// <term>
        /// Menu owner receives a <see cref="WM_MENUCOMMAND"/> message instead of a <see cref="WM_COMMAND"/> message when the user makes a selection.
        /// <see cref="MNS_NOTIFYBYPOS"/> is a menu header style and has no effect when applied to individual sub menus.
        /// </term>
        /// </item>
        /// </list>
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
