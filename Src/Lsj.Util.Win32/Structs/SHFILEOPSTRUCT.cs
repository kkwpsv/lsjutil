using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.FILEOP_FLAGS;
using static Lsj.Util.Win32.Enums.ShellFileOperations;
using static Lsj.Util.Win32.Shell32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information that the <see cref="SHFileOperation"/> function uses to perform file operations
    /// Note As of Windows Vista, the use of the <see cref="IFileOperation"/> interface is recommended over this function.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shellapi/ns-shellapi-shfileopstructw
    /// </para>
    /// </summary>
    /// <remarks>
    /// Important
    /// You must ensure that the source and destination paths are double-null terminated. A normal string ends in just a single null character.
    /// If you pass that value in either the source or destination members,
    /// the function will not realize when it has reached the end of the string and will continue to read on in memory
    /// until it comes to a random double null value.
    /// This can at least lead to a buffer overrun, and possibly the unintended deletion of unrelated data.
    /// <code>
    /// // WRONG
    /// LPTSTR pszSource = L"C:\\Windows\\*";
    /// // RIGHT
    /// LPTSTR pszSource = L"C:\\Windows\\*\0";
    /// </code>
    /// To account for the two terminating null characters, be sure to create buffers large enough
    /// to hold <see cref="MAX_PATH"/> (which normally includes the single terminating null character) plus 1.
    /// It cannot be overstated that your paths should always be full paths.
    /// If the <see cref="pFrom"/> or <see cref="pTo"/> members are unqualified names,
    /// the current directories are taken from the global current drive and directory settings
    /// as managed by the <see cref="GetCurrentDirectory"/> and <see cref="SetCurrentDirectory"/> functions.
    /// If you do not provide a full path, the following facts become pertinent:
    /// The lack of a path before a file name does not indicate to SHFileOperation that this file resides in the root of the current directory.
    /// The PATH environment variable is not used by <see cref="SHFileOperation"/> to determine a valid path.
    /// <see cref="SHFileOperation"/> cannot be relied on to use the directory that is the current directory when it begins executing.
    /// The directory seen as the current directory is process-wide, and it can be changed from another thread while the operation is executing. 
    /// If that were to happen, the results of <see cref="SHFileOperation"/> would be unpredictable.
    /// If <see cref="pFrom"/> is set to a file name without a full path,
    /// deleting the file with <see cref="FO_DELETE"/> does not move it to the Recycle Bin, 
    /// even if the <see cref="FOF_ALLOWUNDO"/> flag is set. 
    /// You must provide a full path to delete the file to the Recycle Bin.
    /// <see cref="SHFileOperation"/> fails on any path prefixed with "\?".
    /// There are two versions of this structure, an ANSI version (SHFILEOPSTRUCTA) and a Unicode version (SHFILEOPSTRUCTW).
    /// The Unicode version is identical to the ANSI version, 
    /// except that wide character strings (LPCWSTR) are used in place of ANSI character strings (LPCSTR).
    /// On Windows 98 and earlier, only the ANSI version is supported.
    /// On Microsoft Windows NT 4.0 and later, both the ANSI and Unicode versions of this structure are supported. 
    /// SHFILEOPSTRUCTW and SHFILEOPTSTRUCTA should never be used directly;
    /// the appropriate structure is redefined as <see cref="SHFILEOPSTRUCT"/> by the precompiler
    /// depending on whether the application is compiled for ANSI or Unicode.
    /// <see cref="SHNAMEMAPPING"/> has similar ANSI and Unicode versions.
    /// For ANSI applications, <see cref="hNameMappings"/> points to an int followed by an array of ANSI <see cref="SHNAMEMAPPING"/> structures.
    /// For Unicode applications, <see cref="hNameMappings"/> points to an int followed by an array of Unicode <see cref="SHNAMEMAPPING"/> structures.
    /// However, on Microsoft Windows NT 4.0 and later, <see cref="SHFileOperation"/> always
    /// returns a handle to a Unicode set of <see cref="SHNAMEMAPPING"/> structures.
    /// If you want applications to be functional with all versions of Windows,
    /// the application must employ conditional code to deal with name mappings.
    /// For example:
    /// <code>
    /// x = SHFileOperation(&shop);
    /// if (fWin9x)
    ///     HandleAnsiNameMappings(shop.hNameMappings);
    /// else 
    ///     HandleUnicodeNameMappings(shop.hNameMappings);
    /// </code>
    /// Treat <see cref="hNameMappings"/> as a pointer to a structure whose members are a <see cref="UINT"/> value
    /// followed by a pointer to an array of <see cref="SHNAMEMAPPING"/> structures, as seen in its declaration:
    /// <code>
    /// struct HANDLETOMAPPINGS 
    /// {
    ///     UINT uNumberOfMappings;  // Number of mappings in the array.
    ///     LPSHNAMEMAPPING lpSHNameMapping;    // Pointer to the array of mappings.
    ///     };
    /// </code>
    /// The <see cref="UINT"/> value indicates the number of <see cref="SHNAMEMAPPING"/> structures in the array.
    /// Each <see cref="SHNAMEMAPPING"/> structure contains the old and new path for one of the renamed files.
    /// Note The handle must be freed with <see cref="SHFreeNameMappings"/>.
    /// The shellapi.h header defines <see cref="SHFILEOPSTRUCT"/> as an alias which automatically selects the ANSI or Unicode version
    /// of this function based on the definition of the UNICODE preprocessor constant.
    /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead to
    /// mismatches that result in compilation or runtime errors.
    /// For more information, see Conventions for Function Prototypes.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SHFILEOPSTRUCT
    {
        /// <summary>
        /// A window handle to the dialog box to display information about the status of the file operation.
        /// </summary>
        public HWND hwnd;

        /// <summary>
        /// A value that indicates which operation to perform. One of the following values:
        /// <see cref="FO_COPY"/>:
        /// Copy the files specified in the <see cref="pFrom"/> member to the location specified in the <see cref="pTo"/> member.
        /// <see cref="FO_DELETE"/>:
        /// Delete the files specified in <see cref="pFrom"/>.
        /// <see cref="FO_MOVE"/>:
        /// Move the files specified in <see cref="pFrom"/> to the location specified in <see cref="pTo"/>.
        /// <see cref="FO_RENAME"/>:
        /// Rename the file specified in <see cref="pFrom"/>.
        /// You cannot use this flag to rename multiple files with a single function call.
        /// Use <see cref="FO_MOVE"/> instead.
        /// </summary>
        public ShellFileOperations wFunc;

        /// <summary>
        /// Note  This string must be double-null terminated.
        /// A pointer to one or more source file names.
        /// These names should be fully qualified paths to prevent unexpected results.
        /// Standard MS-DOS wildcard characters, such as "*", are permitted only in the file-name position.
        /// Using a wildcard character elsewhere in the string will lead to unpredictable results.
        /// Although this member is declared as a single null-terminated string,
        /// it is actually a buffer that can hold multiple null-delimited file names.
        /// Each file name is terminated by a single NULL character.
        /// The last file name is terminated with a double NULL character ("\0\0") to indicate the end of the buffer.
        /// </summary>
        public IntPtr pFrom;

        /// <summary>
        /// Note This string must be double-null terminated.
        /// A pointer to the destination file or directory name.
        /// This parameter must be set to <see cref="NULL"/> if it is not used.
        /// Wildcard characters are not allowed.
        /// Their use will lead to unpredictable results.
        /// Like <see cref="pFrom"/>, the <see cref="pTo"/> member is also a double-null terminated string and is handled in much the same way.
        /// However, pTo must meet the following specifications:
        /// Wildcard characters are not supported.
        /// Copy and Move operations can specify destination directories that do not exist.
        /// In those cases, the system attempts to create them and normally displays a dialog box
        /// to ask the user if they want to create the new directory.
        /// To suppress this dialog box and have the directories created silently,
        /// set the <see cref="FOF_NOCONFIRMMKDIR"/> flag in <see cref="fFlags"/>.
        /// For Copy and Move operations, the buffer can contain multiple destination file names
        /// if the <see cref="fFlags"/> member specifies <see cref="FOF_MULTIDESTFILES"/>.
        /// Pack multiple names into the pTo string in the same way as for <see cref="pFrom"/>.
        /// Use fully qualified paths.
        /// Using relative paths is not prohibited, but can have unpredictable results.
        /// </summary>
        public IntPtr pTo;

        /// <summary>
        /// Flags that control the file operation. This member can take a combination of the following flags.
        /// <see cref="FOF_ALLOWUNDO"/>:
        /// Preserve undo information, if possible.
        /// Prior to Windows Vista, operations could be undone only from the same process that performed the original operation.
        /// In Windows Vista and later systems, the scope of the undo is a user session.
        /// Any process running in the user session can undo another operation.
        /// The undo state is held in the Explorer.exe process, and as long as that process is running, it can coordinate the undo functions.
        /// If the source file parameter does not contain fully qualified path and file names, this flag is ignored.
        /// <see cref="FOF_CONFIRMMOUSE"/>:
        /// Not used.
        /// <see cref="FOF_FILESONLY"/>:
        /// Perform the operation only on files (not on folders) if a wildcard file name (.) is specified.
        /// <see cref="FOF_MULTIDESTFILES"/>:
        /// The pTo member specifies multiple destination files (one for each source file in <see cref="pFrom"/>)
        /// rather than one directory where all source files are to be deposited.
        /// <see cref="FOF_NOCONFIRMATION"/>:
        /// Respond with Yes to All for any dialog box that is displayed.
        /// <see cref="FOF_NOCONFIRMMKDIR"/>:
        /// Do not ask the user to confirm the creation of a new directory if the operation requires one to be created.
        /// <see cref="FOF_NO_CONNECTED_ELEMENTS"/>:
        /// Version 5.0. Do not move connected files as a group. Only move the specified files.
        /// <see cref="FOF_NOCOPYSECURITYATTRIBS"/>:
        /// Version 4.71. Do not copy the security attributes of the file. The destination file receives the security attributes of its new folder.
        /// <see cref="FOF_NOERRORUI"/>:
        /// Do not display a dialog to the user if an error occurs.
        /// <see cref="FOF_NORECURSEREPARSE"/>:
        /// Not used.
        /// <see cref="FOF_NORECURSION"/>:
        /// Only perform the operation in the local directory. Do not operate recursively into subdirectories, which is the default behavior.
        /// <see cref="FOF_NO_UI"/>:
        /// Windows Vista. Perform the operation silently, presenting no UI to the user.
        /// This is equivalent to <code>FOF_SILENT | FOF_NOCONFIRMATION | FOF_NOERRORUI | FOF_NOCONFIRMMKDIR</code>.
        /// <see cref="FOF_RENAMEONCOLLISION"/>:
        /// Give the file being operated on a new name in a move, copy, or rename operation
        /// if a file with the target name already exists at the destination.
        /// <see cref="FOF_SILENT"/>:
        /// Do not display a progress dialog box.
        /// <see cref="FOF_SIMPLEPROGRESS"/>:
        /// Display a progress dialog box but do not show individual file names as they are operated on.
        /// <see cref="FOF_WANTMAPPINGHANDLE"/>:
        /// If <see cref="FOF_RENAMEONCOLLISION"/> is specified and any files were renamed,
        /// assign a name mapping object that contains their old and new names to the <see cref="hNameMappings"/> member.
        /// This object must be freed using <see cref="SHFreeNameMappings"/> when it is no longer needed.
        /// <see cref="FOF_WANTNUKEWARNING"/>:
        /// Version 5.0.
        /// Send a warning if a file is being permanently destroyed during a delete operation rather than recycled.
        /// This flag partially overrides <see cref="FOF_NOCONFIRMATION"/>.
        /// </summary>
        public FILEOP_FLAGS fFlags;

        /// <summary>
        /// When the function returns,
        /// this member contains <see cref="TRUE"/> if any file operations were aborted before they were completed; otherwise, <see cref="FALSE"/>.
        /// An operation can be manually aborted by the user through UI or it can be silently aborted by the system
        /// if the <see cref="FOF_NOERRORUI"/> or <see cref="FOF_NOCONFIRMATION"/> flags were set.
        /// </summary>
        public BOOL fAnyOperationsAborted;

        /// <summary>
        /// When the function returns, this member contains a handle to a name mapping object that contains the old and new names of the renamed files.
        /// This member is used only if the <see cref="fFlags"/> member includes the <see cref="FOF_WANTMAPPINGHANDLE"/> flag.
        /// See Remarks for more details.
        /// </summary>
        public LPVOID hNameMappings;

        /// <summary>
        /// A pointer to the title of a progress dialog box.
        /// This is a null-terminated string.
        /// This member is used only if <see cref="fFlags"/> includes the <see cref="FOF_SIMPLEPROGRESS"/> flag.
        /// </summary>
        public IntPtr lpszProgressTitle;
    }
}
