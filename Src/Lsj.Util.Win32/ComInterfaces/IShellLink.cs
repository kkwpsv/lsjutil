using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using System.Text;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.ComInterfaces.IIDs;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.SLGP_FLAGS;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using static Lsj.Util.Win32.Enums.HOTKEYF;
using static Lsj.Util.Win32.Enums.ShowWindowCommands;
using static Lsj.Util.Win32.User32;
using static Lsj.Util.Win32.Enums.SLR_FLAGS;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Exposes methods that create, modify, and resolve Shell links.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ishelllinkw"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Note  This interface cannot be used to create a link to a URL.
    /// The <see cref="IShellLink"/> interface has an ANSI version (IShellLinkA) and a Unicode version (IShellLinkW).
    /// The version that will be used depends on whether you compile for ANSI or Unicode.
    /// Note
    /// The shobjidl_core.h header defines <see cref="IShellLink"/> as an alias which automatically selects the ANSI or Unicode version
    /// of this function based on the definition of the UNICODE preprocessor constant.
    /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead to mismatches
    /// that result in compilation or runtime errors.
    /// For more information, see Conventions for Function Prototypes.
    /// </remarks>
    public unsafe struct IShellLink
    {
        IntPtr* _vTable;

        /// <summary>
        /// Gets the path and file name of the target of a Shell link object.
        /// </summary>
        /// <param name="pszFile">
        /// The address of a buffer that receives the path and file name of the target of the Shell link object.
        /// </param>
        /// <param name="cch">
        /// The size, in characters, of the buffer pointed to by the <paramref name="pszFile"/> parameter, including the terminating null character.
        /// The maximum path size that can be returned is <see cref="MAX_PATH"/>.
        /// This parameter is commonly set by calling ARRAYSIZE(pszFile).
        /// The ARRAYSIZE macro is defined in Winnt.h.
        /// </param>
        /// <param name="pfd">
        /// A pointer to a <see cref="WIN32_FIND_DATA"/> structure that receives information about the target of the Shell link object.
        /// If this parameter is <see cref="NullRef{WIN32_FIND_DATA}"/>, then no additional information is returned.
        /// </param>
        /// <param name="fFlags">
        /// Flags that specify the type of path information to retrieve.
        /// This parameter can be a combination of the following values.
        /// <see cref="SLGP_SHORTPATH"/>: Retrieves the standard short (8.3 format) file name.
        /// <see cref="SLGP_UNCPRIORITY"/>: Unsupported; do not use.
        /// <see cref="SLGP_RAWPATH"/>:  Retrieves the raw path name. A raw path is something
        /// that might not exist and may include environment variables that need to be expanded.
        /// <see cref="SLGP_RELATIVEPRIORITY"/>: Windows Vista and later. Retrieves the path, if possible, 
        /// of the shortcut's target relative to the path set by a previous call to <see cref="SetRelativePath"/>.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if the operation is successful and a valid path is retrieved.
        /// If the operation is successful but no path is retrieved, it returns <see cref="S_FALSE"/> and <paramref name="pszFile"/> will be empty.
        /// Otherwise, it returns one of the standard <see cref="HRESULT"/> error values.
        /// </returns>
        public HRESULT GetPath([In] IntPtr pszFile, [In] int cch, [In][Out] ref WIN32_FIND_DATA pfd, [In] SLGP_FLAGS fFlags)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, IntPtr, int, ref WIN32_FIND_DATA, SLGP_FLAGS, HRESULT>)_vTable[3])(thisPtr, pszFile, cch, ref pfd, fFlags);
            }
        }

        /// <summary>
        /// Gets the list of item identifiers for the target of a Shell link object.
        /// </summary>
        /// <param name="ppidl">
        /// When this method returns, contains the address of a PIDL.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if the operation is successful and one or more valid PIDLs is retrieved.
        /// If the operation is successful but no PIDLs are retrieved,
        /// it returns <see cref="S_FALSE"/> with <paramref name="ppidl"/> set to <see cref="NULL"/>.
        /// Otherwise, it returns a standard error value.
        /// </returns>
        public HRESULT GetIDList([Out] out LPITEMIDLIST ppidl)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out LPITEMIDLIST, HRESULT>)_vTable[4])(thisPtr, out ppidl);
            }
        }

        /// <summary>
        /// Sets the pointer to an item identifier list (PIDL) for a Shell link object.
        /// </summary>
        /// <param name="pidl">
        /// The object's fully qualified PIDL.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// This method is useful when an application needs to set a Shell link to an object that is not a file,
        /// such as a Control Panel application, a printer, or another computer.
        /// </remarks>
        public HRESULT SetIDList([In] in LPCITEMIDLIST pidl)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in LPCITEMIDLIST, HRESULT>)_vTable[5])(thisPtr, pidl);
            }
        }

        /// <summary>
        /// Gets the description string for a Shell link object.
        /// </summary>
        /// <param name="pszName">
        /// A pointer to the buffer that receives the description string.
        /// </param>
        /// <param name="cch">
        /// The maximum number of characters to copy to the buffer pointed to by the <paramref name="pszName"/> parameter.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// For Windows 2000 or later, the string returned to <paramref name="pszName"/> has a maximum length of <see cref="INFOTIPSIZE"/>.
        /// For systems prior to Windows 2000, the size of the string is limited by <see cref="MAX_PATH"/>.
        /// </remarks>
        public HRESULT GetDescription([In] IntPtr pszName, [In] int cch)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, IntPtr, int, HRESULT>)_vTable[6])(thisPtr, pszName, cch);
            }
        }

        /// <summary>
        /// Sets the description for a Shell link object.
        /// The description can be any application-defined string.
        /// </summary>
        /// <param name="pszName">
        /// A pointer to a buffer containing the new description string.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// For Windows 2000 or later, the string specified by <paramref name="pszName"/> must be no larger than <see cref="INFOTIPSIZE"/>.
        /// For systems prior to Windows 2000, the size of the string is limited by <see cref="MAX_PATH"/>.
        /// </remarks>
        public HRESULT SetDescription([In] string pszName)
        {
            fixed (void* thisPtr = &this)
            fixed (char* pszNamePtr = pszName)
            {
                return ((delegate* unmanaged[Stdcall]<void*, char*, HRESULT>)_vTable[7])(thisPtr, pszNamePtr);
            }
        }

        /// <summary>
        /// Gets the name of the working directory for a Shell link object.
        /// </summary>
        /// <param name="pszDir">
        /// The address of a buffer that receives the name of the working directo
        /// </param>
        /// <param name="cch">
        /// The maximum number of characters to copy to the buffer pointed to by the <paramref name="pszDir"/> parameter.
        /// The name of the working directory is truncated if it is longer than the maximum specified by this parameter.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT GetWorkingDirectory([In] IntPtr pszDir, [In] int cch)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, IntPtr, int, HRESULT>)_vTable[8])(thisPtr, pszDir, cch);
            }
        }

        /// <summary>
        /// Sets the name of the working directory for a Shell link object.
        /// </summary>
        /// <param name="pszDir">
        /// The address of a buffer that contains the name of the new working directory.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// The working directory is optional unless the target requires a working directory.
        /// For example, if an application creates a Shell link to a Microsoft Word document that uses a template residing in a different directory,
        /// the application would use this method to set the working directory.
        /// </remarks>
        public HRESULT SetWorkingDirectory([In] string pszDir)
        {
            fixed (void* thisPtr = &this)
            fixed (char* pszDirPtr = pszDir)
            {
                return ((delegate* unmanaged[Stdcall]<void*, char*, HRESULT>)_vTable[9])(thisPtr, pszDirPtr);
            }
        }

        /// <summary>
        /// Gets the command-line arguments associated with a Shell link object.
        /// </summary>
        /// <param name="pszArgs">
        /// A pointer to the buffer that, when this method returns successfully, receives the command-line arguments.
        /// </param>
        /// <param name="cch">
        /// The maximum number of characters that can be copied to the buffer supplied by the <paramref name="pszArgs"/> parameter.
        /// In the case of a Unicode string, there is no limitation on maximum string length.
        /// In the case of an ANSI string, the maximum length of the returned string varies depending on the version of Windows—
        /// <see cref="MAX_PATH"/> prior to Windows 2000 and <see cref="INFOTIPSIZE"/> (defined in Commctrl.h) in Windows 2000 and later.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// In Windows 7 and later, it is recommended that you retrieve argument strings though <see cref="IPropertyStore"/>
        /// (using the PKEY_Link_Arguments value) rather than this method, 
        /// which can silently truncate the string if the provided buffer is not large enough.
        /// <see cref="IPropertyStore"/> allocates a string of the correct size.
        /// </remarks>
        public HRESULT GetArguments([In] IntPtr pszArgs, [In] int cch)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, IntPtr, int, HRESULT>)_vTable[10])(thisPtr, pszArgs, cch);
            }
        }

        /// <summary>
        /// Sets the command-line arguments for a Shell link object.
        /// </summary>
        /// <param name="pszArgs">
        /// A pointer to a buffer that contains the new command-line arguments.
        /// In the case of a Unicode string, there is no limitation on maximum string length.
        /// In the case of an ANSI string, the maximum length of the returned string varies depending on the version of Windows—
        /// <see cref="MAX_PATH"/> prior to Windows 2000 and <see cref="INFOTIPSIZE"/> (defined in Commctrl.h) in Windows 2000 and later.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// This method is useful when creating a link to an application that takes special flags as arguments, such as a compiler.
        /// </remarks>
        public HRESULT SetArguments([In] string pszArgs)
        {
            fixed (void* thisPtr = &this)
            fixed (char* pszArgsPtr = pszArgs)
            {
                return ((delegate* unmanaged[Stdcall]<void*, char*, HRESULT>)_vTable[11])(thisPtr, pszArgsPtr);
            }
        }

        /// <summary>
        /// Gets the keyboard shortcut (hot key) for a Shell link object.
        /// </summary>
        /// <param name="pwHotkey">
        /// The address of the keyboard shortcut.
        /// The virtual key code is in the low-order byte, and the modifier flags are in the high-order byte.
        /// The modifier flags can be a combination of the following values.
        /// <see cref="HOTKEYF_ALT"/>: ALT key
        /// <see cref="HOTKEYF_CONTROL"/>: CTRL key
        /// <see cref="HOTKEYF_EXT"/>: Extended key
        /// <see cref="HOTKEYF_SHIFT"/>: SHIFT key
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT GetHotkey([Out] out WORD pwHotkey)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out WORD, HRESULT>)_vTable[12])(thisPtr, out pwHotkey);
            }
        }

        /// <summary>
        /// Sets a keyboard shortcut (hot key) for a Shell link object.
        /// </summary>
        /// <param name="wHotkey">
        /// The new keyboard shortcut.
        /// The virtual key code is in the low-order byte, and the modifier flags are in the high-order byte.
        /// The modifier flags can be a combination of the values specified in the description of the <see cref="GetHotkey"/> method.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// Setting a keyboard shortcut allows the user to activate the object by pressing a particular combination of keys.
        /// </remarks>
        public HRESULT SetHotkey([In] WORD wHotkey)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, WORD, HRESULT>)_vTable[13])(thisPtr, wHotkey);
            }
        }

        /// <summary>
        /// Gets the show command for a Shell link object.
        /// </summary>
        /// <param name="piShowCmd">
        /// A pointer to the command. The following commands are supported.
        /// <see cref="SW_SHOWNORMAL"/>:
        /// Activates and displays a window.
        /// If the window is minimized or maximized, the system restores it to its original size and position.
        /// An application should specify this flag when displaying the window for the first time.
        /// <see cref="SW_SHOWMAXIMIZED"/>:
        /// Activates the window and displays it as a maximized window.
        /// <see cref="SW_SHOWMINIMIZED"/>:
        /// Activates the window and displays it as a minimized window.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// The show command is used to set the initial show state of the corresponding object.
        /// This is one of the SW_xxx values described in <see cref="ShowWindow"/>.
        /// </remarks>
        public HRESULT GetShowCmd([Out] out ShowWindowCommands piShowCmd)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out ShowWindowCommands, HRESULT>)_vTable[14])(thisPtr, out piShowCmd);
            }
        }

        /// <summary>
        /// Sets the show command for a Shell link object.
        /// The show command sets the initial show state of the window.
        /// </summary>
        /// <param name="iShowCmd">
        /// Command. <see cref="SetShowCmd"/> accepts one of the following <see cref="ShowWindow"/> commands.
        /// A pointer to the command. The following commands are supported.
        /// <see cref="SW_SHOWNORMAL"/>:
        /// Activates and displays a window.
        /// If the window is minimized or maximized, the system restores it to its original size and position.
        /// An application should specify this flag when displaying the window for the first time.
        /// <see cref="SW_SHOWMAXIMIZED"/>:
        /// Activates the window and displays it as a maximized window.
        /// <see cref="SW_SHOWMINNOACTIVE"/>:
        /// Displays the window in its minimized state, leaving the currently active window as active.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT SetShowCmd([In] ShowWindowCommands iShowCmd)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, ShowWindowCommands, HRESULT>)_vTable[15])(thisPtr, iShowCmd);
            }
        }

        /// <summary>
        /// Gets the location (path and index) of the icon for a Shell link object.
        /// </summary>
        /// <param name="pszIconPath">
        /// The address of a buffer that receives the path of the file containing the icon.
        /// </param>
        /// <param name="cch">
        /// The maximum number of characters to copy to the buffer pointed to by the <paramref name="pszIconPath"/> parameter.
        /// </param>
        /// <param name="piIcon">
        /// The address of a value that receives the index of the icon.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT GetIconLocation([In] IntPtr pszIconPath, [In] int cch, [Out] out int piIcon)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, IntPtr, int, out int, HRESULT>)_vTable[16])(thisPtr, pszIconPath, cch, out piIcon);
            }
        }

        /// <summary>
        /// Sets the location (path and index) of the icon for a Shell link object.
        /// </summary>
        /// <param name="pszIconPath">
        /// The address of a buffer to contain the path of the file containing the icon.
        /// </param>
        /// <param name="iIcon">
        /// The index of the icon.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT SetIconLocation([In] string pszIconPath, [In] int iIcon)
        {
            fixed (void* thisPtr = &this)
            fixed (char* pszIconPathPtr = pszIconPath)
            {
                return ((delegate* unmanaged[Stdcall]<void*, char*, int, HRESULT>)_vTable[17])(thisPtr, pszIconPathPtr, iIcon);
            }
        }

        /// <summary>
        /// Sets the relative path to the Shell link object.
        /// </summary>
        /// <param name="pszPathRel">
        /// The address of a buffer that contains the fully-qualified path of the shortcut file,
        /// relative to which the shortcut resolution should be performed.
        /// It should be a file name, not a folder name.
        /// </param>
        /// <param name="dwReserved">
        /// Reserved. Set this parameter to zero.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// Clients commonly define a relative link when it may be moved along with its target, causing the absolute path to become invalid.
        /// The <see cref="SetRelativePath"/> method can be used to help the link resolution process
        /// find its target based on a common path prefix between the target and the relative path.
        /// To assist in the resolution process, clients should set the relative path as part of the link creation process.
        /// Examples
        /// Consider the following scenario:
        /// You have a link: c:\MyLink.lnk.
        /// The link target is c:\MyDocs\MyFile.txt.
        /// You want to move the link and MyDocs\MyFile.txt to d:\.
        /// You can assist the resolution process by creating the original link with a relative path before the shortcut is saved.
        /// <code>
        /// ::SetRelativePath("c:\MyLink.lnk", NULL);
        /// </code>
        /// Before the shortcut is resolved, set a new relative path, and the Resolve code will find the file in its new location.
        /// <code>
        /// ::SetRelativePath("d:\MyLink.lnk", NULL);
        /// </code>
        /// </remarks>
        public HRESULT SetRelativePath([In] string pszPathRel, [In] DWORD dwReserved)
        {
            fixed (void* thisPtr = &this)
            fixed (char* pszPathRelPtr = pszPathRel)
            {
                return ((delegate* unmanaged[Stdcall]<void*, char*, DWORD, HRESULT>)_vTable[18])(thisPtr, pszPathRelPtr, dwReserved);
            }
        }

        /// <summary>
        /// Attempts to find the target of a Shell link, even if it has been moved or renamed.
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window that the Shell will use as the parent for a dialog box.
        /// The Shell displays the dialog box if it needs to prompt the user for more information while resolving a Shell link.
        /// </param>
        /// <param name="fFlags">
        /// Action flags.
        /// This parameter can be a combination of the following values.
        /// <see cref="SLR_NO_UI"/>:
        /// Do not display a dialog box if the link cannot be resolved.
        /// When <see cref="SLR_NO_UI"/> is set, the high-order word of <paramref name="fFlags"/> can be set to a time-out value
        /// that specifies the maximum amount of time to be spent resolving the link.
        /// The function returns if the link cannot be resolved within the time-out duration.
        /// If the high-order word is set to zero, the time-out duration will be set to the default value of 3,000 milliseconds (3 seconds).
        /// To specify a value, set the high word of fFlags to the desired time-out duration, in milliseconds.
        /// <see cref="SLR_ANY_MATCH "/>:
        /// Not used.
        /// <see cref="SLR_UPDATE"/>:
        /// If the link object has changed, update its path and list of identifiers.
        /// If <see cref="SLR_UPDATE"/> is set, you do not need to call <see cref="IPersistFile.IsDirty"/>
        /// to determine whether the link object has changed.
        /// <see cref="SLR_NOUPDATE"/>:
        /// Do not update the link information.
        /// <see cref="SLR_NOSEARCH"/>:
        /// Do not execute the search heuristics.
        /// <see cref="SLR_NOTRACK"/>:
        /// Do not use distributed link tracking.
        /// <see cref="SLR_NOLINKINFO"/>:
        /// Disable distributed link tracking.
        /// By default, distributed link tracking tracks removable media across multiple devices based on the volume name.
        /// It also uses the UNC path to track remote file systems whose drive letter has changed.
        /// Setting <see cref="SLR_NOLINKINFO"/> disables both types of tracking.
        /// <see cref="SLR_INVOKE_MSI"/>:
        /// Call the Windows Installer.
        /// <see cref="SLR_NO_UI_WITH_MSG_PUMP"/>:
        /// Windows XP and later.
        /// <see cref="SLR_OFFER_DELETE_WITHOUT_FILE"/>:
        /// Windows 7 and later.
        /// Offer the option to delete the shortcut when this method is unable to resolve it, even if the shortcut is not a shortcut to a file.
        /// <see cref="SLR_KNOWNFOLDER"/>:
        /// Windows 7 and later.
        /// Report as dirty if the target is a known folder and the known folder was redirected.
        /// This only works if the original target path was a file system path or ID list and not an aliased known folder ID list.
        /// <see cref="SLR_MACHINE_IN_LOCAL_TARGET"/>:
        /// Windows 7 and later.
        /// Resolve the computer name in UNC targets that point to a local computer.
        /// This value is used with <see cref="SLDF_KEEP_LOCAL_IDLIST_FOR_UNC_TARGET"/>.
        /// <see cref="SLR_UPDATE_MACHINE_AND_SID"/>:
        /// Windows 7 and later.
        /// Update the computer GUID and user SID if necessary.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// Following link creation, the name or location of the target may change.
        /// The <see cref="Resolve"/> method first retrieves the path associated with the link.
        /// If the object is no longer there or has been renamed, Resolve will attempt to find it.
        /// If successful, and the following conditions are met, the file that the link object was loaded from
        /// will be updated to reflect the new state of the link object.
        /// The <see cref="SLR_UPDATE"/> flag is set.
        /// The target has been moved or renamed, updating the internal state of the Shell link object to refer to the new target.
        /// The Shell link object was loaded from a file through <see cref="IPersistFile"/>.
        /// The client can also call the <see cref="IPersistFile.IsDirty"/> method to determine
        /// whether the link object has changed and the file needs to be updated.
        /// Resolve has two approaches to finding target objects. The first is the distributed link tracking service.
        /// If the service is available, it can find an object that was on an NTFS version 5.0 volume and was moved to another location on that volume.
        /// It can also find an object that was moved to another NTFS version 5.0 volume, including volumes on other computers.
        /// To suppress the use of this service, set the <see cref="SLR_NOTRACK"/> flag.
        /// If distributed link tracking is not available or fails to find the link object, Resolve attempts to find it with search heuristics.
        /// It first looks in the object's last known directory for an object with a different name but the same attributes and file creation time.
        /// Next, it recursively searches subdirectories in the vicinity of the object's last known directory.
        /// It looks for an object with the same name or creation time.
        /// Finally, Resolve looks for a matching object on the desktop and other local volumes. 
        /// To suppress the use of the search heuristics, set the <see cref="SLR_NOSEARCH"/> flag.
        /// If both approaches fail, the system will display a dialog box prompting the user for a location.
        /// To suppress the dialog box, set the <see cref="SLR_NO_UI"/> flag.
        /// </remarks>
        public HRESULT Resolve([In] HWND hwnd, [In] SLR_FLAGS fFlags)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HWND, SLR_FLAGS, HRESULT>)_vTable[19])(thisPtr, hwnd, fFlags);
            }
        }

        /// <summary>
        /// Sets the path and file name for the target of a Shell link object.
        /// </summary>
        /// <param name="pszFile">
        /// The address of a buffer that contains the new path.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT SetPath([In] string pszFile)
        {
            fixed (void* thisPtr = &this)
            fixed (char* pszFilePtr = pszFile)
            {
                return ((delegate* unmanaged[Stdcall]<void*, char*, HRESULT>)_vTable[20])(thisPtr, pszFilePtr);
            }
        }
    }
}
