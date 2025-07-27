using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.DISPLAYCONFIG_PATH_INFOFlags;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="DISPLAYCONFIG_PATH_SOURCE_INFO"/> structure contains source information for a single path.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-displayconfig_path_source_info"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// A <see cref="DISPLAYCONFIG_PATH_SOURCE_INFO"/> structure is specified
    /// in the <see cref="DISPLAYCONFIG_PATH_INFO.sourceInfo"/> member of a <see cref="DISPLAYCONFIG_PATH_INFO"/> structure.
    /// </para>
    /// <para>
    /// A source corresponds to a surface on which the display adapter can render pixels.
    /// Each display adapter is capable of rendering to x number of sources.
    /// What this means is how many desktops can be rendered for extend mode.
    /// This is typically 2. For example, source 0 might be rendering pixels from 0,0 to 1024,768,
    /// and source 1 might be rendering pixels from 1025,0 to 2048, 768.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct DISPLAYCONFIG_PATH_SOURCE_INFO
    {
        /// <summary>
        /// The identifier of the adapter that this source information relates to.
        /// </summary>
        [FieldOffset(0)]
        public LUID adapterId;

        /// <summary>
        /// The source identifier on the specified adapter that this path relates to.
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
        /// <para>
        /// A valid identifier used to show which clone group the path is a member of only when <see cref="DISPLAYCONFIG_PATH_SUPPORT_VIRTUAL_MODE"/> is set.
        /// If this value is invalid, then it must be set to <see cref="DISPLAYCONFIG_PATH_CLONE_GROUP_INVALID"/>.
        /// </para>
        /// <para>
        /// <see cref="cloneGroupId"/> is only used when the source mode index is not specified.
        /// Two such scenarios are when the source mode info must be invalid because <see cref="SDC_TOPOLOGY_SUPPLIED"/> is used,
        /// and when <see cref="SDC_USE_SUPPLIED_DISPLAY_CONFIG"/> is used with paths that do not have source mode info.
        /// The <see cref="cloneGroupId"/> will be used to indicate which paths are in a clone group,
        /// all the paths with the same <see cref="cloneGroupId"/> value are considered in the same clone group.
        /// There is no requirement that the clone group id’s have to be zero based or contiguous. Supported starting in Windows 10.
        /// </para>
        /// </summary>
        public UINT32 cloneGroupId
        {
            get => modeInfoIdx & 0xFFFF;
            set => modeInfoIdx |= (value & 0xFFFF);
        }

        /// <summary>
        /// A valid index into the mode array of the <see cref="DISPLAYCONFIG_SOURCE_MODE"/> entry
        /// that contains the source mode information for this path only when <see cref="DISPLAYCONFIG_PATH_SUPPORT_VIRTUAL_MODE"/> is set.
        /// If there is no entry for this in the mode array,
        /// the value of <see cref="sourceModeInfoIdx"/> is <see cref="DISPLAYCONFIG_PATH_SOURCE_MODE_IDX_INVALID"/>.
        /// Supported starting in Windows 10.
        /// </summary>
        public UINT32 sourceModeInfoIdx
        {
            get => modeInfoIdx >> 16;
            set => modeInfoIdx |= (value << 16);
        }

        /// <summary>
        /// <para>
        /// A bitwise OR of flag values that indicates the status of the source.
        /// The following values are supported:
        /// </para>
        /// <para>
        /// <see cref="DISPLAYCONFIG_SOURCE_IN_USE"/>
        /// </para>
        /// <para>
        /// This source is in use by at least one active path.
        /// </para>
        /// </summary>
        [FieldOffset(16)]
        public UINT32 statusFlags;
    }
}
