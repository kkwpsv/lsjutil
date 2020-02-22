using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// File Creation Disposition
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/en-us/windows/win32/api/fileapi/nf-fileapi-createfilew
    /// </para>
    /// </summary>
    public enum FileCreationDispositions : uint
    {
        /// <summary>
        /// Creates a new file, always.
        /// If the specified file exists and is writable, the function overwrites the file, the function succeeds,
        /// and last-error code is set to <see cref="SystemErrorCodes.ERROR_ALREADY_EXISTS"/>.
        /// If the specified file does not exist and is a valid path, a new file is created, the function succeeds,
        /// and the last-error code is set to <see cref="SystemErrorCodes.ERROR_SUCCESS"/>.
        /// For more information, see the Remarks section of this topic.
        /// </summary>
        CREATE_ALWAYS = 2,

        /// <summary>
        /// Creates a new file, only if it does not already exist.
        /// If the specified file exists, the function fails and the last-error code is set to <see cref="SystemErrorCodes.ERROR_FILE_EXISTS"/> (80).
        /// If the specified file does not exist and is a valid path to a writable location, a new file is created.
        /// </summary>
        CREATE_NEW = 1,

        /// <summary>
        /// Opens a file, always.
        /// If the specified file exists, the function succeeds and the last-error code is set to <see cref="SystemErrorCodes.ERROR_ALREADY_EXISTS"/>.
        /// If the specified file does not exist and is a valid path to a writable location,
        /// the function creates a file and the last-error code is set to <see cref="SystemErrorCodes.ERROR_SUCCESS"/>.
        /// </summary>
        OPEN_ALWAYS = 4,

        /// <summary>
        /// Opens a file or device, only if it exists.
        /// If the specified file or device does not exist, the function fails and
        /// the last-error code is set to <see cref="SystemErrorCodes.ERROR_FILE_NOT_FOUND"/>.
        /// For more information about devices, see the Remarks section.
        /// </summary>
        OPEN_EXISTING = 3,

        /// <summary>
        /// Opens a file and truncates it so that its size is zero bytes, only if it exists.
        /// If the specified file does not exist, the function fails and 
        /// the last-error code is set to <see cref="SystemErrorCodes.ERROR_FILE_NOT_FOUND"/>.
        /// The calling process must open the file with the <see cref="GenericAccessRights.GENERIC_WRITE"/> bit set
        /// as part of the dwDesiredAccess parameter.
        /// </summary>
        TRUNCATE_EXISTING = 5,
    }
}
