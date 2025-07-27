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
    /// <para>
    /// The HIDWORD of the <see cref="ullArguments"/> member is always 0, with the following exceptions:
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// For <see cref="GID_PAN"/>, it is 0 except when there is inertia.
    /// When <see cref="GF_INERTIA"/> is set, the HIDWORD is an inertia vector (two 16-bit values).
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// For <see cref="GID_PRESSANDTAP"/>, it is the distance between the two points.
    /// </description>
    /// </item>
    /// </list>
    /// <para>
    /// The <see cref="GESTUREINFO"/> structure is retrieved by passing the handle to the gesture information structure to the <see cref="GetGestureInfo"/> function.
    /// </para>
    /// <para>
    /// The following flags indicate the various states of the gestures and are stored in <see cref="dwFlags"/>.
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
    /// <see cref="GF_BEGIN"/>
    /// </term>
    /// <term>
    /// 0x00000001
    /// </term>
    /// <term>
    /// A gesture is starting.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="GF_INERTIA"/>
    /// </term>
    /// <term>
    /// 0x00000002
    /// </term>
    /// <term>
    /// A gesture has triggered inertia.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="GF_END"/>
    /// </term>
    /// <term>
    /// 0x00000004
    /// </term>
    /// <term>
    /// A gesture has finished.
    /// </term>
    /// </item>
    /// </list>
    /// <para>
    /// Note
    /// Most applications should ignore the <see cref="GID_BEGIN"/> and <see cref="GID_END"/> messages and pass them to <see cref="DefWindowProc"/>.
    /// These messages are used by the default gesture handler.
    /// Application behavior is undefined when the <see cref="GID_BEGIN"/> and <see cref="GID_END"/> messages are consumed by a third-party application.
    /// </para>
    /// <para>
    /// The following table indicates the various identifiers for gestures.
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
    /// <see cref="GID_BEGIN"/>
    /// </term>
    /// <term>
    /// 1
    /// </term>
    /// <term>
    /// A gesture is starting.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="GID_END"/>
    /// </term>
    /// <term>
    /// 2
    /// </term>
    /// <term>
    /// A gesture is ending.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="GID_ZOOM"/>
    /// </term>
    /// <term>
    /// 3
    /// </term>
    /// <term>
    /// The zoom gesture.
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
    /// The pan gesture.
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
    /// The rotation gesture.
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
    /// The two-finger tap gesture.
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
    /// The press and tap gesture.
    /// </term>
    /// </item>
    /// </list>
    /// <para>
    /// Note
    /// The <see cref="GID_PAN"/> gesture has built-in inertia.
    /// At the end of a pan gesture, additional pan gesture messages are created by the operating system.
    /// </para>
    /// <para>
    /// The following type is defined to represent a constant pointer to a <see cref="GESTUREINFO"/> structure.
    /// </para>
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
