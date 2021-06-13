using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="CreateEventEx"/> Flags.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-createeventexw"/>
    /// </para>
    /// </summary>
    public enum CreateEventExFlags : uint
    {
        /// <summary>
        /// The initial state of the event object is signaled; otherwise, it is nonsignaled.
        /// </summary>
        CREATE_EVENT_INITIAL_SET = 0x00000002,

        /// <summary>
        /// The event must be manually reset using the ResetEvent function.
        /// Any number of waiting threads, or threads that subsequently begin wait operations for the specified event object,
        /// can be released while the object's state is signaled.
        /// If this flag is not specified, the system automatically resets the event after releasing a single waiting thread.
        /// </summary>
        CREATE_EVENT_MANUAL_RESET = 0x00000001,
    }
}
