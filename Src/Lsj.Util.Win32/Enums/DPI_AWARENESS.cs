using static Lsj.Util.Win32.Enums.WindowsMessages;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Identifies the dots per inch (dpi) setting for a thread, process, or window.
    /// </para>
    /// </summary>
    /// <remarks>
    /// In previous versions of Windows, DPI values were only set once for an entire application.
    /// For those apps, the <see cref="PROCESS_DPI_AWARENESS"/> type determined the type of DPI awareness for the entire application.
    /// Currently, the DPI awareness is defined on an individual thread, window, or process level and is indicated by the <see cref="DPI_AWARENESS"/> type.
    /// While the focus shifted from a process level to a thread level,
    /// the different kinds of DPI awareness are the same: unaware, system aware, and per monitor aware.
    /// For detailed descriptions and some examples of the different DPI kinds, see <see cref="PROCESS_DPI_AWARENESS"/>.
    /// The old recommendation was to define the DPI awareness level in the application manifest
    /// using the setting dpiAware as explained in <see cref="PROCESS_DPI_AWARENESS"/>.
    /// Now that the DPI awareness is tied to threads and windows instead of an entire application, a new windows setting is added to the app manifest.
    /// This setting is dpiAwareness and will override any dpiAware setting if both of them are present in the manifest.
    /// While it is still recommended to use the manifest, you can now change the DPI awareness
    /// while the app is running by using <see cref="SetThreadDpiAwarenessContext"/>.
    /// It is important to note that if your application has a <see cref="DPI_AWARENESS_PER_MONITOR_AWARE"/> window,
    /// you are responsible for keeping track of the DPI by responding to <see cref="WM_DPICHANGED"/> messages.
    /// </remarks>
    public enum DPI_AWARENESS
    {
        /// <summary>
        /// Invalid DPI awareness. This is an invalid DPI awareness value.
        /// </summary>
        DPI_AWARENESS_INVALID = -1,

        /// <summary>
        /// DPI unaware. This process does not scale for DPI changes and is always assumed to have a scale factor of 100% (96 DPI).
        /// It will be automatically scaled by the system on any other DPI setting.
        /// </summary>
        DPI_AWARENESS_UNAWARE = 0,

        /// <summary>
        /// System DPI aware. This process does not scale for DPI changes.
        /// It will query for the DPI once and use that value for the lifetime of the process.
        /// If the DPI changes, the process will not adjust to the new DPI value.
        /// It will be automatically scaled up or down by the system when the DPI changes from the system value.
        /// </summary>
        DPI_AWARENESS_SYSTEM_AWARE = 1,

        /// <summary>
        /// Per monitor DPI aware.
        /// This process checks for the DPI when it is created and adjusts the scale factor whenever the DPI changes.
        /// These processes are not automatically scaled by the system.
        /// </summary>
        DPI_AWARENESS_PER_MONITOR_AWARE = 2
    }
}
