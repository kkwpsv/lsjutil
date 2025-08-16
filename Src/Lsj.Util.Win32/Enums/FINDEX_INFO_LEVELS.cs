using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Defines values that are used with the <see cref="FindFirstFileEx"/> function to specify the information level of the returned data.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/minwinbase/ne-minwinbase-findex_info_levels"/>
    /// </para>
    /// </summary>
    public enum FINDEX_INFO_LEVELS
    {
        /// <summary>
        /// The <see cref="FindFirstFileEx"/> function retrieves a standard set of attribute information.
        /// The data is returned in a <see cref="WIN32_FIND_DATA"/> structure.
        /// </summary>
        FindExInfoStandard,

        /// <summary>
        /// <para>
        /// The <see cref="FindFirstFileEx"/> function does not query the short file name, improving overall enumeration speed.
        /// The data is returned in a <see cref="WIN32_FIND_DATA"/> structure,
        /// and the <see cref="WIN32_FIND_DATA.cAlternateFileName"/> member is always a <see cref="NULL"/> string.
        /// </para>
        /// <para>
        /// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// This value is not supported until Windows Server 2008 R2 and Windows 7.
        /// </para>
        /// </summary>
        FindExInfoBasic,

        /// <summary>
        /// This value is used for validation. Supported values are less than this value.
        /// </summary>
        FindExInfoMaxInfoLevel,
    }
}
