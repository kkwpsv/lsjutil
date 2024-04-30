using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Stores information about a gesture.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-gestureinfo"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The HIDWORD of the <see cref="ullArguments"/> member is always 0, with the following exceptions:
    /// For <see cref="GID_PAN"/>, it is 0 except when there is inertia.
    /// When <see cref="GF_INERTIA"/> is set, the HIDWORD is an inertia vector (two 16-bit values).
    /// For <see cref="GID_PRESSANDTAP"/>, it is the distance between the two points.
    /// The <see cref="GESTUREINFO"/> structure is retrieved by passing the handle
    /// to the gesture information structure to the <see cref="GetGestureInfo"/> function.
    /// The following flags indicate the various states of the gestures and are stored in <see cref="dwFlags"/>.
    /// Name                        Value       Description
    /// <see cref="GF_BEGIN"/>      0x00000001  A gesture is starting.
    /// <see cref="GF_INERTIA"/>    0x00000002  A gesture has triggered inertia.
    /// <see cref="GF_END"/>        0x00000004  A gesture has finished.
    /// Note
    /// Most applications should ignore the <see cref="GID_BEGIN"/> and <see cref="GID_END"/> messages and pass them to <see cref="DefWindowProc"/>.
    /// These messages are used by the default gesture handler.
    /// Application behavior is undefined when the <see cref="GID_BEGIN"/> and <see cref="GID_END"/> messages are consumed by a third-party application.
    /// The following table indicates the various identifiers for gestures.
    /// Name                            Value       Description
    /// <see cref="GID_BEGIN"/>         1           A gesture is starting.
    /// <see cref="GID_END"/>           2           A gesture is ending.
    /// <see cref="GID_ZOOM"/>          3           The zoom gesture.
    /// <see cref="GID_PAN"/>           4           The pan gesture.
    /// <see cref="GID_ROTATE"/>        5           The rotation gesture.
    /// <see cref="GID_TWOFINGERTAP"/>  6           The two-finger tap gesture.
    /// <see cref="GID_PRESSANDTAP"/>   7           The press and tap gesture.
    /// Note
    /// The <see cref="GID_PAN"/> gesture has built-in inertia.
    /// At the end of a pan gesture, additional pan gesture messages are created by the operating system.
    /// The following type is defined to represent a constant pointer to a GESTUREINFO structure.
    /// <code>
    ///   typedef GESTUREINFO const * PCGESTUREINFO;
    /// </code>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct GESTUREINFO
    {
        /// <summary>
        /// The size of the structure, in bytes.
        /// The caller must set this to <code>sizeof(GESTUREINFO)</code>.
        /// </summary>
        public UINT cbSize;

        /// <summary>
        /// The state of the gesture. For additional information, see Remarks.
        /// </summary>
        public DWORD dwFlags;

        /// <summary>
        /// The identifier of the gesture command.
        /// </summary>
        public DWORD dwID;

        /// <summary>
        /// A handle to the window that is targeted by this gesture.
        /// </summary>
        public HWND hwndTarget;

        /// <summary>
        /// A <see cref="POINTS"/> structure containing the coordinates associated with the gesture.
        /// These coordinates are always relative to the origin of the screen.
        /// </summary>
        public POINTS ptsLocation;

        /// <summary>
        /// An internally used identifier for the structure.
        /// </summary>
        public DWORD dwInstanceID;

        /// <summary>
        /// An internally used identifier for the sequence.
        /// </summary>
        public DWORD dwSequenceID;

        /// <summary>
        /// A 64-bit unsigned integer that contains the arguments for gestures that fit into 8 bytes.
        /// </summary>
        public ULONGLONG ullArguments;

        /// <summary>
        /// The size, in bytes, of extra arguments that accompany this gesture.
        /// </summary>
        public UINT cbExtraArgs;
    }
}
