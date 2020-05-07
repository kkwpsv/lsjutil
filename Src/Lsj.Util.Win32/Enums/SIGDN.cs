using Lsj.Util.Win32.ComInterfaces;
using static Lsj.Util.Win32.Enums.SFGAOF;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Requests the form of an item's display name to retrieve through <see cref="IShellItem.GetDisplayName"/> and <see cref="SHGetNameFromIDList"/>.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shobjidl_core/ne-shobjidl_core-sigdn
    /// </para>
    /// </summary>
    /// <remarks>
    /// Different forms of an item's name can be retrieved through the item's properties, including those listed here.
    /// Note that not all properties are present on all items, so only those appropriate to the item will appear.
    /// PKEY_FileName, PKEY_ItemFolderNameDisplay, PKEY_ItemFolderPathDisplay, PKEY_ItemFolderPathDisplayNarrow
    /// </remarks>
    public enum SIGDN
    {
        /// <summary>
        /// Returns the display name relative to the parent folder. In UI this name is generally ideal for display to the user.
        /// </summary>
        SIGDN_NORMALDISPLAY = 0,

        /// <summary>
        /// Returns the parsing name relative to the parent folder.
        /// This name is not suitable for use in UI.
        /// </summary>
        SIGDN_PARENTRELATIVEPARSING = unchecked((int)0x80018001),

        /// <summary>
        /// Returns the parsing name relative to the desktop.
        /// This name is not suitable for use in UI.
        /// </summary>
        SIGDN_DESKTOPABSOLUTEPARSING = unchecked((int)0x80028000),

        /// <summary>
        /// Returns the editing name relative to the parent folder.
        /// In UI this name is suitable for display to the user.
        /// </summary>
        SIGDN_PARENTRELATIVEEDITING = unchecked((int)0x80031001),

        /// <summary>
        /// Returns the editing name relative to the desktop.
        /// In UI this name is suitable for display to the user.
        /// </summary>
        SIGDN_DESKTOPABSOLUTEEDITING = unchecked((int)0x8004c000),

        /// <summary>
        /// Returns the item's file system path, if it has one.
        /// Only items that report <see cref="SFGAO_FILESYSTEM"/> have a file system path.
        /// When an item does not have a file system path, a call to <see cref="IShellItem.GetDisplayName"/> on that item will fail.
        /// In UI this name is suitable for display to the user in some cases, but note that it might not be specified for all items.
        /// </summary>
        SIGDN_FILESYSPATH = unchecked((int)0x80058000),

        /// <summary>
        /// Returns the item's URL, if it has one.
        /// Some items do not have a URL, and in those cases a call to <see cref="IShellItem.GetDisplayName"/> will fail.
        /// This name is suitable for display to the user in some cases, but note that it might not be specified for all items.
        /// </summary>
        SIGDN_URL = unchecked((int)0x80068000),

        /// <summary>
        /// Returns the path relative to the parent folder in a friendly format as displayed in an address bar.
        /// This name is suitable for display to the user.
        /// </summary>
        SIGDN_PARENTRELATIVEFORADDRESSBAR = unchecked((int)0x8007c001),

        /// <summary>
        /// Returns the path relative to the parent folder.
        /// </summary>
        SIGDN_PARENTRELATIVE = unchecked((int)0x80080001),

        /// <summary>
        /// Introduced in Windows 8.
        /// </summary>
        SIGDN_PARENTRELATIVEFORUI = unchecked((int)0x80094001)
    }
}
