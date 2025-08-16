namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Header control item filter types
    /// </summary>
    public enum HeaderControlItemFilterTypes : uint
    {
        /// <summary>
        /// HDFT_ISSTRING
        /// </summary>
        HDFT_ISSTRING = 0x0000,

        /// <summary>
        /// HDFT_ISNUMBER
        /// </summary>
        HDFT_ISNUMBER = 0x0001,

        /// <summary>
        /// HDFT_HASNOVALUE
        /// </summary>
        HDFT_HASNOVALUE = 0x8000,

        /// <summary>
        /// HDFT_ISDATE
        /// </summary>
        HDFT_ISDATE = 0x0002,
    }
}
