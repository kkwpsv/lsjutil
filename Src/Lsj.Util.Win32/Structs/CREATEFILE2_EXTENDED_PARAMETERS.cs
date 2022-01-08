using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.FileAttributes;
using static Lsj.Util.Win32.Enums.FileFlags;
using static Lsj.Util.Win32.Enums.SecurityQualityOfServiceFlags;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains optional extended parameters for <see cref="CreateFile2"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/en-us/windows/win32/api/fileapi/ns-fileapi-createfile2_extended_parameters"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CREATEFILE2_EXTENDED_PARAMETERS
    {
        /// <summary>
        /// Contains the size of this structure, <code>sizeof(CREATEFILE2_EXTENDED_PARAMETERS)</code>.
        /// </summary>
        public DWORD dwSize;

        /// <summary>
        /// The file or device attributes and flags, <see cref="FILE_ATTRIBUTE_NORMAL"/> being the most common default value for files.
        /// This parameter can include any combination of the available file attributes (FILE_ATTRIBUTE_*).
        /// All other file attributes override <see cref="FILE_ATTRIBUTE_NORMAL"/>.
        /// Note
        /// When <see cref="CreateFile2"/> opens an existing file, it generally combines the file flags with the file attributes of the existing file,
        /// and ignores any file attributes supplied as part of <see cref="dwFlagsAndAttributes"/>.
        /// Special cases are detailed in Creating and Opening Files.
        /// Some of the following file attributes and flags may only apply to files
        /// and not necessarily all other types of devices that <see cref="CreateFile2"/> can open.
        /// For additional information, see the Remarks section of the <see cref="CreateFile2"/> reference page and Creating and Opening Files.
        /// For more advanced access to file attributes, see <see cref="SetFileAttributes"/>.
        /// For a complete list of all file attributes with their values and descriptions, see File Attribute Constants.
        /// <see cref="FILE_ATTRIBUTE_ARCHIVE"/>, <see cref="FILE_ATTRIBUTE_ENCRYPTED"/>, <see cref="FILE_ATTRIBUTE_HIDDEN"/>,
        /// <see cref="FILE_ATTRIBUTE_INTEGRITY_STREAM"/>, <see cref="FILE_ATTRIBUTE_NORMAL"/>, <see cref="FILE_ATTRIBUTE_OFFLINE"/>,
        /// <see cref="FILE_ATTRIBUTE_READONLY"/>, <see cref="FILE_ATTRIBUTE_SYSTEM"/>,<see cref="FILE_ATTRIBUTE_TEMPORARY"/>
        /// </summary>
        public DWORD dwFileAttributes;

        /// <summary>
        /// This parameter can contain combinations of flags (FILE_FLAG_*) for control of file or device
        /// caching behavior, access modes, and other special-purpose flags.
        /// <see cref="FILE_FLAG_BACKUP_SEMANTICS"/>, <see cref="FILE_FLAG_DELETE_ON_CLOSE"/>, <see cref="FILE_FLAG_NO_BUFFERING"/>,
        /// <see cref="FILE_FLAG_OPEN_NO_RECALL"/>, <see cref="FILE_FLAG_OPEN_REPARSE_POINT"/>, <see cref="FILE_FLAG_OPEN_REQUIRING_OPLOCK"/>,
        /// <see cref="FILE_FLAG_OVERLAPPED"/>, <see cref="FILE_FLAG_POSIX_SEMANTICS"/>, <see cref="FILE_FLAG_RANDOM_ACCESS"/>,
        /// <see cref="FILE_FLAG_SESSION_AWARE"/>, <see cref="FILE_FLAG_SEQUENTIAL_SCAN"/>, <see cref="FILE_FLAG_WRITE_THROUGH"/>
        /// </summary>
        public FileFlags dwFileFlags;

        /// <summary>
        /// The <see cref="dwSecurityQosFlags"/> parameter specifies SQOS information.
        /// For more information, see Impersonation Levels.
        /// <see cref="SECURITY_ANONYMOUS"/>:
        /// Impersonates a client at the Anonymous impersonation level.
        /// <see cref="SECURITY_CONTEXT_TRACKING"/>:
        /// The security tracking mode is dynamic. If this flag is not specified, the security tracking mode is static.
        /// <see cref="SECURITY_DELEGATION"/>:
        /// Impersonates a client at the Delegation impersonation level.
        /// <see cref="SECURITY_EFFECTIVE_ONLY"/>:
        /// Only the enabled aspects of the client's security context are available to the server.
        /// If you do not specify this flag, all aspects of the client's security context are available.
        /// This allows the client to limit the groups and privileges that a server can use while impersonating the client.
        /// <see cref="SECURITY_IDENTIFICATION"/>:
        /// Impersonates a client at the Identification impersonation level.
        /// <see cref="SECURITY_IMPERSONATION"/>:
        /// Impersonate a client at the impersonation level.
        /// This is the default behavior if no other flags are specified.
        /// </summary>
        public SecurityQualityOfServiceFlags dwSecurityQosFlags;

        /// <summary>
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that contains two separate but related data members:
        /// an optional security descriptor, and a Boolean value that determines whether the returned handle can be inherited by child processes.
        /// This parameter can be <see cref="NULL"/>.
        /// If this parameter is <see cref="NULL"/>, the handle returned by <see cref="CreateFile2"/> cannot be inherited
        /// by any child processes the application may create and the file or device associated with the returned handle gets a default security descriptor.
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a <see cref="SECURITY_DESCRIPTOR"/> for a file or device.
        /// If this member is <see cref="NULL"/>, the file or device associated with the returned handle is assigned a default security descriptor.
        /// <see cref="CreateFile2"/> ignores the <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member when opening an existing file or device,
        /// but continues to use the <see cref="SECURITY_ATTRIBUTES.bInheritHandle"/> member.
        /// The <see cref="SECURITY_ATTRIBUTES.bInheritHandle"/> member of the structure specifies whether the returned handle can be inherited.
        /// For more information, see the Remarks section of the <see cref="CreateFile2"/> topic.
        /// </summary>
        public LP<SECURITY_ATTRIBUTES> lpSecurityAttributes;

        /// <summary>
        /// A valid handle to a template file with the <see cref="GENERIC_READ"/> access right.
        /// The template file supplies file attributes and extended attributes for the file that is being created.
        /// This parameter can be <see cref="NULL"/>.
        /// When opening an existing file, <see cref="CreateFile2"/> ignores this parameter.
        /// When opening a new encrypted file, the file inherits the discretionary access control list from its parent directory.
        /// For additional information, see File Encryption.
        /// </summary>
        public HANDLE hTemplateFile;
    }
}
