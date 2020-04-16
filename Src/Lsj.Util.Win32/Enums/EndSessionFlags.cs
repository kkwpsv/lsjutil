namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// EndSessionFlags
    /// </summary>
    public enum EndSessionFlags : uint
    {
        /// <summary>
        /// The application is using a file that must be replaced, the system is being serviced, or system resources are exhausted.
        /// For more information, see Guidelines for Applications.
        /// </summary>
        ENDSESSION_CLOSEAPP = 0x00000001,

        /// <summary>
        /// The application is forced to shut down.
        /// </summary>
        ENDSESSION_CRITICAL = 0x40000000,

        /// <summary>
        /// The user is logging off. For more information, see Logging Off.
        /// </summary>
        ENDSESSION_LOGOFF = 0x80000000,
    }
}
