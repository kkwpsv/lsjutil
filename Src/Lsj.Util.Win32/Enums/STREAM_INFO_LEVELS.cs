using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Defines values that are used with the <see cref="FindFirstStreamW"/> function to specify the information level of the returned data.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/ne-fileapi-stream_info_levels"/>
    /// </para>
    /// </summary>
    public enum STREAM_INFO_LEVELS
    {
        /// <summary>
        /// The <see cref="FindFirstStreamW"/> function retrieves standard stream information.
        /// The data is returned in a <see cref="WIN32_FIND_STREAM_DATA"/> structure.
        /// </summary>
        FindStreamInfoStandard,

        /// <summary>
        /// Used to determine valid enumeration values.
        /// All supported enumeration values are less than <see cref="FindStreamInfoMaxInfoLevel"/>.
        /// </summary>
        FindStreamInfoMaxInfoLevel,
    }
}
