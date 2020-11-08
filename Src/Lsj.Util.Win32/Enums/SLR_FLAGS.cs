namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// SLR_FLAGS
    /// </summary>
    public enum SLR_FLAGS
    {
        /// <summary>
        /// SLR_NONE
        /// </summary>
        SLR_NONE = 0,

        /// <summary>
        /// SLR_NO_UI
        /// </summary>
        SLR_NO_UI = 0x1,

        /// <summary>
        /// SLR_ANY_MATCH
        /// </summary>
        SLR_ANY_MATCH = 0x2,

        /// <summary>
        /// SLR_UPDATE
        /// </summary>
        SLR_UPDATE = 0x4,

        /// <summary>
        /// SLR_NOUPDATE
        /// </summary>
        SLR_NOUPDATE = 0x8,

        /// <summary>
        /// SLR_NOSEARCH
        /// </summary>
        SLR_NOSEARCH = 0x10,

        /// <summary>
        /// SLR_NOTRACK
        /// </summary>
        SLR_NOTRACK = 0x20,

        /// <summary>
        /// SLR_NOLINKINFO
        /// </summary>
        SLR_NOLINKINFO = 0x40,

        /// <summary>
        /// SLR_INVOKE_MSI
        /// </summary>
        SLR_INVOKE_MSI = 0x80,

        /// <summary>
        /// SLR_NO_UI_WITH_MSG_PUMP
        /// </summary>
        SLR_NO_UI_WITH_MSG_PUMP = 0x101,

        /// <summary>
        /// SLR_OFFER_DELETE_WITHOUT_FILE
        /// </summary>
        SLR_OFFER_DELETE_WITHOUT_FILE = 0x200,

        /// <summary>
        /// SLR_KNOWNFOLDER
        /// </summary>
        SLR_KNOWNFOLDER = 0x400,

        /// <summary>
        /// SLR_MACHINE_IN_LOCAL_TARGET
        /// </summary>
        SLR_MACHINE_IN_LOCAL_TARGET = 0x800,

        /// <summary>
        /// SLR_UPDATE_MACHINE_AND_SID
        /// </summary>
        SLR_UPDATE_MACHINE_AND_SID = 0x1000,

        /// <summary>
        /// SLR_NO_OBJECT_ID
        /// </summary>
        SLR_NO_OBJECT_ID = 0x2000
    }
}
