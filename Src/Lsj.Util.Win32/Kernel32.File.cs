using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using System.Text;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.FileAccessRights;
using static Lsj.Util.Win32.Enums.FileAttributes;
using static Lsj.Util.Win32.Enums.FileCreationDispositions;
using static Lsj.Util.Win32.Enums.FileFlags;
using static Lsj.Util.Win32.Enums.FileShareModes;
using static Lsj.Util.Win32.Enums.FileSystemFlags;
using static Lsj.Util.Win32.Enums.FINDEX_SEARCH_OPS;
using static Lsj.Util.Win32.Enums.FindFirstFileExFlags;
using static Lsj.Util.Win32.Enums.GenericAccessRights;
using static Lsj.Util.Win32.Enums.GET_FILEEX_INFO_LEVELS;
using static Lsj.Util.Win32.Enums.IoControlCodes;
using static Lsj.Util.Win32.Enums.STREAM_INFO_LEVELS;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Ktmw32;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// Creates a new directory.
        /// If the underlying file system supports security on files and directories,
        /// the function applies a specified security descriptor to the new directory.
        /// To specify a template directory, use the <see cref="CreateDirectoryEx"/> function.
        /// To perform this operation as a transacted operation, use the <see cref="CreateDirectoryTransacted"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-createdirectory
        /// </para>
        /// </summary>
        /// <param name="lpPathName">
        /// The path of the directory to be created.
        /// For the ANSI version of this function, there is a default string size limit for paths of 248 characters
        /// (<see cref="MAX_PATH"/> - enough room for a 8.3 filename).
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File
        ///  Starting with Windows 10, version 1607, for the unicode version of this function (<see cref="CreateDirectory"/>),
        ///  you can opt-in to remove the 248 character limitation without prepending "\\?\". The 255 character limit per path segment still applies.
        ///  See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// </param>
        /// <param name="lpSecurityAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure.
        /// The <paramref name="lpSecurityAttributes"/> member of the structure specifies a security descriptor for the new directory.
        /// If <paramref name="lpSecurityAttributes"/> is null, the directory gets a default security descriptor.
        /// The access control lists (ACL) in the default security descriptor for a directory are inherited from its parent directory.
        /// The target file system must support security on files and directories for this parameter to have an effect.
        /// This is indicated when <see cref="GetVolumeInformation"/> returns <see cref="FS_PERSISTENT_ACLS"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// Possible errors include the following.
        /// <see cref="ERROR_ALREADY_EXISTS"/>: The specified directory already exists.
        /// <see cref="ERROR_PATH_NOT_FOUND"/>: One or more intermediate directories do not exist.
        /// </returns>
        /// <remarks>
        /// Some file systems, such as the NTFS file system, support compression or encryption for individual files and directories.
        /// On volumes formatted for such a file system, a new directory inherits the compression and encryption attributes of its parent directory.
        /// An application can obtain a handle to a directory by calling <see cref="CreateFile"/> with
        /// the <see cref="FILE_FLAG_BACKUP_SEMANTICS"/> flag set.
        /// For a code example, see <see cref="CreateFile"/>.
        /// To support inheritance functions that query the security descriptor of this object may heuristically determine
        /// and report that inheritance is in effect. See Automatic Propagation of Inheritable ACEs for more information.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDirectoryW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CreateDirectory([MarshalAs(UnmanagedType.LPWStr)][In]string lpPathName,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))]
            [In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpSecurityAttributes);

        /// <summary>
        /// <para>
        /// Creates a new directory with the attributes of a specified template directory.
        /// If the underlying file system supports security on files and directories,
        /// the function applies a specified security descriptor to the new directory.
        /// The new directory retains the other attributes of the specified template directory.
        /// To perform this operation as a transacted operation, use the <see cref="CreateDirectoryTransacted"/> function.
        /// </para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-createdirectoryexw
        /// </summary>
        /// <param name="lpTemplateDirectory">
        /// The path of the directory to use as a template when creating the new directory.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File.
        /// Starting with Windows 10, version 1607, for the unicode version of this function (<see cref="CreateDirectoryEx"/>),
        /// you can opt-in to remove the <see cref="MAX_PATH"/> character limitation without prepending "\\?\".
        /// The 255 character limit per path segment still applies.
        /// See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// </param>
        /// <param name="lpNewDirectory">
        /// The path of the directory to be created.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File.
        /// Starting with Windows 10, version 1607, for the unicode version of this function (<see cref="CreateDirectoryEx"/>),
        /// you can opt-in to remove the <see cref="MAX_PATH"/> character limitation without prepending "\\?\".
        /// The 255 character limit per path segment still applies.
        /// See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// </param>
        /// <param name="lpSecurityAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure.
        /// The <paramref name="lpSecurityAttributes"/> member of the structure specifies a security descriptor for the new directory.
        /// If <paramref name="lpSecurityAttributes"/> is null, the directory gets a default security descriptor.
        /// The access control lists (ACL) in the default security descriptor for a directory are inherited from its parent directory.
        /// The target file system must support security on files and directories for this parameter to have an effect.
        /// This is indicated when <see cref="GetVolumeInformation"/> returns <see cref="FS_PERSISTENT_ACLS"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// Possible errors include the following.
        /// <see cref="ERROR_ALREADY_EXISTS"/>: The specified directory already exists.
        /// <see cref="ERROR_PATH_NOT_FOUND"/>: One or more intermediate directories do not exist.
        /// This function only creates the final directory in the path.
        /// To create all intermediate directories on the path, use the <see cref="SHCreateDirectoryEx"/> function.
        /// </returns>
        /// <remarks>
        /// The <see cref="CreateDirectoryEx"/> function allows you to create directories that inherit stream information from other directories.
        /// This function is useful, for example, when you are using Macintosh directories,
        /// which have a resource stream that is needed to properly identify directory contents as an attribute.
        /// Some file systems, such as the NTFS file system, support compression or encryption for individual files and directories.
        /// On volumes formatted for such a file system, a new directory inherits the compression and encryption attributes of its parent directory.
        /// You can obtain a handle to a directory by calling the <see cref="CreateFile"/> function with
        /// the <see cref="FILE_FLAG_BACKUP_SEMANTICS"/> flag set.
        /// For a code example, see <see cref="CreateFile"/>.
        /// To support inheritance functions that query the security descriptor of this object can heuristically determine and report
        /// that inheritance is in effect. For more information, see Automatic Propagation of Inheritable ACEs.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDirectoryExW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CreateDirectoryEx([MarshalAs(UnmanagedType.LPWStr)][In]string lpTemplateDirectory,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpNewDirectory,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))]
            [In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpSecurityAttributes);

        /// <summary>
        /// <para>
        /// Creates a new directory as a transacted operation, with the attributes of a specified template directory.
        /// If the underlying file system supports security on files and directories,
        /// the function applies a specified security descriptor to the new directory.
        /// The new directory retains the other attributes of the specified template directory.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-createdirectorytransactedw
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDirectoryTransactedW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CreateDirectoryTransacted([MarshalAs(UnmanagedType.LPWStr)][In]string lpTemplateDirectory,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpNewDirectory,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))]
            [In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpSecurityAttributes, IntPtr hTransaction);

        /// <summary>
        /// <para>
        /// Creates or opens a file or I/O device.
        /// The most commonly used I/O devices are as follows: file, file stream, directory, physical disk, volume, console buffer,
        /// tape drive, communications resource, mailslot, and pipe.
        /// The function returns a handle that can be used to access the file or device for various types of I/O depending on
        /// the file or device and the flags and attributes specified.
        /// To perform this operation as a transacted operation, which results in a handle that can be used for transacted I/O,
        /// use the <see cref="CreateFileTransacted"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-createfilew
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// The name of the file or device to be created or opened. You may use either forward slashes (/) or backslashes () in this name.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming Files, Paths, and Namespaces.
        /// For information on special device names, see Defining an MS-DOS Device Name.
        /// To create a file stream, specify the name of the file, a colon, and then the name of the stream. 
        /// For more information, see File Streams.
        /// Starting with Windows 10, version 1607, for the unicode version of this function (<see cref="CreateFile"/>),
        /// you can opt-in to remove the <see cref="MAX_PATH"/> limitation without prepending "\\?\".
        /// See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// The requested access to the file or device, which can be summarized as read, write, both or neither zero).
        /// The most commonly used values are <see cref="GENERIC_READ"/>, <see cref="GENERIC_WRITE"/>,
        /// or both (<see cref="GENERIC_READ"/> | <see cref="GENERIC_WRITE"/>).
        /// For more information, see Generic Access Rights, File Security and Access Rights, File Access Rights Constants, and ACCESS_MASK.
        /// If this parameter is zero, the application can query certain metadata such as file, directory, or device attributes
        /// without accessing that file or device, even if <see cref="GENERIC_READ"/> access would have been denied.
        /// You cannot request an access mode that conflicts with the sharing mode that is specified by
        /// the <paramref name="dwShareMode"/> parameter in an open request that already has an open handle.
        /// For more information, see the Remarks section of this topic and Creating and Opening Files.
        /// </param>
        /// <param name="dwShareMode">
        /// The requested sharing mode of the file or device, which can be read, write, both, delete, all of these, or none (refer to the following table).
        /// Access requests to attributes or extended attributes are not affected by this flag.
        /// If this parameter is zero and <see cref="CreateFile"/> succeeds,
        /// the file or device cannot be shared and cannot be opened again until the handle to the file or device is closed.
        /// For more information, see the Remarks section.
        /// You cannot request a sharing mode that conflicts with the access mode that is specified in an existing request that has an open handle.
        /// <see cref="CreateFile"/> would fail and
        /// the <see cref="GetLastError"/> function would return <see cref="ERROR_SHARING_VIOLATION"/>.
        /// To enable a process to share a file or device while another process has the file or device open,
        /// use a compatible combination of one or more of the following values.
        /// For more information about valid combinations of this parameter with the <paramref name="dwDesiredAccess"/> parameter,
        /// see Creating and Opening Files.
        /// The sharing options for each open handle remain in effect until that handle is closed, regardless of process context.
        /// </param>
        /// <param name="lpSecurityAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that contains two separate but related data members:
        /// an optional security descriptor, and a Boolean value that determines whether the returned handle can be inherited by child processes.
        /// The parameter can be <see langword="null"/>.
        /// If this parameter is <see langword="null"/>, the handle returned by <see cref="CreateFile"/> cannot be inherited
        /// by any child processes the application may create and the file or device associated with the returned handle
        /// gets a default security descriptor.
        /// The <paramref name="lpSecurityAttributes"/> member of the structure specifies a <see cref="SECURITY_DESCRIPTOR"/> for a file or device.
        /// If this member is <see langword="null"/>, the file or device associated with the returned handle is assigned a default security descriptor.
        /// <see cref="CreateFile"/> ignores the <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member when opening an existing file,
        /// but continues to use the <see cref="SECURITY_ATTRIBUTES.bInheritHandle"/> member.
        /// The <see cref="SECURITY_ATTRIBUTES.bInheritHandle"/> member of the structure specifies whether the returned handle can be inherited.
        /// For more information, see the Remarks section of this topic.
        /// </param>
        /// <param name="dwCreationDisposition">
        /// An action to take on files that exist and do not exist.
        /// For devices other than files, this parameter is usually set to <see cref="OPEN_EXISTING"/>.
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
        /// When <see cref="CreateFile"/> opens an existing file, it generally combines the file flags with the file attributes of the existing file,
        /// and ignores any file attributes supplied as part of <paramref name="dwFlagsAndAttributes"/>.
        /// Special cases are detailed in Creating and Opening Files.
        /// Some of the following file attributes and flags may only apply to files and not necessarily all other types of devices 
        /// that <see cref="CreateFile"/> can open.
        /// For additional information, see the Remarks section of this topic and Creating and Opening Files.
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
        /// When opening an existing file, <see cref="CreateFile"/> ignores the template file.
        /// When opening a new EFS-encrypted file, the file inherits the discretionary access control list from its parent directory.
        /// For additional information, see File Encryption.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is an open handle to the specified file, device, named pipe, or mail slot.
        /// If the function fails, the return value is <see cref="INVALID_HANDLE_VALUE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="CreateFile"/> was originally developed specifically for file interaction
        /// but has since been expanded and enhanced to include most other types of I/O devices and mechanisms available to Windows developers.
        /// This section attempts to cover the varied issues developers may experience
        /// when using <see cref="CreateFile"/> in different contexts and with different I/O types.
        /// The text attempts to use the word file only when referring specifically to data stored in an actual file on a file system.
        /// However, some uses of file may be referring more generally to an I/O object that supports file-like mechanisms.
        /// This liberal use of the term file is particularly prevalent in constant names and parameter names because of
        /// the previously mentioned historical reasons.
        /// When an application is finished using the object handle returned by <see cref="CreateFile"/>,
        /// use the <see cref="CloseHandle"/> function to close the handle.
        /// This not only frees up system resources, but can have wider influence on things like sharing the file or device and committing data to disk.
        /// Specifics are noted within this topic as appropriate.
        /// Windows Server 2003 and Windows XP:
        /// A sharing violation occurs if an attempt is made to open a file or directory for deletion on a remote computer
        /// when the value of the <paramref name="dwDesiredAccess"/> parameter is the <see cref="StandardAccessRights.DELETE"/> access flag (0x00010000)
        /// OR'ed with any other access flag, and the remote file or directory has not been opened with <see cref="FILE_SHARE_DELETE"/>.
        /// To avoid the sharing violation in this scenario, open the remote file or directory
        /// with the <see cref="StandardAccessRights.DELETE"/> access right only,
        /// or call <see cref="DeleteFile"/> without first opening the file or directory for deletion.
        /// Some file systems, such as the NTFS file system, support compression or encryption for individual files and directories.
        /// On volumes that have a mounted file system with this support, a new file inherits the compression and encryption attributes of its directory.
        /// You cannot use <see cref="CreateFile"/> to control compression, decompression, or decryption on a file or directory.
        /// For more information, see Creating and Opening Files, File Compression and Decompression, and File Encryption.
        /// Windows Server 2003 and Windows XP:
        /// For backward compatibility purposes, <see cref="CreateFile"/> does not apply inheritance rules when you specify 
        /// a security descriptor in <paramref name="lpSecurityAttributes"/>.
        /// To support inheritance, functions that later query the security descriptor of this file may heuristically determine 
        /// and report that inheritance is in effect.
        /// For more information, see Automatic Propagation of Inheritable ACEs.
        /// As stated previously, if the <paramref name="lpSecurityAttributes"/> parameter is <see langword="null"/>,
        /// the handle returned by <see cref="CreateFile"/> cannot be inherited by any child processes your application may create.
        /// The following information regarding this parameter also applies:
        /// If the <see cref="SECURITY_ATTRIBUTES.bInheritHandle"/> member variable is not <see langword="false"/>, which is any nonzero value,
        /// then the handle can be inherited.
        /// Therefore it is critical this structure member be properly initialized to <see langword="false"/> if you do not intend
        /// the handle to be inheritable.
        /// The access control lists(ACL) in the default security descriptor for a file or directory are inherited from its parent directory.
        /// The target file system must support security on files and directories for the lpSecurityDescriptor member to have an effect on them,
        /// which can be determined by using <see cref="GetVolumeInformation"/>.
        /// Note that <see cref="CreateFile"/> with supersede disposition will fail
        /// if performed on a file where there is already an open alternate data stream.
        /// Symbolic Link Behavior
        /// If the call to this function creates a file, there is no change in behavior.
        /// Also, consider the following information regarding <see cref="FILE_FLAG_OPEN_REPARSE_POINT"/>:
        /// If <see cref="FILE_FLAG_OPEN_REPARSE_POINT"/> is specified:
        /// If an existing file is opened and it is a symbolic link, the handle returned is a handle to the symbolic link.
        /// If <see cref="TRUNCATE_EXISTING"/> or <see cref="FILE_FLAG_DELETE_ON_CLOSE"/> are specified, the file affected is a symbolic link.
        /// If <see cref="FILE_FLAG_OPEN_REPARSE_POINT"/> is not specified:
        /// If an existing file is opened and it is a symbolic link, the handle returned is a handle to the target.
        /// If <see cref="CREATE_ALWAYS"/>, <see cref="TRUNCATE_EXISTING"/>, or <see cref="FILE_FLAG_DELETE_ON_CLOSE"/> are specified,
        /// the file affected is the target.
        /// Caching Behavior
        /// Several of the possible values for the <paramref name="dwFlagsAndAttributes"/> parameter are used by <see cref="CreateFile"/>
        /// to control or affect how the data associated with the handle is cached by the system. They are:
        /// <see cref="FILE_FLAG_NO_BUFFERING"/>, <see cref="FILE_FLAG_RANDOM_ACCESS"/>, <see cref="FILE_FLAG_SEQUENTIAL_SCAN"/>,
        /// <see cref="FILE_FLAG_WRITE_THROUGH"/>, <see cref="FILE_ATTRIBUTE_TEMPORARY"/>.
        /// If none of these flags is specified, the system uses a default general-purpose caching scheme.
        /// Otherwise, the system caching behaves as specified for each flag.
        /// Some of these flags should not be combined.
        /// For instance, combining <see cref="FILE_FLAG_RANDOM_ACCESS"/> with <see cref="FILE_FLAG_SEQUENTIAL_SCAN"/> is self-defeating.
        /// Specifying the <see cref="FILE_FLAG_SEQUENTIAL_SCAN"/> flag can increase performance for applications
        /// that read large files using sequential access.
        /// Performance gains can be even more noticeable for applications that read large files mostly sequentially,
        /// but occasionally skip forward over small ranges of bytes.
        /// If an application moves the file pointer for random access, optimum caching performance most likely will not occur.
        /// However, correct operation is still guaranteed.
        /// The flags <see cref="FILE_FLAG_WRITE_THROUGH"/> and <see cref="FILE_FLAG_NO_BUFFERING"/> are independent and may be combined.
        /// If <see cref="FILE_FLAG_WRITE_THROUGH"/> is used but <see cref="FILE_FLAG_NO_BUFFERING"/> is not also specified,
        /// so that system caching is in effect, then the data is written to the system cache but is flushed to disk without delay.
        /// If <see cref="FILE_FLAG_WRITE_THROUGH"/> and <see cref="FILE_FLAG_NO_BUFFERING"/> are both specified,
        /// so that system caching is not in effect, then the data is immediately flushed to disk without going through the Windows system cache.
        /// The operating system also requests a write-through of the hard disk's local hardware cache to persistent media.
        /// Not all hard disk hardware supports this write-through capability.
        /// Proper use of the <see cref="FILE_FLAG_NO_BUFFERING"/> flag requires special application considerations.
        /// For more information, see File Buffering.
        /// A write-through request via <see cref="FILE_FLAG_WRITE_THROUGH"/> also causes NTFS to flush any metadata changes,
        /// such as a time stamp update or a rename operation, that result from processing the request.
        /// For this reason, the <see cref="FILE_FLAG_WRITE_THROUGH"/> flag is often used with 
        /// the <see cref="FILE_FLAG_NO_BUFFERING"/> flag as a replacement for
        /// calling the <see cref="FlushFileBuffers"/> function after each write, which can cause unnecessary performance penalties.
        /// Using these flags together avoids those penalties.
        /// For general information about the caching of files and metadata, see File Caching.
        /// When <see cref="FILE_FLAG_NO_BUFFERING"/> is combined with <see cref="FILE_FLAG_OVERLAPPED"/>,
        /// the flags give maximum asynchronous performance, because the I/O does not rely on the synchronous operations of the memory manager.
        /// However, some I/O operations take more time, because data is not being held in the cache.
        /// Also, the file metadata may still be cached (for example, when creating an empty file).
        /// To ensure that the metadata is flushed to disk, use the <see cref="FlushFileBuffers"/> function.
        /// Specifying the <see cref="FILE_ATTRIBUTE_TEMPORARY"/> attribute causes file systems to avoid writing data back to mass storage
        /// if sufficient cache memory is available, because an application deletes a temporary file after a handle is closed.
        /// In that case, the system can entirely avoid writing the data.
        /// Although it does not directly control data caching in the same way as the previously mentioned flags,
        /// the <see cref="FILE_ATTRIBUTE_TEMPORARY"/> attribute does tell the system to hold as much as possible
        /// in the system cache without writing and therefore may be of concern for certain applications.
        /// Files
        /// If you rename or delete a file and then restore it shortly afterward, the system searches the cache for file information to restore.
        /// Cached information includes its short/long name pair and creation time.
        /// If you call <see cref="CreateFile"/> on a file that is pending deletion as a result of
        /// a previous call to <see cref="DeleteFile"/>, the function fails.
        /// The operating system delays file deletion until all handles to the file are closed.
        /// <see cref="GetLastError"/> returns <see cref="ERROR_ACCESS_DENIED"/>.
        /// The <paramref name="dwDesiredAccess"/> parameter can be zero, allowing the application to query file attributes
        /// without accessing the file if the application is running with adequate security settings.
        /// This is useful to test for the existence of a file without opening it for read and/or write access,
        /// or to obtain other statistics about the file or directory.
        /// See Obtaining and Setting File Information and <see cref="GetFileInformationByHandle"/>.
        /// If <see cref="CREATE_ALWAYS"/> and <see cref="FILE_ATTRIBUTE_NORMAL"/> are specified,
        /// <see cref="CreateFile"/> fails and sets the last error to <see cref="ERROR_ACCESS_DENIED"/> if the file exists
        /// and has the <see cref="FILE_ATTRIBUTE_HIDDEN"/> or <see cref="FILE_ATTRIBUTE_SYSTEM"/> attribute.
        /// To avoid the error, specify the same attributes as the existing file.
        /// When an application creates a file across a network, it is better to use <see cref="GENERIC_READ"/>| <see cref="GENERIC_READ"/>
        /// for <paramref name="dwDesiredAccess"/> than to use <see cref="GENERIC_WRITE"/> alone.
        /// The resulting code is faster, because the redirector can use the cache manager and send fewer SMBs with more data.
        /// This combination also avoids an issue where writing to a file across a network
        /// can occasionally return <see cref="ERROR_ACCESS_DENIED"/>.
        /// For more information, see Creating and Opening Files.
        /// Synchronous and Asynchronous I/O Handles
        /// <see cref="CreateFile"/> provides for creating a file or device handle that is either synchronous or asynchronous.
        /// A synchronous handle behaves such that I/O function calls using that handle are blocked until they complete,
        /// while an asynchronous file handle makes it possible for the system to return immediately from I/O function calls,
        /// whether they completed the I/O operation or not.
        /// As stated previously, this synchronous versus asynchronous behavior is determined
        /// by specifying <see cref="FILE_FLAG_OVERLAPPED"/> within the <paramref name="dwFlagsAndAttributes"/> parameter.
        /// There are several complexities and potential pitfalls when using asynchronous I/O;
        /// for more information, see Synchronous and Asynchronous I/O.
        /// File Streams
        /// On NTFS file systems, you can use <see cref="CreateFile"/> to create separate streams within a file.
        /// For more information, see File Streams.
        /// Directories
        /// An application cannot create a directory by using <see cref="CreateFile"/>, therefore only
        /// the <see cref="OPEN_EXISTING"/> value is valid for <paramref name="dwCreationDisposition"/> for this use case.
        /// To create a directory, the application must call <see cref="CreateDirectory"/> or <see cref="CreateDirectoryEx"/>.
        /// To open a directory using <see cref="CreateFile"/>, specify the <see cref="FILE_FLAG_BACKUP_SEMANTICS"/> flag
        /// as part of <paramref name="dwFlagsAndAttributes"/>.
        /// Appropriate security checks still apply when this flag is used
        /// without <see cref="SE_BACKUP_NAME"/> and <see cref="SE_RESTORE_NAME"/> privileges.
        /// When using <see cref="CreateFile"/> to open a directory during defragmentation of a FAT or FAT32 file system volume,
        /// do not specify the <see cref="MAXIMUM_ALLOWED"/> access right.
        /// Access to the directory is denied if this is done.
        /// Specify the <see cref="GENERIC_READ"/> access right instead.
        /// For more information, see About Directory Management.
        /// Physical Disks and Volumes
        /// Direct access to the disk or to a volume is restricted.
        /// For more information, see "Changes to the file system and to the storage stack to restrict direct disk access
        /// and direct volume access in Windows Vista and in Windows Server 2008" in the Help and Support Knowledge Base
        /// at http://support.microsoft.com/kb/942448.
        /// Windows Server 2003 and Windows XP:  Direct access to the disk or to a volume is not restricted in this manner.
        /// You can use the <see cref="CreateFile"/> function to open a physical disk drive or a volume,
        /// which returns a direct access storage device (DASD) handle that can be used with the <see cref="DeviceIoControl"/> function.
        /// This enables you to access the disk or volume directly, for example such disk metadata as the partition table.
        /// However, this type of access also exposes the disk drive or volume to potential data loss,
        /// because an incorrect write to a disk using this mechanism could make its contents inaccessible to the operating system.
        /// To ensure data integrity, be sure to become familiar with <see cref="DeviceIoControl"/> and how other APIs behave differently
        /// with a direct access handle as opposed to a file system handle.
        /// The following requirements must be met for such a call to succeed:
        /// The caller must have administrative privileges. For more information, see Running with Special Privileges.
        /// The <paramref name="dwCreationDisposition"/> parameter must have the <see cref="OPEN_EXISTING"/> flag.
        /// When opening a volume or floppy disk, the <paramref name="dwShareMode"/> parameter must have
        /// the <see cref="FILE_SHARE_WRITE"/> flag.
        /// The <paramref name="dwDesiredAccess"/> parameter can be zero, allowing the application to query device attributes without accessing a device.
        /// This is useful for an application to determine the size of a floppy disk drive and the formats it supports
        /// without requiring a floppy disk in a drive, for instance.
        /// It can also be used for reading statistics without requiring higher-level data read/write permission.
        /// When opening a physical drive x:, the lpFileName string should be the following form: "\\.\PhysicalDriveX".
        /// Hard disk numbers start at zero. The following table shows some examples of physical drive strings.
        /// "\\.\PhysicalDrive0": Opens the first physical drive.
        /// "\\.\PhysicalDrive2": Opens the third physical drive.
        /// To obtain the physical drive identifier for a volume, open a handle to the volume and
        /// call the <see cref="DeviceIoControl"/> function with <see cref="IOCTL_VOLUME_GET_VOLUME_DISK_EXTENTS"/>.
        /// This control code returns the disk number and offset for each of the volume's one or more extents; a volume can span multiple physical disks.
        /// For an example of opening a physical drive, see Calling DeviceIoControl.
        /// When opening a volume or removable media drive (for example, a floppy disk drive or flash memory thumb drive),
        /// the <paramref name="lpFileName"/> string should be the following form: "\.&lt;i&gt;X:".
        /// Do not use a trailing backslash (), which indicates the root directory of a drive.
        /// The following table shows some examples of drive strings.
        /// "\\.\A:": Opens floppy disk drive A.
        /// "\\.\C:": Opens the C: volume.
        /// "\\.\C:\": Opens the file system of the C: volume.
        /// You can also open a volume by referring to its volume name. For more information, see Naming a Volume.
        /// A volume contains one or more mounted file systems.
        /// Volume handles can be opened as noncached at the discretion of the particular file system,
        /// even when the noncached option is not specified in <see cref="CreateFile"/>.
        /// You should assume that all Microsoft file systems open volume handles as noncached.
        /// The restrictions on noncached I/O for files also apply to volumes.
        /// A file system may or may not require buffer alignment even though the data is noncached.
        /// However, if the noncached option is specified when opening a volume, buffer alignment is enforced regardless of the file system on the volume.
        /// It is recommended on all file systems that you open volume handles as noncached, and follow the noncached I/O restrictions.
        /// To read or write to the last few sectors of the volume, you must call <see cref="DeviceIoControl"/> and
        /// specify <see cref="FSCTL_ALLOW_EXTENDED_DASD_IO"/>.
        /// This signals the file system driver not to perform any I/O boundary checks on partition read or write calls.
        /// Instead, boundary checks are performed by the device driver.
        /// Changer Device
        /// The IOCTL_CHANGER_* control codes for <see cref="DeviceIoControl"/> accept a handle to a changer device.
        /// To open a changer device, use a file name of the following form: "\\.\Changerx" where x is a number
        /// that indicates which device to open, starting with zero.
        /// To open changer device zero in an application that is written in C or C++, use the following file name: "\\\\.\\Changer0".
        /// Tape Drives
        /// You can open tape drives by using a file name of the following form: "\\.\TAPEx" where x is a number 
        /// that indicates which drive to open, starting with tape drive zero.
        /// To open tape drive zero in an application that is written in C or C++, use the following file name: "\\\\.\\TAPE0".
        /// For more information, see Backup.
        /// Communications Resources
        /// The <see cref="CreateFile"/> function can create a handle to a communications resource, such as the serial port COM1.
        /// For communications resources, the <paramref name="dwCreationDisposition"/> parameter must
        /// be <see cref="OPEN_EXISTING"/>, the <paramref name="dwShareMode"/> parameter must be zero (exclusive access),
        /// and the <paramref name="hTemplateFile"/> parameter must be <see cref="IntPtr.Zero"/>.
        /// Read, write, or read/write access can be specified, and the handle can be opened for overlapped I/O.
        /// To specify a COM port number greater than 9, use the following syntax: "\.\COM10".
        /// This syntax works for all port numbers and hardware that allows COM port numbers to be specified.
        /// For more information about communications, see Communications.
        /// Consoles
        /// The <see cref="CreateFile"/> function can create a handle to console input (CONIN$).
        /// If the process has an open handle to it as a result of inheritance or duplication,
        /// it can also create a handle to the active screen buffer (CONOUT$).
        /// The calling process must be attached to an inherited console or one allocated by the <see cref="AllocConsole"/> function.
        /// For console handles, set the <see cref="CreateFile"/> parameters as follows.
        /// <paramref name="lpFileName"/>: 
        /// Use the CONIN$ value to specify console input.
        /// Use the CONOUT$ value to specify console output.
        /// CONIN$ gets a handle to the console input buffer, even if the <see cref="SetStdHandle"/> function redirects the standard input handle.
        /// To get the standard input handle, use the <see cref="GetStdHandle"/> function.
        /// CONOUT$ gets a handle to the active screen buffer, even if <see cref="SetStdHandle"/> redirects the standard output handle.
        /// To get the standard output handle, use <see cref="GetStdHandle"/>.
        /// <paramref name="dwDesiredAccess"/>: <see cref="GENERIC_READ"/> | <see cref="GENERIC_WRITE"/> is preferred, but either one can limit access.
        /// <paramref name="dwShareMode"/>: 
        /// When opening CONIN$, specify <see cref="FILE_SHARE_READ"/>.
        /// When opening CONOUT$, specify <see cref="FILE_SHARE_WRITE"/>.
        /// If the calling process inherits the console, or if a child process should be able to access the console,
        /// this parameter must be <see cref="FILE_SHARE_READ"/> | <see cref="FILE_SHARE_WRITE"/>.
        /// <paramref name="lpSecurityAttributes"/>:
        /// If you want the console to be inherited, the <see cref="SECURITY_ATTRIBUTES.bInheritHandle"/> member of
        /// the <see cref="SECURITY_ATTRIBUTES"/> structure must be <see langword="true"/>.
        /// <paramref name="dwCreationDisposition"/>:
        /// You should specify <see cref="OPEN_EXISTING"/> when using <see cref="CreateFile"/> to open the console.
        /// <paramref name="dwFlagsAndAttributes"/>: Ignored.
        /// <paramref name="hTemplateFile"/>: Ignored.
        /// The following table shows various settings of <paramref name="dwDesiredAccess"/> and <paramref name="lpFileName"/>.
        /// "CON" <see cref="GENERIC_READ"/> Opens console for input.
        /// "CON" <see cref="GENERIC_WRITE"/> Opens console for output.
        /// "CON" <see cref="GENERIC_READ"/> | <see cref="GENERIC_WRITE"/>
        /// Causes <see cref="CreateFile"/> to fail; <see cref="GetLastError"/> returns <see cref="ERROR_FILE_NOT_FOUND"/>.
        /// Mailslots
        /// If <see cref="CreateFile"/> opens the client end of a mailslot, the function returns <see cref="INVALID_HANDLE_VALUE"/>
        /// if the mailslot client attempts to open a local mailslot before the mailslot server has created it with the <see cref="CreateMailslot"/> function.
        /// For more information, see Mailslots.
        /// Pipes
        /// If <see cref="CreateFile"/> opens the client end of a named pipe,
        /// the function uses any instance of the named pipe that is in the listening state.
        /// The opening process can duplicate the handle as many times as required, but after it is opened,
        /// the named pipe instance cannot be opened by another client.
        /// The access that is specified when a pipe is opened must be compatible with the access that is specified
        /// in the dwOpenModeparameter of the <see cref="CreateNamedPipe"/> function.
        /// If the <see cref="CreateNamedPipe"/> function was not successfully called on the server prior to this operation,
        /// a pipe will not exist and <see cref="CreateFile"/> will fail with <see cref="ERROR_FILE_NOT_FOUND"/>.
        /// If there is at least one active pipe instance but there are no available listener pipes on the server,
        /// which means all pipe instances are currently connected, CreateFile fails with <see cref="ERROR_PIPE_BUSY"/>.
        /// For more information, see Pipes.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateFile", SetLastError = true)]
        public static extern IntPtr CreateFile([MarshalAs(UnmanagedType.LPWStr)] [In] string lpFileName, [In]uint dwDesiredAccess,
            [In]FileShareModes dwShareMode,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))]
            [In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpSecurityAttributes, [In]FileCreationDispositions dwCreationDisposition,
            [In]uint dwFlagsAndAttributes, [In]IntPtr hTemplateFile);

        /// <summary>
        /// <para>
        /// Creates or opens a file, file stream, or directory as a transacted operation.
        /// The function returns a handle that can be used to access the object.
        /// To perform this operation as a nontransacted operation or to access objects
        /// other than files(for example, named pipes, physical devices, mailslots), use the <see cref="CreateFile"/> function.
        /// For more information about transactions, see the Remarks section of this topic.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-createfiletransactedw
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
        /// Appropriate security checks still apply when this flag is used
        /// without <see cref="SE_BACKUP_NAME"/> and <see cref="SE_RESTORE_NAME"/> privileges.
        /// When using <see cref="CreateFileTransacted"/> to open a directory during defragmentation of a FAT or FAT32 file system volume,
        /// do not specify the <see cref="MAXIMUM_ALLOWED"/> access right. Access to the directory is denied if this is done.
        /// Specify the <see cref="GENERIC_READ"/> access right instead.
        /// For more information, see About Directory Management.
        /// </remarks>
        [Obsolete("Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs." +
            " Many scenarios that TxF was developed for can be achieved through simpler and more readily available techniques." +
            " Furthermore, TxF may not be available in future versions of Microsoft Windows." +
            " For more information, and alternatives to TxF, please see Alternatives to using Transactional NTFS.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateFileTransactedW", SetLastError = true)]
        public static extern IntPtr CreateFileTransacted([MarshalAs(UnmanagedType.LPWStr)][In]string lpFileName, [In]FileAccessRights dwDesiredAccess,
            [In]FileShareModes dwShareMode,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))]
            [In] StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpSecurityAttributes, [In]FileCreationDispositions dwCreationDisposition,
            [In]uint dwFlagsAndAttributes, [In]IntPtr hTemplateFile, [In]IntPtr hTransaction, [In]IntPtr pusMiniVersion, [In]IntPtr lpExtendedParameter);

        /// <summary>
        /// <para>
        /// Deletes an existing file.
        /// To perform this operation as a transacted operation, use the <see cref="DeleteFileTransacted"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-deletefilew
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// The name of the file to be deleted.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File.
        /// Starting in Windows 10, version 1607, for the unicode version of this function (<see cref="DeleteFile"/>),
        /// you can opt-in to remove the <see cref="MAX_PATH"/> character limitation without prepending "\\?\".
        /// See the "Maximum Path Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If an application attempts to delete a file that does not exist,
        /// the <see cref="DeleteFile"/> function fails with <see cref="ERROR_FILE_NOT_FOUND"/>.
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
        /// The <see cref="DeleteFile"/> function fails if an application attempts to delete a file that has other handles open for normal I/O or
        /// as a memory-mapped file (<see cref="FILE_SHARE_DELETE"/> must have been specified when other handles were opened).
        /// The <see cref="DeleteFile"/> function marks a file for deletion on close.
        /// Therefore, the file deletion does not occur until the last handle to the file is closed.
        /// Subsequent calls to <see cref="CreateFile"/> to open the file fail with <see cref="ERROR_ACCESS_DENIED"/>.
        /// Symbolic link behavior—
        /// If the path points to a symbolic link, the symbolic link is deleted, not the target.
        /// To delete a target, you must call <see cref="CreateFile"/> and specify <see cref="FILE_FLAG_DELETE_ON_CLOSE"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteFileW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteFile([MarshalAs(UnmanagedType.LPWStr)][In]string lpFileName);

        /// <summary>
        /// <para>
        /// Deletes an existing file as a transacted operation.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-deletefiletransactedw
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteFileTransactedW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteFileTransacted([MarshalAs(UnmanagedType.LPWStr)][In]string lpFileName, [In]IntPtr hTransaction);

        /// <summary>
        /// <para>
        /// Closes a file search handle opened by the <see cref="FindFirstFile"/>, <see cref="FindFirstFileEx"/>,
        /// <see cref="FindFirstFileNameW"/>, <see cref="FindFirstFileNameTransactedW"/>, <see cref="FindFirstFileTransacted"/>,
        /// <see cref="FindFirstStreamTransactedW"/>, or <see cref="FindFirstStreamW"/> functions.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-findclose
        /// </para>
        /// </summary>
        /// <param name="hFindFile">
        /// The file search handle.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// After the <see cref="FindClose"/> function is called, the handle specified
        /// by the <see cref="hFindFile"/> parameter cannot be used in subsequent calls to the <see cref="FindNextFile"/>,
        /// <see cref="FindNextFileNameW"/>, <see cref="FindNextStreamW"/>, or <see cref="FindClose"/> functions.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindClose", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FindClose([In]IntPtr hFindFile);

        /// <summary>
        /// <para>
        /// Stops change notification handle monitoring.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-findclosechangenotification
        /// </para>
        /// </summary>
        /// <param name="hChangeHandle">
        /// A handle to a change notification handle created by the <see cref="FindFirstChangeNotification"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// After the FindCloseChangeNotification function is called,
        /// the handle specified by the <paramref name="hChangeHandle"/> parameter cannot be used in subsequent calls
        /// to either the <see cref="FindNextChangeNotification"/> or <see cref="FindCloseChangeNotification"/> function.
        /// Change notifications can also be used in the wait functions.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindCloseChangeNotification", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FindCloseChangeNotification([In]IntPtr hChangeHandle);

        /// <summary>
        /// <para>
        /// Creates a change notification handle and sets up initial change notification filter conditions.
        /// A wait on a notification handle succeeds when a change matching the filter conditions occurs in the specified directory or subtree.
        /// The function does not report changes to the specified directory itself.
        /// This function does not indicate the change that satisfied the wait condition.
        /// To retrieve information about the specific change as part of the notification, use the <see cref="ReadDirectoryChangesW"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-findfirstchangenotificationw
        /// </para>
        /// </summary>
        /// <param name="lpPathName">
        /// The full path of the directory to be watched.
        /// This cannot be a relative path or an empty string.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File.
        /// </param>
        /// <param name="bWatchSubtree">
        /// If this parameter is <see langword="true"/>, the function monitors the directory tree rooted at the specified directory;
        /// if it is <see langword="false"/>, it monitors only the specified directory.
        /// </param>
        /// <param name="dwNotifyFilter">
        /// The filter conditions that satisfy a change notification wait.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to a find change notification object.
        /// If the function fails, the return value is <see cref="INVALID_HANDLE_VALUE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The wait functions can monitor the specified directory or subtree
        /// by using the handle returned by the <see cref="FindFirstChangeNotification"/> function.
        /// A wait is satisfied when one of the filter conditions occurs in the monitored directory or subtree.
        /// After the wait has been satisfied, the application can respond to this condition and continue monitoring the directory
        /// by calling the <see cref="FindNextChangeNotification"/> function and the appropriate wait function.
        /// When the handle is no longer needed, it can be closed by using the <see cref="FindCloseChangeNotification"/> function.
        /// Notifications may not be returned when calling <see cref="FindFirstChangeNotification"/> for a remote file system.
        /// Symbolic link behavior—If the path points to a symbolic link, the notification handle is created for the target.
        /// If an application has registered to receive change notifications for a directory that contains symbolic links,
        /// the application is only notified when the symbolic links have been changed, not the target files.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindFirstChangeNotificationW", SetLastError = true)]
        public static extern IntPtr FindFirstChangeNotification([MarshalAs(UnmanagedType.LPWStr)][In]string lpPathName,
            [In]bool bWatchSubtree, [In]FileNotifyFilters dwNotifyFilter);

        /// <summary>
        /// <para>
        /// Searches a directory for a file or subdirectory with a name that matches a specific name (or partial name if wildcards are used).
        /// To specify additional attributes to use in a search, use the <see cref="FindFirstFileEx"/> function.
        /// To perform this operation as a transacted operation, use the <see cref="FindFirstFileTransacted"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-findfirstfilew
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// The directory or path, and the file name.
        /// The file name can include wildcard characters, for example, an asterisk (*) or a question mark (?).
        /// This parameter should not be <see langword="null"/>, an invalid string (for example, an empty string or a string
        /// that is missing the terminating null character), or end in a trailing backslash().
        /// If the string ends with a wildcard, period(.), or directory name, the user must have access permissions to the root and
        /// all subdirectories on the path.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File.
        /// Starting in Windows 10, version 1607, for the unicode version of this function(<see cref="FindFirstFile"/>),
        /// you can opt-in to remove the <see cref="MAX_PATH"/> character limitation without prepending "\\?\".
        /// See the "Maximum Path Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// </param>
        /// <param name="lpFindFileData">
        /// A pointer to the <see cref="WIN32_FIND_DATA"/> structure that receives information about a found file or directory.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a search handle used in a subsequent call to <see cref="FindNextFile"/>
        /// or <see cref="FindClose"/>, and the <paramref name="lpFindFileData"/> parameter contains information about the first file or directory found.
        /// If the function fails or fails to locate files from the search string in the <paramref name="lpFileName"/> parameter,
        /// the return value is <see cref="INVALID_HANDLE_VALUE"/> and the contents of <paramref name="lpFindFileData"/> are indeterminate.
        /// To get extended error information, call the <see cref="GetLastError"/> function.
        /// If the function fails because no matching files can be found, the <see cref="GetLastError"/> function returns <see cref="ERROR_FILE_NOT_FOUND"/>.
        /// </returns>
        /// <remarks>
        /// The FindFirstFile function opens a search handle and returns information about the first file that the file system finds
        /// with a name that matches the specified pattern.
        /// This may or may not be the first file or directory that appears in a directory-listing application (such as the dir command)
        /// when given the same file name string pattern.
        /// This is because <see cref="FindFirstFile"/> does no sorting of the search results.
        /// For additional information, see <see cref="FindNextFile"/>.
        /// The following list identifies some other search characteristics:
        /// The search is performed strictly on the name of the file, not on any attributes such as a date or a file type
        /// (for other options, see <see cref="FindFirstFileEx"/>).
        /// The search includes the long and short file names.
        /// An attempt to open a search with a trailing backslash always fails.
        /// Passing an invalid string, <see langword="null"/>, or empty string for the <paramref name="lpFileName"/> parameter is
        /// not a valid use of this function. Results in this case are undefined.
        /// In rare cases or on a heavily loaded system, file attribute information on NTFS file systems may not be current
        /// at the time this function is called.
        /// To be assured of getting the current NTFS file system file attributes, call the <see cref="GetFileInformationByHandle"/> function.
        /// After the search handle is established, you can use it to search for other files that match the same pattern
        /// by using the <see cref="FindNextFile"/> function.
        /// When the search handle is no longer needed, close it by using the <see cref="FindClose"/> function, not <see cref="CloseHandle"/>.
        /// As stated previously, you cannot use a trailing backslash () in the <paramref name="lpFileName"/> input string for <see cref="FindFirstFile"/>,
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
        /// The following call:
        /// <code>FindFirstFileEx(lpFileName, FindExInfoStandard, lpFindData, FindExSearchNameMatch, NULL, 0);</code>
        /// s equivalent to the following call:
        /// <code>FindFirstFile(lpFileName, lpFindData);</code>
        /// Be aware that some other thread or process could create or delete a file with this name between the time you query for the result
        /// and the time you act on the information. 
        /// If this is a potential concern for your application, one possible solution is to use the <see cref="CreateFile"/> function
        /// with <see cref="CREATE_NEW"/> (which fails if the file exists) or <see cref="OPEN_EXISTING"/> (which fails if the file does not exist).
        /// If you are writing a 32-bit application to list all the files in a directory and the application may be run on a 64-bit computer,
        /// you should call <see cref="Wow64DisableWow64FsRedirection"/> before calling <see cref="FindFirstFileEx"/>
        /// and call <see cref="Wow64RevertWow64FsRedirection"/> after the last call to <see cref="FindNextFile"/>.
        /// For more information, see File System Redirector.
        /// If the path points to a symbolic link, the <see cref="WIN32_FIND_DATA"/> buffer contains information about the symbolic link, not the target.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindFirstFileW", SetLastError = true)]
        public static extern IntPtr FindFirstFile([MarshalAs(UnmanagedType.LPWStr)][In]string lpFileName, [In][Out]ref WIN32_FIND_DATA lpFindFileData);

        /// <summary>
        /// <para>
        /// Searches a directory for a file or subdirectory with a name and attributes that match those specified.
        /// For the most basic version of this function, see <see cref="FindFirstFile"/>.
        /// To perform this operation as a transacted operation, use the <see cref="FindFirstFileTransacted"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-findfirstfileexw
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// The directory or path, and the file name. The file name can include wildcard characters, for example, an asterisk (*) or a question mark (?).
        /// This parameter should not be <see langword="null"/>, an invalid string (for example, an empty string or a string
        /// that is missing the terminating null character), or end in a trailing backslash().
        /// If the string ends with a wildcard, period, or directory name, the user must have access to the root and all subdirectories on the path.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to approximately 32,000 wide characters, call the Unicode version of the function (<see cref="FindFirstFileEx"/>),
        /// and prepend "\?" to the path.For more information, see Naming a File.
        /// Starting in Windows 10, version 1607, for the unicode version of this function (<see cref="FindFirstFileEx"/>),
        /// you can opt-in to remove the <see cref="MAX_PATH"/> character limitation without prepending "\\?\".
        /// See the "Maximum Path Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// </param>
        /// <param name="fInfoLevelId">
        /// The information level of the returned data.
        /// This parameter is one of the <see cref="FINDEX_INFO_LEVELS"/> enumeration values.
        /// </param>
        /// <param name="lpFindFileData">
        /// A pointer to the buffer that receives the file data.
        /// The pointer type is determined by the level of information that is specified in the <paramref name="fInfoLevelId"/> parameter.
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
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a search handle used in a subsequent call
        /// to <see cref="FindNextFile"/> or <see cref="FindClose"/>, and the <paramref name="lpFindFileData"/> parameter contains information
        /// about the first file or directory found.
        /// If the function fails or fails to locate files from the search string in the <paramref name="lpFileName"/> parameter,
        /// the return value is <see cref="INVALID_HANDLE_VALUE"/> and the contents of <paramref name="lpFindFileData"/> are indeterminate.
        /// To get extended error information, call the <see cref="GetLastError"/> function.
        /// </returns>
        /// <remarks>
        /// The <see cref="FindFirstFileEx"/> function opens a search handle and returns information about the first file
        /// that the file system finds with a name that matches the specified pattern.
        /// This may or may not be the first file or directory that appears in a directory-listing application (such as the dir command)
        /// when given the same file name string pattern.
        /// This is because <see cref="FindFirstFileEx"/> does no sorting of the search results.
        /// For additional information, see <see cref="FindNextFile"/>.
        /// The following list identifies some other search characteristics:
        /// The search is performed strictly on the name of the file, not on any attributes such as a date or a file type.
        /// The search includes the long and short file names.
        /// An attempt to open a search with a trailing backslash always fails.
        /// Passing an invalid string, <see langword="null"/>, or empty string for the <paramref name="lpFileName"/> parameter is
        /// not a valid use of this function.Results in this case are undefined.
        /// Note In rare cases or on a heavily loaded system, file attribute information on NTFS file systems may not be current
        /// at the time this function is called.
        /// To be assured of getting the current NTFS file system file attributes, call the <see cref="GetFileInformationByHandle"/> function.
        /// If the underlying file system does not support the specified type of filtering, other than directory filtering,
        /// <see cref="FindFirstFileEx"/> fails with the error <see cref="ERROR_NOT_SUPPORTED"/>.
        /// The application must use <see cref="FINDEX_SEARCH_OPS"/> type <see cref="FindExSearchNameMatch"/> and perform its own filtering.
        /// After the search handle is established, use it in the <see cref="FindNextFile"/> function to search for other files
        /// that match the same pattern with the same filtering that is being performed.
        /// When the search handle is not needed, it should be closed by using the <see cref="FindClose"/> function.
        /// As stated previously, you cannot use a trailing backslash () in the <paramref name="lpFileName"/> input string
        /// for <see cref="FindFirstFileEx"/>, therefore it may not be obvious how to search root directories.
        /// If you want to see files or get the attributes of a root directory, the following options would apply:
        /// To examine files in a root directory, you can use "C:\*" and step through the directory by using <see cref="FindNextFile"/>.
        /// To get the attributes of a root directory, use the <see cref="GetFileAttributes"/> function.
        /// Note Prepending the string "\\?\" does not allow access to the root directory.
        /// On network shares, you can use an <paramref name="lpFileName"/> in the form of the following: "\\server\service\*".
        /// However, you cannot use an <paramref name="lpFileName"/> that points to the share itself; for example, "\\server\service" is not valid.
        /// To examine a directory that is not a root directory, use the path to that directory, without a trailing backslash.
        /// For example, an argument of "C:\Windows" returns information about the directory "C:\Windows", not about a directory or file in "C:\Windows".
        /// To examine the files and directories in "C:\Windows", use an lpFileName of "C:\Windows*".
        /// The following call:
        /// <code>FindFirstFileEx(lpFileName, FindExInfoStandard, lpFindData, FindExSearchNameMatch, NULL, 0);</code>
        /// s equivalent to the following call:
        /// <code>FindFirstFile(lpFileName, lpFindData);</code>
        /// Be aware that some other thread or process could create or delete a file with this name between the time you query for the result
        /// and the time you act on the information. 
        /// If this is a potential concern for your application, one possible solution is to use the <see cref="CreateFile"/> function
        /// with <see cref="CREATE_NEW"/> (which fails if the file exists) or <see cref="OPEN_EXISTING"/> (which fails if the file does not exist).
        /// If you are writing a 32-bit application to list all the files in a directory and the application may be run on a 64-bit computer,
        /// you should call <see cref="Wow64DisableWow64FsRedirection"/> before calling <see cref="FindFirstFileEx"/>
        /// and call <see cref="Wow64RevertWow64FsRedirection"/> after the last call to <see cref="FindNextFile"/>.
        /// For more information, see File System Redirector.
        /// If the path points to a symbolic link, the <see cref="WIN32_FIND_DATA"/> buffer contains information about the symbolic link, not the target.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindFirstFileExW", SetLastError = true)]
        public static extern IntPtr FindFirstFileEx([MarshalAs(UnmanagedType.LPWStr)][In]string lpFileName, [In]FINDEX_INFO_LEVELS fInfoLevelId,
            [In]IntPtr lpFindFileData, [In]FINDEX_SEARCH_OPS fSearchOp, [In]IntPtr lpSearchFilter, [In]FindFirstFileExFlags dwAdditionalFlags);

        /// <summary>
        /// <para>
        /// Creates an enumeration of all the hard links to the specified file.
        /// The <see cref="FindFirstFileNameW"/> function returns a handle to the enumeration that can be used
        /// on subsequent calls to the <see cref="FindNextFileNameW"/> function.
        /// To perform this operation as a transacted operation, use the <see cref="FindFirstFileNameTransactedW"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-findfirstfilenamew
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// The name of the file.
        /// Starting with Windows 10, version 1607, you can opt-in to remove the <see cref="MAX_PATH"/> limitation without prepending "\\?\".
        /// See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// </param>
        /// <param name="dwFlags">
        /// Reserved; specify zero (0).
        /// </param>
        /// <param name="StringLength">
        /// The size of the buffer pointed to by the LinkName parameter, in characters.
        /// If this call fails and the error returned from the <see cref="GetLastError"/> function is <see cref="ERROR_MORE_DATA"/>,
        /// the value that is returned by this parameter is the size that the buffer pointed to
        /// by <paramref name="LinkName"/> must be to contain all the data.
        /// </param>
        /// <param name="LinkName">
        /// A pointer to a buffer to store the first link name found for <paramref name="lpFileName"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a search handle that can be used with
        /// the <see cref="FindNextFileNameW"/> function or closed with the <see cref="FindClose"/> function.
        /// If the function fails, the return value is <see cref="INVALID_HANDLE_VALUE"/>.
        /// To get extended error information, call the <see cref="GetLastError"/> function.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindFirstFileNameW", SetLastError = true)]
        public static extern IntPtr FindFirstFileNameW([MarshalAs(UnmanagedType.LPWStr)][In]string lpFileName, [In]uint dwFlags,
            [In][Out]ref uint StringLength, [MarshalAs(UnmanagedType.LPWStr)][In][Out]StringBuilder LinkName);

        /// <summary>
        /// <para>
        /// Creates an enumeration of all the hard links to the specified file as a transacted operation.
        /// The function returns a handle to the enumeration that can be used on subsequent calls to the <see cref="FindNextFileNameW"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-findfirstfilenametransactedw
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindFirstFileNameTransactedW ", SetLastError = true)]
        public static extern IntPtr FindFirstFileNameTransactedW([MarshalAs(UnmanagedType.LPWStr)][In]string lpFileName, [In]uint dwFlags,
            [In][Out]ref uint StringLength, [MarshalAs(UnmanagedType.LPWStr)][In][Out]StringBuilder LinkName, [In]IntPtr hTransaction);

        /// <summary>
        /// <para>
        /// Searches a directory for a file or subdirectory with a name that matches a specific name as a transacted operation.
        /// This function is the transacted form of the <see cref="FindFirstFileEx"/> function.
        /// For the most basic version of this function, see <see cref="FindFirstFile"/>.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-findfirstfiletransactedw
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindFirstFileTransactedW", SetLastError = true)]
        public static extern IntPtr FindFirstFileTransacted([MarshalAs(UnmanagedType.LPWStr)][In]string lpFileName, [In]FINDEX_INFO_LEVELS fInfoLevelId,
            [In]IntPtr lpFindFileData, [In]FINDEX_SEARCH_OPS fSearchOp, [In]IntPtr lpSearchFilter,
            [In]FindFirstFileExFlags dwAdditionalFlags, [In]IntPtr hTransaction);

        /// <summary>
        /// <para>
        /// Enumerates the first stream in the specified file or directory as a transacted operation.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-findfirststreamtransactedw
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindFirstStreamTransactedW", SetLastError = true)]
        public static extern IntPtr FindFirstStreamTransactedW([MarshalAs(UnmanagedType.LPWStr)][In]string lpFileName, [In]STREAM_INFO_LEVELS InfoLevel,
            [In]IntPtr lpFindStreamData, [In]uint dwFlags, [In]IntPtr hTransaction);

        /// <summary>
        /// <para>
        /// Enumerates the first stream with a ::$DATA stream type in the specified file or directory.
        /// To perform this operation as a transacted operation, use the <see cref="FindFirstStreamTransactedW"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-findfirststreamw
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// The fully qualified file name.
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
        /// <returns>
        /// If the function succeeds, the return value is a search handle that can be used in subsequent calls to the <see cref="FindNextStreamW"/> function.
        /// If the function fails, the return value is <see cref="INVALID_HANDLE_VALUE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="FindFirstStreamW"/> function opens a search handle and returns information
        /// about the first ::$DATA stream in the specified file or directory.
        /// For files, this is always the default data stream, "::$DATA".
        /// After the search handle has been established, use it in the <see cref="FindNextStreamW"/> function
        /// to search for other streams in the specified file or directory.
        /// When the search handle is no longer needed, it should be closed using the <see cref="FindClose"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindFirstStreamTransactedW", SetLastError = true)]
        public static extern IntPtr FindFirstStreamW([MarshalAs(UnmanagedType.LPWStr)][In] string lpFileName, [In]STREAM_INFO_LEVELS InfoLevel,
            [In]IntPtr lpFindStreamData, [In]uint dwFlags);

        /// <summary>
        /// <para>
        /// Retrieves the name of a mounted folder on the specified volume.
        /// <see cref="FindFirstVolumeMountPoint"/> is used to begin scanning the mounted folders on a volume.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-findfirstvolumemountpointw
        /// </para>
        /// </summary>
        /// <param name="lpszRootPathName">
        /// A volume GUID path for the volume to scan for mounted folders. A trailing backslash is required.
        /// </param>
        /// <param name="lpszVolumeMountPoint">
        /// A pointer to a buffer that receives the name of the first mounted folder that is found.
        /// </param>
        /// <param name="cchBufferLength">
        /// The length of the buffer that receives the path to the mounted folder, in TCHARs.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a search handle used in a subsequent call 
        /// to the <see cref="FindNextVolumeMountPoint"/> and <see cref="FindVolumeMountPointClose"/> functions.
        /// If the function fails to find a mounted folder on the volume, the return value is the <see cref="INVALID_HANDLE_VALUE"/> error code.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="FindFirstVolumeMountPoint"/> function opens a mounted folder search handle and returns information
        /// about the first mounted folder that is found on the specified volume.
        /// After the search handle is established, you can use the <see cref="FindNextVolumeMountPoint"/> function to search for other mounted folders.
        /// When the search handle is no longer needed, close it with the <see cref="FindVolumeMountPointClose"/> function.
        /// The <see cref="FindFirstVolumeMountPoint"/>, <see cref="FindNextVolumeMountPoint"/>,
        /// and <see cref="FindVolumeMountPointClose"/> functions return paths to mounted folders for a specified volume.
        /// They do not return drive letters or volume GUID paths.
        /// For information about enumerating the volume GUID paths for a volume, see Enumerating Volume GUID Paths.
        /// You should not assume any correlation between the order of the mounted folders that are returned by these functions
        /// and the order of the mounted folders that are returned by other functions or tools.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindFirstVolumeMountPointW", SetLastError = true)]
        public static extern IntPtr FindFirstVolumeMountPoint([MarshalAs(UnmanagedType.LPWStr)][In]string lpszRootPathName,
            [MarshalAs(UnmanagedType.LPWStr)][In]StringBuilder lpszVolumeMountPoint, [In]uint cchBufferLength);

        /// <summary>
        /// <para>
        /// Requests that the operating system signal a change notification handle the next time it detects an appropriate change.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-findnextchangenotification
        /// </para>
        /// </summary>
        /// <param name="hChangeHandle">
        /// A handle to a change notification handle created by the <see cref="FindFirstChangeNotification"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// After the <see cref="FindNextChangeNotification"/> function returns successfully,
        /// the application can wait for notification that a change has occurred by using the wait functions.
        /// If a change occurs after a call to <see cref="FindFirstChangeNotification"/> but before a call to <see cref="FindNextChangeNotification"/>,
        /// the operating system records the change.
        /// When <see cref="FindNextChangeNotification"/> is executed, the recorded change immediately satisfies a wait for the change notification.
        /// <see cref="FindNextChangeNotification"/> should not be used more than once on the same handle without using one of the wait functions.
        /// An application may miss a change notification if it uses <see cref="FindNextChangeNotification"/> when there is a change request outstanding.
        /// When <paramref name="hChangeHandle"/> is no longer needed, close it by using the <see cref="FindCloseChangeNotification"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindNextChangeNotification", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FindNextChangeNotification([In]IntPtr hChangeHandle);

        /// <summary>
        /// <para>
        /// Continues a file search from a previous call to the <see cref="FindFirstFile"/>,
        /// <see cref="FindFirstFileEx"/>, or <see cref="FindFirstFileTransacted"/> functions.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-findnextfilew
        /// </para>
        /// </summary>
        /// <param name="hFindFile">
        /// The search handle returned by a previous call to the <see cref="FindFirstFile"/> or <see cref="FindFirstFileEx"/> function.
        /// </param>
        /// <param name="lpFindFileData">
        /// A pointer to the <see cref="WIN32_FIND_DATA"/> structure that receives information about the found file or subdirectory.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/> and the <paramref name="lpFindFileData"/> parameter
        /// contains information about the next file or directory found.
        /// If the function fails, the return value is <see langword="false"/> and the contents of lpFindFileData are indeterminate.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If the function fails because no more matching files can be found,
        /// the <see cref="GetLastError"/> function returns <see cref="ERROR_NO_MORE_FILES"/>.
        /// </returns>
        /// <remarks>
        /// This function uses the same search filters that were used to create the search handle passed in the <paramref name="hFindFile"/> parameter.
        /// For additional information, see <see cref="FindFirstFile"/> and <see cref="FindFirstFileEx"/>.
        /// The order in which the search returns the files, such as alphabetical order, is not guaranteed, and is dependent on the file system.
        /// If the data must be sorted, the application must do the ordering after obtaining all the results.
        /// In rare cases or on a heavily loaded system, file attribute information on NTFS file systems may not be current
        /// at the time this function is called.
        /// To be assured of getting the current NTFS file system file attributes, call the <see cref="GetFileInformationByHandle"/> function.
        /// The order in which this function returns the file names is dependent on the file system type.
        /// With the NTFS file system and CDFS file systems, the names are usually returned in alphabetical order.
        /// With FAT file systems, the names are usually returned in the order the files were written to the disk,
        /// which may or may not be in alphabetical order.
        /// However, as stated previously, these behaviors are not guaranteed.
        /// If the path points to a symbolic link, the <see cref="WIN32_FIND_DATA"/> buffer contains information about the symbolic link, not the target.
        /// If there is a transaction bound to the file enumeration handle,
        /// then the files that are returned are subject to transaction isolation rules.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindNextFileW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FindNextFile([In]IntPtr hFindFile, [In][Out]ref WIN32_FIND_DATA lpFindFileData);

        /// <summary>
        /// <para>
        /// Continues enumerating the hard links to a file using the handle returned by a successful call to the <see cref="FindFirstFileNameW"/> function.
        /// </para>
        /// </summary>
        /// <param name="hFindStream">
        /// A handle to the enumeration that is returned by a successful call to <see cref="FindFirstFileNameW"/>.
        /// </param>
        /// <param name="StringLength">
        /// The size of the <paramref name="LinkName"/> parameter, in characters.
        /// If this call fails and the error is <see cref="ERROR_MORE_DATA"/>, the value that is returned by this parameter is the size
        /// that <paramref name="LinkName"/> must be to contain all the data.
        /// </param>
        /// <param name="LinkName">
        /// A pointer to a buffer to store the first link name found for <paramref name="hFindStream"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If no matching files can be found, the <see cref="GetLastError"/> function returns <see cref="ERROR_HANDLE_EOF"/>.
        /// </returns>
        /// <remarks>
        /// If the function returns <see langword="true"/>, there are more hard links to enumerate.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindNextFileNameW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FindNextFileNameW([In]IntPtr hFindStream, [In][Out]ref uint StringLength,
            [MarshalAs(UnmanagedType.LPWStr)][In][Out]StringBuilder LinkName);

        /// <summary>
        /// <para>
        /// Continues a stream search started by a previous call to the <see cref="FindFirstStreamW"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-findnextstreamw
        /// </para>
        /// </summary>
        /// <param name="hFindStream">
        /// The search handle returned by a previous call to the <see cref="FindFirstStreamW"/> function.
        /// </param>
        /// <param name="lpFindStreamData">
        /// A pointer to the <see cref="WIN32_FIND_STREAM_DATA"/> structure that receives information about the stream.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If no matching files can be found, the <see cref="GetLastError"/> function returns <see cref="ERROR_HANDLE_EOF"/>.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindNextStreamW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FindNextStreamW([In]IntPtr hFindStream, [In]IntPtr lpFindStreamData);

        /// <summary>
        /// <para>
        /// Continues a mounted folder search started by a call to the <see cref="FindFirstVolumeMountPoint"/> function.
        /// <see cref="FindNextVolumeMountPoint"/> finds one mounted folder per call.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-findnextvolumemountpointw
        /// </para>
        /// </summary>
        /// <param name="hFindVolumeMountPoint">
        /// A mounted folder search handle returned by a previous call to the <see cref="FindFirstVolumeMountPoint"/> function.
        /// </param>
        /// <param name="lpszVolumeMountPoint">
        /// A pointer to a buffer that receives the name of the mounted folder that is found.
        /// </param>
        /// <param name="cchBufferLength">
        /// The length of the buffer that receives the mounted folder name, in TCHARs.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If no more mounted folders can be found, the <see cref="GetLastError"/> function returns the <see cref="ERROR_NO_MORE_FILES"/> error code.
        /// In that case, close the search with the <see cref="FindVolumeMountPointClose"/> function.
        /// </returns>
        /// <remarks>
        /// After the search handle is established by calling <see cref="FindFirstVolumeMountPoint"/>,
        /// you can use the <see cref="FindNextVolumeMountPoint"/> function to search for other mounted folders.
        /// The <see cref="FindFirstVolumeMountPoint"/>, <see cref="FindNextVolumeMountPoint"/>,
        /// and <see cref="FindVolumeMountPointClose"/> functions return paths to mounted folders for a specified volume.
        /// They do not return drive letters or volume GUID paths.
        /// For information about enumerating the volume GUID paths for a volume, see Enumerating Volume GUID Paths.
        /// You should not assume any correlation between the order of the mounted folders that are returned
        /// with these functions and the order of the mounted folders that are returned by other functions or tools.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindNextVolumeMountPointW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FindNextVolumeMountPoint([In]IntPtr hFindVolumeMountPoint,
            [MarshalAs(UnmanagedType.LPWStr)][In]StringBuilder lpszVolumeMountPoint, [In]uint cchBufferLength);

        /// <summary>
        /// <para>
        /// Closes the specified mounted folder search handle.
        /// The <see cref="FindFirstVolumeMountPoint"/> and <see cref="FindNextVolumeMountPoint"/> functions
        /// use this search handle to locate mounted folders on a specified volume.
        /// </para>
        /// </summary>
        /// <param name="hFindVolumeMountPoint">
        /// The mounted folder search handle to be closed.
        /// This handle must have been previously opened by the <see cref="FindFirstVolumeMountPoint"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// After the <see cref="FindVolumeMountPointClose"/> function is called,
        /// the handle <paramref name="hFindVolumeMountPoint"/> cannot be used in subsequent calls to
        /// either <see cref="FindNextVolumeMountPoint"/> or <see cref="FindVolumeMountPointClose"/>.
        /// The <see cref="FindFirstVolumeMountPoint"/>, <see cref="FindNextVolumeMountPoint"/>,
        /// and <see cref="FindVolumeMountPointClose"/> functions return paths to mounted folders for a specified volume.
        /// They do not return drive letters or volume GUID paths.
        /// For information about enumerating the volume GUID paths for a volume, see Enumerating Volume GUID Paths.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindVolumeMountPointClose", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FindVolumeMountPointClose([In]IntPtr hFindVolumeMountPoint);

        /// <summary>
        /// <para>
        /// Flushes the buffers of a specified file and causes all buffered data to be written to a file.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-flushfilebuffers
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the open file.
        /// The file handle must have the <see cref="GENERIC_WRITE"/> access right.
        /// For more information, see File Security and Access Rights.
        /// If <paramref name="hFile"/> is a handle to a communications device, the function only flushes the transmit buffer.
        /// If <paramref name="hFile"/> is a handle to the server end of a named pipe,
        /// the function does not return until the client has read all buffered data from the pipe.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// The function fails if <paramref name="hFile"/> is a handle to the console output.
        /// That is because the console output is not buffered.
        /// The function returns <see langword="false"/>, and <see cref="GetLastError"/> returns <see cref="ERROR_INVALID_HANDLE"/>.
        /// </returns>
        /// <remarks>
        /// Typically the <see cref="WriteFile"/> and <see cref="WriteFileEx"/> functions write data to an internal buffer
        /// that the operating system writes to a disk or communication pipe on a regular basis.
        /// The <see cref="FlushFileBuffers"/> function writes all the buffered information for a specified file to the device or pipe.
        /// Due to disk caching interactions within the system, the <see cref="FlushFileBuffers"/> function can be inefficient
        /// when used after every write to a disk drive device when many writes are being performed separately.
        /// If an application is performing multiple writes to disk and also needs to ensure critical data is written to persistent media,
        /// the application should use unbuffered I/O instead of frequently calling <see cref="FlushFileBuffers"/>.
        /// To open a file for unbuffered I/O, call the <see cref="CreateFile"/> function with
        /// the <see cref="FILE_FLAG_NO_BUFFERING"/> and <see cref="FILE_FLAG_WRITE_THROUGH"/> flags.
        /// This prevents the file contents from being cached and flushes the metadata to disk with each write.
        /// For more information, see <see cref="CreateFile"/>.
        /// To flush all open files on a volume, call <see cref="FlushFileBuffers"/> with a handle to the volume.
        /// The caller must have administrative privileges. For more information, see Running with Special Privileges.
        /// When opening a volume with <see cref="CreateFile"/>, the lpFileName string should be the following form: \.&lt;i&gt;x: or \?\Volume{GUID}.
        /// Do not use a trailing backslash in the volume name, because that indicates the root directory of a drive.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FlushFileBuffers", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FlushFileBuffers([In]IntPtr hFile);

        /// <summary>
        /// <para>
        /// Retrieves file system attributes for a specified file or directory.
        /// To get more attribute information, use the <see cref="GetFileAttributesEx"/> function.
        /// To perform this operation as a transacted operation, use the <see cref="GetFileAttributesTransacted"/> function.
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// The name of the file or directory.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function (<see cref="GetFileAttributes"/>),
        /// and prepend "\\?\" to the path.
        /// For more information, see File Names, Paths, and Namespaces.
        ///  Starting in Windows 10, version 1607, for the unicode version of this function (<see cref="GetFileAttributes"/>),
        ///  you can opt-in to remove the <see cref="MAX_PATH"/> character limitation without prepending "\\?\".
        ///  See the "Maximum Path Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value contains the attributes of the specified file or directory.
        /// For a list of attribute values and their descriptions, see File Attribute Constants.
        /// If the function fails, the return value is <see cref="INVALID_FILE_ATTRIBUTES"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// When <see cref="GetFileAttributes"/> is called on a directory that is a mounted folder,
        /// it returns the file system attributes of the directory,
        /// not those of the root directory in the volume that the mounted folder associates with the directory.
        /// To obtain the file attributes of the associated volume,
        /// call <see cref="GetVolumeNameForVolumeMountPoint"/> to obtain the name of the associated volume.
        /// Then use the resulting name in a call to <see cref="GetFileAttributes"/>.
        /// The results are the attributes of the root directory on the associated volume.
        /// If you call <see cref="GetFileAttributes"/> for a network share, the function fails,
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_BAD_NETPATH"/>.
        /// You must specify a path to a subfolder on that share.
        /// Symbolic link behavior—If the path points to a symbolic link, the function returns attributes for the symbolic link.
        /// Transacted Operations
        /// If a file is open for modification in a transaction, no other thread can open the file for modification until the transaction is committed.
        /// So if a transacted thread opens the file first, any subsequent threads that try modifying the file before the transaction
        /// is committed receives a sharing violation.
        /// If a non-transacted thread modifies the file before the transacted thread does,
        /// and the file is still open when the transaction attempts to open it,
        /// the transaction receives the error <see cref="ERROR_TRANSACTIONAL_CONFLICT"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFileAttributesW", SetLastError = true)]
        public static extern FileAttributes GetFileAttributes([MarshalAs(UnmanagedType.LPWStr)][In]string lpFileName);

        /// <summary>
        /// <para>
        /// Retrieves attributes for a specified file or directory.
        /// To perform this operation as a transacted operation, use the <see cref="GetFileAttributesTransacted"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-getfileattributesexw
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// The name of the file or directory.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function (<see cref="GetFileAttributesEx"/>),
        /// and prepend "\\?\" to the path. For more information, see Naming a File.
        /// Starting in Windows 10, version 1607, for the unicode version of this function (<see cref="GetFileAttributesEx"/>),
        /// you can opt-in to remove the <see cref="MAX_PATH"/> character limitation without prepending "\\?\".
        /// See the "Maximum Path Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// </param>
        /// <param name="fInfoLevelId">
        /// A class of attribute information to retrieve.
        /// This parameter can be the following value from the <see cref="GET_FILEEX_INFO_LEVELS"/> enumeration.
        /// <see cref="GetFileExInfoStandard"/>: The <paramref name="lpFileInformation"/> parameter is a <see cref="WIN32_FILE_ATTRIBUTE_DATA"/> structure.
        /// </param>
        /// <param name="lpFileInformation">
        /// A pointer to a buffer that receives the attribute information.
        /// The type of attribute information that is stored into this buffer is determined by the value of <paramref name="fInfoLevelId"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="GetFileAttributes"/> function retrieves file system attribute information.
        /// <see cref="GetFileAttributesEx"/> can obtain other sets of file or directory attribute information.
        /// Currently, <see cref="GetFileAttributesEx"/> retrieves a set of standard attributes that is a superset of the file system attribute information.
        /// When the <see cref="GetFileAttributesEx"/> function is called on a directory that is a mounted folder,
        /// it returns the attributes of the directory, not those of the root directory in the volume that the mounted folder associates with the directory.
        /// To obtain the attributes of the associated volume,
        /// call <see cref="GetVolumeNameForVolumeMountPoint"/> to obtain the name of the associated volume.
        /// Then use the resulting name in a call to <see cref="GetFileAttributesEx"/>.
        /// The results are the attributes of the root directory on the associated volume.
        /// Symbolic link behavior—If the path points to a symbolic link, the function returns attributes for the symbolic link.
        /// Transacted Operations
        /// If a file is open for modification in a transaction, no other thread can open the file for modification until the transaction is committed.
        /// So if a transacted thread opens the file first, any subsequent threads that try modifying the file
        /// before the transaction is committed receives a sharing violation.
        /// If a non-transacted thread modifies the file before the transacted thread does,
        /// and the file is still open when the transaction attempts to open it,
        /// the transaction receives the error <see cref="ERROR_TRANSACTIONAL_CONFLICT"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFileAttributesExW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetFileAttributesEx([MarshalAs(UnmanagedType.LPWStr)][In]string lpFileName,
            [In]GET_FILEEX_INFO_LEVELS fInfoLevelId, [In]IntPtr lpFileInformation);
    }
}
