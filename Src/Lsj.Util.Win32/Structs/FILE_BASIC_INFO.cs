using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.FILE_INFO_BY_HANDLE_CLASS;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains the basic information for a file.
    /// Used for file handles.
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILE_BASIC_INFO
    {
        /// <summary>
        /// The time the file was created in <see cref="FILETIME"/> format,
        /// which is a 64-bit value representing the number of 100-nanosecond intervals since January 1, 1601 (UTC).
        /// </summary>
        public LARGE_INTEGER CreationTime;

        /// <summary>
        /// The time the file was last accessed in <see cref="FILETIME"/> format.
        /// </summary>
        public LARGE_INTEGER LastAccessTime;

        /// <summary>
        /// The time the file was last written to in <see cref="FILETIME"/> format.
        /// </summary>
        public LARGE_INTEGER LastWriteTime;

        /// <summary>
        /// The time the file was changed in <see cref="FILETIME"/> format.
        /// </summary>
        public LARGE_INTEGER ChangeTime;

        /// <summary>
        /// The file attributes.
        /// For a list of attributes, see File Attribute Constants.
        /// If this is set to 0 in a <see cref="FILE_BASIC_INFO"/> structure passed to <see cref="SetFileInformationByHandle"/>
        /// then none of the attributes are changed.
        /// </summary>
        public FileAttributes FileAttributes;
    }
}
