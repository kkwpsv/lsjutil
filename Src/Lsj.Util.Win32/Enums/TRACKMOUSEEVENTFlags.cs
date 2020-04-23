using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.WindowsMessages;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="TRACKMOUSEEVENT"/> Flags
    /// </summary>
    public enum TRACKMOUSEEVENTFlags : uint
    {
        /// <summary>
        /// The caller wants to cancel a prior tracking request.
        /// The caller should also specify the type of tracking that it wants to cancel.
        /// For example, to cancel hover tracking, the caller must pass the <see cref="TME_CANCEL"/> and <see cref="TME_HOVER"/> flags.
        /// </summary>
        TME_CANCEL = 0x80000000,

        /// <summary>
        /// The caller wants hover notification. Notification is delivered as a <see cref="WM_MOUSEHOVER"/> message.
        /// If the caller requests hover tracking while hover tracking is already active, the hover timer will be reset.
        /// This flag is ignored if the mouse pointer is not over the specified window or area.
        /// </summary>
        TME_HOVER = 0x00000001,

        /// <summary>
        /// The caller wants leave notification. Notification is delivered as a <see cref="WM_MOUSELEAVE"/> message.
        /// If the mouse is not over the specified window or area, a leave notification is generated immediately and no further tracking is performed.
        /// </summary>
        TME_LEAVE = 0x00000002,

        /// <summary>
        /// The caller wants hover and leave notification for the nonclient areas.
        /// Notification is delivered as <see cref="WM_NCMOUSEHOVER"/> and <see cref="WM_NCMOUSELEAVE"/> messages.
        /// </summary>
        TME_NONCLIENT = 0x00000010,

        /// <summary>
        /// The function fills in the structure instead of treating it as a tracking request.
        /// The structure is filled such that had that structure been passed to <see cref="TrackMouseEvent"/>, it would generate the current tracking.
        /// The only anomaly is that the hover time-out returned is always the actual time-out and not <see cref="HOVER_DEFAULT"/>,
        /// if <see cref="HOVER_DEFAULT"/> was specified during the original <see cref="TrackMouseEvent"/> request.
        /// </summary>
        TME_QUERY = 0x40000000,
    }
}
