using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="ChangeDisplaySettings"/> and <see cref="ChangeDisplaySettingsEx"/> Flags
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-changedisplaysettingsexw"/>
    /// </para>
    /// </summary>
    public enum ChangeDisplaySettingsFlags : uint
    {
        /// <summary>
        /// The mode is temporary in nature.
        /// If you change to and from another desktop, this mode will not be reset.
        /// </summary>
        CDS_FULLSCREEN = 0x00000004,

        /// <summary>
        /// The settings will be saved in the global settings area so that they will affect all users on the machine.
        /// Otherwise, only the settings for the user are modified.
        /// This flag is only valid when specified with the <see cref="CDS_UPDATEREGISTRY"/> flag.
        /// </summary>
        CDS_GLOBAL = 0x00000008,

        /// <summary>
        /// The settings will be saved in the registry, but will not take effect.
        /// This flag is only valid when specified with the <see cref="CDS_UPDATEREGISTRY"/> flag.
        /// </summary>
        CDS_NORESET = 0x10000000,

        /// <summary>
        /// The settings should be changed, even if the requested settings are the same as the current settings.
        /// </summary>
        CDS_RESET = 0x40000000,

        /// <summary>
        /// This device will become the primary device.
        /// </summary>
        CDS_SET_PRIMARY = 0x00000010,

        /// <summary>
        /// The system tests if the requested graphics mode could be set.
        /// </summary>
        CDS_TEST = 0x00000002,

        /// <summary>
        /// The graphics mode for the current screen will be changed dynamically and the graphics mode will be updated in the registry
        /// The mode information is stored in the USER profile.
        /// </summary>
        CDS_UPDATEREGISTRY = 0x00000001,

        /// <summary>
        /// When set, the lParam parameter is a pointer to a <see cref="VIDEOPARAMETERS"/> structure.
        /// </summary>
        CDS_VIDEOPARAMETERS = 0x00000020,

        /// <summary>
        /// Enables settings changes to unsafe graphics modes.
        /// </summary>
        CDS_ENABLE_UNSAFE_MODES = 0x00000100,

        /// <summary>
        /// Disables settings changes to unsafe graphics modes.
        /// </summary>
        CDS_DISABLE_UNSAFE_MODES = 0x00000200,
    }
}
