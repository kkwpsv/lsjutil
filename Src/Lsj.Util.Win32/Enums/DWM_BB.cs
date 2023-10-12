using Lsj.Util.Win32.Structs;
using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Flags used by the <see cref="DWM_BLURBEHIND"/> structure to indicate which of its members contain valid information.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/dwm/dwm-bb-constants"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum DWM_BB : uint
    {
        /// <summary>
        /// A value for the <see cref="DWM_BLURBEHIND.fEnable"/> member has been specified.
        /// </summary>
        DWM_BB_ENABLE = 0x00000001,

        /// <summary>
        /// A value for the <see cref="DWM_BLURBEHIND.hRgnBlur"/> member has been specified.
        /// </summary>
        DWM_BB_BLURREGION = 0x00000002,

        /// <summary>
        /// A value for the <see cref="DWM_BLURBEHIND.fTransitionOnMaximized"/> member has been specified.
        /// </summary>
        DWM_BB_TRANSITIONONMAXIMIZED = 0x00000004,
    }
}
