namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// ACTCTX_FLAG
    /// </summary>
    public enum ACTCTX_FLAG : uint
    {
        /// <summary>
        /// ACTCTX_FLAG_PROCESSOR_ARCHITECTURE_VALID
        /// </summary>
        ACTCTX_FLAG_PROCESSOR_ARCHITECTURE_VALID = 0x00000001,

        /// <summary>
        /// ACTCTX_FLAG_LANGID_VALID
        /// </summary>
        ACTCTX_FLAG_LANGID_VALID = 0x00000002,

        /// <summary>
        /// ACTCTX_FLAG_ASSEMBLY_DIRECTORY_VALID
        /// </summary>
        ACTCTX_FLAG_ASSEMBLY_DIRECTORY_VALID = 0x00000004,

        /// <summary>
        /// ACTCTX_FLAG_RESOURCE_NAME_VALID
        /// </summary>
        ACTCTX_FLAG_RESOURCE_NAME_VALID = 0x00000008,

        /// <summary>
        /// ACTCTX_FLAG_SET_PROCESS_DEFAULT
        /// </summary>
        ACTCTX_FLAG_SET_PROCESS_DEFAULT = 0x00000010,

        /// <summary>
        /// ACTCTX_FLAG_APPLICATION_NAME_VALID
        /// </summary>
        ACTCTX_FLAG_APPLICATION_NAME_VALID = 0x00000020,

        /// <summary>
        /// ACTCTX_FLAG_SOURCE_IS_ASSEMBLYREF
        /// </summary>
        ACTCTX_FLAG_SOURCE_IS_ASSEMBLYREF = 0x00000040,

        /// <summary>
        /// ACTCTX_FLAG_HMODULE_VALID
        /// </summary>
        ACTCTX_FLAG_HMODULE_VALID = 0x00000080,
    }
}
