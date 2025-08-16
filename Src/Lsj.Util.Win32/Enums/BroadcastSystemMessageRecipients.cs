using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="BroadcastSystemMessage"/> recipients
    /// </summary>
    public enum BroadcastSystemMessageRecipients : uint
    {
        /// <summary>
        /// BSM_ALLCOMPONENTS
        /// </summary>
        BSM_ALLCOMPONENTS = 0x00000000,

        /// <summary>
        /// BSM_ALLDESKTOPS
        /// </summary>
        BSM_ALLDESKTOPS = 0x00000010,

        /// <summary>
        /// BSM_APPLICATIONS
        /// </summary>
        BSM_APPLICATIONS = 0x00000008,
    }
}
