using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Enums.SystemMetric;
using static Lsj.Util.Win32.Shell32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="SHGetStockIconInfo"/> Flags.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shellapi/nf-shellapi-shgetstockiconinfo
    /// </para>
    /// </summary>
    public enum SHGetStockIconInfoFlags : uint
    {
        /// <summary>
        /// The <see cref="SHSTOCKICONINFO.szPath"/> and <see cref="SHSTOCKICONINFO.iIcon"/> members of the <see cref="SHSTOCKICONINFO"/> structure
        /// receive the path and icon index of the requested icon, in a format suitable for passing to the <see cref="ExtractIcon"/> function.
        /// The numerical value of this flag is zero, so you always get the icon location regardless of other flags.
        /// </summary>
        SHGSI_ICONLOCATION = 0,

        /// <summary>
        /// The <see cref="SHSTOCKICONINFO.hIcon"/> member of the <see cref="SHSTOCKICONINFO"/> structure receives a handle to the specified icon.
        /// </summary>
        SHGSI_ICON = 0x000000100,

        /// <summary>
        /// The <see cref="SHSTOCKICONINFO.iSysImageIndex"/> member of the <see cref="SHSTOCKICONINFO"/> structure
        /// receives the index of the specified icon in the system imagelist.
        /// </summary>
        SHGSI_SYSICONINDEX = 0x000004000,

        /// <summary>
        /// Modifies the <see cref="SHGSI_ICON"/> value by causing the function to add the link overlay to the file's icon.
        /// </summary>
        SHGSI_LINKOVERLAY = 0x000008000,

        /// <summary>
        /// Modifies the <see cref="SHGSI_ICON"/> value by causing the function to blend the icon with the system highlight color.
        /// </summary>
        SHGSI_SELECTED = 0x000010000,

        /// <summary>
        /// Modifies the <see cref="SHGSI_ICON"/> value by causing the function to retrieve the large version of the icon,
        /// as specified by the <see cref="SM_CXICON"/> and <see cref="SM_CYICON"/> system metrics.
        /// </summary>
        SHGSI_LARGEICON = 0,

        /// <summary>
        /// Modifies the <see cref="SHGSI_ICON"/> value by causing the function to retrieve the small version of the icon,
        /// as specified by the <see cref="SM_CXSMICON"/> and <see cref="SM_CYSMICON"/> system metrics.
        /// </summary>
        SHGSI_SMALLICON = 0x000000001,

        /// <summary>
        /// Modifies the <see cref="SHGSI_LARGEICON"/> or <see cref="SHGSI_SMALLICON"/> values by causing the function
        /// to retrieve the Shell-sized icons rather than the sizes specified by the system metrics.
        /// </summary>
        SHGSI_SHELLICONSIZE = 0x000000004,
    }
}
