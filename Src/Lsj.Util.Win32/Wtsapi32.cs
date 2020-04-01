using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32
{
    public class Wtsapi32
    {
        /// <summary>
        /// Retrieves the session identifier of the console session. 
        /// The console session is the session that is currently attached to the physical console. 
        /// Note that it is not necessary that Remote Desktop Services be running for this function to succeed.
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-wtsgetactiveconsolesessionid
        /// </para>
        /// </summary>
        /// <returns>
        /// The session identifier of the session that is attached to the physical console. 
        /// If there is no session attached to the physical console, (for example, 
        /// if the physical console session is in the process of being attached or detached), this function returns 0xFFFFFFFF.
        /// </returns>
        /// <remarks>
        /// The session identifier returned by this function is the identifier of the current physical console session. 
        /// To monitor the state of the current physical console session, use the<see cref="WTSRegisterSessionNotification"/>  function.
        /// </remarks>
        [DllImport("Kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WTSGetActiveConsoleSessionId", SetLastError = true)]
        public static extern ulong WTSGetActiveConsoleSessionId();
        /// <summary>
        /// Obtains the primary access token of the logged-on user specified by the session ID. To call this function successfully, 
        /// the calling application must be running within the context of the LocalSystem account and have the SE_TCB_NAME privilege.
        /// Caution WTSQueryUserToken is intended for highly trusted services.Service providers must use caution that they do not leak user tokens when calling this function.
        /// Service providers must close token handles after they have finished using them.
        /// <para>
        ///  From: https://docs.microsoft.com/zh-cn/windows/win32/api/wtsapi32/nf-wtsapi32-wtsqueryusertoken
        /// </para>
        /// </summary>
        /// <param name="SessionId">
        /// When this function returns, receives a pointer to the new environment block.
        /// The environment block is an array of null-terminated Unicode strings. The list ends with two nulls (\0\0).
        /// </param>
        /// <param name="phToken">
        /// If the function succeeds, receives a pointer to the token handle for the logged-on user. 
        /// Note that you must call the<see cref="CloseHandle"/>  function to close this handle.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a nonzero value, and the phToken parameter points to the primary token of the user.
        /// If the function fails, the return value is zero.To get extended error information, call GetLastError.Among other errors,
        /// <see cref="GetLastError"/> can return one of the following errors.
        /// </returns>
        /// <remarks>
        /// For information about primary tokens, see Access Tokens. 
        /// For more information about account privileges, see Remote Desktop Services Permissions and Authorization Constants.
        /// See LocalSystem account for information about the privileges associated with that account.
        /// </remarks>

        [DllImport("Wtsapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "WTSQueryUserToken", SetLastError = true)]
        public static extern bool WTSQueryUserToken([In]ulong SessionId, [Out]out IntPtr phToken);

    }
}
