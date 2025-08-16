using System;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="PeekMessage"/> flags
    /// </summary>
    [Flags]
    public enum PeekMessageFlags : uint
    {
        /// <summary>
        /// PM_NOREMOVE
        /// </summary>
        PM_NOREMOVE = 0x0000,

        /// <summary>
        /// PM_REMOVE
        /// </summary>
        PM_REMOVE = 0x0001,

        /// <summary>
        /// PM_NOYIELD
        /// </summary>
        PM_NOYIELD = 0x0002,

        /// <summary>
        /// PM_QS_INPUT
        /// </summary>
        PM_QS_INPUT = QueueStatus.QS_INPUT << 16,

        /// <summary>
        /// PM_QS_PAINT
        /// </summary>
        PM_QS_PAINT = QueueStatus.QS_PAINT << 16,

        /// <summary>
        /// PM_QS_POSTMESSAGE
        /// </summary>
        PM_QS_POSTMESSAGE = (QueueStatus.QS_POSTMESSAGE | QueueStatus.QS_HOTKEY | QueueStatus.QS_TIMER) << 16,

        /// <summary>
        /// PM_QS_SENDMESSAGE
        /// </summary>
        PM_QS_SENDMESSAGE = QueueStatus.QS_SENDMESSAGE << 16,
    }
}
