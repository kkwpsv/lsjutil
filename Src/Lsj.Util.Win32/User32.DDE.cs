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
		/// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/ddeml/nf-ddeml-ddeimpersonateclient"/>
		/// </para>
		/// </summary>
		/// <param name="hConv">
		/// A handle to the DDE client conversation to be impersonated.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is <see cref="TRUE"/>.
		/// If the function fails, the return value is <see cref="FALSE"/>.
		/// To get extended error information, call <see cref="GetLastError"/>.
		/// </returns>
		/// <remarks>
		/// Impersonation is the ability of a process to take on the security attributes of another process.
		/// When a client in a DDE conversation requests information from a DDE server, the server impersonates the client.
		/// When the server requests access to an object, the system verifies the access against the client's security attributes.
		/// When the impersonation is complete, the server normally calls the <see cref="RevertToSelf"/> function.
		/// Security Considerations
		/// If the call to DdeImpersonateClient fails for any reason, the client is not impersonated
        /// and the client request is made in the security context of the calling process.
        /// If the calling process is running as a highly privileged account, such as LocalSystem, or as a member of an administrative group,
        /// the user may be able to perform actions that would otherwise be disallowed.
        /// Therefore it is important that you always check the return value of the call, and if it fails to raise an error,
        /// do not continue execution of the client request. 
		/// </remarks>
		[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DdeImpersonateClient", ExactSpelling = true, SetLastError = true)]
		public static extern BOOL DdeImpersonateClient([In]HCONV hConv);
	}
}
