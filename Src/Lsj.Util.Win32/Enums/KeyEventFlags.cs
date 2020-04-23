namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Key Event Flags
    /// </summary>
    public enum KeyEventFlags : uint
    {
        /// <summary>
        /// KEYEVENTF_EXTENDEDKEY
        /// </summary>
        KEYEVENTF_EXTENDEDKEY = 0x0001,

        /// <summary>
        /// KEYEVENTF_KEYUP
        /// </summary>
        KEYEVENTF_KEYUP = 0x0002,

        /// <summary>
        /// KEYEVENTF_UNICODE
        /// </summary>
        KEYEVENTF_UNICODE = 0x0004,

        /// <summary>
        /// KEYEVENTF_SCANCODE
        /// </summary>
        KEYEVENTF_SCANCODE = 0x0008,
    }
}
