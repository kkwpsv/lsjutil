using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Defines a menu item in an extended menu template.
    /// This structure definition is for explanation only; it is not present in any standard header file.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/menurc/menuex-template-item
    /// </para>
    /// </summary>
    /// <remarks>
    /// An extended menu template consists of a <see cref="MENUEX_TEMPLATE_HEADER"/> structure
    /// followed by one or more contiguous <see cref="MENUEX_TEMPLATE_ITEM"/> structures.
    /// The <see cref="MENUEX_TEMPLATE_ITEM"/> structures, which are variable in length, are aligned on <see cref="DWORD"/> boundaries.
    /// To create a menu from an extended menu template in memory, use the <see cref="LoadMenuIndirect"/> function.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct MENUEX_TEMPLATE_ITEM
    {
        /// <summary>
        /// The menu item type.
        /// This member can be a combination of the type (beginning with MFT) values listed with the <see cref="MENUITEMINFO"/> structure.
        /// </summary>
        public DWORD dwType;

        /// <summary>
        /// The menu item state. This member can be a combination of the state
        /// (beginning with MFS) values listed with the <see cref="MENUITEMINFO"/> structure.
        /// </summary>
        public DWORD dwState;

        /// <summary>
        /// The menu item identifier.
        /// This is an application-defined value that identifies the menu item.
        /// In an extended menu resource, items that open drop-down menus or submenus as well as command items can have identifiers.
        /// </summary>
        public UINT uId;

        /// <summary>
        /// Specifies whether the menu item is the last item in the menu bar, drop-down menu, submenu,
        /// or shortcut menu and whether it is an item that opens a drop-down menu or submenu.
        /// This member can be zero or more of these values.
        /// For 32-bit applications, this member is a word; for 16-bit applications, it is a byte.
        /// 0x80:
        /// The structure defines the last menu item in the menu bar, drop-down menu, submenu, or shortcut menu.
        /// 0x01:
        /// The structure defines a item that opens a drop-down menu or submenu.
        /// Subsequent structures define menu items in the corresponding drop-down menu or submenu.
        /// </summary>
        public WORD wFlags;

        /// <summary>
        /// The menu item text.
        /// This member is a null-terminated Unicode string, aligned on a word boundary.
        /// The size of the menu item definition varies depending on the length of this string.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
        public string szText;
    }
}
