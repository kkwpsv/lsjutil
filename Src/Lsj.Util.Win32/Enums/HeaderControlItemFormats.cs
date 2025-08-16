namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Header control item formats
    /// </summary>
    public enum HeaderControlItemFormats : uint
    {
        /// <summary>
        /// HDF_CENTER
        /// </summary>
        HDF_CENTER = 0x0002,

        /// <summary>
        /// HDF_LEFT
        /// </summary>
        HDF_LEFT = 0x0000,

        /// <summary>
        /// HDF_RIGHT
        /// </summary>
        HDF_RIGHT = 0x0001,

        /// <summary>
        /// HDF_BITMAP
        /// </summary>
        HDF_BITMAP = 0x2000,

        /// <summary>
        /// HDF_BITMAP_ON_RIGHT
        /// </summary>
        HDF_BITMAP_ON_RIGHT = 0x1000,

        /// <summary>
        /// HDF_OWNERDRAW
        /// </summary>
        HDF_OWNERDRAW = 0x8000,

        /// <summary>
        /// HDF_STRING
        /// </summary>
        HDF_STRING = 0x4000,

        /// <summary>
        /// HDF_IMAGE
        /// </summary>
        HDF_IMAGE = 0x0800,

        /// <summary>
        /// HDF_JUSTIFYMASK
        /// </summary>
        HDF_JUSTIFYMASK = 0x0003,

        /// <summary>
        /// HDF_RTLREADING
        /// </summary>
        HDF_RTLREADING = 0x0004,

        /// <summary>
        /// HDF_SORTDOWN
        /// </summary>
        HDF_SORTDOWN = 0x0200,

        /// <summary>
        /// HDF_SORTUP
        /// </summary>
        HDF_SORTUP = 0x0400,

        /// <summary>
        /// HDF_CHECKBOX
        /// </summary>
        HDF_CHECKBOX = 0x0040,

        /// <summary>
        /// HDF_CHECKED
        /// </summary>
        HDF_CHECKED = 0x0080,

        /// <summary>
        /// HDF_FIXEDWIDTH
        /// </summary>
        HDF_FIXEDWIDTH = 0x0100,

        /// <summary>
        /// HDF_SPLITBUTTON
        /// </summary>
        HDF_SPLITBUTTON = 0x1000000,
    }
}
