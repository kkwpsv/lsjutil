using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.CSIDL;
using static Lsj.Util.Win32.BaseTypes.HKEY;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.BaseTypes.KNOWNFOLDERID;
using static Lsj.Util.Win32.BaseTypes.UINT;
using static Lsj.Util.Win32.ComInterfaces.IIDs;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.BrowseForFolderDialogOptionFlags;
using static Lsj.Util.Win32.Enums.BrowseForFolderMessages;
using static Lsj.Util.Win32.Enums.COINIT;
using static Lsj.Util.Win32.Enums.FileAttributes;
using static Lsj.Util.Win32.Enums.FILEOPENDIALOGOPTIONS;
using static Lsj.Util.Win32.Enums.FileOperationFlags;
using static Lsj.Util.Win32.Enums.KF_CATEGORY;
using static Lsj.Util.Win32.Enums.KNOWN_FOLDER_FLAG;
using static Lsj.Util.Win32.Enums.RegistryValueTypes;
using static Lsj.Util.Win32.Enums.ResourceTypes;
using static Lsj.Util.Win32.Enums.ShellChangeNotifyEvents;
using static Lsj.Util.Win32.Enums.ShellChangeNotifyFlags;
using static Lsj.Util.Win32.Enums.ShellExecuteErrorCodes;
using static Lsj.Util.Win32.Enums.ShellGetFileInfoFlags;
using static Lsj.Util.Win32.Enums.ShellGetFolderPathTypes;
using static Lsj.Util.Win32.Enums.ShellGetStockIconInfoFlags;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.SystemMetricIndexes;
using static Lsj.Util.Win32.Enums.TokenAccessRights;
using static Lsj.Util.Win32.Enums.VARENUM;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Ole32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Shell32.dll
    /// </summary>
    public static class Shell32
    {
        /// <summary>
        /// <para>
        /// Specifies an application-defined callback function used to send messages to, and process messages from,
        /// a Browse dialog box displayed in response to a call to <see cref="SHBrowseForFolder"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/bb762598(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// The window handle of the browse dialog box.
        /// </param>
        /// <param name="uMsg">
        /// The dialog box event that generated the message.
        /// One of the following values.
        /// <see cref="BFFM_INITIALIZED"/>, <see cref="BFFM_IUNKNOWN"/>, <see cref="BFFM_SELCHANGED"/>, <see cref="BFFM_VALIDATEFAILED"/>
        /// </param>
        /// <param name="lParam">
        /// <para>
        /// The dialog box event that generated the message. One of the following values.
        /// </para>
        /// <para>
        /// <see cref="BFFM_INITIALIZED"/>
        /// </para>
        /// <para>
        /// The dialog box has finished initializing.
        /// </para>
        /// <para>
        /// <see cref="BFFM_IUNKNOWN"/>
        /// </para>
        /// <para>
        /// An <see cref="IUnknown"/> interface is available to the dialog box.
        /// </para>
        /// <para>
        /// <see cref="BFFM_SELCHANGED"/>
        /// </para>
        /// <para>
        /// The selection has changed in the dialog box.
        /// </para>
        /// <para>
        /// <see cref="BFFM_VALIDATEFAILED"/>
        /// </para>
        /// <para>
        /// The user typed an invalid name into the dialog's edit box. A nonexistent folder is considered an invalid name.
        /// </para>
        /// </param>
        /// <param name="lpData">
        /// An application-defined value that was specified in the <see cref="BROWSEINFO.lParam"/> member
        /// of the <see cref="BROWSEINFO"/> structure used in the call to <see cref="SHBrowseForFolder"/>.
        /// </param>
        /// <returns>
        /// Returns zero except in the case of <see cref="BFFM_VALIDATEFAILED"/>.
        /// For that flag, returns zero to dismiss the dialog or nonzero to keep the dialog displayed.
        /// </returns>
        /// <remarks>
        /// <para>
        /// To attach your <see cref="BrowseCallbackProc"/> to a dialog, specify its address
        /// in the <see cref="BROWSEINFO.lpfn"/> member of the <see cref="BROWSEINFO"/> structure used in a <see cref="SHBrowseForFolder"/> call.
        /// </para>
        /// <para>
        /// <see cref="BrowseCallbackProc"/> can also send messages to the dialog box through <see cref="SendMessage"/>,
        /// to control these aspects:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// OK button enabled/disabled
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// OK button text
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Selected folder
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Expanded folder
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Status text
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Set the <see cref="SendMessage"/> function's Msg parameter to one of the following values,
        /// providing additional information in the wParam and lParam parameters as indicated for each message type.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Msg
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// <term>
        /// wParam
        /// </term>
        /// <term>
        /// lParam
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="BFFM_ENABLEOK"/>
        /// </term>
        /// <term>
        /// Enables or disables the dialog box's OK button.
        /// </term>
        /// <term>
        /// Not used.
        /// </term>
        /// <term>
        /// To enable, set to a nonzero value. To disable, set to zero.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BFFM_SETOKTEXT"/>
        /// </term>
        /// <term>
        /// Version 6.0 or later. Sets the text that is displayed on the dialog box's OK button.
        /// </term>
        /// <term>
        /// Not used.
        /// </term>
        /// <term>
        /// A pointer to a null-terminated Unicode string that contains the desired text.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BFFM_SETSELECTION"/>
        /// </term>
        /// <term>
        /// Specifies the path of a folder to select. The path can be specified as a string or a PIDL.
        /// </term>
        /// <term>
        /// <see cref="TRUE"/> to use a string; <see cref="FALSE"/> to use a PIDL.
        /// </term>
        /// <term>
        /// The string or PIDL that specifies the path.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BFFM_SETEXPANDED"/>
        /// </term>
        /// <term>
        /// Version 6.0 or later.
        /// Specifies the path of a folder to expand in the Browse dialog box.
        /// The path can be specified as a Unicode string or a PIDL.
        /// </term>
        /// <term>
        /// <see cref="TRUE"/> to use a string; <see cref="FALSE"/> to use a PIDL.
        /// </term>
        /// <term>
        /// The string or PIDL that specifies the path.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BFFM_SETSTATUSTEXT"/>
        /// </term>
        /// <term>
        /// Sets the status text.
        /// Set the <see cref="BrowseCallbackProc"/> <paramref name="lpData"/> parameter to point to a null-terminated string with the desired text.
        /// </term>
        /// <term>
        /// Not used.
        /// </term>
        /// <term>
        /// A pointer to a null-terminated string that contains the desired text.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        public delegate int BrowseCallbackProc([In] HWND hwnd, [In] BrowseForFolderMessages uMsg, [In] LPARAM lParam, [In] LPARAM lpData);


        /// <summary>
        /// <para>
        /// Parses a Unicode command line string and returns an array of pointers to the command line arguments,
        /// along with a count of such arguments, in a way that is similar to the standard C run-time argv and argc values.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shellapi/nf-shellapi-commandlinetoargvw"/>
        /// </para>
        /// </summary>
        /// <param name="lpCmdLine">
        /// Pointer to a null-terminated Unicode string that contains the full command line.
        /// If this parameter is an empty string the function returns the path to the current executable file.
        /// </param>
        /// <param name="pNumArgs">
        /// Pointer to an int that receives the number of array elements returned, similar to argc.
        /// </param>
        /// <returns>
        /// <para>
        /// A pointer to an array of <see cref="LPWSTR"/> values, similar to argv.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The address returned by <see cref="CommandLineToArgvW"/> is the address of the first element in an array of <see cref="LPWSTR"/> values;
        /// the number of pointers in this array is indicated by <paramref name="pNumArgs"/>.
        /// Each pointer to a null-terminated Unicode string represents an individual argument found on the command line.
        /// </para>
        /// <para>
        /// <see cref="CommandLineToArgvW"/> allocates a block of contiguous memory for pointers to the argument strings,
        /// and for the argument strings themselves; the calling application must free the memory used by the argument list when it is no longer needed.
        /// To free the memory, use a single call to the <see cref="LocalFree"/> function.
        /// </para>
        /// <para>
        /// For more information about the argv and argc argument convention, see Argument Definitions and Parsing C Command-Line Arguments.
        /// </para>
        /// <para>
        /// The <see cref="GetCommandLine"/> function can be used to get a command line string
        /// that is suitable for use as the <paramref name="lpCmdLine"/> parameter.
        /// </para>
        /// <para>
        /// This function accepts command lines that contain a program name; the program name can be enclosed in quotation marks or not.
        /// </para>
        /// <para>
        /// <see cref="CommandLineToArgvW"/> has a special interpretation of backslash characters when they are followed by a quotation mark character (").
        /// This interpretation assumes that any preceding argument is a valid file system path, or else it may behave unpredictably.
        /// </para>
        /// <para>
        /// This special interpretation controls the "in quotes" mode tracked by the parser.
        /// When this mode is off, whitespace terminates the current argument.
        /// When on, whitespace is added to the argument like all other characters.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// 2n backslashes followed by a quotation mark produce n backslashes followed by begin/end quote.
        /// This does not become part of the parsed argument, but toggles the "in quotes" mode.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// (2n) + 1 backslashes followed by a quotation mark again produce n backslashes followed by a quotation mark literal (").
        /// This does not toggle the "in quotes" mode.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// n backslashes not followed by a quotation mark simply produce n backslashes.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Important  
        /// </para>
        /// <para>
        /// <see cref="CommandLineToArgvW"/> treats whitespace outside of quotation marks as argument delimiters.
        /// However, if <paramref name="lpCmdLine"/> starts with any amount of whitespace,
        /// <see cref="CommandLineToArgvW"/> will consider the first argument to be an empty string.
        /// Excess whitespace at the end of <paramref name="lpCmdLine"/> is ignored.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "CommandLineToArgvW", ExactSpelling = true, SetLastError = true)]
        public static extern nint CommandLineToArgvW([In] LPCWSTR lpCmdLine, [Out] out int pNumArgs);

        /// <summary>
        /// <para>
        /// Retrieves the names of dropped files that result from a successful drag-and-drop operation.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shellapi/nf-shellapi-dragqueryfilew"/>
        /// </para>
        /// </summary>
        /// <param name="hDrop">
        /// Identifier of the structure that contains the file names of the dropped files.
        /// </param>
        /// <param name="iFile">
        /// Index of the file to query.
        /// If the value of this parameter is 0xFFFFFFFF, <see cref="DragQueryFile"/> returns a count of the files dropped.
        /// If the value of this parameter is between zero and the total number of files dropped,
        /// <see cref="DragQueryFile"/> copies the file name with the corresponding value to the buffer pointed to by the <paramref name="lpszFile"/> parameter.
        /// </param>
        /// <param name="lpszFile">
        /// The address of a buffer that receives the file name of a dropped file when the function returns.
        /// This file name is a null-terminated string.
        /// If this parameter is <see cref="NULL"/>, <see cref="DragQueryFile"/> returns the required size, in characters, of this buffer.
        /// </param>
        /// <param name="cch">
        /// The size, in characters, of the <paramref name="lpszFile"/> buffer.
        /// </param>
        /// <returns>
        /// <para>
        /// A nonzero value indicates a successful call.
        /// </para>
        /// <para>
        /// When the function copies a file name to the buffer,
        /// the return value is a count of the characters copied, not including the terminating null character.
        /// </para>
        /// <para>
        /// If the index value is 0xFFFFFFFF, the return value is a count of the dropped files.
        /// Note that the index variable itself returns unchanged, and therefore remains 0xFFFFFFFF.
        /// </para>
        /// <para>
        /// If the index value is between zero and the total number of dropped files,
        /// and the <paramref name="lpszFile"/> buffer address is <see cref="NULL"/>,
        /// the return value is the required size, in characters, of the buffer, not including the terminating null character.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "DragQueryFileW", ExactSpelling = true)]
        public static extern UINT DragQueryFile([In] HDROP hDrop, [In] UINT iFile, [In] LPWSTR lpszFile, [In] UINT cch);

        /// <summary>
        /// <para>
        /// Creates a duplicate of a specified icon.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shellapi/nf-shellapi-duplicateicon"/>
        /// </para>
        /// </summary>
        /// <param name="hInst">
        /// </param>
        /// <param name="hIcon">
        /// Handle to the icon to be duplicated.
        /// </param>
        /// <returns>
        /// If successful, the function returns the handle to the new icon that was created; otherwise, <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// When it is no longer needed, the caller is responsible for freeing the icon handle
        /// returned by <see cref="DuplicateIcon"/> by calling the <see cref="DestroyIcon"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "DuplicateIcon", ExactSpelling = true)]
        public static extern HICON DuplicateIcon([In] HINSTANCE hInst, [In] HICON hIcon);

        /// <summary>
        /// <para>
        /// Gets a handle to an icon stored as a resource in a file or an icon stored in a file's associated executable file.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shellapi/nf-shellapi-extractassociatediconw"/>
        /// </para>
        /// </summary>
        /// <param name="hInst">
        /// A handle to the instance of the calling application.
        /// </param>
        /// <param name="pszIconPath">
        /// <para>
        /// Pointer to a string that, on entry, specifies the full path and file name of the file that contains the icon.
        /// The function extracts the icon handle from that file, or from an executable file associated with that file.
        /// </para>
        /// <para>
        /// When this function returns, if the icon handle was obtained from an executable file
        /// (either an executable file pointed to by <paramref name="pszIconPath"/> or an associated executable file)
        /// the function stores the full path and file name of that executable in the buffer pointed to by this parameter.
        /// </para>
        /// </param>
        /// <param name="piIcon">
        /// <para>
        /// Pointer to a <see cref="WORD"/> value that, on entry, specifies the index of the icon whose handle is to be obtained.
        /// </para>
        /// <para>
        /// When the function returns, if the icon handle was obtained from an executable file
        /// (either an executable file pointed to by <paramref name="pszIconPath"/> or an associated executable file),
        /// this value points to the icon's index in that file.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is an icon handle.
        /// If the icon is extracted from an associated executable file,
        /// the function stores the full path and file name of the executable file in the string pointed to by <paramref name="pszIconPath"/>,
        /// and stores the icon's identifier in the <see cref="WORD"/> pointed to by <paramref name="piIcon"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// When it is no longer needed, the caller is responsible for freeing the icon handle
        /// returned by <see cref="ExtractAssociatedIcon"/> by calling the <see cref="DestroyIcon"/> function.
        /// </para>
        /// <para>
        /// The <see cref="ExtractAssociatedIcon"/> function first looks for the indexed icon in the file specified by <paramref name="pszIconPath"/>.
        /// If the function cannot obtain the icon handle from that file, and the file has an associated executable file,
        /// it looks in that executable file for an icon.
        /// Associations with executable files are based on file name extensions and are stored in the per-user part of the registry.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "ExtractAssociatedIconW", ExactSpelling = true)]
        public static extern HICON ExtractAssociatedIcon([In] HINSTANCE hInst, [In][Out] LPWSTR pszIconPath, [In][Out] ref WORD piIcon);

        /// <summary>
        /// <para>
        /// Gets a handle to an icon from the specified executable file, DLL, or icon file.
        /// </para>
        /// <para>
        /// To retrieve an array of handles to large or small icons, use the <see cref="ExtractIconEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shellapi/nf-shellapi-extracticonw"/>
        /// </para>
        /// </summary>
        /// <param name="hInst">
        /// Handle to the instance of the application that calls the function.
        /// </param>
        /// <param name="pszExeFileName">
        /// Pointer to a null-terminated string that specifies the name of an executable file, DLL, or icon file.
        /// </param>
        /// <param name="nIconIndex">
        /// <para>
        /// Specifies the zero-based index of the icon to retrieve.
        /// For example, if this value is 0, the function returns a handle to the first icon in the specified file.
        /// </para>
        /// <para>
        /// If this value is -1, the function returns the total number of icons in the specified file.
        /// If the file is an executable file or DLL, the return value is the number of <see cref="RT_GROUP_ICON"/> resources.
        /// If the file is an .ICO file, the return value is 1.
        /// </para>
        /// <para>
        /// If this value is a negative number not equal to –1, the function returns a handle to the icon in the specified file
        /// whose resource identifier is equal to the absolute value of <paramref name="nIconIndex"/>.
        /// For example, you should use –3 to extract the icon whose resource identifier is 3.
        /// To extract the icon whose resource identifier is 1, use the <see cref="ExtractIconEx"/> function.
        /// </para>
        /// </param>
        /// <returns>
        /// The return value is a handle to an icon.
        /// If the file specified was not an executable file, DLL, or icon file, the return is 1.
        /// If no icons were found in the file, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// When it is no longer needed, you must destroy the icon handle returned by <see cref="ExtractIcon"/>
        /// by calling the <see cref="DestroyIcon"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "ExtractIconW", ExactSpelling = true)]
        public static extern HICON ExtractIcon([In] HINSTANCE hInst, [In] LPWSTR pszExeFileName, [In] UINT nIconIndex);

        /// <summary>
        /// <para>
        /// The <see cref="ExtractIconEx"/> function creates an array of handles to large or small icons
        /// extracted from the specified executable file, DLL, or icon file.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shellapi/nf-shellapi-extracticonexw"/>
        /// </para>
        /// </summary>
        /// <param name="lpszFile">
        /// Pointer to a null-terminated string that specifies the name of an executable file, DLL, or icon file from which icons will be extracted.
        /// </param>
        /// <param name="nIconIndex">
        /// <para>
        /// Specifies the zero-based index of the first icon to extract.
        /// For example, if this value is zero, the function extracts the first icon in the specified file.
        /// </para>
        /// <para>
        /// If this value is –1 and <paramref name="phiconLarge"/> and <paramref name="phiconSmall"/> are both <see langword="null"/>,
        /// the function returns the total number of icons in the specified file.
        /// If the file is an executable file or DLL, the return value is the number of <see cref="RT_GROUP_ICON"/> resources.
        /// If the file is an .ico file, the return value is 1.
        /// </para>
        /// <para>
        /// If this value is a negative number and either <paramref name="phiconLarge"/> or <paramref name="phiconSmall"/> is not <see langword="null"/>,
        /// the function begins by extracting the icon whose resource identifier is equal to the absolute value of <paramref name="nIconIndex"/>.
        /// For example, use -3 to extract the icon whose resource identifier is 3.
        /// </para>
        /// </param>
        /// <param name="phiconLarge">
        /// Pointer to an array of icon handles that receives handles to the large icons extracted from the file.
        /// If this parameter is <see langword="null"/>, no large icons are extracted from the file.
        /// </param>
        /// <param name="phiconSmall">
        /// Pointer to an array of icon handles that receives handles to the small icons extracted from the file.
        /// If this parameter is <see langword="null"/>, no small icons are extracted from the file.
        /// </param>
        /// <param name="nIcons">
        /// The number of icons to extract from the file.
        /// </param>
        /// <returns>
        /// <para>
        /// If the <paramref name="nIconIndex"/> parameter is -1
        /// and both the <paramref name="phiconLarge"/> and <paramref name="phiconSmall"/> parameters are <see langword="null"/>,
        /// then the return value is the number of icons contained in the specified file.
        /// </para>
        /// <para>
        /// If the <paramref name="nIconIndex"/> parameter is any value other than -1
        /// and either <paramref name="phiconLarge"/> or <paramref name="phiconSmall"/> is not <see langword="null"/>,
        /// the return value is the number of icons successfully extracted from the file.
        /// </para>
        /// <para>
        ///  Note
        /// </para>
        /// <para>
        /// If the function encounters an error, it returns <see cref="UINT_MAX"/>.
        /// In this case, you can call <see cref="GetLastError"/> to retrieve the error code.
        /// For example, this function returns <see cref="UINT_MAX"/> if the file specified by <paramref name="lpszFile"/> cannot be found
        /// while the <paramref name="nIconIndex"/> parameter is any value other than -1
        /// and either <paramref name="phiconLarge"/> or <paramref name="phiconSmall"/> is not <see langword="null"/>,
        /// In this case, <see cref="GetLastError"/> returns <see cref="ERROR_FILE_NOT_FOUND"/> (2).
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// When they are no longer needed, you must destroy all icons extracted by <see cref="ExtractIconEx"/> by calling the <see cref="DestroyIcon"/> function.
        /// </para>
        /// <para>
        /// To retrieve the dimensions of the large and small icons,
        /// use this function with the <see cref="SM_CXICON"/>, <see cref="SM_CYICON"/>, <see cref="SM_CXSMICON"/>, and <see cref="SM_CYSMICON"/> flags.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "ExtractIconExW", ExactSpelling = true, SetLastError = true)]
        public static extern UINT ExtractIconEx([In] LPWSTR lpszFile, [In] int nIconIndex, [Out] HICON[] phiconLarge, [Out] HICON[] phiconSmall, [In] UINT nIcons);

        /// <summary>
        /// <para>
        /// Retrieves the application-defined, explicit Application User Model ID (AppUserModelID) for the current process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-getcurrentprocessexplicitappusermodelid"/>
        /// </para>
        /// </summary>
        /// <param name="AppID">
        /// A pointer that receives the address of the AppUserModelID assigned to the process.
        /// The caller is responsible for freeing this string with <see cref="CoTaskMemFree"/> when it is no longer needed.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The AppUserModelID retrieved by this function was set earlier through <see cref="SetCurrentProcessExplicitAppUserModelID"/>.
        /// </para>
        /// <para>
        /// An application can only retrieve an AppUserModelID that has been explicitly set. System-assigned default AppUserModelIDs cannot be retrieved.
        /// If the application requires knowledge of its AppUserModelID it should set one explicitly.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCurrentProcessExplicitAppUserModelID", ExactSpelling = true)]
        public static extern HRESULT GetCurrentProcessExplicitAppUserModelID([Out] out IntPtr AppID);

        /// <summary>
        /// <para>
        /// Specifies a unique application-defined Application User Model ID (AppUserModelID) that identifies the current process to the taskbar.
        /// This identifier allows an application to group its associated processes and windows under a single taskbar button.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-setcurrentprocessexplicitappusermodelid"/>
        /// </para>
        /// </summary>
        /// <param name="AppID">
        /// Pointer to the AppUserModelID to assign to the current process.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// This method must be called during an application's initial startup routine
        /// before the application presents any UI or makes any manipulation of its Jump Lists.
        /// This includes any call to <see cref="SHAddToRecentDocs"/>.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetCurrentProcessExplicitAppUserModelID", ExactSpelling = true)]
        public static extern HRESULT SetCurrentProcessExplicitAppUserModelID([In] LPCWSTR AppID);

        /// <summary>
        /// <para>
        /// Notifies the system that an item has been accessed, for the purposes of tracking those items used most recently and most frequently.
        /// This function can also be used to clear all usage data.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shlobj_core/nf-shlobj_core-shaddtorecentdocs"/>
        /// </para>
        /// </summary>
        /// <param name="uFlags">
        /// A value from the <see cref="SHARD"/> enumeration that indicates the form of the information pointed to by the <paramref name="pv"/> parameter.
        /// </param>
        /// <param name="pv">
        /// <para>
        /// A pointer to data that identifies the item that has been accessed. The item can be specified in this parameter in one of the following forms:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// A null-terminated string that contains the path and file name of the item.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A PIDL that identifies the item's file object.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Windows 7 and later only.
        /// A <see cref="SHARDAPPIDINFO"/>, <see cref="SHARDAPPIDINFOIDLIST"/>, or <see cref="SHARDAPPIDINFOLINK"/> structure
        /// that identifies the item through an AppUserModelID.
        /// See Application User Model IDs (AppUserModelIDs) for more information.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Windows 7 and later only.
        /// An <see cref="IShellLink"/> object that identifies the item through a shortcut.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Set this parameter to <see cref="NULL"/> to clear all usage data on all items.
        /// </para>
        /// </param>
        /// <remarks>
        /// <para>
        /// The usage statistics gathered through calls to this method are used to determine lists of items accessed most recently and most frequently.
        /// These lists are seen in the Start menu and, in Windows 7 and later, in an application's Jump List.
        /// </para>
        /// <para>
        /// When this method is called, it affects the following areas:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Updates the Recent and Frequent lists for the associated application's Jump List.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Adds a shortcut to the user's Recent folder (<see cref="FOLDERID_Recent"/>, <see cref="CSIDL_RECENT"/>).
        /// This is reflected in the My Recent Documents (Windows XP) and Recent Items (Windows Vista and later) menu in the Start menu.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Adds a shortcut to the Classic Start menu's Documents submenu.
        /// (Note that the Classic Start menu option is not available in Windows 7 and later.)
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Items represented by an <see cref="IShellLink"/> are not added to the Recent folder,
        /// although they are reflected in an application's Jump List.
        /// </para>
        /// <para>
        /// In some cases, notably when a user opens an item through Windows Explorer or uses the common file dialog to open, save, or create a file,
        /// the Shell calls <see cref="SHAddToRecentDocs"/> on behalf of the application.
        /// An application that has a custom UI for selecting items should call <see cref="SHAddToRecentDocs"/> explicitly to ensure accurate statistics.
        /// Duplicate calls are accounted for by the system so there is no risk of skewing the data by doing so.
        /// </para>
        /// <para>
        /// Executable (.exe) files are filtered from the recently used documents list in Windows XP and later versions.
        /// Although <see cref="SHAddToRecentDocs"/> will accept the path of an executable file, that file will not appear in the Recent Items list.
        /// </para>
        /// <para>
        /// Folders are also accepted by <see cref="SHAddToRecentDocs"/>, but appear only in the Jump List for the Windows Explorer taskbar button.
        /// Folders do not appear in any other application's Jump List.
        /// </para>
        /// <para>
        /// In certain cases, <see cref="SHAddToRecentDocs"/> attempts to register an application
        /// to handle a file type that it is not registered to handle.
        /// This occurs under these circumstances:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// An application explicitly calls <see cref="SHAddToRecentDocs"/> with a file type that it is not registered to handle.
        /// This also applies to calls made to <see cref="SHAddToRecentDocs"/> by the common file dialog on behalf of the application,
        /// but only when the dialog is used to open a file, not when it is used to save one.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The user drops a file of a type that the application is not registered to handle on the application's taskbar button.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// This registration is done per-user.
        /// </para>
        /// <para>
        /// A set of requirements must be met for the registration to be accomplished successfully:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The application must be registered under <c>HKEY_CLASSES_ROOT\Applications</c>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// That registration cannot include the NoOpenWith value.
        /// See File Types for more details on NoOpenWith.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// That registration cannot supply data under a <c>SupportedTypes</c> subkey.
        /// See File Types for more details on the <c>SupportedTypes</c> subkey.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// The application's executable file cannot be listed in the KillList value found here:
        /// </para>
        /// <code>
        /// HKEY_LOCAL_MACHINE
        ///    Software
        ///       Microsoft
        ///          Windows
        ///             CurrentVersion
        ///                Explorer
        ///                   FileAssociation
        ///                      KillList
        /// </code>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Third party applications should not modify the KillList value. It should be regarded as read-only.
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// The application's <c>HKEY_CLASSES_ROOT\Applications</c> registration must have a set of default verbs
        /// defined under a <c>HKEY_CLASSES_ROOT\Applications\ExampleApp.exe\shell</c> subkey.
        /// </para>
        /// <para>
        /// If <see cref="SHAddToRecentDocs"/> is attempting the registration as the result of a drag-and-drop onto the taskbar button,
        /// the <c>shell</c> subkey is created if it does not already exist, as long as the existing application registration
        /// does not contain a NoOpenWith value and the application's executable is not listed in the KillList value.
        /// </para>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Suppressing Calls to <see cref="SHAddToRecentDocs"/>
        /// </para>
        /// <para>
        /// In versions of Windows before Windows 7, a file type could set the <see cref="FTA_NoRecentDocs"/> flag
        /// to prevent that file type from being added to the Recent folder.
        /// This mechanism is also supported under Windows 7 and later.
        /// See File Types for more information.
        /// </para>
        /// <para>
        /// <see cref="SHAddToRecentDocs"/> tracks document usage statistics through the verbs that are invoked to access those documents.
        /// Verbs supplied by registered <see cref="IContextMenu"/> handlers are tracked,
        /// those items appear in My Recent Documents (Windows XP) and Recent Items (Windows Vista).
        /// In Windows 7, the parent folders of the documents appear in the Jump List for the Windows Explorer taskbar button.
        /// However, the documents accessed through those <see cref="IContextMenu"/> verbs do not appear in application Jump Lists.
        /// For those items to appear in an application's Jump List, an application must call <see cref="SHAddToRecentDocs"/> explicitly.
        /// </para>
        /// <para>
        /// Prior to Windows 7, only the <c>open</c> verb resulted in a call to <see cref="SHAddToRecentDocs"/>.
        /// In Windows 7 and later, other verbs can also generate usage statistics.
        /// This information is used to make a Jump List's destinations more complete and accurate.
        /// </para>
        /// <para>
        /// However, some classes of file type association registrations or individual <see cref="IContextMenu"/> implementations
        /// are not appropriate for this sort of tracking.
        /// The point of usage tracking is to generate a list of items that the user is likely to want to access again.
        /// If a particular verb—<c>delete</c>, for instance—is inherently invoked on an item that the user will not access again,
        /// or is a secondary action such as a virus scan on a file, that verb is not appropriate for tracking.
        /// File type classes should remove themselves from this tracking through the registry entry NoRecentDocs.
        /// NoRecentDocs is of type <see cref="REG_SZ"/> and has no associated data.
        /// Its presence is all that is required to prevent the call to <see cref="SHAddToRecentDocs"/>.
        /// </para>
        /// <para>
        /// For example, context menu extensions and static verbs registered under <see cref="HKEY_CLASSES_ROOT"/> in classes
        /// such as "*", "AllFileSystemObjects", or "Folder" should not be tracked.
        /// In cases such as these, the NoRecentDocs entry is added to the root of the class key as shown here
        /// to suppress tracking of documents launched through any verb or extension registered to that class:
        /// </para>
        /// <code>
        /// HKEY_CLASSES_ROOT
        ///    AllFileSystemObjects
        ///       NoRecentDocs
        /// </code>
        /// <para>
        /// The NoRecentDocs entry is assigned by default to the *, <c>AllFileSystemObjects</c>, <c>Folder</c>,
        /// <c>Directory</c>, and <c>DesktopBackground</c> class subkeys.
        /// </para>
        /// <para>
        /// Individual <see cref="IContextMenu"/> implementations can opt out of tracking by adding a NoRecentDocs subkey
        /// to its Component Object Model (COM) object's registration, in its <c>shellex</c> subkey, as shown here:
        /// </para>
        /// <code>
        /// HKEY_CLASSES_ROOT
        ///    CLSID
        ///       {093C7AAB-5E72-454f-A91D-CA1BC991FCEC}
        ///          shellex
        ///             NoRecentDocs
        /// </code>
        /// <para>
        /// This subkey is not present by default on any <see cref="IContextMenu"/> implementation.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHAddToRecentDocs", ExactSpelling = true)]
        public static extern void SHAddToRecentDocs([In] SHARD uFlags, [In] LPCVOID pv);

        /// <summary>
        /// <para>
        /// Takes a pointer to a fully qualified item identifier list (PIDL), and returns a specified interface pointer on the parent object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shlobj_core/nf-shlobj_core-shbindtoparent"/>
        /// </para>
        /// </summary>
        /// <param name="pidl">
        /// The item's PIDL.
        /// </param>
        /// <param name="riid">
        /// The REFIID of one of the interfaces exposed by the item's parent object.
        /// </param>
        /// <param name="ppv">
        /// A pointer to the interface specified by <paramref name="riid"/>.
        /// You must release the object when you are finished.
        /// </param>
        /// <param name="ppidlLast">
        /// <para>
        /// The item's PIDL relative to the parent folder.
        /// This PIDL can be used with many of the methods supported by the parent folder's interfaces.
        /// If you set <paramref name="ppidlLast"/> to <see cref="NullRef{LPCITEMIDLIST}"/>, the PIDL is not returned.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// <see cref="SHBindToParent"/> does not allocate a new PIDL; it simply receives a pointer through this parameter.
        /// Therefore, you are not responsible for freeing this resource.
        /// </para>
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHBindToParent", ExactSpelling = true)]
        public static extern HRESULT SHBindToParent([In] LPCITEMIDLIST pidl, [In][Out] ref IID riid,
            [Out] out object ppv, [Out] out LPCITEMIDLIST ppidlLast);

        /// <summary>
        /// <para>
        /// Displays a dialog box that enables the user to select a Shell folder.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shlobj_core/nf-shlobj_core-shbrowseforfolderw"/>
        /// </para>
        /// </summary>
        /// <param name="lpbi">
        /// A pointer to a <see cref="BROWSEINFO"/> structure that contains information used to display the dialog box.
        /// </param>
        /// <returns>
        /// <para>
        /// Returns a PIDL that specifies the location of the selected folder relative to the root of the namespace.
        /// If the user chooses the Cancel button in the dialog box, the return value is <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// It is possible that the PIDL returned is that of a folder shortcut rather than a folder.
        /// For a full discussion of this case, see the Remarks section.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// For Windows Vista or later, it is recommended that you use <see cref="IFileDialog"/>
        /// with the <see cref="FOS_PICKFOLDERS"/> option rather than the <see cref="SHBrowseForFolder"/> function.
        /// This uses the Open Files dialog in pick folders mode and is the preferred implementation.
        /// </para>
        /// <para>
        /// You must initialize Component Object Model (COM) before you call <see cref="SHBrowseForFolder"/>.
        /// If you initialize COM using <see cref="CoInitializeEx"/>,
        /// you must set the <see cref="COINIT_APARTMENTTHREADED"/> flag in its dwCoInit parameter.
        /// You can also use <see cref="CoInitialize"/> or <see cref="OleInitialize"/>, which always use apartment threading.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// If COM is initialized using <see cref="CoInitializeEx"/> with the <see cref="COINIT_MULTITHREADED"/> flag,
        /// <see cref="SHBrowseForFolder"/> fails if the calling application
        /// uses the <see cref="BIF_USENEWUI"/> or <see cref="BIF_NEWDIALOGSTYLE"/> flag in the <see cref="BROWSEINFO"/> structure.
        /// It is the responsibility of the calling application to call <see cref="CoTaskMemFree"/> to free the IDList
        /// returned by <see cref="SHBrowseForFolder"/> when it is no longer needed.
        /// </para>
        /// <para>
        /// There are two styles of dialog box available.
        /// The older style is displayed by default and is not resizable.
        /// The newer style provides a number of additional features, including drag-and-drop capability
        /// within the dialog box, reordering, deletion, shortcut menus, the ability to create new folders, and other shortcut menu commands.
        /// Initially, it is larger than the older dialog box, but the user can resize it.
        /// To specify a dialog box using the newer style, set the <see cref="BIF_USENEWUI"/> flag
        /// in the <see cref="BROWSEINFO.ulFlags"/> member of the <see cref="BROWSEINFO"/> structure.
        /// </para>
        /// <para>
        /// If you implement a callback function, specified in the <see cref="BROWSEINFO.lpfn"/> member
        /// of the <see cref="BROWSEINFO"/> structure, you receive a handle to the dialog box.
        /// One use of this window handle is to modify the layout or contents of the dialog box.
        /// Because it is not resizable, modifying the older style dialog box is relatively straightforward.
        /// Modifying the newer style dialog box is much more difficult, and not recommended.
        /// Not only does it have a different size and layout than the old style,
        /// but its dimensions and the positions of its controls change every time it is resized by the user.
        /// </para>
        /// <para>
        /// If the <see cref="BIF_RETURNONLYFSDIRS"/> flag is set in the <see cref="BROWSEINFO.ulFlags"/> member
        /// of the <see cref="BROWSEINFO"/> structure, the OK button remains enabled for "\server" items, as well as "\server\share" and directory items.
        /// However, if the user selects a "\server" item,
        /// passing the PIDL returned by <see cref="SHBrowseForFolder"/> to <see cref="SHGetPathFromIDList"/> fails.
        /// </para>
        /// <para>
        /// Custom Filtering
        /// </para>
        /// <para>
        /// As of Windows XP, <see cref="SHBrowseForFolder"/> supports custom filtering on the contents of the dialog box.
        /// To create a custom filter, follow these steps.
        /// </para>
        /// <para>
        /// <list type="number">
        /// <item>
        /// <description>
        /// Set the <see cref="BIF_NEWDIALOGSTYLE"/> flag in the <see cref="BROWSEINFO.ulFlags"/> member
        /// of the <see cref="BROWSEINFO"/> structure pointed to by the <paramref name="lpbi"/> parameter.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Specify a callback function in the <see cref="BROWSEINFO.lpfn"/> member of that same <see cref="BROWSEINFO"/> structure.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Code the callback function to receive the <see cref="BFFM_INITIALIZED"/> and <see cref="BFFM_IUNKNOWN"/> messages.
        /// On receipt of the <see cref="BFFM_IUNKNOWN"/> message,
        /// the callback function's lParam parameter contains a pointer to the dialog box's implementation of <see cref="IUnknown"/>.
        /// Call <see cref="IUnknown.QueryInterface"/> on that <see cref="IUnknown"/> to obtain a pointer to an instance of <see cref="IFolderFilterSite"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Create an object that implements <see cref="IFolderFilter"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Call <see cref="IFolderFilterSite.SetFilter"/>, passing to it a pointer to your <see cref="IFolderFilter"/>.
        /// <see cref="IFolderFilter"/> methods can then be used to include and exclude items from the tree.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Once the filter is created, the <see cref="IFolderFilterSite"/> interface is no longer needed.
        /// Call <c>IFolderFilterSite.Release</c> if you have no further use for it.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Dealing With Shortcuts
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This section applies to only Windows 2000 and earlier systems.
        /// By default, Windows XP and later systems return the PIDL of a shortcut's target rather than the shortcut itself,
        /// as long as the <see cref="BIF_NOTRANSLATETARGETS"/> flag is not set in the <see cref="BROWSEINFO"/> structure.
        /// If <see cref="SHBrowseForFolder"/> returns a PIDL to a shortcut,
        /// sending that PIDL to <see cref="SHGetPathFromIDList"/> returns the path of the shortcut itself rather than the path of its target.
        /// The path to the shortcut's target can be obtained by using the <see cref="IShellLink"/> interface as shown in this example.
        /// </para>
        /// <code>
        /// #include
        /// // Macros for interface casts
        /// #ifdef __cplusplus
        /// #define IID_PPV_ARG(IType, ppType) IID_##IType, reinterpret_cast(static_cast(ppType))
        /// #else
        /// #define IID_PPV_ARG(IType, ppType) &amp;IID_##IType, (void**)(ppType)
        /// #endif
        /// // Retrieves the UIObject interface for the specified full PIDL
        /// STDAPI SHGetUIObjectFromFullPIDL(LPCITEMIDLIST pidl, HWND hwnd, REFIID riid, void** ppv)
        /// {
        ///     LPCITEMIDLIST pidlChild;
        ///     IShellFolder* psf;
        /// 
        ///     *ppv = NULL;
        /// 
        ///     HRESULT hr = SHBindToParent(pidl, IID_PPV_ARG(IShellFolder, &amp;psf), &amp;pidlChild);
        ///     if (SUCCEEDED(hr))
        ///     {
        ///         hr = psf->GetUIObjectOf(hwnd, 1, &amp;pidlChild, riid, NULL, ppv);
        ///         psf->Release();
        ///     }
        ///     return hr;
        ///  }
        ///  
        /// #define ILSkip(pidl, cb)       ((LPITEMIDLIST)(((BYTE*)(pidl))+cb))
        /// #define ILNext(pidl)           ILSkip(pidl, (pidl)->mkid.cb)
        /// HRESULT SHILClone(LPCITEMIDLIST pidl, LPITEMIDLIST* ppidl)
        /// {
        ///     DWORD cbTotal = 0;
        ///     if (pidl)
        ///     {
        ///         LPCITEMIDLIST pidl_temp = pidl;
        ///         cbTotal += sizeof(pidl_temp->mkid.cb);
        ///         
        ///         while (pidl_temp->mkid.cb)
        ///         {
        ///             cbTotal += pidl_temp->mkid.cb;
        ///             pidl_temp += ILNext(pidl_temp);
        ///         }
        ///     }
        ///     *ppidl = (LPITEMIDLIST)CoTaskMemAlloc(cbTotal);
        ///     if (*ppidl)
        ///         CopyMemory(*ppidl, pidl, cbTotal);
        ///     return *ppidl ? S_OK : E_OUTOFMEMORY;
        /// }
        /// 
        /// // Get the target PIDL for a folder PIDL. This also deals with cases of a folder
        /// // shortcut or an alias to a real folder.
        /// STDAPI SHGetTargetFolderIDList(LPCITEMIDLIST pidlFolder, LPITEMIDLIST* ppidl)
        /// {
        ///     IShellLink* psl;
        ///     
        ///     *ppidl = NULL;
        ///     
        ///     HRESULT hr = SHGetUIObjectFromFullPIDL(pidlFolder, NULL, IID_PPV_ARG(IShellLink, &amp;psl));
        ///     
        ///     if (SUCCEEDED(hr))
        ///     {
        ///         hr = psl->GetIDList(ppidl);
        ///         psl->Release();
        ///     }
        ///     
        ///     // It's not a folder shortcut so get the PIDL normally.
        ///     if (FAILED(hr))
        ///         hr = SHILClone(pidlFolder, ppidl);
        ///         
        /// 
        ///     return hr;
        ///  }
        ///  
        /// // Get the target folder for a folder PIDL. This deals with cases where a folder
        /// // is an alias to a real folder, folder shortcuts, the My Documents folder, and 
        /// // other items of that nature.
        /// STDAPI SHGetTargetFolderPath(LPCITEMIDLIST pidlFolder, LPWSTR pszPath, UINT cchPath)
        /// {
        ///     LPITEMIDLIST pidlTarget;
        ///     
        ///     *pszPath = 0;
        ///     
        ///     HRESULT hr = SHGetTargetFolderIDList(pidlFolder, &amp;pidlTarget);
        ///     
        ///     if (SUCCEEDED(hr))
        ///     {
        ///         SHGetPathFromIDListW(pidlTarget, pszPath);   // Make sure it is a path
        ///         CoTaskMemFree(pidlTarget);
        ///     }
        ///     
        ///     return *pszPath ? S_OK : E_FAIL;
        /// }
        /// // Retrieves the UIObject interface for the specified full PIDLstatic 
        /// HRESULT SHGetUIObjectFromFullPIDL(LPCITEMIDLIST pidl, HWND hwnd, REFIID riid, void** ppv)
        /// {
        ///     LPCITEMIDLIST pidlChild;
        ///     IShellFolder* psf;
        ///     *ppv = NULL;
        ///     
        ///     HRESULT hr = SHBindToParent(pidl, IID_IShellFolder, (LPVOID*)&amp;psf, &amp;pidlChild);
        ///     if (SUCCEEDED(hr))
        ///     {
        ///         hr = psf->GetUIObjectOf(hwnd, 1, &amp;pidlChild, riid, NULL, ppv);
        ///         psf->Release();
        ///     }
        ///     return hr;
        ///     }
        ///     
        /// static HRESULT SHILClone(LPCITEMIDLIST pidl, LPITEMIDLIST* ppidl)
        /// {
        ///     DWORD cbTotal = 0;
        ///     if (pidl)
        ///     {
        ///         LPCITEMIDLIST pidl_temp = pidl;
        ///         cbTotal += pidl_temp->mkid.cb;
        ///         
        ///         while (pidl_temp->mkid.cb)
        ///         {
        ///             cbTotal += pidl_temp->mkid.cb;
        ///             pidl_temp = ILNext(pidl_temp);
        ///          }
        ///      }
        ///      
        ///      *ppidl = (LPITEMIDLIST)CoTaskMemAlloc(cbTotal);
        ///      if (*ppidl)
        ///         CopyMemory(*ppidl, pidl, cbTotal);
        ///         
        ///      return *ppidl ? S_OK : E_OUTOFMEMORY;
        ///      }
        ///      
        /// // Get the target PIDL for a folder PIDL. This also deals with cases of a folder
        /// // shortcut or an alias to a real folder.
        /// static HRESULT SHGetTargetFolderIDList(LPCITEMIDLIST pidlFolder, LPITEMIDLIST* ppidl)
        /// {
        ///     IShellLink* psl;
        ///     *ppidl = NULL;
        ///     
        ///     HRESULT hr = SHGetUIObjectFromFullPIDL(pidlFolder, NULL, IID_IShellLink, (LPVOID*)&amp;psl);
        ///     if (SUCCEEDED(hr))
        ///     {
        ///         hr = psl->GetIDList(ppidl);
        ///         psl->Release();
        ///     }
        ///
        ///     // It's not a folder shortcut so get the PIDL normally.
        ///     if (FAILED(hr))
        ///         hr = SHILClone(pidlFolder, ppidl);
        ///     return hr;
        /// }
        /// 
        /// // Get the target folder for a folder PIDL. This deals with cases where a folder
        /// // is an alias to a real folder, folder shortcuts, the My Documents folder, 
        /// // and so on.
        /// STDAPI SHGetTargetFolderPath(LPCITEMIDLIST pidlFolder, LPWSTR pszPath, UINT cchPath)
        /// {
        ///     LPITEMIDLIST pidlTarget;
        ///     *pszPath = 0;
        ///     
        ///     HRESULT hr = SHGetTargetFolderIDList(pidlFolder, &amp;pidlTarget);
        ///     if (SUCCEEDED(hr))
        ///     {
        ///         SHGetPathFromIDListW(pidlTarget, pszPath);
        ///         
        ///         // Make sure it is a path
        ///         CoTaskMemFree(pidlTarget);
        ///      }
        ///      
        ///     return *pszPath ? S_OK : E_FAIL;
        /// }
        /// </code>
        /// The shlobj_core.h header defines <see cref="SHBrowseForFolder"/> as an alias which automatically selects
        /// the ANSI or Unicode version of this function based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead
        /// to mismatches that result in compilation or runtime errors.
        /// For more information, see Conventions for Function Prototypes.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHBrowseForFolderW", ExactSpelling = true)]
        public static extern LPITEMIDLIST SHBrowseForFolder([In] in BROWSEINFO lpbi);

        /// <summary>
        /// <para>
        /// Notifies the system of an event that an application has performed.
        /// An application should use this function if it performs an action that may affect the Shell.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shlobj_core/nf-shlobj_core-shchangenotify"/>
        /// </para>
        /// </summary>
        /// <param name="wEventId">
        /// <para>
        /// Describes the event that has occurred.
        /// Typically, only one event is specified at a time.
        /// If more than one event is specified, the values contained in the <paramref name="dwItem1"/> and <paramref name="dwItem2"/> parameters
        /// must be the same, respectively, for all specified events.
        /// This parameter can be one or more of the following values:
        /// </para>
        /// <para>
        /// <see cref="SHCNE_ALLEVENTS"/>
        /// </para>
        /// <para>
        /// All events have occurred.
        /// </para>
        /// <para>
        /// <see cref="SHCNE_ASSOCCHANGED"/>
        /// </para>
        /// <para>
        /// A file type association has changed.
        /// <see cref="SHCNF_IDLIST"/> must be specified in the <paramref name="uFlags"/> parameter.
        /// <paramref name="dwItem1"/> and <paramref name="dwItem2"/> are not used and must be <see cref="NULL"/>.
        /// This event should also be sent for registered protocols.
        /// </para>
        /// <para>
        /// <see cref="SHCNE_ATTRIBUTES"/>
        /// </para>
        /// <para>
        /// The attributes of an item or folder have changed.
        /// <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be specified in <paramref name="uFlags"/>.
        /// <paramref name="dwItem1"/> contains the item or folder that has changed.
        /// <paramref name="dwItem2"/> is not used and should be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// <see cref="SHCNE_CREATE"/>
        /// </para>
        /// <para>
        /// A nonfolder item has been created.
        /// <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be specified in <paramref name="uFlags"/>.
        /// <paramref name="dwItem1"/> contains the item that was created.
        /// <paramref name="dwItem2"/> is not used and should be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// <see cref="SHCNE_DELETE"/>
        /// </para>
        /// <para>
        /// A nonfolder item has been deleted.
        /// <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be specified in <paramref name="uFlags"/>.
        /// <paramref name="dwItem1"/> contains the item that was deleted.
        /// <paramref name="dwItem2"/> is not used and should be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// <see cref="SHCNE_DRIVEADD"/>
        /// </para>
        /// <para>
        /// A drive has been added.
        /// <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be specified in <paramref name="uFlags"/>.
        /// <paramref name="dwItem1"/> contains the root of the drive that was added.
        /// <paramref name="dwItem2"/> is not used and should be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// <see cref="SHCNE_DRIVEADDGUI"/>
        /// </para>
        /// <para>
        /// Windows XP and later: Not used.
        /// </para>
        /// <para>
        /// <see cref="SHCNE_DRIVEREMOVED"/>
        /// </para>
        /// <para>
        /// A drive has been removed.
        /// <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be specified in <paramref name="uFlags"/>.
        /// <paramref name="dwItem1"/> contains the root of the drive that was removed.
        /// <paramref name="dwItem2"/> is not used and should be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// <see cref="SHCNE_EXTENDED_EVENT"/>
        /// </para>
        /// <para>
        /// Not currently used.
        /// </para>
        /// <para>
        /// <see cref="SHCNE_FREESPACE"/>
        /// </para>
        /// <para>
        /// The amount of free space on a drive has changed.
        /// <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be specified in <paramref name="uFlags"/>.
        /// <paramref name="dwItem1"/> contains the root of the drive on which the free space changed.
        /// <paramref name="dwItem2"/> is not used and should be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// <see cref="SHCNE_MEDIAINSERTED"/>
        /// </para>
        /// <para>
        /// Storage media has been inserted into a drive.
        /// <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be specified in <paramref name="uFlags"/>.
        /// <paramref name="dwItem1"/> contains the root of the drive that contains the new media.
        /// <paramref name="dwItem2"/> is not used and should be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// <see cref="SHCNE_MEDIAREMOVED"/>
        /// </para>
        /// <para>
        /// Storage media has been removed from a drive.
        /// <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be specified in <paramref name="uFlags"/>.
        /// <paramref name="dwItem1"/> contains the root of the drive from which the media was removed.
        /// <paramref name="dwItem2"/> is not used and should be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// <see cref="SHCNE_MKDIR"/>
        /// </para>
        /// <para>
        /// A folder has been created.
        /// <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be specified in <paramref name="uFlags"/>.
        /// <paramref name="dwItem1"/> contains the folder that was created.
        /// <paramref name="dwItem2"/> is not used and should be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// <see cref="SHCNE_NETSHARE"/>
        /// </para>
        /// <para>
        /// A folder on the local computer is being shared via the network.
        /// <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be specified in <paramref name="uFlags"/>.
        /// <paramref name="dwItem1"/> contains the folder that is being shared.
        /// <paramref name="dwItem2"/> is not used and should be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// <see cref="SHCNE_NETUNSHARE"/>
        /// </para>
        /// <para>
        /// A folder on the local computer is no longer being shared via the network.
        /// <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be specified in <paramref name="uFlags"/>.
        /// <paramref name="dwItem1"/> contains the folder that is no longer being shared.
        /// <paramref name="dwItem2"/> is not used and should be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// <see cref="SHCNE_RENAMEFOLDER"/>
        /// </para>
        /// <para>
        /// The name of a folder has changed.
        /// <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be specified in <paramref name="uFlags"/>.
        /// <paramref name="dwItem1"/> contains the previous PIDL or name of the folder.
        /// <paramref name="dwItem2"/> contains the new PIDL or name of the folder.
        /// </para>
        /// <para>
        /// <see cref="SHCNE_RENAMEITEM"/>
        /// </para>
        /// <para>
        /// The name of a nonfolder item has changed.
        /// <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be specified in <paramref name="uFlags"/>.
        /// <paramref name="dwItem1"/> contains the previous PIDL or name of the item.
        /// <paramref name="dwItem2"/> contains the new PIDL or name of the item.
        /// </para>
        /// <para>
        /// <see cref="SHCNE_RMDIR"/>
        /// </para>
        /// <para>
        /// A folder has been removed.
        /// <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be specified in <paramref name="uFlags"/>.
        /// <paramref name="dwItem1"/> contains the folder that was removed.
        /// <paramref name="dwItem2"/> is not used and should be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// <see cref="SHCNE_SERVERDISCONNECT"/>
        /// </para>
        /// <para>
        /// The computer has disconnected from a server.
        /// <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be specified in <paramref name="uFlags"/>.
        /// <paramref name="dwItem1"/> contains the server from which the computer was disconnected.
        /// <paramref name="dwItem2"/> is not used and should be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// <see cref="SHCNE_UPDATEDIR"/>
        /// </para>
        /// <para>
        /// The contents of an existing folder have changed, but the folder still exists and has not been renamed.
        /// <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be specified in <paramref name="uFlags"/>.
        /// <paramref name="dwItem1"/> contains the folder that has changed.
        /// <paramref name="dwItem2"/> is not used and should be <see cref="NULL"/>.
        /// If a folder has been created, deleted, or renamed,
        /// use <see cref="SHCNE_MKDIR"/>, <see cref="SHCNE_RMDIR"/>, or <see cref="SHCNE_RENAMEFOLDER"/>, respectively.
        /// </para>
        /// <para>
        /// <see cref="SHCNE_UPDATEIMAGE"/>
        /// </para>
        /// <para>
        /// An image in the system image list has changed.
        /// <see cref="SHCNF_DWORD"/> must be specified in <paramref name="uFlags"/>.
        /// </para>
        /// <para>
        /// <paramref name="dwItem2"/> contains the index in the system image list that has changed.
        /// <paramref name="dwItem1"/> is not used and should be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// <see cref="SHCNE_UPDATEITEM"/>
        /// </para>
        /// <para>
        /// An existing item (a folder or a nonfolder) has changed, but the item still exists and has not been renamed.
        /// <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be specified in <paramref name="uFlags"/>.
        /// <paramref name="dwItem1"/> contains the item that has changed.
        /// <paramref name="dwItem2"/> is not used and should be <see cref="NULL"/>.
        /// If a nonfolder item has been created, deleted, or renamed,
        /// use <see cref="SHCNE_CREATE"/>, <see cref="SHCNE_DELETE"/>, or <see cref="SHCNE_RENAMEITEM"/>, respectively, instead.
        /// </para>
        /// <para>
        /// <see cref="SHCNE_DISKEVENTS"/>
        /// </para>
        /// <para>
        /// Specifies a combination of all of the disk event identifiers.
        /// </para>
        /// <para>
        /// <see cref="SHCNE_GLOBALEVENTS"/>
        /// </para>
        /// <para>
        /// Specifies a combination of all of the global event identifiers.
        /// </para>
        /// <para>
        /// <see cref="SHCNE_INTERRUPT"/>
        /// </para>
        /// <para>
        /// The specified event occurred as a result of a system interrupt.
        /// As this value modifies other event values, it cannot be used alone.
        /// </para>
        /// </param>
        /// <param name="uFlags">
        /// <para>
        /// Flags that, when combined bitwise with <see cref="SHCNF_TYPE"/>,
        /// indicate the meaning of the <paramref name="dwItem1"/> and <paramref name="dwItem2"/> parameters.
        /// The <paramref name="uFlags"/> parameter must be one of the following values.
        /// </para>
        /// <para>
        /// <see cref="SHCNF_DWORD"/>
        /// </para>
        /// <para>
        /// The <paramref name="dwItem1"/> and <paramref name="dwItem2"/> parameters are <see cref="DWORD"/> values.
        /// </para>
        /// <para>
        /// <see cref="SHCNF_IDLIST"/>
        /// </para>
        /// <para>
        /// <paramref name="dwItem1"/> and <paramref name="dwItem2"/> are the addresses of <see cref="ITEMIDLIST"/> structures
        /// that represent the item(s) affected by the change.
        /// Each <see cref="ITEMIDLIST"/> must be relative to the desktop folder.
        /// </para>
        /// <para>
        /// <see cref="SHCNF_PATH"/>
        /// </para>
        /// <para>
        /// <paramref name="dwItem1"/> and <paramref name="dwItem2"/> are the addresses of null-terminated strings
        /// of maximum length <see cref="MAX_PATH"/> that contain the full path names of the items affected by the change.
        /// </para>
        /// <para>
        /// <see cref="SHCNF_PRINTER"/>
        /// </para>
        /// <para>
        /// <paramref name="dwItem1"/> and <paramref name="dwItem2"/> are the addresses of null-terminated strings
        /// that represent the friendly names of the printer(s) affected by the change.
        /// </para>
        /// <para>
        /// <see cref="SHCNF_FLUSH"/>
        /// </para>
        /// <para>
        /// The function should not return until the notification has been delivered to all affected components.
        /// As this flag modifies other data-type flags, it cannot be used by itself.
        /// </para>
        /// <para>
        /// <see cref="SHCNF_FLUSHNOWAIT"/>
        /// </para>
        /// <para>
        /// The function should begin delivering notifications to all affected components
        /// but should return as soon as the notification process has begun.
        /// As this flag modifies other data-type flags, it cannot by used by itself.
        /// This flag includes <see cref="SHCNF_FLUSH"/>.
        /// </para>
        /// <para>
        /// <see cref="SHCNF_NOTIFYRECURSIVE"/>
        /// </para>
        /// <para>
        /// Notify clients registered for all children.
        /// </para>
        /// </param>
        /// <param name="dwItem1">
        /// Optional. First event-dependent value.
        /// </param>
        /// <param name="dwItem2">
        /// Optional. Second event-dependent value.
        /// </param>
        /// <remarks>
        /// <para>
        /// Applications that register new handlers of any type must call <see cref="SHChangeNotify"/> with the <see cref="SHCNE_ASSOCCHANGED"/> flag
        /// to instruct the Shell to invalidate the icon and thumbnail cache.
        /// This will also load new icon and thumbnail handlers that have been registered.
        /// Note, however, that icon overlay handlers are not reloaded.
        /// </para>
        /// <para>
        /// The strings pointed to by <paramref name="dwItem1"/> and <paramref name="dwItem2"/> can be either ANSI or Unicode.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHChangeNotify", ExactSpelling = true)]
        public static extern void SHChangeNotify([In] ShellChangeNotifyEvents wEventId, [In] ShellChangeNotifyFlags uFlags, [In] LPCVOID dwItem1, [In] LPCVOID dwItem2);

        /// <summary>
        /// <para>
        /// Creates a new file system folder, with optional security attributes.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shlobj_core/nf-shlobj_core-shcreatedirectoryexw"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to a parent window.
        /// This parameter can be set to <see cref="NULL"/> if no user interface will be displayed.
        /// </param>
        /// <param name="pszPath">
        /// A pointer to a null-terminated string specifying the fully qualified path of the directory.
        /// This string is of maximum length of 248 characters, including the terminating null character.
        /// </param>
        /// <param name="psa">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure with the directory's security attribute.
        /// Set this parameter to <see cref="NullRef{SECURITY_ATTRIBUTES}"/> if no security attributes need to be set.
        /// </param>
        /// <returns>
        /// <para>
        /// Returns <see cref="ERROR_SUCCESS"/> if successful.
        /// If the operation fails, other error codes can be returned, including those listed here.
        /// For values not specifically listed, see System Error Codes.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_BAD_PATHNAME"/>
        /// </term>
        /// <term>
        /// The <paramref name="pszPath"/> parameter was set to a relative path.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_FILENAME_EXCED_RANGE"/>
        /// </term>
        /// <term>
        /// The path pointed to by <paramref name="pszPath"/> is too long.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_PATH_NOT_FOUND"/>
        /// </term>
        /// <term>
        /// The system cannot find the path pointed to by <paramref name="pszPath"/>. The path may contain an invalid entry.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_FILE_EXISTS"/>
        /// </term>
        /// <term>
        /// The directory exists.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_ALREADY_EXISTS"/>
        /// </term>
        /// <term>
        /// The directory exists.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_CANCELLED"/>
        /// </term>
        /// <term>
        /// The user canceled the operation.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function creates a file system folder whose fully qualified path is given by <paramref name="pszPath"/>.
        /// If one or more of the intermediate folders do not exist, they are created as well.
        /// <see cref="SHCreateDirectoryEx"/> also verifies that the files are visible.
        /// If they are not visible, expect one of the following:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// If <paramref name="hwnd"/> is set to a valid window handle,
        /// a message box is displayed warning the user that he or she might not be able to access the files.
        /// If the user chooses not to proceed, the function returns <see cref="ERROR_CANCELLED"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If <paramref name="hwnd"/> is set to <see cref="NULL"/>,
        /// no user interface is displayed and the function returns <see cref="ERROR_CANCELLED"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [Obsolete("This function is available through Windows XP Service Pack 2 (SP2) and Windows Server 2003. " +
            "It might be altered or unavailable in subsequent versions of Windows.")]
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHCreateDirectoryExW", ExactSpelling = true)]
        public static extern int SHCreateDirectoryEx([In] HWND hwnd, [In] LPCWSTR pszPath, [In] in SECURITY_ATTRIBUTES psa);

        /// <summary>
        /// <para>
        /// Provides a default handler to extract an icon from a file.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shlobj_core/nf-shlobj_core-shdefextracticonw"/>
        /// </para>
        /// </summary>
        /// <param name="pszIconFile">
        /// A pointer to a null-terminated buffer that contains the path and name of the file from which the icon is extracted.
        /// </param>
        /// <param name="iIndex">
        /// The location of the icon within the file named in <paramref name="pszIconFile"/>.
        /// If this is a positive number, it refers to the zero-based position of the icon in the file.
        /// For instance, 0 refers to the 1st icon in the resource file and 2 refers to the 3rd.
        /// If this is a negative number, it refers to the icon's resource ID.
        /// </param>
        /// <param name="uFlags">
        /// <para>
        /// A flag that controls the icon extraction.
        /// </para>
        /// <para>
        /// <see cref="GIL_SIMULATEDOC"/>
        /// </para>
        /// <para>
        /// Overlays the extracted icon on the default document icon to create the final icon.
        /// This icon can be used when no more appropriate icon can be found or retrieved.
        /// </para>
        /// </param>
        /// <param name="phiconLarge">
        /// A pointer to an <see cref="HICON"/> that, when this function returns successfully,
        /// receives the handle of the large version of the icon specified in the LOWORD of <paramref name="nIconSize"/>.
        /// This value can be <see cref="NullRef{HICON}"/>.
        /// </param>
        /// <param name="phiconSmall">
        /// A pointer to an <see cref="HICON"/> that, when this function returns successfully,
        /// receives the handle of the small version of the icon specified in the HIWORD of <paramref name="nIconSize"/>.
        /// </param>
        /// <param name="nIconSize">
        /// A value that contains the large icon size in its LOWORD and the small icon size in its HIWORD.
        /// Size is measured in pixels. Pass 0 to specify default large and small sizes.
        /// </param>
        /// <returns>
        /// <para>
        /// This function can return one of these values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// Success.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="S_FALSE"/>
        /// </term>
        /// <term>
        /// The requested icon is not present.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_FAIL"/>
        /// </term>
        /// <term>
        /// The file cannot be accessed, or is being accessed through a slow link.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// It is the responsibility of the caller to free the icon resources created through this function when they are no longer needed.
        /// This can be done through the <see cref="DestroyIcon"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHDefExtractIconW", ExactSpelling = true)]
        public static extern HRESULT SHDefExtractIcon([In] LPCWSTR pszIconFile, [In] int iIndex, [In] UINT uFlags,
            [Out] out HICON phiconLarge, [Out] out HICON phiconSmall, [In] UINT nIconSize);

        /// <summary>
        /// <para>
        /// Performs an operation on a specified file.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shellapi/nf-shellapi-shellexecutew"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the parent window used for displaying a UI or error messages.
        /// This value can be <see cref="NULL"/> if the operation is not associated with a window.
        /// </param>
        /// <param name="lpOperation">
        /// <para>
        /// A pointer to a null-terminated string, referred to in this case as a verb, that specifies the action to be performed.
        /// The set of available verbs depends on the particular file or folder.
        /// Generally, the actions available from an object's shortcut menu are available verbs.
        /// The following verbs are commonly used:
        /// </para>
        /// <para>
        /// edit
        /// </para>
        /// <para>
        /// Launches an editor and opens the document for editing.
        /// If <paramref name="lpFile"/> is not a document file, the function will fail.
        /// </para>
        /// <para>
        /// explore
        /// </para>
        /// <para>
        /// Explores a folder specified by <paramref name="lpFile"/>.
        /// </para>
        /// <para>
        /// find
        /// </para>
        /// <para>
        /// Initiates a search beginning in the directory specified by <paramref name="lpDirectory"/>.
        /// </para>
        /// <para>
        /// open
        /// </para>
        /// <para>
        /// Opens the item specified by the <paramref name="lpFile"/> parameter.
        /// The item can be a file or folder.
        /// </para>
        /// <para>
        /// print
        /// </para>
        /// <para>
        /// Prints the file specified by <paramref name="lpFile"/>.
        /// If <paramref name="lpFile"/> is not a document file, the function fails.
        /// </para>
        /// <para>
        /// runas
        /// </para>
        /// <para>
        /// Launches an application as Administrator.
        /// User Account Control (UAC) will prompt the user for consent to run the application elevated
        /// or enter the credentials of an administrator account used to run the application.
        /// </para>
        /// <para>
        /// <see cref="NULL"/>
        /// </para>
        /// <para>
        /// The default verb is used, if available.
        /// If not, the "open" verb is used. If neither verb is available, the system uses the first verb listed in the registry.
        /// </para>
        /// </param>
        /// <param name="lpFile">
        /// <para>
        /// A pointer to a null-terminated string that specifies the file or object on which to execute the specified verb.
        /// To specify a Shell namespace object, pass the fully qualified parse name.
        /// Note that not all verbs are supported on all objects.
        /// For example, not all document types support the "print" verb.
        /// If a relative path is used for the <paramref name="lpDirectory"/> parameter do not use a relative path for <paramref name="lpFile"/>.
        /// </para>
        /// <para>
        /// If <paramref name="lpFile"/> specifies an executable file and "open" or "runas" verbs are used in <paramref name="lpOperation"/>,
        /// the command line string of the launched process includes a trailing whitespace character.
        /// </para>
        /// </param>
        /// <param name="lpParameters">
        /// If <paramref name="lpFile"/> specifies an executable file, this parameter is a pointer to a null-terminated string
        /// that specifies the parameters to be passed to the application.
        /// The format of this string is determined by the verb that is to be invoked.
        /// If <paramref name="lpFile"/> specifies a document file, <paramref name="lpParameters"/> should be <see cref="NULL"/>.
        /// </param>
        /// <param name="lpDirectory">
        /// A pointer to a null-terminated string that specifies the default (working) directory for the action.
        /// If this value is <see cref="NULL"/> the current working directory is used.
        /// If a relative path is provided at <paramref name="lpFile"/>, do not use a relative path for <paramref name="lpDirectory"/>.
        /// </param>
        /// <param name="nShowCmd">
        /// The flags that specify how an application is to be displayed when it is opened.
        /// If <paramref name="lpFile"/> specifies a document file, the flag is simply passed to the associated application.
        /// It is up to the application to decide how to handle it.
        /// It can be any of the values that can be specified in the nCmdShow parameter for the <see cref="ShowWindow"/> function.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, it returns a value greater than 32.
        /// If the function fails, it returns an error value that indicates the cause of the failure.
        /// The return value is cast as an <see cref="HINSTANCE"/> for backward compatibility with 16-bit Windows applications.
        /// It is not a true <see cref="HINSTANCE"/>, however.
        /// It can be cast only to an <see cref="INT_PTR"/> and compared to either 32 or the following error codes below.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0
        /// </term>
        /// <term>
        /// The operating system is out of memory or resources.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_FILE_NOT_FOUND"/>
        /// </term>
        /// <term>
        /// The specified file was not found.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_PATH_NOT_FOUND"/>
        /// </term>
        /// <term>
        /// The specified path was not found.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_BAD_FORMAT"/>
        /// </term>
        /// <term>
        /// The .exe file is invalid (non-Win32 .exe or error in .exe image).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SE_ERR_ACCESSDENIED"/>
        /// </term>
        /// <term>
        /// The operating system denied access to the specified file.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SE_ERR_ASSOCINCOMPLETE"/>
        /// </term>
        /// <term>
        /// The file name association is incomplete or invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SE_ERR_DDEBUSY"/>
        /// </term>
        /// <term>
        /// The DDE transaction could not be completed because other DDE transactions were being processed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SE_ERR_DDEFAIL"/>
        /// </term>
        /// <term>
        /// The DDE transaction failed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SE_ERR_DDETIMEOUT"/>
        /// </term>
        /// <term>
        /// The DDE transaction could not be completed because the request timed out.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SE_ERR_DLLNOTFOUND"/>
        /// </term>
        /// <term>
        /// The specified DLL was not found.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SE_ERR_FNF"/>
        /// </term>
        /// <term>
        /// The specified file was not found.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SE_ERR_NOASSOC"/>
        /// </term>
        /// <term>
        /// There is no application associated with the given file name extension.
        /// This error will also be returned if you attempt to print a file that is not printable.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SE_ERR_OOM"/>
        /// </term>
        /// <term>
        /// There was not enough memory to complete the operation.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SE_ERR_PNF"/>
        /// </term>
        /// <term>
        /// The specified path was not found.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SE_ERR_SHARE"/>
        /// </term>
        /// <term>
        /// A sharing violation occurred.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Call <see cref="GetLastError"/> for extended error information.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Because <see cref="ShellExecute"/> can delegate execution to Shell extensions
        /// (data sources, context menu handlers, verb implementations)
        /// that are activated using Component Object Model (COM), COM should be initialized before <see cref="ShellExecute"/> is called.
        /// Some Shell extensions require the COM single-threaded apartment (STA) type.
        /// In that case, COM should be initialized as shown here:
        /// </para>
        /// <code>
        /// CoInitializeEx(NULL, COINIT_APARTMENTTHREADED | COINIT_DISABLE_OLE1DDE)
        /// </code>
        /// <para>
        /// There are certainly instances where <see cref="ShellExecute"/> does not use one of these types of Shell extension
        /// and those instances would not require COM to be initialized at all.
        /// Nonetheless, it is good practice to always initialize COM before using this function.
        /// </para>
        /// <para>
        /// This method allows you to execute any commands in a folder's shortcut menu or stored in the registry.
        /// </para>
        /// <para>
        /// To open a folder, use either of the following calls:
        /// </para>
        /// <code>
        /// ShellExecute(handle, NULL, &lt;fully_qualified_path_to_folder&gt;, NULL, NULL, SW_SHOWNORMAL);
        /// </code>
        /// <para>
        /// or
        /// </para>
        /// <code>
        /// ShellExecute(handle, "open", &lt;fully_qualified_path_to_folder&gt;, NULL, NULL, SW_SHOWNORMAL);
        /// </code>
        /// <para>
        /// To explore a folder, use the following call:
        /// </para>
        /// <code>
        /// ShellExecute(handle, "explore", &lt;fully_qualified_path_to_folder&gt;, NULL, NULL, SW_SHOWNORMAL);
        /// </code>
        /// <para>
        /// To launch the Shell's Find utility for a directory, use the following call.
        /// </para>
        /// <code>
        /// ShellExecute(handle, "find", &lt;fully_qualified_path_to_folder&gt;, NULL, NULL, 0);
        /// </code>
        /// <para>
        /// If <paramref name="lpOperation"/> is <see cref="NULL"/>, the function opens the file specified by <paramref name="lpFile"/>.
        /// If <paramref name="lpOperation"/> is "open" or "explore", the function attempts to open or explore the folder.
        /// </para>
        /// <para>
        /// To obtain information about the application that is launched
        /// as a result of calling <see cref="ShellExecute"/>, use <see cref="ShellExecuteEx"/>.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// The Launch folder windows in a separate process setting in Folder Options affects <see cref="ShellExecute"/>.
        /// If that option is disabled (the default setting), <see cref="ShellExecute"/> uses an open Explorer window rather than launch a new one.
        /// If no Explorer window is open, <see cref="ShellExecute"/> launches a new one.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShellExecuteW", ExactSpelling = true)]
        public static extern HINSTANCE ShellExecute([In] HWND hwnd, [In] LPCWSTR lpOperation, [In] LPCWSTR lpFile, [In] LPCWSTR lpParameters,
            [In] LPCWSTR lpDirectory, [In] ShowWindowCommands nShowCmd);

        /// <summary>
        /// <para>
        /// Performs an operation on a specified file.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shellapi/nf-shellapi-shellexecuteexw"/>
        /// </para>
        /// </summary>
        /// <param name="pExecInfo">
        /// A pointer to a <see cref="SHELLEXECUTEINFO"/> structure that contains and receives information about the application being executed.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful; otherwise, <see cref="FALSE"/>.
        /// Call <see cref="GetLastError"/> for extended error information.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Because <see cref="ShellExecuteEx"/> can delegate execution to Shell extensions (data sources, context menu handlers, verb implementations)
        /// that are activated using Component Object Model (COM), COM should be initialized before <see cref="ShellExecuteEx"/> is called.
        /// Some Shell extensions require the COM single-threaded apartment (STA) type.
        /// In that case, COM should be initialized as shown here:
        /// </para>
        /// <code>
        /// CoInitializeEx(NULL, COINIT_APARTMENTTHREADED | COINIT_DISABLE_OLE1DDE)
        /// </code>
        /// <para>
        /// There are instances where <see cref="ShellExecuteEx"/> does not use one of these types of Shell extension
        /// and those instances would not require COM to be initialized at all.
        /// Nonetheless, it is good practice to always initialize COM before using this function.
        /// </para>
        /// <para>
        /// When DLLs are loaded into your process, you acquire a lock known as a loader lock.
        /// The DllMain function always executes under the loader lock.
        /// It is important that you do not call <see cref="ShellExecuteEx"/> while you hold a loader lock.
        /// Because <see cref="ShellExecuteEx"/> is extensible, you could load code that does not function properly
        /// in the presence of a loader lock, risking a deadlock and therefore an unresponsive thread.
        /// </para>
        /// <para>
        /// With multiple monitors, if you specify an <see cref="HWND"/> and set the <see cref="SHELLEXECUTEINFO.lpVerb"/> member
        /// of the <see cref="SHELLEXECUTEINFO"/> structure pointed to by <paramref name="pExecInfo"/> to "Properties",
        /// any windows created by <see cref="ShellExecuteEx"/> might not appear in the correct position.
        /// </para>
        /// <para>
        /// If the function succeeds, it sets the <see cref="SHELLEXECUTEINFO.hInstApp"/> member
        /// of the <see cref="SHELLEXECUTEINFO"/> structure to a value greater than 32.
        /// If the function fails, <see cref="SHELLEXECUTEINFO.hInstApp"/> is set to the SE_ERR_XXX error value that best indicates the cause of the failure.
        /// Although <see cref="SHELLEXECUTEINFO.hInstApp"/> is declared as an <see cref="HINSTANCE"/>
        /// for compatibility with 16-bit Windows applications, it is not a true <see cref="HINSTANCE"/>.
        /// It can be cast only to an <see cref="int"/> and can be compared only to either the value 32 or the SE_ERR_XXX error codes.
        /// </para>
        /// <para>
        /// The SE_ERR_XXX error values are provided for compatibility with <see cref="ShellExecute"/>.
        /// To retrieve more accurate error information, use <see cref="GetLastError"/>.
        /// It may return one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Error
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_FILE_NOT_FOUND"/>
        /// </term>
        /// <term>
        /// The specified file was not found.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_PATH_NOT_FOUND"/>
        /// </term>
        /// <term>
        /// The specified path was not found.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_DDE_FAIL"/>
        /// </term>
        /// <term>
        /// The Dynamic Data Exchange (DDE) transaction failed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_NO_ASSOCIATION"/>
        /// </term>
        /// <term>
        /// There is no application associated with the specified file name extension.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_ACCESS_DENIED"/>
        /// </term>
        /// <term>
        /// Access to the specified file is denied.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_DLL_NOT_FOUND"/>
        /// </term>
        /// <term>
        /// One of the library files necessary to run the application can't be found.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_CANCELLED"/>
        /// </term>
        /// <term>
        /// The function prompted the user for additional information, but the user canceled the request.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_NOT_ENOUGH_MEMORY"/>
        /// </term>
        /// <term>
        /// There is not enough memory to perform the specified action.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_SHARING_VIOLATION"/>
        /// </term>
        /// <term>
        /// A sharing violation occurred.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Opening items from a URL You can register your application to activate when passed URLs.
        /// You can also specify which protocols your application supports.
        /// See Application Registration for more info.
        /// </para>
        /// <para>
        /// Site chain support As of Windows 8, you can provide a site chain pointer to the <see cref="ShellExecuteEx"/> function
        /// to support item activation with services from that site.
        /// See Launching Applications (ShellExecute, ShellExecuteEx, SHELLEXECUTEINFO) for more information.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShellExecuteExW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ShellExecuteEx([In][Out] ref SHELLEXECUTEINFO pExecInfo);

        /// <summary>
        /// <para>
        /// Copies, moves, renames, or deletes a file system object.
        /// This function has been replaced in Windows Vista by <see cref="IFileOperation"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shellapi/nf-shellapi-shfileoperationw"/>
        /// </para>
        /// </summary>
        /// <param name="lpFileOp">
        /// A pointer to an <see cref="SHFILEOPSTRUCT"/> structure that contains information this function needs to carry out the specified operation.
        /// This parameter must contain a valid value that is not <see cref="NullRef{SHFILEOPSTRUCT}"/>.
        /// You are responsible for validating the value. If you do not validate it, you will experience unexpected results.
        /// </param>
        /// <returns>
        /// <para>
        /// Returns zero if successful; otherwise nonzero.
        /// Applications normally should simply check for zero or nonzero.
        /// </para>
        /// <para>
        /// It is good practice to examine the value of the <see cref="SHFILEOPSTRUCT.fAnyOperationsAborted"/> member of the <see cref="SHFILEOPSTRUCT"/>.
        /// <see cref="SHFileOperation"/> can return 0 for success if the user cancels the operation.
        /// If you do not check <see cref="SHFILEOPSTRUCT.fAnyOperationsAborted"/> as well as the return value,
        /// you cannot know that the function accomplished the full task you asked of it and you might proceed under incorrect assumptions.
        /// </para>
        /// <para>
        /// Do not use <see cref="GetLastError"/> with the return values of this function.
        /// </para>
        /// <para>
        /// To examine the nonzero values for troubleshooting purposes, they largely map to those defined in Winerror.h.
        /// However, several of its possible return values are based on pre-Win32 error codes,
        /// which in some cases overlap the later Winerror.h values without matching their meaning.
        /// Those particular values are detailed here, and for these specific values only these meanings should be accepted over the Winerror.h codes.
        /// However, these values are provided with these warnings:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// These are pre-Win32 error codes and are no longer supported or defined in any public header file.
        /// To use them, you must either define them yourself or compare against the numerical value.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// These error codes are subject to change and have historically done so.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// These values are provided only as an aid in debugging.
        /// They should not be regarded as definitive.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Error Code
        /// </term>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="DE_SAMEFILE"/>
        /// </term>
        /// <term>
        /// 0x71
        /// </term>
        /// <term>
        /// The source and destination files are the same file.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DE_MANYSRC1DEST"/>
        /// </term>
        /// <term>
        /// 0x72
        /// </term>
        /// <term>
        /// Multiple file paths were specified in the source buffer, but only one destination file path.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DE_DIFFDIR"/>
        /// </term>
        /// <term>
        /// 0x73
        /// </term>
        /// <term>
        /// Rename operation was specified but the destination path is a different directory.
        /// Use the move operation instead.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DE_ROOTDIR"/>
        /// </term>
        /// <term>
        /// 0x74
        /// </term>
        /// <term>
        /// The source is a root directory, which cannot be moved or renamed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DE_OPCANCELLED"/>
        /// </term>
        /// <term>
        /// 0x75
        /// </term>
        /// <term>
        /// The operation was canceled by the user, or silently canceled if the appropriate flags were supplied to <see cref="SHFileOperation"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DE_DESTSUBTREE"/>
        /// </term>
        /// <term>
        /// 0x76
        /// </term>
        /// <term>
        /// The destination is a subtree of the source.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DE_ACCESSDENIEDSRC"/>
        /// </term>
        /// <term>
        /// 0x78
        /// </term>
        /// <term>
        /// Security settings denied access to the source.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DE_PATHTOODEEP"/>
        /// </term>
        /// <term>
        /// 0x79
        /// </term>
        /// <term>
        /// The source or destination path exceeded or would exceed <see cref="MAX_PATH"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DE_MANYDEST"/>
        /// </term>
        /// <term>
        /// 0x7A
        /// </term>
        /// <term>
        /// The operation involved multiple destination paths, which can fail in the case of a move operation.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DE_INVALIDFILES"/>
        /// </term>
        /// <term>
        /// 0x7C
        /// </term>
        /// <term>
        /// The path in the source or destination or both was invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DE_DESTSAMETREE"/>
        /// </term>
        /// <term>
        /// 0x7D
        /// </term>
        /// <term>
        /// The source and destination have the same parent folder.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DE_FLDDESTISFILE"/>
        /// </term>
        /// <term>
        /// 0x7E
        /// </term>
        /// <term>
        /// The destination path is an existing file.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DE_FILEDESTISFLD"/>
        /// </term>
        /// <term>
        /// 0x80
        /// </term>
        /// <term>
        /// The destination path is an existing folder.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DE_FILENAMETOOLONG"/>
        /// </term>
        /// <term>
        /// 0x81
        /// </term>
        /// <term>
        /// The name of the file exceeds <see cref="MAX_PATH"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DE_DEST_IS_CDROM"/>
        /// </term>
        /// <term>
        /// 0x82
        /// </term>
        /// <term>
        /// The destination is a read-only CD-ROM, possibly unformatted.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DE_DEST_IS_DVD"/>
        /// </term>
        /// <term>
        /// 0x83
        /// </term>
        /// <term>
        /// The destination is a read-only DVD, possibly unformatted.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DE_DEST_IS_CDRECORD"/>
        /// </term>
        /// <term>
        /// 0x84
        /// </term>
        /// <term>
        /// The destination is a writable CD-ROM, possibly unformatted.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DE_FILE_TOO_LARGE"/>
        /// </term>
        /// <term>
        /// 0x85
        /// </term>
        /// <term>
        /// The file involved in the operation is too large for the destination media or file system.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DE_SRC_IS_CDROM"/>
        /// </term>
        /// <term>
        /// 0x86
        /// </term>
        /// <term>
        /// The source is a read-only CD-ROM, possibly unformatted.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DE_SRC_IS_DVD"/>
        /// </term>
        /// <term>
        /// 0x87
        /// </term>
        /// <term>
        /// The source is a read-only DVD, possibly unformatted.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DE_SRC_IS_CDRECORD"/>
        /// </term>
        /// <term>
        /// 0x88
        /// </term>
        /// <term>
        /// The source is a writable CD-ROM, possibly unformatted.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DE_ERROR_MAX"/>
        /// </term>
        /// <term>
        /// 0xB7
        /// </term>
        /// <term>
        /// <see cref="MAX_PATH"/> was exceeded during the operation.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// </term>
        /// <term>
        /// 0x402
        /// </term>
        /// <term>
        /// An unknown error occurred.
        /// This is typically due to an invalid path in the source or destination.
        /// This error does not occur on Windows Vista and later.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERRORONDEST"/>
        /// </term>
        /// <term>
        /// 0x10000
        /// </term>
        /// <term>
        /// An unspecified error occurred on the destination.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <c>DE_ROOTDIR | ERRORONDEST</c>
        /// </term>
        /// <term>
        /// 0x10074
        /// </term>
        /// <term>
        /// Destination is a root directory and cannot be renamed.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// You should use fully qualified path names with this function. Using it with relative path names is not thread safe.
        /// </para>
        /// <para>
        /// With two exceptions, you cannot use <see cref="SHFileOperation"/> to move special folders
        /// from a local drive to a remote computer by specifying a network path.
        /// The exceptions are the My Documents (<see cref="CSIDL_PERSONAL"/>, <see cref="CSIDL_MYDOCUMENTS"/>)
        /// and My Pictures folders (<see cref="CSIDL_MYPICTURES"/>).
        /// </para>
        /// <para>
        /// When used to delete a file, <see cref="SHFileOperation"/> permanently deletes the file
        /// unless you set the <see cref="FOF_ALLOWUNDO"/> flag in the <see cref="SHFILEOPSTRUCT.fFlags"/> member
        /// of the <see cref="SHFILEOPSTRUCT"/> structure pointed to by <paramref name="lpFileOp"/>.
        /// Setting that flag sends the file to the Recycle Bin.
        /// If you want to simply delete a file and guarantee that it is not placed in the Recycle Bin, use <see cref="DeleteFile"/>.
        /// </para>
        /// <para>
        /// If a copy callback handler is exposed and registered, <see cref="SHFileOperation"/> calls it
        /// unless you set a flag such as <see cref="FOF_NOCONFIRMATION"/> in the <see cref="SHFILEOPSTRUCT.fFlags"/> member
        /// of the structure pointed to by <paramref name="lpFileOp"/>.
        /// See <see cref="ICopyHook.CopyCallback"/> for details on implementing copy callback handlers.
        /// </para>
        /// <para>
        /// File deletion is recursive unless you set the <see cref="FOF_NORECURSION"/> flag in <paramref name="lpFileOp"/>.
        /// </para>
        /// <para>
        /// Connecting Files
        /// </para>
        /// <para>
        /// With Windows 2000 or later, it is possible to connect an HTML file with a folder
        /// that contains related files such as Graphics Interchange Format (GIF) images or style sheets.
        /// If file connection is enabled, when you move or copy the HTML file,
        /// the connected folder and all of its files are also moved or copied.
        /// Conversely, if you move the folder with the related files, the HTML file is also moved.
        /// </para>
        /// <para>
        /// The HTML file must have a .htm or .html extension.
        /// You create the connection to the related files by placing the folder that contains them into the same folder as the HTML file.
        /// The name of the folder that contains the connected files must be the same as the name of the HTML file
        /// followed by "_files" or ".files" (this is case sensitive; for example, ".Files" does not work).
        /// An example is given here.
        /// </para>
        /// <para>
        /// <list type="number">
        /// <item>
        /// <description>
        /// Create a file named Test.htm in the C:\Files directory (C:\Files\Test.htm).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Create a new folder named Test.files in the C:\Files directory (C:\Files\Test.files).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Populate the folder with a few files. Any file placed in this folder is connected to Test.htm.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Move or copy the Test.htm file to the C:\Files2 directory.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Note that the Test.files directory is now found in the C:\Files2 directory as well.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// File connection is enabled by default.
        /// It can be disabled by adding a <see cref="REG_DWORD"/> entry, NoFileFolderConnection, as shown here:
        /// </para>
        /// <code>
        /// HKEY_CURRENT_USER
        ///    Software
        ///       Microsoft
        ///          Windows
        ///             CurrentVersion
        ///                Explorer
        ///                   NoFileFolderConnection
        /// </code>
        /// <para>
        /// Setting NoFileFolderConnection to 1 disables file connection.
        /// If the value is set to zero or is missing, file connection is enabled.
        /// </para>
        /// <para>
        /// To move only the specified files and none of the connected files,
        /// set the <see cref="FOF_NO_CONNECTED_ELEMENTS"/> flag in the <see cref="SHFILEOPSTRUCT.fFlags"/> member
        /// of the structure pointed to by <paramref name="lpFileOp"/>.
        /// </para>
        /// <para>
        /// Note that the use of a folder with a name like "MyFile_files"
        /// to define a connection may not be valid for localized versions of Windows.
        /// The term "files" may need to be replaced by the equivalent word in the local language.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHFileOperationW", ExactSpelling = true)]
        public static extern int SHFileOperation([In] in SHFILEOPSTRUCT lpFileOp);

        /// <summary>
        /// <para>
        /// Frees a file name mapping object that was retrieved by the <see cref="SHFileOperation"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shellapi/nf-shellapi-shfreenamemappings"/>
        /// </para>
        /// </summary>
        /// <param name="hNameMappings">
        /// A handle to the file name mapping object to be freed.
        /// </param>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHFreeNameMappings", ExactSpelling = true)]
        public static extern void SHFreeNameMappings([In] HANDLE hNameMappings);

        /// <summary>
        /// <para>
        /// Retrieves the <see cref="IShellFolder"/> interface for the desktop folder, which is the root of the Shell's namespace.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shlobj_core/nf-shlobj_core-shgetdesktopfolder"/>
        /// </para>
        /// </summary>
        /// <param name="ppshf">
        /// When this method returns, receives an <see cref="IShellFolder"/> interface pointer for the desktop folder.
        /// The calling application is responsible for eventually freeing the interface by calling its <see cref="IUnknown.Release"/> method.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHGetDesktopFolder", ExactSpelling = true)]
        public static extern HRESULT SHGetDesktopFolder([Out] out P<IShellFolder> ppshf);

        /// <summary>
        /// <para>
        /// Retrieves information about an object in the file system, such as a file, folder, directory, or drive root.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shellapi/nf-shellapi-shgetfileinfow"/>
        /// </para>
        /// </summary>
        /// <param name="pszPath">
        /// <para>
        /// A pointer to a null-terminated string of maximum length <see cref="MAX_PATH"/> that contains the path and file name.
        /// Both absolute and relative paths are valid.
        /// </para>
        /// <para>
        /// If the <paramref name="uFlags"/> parameter includes the <see cref="SHGFI_PIDL"/> flag,
        /// this parameter must be the address of an <see cref="ITEMIDLIST"/> (PIDL) structure
        /// that contains the list of item identifiers that uniquely identifies the file within the Shell's namespace.
        /// The PIDL must be a fully qualified PIDL. Relative PIDLs are not allowed.
        /// </para>
        /// <para>
        /// If the <paramref name="uFlags"/> parameter includes the <see cref="SHGFI_USEFILEATTRIBUTES"/> flag,
        /// this parameter does not have to be a valid file name. 
        /// The function will proceed as if the file exists with the specified name
        /// and with the file attributes passed in the <paramref name="dwFileAttributes"/> parameter.
        /// This allows you to obtain information about a file type by passing just the extension for <paramref name="pszPath"/>
        /// and passing <see cref="FILE_ATTRIBUTE_NORMAL"/> in <paramref name="dwFileAttributes"/>.
        /// </para>
        /// <para>
        /// This string can use either short (the 8.3 form) or long file names.
        /// </para>
        /// </param>
        /// <param name="dwFileAttributes">
        /// A combination of one or more file attribute flags (FILE_ATTRIBUTE_ values as defined in Winnt.h).
        /// If <paramref name="uFlags"/> does not include the <see cref="SHGFI_USEFILEATTRIBUTES"/> flag, this parameter is ignored.
        /// </param>
        /// <param name="psfi">
        /// Pointer to a <see cref="SHFILEINFO"/> structure to receive the file information.
        /// </param>
        /// <param name="cbFileInfo">
        /// The size, in bytes, of the <see cref="SHFILEINFO"/> structure pointed to by the psfi parameter.
        /// </param>
        /// <param name="uFlags">
        /// The flags that specify the file information to retrieve.
        /// This parameter can be a combination of the following values.
        /// <see cref="SHGFI_ADDOVERLAYS"/>:
        /// Version 5.0. Apply the appropriate overlays to the file's icon. The <see cref="SHGFI_ICON"/> flag must also be set.
        /// <see cref="SHGFI_ATTR_SPECIFIED"/>:
        /// Modify <see cref="SHGFI_ATTRIBUTES"/> to indicate that the <see cref="SHFILEINFO.dwAttributes"/> member
        /// of the <see cref="SHFILEINFO"/> structure at <paramref name="psfi"/> contains the specific attributes that are desired.
        /// These attributes are passed to <see cref="IShellFolder.GetAttributesOf"/>.
        /// If this flag is not specified, 0xFFFFFFFF is passed to <see cref="IShellFolder.GetAttributesOf"/>, requesting all attributes.
        /// This flag cannot be specified with the <see cref="SHGFI_ICON"/> flag.
        /// <see cref="SHGFI_ATTRIBUTES"/>:
        /// Retrieve the item attributes.
        /// The attributes are copied to the <see cref="SHFILEINFO.dwAttributes"/> member of the structure specified in the <paramref name="psfi"/> parameter.
        /// These are the same attributes that are obtained from <see cref="IShellFolder.GetAttributesOf"/>.
        /// <see cref="SHGFI_DISPLAYNAME"/>:
        /// Retrieve the display name for the file, which is the name as it appears in Windows Explorer.
        /// The name is copied to the <see cref="SHFILEINFO.szDisplayName"/> member of the structure specified in <paramref name="psfi"/>.
        /// The returned display name uses the long file name, if there is one, rather than the 8.3 form of the file name.
        /// Note that the display name can be affected by settings such as whether extensions are shown.
        /// <see cref="SHGFI_EXETYPE"/>:
        /// Retrieve the type of the executable file if <paramref name="pszPath"/> identifies an executable file.
        /// The information is packed into the return value.
        /// This flag cannot be specified with any other flags.
        /// <see cref="SHGFI_ICON"/>:
        /// Retrieve the handle to the icon that represents the file and the index of the icon within the system image list.
        /// The handle is copied to the <see cref="SHFILEINFO.hIcon"/> member of the structure
        /// specified by <paramref name="psfi"/>, and the index is copied to the <see cref="SHFILEINFO.iIcon"/> member.
        /// <see cref="SHGFI_ICONLOCATION"/>:
        /// Retrieve the name of the file that contains the icon representing the file specified by <paramref name="pszPath"/>,
        /// as returned by the <see cref="IExtractIcon.GetIconLocation"/> method of the file's icon handler.
        /// Also retrieve the icon index within that file.
        /// The name of the file containing the icon is copied to the <see cref="SHFILEINFO.szDisplayName"/> member
        /// of the structure specified by <paramref name="psfi"/>.
        /// The icon's index is copied to that structure's <see cref="SHFILEINFO.iIcon"/> member.
        /// <see cref="SHGFI_LARGEICON"/>:
        /// Modify <see cref="SHGFI_ICON"/>, causing the function to retrieve the file's large icon.
        /// The <see cref="SHGFI_ICON"/> flag must also be set.
        /// <see cref="SHGFI_LINKOVERLAY"/>:
        /// Modify <see cref="SHGFI_ICON"/>, causing the function to add the link overlay to the file's icon.
        /// The <see cref="SHGFI_ICON"/> flag must also be set.
        /// <see cref="SHGFI_OPENICON"/>:
        /// Modify <see cref="SHGFI_ICON"/>, causing the function to retrieve the file's open icon.
        /// Also used to modify <see cref="SHGFI_SYSICONINDEX"/>, causing the function to return the handle
        /// to the system image list that contains the file's small open icon.
        /// A container object displays an open icon to indicate that the container is open.
        /// The <see cref="SHGFI_ICON"/> and/or <see cref="SHGFI_SYSICONINDEX"/> flag must also be set.
        /// <see cref="SHGFI_OVERLAYINDEX"/>:
        /// Version 5.0. Return the index of the overlay icon.
        /// The value of the overlay index is returned in the upper eight bits of the <see cref="SHFILEINFO.iIcon"/> member
        /// of the structure specified by <paramref name="psfi"/>.
        /// This flag requires that the <see cref="SHGFI_ICON"/> be set as well.
        /// <see cref="SHGFI_PIDL"/>:
        /// Indicate that <paramref name="pszPath"/> is the address of an <see cref="ITEMIDLIST"/> structure rather than a path name.
        /// <see cref="SHGFI_SELECTED"/>:
        /// Modify <see cref="SHGFI_ICON"/>, causing the function to blend the file's icon with the system highlight color.
        /// The <see cref="SHGFI_ICON"/> flag must also be set.
        /// <see cref="SHGFI_SHELLICONSIZE"/>:
        /// Modify <see cref="SHGFI_ICON"/>, causing the function to retrieve a Shell-sized icon.
        /// If this flag is not specified the function sizes the icon according to the system metric values.
        /// The <see cref="SHGFI_ICON"/> flag must also be set.
        /// <see cref="SHGFI_SMALLICON"/>:
        /// Modify <see cref="SHGFI_ICON"/>, causing the function to retrieve the file's small icon.
        /// Also used to modify <see cref="SHGFI_SYSICONINDEX"/>, causing the function to return
        /// the handle to the system image list that contains small icon images.
        /// The <see cref="SHGFI_ICON"/> and/or <see cref="SHGFI_SYSICONINDEX"/> flag must also be set.
        /// <see cref="SHGFI_SYSICONINDEX"/>:
        /// Retrieve the index of a system image list icon.
        /// If successful, the index is copied to the <see cref="SHFILEINFO.iIcon"/> member of <paramref name="psfi"/>.
        /// The return value is a handle to the system image list.
        /// Only those images whose indices are successfully copied to iIcon are valid.
        /// Attempting to access other images in the system image list will result in undefined behavior.
        /// <see cref="SHGFI_TYPENAME"/>:
        /// Retrieve the string that describes the file's type.
        /// The string is copied to the <see cref="SHFILEINFO.szTypeName"/> member of the structure specified in <paramref name="psfi"/>.
        /// <see cref="SHGFI_USEFILEATTRIBUTES"/>:
        /// Indicates that the function should not attempt to access the file specified by <paramref name="pszPath"/>.
        /// Rather, it should act as if the file specified by <paramref name="pszPath"/> exists
        /// with the file attributes passed in <paramref name="dwFileAttributes"/>.
        /// This flag cannot be combined with the <see cref="SHGFI_ATTRIBUTES"/>, <see cref="SHGFI_EXETYPE"/>, or <see cref="SHGFI_PIDL"/> flags.
        /// </param>
        /// <returns>
        /// <para>
        /// Returns a value whose meaning depends on the <paramref name="uFlags"/> parameter.
        /// </para>
        /// <para>
        /// If <paramref name="uFlags"/> does not contain <see cref="SHGFI_EXETYPE"/> or <see cref="SHGFI_SYSICONINDEX"/>,
        /// the return value is nonzero if successful, or zero otherwise.
        /// </para>
        /// <para>
        /// If <paramref name="uFlags"/> contains the <see cref="SHGFI_EXETYPE"/> flag,
        /// the return value specifies the type of the executable file.
        /// It will be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0
        /// </term>
        /// <term>
        /// Nonexecutable file or an error condition.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// LOWORD = NE or PE and HIWORD = Windows version
        /// </term>
        /// <term>
        /// Windows application.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// LOWORD = MZ and HIWORD = 0
        /// </term>
        /// <term>
        /// MS-DOS .exe or .com file
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// LOWORD = PE and HIWORD = 0
        /// </term>
        /// <term>
        /// Console application or .bat file
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// You should call this function from a background thread.
        /// Failure to do so could cause the UI to stop responding.
        /// </para>
        /// <para>
        /// If <see cref="SHGetFileInfo"/> returns an icon handle in the <see cref="SHFILEINFO.hIcon"/> member
        /// of the <see cref="SHFILEINFO"/> structure pointed to by <paramref name="psfi"/>,
        /// you are responsible for freeing it with <see cref="DestroyIcon"/> when you no longer need it.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Once you have a handle to a system image list, you can use the Image List API to manipulate it like any other image list.
        /// Because system image lists are created on a per-process basis, you should treat them as read-only objects.
        /// Writing to a system image list may overwrite or delete one of the system images,
        /// making it unavailable or incorrect for the remainder of the process.
        /// You must initialize Component Object Model (COM) with <see cref="CoInitialize"/> or <see cref="OleInitialize"/> prior to calling <see cref="SHGetFileInfo"/>.
        /// </para>
        /// <para>
        /// When you use the <see cref="SHGFI_EXETYPE"/> flag with a Windows application,
        /// the Windows version of the executable is given in the HIWORD of the return value.
        /// This version is returned as a hexadecimal value.
        /// For details on equating this value with a specific Windows version, see Using the Windows Headers.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHGetFileInfoW", ExactSpelling = true)]
        public static extern DWORD_PTR SHGetFileInfo([In] LPCWSTR pszPath, [In] FileAttributes dwFileAttributes, [In][Out] ref SHFILEINFO psfi,
            [In] UINT cbFileInfo, [In] ShellGetFileInfoFlags uFlags);

        /// <summary>
        /// <para>
        /// Deprecated. Retrieves the path of a folder as an <see cref="ITEMIDLIST"/> structure.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shlobj_core/nf-shlobj_core-shgetfolderlocation"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// Reserved.
        /// </param>
        /// <param name="csidl">
        /// A <see cref="CSIDL"/> value that identifies the folder to be located.
        /// The folders associated with the CSIDLs might not exist on a particular system.
        /// </param>
        /// <param name="hToken">
        /// <para>
        /// An access token that can be used to represent a particular user.
        /// It is usually set to <see cref="NULL"/>, but it may be needed
        /// when there are multiple users for those folders that are treated as belonging to a single user.
        /// The most commonly used folder of this type is My Documents.
        /// The calling application is responsible for correct impersonation when <paramref name="hToken"/> is non-<see cref="NULL"/>.
        /// It must have appropriate security privileges for the particular user, and the user's registry hive must be currently mounted.
        /// See Access Control for further discussion of access control issues.
        /// </para>
        /// <para>
        /// Assigning the <paramref name="hToken"/> parameter a value of -1 indicates the Default User.
        /// This allows clients of <see cref="SHGetFolderLocation"/> to find folder locations (such as the Desktop folder) for the Default User.
        /// The Default User user profile is duplicated when any new user account is created,
        /// and includes special folders such as My Documents and Desktop.
        /// Any items added to the Default User folder also appear in any new user account.
        /// </para>
        /// </param>
        /// <param name="dwFlags">
        /// </param>
        /// <param name="ppidl">
        /// The address of a pointer to an item identifier list structure that specifies the folder's location relative to the root of the namespace (the desktop).
        /// The <paramref name="ppidl"/> parameter is set to <see cref="NULL"/> on failure.
        /// The calling application is responsible for freeing this resource by calling <see cref="ILFree"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// Returns S_OK if successful, or an error value otherwise, including the following:
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <c>HRESULT_FROM_WIN32(ERROR_FILE_NOT_FOUND)</c>
        /// </term>
        /// <term>
        /// The <see cref="CSIDL"/> in <paramref name="csidl"/> is valid but the folder does not exist.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_INVALIDARG"/>
        /// </term>
        /// <term>
        /// The <see cref="CSIDL"/> in <paramref name="csidl"/> is not valid.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// As of Windows Vista, this function is merely a wrapper for <see cref="SHGetKnownFolderIDList"/>.
        /// The CSIDL value is translated to its associated <see cref="KNOWNFOLDERID"/> and <see cref="SHGetKnownFolderIDList"/> is called.
        /// New applications should use the known folder system rather than the older CSIDL system, which is supported only for backward compatibility.
        /// The <see cref="SHGetFolderLocation"/>, <see cref="SHGetFolderPath"/>, <see cref="SHGetSpecialFolderLocation"/>,
        /// and <see cref="SHGetSpecialFolderPath"/> functions are the preferred ways to obtain handles to folders on systems earlier than Windows Vista.
        /// Functions such as <see cref="ExpandEnvironmentStrings"/> that use the environment variable names directly,
        /// in the form %VariableName%, may not be reliable.
        /// </para>
        /// <para>
        /// This function is a superset of <see cref="SHGetSpecialFolderLocation"/>, included with earlier versions of the Shell.
        /// </para>
        /// </remarks>
        [Obsolete("Deprecated")]
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHGetFolderLocation", ExactSpelling = true)]
        public static extern HRESULT SHGetFolderLocation([In] HWND hwnd, [In] CSIDL csidl, [In] HANDLE hToken, [In] DWORD dwFlags,
            [Out] out LPITEMIDLIST ppidl);

        /// <summary>
        /// <para>
        /// Deprecated. Gets the path of a folder identified by a CSIDL value.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shlobj_core/nf-shlobj_core-shgetfolderpathw"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// Reserved.
        /// </param>
        /// <param name="csidl">
        /// A <see cref="CSIDL"/> value that identifies the folder whose path is to be retrieved.
        /// Only real folders are valid.
        /// If a virtual folder is specified, this function fails.
        /// You can force creation of a folder by combining the folder's <see cref="CSIDL"/> with <see cref="CSIDL_FLAG_CREATE"/>.
        /// </param>
        /// <param name="hToken">
        /// <para>
        /// An access token that can be used to represent a particular user.
        /// </para>
        /// <para>
        /// Microsoft Windows 2000 and earlier: Always set this parameter to <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// Windows XP and later: This parameter is usually set to <see cref="NULL"/>,
        /// but you might need to assign a non-<see cref="NULL"/> value to <paramref name="hToken"/> for those folders
        /// that can have multiple users but are treated as belonging to a single user.
        /// The most commonly used folder of this type is Documents.
        /// </para>
        /// <para>
        /// The calling process is responsible for correct impersonation when <paramref name="hToken"/> is non-<see cref="NULL"/>.
        /// The calling process must have appropriate security privileges for the particular user,
        /// including <see cref="TOKEN_QUERY"/> and <see cref="TOKEN_IMPERSONATE"/>, and the user's registry hive must be currently mounted.
        /// See Access Control for further discussion of access control issues.
        /// </para>
        /// <para>
        /// Assigning the <paramref name="hToken"/> parameter a value of -1 indicates the Default User.
        /// This enables clients of <see cref="SHGetFolderPath"/> to find folder locations (such as the Desktop folder) for the Default User.
        /// The Default User user profile is duplicated when any new user account is created, and includes special folders such as My Documents and Desktop.
        /// Any items added to the Default User folder also appear in any new user account.
        /// </para>
        /// </param>
        /// <param name="dwFlags">
        /// <para>
        /// Flags that specify the path to be returned.
        /// This value is used in cases where the folder associated with a <see cref="KNOWNFOLDERID"/> (or <see cref="CSIDL"/>)
        /// can be moved, renamed, redirected, or roamed across languages by a user or administrator.
        /// </para>
        /// <para>
        /// The known folder system that underlies <see cref="SHGetFolderPath"/> allows users or administrators
        /// to redirect a known folder to a location that suits their needs.
        /// This is achieved by calling <see cref="IKnownFolderManager.Redirect"/>,
        /// which sets the "current" value of the folder associated with the <see cref="SHGFP_TYPE_CURRENT"/> flag.
        /// </para>
        /// <para>
        /// The default value of the folder, which is the location of the folder
        /// if a user or administrator had not redirected it elsewhere, is retrieved by specifying the <see cref="SHGFP_TYPE_DEFAULT"/> flag.
        /// This value can be used to implement a "restore defaults" feature for a known folder.
        /// </para>
        /// <para>
        /// For example, the default value (<see cref="SHGFP_TYPE_DEFAULT"/>) for <see cref="FOLDERID_Music"/> (<see cref="CSIDL_MYMUSIC"/>) is "C:\Users\user name\Music".
        /// If the folder was redirected, the current value (<see cref="SHGFP_TYPE_CURRENT"/>) might be "D:\Music".
        /// If the folder has not been redirected, then <see cref="SHGFP_TYPE_DEFAULT"/> and <see cref="SHGFP_TYPE_CURRENT"/> retrieve the same path.
        /// </para>
        /// <para>
        /// <see cref="SHGFP_TYPE_CURRENT"/>
        /// </para>
        /// <para>
        /// Retrieve the folder's current path.
        /// </para>
        /// <para>
        /// <see cref="SHGFP_TYPE_DEFAULT"/>
        /// </para>
        /// <para>
        /// Retrieve the folder's default path.
        /// </para>
        /// </param>
        /// <param name="pszPath">
        /// A pointer to a null-terminated string of length <see cref="MAX_PATH"/> which will receive the path.
        /// If an error occurs or <see cref="S_FALSE"/> is returned, this string will be empty.
        /// The returned path does not include a trailing backslash. 
        /// For example, "C:\Users" is returned rather than "C:\Users\".
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function is a superset of <see cref="SHGetSpecialFolderPath"/>.
        /// </para>
        /// <para>
        /// Only some <see cref="CSIDL"/> values are supported, including the following:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="CSIDL_ADMINTOOLS"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CSIDL_APPDATA"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CSIDL_COMMON_ADMINTOOLS"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CSIDL_COMMON_APPDATA"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CSIDL_COMMON_DOCUMENTS"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CSIDL_COOKIES"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CSIDL_FLAG_CREATE"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CSIDL_FLAG_DONT_VERIFY"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CSIDL_HISTORY"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CSIDL_INTERNET_CACHE"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CSIDL_LOCAL_APPDATA"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CSIDL_MYPICTURES"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CSIDL_PERSONAL"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CSIDL_PROGRAM_FILES"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CSIDL_PROGRAM_FILES_COMMON"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CSIDL_SYSTEM"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CSIDL_WINDOWS"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [Obsolete("As of Windows Vista, this function is merely a wrapper for SHGetKnownFolderPath." +
            "The CSIDL value is translated to its associated KNOWNFOLDERID and then SHGetKnownFolderPath is called." +
            "New applications should use the known folder system rather than the older CSIDL system," +
            "which is supported only for backward compatibility.")]
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHGetFolderPathW", ExactSpelling = true)]
        public static extern HRESULT SHGetFolderPath([In] HWND hwnd, [In] CSIDL csidl, [In] HANDLE hToken, [In] ShellGetFolderPathTypes dwFlags, [In] LPWSTR pszPath);


        /// <summary>
        /// <para>
        /// Retrieves the path of a known folder as an <see cref="ITEMIDLIST"/> structure.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shlobj_core/nf-shlobj_core-shgetknownfolderidlist"/>
        /// </para>
        /// </summary>
        /// <param name="rfid">
        /// A reference to the <see cref="KNOWNFOLDERID"/> that identifies the folder.
        /// The folders associated with the known folder IDs might not exist on a particular system.
        /// </param>
        /// <param name="dwFlags">
        /// Flags that specify special retrieval options.
        /// This value can be 0; otherwise, it is one or more of the <see cref="KNOWN_FOLDER_FLAG"/> values.
        /// </param>
        /// <param name="hToken">
        /// <para>
        /// An access token used to represent a particular user.
        /// This parameter is usually set to <see cref="NULL"/>, in which case the function tries to access the current user's instance of the folder.
        /// However, you may need to assign a value to <paramref name="hToken"/> for those folders
        /// that can have multiple users but are treated as belonging to a single user.
        /// The most commonly used folder of this type is Documents.
        /// </para>
        /// <para>
        /// The calling application is responsible for correct impersonation when <paramref name="hToken"/> is non-null.
        /// It must have appropriate security privileges for the particular user, including <see cref="TOKEN_QUERY"/> and <see cref="TOKEN_IMPERSONATE"/>,
        /// and the user's registry hive must be currently mounted.
        /// See Access Control for further discussion of access control issues.
        /// </para>
        /// <para>
        /// Assigning the <paramref name="hToken"/> parameter a value of -1 indicates the Default User.
        /// This allows clients of <see cref="SHGetKnownFolderIDList"/> to find folder locations (such as the Desktop folder) for the Default User.
        /// The Default User user profile is duplicated when any new user account is created, and includes special folders such as Documents and Desktop.
        /// Any items added to the Default User folder also appear in any new user account.
        /// Note that access to the Default User folders requires administrator privileges.
        /// </para>
        /// </param>
        /// <param name="ppidl">
        /// When this method returns, contains a pointer to the PIDL of the folder.
        /// This parameter is passed uninitialized.
        /// The caller is responsible for freeing the returned PIDL when it is no longer needed by calling ILFree.
        /// </param>
        /// <returns>
        /// <para>
        /// Returns <see cref="S_OK"/> if successful, or an error value otherwise, including the following:
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="E_INVALIDARG"/>
        /// </term>
        /// <term>
        /// Among other things, this value can indicate that the <paramref name="rfid"/> parameter
        /// references a <see cref="KNOWNFOLDERID"/> that is not present on the system.
        /// Not all <see cref="KNOWNFOLDERID"/> values are present on all systems.
        /// Use <see cref="IKnownFolderManager.GetFolderIds"/> to retrieve the set of <see cref="KNOWNFOLDERID"/> values for the current system.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function replaces <see cref="SHGetFolderLocation"/>.
        /// That older function is now simply a wrapper for <see cref="SHGetKnownFolderIDList"/>.
        /// </para>
        /// <para>
        /// Callers using this function must have at least User privileges.
        /// </para>
        /// <para>
        /// Some known folders, for example, the Documents folder, are per-user.
        /// Each user has a different path for the Documents folder.
        /// If <paramref name="hToken"/> is <see cref="NULL"/>, the API tries to access the current user's instance of the folder.
        /// If <paramref name="hToken"/> is a valid user token, the API tries to impersonate the user using this token,
        /// and attempts to access that user's instance of the folder.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHGetKnownFolderIDList", ExactSpelling = true)]
        public static extern HRESULT SHGetKnownFolderIDList([In] in KNOWNFOLDERID rfid, [In] KNOWN_FOLDER_FLAG dwFlags,
            [In] HANDLE hToken, [Out] out LPITEMIDLIST ppidl);

        /// <summary>
        /// <para>
        /// Retrieves the full path of a known folder identified by the folder's <see cref="KNOWNFOLDERID"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shlobj_core/nf-shlobj_core-shgetknownfolderpath"/>
        /// </para>
        /// </summary>
        /// <param name="rfid">
        /// A reference to the <see cref="KNOWNFOLDERID"/> that identifies the folder.
        /// </param>
        /// <param name="dwFlags">
        /// Flags that specify special retrieval options.
        /// This value can be 0; otherwise, one or more of the <see cref="KNOWN_FOLDER_FLAG"/> values.
        /// </param>
        /// <param name="hToken">
        /// <para>
        /// An access token that represents a particular user.
        /// If this parameter is <see cref="NULL"/>, which is the most common usage, the function requests the known folder for the current user.
        /// </para>
        /// <para>
        /// Request a specific user's folder by passing the <paramref name="hToken"/> of that user.
        /// This is typically done in the context of a service that has sufficient privileges to retrieve the token of a given user.
        /// That token must be opened with <see cref="TOKEN_QUERY"/> and <see cref="TOKEN_IMPERSONATE"/> rights.
        /// In some cases, you also need to include <see cref="TOKEN_DUPLICATE"/>.
        /// In addition to passing the user's <paramref name="hToken"/>, the registry hive of that specific user must be mounted.
        /// See Access Control for further discussion of access control issues.
        /// </para>
        /// <para>
        /// Assigning the <paramref name="hToken"/> parameter a value of -1 indicates the Default User.
        /// This allows clients of <see cref="SHGetKnownFolderPath"/> to find folder locations (such as the Desktop folder) for the Default User.
        /// The Default User user profile is duplicated when any new user account is created, and includes special folders such as Documents and Desktop.
        /// Any items added to the Default User folder also appear in any new user account.
        /// Note that access to the Default User folders requires administrator privileges.
        /// </para>
        /// </param>
        /// <param name="ppszPath">
        /// When this method returns, contains the address of a pointer to a null-terminated Unicode string that specifies the path of the known folder.
        /// The calling process is responsible for freeing this resource once it is no longer needed by calling <see cref="CoTaskMemFree"/>,
        /// whether <see cref="SHGetKnownFolderPath"/> succeeds or not.
        /// The returned path does not include a trailing backslash. For example, "C:\Users" is returned rather than "C:\Users\".
        /// </param>
        /// <returns>
        /// <para>
        /// Returns <see cref="S_OK"/> if successful, or an error value otherwise, including the following:
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="E_FAIL"/>
        /// </term>
        /// <term>
        /// Among other things, this value can indicate that the <paramref name="rfid"/> parameter
        /// references a <see cref="KNOWNFOLDERID"/> which does not have a path (such as a folder marked as <see cref="KF_CATEGORY_VIRTUAL"/>).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_INVALIDARG"/>
        /// </term>
        /// <term>
        /// Among other things, this value can indicate that the <paramref name="rfid"/> parameter
        /// references a <see cref="KNOWNFOLDERID"/> that is not present on the system.
        /// Not all <see cref="KNOWNFOLDERID"/> values are present on all systems.
        /// Use <see cref="IKnownFolderManager.GetFolderIds"/> to retrieve the set of <see cref="KNOWNFOLDERID"/> values for the current system.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// This function replaces <see cref="SHGetFolderPath"/>.
        /// That older function is now simply a wrapper for <see cref="SHGetKnownFolderPath"/>.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHGetKnownFolderPath", ExactSpelling = true)]
        public static extern HRESULT SHGetKnownFolderPath([In] in KNOWNFOLDERID rfid, [In] KNOWN_FOLDER_FLAG dwFlags,
            [In] HANDLE hToken, [Out] out LPWSTR ppszPath);

        /// <summary>
        /// <para>
        /// Retrieves the display name of an item identified by its IDList.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-shgetnamefromidlist"/>
        /// </para>
        /// </summary>
        /// <param name="pidl">
        /// A PIDL that identifies the item.
        /// </param>
        /// <param name="sigdnName">
        /// A value from the <see cref="SIGDN"/> enumeration that specifies the type of display name to retrieve.
        /// </param>
        /// <param name="ppszName">
        /// A value that, when this function returns successfully, receives the address of a pointer to the retrieved display name.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// It is the responsibility of the caller to free the string pointed to by <paramref name="ppszName"/> when it is no longer needed.
        /// Call <see cref="CoTaskMemFree"/> on *<paramref name="ppszName"/> to free the memory.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHGetNameFromIDList", ExactSpelling = true)]
        public static extern HRESULT SHGetNameFromIDList([In] LPCITEMIDLIST pidl, [In] SIGDN sigdnName, [Out] out LPWSTR ppszName);

        /// <summary>
        /// <para>
        /// Converts an item identifier list to a file system path.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shlobj_core/nf-shlobj_core-shgetpathfromidlistw"/>
        /// </para>
        /// </summary>
        /// <param name="pidl">
        /// The address of an item identifier list that specifies a file or directory location relative to the root of the namespace (the desktop).
        /// </param>
        /// <param name="pszPath">
        /// The address of a buffer to receive the file system path.
        /// This buffer must be at least <see cref="MAX_PATH"/> characters in size.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful; otherwise, <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the location specified by the <paramref name="pidl"/> parameter is not part of the file system, this function will fail.
        /// </para>
        /// <para>
        /// If the <paramref name="pidl"/> parameter specifies a shortcut,
        /// the <paramref name="pszPath"/> will contain the path to the shortcut, not to the shortcut's target.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHGetPathFromIDListW", ExactSpelling = true)]
        public static extern BOOL SHGetPathFromIDList([In] LPCITEMIDLIST pidl, [In] LPWSTR pszPath);

        /// <summary>
        /// <para>
        /// Retrieves an object that represents a specific window's collection of properties, which allows those properties to be queried or set.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shellapi/nf-shellapi-shgetpropertystoreforwindow"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window whose properties are being retrieved.
        /// </param>
        /// <param name="riid">
        /// A reference to the <see cref="IID"/> of the property store object to retrieve through <paramref name="ppv"/>.
        /// This is typically <see cref="IID_IPropertyStore"/>.
        /// </param>
        /// <param name="ppv">
        /// When this function returns, contains the interface pointer requested in <paramref name="riid"/>.
        /// This is typically <see cref="IPropertyStore"/>.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// An application can use this function to obtain access to a window's property store
        /// so that it can set an explicit Application User Model ID (AppUserModelID) in the System.AppUserModel.ID property.
        /// </para>
        /// <para>
        /// A window's properties must be removed before the window is closed.
        /// If this is not done, the resources used by those properties are not returned to the system.
        /// A property is removed by setting it to the <see cref="PROPVARIANT"/> type <see cref="VT_EMPTY"/>.
        /// </para>
        /// <para>
        /// When a call is made to <see cref="IPropertyStore.SetValue"/> on the object retrieved through <paramref name="ppv"/>,
        /// the properties and values are immediately stored on the window.
        /// Therefore, no call to <see cref="IPropertyStore.Commit"/> is needed.
        /// No error occurs if it is called, but it has no effect.
        /// </para>
        /// <para>
        /// An application sets AppUserModelIDs on individual windows to control the application's taskbar grouping and Jump List contents.
        /// For instance, a suite application might want to provide a different taskbar button for each of its subfeatures,
        /// with the windows relating to that subfeature grouped under that button.
        /// Without window-level AppUserModelIDs, those windows would all be grouped together under the main process.
        /// </para>
        /// <para>
        /// Applications should also use this property store to set these relaunch properties so that the system can return the application to that state.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// System.AppUserModel.RelaunchCommand
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// System.AppUserModel.RelaunchDisplayNameResource
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// System.AppUserModel.RelaunchIconResource
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHGetPropertyStoreForWindow", ExactSpelling = true)]
        public static extern HRESULT SHGetPropertyStoreForWindow([In] HWND hwnd, [In] in IID riid, [Out] out IntPtr ppv);

        /// <summary>
        /// <para>
        /// Retrieves a pointer to the <see cref="ITEMIDLIST"/> structure of a special folder.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shlobj_core/nf-shlobj_core-shgetspecialfolderlocation"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// Reserved.
        /// </param>
        /// <param name="csidl">
        /// A <see cref="CSIDL"/> value that identifies the folder of interest.
        /// </param>
        /// <param name="ppidl">
        /// A PIDL specifying the folder's location relative to the root of the namespace (the desktop).
        /// It is the responsibility of the calling application to free the returned IDList by using <see cref="CoTaskMemFree"/>.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        [Obsolete("SHGetSpecialFolderLocation is not supported and may be altered or unavailable in the future. Instead, use SHGetFolderLocation.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHGetSpecialFolderLocation", ExactSpelling = true)]
        public static extern HRESULT SHGetSpecialFolderLocation([In] HWND hwnd, [In] CSIDL csidl, [Out] out LPITEMIDLIST ppidl);

        /// <summary>
        /// <para>
        /// Retrieves the path of a special folder, identified by its <see cref="CSIDL"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shlobj_core/nf-shlobj_core-shgetspecialfolderpathw"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// Reserved.
        /// </param>
        /// <param name="pszPath">
        /// A pointer to a null-terminated string that receives the drive and path of the specified folder.
        /// This buffer must be at least <see cref="MAX_PATH"/> characters in size.
        /// </param>
        /// <param name="csidl">
        /// A <see cref="CSIDL"/> that identifies the folder of interest.
        /// If a virtual folder is specified, this function will fail.
        /// </param>
        /// <param name="fCreate">
        /// Indicates whether the folder should be created if it does not already exist.
        /// If this value is nonzero, the folder is created.
        /// If this value is zero, the folder is not created.
        /// </param>
        /// <returns>
        /// <see cref="TRUE"/> if successful; otherwise, <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The Microsoft Internet Explorer 4.0 Desktop Update must be installed for this function to be available.
        /// </remarks>
        [Obsolete("SHGetSpecialFolderPath is not supported. Instead, use SHGetFolderPath.")]
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHGetSpecialFolderPathW", ExactSpelling = true)]
        public static extern BOOL SHGetSpecialFolderPath([In] HWND hwnd, [In] IntPtr pszPath, [In] CSIDL csidl, [In] BOOL fCreate);

        /// <summary>
        /// <para>
        /// Retrieves information about system-defined Shell icons.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shellapi/nf-shellapi-shgetstockiconinfo"/>
        /// </para>
        /// </summary>
        /// <param name="siid">
        /// One of the values from the <see cref="SHSTOCKICONID"/> enumeration that specifies which icon should be retrieved.
        /// </param>
        /// <param name="uFlags">
        /// <para>
        /// A combination of zero or more of the following flags that specify which information is requested.
        /// </para>
        /// <para>
        /// <see cref="SHGSI_ICONLOCATION"/>
        /// </para>
        /// <para>
        /// The <see cref="SHSTOCKICONINFO.szPath"/> and <see cref="SHSTOCKICONINFO.iIcon"/> members of the <see cref="SHSTOCKICONINFO"/> structure
        /// receive the path and icon index of the requested icon, in a format suitable for passing to the <see cref="ExtractIcon"/> function.
        /// The numerical value of this flag is zero, so you always get the icon location regardless of other flags.
        /// </para>
        /// <para>
        /// <see cref="SHGSI_ICON"/>
        /// </para>
        /// <para>
        /// The <see cref="SHSTOCKICONINFO.hIcon"/> member of the <see cref="SHSTOCKICONINFO"/> structure receives a handle to the specified icon.
        /// </para>
        /// <para>
        /// <see cref="SHGSI_SYSICONINDEX"/>
        /// </para>
        /// <para>
        /// The <see cref="SHSTOCKICONINFO.iSysImageImage"/> member of the <see cref="SHSTOCKICONINFO"/> structure
        /// receives the index of the specified icon in the system imagelist.
        /// </para>
        /// <para>
        /// <see cref="SHGSI_LINKOVERLAY"/>
        /// </para>
        /// <para>
        /// Modifies the <see cref="SHGSI_ICON"/> value by causing the function to add the link overlay to the file's icon.
        /// </para>
        /// <para>
        /// <see cref="SHGSI_SELECTED"/>
        /// </para>
        /// <para>
        /// Modifies the <see cref="SHGSI_ICON"/> value by causing the function to blend the icon with the system highlight color.
        /// </para>
        /// <para>
        /// <see cref="SHGSI_LARGEICON"/>
        /// </para>
        /// <para>
        /// Modifies the <see cref="SHGSI_ICON"/> value by causing the function to retrieve the large version of the icon,
        /// as specified by the <see cref="SM_CXICON"/> and <see cref="SM_CYICON"/> system metrics.
        /// </para>
        /// <para>
        /// <see cref="SHGSI_SMALLICON"/>
        /// </para>
        /// <para>
        /// Modifies the <see cref="SHGSI_ICON"/> value by causing the function to retrieve the small version of the icon,
        /// as specified by the <see cref="SM_CXSMICON"/> and <see cref="SM_CYSMICON"/> system metrics.
        /// </para>
        /// <para>
        /// <see cref="SHGSI_SHELLICONSIZE"/>
        /// </para>
        /// <para>
        /// Modifies the <see cref="SHGSI_LARGEICON"/> or <see cref="SHGSI_SMALLICON"/> values by causing the function
        /// to retrieve the Shell-sized icons rather than the sizes specified by the system metrics.
        /// </para>
        /// </param>
        /// <param name="psii">
        /// A pointer to a <see cref="SHSTOCKICONINFO"/> structure.
        /// When this function is called, the <see cref="SHSTOCKICONINFO.cbSize"/> member of this structure needs to be
        /// set to the size of the <see cref="SHSTOCKICONINFO"/> structure.
        /// When this function returns, contains a pointer to a <see cref="SHSTOCKICONINFO"/> structure that contains the requested information.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// If this function returns an icon handle in the <see cref="SHSTOCKICONINFO.hIcon"/> member of the <see cref="SHSTOCKICONINFO"/> structure
        /// pointed to by <paramref name="psii"/>, you are responsible for freeing the icon with <see cref="DestroyIcon"/> when you no longer need it.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHGetStockIconInfo", ExactSpelling = true)]
        public static extern HRESULT SHGetStockIconInfo([In] SHSTOCKICONID siid, [In] ShellGetStockIconInfoFlags uFlags, [Out] out SHSTOCKICONINFO psii);

        /// <summary>
        /// <para>
        /// Redirects a known folder to a new location.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shlobj_core/nf-shlobj_core-shsetknownfolderpath"/>
        /// </para>
        /// </summary>
        /// <param name="rfid">
        /// A <see cref="GUID"/> that identifies the known folder.
        /// </param>
        /// <param name="dwFlags">
        /// <para>
        /// Either 0 or the following value.
        /// </para>
        /// <para>
        /// <see cref="KF_FLAG_DONT_UNEXPAND"/>
        /// </para>
        /// <para>
        /// If this flag is set, portions of the path referenced by <paramref name="pszPath"/> may be represented by environment strings such as <c>%USERPROFILE%</c>.
        /// </para>
        /// </param>
        /// <param name="hToken">
        /// <para>
        /// An access token used to represent a particular user.
        /// This parameter is usually set to <see cref="NULL"/>, in which case the function tries to access the current user's instance of the folder.
        /// However, you may need to assign a value to <paramref name="hToken"/> for those folders
        /// that can have multiple users but are treated as belonging to a single user.
        /// The most commonly used folder of this type is Documents.
        /// </para>
        /// <para>
        /// The calling application is responsible for correct impersonation when <paramref name="hToken"/> is non-null.
        /// It must have appropriate security privileges for the particular user, including <see cref="TOKEN_QUERY"/> and <see cref="TOKEN_IMPERSONATE"/>,
        /// and the user's registry hive must be currently mounted.
        /// See Access Control for further discussion of access control issues.
        /// </para>
        /// <para>
        /// Assigning the <paramref name="hToken"/> parameter a value of -1 indicates the Default User.
        /// This allows clients of <see cref="SHSetKnownFolderPath"/> to set folder locations (such as the Desktop folder) for the Default User.
        /// The Default User user profile is duplicated when any new user account is created, and includes special folders such as Documents and Desktop.
        /// Any items added to the Default User folder also appear in any new user account.
        /// Note that access to the Default User folders requires administrator privileges.
        /// </para>
        /// </param>
        /// <param name="pszPath">
        /// A pointer to the folder's new path.
        /// This is a null-terminated Unicode string of length <see cref="MAX_PATH"/>.
        /// This path cannot be of zero length.
        /// </param>
        /// <returns>
        /// <para>
        /// Returns S_OK if successful, or an error value otherwise, including the following:
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="E_INVALIDARG"/>
        /// </term>
        /// <term>
        /// Among other things, this value can indicate that the <paramref name="rfid"/> parameter
        /// references a <see cref="KNOWNFOLDERID"/> that is not present on the system.
        /// Not all <see cref="KNOWNFOLDERID"/> values are present on all systems.
        /// Use <see cref="IKnownFolderManager.GetFolderIds"/> to retrieve the set of <see cref="KNOWNFOLDERID"/> values for the current system.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function replaces <see cref="SHSetFolderPath"/>.
        /// That older function is now simply a wrapper for <see cref="SHSetKnownFolderPath"/>.
        /// </para>
        /// <para>
        /// The caller of this function must have Administrator privileges.
        /// To call this function on public known folders, the caller must have Administrator privileges.
        /// For per-user known folders the caller only requires User privileges.
        /// </para>
        /// <para>
        /// Some of the known folders, for example, the Documents folder, are per-user.
        /// Every user has a different path for their Documents folder.
        /// If <paramref name="hToken"/> is <see cref="NULL"/>, the API tries to access the calling application's instance of the folder, which is that of the current user.
        /// If <paramref name="hToken"/> is a valid user token, the API tries to impersonate the user using this token and tries to access that user's instance.
        /// </para>
        /// <para>
        /// This function cannot be called on folders of type <see cref="KF_CATEGORY_FIXED"/> and <see cref="KF_CATEGORY_VIRTUAL"/>.
        /// </para>
        /// <para>
        /// To call this function on a folder of type <see cref="KF_CATEGORY_COMMON"/>, the calling application must be running with elevated privileges.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHSetKnownFolderPath", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT SHSetKnownFolderPath([In] in KNOWNFOLDERID rfid, [In] KNOWN_FOLDER_FLAG dwFlags,
            [In] HANDLE hToken, [In] LPCWSTR pszPath);
    }
}
