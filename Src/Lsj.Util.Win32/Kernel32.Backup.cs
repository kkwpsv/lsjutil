using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.ACCESS_MASK;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.FileFlags;
using static Lsj.Util.Win32.Enums.StandardAccessRights;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// The <see cref="BackupRead"/> function can be used to back up a file or directory, including the security information.
        /// The function reads data associated with a specified file or directory into a buffer,
        /// which can then be written to the backup medium using the <see cref="WriteFile"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-backupread"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// <para>
        /// Handle to the file or directory to be backed up.
        /// To obtain the handle, call the <see cref="CreateFile"/> function.
        /// The SACLs are not read unless the file handle was created with the <see cref="ACCESS_SYSTEM_SECURITY"/> access right.
        /// For more information, see File security and access rights.
        /// </para>
        /// <para>
        /// The handle must be synchronous (nonoverlapped).
        /// This means that the <see cref="FILE_FLAG_OVERLAPPED"/> flag must not be set when <see cref="CreateFile"/> is called.
        /// This function does not validate that the handle it receives is synchronous,
        /// so it does not return an error code for a synchronous handle,
        /// but calling it with an asynchronous (overlapped) handle can result in subtle errors that are very difficult to debug.
        /// </para>
        /// <para>
        /// The <see cref="BackupRead"/> function may fail if <see cref="CreateFile"/> was called with the flag <see cref="FILE_FLAG_NO_BUFFERING"/>.
        /// In this case, the <see cref="GetLastError"/> function returns the value <see cref="ERROR_INVALID_PARAMETER"/>.
        /// </para>
        /// </param>
        /// <param name="lpBuffer">
        /// Pointer to a buffer that receives the data.
        /// </param>
        /// <param name="nNumberOfBytesToRead">
        /// Length of the buffer, in bytes.
        /// The buffer size must be greater than the size of a <see cref="WIN32_STREAM_ID"/> structure.
        /// </param>
        /// <param name="lpNumberOfBytesRead">
        /// <para>
        /// Pointer to a variable that receives the number of bytes read.
        /// </para>
        /// <para>
        /// If the function returns a nonzero value, and the variable pointed to by <paramref name="lpNumberOfBytesRead"/> is zero,
        /// then all the data associated with the file handle has been read.
        /// </para>
        /// </param>
        /// <param name="bAbort">
        /// Indicates whether you have finished using <see cref="BackupRead"/> on the handle.
        /// While you are backing up the file, specify this parameter as <see cref="FALSE"/>.
        /// Once you are done using <see cref="BackupRead"/>,
        /// you must call <see cref="BackupRead"/> one more time specifying <see cref="TRUE"/>
        /// for this parameter and passing the appropriate <paramref name="lpContext"/>.
        /// <paramref name="lpContext"/> must be passed when <paramref name="bAbort"/> is <see cref="TRUE"/>; all other parameters are ignored.
        /// </param>
        /// <param name="bProcessSecurity">
        /// <para>
        /// Indicates whether the function will restore the access-control list (ACL) data for the file or directory.
        /// </para>
        /// <para>
        /// If <paramref name="bProcessSecurity"/> is <see cref="TRUE"/>, the ACL data will be backed up.
        /// </para>
        /// </param>
        /// <param name="lpContext">
        /// <para>
        /// Pointer to a variable that receives a pointer to an internal data structure
        /// used by <see cref="BackupRead"/> to maintain context information during a backup operation.
        /// </para>
        /// <para>
        /// You must set the variable pointed to by <paramref name="lpContext"/> to <see cref="NULL"/>
        /// before the first call to <see cref="BackupRead"/> for the specified file or directory.
        /// The function allocates memory for the data structure, and then sets the variable to point to that structure.
        /// You must not change <paramref name="lpContext"/> or the variable that it points to between calls to <see cref="BackupRead"/>.
        /// </para>
        /// <para>
        /// To release the memory used by the data structure,
        /// call <see cref="BackupRead"/> with the <paramref name="bAbort"/> parameter set to <see cref="TRUE"/>
        /// when the backup operation is complete.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero, indicating that an I/O error occurred.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function is not intended for use in backing up files encrypted under the Encrypted File System.
        /// Use <see cref="ReadEncryptedFileRaw"/> for that purpose.
        /// </para>
        /// <para>
        /// If an error occurs while <see cref="BackupRead"/> is reading data,
        /// the calling process can skip the bad data by calling the <see cref="BackupSeek"/> function.
        /// </para>
        /// <para>
        /// The file or directory should be restored using the <see cref="BackupWrite"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "BackupRead", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL BackupRead([In] HANDLE hFile,
