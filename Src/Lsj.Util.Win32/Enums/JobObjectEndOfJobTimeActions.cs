namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Job object end-of-job time actions
    /// </summary>
    public enum JobObjectEndOfJobTimeActions : uint
    {
        /// <summary>
        /// JOB_OBJECT_TERMINATE_AT_END_OF_JOB
        /// </summary>
        JOB_OBJECT_TERMINATE_AT_END_OF_JOB = 0,

        /// <summary>
        /// JOB_OBJECT_POST_AT_END_OF_JOB
        /// </summary>
        JOB_OBJECT_POST_AT_END_OF_JOB = 1,
    }
}
