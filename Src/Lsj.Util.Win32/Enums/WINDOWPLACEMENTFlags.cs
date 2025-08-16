using Lsj.Util.Win32.Structs;
using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="WINDOWPLACEMENT"/> flags
    /// </summary>
    [Flags]
    public enum WindowPlacementFlags : uint
    {
        /// <summary>
        /// WPF_ASYNCWINDOWPLACEMENT
        /// </summary>
        WPF_ASYNCWINDOWPLACEMENT = 4,

        /// <summary>
        /// WPF_RESTORETOMAXIMIZED
        /// </summary>
        WPF_RESTORETOMAXIMIZED = 2,

        /// <summary>
        /// WPF_SETMINPOSITION
        /// </summary>
        WPF_SETMINPOSITION = 1,
    }
}
