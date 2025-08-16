namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// HANDLE_FLAG
    /// </summary>
    public enum HANDLE_FLAG : uint
    {
        /// <summary>
        /// HANDLE_FLAG_INHERIT
        /// </summary>
        HANDLE_FLAG_INHERIT = 0x00000001,

        /// <summary>
        /// HANDLE_FLAG_PROTECT_FROM_CLOSE
        /// </summary>
        HANDLE_FLAG_PROTECT_FROM_CLOSE = 0x00000002,
    }
}
