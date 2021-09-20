using static Lsj.Util.Win32.BaseTypes.KNOWNFOLDERID;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Value that represent a category by which a folder registered with the Known Folder system can be classified.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/shobjidl_core/ne-shobjidl_core-kf_category"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Note: The user profile root folder (<see cref="FOLDERID_Profile"/>) does not support redirection.
    /// </remarks>
    public enum KF_CATEGORY : uint
    {
        /// <summary>
        /// Virtual folders are not part of the file system, which is to say that they have no path.
        /// For example, Control Panel and Printers are virtual folders.
        /// A number of features such as folder path and redirection do not apply to this category.
        /// </summary>
        KF_CATEGORY_VIRTUAL = 1,

        /// <summary>
        /// Fixed file system folders are not managed by the Shell and are usually given a permanent path when the system is installed.
        /// For example, the Windows and Program Files folders are fixed folders.
        /// A number of features such as redirection do not apply to this category.
        /// </summary>
        KF_CATEGORY_FIXED = 2,

        /// <summary>
        /// Common folders are those file system folders used for sharing data and settings, accessible by all users of a system.
        /// For example, all users share a common Documents folder as well as their per-user Documents folder.
        /// </summary>
        KF_CATEGORY_COMMON = 3,

        /// <summary>
        /// Per-user folders are those stored under each user's profile and accessible only by that user.
        /// For example, %USERPROFILE%\Pictures.
        /// This category of folder usually supports many features including aliasing, redirection and customization.
        /// </summary>
        KF_CATEGORY_PERUSER = 4
    }
}
