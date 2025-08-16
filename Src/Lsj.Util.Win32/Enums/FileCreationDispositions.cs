namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// File creation dispositions
    /// </summary>
    public enum FileCreationDispositions : uint
    {
        /// <summary>
        /// CREATE_ALWAYS
        /// </summary>
        CREATE_ALWAYS = 2,

        /// <summary>
        /// CREATE_NEW
        /// </summary>
        CREATE_NEW = 1,

        /// <summary>
        /// OPEN_ALWAYS
        /// </summary>
        OPEN_ALWAYS = 4,

        /// <summary>
        /// OPEN_EXISTING
        /// </summary>
        OPEN_EXISTING = 3,

        /// <summary>
        /// TRUNCATE_EXISTING
        /// </summary>
        TRUNCATE_EXISTING = 5,
    }
}
