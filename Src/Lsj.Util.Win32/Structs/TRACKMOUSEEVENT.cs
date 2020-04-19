using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.SystemParametersInfoParameters;
using static Lsj.Util.Win32.Enums.TRACKMOUSEEVENTFlags;
using static Lsj.Util.Win32.Enums.WindowsMessages;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Used by the <see cref="TrackMouseEvent"/> function to track when the mouse pointer
    /// leaves a window or hovers over a window for a specified amount of time.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-trackmouseevent
    /// </para>
    /// </summary>
    /// <remarks>
    /// The system default hover time-out is initially the menu drop-down time, which is 400 milliseconds.
    /// You can call <see cref="SystemParametersInfo"/> and use <see cref="SPI_GETMOUSEHOVERTIME"/> to retrieve the default hover time-out.
    /// The system default hover rectangle is the same as the double-click rectangle.
    /// You can call <see cref="SystemParametersInfo"/> and use <see cref="SPI_GETMOUSEHOVERWIDTH"/> and <see cref="SPI_GETMOUSEHOVERHEIGHT"/>
    /// to retrieve the size of the rectangle within which the mouse pointer has to stay for <see cref="TrackMouseEvent"/>
    /// to generate a <see cref="WM_MOUSEHOVER"/> message.
    /// </remarks>
    [StructLayout(LayoutKind.Auto, CharSet = CharSet.Unicode)]
    public struct TRACKMOUSEEVENT
    {
        /// <summary>
        /// The size of the <see cref="TRACKMOUSEEVENT"/> structure, in bytes.
        /// </summary>
        public DWORD cbSize;

        /// <summary>
        /// The services requested. This member can be a combination of the following values.
        /// <see cref="TME_CANCEL"/>, <see cref="TME_HOVER"/>, <see cref="TME_LEAVE"/>, <see cref="TME_NONCLIENT"/>, <see cref="TME_QUERY"/>
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
