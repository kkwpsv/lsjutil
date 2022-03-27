using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.DEVICE_SCALE_FACTOR;
using static Lsj.Util.Win32.Enums.MONITOR_DPI_TYPE;
using static Lsj.Util.Win32.Enums.PROCESS_DPI_AWARENESS;
using static Lsj.Util.Win32.User32;

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
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/shellscalingapi/nf-shellscalingapi-getdpiformonitor"/>
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
        [DllImport("Shcore.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDpiForMonitor", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT GetDpiForMonitor([In] HMONITOR hmonitor, [In] MONITOR_DPI_TYPE dpiType, [Out] out UINT dpiX, [Out] out UINT dpiY);

        /// <summary>
        /// <para>
        /// Retrieves the dots per inch (dpi) awareness of the specified process.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/shellscalingapi/nf-shellscalingapi-getprocessdpiawareness"/>
        /// </para>
        /// </summary>
        /// <param name="hprocess">
        /// Handle of the process that is being queried.
        /// If this parameter is <see cref="NULL"/>, the current process is queried.
        /// </param>
        /// <param name="value">
        /// The DPI awareness of the specified process.
        /// Possible values are from the <see cref="PROCESS_DPI_AWARENESS"/> enumeration.
        /// </param>
        /// <returns>
        /// This function returns one of the following values.
        /// <see cref="S_OK"/>: The function successfully retrieved the DPI awareness of the specified process. 
        /// <see cref="E_INVALIDARG"/>: The handle or pointer passed in is not valid. 
        /// <see cref="E_ACCESSDENIED"/>: The application does not have sufficient privileges. 
        /// </returns>
        /// <remarks>
        /// This function is identical to the following code:
        /// <code>GetAwarenessFromDpiAwarenessContext(GetThreadDpiAwarenessContext());</code>
        /// </remarks>
        [DllImport("Shcore.dll", CharSet = CharSet.Unicode, EntryPoint = "GetProcessDpiAwareness", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT GetProcessDpiAwareness([In] HANDLE hprocess, [Out] out PROCESS_DPI_AWARENESS value);

        /// <summary>
        /// <para>
        /// Gets the preferred scale factor for a display device.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/shellscalingapi/nf-shellscalingapi-getscalefactorfordevice"/>
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
        public static extern DEVICE_SCALE_FACTOR GetScaleFactorForDevice([In] DISPLAY_DEVICE_TYPE deviceType);

        /// <summary>
        /// <para>
        /// It is recommended that you set the process-default DPI awareness via application manifest.
        /// See Setting the default DPI awareness for a process for more information.
        /// Setting the process-default DPI awareness via API call can lead to unexpected application behavior.
        /// Sets the process-default DPI awareness level.
        /// This is equivalent to calling <see cref="SetProcessDpiAwarenessContext"/> with the corresponding <see cref="DPI_AWARENESS_CONTEXT"/> value.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/shellscalingapi/nf-shellscalingapi-setprocessdpiawareness"/>
        /// </para>
        /// </summary>
        /// <param name="value">
        /// The DPI awareness value to set.
        /// Possible values are from the <see cref="PROCESS_DPI_AWARENESS"/> enumeration.
        /// </param>
        /// <returns>
        /// This function returns one of the following values.
        /// <see cref="S_OK"/>: The DPI awareness for the app was set successfully.
        /// <see cref="E_INVALIDARG"/>: The value passed in is not valid.
        /// <see cref="E_ACCESSDENIED"/>: The DPI awareness is already set, either by calling this API previously or through the application(.exe) manifest.
        /// </returns>
        /// <remarks>
        /// It is recommended that you set the process-default DPI awareness via application manifest.
        /// See Setting the default DPI awareness for a process for more information.
        /// Setting the process-default DPI awareness via API call can lead to unexpected application behavior.
        /// Previous versions of Windows only had one DPI awareness value for the entire application.
        /// For those applications, the recommendation was to set the DPI awareness value in the manifest as described in <see cref="PROCESS_DPI_AWARENESS"/>.
        /// Under that recommendation, you were not supposed to use <see cref="SetProcessDpiAwareness"/> to update the DPI awareness.
        /// In fact, future calls to this API would fail after the DPI awareness was set once.
        /// Now that DPI awareness is tied to a thread rather than an application, you can use this method to update the DPI awareness.
        /// However, consider using <see cref="SetThreadDpiAwarenessContext"/> instead.
        /// Important
        /// For older applications, it is strongly recommended to not use <see cref="SetProcessDpiAwareness"/> to set the DPI awareness for your application.
        /// Instead, you should declare the DPI awareness for your application in the application manifest.
        /// See <see cref="PROCESS_DPI_AWARENESS"/> for more information about the DPI awareness values and how to set them in the manifest.
        /// You must call this API before you call any APIs that depend on the dpi awareness.
        /// This is part of the reason why it is recommended to use the application manifest rather than the <see cref="SetProcessDpiAwareness"/> API.
        /// Once API awareness is set for an app, any future calls to this API will fail.
        /// This is true regardless of whether you set the DPI awareness in the manifest or by using this API.
        /// If the DPI awareness level is not set, the default value is <see cref="PROCESS_DPI_UNAWARE"/>.
        /// </remarks>
        [DllImport("Shcore.dll", CharSet = CharSet.Unicode, EntryPoint = "SetProcessDpiAwareness", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT SetProcessDpiAwareness([In] PROCESS_DPI_AWARENESS value);
    }
}
