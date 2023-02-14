using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Process Priority Classes
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-setpriorityclass"/>
    /// </para>
    /// </summary>
    public enum ProcessPriorityClasses
    {
        /// <summary>
        /// Process that has priority above <see cref="NORMAL_PRIORITY_CLASS"/> but below <see cref="HIGH_PRIORITY_CLASS"/>.
        /// </summary>
        ABOVE_NORMAL_PRIORITY_CLASS = 0x00008000,

        /// <summary>
        /// Process that has priority above <see cref="IDLE_PRIORITY_CLASS"/> but below <see cref="NORMAL_PRIORITY_CLASS"/>.
        /// </summary>
        BELOW_NORMAL_PRIORITY_CLASS = 0x00004000,

        /// <summary>
        /// Process that performs time-critical tasks that must be executed immediately.
        /// The threads of the process preempt the threads of normal or idle priority class processes.
        /// An example is the Task List, which must respond quickly when called by the user, regardless of the load on the operating system.
        /// Use extreme care when using the high-priority class, because a high-priority class application can use nearly all available CPU time.
        /// </summary>
        HIGH_PRIORITY_CLASS = 0x00000080,

        /// <summary>
        /// Process whose threads run only when the system is idle.
        /// The threads of the process are preempted by the threads of any process running in a higher priority class.
        /// An example is a screen saver. The idle-priority class is inherited by child processes.
        /// </summary>
        IDLE_PRIORITY_CLASS = 0x00000040,

        /// <summary>
        /// Process with no special scheduling needs.
        /// </summary>
        NORMAL_PRIORITY_CLASS = 0x00000020,

        /// <summary>
        /// Begin background processing mode.
        /// The system lowers the resource scheduling priorities of the process (and its threads)
        /// so that it can perform background work without significantly affecting activity in the foreground.
        /// This value can be specified only if hProcess is a handle to the current process.
        /// The function fails if the process is already in background processing mode.
        /// Windows Server 2003 and Windows XP:  This value is not supported.
        /// </summary>
        PROCESS_MODE_BACKGROUND_BEGIN = 0x00100000,

        /// <summary>
        /// End background processing mode.
        /// The system restores the resource scheduling priorities of the process (and its threads)
        /// as they were before the process entered background processing mode.
        /// This value can be specified only if hProcess is a handle to the current process.
        /// The function fails if the process is not in background processing mode.
        /// Windows Server 2003 and Windows XP:  This value is not supported.
        /// </summary>
        PROCESS_MODE_BACKGROUND_END = 0x00200000,

        /// <summary>
        /// Process that has the highest possible priority.
        /// The threads of the process preempt the threads of all other processes, including operating system processes performing important tasks.
        /// For example, a real-time process that executes for more than a very brief interval can cause disk caches not to flush
        /// or cause the mouse to be unresponsive.
        /// </summary>
        REALTIME_PRIORITY_CLASS = 0x00000100,
    }
}
