using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="VirtualFree"/> Types
    /// </summary>
    public enum VirtualFreeTypes : uint
    {
        /// <summary>
        /// MEM_COALESCE_PLACEHOLDERS
        /// </summary>
        MEM_COALESCE_PLACEHOLDERS = 0x00000001,

        /// <summary>
        /// MEM_PRESERVE_PLACEHOLDER
        /// </summary>
        MEM_PRESERVE_PLACEHOLDER = 0x00000002,

        /// <summary>
        /// MEM_DECOMMIT
        /// </summary>
        MEM_DECOMMIT = 0x00004000,

        /// <summary>
        /// MEM_RELEASE
        /// </summary>
        MEM_RELEASE = 0x00008000,

        /// <summary>
        /// MEM_FREE
        /// </summary>
        MEM_FREE = 0x00010000,
    }
}
