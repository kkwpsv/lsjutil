namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// ILLUMINANT
    /// </summary>
    public enum ILLUMINANT
    {
        /// <summary>
        /// ILLUMINANT_DEVICE_DEFAULT
        /// </summary>
        ILLUMINANT_DEVICE_DEFAULT = 0,

        /// <summary>
        /// ILLUMINANT_A
        /// </summary>
        ILLUMINANT_A = 1,

        /// <summary>
        /// ILLUMINANT_B
        /// </summary>
        ILLUMINANT_B = 2,

        /// <summary>
        /// ILLUMINANT_C
        /// </summary>
        ILLUMINANT_C = 3,

        /// <summary>
        /// ILLUMINANT_D50
        /// </summary>
        ILLUMINANT_D50 = 4,

        /// <summary>
        /// ILLUMINANT_D55
        /// </summary>
        ILLUMINANT_D55 = 5,

        /// <summary>
        /// ILLUMINANT_D65
        /// </summary>
        ILLUMINANT_D65 = 6,

        /// <summary>
        /// ILLUMINANT_D75
        /// </summary>
        ILLUMINANT_D75 = 7,

        /// <summary>
        /// ILLUMINANT_F2
        /// </summary>
        ILLUMINANT_F2 = 8,

        /// <summary>
        /// ILLUMINANT_TUNGSTEN
        /// </summary>
        ILLUMINANT_TUNGSTEN = ILLUMINANT_A,

        /// <summary>
        /// ILLUMINANT_DAYLIGHT
        /// </summary>
        ILLUMINANT_DAYLIGHT = ILLUMINANT_C,

        /// <summary>
        /// ILLUMINANT_FLUORESCENT
        /// </summary>
        ILLUMINANT_FLUORESCENT = ILLUMINANT_F2,

        /// <summary>
        /// ILLUMINANT_NTSC
        /// </summary>
        ILLUMINANT_NTSC = ILLUMINANT_C,
    }
}
