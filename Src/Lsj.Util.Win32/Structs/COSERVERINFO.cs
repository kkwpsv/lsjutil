using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.RPC_C_AUTHN_LEVEL;
using static Lsj.Util.Win32.Ole32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Identifies a remote computer resource to the activation functions.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/objidl/ns-objidl-coserverinfo"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="COSERVERINFO"/> structure is used primarily to identify a remote system in object creation functions.
    /// Computer resources are named using the naming scheme of the network transport.
    /// By default, all UNC ("\server" or "server") and DNS names ("domain.com", "example.microsoft.com", or "135.5.33.19") names are allowed.
    /// If <see cref="pAuthInfo"/> is set to <see cref="NULL"/>, Snego will be used to negotiate an authentication service
    /// that will work between the client and server.
    /// However, a non-NULL <see cref="COAUTHINFO"/> structure can be specified for <see cref="pAuthInfo"/> to meet any one of the following needs:
    /// To specify a different client identity for computer remote activations.
    /// The specified identity will be used for the launch permission check on the server rather than the real client identity.
    /// To specify that Kerberos, rather than NTLMSSP, is used for machine remote activation.
    /// A nondefault client identity may or may not be specified.
    /// To request unsecure activation.
    /// To specify a proprietary authentication service.
    /// If <see cref="pAuthInfo"/> is not <see cref="NULL"/>, those values will be used to specify the authentication settings for the remote call.
    /// These settings will be passed to the <see cref="RpcBindingSetAuthInfoEx"/> function.
    /// If the <see cref="pAuthInfo"/> parameter is <see cref="NULL"/>, then <see cref="COAUTHINFO.dwAuthnLevel"/> can be overridden
    /// by the authentication level set by the <see cref="CoInitializeSecurity"/> function.
    /// If the <see cref="CoInitializeSecurity"/> function isn't called,
    /// then the authentication level specified under the AppID registry key is used, if it exists.
    /// Starting with Windows XP with Service Pack 2 (SP2), <see cref="COAUTHINFO.dwAuthnLevel"/> is the maximum of <see cref="RPC_C_AUTHN_LEVEL_CONNECT"/>
    /// and the process-wide authentication level of the client process that is issuing the activation request.
    /// For earlier versions of the operating system, this is <see cref="RPC_C_AUTHN_LEVEL_CONNECT"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct COSERVERINFO
    {
        /// <summary>
        /// This member is reserved and must be 0.
        /// </summary>
        public DWORD dwReserved1;

        /// <summary>
        /// The name of the computer.
        /// </summary>
        public IntPtr pwszName;

        /// <summary>
        /// A pointer to a <see cref="COAUTHINFO"/> structure to override the default activation security for machine remote activations.
        /// Otherwise, set to <see cref="NULL"/> to indicate that default values should be used.
        /// For more information, see the Remarks section.
        /// </summary>
        public IntPtr pAuthInfo;

        /// <summary>
        /// This member is reserved and must be 0.
        /// </summary>
        public DWORD dwReserved2;
    }
}
