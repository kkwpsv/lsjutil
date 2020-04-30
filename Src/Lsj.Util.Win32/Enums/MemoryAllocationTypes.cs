namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Memory Allocation Types
    /// </summary>
    public enum MemoryAllocationTypes : uint
    {
        /// <summary>
        /// MEM_COMMIT
        /// </summary>
        MEM_COMMIT = 0x00001000,

        /// <summary>
        /// MEM_RESERVE
        /// </summary>
        MEM_RESERVE = 0x00002000,

        /// <summary>
        /// MEM_REPLACE_PLACEHOLDER
        /// </summary>
        MEM_REPLACE_PLACEHOLDER = 0x00004000,

        /// <summary>
        /// MEM_RESERVE_PLACEHOLDER
        /// </summary>
        MEM_RESERVE_PLACEHOLDER = 0x00040000,

        /// <summary>
        /// MEM_RESET
        /// </summary>
        MEM_RESET = 0x00080000,

        /// <summary>
        /// MEM_TOP_DOWN
        /// </summary>
        MEM_TOP_DOWN = 0x00100000,

        /// <summary>
        /// MEM_WRITE_WATCH
        /// </summary>
        MEM_WRITE_WATCH = 0x00200000,

        /// <summary>
        /// MEM_PHYSICAL
        /// </summary>
        MEM_PHYSICAL = 0x00400000,

        /// <summary>
        /// MEM_ROTATE
        /// </summary>
        MEM_ROTATE = 0x00800000,

        /// <summary>
        /// MEM_DIFFERENT_IMAGE_BASE_OK
        /// </summary>
        MEM_DIFFERENT_IMAGE_BASE_OK = 0x00800000,

        /// <summary>
        /// MEM_RESET_UNDO
        /// </summary>
        MEM_RESET_UNDO = 0x01000000,

        /// <summary>
        /// MEM_LARGE_PAGES
        /// </summary>
        MEM_LARGE_PAGES = 0x20000000,

        /// <summary>
        /// MEM_4MB_PAGES
        /// </summary>
        MEM_4MB_PAGES = 0x80000000,

        /// <summary>
        /// MEM_64K_PAGES
        /// </summary>
        MEM_64K_PAGES = (MEM_LARGE_PAGES | MEM_PHYSICAL),

        /// <summary>
        /// MEM_UNMAP_WITH_TRANSIENT_BOOST
        /// </summary>
        MEM_UNMAP_WITH_TRANSIENT_BOOST = 0x00000001,
    }
}
