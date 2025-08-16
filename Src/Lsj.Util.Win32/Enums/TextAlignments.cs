using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Text alignments
    /// </summary>
    [Flags]
    public enum TextAlignments : uint
    {
        /// <summary>
        /// TA_NOUPDATECP
        /// </summary>
        TA_NOUPDATECP = 0,

        /// <summary>
        /// TA_UPDATECP
        /// </summary>
        TA_UPDATECP = 1,

        /// <summary>
        /// TA_LEFT
        /// </summary>
        TA_LEFT = 0,

        /// <summary>
        /// TA_RIGHT
        /// </summary>
        TA_RIGHT = 2,

        /// <summary>
        /// TA_CENTER
        /// </summary>
        TA_CENTER = 6,

        /// <summary>
        /// TA_TOP
        /// </summary>
        TA_TOP = 0,

        /// <summary>
        /// TA_BOTTOM
        /// </summary>
        TA_BOTTOM = 8,

        /// <summary>
        /// TA_BASELINE
        /// </summary>
        TA_BASELINE = 24,

        /// <summary>
        /// TA_RTLREADING
        /// </summary>
        TA_RTLREADING = 256,

        /// <summary>
        /// VTA_BASELINE
        /// </summary>
        VTA_BASELINE = TA_BASELINE,

        /// <summary>
        /// VTA_CENTER
        /// </summary>
        VTA_CENTER = TA_CENTER,
    }
}
