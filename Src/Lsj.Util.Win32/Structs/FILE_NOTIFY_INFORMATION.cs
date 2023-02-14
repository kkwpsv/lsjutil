using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.FILE_ACTION;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Describes the changes found by the <see cref="ReadDirectoryChangesW"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-file_notify_information"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILE_NOTIFY_INFORMATION
    {
        /// <summary>
        /// The number of bytes that must be skipped to get to the next record.
        /// A value of zero indicates that this is the last record.
        /// </summary>
        public DWORD NextEntryOffset;

        /// <summary>
        /// The type of change that has occurred.
        /// This member can be one of the following values.
        /// <see cref="FILE_ACTION_ADDED"/>, <see cref="FILE_ACTION_REMOVED"/>, <see cref="FILE_ACTION_MODIFIED"/>,
        /// <see cref="FILE_ACTION_RENAMED_OLD_NAME"/>, <see cref="FILE_ACTION_RENAMED_NEW_NAME"/>
        /// </summary>
        public FILE_ACTION Action;

        /// <summary>
        /// The size of the file name portion of the record, in bytes. Note that this value does not include the terminating null character.
        /// </summary>
        public DWORD FileNameLength;

        /// <summary>
        /// A variable-length field that contains the file name relative to the directory handle.
        /// The file name is in the Unicode character format and is not null-terminated.
        /// If there is both a short and long name for the file, the function will return one of these names, but it is unspecified which one.
        /// </summary>
        public WCHAR FileName;
    }
}
