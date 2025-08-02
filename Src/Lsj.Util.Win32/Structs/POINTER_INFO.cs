using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.POINTER_INPUT_TYPE;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains basic pointer information common to all pointer types.
    /// Applications can retrieve this information using the <see cref="GetPointerInfo"/>, <see cref="GetPointerFrameInfo"/>,
    /// <see cref="GetPointerInfoHistory"/> and <see cref="GetPointerFrameInfoHistory"/> functions.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-pointer_info"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct POINTER_INFO
    {
        /// <summary>
        /// A value from the <see cref="POINTER_INPUT_TYPE"/> enumeration that specifies the pointer type.
        /// </summary>
        public POINTER_INPUT_TYPE pointerType;

        /// <summary>
        /// An identifier that uniquely identifies a pointer during its lifetime.
        /// A pointer comes into existence when it is first detected and ends its existence when it goes out of detection range.
        /// Note that if a physical entity (finger or pen) goes out of detection range and then returns to be detected again,
        /// it is treated as a new pointer and may be assigned a new pointer identifier.
        /// </summary>
        public UINT32 pointerId;

        /// <summary>
        /// <para>
        /// An identifier common to multiple pointers for which the source device reported an update in a single input frame.
        /// For example, a parallel-mode multi-touch digitizer may report the positions of multiple touch contacts in a single update to the system.
        /// </para>
        /// <para>
        /// Note that frame identifier is assigned as input is reported to the system for all pointers across all devices.
        /// Therefore, this field may not contain strictly sequential values in a single series of messages that a window receives.
        /// However, this field will contain the same numerical value for all input updates that were reported in the same input frame by a single device.
        /// </para>
        /// </summary>
        public UINT32 frameId;

        /// <summary>
        /// May be any reasonable combination of flags from the Pointer Flags constants.
        /// </summary>
        public POINTER_FLAGS pointerFlags;

        /// <summary>
        /// Handle to the source device that can be used in calls to the raw input device API and the digitizer device API.
        /// </summary>
        public HANDLE sourceDevice;

        /// <summary>
        /// Window to which this message was targeted.
        /// If the pointer is captured, either implicitly by virtue of having made contact over this window
        /// or explicitly using the pointer capture API, this is the capture window.
        /// If the pointer is uncaptured, this is the window over which the pointer was when this message was generated.
        /// </summary>
        public HWND hwndTarget;

        /// <summary>
        /// <para>
        /// The predicted screen coordinates of the pointer, in pixels.
        /// </para>
        /// <para>
        /// The predicted value is based on the pointer position reported by the digitizer and the motion of the pointer.
        /// This correction can compensate for visual lag due to inherent delays in sensing and processing the pointer location on the digitizer.
        /// This is applicable to pointers of type <see cref="PT_TOUCH"/>.
        /// For other pointer types, the predicted value will be the same as the non-predicted value (see <see cref="ptPixelLocationRaw"/>).
        /// </para>
        /// </summary>
        public POINT ptPixelLocation;

        /// <summary>
        /// <para>
        /// The predicted screen coordinates of the pointer, in HIMETRIC units.
        /// </para>
        /// <para>
        /// The predicted value is based on the pointer position reported by the digitizer and the motion of the pointer.
        /// This correction can compensate for visual lag due to inherent delays in sensing and processing the pointer location on the digitizer.
        /// This is applicable to pointers of type <see cref="PT_TOUCH"/>.
        /// For other pointer types, the predicted value will be the same as the non-predicted value (see <see cref="ptHimetricLocationRaw"/>).
        /// </para>
        /// </summary>
        public POINT ptHimetricLocation;

        /// <summary>
        /// The screen coordinates of the pointer, in pixels.
        /// For adjusted screen coordinates, see <see cref="ptPixelLocation"/>.
        /// </summary>
        public POINT ptPixelLocationRaw;

        /// <summary>
        /// The screen coordinates of the pointer, in HIMETRIC units.
        /// For adjusted screen coordinates, see <see cref="ptHimetricLocation"/>.
        /// </summary>
        public POINT ptHimetricLocationRaw;

        /// <summary>
        /// <para>
        /// 0 or the time stamp of the message, based on the system tick count when the message was received.
        /// </para>
        /// <para>
        /// The application can specify the input time stamp in either <see cref="dwTime"/> or <see cref="PerformanceCount"/>.
        /// The value cannot be more recent than the current tick count
        /// or QueryPerformanceCount (QPC) value of the injection thread.
        /// Once a frame is injected with a time stamp,
        /// all subsequent frames must include a timestamp until all contacts in the frame go to an UP state.
        /// The custom timestamp value must also be provided for the first element in the contacts array.
        /// The time stamp values after the first element are ignored.
        /// The custom timestamp value must increment in every injection frame.
        /// </para>
        /// <para>
        /// When <see cref="PerformanceCount"/> is specified, the time stamp will be converted
        /// to the current time in .1 millisecond resolution upon actual injection.
        /// If a custom <see cref="PerformanceCount"/> resulted in the same .1 millisecond window from the previous injection,
        /// <see cref="ERROR_NOT_READY"/> is returned and injection will not occur.
        /// While injection will not be invalidated immediately by the error,
        /// the next successful injection must have a <see cref="PerformanceCount"/> value
        /// that is at least 0.1 millisecond from the previously successful injection.
        /// This is also true if <see cref="dwTime"/> is used.
        /// </para>
        /// <para>
        /// If both <see cref="dwTime"/> and <see cref="PerformanceCount"/> are specified in <see cref="InjectTouchInput"/>,
        /// <see cref="ERROR_INVALID_PARAMETER"/> is returned.
        /// </para>
        /// <para>
        /// <see cref="InjectTouchInput"/> cannot switch between <see cref="dwTime"/> and <see cref="PerformanceCount"/> once injection has started.
        /// </para>
        /// <para>
        /// If neither <see cref="dwTime"/> and <see cref="PerformanceCount"/> are specified,
        /// <see cref="InjectTouchInput"/> allocates the timestamp based on the timing of the call.
        /// If <see cref="InjectTouchInput"/> calls are repeatedly less than 0.1 millisecond apart,
        /// <see cref="ERROR_NOT_READY"/> might be returned. The error will not invalidate the input immediately,
        /// but the injection application needs to retry the same frame again for injection to succeed.
        /// </para>
        /// </summary>
        public DWORD dwTime;

        /// <summary>
        /// Count of inputs that were coalesced into this message.
        /// This count matches the total count of entries that can be returned by a call to <see cref="GetPointerInfoHistory"/>.
        /// If no coalescing occurred, this count is 1 for the single input represented by the message.
        /// </summary>
        public UINT32 historyCount;

        /// <summary>
        /// 
        /// </summary>
        public INT32 InputData;

        /// <summary>
        /// <para>
        /// Indicates which keyboard modifier keys were pressed at the time the input was generated.
        /// May be zero, or a combination of the following values from Modifier Key State.
        /// </para>
        /// <para>
        /// <see cref="POINTER_MOD_SHIFT"/> – A SHIFT key was pressed.
        /// </para>
        /// <para>
        /// <see cref="POINTER_MOD_CTRL"/> – A CTRL key was pressed.
        /// </para>
        /// <para>
        /// Use <see cref="GetKeyState"/>.
        /// </para>
        /// </summary>
        public DWORD dwKeyStates;

        /// <summary>
        /// The value of the high-resolution performance counter when the pointer message was received
        /// (high-precision, 64 bit alternative to <see cref="dwTime"/>).
        /// The value can be calibrated when the touch digitizer hardware supports the scan timestamp information in its input report.
        /// </summary>
        public UINT64 PerformanceCount;

        /// <summary>
        /// A value from the <see cref="POINTER_BUTTON_CHANGE_TYPE"/> enumeration
        /// that specifies the change in button state between this input and the previous input.
        /// </summary>
        public POINTER_BUTTON_CHANGE_TYPE ButtonChangeType;
    }
}
