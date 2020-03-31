namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Background Modes
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setbkmode
    /// </para>
    /// </summary>
    public enum BackgroundModes
    {
        /// <summary>
        /// Background remains untouched.
        /// </summary>
        TRANSPARENT = 1,

        /// <summary>
        /// Background is filled with the current background color before the text, hatched brush, or pen is drawn.
        /// </summary>
        OPAQUE = 2,
    }
}
