using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.COPYFILE2_MESSAGE_TYPE;
using static Lsj.Util.Win32.Enums.COPYFILE2_MESSAGE_ACTION;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Passed to the CopyFile2ProgressRoutine callback function with information about a pending copy operation.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/ns-winbase-copyfile2_message"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct COPYFILE2_MESSAGE
    {
        /// <summary>
        /// Value from the <see cref="COPYFILE2_MESSAGE_TYPE"/> enumeration used as a discriminant for the <see cref="Info"/> union within this structure.
        /// <see cref="COPYFILE2_CALLBACK_CHUNK_STARTED"/>:
        /// Indicates a single chunk of a stream has started to be copied.
        /// Information is in the <see cref="COPYFILE2_MESSAGE_Info.ChunkStarted"/> structure within the <see cref="Info"/> union.
        /// <see cref="COPYFILE2_CALLBACK_CHUNK_FINISHED"/>:
        /// Indicates the copy of a single chunk of a stream has completed.
        /// Information is in the <see cref="COPYFILE2_MESSAGE_Info.ChunkFinished"/> structure within the <see cref="Info"/> union.
        /// <see cref="COPYFILE2_CALLBACK_STREAM_STARTED"/>:
        /// Indicates both source and destination handles for a stream have been opened and the copy of the stream is about to be started.
        /// Information is in the <see cref="COPYFILE2_MESSAGE_Info.StreamStarted"/> structure within the <see cref="Info"/> union.
        /// This does not indicate that the copy has started for that stream.
        /// <see cref="COPYFILE2_CALLBACK_STREAM_FINISHED"/>:
        /// Indicates the copy operation for a stream have started to be completed,
        /// either successfully or due to a <see cref="COPYFILE2_PROGRESS_STOP"/> return from CopyFile2ProgressRoutine.
        /// Information is in the <see cref="COPYFILE2_MESSAGE_Info.StreamFinished"/> structure within the <see cref="Info"/> union.
        /// <see cref="COPYFILE2_CALLBACK_POLL_CONTINUE"/>:
        /// May be sent periodically.
        /// Information is in the <see cref="COPYFILE2_MESSAGE_Info.PollContinue"/> structure within the <see cref="Info"/> union.
        /// <see cref="COPYFILE2_CALLBACK_ERROR"/>:
        /// An error was encountered during the copy operation.
        /// Information is in the <see cref="COPYFILE2_MESSAGE_Info.Error"/> structure within the <see cref="Info"/> union.
        /// </summary>
        public COPYFILE2_MESSAGE_TYPE Type;

        /// <summary>
        /// 
        /// </summary>
        public DWORD dwPadding;

        /// <summary>
        /// 
        /// </summary>
        public COPYFILE2_MESSAGE_Info Info;

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
        public struct COPYFILE2_MESSAGE_Info
        {
            /// <summary>
            /// This structure is selected if the <see cref="Type"/> member is set to <see cref="COPYFILE2_CALLBACK_CHUNK_STARTED"/> (1).
            /// </summary>
            [FieldOffset(0)]
            public COPYFILE2_MESSAGE_ChunkStarted ChunkStarted;

            /// <summary>
            /// This structure is selected if the <see cref="Type"/> member is set to <see cref="COPYFILE2_CALLBACK_CHUNK_FINISHED"/> (2).
            /// </summary>
            [FieldOffset(0)]
            public COPYFILE2_MESSAGE_ChunkFinished ChunkFinished;

            /// <summary>
            /// This structure is selected if the <see cref="Type"/> member is set to <see cref="COPYFILE2_CALLBACK_STREAM_STARTED"/> (3).
            /// </summary>
            [FieldOffset(0)]
            public COPYFILE2_MESSAGE_StreamStarted StreamStarted;

            /// <summary>
            /// This structure is selected if the <see cref="Type"/> member is set to <see cref="COPYFILE2_CALLBACK_STREAM_FINISHED"/> (4).
            /// </summary>
            [FieldOffset(0)]
            public COPYFILE2_MESSAGE_StreamFinished StreamFinished;

            /// <summary>
            /// This structure is selected if the <see cref="Type"/> member is set to <see cref="COPYFILE2_CALLBACK_POLL_CONTNUE"/> (5).
            /// </summary>
            [FieldOffset(0)]
            public COPYFILE2_MESSAGE_PollContinue PollContinue;

            /// <summary>
            /// This structure is selected if the <see cref="Type"/> member is set to <see cref="COPYFILE2_CALLBACK_ERROR"/> (6).
            /// </summary>
            [FieldOffset(0)]
            public COPYFILE2_MESSAGE_Error Error;
        }

        /// <summary>
        /// 
        /// </summary>

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct COPYFILE2_MESSAGE_ChunkStarted
        {
            /// <summary>
            /// Indicates which stream within the file is about to be copied.
            /// The value used for identifying a stream within a file will start at one (1) and will always be higher than any previous stream for that file.
            /// </summary>
            public DWORD dwStreamNumber;

            /// <summary>
            /// This member is reserved for internal use.
            /// </summary>
            public DWORD dwReserved;

            /// <summary>
            /// Handle to the source stream.
            /// </summary>
            public HANDLE hSourceFile;

            /// <summary>
            /// Handle to the destination stream.
            /// </summary>
            public HANDLE hDestinationFile;

            /// <summary>
            /// Indicates which chunk within the current stream is about to be copied.
            /// The value used for a chunk will start at zero (0) and will always be higher than that of any previous chunk for the current stream.
            /// </summary>
            public ULARGE_INTEGER uliChunkNumber;

            /// <summary>
            /// Size of the copied chunk, in bytes.
            /// </summary>
            public ULARGE_INTEGER uliChunkSize;

            /// <summary>
            /// Size of the current stream, in bytes.
            /// </summary>
            public ULARGE_INTEGER uliStreamSize;

            /// <summary>
            /// Size of all streams for this file, in bytes.
            /// </summary>
            public ULARGE_INTEGER uliTotalFileSize;
        }

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct COPYFILE2_MESSAGE_ChunkFinished
        {
            /// <summary>
            /// Indicates which stream within the file is about to be copied.
            /// The value used for identifying a stream within a file will start at one (1) and will always be higher than any previous stream for that file.
            /// </summary>
            public DWORD dwStreamNumber;

            /// <summary>
            /// 
            /// </summary>
            public DWORD dwFlags;

            /// <summary>
            /// This member is reserved for internal use.
            /// </summary>
            public DWORD dwReserved;

            /// <summary>
            /// Handle to the source stream.
            /// </summary>
            public HANDLE hSourceFile;

            /// <summary>
            /// Handle to the destination stream.
            /// </summary>
            public HANDLE hDestinationFile;

            /// <summary>
            /// Indicates which chunk within the current stream is in process.
            /// The value used for a chunk will start at zero (0) and will always be higher than that of any previous chunk for the current stream.
            /// </summary>
            public ULARGE_INTEGER uliChunkNumber;

            /// <summary>
            /// Size of the copied chunk, in bytes.
            /// </summary>
            public ULARGE_INTEGER uliChunkSize;

            /// <summary>
            /// Size of the current stream, in bytes.
            /// </summary>
            public ULARGE_INTEGER uliStreamSize;

            /// <summary>
            /// Total bytes copied for this stream so far.
            /// </summary>
            public ULARGE_INTEGER uliStreamBytesTransferred;

            /// <summary>
            /// Size of all streams for this file, in bytes.
            /// </summary>
            public ULARGE_INTEGER uliTotalFileSize;

            /// <summary>
            /// Total bytes copied for this file so far.
            /// </summary>
            public ULARGE_INTEGER uliTotalBytesTransferred;
        }

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct COPYFILE2_MESSAGE_StreamStarted
        {
            /// <summary>
            /// Indicates which stream within the file is about to be copied.
            /// The value used for identifying a stream within a file will start at one (1) and will always be higher than any previous stream for that file.
            /// </summary>
            public DWORD dwStreamNumber;

            /// <summary>
            /// This member is reserved for internal use.
            /// </summary>
            public DWORD dwReserved;

            /// <summary>
            /// Handle to the source stream.
            /// </summary>
            public HANDLE hSourceFile;

            /// <summary>
            /// Handle to the destination stream.
            /// </summary>
            public HANDLE hDestinationFile;

            /// <summary>
            /// Size of the current stream, in bytes.
            /// </summary>
            public ULARGE_INTEGER uliStreamSize;

            /// <summary>
            /// Size of all streams for this file, in bytes.
            /// </summary>
            public ULARGE_INTEGER uliTotalFileSize;
        }

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct COPYFILE2_MESSAGE_StreamFinished
        {
            /// <summary>
            /// Indicates which stream within the file is about to be copied.
            /// The value used for identifying a stream within a file will start at one (1) and will always be higher than any previous stream for that file.
            /// </summary>
            public DWORD dwStreamNumber;

            /// <summary>
            /// This member is reserved for internal use.
            /// </summary>
            public DWORD dwReserved;

            /// <summary>
            /// Handle to the source stream.
            /// </summary>
            public HANDLE hSourceFile;

            /// <summary>
            /// Handle to the destination stream.
            /// </summary>
            public HANDLE hDestinationFile;

            /// <summary>
            /// Size of the current stream, in bytes.
            /// </summary>
            public ULARGE_INTEGER uliStreamSize;

            /// <summary>
            /// Total bytes copied for this stream so far.
            /// </summary>
            public ULARGE_INTEGER uliStreamBytesTransferred;

            /// <summary>
            /// Size of all streams for this file, in bytes.
            /// </summary>
            public ULARGE_INTEGER uliTotalFileSize;

            /// <summary>
            /// Total bytes copied for this file so far.
            /// </summary>
            public ULARGE_INTEGER uliTotalBytesTransferred;
        }

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct COPYFILE2_MESSAGE_PollContinue
        {
            /// <summary>
            /// This member is reserved for internal use.
            /// </summary>
            public DWORD dwReserved;
        }

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct COPYFILE2_MESSAGE_Error
        {
            /// <summary>
            /// Value from the <see cref="COPYFILE2_COPY_PHASE"/> enumeration indicating the current phase of the copy at the time of the error.
            /// </summary>
            public COPYFILE2_COPY_PHASE CopyPhase;

            /// <summary>
            /// The number of the stream that was being processed at the time of the error.
            /// </summary>
            public DWORD dwStreamNumber;

            /// <summary>
            /// Value indicating the problem.
            /// </summary>
            public HRESULT hrFailure;

            /// <summary>
            /// This member is reserved for internal use.
            /// </summary>
            public DWORD dwReserved;

            /// <summary>
            /// Indicates which chunk within the current stream was being processed at the time of the error.
            /// The value used for a chunk will start at zero (0) and will always be higher than that of any previous chunk for the current stream.
            /// </summary>
            public ULARGE_INTEGER uliChunkNumber;

            /// <summary>
            /// Size, in bytes, of the stream being processed.
            /// </summary>
            public ULARGE_INTEGER uliStreamSize;

            /// <summary>
            /// Number of bytes that had been successfully transferred for the stream being processed.
            /// </summary>
            public ULARGE_INTEGER uliStreamBytesTransferred;

            /// <summary>
            /// Size, in bytes, of the total file being processed.
            /// </summary>
            public ULARGE_INTEGER uliTotalFileSize;

            /// <summary>
            /// Number of bytes that had been successfully transferred for the entire copy operation.
            /// </summary>
            public ULARGE_INTEGER uliTotalBytesTransferred;
        }
    }
}
