using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.WaitResult;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.InitOnceFlags;
using static Lsj.Util.Win32.Enums.NTSTATUS;
using static Lsj.Util.Win32.Enums.StandardAccessRights;
using static Lsj.Util.Win32.Enums.SynchronizationBarrierFlags;
using static Lsj.Util.Win32.Enums.SynchronizationObjectAccessRights;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.ThreadAccessRights;
using static Lsj.Util.Win32.Enums.ThreadPoolFlags;
using static Lsj.Util.Win32.Ole32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// CONDITION_VARIABLE_LOCKMODE_SHARED
        /// </summary>
        public const uint CONDITION_VARIABLE_LOCKMODE_SHARED = unchecked((uint)-1);

        /// <summary>
        /// CRITICAL_SECTION_NO_DEBUG_INFO
        /// </summary>
        public const uint CRITICAL_SECTION_NO_DEBUG_INFO = 0x01000000;

        /// <summary>
        /// INIT_ONCE_CTX_RESERVED_BITS
        /// </summary>
        public const int INIT_ONCE_CTX_RESERVED_BITS = 2;

        /// <summary>
        /// SRWLOCK_INIT
        /// </summary>
        public readonly static SRWLOCK SRWLOCK_INIT = new SRWLOCK();


        /// <summary>
        /// <para>
        /// An application-defined completion routine.
        /// Specify this address when calling the <see cref="QueueUserAPC"/> function.
        /// The <see cref="PAPCFUNC"/> type defines a pointer to this callback function.
        /// APCProc is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/nc-winnt-papcfunc"/>
        /// </para>
        /// </summary>
        /// <param name="Parameter"></param>
        public delegate void Papcfunc(ULONG_PTR Parameter);

        /// <summary>
        /// <para>
        /// An application-defined callback function.
        /// Specify a pointer to this function when calling the <see cref="InitOnceExecuteOnce"/> function.
        /// The <see cref="PINIT_ONCE_FN"/> type defines a pointer to this callback function.
        /// InitOnceCallback is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nc-synchapi-pinit_once_fn"/>
        /// </para>
        /// </summary>
        /// <param name="InitOnce">
        /// A pointer to the one-time initialization structure.
        /// </param>
        /// <param name="Parameter">
        /// An optional parameter that was passed to the callback function.
        /// </param>
        /// <param name="Context">
        /// The data to be stored with the one-time initialization structure.
        /// If Context references a value, the low-order <see cref="INIT_ONCE_CTX_RESERVED_BITS"/> of the value must be zero.
        /// If Context points to a data structure, the data structure must be DWORD-aligned.
        /// </param>
        /// <returns>
        /// If the function returns <see cref="TRUE"/>, the block is marked as initialized.
        /// If the function returns <see cref="FALSE"/>, the block is not marked as initialized and the call to <see cref="InitOnceExecuteOnce"/> fails.
        /// To communicate additional error information, call <see cref="SetLastError"/> before returning <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// This function can create a synchronization object and return it in the lpContext parameter.
        /// </remarks>
        public delegate BOOL PinitOnceFn([In][Out] ref INIT_ONCE InitOnce, [In] PVOID Parameter, [Out] out PVOID Context);

        /// <summary>
        /// <para>
        /// An application-defined function that serves as the starting address for a timer callback or a registered wait callback.
        /// Specify this address when calling the <see cref="CreateTimerQueueTimer"/>, <see cref="RegisterWaitForSingleObject"/> function.
        /// The <see cref="WAITORTIMERCALLBACK"/> type defines a pointer to this callback function.
        /// WaitOrTimerCallback is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms687066(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="lpParameter">
        /// The thread data passed to the function using a parameter of the <see cref="CreateTimerQueueTimer"/>
        /// or <see cref="RegisterWaitForSingleObject"/> function.
        /// </param>
        /// <param name="TimerOrWaitFired">
        /// If this parameter is <see cref="BOOLEAN.TRUE"/>, the wait timed out.
        /// If this parameter is <see cref="BOOLEAN.FALSE"/>, the wait event has been signaled.
        /// (This parameter is always <see cref="BOOLEAN.TRUE"/> for timer callbacks.)
        /// </param>
        /// <remarks>
        /// This callback function must not call the <see cref="TerminateThread"/> function.
        /// </remarks>
        public delegate void Waitortimercallback([In] PVOID lpParameter, [In] BOOLEAN TimerOrWaitFired);


        /// <summary>
        /// <para>
        /// Acquires a slim reader/writer (SRW) lock in exclusive mode.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-acquiresrwlockexclusive"/>
        /// </para>
        /// </summary>
        /// <param name="SRWLock">
        /// A pointer to the SRW lock.
        /// </param>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "AcquireSRWLockExclusive", ExactSpelling = true, SetLastError = true)]
        public static extern void AcquireSRWLockExclusive([In][Out] ref SRWLOCK SRWLock);

        /// <summary>
        /// <para>
        /// Acquires a slim reader/writer (SRW) lock in shared mode.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-acquiresrwlockshared"/>
        /// </para>
        /// </summary>
        /// <param name="SRWLock">
        /// A pointer to the SRW lock.
        /// </param>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "AcquireSRWLockShared", ExactSpelling = true, SetLastError = true)]
        public static extern void AcquireSRWLockShared([In][Out] ref SRWLOCK SRWLock);

        /// <summary>
        /// <para>
        /// Releases all resources used by an unowned critical section object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-deletecriticalsection"/>
        /// </para>
        /// </summary>
        /// <param name="lpCriticalSection">
        /// A pointer to the critical section object.
        /// The object must have been previously initialized with the <see cref="InitializeCriticalSection"/> function.
        /// </param>
        /// <remarks>
        /// Deleting a critical section object releases all system resources used by the object.
        /// The caller is responsible for ensuring that the critical section object is unowned and
        /// the specified <see cref="CRITICAL_SECTION"/> structure is not being accessed by any critical section functions
        /// called by other threads in the process.
        /// After a critical section object has been deleted, do not reference the object in any function
        /// that operates on critical sections (such as <see cref="EnterCriticalSection"/>, <see cref="TryEnterCriticalSection"/>,
        /// and <see cref="LeaveCriticalSection"/>) other than <see cref="InitializeCriticalSection"/>
        /// and <see cref="InitializeCriticalSectionAndSpinCount"/>.
        /// If you attempt to do so, memory corruption and other unexpected errors can occur.
        /// If a critical section is deleted while it is still owned,
        /// the state of the threads waiting for ownership of the deleted critical section is undefined.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteCriticalSection", ExactSpelling = true, SetLastError = true)]
        public static extern void DeleteCriticalSection([In][Out] ref CRITICAL_SECTION lpCriticalSection);

        /// <summary>
        /// <para>
        /// Deletes a synchronization barrier.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-deletesynchronizationbarrier"/>
        /// </para>
        /// </summary>
        /// <param name="lpBarrier">
        /// A pointer to the synchronization barrier to delete.
        /// </param>
        /// <returns>
        /// The <see cref="DeleteSynchronizationBarrier"/> function always returns <see cref="TRUE"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="DeleteSynchronizationBarrier"/> releases a synchronization barrier when it is no longer needed.
        /// It is safe to call <see cref="DeleteSynchronizationBarrier"/> immediately after calling <see cref="EnterSynchronizationBarrier"/>
        /// because that function ensures that all threads in the barrier have finished using it before allowing the barrier to be released.
        /// If a synchronization barrier will never be deleted, threads can
        /// specify the <see cref="SYNCHRONIZATION_BARRIER_FLAGS_NO_DELETE"/> flag when they enter the barrier.
        /// This flag causes the function to skip the extra work required for deletion safety, which can improve performance.
        /// All threads using the barrier must specify this flag; if any thread does not, the flag is ignored.
        /// Be careful when using <see cref="SYNCHRONIZATION_BARRIER_FLAGS_NO_DELETE"/>,
        /// because deleting a barrier while this flag is in effect may result in an invalid handle access
        /// and cause one or more threads to become permanently blocked.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteSynchronizationBarrier", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DeleteSynchronizationBarrier([In][Out] ref SYNCHRONIZATION_BARRIER lpBarrier);

        /// <summary>
        /// <para>
        /// Waits for ownership of the specified critical section object.
        /// The function returns when the calling thread is granted ownership.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-entercriticalsection"/>
        /// </para>
        /// </summary>
        /// <param name="lpCriticalSection">
        /// A pointer to the critical section object.
        /// </param>
        /// <returns>
        /// This function does not return a value.
        /// <para>
        /// This function can raise EXCEPTION_POSSIBLE_DEADLOCK if a wait operation on the critical section times out.
        /// </para>
        /// The timeout interval is specified by the following registry value:
        /// HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\CriticalSectionTimeout.
        /// Do not handle a possible deadlock exception; instead, debug the application.
        /// </returns>
        /// <remarks>
        /// The threads of a single process can use a critical section object for mutual-exclusion synchronization.
        /// The process is responsible for allocating the memory used by a critical section object,
        /// which it can do by declaring a variable of type <see cref="CRITICAL_SECTION"/>.
        /// Before using a critical section, some thread of the process must call <see cref="InitializeCriticalSection"/> or
        /// <see cref="InitializeCriticalSectionAndSpinCount"/> to initialize the object.
        /// To enable mutually exclusive access to a shared resource, each thread calls the <see cref="EnterCriticalSection"/> or
        /// <see cref="TryEnterCriticalSection"/> function to request ownership of the critical section
        /// before executing any section of code that accesses the protected resource.
        /// The difference is that <see cref="TryEnterCriticalSection"/> returns immediately,
        /// regardless of whether it obtained ownership of the critical section,
        /// while <see cref="EnterCriticalSection"/> blocks until the thread can take ownership of the critical section.
        /// When it has finished executing the protected code, the thread uses the <see cref="LeaveCriticalSection"/> function to relinquish ownership,
        /// enabling another thread to become owner and access the protected resource.
        /// There is no guarantee about the order in which waiting threads will acquire ownership of the critical section.
        /// After a thread has ownership of a critical section, it can make additional calls to <see cref="EnterCriticalSection"/> or
        /// <see cref="TryEnterCriticalSection"/> without blocking its execution.
        /// This prevents a thread from deadlocking itself while waiting for a critical section that it already owns.
        /// The thread enters the critical section each time <see cref="EnterCriticalSection"/> and <see cref="TryEnterCriticalSection"/> succeed.
        /// A thread must call <see cref="LeaveCriticalSection"/> once for each time that it entered the critical section.
        /// Any thread of the process can use the DeleteCriticalSection function to release the system resources
        /// that were allocated when the critical section object was initialized.
        /// After this function has been called, the critical section object can no longer be used for synchronization.
        /// If a thread terminates while it has ownership of a critical section, the state of the critical section is undefined.
        /// If a critical section is deleted while it is still owned,
        /// the state of the threads waiting for ownership of the deleted critical section is undefined.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnterCriticalSection", ExactSpelling = true, SetLastError = true)]
        public static extern void EnterCriticalSection([In][Out] ref CRITICAL_SECTION lpCriticalSection);

        /// <summary>
        /// <para>
        /// Causes the calling thread to wait at a synchronization barrier until the maximum number of threads have entered the barrier.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-entersynchronizationbarrier"/>
        /// </para>
        /// </summary>
        /// <param name="lpBarrier">
        /// A pointer to an initialized synchronization barrier.
        /// Use the <see cref="InitializeSynchronizationBarrier"/> function to initialize the barrier.
        /// <see cref="SYNCHRONIZATION_BARRIER"/> is an opaque structure that should not be modified by the application.
        /// </param>
        /// <param name="dwFlags">
        /// Flags that control the behavior of threads that enter this barrier.
        /// This parameter can be one or more of the following values.
        /// <see cref="SYNCHRONIZATION_BARRIER_FLAGS_BLOCK_ONLY"/>:
        /// Specifies that the thread entering the barrier should block immediately until the last thread enters the barrier.
        /// For more information, see Remarks.
        /// <see cref="SYNCHRONIZATION_BARRIER_FLAGS_SPIN_ONLY"/>:
        /// Specifies that the thread entering the barrier should spin until the last thread enters the barrier,
        /// even if the spinning thread exceeds the barrier's maximum spin count.
        /// For more information, see Remarks.
        /// <see cref="SYNCHRONIZATION_BARRIER_FLAGS_NO_DELETE"/>:
        /// Specifies that the function can skip the work required to ensure that it is safe to delete the barrier, which can improve performance.
        /// All threads that enter this barrier must specify the flag; otherwise, the flag is ignored.
        /// This flag should be used only if the barrier will never be deleted.
        /// </param>
        /// <returns>
        /// <see cref="TRUE"/> for the last thread to signal the barrier.
        /// Threads that signal the barrier before the last thread signals it receive a return value of <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The default behavior for threads entering a synchronization barrier is to spin
        /// until the maximum spin count of the barrier is reached, and then block.
        /// This allows threads to resume quickly if the last thread enters the barrier in a relatively short time.
        /// However, if the last thread takes relatively longer to arrive,
        /// threads already in the barrier block so they stop consuming processor time while waiting.
        /// A thread can override the default behavior of the barrier
        /// by specifying <see cref="SYNCHRONIZATION_BARRIER_FLAGS_BLOCK_ONLY"/> or <see cref="SYNCHRONIZATION_BARRIER_FLAGS_SPIN_ONLY"/>.
        /// However, keep in mind that using these flags can affect performance.
        /// Spinning indefinitely keeps a processor from servicing other threads,
        /// while premature blocking incurs the overhead of swapping the thread off the processor,
        /// awakening the thread when it unblocks, and swapping it back onto the processor again.
        /// In general it is better to allow the barrier to manage threads and use these flags
        /// only if performance testing indicates the application would benefit from them.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnterSynchronizationBarrier", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnterSynchronizationBarrier([In][Out] ref SYNCHRONIZATION_BARRIER lpBarrier, [In] SynchronizationBarrierFlags dwFlags);

        /// <summary>
        /// <para>
        /// Initializes a condition variable.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-initializeconditionvariable"/>
        /// </para>
        /// </summary>
        /// <param name="ConditionVariable">
        /// A pointer to the condition variable.
        /// </param>
        /// <remarks>
        /// Threads can atomically release a lock and enter the sleeping state
        /// using the <see cref="SleepConditionVariableCS"/> or <see cref="SleepConditionVariableSRW"/> function.
        /// The threads are woken using the <see cref="WakeConditionVariable"/> or <see cref="WakeAllConditionVariable"/> function.
        /// Condition variables are user-mode objects that cannot be shared across processes.
        /// A condition variable cannot be moved or copied. The process must not modify the object, and must instead treat it as logically opaque.
        /// Only use the condition variable functions to manage condition variables.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitializeConditionVariable", ExactSpelling = true, SetLastError = true)]
        public static extern void InitializeConditionVariable([Out] out CONDITION_VARIABLE ConditionVariable);

        /// <summary>
        /// <para>
        /// Initializes a critical section object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-initializecriticalsection"/>
        /// </para>
        /// </summary>
        /// <param name="lpCriticalSection">
        /// A pointer to the critical section object.
        /// </param>
        /// <returns>
        /// This function does not return a value.
        ///Windows Server 2003 and Windows XP:
        ///In low memory situations, <see cref="InitializeCriticalSection"/> can raise a <see cref="STATUS_NO_MEMORY"/> exception.
        ///Starting with Windows Vista, this exception was eliminated and <see cref="InitializeCriticalSection"/> always succeeds,
        ///even in low memory situations.
        /// </returns>
        /// <remarks>
        /// The threads of a single process can use a critical section object for mutual-exclusion synchronization.
        /// There is no guarantee about the order in which threads will obtain ownership of the critical section,
        /// however, the system will be fair to all threads.
        /// The process is responsible for allocating the memory used by a critical section object,
        /// which it can do by declaring a variable of type <see cref="CRITICAL_SECTION"/>.
        /// Before using a critical section, some thread of the process must initialize the object.
        /// After a critical section object has been initialized, the threads of the process can specify the object
        /// in the <see cref="EnterCriticalSection"/>, <see cref="TryEnterCriticalSection"/>, or <see cref="LeaveCriticalSection"/> function
        /// to provide mutually exclusive access to a shared resource.
        /// For similar synchronization between the threads of different processes, use a mutex object.
        /// A critical section object cannot be moved or copied.
        /// The process must also not modify the object, but must treat it as logically opaque.
        /// Use only the critical section functions to manage critical section objects.
        /// When you have finished using the critical section, call the <see cref="DeleteCriticalSection"/> function.
        /// A critical section object must be deleted before it can be reinitialized.
        /// Initializing a critical section that has already been initialized results in undefined behavior.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitializeCriticalSection", ExactSpelling = true, SetLastError = true)]
        public static extern void InitializeCriticalSection([In][Out] ref CRITICAL_SECTION lpCriticalSection);

        /// <summary>
        /// <para>
        /// Initializes a new synchronization barrier.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-initializesynchronizationbarrier"/>
        /// </para>
        /// </summary>
        /// <param name="lpBarrier">
        /// A pointer to the <see cref="SYNCHRONIZATION_BARRIER"/> structure to initialize.
        /// This is an opaque structure that should not be modified by applications.
        /// </param>
        /// <param name="lTotalThreads">
        /// The maximum number of threads that can enter this barrier.
        /// After the maximum number of threads have entered the barrier, all threads continue.
        /// </param>
        /// <param name="lSpinCount">
        /// The number of times an individual thread should spin while waiting for other threads to arrive at the barrier.
        /// If this parameter is -1, the thread spins 2000 times.
        /// If the thread exceeds <paramref name="lSpinCount"/>, the thread blocks
        /// unless it called <see cref="EnterSynchronizationBarrier"/> with <see cref="SYNCHRONIZATION_BARRIER_FLAGS_SPIN_ONLY"/>.
        /// </param>
        /// <returns>
        /// <see cref="TRUE"/> if the barrier was successfully initialized.
        /// If the barrier was not successfully initialized, this function returns <see cref="FALSE"/>.
        /// Use <see cref="GetLastError"/> to get extended error information.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitializeSynchronizationBarrier", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL InitializeSynchronizationBarrier([Out] out SYNCHRONIZATION_BARRIER lpBarrier, [In] LONG lTotalThreads, [In] LONG lSpinCount);

        /// <summary>
        /// <para>
        /// Initializes a critical section object and sets the spin count for the critical section.
        /// When a thread tries to acquire a critical section that is locked, the thread spins:
        /// it enters a loop which iterates spin count times, checking to see if the lock is released.
        /// If the lock is not released before the loop finishes, the thread goes to sleep to wait for the lock to be released.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-initializecriticalsectionandspincount"/>
        /// </para>
        /// </summary>
        /// <param name="lpCriticalSection">
        /// A pointer to the critical section object.
        /// </param>
        /// <param name="dwSpinCount">
        /// The spin count for the critical section object.
        /// On single-processor systems, the spin count is ignored and the critical section spin count is set to 0 (zero).
        /// On multiprocessor systems, if the critical section is unavailable, the calling thread spins <paramref name="dwSpinCount"/> times
        /// before performing a wait operation on a semaphore associated with the critical section.
        /// If the critical section becomes free during the spin operation, the calling thread avoids the wait operation.
        /// </param>
        /// <returns>
        /// This function always succeeds and returns a <see langword="true"/> value.
        /// Windows Server 2003 and Windows XP:
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// Starting with Windows Vista, the <see cref="InitializeCriticalSectionAndSpinCount"/> function always succeeds, even in low memory situations.
        /// </returns>
        /// <remarks>
        /// The threads of a single process can use a critical section object for mutual-exclusion synchronization.
        /// There is no guarantee about the order that threads obtain ownership of the critical section.
        /// However, the system is fair to all threads.
        /// The process is responsible for allocating the memory used by a critical section object,
        /// which it can do by declaring a variable of type <see cref="CRITICAL_SECTION"/>.
        /// Before using a critical section, some thread of the process must initialize the object.
        /// You can subsequently modify the spin count by calling the <see cref="SetCriticalSectionSpinCount"/> function.
        /// After a critical section object is initialized, the threads of the process can specify the object in the <see cref="EnterCriticalSection"/>,
        /// <see cref="TryEnterCriticalSection"/>, or <see cref="LeaveCriticalSection"/> function to provide mutually exclusive access to a shared resource.
        /// For similar synchronization between the threads of different processes, use a mutex object.
        /// A critical section object cannot be moved or copied.
        /// The process must also not modify the object, but must treat it as logically opaque.
        /// Use only the critical section functions to manage critical section objects.
        /// When you have finished using the critical section, call the <see cref="DeleteCriticalSection"/> function.
        /// A critical section object must be deleted before it can be reinitialized.
        /// Initializing a critical section that is already initialized results in undefined behavior.
        /// The spin count is useful for critical sections of short duration that can experience high levels of contention.
        /// Consider a worst-case scenario, in which an application on an SMP system has two or three threads constantly allocating
        /// and releasing memory from the heap.
        /// The application serializes the heap with a critical section.
        /// In the worst-case scenario, contention for the critical section is constant,
        /// and each thread makes an processing-intensive call to the <see cref="WaitForSingleObject"/> function.
        /// However, if the spin count is set properly, the calling thread does not immediately
        /// call <see cref="WaitForSingleObject"/> when contention occurs.
        /// Instead, the calling thread can acquire ownership of the critical section if it is released during the spin operation.
        /// You can improve performance significantly by choosing a small spin count for a critical section of short duration.
        /// For example, the heap manager uses a spin count of roughly 4,000 for its per-heap critical sections.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitializeCriticalSectionAndSpinCount", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL InitializeCriticalSectionAndSpinCount([In][Out] ref CRITICAL_SECTION lpCriticalSection, [In] DWORD dwSpinCount);

        /// <summary>
        /// <para>
        /// Initializes a critical section object with a spin count and optional flags.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-initializecriticalsectionex"/>
        /// </para>
        /// </summary>
        /// <param name="lpCriticalSection">
        /// A pointer to the critical section object.
        /// </param>
        /// <param name="dwSpinCount">
        /// The spin count for the critical section object.
        /// On single-processor systems, the spin count is ignored and the critical section spin count is set to 0 (zero).
        /// On multiprocessor systems, if the critical section is unavailable, the calling thread spins <paramref name="dwSpinCount"/> times
        /// before performing a wait operation on a semaphore associated with the critical section.
        /// If the critical section becomes free during the spin operation, the calling thread avoids the wait operation.
        /// </param>
        /// <param name="Flags">
        /// This parameter can be 0 or the following value.
        /// <see cref="CRITICAL_SECTION_NO_DEBUG_INFO"/>: The critical section is created without debug information.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The threads of a single process can use a critical section object for mutual-exclusion synchronization.
        /// There is no guarantee about the order that threads obtain ownership of the critical section.
        /// However, the system is fair to all threads.
        /// The process is responsible for allocating the memory used by a critical section object,
        /// which it can do by declaring a variable of type <see cref="CRITICAL_SECTION"/>.
        /// Before using a critical section, some thread of the process must initialize the object.
        /// You can subsequently modify the spin count by calling the <see cref="SetCriticalSectionSpinCount"/> function.
        /// After a critical section object is initialized, the threads of the process can specify the object in the <see cref="EnterCriticalSection"/>,
        /// <see cref="TryEnterCriticalSection"/>, or <see cref="LeaveCriticalSection"/> function to provide mutually exclusive access to a shared resource.
        /// For similar synchronization between the threads of different processes, use a mutex object.
        /// A critical section object cannot be moved or copied.
        /// The process must also not modify the object, but must treat it as logically opaque.
        /// Use only the critical section functions to manage critical section objects.
        /// When you have finished using the critical section, call the <see cref="DeleteCriticalSection"/> function.
        /// A critical section object must be deleted before it can be reinitialized.
        /// Initializing a critical section that is already initialized results in undefined behavior.
        /// The spin count is useful for critical sections of short duration that can experience high levels of contention.
        /// Consider a worst-case scenario, in which an application on an SMP system has two or three threads constantly allocating
        /// and releasing memory from the heap.
        /// The application serializes the heap with a critical section.
        /// In the worst-case scenario, contention for the critical section is constant,
        /// and each thread makes an processing-intensive call to the <see cref="WaitForSingleObject"/> function.
        /// However, if the spin count is set properly, the calling thread does not immediately
        /// call <see cref="WaitForSingleObject"/> when contention occurs.
        /// Instead, the calling thread can acquire ownership of the critical section if it is released during the spin operation.
        /// You can improve performance significantly by choosing a small spin count for a critical section of short duration.
        /// For example, the heap manager uses a spin count of roughly 4,000 for its per-heap critical sections.
        /// This gives great performance and scalability in almost all worst-case scenarios.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitializeCriticalSectionEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL InitializeCriticalSectionEx([In][Out] ref CRITICAL_SECTION lpCriticalSection, [In] DWORD dwSpinCount, [In] DWORD Flags);

        /// <summary>
        /// <para>
        /// Begins one-time initialization.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-initoncebegininitialize"/>
        /// </para>
        /// </summary>
        /// <param name="lpInitOnce">
        /// A pointer to the one-time initialization structure.
        /// </param>
        /// <param name="dwFlags">
        /// This parameter can have a value of 0, or one or more of the following flags.
        /// <see cref="INIT_ONCE_ASYNC"/>:
        /// Enables multiple initialization attempts to execute in parallel.
        /// If this flag is used, subsequent calls to this function will fail unless this flag is also specified.
        /// <see cref="INIT_ONCE_CHECK_ONLY"/>:
        /// This function call does not begin initialization.
        /// The return value indicates whether initialization has already completed.
        /// If the function returns <see cref="TRUE"/>, the <paramref name="lpContext"/> parameter receives the data.
        /// </param>
        /// <param name="fPending">
        /// If the function succeeds, this parameter indicates the current initialization status.
        /// If this parameter is <see cref="TRUE"/> and <paramref name="dwFlags"/> contains <see cref="INIT_ONCE_CHECK_ONLY"/>,
        /// the initialization is pending and the context data is invalid.
        /// If this parameter is <see cref="FALSE"/>, initialization has already completed
        /// and the caller can retrieve the context data from the <paramref name="lpContext"/> parameter.
        /// If this parameter is <see cref="TRUE"/> and dwFlags does not contain <see cref="INIT_ONCE_CHECK_ONLY"/>,
        /// initialization has been started and the caller can perform the initialization tasks.
        /// </param>
        /// <param name="lpContext">
        /// An optional parameter that receives the data stored with the one-time initialization structure upon success.
        /// The low-order <see cref="INIT_ONCE_CTX_RESERVED_BITS"/> bits of the data are always zero.
        /// </param>
        /// <returns>
        /// If <see cref="INIT_ONCE_CHECK_ONLY"/> is not specified and the function succeeds, the return value is <see cref="TRUE"/>.
        /// If <see cref="INIT_ONCE_CHECK_ONLY"/> is specified and initialization has completed, the return value is <see cref="TRUE"/>.
        /// Otherwise, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// This function can be used for either synchronous or asynchronous one-time initialization.
        /// For asynchronous one-time initialization, use the <see cref="INIT_ONCE_ASYNC"/> flag.
        /// To specify a callback function to execute during synchronous one-time initialization, see the <see cref="InitOnceExecuteOnce"/> function.
        /// If this function succeeds, the thread can create a synchronization object and
        /// specify in the <paramref name="lpContext"/> parameter of the <see cref="InitOnceComplete"/> function.
        /// A one-time initialization object cannot be moved or copied.
        /// The process must not modify the initialization object, and must instead treat it as logically opaque.
        /// Only use the one-time initialization functions to manage one-time initialization objects.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitOnceBeginInitialize", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL InitOnceBeginInitialize([In][Out] ref INIT_ONCE lpInitOnce, [In] InitOnceFlags dwFlags, [Out] out BOOL fPending, [Out] out LPVOID lpContext);

        /// <summary>
        /// <para>
        /// Completes one-time initialization started with the <see cref="InitOnceBeginInitialize"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-initoncecomplete"/>
        /// </para>
        /// </summary>
        /// <param name="lpInitOnce">
        /// A pointer to the one-time initialization structure.
        /// </param>
        /// <param name="dwFlags">
        /// This parameter can be one of the following flags.
        /// <see cref="INIT_ONCE_ASYNC"/>:
        /// Operate in asynchronous mode.
        /// This enables multiple completion attempts to execute in parallel.
        /// This flag must match the flag passed in the corresponding call to the <see cref="InitOnceBeginInitialize"/> function.
        /// This flag may not be combined with <see cref="INIT_ONCE_INIT_FAILED"/>.
        /// <see cref="INIT_ONCE_INIT_FAILED"/>:
        /// The initialization attempt failed.
        /// This flag may not be combined with <see cref="INIT_ONCE_ASYNC"/>.
        /// To fail an asynchronous initialization, merely abandon it (that is, do not call the InitOnceComplete function).
        /// </param>
        /// <param name="lpContext">
        /// A pointer to the data to be stored with the one-time initialization structure.
        /// This data is returned in the lpContext parameter passed to subsequent calls to the <see cref="InitOnceBeginInitialize"/> function.
        /// If <paramref name="lpContext"/> points to a value, the low-order <see cref="INIT_ONCE_CTX_RESERVED_BITS"/> of the value must be zero.
        /// If <paramref name="lpContext"/> points to a data structure, the data structure must be DWORD-aligned.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitOnceComplete", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL InitOnceComplete([In][Out] ref INIT_ONCE lpInitOnce, [In] DWORD dwFlags, [In] LPVOID lpContext);

        /// <summary>
        /// <para>
        /// Executes the specified function successfully one time.
        /// No other threads that specify the same one-time initialization structure can execute the specified function
        /// while it is being executed by the current thread.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-initonceexecuteonce"/>
        /// </para>
        /// </summary>
        /// <param name="lpInitOnce">
        /// A pointer to the one-time initialization structure.
        /// </param>
        /// <param name="InitFn">
        /// A pointer to an application-defined InitOnceCallback function.
        /// </param>
        /// <param name="Parameter">
        /// A parameter to be passed to the callback function.
        /// </param>
        /// <param name="lpContext">
        /// An optional parameter that receives the data stored with the one-time initialization structure upon success.
        /// The low-order <see cref="INIT_ONCE_CTX_RESERVED_BITS"/> bits of the data are always zero.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// This function is used for synchronous one-time initialization.
        /// For asynchronous one-time initialization, use the <see cref="InitOnceBeginInitialize"/> function with the <see cref="INIT_ONCE_ASYNC"/> flag.
        /// Only one thread at a time can execute the callback function specified by <paramref name="InitFn"/>.
        /// Other threads that specify the same one-time initialization structure block until the callback finishes.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitOnceExecuteOnce", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL InitOnceExecuteOnce([In][Out] ref INIT_ONCE lpInitOnce, [In] PINIT_ONCE_FN InitFn, [In] PVOID Parameter, [Out] out LPVOID lpContext);

        /// <summary>
        /// <para>
        /// Initializes a one-time initialization structure.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-initonceinitialize"/>
        /// </para>
        /// </summary>
        /// <param name="InitOnce">
        /// A pointer to the one-time initialization structure.
        /// </param>
        /// <remarks>
        /// The <see cref="InitOnceInitialize"/> function is used to initialize a one-time initialization structure dynamically.
        /// To initialize the structure statically, assign the constant <see cref="INIT_ONCE_STATIC_INIT"/> to the structure variable.
        /// A one-time initialization object cannot be moved or copied.
        /// The process must not modify the initialization object, and must instead treat it as logically opaque.
        /// Only use the one-time initialization functions to manage one-time initialization objects.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitOnceInitialize", ExactSpelling = true, SetLastError = true)]
        public static extern void InitOnceInitialize([Out] out INIT_ONCE InitOnce);

        /// <summary>
        /// <para>
        /// Initializes the head of a singly linked list.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/interlockedapi/nf-interlockedapi-initializeslisthead"/>
        /// </para>
        /// </summary>
        /// <param name="ListHead">
        /// A pointer to an <see cref="SLIST_HEADER"/> structure that represents the head of a singly linked list.
        /// This structure is for system use only.
        /// </param>
        /// <remarks>
        /// All list items must be aligned on a MEMORY_ALLOCATION_ALIGNMENT boundary.
        /// Unaligned items can cause unpredictable results. See _aligned_malloc.
        /// To add items to the list, use the <see cref="InterlockedPushEntrySList"/> function.
        /// To remove items from the list, use the <see cref="InterlockedPopEntrySList"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitializeSListHead", ExactSpelling = true, SetLastError = true)]
        public static extern void InitializeSListHead([In][Out] ref SLIST_HEADER ListHead);

        /// <summary>
        /// <para>
        /// Initialize a slim reader/writer (SRW) lock.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-initializesrwlock?redirectedfrom=MSDN"/>
        /// </para>
        /// </summary>
        /// <param name="SRWLock">
        /// A pointer to the SRW lock.
        /// </param>
        /// <remarks>
        /// An SRW lock must be initialized before it is used.
        /// The <see cref="InitializeSRWLock"/> function is used to initialize a SRW lock dynamically.
        /// To initialize the structure statically, assign the constant <see cref="SRWLOCK_INIT"/> to the structure variable.
        /// An SRW lock cannot be moved or copied.
        /// The process must not modify the object, and must instead treat it as logically opaque.
        /// Only use the SRW functions to manage SRW locks.
        /// SRW locks do not need to be explicitly destroyed.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitializeSRWLock", ExactSpelling = true, SetLastError = true)]
        public static extern void InitializeSRWLock([In][Out] ref SRWLOCK SRWLock);

        ///// <summary>
        ///// <para>
        ///// Performs an atomic compare-and-exchange operation on the specified values.
        ///// The function compares two specified 32-bit values and exchanges with another 32-bit value based on the outcome of the comparison.
        ///// If you are exchanging pointer values, this function has been superseded by the <see cref="InterlockedCompareExchangePointer"/> function.
        ///// To operate on 64-bit values, use the <see cref="InterlockedCompareExchange64"/> function.
        ///// </para>
        ///// <para>
        ///// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/nf-winnt-interlockedcompareexchange"/>
        ///// </para>
        ///// </summary>
        ///// <param name="Destination">
        ///// A pointer to the destination value.
        ///// </param>
        ///// <param name="ExChange">
        ///// The exchange value.
        ///// </param>
        ///// <param name="Comperand">
        ///// The value to compare to <paramref name="Destination"/>.
        ///// </param>
        ///// <returns>
        ///// The function returns the initial value of the <paramref name="Destination"/> parameter.
        ///// </returns>
        ///// <remarks>
        ///// The function compares the <paramref name="Destination"/> value with the <paramref name="Comperand"/> value.
        ///// If the Destination value is equal to the <paramref name="Comperand"/> value,
        ///// the <paramref name="ExChange"/> value is stored in the address specified by <paramref name="Destination"/>.
        ///// Otherwise, no operation is performed.
        ///// The parameters for this function must be aligned on a 32-bit boundary;
        ///// otherwise, the function will behave unpredictably on multiprocessor x86 systems and any non-x86 systems.
        ///// See _aligned_malloc.
        ///// The interlocked functions provide a simple mechanism for synchronizing access to a variable that is shared by multiple threads.
        ///// This function is atomic with respect to calls to other interlocked functions.
        ///// This function is implemented using a compiler intrinsic where possible.
        ///// For more information, see the WinBase.h header file and _InterlockedCompareExchange.
        ///// This function generates a full memory barrier (or fence) to ensure that memory operations are completed in order.
        ///// Note This function is supported on Windows RT-based systems.
        ///// </remarks>
        //[DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InterlockedCompareExchange", ExactSpelling = true, SetLastError = true)]
        //public static extern LONG InterlockedCompareExchange([In][Out] ref LONG Destination, [In] LONG ExChange, [In] LONG Comperand);

        ///// <summary>
        ///// <para>
        ///// Performs an atomic compare-and-exchange operation on the specified values.
        ///// The function compares two specified 64-bit values and exchanges with another 64-bit value based on the outcome of the comparison.
        ///// </para>
        ///// <para>
        ///// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/nf-winnt-interlockedcompareexchange64"/>
        ///// </para>
        ///// </summary>
        ///// <param name="Destination">
        ///// A pointer to the destination value.
        ///// </param>
        ///// <param name="ExChange">
        ///// The exchange value.
        ///// </param>
        ///// <param name="Comperand">
        ///// The value to compare to <paramref name="Destination"/>.
        ///// </param>
        ///// <returns>
        ///// The function returns the initial value of the <paramref name="Destination"/> parameter.
        ///// </returns>
        ///// <remarks>
        ///// The function compares the <paramref name="Destination"/> value with the <paramref name="Comperand"/> value.
        ///// If the <paramref name="Destination"/> value is equal to the <paramref name="Comperand"/> value,
        ///// the <paramref name="ExChange"/> value is stored in the address specified by <paramref name="Destination"/>.
        ///// Otherwise, no operation is performed.
        ///// The variables for this function must be aligned on a 64-bit boundary;
        ///// otherwise, this function will behave unpredictably on multiprocessor x86 systems and any non-x86 systems.
        ///// See _aligned_malloc.
        ///// The interlocked functions provide a simple mechanism for synchronizing access to a variable that is shared by multiple threads.
        ///// This function is atomic with respect to calls to other interlocked functions.
        ///// This function is implemented using a compiler intrinsic where possible.
        ///// For more information, see the WinBase.h header file and _InterlockedCompareExchange64.
        ///// This function generates a full memory barrier (or fence) to ensure that memory operations are completed in order.
        ///// Note This function is supported on Windows RT-based systems.
        ///// </remarks>
        //[DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InterlockedCompareExchange64", ExactSpelling = true, SetLastError = true)]
        //public static extern LONG64 InterlockedCompareExchange64([In][Out] ref LONG64 Destination, [In] LONG64 ExChange, [In] LONG64 Comperand);

        ///// <summary>
        ///// <para>
        ///// Performs an atomic compare-and-exchange operation on the specified values.
        ///// The function compares two specified pointer values and exchanges with another pointer value based on the outcome of the comparison.
        ///// To operate on non-pointer values, use the <see cref="InterlockedCompareExchange"/> function.
        ///// </para>
        ///// <para>
        ///// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/nf-winnt-interlockedcompareexchangepointer"/>
        ///// </para>
        ///// </summary>
        ///// <param name="Destination">
        ///// A pointer to a pointer to the destination value.
        ///// </param>
        ///// <param name="Exchange">
        ///// The exchange value.
        ///// </param>
        ///// <param name="Comperand">
        ///// The value to compare to <paramref name="Destination"/>.
        ///// </param>
        ///// <returns>
        ///// The function returns the initial value of the <paramref name="Destination"/> parameter.
        ///// </returns>
        ///// <remarks>
        ///// The function compares the <paramref name="Destination"/> value with the <paramref name="Comperand"/> value.
        ///// If the <paramref name="Destination"/> value is equal to the <paramref name="Comperand"/> value,
        ///// the <paramref name="Exchange"/> value is stored in the address specified by <paramref name="Destination"/>.
        ///// Otherwise, no operation is performed.
        ///// On a 64-bit system, the parameters are 64 bits and must be aligned on 64-bit boundaries;
        ///// otherwise, the function will behave unpredictably.On a 32-bit system, the parameters are 32 bits and must be aligned on 32-bit boundaries.
        ///// The interlocked functions provide a simple mechanism for synchronizing access to a variable that is shared by multiple threads.
        ///// This function is atomic with respect to calls to other interlocked functions.
        ///// This function is implemented using a compiler intrinsic where possible.
        ///// For more information, see the WinBase.h header file and _InterlockedCompareExchangePointer.
        ///// This function generates a full memory barrier (or fence) to ensure that memory operations are completed in order.
        ///// Note This function is supported on Windows RT-based systems.
        ///// </remarks>
        //[DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InterlockedCompareExchangePointer", ExactSpelling = true, SetLastError = true)]
        //public static extern PVOID InterlockedCompareExchangePointer([In][Out] ref PVOID Destination, [In] PVOID Exchange, [In] PVOID Comperand);

        ///// <summary>
        ///// <para>
        ///// Decrements (decreases by one) the value of the specified 32-bit variable as an atomic operation.
        ///// To operate on 64-bit values, use the <see cref="InterlockedDecrement64"/> function.
        ///// </para>
        ///// <para>
        ///// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/nf-winnt-interlockeddecrement"/>
        ///// </para>
        ///// </summary>
        ///// <param name="Addend">
        ///// A pointer to the variable to be decremented.
        ///// </param>
        ///// <returns>
        ///// The function returns the resulting decremented value.
        ///// </returns>
        ///// <remarks>
        ///// The variable pointed to by the <paramref name="Addend"/> parameter must be aligned on a 32-bit boundary;
        ///// otherwise, this function will behave unpredictably on multiprocessor x86 systems and any non-x86 systems.
        ///// See _aligned_malloc.
        ///// The interlocked functions provide a simple mechanism for synchronizing access to a variable that is shared by multiple threads.
        ///// This function is atomic with respect to calls to other interlocked functions.
        ///// This function is implemented using a compiler intrinsic where possible.
        ///// For more information, see the WinBase.h header file and _InterlockedDecrement.
        ///// This function generates a full memory barrier (or fence) to ensure that memory operations are completed in order.
        ///// Note This function is supported on Windows RT-based systems.
        ///// </remarks>
        //[DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InterlockedDecrement", ExactSpelling = true, SetLastError = true)]
        //public static extern LONG InterlockedDecrement([In][Out] ref LONG Addend);

        ///// <summary>
        ///// <para>
        ///// Decrements (decreases by one) the value of the specified 64-bit variable as an atomic operation.
        ///// To operate on 32-bit values, use the <see cref="InterlockedDecrement"/> function.
        ///// </para>
        ///// <para>
        ///// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/nf-winnt-interlockeddecrement64"/>
        ///// </para>
        ///// </summary>
        ///// <param name="Addend">
        ///// A pointer to the variable to be decremented.
        ///// </param>
        ///// <returns>
        ///// The function returns the resulting decremented value.
        ///// </returns>
        ///// <remarks>
        ///// The variable pointed to by the <paramref name="Addend"/> parameter must be aligned on a 64-bit boundary;
        ///// otherwise, this function will behave unpredictably on multiprocessor x86 systems and any non-x86 systems. See _aligned_malloc.
        ///// The interlocked functions provide a simple mechanism for synchronizing access to a variable that is shared by multiple threads.
        ///// This function is atomic with respect to calls to other interlocked functions.
        ///// This function is implemented using a compiler intrinsic where possible.
        ///// For more information, see the WinBase.h header file and _InterlockedDecrement64.
        ///// This function generates a full memory barrier (or fence) to ensure that memory operations are completed in order.
        ///// Itanium-based systems:  For performance-critical applications, use InterlockedDecrementAcquire64 or InterlockedDecrementRelease64 instead.
        ///// Note  This function is supported on Windows RT-based systems.
        ///// </remarks>
        //[DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InterlockedDecrement64", ExactSpelling = true, SetLastError = true)]
        //public static extern LONG64 InterlockedDecrement64([In][Out] ref LONG64 Addend);

        ///// <summary>
        ///// <para>
        ///// Sets a 32-bit variable to the specified value as an atomic operation.
        ///// To operate on a pointer variable, use the <see cref="InterlockedExchangePointer"/> function.
        ///// To operate on a 16-bit variable, use the <see cref="InterlockedExchange16"/> function.
        ///// To operate on a 64-bit variable, use the <see cref="InterlockedExchange64"/> function.
        ///// </para>
        ///// <para>
        ///// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/nf-winnt-interlockedexchange"/>
        ///// </para>
        ///// </summary>
        ///// <param name="Target">
        ///// A pointer to the value to be exchanged.
        ///// The function sets this variable to <paramref name="Value"/>, and returns its prior value.
        ///// </param>
        ///// <param name="Value">
        ///// The value to be exchanged with the value pointed to by <paramref name="Target"/>.
        ///// </param>
        ///// <returns>
        ///// The function returns the initial value of the <paramref name="Target"/> parameter.
        ///// </returns>
        ///// <remarks>
        ///// The interlocked functions provide a simple mechanism for synchronizing access to a variable that is shared by multiple threads.
        ///// This function is atomic with respect to calls to other interlocked functions.
        ///// This function is implemented using a compiler intrinsic where possible.
        ///// For more information, see the WinBase.h header file and _InterlockedExchange.
        ///// This function generates a full memory barrier (or fence) to ensure that memory operations are completed in order.
        ///// Itanium-based systems:  For performance-critical applications, use InterlockedExchangeAcquire instead.
        ///// Note  This function is supported on Windows RT-based systems.
        ///// </remarks>
        //[DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InterlockedExchange", ExactSpelling = true, SetLastError = true)]
        //public static extern LONG InterlockedExchange([In][Out] ref LONG Target, [In] LONG Value);

        ///// <summary>
        ///// <para>
        ///// Sets a 32-bit variable to the specified value as an atomic operation.
        ///// To operate on a pointer variable, use the <see cref="InterlockedExchangePointer"/> function.
        ///// To operate on a 32-bit variable, use the <see cref="InterlockedExchange"/> function.
        ///// To operate on a 64-bit variable, use the <see cref="InterlockedExchange64"/> function.
        ///// </para>
        ///// <para>
        ///// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/nf-winnt-interlockedexchange16"/>
        ///// </para>
        ///// </summary>
        ///// <param name="Destination">
        ///// A pointer to the value to be exchanged.
        ///// The function sets this variable to <paramref name="ExChange"/>, and returns its prior value.
        ///// </param>
        ///// <param name="ExChange">
        ///// The value to be exchanged with the value pointed to by <paramref name="Destination"/>.
        ///// </param>
        ///// <returns>
        ///// The function returns the initial value of the <paramref name="Destination"/> parameter.
        ///// </returns>
        ///// <remarks>
        ///// The interlocked functions provide a simple mechanism for synchronizing access to a variable that is shared by multiple threads.
        ///// This function is atomic with respect to calls to other interlocked functions.
        ///// This function is implemented using a compiler intrinsic where possible.
        ///// For more information, see the WinBase.h header file and _InterlockedExchange16.
        ///// This function generates a full memory barrier (or fence) to ensure that memory operations are completed in order.
        ///// Itanium-based systems:  For performance-critical applications, use InterlockedExchangeAcquire instead.
        ///// Note  This function is supported on Windows RT-based systems.
        ///// </remarks>
        //[DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InterlockedExchange16", ExactSpelling = true, SetLastError = true)]
        //public static extern LONG InterlockedExchange16([In][Out] ref SHORT Destination, [In] SHORT ExChange);

        ///// <summary>
        ///// <para>
        ///// Sets a 32-bit variable to the specified value as an atomic operation.
        ///// To operate on a pointer variable, use the <see cref="InterlockedExchangePointer"/> function.
        ///// To operate on a 16-bit variable, use the <see cref="InterlockedExchange16"/> function.
        ///// To operate on a 32-bit variable, use the <see cref="InterlockedExchange"/> function.
        ///// </para>
        ///// <para>
        ///// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/nf-winnt-interlockedexchange32"/>
        ///// </para>
        ///// </summary>
        ///// <param name="Target">
        ///// A pointer to the value to be exchanged.
        ///// The function sets this variable to <paramref name="Value"/>, and returns its prior value.
        ///// </param>
        ///// <param name="Value">
        ///// The value to be exchanged with the value pointed to by <paramref name="Target"/>.
        ///// </param>
        ///// <returns>
        ///// The function returns the initial value of the <paramref name="Target"/> parameter.
        ///// </returns>
        ///// <remarks>
        ///// The interlocked functions provide a simple mechanism for synchronizing access to a variable that is shared by multiple threads.
        ///// This function is atomic with respect to calls to other interlocked functions.
        ///// This function is implemented using a compiler intrinsic where possible.
        ///// For more information, see the WinBase.h header file and _InterlockedExchange64.
        ///// This function generates a full memory barrier (or fence) to ensure that memory operations are completed in order.
        ///// Itanium-based systems:  For performance-critical applications, use InterlockedExchangeAcquire64 instead.
        ///// Note  This function is supported on Windows RT-based systems.
        ///// </remarks>
        //[DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InterlockedExchange64", ExactSpelling = true, SetLastError = true)]
        //public static extern LONG InterlockedExchange64([In][Out] ref LONG64 Target, [In] LONG64 Value);

        ///// <summary>
        ///// <para>
        ///// Performs an atomic addition of two 32-bit values.
        ///// To operate on 64-bit values, use the <see cref="InterlockedExchangeAdd64"/> function.
        ///// </para>
        ///// <para>
        ///// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/nf-winnt-interlockedexchangeadd"/>
        ///// </para>
        ///// </summary>
        ///// <param name="Addend">
        ///// A pointer to a variable. The value of this variable will be replaced with the result of the operation.
        ///// </param>
        ///// <param name="Value">
        ///// The value to be added to the variable pointed to by the <paramref name="Addend"/> parameter.
        ///// </param>
        ///// <returns>
        ///// The function returns the initial value of the <paramref name="Addend"/> parameter.
        ///// </returns>
        ///// <remarks>
        ///// The function performs an atomic addition of Value to the value pointed to by <paramref name="Addend"/>.
        ///// The result is stored in the address specified by <paramref name="Addend"/>.
        ///// The function returns the initial value of the variable pointed to by <paramref name="Addend"/>.
        ///// The variables for this function must be aligned on a 32-bit boundary;
        ///// otherwise, this function will behave unpredictably on multiprocessor x86 systems and any non-x86 systems.
        ///// See _aligned_malloc.
        ///// The interlocked functions provide a simple mechanism for synchronizing access to a variable that is shared by multiple threads.
        ///// This function is atomic with respect to calls to other interlocked functions.
        ///// This function is implemented using a compiler intrinsic where possible.
        ///// For more information, see the WinBase.h header file and _InterlockedExchangeAdd
        ///// This function generates a full memory barrier (or fence) to ensure that memory operations are completed in order.
        ///// Note This function is supported on Windows RT-based systems.
        ///// </remarks>
        //[DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InterlockedExchangeAdd", ExactSpelling = true, SetLastError = true)]
        //public static extern LONG InterlockedExchangeAdd([In][Out] ref LONG Addend, [In] LONG Value);

        ///// <summary>
        ///// <para>
        ///// Performs an atomic addition of two 64-bit values.
        ///// To operate on 32-bit values, use the <see cref="InterlockedExchangeAdd"/> function.
        ///// </para>
        ///// <para>
        ///// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/nf-winnt-interlockedexchangeadd64"/>
        ///// </para>
        ///// </summary>
        ///// <param name="Addend">
        ///// A pointer to a variable. The value of this variable will be replaced with the result of the operation.
        ///// </param>
        ///// <param name="Value">
        ///// The value to be added to the variable pointed to by the <paramref name="Addend"/> parameter.
        ///// </param>
        ///// <returns>
        ///// The function returns the initial value of the <paramref name="Addend"/> parameter.
        ///// </returns>
        ///// <remarks>
        ///// The function performs an atomic addition of Value to the value pointed to by <paramref name="Addend"/>.
        ///// The result is stored in the address specified by <paramref name="Addend"/>.
        ///// The function returns the initial value of the variable pointed to by <paramref name="Addend"/>.
        ///// The variables for this function must be aligned on a 64-bit boundary;
        ///// otherwise, this function will behave unpredictably on multiprocessor x86 systems and any non-x86 systems.
        ///// See _aligned_malloc.
        ///// The interlocked functions provide a simple mechanism for synchronizing access to a variable that is shared by multiple threads.
        ///// This function is atomic with respect to calls to other interlocked functions.
        ///// This function is implemented using a compiler intrinsic where possible.
        ///// For more information, see the WinBase.h header file and _InterlockedExchangeAdd64.
        ///// This function generates a full memory barrier (or fence) to ensure that memory operations are completed in order.
        ///// Note This function is supported on Windows RT-based systems.
        ///// </remarks>
        //[DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InterlockedExchangeAdd64", ExactSpelling = true, SetLastError = true)]
        //public static extern LONG64 InterlockedExchangeAdd64([In][Out] ref LONG64 Addend, [In] LONG64 Value);

        ///// <summary>
        ///// <para>
        ///// Atomically exchanges a pair of addresses.
        ///// </para>
        ///// <para>
        ///// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/nf-winnt-interlockedexchangepointer"/>
        ///// </para>
        ///// </summary>
        ///// <param name="Target">
        ///// A pointer to the address to exchange.
        ///// The function sets the address pointed to by the <paramref name="Target"/> parameter (*Target) to the address 
        ///// that is the value of the <paramref name="Value"/> parameter, and returns the prior value of the <paramref name="Target"/> parameter.
        ///// </param>
        ///// <param name="Value">
        ///// The address to be exchanged with the address pointed to by the <paramref name="Target"/> parameter (*Target).
        ///// </param>
        ///// <returns>
        ///// The function returns the initial address pointed to by the <paramref name="Target"/> parameter.
        ///// </returns>
        ///// <remarks>
        ///// This function copies the address passed as the second parameter to the first and returns the original address of the first.
        ///// On a 64-bit system, the parameters are 64 bits and the Target parameter must be aligned on 64-bit boundaries;
        ///// otherwise, the function will behave unpredictably.
        ///// On a 32-bit system, the parameters are 32 bits and the Target parameter must be aligned on 32-bit boundaries.
        ///// The interlocked functions provide a simple mechanism for synchronizing access to a variable that is shared by multiple threads.
        ///// This function is atomic with respect to calls to other interlocked functions.
        ///// This function is implemented using a compiler intrinsic where possible.
        ///// For more information, see the WinBase.h header file and _InterlockedExchangePointer.
        ///// This function generates a full memory barrier (or fence) to ensure that memory operations are completed in order.
        ///// Note This function is supported on Windows RT-based systems.
        ///// </remarks>
        //[DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InterlockedExchangePointer", ExactSpelling = true, SetLastError = true)]
        //public static extern PVOID InterlockedExchangePointer([In][Out] ref PVOID Target, [In] PVOID Value);

        /// <summary>
        /// <para>
        /// Removes all items from a singly linked list.
        /// Access to the list is synchronized on a multiprocessor system.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/interlockedapi/nf-interlockedapi-interlockedflushslist"/>
        /// </para>
        /// </summary>
        /// <param name="ListHead">
        /// Pointer to an <see cref="SLIST_HEADER"/> structure that represents the head of the singly linked list.
        /// This structure is for system use only.
        /// </param>
        /// <returns>
        /// The return value is a pointer to the items removed from the list.
        /// If the list is empty, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// All list items must be aligned on a MEMORY_ALLOCATION_ALIGNMENT boundary;
        /// otherwise, this function will behave unpredictably. See _aligned_malloc.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InterlockedFlushSList", ExactSpelling = true, SetLastError = true)]
        public static extern PSLIST_ENTRY InterlockedFlushSList([In][Out] ref SLIST_HEADER ListHead);

        ///// <summary>
        ///// <para>
        ///// Increments (increases by one) the value of the specified 32-bit variable as an atomic operation.
        ///// To operate on 64-bit values, use the <see cref="InterlockedIncrement64"/> function.
        ///// </para>
        ///// <para>
        ///// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/nf-winnt-interlockedincrement"/>
        ///// </para>
        ///// </summary>
        ///// <param name="Addend">
        ///// A pointer to the variable to be incremented.
        ///// </param>
        ///// <returns>
        ///// The function returns the resulting incremented value.
        ///// </returns>
        ///// <remarks>
        ///// The variable pointed to by the <paramref name="Addend"/> parameter must be aligned on a 32-bit boundary;
        ///// otherwise, this function will behave unpredictably on multiprocessor x86 systems and any non-x86 systems.
        ///// See _aligned_malloc.
        ///// The interlocked functions provide a simple mechanism for synchronizing access to a variable that is shared by multiple threads.
        ///// This function is atomic with respect to calls to other interlocked functions.
        ///// This function is implemented using a compiler intrinsic where possible.
        ///// For more information, see the WinBase.h header file and _InterlockedIncrement.
        ///// This function generates a full memory barrier (or fence) to ensure that memory operations are completed in order.
        ///// This function is supported on Windows RT-based systems.
        ///// </remarks>
        //[DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InterlockedIncrement", ExactSpelling = true, SetLastError = true)]
        //public static extern LONG InterlockedIncrement([In][Out] ref LONG Addend);

        ///// <summary>
        ///// <para>
        ///// Increments (increases by one) the value of the specified 64-bit variable as an atomic operation.
        ///// To operate on 32-bit values, use the <see cref="InterlockedIncrement"/> function.
        ///// </para>
        ///// <para>
        ///// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/nf-winnt-interlockedincrement64"/>
        ///// </para>
        ///// </summary>
        ///// <param name="Addend">
        ///// A pointer to the variable to be incremented.
        ///// </param>
        ///// <returns>
        ///// The function returns the resulting incremented value.
        ///// </returns>
        ///// <remarks>
        ///// The variable pointed to by the <paramref name="Addend"/> parameter must be aligned on a 64-bit boundary;
        ///// otherwise, this function will behave unpredictably on multiprocessor x86 systems and any non-x86 systems. See _aligned_malloc.
        ///// The interlocked functions provide a simple mechanism for synchronizing access to a variable that is shared by multiple threads.
        ///// This function is atomic with respect to calls to other interlocked functions.
        ///// This function is implemented using a compiler intrinsic where possible.
        ///// For more information, see the WinBase.h header file and _InterlockedIncrement64.
        ///// This function generates a full memory barrier (or fence) to ensure that memory operations are completed in order.
        ///// Itanium-based systems:  For performance-critical applications, use InterlockedIncrementAcquire64 or InterlockedIncrementRelease64 instead.
        ///// Note  This function is supported on Windows RT-based systems.
        ///// </remarks>
        //[DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InterlockedIncrement64", ExactSpelling = true, SetLastError = true)]
        //public static extern LONG64 InterlockedIncrement64([In][Out] ref LONG64 Addend);

        /// <summary>
        /// <para>
        /// Removes an item from the front of a singly linked list.
        /// Access to the list is synchronized on a multiprocessor system.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/interlockedapi/nf-interlockedapi-interlockedpopentryslist"/>
        /// </para>
        /// </summary>
        /// <param name="ListHead">
        /// Pointer to an <see cref="SLIST_HEADER"/> structure that represents the head of a singly linked list.
        /// </param>
        /// <returns>
        /// The return value is a pointer to the item removed from the list.
        /// If the list is empty, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// All list items must be aligned on a MEMORY_ALLOCATION_ALIGNMENT boundary; otherwise, this function will behave unpredictably.
        /// See _aligned_malloc.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InterlockedPopEntrySList", ExactSpelling = true, SetLastError = true)]
        public static extern PSLIST_ENTRY InterlockedPopEntrySList([In][Out] ref SLIST_HEADER ListHead);

        /// <summary>
        /// <para>
        /// Inserts an item at the front of a singly linked list.
        /// Access to the list is synchronized on a multiprocessor system.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/interlockedapi/nf-interlockedapi-interlockedpushentryslist"/>
        /// </para>
        /// </summary>
        /// <param name="ListHead">
        /// Pointer to an <see cref="SLIST_HEADER"/> structure that represents the head of a singly linked list.
        /// </param>
        /// <param name="ListEntry">
        /// Pointer to an <see cref="SLIST_ENTRY"/> structure that represents an item in a singly linked list.
        /// </param>
        /// <returns>
        /// The return value is the previous first item in the list.
        /// If the list was previously empty, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// All list items must be aligned on a MEMORY_ALLOCATION_ALIGNMENT boundary; otherwise, this function will behave unpredictably.
        /// See _aligned_malloc.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InterlockedPushEntrySList", ExactSpelling = true, SetLastError = true)]
        public static extern PSLIST_ENTRY InterlockedPushEntrySList([In][Out] ref SLIST_HEADER ListHead, [In] PSLIST_ENTRY ListEntry);

        /// <summary>
        /// <para>
        /// Releases ownership of the specified critical section object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-leavecriticalsection"/>
        /// </para>
        /// </summary>
        /// <param name="lpCriticalSection">
        /// A pointer to the critical section object.
        /// </param>
        /// <remarks>
        /// The threads of a single process can use a critical-section object for mutual-exclusion synchronization.
        /// The process is responsible for allocating the memory used by a critical-section object,
        /// which it can do by declaring a variable of type <see cref="CRITICAL_SECTION"/>.
        /// Before using a critical section, some thread of the process must call the <see cref="InitializeCriticalSection"/> or
        /// <see cref="InitializeCriticalSectionAndSpinCount"/> function to initialize the object.
        /// A thread uses the <see cref="EnterCriticalSection"/> or <see cref="TryEnterCriticalSection"/> function
        /// to acquire ownership of a critical section object.
        /// To release its ownership, the thread must call <see cref="LeaveCriticalSection"/> once for each time that it entered the critical section.
        /// If a thread calls <see cref="LeaveCriticalSection"/> when it does not have ownership of the specified critical section object,
        /// an error occurs that may cause another thread using <see cref="EnterCriticalSection"/> to wait indefinitely.
        /// Any thread of the process can use the <see cref="DeleteCriticalSection"/> function to release the system resources
        /// that were allocated when the critical section object was initialized.
        /// After this function has been called, the critical section object can no longer be used for synchronization.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "LeaveCriticalSection", ExactSpelling = true, SetLastError = true)]
        public static extern void LeaveCriticalSection([In][Out] ref CRITICAL_SECTION lpCriticalSection);

        /// <summary>
        /// <para>
        /// Retrieves the number of entries in the specified singly linked list.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/interlockedapi/nf-interlockedapi-querydepthslist"/>
        /// </para>
        /// </summary>
        /// <param name="ListHead">
        /// A pointer to an <see cref="SLIST_HEADER"/> structure that represents the head of a singly linked list.
        /// This structure is for system use only.
        /// The list must be previously initialized with the <see cref="InitializeSListHead"/> function.
        /// </param>
        /// <returns>
        /// The function returns the number of entries in the list, up to a maximum value of 65535.
        /// </returns>
        /// <remarks>
        /// The system does not limit the number of entries in a singly linked list.
        /// However, the return value of QueryDepthSList is truncated to 16 bits, so the maximum value it can return is 65535.
        /// If the specified singly linked list contains more than 65535 entries, <see cref="QueryDepthSList"/> returns the number of entries in the list modulo 65535.
        /// For example, if the specified list contains 65536 entries, <see cref="QueryDepthSList"/> returns zero.
        /// The return value of <see cref="QueryDepthSList"/> should not be relied upon in multithreaded applications
        /// because the item count can be changed at any time by another thread.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "QueryDepthSList", ExactSpelling = true, SetLastError = true)]
        public static extern USHORT QueryDepthSList([In] in SLIST_HEADER ListHead);

        /// <summary>
        /// <para>
        /// Adds a user-mode asynchronous procedure call (APC) object to the APC queue of the specified thread.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-queueuserapc"/>
        /// </para>
        /// </summary>
        /// <param name="pfnAPC">
        /// A pointer to the application-supplied APC function to be called when the specified thread performs an alertable wait operation.
        /// For more information, see <see cref="PAPCFUNC"/>.
        /// </param>
        /// <param name="hThread">
        /// A handle to the thread.
        /// The handle must have the <see cref="THREAD_SET_CONTEXT"/> access right.
        /// For more information, see Synchronization Object Security and Access Rights.
        /// </param>
        /// <param name="dwData">
        /// A single value that is passed to the APC function pointed to by the <paramref name="pfnAPC"/> parameter.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// Windows Server 2003 and Windows XP:
        /// There are no error values defined for this function that can be retrieved by calling <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The APC support provided in the operating system allows an application to queue an APC object to a thread.
        /// To ensure successful execution of functions used by the APC, APCs should be queued only to threads in the caller's process.
        /// Note Queuing APCs to threads outside the caller's process is not recommended for a number of reasons.
        /// DLL rebasing can cause the addresses of functions used by the APC to be incorrect when the functions are executed outside the caller's process.
        /// Similarly, if a 64-bit process queues an APC to a 32-bit process or vice versa, addresses will be incorrect and the application will crash.
        /// Other factors can prevent successful function execution, even if the address is known.
        /// Each thread has its own APC queue. The queuing of an APC is a request for the thread to call the APC function.
        /// The operating system issues a software interrupt to direct the thread to call the APC function.
        /// When a user-mode APC is queued, the thread is not directed to call the APC function unless it is in an alertable state.
        /// After the thread is in an alertable state, the thread handles all pending APCs in first in, first out (FIFO) order,
        /// and the wait operation returns <see cref="WAIT_IO_COMPLETION"/>.
        /// A thread enters an alertable state by using <see cref="SleepEx"/>, <see cref="SignalObjectAndWait"/>, <see cref="WaitForSingleObjectEx"/>,
        /// <see cref="WaitForMultipleObjectsEx"/>, or <see cref="MsgWaitForMultipleObjectsEx"/> to perform an alertable wait operation.
        /// If an application queues an APC before the thread begins running, the thread begins by calling the APC function.
        /// After the thread calls an APC function, it calls the APC functions for all APCs in its APC queue.
        /// It is possible to sleep or wait for an object within the APC.
        /// If you perform an alertable wait inside an APC, it will recursively dispatch the APCs. This can cause a stack overflow.
        /// When the thread is terminated using the <see cref="ExitThread"/> or <see cref="TerminateThread"/> function, the APCs in its APC queue are lost.
        /// The APC functions are not called.
        /// When the thread is in the process of being terminated, calling <see cref="QueueUserAPC"/> to add to the thread's APC queue
        /// will fail with (31) <see cref="ERROR_GEN_FAILURE"/>.
        /// Note that the <see cref="ReadFileEx"/>, <see cref="SetWaitableTimer"/>, and <see cref="WriteFileEx"/> functions are implemented
        /// using an APC as the completion notification callback mechanism.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0400 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "QueueUserAPC", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD QueueUserAPC([In] PAPCFUNC pfnAPC, [In] HANDLE hThread, [In] ULONG_PTR dwData);

        /// <summary>
        /// <para>
        /// Directs a wait thread in the thread pool to wait on the object.
        /// The wait thread queues the specified callback function to the thread pool when one of the following occurs:
        /// The specified object is in the signaled state.
        /// The time-out interval elapses.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-registerwaitforsingleobject"/>
        /// </para>
        /// </summary>
        /// <param name="phNewWaitObject">
        /// A pointer to a variable that receives a wait handle on return.
        /// Note that a wait handle cannot be used in functions that require an object handle, such as <see cref="CloseHandle"/>.
        /// </param>
        /// <param name="hObject">
        /// A handle to the object. For a list of the object types whose handles can be specified, see the following Remarks section.
        /// If this handle is closed while the wait is still pending, the function's behavior is undefined.
        /// The handles must have the <see cref="SYNCHRONIZE"/> access right. For more information, see Standard Access Rights.
        /// </param>
        /// <param name="Callback">
        /// A pointer to the application-defined function of type <see cref="WAITORTIMERCALLBACK"/> to be executed
        /// when <paramref name="hObject"/> is in the signaled state, or <paramref name="dwMilliseconds"/> elapses.
        /// For more information, see <see cref="WAITORTIMERCALLBACK"/>.
        /// </param>
        /// <param name="Context">
        /// A single value that is passed to the callback function.
        /// </param>
        /// <param name="dwMilliseconds">
        /// The time-out interval, in milliseconds.
        /// The function returns if the interval elapses, even if the object's state is nonsignaled.
        /// If <paramref name="dwMilliseconds"/> is zero, the function tests the object's state and returns immediately.
        /// If <paramref name="dwMilliseconds"/> is <see cref="INFINITE"/>, the function's time-out interval never elapses.
        /// </param>
        /// <param name="dwFlags">
        /// This parameter can be one or more of the following values.
        /// For information about using these values with objects that remain signaled, see the Remarks section.
        /// <see cref="WT_EXECUTEDEFAULT"/>, <see cref="WT_EXECUTEINIOTHREAD"/>, <see cref="WT_EXECUTEINPERSISTENTTHREAD"/>,
        /// <see cref="WT_EXECUTEINWAITTHREAD"/>, <see cref="WT_EXECUTELONGFUNCTION"/>, <see cref="WT_EXECUTEONLYONCE"/>,
        /// <see cref="WT_TRANSFER_IMPERSONATION"/>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// New wait threads are created automatically when required.
        /// The wait operation is performed by a wait thread from the thread pool.
        /// The callback routine is executed by a worker thread when the object's state becomes signaled or the time-out interval elapses.
        /// If <paramref name="dwFlags"/> is not <see cref="WT_EXECUTEONLYONCE"/>, the timer is reset every time the event is signaled or the time-out interval elapses.
        /// When the wait is completed, you must call the <see cref="UnregisterWait"/>
        /// or <see cref="UnregisterWaitEx"/> function to cancel the wait operation.
        /// (Even wait operations that use <see cref="WT_EXECUTEONLYONCE"/> must be canceled.)
        /// Do not make a blocking call to either of these functions from within the callback function.
        /// Note that you should not pulse an event object passed to <see cref="RegisterWaitForSingleObject"/>,
        /// because the wait thread might not detect that the event is signaled before it is reset.
        /// You should not register an object that remains signaled (such as a manual reset event or terminated process)
        /// unless you set the <see cref="WT_EXECUTEONLYONCE"/> or <see cref="WT_EXECUTEINWAITTHREAD"/> flag.
        /// For other flags, the callback function might be called too many times before the event is reset.
        /// The function modifies the state of some types of synchronization objects.
        /// Modification occurs only for the object whose signaled state caused the wait condition to be satisfied.
        /// For example, the count of a semaphore object is decreased by one.
        /// The <see cref="RegisterWaitForSingleObject"/> function can wait for the following objects:
        /// Change notification, Console input, Event, Memory resource notification, Mutex, Process, Semaphore, Thread, Waitable timer
        /// For more information, see Synchronization Objects.
        /// By default, the thread pool has a maximum of 500 threads.
        /// To raise this limit, use the <see cref="WT_SET_MAX_THREADPOOL_THREADS"/> macro defined in WinNT.h.
        /// <code>
        /// #define WT_SET_MAX_THREADPOOL_THREADS(Flags,Limit) \
        /// ((Flags)|=(Limit)&lt;&lt;16)
        /// </code>
        /// Use this macro when specifying the dwFlags parameter. 
        /// The macro parameters are the desired flags and the new limit(up to (2&lt;&lt;16)-1 threads).
        /// However, note that your application can improve its performance by keeping the number of worker threads low.
        /// The work item and all functions it calls must be thread-pool safe.
        /// Therefore, you cannot call an asynchronous call that requires a persistent thread,
        /// such as the <see cref="RegNotifyChangeKeyValue"/> function, from the default callback environment.
        /// Instead, set the thread pool maximum equal to the thread pool minimum
        /// using the <see cref="SetThreadpoolThreadMaximum"/> and <see cref="SetThreadpoolThreadMinimum"/> functions,
        /// or create your own thread using the <see cref="CreateThread"/> function.
        /// (For the original thread pool API, specify <see cref="WT_EXECUTEINPERSISTENTTHREAD"/> using the <see cref="QueueUserWorkItem"/> function.)
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0500 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegisterWaitForSingleObject", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL RegisterWaitForSingleObject([Out] out HANDLE phNewWaitObject, [In] HANDLE hObject, [In] WAITORTIMERCALLBACK Callback,
            [In] PVOID Context, [In] ULONG dwMilliseconds, [In] ThreadPoolFlags dwFlags);

        /// <summary>
        /// <para>
        /// Releases a slim reader/writer (SRW) lock that was acquired in exclusive mode.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-releasesrwlockexclusive"/>
        /// </para>
        /// </summary>
        /// <param name="SRWLock">
        /// A pointer to the SRW lock.
        /// </param>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ReleaseSRWLockExclusive", ExactSpelling = true, SetLastError = true)]
        public static extern void ReleaseSRWLockExclusive([In][Out] ref SRWLOCK SRWLock);

        /// <summary>
        /// <para>
        /// Releases a slim reader/writer (SRW) lock that was acquired in shared mode.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-releasesrwlockshared"/>
        /// </para>
        /// </summary>
        /// <param name="SRWLock">
        /// A pointer to the SRW lock.
        /// </param>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ReleaseSRWLockShared", ExactSpelling = true, SetLastError = true)]
        public static extern void ReleaseSRWLockShared([In][Out] ref SRWLOCK SRWLock);

        /// <summary>
        /// <para>
        /// Sets the spin count for the specified critical section.
        /// Spinning means that when a thread tries to acquire a critical section that is locked, the thread enters a loop,
        /// checks to see if the lock is released, and if the lock is not released, the thread goes to sleep.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-setcriticalsectionspincount"/>
        /// </para>
        /// </summary>
        /// <param name="lpCriticalSection">
        /// A pointer to the critical section object.
        /// </param>
        /// <param name="dwSpinCount">
        /// The spin count for the critical section object.
        /// On single-processor systems, the spin count is ignored and the critical section spin count is set to zero (0).
        /// On multiprocessor systems, if the critical section is unavailable,
        /// the calling thread spins <paramref name="dwSpinCount"/> times before performing a wait operation
        /// on a semaphore associated with the critical section.
        /// If the critical section becomes free during the spin operation, the calling thread avoids the wait operation.
        /// </param>
        /// <returns>
        /// The function returns the previous spin count for the critical section.
        /// </returns>
        /// <remarks>
        /// The threads of a single process can use a critical section object for mutual-exclusion synchronization.
        /// The process is responsible for allocating the memory used by a critical section object,
        /// which it can do by declaring a variable of type <see cref="CRITICAL_SECTION"/>.
        /// Before using a critical section, some thread of the process must call the <see cref="InitializeCriticalSection"/>
        /// or <see cref="InitializeCriticalSectionAndSpinCount"/> function to initialize the object.
        /// You can subsequently modify the spin count by calling the <see cref="SetCriticalSectionSpinCount"/> function.
        /// The spin count is useful for critical sections of short duration that can experience high levels of contention.
        /// Consider a worst-case scenario, in which an application on an SMP system has two or three threads constantly
        /// allocating and releasing memory from the heap.
        /// The application serializes the heap with a critical section.
        /// In the worst-case scenario, contention for the critical section is constant,
        /// and each thread makes an processing-intensive call to the <see cref="WaitForSingleObject"/> function.
        /// However, if the spin count is set properly, the calling thread does not immediately
        /// call <see cref="WaitForSingleObject"/> when contention occurs.
        /// Instead, the calling thread can acquire ownership of the critical section if it is released during the spin operation.
        /// You can improve performance significantly by choosing a small spin count for a critical section of short duration.
        /// The heap manager uses a spin count of roughly 4000 for its per-heap critical sections.
        /// This gives great performance and scalability in almost all worst-case scenarios.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0403 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetCriticalSectionSpinCount", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD SetCriticalSectionSpinCount([In] in CRITICAL_SECTION lpCriticalSection, [In] DWORD dwSpinCount);

        /// <summary>
        /// <para>
        /// Signals one object and waits on another object as a single operation.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-signalobjectandwait"/>
        /// </para>
        /// </summary>
        /// <param name="hObjectToSignal">
        /// A handle to the object to be signaled. This object can be a semaphore, a mutex, or an event.
        /// If the handle is a semaphore, the <see cref="SEMAPHORE_MODIFY_STATE"/> access right is required.
        /// If the handle is an event, the <see cref="EVENT_MODIFY_STATE"/> access right is required.
        /// If the handle is a mutex and the caller does not own the mutex, the function fails with <see cref="ERROR_NOT_OWNER"/>.
        /// </param>
        /// <param name="hObjectToWaitOn">
        /// A handle to the object to wait on.
        /// The <see cref="SYNCHRONIZE"/> access right is required; for more information, see Synchronization Object Security and Access Rights.
        /// For a list of the object types whose handles you can specify, see the Remarks section.
        /// </param>
        /// <param name="dwMilliseconds">
        /// The time-out interval, in milliseconds.
        /// The function returns if the interval elapses, even if the object's state is nonsignaled and
        /// no completion or asynchronous procedure call (APC) objects are queued.
        /// If <paramref name="dwMilliseconds"/> is zero, the function tests the object's state,
        /// checks for queued completion routines or APCs, and returns immediately.
        /// If <paramref name="dwMilliseconds"/> is <see cref="INFINITE"/>, the function's time-out interval never elapses.
        /// </param>
        /// <param name="bAlertable">
        /// If this parameter is <see cref="TRUE"/>, the function returns when the system queues an I/O completion routine or APC function,
        /// and the thread calls the function.
        /// If <see cref="FALSE"/>, the function does not return, and the thread does not call the completion routine or APC function.
        /// A completion routine is queued when the function call that queued the APC has completed.
        /// This function returns and the completion routine is called only if <paramref name="bAlertable"/> is <see cref="TRUE"/>,
        /// and the calling thread is the thread that queued the APC.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value indicates the event that caused the function to return.
        /// It can be one of the following values.
        /// <see cref="WAIT_ABANDONED"/>:
        /// The specified object is a mutex object that was not released by the thread that owned the mutex object before the owning thread terminated.
        /// Ownership of the mutex object is granted to the calling thread, and the mutex is set to nonsignaled.
        /// If the mutex was protecting persistent state information, you should check it for consistency.
        /// <see cref="WAIT_IO_COMPLETION"/>:
        /// The wait was ended by one or more user-mode asynchronous procedure calls (APC) queued to the thread.
        /// <see cref="WAIT_OBJECT_0"/>:
        /// The state of the specified object is signaled.
        /// <see cref="WAIT_TIMEOUT"/>:
        /// The time-out interval elapsed, and the object's state is nonsignaled.
        /// <see cref="WAIT_FAILED"/>:
        /// The function has failed.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="SignalObjectAndWait"/> function provides a more efficient way to signal one object and then wait on another compared
        /// to separate function calls such as <see cref="SetEvent"/> followed by <see cref="WaitForSingleObject"/>.
        /// The <see cref="SignalObjectAndWait"/> function can wait for the following objects:
        /// Change notification, Console input, Event, Memory resource notification, Mutex, Process, Semaphore, Thread, Waitable timer
        /// For more information, see Synchronization Objects.
        /// A thread can use the <see cref="SignalObjectAndWait"/> function to ensure that a worker thread is in a wait state before signaling an object.
        /// For example, a thread and a worker thread may use handles to event objects to synchronize their work.
        /// The thread executes code such as the following:
        /// <code>
        /// dwRet = WaitForSingleObject(hEventWorkerDone, INFINITE);
        /// if( WAIT_OBJECT_0 == dwRet)
        ///     SetEvent(hEventMoreWorkToDo);
        /// </code>
        /// The worker thread executes code such as the following:
        /// <code>
        /// dwRet = SignalObjectAndWait(hEventWorkerDone, hEventMoreWorkToDo, INFINITE, FALSE);
        /// </code>
        /// Note that the "signal" and "wait" are not guaranteed to be performed as an atomic operation.
        /// Threads executing on other processors can observe the signaled state of the first object before the thread 
        /// calling <see cref="SignalObjectAndWait"/> begins its wait on the second object.
        /// Use extreme caution when using <see cref="SignalObjectAndWait"/> and <see cref="PulseEvent"/> with Windows 7,
        /// since using these APIs among multiple threads can cause an application to deadlock.
        /// Threads that are signaled by <see cref="SignalObjectAndWait"/> call <see cref="PulseEvent"/>
        /// to signal the waiting object of the <see cref="SignalObjectAndWait"/> call.
        /// In some circumstances, the caller of <see cref="SignalObjectAndWait"/> can't receive signal state
        /// of the waiting object in time, causing a deadlock.
        /// Use caution when using the wait functions and code that directly or indirectly creates windows.
        /// If a thread creates any windows, it must process messages.
        /// Message broadcasts are sent to all windows in the system.
        /// A thread that uses a wait function with no time-out interval may cause the system to become deadlocked.
        /// Two examples of code that indirectly creates windows are DDE and COM <see cref="CoInitialize"/>.
        /// Therefore, if you have a thread that creates windows, be sure to call <see cref="SignalObjectAndWait"/> from a different thread.
        /// If this is not possible, you can use <see cref="MsgWaitForMultipleObjects"/> or <see cref="MsgWaitForMultipleObjectsEx"/>,
        /// but the functionality is not equivalent.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0400 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SignalObjectAndWait", ExactSpelling = true, SetLastError = true)]
        public static extern WaitResult SignalObjectAndWait([In] HANDLE hObjectToSignal, [In] HANDLE hObjectToWaitOn,
            [In] DWORD dwMilliseconds, [In] BOOL bAlertable);

        /// <summary>
        /// <para>
        /// Sleeps on the specified condition variable and releases the specified critical section as an atomic operation.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-sleepconditionvariablecs"/>
        /// </para>
        /// </summary>
        /// <param name="ConditionVariable">
        /// A pointer to the condition variable.
        /// This variable must be initialized using the <see cref="InitializeConditionVariable"/> function.
        /// </param>
        /// <param name="CriticalSection">
        /// A pointer to the critical section object.
        /// This critical section must be entered exactly once by the caller at the time <see cref="SleepConditionVariableCS"/> is called.
        /// </param>
        /// <param name="dwMilliseconds">
        /// The time-out interval, in milliseconds.
        /// If the time-out interval elapses, the function re-acquires the critical section and returns zero.
        /// If <paramref name="dwMilliseconds"/> is zero, the function tests the states of the specified objects and returns immediately.
        /// If <paramref name="dwMilliseconds"/> is <see cref="INFINITE"/>, the function's time-out interval never elapses.
        /// For more information, see Remarks.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails or the time-out interval elapses, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// Possible error codes include <see cref="ERROR_TIMEOUT"/>, which indicates that the time-out interval has elapsed
        /// before another thread has attempted to wake the sleeping thread.
        /// </returns>
        /// <remarks>
        /// A thread that is sleeping on a condition variable can be woken before the specified time-out interval has elapsed
        /// using the <see cref="WakeConditionVariable"/> or <see cref="WakeAllConditionVariable"/> function.
        /// In this case, the thread wakes when the wake processing is complete, and not when its time-out interval elapses.
        /// After the thread is woken, it re-acquires the critical section it released when the thread entered the sleeping state.
        /// Condition variables are subject to spurious wakeups (those not associated with an explicit wake) and
        /// stolen wakeups (another thread manages to run before the woken thread).
        /// Therefore, you should recheck a predicate (typically in a while loop) after a sleep operation returns.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SleepConditionVariableCS", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SleepConditionVariableCS([In][Out] ref CONDITION_VARIABLE ConditionVariable,
            [In][Out] ref CRITICAL_SECTION CriticalSection, [In] DWORD dwMilliseconds);

        /// <summary>
        /// <para>
        /// Sleeps on the specified condition variable and releases the specified lock as an atomic operation.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-sleepconditionvariablesrw"/>
        /// </para>
        /// </summary>
        /// <param name="ConditionVariable">
        /// A pointer to the condition variable.
        /// This variable must be initialized using the <see cref="InitializeConditionVariable"/> function.
        /// </param>
        /// <param name="CriticalSection">
        /// A pointer to the lock.
        /// This lock must be held in the manner specified by the <paramref name="Flags"/> parameter.
        /// </param>
        /// <param name="dwMilliseconds">
        /// The time-out interval, in milliseconds.
        /// The function returns if the interval elapses.
        /// If <paramref name="dwMilliseconds"/> is zero, the function tests the states of the specified objects and returns immediately.
        /// If <paramref name="dwMilliseconds"/> is <see cref="INFINITE"/>, the function's time-out interval never elapses.
        /// </param>
        /// <param name="Flags">
        /// If this parameter is <see cref="CONDITION_VARIABLE_LOCKMODE_SHARED"/>, the SRW lock is in shared mode.
        /// Otherwise, the lock is in exclusive mode.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If the timeout expires the function returns <see langword="false"/> and <see cref="GetLastError"/> returns <see cref="ERROR_TIMEOUT"/>.
        /// </returns>
        /// <remarks>
        /// If the lock is unlocked when this function is called, the function behavior is undefined.
        /// The thread can be woken using the <see cref="WakeConditionVariable"/> or <see cref="WakeAllConditionVariable"/> function.
        /// Condition variables are subject to spurious wakeups (those not associated with an explicit wake) and
        /// stolen wakeups (another thread manages to run before the woken thread).
        /// Therefore, you should recheck a predicate (typically in a while loop) after a sleep operation returns.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SleepConditionVariableSRW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SleepConditionVariableSRW([In][Out] ref CONDITION_VARIABLE ConditionVariable,
            [In][Out] ref CRITICAL_SECTION CriticalSection, [In] DWORD dwMilliseconds, [In] ULONG Flags);

        /// <summary>
        /// <para>
        /// Attempts to acquire a slim reader/writer (SRW) lock in exclusive mode.
        /// If the call is successful, the calling thread takes ownership of the lock.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-tryacquiresrwlockexclusive"/>
        /// </para>
        /// </summary>
        /// <param name="SRWLock">
        /// A pointer to the SRW lock.
        /// </param>
        /// <returns>
        /// If the lock is successfully acquired, the return value is <see cref="BOOLEAN.TRUE"/>.
        /// if the current thread could not acquire the lock, the return value is <see cref="BOOLEAN.FALSE"/>.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "TryAcquireSRWLockExclusive", ExactSpelling = true, SetLastError = true)]
        public static extern BOOLEAN TryAcquireSRWLockExclusive([In][Out] ref SRWLOCK SRWLock);

        /// <summary>
        /// <para>
        /// Attempts to acquire a slim reader/writer (SRW) lock in shared mode.
        /// If the call is successful, the calling thread takes ownership of the lock.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-tryacquiresrwlockshared"/>
        /// </para>
        /// </summary>
        /// <param name="SRWLock">
        /// A pointer to the SRW lock.
        /// </param>
        /// <returns>
        /// If the lock is successfully acquired, the return value is <see cref="BOOLEAN.TRUE"/>.
        /// if the current thread could not acquire the lock, the return value is <see cref="BOOLEAN.FALSE"/>.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "TryAcquireSRWLockShared", ExactSpelling = true, SetLastError = true)]
        public static extern BOOLEAN TryAcquireSRWLockShared([In][Out] ref SRWLOCK SRWLock);

        /// <summary>
        /// <para>
        /// Attempts to enter a critical section without blocking.
        /// If the call is successful, the calling thread takes ownership of the critical section.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-tryentercriticalsection"/>
        /// </para>
        /// </summary>
        /// <param name="lpCriticalSection">
        /// A pointer to the critical section object.
        /// </param>
        /// <returns>
        /// If the critical section is successfully entered or the current thread already owns the critical section,
        /// the return value is <see langword="true"/>.
        /// If another thread already owns the critical section, the return value is <see langword="false"/>.
        /// </returns>
        /// <remarks>
        /// The threads of a single process can use a critical section object for mutual-exclusion synchronization.
        /// The process is responsible for allocating the memory used by a critical section object,
        /// which it can do by declaring a variable of type <see cref="CRITICAL_SECTION"/>.
        /// Before using a critical section, some thread of the process must call the <see cref="InitializeCriticalSection"/> or
        /// <see cref="InitializeCriticalSectionAndSpinCount"/> function to initialize the object.
        /// To enable mutually exclusive use of a shared resource, each thread calls the <see cref="EnterCriticalSection"/> or
        /// <see cref="TryEnterCriticalSection"/> function to request ownership of the critical section
        /// before executing any section of code that uses the protected resource.
        /// The difference is that <see cref="TryEnterCriticalSection"/> returns immediately,
        /// regardless of whether it obtained ownership of the critical section,
        /// while <see cref="EnterCriticalSection"/> blocks until the thread can take ownership of the critical section.
        /// When it has finished executing the protected code,
        /// the thread uses the <see cref="LeaveCriticalSection"/> function to relinquish ownership,
        /// enabling another thread to become the owner and gain access to the protected resource.
        /// The thread must call <see cref="LeaveCriticalSection"/> once for each time that it entered the critical section.
        /// Any thread of the process can use the <see cref="DeleteCriticalSection"/> function to release the system resources
        /// that were allocated when the critical section object was initialized.
        /// After this function has been called, the critical section object can no longer be used for synchronization.
        /// If a thread terminates while it has ownership of a critical section, the state of the critical section is undefined.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0400 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "TryEnterCriticalSection", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL TryEnterCriticalSection([In][Out] ref CRITICAL_SECTION lpCriticalSection);

        /// <summary>
        /// <para>
        /// Cancels a registered wait operation issued by the <see cref="RegisterWaitForSingleObject"/> function.
        /// To use a completion event, call the <see cref="UnregisterWaitEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-unregisterwait"/>
        /// </para>
        /// </summary>
        /// <param name="WaitHandle">
        /// The wait handle.
        /// This handle is returned by the <see cref="RegisterWaitForSingleObject"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If any callback functions associated with the timer have not completed when <see cref="UnregisterWait"/> is called,
        /// <see cref="UnregisterWait"/> unregisters the wait on the callback functions and fails with the <see cref="ERROR_IO_PENDING"/> error code.
        /// The error code does not indicate that the function has failed, and the function does not need to be called again.
        /// If your code requires an error code to set only when the unregister operation has failed, call <see cref="UnregisterWaitEx"/> instead.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0500 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "UnregisterWait", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL UnregisterWait([In] HANDLE WaitHandle);

        /// <summary>
        /// <para>
        /// Waits until one or all of the specified objects are in the signaled state or the time-out interval elapses.
        /// To enter an alertable wait state, use the <see cref="WaitForMultipleObjectsEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-waitformultipleobjects"/>
        /// </para>
        /// </summary>
        /// <param name="nCount">
        /// The number of object handles in the array pointed to by <paramref name="lpHandles"/>.
        /// The maximum number of object handles is <see cref="MAXIMUM_WAIT_OBJECTS"/>.
        /// This parameter cannot be zero.
        /// </param>
        /// <param name="lpHandles">
        /// An array of object handles.
        /// For a list of the object types whose handles can be specified, see the following Remarks section.
        /// The array can contain handles to objects of different types.
        /// It may not contain multiple copies of the same handle.
        /// If one of these handles is closed while the wait is still pending, the function's behavior is undefined.
        /// The handles must have the <see cref="SYNCHRONIZE"/> access right.
        /// For more information, see Standard Access Rights.
        /// </param>
        /// <param name="bWaitAll">
        /// If this parameter is <see langword="true"/>, the function returns when the state of all objects
        /// in the <paramref name="lpHandles"/> array is signaled.
        /// If <see langword="false"/>, the function returns when the state of any one of the objects is set to signaled.
        /// In the latter case, the return value indicates the object whose state caused the function to return.
        /// </param>
        /// <param name="dwMilliseconds">
        /// The time-out interval, in milliseconds.
        /// If a nonzero value is specified, the function waits until the specified objects are signaled or the interval elapses.
        /// If <paramref name="dwMilliseconds"/> is zero, the function does not enter a wait state if the specified objects are not signaled;
        /// it always returns immediately.
        /// If <paramref name="dwMilliseconds"/> is <see cref="INFINITE"/>, the function will return only when the specified objects are signaled.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value indicates the event that caused the function to return.
        /// It can be one of the following values.
        /// (Note that <see cref="WAIT_OBJECT_0"/> is defined as 0 and <see cref="WAIT_ABANDONED_0"/> is defined as 0x00000080L.)
        /// <see cref="WAIT_OBJECT_0"/> to (<see cref="WAIT_OBJECT_0"/> + <paramref name="nCount"/>– 1):
        /// If <paramref name="bWaitAll"/> is <see langword="true"/>, the return value indicates that the state of all specified objects is signaled.
        /// If <paramref name="bWaitAll"/> is <see langword="false"/>, the return value minus <see cref="WAIT_OBJECT_0"/>
        /// indicates the <paramref name="lpHandles"/> array index of the object that satisfied the wait.
        /// If more than one object became signaled during the call,
        /// this is the array index of the signaled object with the smallest index value of all the signaled objects.
        /// <see cref="WAIT_ABANDONED_0"/> to (<see cref="WAIT_ABANDONED_0 "/> + <paramref name="nCount"/>– 1):
        /// If <paramref name="bWaitAll"/> is <see langword="true"/>, the return value indicates that the state of all specified objects is
        /// signaled and at least one of the objects is an abandoned mutex object.
        /// If <paramref name="bWaitAll"/> is <see langword="false"/>, the return value minus <see cref="WAIT_ABANDONED_0"/> indicates
        /// the <paramref name="lpHandles"/> array index of an abandoned mutex object that satisfied the wait.
        /// Ownership of the mutex object is granted to the calling thread, and the mutex is set to nonsignaled.
        /// If a mutex was protecting persistent state information, you should check it for consistency.
        /// <see cref="WAIT_TIMEOUT"/>:
        /// The time-out interval elapsed and the conditions specified by the <paramref name="bWaitAll"/> parameter are not satisfied.
        /// <see cref="WAIT_FAILED"/>:
        /// The function has failed.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="WaitForMultipleObjects"/> function determines whether the wait criteria have been met.
        /// If the criteria have not been met, the calling thread enters the wait state until the conditions of the wait criteria
        /// have been met or the time-out interval elapses.
        /// When <paramref name="bWaitAll"/> is <see langword="true"/>, the function's wait operation is completed only
        /// when the states of all objects have been set to signaled.
        /// The function does not modify the states of the specified objects until the states of all objects have been set to signaled.
        /// For example, a mutex can be signaled, but the thread does not get ownership until the states of the other objects are also set to signaled.
        /// In the meantime, some other thread may get ownership of the mutex, thereby setting its state to nonsignaled.
        /// When <paramref name="bWaitAll"/> is <see langword="false"/>, this function checks the handles in the array in order starting with index 0,
        /// until one of the objects is signaled.
        /// If multiple objects become signaled, the function returns the index of the first handle in the array whose object was signaled.
        /// The function modifies the state of some types of synchronization objects.
        /// Modification occurs only for the object or objects whose signaled state caused the function to return.
        /// For example, the count of a semaphore object is decreased by one.
        /// For more information, see the documentation for the individual synchronization objects.
        /// To wait on more than <see cref="MAXIMUM_WAIT_OBJECTS"/> handles, use one of the following methods:
        /// Create a thread to wait on <see cref="MAXIMUM_WAIT_OBJECTS"/> handles, then wait on that thread plus the other handles.
        /// Use this technique to break the handles into groups of <see cref="MAXIMUM_WAIT_OBJECTS"/>.
        /// Call <see cref="RegisterWaitForSingleObject"/> to wait on each handle.
        /// A wait thread from the thread pool waits on <see cref="MAXIMUM_WAIT_OBJECTS"/> registered objects and assigns a worker thread
        /// after the object is signaled or the time-out interval expires.
        /// The <see cref="WaitForMultipleObjects"/> function can specify handles of any of the following object types
        /// in the <paramref name="lpHandles"/> array:
        /// Change notification, Console input, Event, Memory resource notification, Mutex, Process, Semaphore, Thread, Waitable timer.
        /// Use caution when calling the wait functions and code that directly or indirectly creates windows.
        /// If a thread creates any windows, it must process messages.
        /// Message broadcasts are sent to all windows in the system.
        /// A thread that uses a wait function with no time-out interval may cause the system to become deadlocked.
        /// Two examples of code that indirectly creates windows are DDE and the <see cref="CoInitialize"/> function.
        /// Therefore, if you have a thread that creates windows, use <see cref="MsgWaitForMultipleObjects"/> or
        /// <see cref="MsgWaitForMultipleObjectsEx"/>, rather than <see cref="WaitForMultipleObjects"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WaitForMultipleObjects", ExactSpelling = true, SetLastError = true)]
        public static extern WaitResult WaitForMultipleObjects([In] DWORD nCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)][In] HANDLE[] lpHandles,
            [MarshalAs(UnmanagedType.Bool)][In] BOOL bWaitAll, [In] DWORD dwMilliseconds);

        /// <summary>
        /// <para>
        /// Waits until one or all of the specified objects are in the signaled state,
        /// an I/O completion routine or asynchronous procedure call (APC) is queued to the thread, or the time-out interval elapses.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-waitformultipleobjectsex"/>
        /// </para>
        /// </summary>
        /// <param name="nCount">
        /// The number of object handles in the array pointed to by <paramref name="lpHandles"/>.
        /// The maximum number of object handles is <see cref="MAXIMUM_WAIT_OBJECTS"/>.
        /// This parameter cannot be zero.
        /// </param>
        /// <param name="lpHandles">
        /// An array of object handles.
        /// For a list of the object types whose handles can be specified, see the following Remarks section.
        /// The array can contain handles to objects of different types.
        /// It may not contain multiple copies of the same handle.
        /// If one of these handles is closed while the wait is still pending, the function's behavior is undefined.
        /// The handles must have the <see cref="SYNCHRONIZE"/> access right.
        /// For more information, see Standard Access Rights.
        /// </param>
        /// <param name="bWaitAll">
        /// If this parameter is <see langword="true"/>, the function returns when the state of all objects
        /// in the <paramref name="lpHandles"/> array is signaled.
        /// If <see langword="false"/>, the function returns when the state of any one of the objects is set to signaled.
        /// In the latter case, the return value indicates the object whose state caused the function to return.
        /// </param>
        /// <param name="dwMilliseconds">
        /// The time-out interval, in milliseconds.
        /// If a nonzero value is specified, the function waits until the specified objects are signaled or the interval elapses.
        /// If <paramref name="dwMilliseconds"/> is zero, the function does not enter a wait state if the specified objects are not signaled;
        /// it always returns immediately.
        /// If <paramref name="dwMilliseconds"/> is <see cref="INFINITE"/>, the function will return only when the specified objects are signaled.
        /// </param>
        /// <param name="bAlertable">
        /// If this parameter is <see cref="TRUE"/> and the thread is in the waiting state,
        /// the function returns when the system queues an I/O completion routine or APC, and the thread runs the routine or function.
        /// Otherwise, the function does not return and the completion routine or APC function is not executed.
        /// A completion routine is queued when the <see cref="ReadFileEx"/> or <see cref="WriteFileEx"/> function in which it was specified has completed.
        /// The wait function returns and the completion routine is called only if <paramref name="bAlertable"/> is <see cref="TRUE"/>
        /// and the calling thread is the thread that initiated the read or write operation.
        /// An APC is queued when you call <see cref="QueueUserAPC"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value indicates the event that caused the function to return.
        /// It can be one of the following values.
        /// (Note that <see cref="WAIT_OBJECT_0"/> is defined as 0 and <see cref="WAIT_ABANDONED_0"/> is defined as 0x00000080L.)
        /// <see cref="WAIT_OBJECT_0"/> to (<see cref="WAIT_OBJECT_0"/> + <paramref name="nCount"/>– 1):
        /// If <paramref name="bWaitAll"/> is <see langword="true"/>, the return value indicates that the state of all specified objects is signaled.
        /// If <paramref name="bWaitAll"/> is <see langword="false"/>, the return value minus <see cref="WAIT_OBJECT_0"/>
        /// indicates the <paramref name="lpHandles"/> array index of the object that satisfied the wait.
        /// If more than one object became signaled during the call,
        /// this is the array index of the signaled object with the smallest index value of all the signaled objects.
        /// <see cref="WAIT_ABANDONED_0"/> to (<see cref="WAIT_ABANDONED_0 "/> + <paramref name="nCount"/>– 1):
        /// If <paramref name="bWaitAll"/> is <see langword="true"/>, the return value indicates that the state of all specified objects is
        /// signaled and at least one of the objects is an abandoned mutex object.
        /// If <paramref name="bWaitAll"/> is <see langword="false"/>, the return value minus <see cref="WAIT_ABANDONED_0"/> indicates
        /// the <paramref name="lpHandles"/> array index of an abandoned mutex object that satisfied the wait.
        /// Ownership of the mutex object is granted to the calling thread, and the mutex is set to nonsignaled.
        /// If a mutex was protecting persistent state information, you should check it for consistency.
        /// <see cref="WAIT_TIMEOUT"/>:
        /// The time-out interval elapsed and the conditions specified by the <paramref name="bWaitAll"/> parameter are not satisfied.
        /// <see cref="WAIT_FAILED"/>:
        /// The function has failed.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="WaitForMultipleObjectsEx"/> function determines whether the wait criteria have been met.
        /// If the criteria have not been met, the calling thread enters the wait state until the conditions of the wait criteria
        /// have been met or the time-out interval elapses.
        /// When <paramref name="bWaitAll"/> is <see langword="true"/>, the function's wait operation is completed only
        /// when the states of all objects have been set to signaled.
        /// The function does not modify the states of the specified objects until the states of all objects have been set to signaled.
        /// For example, a mutex can be signaled, but the thread does not get ownership until the states of the other objects are also set to signaled.
        /// In the meantime, some other thread may get ownership of the mutex, thereby setting its state to nonsignaled.
        /// When <paramref name="bWaitAll"/> is <see langword="false"/>, this function checks the handles in the array in order starting with index 0,
        /// until one of the objects is signaled.
        /// If multiple objects become signaled, the function returns the index of the first handle in the array whose object was signaled.
        /// The function modifies the state of some types of synchronization objects.
        /// Modification occurs only for the object or objects whose signaled state caused the function to return.
        /// For example, the count of a semaphore object is decreased by one.
        /// For more information, see the documentation for the individual synchronization objects.
        /// To wait on more than <see cref="MAXIMUM_WAIT_OBJECTS"/> handles, use one of the following methods:
        /// Create a thread to wait on <see cref="MAXIMUM_WAIT_OBJECTS"/> handles, then wait on that thread plus the other handles.
        /// Use this technique to break the handles into groups of <see cref="MAXIMUM_WAIT_OBJECTS"/>.
        /// Call <see cref="RegisterWaitForSingleObject"/> to wait on each handle.
        /// A wait thread from the thread pool waits on <see cref="MAXIMUM_WAIT_OBJECTS"/> registered objects and assigns a worker thread
        /// after the object is signaled or the time-out interval expires.
        /// The <see cref="WaitForMultipleObjectsEx"/> function can specify handles of any of the following object types
        /// in the <paramref name="lpHandles"/> array:
        /// Change notification, Console input, Event, Memory resource notification, Mutex, Process, Semaphore, Thread, Waitable timer.
        /// Use caution when calling the wait functions and code that directly or indirectly creates windows.
        /// If a thread creates any windows, it must process messages.
        /// Message broadcasts are sent to all windows in the system.
        /// A thread that uses a wait function with no time-out interval may cause the system to become deadlocked.
        /// Two examples of code that indirectly creates windows are DDE and the <see cref="CoInitialize"/> function.
        /// Therefore, if you have a thread that creates windows, use <see cref="MsgWaitForMultipleObjects"/> or
        /// <see cref="MsgWaitForMultipleObjectsEx"/>, rather than <see cref="WaitForMultipleObjectsEx"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WaitForMultipleObjectsEx", ExactSpelling = true, SetLastError = true)]
        public static extern WaitResult WaitForMultipleObjectsEx([In] DWORD nCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)][In] IntPtr[] lpHandles,
            [In] BOOL bWaitAll, [In] DWORD dwMilliseconds, [In] BOOL bAlertable);

        /// <summary>
        /// <para>
        /// Waits until the specified object is in the signaled state or the time-out interval elapses.
        /// To enter an alertable wait state, use the <see cref="WaitForSingleObjectEx"/> function.
        /// To wait for multiple objects, use <see cref="WaitForMultipleObjects"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-waitforsingleobject"/>
        /// </para>
        /// </summary>
        /// <param name="hHandle">
        /// A handle to the object.
        /// For a list of the object types whose handles can be specified, see the following Remarks section.
        /// If this handle is closed while the wait is still pending, the function's behavior is undefined.
        /// The handle must have the <see cref="SYNCHRONIZE"/> access right.
        /// For more information, see Standard Access Rights.
        /// </param>
        /// <param name="dwMilliseconds">
        /// The time-out interval, in milliseconds.
        /// If a nonzero value is specified, the function waits until the object is signaled or the interval elapses.
        /// If <paramref name="dwMilliseconds"/> is zero, the function does not enter a wait state if the object is not signaled; it always returns immediately.
        /// If <paramref name="dwMilliseconds"/> is <see cref="INFINITE"/>, the function will return only when the object is signaled.
        /// Windows XP, Windows Server 2003, Windows Vista, Windows 7, Windows Server 2008 and Windows Server 2008 R2:
        /// The <paramref name="dwMilliseconds"/> value does include time spent in low-power states.
        /// For example, the timeout does keep counting down while the computer is asleep.
        /// Windows 8, Windows Server 2012, Windows 8.1, Windows Server 2012 R2, Windows 10 and Windows Server 2016:
        /// The <paramref name="dwMilliseconds"/> value does not include time spent in low-power states.
        /// For example, the timeout does not keep counting down while the computer is asleep.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value indicates the event that caused the function to return.
        /// It can be one of the following values.
        /// <see cref="WAIT_ABANDONED"/>:
        /// The specified object is a mutex object that was not released by the thread that owned the mutex object before the owning thread terminated.
        /// Ownership of the mutex object is granted to the calling thread and the mutex state is set to nonsignaled.
        /// If the mutex was protecting persistent state information, you should check it for consistency.
        /// <see cref="WAIT_OBJECT_0"/>:
        /// The state of the specified object is signaled.
        /// <see cref="WAIT_TIMEOUT"/>:
        /// The time-out interval elapsed, and the object's state is nonsignaled.
        /// <see cref="WAIT_FAILED"/>:
        /// The function has failed. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="WaitForSingleObject"/> function checks the current state of the specified object.
        /// If the object's state is nonsignaled, the calling thread enters the wait state until the object is signaled or the time-out interval elapses.
        /// The function modifies the state of some types of synchronization objects.
        /// Modification occurs only for the object whose signaled state caused the function to return.
        /// For example, the count of a semaphore object is decreased by one.
        /// The <see cref="WaitForSingleObject"/> function can wait for the following objects:
        /// Change notification, Console input, Event, Memory resource notification, Mutex, Process, Semaphore, Thread, Waitable timer
        /// Use caution when calling the wait functions and code that directly or indirectly creates windows.
        /// If a thread creates any windows, it must process messages.
        /// Message broadcasts are sent to all windows in the system.
        /// A thread that uses a wait function with no time-out interval may cause the system to become deadlocked.
        /// Two examples of code that indirectly creates windows are DDE and the <see cref="CoInitialize"/> function.
        /// Therefore, if you have a thread that creates windows, use <see cref="MsgWaitForMultipleObjects"/> or <see cref="MsgWaitForMultipleObjectsEx"/>,
        /// rather than <see cref="WaitForSingleObject"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WaitForSingleObject", ExactSpelling = true, SetLastError = true)]
        public static extern WaitResult WaitForSingleObject([In] HANDLE hHandle, [In] DWORD dwMilliseconds);

        /// <summary>
        /// <para>
        /// Waits until the specified object is in the signaled state,
        /// an I/O completion routine or asynchronous procedure call (APC) is queued to the thread, or the time-out interval elapses.
        /// To wait for multiple objects, use the WaitForMultipleObjectsEx.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-waitforsingleobjectex"/>
        /// </para>
        /// </summary>
        /// <param name="hHandle">
        /// A handle to the object. 
        /// For a list of the object types whose handles can be specified, see the following Remarks section.
        /// If this handle is closed while the wait is still pending, the function's behavior is undefined.
        /// The handle must have the <see cref="SYNCHRONIZE"/> access right.
        /// For more information, see Standard Access Rights.
        /// </param>
        /// <param name="dwMilliseconds">
        /// The time-out interval, in milliseconds.
        /// If a nonzero value is specified, the function waits until the object is signaled,
        /// an I/O completion routine or APC is queued, or the interval elapses.
        /// If <paramref name="dwMilliseconds"/> is zero, the function does not enter a wait state if the criteria is not met;
        /// it always returns immediately.
        /// If <paramref name="dwMilliseconds"/> is <see cref="INFINITE"/>,
        /// the function will return only when the object is signaled or an I/O completion routine or APC is queued.
        /// </param>
        /// <param name="bAlertable">
        /// If this parameter is <see langword="true"/> and the thread is in the waiting state,
        /// the function returns when the system queues an I/O completion routine or APC, and the thread runs the routine or function.
        /// Otherwise, the function does not return, and the completion routine or APC function is not executed.
        /// A completion routine is queued when the <see cref="ReadFileEx"/> or <see cref="WriteFileEx"/> function in which it was specified has completed.
        /// The wait function returns and the completion routine is called only if <paramref name="bAlertable"/> is <see langword="true"/>,
        /// and the calling thread is the thread that initiated the read or write operation.
        /// An APC is queued when you call <see cref="QueueUserAPC"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value indicates the event that caused the function to return.
        /// It can be one of the following values.
        /// <see cref="WAIT_ABANDONED"/>:
        /// The specified object is a mutex object that was not released by the thread that owned the mutex object before the owning thread terminated.
        /// Ownership of the mutex object is granted to the calling thread and the mutex is set to nonsignaled.
        /// If the mutex was protecting persistent state information, you should check it for consistency.
        /// <see cref="WAIT_IO_COMPLETION"/>:
        /// The wait was ended by one or more user-mode asynchronous procedure calls (APC) queued to the thread.
        /// <see cref="WAIT_OBJECT_0"/>:
        /// The state of the specified object is signaled.
        /// <see cref="WAIT_TIMEOUT"/>:
        /// The time-out interval elapsed, and the object's state is nonsignaled.
        /// <see cref="WAIT_FAILED"/>:
        /// The function has failed.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="WaitForSingleObjectEx"/> function determines whether the wait criteria have been met.
        /// If the criteria have not been met, the calling thread enters the wait state until the conditions of the wait criteria
        /// have been met or the time-out interval elapses.
        /// The function modifies the state of some types of synchronization objects.
        /// Modification occurs only for the object whose signaled state caused the function to return.
        /// For example, the count of a semaphore object is decreased by one.
        /// The WaitForSingleObjectEx function can wait for the following objects:
        /// Change notification, Console input, Event, Memory resource notification, Mutex, Process, Semaphore, Thread, Waitable timer
        /// Use caution when calling the wait functions and code that directly or indirectly creates windows.
        /// If a thread creates any windows, it must process messages.
        /// Message broadcasts are sent to all windows in the system.
        /// A thread that uses a wait function with no time-out interval may cause the system to become deadlocked.
        /// Two examples of code that indirectly creates windows are DDE and the <see cref="CoInitialize"/> function.
        /// Therefore, if you have a thread that creates windows, use <see cref="MsgWaitForMultipleObjects"/> or
        /// <see cref="MsgWaitForMultipleObjectsEx"/>, rather than <see cref="WaitForSingleObjectEx"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WaitForSingleObjectEx", ExactSpelling = true, SetLastError = true)]
        public static extern WaitResult WaitForSingleObjectEx([In] HANDLE hHandle, [In] DWORD dwMilliseconds, [In] BOOL bAlertable);

        /// <summary>
        /// <para>
        /// Wake all threads waiting on the specified condition variable.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-wakeallconditionvariable"/>
        /// </para>
        /// </summary>
        /// <param name="ConditionVariable">
        /// A pointer to the condition variable.
        /// </param>
        /// <remarks>
        /// The <see cref="WakeAllConditionVariable"/> wakes all waiting threads while the <see cref="WakeConditionVariable"/> wakes only a single thread.
        /// Waking one thread is similar to setting an auto-reset event, while waking all threads is similar to pulsing a manual reset event
        /// but more reliable (see <see cref="PulseEvent"/> for details).
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WakeAllConditionVariable", ExactSpelling = true, SetLastError = true)]
        public static extern void WakeAllConditionVariable([In][Out] ref CONDITION_VARIABLE ConditionVariable);

        /// <summary>
        /// <para>
        /// Wake a single thread waiting on the specified condition variable.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-wakeconditionvariable"/>
        /// </para>
        /// </summary>
        /// <param name="ConditionVariable">
        /// A pointer to the condition variable.
        /// </param>
        /// <remarks>
        /// The <see cref="WakeAllConditionVariable"/> wakes all waiting threads while the <see cref="WakeConditionVariable"/> wakes only a single thread.
        /// Waking one thread is similar to setting an auto-reset event, while waking all threads is similar to pulsing a manual reset event
        /// but more reliable (see <see cref="PulseEvent"/> for details).
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WakeConditionVariable", ExactSpelling = true, SetLastError = true)]
        public static extern void WakeConditionVariable([In][Out] ref CONDITION_VARIABLE ConditionVariable);
    }
}
