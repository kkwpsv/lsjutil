using System;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="BroadcastSystemMessage"/> and <see cref="BroadcastSystemMessageEx"/> flags
    /// </summary>
    [Flags]
    public enum BroadcastSystemMessageFlags
    {
        /// <summary>
        /// BSF_ALLOWSFW
        /// </summary>
        BSF_ALLOWSFW = 0x00000080,

        /// <summary>
        /// BSF_FLUSHDISK
        /// </summary>
        BSF_FLUSHDISK = 0x00000004,

        /// <summary>
        /// BSF_FORCEIFHUNG
        /// </summary>
        BSF_FORCEIFHUNG = 0x00000020,

        /// <summary>
        /// BSF_IGNORECURRENTTASK
        /// </summary>
        BSF_IGNORECURRENTTASK = 0x00000002,

        /// <summary>
        /// BSF_NOHANG
        /// </summary>
        BSF_NOHANG = 0x00000008,

        /// <summary>
        /// BSF_NOTIMEOUTIFNOTHUNG
        /// </summary>
        BSF_NOTIMEOUTIFNOTHUNG = 0x00000040,

        /// <summary>
        /// BSF_POSTMESSAGE
        /// </summary>
        BSF_POSTMESSAGE = 0x00000010,

        /// <summary>
        /// BSF_QUERY
        /// </summary>
        BSF_QUERY = 0x00000001,

        /// <summary>
        /// BSF_SENDNOTIFYMESSAGE
        /// </summary>
        BSF_SENDNOTIFYMESSAGE = 0x00000100,

        /// <summary>
        /// BSF_LUID
        /// </summary>
        BSF_LUID = 0x00000400,

        /// <summary>
        /// BSF_RETURNHDESK
        /// </summary>
        BSF_RETURNHDESK = 0x00000200,
    }
}
