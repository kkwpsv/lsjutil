using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.WaitResult;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.BroadcastSystemMessageFlags;
using static Lsj.Util.Win32.Enums.BroadcastSystemMessageRecipients;
using static Lsj.Util.Win32.Enums.GetWindowLongIndexes;
using static Lsj.Util.Win32.Enums.InSendMessageExResults;
using static Lsj.Util.Win32.Enums.MessageFilterFlags;
using static Lsj.Util.Win32.Enums.MsgWaitForMultipleObjectsExFlags;
using static Lsj.Util.Win32.Enums.PeekMessageFlags;
using static Lsj.Util.Win32.Enums.QueueStatus;
using static Lsj.Util.Win32.Enums.SendMessageTimeoutFlags;
using static Lsj.Util.Win32.Enums.StandardAccessRights;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.ThreadAccessRights;
using static Lsj.Util.Win32.Enums.WindowHookTypes;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

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
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-postmessagew"/>
        /// </para>
        /// </summary>
        public static readonly HWND HWND_BROADCAST = new IntPtr(0xFFFF);


        /// <summary>
        /// <para>
        /// An application-defined callback function used with the <see cref="SendMessageCallback"/> function.
        /// The system passes the message to the callback function after passing the message to the destination window procedure.
        /// The <see cref="SENDASYNCPROC"/> type defines a pointer to this callback function.
        /// SendAsyncProc is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nc-winuser-sendasyncproc"/>
        /// </para>
        /// </summary>
        /// <param name="Arg1">
        /// A handle to the window whose window procedure received the message.
        /// If the <see cref="SendMessageCallback"/> function was called with its hwnd parameter set to <see cref="HWND_BROADCAST"/>,
        /// the system calls the SendAsyncProc function once for each top-level window.
        /// </param>
        /// <param name="Arg2">
        /// The message.
        /// </param>
        /// <param name="Arg3">
        /// An application-defined value sent from the <see cref="SendMessageCallback"/> function.
        /// </param>
        /// <param name="Arg4">
        /// The result of the message processing.
        /// This value depends on the message.
        /// </param>
        /// <remarks>
        /// You install a SendAsyncProc application-defined callback function by passing a <see cref="SENDASYNCPROC"/> pointer
        /// to the <see cref="SendMessageCallback"/> function.
        /// The callback function is only called when the thread that called <see cref="SendMessageCallback"/>
        /// calls <see cref="GetMessage"/>, <see cref="PeekMessage"/>, or <see cref="WaitMessage"/>.
        /// </remarks>
        public delegate void Sendasyncproc([In] HWND Arg1, [In] WindowMessages Arg2, [In] ULONG_PTR Arg3, [In] LRESULT Arg4);


        /// <summary>
        /// <para>
        /// Sends a message to the specified recipients.
        /// The recipients can be applications, installable drivers, network drivers, system-level device drivers, or any combination of these system components.
        /// To receive additional information if the request is defined, use the <see cref="BroadcastSystemMessageEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-broadcastsystemmessagew"/>
        /// </para>
        /// </summary>
        /// <param name="flags">
        /// The broadcast option.
        /// This parameter can be one or more of the following values.
        /// <see cref="BSF_ALLOWSFW"/>, <see cref="BSF_FLUSHDISK"/>, <see cref="BSF_FORCEIFHUNG"/>,
        /// <see cref="BSF_IGNORECURRENTTASK"/>, <see cref="BSF_NOHANG"/>, <see cref="BSF_NOTIMEOUTIFNOTHUNG"/>,
        /// <see cref="BSF_POSTMESSAGE"/>, <see cref="BSF_QUERY"/>, <see cref="BSF_SENDNOTIFYMESSAGE"/>
        /// </param>
        /// <param name="lpInfo">
        /// A pointer to a variable that contains and receives information about the recipients of the message.
        /// When the function returns, this variable receives a combination of these values
        /// identifying which recipients actually received the message.
        /// If this parameter is <see cref="NullRef{BroadcastSystemMessageRecipients}"/>, the function broadcasts to all components.
        /// This parameter can be one or more of the following values.
        /// <see cref="BSM_ALLCOMPONENTS"/>, <see cref="BSM_ALLDESKTOPS"/>, <see cref="BSM_APPLICATIONS"/>
        /// </param>
        /// <param name="Msg">
        /// The message to be sent.
        /// The message to be sent.
        /// </param>
        /// <param name="wParam">
        /// Additional message-specific information.
        /// </param>
        /// <param name="lParam">
        /// Additional message-specific information.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a positive value.
        /// If the function is unable to broadcast the message, the return value is –1.
        /// If the <paramref name="flags"/> parameter is <see cref="BSF_QUERY"/> and at least one recipient
        /// returned <see cref="BROADCAST_QUERY_DENY"/> to the corresponding message, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If <see cref="BSF_QUERY"/> is not specified, the function sends the specified message to all requested recipients,
        /// ignoring values returned by those recipients.
        /// The system only does marshalling for system messages (those in the range 0 to (WM_USER-1)).
        /// To send other messages (those >= WM_USER) to another process, you must do custom marshalling.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "BroadcastSystemMessageW", ExactSpelling = true, SetLastError = true)]
        public static extern LONG BroadcastSystemMessage([In] BroadcastSystemMessageFlags flags, [In][Out] ref BroadcastSystemMessageRecipients lpInfo,
            [In] WindowMessages Msg, [In] WPARAM wParam, [In] LPARAM lParam);

        /// <summary>
        /// <para>
        /// Sends a message to the specified recipients.
        /// The recipients can be applications, installable drivers, network drivers,
        /// system-level device drivers, or any combination of these system components.
        /// This function is similar to <see cref="BroadcastSystemMessage"/> except
        /// that this function can return more information from the recipients.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-broadcastsystemmessageexw"/>
        /// </para>
        /// </summary>
        /// <param name="flags">
        /// The broadcast option.
        /// This parameter can be one or more of the following values.
        /// <see cref="BSF_ALLOWSFW"/>, <see cref="BSF_FLUSHDISK"/>, <see cref="BSF_FORCEIFHUNG"/>,
        /// <see cref="BSF_IGNORECURRENTTASK"/>, <see cref="BSF_LUID"/>, <see cref="BSF_NOHANG"/>,
        /// <see cref="BSF_NOTIMEOUTIFNOTHUNG"/>, <see cref="BSF_POSTMESSAGE"/>, <see cref="BSF_RETURNHDESK"/>,
        /// <see cref="BSF_QUERY"/>, <see cref="BSF_SENDNOTIFYMESSAGE"/>
        /// </param>
        /// <param name="lpInfo">
        /// A pointer to a variable that contains and receives information about the recipients of the message.
        /// When the function returns, this variable receives a combination of these values
        /// identifying which recipients actually received the message.
        /// If this parameter is <see cref="NullRef{BroadcastSystemMessageRecipients}"/>, the function broadcasts to all components.
        /// This parameter can be one or more of the following values.
        /// <see cref="BSM_ALLCOMPONENTS"/>, <see cref="BSM_ALLDESKTOPS"/>, <see cref="BSM_APPLICATIONS"/>
        /// </param>
        /// <param name="Msg">
        /// The message to be sent.
        /// The message to be sent.
        /// </param>
        /// <param name="wParam">
        /// Additional message-specific information.
        /// </param>
        /// <param name="lParam">
        /// Additional message-specific information.
        /// </param>
        /// <param name="pbsmInfo">
        /// A pointer to a <see cref="BSMINFO"/> structure that contains additional information
        /// if the request is denied and <paramref name="flags"/> is set to <see cref="BSF_QUERY"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a positive value.
        /// If the function is unable to broadcast the message, the return value is –1.
        /// If the <paramref name="flags"/> parameter is <see cref="BSF_QUERY"/> and at least one recipient
        /// returned <see cref="BROADCAST_QUERY_DENY"/> to the corresponding message, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If <see cref="BSF_QUERY"/> is not specified, the function sends the specified message to all requested recipients,
        /// ignoring values returned by those recipients.
        /// If the caller's thread is on a desktop other than that of the window that denied the request,
        /// the caller must call <code>SetThreadDesktop(hdesk)</code> to query anything on that window.
        /// Also, the caller must call <see cref="CloseDesktop"/> on the returned hdesk handle.
        /// The system only does marshalling for system messages (those in the range 0 to (WM_USER-1)).
        /// To send other messages (those >= WM_USER) to another process, you must do custom marshalling.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "BroadcastSystemMessageExW", ExactSpelling = true, SetLastError = true)]
        public static extern LONG BroadcastSystemMessageEx([In] BroadcastSystemMessageFlags flags, [In][Out] ref BroadcastSystemMessageRecipients lpInfo,
            [In] WindowMessages Msg, [In] WPARAM wParam, [In] LPARAM lParam, [Out] out BSMINFO pbsmInfo);

        /// <summary>
        /// <para>
        /// Passes the specified message and hook code to the hook procedures associated
        /// with the <see cref="WH_SYSMSGFILTER"/> and <see cref="WH_MSGFILTER"/> hooks.
        /// A <see cref="WH_SYSMSGFILTER"/> or <see cref="WH_MSGFILTER"/> hook procedure is an application-defined callback function that examines and,
        /// optionally, modifies messages for a dialog box, message box, menu, or scroll bar.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-callmsgfilterw"/>
        /// </para>
        /// </summary>
        /// <param name="lpMsg">
        /// A pointer to an <see cref="MSG"/> structure that contains the message to be passed to the hook procedures.
        /// </param>
        /// <param name="nCode">
        /// An application-defined code used by the hook procedure to determine how to process the message.
        /// The code must not have the same value as system-defined hook codes (MSGF_ and HC_) associated
        /// with the <see cref="WH_SYSMSGFILTER"/> and <see cref="WH_MSGFILTER"/> hooks.
        /// </param>
        /// <returns>
        /// If the application should process the message further, the return value is <see cref="FALSE"/>.
        /// If the application should not process the message further, the return value is <see cref="TRUE"/>.
        /// </returns>
        /// <remarks>
        /// The system calls <see cref="CallMsgFilter"/> to enable applications to examine and control the flow of messages
        /// during internal processing of dialog boxes, message boxes, menus, and scroll bars,
        /// or when the user activates a different window by pressing the ALT+TAB key combination.
        /// Install this hook procedure by using the <see cref="SetWindowsHookEx"/> function.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallMsgFilterW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CallMsgFilter([In][Out] ref MSG lpMsg, [In] int nCode);

        /// <summary>
        /// <para>
        /// Passes the hook information to the next hook procedure in the current hook chain.
        /// A hook procedure can call this function either before or after processing the hook information.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-callnexthookex"/>
        /// </para>
        /// </summary>
        /// <param name="hhk">
        /// This parameter is ignored.
        /// </param>
        /// <param name="nCode">
        /// The hook code passed to the current hook procedure.
        /// The next hook procedure uses this code to determine how to process the hook information.
        /// </param>
        /// <param name="wParam">
        /// The <paramref name="wParam"/> value passed to the current hook procedure.
        /// The meaning of this parameter depends on the type of hook associated with the current hook chain.
        /// </param>
        /// <param name="lParam">
        /// The <paramref name="lParam"/> value passed to the current hook procedure.
        /// The meaning of this parameter depends on the type of hook associated with the current hook chain.
        /// </param>
        /// <returns>
        /// This value is returned by the next hook procedure in the chain.
        /// The current hook procedure must also return this value.
        /// The meaning of the return value depends on the hook type.
        /// For more information, see the descriptions of the individual hook procedures.
        /// </returns>
        /// <remarks>
        /// Hook procedures are installed in chains for particular hook types.
        /// <see cref="CallNextHookEx"/> calls the next hook in the chain.
        /// Calling <see cref="CallNextHookEx"/> is optional, but it is highly recommended;
        /// otherwise, other applications that have installed hooks will not receive hook notifications and may behave incorrectly as a result.
        /// You should call <see cref="CallNextHookEx"/> unless you absolutely need to prevent the notification from being seen by other applications.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallNextHookEx", ExactSpelling = true, SetLastError = true)]
        public static extern LRESULT CallNextHookEx([In] HHOOK hhk, [In] int nCode, [In] WPARAM wParam, [In] LPARAM lParam);


        /// <summary>
        /// <para>
        /// Passes message information to the specified window procedure.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-callwindowprocw"/>
        /// </para>
        /// </summary>
        /// <param name="lpPrevWndFunc">
        /// The previous window procedure.
        /// If this value is obtained by calling the <see cref="GetWindowLong"/> function with the nIndex parameter
        /// set to <see cref="GWL_WNDPROC"/> or <see cref="DWL_DLGPROC"/>,
        /// it is actually either the address of a window or dialog box procedure,
        /// or a special internal value meaningful only to <see cref="CallWindowProc"/>.
        /// </param>
        /// <param name="hWnd">
        /// A handle to the window procedure to receive the message.
        /// </param>
        /// <param name="Msg">
        /// The message.
        /// </param>
        /// <param name="wParam">
        /// Additional message-specific information.
        /// The contents of this parameter depend on the value of the <paramref name="Msg"/> parameter.
        /// </param>
        /// <param name="lParam">
        /// Additional message-specific information.
        /// The contents of this parameter depend on the value of the <paramref name="Msg"/> parameter.
        /// </param>
        /// <returns>
        /// The return value specifies the result of the message processing and depends on the message sent.
        /// </returns>
        /// <remarks>
        /// Use the <see cref="CallWindowProc"/> function for window subclassing.
        /// Usually, all windows with the same class share one window procedure.
        /// A subclass is a window or set of windows with the same class whose messages are intercepted and processed
        /// by another window procedure (or procedures) before being passed to the window procedure of the class.
        /// The <see cref="SetWindowLong"/> function creates the subclass by changing the window procedure associated with a particular window,
        /// causing the system to call the new window procedure instead of the previous one.
        /// An application must pass any messages not processed by the new window procedure
        /// to the previous window procedure by calling <see cref="CallWindowProc"/>.
        /// This allows the application to create a chain of window procedures.
        /// The <see cref="CallWindowProc"/> function handles Unicode-to-ANSI conversion.
        /// You cannot take advantage of this conversion if you call the window procedure directly.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallWindowProcW", ExactSpelling = true, SetLastError = true)]
        public static extern LRESULT CallWindowProc([In] WNDPROC lpPrevWndFunc, [In] HWND hWnd, [In] WindowMessages Msg,
            [In] WPARAM wParam, [In] LPARAM lParam);

        /// <summary>
        /// <para>
        /// Adds or removes a message from the User Interface Privilege Isolation (UIPI) message filter.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-changewindowmessagefilter"/>
        /// </para>
        /// </summary>
        /// <param name="message">
        /// The message to add to or remove from the filter.
        /// </param>
        /// <param name="dwFlag">
        /// The action to be performed. One of the following values.
        /// <see cref="MSGFLT_ADD"/>:
        /// Adds the <paramref name="message"/> to the filter.
        /// This has the effect of allowing the message to be received.
        /// <see cref="MSGFLT_REMOVE"/>
        /// Removes the <paramref name="message"/> from the filter.
        /// This has the effect of blocking the message.
        /// </param>
        /// <returns>
        /// <see cref="TRUE"/> if successful; otherwise, <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// Note
        /// A message can be successfully removed from the filter, but that is not a guarantee that the message will be blocked.
        /// See the Remarks section for more details.
        /// </returns>
        /// <remarks>
        /// UIPI is a security feature that prevents messages from being received from a lower integrity level sender.
        /// All such messages with a value above <see cref="WM_USER"/> are blocked by default.
        /// The filter, somewhat contrary to intuition, is a list of messages that are allowed through.
        /// Therefore, adding a message to the filter allows that message to be received from a lower integrity sender,
        /// while removing a message blocks that message from being received.
        /// Certain messages with a value less than <see cref="WM_USER"/> are required
        /// to pass through the filter regardless of the filter setting.
        /// You can call this function to remove one of those messages from the filter and it will return <see cref="TRUE"/>.
        /// However, the message will still be received by the calling process.
        /// Processes at or below SECURITY_MANDATORY_LOW_RID are not allowed to change the filter.
        /// If those processes call this function, it will fail.
        /// For more information on integrity levels, see Understanding and Working in Protected Mode Internet Explorer.
        /// </remarks>
        [Obsolete("Using the ChangeWindowMessageFilter function is not recommended, as it has process-wide scope." +
            "Instead, use the ChangeWindowMessageFilterEx function to control access to specific windows as needed." +
            "ChangeWindowMessageFilter may not be supported in future versions of Windows.")]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ChangeWindowMessageFilter", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ChangeWindowMessageFilter([In] WindowMessages message, [In] MessageFilterFlags dwFlag);

        /// <summary>
        /// <para>
        /// Modifies the User Interface Privilege Isolation (UIPI) message filter for a specified window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-changewindowmessagefilterex"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window whose UIPI message filter is to be modified.
        /// </param>
        /// <param name="message">
        /// A handle to the window whose UIPI message filter is to be modified.
        /// </param>
        /// <param name="action">
        /// The action to be performed, and can take one of the following values:
        /// <see cref="MSGFLT_ALLOW"/>:
        /// Allows the message through the filter.
        /// This enables the message to be received by <paramref name="hwnd"/>,
        /// regardless of the source of the message, even it comes from a lower privileged process.
        /// <see cref="MSGFLT_DISALLOW"/>:
        /// Blocks the message to be delivered to <paramref name="hwnd"/> if it comes from a lower privileged process,
        /// unless the message is allowed process-wide by using the <see cref="ChangeWindowMessageFilter"/> function or globally.
        /// <see cref="MSGFLT_RESET"/>:
        /// Resets the window message filter for <paramref name="hwnd"/> to the default.
        /// Any message allowed globally or process-wide will get through, but any message not included in those two categories,
        /// and which comes from a lower privileged process, will be blocked.
        /// </param>
        /// <param name="pChangeFilterStruct">
        /// Optional pointer to a <see cref="CHANGEFILTERSTRUCT"/> structure.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns <see cref="TRUE"/>; otherwise, it returns <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// UIPI is a security feature that prevents messages from being received from a lower-integrity-level sender.
        /// You can use this function to allow specific messages to be delivered to a window
        /// even if the message originates from a process at a lower integrity level.
        /// Unlike the <see cref="ChangeWindowMessageFilter"/> function, which controls the process message filter,
        /// the <see cref="ChangeWindowMessageFilterEx"/> function controls the window message filter.
        /// An application may use the <see cref="ChangeWindowMessageFilter"/> function to allow or block a message in a process-wide manner.
        /// If the message is allowed by either the process message filter or the window message filter, it will be delivered to the window.
        /// Note that processes at or below SECURITY_MANDATORY_LOW_RID are not allowed to change the message filter.
        /// If those processes call this function, it will fail and generate the extended error code, <see cref="ERROR_ACCESS_DENIED"/>.
        /// Certain messages whose value is smaller than <see cref="WM_USER"/> are required to be passed through the filter,
        /// regardless of the filter setting.
        /// There will be no effect when you attempt to use this function to allow or block such messages.
        /// </remarks>
        [Obsolete("Using the ChangeWindowMessageFilter function is not recommended, as it has process-wide scope." +
            "Instead, use the ChangeWindowMessageFilterEx function to control access to specific windows as needed." +
            "ChangeWindowMessageFilter may not be supported in future versions of Windows.")]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ChangeWindowMessageFilterEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ChangeWindowMessageFilterEx([In] HWND hwnd, [In] WindowMessages message,
            [In] MessageFilterFlags action, [In][Out] ref CHANGEFILTERSTRUCT pChangeFilterStruct);

        /// <summary>
        /// <para>
        /// Dispatches a message to a window procedure.
        /// It is typically used to dispatch a message retrieved by the <see cref="GetMessage"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-dispatchmessagew"/>
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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DispatchMessageW", ExactSpelling = true, SetLastError = true)]
        public static extern LRESULT DispatchMessage([In] in MSG lpmsg);

        /// <summary>
        /// <para>
        /// Determines whether the current window procedure is processing a message that was sent from another thread
        /// (in the same process or a different process) by a call to the <see cref="SendMessage"/> function.
        /// To obtain additional information about how the message was sent, use the <see cref="InSendMessageEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-insendmessage"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// If the window procedure is processing a message sent to it from another thread using the <see cref="SendMessage"/> function,
        /// the return value is <see cref="TRUE"/>.
        /// If the window procedure is not processing a message sent to it from another thread using the <see cref="SendMessage"/> function,
        /// the return value is <see cref="FALSE"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "InSendMessage", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL InSendMessage();

        /// <summary>
        /// <para>
        /// Determines whether the current window procedure is processing a message
        /// that was sent from another thread (in the same process or a different process).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-insendmessageex"/>
        /// </para>
        /// </summary>
        /// <param name="lpReserved">
        /// Reserved; must be <see cref="NULL"/>.
        /// </param>
        /// <returns>
        /// If the message was not sent, the return value is <see cref="ISMEX_NOSEND"/> (0x00000000).
        /// Otherwise, the return value is one or more of the following values.
        /// <see cref="ISMEX_CALLBACK"/>, <see cref="ISMEX_NOTIFY"/>, <see cref="ISMEX_REPLIED"/>, <see cref="ISMEX_SEND"/>
        /// </returns>
        /// <remarks>
        /// To determine if the sender is blocked, use the following test:
        /// <code>fBlocked = ( InSendMessageEx(NULL) &amp; (ISMEX_REPLIED|ISMEX_SEND) ) == ISMEX_SEND;</code>
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "InSendMessageEx", ExactSpelling = true, SetLastError = true)]
        public static extern InSendMessageExResults InSendMessageEx([In] LPVOID lpReserved);

        /// <summary>
        /// <para>
        /// Determines whether there are mouse-button or keyboard messages in the calling thread's message queue.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getinputstate"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// If the queue contains one or more new mouse-button or keyboard messages, the return value is <see cref="TRUE"/>.
        /// If there are no new mouse-button or keyboard messages in the queue, the return value is <see cref="FALSE"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetInputState", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetInputState();

        /// <summary>
        /// <para>
        /// Retrieves a message from the calling thread's message queue.
        /// The function dispatches incoming sent messages until a posted message is available for retrieval.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getmessage"/>
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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMessageW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetMessage([Out] out MSG lpMsg, [In] HWND hWnd, [In] UINT wMsgFilterMin, [In] UINT wMsgFilterMax);

        /// <summary>
        /// <para>
        /// Retrieves the extra message information for the current thread.
        /// Extra message information is an application- or driver-defined value associated with the current thread's message queue.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getmessageextrainfo"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// The return value specifies the extra information.
        /// The meaning of the extra information is device specific.
        /// </returns>
        /// <remarks>
        /// To set a thread's extra message information, use the <see cref="SetMessageExtraInfo"/> function.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMessageExtraInfo", ExactSpelling = true, SetLastError = true)]
        public static extern LPARAM GetMessageExtraInfo();

        /// <summary>
        /// <para>
        /// Retrieves the cursor position for the last message retrieved by the <see cref="GetMessage"/> function.
        /// To determine the current position of the cursor, use the <see cref="GetCursorPos"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getmessagepos"/>
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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMessagePos", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetMessagePos();

        /// <summary>
        /// <para>
        /// Retrieves the message time for the last message retrieved by the <see cref="GetMessage"/> function.
        /// The time is a long integer that specifies the elapsed time, in milliseconds,
        /// from the time the system was started to the time the message was created (that is, placed in the thread's message queue).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getmessagetime"/>
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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMessageTime", ExactSpelling = true, SetLastError = true)]
        public static extern LONG GetMessageTime();

        /// <summary>
        /// <para>
        /// Retrieves the type of messages found in the calling thread's message queue.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getqueuestatus"/>
        /// </para>
        /// </summary>
        /// <param name="flags">
        /// The types of messages for which to check. This parameter can be one or more of the following values.
        /// <see cref="QS_ALLEVENTS"/>, <see cref="QS_ALLINPUT"/>, <see cref="QS_ALLPOSTMESSAGE"/>, <see cref="QS_HOTKEY"/>, <see cref="QS_INPUT"/>,
        /// <see cref="QS_KEY"/>, <see cref="QS_MOUSE"/>, <see cref="QS_MOUSEBUTTON"/>, <see cref="QS_MOUSEMOVE"/>, <see cref="QS_PAINT"/>,
        /// <see cref="QS_POSTMESSAGE"/>, <see cref="QS_RAWINPUT"/>, <see cref="QS_SENDMESSAGE"/>, <see cref="QS_TIMER"/>
        /// </param>
        /// <returns>
        /// The high-order word of the return value indicates the types of messages currently in the queue.
        /// The low-order word indicates the types of messages that have been added to the queue and that are still in the queue
        /// since the last call to the <see cref="GetQueueStatus"/>, <see cref="GetMessage"/>, or <see cref="PeekMessage"/> function.
        /// </returns>
        /// <remarks>
        /// The presence of a QS_ flag in the return value does not guarantee that a subsequent call
        /// to the <see cref="GetMessage"/> or <see cref="PeekMessage"/> function will return a message.
        /// <see cref="GetMessage"/> and <see cref="PeekMessage"/> perform some internal filtering that may cause the message to be processed internally.
        /// For this reason, the return value from <see cref="GetQueueStatus"/> should be considered only a hint as to
        /// whether <see cref="GetMessage"/> or <see cref="PeekMessage"/> should be called.
        /// The <see cref="QS_ALLPOSTMESSAGE"/> and <see cref="QS_POSTMESSAGE"/> flags differ in when they are cleared.
        /// <see cref="QS_POSTMESSAGE"/> is cleared when you call <see cref="GetMessage"/> or <see cref="PeekMessage"/>,
        /// whether or not you are filtering messages.
        /// <see cref="QS_ALLPOSTMESSAGE"/> is cleared when you call <see cref="GetMessage"/> or <see cref="PeekMessage"/> without filtering messages
        /// (wMsgFilterMin and wMsgFilterMax are 0).
        /// This can be useful when you call <see cref="PeekMessage"/> multiple times to get messages in different ranges.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetQueueStatus", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetQueueStatus([In] QueueStatus flags);

        /// <summary>
        /// <para>
        /// Waits until one or all of the specified objects are in the signaled state or the time-out interval elapses.
        /// The objects can include input event objects, which you specify using the <paramref name="dwWakeMask"/> parameter.
        /// To enter an alertable wait state, use the <see cref="MsgWaitForMultipleObjectsEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-msgwaitformultipleobjects"/>
        /// </para>
        /// </summary>
        /// <param name="nCount">
        /// The number of object handles in the array pointed to by <paramref name="pHandles"/>.
        /// The maximum number of object handles is <see cref="MAXIMUM_WAIT_OBJECTS"/> minus one.
        /// If this parameter has the value zero, then the function waits only for an input event.
        /// </param>
        /// <param name="pHandles">
        /// An array of object handles.
        /// For a list of the object types whose handles can be specified, see the following Remarks section.
        /// The array can contain handles of objects of different types. It may not contain multiple copies of the same handle.
        /// If one of these handles is closed while the wait is still pending, the function's behavior is undefined.
        /// The handles must have the <see cref="SYNCHRONIZE"/> access right.
        /// For more information, see Standard Access Rights.
        /// </param>
        /// <param name="fWaitAll">
        /// If this parameter is <see cref="TRUE"/>, the function returns when the states of all objects
        /// in the <paramref name="pHandles"/> array have been set to signaled and an input event has been received.
        /// If this parameter is <see cref="FALSE"/>, the function returns
        /// when the state of any one of the objects is set to signaled or an input event has been received.
        /// In this case, the return value indicates the object whose state caused the function to return.
        /// </param>
        /// <param name="dwMilliseconds">
        /// The time-out interval, in milliseconds.
        /// If a nonzero value is specified, the function waits until the specified objects are signaled or the interval elapses.
        /// If <paramref name="dwMilliseconds"/> is zero, the function does not enter a wait state if the specified objects are not signaled;
        /// it always returns immediately.
        /// If <paramref name="dwMilliseconds"/> is <see cref="INFINITE"/>, the function will return only when the specified objects are signaled.
        /// </param>
        /// <param name="dwWakeMask">
        /// The input types for which an input event object handle will be added to the array of object handles.
        /// This parameter can be one or more of the following values.
        /// <see cref="QS_ALLEVENTS"/>, <see cref="QS_ALLINPUT"/>, <see cref="QS_ALLPOSTMESSAGE"/>, <see cref="QS_HOTKEY"/>,
        /// <see cref="QS_INPUT"/>, <see cref="QS_KEY"/>, <see cref="QS_MOUSE"/>, <see cref="QS_MOUSEBUTTON"/>, <see cref="QS_MOUSEMOVE"/>,
        /// <see cref="QS_PAINT"/>, <see cref="QS_POSTMESSAGE"/>, <see cref="QS_RAWINPUT"/>, <see cref="QS_SENDMESSAGE"/>, <see cref="QS_TIMER"/>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value indicates the event that caused the function to return.
        /// It can be one of the following values.
        /// (Note that <see cref="WAIT_OBJECT_0"/> is defined as 0 and <see cref="WAIT_ABANDONED_0"/> is defined as 0x00000080L.)
        /// <see cref="WAIT_OBJECT_0"/> to (<see cref="WAIT_OBJECT_0"/> + <paramref name="nCount"/>– 1):
        /// If <paramref name="fWaitAll"/> is <see cref="TRUE"/>, the return value indicates that the state of all specified objects is signaled.
        /// If <paramref name="fWaitAll"/> is <see cref="FALSE"/>, the return value minus <see cref="WAIT_OBJECT_0"/> indicates
        /// the <paramref name="pHandles"/> array index of the object that satisfied the wait.
        /// <see cref="WAIT_OBJECT_0"/> + <paramref name="nCount"/>:
        /// New input of the type specified in the <paramref name="dwWakeMask"/> parameter is available in the thread's input queue.
        /// Functions such as <see cref="PeekMessage"/>, <see cref="GetMessage"/>, and <see cref="WaitMessage"/> mark messages in the queue as old messages.
        /// Therefore, after you call one of these functions, a subsequent call to <see cref="MsgWaitForMultipleObjects"/> will not return
        /// until new input of the specified type arrives.
        /// This value is also returned upon the occurrence of a system event that requires the thread's action, such as foreground activation.
        /// Therefore, <see cref="MsgWaitForMultipleObjects"/> can return
        /// even though no appropriate input is available and even if <paramref name="dwWakeMask"/> is set to 0.
        /// If this occurs, call <see cref="GetMessage"/> or <see cref="PeekMessage"/> to process the system event
        /// before trying the call to <see cref="MsgWaitForMultipleObjects"/> again.
        /// <see cref="WAIT_ABANDONED_0"/> to (<see cref="WAIT_ABANDONED_0"/> + <paramref name="nCount"/>– 1):
        /// If <paramref name="fWaitAll"/> is <see cref="TRUE"/>, the return value indicates that the state of all specified objects is signaled
        /// and at least one of the objects is an abandoned mutex object.
        /// If <paramref name="fWaitAll"/> is <see cref="FALSE"/>, the return value minus <see cref="WAIT_ABANDONED_0"/> indicates
        /// the <paramref name="pHandles"/> array index of an abandoned mutex object that satisfied the wait.
        /// Ownership of the mutex object is granted to the calling thread, and the mutex is set to nonsignaled.
        /// If the mutex was protecting persistent state information, you should check it for consistency.
        /// <see cref="WAIT_TIMEOUT"/>:
        /// The time-out interval elapsed and the conditions specified
        /// by the <paramref name="fWaitAll"/> and <paramref name="dwWakeMask"/> parameters were not satisfied.
        /// <see cref="WAIT_FAILED"/>:
        /// The function has failed. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="MsgWaitForMultipleObjects"/> function determines whether the wait criteria have been met.
        /// If the criteria have not been met, the calling thread enters the wait state until the conditions of the wait criteria
        /// have been met or the time-out interval elapses.
        /// When <paramref name="fWaitAll"/> is <see cref="TRUE"/>, the function does not modify the states of the specified objects
        /// until the states of all objects have been set to signaled.
        /// For example, a mutex can be signaled, but the thread does not get ownership until the states of the other objects have also been set to signaled.
        /// In the meantime, some other thread may get ownership of the mutex, thereby setting its state to nonsignaled.
        /// When <paramref name="fWaitAll"/> is <see cref="TRUE"/>, the function's wait is completed only when the states of all objects have been set
        /// to signaled and an input event has been received.
        /// Therefore, setting <paramref name="fWaitAll"/> to <see cref="TRUE"/> prevents input from being processed
        /// until the state of all objects in the <paramref name="pHandles"/> array have been set to signaled.
        /// For this reason, if you set <paramref name="fWaitAll"/> to <see cref="TRUE"/>,
        /// you should use a short timeout value in <paramref name="dwMilliseconds"/>.
        /// If you have a thread that creates windows waiting for all objects in the <paramref name="pHandles"/> array,
        /// including input events specified by <paramref name="dwWakeMask"/>, with no timeout interval, the system will deadlock.
        /// This is because threads that create windows must process messages.
        /// DDE sends message to all windows in the system.
        /// Therefore, if a thread creates windows, do not set the <paramref name="fWaitAll"/> parameter to <see cref="TRUE"/>
        /// in calls to <see cref="MsgWaitForMultipleObjects"/> made from that thread.
        /// When <paramref name="fWaitAll"/> is <see cref="FALSE"/>, this function checks the handles in the array in order starting with index 0,
        /// until one of the objects is signaled.
        /// If multiple objects become signaled, the function returns the index of the first handle in the array whose object was signaled.
        /// <see cref="MsgWaitForMultipleObjects"/> does not return if there is unread input of the specified type in the message queue
        /// after the thread has called a function to check the queue.
        /// This is because functions such as <see cref="PeekMessage"/>, <see cref="GetMessage"/>, <see cref="GetQueueStatus"/>,
        /// and <see cref="WaitMessage"/> check the queue and then change the state information for the queue so that the input is no longer considered new.
        /// A subsequent call to <see cref="MsgWaitForMultipleObjects"/> will not return until new input of the specified type arrives.
        /// The existing unread input (received prior to the last time the thread checked the queue) is ignored.
        /// The function modifies the state of some types of synchronization objects.
        /// Modification occurs only for the object or objects whose signaled state caused the function to return.
        /// For example, the count of a semaphore object is decreased by one.
        /// For more information, see the documentation for the individual synchronization objects.
        /// The <see cref="MsgWaitForMultipleObjects"/> function can specify handles of any of the following object types
        /// in the <paramref name="pHandles"/> array:
        /// Change notification, Console input, Event, Memory resource notification, Mutex, Process, Semaphore, Thread, Waitable timer
        /// The <see cref="QS_ALLPOSTMESSAGE"/> and <see cref="QS_POSTMESSAGE"/> flags differ in when they are cleared.
        /// <see cref="QS_POSTMESSAGE"/> is cleared when you call <see cref="GetMessage"/> or <see cref="PeekMessage"/>,
        /// whether or not you are filtering messages.
        /// <see cref="QS_ALLPOSTMESSAGE"/> is cleared when you call <see cref="GetMessage"/> or <see cref="PeekMessage"/>
        /// without filtering messages (wMsgFilterMin and wMsgFilterMax are 0).
        /// This can be useful when you call <see cref="PeekMessage"/> multiple times to get messages in different ranges.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "MsgWaitForMultipleObjects", ExactSpelling = true, SetLastError = true)]
        public static extern WaitResult MsgWaitForMultipleObjects([In] DWORD nCount, [MarshalAs(UnmanagedType.LPArray)][In] HANDLE[] pHandles,
          [In] BOOL fWaitAll, [In] DWORD dwMilliseconds, [In] QueueStatus dwWakeMask);

        /// <summary>
        /// <para>
        /// Waits until one or all of the specified objects are in the signaled state,
        /// an I/O completion routine or asynchronous procedure call (APC) is queued to the thread, or the time-out interval elapses.
        /// The array of objects can include input event objects, which you specify using the dwWakeMask parameter.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-msgwaitformultipleobjectsex"/>
        /// </para>
        /// </summary>
        /// <param name="nCount">
        /// The number of object handles in the array pointed to by <paramref name="pHandles"/>.
        /// The maximum number of object handles is <see cref="MAXIMUM_WAIT_OBJECTS"/> minus one.
        /// If this parameter has the value zero, then the function waits only for an input event.
        /// </param>
        /// <param name="pHandles">
        /// An array of object handles.
        /// For a list of the object types whose handles you can specify, see the Remarks section later in this topic.
        /// The array can contain handles to multiple types of objects.
        /// It may not contain multiple copies of the same handle.
        /// If one of these handles is closed while the wait is still pending, the function's behavior is undefined.
        /// The handles must have the <see cref="SYNCHRONIZE"/> access right. For more information, see Standard Access Rights.
        /// </param>
        /// <param name="dwMilliseconds">
        /// The time-out interval, in milliseconds.
        /// If a nonzero value is specified, the function waits until the specified objects are signaled,
        /// an I/O completion routine or APC is queued, or the interval elapses.
        /// If <paramref name="dwMilliseconds"/> is zero, the function does not enter a wait state if the criteria is not met;
        /// it always returns immediately.
        /// If <paramref name="dwMilliseconds"/> is <see cref="INFINITE"/>, the function will return only
        /// when the specified objects are signaled or an I/O completion routine or APC is queued.
        /// </param>
        /// <param name="dwWakeMask">
        /// The input types for which an input event object handle will be added to the array of object handles.
        /// This parameter can be one or more of the following values.
        /// <see cref="QS_ALLEVENTS"/>, <see cref="QS_ALLINPUT"/>, <see cref="QS_ALLPOSTMESSAGE"/>, <see cref="QS_HOTKEY"/>,
        /// <see cref="QS_INPUT"/>, <see cref="QS_KEY"/>, <see cref="QS_MOUSE"/>, <see cref="QS_MOUSEBUTTON"/>, <see cref="QS_MOUSEMOVE"/>,
        /// <see cref="QS_PAINT"/>, <see cref="QS_POSTMESSAGE"/>, <see cref="QS_RAWINPUT"/>, <see cref="QS_SENDMESSAGE"/>, <see cref="QS_TIMER"/>
        /// </param>
        /// <param name="dwFlags">
        /// The wait type. This parameter can be one or more of the following values.
        /// 0: 
        /// The function returns when any one of the objects is signaled.
        /// The return value indicates the object whose state caused the function to return.
        /// <see cref="MWMO_ALERTABLE"/>, <see cref="MWMO_INPUTAVAILABLE"/>, <see cref="MWMO_WAITALL"/>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value indicates the event that caused the function to return.
        /// It can be one of the following values.
        /// <see cref="WAIT_OBJECT_0"/> to (<see cref="WAIT_OBJECT_0"/> + <paramref name="nCount"/> - 1):
        /// If the <see cref="MWMO_WAITALL"/> flag is used, the return value indicates that the state of all specified objects is signaled.
        /// Otherwise, the return value minus <see cref="WAIT_OBJECT_0"/> indicates the <paramref name="pHandles"/> array index of the object
        /// that caused the function to return.
        /// <see cref="WAIT_OBJECT_0"/> + <paramref name="nCount"/>:
        /// New input of the type specified in the <paramref name="dwWakeMask"/> parameter is available in the thread's input queue.
        /// Functions such as <see cref="PeekMessage"/>, <see cref="GetMessage"/>, <see cref="GetQueueStatus"/>,
        /// and <see cref="WaitMessage"/> mark messages in the queue as old messages.
        /// Therefore, after you call one of these functions, a subsequent call to <see cref="MsgWaitForMultipleObjectsEx"/> will not return 
        /// until new input of the specified type arrives.
        /// This value is also returned upon the occurrence of a system event that requires the thread's action, such as foreground activation.
        /// Therefore, <see cref="MsgWaitForMultipleObjectsEx"/> can return even though no appropriate input is available
        /// and even if <paramref name="dwWakeMask"/> is set to 0.
        /// If this occurs, call <see cref="GetMessage"/> or <see cref="PeekMessage"/> to process the system event
        /// before trying the call to <see cref="MsgWaitForMultipleObjectsEx"/> again.
        /// <see cref="WAIT_ABANDONED_0"/> to (<see cref="WAIT_ABANDONED_0"/> + <paramref name="nCount"/> - 1):
        /// If the <see cref="MWMO_WAITALL"/> flag is used, the return value indicates that the state of all specified objects is signaled
        /// and at least one of the objects is an abandoned mutex object.
        /// Otherwise, the return value minus <see cref="WAIT_ABANDONED_0"/> indicates the <paramref name="pHandles"/> array index
        /// of an abandoned mutex object that caused the function to return.
        /// Ownership of the mutex object is granted to the calling thread, and the mutex is set to nonsignaled.
        /// If the mutex was protecting persistent state information, you should check it for consistency.
        /// <see cref="WAIT_IO_COMPLETION"/>:
        /// The wait was ended by one or more user-mode asynchronous procedure calls (APC) queued to the thread.
        /// <see cref="WAIT_TIMEOUT"/>:
        /// The time-out interval elapsed, but the conditions specified by the <paramref name="dwFlags"/>
        /// and <paramref name="dwWakeMask"/> parameters were not met.
        /// <see cref="WAIT_FAILED"/>:
        /// The function has failed. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="MsgWaitForMultipleObjectsEx"/> function determines whether the conditions specified
        /// by <paramref name="dwWakeMask"/> and <paramref name="dwFlags"/> have been met.
        /// If the conditions have not been met, the calling thread enters the wait state until the conditions of the wait criteria have been met
        /// or the time-out interval elapses.
        /// When <paramref name="dwFlags"/> is zero, this function checks the handles in the array in order starting with index 0,
        /// until one of the objects is signaled.
        /// If multiple objects become signaled, the function returns the index of the first handle in the array whose object was signaled.
        /// <see cref="MsgWaitForMultipleObjectsEx"/> does not return if there is unread input of the specified type in the message queue
        /// after the thread has called a function to check the queue, unless you use the <see cref="MWMO_INPUTAVAILABLE"/> flag.
        /// This is because functions such as <see cref="PeekMessage"/>, <see cref="GetMessage"/>, <see cref="GetQueueStatus"/>,
        /// and <see cref="WaitMessage"/> check the queue and then change the state information for the queue so that the input is no longer considered new.
        /// A subsequent call to <see cref="MsgWaitForMultipleObjectsEx"/> will not return until new input of the specified type arrives,
        /// unless you use the <see cref="MWMO_INPUTAVAILABLE"/> flag.
        /// If this flag is not used, the existing unread input (received prior to the last time the thread checked the queue) is ignored.
        /// The function modifies the state of some types of synchronization objects.
        /// Modification occurs only for the object or objects whose signaled state caused the function to return.
        /// For example, the system decreases the count of a semaphore object by one.
        /// For more information, see the documentation for the individual synchronization objects.
        /// The <see cref="MsgWaitForMultipleObjectsEx"/> function can specify handles of any of the following object types in the pHandles array:
        /// Change notification, Console input ,Event ,Memory resource notification, Mutex, Process, Semaphore, Thread, Waitable timer
        /// The <see cref="QS_ALLPOSTMESSAGE"/> and <see cref="QS_POSTMESSAGE"/> flags differ in when they are cleared.
        /// <see cref="QS_POSTMESSAGE"/> is cleared when you call <see cref="GetMessage"/> or <see cref="PeekMessage"/>,
        /// whether or not you are filtering messages.
        /// <see cref="QS_ALLPOSTMESSAGE"/> is cleared when you call <see cref="GetMessage"/> or <see cref="PeekMessage"/>
        /// without filtering messages (wMsgFilterMin and wMsgFilterMax are 0).
        /// This can be useful when you call <see cref="PeekMessage"/> multiple times to get messages in different ranges.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "MsgWaitForMultipleObjectsEx", ExactSpelling = true, SetLastError = true)]
        public static extern WaitResult MsgWaitForMultipleObjectsEx([In] DWORD nCount, [MarshalAs(UnmanagedType.LPArray)][In] HANDLE[] pHandles,
            [In] DWORD dwMilliseconds, [In] QueueStatus dwWakeMask, [In] MsgWaitForMultipleObjectsExFlags dwFlags);

        /// <summary>
        /// <para>
        /// Dispatches incoming sent messages, checks the thread message queue for a posted message, and retrieves the message (if any exist).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-peekmessagew"/>
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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "PeekMessageW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL PeekMessage([Out] out MSG lpMsg, [In] HWND hWnd, [In] UINT wMsgFilterMin, [In] UINT wMsgFilterMax,
            [In] PeekMessageFlags wRemoveMsg);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idThread"></param>
        /// <param name="Msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [Obsolete]
        public static BOOL PostAppMessage([In] DWORD idThread, [In] WindowMessages Msg, [In] WPARAM wParam, [In] LPARAM lParam) =>
             PostThreadMessage(idThread, Msg, wParam, lParam);

        /// <summary>
        /// <para>
        /// Places (posts) a message in the message queue associated with the thread that created the specified window and
        /// returns without waiting for the thread to process the message.
        ///</para>
        /// <para>
        /// To post a message in the message queue associated with a thread, use the <see cref="PostThreadMessage"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-postmessagew"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose window procedure is to receive the message. The following values have special meanings.
        /// <see cref="HWND_BROADCAST"/>: The message is posted to all top-level windows in the system, including disabled or invisible unowned windows,
        /// overlapped windows, and pop-up windows. The message is not posted to child windows.
        /// <see cref="NULL"/>: The function behaves like a call to <see cref="PostThreadMessage"/> with the dwThreadId parameter set to
        /// the identifier of the current thread.
        /// </param>
        /// <param name="msg">
        /// The message to be posted.
        /// </param>
        /// <param name="wParam">
        /// Additional message-specific information.
        /// </param>
        /// <param name="lParam">
        /// Additional message-specific information.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// <see cref="GetLastError"/> returns <see cref="ERROR_NOT_ENOUGH_QUOTA"/> when the limit is hit.
        /// </returns>
        /// <remarks>
        /// When a message is blocked by UIPI the last error, retrieved with <see cref="GetLastError"/>, is set to 5 (access denied).
        /// Messages in a message queue are retrieved by calls to the <see cref="GetMessage"/> or <see cref="PeekMessage"/> function.
        /// Applications that need to communicate using <see cref="HWND_BROADCAST"/> should use the <see cref="RegisterWindowMessage"/> function
        /// to obtain a unique message for inter-application communication.
        /// The system only does marshalling for system messages (those in the range 0 to (<see cref="WM_USER"/>-1)).
        /// To send other messages (those >= <see cref="WM_USER"/>) to another process, you must do custom marshalling.
        /// If you send a message in the range below <see cref="WM_USER"/> to the asynchronous message functions
        /// (<see cref="PostMessage"/>, <see cref="SendNotifyMessage"/>, and <see cref="SendMessageCallback"/>), its message parameters cannot include pointers.
        /// Otherwise, the operation will fail.
        /// The functions will return before the receiving thread has had a chance to process the message and the sender will free the memory before it is used.
        /// Do not post the <see cref="WM_QUIT"/> message using <see cref="PostMessage"/>; use the <see cref="PostQuitMessage"/> function.
        /// An accessibility application can use <see cref="PostMessage"/> to post <see cref="WM_APPCOMMAND"/> messages to the shell to launch applications.
        /// This functionality is not guaranteed to work for other types of applications.
        /// There is a limit of 10,000 posted messages per message queue.
        /// This limit should be sufficiently large.
        /// If your application exceeds the limit, it should be redesigned to avoid consuming so many system resources.
        /// To adjust this limit, modify the following registry key.
        /// HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Windows\USERPostMessageLimit
        /// The minimum acceptable value is 4000.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "PostMessageW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL PostMessage([In] HWND hWnd, [In] WindowMessages msg, [In] WPARAM wParam, [In] LPARAM lParam);

        /// <summary>
        /// <para>
        /// Indicates to the system that a thread has made a request to terminate (quit).
        /// It is typically used in response to a <see cref="WM_DESTROY"/> message.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-postquitmessage"/>
        /// </para>
        /// </summary>
        /// <param name="nExitCode">
        /// The application exit code.
        /// This value is used as the <see cref="MSG.wParam"/> parameter of the <see cref="WM_QUIT"/> message.
        /// </param>
        /// <remarks>
        /// The <see cref="PostQuitMessage"/> function posts a <see cref="WM_QUIT"/> message to the thread's message queue and returns immediately;
        /// the function simply indicates to the system that the thread is requesting to quit at some time in the future.
        /// When the thread retrieves the <see cref="WM_QUIT"/> message from its message queue,
        /// it should exit its message loop and return control to the system.
        /// The exit value returned to the system must be the <see cref="MSG.wParam"/> parameter of the <see cref="WM_QUIT"/> message.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "PostQuitMessage", ExactSpelling = true, SetLastError = true)]
        public static extern void PostQuitMessage([In] int nExitCode);

        /// <summary>
        /// <para>
        /// Posts a message to the message queue of the specified thread. It returns without waiting for the thread to process the message.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-postthreadmessagew"/>
        /// </para>
        /// </summary>
        /// <param name="idThread">
        /// The identifier of the thread to which the message is to be posted.
        /// The function fails if the specified thread does not have a message queue.
        /// The system creates a thread's message queue when the thread makes its first call to one of the User or GDI functions.
        /// For more information, see the Remarks section.
        /// Message posting is subject to UIPI.
        /// The thread of a process can post messages only to posted-message queues of threads in processes of lesser or equal integrity level.
        /// This thread must have the SeTcbPrivilege privilege to post a message to a thread that belongs to a process
        /// with the same locally unique identifier (LUID) but is in a different desktop.
        /// Otherwise, the function fails and returns <see cref="ERROR_INVALID_THREAD_ID"/>.
        /// This thread must either belong to the same desktop as the calling thread or to a process with the same <see cref="LUID"/>.
        /// Otherwise, the function fails and returns <see cref="ERROR_INVALID_THREAD_ID"/>.
        /// </param>
        /// <param name="Msg">
        /// The type of message to be posted.
        /// </param>
        /// <param name="wParam">
        /// Additional message-specific information.
        /// </param>
        /// <param name="lParam">
        /// Additional message-specific information.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// <see cref="GetLastError"/> returns <see cref="ERROR_INVALID_THREAD_ID"/> if <paramref name="idThread"/> is not a valid thread identifier,
        /// or if the thread specified by <paramref name="idThread"/> does not have a message queue.
        /// <see cref="GetLastError"/> returns <see cref="ERROR_NOT_ENOUGH_QUOTA"/> when the message limit is hit.
        /// </returns>
        /// <remarks>
        /// When a message is blocked by UIPI the last error, retrieved with <see cref="GetLastError"/>, is set to 5 (access denied).
        /// The thread to which the message is posted must have created a message queue, or else the call to <see cref="PostThreadMessage"/> fails.
        /// Use the following method to handle this situation.
        /// Create an event object, then create the thread.
        /// Use the <see cref="WaitForSingleObject"/> function to wait for the event to be set to the signaled state before calling <see cref="PostThreadMessage"/>.
        /// In the thread to which the message will be posted, call <see cref="PeekMessage"/> as shown here to force the system to create the message queue.
        /// <code>
        /// PeekMessage(&amp;msg, NULL, WM_USER, WM_USER, PM_NOREMOVE)
        /// </code>
        /// Set the event, to indicate that the thread is ready to receive posted messages.
        /// The thread to which the message is posted retrieves the message by calling the <see cref="GetMessage"/> or <see cref="PeekMessage"/> function.
        /// The <see cref="MSG.hwnd"/> member of the returned <see cref="MSG"/> structure is <see cref="NULL"/>.
        /// Messages sent by <see cref="PostThreadMessage"/> are not associated with a window.
        /// As a general rule, messages that are not associated with a window cannot be dispatched by the <see cref="DispatchMessage"/> function.
        /// Therefore, if the recipient thread is in a modal loop (as used by MessageBox or DialogBox), the messages will be lost.
        /// To intercept thread messages while in a modal loop, use a thread-specific hook.
        /// The system only does marshalling for system messages (those in the range 0 to (<see cref="WM_USER"/>-1)).
        /// To send other messages (those >= <see cref="WM_USER"/>) to another process, you must do custom marshalling.
        /// There is a limit of 10,000 posted messages per message queue.
        /// This limit should be sufficiently large.
        /// If your application exceeds the limit, it should be redesigned to avoid consuming so many system resources.
        /// To adjust this limit, modify the following registry key.
        /// HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Windows\USERPostMessageLimit
        /// The minimum acceptable value is 4000.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "PostThreadMessageW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL PostThreadMessage([In] DWORD idThread, [In] WindowMessages Msg, [In] WPARAM wParam, [In] LPARAM lParam);

        /// <summary>
        /// <para>
        /// Defines a new window message that is guaranteed to be unique throughout the system.
        /// The message value can be used when sending or posting messages.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-registerwindowmessagew"/>
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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegisterWindowMessageW", ExactSpelling = true, SetLastError = true)]
        public static extern UINT RegisterWindowMessage([In] LPCWSTR lpString);

        /// <summary>
        /// <para>
        /// Replies to a message sent from another thread by the <see cref="SendMessage"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-replymessage"/>
        /// </para>
        /// </summary>
        /// <param name="lResult">
        /// The result of the message processing. The possible values are based on the message sent.
        /// </param>
        /// <returns>
        /// If the calling thread was processing a message sent from another thread or process, the return value is <see cref="TRUE"/>.
        /// If the calling thread was not processing a message sent from another thread or process, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// By calling this function, the window procedure that receives the message allows the thread that called <see cref="SendMessage"/>
        /// to continue to run as though the thread receiving the message had returned control.
        /// The thread that calls the <see cref="ReplyMessage"/> function also continues to run.
        /// If the message was not sent through <see cref="SendMessage"/> or if the message was sent by the same thread,
        /// <see cref="ReplyMessage"/> has no effect.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ReplyMessage", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ReplyMessage([In] LRESULT lResult);

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
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-sendmessage"/>
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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SendMessageW", ExactSpelling = true, SetLastError = true)]
        public static extern LRESULT SendMessage([In] HWND hWnd, [In] WindowMessages Msg, [In] WPARAM wParam, [In] LPARAM lParam);

        /// <summary>
        /// <para>
        /// Sends the specified message to a window or windows.
        /// It calls the window procedure for the specified window and returns immediately if the window belongs to another thread.
        /// After the window procedure processes the message, the system calls the specified callback function,
        /// passing the result of the message processing and an application-defined value to the callback function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-sendmessagecallbackw"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose window procedure will receive the message.
        /// If this parameter is <see cref="HWND_BROADCAST"/> ((HWND)0xffff), the message is sent to all top-level windows in the system,
        /// including disabled or invisible unowned windows, overlapped windows, and pop-up windows; but the message is not sent to child windows.
        /// </param>
        /// <param name="Msg">
        /// The message to be sent.
        /// For lists of the system-provided messages, see System-Defined Messages.
        /// </param>
        /// <param name="wParam">
        /// Additional message-specific information.
        /// </param>
        /// <param name="lParam">
        /// Additional message-specific information.
        /// </param>
        /// <param name="lpResultCallBack">
        /// A pointer to a callback function that the system calls after the window procedure processes the message.
        /// For more information, see <see cref="SENDASYNCPROC"/>.
        /// If hWnd is <see cref="HWND_BROADCAST"/> ((HWND)0xffff), the system calls the <see cref="SENDASYNCPROC"/> callback function
        /// once for each top-level window.
        /// </param>
        /// <param name="dwData">
        /// An application-defined value to be sent to the callback function pointed to by the <paramref name="lpResultCallBack"/> parameter.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If the target window belongs to the same thread as the caller, then the window procedure is called synchronously,
        /// and the callback function is called immediately after the window procedure returns.
        /// If the target window belongs to a different thread from the caller, then the callback function is called
        /// only when the thread that called <see cref="SendMessageCallback"/> also calls <see cref="GetMessage"/>,
        /// <see cref="PeekMessage"/>, or <see cref="WaitMessage"/>.
        /// If you send a message in the range below <see cref="WM_USER"/> to the asynchronous message functions
        /// (<see cref="PostMessage"/>, <see cref="SendNotifyMessage"/>, and <see cref="SendMessageCallback"/>),
        /// its message parameters cannot include pointers. Otherwise, the operation will fail.
        /// The functions will return before the receiving thread has had a chance to process the message and the sender will free the memory before it is used.
        /// Applications that need to communicate using <see cref="HWND_BROADCAST"/> should use the <see cref="RegisterWindowMessage"/> function
        /// to obtain a unique message for inter-application communication.
        /// The system only does marshalling for system messages (those in the range 0 to (<see cref="WM_USER"/>-1)).
        /// To send other messages (those >= <see cref="WM_USER"/>) to another process, you must do custom marshalling.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SendMessageCallbackW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SendMessageCallback([In] HWND hWnd, [In] WindowMessages Msg, [In] WPARAM wParam, [In] LPARAM lParam,
            [In] SENDASYNCPROC lpResultCallBack, [In] ULONG_PTR dwData);

        /// <summary>
        /// <para>
        /// Sends the specified message to one or more windows.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-sendmessagetimeoutw"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose window procedure will receive the message.
        /// If this parameter is <see cref="HWND_BROADCAST"/> ((HWND)0xffff), the message is sent to all top-level windows in the system,
        /// including disabled or invisible unowned windows.
        /// The function does not return until each window has timed out.
        /// Therefore, the total wait time can be up to the value of <paramref name="uTimeout"/> multiplied by the number of top-level windows.
        /// </param>
        /// <param name="Msg">
        /// The message to be sent.
        /// For lists of the system-provided messages, see System-Defined Messages.
        /// </param>
        /// <param name="wParam">
        /// Any additional message-specific information.
        /// </param>
        /// <param name="lParam">
        /// Any additional message-specific information.
        /// </param>
        /// <param name="fuFlags">
        /// The behavior of this function. This parameter can be one or more of the following values.
        /// <see cref="SMTO_ABORTIFHUNG"/>, <see cref="SMTO_BLOCK"/>, <see cref="SMTO_NORMAL"/>,
        /// <see cref="SMTO_NOTIMEOUTIFNOTHUNG"/>, <see cref="SMTO_ERRORONEXIT"/>
        /// </param>
        /// <param name="uTimeout">
        /// The duration of the time-out period, in milliseconds.
        /// If the message is a broadcast message, each window can use the full time-out period.
        /// For example, if you specify a five second time-out period and there are three top-level windows that fail to process the message,
        /// you could have up to a 15 second delay.
        /// </param>
        /// <param name="lpdwResult">
        /// The result of the message processing. The value of this parameter depends on the message that is specified.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// <see cref="SendMessageTimeout"/> does not provide information about individual windows timing out if <see cref="HWND_BROADCAST"/> is used.
        /// If the function fails or times out, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If <see cref="GetLastError"/> returns <see cref="ERROR_TIMEOUT"/>, then the function timed out.
        /// Windows 2000: If <see cref="GetLastError"/> returns 0, then the function timed out.
        /// </returns>
        /// <remarks>
        /// The function calls the window procedure for the specified window and, if the specified window belongs to a different thread,
        /// does not return until the window procedure has processed the message or the specified time-out period has elapsed.
        /// If the window receiving the message belongs to the same queue as the current thread,
        /// the window procedure is called directly—the time-out value is ignored.
        /// This function considers that a thread is not responding if it has not called <see cref="GetMessage"/> or a similar function within five seconds.
        /// The system only does marshalling for system messages (those in the range 0 to (<see cref="WM_USER"/>-1)).
        /// To send other messages (those >= <see cref="WM_USER"/>) to another process, you must do custom marshalling.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SendMessageTimeoutW", ExactSpelling = true, SetLastError = true)]
        public static extern LRESULT SendMessageTimeout([In] HWND hWnd, [In] WindowMessages Msg, [In] WPARAM wParam, [In] LPARAM lParam,
            [In] SendMessageTimeoutFlags fuFlags, [In] UINT uTimeout, [Out] out DWORD_PTR lpdwResult);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cMessagesMax"></param>
        /// <returns></returns>
        [Obsolete]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetMessageQueue", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetMessageQueue(int cMessagesMax);

        /// <summary>
        /// <para>
        /// Sends the specified message to a window or windows.
        /// If the window was created by the calling thread, <see cref="SendNotifyMessage"/> calls the window procedure for the window
        /// and does not return until the window procedure has processed the message.
        /// If the window was created by a different thread, <see cref="SendNotifyMessage"/> passes the message to the window procedure and returns immediately;
        /// it does not wait for the window procedure to finish processing the message.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-sendnotifymessagew"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose window procedure will receive the message.
        /// If this parameter is <see cref="HWND_BROADCAST"/> ((HWND)0xffff), the message is sent to all top-level windows in the system,
        /// including disabled or invisible unowned windows, overlapped windows, and pop-up windows; but the message is not sent to child windows.
        /// </param>
        /// <param name="Msg">
        /// The message to be sent.
        /// For lists of the system-provided messages, see System-Defined Messages.
        /// </param>
        /// <param name="wParam">
        /// Additional message-specific information.
        /// </param>
        /// <param name="lParam">
        /// Additional message-specific information.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If you send a message in the range below <see cref="WM_USER"/> to the asynchronous message functions
        /// (<see cref="PostMessage"/>, <see cref="SendNotifyMessage"/>, and <see cref="SendMessageCallback"/>),
        /// its message parameters cannot include pointers.
        /// Otherwise, the operation will fail. The functions will return before the receiving thread has had a chance
        /// to process the message and the sender will free the memory before it is used.
        /// Applications that need to communicate using <see cref="HWND_BROADCAST"/> should use the <see cref="RegisterWindowMessage"/> function
        /// to obtain a unique message for inter-application communication.
        /// The system only does marshalling for system messages (those in the range 0 to (<see cref="WM_USER"/>-1)).
        /// To send other messages (those >= <see cref="WM_USER"/>) to another process, you must do custom marshalling.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SendNotifyMessageW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SendNotifyMessage([In] HWND hWnd, [In] WindowMessages Msg, [In] WPARAM wParam, [In] LPARAM lParam);

        /// <summary>
        /// <para>
        /// Sets the extra message information for the current thread.
        /// Extra message information is an application- or driver-defined value associated with the current thread's message queue.
        /// An application can use the <see cref="GetMessageExtraInfo"/> function to retrieve a thread's extra message information.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setmessageextrainfo"/>
        /// </para>
        /// </summary>
        /// <param name="lParam">
        /// The value to be associated with the current thread.
        /// </param>
        /// <returns>
        /// The return value is the previous value associated with the current thread.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetMessageExtraInfo", ExactSpelling = true, SetLastError = true)]
        public static extern LPARAM SetMessageExtraInfo([In] LPARAM lParam);

        /// <summary>
        /// <para>
        /// Processes accelerator keystrokes for window menu commands of the multiple-document interface (MDI) child windows
        /// associated with the specified MDI client window.
        /// The function translates <see cref="WM_KEYUP"/> and <see cref="WM_KEYDOWN"/> messages to <see cref="WM_SYSCOMMAND"/> messages
        /// and sends them to the appropriate MDI child windows.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-translatemdisysaccel"/>
        /// </para>
        /// </summary>
        /// <param name="hWndClient">
        /// A handle to the MDI client window.
        /// </param>
        /// <param name="lpMsg">
        /// A pointer to a message retrieved by using the <see cref="GetMessage"/> or <see cref="PeekMessage"/> function.
        /// The message must be an <see cref="MSG"/> structure and contain message information from the application's message queue.
        /// </param>
        /// <returns>
        /// If the message is translated into a system command, the return value is <see cref="TRUE"/>.
        /// If the message is not translated into a system command, the return value is <see cref="FALSE"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "TranslateMDISysAccel", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL TranslateMDISysAccel([In] HWND hWndClient, [In][Out] ref MSG lpMsg);

        /// <summary>
        /// <para>
        /// Translates virtual-key messages into character messages.
        /// The character messages are posted to the calling thread's message queue, 
        /// to be read the next time the thread calls the <see cref="GetMessage"/> or <see cref="PeekMessage"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-translatemessage"/>
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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "TranslateMessage", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL TranslateMessage([In] in MSG lpMsg);

        /// <summary>
        /// <para>
        /// Yields control to other threads when a thread has no other messages in its message queue.
        /// The <see cref="WaitMessage"/> function suspends the thread and does not return until a new message is placed in the thread's message queue.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-waitmessage"/>
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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "WaitMessage", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL WaitMessage();
    }
}
