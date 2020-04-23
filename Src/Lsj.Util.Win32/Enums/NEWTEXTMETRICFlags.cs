using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="NEWTEXTMETRIC"/> Flags
    /// </summary>
    public enum NEWTEXTMETRICFlags : uint
    {
        /// <summary>
        /// NTM_REGULAR
        /// </summary>
        NTM_REGULAR = 0x00000040,

        /// <summary>
        /// NTM_BOLD
        /// </summary>
        NTM_BOLD = 0x00000020,

        /// <summary>
        /// NTM_ITALIC
        /// </summary>
        NTM_ITALIC = 0x00000001,

        /// <summary>
        /// NTM_NONNEGATIVE_AC
        /// </summary>
        NTM_NONNEGATIVE_AC = 0x00010000,

        /// <summary>
        /// NTM_PS_OPENTYPE
        /// </summary>
        NTM_PS_OPENTYPE = 0x00020000,

        /// <summary>
        /// NTM_TT_OPENTYPE
        /// </summary>
        NTM_TT_OPENTYPE = 0x00040000,

        /// <summary>
        /// NTM_MULTIPLEMASTER
        /// </summary>
        NTM_MULTIPLEMASTER = 0x00080000,

        /// <summary>
        /// NTM_TYPE1
        /// </summary>
        NTM_TYPE1 = 0x00100000,

        /// <summary>
        /// NTM_DSIG
        /// </summary>
        NTM_DSIG = 0x00200000,
    }
}
