namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// LogonTypes
    /// </summary>
    public enum LogonTypes : uint
    {
        /// <summary>
        /// LOGON32_LOGON_INTERACTIVE
        /// </summary>
        LOGON32_LOGON_INTERACTIVE = 2,

        /// <summary>
        /// LOGON32_LOGON_NETWORK
        /// </summary>
        LOGON32_LOGON_NETWORK = 3,

        /// <summary>
        /// LOGON32_LOGON_BATCH
        /// </summary>
        LOGON32_LOGON_BATCH = 4,

        /// <summary>
        /// LOGON32_LOGON_SERVICE
        /// </summary>
        LOGON32_LOGON_SERVICE = 5,

        /// <summary>
        /// LOGON32_LOGON_UNLOCK
        /// </summary>
        LOGON32_LOGON_UNLOCK = 7,

        /// <summary>
        /// LOGON32_LOGON_NETWORK_CLEARTEXT
        /// </summary>
        LOGON32_LOGON_NETWORK_CLEARTEXT = 8,

        /// <summary>
        /// LOGON32_LOGON_NEW_CREDENTIALS
        /// </summary>
        LOGON32_LOGON_NEW_CREDENTIALS = 9,
    }
}
