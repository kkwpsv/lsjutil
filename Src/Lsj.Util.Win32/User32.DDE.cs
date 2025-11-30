using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32
{
    public partial class User32
	{
        /// <summary>
        /// <para>
        /// Impersonates a Dynamic Data Exchange (DDE) client application in a DDE client conversation.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/ddeml/nf-ddeml-ddeimpersonateclient"/>
        /// </para>
        /// </summary>
        /// <param name="hConv">
        /// A handle to the DDE client conversation to be impersonated.
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
        /// Impersonation is the ability of a process to take on the security attributes of another process.
        /// When a client in a DDE conversation requests information from a DDE server, the server impersonates the client.
        /// When the server requests access to an object, the system verifies the access against the client's security attributes.
        /// </para>
        /// <para>
        /// When the impersonation is complete, the server normally calls the <see cref="RevertToSelf"/> function.
        /// </para>
        /// <para>
        /// Security Considerations
        /// </para>
        /// <para>
        /// If the call to <see cref="DdeImpersonateClient"/> fails for any reason,
        /// the client is not impersonated and the client request is made in the security context of the calling process.
        /// If the calling process is running as a highly privileged account, such as LocalSystem, or as a member of an administrative group,
        /// the user may be able to perform actions that would otherwise be disallowed.
        /// Therefore it is important that you always check the return value of the call,
        /// and if it fails to raise an error, do not continue execution of the client request.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DdeImpersonateClient", ExactSpelling = true, SetLastError = true)]
		public static extern BOOL DdeImpersonateClient([In]HCONV hConv);

        /// <summary>
        /// <para>
        /// Enables a Dynamic Data Exchange (DDE) server application to impersonate a DDE client application's security context.
        /// This protects secure server data from unauthorized DDE clients.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dde/nf-dde-impersonateddeclientwindow"/>
        /// </para>
        /// </summary>
        /// <param name="hWndClient">
        /// A handle to the DDE client window to be impersonated.
        /// The client window must have established a DDE conversation
        /// with the server window identified by the <paramref name="hWndServer"/> parameter.
        /// </param>
        /// <param name="hWndServer">
        /// A handle to the DDE server window.
        /// An application must create the server window before calling this function.
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
        /// An application should call the <see cref="RevertToSelf"/> function
        /// to undo the impersonation set by the <see cref="ImpersonateDdeClientWindow"/> function.
        /// </para>
        /// <para>
        /// A DDEML application should use the <see cref="DdeImpersonateClient"/> function.
        /// </para>
        /// <para>
        /// Security Considerations
        /// </para>
        /// <para>
        /// Using this function incorrectly might compromise the security of your program.
        /// It is very important to check the return value of the call.
        /// If the function fails for any reason, the client is not impersonated
        /// and any subsequent client request is made in the security context of the calling process.
        /// If the calling process is running as a highly privileged account, such as LocalSystem or as a member of an administrative group,
        /// the user may be able to perform actions that would otherwise be disallowed.
        /// Therefore, if the call fails or raises an error do not continue execution of the client request.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ImpersonateDdeClientWindow", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ImpersonateDdeClientWindow([In] HWND hWndClient, [In] HWND hWndServer);
    }
}
