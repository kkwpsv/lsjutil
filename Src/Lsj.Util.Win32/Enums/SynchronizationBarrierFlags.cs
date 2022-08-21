namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Synchronization Barrier Flags
    /// </summary>
    public enum SynchronizationBarrierFlags : uint
    {
        /// <summary>
        /// SYNCHRONIZATION_BARRIER_FLAGS_SPIN_ONLY
        /// </summary>
        SYNCHRONIZATION_BARRIER_FLAGS_SPIN_ONLY = 0x01,

        /// <summary>
        /// SYNCHRONIZATION_BARRIER_FLAGS_BLOCK_ONLY
        /// </summary>
        SYNCHRONIZATION_BARRIER_FLAGS_BLOCK_ONLY = 0x02,

        /// <summary>
        /// SYNCHRONIZATION_BARRIER_FLAGS_NO_DELETE
        /// </summary>
        SYNCHRONIZATION_BARRIER_FLAGS_NO_DELETE = 0x04,
    }
}
