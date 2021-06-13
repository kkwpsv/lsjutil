namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the supported normalization forms.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/ne-winnls-norm_form"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// For more information about the normalization forms, see Using Unicode Normalization to Represent Strings.
    /// </remarks>
    public enum NORM_FORM
    {
        /// <summary>
        /// Not supported.
        /// </summary>
        NormalizationOther = 0,

        /// <summary>
        /// Unicode normalization form C, canonical composition.
        /// Transforms each decomposed grouping, consisting of a base character plus combining characters,
        /// to the canonical precomposed equivalent. For example, A + ¨ becomes Ä.
        /// </summary>
        NormalizationC = 0x1,

        /// <summary>
        /// Unicode normalization form D, canonical decomposition.
        /// Transforms each precomposed character to its canonical decomposed equivalent. For example, Ä becomes A + ¨.
        /// </summary>
        NormalizationD = 0x2,

        /// <summary>
        /// Unicode normalization form KC, compatibility composition.
        /// Transforms each base plus combining characters to the canonical precomposed equivalent and all compatibility characters to their equivalents.
        /// For example, the ligature ﬁ becomes f + i; similarly, A + ¨ + ﬁ + n becomes Ä + f + i + n.
        /// </summary>
        NormalizationKC = 0x5,

        /// <summary>
        /// Unicode normalization form KD, compatibility decomposition.
        /// Transforms each precomposed character to its canonical decomposed equivalent and all compatibility characters to their equivalents.
        /// For example, Ä + ﬁ + n becomes A + ¨ + f + i + n.
        /// </summary>
        NormalizationKD = 0x6
    }
}
