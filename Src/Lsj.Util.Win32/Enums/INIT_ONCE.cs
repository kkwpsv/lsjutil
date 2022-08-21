namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// InitOnceFlags
    /// </summary>
    public enum InitOnceFlags : uint
    {
        /// <summary>
        /// INIT_ONCE_CHECK_ONLY
        /// </summary>
        INIT_ONCE_CHECK_ONLY = 1,

        /// <summary>
        /// INIT_ONCE_ASYNC
        /// </summary>
        INIT_ONCE_ASYNC = 2,

        /// <summary>
        /// INIT_ONCE_INIT_FAILED
        /// </summary>
        INIT_ONCE_INIT_FAILED = 4,
    }
}
