﻿using System;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="LoadLibraryEx"/> Flags
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/libloaderapi/nf-libloaderapi-loadlibraryexw
    /// </para>
    /// </summary>
    public enum LoadLibraryExFlags
    {
        /// <summary>
        /// If this value is used, and the executable module is a DLL, the system does not call DllMain for process and thread initialization and termination.
        /// Also, the system does not load additional executable modules that are referenced by the specified module.
        /// Note
        /// Do not use this value; it is provided only for backward compatibility.
        /// If you are planning to access only data or resources in the DLL, use <see cref="LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE"/>
        /// or <see cref="LOAD_LIBRARY_AS_IMAGE_RESOURCE"/> or both.
        /// Otherwise, load the library as a DLL or executable module using the <see cref="LoadLibrary"/> function.
        /// </summary>
        [Obsolete]
        DONT_RESOLVE_DLL_REFERENCES = 0x00000001,

        /// <summary>
        /// If this value is used, the system does not check AppLocker rules or apply Software Restriction Policies for the DLL.
        /// This action applies only to the DLL being loaded and not to its dependencies.
        /// This value is recommended for use in setup programs that must run extracted DLLs during installation.
        /// Windows Server 2008 R2 and Windows 7:
        /// On systems with KB2532445 installed, the caller must be running as "LocalSystem" or "TrustedInstaller"; otherwise the system ignores this flag.
        /// For more information, see "You can circumvent AppLocker rules by using an Office macro on a computer
        /// that is running Windows 7 or Windows Server 2008 R2" in the Help and Support Knowledge Base at http://support.microsoft.com/kb/2532445.
        /// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// AppLocker was introduced in Windows 7 and Windows Server 2008 R2.
        /// </summary>
        LOAD_IGNORE_CODE_AUTHZ_LEVEL = 0x00000010,

        /// <summary>
        /// If this value is used, the system maps the file into the calling process's virtual address space as if it were a data file.
        /// Nothing is done to execute or prepare to execute the mapped file.
        /// Therefore, you cannot call functions like <see cref="GetModuleFileName"/>,
        /// <see cref="GetModuleHandle"/> or <see cref="GetProcAddress"/> with this DLL.
        /// Using this value causes writes to read-only memory to raise an access violation.
        /// Use this flag when you want to load a DLL only to extract messages or resources from it.
        /// This value can be used with <see cref="LOAD_LIBRARY_AS_IMAGE_RESOURCE"/>.
        /// For more information, see Remarks.
        /// </summary>
        LOAD_LIBRARY_AS_DATAFILE = 0x00000002,

        /// <summary>
        /// Similar to LOAD_LIBRARY_AS_DATAFILE, except that the DLL file is opened with exclusive write access for the calling process.
        /// Other processes cannot open the DLL file for write access while it is in use.
        /// However, the DLL can still be opened by other processes.
        /// This value can be used with <see cref="LOAD_LIBRARY_AS_IMAGE_RESOURCE"/>.
        /// For more information, see Remarks.
        /// Windows Server 2003 and Windows XP: This value is not supported until Windows Vista.
        /// </summary>
        LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE = 0x00000040,

        /// <summary>
        /// If this value is used, the system maps the file into the process's virtual address space as an image file.
        /// However, the loader does not load the static imports or perform the other usual initialization steps.
        /// Use this flag when you want to load a DLL only to extract messages or resources from it.
        /// Unless the application depends on the file having the in-memory layout of an image,
        /// this value should be used with either <see cref="LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE"/> or <see cref="LOAD_LIBRARY_AS_DATAFILE"/>.
        /// For more information, see the Remarks section.
        /// Windows Server 2003 and Windows XP:  This value is not supported until Windows Vista.
        /// </summary>
        LOAD_LIBRARY_AS_IMAGE_RESOURCE = 0x00000020,

        /// <summary>
        /// If this value is used, the application's installation directory is searched for the DLL and its dependencies.
        /// Directories in the standard search path are not searched. This value cannot be combined with <see cref="LOAD_WITH_ALTERED_SEARCH_PATH"/>.
        /// Windows 7, Windows Server 2008 R2, Windows Vista and Windows Server 2008:  This value requires KB2533623 to be installed.
        /// Windows Server 2003 and Windows XP:  This value is not supported.
        /// </summary>
        LOAD_LIBRARY_SEARCH_APPLICATION_DIR = 0x00000200,

        /// <summary>
        /// This value is a combination of <see cref="LOAD_LIBRARY_SEARCH_APPLICATION_DIR"/>,
        /// <see cref="LOAD_LIBRARY_SEARCH_SYSTEM32"/>, and <see cref="LOAD_LIBRARY_SEARCH_USER_DIRS"/>.
        /// Directories in the standard search path are not searched.
        /// This value cannot be combined with <see cref="LOAD_WITH_ALTERED_SEARCH_PATH"/>.
        /// This value represents the recommended maximum number of directories an application should include in its DLL search path.
        /// Windows 7, Windows Server 2008 R2, Windows Vista and Windows Server 2008: This value requires KB2533623 to be installed.
        /// Windows Server 2003 and Windows XP: This value is not supported.
        /// </summary>
        LOAD_LIBRARY_SEARCH_DEFAULT_DIRS = 0x00001000,

        /// <summary>
        /// If this value is used, the directory that contains the DLL is temporarily added to the beginning of the list
        /// of directories that are searched for the DLL's dependencies.
        /// Directories in the standard search path are not searched.
        /// The lpFileName parameter must specify a fully qualified path.
        /// This value cannot be combined with <see cref="LOAD_WITH_ALTERED_SEARCH_PATH"/>.
        /// For example, if Lib2.dll is a dependency of C:\Dir1\Lib1.dll, loading Lib1.dll with this value
        /// causes the system to search for Lib2.dll only in C:\Dir1.
        /// To search for Lib2.dll in C:\Dir1 and all of the directories in the DLL search path,
        /// combine this value with <see cref="LOAD_LIBRARY_SEARCH_DEFAULT_DIRS"/>.
        /// Windows 7, Windows Server 2008 R2, Windows Vista and Windows Server 2008: This value requires KB2533623 to be installed.
        /// Windows Server 2003 and Windows XP: This value is not supported.
        /// </summary>
        LOAD_LIBRARY_SEARCH_DLL_LOAD_DIR = 0x00000100,

        /// <summary>
        /// If this value is used, %windows%\system32 is searched for the DLL and its dependencies.
        /// Directories in the standard search path are not searched.
        /// This value cannot be combined with <see cref="LOAD_WITH_ALTERED_SEARCH_PATH"/>.
        /// Windows 7, Windows Server 2008 R2, Windows Vista and Windows Server 2008: This value requires KB2533623 to be installed.
        /// Windows Server 2003 and Windows XP: This value is not supported.
        /// </summary>
        LOAD_LIBRARY_SEARCH_SYSTEM32 = 0x00000800,

        /// <summary>
        /// If this value is used, directories added using the <see cref="AddDllDirectory"/> or the <see cref="SetDllDirectory"/> function
        /// are searched for the DLL and its dependencies.
        /// If more than one directory has been added, the order in which the directories are searched is unspecified.
        /// Directories in the standard search path are not searched.
        /// This value cannot be combined with <see cref="LOAD_WITH_ALTERED_SEARCH_PATH"/>.
        /// Windows 7, Windows Server 2008 R2, Windows Vista and Windows Server 2008: This value requires KB2533623 to be installed.
        /// Windows Server 2003 and Windows XP:  This value is not supported.
        /// </summary>
        LOAD_LIBRARY_SEARCH_USER_DIRS = 0x00000400,

        /// <summary>
        /// If this value is used and lpFileName specifies an absolute path, the system uses the alternate file search strategy
        /// discussed in the Remarks section to find associated executable modules that the specified module causes to be loaded.
        /// If this value is used and lpFileName specifies a relative path, the behavior is undefined.
        /// If this value is not used, or if lpFileName does not specify a path,
        /// the system uses the standard search strategy discussed in the Remarks section to find associated executable modules
        /// that the specified module causes to be loaded.
        /// This value cannot be combined with any LOAD_LIBRARY_SEARCH flag.
        /// </summary>
        LOAD_WITH_ALTERED_SEARCH_PATH = 0x00000008,
    }
}
