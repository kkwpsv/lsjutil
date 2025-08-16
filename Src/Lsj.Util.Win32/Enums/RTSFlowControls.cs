namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// RTS flow controls
    /// </summary>
    public enum RTSFlowControls : uint
    {
        /// <summary>
        /// RTS_CONTROL_DISABLE
        /// </summary>
        RTS_CONTROL_DISABLE = 0x00,

        /// <summary>
        /// RTS_CONTROL_ENABLE
        /// </summary>
        RTS_CONTROL_ENABLE = 0x01,

        /// <summary>
        ///RTS_CONTROL_HANDSHAKE
        /// </summary>
        RTS_CONTROL_HANDSHAKE = 0x02,

        /// <summary>
        /// RTS_CONTROL_TOGGLE
        /// </summary>
        RTS_CONTROL_TOGGLE = 0x03,
    }
}
