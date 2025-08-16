using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="CompareString"/> Results
    /// </summary>
    public enum CompareStringResults
    {
        /// <summary>
        /// CSTR_LESS_THAN
        /// </summary>
        CSTR_LESS_THAN = 1,

        /// <summary>
        /// CSTR_EQUAL
        /// </summary>
        CSTR_EQUAL = 2,

        /// <summary>
        /// CSTR_GREATER_THAN
        /// </summary>
        CSTR_GREATER_THAN = 3,
    }
}
