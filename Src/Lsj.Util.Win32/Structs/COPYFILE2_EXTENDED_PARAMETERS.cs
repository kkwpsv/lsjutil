using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.COPY_FILE;
using static Lsj.Util.Win32.Enums.StandardAccessRights;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains extended parameters for the <see cref="CopyFile2"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/ns-winbase-copyfile2_extended_parameters"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct COPYFILE2_EXTENDED_PARAMETERS
    {
        /// <summary>
        /// Contains the size of this structure, <code>sizeof(COPYFILE2_EXTENDED_PARAMETERS)</code>.
        /// </summary>
        public DWORD dwSize;

        /// <summary>
        /// <para>
        /// Contains a combination of zero or more of these flag values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// <para>
        /// <see cref="COPY_FILE_FAIL_IF_EXISTS"/>
        /// </para>
        /// </term>
        /// <term>
        /// If the destination file exists the copy operation fails immediately.
        /// If a file or directory exists with the destination name then the <see cref="CopyFile2"/> function call
        /// will fail with either <code>HRESULT_FROM_WIN32(ERROR_ALREADY_EXISTS)</code> or <code>HRESULT_FROM_WIN32(ERROR_FILE_EXISTS)</code>.
        /// If <see cref="COPY_FILE_RESUME_FROM_PAUSE"/> is also specified then a failure is only triggered if the destination file does not have a valid restart header.
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="COPY_FILE_RESTARTABLE"/>
        /// </para>
        /// </term>
        /// <term>
        /// The file is copied in a manner that can be restarted if the same source and destination filenames are used again.
        /// This is slower.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="COPY_FILE_OPEN_SOURCE_FOR_WRITE"/>
        /// </para>
        /// </term>
        /// <term>
        /// The file is copied and the source file is opened for write access.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="COPY_FILE_ALLOW_DECRYPTED_DESTINATION"/>
        /// </para>
        /// </term>
        /// <term>
        /// The copy will be attempted even if the destination file cannot be encrypted.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="COPY_FILE_COPY_SYMLINK"/>
        /// </para>
        /// </term>
        /// <term>
        /// If the source file is a symbolic link, the destination file is also a symbolic link pointing to the same file as the source symbolic link.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="COPY_FILE_NO_BUFFERING"/>
        /// </para>
        /// </term>
        /// <term>
        /// The copy is performed using unbuffered I/O, bypassing the system cache resources.
        /// This flag is recommended for very large file copies.
        /// It is not recommended to pause copies that are using this flag.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="COPY_FILE_REQUEST_SECURITY_PRIVILEGES"/>
        /// </para>
        /// </term>
        /// <term>
        /// The copy is attempted, specifying <code>ACCESS_SYSTEM_SECURITY</code> for the source file
        /// and <code>ACCESS_SYSTEM_SECURITY | WRITE_DAC | WRITE_OWNER</code> for the destination file.
        /// If these requests are denied the access request will be reduced to the highest privilege level for which access is granted.
        /// For more information see SACL Access Right.
        /// This can be used to allow the <see cref="CopyFile2ProgressRoutine"/> callback to perform operations requiring higher privileges,
        /// such as copying the security attributes for the file.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="COPY_FILE_RESUME_FROM_PAUSE"/>
        /// </para>
        /// </term>
        /// <term>
        /// The destination file is examined to see if it was copied using <see cref="COPY_FILE_RESTARTABLE"/>.
        /// If so the copy is resumed. If not the file will be fully copied.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="COPY_FILE_NO_OFFLOAD"/>
        /// </para>
        /// </term>
        /// <term>
        /// Do not attempt to use the Windows Copy Offload mechanism. This is not generally recommended.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="COPY_FILE_IGNORE_EDP_BLOCK"/>
        /// </para>
        /// </term>
        /// <term>
        /// Instead of blocking, the file should be copied and encrypted on the destination if supported by the destination file system.
        /// Supported on Windows 10 and later.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="COPY_FILE_IGNORE_SOURCE_ENCRYPTION"/>
        /// </para>
        /// </term>
        /// <term>
        /// Ignore the source file’s encrypted state.
        /// Supported on Windows 10 and later.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="COPY_FILE_DONT_REQUEST_DEST_WRITE_DAC"/>
        /// </para>
        /// </term>
        /// <term>
        /// Don't request <see cref="WRITE_DAC"/> for the destination file access.
        /// Supported on Windows 10 and later.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="COPY_FILE_OPEN_AND_COPY_REPARSE_POINT"/>
        /// </para>
        /// </term>
        /// <term>
        /// Always copy the reparse point regardless of type.
        /// It's the caller’s responsibility to understand the reparse point meaning.
        /// Supported on Windows 10, build 19041 and later.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="COPY_FILE_DIRECTORY"/>
        /// </para>
        /// </term>
        /// <term>
        /// Indicates the source file is a directory file.
        /// When provided, the source file is opened with <see cref="FILE_OPEN_FOR_BACKUP_INTENT"/>.
        /// The directory file will have its alternate data streams, reparse point info, and EAs copied like a normal file.
        /// Supported in Windows 10, build 19041 and later.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="COPY_FILE_SKIP_ALTERNATE_STREAMS"/>
        /// </para>
        /// </term>
        /// <term>
        /// Do not copy alternate data streams.
        /// Supported in Windows 10, build 19041 and later.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="COPY_FILE_DISABLE_PRE_ALLOCATION"/>
        /// </para>
        /// </term>
        /// <term>
        /// Do not preallocate the destination file size before performing the copy. Supported in Windows 10, build 19041 and later.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="COPY_FILE_ENABLE_LOW_FREE_SPACE_MODE"/>
        /// </para>
        /// </term>
        /// <term>
        /// Enable LowFreeSpace mode. No overlapped I/Os are used. ODX and SMB offload are not attempted.
        /// Supported in Windows 10, build 19041 and later.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="COPY_FILE_REQUEST_COMPRESSED_TRAFFIC"/>
        /// </para>
        /// </term>
        /// <term>
        /// Request the underlying transfer channel compress the data during the copy operation.
        /// The request may not be supported for all mediums, in which case it is ignored.
        /// The compression attributes and parameters (computational complexity, memory usage) are not configurable through this API,
        /// and are subject to change between different OS releases.
        /// Supported in Windows Server 2022 and Windows 10, build 1903 and later.
        /// (On Windows 10, the flag is supported for files residing on SMB shares, where the negotiated SMB protocol version is SMB v3.1.1 or greater.)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="COPY_FILE_ENABLE_SPARSE_COPY"/>
        /// </para>
        /// </term>
        /// <term>
        /// Enable retaining the sparse state of the file during copy.
        /// Supported in Windows 11, build 22H2 and later.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public COPY_FILE dwCopyFlags;

        /// <summary>
        /// If this flag is set to <see cref="TRUE"/> during the copy operation then the copy operation is canceled.
        /// </summary>
        public P<BOOL> pfCancel;

        /// <summary>
        /// The optional address of a callback function of type <see cref="PCOPYFILE2_PROGRESS_ROUTINE"/>
        /// that is called each time another portion of the file has been copied.
        /// This parameter can be <see cref="NULL"/>.
        /// For more information on the progress callback function, see the CopyFile2ProgressRoutine callback function.
        /// </summary>
        public PCOPYFILE2_PROGRESS_ROUTINE pProgressRoutine;

        /// <summary>
        /// A pointer to application-specific context information to be passed to the CopyFile2ProgressRoutine.
        /// </summary>
        public PVOID pvCallbackContext;
    }
}
