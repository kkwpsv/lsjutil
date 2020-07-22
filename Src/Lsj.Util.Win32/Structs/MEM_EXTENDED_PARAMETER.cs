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
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-mem_extended_parameter
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode, Pack = 8)]
    public struct MEM_EXTENDED_PARAMETER
    {
        /// <summary>
        /// A <see cref="MEM_EXTENDED_PARAMETER_TYPE"/> value that indicates the type of the parameter.
        /// If Type is set to <see cref="MemExtendedParameterAddressRequirements"/>,
        /// then <see cref="Pointer"/> must be a pointer to a caller-allocated <see cref="MEM_ADDRESS_REQUIREMENTS"/> structure
        /// that specifies the lowest and highest base address and alignment.
        /// If Type is set to <see cref="MemExtendedParameterNumaNode"/>, then <see cref="ULong"/> must be set to the desired node number.
        /// </summary>
        [FieldOffset(0)]
        public MEM_EXTENDED_PARAMETER_TYPE Type;

        /// <summary>
        /// 
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
