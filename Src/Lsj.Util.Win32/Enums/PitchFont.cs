namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="PitchFont"/> Enumeration defines values that are used for specifying characteristics of a font.
    /// The values are used to indicate whether the characters in a font have a fixed or variable width, or pitch.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/openspecs/windows_protocols/ms-wmf/22dbe377-aec4-4669-88e6-b8fdd9351d76
    /// </para>
    /// </summary>
    public enum PitchFont
    {
        /// <summary>
        /// The default pitch, which is implementation-dependent.
        /// </summary>
        DEFAULT_PITCH = 0,

        /// <summary>
        /// A fixed pitch, which means that all the characters in the font occupy the same width when output in a string.
        /// </summary>
        FIXED_PITCH = 1,

        /// <summary>
        /// A variable pitch, which means that the characters in the font occupy widths that are proportional
        /// to the actual widths of the glyphs when output in a string.
        /// For example, the "i" and space characters usually have much smaller widths than a "W" or "O" character.
        /// </summary>
        VARIABLE_PITCH = 2
    }
}
