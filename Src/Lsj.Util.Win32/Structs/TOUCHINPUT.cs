using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.User32;
using static Lsj.Util.Win32.Enums.WindowMessages;

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
    /// <para>
    /// The following table lists the flags for the <see cref="dwFlags"/> member.
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Flag
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
    /// <see cref="TOUCHEVENTF_MOVE"/>
    /// </term>
    /// <term>
    /// 0x0001
    /// </term>
    /// <term>
    /// Movement has occurred. Cannot be combined with <see cref="TOUCHEVENTF_DOWN"/>.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="TOUCHEVENTF_DOWN"/>
    /// </term>
    /// <term>
    /// 0x0002
    /// </term>
    /// <term>
    /// The corresponding touch point was established through a new contact.
    /// Cannot be combined with <see cref="TOUCHEVENTF_MOVE"/> or <see cref="TOUCHEVENTF_UP"/>.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="TOUCHEVENTF_UP"/>
    /// </term>
    /// <term>
    /// 0x0004
    /// </term>
    /// <term>
    /// A touch point was removed.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="TOUCHEVENTF_INRANGE"/>
    /// </term>
    /// <term>
    /// 0x0008
    /// </term>
    /// <term>
    /// A touch point is in range.
    /// This flag is used to enable touch hover support on compatible hardware.
    /// Applications that do not want support for hover can ignore this flag.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="TOUCHEVENTF_PRIMARY"/>
    /// </term>
    /// <term>
    /// 0x0010
    /// </term>
    /// <term>
    /// Indicates that this <see cref="TOUCHINPUT"/> structure corresponds to a primary contact point.
    /// See the following text for more information on primary touch points.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="TOUCHEVENTF_NOCOALESCE"/>
    /// </term>
    /// <term>
    /// 0x0020
    /// </term>
    /// <term>
    /// When received using <see cref="GetTouchInputInfo"/>, this input was not coalesced.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="TOUCHEVENTF_PEN"/>
    /// </term>
    /// <term>
    /// 0x0040
    /// </term>
    /// <term>
    /// The touch event was triggered by a stylus device.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="TOUCHEVENTF_PALM"/>
    /// </term>
    /// <term>
    /// 0x0080
    /// </term>
    /// <term>
    /// The touch event was triggered by the user's palm.
    /// </term>
    /// </item>
    /// </list>
    /// <para>
    /// Note
    /// </para>
    /// <para>
    /// If the target hardware on a machine does not support hover,
    /// when the <see cref="TOUCHEVENTF_UP"/> flag is set, the <see cref="TOUCHEVENTF_INRANGE"/> flag is cleared.
    /// If the target hardware on a machine supports hover,
    /// the <see cref="TOUCHEVENTF_UP"/> and <see cref="TOUCHEVENTF_INRANGE"/> flags will be set independently.
    /// </para>
    /// <para>
    /// The following table lists the flags for the <see cref="dwMask"/> member.
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Flag
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
    /// <see cref="TOUCHINPUTMASKF_CONTACTAREA"/>
    /// </term>
    /// <term>
    /// 0x0004
    /// </term>
    /// <term>
    /// <see cref="cxContact"/> and <see cref="cyContact"/> are valid.
    /// See the following text for more information on primary touch points.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="TOUCHINPUTMASKF_EXTRAINFO"/>
    /// </term>
    /// <term>
    /// 0x0002
    /// </term>
    /// <term>
    /// <see cref="dwExtraInfo"/> is valid.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="TOUCHINPUTMASKF_TIMEFROMSYSTEM"/>
    /// </term>
    /// <term>
    /// 0x0001
    /// </term>
    /// <term>
    /// The system time was set in the <see cref="TOUCHINPUT"/> structure.
    /// </term>
    /// </item>
    /// </list>
    /// <para>
    /// A touch point is designated as primary when it is the first touch point to be established from a previous state of no touch points.
    /// The <see cref="TOUCHEVENTF_PRIMARY"/> flag continues to be set for all subsequent events
    /// for the primary touch point until the primary touch point is released.
    /// Note that a <see cref="TOUCHEVENTF_UP"/> event on the primary touch point does not necessarily designate the end of a Windows Touch operation;
    /// the current Windows Touch operation proceeds from the establishment of the primary touch point until the last touch point is released.
    /// </para>
    /// <para>
    /// Note that a solitary touch point or, in a set of simultaneous touch points, the first to be detected, is designated the primary.
    /// The system mouse position follows the primary touch point and, in addition to touch messages,
    /// also generates <see cref="WM_LBUTTONDOWN"/>, <see cref="WM_MOUSEMOVE"/>, and <see cref="WM_LBUTTONUP"/> messages
    /// in response to actions on a primary touch point.
    /// The primary touch point can also generate <see cref="WM_RBUTTONDOWN"/> and <see cref="WM_RBUTTONUP"/> messages using the press and hold gesture.
    /// </para>
    /// <para>
    /// Note that the touch point identifier may be dynamic and is associated with a given touch point only as long as the touch point persists.
    /// If contact is broken and then resumed (for example, if a finger is removed from the surface and then pressed down again),
    /// the same touch point (the same finger, pen, or other such device) may receive a different touch point identifier.
    /// </para>
    /// <para>
    /// The following type is defined to represent a constant pointer to a <see cref="TOUCHINPUT"/> structure.
    /// </para>
    /// <code>
    /// typedef TOUCHINPUT const * PCTOUCHINPUT;
    /// </code>
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
