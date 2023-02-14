namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Specifies how far a moniker should be reduced.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/objidl/ne-objidl-mkrreduce"/>
    /// </para>
    /// </summary>
    public enum MKRREDUCE : uint
    {
        /// <summary>
        /// Performs only one step of reducing the moniker.
        /// In general, the caller must have specific knowledge about the particular kind of moniker to take advantage of this option.
        /// </summary>
        MKRREDUCE_ONE = (3 << 16),

        /// <summary>
        ///  Reduces the moniker to a form that the user identifies as a persistent object.
        ///  If no such point exists, then this option should be treated as <see cref="MKRREDUCE_ALL"/>.
        /// </summary>
        MKRREDUCE_TOUSER = (2 << 16),

        /// <summary>
        /// Reduces the moniker to where any further reduction would reduce it to a form that the user does not identify as a persistent object.
        /// Often, this is the same stage as <see cref="MKRREDUCE_TOUSER"/>.
        /// </summary>
        MKRREDUCE_THROUGHUSER = (1 << 16),

        /// <summary>
        /// Reduces the moniker until it is in its simplest form, that is, reduce it to itself.
        /// </summary>
        MKRREDUCE_ALL = 0
    }
}
