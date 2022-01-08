using Lsj.Util.Win32.Structs;
using System;
using static Lsj.Util.Win32.BaseTypes.ACCESS_MASK;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Copy File Flags
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/ns-winbase-copyfile2_extended_parameters"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum CopyFileFlags : uint
    {
        /// <summary>
        /// The copy will be attempted even if the destination file cannot be encrypted.
        /// </summary>
        COPY_FILE_ALLOW_DECRYPTED_DESTINATION = 0x00000008,

        /// <summary>
        /// If the source file is a symbolic link, the destination file is also a symbolic link pointing to the same file as the source symbolic link.
        /// </summary>
        COPY_FILE_COPY_SYMLINK = 0x00000800,

        /// <summary>
        /// If the destination file exists the copy operation fails immediately.
        /// If a file or directory exists with the destination name then the <see cref="CopyFile2"/> function call
        /// will fail with either <code>HRESULT_FROM_WIN32(ERROR_ALREADY_EXISTS)</code> or <code>HRESULT_FROM_WIN32(ERROR_FILE_EXISTS)</code>.
        /// If <see cref="COPY_FILE_RESUME_FROM_PAUSE"/> is also specified then a failure is only triggered if the destination file does not have a valid restart header.
        /// </summary>
        COPY_FILE_FAIL_IF_EXISTS = 0x00000001,

        /// <summary>
        /// The copy is performed using unbuffered I/O, bypassing the system cache resources.
        /// This flag is recommended for very large file copies.
        /// It is not recommended to pause copies that are using this flag.
        /// </summary>
        COPY_FILE_NO_BUFFERING = 0x00001000,

        /// <summary>
        /// Do not attempt to use the Windows Copy Offload mechanism.
        /// This is not generally recommended.
        /// </summary>
        COPY_FILE_NO_OFFLOAD = 0x00040000,

        /// <summary>
        /// The file is copied and the source file is opened for write access.
        /// </summary>
        COPY_FILE_OPEN_SOURCE_FOR_WRITE = 0x00000004,

        /// <summary>
        /// The file is copied in a manner that can be restarted if the same source and destination filenames are used again.
        /// This is slower.
        /// </summary>
        COPY_FILE_RESTARTABLE = 0x00000002,

        /// <summary>
        /// The copy is attempted, specifying <see cref="ACCESS_SYSTEM_SECURITY"/> for the source file
        /// and <code>ACCESS_SYSTEM_SECURITY | WRITE_DAC | WRITE_OWNER</code> for the destination file.
        /// If these requests are denied the access request will be reduced to the highest privilege level for which access is granted.
        /// For more information see SACL Access Right.
        /// This can be used to allow the CopyFile2ProgressRoutine callback to perform operations requiring higher privileges,
        /// such as copying the security attributes for the file.
        /// </summary>
        COPY_FILE_REQUEST_SECURITY_PRIVILEGES = 0x00002000,

        /// <summary>
        /// The destination file is examined to see if it was copied using <see cref="COPY_FILE_RESTARTABLE"/>.
        /// If so the copy is resumed.
        /// If not the file will be fully copied.
        /// </summary>
        COPY_FILE_RESUME_FROM_PAUSE = 0x00004000,
    }
}
