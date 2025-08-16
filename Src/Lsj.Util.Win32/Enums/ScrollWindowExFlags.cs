using System;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="ScrollWindowEx"/> flags.
    /// </summary>
    [Flags]
    public enum ScrollWindowExFlags
    {
        /// <summary>
        /// SW_SCROLLCHILDREN
        /// </summary>
        SW_SCROLLCHILDREN = 0x0001,

        /// <summary>
        /// SW_INVALIDATE
        /// </summary>
        SW_INVALIDATE = 0x0002,

        /// <summary>
        /// SW_ERASE
        /// </summary>
        SW_ERASE = 0x0004,

        /// <summary>
        /// SW_SMOOTHSCROLL
        /// </summary>
        SW_SMOOTHSCROLL = 0x0010,
    }
}
