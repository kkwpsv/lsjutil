namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The operating system provides a set of standard icons that are available for any application to use at any time.
    /// The software development kit (SDK) header files contain
    /// identifiers for the system icons — the identifiers begin with the IDI_ prefix.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/menurc/about-icons"/>
    /// </para>
    /// </summary>
    public enum SystemIcons
    {
        /// <summary>
        /// Default application icon
        /// </summary>
        IDI_APPLICATION = 32512,

        /// <summary>
        /// Error icon
        /// </summary>
        IDI_ERROR = 32513,

        /// <summary>
        /// Question mark icon
        /// </summary>
        IDI_QUESTION = 32514,

        /// <summary>
        /// Warning icon
        /// </summary>
        IDI_WARNING = 32515,

        /// <summary>
        /// Information icon
        /// </summary>
        IDI_INFORMATION = 32516,

        /// <summary>
        /// Windows logo icon
        /// </summary>
        IDI_WINLOGO = 32517,

        /// <summary>
        /// Security shield icon
        /// </summary>
        IDI_SHIELD = 32518,

        /// <summary>
        /// IDI_ASTERISK
        /// </summary>
        IDI_ASTERISK = 32516,

        /// <summary>
        /// IDI_EXCLAMATION
        /// </summary>
        IDI_EXCLAMATION = 32515,

        /// <summary>
        /// IDI_HAND
        /// </summary>
        IDI_HAND = 32513,
    }
}
