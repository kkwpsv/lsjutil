namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// ICM Modes
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-seticmmode"/>
    /// </para>
    /// </summary>
    public enum ICMModes
    {
        /// <summary>
        /// Turns off color management. Turns on old-style color correction of halftones.
        /// </summary>
        ICM_OFF = 1,

        /// <summary>
        /// Turns on color management. Turns off old-style color correction of halftones.
        /// </summary>
        ICM_ON = 2,

        /// <summary>
        /// Queries the current state of color management.
        /// </summary>
        ICM_QUERY = 3,

        /// <summary>
        /// Turns off color management inside DC.
        /// Under Windows 2000, also turns off old-style color correction of halftones. Not supported under Windows 95.
        /// </summary>
        ICM_DONE_OUTSIDEDC = 4,
    }
}
