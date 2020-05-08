using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Enums.DEVICE_SCALE_FACTOR;
using static Lsj.Util.Win32.Enums.MONITOR_DPI_TYPE;
using static Lsj.Util.Win32.Enums.PROCESS_DPI_AWARENESS;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Shcore.dll
    /// </summary>
    public static class Shcore
    {
        /// <summary>
        /// <para>
        /// Queries the dots per inch (dpi) of a display.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shellscalingapi/nf-shellscalingapi-getdpiformonitor
        /// </para>
        /// </summary>
        /// <param name="hmonitor">
        /// Handle of the monitor being queried.
        /// </param>
        /// <param name="dpiType">
        /// The type of DPI being queried.
        /// Possible values are from the <see cref="MONITOR_DPI_TYPE"/> enumeration.
        /// </param>
        /// <param name="dpiX">
        /// The value of the DPI along the X axis.
        /// This value always refers to the horizontal edge, even when the screen is rotated.
        /// </param>
        /// <param name="dpiY">
        /// The value of the DPI along the Y axis.
        /// This value always refers to the vertical edge, even when the screen is rotated.
        /// </param>
        /// <returns>
        /// This function returns one of the following values.
        /// <see cref="S_OK"/>: The function successfully returns the X and Y DPI values for the specified monitor.
        /// <see cref="E_INVALIDARG"/>: The handle, DPI type, or pointers passed in are not valid. 
        /// </returns>
        /// <remarks>
        /// This API is not DPI aware and should not be used if the calling thread is per-monitor DPI aware.
        /// For the DPI-aware version of this API, see <see cref="GetDpiForWindow"/>.
        /// When you call <see cref="GetDpiForMonitor"/>, you will receive different DPI values depending on the DPI awareness of the calling application.
        /// DPI awareness is an application-level property usually defined in the application manifest.
        /// For more information about DPI awareness values, see <see cref="PROCESS_DPI_AWARENESS"/>.
        /// The following table indicates how the results will differ based on the <see cref="PROCESS_DPI_AWARENESS"/> value of your application.
        /// <see cref="PROCESS_DPI_UNAWARE"/>: 6 because the app is unaware of any other scale factors.
        /// <see cref="PROCESS_SYSTEM_DPI_AWARE"/>: A value set to the system DPI because the app assumes all applications use the system DPI.
        /// <see cref="PROCESS_PER_MONITOR_DPI_AWARE"/>: The actual DPI value set by the user for that display.
        /// The values of *<paramref name="dpiX"/> and *<paramref name="dpiY"/> are identical.
        /// You only need to record one of the values to determine the DPI and respond appropriately.
        /// When <see cref="MONITOR_DPI_TYPE"/> is <see cref="MDT_ANGULAR_DPI"/> or <see cref="MDT_RAW_DPI"/>,
        /// the returned DPI value does not include any changes that the user made to the DPI
        /// by using the desktop scaling override slider control in Control Panel.
        /// For more information about DPI settings in Control Panel, see the Writing DPI-Aware Desktop Applications in Windows 8.1 Preview white paper.
        /// </remarks>
        [DllImport("Shcore.dll", CharSet = CharSet.Unicode, EntryPoint = "GetScaleFactorForDevice", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT GetDpiForMonitor([In]HMONITOR hmonitor, [In]MONITOR_DPI_TYPE dpiType, [Out]out UINT dpiX, [Out]out UINT dpiY);

        /// <summary>
        /// <para>
        /// Gets the preferred scale factor for a display device.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shellscalingapi/nf-shellscalingapi-getscalefactorfordevice
        /// </para>
        /// </summary>
        /// <param name="deviceType">
        /// The value that indicates the type of the display device.
        /// </param>
        /// <returns>
        /// A value that indicates the scale factor that should be used with the specified <see cref="DISPLAY_DEVICE_TYPE"/>.
        /// </returns>
        /// <remarks>
        /// The default <see cref="DEVICE_SCALE_FACTOR"/> is <see cref="SCALE_100_PERCENT"/>.
        /// Use the scale factor that is returned to scale point values for fonts and pixel values.
        /// </remarks>
        [DllImport("Shcore.dll", CharSet = CharSet.Unicode, EntryPoint = "GetScaleFactorForDevice", ExactSpelling = true, SetLastError = true)]
        public static extern DEVICE_SCALE_FACTOR GetScaleFactorForDevice([In]DISPLAY_DEVICE_TYPE deviceType);
    }
}
