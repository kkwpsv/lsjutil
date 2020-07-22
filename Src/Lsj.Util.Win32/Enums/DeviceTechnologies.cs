namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Device Technologies
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getdevicecaps
    /// </para>
    /// </summary>
    public enum DeviceTechnologies : uint
    {
        /// <summary>
        /// Vector plotter
        /// </summary>
        DT_PLOTTER = 0,

        /// <summary>
        /// Raster display
        /// </summary>
        DT_RASDISPLAY = 1,

        /// <summary>
        /// Raster printer
        /// </summary>
        DT_RASPRINTER = 2,

        /// <summary>
        /// Raster camera
        /// </summary>
        DT_RASCAMERA = 3,

        /// <summary>
        /// Character stream
        /// </summary>
        DT_CHARSTREAM = 4,

        /// <summary>
        /// Metafile
        /// </summary>
        DT_METAFILE = 5,

        /// <summary>
        /// Display file
        /// </summary>
        DT_DISPFILE = 6,
    }
}
