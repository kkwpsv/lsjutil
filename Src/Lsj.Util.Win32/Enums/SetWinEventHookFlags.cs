using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="SetWinEventHook"/> flags
    /// </summary>
    public enum SetWinEventHookFlags : uint
    {
        /// <summary>
        /// WINEVENT_OUTOFCONTEXT
        /// </summary>
        WINEVENT_OUTOFCONTEXT = 0x0000,

        /// <summary>
        /// WINEVENT_SKIPOWNTHREAD
        /// </summary>
        WINEVENT_SKIPOWNTHREAD = 0x0001,

        /// <summary>
        /// WINEVENT_SKIPOWNPROCESS
        /// </summary>
        WINEVENT_SKIPOWNPROCESS = 0x0002,

        /// <summary>
        /// WINEVENT_INCONTEXT
        /// </summary>
        WINEVENT_INCONTEXT = 0x0004,
    }
}
