using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.ACCESS_MASK;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HFILE;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.BaseTypes.WaitResult;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.ConsoleModes;
using static Lsj.Util.Win32.Enums.COPYFILE2_MESSAGE_ACTION;
using static Lsj.Util.Win32.Enums.COPYFILE2_MESSAGE_TYPE;
using static Lsj.Util.Win32.Enums.CopyFileFlags;
using static Lsj.Util.Win32.Enums.DefineDosDeviceFlags;
using static Lsj.Util.Win32.Enums.DeviceRegistryPropertyCodes;
using static Lsj.Util.Win32.Enums.DriveTypes;
using static Lsj.Util.Win32.Enums.ErrorModes;
using static Lsj.Util.Win32.Enums.FILE_INFO_BY_HANDLE_CLASS;
using static Lsj.Util.Win32.Enums.FileAccessRights;
using static Lsj.Util.Win32.Enums.FileAttributes;
using static Lsj.Util.Win32.Enums.FileCompletionNotificationModes;
using static Lsj.Util.Win32.Enums.FileCreationDispositions;
using static Lsj.Util.Win32.Enums.FileFlags;
using static Lsj.Util.Win32.Enums.FileNotifyFilters;
using static Lsj.Util.Win32.Enums.FileShareModes;
using static Lsj.Util.Win32.Enums.FileSystemFlags;
using static Lsj.Util.Win32.Enums.FileTypes;
using static Lsj.Util.Win32.Enums.FINDEX_SEARCH_OPS;
using static Lsj.Util.Win32.Enums.FindFirstFileExFlags;
using static Lsj.Util.Win32.Enums.GenericAccessRights;
using static Lsj.Util.Win32.Enums.GET_FILEEX_INFO_LEVELS;
using static Lsj.Util.Win32.Enums.GetFinalPathNameByHandleFlags;
using static Lsj.Util.Win32.Enums.IoControlCodes;
using static Lsj.Util.Win32.Enums.LockFileExFlags;
using static Lsj.Util.Win32.Enums.LPPROGRESS_ROUTINECallbackReasons;
using static Lsj.Util.Win32.Enums.LPPROGRESS_ROUTINEResults;
using static Lsj.Util.Win32.Enums.MoveMethods;
using static Lsj.Util.Win32.Enums.OpenFileFlags;
using static Lsj.Util.Win32.Enums.ReplaceFileFlags;
using static Lsj.Util.Win32.Enums.SECURITY_INFORMATION;
using static Lsj.Util.Win32.Enums.SecurityQualityOfServiceFlags;
using static Lsj.Util.Win32.Enums.StandardAccessRights;
using static Lsj.Util.Win32.Enums.STREAM_INFO_LEVELS;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.TXFS_MINIVERSION;
using static Lsj.Util.Win32.Ktmw32;
using static Lsj.Util.Win32.SetupAPI;
using static Lsj.Util.Win32.Shell32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using FILETIME = Lsj.Util.Win32.Structs.FILETIME;
using static Lsj.Util.Win32.Enums.MoveFileFlags;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// Copies an existing file to a new file as a transacted operation, notifying the application of its progress through a callback function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-copyfiletransactedw"/>
        /// </para>
        /// </summary>
        /// <param name="lpExistingFileName">
        /// The name of an existing file.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File.
        /// If <paramref name="lpExistingFileName"/> does not exist, the <see cref="CopyFileTransacted"/> function fails,
        /// and the <see cref="GetLastError"/> function returns <see cref="ERROR_FILE_NOT_FOUND"/>.
        /// The file must reside on the local computer; otherwise,
        /// the function fails and the last error code is set to <see cref="ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE"/>.
        /// </param>
        /// <param name="lpNewFileName">
        /// The name of the new file.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File.
        /// </param>
        /// <param name="lpProgressRoutine">
        /// The address of a callback function of type <see cref="LPPROGRESS_ROUTINE"/> that is called each time another portion of the file has been copied.
        /// This parameter can be <see cref="NULL"/>.
        /// For more information on the progress callback function, see the CopyProgressRoutine function.
        /// </param>
        /// <param name="lpData">
        /// The argument to be passed to the callback function.
        /// This parameter can be <see cref="NULL"/>.
        /// </param>
        /// <param name="pbCancel">
        /// If this flag is set to <see cref="TRUE"/> during the copy operation, the operation is canceled.
        /// Otherwise, the copy operation will continue to completion.
        /// </param>
        /// <param name="dwCopyFlags">
        /// Flags that specify how the file is to be copied.
        /// This parameter can be a combination of the following values.
        /// <see cref="COPY_FILE_COPY_SYMLINK"/>:
        /// f the source file is a symbolic link, the destination file is also a symbolic link pointing to the same file that the source symbolic link is pointing to.
        /// <see cref="COPY_FILE_FAIL_IF_EXISTS"/>:
        /// The copy operation fails immediately if the target file already exists.
        /// <see cref="COPY_FILE_OPEN_SOURCE_FOR_WRITE"/>:
        /// The file is copied and the original file is opened for write access.
        /// <see cref="COPY_FILE_RESTARTABLE"/>:
        /// Progress of the copy is tracked in the target file in case the copy fails.
        /// The failed copy can be restarted at a later time by specifying the same values
        /// for <paramref name="lpExistingFileName"/> and <paramref name="lpNewFileName"/> as those used in the call that failed.
        /// This can significantly slow down the copy operation as the new file may be flushed multiple times during the copy operation.
        /// </param>
        /// <param name="hTransaction">
        /// A handle to the transaction.
        /// This handle is returned by the <see cref="CreateTransaction"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>. To get extended error information call <see cref="GetLastError"/>.
        /// If <paramref name="lpProgressRoutine"/> returns <see cref="PROGRESS_CANCEL"/> due to the user canceling the operation,
        /// <see cref="CopyFileTransacted"/> will return <see cref="FALSE"/> and <see cref="GetLastError"/> will return <see cref="ERROR_REQUEST_ABORTED"/>.
        /// In this case, the partially copied destination file is deleted.
        /// If <paramref name="lpProgressRoutine"/> returns <see cref="PROGRESS_STOP"/> due to the user stopping the operation,
        /// <see cref="CopyFileTransacted"/> will return <see cref="FALSE"/> and <see cref="GetLastError"/> will return <see cref="ERROR_REQUEST_ABORTED"/>.
        /// In this case, the partially copied destination file is left intact.
        /// If you attempt to call this function with a handle to a transaction that has already been rolled back,
        /// <see cref="CopyFileTransacted"/> will return either <see cref="ERROR_TRANSACTION_NOT_ACTIVE"/> or <see cref="ERROR_INVALID_TRANSACTION"/>.
        /// </returns>
        /// <remarks>
        /// This function preserves extended attributes, OLE structured storage, NTFS file system alternate data streams, security resource attributes, and file attributes.
        /// Windows 7, Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// Security resource attributes (ATTRIBUTE_SECURITY_INFORMATION) for the existing file are not copied to the new file until Windows 8 and Windows Server 2012.
        /// The security resource properties (ATTRIBUTE_SECURITY_INFORMATION) for the existing file are copied to the new file.
        /// Windows 7, Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// Security resource properties for the existing file are not copied to the new file until Windows 8 and Windows Server 2012.
        /// This function fails with <see cref="ERROR_ACCESS_DENIED"/> if the destination file already exists
        /// and has the <see cref="FILE_ATTRIBUTE_HIDDEN"/> or <see cref="FILE_ATTRIBUTE_READONLY"/> attribute set.
        /// When encrypted files are copied using <see cref="CopyFileEx"/>, the function attempts to encrypt the destination file
        /// with the keys used in the encryption of the source file. If this cannot be done, this function attempts to encrypt the destination file with default keys.
        /// If both of these methods cannot be done, <see cref="CopyFileEx"/> fails with an <see cref="ERROR_ENCRYPTION_FAILED"/> error code.
        /// If you want <see cref="CopyFileEx"/> to complete the copy operation even if the destination file cannot be encrypted,
        /// include the <see cref="COPY_FILE_ALLOW_DECRYPTED_DESTINATION"/> as the value of the <paramref name="dwCopyFlags"/> parameter in your call to <see cref="CopyFileEx"/>.
        /// If <see cref="COPY_FILE_COPY_SYMLINK"/> is specified, the following rules apply:
        /// If the source file is a symbolic link, the symbolic link is copied, not the target file.
        /// If the source file is not a symbolic link, there is no change in behavior.
        /// If the destination file is an existing symbolic link, the symbolic link is overwritten, not the target file.
        /// If <see cref="COPY_FILE_FAIL_IF_EXISTS"/> is also specified, and the destination file is an existing symbolic link, the operation fails in all cases.
        /// If <see cref="COPY_FILE_COPY_SYMLINK"/> is not specified, the following rules apply:
        /// If <see cref="COPY_FILE_FAIL_IF_EXISTS"/> is also specified, and the destination file is an existing symbolic link,
        /// the operation fails only if the target of the symbolic link exists.
        /// If <see cref="COPY_FILE_FAIL_IF_EXISTS"/> is not specified, there is no change in behavior.
        /// Link tracking is not supported by TxF.
        /// </remarks>
        [Obsolete("Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. " +
            "Many scenarios that TxF was developed for can be achieved through simpler and more readily available techniques. " +
            "Furthermore, TxF may not be available in future versions of Microsoft Windows. " +
            "For more information, and alternatives to TxF, please see Alternatives to using Transactional NTFS.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CopyFileTransactedW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CopyFileTransacted([In] LPCWSTR lpExistingFileName, [In] LPCWSTR lpNewFileName, [In] LPPROGRESS_ROUTINE lpProgressRoutine,
            [In] LPVOID lpData, [In] LP<BOOL> pbCancel, [In] CopyFileFlags dwCopyFlags, [In] HANDLE hTransaction);

        /// <summary>
        /// <para>
        /// Creates a new directory as a transacted operation, with the attributes of a specified template directory.
        /// If the underlying file system supports security on files and directories,
        /// the function applies a specified security descriptor to the new directory.
        /// The new directory retains the other attributes of the specified template directory.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-createdirectorytransactedw"/>
        /// </para>
        /// </summary>
        /// <param name="lpTemplateDirectory">
        /// The path of the directory to use as a template when creating the new directory. This parameter can be <see langword="null"/>.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File.
        /// The directory must reside on the local computer; otherwise, the function fails and
        /// the last error code is set to <see cref="ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE"/>.
        /// </param>
        /// <param name="lpNewDirectory">
        /// The path of the directory to be created.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File.
        /// </param>
        /// <param name="lpSecurityAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure.
        /// The <paramref name="lpSecurityAttributes"/> member of the structure specifies a security descriptor for the new directory.
        /// If <paramref name="lpSecurityAttributes"/> is <see langword="null"/>, the directory gets a default security descriptor.
        /// The access control lists (ACL) in the default security descriptor for a directory are inherited from its parent directory.
        /// The target file system must support security on files and directories for this parameter to have an effect.
        /// This is indicated when <see cref="GetVolumeInformation"/> returns <see cref="FS_PERSISTENT_ACLS"/>.
        /// </param>
        /// <param name="hTransaction">
        /// A handle to the transaction.
        /// This handle is returned by the <see cref="CreateTransaction"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// Possible errors include the following.
        /// <see cref="ERROR_ALREADY_EXISTS"/>: The specified directory already exists.
        /// <see cref="ERROR_EFS_NOT_ALLOWED_IN_TRANSACTION"/>:
        /// You cannot create a child directory with a parent directory that has encryption disabled.
        /// <see cref="ERROR_PATH_NOT_FOUND"/>:
        /// One or more intermediate directories do not exist.
        /// This function only creates the final directory in the path.
        /// </returns>
        /// <remarks>
        /// The <see cref="CreateDirectoryTransacted"/> function allows you to create directories that inherit stream information from other directories.
        /// This function is useful, for example, when you are using Macintosh directories,
        /// which have a resource stream that is needed to properly identify directory contents as an attribute.
        /// Some file systems, such as the NTFS file system, support compression or encryption for individual files and directories.
        /// On volumes formatted for such a file system, a new directory inherits the compression and encryption attributes of its parent directory.
        /// This function fails with <see cref="ERROR_EFS_NOT_ALLOWED_IN_TRANSACTION"/> if you try to create a child directory
        /// with a parent directory that has encryption disabled.
        /// You can obtain a handle to a directory by calling the <see cref="CreateFileTransacted"/> function
        /// with the <see cref="FILE_FLAG_BACKUP_SEMANTICS"/> flag set.
        /// </remarks>
        [Obsolete("Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs." +
            " Many scenarios that TxF was developed for can be achieved through simpler and more readily available techniques." +
            " Furthermore, TxF may not be available in future versions of Microsoft Windows." +
            " For more information, and alternatives to TxF, please see Alternatives to using Transactional NTFS.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDirectoryTransactedW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CreateDirectoryTransacted([In] LPCWSTR lpTemplateDirectory, [In] LPCWSTR lpNewDirectory,
            [In] in SECURITY_ATTRIBUTES lpSecurityAttributes, HANDLE hTransaction);

        /// <summary>
        /// <para>
        /// Establishes a hard link between an existing file and a new file.
        /// This function is only supported on the NTFS file system, and only for files, not directories.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-createhardlinktransactedw"/>
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// The name of the new file.
        /// This parameter may include the path but cannot specify the name of a directory.
        /// </param>
        /// <param name="lpExistingFileName">
        /// The name of the existing file.
        /// This parameter may include the path cannot specify the name of a directory.
        /// </param>
        /// <param name="lpSecurityAttributes">
        /// Reserved; must be <see cref="NULL"/>.
        /// </param>
        /// <param name="hTransaction">
        /// A handle to the transaction. This handle is returned by the <see cref="CreateTransaction"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// The maximum number of hard links that can be created with this function is 1023 per file.
        /// If more than 1023 links are created for a file, an error results.
        /// The files must reside on the local computer; otherwise, the function fails
        /// and the last error code is set to <see cref="ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE"/>.
        /// </returns>
        /// <remarks>
        /// Any directory entry for a file that is created with <see cref="CreateFileTransacted"/>
        /// or <see cref="CreateHardLinkTransacted"/> is a hard link to an associated file.
        /// An additional hard link that is created with the <see cref="CreateHardLinkTransacted"/> function allows you to have multiple directory entries for a file,
        /// that is, multiple hard links to the same file, which can be different names in the same directory, or the same or different names in different directories.
        /// However, all hard links to a file must be on the same volume.
        /// Because hard links are only directory entries for a file, many changes to that file are instantly visible to applications
        /// that access it through the hard links that reference it.
        /// However, the directory entry size and attribute information is updated only for the link through which the change was made.
        /// The security descriptor belongs to the file to which a hard link points.
        /// The link itself is only a directory entry, and does not have a security descriptor.
        /// Therefore, when you change the security descriptor of a hard link, you a change the security descriptor of the underlying file,
        /// and all hard links that point to the file allow the newly specified access.
        /// You cannot give a file different security descriptors on a per-hard-link basis.
        /// This function does not modify the security descriptor of the file to be linked to,
        /// even if security descriptor information is passed in the <paramref name="lpSecurityAttributes"/> parameter.
        /// Use <see cref="DeleteFileTransacted"/> to delete hard links.
        /// You can delete them in any order regardless of the order in which they are created.
        /// Flags, attributes, access, and sharing that are specified in CreateFile operate on a per-file basis.
        /// That is, if you open a file that does not allow sharing, another application cannot share the file by creating a new hard link to the file.
        /// When you create a hard link on the NTFS file system, the file attribute information
        /// in the directory entry is refreshed only when the file is opened, or when <see cref="GetFileInformationByHandle"/> is called with the handle of a specific file.
        /// Symbolic link behavior—If the path points to a symbolic link, the function creates a hard link to the target.
        /// </remarks>
        [Obsolete("Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs." +
            " Many scenarios that TxF was developed for can be achieved through simpler and more readily available techniques." +
            " Furthermore, TxF may not be available in future versions of Microsoft Windows." +
            " For more information, and alternatives to TxF, please see Alternatives to using Transactional NTFS.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateHardLinkTransactedW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CreateHardLinkTransacted([In] LPCWSTR lpFileName, [In] LPCWSTR lpExistingFileName,
            [In] IntPtr lpSecurityAttributes, [In] HANDLE hTransaction);

        /// <summary>
        /// <para>
        /// Creates a symbolic link.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-createsymboliclinkw"/>
        /// </para>
        /// </summary>
        /// <param name="lpSymlinkFileName">
        /// The symbolic link to be created.
        /// </param>
        /// <param name="lpTargetFileName">
        /// The name of the target for the symbolic link to be created.
        /// If lpTargetFileName has a device name associated with it, the link is treated as an absolute link; otherwise, the link is treated as a relative link.
        /// </param>
        /// <param name="dwFlags">
        /// Indicates whether the link target, <paramref name="lpTargetFileName"/>, is a directory.
        /// 0x0:
        /// The link target is a file.
        /// <see cref="SYMBOLIC_LINK_FLAG_DIRECTORY"/>:
        /// The link target is a directory.
        /// </param>
        /// <param name="hTransaction">
        /// A handle to the transaction.
        /// This handle is returned by the <see cref="CreateTransaction"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Symbolic links can either be absolute or relative links.
        /// Absolute links are links that specify each portion of the path name;
        /// relative links are determined relative to where relative–link specifiers are in a specified path.
        /// Relative links are specified using the following conventions:
        /// Dot (. and ..) conventions—for example, "..\" resolves the path relative to the parent directory.
        /// Names with no slashes (\\)—for example, "tmp" resolves the path relative to the current directory.
        /// Root relative—for example, "\Windows\System32" resolves to "current drive:\Windows\System32".
        /// Current working directory–relative—for example, if the current working directory is C:\Windows\System32, "C:File.txt" resolves to "C:\Windows\System32\File.txt".
        /// Note  If you specify a current working directory–relative link, it is created as an absolute link,
        /// due to the way the current working directory is processed based on the user and the thread.
        /// </remarks>
        [Obsolete("Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs." +
            " Many scenarios that TxF was developed for can be achieved through simpler and more readily available techniques." +
            " Furthermore, TxF may not be available in future versions of Microsoft Windows." +
            " For more information, and alternatives to TxF, please see Alternatives to using Transactional NTFS.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateSymbolicLinkTransactedW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOLEAN CreateSymbolicLinkTransacted([In] LPCWSTR lpSymlinkFileName, [In] LPCWSTR lpTargetFileName, [In] DWORD dwFlags, [In] HANDLE hTransaction);

        /// <summary>
        /// <para>
        /// Creates or opens a file, file stream, or directory as a transacted operation.
        /// The function returns a handle that can be used to access the object.
        /// To perform this operation as a nontransacted operation or to access objects
        /// other than files(for example, named pipes, physical devices, mailslots), use the <see cref="CreateFile"/> function.
        /// For more information about transactions, see the Remarks section of this topic.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-createfiletransactedw"/>
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// The name of an object to be created or opened.
        /// The object must reside on the local computer
        /// otherwise, the function fails and the last error code is set to <see cref="ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE"/>.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File. For information on special device names, see Defining an MS-DOS Device Name.
        /// To create a file stream, specify the name of the file, a colon, and then the name of the stream.
        /// For more information, see File Streams.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// The access to the object, which can be summarized as read, write, both or neither (zero).
        /// The most commonly used values are <see cref="GENERIC_READ"/>, <see cref="GENERIC_WRITE"/>,
        /// or both (<see cref="GENERIC_READ"/> | <see cref="GENERIC_WRITE"/>).
        /// For more information, see Generic Access Rights and File Security and Access Rights.
        /// If this parameter is zero, the application can query file, directory, or device attributes without accessing that file or device.
        /// For more information, see the Remarks section of this topic.
        /// You cannot request an access mode that conflicts with the sharing mode that is specified in an open request that has an open handle.
        /// For more information, see Creating and Opening Files.
        /// </param>
        /// <param name="dwShareMode">
        /// The sharing mode of an object, which can be read, write, both, delete, all of these, or none (refer to the following table).
        /// If this parameter is zero and <see cref="CreateFileTransacted"/> succeeds,
        /// the object cannot be shared and cannot be opened again until the handle is closed.
        /// For more information, see the Remarks section of this topic.
        /// You cannot request a sharing mode that conflicts with the access mode that is specified in an open request that has an open handle,
        /// because that would result in the following sharing violation: <see cref="ERROR_SHARING_VIOLATION"/>.
        /// For more information, see Creating and Opening Files.
        /// To enable a process to share an object while another process has the object open,
        /// use a combination of one or more of the following values to specify the access mode they can request to open the object.
        /// The sharing options for each open handle remain in effect until that handle is closed, regardless of process context.
        /// </param>
        /// <param name="lpSecurityAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that contains an optional security descriptor and
        /// also determines whether or not the returned handle can be inherited by child processes.
        /// The parameter can be <see cref="IntPtr.Zero"/>.
        /// If the <paramref name="lpSecurityAttributes"/> parameter is <see langword="null"/>, the handle returned by <see cref="CreateFileTransacted"/> 
        /// cannot be inherited by any child processes your application may create and
        /// the object associated with the returned handle gets a default security descriptor.
        /// The <see cref="SECURITY_ATTRIBUTES.bInheritHandle"/> member of the structure specifies whether the returned handle can be inherited.
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for an object,
        /// but may also be NULL.
        /// If <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member is <see cref="IntPtr.Zero"/>,
        /// the object associated with the returned handle is assigned a default security descriptor.
        /// <see cref="CreateFileTransacted"/> ignores the <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member when opening an existing file,
        /// but continues to use the <see cref="SECURITY_ATTRIBUTES.bInheritHandle"/> member.
        /// For more information, see the Remarks section of this topic.
        /// </param>
        /// <param name="dwCreationDisposition">
        /// An action to take on files that exist and do not exist.
        /// For more information, see the Remarks section of this topic.
        /// </param>
        /// <param name="dwFlagsAndAttributes">
        /// The file attributes and flags, <see cref="FILE_ATTRIBUTE_NORMAL"/> being the most common default value.
        /// This parameter can include any combination of the available file attributes (FILE_ATTRIBUTE_*).
        /// All other file attributes override <see cref="FILE_ATTRIBUTE_NORMAL"/>.
        /// This parameter can also contain combinations of flags (FILE_FLAG_) for control of buffering behavior,
        /// access modes, and other special-purpose flags. These combine with any FILE_ATTRIBUTE_ values.
        /// This parameter can also contain Security Quality of Service (SQOS) information
        /// by specifying the <see cref="SECURITY_SQOS_PRESENT"/> flag.
        /// Additional SQOS-related flags information is presented in the table following the attributes and flags tables.
        /// When <see cref="CreateFileTransacted"/> opens an existing file, it generally combines the file flags
        /// with the file attributes of the existing file, and ignores any file attributes supplied as part of <paramref name="dwFlagsAndAttributes"/>.
        /// Special cases are detailed in Creating and Opening Files.
        /// The following file attributes and flags are used only for file objects, not other types of objects
        /// that <see cref="CreateFileTransacted"/> opens (additional information can be found in the Remarks section of this topic).
        /// For more advanced access to file attributes, see <see cref="SetFileAttributes"/>.
        /// For a complete list of all file attributes with their values and descriptions, see File Attribute 
        /// The <paramref name="lpSecurityAttributes"/> parameter can also specify SQOS information.
        /// For more information, see Impersonation Levels.
        /// When the calling application specifies the <see cref="SECURITY_SQOS_PRESENT"/> flag
        /// as part of <paramref name="dwFlagsAndAttributes"/>, it can also contain one or more of the following values.
        /// <see cref="SECURITY_ANONYMOUS"/>, <see cref="SECURITY_CONTEXT_TRACKING"/>, <see cref="SECURITY_DELEGATION"/>,
        /// <see cref="SECURITY_EFFECTIVE_ONLY"/>, <see cref="SECURITY_IDENTIFICATION"/>, <see cref="SECURITY_IMPERSONATION"/>
        /// </param>
        /// <param name="hTemplateFile">
        /// A valid handle to a template file with the <see cref="GENERIC_READ"/> access right.
        /// The template file supplies file attributes and extended attributes for the file that is being created.
        /// This parameter can be <see cref="IntPtr.Zero"/>.
        /// When opening an existing file, <see cref="CreateFileTransacted"/> ignores the template file.
        /// When opening a new EFS-encrypted file, the file inherits the DACL from its parent directory.
        /// </param>
        /// <param name="hTransaction">
        /// A handle to the transaction.
        /// This handle is returned by the <see cref="CreateTransaction"/> function.
        /// </param>
        /// <param name="pusMiniVersion">
        /// The miniversion to be opened.
        /// If the transaction specified in hTransaction is not the transaction that is modifying the file,
        /// this parameter should be <see cref="IntPtr.Zero"/>.
        /// Otherwise, this parameter can be a miniversion identifier returned by the <see cref="FSCTL_TXFS_CREATE_MINIVERSION"/> control code,
        /// or one of the following values.
        /// <see cref="TXFS_MINIVERSION_COMMITTED_VIEW"/>, <see cref="TXFS_MINIVERSION_DIRTY_VIEW"/>, <see cref="TXFS_MINIVERSION_DEFAULT_VIEW"/>.
        /// </param>
        /// <param name="lpExtendedParameter">
        /// This parameter is reserved and must be <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is an open handle to the specified file, device, named pipe, or mail slot.
        /// If the function fails, the return value is <see cref="INVALID_HANDLE_VALUE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// When using the handle returned by <see cref="CreateFileTransacted"/>,
        /// use the transacted version of file I/O functions instead of the standard file I/O functions where appropriate.
        /// For more information, see Programming Considerations for Transactional NTFS.
        /// When opening a transacted handle to a directory, that handle must have <see cref="FILE_WRITE_DATA"/>
        /// (<see cref="FILE_ADD_FILE"/>) and <see cref="FILE_APPEND_DATA"/>
        /// (<see cref="FILE_ADD_SUBDIRECTORY"/>) permissions.
        /// These are included in <see cref="FILE_GENERIC_WRITE"/> permissions.
        /// You should open directories with fewer permissions if you are just using the handle to create files or subdirectories;
        /// otherwise, sharing violations can occur.
        /// You cannot open a file with <see cref="FILE_EXECUTE"/> access level
        /// when that file is a part of another transaction (that is, another application opened it by calling <see cref="CreateFileTransacted"/>).
        /// This means that <see cref="CreateFileTransacted"/> fails if the access level
        /// <see cref="FILE_EXECUTE"/> or <see cref="FILE_ALL_ACCESS"/> is specified.
        /// When a non-transacted application calls <see cref="CreateFileTransacted"/> with <see cref="MAXIMUM_ALLOWED"/> specified 
        /// for <paramref name="lpSecurityAttributes"/>, a handle is opened with the same access level every time.
        /// When a transacted application calls <see cref="CreateFileTransacted"/> with <see cref="MAXIMUM_ALLOWED"/> specified
        /// for <paramref name="lpSecurityAttributes"/>, a handle is opened with a differing amount of access based on
        /// whether the file is locked by a transaction.
        /// For example, if the calling application has <see cref="FILE_EXECUTE"/> access level for a file,
        /// the application only obtains this access if the file that is being opened is either not locked by a transaction,
        /// or is locked by a transaction and the application is already a transacted reader for that file.
        /// See Transactional NTFS for a complete description of transacted operations.
        /// Use the <see cref="CloseHandle"/> function to close an object handle returned by <see cref="CreateFileTransacted"/>
        /// when the handle is no longer needed, and prior to committing or rolling back the transaction.
        /// Some file systems, such as the NTFS file system, support compression or encryption for individual files and directories.
        /// On volumes that are formatted for that kind of file system, a new file inherits the compression and encryption attributes of its directory.
        /// You cannot use <see cref="CreateFileTransacted"/> to control compression on a file or directory.
        /// For more information, see File Compression and Decompression, and File Encryption.
        /// Symbolic link behavior—If the call to this function creates a new file, there is no change in behavior.
        /// If <see cref="FILE_FLAG_OPEN_REPARSE_POINT"/> is specified:
        /// If an existing file is opened and it is a symbolic link, the handle returned is a handle to the symbolic link.
        /// If <see cref="TRUNCATE_EXISTING"/> or <see cref="FILE_FLAG_DELETE_ON_CLOSE"/> are specified,
        /// the file affected is a symbolic link.
        /// If <see cref="FILE_FLAG_OPEN_REPARSE_POINT"/> is not specified:
        /// If an existing file is opened and it is a symbolic link, the handle returned is a handle to the target.
        /// If <see cref="CREATE_ALWAYS"/>, <see cref="TRUNCATE_EXISTING"/>,
        /// or <see cref="FILE_FLAG_DELETE_ON_CLOSE"/> are specified, the file affected is the target.
        /// A multi-sector write is not guaranteed to be atomic unless you are using a transaction (that is, the handle created is a transacted handle).
        /// A single-sector write is atomic. Multi-sector writes that are cached may not always be written to the disk;
        /// therefore, specify <see cref="FILE_FLAG_WRITE_THROUGH"/> to ensure that
        /// an entire multi-sector write is written to the disk without caching.
        /// As stated previously, if the <paramref name="lpSecurityAttributes"/> parameter is <see cref="IntPtr.Zero"/>,
        /// the handle returned by <see cref="CreateFileTransacted"/> cannot be inherited by any child processes your application may create.
        /// The following information regarding this parameter also applies:
        /// If <see cref="SECURITY_ATTRIBUTES.bInheritHandle"/> is not <see langword="false"/>, which is any nonzero value,
        /// then the handle can be inherited. Therefore it is critical this structure member be properly
        /// initialized to <see langword="false"/> if you do not intend the handle to be inheritable.
        /// The access control lists(ACL) in the default security descriptor for a file or directory are inherited from its parent directory.
        /// The target file system must support security on files and directories for
        /// the <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> to have an effect on them,
        /// which can be determined by using <see cref="GetVolumeInformation"/>.
        /// Files
        /// If you try to create a file on a floppy drive that does not have a floppy disk or a CD-ROM drive that does not have a CD,
        /// the system displays a message for the user to insert a disk or a CD.
        /// To prevent the system from displaying this message, call the <see cref="SetErrorMode"/> function with <see cref="SEM_FAILCRITICALERRORS"/>.
        /// For more information, see Creating and Opening Files.
        /// If you rename or delete a file and then restore it shortly afterward, the system searches the cache for file information to restore.
        /// Cached information includes its short/long name pair and creation time.
        /// If you call <see cref="CreateFileTransacted"/> on a file that is pending deletion as a result of a previous call to <see cref="DeleteFile"/>,
        /// the function fails. The operating system delays file deletion until all handles to the file are closed.
        /// <see cref="GetLastError"/> returns <see cref="ERROR_ACCESS_DENIED"/>.
        /// The <paramref name="dwDesiredAccess"/> parameter can be zero, allowing the application to query file attributes
        /// without accessing the file if the application is running with adequate security settings.
        /// This is useful to test for the existence of a file without opening it for read and/or write access,
        /// or to obtain other statistics about the file or directory.
        /// See Obtaining and Setting File Information and <see cref="GetFileInformationByHandle"/>.
        /// When an application creates a file across a network, it is better to use
        /// <see cref="GENERIC_READ"/> | <see cref="GENERIC_WRITE"/> than
        /// to use <see cref="GENERIC_WRITE"/> alone.
        /// The resulting code is faster, because the redirector can use the cache manager and send fewer SMBs with more data.
        /// This combination also avoids an issue where writing to a file
        /// across a network can occasionally return <see cref="ERROR_ACCESS_DENIED"/>.
        /// File Streams
        /// On NTFS file systems, you can use <see cref="CreateFileTransacted"/> to create separate streams within a file.
        /// For more information, see File Streams.
        /// Directories
        /// An application cannot create a directory by using <see cref="CreateFileTransacted"/>,
        /// therefore only the <see cref="OPEN_EXISTING"/> value is valid
        /// for <paramref name="dwCreationDisposition"/> for this use case.
        /// To create a directory, the application must call <see cref="CreateDirectoryTransacted"/>,
        /// <see cref="CreateDirectory"/> or <see cref="CreateDirectoryEx"/>.
        /// To open a directory using <see cref="CreateFileTransacted"/>, specify the <see cref="FILE_FLAG_BACKUP_SEMANTICS"/> flag
        /// as part of <paramref name="dwFlagsAndAttributes"/>.
        /// Appropriate security checks still apply when this flag is used without SE_BACKUP_NAME and SE_RESTORE_NAME privileges.
        /// When using <see cref="CreateFileTransacted"/> to open a directory during defragmentation of a FAT or FAT32 file system volume,
        /// do not specify the <see cref="MAXIMUM_ALLOWED"/> access right. Access to the directory is denied if this is done.
        /// Specify the <see cref="GENERIC_READ"/> access right instead.
        /// For more information, see About Directory Management.
        /// </remarks>
        [Obsolete("Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs." +
            " Many scenarios that TxF was developed for can be achieved through simpler and more readily available techniques." +
            " Furthermore, TxF may not be available in future versions of Microsoft Windows." +
            " For more information, and alternatives to TxF, please see Alternatives to using Transactional NTFS.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateFileTransactedW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE CreateFileTransacted([In] LPCWSTR lpFileName, [In] FileAccessRights dwDesiredAccess, [In] FileShareModes dwShareMode,
            [In] in SECURITY_ATTRIBUTES lpSecurityAttributes, [In] FileCreationDispositions dwCreationDisposition, [In] uint dwFlagsAndAttributes,
            [In] HANDLE hTemplateFile, [In] HANDLE hTransaction, [Out] out TXFS_MINIVERSION pusMiniVersion, [In] PVOID lpExtendedParameter);

        /// <summary>
        /// <para>
        /// Deletes an existing file as a transacted operation.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-deletefiletransactedw"/>
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// The name of the file to be deleted.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File.
        /// The file must reside on the local computer;
        /// otherwise, the function fails and the last error code is set to <see cref="ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE"/>.
        /// </param>
        /// <param name="hTransaction">
        /// A handle to the transaction. This handle is returned by the <see cref="CreateTransaction"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If an application attempts to delete a file that does not exist,
        /// the <see cref="DeleteFileTransacted"/> function fails with <see cref="ERROR_FILE_NOT_FOUND"/>.
        /// If the file is a read-only file, the function fails with <see cref="ERROR_ACCESS_DENIED"/>.
        /// The following list identifies some tips for deleting, removing, or closing files:
        /// To delete a read-only file, first you must remove the read-only attribute.
        /// To delete or rename a file, you must have either delete permission on the file, or delete child permission in the parent directory.
        /// To recursively delete the files in a directory, use the <see cref="SHFileOperation"/> function.
        /// To remove an empty directory, use the <see cref="RemoveDirectory"/> function.
        /// To close an open file, use the <see cref="CloseHandle"/> function.
        /// If you set up a directory with all access except delete and delete child, and the access control lists (ACL) of new files are inherited,
        /// then you can create a file without being able to delete it.
        /// However, then you can create a file, and then get all the access you request on the handle that is returned to you at the time
        /// you create the file.
        /// If you request delete permission at the time you create a file, you can delete or rename the file with that handle,
        /// but not with any other handle.
        /// For more information, see File Security and Access Rights.
        /// The <see cref="DeleteFileTransacted"/> function fails if an application attempts to delete a file that has other handles open
        /// for normal I/O or as a memory-mapped file (<see cref="FILE_SHARE_DELETE"/> must have been specified
        /// when other handles were opened).
        /// The <see cref="DeleteFileTransacted"/> function marks a file for deletion on close.
        /// The file is deleted after the last transacted writer handle to the file is closed, provided that the transaction is still active.
        /// If a file has been marked for deletion and a transacted writer handle is still open after the transaction completes,
        /// the file will not be deleted.
        /// Symbolic link behavior—
        /// If the path points to a symbolic link, the symbolic link is deleted, not the target.
        /// To delete a target, you must call <see cref="CreateFile"/> and specify <see cref="FILE_FLAG_DELETE_ON_CLOSE"/>.
        /// </remarks>
        [Obsolete("Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs." +
            " Many scenarios that TxF was developed for can be achieved through simpler and more readily available techniques." +
            " Furthermore, TxF may not be available in future versions of Microsoft Windows." +
            " For more information, and alternatives to TxF, please see Alternatives to using Transactional NTFS.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteFileTransactedW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DeleteFileTransacted([In] LPCWSTR lpFileName, [In] HANDLE hTransaction);

        /// <summary>
        /// <para>
        /// Creates an enumeration of all the hard links to the specified file as a transacted operation.
        /// The function returns a handle to the enumeration that can be used on subsequent calls to the <see cref="FindNextFileNameW"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-findfirstfilenametransactedw"/>
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// The name of the file.
        /// The file must reside on the local computer; otherwise, the function fails and
        /// the last error code is set to <see cref="ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE"/>.
        /// </param>
        /// <param name="dwFlags">
        /// Reserved; specify zero (0).
        /// </param>
        /// <param name="StringLength">
        /// The size of the buffer pointed to by the <paramref name="LinkName"/> parameter, in characters.
        /// If this call fails and the error is <see cref="ERROR_MORE_DATA"/>, the value that is returned by this parameter is the size
        /// that the buffer pointed to by <paramref name="LinkName"/> must be to contain all the data.
        /// </param>
        /// <param name="LinkName">
        /// A pointer to a buffer to store the first link name found for <paramref name="lpFileName"/>.
        /// </param>
        /// <param name="hTransaction">
        /// A handle to the transaction.
        /// This handle is returned by the <see cref="CreateTransaction"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a search handle that can be used with
        /// the <see cref="FindNextFileNameW"/> function or closed with the <see cref="FindClose"/> function.
        /// If the function fails, the return value is <see cref="INVALID_HANDLE_VALUE"/>.
        /// To get extended error information, call the <see cref="GetLastError"/> function.
        /// </returns>
        [Obsolete("Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs." +
            " Many scenarios that TxF was developed for can be achieved through simpler and more readily available techniques." +
            " Furthermore, TxF may not be available in future versions of Microsoft Windows." +
            " For more information, and alternatives to TxF, please see Alternatives to using Transactional NTFS.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindFirstFileNameTransactedW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE FindFirstFileNameTransactedW([In] LPCWSTR lpFileName, [In] DWORD dwFlags, [In][Out] ref DWORD StringLength,
            [In] IntPtr LinkName, [In] HANDLE hTransaction);

        /// <summary>
        /// <para>
        /// Searches a directory for a file or subdirectory with a name that matches a specific name as a transacted operation.
        /// This function is the transacted form of the <see cref="FindFirstFileEx"/> function.
        /// For the most basic version of this function, see <see cref="FindFirstFile"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-findfirstfiletransactedw"/>
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// The directory or path, and the file name.
        /// The file name can include wildcard characters, for example, an asterisk (*) or a question mark (?).
        /// This parameter should not be <see langword="null"/>, an invalid string (for example, an empty string or a string
        /// that is missing the terminating null character), or end in a trailing backslash().
        /// If the string ends with a wildcard, period(.), or directory name, the user must have access to the root and all subdirectories on the path.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File.
        /// The file must reside on the local computer; otherwise, the function fails and the last error code
        /// is set to <see cref="ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE"/>.
        /// </param>
        /// <param name="fInfoLevelId">
        /// The information level of the returned data.
        /// This parameter is one of the <see cref="FINDEX_INFO_LEVELS"/> enumeration values.
        /// </param>
        /// <param name="lpFindFileData">
        /// A pointer to the <see cref="WIN32_FIND_DATA"/> structure that receives information about a found file or subdirectory.
        /// </param>
        /// <param name="fSearchOp">
        /// The type of filtering to perform that is different from wildcard matching.
        /// This parameter is one of the <see cref="FINDEX_SEARCH_OPS"/> enumeration values.
        /// </param>
        /// <param name="lpSearchFilter">
        /// A pointer to the search criteria if the specified <paramref name="fSearchOp"/> needs structured search information.
        /// At this time, none of the supported <paramref name="fSearchOp"/> values require extended search information.
        /// Therefore, this pointer must be <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <param name="dwAdditionalFlags">
        /// Specifies additional flags that control the search.
        /// <see cref="FIND_FIRST_EX_CASE_SENSITIVE"/>: Searches are case-sensitive.
        /// </param>
        /// <param name="hTransaction">
        /// A handle to the transaction.
        /// This handle is returned by the <see cref="CreateTransaction"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a search handle used in a subsequent call to <see cref="FindNextFile"/> or <see cref="FindClose"/>,
        /// and the <paramref name="lpFindFileData"/> parameter contains information about the first file or directory found.
        /// If the function fails or fails to locate files from the search string in the <paramref name="lpFileName"/> parameter,
        /// the return value is <see cref="INVALID_HANDLE_VALUE"/> and the contents of <paramref name="lpFindFileData"/> are indeterminate.
        /// To get extended error information, call the <see cref="GetLastError"/> function.
        /// </returns>
        /// <remarks>
        /// The <see cref="FindFirstFileTransacted"/> function opens a search handle and returns information about the first file
        /// that the file system finds with a name that matches the specified pattern.
        /// This may or may not be the first file or directory that appears in a directory-listing application (such as the dir command)
        /// when given the same file name string pattern.
        /// This is because <see cref="FindFirstFileTransacted"/> does no sorting of the search results.
        /// For additional information, see <see cref="FindNextFile"/>.
        /// The following list identifies some other search characteristics:
        /// The search is performed strictly on the name of the file, not on any attributes such as a date or a file type.
        /// The search includes the long and short file names.
        /// An attempt to open a search with a trailing backslash always fails.
        /// Passing an invalid string, <see langword="null"/>, or empty string for the <paramref name="lpFileName"/> parameter
        /// is not a valid use of this function.
        /// Results in this case are undefined.
        /// In rare cases, file information on NTFS file systems may not be current at the time you call this function.
        /// To be assured of getting the current file information, call the <see cref="GetFileInformationByHandle"/> function.
        /// If the underlying file system does not support the specified type of filtering, other than directory filtering,
        /// <see cref="FindFirstFileTransacted"/> fails with the error <see cref="ERROR_NOT_SUPPORTED"/>.
        /// The application must use <see cref="FINDEX_SEARCH_OPS"/> type <see cref="FindExSearchNameMatch"/> and perform its own filtering.
        /// After the search handle is established, use it in the <see cref="FindNextFile"/> function to search
        /// for other files that match the same pattern with the same filtering that is being performed.
        /// When the search handle is not needed, it should be closed by using the <see cref="FindClose"/> function.
        /// As stated previously, you cannot use a trailing backslash () in the lpFileName input string for <see cref="FindFirstFileTransacted"/>,
        /// therefore it may not be obvious how to search root directories.
        /// If you want to see files or get the attributes of a root directory, the following options would apply:
        /// To examine files in a root directory, you can use "C:\*" and step through the directory by using <see cref="FindNextFile"/>.
        /// To get the attributes of a root directory, use the <see cref="GetFileAttributes"/> function.
        /// Prepending the string "\\?\" does not allow access to the root directory.
        /// On network shares, you can use an <paramref name="lpFileName"/> in the form of the following: "\\server\service\*".
        /// However, you cannot use an <paramref name="lpFileName"/> that points to the share itself; for example, "\\server\service" is not valid.
        /// To examine a directory that is not a root directory, use the path to that directory, without a trailing backslash.
        /// For example, an argument of "C:\Windows" returns information about the directory "C:\Windows", not about a directory or file in "C:\Windows".
        /// To examine the files and directories in "C:\Windows", use an lpFileName of "C:\Windows*".
        /// Be aware that some other thread or process could create or delete a file with this name between the time you query
        /// for the result and the time you act on the information. 
        /// If this is a potential concern for your application, one possible solution is to use the <see cref="CreateFile"/> function
        /// with <see cref="CREATE_NEW"/> (which fails if the file exists) or <see cref="OPEN_EXISTING"/> (which fails if the file does not exist).
        /// If you are writing a 32-bit application to list all the files in a directory and the application may be run on a 64-bit computer,
        /// you should call <see cref="Wow64DisableWow64FsRedirection"/> before calling <see cref="FindFirstFileTransacted"/> and
        /// call <see cref="Wow64RevertWow64FsRedirection"/> after the last call to <see cref="FindNextFile"/>.
        /// For more information, see File System Redirector.
        /// If the path points to a symbolic link, the <see cref="WIN32_FIND_DATA"/> buffer contains information about the symbolic link, not the target.
        /// </remarks>
        [Obsolete("Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs." +
                    " Many scenarios that TxF was developed for can be achieved through simpler and more readily available techniques." +
                    " Furthermore, TxF may not be available in future versions of Microsoft Windows." +
                    " For more information, and alternatives to TxF, please see Alternatives to using Transactional NTFS.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindFirstFileTransactedW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE FindFirstFileTransacted([In] LPCWSTR lpFileName, [In] FINDEX_INFO_LEVELS fInfoLevelId, [In] LPVOID lpFindFileData,
            [In] FINDEX_SEARCH_OPS fSearchOp, [In] LPVOID lpSearchFilter, [In] FindFirstFileExFlags dwAdditionalFlags, [In] HANDLE hTransaction);

        /// <summary>
        /// <para>
        /// Enumerates the first stream in the specified file or directory as a transacted operation.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-findfirststreamtransactedw"/>
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// The fully qualified file name.
        /// The file must reside on the local computer; otherwise, the function fails and the last error code
        /// is set to <see cref="ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE"/>.
        /// </param>
        /// <param name="InfoLevel">
        /// The information level of the returned data.
        /// This parameter is one of the values in the <see cref="STREAM_INFO_LEVELS"/> enumeration type.
        /// <see cref="FindStreamInfoStandard"/>: The data is returned in a <see cref="WIN32_FIND_STREAM_DATA"/> structure.
        /// </param>
        /// <param name="lpFindStreamData">
        /// A pointer to a buffer that receives the file data.
        /// The format of this data depends on the value of the <paramref name="InfoLevel"/> parameter.
        /// </param>
        /// <param name="dwFlags">
        /// Reserved for future use. This parameter must be zero.
        /// </param>
        /// <param name="hTransaction">
        /// A handle to the transaction.
        /// This handle is returned by the <see cref="CreateTransaction"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a search handle that can be used in subsequent calls to the <see cref="FindNextStreamW"/> function.
        /// If the function fails, the return value is <see cref="INVALID_HANDLE_VALUE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// All files contain a default data stream.
        /// On NTFS, files can also contain one or more named data streams.
        /// On FAT file systems, files cannot have more that the default data stream, and therefore, this function will not return
        /// valid results when used on FAT filesystem files.
        /// This function works on all file systems that supports hard links; otherwise, the function returns <see cref="ERROR_STATUS_NOT_IMPLEMENTED"/>.
        /// The <see cref="FindFirstStreamTransactedW"/> function opens a search handle and returns information about
        /// the first stream in the specified file or directory.
        /// For files, this is always the default data stream, ::$DATA.
        /// After the search handle has been established, use it in the <see cref="FindNextStreamW"/> function to search for other streams
        /// in the specified file or directory.
        /// When the search handle is no longer needed, it should be closed using the <see cref="FindClose"/> function.
        /// </remarks>
        [Obsolete("Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs." +
            " Many scenarios that TxF was developed for can be achieved through simpler and more readily available techniques." +
            " Furthermore, TxF may not be available in future versions of Microsoft Windows." +
            " For more information, and alternatives to TxF, please see Alternatives to using Transactional NTFS.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindFirstStreamTransactedW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE FindFirstStreamTransactedW([In] LPCWSTR lpFileName,
            [In] STREAM_INFO_LEVELS InfoLevel, [In] LPVOID lpFindStreamData, [In] DWORD dwFlags, [In] LPVOID hTransaction);

        /// <summary>
        /// <para>
        /// Retrieves the actual number of bytes of disk storage used to store a specified file as a transacted operation.
        /// If the file is located on a volume that supports compression and the file is compressed,
        /// the value obtained is the compressed size of the specified file.
        /// If the file is located on a volume that supports sparse files and the file is a sparse file,
        /// the value obtained is the sparse size of the specified file.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-getcompressedfilesizetransactedw"/>
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// The name of the file.
        /// Do not specify the name of a file on a nonseeking device, such as a pipe or a communications device, as its file size has no meaning.
        /// The file must reside on the local computer; otherwise, the function fails and
        /// the last error code is set to <see cref="ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE"/>.
        /// </param>
        /// <param name="lpFileSizeHigh">
        /// A pointer to a variable that receives the high-order DWORD of the compressed file size.
        /// The function's return value is the low-order DWORD of the compressed file size.
        /// This parameter can be <see langword="null"/> if the high-order DWORD of the compressed file size is not needed.
        /// Files less than 4 gigabytes in size do not need the high-order DWORD.
        /// </param>
        /// <param name="hTransaction">
        /// A handle to the transaction.
        /// This handle is returned by the <see cref="CreateTransaction"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the low-order DWORD of the actual number of bytes of disk storage
        /// used to store the specified file, and if <paramref name="lpFileSizeHigh"/> is non-NULL,
        /// the function puts the high-order DWORD of that actual value into the DWORD pointed to by that parameter.
        /// This is the compressed file size for compressed files, the actual file size for noncompressed files.
        /// If the function fails, and <paramref name="lpFileSizeHigh"/> is <see langword="null"/>,
        /// the return value is <see cref="INVALID_FILE_SIZE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If the return value is <see cref="INVALID_FILE_SIZE"/> and <paramref name="lpFileSizeHigh"/> is non-NULL,
        /// an application must call <see cref="GetLastError"/> to determine whether the function has succeeded
        /// (value is <see cref="NO_ERROR"/>) or failed (value is other than <see cref="NO_ERROR"/>).
        /// </returns>
        /// <remarks>
        /// An application can determine whether a volume is compressed by calling <see cref="GetVolumeInformation"/>,
        /// then checking the status of the <see cref="FS_VOL_IS_COMPRESSED"/> flag in the DWORD value pointed to
        /// by that function's lpFileSystemFlags parameter.
        /// If the file is not located on a volume that supports compression or sparse files, or if the file is not compressed or a sparse file,
        /// the value obtained is the actual file size, the same as the value returned by a call to <see cref="GetFileSize"/>.
        /// Symbolic links:  If the path points to a symbolic link, the function returns the file size of the target.
        /// </remarks>
        [Obsolete("Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs." +
            " Many scenarios that TxF was developed for can be achieved through simpler and more readily available techniques." +
            " Furthermore, TxF may not be available in future versions of Microsoft Windows." +
            " For more information, and alternatives to TxF, please see Alternatives to using Transactional NTFS.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCompressedFileSizeTransactedW", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetCompressedFileSizeTransacted([In] LPCWSTR lpFileName, [Out] out DWORD lpFileSizeHigh, [In] HANDLE hTransaction);

        /// <summary>
        /// <para>
        /// Retrieves file system attributes for a specified file or directory as a transacted operation.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-getfileattributestransactedw"/>
        /// </para>
        /// </summary>
        /// <param name="lpFileName"></param>
        /// The name of the file or directory.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function (<see cref="GetFileAttributesEx"/>),
        /// and prepend "\\?\" to the path. For more information, see Naming a File.
        /// The file or directory must reside on the local computer; otherwise,
        /// the function fails and the last error code is set to <see cref="ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE"/>.
        /// <param name="fInfoLevelId">
        /// A class of attribute information to retrieve.
        /// This parameter can be the following value from the <see cref="GET_FILEEX_INFO_LEVELS"/> enumeration.
        /// <see cref="GetFileExInfoStandard"/>: The <paramref name="lpFileInformation"/> parameter is a <see cref="WIN32_FILE_ATTRIBUTE_DATA"/> structure.
        /// </param>
        /// <param name="lpFileInformation">
        /// A pointer to a buffer that receives the attribute information.
        /// The type of attribute information that is stored into this buffer is determined by the value of <paramref name="fInfoLevelId"/>.
        /// </param>
        /// <param name="hTransaction">
        /// A handle to the transaction. This handle is returned by the <see cref="CreateTransaction"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// When <see cref="GetFileAttributesTransacted"/> is called on a directory that is a mounted folder, it returns the attributes of the directory,
        /// not those of the root directory in the volume that the mounted folder associates with the directory.
        /// To obtain the file attributes of the associated volume,
        /// call <see cref="GetVolumeNameForVolumeMountPoint"/> to obtain the name of the associated volume.
        /// Then use the resulting name in a call to <see cref="GetFileAttributesTransacted"/>.
        /// The results are the attributes of the root directory on the associated volume.
        /// Symbolic links:  If the path points to a symbolic link, the function returns attributes for the symbolic link.
        /// Transacted Operations
        /// If a file is open for modification in a transaction, no other thread can open the file for modification until the transaction is committed.
        /// Conversely, if a file is open for modification outside of a transaction,
        /// no transacted thread can open the file for modification until the non-transacted handle is closed.
        /// If a non-transacted thread has a handle opened to modify a file,
        /// a call to <see cref="GetFileAttributesTransacted"/> for that file will fail with an <see cref="ERROR_TRANSACTIONAL_CONFLICT"/> error.
        /// </remarks>
        [Obsolete("Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs." +
            " Many scenarios that TxF was developed for can be achieved through simpler and more readily available techniques." +
            " Furthermore, TxF may not be available in future versions of Microsoft Windows." +
            " For more information, and alternatives to TxF, please see Alternatives to using Transactional NTFS.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFileAttributesTransactedW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetFileAttributesTransacted([In] LPCWSTR lpFileName, [In] GET_FILEEX_INFO_LEVELS fInfoLevelId,
            [In] LPVOID lpFileInformation, [In] HANDLE hTransaction);



        /// <summary>
        /// <para>
        /// Retrieves the full path and file name of the specified file as a transacted operation.
        /// To perform this operation without transactions, use the <see cref="GetFullPathName"/> function.
        /// For more information about file and path names, see File Names, Paths, and Namespaces.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-getfullpathnametransactedw"/>
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// The name of the file.
        /// This string can use short (the 8.3 form) or long file names. This string can be a share or volume name.
        /// The file must reside on the local computer;
        /// otherwise, the function fails and the last error code is set to <see cref="ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE"/>.
        /// </param>
        /// <param name="nBufferLength">
        /// The size of the buffer to receive the null-terminated string for the drive and path, in TCHARs.
        /// </param>
        /// <param name="lpBuffer">
        /// A pointer to a buffer that receives the null-terminated string for the drive and path.
        /// </param>
        /// <param name="lpFilePart">
        /// A pointer to a buffer that receives the address (in <paramref name="lpBuffer"/>) of the final file name component in the path.
        /// Specify <see cref="NullRef{IntPtr}"/> if you do not need to receive this information.
        /// If <paramref name="lpBuffer"/> points to a directory and not a file, <paramref name="lpFilePart"/> receives 0 (zero).
        /// </param>
        /// <param name="hTransaction">
        /// A handle to the transaction.
        /// This handle is returned by the <see cref="CreateTransaction"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the length, in TCHARs,
        /// of the string copied to <paramref name="lpBuffer"/>, not including the terminating null character.
        /// If the <paramref name="lpBuffer"/> buffer is too small to contain the path, the return value is the size, in TCHARs,
        /// of the buffer that is required to hold the path and the terminating null character.
        /// If the function fails for any other reason, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="GetFullPathNameTransacted"/> merges the name of the current drive and directory
        /// with a specified file name to determine the full path and file name of a specified file.
        /// It also calculates the address of the file name portion of the full path and file name.
        /// This function does not verify that the resulting path and file name are valid, or that they see an existing file on the associated volume.
        /// Share and volume names are valid input for <paramref name="lpFileName"/>.
        /// For example, the following list identities the returned path and file names if test-2 is a remote computer and U: is a network mapped drive:
        /// If you specify "\\test-2\q$\lh" the path returned is "\\test-2\q$\lh"
        /// If you specify "\\?\UNC\test-2\q$\lh" the path returned is "\\?\UNC\test-2\q$\lh"
        /// If you specify "U:" the path returned is "U:\"
        /// <see cref="GetFullPathNameTransacted"/> does not convert the specified file name, <paramref name="lpFileName"/>.
        /// If the specified file name exists, you can use <see cref="GetLongPathNameTransacted"/>,
        /// <see cref="GetLongPathName"/>, or <see cref="GetShortPathName"/> to convert to long or short path names, respectively.
        /// If the return value is greater than the value specified in <paramref name="nBufferLength"/>,
        /// you can call the function again with a buffer that is large enough to hold the path.
        /// For an example of this case as well as using zero length buffer for dynamic allocation, see the Example Code section.
        /// Note
        /// Although the return value in this case is a length that includes the terminating null character,
        /// the return value on success does not include the terminating null character in the count.
        /// </remarks>
        [Obsolete("Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs." +
            "Many scenarios that TxF was developed for can be achieved through simpler and more readily available techniques." +
            "Furthermore, TxF may not be available in future versions of Microsoft Windows." +
            "For more information, and alternatives to TxF, please see Alternatives to using Transactional NTFS.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFullPathNameTransactedW", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetFullPathNameTransacted([In] LPCWSTR lpFileName, [In] DWORD nBufferLength, [In] IntPtr lpBuffer,
            [Out] out IntPtr lpFilePart, [In] HANDLE hTransaction);

        /// <summary>
        /// <para>
        /// Converts the specified path to its long form as a transacted operation.
        /// To perform this operation without a transaction, use the <see cref="GetLongPathName"/> function.
        /// For more information about file and path names, see Naming Files, Paths, and Namespaces.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-getlongpathnametransactedw"/>
        /// </para>
        /// </summary>
        /// <param name="lpszShortPath">
        /// The path to be converted.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> (260) characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming Files, Paths, and Namespaces.
        /// The path must reside on the local computer;
        /// otherwise, the function fails and the last error code is set to <see cref="ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE"/>.
        /// </param>
        /// <param name="lpszLongPath">
        /// A pointer to the buffer to receive the long path.
        /// You can use the same buffer you used for the <paramref name="lpszShortPath"/> parameter.
        /// </param>
        /// <param name="cchBuffer">
        /// The size of the buffer <paramref name="lpszLongPath"/> points to, in TCHARs.
        /// </param>
        /// <param name="hTransaction">
        /// A handle to the transaction.
        /// This handle is returned by the <see cref="CreateTransaction"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the length, in TCHARs,
        /// of the string copied to <paramref name="lpszLongPath"/>, not including the terminating null character.
        /// If the <paramref name="lpszLongPath"/> buffer is too small to contain the path, the return value is the size, in TCHARs,
        /// of the buffer that is required to hold the path and the terminating null character.
        /// If the function fails for any other reason, such as if the file does not exist, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// On many file systems, a short file name contains a tilde (~) character.
        /// However, not all file systems follow this convention.
        /// Therefore, do not assume that you can skip calling <see cref="GetLongPathNameTransacted"/>
        /// if the path does not contain a tilde (~) character.
        /// If a long path is not found, this function returns the name specified
        /// in the <paramref name="lpszShortPath"/> parameter in the <paramref name="lpszLongPath"/> parameter.
        /// If the return value is greater than the value specified in <paramref name="cchBuffer"/>,
        /// you can call the function again with a buffer that is large enough to hold the path.
        /// For an example of this case, see the Example Code section for <see cref="GetFullPathName"/>.
        /// Note
        /// Although the return value in this case is a length that includes the terminating null character,
        /// the return value on success does not include the terminating null character in the count.
        /// It is possible to have access to a file or directory but not have access to some of the parent directories of that file or directory.
        /// As a result, <see cref="GetLongPathNameTransacted"/> may fail
        /// when it is unable to query the parent directory of a path component to determine the long name for that component.
        /// This check can be skipped for directory components that have file extensions longer than 3 characters,
        /// or total lengths longer than 12 characters.
        /// For more information, see the Short vs. Long Names section of Naming Files, Paths, and Namespaces. 
        /// </remarks>
        [Obsolete("Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs." +
            "Many scenarios that TxF was developed for can be achieved through simpler and more readily available techniques." +
            "Furthermore, TxF may not be available in future versions of Microsoft Windows." +
            "For more information, and alternatives to TxF, please see Alternatives to using Transactional NTFS.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetLongPathNameTransacted", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetLongPathNameTransacted([In] LPCWSTR lpszShortPath, [In] IntPtr lpszLongPath, [In] DWORD cchBuffer, [In] HANDLE hTransaction);

        /// <summary>
        /// <para>
        /// Moves an existing file or a directory, including its children, as a transacted operation.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-movefiletransactedw"/>
        /// </para>
        /// </summary>
        /// <param name="lpExistingFileName">
        /// The current name of the file or directory on the local computer.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File
        /// </param>
        /// <param name="lpNewFileName">
        /// The new name for the file or directory.
        /// The new name must not already exist.
        /// A new file may be on a different file system or drive.
        /// A new directory must be on the same drive.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File
        /// </param>
        /// <param name="lpProgressRoutine">
        /// A pointer to a CopyProgressRoutine callback function that is called each time another portion of the file has been moved.
        /// The callback function can be useful if you provide a user interface that displays the progress of the operation.
        /// This parameter can be <see cref="NULL"/>.
        /// </param>
        /// <param name="lpData">
        /// An argument to be passed to the CopyProgressRoutine callback function.
        /// This parameter can be <see cref="NULL"/>.
        /// </param>
        /// <param name="dwFlags">
        /// The move options. This parameter can be one or more of the following values.
        /// <see cref="MOVEFILE_COPY_ALLOWED"/>:
        /// If the file is to be moved to a different volume, the function simulates the move by using the <see cref="CopyFile"/> and <see cref="DeleteFile"/> functions.
        /// If the file is successfully copied to a different volume and the original file is unable to be deleted, the function succeeds leaving the source file intact.
        /// This value cannot be used with <see cref="MOVEFILE_DELAY_UNTIL_REBOOT"/>.
        /// <see cref="MOVEFILE_CREATE_HARDLINK"/>:
        /// Reserved for future use.
        /// <see cref="MOVEFILE_DELAY_UNTIL_REBOOT"/>:
        /// The system does not move the file until the operating system is restarted.
        /// The system moves the file immediately after AUTOCHK is executed, but before creating any paging files.
        /// Consequently, this parameter enables the function to delete paging files from previous startups.
        /// This value can be used only if the process is in the context of a user who belongs to the administrators group or the LocalSystem account.
        /// This value cannot be used with <see cref="MOVEFILE_COPY_ALLOWED"/>.
        /// The write operation to the registry value as detailed in the Remarks section is what is transacted.
        /// The file move is finished when the computer restarts, after the transaction is complete.
        /// <see cref="MOVEFILE_REPLACE_EXISTING"/>:
        /// If a file named <paramref name="lpNewFileName"/> exists, the function replaces its contents with the contents of the <paramref name="lpExistingFileName"/> file.
        /// This value cannot be used if <paramref name="lpNewFileName"/> or <paramref name="lpExistingFileName"/> names a directory.
        /// <see cref="MOVEFILE_WRITE_THROUGH"/>:
        /// A call to MoveFileTransacted means that the move file operation is complete when the commit operation is completed.
        /// This flag is unnecessary; there are no negative affects if this flag is specified, other than an operation slowdown.
        /// The function does not return until the file has actually been moved on the disk.
        /// Setting this value guarantees that a move performed as a copy and delete operation is flushed to disk before the function returns.
        /// The flush occurs at the end of the copy operation.
        /// This value has no effect if <see cref="MOVEFILE_DELAY_UNTIL_REBOOT"/> is set.
        /// </param>
        /// <param name="hTransaction">
        /// A handle to the transaction.
        /// This handle is returned by the <see cref="CreateTransaction"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// When moving a file across volumes, if lpProgressRoutine returns <see cref="PROGRESS_CANCEL"/> due to the user canceling the operation,
        /// <see cref="MoveFileTransacted"/> will return zero and <see cref="GetLastError"/> will return <see cref="ERROR_REQUEST_ABORTED"/>. The existing file is left intact.
        /// When moving a file across volumes, if lpProgressRoutine returns <see cref="PROGRESS_STOP"/> due to the user stopping the operation,
        /// <see cref="MoveFileTransacted"/> will return zero and <see cref="GetLastError"/> will return <see cref="ERROR_REQUEST_ABORTED"/>. The existing file is left intact.
        /// </returns>
        /// <remarks>
        /// If the <paramref name="dwFlags"/> parameter specifies <see cref="MOVEFILE_DELAY_UNTIL_REBOOT"/>, <see cref="MoveFileTransacted"/> fails if it cannot access the registry.
        /// The function transactionally stores the locations of the files to be renamed at restart in the following registry value:
        /// HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\PendingFileRenameOperations
        /// This registry value is of type REG_MULTI_SZ. Each rename operation stores one of the following NULL-terminated strings,
        /// depending on whether the rename is a delete or not:
        /// szDstFile\0\0
        /// szSrcFile\0szDstFile\0
        /// The string szDstFile\0\0 indicates that the file szDstFile is to be deleted on reboot.
        /// The string szSrcFile\0szDstFile\0 indicates that szSrcFile is to be renamed szDstFile on reboot.
        /// Note  Although \0\0 is technically not allowed in a REG_MULTI_SZ node, it can because the file is considered to be renamed to a null name.
        /// The system uses these registry entries to complete the operations at restart in the same order that they were issued.
        /// For more information about using the <see cref="MOVEFILE_DELAY_UNTIL_REBOOT"/> flag, see <see cref="MoveFileWithProgress"/>.
        /// If a file is moved across volumes, <see cref="MoveFileTransacted"/> does not move the security descriptor with the file.
        /// The file is assigned the default security descriptor in the destination directory.
        /// This function always fails if you specify the <see cref="MOVEFILE_FAIL_IF_NOT_TRACKABLE"/> flag; tracking is not supported by TxF.
        /// </remarks>
        [Obsolete("Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. " +
            "Many scenarios that TxF was developed for can be achieved through simpler and more readily available techniques. " +
            "Furthermore, TxF may not be available in future versions of Microsoft Windows. " +
            "For more information, and alternatives to TxF, please see Alternatives to using Transactional NTFS.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "MoveFileTransactedW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL MoveFileTransacted([In] LPCWSTR lpExistingFileName, [In] LPCWSTR lpNewFileName,
            [In] LPPROGRESS_ROUTINE lpProgressRoutine, [In] LPVOID lpData, [In] MoveFileFlags dwFlags, [In] HANDLE hTransaction);

        /// <summary>
        /// <para>
        /// Deletes an existing empty directory as a transacted operation.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-removedirectorytransactedw"/>
        /// </para>
        /// </summary>
        /// <param name="lpPathName">
        /// The path of the directory to be removed.
        /// The path must specify an empty directory, and the calling process must have delete access to the directory.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File.
        /// The directory must reside on the local computer;
        /// otherwise, the function fails and the last error code is set to <see cref="ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE"/>.
        /// </param>
        /// <param name="hTransaction">
        /// A handle to the transaction.
        /// This handle is returned by the <see cref="CreateTransaction"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="RemoveDirectoryTransacted"/> function marks a directory for deletion on close.
        /// Therefore, the directory is not removed until the last handle to the directory is closed.
        /// <see cref="RemoveDirectory"/> removes a directory junction, even if the contents of the target are not empty;
        /// the function removes directory junctions regardless of the state of the target object.
        /// </remarks>
        [Obsolete("Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. " +
            "Many scenarios that TxF was developed for can be achieved through simpler and more readily available techniques. " +
            "Furthermore, TxF may not be available in future versions of Microsoft Windows. " +
            "For more information, and alternatives to TxF, please see Alternatives to using Transactional NTFS.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "RemoveDirectoryTransactedW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL RemoveDirectoryTransacted([In] LPCWSTR lpPathName, [In] HANDLE hTransaction);

        /// <summary>
        /// <para>
        /// Sets the attributes for a file or directory as a transacted operation.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-setfileattributestransactedw"/>
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// The name of the file whose attributes are to be set.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see File Names, Paths, and Namespaces.
        /// The file must reside on the local computer; otherwise,
        /// the function fails and the last error code is set to <see cref="ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE"/>.
        /// </param>
        /// <param name="dwFileAttributes">
        /// The file attributes to set for the file.
        /// For a list of file attribute value and their descriptions, see File Attribute Constants.
        /// This parameter can be one or more values, combined using the bitwise-OR operator.
        /// However, all other values override <see cref="FILE_ATTRIBUTE_NORMAL"/>.
        /// Not all attributes are supported by this function.
        /// For more information, see the Remarks section.
        /// The following is a list of supported attribute values.
        /// <see cref="FILE_ATTRIBUTE_ARCHIVE"/>, <see cref="FILE_ATTRIBUTE_HIDDEN"/>, <see cref="FILE_ATTRIBUTE_NORMAL"/>,
        /// <see cref="FILE_ATTRIBUTE_NOT_CONTENT_INDEXED"/>, <see cref="FILE_ATTRIBUTE_OFFLINE"/>, <see cref="FILE_ATTRIBUTE_READONLY"/>,
        /// <see cref="FILE_ATTRIBUTE_SYSTEM"/>, <see cref="FILE_ATTRIBUTE_TEMPORARY"/>
        /// </param>
        /// <param name="hTransaction">
        /// A handle to the transaction.
        /// This handle is returned by the <see cref="CreateTransaction"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The following table describes how to set the attributes that cannot be set using <see cref="SetFileAttributesTransacted"/>.
        /// Note that these are not transacted operations.
        /// <see cref="FILE_ATTRIBUTE_COMPRESSED"/>:
        /// To set a file's compression state, use the <see cref="DeviceIoControl"/> function with the <see cref="FSCTL_SET_COMPRESSION"/> operation.
        /// <see cref="FILE_ATTRIBUTE_DEVICE"/>:
        /// Reserved; do not use.
        /// <see cref="FILE_ATTRIBUTE_DIRECTORY"/>:
        /// Files cannot be converted into directories. To create a directory, use the <see cref="CreateDirectory"/> or <see cref="CreateDirectoryEx"/> function.
        /// <see cref="FILE_ATTRIBUTE_ENCRYPTED"/>:
        /// To create an encrypted file, use the <see cref="CreateFile"/> function with the <see cref="FILE_ATTRIBUTE_ENCRYPTED"/> attribute.
        /// To convert an existing file into an encrypted file, use the <see cref="EncryptFile"/> function.
        /// <see cref="FILE_ATTRIBUTE_REPARSE_POINT"/>:
        /// To associate a reparse point with a file or directory,
        /// use the <see cref="DeviceIoControl"/> function with the <see cref="FSCTL_SET_REPARSE_POINT"/> operation.
        /// <see cref="FILE_ATTRIBUTE_SPARSE_FILE"/>:
        /// To set a file's sparse attribute, use the <see cref="DeviceIoControl"/> function with the <see cref="FSCTL_SET_SPARSE"/> operation.
        /// If a file is open for modification in a transaction, no other thread can successfully open the file for modification until the transaction is committed.
        /// If a transacted thread opens the file first, any subsequent threads that attempt to open the file for modification
        /// before the transaction is committed will receive a sharing violation.
        /// If a non-transacted thread opens the file for modification before the transacted thread does,
        /// and it is still open when the transacted thread attempts to open it,
        /// the transaction will receive the <see cref="ERROR_TRANSACTIONAL_CONFLICT"/> error.
        /// </remarks>
        [Obsolete("Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. " +
            "Many scenarios that TxF was developed for can be achieved through simpler and more readily available techniques. " +
            "Furthermore, TxF may not be available in future versions of Microsoft Windows. " +
            "For more information, and alternatives to TxF, please see Alternatives to using Transactional NTFS.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetFileAttributesTransactedW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetFileAttributesTransacted([In] LPCWSTR lpFileName, [In] FileAttributes dwFileAttributes, [In] HANDLE hTransaction);
    }
}
