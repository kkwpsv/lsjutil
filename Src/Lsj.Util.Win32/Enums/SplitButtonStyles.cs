using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    ///  Split Button Styles
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/ns-commctrl-button_splitinfo
    /// </para>
    /// </summary>
    [Flags]
    public enum SplitButtonStyles : uint
    {
        /// <summary>
        /// Align the image or glyph horizontally with the left margin.
        /// </summary>
        BCSS_ALIGNLEFT = 0x0004,

        /// <summary>
        /// Draw an icon image as the glyph.
        /// </summary>
        BCSS_IMAGE = 0x0008,

        /// <summary>
        /// No split.
        /// </summary>
        BCSS_NOSPLIT = 0x0001,

        /// <summary>
        /// Stretch glyph, but try to retain aspect ratio.
        /// </summary>
        BCSS_STRETCH = 0x0002,
    }
}
