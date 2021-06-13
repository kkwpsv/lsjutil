using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.TouchWindowFlags;
using static Lsj.Util.Win32.Enums.WindowsMessages;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32
{
    public partial class User32
    {
        /// <summary>
        /// <para>
        /// Registers a window as being touch-capable.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-registertouchwindow"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// The handle of the window being registered.
        /// The function fails with <see cref="ERROR_ACCESS_DENIED"/> if the calling thread does not own the specified window.
        /// </param>
        /// <param name="ulFlags">
        /// A set of bit flags that specify optional modifications. This field may contain 0 or one of the following values.
        /// <see cref="TWF_FINETOUCH"/>:
        /// Specifies that <paramref name="hwnd"/> prefers noncoalesced touch input.
        /// <see cref="TWF_WANTPALM"/>:
        /// Setting this flag disables palm rejection which reduces delays for getting <see cref="WM_TOUCH"/> messages.
        /// This is useful if you want as quick of a response as possible when a user touches your application.
        /// By default, palm detection is enabled and some <see cref="WM_TOUCH"/> messages are prevented from being sent to your application.
        /// This is useful if you do not want to receive <see cref="WM_TOUCH"/> messages that are from palm contact.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, use the <see cref="GetLastError"/> function.
        /// </returns>
        /// <remarks>
        /// Note
        /// <see cref="RegisterTouchWindow"/> must be called on every window that will be used for touch input.
        /// This means that if you have an application that has multiple windows within it,
        /// <see cref="RegisterTouchWindow"/> must be called on every window in that application that uses touch features.
        /// Also, an application can call <see cref="RegisterTouchWindow"/> any number of times for the same window
        /// if it desires to change the modifier flags.
        /// A window can be marked as no longer requiring touch input using the <see cref="UnregisterTouchWindow"/> function.
        /// If <see cref="TWF_WANTPALM"/> is enabled, packets from touch input are not buffered
        /// and palm detection is not performed before the packets are sent to your application.
        /// Enabling <see cref="TWF_WANTPALM"/> is most useful if you want minimal latencies when processing <see cref="WM_TOUCH"/> messages.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegisterTouchWindow", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL RegisterTouchWindow([In] HWND hwnd, [In] TouchWindowFlags ulFlags);

        /// <summary>
        /// <para>
        /// Checks whether a specified window is touch-capable and, optionally, retrieves the modifier flags set for the window's touch capability.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-istouchwindow"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// The handle of the window.
        /// The function fails with <see cref="ERROR_ACCESS_DENIED"/> if the calling thread is not on the same desktop as the specified window.
        /// </param>
        /// <param name="pulFlags">
        /// The address of the <see cref="ULONG"/> variable to receive the modifier flags for the specified window's touch capability.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if the window supports Windows Touch;
        /// returns <see cref="FALSE"/> if the window does not support Windows Touch.
        /// </returns>
        /// <remarks>
        /// The following table lists the values for the <paramref name="pulFlags"/> output parameter.
        /// <see cref="TWF_FINETOUCH"/>: Specifies that <paramref name="hwnd"/> prefers noncoalesced touch input.
        /// <see cref="TWF_WANTPALM"/>:
        /// Clearing this flag disables palm rejection which reduces delays for getting <see cref="WM_TOUCH"/> messages.
        /// This is useful if you want as quick of a response as possible when a user touches your application
        /// Setting this flag enables palm detection and will prevent some <see cref="WM_TOUCH"/> messages from being sent to your application.
        /// This is useful if you do not want to receive <see cref="WM_TOUCH"/> messages that are from palm contact.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsTouchWindow", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsTouchWindow([In] HWND hwnd, [Out] out TouchWindowFlags pulFlags);

        /// <summary>
        /// <para>
        /// Registers a window as no longer being touch-capable.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-unregistertouchwindow"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// The handle of the window.
        /// The function fails with <see cref="ERROR_ACCESS_DENIED"/> if the calling thread does not own the specified window.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, use the <see cref="GetLastError"/> function.
        /// </returns>
        /// <remarks>
        /// The <see cref="UnregisterTouchWindow"/> function succeeds
        /// even if the specified window was not previously registered as being touch-capable.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "UnregisterTouchWindow", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL UnregisterTouchWindow([In] HWND hwnd);
    }
}
