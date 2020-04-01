using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.PeekMessageFlags;
using static Lsj.Util.Win32.Enums.WindowsMessages;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32
{
    public static partial class User32
    {
        /// <summary>
        /// <para>
        /// The message is posted to all top-level windows in the system, including disabled or invisible unowned windows,
        /// overlapped windows, and pop-up windows. The message is not posted to child windows.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-postmessagew
        /// </para>
        /// </summary>
        public static readonly IntPtr HWND_BROADCAST = new IntPtr(0xFFFF);

        /// <summary>
        /// <para>
        /// Dispatches a message to a window procedure.
        /// It is typically used to dispatch a message retrieved by the <see cref="GetMessage"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-dispatchmessagew
        /// </para>
        /// </summary>
        /// <param name="lpmsg">The message.</param>
        /// <returns>
        /// The return value specifies the value returned by the window procedure.
        /// Although its meaning depends on the message being dispatched, the return value generally is ignored.
        /// </returns>
        /// <remarks>
        /// The <see cref="MSG"/> structure must contain valid message values.
        /// If the <paramref name="lpmsg"/> parameter points to a <see cref="WM_TIMER"/> message
        /// and the <see cref="MSG.lParam"/> parameter of the <see cref="WM_TIMER"/> message is not <see cref="NULL"/>,
        /// <see cref="MSG.lParam"/> points to a function that is called instead of the window procedure.
        /// Note that the application is responsible for retrieving and dispatching input messages to the dialog box.
        /// Most applications use the main message loop for this.
        /// However, to permit the user to move to and to select controls by using the keyboard, the application must call <see cref="IsDialogMessage"/>.
        /// For more information, see Dialog Box Keyboard Interface.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DispatchMessageW", SetLastError = true)]
        public static extern LRESULT DispatchMessage([MarshalAs(UnmanagedType.LPStruct)][In]MSG lpmsg);

        /// <summary>
        /// <para>
        /// Determines whether there are mouse-button or keyboard messages in the calling thread's message queue.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getinputstate
        /// </para>
        /// </summary>
        /// <returns>
        /// If the queue contains one or more new mouse-button or keyboard messages, the return value is <see cref="TRUE"/>.
        /// If there are no new mouse-button or keyboard messages in the queue, the return value is <see cref="FALSE"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetInputState", SetLastError = true)]
        public static extern BOOL GetInputState();

        /// <summary>
        /// <para>
        /// Retrieves a message from the calling thread's message queue.
        /// The function dispatches incoming sent messages until a posted message is available for retrieval.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getmessage
        /// </para>
        /// </summary>
        /// <param name="lpMsg">A <see cref="MSG"/> structure that receives message information from the thread's message queue.</param>
        /// <param name="hWnd">
        /// A handle to the window whose messages are to be retrieved. The window must belong to the current thread.
        /// If <paramref name="hWnd"/> is <see cref="IntPtr.Zero"/>, <see cref="GetMessage"/> retrieves messages for any window that belongs to 
        /// the current thread, and any messages on the current thread's message queue whose <see cref="MSG.hwnd"/> value is <see cref="IntPtr.Zero"/>
        /// (see the <see cref="MSG"/> structure).
        /// Therefore if <paramref name="hWnd"/> is <see cref="IntPtr.Zero"/>, both window messages and thread messages are processed.
        /// If <paramref name="hWnd"/> is -1, GetMessage retrieves only messages on the current thread's message queue
        /// whose hwnd value is <see cref="IntPtr.Zero"/>, that is, thread messages as posted by <see cref="PostMessage"/> 
        /// (when the <paramref name="hWnd"/> parameter is <see cref="IntPtr.Zero"/>) or <see cref="PostThreadMessage"/>.
        /// </param>
        /// <param name="wMsgFilterMin">
        /// The integer value of the lowest message value to be retrieved. 
        /// Use <see cref="WM_KEYFIRST"/> (0x0100) to specify the first keyboard message
        /// or <see cref="WM_MOUSEFIRST"/> (0x0200) to specify the first mouse message.
        /// Use <see cref="WM_INPUT"/> here and in <paramref name="wMsgFilterMax"/>
        /// to specify only the <see cref="WM_INPUT"/> messages.
        /// If <paramref name="wMsgFilterMin"/> and <paramref name="wMsgFilterMax"/> are both zero,
        /// <see cref="GetMessage"/> returns all available messages (that is, no range filtering is performed).
        /// </param>
        /// <param name="wMsgFilterMax">
        /// The integer value of the highest message value to be retrieved.
        /// Use <see cref="WM_KEYLAST"/> to specify the last keyboard message 
        /// or <see cref="WM_MOUSELAST"/> to specify the last mouse message.
        /// Use <see cref="WM_INPUT"/> here and in wMsgFilterMin to specify only the <see cref="WM_INPUT"/> messages.
        /// If <paramref name="wMsgFilterMin"/> and <paramref name="wMsgFilterMax"/> are both zero,
        /// <see cref="GetMessage"/> returns all available messages (that is, no range filtering is performed).
        /// </param>
        /// <returns>
        /// If the function retrieves a message other than <see cref="WM_QUIT"/>, the return value is nonzero.
        /// If the function retrieves the <see cref="WM_QUIT"/> message, the return value is zero.
        /// If there is an error, the return value is -1. 
        /// For example, the function fails if <paramref name="hWnd"/> is an invalid window handle or <paramref name="lpMsg"/> is an invalid pointer. 
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMessageW", SetLastError = true)]
        public static extern BOOL GetMessage([Out]out MSG lpMsg, [In]HWND hWnd, [In]UINT wMsgFilterMin, [In]UINT wMsgFilterMax);

        /// <summary>
        /// <para>
        /// Retrieves the extra message information for the current thread.
        /// Extra message information is an application- or driver-defined value associated with the current thread's message queue.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getmessageextrainfo
        /// </para>
        /// </summary>
        /// <returns>
        /// The return value specifies the extra information.
        /// The meaning of the extra information is device specific.
        /// </returns>
        /// <remarks>
        /// To set a thread's extra message information, use the <see cref="SetMessageExtraInfo"/> function.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMessageExtraInfo", SetLastError = true)]
        public static extern LPARAM GetMessageExtraInfo();

        /// <summary>
        /// <para>
        /// Retrieves the cursor position for the last message retrieved by the <see cref="GetMessage"/> function.
        /// To determine the current position of the cursor, use the <see cref="GetCursorPos"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getmessagepos
        /// </para>
        /// </summary>
        /// <returns>
        /// The return value specifies the x- and y-coordinates of the cursor position.
        /// The x-coordinate is the low order short and the y-coordinate is the high-order short.
        /// </returns>
        /// <remarks>
        /// As noted above, the x-coordinate is in the low-order short of the return value;
        /// the y-coordinate is in the high-order short (both represent signed values because they can take negative values on systems with multiple monitors).
        /// If the return value is assigned to a variable, you can use the <see cref="MAKEPOINTS"/> macro
        /// to obtain a <see cref="POINTS"/> structure from the return value.
        /// You can also use the <see cref="GET_X_LPARAM"/> or <see cref="GET_Y_LPARAM"/> macro to extract the x- or y-coordinate.
        /// Important Do not use the <see cref="LOWORD"/> or <see cref="HIWORD"/> macros to extract the x- and y- coordinates of the cursor position
        /// because these macros return incorrect results on systems with multiple monitors.
        /// Systems with multiple monitors can have negative x- and y- coordinates,
        /// and <see cref="LOWORD"/> and <see cref="HIWORD"/> treat the coordinates as unsigned quantities.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMessagePos", SetLastError = true)]
        public static extern DWORD GetMessagePos();

        /// <summary>
        /// <para>
        /// Retrieves the message time for the last message retrieved by the <see cref="GetMessage"/> function.
        /// The time is a long integer that specifies the elapsed time, in milliseconds,
        /// from the time the system was started to the time the message was created (that is, placed in the thread's message queue).
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getmessagetime
        /// </para>
        /// </summary>
        /// <returns>
        /// The return value specifies the message time.
        /// </returns>
        /// <remarks>
        /// The return value from the <see cref="GetMessageTime"/> function does not necessarily increase between subsequent messages,
        /// because the value wraps to the minimum value for a long integer if the timer count exceeds the maximum value for a long integer.
        /// To calculate time delays between messages, subtract the time of the first message from the time of the second message (ignoring overflow)
        /// and compare the result of the subtraction against the desired delay amount.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMessageTime", SetLastError = true)]
        public static extern LONG GetMessageTime();

        /// <summary>
        /// <para>
        /// Dispatches incoming sent messages, checks the thread message queue for a posted message, and retrieves the message (if any exist).
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-peekmessagew
        /// </para>
        /// </summary>
        /// <param name="lpMsg">A pointer to an <see cref="MSG"/> structure that receives message information.</param>
        /// <param name="hWnd">
        /// A handle to the window whose messages are to be retrieved. The window must belong to the current thread.
        /// If <paramref name="hWnd"/> is <see cref="IntPtr.Zero"/>, <see cref="PeekMessage"/> retrieves messages for any window
        /// that belongs to the current thread, and any messages on the current thread's message queue
        /// whose hwnd value is <see cref="IntPtr.Zero"/> (see the <see cref="MSG"/> structure).
        /// Therefore if <paramref name="hWnd"/> is <see cref="IntPtr.Zero"/>, both window messages and thread messages are processed.
        /// If <paramref name="hWnd"/> is -1, <see cref="PeekMessage"/> retrieves only messages on the current thread's message queue
        /// whose hwnd value is <see cref="IntPtr.Zero"/>, that is,
        /// thread messages as posted by <see cref="PostMessage"/> (when the hWnd parameter is <see cref="IntPtr.Zero"/>) or <see cref="PostThreadMessage"/>.
        /// </param>
        /// <param name="wMsgFilterMin">
        /// The value of the first message in the range of messages to be examined.
        /// Use <see cref="WM_KEYFIRST"/> (0x0100) to specify the first keyboard message
        /// or <see cref="WM_MOUSEFIRST"/> (0x0200) to specify the first mouse message.
        /// If <paramref name="wMsgFilterMin"/> and <paramref name="wMsgFilterMax"/> are both zero,
        /// <see cref="PeekMessage"/> returns all available messages (that is, no range filtering is performed).
        /// </param>
        /// <param name="wMsgFilterMax">
        /// The value of the last message in the range of messages to be examined.
        /// Use <see cref="WM_KEYLAST"/> to specify the last keyboard message
        /// or <see cref="WM_MOUSELAST"/> to specify the last mouse message.
        /// If <paramref name="wMsgFilterMin"/> and <paramref name="wMsgFilterMax"/> are both zero,
        /// <see cref="PeekMessage"/> returns all available messages (that is, no range filtering is performed).
        /// </param>
        /// <param name="wRemoveMsg">
        /// Specifies how messages are to be handled. This parameter can be one or more of the following values.
        /// <see cref="PM_NOREMOVE"/>, <see cref="PM_REMOVE"/> and <see cref="PM_NOYIELD"/>.
        /// By default, all message types are processed.
        /// To specify that only certain message should be processed, specify one or more of the following values.
        /// <see cref="PM_QS_INPUT"/>, <see cref="PM_QS_PAINT"/>,
        /// <see cref="PM_QS_POSTMESSAGE"/> and <see cref="PM_QS_SENDMESSAGE"/>.
        /// </param>
        /// <returns>
        /// If a message is available, the return value is <see cref="TRUE"/>.
        /// If no messages are available, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="PeekMessage"/> retrieves messages associated with the window identified by the <paramref name="hWnd"/> parameter
        /// or any of its children as specified by the <see cref="IsChild"/> function, and within the range of message values
        /// given by the <paramref name="wMsgFilterMin"/> and <paramref name="wMsgFilterMax"/> parameters.
        /// Note that an application can only use the low word in the <paramref name="wMsgFilterMin"/> and <paramref name="wMsgFilterMax"/> parameters;
        /// the high word is reserved for the system.
        /// Note that <see cref="PeekMessage"/> always retrieves <see cref="WM_QUIT"/> messages,
        /// no matter which values you specify for <paramref name="wMsgFilterMin"/> and <paramref name="wMsgFilterMax"/>.
        /// During this call, the system delivers pending, nonqueued messages, that is, messages sent to windows owned
        /// by the calling thread using the <see cref="SendMessage"/>, <see cref="SendMessageCallback"/>,
        /// <see cref="SendMessageTimeout"/>, or <see cref="SendNotifyMessage"/> function.
        /// Then the first queued message that matches the specified filter is retrieved.
        /// The system may also process internal events.
        /// If no filter is specified, messages are processed in the following order:
        /// Sent messages
        /// Posted messages
        /// Input (hardware) messages and system internal events
        /// Sent messages (again)
        /// <see cref="WM_PAINT"/> messages
        /// <see cref="WM_TIMER"/> messages
        /// To retrieve input messages before posted messages, use the <paramref name="wMsgFilterMin"/> and <paramref name="wMsgFilterMax"/> parameters.
        /// The <see cref="PeekMessage"/> function normally does not remove <see cref="WM_PAINT"/> messages from the queue.
        /// <see cref="WM_PAINT"/> messages remain in the queue until they are processed.
        /// However, if a <see cref="WM_PAINT"/> message has a NULL update region, <see cref="PeekMessage"/> does remove it from the queue.
        /// If a top-level window stops responding to messages for more than several seconds,
        /// the system considers the window to be not responding and replaces it with a ghost window that has the same z-order,
        /// location, size, and visual attributes.
        /// This allows the user to move it, resize it, or even close the application.
        /// However, these are the only actions available because the application is actually not responding.
        /// When an application is being debugged, the system does not generate a ghost window.
        /// DPI Virtualization
        /// This API does not participate in DPI virtualization.
        /// The output is in the mode of the window that the message is targeting.
        /// The calling thread is not taken into consideration.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "PeekMessageW", SetLastError = true)]
        public static extern BOOL PeekMessage([Out]out MSG lpMsg, [In]HWND hWnd, [In]UINT wMsgFilterMin, [In]UINT wMsgFilterMax,
            [In]PeekMessageFlags wRemoveMsg);

        /// <summary>
        /// <para>
        /// Places (posts) a message in the message queue associated with the thread that created the specified window and
        /// returns without waiting for the thread to process the message.
        ///</para>
        /// <para>
        /// To post a message in the message queue associated with a thread, use the <see cref="PostThreadMessage"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-postmessagew
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose window procedure is to receive the message. The following values have special meanings.
        /// <see cref="HWND_BROADCAST"/> : The message is posted to all top-level windows in the system, including disabled or invisible unowned windows,
        /// overlapped windows, and pop-up windows. The message is not posted to child windows.
        /// <see cref="IntPtr.Zero"/>: The function behaves like a call to <see cref="PostThreadMessage"/> with the dwThreadId parameter set to
        /// the identifier of the current thread.
        /// </param>
        /// <param name="msg">The message to be posted.</param>
        /// <param name="wParam">Additional message-specific information.</param>
        /// <param name="lParam">Additional message-specific information.</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "PostMessageW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PostMessage([In]IntPtr hWnd, [In]WindowsMessages msg, [In]UIntPtr wParam, [In]IntPtr lParam);

        /// <summary>
        /// <para>
        /// Indicates to the system that a thread has made a request to terminate (quit).
        /// It is typically used in response to a <see cref="WM_DESTROY"/> message.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-postquitmessage
        /// </para>
        /// </summary>
        /// <param name="nExitCode">
        /// The application exit code.
        /// This value is used as the <see cref="MSG.wParam"/> parameter of the <see cref="WM_DESTROY"/> message.
        /// </param>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "PostQuitMessage", SetLastError = true)]
        public static extern void PostQuitMessage([In] int nExitCode);

        /// <summary>
        /// <para>
        /// Defines a new window message that is guaranteed to be unique throughout the system.
        /// The message value can be used when sending or posting messages.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-registerwindowmessagew
        /// </para>
        /// </summary>
        /// <param name="lpString">
        /// The message to be registered.
        /// </param>
        /// <returns>
        /// If the message is successfully registered, the return value is a message identifier in the range 0xC000 through 0xFFFF.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="RegisterWindowMessage"/> function is typically used to register messages for communicating between two cooperating applications.
        /// If two different applications register the same message string, the applications return the same message value.
        /// The message remains registered until the session ends.
        /// Only use <see cref="RegisterWindowMessage"/> when more than one application must process the same message.
        /// For sending private messages within a window class, an application can use any integer in the range <see cref="WM_USER"/> through 0x7FFF.
        /// (Messages in this range are private to a window class, not to an application.
        /// For example, predefined control classes such as BUTTON, EDIT, LISTBOX, and COMBOBOX may use values in this range.)
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegisterWindowMessageW", SetLastError = true)]
        public static extern UINT RegisterWindowMessage([MarshalAs(UnmanagedType.LPWStr)][In]string lpString);

        /// <summary>
        /// <para>
        /// Sends the specified message to a window or windows.
        /// The <see cref="SendMessage"/> function calls the window procedure for the specified window
        /// and does not return until the window procedure has processed the message.
        /// To send a message and return immediately, use the <see cref="SendMessageCallback"/> or <see cref="SendNotifyMessage"/> function.
        /// To post a message to a thread's message queue and return immediately,
        /// use the <see cref="PostMessage"/> or <see cref="PostThreadMessage"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-sendmessage
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose window procedure will receive the message.
        /// If this parameter is <see cref="HWND_BROADCAST"/>, the message is sent to all top-level windows in the system,
        /// including disabled or invisible unowned windows, overlapped windows, and pop-up windows; but the message is not sent to child windows.
        /// Message sending is subject to UIPI.
        /// The thread of a process can send messages only to message queues of threads in processes of lesser or equal integrity level.
        /// </param>
        /// <param name="Msg">
        /// The message to be sent.
        /// </param>
        /// <param name="wParam">
        /// Additional message-specific information.
        /// </param>
        /// <param name="lParam">
        /// Additional message-specific information.
        /// </param>
        /// <returns>
        /// The return value specifies the result of the message processing; it depends on the message sent.
        /// </returns>
        /// <remarks>
        /// When a message is blocked by UIPI the last error, retrieved with <see cref="GetLastError"/>, is set to 5 (access denied).
        /// Applications that need to communicate using <see cref="HWND_BROADCAST"/> should use
        /// the <see cref="RegisterWindowMessage"/> function to obtain a unique message for inter-application communication.
        /// The system only does marshalling for system messages (those in the range 0 to (<see cref="WM_USER"/>-1)).
        /// To send other messages (those >= <see cref="WM_USER"/>) to another process, you must do custom marshalling.
        /// If the specified window was created by the calling thread, the window procedure is called immediately as a subroutine.
        /// If the specified window was created by a different thread, the system switches to that thread and calls the appropriate window procedure.
        /// Messages sent between threads are processed only when the receiving thread executes message retrieval code.
        /// The sending thread is blocked until the receiving thread processes the message.
        /// However, the sending thread will process incoming nonqueued messages while waiting for its message to be processed.
        /// To prevent this, use <see cref="SendMessageTimeout"/> with <see cref="SMTO_BLOCK"/> set.
        /// For more information on nonqueued messages, see Nonqueued Messages.
        /// An accessibility application can use <see cref="SendMessage"/> to send <see cref="WM_APPCOMMAND"/> messages to the shell to launch applications.
        /// This functionality is not guaranteed to work for other types of applications.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SendMessageW", SetLastError = true)]
        public static extern IntPtr SendMessage([In]IntPtr hWnd, [In]WindowsMessages Msg, [In]UIntPtr wParam, [In]IntPtr lParam);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cMessagesMax"></param>
        /// <returns></returns>
        [Obsolete]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetMessageQueue", SetLastError = true)]
        public static extern BOOL SetMessageQueue(int cMessagesMax);

        /// <summary>
        /// <para>
        /// Translates virtual-key messages into character messages.
        /// The character messages are posted to the calling thread's message queue, 
        /// to be read the next time the thread calls the <see cref="GetMessage"/> or <see cref="PeekMessage"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-translatemessage
        /// </para>
        /// </summary>
        /// <param name="lpMsg">
        /// An MSG structure that contains message information retrieved from the calling thread's message queue
        /// by using the <see cref="GetMessage"/> or <see cref="PeekMessage"/> function.
        /// </param>
        /// <returns>
        /// If the message is translated (that is, a character message is posted to the thread's message queue),
        /// the return value is <see langword="true"/>.
        /// If the message is <see cref="WM_KEYDOWN"/>, <see cref="WM_KEYUP"/>,
        /// <see cref="WM_SYSKEYDOWN"/>, or <see cref="WM_SYSKEYUP"/>,
        /// the return value is <see langword="true"/>, regardless of the translation.
        /// If the message is not translated (that is, a character message is not posted to the thread's message queue),
        /// the return value is <see langword="false"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "TranslateMessage", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern BOOL TranslateMessage([MarshalAs(UnmanagedType.LPStruct)][In]MSG lpMsg);

        /// <summary>
        /// <para>
        /// Yields control to other threads when a thread has no other messages in its message queue.
        /// The <see cref="WaitMessage"/> function suspends the thread and does not return until a new message is placed in the thread's message queue.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-waitmessage
        /// </para>
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Note that <see cref="WaitMessage"/> does not return if there is unread input in the message queue
        /// after the thread has called a function to check the queue.
        /// This is because functions such as <see cref="PeekMessage"/>, <see cref="GetMessage"/>, <see cref="GetQueueStatus"/>,
        /// <see cref="WaitMessage"/>, <see cref="MsgWaitForMultipleObjects"/>, and <see cref="MsgWaitForMultipleObjectsEx"/> check the queue
        /// and then change the state information for the queue so that the input is no longer considered new.
        /// A subsequent call to <see cref="WaitMessage"/> will not return until new input of the specified type arrives.
        /// The existing unread input (received prior to the last time the thread checked the queue) is ignored.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "WaitMessage", SetLastError = true)]
        public static extern BOOL WaitMessage();
    }
}
