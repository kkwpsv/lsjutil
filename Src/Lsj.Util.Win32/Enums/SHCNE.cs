namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// SHCNE
    /// </summary>
    public enum SHCNE
    {
        /// <summary>
        /// SHCNE_RENAMEITEM
        /// </summary>
        SHCNE_RENAMEITEM = 0x00000001,

        /// <summary>
        /// SHCNE_CREATE
        /// </summary>
        SHCNE_CREATE = 0x00000002,

        /// <summary>
        /// SHCNE_DELETE
        /// </summary>
        SHCNE_DELETE = 0x00000004,

        /// <summary>
        /// SHCNE_MKDIR
        /// </summary>
        SHCNE_MKDIR = 0x00000008,

        /// <summary>
        /// SHCNE_RMDIR
        /// </summary>
        SHCNE_RMDIR = 0x00000010,

        /// <summary>
        /// SHCNE_MEDIAINSERTED
        /// </summary>
        SHCNE_MEDIAINSERTED = 0x00000020,

        /// <summary>
        /// SHCNE_MEDIAREMOVED
        /// </summary>
        SHCNE_MEDIAREMOVED = 0x00000040,

        /// <summary>
        /// SHCNE_DRIVEREMOVED
        /// </summary>
        SHCNE_DRIVEREMOVED = 0x00000080,

        /// <summary>
        /// SHCNE_DRIVEADD
        /// </summary>
        SHCNE_DRIVEADD = 0x00000100,

        /// <summary>
        /// SHCNE_NETSHARE
        /// </summary>
        SHCNE_NETSHARE = 0x00000200,

        /// <summary>
        /// SHCNE_NETUNSHARE
        /// </summary>
        SHCNE_NETUNSHARE = 0x00000400,

        /// <summary>
        /// SHCNE_ATTRIBUTES
        /// </summary>
        SHCNE_ATTRIBUTES = 0x00000800,

        /// <summary>
        /// SHCNE_UPDATEDIR
        /// </summary>
        SHCNE_UPDATEDIR = 0x00001000,

        /// <summary>
        /// SHCNE_UPDATEITEM
        /// </summary>
        SHCNE_UPDATEITEM = 0x00002000,

        /// <summary>
        /// SHCNE_SERVERDISCONNECT
        /// </summary>
        SHCNE_SERVERDISCONNECT = 0x00004000,

        /// <summary>
        /// SHCNE_UPDATEIMAGE
        /// </summary>
        SHCNE_UPDATEIMAGE = 0x00008000,

        /// <summary>
        /// SHCNE_DRIVEADDGUI
        /// </summary>
        SHCNE_DRIVEADDGUI = 0x00010000,

        /// <summary>
        /// SHCNE_RENAMEFOLDER
        /// </summary>
        SHCNE_RENAMEFOLDER = 0x00020000,

        /// <summary>
        /// SHCNE_FREESPACE
        /// </summary>
        SHCNE_FREESPACE = 0x00040000,

        /// <summary>
        /// SHCNE_EXTENDED_EVENT
        /// </summary>
        SHCNE_EXTENDED_EVENT = 0x04000000,

        /// <summary>
        /// SHCNE_ASSOCCHANGED
        /// </summary>
        SHCNE_ASSOCCHANGED = 0x08000000,

        /// <summary>
        /// SHCNE_DISKEVENTS
        /// </summary>
        SHCNE_DISKEVENTS = 0x0002381F,

        /// <summary>
        /// SHCNE_GLOBALEVENTS
        /// </summary>
        SHCNE_GLOBALEVENTS = 0x0C0581E0,

        /// <summary>
        /// SHCNE_ALLEVENTS
        /// </summary>
        SHCNE_ALLEVENTS = 0x7FFFFFFF,

        /// <summary>
        /// SHCNE_INTERRUPT
        /// </summary>
        SHCNE_INTERRUPT = unchecked((int)0x80000000),
    }
}
