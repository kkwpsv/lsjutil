using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Gets and sets the configuration for enabling gesture messages and the type of this configuration.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-gestureconfig"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// It is impossible to disable two-finger panning and keep single finger panning.
    /// You must set the want bits for <see cref="GC_PAN"/> before you can set them
    /// for <see cref="GC_PAN_WITH_SINGLE_FINGER_HORIZONTALLY"/> or <see cref="GC_PAN_WITH_SINGLE_FINGER_VERTICALLY"/>.
    /// </para>
    /// <para>
    /// An inertia vector is included in the <see cref="GID_PAN"/> message with the <see cref="GF_END"/> flag
    /// if inertia was disabled by a call to <see cref="SetGestureConfig"/>.
    /// </para>
    /// <para>
    /// When you pass this structure, the <see cref="dwID"/> member contains information for a set of gestures.
    /// This determines what the other flags will mean.
    /// If you set flags for pan messages, they will be different from those flags that are set for rotation messages.
    /// </para>
    /// <para>
    /// The following table indicates the various identifiers for gestures that are supported
    /// by the <see cref="dwID"/> member of the <see cref="GESTURECONFIG"/> structure.
    /// Note that setting <see cref="dwID"/> to 0 indicates that global gesture configuration flags are set.
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Name
    /// </term>
    /// <term>
    /// Value
    /// </term>
    /// <term>
    /// Description
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// <see cref="GID_ZOOM"/>
    /// </term>
    /// <term>
    /// 3
    /// </term>
    /// <term>
    /// Indicates configuration settings for the zoom gesture.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="GID_PAN"/>
    /// </term>
    /// <term>
    /// 4
    /// </term>
    /// <term>
    /// Indicates the pan gesture.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="GID_ROTATE"/>
    /// </term>
    /// <term>
    /// 5
    /// </term>
    /// <term>
    /// Indicates the rotation gesture.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="GID_TWOFINGERTAP"/>
    /// </term>
    /// <term>
    /// 6
    /// </term>
    /// <term>
    /// Indicates the two-finger tap gesture.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="GID_PRESSANDTAP"/>
    /// </term>
    /// <term>
    /// 7
    /// </term>
    /// <term>
    /// Indicates the press and tap gesture.
    /// </term>
    /// </item>
    /// </list>
    /// <para>
    /// The following flags are used when <see cref="dwID"/> is set to 0.
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Name
    /// </term>
    /// <term>
    /// Value
    /// </term>
    /// <term>
    /// Description
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// <see cref="GC_ALLGESTURES"/>
    /// </term>
    /// <term>
    /// 0x00000001
    /// </term>
    /// <term>
    /// Indicates all of the gestures.
    /// </term>
    /// </item>
    /// </list>
    /// /// <para>
    /// The following flags are used when <see cref="dwID"/> is set to <see cref="GID_ZOOM"/>.
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Name
    /// </term>
    /// <term>
    /// Value
    /// </term>
    /// <term>
    /// Description
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// <see cref="GC_ZOOM"/>
    /// </term>
    /// <term>
    /// 0x00000001
    /// </term>
    /// <term>
    /// Indicates the zoom gesture.
    /// </term>
    /// </item>
    /// </list>
    /// <para>
    /// The following flags are used when <see cref="dwID"/> is set to <see cref="GID_PAN"/>.
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Name
    /// </term>
    /// <term>
    /// Value
    /// </term>
    /// <term>
    /// Description
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// <see cref="GC_PAN"/>
    /// </term>
    /// <term>
    /// 0x00000001
    /// </term>
    /// <term>
    /// Indicates all pan gestures.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="GC_PAN_WITH_SINGLE_FINGER_VERTICALLY"/>
    /// </term>
    /// <term>
    /// 0x00000002
    /// </term>
    /// <term>
    /// Indicates vertical pans with one finger.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="GC_PAN_WITH_SINGLE_FINGER_HORIZONTALLY"/>
    /// </term>
    /// <term>
    /// 0x00000004
    /// </term>
    /// <term>
    /// Indicates horizontal pans with one finger.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="GC_PAN_WITH_GUTTER"/>
    /// </term>
    /// <term>
    /// 0x00000008
    /// </term>
    /// <term>
    /// Limits perpendicular movement to primary direction until a threshold is reached to break out of the gutter.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="GC_PAN_WITH_INERTIA"/>
    /// </term>
    /// <term>
    /// 0x00000010
    /// </term>
    /// <term>
    /// Indicates panning with inertia to smoothly slow when pan gestures stop.
    /// </term>
    /// </item>
    /// </list>
    /// <para>
    /// Note
    /// Setting the <see cref="GID_PAN"/> flags in <see cref="SetGestureConfig"/> will affect the default gesture handler for panning.
    /// You should not have both <see cref="dwWant"/> and <see cref="dwBlock"/> set for the same flags; this will result in unexpected behavior.
    /// See Windows Touch Gestures for more information on panning and legacy panning support;
    /// see <see cref="SetGestureConfig"/> for examples of enabling and blocking gestures.
    /// </para>
    /// <para>
    /// The following flags are used when <see cref="dwID"/> is set to <see cref="GID_ROTATE"/>.
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Name
    /// </term>
    /// <term>
    /// Value
    /// </term>
    /// <term>
    /// Description
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// <see cref="GC_ROTATE"/>
    /// </term>
    /// <term>
    /// 0x00000001
    /// </term>
    /// <term>
    /// Indicates the rotation gesture.
    /// </term>
    /// </item>
    /// </list>
    /// <para>
    /// The following flags are used when <see cref="dwID"/> is set to <see cref="GID_TWOFINGERTAP"/>.
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Name
    /// </term>
    /// <term>
    /// Value
    /// </term>
    /// <term>
    /// Description
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// <see cref="GC_TWOFINGERTAP"/>
    /// </term>
    /// <term>
    /// 0x00000001
    /// </term>
    /// <term>
    /// Indicates the two-finger tap gesture.
    /// </term>
    /// </item>
    /// </list>
    /// <para>
    /// The following flags are used when <see cref="dwID"/> is set to <see cref="GID_PRESSANDTAP"/>.
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Name
    /// </term>
    /// <term>
    /// Value
    /// </term>
    /// <term>
    /// Description
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// <see cref="GC_PRESSANDTAP"/>
    /// </term>
    /// <term>
    /// 0x00000001
    /// </term>
    /// <term>
    /// Indicates the press and tap gesture.
    /// </term>
    /// </item>
    /// </list>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct GESTURECONFIG
    {
        /// <summary>
        /// The identifier for the type of configuration that will have messages enabled or disabled.
        /// For more information, see Remarks.
        /// </summary>
        public DWORD dwID;

        /// <summary>
        /// The messages to enable.
        /// </summary>
        public DWORD dwWant;

        /// <summary>
        /// The messages to disable.
        /// </summary>
        public DWORD dwBlock;
    }
}
