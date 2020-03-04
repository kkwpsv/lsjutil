using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Receives the requested file attribute information.
    /// Used for any handles.
    /// Use only when calling <see cref="GetFileInformationByHandleEx"/>.
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILE_ATTRIBUTE_TAG_INFO
    {
        /// <summary>
        /// The file attribute information.
        /// </summary>
        public uint FileAttributes;

        /// <summary>
        /// The reparse tag.
        /// </summary>
        public uint ReparseTag;
    }
}
