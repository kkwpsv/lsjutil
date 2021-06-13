using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Shell32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Indicates the interpretation of the data passed by <see cref="SHAddToRecentDocs"/> in its pv parameter
    /// to identify the item whose usage statistics are being tracked.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/shlobj_core/ne-shlobj_core-shard"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Before Windows 7, <see cref="SHARD_PIDL"/>, <see cref="SHARD_PATHA"/>, and <see cref="SHARD_PATHW"/> were
    /// defined as individual constants, not as enumeration members.
    /// When providing an <see cref="IShellLink"/> through either <see cref="SHARD_LINK"/> or <see cref="SHARD_APPIDINFOLINK"/>,
    /// the <see cref="IShellLink"/> instance must provide the following:
    /// Either a PIDL (<see cref="IShellLink.SetIDList"/>) or the target path (<see cref="IShellLink.SetPath"/>
    /// or <see cref="IShellLink.SetRelativePath"/>)
    /// Command-line arguments(<see cref="IShellLink.SetArguments"/>)
    /// Icon location(<see cref="IShellLink.SetIconLocation"/>)
    /// The display name must be set through the item's System.Title (PKEY_Title) property.
    /// The property can directly hold the display name or it can be an indirect string representation, 
    /// such as "@shell32.dll,-1324", to use a stored string.
    /// An indirect string enables the item name to be displayed in the user's selected language.
    /// Optionally, the description field(<see cref="IShellLink.SetDescription"/>) can be set to provide a custom tooltip for the item in the Jump List.
    /// </remarks>
    public enum SHARD
    {
        /// <summary>
        /// The pv parameter points to a PIDL that identifies the document's file object.
        /// PIDLs that identify non-file objects are not accepted.
        /// </summary>
        SHARD_PIDL = 0x00000001,

        /// <summary>
        /// The pv parameter points to a null-terminated ANSI string with the path and file name of the object.
        /// </summary>
        SHARD_PATHA = 0x00000002,

        /// <summary>
        /// The pv parameter points to a null-terminated Unicode string with the path and file name of the object.
        /// </summary>
        SHARD_PATHW = 0x00000003,

        /// <summary>
        /// Windows 7 and later.
        /// The pv parameter points to a <see cref="SHARDAPPIDINFO"/> structure that pairs an <see cref="IShellItem"/>
        /// that identifies the item with an AppUserModelID that associates it with a particular process or application.
        /// </summary>
        SHARD_APPIDINFO = 0x00000004,

        /// <summary>
        /// Windows 7 and later.
        /// The pv parameter points to a <see cref="SHARDAPPIDINFOIDLIST"/> structure that pairs an absolute PIDL
        /// that identifies the item with an AppUserModelID that associates it with a particular process or application.
        /// </summary>
        SHARD_APPIDINFOIDLIST = 0x00000005,

        /// <summary>
        /// Windows 7 and later.
        /// The pv parameter is an interface pointer to an <see cref="IShellLink"/> object.
        /// </summary>
        SHARD_LINK = 0x00000006,

        /// <summary>
        /// Windows 7 and later.
        /// The pv parameter points to a <see cref="SHARDAPPIDINFOLINK"/> structure that pairs an <see cref="IShellLink"/>
        /// that identifies the item with an AppUserModelID that associates it with a particular process or application.
        /// </summary>
        SHARD_APPIDINFOLINK = 0x00000007,

        /// <summary>
        /// Windows 7 and later.
        /// The pv parameter is an interface pointer to an <see cref="IShellItem"/> object.
        /// </summary>
        SHARD_SHELLITEM = 0x00000008,
    }
}
