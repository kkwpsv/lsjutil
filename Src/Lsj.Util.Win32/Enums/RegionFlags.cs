namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Region Flags
    /// </summary>
    public enum RegionFlags
    {
        /// <summary>
        /// ERROR
        /// </summary>
        ERROR = 0,

        /// <summary>
        /// Region is empty.
        /// </summary>
        NULLREGION = 1,

        /// <summary>
        /// Region consists of a single rectangle.
        /// </summary>
        SIMPLEREGION = 2,

        /// <summary>
        /// Region consists of more than one rectangle.
        /// </summary>
        COMPLEXREGION = 3,

        /// <summary>
        /// ERROR
        /// </summary>
        RGN_ERROR = ERROR,
    }
}
