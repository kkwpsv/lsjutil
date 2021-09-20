using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="HDITEM"/> Filter Type
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/ns-commctrl-hditemw"/>
    /// </para>
    /// </summary>
    public enum HDITEMFilterType : uint
    {
        /// <summary>
        /// String data.
        /// </summary>
        HDFT_ISSTRING = 0x0000,

        /// <summary>
        /// Numerical data.
        /// </summary>
        HDFT_ISNUMBER = 0x0001,

        /// <summary>
        /// Ignore <see cref="HDITEM.pvFilter"/>.
        /// </summary>
        HDFT_HASNOVALUE = 0x8000,

        /// <summary>
        /// Version 6.00 and later.
        /// Date data.
        /// The <see cref="HDITEM.pvFilter"/> member is a pointer to a <see cref="SYSTEMTIME"/> structure.
        /// </summary>
        HDFT_ISDATE = 0x0002,
    }
}
