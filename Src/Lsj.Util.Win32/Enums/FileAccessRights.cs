using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// File Access Rights Constants
    /// The valid access rights for files and directories include the <see cref="StandardAccessRights.DELETE"/>,
    /// <see cref="StandardAccessRights.READ_CONTROL"/>, <see cref="StandardAccessRights.WRITE_DAC"/>,
    /// <see cref="StandardAccessRights.WRITE_OWNER"/>, and <see cref="StandardAccessRights.SYNCHRONIZE"/> standard access rights.
    /// The following table lists the access rights that are specific to files and directories.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/fileio/file-access-rights-constants"/>
    /// </para>
    /// </summary>
    public enum FileAccessRights : uint
    {
        /// <summary>
        /// For a directory, the right to create a file in the directory.
        /// </summary>
        FILE_ADD_FILE = 0x0002,

        /// <summary>
        /// For a directory, the right to create a subdirectory.
        /// </summary>
        FILE_ADD_SUBDIRECTORY = 0x0004,

        /// <summary>
        /// All possible access rights for a file.
        /// </summary>
        FILE_ALL_ACCESS = StandardAccessRights.STANDARD_RIGHTS_REQUIRED | StandardAccessRights.SYNCHRONIZE | 0x1FF,

        /// <summary>
        /// For a file object, the right to append data to the file.
        /// (For local files, write operations will not overwrite existing data if this flag is specified without <see cref="FILE_WRITE_DATA"/>.) 
        /// For a directory object, the right to create a subdirectory (<see cref="FILE_ADD_SUBDIRECTORY"/>).
        /// </summary>
        FILE_APPEND_DATA = 0x0004,

        /// <summary>
        /// For a named pipe, the right to create a pipe.
        /// </summary>
        FILE_CREATE_PIPE_INSTANCE = 0x0004,

        /// <summary>
        /// For a directory, the right to delete a directory and all the files it contains, including read-only files.
        /// </summary>
        FILE_DELETE_CHILD = 0x0040,

        /// <summary>
        /// For a native code file, the right to execute the file.
        /// This access right given to scripts may cause the script to be executable, depending on the script interpreter.
        /// </summary>
        FILE_EXECUTE = 0x0020,

        /// <summary>
        /// For a directory, the right to list the contents of the directory.
        /// </summary>
        FILE_LIST_DIRECTORY = 0x0001,

        /// <summary>
        /// The right to read file attributes.
        /// </summary>
        FILE_READ_ATTRIBUTES = 0x0080,

        /// <summary>
        /// For a file object, the right to read the corresponding file data.
        /// For a directory object, the right to read the corresponding directory data.
        /// </summary>
        FILE_READ_DATA = 0x0001,

        /// <summary>
        /// The right to read extended file attributes.
        /// </summary>
        FILE_READ_EA = 0x0008,

        /// <summary>
        /// For a directory, the right to traverse the directory.
        /// By default, users are assigned the BYPASS_TRAVERSE_CHECKING privilege,
        /// which ignores the <see cref="FILE_TRAVERSE"/> access right.
        /// See the remarks in File Security and Access Rights for more information.
        /// </summary>
        FILE_TRAVERSE = 0x0020,

        /// <summary>
        /// The right to write file attributes.
        /// </summary>
        FILE_WRITE_ATTRIBUTES = 0x0100,

        /// <summary>
        /// For a file object, the right to write data to the file.
        /// For a directory object, the right to create a file in the directory (<see cref="FILE_ADD_FILE"/>).
        /// </summary>
        FILE_WRITE_DATA = 0x0002,

        /// <summary>
        /// The right to write extended file attributes.
        /// </summary>
        FILE_WRITE_EA = 0x0010,

        /// <summary>
        /// Includes <see cref="StandardAccessRights.READ_CONTROL"/>, which is the right to read the information in the file or directory object's security descriptor.
        /// This does not include the information in the SACL.
        /// </summary>
        STANDARD_RIGHTS_READ = StandardAccessRights.READ_CONTROL,

        /// <summary>
        /// Same as <see cref="STANDARD_RIGHTS_READ"/>.
        /// </summary>
        STANDARD_RIGHTS_WRITE = StandardAccessRights.READ_CONTROL,

        /// <summary>
        /// FILE_GENERIC_READ
        /// </summary>
        FILE_GENERIC_READ = STANDARD_RIGHTS_READ | FILE_READ_DATA | FILE_READ_ATTRIBUTES | FILE_READ_EA | StandardAccessRights.SYNCHRONIZE,

        /// <summary>
        /// FILE_GENERIC_WRITE
        /// </summary>
        FILE_GENERIC_WRITE = STANDARD_RIGHTS_WRITE | FILE_WRITE_DATA | FILE_WRITE_ATTRIBUTES | FILE_WRITE_EA | FILE_APPEND_DATA | StandardAccessRights.SYNCHRONIZE,
    }
}
