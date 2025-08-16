using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Work thread flags
    /// </summary>
    [Flags]
    public enum WorkThreadFlags : ulong
    {
        /// <summary>
        /// WT_EXECUTEDEFAULT
        /// </summary>
        WT_EXECUTEDEFAULT = 0x00000000,

        /// <summary>
        /// WT_EXECUTEINIOTHREAD
        /// </summary>
        WT_EXECUTEINIOTHREAD = 0x00000001,

        /// <summary>
        /// WT_EXECUTEINPERSISTENTTHREAD
        /// </summary>
        WT_EXECUTEINPERSISTENTTHREAD = 0x00000080,

        /// <summary>
        /// WT_EXECUTEINWAITTHREAD
        /// </summary>
        WT_EXECUTEINWAITTHREAD = 0x00000004,

        /// <summary>
        /// WT_EXECUTELONGFUNCTION
        /// </summary>
        WT_EXECUTELONGFUNCTION = 0x00000010,

        /// <summary>
        /// WT_EXECUTEONLYONCE
        /// </summary>
        WT_EXECUTEONLYONCE = 0x00000008,

        /// <summary>
        /// WT_TRANSFER_IMPERSONATION
        /// </summary>
        WT_TRANSFER_IMPERSONATION = 0x00000100,

        /// <summary>
        /// WT_EXECUTEINTIMERTHREAD
        /// </summary>
        WT_EXECUTEINTIMERTHREAD = 0x00000020,
    }
}
