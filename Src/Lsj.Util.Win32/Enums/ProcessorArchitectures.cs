namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Processor architectures
    /// </summary>
    public enum ProcessorArchitectures : ushort
    {
        /// <summary>
        /// PROCESSOR_ARCHITECTURE_AMD64
        /// </summary>
        PROCESSOR_ARCHITECTURE_AMD64 = 9,

        /// <summary>
        /// PROCESSOR_ARCHITECTURE_ARM
        /// </summary>
        PROCESSOR_ARCHITECTURE_ARM = 5,

        /// <summary>
        /// PROCESSOR_ARCHITECTURE_ARM64
        /// </summary>
        PROCESSOR_ARCHITECTURE_ARM64 = 12,

        /// <summary>
        /// PROCESSOR_ARCHITECTURE_IA64
        /// </summary>
        PROCESSOR_ARCHITECTURE_IA64 = 6,

        /// <summary>
        /// PROCESSOR_ARCHITECTURE_INTEL
        /// </summary>
        PROCESSOR_ARCHITECTURE_INTEL = 0,

        /// <summary>
        /// PROCESSOR_ARCHITECTURE_UNKNOWN
        /// </summary>
        PROCESSOR_ARCHITECTURE_UNKNOWN = 0xffff,

    }

}
