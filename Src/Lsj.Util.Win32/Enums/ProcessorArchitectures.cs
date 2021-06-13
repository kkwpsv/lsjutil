namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Processor Architectures
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/sysinfoapi/ns-sysinfoapi-system_info"/>
    /// </para>
    /// </summary>
    public enum ProcessorArchitectures : ushort
    {
        /// <summary>
        /// x64 (AMD or Intel)
        /// </summary>
        PROCESSOR_ARCHITECTURE_AMD64 = 9,

        /// <summary>
        /// ARM
        /// </summary>
        PROCESSOR_ARCHITECTURE_ARM = 5,

        /// <summary>
        /// ARM64
        /// </summary>
        PROCESSOR_ARCHITECTURE_ARM64 = 12,

        /// <summary>
        /// Intel Itanium-based
        /// </summary>
        PROCESSOR_ARCHITECTURE_IA64 = 6,

        /// <summary>
        /// x86
        /// </summary>
        PROCESSOR_ARCHITECTURE_INTEL = 0,

        /// <summary>
        /// Unknown architecture.
        /// </summary>
        PROCESSOR_ARCHITECTURE_UNKNOWN = 0xffff,
    }
}
