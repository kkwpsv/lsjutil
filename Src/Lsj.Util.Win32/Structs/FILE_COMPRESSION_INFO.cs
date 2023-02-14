using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals.ByValStructs;
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
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/ns-winbase-file_compression_info"/>
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
        public WORD CompressionFormat;

        /// <summary>
        /// The factor that the compression uses.
        /// </summary>
        public UCHAR CompressionUnitShift;

        /// <summary>
        /// The number of chunks that are shifted by compression.
        /// </summary>
        public UCHAR ChunkShift;

        /// <summary>
        /// The number of clusters that are shifted by compression.
        /// </summary>
        public UCHAR ClusterShift;

        /// <summary>
        /// Reserved.
        /// </summary>
        public ByValUCHARArrayStructForSize3 Reserved;
    }
}
