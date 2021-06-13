using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Shell32;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// CSIDL (constant special item ID list) values provide a unique system-independent way
    /// to identify special folders used frequently by applications, but which may not have the same name or location on any given system.
    /// For example, the system folder may be "C:\Windows" on one system and "C:\Winnt" on another.
    /// These constants are defined in Shlobj.h.
    /// As of Windows Vista, these values have been replaced by <see cref="KNOWNFOLDERID"/> values.
    /// See that topic for a list of the new constants and their corresponding <see cref="CSIDL"/> values.
    /// For convenience, corresponding <see cref="KNOWNFOLDERID"/> values are also noted here for each <see cref="CSIDL"/> value.
    /// The <see cref="CSIDL"/> system is supported under Windows Vista for compatibility reasons.
    /// However, new development should use <see cref="KNOWNFOLDERID"/> values rather than <see cref="CSIDL"/> values.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/shell/csidl"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// These values supersede the use of environment variables for this purpose. 
    /// They are in turn superseded in Windows Vista and later by the <see cref="KNOWNFOLDERID"/> values.
    /// A <see cref="CSIDL"/> is used in conjunction with one of four Shell functions, <see cref="SHGetFolderLocation"/>,
    /// <see cref="SHGetFolderPath"/>, <see cref="SHGetSpecialFolderLocation"/>, and <see cref="SHGetSpecialFolderPath"/>,
    /// to retrieve a special folder's path or pointer to an item identifier list (PIDL).
    /// Combine <see cref="CSIDL_FLAG_CREATE"/> with any of the other CSIDLs,
    /// except for <see cref="CSIDL_FLAG_DONT_VERIFY"/>, to force the creation of the associated folder.
    /// The remaining CSIDLs correspond to either file system folders or virtual folders.
    /// Where the CSIDL identifies a file system folder, a commonly used path is given as an example. Other paths may be used.
    /// Some CSIDLs can be mapped to an equivalent %VariableName% environment variable.
    /// CSIDLs are more reliable, however, and should be used if possible.
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct CSIDL
    {
        /// <summary>
        /// Version 5.0.
        /// The file system directory that is used to store administrative tools for an individual user.
        /// The MMC will save customized consoles to this directory, and it will roam with the user.
        /// </summary>
        public static CSIDL CSIDL_ADMINTOOLS = new CSIDL { _value = 0x0030 };

        /// <summary>
        /// The file system directory that corresponds to the user's nonlocalized Startup program group.
        /// This value is recognized in Windows Vista for backward compatibility, but the folder itself no longer exists.
        /// </summary>
        public static CSIDL CSIDL_ALTSTARTUP = new CSIDL { _value = 0x001d };

        /// <summary>
        /// Version 4.71.
        /// The file system directory that serves as a common repository for application-specific data.
        /// A typical path is C:\Documents and Settings\username\Application Data.
        /// </summary>
        public static CSIDL CSIDL_APPDATA = new CSIDL { _value = 0x001a };

        /// <summary>
        /// The virtual folder that contains the objects in the user's Recycle Bin.
        /// </summary>
        public static CSIDL CSIDL_BITBUCKET = new CSIDL { _value = 0x000a };

        /// <summary>
        /// Version 6.0.
        /// The file system directory that acts as a staging area for files waiting to be written to a CD.
        /// A typical path is C:\Documents and Settings\username\Local Settings\Application Data\Microsoft\CD Burning.
        /// </summary>
        public static CSIDL CSIDL_CDBURN_AREA = new CSIDL { _value = 0x003b };

        /// <summary>
        /// Version 5.0.
        /// The file system directory that contains administrative tools for all users of the computer.
        /// </summary>
        public static CSIDL CSIDL_COMMON_ADMINTOOLS = new CSIDL { _value = 0x003b };

        /// <summary>
        /// The file system directory that corresponds to the nonlocalized Startup program group for all users.
        /// This value is recognized in Windows Vista for backward compatibility, but the folder itself no longer exists.
        /// </summary>
        public static CSIDL CSIDL_COMMON_ALTSTARTUP = new CSIDL { _value = 0x001e };

        /// <summary>
        /// Version 5.0.
        /// The file system directory that contains application data for all users.
        /// A typical path is C:\Documents and Settings\All Users\Application Data.
        /// This folder is used for application data that is not user specific.
        /// For example, an application can store a spell-check dictionary,
        /// a database of clip art, or a log file in the <see cref="CSIDL_COMMON_APPDATA"/> folder.
        /// This information will not roam and is available to anyone using the computer.
        /// </summary>
        public static CSIDL CSIDL_COMMON_APPDATA = new CSIDL { _value = 0x0023 };

        /// <summary>
        /// The file system directory that contains files and folders that appear on the desktop for all users.
        /// A typical path is C:\Documents and Settings\All Users\Desktop. 
        /// </summary>
        public static CSIDL CSIDL_COMMON_DESKTOPDIRECTORY = new CSIDL { _value = 0x0019 };

        /// <summary>
        /// The file system directory that contains documents that are common to all users.
        /// A typical path is C:\Documents and Settings\All Users\Documents.
        /// </summary>
        public static CSIDL CSIDL_COMMON_DOCUMENTS = new CSIDL { _value = 0x002e };

        /// <summary>
        /// The file system directory that serves as a common repository for favorite items common to all users.
        /// </summary>
        public static CSIDL CSIDL_COMMON_FAVORITES = new CSIDL { _value = 0x001f };

        /// <summary>
        /// Version 6.0.
        /// The file system directory that serves as a repository for music files common to all users.
        /// A typical path is C:\Documents and Settings\All Users\Documents\My Music.
        /// </summary>
        public static CSIDL CSIDL_COMMON_MUSIC = new CSIDL { _value = 0x0035 };

        /// <summary>
        /// This value is recognized in Windows Vista for backward compatibility, but the folder itself is no longer used.
        /// </summary>
        public static CSIDL CSIDL_COMMON_OEM_LINKS = new CSIDL { _value = 0x003a };

        /// <summary>
        /// Version 6.0.
        /// The file system directory that serves as a repository for image files common to all users.
        /// A typical path is C:\Documents and Settings\All Users\Documents\My Pictures.
        /// </summary>
        public static CSIDL CSIDL_COMMON_PICTURES = new CSIDL { _value = 0x0036 };

        /// <summary>
        /// The file system directory that contains the directories for the common program groups that appear on the Start menu for all users.
        /// A typical path is C:\Documents and Settings\All Users\Start Menu\Programs.
        /// </summary>
        public static CSIDL CSIDL_COMMON_PROGRAMS = new CSIDL { _value = 0x0017 };

        /// <summary>
        /// The file system directory that contains the programs and folders that appear on the Start menu for all users.
        /// A typical path is C:\Documents and Settings\All Users\Start Menu.
        /// </summary>
        public static CSIDL CSIDL_COMMON_STARTMENU = new CSIDL { _value = 0x0016 };

        /// <summary>
        /// The file system directory that contains the programs that appear in the Startup folder for all users.
        /// A typical path is C:\Documents and Settings\All Users\Start Menu\Programs\Startup.
        /// </summary>
        public static CSIDL CSIDL_COMMON_STARTUP = new CSIDL { _value = 0x0018 };

        /// <summary>
        /// The file system directory that contains the templates that are available to all users.
        /// A typical path is C:\Documents and Settings\All Users\Templates.
        /// </summary>
        public static CSIDL CSIDL_COMMON_TEMPLATES = new CSIDL { _value = 0x002d };

        /// <summary>
        /// Version 6.0.
        /// The file system directory that serves as a repository for video files common to all users.
        /// A typical path is C:\Documents and Settings\All Users\Documents\My Videos.
        /// </summary>
        public static CSIDL CSIDL_COMMON_VIDEO = new CSIDL { _value = 0x0037 };

        /// <summary>
        /// The folder that represents other computers in your workgroup.
        /// </summary>
        public static CSIDL CSIDL_COMPUTERSNEARME = new CSIDL { _value = 0x003d };

        /// <summary>
        /// The virtual folder that represents Network Connections, that contains network and dial-up connections.
        /// </summary>
        public static CSIDL CSIDL_CONNECTIONS = new CSIDL { _value = 0x0031 };

        /// <summary>
        /// The virtual folder that contains icons for the Control Panel applications.
        /// </summary>
        public static CSIDL CSIDL_CONTROLS = new CSIDL { _value = 0x0003 };

        /// <summary>
        /// The file system directory that serves as a common repository for Internet cookies.
        /// A typical path is C:\Documents and Settings\username\Cookies.
        /// </summary>
        public static CSIDL CSIDL_COOKIES = new CSIDL { _value = 0x0021 };

        /// <summary>
        /// The virtual folder that represents the Windows desktop, the root of the namespace.
        /// </summary>
        public static CSIDL CSIDL_DESKTOP = new CSIDL { _value = 0x0000 };

        /// <summary>
        /// The file system directory used to physically store file objects on the desktop (not to be confused with the desktop folder itself).
        /// A typical path is C:\Documents and Settings\username\Desktop.
        /// </summary>
        public static CSIDL CSIDL_DESKTOPDIRECTORY = new CSIDL { _value = 0x0010 };

        /// <summary>
        /// The virtual folder that represents My Computer,
        /// containing everything on the local computer: storage devices, printers, and Control Panel.
        /// The folder can also contain mapped network drives.
        /// </summary>
        public static CSIDL CSIDL_DRIVES = new CSIDL { _value = 0x0011 };

        /// <summary>
        /// The file system directory that serves as a common repository for the user's favorite items.
        /// A typical path is C:\Documents and Settings\username\Favorites.
        /// </summary>
        public static CSIDL CSIDL_FAVORITES = new CSIDL { _value = 0x0006 };

        /// <summary>
        /// A virtual folder that contains fonts. A typical path is C:\Windows\Fonts.
        /// </summary>
        public static CSIDL CSIDL_FONTS = new CSIDL { _value = 0x0014 };

        /// <summary>
        /// The file system directory that serves as a common repository for Internet history items.
        /// </summary>
        public static CSIDL CSIDL_HISTORY = new CSIDL { _value = 0x0022 };

        /// <summary>
        /// A virtual folder for Internet Explorer. 
        /// </summary>
        public static CSIDL CSIDL_INTERNET = new CSIDL { _value = 0x0001 };

        /// <summary>
        /// Version 4.72.
        /// The file system directory that serves as a common repository for temporary Internet files.
        /// A typical path is C:\Documents and Settings\username\Local Settings\Temporary Internet Files.
        /// </summary>
        public static CSIDL CSIDL_INTERNET_CACHE = new CSIDL { _value = 0x0020 };

        /// <summary>
        /// Version 5.0.
        /// The file system directory that serves as a data repository for local (nonroaming) applications.
        /// A typical path is C:\Documents and Settings\username\Local Settings\Application Data.
        /// </summary>
        public static CSIDL CSIDL_LOCAL_APPDATA = new CSIDL { _value = 0x001c };

        /// <summary>
        /// Version 6.0.
        /// The virtual folder that represents the My Documents desktop item.
        /// This value is equivalent to <see cref="CSIDL_PERSONAL"/>
        /// </summary>
        public static CSIDL CSIDL_MYDOCUMENTS = CSIDL_PERSONAL;

        /// <summary>
        /// The file system directory that serves as a common repository for music files.
        /// A typical path is C:\Documents and Settings\User\My Documents\My Music.
        /// </summary>
        public static CSIDL CSIDL_MYMUSIC = new CSIDL { _value = 0x000d };

        /// <summary>
        /// Version 5.0. The file system directory that serves as a common repository for image files.
        /// A typical path is C:\Documents and Settings\username\My Documents\My Pictures.
        /// </summary>
        public static CSIDL CSIDL_MYPICTURES = new CSIDL { _value = 0x0027 };

        /// <summary>
        /// Version 6.0.
        /// The file system directory that serves as a common repository for video files.
        /// A typical path is C:\Documents and Settings\username\My Documents\My Videos.
        /// </summary>
        public static CSIDL CSIDL_MYVIDEO = new CSIDL { _value = 0x000e };

        /// <summary>
        /// A file system directory that contains the link objects that may exist in the My Network Places virtual folder.
        /// It is not the same as <see cref="CSIDL_NETWORK"/>, which represents the network namespace root.
        /// A typical path is C:\Documents and Settings\username\NetHood.
        /// </summary>
        public static CSIDL CSIDL_NETHOOD = new CSIDL { _value = 0x0013 };

        /// <summary>
        /// A virtual folder that represents Network Neighborhood, the root of the network namespace hierarchy.
        /// </summary>
        public static CSIDL CSIDL_NETWORK = new CSIDL { _value = 0x0012 };

        /// <summary>
        /// Version 6.0.
        /// The virtual folder that represents the My Documents desktop item. This is equivalent to <see cref="CSIDL_MYDOCUMENTS"/>.
        /// Previous to Version 6.0.
        /// The file system directory used to physically store a user's common repository of documents.
        /// A typical path is C:\Documents and Settings\username\My Documents.
        /// This should be distinguished from the virtual My Documents folder in the namespace.
        /// To access that virtual folder, use <see cref="SHGetFolderLocation"/>,
        /// which returns the <see cref="ITEMIDLIST"/> for the virtual location,
        /// or refer to the technique described in Managing the File System.
        /// </summary>
        public static CSIDL CSIDL_PERSONAL = new CSIDL { _value = 0x0005 };

        /// <summary>
        /// The virtual folder that contains installed printers.
        /// </summary>
        public static CSIDL CSIDL_PRINTERS = new CSIDL { _value = 0x0004 };

        /// <summary>
        /// The file system directory that contains the link objects that can exist in the Printers virtual folder.
        /// A typical path is C:\Documents and Settings\username\PrintHood.
        /// </summary>
        public static CSIDL CSIDL_PRINTHOOD = new CSIDL { _value = 0x001b };

        /// <summary>
        /// Version 5.0.
        /// The user's profile folder.
        /// A typical path is C:\Users\username. Applications should not create files or folders at this level;
        /// they should put their data under the locations referred to by <see cref="CSIDL_APPDATA"/> or <see cref="CSIDL_LOCAL_APPDATA"/>.
        /// However, if you are creating a new Known Folder the profile root referred to by <see cref="CSIDL_PROFILE"/> is appropriate.
        /// </summary>
        public static CSIDL CSIDL_PROFILE = new CSIDL { _value = 0x0028 };

        /// <summary>
        /// Version 5.0.
        /// The Program Files folder. A typical path is C:\Program Files.
        /// </summary>
        public static CSIDL CSIDL_PROGRAM_FILES = new CSIDL { _value = 0x0026 };

        /// <summary>
        /// 
        /// </summary>
        public static CSIDL CSIDL_PROGRAM_FILESX86 = new CSIDL { _value = 0x002a };

        /// <summary>
        /// Version 5.0.
        /// A folder for components that are shared across applications.
        /// A typical path is C:\Program Files\Common. Valid only for Windows XP.
        /// </summary>
        public static CSIDL CSIDL_PROGRAM_FILES_COMMON = new CSIDL { _value = 0x002b };

        /// <summary>
        /// 
        /// </summary>
        public static CSIDL CSIDL_PROGRAM_FILES_COMMONX86 = new CSIDL { _value = 0x002c };

        /// <summary>
        /// The file system directory that contains the user's program groups (which are themselves file system directories).
        /// A typical path is C:\Documents and Settings\username\Start Menu\Programs.
        /// </summary>
        public static CSIDL CSIDL_PROGRAMS = new CSIDL { _value = 0x0002 };

        /// <summary>
        /// The file system directory that contains shortcuts to the user's most recently used documents.
        /// A typical path is C:\Documents and Settings\username\My Recent Documents.
        /// To create a shortcut in this folder, use <see cref="SHAddToRecentDocs"/>.
        /// In addition to creating the shortcut, this function updates the Shell's list of recent documents
        /// and adds the shortcut to the My Recent Documents submenu of the Start menu.
        /// </summary>
        public static CSIDL CSIDL_RECENT = new CSIDL { _value = 0x0008 };

        /// <summary>
        /// Windows Vista. The file system directory that contains resource data. A typical path is C:\Windows\Resources. 
        /// </summary>
        public static CSIDL CSIDL_RESOURCES = new CSIDL { _value = 0x0038 };

        /// <summary>
        /// 
        /// </summary>
        public static CSIDL CSIDL_RESOURCES_LOCALIZED = new CSIDL { _value = 0x0039 };

        /// <summary>
        /// The file system directory that contains Send To menu items.
        /// A typical path is C:\Documents and Settings\username\SendTo.
        /// </summary>
        public static CSIDL CSIDL_SENDTO = new CSIDL { _value = 0x0009 };

        /// <summary>
        /// The file system directory that contains Start menu items.
        /// A typical path is C:\Documents and Settings\username\Start Menu.
        /// </summary>
        public static CSIDL CSIDL_STARTMENU = new CSIDL { _value = 0x000b };

        /// <summary>
        /// The file system directory that corresponds to the user's Startup program group.
        /// The system starts these programs whenever the associated user logs on.
        /// A typical path is C:\Documents and Settings\username\Start Menu\Programs\Startup.
        /// </summary>
        public static CSIDL CSIDL_STARTUP = new CSIDL { _value = 0x0007 };

        /// <summary>
        /// Version 5.0.
        /// The Windows System folder. A typical path is C:\Windows\System32.
        /// </summary>
        public static CSIDL CSIDL_SYSTEM = new CSIDL { _value = 0x0025 };

        /// <summary>
        /// 
        /// </summary>
        public static CSIDL CSIDL_SYSTEMX86 = new CSIDL { _value = 0x0029 };

        /// <summary>
        /// The file system directory that serves as a common repository for document templates.
        /// A typical path is C:\Documents and Settings\username\Templates.
        /// </summary>
        public static CSIDL CSIDL_TEMPLATES = new CSIDL { _value = 0x0015 };

        /// <summary>
        /// Version 5.0.
        /// The Windows directory or SYSROOT.
        /// This corresponds to the %windir% or %SYSTEMROOT% environment variables.
        /// A typical path is C:\Windows.
        /// </summary>
        public static CSIDL CSIDL_WINDOWS = new CSIDL { _value = 0x0024 };

        /// <summary>
        /// Version 5.0.
        /// Combine with another <see cref="CSIDL"/> to force the creation of the associated folder if it does not exist.
        /// </summary>
        public static CSIDL CSIDL_FLAG_CREATE = new CSIDL { _value = 0x8000 };

        /// <summary>
        /// Combine with another CSIDL constant to ensure the expansion of environment variables.
        /// </summary>
        public static CSIDL CSIDL_FLAG_DONT_UNEXPAND = new CSIDL { _value = 0x2000 };

        /// <summary>
        /// Combine with another CSIDL constant, except for <see cref="CSIDL_FLAG_CREATE"/>,
        /// to return an unverified folder path with no attempt to create or initialize the folder.
        /// </summary>
        public static CSIDL CSIDL_FLAG_DONT_VERIFY = new CSIDL { _value = 0x4000 };

        /// <summary>
        /// Combine with another <see cref="CSIDL"/> constant to ensure the retrieval of the true system path for the folder, 
        /// free of any aliased placeholders such as %USERPROFILE%, returned by <see cref="SHGetFolderLocation"/>.
        /// This flag has no effect on paths returned by <see cref="SHGetFolderPath"/>.
        /// </summary>
        public static CSIDL CSIDL_FLAG_NO_ALIAS = new CSIDL { _value = 0x1000 };

        /// <summary>
        /// 
        /// </summary>
        public static CSIDL CSIDL_FLAG_PER_USER_INIT = new CSIDL { _value = 0x0800 };

        /// <summary>
        /// A mask for any valid CSIDL flag value.
        /// </summary>
        public static CSIDL CSIDL_FLAG_MASK = new CSIDL { _value = 0xFF00 };

        [FieldOffset(0)]
        private int _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString("X");

        /// <summary>
        /// Is Succeed
        /// </summary>
        public bool Succeed => _value >= 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator int(CSIDL val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator CSIDL(int val) => new CSIDL { _value = val };
    }
}
