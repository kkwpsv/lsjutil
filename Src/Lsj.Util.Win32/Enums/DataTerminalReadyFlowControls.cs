namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Data-terminal-ready flow controls
    /// </summary>
    public enum DataTerminalReadyFlowControls : uint
    {
        /// <summary>
        /// DTR_CONTROL_DISABLE
        /// </summary>
        DTR_CONTROL_DISABLE = 0x00,

        /// <summary>
        /// DTR_CONTROL_ENABLE
        /// </summary>
        DTR_CONTROL_ENABLE = 0x01,

        /// <summary>
        /// DTR_CONTROL_HANDSHAKE
        /// </summary>
        DTR_CONTROL_HANDSHAKE = 0x02,
    }
}
