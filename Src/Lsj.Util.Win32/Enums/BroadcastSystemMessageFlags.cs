using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="BroadcastSystemMessage"/> and <see cref="BroadcastSystemMessageEx"/> Flags
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-broadcastsystemmessagew"/>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-broadcastsystemmessageexw"/>
    /// </para>
    /// </summary>
    public enum BroadcastSystemMessageFlags : uint
    {
        /// <summary>
        /// Enables the recipient to set the foreground window while processing the message.
        /// </summary>
        BSF_ALLOWSFW = 0x00000080,

        /// <summary>
        /// /Flushes the disk after each recipient processes the message.
        /// </summary>
        BSF_FLUSHDISK = 0x00000004,

        /// <summary>
        /// Continues to broadcast the message, even if the time-out period elapses or one of the recipients is not responding.
        /// </summary>
        BSF_FORCEIFHUNG = 0x00000020,

        /// <summary>
        /// Does not send the message to windows that belong to the current task.
        /// This prevents an application from receiving its own message.
        /// </summary>
        BSF_IGNORECURRENTTASK = 0x00000002,

        /// <summary>
        /// Forces a nonresponsive application to time out.
        /// If one of the recipients times out, do not continue broadcasting the message.
        /// </summary>
        BSF_NOHANG = 0x00000008,

        /// <summary>
        /// Waits for a response to the message, as long as the recipient is not being unresponsive.
        /// Does not time out.
        /// </summary>
        BSF_NOTIMEOUTIFNOTHUNG = 0x00000040,

        /// <summary>
        /// Posts the message.
        /// Do not use in combination with <see cref="BSF_QUERY"/>.
        /// </summary>
        BSF_POSTMESSAGE = 0x00000010,

        /// <summary>
        /// Sends the message to one recipient at a time,
        /// sending to a subsequent recipient only if the current recipient returns <see cref="TRUE"/>.
        /// </summary>
        BSF_QUERY = 0x00000001,

        /// <summary>
        /// Sends the message using <see cref="SendNotifyMessage"/> function.
        /// Do not use in combination with <see cref="BSF_QUERY"/>.
        /// </summary>
        BSF_SENDNOTIFYMESSAGE = 0x00000100,

        /// <summary>
        /// If <see cref="BSF_LUID"/> is set, the message is sent to the window
        /// that has the same LUID as specified in the <see cref="BSMINFO.luid"/> member of the <see cref="BSMINFO"/> structure.
        /// Windows 2000:  This flag is not supported.
        /// </summary>
        BSF_LUID = 0x00000400,

        /// <summary>
        /// If access is denied and both this and <see cref="BSF_QUERY"/> are set,
        /// <see cref="BSMINFO"/> returns both the desktop handle and the window handle.
        /// If access is denied and only <see cref="BSF_QUERY"/> is set,
        /// only the window handle is returned by <see cref="BSMINFO"/>.
        /// Windows 2000:  This flag is not supported.
        /// </summary>
        BSF_RETURNHDESK = 0x00000200,
    }
}
