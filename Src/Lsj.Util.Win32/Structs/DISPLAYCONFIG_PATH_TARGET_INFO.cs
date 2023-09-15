using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Enums.DISPLAYCONFIG_PATH_TARGET_INFOFlags;
using static Lsj.Util.Win32.Enums.QueryDisplayConfigFlags;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="DISPLAYCONFIG_PATH_TARGET_INFO"/> structure contains target information for a single path.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-displayconfig_path_target_info"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// A <see cref="DISPLAYCONFIG_PATH_TARGET_INFO"/> structure is specified
    /// in the <see cref="DISPLAYCONFIG_PATH_INFO.targetInfo"/> member of a <see cref="DISPLAYCONFIG_PATH_INFO"/> structure.
    /// A target corresponds to the number of possible video outputs on a display adapter.
    /// This number, however, does not equate to the number of physical connectors on the display adapter.
    /// Each connector exposes a number of targets that includes backward compatibility with older connector technology.
    /// For example, a DVI connector exposes a DVI target, as well as a VGA target.
    /// A DisplayPort connector, which was introduced in 2006, exposes DisplayPort, HDMI, DVI, legacy TV, and VGA targets.
    /// The <see cref="statusFlags"/> member is set when you call the <see cref="QueryDisplayConfig"/> function.
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct DISPLAYCONFIG_PATH_TARGET_INFO
    {
        /// <summary>
        /// The identifier of the adapter that the path is on.
        /// </summary>
        [FieldOffset(0)]
        public LUID adapterId;

        /// <summary>
        /// The target identifier on the specified adapter that this path relates to.
        /// </summary>
        [FieldOffset(8)]
        public UINT32 id;

        /// <summary>
        /// A valid index into the mode information table that contains the source mode information for this path
        /// only when <see cref="DISPLAYCONFIG_PATH_SUPPORT_VIRTUAL_MODE"/> is not set.
        /// If source mode information is not available, the value of <see cref="modeInfoIdx"/> is <see cref="DISPLAYCONFIG_PATH_MODE_IDX_INVALID"/>.
        /// </summary>
        [FieldOffset(12)]
        public UINT32 modeInfoIdx;

        /// <summary>
        /// A valid index into the mode array of the <see cref="DISPLAYCONFIG_DESKTOP_IMAGE_INFO"/> entry
        /// that contains the desktop mode information for this path only when <see cref="DISPLAYCONFIG_PATH_SUPPORT_VIRTUAL_MODE"/> is set.
        /// If there is no entry for this in the mode array,
        /// the value of <see cref="desktopModeInfoIdx"/> is <see cref="DISPLAYCONFIG_PATH_DESKTOP_IMAGE_IDX_INVALID"/>.
        /// Supported starting in Windows 10.
        /// </summary>
        public UINT32 desktopModeInfoIdx
        {
            get => modeInfoIdx & 0xFFFF;
            set => modeInfoIdx |= (value & 0xFFFF);
        }

        /// <summary>
        /// A valid index into the mode array of the <see cref="DISPLAYCONFIG_TARGET_MODE"/> entry
        /// that contains the target mode information for this path only when <see cref="DISPLAYCONFIG_PATH_SUPPORT_VIRTUAL_MODE"/> is set.
        /// If there is no entry for this in the mode array,
        /// the value of <see cref="targetModeInfoIdx"/> is <see cref="DISPLAYCONFIG_PATH_TARGET_MODE_IDX_INVALID"/>.
        /// Supported starting in Windows 10.
        /// </summary>
        public UINT32 targetModeInfoIdx
        {
            get => modeInfoIdx >> 16;
            set => modeInfoIdx |= (value << 16);
        }

        /// <summary>
        /// The target's connector type.
        /// For a list of possible values, see the <see cref="DISPLAYCONFIG_VIDEO_OUTPUT_TECHNOLOGY"/> enumerated type.
        /// </summary>
        [FieldOffset(16)]
        public DISPLAYCONFIG_VIDEO_OUTPUT_TECHNOLOGY outputTechnology;

        /// <summary>
        /// A value that specifies the rotation of the target.
        /// For a list of possible values, see the <see cref="DISPLAYCONFIG_ROTATION"/> enumerated type.
        /// </summary>
        [FieldOffset(20)]
        public DISPLAYCONFIG_ROTATION rotation;

        /// <summary>
        /// A value that specifies how the source image is scaled to the target.
        /// For a list of possible values, see the <see cref="DISPLAYCONFIG_SCALING"/> enumerated type.
        /// For more information about scaling, see Scaling the Desktop Image.
        /// </summary>
        [FieldOffset(24)]
        public DISPLAYCONFIG_SCALING scaling;

        /// <summary>
        /// A <see cref="DISPLAYCONFIG_RATIONAL"/> structure that specifies the refresh rate of the target.
        /// If the caller specifies target mode information, the operating system will instead use the refresh rate
        /// that is stored in the <see cref="DISPLAYCONFIG_VIDEO_SIGNAL_INFO.vSyncFreq"/> member
        /// of the <see cref="DISPLAYCONFIG_VIDEO_SIGNAL_INFO"/> structure.
        /// In this case, the caller specifies this value in the <see cref="DISPLAYCONFIG_TARGET_MODE.targetVideoSignalInfo"/> member 
        /// of the <see cref="DISPLAYCONFIG_TARGET_MODE"/> structure.
        /// A refresh rate with both the numerator and denominator set to zero indicates
        /// that the caller does not specify a refresh rate and the operating system should use the most optimal refresh rate available.
        /// For this case, in a call to the <see cref="SetDisplayConfig"/> function,
        /// the caller must set the <see cref="DISPLAYCONFIG_SCANLINE_ORDERING_UNSPECIFIED.scanLineOrdering"/> member
        /// to the <see cref="DISPLAYCONFIG_SCANLINE_ORDERING_UNSPECIFIED"/> value; otherwise, <see cref="SetDisplayConfig"/> fails.
        /// </summary>
        [FieldOffset(28)]
        public DISPLAYCONFIG_RATIONAL refreshRate;

        /// <summary>
        /// A value that specifies the scan-line ordering of the output on the target.
        /// For a list of possible values, see the <see cref="DISPLAYCONFIG_SCANLINE_ORDERING"/> enumerated type.
        /// If the caller specifies target mode information, the operating system will instead use the scan-line ordering
        /// that is stored in the <see cref="DISPLAYCONFIG_VIDEO_SIGNAL_INFO.scanLineOrdering"/> member
        /// of the <see cref="DISPLAYCONFIG_VIDEO_SIGNAL_INFO"/> structure.
        /// In this case, the caller specifies this value in the <see cref="DISPLAYCONFIG_TARGET_MODE.targetVideoSignalInfo"/> member
        /// of the <see cref="DISPLAYCONFIG_TARGET_MODE"/> structure.
        /// </summary>
        [FieldOffset(36)]
        public DISPLAYCONFIG_SCANLINE_ORDERING scanLineOrdering;

        /// <summary>
        /// A Boolean value that specifies whether the target is available.
        /// <see cref="TRUE"/> indicates that the target is available.
        /// Because the asynchronous nature of display topology changes when a monitor is removed,
        /// a path might still be marked as active even though the monitor has been removed.
        /// In such a case, <see cref="targetAvailable"/> could be <see cref="FALSE"/> for an active path.
        /// This is typically a transient situation that will change after the operating system takes action on the monitor removal.
        /// </summary>
        [FieldOffset(40)]
        public BOOL targetAvailable;

        /// <summary>
        /// A bitwise OR of flag values that indicates the status of the target.
        /// The following values are supported:
        /// <see cref="DISPLAYCONFIG_TARGET_IN_USE"/>:
        /// Target is in use on an active path.
        /// <see cref="DISPLAYCONFIG_TARGET_FORCIBLE"/>:
        /// The output can be forced on this target even if a monitor is not detected.
        /// <see cref="DISPLAYCONFIG_TARGET_FORCED_AVAILABILITY_BOOT"/>:
        /// Output is currently being forced in a boot-persistent manner.
        /// <see cref="DISPLAYCONFIG_TARGET_FORCED_AVAILABILITY_PATH"/>:
        /// Output is currently being forced in a path-persistent manner.
        /// <see cref="DISPLAYCONFIG_TARGET_FORCED_AVAILABILITY_SYSTEM"/>:
        /// Output is currently being forced in a nonpersistent manner.
        /// <see cref="DISPLAYCONFIG_TARGET_IS_HMD"/>:
        /// The output is a head-mounted display (HMD).
        /// Such a path is only returned from <see cref="QueryDisplayConfig"/> using the <see cref="QDC_INCLUDE_HMD"/> flag.
        /// Supported starting in the Windows 10 Creators Update(Version 1703).
        /// </summary>
        [FieldOffset(44)]
        public DISPLAYCONFIG_PATH_TARGET_INFOFlags statusFlags;
    }
}
