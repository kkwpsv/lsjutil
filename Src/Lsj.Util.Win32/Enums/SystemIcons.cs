namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// System Icons
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-loadiconw
    /// </para>
    /// </summary>
    public enum SystemIcons
    {
        /// <summary>
        /// Default application icon.
        /// </summary>
        IDI_APPLICATION = 32512,

        /// <summary>
        /// Asterisk icon. Same as <see cref="IDI_INFORMATION"/>.
        /// </summary>
        IDI_ASTERISK = 32516,

        /// <summary>
        /// Hand-shaped icon.
        /// </summary>
        IDI_ERROR = 32513,

        /// <summary>
        /// Exclamation point icon. Same as <see cref="IDI_WARNING"/>.
        /// </summary>
        IDI_EXCLAMATION = 32515,

        /// <summary>
        /// Hand-shaped icon. Same as <see cref="IDI_ERROR"/>.
        /// </summary>
        IDI_HAND = 32513,

        /// <summary>
        /// Asterisk icon.
        /// </summary>
        IDI_INFORMATION = 32516,

        /// <summary>
        /// Question mark icon.
        /// </summary>
        IDI_QUESTION = 32514,

        /// <summary>
        /// Security Shield icon.
        /// </summary>
        IDI_SHIELD = 32518,

        /// <summary>
        /// Exclamation point icon.
        /// </summary>
        IDI_WARNING = 32515,

        /// <summary>
        /// Default application icon.
        /// Windows 2000:  Windows logo icon.
        /// </summary>
        IDI_WINLOGO = 32517,
    }
}
