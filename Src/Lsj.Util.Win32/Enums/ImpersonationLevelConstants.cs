using static Lsj.Util.Win32.Ole32;
using static Lsj.Util.Win32.Advapi32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Specifies an impersonation level, which indicates the amount of authority given to the server when it is impersonating the client.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/com/com-impersonation-level-constants"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// <see cref="GetUserName"/> will fail while impersonating at identify level.
    /// The workaround is to impersonate, call <see cref="OpenThreadToken"/>, revert, call <see cref="GetTokenInformation"/>,
    /// and finally, call <see cref="LookupAccountSid"/>.
    /// Using <see cref="CoSetProxyBlanket"/>, the client sets the impersonation level
    /// </para>
    /// <para>
    /// Using <see cref="CoSetProxyBlanket"/>, the client sets the impersonation level and proxy identity
    /// that will be available when a server calls <see cref="CoImpersonateClient"/>.
    /// The identity the server will see when impersonating takes place is described in Cloaking.
    /// Note that when making a call while impersonating, the callee will normally receive the caller's process token, not the caller's impersonation token.
    /// To receive the caller's impersonation token, the caller must enable cloaking.
    /// </para>
    /// </remarks>
    public enum ImpersonationLevelConstants : uint
    {
        /// <summary>
        /// DCOM can choose the impersonation level using its normal security blanket negotiation algorithm.
        /// For more information, see Security Blanket Negotiation.
        /// </summary>
        RPC_C_IMP_LEVEL_DEFAULT = 0,

        /// <summary>
        /// The client is anonymous to the server.
        /// The server process can impersonate the client, but the impersonation token will not contain any information and cannot be used.
        /// </summary>
        RPC_C_IMP_LEVEL_ANONYMOUS = 1,

        /// <summary>
        /// The server can obtain the client's identity.
        /// The server can impersonate the client for ACL checking, but it cannot access system objects as the client.
        /// </summary>
        RPC_C_IMP_LEVEL_IDENTIFY = 2,

        /// <summary>
        /// The server process can impersonate the client's security context while acting on behalf of the client.
        /// This level of impersonation can be used to access local resources such as files.
        /// When impersonating at this level, the impersonation token can only be passed across one machine boundary.
        /// The Schannel authentication service only supports this level of impersonation.
        /// </summary>
        RPC_C_IMP_LEVEL_IMPERSONATE = 3,

        /// <summary>
        /// The server process can impersonate the client's security context while acting on behalf of the client.
        /// The server process can also make outgoing calls to other servers while acting on behalf of the client, using cloaking.
        /// The server may use the client's security context on other machines to access local and remote resources as the client.
        /// When impersonating at this level, the impersonation token can be passed across any number of computer boundaries.
        /// </summary>
        RPC_C_IMP_LEVEL_DELEGATE = 4,
    }
}
