using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Defines values that are used with the <see cref="GetFileAttributesEx"/> and <see cref="GetFileAttributesTransacted"/> functions
    /// to specify the information level of the returned data.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/minwinbase/ne-minwinbase-get_fileex_info_levels
    /// </para>
    /// </summary>
    public enum GET_FILEEX_INFO_LEVELS
    {
        /// <summary>
        /// The <see cref="GetFileAttributesEx"/> or <see cref="GetFileAttributesTransacted"/> function retrieves a standard set of attribute information.
        /// The data is returned in a <see cref="WIN32_FILE_ATTRIBUTE_DATA"/> structure.
        /// </summary>
        GetFileExInfoStandard,

        /// <summary>
        /// One greater than the maximum value. Valid values for this enumeration will be less than this value.
        /// </summary>
        GetFileExMaxInfoLevel
    }
}
