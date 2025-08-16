namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Open file dialog flags
    /// </summary>
    public enum OpenFileDialogFlags : uint
    {
        /// <summary>
        /// OFN_ALLOWMULTISELECT
        /// </summary>
        OFN_ALLOWMULTISELECT = 0x00000200,

        /// <summary>
        /// OFN_CREATEPROMPT
        /// </summary>
        OFN_CREATEPROMPT = 0x00002000,

        /// <summary>
        /// OFN_DONTADDTORECENT
        /// </summary>
        OFN_DONTADDTORECENT = 0x02000000,

        /// <summary>
        /// OFN_ENABLEHOOK
        /// </summary>
        OFN_ENABLEHOOK = 0x00000020,

        /// <summary>
        /// OFN_ENABLEINCLUDENOTIFY
        /// </summary>
        OFN_ENABLEINCLUDENOTIFY = 0x00400000,

        /// <summary>
        /// OFN_ENABLESIZING
        /// </summary>
        OFN_ENABLESIZING = 0x00800000,

        /// <summary>
        /// OFN_ENABLETEMPLATE
        /// </summary>
        OFN_ENABLETEMPLATE = 0x00000040,

        /// <summary>
        /// OFN_ENABLETEMPLATEHANDLE
        /// </summary>
        OFN_ENABLETEMPLATEHANDLE = 0x00000080,

        /// <summary>
        /// OFN_EXPLORER
        /// </summary>
        OFN_EXPLORER = 0x00080000,

        /// <summary>
        /// OFN_EXTENSIONDIFFERENT
        /// </summary>
        OFN_EXTENSIONDIFFERENT = 0x00000400,

        /// <summary>
        /// OFN_FILEMUSTEXIST
        /// </summary>
        OFN_FILEMUSTEXIST = 0x00001000,

        /// <summary>
        /// OFN_FORCESHOWHIDDEN
        /// </summary>
        OFN_FORCESHOWHIDDEN = 0x10000000,

        /// <summary>
        /// OFN_HIDEREADONLY
        /// </summary>
        OFN_HIDEREADONLY = 0x00000004,

        /// <summary>
        /// OFN_LONGNAMES
        /// </summary>
        OFN_LONGNAMES = 0x00200000,

        /// <summary>
        /// OFN_NOCHANGEDIR
        /// </summary>
        OFN_NOCHANGEDIR = 0x00000008,

        /// <summary>
        /// OFN_NODEREFERENCELINKS
        /// </summary>
        OFN_NODEREFERENCELINKS = 0x00100000,

        /// <summary>
        /// OFN_NOLONGNAMES
        /// </summary>
        OFN_NOLONGNAMES = 0x00040000,

        /// <summary>
        /// OFN_NONETWORKBUTTON
        /// </summary>
        OFN_NONETWORKBUTTON = 0x00020000,

        /// <summary>
        /// OFN_NOREADONLYRETURN
        /// </summary>
        OFN_NOREADONLYRETURN = 0x00008000,

        /// <summary>
        /// OFN_NOTESTFILECREATE
        /// </summary>
        OFN_NOTESTFILECREATE = 0x00010000,

        /// <summary>
        /// OFN_NOVALIDATE
        /// </summary>
        OFN_NOVALIDATE = 0x00000100,

        /// <summary>
        /// OFN_OVERWRITEPROMPT
        /// </summary>
        OFN_OVERWRITEPROMPT = 0x00000002,

        /// <summary>
        /// OFN_PATHMUSTEXIST
        /// </summary>
        OFN_PATHMUSTEXIST = 0x00000800,

        /// <summary>
        /// OFN_READONLY
        /// </summary>
        OFN_READONLY = 0x00000001,

        /// <summary>
        /// OFN_SHAREAWARE
        /// </summary>
        OFN_SHAREAWARE = 0x00004000,

        /// <summary>
        /// OFN_SHOWHELP
        /// </summary>
        OFN_SHOWHELP = 0x00000010,
    }
}
