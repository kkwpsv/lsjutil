namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// CM_DEVCAP
    /// </summary>
    public enum CM_DEVCAP : uint
    {
        /// <summary>
        /// CM_DEVCAP_LOCKSUPPORTED
        /// </summary>
        CM_DEVCAP_LOCKSUPPORTED = 0x00000001,

        /// <summary>
        /// CM_DEVCAP_EJECTSUPPORTED
        /// </summary>
        CM_DEVCAP_EJECTSUPPORTED = 0x00000002,

        /// <summary>
        /// CM_DEVCAP_REMOVABLE
        /// </summary>
        CM_DEVCAP_REMOVABLE = 0x00000004,

        /// <summary>
        /// CM_DEVCAP_DOCKDEVICE
        /// </summary>
        CM_DEVCAP_DOCKDEVICE = 0x00000008,

        /// <summary>
        /// CM_DEVCAP_UNIQUEID
        /// </summary>
        CM_DEVCAP_UNIQUEID = 0x00000010,

        /// <summary>
        /// CM_DEVCAP_SILENTINSTALL
        /// </summary>
        CM_DEVCAP_SILENTINSTALL = 0x00000020,

        /// <summary>
        /// CM_DEVCAP_RAWDEVICEOK
        /// </summary>
        CM_DEVCAP_RAWDEVICEOK = 0x00000040,

        /// <summary>
        /// CM_DEVCAP_SURPRISEREMOVALOK
        /// </summary>
        CM_DEVCAP_SURPRISEREMOVALOK = 0x00000080,

        /// <summary>
        /// CM_DEVCAP_HARDWAREDISABLED
        /// </summary>
        CM_DEVCAP_HARDWAREDISABLED = 0x00000100,

        /// <summary>
        /// CM_DEVCAP_NONDYNAMIC
        /// </summary>
        CM_DEVCAP_NONDYNAMIC = 0x00000200,

        /// <summary>
        /// CM_DEVCAP_SECUREDEVICE
        /// </summary>
        CM_DEVCAP_SECUREDEVICE = 0x00000400,
    }
}
