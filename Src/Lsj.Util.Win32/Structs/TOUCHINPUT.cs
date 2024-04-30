using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Encapsulates data for touch input.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-touchinput"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The following table lists the flags for the <see cref="dwFlags"/> member.
    /// <see cref="TOUCHEVENTF_MOVE"/>:
    /// Movement has occurred. Cannot be combined with <see cref="TOUCHEVENTF_DOWN"/>.
    /// <see cref="TOUCHEVENTF_DOWN"/>:
    /// The corresponding touch point was established through a new contact.
    /// Cannot be combined with <see cref="TOUCHEVENTF_MOVE"/> or <see cref="TOUCHEVENTF_UP"/>.
    /// <see cref="TOUCHEVENTF_UP"/>:
    /// A touch point was removed.
    /// <see cref="TOUCHEVENTF_INRANGE"/>:
    /// A touch point is in range. This flag is used to enable touch hover support on compatible hardware.
    /// Applications that do not want support for hover can ignore this flag.
    /// <see cref="TOUCHEVENTF_PRIMARY"/>:
    /// Indicates that this <see cref="TOUCHINPUT"/> structure corresponds to a primary contact point.
    /// See the following text for more information on primary touch points.
    /// <see cref="TOUCHEVENTF_NOCOALESCE"/>:
    /// When received using <see cref="GetTouchInputInfo"/>, this input was not coalesced.
    /// <see cref="TOUCHEVENTF_PEN"/>:
    /// The touch event was triggered by a stylus device.
    /// <see cref="TOUCHEVENTF_PALM"/>:
    /// The touch event was triggered by the user's palm.
    /// Note
    /// If the target hardware on a machine does not support hover, when the <see cref="TOUCHEVENTF_UP"/> flag is set, the <see cref="TOUCHEVENTF_INRANGE"/> flag is cleared.
    /// If the target hardware on a machine supports hover, the <see cref="TOUCHEVENTF_UP"/> and <see cref="TOUCHEVENTF_INRANGE"/> flags will be set independently.
    /// The following table lists the flags for the <see cref="dwMask"/> member.
    /// <see cref="TOUCHINPUTMASKF_CONTACTAREA"/>:
    /// <see cref="cxContact"/> and <see cref="cyContact"/> are valid.
    /// See the following text for more information on primary touch points.
    /// <see cref="TOUCHINPUTMASKF_EXTRAINFO"/>:
    /// <see cref="dwExtraInfo"/> is valid.
    /// <see cref="TOUCHINPUTMASKF_TIMEFROMSYSTEM"/>:
    /// The system time was set in the <see cref="TOUCHINPUT"/> structure.
    /// A touch point is designated as primary when it is the first touch point to be established from a previous state of no touch points.
    /// The <see cref="TOUCHEVENTF_PRIMARY"/> flag continues to be set for all subsequent events for the primary touch point until the primary touch point is released.
    /// Note that a <see cref="TOUCHEVENTF_UP"/> event on the primary touch point does not necessarily designate the end of a Windows Touch operation;
    /// the current Windows Touch operation proceeds from the establishment of the primary touch point until the last touch point is released.
    /// Note that a solitary touch point or, in a set of simultaneous touch points, the first to be detected, is designated the primary.
    /// The system mouse position follows the primary touch point and, in addition to touch messages,
    /// also generates <see cref="WM_LBUTTONDOWN"/>, <see cref="WM_MOUSEMOVE"/>, and <see cref="WM_LBUTTONUP"/> messages in response to actions on a primary touch point.
    /// The primary touch point can also generate <see cref="WM_RBUTTONDOWN"/> and <see cref="WM_RBUTTONUP"/> messages using the press and hold gesture.
    /// Note that the touch point identifier may be dynamic and is associated with a given touch point only as long as the touch point persists.
    /// If contact is broken and then resumed (for example, if a finger is removed from the surface and then pressed down again),
    /// the same touch point (the same finger, pen, or other such device) may receive a different touch point identifier.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct TOUCHINPUT
    {
        /// <summary>
        /// The x-coordinate (horizontal point) of the touch input.
        /// This member is indicated in hundredths of a pixel of physical screen coordinates.
        /// </summary>
        public LONG x;

        /// <summary>
        /// The y-coordinate (vertical point) of the touch input.
        /// This member is indicated in hundredths of a pixel of physical screen coordinates.
        /// </summary>
        public LONG y;

        /// <summary>
        /// A device handle for the source input device.
        /// Each device is given a unique provider at run time by the touch input provider.
        /// See Examples section below.
        /// </summary>
        public HANDLE hSource;

        /// <summary>
        /// A touch point identifier that distinguishes a particular touch input.
        /// This value stays consistent in a touch contact sequence from the point a contact comes down until it comes back up.
        /// An ID may be reused later for subsequent contacts.
        /// </summary>
        public DWORD dwID;

        /// <summary>
        /// A set of bit flags that specify various aspects of touch point press, release, and motion.
        /// The bits in this member can be any reasonable combination of the values in the Remarks section.
        /// </summary>
        public DWORD dwFlags;

        /// <summary>
        /// A set of bit flags that specify which of the optional fields in the structure contain valid values.
        /// The availability of valid information in the optional fields is device-specific.
        /// Applications should use an optional field value only when the corresponding bit is set in <see cref="dwMask"/>.
        /// This field may contain a combination of the <see cref="dwMask"/> flags mentioned in the Remarks section.
        /// </summary>
        public DWORD dwMask;

        /// <summary>
        /// The time stamp for the event, in milliseconds.
        /// The consuming application should note that the system performs no validation on this field;
        /// when the <see cref="TOUCHINPUTMASKF_TIMEFROMSYSTEM"/> flag is not set,
        /// the accuracy and sequencing of values in this field are completely dependent on the touch input provider.
        /// </summary>
        public DWORD dwTime;

        /// <summary>
        /// An additional value associated with the touch event.
        /// </summary>
        public ULONG_PTR dwExtraInfo;

        /// <summary>
        /// The width of the touch contact area in hundredths of a pixel in physical screen coordinates.
        /// This value is only valid if the dwMask member has the <see cref="TOUCHEVENTFMASK_CONTACTAREA"/> flag set.
        /// </summary>
        public DWORD cxContact;

        /// <summary>
        /// The height of the touch contact area in hundredths of a pixel in physical screen coordinates.
        /// This value is only valid if the dwMask member has the <see cref="TOUCHEVENTFMASK_CONTACTAREA"/> flag set.
        /// </summary>
        public DWORD cyContact;
    }
}
