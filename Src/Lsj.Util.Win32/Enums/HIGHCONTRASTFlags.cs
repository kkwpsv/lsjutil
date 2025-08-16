namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// High contrast flags
    /// </summary>
    public enum HighContrastFlags : uint
    {
        /// <summary>
        /// HCF_HIGHCONTRASTON
        /// </summary>
        HCF_HIGHCONTRASTON = 0x00000001,

        /// <summary>
        /// HCF_AVAILABLE
        /// </summary>
        HCF_AVAILABLE = 0x00000002,

        /// <summary>
        /// HCF_HOTKEYACTIVE
        /// </summary>
        HCF_HOTKEYACTIVE = 0x00000004,

        /// <summary>
        /// HCF_CONFIRMHOTKEY
        /// </summary>
        HCF_CONFIRMHOTKEY = 0x00000008,

        /// <summary>
        /// HCF_HOTKEYSOUND
        /// </summary>
        HCF_HOTKEYSOUND = 0x00000010,

        /// <summary>
        /// HCF_INDICATOR
        /// </summary>
        HCF_INDICATOR = 0x00000020,

        /// <summary>
        /// HCF_HOTKEYAVAILABLE
        /// </summary>
        HCF_HOTKEYAVAILABLE = 0x00000040,
    }
}
