namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Window Display Affinities
    /// </summary>
    public enum WindowDisplayAffinities : uint
    {
        /// <summary>
        /// WDA_NONE
        /// </summary>
        WDA_NONE = 0x00000000,

        /// <summary>
        /// WDA_MONITOR
        /// </summary>
        WDA_MONITOR = 0x00000001,

        /// <summary>
        /// WDA_EXCLUDEFROMCAPTURE
        /// </summary>
        WDA_EXCLUDEFROMCAPTURE = 0x00000011,
    }
}
