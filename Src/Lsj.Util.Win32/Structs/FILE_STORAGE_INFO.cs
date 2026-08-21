using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.FILE_INFO_BY_HANDLE_CLASS;
using static Lsj.Util.Win32.Enums.FileStorageInfoFlags;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains directory information for a file.
    /// This structure is returned from the <see cref="GetFileInformationByHandleEx"/> function
    /// when <see cref="FileStorageInfo"/> is passed in the FileInformationClass parameter.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/ns-winbase-file_storage_info"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// If a volume is built on top of storage devices with different properties (for example a mirrored, spanned, striped, or RAID configuration)
    /// the sizes returned are those of the largest size of any of the underlying storage devices.
    /// </remarks>
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
        /// <para>
        /// This member can contain combinations of flags specifying information about the alignment of the storage.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="STORAGE_INFO_FLAGS_ALIGNED_DEVICE"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// When set, this flag indicates that the logical sectors of the storage device are aligned to physical sector boundaries.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="STORAGE_INFO_FLAGS_PARTITION_ALIGNED_ON_DEVICE"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// When set, this flag indicates that the partition is aligned to physical sector boundaries on the storage device.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public FileStorageInfoFlags Flags;

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
