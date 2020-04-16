using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Defines values that are used with the <see cref="FILE_IO_PRIORITY_HINT_INFO"/> structure to specify the priority hint for a file I/O operation.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/ne-winbase-priority_hint
    /// </para>
    /// </summary>
    public enum PRIORITY_HINT
    {
        /// <summary>
        /// The lowest possible priority hint level. The system uses this value for background I/O operations.
        /// </summary>
        IoPriorityHintVeryLow = 0,

        /// <summary>
        /// A low-priority hint level.
        /// </summary>
        IoPriorityHintLow,

        /// <summary>
        /// A normal-priority hint level. This value is the default setting for an I/O operation.
        /// </summary>
        IoPriorityHintNormal,

        /// <summary>
        /// This value is used for validation. Supported values are less than this value.
        /// </summary>
        MaximumIoPriorityHintType
    }
}
