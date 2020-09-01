using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.FileFlags;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Indicates whether a file should be deleted.
    /// Used for any handles.
    /// Use only when calling <see cref="SetFileInformationByHandle"/>.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/ns-winbase-file_disposition_info
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILE_DISPOSITION_INFO
    {
        /// <summary>
        /// Indicates whether the file should be deleted.
        /// Set to <see langword="true"/> to delete the file.
        /// This member has no effect if the handle was opened with <see cref="FILE_FLAG_DELETE_ON_CLOSE"/>.
        /// </summary>
        public BOOLEAN DeleteFile;
    }
}
