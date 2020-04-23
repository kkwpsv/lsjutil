namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Load Image Flags
    /// </summary>
    public enum LoadImageFlags : uint
    {
        /// <summary>
        /// LR_DEFAULTCOLOR
        /// </summary>
        LR_DEFAULTCOLOR = 0x00000000,

        /// <summary>
        /// LR_MONOCHROME
        /// </summary>
        LR_MONOCHROME = 0x00000001,

        /// <summary>
        /// LR_COLOR
        /// </summary>
        LR_COLOR = 0x00000002,

        /// <summary>
        /// LR_COPYRETURNORG
        /// </summary>
        LR_COPYRETURNORG = 0x00000004,

        /// <summary>
        /// LR_COPYDELETEORG
        /// </summary>
        LR_COPYDELETEORG = 0x00000008,

        /// <summary>
        /// LR_LOADFROMFILE
        /// </summary>
        LR_LOADFROMFILE = 0x00000010,

        /// <summary>
        /// LR_LOADTRANSPARENT
        /// </summary>
        LR_LOADTRANSPARENT = 0x00000020,

        /// <summary>
        /// LR_DEFAULTSIZE
        /// </summary>
        LR_DEFAULTSIZE = 0x00000040,

        /// <summary>
        /// LR_VGACOLOR
        /// </summary>
        LR_VGACOLOR = 0x00000080,

        /// <summary>
        /// LR_LOADMAP3DCOLORS
        /// </summary>
        LR_LOADMAP3DCOLORS = 0x00001000,

        /// <summary>
        /// LR_CREATEDIBSECTION
        /// </summary>
        LR_CREATEDIBSECTION = 0x00002000,

        /// <summary>
        /// LR_COPYFROMRESOURCE
        /// </summary>
        LR_COPYFROMRESOURCE = 0x00004000,

        /// <summary>
        /// LR_SHARED
        /// </summary>
        LR_SHARED = 0x00008000,
    }
}
