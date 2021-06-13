﻿using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.CSIDL;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// The <see cref="KNOWNFOLDERID"/> constants represent GUIDs that identify standard folders registered with the system as Known Folders.
    /// These folders are installed with Windows Vista and later operating systems, and a computer will have only folders appropriate to it installed.
    /// For descriptions of these folders, see <see cref="CSIDL"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/shell/knownfolderid"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public struct KNOWNFOLDERID
    {
        /// <summary>
        /// Account Pictures
        /// PERUSER
        /// %APPDATA%\Microsoft\Windows\AccountPictures
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_AccountPictures = new Guid(0x008ca0b1, 0x55b4, 0x4c56, 0xb8, 0xa8, 0x4d, 0xe4, 0xb2, 0x99, 0xd3, 0xbe);

        /// <summary>
        /// Get Programs
        /// VIRTUAL
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_AddNewPrograms = new Guid(0xde61d971, 0x5ebc, 0x4f02, 0xa3, 0xa9, 0x6c, 0x82, 0x89, 0x5e, 0x5c, 0x04);

        /// <summary>
        /// Administrative Tools
        /// PERUSER
        /// %APPDATA%\Microsoft\Windows\Start Menu\Programs\Administrative Tools
        /// <see cref="CSIDL_ADMINTOOLS"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_AdminTools = new Guid(0x724ef170, 0xa42d, 0x4fef, 0x9f, 0x26, 0xb6, 0x0e, 0x84, 0x6f, 0xba, 0x4f);

        /// <summary>
        /// AppDataDesktop
        /// PERUSER
        /// %LOCALAPPDATA%\Desktop
        /// </summary>
        /// <remarks>
        /// This FOLDERID is used internally by .NET applications to enable cross-platform app functionality.
        /// It is not intended to be used directly from an application.
        /// </remarks>
        public static readonly KNOWNFOLDERID FOLDERID_AppDataDesktop = new Guid(0xb2c5e279, 0x7add, 0x439f, 0xb2, 0x8c, 0xc4, 0x1f, 0xe1, 0xbb, 0xf6, 0x72);

        /// <summary>
        /// AppDataDocuments
        /// PERUSER
        /// %LOCALAPPDATA%\Documents
        /// </summary>
        /// <remarks>
        /// This FOLDERID is used internally by .NET applications to enable cross-platform app functionality.
        /// It is not intended to be used directly from an application.
        /// </remarks>
        public static readonly KNOWNFOLDERID FOLDERID_AppDataDocuments = new Guid(0x7be16610, 0x1f7f, 0x44ac, 0xbf, 0xf0, 0x83, 0xe1, 0x5f, 0x2f, 0xfc, 0xa1);

        /// <summary>
        /// AppDataFavorites
        /// PERUSER
        /// %LOCALAPPDATA%\Favorites
        /// </summary>
        /// <remarks>
        /// This FOLDERID is used internally by .NET applications to enable cross-platform app functionality.
        /// It is not intended to be used directly from an application.
        /// </remarks>
        public static readonly KNOWNFOLDERID FOLDERID_AppDataFavorites = new Guid(0x7cfbefbc, 0xde1f, 0x45aa, 0xb8, 0x43, 0xa5, 0x42, 0xac, 0x53, 0x6c, 0xc9);

        /// <summary>
        /// AppDataFavorites
        /// PERUSER
        /// %LOCALAPPDATA%\ProgramData
        /// </summary>
        /// <remarks>
        /// This FOLDERID is used internally by .NET applications to enable cross-platform app functionality.
        /// It is not intended to be used directly from an application.
        /// </remarks>
        public static readonly KNOWNFOLDERID FOLDERID_AppDataProgramData = new Guid(0x559d40a3, 0xa036, 0x40fa, 0xaf, 0x61, 0x84, 0xcb, 0x43, 0x0a, 0x4d, 0x34);

        /// <summary>
        /// Application Shortcuts
        /// PERUSER
        /// %LOCALAPPDATA%\Microsoft\Windows\Application Shortcuts
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_ApplicationShortcuts = new Guid(0xa3918781, 0xe5f2, 0x4890, 0xb3, 0xd9, 0xa7, 0xe5, 0x43, 0x32, 0x32, 0x8c);

        /// <summary>
        /// Applications
        /// VIRTUAL
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_AppsFolder = new Guid(0x1e87508d, 0x89c2, 0x42f0, 0x8a, 0x7e, 0x64, 0x5a, 0x0f, 0x50, 0xca, 0x58);

        /// <summary>
        /// Installed Updates
        /// VIRTUAL
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_AppUpdates = new Guid(0xa305ce99, 0xf527, 0x492b, 0x8b, 0x1a, 0x7e, 0x76, 0xfa, 0x98, 0xd6, 0xe4);

        /// <summary>
        /// Camera Roll
        /// PERUSER
        /// %USERPROFILE%\Pictures\Camera Roll
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_CameraRoll = new Guid(0xab5fb87b, 0x7ce2, 0x4f83, 0x91, 0x5d, 0x55, 0x08, 0x46, 0xc9, 0x53, 0x7b);

        /// <summary>
        /// Temporary Burn Folder
        /// PERUSER
        /// %LOCALAPPDATA%\Microsoft\Windows\Burn\Burn
        /// <see cref="CSIDL_CDBURN_AREA"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_CDBurning = new Guid(0x9e52ab10, 0xf80d, 0x49df, 0xac, 0xb8, 0x43, 0x30, 0xf5, 0x68, 0x78, 0x55);

        /// <summary>
        /// Programs and Features
        /// VIRTUAL
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_ChangeRemovePrograms = new Guid(0xdf7266ac, 0x9274, 0x4867, 0x8d, 0x55, 0x3b, 0xd6, 0x61, 0xde, 0x87, 0x2d);

        /// <summary>
        /// Administrative Tools
        /// COMMON
        /// %ALLUSERSPROFILE%\Microsoft\Windows\Start Menu\Programs\Administrative Tools
        /// <see cref="CSIDL_COMMON_ADMINTOOLS"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_CommonAdminTools = new Guid(0xd0384e7d, 0xbac3, 0x4797, 0x8f, 0x14, 0xcb, 0xa2, 0x29, 0xb3, 0x92, 0xb5);

        /// <summary>
        /// OEM Links
        /// COMMON
        /// %ALLUSERSPROFILE%\OEM Links
        /// <see cref="CSIDL_COMMON_OEM_LINKS"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_CommonOEMLinks = new Guid(0xc1bae2d0, 0x10df, 0x4334, 0xbe, 0xdd, 0x7a, 0xa2, 0x0b, 0x22, 0x7a, 0x9d);

        /// <summary>
        /// Programs
        /// COMMON
        /// %ALLUSERSPROFILE%\Microsoft\Windows\Start Menu\Programs
        /// <see cref="CSIDL_COMMON_PROGRAMS"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_CommonPrograms = new Guid(0x0139d44e, 0x6afe, 0x49f2, 0x86, 0x90, 0x3d, 0xaf, 0xca, 0xe6, 0xff, 0xb8);

        /// <summary>
        /// Start Menu
        /// COMMON
        /// %ALLUSERSPROFILE%\Microsoft\Windows\Start Menu
        /// <see cref="CSIDL_COMMON_STARTMENU"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_CommonStartMenu = new Guid(0xa4115719, 0xd62e, 0x491d, 0xaa, 0x7c, 0xe7, 0x4b, 0x8b, 0xe3, 0xb0, 0x67);

        /// <summary>
        /// Startup
        /// COMMON
        /// %ALLUSERSPROFILE%\Microsoft\Windows\Start Menu\Programs\StartUp
        /// <see cref="CSIDL_COMMON_STARTUP"/>, <see cref="CSIDL_COMMON_ALTSTARTUP"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_CommonStartup = new Guid(0x82a5ea35, 0xd9cd, 0x47c5, 0x96, 0x29, 0xe1, 0x5d, 0x2f, 0x71, 0x4e, 0x6e);

        /// <summary>
        /// Templates
        /// COMMON
        /// %ALLUSERSPROFILE%\Microsoft\Windows\Templates
        /// <see cref="CSIDL_COMMON_TEMPLATES"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_CommonTemplates = new Guid(0xb94237e7, 0x57ac, 0x4347, 0x91, 0x51, 0xb0, 0x8c, 0x6c, 0x32, 0xd1, 0xf7);

        /// <summary>
        /// Computer
        /// VIRTUAL
        /// <see cref="CSIDL_DRIVES"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_ComputerFolder = new Guid(0x0ac0837c, 0xbbf8, 0x452a, 0x85, 0x0d, 0x79, 0xd0, 0x8e, 0x66, 0x7c, 0xa7);

        /// <summary>
        /// Conflicts
        /// VIRTUAL
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_ConflictFolder = new Guid(0x4bfefb45, 0x347d, 0x4006, 0xa5, 0xbe, 0xac, 0x0c, 0xb0, 0x56, 0x71, 0x92);

        /// <summary>
        /// Network Connections
        /// VIRTUAL
        /// <see cref="CSIDL_CONNECTIONS"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_ConnectionsFolder = new Guid(0x6f0cd92b, 0x2e97, 0x45d1, 0x88, 0xff, 0xb0, 0xd1, 0x86, 0xb8, 0xde, 0xdd);

        /// <summary>
        /// Contacts
        /// PERUSER
        /// %USERPROFILE%\Contacts
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_Contacts = new Guid(0x56784854, 0xc6cb, 0x462b, 0x81, 0x69, 0x88, 0xe3, 0x50, 0xac, 0xb8, 0x82);

        /// <summary>
        /// Control Panel
        /// VIRTUAL
        /// <see cref="CSIDL_CONTROLS"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_ControlPanelFolder = new Guid(0x82a74aeb, 0xaeb4, 0x465c, 0xa0, 0x14, 0xd0, 0x97, 0xee, 0x34, 0x6d, 0x63);

        /// <summary>
        /// Cookies
        /// PERUSER
        /// %APPDATA%\Microsoft\Windows\Cookies
        /// <see cref="CSIDL_COOKIES"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_Cookies = new Guid(0x2b0f765d, 0xc0e9, 0x4171, 0x90, 0x8e, 0x08, 0xa6, 0x11, 0xb8, 0x4f, 0xf6);

        /// <summary>
        /// Desktop
        /// PERUSER
        /// %USERPROFILE%\Desktop
        /// <see cref="CSIDL_DESKTOP"/>, <see cref="CSIDL_DESKTOPDIRECTORY"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_Desktop = new Guid(0xb4bfcc3a, 0xdb2c, 0x424c, 0xb0, 0x29, 0x7f, 0xe9, 0x9a, 0x87, 0xc6, 0x41);

        /// <summary>
        /// DeviceMetadataStore
        /// COMMON
        /// %ALLUSERSPROFILE%\Microsoft\Windows\DeviceMetadataStore
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_DeviceMetadataStore = new Guid(0x5ce4a5e9, 0xe4eb, 0x479d, 0xb8, 0x9f, 0x13, 0x0c, 0x02, 0x88, 0x61, 0x55);

        /// <summary>
        /// Documents
        /// PERUSER
        /// %USERPROFILE%\Documents
        /// <see cref="CSIDL_MYDOCUMENTS"/>, <see cref="CSIDL_PERSONAL"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_Documents = new Guid(0xfdd39ad0, 0x238f, 0x46af, 0xad, 0xb4, 0x6c, 0x85, 0x48, 0x03, 0x69, 0xc7);

        /// <summary>
        /// Documents
        /// PERUSER
        /// %APPDATA%\Microsoft\Windows\Libraries\Documents.library-ms
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_DocumentsLibrary = new Guid(0x7b0db17d, 0x9cd2, 0x4a93, 0x97, 0x33, 0x46, 0xcc, 0x89, 0x02, 0x2e, 0x7c);

        /// <summary>
        /// Downloads
        /// PERUSER
        /// %USERPROFILE%\Downloads
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_Downloads = new Guid(0x374de290, 0x123f, 0x4565, 0x91, 0x64, 0x39, 0xc4, 0x92, 0x5e, 0x46, 0x7b);

        /// <summary>
        /// Favorites
        /// PERUSER
        /// %USERPROFILE%\Favorites
        /// <see cref="CSIDL_FAVORITES"/>, <see cref="CSIDL_COMMON_FAVORITES"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_Favorites = new Guid(0x1777f761, 0x68ad, 0x4d8a, 0x87, 0xbd, 0x30, 0xb7, 0x59, 0xfa, 0x33, 0xdd);

        /// <summary>
        /// Fonts
        /// FIXED
        /// %windir%\Fonts
        /// <see cref="CSIDL_FONTS"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_Fonts = new Guid(0xfd228cb7, 0xae11, 0x4ae3, 0x86, 0x4c, 0x16, 0xf3, 0x91, 0x0a, 0xb8, 0xfe);

        /// <summary>
        /// Games
        /// VIRTUAL
        /// </summary>
        [Obsolete("This FOLDERID is deprecated in Windows 10, version 1803 and later versions." +
            " In these versions, it returns 0x80070057 - E_INVALIDARG")]
        public static readonly KNOWNFOLDERID FOLDERID_Games = new Guid(0xcac52c1a, 0xb53d, 0x4edc, 0x92, 0xd7, 0x6b, 0x2e, 0x8a, 0xc1, 0x94, 0x34);

        /// <summary>
        /// GameExplorer
        /// PERUSER
        /// %LOCALAPPDATA%\Microsoft\Windows\GameExplorer
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_GameTasks = new Guid(0x054fae61, 0x4dd8, 0x4787, 0x80, 0xb6, 0x09, 0x02, 0x20, 0xc4, 0xb7, 0x00);

        /// <summary>
        /// History
        /// PERUSER
        /// %LOCALAPPDATA%\Microsoft\Windows\History
        /// <see cref="CSIDL_HISTORY"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_History = new Guid(0xd9dc8a3b, 0xb784, 0x432e, 0xa7, 0x81, 0x5a, 0x11, 0x30, 0xa7, 0x59, 0x63);

        /// <summary>
        /// Homegroup
        /// VIRTUAL
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_HomeGroup = new Guid(0x52528a6b, 0xb9e3, 0x4add, 0xb6, 0x0d, 0x58, 0x8c, 0x2d, 0xba, 0x84, 0x2d);

        /// <summary>
        /// The user's username (%USERNAME%)
        /// VIRTUAL
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_HomeGroupCurrentUser = new Guid(0x9b74b6a3, 0x0dfd, 0x4f11, 0x9e, 0x78, 0x5f, 0x78, 0x00, 0xf2, 0xe7, 0x72);

        /// <summary>
        /// ImplicitAppShortcuts
        /// PERUSER
        /// %APPDATA%\Microsoft\Internet Explorer\Quick Launch\User Pinned\ImplicitAppShortcuts
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_ImplicitAppShortcuts = new Guid(0xbcb5256f, 0x79f6, 0x4cee, 0xb7, 0x25, 0xdc, 0x34, 0xe4, 0x02, 0xfd, 0x46);

        /// <summary>
        /// Temporary Internet Files
        /// PERUSER
        /// %LOCALAPPDATA%\Microsoft\Windows\Temporary Internet Files
        /// <see cref="CSIDL_INTERNET_CACHE"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_InternetCache = new Guid(0x352481e8, 0x33be, 0x4251, 0xba, 0x85, 0x60, 0x07, 0xca, 0xed, 0xcf, 0x9d);

        /// <summary>
        /// The Internet
        /// VIRTUAL
        /// <see cref="CSIDL_INTERNET"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_InternetFolder = new Guid(0x4d9f7874, 0x4e0c, 0x4904, 0x96, 0x7b, 0x40, 0xb0, 0xd2, 0x0c, 0x3e, 0x4b);

        /// <summary>
        /// Libraries
        /// PERUSER
        /// %APPDATA%\Microsoft\Windows\Libraries
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_Libraries = new Guid(0x1b3ea5dc, 0xb587, 0x4786, 0xb4, 0xef, 0xbd, 0x1d, 0xc3, 0x32, 0xae, 0xae);

        /// <summary>
        /// Links
        /// PERUSER
        /// %USERPROFILE%\Links
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_Links = new Guid(0xbfb9d5e0, 0xc6a9, 0x404c, 0xb2, 0xb2, 0xae, 0x6d, 0xb6, 0xaf, 0x49, 0x68);

        /// <summary>
        /// Local
        /// PERUSER
        /// %LOCALAPPDATA% (%USERPROFILE%\AppData\Local)
        /// <see cref="CSIDL_LOCAL_APPDATA"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_LocalAppData = new Guid(0xf1b32785, 0x6fba, 0x4fcf, 0x9d, 0x55, 0x7b, 0x8e, 0x7f, 0x15, 0x70, 0x91);

        /// <summary>
        /// LocalLow
        /// PERUSER
        /// %USERPROFILE%\AppData\LocalLow
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_LocalAppDataLow = new Guid(0xa520a1a4, 0x1780, 0x4ff6, 0xbd, 0x18, 0x16, 0x73, 0x43, 0xc5, 0xaf, 0x16);

        /// <summary>
        /// FIXED
        /// %windir%\resources\0409 (code page)
        /// <see cref="CSIDL_RESOURCES_LOCALIZED"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_LocalizedResourcesDir = new Guid(0x2a00375e, 0x224c, 0x49de, 0xb8, 0xd1, 0x44, 0x0d, 0xf7, 0xef, 0x3d, 0xdc);

        /// <summary>
        /// Music
        /// PERUSER
        /// %USERPROFILE%\Music
        /// <see cref="CSIDL_MYMUSIC"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_Music = new Guid(0x4bd8d571, 0x6d19, 0x48d3, 0xbe, 0x97, 0x42, 0x22, 0x20, 0x08, 0x0e, 0x43);

        /// <summary>
        /// Music
        /// PERUSER
        /// %APPDATA%\Microsoft\Windows\Libraries\Music.library-ms
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_MusicLibrary = new Guid(0x2112ab0a, 0xc86a, 0x4ffe, 0xa3, 0x68, 0x0d, 0xe9, 0x6e, 0x47, 0x01, 0x2e);

        /// <summary>
        /// Network Shortcuts
        /// PERUSER
        /// %APPDATA%\Microsoft\Windows\Network Shortcuts
        /// <see cref="CSIDL_NETHOOD"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_NetHood = new Guid(0xc5abbf53, 0xe17f, 0x4121, 0x89, 0x00, 0x86, 0x62, 0x6f, 0xc2, 0xc9, 0x73);

        /// <summary>
        /// Network
        /// VIRTUAL
        /// <see cref="CSIDL_NETWORK"/>, <see cref="CSIDL_COMPUTERSNEARME"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_NetworkFolder = new Guid(0xd20beec4, 0x5ca8, 0x4905, 0xae, 0x3b, 0xbf, 0x25, 0x1e, 0xa0, 0x9b, 0x53);

        /// <summary>
        /// 3D Objects
        /// PERUSER
        /// %USERPROFILE%\3D Objects
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_Objects3D = new Guid(0x31c0dd25, 0x9439, 0x4f12, 0xbf, 0x41, 0x7f, 0xf4, 0xed, 0xa3, 0x87, 0x22);

        /// <summary>
        /// Original Images
        /// PERUSER
        /// %LOCALAPPDATA%\Microsoft\Windows Photo Gallery\Original Images
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_OriginalImages = new Guid(0x2c36c0aa, 0x5812, 0x4b87, 0xbf, 0xd0, 0x4c, 0xd0, 0xdf, 0xb1, 0x9b, 0x39);

        /// <summary>
        /// Slide Shows
        /// PERUSER
        /// %USERPROFILE%\Pictures\Slide Shows
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_PhotoAlbums = new Guid(0x69d2cf90, 0xfc33, 0x4fb7, 0x9a, 0x0c, 0xeb, 0xb0, 0xf0, 0xfc, 0xb4, 0x3c);

        /// <summary>
        /// Pictures
        /// PERUSER
        /// %APPDATA%\Microsoft\Windows\Libraries\Pictures.library-ms
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_PicturesLibrary = new Guid(0xa990ae9f, 0xa03b, 0x4e80, 0x94, 0xbc, 0x99, 0x12, 0xd7, 0x50, 0x41, 0x04);

        /// <summary>
        /// Pictures
        /// PERUSER
        /// %USERPROFILE%\Pictures
        /// <see cref="CSIDL_MYPICTURES"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_Pictures = new Guid(0x33e28130, 0x4e1e, 0x4676, 0x83, 0x5a, 0x98, 0x39, 0x5c, 0x3b, 0xc3, 0xbb);

        /// <summary>
        /// Playlists
        /// PERUSER
        /// %USERPROFILE%\Music\Playlists
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_Playlists = new Guid(0xde92c1c7, 0x837f, 0x4f69, 0xa3, 0xbb, 0x86, 0xe6, 0x31, 0x20, 0x4a, 0x23);

        /// <summary>
        /// Printers
        /// VIRTUAL
        /// <see cref="CSIDL_PRINTERS"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_PrintersFolder = new Guid(0x76fc4e2d, 0xd6ad, 0x4519, 0xa6, 0x63, 0x37, 0xbd, 0x56, 0x06, 0x81, 0x85);

        /// <summary>
        /// Printer Shortcuts
        /// PERUSER
        /// %APPDATA%\Microsoft\Windows\Printer Shortcuts
        /// <see cref="CSIDL_PRINTHOOD"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_PrintHood = new Guid(0x9274bd8d, 0xcfd1, 0x41c3, 0xb3, 0x5e, 0xb1, 0x3f, 0x55, 0xa7, 0x58, 0xf4);

        /// <summary>
        /// The user's username (%USERNAME%)
        /// FIXED
        /// %USERPROFILE% (%SystemDrive%\Users\%USERNAME%)
        /// <see cref="CSIDL_PROFILE"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_Profile = new Guid(0x5e6c858f, 0x0e22, 0x4760, 0x9a, 0xfe, 0xea, 0x33, 0x17, 0xb6, 0x71, 0x73);

        /// <summary>
        /// ProgramData
        /// FIXED
        /// %ALLUSERSPROFILE% (%ProgramData%, %SystemDrive%\ProgramData)
        /// <see cref="CSIDL_COMMON_APPDATA"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_ProgramData = new Guid(0x62ab5d82, 0xfdc1, 0x4dc3, 0xa9, 0xdd, 0x07, 0x0d, 0x1d, 0x49, 0x5d, 0x97);

        /// <summary>
        /// Program Files
        /// FIXED
        /// %ProgramFiles% (%SystemDrive%\Program Files)
        /// <see cref="CSIDL_PROGRAM_FILES"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_ProgramFiles = new Guid(0x905e63b6, 0xc1bf, 0x494e, 0xb2, 0x9c, 0x65, 0xb7, 0x32, 0xd3, 0xd2, 0x1a);

        /// <summary>
        /// Program Files
        /// FIXED
        /// %ProgramFiles% (%SystemDrive%\Program Files)
        /// </summary>
        /// <remarks>
        /// This value is not supported on 32-bit operating systems.
        /// It also is not supported for 32-bit applications running on 64-bit operating systems.
        /// Attempting to use <see cref="FOLDERID_ProgramFilesX64"/> in either situation results in an error.
        /// </remarks>
        public static readonly KNOWNFOLDERID FOLDERID_ProgramFilesX64 = new Guid(0x6d809377, 0x6af0, 0x444b, 0x89, 0x57, 0xa3, 0x77, 0x3f, 0x02, 0x20, 0x0e);

        /// <summary>
        /// Program Files
        /// FIXED
        /// %ProgramFiles% (%SystemDrive%\Program Files)
        /// <see cref="CSIDL_PROGRAM_FILESX86"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_ProgramFilesX86 = new Guid(0x7c5a40ef, 0xa0fb, 0x4bfc, 0x87, 0x4a, 0xc0, 0xf2, 0xe0, 0xb9, 0xfa, 0x8e);

        /// <summary>
        /// Common Files
        /// FIXED
        /// %ProgramFiles%\Common Files
        /// <see cref="CSIDL_PROGRAM_FILES_COMMON"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_ProgramFilesCommon = new Guid(0xf7f1ed05, 0x9f6d, 0x47a2, 0xaa, 0xae, 0x29, 0xd3, 0x17, 0xc6, 0xf0, 0x66);

        /// <summary>
        /// Common Files
        /// FIXED
        /// %ProgramFiles%\Common Files
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_ProgramFilesCommonX64 = new Guid(0x6365d5a7, 0x0f0d, 0x45e5, 0x87, 0xf6, 0x0d, 0xa5, 0x6b, 0x6a, 0x4f, 0x7d);

        /// <summary>
        /// Common Files
        /// FIXED
        /// %ProgramFiles%\Common Files
        /// <see cref="CSIDL_PROGRAM_FILES_COMMONX86"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_ProgramFilesCommonX86 = new Guid(0xde974d24, 0xd9c6, 0x4d3e, 0xbf, 0x91, 0xf4, 0x45, 0x51, 0x20, 0xb9, 0x17);

        /// <summary>
        /// Programs
        /// PERUSER
        /// %APPDATA%\Microsoft\Windows\Start Menu\Programs
        /// <see cref="CSIDL_PROGRAMS"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_Programs = new Guid(0xa77f5d77, 0x2e2b, 0x44c3, 0xa6, 0xa2, 0xab, 0xa6, 0x01, 0x05, 0x4a, 0x51);

        /// <summary>
        /// Public
        /// FIXED
        /// %PUBLIC% (%SystemDrive%\Users\Public)
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_Public = new Guid(0xdfdf76a2, 0xc82a, 0x4d63, 0x90, 0x6a, 0x56, 0x44, 0xac, 0x45, 0x73, 0x85);

        /// <summary>
        /// Public Desktop
        /// COMMON
        /// %PUBLIC%\Desktop
        /// <see cref="CSIDL_COMMON_DESKTOPDIRECTORY"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_PublicDesktop = new Guid(0xc4aa340d, 0xf20f, 0x4863, 0xaf, 0xef, 0xf8, 0x7e, 0xf2, 0xe6, 0xba, 0x25);

        /// <summary>
        /// Public Documents
        /// COMMON
        /// %PUBLIC%\Documents
        /// <see cref="CSIDL_COMMON_DOCUMENTS"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_PublicDocuments = new Guid(0xed4824af, 0xdce4, 0x45a8, 0x81, 0xe2, 0xfc, 0x79, 0x65, 0x08, 0x36, 0x34);

        /// <summary>
        /// Public Downloads
        /// COMMON
        /// %PUBLIC%\Downloads
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_PublicDownloads = new Guid(0x3d644c9b, 0x1fb8, 0x4f30, 0x9b, 0x45, 0xf6, 0x70, 0x23, 0x5f, 0x79, 0xc0);

        /// <summary>
        /// GameExplorer
        /// COMMON
        /// %ALLUSERSPROFILE%\Microsoft\Windows\GameExplorer
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_PublicGameTasks = new Guid(0xdebf2536, 0xe1a8, 0x4c59, 0xb6, 0xa2, 0x41, 0x45, 0x86, 0x47, 0x6a, 0xea);

        /// <summary>
        /// Libraries
        /// COMMON
        /// %ALLUSERSPROFILE%\Microsoft\Windows\Libraries
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_PublicLibraries = new Guid(0x48daf80b, 0xe6cf, 0x4f4e, 0xb8, 0x00, 0x0e, 0x69, 0xd8, 0x4e, 0xe3, 0x84);

        /// <summary>
        /// Public Music
        /// COMMON
        /// %PUBLIC%\Music
        /// <see cref="CSIDL_COMMON_MUSIC"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_PublicMusic = new Guid(0x3214fab5, 0x9757, 0x4298, 0xbb, 0x61, 0x92, 0xa9, 0xde, 0xaa, 0x44, 0xff);

        /// <summary>
        /// Public Pictures
        /// COMMON
        /// %PUBLIC%\Pictures
        /// <see cref="CSIDL_COMMON_PICTURES"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_PublicPictures = new Guid(0xb6ebfb86, 0x6907, 0x413c, 0x9a, 0xf7, 0x4f, 0xc2, 0xab, 0xf0, 0x7c, 0xc5);

        /// <summary>
        /// Ringtones
        /// COMMON
        /// %ALLUSERSPROFILE%\Microsoft\Windows\Ringtones
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_PublicRingtones = new Guid(0xe555ab60, 0x153b, 0x4d17, 0x9f, 0x04, 0xa5, 0xfe, 0x99, 0xfc, 0x15, 0xec);

        /// <summary>
        /// Public Account Pictures
        /// COMMON
        /// %PUBLIC%\AccountPictures
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_PublicUserTiles = new Guid(0x0482af6c, 0x08f1, 0x4c34, 0x8c, 0x90, 0xe1, 0x7e, 0xc9, 0x8b, 0x1e, 0x17);

        /// <summary>
        /// Public Videos
        /// COMMON
        /// %PUBLIC%\Videos
        /// <see cref="CSIDL_COMMON_VIDEO"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_PublicVideos = new Guid(0x2400183a, 0x6185, 0x49fb, 0xa2, 0xd8, 0x4a, 0x39, 0x2a, 0x60, 0x2b, 0xa3);

        /// <summary>
        /// Quick Launch
        /// COMMON
        /// %APPDATA%\Microsoft\Internet Explorer\Quick Launch
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_QuickLaunch = new Guid(0x52a4f021, 0x7b75, 0x48a9, 0x9f, 0x6b, 0x4b, 0x87, 0xa2, 0x10, 0xbc, 0x8f);

        /// <summary>
        /// Recent Items
        /// COMMON
        /// %APPDATA%\Microsoft\Windows\Recent
        /// <see cref="CSIDL_RECENT"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_Recent = new Guid(0xae50c081, 0xebd2, 0x438a, 0x86, 0x55, 0x8a, 0x09, 0x2e, 0x34, 0x98, 0x7a);

        /// <summary>
        /// Recorded TV
        /// COMMON
        /// %PUBLIC%\RecordedTV.library-ms
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_RecordedTVLibrary = new Guid(0x1a6fdba2, 0xf42d, 0x4358, 0xa7, 0x98, 0xb7, 0x4d, 0x74, 0x59, 0x26, 0xc5);

        /// <summary>
        /// Recycle Bin
        /// VIRTUAL
        /// <see cref="CSIDL_BITBUCKET"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_RecycleBinFolder = new Guid(0xb7534046, 0x3ecb, 0x4c18, 0xbe, 0x4e, 0x64, 0xcd, 0x4c, 0xb7, 0xd6, 0xac);

        /// <summary>
        /// Resources
        /// FIXED
        /// %windir%\Resources
        /// <see cref="CSIDL_RESOURCES"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_ResourceDir = new Guid(0x8ad10c31, 0x2adb, 0x4296, 0xa8, 0xf7, 0xe4, 0x70, 0x12, 0x32, 0xc9, 0x72);

        /// <summary>
        /// Ringtones
        /// PERUSER
        /// %LOCALAPPDATA%\Microsoft\Windows\Ringtones
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_Ringtones = new Guid(0xc870044b, 0xf49e, 0x4126, 0xa9, 0xc3, 0xb5, 0x2a, 0x1f, 0xf4, 0x11, 0xe8);

        /// <summary>
        /// Roaming
        /// PERUSER
        /// %APPDATA% (%USERPROFILE%\AppData\Roaming)
        /// <see cref="CSIDL_APPDATA"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_RoamingAppData = new Guid(0x3eb685db, 0x65f9, 0x4cf6, 0xa0, 0x3a, 0xe3, 0xef, 0x65, 0x72, 0x9f, 0x3d);

        /// <summary>
        /// RoamedTileImages
        /// PERUSER
        /// %LOCALAPPDATA%\Microsoft\Windows\RoamedTileImages
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_RoamedTileImages = new Guid(0xaaa8d5a5, 0xf1d6, 0x4259, 0xba, 0xa8, 0x78, 0xe7, 0xef, 0x60, 0x83, 0x5e);

        /// <summary>
        /// RoamingTiles
        /// PERUSER
        /// %LOCALAPPDATA%\Microsoft\Windows\RoamingTiles
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_RoamingTiles = new Guid(0x00bcfc5a, 0xed94, 0x4e48, 0x96, 0xa1, 0x3f, 0x62, 0x17, 0xf2, 0x19, 0x90);

        /// <summary>
        /// Sample Music
        /// COMMON
        /// %PUBLIC%\Music\Sample Music
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_SampleMusic = new Guid(0xb250c668, 0xf57d, 0x4ee1, 0xa6, 0x3c, 0x29, 0x0e, 0xe7, 0xd1, 0xaa, 0x1f);

        /// <summary>
        /// Sample Pictures
        /// COMMON
        /// %PUBLIC%\Pictures\Sample Pictures
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_SamplePictures = new Guid(0xc4900540, 0x2379, 0x4c75, 0x84, 0x4b, 0x64, 0xe6, 0xfa, 0xf8, 0x71, 0x6b);

        /// <summary>
        /// Sample Playlists
        /// COMMON
        /// %PUBLIC%\Music\Sample Playlists
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_SamplePlaylists = new Guid(0x15ca69b3, 0x30ee, 0x49c1, 0xac, 0xe1, 0x6b, 0x5e, 0xc3, 0x72, 0xaf, 0xb5);

        /// <summary>
        /// Sample Videos
        /// COMMON
        /// %PUBLIC%\Videos\Sample Videos
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_SampleVideos = new Guid(0x859ead94, 0x2e85, 0x48ad, 0xa7, 0x1a, 0x09, 0x69, 0xcb, 0x56, 0xa6, 0xcd);

        /// <summary>
        /// Saved Games
        /// PERUSER
        /// %USERPROFILE%\Saved Games
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_SavedGames = new Guid(0x4c5c32ff, 0xbb9d, 0x43b0, 0xb5, 0xb4, 0x2d, 0x72, 0xe5, 0x4e, 0xaa, 0xa4);

        /// <summary>
        /// Saved Pictures
        /// PERUSER
        /// %USERPROFILE%\Pictures\Saved Pictures
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_SavedPictures = new Guid(0x3b193882, 0xd3ad, 0x4eab, 0x96, 0x5a, 0x69, 0x82, 0x9d, 0x1f, 0xb5, 0x9f);

        /// <summary>
        /// Saved Pictures Library
        /// PERUSER
        /// %APPDATE%\Microsoft\Windows\Libraries\SavedPictures.library-ms
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_SavedPicturesLibrary = new Guid(0xe25b5812, 0xbe88, 0x4bd9, 0x94, 0xb0, 0x29, 0x23, 0x34, 0x77, 0xb6, 0xc3);

        /// <summary>
        /// Searches
        /// PERUSER
        /// %USERPROFILE%\Searches
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_SavedSearches = new Guid(0x7d1d3a04, 0xdebb, 0x4115, 0x95, 0xcf, 0x2f, 0x29, 0xda, 0x29, 0x20, 0xda);

        /// <summary>
        /// Screenshots
        /// PERUSER
        /// %USERPROFILE%\Pictures\Screenshots
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_Screenshots = new Guid(0xb7bede81, 0xdf94, 0x4682, 0xa7, 0xd8, 0x57, 0xa5, 0x26, 0x20, 0xb8, 0x6f);

        /// <summary>
        /// Offline Files
        /// VIRTUAL
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_SEARCH_CSC = new Guid(0xee32e446, 0x31ca, 0x4aba, 0x81, 0x4f, 0xa5, 0xeb, 0xd2, 0xfd, 0x6d, 0x5e);

        /// <summary>
        /// History
        /// PERUSER
        /// %LOCALAPPDATA%\Microsoft\Windows\ConnectedSearch\History
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_SearchHistory = new Guid(0x0d4c3db6, 0x03a3, 0x462f, 0xa0, 0xe6, 0x08, 0x92, 0x4c, 0x41, 0xb5, 0xd4);

        /// <summary>
        /// Search Results
        /// VIRTUAL
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_SearchHome = new Guid(0x190337d1, 0xb8ca, 0x4121, 0xa6, 0x39, 0x6d, 0x47, 0x2d, 0x16, 0x97, 0x2a);

        /// <summary>
        /// Microsoft Office Outlook
        /// VIRTUAL
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_SEARCH_MAPI = new Guid(0x98ec0e18, 0x2098, 0x4d44, 0x86, 0x44, 0x66, 0x97, 0x93, 0x15, 0xa2, 0x81);

        /// <summary>
        /// Templates
        /// PERUSER
        /// %LOCALAPPDATA%\Microsoft\Windows\ConnectedSearch\Templates
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_SearchTemplates = new Guid(0x7e636bfe, 0xdfa9, 0x4d5e, 0xb4, 0x56, 0xd7, 0xb3, 0x98, 0x51, 0xd8, 0xa9);

        /// <summary>
        /// SendTo
        /// PERUSER
        /// %APPDATA%\Microsoft\Windows\SendTo
        /// <see cref="CSIDL_SENDTO"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_SendTo = new Guid(0x8983036c, 0x27c0, 0x404b, 0x8f, 0x08, 0x10, 0x2d, 0x10, 0xdc, 0xfd, 0x74);

        /// <summary>
        /// Gadgets
        /// COMMON
        /// %ProgramFiles%\Windows Sidebar\Gadgets
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_SidebarDefaultParts = new Guid(0x7b396e54, 0x9ec5, 0x4300, 0xbe, 0x0a, 0x24, 0x82, 0xeb, 0xae, 0x1a, 0x26);

        /// <summary>
        /// Gadgets
        /// PERUSER
        /// %LOCALAPPDATA%\Microsoft\Windows Sidebar\Gadgets
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_SidebarParts = new Guid(0xa75d362e, 0x50fc, 0x4fb7, 0xac, 0x2c, 0xa8, 0xbe, 0xaa, 0x31, 0x44, 0x93);

        /// <summary>
        /// OneDrive
        /// PERUSER
        /// %USERPROFILE%\OneDrive
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_SkyDrive = new Guid(0xa52bba46, 0xe9e1, 0x435f, 0xb3, 0xd9, 0x28, 0xda, 0xa6, 0x48, 0xc0, 0xf6);

        /// <summary>
        /// Camera Roll
        /// PERUSER
        /// %USERPROFILE%\OneDrive\Pictures\Camera Roll
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_SkyDriveCameraRoll = new Guid(0x767e6811, 0x49cb, 0x4273, 0x87, 0xc2, 0x20, 0xf3, 0x55, 0xe1, 0x08, 0x5b);

        /// <summary>
        /// Documents
        /// PERUSER
        /// %USERPROFILE%\OneDrive\Documents
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_SkyDriveDocuments = new Guid(0x24d89e24, 0x2f19, 0x4534, 0x9d, 0xde, 0x6a, 0x66, 0x71, 0xfb, 0xb8, 0xfe);

        /// <summary>
        /// Pictures
        /// PERUSER
        /// %USERPROFILE%\OneDrive\Pictures
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_SkyDrivePictures = new Guid(0x339719b5, 0x8c47, 0x4894, 0x94, 0xc2, 0xd8, 0xf7, 0x7a, 0xdd, 0x44, 0xa6);

        /// <summary>
        /// Start Menu
        /// PERUSER
        /// %APPDATA%\Microsoft\Windows\Start Menu
        /// <see cref="CSIDL_STARTMENU"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_StartMenu = new Guid(0x625b53c3, 0xab48, 0x4ec1, 0xba, 0x1f, 0xa1, 0xef, 0x41, 0x46, 0xfc, 0x19);

        /// <summary>
        /// StartUp
        /// PERUSER
        /// %APPDATA%\Microsoft\Windows\Start Menu\Programs\StartUp
        /// <see cref="CSIDL_STARTUP"/>, <see cref="CSIDL_ALTSTARTUP"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_Startup = new Guid(0xb97d20bb, 0xf46a, 0x4c97, 0xba, 0x10, 0x5e, 0x36, 0x08, 0x43, 0x08, 0x54);

        /// <summary>
        /// Sync Center
        /// VIRTUAL
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_SyncManagerFolder = new Guid(0x43668bf8, 0xc14e, 0x49b2, 0x97, 0xc9, 0x74, 0x77, 0x84, 0xd7, 0x84, 0xb7);

        /// <summary>
        /// Sync Results
        /// VIRTUAL
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_SyncResultsFolder = new Guid(0x289a9a43, 0xbe44, 0x4057, 0xa4, 0x1b, 0x58, 0x7a, 0x76, 0xd7, 0xe7, 0xf9);

        /// <summary>
        /// Sync Setup
        /// VIRTUAL
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_SyncSetupFolder = new Guid(0x0f214138, 0xb1d3, 0x4a90, 0xbb, 0xa9, 0x27, 0xcb, 0xc0, 0xc5, 0x38, 0x9a);

        /// <summary>
        /// System32
        /// FIXED
        /// %windir%\system32
        /// <see cref="CSIDL_SYSTEM"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_System = new Guid(0x1ac14e77, 0x02e7, 0x4e5d, 0xb7, 0x44, 0x2e, 0xb1, 0xae, 0x51, 0x98, 0xb7);

        /// <summary>
        /// System32
        /// FIXED
        /// %windir%\system32
        /// <see cref="CSIDL_SYSTEMX86"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_SystemX86 = new Guid(0xd65231b0, 0xb2f1, 0x4857, 0xa4, 0xce, 0xa8, 0xe7, 0xc6, 0xea, 0x7d, 0x27);

        /// <summary>
        /// Templates
        /// PERUSER
        /// %APPDATA%\Microsoft\Windows\Template
        /// <see cref="CSIDL_TEMPLATES"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_Templates = new Guid(0xa63293e8, 0x664e, 0x48db, 0xa0, 0x79, 0xdf, 0x75, 0x9e, 0x05, 0x09, 0xf7);

        /// <summary>
        /// User Pinned
        /// PERUSER
        /// %APPDATA%\Microsoft\Internet Explorer\Quick Launch\User Pinned
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_UserPinned = new Guid(0x9e3995ab, 0x1f9c, 0x4f13, 0xb8, 0x27, 0x48, 0xb2, 0x4b, 0x6c, 0x71, 0x74);

        /// <summary>
        /// Users
        /// FIXED
        /// %SystemDrive%\Users
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_UserProfiles = new Guid(0x0762d272, 0xc50a, 0x4bb0, 0xa3, 0x82, 0x69, 0x7d, 0xcd, 0x72, 0x9b, 0x80);

        /// <summary>
        /// Programs
        /// PERUSER
        /// %LOCALAPPDATA%\Programs
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_UserProgramFiles = new Guid(0x5cd7aee2, 0x2219, 0x4a67, 0xb8, 0x5d, 0x6c, 0x9c, 0xe1, 0x56, 0x60, 0xcb);

        /// <summary>
        /// Programs
        /// PERUSER
        /// %LOCALAPPDATA%\Programs\Common
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_UserProgramFilesCommon = new Guid(0xbcbd3057, 0xca5c, 0x4622, 0xb4, 0x2d, 0xbc, 0x56, 0xdb, 0x0a, 0xe5, 0x16);

        /// <summary>
        /// The user's full name (for instance, Jean Philippe Bagel) entered when the user account was created.
        /// VIRTUAL
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_UsersFiles = new Guid(0xf3ce0f7c, 0x4901, 0x4acc, 0x86, 0x48, 0xd5, 0xd4, 0x4b, 0x04, 0xef, 0x8f);

        /// <summary>
        /// Libraries
        /// VIRTUAL
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_UsersLibraries = new Guid(0xa302545d, 0xdeff, 0x464b, 0xab, 0xe8, 0x61, 0xc8, 0x64, 0x8d, 0x93, 0x9b);

        /// <summary>
        /// Videos
        /// PERUSER
        /// %USERPROFILE%\Videos
        /// <see cref="CSIDL_MYVIDEO"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_Videos = new Guid(0x18989b1d, 0x99b5, 0x455b, 0x84, 0x1c, 0xab, 0x7c, 0x74, 0xe4, 0xdd, 0xfc);

        /// <summary>
        /// Videos
        /// PERUSER
        /// %APPDATA%\Microsoft\Windows\Libraries\Videos.library-ms
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_VideosLibrary = new Guid(0x491e922f, 0x5643, 0x4af4, 0xa7, 0xeb, 0x4e, 0x7a, 0x13, 0x8d, 0x81, 0x74);

        /// <summary>
        /// Windows
        /// FIXED
        /// %windir%
        /// <see cref="CSIDL_WINDOWS"/>
        /// </summary>
        public static readonly KNOWNFOLDERID FOLDERID_Windows = new Guid(0xf38bf404, 0x1d43, 0x42f2, 0x93, 0x05, 0x67, 0xde, 0x0b, 0x28, 0xfc, 0x23);


        [FieldOffset(0)]
        private Guid _value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator Guid(KNOWNFOLDERID val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator KNOWNFOLDERID(Guid val) => new KNOWNFOLDERID { _value = val };
    }
}
