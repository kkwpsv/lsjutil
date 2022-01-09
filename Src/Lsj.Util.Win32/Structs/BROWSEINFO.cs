using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.BROWSEINFOFlags;
using static Lsj.Util.Win32.Shell32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains parameters for the <see cref="SHBrowseForFolder"/> function and receives information about the folder selected by the user.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/shlobj_core/ns-shlobj_core-browseinfow"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The shlobj_core.h header defines <see cref="BROWSEINFO"/> as an alias which automatically
    /// selects the ANSI or Unicode version of this function based on the definition of the UNICODE preprocessor constant.
    /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead
    /// to mismatches that result in compilation or runtime errors.
    /// For more information, see Conventions for Function Prototypes.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct BROWSEINFO
    {
       
        /// <summary>
        /// A handle to the owner window for the dialog box.
        /// </summary>
        public HWND hwndOwner;

        /// <summary>
        /// A PIDL that specifies the location of the root folder from which to start browsing.
        /// Only the specified folder and its subfolders in the namespace hierarchy appear in the dialog box.
        /// This member can be <see cref="NULL"/>; in that case, a default location is used.
        /// </summary>
        public LPCITEMIDLIST pidlRoot;

        /// <summary>
        /// Pointer to a buffer to receive the display name of the folder selected by the user.
        /// The size of this buffer is assumed to be <see cref="MAX_PATH"/> characters.
        /// </summary>
        public IntPtr pszDisplayName;

        /// <summary>
        /// Pointer to a null-terminated string that is displayed above the tree view control in the dialog box.
        /// This string can be used to specify instructions to the user.
        /// </summary>
        public IntPtr lpszTitle;

        /// <summary>
        /// Flags that specify the options for the dialog box.
        /// This member can be 0 or a combination of the following values.
        /// Version numbers refer to the minimum version of Shell32.dll required
        /// for <see cref="SHBrowseForFolder"/> to recognize flags added in later releases.
        /// See Shell and Common Controls Versions for more information.
        /// <see cref="BIF_RETURNONLYFSDIRS"/>, <see cref="BIF_DONTGOBELOWDOMAIN "/>, <see cref="BIF_STATUSTEXT"/>,
        /// <see cref="BIF_RETURNFSANCESTORS"/>, <see cref="BIF_EDITBOX"/>, <see cref="BIF_VALIDATE"/>,
        /// <see cref="BIF_NEWDIALOGSTYLE"/>, <see cref="BIF_BROWSEINCLUDEURLS"/>, <see cref="BIF_USENEWUI"/>,
        /// <see cref="BIF_UAHINT"/>, <see cref="BIF_NONEWFOLDERBUTTON"/>, <see cref="BIF_NOTRANSLATETARGETS"/>,
        /// <see cref="BIF_BROWSEFORCOMPUTER"/>, <see cref="BIF_BROWSEFORPRINTER"/>, <see cref="BIF_BROWSEINCLUDEFILES"/>,
        /// <see cref="BIF_SHAREABLE"/>, <see cref="BIF_BROWSEFILEJUNCTIONS"/>
        /// </summary>
        public BROWSEINFOFlags ulFlags;

        /// <summary>
        /// Pointer to an application-defined function that the dialog box calls when an event occurs.
        /// For more information, see the BrowseCallbackProc function.
        /// This member can be <see cref="NULL"/>.
        /// </summary>
        public BFFCALLBACK lpfn;

        /// <summary>
        /// An application-defined value that the dialog box passes to the callback function, if one is specified in <see cref="lpfn"/>.
        /// </summary>
        public LPARAM lParam;

        /// <summary>
        /// An integer value that receives the index of the image associated with the selected folder, stored in the system image list.
        /// </summary>
        public int iImage;
    }
}
