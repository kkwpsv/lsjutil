using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Enums.FILE_INFO_BY_HANDLE_CLASS;
using static Lsj.Util.Win32.BaseTypes.BOOLEAN;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains the name to which the file should be renamed.
    /// Use only when calling <see cref="SetFileInformationByHandle"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/ns-winbase-file_rename_info"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILE_RENAME_INFO
    {
        private DWORD _field0;

        /// <summary>
        /// <para>
        /// This field is used when <see cref="SetFileInformationByHandle"/>'s FileInformationClass parameter is set to <see cref="FileRenameInfo"/>.
        /// If this field is <see cref="TRUE"/> and the target file exists then the target file will be replaced by the source file.
        /// If this field is <see cref="FALSE"/> and the target file exists then operation will return an error.
        /// </para>
        /// </summary>
        public BOOLEAN ReplaceIfExists
        {
            get => (BOOLEAN)((byte)(int)_field0 == 0);
            set => _field0 = _field0 & 0xFFFFFF00 | (uint)(value ? 1 : 0);
        }

        /// <summary>
        /// This field is used when <see cref="SetFileInformationByHandle"/>'s FileInformationClass parameter is set to FileRenameInfoEx.
        /// </summary>
        public DWORD Flags
        {
            get => _field0;
            set => _field0 = value;
        }

        /// <summary>
        /// This field should be set to <see cref="NULL"/>.
        /// </summary>
        public HANDLE RootDirectory;

        /// <summary>
        /// The size of <see cref="FileName"/> in bytes, not including the NUL-termination.
        /// </summary>
        public DWORD FileNameLength;

        /// <summary>
        /// <para>
        /// A NUL-terminated wide-character string containing the new path to the file.
        /// The value can be one of the following:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// An absolute path (drive, directory, and filename).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A path relative to the process's current directory.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The new name of an NTFS file stream, starting with .
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        public WCHAR FileName;
    }
}
