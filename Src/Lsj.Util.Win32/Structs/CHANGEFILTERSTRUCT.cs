using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.MessageFilterFlags;
using static Lsj.Util.Win32.Enums.MessageFilterInfoValues;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains extended result information obtained by calling the <see cref="ChangeWindowMessageFilterEx"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-changefilterstruct"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Certain messages whose value is smaller than <see cref="WM_USER"/> are required to pass through the filter,
    /// regardless of the filter setting.
    /// There will be no effect when you attempt to use this function to allow or block such messages.
    /// An application may use the <see cref="ChangeWindowMessageFilter"/> function to allow or block a message in a process-wide manner.
    /// If the message is allowed by either the process message filter or the window message filter, it will be delivered to the window.
    /// The following table lists the possible values returned in <see cref="ExtStatus"/>.
    /// Message already allowed at higher scope     Message already allowed by window's message filter      Operation requested             Indicator returned in <see cref="ExtStatus"/> on success
    /// No                                          No                                                      <see cref="MSGFLT_ALLOW"/>      <see cref="MSGFLTINFO_NONE"/>
    /// No                                          No                                                      <see cref="MSGFLT_DISALLOW"/>   <see cref="MSGFLTINFO_ALREADYDISALLOWED_FORWND"/>
    /// No                                          No                                                      <see cref="MSGFLT_RESET"/>      <see cref="MSGFLTINFO_NONE"/>
    /// No                                          Yes                                                     <see cref="MSGFLT_ALLOW"/>      <see cref="MSGFLTINFO_ALREADYALLOWED_FORWND"/>
    /// No                                          Yes                                                     <see cref="MSGFLT_DISALLOW"/>   <see cref="MSGFLTINFO_NONE"/>
    /// No                                          Yes                                                     <see cref="MSGFLT_RESET"/>      <see cref="MSGFLTINFO_NONE"/>
    /// Yes                                         No                                                      <see cref="MSGFLT_ALLOW"/>      <see cref="MSGFLTINFO_NONE"/>
    /// Yes                                         No                                                      <see cref="MSGFLT_DISALLOW"/>   <see cref="MSGFLTINFO_ALLOWED_HIGHER"/>
    /// Yes                                         No                                                      <see cref="MSGFLT_RESET"/>      <see cref="MSGFLTINFO_NONE"/>
    /// Yes                                         Yes                                                     <see cref="MSGFLT_ALLOW"/>      <see cref="MSGFLTINFO_ALREADYALLOWED_FORWND"/>
    /// Yes                                         Yes                                                     <see cref="MSGFLT_DISALLOW"/>   <see cref="MSGFLTINFO_ALLOWED_HIGHER"/>
    /// Yes                                         Yes                                                     <see cref="MSGFLT_RESET"/>      <see cref="MSGFLTINFO_NONE"/>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CHANGEFILTERSTRUCT
    {
        /// <summary>
        /// The size of the structure, in bytes.
        /// Must be set to <code>sizeof(CHANGEFILTERSTRUCT)</code>,
        /// otherwise the function fails with <see cref="ERROR_INVALID_PARAMETER"/>.
        /// </summary>
        public DWORD cbSize;

        /// <summary>
        /// If the function succeeds, this field contains one of the following values.
        /// <see cref="MSGFLTINFO_NONE"/>:
        /// See the Remarks section. Applies to <see cref="MSGFLT_ALLOW"/> and <see cref="MSGFLT_DISALLOW"/>.
        /// <see cref="MSGFLTINFO_ALLOWED_HIGHER"/>:
        /// The message is allowed at a scope higher than the window. Applies to <see cref="MSGFLT_DISALLOW"/>.
        /// <see cref="MSGFLTINFO_ALREADYALLOWED_FORWND"/>:
        /// The message has already been allowed by this window's message filter, 
        /// and the function thus succeeded with no change to the window's message filter.
        /// Applies to <see cref="MSGFLT_ALLOW"/>.
        /// <see cref="MSGFLTINFO_ALREADYDISALLOWED_FORWND"/>:
        /// The message has already been blocked by this window's message filter,
        /// and the function thus succeeded with no change to the window's message filter.
        /// Applies to <see cref="MSGFLT_DISALLOW"/>.
        /// </summary>
        public MessageFilterInfoValues ExtStatus;
    }
}
