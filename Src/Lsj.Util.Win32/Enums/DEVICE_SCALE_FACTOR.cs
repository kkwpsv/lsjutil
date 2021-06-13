namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Indicates a spoofed device scale factor, as a percent.
    /// Used by IApplicationDesignModeSettings::SetApplicationViewState and IApplicationDesignModeSettings::IsApplicationViewStateSupported
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/shtypes/ne-shtypes-device_scale_factor"/>
    /// </para>
    /// </summary>
    public enum DEVICE_SCALE_FACTOR
    {
        /// <summary>
        /// 
        /// </summary>
        DEVICE_SCALE_FACTOR_INVALID = 0,

        /// <summary>
        /// 100%. The scale factor for the device is 1x.
        /// </summary>
        SCALE_100_PERCENT = 100,

        /// <summary>
        /// 120%. The scale factor for the device is 1.2x.
        /// </summary>
        SCALE_120_PERCENT = 120,

        /// <summary>
        /// 
        /// </summary>
        SCALE_125_PERCENT = 125,

        /// <summary>
        /// 140%. The scale factor for the device is 1.4x.
        /// </summary>
        SCALE_140_PERCENT = 140,

        /// <summary>
        /// 	150%. The scale factor for the device is 1.5x.
        /// </summary>
        SCALE_150_PERCENT = 150,

        /// <summary>
        /// 160%. The scale factor for the device is 1.6x.
        /// </summary>
        SCALE_160_PERCENT = 160,

        /// <summary>
        /// 
        /// </summary>
        SCALE_175_PERCENT = 175,

        /// <summary>
        /// 180%. The scale factor for the device is 1.8x.
        /// </summary>
        SCALE_180_PERCENT = 180,

        /// <summary>
        /// 
        /// </summary>
        SCALE_200_PERCENT = 200,

        /// <summary>
        /// 225%. The scale factor for the device is 2.25x.
        /// </summary>
        SCALE_225_PERCENT = 225,

        /// <summary>
        /// 
        /// </summary>
        SCALE_250_PERCENT = 250,

        /// <summary>
        /// 
        /// </summary>
        SCALE_300_PERCENT = 300,

        /// <summary>
        /// 
        /// </summary>
        SCALE_350_PERCENT = 350,

        /// <summary>
        /// 
        /// </summary>
        SCALE_400_PERCENT = 400,

        /// <summary>
        /// 
        /// </summary>
        SCALE_450_PERCENT = 450,

        /// <summary>
        /// 
        /// </summary>
        SCALE_500_PERCENT = 500,
    }
}
