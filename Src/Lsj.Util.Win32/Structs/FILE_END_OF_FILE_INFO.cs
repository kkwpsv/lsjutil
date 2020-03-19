using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains the specified value to which the end of the file should be set.
    /// Used for file handles.
    /// Use only when calling <see cref="SetFileInformationByHandle"/>.
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILE_END_OF_FILE_INFO
    {
        /// <summary>
        /// The specified value for the new end of the file.
        /// </summary>
        public LARGE_INTEGER EndOfFile;
    }
}
