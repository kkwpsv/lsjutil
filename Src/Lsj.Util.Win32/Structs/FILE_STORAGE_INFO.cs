using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.FILE_INFO_BY_HANDLE_CLASS;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains directory information for a file.
    /// This structure is returned from the <see cref="GetFileInformationByHandleEx"/> function
    /// when <see cref="FileStorageInfo"/> is passed in the FileInformationClass parameter.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/ns-winbase-file_storage_info"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILE_STORAGE_INFO
    {
        /// <summary>
        /// Logical bytes per sector reported by physical storage. This is the smallest size for which uncached I/O is supported.
        /// </summary>
        public ULONG LogicalBytesPerSector;

        /// <summary>
        /// Bytes per sector for atomic writes. Writes smaller than this may require a read before the entire block can be written atomically.
        /// </summary>
        public ULONG PhysicalBytesPerSectorForAtomicity;

        /// <summary>
        /// Bytes per sector for optimal performance for writes.
        /// </summary>
        public ULONG PhysicalBytesPerSectorForPerformance;

        /// <summary>
        /// This is the size of the block used for atomicity by the file system.
        /// This may be a trade-off between the optimal size of the physical media and one that is easier to adapt existing code and structures.
        /// </summary>
        public ULONG FileSystemEffectivePhysicalBytesPerSectorForAtomicity;

        /// <summary>
        /// This member can contain combinations of flags specifying information about the alignment of the storage.
        /// </summary>
        public StorageInfoFlags Flags;

        /// <summary>
        /// Logical sector offset within the first physical sector where the first logical sector is placed, in bytes.
        /// If this value is set to <see cref="STORAGE_INFO_OFFSET_UNKNOWN"/>, there was insufficient information to compute this field.
        /// </summary>
        public ULONG ByteOffsetForSectorAlignment;

        /// <summary>
        /// Offset used to align the partition to a physical sector boundary on the storage device, in bytes.
        /// If this value is set to <see cref="STORAGE_INFO_OFFSET_UNKNOWN"/>, there was insufficient information to compute this field.
        /// </summary>
        public ULONG ByteOffsetForPartitionAlignment;
    }
}
