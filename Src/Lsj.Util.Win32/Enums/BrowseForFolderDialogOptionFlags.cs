using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Browse for folder dialog option flags
    /// </summary>
    [Flags]
    public enum BrowseForFolderDialogOptionFlags : uint
    {
        /// <summary>
        /// BIF_RETURNONLYFSDIRS
        /// </summary>
        BIF_RETURNONLYFSDIRS = 0x00000001,

        /// <summary>
        /// BIF_DONTGOBELOWDOMAIN
        /// </summary>
        BIF_DONTGOBELOWDOMAIN = 0x00000002,

        /// <summary>
        /// BIF_STATUSTEXT
        /// </summary>
        BIF_STATUSTEXT = 0x00000004,

        /// <summary>
        /// BIF_RETURNFSANCESTORS
        /// </summary>
        BIF_RETURNFSANCESTORS = 0x00000008,

        /// <summary>
        /// BIF_EDITBOX
        /// </summary>
        BIF_EDITBOX = 0x00000010,

        /// <summary>
        /// BIF_VALIDATE
        /// </summary>
        BIF_VALIDATE = 0x00000020,

        /// <summary>
        /// BIF_NEWDIALOGSTYLE
        /// </summary>
        BIF_NEWDIALOGSTYLE = 0x00000040,

        /// <summary>
        /// BIF_BROWSEINCLUDEURLS
        /// </summary>
        BIF_BROWSEINCLUDEURLS = 0x00000080,

        /// <summary>
        /// BIF_USENEWUI
        /// </summary>
        BIF_USENEWUI = (BIF_NEWDIALOGSTYLE | BIF_EDITBOX),

        /// <summary>
        /// BIF_UAHINT
        /// </summary>
        BIF_UAHINT = 0x00000100,

        /// <summary>
        /// BIF_NONEWFOLDERBUTTON
        /// </summary>
        BIF_NONEWFOLDERBUTTON = 0x00000200,

        /// <summary>
        /// BIF_NOTRANSLATETARGETS
        /// </summary>
        BIF_NOTRANSLATETARGETS = 0x00000400,

        /// <summary>
        /// BIF_BROWSEFORCOMPUTER
        /// </summary>
        BIF_BROWSEFORCOMPUTER = 0x00001000,

        /// <summary>
        /// BIF_BROWSEFORPRINTER
        /// </summary>
        BIF_BROWSEFORPRINTER = 0x00002000,

        /// <summary>
        /// BIF_BROWSEINCLUDEFILES
        /// </summary>
        BIF_BROWSEINCLUDEFILES = 0x00004000,

        /// <summary>
        /// BIF_SHAREABLE
        /// </summary>
        BIF_SHAREABLE = 0x00008000,

        /// <summary>
        /// BIF_BROWSEFILEJUNCTIONS
        /// </summary>
        BIF_BROWSEFILEJUNCTIONS = 0x00010000,
    }
}
