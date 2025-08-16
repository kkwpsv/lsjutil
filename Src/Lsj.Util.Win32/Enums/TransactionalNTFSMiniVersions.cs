namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Transactional NTFS mini versions
    /// </summary>
    public enum TransactionalNTFSMiniVersions : ushort
    {
        /// <summary>
        /// TXFS_MINIVERSION_COMMITTED_VIEW
        /// </summary>
        TXFS_MINIVERSION_COMMITTED_VIEW = 0x0000,

        /// <summary>
        /// TXFS_MINIVERSION_DIRTY_VIEW
        /// </summary>
        TXFS_MINIVERSION_DIRTY_VIEW = 0xFFFF,

        /// <summary>
        /// TXFS_MINIVERSION_DEFAULT_VIEW
        /// </summary>
        TXFS_MINIVERSION_DEFAULT_VIEW = 0xFFFE,
    }
}
