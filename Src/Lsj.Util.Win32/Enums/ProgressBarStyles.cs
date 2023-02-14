using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Progress Bar Styles
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/controls/progress-bar-control-styles"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// You can set progress bar styles, in the same way as other common controls,
    /// with <see cref="CreateWindowEx"/>, <see cref="GetWindowLong"/>, or <see cref="SetWindowLong"/>.
    /// </remarks>
    public enum ProgressBarStyles : uint
    {
        /// <summary>
        /// Version 6.0 or later.
        /// The progress indicator does not grow in size but instead moves repeatedly along the length of the bar,
        /// indicating activity without specifying what proportion of the progress is complete.
        /// </summary>
        PBS_MARQUEE = 0x08,

        /// <summary>
        /// Version 4.70 or later.
        /// The progress bar displays progress status in a smooth scrolling bar instead of the default segmented bar.
        /// </summary>
        PBS_SMOOTH = 0x01,

        /// <summary>
        /// Version 6.0 or later and Windows Vista.
        /// Determines the animation behavior that the progress bar should use when moving backward (from a higher value to a lower value).
        /// If this is set, then a "smooth" transition will occur, otherwise the control will "jump" to the lower value.
        /// </summary>
        PBS_SMOOTHREVERSE = 0x10,

        /// <summary>
        /// Version 4.70 or later.
        /// The progress bar displays progress status vertically, from bottom to top.
        /// </summary>
        PBS_VERTICAL = 0x04,
    }
}
