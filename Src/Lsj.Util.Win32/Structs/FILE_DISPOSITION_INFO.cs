using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.FileFlags;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Indicates whether a file should be deleted.
    /// Used for any handles.
    /// Use only when calling <see cref="SetFileInformationByHandle"/>.
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
        [MarshalAs(UnmanagedType.U1)]
        public bool DeleteFile;
    }
}
