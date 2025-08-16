using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="DrawFrameControl"/> types
    /// </summary>
    public enum DrawFrameControlTypes : uint
    {
        /// <summary>
        /// DFC_BUTTON
        /// </summary>
        DFC_BUTTON = 4,

        /// <summary>
        /// DFC_CAPTION
        /// </summary>
        DFC_CAPTION = 1,

        /// <summary>
        /// DFC_MENU
        /// </summary>
        DFC_MENU = 2,

        /// <summary>
        /// DFC_POPUPMENU
        /// </summary>
        DFC_POPUPMENU = 5,

        /// <summary>
        /// DFC_SCROLL
        /// </summary>
        DFC_SCROLL = 3,
    }
}
