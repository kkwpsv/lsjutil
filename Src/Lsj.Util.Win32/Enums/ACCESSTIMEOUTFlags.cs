using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="ACCESSTIMEOUT"/> Flags.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-accesstimeout"/>
    /// </para>
    /// </summary>
    public enum ACCESSTIMEOUTFlags : uint
    {
        /// <summary>
        /// If this flag is set, the operating system plays a descending siren sound
        /// when the time-out period elapses and the accessibility features are turned off.
        /// </summary>
        ATF_ONOFFFEEDBACK = 0x00000002,

        /// <summary>
        /// If this flag is set, a time-out period has been set for accessibility features.
        /// If this flag is not set, the features will not time out even though a time-out period is specified.
        /// </summary>
        ATF_TIMEOUTON = 0x00000001,
    }
}
