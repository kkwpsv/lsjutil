namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// IDN Flags
    /// </summary>
    public enum IDNFlags : uint
    {
        /// <summary>
        /// IDN_ALLOW_UNASSIGNED
        /// </summary>
        IDN_ALLOW_UNASSIGNED = 0x01,

        /// <summary>
        /// IDN_USE_STD3_ASCII_RULES
        /// </summary>
        IDN_USE_STD3_ASCII_RULES = 0x02,

        /// <summary>
        /// IDN_EMAIL_ADDRESS
        /// </summary>
        IDN_EMAIL_ADDRESS = 0x04,

        /// <summary>
        /// IDN_RAW_PUNYCODE
        /// </summary>
        IDN_RAW_PUNYCODE = 0x08,
    }
}
