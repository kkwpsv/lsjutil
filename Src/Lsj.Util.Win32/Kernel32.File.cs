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
using static Lsj.Util.Win32.Enums.GenericAccessRights;
using static Lsj.Util.Win32.Enums.GET_FILEEX_INFO_LEVELS;
using static Lsj.Util.Win32.Enums.GetFinalPathNameByHandleFlags;
using static Lsj.Util.Win32.Enums.IoControlCodes;
using static Lsj.Util.Win32.Enums.LockFileExFlags;
using static Lsj.Util.Win32.Enums.LPPROGRESS_ROUTINECallbackReasons;
using static Lsj.Util.Win32.Enums.LPPROGRESS_ROUTINEResults;
using static Lsj.Util.Win32.Enums.MoveFileFlags;
using static Lsj.Util.Win32.Enums.MoveMethods;
using static Lsj.Util.Win32.Enums.OpenFileFlags;
using static Lsj.Util.Win32.Enums.ReplaceFileFlags;
using static Lsj.Util.Win32.Enums.SECURITY_INFORMATION;
using static Lsj.Util.Win32.Enums.SecurityQualityOfServiceFlags;
using static Lsj.Util.Win32.Enums.StandardAccessRights;
using static Lsj.Util.Win32.Enums.STREAM_INFO_LEVELS;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.SetupAPI;
using static Lsj.Util.Win32.Shell32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using FILETIME = Lsj.Util.Win32.Structs.FILETIME;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// INVALID_FILE_SIZE
        /// </summary>
        public const uint INVALID_FILE_SIZE = 0xFFFFFFFF;

        /// <summary>
        /// OFS_MAXPATHNAME
        /// </summary>
        public const int OFS_MAXPATHNAME = 128;

        /// <summary>
        /// STORAGE_INFO_OFFSET_UNKNOWN 
        /// </summary>
        public const uint STORAGE_INFO_OFFSET_UNKNOWN = 0xFFFFFFFF;

        /// <summary>
        /// SYMBOLIC_LINK_FLAG_DIRECTORY 
        /// </summary>
        public const uint SYMBOLIC_LINK_FLAG_DIRECTORY = 0x1;

        /// <summary>
        /// SYMBOLIC_LINK_FLAG_ALLOW_UNPRIVILEGED_CREATE 
        /// </summary>
        public const uint SYMBOLIC_LINK_FLAG_ALLOW_UNPRIVILEGED_CREATE = 0x2;


        /// <summary>
        /// <para>
        /// An application-defined callback function used with the <see cref="CopyFileEx"/>,
        /// <see cref="MoveFileTransacted"/>, and <see cref="MoveFileWithProgress"/> functions.
        /// It is called when a portion of a copy or move operation is completed.
        /// The <see cref="LPPROGRESS_ROUTINE"/> type defines a pointer to this callback function.
        /// CopyProgressRoutine is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nc-winbase-lpprogress_routine"/>
        /// </para>
        /// </summary>
        /// <param name="TotalFileSize">
        /// The total size of the file, in bytes.
        /// </param>
        /// <param name="TotalBytesTransferred">
        /// The total number of bytes transferred from the source file to the destination file since the copy operation began.
        /// </param>
        /// <param name="StreamSize">
        /// The total size of the current file stream, in bytes.
        /// </param>
        /// <param name="StreamBytesTransferred">
        /// The total number of bytes in the current stream that have been transferred from the source file to the destination file since the copy operation began.
        /// </param>
        /// <param name="dwStreamNumber">
        /// A handle to the current stream. The first time CopyProgressRoutine is called, the stream number is 1.
        /// </param>
        /// <param name="dwCallbackReason">
        /// The reason that CopyProgressRoutine was called. This parameter can be one of the following values.
        /// <see cref="CALLBACK_CHUNK_FINISHED"/>, <see cref="CALLBACK_STREAM_SWITCH"/>
        /// </param>
        /// <param name="hSourceFile">
        /// A handle to the source file.
        /// </param>
        /// <param name="hDestinationFile">
        /// A handle to the destination file
        /// </param>
        /// <param name="lpData">
        /// Argument passed to CopyProgressRoutine by <see cref="CopyFileEx"/>, <see cref="MoveFileTransacted"/>, or <see cref="MoveFileWithProgress"/>.
        /// </param>
        /// <returns>
        /// The CopyProgressRoutine function should return one of the following values.
        /// <see cref="PROGRESS_CANCEL"/>, <see cref="PROGRESS_CONTINUE"/>, <see cref="PROGRESS_QUIET"/>, <see cref="PROGRESS_STOP"/>
        /// </returns>
        /// <remarks>
        /// An application can use this information to display a progress bar that shows the total number of bytes copied as a percent of the total file size.
        /// </remarks>
        public delegate LPPROGRESS_ROUTINEResults LpprogressRoutine([In] LARGE_INTEGER TotalFileSize, [In] LARGE_INTEGER TotalBytesTransferred, [In] LARGE_INTEGER StreamSize,
            [In] LARGE_INTEGER StreamBytesTransferred, [In] DWORD dwStreamNumber, [In] LPPROGRESS_ROUTINECallbackReasons dwCallbackReason, [In] HANDLE hSourceFile,
            [In] HANDLE hDestinationFile, [In] LPVOID lpData);

        /// <summary>
        /// <para>
        /// An application-defined callback function used with the <see cref="CopyFile2"/> function.
        /// It is called when a portion of a copy or move operation is completed.
        /// The <see cref="PCOPYFILE2_PROGRESS_ROUTINE"/> type defines a pointer to this callback function.
        /// CopyFile2ProgressRoutine is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/en-us/windows/win32/api/winbase/nc-winbase-pcopyfile2_progress_routine"/>
        /// </para>
        /// </summary>
        /// <param name="pMessage">
        /// Pointer to a <see cref="COPYFILE2_MESSAGE"/> structure.
        /// </param>
        /// <param name="pvCallbackContext">
        /// Copy of value passed in the <see cref="COPYFILE2_EXTENDED_PARAMETERS.pvCallbackContext"/> member
        /// of the <see cref="COPYFILE2_EXTENDED_PARAMETERS"/> structure passed to <see cref="CopyFile2"/>.
        /// </param>
        /// <remarks>
        /// The <see cref="COPYFILE2_CALLBACK_STREAM_FINISHED"/> message is the last message for a paused copy.
        /// If <see cref="COPYFILE2_PROGRESS_PAUSE"/> is returned in response to a <see cref="COPYFILE2_CALLBACK_STREAM_FINISHED"/> message
        /// then no further callbacks will be sent.
        /// </remarks>
        public delegate COPYFILE2_MESSAGE_ACTION Pcopyfile2ProgressRoutine([In] COPYFILE2_MESSAGE pMessage, [In] PVOID pvCallbackContext);


        /// <summary>
        /// <para>
        /// Compares two file times.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-comparefiletime"/>
        /// </para>
        /// </summary>
        /// <param name="lpFileTime1">
        /// A pointer to a <see cref="FILETIME"/> structure that specifies the first file time.
        /// </param>
        /// <param name="lpFileTime2">
        /// A pointer to a <see cref="FILETIME"/> structure that specifies the second file time.
        /// </param>
        /// <returns>
        /// The return value is one of the following values.
        /// -1: First file time is earlier than second file time.
        /// 0:  First file time is equal to second file time.
        /// 1:  First file time is later than second file time.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CompareFileTime", ExactSpelling = true, SetLastError = true)]
        public static extern LONG CompareFileTime([In] in FILETIME lpFileTime1, [In] in FILETIME lpFileTime2);

        /// <summary>
        /// <para>
        /// Copies an existing file to a new file.
        /// The <see cref="CopyFileEx"/> function provides two additional capabilities.
        /// <see cref="CopyFileEx"/> can call a specified callback function each time a portion of the copy operation is completed,
        /// and <see cref="CopyFileEx"/> can be canceled during the copy operation.
        /// To perform this operation as a transacted operation, use the <see cref="CopyFileTransacted"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-copyfilew"/>
        /// </para>
        /// </summary>
        /// <param name="lpExistingFileName">
        /// The name of an existing file.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File.
        /// Tip
        /// Starting with Windows 10, version 1607, for the unicode version of this function (CopyFileW),
        /// you can opt-in to remove the <see cref="MAX_PATH"/> limitation without prepending "\\?\".
        /// See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// If <paramref name="lpExistingFileName"/> does not exist, <see cref="CopyFile"/> fails,
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_FILE_NOT_FOUND"/>.
        /// </param>
        /// <param name="lpNewFileName">
        /// The name of the new file.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File.
        /// Tip
        /// Starting with Windows 10, version 1607, for the unicode version of this function (CopyFileW),
        /// you can opt-in to remove the <see cref="MAX_PATH"/> limitation without prepending "\\?\".
        /// See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// </param>
        /// <param name="bFailIfExists">
        /// If this parameter is <see cref="TRUE"/> and the new file specified by <paramref name="lpNewFileName"/> already exists, the function fails.
        /// If this parameter is <see cref="FALSE"/> and the new file already exists, the function overwrites the existing file and succeeds.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The security resource properties (ATTRIBUTE_SECURITY_INFORMATION) for the existing file are copied to the new file.
        /// Windows 7, Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// Security resource properties for the existing file are not copied to the new file until Windows 8 and Windows Server 2012.
        /// File attributes for the existing file are copied to the new file.
        /// For example, if an existing file has the <see cref="FILE_ATTRIBUTE_READONLY"/> file attribute,
        /// a copy created through a call to <see cref="CopyFile"/> will also have the <see cref="FILE_ATTRIBUTE_READONLY"/> file attribute.
        /// For more information, see Retrieving and Changing File Attributes.
        /// This function fails with ERROR_ACCESS_DENIED if the destination file already exists
        /// and has the <see cref="FILE_ATTRIBUTE_HIDDEN"/> or <see cref="FILE_ATTRIBUTE_READONLY"/> attribute set.
        /// When <see cref="CopyFile"/> is used to copy an encrypted file,
        /// it attempts to encrypt the destination file with the keys used in the encryption of the source file.
        /// If this cannot be done, this function attempts to encrypt the destination file with default keys.
        /// If neither of these methods can be done, CopyFile fails with an <see cref="ERROR_ENCRYPTION_FAILED"/> error code.
        /// Symbolic link behavior—If the source file is a symbolic link, the actual file copied is the target of the symbolic link.
        /// If the destination file already exists and is a symbolic link, the target of the symbolic link is overwritten by the source file
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CopyFileW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CopyFile([In] LPCWSTR lpExistingFileName, [In] LPCWSTR lpNewFileName, [In] BOOL bFailIfExists);

        /// <summary>
        /// <para>
        /// Copies an existing file to a new file, notifying the application of its progress through a callback function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-copyfile2"/>
        /// </para>
        /// </summary>
        /// <param name="pwszExistingFileName">
        /// The name of an existing file.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File.
        /// Tip
        /// Starting with Windows 10, version 1607, for the unicode version of this function (CopyFileW),
        /// you can opt-in to remove the <see cref="MAX_PATH"/> limitation without prepending "\\?\".
        /// See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// If <paramref name="pwszExistingFileName"/> does not exist, <see cref="CopyFile2"/> fails
        /// returns <code>HRESULT_FROM_WIN32(ERROR_FILE_NOT_FOUND)</code>.
        /// </param>
        /// <param name="pwszNewFileName">
        /// The name of the new file.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File.
        /// Tip
        /// Starting with Windows 10, version 1607, for the unicode version of this function (CopyFileW),
        /// you can opt-in to remove the <see cref="MAX_PATH"/> limitation without prepending "\\?\".
        /// See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// </param>
        /// <param name="pExtendedParameters">
        /// Optional address of a <see cref="COPYFILE2_EXTENDED_PARAMETERS"/> structure.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value will return <see cref="TRUE"/> when passed to the <see cref="SUCCEEDED"/> macro.
        /// <see cref="S_OK"/>: The copy operation completed successfully.
        /// <code>HRESULT_FROM_WIN32(ERROR_REQUEST_PAUSED)</code>:
        /// The copy operation was paused by a <see cref="COPYFILE2_PROGRESS_PAUSE"/> return from the <see cref="CopyFile2ProgressRoutine"/> callback function.
        /// <code>HRESULT_FROM_WIN32(ERROR_REQUEST_ABORTED)</code>:
        /// The copy operation was paused by a <see cref="COPYFILE2_PROGRESS_CANCEL"/> or <see cref="COPYFILE2_PROGRESS_STOP"/>
        /// return from the CopyFile2ProgressRoutine callback function.
        /// <code>HRESULT_FROM_WIN32(ERROR_ALREADY_EXISTS)</code>:
        /// The <see cref="COPYFILE2_EXTENDED_PARAMETERS.dwCopyFlags"/> member of the <see cref="COPYFILE2_EXTENDED_PARAMETERS"/> structure passed
        /// through the <paramref name="pExtendedParameters"/> parameter contains the <see cref="COPY_FILE_FAIL_IF_EXISTS"/> flag and a conflicting name existed.
        /// <code>HRESULT_FROM_WIN32(ERROR_FILE_EXISTS)</code>:
        /// The <see cref="COPYFILE2_EXTENDED_PARAMETERS.dwCopyFlags"/> member of the <see cref="COPYFILE2_EXTENDED_PARAMETERS"/> structure passed
        /// through the <paramref name="pExtendedParameters"/> parameter contains the <see cref="COPY_FILE_FAIL_IF_EXISTS"/> flag and a conflicting name existed.
        /// </returns>
        /// <remarks>
        /// This function preserves extended attributes, OLE structured storage, NTFS file system alternate data streams, and file attributes.
        /// Security attributes for the existing file are not copied to the new file.
        /// To copy security attributes, use the <see cref="SHFileOperation"/> function.
        /// This function fails with <code>HRESULT_FROM_WIN32(ERROR_ACCESS_DENIED)</code> if the destination file already exists
        /// and has the <see cref="FILE_ATTRIBUTE_HIDDEN"/> or <see cref="FILE_ATTRIBUTE_READONLY"/> attribute set.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CopyFile2", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CopyFile2([In] LPCWSTR pwszExistingFileName, [In] LPCWSTR pwszNewFileName, [In] in COPYFILE2_EXTENDED_PARAMETERS pExtendedParameters);

        /// <summary>
        /// <para>
        /// Copies an existing file to a new file, notifying the application of its progress through a callback function.
        /// To perform this operation as a transacted operation, use the <see cref="CopyFileTransacted"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-copyfileexw"/>
        /// </para>
        /// </summary>
        /// <param name="lpExistingFileName">
        /// The name of an existing file.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File.
        /// Tip
        /// Starting with Windows 10, version 1607, for the unicode version of this function (CopyFileW),
        /// you can opt-in to remove the <see cref="MAX_PATH"/> limitation without prepending "\\?\".
        /// See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// If <paramref name="lpExistingFileName"/> does not exist, <see cref="CopyFile"/> fails,
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_FILE_NOT_FOUND"/>.
        /// </param>
        /// <param name="lpNewFileName">
        /// The name of the new file.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File.
        /// Tip
        /// Starting with Windows 10, version 1607, for the unicode version of this function (CopyFileW),
        /// you can opt-in to remove the <see cref="MAX_PATH"/> limitation without prepending "\\?\".
        /// See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
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
        /// <see cref="COPY_FILE_ALLOW_DECRYPTED_DESTINATION"/>:
        /// An attempt to copy an encrypted file will succeed even if the destination copy cannot be encrypted.
        /// <see cref="COPY_FILE_COPY_SYMLINK"/>:
        /// f the source file is a symbolic link, the destination file is also a symbolic link pointing to the same file that the source symbolic link is pointing to.
        /// Windows Server 2003 and Windows XP: This value is not supported.
        /// <see cref="COPY_FILE_FAIL_IF_EXISTS"/>:
        /// The copy operation fails immediately if the target file already exists.
        /// <see cref="COPY_FILE_NO_BUFFERING"/>:
        /// The copy operation is performed using unbuffered I/O, bypassing system I/O cache resources.
        /// Recommended for very large file transfers.
        /// Windows Server 2003 and Windows XP: This value is not supported.
        /// <see cref="COPY_FILE_OPEN_SOURCE_FOR_WRITE"/>:
        /// The file is copied and the original file is opened for write access.
        /// <see cref="COPY_FILE_RESTARTABLE"/>:
        /// Progress of the copy is tracked in the target file in case the copy fails.
        /// The failed copy can be restarted at a later time by specifying the same values
        /// for <paramref name="lpExistingFileName"/> and <paramref name="lpNewFileName"/> as those used in the call that failed.
        /// This can significantly slow down the copy operation as the new file may be flushed multiple times during the copy operation.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>. To get extended error information call <see cref="GetLastError"/>.
        /// If <paramref name="lpProgressRoutine"/> returns <see cref="PROGRESS_CANCEL"/> due to the user canceling the operation,
        /// <see cref="CopyFileEx"/> will return <see cref="FALSE"/> and <see cref="GetLastError"/> will return <see cref="ERROR_REQUEST_ABORTED"/>.
        /// In this case, the partially copied destination file is deleted.
        /// If <paramref name="lpProgressRoutine"/> returns <see cref="PROGRESS_STOP"/> due to the user stopping the operation,
        /// <see cref="CopyFileEx"/> will return <see cref="FALSE"/> and <see cref="GetLastError"/> will return <see cref="ERROR_REQUEST_ABORTED"/>.
        /// In this case, the partially copied destination file is left intact.
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
        /// Windows 7, Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// If you are writing an application that is optimizing file copy operations across a LAN,
        /// consider using the <see cref="TransmitFile"/> function from Windows Sockets (Winsock).
        /// <see cref="TransmitFile"/> supports high-performance network transfers and provides a simple interface to send the contents of a file to a remote computer.
        /// To use <see cref="TransmitFile"/>, you must write a Winsock client application that sends the file from the source computer
        /// as well as a Winsock server application that uses other Winsock functions to receive the file on the remote computer.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CopyFileExW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CopyFileEx([In] LPCWSTR lpExistingFileName, [In] LPCWSTR lpNewFileName, [In] LPPROGRESS_ROUTINE lpProgressRoutine,
            [In] LPVOID lpData, [In] LP<BOOL> pbCancel, [In] CopyFileFlags dwCopyFlags);

        /// <summary>
        /// <para>
        /// Creates a new directory.
        /// If the underlying file system supports security on files and directories,
        /// the function applies a specified security descriptor to the new directory.
        /// To specify a template directory, use the <see cref="CreateDirectoryEx"/> function.
        /// To perform this operation as a transacted operation, use the <see cref="CreateDirectoryTransacted"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-createdirectory"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDirectoryW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CreateDirectory([In] LPCWSTR lpPathName, [In] in SECURITY_ATTRIBUTES lpSecurityAttributes);

        /// <summary>
        /// <para>
        /// Creates a new directory with the attributes of a specified template directory.
        /// If the underlying file system supports security on files and directories,
        /// the function applies a specified security descriptor to the new directory.
        /// The new directory retains the other attributes of the specified template directory.
        /// To perform this operation as a transacted operation, use the <see cref="CreateDirectoryTransacted"/> function.
        /// </para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-createdirectoryexw"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDirectoryExW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CreateDirectoryEx([In] LPCWSTR lpTemplateDirectory, [In] LPCWSTR lpNewDirectory, [In] in SECURITY_ATTRIBUTES lpSecurityAttributes);

        /// <summary>
        /// <para>
        /// Establishes a hard link between an existing file and a new file.
        /// This function is only supported on the NTFS file system, and only for files, not directories.
        /// To perform this operation as a transacted operation, use the <see cref="CreateHardLinkTransacted"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-createhardlinkw"/>
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// The name of the new file.
        /// This parameter may include the path but cannot specify the name of a directory.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\\?\" to the path.
        /// For more information, see Naming a File.
        /// If you pass a name longer than MAX_PATH characters to the ANSI version of this function
        /// or to the Unicode version of this function without prepending "\\?\" to the path, the function returns <see cref="ERROR_PATH_NOT_FOUND"/>.
        /// Tip  Starting with Windows 10, version 1607, for the unicode version of this function (CreateHardLinkW),
        /// you can opt-in to remove the MAX_PATH limitation without prepending "\\?\".
        /// See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// </param>
        /// <param name="lpExistingFileName">
        /// The name of the existing file.
        /// This parameter may include the path cannot specify the name of a directory.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\\?\" to the path.
        /// For more information, see Naming a File.
        /// If you pass a name longer than MAX_PATH characters to the ANSI version of this function
        /// or to the Unicode version of this function without prepending "\\?\" to the path, the function returns <see cref="ERROR_PATH_NOT_FOUND"/>.
        /// Tip  Starting with Windows 10, version 1607, for the unicode version of this function (CreateHardLinkW),
        /// you can opt-in to remove the MAX_PATH limitation without prepending "\\?\".
        /// See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// </param>
        /// <param name="lpSecurityAttributes">
        /// Reserved; must be <see cref="NULL"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// The maximum number of hard links that can be created with this function is 1023 per file.
        /// If more than 1023 links are created for a file, an error results.
        /// If you pass a name longer than <see cref="MAX_PATH"/> characters to
        /// the <paramref name="lpFileName"/> or <paramref name="lpExistingFileName"/> parameter of the ANSI version of this function
        /// or to the Unicode version of this function without prepending "\\?\" to the path, the function returns <see cref="ERROR_PATH_NOT_FOUND"/>.
        /// </returns>
        /// <remarks>
        /// Any directory entry for a file that is created with <see cref="CreateFile"/> or <see cref="CreateHardLink"/> is a hard link to an associated file.
        /// An additional hard link that is created with the <see cref="CreateHardLink"/> function allows you to have multiple directory entries for a file,
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
        /// Use <see cref="DeleteFile"/> to delete hard links.
        /// You can delete them in any order regardless of the order in which they are created.
        /// Flags, attributes, access, and sharing that are specified in CreateFile operate on a per-file basis.
        /// That is, if you open a file that does not allow sharing, another application cannot share the file by creating a new hard link to the file.
        /// When you create a hard link on the NTFS file system, the file attribute information
        /// in the directory entry is refreshed only when the file is opened, or when <see cref="GetFileInformationByHandle"/> is called with the handle of a specific file.
        /// Symbolic link behavior—If the path points to a symbolic link, the function creates a hard link to the target.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateHardLinkW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CreateHardLink([In] LPCWSTR lpFileName, [In] LPCWSTR lpExistingFileName, [In] IntPtr lpSecurityAttributes);

        /// <summary>
        /// <para>
        /// Creates a symbolic link.
        /// To perform this operation as a transacted operation, use the <see cref="CreateSymbolicLinkTransacted"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-createsymboliclinkw"/>
        /// </para>
        /// </summary>
        /// <param name="lpSymlinkFileName">
        /// The symbolic link to be created.
        /// This parameter may include the path.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\\?\" to the path.
        /// For more information, see Naming a File.
        /// Tip  Starting with Windows 10, version 1607, for the unicode version of this function (CreateSymbolicLinkW),
        /// you can opt-in to remove the MAX_PATH limitation without prepending "\\?\".
        /// See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// </param>
        /// <param name="lpTargetFileName">
        /// The name of the target for the symbolic link to be created.
        /// If lpTargetFileName has a device name associated with it, the link is treated as an absolute link; otherwise, the link is treated as a relative link.
        /// This parameter may include the path.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\\?\" to the path.
        /// For more information, see Naming a File.
        /// Tip  Starting with Windows 10, version 1607, for the unicode version of this function (CreateSymbolicLinkW),
        /// you can opt-in to remove the MAX_PATH limitation without prepending "\\?\".
        /// See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// </param>
        /// <param name="dwFlags">
        /// Indicates whether the link target, <paramref name="lpTargetFileName"/>, is a directory.
        /// 0x0:
        /// The link target is a file.
        /// <see cref="SYMBOLIC_LINK_FLAG_DIRECTORY"/>:
        /// The link target is a directory.
        /// <see cref="SYMBOLIC_LINK_FLAG_ALLOW_UNPRIVILEGED_CREATE"/>:
        /// Specify this flag to allow creation of symbolic links when the process is not elevated.
        /// Developer Mode must first be enabled on the machine before this option will function.
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
        /// To remove a symbolic link, delete the file (using <see cref="DeleteFile"/> or similar APIs)
        /// or remove the directory (using <see cref="RemoveDirectory"/> or similar APIs) depending on what type of symbolic link is used.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateSymbolicLinkW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOLEAN CreateSymbolicLink([In] LPCWSTR lpSymlinkFileName, [In] LPCWSTR lpTargetFileName, [In] DWORD dwFlags);

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
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-createfilew"/>
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
        /// Appropriate security checks still apply when this flag is used without SE_BACKUP_NAME and SE_RESTORE_NAME privileges.
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateFileW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE CreateFile([In] LPCWSTR lpFileName, [In] ACCESS_MASK dwDesiredAccess, [In] FileShareModes dwShareMode,
            [In] in SECURITY_ATTRIBUTES lpSecurityAttributes, [In] FileCreationDispositions dwCreationDisposition,
            [In] uint dwFlagsAndAttributes, [In] HANDLE hTemplateFile);

        /// <summary>
        /// <para>
        /// Creates or opens a file or I/O device.
        /// The most commonly used I/O devices are as follows: file, file stream, directory, physical disk, volume, console buffer,
        /// tape drive, communications resource, mailslot, and pipe.
        /// The function returns a handle that can be used to access the file or device for various types of I/O
        /// depending on the file or device and the flags and attributes specified.
        /// When called from a Windows Store app, <see cref="CreateFile2"/> is simplified.
        /// You can open only files or directories inside the ApplicationData.LocalFolder or Package.InstalledLocation directories.
        /// You can't open named pipes or mailslots or create encrypted files (<see cref="FILE_ATTRIBUTE_ENCRYPTED"/>).
        /// Note
        /// We refer here to the app's local folder and the package's installed location, not additional packages in the package graph, like resource packages.
        /// <see cref="CreateFile2"/> doesn't support opening files in additional packages in the package graph.
        /// For example, suppose an app has a dependency on WinJS.
        /// The app can call <see cref="CreateFile2"/> to open a file in its package but not in the WinJS package.
        /// To perform this operation as a transacted operation, which results in a handle
        /// that can be used for transacted I/O, use the <see cref="CreateFileTransacted"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-createfile2"/>
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// The name of the file or device to be created or opened.
        /// For information on special device names, see Defining an MS-DOS Device Name.
        /// To create a file stream, specify the name of the file, a colon, and then the name of the stream.
        /// For more information, see File Streams.
        /// Tip
        /// Starting with Windows 10, version 1607, you can opt-in to remove the <see cref="MAX_PATH"/> limitation without prepending "\\?\".
        /// See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// The requested access to the file or device, which can be summarized as read, write, both or neither zero).
        /// The most commonly used values are <see cref="GENERIC_READ"/>, <see cref="GENERIC_WRITE"/>, or both <code>(GENERIC_READ | GENERIC_WRITE)</code>.
        /// For more information, see Generic Access Rights, File Security and Access Rights, File Access Rights Constants, and ACCESS_MASK.
        /// If this parameter is zero, the application can query certain metadata such as file, directory, or device attributes
        /// without accessing that file or device, even if <see cref="GENERIC_READ"/> access would have been denied.
        /// You cannot request an access mode that conflicts with the sharing mode that is specified by the <paramref name="dwShareMode"/> parameter
        /// in an open request that already has an open handle.
        /// For more information, see the Remarks section of this topic and Creating and Opening Files.
        /// </param>
        /// <param name="dwShareMode">
        /// The requested sharing mode of the file or device, which can be read, write, both, delete, all of these, or none (refer to the following table).
        /// Access requests to attributes or extended attributes are not affected by this flag.
        /// If this parameter is zero and <see cref="CreateFile2"/> succeeds,
        /// the file or device cannot be shared and cannot be opened again until the handle to the file or device is closed.
        /// For more information, see the Remarks section.
        /// You cannot request a sharing mode that conflicts with the access mode that is specified in an existing request that has an open handle.
        /// <see cref="CreateFile2"/> would fail and the <see cref="GetLastError"/> function would return <see cref="ERROR_SHARING_VIOLATION"/>.
        /// To enable a process to share a file or device while another process has the file or device open,
        /// use a compatible combination of one or more of the following values.
        /// For more information about valid combinations of this parameter with the <paramref name="dwDesiredAccess"/> parameter, see Creating and Opening Files.
        /// Note
        /// The sharing options for each open handle remain in effect until that handle is closed, regardless of process context.
        /// 0, <see cref="FILE_SHARE_DELETE"/>, <see cref="FILE_SHARE_READ"/>, <see cref="FILE_SHARE_WRITE"/>
        /// </param>
        /// <param name="dwCreationDisposition">
        /// An action to take on a file or device that exists or does not exist.
        /// For devices other than files, this parameter is usually set to <see cref="OPEN_EXISTING"/>.
        /// For more information, see the Remarks section.
        /// This parameter must be one of the following values, which cannot be combined:
        /// <see cref="CREATE_ALWAYS"/>, <see cref="CREATE_NEW"/>, <see cref="OPEN_ALWAYS"/>, <see cref="OPEN_EXISTING"/>, <see cref="TRUNCATE_EXISTING"/>
        /// </param>
        /// <param name="pCreateExParams">
        /// Pointer to an optional <see cref="CREATEFILE2_EXTENDED_PARAMETERS"/> structure.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is an open handle to the specified file, device, named pipe, or mail slot.
        /// If the function fails, the return value is <see cref="INVALID_HANDLE_VALUE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// To compile an application that uses the <see cref="CreateFile2"/> function, define the _WIN32_WINNT macro as 0x0602 or later.
        /// For more information, see Using the Windows Headers.
        /// <see cref="CreateFile2"/> supports file interaction and most other types of I/O devices and mechanisms available to Windows developers.
        /// This section attempts to cover the varied issues developers may experience
        /// when using <see cref="CreateFile2"/> in different contexts and with different I/O types.
        /// The text attempts to use the word file only when referring specifically to data stored in an actual file on a file system.
        /// However, some uses of file may be referring more generally to an I/O object that supports file-like mechanisms.
        /// This liberal use of the term file is particularly prevalent in constant names and parameter names because of the previously mentioned historical reasons.
        /// When an application is finished using the object handle returned by <see cref="CreateFile2"/>,
        /// use the <see cref="CloseHandle"/> function to close the handle.
        /// This not only frees up system resources, but can have wider influence on things like sharing the file or device and committing data to disk.
        /// Specifics are noted within this topic as appropriate.
        /// Some file systems, such as the NTFS file system, support compression or encryption for individual files and directories.
        /// On volumes that have a mounted file system with this support, a new file inherits the compression and encryption attributes of its directory.
        /// You cannot use <see cref="CreateFile2"/> to control compression, decompression, or decryption on a file or directory.
        /// For more information, see Creating and Opening Files, File Compression and Decompression, and File Encryption.
        /// If the <see cref="CREATEFILE2_EXTENDED_PARAMETERS.lpSecurityAttributes"/> member of the <see cref="CREATEFILE2_EXTENDED_PARAMETERS"/> structure
        /// passed in the <paramref name="pCreateExParams"/> parameter is <see cref="NULL"/>,
        /// the handle returned by <see cref="CreateFile2"/> cannot be inherited by any child processes your application may create.
        /// The following information regarding this member also applies:
        /// If the <see cref="SECURITY_ATTRIBUTES.bInheritHandle"/> member variable is not <see cref="FALSE"/>,
        /// which is any nonzero value, then the handle can be inherited.
        /// Therefore it is critical this structure member be properly initialized to <see cref="FALSE"/> if you do not intend the handle to be inheritable.
        /// The access control lists (ACL) in the default security descriptor for a file or directory are inherited from its parent directory.
        /// The target file system must support security on files and directories for the <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member
        /// to have an effect on them, which can be determined by using <see cref="GetVolumeInformation"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateFile2", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE CreateFile2([In] LPCWSTR lpFileName, [In] ACCESS_MASK dwDesiredAccess,
             [In] FileShareModes dwShareMode, [In] FileCreationDispositions dwCreationDisposition, [In] in CREATEFILE2_EXTENDED_PARAMETERS pCreateExParams);

        /// <summary>
        /// <para>
        /// Decrypts an encrypted file or directory.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-decryptfilew"/>
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// The name of the file or directory to be decrypted.
        /// The caller must have the <see cref="FILE_READ_DATA"/>, <see cref="FILE_WRITE_DATA"/>, <see cref="FILE_READ_ATTRIBUTES"/>,
        /// <see cref="FILE_WRITE_ATTRIBUTES"/>, and <see cref="SYNCHRONIZE"/> access rights.
        /// For more information, see File Security and Access Rights.
        /// </param>
        /// <param name="dwReserved">
        /// Reserved; must be zero.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="DecryptFile"/> function requires exclusive access to the file being decrypted,
        /// and will fail if another process is using the file.
        /// If the file is not encrypted, <see cref="DecryptFile"/> simply returns a <see cref="TRUE"/> value, which indicates success.
        /// If <paramref name="lpFileName"/> specifies a read-only file,
        /// the function fails and <see cref="GetLastError"/> returns <see cref="ERROR_FILE_READ_ONLY"/>.
        /// If <paramref name="lpFileName"/> specifies a directory that contains a read-only file,
        /// the functions succeeds but the directory is not decrypted.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DecryptFileW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DecryptFile([In] LPCWSTR lpFileName, [In] DWORD dwReserved);

        /// <summary>
        /// <para>
        /// Defines, redefines, or deletes MS-DOS device names.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-definedosdevicew"/>
        /// </para>
        /// </summary>
        /// <param name="dwFlags">
        /// The controllable aspects of the <see cref="DefineDosDevice"/> function.
        /// This parameter can be one or more of the following values.
        /// <see cref="DDD_EXACT_MATCH_ON_REMOVE"/>, <see cref="DDD_NO_BROADCAST_SYSTEM"/>,
        /// <see cref="DDD_RAW_TARGET_PATH"/>, <see cref="DDD_REMOVE_DEFINITION"/>
        /// </param>
        /// <param name="lpDeviceName">
        /// A pointer to an MS-DOS device name string specifying the device the function is defining, redefining, or deleting.
        /// The device name string must not have a colon as the last character, unless a drive letter is being defined, redefined, or deleted.
        /// For example, drive C would be the string "C:". In no case is a trailing backslash ("") allowed.
        /// </param>
        /// <param name="lpTargetPath">
        /// A pointer to a path string that will implement this device.
        /// The string is an MS-DOS path string unless the <see cref="DDD_RAW_TARGET_PATH"/> flag is specified, in which case this string is a path string.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// MS-DOS device names are stored as junctions in the object namespace.
        /// The code that converts an MS-DOS path into a corresponding path uses these junctions to map MS-DOS devices and drive letters.
        /// The <see cref="DefineDosDevice"/> function enables an application to modify the junctions used to implement the MS-DOS device namespace.
        /// To retrieve the current mapping for a particular MS-DOS device name or to obtain a list of all MS-DOS devices
        /// known to the system, use the <see cref="QueryDosDevice"/> function.
        /// To define a drive letter assignment that is persistent across boots and not a network share, use the <see cref="SetVolumeMountPoint"/> function.
        /// If the volume to be mounted already has a drive letter assigned to it, use the <see cref="DeleteVolumeMountPoint"/> function to remove the assignment.
        /// Drive letters and device names defined at system boot time are protected from redefinition and deletion unless the user is an administrator.
        /// Starting with Windows XP, this function creates a device name for a caller that is not running in the "LocalSystem" context in its own Local MS-DOS device namespace.
        /// If the caller is running in the "LocalSystem" context, the function creates the device name in the Global MS-DOS device namespace.
        /// For more information, see Defining an MS DOS Device Name and File Names, Paths, and Namespaces.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DefineDosDeviceW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DefineDosDevice([In] DefineDosDeviceFlags dwFlags, [In] LPCWSTR lpDeviceName, [In] LPCWSTR lpTargetPath);

        /// <summary>
        /// <para>
        /// Deletes an existing file.
        /// To perform this operation as a transacted operation, use the <see cref="DeleteFileTransacted"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-deletefilew"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteFileW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DeleteFile([In] LPCWSTR lpFileName);

        /// <summary>
        /// <para>
        /// Deletes a drive letter or mounted folder.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-deletevolumemountpointw"/>
        /// </para>
        /// </summary>
        /// <param name="lpszVolumeMountPoint">
        /// The drive letter or mounted folder to be deleted.
        /// A trailing backslash is required, for example, "X:" or "Y:\MountX".
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Deleting a mounted folder does not cause the underlying directory to be deleted.
        /// If the <paramref name="lpszVolumeMountPoint"/> parameter is a directory that is not a mounted folder, the function does nothing.
        /// The directory is not deleted.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteVolumeMountPointW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DeleteVolumeMountPoint([In] LPCWSTR lpszVolumeMountPoint);

        /// <summary>
        /// <para>
        /// Encrypts a file or directory. All data streams in a file are encrypted. All new files created in an encrypted directory are encrypted.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-encryptfilew"/>
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// The name of the file or directory to be encrypted.
        /// The caller must have the <see cref="FILE_READ_DATA"/>, <see cref="FILE_WRITE_DATA"/>, <see cref="FILE_READ_ATTRIBUTES"/>,
        /// <see cref="FILE_WRITE_ATTRIBUTES"/>, and <see cref="SYNCHRONIZE"/> access rights.
        /// For more information, see File Security and Access Rights.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="EncryptFile"/> function requires exclusive access to the file being encrypted,
        /// and will fail if another process is using the file.
        /// If the file is already encrypted, <see cref="EncryptFile"/> simply returns a nonzero value, which indicates success.
        /// If the file is compressed, <see cref="EncryptFile"/> will decompress the file before encrypting it.
        /// If <paramref name="lpFileName"/> specifies a read-only file,
        /// the function fails and <see cref="GetLastError"/> returns <see cref="ERROR_FILE_READ_ONLY"/>.
        /// If <paramref name="lpFileName"/> specifies a directory that contains a read-only file,
        /// the functions succeeds but the directory is not encrypted.
        /// To decrypt an encrypted file, use the <see cref="DecryptFile"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "EncryptFileW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EncryptFile([MarshalAs(UnmanagedType.LPWStr)][In] string lpFileName);

        /// <summary>
        /// <para>
        /// Closes a file search handle opened by the <see cref="FindFirstFile"/>, <see cref="FindFirstFileEx"/>,
        /// <see cref="FindFirstFileNameW"/>, <see cref="FindFirstFileNameTransactedW"/>, <see cref="FindFirstFileTransacted"/>,
        /// <see cref="FindFirstStreamTransactedW"/>, or <see cref="FindFirstStreamW"/> functions.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-findclose"/>
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
        /// by the <paramref name="hFindFile"/> parameter cannot be used in subsequent calls to the <see cref="FindNextFile"/>,
        /// <see cref="FindNextFileNameW"/>, <see cref="FindNextStreamW"/>, or <see cref="FindClose"/> functions.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindClose", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL FindClose([In] HANDLE hFindFile);

        /// <summary>
        /// <para>
        /// Stops change notification handle monitoring.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-findclosechangenotification"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindCloseChangeNotification", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL FindCloseChangeNotification([In] HANDLE hChangeHandle);

        /// <summary>
        /// <para>
        /// Creates a change notification handle and sets up initial change notification filter conditions.
        /// A wait on a notification handle succeeds when a change matching the filter conditions occurs in the specified directory or subtree.
        /// The function does not report changes to the specified directory itself.
        /// This function does not indicate the change that satisfied the wait condition.
        /// To retrieve information about the specific change as part of the notification, use the <see cref="ReadDirectoryChangesW"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-findfirstchangenotificationw"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindFirstChangeNotificationW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE FindFirstChangeNotification([In] LPCWSTR lpPathName, [In] BOOL bWatchSubtree, [In] FileNotifyFilters dwNotifyFilter);

        /// <summary>
        /// <para>
        /// Searches a directory for a file or subdirectory with a name that matches a specific name (or partial name if wildcards are used).
        /// To specify additional attributes to use in a search, use the <see cref="FindFirstFileEx"/> function.
        /// To perform this operation as a transacted operation, use the <see cref="FindFirstFileTransacted"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-findfirstfilew"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindFirstFileW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE FindFirstFile([MarshalAs(UnmanagedType.LPWStr)][In] string lpFileName, [Out] out WIN32_FIND_DATA lpFindFileData);

        /// <summary>
        /// <para>
        /// Searches a directory for a file or subdirectory with a name and attributes that match those specified.
        /// For the most basic version of this function, see <see cref="FindFirstFile"/>.
        /// To perform this operation as a transacted operation, use the <see cref="FindFirstFileTransacted"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-findfirstfileexw"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindFirstFileExW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE FindFirstFileEx([In] LPCWSTR lpFileName, [In] FINDEX_INFO_LEVELS fInfoLevelId,
            [In] LPVOID lpFindFileData, [In] FINDEX_SEARCH_OPS fSearchOp, [In] LPVOID lpSearchFilter, [In] FindFirstFileExFlags dwAdditionalFlags);

        /// <summary>
        /// <para>
        /// Creates an enumeration of all the hard links to the specified file.
        /// The <see cref="FindFirstFileNameW"/> function returns a handle to the enumeration that can be used
        /// on subsequent calls to the <see cref="FindNextFileNameW"/> function.
        /// To perform this operation as a transacted operation, use the <see cref="FindFirstFileNameTransactedW"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-findfirstfilenamew"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindFirstFileNameW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE FindFirstFileNameW([In] LPCWSTR lpFileName, [In] DWORD dwFlags, [In][Out] ref DWORD StringLength, [In] IntPtr LinkName);

        /// <summary>
        /// <para>
        /// Enumerates the first stream with a ::$DATA stream type in the specified file or directory.
        /// To perform this operation as a transacted operation, use the <see cref="FindFirstStreamTransactedW"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-findfirststreamw"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindFirstStreamTransactedW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE FindFirstStreamW([In] LPCWSTR lpFileName, [In] STREAM_INFO_LEVELS InfoLevel, [In] LPVOID lpFindStreamData, [In] DWORD dwFlags);

        /// <summary>
        /// <para>
        /// Retrieves the name of a volume on a computer.
        /// <see cref="FindFirstVolume"/> is used to begin scanning the volumes of a computer.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-findfirstvolumew"/>
        /// </para>
        /// </summary>
        /// <param name="lpszVolumeName">
        /// A pointer to a buffer that receives a null-terminated string that specifies a volume GUID path for the first volume that is found.
        /// </param>
        /// <param name="cchBufferLength">
        /// The length of the buffer to receive the volume GUID path, in TCHARs.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a search handle used in a subsequent call
        /// to the <see cref="FindNextVolume"/> and <see cref="FindVolumeClose"/> functions.
        /// If the function fails to find any volumes, the return value is the <see cref="INVALID_HANDLE_VALUE"/> error code.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="FindFirstVolume"/> function opens a volume search handle and returns information about the first volume found on a computer.
        /// After the search handle is established, you can use the <see cref="FindNextVolume"/> function to search for other volumes.
        /// When the search handle is no longer needed, close it by using the <see cref="FindVolumeClose"/> function.
        /// You should not assume any correlation between the order of the volumes
        /// that are returned by these functions and the order of the volumes that are on the computer.
        /// In particular, do not assume any correlation between volume order and drive letters as assigned by the BIOS (if any) or the Disk Administrator.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindFirstVolume", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE FindFirstVolume([In] LPWSTR lpszVolumeName, [In] DWORD cchBufferLength);

        /// <summary>
        /// <para>
        /// Retrieves the name of a mounted folder on the specified volume.
        /// <see cref="FindFirstVolumeMountPoint"/> is used to begin scanning the mounted folders on a volume.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-findfirstvolumemountpointw"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindFirstVolumeMountPointW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE FindFirstVolumeMountPoint([MarshalAs(UnmanagedType.LPWStr)][In] string lpszRootPathName,
            [In] IntPtr lpszVolumeMountPoint, [In] DWORD cchBufferLength);

        /// <summary>
        /// <para>
        /// Requests that the operating system signal a change notification handle the next time it detects an appropriate change.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-findnextchangenotification"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindNextChangeNotification", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL FindNextChangeNotification([In] HANDLE hChangeHandle);

        /// <summary>
        /// <para>
        /// Continues a file search from a previous call to the <see cref="FindFirstFile"/>,
        /// <see cref="FindFirstFileEx"/>, or <see cref="FindFirstFileTransacted"/> functions.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-findnextfilew"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindNextFileW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL FindNextFile([In] HANDLE hFindFile, [Out] out WIN32_FIND_DATA lpFindFileData);

        /// <summary>
        /// <para>
        /// Continues enumerating the hard links to a file using the handle returned by a successful call to the <see cref="FindFirstFileNameW"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-findnextfilenamew"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindNextFileNameW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL FindNextFileNameW([In] HANDLE hFindStream, [In][Out] ref DWORD StringLength, [In] IntPtr LinkName);

        /// <summary>
        /// <para>
        /// Continues a stream search started by a previous call to the <see cref="FindFirstStreamW"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-findnextstreamw"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindNextStreamW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL FindNextStreamW([In] HANDLE hFindStream, [In] LPVOID lpFindStreamData);

        /// <summary>
        /// <para>
        /// Continues a volume search started by a call to the <see cref="FindFirstVolume"/> function.
        /// <see cref="FindNextVolume"/> finds one volume per call.
        /// </para>
        /// </summary>
        /// <param name="hFindVolume">
        /// The volume search handle returned by a previous call to the <see cref="FindFirstVolume"/> function.
        /// </param>
        /// <param name="lpszVolumeName">
        /// A pointer to a string that receives the volume GUID path that is found.
        /// </param>
        /// <param name="cchBufferLength">
        /// The length of the buffer that receives the volume GUID path, in TCHARs.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If no matching files can be found, the <see cref="GetLastError"/> function returns the <see cref="ERROR_NO_MORE_FILES"/> error code.
        /// In that case, close the search with the <see cref="FindVolumeClose"/> function.
        /// </returns>
        /// <remarks>
        /// After the search handle is established by calling <see cref="FindFirstVolume"/>,
        /// you can use the <see cref="FindNextVolume"/> function to search for other volumes.
        /// You should not assume any correlation between the order of the volumes
        /// that are returned by these functions and the order of the volumes that are on the computer.
        /// In particular, do not assume any correlation between volume order and drive letters as assigned by the BIOS (if any) or the Disk Administrator.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindNextVolumeW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL FindNextVolume([In] HANDLE hFindVolume, [In] LPWSTR lpszVolumeName, [In] DWORD cchBufferLength);

        /// <summary>
        /// <para>
        /// Continues a mounted folder search started by a call to the <see cref="FindFirstVolumeMountPoint"/> function.
        /// <see cref="FindNextVolumeMountPoint"/> finds one mounted folder per call.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-findnextvolumemountpointw"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindNextVolumeMountPointW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL FindNextVolumeMountPoint([In] IntPtr hFindVolumeMountPoint, [In] IntPtr lpszVolumeMountPoint,
            [In] DWORD cchBufferLength);

        /// <summary>
        /// <para>
        /// Closes the specified volume search handle.
        /// The <see cref="FindFirstVolume"/> and <see cref="FindNextVolume"/> functions use this search handle to locate volumes.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-findvolumeclose"/>
        /// </para>
        /// </summary>
        /// <param name="hFindVolume">
        /// The volume search handle to be closed.
        /// This handle must have been previously opened by the <see cref="FindFirstVolume"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// After the <see cref="FindVolumeClose"/> function is called, the handle <paramref name="hFindVolume"/> cannot be used
        /// in subsequent calls to either <see cref="FindNextVolume"/> or <see cref="FindVolumeClose"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindVolumeClose", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL FindVolumeClose([In] HANDLE hFindVolume);

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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindVolumeMountPointClose", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL FindVolumeMountPointClose([In] HANDLE hFindVolumeMountPoint);

        /// <summary>
        /// <para>
        /// Flushes the buffers of a specified file and causes all buffered data to be written to a file.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-flushfilebuffers"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FlushFileBuffers", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL FlushFileBuffers([In] HANDLE hFile);

        /// <summary>
        /// <para>
        /// Retrieves the actual number of bytes of disk storage used to store a specified file.
        /// If the file is located on a volume that supports compression and the file is compressed,
        /// the value obtained is the compressed size of the specified file.
        /// If the file is located on a volume that supports sparse files and the file is a sparse file,
        /// the value obtained is the sparse size of the specified file.
        /// To perform this operation as a transacted operation, use the <see cref="GetCompressedFileSizeTransacted"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-getcompressedfilesizew"/>
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// The name of the file.
        /// Do not specify the name of a file on a nonseeking device, such as a pipe or a communications device, as its file size has no meaning.
        /// This parameter may include the path. In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\\?\" to the path.
        /// For more information, see Naming a File.
        /// Starting with Windows 10, version 1607, for the unicode version of this function (<see cref="GetCompressedFileSize"/>),
        /// you can opt-in to remove the <see cref="MAX_PATH"/> limitation without prepending "\\?\".
        /// See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// </param>
        /// <param name="lpFileSizeHigh">
        /// The high-order DWORD of the compressed file size.
        /// The function's return value is the low-order DWORD of the compressed file size.
        /// This parameter can be NULL if the high-order DWORD of the compressed file size is not needed.
        /// Files less than 4 gigabytes in size do not need the high-order DWORD.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the low-order DWORD of the actual number of bytes of disk storage
        /// used to store the specified file, and if <paramref name="lpFileSizeHigh"/> is non-NULL,
        /// the function puts the high-order DWORD of that actual value into the DWORD pointed to by that parameter.
        /// This is the compressed file size for compressed files, the actual file size for noncompressed files.
        /// If the function fails, and <paramref name="lpFileSizeHigh"/> is <see langword="null"/>, the return value is <see cref="INVALID_FILE_SIZE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If the return value is <see cref="INVALID_FILE_SIZE"/> and <paramref name="lpFileSizeHigh"/> is non-NULL,
        /// an application must call <see cref="GetLastError"/> to determine whether the function has succeeded (value is <see cref="NO_ERROR"/>)
        /// or failed (value is other than <see cref="NO_ERROR"/>).
        /// </returns>
        /// <remarks>
        /// An application can determine whether a volume is compressed by calling <see cref="GetVolumeInformation"/>,
        /// then checking the status of the <see cref="FS_VOL_IS_COMPRESSED"/> flag in the DWORD value pointed to by
        /// that function's lpFileSystemFlags parameter.
        /// If the file is not located on a volume that supports compression or sparse files, or if the file is not compressed or a sparse file,
        /// the value obtained is the actual file size, the same as the value returned by a call to <see cref="GetFileSize"/>.
        /// Symbolic link behavior—If the path points to a symbolic link, the function returns the file size of the target.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCompressedFileSizeW", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetCompressedFileSize([In] LPCWSTR lpFileName, [Out] out DWORD lpFileSizeHigh);

        /// <summary>
        /// <para>
        /// Retrieves information about the specified disk, including the amount of free space on the disk.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-getdiskfreespacew"/>
        /// </para>
        /// </summary>
        /// <param name="lpRootPathName">
        /// The root directory of the disk for which information is to be returned.
        /// If this parameter is <see langword="null"/>, the function uses the root of the current disk.
        /// If this parameter is a UNC name, it must include a trailing backslash (for example, "\\MyServer\MyShare\").
        /// Furthermore, a drive specification must have a trailing backslash (for example, "C:\").
        /// The calling application must have <see cref="FILE_LIST_DIRECTORY"/> access rights for this directory.
        /// </param>
        /// <param name="lpSectorsPerCluster">
        /// A pointer to a variable that receives the number of sectors per cluster.
        /// </param>
        /// <param name="lpBytesPerSector">
        /// A pointer to a variable that receives the number of bytes per sector.
        /// </param>
        /// <param name="lpNumberOfFreeClusters">
        /// A pointer to a variable that receives the total number of free clusters
        /// on the disk that are available to the user who is associated with the calling thread.
        /// If per-user disk quotas are in use, this value may be less than the total number of free clusters on the disk.
        /// </param>
        /// <param name="lpTotalNumberOfClusters">
        /// A pointer to a variable that receives the total number of clusters on the disk
        /// that are available to the user who is associated with the calling thread.
        /// If per-user disk quotas are in use, this value may be less than the total number of clusters on the disk.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="GetDiskFreeSpaceEx"/> function lets you avoid some of the arithmetic
        /// that is required by the <see cref="GetDiskFreeSpace"/> function.
        /// Symbolic link behavior—If the path points to a symbolic link, the operation is performed on the target.
        /// Note
        /// The fileapi.h header defines <see cref="GetDiskFreeSpace"/> as an alias which automatically
        /// selects the ANSI or Unicode version of this function based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead to mismatches
        /// that result in compilation or runtime errors.
        /// For more information, see Conventions for Function Prototypes.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDiskFreeSpaceW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetDiskFreeSpace([MarshalAs(UnmanagedType.LPWStr)][In] string lpRootPathName, [Out] out DWORD lpSectorsPerCluster,
            [Out] out DWORD lpBytesPerSector, [Out] out DWORD lpNumberOfFreeClusters, [Out] out DWORD lpTotalNumberOfClusters);

        /// <summary>
        /// <para>
        /// Retrieves information about the amount of space that is available on a disk volume,
        /// which is the total amount of space, the total amount of free space,
        /// and the total amount of free space available to the user that is associated with the calling thread.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-getdiskfreespaceexw"/>
        /// </para>
        /// </summary>
        /// <param name="lpDirectoryName">
        /// A directory on the disk.
        /// If this parameter is <see langword="null"/>, the function uses the root of the current disk.
        /// If this parameter is a UNC name, it must include a trailing backslash, for example, "\\MyServer\MyShare\".
        /// This parameter does not have to specify the root directory on a disk. The function accepts any directory on a disk.
        /// The calling application must have <see cref="FILE_LIST_DIRECTORY"/> access rights for this directory.
        /// </param>
        /// <param name="lpFreeBytesAvailableToCaller">
        /// A pointer to a variable that receives the total number of free bytes on a disk
        /// that are available to the user who is associated with the calling thread.
        /// This parameter can be <see cref="NullRef{ULARGE_INTEGER}"/>.
        /// If per-user quotas are being used, this value may be less than the total number of free bytes on a disk.
        /// </param>
        /// <param name="lpTotalNumberOfBytes">
        /// A pointer to a variable that receives the total number of bytes on a disk
        /// that are available to the user who is associated with the calling thread.
        /// This parameter can be <see cref="NullRef{ULARGE_INTEGER}"/>.
        /// If per-user quotas are being used, this value may be less than the total number of bytes on a disk.
        /// To determine the total number of bytes on a disk or volume, use <see cref="IOCTL_DISK_GET_LENGTH_INFO"/>.
        /// </param>
        /// <param name="lpTotalNumberOfFreeBytes">
        /// A pointer to a variable that receives the total number of free bytes on a disk.
        /// This parameter can be <see cref="NullRef{ULARGE_INTEGER}"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The values obtained by this function are of the type <see cref="ULARGE_INTEGER"/>.
        /// Do not truncate these values to 32 bits.
        /// The <see cref="GetDiskFreeSpaceEx"/> function returns <see cref="FALSE"/> for <paramref name="lpTotalNumberOfFreeBytes"/>
        /// and <paramref name="lpFreeBytesAvailableToCaller"/> for all CD requests unless the disk is an unwritten CD in a CD-RW drive.
        /// Symbolic link behavior—If the path points to a symbolic link, the operation is performed on the target.
        /// Note
        /// The fileapi.h header defines <see cref="GetDiskFreeSpaceEx"/> as an alias which automatically
        /// selects the ANSI or Unicode version of this function based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead to mismatches
        /// that result in compilation or runtime errors.
        /// For more information, see Conventions for Function Prototypes.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDiskFreeSpaceExW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetDiskFreeSpaceEx([In] LPCWSTR lpDirectoryName, [Out] out ULARGE_INTEGER lpFreeBytesAvailableToCaller,
            [Out] out ULARGE_INTEGER lpTotalNumberOfBytes, [Out] out ULARGE_INTEGER lpTotalNumberOfFreeBytes);

        /// <summary>
        /// <para>
        /// Determines whether a disk drive is a removable, fixed, CD-ROM, RAM disk, or network drive.
        /// To determine whether a drive is a USB-type drive,
        /// call <see cref="SetupDiGetDeviceRegistryProperty"/> and specify the <see cref="SPDRP_REMOVAL_POLICY"/> property.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-getdrivetypew"/>
        /// </para>
        /// </summary>
        /// <param name="lpRootPathName">
        /// The root directory for the drive.
        /// A trailing backslash is required.
        /// If this parameter is <see langword="null"/>, the function uses the root of the current directory.
        /// </param>
        /// <returns>
        /// The return value specifies the type of drive, which can be one of the following values.
        /// <see cref="DRIVE_UNKNOWN"/>, <see cref="DRIVE_NO_ROOT_DIR"/>, <see cref="DRIVE_REMOVABLE"/>, <see cref="DRIVE_FIXED"/>,
        /// <see cref="DRIVE_REMOTE"/>, <see cref="DRIVE_CDROM"/>, <see cref="DRIVE_RAMDISK"/>
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDriveTypeW", ExactSpelling = true, SetLastError = true)]
        public static extern DriveTypes GetDriveType([In] LPCWSTR lpRootPathName);

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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFileAttributesW", ExactSpelling = true, SetLastError = true)]
        public static extern FileAttributes GetFileAttributes([In] LPCWSTR lpFileName);

        /// <summary>
        /// <para>
        /// Retrieves attributes for a specified file or directory.
        /// To perform this operation as a transacted operation, use the <see cref="GetFileAttributesTransacted"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-getfileattributesexw"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFileAttributesExW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetFileAttributesEx([In] LPCWSTR lpFileName, [In] GET_FILEEX_INFO_LEVELS fInfoLevelId, [In] LPVOID lpFileInformation);

        /// <summary>
        /// <para>
        /// Retrieves file information for the specified file.
        /// For a more advanced version of this function, see <see cref="GetFileInformationByHandleEx"/>.
        /// To set file information using a file handle, see <see cref="SetFileInformationByHandle"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-getfileinformationbyhandle"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the file that contains the information to be retrieved.
        /// This handle should not be a pipe handle.
        /// </param>
        /// <param name="lpFileInformation">
        /// A pointer to a <see cref="BY_HANDLE_FILE_INFORMATION"/> structure that receives the file information.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/> and file information data is contained in the buffer 
        /// pointed to by the <paramref name="lpFileInformation"/> parameter.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Depending on the underlying network features of the operating system and the type of server connected to,
        /// the <see cref="GetFileInformationByHandle"/> function may fail, return partial information, or full information for the given file.
        /// You can compare the <see cref="BY_HANDLE_FILE_INFORMATION.dwVolumeSerialNumber"/> and
        /// <see cref="BY_HANDLE_FILE_INFORMATION.nFileIndexHigh"/> <see cref="BY_HANDLE_FILE_INFORMATION.nFileIndexLow"/> members
        /// returned in the <see cref="BY_HANDLE_FILE_INFORMATION"/> structure to determine if two paths map to the same target;
        /// for example, you can compare two file paths and determine if they map to the same directory.
        /// Transacted Operations
        /// If there is a transaction bound to the thread at the time of the call,
        /// then the function returns the compressed file size of the isolated file view.
        /// For more information, see About Transactional NTFS.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFileInformationByHandle", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetFileInformationByHandle([In] HANDLE hFile, [Out] out BY_HANDLE_FILE_INFORMATION lpFileInformation);

        /// <summary>
        /// <para>
        /// Retrieves file information for the specified file.
        /// For a more basic version of this function for desktop apps, see <see cref="GetFileInformationByHandle"/>.
        /// To set file information using a file handle, see <see cref="SetFileInformationByHandle"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-getfileinformationbyhandleex"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the file that contains the information to be retrieved.
        /// This handle should not be a pipe handle.
        /// </param>
        /// <param name="FileInformationClass">
        /// A <see cref="FILE_INFO_BY_HANDLE_CLASS"/> enumeration value that specifies the type of information to be retrieved.
        /// For a table of valid values, see the Remarks section.
        /// </param>
        /// <param name="lpFileInformation">
        /// A pointer to the buffer that receives the requested file information.
        /// The structure that is returned corresponds to the class that is specified by <paramref name="FileInformationClass"/>.
        /// For a table of valid structure types, see the Remarks section.
        /// </param>
        /// <param name="dwBufferSize">
        /// The size of the <paramref name="lpFileInformation"/> buffer, in bytes.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/> and file information data is contained in the buffer
        /// pointed to by the <paramref name="lpFileInformation"/> parameter.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If <paramref name="FileInformationClass"/> is <see cref="FileStreamInfo"/> and the calls succeed but no streams are returned,
        /// the error that is returned by <see cref="GetLastError"/> is <see cref="ERROR_HANDLE_EOF"/>.
        /// Certain file information classes behave slightly differently on different operating system releases.
        /// These classes are supported by the underlying drivers, and any information they return is subject to change between operating system releases.
        /// The following table shows the valid file information class types and their corresponding data structure types for use with this function.
        /// <see cref="FileBasicInfo"/>: <see cref="FILE_BASIC_INFO"/>
        /// <see cref="FileStandardInfo"/>: <see cref="FILE_STANDARD_INFO"/>
        /// <see cref="FileNameInfo"/>: <see cref="FILE_NAME_INFO"/>
        /// <see cref="FileStreamInfo"/>: <see cref="FILE_STREAM_INFO"/>
        /// <see cref="FileCompressionInfo"/>: <see cref="FILE_COMPRESSION_INFO"/>
        /// <see cref="FileAttributeTagInfo"/>: <see cref="FILE_ATTRIBUTE_TAG_INFO"/>
        /// <see cref="FileIdBothDirectoryInfo"/>: <see cref="FILE_ID_BOTH_DIR_INFO"/>
        /// <see cref="FileIdBothDirectoryRestartInfo"/>: <see cref="FILE_ID_BOTH_DIR_INFO"/>
        /// <see cref="FileRemoteProtocolInfo"/>: <see cref="FILE_REMOTE_PROTOCOL_INFO"/>
        /// <see cref="FileFullDirectoryInfo"/>: <see cref="FILE_FULL_DIR_INFO"/>
        /// <see cref="FileFullDirectoryRestartInfo"/>: <see cref="FILE_FULL_DIR_INFO"/>
        /// <see cref="FileStorageInfo"/>: <see cref="FILE_STORAGE_INFO"/>
        /// <see cref="FileAlignmentInfo"/>: <see cref="FILE_ALIGNMENT_INFO"/>
        /// <see cref="FileIdInfo"/>: <see cref="FILE_ID_INFO"/>
        /// <see cref="FileIdExtdDirectoryInfo"/>: <see cref="FILE_ID_EXTD_DIR_INFO"/>
        /// <see cref="FileIdExtdDirectoryRestartInfo"/>: <see cref="FILE_ID_EXTD_DIR_INFO"/>
        /// Transacted Operations
        /// If there is a transaction bound to the thread at the time of the call,
        /// then the function returns the compressed file size of the isolated file view.
        /// For more information, see About Transactional NTFS.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFileInformationByHandleEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetFileInformationByHandleEx([In] HANDLE hFile, [In] FILE_INFO_BY_HANDLE_CLASS FileInformationClass,
            [Out] out LPVOID lpFileInformation, [In] DWORD dwBufferSize);

        /// <summary>
        /// <para>
        /// Retrieves the size of the specified file, in bytes.
        /// It is recommended that you use <see cref="GetFileSizeEx"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-getfilesize"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the file.
        /// </param>
        /// <param name="lpFileSizeHigh">
        /// A pointer to the variable where the high-order doubleword of the file size is returned.
        /// This parameter can be <see langword="null"/> if the application does not require the high-order doubleword.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the low-order doubleword of the file size, and,
        /// if <paramref name="lpFileSizeHigh"/> is non-NULL, the function puts the high-order doubleword of the file size
        /// into the variable pointed to by that parameter.
        /// If the function fails and <paramref name="lpFileSizeHigh"/> is NULL, the return value is <see cref="INVALID_FILE_SIZE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// When <paramref name="lpFileSizeHigh"/> is NULL, the results returned for large files are ambiguous,
        /// and you will not be able to determine the actual size of the file.
        /// It is recommended that you use <see cref="GetFileSizeEx"/> instead.
        /// If the function fails and <paramref name="lpFileSizeHigh"/> is non-NULL,
        /// the return value is <see cref="INVALID_FILE_SIZE"/> and <see cref="GetLastError"/> will return a value other than <see cref="NO_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// You cannot use the <see cref="GetFileSize"/> function with a handle of a nonseeking device such as a pipe or a communications device.
        /// To determine the file type for <paramref name="hFile"/>, use the <see cref="GetFileType"/> function.
        /// The <see cref="GetFileSize"/> function retrieves the uncompressed size of a file.
        /// Use the <see cref="GetCompressedFileSize"/> function to obtain the compressed size of a file.
        /// Note that if the return value is <see cref="INVALID_FILE_SIZE"/>,
        /// an application must call <see cref="GetLastError"/> to determine whether the function has succeeded or failed.
        /// The reason the function may appear to fail when it has not is that <paramref name="lpFileSizeHigh"/> could be non-NULL
        /// or the file size could be 0xffffffff.
        /// In this case, <see cref="GetLastError"/> will return <see cref="NO_ERROR"/> upon success.
        /// Because of this behavior, it is recommended that you use <see cref="GetFileSizeEx"/> instead.
        /// Transacted Operations:  If there is a transaction bound to the file handle, then the function returns information for the isolated file view.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFileSize", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetFileSize([In] HANDLE hFile, [Out] out DWORD lpFileSizeHigh);

        /// <summary>
        /// <para>
        /// Retrieves the size of the specified file.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-getfilesizeex"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the file.
        /// The handle must have been created with the <see cref="FILE_READ_ATTRIBUTES"/> access right or equivalent,
        /// or the caller must have sufficient permission on the directory that contains the file.
        /// For more information, see File Security and Access Rights.
        /// </param>
        /// <param name="lpFileSize">
        /// A pointer to a <see cref="LARGE_INTEGER"/> structure that receives the file size, in bytes.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Transacted Operations:
        /// If there is a transaction bound to the file handle, then the function returns information for the isolated file view.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFileSizeEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetFileSizeEx([In] HANDLE hFile, [Out] out LARGE_INTEGER lpFileSize);

        /// <summary>
        /// <para>
        /// Retrieves the date and time that a file or directory was created, last accessed, and last modified.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-getfiletime"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the file or directory for which dates and times are to be retrieved.
        /// The handle must have been created using the MSe CreateFile function with the <see cref="GENERIC_READ"/> access right.
        /// For more information, see File Security and Access Rights.
        /// </param>
        /// <param name="lpCreationTime">
        /// A pointer to a <see cref="FILETIME"/> structure to receive the date and time the file or directory was created.
        /// This parameter can be <see langword="null"/> if the application does not require this information.
        /// </param>
        /// <param name="lpLastAccessTime">
        /// A pointer to a <see cref="FILETIME"/> structure to receive the date and time the file or directory was last accessed.
        /// The last access time includes the last time the file or directory was written to, read from, or,
        /// in the case of executable files, run.
        /// This parameter can be <see langword="null"/> if the application does not require this information.
        /// </param>
        /// <param name="lpLastWriteTime">
        /// A pointer to a <see cref="FILETIME"/> structure to receive the date and time the file or directory was last written to,
        /// truncated, or overwritten (for example, with <see cref="WriteFile"/> or <see cref="SetEndOfFile"/>).
        /// This date and time is not updated when file attributes or security descriptors are changed.
        /// This parameter can be <see langword="null"/> if the application does not require this information.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Not all file systems can record creation and last access times and not all file systems record them in the same manner.
        /// For example, on FAT, create time has a resolution of 10 milliseconds, write time has a resolution of 2 seconds,
        /// and access time has a resolution of 1 day (really, the access date).
        /// Therefore, the <see cref="GetFileTime"/> function may not return the same file time information set using the <see cref="SetFileTime"/> function.
        /// NTFS delays updates to the last access time for a file by up to one hour after the last access.
        /// NTFS also permits last access time updates to be disabled.
        /// Last access time is not updated on NTFS volumes by default.
        /// Windows Server 2003 and Windows XP:  Last access time is updated on NTFS volumes by default.
        /// For more information, see File Times.
        /// If you rename or delete a file, then restore it shortly thereafter, Windows searches the cache for file information to restore.
        /// Cached information includes its short/long name pair and creation time.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFileTime", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetFileTime([In] HANDLE hFile, [Out] out FILETIME lpCreationTime,
            [Out] out FILETIME lpLastAccessTime, [Out] out FILETIME lpLastWriteTime);

        /// <summary>
        /// <para>
        /// Retrieves the file type of the specified file.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-getfiletype"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the file.
        /// </param>
        /// <returns>
        /// You can distinguish between a "valid" return of <see cref="FILE_TYPE_UNKNOWN"/> and its return due to a calling error
        /// (for example, passing an invalid handle to <see cref="GetFileType"/>) by calling <see cref="GetLastError"/>.
        /// If the function worked properly and <see cref="FILE_TYPE_UNKNOWN"/> was returned,
        /// a call to <see cref="GetLastError"/> will return <see cref="NO_ERROR"/>.
        /// If the function returned <see cref="FILE_TYPE_UNKNOWN"/> due to an error in calling <see cref="GetFileType"/>,
        /// <see cref="GetLastError"/> will return the error code.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFileType", ExactSpelling = true, SetLastError = true)]
        public static extern FileTypes GetFileType([In] HANDLE hFile);

        /// <summary>
        /// <para>
        /// Retrieves the final path for the specified file.
        /// For more information about file and path names, see Naming a File.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-getfinalpathnamebyhandlew"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to a file or directory.
        /// </param>
        /// <param name="lpszFilePath">
        /// A pointer to a buffer that receives the path of <paramref name="hFile"/>.
        /// </param>
        /// <param name="cchFilePath">
        /// The size of <paramref name="lpszFilePath"/>, in TCHARs.
        /// This value must include a NULL termination character.
        /// </param>
        /// <param name="dwFlags">
        /// The type of result to return. 
        /// This parameter can be one of the following values.
        /// <see cref="FILE_NAME_NORMALIZED"/>, <see cref="FILE_NAME_OPENED"/>
        /// This parameter can also include one of the following values.
        /// <see cref="VOLUME_NAME_DOS"/>, <see cref="VOLUME_NAME_GUID"/>, <see cref="VOLUME_NAME_NONE"/>, <see cref="VOLUME_NAME_NT"/>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the length of the string received by <paramref name="lpszFilePath"/>, in TCHARs.
        /// This value does not include the size of the terminating null character.
        /// If the function fails because <paramref name="lpszFilePath"/> is too small to hold the string plus the terminating null character,
        /// the return value is the required buffer size, in TCHARs. This value includes the size of the terminating null character.
        /// If the function fails for any other reason, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// <see cref="ERROR_PATH_NOT_FOUND"/>:
        /// Can be returned if you are searching for a drive letter and one does not exist.
        /// For example, the handle was opened on a drive that is not currently mounted, or if you create a volume and do not assign it a drive letter.
        /// If a volume has no drive letter, you can use the volume GUID path to identify it
        /// This return value can also be returned if you are searching for a volume GUID path on a network share.
        /// Volume GUID paths are not created for network shares.
        /// <see cref="ERROR_NOT_ENOUGH_MEMORY"/>:
        /// Insufficient memory to complete the operation.
        /// <see cref="ERROR_INVALID_PARAMETER"/>:
        /// Invalid flags were specified for dwFlags.
        /// </returns>
        /// <remarks>
        /// The Server Message Block (SMB) Protocol does not support queries for normalized paths.
        /// Consequently, when you call this function passing the handle of a file opened using SMB,
        /// and with the <see cref="FILE_NAME_NORMALIZED"/> flag, the function splits the path into its components
        /// and tries to query for the normalized name of each of those components in turn.
        /// If the user lacks access permission to any one of those components, then the function call fails with <see cref="ERROR_ACCESS_DENIED"/>.
        /// A final path is the path that is returned when a path is fully resolved.
        /// For example, for a symbolic link named "C:\tmp\mydir" that points to "D:\yourdir", the final path would be "D:\yourdir".
        /// The string that is returned by this function uses the "\\?\" syntax.
        /// For more information, see <see cref="CreateFile"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFinalPathNameByHandle", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetFinalPathNameByHandle([In] HANDLE hFile, [In] LPWSTR lpszFilePath, [In] DWORD cchFilePath, [In] GetFinalPathNameByHandleFlags dwFlags);

        /// <summary>
        /// <para>
        /// Retrieves the full path and file name of the specified file.
        /// To perform this operation as a transacted operation, use the <see cref="GetFullPathNameTransacted"/> function.
        /// For more information about file and path names, see File Names, Paths, and Namespaces.
        /// The <see cref="GetFullPathName"/> function is not recommended for multithreaded applications or shared library code.
        /// For more information, see the Remarks section.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-getfullpathnamew"/>
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// The name of the file.
        /// This parameter can be a short (the 8.3 form) or long file name. This string can also be a share or volume name.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function (<see cref="GetFullPathName"/>),
        /// and prepend "\\?\" to the path.
        /// For more information, see Naming a File.
        /// Starting in Windows 10, version 1607, for the unicode version of this function (<see cref="GetFullPathName"/>),
        /// you can opt-in to remove the <see cref="MAX_PATH"/> character limitation without prepending "\\?\".
        /// See the "Maximum Path Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// </param>
        /// <param name="nBufferLength">
        /// The size of the buffer to receive the null-terminated string for the drive and path, in TCHARs.
        /// </param>
        /// <param name="lpBuffer">
        /// A pointer to a buffer that receives the null-terminated string for the drive and path.
        /// </param>
        /// <param name="lpFilePart">
        /// A pointer to a buffer that receives the address (within <paramref name="lpBuffer"/>) of the final file name component in the path.
        /// This parameter can be <see cref="IntPtr.Zero"/>.
        /// If <paramref name="lpBuffer"/> refers to a directory and not a file, <paramref name="lpFilePart"/> receives zero.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the length, in TCHARs, of the string copied to <paramref name="lpBuffer"/>,
        /// not including the terminating null character.
        /// If the <paramref name="lpBuffer"/> buffer is too small to contain the path, the return value is the size, in TCHARs
        /// of the buffer that is required to hold the path and the terminating null character.
        /// If the function fails for any other reason, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="GetFullPathName"/> merges the name of the current drive and directory with a specified file name
        /// to determine the full path and file name of a specified file.
        /// It also calculates the address of the file name portion of the full path and file name.
        /// This function does not verify that the resulting path and file name are valid, or that they see an existing file on the associated volume.
        /// Note that the <paramref name="lpFilePart"/> parameter does not require string buffer space, but only enough for a single address.
        /// This is because it simply returns an address within the buffer that already exists for <paramref name="lpBuffer"/>.
        /// Share and volume names are valid input for <paramref name="lpFileName"/>.
        /// For example, the following list identities the returned path and file names if test-2 is a remote computer and U: is a network mapped drive
        /// whose current directory is the root of the volume:
        /// If you specify "\\test-2\q$\lh" the path returned is "\\test-2\q$\lh"
        /// If you specify "\\?\UNC\test-2\q$\lh" the path returned is "\\?\UNC\test-2\q$\lh"
        /// If you specify "U:" the path returned is the current directory on the "U:\" drive
        /// <see cref="GetFullPathName"/> does not convert the specified file name, <paramref name="lpFileName"/>.
        /// If the specified file name exists, you can use <see cref="GetLongPathName"/> or <see cref="GetShortPathName"/>
        /// to convert to long or short path names, respectively.
        /// If the return value is greater than or equal to the value specified in <paramref name="nBufferLength"/>,
        /// you can call the function again with a buffer that is large enough to hold the path.
        /// For an example of this case in addition to using zero-length buffer for dynamic allocation, see the Example Code section.
        /// Although the return value in this case is a length that includes the terminating null character,
        /// the return value on success does not include the terminating null character in the count.
        /// Multithreaded applications and shared library code should not use the <see cref="GetFullPathName"/> function
        /// and should avoid using relative path names.
        /// The current directory state written by the <see cref="SetCurrentDirectory"/> function is stored as a global variable in each process,
        /// therefore multithreaded applications cannot reliably use this value without possible data corruption from other threads
        /// that may also be reading or setting this value.
        /// This limitation also applies to the <see cref="SetCurrentDirectory"/> and <see cref="GetCurrentDirectory"/> functions.
        /// The exception being when the application is guaranteed to be running in a single thread,
        /// for example parsing file names from the command line argument string in the main thread prior to creating any additional threads.
        /// Using relative path names in multithreaded applications or shared library code can yield unpredictable results and is not supported.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFullPathNameW", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetFullPathName([In] LPCWSTR lpFileName, [In] DWORD nBufferLength,
            [In] IntPtr lpBuffer, [Out] out IntPtr lpFilePart);

        /// <summary>
        /// <para>
        /// Retrieves a bitmask representing the currently available disk drives.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-getlogicaldrives"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is a bitmask representing the currently available disk drives.
        /// Bit position 0 (the least-significant bit) is drive A, bit position 1 is drive B, bit position 2 is drive C, and so on.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetLogicalDrives", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetLogicalDrives();

        /// <summary>
        /// <para>
        /// Fills a buffer with strings that specify valid drives in the system.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-getlogicaldrivestringsw"/>
        /// </para>
        /// </summary>
        /// <param name="nBufferLength">
        /// The maximum size of the buffer pointed to by <paramref name="lpBuffer"/>, in TCHARs.
        /// This size does not include the terminating null character.
        /// If this parameter is zero, <paramref name="lpBuffer"/> is not used.
        /// </param>
        /// <param name="lpBuffer">
        /// A pointer to a buffer that receives a series of null-terminated strings,
        /// one for each valid drive in the system, plus with an additional null character.
        /// Each string is a device name.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the length, in characters, of the strings copied to the buffer,
        /// not including the terminating null character.
        /// Note that an ANSI-ASCII null character uses one byte, but a Unicode (UTF-16) null character uses two bytes.
        /// If the buffer is not large enough, the return value is greater than <paramref name="nBufferLength"/>.
        /// It is the size of the buffer required to hold the drive strings.
        /// If the function fails, the return value is zero.
        /// To get extended error information, use the <see cref="GetLastError"/> function.
        /// </returns>
        /// <remarks>
        /// Each string in the buffer may be used wherever a root directory is required,
        /// such as for the <see cref="GetDriveType"/> and <see cref="GetDiskFreeSpace"/> functions.
        /// This function returns a concatenation of the drives in the Global and Local MS-DOS Device namespaces.
        /// If a drive exists in both namespaces, this function will return the entry in the Local MS-DOS Device namespace.
        /// For more information, see Defining an MS DOS Device Name.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetLogicalDriveStringsW", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetLogicalDriveStrings([In] DWORD nBufferLength, [In] IntPtr lpBuffer);

        /// <summary>
        /// <para>
        /// Converts the specified path to its long form.
        /// To perform this operation as a transacted operation, use the <see cref="GetLongPathNameTransacted"/> function.
        /// For more information about file and path names, see Naming Files, Paths, and Namespaces.
        /// Important
        /// To use this function, the caller must have the following permissions on the specified path and parent directories:
        /// List Folder, Read Data, Read Attributes
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-getlongpathnamew"/>
        /// </para>
        /// </summary>
        /// <param name="lpszShortPath">
        /// The path to be converted.
        /// In the ANSI version of this function, GetLongPathNameA, the name is limited to <see cref="MAX_PATH"/> (260) characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function,
        /// <see cref="GetLongPathName"/>, and prepend "\\?\" to the path.
        /// For more information, see Naming Files, Paths, and Namespaces.
        /// Tip Starting with Windows 10, version 1607, for the unicode version of this function (<see cref="GetLongPathName"/>),
        /// you can opt-in to remove the MAX_PATH limitation without prepending "\\?\".
        /// See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// </param>
        /// <param name="lpszLongPath">
        /// A pointer to the buffer to receive the long path.
        /// You can use the same buffer you used for the <paramref name="lpszShortPath"/>  parameter.
        /// </param>
        /// <param name="cchBuffer">
        /// The size of the buffer <paramref name="lpszLongPath"/> points to, in TCHARs.
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
        /// Therefore, do not assume that you can skip calling <see cref="GetLongPathName"/> if the path does not contain a tilde (~) character.
        /// If the file or directory exists but a long path is not found, <see cref="GetLongPathName"/> succeeds,
        /// having copied the string referred to by the <paramref name="lpszShortPath"/> parameter
        /// to the buffer referred to by the <paramref name="lpszLongPath"/> parameter.
        /// If the return value is greater than the value specified in <paramref name="cchBuffer"/>,
        /// you can call the function again with a buffer that is large enough to hold the path.
        /// For an example of this case, see the Example Code section for <see cref="GetFullPathName"/>.
        /// Note
        /// Although the return value in this case is a length that includes the terminating null character,
        /// the return value on success does not include the terminating null character in the count.
        /// It is possible to have access to a file or directory but not have access to some of the parent directories of that file or directory.
        /// As a result, <see cref="GetLongPathName"/> may fail when it is unable
        /// to query the parent directory of a path component to determine the long name for that component.
        /// This check can be skipped for directory components that have file extensions longer than 3 characters,
        /// or total lengths longer than 12 characters.
        /// For more information, see the Short vs. Long Names section of Naming Files, Paths, and Namespaces. 
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetLongPathNameW", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetLongPathName([In] LPCWSTR lpszShortPath, [In] IntPtr lpszLongPath, [In] DWORD cchBuffer);

        /// <summary>
        /// <para>
        /// Retrieves the short path form of the specified path.
        /// For more information about file and path names, see Naming Files, Paths, and Namespaces.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-getshortpathnamew"/>
        /// </para>
        /// </summary>
        /// <param name="lpszLongPath">
        /// The path string.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\\?\" to the path.
        /// For more information, see Naming Files, Paths, and Namespaces.
        /// </param>
        /// <param name="lpszShortPath">
        /// A pointer to a buffer to receive the null-terminated short form of the path that lpszLongPath specifies.
        /// Passing <see langword="null"/> for this parameter and zero for <paramref name="cchBuffer"/>
        /// will always return the required buffer size for a specified <paramref name="lpszLongPath"/>.
        /// </param>
        /// <param name="cchBuffer">
        /// The size of the buffer that <paramref name="lpszShortPath"/> points to, in TCHARs.
        /// Set this parameter to zero if <paramref name="lpszShortPath"/> is set to <see langword="null"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the length, in TCHARs,
        /// of the string that is copied to <paramref name="lpszShortPath"/>, not including the terminating null character.
        /// If the <paramref name="lpszShortPath"/> buffer is too small to contain the path, the return value is the size of the buffer, in TCHARs,
        /// that is required to hold the path and the terminating null character.
        /// If the function fails for any other reason, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The path that the <paramref name="lpszLongPath"/> parameter specifies does not have to be a full or long path.
        /// The short form can be longer than the specified path.
        /// If the return value is greater than the value specified in the <paramref name="cchBuffer"/> parameter,
        /// you can call the function again with a buffer that is large enough to hold the path.
        /// For an example of this case in addition to using zero-length buffer for dynamic allocation, see the Example Code section.
        /// Note
        /// Although the return value in this case is a length that includes the terminating null character,
        /// the return value on success does not include the terminating null character in the count.
        /// If the specified path is already in its short form and conversion is not needed,
        /// the function simply copies the specified path to the buffer specified by the <paramref name="lpszShortPath"/> parameter.
        /// You can set the <paramref name="lpszShortPath"/> parameter to the same value as the <paramref name="lpszLongPath"/> parameter;
        /// in other words, you can set the output buffer for the short path to the address of the input path string.
        /// Always ensure that the <paramref name="cchBuffer"/> parameter accurately represents the total size, in TCHARs, of this buffer.
        /// You can obtain the long name of a file from the short name by calling the <see cref="GetLongPathName"/> function.
        /// Alternatively, where <see cref="GetLongPathName"/> is not available,
        /// you can call <see cref="FindFirstFile"/> on each component of the path to get the corresponding long name.
        /// It is possible to have access to a file or directory but not have access to some of the parent directories of that file or directory.
        /// As a result, <see cref="GetShortPathName"/> may fail when it is unable
        /// to query the parent directory of a path component to determine the short name for that component.
        /// This check can be skipped for directory components that already meet the requirements of a short name.
        /// For more information, see the Short vs. Long Names section of Naming Files, Paths, and Namespaces.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetShortPathNameW", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetShortPathName([In] LPCWSTR lpszLongPath, [In] IntPtr lpszShortPath, [In] DWORD cchBuffer);

        /// <summary>
        /// <para>
        /// Creates a name for a temporary file.
        /// If a unique file name is generated, an empty file is created and the handle to it is released; otherwise, only a file name is generated.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-gettempfilenamew"/>
        /// </para>
        /// </summary>
        /// <param name="lpPathName">
        /// The directory path for the file name.
        /// Applications typically specify a period (.) for the current directory or the result of the <see cref="GetTempPath"/> function.
        /// The string cannot be longer than <see cref="MAX_PATH"/>–14 characters or <see cref="GetTempFileName"/> will fail.
        /// If this parameter is <see langword="null"/>, the function fails.
        /// </param>
        /// <param name="lpPrefixString">
        /// The null-terminated prefix string.
        /// The function uses up to the first three characters of this string as the prefix of the file name.
        /// This string must consist of characters in the OEM-defined character set.
        /// </param>
        /// <param name="uUnique">
        /// An unsigned integer to be used in creating the temporary file name.
        /// For more information, see Remarks.
        /// If <paramref name="uUnique"/> is zero, the function attempts to form a unique file name using the current system time.
        /// If the file already exists, the number is increased by one and the functions tests if this file already exists.
        /// This continues until a unique filename is found; the function creates a file by that name and closes it.
        /// Note that the function does not attempt to verify the uniqueness of the file name when <paramref name="uUnique"/> is nonzero.
        /// </param>
        /// <param name="lpTempFileName">
        /// A pointer to the buffer that receives the temporary file name.
        /// This buffer should be <see cref="MAX_PATH"/> characters to accommodate the path plus the terminating null character.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value specifies the unique numeric value used in the temporary file name.
        /// If the <paramref name="uUnique"/> parameter is nonzero, the return value specifies that same number.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// The following is a possible return value.
        /// <see cref="ERROR_BUFFER_OVERFLOW"/>:
        /// The length of the string pointed to by the <paramref name="lpPathName"/> parameter is more than <see cref="MAX_PATH"/>–14 characters.
        /// </returns>
        /// <remarks>
        /// The <see cref="GetTempFileName"/> function creates a temporary file name of the following form:
        /// &lt;path&gt;&lt;i&gt;&lt;pre&gt;&lt;uuuu&gt;.TMP
        /// The following table describes the file name syntax.
        /// &lt;path&gt;: Path specified by the <paramref name="lpPathName"/> parameter
        /// &lt;pre&gt;: First three letters of the <paramref name="lpPrefixString"/> string
        /// &lt;uuuu&gt;: Hexadecimal value of <paramref name="uUnique"/>
        /// If <paramref name="uUnique"/> is zero, <see cref="GetTempFileName"/> creates an empty file and closes it.
        /// If <paramref name="uUnique"/> is not zero, you must create the file yourself.
        /// Only a file name is created, because <see cref="GetTempFileName"/> is not able to guarantee that the file name is unique.
        /// Only the lower 16 bits of the uUnique parameter are used.
        /// This limits <see cref="GetTempFileName"/> to a maximum of 65,535 unique file names
        /// if the <paramref name="lpPathName"/> and <paramref name="lpPrefixString"/> parameters remain the same.
        /// Due to the algorithm used to generate file names, <see cref="GetTempFileName"/> can perform poorly
        /// when creating a large number of files with the same prefix.
        /// In such cases, it is recommended that you construct unique file names based on GUIDs.
        /// Temporary files whose names have been created by this function are not automatically deleted.
        /// To delete these files call <see cref="DeleteFile"/>.
        /// To avoid problems resulting when converting an ANSI string, an application should call
        /// the <see cref="CreateFile"/> function to create a temporary file.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTempFileNameW", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GetTempFileName([In] LPCWSTR lpPathName, [In] LPCWSTR lpPrefixString, [In] UINT uUnique, [In] IntPtr lpTempFileName);

        /// <summary>
        /// <para>
        /// Retrieves the path of the directory designated for temporary files.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-gettemppathw"/>
        /// </para>
        /// </summary>
        /// <param name="nBufferLength">
        /// The size of the string buffer identified by <paramref name="lpBuffer"/>, in TCHARs.
        /// </param>
        /// <param name="lpBuffer">
        /// A pointer to a string buffer that receives the null-terminated string specifying the temporary file path.
        /// The returned string ends with a backslash, for example, "C:\TEMP\".
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the length, in TCHARs, of the string copied to lpBuffer,
        /// not including the terminating null character.
        /// If the return value is greater than nBufferLength, the return value is the length, in TCHARs, of the buffer required to hold the path.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// The maximum possible return value is <see cref="MAX_PATH"/>+1 (261).
        /// </returns>
        /// <remarks>
        /// The <see cref="GetTempPath"/> function checks for the existence of environment variables in the following order
        /// and uses the first path found:
        /// The path specified by the TMP environment variable.
        /// The path specified by the TEMP environment variable.
        /// The path specified by the USERPROFILE environment variable.
        /// The Windows directory.
        /// Note that the function does not verify that the path exists, nor does it test to see
        /// if the current process has any kind of access rights to the path.
        /// The GetTempPath function returns the properly formatted string that specifies the fully qualified path
        /// based on the environment variable search order as previously specified.
        /// The application should verify the existence of the path and adequate access rights to the path prior to any use for file I/O operations.
        /// Symbolic link behavior—If the path points to a symbolic link, the temp path name maintains any symbolic links.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTempPathW", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetTempPath([In] DWORD nBufferLength, [In] IntPtr lpBuffer);

        /// <summary>
        /// <para>
        /// Retrieves information about the file system and volume associated with the specified root directory.
        /// To specify a handle when retrieving this information, use the <see cref="GetVolumeInformationByHandleW"/> function.
        /// To retrieve the current compression state of a file or directory, use <see cref="FSCTL_GET_COMPRESSION"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-getvolumeinformationw"/>
        /// </para>
        /// </summary>
        /// <param name="lpRootPathName">
        /// A pointer to a string that contains the root directory of the volume to be described.
        /// If this parameter is <see langword="null"/>, the root of the current directory is used. A trailing backslash is required.
        /// For example, you specify \MyServer\MyShare as "\MyServer\MyShare\", or the C drive as "C:\".
        /// </param>
        /// <param name="lpVolumeNameBuffer">
        /// A pointer to a buffer that receives the name of a specified volume.
        /// The buffer size is specified by the <paramref name="nVolumeNameSize"/> parameter.
        /// </param>
        /// <param name="nVolumeNameSize">
        /// The length of a volume name buffer, in TCHARs. The maximum buffer size is <see cref="MAX_PATH"/>+1.
        /// This parameter is ignored if the volume name buffer is not supplied.
        /// </param>
        /// <param name="lpVolumeSerialNumber">
        /// A pointer to a variable that receives the volume serial number.
        /// This parameter can be <see langword="null"/> if the serial number is not required.
        /// This function returns the volume serial number that the operating system assigns when a hard disk is formatted.
        /// To programmatically obtain the hard disk's serial number that the manufacturer assigns,
        /// use the Windows Management Instrumentation (WMI) Win32_PhysicalMedia property SerialNumber.
        /// </param>
        /// <param name="lpMaximumComponentLength">
        /// A pointer to a variable that receives the maximum length, in TCHARs, of a file name component that a specified file system supports.
        /// A file name component is the portion of a file name between backslashes.
        /// The value that is stored in the variable that <paramref name="lpMaximumComponentLength"/> points to is used to indicate that
        /// a specified file system supports long names.
        /// For example, for a FAT file system that supports long names, the function stores the value 255, rather than the previous 8.3 indicator.
        /// Long names can also be supported on systems that use the NTFS file system.
        /// </param>
        /// <param name="lpFileSystemFlags">
        /// A pointer to a variable that receives flags associated with the specified file system.
        /// This parameter can be one or more of <see cref="FileSystemFlags"/>.
        /// However, <see cref="FILE_FILE_COMPRESSION"/> and <see cref="FILE_VOLUME_IS_COMPRESSED"/> are mutually exclusive.
        /// </param>
        /// <param name="lpFileSystemNameBuffer">
        /// A pointer to a buffer that receives the name of the file system, for example, the FAT file system or the NTFS file system.
        /// The buffer size is specified by the <paramref name="nFileSystemNameSize"/> parameter.
        /// </param>
        /// <param name="nFileSystemNameSize">
        /// The length of the file system name buffer, in TCHARs. The maximum buffer size is <see cref="MAX_PATH"/>+1.
        /// This parameter is ignored if the file system name buffer is not supplied.
        /// </param>
        /// <returns>
        /// If all the requested information is retrieved, the return value is <see cref="TRUE"/>.
        /// If not all the requested information is retrieved, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// When a user attempts to get information about a floppy drive that does not have a floppy disk,
        /// or a CD-ROM drive that does not have a compact disc,
        /// the system displays a message box for the user to insert a floppy disk or a compact disc, respectively.
        /// To prevent the system from displaying this message box, call the <see cref="SetErrorMode"/> function with <see cref="SEM_FAILCRITICALERRORS"/>.
        /// The <see cref="FILE_VOLUME_IS_COMPRESSED"/> flag is the only indicator of volume-based compression.
        /// The file system name is not altered to indicate compression, for example, this flag is returned set on a DoubleSpace volume.
        /// When compression is volume-based, an entire volume is compressed or not compressed.
        /// The <see cref="FILE_FILE_COMPRESSION"/> flag indicates whether a file system supports file-based compression.
        /// When compression is file-based, individual files can be compressed or not compressed.
        /// The <see cref="FILE_FILE_COMPRESSION"/> and <see cref="FILE_VOLUME_IS_COMPRESSED"/> flags are mutually exclusive.
        /// Both bits cannot be returned set.
        /// The maximum component length value that is stored in <paramref name="lpMaximumComponentLength"/> is the only indicator
        /// that a volume supports longer-than-normal FAT file system (or other file system) file names.
        /// The file system name is not altered to indicate support for long file names.
        /// The <see cref="GetCompressedFileSize"/> function obtains the compressed size of a file.
        /// The <see cref="GetFileAttributes"/> function can determine whether an individual file is compressed.
        /// Symbolic link behavior—
        /// If the path points to a symbolic link, the function returns volume information for the target.
        /// Transacted Operations
        /// If the volume supports file system transactions,
        /// the function returns <see cref="FILE_SUPPORTS_TRANSACTIONS"/> in <paramref name="lpFileSystemFlags"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetVolumeInformationW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetVolumeInformation([In] LPCWSTR lpRootPathName, [In] IntPtr lpVolumeNameBuffer,
            [In] DWORD nVolumeNameSize, [Out] out DWORD lpVolumeSerialNumber, [Out] out DWORD lpMaximumComponentLength,
            [Out] out FileSystemFlags lpFileSystemFlags, [In] IntPtr lpFileSystemNameBuffer, [In] DWORD nFileSystemNameSize);

        /// <summary>
        /// <para>
        /// Retrieves information about the file system and volume associated with the specified file.
        /// To retrieve the current compression state of a file or directory, use <see cref="FSCTL_GET_COMPRESSION"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-getvolumeinformationbyhandlew"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the file.
        /// </param>
        /// <param name="lpVolumeNameBuffer">
        /// A pointer to a buffer that receives the name of a specified volume.
        /// The maximum buffer size is <see cref="MAX_PATH"/>+1.
        /// </param>
        /// <param name="nVolumeNameSize">
        /// The length of a volume name buffer, in WCHARs.
        /// The maximum buffer size is <see cref="MAX_PATH"/>+1.
        /// This parameter is ignored if the volume name buffer is not supplied.
        /// </param>
        /// <param name="lpVolumeSerialNumber">
        /// A pointer to a variable that receives the volume serial number.
        /// This parameter can be <see langword="null"/> if the serial number is not required.
        /// This function returns the volume serial number that the operating system assigns when a hard disk is formatted.
        /// To programmatically obtain the hard disk's serial number that the manufacturer assigns,
        /// use the Windows Management Instrumentation (WMI) Win32_PhysicalMedia property SerialNumber.
        /// </param>
        /// <param name="lpMaximumComponentLength">
        /// A pointer to a variable that receives the maximum length, in WCHARs, of a file name component that a specified file system supports.
        /// A file name component is the portion of a file name between backslashes.
        /// The value that is stored in the variable that <paramref name="lpMaximumComponentLength"/> points to is used to indicate
        /// that a specified file system supports long names.
        /// For example, for a FAT file system that supports long names, the function stores the value 255, rather than the previous 8.3 indicator.
        /// Long names can also be supported on systems that use the NTFS file system.
        /// </param>
        /// <param name="lpFileSystemFlags">
        /// A pointer to a variable that receives flags associated with the specified file system.
        /// This parameter can be one or more of <see cref="FileSystemFlags"/>.
        /// However, <see cref="FILE_FILE_COMPRESSION"/> and <see cref="FILE_VOLUME_IS_COMPRESSED"/> are mutually exclusive.
        /// </param>
        /// <param name="lpFileSystemNameBuffer">
        /// A pointer to a buffer that receives the name of the file system, for example, the FAT file system or the NTFS file system.
        /// The buffer size is specified by the <paramref name="nFileSystemNameSize"/> parameter.
        /// </param>
        /// <param name="nFileSystemNameSize">
        /// The length of the file system name buffer, in TCHARs. The maximum buffer size is <see cref="MAX_PATH"/>+1.
        /// This parameter is ignored if the file system name buffer is not supplied.
        /// </param>
        /// <returns>
        /// If all the requested information is retrieved, the return value is <see langword="true"/>.
        /// If not all the requested information is retrieved, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetVolumeInformationByHandleW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetVolumeInformationByHandleW([In] HANDLE hFile, [In] IntPtr lpVolumeNameBuffer, [In] DWORD nVolumeNameSize,
            [Out] out DWORD lpVolumeSerialNumber, [Out] out DWORD lpMaximumComponentLength, [Out] out FileSystemFlags lpFileSystemFlags,
            [In] IntPtr lpFileSystemNameBuffer, [In] DWORD nFileSystemNameSize);

        /// <summary>
        /// <para>
        /// Retrieves a volume GUID path for the volume that is associated with the specified volume mount point
        /// ( drive letter, volume GUID path, or mounted folder).
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-getvolumenameforvolumemountpointw"/>
        /// </para>
        /// </summary>
        /// <param name="lpszVolumeMountPoint">
        /// A pointer to a string that contains the path of a mounted folder (for example, "Y:\MountX\") or a drive letter (for example, "X:\").
        /// The string must end with a trailing backslash ('\').
        /// </param>
        /// <param name="lpszVolumeName">
        /// A pointer to a string that receives the volume GUID path.
        /// This path is of the form "\\?\Volume{GUID}\" where GUID is a GUID that identifies the volume.
        /// If there is more than one volume GUID path for the volume, only the first one in the mount manager's cache is returned.
        /// </param>
        /// <param name="cchBufferLength">
        /// The length of the output buffer, in TCHARs.
        /// A reasonable size for the buffer to accommodate the largest possible volume GUID path is 50 characters.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Use <see cref="GetVolumeNameForVolumeMountPoint"/> to obtain a volume GUID path for use with functions
        /// such as <see cref="SetVolumeMountPoint"/> and <see cref="FindFirstVolumeMountPoint"/> that require a volume GUID path as an input parameter.
        /// For more information about volume GUID paths, see Naming A Volume.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetVolumeNameForVolumeMountPointW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetVolumeNameForVolumeMountPoint([In] LPCWSTR lpszVolumeMountPoint, [In] IntPtr lpszVolumeName, [In] DWORD cchBufferLength);

        /// <summary>
        /// <para>
        /// Retrieves the volume mount point where the specified path is mounted.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-getvolumepathnamew"/>
        /// </para>
        /// </summary>
        /// <param name="lpszFileName">
        /// A pointer to the input path string. Both absolute and relative file and directory names, for example, "..", are acceptable in this path.
        /// If you specify a relative directory or file name without a volume qualifier, <see cref="GetVolumePathName"/> returns the drive letter of the boot volume.
        /// If this parameter is an empty string, "", the function fails but the last error is set to <see cref="ERROR_SUCCESS"/>.
        /// </param>
        /// <param name="lpszVolumePathName">
        /// A pointer to a string that receives the volume mount point for the input path.
        /// </param>
        /// <param name="cchBufferLength">
        /// The length of the output buffer, in TCHARs.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If a specified path is passed, <see cref="GetVolumePathName"/> returns the path to the volume mount point,
        /// which means that it returns the root of the volume where the end point of the specified path is located.
        /// For example, assume that you have volume D mounted at C:\Mnt\Ddrive and volume E mounted at C:\Mnt\Ddrive\Mnt\Edrive.
        /// Also assume that you have a file with the path E:\Dir\Subdir\MyFile.
        /// If you pass C:\Mnt\Ddrive\Mnt\Edrive\Dir\Subdir\MyFile to <see cref="GetVolumePathName"/>, it returns the path C:\Mnt\Ddrive\Mnt\Edrive\.
        /// If either a relative directory or a file is passed without a volume qualifier, the function returns the drive letter of the boot volume.
        /// The drive letter of the boot volume is also returned if an invalid file or directory name is specified without a valid volume qualifier.
        /// If a valid volume specifier is given, and the volume exists, but an invalid file or directory name is specified,
        /// the function will succeed and that volume name will be returned. For examples, see the Examples section of this topic.
        /// You must specify a valid Win32 namespace path.
        /// If you specify an NT namespace path, for example, \DosDevices\H: or \Device\HardDiskVolume6,
        /// the function returns the drive letter of the boot volume, not the drive letter of that NT namespace path.
        /// For more information about path names and namespaces, see Naming Files, Paths, and Namespaces.
        /// You can specify both local and remote paths.
        /// If you specify a local path, GetVolumePathName returns a full path whose prefix is the longest prefix that represents a volume.
        /// If a network share is specified, <see cref="GetVolumePathName"/> returns the shortest path
        /// for which <see cref="GetDriveType"/> returns <see cref="DRIVE_REMOTE"/>,
        /// which means that the path is validated as a remote drive that exists, which the current user can access.
        /// There are certain special cases that do not return a trailing backslash.
        /// These occur when the output buffer length is one character too short.
        /// For example, if <paramref name="lpszFileName"/> is C: and lpszVolumePathName is 4 characters long, the value returned is C:\;
        /// however, if <paramref name="lpszVolumePathName"/> is 3 characters long, the value returned is C:.
        /// A safer but slower way to set the size of the return buffer is to call the <see cref="GetFullPathName"/> function,
        /// and then make sure that the buffer size is at least the same size as the full path that <see cref="GetFullPathName"/> returns.
        /// If the output buffer is more than one character too short, the function will fail and return an error.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetVolumePathNameW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetVolumePathName([In] LPCWSTR lpszFileName, [In] LPWSTR lpszVolumePathName, [In] DWORD cchBufferLength);

        /// <summary>
        /// <para>
        /// Retrieves a list of drive letters and mounted folder paths for the specified volume.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-getvolumepathnamesforvolumenamew"/>
        /// </para>
        /// </summary>
        /// <param name="lpszVolumeName">
        /// A volume GUID path for the volume.
        /// A volume GUID path is of the form "\\?\Volume{xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx}\".
        /// </param>
        /// <param name="lpszVolumePathNames">
        /// A pointer to a buffer that receives the list of drive letters and mounted folder paths.
        /// The list is an array of null-terminated strings terminated by an additional NULL character.
        /// If the buffer is not large enough to hold the complete list, the buffer holds as much of the list as possible.
        /// </param>
        /// <param name="cchBufferLength">
        /// The length of the <paramref name="lpszVolumePathNames"/> buffer, in TCHARs, including all NULL characters.
        /// </param>
        /// <param name="lpcchReturnLength">
        /// If the call is successful, this parameter is the number of TCHARs copied to the <paramref name="lpszVolumePathNames"/> buffer.
        /// Otherwise, this parameter is the size of the buffer required to hold the complete list, in TCHARs.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If the buffer is not large enough to hold the complete list, the error code is <see cref="ERROR_MORE_DATA"/> 
        /// and the <paramref name="lpcchReturnLength"/> parameter receives the required buffer size.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetVolumePathNamesForVolumeNameW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetVolumePathNamesForVolumeName([In] LPCWSTR lpszVolumeName, [In] IntPtr lpszVolumePathNames,
            [In] DWORD cchBufferLength, [Out] out DWORD lpcchReturnLength);

        /// <summary>
        /// <para>
        /// Converts a local file time to a file time based on the Coordinated Universal Time (UTC).
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-localfiletimetofiletime"/>
        /// </para>
        /// </summary>
        /// <param name="lpLocalFileTime">
        /// A pointer to a <see cref="FILETIME"/> structure that specifies the local file time to be converted into a UTC-based file time.
        /// </param>
        /// <param name="lpFileTime">
        /// A pointer to a <see cref="FILETIME"/> structure to receive the converted UTC-based file time.
        /// This parameter cannot be the same as the <paramref name="lpLocalFileTime"/> parameter.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="LocalFileTimeToFileTime"/> uses the current settings for the time zone and daylight saving time.
        /// Therefore, if it is daylight saving time, this function will take daylight saving time into account,
        /// even if the time you are converting is in standard time.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "LocalFileTimeToFileTime", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL LocalFileTimeToFileTime([In] in FILETIME lpLocalFileTime, [Out] out FILETIME lpFileTime);

        /// <summary>
        /// <para>
        /// Locks the specified file for exclusive access by the calling process.
        /// To specify additional options, for example creating a shared lock or for block-on-fail operation, use the <see cref="LockFileEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-lockfile"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the file. 
        /// The file handle must have been created with the <see cref="GENERIC_READ"/> or <see cref="GENERIC_WRITE"/> access right.
        /// For more information, see File Security and Access Rights.
        /// </param>
        /// <param name="dwFileOffsetLow">
        /// The low-order 32 bits of the starting byte offset in the file where the lock should begin.
        /// </param>
        /// <param name="dwFileOffsetHigh">
        /// The high-order 32 bits of the starting byte offset in the file where the lock should begin.
        /// </param>
        /// <param name="nNumberOfBytesToLockLow">
        /// The low-order 32 bits of the length of the byte range to be locked.
        /// </param>
        /// <param name="nNumberOfBytesToLockHigh">
        /// The high-order 32 bits of the length of the byte range to be locked.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero (<see cref="TRUE"/>).
        /// If the function fails, the return value is zero (<see cref="FALSE"/>).
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If the call to <see cref="LockFile"/> completes synchronously, a completion entry may not be queued
        /// when a completion port is associated with the file handle.
        /// The <see cref="UnlockFile"/> function unlocks a file region locked by <see cref="LockFile"/>.
        /// Locking a region of a file gives the threads of the locking process exclusive access to the specified region using this file handle.
        /// If the file handle is inherited by a process created by the locking process, the child process is not granted access to the locked region.
        /// If the locking process opens the file a second time, it cannot access the specified region through this second handle
        /// until it unlocks the region.
        /// Locking a region of a file does not prevent reading from a mapped file view.
        /// You can lock bytes that are beyond the end of the current file.
        /// This is useful to coordinate adding records to the end of a file.
        /// Exclusive locks cannot overlap an existing locked region of a file.
        /// For more information, see <see cref="LockFileEx"/>.
        /// If <see cref="LockFile"/> cannot lock a region of a file, it returns zero immediately. It does not block.
        /// To issue a file lock request that will block until the lock is acquired, use <see cref="LockFileEx"/>
        /// without the <see cref="LOCKFILE_FAIL_IMMEDIATELY"/> flag.
        /// If a process terminates with a portion of a file locked or closes a file that has outstanding locks,
        /// the locks are unlocked by the operating system.
        /// However, the time it takes for the operating system to unlock these locks depends upon available system resources.
        /// Therefore, it is recommended that your process explicitly unlock all files it has locked when it terminates.
        /// If this is not done, access to these files may be denied if the operating system has not yet unlocked them.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "LockFile", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL LockFile([In] HANDLE hFile, [In] DWORD dwFileOffsetLow, [In] DWORD dwFileOffsetHigh,
            [In] DWORD nNumberOfBytesToLockLow, [In] DWORD nNumberOfBytesToLockHigh);

        /// <summary>
        /// <para>
        /// Locks the specified file for exclusive access by the calling process.
        /// This function can operate either synchronously or asynchronously and can request either an exclusive or a shared lock.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-lockfileex"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the file.
        /// The handle must have been created with either the <see cref="GENERIC_READ"/> or <see cref="GENERIC_WRITE"/> access right.
        /// For more information, see File Security and Access Rights.
        /// </param>
        /// <param name="dwFlags">
        /// This parameter may be one or more of the following values.
        /// <see cref="LOCKFILE_EXCLUSIVE_LOCK"/>, <see cref="LOCKFILE_FAIL_IMMEDIATELY"/>
        /// </param>
        /// <param name="dwReserved">
        /// Reserved parameter; must be set to zero.
        /// </param>
        /// <param name="nNumberOfBytesToLockLow">
        /// The low-order 32 bits of the length of the byte range to lock.
        /// </param>
        /// <param name="nNumberOfBytesToLockHigh">
        /// The high-order 32 bits of the length of the byte range to lock.
        /// </param>
        /// <param name="lpOverlapped">
        /// A pointer to an <see cref="OVERLAPPED"/> structure that the function uses with the locking request.
        /// This structure, which is required, contains the file offset of the beginning of the lock range.
        /// You must initialize the <see cref="OVERLAPPED.hEvent"/> member to a valid handle or zero.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Locking a region of a file is used to acquire shared or exclusive access to the specified region using this file handle.
        /// If the file handle is inherited by a process created by the locking process, the child process is not granted access to the locked region.
        /// If the locking process opens the file a second time, it cannot access the specified region through this second handle until it unlocks the region.
        /// Locking a portion of a file for exclusive access denies all other processes both read and write access to the specified region of the file.
        /// Locking a region that goes beyond the current end-of-file position is not an error.
        /// Locking a portion of a file for shared access denies all processes write access to the specified region of the file,
        /// including the process that first locks the region.
        /// All processes can read the locked region.
        /// Locking a region of a file does not prevent reading from a mapped file view.
        /// The <see cref="LockFileEx"/> function operates asynchronously if the file handle was opened for asynchronous I/O,
        /// unless the <see cref="LOCKFILE_FAIL_IMMEDIATELY"/> flag is specified.
        /// If an exclusive lock is requested for a range of a file that already has a shared or exclusive lock,
        /// the function returns the error <see cref="ERROR_IO_PENDING"/>.
        /// The system will signal the event specified in the <see cref="OVERLAPPED"/> structure after the lock is granted.
        /// To determine when the lock has been granted, use the <see cref="GetOverlappedResult"/> function or one of the wait functions.
        /// For more information, see Synchronous and Asynchronous I/O.
        /// If the file handle was not opened for asynchronous I/O and the lock is not available,
        /// this call waits until the lock is granted or an error occurs,
        /// unless the <see cref="LOCKFILE_FAIL_IMMEDIATELY"/> flag is specified.
        /// Exclusive locks cannot overlap an existing locked region of a file.
        /// Shared locks can overlap a locked region provided locks held on that region are shared locks.
        /// A shared lock can overlap an exclusive lock if both locks were created using the same file handle.
        /// When a shared lock overlaps an exclusive lock, the only possible access is a read by the owner of the locks.
        /// If the same range is locked with an exclusive and a shared lock, two unlock operations are necessary to unlock the region;
        /// the first unlock operation unlocks the exclusive lock, the second unlock operation unlocks the shared lock.
        /// If a process terminates with a portion of a file locked or closes a file that has outstanding locks, the locks are unlocked by the operating system.
        /// However, the time it takes for the operating system to unlock these locks depends upon available system resources.
        /// Therefore, it is recommended that your process explicitly unlock all files it has locked when it terminates.
        /// If this is not done, access to these files may be denied if the operating system has not yet unlocked them.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "LockFileEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL LockFileEx([In] HANDLE hFile, [In] LockFileExFlags dwFlags, [In] DWORD dwReserved, [In] DWORD nNumberOfBytesToLockLow,
            [In] DWORD nNumberOfBytesToLockHigh, [In] in OVERLAPPED lpOverlapped);

        /// <summary>
        /// <para>
        /// Moves an existing file or directory, including its children, with various move options.
        /// The <see cref="MoveFileWithProgress"/> function is equivalent to the <see cref="MoveFileEx"/> function,
        /// except that <see cref="MoveFileWithProgress"/> allows you to provide a callback function that receives progress notifications.
        /// To perform this operation as a transacted operation, use the <see cref="MoveFileTransacted"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-movefileexw"/>
        /// </para>
        /// </summary>
        /// <param name="lpExistingFileName">
        /// The current name of the file or directory on the local computer.
        /// If <paramref name="dwFlags"/> specifies <see cref="MOVEFILE_DELAY_UNTIL_REBOOT"/>, the file cannot exist on a remote share,
        /// because delayed operations are performed before the network is available.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File
        /// Tip
        /// Starting with Windows 10, version 1607, for the unicode version of this function (MoveFileExW),
        /// you can opt-in to remove the MAX_PATH limitation without prepending "\\?\".
        /// See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// </param>
        /// <param name="lpNewFileName">
        /// The new name of the file or directory on the local computer.
        /// When moving a file, the destination can be on a different file system or volume.
        /// If the destination is on another drive, you must set the <see cref="MOVEFILE_COPY_ALLOWED"/> flag in <paramref name="dwFlags"/>.
        /// When moving a directory, the destination must be on the same drive.
        /// If <paramref name="dwFlags"/> specifies <see cref="MOVEFILE_DELAY_UNTIL_REBOOT"/> and <paramref name="lpNewFileName"/> is <see cref="NULL"/>,
        /// <see cref="MoveFileEx"/> registers the <paramref name="lpExistingFileName"/> file to be deleted when the system restarts.
        /// If <paramref name="lpExistingFileName"/> refers to a directory, the system removes the directory at restart only if the directory is empty.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File
        /// Tip  Starting with Windows 10, version 1607, for the unicode version of this function (MoveFileExW),
        /// you can opt-in to remove the <see cref="MAX_PATH"/> limitation without prepending "\\?\".
        /// See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// </param>
        /// <param name="dwFlags">
        /// This parameter can be one or more of the following values.
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
        /// <see cref="MOVEFILE_FAIL_IF_NOT_TRACKABLE"/>:
        /// The function fails if the source file is a link source, but the file cannot be tracked after the move.
        /// This situation can occur if the destination is a volume formatted with the FAT file system.
        /// <see cref="MOVEFILE_REPLACE_EXISTING"/>:
        /// If a file named <paramref name="lpNewFileName"/> exists, the function replaces its contents with the contents of the <paramref name="lpExistingFileName"/> file,
        /// provided that security requirements regarding access control lists (ACLs) are met.
        /// For more information, see the Remarks section of this topic.
        /// If <paramref name="lpNewFileName"/> names an existing directory, an error is reported.
        /// <see cref="MOVEFILE_WRITE_THROUGH"/>:
        /// The function does not return until the file is actually moved on the disk.
        /// Setting this value guarantees that a move performed as a copy and delete operation is flushed to disk before the function returns.
        /// The flush occurs at the end of the copy operation.
        /// This value has no effect if <see cref="MOVEFILE_DELAY_UNTIL_REBOOT"/> is set.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If the <paramref name="dwFlags"/> parameter specifies <see cref="MOVEFILE_DELAY_UNTIL_REBOOT"/>, <see cref="MoveFileEx"/> fails if it cannot access the registry.
        /// The function stores the locations of the files to be renamed at restart in the following registry value:
        /// HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\PendingFileRenameOperations
        /// This registry value is of type REG_MULTI_SZ.
        /// Each rename operation stores one of the following NULL-terminated strings, depending on whether the rename is a delete or not:
        /// szDstFile\0\0
        /// szSrcFile\0szDstFile\0
        /// The string szDstFile\0\0 indicates that the file szDstFile is to be deleted on reboot.
        /// The string szSrcFile\0szDstFile\0 indicates that szSrcFile is to be renamed szDstFile on reboot.
        /// Note
        /// Although \0\0 is technically not allowed in a REG_MULTI_SZ node, it can because the file is considered to be renamed to a null name.
        /// The system uses these registry entries to complete the operations at restart in the same order that they were issued.
        /// For example, the following code fragment creates registry entries that delete szDstFile and rename szSrcFile to be szDstFile at restart:
        /// <code>
        /// MoveFileEx(szDstFile, NULL, MOVEFILE_DELAY_UNTIL_REBOOT);
        /// MoveFileEx(szSrcFile, szDstFile, MOVEFILE_DELAY_UNTIL_REBOOT);
        /// </code>
        /// Because the actual move and deletion operations specified with the <see cref="MOVEFILE_DELAY_UNTIL_REBOOT"/> flag take place
        /// after the calling application has ceased running, the return value cannot reflect success or failure in moving or deleting the file.
        /// Rather, it reflects success or failure in placing the appropriate entries into the registry.
        /// The system deletes a directory that is tagged for deletion with the <see cref="MOVEFILE_DELAY_UNTIL_REBOOT"/> flag only if it is empty.
        /// To ensure deletion of directories, move or delete all files from the directory before attempting to delete it.
        /// Files may be in the directory at boot time, but they must be deleted or moved before the system can delete the directory.
        /// The move and deletion operations are carried out at boot time in the same order that they are specified in the calling application.
        /// To delete a directory that has files in it at boot time, first delete the files.
        /// If a file is moved across volumes, <see cref="MoveFileEx"/> does not move the security descriptor with the file.
        /// The file is assigned the default security descriptor in the destination directory.
        /// The <see cref="MoveFileEx"/> function coordinates its operation with the link tracking service, so link sources can be tracked as they are moved.
        /// To delete or rename a file, you must have either delete permission on the file or delete child permission in the parent directory.
        /// If you set up a directory with all access except delete and delete child and the ACLs of new files are inherited,
        /// then you should be able to create a file without being able to delete it.
        /// However, you can then create a file, and get all the access you request on the handle that is returned to you at the time that you create the file.
        /// If you request delete permission at the time you create the file, you can delete or rename the file with that handle but not with any other handle.
        /// For more information, see File Security and Access Rights.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "MoveFileExW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL MoveFileEx([In] LPCWSTR lpExistingFileName, [In] LPCWSTR lpNewFileName, [In] MoveFileFlags dwFlags);

        /// <summary>
        /// <para>
        /// Moves a file or directory, including its children. You can provide a callback function that receives progress notifications.
        /// To perform this operation as a transacted operation, use the <see cref="MoveFileTransacted"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-movefilewithprogressw"/>
        /// </para>
        /// </summary>
        /// <param name="lpExistingFileName">
        /// The current name of the file or directory on the local computer.
        /// If <paramref name="dwFlags"/> specifies <see cref="MOVEFILE_DELAY_UNTIL_REBOOT"/>, the file cannot exist on a remote share,
        /// because delayed operations are performed before the network is available.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File
        /// Tip
        /// Starting with Windows 10, version 1607, for the unicode version of this function (MoveFileExW),
        /// you can opt-in to remove the MAX_PATH limitation without prepending "\\?\".
        /// See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// </param>
        /// <param name="lpNewFileName">
        /// The new name of the file or directory on the local computer.
        /// When moving a file, the destination can be on a different file system or volume.
        /// If the destination is on another drive, you must set the <see cref="MOVEFILE_COPY_ALLOWED"/> flag in <paramref name="dwFlags"/>.
        /// When moving a directory, the destination must be on the same drive.
        /// If <paramref name="dwFlags"/> specifies <see cref="MOVEFILE_DELAY_UNTIL_REBOOT"/> and <paramref name="lpNewFileName"/> is <see cref="NULL"/>,
        /// <see cref="MoveFileEx"/> registers the <paramref name="lpExistingFileName"/> file to be deleted when the system restarts.
        /// The function fails if it cannot access the registry to store the information about the delete operation.
        /// If <paramref name="lpExistingFileName"/> refers to a directory, the system removes the directory at restart only if the directory is empty.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File
        /// Tip  Starting with Windows 10, version 1607, for the unicode version of this function (MoveFileExW),
        /// you can opt-in to remove the <see cref="MAX_PATH"/> limitation without prepending "\\?\".
        /// See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
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
        /// This parameter can be one or more of the following values.
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
        /// <see cref="MOVEFILE_FAIL_IF_NOT_TRACKABLE"/>:
        /// The function fails if the source file is a link source, but the file cannot be tracked after the move.
        /// This situation can occur if the destination is a volume formatted with the FAT file system.
        /// <see cref="MOVEFILE_REPLACE_EXISTING"/>:
        /// If a file named <paramref name="lpNewFileName"/> exists, the function replaces its contents with the contents of the <paramref name="lpExistingFileName"/> file,
        /// provided that security requirements regarding access control lists (ACLs) are met.
        /// For more information, see the Remarks section of this topic.
        /// If <paramref name="lpNewFileName"/> names an existing directory, an error is reported.
        /// <see cref="MOVEFILE_WRITE_THROUGH"/>:
        /// The function does not return until the file is actually moved on the disk.
        /// Setting this value guarantees that a move performed as a copy and delete operation is flushed to disk before the function returns.
        /// The flush occurs at the end of the copy operation.
        /// This value has no effect if <see cref="MOVEFILE_DELAY_UNTIL_REBOOT"/> is set.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// When moving a file across volumes, if lpProgressRoutine returns <see cref="PROGRESS_CANCEL"/> due to the user canceling the operation,
        /// <see cref="MoveFileWithProgress"/> will return zero and <see cref="GetLastError"/> will return <see cref="ERROR_REQUEST_ABORTED"/>. The existing file is left intact.
        /// When moving a file across volumes, if lpProgressRoutine returns <see cref="PROGRESS_STOP"/> due to the user stopping the operation,
        /// <see cref="MoveFileWithProgress"/> will return zero and <see cref="GetLastError"/> will return <see cref="ERROR_REQUEST_ABORTED"/>. The existing file is left intact.
        /// </returns>
        /// <remarks>
        /// The <see cref="MoveFileWithProgress"/> function coordinates its operation with the link tracking service, so link sources can be tracked as they are moved.
        /// To delete or rename a file, you must have either delete permission on the file or delete child permission in the parent directory.
        /// If you set up a directory with all access except delete and delete child and the ACLs of new files are inherited,
        /// then you should be able to create a file without being able to delete it.
        /// However, you can then create a file, and you will get all the access you request on the handle returned to you at the time you create the file.
        /// If you requested delete permission at the time you created the file, you could delete or rename the file with that handle but not with any other.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "MoveFileWithProgressW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL MoveFileWithProgress([In] LPCWSTR lpExistingFileName, [In] LPCWSTR lpNewFileName,
            [In] LPPROGRESS_ROUTINE lpProgressRoutine, [In] LPVOID lpData, [In] MoveFileFlags dwFlags);

        /// <summary>
        /// <para>
        /// Creates, opens, reopens, or deletes a file.
        /// Note This function has limited capabilities and is not recommended. For new application development, use the <see cref="CreateFile"/> function.
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// The name of the file.
        /// The string must consist of characters from the 8-bit Windows character set.
        /// The <see cref="OpenFile"/> function does not support Unicode file names or opening named pipes.
        /// </param>
        /// <param name="lpReOpenBuff">
        /// A pointer to the <see cref="OFSTRUCT"/> structure that receives information about a file when it is first opened.
        /// The structure can be used in subsequent calls to the OpenFile function to see an open file.
        /// The <see cref="OFSTRUCT"/> structure contains a path string member with a length that is limited to <see cref="OFS_MAXPATHNAME"/> characters,
        /// which is 128 characters.
        /// Because of this, you cannot use the <see cref="OpenFile"/> function to open a file with a path length that exceeds 128 characters.
        /// The <see cref="CreateFile"/> function does not have this path length limitation.
        /// </param>
        /// <param name="uStyle">
        /// The action to be taken.
        /// This parameter can be one or more of the following values.
        /// <see cref="OF_CANCEL"/>, <see cref="OF_CREATE"/>, <see cref="OF_DELETE"/>, <see cref="OF_EXIST"/>, <see cref="OF_PARSE"/>,
        /// <see cref="OF_PROMPT"/>, <see cref="OF_READ"/>, <see cref="OF_READWRITE"/>, <see cref="OF_REOPEN"/>, <see cref="OF_SHARE_COMPAT"/>,
        /// <see cref="OF_SHARE_DENY_NONE"/>, <see cref="OF_SHARE_DENY_READ"/>, <see cref="OF_SHARE_DENY_WRITE"/>, <see cref="OF_SHARE_EXCLUSIVE"/>,
        /// <see cref="OF_VERIFY"/>, <see cref="OF_WRITE"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value specifies a file handle to use when performing file I/O.
        /// To close the file, call the <see cref="CloseHandle"/> function using this handle.
        /// If the function fails, the return value is <see cref="HFILE_ERROR"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If the <paramref name="lpFileName"/> parameter specifies a file name and extension only,
        /// this function searches for a matching file in the following directories and the order shown:
        /// The directory where an application is loaded.
        /// The current directory.
        /// The Windows system directory.
        /// Use the <see cref="GetSystemDirectory"/> function to get the path of this directory.
        /// The 16-bit Windows system directory.
        /// There is not a function that retrieves the path of this directory, but it is searched.
        /// The Windows directory.
        /// Use the <see cref="GetWindowsDirectory"/> function to get the path of this directory.
        /// The directories that are listed in the PATH environment variable.
        /// The lpFileName parameter cannot contain wildcard characters.
        /// The <see cref="OpenFile"/> function does not support the OF_SEARCH flag that the 16-bit Windows <see cref="OpenFile"/> function supports.
        /// The OF_SEARCH flag directs the system to search for a matching file even when a file name includes a full path.
        /// Use the <see cref="SearchPath"/> function to search for a file.
        /// A sharing violation occurs if an attempt is made to open a file or directory for deletion on a remote machine
        /// when the value of the <paramref name="uStyle"/> parameter is the <see cref="OF_DELETE"/> access flag OR'ed with any other access flag,
        /// and the remote file or directory has not been opened with <see cref="FILE_SHARE_DELETE"/> share access.
        /// To avoid the sharing violation in this scenario, open the remote file or directory with <see cref="OF_DELETE"/> access only,
        /// or call <see cref="DeleteFile"/> without first opening the file or directory for deletion.
        /// </remarks>
        [Obsolete]
        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "OpenFile", ExactSpelling = true, SetLastError = true, ThrowOnUnmappableChar = true)]
        public static extern HFILE OpenFile([MarshalAs(UnmanagedType.LPStr)][In] string lpFileName, [In][Out] ref OFSTRUCT lpReOpenBuff, [In] OpenFileFlags uStyle);

        /// <summary>
        /// <para>
        /// Posts an I/O completion packet to an I/O completion port.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/fileio/postqueuedcompletionstatus"/>
        /// </para>
        /// </summary>
        /// <param name="CompletionPort">
        /// A handle to an I/O completion port to which the I/O completion packet is to be posted.
        /// </param>
        /// <param name="dwNumberOfBytesTransferred">
        /// The value to be returned through the lpNumberOfBytesTransferred parameter of the <see cref="GetQueuedCompletionStatus"/> function.
        /// </param>
        /// <param name="dwCompletionKey">
        /// The value to be returned through the lpCompletionKey parameter of the <see cref="GetQueuedCompletionStatus"/> function.
        /// </param>
        /// <param name="lpOverlapped">
        /// The value to be returned through the <paramref name="lpOverlapped"/> parameter of the <see cref="GetQueuedCompletionStatus"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="BOOL.TRUE"/>.
        /// If the function fails, the return value is <see cref="BOOL.FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The I/O completion packet will satisfy an outstanding call to the <see cref="GetQueuedCompletionStatus"/> function.
        /// This function returns with the three values passed as the second, third,
        /// and fourth parameters of the call to <see cref="PostQueuedCompletionStatus"/>.
        /// The system does not use or validate these values.
        /// In particular, the <paramref name="lpOverlapped"/> parameter need not point to an <see cref="OVERLAPPED"/> structure.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "PostQueuedCompletionStatus", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL PostQueuedCompletionStatus([In] HANDLE CompletionPort, [In] DWORD dwNumberOfBytesTransferred,
            [In] ULONG_PTR dwCompletionKey, [In][Out] ref OVERLAPPED lpOverlapped);

        /// <summary>
        /// <para>
        /// Retrieves information about MS-DOS device names.
        /// The function can obtain the current mapping for a particular MS-DOS device name.
        /// The function can also obtain a list of all existing MS-DOS device names.
        /// MS-DOS device names are stored as junctions in the object namespace.
        /// The code that converts an MS-DOS path into a corresponding path uses these junctions to map MS-DOS devices and drive letters.
        /// The <see cref="QueryDosDevice"/> function enables an application to query the names of the junctions
        /// used to implement the MS-DOS device namespace as well as the value of each specific junction.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-querydosdevicew"/>
        /// </para>
        /// </summary>
        /// <param name="lpDeviceName">
        /// An MS-DOS device name string specifying the target of the query.
        /// The device name cannot have a trailing backslash; for example, use "C:", not "C:\".
        /// This parameter can be <see cref="NULL"/>.
        /// In that case, the QueryDosDevice function will store a list of all existing MS-DOS device names into the buffer
        /// pointed to by <paramref name="lpTargetPath"/>.
        /// </param>
        /// <param name="lpTargetPath">
        /// A pointer to a buffer that will receive the result of the query.
        /// The function fills this buffer with one or more null-terminated strings.
        /// The final null-terminated string is followed by an additional <see cref="NULL"/>.
        /// If <paramref name="lpDeviceName"/> is non-NULL, the function retrieves information
        /// about the particular MS-DOS device specified by <paramref name="lpDeviceName"/>.
        /// The first null-terminated string stored into the buffer is the current mapping for the device.
        /// The other null-terminated strings represent undeleted prior mappings for the device.
        /// If <paramref name="lpDeviceName"/> is <see cref="NULL"/>, the function retrieves a list of all existing MS-DOS device names.
        /// Each null-terminated string stored into the buffer is the name of an existing MS-DOS device,
        /// for example, \Device\HarddiskVolume1 or \Device\Floppy0.
        /// </param>
        /// <param name="ucchMax">
        /// The maximum number of TCHARs that can be stored into the buffer pointed to by <paramref name="lpTargetPath"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the number of TCHARs stored into the buffer pointed to by <paramref name="lpTargetPath"/>.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If the buffer is too small, the function fails and the last error code is <see cref="ERROR_INSUFFICIENT_BUFFER"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="DefineDosDevice"/> function enables an application to create and modify the junctions used to implement the MS-DOS device namespace.
        /// Windows Server 2003 and Windows XP:
        /// <see cref="QueryDosDevice"/> first searches the Local MS-DOS Device namespace for the specified device name.
        /// If the device name is not found, the function will then search the Global MS-DOS Device namespace.
        /// When all existing MS-DOS device names are queried, the list of device names
        /// that are returned is dependent on whether it is running in the "LocalSystem" context.
        /// If so, only the device names included in the Global MS-DOS Device namespace will be returned.
        /// If not, a concatenation of the device names in the Global and Local MS-DOS Device namespaces will be returned.
        /// If a device name exists in both namespaces, <see cref="QueryDosDevice"/> will return the entry in the Local MS-DOS Device namespace.
        /// For more information on the Global and Local MS-DOS Device namespaces and changes to the accessibility of MS-DOS device names,
        /// see Defining an MS DOS Device Name.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "QueryDosDeviceW", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD QueryDosDevice([In] LPCWSTR lpDeviceName, [In] IntPtr lpTargetPath, [In] DWORD ucchMax);

        /// <summary>
        /// <para>
        /// Retrieves information that describes the changes within the specified directory.
        /// The function does not report changes to the specified directory itself.
        /// To track changes on a volume, see change journals.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-readdirectorychangesw"/>
        /// </para>
        /// </summary>
        /// <param name="hDirectory">
        /// A handle to the directory to be monitored.
        /// This directory must be opened with the <see cref="FILE_LIST_DIRECTORY"/> access right,
        /// or an access right such as <see cref="GENERIC_READ"/> that includes the <see cref="FILE_LIST_DIRECTORY"/> access right.
        /// </param>
        /// <param name="lpBuffer">
        /// A pointer to the DWORD-aligned formatted buffer in which the read results are to be returned.
        /// The structure of this buffer is defined by the <see cref="FILE_NOTIFY_INFORMATION"/> structure.
        /// This buffer is filled either synchronously or asynchronously, depending on how the directory is opened
        /// and what value is given to the <paramref name="lpOverlapped"/> parameter.
        /// For more information, see the Remarks section.
        /// </param>
        /// <param name="nBufferLength">
        /// The size of the buffer that is pointed to by the <paramref name="lpBuffer"/> parameter, in bytes.
        /// </param>
        /// <param name="bWatchSubtree">
        /// If this parameter is <see cref="TRUE"/>, the function monitors the directory tree rooted at the specified directory.
        /// If this parameter is <see cref="FALSE"/>, the function monitors only the directory specified by the <paramref name="hDirectory"/> parameter.
        /// </param>
        /// <param name="dwNotifyFilter">
        /// The filter criteria that the function checks to determine if the wait operation has completed.
        /// This parameter can be one or more of the following values.
        /// <see cref="FILE_NOTIFY_CHANGE_FILE_NAME"/>, <see cref="FILE_NOTIFY_CHANGE_DIR_NAME"/>, <see cref="FILE_NOTIFY_CHANGE_ATTRIBUTES"/>,
        /// <see cref="FILE_NOTIFY_CHANGE_SIZE"/>, <see cref="FILE_NOTIFY_CHANGE_LAST_WRITE"/>, <see cref="FILE_NOTIFY_CHANGE_LAST_ACCESS"/>,
        /// <see cref="FILE_NOTIFY_CHANGE_CREATION"/>, <see cref="FILE_NOTIFY_CHANGE_SECURITY"/>
        /// </param>
        /// <param name="lpBytesReturned">
        /// For synchronous calls, this parameter receives the number of bytes transferred into the <paramref name="lpBuffer"/> parameter.
        /// For asynchronous calls, this parameter is undefined.
        /// You must use an asynchronous notification technique to retrieve the number of bytes transferred.
        /// </param>
        /// <param name="lpOverlapped">
        /// A pointer to an <see cref="OVERLAPPED"/> structure that supplies data to be used during asynchronous operation.
        /// Otherwise, this value is <see cref="NullRef{OVERLAPPED}"/>.
        /// The <see cref="OVERLAPPED.Offset"/> and <see cref="OVERLAPPED.OffsetHigh"/> members of this structure are not used.
        /// </param>
        /// <param name="lpCompletionRoutine">
        /// A pointer to a completion routine to be called when the operation has been completed or canceled
        /// and the calling thread is in an alertable wait state.
        /// For more information about this completion routine, see <see cref="LPOVERLAPPED_COMPLETION_ROUTINE"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// For synchronous calls, this means that the operation succeeded.
        /// For asynchronous calls, this indicates that the operation was successfully queued.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If the network redirector or the target file system does not support this operation,
        /// the function fails with <see cref="ERROR_INVALID_FUNCTION"/>.
        /// </returns>
        /// <remarks>
        /// To obtain a handle to a directory, use the <see cref="CreateFile"/> function with the <see cref="FILE_FLAG_BACKUP_SEMANTICS"/> flag.
        /// A call to <see cref="ReadDirectoryChangesW"/> can be completed synchronously or asynchronously.
        /// To specify asynchronous completion, open the directory with <see cref="CreateFile"/> as shown above,
        /// but additionally specify the <see cref="FILE_FLAG_OVERLAPPED"/> attribute in the dwFlagsAndAttributes parameter.
        /// Then specify an <see cref="OVERLAPPED"/> structure when you call <see cref="ReadDirectoryChangesW"/>.
        /// When you first call <see cref="ReadDirectoryChangesW"/>, the system allocates a buffer to store change information.
        /// This buffer is associated with the directory handle until it is closed and its size does not change during its lifetime.
        /// Directory changes that occur between calls to this function are added to the buffer and then returned with the next call.
        /// If the buffer overflows, <see cref="ReadDirectoryChangesW"/> will still return <see cref="TRUE"/>,
        /// but the entire contents of the buffer are discarded and the <paramref name="lpBytesReturned"/> parameter will be zero,
        /// which indicates that your buffer was too small to hold all of the changes that occurred.
        /// Upon successful synchronous completion, the <paramref name="lpBuffer"/> parameter is a formatted buffer
        /// and the number of bytes written to the buffer is available in <paramref name="lpBytesReturned"/>.
        /// If the number of bytes transferred is zero, the buffer was either too large for the system
        /// to allocate or too small to provide detailed information on all the changes that occurred in the directory or subtree.
        /// In this case, you should compute the changes by enumerating the directory or subtree.
        /// For asynchronous completion, you can receive notification in one of three ways:
        /// Using the <see cref="GetOverlappedResult"/> function. To receive notification through <see cref="GetOverlappedResult"/>,
        /// do not specify a completion routine in the <paramref name="lpCompletionRoutine"/> parameter.
        /// Be sure to set the <see cref="OVERLAPPED.hEvent"/> member of the <see cref="OVERLAPPED"/> structure to a unique event.
        /// Using the <see cref="GetQueuedCompletionStatus"/> function.
        /// To receive notification through <see cref="GetQueuedCompletionStatus"/>,
        /// do not specify a completion routine in <paramref name="lpCompletionRoutine"/>.
        /// Associate the directory handle hDirectory with a completion port by calling the <see cref="CreateIoCompletionPort"/> function.
        /// Using a completion routine.
        /// To receive notification through a completion routine, do not associate the directory with a completion port.
        /// Specify a completion routine in <paramref name="lpCompletionRoutine"/>.
        /// This routine is called whenever the operation has been completed or canceled while the thread is in an alertable wait state. 
        /// The <see cref="OVERLAPPED.hEvent"/> member of the <see cref="OVERLAPPED"/> structure is not used by the system, so you can use it yourself.
        /// For more information, see Synchronous and Asynchronous I/O.
        /// <see cref="ReadDirectoryChangesW"/> fails with <see cref="ERROR_INVALID_PARAMETER"/> when the buffer length is greater than 64 KB
        /// and the application is monitoring a directory over the network.
        /// This is due to a packet size limitation with the underlying file sharing protocols.
        /// <see cref="ReadDirectoryChangesW"/> fails with <see cref="ERROR_NOACCESS"/> when the buffer is not aligned on a <see cref="DWORD"/> boundary.
        /// If you opened the file using the short name, you can receive change notifications for the short name.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ReadDirectoryChangesW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ReadDirectoryChangesW([In] HANDLE hDirectory, [In] LPVOID lpBuffer, [In] DWORD nBufferLength, [In] BOOL bWatchSubtree,
            [In] FileNotifyFilters dwNotifyFilter, [Out] out DWORD lpBytesReturned, [In][Out] ref OVERLAPPED lpOverlapped,
            [In] LPOVERLAPPED_COMPLETION_ROUTINE lpCompletionRoutine);

        /// <summary>
        /// <para>
        /// Reads data from the specified file or input/output (I/O) device.
        /// Reads occur at the position specified by the file pointer if supported by the device.
        /// This function is designed for both synchronous and asynchronous operations.
        /// For a similar function designed solely for asynchronous operation, see <see cref="ReadFileEx"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-readfile"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the device (for example, a file, file stream, physical disk, volume, console buffer, tape drive,
        /// socket, communications resource, mailslot, or pipe).
        /// The hFile parameter must have been created with read access.
        /// For more information, see Generic Access Rights and File Security and Access Rights.
        /// For asynchronous read operations, <paramref name="hFile"/> can be any handle that is opened
        /// with the <see cref="FILE_FLAG_OVERLAPPED"/> flag by the <see cref="CreateFile"/> function,
        /// or a socket handle returned by the socket or accept function.
        /// </param>
        /// <param name="lpBuffer">
        /// A pointer to the buffer that receives the data read from a file or device.
        /// This buffer must remain valid for the duration of the read operation.
        /// The caller must not use this buffer until the read operation is completed.
        /// </param>
        /// <param name="nNumberOfBytesToRead">
        /// The maximum number of bytes to be read.
        /// </param>
        /// <param name="lpNumberOfBytesWritten">
        /// A pointer to the variable that receives the number of bytes read when using a synchronous <paramref name="hFile"/> parameter.
        /// <see cref="ReadFile"/> sets this value to zero before doing any work or error checking.
        /// Use <see langword="null"/> for this parameter if this is an asynchronous operation to avoid potentially erroneous results.
        /// This parameter can be <see langword="null"/>  only when the <paramref name="lpOverlapped"/> parameter is not <see langword="null"/>.
        /// For more information, see the Remarks section.
        /// </param>
        /// <param name="lpOverlapped">
        /// A pointer to an <see cref="OVERLAPPED"/> structure is required if the <paramref name="hFile"/> parameter was opened
        /// with <see cref="FILE_FLAG_OVERLAPPED"/>, otherwise it can be <see langword="null"/>.
        /// If <paramref name="hFile"/> is opened with <see cref="FILE_FLAG_OVERLAPPED"/>,
        /// the <paramref name="lpOverlapped"/> parameter must point to a valid and unique <see cref="OVERLAPPED"/> structure,
        /// otherwise the function can incorrectly report that the read operation is complete.
        /// For an <paramref name="hFile"/> that supports byte offsets, if you use this parameter you must specify a byte offset
        /// at which to start reading from the file or device.
        /// This offset is specified by setting the <see cref="OVERLAPPED.Offset"/> and <see cref="OVERLAPPED.OffsetHigh"/> members
        /// of the <see cref="OVERLAPPED"/> structure.
        /// For an <paramref name="hFile"/> that does not support byte offsets, <see cref="OVERLAPPED.Offset"/>
        /// and <see cref="OVERLAPPED.OffsetHigh"/> are ignored.
        /// For more information about different combinations of <paramref name="lpOverlapped"/> and <see cref="FILE_FLAG_OVERLAPPED"/>,
        /// see the Remarks section and the Synchronization and File Position section.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, or is completing asynchronously, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call the <see cref="GetLastError"/> function.
        /// Note The <see cref="GetLastError"/> code <see cref="ERROR_IO_PENDING"/> is not a failure;
        /// it designates the read operation is pending completion asynchronously.
        /// For more information, see Remarks.
        /// </returns>
        /// <remarks>
        /// The <see cref="ReadFile"/> function returns when one of the following conditions occur:
        /// The number of bytes requested is read.
        /// A write operation completes on the write end of the pipe.
        /// An asynchronous handle is being used and the read is occurring asynchronously.
        /// An error occurs.
        /// The <see cref="ReadFile"/> function may fail with <see cref="ERROR_INVALID_USER_BUFFER"/> or <see cref="ERROR_NOT_ENOUGH_MEMORY"/>
        /// whenever there are too many outstanding asynchronous I/O requests.
        /// To cancel all pending asynchronous I/O operations, use either:
        /// <see cref="CancelIo"/>—this function only cancels operations issued by the calling thread for the specified file handle.
        /// <see cref="CancelIoEx"/>—this function cancels all operations issued by the threads for the specified file handle.
        /// Use <see cref="CancelSynchronousIo"/> to cancel pending synchronous I/O operations.
        /// I/O operations that are canceled complete with the error <see cref="ERROR_OPERATION_ABORTED"/>.
        /// The <see cref="ReadFile"/> function may fail with <see cref="ERROR_NOT_ENOUGH_QUOTA"/>,
        /// which means the calling process's buffer could not be page-locked.
        /// For additional information, see <see cref="SetProcessWorkingSetSize"/>.
        /// If part of a file is locked by another process and the read operation overlaps the locked portion, this function fails.
        /// Accessing the input buffer while a read operation is using the buffer may lead to corruption of the data read into that buffer.
        /// Applications must not read from, write to, reallocate, or free the input buffer that a read operation is using until the read operation completes.
        /// This can be particularly problematic when using an asynchronous file handle.
        /// Additional information regarding synchronous versus asynchronous file handles can be found in the Synchronization and File Position section
        /// and in the <see cref="CreateFile"/> reference topic.
        /// Characters can be read from the console input buffer by using <see cref="ReadFile"/> with a handle to console input.
        /// The console mode determines the exact behavior of the <see cref="ReadFile"/> function.
        /// By default, the console mode is <see cref="ENABLE_LINE_INPUT"/>,
        /// which indicates that <see cref="ReadFile"/> should read until it reaches a carriage return.
        /// If you press Ctrl+C, the call succeeds, but <see cref="GetLastError"/> returns <see cref="ERROR_OPERATION_ABORTED"/>.
        /// For more information, see <see cref="CreateFile"/>.
        /// When reading from a communications device, the behavior of <see cref="ReadFile"/> is determined by the current communication time-out
        /// as set and retrieved by using the <see cref="SetCommTimeouts"/> and <see cref="GetCommTimeouts"/> functions.
        /// Unpredictable results can occur if you fail to set the time-out values.
        /// For more information about communication time-outs, see <see cref="COMMTIMEOUTS"/>.
        /// If <see cref="ReadFile"/> attempts to read from a mailslot that has a buffer that is too small,
        /// the function returns <see cref="FALSE"/> and <see cref="GetLastError"/> returns <see cref="ERROR_INSUFFICIENT_BUFFER"/>.
        /// There are strict requirements for successfully working with files opened
        /// with <see cref="CreateFile"/> using the <see cref="FILE_FLAG_NO_BUFFERING"/> flag.
        /// For details see File Buffering.
        /// If <paramref name="hFile"/> was opened with <see cref="FILE_FLAG_OVERLAPPED"/>, the following conditions are in effect:
        /// The <paramref name="lpOverlapped"/> parameter must point to a valid and unique <see cref="OVERLAPPED"/> structure,
        /// otherwise the function can incorrectly report that the read operation is complete.
        /// The <paramref name="lpNumberOfBytesWritten"/> parameter should be set to <see langword="null"/>.
        /// Use the <see cref="GetOverlappedResult"/> function to get the actual number of bytes read.
        /// If the <paramref name="hFile"/> parameter is associated with an I/O completion port,
        /// you can also get the number of bytes read by calling the <see cref="GetQueuedCompletionStatus"/> function.
        /// Synchronization and File Position
        /// If <paramref name="hFile"/> is opened with <see cref="FILE_FLAG_OVERLAPPED"/>, it is an asynchronous file handle; otherwise it is synchronous.
        /// The rules for using the <see cref="OVERLAPPED"/> structure are slightly different for each, as previously noted.
        /// Note If a file or device is opened for asynchronous I/O, subsequent calls to functions such as <see cref="ReadFile"/> using
        /// that handle generally return immediately, but can also behave synchronously with respect to blocked execution.
        /// For more information see http://support.microsoft.com/kb/156932.
        /// Considerations for working with asynchronous file handles:
        /// <see cref="ReadFile"/> may return before the read operation is complete.
        /// In this scenario, <see cref="ReadFile"/> returns <see cref="FALSE"/> and the <see cref="GetLastError"/> function
        /// returns <see cref="ERROR_IO_PENDING"/>, which allows the calling process to continue while the system completes the read operation.
        /// The <paramref name="lpOverlapped"/> parameter must not be <see langword="null"/> and should be used with the following facts in mind:
        /// Although the event specified in the <see cref="OVERLAPPED"/> structure is set and reset automatically by the system,
        /// the offset that is specified in the <see cref="OVERLAPPED"/> structure is not automatically updated.
        /// <see cref="ReadFile"/> resets the event to a nonsignaled state when it begins the I/O operation.
        /// The event specified in the <see cref="OVERLAPPED"/> structure is set to a signaled state when the read operation is complete;
        /// until that time, the read operation is considered pending.
        /// Because the read operation starts at the offset that is specified in the <see cref="OVERLAPPED"/> structure,
        /// and <see cref="ReadFile"/> may return before the system-level read operation is complete (read pending),
        /// neither the offset nor any other part of the structure should be modified, freed,
        /// or reused by the application until the event is signaled (that is, the read completes).
        /// If end-of-file (EOF) is detected during asynchronous operations, the call to <see cref="GetOverlappedResult"/>
        /// for that operation returns <see cref="FALSE"/> and <see cref="GetLastError"/> returns <see cref="ERROR_HANDLE_EOF"/>.
        /// Considerations for working with synchronous file handles:
        /// If <paramref name="lpOverlapped"/> is <see langword="null"/>, the read operation starts at the current file position
        /// and <see cref="ReadFile"/> does not return until the operation is complete,
        /// and the system updates the file pointer before <see cref="ReadFile"/> returns.
        /// If <paramref name="lpOverlapped"/> is not <see langword="null"/>,
        /// the read operation starts at the offset that is specified in the <see cref="OVERLAPPED"/> structure
        /// and <see cref="ReadFile"/> does not return until the read operation is complete.
        /// The system updates the <see cref="OVERLAPPED"/> offset before <see cref="ReadFile"/> returns.
        /// If <paramref name="lpOverlapped"/> is <see langword="null"/>, then when a synchronous read operation reaches the end of a file,
        /// <see cref="ReadFile"/> returns <see cref="TRUE"/> and sets *<paramref name="lpNumberOfBytesWritten"/> to zero.
        /// If <paramref name="lpOverlapped"/> is not <see langword="null"/>, then when a synchronous read operation reaches the end of a file,
        /// <see cref="ReadFile"/> returns <see cref="FALSE"/> and <see cref="GetLastError"/> returns <see cref="ERROR_HANDLE_EOF"/>.
        /// For more information, see <see cref="CreateFile"/> and Synchronous and Asynchronous I/O.
        /// Pipes
        /// If an anonymous pipe is being used and the write handle has been closed,
        /// when <see cref="ReadFile"/> attempts to read using the pipe's corresponding read handle,
        /// the function returns <see cref="FALSE"/> and <see cref="GetLastError"/> returns <see cref="ERROR_BROKEN_PIPE"/>.
        /// If a named pipe is being read in message mode and the next message is longer than the <paramref name="nNumberOfBytesToRead"/> parameter specifies,
        /// <see cref="ReadFile"/> returns <see cref="FALSE"/> and <see cref="GetLastError"/> returns <see cref="ERROR_MORE_DATA"/>.
        /// The remainder of the message can be read by a subsequent call to the <see cref="ReadFile"/> or <see cref="PeekNamedPipe"/> function.
        /// If the <paramref name="lpNumberOfBytesWritten"/> parameter is zero when <see cref="ReadFile"/> returns <see cref="TRUE"/> on a pipe,
        /// the other end of the pipe called the <see cref="WriteFile"/> function with <paramref name="nNumberOfBytesToRead"/> set to zero.
        /// For more information about pipes, see Pipes.
        /// Transacted Operations
        /// If there is a transaction bound to the file handle, then the function returns data from the transacted view of the file.
        /// A transacted read handle is guaranteed to show the same view of a file for the duration of the handle.
        /// For more information, see About Transactional NTFS.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ReadFile", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ReadFile([In] HANDLE hFile, [In] LPVOID lpBuffer, [In] DWORD nNumberOfBytesToRead,
            [Out] out DWORD lpNumberOfBytesWritten, [In] in OVERLAPPED lpOverlapped);

        /// <summary>
        /// <para>
        /// Reads data from the specified file or input/output (I/O) device.
        /// It reports its completion status asynchronously, calling the specified completion routine
        /// when reading is completed or canceled and the calling thread is in an alertable wait state.
        /// To read data from a file or device synchronously, use the <see cref="ReadFile"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-readfileex"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the file or I/O device (for example, a file, file stream, physical disk, volume, console buffer,
        /// tape drive, socket, communications resource, mailslot, or pipe).
        /// This parameter can be any handle opened with the <see cref="FILE_FLAG_OVERLAPPED"/> flag by the <see cref="CreateFile"/> function,
        /// or a socket handle returned by the socket or accept function.
        /// This handle also must have the <see cref="GENERIC_READ"/> access right.
        /// For more information on access rights, see File Security and Access Rights.
        /// </param>
        /// <param name="lpBuffer">
        /// A pointer to a buffer that receives the data read from the file or device.
        /// This buffer must remain valid for the duration of the read operation.
        /// The application should not use this buffer until the read operation is completed.
        /// </param>
        /// <param name="nNumberOfBytesToRead">
        /// The number of bytes to be read.
        /// </param>
        /// <param name="lpOverlapped">
        /// A pointer to an <see cref="OVERLAPPED"/> data structure that supplies data to be used during the asynchronous (overlapped) file read operation.
        /// For files that support byte offsets, you must specify a byte offset at which to start reading from the file.
        /// You specify this offset by setting the <see cref="OVERLAPPED.Offset"/> and <see cref="OVERLAPPED.OffsetHigh"/> members
        /// of the <see cref="OVERLAPPED"/> structure.
        /// For files or devices that do not support byte offsets, <see cref="OVERLAPPED.Offset"/> and <see cref="OVERLAPPED.OffsetHigh"/> are ignored.
        /// The <see cref="ReadFileEx"/> function ignores the <see cref="OVERLAPPED"/> structure's <see cref="OVERLAPPED.hEvent"/> member.
        /// An application is free to use that member for its own purposes in the context of a <see cref="ReadFileEx"/> call.
        /// <see cref="ReadFileEx"/> signals completion of its read operation by calling, or queuing a call to,
        /// the completion routine pointed to by <paramref name="lpCompletionRoutine"/>, so it does not need an event handle.
        /// The ReadFileEx function does use the <see cref="OVERLAPPED"/> structure's <see cref="OVERLAPPED.Internal"/>
        /// and <see cref="OVERLAPPED.InternalHigh"/> members. An application should not set these members.
        /// The <see cref="OVERLAPPED"/> data structure must remain valid for the duration of the read operation.
        /// It should not be a variable that can go out of scope while the read operation is pending completion.
        /// </param>
        /// <param name="lpCompletionRoutine">
        /// A pointer to the completion routine to be called when the read operation is complete and the calling thread is in an alertable wait state.
        /// For more information about the completion routine, see <see cref="LPOVERLAPPED_COMPLETION_ROUTINE"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If the function succeeds, the calling thread has an asynchronous I/O operation pending: the overlapped read operation from the file.
        /// When this I/O operation completes, and the calling thread is blocked in an alertable wait state,
        /// the system calls the function pointed to by <paramref name="lpCompletionRoutine"/>,
        /// and the wait state completes with a return code of <see cref="WAIT_IO_COMPLETION"/>.
        /// If the function succeeds, and the file reading operation completes, but the calling thread is not in an alertable wait state,
        /// the system queues the completion routine call, holding the call until the calling thread enters an alertable wait state.
        /// For information about alertable waits and overlapped input/output operations, see About Synchronization.
        /// If <see cref="ReadFileEx"/> attempts to read past the end-of-file (EOF), the call to <see cref="GetOverlappedResult"/>
        /// for that operation returns <see cref="FALSE"/> and <see cref="GetLastError"/> returns <see cref="ERROR_HANDLE_EOF"/>.
        /// </returns>
        /// <remarks>
        /// When using <see cref="ReadFileEx"/> you should check <see cref="GetLastError"/> even
        /// when the function returns "success" to check for conditions that are "successes" but have some outcome you might want to know about.
        /// For example, a buffer overflow when calling <see cref="ReadFileEx"/> will return <see cref="TRUE"/>,
        /// but <see cref="GetLastError"/> will report the overflow with <see cref="ERROR_MORE_DATA"/>.
        /// If the function call is successful and there are no warning conditions, <see cref="GetLastError"/> will return <see cref="ERROR_SUCCESS"/>.
        /// The <see cref="ReadFileEx"/> function may fail if there are too many outstanding asynchronous I/O requests.
        /// In the event of such a failure, <see cref="GetLastError"/> can return
        /// <see cref="ERROR_INVALID_USER_BUFFER"/> or <see cref="ERROR_NOT_ENOUGH_MEMORY"/>.
        /// To cancel all pending asynchronous I/O operations, use either:
        /// <see cref="CancelIo"/>—this function only cancels operations issued by the calling thread for the specified file handle.
        /// <see cref="CancelIoEx"/>—this function cancels all operations issued by the threads for the specified file handle.
        /// Use <see cref="CancelSynchronousIo"/> to cancel pending synchronous I/O operations.
        /// I/O operations that are canceled complete with the error <see cref="ERROR_OPERATION_ABORTED"/>.
        /// If part of the file specified by <paramref name="hFile"/> is locked by another process, and the read operation specified in a call
        /// to <see cref="ReadFileEx"/> overlaps the locked portion, the call to <see cref="ReadFileEx"/> fails.
        /// When attempting to read data from a mailslot whose buffer is too small, <see cref="ReadFileEx"/> returns <see cref="FALSE"/>,
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_INSUFFICIENT_BUFFER"/>.
        /// Accessing the input buffer while a read operation is using the buffer may lead to corruption of the data read into that buffer.
        /// Applications must not read from, write to, reallocate, or free the input buffer that a read operation is using until the read operation completes.
        /// An application uses the <see cref="MsgWaitForMultipleObjectsEx"/>, <see cref="WaitForSingleObjectEx"/>,
        /// <see cref="WaitForMultipleObjectsEx"/>, and <see cref="SleepEx"/> functions to enter an alertable wait state.
        /// For more information about alertable waits and overlapped input/output, see About Synchronization.
        /// There are strict requirements for successfully working with files opened with <see cref="CreateFile"/> using <see cref="FILE_FLAG_NO_BUFFERING"/>.
        /// For details see File Buffering.
        /// Transacted Operations
        /// If there is a transaction bound to the file handle, then the function returns data from the transacted view of the file.
        /// A transacted read handle is guaranteed to show the same view of a file for the duration of the handle.
        /// For additional information, see About Transactional NTFS.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ReadFileEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ReadFileEx([In] HANDLE hFile, [In] LPVOID lpBuffer, [In] DWORD nNumberOfBytesToRead,
            [In] in OVERLAPPED lpOverlapped, [In] LPOVERLAPPED_COMPLETION_ROUTINE lpCompletionRoutine);

        /// <summary>
        /// <para>
        /// Reads data from a file and stores it in an array of buffers.
        /// The function starts reading data from the file at a position that is specified by an <see cref="OVERLAPPED"/> structure.
        /// The <see cref="ReadFileScatter"/> function operates asynchronously.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-readfilescatter"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the file to be read.
        /// The file handle must be created with the <see cref="GENERIC_READ"/> right,
        /// and the <see cref="FILE_FLAG_OVERLAPPED"/> and <see cref="FILE_FLAG_NO_BUFFERING"/> flags.
        /// For more information, see File Security and Access Rights.
        /// </param>
        /// <param name="aSegmentArray">
        /// A pointer to an array of <see cref="FILE_SEGMENT_ELEMENT"/> buffers that receives the data.
        /// For a description of this union, see Remarks.
        /// Each element can receive one page of data.
        /// Note
        /// To determine the size of a system page, use <see cref="GetSystemInfo"/>.
        /// The array must contain enough elements to store <paramref name="nNumberOfBytesToRead"/> bytes of data, plus one element for the terminating NULL.
        /// For example, if there are 40 KB to be read and the page size is 4 KB, the array must have 11 elements that includes 10 for the data and one for the NULL.
        /// Each buffer must be at least the size of a system memory page and must be aligned on a system memory page size boundary.
        /// The system reads one system memory page of data into each buffer.
        /// The function stores the data in the buffers in sequential order.
        /// For example, it stores data into the first buffer, then into the second buffer, and so on until each buffer is filled and all the data is stored,
        /// or there are no more buffers.
        /// </param>
        /// <param name="nNumberOfBytesToRead">
        /// The total number of bytes to be read from the file.
        /// Each element of <paramref name="aSegmentArray"/> contains a one-page chunk of this total.
        /// Because the file must be opened with <see cref="FILE_FLAG_NO_BUFFERING"/>,
        /// the number of bytes must be a multiple of the sector size of the file system where the file is located.
        /// </param>
        /// <param name="lpReserved">
        /// This parameter is reserved for future use and must be <see cref="NULL"/>.
        /// </param>
        /// <param name="lpOverlapped">
        /// A pointer to an <see cref="OVERLAPPED"/> data structure.
        /// The <see cref="ReadFileScatter"/> function requires a valid <see cref="OVERLAPPED"/> structure.
        /// The <paramref name="lpOverlapped"/> parameter cannot be <see cref="NullRef{OVERLAPPED}"/>.
        /// The <see cref="ReadFileScatter"/> function starts reading data from the file at a position
        /// that is specified by the <see cref="OVERLAPPED.Offset"/> and <see cref="OVERLAPPED.OffsetHigh"/> members of the <see cref="OVERLAPPED"/> structure.
        /// The <see cref="ReadFileScatter"/> function may return before the read operation is complete.
        /// In that scenario, the <see cref="ReadFileScatter"/> function returns the value 0 (zero),
        /// and the <see cref="GetLastError"/> function returns the value <see cref="ERROR_IO_PENDING"/>.
        /// This asynchronous operation of <see cref="ReadFileScatter"/> lets the calling process continue while the read operation completes.
        /// You can call the <see cref="GetOverlappedResult"/>, <see cref="HasOverlappedIoCompleted"/>,
        /// or <see cref="GetQueuedCompletionStatus"/> functions to obtain information about the completion of the read operation.
        /// For more information, see Synchronous and Asynchronous I/O.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call the <see cref="GetLastError"/> function.
        /// If <see cref="ReadFileScatter"/> attempts to read past the end-of-file (EOF),
        /// the call to <see cref="GetOverlappedResult"/> for that operation returns <see cref="FALSE"/>
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_HANDLE_EOF"/>.
        /// If the function returns before the read operation is complete, the function returns <see cref="FALSE"/>,
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_IO_PENDING"/>.
        /// </returns>
        /// <remarks>
        /// This function is not supported for 32-bit applications by WOW64 on Itanium-based systems.
        /// Assigning a pointer to the <see cref="FILE_SEGMENT_ELEMENT.Buffer"/> member will sign-extend the value if the code is compiled as 32-bits;
        /// this can break large-address aware applications running on systems configured with 4-Gigabyte Tuning or running on under WOW64 on 64-bit Windows.
        /// Therefore, use the PtrToPtr64 macro when assigning pointers to <see cref="FILE_SEGMENT_ELEMENT.Buffer"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ReadFileScatter", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ReadFileScatter([In] HANDLE hFile, [In] FILE_SEGMENT_ELEMENT[] aSegmentArray, [In] DWORD nNumberOfBytesToRead,
            [In] IntPtr lpReserved, [In][Out] ref OVERLAPPED lpOverlapped);

        /// <summary>
        /// <para>
        /// Deletes an existing empty directory.
        /// To perform this operation as a transacted operation, use the <see cref="RemoveDirectoryTransacted"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-removedirectoryw"/>
        /// </para>
        /// </summary>
        /// <param name="lpPathName">
        /// The path of the directory to be removed.
        /// This path must specify an empty directory,and the calling process must have delete access to the directory.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\\?\" to the path.
        /// For more information, see Naming a File.
        /// Tip Starting with Windows 10, version 1607, for the unicode version of this function (<see cref="RemoveDirectory"/>),
        /// you can opt-in to remove the <see cref="MAX_PATH"/> limitation without prepending "\\?\".
        /// See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="RemoveDirectory"/> function marks a directory for deletion on close.
        /// Therefore, the directory is not removed until the last handle to the directory is closed.
        /// To recursively delete the files in a directory, use the <see cref="SHFileOperation"/> function.
        /// <see cref="RemoveDirectory"/> removes a directory junction, even if the contents of the target are not empty;
        /// the function removes directory junctions regardless of the state of the target object.
        /// For more information on junctions, see Hard Links and Junctions.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "RemoveDirectoryW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL RemoveDirectory([In] LPCWSTR lpPathName);

        /// <summary>
        /// <para>
        /// Reopens the specified file system object with different access rights, sharing mode, and flags.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-reopenfile"/>
        /// </para>
        /// </summary>
        /// <param name="hOriginalFile">
        /// A handle to the object to be reopened.
        /// The object must have been created by the <see cref="CreateFile"/> function.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// The required access to the object. For a list of values, see File Security and Access Rights.
        /// You cannot request an access mode that conflicts with the sharing mode specified in a previous open request whose handle is still open.
        /// If this parameter is zero (0), the application can query device attributes without accessing the device. 
        /// This is useful if an application wants to determine the size of a floppy disk drive and the formats it supports without requiring a floppy in the drive.
        /// </param>
        /// <param name="dwShareMode">
        /// The sharing mode of the object.
        /// You cannot request a sharing mode that conflicts with the access mode specified in a previous open request whose handle is still open.
        /// If this parameter is zero (0) and <see cref="CreateFile"/> succeeds, the object cannot be shared and cannot be opened again until the handle is closed.
        /// To enable other processes to share the object while your process has it open,
        /// use a combination of one or more of the following values to specify the type of access they can request when they open the object.
        /// These sharing options remain in effect until you close the handle to the object.
        /// <see cref="FILE_SHARE_DELETE"/>, <see cref="FILE_SHARE_READ"/>, <see cref="FILE_SHARE_WRITE"/>
        /// </param>
        /// <param name="dwFlagsAndAttributes">
        /// The file flags.
        /// This parameter can be one or more of the following values.
        /// <see cref="FILE_FLAG_BACKUP_SEMANTICS"/>, <see cref="FILE_FLAG_DELETE_ON_CLOSE"/>, <see cref="FILE_FLAG_NO_BUFFERING"/>,
        /// <see cref="FILE_FLAG_OPEN_NO_RECALL"/>, <see cref="FILE_FLAG_OPEN_REPARSE_POINT"/>, <see cref="FILE_FLAG_OVERLAPPED"/>,
        /// <see cref="FILE_FLAG_POSIX_SEMANTICS"/>, <see cref="FILE_FLAG_RANDOM_ACCESS"/>, <see cref="FILE_FLAG_SEQUENTIAL_SCAN"/>,
        /// <see cref="FILE_FLAG_WRITE_THROUGH"/>
        /// If the handle represents the client side of a named pipe, the <paramref name="dwFlagsAndAttributes"/> parameter
        /// can also contain Security Quality of Service information.
        /// For more information, see Impersonation Levels.
        /// When the calling application specifies the <see cref="SECURITY_SQOS_PRESENT"/> flag,
        /// the <paramref name="dwFlagsAndAttributes"/> parameter can contain one or more of the following values.
        /// <see cref="SECURITY_ANONYMOUS"/>/ <see cref="SECURITY_CONTEXT_TRACKING"/>, <see cref="SECURITY_DELEGATION"/>,
        /// <see cref="SECURITY_EFFECTIVE_ONLY"/>, <see cref="SECURITY_IDENTIFICATION"/>, <see cref="SECURITY_IMPERSONATION"/>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is an open handle to the specified file.
        /// If the function fails, the return value is <see cref="INVALID_HANDLE_VALUE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <paramref name="dwFlagsAndAttributes"/> parameter cannot contain any of the file attribute flags (FILE_ATTRIBUTE_*).
        /// These can only be specified when the file is created.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ReOpenFile", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE ReOpenFile([In] HANDLE hOriginalFile, [In] ACCESS_MASK dwDesiredAccess,
            [In] FileShareModes dwShareMode, [In] DWORD dwFlagsAndAttributes);

        /// <summary>
        /// <para>
        /// Replaces one file with another file, with the option of creating a backup copy of the original file. 
        /// The replacement file assumes the name of the replaced file and its identity.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-replacefilew"/>
        /// </para>
        /// </summary>
        /// <param name="lpReplacedFileName">
        /// The name of the file to be replaced.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File.
        /// Tip Starting with Windows 10, version 1607, for the unicode version of this function (<see cref="ReplaceFile"/>),
        /// you can opt-in to remove the <see cref="MAX_PATH"/> limitation without prepending "\\?\".
        /// See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// This file is opened with the <see cref="GENERIC_READ"/>, <see cref="DELETE"/>, and <see cref="SYNCHRONIZE"/> access rights.
        /// The sharing mode is <code>FILE_SHARE_READ | FILE_SHARE_WRITE | FILE_SHARE_DELETE</code>.
        /// The caller must have write access to the file to be replaced.
        /// For more information, see File Security and Access Rights.
        /// </param>
        /// <param name="lpReplacementFileName">
        /// The name of the file that will replace the <paramref name="lpReplacedFileName"/> file.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File.
        /// Tip  Starting with Windows 10, version 1607, for the unicode version of this function (<see cref="ReplaceFile"/>),
        /// you can opt-in to remove the <see cref="MAX_PATH"/> limitation without prepending "\\?\".
        /// See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// The function attempts to open this file with the <see cref="SYNCHRONIZE"/>, <see cref="GENERIC_READ"/>, <see cref="GENERIC_WRITE"/>,
        /// <see cref="DELETE"/>, and <see cref="WRITE_DAC"/> access rights so that it can preserve all attributes and ACLs.
        /// If this fails, the function attempts to open the file with the <see cref="SYNCHRONIZE"/>, <see cref="GENERIC_READ"/>,
        /// <see cref="DELETE"/>, and <see cref="WRITE_DAC"/> access rights.
        /// No sharing mode is specified.
        /// </param>
        /// <param name="lpBackupFileName">
        /// The name of the file that will serve as a backup copy of the <paramref name="lpReplacedFileName"/> file.
        /// If this parameter is <see langword="null"/>, no backup file is created.
        /// See the Remarks section for implementation details on the backup file.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.
        /// For more information, see Naming a File.
        /// Tip  Starting with Windows 10, version 1607, for the unicode version of this function (<see cref="ReplaceFile"/>),
        /// you can opt-in to remove the <see cref="MAX_PATH"/> limitation without prepending "\\?\".
        /// See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// </param>
        /// <param name="dwReplaceFlags">
        /// The replacement options.
        /// This parameter can be one or more of the following values.
        /// <see cref="REPLACEFILE_WRITE_THROUGH"/>, <see cref="REPLACEFILE_IGNORE_MERGE_ERRORS"/>, <see cref="REPLACEFILE_IGNORE_ACL_ERRORS"/>
        /// </param>
        /// <param name="lpExclude">
        /// Reserved for future use.
        /// </param>
        /// <param name="lpReserved">
        /// Reserved for future use.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// The following are possible error codes for this function.
        /// <see cref="ERROR_UNABLE_TO_MOVE_REPLACEMENT"/>:
        /// The replacement file could not be renamed.
        /// If <paramref name="lpBackupFileName"/> was specified, the replaced and replacement files retain their original file names.
        /// Otherwise, the replaced file no longer exists and the replacement file exists under its original name.
        /// <see cref="ERROR_UNABLE_TO_MOVE_REPLACEMENT_2"/>:
        /// The replacement file could not be moved.
        /// The replacement file still exists under its original name; however, it has inherited the file streams and attributes from the file it is replacing.
        /// The file to be replaced still exists with a different name.
        /// If <paramref name="lpBackupFileName"/> is specified, it will be the name of the replaced file.
        /// <see cref="ERROR_UNABLE_TO_REMOVE_REPLACED"/>:
        /// The replaced file could not be deleted.
        /// The replaced and replacement files retain their original file names.
        /// If any other error is returned, such as <see cref="ERROR_INVALID_PARAMETER"/>,
        /// the replaced and replacement files will retain their original file names.
        /// In this scenario, a backup file does not exist and it is not guaranteed that the replacement file
        /// will have inherited all of the attributes and streams of the replaced file.
        /// </returns>
        /// <remarks>
        /// Tip Starting with Windows 10, version 1607, for the unicode version of this function (<see cref="ReplaceFile"/>),
        /// you can opt-in to remove the <see cref="MAX_PATH"/> limitation.
        /// See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// The <see cref="ReplaceFile"/> function combines several steps within a single function.
        /// An application can call <see cref="ReplaceFile"/> instead of calling separate functions to save the data to a new file,
        /// rename the original file using a temporary name, rename the new file to have the same name as the original file, and delete the original file.
        /// Another advantage is that <see cref="ReplaceFile"/> not only copies the new file data, but also preserves the following attributes of the original file:
        /// Creation time, Short file name, Object identifier, DACLs, Security resource attributes, Encryption, Compression,
        /// Named streams not already in the replacement file
        /// For example, if the replacement file is encrypted, but the replaced file is not encrypted, the resulting file is not encrypted.
        /// Windows 7, Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// Security resource attributes (<see cref="ATTRIBUTE_SECURITY_INFORMATION"/>) for the original file are not preserved until Windows 8 and Windows Server 2012.
        /// Note
        /// If the replacement file is protected using Selective Wipe, then the replaced file will be protected by the enterprise id of the replacement file.
        /// The resulting file has the same file ID as the replacement file.
        /// The backup file, replaced file, and replacement file must all reside on the same volume.
        /// To delete or rename a file, you must have either delete permission on the file or delete child permission in the parent directory.
        /// If you set up a directory with all access except delete and delete child and the DACLs of new files are inherited,
        /// then you should be able to create a file without being able to delete it.
        /// However, you can then create a file, and you will get all the access you request on the handle returned to you at the time you create the file.
        /// If you requested delete permission at the time you created the file, you could delete or rename the file with that handle but not with any other.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ReplaceFileW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ReplaceFile([In] LPCWSTR lpReplacedFileName, [In] LPCWSTR lpReplacementFileName, [In] LPCWSTR lpBackupFileName,
            [In] ReplaceFileFlags dwReplaceFlags, [In] LPVOID lpExclude, [In] LPVOID lpReserved);

        /// <summary>
        /// <para>
        /// Sets the physical file size for the specified file to the current position of the file pointer.
        /// The physical file size is also referred to as the end of the file.
        /// The <see cref="SetEndOfFile"/> function can be used to truncate or extend a file.
        /// To set the logical end of a file, use the <see cref="SetFileValidData"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-setendoffile"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the file to be extended or truncated.
        /// The file handle must be created with the <see cref="GENERIC_WRITE"/> access right.
        /// For more information, see File Security and Access Rights.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The SetEndOfFile function can be used to truncate or extend a file.
        /// If the file is extended, the contents of the file between the old end of the file and the new end of the file are not defined.
        /// Each file stream has the following:
        /// File size: the size of the data in a file, to the byte.
        /// Allocation size: the size of the space that is allocated for a file on a disk, which is always an even multiple of the cluster size.
        /// Valid data length: the length of the data in a file that is actually written, to the byte.
        /// This value is always less than or equal to the file size.
        /// The <see cref="SetEndOfFile"/> function sets the file size.
        /// Use <see cref="SetFileValidData"/> to set the valid data length.
        /// If <see cref="CreateFileMapping"/> is called to create a file mapping object for <paramref name="hFile"/>,
        /// <see cref="UnmapViewOfFile"/> must be called first to unmap all views
        /// and call <see cref="CloseHandle"/> to close the file mapping object before you can call <see cref="SetEndOfFile"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetEndOfFile", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetEndOfFile([In] HANDLE hFile);

        /// <summary>
        /// <para>
        /// Sets the attributes for a file or directory.
        /// To perform this operation as a transacted operation, use the <see cref="SetFileAttributesTransacted"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-setfileattributesw"/>
        /// </para>
        /// </summary>
        /// <param name="lpFileName">
        /// The name of the file whose attributes are to be set.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters.
        /// To extend this limit to 32,767 wide characters, call the Unicode version of the function (<see cref="SetFileAttributes"/>)
        /// and prepend "\\?\" to the path.
        /// For more information, see File Names, Paths, and Namespaces.
        /// Tip Starting in Windows 10, version 1607, for the unicode version of this function (<see cref="SetFileAttributes"/>),
        /// you can opt-in to remove the MAX_PATH character limitation without prepending "\\?\".
        /// See the "Maximum Path Limitation" section of Naming Files, Paths, and Namespaces for details.
        /// </param>
        /// <param name="dwFileAttributes">
        /// The file attributes to set for the file.
        /// This parameter can be one or more values, combined using the bitwise-OR operator.
        /// However, all other values override <see cref="FILE_ATTRIBUTE_NORMAL"/>.
        /// Not all attributes are supported by this function. For more information, see the Remarks section.
        /// The following is a list of supported attribute values.
        /// <see cref="FILE_ATTRIBUTE_ARCHIVE"/>, <see cref="FILE_ATTRIBUTE_HIDDEN"/>, <see cref="FILE_ATTRIBUTE_NORMAL"/>,
        /// <see cref="FILE_ATTRIBUTE_NOT_CONTENT_INDEXED"/>, <see cref="FILE_ATTRIBUTE_OFFLINE"/>, <see cref="FILE_ATTRIBUTE_READONLY"/>,
        /// <see cref="FILE_ATTRIBUTE_SYSTEM"/>, <see cref="FILE_ATTRIBUTE_TEMPORARY"/>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The following table describes how to set the attributes that cannot be set using <see cref="SetFileAttributes"/>.
        /// For a complete list of all file attribute values and their descriptions, see File Attribute Constants.
        /// <see cref="FILE_ATTRIBUTE_COMPRESSED"/>:
        /// To set a file's compression state, use the <see cref="DeviceIoControl"/> function with the <see cref="FSCTL_SET_COMPRESSION"/> operation.
        /// <see cref="FILE_ATTRIBUTE_DEVICE"/>: Reserved; do not use.
        /// <see cref="FILE_ATTRIBUTE_DIRECTORY"/>:
        /// Files cannot be converted into directories.
        /// To create a directory, use the <see cref="CreateDirectory"/> or <see cref="CreateDirectoryEx"/> function.
        /// <see cref="FILE_ATTRIBUTE_ENCRYPTED"/>:
        /// To create an encrypted file, use the <see cref="CreateFile"/> function with the <see cref="FILE_ATTRIBUTE_ENCRYPTED"/> attribute.
        /// To convert an existing file into an encrypted file, use the <see cref="EncryptFile"/> function.
        /// <see cref="FILE_ATTRIBUTE_REPARSE_POINT"/>:
        /// To associate a reparse point with a file or directory,
        /// use the <see cref="DeviceIoControl"/> function with the <see cref="FSCTL_SET_REPARSE_POINT"/> operation.
        /// <see cref="FILE_ATTRIBUTE_SPARSE_FILE"/>:
        /// To set a file's sparse attribute, use the <see cref="DeviceIoControl"/> function with the <see cref="FSCTL_SET_SPARSE"/> operation.
        /// Transacted Operations
        /// If a file is open for modification in a transaction, no other thread can open the file for modification until the transaction is committed.
        /// So if a transacted thread opens the file first, any subsequent threads that try modifying the file
        /// before the transaction is committed receives a sharing violation.
        /// If a non-transacted thread modifies the file before the transacted thread does,
        /// and the file is still open when the transaction attempts to open it,
        /// the transaction receives the error <see cref="ERROR_TRANSACTIONAL_CONFLICT"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetFileAttributesW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetFileAttributes([In] LPCWSTR lpFileName, [In] FileAttributes dwFileAttributes);

        /// <summary>
        /// <para>
        /// Sets the notification modes for a file handle, allowing you to specify how completion notifications work for the specified file.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-setfilecompletionnotificationmodes"/>
        /// </para>
        /// </summary>
        /// <param name="FileHandle">
        /// A handle to the file.
        /// </param>
        /// <param name="Flags">
        /// The modes to be set.
        /// One or more modes can be set at the same time; however, after a mode has been set for a file handle, it cannot be removed.
        /// <see cref="FILE_SKIP_COMPLETION_PORT_ON_SUCCESS"/>, <see cref="FILE_SKIP_SET_EVENT_ON_HANDLE"/>
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful or <see cref="FALSE"/> otherwise.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// To compile an application that uses this function, define the _WIN32_WINNT macro as 0x0600 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetFileCompletionNotificationModes", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetFileCompletionNotificationModes([In] HANDLE FileHandle, [In] FileCompletionNotificationModes Flags);

        /// <summary>
        /// <para>
        /// Sets the file information for the specified file.
        /// To retrieve file information using a file handle, see <see cref="GetFileInformationByHandle"/> or <see cref="GetFileInformationByHandleEx"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-setfileinformationbyhandle"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the file for which to change information.
        /// This handle must be opened with the appropriate permissions for the requested change.
        /// For more information, see the Remarks and Example Code sections.
        /// This handle should not be a pipe handle.
        /// </param>
        /// <param name="FileInformationClass">
        /// A <see cref="FILE_INFO_BY_HANDLE_CLASS"/> enumeration value that specifies the type of information to be changed.
        /// For a table of valid values, see the Remarks section.
        /// </param>
        /// <param name="lpFileInformation">
        /// A pointer to the buffer that contains the information to change for the specified file information class.
        /// The structure that this parameter points to corresponds to the class that is specified by <paramref name="FileInformationClass"/>.
        /// For a table of valid structure types, see the Remarks section.
        /// </param>
        /// <param name="dwBufferSize">
        /// The size of <paramref name="lpFileInformation"/>, in bytes.
        /// </param>
        /// <returns>
        /// Returns <see langword="true"/> if successful or <see langword="false"/> otherwise.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Certain file information classes behave slightly differently on different operating system releases. 
        /// These classes are supported by the underlying drivers, and any information they return is subject to change between operating system releases.
        /// The following table shows the valid file information classes and their corresponding data structure types for use with this function.
        /// <see cref="FileBasicInfo"/>: <see cref="FILE_BASIC_INFO"/>
        /// <see cref="FileRenameInfo"/>: <see cref="FILE_RENAME_INFO"/>
        /// <see cref="FileDispositionInfo"/>: <see cref="FILE_DISPOSITION_INFO"/>
        /// <see cref="FileAllocationInfo"/>: <see cref="FILE_ALLOCATION_INFO"/>
        /// <see cref="FileEndOfFileInfo"/>: <see cref="FILE_END_OF_FILE_INFO"/>
        /// <see cref="FileIoPriorityHintInfo"/>: <see cref="FILE_IO_PRIORITY_HINT_INFO"/>
        /// You must specify appropriate access flags when creating the file handle for use with <see cref="SetFileInformationByHandle"/>.
        /// For example, if the application is using <see cref="FILE_DISPOSITION_INFO"/> with the <see cref="DeleteFile"/> member set to <see langword="true"/>,
        /// the file would need <see cref="DELETE"/> access requested in the call to the <see cref="CreateFile"/> function.
        /// To see an example of this, see the Example Code section.
        /// For more information about file permissions, see File Security and Access Rights.
        /// If there is a transaction bound to the handle, then the changes made will be transacted for the information classes <see cref="FileBasicInfo"/>,
        /// <see cref="FileRenameInfo"/>, <see cref="FileAllocationInfo"/>, <see cref="FileEndOfFileInfo"/>, and <see cref="FileDispositionInfo"/>.
        /// If <see cref="FileDispositionInfo"/> is specified, only the delete operation is transacted if a <see cref="DeleteFile"/> operation was requested.
        /// In this case, if the transaction is not committed before the handle is closed, the deletion will not occur.
        /// For more information about TxF, see Transactional NTFS (TxF).
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetFileInformationByHandle", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetFileInformationByHandle([In] IntPtr hFile, [In] FILE_INFO_BY_HANDLE_CLASS FileInformationClass,
          [In] LPVOID lpFileInformation, [In] DWORD dwBufferSize);

        /// <summary>
        /// <para>
        /// Moves the file pointer of the specified file.
        /// This function stores the file pointer in two <see cref="LONG"/> values.
        /// To work with file pointers that are larger than a single <see cref="LONG"/> value,
        /// it is easier to use the <see cref="SetFilePointerEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-setfilepointer"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the file.
        /// The file handle must be created with the <see cref="GENERIC_READ"/> or <see cref="GENERIC_WRITE"/> access right.
        /// For more information, see File Security and Access Rights.
        /// </param>
        /// <param name="lDistanceToMove">
        /// The low order 32-bits of a signed value that specifies the number of bytes to move the file pointer.
        /// If <paramref name="lpDistanceToMoveHigh"/> is not <see cref="NullRef{LONG}"/>,
        /// <paramref name="lpDistanceToMoveHigh"/> and <paramref name="lDistanceToMove"/> form a single 64-bit signed value that specifies the distance to move.
        /// If <paramref name="lpDistanceToMoveHigh"/> is <see cref="NullRef{LONG}"/>,
        /// <paramref name="lDistanceToMove"/> is a 32-bit signed value.
        /// A positive value for <paramref name="lDistanceToMove"/> moves the file pointer forward in the file, and a negative value moves the file pointer back.
        /// </param>
        /// <param name="lpDistanceToMoveHigh">
        /// A pointer to the high order 32-bits of the signed 64-bit distance to move.
        /// If you do not need the high order 32-bits, this pointer must be set to <see cref="NullRef{LONG}"/>.
        /// When not <see cref="NullRef{LONG}"/>, this parameter also receives the high order DWORD of the new value of the file pointer.
        /// For more information, see the Remarks section in this topic.
        /// </param>
        /// <param name="dwMoveMethod">
        /// The starting point for the file pointer move.
        /// This parameter can be one of the following values.
        /// <see cref="FILE_BEGIN"/>:
        /// The starting point is zero or the beginning of the file.
        /// <see cref="FILE_CURRENT"/>:
        /// The starting point is the current value of the file pointer.
        /// <see cref="FILE_END"/>:
        /// The starting point is the current end-of-file position.
        /// </param>
        /// <returns>
        /// If the function succeeds and <paramref name="lpDistanceToMoveHigh"/> is <see cref="NullRef{LONG}"/>,
        /// the return value is the low-order DWORD of the new file pointer.
        /// Note
        /// If the function returns a value other than <see cref="INVALID_SET_FILE_POINTER"/>, the call to <see cref="SetFilePointer"/> has succeeded.
        /// You do not need to call <see cref="GetLastError"/>.
        /// If function succeeds and <paramref name="lpDistanceToMoveHigh"/> is not <see cref="NullRef{LONG}"/>,
        /// the return value is the low-order DWORD of the new file pointer and <paramref name="lpDistanceToMoveHigh"/> contains the high order DWORD of the new file pointer.
        /// If the function fails, the return value is <see cref="INVALID_SET_FILE_POINTER"/>.
        /// To get extended error information, call GetLastError.
        /// If a new file pointer is a negative value, the function fails, the file pointer is not moved,
        /// and the code returned by <see cref="GetLastError"/> is <see cref="ERROR_NEGATIVE_SEEK"/>.
        /// If <paramref name="lpDistanceToMoveHigh"/> is NULL and the new file position does not fit in a 32-bit value,
        /// the function fails and returns <see cref="INVALID_SET_FILE_POINTER"/>.
        /// Note
        /// Because <see cref="INVALID_SET_FILE_POINTER"/> is a valid value for the low-order DWORD of the new file pointer,
        /// you must check both the return value of the function and the error code returned by <see cref="GetLastError"/> to determine whether or not an error has occurred.
        /// If an error has occurred, the return value of <see cref="SetFilePointer"/> is <see cref="INVALID_SET_FILE_POINTER"/>
        /// and <see cref="GetLastError"/> returns a value other than <see cref="NO_ERROR"/>.
        /// For a code example that demonstrates how to check for failure, see the Remarks section in this topic.
        /// </returns>
        /// <remarks>
        /// The file pointer that is identified by the value of the <paramref name="hFile"/> parameter is not used for overlapped read and write operations.
        /// The <paramref name="hFile"/> parameter must refer to a file stored on a seeking device; for example, a disk volume.
        /// Calling the <see cref="SetFilePointer"/> function with a handle to a non-seeking device such as a pipe or a communications device is not supported,
        /// even though the <see cref="SetFilePointer"/> function may not return an error.
        /// The behavior of the <see cref="SetFilePointer"/> function in this case is undefined.
        /// To specify the offset for overlapped operations
        /// Use the <see cref="OVERLAPPED.Offset"/> and <see cref="OVERLAPPED.OffsetHigh"/> members of the <see cref="OVERLAPPED"/> structure.
        /// To determine the file type for <paramref name="hFile"/>
        /// Use the <see cref="GetFileType"/> function.
        /// For information about how to determine the position of a file pointer, see Positioning a File Pointer.
        /// Be careful when you set a file pointer in a multithreaded application.
        /// You must synchronize access to shared resources.
        /// For example, an application with threads that share a file handle, update the file pointer,
        /// and read from the file must protect this sequence by using a critical section object or mutex object.
        /// For more information, see Critical Section Objects and Mutex Objects.
        /// If the hFile handle is opened with the <see cref="FILE_FLAG_NO_BUFFERING"/> flag set, an application can move the file pointer only to sector-aligned positions.
        /// A sector-aligned position is a position that is a whole number multiple of the volume sector size.
        /// An application can obtain a volume sector size by calling the <see cref="GetDiskFreeSpace"/> function.
        /// If an application calls <see cref="SetFilePointer"/> with distance to move value
        /// that result in a position not sector-aligned and a handle that is opened with <see cref="FILE_FLAG_NO_BUFFERING"/>,
        /// the function fails, and GetLastError returns <see cref="ERROR_INVALID_PARAMETER"/>.
        /// It is not an error to set a file pointer to a position beyond the end of the file.
        /// The size of the file does not increase until you call the <see cref="SetEndOfFile"/>, <see cref="WriteFile"/>, or <see cref="WriteFileEx"/> function.
        /// A write operation increases the size of the file to the file pointer position plus the size of the buffer written,
        /// which results in the intervening bytes uninitialized.
        /// If the return value is <see cref="INVALID_SET_FILE_POINTER"/> and if <paramref name="lpDistanceToMoveHigh"/> is non-NULL,
        /// an application must call <see cref="GetLastError"/> to determine whether or not the function has succeeded or failed.
        /// The following code example shows you that scenario.
        /// <code>
        /// // Case One: calling the function with lpDistanceToMoveHigh == NULL 
        /// 
        /// // Try to move hFile file pointer some distance  
        /// DWORD dwPtr = SetFilePointer( hFile, 
        ///                               lDistance, 
        ///                               NULL, 
        ///                               FILE_BEGIN ); 
        ///                               
        /// if (dwPtr == INVALID_SET_FILE_POINTER) // Test for failure
        /// { 
        ///     // Obtain the error code. 
        ///     DWORD dwError = GetLastError() ; 
        ///     
        ///     // Deal with failure 
        ///     // . . . 
        /// 
        /// } // End of error handler 
        /// 
        /// 
        /// //
        /// // Case Two: calling the function with lpDistanceToMoveHigh != NULL
        /// 
        /// // Try to move hFile file pointer a huge distance 
        /// DWORD dwPtrLow = SetFilePointer( hFile,
        ///                                  lDistLow,
        ///                                  &amp;lDistHigh,
        ///                                  FILE_BEGIN );
        ///
        /// // Test for failure
        /// if ( dwPtrLow == INVALID_SET_FILE_POINTER &amp;&amp;
        ///      GetLastError() != NO_ERROR )
        /// {
        ///  // Deal with failure
        ///  // . . .
        ///  
        /// } // End of error handler
        /// </code>
        /// Although the parameter <paramref name="lpDistanceToMoveHigh"/> is used to manipulate huge files,
        /// the value of the parameter should be set when moving files of any size.
        /// If it is set to <see cref="NullRef{LONG}"/>, then <paramref name="lDistanceToMove"/> has a maximum value of 2^31–2, or 2 gigabytes less 2,
        /// because all file pointer values are signed values.
        /// Therefore, if there is even a small chance for the file to increase to that size,
        /// it is best to treat the file as a huge file and work with 64-bit file pointers.
        /// With file compression on the NTFS file system, and sparse files,
        /// it is possible to have files that are large even if the underlying volume is not very large.
        /// If <paramref name="lpDistanceToMoveHigh"/> is not <see cref="NullRef{LONG}"/>,
        /// then <paramref name="lpDistanceToMoveHigh"/> and <paramref name="lDistanceToMove"/> form a single 64-bit signed value.
        /// The <paramref name="lDistanceToMove"/> parameter is treated as the low-order 32 bits of the value,
        /// and <paramref name="lpDistanceToMoveHigh"/> as the high-order 32 bits,
        /// which means that <paramref name="lpDistanceToMoveHigh"/> is a sign extension of <paramref name="lDistanceToMove"/>.
        /// To move the file pointer from zero to 2 gigabytes, <paramref name="lpDistanceToMoveHigh"/> must be set to
        /// either <see cref="NullRef{LONG}"/> or a sign extension of <paramref name="lDistanceToMove"/>.
        /// To move the pointer more than 2 gigabytes, use <paramref name="lpDistanceToMoveHigh"/> and <paramref name="lDistanceToMove"/> as a single 64-bit quantity.
        /// For example, to move in the range from 2 gigabytes to 4 gigabytes set the contents of <paramref name="lpDistanceToMoveHigh"/> to zero,
        /// or to –1 for a negative sign extension of <paramref name="lDistanceToMove"/>.
        /// To work with 64-bit file pointers, you can declare a LONG, treat it as the upper half of the 64-bit file pointer,
        /// and pass its address in <paramref name="lpDistanceToMoveHigh"/>.
        /// This means that you have to treat two different variables as a logical unit, which can cause an error.
        /// It is best to use the <see cref="LARGE_INTEGER"/> structure to create a 64-bit value
        /// and pass the two 32-bit values by using the appropriate elements of the union.
        /// Also, it is best to use a function to hide the interface to <see cref="SetFilePointer"/>.
        /// The following code example shows you that scenario.
        /// <code>
        /// __int64 myFileSeek (HANDLE hf, __int64 distance, DWORD MoveMethod)
        /// {
        ///     LARGE_INTEGER li;
        ///     
        ///     li.QuadPart = distance;
        ///     
        ///     li.LowPart = SetFilePointer(hf,
        ///                                 li.LowPart,
        ///                                 &amp;li.HighPart,
        ///                                 MoveMethod);
        ///                                 
        ///     if (li.LowPart == INVALID_SET_FILE_POINTER &amp;&amp; GetLastError()
        ///         != NO_ERROR)
        ///     {
        ///         li.QuadPart = -1;
        ///     }
        /// 
        /// return li.QuadPart;
        /// }
        /// </code>
        /// You can use <see cref="SetFilePointer"/> to determine the length of a file.
        /// To do this, use <see cref="FILE_END"/> for <paramref name="dwMoveMethod"/> and seek to location zero.
        /// The file offset returned is the length of the file.
        /// However, this practice can have unintended side effects, for example,
        /// failure to save the current file pointer so that the program can return to that location.
        /// It is best to use GetFileSize instead.
        /// You can also use the <see cref="SetFilePointer"/> function to query the current file pointer position.
        /// To do this, specify a move method of <see cref="FILE_CURRENT"/> and a distance of zero.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetFilePointer", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD SetFilePointer([In] HANDLE hFile, [In] LONG lDistanceToMove, [In][Out] ref LONG lpDistanceToMoveHigh, [In] MoveMethods dwMoveMethod);

        /// <summary>
        /// <para>
        /// Moves the file pointer of the specified file.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-setfilepointerex"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the file.
        /// The file handle must have been created with the <see cref="GENERIC_READ"/> or <see cref="GENERIC_WRITE"/> access right.
        /// For more information, see File Security and Access Rights.
        /// </param>
        /// <param name="liDistanceToMove">
        /// The number of bytes to move the file pointer.
        /// A positive value moves the pointer forward in the file and a negative value moves the file pointer backward.
        /// </param>
        /// <param name="lpNewFilePointer">
        /// A pointer to a variable to receive the new file pointer.
        /// If this parameter is <see cref="NullRef{LARGE_INTEGER}"/>, the new file pointer is not returned.
        /// </param>
        /// <param name="dwMoveMethod">
        /// The starting point for the file pointer move. This parameter can be one of the following values.
        /// <see cref="FILE_BEGIN"/>: 
        /// The starting point is zero or the beginning of the file.
        /// If this flag is specified, then the <paramref name="liDistanceToMove"/> parameter is interpreted as an unsigned value.
        /// <see cref="FILE_CURRENT"/>:
        /// The start point is the current value of the file pointer. 
        /// <see cref="FILE_END"/>:
        /// The starting point is the current end-of-file position. 
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The file pointer returned by this function is not used for overlapped read and write operations.
        /// To specify the offset for overlapped operations, use the <see cref="OVERLAPPED.Offset"/>
        /// and <see cref="OVERLAPPED.OffsetHigh"/> members of the <see cref="OVERLAPPED"/> structure.
        /// You cannot use the <see cref="SetFilePointerEx"/> function with a handle to a nonseeking device such as a pipe or a communications device.
        /// To determine the file type for <paramref name="hFile"/>, use the <see cref="GetFileType"/> function.
        /// Use caution when setting the file pointer in a multithreaded application. You must synchronize access to shared resources.
        /// For example, an application whose threads share a file handle, update the file pointer,
        /// and read from the file must protect this sequence by using a critical section object or a mutex object.
        /// For more information about these objects, see Critical Section Objects and Mutex Objects.
        /// If the <paramref name="hFile"/> handle was opened with the <see cref="FILE_FLAG_NO_BUFFERING"/> flag set,
        /// an application can move the file pointer only to sector-aligned positions.
        /// A sector-aligned position is a position that is a whole number multiple of the volume's sector size.
        /// An application can obtain a volume's sector size by calling the <see cref="GetDiskFreeSpace"/> function.
        /// If an application calls <see cref="SetFilePointerEx"/> with distance-to-move values that result in a position
        /// that is not sector-aligned and a handle that was opened with <see cref="FILE_FLAG_NO_BUFFERING"/>,
        /// the function fails, and <see cref="GetLastError"/> returns <see cref="ERROR_INVALID_PARAMETER"/>.
        /// For additional information, see File Buffering.
        /// Note that it is not an error to set the file pointer to a position beyond the end of the file.
        /// The size of the file does not increase until you call the <see cref="SetEndOfFile"/>,
        /// <see cref="WriteFile"/>, or <see cref="WriteFileEx"/> function.
        /// A write operation increases the size of the file to the file pointer position plus the size of the buffer written,
        /// leaving the intervening bytes uninitialized.
        /// You can use <see cref="SetFilePointerEx"/> to determine the length of a file.
        /// To do this, use <see cref="FILE_END"/> for <paramref name="dwMoveMethod"/> and seek to location zero.
        /// The file offset returned is the length of the file.
        /// However, this practice can have unintended side effects, such as failure to save the current file pointer
        /// so that the program can return to that location.
        /// It is simpler and safer to use the <see cref="GetFileSizeEx"/> function instead.
        /// You can also use <see cref="SetFilePointerEx"/> to query the current file pointer position.
        /// To do this, specify a move method of <see cref="FILE_CURRENT"/> and a distance of zero.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetFilePointerEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetFilePointerEx([In] HANDLE hFile, [In] LARGE_INTEGER liDistanceToMove, [Out] out LARGE_INTEGER lpNewFilePointer,
            [In] MoveMethods dwMoveMethod);

        /// <summary>
        /// <para>
        /// Sets the date and time that the specified file or directory was created, last accessed, or last modified.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-setfiletime"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the file or directory.
        /// The handle must have been created using the <see cref="CreateFile"/> function with the <see cref="FILE_WRITE_ATTRIBUTES"/> access right.
        /// For more information, see File Security and Access Rights.
        /// </param>
        /// <param name="lpCreationTime">
        /// A pointer to a <see cref="FILETIME"/> structure that contains the new creation date and time for the file or directory.
        /// If the application does not need to change this information, set this parameter either to <see cref="NullRef{FILETIME}"/>
        /// or to a pointer to a <see cref="FILETIME"/> structure that has both the <see cref="FILETIME.dwLowDateTime"/>
        /// and <see cref="FILETIME.dwHighDateTime"/> members set to 0.
        /// </param>
        /// <param name="lpLastAccessTime">
        /// A pointer to a <see cref="FILETIME"/> structure that contains the new last access date and time for the file or directory.
        /// The last access time includes the last time the file or directory was written to, read from, or (in the case of executable files) run.
        /// If the application does not need to change this information, set this parameter either to <see cref="NullRef{FILETIME}"/>
        /// or to a pointer to a <see cref="FILETIME"/> structure that has both the <see cref="FILETIME.dwLowDateTime"/>
        /// and <see cref="FILETIME.dwHighDateTime"/> members set to 0.
        /// To prevent file operations using the given handle from modifying the last access time,
        /// call <see cref="SetFileTime"/> immediately after opening the file handle and pass a <see cref="FILETIME"/> structure
        /// that has both the <see cref="FILETIME.dwLowDateTime"/> and <see cref="FILETIME.dwHighDateTime"/> members set to 0xFFFFFFFF.
        /// </param>
        /// <param name="lpLastWriteTime">
        /// A pointer to a <see cref="FILETIME"/> structure that contains the new last modified date and time for the file or directory.
        /// If the application does not need to change this information, set this parameter either to <see cref="NullRef{FILETIME}"/>
        /// or to a pointer to a <see cref="FILETIME"/> structure that has both the <see cref="FILETIME.dwLowDateTime"/>
        /// and <see cref="FILETIME.dwHighDateTime"/> members set to 0.
        /// To prevent file operations using the given handle from modifying the last access time,
        /// call <see cref="SetFileTime"/> immediately after opening the file handle and pass a <see cref="FILETIME"/> structure
        /// that has both the <see cref="FILETIME.dwLowDateTime"/> and <see cref="FILETIME.dwHighDateTime"/> members set to 0xFFFFFFFF.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Not all file systems can record creation and last access times and not all file systems record them in the same manner.
        /// For example, on FAT, create time has a resolution of 10 milliseconds, write time has a resolution of 2 seconds,
        /// and access time has a resolution of 1 day (really, the access date).
        /// Therefore, the <see cref="GetFileTime"/> function may not return the same file time information set using <see cref="SetFileTime"/>.
        /// NTFS delays updates to the last access time for a file by up to one hour after the last access.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetFileTime", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetFileTime([In] HANDLE hFile, [In] in FILETIME lpCreationTime,
            [In] in FILETIME lpLastAccessTime, [In] in FILETIME lpLastWriteTime);

        /// <summary>
        /// <para>
        /// Sets the valid data length of the specified file. This function is useful in very limited scenarios.
        /// For more information, see the Remarks section.
        /// Caution
        /// Use of this function without proper security considerations may compromise data privacy and security.
        /// For more information, see the Remarks section.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-setfilevaliddata"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the file. The file must have been opened with the <see cref="GENERIC_WRITE"/> access right,
        /// and the SE_MANAGE_VOLUME_NAME privilege enabled.
        /// For more information, see File Security and Access Rights.
        /// Note The file cannot be a network file, or be compressed, sparse, or transacted.
        /// </param>
        /// <param name="ValidDataLength">
        /// The new valid data length.
        /// This parameter must be a positive value that is greater than the current valid data length, but less than the current file size.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="SetFileValidData"/> function sets the logical end of a file.
        /// To set the size of a file, use the <see cref="SetEndOfFile"/> function.
        /// The physical file size is also referred to as the end of the file.
        /// Each file stream has the following properties:
        /// File size: the size of the data in a file, to the byte.
        /// Allocation size: the size of the space that is allocated for a file on a disk, which is always an even multiple of the cluster size.
        /// Valid data length: the length of the data in a file that is actually written, to the byte.
        /// This value is always less than or equal to the file size.
        /// Typically, the <see cref="SetFileValidData"/> function is used by system-level applications on their own private data.
        /// Not all file systems use valid data length. Some file systems can track multiple valid data ranges.
        /// In general, most applications will never need to call this function.
        /// The <see cref="SetFileValidData"/> function allows you to avoid filling data with zeros when writing nonsequentially to a file.
        /// The function makes the data in the file valid without writing to the file.
        /// As a result, although some performance gain may be realized, existing data on disk from previously existing files
        /// can inadvertently become available to unintended readers.
        /// The following paragraphs provide a more detailed description of this potential security and privacy issue.
        /// A caller must have the SE_MANAGE_VOLUME_NAME privilege enabled when opening a file initially.
        /// Applications should call <see cref="SetFileValidData"/> only on files that restrict access
        /// to those entitiesthat have SE_MANAGE_VOLUME_NAME access.
        /// The application must ensure that the unwritten ranges of the file are never exposed, or security issues can result as follows.
        /// If <see cref="SetFileValidData"/> is used on a file, the potential performance gain is obtained
        /// by not filling the allocated clusters for the file with zeros.
        /// Therefore, reading from the file will return whatever the allocated clusters contain, potentially content from other users.
        /// This is not necessarily a security issue at this point, because the caller needs to have SE_MANAGE_VOLUME_NAME privilege
        /// for <see cref="SetFileValidData"/> to succeed, and all data on disk can be read by such users.
        /// However, this caller can inadvertently expose this data to other users that cannot acquire the SE_MANAGE_VOLUME_PRIVILEGE privilege
        /// if the following holds:
        /// If the file was not opened with a sharing mode that denies other readers, a nonprivileged user can open it and read the exposed data.
        /// If the system stops responding before the caller finishes writing up the <paramref name="ValidDataLength"/> supplied in the call,
        /// then, on a reboot, such a nonprivileged user can open the file and read exposed content.
        /// If the caller of <see cref="SetFileValidData"/> opened the file with adequately restrictive access control,
        /// the previous conditions would not apply.
        /// However, for partially written files extended with <see cref="SetFileValidData"/> (that is, writing was not completed up to
        /// the <paramref name="ValidDataLength"/> supplied in the call) there exists yet another potential privacy or security vulnerability.
        /// An administrator could copy the file to a target that is not properly controlled with restrictive ACL permissions,
        /// thus inadvertently exposing the extended area's data to unauthorized reading.
        /// It is for these reasons that <see cref="SetFileValidData"/> is not recommended for general purpose use,
        /// in addition to performance considerations, as discussed below.
        /// For more information about security and access privileges, see Running with Special Privileges and File Security and Access Rights.
        /// You can use the <see cref="SetFileValidData"/> function to create large files in very specific circumstances
        /// so that the performance of subsequent file I/O can be better than other methods.
        /// Specifically, if the extended portion of the file is large and will be written to randomly,
        /// such as in a database type of application, the time it takes to extend and write to the file will be faster
        /// than using <see cref="SetEndOfFile"/> and writing randomly.
        /// In most other situations, there is usually no performance gain to using <see cref="SetFileValidData"/>,
        /// and sometimes there can be a performance penalty.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetFileValidData", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetFileValidData([In] HANDLE hFile, [In] LONGLONG ValidDataLength);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uNumber"></param>
        /// <returns></returns>
        [Obsolete]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetHandleCount", ExactSpelling = true, SetLastError = true)]
        public static extern UINT SetHandleCount([In] uint uNumber);

        /// <summary>
        /// <para>
        /// Associates a volume with a drive letter or a directory on another volume.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-setvolumemountpointw"/>
        /// </para>
        /// </summary>
        /// <param name="lpszVolumeMountPoint">
        /// The user-mode path to be associated with the volume.
        /// This may be a drive letter (for example, "X:") or a directory on another volume (for example, "Y:\MountX").
        /// The string must end with a trailing backslash ('').
        /// </param>
        /// <param name="lpszVolumeName">
        /// A volume GUID path for the volume.
        /// This string must be of the form "\\?\Volume{GUID}\" where GUID is a GUID that identifies the volume.
        /// The "\\?\" turns off path parsing and is ignored as part of the path, as discussed in Naming a Volume.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If the <paramref name="lpszVolumeMountPoint"/> parameter contains a path to a mounted folder,
        /// <see cref="GetLastError"/> returns <see cref="ERROR_DIR_NOT_EMPTY"/>, even if the directory is empty.
        /// </returns>
        /// <remark>
        /// When this function is used to associate a volume with a directory on another volume,
        /// the associated directory is called a mounted folder.
        /// It is an error to associate a volume with a directory that has any files or subdirectories in it.
        /// This error occurs for system and hidden directories as well as other directories,
        /// and it occurs for system and hidden files.
        /// When mounted folders are created on a volume on a clustered disk, they may be deleted unexpectedly under certain circumstances.
        /// For information on how to create and configure mounted folders to ensure that this does not happen,
        /// see Cluster Disk and Drive Connection Problems.
        /// </remark>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetVolumeMountPointW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetVolumeMountPoint([MarshalAs(UnmanagedType.LPWStr)][In] string lpszVolumeMountPoint,
            [MarshalAs(UnmanagedType.LPWStr)][In] string lpszVolumeName);

        /// <summary>
        /// <para>
        /// Unlocks a region in an open file.
        /// Unlocking a region enables other processes to access the region.
        /// For an alternate way to specify the region, use the <see cref="UnlockFileEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-unlockfile"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the file that contains a region locked with <see cref="LockFile"/>.
        /// The file handle must have been created with either the <see cref="GENERIC_READ"/> or <see cref="GENERIC_WRITE"/> access right.
        /// For more information, see File Security and Access Rights.
        /// </param>
        /// <param name="dwFileOffsetLow">
        /// The low-order word of the starting byte offset in the file where the locked region begins.
        /// </param>
        /// <param name="dwFileOffsetHigh">
        /// The high-order word of the starting byte offset in the file where the locked region begins.
        /// </param>
        /// <param name="nNumberOfBytesToUnlockLow">
        /// The low-order word of the length of the byte range to be unlocked.
        /// </param>
        /// <param name="nNumberOfBytesToUnlockHigh">
        /// The high-order word of the length of the byte range to be unlocked.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// This function always operates synchronously, but may not queue a completion entry when a completion port is associated with the file handle.
        /// Unlocking a region of a file releases a previously acquired lock on the file.
        /// The region to unlock must correspond exactly to an existing locked region.
        /// Two adjacent regions of a file cannot be locked separately and then unlocked using a single region that spans both locked regions.
        /// If a process terminates with a portion of a file locked or closes a file that has outstanding locks, the locks are unlocked by the operating system.
        /// However, the time it takes for the operating system to unlock these locks depends upon available system resources.
        /// Therefore, it is recommended that your process explicitly unlock all files it has locked when it terminates.
        /// If this is not done, access to these files may be denied if the operating system has not yet unlocked them.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "UnlockFile", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL UnlockFile([In] HANDLE hFile, [In] DWORD dwFileOffsetLow, [In] DWORD dwFileOffsetHigh,
            [In] DWORD nNumberOfBytesToUnlockLow, [In] DWORD nNumberOfBytesToUnlockHigh);

        /// <summary>
        /// <para>
        /// Unlocks a region in the specified file.
        /// This function can operate either synchronously or asynchronously.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-unlockfileex"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the file.
        /// The handle must have been created with either the <see cref="GENERIC_READ"/> or <see cref="GENERIC_WRITE"/> access right.
        /// For more information, see File Security and Access Rights.
        /// </param>
        /// <param name="dwReserved">
        /// Reserved parameter; must be zero.
        /// </param>
        /// <param name="nNumberOfBytesToUnlockLow">
        /// The low-order part of the length of the byte range to unlock.
        /// </param>
        /// <param name="nNumberOfBytesToUnlockHigh">
        /// The high-order part of the length of the byte range to unlock.
        /// </param>
        /// <param name="lpOverlapped">
        /// A pointer to an <see cref="OVERLAPPED"/> structure that the function uses with the unlocking request.
        /// This structure contains the file offset of the beginning of the unlock range.
        /// You must initialize the <see cref="OVERLAPPED.hEvent"/> member to a valid handle or zero.
        /// For more information, see Synchronous and Asynchronous I/O.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Unlocking a region of a file releases a previously acquired lock on the file.
        /// The region to unlock must correspond exactly to an existing locked region.
        /// Two adjacent regions of a file cannot be locked separately and then unlocked using a single region that spans both locked regions.
        /// Locks are released before the <see cref="CloseHandle"/> function is finished processing.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "UnlockFileEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL UnlockFileEx([In] HANDLE hFile, [In] DWORD dwReserved, [In] DWORD nNumberOfBytesToUnlockLow,
            [In] DWORD nNumberOfBytesToUnlockHigh, [In] in OVERLAPPED lpOverlapped);

        /// <summary>
        /// <para>
        /// Writes data to the specified file or input/output (I/O) device.
        /// This function is designed for both synchronous and asynchronous operation.
        /// For a similar function designed solely for asynchronous operation, see <see cref="WriteFileEx"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-writefile"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the file or I/O device (for example, a file, file stream, physical disk, volume, console buffer,
        /// tape drive, socket, communications resource, mailslot, or pipe).
        /// The <paramref name="hFile"/> parameter must have been created with the write access.
        /// For more information, see Generic Access Rights and File Security and Access Rights.
        /// For asynchronous write operations, <paramref name="hFile"/> can be any handle opened with the <see cref="CreateFile"/> function
        /// using the <see cref="FILE_FLAG_OVERLAPPED"/> flag or a socket handle returned by the socket or accept function.
        /// </param>
        /// <param name="lpBuffer">
        /// A pointer to the buffer containing the data to be written to the file or device.
        /// This buffer must remain valid for the duration of the write operation.
        /// The caller must not use this buffer until the write operation is completed.
        /// </param>
        /// <param name="nNumberOfBytesToWrite">
        /// The number of bytes to be written to the file or device.
        /// A value of zero specifies a null write operation.
        /// The behavior of a null write operation depends on the underlying file system or communications technology.
        /// Windows Server 2003 and Windows XP:
        /// Pipe write operations across a network are limited in size per write.
        /// The amount varies per platform. For x86 platforms it's 63.97 MB. For x64 platforms it's 31.97 MB. For Itanium it's 63.95 MB.
        /// For more information regarding pipes, see the Remarks section.
        /// </param>
        /// <param name="lpNumberOfBytesWritten">
        /// A pointer to the variable that receives the number of bytes written when using a synchronous <paramref name="hFile"/> parameter.
        /// <see cref="WriteFile"/> sets this value to zero before doing any work or error checking.
        /// Use <see langword="null"/> for this parameter if this is an asynchronous operation to avoid potentially erroneous results.
        /// This parameter can be <see langword="null"/> only when the <paramref name="lpOverlapped"/> parameter is not <see langword="null"/>.
        /// For more information, see the Remarks section.
        /// </param>
        /// <param name="lpOverlapped">
        /// A pointer to an <see cref="OVERLAPPED"/> structure is required if the <paramref name="hFile"/> parameter
        /// was opened with <see cref="FILE_FLAG_OVERLAPPED"/>, otherwise this parameter can be <see langword="null"/>.
        /// For an <paramref name="hFile"/> that supports byte offsets, if you use this parameter you must specify a byte offset
        /// at which to start writing to the file or device.
        /// This offset is specified by setting the <see cref="OVERLAPPED.Offset"/>
        /// and <see cref="OVERLAPPED.OffsetHigh"/> members of the <see cref="OVERLAPPED"/> structure.
        /// For an <paramref name="hFile"/> that does not support byte offsets, <see cref="OVERLAPPED.Offset"/>
        /// and <see cref="OVERLAPPED.OffsetHigh"/> are ignored.
        /// To write to the end of file, specify both the <see cref="OVERLAPPED.Offset"/> and <see cref="OVERLAPPED.OffsetHigh"/> members
        /// of the <see cref="OVERLAPPED"/> structure as 0xFFFFFFFF.
        /// This is functionally equivalent to previously calling the <see cref="CreateFile"/> function
        /// to open <paramref name="hFile"/> using <see cref="FILE_APPEND_DATA"/> access.
        /// For more information about different combinations of <paramref name="lpOverlapped"/> and <see cref="FILE_FLAG_OVERLAPPED"/>,
        /// see the Remarks section and the Synchronization and File Position section.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, or is completing asynchronously, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call the <see cref="GetLastError"/> function.
        /// Note The <see cref="GetLastError"/> code <see cref="ERROR_IO_PENDING"/> is not a failure;
        /// it designates the write operation is pending completion asynchronously.
        /// For more information, see Remarks.
        /// </returns>
        /// <remarks>
        /// The <see cref="WriteFile"/> function returns when one of the following conditions occur:
        /// The number of bytes requested is written.
        /// A read operation releases buffer space on the read end of the pipe (if the write was blocked).
        /// For more information, see the Pipes section.
        /// An asynchronous handle is being used and the write is occurring asynchronously.
        /// An error occurs.
        /// The <see cref="WriteFile"/> function may fail with <see cref="ERROR_INVALID_USER_BUFFER"/> or <see cref="ERROR_NOT_ENOUGH_MEMORY"/>
        /// whenever there are too many outstanding asynchronous I/O requests.
        /// To cancel all pending asynchronous I/O operations, use either:
        /// <see cref="CancelIo"/>—this function cancels only operations issued by the calling thread for the specified file handle.
        /// <see cref="CancelIoEx"/>—this function cancels all operations issued by the threads for the specified file handle.
        /// Use the <see cref="CancelSynchronousIo"/> function to cancel pending synchronous I/O operations.
        /// I/O operations that are canceled complete with the error <see cref="ERROR_OPERATION_ABORTED"/>.
        /// The <see cref="WriteFile"/> function may fail with <see cref="ERROR_NOT_ENOUGH_QUOTA"/>,
        /// which means the calling process's buffer could not be page-locked.
        /// For more information, see <see cref="SetProcessWorkingSetSize"/>.
        /// If part of the file is locked by another process and the write operation overlaps the locked portion, <see cref="WriteFile"/> fails.
        /// When writing to a file, the last write time is not fully updated until all handles used for writing have been closed.
        /// Therefore, to ensure an accurate last write time, close the file handle immediately after writing to the file.
        /// Accessing the output buffer while a write operation is using the buffer may lead to corruption of the data written from that buffer.
        /// Applications must not write to, reallocate, or free the output buffer that a write operation is using until the write operation completes.
        /// This can be particularly problematic when using an asynchronous file handle.
        /// Additional information regarding synchronous versus asynchronous file handles can be found later
        /// in the Synchronization and File Position section and Synchronous and Asynchronous I/O.
        /// Note that the time stamps may not be updated correctly for a remote file. To ensure consistent results, use unbuffered I/O.
        /// The system interprets zero bytes to write as specifying a null write operation and WriteFile does not truncate or extend the file.
        /// To truncate or extend a file, use the <see cref="SetEndOfFile"/> function.
        /// Characters can be written to the screen buffer using WriteFile with a handle to console output.
        /// The exact behavior of the function is determined by the console mode. The data is written to the current cursor position.
        /// The cursor position is updated after the write operation. For more information about console handles, see <see cref="CreateFile"/>.
        /// When writing to a communications device, the behavior of <see cref="WriteFile"/> is determined
        /// by the current communication time-out as set and retrieved by using the <see cref="SetCommTimeouts"/> and <see cref="GetCommTimeouts"/> functions.
        /// Unpredictable results can occur if you fail to set the time-out values.
        /// For more information about communication time-outs, see <see cref="COMMTIMEOUTS"/>.
        /// Although a single-sector write is atomic, a multi-sector write is not guaranteed to be atomic unless you are using a transaction
        /// (that is, the handle created is a transacted handle; for example, a handle created using <see cref="CreateFileTransacted"/>).
        /// Multi-sector writes that are cached may not always be written to the disk right away;
        /// therefore, specify <see cref="FILE_FLAG_WRITE_THROUGH"/> in <see cref="CreateFile"/> to ensure
        /// that an entire multi-sector write is written to the disk without potential caching delays.
        /// If you write directly to a volume that has a mounted file system, you must first obtain exclusive access to the volume.
        /// Otherwise, you risk causing data corruption or system instability, because your application's writes may conflict
        /// with other changes coming from the file system and leave the contents of the volume in an inconsistent state.
        /// To prevent these problems, the following changes have been made in Windows Vista and later:
        /// A write on a volume handle will succeed if the volume does not have a mounted file system, or if one of the following conditions is true:
        /// The sectors to be written to are boot sectors.
        /// The sectors to be written to reside outside of file system space.
        /// You have explicitly locked or dismounted the volume by using <see cref="FSCTL_LOCK_VOLUME"/> or <see cref="FSCTL_DISMOUNT_VOLUME"/>.
        /// The volume has no actual file system. (In other words, it has a RAW file system mounted.)
        /// A write on a disk handle will succeed if one of the following conditions is true:
        /// The sectors to be written to do not fall within a volume's extents.
        /// The sectors to be written to fall within a mounted volume, but you have explicitly locked or dismounted the volume
        /// by using <see cref="FSCTL_LOCK_VOLUME"/> or <see cref="FSCTL_DISMOUNT_VOLUME"/>.
        /// The sectors to be written to fall within a volume that has no mounted file system other than RAW.
        /// There are strict requirements for successfully working with files opened with <see cref="CreateFile"/> using <see cref="FILE_FLAG_NO_BUFFERING"/>.
        /// For details see File Buffering.
        /// If <paramref name="hFile"/> was opened with <see cref="FILE_FLAG_OVERLAPPED"/>, the following conditions are in effect:
        /// The <paramref name="lpOverlapped"/> parameter must point to a valid and unique <see cref="OVERLAPPED"/> structure,
        /// otherwise the function can incorrectly report that the write operation is complete.
        /// The <paramref name="lpNumberOfBytesWritten"/> parameter should be set to <see langword="null"/>.
        /// To get the number of bytes written, use the <see cref="GetOverlappedResult"/> function.
        /// If the <paramref name="hFile"/> parameter is associated with an I/O completion port,
        /// you can also get the number of bytes written by calling the <see cref="GetQueuedCompletionStatus"/> function.
        /// Synchronization and File Position
        /// If <paramref name="hFile"/> is opened with <see cref="FILE_FLAG_OVERLAPPED"/>, it is an asynchronous file handle; otherwise it is synchronous.
        /// The rules for using the <see cref="OVERLAPPED"/> structure are slightly different for each, as previously noted.
        /// Note If a file or device is opened for asynchronous I/O, subsequent calls to functions such as <see cref="WriteFile"/>
        /// using that handle generally return immediately, but can also behave synchronously with respect to blocked execution.
        /// For more information, see http://support.microsoft.com/kb/156932.
        /// Considerations for working with asynchronous file handles:
        /// <see cref="WriteFile"/> may return before the write operation is complete.
        /// In this scenario, <see cref="WriteFile"/> returns <see cref="FALSE"/> and
        /// the <see cref="GetLastError"/> function returns <see cref="ERROR_IO_PENDING"/>,
        /// which allows the calling process to continue while the system completes the write operation.
        /// The <paramref name="lpOverlapped"/> parameter must not be <see langword="null"/> and should be used with the following facts in mind:
        /// Although the event specified in the <see cref="OVERLAPPED"/> structure is set and reset automatically by the system,
        /// the offset that is specified in the <see cref="OVERLAPPED"/> structure is not automatically updated.
        /// <see cref="WriteFile"/> resets the event to a nonsignaled state when it begins the I/O operation.
        /// The event specified in the <see cref="OVERLAPPED"/> structure is set to a signaled state when the write operation is complete;
        /// until that time, the write operation is considered pending.
        /// Because the write operation starts at the offset that is specified in the <see cref="OVERLAPPED"/> structure,
        /// and <see cref="WriteFile"/> may return before the system-level write operation is complete (write pending),
        /// neither the offset nor any other part of the structure should be modified, freed,
        /// or reused by the application until the event is signaled (that is, the write completes).
        /// Considerations for working with synchronous file handles:
        /// If <paramref name="lpOverlapped"/> is <see langword="null"/>, the write operation starts at the current file position
        /// and <see cref="WriteFile"/> does not return until the operation is complete,
        /// and the system updates the file pointer before <see cref="WriteFile"/> returns.
        /// If <paramref name="lpOverlapped"/> is not <see langword="null"/>,
        /// the write operation starts at the offset that is specified in the <see cref="OVERLAPPED"/> structure
        /// and <see cref="WriteFile"/> does not return until the write operation is complete.
        /// The system updates the <see cref="OVERLAPPED"/> offset before <see cref="WriteFile"/> returns.
        /// For more information, see CreateFile and Synchronous and Asynchronous I/O.
        /// Pipes
        /// If an anonymous pipe is being used and the read handle has been closed,
        /// when <see cref="WriteFile"/> attempts to write using the pipe's corresponding write handle,
        /// the function returns <see cref="FALSE"/> and <see cref="GetLastError"/> returns <see cref="ERROR_BROKEN_PIPE"/>.
        /// If the pipe buffer is full when an application uses the <see cref="WriteFile"/> function to write to a pipe,
        /// the write operation may not finish immediately.
        /// The write operation will be completed when a read operation(using the <see cref="ReadFile"/> function)
        /// makes more system buffer space available for the pipe.
        /// When writing to a non-blocking, byte-mode pipe handle with insufficient buffer space,
        /// <see cref="WriteFile"/> returns <see cref="TRUE"/> with <paramref name="lpNumberOfBytesWritten"/> &lt; <paramref name="nNumberOfBytesToWrite"/>.
        /// For more information about pipes, see Pipes.
        /// Transacted Operations
        /// If there is a transaction bound to the file handle, then the file write is transacted.For more information, see About Transactional NTFS.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WriteFile", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL WriteFile([In] HANDLE hFile, [In] LPCVOID lpBuffer, [In] DWORD nNumberOfBytesToWrite,
            [Out] out DWORD lpNumberOfBytesWritten, [In] in OVERLAPPED lpOverlapped);

        /// <summary>
        /// <para>
        /// Writes data to the specified file or input/output (I/O) device.
        /// It reports its completion status asynchronously, calling the specified completion routine
        /// when writing is completed or canceled and the calling thread is in an alertable wait state.
        /// To write data to a file or device synchronously, use the <see cref="WriteFile"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-writefileex"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the file or I/O device (for example, a file, file stream, physical disk, volume, console buffer,
        /// tape drive, socket, communications resource, mailslot, or pipe).
        /// This parameter can be any handle opened with the <see cref="FILE_FLAG_OVERLAPPED"/> flag by the <see cref="CreateFile"/> function,
        /// or a socket handle returned by the socket or accept function.
        /// Do not associate an I/O completion port with this handle.
        /// For more information, see the Remarks section.
        /// This handle also must have the <see cref="GENERIC_WRITE"/> access right.
        /// For more information on access rights, see File Security and Access Rights.
        /// </param>
        /// <param name="lpBuffer">
        /// A pointer to the buffer containing the data to be written to the file or device.
        /// This buffer must remain valid for the duration of the write operation.
        /// The caller must not use this buffer until the write operation is completed.
        /// </param>
        /// <param name="nNumberOfBytesToWrite">
        /// The number of bytes to be written to the file or device.
        /// A value of zero specifies a null write operation.
        /// The behavior of a null write operation depends on the underlying file system.
        /// Pipe write operations across a network are limited to 65,535 bytes per write.
        /// For more information regarding pipes, see the Remarks section.
        /// </param>
        /// <param name="lpOverlapped">
        /// A pointer to an <see cref="OVERLAPPED"/> data structure that supplies data to be used during the overlapped (asynchronous) write operation.
        /// For files that support byte offsets, you must specify a byte offset at which to start writing to the file.
        /// You specify this offset by setting the <see cref="OVERLAPPED.Offset"/>
        /// and <see cref="OVERLAPPED.OffsetHigh"/> members of the <see cref="OVERLAPPED"/> structure.
        /// For files or devices that do not support byte offsets, <see cref="OVERLAPPED.Offset"/> and <see cref="OVERLAPPED.OffsetHigh"/> are ignored.
        /// To write to the end of file, specify both the <see cref="OVERLAPPED.Offset"/>
        /// and <see cref="OVERLAPPED.OffsetHigh"/> members of the <see cref="OVERLAPPED"/> structure as 0xFFFFFFFF.
        /// This is functionally equivalent to previously calling the CreateFile function to open hFile using FILE_APPEND_DATA access.
        /// The <see cref="WriteFileEx"/> function ignores the <see cref="OVERLAPPED"/> structure's <see cref="OVERLAPPED.hEvent"/> member.
        /// An application is free to use that member for its own purposes in the context of a <see cref="WriteFileEx"/> call.
        /// <see cref="WriteFileEx"/> signals completion of its writing operation by calling, or queuing a call to,
        /// the completion routine pointed to by <paramref name="lpCompletionRoutine"/>, so it does not need an event handle.
        /// The <see cref="WriteFileEx"/> function does use the <see cref="OVERLAPPED.Internal"/>
        /// and <see cref="OVERLAPPED.InternalHigh"/> members of the <see cref="OVERLAPPED"/> structure.
        /// You should not change the value of these members.
        /// The <see cref="OVERLAPPED"/> data structure must remain valid for the duration of the write operation.
        /// It should not be a variable that can go out of scope while the write operation is pending completion.
        /// </param>
        /// <param name="lpCompletionRoutine">
        /// A pointer to a completion routine to be called when the write operation has been completed and the calling thread is in an alertable wait state.
        /// For more information about this completion routine, see <see cref="LPOVERLAPPED_COMPLETION_ROUTINE"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If the WriteFileEx function succeeds, the calling thread has an asynchronous I/O operation pending: the overlapped write operation to the file.
        /// When this I/O operation finishes, and the calling thread is blocked in an alertable wait state,
        /// the operating system calls the function pointed to by <paramref name="lpCompletionRoutine"/>,
        /// and the wait completes with a return code of <see cref="WAIT_IO_COMPLETION"/>.
        /// If the function succeeds and the file-writing operation finishes, but the calling thread is not in an alertable wait state,
        /// the system queues the call to *<paramref name="lpCompletionRoutine"/>, holding the call until the calling thread enters an alertable wait state.
        /// For more information about alertable wait states and overlapped input/output operations, see About Synchronization.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WriteFileEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL WriteFileEx([In] HANDLE hFile, [In] LPCVOID lpBuffer, [In] DWORD nNumberOfBytesToWrite,
            [In] in OVERLAPPED lpOverlapped, [In] LPOVERLAPPED_COMPLETION_ROUTINE lpCompletionRoutine);

        /// <summary>
        /// <para>
        /// Retrieves data from an array of buffers and writes the data to a file.
        /// The function starts writing data to the file at a position that is specified by an <see cref="OVERLAPPED"/> structure.
        /// The <see cref="WriteFileGather"/> function operates asynchronously.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-writefilegather"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the file.
        /// The file handle must be created with the <see cref="GENERIC_WRITE"/> access right,
        /// and the <see cref="FILE_FLAG_OVERLAPPED"/> and <see cref="FILE_FLAG_NO_BUFFERING"/> flags.
        /// For more information, see File Security and Access Rights.
        /// </param>
        /// <param name="aSegmentArray">
        /// A pointer to an array of <see cref="FILE_SEGMENT_ELEMENT"/> buffers that contain the data.
        /// For a description of this union, see Remarks.
        /// Each element contains the address of one page of data.
        /// Note To determine the size of a system page, use the <see cref="GetSystemInfo"/> function.
        /// The array must contain enough elements to store <paramref name="nNumberOfBytesToWrite"/> bytes of data,
        /// and one element for the terminating NULL.
        /// For example, if there are 40 KB to be read and the page size is 4 KB,
        /// the array must have 11 elements that includes 10 elements for the data and one element for the NULL.
        /// Each buffer must be at least the size of a system memory page and must be aligned on a system memory page size boundary.
        /// The system writes one system memory page of data from each buffer.
        /// The function gathers the data from the buffers in a sequential order.
        /// For example, it writes data to the file from the first buffer, then the second buffer, and so on until there is no more data.
        /// Due to the asynchronous operation of this function, precautions must be taken to ensure
        /// that this parameter always references valid memory for the lifetime of the asynchronous writes.
        /// For instance, a common programming error is to use local stack storage and then allow execution to run out of scope.
        /// </param>
        /// <param name="nNumberOfBytesToWrite">
        /// The total number of bytes to be written.
        /// Each element of <paramref name="aSegmentArray"/> contains a one-page chunk of this total.
        /// Because the file must be opened with <paramref name="aSegmentArray"/>,
        /// the number of bytes must be a multiple of the sector size of the file system where the file is located.
        /// If <paramref name="nNumberOfBytesToWrite"/> is zero (0), the function performs a null write operation.
        /// The behavior of a null write operation depends on the underlying file system.
        /// If <paramref name="nNumberOfBytesToWrite"/> is not zero (0) and the offset and length of the write place data
        /// beyond the current end of the file, the <see cref="WriteFileGather"/> function extends the file.
        /// </param>
        /// <param name="lpReserved">
        /// This parameter is reserved for future use and must be <see cref="NULL"/>.
        /// </param>
        /// <param name="lpOverlapped">
        /// A pointer to an <see cref="OVERLAPPED"/> data structure.
        /// The <see cref="WriteFileGather"/> function requires a valid <see cref="OVERLAPPED"/> structure.
        /// The <paramref name="lpOverlapped"/> parameter cannot be <see cref="NullRef{OVERLAPPED}"/>.
        /// The <see cref="WriteFileGather"/> function starts writing data to the file at a position
        /// that is specified by the <see cref="OVERLAPPED.Offset"/> and <see cref="OVERLAPPED.OffsetHigh"/> members of the <see cref="OVERLAPPED"/> structure.
        /// The <see cref="WriteFileGather"/> function may return before the write operation is complete.
        /// In that scenario, the <see cref="WriteFileGather"/> function returns the value zero (0),
        /// and the <see cref="GetLastError"/> function returns the value <see cref="ERROR_IO_PENDING"/>.
        /// This asynchronous operation of the <see cref="WriteFileGather"/> function lets the calling process continue while the write operation completes.
        /// You can call the <see cref="GetOverlappedResult"/>, <see cref="HasOverlappedIoCompleted"/>,
        /// or <see cref="GetQueuedCompletionStatus"/> function to obtain information about the completion of the write operation.
        /// For more information, see Synchronous and Asynchronous I/O.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call the <see cref="GetLastError"/> function.
        /// If the function returns before the write operation is complete, the function returns <see cref="FALSE"/>,
        /// and the <see cref="GetLastError"/> function returns <see cref="ERROR_IO_PENDING"/>.
        /// </returns>
        /// <remarks>
        /// This function is not supported for 32-bit applications by WOW64 on the Itanium-based systems.
        /// Assigning a pointer to the <see cref="FILE_SEGMENT_ELEMENT.Buffer"/> member will sign-extend the value if the code is compiled as 32-bits;
        /// this can break large-address aware applications running on systems configured with 4-Gigabyte Tuning or running under WOW64 on 64-bit Windows.
        /// Therefore, use the PtrToPtr64 macro when assigning pointers to Buffer.
        /// If part of the file specified by hFile is locked by another process,
        /// and the write operation overlaps the locked portion, the <see cref="WriteFileGather"/> function fails.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WriteFileGather", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL WriteFileGather([In] HANDLE hFile, [In] FILE_SEGMENT_ELEMENT[] aSegmentArray, [In] DWORD nNumberOfBytesToWrite,
            [In] IntPtr lpReserved, [In][Out] ref OVERLAPPED lpOverlapped);

