using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="TEXTMETRIC"/> PitchAndFamily Flags
    /// </summary>
    public enum TEXTMETRICPitchAndFamilyFlags : byte
    {
        /// <summary>
        /// TMPF_FIXED_PITCH
        /// </summary>
        TMPF_FIXED_PITCH = 0x01,

        /// <summary>
        /// TMPF_VECTOR
        /// </summary>
        TMPF_VECTOR = 0x02,

        /// <summary>
        /// TMPF_DEVICE
        /// </summary>
        TMPF_DEVICE = 0x08,

        /// <summary>
        /// TMPF_TRUETYPE
        /// </summary>
        TMPF_TRUETYPE = 0x04,
    }
}
