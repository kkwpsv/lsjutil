using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="ChangeDisplaySettings"/> Results
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-changedisplaysettingsw"/>
    /// </para>
    /// </summary>
    public enum ChangeDisplaySettingsResults : int
    {
        /// <summary>
        /// The settings change was successful.
        /// </summary>
        DISP_CHANGE_SUCCESSFUL = 0,

        /// <summary>
        /// The settings change was unsuccessful because the system is DualView capable.
        /// </summary>
        DISP_CHANGE_BADDUALVIEW = -6,

        /// <summary>
        /// An invalid set of flags was passed in.
        /// </summary>
        DISP_CHANGE_BADFLAGS = -4,

        /// <summary>
        /// The graphics mode is not supported.
        /// </summary>
        DISP_CHANGE_BADMODE = -2,

        /// <summary>
        /// An invalid parameter was passed in.
        /// This can include an invalid flag or combination of flags.
        /// </summary>
        DISP_CHANGE_BADPARAM = -5,

        /// <summary>
        /// The display driver failed the specified graphics mode.
        /// </summary>
        DISP_CHANGE_FAILED = -1,

        /// <summary>
        /// Unable to write settings to the registry.
        /// </summary>
        DISP_CHANGE_NOTUPDATED = -3,

        /// <summary>
        /// The computer must be restarted for the graphics mode to work.
        /// </summary>
        DISP_CHANGE_RESTART = 1,
    }
}
