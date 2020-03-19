using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Receives file compression information.
    /// Used for any handles.
    /// Use only when calling <see cref="GetFileInformationByHandleEx"/>.
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILE_COMPRESSION_INFO
    {
        /// <summary>
        /// The file size of the compressed file.
        /// </summary>
        public LARGE_INTEGER CompressedFileSize;

        /// <summary>
        /// The compression format that is used to compress the file.
        /// </summary>
        public ushort CompressionFormat;

        /// <summary>
        /// The factor that the compression uses.
        /// </summary>
        public byte CompressionUnitShift;

        /// <summary>
        /// The number of chunks that are shifted by compression.
        /// </summary>
        public byte ChunkShift;

        /// <summary>
        /// The number of clusters that are shifted by compression.
        /// </summary>
        public byte ClusterShift;

        /// <summary>
        /// Reserved.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 3)]
        public byte[] Reserved;
    }
}
