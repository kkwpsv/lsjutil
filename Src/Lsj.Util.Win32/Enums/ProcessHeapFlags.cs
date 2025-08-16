using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Process heap flags
    /// </summary>
    [Flags]
    public enum ProcessHeapFlags : ushort
    {
        /// <summary>
        /// PROCESS_HEAP_ENTRY_BUSY
        /// </summary>
        PROCESS_HEAP_ENTRY_BUSY = 0x0004,

        /// <summary>
        /// PROCESS_HEAP_ENTRY_DDESHARE
        /// </summary>
        PROCESS_HEAP_ENTRY_DDESHARE = 0x0020,

        /// <summary>
        /// PROCESS_HEAP_ENTRY_MOVEABLE
        /// </summary>
        PROCESS_HEAP_ENTRY_MOVEABLE = 0x0010,

        /// <summary>
        /// PROCESS_HEAP_REGION
        /// </summary>
        PROCESS_HEAP_REGION = 0x0001,

        /// <summary>
        /// PROCESS_HEAP_UNCOMMITTED_RANGE
        /// </summary>
        PROCESS_HEAP_UNCOMMITTED_RANGE = 0x0002,
    }
}
