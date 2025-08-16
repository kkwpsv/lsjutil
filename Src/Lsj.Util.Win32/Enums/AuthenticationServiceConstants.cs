using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Ole32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Defines authentication services by identifying the security package that provides the service, such as NTLMSSP, Kerberos, or Schannel.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/com/com-authentication-service-constants"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// These constants are used in the <see cref="SOLE_AUTHENTICATION_SERVICE"/> and the <see cref="SOLE_AUTHENTICATION_INFO"/> structures.
    /// The <see cref="SOLE_AUTHENTICATION_SERVICE"/> structure is passed by the server to the <see cref="CoInitializeSecurity"/> function
    /// and can be retrieved by the <see cref="CoQueryAuthenticationServices"/> function.
    /// A pointer to a <see cref="SOLE_AUTHENTICATION_INFO"/> structure is passed by the client to <see cref="CoInitializeSecurity"/>.
    /// For more information on the security packages identified by these values, such as NTLMSSP and Kerberos, see COM and Security Packages.
    /// </remarks>
    public enum AuthenticationServiceConstants : uint
    {
        /// <summary>
        /// No authentication.
        /// </summary>
        RPC_C_AUTHN_NONE = 0,

        /// <summary>
        /// DCE private key authentication.
        /// </summary>
        RPC_C_AUTHN_DCE_PRIVATE = 1,

        /// <summary>
        /// DCE public key authentication.
        /// </summary>
        RPC_C_AUTHN_DCE_PUBLIC = 2,

        /// <summary>
        /// DEC public key authentication. Reserved for future use.
        /// </summary>
        RPC_C_AUTHN_DEC_PUBLIC = 4,

        /// <summary>
        /// Snego security support provider.
        /// </summary>
        RPC_C_AUTHN_GSS_NEGOTIATE = 9,

        /// <summary>
        /// NTLMSSP
        /// </summary>
        RPC_C_AUTHN_WINNT = 10,

        /// <summary>
        /// Schannel security support provider.
        /// This authentication service supports SSL 2.0, SSL 3.0, TLS, and PCT.
        /// </summary>
        RPC_C_AUTHN_GSS_SCHANNEL = 14,

        /// <summary>
        /// Kerberos security support provider.
        /// </summary>
        RPC_C_AUTHN_GSS_KERBEROS = 16,

        /// <summary>
        /// DPA security support provider.
        /// </summary>
        RPC_C_AUTHN_DPA = 17,

        /// <summary>
        /// MSN security support provider.
        /// </summary>
        RPC_C_AUTHN_MSN = 18,

        /// <summary>
        /// Kernel security support provider.
        /// </summary>
        RPC_C_AUTHN_KERNEL = 20,

        /// <summary>
        /// Digest security support provider.
        /// </summary>
        RPC_C_AUTHN_DIGEST = 21,

        /// <summary>
        /// NEGO extender security support provider.
        /// </summary>
        RPC_C_AUTHN_NEGO_EXTENDER = 30,

        /// <summary>
        /// PKU2U security support provider.
        /// </summary>
        RPC_C_AUTHN_PKU2U = 31,

        /// <summary>
        /// RPC_C_AUTHN_LIVE_SSP
        /// </summary>
        RPC_C_AUTHN_LIVE_SSP = 32,

        /// <summary>
        /// RPC_C_AUTHN_LIVEXP_SSP
        /// </summary>
        RPC_C_AUTHN_LIVEXP_SSP = 35,

        /// <summary>
        /// RPC_C_AUTHN_CLOUD_AP
        /// </summary>
        RPC_C_AUTHN_CLOUD_AP = 36,

        /// <summary>
        /// RPC_C_AUTHN_MSONLINE
        /// </summary>
        RPC_C_AUTHN_MSONLINE = 82,

        /// <summary>
        /// MQ security support provider.
        /// </summary>
        RPC_C_AUTHN_MQ = 100,

        /// <summary>
        /// The system default authentication service.
        /// When this value is specified, COM uses its normal security blanket negotiation algorithm to pick an authentication service.
        /// For more information, see Security Blanket Negotiation.
        /// </summary>
        RPC_C_AUTHN_DEFAULT = 0xFFFFFFFF,
    }
}
