namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// RPC_C_AUTHZ
    /// </summary>
    public enum RPC_C_AUTHZ : uint
    {
        /// <summary>
        /// RPC_C_AUTHZ_NONE
        /// </summary>
        RPC_C_AUTHZ_NONE = 0,

        /// <summary>
        /// RPC_C_AUTHZ_NAME
        /// </summary>
        RPC_C_AUTHZ_NAME = 1,

        /// <summary>
        /// RPC_C_AUTHZ_DCE
        /// </summary>
        RPC_C_AUTHZ_DCE = 2,

        /// <summary>
        /// RPC_C_AUTHZ_DEFAULT
        /// </summary>
        RPC_C_AUTHZ_DEFAULT = 0xffffffff,
    }
}
