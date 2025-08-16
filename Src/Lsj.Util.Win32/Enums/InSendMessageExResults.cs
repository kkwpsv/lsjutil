using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="InSendMessageEx"/> results
    /// </summary>
    public enum InSendMessageExResults : uint
    {
        /// <summary>
        /// ISMEX_NOSEND
        /// </summary>
        ISMEX_NOSEND = 0x00000000,

        /// <summary>
        /// ISMEX_CALLBACK
        /// </summary>
        ISMEX_CALLBACK = 0x00000004,

        /// <summary>
        /// ISMEX_NOTIFY
        /// </summary>
        ISMEX_NOTIFY = 0x00000002,

        /// <summary>
        /// ISMEX_REPLIED
        /// </summary>
        ISMEX_REPLIED = 0x00000008,

        /// <summary>
        /// ISMEX_SEND
        /// </summary>
        ISMEX_SEND = 0x00000001,
    }
}
