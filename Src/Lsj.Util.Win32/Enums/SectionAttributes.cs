namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Section Attributes
    /// </para>
    /// </summary>
    public enum SectionAttributes : uint
    {
        /// <summary>
        /// SEC_COMMIT
        /// </summary>
        SEC_COMMIT = 0x8000000,

        /// <summary>
        /// SEC_IMAGE
        /// </summary>
        SEC_IMAGE = 0x1000000,

        /// <summary>
        /// SEC_IMAGE_NO_EXECUTE
        /// </summary>
        SEC_IMAGE_NO_EXECUTE = 0x11000000,

        /// <summary>
        /// SEC_LARGE_PAGES
        /// </summary>
        SEC_LARGE_PAGES = 0x80000000,

        /// <summary>
        /// SEC_NOCACHE
        /// </summary>
        SEC_NOCACHE = 0x10000000,

        /// <summary>
        /// SEC_RESERVE
        /// </summary>
        SEC_RESERVE = 0x4000000,

        /// <summary>
        /// SEC_WRITECOMBINE
        /// </summary>
        SEC_WRITECOMBINE = 0x40000000,
    }
}
