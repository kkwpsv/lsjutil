using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Receives the file name.
    /// Used for any handles.
    /// Use only when calling <see cref="GetFileInformationByHandleEx"/>.
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILE_NAME_INFO
    {
        /// <summary>
        /// The size of the <see cref="FileName"/> string, in bytes.
        /// </summary>
        public DWORD FileNameLength;

        /// <summary>
        /// The file name that is returned.
        /// </summary>
        public WCHAR FileName;
    }
}
