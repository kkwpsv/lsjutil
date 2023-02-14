using System;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// ThreadPoolFlags
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-registerwaitforsingleobject"/>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoollegacyapiset/nf-threadpoollegacyapiset-createtimerqueuetimer"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum ThreadPoolFlags : ulong
    {
        /// <summary>
        /// By default, the callback function is queued to a non-I/O worker thread. 
        /// </summary>
        WT_EXECUTEDEFAULT = 0x00000000,

        /// <summary>
        /// This flag is not used.
        /// Windows Server 2003 and Windows XP:
        /// The callback function is queued to an I/O worker thread. 
        /// This flag should be used if the function should be executed in a thread that waits in an alertable state.
        /// I/O worker threads were removed starting with Windows Vista and Windows Server 2008.
        /// </summary>
        WT_EXECUTEINIOTHREAD = 0x00000001,

        /// <summary>
        /// The callback function is queued to a thread that never terminates.
        /// It does not guarantee that the same thread is used each time.
        /// This flag should be used only for short tasks or it could affect other wait operations.
        /// This flag must be set if the thread calls functions that use APCs.
        /// For more information, see Asynchronous Procedure Calls.
        /// Note that currently no worker thread is truly persistent, although no worker thread will terminate if there are any pending I/O requests.
        /// </summary>
        WT_EXECUTEINPERSISTENTTHREAD = 0x00000080,

        /// <summary>
        /// The callback function is invoked by the wait thread itself.
        /// This flag should be used only for short tasks or it could affect other wait operations.
        /// Deadlocks can occur if some other thread acquires an exclusive lock and calls the <see cref="UnregisterWait"/>
        /// or <see cref="UnregisterWaitEx"/> function while the callback function is trying to acquire the same lock.
        /// </summary>
        WT_EXECUTEINWAITTHREAD = 0x00000004,

        /// <summary>
        /// The callback function can perform a long wait.
        /// This flag helps the system to decide if it should create a new thread. 
        /// </summary>
        WT_EXECUTELONGFUNCTION = 0x00000010,

        /// <summary>
        /// The thread will no longer wait on the handle after the callback function has been called once.
        /// Otherwise, the timer is reset every time the wait operation completes until the wait operation is canceled. 
        /// </summary>
        WT_EXECUTEONLYONCE = 0x00000008,

        /// <summary>
        /// Callback functions will use the current access token, whether it is a process or impersonation token.
        /// If this flag is not specified, callback functions execute only with the process token.
        /// Windows XP: This flag is not supported until Windows XP with SP2 and Windows Server 2003.
        /// </summary>
        WT_TRANSFER_IMPERSONATION = 0x00000100,

        /// <summary>
        /// The callback function is invoked by the timer thread itself.
        /// This flag should be used only for short tasks or it could affect other timer operations.
        /// The callback function is queued as an APC.
        /// It should not perform alertable wait operations.
        /// </summary>
        WT_EXECUTEINTIMERTHREAD = 0x00000020,
    }
}
