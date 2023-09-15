using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.DISPLAYCONFIG_PATH_INFOFlags;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="DISPLAYCONFIG_PATH_INFO"/> structure is used to describe a single path from a target to a source.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-displayconfig_path_info"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DISPLAYCONFIG_PATH_INFO
    {
        /// <summary>
        /// A <see cref="DISPLAYCONFIG_PATH_SOURCE_INFO"/> structure that contains the source information for the path.
        /// </summary>
        public DISPLAYCONFIG_PATH_SOURCE_INFO sourceInfo;

        /// <summary>
        /// A <see cref="DISPLAYCONFIG_PATH_TARGET_INFO"/> structure that contains the target information for the path.
        /// </summary>
        public DISPLAYCONFIG_PATH_TARGET_INFO targetInfo;

        /// <summary>
        /// A bitwise OR of flag values that indicates the state of the path.
        /// The following values are supported:
        /// <see cref="DISPLAYCONFIG_PATH_ACTIVE"/>:
        /// Set by <see cref="QueryDisplayConfig"/> to indicate that the path is active and part of the desktop.
        /// If this flag value is set, <see cref="SetDisplayConfig"/> attempts to enable this path.
        /// <see cref="DISPLAYCONFIG_PATH_SUPPORT_VIRTUAL_MODE"/>:
        /// Set by <see cref="QueryDisplayConfig"/> to indicate that the path supports virtual modes.
        /// Supported starting in Windows 10.
        /// <see cref="DISPLAYCONFIG_PATH_BOOST_REFRESH_RATE"/>:
        /// Set by <see cref="QueryDisplayConfig"/> to indicate that the path supports virtual refresh rates.
        /// Supported starting in Windows 11.
        /// </summary>
        public DISPLAYCONFIG_PATH_INFOFlags flags;
    }
}
