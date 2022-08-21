namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// PointTypes
    /// </summary>
    public enum PointTypes : byte
    {
        /// <summary>
        /// PT_CLOSEFIGURE
        /// </summary>
        PT_CLOSEFIGURE = 0x01,

        /// <summary>
        /// PT_LINETO
        /// </summary>
        PT_LINETO = 0x02,

        /// <summary>
        /// PT_BEZIERTO
        /// </summary>
        PT_BEZIERTO = 0x04,

        /// <summary>
        /// PT_MOVETO
        /// </summary>
        PT_MOVETO = 0x06,
    }
}
