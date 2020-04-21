using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="MENUITEMINFO"/> Masks
    /// </summary>
    public enum MENUITEMINFOMasks : uint
    {
        /// <summary>
        /// MIIM_STATE
        /// </summary>
        MIIM_STATE = 0x00000001,

        /// <summary>
        /// MIIM_ID
        /// </summary>
        MIIM_ID = 0x00000002,

        /// <summary>
        /// MIIM_SUBMENU
        /// </summary>
        MIIM_SUBMENU = 0x00000004,

        /// <summary>
        /// MIIM_CHECKMARKS
        /// </summary>
        MIIM_CHECKMARKS = 0x00000008,

        /// <summary>
        /// MIIM_TYPE
        /// </summary>
        MIIM_TYPE = 0x00000010,

        /// <summary>
        /// MIIM_DATA
        /// </summary>
        MIIM_DATA = 0x00000020,

        /// <summary>
        /// MIIM_STRING
        /// </summary>
        MIIM_STRING = 0x00000040,

        /// <summary>
        /// MIIM_BITMAP
        /// </summary>
        MIIM_BITMAP = 0x00000080,

        /// <summary>
        /// MIIM_FTYPE
        /// </summary>
        MIIM_FTYPE = 0x00000100,
    }
}
