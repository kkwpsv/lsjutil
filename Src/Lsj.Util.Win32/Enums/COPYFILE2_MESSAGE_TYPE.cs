using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Indicates the type of message passed in the <see cref="COPYFILE2_MESSAGE"/> structure to the CopyFile2ProgressRoutine callback function.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/ne-winbase-copyfile2_message_type"/>
    /// </para>
    /// </summary>
    public enum COPYFILE2_MESSAGE_TYPE
    {
        /// <summary>
        /// Not a valid value.
        /// </summary>
        COPYFILE2_CALLBACK_NONE,

        /// <summary>
        /// Indicates a single chunk of a stream has started to be copied.
        /// </summary>
        COPYFILE2_CALLBACK_CHUNK_STARTED,

        /// <summary>
        /// Indicates the copy of a single chunk of a stream has completed.
        /// </summary>
        COPYFILE2_CALLBACK_CHUNK_FINISHED,

        /// <summary>
        /// Indicates both source and destination handles for a stream have been opened and the copy of the stream is about to be started.
        /// </summary>
        COPYFILE2_CALLBACK_STREAM_STARTED,

        /// <summary>
        /// Indicates the copy operation for a stream have started to be completed.
        /// </summary>
        COPYFILE2_CALLBACK_STREAM_FINISHED,

        /// <summary>
        /// May be sent periodically.
        /// </summary>
        COPYFILE2_CALLBACK_POLL_CONTINUE,

        /// <summary>
        /// An error was encountered during the copy operation.
        /// </summary>
        COPYFILE2_CALLBACK_ERROR,

        /// <summary>
        /// 
        /// </summary>
        COPYFILE2_CALLBACK_MAX
    }
}
