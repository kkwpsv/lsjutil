using Lsj.Util.Win32.BaseTypes;
using static Lsj.Util.Win32.BaseTypes.KNOWNFOLDERID;
using static Lsj.Util.Win32.Shell32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Specify special retrieval options for known folders.
    /// These values supersede <see cref="CSIDL"/> values, which have parallel meanings.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/shlobj_core/ne-shlobj_core-known_folder_flag"/>
    /// </para>
    /// </summary>
    public enum KNOWN_FOLDER_FLAG : uint
    {
        /// <summary>
        /// No flags.
        /// </summary>
        KF_FLAG_DEFAULT = 0x00000000,

        /// <summary>
        /// Introduced in Windows 10, version 1709. When called from a packaged app,
        /// LocalAppData/RoamingAppData folders are redirected to private app locations that match the paths
        /// returned from Windows.Storage.ApplicationData.Current{LocalFolderRoamingFolder}.
        /// Other folders are redirected to subdirectories of LocalAppData
        /// This flag is used with <see cref="FOLDERID_AppDataDesktop"/>, <see cref="FOLDERID_AppDataDocuments"/>,
        /// <see cref="FOLDERID_AppDataFavorites"/>, and <see cref="FOLDERID_AppDataProgramData"/>.
        /// It is also intended for compatibility with .NET applications, and not meant to be used directly from an application.
        /// </summary>
        KF_FLAG_FORCE_APP_DATA_REDIRECTION = 0x00080000,


        /// <summary>
        /// Introduced in Windows 10, version 1703.
        /// When running in a Desktop Bridge process, some file system locations are redirected to package-specific locations by the file system.
        /// This flag will cause the target of the direction to be returned for those locations.
        /// This is useful in cases where the real location within the file system needs to be known.
        /// </summary>
        KF_FLAG_RETURN_FILTER_REDIRECTION_TARGET = 0x00040000,

        /// <summary>
        /// Introduced in Windows 10, version 1703.
        /// When running inside an AppContainer process, or when providing an AppContainer token,
        /// some folders are redirected to AppContainer-specific locations within the package.
        /// This flag will force with redirection for folders that are not normally redirected for the purposes of Desktop Bridge processes,
        /// and can be used for sharing files between UWA and Desktop Bridge apps within the same package.
        /// This flag is functionally identical to KF_FLAG_FORCE_APPCONTAINER_REDIRECTION.
        /// </summary>
        KF_FLAG_FORCE_PACKAGE_REDIRECTION = 0x00020000,

        /// <summary>
        /// Introduced in Windows 10, version 1703.
        /// When running inside a packaged process (such as a Desktop Bridge app or an AppContainer), or when providing a packaged process token,
        /// some folders are redirected to package-specific locations.
        /// This flag disables redirection on locations where it is applied,
        /// and instead returns the path that would be returned were it not running inside a packaged process.
        /// This flag is functionally identical to <see cref="KF_FLAG_NO_APPCONTAINER_REDIRECTION"/>.
        /// </summary>
        KF_FLAG_NO_PACKAGE_REDIRECTION = 0x00010000,

        /// <summary>
        ///  Introduced in Windows 8.
        ///  This flag is functionally identical to <see cref="KF_FLAG_FORCE_PACKAGE_REDIRECTION"/>, and was deprecated in Windows 10, version 1703.
        /// </summary>
        KF_FLAG_FORCE_APPCONTAINER_REDIRECTION = 0x00020000,

        /// <summary>
        /// Introduced in Windows 8.
        /// This flag is functionally identical to <see cref="KF_FLAG_NO_PACKAGE_REDIRECTION"/> and was deprecated in Windows 10, version 1703.
        /// </summary>
        KF_FLAG_NO_APPCONTAINER_REDIRECTION = 0x00010000,

        /// <summary>
        /// Forces the creation of the specified folder if that folder does not already exist.
        /// The security provisions predefined for that folder are applied.
        /// If the folder does not exist and cannot be created, the function returns a failure code and no path is returned.
        /// This value can be used only with the following functions and methods:
        /// <see cref="SHGetKnownFolderPath"/>, <see cref="SHGetKnownFolderIDList"/>, <see cref="IKnownFolder.GetIDList"/>,
        /// <see cref="IKnownFolder.GetPath"/>, <see cref="IKnownFolder.GetShellItem"/>
        /// </summary>
        KF_FLAG_CREATE = 0x00008000,

        /// <summary>
        /// Do not verify the folder's existence before attempting to retrieve the path or IDList.
        /// If this flag is not set, an attempt is made to verify that the folder is truly present at the path.
        /// If that verification fails due to the folder being absent or inaccessible, the function returns a failure code and no path is returned.
        /// If the folder is located on a network, the function might take a longer time to execute. Setting this flag can reduce that lag time.
        /// </summary>
        KF_FLAG_DONT_VERIFY = 0x00004000,

        /// <summary>
        /// Stores the full path in the registry without using environment strings.
        /// If this flag is not set, portions of the path may be represented by environment strings such as %USERPROFILE%.
        /// This flag can only be used with <see cref="SHSetKnownFolderPath"/> and <see cref="IKnownFolder.SetPath"/>.
        /// </summary>
        KF_FLAG_DONT_UNEXPAND = 0x00002000,

        /// <summary>
        /// Gets the true system path for the folder, free of any aliased placeholders such as %USERPROFILE%,
        /// returned by <see cref="SHGetKnownFolderIDList"/> and <see cref="IKnownFolder.GetIDList"/>.
        /// This flag has no effect on paths returned by <see cref="SHGetKnownFolderPath"/> and <see cref="IKnownFolder.GetPath"/>.
        /// By default, known folder retrieval functions and methods return the aliased path if an alias exists.
        /// </summary>
        KF_FLAG_NO_ALIAS = 0x00001000,

        /// <summary>
        /// Initializes the folder using its Desktop.ini settings.
        /// If the folder cannot be initialized, the function returns a failure code and no path is returned.
        /// This flag should always be combined with <see cref="KF_FLAG_CREATE"/>.
        /// If the folder is located on a network, the function might take a longer time to execute.
        /// </summary>
        KF_FLAG_INIT = 0x00000800,

        /// <summary>
        /// Gets the default path for a known folder.
        /// If this flag is not set, the function retrieves the current—and possibly redirected—path of the folder.
        /// The execution of this flag includes a verification of the folder's existence unless <see cref="KF_FLAG_DONT_VERIFY"/> is set.
        /// </summary>
        KF_FLAG_DEFAULT_PATH = 0x00000400,

        /// <summary>
        /// Gets the folder's default path independent of the current location of its parent.
        /// <see cref="KF_FLAG_DEFAULT_PATH"/> must also be set.
        /// </summary>
        KF_FLAG_NOT_PARENT_RELATIVE = 0x00000200,

        /// <summary>
        /// Build a simple IDList (PIDL) This value can be used when you want to retrieve the file system path but do not specify this value
        /// if you are retrieving the localized display name of the folder because it might not resolve correctly.
        /// </summary>
        KF_FLAG_SIMPLE_IDLIST = 0x00000100,

        /// <summary>
        /// Introduced in Windows 7. Return only aliased PIDLs. Do not use the file system path.
        /// </summary>
        KF_FLAG_ALIAS_ONLY = 0x80000000,
    }
}
