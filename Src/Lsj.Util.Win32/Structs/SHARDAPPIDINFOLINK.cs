using Lsj.Util.Win32.ComInterfaces;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.CSIDL;
using static Lsj.Util.Win32.BaseTypes.KNOWNFOLDERID;
using static Lsj.Util.Win32.Shell32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains data used by <see cref="SHAddToRecentDocs"/> to identify both an item,
    /// in this case through an <see cref="IShellLink"/>, and the process that it is associated with.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/shlobj_core/ns-shlobj_core-shardappidinfolink"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="IShellLink"/> instance pointed to by psl must provide the following:
    /// Either a pointer to an item identifier list(PIDL) (<see cref="IShellLink.SetIDList"/>)
    /// or the target path(<see cref="IShellLink.SetPath"/> or <see cref="IShellLink.SetRelativePath"/>)
    /// Command-line arguments(<see cref="IShellLink.SetArguments"/>)
    /// Icon location(<see cref="IShellLink.SetIconLocation"/>)
    /// The display name must be set through the item's System.Title (PKEY_Title) property.
    /// The property can directly hold the display name or it can be an indirect string representation,
    /// such as "@shell32.dll,-1324", to use a stored string.
    /// An indirect string enables the item name to be displayed in the user's selected language.
    /// Optionally, the description field(<see cref="IShellLink.SetDescription"/>) can be set to provide a custom tooltip for the item in the Jump List.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SHARDAPPIDINFOLINK
    {
        /// <summary>
        /// Pointer to an <see cref="IShellLink"/> instance that, when launched, opens the item.
        /// The shortcut is not added by <see cref="SHAddToRecentDocs"/> to the user's Recent folder (<see cref="CSIDL_RECENT"/>,
        /// <see cref="FOLDERID_Recent"/>), but it is added to the Recent category in the specified application's Jump List.
        /// </summary>
        [MarshalAs(UnmanagedType.Interface)]
        public IShellLink psl;

        /// <summary>
        /// The application-defined AppUserModelID associated with the item.
        /// </summary>
        public IntPtr pszAppID;
    }
}
