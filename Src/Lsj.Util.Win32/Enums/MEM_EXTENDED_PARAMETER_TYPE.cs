using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Defines values for extended parameters used for file mapping into an address space.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ne-winnt-mem_extended_parameter_type
    /// </para>
    /// </summary>
    public enum MEM_EXTENDED_PARAMETER_TYPE : byte
    {
        /// <summary>
        /// 
        /// </summary>
        MemExtendedParameterInvalidType = 0,

        /// <summary>
        /// This extended parameter type is used to specify alignment and virtual address range restrictions
        /// for new memory allocations created by <see cref="VirtualAlloc2"/> and <see cref="MapViewOfFile3"/>.
        /// </summary>
        MemExtendedParameterAddressRequirements,

        /// <summary>
        /// This extended parameter type is used to specify the preferred NUMA node
        /// for new memory allocations created by <see cref="VirtualAlloc2"/> and <see cref="MapViewOfFile3"/>.
        /// </summary>
        MemExtendedParameterNumaNode,

        /// <summary>
        /// 
        /// </summary>
        MemExtendedParameterPartitionHandle,

        /// <summary>
        /// 
        /// </summary>
        MemExtendedParameterUserPhysicalHandle,

        /// <summary>
        /// 
        /// </summary>
        MemExtendedParameterAttributeFlags,

        /// <summary>
        /// 
        /// </summary>
        MemExtendedParameterMax
    }
}