#if NETFRAMEWORK
            [In] nint lpBuffer,
#else
            [In] P<BYTE> lpBuffer,
#endif
            [In] DWORD nNumberOfBytesToRead, [Out] out DWORD lpNumberOfBytesRead, [In] BOOL bAbort,
            [In] BOOL bProcessSecurity, [Out] out LPVOID lpContext);

        /// <summary>
        /// <para>
        /// The <see cref="BackupSeek"/> function seeks forward in a data stream initially accessed
        /// by using the <see cref="BackupRead"/> or <see cref="BackupWrite"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-backupseek"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// <para>
        /// Handle to the file or directory.
        /// This handle is created by using the <see cref="CreateFile"/> function.
        /// </para>
        /// <para>
        /// The handle must be synchronous (nonoverlapped).
        /// This means that the <see cref="FILE_FLAG_OVERLAPPED"/> flag must not be set when <see cref="CreateFile"/> is called.
        /// This function does not validate that the handle it receives is synchronous,
        /// so it does not return an error code for a synchronous handle,
        /// but calling it with an asynchronous (overlapped) handle can result in subtle errors that are very difficult to debug.
        /// </para>
        /// </param>
        /// <param name="dwLowBytesToSeek">
        /// Low-order part of the number of bytes to seek.
        /// </param>
        /// <param name="dwHighBytesToSeek">
        /// High-order part of the number of bytes to seek.
        /// </param>
        /// <param name="lpdwLowByteSeeked">
        /// Pointer to a variable that receives the low-order bits of the number of bytes the function actually seeks.
        /// </param>
        /// <param name="lpdwHighByteSeeked">
        /// Pointer to a variable that receives the high-order bits of the number of bytes the function actually seeks.
        /// </param>
        /// <param name="lpContext">
        /// Pointer to an internal data structure used by the function.
        /// This structure must be the same structure that was initialized by the <see cref="BackupRead"/> or <see cref="BackupWrite"/> function.
        /// An application must not touch the contents of this structure.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function could seek the requested amount, the function returns a nonzero value.
        /// </para>
        /// <para>
        /// If the function could not seek the requested amount, the function returns zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// Applications use the <see cref="BackupSeek"/> function to skip portions of a data stream that cause errors.
        /// This function does not seek across stream headers.
        /// For example, this function cannot be used to skip the stream name.
        /// If an application attempts to seek past the end of a substream, the function fails,
        /// the <paramref name="lpdwLowByteSeeked"/> and <paramref name="lpdwHighByteSeeked"/> parameters
        /// indicate the actual number of bytes the function seeks,
        /// and the file position is placed at the start of the next stream header.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "BackupSeek", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL BackupSeek([In] HANDLE hFile, [In] DWORD dwLowBytesToSeek, [In] DWORD dwHighBytesToSeek,
            [Out] out DWORD lpdwLowByteSeeked, [Out] out DWORD lpdwHighByteSeeked, [In] in LPVOID lpContext);

        /// <summary>
        /// <para>
        /// The <see cref="BackupWrite"/> function can be used to restore a file or directory that was backed up using <see cref="BackupRead"/>.
        /// Use the <see cref="ReadFile"/> function to get a stream of data from the backup medium,
        /// then use <see cref="BackupWrite"/> to write the data to the specified file or directory.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-backupwrite"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// <para>
        /// Handle to the file or directory to be restored.
        /// To obtain the handle, call the <see cref="CreateFile"/> function.
        /// The SACLs are not restored unless the file handle was created with the <see cref="ACCESS_SYSTEM_SECURITY"/> access right.
        /// To ensure that the integrity ACEs are restored correctly,
        /// the file handle must also have been created with the <see cref="WRITE_OWNER"/> access right.
        /// For more information, see File security and access rights.
        /// </para>
        /// <para>
        /// The handle must be synchronous (nonoverlapped).
        /// This means that the <see cref="FILE_FLAG_OVERLAPPED"/> flag must not be set when <see cref="CreateFile"/> is called.
        /// This function does not validate that the handle it receives is synchronous,
        /// so it does not return an error code for a synchronous handle,
        /// but calling it with an asynchronous (overlapped) handle can result in subtle errors that are very difficult to debug.
        /// </para>
        /// <para>
        /// The <see cref="BackupWrite"/> function may fail if <see cref="CreateFile"/> was called with the flag <see cref="FILE_FLAG_NO_BUFFERING"/>.
        /// In this case, the <see cref="GetLastError"/> function returns the value <see cref="ERROR_INVALID_PARAMETER"/>.
        /// </para>
        /// </param>
        /// <param name="lpBuffer">
        /// Pointer to a buffer that the function writes data from.
        /// </param>
        /// <param name="nNumberOfBytesToWrite">
        /// Size of the buffer, in bytes. The buffer size must be greater than the size of a <see cref="WIN32_STREAM_ID"/> structure.
        /// </param>
        /// <param name="lpNumberOfBytesWritten">
        /// Pointer to a variable that receives the number of bytes written.
        /// </param>
        /// <param name="bAbort">
        /// Indicates whether you have finished using <see cref="BackupWrite"/> on the handle.
        /// While you are restoring the file, specify this parameter as <see cref="FALSE"/>.
        /// After you are done using <see cref="BackupWrite"/>,
        /// you must call <see cref="BackupWrite"/> one more time specifying <see cref="TRUE"/> for this parameter
        /// and passing the appropriate <paramref name="lpContext"/>.
        /// <paramref name="lpContext"/> must be passed when <paramref name="bAbort"/> is <see cref="TRUE"/>;
        /// all other parameters are ignored.
        /// </param>
        /// <param name="bProcessSecurity">
        /// <para>
        /// Specifies whether the function will restore the access-control list (ACL) data for the file or directory.
        /// </para>
        /// <para>
        /// If <paramref name="bProcessSecurity"/> is <see cref="TRUE"/>,
        /// you need to specify <see cref="WRITE_OWNER"/> and <see cref="WRITE_DAC"/> access when opening the file or directory handle.
        /// If the handle does not have those access rights, the operating system denies access to the ACL data,
        /// and ACL data restoration will not occur.
        /// </para>
        /// </param>
        /// <param name="lpContext">
        /// <para>
        /// Pointer to a variable that receives a pointer to an internal data structure used by <see cref="BackupWrite"/>
        /// to maintain context information during a restore operation.
        /// </para>
        /// <para>
        /// You must set the variable pointed to by <paramref name="lpContext"/> to <see cref="NULL"/>
        /// before the first call to <see cref="BackupWrite"/> for the specified file or directory.
        /// The function allocates memory for the data structure, and then sets the variable to point to that structure.
        /// You must not change <paramref name="lpContext"/> or the variable that it points to between calls to <see cref="BackupWrite"/>.
        /// </para>
        /// <para>
        /// To release the memory used by the data structure,
        /// call <see cref="BackupWrite"/> with the <paramref name="bAbort"/> parameter set to <see cref="TRUE"/>
        /// when the restore operation is complete.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero, indicating that an I/O error occurred.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function is not intended for use in restoring files encrypted under the Encrypted File System.
        /// Use <see cref="WriteEncryptedFileRaw"/> for that purpose.
        /// </para>
        /// <para>
        /// The data read from the backup medium must be substreams separated by <see cref="WIN32_STREAM_ID"/> structures.
        /// </para>
        /// <para>
        /// The <c>BACKUP_LINK</c> stream type lets you restore files with hard links.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "BackupWrite", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL BackupWrite([In] HANDLE hFile,
#if NETFRAMEWORK
            [In] nint lpBuffer,
#else
            [In] P<BYTE> lpBuffer,
#endif
            [In] DWORD nNumberOfBytesToWrite, [Out] out DWORD lpNumberOfBytesWritten, [In] BOOL bAbort,
            [In] BOOL bProcessSecurity, [Out] out LPVOID lpContext);
    }
}
