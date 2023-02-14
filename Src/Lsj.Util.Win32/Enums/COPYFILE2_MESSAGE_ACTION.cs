using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Enums.CopyFileFlags;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Returned by the CopyFile2ProgressRoutine callback function to indicate what action should be taken for the pending copy operation.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/ne-winbase-copyfile2_message_action"/>
    /// </para>
    /// </summary>
    public enum COPYFILE2_MESSAGE_ACTION
    {
        /// <summary>
        /// Continue the copy operation.
        /// </summary>
        COPYFILE2_PROGRESS_CONTINUE,

        /// <summary>
        /// Cancel the copy operation.
        /// The <see cref="CopyFile2"/> function will fail, return <code>HRESULT_FROM_WIN32(ERROR_REQUEST_ABORTED)</code>
        /// and any partially copied fragments will be deleted.
        /// </summary>
        COPYFILE2_PROGRESS_CANCEL,

        /// <summary>
        /// Stop the copy operation.
        /// The <see cref="CopyFile2"/> function will fail, return <code>HRESULT_FROM_WIN32(ERROR_REQUEST_ABORTED)</code>
        /// and any partially copied fragments will be left intact.
        /// The operation can be restarted using the <see cref="COPY_FILE_RESUME_FROM_PAUSE"/> flag only if <see cref="COPY_FILE_RESTARTABLE"/> was set
        /// in the <see cref="COPYFILE2_EXTENDED_PARAMETERS.dwCopyFlags"/> member of the <see cref="COPYFILE2_EXTENDED_PARAMETERS"/> structure
        /// passed to the <see cref="CopyFile2"/> function.
        /// </summary>
        COPYFILE2_PROGRESS_STOP,

        /// <summary>
        /// Continue the copy operation but do not call the CopyFile2ProgressRoutine callback function again for this operation.
        /// </summary>
        COPYFILE2_PROGRESS_QUIET,

        /// <summary>
        /// Pause the copy operation.
        /// In most cases the <see cref="CopyFile2"/> function will fail and return <code>HRESULT_FROM_WIN32(ERROR_REQUEST_PAUSED)</code>
        /// and any partially copied fragments will be left intact (except for the header written that is used to resume the copy operation later.)
        /// In case the copy operation was complete at the time the pause request is processed
        /// the <see cref="CopyFile2"/> call will complete successfully and no resume header will be written.
        /// </summary>
        COPYFILE2_PROGRESS_PAUSE,
    }
}
