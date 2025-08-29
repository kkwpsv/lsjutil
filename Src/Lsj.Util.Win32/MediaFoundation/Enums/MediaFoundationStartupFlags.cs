namespace Lsj.Util.Win32.MediaFoundation.Enums
{
    /// <summary>
    /// Media Foundation startup flags
    /// </summary>
    public enum MediaFoundationStartupFlags : uint
    {
        /// <summary>
        /// MFSTARTUP_NOSOCKET
        /// </summary>
        MFSTARTUP_NOSOCKET = 0x1,

        /// <summary>
        /// MFSTARTUP_LITE
        /// </summary>
        MFSTARTUP_LITE = MFSTARTUP_NOSOCKET,

        /// <summary>
        /// MFSTARTUP_FULL
        /// </summary>
        MFSTARTUP_FULL = 0,
    }
}
