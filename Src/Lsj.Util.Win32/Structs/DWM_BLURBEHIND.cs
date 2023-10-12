using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Dwmapi;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Specifies Desktop Window Manager (DWM) blur-behind properties.
    /// Used by the <see cref="DwmEnableBlurBehindWindow"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/ns-dwmapi-dwm_blurbehind"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DWM_BLURBEHIND
    {
        /// <summary>
        /// A bitwise combination of DWM Blur Behind constant values that indicates which of the members of this structure have been set.
        /// </summary>
        public DWM_BB dwFlags;

        /// <summary>
        /// <see cref="TRUE"/> to register the window handle to DWM blur behind;
        /// <see cref="FALSE"/> to unregister the window handle from DWM blur behind.
        /// </summary>
        public BOOL fEnable;

        /// <summary>
        /// The region within the client area where the blur behind will be applied.
        /// A <see cref="NULL"/> value will apply the blur behind the entire client area.
        /// </summary>
        public HRGN hRgnBlur;

        /// <summary>
        /// <see cref="TRUE"/> if the window's colorization should transition to match the maximized windows; otherwise, <see cref="FALSE"/>.
        /// </summary>
        public BOOL fTransitionOnMaximized;
    }
}
