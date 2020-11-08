namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// FILEOP_FLAGS
    /// </summary>
    public enum FILEOP_FLAGS : ushort
    {
        /// <summary>
        /// FOF_MULTIDESTFILES
        /// </summary>
        FOF_MULTIDESTFILES = 0x0001,

        /// <summary>
        /// FOF_CONFIRMMOUSE
        /// </summary>
        FOF_CONFIRMMOUSE = 0x0002,

        /// <summary>
        /// FOF_SILENT
        /// </summary>
        FOF_SILENT = 0x0004,

        /// <summary>
        /// FOF_RENAMEONCOLLISION
        /// </summary>
        FOF_RENAMEONCOLLISION = 0x0008,

        /// <summary>
        /// FOF_NOCONFIRMATION
        /// </summary>
        FOF_NOCONFIRMATION = 0x0010,

        /// <summary>
        /// FOF_WANTMAPPINGHANDLE
        /// </summary>
        FOF_WANTMAPPINGHANDLE = 0x0020,

        /// <summary>
        /// FOF_ALLOWUNDO
        /// </summary>
        FOF_ALLOWUNDO = 0x0040,

        /// <summary>
        /// FOF_FILESONLY
        /// </summary>
        FOF_FILESONLY = 0x0080,

        /// <summary>
        /// FOF_SIMPLEPROGRESS
        /// </summary>
        FOF_SIMPLEPROGRESS = 0x0100,

        /// <summary>
        /// FOF_NOCONFIRMMKDIR
        /// </summary>
        FOF_NOCONFIRMMKDIR = 0x0200,

        /// <summary>
        /// FOF_NOERRORUI
        /// </summary>
        FOF_NOERRORUI = 0x0400,

        /// <summary>
        /// FOF_NOCOPYSECURITYATTRIBS
        /// </summary>
        FOF_NOCOPYSECURITYATTRIBS = 0x0800,

        /// <summary>
        /// FOF_NORECURSION
        /// </summary>
        FOF_NORECURSION = 0x1000,

        /// <summary>
        /// FOF_NO_CONNECTED_ELEMENTS
        /// </summary>
        FOF_NO_CONNECTED_ELEMENTS = 0x2000,

        /// <summary>
        /// FOF_WANTNUKEWARNING
        /// </summary>
        FOF_WANTNUKEWARNING = 0x4000,

        /// <summary>
        /// FOF_NORECURSEREPARSE
        /// </summary>
        FOF_NORECURSEREPARSE = 0x8000,

        /// <summary>
        /// FOF_NO_UI
        /// </summary>
        FOF_NO_UI = (FOF_SILENT | FOF_NOCONFIRMATION | FOF_NOERRORUI | FOF_NOCONFIRMMKDIR),
    }
}
