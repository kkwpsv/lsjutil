using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.IoControlCodes;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains a range of a file to set to zeros.
    /// This structure is used by the <see cref="FSCTL_SET_ZERO_DATA"/> control code
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winioctl/ns-winioctl-file_zero_data_information"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILE_ZERO_DATA_INFORMATION
    {
        /// <summary>
        /// The file offset of the start of the range to set to zeros, in bytes.
        /// </summary>
        public LARGE_INTEGER FileOffset;

        /// <summary>
        /// The byte offset of the first byte beyond the last zeroed byte.
        /// </summary>
        public LARGE_INTEGER BeyondFinalZero;
    }
}
