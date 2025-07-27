using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.MEM_EXTENDED_PARAMETER_TYPE;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Represents an extended parameter for a function that manages virtual memory.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-mem_extended_parameter"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode, Pack = 8)]
    public struct MEM_EXTENDED_PARAMETER
    {
        /// <summary>
        /// <para>
        /// A <see cref="MEM_EXTENDED_PARAMETER_TYPE"/> value that indicates the type of the parameter.
        /// </para>
        /// <para>
        /// If <see cref="Type"/> is set to <see cref="MemExtendedParameterAddressRequirements"/>,
        /// then <see cref="Pointer"/> must be a pointer to a caller-allocated <see cref="MEM_ADDRESS_REQUIREMENTS"/> structure
        /// that specifies the lowest and highest base address and alignment.
        /// </para>
        /// <para>
        /// If <see cref="Type"/> is set to <see cref="MemExtendedParameterNumaNode"/>,
        /// then <see cref="ULong64"/> must be set to the desired node number.
        /// </para>
        /// <para>
        /// If <see cref="Type"/> is set to <see cref="MemExtendedParameterAttributeFlags"/>,
        /// then <see cref="ULong64"/> must be set to a value that contains the desired flags:
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Flag
        /// </term>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="MEM_EXTENDED_PARAMETER_NONPAGED"/>
        /// </term>
        /// <term>
        /// 0x02
        /// </term>
        /// <term>
        /// The allocation is non-pageable.
        /// </term>
        /// </item>
        /// <item>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MEM_EXTENDED_PARAMETER_NONPAGED_LARGE"/>
        /// </term>
        /// <term>
        /// 0x08
        /// </term>
        /// <term>
        /// The allocation is mapped using large pages.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MEM_EXTENDED_PARAMETER_NONPAGED_HUGE"/>
        /// </term>
        /// <term>
        /// 0x10
        /// </term>
        /// <term>
        /// The allocation is mapped using huge pages.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MEM_EXTENDED_PARAMETER_EC_CODE"/>
        /// </term>
        /// <term>
        /// 0x40
        /// </term>
        /// <term>
        /// The allocation will contain emulation-compatible (EC) code.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        [FieldOffset(0)]
        public MEM_EXTENDED_PARAMETER_TYPE Type;

        /// <summary>
        /// If <see cref="Type"/> is set to <see cref="MemExtendedParameterNumaNode"/>,
        /// then <see cref="ULong64"/> must be set to the desired node number.
        /// </summary>
        [FieldOffset(8)]
        public DWORD64 ULong64;

        /// <summary>
        /// If Type is set to <see cref="MemExtendedParameterAddressRequirements"/>, then <see cref="Pointer"/> must be a pointer
        /// to a caller-allocated <see cref="MEM_ADDRESS_REQUIREMENTS"/> structure that specifies the lowest and highest base address and alignment.
        /// </summary>
        [FieldOffset(8)]
        public PVOID Pointer;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(8)]
        public SIZE_T Size;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(8)]
        public HANDLE Handle;

        /// <summary>
        /// If Type is set to <see cref="MemExtendedParameterNumaNode"/>, then <see cref="ULong"/> must be set to the desired node number.
        /// </summary>
        [FieldOffset(8)]
        public DWORD ULong;
    }
}
