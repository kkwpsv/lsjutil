namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// HT Pattern Sizes
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winddi/ns-winddi-gdiinfo"/>
    /// </para>
    /// </summary>
    public enum HTPatternSizes : uint
    {
        /// <summary>
        /// 
        /// </summary>
        HT_PATSIZE_2x2 = 0,

        /// <summary>
        /// 
        /// </summary>
        HT_PATSIZE_2x2_M = 1,

        /// <summary>
        /// 
        /// </summary>
        HT_PATSIZE_4x4 = 2,

        /// <summary>
        /// 
        /// </summary>
        HT_PATSIZE_4x4_M = 3,

        /// <summary>
        /// 
        /// </summary>
        HT_PATSIZE_6x6 = 4,

        /// <summary>
        /// 
        /// </summary>
        HT_PATSIZE_6x6_M = 5,

        /// <summary>
        /// 
        /// </summary>
        HT_PATSIZE_8x8 = 6,

        /// <summary>
        /// 
        /// </summary>
        HT_PATSIZE_8x8_M = 7,

        /// <summary>
        /// 
        /// </summary>
        HT_PATSIZE_10x10 = 8,

        /// <summary>
        /// 
        /// </summary>
        HT_PATSIZE_10x10_M = 9,

        /// <summary>
        /// 
        /// </summary>
        HT_PATSIZE_12x12 = 10,

        /// <summary>
        /// 
        /// </summary>
        HT_PATSIZE_12x12_M = 11,

        /// <summary>
        /// 
        /// </summary>
        HT_PATSIZE_14x14 = 12,

        /// <summary>
        /// 
        /// </summary>
        HT_PATSIZE_14x14_M = 13,

        /// <summary>
        /// 
        /// </summary>
        HT_PATSIZE_16x16 = 14,

        /// <summary>
        /// 
        /// </summary>
        HT_PATSIZE_16x16_M = 15,

        /// <summary>
        /// 
        /// </summary>
        HT_PATSIZE_SUPERCELL = 16,

        /// <summary>
        /// 
        /// </summary>
        HT_PATSIZE_SUPERCELL_M = 17,

        /// <summary>
        /// 
        /// </summary>
        HT_PATSIZE_USER = 18,

        /// <summary>
        /// 
        /// </summary>
        HT_PATSIZE_MAX_INDEX = HT_PATSIZE_USER,

        /// <summary>
        /// 
        /// </summary>
        HT_PATSIZE_DEFAULT = HT_PATSIZE_SUPERCELL_M,
    }
}
