using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="FILE_STORAGE_INFO"/> Flags.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/ns-winbase-file_storage_info
    /// </para>
    /// </summary>
    public enum StorageInfoFlags : uint
    {
        /// <summary>
        /// When set, this flag indicates that the logical sectors of the storage device are aligned to physical sector boundaries.
        /// </summary>
        STORAGE_INFO_FLAGS_ALIGNED_DEVICE = 0x00000001,

        /// <summary>
        /// When set, this flag indicates that the partition is aligned to physical sector boundaries on the storage device.
        /// </summary>
        STORAGE_INFO_FLAGS_PARTITION_ALIGNED_ON_DEVICE = 0x00000002,
    }
}
