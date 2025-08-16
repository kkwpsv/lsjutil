using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="MapVirtualKey"/> types
    /// </summary>
    public enum MapVirtualKeyTypes : uint
    {
        /// <summary>
        /// MAPVK_VK_TO_CHAR
        /// </summary>
        MAPVK_VK_TO_CHAR = 2,

        /// <summary>
        /// MAPVK_VK_TO_VSC
        /// </summary>
        MAPVK_VK_TO_VSC = 0,

        /// <summary>
        /// MAPVK_VSC_TO_VK
        /// </summary>
        MAPVK_VSC_TO_VK = 1,

        /// <summary>
        /// MAPVK_VSC_TO_VK_EX
        /// </summary>
        MAPVK_VSC_TO_VK_EX = 3,
    }
}
