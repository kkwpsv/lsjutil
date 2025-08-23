using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.FileActions;
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
        /// <para>
        /// The type of change that has occurred. This member can be one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_ACTION_ADDED"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// The file was added to the directory.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_ACTION_REMOVED"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// The file was removed from the directory.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_ACTION_MODIFIED"/>
        /// </para>
        /// <para>
        /// 0x00000003
        /// </para>
        /// </term>
        /// <term>
        /// The file was modified. This can be a change in the time stamp or attributes.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_ACTION_RENAMED_OLD_NAME"/>
        /// </para>
        /// <para>
        /// 0x00000004
        /// </para>
        /// </term>
        /// <term>
        /// The file was renamed and this is the old name.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FILE_ACTION_RENAMED_NEW_NAME"/>
        /// </para>
        /// <para>
        /// 0x00000005
        /// </para>
        /// </term>
        /// <term>
        /// The file was renamed and this is the new name.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public FileActions Action;

        /// <summary>
        /// The size of the file name portion of the record, in bytes. Note that this value does not include the terminating null character.
        /// </summary>
        public DWORD FileNameLength;

        /// <summary>
        /// <para>
        /// A variable-length field that contains the file name relative to the directory handle.
        /// The file name is in the Unicode character format and is not null-terminated.
        /// </para>
        /// <para>
        /// If there is both a short and long name for the file, the function will return one of these names, but it is unspecified which one.
        /// </para>
        /// </summary>
        public WCHAR FileName;
    }
}
