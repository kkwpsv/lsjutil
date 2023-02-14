using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Enums.CheckTokenMembershipExFlags;
using static Lsj.Util.Win32.Enums.CreateRestrictedTokenFlags;
using static Lsj.Util.Win32.Enums.GroupAttributes;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.TOKEN_INFORMATION_CLASS;
using static Lsj.Util.Win32.Enums.TokenAccessRights;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// The <see cref="CheckTokenMembershipEx"/> function determines whether the specified SID is enabled in the specified token.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-checktokenmembershipex"/>
        /// </para>
        /// </summary>
        /// <param name="TokenHandle">
        /// A handle to an access token.
        /// If present, this token is checked for the SID.
        /// If not present, then the current effective token is used. This must be an impersonation token.
        /// </param>
        /// <param name="SidToCheck">
        /// A pointer to a SID structure.
        /// The function checks for the presence of this SID in the presence of the token.
        /// </param>
        /// <param name="Flags">
        /// Flags that affect the behavior of the function.
        /// Currently the only valid flag is <see cref="CTMF_INCLUDE_APPCONTAINER"/> which allows app containers
        /// to pass the call as long as the other requirements of the token are met, such as the group specified is present and enabled.
        /// </param>
        /// <param name="IsMember">
        /// <see cref="TRUE"/> if the SID is enabled in the token; otherwise, <see cref="FALSE"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CheckTokenMembershipEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CheckTokenMembershipEx([In] HANDLE TokenHandle, [In] PSID SidToCheck,
            [In] CheckTokenMembershipExFlags Flags, [Out] out BOOL IsMember);
    }
}
