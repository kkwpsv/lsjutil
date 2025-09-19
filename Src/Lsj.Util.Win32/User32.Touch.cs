using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.TouchWindowFlags;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32
{
    public partial class User32
    {
        /// <summary>
        /// <para>
        /// Closes resources associated with a gesture information handle.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-closegestureinfohandle"/>
        /// </para>
        /// </summary>
        /// <param name="hGestureInfo">
        /// The gesture information handle.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// To get extended error information, use the <see cref="GetLastError"/> function.
        /// </returns>
        /// <remarks>
        /// If an application processes a <see cref="WM_GESTURE"/> message, it is responsible for closing the handle using this function.
        /// Failure to do so may result in process memory leaks.
        /// If the message is passed to <see cref="DefWindowProc"/>, or is forwarded
        /// using one of the <see cref="PostMessage"/> or <see cref="SendMessage"/> classes of API functions,
        /// the handle is transferred with the message and need not be closed by the application.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseGestureInfoHandle", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CloseGestureInfoHandle([In] HGESTUREINFO hGestureInfo);

        /// <summary>
        /// <para>
        /// Closes a touch input handle, frees process memory associated with it, and invalidates the handle.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-closetouchinputhandle"/>
        /// </para>
        /// </summary>
        /// <param name="hTouchInput">
        /// The touch input handle received in the <see cref="LPARAM"/> of a touch message.
        /// The function fails with <see cref="ERROR_INVALID_HANDLE"/> if this handle is not valid.
        /// Note that the handle is not valid after it has been used in a successful call to <see cref="CloseTouchInputHandle"/>
        /// or after it has been passed to <see cref="DefWindowProc"/>, <see cref="PostMessage"/>, <see cref="SendMessage"/> or one of their variants.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// To get extended error information, use the <see cref="GetLastError"/> function.
        /// </returns>
        /// <remarks>
        /// Calling <see cref="CloseTouchInputHandle"/> will not free memory associated with values retrieved in a call to <see cref="GetTouchInputInfo"/>.
        /// Values in structures passed to <see cref="GetTouchInputInfo"/> will be valid until you delete them.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseTouchInputHandle", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CloseTouchInputHandle([In] HTOUCHINPUT hTouchInput);

        /// <summary>
        /// <para>
        /// Retrieves the configuration for which Windows Touch gesture messages are sent from a window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getgestureconfig"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window to get the gesture configuration from.
        /// </param>
        /// <param name="dwReserved">
        /// This value is reserved and must be set to 0.
        /// </param>
        /// <param name="dwFlags">
        /// A gesture command flag value indicating options for retrieving the gesture configuration.
        /// See Remarks for additional information and supported values.
        /// </param>
        /// <param name="pcIDs">
        /// The size, in number of gesture configuration structures, that is in the <paramref name="pGestureConfig"/> buffer.
        /// </param>
        /// <param name="pGestureConfig">
        /// An array of gesture configuration structures that specify the gesture configuration.
        /// </param>
        /// <param name="cbSize">
        /// The size of the gesture configuration (<see cref="GESTURECONFIG"/>) structure.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// To get extended error information, use the <see cref="GetLastError"/> function.
        /// </returns>
        /// <remarks>
        /// Passing a value other than <code>sizeof(GESTURECONFIG)</code> for the <paramref name="cbSize"/> parameter
        /// will cause calls to this function to fail and <see cref="GetLastError"/> will return <see cref="ERROR_INVALID_PARAMETER"/> (87 in decimal).
        /// The following table lists the gesture configuration values:
        /// <see cref="GCF_INCLUDE_ANCESTORS"/>
        /// 0x00000001
        /// If specified, <see cref="GetGestureConfig"/> returns consolidated configuration for the specified window and its parent window chain.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetGestureConfig", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetGestureConfig([In] HWND hwnd, [In] DWORD dwReserved, [In] DWORD dwFlags, [In] in UINT pcIDs,
            [In][Out] GESTURECONFIG[] pGestureConfig, [In] UINT cbSize);

        /// <summary>
        /// <para>
        /// Retrieves additional information about a gesture from its <see cref="GESTUREINFO"/> handle.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getgestureextraargs"/>
        /// </para>
        /// </summary>
        /// <param name="hGestureInfo">
        /// The handle to the gesture information that is passed in the lParam of a <see cref="WM_GESTURE"/> message.
        /// </param>
        /// <param name="cbExtraArgs">
        /// A count of the bytes of data stored in the extra arguments.
        /// </param>
        /// <param name="pExtraArgs">
        /// A pointer to the extra argument information.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// To get extended error information, use the <see cref="GetLastError"/> function.
        /// </returns>
        /// <remarks>
        /// This function is reserved for future use and should only be used for testing.
        /// Windows 7 gestures do not use extra arguments.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetGestureExtraArgs", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetGestureExtraArgs([In] HGESTUREINFO hGestureInfo, [In] UINT cbExtraArgs, [In] IntPtr pExtraArgs);

        /// <summary>
        /// <para>
        /// Retrieves a <see cref="GESTUREINFO"/> structure given a handle to the gesture information.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getgestureinfo"/>
        /// </para>
        /// </summary>
        /// <param name="hGestureInfo">
        /// The gesture information handle.
        /// </param>
        /// <param name="pGestureInfo">
        /// A pointer to the gesture information structure.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// To get extended error information, use the <see cref="GetLastError"/> function.
        /// </returns>
        /// <remarks>
        /// The cbSize member of the <see cref="GESTUREINFO"/> structure passed in to the function must be set before the function is called.
        /// Otherwise, calls to <see cref="GetLastError"/> will return <see cref="ERROR_INVALID_PARAMETER"/> (87 in decimal).
        /// If an application processes a <see cref="WM_GESTURE"/> message, it is responsible for closing the handle using <see cref="CloseGestureInfoHandle"/>.
        /// Failure to do so may result in process memory leaks.
        /// If the message is passed to <see cref="DefWindowProc"/>,
        /// or is forwarded using one of the <see cref="PostMessage"/> or <see cref="SendMessage"/> classes of API functions,
        /// the handle is transferred with the message and need not be closed by the application.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetGestureInfo", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetGestureInfo([In] HGESTUREINFO hGestureInfo, [Out] out GESTUREINFO pGestureInfo);

        /// <summary>
        /// <para>
        /// Retrieves detailed information about touch inputs associated with a particular touch input handle.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-gettouchinputinfo"/>
        /// </para>
        /// </summary>
        /// <param name="hTouchInput">
        /// The touch input handle received in the <see cref="LPARAM"/> of a touch message.
        /// The function fails with <see cref="ERROR_INVALID_HANDLE"/> if this handle is not valid.
        /// Note that the handle is not valid after it has been used in a successful call to <see cref="CloseTouchInputHandle"/>
        /// or after it has been passed to <see cref="DefWindowProc"/>, <see cref="PostMessage"/>, <see cref="SendMessage"/> or one of their variants.
        /// </param>
        /// <param name="cInputs">
        /// The number of structures in the <paramref name="pInputs"/> array.
        /// This should ideally be at least equal to the number of touch points associated with the message as indicated in the message <see cref="WPARAM"/>.
        /// If <paramref name="cInputs"/> is less than the number of touch points, the function will still succeed
        /// and populate the <paramref name="pInputs"/> buffer with information about <paramref name="cInputs"/> touch points.
        /// </param>
        /// <param name="pInputs">
        /// A pointer to an array of <see cref="TOUCHINPUT"/> structures to receive information about the touch points associated with the specified touch input handle.
        /// </param>
        /// <param name="cbSize">
        /// The size, in bytes, of a single <see cref="TOUCHINPUT"/> structure.
        /// If <paramref name="cbSize"/> is not the size of a single <see cref="TOUCHINPUT"/> structure,
        /// the function fails with <see cref="ERROR_INVALID_PARAMETER"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// To get extended error information, use the <see cref="GetLastError"/> function.
        /// </returns>
        /// <remarks>
        /// Calling <see cref="CloseTouchInputHandle"/> will not free memory associated with values retrieved in a call to <see cref="GetTouchInputInfo"/>.
        /// Values in structures passed to <see cref="GetTouchInputInfo"/> will be valid until you delete them.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTouchInputInfo", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetTouchInputInfo([In] HTOUCHINPUT hTouchInput, [In] UINT cInputs, [Out] TOUCHINPUT[] pInputs, [In] int cbSize);

        /// <summary>
        /// <para>
        /// Checks whether a specified window is touch-capable and, optionally, retrieves the modifier flags set for the window's touch capability.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-istouchwindow"/>
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
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsTouchWindow", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsTouchWindow([In] HWND hwnd, [Out] out TouchWindowFlags pulFlags);

        /// <summary>
        /// <para>
        /// Registers a window as being touch-capable.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-registertouchwindow"/>
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
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegisterTouchWindow", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL RegisterTouchWindow([In] HWND hwnd, [In] TouchWindowFlags ulFlags);

        /// <summary>
        /// <para>
        /// Configures the messages that are sent from a window for Windows Touch gestures.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setgestureconfig"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window to set the gesture configuration on.
        /// </param>
        /// <param name="dwReserved">
        /// This value is reserved and must be set to 0.
        /// </param>
        /// <param name="cIDs">
        /// A count of the gesture configuration structures that are being passed.
        /// </param>
        /// <param name="pGestureConfig">
        /// An array of gesture configuration structures that specify the gesture configuration.
        /// </param>
        /// <param name="cbSize">
        /// The size of the gesture configuration (<see cref="GESTURECONFIG"/>) structure.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// To get extended error information, use the <see cref="GetLastError"/> function.
        /// </returns>
        /// <remarks>
        /// If you don't expect to change the gesture configuration, call <see cref="SetGestureConfig"/> at window creation time.
        /// If you want to dynamically change the gesture configuration, call <see cref="SetGestureConfig"/> in response to <see cref="WM_GESTURENOTIFY"/> messages.
        /// The following table shows the identifiers for gestures that are supported by the <see cref="GESTURECONFIG.dwID"/> member of the <see cref="GESTURECONFIG"/> structure.
        /// Note that setting <see cref="GESTURECONFIG.dwID"/> to 0 indicates that global gesture configuration flags are set.
        /// <see cref="GID_ZOOM"/>: Configuration settings for the zoom gesture.
        /// <see cref="GID_PAN"/>: The pan gesture.
        /// <see cref="GID_ROTATE"/>: The rotation gesture.
        /// <see cref="GID_TWOFINGERTAP"/>: The two-finger tap gesture.
        /// <see cref="GID_PRESSANDTAP"/>: The press and tap gesture.
        /// The following flags are used when <see cref="GESTURECONFIG.dwID"/> is set to zero.
        /// <see cref="GC_ALLGESTURES"/>: All of the gestures.
        /// The following flags are used when <see cref="GESTURECONFIG.dwID"/> is set to <see cref="GID_ZOOM"/>.
        /// <see cref="GC_ZOOM"/>: The zoom gesture.
        /// The following flags are used when <see cref="GESTURECONFIG.dwID"/> is set to <see cref="GID_PAN"/>.
        /// <see cref="GC_PAN"/>: All pan gestures.
        /// <see cref="GC_PAN_WITH_SINGLE_FINGER_VERTICALLY"/>:
        /// Vertical pans with one finger.
        /// <see cref="GC_PAN_WITH_SINGLE_FINGER_HORIZONTALLY"/>:
        /// Horizontal pans with one finger.
        /// <see cref="GC_PAN_WITH_GUTTER"/>:
        /// Panning with a gutter boundary around the edges of pannable region.
        /// The gutter boundary limits perpendicular movement to a primary direction until a threshold is reached to break out of the gutter.
        /// <see cref="GC_PAN_WITH_INTERTIA"/>:
        /// Panning with inertia to smoothly slow when pan gestures stop.
        /// Note
        /// Pan gestures can be used in conjunction with each other to control behavior.
        /// For example, setting the <see cref="GESTURECONFIG.dwWant"/> bits to panning with single-finger horizontal 
        /// and setting the <see cref="GESTURECONFIG.dwBlock"/> bits to single-finger vertical will restrict panning to horizontal pans.
        /// Changing the <see cref="GESTURECONFIG.dwWant"/> bit to have <see cref="GC_PAN_WITH_SINGLE_FINGER_VERTICALLY"/> | <see cref="GC_PAN_WITH_SINGLE_FINGER_HORIZONTALLY"/>
        /// and removing single-finger vertical pan from the <see cref="GESTURECONFIG.dwBlock"/> bit will enable both vertical and horizontal panning.
        /// Note
        /// By default, panning has inertia enabled.
        /// Note
        /// A single call to <see cref="SetGestureConfig"/> cannot include other GIDs along with 0.
        /// The following flags are used when <see cref="GESTURECONFIG.dwID"/> is set to <see cref="GID_ROTATE"/>.
        /// <see cref="GC_ROTATE"/>: The rotation gesture.
        /// The following flags are used when <see cref="GESTURECONFIG.dwID"/> is set to <see cref="GID_TWOFINGERTAP"/>.
        /// <see cref="GC_TWOFINGERTAP"/>: The two-finger tap gesture.
        /// The following flags are used when <see cref="GESTURECONFIG.dwID"/> is set to <see cref="GID_PRESSANDTAP"/>.
        /// <see cref="GC_PRESSANDTAP"/>: The press and tap gesture.
        /// Note
        /// Calling <see cref="SetGestureConfig"/> will change the gesture configuration for the lifetime of the Window, not just for the next gesture.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetGestureConfig", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetGestureConfig([In] HWND hwnd, [In] DWORD dwReserved, [In] UINT cIDs, [In] GESTURECONFIG[] pGestureConfig, [In] UINT cbSize);

        /// <summary>
        /// <para>
        /// Registers a window as no longer being touch-capable.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-unregistertouchwindow"/>
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
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "UnregisterTouchWindow", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL UnregisterTouchWindow([In] HWND hwnd);
    }
}
