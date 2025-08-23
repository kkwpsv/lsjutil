namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Message filterinfo status
    /// </summary>
    public enum MessageFilterInfoStatus : uint
    {
        /// <summary>
        /// MSGFLTINFO_NONE
        /// </summary>
        MSGFLTINFO_NONE = 0,

        /// <summary>
        /// MSGFLTINFO_ALREADYALLOWED_FORWND
        /// </summary>
        MSGFLTINFO_ALREADYALLOWED_FORWND = 1,

        /// <summary>
        /// MSGFLTINFO_ALREADYDISALLOWED_FORWND
        /// </summary>
        MSGFLTINFO_ALREADYDISALLOWED_FORWND = 2,

        /// <summary>
        /// MSGFLTINFO_ALLOWED_HIGHER
        /// </summary>
        MSGFLTINFO_ALLOWED_HIGHER = 3,
    }
}
