using Lsj.Util.Win32.ComInterfaces;
using System;
using static Lsj.Util.Win32.Enums.FileAttributes;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Attributes that can be retrieved on an item (file or folder) or set of items.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/shell/sfgao
    /// </para>
    /// </summary>
    [Flags]
    public enum SFGAOF : uint
    {
        /// <summary>
        /// The specified items can be copied.
        /// </summary>
        SFGAO_CANCOPY = 0x00000001,

        /// <summary>
        /// The specified items can be moved.
        /// </summary>
        SFGAO_CANMOVE = 0x00000002,

        /// <summary>
        /// Shortcuts can be created for the specified items.
        /// This attribute has the same value as <see cref="DROPEFFECT_LINK"/>.
        /// If a namespace extension returns this attribute, a Create Shortcut entry with a default handler is added to the shortcut menu 
        /// that is displayed during drag-and-drop operations.
        /// The extension can also implement its own handler for the link verb in place of the default.
        /// If the extension does so, it is responsible for creating the shortcut.
        /// A Create Shortcut item is also added to the Windows Explorer File menu and to normal shortcut menus.
        /// If the item is selected, your application's <see cref="IContextMenu.InvokeCommand"/> method is invoked
        /// with the lpVerb member of the <see cref="CMINVOKECOMMANDINFO"/> structure set to link.
        /// Your application is responsible for creating the link.
        /// </summary>
        SFGAO_CANLINK = 0x00000004,

        /// <summary>
        /// The specified items can be bound to an <see cref="IStorage"/> object through <see cref="IShellFolder.BindToObject"/>.
        /// For more information about namespace manipulation capabilities, see <see cref="IStorage"/>.
        /// </summary>
        SFGAO_STORAGE = 0x00000008,

        /// <summary>
        /// The specified items can be renamed. Note that this value is essentially a suggestion; not all namespace clients allow items to be renamed.
        /// However, those that do must have this attribute set.
        /// </summary>
        SFGAO_CANRENAME = 0x00000010,

        /// <summary>
        /// The specified items can be deleted.
        /// </summary>
        SFGAO_CANDELETE = 0x00000020,

        /// <summary>
        /// The specified items have property sheets.
        /// </summary>
        SFGAO_HASPROPSHEET = 0x00000040,

        /// <summary>
        /// The specified items are drop targets.
        /// </summary>
        SFGAO_DROPTARGET = 0x00000100,

        /// <summary>
        /// This flag is a mask for the capability attributes: <see cref="SFGAO_CANCOPY"/>, <see cref="SFGAO_CANMOVE"/>, <see cref="SFGAO_CANLINK"/>,
        /// <see cref="SFGAO_CANRENAME"/>, <see cref="SFGAO_CANDELETE"/>, <see cref="SFGAO_HASPROPSHEET"/>, and <see cref="SFGAO_DROPTARGET"/>.
        /// Callers normally do not use this value.
        /// </summary>
        SFGAO_CAPABILITYMASK = 0x00000177,

        /// <summary>
        /// Windows 7 and later. The specified items are system items.
        /// </summary>
        SFGAO_SYSTEM = 0x00001000,

        /// <summary>
        /// The specified items are encrypted and might require special presentation.
        /// </summary>
        SFGAO_ENCRYPTED = 0x00002000,

        /// <summary>
        /// Accessing the item (through <see cref="IStream"/> or other storage interfaces) is expected to be a slow operation.
        /// Applications should avoid accessing items flagged with <see cref="SFGAO_ISSLOW"/>.
        /// Note:
        /// Opening a stream for an item is generally a slow operation at all times.
        /// <see cref="SFGAO_ISSLOW"/> indicates that it is expected to be especially slow,
        /// for example in the case of slow network connections or offline (<see cref="FILE_ATTRIBUTE_OFFLINE"/>) files.
        /// However, querying <see cref="SFGAO_ISSLOW"/> is itself a slow operation.
        /// Applications should query <see cref="SFGAO_ISSLOW"/> only on a background thread.
        /// An alternate method, such as retrieving the <see cref="PKEY_FileAttributes"/> property and testing for <see cref="FILE_ATTRIBUTE_OFFLINE"/>,
        /// could be used in place of a method call that involves <see cref="SFGAO_ISSLOW"/>.
        /// </summary>
        SFGAO_ISSLOW = 0x00004000,

        /// <summary>
        /// The specified items are shown as dimmed and unavailable to the user.
        /// </summary>
        SFGAO_GHOSTED = 0x00008000,

        /// <summary>
        /// The specified items are shortcuts.
        /// </summary>
        SFGAO_LINK = 0x00010000,

        /// <summary>
        /// The specified objects are shared.
        /// </summary>
        SFGAO_SHARE = 0x00020000,

        /// <summary>
        /// The specified items are read-only.
        /// In the case of folders, this means that new items cannot be created in those folders.
        /// This should not be confused with the behavior specified by the <see cref="FILE_ATTRIBUTE_READONLY"/> flag
        /// retrieved by <see cref="IColumnProvider.GetItemData"/> in a <see cref="SHCOLUMNDATA"/> structure.
        /// <see cref="FILE_ATTRIBUTE_READONLY"/> has no meaning for Win32 file system folders.
        /// </summary>
        SFGAO_READONLY = 0x00040000,

        /// <summary>
        /// The item is hidden and should not be displayed unless the Show hidden files and folders option is enabled in Folder Settings.
        /// </summary>
        SFGAO_HIDDEN = 0x00080000,

        /// <summary>
        /// Do not use.
        /// </summary>
        SFGAO_DISPLAYATTRMASK = 0x000FC000,

        /// <summary>
        /// The items are nonenumerated items and should be hidden.
        /// They are not returned through an enumerator such as that created by the <see cref="IShellFolder.EnumObjects"/> method.
        /// </summary>
        SFGAO_NONENUMERATED = 0x00100000,

        /// <summary>
        /// The items contain new content, as defined by the particular application.
        /// </summary>
        SFGAO_NEWCONTENT = 0x00200000,

        /// <summary>
        /// Not supported.
        /// </summary>
        [Obsolete]
        SFGAO_CANMONIKER = 0x00400000,

        /// <summary>
        /// Not supported.
        /// </summary>
        [Obsolete]
        SFGAO_HASSTORAGE = 0x00400000,

        /// <summary>
        /// Indicates that the item has a stream associated with it.
        /// That stream can be accessed through a call to <see cref="IShellFolder.BindToObject"/> or <see cref="IShellItem.BindToHandler"/>
        /// with <see cref="IID_IStream"/> in the riid parameter.
        /// </summary>
        SFGAO_STREAM = 0x00400000,

        /// <summary>
        /// Children of this item are accessible through <see cref="IStream"/> or <see cref="IStorage"/>.
        /// Those children are flagged with <see cref="SFGAO_STORAGE"/> or <see cref="SFGAO_STREAM"/>.
        /// </summary>
        SFGAO_STORAGEANCESTOR = 0x00800000,

        /// <summary>
        /// When specified as input, <see cref="SFGAO_VALIDATE"/> instructs the folder to validate
        /// that the items contained in a folder or Shell item array exist.
        /// If one or more of those items do not exist, <see cref="IShellFolder.GetAttributesOf"/> and <see cref="IShellItemArray.GetAttributes"/>
        /// return a failure code.
        /// This flag is never returned as an [out] value.
        /// When used with the file system folder, <see cref="SFGAO_VALIDATE"/> instructs the folder to discard cached properties
        /// retrieved by clients of <see cref="IShellFolder2.GetDetailsEx"/> that might have accumulated for the specified items.
        /// </summary>
        SFGAO_VALIDATE = 0x01000000,

        /// <summary>
        /// The specified items are on removable media or are themselves removable devices.
        /// </summary>
        SFGAO_REMOVABLE = 0x02000000,

        /// <summary>
        /// The specified items are compressed.
        /// </summary>
        SFGAO_COMPRESSED = 0x04000000,

        /// <summary>
        /// The specified items can be hosted inside a web browser or Windows Explorer frame.
        /// </summary>
        SFGAO_BROWSABLE = 0x08000000,

        /// <summary>
        /// The specified folders are either file system folders or contain at least one descendant (child, grandchild, or later)
        /// that is a file system (<see cref="SFGAO_FILESYSTEM"/>) folder.
        /// </summary>
        SFGAO_FILESYSANCESTOR = 0x10000000,

        /// <summary>
        /// The specified items are folders.
        /// Some items can be flagged with both <see cref="SFGAO_STREAM"/> and <see cref="SFGAO_FOLDER"/>,
        /// such as a compressed file with a .zip file name extension.
        /// Some applications might include this flag when testing for items that are both files and containers.
        /// </summary>
        SFGAO_FOLDER = 0x20000000,

        /// <summary>
        /// The specified folders or files are part of the file system (that is, they are files, directories, or root directories).
        /// The parsed names of the items can be assumed to be valid Win32 file system paths. These paths can be either UNC or drive-letter based.
        /// </summary>
        SFGAO_FILESYSTEM = 0x40000000,

        /// <summary>
        /// This flag is a mask for the storage capability attributes: <see cref="SFGAO_STORAGE"/>, <see cref="SFGAO_LINK"/>,
        /// <see cref="SFGAO_READONLY"/>, <see cref="SFGAO_STREAM"/>, <see cref="SFGAO_STORAGEANCESTOR"/>, <see cref="SFGAO_FILESYSANCESTOR"/>,
        /// <see cref="SFGAO_FOLDER"/>, and <see cref="SFGAO_FILESYSTEM"/>.
        /// Callers normally do not use this value.
        /// </summary>
        SFGAO_STORAGECAPMASK = 0x70C50008,

        /// <summary>
        /// The specified folders have subfolders.
        /// The <see cref="SFGAO_HASSUBFOLDER"/> attribute is only advisory and might be returned by Shell folder implementations
        /// even if they do not contain subfolders.
        /// Note, however, that the converse—failing to return <see cref="SFGAO_HASSUBFOLDER"/>—definitively states
        /// that the folder objects do not have subfolders.
        /// Returning <see cref="SFGAO_HASSUBFOLDER"/> is recommended whenever a significant amount of time is required
        /// to determine whether any subfolders exist.
        /// For example, the Shell always returns <see cref="SFGAO_HASSUBFOLDER"/> when a folder is located on a network drive.
        /// </summary>
        SFGAO_HASSUBFOLDER = 0x80000000,

        /// <summary>
        /// This flag is a mask for content attributes, at present only <see cref="SFGAO_HASSUBFOLDER"/>.
        /// Callers normally do not use this value.
        /// </summary>
        SFGAO_CONTENTSMASK = 0x80000000,

        /// <summary>
        /// Mask used by the <see cref="PKEY_SFGAOFlags"/> property to determine attributes that are considered to cause slow calculations or lack context:
        /// <see cref="SFGAO_ISSLOW"/>, <see cref="SFGAO_READONLY"/>, <see cref="SFGAO_HASSUBFOLDER"/>, and <see cref="SFGAO_VALIDATE"/>.
        /// Callers normally do not use this value.
        /// </summary>
        SFGAO_PKEYSFGAOMASK = 0x81044000,
    }
}
