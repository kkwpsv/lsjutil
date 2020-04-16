using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="SystemParametersInfo"/> Flags
    /// </summary>
    public enum SystemParametersInfoFlags : uint
    {
        /// <summary>
        /// SPIF_UPDATEINIFILE
        /// </summary>
        SPIF_UPDATEINIFILE = 0x0001,

        /// <summary>
        /// SPIF_SENDWININICHANGE
        /// </summary>
        SPIF_SENDWININICHANGE = 0x0002,

        /// <summary>
        /// SPIF_SENDCHANGE
        /// </summary>
        SPIF_SENDCHANGE = SPIF_SENDWININICHANGE,
    }
}
