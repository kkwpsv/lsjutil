using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// STRRET_TYPE
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shtypes/ns-shtypes-strret
    /// </para>
    /// </summary>
    public enum STRRET_TYPE : uint
    {
        /// <summary>
        /// The string is returned in the <see cref="STRRET.cStr"/> member.
        /// </summary>
        STRRET_WSTR = 0,

        /// <summary>
        /// The <see cref="STRRET.uOffset"/> member value indicates the number of bytes
        /// from the beginning of the item identifier list where the string is located.
        /// </summary>
        STRRET_OFFSET = 0x1,

        /// <summary>
        /// The string is at the address specified by <see cref="STRRET.pOleStr"/> member.
        /// </summary>
        STRRET_CSTR = 0x2
    }
}
