using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="FILE_STORAGE_INFO"/> flags
    /// </summary>
    public enum FileStorageInfoFlags : uint
    {
        /// <summary>
        /// STORAGE_INFO_FLAGS_ALIGNED_DEVICE
        /// </summary>
        STORAGE_INFO_FLAGS_ALIGNED_DEVICE = 0x00000001,

        /// <summary>
        /// STORAGE_INFO_FLAGS_PARTITION_ALIGNED_ON_DEVICE
        /// </summary>
        STORAGE_INFO_FLAGS_PARTITION_ALIGNED_ON_DEVICE = 0x00000002,
    }
}
