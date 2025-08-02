using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.SystemParametersInfoParameters;
using static Lsj.Util.Win32.Enums.TRACKMOUSEEVENTFlags;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Used by the <see cref="TrackMouseEvent"/> function to track when the mouse pointer
    /// leaves a window or hovers over a window for a specified amount of time.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-trackmouseevent"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The system default hover time-out is initially the menu drop-down time, which is 400 milliseconds.
    /// You can call <see cref="SystemParametersInfo"/> and use <see cref="SPI_GETMOUSEHOVERTIME"/> to retrieve the default hover time-out.
    /// </para>
    /// <para>
    /// The system default hover rectangle is the same as the double-click rectangle.
    /// You can call <see cref="SystemParametersInfo"/> and use <see cref="SPI_GETMOUSEHOVERWIDTH"/>
    /// > and <see cref="SPI_GETMOUSEHOVERHEIGHT"/> to retrieve the size of the rectangle
    /// within which the mouse pointer has to stay for <see cref="TrackMouseEvent"/> to generate a <see cref="WM_MOUSEHOVER"/> message.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct TRACKMOUSEEVENT
    {
        /// <summary>
        /// The size of the <see cref="TRACKMOUSEEVENT"/> structure, in bytes.
        /// </summary>
        public DWORD cbSize;

        /// <summary>
        /// <para>
        /// The services requested. This member can be a combination of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TME_CANCEL"/>
        /// </para>
        /// <para>
        /// 0x80000000
        /// </para>
        /// </term>
        /// <term>
        /// The caller wants to cancel a prior tracking request.
        /// The caller should also specify the type of tracking that it wants to cancel.
        /// For example, to cancel hover tracking, the caller must pass the <see cref="TME_CANCEL"/> and <see cref="TME_HOVER"/> flags.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TME_HOVER"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The caller wants hover notification. Notification is delivered as a <see cref="WM_MOUSEHOVER"/> message.
        /// </para>
        /// <para>
        /// If the caller requests hover tracking while hover tracking is already active, the hover timer will be reset.
        /// </para>
        /// <para>
        /// This flag is ignored if the mouse pointer is not over the specified window or area.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TME_LEAVE"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// The caller wants leave notification.
        /// Notification is delivered as a <see cref="WM_MOUSELEAVE"/> message.
        /// If the mouse is not over the specified window or area, a leave notification is generated immediately and no further tracking is performed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TME_NONCLIENT"/>
        /// </para>
        /// <para>
        /// 0x00000010
        /// </para>
        /// </term>
        /// <term>
        /// The caller wants hover and leave notification for the nonclient areas.
        /// Notification is delivered as <see cref="WM_NCMOUSEHOVER"/> and <see cref="WM_NCMOUSELEAVE"/> messages.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TME_QUERY"/>
        /// </para>
        /// <para>
        /// 0x40000000
        /// </para>
        /// </term>
        /// <term>
        /// The function fills in the structure instead of treating it as a tracking request.
        /// The structure is filled such that had that structure been passed to <see cref="TrackMouseEvent"/>, it would generate the current tracking.
        /// The only anomaly is that the hover time-out returned is always the actual time-out and not <see cref="HOVER_DEFAULT"/>,
        /// if <see cref="HOVER_DEFAULT"/> was specified during the original <see cref="TrackMouseEvent"/> request.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public TRACKMOUSEEVENTFlags dwFlags;

        /// <summary>
        /// A handle to the window to track.
        /// </summary>
        public HWND hwndTrack;

        /// <summary>
        /// The hover time-out (if <see cref="TME_HOVER"/> was specified in <see cref="dwFlags"/>), in milliseconds.
        /// Can be <see cref="HOVER_DEFAULT"/>, which means to use the system default hover time-out.
        /// </summary>
        public DWORD dwHoverTime;
    }
}
