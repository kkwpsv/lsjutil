namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Message Filter Flags
    /// </summary>
    public enum MessageFilterFlags : uint
    {
        /// <summary>
        /// MSGFLT_ADD
        /// </summary>
        MSGFLT_ADD = 1,

        /// <summary>
        /// MSGFLT_REMOVE
        /// </summary>
        MSGFLT_REMOVE = 2,

        /// <summary>
        /// MSGFLT_RESET
        /// </summary>
        MSGFLT_RESET = 0,

        /// <summary>
        /// MSGFLT_ALLOW
        /// </summary>
        MSGFLT_ALLOW = 1,

        /// <summary>
        /// MSGFLT_DISALLOW
        /// </summary>
        MSGFLT_DISALLOW = 2,
    }
}
