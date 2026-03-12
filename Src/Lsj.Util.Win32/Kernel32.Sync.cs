using Lsj.Util.Win32.Attributes;
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
using static Lsj.Util.Win32.Enums.WorkThreadFlags;
using static Lsj.Util.Win32.Ole32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// An application-defined completion routine.
        /// Specify this address when calling the <see cref="QueueUserAPC"/> function.
        /// The <see cref="PAPCFUNC"/> type defines a pointer to this callback function.
        /// <c>APCProc</c> is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/nc-winnt-papcfunc"/>
        /// </para>
        /// </summary>
        /// <param name="Parameter">
        /// he data passed to the function using the <c>dwData</c> parameter of the <see cref="QueueUserAPC"/> function.
        /// </param>
        public delegate void Papcfunc(ULONG_PTR Parameter);

        /// <summary>
        /// <para>
        /// An application-defined callback function.
        /// Specify a pointer to this function when calling the <see cref="InitOnceExecuteOnce"/> function.
        /// The <see cref="PINIT_ONCE_FN"/> type defines a pointer to this callback function.
        /// <c>InitOnceCallback</c> is a placeholder for the application-defined function name.
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
        /// If <paramref name="Context"/> references a value, the low-order <see cref="INIT_ONCE_CTX_RESERVED_BITS"/> of the value must be zero.
        /// If <paramref name="Context"/> points to a data structure, the data structure must be <see cref="DWORD"/>-aligned. 
        /// <paramref name="Context"/> must not be a code pointer on Arm32,
        /// because Arm32 code pointers always have the least significant bit set, see the Arm32 ABI for details.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function returns <see cref="TRUE"/>, the block is marked as initialized.
        /// </para>
        /// <para>
        /// If the function returns <see cref="FALSE"/>,
        /// the block is not marked as initialized and the call to <see cref="InitOnceExecuteOnce"/> fails.
        /// To communicate additional error information, call <see cref="SetLastError"/> before returning <see cref="FALSE"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// This function can create a synchronization object and return it in the <paramref name="Context"/> parameter.
        /// </remarks>
        public delegate BOOL PinitOnceFn([In][Out] ref INIT_ONCE InitOnce, [In] PVOID Parameter, [Out] out PVOID Context);

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
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "AcquireSRWLockExclusive", ExactSpelling = true)]
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
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "AcquireSRWLockShared", ExactSpelling = true)]
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
        /// <para>
        /// Deleting a critical section object releases all system resources used by the object.
        /// The caller is responsible for ensuring that the critical section object is unowned
        /// and the specified <see cref="CRITICAL_SECTION"/> structure is not being accessed
        /// by any critical section functions called by other threads in the process.
        /// </para>
        /// <para>
        /// After a critical section object has been deleted, do not reference the object in any function that operates on critical sections
        /// (such as <see cref="EnterCriticalSection"/>, <see cref="TryEnterCriticalSection"/>, and <see cref="LeaveCriticalSection"/>)
        /// other than <see cref="InitializeCriticalSection"/> and <see cref="InitializeCriticalSectionAndSpinCount"/>.
        /// If you attempt to do so, memory corruption and other unexpected errors can occur.
        /// </para>
        /// <para>
        /// If a critical section is deleted while it is still owned,
        /// the state of the threads waiting for ownership of the deleted critical section is undefined.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteCriticalSection", ExactSpelling = true)]
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
        /// <para>
        /// <see cref="DeleteSynchronizationBarrier"/> releases a synchronization barrier when it is no longer needed.
        /// It is safe to call <see cref="DeleteSynchronizationBarrier"/> immediately after calling <see cref="EnterSynchronizationBarrier"/>
        /// because that function ensures that all threads in the barrier have finished using it before allowing the barrier to be released.
        /// </para>
        /// <para>
        /// If a synchronization barrier will never be deleted,
        /// threads can specify the <see cref="SYNCHRONIZATION_BARRIER_FLAGS_NO_DELETE"/> flag when they enter the barrier.
        /// This flag causes the function to skip the extra work required for deletion safety, which can improve performance.
        /// All threads using the barrier must specify this flag; if any thread does not, the flag is ignored.
        /// Be careful when using <see cref="SYNCHRONIZATION_BARRIER_FLAGS_NO_DELETE"/>,
        /// because deleting a barrier while this flag is in effect may result in an invalid handle access
        /// and cause one or more threads to become permanently blocked.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteSynchronizationBarrier", ExactSpelling = true)]
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
        /// <para>
        /// This function does not return a value.
        /// </para>
        /// <para>
        /// This function can raise <see cref="EXCEPTION_POSSIBLE_DEADLOCK"/>, also known as <see cref="STATUS_POSSIBLE_DEADLOCK"/>,
        /// if a wait operation on the critical section times out.
        /// The timeout interval is specified by the following registry value:
        /// <c>HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\CriticalSectionTimeout</c>
        /// Do not handle a possible deadlock exception; instead, debug the application.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The threads of a single process can use a critical section object for mutual-exclusion synchronization.
        /// The process is responsible for allocating the memory used by a critical section object,
        /// which it can do by declaring a variable of type <see cref="CRITICAL_SECTION"/>.
        /// Before using a critical section, some thread of the process must call
        /// <see cref="InitializeCriticalSection"/> or <see cref="InitializeCriticalSectionAndSpinCount"/> to initialize the object.
        /// </para>
        /// <para>
        /// To enable mutually exclusive access to a shared resource,
        /// each thread calls the <see cref="EnterCriticalSection"/> or <see cref="TryEnterCriticalSection"/> function
        /// to request ownership of the critical section before executing any section of code that accesses the protected resource.
        /// The difference is that <see cref="TryEnterCriticalSection"/> returns immediately,
        /// regardless of whether it obtained ownership of the critical section,
        /// while <see cref="EnterCriticalSection"/> blocks until the thread can take ownership of the critical section.
        /// When it has finished executing the protected code, the thread uses the <see cref="LeaveCriticalSection"/> function to relinquish ownership,
        /// enabling another thread to become owner and access the protected resource.
        /// There is no guarantee about the order in which waiting threads will acquire ownership of the critical section.
        /// </para>
        /// <para>
        /// After a thread has ownership of a critical section,
        /// it can make additional calls to <see cref="EnterCriticalSection"/> or <see cref="TryEnterCriticalSection"/> without blocking its execution.
        /// This prevents a thread from deadlocking itself while waiting for a critical section that it already owns.
        /// The thread enters the critical section each time <see cref="EnterCriticalSection"/> and <see cref="TryEnterCriticalSection"/> succeed.
        /// A thread must call <see cref="LeaveCriticalSection"/> once for each time that it entered the critical section.
        /// </para>
        /// <para>
        /// Any thread of the process can use the <see cref="DeleteCriticalSection"/> function
        /// to release the system resources that were allocated when the critical section object was initialized.
        /// After this function has been called, the critical section object can no longer be used for synchronization.
        /// </para>
        /// <para>
        /// If a thread terminates while it has ownership of a critical section, the state of the critical section is undefined.
        /// </para>
        /// <para>
        /// If a critical section is deleted while it is still owned,
        /// the state of the threads waiting for ownership of the deleted critical section is undefined.
        /// </para>
        /// <para>
        /// While a process is exiting, if a call to <see cref="EnterCriticalSection"/> would block,
        /// it will instead terminate the process immediately.
        /// This may cause global destructors to not be called.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnterCriticalSection", ExactSpelling = true)]
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
        /// <para>
        /// Flags that control the behavior of threads that enter this barrier.
        /// This parameter can be one or more of the following values:
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="SYNCHRONIZATION_BARRIER_FLAGS_BLOCK_ONLY"/>
        /// </term>
        /// <term>
        /// Specifies that the thread entering the barrier should block immediately until the last thread enters the barrier.
        /// For more information, see Remarks.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SYNCHRONIZATION_BARRIER_FLAGS_SPIN_ONLY"/>
        /// </term>
        /// <term>
        /// Specifies that the thread entering the barrier should spin until the last thread enters the barrier,
        /// even if the spinning thread exceeds the barrier's maximum spin count.
        /// For more information, see Remarks.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SYNCHRONIZATION_BARRIER_FLAGS_NO_DELETE"/>
        /// </term>
        /// <term>
        /// Specifies that the function can skip the work required to ensure that it is safe to delete the barrier, which can improve performance.
        /// All threads that enter this barrier must specify the flag; otherwise, the flag is ignored.
        /// This flag should be used only if the barrier will never be deleted.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <see cref="TRUE"/> for the last thread to signal the barrier.
        /// Threads that signal the barrier before the last thread signals it receive a return value of <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The default behavior for threads entering a synchronization barrier is to spin
        /// until the maximum spin count of the barrier is reached, and then block.
        /// This allows threads to resume quickly if the last thread enters the barrier in a relatively short time.
        /// However, if the last thread takes relatively longer to arrive, threads already in the barrier block
        /// so they stop consuming processor time while waiting.
        /// </para>
        /// <para>
        /// A thread can override the default behavior of the barrier
        /// by specifying <see cref="SYNCHRONIZATION_BARRIER_FLAGS_BLOCK_ONLY"/> or <see cref="SYNCHRONIZATION_BARRIER_FLAGS_SPIN_ONLY"/>.
        /// However, keep in mind that using these flags can affect performance.
        /// Spinning indefinitely keeps a processor from servicing other threads,
        /// while premature blocking incurs the overhead of swapping the thread off the processor,
        /// awakening the thread when it unblocks, and swapping it back onto the processor again.
        /// In general it is better to allow the barrier to manage threads and use these flags
        /// only if performance testing indicates the application would benefit from them.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnterSynchronizationBarrier", ExactSpelling = true)]
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
        /// <para>
        /// Threads can atomically release a lock and enter the sleeping state
        /// using the <see cref="SleepConditionVariableCS"/> or <see cref="SleepConditionVariableSRW"/> function.
        /// The threads are woken using the <see cref="WakeConditionVariable"/> or <see cref="WakeAllConditionVariable"/> function.
        /// </para>
        /// <para>
        /// Condition variables are user-mode objects that cannot be shared across processes.
        /// </para>
        /// <para>
        /// A condition variable cannot be moved or copied while in use.
        /// The process must not modify the object, and must instead treat it as logically opaque.
        /// Only use the condition variable functions to manage condition variables.
        /// </para>
        /// <para>
        /// A condition variable with no waiting threads is in its initial stat
        /// e and can be copied, moved, and forgotten without being explicitly destroyed.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitializeConditionVariable", ExactSpelling = true)]
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
        /// <para>
        /// This function does not return a value.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP:
        /// In low memory situations, <see cref="InitializeCriticalSection"/> can raise a <see cref="STATUS_NO_MEMORY"/> exception.
        /// Starting with Windows Vista, this exception was eliminated
        /// and <see cref="InitializeCriticalSection"/> always succeeds, even in low memory situations.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The threads of a single process can use a critical section object for mutual-exclusion synchronization.
        /// There is no guarantee about the order in which threads will obtain ownership of the critical section,
        /// however, the system will be fair to all threads.
        /// </para>
        /// <para>
        /// The process is responsible for allocating the memory used by a critical section object,
        /// which it can do by declaring a variable of type <see cref="CRITICAL_SECTION"/>.
        /// Before using a critical section, some thread of the process must initialize the object.
        /// </para>
        /// <para>
        /// After a critical section object has been initialized, the threads of the process can specify the object
        /// in the <see cref="EnterCriticalSection"/>, <see cref="TryEnterCriticalSection"/>, or <see cref="LeaveCriticalSection"/> function
        /// to provide mutually exclusive access to a shared resource.
        /// For similar synchronization between the threads of different processes, use a mutex object.
        /// </para>
        /// <para>
        /// A critical section object cannot be moved or copied.
        /// The process must also not modify the object, but must treat it as logically opaque.
        /// Use only the critical section functions to manage critical section objects.
        /// When you have finished using the critical section, call the <see cref="DeleteCriticalSection"/> function.
        /// </para>
        /// <para>
        /// A critical section object must be deleted before it can be reinitialized.
        /// Initializing a critical section that has already been initialized results in undefined behavior.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitializeCriticalSection", ExactSpelling = true)]
        public static extern void InitializeCriticalSection([In][Out] ref CRITICAL_SECTION lpCriticalSection);

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
        /// <para>
        /// This function always succeeds and returns a nonzero value.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP:
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero <c>0</c>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// Starting with Windows Vista, the <see cref="InitializeCriticalSectionAndSpinCount"/> function always succeeds,
        /// even in low memory situations.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The threads of a single process can use a critical section object for mutual-exclusion synchronization.
        /// There is no guarantee about the order that threads obtain ownership of the critical section.
        /// However, the system is fair to all threads.
        /// </para>
        /// <para>
        /// The process is responsible for allocating the memory used by a critical section object,
        /// which it can do by declaring a variable of type <see cref="CRITICAL_SECTION"/>.
        /// Before using a critical section, some thread of the process must initialize the object.
        /// You can subsequently modify the spin count by calling the <see cref="SetCriticalSectionSpinCount"/> function.
        /// </para>
        /// <para>
        /// After a critical section object is initialized, the threads of the process can specify the object
        /// in the <see cref="EnterCriticalSection"/>, <see cref="TryEnterCriticalSection"/>,
        /// or <see cref="LeaveCriticalSection"/> function to provide mutually exclusive access to a shared resource.
        /// For similar synchronization between the threads of different processes, use a mutex object.
        /// </para>
        /// <para>
        /// A critical section object cannot be moved or copied.
        /// The process must also not modify the object, but must treat it as logically opaque.
        /// Use only the critical section functions to manage critical section objects.
        /// When you have finished using the critical section, call the <see cref="DeleteCriticalSection"/> function.
        /// </para>
        /// <para>
        /// A critical section object must be deleted before it can be reinitialized.
        /// Initializing a critical section that is already initialized results in undefined behavior.
        /// </para>
        /// <para>
        /// The spin count is useful for critical sections of short duration that can experience high levels of contention.
        /// Consider a worst-case scenario, in which an application
        /// on an SMP system has two or three threads constantly allocating and releasing memory from the heap.
        /// The application serializes the heap with a critical section.
        /// In the worst-case scenario, contention for the critical section is constant,
        /// and each thread makes a processing-intensive call to the <see cref="WaitForSingleObject"/> function.
        /// However, if the spin count is set properly,
        /// the calling thread does not immediately call <see cref="WaitForSingleObject"/> when contention occurs.
        /// Instead, the calling thread can acquire ownership of the critical section if it is released during the spin operation.
        /// </para>
        /// <para>
        /// You can improve performance significantly by choosing a small spin count for a critical section of short duration.
        /// For example, the heap manager uses a spin count of roughly 4,000 for its per-heap critical sections.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
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
        /// <para>
        /// This parameter can be 0 or the following value.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="CRITICAL_SECTION_NO_DEBUG_INFO"/>
        /// </term>
        /// <term>
        /// The critical section is created without debug information.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero (0).
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The threads of a single process can use a critical section object for mutual-exclusion synchronization.
        /// There is no guarantee about the order that threads obtain ownership of the critical section,
        /// however, the system is fair to all threads.
        /// </para>
        /// <para>
        /// The process is responsible for allocating the memory used by a critical section object,
        /// which it can do by declaring a variable of type <see cref="CRITICAL_SECTION"/>.
        /// Before using a critical section, some thread of the process must initialize the object.
        /// You can subsequently modify the spin count by calling the <see cref="SetCriticalSectionSpinCount"/> function.
        /// </para>
        /// <para>
        /// After a critical section object is initialized, the threads of the process can specify the object
        /// in the <see cref="EnterCriticalSection"/>, <see cref="TryEnterCriticalSection"/>,
        /// or <see cref="LeaveCriticalSection"/> function to provide mutually exclusive access to a shared resource.
        /// For similar synchronization between the threads of different processes, use a mutex object.
        /// </para>
        /// <para>
        /// A critical section object cannot be moved or copied.
        /// The process must also not modify the object, but must treat it as logically opaque.
        /// Use only the critical section functions to manage critical section objects.
        /// When you have finished using the critical section, call the <see cref="DeleteCriticalSection"/> function.
        /// </para>
        /// <para>
        /// A critical section object must be deleted before it can be reinitialized.
        /// Initializing a critical section that is already initialized results in undefined behavior.
        /// </para>
        /// <para>
        /// The spin count is useful for critical sections of short duration that can experience high levels of contention.
        /// Consider a worst-case scenario, in which an application
        /// on an SMP system has two or three threads constantly allocating and releasing memory from the heap.
        /// The application serializes the heap with a critical section.
        /// In the worst-case scenario, contention for the critical section is constant,
        /// and each thread makes a processing-intensive call to the <see cref="WaitForSingleObject"/> function.
        /// However, if the spin count is set properly,
        /// the calling thread does not immediately call <see cref="WaitForSingleObject"/> when contention occurs.
        /// Instead, the calling thread can acquire ownership of the critical section if it is released during the spin operation.
        /// </para>
        /// <para>
        /// You can improve performance significantly by choosing a small spin count for a critical section of short duration.
        /// The heap manager uses a spin count of roughly 4000 for its per-heap critical sections.
        /// This gives great performance and scalability in almost all worst-case scenarios.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitializeCriticalSectionEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL InitializeCriticalSectionEx([In][Out] ref CRITICAL_SECTION lpCriticalSection, [In] DWORD dwSpinCount, [In] DWORD Flags);

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
        /// <para>
        /// All list items must be aligned on a <c>MEMORY_ALLOCATION_ALIGNMENT</c> boundary.
        /// Unaligned items can cause unpredictable results. See <c>_aligned_malloc</c>.
        /// </para>
        /// <para>
        /// To add items to the list, use the <see cref="InterlockedPushEntrySList"/> function.
        /// To remove items from the list, use the <see cref="InterlockedPopEntrySList"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitializeSListHead", ExactSpelling = true)]
        public static extern void InitializeSListHead([In][Out] ref SLIST_HEADER ListHead);

        /// <summary>
        /// <para>
        /// Initialize a slim reader/writer (SRW) lock.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-initializesrwlock"/>
        /// </para>
        /// </summary>
        /// <param name="SRWLock">
        /// A pointer to the SRW lock.
        /// </param>
        /// <remarks>
        /// <para>
        /// An SRW lock must be initialized before it is used.
        /// The <see cref="InitializeSRWLock"/> function is used to initialize a SRW lock dynamically.
        /// To initialize the structure statically, assign the constant <see cref="SRWLOCK_INIT"/> to the structure variable.
        /// </para>
        /// <para>
        /// An SRW lock cannot be moved or copied while in use.
        /// The process must not modify the object, and must instead treat it as logically opaque.
        /// Only use the SRW functions to manage SRW locks.
        /// </para>
        /// <para>
        /// An unlocked SRW lock with no waiting threads is in its initial state and can be copied, moved, and forgotten without being explicitly destroyed.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitializeSRWLock", ExactSpelling = true)]
        public static extern void InitializeSRWLock([In][Out] ref SRWLOCK SRWLock);

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
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitializeSynchronizationBarrier", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL InitializeSynchronizationBarrier([Out] out SYNCHRONIZATION_BARRIER lpBarrier, [In] LONG lTotalThreads, [In] LONG lSpinCount);

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
        /// <para>
        /// This parameter can have a value of 0, or one or more of the following flags.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="INIT_ONCE_ASYNC"/>
        /// </para>
        /// <para>
        /// 0x00000002UL
        /// </para>
        /// </term>
        /// <term>
        /// Enables multiple initialization attempts to execute in parallel.
        /// If this flag is used, subsequent calls to this function will fail unless this flag is also specified.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="INIT_ONCE_CHECK_ONLY"/>
        /// </para>
        /// <para>
        /// 0x00000001UL
        /// </para>
        /// </term>
        /// <term>
        /// This function call does not begin initialization.
        /// The return value indicates whether initialization has already completed.
        /// If the function returns <see cref="TRUE"/>, the <paramref name="lpContext"/> parameter receives the data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="fPending">
        /// <para>
        /// If the function succeeds, this parameter indicates the current initialization status.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="TRUE"/> and <paramref name="dwFlags"/> contains <see cref="INIT_ONCE_CHECK_ONLY"/>,
        /// the initialization is pending and the context data is invalid.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="FALSE"/>, initialization has already completed
        /// and the caller can retrieve the context data from the <paramref name="lpContext"/> parameter.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="TRUE"/> and <paramref name="dwFlags"/> does not contain <see cref="INIT_ONCE_CHECK_ONLY"/>,
        /// initialization has been started and the caller can perform the initialization tasks.
        /// </para>
        /// </param>
        /// <param name="lpContext">
        /// An optional parameter that receives the data stored with the one-time initialization structure upon success.
        /// The low-order <see cref="INIT_ONCE_CTX_RESERVED_BITS"/> bits of the data are always zero.
        /// </param>
        /// <returns>
        /// <para>
        /// If <see cref="INIT_ONCE_CHECK_ONLY"/> is not specified and the function succeeds, the return value is <see cref="TRUE"/>.
        /// </para>
        /// <para>
        /// If <see cref="INIT_ONCE_CHECK_ONLY"/> is specified and initialization has completed, the return value is <see cref="TRUE"/>.
        /// </para>
        /// <para>
        /// Otherwise, the return value is <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function can be used for either synchronous or asynchronous one-time initialization.
        /// For asynchronous one-time initialization, use the <see cref="INIT_ONCE_ASYNC"/> flag.
        /// To specify a callback function to execute during synchronous one-time initialization,
        /// see the <see cref="InitOnceExecuteOnce"/> function.
        /// </para>
        /// <para>
        /// If this function succeeds, the thread can create a synchronization object
        /// and specify in the <paramref name="lpContext"/> parameter of the <see cref="InitOnceComplete"/> function.
        /// </para>
        /// <para>
        /// A one-time initialization object cannot be moved or copied.
        /// The process must not modify the initialization object, and must instead treat it as logically opaque.
        /// Only use the one-time initialization functions to manage one-time initialization objects.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitOnceBeginInitialize", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL InitOnceBeginInitialize([In][Out] ref INIT_ONCE lpInitOnce, [In] InitOnceFlags dwFlags,
            [Out] out BOOL fPending, [Out] out LPVOID lpContext);

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
        /// <para>
        /// This parameter can be one of the following flags.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="INIT_ONCE_ASYNC"/>
        /// </para>
        /// <para>
        /// 0x00000002UL
        /// </para>
        /// </term>
        /// <term>
        /// Operate in asynchronous mode.
        /// This enables multiple completion attempts to execute in parallel.
        /// This flag must match the flag passed in the corresponding call to the <see cref="InitOnceBeginInitialize"/> function.
        /// This flag may not be combined with <see cref="INIT_ONCE_INIT_FAILED"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="INIT_ONCE_INIT_FAILED"/>
        /// </para>
        /// <para>
        /// 0x00000004UL
        /// </para>
        /// </term>
        /// <term>
        /// The initialization attempt failed.
        /// This flag may not be combined with <see cref="INIT_ONCE_ASYNC"/>.
        /// To fail an asynchronous initialization, merely abandon it (that is, do not call the <see cref="InitOnceComplete"/> function).
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpContext">
        /// A pointer to the data to be stored with the one-time initialization structure.
        /// This data is returned in the lpContext parameter passed to subsequent calls to the <see cref="InitOnceBeginInitialize"/> function.
        /// If <paramref name="lpContext"/> points to a value, the low-order <see cref="INIT_ONCE_CTX_RESERVED_BITS"/> of the value must be zero.
        /// If <paramref name="lpContext"/> points to a data structure, the data structure must be DWORD-aligned.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitOnceComplete", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL InitOnceComplete([In][Out] ref INIT_ONCE lpInitOnce, [In] DWORD dwFlags, [In] LPVOID lpContext);

        /// <summary>
        /// <para>
        /// When multiple threads call <see cref="InitOnceExecuteOnce"/> passing the same one-time initialization block,
        /// only one thread will execute the callback function specified by <paramref name="InitFn"/>.
        /// The remaining threads will block until the callback function completes.
        /// If the callback function returns <see cref="TRUE"/> to indicate success,
        /// <see cref="InitOnceExecuteOnce"/> will return <see cref="TRUE"/> back to all callers at once.
        /// If, however, the callback returns <see cref="FALSE"/> to indicate failure,
        /// <see cref="InitOnceExecuteOnce"/> will return <see cref="FALSE"/> to only the single thread which executed the callback function.
        /// At this same time one of the remaining blocked threads will unblock and execute <paramref name="InitFn"/> once again.
        /// Thus, in a scenario where <paramref name="InitFn"/> can fail intermittently and retries are desired,
        /// all threads should continue calling <see cref="InitOnceExecuteOnce"/> until <see cref="TRUE"/> is returned.
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
        /// If <paramref name="lpContext"/> points to a data structure, the data structure must be <see cref="DWORD"/>-aligned.
        /// <paramref name="lpContext"/> must not be a code pointer on Arm32,
        /// because Arm32 code pointers always have the least significant bit set, see the Arm32 ABI for details.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function is used for synchronous one-time initialization.
        /// For asynchronous one-time initialization,
        /// use the <see cref="InitOnceBeginInitialize"/> function with the <see cref="INIT_ONCE_ASYNC"/> flag.
        /// </para>
        /// <para>
        /// Only one thread at a time can execute the callback function specified by <paramref name="InitFn"/>.
        /// Other threads that specify the same one-time initialization structure block until the callback finishes.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitOnceExecuteOnce", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL InitOnceExecuteOnce([In][Out] ref INIT_ONCE lpInitOnce, [In] PINIT_ONCE_FN InitFn,
            [In] PVOID Parameter, [Out] out LPVOID lpContext);

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
        /// <para>
        /// The <see cref="InitOnceInitialize"/> function is used to initialize a one-time initialization structure dynamically.
        /// To initialize the structure statically, assign the constant <see cref="INIT_ONCE_STATIC_INIT"/> to the structure variable.
        /// </para>
        /// <para>
        /// A one-time initialization object cannot be moved or copied.
        /// The process must not modify the initialization object, and must instead treat it as logically opaque.
        /// Only use the one-time initialization functions to manage one-time initialization objects.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitOnceInitialize", ExactSpelling = true)]
        public static extern void InitOnceInitialize([Out] out Structs.INIT_ONCE InitOnce);

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
        /// All list items must be aligned on a <c>MEMORY_ALLOCATION_ALIGNMENT</c> boundary;
        /// otherwise, this function will behave unpredictably. See <c>_aligned_malloc</c>.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InterlockedFlushSList", ExactSpelling = true)]
        public static extern PSLIST_ENTRY InterlockedFlushSList([In][Out] ref SLIST_HEADER ListHead);

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
        /// All list items must be aligned on a <c>MEMORY_ALLOCATION_ALIGNMENT</c> boundary; otherwise, this function will behave unpredictably.
        /// See <c>_aligned_malloc</c>.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InterlockedPopEntrySList", ExactSpelling = true)]
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
        /// All list items must be aligned on a <c>MEMORY_ALLOCATION_ALIGNMENT</c> boundary; otherwise, this function will behave unpredictably.
        /// See <c>_aligned_malloc</c>.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InterlockedPushEntrySList", ExactSpelling = true)]
        public static extern PSLIST_ENTRY InterlockedPushEntrySList([In][Out] ref SLIST_HEADER ListHead, [In] PSLIST_ENTRY ListEntry);

        /// <summary>
        /// <para>
        /// Inserts a singly-linked list at the front of another singly linked list.
        /// </para>
        /// <para>
        /// Access to the lists is synchronized on a multiprocessor system.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/sync/interlockedpushlistslist"/>
        /// </para>
        /// </summary>
        /// <param name="ListHead">
        /// Pointer to an <see cref="SLIST_HEADER"/> structure that represents the head of a singly linked list.
        /// The list specified by the <paramref name="List"/> and <paramref name="ListEnd"/> parameters
        /// is inserted at the front of this list.
        /// </param>
        /// <param name="List">
        /// Pointer to an <c>SLIST_ENTRY</c> structure that represents the first item in the list to be inserted.
        /// </param>
        /// <param name="ListEnd">
        /// Pointer to an <c>SLIST_ENTRY</c> structure that represents the last item in the list to be inserted.
        /// </param>
        /// <param name="Count">
        /// The number of items in the list to be inserted.
        /// </param>
        /// <returns>
        /// The return value is the previous first item in the list specified by the <paramref name="ListHead"/> parameter.
        /// If the list was previously empty, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// All list items must be aligned on a <see cref="MEMORY_ALLOCATION_ALIGNMENT"/> boundary;
        /// otherwise, this function will behave unpredictably.
        /// See <c>_aligned_malloc</c>.
        /// </para>
        /// <para>
        /// Windows 8 and Windows Server 2012: This function has been superceded by <see cref="InterlockedPushListSListEx"/>.
        /// </para>
        /// <para>
        /// When compiling with <c>NTDDI_VERSION</c> set to <c>NTDDI_WIN8</c> or greater,
        /// calls to <see cref="InterlockedPushListSList"/> will go to <see cref="InterlockedPushListSListEx"/> instead.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InterlockedPushListSList", ExactSpelling = true)]
        public static extern PSLIST_ENTRY InterlockedPushListSList([In][Out] ref SLIST_HEADER ListHead,
            [In] PSLIST_ENTRY List, [In] PSLIST_ENTRY ListEnd, [In] ULONG Count);

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
        /// <para>
        /// The threads of a single process can use a critical-section object for mutual-exclusion synchronization.
        /// The process is responsible for allocating the memory used by a critical-section object,
        /// which it can do by declaring a variable of type <see cref="CRITICAL_SECTION"/>.
        /// Before using a critical section, some thread of the process must call
        /// the <see cref="InitializeCriticalSection"/> or <see cref="InitializeCriticalSectionAndSpinCount"/> function to initialize the object.
        /// </para>
        /// <para>
        /// A thread uses the <see cref="EnterCriticalSection"/> or <see cref="TryEnterCriticalSection"/> function
        /// to acquire ownership of a critical section object.
        /// To release its ownership, the thread must call <see cref="LeaveCriticalSection"/> once
        /// for each time that it entered the critical section.
        /// </para>
        /// <para>
        /// If a thread calls <see cref="LeaveCriticalSection"/> when it does not have ownership of the specified critical section object,
        /// an error occurs that may cause another thread using <see cref="EnterCriticalSection"/> to wait indefinitely.
        /// </para>
        /// <para>
        /// <see cref="LeaveCriticalSection"/> does not access the specified <see cref="CRITICAL_SECTION"/> structure
        /// after the ownership of a critical section object is released.
        /// </para>
        /// <para>
        /// Any thread of the process can use the <see cref="DeleteCriticalSection"/> function to release the system resources
        /// that were allocated when the critical section object was initialized.
        /// After this function has been called, the critical section object can no longer be used for synchronization.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "LeaveCriticalSection", ExactSpelling = true)]
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
        /// <para>
        /// A pointer to an <see cref="SLIST_HEADER"/> structure that represents the head of a singly linked list.
        /// This structure is for system use only.
        /// </para>
        /// <para>
        /// The list must be previously initialized with the <see cref="InitializeSListHead"/> function.
        /// </para>
        /// </param>
        /// <returns>
        /// The function returns the number of entries in the list, up to a maximum value of 65535.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The system does not limit the number of entries in a singly linked list.
        /// However, the return value of <see cref="QueryDepthSList"/> is truncated to 16 bits,
        /// so the maximum value it can return is 65535.
        /// If the specified singly linked list contains more than 65535 entries,
        /// <see cref="QueryDepthSList"/> returns the number of entries in the list modulo 65535.
        /// For example, if the specified list contains 65536 entries, <see cref="QueryDepthSList"/> returns zero.
        /// </para>
        /// <para>
        /// The return value of <see cref="QueryDepthSList"/> should not be relied upon in multithreaded applications
        /// because the item count can be changed at any time by another thread.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "QueryDepthSList", ExactSpelling = true)]
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
        /// A pointer to the application-supplied APC function to be called
        /// when the specified thread performs an alertable wait operation.
        /// For more information, see <see cref="PAPCFUNC"/> callback function.
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
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// Windows Server 2003 and Windows XP:
        /// There are no error values defined for this function that can be retrieved by calling <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// See <see cref="QueueUserAPC2"/> function for information on special user-mode APCs.
        /// </para>
        /// <para>
        /// The APC support provided in the operating system allows an application to queue an APC object to a thread.
        /// To ensure successful execution of functions used by the APC,
        /// APCs should be queued only to threads in the caller's process.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Queuing APCs to threads outside the caller's process is not recommended for a number of reasons.
        /// DLL rebasing can cause the addresses of functions used by the APC to be incorrect
        /// when the functions are executed outside the caller's process.
        /// Similarly, if a 64-bit process queues an APC to a 32-bit process or vice versa,
        /// addresses will be incorrect and the application will crash.
        /// Other factors can prevent successful function execution, even if the address is known.
        /// </para>
        /// <para>
        /// Each thread has its own APC queue. The queuing of an APC is a request for the thread to call the APC function.
        /// The operating system issues a software interrupt to direct the thread to call the APC function.
        /// </para>
        /// <para>
        /// When a user-mode APC is queued, the thread is not directed to call the APC function unless it is in an alertable state.
        /// After the thread is in an alertable state, the thread handles all pending APCs
        /// in first in, first out (FIFO) order, and the wait operation returns <see cref="WAIT_IO_COMPLETION"/>.
        /// A thread enters an alertable state by using <see cref="SleepEx"/> function,
        /// <see cref="SignalObjectAndWait"/> function, <see cref="WaitForSingleObjectEx"/> function,
        /// <see cref="WaitForMultipleObjectsEx"/> function, or <see cref="MsgWaitForMultipleObjectsEx"/> function.
        /// </para>
        /// <para>
        /// If an application queues an APC before the thread begins running, the thread begins by calling the APC function.
        /// After the thread calls an APC function, it calls the APC functions for all APCs in its APC queue.
        /// </para>
        /// <para>
        /// It is possible to sleep or wait for an object within the APC.
        /// If you perform an alertable wait inside an APC, it will recursively dispatch the APCs.
        /// This can cause a stack overflow.
        /// </para>
        /// <para>
        /// When the thread is terminated using the <see cref="ExitThread"/> function or <see cref="TerminateThread"/> function function,
        /// the APCs in its APC queue are lost.
        /// The APC functions are not called.
        /// </para>
        /// <para>
        /// When the thread is in the process of being terminated,
        /// calling <see cref="QueueUserAPC"/> to add to the thread's APC queue will fail with (31) <see cref="ERROR_GEN_FAILURE"/>.
        /// </para>
        /// <para>
        /// Note that the <see cref="ReadFileEx"/> function, <see cref="SetWaitableTimer"/> function,
        /// and <see cref="WriteFileEx"/> function functions are implemented using an APC as the completion notification callback mechanism.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "QueueUserAPC", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD QueueUserAPC([In] PAPCFUNC pfnAPC, [In] HANDLE hThread, [In] ULONG_PTR dwData);

        /// <summary>
        /// <para>
        /// Directs a wait thread in the thread pool to wait on the object.
        /// The wait thread queues the specified callback function to the thread pool when one of the following occurs:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The specified object is in the signaled state.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The time-out interval elapses.
        /// </description>
        /// </item>
        /// </list>
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
        /// <para>
        /// A handle to the object.
        /// For a list of the object types whose handles can be specified, see the following Remarks section.
        /// </para>
        /// <para>
        /// Mutex is not supported.
        /// If a handle to a mutex is passed in, the thread pool raises a <see cref="STATUS_THREADPOOL_HANDLE_EXCEPTION"/> exception
        /// and <c>ExceptionRecord.ExceptionInformation[0]</c> will be equal to <see cref="STATUS_INVALID_PARAMETER_3"/>.
        /// </para>
        /// <para>
        /// If this handle is closed while the wait is still pending, the function's behavior is undefined.
        /// </para>
        /// <para>
        /// The handles must have the <see cref="SYNCHRONIZE"/> access right.
        /// For more information, see Standard Access Rights.
        /// </para>
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
        /// <para>
        /// This parameter can be one or more of the following values.
        /// </para>
        /// <para>
        /// For information about using these values with objects that remain signaled, see the Remarks section.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WT_EXECUTEDEFAULT"/>
        /// </para>
        /// <para>
        /// 0x00000000
        /// </para>
        /// </term>
        /// <term>
        /// By default, the callback function is queued to a non-I/O worker thread.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WT_EXECUTEINIOTHREAD"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// This flag is not used.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP:
        /// The callback function is queued to an I/O worker thread.
        /// This flag should be used if the function should be executed in a thread that waits in an alertable state.
        /// </para>
        /// <para>
        /// I/O worker threads were removed starting with Windows Vista and Windows Server 2008.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WT_EXECUTEINPERSISTENTTHREAD"/>
        /// </para>
        /// <para>
        /// 0x00000080
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The callback function is queued to a thread that never terminates.
        /// It does not guarantee that the same thread is used each time.
        /// This flag should be used only for short tasks or it could affect other wait operations.
        /// </para>
        /// <para>
        /// This flag must be set if the thread calls functions that use APCs.
        /// For more information, see Asynchronous Procedure Calls.
        /// </para>
        /// <para>
        /// Note that currently no worker thread is truly persistent,
        /// although no worker thread will terminate if there are any pending I/O requests.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WT_EXECUTEINWAITTHREAD"/>
        /// </para>
        /// <para>
        /// 0x00000004
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The callback function is invoked by the wait thread itself.
        /// This flag should be used only for short tasks or it could affect other wait operations.
        /// </para>
        /// <para>
        /// Deadlocks can occur if some other thread acquires an exclusive lock
        /// and calls the <see cref="UnregisterWait"/> or <see cref="UnregisterWaitEx"/> function
        /// while the callback function is trying to acquire the same lock.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WT_EXECUTELONGFUNCTION"/>
        /// </para>
        /// <para>
        /// 0x00000010
        /// </para>
        /// </term>
        /// <term>
        /// The callback function can perform a long wait.
        /// This flag helps the system to decide if it should create a new thread.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WT_EXECUTEONLYONCE"/>
        /// </para>
        /// <para>
        /// 0x00000008
        /// </para>
        /// </term>
        /// <term>
        /// The thread will no longer wait on the handle after the callback function has been called once.
        /// Otherwise, the timer is reset every time the wait operation completes until the wait operation is canceled.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WT_TRANSFER_IMPERSONATION"/>
        /// </para>
        /// <para>
        /// 0x00000100
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Callback functions will use the current access token, whether it is a process or impersonation token.
        /// If this flag is not specified, callback functions execute only with the process token.
        /// </para>
        /// <para>
        /// Windows XP: This flag is not supported until Windows XP with SP2 and Windows Server 2003.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// New wait threads are created automatically when required.
        /// The wait operation is performed by a wait thread from the thread pool.
        /// The callback routine is executed by a worker thread when the object's state becomes signaled or the time-out interval elapses.
        /// If <paramref name="dwFlags"/> is not <see cref="WT_EXECUTEONLYONCE"/>,
        /// the timer is reset every time the event is signaled or the time-out interval elapses.
        /// </para>
        /// <para>
        /// When the wait is completed, you must call the <see cref="UnregisterWait"/>
        /// or <see cref="UnregisterWaitEx"/> function to cancel the wait operation.
        /// (Even wait operations that use <see cref="WT_EXECUTEONLYONCE"/> must be canceled.)
        /// Do not make a blocking call to either of these functions from within the callback function.
        /// </para>
        /// <para>
        /// Note that you should not pulse an event object passed to <see cref="RegisterWaitForSingleObject"/>,
        /// because the wait thread might not detect that the event is signaled before it is reset.
        /// You should not register an object that remains signaled (such as a manual reset event or terminated process)
        /// unless you set the <see cref="WT_EXECUTEONLYONCE"/> or <see cref="WT_EXECUTEINWAITTHREAD"/> flag.
        /// For other flags, the callback function might be called too many times before the event is reset.
        /// </para>
        /// <para>
        /// The function modifies the state of some types of synchronization objects.
        /// Modification occurs only for the object whose signaled state caused the wait condition to be satisfied.
        /// For example, the count of a semaphore object is decreased by one.
        /// </para>
        /// <para>
        /// The <see cref="RegisterWaitForSingleObject"/> function can wait for the following objects:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Change notification
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Console input
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Event
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Memory resource notification
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Process
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Semaphore
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Thread
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Waitable timer
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// For more information, see Synchronization Objects.
        /// </para>
        /// <para>
        /// By default, the thread pool has a maximum of 500 threads.
        /// To raise this limit, use the <c>WT_SET_MAX_THREADPOOL_THREAD</c> macro defined in WinNT.h.
        /// </para>
        /// <code>
        /// #define WT_SET_MAX_THREADPOOL_THREADS(Flags,Limit) \
        /// ((Flags)|=(Limit)&lt;&lt;16)
        /// </code>
        /// <para>
        /// Use this macro when specifying the <paramref name="dwFlags"/> parameter.
        /// The macro parameters are the desired flags and the new limit (up to (2&lt;&lt;16)-1 threads).
        /// However, note that your application can improve its performance by keeping the number of worker threads low.
        /// </para>
        /// <para>
        /// The work item and all functions it calls must be thread-pool safe.
        /// Therefore, you cannot call an asynchronous call that requires a persistent thread,
        /// such as the <see cref="RegNotifyChangeKeyValue"/> function, from the default callback environment.
        /// Instead, set the thread pool maximum equal to the thread pool minimum
        /// using the <see cref="SetThreadpoolThreadMaximum"/> and <see cref="SetThreadpoolThreadMinimum"/> functions,
        /// or create your own thread using the <see cref="CreateThread"/> function.
        /// (For the original thread pool API, specify <see cref="WT_EXECUTEINPERSISTENTTHREAD"/> using the <see cref="QueueUserWorkItem"/> function.)
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegisterWaitForSingleObject", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL RegisterWaitForSingleObject([Out] out HANDLE phNewWaitObject, [In] HANDLE hObject, [In] WAITORTIMERCALLBACK Callback,
            [In] PVOID Context, [In] ULONG dwMilliseconds, [In] WorkThreadFlags dwFlags);

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
        /// <remarks>
        /// The SRW lock must be released by the same thread that acquired it.
        /// You can use Application Verifier to help verify that your program uses SRW locks correctly
        /// (enable Locks checker from Basic group).
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ReleaseSRWLockExclusive", ExactSpelling = true)]
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
        /// <remarks>
        /// The SRW lock must be released by the same thread that acquired it.
        /// You can use Application Verifier to help verify that your program uses SRW locks correctly
        /// (enable Locks checker from Basic group).
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
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
        /// <para>
        /// The threads of a single process can use a critical section object for mutual-exclusion synchronization.
        /// The process is responsible for allocating the memory used by a critical section object,
        /// which it can do by declaring a variable of type <see cref="CRITICAL_SECTION"/>.
        /// Before using a critical section, some thread of the process must call the <see cref="InitializeCriticalSection"/>
        /// or <see cref="InitializeCriticalSectionAndSpinCount"/> function to initialize the object.
        /// You can subsequently modify the spin count by calling the <see cref="SetCriticalSectionSpinCount"/> function.
        /// </para>
        /// <para>
        /// The spin count is useful for critical sections of short duration that can experience high levels of contention.
        /// Consider a worst-case scenario, in which an application
        /// on an SMP system has two or three threads constantly allocating and releasing memory from the heap.
        /// The application serializes the heap with a critical section.
        /// In the worst-case scenario, contention for the critical section is constant,
        /// and each thread makes a processing-intensive call to the <see cref="WaitForSingleObject"/> function.
        /// However, if the spin count is set properly,
        /// the calling thread does not immediately call <see cref="WaitForSingleObject"/> when contention occurs.
        /// Instead, the calling thread can acquire ownership of the critical section if it is released during the spin operation.
        /// </para>
        /// <para>
        /// You can improve performance significantly by choosing a small spin count for a critical section of short duration.
        /// The heap manager uses a spin count of roughly 4000 for its per-heap critical sections.
        /// This gives great performance and scalability in almost all worst-case scenarios.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetCriticalSectionSpinCount", ExactSpelling = true)]
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
        /// <para>
        /// A handle to the object to be signaled.
        /// This object can be a semaphore, a mutex, or an event.
        /// </para>
        /// <para>
        /// If the handle is a semaphore, the <see cref="SEMAPHORE_MODIFY_STATE"/> access right is required.
        /// If the handle is an event, the <see cref="EVENT_MODIFY_STATE"/> access right is required.
        /// If the handle is a mutex and the caller does not own the mutex, the function fails with <see cref="ERROR_NOT_OWNER"/>.
        /// </para>
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
        /// <para>
        /// If this parameter is <see cref="TRUE"/>, the function returns
        /// when the system queues an I/O completion routine or APC function, and the thread calls the function.
        /// If <see cref="FALSE"/>, the function does not return, and the thread does not call the completion routine or APC function.
        /// </para>
        /// <para>
        /// A completion routine is queued when the function call that queued the APC has completed.
        /// This function returns and the completion routine is called only if <paramref name="bAlertable"/> is <see cref="TRUE"/>,
        /// and the calling thread is the thread that queued the APC.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value indicates the event that caused the function to return.
        /// It can be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code/value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WAIT_ABANDONED"/>
        /// </para>
        /// <para>
        /// 0x00000080L
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The specified object is a mutex object that was not released by the thread
        /// that owned the mutex object before the owning thread terminated.
        /// Ownership of the mutex object is granted to the calling thread, and the mutex is set to nonsignaled.
        /// </para>
        /// <para>
        /// If the mutex was protecting persistent state information, you should check it for consistency.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WAIT_IO_COMPLETION"/>
        /// </para>
        /// <para>
        /// 0x000000C0L
        /// </para>
        /// </term>
        /// <term>
        /// The wait was ended by one or more user-mode asynchronous procedure calls (APC) queued to the thread.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WAIT_OBJECT_0"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// The state of the specified object is signaled.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WAIT_TIMEOUT"/>
        /// </para>
        /// <para>
        /// 0x00000102L
        /// </para>
        /// </term>
        /// <term>
        /// The time-out interval elapsed, and the object's state is nonsignaled.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WAIT_FAILED"/>
        /// </para>
        /// <para>
        /// (<see cref="DWORD"/>)0xFFFFFFFF
        /// </para>
        /// </term>
        /// <term>
        /// The function has failed.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="SignalObjectAndWait"/> function provides a more efficient way to signal one object
        /// and then wait on another compared to separate function calls
        /// such as <see cref="SetEvent"/> followed by <see cref="WaitForSingleObject"/>.
        /// </para>
        /// <para>
        /// The <see cref="SignalObjectAndWait"/> function can wait for the following objects:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Change notification
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Console input
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Event
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Memory resource notification
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Mutex
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Process
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Semaphore
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Thread
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Waitable timer
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// For more information, see Synchronization Objects.
        /// </para>
        /// <para>
        /// A thread can use the <see cref="SignalObjectAndWait"/> function to ensure
        /// that a worker thread is in a wait state before signaling an object.
        /// For example, a thread and a worker thread may use handles to event objects to synchronize their work.
        /// The thread executes code such as the following:
        /// </para>
        /// <code>
        /// dwRet = WaitForSingleObject(hEventWorkerDone, INFINITE);
        /// if( WAIT_OBJECT_0 == dwRet)
        ///     SetEvent(hEventMoreWorkToDo);
        /// </code>
        /// <para>
        /// The worker thread executes code such as the following:
        /// </para>
        /// <code>
        /// dwRet = SignalObjectAndWait(hEventWorkerDone, hEventMoreWorkToDo, INFINITE, FALSE);
        /// </code>
        /// <para>
        /// Note that the "signal" and "wait" are not guaranteed to be performed as an atomic operation.
        /// Threads executing on other processors can observe the signaled state of the first object
        /// before the thread calling <see cref="SignalObjectAndWait"/> begins its wait on the second object.
        /// </para>
        /// <para>
        /// Use extreme caution when using <see cref="SignalObjectAndWait"/> and <see cref="PulseEvent"/> with Windows 7,
        /// since using these APIs among multiple threads can cause an application to deadlock.
        /// Threads that are signaled by <see cref="SignalObjectAndWait"/> call <see cref="PulseEvent"/>
        /// to signal the waiting object of the <see cref="SignalObjectAndWait"/> call.
        /// In some circumstances, the caller of <see cref="SignalObjectAndWait"/> can't receive signal state of the waiting object in time, causing a deadlock.
        /// </para>
        /// <para>
        /// Use caution when using the wait functions and code that directly or indirectly creates windows.
        /// If a thread creates any windows, it must process messages. Message broadcasts are sent to all windows in the system.
        /// A thread that uses a wait function with no time-out interval may cause the system to become deadlocked.
        /// Two examples of code that indirectly creates windows are DDE and COM <see cref="CoInitialize"/>.
        /// Therefore, if you have a thread that creates windows, be sure to call <see cref="SignalObjectAndWait"/> from a different thread.
        /// If this is not possible, you can use <see cref="MsgWaitForMultipleObjects"/> or <see cref="MsgWaitForMultipleObjectsEx"/>,
        /// but the functionality is not equivalent.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SignalObjectAndWait", ExactSpelling = true)]
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
        /// This variable must be initialized by either calling <see cref="InitializeConditionVariable"/> (to initialize the structure dynamically)
        /// or assign the constant <see cref="CONDITION_VARIABLE_INIT"/> to the structure variable (to initialize the structure statically).
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
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails or the time-out interval elapses, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// Possible error codes include <see cref="ERROR_TIMEOUT"/>,
        /// which indicates that the time-out interval has elapsed before another thread has attempted to wake the sleeping thread.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// A thread that is sleeping on a condition variable can be woken
        /// before the specified time-out interval has elapsed
        /// using the <see cref="WakeConditionVariable"/> or <see cref="WakeAllConditionVariable"/> function.
        /// In this case, the thread wakes when the wake processing is complete, and not when its time-out interval elapses.
        /// After the thread is woken, it re-acquires the critical section it released when the thread entered the sleeping state.
        /// </para>
        /// <para>
        /// Condition variables are subject to spurious wakeups (those not associated with an explicit wake)
        /// and stolen wakeups (another thread manages to run before the woken thread).
        /// Therefore, you should recheck a predicate (typically in a <c>while</c> loop) after a sleep operation returns.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
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
        /// This variable must be initialized by either calling <see cref="InitializeConditionVariable"/> (to initialize the structure dynamically)
        /// or assign the constant <see cref="CONDITION_VARIABLE_INIT"/> to the structure variable (to initialize the structure statically).
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
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <c>0</c>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// If the timeout expires the function returns <c>FALSE</c> and <see cref="GetLastError"/> returns <see cref="ERROR_TIMEOUT"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the lock is unlocked when this function is called, the function behavior is undefined.
        /// </para>
        /// <para>
        /// The thread can be woken using the <see cref="WakeConditionVariable"/> or <see cref="WakeAllConditionVariable"/> function.
        /// After the thread is woken, it re-acquires the lock it released when the thread entered the sleeping state.
        /// </para>
        /// <para>
        /// Condition variables are subject to spurious wakeups (those not associated with an explicit wake)
        /// and stolen wakeups (another thread manages to run before the woken thread).
        /// Therefore, you should recheck a predicate (typically in a <c>while</c> loop) after a sleep operation returns.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
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
        /// <para>
        /// If the lock is successfully acquired, the return value is nonzero.
        /// </para>
        /// <para>
        /// if the current thread could not acquire the lock, the return value is zero.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "TryAcquireSRWLockExclusive", ExactSpelling = true)]
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
        /// <para>
        /// If the lock is successfully acquired, the return value is nonzero.
        /// </para>
        /// <para>
        /// if the current thread could not acquire the lock, the return value is zero.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "TryAcquireSRWLockShared", ExactSpelling = true)]
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
        /// <para>
        /// If the critical section is successfully entered or the current thread already owns the critical section,
        /// the return value is nonzero.
        /// </para>
        /// <para>
        /// If another thread already owns the critical section, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The threads of a single process can use a critical section object for mutual-exclusion synchronization.
        /// The process is responsible for allocating the memory used by a critical section object,
        /// which it can do by declaring a variable of type <see cref="CRITICAL_SECTION"/>.
        /// Before using a critical section, some thread of the process must call
        /// the <see cref="InitializeCriticalSection"/> or <see cref="InitializeCriticalSectionAndSpinCount"/> function to initialize the object.
        /// </para>
        /// <para>
        /// To enable mutually exclusive use of a shared resource,
        /// each thread calls the <see cref="EnterCriticalSection"/> or <see cref="TryEnterCriticalSection"/> function
        /// to request ownership of the critical section before executing any section of code that uses the protected resource.
        /// The difference is that <see cref="TryEnterCriticalSection"/> returns immediately,
        /// regardless of whether it obtained ownership of the critical section,
        /// while <see cref="EnterCriticalSection"/> blocks until the thread can take ownership of the critical section.
        /// When it has finished executing the protected code, the thread uses the <see cref="LeaveCriticalSection"/> function to relinquish ownership,
        /// enabling another thread to become the owner and gain access to the protected resource.
        /// The thread must call <see cref="LeaveCriticalSection"/> once for each time that it entered the critical section.
        /// </para>
        /// <para>
        /// Any thread of the process can use the <see cref="DeleteCriticalSection"/> function to release the system resources
        /// that were allocated when the critical section object was initialized.
        /// After this function has been called, the critical section object can no longer be used for synchronization.
        /// </para>
        /// <para>
        /// If a thread terminates while it has ownership of a critical section, the state of the critical section is undefined.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "TryEnterCriticalSection", ExactSpelling = true)]
        public static extern BOOL TryEnterCriticalSection([In][Out] ref CRITICAL_SECTION lpCriticalSection);

        /// <summary>
        /// <para>
        /// Cancels a registered wait operation issued by the <see cref="RegisterWaitForSingleObject"/> function.
        /// </para>
        /// <para>
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
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// If any callback functions associated with the timer have not completed when <see cref="UnregisterWait"/> is called,
        /// <see cref="UnregisterWait"/> unregisters the wait on the callback functions and fails with the <see cref="ERROR_IO_PENDING"/> error code.
        /// The error code does not indicate that the function has failed, and the function does not need to be called again.
        /// If your code requires an error code to set only when the unregister operation has failed, call <see cref="UnregisterWaitEx"/> instead.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "UnregisterWait", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL UnregisterWait([In] HANDLE WaitHandle);

        /// <summary>
        /// <para>
        /// Cancels a registered wait operation issued by the <see cref="RegisterWaitForSingleObject"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoollegacyapiset/nf-threadpoollegacyapiset-unregisterwaitex"/>
        /// </para>
        /// </summary>
        /// <param name="WaitHandle">
        /// The wait handle.
        /// This handle is returned by the <see cref="RegisterWaitForSingleObject"/> function.
        /// </param>
        /// <param name="CompletionEvent">
        /// <para>
        /// A handle to the event object to be signaled when the wait operation has been unregistered.
        /// This parameter can be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="INVALID_HANDLE_VALUE"/>, the function waits for all callback functions to complete before returning.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NULL"/>, the function marks the timer for deletion and returns immediately.
        /// However, most callers should wait for the callback function to complete so they can perform any needed cleanup.
        /// </para>
        /// <para>
        /// If the caller provides this event and the function succeeds
        /// or the function fails with <see cref="ERROR_IO_PENDING"/>, do not close the event until it is signaled.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// You cannot make a blocking call to <see cref="UnregisterWaitEx"/> from within a callback function for the same wait operation.
        /// Otherwise, the callback will be waiting for itself to finish.
        /// In general, a blocking call to <see cref="UnregisterWaitEx"/> creates a dependency between the current thread and the callback,
        /// so to make a blocking unregister call on another wait operation,
        /// you must ensure that the callback functions do not depend on one another
        /// and that the second wait operation does not also perform a blocking unregister call on the first operation.
        /// </para>
        /// <para>
        /// Be careful when making a blocking <see cref="UnregisterWaitEx"/> call on a persistent thread.
        /// If the wait operation being unregistered was created with <see cref="WT_EXECUTEINPERSISTENTTHREAD"/>, a deadlock may occur.
        /// </para>
        /// <para>
        /// After making non-blocking call to <see cref="UnregisterWaitEx"/>,
        /// no new callback functions associated with <paramref name="WaitHandle"/> can be queued.
        /// However, there may be pending callback functions already queued to worker threads.
        /// </para>
        /// <para>
        /// Under some conditions, the function will fail with <see cref="ERROR_IO_PENDING"/> if <paramref name="CompletionEvent"/> is <see cref="NULL"/>.
        /// This indicates that there are outstanding callback functions.
        /// Those callbacks either will execute or are in the middle of executing.
        /// </para>
        /// <para>
        /// If <paramref name="CompletionEvent"/> is a handle to an event provided by the caller,
        /// it is possible for the function to succeed, fail with <see cref="ERROR_IO_PENDING"/>, or fail with a different error code.
        /// If the function succeeds, or if the function fails with <see cref="ERROR_IO_PENDING"/>,
        /// the caller should always wait until the event is signaled to close the event.
        /// If the function fails with a different error code, it is not necessary to wait until the event is signaled to close the event.
        /// </para>
        /// <para>
        /// Windows XP:
        /// If <paramref name="CompletionEvent"/> is a handle to an event provided by the caller
        /// and the function fails with <see cref="ERROR_IO_PENDING"/>, the caller should wait until the event is signaled to close the event.
        /// This behavior changed starting with Windows Vista.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "UnregisterWaitEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL UnregisterWaitEx([In] HANDLE WaitHandle, [In] HANDLE CompletionEvent);

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
        /// <para>
        /// An array of object handles.
        /// For a list of the object types whose handles can be specified, see the following Remarks section.
        /// The array can contain handles to objects of different types.
        /// It may not contain multiple copies of the same handle.
        /// </para>
        /// <para>
        /// If one of these handles is closed while the wait is still pending, the function's behavior is undefined.
        /// </para>
        /// <para>
        /// The handles must have the <see cref="SYNCHRONIZE"/> access right. 
        /// For more information, see Standard Access Rights.
        /// </para>
        /// </param>
        /// <param name="bWaitAll">
        /// If this parameter is <see cref="TRUE"/>, the function returns
        /// when the state of all objects in the <paramref name="lpHandles"/> array is signaled.
        /// If <see cref="FALSE"/>, the function returns when the state of any one of the objects is set to signaled.
        /// In the latter case, the return value indicates the object whose state caused the function to return.
        /// </param>
        /// <param name="dwMilliseconds">
        /// <para>
        /// The time-out interval, in milliseconds.
        /// If a nonzero value is specified, the function waits until the specified objects are signaled or the interval elapses.
        /// If <paramref name="dwMilliseconds"/> is zero, the function does not enter a wait state
        /// if the specified objects are not signaled; it always returns immediately.
        /// If <paramref name="dwMilliseconds"/> is <see cref="INFINITE"/>,
        /// the function will return only when the specified objects are signaled.
        /// </para>
        /// <para>
        /// Windows XP, Windows Server 2003, Windows Vista, Windows 7, Windows Server 2008, and Windows Server 2008 R2:
        /// The <paramref name="dwMilliseconds"/> value does include time spent in low-power states.
        /// For example, the timeout does keep counting down while the computer is asleep.
        /// </para>
        /// <para>
        /// Windows 8 and newer, Windows Server 2012 and newer:
        /// The <paramref name="dwMilliseconds"/> value does not include time spent in low-power states.
        /// For example, the timeout does not keep counting down while the computer is asleep.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value indicates the event that caused the function to return.
        /// It can be one of the following values.
        /// (Note that <see cref="WAIT_OBJECT_0"/> is defined as 0 and <see cref="WAIT_ABANDONED_0"/> is defined as 0x00000080L.)
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code/value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="WAIT_OBJECT_0"/> to (<see cref="WAIT_OBJECT_0"/> + <paramref name="nCount"/>– 1)
        /// </term>
        /// <term>
        /// <para>
        /// If <paramref name="bWaitAll"/> is <see cref="TRUE"/>,
        /// a return value within the specified range indicates that the state of all specified objects is signaled.
        /// </para>
        /// <para>
        /// If <paramref name="bWaitAll"/> is <see cref="FALSE"/>,
        /// the return value minus <see cref="WAIT_OBJECT_0"/> indicates
        /// the <paramref name="lpHandles"/> array index of the object that satisfied the wait.
        /// If more than one object became signaled during the call,
        /// this is the array index of the signaled object with the smallest index value of all the signaled objects.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WAIT_ABANDONED_0"/> to (<see cref="WAIT_ABANDONED_0"/> + <paramref name="nCount"/>– 1)
        /// </term>
        /// <term>
        /// <para>
        /// If <paramref name="bWaitAll"/> is <see cref="TRUE"/>,
        /// a return value within the specified range indicates that 
        /// the state of all specified objects is signaled and at least one of the objects is an abandoned mutex object.
        /// </para>
        /// <para>
        /// If <paramref name="bWaitAll"/> is <see cref="FALSE"/>,
        /// the return value minus <see cref="WAIT_ABANDONED_0"/> indicates
        /// the <paramref name="lpHandles"/> array index of an abandoned mutex object that satisfied the wait.
        /// Ownership of the mutex object is granted to the calling thread, and the mutex is set to nonsignaled.
        /// </para>
        /// <para>
        /// If a mutex was protecting persistent state information, you should check it for consistency.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WAIT_TIMEOUT"/>
        /// </para>
        /// <para>
        /// 0x00000102L
        /// </para>
        /// </term>
        /// <term>
        /// The time-out interval elapsed and the conditions specified by the <paramref name="bWaitAll"/> parameter are not satisfied.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WAIT_FAILED"/>
        /// </para>
        /// <para>
        /// (<see cref="DWORD"/>)0xFFFFFFFF
        /// </para>
        /// </term>
        /// <term>
        /// The function has failed. To get extended error information, call <see cref="GetLastError"/>.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="WaitForMultipleObjects"/> function determines whether the wait criteria have been met.
        /// If the criteria have not been met, the calling thread enters the wait state
        /// until the conditions of the wait criteria have been met or the time-out interval elapses.
        /// </para>
        /// <para>
        /// When <paramref name="bWaitAll"/> is <see cref="TRUE"/>,
        /// the function's wait operation is completed only when the states of all objects have been set to signaled.
        /// The function does not modify the states of the specified objects until the states of all objects have been set to signaled.
        /// For example, a mutex can be signaled, but the thread does not get ownership
        /// until the states of the other objects are also set to signaled.
        /// In the meantime, some other thread may get ownership of the mutex, thereby setting its state to nonsignaled.
        /// </para>
        /// <para>
        /// When <paramref name="bWaitAll"/> is <see cref="FALSE"/>,
        /// this function checks the handles in the array in order starting with index 0, until one of the objects is signaled.
        /// If multiple objects become signaled, the function returns the index of the first handle in the array whose object was signaled.
        /// </para>
        /// <para>
        /// The function modifies the state of some types of synchronization objects.
        /// Modification occurs only for the object or objects whose signaled state caused the function to return.
        /// For example, the count of a semaphore object is decreased by one.
        /// For more information, see the documentation for the individual synchronization objects.
        /// </para>
        /// <para>
        /// To wait on more than <see cref="MAXIMUM_WAIT_OBJECTS"/> handles, use one of the following methods:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Create a thread to wait on <see cref="MAXIMUM_WAIT_OBJECTS"/> handles, then wait on that thread plus the other handles.
        /// Use this technique to break the handles into groups of <see cref="MAXIMUM_WAIT_OBJECTS"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Call <see cref="RegisterWaitForSingleObject"/> or <see cref="SetThreadpoolWait"/> to wait on each handle.
        /// The thread pool waits efficiently on the handles and assigns a worker thread after the object is signaled or the time-out interval expires.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The <see cref="WaitForMultipleObjects"/> function can specify handles of any of the following object types
        /// in the <paramref name="lpHandles"/> array:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Change notification
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Console input
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Event
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Memory resource notification
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Mutex
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Process
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Semaphore
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Thread
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Waitable timer
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Use caution when calling the wait functions and code that directly or indirectly creates windows.
        /// If a thread creates any windows, it must process messages.
        /// Message broadcasts are sent to all windows in the system.
        /// A thread that uses a wait function with no time-out interval may cause the system to become deadlocked.
        /// Two examples of code that indirectly creates windows are DDE and the <see cref="CoInitialize"/> function.
        /// Therefore, if you have a thread that creates windows,
        /// use <see cref="MsgWaitForMultipleObjects"/> or <see cref="MsgWaitForMultipleObjectsEx"/>,
        /// rather than <see cref="WaitForMultipleObjects"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WaitForMultipleObjects", ExactSpelling = true, SetLastError = true)]
        public static extern WaitResult WaitForMultipleObjects([In] DWORD nCount, [In] HANDLE[] lpHandles, [In] BOOL bWaitAll, [In] DWORD dwMilliseconds);

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
        /// <para>
        /// An array of object handles.
        /// For a list of the object types whose handles can be specified, see the following Remarks section.
        /// The array can contain handles of objects of different types.
        /// It may not contain multiple copies of the same handle.
        /// </para>
        /// <para>
        /// If one of these handles is closed while the wait is still pending, the function's behavior is undefined.
        /// </para>
        /// <para>
        /// The handles must have the <see cref="SYNCHRONIZE"/> access right.
        /// For more information, see Standard Access Rights.
        /// </para>
        /// </param>
        /// <param name="bWaitAll">
        /// If this parameter is <see cref="TRUE"/>, the function returns
        /// when the state of all objects in the <paramref name="lpHandles"/> array is set to signaled.
        /// If <see cref="FALSE"/>, the function returns when the state of any one of the objects is set to signaled.
        /// In the latter case, the return value indicates the object whose state caused the function to return.
        /// </param>
        /// <param name="dwMilliseconds">
        /// <para>
        /// The time-out interval, in milliseconds.
        /// If a nonzero value is specified, the function waits until the specified objects are signaled,
        /// an I/O completion routine or APC is queued, or the interval elapses.
        /// If <paramref name="dwMilliseconds"/> is zero,
        /// the function does not enter a wait state if the criteria is not met; it always returns immediately.
        /// If <paramref name="dwMilliseconds"/> is <see cref="INFINITE"/>,
        /// the function will return only when the specified objects are signaled or an I/O completion routine or APC is queued.
        /// </para>
        /// <para>
        /// Windows XP, Windows Server 2003, Windows Vista, Windows 7, Windows Server 2008, and Windows Server 2008 R2
        /// : The <paramref name="dwMilliseconds"/> value does include time spent in low-power states.
        /// For example, the timeout does keep counting down while the computer is asleep.
        /// </para>
        /// <para>
        /// Windows 8 and newer, Windows Server 2012 and newer:
        /// The <paramref name="dwMilliseconds"/> value does not include time spent in low-power states.
        /// For example, the timeout does not keep counting down while the computer is asleep.
        /// </para>
        /// </param>
        /// <param name="bAlertable">
        /// <para>
        /// If this parameter is <see cref="TRUE"/> and the thread is in the waiting state,
        /// the function returns when the system queues an I/O completion routine or APC, and the thread runs the routine or function.
        /// Otherwise, the function does not return and the completion routine or APC function is not executed.
        /// </para>
        /// <para>
        /// A completion routine is queued when the <see cref="ReadFileEx"/> or <see cref="WriteFileEx"/> function
        /// in which it was specified has completed.
        /// The wait function returns and the completion routine is called only if <paramref name="bAlertable"/> is <see cref="TRUE"/>
        /// and the calling thread is the thread that initiated the read or write operation.
        /// An APC is queued when you call <see cref="QueueUserAPC"/>.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value indicates the event that caused the function to return.
        /// It can be one of the following values.
        /// (Note that <see cref="WAIT_OBJECT_0"/> is defined as 0 and <see cref="WAIT_ABANDONED_0"/> is defined as 0x00000080L.)
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code/value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="WAIT_OBJECT_0"/> to (<see cref="WAIT_OBJECT_0"/> + <paramref name="nCount"/>– 1)
        /// </term>
        /// <term>
        /// <para>
        /// If <paramref name="bWaitAll"/> is <see cref="TRUE"/>, a return value in this range indicates
        /// that the state of all specified objects is signaled.
        /// </para>
        /// <para>
        /// If <paramref name="bWaitAll"/> is <see cref="FALSE"/>, he return value minus <see cref="WAIT_OBJECT_0"/> indicates
        /// the <paramref name="lpHandles"/> array index of the object that satisfied the wait.
        /// If more than one object became signaled during the call,
        /// this is the array index of the signaled object with the smallest index value of all the signaled objects.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WAIT_ABANDONED_0"/> to (<see cref="WAIT_ABANDONED_0"/> + <paramref name="nCount"/>– 1)
        /// </term>
        /// <term>
        /// <para>
        /// If <paramref name="bWaitAll"/> is <see cref="TRUE"/>, a return value in this range indicates
        /// that the state of all specified objects is signaled, and at least one of the objects is an abandoned mutex object.
        /// </para>
        /// <para>
        /// If <paramref name="bWaitAll"/> is <see cref="FALSE"/>, the return value minus <see cref="WAIT_ABANDONED_0"/> indicates
        /// the <paramref name="lpHandles"/> array index of an abandoned mutex object that satisfied the wait.
        /// Ownership of the mutex object is granted to the calling thread, and the mutex is set to nonsignaled.
        /// </para>
        /// <para>
        /// If a mutex was protecting persistent state information, you should check it for consistency.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WAIT_IO_COMPLETION"/>
        /// </para>
        /// <para>
        /// 0x000000C0L
        /// </para>
        /// </term>
        /// <term>
        /// The wait was ended by one or more user-mode asynchronous procedure calls (APC) queued to the thread.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WAIT_TIMEOUT"/>
        /// </para>
        /// <para>
        /// 0x00000102L
        /// </para>
        /// </term>
        /// <term>
        /// The time-out interval elapsed, the conditions specified by the <paramref name="bWaitAll"/> parameter were not satisfied,
        /// and no completion routines are queued.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WAIT_FAILED"/>
        /// </para>
        /// <para>
        /// (<see cref="DWORD"/>)0xFFFFFFFF
        /// </para>
        /// </term>
        /// <term>
        /// The function has failed.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="WaitForMultipleObjectsEx"/> function determines whether the wait criteria have been met.
        /// If the criteria have not been met, the calling thread enters the wait state
        /// until the conditions of the wait criteria have been met or the time-out interval elapses.
        /// </para>
        /// <para>
        /// When <paramref name="bWaitAll"/> is <see cref="TRUE"/>, the function's wait operation is completed
        /// only when the states of all objects have been set to signaled.
        /// The function does not modify the states of the specified objects until the states of all objects have been set to signaled.
        /// For example, a mutex can be signaled, but the thread does not get ownership
        /// until the states of the other objects are also set to signaled.
        /// In the meantime, some other thread may get ownership of the mutex, thereby setting its state to nonsignaled.
        /// </para>
        /// <para>
        /// When <paramref name="bWaitAll"/> is <see cref="FALSE"/>,
        /// this function checks the handles in the array in order starting with index 0,
        /// until one of the objects is signaled. If multiple objects become signaled,
        /// the function returns the index of the first handle in the array whose object was signaled.
        /// </para>
        /// <para>
        /// The function modifies the state of some types of synchronization objects.
        /// Modification occurs only for the object or objects whose signaled state caused the function to return.
        /// For example, the count of a semaphore object is decreased by one.
        /// For more information, see the documentation for the individual synchronization objects.
        /// </para>
        /// <para>
        /// To wait on more than <see cref="MAXIMUM_WAIT_OBJECTS"/> handles, use one of the following methods:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Create a thread to wait on <see cref="MAXIMUM_WAIT_OBJECTS"/> handles,
        /// then wait on that thread plus the other handles.
        /// Use this technique to break the handles into groups of <see cref="MAXIMUM_WAIT_OBJECTS"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Call <see cref="RegisterWaitForSingleObject"/> or <see cref="SetThreadpoolWait"/> to wait on each handle.
        /// The thread pool waits efficiently on the handles and assigns a worker thread
        /// after the object is signaled or the time-out interval expires.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The <see cref="WaitForMultipleObjectsEx"/> function can specify handles of any of the following object types
        /// in the <paramref name="lpHandles"/> array:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Change notification
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Console input
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Event
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Memory resource notification
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Mutex
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Process
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Semaphore
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Thread
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Waitable timer
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Use caution when calling the wait functions and code that directly or indirectly creates windows.
        /// If a thread creates any windows, it must process messages.
        /// Message broadcasts are sent to all windows in the system.
        /// A thread that uses a wait function with no time-out interval may cause the system to become deadlocked.
        /// Two examples of code that indirectly creates windows are DDE and the <see cref="CoInitialize"/> function.
        /// Therefore, if you have a thread that creates windows,
        /// use <see cref="MsgWaitForMultipleObjects"/> or <see cref="MsgWaitForMultipleObjectsEx"/>,
        /// rather than <see cref="WaitForMultipleObjectsEx"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WaitForMultipleObjectsEx", ExactSpelling = true, SetLastError = true)]
        public static extern WaitResult WaitForMultipleObjectsEx([In] DWORD nCount, [In] IntPtr[] lpHandles, [In] BOOL bWaitAll, [In] DWORD dwMilliseconds, [In] BOOL bAlertable);

        /// <summary>
        /// <para>
        /// Waits until the specified object is in the signaled state or the time-out interval elapses.
        /// </para>
        /// <para>
        /// To enter an alertable wait state, use the <see cref="WaitForSingleObjectEx"/> function.
        /// To wait for multiple objects, use <see cref="WaitForMultipleObjects"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-waitforsingleobject"/>
        /// </para>
        /// </summary>
        /// <param name="hHandle">
        /// <para>
        /// A handle to the object.
        /// For a list of the object types whose handles can be specified, see the following Remarks section.
        /// </para>
        /// <para>
        /// If this handle is closed while the wait is still pending, the function's behavior is undefined.
        /// </para>
        /// <para>
        /// The handle must have the <see cref="SYNCHRONIZE"/> access right. For more information, see Standard Access Rights.
        /// </para>
        /// </param>
        /// <param name="dwMilliseconds">
        /// <para>
        /// The time-out interval, in milliseconds.
        /// If a nonzero value is specified, the function waits until the object is signaled or the interval elapses.
        /// If <paramref name="dwMilliseconds"/> is zero, the function does not enter a wait state if the object is not signaled; it always returns immediately.
        /// If <paramref name="dwMilliseconds"/> is <see cref="INFINITE"/>, the function will return only when the object is signaled.
        /// </para>
        /// <para>
        /// Windows XP, Windows Server 2003, Windows Vista, Windows 7, Windows Server 2008, and Windows Server 2008 R2:
        /// The <paramref name="dwMilliseconds"/> value does include time spent in low-power states.
        /// For example, the timeout does keep counting down while the computer is asleep.
        /// </para>
        /// <para>
        /// Windows 8 and newer, Windows Server 2012 and newer:
        /// The <paramref name="dwMilliseconds"/> value does not include time spent in low-power states.
        /// For example, the timeout does not keep counting down while the computer is asleep.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value indicates the event that caused the function to return.
        /// It can be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code/value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WAIT_ABANDONED"/>
        /// </para>
        /// <para>
        /// 0x00000080L
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The specified object is a mutex object that was not released by the thread
        /// that owned the mutex object before the owning thread terminated.
        /// Ownership of the mutex object is granted to the calling thread and the mutex state is set to nonsignaled.
        /// </para>
        /// <para>
        /// If the mutex was protecting persistent state information, you should check it for consistency.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WAIT_OBJECT_0"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// The state of the specified object is signaled.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WAIT_TIMEOUT"/>
        /// </para>
        /// <para>
        /// 0x00000102L
        /// </para>
        /// </term>
        /// <term>
        /// The time-out interval elapsed, and the object's state is nonsignaled.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WAIT_FAILED"/>
        /// </para>
        /// <para>
        /// (DWORD)0xFFFFFFFF
        /// </para>
        /// </term>
        /// <term>
        /// The function has failed.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="WaitForSingleObject"/> function checks the current state of the specified object.
        /// If the object's state is nonsignaled, the calling thread enters the wait state
        /// until the object is signaled or the time-out interval elapses.
        /// </para>
        /// <para>
        /// The function modifies the state of some types of synchronization objects.
        /// Modification occurs only for the object whose signaled state caused the function to return.
        /// For example, the count of a semaphore object is decreased by one.
        /// </para>
        /// <para>
        /// The <see cref="WaitForSingleObject"/> function can wait for the following objects:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Change notification
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Console input
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Event
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Memory resource notification
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Mutex
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Process
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Semaphore
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Thread
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Waitable timer
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Use caution when calling the wait functions and code that directly or indirectly creates windows.
        /// If a thread creates any windows, it must process messages.
        /// Message broadcasts are sent to all windows in the system.
        /// A thread that uses a wait function with an <see cref="INFINITE"/> time-out interval may cause the system to become deadlocked.
        /// Two examples of code that indirectly creates windows are DDE and the <see cref="CoInitialize"/> function.
        /// Therefore, if you have a thread that creates windows,
        /// use <see cref="MsgWaitForMultipleObjects"/> or <see cref="MsgWaitForMultipleObjectsEx"/>,
        /// rather than <see cref="WaitForSingleObject"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WaitForSingleObject", ExactSpelling = true, SetLastError = true)]
        public static extern WaitResult WaitForSingleObject([In] HANDLE hHandle, [In] DWORD dwMilliseconds);

        /// <summary>
        /// <para>
        /// Waits until the specified object is in the signaled state,
        /// an I/O completion routine or asynchronous procedure call (APC) is queued to the thread, or the time-out interval elapses.
        /// </para>
        /// <para>
        /// To wait for multiple objects, use the WaitForMultipleObjectsEx.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-waitforsingleobjectex"/>
        /// </para>
        /// </summary>
        /// <param name="hHandle">
        /// <para>
        /// A handle to the object.
        /// For a list of the object types whose handles can be specified, see the following Remarks section.
        /// </para>
        /// <para>
        /// If this handle is closed while the wait is still pending, the function's behavior is undefined.
        /// </para>
        /// <para>
        /// The handle must have the <see cref="SYNCHRONIZE"/> access right. For more information, see Standard Access Rights.
        /// </para>
        /// </param>
        /// <param name="dwMilliseconds">
        /// <para>
        /// The time-out interval, in milliseconds.
        /// If a nonzero value is specified, the function waits until the object is signaled, 
        /// an I/O completion routine or APC is queued, or the interval elapses.
        /// If <paramref name="dwMilliseconds"/> is zero,
        /// the function does not enter a wait state if the criteria is not met; it always returns immediately.
        /// If <paramref name="dwMilliseconds"/> is <see cref="INFINITE"/>,
        /// the function will return only when the object is signaled or an I/O completion routine or APC is queued.
        /// </para>
        /// <para>
        /// Windows XP, Windows Server 2003, Windows Vista, Windows 7, Windows Server 2008, and Windows Server 2008 R2:
        /// The <paramref name="dwMilliseconds"/> value does include time spent in low-power states.
        /// For example, the timeout does keep counting down while the computer is asleep.
        /// </para>
        /// <para>
        /// Windows 8 and newer, Windows Server 2012 and newer:
        /// The <paramref name="dwMilliseconds"/> value does not include time spent in low-power states.
        /// For example, the timeout does not keep counting down while the computer is asleep.
        /// </para>
        /// </param>
        /// <param name="bAlertable">
        /// <para>
        /// If this parameter is <see cref="TRUE"/> and the thread is in the waiting state,
        /// the function returns when the system queues an I/O completion routine or APC, and the thread runs the routine or function.
        /// Otherwise, the function does not return, and the completion routine or APC function is not executed.
        /// </para>
        /// <para>
        /// A completion routine is queued
        /// when the <see cref="ReadFileEx"/> or <see cref="WriteFileEx"/> function in which it was specified has completed.
        /// The wait function returns and the completion routine is called only if <paramref name="bAlertable"/> is <see cref="TRUE"/>,
        /// and the calling thread is the thread that initiated the read or write operation.
        /// An APC is queued when you call <see cref="QueueUserAPC"/>.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value indicates the event that caused the function to return.
        /// It can be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code/value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WAIT_ABANDONED"/>
        /// </para>
        /// <para>
        /// 0x00000080L
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The specified object is a mutex object that was not released by the thread
        /// that owned the mutex object before the owning thread terminated.
        /// Ownership of the mutex object is granted to the calling thread and the mutex is set to nonsignaled.
        /// </para>
        /// <para>
        /// If the mutex was protecting persistent state information, you should check it for consistency.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WAIT_IO_COMPLETION"/>
        /// </para>
        /// <para>
        /// 0x000000C0L
        /// </para>
        /// </term>
        /// <term>
        /// The wait was ended by one or more user-mode asynchronous procedure calls (APC) queued to the thread.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WAIT_OBJECT_0"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// The state of the specified object is signaled.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WAIT_TIMEOUT"/>
        /// </para>
        /// <para>
        /// 0x00000102L
        /// </para>
        /// </term>
        /// <term>
        /// The time-out interval elapsed, and the object's state is nonsignaled.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WAIT_FAILED"/>
        /// </para>
        /// <para>
        /// (<see cref="DWORD"/>)0xFFFFFFFF
        /// </para>
        /// </term>
        /// <term>
        /// The function has failed.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="WaitForSingleObjectEx"/> function determines whether the wait criteria have been met.
        /// If the criteria have not been met, the calling thread enters the wait state
        /// until the conditions of the wait criteria have been met or the time-out interval elapses.
        /// </para>
        /// <para>
        /// The function modifies the state of some types of synchronization objects.
        /// Modification occurs only for the object whose signaled state caused the function to return.
        /// For example, the count of a semaphore object is decreased by one.
        /// </para>
        /// <para>
        /// The <see cref="WaitForSingleObjectEx"/> function can wait for the following objects:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Change notification
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Console input
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Event
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Memory resource notification
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Mutex
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Process
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Semaphore
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Thread
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Waitable timer
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Use caution when calling the wait functions and code that directly or indirectly creates windows.
        /// If a thread creates any windows, it must process messages.
        /// Message broadcasts are sent to all windows in the system.
        /// A thread that uses a wait function with no time-out interval may cause the system to become deadlocked.
        /// Two examples of code that indirectly creates windows are DDE and the <see cref="CoInitialize"/> function.
        /// Therefore, if you have a thread that creates windows,
        /// use <see cref="MsgWaitForMultipleObjects"/> or <see cref="MsgWaitForMultipleObjectsEx"/>,
        /// rather than <see cref="WaitForSingleObjectEx"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
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
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WakeAllConditionVariable", ExactSpelling = true)]
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
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WakeConditionVariable", ExactSpelling = true)]
        public static extern void WakeConditionVariable([In][Out] ref CONDITION_VARIABLE ConditionVariable);
    }
}
