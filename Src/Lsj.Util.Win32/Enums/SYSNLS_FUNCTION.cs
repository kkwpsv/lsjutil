using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Specifies NLS function capabilities.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/ne-winnls-sysnls_function"/>
    /// </para>
    /// </summary>
    public enum SYSNLS_FUNCTION : uint
    {
        /// <summary>
        /// Value indicating comparison of two strings in the manner of the <see cref="CompareString"/> function
        /// or <see cref="LCMapString"/> with the <see cref="LCMAP_SORTKEY"/> flag specified.
        /// </summary>
        COMPARE_STRING = 1,
    }
}
