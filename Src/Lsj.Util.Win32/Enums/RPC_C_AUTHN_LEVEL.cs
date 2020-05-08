namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// RPC_C_AUTHN_LEVEL
    /// </summary>
    public enum RPC_C_AUTHN_LEVEL : uint
    {
        /// <summary>
        /// RPC_C_AUTHN_LEVEL_DEFAULT
        /// </summary>
        RPC_C_AUTHN_LEVEL_DEFAULT = 0,

        /// <summary>
        /// RPC_C_AUTHN_LEVEL_NONE
        /// </summary>
        RPC_C_AUTHN_LEVEL_NONE = 1,

        /// <summary>
        /// RPC_C_AUTHN_LEVEL_CONNECT
        /// </summary>
        RPC_C_AUTHN_LEVEL_CONNECT = 2,

        /// <summary>
        /// RPC_C_AUTHN_LEVEL_CALL
        /// </summary>
        RPC_C_AUTHN_LEVEL_CALL = 3,

        /// <summary>
        /// RPC_C_AUTHN_LEVEL_PKT
        /// </summary>
        RPC_C_AUTHN_LEVEL_PKT = 4,

        /// <summary>
        /// RPC_C_AUTHN_LEVEL_PKT_INTEGRITY
        /// </summary>
        RPC_C_AUTHN_LEVEL_PKT_INTEGRITY = 5,

        /// <summary>
        /// RPC_C_AUTHN_LEVEL_PKT_PRIVACY
        /// </summary>
        RPC_C_AUTHN_LEVEL_PKT_PRIVACY = 6,
    }
}
