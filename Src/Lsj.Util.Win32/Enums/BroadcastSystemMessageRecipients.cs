using static Lsj.Util.Win32.Enums.PrivilegeConstants;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="BroadcastSystemMessage"/> Recipients
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-broadcastsystemmessagew"/>
    /// </para>
    /// </summary>
    public enum BroadcastSystemMessageRecipients : uint
    {
        /// <summary>
        /// Broadcast to all system components.
        /// </summary>
        BSM_ALLCOMPONENTS = 0x00000000,

        /// <summary>
        /// Broadcast to all desktops.
        /// Requires the <see cref="SE_TCB_NAME"/> privilege.
        /// </summary>
        BSM_ALLDESKTOPS = 0x00000010,

        /// <summary>
        /// Broadcast to applications.
        /// </summary>
        BSM_APPLICATIONS = 0x00000008,
    }
}
