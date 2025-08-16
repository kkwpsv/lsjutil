namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Clip precisions
    /// </summary>
    public enum ClipPrecisions : byte
    {
        /// <summary>
        /// CLIP_DEFAULT_PRECIS
        /// </summary>
        CLIP_DEFAULT_PRECIS = 0x00000000,

        /// <summary>
        /// CLIP_CHARACTER_PRECIS
        /// </summary>
        CLIP_CHARACTER_PRECIS = 0x00000001,

        /// <summary>
        /// CLIP_STROKE_PRECIS
        /// </summary>
        CLIP_STROKE_PRECIS = 0x00000002,

        /// <summary>
        /// CLIP_LH_ANGLES
        /// </summary>
        CLIP_LH_ANGLES = 0x00000010,

        /// <summary>
        /// CLIP_TT_ALWAYS
        /// </summary>
        CLIP_TT_ALWAYS = 0x00000020,

        /// <summary>
        /// CLIP_DFA_DISABLE
        /// </summary>
        CLIP_DFA_DISABLE = 0x00000040,

        /// <summary>
        /// CLIP_EMBEDDED
        /// </summary>
        CLIP_EMBEDDED = 0x00000080,

        /// <summary>
        /// CLIP_MASK
        /// </summary>
        CLIP_MASK = 0x0000000f,

        /// <summary>
        /// CLIP_DFA_OVERRIDE
        /// </summary>
        CLIP_DFA_OVERRIDE = CLIP_DFA_DISABLE,
    }
}
