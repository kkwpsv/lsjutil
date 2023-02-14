using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="AnimateWindow"/> Flags
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-animatewindow"/>
    /// </para>
    /// </summary>
    public enum AnimateWindowFlags
    {
        /// <summary>
        /// Activates the window. Do not use this value with <see cref="AW_HIDE"/>.
        /// </summary>
        AW_ACTIVATE = 0x00020000,

        /// <summary>
        /// Uses a fade effect. This flag can be used only if hwnd is a top-level window.
        /// </summary>
        AW_BLEND = 0x00080000,

        /// <summary>
        /// Makes the window appear to collapse inward if <see cref="AW_HIDE"/> is used or expand outward if the <see cref="AW_HIDE"/> is not used.
        /// The various direction flags have no effect.
        /// </summary>
        AW_CENTER = 0x00000010,

        /// <summary>
        /// Hides the window. By default, the window is shown.
        /// </summary>
        AW_HIDE = 0x00010000,

        /// <summary>
        /// Animates the window from left to right.
        /// This flag can be used with roll or slide animation.
        /// It is ignored when used with <see cref="AW_CENTER"/> or <see cref="AW_BLEND"/>.
        /// </summary>
        AW_HOR_POSITIVE = 0x00000001,

        /// <summary>
        /// Animates the window from right to left.
        /// This flag can be used with roll or slide animation.
        /// It is ignored when used with <see cref="AW_CENTER"/> or <see cref="AW_BLEND"/>.
        /// </summary>
        AW_HOR_NEGATIVE = 0x00000002,

        /// <summary>
        /// Uses slide animation.
        /// By default, roll animation is used. This flag is ignored when used with <see cref="AW_CENTER"/>.
        /// </summary>
        AW_SLIDE = 0x00040000,

        /// <summary>
        /// Animates the window from top to bottom.
        /// This flag can be used with roll or slide animation.
        /// It is ignored when used with <see cref="AW_CENTER"/> or <see cref="AW_BLEND"/>.
        /// </summary>
        AW_VER_POSITIVE = 0x00000004,

        /// <summary>
        /// Animates the window from bottom to top.
        /// This flag can be used with roll or slide animation.
        /// It is ignored when used with <see cref="AW_CENTER"/> or <see cref="AW_BLEND"/>.
        /// </summary>
        AW_VER_NEGATIVE = 0x00000008,
    }
}
