using Lsj.Util.Win32.Attributes;
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
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shellscalingapi/nf-shellscalingapi-getdpiformonitor"/>
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
        /// <para>
        /// This function returns one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// The function successfully returns the X and Y DPI values for the specified monitor.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_INVALIDARG"/>
        /// </term>
        /// <term>
        /// The handle, DPI type, or pointers passed in are not valid.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This API is not DPI aware and should not be used if the calling thread is per-monitor DPI aware.
        /// For the DPI-aware version of this API, see <see cref="GetDpiForWindow"/>.
        /// </para>
        /// <para>
        /// When you call <see cref="GetDpiForMonitor"/>, you will receive different DPI values depending on the DPI awareness of the calling application.
        /// DPI awareness is an application-level property usually defined in the application manifest.
        /// For more information about DPI awareness values, see <see cref="PROCESS_DPI_AWARENESS"/>.
        /// The following table indicates how the results will differ based on the <see cref="PROCESS_DPI_AWARENESS"/> value of your application.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// <see cref="PROCESS_DPI_UNAWARE"/>
        /// </term>
        /// <term>
        /// 96 because the app is unaware of any other scale factors.
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="PROCESS_SYSTEM_DPI_AWARE"/>
        /// </term>
        /// <term>
        /// A value set to the system DPI because the app assumes all applications use the system DPI.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PROCESS_PER_MONITOR_DPI_AWARE"/>
        /// </term>
        /// <term>
        /// The actual DPI value set by the user for that display.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The values of *dpiX and *dpiY are identical. You only need to record one of the values to determine the DPI and respond appropriately.
        /// </para>
        /// <para>
        /// When <see cref="MONITOR_DPI_TYPE"/> is <see cref="MDT_ANGULAR_DPI"/> or <see cref="MDT_RAW_DPI"/>,
        /// the returned DPI value does not include any changes that the user made to the DPI
        /// by using the desktop scaling override slider control in Control Panel.
        /// </para>
        /// <para>
        /// For more information about DPI settings in Control Panel, see the Writing DPI-Aware Desktop Applications in Windows 8.1 Preview white paper.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8_1)]
        [DllImport("Shcore.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDpiForMonitor", ExactSpelling = true)]
        public static extern HRESULT GetDpiForMonitor([In] HMONITOR hmonitor, [In] MONITOR_DPI_TYPE dpiType, [Out] out UINT dpiX, [Out] out UINT dpiY);

        /// <summary>
        /// <para>
        /// Retrieves the dots per inch (dpi) awareness of the specified process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shellscalingapi/nf-shellscalingapi-getprocessdpiawareness"/>
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
        /// <para>
        /// This function returns one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// The function successfully retrieved the DPI awareness of the specified process.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_INVALIDARG"/>
        /// </term>
        /// <term>
        /// The handle or pointer passed in is not valid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_ACCESSDENIED"/>
        /// </term>
        /// <term>
        /// The application does not have sufficient privileges.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function is identical to the following code:
        /// </para>
        /// <code>
        /// GetAwarenessFromDpiAwarenessContext(GetThreadDpiAwarenessContext());
        /// </code>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8_1)]
        [DllImport("Shcore.dll", CharSet = CharSet.Unicode, EntryPoint = "GetProcessDpiAwareness", ExactSpelling = true)]
        public static extern HRESULT GetProcessDpiAwareness([In] HANDLE hprocess, [Out] out PROCESS_DPI_AWARENESS value);

        /// <summary>
        /// <para>
        /// Gets the preferred scale factor for a display device.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This function is not supported as of Windows 8.1.
        /// Use <see cref="GetScaleFactorForMonitor"/> instead.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shellscalingapi/nf-shellscalingapi-getscalefactorfordevice"/>
        /// </para>
        /// </summary>
        /// <param name="deviceType">
        /// The value that indicates the type of the display device.
        /// </param>
        /// <returns>
        /// <para>
        /// A value that indicates the scale factor that should be used with the specified <see cref="DISPLAY_DEVICE_TYPE"/>.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code/value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SCALE_100_PERCENT"/>
        /// </para>
        /// <para>
        /// 100
        /// </para>
        /// </term>
        /// <term>
        /// Use a scale factor of 1x.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SCALE_140_PERCENT"/>
        /// </para>
        /// <para>
        /// 140
        /// </para>
        /// </term>
        /// <term>
        /// Use a scale factor of 1.4x.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SCALE_180_PERCENT"/>
        /// </para>
        /// <para>
        /// 180
        /// </para>
        /// </term>
        /// <term>
        /// Use a scale factor of 1.8x.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The default <see cref="DEVICE_SCALE_FACTOR"/> is <see cref="SCALE_100_PERCENT"/>.
        /// </para>
        /// <para>
        /// Use the scale factor that is returned to scale point values for fonts and pixel values.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("Shcore.dll", CharSet = CharSet.Unicode, EntryPoint = "GetScaleFactorForDevice", ExactSpelling = true)]
        public static extern DEVICE_SCALE_FACTOR GetScaleFactorForDevice([In] DISPLAY_DEVICE_TYPE deviceType);

        /// <summary>
        /// <para>
        /// Sets the process-default DPI awareness level.
        /// This is equivalent to calling <see cref="SetProcessDpiAwarenessContext"/> with the corresponding <see cref="DPI_AWARENESS_CONTEXT"/> value.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// It is recommended that you set the process-default DPI awareness via application manifest.
        /// See Setting the default DPI awareness for a process for more information.
        /// Setting the process-default DPI awareness via API call can lead to unexpected application behavior.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shellscalingapi/nf-shellscalingapi-setprocessdpiawareness"/>
        /// </para>
        /// </summary>
        /// <param name="value">
        /// The DPI awareness value to set.
        /// Possible values are from the <see cref="PROCESS_DPI_AWARENESS"/> enumeration.
        /// </param>
        /// <returns>
        /// <para>
        /// This function returns one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// The DPI awareness for the app was set successfully.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_INVALIDARG"/>
        /// </term>
        /// <term>
        /// The value passed in is not valid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_ACCESSDENIED"/>
        /// </term>
        /// <term>
        /// The DPI awareness is already set, either by calling this API previously or through the application (.exe) manifest.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Previous versions of Windows only had one DPI awareness value for the entire application.
        /// For those applications, the recommendation was to set the DPI awareness value in the manifest as described in <see cref="PROCESS_DPI_AWARENESS"/>.
        /// Under that recommendation, you were not supposed to use <see cref="SetProcessDpiAwareness"/> to update the DPI awareness.
        /// In fact, future calls to this API would fail after the DPI awareness was set once.
        /// Now that DPI awareness is tied to a thread rather than an application, you can use this method to update the DPI awareness.
        /// However, consider using <see cref="SetThreadDpiAwarenessContext"/> instead.
        /// </para>
        /// <para>
        /// Important  
        /// </para>
        /// <para>
        /// For older applications, it is strongly recommended to not use <see cref="SetProcessDpiAwareness"/> to set the DPI awareness for your application.
        /// Instead, you should declare the DPI awareness for your application in the application manifest.
        /// See <see cref="PROCESS_DPI_AWARENESS"/> for more information about the DPI awareness values and how to set them in the manifest.
        /// </para>
        /// <para>
        /// You must call this API before you call any APIs that depend on the dpi awareness.
        /// This is part of the reason why it is recommended to use the application manifest rather than the <see cref="SetProcessDpiAwareness"/> API.
        /// Once API awareness is set for an app, any future calls to this API will fail.
        /// This is true regardless of whether you set the DPI awareness in the manifest or by using this API.
        /// </para>
        /// <para>
        /// If the DPI awareness level is not set, the default value is <see cref="PROCESS_DPI_UNAWARE"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8_1)]
        [DllImport("Shcore.dll", CharSet = CharSet.Unicode, EntryPoint = "SetProcessDpiAwareness", ExactSpelling = true)]
        public static extern HRESULT SetProcessDpiAwareness([In] PROCESS_DPI_AWARENESS value);
    }
}
