using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.EOLE_AUTHENTICATION_CAPABILITIES;
using static Lsj.Util.Win32.Enums.RPC_C_AUTHN;
using static Lsj.Util.Win32.Enums.RPC_C_AUTHN_LEVEL;
using static Lsj.Util.Win32.Enums.RPC_C_AUTHZ;
using static Lsj.Util.Win32.Enums.RPC_C_IMP_LEVEL;
using static Lsj.Util.Win32.Ole32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains the authentication settings used while making a remote activation request from the client computer to the server computer.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wtypesbase/ns-wtypesbase-coauthinfo"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// If <see cref="COSERVERINFO.pAuthInfo"/> in <see cref="COSERVERINFO"/> is set to <see cref="NULL"/>,
    /// Snego will be used to negotiate an authentication service that will work between the client and server.
    /// However, a non-NULL <see cref="COAUTHINFO"/> structure can be specified for pAuthInfo to meet any one of the following needs:
    /// To specify a different client identity for computer remote activations.
    /// The specified identity will be used for the launch permission check on the server rather than the real client identity.
    /// To specify that Kerberos, rather than NTLMSSP, is used for machine remote activation.A nondefault client identity may or may not be specified.
    /// To request unsecure activation.
    /// To specify a proprietary authentication service.
    /// Specifying a <see cref="COAUTHINFO"/> structure allows DCOM activations to work correctly with security providers other than NTLMSSP.
    /// You can also specify additional security information used during remote activations for interoperability with alternate implementations of DCOM.
    /// If you set <see cref="dwAuthzSvc"/>, <see cref="pwszServerPrincName"/>, <see cref="dwImpersonationLevel"/>,
    /// or <see cref="dwCapabilities"/> to incorrect values and call either <see cref="CoGetClassObject"/> or <see cref="CoCreateInstanceEx"/>,
    /// these functions do not return <see cref="E_INVALIDARG"/> or a similar error.
    /// Default values are used instead of the incorrect values.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct COAUTHINFO
    {
        /// <summary>
        /// The authentication service to be used.
        /// For a list of values, see Authentication Service Constants.
        /// Use <see cref="RPC_C_AUTHN_NONE"/> if no authentication is required.
        /// <see cref="RPC_C_AUTHN_WINNT"/> is the default and <see cref="RPC_C_AUTHN_GSS_KERBEROS"/> is also supported.
        /// </summary>
        public RPC_C_AUTHN dwAuthnSvc;

        /// <summary>
        /// The authorization service to be used.
        /// For a list of values, see Authorization Constants.
        /// To use the NT authentication service, specify <see cref="RPC_C_AUTHZ_NONE"/>.
        /// </summary>
        public RPC_C_AUTHZ dwAuthzSvc;

        /// <summary>
        /// The server principal name to use with the authentication service.
        /// If you are using <see cref="RPC_C_AUTHN_WINNT"/>, the principal name must be <see langword="null"/>.
        /// </summary>
        public IntPtr pwszServerPrincName;

        /// <summary>
        /// The authentication level to be used.
        /// For a list of values, see Authentication Level Constants.
        /// As of Windows Server 2003, remote activations use the default authentication level
        /// specified in the <see cref="CoInitializeSecurity"/> dwAuthnLevel parameter.
        /// In previous versions of Windows, <see cref="RPC_C_AUTHN_LEVEL_CONNECT"/> was always
        /// used for the security level unless another level was explicitly specified.
        /// </summary>
        public RPC_C_AUTHN_LEVEL dwAuthnLevel;

        /// <summary>
        /// The impersonation level to be used.
        /// For a list of values, see Impersonation Level Constants.
        /// This value must be <see cref="RPC_C_IMP_LEVEL_IMPERSONATE"/> or above.
        /// </summary>
        public RPC_C_IMP_LEVEL dwImpersonationLevel;

        /// <summary>
        /// A pointer to a <see cref="COAUTHIDENTITY"/> structure that establishes a nondefault client identity.
        /// If this parameter is <see cref="NULL"/>, the actual identity of the client is used.
        /// Values of structure members are authentication-service specific.
        /// This value must be <see cref="NULL"/> if <see cref="dwAuthnSvc"/> does not specify
        /// either the NTLMSSP or Kerberos network authentication protocol is used as the authorization service.
        /// </summary>
        public IntPtr pAuthIdentityData;

        /// <summary>
        /// Indicates additional capabilities of this proxy.
        /// Currently, this member must be <see cref="EOAC_NONE"/> (0x0) or <see cref="RPC_C_QOS_CAPABILITIES_MUTUAL_AUTH"/> (0x1).
        /// Use <see cref="RPC_C_QOS_CAPABILITIES_MUTUAL_AUTH"/> if Kerberos is required.
        /// </summary>
        public DWORD dwCapabilities;
    }
}
