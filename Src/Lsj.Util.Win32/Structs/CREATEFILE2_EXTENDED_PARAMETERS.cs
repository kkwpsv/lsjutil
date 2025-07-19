using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.FileAttributes;
using static Lsj.Util.Win32.Enums.FileCreationDispositions;
using static Lsj.Util.Win32.Enums.FileFlags;
using static Lsj.Util.Win32.Enums.FileShareModes;
using static Lsj.Util.Win32.Enums.GenericAccessRights;
using static Lsj.Util.Win32.Enums.PrivilegeConstants;
using static Lsj.Util.Win32.Enums.SecurityQualityOfServiceFlags;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains optional extended parameters for <see cref="CreateFile2"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/fileapi/ns-fileapi-createfile2_extended_parameters"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Caching Behavior
    /// </para>
    /// <para>
    /// Several of the possible values for the <see cref="dwFileFlags"/> member are used to control
    /// or affect how the data associated with the handle is cached by the system.
    /// They are:
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="FILE_FLAG_NO_BUFFERING"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="FILE_FLAG_RANDOM_ACCESS"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="FILE_FLAG_SEQUENTIAL_SCAN"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="FILE_FLAG_WRITE_THROUGH"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="FILE_ATTRIBUTE_TEMPORARY"/>
    /// </description>
    /// </item>
    /// </list>
    /// <para>
    /// If none of these flags is specified, the system uses a default general-purpose caching scheme.
    /// Otherwise, the system caching behaves as specified for each flag.
    /// </para>
    /// <para>
    /// Some of these flags should not be combined.
    /// For instance, combining <see cref="FILE_FLAG_RANDOM_ACCESS"/> with <see cref="FILE_FLAG_SEQUENTIAL_SCAN"/> is self-defeating.
    /// </para>
    /// <para>
    /// Specifying the <see cref="FILE_FLAG_SEQUENTIAL_SCAN"/> flag can increase performance for applications
    /// that read large files using sequential access.
    /// Performance gains can be even more noticeable for applications that read large files mostly sequentially,
    /// but occasionally skip forward over small ranges of bytes.
    /// If an application moves the file pointer for random access, optimum caching performance most likely will not occur.
    /// However, correct operation is still guaranteed.
    /// </para>
    /// <para>
    /// The flags <see cref="FILE_FLAG_WRITE_THROUGH"/> and <see cref="FILE_FLAG_NO_BUFFERING"/> are independent and may be combined.
    /// </para>
    /// <para>
    /// If <see cref="FILE_FLAG_WRITE_THROUGH"/> is used but <see cref="FILE_FLAG_NO_BUFFERING"/> is not also specified,
    /// so that system caching is in effect, then the data is written to the system cache but is flushed to disk without delay.
    /// </para>
    /// <para>
    /// If <see cref="FILE_FLAG_WRITE_THROUGH"/> and <see cref="FILE_FLAG_NO_BUFFERING"/> are both specified,
    /// so that system caching is not in effect, then the data is immediately flushed to disk without going through the Windows system cache.
    /// The operating system also requests a write-through of the hard disk's local hardware cache to persistent media.
    /// </para>
    /// <para>
    /// Note
    /// </para>
    /// <para>
    /// Not all hard disk hardware supports this write-through capability.
    /// </para>
    /// <para>
    /// Proper use of the <see cref="FILE_FLAG_NO_BUFFERING"/> flag requires special application considerations.
    /// For more information, see File Buffering.
    /// </para>
    /// <para>
    /// A write-through request via <see cref="FILE_FLAG_WRITE_THROUGH"/> also causes NTFS to flush any metadata changes,
    /// such as a time stamp update or a rename operation, that result from processing the request.
    /// For this reason, the <see cref="FILE_FLAG_WRITE_THROUGH"/> flag is often used with the <see cref="FILE_FLAG_NO_BUFFERING"/> flag
    /// as a replacement for calling the <see cref="FlushFileBuffers"/> function after each write, which can cause unnecessary performance penalties.
    /// Using these flags together avoids those penalties.
    /// For general information about the caching of files and metadata, see File Caching.
    /// </para>
    /// <para>
    /// When <see cref="FILE_FLAG_NO_BUFFERING"/> is combined with <see cref="FILE_FLAG_OVERLAPPED"/>,
    /// the flags give maximum asynchronous performance, because the I/O does not rely on the synchronous operations of the memory manager.
    /// However, some I/O operations take more time, because data is not being held in the cache.
    /// Also, the file metadata may still be cached (for example, when creating an empty file).
    /// To ensure that the metadata is flushed to disk, use the <see cref="FlushFileBuffers"/> function.
    /// </para>
    /// <para>
    /// Specifying the <see cref="FILE_ATTRIBUTE_TEMPORARY"/> attribute causes file systems
    /// to avoid writing data back to mass storage if sufficient cache memory is available,
    /// because an application deletes a temporary file after a handle is closed.
    /// In that case, the system can entirely avoid writing the data.
    /// Although it does not directly control data caching in the same way as the previously mentioned flags,
    /// the <see cref="FILE_ATTRIBUTE_TEMPORARY"/> attribute does tell the system to hold as much as possible in the system cache
    /// without writing and therefore may be of concern for certain applications.
    /// </para>
    /// <para>
    /// Synchronous and Asynchronous I/O Handles
    /// </para>
    /// <para>
    /// <see cref="CreateFile2"/> provides for creating a file or device handle that is either synchronous or asynchronous.
    /// A synchronous handle behaves such that I/O function calls using that handle are blocked until they complete,
    /// while an asynchronous file handle makes it possible for the system to return immediately from I/O function calls,
    /// whether they completed the I/O operation or not.
    /// As stated previously, this synchronous versus asynchronous behavior is determined
    /// by specifying <see cref="FILE_FLAG_OVERLAPPED"/> within the <see cref="dwFileFlags"/> member
    /// of the <see cref="CREATEFILE2_EXTENDED_PARAMETERS"/> structure passed in the pCreateExParams parameter. 
    /// There are several complexities and potential pitfalls when using asynchronous I/O; for more information, see Synchronous and Asynchronous I/O.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CREATEFILE2_EXTENDED_PARAMETERS
    {
        /// <summary>
        /// Contains the size of this structure, <code>sizeof(CREATEFILE2_EXTENDED_PARAMETERS)</code>.
        /// </summary>
        public DWORD dwSize;

        /// <summary>
        /// <para>
        /// The file or device attributes and flags, <see cref="FILE_ATTRIBUTE_NORMAL"/> being the most common default value for files.
        /// </para>
        /// <para>
        /// This parameter can include any combination of the available file attributes (FILE_ATTRIBUTE_*).
        /// All other file attributes override <see cref="FILE_ATTRIBUTE_NORMAL"/>.
        /// </para>
        /// <para>
        ///  Note
        /// </para>
        /// <para>
        /// When <see cref="CreateFile2"/> opens an existing file, it generally combines the file flags with the file attributes of the existing file,
        /// and ignores any file attributes supplied as part of dwFlagsAndAttributes.
        /// Special cases are detailed in Creating and Opening Files.
        /// </para>
        /// <para>
        /// Some of the following file attributes and flags may only apply to files
        /// and not necessarily all other types of devices that <see cref="CreateFile2"/> can open.
        /// For additional information, see the Remarks section of the <see cref="CreateFile2"/> reference page and Creating and Opening Files.
        /// </para>
        /// <para>
        /// For more advanced access to file attributes, see <see cref="SetFileAttributes"/>.
        /// For a complete list of all file attributes with their values and descriptions, see File Attribute Constants.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Attribute
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_ATTRIBUTE_ARCHIVE"/>
        /// </para>
        /// </term>
        /// <term>
        /// The file should be archived. Applications use this attribute to mark files for backup or removal.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_ATTRIBUTE_ENCRYPTED"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The file or directory is encrypted.
        /// For a file, this means that all data in the file is encrypted.
        /// For a directory, this means that encryption is the default for newly created files and subdirectories.
        /// For more information, see File Encryption.
        /// </para>
        /// <para>
        /// This flag has no effect if <see cref="FILE_ATTRIBUTE_SYSTEM"/> is also specified.
        /// </para>
        /// <para>
        /// This flag is not supported on Home, Home Premium, Starter, or ARM editions of Windows.
        /// </para>
        /// <para>
        /// This flag is not supported when called from a Windows Store app.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_ATTRIBUTE_HIDDEN"/>
        /// </para>
        /// </term>
        /// <term>
        /// The file is hidden. Do not include it in an ordinary directory listing.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_ATTRIBUTE_INTEGRITY_STREAM"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// A file or directory that is configured with integrity. For a file, all data streams in the file have integrity.
        /// For a directory, integrity is the default for newly created files and subdirectories, unless the caller specifies otherwise.
        /// </para>
        /// <para>
        /// This flag is only supported on the ReFS file system.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_ATTRIBUTE_NORMAL"/>
        /// </para>
        /// </term>
        /// <term>
        /// The file does not have other attributes set. This attribute is valid only if used alone.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_ATTRIBUTE_OFFLINE"/>
        /// </para>
        /// </term>
        /// <term>
        /// The data of a file is not immediately available.
        /// This attribute indicates that file data is physically moved to offline storage.
        /// This attribute is used by Remote Storage, the hierarchical storage management software.
        /// Applications should not arbitrarily change this attribute.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_ATTRIBUTE_READONLY"/>
        /// </para>
        /// </term>
        /// <term>
        /// The file is read only. Applications can read the file, but cannot write to or delete it.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_ATTRIBUTE_SYSTEM"/>
        /// </para>
        /// </term>
        /// <term>
        /// The file is part of or used exclusively by an operating system.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_ATTRIBUTE_TEMPORARY"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The file is being used for temporary storage.
        /// </para>
        /// <para>
        /// For more information, see the Caching Behavior section of this topic.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public DWORD dwFileAttributes;

        /// <summary>
        /// <para>
        /// This parameter can contain combinations of flags (FILE_FLAG_*) for control of file or device
        /// caching behavior, access modes, and other special-purpose flags.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Flag
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_FLAG_BACKUP_SEMANTICS"/>
        /// </para>
        /// <para>
        /// 0x02000000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The file is being opened or created for a backup or restore operation.
        /// The system ensures that the calling process overrides file security checks
        /// when the process has <see cref="SE_BACKUP_NAME"/> and <see cref="SE_RESTORE_NAME"/> privileges.
        /// For more information, see Changing Privileges in a Token.
        /// </para>
        /// <para>
        /// You must set this flag to obtain a handle to a directory.
        /// A directory handle can be passed to some functions instead of a file handle.
        /// For more information, see the Remarks section.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_FLAG_DELETE_ON_CLOSE"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The file is to be deleted immediately after all of its handles are closed,
        /// which includes the specified handle and any other open or duplicated handles.
        /// </para>
        /// <para>
        /// If there are existing open handles to a file, the call fails unless they were all opened with the <see cref="FILE_SHARE_DELETE"/> share mode.
        /// </para>
        /// <para>
        /// Subsequent open requests for the file fail, unless the <see cref="FILE_SHARE_DELETE"/> share mode is specified.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_FLAG_IGNORE_IMPERSONATED_DEVICEMAP"/>
        /// </para>
        /// </term>
        /// <term>
        /// A device map is a mapping between DOS device names and devices in the system, and is used when resolving DOS names.
        /// Separate device maps exists for each user in the system, and users can manage their own device maps.
        /// Typically during impersonation, the impersonated user's device map would be used.
        /// However, when this flag is set, the process user's device map is used instead.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_FLAG_NO_BUFFERING"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The file or device is being opened with no system caching for data reads and writes.
        /// This flag does not affect hard disk caching or memory mapped files.
        /// </para>
        /// <para>
        /// There are strict requirements for successfully working with files opened with <see cref="CreateFile2"/>
        /// using the <see cref="FILE_FLAG_NO_BUFFERING"/> flag, for details see File Buffering.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_FLAG_OPEN_NO_RECALL"/>
        /// </para>
        /// </term>
        /// <term>
        /// The file data is requested, but it should continue to be located in remote storage.
        /// It should not be transported back to local storage.
        /// This flag is for use by remote storage systems.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_FLAG_OPEN_REPARSE_POINT"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Normal reparse point processing will not occur; <see cref="CreateFile2"/> will attempt to open the reparse point.
        /// When a file is opened, a file handle is returned, whether or not the filter that controls the reparse point is operational.
        /// </para>
        /// <para>
        /// This flag cannot be used with the <see cref="CREATE_ALWAYS"/> flag.
        /// </para>
        /// <para>
        /// If the file is not a reparse point, then this flag is ignored.
        /// </para>
        /// <para>
        /// For more information, see the Remarks section.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_FLAG_OPEN_REQUIRING_OPLOCK"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The file is being opened and an opportunistic lock (oplock) on the file is being requested as a single atomic operation.
        /// The file system checks for oplocks before it performs the create operation,
        /// and will fail the create with a last error code of <see cref="ERROR_CANNOT_BREAK_OPLOCK"/> if the result would be to break an existing oplock.
        /// </para>
        /// <para>
        /// If you use this flag and your call to the <see cref="CreateFile2"/> function returns successfully,
        /// you should request an oplock on the file by calling <see cref="DeviceIoControl"/> on the new file handle
        /// with <see cref="FSCTL_REQUEST_OPLOCK"/> or one of the other Opportunistic Lock Operations.
        /// If you perform other file system operations on the file before requesting an oplock, a deadlock may occur.
        /// A deadlock is especially likely if you call a file system API that takes the name of the file rather than a handle, such as <see cref="GetFileAttributes"/>.
        /// </para>
        /// <para>
        /// Note: You can safely call the <see cref="CloseHandle"/> function on the file handle without first requesting an oplock.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_FLAG_OVERLAPPED"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The file or device is being opened or created for asynchronous I/O.
        /// </para>
        /// <para>
        /// When subsequent I/O operations are completed on this handle,
        /// the event specified in the <see cref="OVERLAPPED"/> structure will be set to the signaled state.
        /// </para>
        /// <para>
        /// If this flag is specified, the file can be used for simultaneous read and write operations.
        /// </para>
        /// <para>
        /// If this flag is not specified, then I/O operations are serialized,
        /// even if the calls to the read and write functions specify an <see cref="OVERLAPPED"/> structure.
        /// </para>
        /// <para>
        /// For information about considerations when using a file handle created with this flag,
        /// see the Synchronous and Asynchronous I/O Handles section of this topic.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_FLAG_POSIX_SEMANTICS"/>
        /// </para>
        /// </term>
        /// <term>
        /// Access will occur according to POSIX rules.
        /// This includes allowing multiple files with names, differing only in case, for file systems that support that naming.
        /// Use care when using this option, because files created with this flag
        /// may not be accessible by applications that are written for MS-DOS or 16-bit Windows.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_FLAG_RANDOM_ACCESS"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Access is intended to be random. The system can use this as a hint to optimize file caching.
        /// </para>
        /// <para>
        /// This flag has no effect if the file system does not support cached I/O and <see cref="FILE_FLAG_NO_BUFFERING"/>.
        /// </para>
        /// <para>
        /// For more information, see the Caching Behavior section of this topic.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_FLAG_SESSION_AWARE"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The file or device is being opened with session awareness.
        /// If this flag is not specified, then per-session devices (such as a device using RemoteFX USB Redirection) cannot be opened by processes running in session 0.
        /// This flag has no effect for callers not in session 0. This flag is supported only on server editions of Windows.
        /// </para>
        /// <para>
        /// Windows Server 2008 R2 and Windows Server 2008: This flag is not supported before Windows Server 2012.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_FLAG_SEQUENTIAL_SCAN"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Access is intended to be sequential from beginning to end. The system can use this as a hint to optimize file caching.
        /// </para>
        /// <para>
        /// This flag should not be used if read-behind (that is, backwards scans) will be used.
        /// </para>
        /// <para>
        /// This flag has no effect if the file system does not support cached I/O and <see cref="FILE_FLAG_NO_BUFFERING"/>.
        /// </para>
        /// <para>
        /// For more information, see the Caching Behavior section of this topic.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_FLAG_WRITE_THROUGH"/>
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Write operations will not go through any intermediate cache, they will go directly to disk.
        /// </para>
        /// <para>
        /// For additional information, see the Caching Behavior section of this topic.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public FileFlags dwFileFlags;

        /// <summary>
        /// <para>
        /// The <see cref="dwSecurityQosFlags"/> parameter specifies SQOS information.
        /// For more information, see Impersonation Levels.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Security flag
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="SECURITY_ANONYMOUS"/>
        /// </term>
        /// <term>
        /// Impersonates a client at the Anonymous impersonation level.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SECURITY_CONTEXT_TRACKING"/>
        /// </term>
        /// <term>
        /// The security tracking mode is dynamic. If this flag is not specified, the security tracking mode is static.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SECURITY_DELEGATION"/>
        /// </term>
        /// <term>
        /// Impersonates a client at the Delegation impersonation level.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SECURITY_EFFECTIVE_ONLY"/>
        /// </term>
        /// <term>
        /// <para>
        /// Only the enabled aspects of the client's security context are available to the server.
        /// If you do not specify this flag, all aspects of the client's security context are available.
        /// </para>
        /// <para>
        /// This allows the client to limit the groups and privileges that a server can use while impersonating the client.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SECURITY_IDENTIFICATION"/>
        /// </term>
        /// <term>
        /// Impersonates a client at the Identification impersonation level.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SECURITY_IMPERSONATION"/>
        /// </term>
        /// <term>
        /// Impersonate a client at the impersonation level. This is the default behavior if no other flags are specified.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public SecurityQualityOfServiceFlags dwSecurityQosFlags;

        /// <summary>
        /// <para>
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that contains two separate but related data members:
        /// an optional security descriptor, and a Boolean value that determines whether the returned handle can be inherited by child processes.
        /// </para>
        /// <para>
        /// This parameter can be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NULL"/>, the handle returned by <see cref="CreateFile2"/> cannot be inherited by any child processes
        /// the application may create and the file or device associated with the returned handle gets a default security descriptor.
        /// </para>
        /// <para>
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a <see cref="SECURITY_DESCRIPTOR"/> for a file or device.
        /// If this member is <see cref="NULL"/>, the file or device associated with the returned handle is assigned a default security descriptor.
        /// </para>
        /// <para>
        /// <see cref="CreateFile2"/> ignores the <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member
        /// when opening an existing file or device, but continues to use the <see cref="SECURITY_ATTRIBUTES.bInheritHandle"/> member.
        /// </para>
        /// <para>
        /// The <see cref="SECURITY_ATTRIBUTES.bInheritHandle"/> member of the structure specifies whether the returned handle can be inherited.
        /// </para>
        /// <para>
        /// For more information, see the Remarks section of the <see cref="CreateFile2"/> topic.
        /// </para>
        /// </summary>
        public LP<SECURITY_ATTRIBUTES> lpSecurityAttributes;

        /// <summary>
        /// <para>
        /// A valid handle to a template file with the <see cref="GENERIC_READ"/> access right.
        /// The template file supplies file attributes and extended attributes for the file that is being created.
        /// </para>
        /// <para>
        /// This parameter can be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// When opening an existing file, <see cref="CreateFile2"/> ignores this parameter.
        /// </para>
        /// <para>
        /// When opening a new encrypted file, the file inherits the discretionary access control list from its parent directory.
        /// For additional information, see File Encryption.
        /// </para>
        /// </summary>
        public HANDLE hTemplateFile;
    }
}
