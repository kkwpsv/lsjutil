using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.HEAP_INFORMATION_CLASS;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Specifies flags for a <see cref="HeapOptimizeResources"/> operation initiated with <see cref="HeapSetInformation"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-heap_optimize_resources_information"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Mandatory parameter to the <see cref="HeapOptimizeResources"/> class.
    /// The <see cref="HEAP_OPTIMIZE_RESOURCES_CURRENT_VERSION"/> constant is available to fill in
    /// the <see cref="Version"/> field of the <see cref="HEAP_OPTIMIZE_RESOURCES_INFORMATION"/> structure.
    /// The only legal value for this field is currently 1.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct HEAP_OPTIMIZE_RESOURCES_INFORMATION
    {
        /// <summary>
        /// HEAP_OPTIMIZE_RESOURCES_CURRENT_VERSION
        /// </summary>
        public const uint HEAP_OPTIMIZE_RESOURCES_CURRENT_VERSION = 1;

        /// <summary>
        /// 
        /// </summary>
        public DWORD Version;

        /// <summary>
        /// 
        /// </summary>
        public DWORD Flags;
    }
}
