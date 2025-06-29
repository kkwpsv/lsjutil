using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.MessageFilterFlags;
using static Lsj.Util.Win32.Enums.MSGFLTINFO;
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
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-changefilterstruct"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Certain messages whose value is smaller than <see cref="WM_USER"/> are required to pass through the filter, regardless of the filter setting.
    /// There will be no effect when you attempt to use this function to allow or block such messages.
    /// </para>
    /// <para>
    /// An application may use the <see cref="ChangeWindowMessageFilter"/> function to allow or block a message in a process-wide manner.
    /// If the message is allowed by either the process message filter or the window message filter, it will be delivered to the window.
    /// </para>
    /// <para>
    /// The following table lists the possible values returned in <see cref="ExtStatus"/>.
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Message already allowed at higher scope
    /// </term>
    /// <term>
    /// Message already allowed by window's message filter
    /// </term>
    /// <term>
    /// Operation requested
    /// </term>
    /// <term>
    /// Indicator returned in ExtStatus on success
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// No
    /// </term>
    /// <term>
    /// No
    /// </term>
    /// <term>
    /// <see cref="MSGFLT_ALLOW"/>
    /// </term>
    /// <term>
    /// <see cref="MSGFLTINFO_NONE"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// No
    /// </term>
    /// <term>
    /// No
    /// </term>
    /// <term>
    /// <see cref="MSGFLT_DISALLOW"/>
    /// </term>
    /// <term>
    /// <see cref="MSGFLTINFO_ALREADYDISALLOWED_FORWND"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// No
    /// </term>
    /// <term>
    /// No
    /// </term>
    /// <term>
    /// <see cref="MSGFLT_RESET"/>
    /// </term>
    /// <term>
    /// <see cref="MSGFLTINFO_NONE"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// No
    /// </term>
    /// <term>
    /// Yes
    /// </term>
    /// <term>
    /// <see cref="MSGFLT_ALLOW"/>
    /// </term>
    /// <term>
    /// <see cref="MSGFLTINFO_ALREADYALLOWED_FORWND"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// No
    /// </term>
    /// <term>
    /// Yes
    /// </term>
    /// <term>
    /// <see cref="MSGFLT_DISALLOW"/>
    /// </term>
    /// <term>
    /// <see cref="MSGFLTINFO_NONE"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// No
    /// </term>
    /// <term>
    /// Yes
    /// </term>
    /// <term>
    /// <see cref="MSGFLT_RESET"/>
    /// </term>
    /// <term>
    /// <see cref="MSGFLTINFO_NONE"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Yes
    /// </term>
    /// <term>
    /// No
    /// </term>
    /// <term>
    /// <see cref="MSGFLT_ALLOW"/>
    /// </term>
    /// <term>
    /// <see cref="MSGFLTINFO_NONE"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Yes
    /// </term>
    /// <term>
    /// No
    /// </term>
    /// <term>
    /// <see cref="MSGFLT_DISALLOW"/>
    /// </term>
    /// <term>
    /// <see cref="MSGFLTINFO_ALLOWED_HIGHER"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Yes
    /// </term>
    /// <term>
    /// No
    /// </term>
    /// <term>
    /// <see cref="MSGFLT_RESET"/>
    /// </term>
    /// <term>
    /// <see cref="MSGFLTINFO_NONE"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Yes
    /// </term>
    /// <term>
    /// Yes
    /// </term>
    /// <term>
    /// <see cref="MSGFLT_ALLOW"/>
    /// </term>
    /// <term>
    /// <see cref="MSGFLTINFO_ALREADYALLOWED_FORWND"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Yes
    /// </term>
    /// <term>
    /// Yes
    /// </term>
    /// <term>
    /// <see cref="MSGFLT_DISALLOW"/>
    /// </term>
    /// <term>
    /// <see cref="MSGFLTINFO_ALLOWED_HIGHER"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Yes
    /// </term>
    /// <term>
    /// Yes
    /// </term>
    /// <term>
    /// <see cref="MSGFLT_RESET"/>
    /// </term>
    /// <term>
    /// <see cref="MSGFLTINFO_NONE"/>
    /// </term>
    /// </item>
    /// </list>
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
        /// </summary>
        public MSGFLTINFO ExtStatus;
    }
}
