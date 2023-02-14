﻿namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Identifies the dots per inch (dpi) setting for a monitor.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shellscalingapi/ne-shellscalingapi-monitor_dpi_type"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// All of these settings are affected by the <see cref="PROCESS_DPI_AWARENESS"/> of your application
    /// </remarks>
    public enum MONITOR_DPI_TYPE
    {
        /// <summary>
        /// The effective DPI.
        /// This value should be used when determining the correct scale factor for scaling UI elements.
        /// This incorporates the scale factor set by the user for this specific display.
        /// </summary>
        MDT_EFFECTIVE_DPI = 0,

        /// <summary>
        /// The angular DPI.
        /// This DPI ensures rendering at a compliant angular resolution on the screen.
        /// This does not include the scale factor set by the user for this specific display.
        /// </summary>
        MDT_ANGULAR_DPI = 1,

        /// <summary>
        /// The raw DPI.
        /// This value is the linear DPI of the screen as measured on the screen itself.
        /// Use this value when you want to read the pixel density and not the recommended scaling setting.
        /// This does not include the scale factor set by the user for this specific display and is not guaranteed to be a supported DPI value.
        /// </summary>
        MDT_RAW_DPI = 2,

        /// <summary>
        /// The default DPI setting for a monitor is MDT_EFFECTIVE_DPI.
        /// </summary>
        MDT_DEFAULT = MDT_EFFECTIVE_DPI
    }
}
