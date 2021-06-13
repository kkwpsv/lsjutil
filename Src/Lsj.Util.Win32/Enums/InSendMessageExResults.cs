using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="InSendMessageEx"/> Results
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-insendmessageex?redirectedfrom=MSDN"/>
    /// </para>
    /// </summary>
    public enum InSendMessageExResults : uint
    {
        /// <summary>
        /// 
        /// </summary>
        ISMEX_NOSEND = 0x00000000,

        /// <summary>
        /// The message was sent using the <see cref="SendMessageCallback"/> function.
        /// The thread that sent the message is not blocked. 
        /// </summary>
        ISMEX_CALLBACK = 0x00000004,

        /// <summary>
        /// The message was sent using the <see cref="SendNotifyMessage"/> function.
        /// The thread that sent the message is not blocked. 
        /// </summary>
        ISMEX_NOTIFY = 0x00000002,

        /// <summary>
        /// The window procedure has processed the message.
        /// The thread that sent the message is no longer blocked. 
        /// </summary>
        ISMEX_REPLIED = 0x00000008,

        /// <summary>
        /// The message was sent using the <see cref="SendMessage"/> or <see cref="SendMessageTimeout"/> function.
        /// If <see cref="ISMEX_REPLIED"/> is not set, the thread that sent the message is blocked. 
        /// </summary>
        ISMEX_SEND = 0x00000001,
    }
}