#pragma warning disable IDE1006
        /// <summary>
        /// <para>
        /// 
        /// </para>
        /// </summary>
        /// <param name="hFile"></param>
        /// <param name="lpBuffer"></param>
        /// <param name="lBytes"></param>
        /// <returns></returns>
        [Obsolete]
        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "_hread", ExactSpelling = true, SetLastError = true, ThrowOnUnmappableChar = true)]
        public static extern long _hread([In] HFILE hFile, [In] LPVOID lpBuffer, [In] long lBytes);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hFile"></param>
        /// <param name="lpBuffer"></param>
        /// <param name="lBytes"></param>
        /// <returns></returns>
        [Obsolete]
        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "_hread", ExactSpelling = true, SetLastError = true, ThrowOnUnmappableChar = true)]
        public static extern long _hwrite([In] HFILE hFile, [In] LPCCH lpBuffer, [In] long lBytes);

        /// <summary>
        /// <para>
        /// The <see cref="_lclose"/> function closes the specified file so that it is no longer available for reading or writing.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-_lclose"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// Identifies the file to be closed.
        /// This handle is returned by the function that created or last opened the file.
        /// </param>
        /// <returns>
        /// Handle to file to close.
        /// </returns>
        [Obsolete("This function is provided for compatibility with 16-bit versions of Windows. Win32-based applications should use the CloseHandle function.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "_lclose", ExactSpelling = true, SetLastError = true, ThrowOnUnmappableChar = true)]
        public static extern HFILE _lclose([In] HFILE hFile);

        /// <summary>
        /// <para>
        /// Creates or opens the specified file. This documentation is included only for troubleshooting existing code.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-_lcreat"/>
        /// </para>
        /// </summary>
        /// <param name="lpPathName">
        /// The name of the file. The string must consist of characters from the Windows ANSI character set.
        /// </param>
        /// <param name="iAttribute">
        /// This parameter must be set to one of the following values.
        /// 0: Normal. Can be read from or written to without restriction.
        /// 1: Read-only. Cannot be opened for write.
        /// 2: Hidden. Not found by directory search.
        /// 4: System. Not found by directory search.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a file handle. Otherwise, the return value is <see cref="HFILE_ERROR"/>.
        /// To get extended error information, use the <see cref="GetLastError"/> function.
        /// </returns>
        /// <remarks>
        /// If the file does not exist, <see cref="_lcreat"/> creates and opens a new file for writing.
        /// If the file does exist, <see cref="_lcreat"/> truncates the file size to zero and opens it for reading and writing.
        /// When the function opens a file, the pointer is set to the beginning of the file.
        /// Use the <see cref="_lcreat"/> function with care.
        /// It can open any file, even one already opened by another function.
        /// </remarks>
        [Obsolete("This function is provided for compatibility with 16-bit versions of Windows. Win32-based applications should use the CreateFile function.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "_lcreat", ExactSpelling = true, SetLastError = true, ThrowOnUnmappableChar = true)]
        public static extern HFILE _lcreat([MarshalAs(UnmanagedType.LPStr)][In] string lpPathName, [In] int iAttribute);

        /// <summary>
        /// <para>
        /// Repositions the file pointer for the specified file.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-_llseek"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to an open file. This handle is created by <see cref="_lcreat"/>.
        /// </param>
        /// <param name="lOffset">
        /// The number of bytes that the file pointer is to be moved.
        /// </param>
        /// <param name="iOrigin">
        /// The starting point and the direction that the pointer will be moved.
        /// This parameter must be set to one of the following values.
        /// 0: Moves the pointer from the beginning of the file.
        /// 1: Moves the file from its current location.
        /// 2: Moves the pointer from the end of the file.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value specifies the new offset.
        /// Otherwise, the return value is <see cref="HFILE_ERROR"/>.
        /// To get extended error information, use the <see cref="GetLastError"/> function.
        /// </returns>
        /// <remarks>
        /// When a file is initially opened, the file pointer is set to the beginning of the file.
        /// The <see cref="_llseek"/> function moves the pointer without reading data, which allows random access to the content of the file.
        /// </remarks>
        [Obsolete("This function is provided for compatibility with 16-bit versions of Windows. Win32-based applications should use the SetFilePointer function.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "_llseek", ExactSpelling = true, SetLastError = true, ThrowOnUnmappableChar = true)]
        public static extern LONG _llseek([In] HFILE hFile, [In] LONG lOffset, [In] int iOrigin);

        /// <summary>
        /// <para>
        /// The <see cref="_lopen"/> function opens an existing file and sets the file pointer to the beginning of the file.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-_lopen"/>
        /// </para>
        /// </summary>
        /// <param name="lpPathName">
        /// Pointer to a null-terminated string that names the file to open.
        /// The string must consist of characters from the Windows ANSI character set.
        /// </param>
        /// <param name="iReadWrite">
        /// Specifies the modes in which to open the file.
        /// This parameter consists of one access mode and an optional share mode.
        /// The access mode must be one of the following values: <see cref="OF_READ"/>, <see cref="OF_READWRITE"/>, <see cref="OF_WRITE"/>
        /// The share mode can be one of the following values: <see cref="OF_SHARE_COMPAT"/>, <see cref="OF_SHARE_DENY_NONE"/>,
        /// <see cref="OF_SHARE_DENY_READ"/>, <see cref="OF_SHARE_DENY_WRITE"/>, <see cref="OF_SHARE_EXCLUSIVE"/>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a file handle.
        /// </returns>
        [Obsolete("This function is provided for compatibility with 16-bit versions of Windows. Win32-based applications should use the CreateFile function.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "_lopen", ExactSpelling = true, SetLastError = true, ThrowOnUnmappableChar = true)]
        public static extern HFILE _lopen([MarshalAs(UnmanagedType.LPStr)][In] string lpPathName, [In] OpenFileFlags iReadWrite);

        /// <summary>
        /// <para>
        /// The <see cref="_lread"/> function reads data from the specified file.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-_lread"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// Identifies the specified file.
        /// </param>
        /// <param name="lpBuffer">
        /// Pointer to a buffer that contains the data read from the file.
        /// </param>
        /// <param name="uBytes">
        /// Specifies the number of bytes to be read from the file.
        /// </param>
        /// <returns>
        /// The return value indicates the number of bytes actually read from the file.
        /// If the number of bytes read is less than <paramref name="uBytes"/>,
        /// the function has reached the end of file (EOF) before reading the specified number of bytes.
        /// </returns>
        [Obsolete("This function is provided for compatibility with 16-bit versions of Windows. Win32-based applications should use the ReadFile function.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "_lopen", ExactSpelling = true, SetLastError = true, ThrowOnUnmappableChar = true)]
        public static extern UINT _lread([In] HFILE hFile, [In] LPVOID lpBuffer, [In] UINT uBytes);

        /// <summary>
        /// <para>
        /// Writes data to the specified file.
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the file that receives the data.
        /// This handle is created by <see cref="_lcreat"/>.
        /// </param>
        /// <param name="lpBuffer">
        /// The buffer that contains the data to be added.
        /// </param>
        /// <param name="uBytes">
        /// The number of bytes to write to the file.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the number of bytes written to the file.
        /// Otherwise, the return value is <see cref="HFILE_ERROR"/>.
        /// To get extended error information, use the <see cref="GetLastError"/> function.
        /// </returns>
        [Obsolete("This function is provided for compatibility with 16-bit versions of Windows. Win32-based applications should use the WriteFile function.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "_lopen", ExactSpelling = true, SetLastError = true, ThrowOnUnmappableChar = true)]
        public static extern UINT _lwrite([In] HFILE hFile, [In] LPCCH lpBuffer, [In] UINT uBytes);
#pragma warning restore IDE1006
    }
}
