namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Header control item masks
    /// </summary>
    public enum HeaderControlItemMasks : uint
    {
        /// <summary>
        /// HDI_BITMAP
        /// </summary>
        HDI_BITMAP = 0x0010,

        /// <summary>
        /// HDI_DI_SETITEM
        /// </summary>
        HDI_DI_SETITEM = 0x0040,

        /// <summary>
        /// HDI_FORMAT
        /// </summary>
        HDI_FORMAT = 0x0004,

        /// <summary>
        /// HDI_FILTER
        /// </summary>
        HDI_FILTER = 0x0100,

        /// <summary>
        /// HDI_HEIGHT
        /// </summary>
        HDI_HEIGHT = HDI_WIDTH,

        /// <summary>
        /// HDI_IMAGE
        /// </summary>
        HDI_IMAGE = 0x0020,

        /// <summary>
        /// HDI_LPARAM
        /// </summary>
        HDI_LPARAM = 0x0008,

        /// <summary>
        /// HDI_ORDER
        /// </summary>
        HDI_ORDER = 0x0080,

        /// <summary>
        /// HDI_STATE
        /// </summary>
        HDI_STATE = 0x0200,

        /// <summary>
        /// HDI_TEXT
        /// </summary>
        HDI_TEXT = 0x0002,

        /// <summary>
        /// HDI_WIDTH
        /// </summary>
        HDI_WIDTH = 0x0001,
    }
}
