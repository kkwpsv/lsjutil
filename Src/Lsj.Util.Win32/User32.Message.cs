using Lsj.Util.Win32.Attributes;
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
using static Lsj.Util.Win32.Enums.MessageFilterActions;
using static Lsj.Util.Win32.Enums.MsgWaitForMultipleObjectsExTypes;
using static Lsj.Util.Win32.Enums.PeekMessageFlags;
using static Lsj.Util.Win32.Enums.PrivilegeConstants;
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
        /// An application-defined callback function used with the <see cref="SendMessageCallback"/> function.
        /// The system passes the message to the callback function after passing the message to the destination window procedure.
        /// The <see cref="SENDASYNCPROC"/> type defines a pointer to this callback function.
        /// SendAsyncProc is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nc-winuser-sendasyncproc"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1">
        /// <para>
        /// A handle to the window whose window procedure received the message.
        /// This parameter is typically named <c>hWnd</c>.
        /// </para>
        /// <para>
        /// If the <see cref="SendMessageCallback"/> function was called with its <c>hWnd</c> parameter set to <see cref="HWND_BROADCAST"/>,
        /// the system calls the <c>SendAsyncProc</c>function once for each top-level window.
        /// </para>
        /// </param>
        /// <param name="unnamedParam2">
        /// The message.
        /// This parameter is typically named <c>uMsg</c>.
        /// </param>
        /// <param name="unnamedParam3">
        /// An application-defined value sent from the <see cref="SendMessageCallback"/> function.
        /// This parameter is typically named <c>dwData</c>.
        /// </param>
        /// <param name="unnamedParam4">
        /// The result of the message processing.
        /// This value depends on the message.
        /// This parameter is typically named <c>lResult</c>.
        /// </param>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// The parameters are defined in the header with no names: <c>typedef VOID (CALLBACK* SENDASYNCPROC)(HWND, UINT, ULONG_PTR, LRESULT);</c>.
        /// Therefore, the syntax block lists them as <c>unnamedParam1</c> - <c>unnamedParam4</c>.
        /// You can name these parameters anything in your app.
        /// However, they are usually named as shown in the parameter descriptions.
        /// </para>
        /// <para>
        /// You install a <c>SendAsyncProc</c> application-defined callback function
        /// by passing a <see cref="SENDASYNCPROC"/> pointer to the <see cref="SendMessageCallback"/> function.
        /// </para>
        /// <para>
        /// The callback function is only called when the thread that called <see cref="SendMessageCallback"/> calls
        /// <see cref="GetMessage"/>, <see cref="PeekMessage"/>, or <see cref="WaitMessage"/>.
        /// </para>
        /// </remarks>
        public delegate void Sendasyncproc([In] HWND unnamedParam1, [In] WindowMessages unnamedParam2, [In] ULONG_PTR unnamedParam3, [In] LRESULT unnamedParam4);


        /// <summary>
        /// <para>
        /// Sends a message to the specified recipients.
        /// The recipients can be applications, installable drivers, network drivers, system-level device drivers, or any combination of these system components.
        /// </para>
        /// <para>
        /// To receive additional information if the request is defined, use the <see cref="BroadcastSystemMessageEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-broadcastsystemmessagew"/>
        /// </para>
        /// </summary>
        /// <param name="flags">
        /// <para>
        /// The broadcast option.
        /// This parameter can be one or more of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="BSF_ALLOWSFW"/>
        /// </para>
        /// <para>
        /// 0x00000080
        /// </para>
        /// </term>
        /// <term>
        /// Enables the recipient to set the foreground window while processing the message.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BSF_FLUSHDISK"/>
        /// </para>
        /// <para>
        /// 0x00000004
        /// </para>
        /// </term>
        /// <term>
        /// Flushes the disk after each recipient processes the message.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BSF_FORCEIFHUNG"/>
        /// </para>
        /// <para>
        /// 0x00000020
        /// </para>
        /// </term>
        /// <term>
        /// Continues to broadcast the message, even if the time-out period elapses or one of the recipients is not responding.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BSF_IGNORECURRENTTASK"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// Does not send the message to windows that belong to the current task.
        /// This prevents an application from receiving its own message.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BSF_NOHANG"/>
        /// </para>
        /// <para>
        /// 0x00000008
        /// </para>
        /// </term>
        /// <term>
        /// Forces a nonresponsive application to time out. If one of the recipients times out, do not continue broadcasting the message.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BSF_NOTIMEOUTIFNOTHUNG"/>
        /// </para>
        /// <para>
        /// 0x00000040
        /// </para>
        /// </term>
        /// <term>
        /// Waits for a response to the message, as long as the recipient is not being unresponsive. Does not time out.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BSF_POSTMESSAGE"/>
        /// </para>
        /// <para>
        /// 0x00000010
        /// </para>
        /// </term>
        /// <term>
        /// Posts the message. Do not use in combination with <see cref="BSF_QUERY"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BSF_QUERY"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// Sends the message to one recipient at a time, sending to a subsequent recipient only if the current recipient returns <see cref="TRUE"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BSF_SENDNOTIFYMESSAGE"/>
        /// </para>
        /// <para>
        /// 0x00000100
        /// </para>
        /// </term>
        /// <term>
        /// Sends the message using <see cref="SendNotifyMessage"/> function. Do not use in combination with <see cref="BSF_QUERY"/>.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpInfo">
        /// <para>
        /// A pointer to a variable that contains and receives information about the recipients of the message.
        /// </para>
        /// <para>
        /// When the function returns, this variable receives a combination of these values identifying which recipients actually received the message.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NULL"/>, the function broadcasts to all components.
        /// </para>
        /// <para>
        /// This parameter can be one or more of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="BSM_ALLCOMPONENTS"/>
        /// </para>
        /// <para>
        /// 0x00000000
        /// </para>
        /// </term>
        /// <term>
        /// Broadcast to all system components.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BSM_ALLDESKTOPS"/>
        /// </para>
        /// <para>
        /// 0x00000010
        /// </para>
        /// </term>
        /// <term>
        /// Broadcast to all desktops.
        /// Requires the <see cref="SE_TCB_NAME"/> privilege.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BSM_APPLICATIONS"/>
        /// </para>
        /// <para>
        /// 0x00000008
        /// </para>
        /// </term>
        /// <term>
        /// Broadcast to applications.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="Msg">
        /// <para>
        /// The message to be sent.
        /// </para>
        /// <para>
        /// For lists of the system-provided messages, see System-Defined Messages.
        /// </para>
        /// </param>
        /// <param name="wParam">
        /// Additional message-specific information.
        /// </param>
        /// <param name="lParam">
        /// Additional message-specific information.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a positive value.
        /// </para>
        /// <para>
        /// If the function is unable to broadcast the message, the return value is –1.
        /// </para>
        /// <para>
        /// If the <paramref name="flags"/> parameter is <see cref="BSF_QUERY"/>
        /// and at least one recipient returned <see cref="BROADCAST_QUERY_DENY"/> to the corresponding message, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If <see cref="BSF_QUERY"/> is not specified, the function sends the specified message to all requested recipients, ignoring values returned by those recipients.
        /// </para>
        /// <para>
        /// The system only does marshalling for system messages (those in the range 0 to (<see cref="WM_USER"/>-1)).
        /// To send other messages (those &gt;= <see cref="WM_USER"/>) to another process, you must do custom marshalling.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "BroadcastSystemMessageW", ExactSpelling = true, SetLastError = true)]
        public static extern LONG BroadcastSystemMessage([In] BroadcastSystemMessageFlags flags, [In][Out] ref BroadcastSystemMessageRecipients lpInfo,
            [In] WindowMessages Msg, [In] WPARAM wParam, [In] LPARAM lParam);

        /// <summary>
        /// <para>
        /// <para>
        /// Sends a message to the specified recipients.
        /// The recipients can be applications, installable drivers, network drivers, system-level device drivers, or any combination of these system components.
        /// </para>
        /// <para>
        /// This function is similar to <see cref="BroadcastSystemMessage"/> except that this function can return more information from the recipients.
        /// </para>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-broadcastsystemmessageexw"/>
        /// </para>
        /// </summary>
        /// <param name="flags">
        /// <para>
        /// The broadcast option. This parameter can be one or more of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="BSF_ALLOWSFW"/>
        /// </para>
        /// <para>
        /// 0x00000080
        /// </para>
        /// </term>
        /// <term>
        /// Enables the recipient to set the foreground window while processing the message.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BSF_FLUSHDISK"/>
        /// </para>
        /// <para>
        /// 0x00000004
        /// </para>
        /// </term>
        /// <term>
        /// Flushes the disk after each recipient processes the message.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BSF_FORCEIFHUNG"/>
        /// </para>
        /// <para>
        /// 0x00000020
        /// </para>
        /// </term>
        /// <term>
        /// Continues to broadcast the message, even if the time-out period elapses or one of the recipients is not responding.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BSF_IGNORECURRENTTASK"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// Does not send the message to windows that belong to the current task.
        /// This prevents an application from receiving its own message.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BSF_LUID"/>
        /// </para>
        /// <para>
        /// 0x00000400
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// If <see cref="BSF_LUID"/> is set, the message is sent to the window that has the same LUID
        /// as specified in the <see cref="BSMINFO.luid"/> member of the <see cref="BSMINFO"/> structure.
        /// </para>
        /// <para>
        /// Windows 2000:  This flag is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BSF_NOHANG"/>
        /// </para>
        /// <para>
        /// 0x00000008
        /// </para>
        /// </term>
        /// <term>
        /// Forces a nonresponsive application to time out.
        /// If one of the recipients times out, do not continue broadcasting the message.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BSF_NOTIMEOUTIFNOTHUNG"/>
        /// </para>
        /// <para>
        /// 0x00000040
        /// </para>
        /// </term>
        /// <term>
        /// Waits for a response to the message, as long as the recipient is not being unresponsive.
        /// Does not time out.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BSF_POSTMESSAGE"/>
        /// </para>
        /// <para>
        /// 0x00000010
        /// </para>
        /// </term>
        /// <term>
        /// Posts the message. Do not use in combination with <see cref="BSF_QUERY"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BSF_RETURNHDESK"/>
        /// </para>
        /// <para>
        /// 0x00000200
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// If access is denied and both this and <see cref="BSF_QUERY"/> are set,
        /// <see cref="BSMINFO"/> returns both the desktop handle and the window handle.
        /// If access is denied and only <see cref="BSF_QUERY"/> is set, only the window handle is returned by <see cref="BSMINFO"/>.
        /// </para>
        /// <para>
        /// Windows 2000:  This flag is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BSF_QUERY"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// Sends the message to one recipient at a time, sending to a subsequent recipient only if the current recipient returns <see cref="TRUE"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BSF_SENDNOTIFYMESSAGE"/>
        /// </para>
        /// <para>
        /// 0x00000100
        /// </para>
        /// </term>
        /// <term>
        /// Sends the message using <see cref="SendNotifyMessage"/> function. Do not use in combination with <see cref="BSF_QUERY"/>.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpInfo">
        /// <para>
        /// A pointer to a variable that contains and receives information about the recipients of the message.
        /// </para>
        /// <para>
        /// When the function returns, this variable receives a combination of these values identifying which recipients actually received the message.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NullRef{BroadcastSystemMessageRecipients}"/>, the function broadcasts to all components.
        /// </para>
        /// <para>
        /// This parameter can be one or more of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="BSM_ALLCOMPONENTS"/>
        /// </para>
        /// <para>
        /// 0x00000000
        /// </para>
        /// </term>
        /// <term>
        /// Broadcast to all system components.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BSM_ALLDESKTOPS"/>
        /// </para>
        /// <para>
        /// 0x00000010
        /// </para>
        /// </term>
        /// <term>
        /// Broadcast to all desktops. Requires the <see cref="SE_TCB_NAME"/> privilege.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="BSM_APPLICATIONS"/>
        /// </para>
        /// <para>
        /// 0x00000008
        /// </para>
        /// </term>
        /// <term>
        /// Broadcast to applications.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="Msg">
        /// <para>
        /// The message to be sent.
        /// </para>
        /// <para>
        /// For lists of the system-provided messages, see System-Defined Messages.
        /// </para>
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
        /// <para>
        /// If the function succeeds, the return value is a positive value.
        /// </para>
        /// <para>
        /// If the function is unable to broadcast the message, the return value is –1.
        /// </para>
        /// <para>
        /// If the <paramref name="flags"/> parameter is <see cref="BSF_QUERY"/>
        /// and at least one recipient returned <see cref="BROADCAST_QUERY_DENY"/> to the corresponding message, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If <see cref="BSF_QUERY"/> is not specified, the function sends the specified message to all requested recipients, ignoring values returned by those recipients.
        /// </para>
        /// <para>
        /// If the caller's thread is on a desktop other than that of the window that denied the request,
        /// the caller must call <c>SetThreadDesktop(hdesk)</c> to query anything on that window.
        /// Also, the caller must call <see cref="CloseDesktop"/> on the returned <c>hdesk</c> handle.
        /// </para>
        /// <para>
        /// The system only does marshalling for system messages (those in the range 0 to (<see cref="WM_USER"/>-1)).
        /// To send other messages (those &gt;= <see cref="WM_USER"/>) to another process, you must do custom marshalling.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
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
        /// <para>
        /// If the application should process the message further, the return value is zero.
        /// </para>
        /// <para>
        /// If the application should not process the message further, the return value is nonzero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// he system calls <see cref="CallMsgFilter"/> to enable applications to examine and control the flow of messages
        /// during internal processing of dialog boxes, message boxes, menus, and scroll bars,
        /// or when the user activates a different window by pressing the ALT+TAB key combination.
        /// </para>
        /// <para>
        /// Install this hook procedure by using the <see cref="SetWindowsHookEx"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallMsgFilterW", ExactSpelling = true)]
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
        /// <para>
        /// Hook procedures are installed in chains for particular hook types. <see cref="CallNextHookEx"/> calls the next hook in the chain.
        /// </para>
        /// <para>
        /// Calling <see cref="CallNextHookEx"/> is optional, but it is highly recommended;
        /// otherwise, other applications that have installed hooks will not receive hook notifications and may behave incorrectly as a result.
        /// You should call <see cref="CallNextHookEx"/> unless you absolutely need to prevent the notification from being seen by other applications.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
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
        /// <para>
        /// Use the <see cref="CallWindowProc"/> function for window subclassing.
        /// Usually, all windows with the same class share one window procedure.
        /// A subclass is a window or set of windows with the same class whose messages are intercepted and processed
        /// by another window procedure (or procedures) before being passed to the window procedure of the class.
        /// </para>
        /// <para>
        /// The <see cref="SetWindowLong"/> function creates the subclass by changing the window procedure associated with a particular window,
        /// causing the system to call the new window procedure instead of the previous one.
        /// An application must pass any messages not processed by the new window procedure to the previous window procedure by calling <see cref="CallWindowProc"/>.
        /// This allows the application to create a chain of window procedures.
        /// </para>
        /// <para>
        /// If <c>STRICT</c> is defined, the <paramref name="lpPrevWndFunc"/> parameter has the data type <see cref="WNDPROC"/>.
        /// The <see cref="WNDPROC"/> type is declared as follows:
        /// </para>
        /// <code>
        /// LRESULT (CALLBACK* WNDPROC) (HWND, UINT, WPARAM, LPARAM);
        /// </code>
        /// <para>
        /// If <c>STRICT</c> is not defined, the <paramref name="lpPrevWndFunc"/> parameter has the data type <see cref="FARPROC"/>.
        /// The <see cref="FARPROC"/> type is declared as follows:
        /// </para>
        /// <code>
        /// int (FAR WINAPI * FARPROC) ()
        /// </code>
        /// <para>
        /// In C, the <see cref="FARPROC"/> declaration indicates a callback function that has an unspecified parameter list.
        /// In C++, however, the empty parameter list in the declaration indicates that a function has no parameters.
        /// This subtle distinction can break careless code.
        /// Following is one way to handle this situation:
        /// </para>
        /// <code>
        /// #ifdef STRICT 
        ///   WNDPROC MyWindowProcedure 
        /// #else 
        ///   FARPROC MyWindowProcedure 
        /// #endif 
        /// ... 
        ///   lResult = CallWindowProc(MyWindowProcedure, ...) ;
        /// </code>
        /// <para>
        /// For further information about functions declared with empty argument lists, refer to The C++ Programming Language, Second Edition, by Bjarne Stroustrup.
        /// </para>
        /// <para>
        /// The <see cref="CallWindowProc"/> function handles Unicode-to-ANSI conversion.
        /// You cannot take advantage of this conversion if you call the window procedure directly.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallWindowProcW", ExactSpelling = true)]
        public static extern LRESULT CallWindowProc([In] WNDPROC lpPrevWndFunc, [In] HWND hWnd, [In] WindowMessages Msg, [In] WPARAM wParam, [In] LPARAM lParam);

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
        /// <para>
        /// The action to be performed.
        /// One of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="MSGFLT_ADD"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// Adds the <paramref name="message"/> to the filter.
        /// This has the effect of allowing the message to be received.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MSGFLT_REMOVE"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// Removes the <paramref name="message"/> from the filter.
        /// This has the effect of blocking the message.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// <see cref="TRUE"/> if successful; otherwise, <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>>
        /// Note
        /// </para>
        /// <para>
        /// A message can be successfully removed from the filter, but that is not a guarantee that the message will be blocked.
        /// See the Remarks section for more details.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// UIPI is a security feature that prevents messages from being received from a lower integrity level sender.
        /// All such messages with a value above <see cref="WM_USER"/> are blocked by default.
        /// The filter, somewhat contrary to intuition, is a list of messages that are allowed through.
        /// Therefore, adding a message to the filter allows that message to be received from a lower integrity sender,
        /// while removing a message blocks that message from being received.
        /// </para>
        /// <para>
        /// Certain messages with a value less than <see cref="WM_USER"/> are required to pass through the filter regardless of the filter setting.
        /// You can call this function to remove one of those messages from the filter and it will return <see cref="TRUE"/>.
        /// However, the message will still be received by the calling process.
        /// </para>
        /// <para>
        /// Processes at or below <see cref="SECURITY_MANDATORY_LOW_RID"/> are not allowed to change the filter.
        /// If those processes call this function, it will fail.
        /// </para>
        /// <para>
        /// For more information on integrity levels, see Understanding and Working in Protected Mode Internet Explorer.
        /// </para>
        /// </remarks>
        [Obsolete("Using the ChangeWindowMessageFilter function is not recommended, as it has process-wide scope." +
            "Instead, use the ChangeWindowMessageFilterEx function to control access to specific windows as needed." +
            "ChangeWindowMessageFilter may not be supported in future versions of Windows.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ChangeWindowMessageFilter", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ChangeWindowMessageFilter([In] WindowMessages message, [In] MessageFilterActions dwFlag);

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
        /// The message that the message filter allows through or blocks.
        /// </param>
        /// <param name="action">
        /// <para>
        /// The action to be performed, and can take one of the following values:
        /// </para>
        /// <para>
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
        /// <see cref="MSGFLT_ALLOW"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// Allows the message through the filter.
        /// This enables the message to be received by <paramref name="hwnd"/>,
        /// regardless of the source of the message, even it comes from a lower privileged process.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MSGFLT_DISALLOW"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// Blocks the message to be delivered to <paramref name="hwnd"/> if it comes from a lower privileged process,
        /// unless the message is allowed process-wide by using the <see cref="ChangeWindowMessageFilter"/> function or globally.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MSGFLT_RESET"/>
        /// </para>
        /// <para>
        /// 0
        /// </para>
        /// </term>
        /// <term>
        /// Resets the window message filter for <paramref name="hwnd"/> to the default.
        /// Any message allowed globally or process-wide will get through, but any message not included in those two categories,
        /// and which comes from a lower privileged process, will be blocked.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="pChangeFilterStruct">
        /// Optional pointer to a <see cref="CHANGEFILTERSTRUCT"/> structure.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns <see cref="TRUE"/>; otherwise, it returns <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// UIPI is a security feature that prevents messages from being received from a lower-integrity-level sender.
        /// You can use this function to allow specific messages to be delivered to a window
        /// even if the message originates from a process at a lower integrity level.
        /// Unlike the <see cref="ChangeWindowMessageFilter"/> function, which controls the process message filter,
        /// the <see cref="ChangeWindowMessageFilterEx"/> function controls the window message filter.
        /// </para>
        /// <para>
        /// An application may use the <see cref="ChangeWindowMessageFilter"/> function to allow or block a message in a process-wide manner.
        /// If the message is allowed by either the process message filter or the window message filter, it will be delivered to the window.
        /// </para>
        /// <para>
        /// Note that processes at or below <see cref="SECURITY_MANDATORY_LOW_RID"/> are not allowed to change the message filter.
        /// If those processes call this function, it will fail and generate the extended error code, <see cref="ERROR_ACCESS_DENIED"/>.
        /// </para>
        /// <para>
        /// Certain messages whose value is smaller than <see cref="WM_USER"/> are required to be passed through the filter, regardless of the filter setting.
        /// There will be no effect when you attempt to use this function to allow or block such messages.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ChangeWindowMessageFilterEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ChangeWindowMessageFilterEx([In] HWND hwnd, [In] WindowMessages message,
            [In] MessageFilterActions action, [In][Out] ref CHANGEFILTERSTRUCT pChangeFilterStruct);

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
        /// <para>
        /// The <see cref="MSG"/> structure must contain valid message values.
        /// If the <paramref name="lpmsg"/> parameter points to a <see cref="WM_TIMER"/> message
        /// and the <c>lParam</c> parameter of the <see cref="WM_TIMER"/> message is not <see cref="NULL"/>,
        /// <c>lParam</c> points to a function that is called instead of the window procedure.
        /// </para>
        /// <para>
        /// Note that the application is responsible for retrieving and dispatching input messages to the dialog box.
        /// Most applications use the main message loop for this.
        /// However, to permit the user to move to and to select controls by using the keyboard,
        /// the application must call <see cref="IsDialogMessage"/>.
        /// For more information, see Dialog Box Keyboard Interface.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DispatchMessageW", ExactSpelling = true)]
        public static extern LRESULT DispatchMessage([In] in MSG lpmsg);

        /// <summary>
        /// <para>
        /// Retrieves a message from the calling thread's message queue.
        /// The function dispatches incoming sent messages until a posted message is available for retrieval.
        /// </para>
        /// <para>
        /// Unlike <see cref="GetMessage"/>, the <see cref="PeekMessage"/> function does not wait for a message to be posted before returning.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getmessagew"/>
        /// </para>
        /// </summary>
        /// <param name="lpMsg">
        /// A <see cref="MSG"/> structure that receives message information from the thread's message queue.
        /// </param>
        /// <param name="hWnd">
        /// <para>
        /// A handle to the window whose messages are to be retrieved. The window must belong to the current thread.
        /// </para>
        /// <para>
        /// If <paramref name="hWnd"/> is <see cref="NULL"/>, <see cref="GetMessage"/> retrieves messages for any window
        /// that belongs to the current thread, and any messages on the current thread's message queue
        /// whose <see cref="MSG.hwnd"/> value is <see cref="NULL"/> (see the <see cref="MSG"/> structure).
        /// Therefore if <paramref name="hWnd"/> is <see cref="NULL"/>, both window messages and thread messages are processed.
        /// </para>
        /// <para>
        /// If <paramref name="hWnd"/> is -1, <see cref="GetMessage"/> retrieves only messages on the current thread's message queue
        /// whose <see cref="MSG.hwnd"/> value is <see cref="NULL"/>, that is, thread messages as posted by <see cref="PostMessage"/>
        /// (when the <paramref name="hWnd"/> parameter is <see cref="NULL"/>) or <see cref="PostThreadMessage"/>.
        /// </para>
        /// </param>
        /// <param name="wMsgFilterMin">
        /// <para>
        /// The integer value of the lowest message value to be retrieved.
        /// Use <see cref="WM_KEYFIRST"/> (0x0100) to specify the first keyboard message
        /// or <see cref="WM_MOUSEFIRST"/> (0x0200) to specify the first mouse message.
        /// </para>
        /// <para>
        /// Use <see cref="WM_INPUT"/> here and in <paramref name="wMsgFilterMax"/> to specify only the <see cref="WM_INPUT"/> messages.
        /// </para>
        /// <para>
        /// If <paramref name="wMsgFilterMin"/> and <paramref name="wMsgFilterMax"/> are both zero,
        /// <see cref="GetMessage"/> returns all available messages (that is, no range filtering is performed).
        /// </para>
        /// </param>
        /// <param name="wMsgFilterMax">
        /// <para>
        /// The integer value of the highest message value to be retrieved.
        /// Use <see cref="WM_KEYLAST"/> to specify the last keyboard message
        /// or <see cref="WM_MOUSELAST"/> to specify the last mouse message.
        /// </para>
        /// <para>
        /// Use <see cref="WM_INPUT"/> here and in <paramref name="wMsgFilterMin"/> to specify only the <see cref="WM_INPUT"/> messages.
        /// </para>
        /// <para>
        /// If <paramref name="wMsgFilterMin"/> and <paramref name="wMsgFilterMax"/> are both zero,
        /// <see cref="GetMessage"/> returns all available messages (that is, no range filtering is performed).
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function retrieves a message other than <see cref="WM_QUIT"/>, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function retrieves the <see cref="WM_QUIT"/> message, the return value is zero.
        /// </para>
        /// <para>
        /// If there is an error, the return value is -1.
        /// For example, the function fails if <paramref name="hWnd"/> is an invalid window handle or <paramref name="lpMsg"/> is an invalid pointer.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// Because the return value can be nonzero, zero, or -1, avoid code like this:
        /// </para>
        /// <code>
        /// while (GetMessage( lpMsg, hWnd, 0, 0)) ...
        /// </code>
        /// <para>
        /// The possibility of a -1 return value in the case that <paramref name="hWnd"/> is an invalid paramete
        /// r (such as referring to a window that has already been destroyed) means that such code can lead to fatal application errors.
        /// Instead, use code like this:
        /// </para>
        /// <code>
        /// BOOL bRet;
        /// 
        /// while( (bRet = GetMessage( &amp;msg, hWnd, 0, 0 )) != 0)
        /// { 
        ///     if (bRet == -1)
        ///     {
        ///         // handle the error and possibly exit
        ///     }
        ///     else
        ///     {
        ///         TranslateMessage(&amp;msg); 
        ///         DispatchMessage(&amp;msg); 
        ///     }
        /// }
        /// </code>
        /// </returns>
        /// <remarks>
        /// <para>
        /// An application typically uses the return value to determine whether to end the main message loop and exit the program.
        /// </para>
        /// <para>
        /// The <see cref="GetMessage"/> function retrieves messages associated with the window
        /// identified by the <paramref name="hWnd"/> parameter or any of its children, as specified by the <see cref="IsChild"/> function,
        /// and within the range of message values given by the <paramref name="wMsgFilterMin"/> and <paramref name="wMsgFilterMax"/> parameters.
        /// Note that an application can only use the low word in the <paramref name="wMsgFilterMin"/> and <paramref name="wMsgFilterMax"/> parameters;
        /// the high word is reserved for the system.
        /// </para>
        /// <para>
        /// Note that <see cref="GetMessage"/> always retrieves <see cref="WM_QUIT"/> messages,
        /// no matter which values you specify for <paramref name="wMsgFilterMin"/> and <paramref name="wMsgFilterMax"/>.
        /// </para>
        /// <para>
        /// During this call, the system delivers pending, nonqueued messages, that is, messages sent to windows
        /// owned by the calling thread using the <see cref="SendMessage"/>, <see cref="SendMessageCallback"/>,
        /// <see cref="SendMessageTimeout"/>, or <see cref="SendNotifyMessage"/> function.
        /// Then the first queued message that matches the specified filter is retrieved.
        /// The system may also process internal events.
        /// If no filter is specified, messages are processed in the following order:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Sent messages
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Posted messages
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Input (hardware) messages and system internal events
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Sent messages (again)
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="WM_PAINT"/> messages
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="WM_TIMER"/> messages
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// To retrieve input messages before posted messages,
        /// use the <paramref name="wMsgFilterMin"/> and <paramref name="wMsgFilterMax"/> parameters.
        /// </para>
        /// <para>
        /// <see cref="GetMessage"/> does not remove <see cref="WM_PAINT"/> messages from the queue.
        /// The messages remain in the queue until processed.
        /// </para>
        /// <para>
        /// If a top-level window stops responding to messages for more than several seconds,
        /// the system considers the window to be not responding and replaces it with a ghost window
        /// that has the same z-order, location, size, and visual attributes.
        /// This allows the user to move it, resize it, or even close the application.
        /// However, these are the only actions available because the application is actually not responding.
        /// When in the debugger mode, the system does not generate a ghost window.
        /// </para>
        /// <para>
        /// DPI Virtualization
        /// </para>
        /// <para>
        /// This API does not participate in DPI virtualization.
        /// The output is in the mode of the window that the message is targeting.
        /// The calling thread is not taken into consideration.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
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
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMessageExtraInfo", ExactSpelling = true)]
        public static extern LPARAM GetMessageExtraInfo();

        /// <summary>
        /// <para>
        /// Retrieves the cursor position for the last message retrieved by the <see cref="GetMessage"/> function.
        /// </para>
        /// <para>
        /// To determine the current position of the cursor, use the <see cref="GetCursorPos"/> function.
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
        /// <para>
        /// As noted above, the x-coordinate is in the low-order short of the return value;
        /// the y-coordinate is in the high-order short (both represent signed values because they can take negative values on systems with multiple monitors).
        /// If the return value is assigned to a variable, you can use the <see cref="MAKEPOINTS"/> macro
        /// to obtain a <see cref="POINTS"/> structure from the return value.
        /// You can also use the <see cref="GET_X_LPARAM"/> or <see cref="GET_Y_LPARAM"/> macro to extract the x- or y-coordinate.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Do not use the <see cref="LOWORD"/> or <see cref="HIWORD"/> macros to extract the x- and y- coordinates of the cursor position
        /// because these macros return incorrect results on systems with multiple monitors.
        /// Systems with multiple monitors can have negative x- and y- coordinates,
        /// and <see cref="LOWORD"/> and <see cref="HIWORD"/> treat the coordinates as unsigned quantities.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMessagePos", ExactSpelling = true)]
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
        /// <para>
        /// The return value from the <see cref="GetMessageTime"/> function does not necessarily increase between subsequent messages,
        /// because the value wraps to the minimum value for a long integer if the timer count exceeds the maximum value for a long integer.
        /// </para>
        /// <para>
        /// To calculate time delays between messages, subtract the time of the first message from the time of the second message (ignoring overflow)
        /// and compare the result of the subtraction against the desired delay amount.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMessageTime", ExactSpelling = true)]
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
        /// <para>
        /// The types of messages for which to check.
        /// This parameter can be one or more of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="QS_KEY"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// A <see cref="WM_KEYUP"/>, <see cref="WM_KEYDOWN"/>, <see cref="WM_SYSKEYUP"/>,
        /// or <see cref="WM_SYSKEYDOWN"/> message is in the queue.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="QS_MOUSEMOVE"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// A <see cref="WM_MOUSEMOVE"/> message is in the queue.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="QS_MOUSEBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// A mouse-button message (<see cref="WM_LBUTTONUP"/>, <see cref="WM_RBUTTONDOWN"/>, and so on).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="QS_POSTMESSAGE"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// A posted message (other than those listed here) is in the queue.
        /// For more information, see <see cref="PostMessage"/>.
        /// </para>
        /// <para>
        /// This value is cleared when you call <see cref="GetMessage"/> or <see cref="PeekMessage"/>,
        /// whether or not you are filtering messages.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="QS_TIMER"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// A <see cref="WM_TIMER"/> message is in the queue.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="QS_PAINT"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// A <see cref="WM_PAINT"/> message is in the queue.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="QS_SENDMESSAGE"/>
        /// </para>
        /// <para>
        /// 0x0040
        /// </para>
        /// </term>
        /// <term>
        /// A message sent by another thread or application is in the queue.
        /// For more information, see <see cref="SendMessage"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="QS_HOTKEY"/>
        /// </para>
        /// <para>
        /// 0x0080
        /// </para>
        /// </term>
        /// <term>
        /// A <see cref="WM_HOTKEY"/> message is in the queue.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="QS_ALLPOSTMESSAGE"/>
        /// </para>
        /// <para>
        /// 0x0100
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// A posted message (other than those listed here) is in the queue.
        /// For more information, see <see cref="PostMessage"/>.
        /// </para>
        /// <para>
        /// This value is cleared when you call <see cref="GetMessage"/> or <see cref="PeekMessage"/> without filtering messages.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="QS_RAWINPUT"/>
        /// </para>
        /// <para>
        /// 0x0400
        /// </para>
        /// </term>
        /// <term>
        /// Windows XP and newer: A raw input message is in the queue.
        /// For more information, see Raw Input.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="QS_TOUCH"/>
        /// </para>
        /// <para>
        /// 0x0800
        /// </para>
        /// </term>
        /// <term>
        /// Windows 8 and newer:
        /// A touch input message is in the queue.
        /// For more information, see Touch Input.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="QS_POINTER"/>
        /// </para>
        /// <para>
        /// 0x1000
        /// </para>
        /// </term>
        /// <term>
        /// Windows 8 and newer:
        /// A pointer input message is in the queue.
        /// For more information, see Pointer Input.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="QS_MOUSE"/>
        /// </para>
        /// <para>
        /// (QS_MOUSEMOVE | QS_MOUSEBUTTON)
        /// </para>
        /// </term>
        /// <term>
        /// A <see cref="WM_MOUSEMOVE"/> message or mouse-button message
        /// (<see cref="WM_LBUTTONUP"/>, <see cref="WM_RBUTTONDOWN"/>, and so on).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="QS_INPUT"/>
        /// </para>
        /// <para>
        /// (QS_MOUSE | QS_KEY | QS_RAWINPUT | QS_TOUCH | QS_POINTER)
        /// </para>
        /// </term>
        /// <term>
        /// An input message is in the queue.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="QS_ALLEVENTS"/>
        /// </para>
        /// <para>
        /// (QS_INPUT | QS_POSTMESSAGE | QS_TIMER | QS_PAINT | QS_HOTKEY)
        /// </para>
        /// </term>
        /// <term>
        /// An input, <see cref="WM_TIMER"/>, <see cref="WM_PAINT"/>, <see cref="WM_HOTKEY"/>, or posted message is in the queue.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="QS_ALLINPUT"/>
        /// </para>
        /// <para>
        /// (QS_INPUT | QS_POSTMESSAGE | QS_TIMER | QS_PAINT | QS_HOTKEY | QS_SENDMESSAGE)
        /// </para>
        /// </term>
        /// <term>
        /// Any message is in the queue.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// The high-order word of the return value indicates the types of messages currently in the queue.
        /// The low-order word indicates the types of messages that have been added to the queue and that are still in the queue
        /// since the last call to the <see cref="GetQueueStatus"/>, <see cref="GetMessage"/>, or <see cref="PeekMessage"/> function.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The presence of a <c>QS_</c> flag in the return value does not guarantee
        /// that a subsequent call to the <see cref="GetMessage"/> or <see cref="PeekMessage"/> function will return a message.
        /// <see cref="GetMessage"/> and <see cref="PeekMessage"/> perform some internal filtering that may cause the message to be processed internally.
        /// For this reason, the return value from <see cref="GetQueueStatus"/> should be considered only a hint
        /// as to whether <see cref="GetMessage"/> or <see cref="PeekMessage"/> should be called.
        /// </para>
        /// <para>
        /// The <see cref="QS_ALLPOSTMESSAGE"/> and <see cref="QS_POSTMESSAGE"/> flags differ in when they are cleared.
        /// <see cref="QS_POSTMESSAGE"/> is cleared when you call <see cref="GetMessage"/> or <see cref="PeekMessage"/>,
        /// whether or not you are filtering messages.
        /// <see cref="QS_ALLPOSTMESSAGE"/> is cleared when you call <see cref="GetMessage"/> or <see cref="PeekMessage"/>
        /// without filtering messages (<c>wMsgFilterMin</c> and <c>wMsgFilterMax</c> are 0).
        /// This can be useful when you call <see cref="PeekMessage"/> multiple times to get messages in different ranges.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetQueueStatus", ExactSpelling = true)]
        public static extern DWORD GetQueueStatus([In] QueueStatus flags);

        /// <summary>
        /// <para>
        /// Determines whether the current window procedure is processing a message that was sent from another thread
        /// (in the same process or a different process) by a call to the <see cref="SendMessage"/> function.
        /// </para>
        /// <para>
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
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "InSendMessage", ExactSpelling = true)]
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
        /// <para>
        /// If the message was not sent, the return value is <see cref="ISMEX_NOSEND"/> (0x00000000).
        /// Otherwise, the return value is one or more of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code/value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="ISMEX_CALLBACK"/>
        /// </para>
        /// <para>
        /// 0x00000004
        /// </para>
        /// </term>
        /// <term>
        /// The message was sent using the <see cref="SendMessageCallback"/> function.
        /// The thread that sent the message is not blocked.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="ISMEX_NOTIFY"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// The message was sent using the <see cref="SendNotifyMessage"/> function.
        /// The thread that sent the message is not blocked.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="ISMEX_REPLIED"/>
        /// </para>
        /// <para>
        /// 0x00000008
        /// </para>
        /// </term>
        /// <term>
        /// The window procedure has processed the message.
        /// The thread that sent the message is no longer blocked.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="ISMEX_SEND"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// The message was sent using the <see cref="SendMessage"/> or <see cref="SendMessageTimeout"/> function.
        /// If <see cref="ISMEX_REPLIED"/> is not set, the thread that sent the message is blocked.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To determine if the sender is blocked, use the following test:
        /// </para>
        /// <c>fBlocked = ( InSendMessageEx(NULL) &amp; (ISMEX_REPLIED|ISMEX_SEND) ) == ISMEX_SEND;</c>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "InSendMessageEx", ExactSpelling = true)]
        public static extern InSendMessageExResults InSendMessageEx([In] LPVOID lpReserved);

        /// <summary>
        /// <para>
        /// Determines whether the last message read from the current thread's queue originated from a <see cref="WOW64"/> process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-iswow64message"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// The function returns <see cref="TRUE"/> if the last message
        /// read from the current thread's queue originated from a WOW64 process, and <see cref="FALSE"/> otherwise.
        /// </returns>
        /// <remarks>
        /// This function is useful to helping you develop 64-bit native applications
        /// that can receive private messages sent from 32-bit client applications,
        /// if the messages are associated with data structures that contain pointer-dependent data.
        /// In these situations, you can call this function in your 64-bit native application
        /// to determine if the message originated from a WOW64 process and then thunk the message appropriately.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsWow64Message", ExactSpelling = true)]
        public static extern BOOL IsWow64Message();

        /// <summary>
        /// <para>
        /// Waits until one or all of the specified objects are in the signaled state or the time-out interval elapses.
        /// The objects can include input event objects, which you specify using the <paramref name="dwWakeMask"/> parameter.
        /// </para>
        /// <para>
        /// To enter an alertable wait state, use the <see cref="MsgWaitForMultipleObjectsEx"/> function.
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
        /// <para>
        /// An array of object handles.
        /// For a list of the object types whose handles can be specified, see the following Remarks section.
        /// The array can contain handles of objects of different types.
        /// It may not contain multiple copies of the same handle.
        /// </para>
        /// <para>
        /// If one of these handles is closed while the wait is still pending, the function's behavior is undefined.
        /// </para>
        /// <para>
        /// The handles must have the <see cref="SYNCHRONIZE"/> access right.
        /// For more information, see Standard Access Rights.
        /// </para>
        /// </param>
        /// <param name="fWaitAll">
        /// If this parameter is <see cref="TRUE"/>, the function returns when the states of all objects
        /// in the <paramref name="pHandles"/> array have been set to signaled and an input event has been received.
        /// If this parameter is <see cref="FALSE"/>, the function returns
        /// when the state of any one of the objects is set to signaled or an input event has been received.
        /// In this case, the return value indicates the object whose state caused the function to return.
        /// </param>
        /// <param name="dwMilliseconds">
        /// <para>
        /// The time-out interval, in milliseconds. If a nonzero value is specified,
        /// the function waits until the specified objects are signaled or the interval elapses.
        /// If <paramref name="dwMilliseconds"/> is zero, the function does not enter a wait state
        /// if the specified objects are not signaled; it always returns immediately.
        /// If <paramref name="dwMilliseconds"/> is <see cref="INFINITE"/>,
        /// the function will return only when the specified objects are signaled.
        /// </para>
        /// <para>
        /// Windows XP, Windows Server 2003, Windows Vista, Windows 7, Windows Server 2008, and Windows Server 2008 R2:
        /// The <paramref name="dwMilliseconds"/> value does include time spent in low-power states.
        /// For example, the timeout does keep counting down while the computer is asleep.
        /// </para>
        /// <para>
        /// Windows 8 and newer, Windows Server 2012 and newer:
        /// The <paramref name="dwMilliseconds"/> value does not include time spent in low-power states.
        /// For example, the timeout does not keep counting down while the computer is asleep.
        /// </para>
        /// </param>
        /// <param name="dwWakeMask">
        /// The input types for which an input event object handle will be added to the array of object handles.
        /// This parameter can be any combination of the values listed in <see cref="GetQueueStatus"/> <c>flags</c> parameter.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value indicates the event that caused the function to return.
        /// It can be one of the following values.
        /// (Note that <see cref="WAIT_OBJECT_0"/> is defined as 0 and <see cref="WAIT_ABANDONED_0"/> is defined as 0x00000080L.)
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code/value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="WAIT_OBJECT_0"/> to (<see cref="WAIT_OBJECT_0"/> + <paramref name="nCount"/>– 1)
        /// </term>
        /// <term>
        /// If <paramref name="fWaitAll"/> is <see cref="TRUE"/>, a return value within the specified range
        /// indicates that the state of all specified objects is signaled.
        /// If <paramref name="fWaitAll"/> is <see cref="FALSE"/>, the return value minus <see cref="WAIT_OBJECT_0"/>
        /// indicates the <paramref name="pHandles"/> array index of the object that satisfied the wait.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WAIT_OBJECT_0"/> + <paramref name="nCount"/>
        /// </term>
        /// <term>
        /// <para>
        /// New input of the type specified in the <paramref name="dwWakeMask"/> parameter is available in the thread's input queue.
        /// Functions such as <see cref="PeekMessage"/>, <see cref="GetMessage"/>,
        /// and <see cref="WaitMessage"/> mark messages in the queue as old messages.
        /// Therefore, after you call one of these functions,
        /// a subsequent call to <see cref="MsgWaitForMultipleObjects"/> will not return until new input of the specified type arrives.
        /// </para>
        /// <para>
        /// This value is also returned upon the occurrence of a system event that requires the thread's action, such as foreground activation.
        /// Therefore, <see cref="MsgWaitForMultipleObjects"/> can return even though no appropriate input is available
        /// and even if <paramref name="dwWakeMask"/> is set to 0.
        /// If this occurs, call <see cref="GetMessage"/> or <see cref="PeekMessage"/> to process the system event
        /// before trying the call to <see cref="MsgWaitForMultipleObjects"/> again.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WAIT_ABANDONED_0"/> to (<see cref="WAIT_ABANDONED_0"/> + <paramref name="nCount"/>– 1)
        /// </term>
        /// <term>
        /// <para>
        /// If <paramref name="fWaitAll"/> is <see cref="TRUE"/>, a return value within the specified range
        /// indicates that the state of all specified objects is signaled and at least one of the objects is an abandoned mutex object.
        /// If <paramref name="fWaitAll"/> is <see cref="FALSE"/>, the return value minus <see cref="WAIT_ABANDONED_0"/>
        /// indicates the <paramref name="pHandles"/> array index of an abandoned mutex object that satisfied the wait.
        /// Ownership of the mutex object is granted to the calling thread, and the mutex is set to nonsignaled.
        /// </para>
        /// <para>
        /// If the mutex was protecting persistent state information, you should check it for consistency.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WAIT_TIMEOUT"/>
        /// </para>
        /// <para>
        /// 258L
        /// </para>
        /// </term>
        /// <term>
        /// The time-out interval elapsed and the conditions specified by the <paramref name="fWaitAll"/>
        /// and <paramref name="dwWakeMask"/> parameters were not satisfied.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WAIT_FAILED"/>
        /// </para>
        /// <para>
        /// (DWORD)0xFFFFFFFF
        /// </para>
        /// </term>
        /// <term>
        /// The function has failed. To get extended error information, call <see cref="GetLastError"/>.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="MsgWaitForMultipleObjects"/> function determines whether the wait criteria have been met.
        /// If the criteria have not been met, the calling thread enters the wait state
        /// until the conditions of the wait criteria have been met or the time-out interval elapses.
        /// </para>
        /// <para>
        /// When <paramref name="fWaitAll"/> is <see cref="TRUE"/>,
        /// the function does not modify the states of the specified objects until the states of all objects have been set to signaled.
        /// For example, a mutex can be signaled, but the thread does not get ownership
        /// until the states of the other objects have also been set to signaled.
        /// In the meantime, some other thread may get ownership of the mutex, thereby setting its state to nonsignaled.
        /// </para>
        /// <para>
        /// When <paramref name="fWaitAll"/> is <see cref="TRUE"/>, the function's wait is completed
        /// only when the states of all objects have been set to signaled and an input event has been received.
        /// Therefore, setting <paramref name="fWaitAll"/> to <see cref="TRUE"/> prevents input from being processed
        /// until the state of all objects in the <paramref name="pHandles"/> array have been set to signaled.
        /// For this reason, if you set <paramref name="fWaitAll"/> to <see cref="TRUE"/>,
        /// you should use a short timeout value in <paramref name="dwMilliseconds"/>.
        /// If you have a thread that creates windows waiting for all objects in the <paramref name="pHandles"/> array,
        /// including input events specified by <paramref name="dwWakeMask"/>, with no timeout interval, the system will deadlock.
        /// This is because threads that create windows must process messages.
        /// DDE sends message to all windows in the system.
        /// Therefore, if a thread creates windows, do not set the <paramref name="fWaitAll"/> parameter to <see cref="TRUE"/>
        /// in calls to <see cref="MsgWaitForMultipleObjects"/> made from that thread.
        /// </para>
        /// <para>
        /// When <paramref name="fWaitAll"/> is <see cref="FALSE"/>,
        /// this function checks the handles in the array in order starting with index 0, until one of the objects is signaled.
        /// If multiple objects become signaled, the function returns the index of the first handle in the array whose object was signaled.
        /// </para>
        /// <para>
        /// <see cref="MsgWaitForMultipleObjects"/> does not return if there is unread input of the specified type
        /// in the message queue after the thread has called a function to check the queue.
        /// This is because functions such as <see cref="PeekMessage"/>, <see cref="GetMessage"/>, <see cref="GetQueueStatus"/>,
        /// and <see cref="WaitMessage"/> check the queue and then change the state information for the queue so that the input is no longer considered new.
        /// A subsequent call to <see cref="MsgWaitForMultipleObjects"/> will not return until new input of the specified type arrives.
        /// The existing unread input (received prior to the last time the thread checked the queue) is ignored.
        /// </para>
        /// <para>
        /// The function modifies the state of some types of synchronization objects.
        /// Modification occurs only for the object or objects whose signaled state caused the function to return.
        /// For example, the count of a semaphore object is decreased by one.
        /// For more information, see the documentation for the individual synchronization objects.
        /// </para>
        /// <para>
        /// The <see cref="MsgWaitForMultipleObjects"/> function can specify handles of any
        /// of the following object types in the <paramref name="pHandles"/> array:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Change notification
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Console input
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Event
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Memory resource notification
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Mutex
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Process
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Semaphore
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Thread
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Waitable timer
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "MsgWaitForMultipleObjects", ExactSpelling = true, SetLastError = true)]
        public static extern WaitResult MsgWaitForMultipleObjects([In] DWORD nCount, [In] HANDLE[] pHandles, [In] BOOL fWaitAll,
            [In] DWORD dwMilliseconds, [In] QueueStatus dwWakeMask);

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
        /// <para>
        /// An array of object handles.
        /// For a list of the object types whose handles you can specify, see the Remarks section later in this topic.
        /// The array can contain handles to multiple types of objects.
        /// It may not contain multiple copies of the same handle.
        /// </para>
        /// <para>
        /// If one of these handles is closed while the wait is still pending, the function's behavior is undefined.
        /// </para>
        /// <para>
        /// The handles must have the <see cref="SYNCHRONIZE"/> access right.
        /// For more information, see Standard Access Rights.
        /// </para>
        /// </param>
        /// <param name="dwMilliseconds">
        /// <para>
        /// The time-out interval, in milliseconds.
        /// If a nonzero value is specified, the function waits until the specified objects are signaled,
        /// an I/O completion routine or APC is queued, or the interval elapses.
        /// If <paramref name="dwMilliseconds"/> is zero, the function does not enter a wait state
        /// if the criteria is not met; it always returns immediately.
        /// If <paramref name="dwMilliseconds"/> is <see cref="INFINITE"/>,
        /// the function will return only when the specified objects are signaled or an I/O completion routine or APC is queued.
        /// </para>
        /// <para>
        /// Windows XP, Windows Server 2003, Windows Vista, Windows 7, Windows Server 2008, and Windows Server 2008 R2:
        /// The <paramref name="dwMilliseconds"/> value does include time spent in low-power states.
        /// For example, the timeout does keep counting down while the computer is asleep.
        /// </para>
        /// <para>
        /// Windows 8 and newer, Windows Server 2012 and newer:
        /// The <paramref name="dwMilliseconds"/> value does not include time spent in low-power states.
        /// For example, the timeout does not keep counting down while the computer is asleep.
        /// </para>
        /// </param>
        /// <param name="dwWakeMask">
        /// The input types for which an input event object handle will be added to the array of object handles.
        /// This parameter can be any combination of the values listed in <see cref="GetQueueStatus"/> <c>flags</c> parameter.
        /// </param>
        /// <param name="dwFlags">
        /// <para>
        /// The wait type.
        /// This parameter can be one or more of the following values.
        /// </para>
        /// <para>
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
        /// 0
        /// </term>
        /// <term>
        /// The function returns when any one of the objects is signaled.
        /// The return value indicates the object whose state caused the function to return.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MWMO_ALERTABLE"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// The function also returns if an APC has been queued to the thread with <see cref="QueueUserAPC"/>
        /// while the thread is in the waiting state.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MWMO_INPUTAVAILABLE"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// The function returns if input exists for the queue, even if the input has been seen (but not removed)
        /// using a call to another function, such as <see cref="PeekMessage"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MWMO_WAITALL"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// The function returns when all objects in the <paramref name="pHandles"/> array are signaled
        /// and an input event has been received, all at the same time.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value indicates the event that caused the function to return.
        /// It can be one of the following values.
        /// (Note that <see cref="WAIT_OBJECT_0"/> is defined as 0 and <see cref="WAIT_ABANDONED_0"/> is defined as 0x00000080L.)
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code/value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="WAIT_OBJECT_0"/> to (<see cref="WAIT_OBJECT_0"/> + <paramref name="nCount"/> - 1)
        /// </term>
        /// <term>
        /// If the <see cref="MWMO_WAITALL"/> flag is used, a return value within the specified range indicates
        /// that the state of all specified objects is signaled.
        /// Otherwise, the return value minus <see cref="WAIT_OBJECT_0"/> indicates
        /// the <paramref name="pHandles"/> array index of the object that caused the function to return.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WAIT_OBJECT_0"/> + <paramref name="nCount"/>
        /// </term>
        /// <term>
        /// <para>
        /// New input of the type specified in the <paramref name="dwWakeMask"/> parameter is available in the thread's input queue.
        /// Functions such as <see cref="PeekMessage"/>, <see cref="GetMessage"/>, <see cref="GetQueueStatus"/>,
        /// and <see cref="WaitMessage"/> mark messages in the queue as old messages.
        /// Therefore, after you call one of these functions,
        /// a subsequent call to <see cref="MsgWaitForMultipleObjectsEx"/> will not return until new input of the specified type arrives.
        /// </para>
        /// <para>
        /// This value is also returned upon the occurrence of a system event that requires the thread's action, such as foreground activation.
        /// Therefore, <see cref="MsgWaitForMultipleObjectsEx"/> can return even though no appropriate input is available
        /// and even if <paramref name="dwWakeMask"/> is set to 0.
        /// If this occurs, call <see cref="GetMessage"/> or <see cref="PeekMessage"/> to process the system event
        /// before trying the call to <see cref="MsgWaitForMultipleObjectsEx"/> again.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WAIT_ABANDONED_0"/> to (<see cref="WAIT_ABANDONED_0"/> + <paramref name="nCount"/> - 1)
        /// </term>
        /// <term>
        /// <para>
        /// If the <see cref="MWMO_WAITALL"/> flag is used, a return value within the specified range indicates
        /// that the state of all specified objects is signaled and at least one of the objects is an abandoned mutex object.
        /// Otherwise, the return value minus <see cref="WAIT_ABANDONED_0"/> indicates
        /// the <paramref name="pHandles"/> array index of an abandoned mutex object that caused the function to return.
        /// Ownership of the mutex object is granted to the calling thread, and the mutex is set to nonsignaled.
        /// </para>
        /// <para>
        /// If the mutex was protecting persistent state information, you should check it for consistency.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WAIT_IO_COMPLETION"/>
        /// </para>
        /// <para>
        /// 0x000000C0L
        /// </para>
        /// </term>
        /// <term>
        /// The wait was ended by one or more user-mode asynchronous procedure calls (APC) queued to the thread.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WAIT_TIMEOUT"/>
        /// </para>
        /// <para>
        /// 258L
        /// </para>
        /// </term>
        /// <term>
        /// The time-out interval elapsed, but the conditions specified by the <paramref name="dwFlags"/>
        /// and <paramref name="dwWakeMask"/> parameters were not met.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WAIT_FAILED"/>
        /// </para>
        /// <para>
        /// (DWORD)0xFFFFFFFF
        /// </para>
        /// </term>
        /// <term>
        /// The function has failed.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="MsgWaitForMultipleObjectsEx"/> function determines whether the conditions
        /// specified by <paramref name="dwWakeMask"/> and <paramref name="dwFlags"/> have been met.
        /// If the conditions have not been met, the calling thread enters the wait state
        /// until the conditions of the wait criteria have been met or the time-out interval elapses.
        /// </para>
        /// <para>
        /// When <paramref name="dwFlags"/> is zero, this function checks the handles in the array
        /// in order starting with index 0, until one of the objects is signaled.
        /// If multiple objects become signaled, the function returns the index of the first handle in the array whose object was signaled.
        /// </para>
        /// <para>
        /// <see cref="MsgWaitForMultipleObjectsEx"/> does not return if there is unread input of the specified type in the message queue
        /// after the thread has called a function to check the queue, unless you use the <see cref="MWMO_INPUTAVAILABLE"/> flag.
        /// This is because functions such as <see cref="PeekMessage"/>, <see cref="GetMessage"/>, <see cref="GetQueueStatus"/>,
        /// and <see cref="WaitMessage"/> check the queue and then change the state information for the queue
        /// so that the input is no longer considered new.
        /// A subsequent call to <see cref="MsgWaitForMultipleObjectsEx"/> will not return
        /// until new input of the specified type arrives, unless you use the <see cref="MWMO_INPUTAVAILABLE"/> flag.
        /// If this flag is not used, the existing unread input (received prior to the last time the thread checked the queue) is ignored.
        /// </para>
        /// <para>
        /// The function modifies the state of some types of synchronization objects.
        /// Modification occurs only for the object or objects whose signaled state caused the function to return.
        /// For example, the system decreases the count of a semaphore object by one.
        /// For more information, see the documentation for the individual synchronization objects.
        /// </para>
        /// <para>
        /// The <see cref="MsgWaitForMultipleObjectsEx"/> function can specify handles of any of the following object types
        /// in the <paramref name="pHandles"/> array:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Change notification
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Console input
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Event
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Memory resource notification
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Mutex
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Process
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Semaphore
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Thread
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Waitable timer
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "MsgWaitForMultipleObjectsEx", ExactSpelling = true, SetLastError = true)]
        public static extern WaitResult MsgWaitForMultipleObjectsEx([In] DWORD nCount, [In] HANDLE[] pHandles, [In] DWORD dwMilliseconds,
            [In] QueueStatus dwWakeMask, [In] MsgWaitForMultipleObjectsExTypes dwFlags);

        /// <summary>
        /// <para>
        /// Dispatches incoming sent messages, checks the thread message queue for a posted message, and retrieves the message (if any exist).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-peekmessagew"/>
        /// </para>
        /// </summary>
        /// <param name="lpMsg">
        /// A pointer to an <see cref="MSG"/> structure that receives message information.
        /// </param>
        /// <param name="hWnd">
        /// <para>
        /// A handle to the window whose messages are to be retrieved.
        /// The window must belong to the current thread.
        /// </para>
        /// <para>
        /// If <paramref name="hWnd"/> is <see cref="NULL"/>, <see cref="PeekMessage"/> retrieves messages for any window
        /// that belongs to the current thread, and any messages on the current thread's message queue
        /// whose <see cref="MSG.hwnd"/> value is <see cref="NULL"/> (see the <see cref="MSG"/> structure).
        /// Therefore if hWnd is <see cref="NULL"/>, both window messages and thread messages are processed.
        /// </para>
        /// <para>
        /// If <paramref name="hWnd"/> is -1, <see cref="PeekMessage"/> retrieves only messages on the current thread's message queue
        /// whose <see cref="MSG.hwnd"/> value is <see cref="NULL"/>, that is, thread messages as posted by <see cref="PostMessage"/>
        /// (when the <paramref name="hWnd"/> parameter is <see cref="NULL"/>) or <see cref="PostThreadMessage"/>.
        /// </para>
        /// </param>
        /// <param name="wMsgFilterMin">
        /// <para>
        /// The value of the first message in the range of messages to be examined.
        /// Use <see cref="WM_KEYFIRST"/> (0x0100) to specify the first keyboard message
        /// or <see cref="WM_MOUSEFIRST"/> (0x0200) to specify the first mouse message.
        /// </para>
        /// <para>
        /// If <paramref name="wMsgFilterMin"/> and <paramref name="wMsgFilterMax"/> are both zero,
        /// <see cref="PeekMessage"/> returns all available messages (that is, no range filtering is performed).
        /// </para>
        /// </param>
        /// <param name="wMsgFilterMax">
        /// <para>
        /// The value of the last message in the range of messages to be examined.
        /// Use <see cref="WM_KEYLAST"/> to specify the last keyboard message
        /// or <see cref="WM_MOUSELAST"/> to specify the last mouse message.
        /// </para>
        /// <para>
        /// If <paramref name="wMsgFilterMin"/> and <paramref name="wMsgFilterMax"/> are both zero,
        /// <see cref="PeekMessage"/> returns all available messages (that is, no range filtering is performed).
        /// </para>
        /// </param>
        /// <param name="wRemoveMsg">
        /// <para>
        /// Specifies how messages are to be handled.
        /// This parameter can be one or more of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="PM_NOREMOVE"/>
        /// </para>
        /// <para>
        /// <c>0x0000</c>
        /// </para>
        /// </term>
        /// <term>
        /// Messages are not removed from the queue after processing by <see cref="PeekMessage"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PM_REMOVE"/>
        /// </para>
        /// <para>
        /// <c>0x0001</c>
        /// </para>
        /// </term>
        /// <term>
        /// Messages are removed from the queue after processing by <see cref="PeekMessage"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PM_NOYIELD"/>
        /// </para>
        /// <para>
        /// <c>0x0002</c>
        /// </para>
        /// </term>
        /// <term>
        /// Prevents the system from releasing any thread that is waiting for the caller to go idle (see <see cref="WaitForInputIdle"/>).
        /// Combine this value with either <see cref="PM_NOREMOVE"/> or <see cref="PM_REMOVE"/>.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// By default, all message types are processed.
        /// To specify that only certain message should be processed, specify one or more of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="PM_QS_INPUT"/>
        /// </para>
        /// <para>
        /// <c>(QS_INPUT &lt;&lt; 16)</c>
        /// </para>
        /// </term>
        /// <term>
        /// Process mouse and keyboard messages.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PM_QS_POSTMESSAGE"/>
        /// </para>
        /// <para>
        /// <c>((QS_POSTMESSAGE \| QS_HOTKEY \| QS_TIMER) &lt;&lt; 16)</c>
        /// </para>
        /// </term>
        /// <term>
        /// Process all posted messages, including timers and hotkeys.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PM_QS_PAINT"/>
        /// </para>
        /// <para>
        /// <c>(QS_PAINT &lt;&lt; 16)</c>
        /// </para>
        /// </term>
        /// <term>
        /// Process paint messages.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PM_QS_SENDMESSAGE"/>
        /// </para>
        /// <para>
        /// <c>(QS_SENDMESSAGE &lt;&lt; 16)</c>
        /// </para>
        /// </term>
        /// <term>
        /// Process all sent messages.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// For more info on listed <c>QS_</c> flags and types of messages see <see cref="GetQueueStatus"/> documentation.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If a message is available, the return value is nonzero.
        /// </para>
        /// <para>
        /// If no messages are available, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="PeekMessage"/> retrieves messages associated with the window identified by the <paramref name="hWnd"/> parameter
        /// or any of its children as specified by the <see cref="IsChild"/> function,
        /// and within the range of message values given by the <paramref name="wMsgFilterMin"/> and <paramref name="wMsgFilterMax"/> parameters.
        /// Note that an application can only use the low word in the <paramref name="wMsgFilterMin"/> and <paramref name="wMsgFilterMax"/> parameters;
        /// the high word is reserved for the system.
        /// </para>
        /// <para>
        /// Note that <see cref="PeekMessage"/> always retrieves <see cref="WM_QUIT"/> messages,
        /// no matter which values you specify for <paramref name="wMsgFilterMin"/> and <paramref name="wMsgFilterMax"/>.
        /// </para>
        /// <para>
        /// During this call, the system dispatches (<see cref="DispatchMessage"/>) pending, nonqueued messages,
        /// that is, messages sent to windows owned by the calling thread using the <see cref="SendMessage"/>,
        /// <see cref="SendMessageCallback"/>, <see cref="SendMessageTimeout"/>, or <see cref="SendNotifyMessage"/> function.
        /// Then the first queued message that matches the specified filter is retrieved. The system may also process internal events.
        /// If no filter is specified, messages are processed in the following order:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Sent messages
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Posted messages
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Input (hardware) messages and system internal events
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Sent messages (again)
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="WM_PAINT"/> messages
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="WM_TIMER"/> messages
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// To retrieve input messages before posted messages,
        /// use the <paramref name="wMsgFilterMin"/> and <paramref name="wMsgFilterMax"/> parameters.
        /// </para>
        /// <para>
        /// The <see cref="PeekMessage"/> function normally does not remove <see cref="WM_PAINT"/> messages from the queue.
        /// <see cref="WM_PAINT"/> messages remain in the queue until they are processed.
        /// However, if a <see cref="WM_PAINT"/> message has a <see cref="NULL"/> update region,
        /// <see cref="PeekMessage"/> does remove it from the queue.
        /// </para>
        /// <para>
        /// If a top-level window stops responding to messages for more than several seconds,
        /// the system considers the window to be not responding and replaces it with a ghost window
        /// that has the same z-order, location, size, and visual attributes.
        /// This allows the user to move it, resize it, or even close the application.
        /// However, these are the only actions available because the application is actually not responding.
        /// When an application is being debugged, the system does not generate a ghost window.
        /// </para>
        /// <para>
        /// DPI Virtualization
        /// </para>
        /// <para>
        /// This API does not participate in DPI virtualization.
        /// The output is in the mode of the window that the message is targeting.
        /// The calling thread is not taken into consideration.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "PeekMessageW", ExactSpelling = true)]
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
        /// <para>
        /// A handle to the window whose window procedure is to receive the message.
        /// The following values have special meanings.
        /// </para>
        /// <para>
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
        /// <see cref="HWND_BROADCAST"/>
        /// </para>
        /// <para>
        /// ((HWND)0xffff)
        /// </para>
        /// </term>
        /// <term>
        /// The message is posted to all top-level windows in the system,
        /// including disabled or invisible unowned windows, overlapped windows, and pop-up windows.
        /// The message is not posted to child windows.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// NULL
        /// </term>
        /// <term>
        /// The function behaves like a call to <see cref="PostThreadMessage"/>
        /// with the <c>dwThreadId</c> parameter set to the identifier of the current thread.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Starting with Windows Vista, message posting is subject to UIPI.
        /// The thread of a process can post messages only to message queues of threads in processes of lesser or equal integrity level.
        /// </para>
        /// </param>
        /// <param name="msg">
        /// <para>
        /// The message to be posted.
        /// </para>
        /// <para>
        /// For lists of the system-provided messages, see System-Defined Messages.
        /// </para>
        /// </param>
        /// <param name="wParam">
        /// Additional message-specific information.
        /// </param>
        /// <param name="lParam">
        /// Additional message-specific information.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// When a message is blocked by UIPI the last error, retrieved with <see cref="GetLastError"/>, is set to 5 (access denied).
        /// </para>
        /// <para>
        /// Messages in a message queue are retrieved by calls to the <see cref="GetMessage"/> or <see cref="PeekMessage"/> function.
        /// </para>
        /// <para>
        /// Applications that need to communicate using <see cref="HWND_BROADCAST"/> should use the <see cref="RegisterWindowMessage"/> function
        /// to obtain a unique message for inter-application communication.
        /// </para>
        /// <para>
        /// The system only does marshalling for system messages (those in the range 0 to (<see cref="WM_USER"/>-1)).
        /// To send other messages (those &gt;= <see cref="WM_USER"/>) to another process, you must do custom marshalling.
        /// </para>
        /// <para>
        /// If you send a message in the range below <see cref="WM_USER"/> to the asynchronous message functions
        /// (<see cref="PostMessage"/>, <see cref="SendNotifyMessage"/>, and <see cref="SendMessageCallback"/>),
        /// its message parameters cannot include pointers.
        /// Otherwise, the operation will fail.
        /// The functions will return before the receiving thread has had a chance to process the message
        /// and the sender will free the memory before it is used.
        /// </para>
        /// <para>
        /// Do not post the <see cref="WM_QUIT"/> message using <see cref="PostMessage"/>;
        /// use the <see cref="PostQuitMessage"/> function.
        /// </para>
        /// <para>
        /// An accessibility application can use <see cref="PostMessage"/>
        /// to post <see cref="WM_APPCOMMAND"/> messages to the shell to launch applications.
        /// This functionality is not guaranteed to work for other types of applications.
        /// </para>
        /// <para>
        /// There is a limit of 10,000 posted messages per message queue. This limit should be sufficiently large.
        /// If your application exceeds the limit, it should be redesigned to avoid consuming so many system resources.
        /// To adjust this limit, modify the following registry key.
        /// </para>
        /// <c>
        /// HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Windows\USERPostMessageLimit
        /// </c>
        /// <para>
        /// If the function fails, call <see cref="GetLastError"/> to get extended error information.
        /// <see cref="GetLastError"/> returns <see cref="ERROR_NOT_ENOUGH_QUOTA"/> when the limit is hit.
        /// </para>
        /// <para>
        /// The minimum acceptable value is 4000.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
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
        /// <para>
        /// The <see cref="PostQuitMessage"/> function posts a <see cref="WM_QUIT"/> message to the thread's message queue and returns immediately;
        /// the function simply indicates to the system that the thread is requesting to quit at some time in the future.
        /// </para>
        /// <para>
        /// When the thread retrieves the <see cref="WM_QUIT"/> message from its message queue,
        /// it should exit its message loop and return control to the system.
        /// The exit value returned to the system must be the <see cref="MSG.wParam"/> parameter of the <see cref="WM_QUIT"/> message.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "PostQuitMessage", ExactSpelling = true)]
        public static extern void PostQuitMessage([In] int nExitCode);

        /// <summary>
        /// <para>
        /// Posts a message to the message queue of the specified thread.
        /// It returns without waiting for the thread to process the message.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-postthreadmessagew"/>
        /// </para>
        /// </summary>
        /// <param name="idThread">
        /// <para>
        /// The identifier of the thread to which the message is to be posted.
        /// </para>
        /// <para>
        /// The function fails if the specified thread does not have a message queue.
        /// The system creates a thread's message queue when the thread makes its first call to one of the User or GDI functions.
        /// For more information, see the Remarks section.
        /// </para>
        /// <para>
        /// Message posting is subject to UIPI.
        /// The thread of a process can post messages only to posted-message queues of threads in processes of lesser or equal integrity level.
        /// </para>
        /// <para>
        /// This thread must have the <see cref="SE_TCB_NAME"/> privilege to post a message to a thread
        /// that belongs to a process with the same locally unique identifier (<see cref="LUID"/>) but is in a different desktop.
        /// Otherwise, the function fails and returns <see cref="ERROR_INVALID_THREAD_ID"/>.
        /// </para>
        /// <para>
        /// This thread must either belong to the same desktop as the calling thread or to a process with the same <see cref="LUID"/>.
        /// Otherwise, the function fails and returns <see cref="ERROR_INVALID_THREAD_ID"/>.
        /// </para>
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
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// <see cref="GetLastError"/> returns <see cref="ERROR_INVALID_THREAD_ID"/>
        /// if <paramref name="idThread"/> is not a valid thread identifier,
        /// or if the thread specified by <paramref name="idThread"/> does not have a message queue.
        /// <see cref="GetLastError"/> returns <see cref="ERROR_NOT_ENOUGH_QUOTA"/> when the message limit is hit.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// When a message is blocked by UIPI the last error, retrieved with <see cref="GetLastError"/>, is set to 5 (access denied).
        /// </para>
        /// <para>
        /// The thread to which the message is posted must have created a message queue,
        /// or else the call to <see cref="PostThreadMessage"/> fails.
        /// Use the following method to handle this situation.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Create an event object, then create the thread.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Use the <see cref="WaitForSingleObject"/> function to wait for the event to be set
        /// to the signaled state before calling <see cref="PostThreadMessage"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// In the thread to which the message will be posted,
        /// call <see cref="PeekMessage"/> as shown here to force the system to create the message queue.
        /// </para>
        /// <para>
        /// <c>PeekMessage(&amp;msg, NULL, WM_USER, WM_USER, PM_NOREMOVE)</c>
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Set the event, to indicate that the thread is ready to receive posted messages.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The thread to which the message is posted retrieves the message
        /// by calling the <see cref="GetMessage"/> or <see cref="PeekMessage"/> function.
        /// The <see cref="MSG.hwnd"/> member of the returned <see cref="MSG"/> structure is <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// Messages posted by <see cref="PostThreadMessage"/> are not associated with a window.
        /// As a general rule, messages that are not associated with a window cannot be dispatched by the <see cref="DispatchMessage"/> function.
        /// Therefore, if the recipient thread is in a modal loop
        /// (as used by <see cref="MessageBox"/> or <see cref="DialogBox"/>), the messages will be lost.
        /// To intercept thread messages while in a modal loop, use a thread-specific hook.
        /// </para>
        /// <para>
        /// The system only does marshalling for system messages (those in the range 0 to (<see cref="WM_USER"/>-1)).
        /// To send other messages (those &gt;= <see cref="WM_USER"/>) to another process, you must do custom marshalling.
        /// </para>
        /// <para>
        /// There is a limit of 10,000 posted messages per message queue. This limit should be sufficiently large.
        /// If your application exceeds the limit, it should be redesigned to avoid consuming so many system resources.
        /// To adjust this limit, modify the following registry key.
        /// </para>
        /// <c>HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Windows\USERPostMessageLimit</c>
        /// <para>
        /// The minimum acceptable value is 4000.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
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
        /// <para>
        /// If the message is successfully registered, the return value is a message identifier in the range 0xC000 through 0xFFFF.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="RegisterWindowMessage"/> function is typically used to register messages
        /// for communicating between two cooperating applications.
        /// </para>
        /// <para>
        /// If two different applications register the same message string, the applications return the same message value.
        /// The message remains registered until the session ends.
        /// </para>
        /// <para>
        /// Only use <see cref="RegisterWindowMessage"/> when more than one application must process the same message.
        /// For sending private messages within a window class,
        /// an application can use any integer in the range <see cref="WM_USER"/> through 0x7FFF.
        /// (Messages in this range are private to a window class, not to an application.
        /// For example, predefined control classes such as <c>BUTTON</c>, <c>EDIT</c>,
        /// <c>LISTBOX</c>, and <c>COMBOBOX</c> may use values in this range.)
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
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
        /// The result of the message processing.
        /// The possible values are based on the message sent.
        /// </param>
        /// <returns>
        /// <para>
        /// If the calling thread was processing a message sent from another thread or process, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the calling thread was not processing a message sent from another thread or process, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// By calling this function, the window procedure that receives the message allows the thread
        /// that called <see cref="SendMessage"/> to continue to run as though the thread receiving the message had returned control.
        /// The thread that calls the <see cref="ReplyMessage"/> function also continues to run.
        /// </para>
        /// <para>
        /// If the message was not sent through <see cref="SendMessage"/>
        /// or if the message was sent by the same thread, <see cref="ReplyMessage"/> has no effect.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ReplyMessage", ExactSpelling = true)]
        public static extern BOOL ReplyMessage([In] LRESULT lResult);

        /// <summary>
        /// <para>
        /// Specifies an action or processing for the Input Method Editor (IME) through a specified subfunction.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/ime/nf-ime-sendimemessageexw"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1"></param>
        /// <param name="unnamedParam2"></param>
        /// <returns>
        /// <para>
        /// The result of processing of the subfunction.
        /// If the result is not success, one of the following error codes is stored
        /// into the <see cref="IMESTRUCT.wParam"/> of the <see cref="IMESTRUCT"/> structure.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="IME_RS_DISKERROR"/>
        /// </term>
        /// <term>
        /// Disk error.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="IME_RS_ERROR"/>
        /// </term>
        /// <term>
        /// General error.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="IME_RS_ILLEGAL"/>
        /// </term>
        /// <term>
        /// Contains an illegal character.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="IME_RS_INVALID"/>
        /// </term>
        /// <term>
        /// Invalid subfunction.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="IME_RS_NEST"/>
        /// </term>
        /// <term>
        /// Subfunction is nested and, therefore, cannot be used.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="IME_RS_NOIME"/>
        /// </term>
        /// <term>
        /// The IME has not been selected (has not been installed).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="IME_RS_NOROOM"/>
        /// </term>
        /// <term>
        /// Short of area.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="IME_RS_NOTFOUND"/>
        /// </term>
        /// <term>
        /// No candidate found.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="IME_RS_SYSTEMMODAL"/>
        /// </term>
        /// <term>
        /// Windows is in system mode, data cannot be passed to the IME.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="IME_RS_TOOLONG"/>
        /// </term>
        /// <term>
        /// Characters too long.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <see cref="SendIMEMessageEx"/> guarantees the action stipulated in the specifications only for IMEs
        /// that support the <see cref="WM_CONVERTREQUESTEX"/> message.
        /// For an IME that does not support <see cref="WM_CONVERTREQUESTEX"/>,
        /// <see cref="SendIMEMessageEx"/> sends a <see cref="WM_CONVERTREQUEST"/> message to the IME
        /// and returns the contents of the <see cref="IMESTRUCT.wParam"/> member of the <see cref="IMESTRUCT"/> structure.
        /// If the processing of the subfunction has not been completed normally,
        /// these functions set <see cref="IME_RS_ERROR"/> into <see cref="IMESTRUCT.wParam"/>.
        /// </remarks>
        [Obsolete("This function is obsolete and should not be used.")]
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SendIMEMessageExW", ExactSpelling = true)]
        public static extern LRESULT SendIMEMessageEx([In] HWND unnamedParam1, [In] LPARAM unnamedParam2);

        /// <summary>
        /// <para>
        /// Sends the specified message to a window or windows.
        /// The <see cref="SendMessage"/> function calls the window procedure for the specified window
        /// and does not return until the window procedure has processed the message.
        /// </para>
        /// <para>
        /// To send a message and return immediately, use the <see cref="SendMessageCallback"/> or <see cref="SendNotifyMessage"/> function.
        /// To post a message to a thread's message queue and return immediately,
        /// use the <see cref="PostMessage"/> or <see cref="PostThreadMessage"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-sendmessage"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// <para>
        /// A handle to the window whose window procedure will receive the message.
        /// If this parameter is <see cref="HWND_BROADCAST"/> ((HWND)0xffff),
        /// the message is sent to all top-level windows in the system,
        /// including disabled or invisible unowned windows, overlapped windows, and pop-up windows;
        /// but the message is not sent to child windows.
        /// </para>
        /// <para>
        /// Message sending is subject to UIPI.
        /// The thread of a process can send messages only to message queues of threads in processes of lesser or equal integrity level.
        /// </para>
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
        /// <para>
        /// When a message is blocked by UIPI the last error, retrieved with <see cref="GetLastError"/>, is set to 5 (access denied).
        /// </para>
        /// <para>
        /// Applications that need to communicate using <see cref="HWND_BROADCAST"/>
        /// should use the <see cref="RegisterWindowMessage"/> function to obtain a unique message for inter-application communication.
        /// </para>
        /// <para>
        /// The system only does marshalling for system messages (those in the range 0 to (<see cref="WM_USER"/>-1)).
        /// To send other messages (those &gt;= <see cref="WM_USER"/>) to another process, you must do custom marshalling.
        /// </para>
        /// <para>
        /// If the specified window was created by the calling thread, the window procedure is called immediately as a subroutine.
        /// If the specified window was created by a different thread,
        /// the system switches to that thread and calls the appropriate window procedure.
        /// Messages sent between threads are processed only when the receiving thread executes message retrieval code.
        /// The sending thread is blocked until the receiving thread processes the message.
        /// However, the sending thread will process incoming nonqueued messages while waiting for its message to be processed.
        /// To prevent this, use <see cref="SendMessageTimeout"/> with <see cref="SMTO_BLOCK"/> set.
        /// For more information on nonqueued messages, see Nonqueued Messages.
        /// </para>
        /// <para>
        /// An accessibility application can use <see cref="SendMessage"/>
        /// to send <see cref="WM_APPCOMMAND"/> messages to the shell to launch applications.
        /// This functionality is not guaranteed to work for other types of applications.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
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
        /// <para>
        /// The message to be sent.
        /// </para>
        /// <para>
        /// For lists of the system-provided messages, see System-Defined Messages.
        /// </para>
        /// </param>
        /// <param name="wParam">
        /// Additional message-specific information.
        /// </param>
        /// <param name="lParam">
        /// Additional message-specific information.
        /// </param>
        /// <param name="lpResultCallBack">
        /// <para>
        /// A pointer to a callback function that the system calls after the window procedure processes the message.
        /// For more information, see <c>SendAsyncProc</c>.
        /// </para>
        /// <para>
        /// If <paramref name="hWnd"/> is <see cref="HWND_BROADCAST"/> ((HWND)0xffff),
        /// the system calls the <c>SendAsyncProc</c> callback function once for each top-level window.
        /// </para>
        /// </param>
        /// <param name="dwData">
        /// An application-defined value to be sent to the callback function pointed to by the <paramref name="lpResultCallBack"/> parameter.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the target window belongs to the same thread as the caller, then the window procedure is called synchronously,
        /// and the callback function is called immediately after the window procedure returns.
        /// If the target window belongs to a different thread from the caller,
        /// then the callback function is called only when the thread that called <see cref="SendMessageCallback"/>
        /// also calls <see cref="GetMessage"/>, <see cref="PeekMessage"/>, or <see cref="WaitMessage"/>.
        /// </para>
        /// <para>
        /// If you send a message in the range below <see cref="WM_USER"/> to the asynchronous message functions
        /// (<see cref="PostMessage"/>, <see cref="SendNotifyMessage"/>, and <see cref="SendMessageCallback"/>),
        /// its message parameters cannot include pointers.
        /// Otherwise, the operation will fail.
        /// The functions will return before the receiving thread has had a chance
        /// to process the message and the sender will free the memory before it is used.
        /// </para>
        /// <para>
        /// Applications that need to communicate using <see cref="HWND_BROADCAST"/> 
        /// should use the <see cref="RegisterWindowMessage"/> function to obtain a unique message for inter-application communication.
        /// </para>
        /// <para>
        /// The system only does marshalling for system messages (those in the range 0 to (<see cref="WM_USER"/>-1)).
        /// To send other messages (those &gt;= <see cref="WM_USER"/>) to another process, you must do custom marshalling.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
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
        /// <para>
        /// A handle to the window whose window procedure will receive the message.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="HWND_BROADCAST"/> ((HWND)0xffff),
        /// the message is sent to all top-level windows in the system, including disabled or invisible unowned windows.
        /// The function does not return until each window has timed out.
        /// Therefore, the total wait time can be up to the value of <paramref name="uTimeout"/> multiplied by the number of top-level windows.
        /// </para>
        /// </param>
        /// <param name="Msg">
        /// <para>
        /// The message to be sent.
        /// </para>
        /// <para>
        /// For lists of the system-provided messages, see System-Defined Messages.
        /// </para>
        /// </param>
        /// <param name="wParam">
        /// Any additional message-specific information.
        /// </param>
        /// <param name="lParam">
        /// Any additional message-specific information.
        /// </param>
        /// <param name="fuFlags">
        /// <para>
        /// The behavior of this function.
        /// This parameter can be one or more of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="SMTO_ABORTIFHUNG"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// The function returns without waiting for the time-out period to elapse
        /// if the receiving thread appears to not respond or "hangs."
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SMTO_BLOCK"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// Prevents the calling thread from processing any other requests until the function returns.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SMTO_NORMAL"/>
        /// </para>
        /// <para>
        /// 0x0000
        /// </para>
        /// </term>
        /// <term>
        /// The calling thread is not prevented from processing other requests while waiting for the function to return.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SMTO_NOTIMEOUTIFNOTHUNG"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// The function does not enforce the time-out period as long as the receiving thread is processing messages.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SMTO_ERRORONEXIT"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// The function should return 0 if the receiving window is destroyed or its owning thread dies while the message is being processed.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="uTimeout">
        /// The duration of the time-out period, in milliseconds.
        /// If the message is a broadcast message, each window can use the full time-out period.
        /// For example, if you specify a five second time-out period and there are three top-level windows that fail to process the message,
        /// you could have up to a 15 second delay.
        /// </param>
        /// <param name="lpdwResult">
        /// The result of the message processing.
        /// The value of this parameter depends on the message that is specified.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// <see cref="SendMessageTimeout"/> does not provide information about individual windows timing out if <see cref="HWND_BROADCAST"/> is used.
        /// </para>
        /// <para>
        /// If the function fails or times out, the return value is 0.
        /// Note that the function does not always call <see cref="SetLastError"/> on failure.
        /// If the reason for failure is important to you,
        /// call <c>SetLastError(ERROR_SUCCESS)</c> before calling <see cref="SendMessageTimeout"/>.
        /// If the function returns 0, and <see cref="GetLastError"/> returns <see cref="ERROR_SUCCESS"/>, then treat it as a generic failure.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The function calls the window procedure for the specified window and,
        /// if the specified window belongs to a different thread, does not return
        /// until the window procedure has processed the message or the specified time-out period has elapsed.
        /// If the window receiving the message belongs to the same queue as the current thread,
        /// the window procedure is called directly—the time-out value is ignored.
        /// </para>
        /// <para>
        /// This function considers that a thread is not responding
        /// if it has not called <see cref="GetMessage"/> or a similar function within five seconds.
        /// </para>
        /// <para>
        /// The system only does marshalling for system messages (those in the range 0 to (<see cref="WM_USER"/>-1)).
        /// To send other messages (those &gt;= <see cref="WM_USER"/>) to another process, you must do custom marshalling.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SendMessageTimeoutW", ExactSpelling = true, SetLastError = true)]
        public static extern LRESULT SendMessageTimeout([In] HWND hWnd, [In] WindowMessages Msg, [In] WPARAM wParam, [In] LPARAM lParam,
            [In] SendMessageTimeoutFlags fuFlags, [In] UINT uTimeout, [Out] out DWORD_PTR lpdwResult);

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
        /// <para>
        /// The message to be sent.
        /// </para>
        /// <para>
        /// For lists of the system-provided messages, see System-Defined Messages.
        /// </para>
        /// </param>
        /// <param name="wParam">
        /// Additional message-specific information.
        /// </param>
        /// <param name="lParam">
        /// Additional message-specific information.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If you send a message in the range below <see cref="WM_USER"/> to the asynchronous message functions
        /// (<see cref="PostMessage"/>, <see cref="SendNotifyMessage"/>, and <see cref="SendMessageCallback"/>),
        /// its message parameters cannot include pointers.
        /// Otherwise, the operation will fail.
        /// The functions will return before the receiving thread has had a chance
        /// to process the message and the sender will free the memory before it is used.
        /// </para>
        /// <para>
        /// Applications that need to communicate using <see cref="HWND_BROADCAST"/>
        /// should use the <see cref="RegisterWindowMessage"/> function to obtain a unique message for inter-application communication.
        /// </para>
        /// <para>
        /// The system only does marshalling for system messages (those in the range 0 to (<see cref="WM_USER"/>-1)).
        /// To send other messages (those &gt;= <see cref="WM_USER"/>) to another process, you must do custom marshalling.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
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
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetMessageExtraInfo", ExactSpelling = true)]
        public static extern LPARAM SetMessageExtraInfo([In] LPARAM lParam);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cMessagesMax"></param>
        /// <returns></returns>
        [Obsolete]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetMessageQueue", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetMessageQueue(int cMessagesMax);

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
        /// <para>
        /// If the message is translated into a system command, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the message is not translated into a system command, the return value is zero.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
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
        /// <para>
        /// If the message is translated (that is, a character message is posted to the thread's message queue), the return value is nonzero.
        /// </para>
        /// <para>
        /// If the message is <see cref="WM_KEYDOWN"/>, <see cref="WM_KEYUP"/>, <see cref="WM_SYSKEYDOWN"/>,
        /// or <see cref="WM_SYSKEYUP"/>, the return value is nonzero, regardless of the translation.
        /// </para>
        /// <para>
        /// If the message is not translated (that is, a character message is not posted to the thread's message queue), the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="TranslateMessage"/> function does not modify the message pointed to by the <paramref name="lpMsg"/> parameter.
        /// </para>
        /// <para>
        /// <see cref="WM_KEYDOWN"/> and <see cref="WM_KEYUP"/> combinations
        /// produce a <see cref="WM_CHAR"/> or <see cref="WM_DEADCHAR"/> message.
        /// <see cref="WM_SYSKEYDOWN"/> and <see cref="WM_SYSKEYUP"/> combinations
        /// produce a <see cref="WM_SYSCHAR"/> or <see cref="WM_SYSDEADCHAR"/> message.
        /// </para>
        /// <para>
        /// <see cref="TranslateMessage"/> produces <see cref="WM_CHAR"/> messages only for keys
        /// that are mapped to ASCII characters by the keyboard driver.
        /// </para>
        /// <para>
        /// If applications process virtual-key messages for some other purpose, they should not call <see cref="TranslateMessage"/>.
        /// For instance, an application should not call <see cref="TranslateMessage"/>
        /// if the <see cref="TranslateAccelerator"/> function returns a nonzero value.
        /// Note that the application is responsible for retrieving and dispatching input messages to the dialog box.
        /// Most applications use the main message loop for this.
        /// However, to permit the user to move to and to select controls by using the keyboard,
        /// the application must call <see cref="IsDialogMessage"/>.
        /// For more information, see Dialog Box Keyboard Interface.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "TranslateMessage", ExactSpelling = true)]
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
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// Note that <see cref="WaitMessage"/> does not return for unprocessed messages reported by a previous function which checks the queue.
        /// This is because functions such as <see cref="PeekMessage"/>, <see cref="GetMessage"/>,
        /// <see cref="GetQueueStatus"/>, <see cref="WaitMessage"/>, <see cref="MsgWaitForMultipleObjects"/>,
        /// and <see cref="MsgWaitForMultipleObjectsEx"/> check the queue
        /// and then change the state information for the queue so that the message is no longer considered new.
        /// A subsequent call to <see cref="WaitMessage"/> will not return until new messages arrive.
        /// The existing unprocessed messages (received prior to the last time the thread checked the queue) are not considered to be new.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "WaitMessage", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL WaitMessage();
    }
}
