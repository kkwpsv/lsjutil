using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the class of heap information to be set or retrieved.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ne-winnt-heap_information_class"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// To retrieve information about a heap, use the <see cref="HeapQueryInformation"/> function.
    /// To enable features for a heap, use the <see cref="HeapSetInformation"/> function.
    /// Windows XP and Windows Server 2003:
    /// A look-aside list is a fast memory allocation mechanism that contains only fixed-sized blocks.
    /// Look-aside lists are enabled by default for heaps that support them. Starting with Windows Vista,
    /// look-aside lists are not used and the LFH is enabled by default.
    /// Look-aside lists are faster than general pool allocations that vary in size,
    /// because the system does not search for free memory that fits the allocation.
    /// In addition, access to look-aside lists is generally synchronized using fast atomic processor exchange instructions instead of mutexes or spinlocks.
    /// Look-aside lists can be created by the system or drivers. They can be allocated from paged or nonpaged pool.
    /// </remarks>
    public enum HEAP_INFORMATION_CLASS
    {
        /// <summary>
        /// The heap features that are enabled.
        /// The available features vary based on operating system.
        /// Depending on the HeapInformation parameter in the <see cref="HeapQueryInformation"/> or <see cref="HeapSetInformation"/> functions,
        /// specifying this enumeration value can indicate one of the following features:
        /// A standard heap that does not support look-aside lists.
        /// A heap that supports look-aside lists.
        /// A low-fragmentation heap (LFH), which does not support look-aside lists.
        /// For more information about look-aside lists, see the Remarks section.
        /// </summary>
        HeapCompatibilityInformation = 0,

        /// <summary>
        /// The terminate-on-corruption feature.
        /// If the heap manager detects an error in any heap used by the process,
        /// it calls the Windows Error Reporting service and terminates the process.
        /// After a process enables this feature, it cannot be disabled.
        /// </summary>
        HeapEnableTerminationOnCorruption = 1,

        /// <summary>
        /// 
        /// </summary>
        HeapOptimizeResources = 3,
    }
}
