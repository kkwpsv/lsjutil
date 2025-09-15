using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Wtsapi32.dll
    /// </summary>
    public class Wtsapi32
    {
        /// <summary>
        /// <para>
        /// Obtains the primary access token of the logged-on user specified by the session ID.
        /// To call this function successfully, the calling application must be running within the context of the LocalSystem account 
        /// and have the SeTcbPrivilege privilege.
        /// </para>
        /// <para>
        /// Caution
        /// </para>
        /// <para>
        /// <see cref="WTSQueryUserToken"/> is intended for highly trusted services.Service providers
        /// must use caution that they do not leak user tokens when calling this function.
        /// Service providers must close token handles after they have finished using them.
        /// <para>
        /// </para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsqueryusertoken"/>
        /// </para>
        /// </summary>
        /// <param name="SessionId">
        /// <para>
        /// A Remote Desktop Services session identifier.
        /// Any program running in the context of a service will have a session identifier of zero (0).
        /// You can use the <see cref="WTSEnumerateSessions"/> function to retrieve the identifiers of all sessions on a specified RD Session Host server.
        /// </para>
        /// <para>
        /// To be able to query information for another user's session, you need to have the Query Information permission.
        /// For more information, see Remote Desktop Services Permissions.
        /// To modify permissions on a session, use the Remote Desktop Services Configuration administrative tool.
        /// </para>
        /// </param>
        /// <param name="phToken">
        /// If the function succeeds, receives a pointer to the token handle for the logged-on user. 
        /// Note that you must call the<see cref="CloseHandle"/>  function to close this handle.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a nonzero value,
        /// and the <paramref name="phToken"/> parameter points to the primary token of the user.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// For information about primary tokens, see Access Tokens.
        /// For more information about account privileges, see Remote Desktop Services Permissions and Authorization Constants.
        /// </para>
        /// <para>
        /// See LocalSystem account for information about the privileges associated with that account.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("Wtsapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "WTSQueryUserToken", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL WTSQueryUserToken([In] DWORD SessionId, [Out] out HANDLE phToken);

    }
}
