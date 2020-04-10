namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Login Providers
    /// </summary>
    public enum LoginProviders : uint
    {
        /// <summary>
        /// LOGON32_PROVIDER_DEFAULT
        /// </summary>
        LOGON32_PROVIDER_DEFAULT = 0,

        /// <summary>
        /// LOGON32_PROVIDER_WINNT35
        /// </summary>
        LOGON32_PROVIDER_WINNT35 = 1,

        /// <summary>
        /// LOGON32_PROVIDER_WINNT40
        /// </summary>
        LOGON32_PROVIDER_WINNT40 = 2,

        /// <summary>
        /// LOGON32_PROVIDER_WINNT50
        /// </summary>
        LOGON32_PROVIDER_WINNT50 = 3,

        /// <summary>
        /// LOGON32_PROVIDER_VIRTUAL
        /// </summary>
        LOGON32_PROVIDER_VIRTUAL = 4,
    }
}
