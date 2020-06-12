using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Represents a logical processor in a processor group.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-processor_number
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PROCESSOR_NUMBER
    {
        /// <summary>
        /// The processor group to which the logical processor is assigned.
        /// </summary>
        public WORD Group;

        /// <summary>
        /// The number of the logical processor relative to the group.
        /// </summary>
        public BYTE Number;

        /// <summary>
        /// This parameter is reserved.
        /// </summary>
        public BYTE Reserved;
    }
}
