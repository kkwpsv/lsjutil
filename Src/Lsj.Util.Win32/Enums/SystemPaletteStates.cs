namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// System Palette States
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getsystempaletteuse
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setsystempaletteuse
    /// </para>
    /// </summary>
    public enum SystemPaletteStates : uint
    {
        /// <summary>
        /// SYSPAL_ERROR
        /// </summary>
        SYSPAL_ERROR = 0,

        /// <summary>
        /// SYSPAL_STATIC
        /// </summary>
        SYSPAL_STATIC = 1,

        /// <summary>
        /// SYSPAL_NOSTATIC
        /// </summary>
        SYSPAL_NOSTATIC = 2,

        /// <summary>
        /// SYSPAL_NOSTATIC256
        /// </summary>
        SYSPAL_NOSTATIC256 = 3,
    }
}
