using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Enums.AuthenticationServiceConstants;
using static Lsj.Util.Win32.Ole32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Defines what the server authorizes.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/com/com-authorization-constants"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// These constants are used by methods of the <see cref="IClientSecurity"/> interface.
    /// They are used in the <see cref="SOLE_AUTHENTICATION_SERVICE"/> structure,
    /// which is retrieved by the <see cref="CoQueryAuthenticationServices"/> function.
    /// They are also used in the <see cref="SOLE_AUTHENTICATION_INFO"/> structure,
    /// which in turn is a member of the <see cref="SOLE_AUTHENTICATION_LIST"/> structure.
    /// This structure, which is a list of authentication services, the authorization services they perform,
    /// and the authentication information for each service, is passed to the <see cref="CoInitializeSecurity"/> function
    /// and the <see cref="IClientSecurity.SetBlanket"/> method.
    /// </remarks>
    public enum AuthorizationConstants : uint
    {
        /// <summary>
        /// The server performs no authorization.
        /// Currently, <see cref="RPC_C_AUTHN_WINNT"/>, <see cref="RPC_C_AUTHN_GSS_SCHANNEL"/>,
        /// and <see cref="RPC_C_AUTHN_GSS_KERBEROS"/> all use only <see cref="RPC_C_AUTHZ_NONE"/>.
        /// </summary>
        RPC_C_AUTHZ_NONE = 0,

        /// <summary>
        /// The server performs authorization based on the client's principal name.
        /// </summary>
        RPC_C_AUTHZ_NAME = 1,

        /// <summary>
        /// The server performs authorization checking using the client's DCE privilege attribute certificate (PAC) information,
        /// which is sent to the server with each remote procedure call made using the binding handle.
        /// Generally, access is checked against DCE access control lists (ACLs).
        /// </summary>
        RPC_C_AUTHZ_DCE = 2,

        /// <summary>
        /// DCOM can choose the authorization level using its normal security blanket negotiation algorithm.
        /// For more information, see Security Blanket Negotiation.
        /// </summary>
        RPC_C_AUTHZ_DEFAULT = 0xffffffff,
    }
}
