using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The ID of the input message source.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ne-winuser-input_message_origin_id"/>
    /// </para>
    /// </summary>
    public enum INPUT_MESSAGE_ORIGIN_ID
    {
        /// <summary>
        /// The source isn't identified.
        /// </summary>
        IMO_UNAVAILABLE = 0x00000000,

        /// <summary>
        /// <para>
        /// The input message is from a hardware device or has been injected into the message queue
        /// by an application that has the <c>UIAccess</c> attribute set to <c>TRUE</c> in its manifest file.
        /// </para>
        /// <para>
        /// For more information about the <c>UIAccess</c> attribute and application manifests, see UAC References.
        /// </para>
        /// </summary>
        IMO_HARDWARE = 0x00000001,

        /// <summary>
        /// The input message has been injected (through the <see cref="SendInput"/> function)
        /// by an application that doesn't have the <c>UIAccess</c> attribute set to <c>TRUE</c> in its manifest file.
        /// </summary>
        IMO_INJECTED = 0x00000002,

        /// <summary>
        /// The system has injected the input message.
        /// </summary>
        IMO_SYSTEM = 0x00000004
    }
}
