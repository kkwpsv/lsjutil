using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

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
    /// It is impossible to disable two-finger panning and keep single finger panning.
    /// You must set the want bits for <see cref="GC_PAN"/> before you can set them
    /// for <see cref="GC_PAN_WITH_SINGLE_FINGER_HORIZONTALLY"/> or <see cref="GC_PAN_WITH_SINGLE_FINGER_VERTICALLY"/>.
    /// An inertia vector is included in the <see cref="GID_PAN"/> message
    /// with the <see cref="GF_END"/> flag if inertia was disabled by a call to <see cref="SetGestureConfig"/>.
    /// When you pass this structure, the <see cref="dwID"/> member contains information for a set of gestures.
    /// This determines what the other flags will mean. If you set flags for pan messages,
    /// they will be different from those flags that are set for rotation messages.
    /// The following table indicates the various identifiers for gestures
    /// that are supported by the <see cref="dwID"/> member of the <see cref="GESTURECONFIG"/> structure.
    /// Note that setting <see cref="dwID"/> to 0 indicates that global gesture configuration flags are set.
    /// Name                            Value       Description
    /// <see cref="GID_ZOOM"/>          3           Indicates configuration settings for the zoom gesture.
    /// <see cref="GID_PAN"/>           4           Indicates the pan gesture.
    /// <see cref="GID_ROTATE"/>        5           Indicates the rotation gesture.
    /// <see cref="GID_TWOFINGERTAP"/>  6           Indicates the two-finger tap gesture.
    /// <see cref="GID_PRESSANDTAP"/>   7           Indicates the press and tap gesture.
    /// The following flags are used when <see cref="dwID"/> is set to 0.
    /// Name                            Value           Description
    /// <see cref="GC_ALLGESTURES"/>    0x00000001      Indicates all of the gestures.
    /// The following flags are used when <see cref="dwID"/> is set to <see cref="GID_ZOOM"/>.
    /// Name                    Value           Description
    /// <see cref="GC_ZOOM"/>   0x00000001      Indicates the zoom gesture.
    /// The following flags are used when <see cref="dwID"/> is set to <see cref="GID_PAN"/>.
    /// Name                                                    Value           Description
    /// <see cref="GC_PAN"/>                                    0x00000001      Indicates all pan gestures.
    /// <see cref="GC_PAN_WITH_SINGLE_FINGER_VERTICALLY"/>      0x00000002      Indicates vertical pans with one finger.
    /// <see cref="GC_PAN_WITH_SINGLE_FINGER_HORIZONTALLY"/>    0x00000004      Indicates horizontal pans with one finger.
    /// <see cref="GC_PAN_WITH_GUTTER"/>                        0x00000008      Limits perpendicular movement to primary direction until a threshold is reached to break out of the gutter.
    /// <see cref="GC_PAN_WITH_INERTIA"/>                       0x00000010      Indicates panning with inertia to smoothly slow when pan gestures stop.
    /// Note
    /// Setting the <see cref="GID_PAN"/> flags in <see cref="SetGestureConfig"/> will affect the default gesture handler for panning.
    /// You should not have both <see cref="dwWant"/> and <see cref="dwBlock"/> set for the same flags; this will result in unexpected behavior.
    /// See Windows Touch Gestures for more information on panning and legacy panning support;
    /// see <see cref="SetGestureConfig"/> for examples of enabling and blocking gestures.
    /// The following flags are used when <see cref="dwID"/> is set to <see cref="GID_ROTATE"/>.
    /// Name                        Value           Description
    /// <see cref="GC_ROTATE"/>     0x00000001      Indicates the rotation gesture.
    /// The following flags are used when <see cref="dwID"/> is set to <see cref="GID_TWOFINGERTAP"/>.
    /// Name                                Value           Description
    /// <see cref="GC_TWOFINGERTAP"/>       0x00000001      Indicates the two-finger tap gesture.
    /// The following flags are used when <see cref="dwID"/> is set to <see cref="GID_PRESSANDTAP"/>.
    /// Name                                Value           Description
    /// <see cref="GC_PRESSANDTAP"/>        0x00000001      Indicates the press and tap gesture.
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
