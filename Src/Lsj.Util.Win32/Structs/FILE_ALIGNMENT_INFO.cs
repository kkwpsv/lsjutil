using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.FILE_INFO_BY_HANDLE_CLASS;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains alignment information for a file.
    /// This structure is returned from the <see cref="GetFileInformationByHandleEx"/> function
    /// when <see cref="FileAlignmentInfo"/> is passed in the FileInformationClass parameter.
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILE_ALIGNMENT_INFO
    {
        /// <summary>
        /// Minimum alignment requirement, in bytes.
        /// </summary>
        public uint AlignmentRequirement;
    }
}
