using System;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="MsgWaitForMultipleObjectsEx"/> types
    /// </summary>
    [Flags]
    public enum MsgWaitForMultipleObjectsExTypes : uint
    {
        /// <summary>
        /// MWMO_ALERTABLE
        /// </summary>
        MWMO_ALERTABLE = 0x0002,

        /// <summary>
        /// MWMO_INPUTAVAILABLE
        /// </summary>
        MWMO_INPUTAVAILABLE = 0x0004,

        /// <summary>
        /// MWMO_WAITALL
        /// </summary>
        MWMO_WAITALL = 0x0001,
    }
}
