namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="FontQualities"/> Enumeration specifies how closely the attributes of the logical font
    /// match those of the physical font when rendering text.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/openspecs/windows_protocols/ms-wmf/9518fece-d2f2-4799-9df6-ba3db1d73371
    /// </para>
    /// </summary>
    public enum FontQualities
    {
        /// <summary>
        /// Specifies that the character quality of the font does not matter, so <see cref="DRAFT_QUALITY"/> can be used.
        /// </summary>
        DEFAULT_QUALITY = 0x00,

        /// <summary>
        /// Specifies that the character quality of the font is less important than the matching of logical attribuetes.
        /// For rasterized fonts, scaling SHOULD be enabled, which means that more font sizes are available.
        /// </summary>
        DRAFT_QUALITY = 0x01,

        /// <summary>
        /// Specifies that the character quality of the font is more important than the matching of logical attributes.
        /// For rasterized fonts, scaling SHOULD be disabled, and the font closest in size SHOULD be chosen.
        /// </summary>
        PROOF_QUALITY = 0x02,

        /// <summary>
        /// Specifies that anti-aliasing SHOULD NOT be used when rendering text.
        /// </summary>
        NONANTIALIASED_QUALITY = 0x03,

        /// <summary>
        /// Specifies that anti-aliasing SHOULD be used when rendering text, if the font supports it.
        /// </summary>
        ANTIALIASED_QUALITY = 0x04,

        /// <summary>
        /// Specifies that ClearType anti-aliasing SHOULD be used when rendering text, if the font supports it.
        /// </summary>
        CLEARTYPE_QUALITY = 0x05
    }
}
