using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="CreateProcessWithLogonW"/> Flags.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-createprocesswithlogonw
    /// </para>
    /// </summary>
    public enum CreateProcessWithLogonWFlags : uint
    {
        /// <summary>
        /// Log on, then load the user profile in the HKEY_USERS registry key.
        /// The function returns after the profile is loaded.
        /// Loading the profile can be time-consuming, so it is best to use this value
        /// only if you must access the information in the HKEY_CURRENT_USER registry key.
        /// Windows Server 2003:  The profile is unloaded after the new process is terminated, whether or not it has created child processes.
        /// Windows XP:  The profile is unloaded after the new process and all child processes it has created are terminated.
        /// </summary>
        LOGON_WITH_PROFILE = 0x00000001,

        /// <summary>
        /// Log on, but use the specified credentials on the network only.
        /// The new process uses the same token as the caller, but the system creates a new logon session within LSA,
        /// and the process uses the specified credentials as the default credentials.
        /// This value can be used to create a process that uses a different set of credentials locally than it does remotely.
        /// This is useful in inter-domain scenarios where there is no trust relationship.
        /// The system does not validate the specified credentials.
        /// Therefore, the process can start, but it may not have access to network resources.
        /// </summary>
        LOGON_NETCREDENTIALS_ONLY = 0x00000002,
    }
}
