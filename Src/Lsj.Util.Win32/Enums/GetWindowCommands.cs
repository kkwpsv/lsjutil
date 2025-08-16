using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="GetWindow"/> commands
    /// </summary>
    public enum GetWindowCommands
    {
        /// <summary>
        /// GW_CHILD
        /// </summary>
        GW_CHILD = 5,

        /// <summary>
        /// GW_ENABLEDPOPUP
        /// </summary>
        GW_ENABLEDPOPUP = 6,

        /// <summary>
        /// GW_HWNDFIRST
        /// </summary>
        GW_HWNDFIRST = 0,

        /// <summary>
        /// GW_HWNDLAST
        /// </summary>
        GW_HWNDLAST = 1,

        /// <summary>
        /// GW_HWNDNEXT
        /// </summary>
        GW_HWNDNEXT = 2,

        /// <summary>
        /// GW_HWNDPREV
        /// </summary>
        GW_HWNDPREV = 3,

        /// <summary>
        /// GW_OWNER
        /// </summary>
        GW_OWNER = 4,
    }
}
