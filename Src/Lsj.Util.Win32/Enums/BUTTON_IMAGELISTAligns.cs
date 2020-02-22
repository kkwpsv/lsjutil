using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="BUTTON_IMAGELIST"/> Aligns.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/ns-commctrl-button_imagelist
    /// </para>
    /// </summary>
    public enum BUTTON_IMAGELISTAligns : uint
    {
        /// <summary>
        /// Align the image with the left margin.
        /// </summary>
        BUTTON_IMAGELIST_ALIGN_LEFT = 0,

        /// <summary>
        /// Align the image with the right margin.
        /// </summary>
        BUTTON_IMAGELIST_ALIGN_RIGHT = 1,

        /// <summary>
        /// Align the image with the top margin
        /// </summary>
        BUTTON_IMAGELIST_ALIGN_TOP = 2,

        /// <summary>
        /// Align the image with the bottom margin
        /// </summary>
        BUTTON_IMAGELIST_ALIGN_BOTTOM = 3,

        /// <summary>
        /// Center the image.
        /// </summary>
        BUTTON_IMAGELIST_ALIGN_CENTER = 4,
    }
}
