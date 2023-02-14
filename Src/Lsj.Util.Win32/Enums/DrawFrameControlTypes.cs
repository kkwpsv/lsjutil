using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="DrawFrameControl"/> Types
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-drawframecontrol"/>
    /// </para>
    /// </summary>
    public enum DrawFrameControlTypes : uint
    {
        /// <summary>
        /// Standard button
        /// </summary>
        DFC_BUTTON = 4,

        /// <summary>
        /// Title bar
        /// </summary>
        DFC_CAPTION = 1,

        /// <summary>
        /// Menu bar
        /// </summary>
        DFC_MENU = 2,

        /// <summary>
        /// Popup menu item.
        /// </summary>
        DFC_POPUPMENU = 5,

        /// <summary>
        /// Scroll bar
        /// </summary>
        DFC_SCROLL = 3,
    }
}
