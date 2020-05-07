namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// RPC_C_AUTHN
    /// </summary>
    public enum RPC_C_AUTHN : uint
    {
        /// <summary>
        /// RPC_C_AUTHN_NONE
        /// </summary>
        RPC_C_AUTHN_NONE = 0,

        /// <summary>
        /// RPC_C_AUTHN_DCE_PRIVATE
        /// </summary>
        RPC_C_AUTHN_DCE_PRIVATE = 1,

        /// <summary>
        /// RPC_C_AUTHN_DCE_PUBLIC
        /// </summary>
        RPC_C_AUTHN_DCE_PUBLIC = 2,

        /// <summary>
        /// RPC_C_AUTHN_DEC_PUBLIC
        /// </summary>
        RPC_C_AUTHN_DEC_PUBLIC = 4,

        /// <summary>
        /// RPC_C_AUTHN_GSS_NEGOTIATE
        /// </summary>
        RPC_C_AUTHN_GSS_NEGOTIATE = 9,

        /// <summary>
        /// RPC_C_AUTHN_WINNT
        /// </summary>
        RPC_C_AUTHN_WINNT = 10,

        /// <summary>
        /// RPC_C_AUTHN_GSS_SCHANNEL
        /// </summary>
        RPC_C_AUTHN_GSS_SCHANNEL = 14,

        /// <summary>
        /// RPC_C_AUTHN_GSS_KERBEROS
        /// </summary>
        RPC_C_AUTHN_GSS_KERBEROS = 16,

        /// <summary>
        /// RPC_C_AUTHN_DPA
        /// </summary>
        RPC_C_AUTHN_DPA = 17,

        /// <summary>
        /// RPC_C_AUTHN_MSN
        /// </summary>
        RPC_C_AUTHN_MSN = 18,

        /// <summary>
        /// RPC_C_AUTHN_DIGEST
        /// </summary>
        RPC_C_AUTHN_DIGEST = 21,

        /// <summary>
        /// RPC_C_AUTHN_KERNEL
        /// </summary>
        RPC_C_AUTHN_KERNEL = 20,

        /// <summary>
        /// RPC_C_AUTHN_NEGO_EXTENDER
        /// </summary>
        RPC_C_AUTHN_NEGO_EXTENDER = 30,

        /// <summary>
        /// RPC_C_AUTHN_PKU2U
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
        /// RPC_C_AUTHN_MQ
        /// </summary>
        RPC_C_AUTHN_MQ = 100,

        /// <summary>
        /// RPC_C_AUTHN_DEFAULT
        /// </summary>
        RPC_C_AUTHN_DEFAULT = 0xFFFFFFFF,
    }
}
