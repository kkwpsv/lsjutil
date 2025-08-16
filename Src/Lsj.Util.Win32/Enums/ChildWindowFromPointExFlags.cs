using System;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="ChildWindowFromPointEx"/> flags
    /// </summary>
    [Flags]
    public enum ChildWindowFromPointExFlags : uint
    {
        /// <summary>
        /// CWP_ALL
        /// </summary>
        CWP_ALL = 0x0000,

        /// <summary>
        /// CWP_SKIPINVISIBLE
        /// </summary>
        CWP_SKIPINVISIBLE = 0x0001,

        /// <summary>
        /// CWP_SKIPDISABLED
        /// </summary>
        CWP_SKIPDISABLED = 0x0002,

        /// <summary>
        /// CWP_SKIPTRANSPARENT
        /// </summary>
        CWP_SKIPTRANSPARENT = 0x0004,
    }
}
