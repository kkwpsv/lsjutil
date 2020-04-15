using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Ole32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Identifies an authentication service that a server is willing to use to communicate to a client.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/objidl/ns-objidl-sole_authentication_service
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SOLE_AUTHENTICATION_SERVICE
    {
        /// <summary>
        /// The authentication service. This member can be a single value from the Authentication Service Constants.
        /// </summary>
        public DWORD dwAuthnSvc;

        /// <summary>
        /// The authorization service. This member can be a single value from the Authorization Constants.
        /// </summary>
        public DWORD dwAuthzSvc;

        /// <summary>
        /// The principal name to be used with the authentication service.
        /// If the principal name is <see langword="null"/>, the current user identifier is assumed.
        /// A NULL principal name is allowed for NTLMSSP, Kerberos, and Snego authentication services but may not work for other authentication services.
        /// For Schannel, this member must point to a <see cref="CERT_CONTEXT"/> structure that contains the server's certificate;
        /// if it NULL and if a certificate for the current user does not exist, <see cref="RPC_E_NO_GOOD_SECURITY_PACKAGES"/> is returned.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pPrincipalName;

        /// <summary>
        /// When used in <see cref="CoInitializeSecurity"/>, set on return to indicate the status of the call to register the authentication services.
        /// </summary>
        public HRESULT hr;
    }
}
