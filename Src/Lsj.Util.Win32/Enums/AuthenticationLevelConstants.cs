namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// These values specify an authentication level, which indicates the amount of authentication provided to help protect the integrity of the data.
    /// Each level includes the protection provided by the previous levels.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/com/com-authentication-level-constants"/>
    /// </para>
    /// </summary>
    public enum AuthenticationLevelConstants : uint
    {
        /// <summary>
        /// Tells DCOM to choose the authentication level using its normal security blanket negotiation algorithm.
        /// For more information, see Security Blanket Negotiation.
        /// </summary>
        RPC_C_AUTHN_LEVEL_DEFAULT = 0,

        /// <summary>
        /// Performs no authentication.
        /// </summary>
        RPC_C_AUTHN_LEVEL_NONE = 1,

        /// <summary>
        /// Authenticates the credentials of the client only when the client establishes a relationship with the server.
        /// Datagram transports always use <see cref="RPC_C_AUTHN_LEVEL_PKT"/> instead.
        /// </summary>
        RPC_C_AUTHN_LEVEL_CONNECT = 2,

        /// <summary>
        /// Authenticates only at the beginning of each remote procedure call when the server receives the request.
        /// Datagram transports use <see cref="RPC_C_AUTHN_LEVEL_PKT"/> instead.
        /// </summary>
        RPC_C_AUTHN_LEVEL_CALL = 3,

        /// <summary>
        /// Authenticates that all data received is from the expected client.
        /// </summary>
        RPC_C_AUTHN_LEVEL_PKT = 4,

        /// <summary>
        /// Authenticates and verifies that none of the data transferred between client and server has been modified.
        /// </summary>
        RPC_C_AUTHN_LEVEL_PKT_INTEGRITY = 5,

        /// <summary>
        /// Authenticates all previous levels and encrypts the argument value of each remote procedure call.
        /// </summary>
        RPC_C_AUTHN_LEVEL_PKT_PRIVACY = 6,
    }
}
