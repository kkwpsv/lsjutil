namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// CopyProgressRoutine results
    /// </summary>
    public enum CopyProgressRoutineResults : uint
    {
        /// <summary>
        /// PROGRESS_CONTINUE
        /// </summary>
        PROGRESS_CONTINUE = 0,

        /// <summary>
        /// PROGRESS_CANCEL
        /// </summary>
        PROGRESS_CANCEL = 1,

        /// <summary>
        /// PROGRESS_STOP
        /// </summary>
        PROGRESS_STOP = 2,

        /// <summary>
        /// PROGRESS_QUIET
        /// </summary>
        PROGRESS_QUIET = 3,
    }
}
