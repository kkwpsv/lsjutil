using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.DISPLAYCONFIG_MODE_INFO_TYPE;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="DISPLAYCONFIG_MODE_INFO"/> structure contains either source mode or target mode information.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-displayconfig_mode_info"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct DISPLAYCONFIG_MODE_INFO
    {
        /// <summary>
        /// A value that indicates whether the <see cref="DISPLAYCONFIG_MODE_INFO"/> structure represents source or target mode information.
        /// If <see cref="infoType"/> is <see cref="DISPLAYCONFIG_MODE_INFO_TYPE_TARGET"/>,
        /// the <see cref="targetMode"/> parameter value contains a valid <see cref="DISPLAYCONFIG_TARGET_MODE"/> structure describing the specified target.
        /// If <see cref="infoType"/> is <see cref="DISPLAYCONFIG_MODE_INFO_TYPE_SOURCE"/>,
        /// the <see cref="sourceMode"/> parameter value contains a valid <see cref="DISPLAYCONFIG_SOURCE_MODE"/> structure describing the specified source.
        /// </summary>
        [FieldOffset(0)]
        public DISPLAYCONFIG_MODE_INFO_TYPE infoType;

        /// <summary>
        /// The source or target identifier on the specified adapter that this path relates to.
        /// </summary>
        [FieldOffset(4)]
        public UINT32 id;

        /// <summary>
        /// The identifier of the adapter that this source or target mode information relates to.
        /// </summary>
        [FieldOffset(8)]
        public LUID adapterId;

        /// <summary>
        /// A valid <see cref="DISPLAYCONFIG_TARGET_MODE"/> structure that describes the specified target
        /// only when <see cref="infoType"/> is <see cref="DISPLAYCONFIG_MODE_INFO_TYPE_TARGET"/>.
        /// </summary>
        [FieldOffset(16)]
        public DISPLAYCONFIG_TARGET_MODE targetMode;

        /// <summary>
        /// A valid <see cref="DISPLAYCONFIG_SOURCE_MODE"/> structure that describes the specified source
        /// only when <see cref="infoType"/> is <see cref="DISPLAYCONFIG_MODE_INFO_TYPE_SOURCE"/>.
        /// </summary>
        [FieldOffset(16)]
        public DISPLAYCONFIG_SOURCE_MODE sourceMode;

        /// <summary>
        /// A <see cref="DISPLAYCONFIG_DESKTOP_IMAGE_INFO"/> structure that describes information about the desktop image only
        /// when infoType is <see cref="DISPLAYCONFIG_MODE_INFO_TYPE_DESKTOP_IMAGE"/>.
        /// Supported starting in Windows 10.
        /// </summary>
        [FieldOffset(16)]
        public DISPLAYCONFIG_DESKTOP_IMAGE_INFO desktopImageInfo;
    }
}
