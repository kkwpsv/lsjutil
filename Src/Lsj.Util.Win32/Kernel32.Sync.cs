using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// CONDITION_VARIABLE_LOCKMODE_SHARED
        /// </summary>
        public const uint CONDITION_VARIABLE_LOCKMODE_SHARED = unchecked((uint)-1);

        /// <summary>
        /// <para>
        /// Acquires a slim reader/writer (SRW) lock in exclusive mode.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-acquiresrwlockexclusive
        /// </para>
        /// </summary>
        /// <param name="SRWLock">
        /// A pointer to the SRW lock.
        /// </param>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "AcquireSRWLockExclusive", SetLastError = true)]
        public static extern void AcquireSRWLockExclusive([In][Out]ref SRWLOCK SRWLock);

        /// <summary>
        /// <para>
        /// Acquires a slim reader/writer (SRW) lock in shared mode.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-acquiresrwlockshared
        /// </para>
        /// </summary>
        /// <param name="SRWLock">
        /// A pointer to the SRW lock.
        /// </param>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "AcquireSRWLockExclusive", SetLastError = true)]
        public static extern void AcquireSRWLockShared([In][Out]ref SRWLOCK SRWLock);

        /// <summary>
        /// <para>
        /// Releases all resources used by an unowned critical section object.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-deletecriticalsection
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteCriticalSection", SetLastError = true)]
        public static extern void DeleteCriticalSection([In][Out]ref CRITICAL_SECTION lpCriticalSection);

        /// <summary>
        /// <para>
        /// Waits for ownership of the specified critical section object.
        /// The function returns when the calling thread is granted ownership.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-entercriticalsection
        /// </para>
        /// </summary>
        /// <param name="lpCriticalSection">
        /// A pointer to the critical section object.
        /// </param>
        /// <returns>
        /// This function does not return a value.
        /// <para>
        /// This function can raise <see cref="EXCEPTION_POSSIBLE_DEADLOCK"/> if a wait operation on the critical section times out.
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnterCriticalSection", SetLastError = true)]
        public static extern void EnterCriticalSection([In][Out]ref CRITICAL_SECTION lpCriticalSection);

        /// <summary>
        /// <para>
        /// Initializes a critical section object.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-initializecriticalsection
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitializeCriticalSection", SetLastError = true)]
        public static extern void InitializeCriticalSection([In][Out]ref CRITICAL_SECTION lpCriticalSection);

        /// <summary>
        /// <para>
        /// Initializes a critical section object and sets the spin count for the critical section.
        /// When a thread tries to acquire a critical section that is locked, the thread spins:
        /// it enters a loop which iterates spin count times, checking to see if the lock is released.
        /// If the lock is not released before the loop finishes, the thread goes to sleep to wait for the lock to be released.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-initializecriticalsectionandspincount
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
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0403 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitializeCriticalSection", SetLastError = true)]
        public static extern bool InitializeCriticalSectionAndSpinCount([In][Out]ref CRITICAL_SECTION lpCriticalSection, [In]uint dwSpinCount);

        /// <summary>
        /// <para>
        /// Initialize a slim reader/writer (SRW) lock.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-initializesrwlock?redirectedfrom=MSDN
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitializeSRWLock", SetLastError = true)]
        public static extern void InitializeSRWLock([In][Out]ref SRWLOCK SRWLock);

        /// <summary>
        /// <para>
        /// Performs an atomic compare-and-exchange operation on the specified values.
        /// The function compares two specified 32-bit values and exchanges with another 32-bit value based on the outcome of the comparison.
        /// If you are exchanging pointer values, this function has been superseded by the <see cref="InterlockedCompareExchangePointer"/> function.
        /// To operate on 64-bit values, use the <see cref="InterlockedCompareExchange64"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/nf-winnt-interlockedcompareexchange
        /// </para>
        /// </summary>
        /// <param name="Destination">
        /// A pointer to the destination value.
        /// </param>
        /// <param name="ExChange">
        /// The exchange value.
        /// </param>
        /// <param name="Comperand">
        /// The value to compare to <paramref name="Destination"/>.
        /// </param>
        /// <returns>
        /// The function returns the initial value of the <paramref name="Destination"/> parameter.
        /// </returns>
        /// <remarks>
        /// The function compares the <paramref name="Destination"/> value with the <paramref name="Comperand"/> value.
        /// If the Destination value is equal to the <paramref name="Comperand"/> value,
        /// the <paramref name="ExChange"/> value is stored in the address specified by <paramref name="Destination"/>.
        /// Otherwise, no operation is performed.
        /// The parameters for this function must be aligned on a 32-bit boundary;
        /// otherwise, the function will behave unpredictably on multiprocessor x86 systems and any non-x86 systems.
        /// See _aligned_malloc.
        /// The interlocked functions provide a simple mechanism for synchronizing access to a variable that is shared by multiple threads.
        /// This function is atomic with respect to calls to other interlocked functions.
        /// This function is implemented using a compiler intrinsic where possible.
        /// For more information, see the WinBase.h header file and _InterlockedCompareExchange.
        /// This function generates a full memory barrier (or fence) to ensure that memory operations are completed in order.
        /// Note This function is supported on Windows RT-based systems.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InterlockedCompareExchange", SetLastError = true)]
        public static extern int InterlockedCompareExchange([In][Out]ref int Destination, [In]int ExChange, [In]int Comperand);

        /// <summary>
        /// <para>
        /// Performs an atomic compare-and-exchange operation on the specified values.
        /// The function compares two specified 64-bit values and exchanges with another 64-bit value based on the outcome of the comparison.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/nf-winnt-interlockedcompareexchange64
        /// </para>
        /// </summary>
        /// <param name="Destination">
        /// A pointer to the destination value.
        /// </param>
        /// <param name="ExChange">
        /// The exchange value.
        /// </param>
        /// <param name="Comperand">
        /// The value to compare to <paramref name="Destination"/>.
        /// </param>
        /// <returns>
        /// The function returns the initial value of the <paramref name="Destination"/> parameter.
        /// </returns>
        /// <remarks>
        /// The function compares the <paramref name="Destination"/> value with the <paramref name="Comperand"/> value.
        /// If the <paramref name="Destination"/> value is equal to the <paramref name="Comperand"/> value,
        /// the <paramref name="ExChange"/> value is stored in the address specified by <paramref name="Destination"/>.
        /// Otherwise, no operation is performed.
        /// The variables for this function must be aligned on a 64-bit boundary;
        /// otherwise, this function will behave unpredictably on multiprocessor x86 systems and any non-x86 systems.
        /// See _aligned_malloc.
        /// The interlocked functions provide a simple mechanism for synchronizing access to a variable that is shared by multiple threads.
        /// This function is atomic with respect to calls to other interlocked functions.
        /// This function is implemented using a compiler intrinsic where possible.
        /// For more information, see the WinBase.h header file and _InterlockedCompareExchange64.
        /// This function generates a full memory barrier (or fence) to ensure that memory operations are completed in order.
        /// Note This function is supported on Windows RT-based systems.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InterlockedCompareExchange64", SetLastError = true)]
        public static extern long InterlockedCompareExchange64([In][Out]ref long Destination, [In]long ExChange, [In]long Comperand);

        /// <summary>
        /// <para>
        /// Performs an atomic compare-and-exchange operation on the specified values.
        /// The function compares two specified pointer values and exchanges with another pointer value based on the outcome of the comparison.
        /// To operate on non-pointer values, use the <see cref="InterlockedCompareExchange"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/nf-winnt-interlockedcompareexchangepointer
        /// </para>
        /// </summary>
        /// <param name="Destination">
        /// A pointer to a pointer to the destination value.
        /// </param>
        /// <param name="Exchange">
        /// The exchange value.
        /// </param>
        /// <param name="Comperand">
        /// The value to compare to <paramref name="Destination"/>.
        /// </param>
        /// <returns>
        /// The function returns the initial value of the <paramref name="Destination"/> parameter.
        /// </returns>
        /// <remarks>
        /// The function compares the <paramref name="Destination"/> value with the <paramref name="Comperand"/> value.
        /// If the <paramref name="Destination"/> value is equal to the <paramref name="Comperand"/> value,
        /// the <paramref name="Exchange"/> value is stored in the address specified by <paramref name="Destination"/>.
        /// Otherwise, no operation is performed.
        /// On a 64-bit system, the parameters are 64 bits and must be aligned on 64-bit boundaries;
        /// otherwise, the function will behave unpredictably.On a 32-bit system, the parameters are 32 bits and must be aligned on 32-bit boundaries.
        /// The interlocked functions provide a simple mechanism for synchronizing access to a variable that is shared by multiple threads.
        /// This function is atomic with respect to calls to other interlocked functions.
        /// This function is implemented using a compiler intrinsic where possible.
        /// For more information, see the WinBase.h header file and _InterlockedCompareExchangePointer.
        /// This function generates a full memory barrier (or fence) to ensure that memory operations are completed in order.
        /// Note This function is supported on Windows RT-based systems.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InterlockedCompareExchangePointer", SetLastError = true)]
        public static extern IntPtr InterlockedCompareExchangePointer([In][Out]ref IntPtr Destination, [In]IntPtr Exchange, [In]IntPtr Comperand);

        /// <summary>
        /// <para>
        /// Decrements (decreases by one) the value of the specified 32-bit variable as an atomic operation.
        /// To operate on 64-bit values, use the <see cref="InterlockedDecrement64"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/nf-winnt-interlockeddecrement
        /// </para>
        /// </summary>
        /// <param name="Addend">
        /// A pointer to the variable to be decremented.
        /// </param>
        /// <returns>
        /// The function returns the resulting decremented value.
        /// </returns>
        /// <remarks>
        /// The variable pointed to by the <paramref name="Addend"/> parameter must be aligned on a 32-bit boundary;
        /// otherwise, this function will behave unpredictably on multiprocessor x86 systems and any non-x86 systems.
        /// See _aligned_malloc.
        /// The interlocked functions provide a simple mechanism for synchronizing access to a variable that is shared by multiple threads.
        /// This function is atomic with respect to calls to other interlocked functions.
        /// This function is implemented using a compiler intrinsic where possible.
        /// For more information, see the WinBase.h header file and _InterlockedDecrement.
        /// This function generates a full memory barrier (or fence) to ensure that memory operations are completed in order.
        /// Note This function is supported on Windows RT-based systems.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InterlockedDecrement", SetLastError = true)]
        public static extern int InterlockedDecrement([In][Out]ref int Addend);

        /// <summary>
        /// <para>
        /// Performs an atomic addition of two 32-bit values.
        /// To operate on 64-bit values, use the <see cref="InterlockedExchangeAdd64"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/nf-winnt-interlockedexchangeadd
        /// </para>
        /// </summary>
        /// <param name="Addend">
        /// A pointer to a variable. The value of this variable will be replaced with the result of the operation.
        /// </param>
        /// <param name="Value">
        /// The value to be added to the variable pointed to by the <paramref name="Addend"/> parameter.
        /// </param>
        /// <returns>
        /// The function returns the initial value of the <paramref name="Addend"/> parameter.
        /// </returns>
        /// <remarks>
        /// The function performs an atomic addition of Value to the value pointed to by <paramref name="Addend"/>.
        /// The result is stored in the address specified by <paramref name="Addend"/>.
        /// The function returns the initial value of the variable pointed to by <paramref name="Addend"/>.
        /// The variables for this function must be aligned on a 32-bit boundary;
        /// otherwise, this function will behave unpredictably on multiprocessor x86 systems and any non-x86 systems.
        /// See _aligned_malloc.
        /// The interlocked functions provide a simple mechanism for synchronizing access to a variable that is shared by multiple threads.
        /// This function is atomic with respect to calls to other interlocked functions.
        /// This function is implemented using a compiler intrinsic where possible.
        /// For more information, see the WinBase.h header file and _InterlockedExchangeAdd
        /// This function generates a full memory barrier (or fence) to ensure that memory operations are completed in order.
        /// Note This function is supported on Windows RT-based systems.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InterlockedExchangeAdd", SetLastError = true)]
        public static extern int InterlockedExchangeAdd([In][Out]ref int Addend, [In]int Value);

        /// <summary>
        /// <para>
        /// Performs an atomic addition of two 64-bit values.
        /// To operate on 32-bit values, use the <see cref="InterlockedExchangeAdd"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/nf-winnt-interlockedexchangeadd64
        /// </para>
        /// </summary>
        /// <param name="Addend">
        /// A pointer to a variable. The value of this variable will be replaced with the result of the operation.
        /// </param>
        /// <param name="Value">
        /// The value to be added to the variable pointed to by the <paramref name="Addend"/> parameter.
        /// </param>
        /// <returns>
        /// The function returns the initial value of the <paramref name="Addend"/> parameter.
        /// </returns>
        /// <remarks>
        /// The function performs an atomic addition of Value to the value pointed to by <paramref name="Addend"/>.
        /// The result is stored in the address specified by <paramref name="Addend"/>.
        /// The function returns the initial value of the variable pointed to by <paramref name="Addend"/>.
        /// The variables for this function must be aligned on a 64-bit boundary;
        /// otherwise, this function will behave unpredictably on multiprocessor x86 systems and any non-x86 systems.
        /// See _aligned_malloc.
        /// The interlocked functions provide a simple mechanism for synchronizing access to a variable that is shared by multiple threads.
        /// This function is atomic with respect to calls to other interlocked functions.
        /// This function is implemented using a compiler intrinsic where possible.
        /// For more information, see the WinBase.h header file and _InterlockedExchangeAdd64.
        /// This function generates a full memory barrier (or fence) to ensure that memory operations are completed in order.
        /// Note This function is supported on Windows RT-based systems.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InterlockedExchangeAdd64", SetLastError = true)]
        public static extern long InterlockedExchangeAdd64([In][Out]ref long Addend, [In]long Value);

        /// <summary>
        /// <para>
        /// Atomically exchanges a pair of addresses.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/nf-winnt-interlockedexchangepointer
        /// </para>
        /// </summary>
        /// <param name="Target">
        /// A pointer to the address to exchange.
        /// The function sets the address pointed to by the <paramref name="Target"/> parameter (*Target) to the address 
        /// that is the value of the <paramref name="Value"/> parameter, and returns the prior value of the <paramref name="Target"/> parameter.
        /// </param>
        /// <param name="Value">
        /// The address to be exchanged with the address pointed to by the <paramref name="Target"/> parameter (*Target).
        /// </param>
        /// <returns>
        /// The function returns the initial address pointed to by the <paramref name="Target"/> parameter.
        /// </returns>
        /// <remarks>
        /// This function copies the address passed as the second parameter to the first and returns the original address of the first.
        /// On a 64-bit system, the parameters are 64 bits and the Target parameter must be aligned on 64-bit boundaries;
        /// otherwise, the function will behave unpredictably.
        /// On a 32-bit system, the parameters are 32 bits and the Target parameter must be aligned on 32-bit boundaries.
        /// The interlocked functions provide a simple mechanism for synchronizing access to a variable that is shared by multiple threads.
        /// This function is atomic with respect to calls to other interlocked functions.
        /// This function is implemented using a compiler intrinsic where possible.
        /// For more information, see the WinBase.h header file and _InterlockedExchangePointer.
        /// This function generates a full memory barrier (or fence) to ensure that memory operations are completed in order.
        /// Note This function is supported on Windows RT-based systems.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InterlockedExchangePointer", SetLastError = true)]
        public static extern IntPtr InterlockedExchangePointer([In][Out]ref IntPtr Target, [In]IntPtr Value);

        /// <summary>
        /// <para>
        /// Increments (increases by one) the value of the specified 32-bit variable as an atomic operation.
        /// To operate on 64-bit values, use the <see cref="InterlockedIncrement64"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/nf-winnt-interlockedincrement
        /// </para>
        /// </summary>
        /// <param name="Addend">
        /// A pointer to the variable to be incremented.
        /// </param>
        /// <returns>
        /// The function returns the resulting incremented value.
        /// </returns>
        /// <remarks>
        /// The variable pointed to by the <paramref name="Addend"/> parameter must be aligned on a 32-bit boundary;
        /// otherwise, this function will behave unpredictably on multiprocessor x86 systems and any non-x86 systems.
        /// See _aligned_malloc.
        /// The interlocked functions provide a simple mechanism for synchronizing access to a variable that is shared by multiple threads.
        /// This function is atomic with respect to calls to other interlocked functions.
        /// This function is implemented using a compiler intrinsic where possible.
        /// For more information, see the WinBase.h header file and _InterlockedIncrement.
        /// This function generates a full memory barrier (or fence) to ensure that memory operations are completed in order.
        /// This function is supported on Windows RT-based systems.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InterlockedIncrement", SetLastError = true)]
        public static extern int InterlockedIncrement([In][Out]int Addend);

        /// <summary>
        /// <para>
        /// Releases ownership of the specified critical section object.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-leavecriticalsection
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "LeaveCriticalSection", SetLastError = true)]
        public static extern void LeaveCriticalSection([In][Out]ref CRITICAL_SECTION lpCriticalSection);

        /// <summary>
        /// <para>
        /// Waits until one or all of the specified objects are in the signaled state,
        /// an I/O completion routine or asynchronous procedure call (APC) is queued to the thread, or the time-out interval elapses.
        /// The array of objects can include input event objects, which you specify using the dwWakeMask parameter.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-msgwaitformultipleobjectsex
        /// </para>
        /// </summary>
        /// <param name="nCount">
        /// The number of object handles in the array pointed to by <paramref name="pHandles"/>.
        /// The maximum number of object handles is <see cref="MAXIMUM_WAIT_OBJECTS"/> minus one.
        /// If this parameter has the value zero, then the function waits only for an input event.
        /// </param>
        /// <param name="pHandles">
        /// An array of object handles.
        /// For a list of the object types whose handles you can specify, see the Remarks section later in this topic.
        /// The array can contain handles to multiple types of objects.
        /// It may not contain multiple copies of the same handle.
        /// If one of these handles is closed while the wait is still pending, the function's behavior is undefined.
        /// The handles must have the <see cref="SYNCHRONIZE"/> access right. For more information, see Standard Access Rights.
        /// </param>
        /// <param name="dwMilliseconds">
        /// The time-out interval, in milliseconds.
        /// If a nonzero value is specified, the function waits until the specified objects are signaled,
        /// an I/O completion routine or APC is queued, or the interval elapses.
        /// If <paramref name="dwMilliseconds"/> is zero, the function does not enter a wait state if the criteria is not met;
        /// it always returns immediately.
        /// If <paramref name="dwMilliseconds"/> is <see cref="INFINITE"/>, the function will return only
        /// when the specified objects are signaled or an I/O completion routine or APC is queued.
        /// </param>
        /// <param name="dwWakeMask">
        /// The input types for which an input event object handle will be added to the array of object handles.
        /// This parameter can be one or more of the following values.
        /// <see cref="QS_ALLEVENTS"/>, <see cref="QS_ALLINPUT"/>, <see cref="QS_ALLPOSTMESSAGE"/>, <see cref="QS_HOTKEY"/>,
        /// <see cref="QS_INPUT"/>, <see cref="QS_KEY"/>, <see cref="QS_MOUSE"/>, <see cref="QS_MOUSEBUTTON"/>, <see cref="QS_MOUSEMOVE"/>,
        /// <see cref="QS_PAINT"/>, <see cref="QS_POSTMESSAGE"/>, <see cref="QS_RAWINPUT"/>, <see cref="QS_SENDMESSAGE"/>, <see cref="QS_TIMER"/>
        /// </param>
        /// <param name="dwFlags">
        /// The wait type. This parameter can be one or more of the following values.
        /// 0: 
        /// The function returns when any one of the objects is signaled.
        /// The return value indicates the object whose state caused the function to return.
        /// <see cref="MWMO_ALERTABLE"/>, <see cref="MWMO_INPUTAVAILABLE"/>, <see cref="MWMO_WAITALL"/>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value indicates the event that caused the function to return.
        /// It can be one of the following values.
        /// <see cref="WAIT_OBJECT_0"/> to (<see cref="WAIT_OBJECT_0"/> + <paramref name="nCount"/> - 1):
        /// If the <see cref="MWMO_WAITALL"/> flag is used, the return value indicates that the state of all specified objects is signaled.
        /// Otherwise, the return value minus <see cref="WAIT_OBJECT_0"/> indicates the <paramref name="pHandles"/> array index of the object
        /// that caused the function to return.
        /// <see cref="WAIT_OBJECT_0"/> + <paramref name="nCount"/>:
        /// New input of the type specified in the <paramref name="dwWakeMask"/> parameter is available in the thread's input queue.
        /// Functions such as <see cref="PeekMessage"/>, <see cref="GetMessage"/>, <see cref="GetQueueStatus"/>,
        /// and <see cref="WaitMessage"/> mark messages in the queue as old messages.
        /// Therefore, after you call one of these functions, a subsequent call to <see cref="MsgWaitForMultipleObjectsEx"/> will not return 
        /// until new input of the specified type arrives.
        /// This value is also returned upon the occurrence of a system event that requires the thread's action, such as foreground activation.
        /// Therefore, <see cref="MsgWaitForMultipleObjectsEx"/> can return even though no appropriate input is available
        /// and even if <paramref name="dwWakeMask"/> is set to 0.
        /// If this occurs, call <see cref="GetMessage"/> or <see cref="PeekMessage"/> to process the system event
        /// before trying the call to <see cref="MsgWaitForMultipleObjectsEx"/> again.
        /// <see cref="WAIT_ABANDONED_0"/> to (<see cref="WAIT_ABANDONED_0"/> + <paramref name="nCount"/> - 1):
        /// If the <see cref="MWMO_WAITALL"/> flag is used, the return value indicates that the state of all specified objects is signaled
        /// and at least one of the objects is an abandoned mutex object.
        /// Otherwise, the return value minus <see cref="WAIT_ABANDONED_0"/> indicates the <paramref name="pHandles"/> array index
        /// of an abandoned mutex object that caused the function to return.
        /// Ownership of the mutex object is granted to the calling thread, and the mutex is set to nonsignaled.
        /// If the mutex was protecting persistent state information, you should check it for consistency.
        /// <see cref="WAIT_IO_COMPLETION"/>:
        /// The wait was ended by one or more user-mode asynchronous procedure calls (APC) queued to the thread.
        /// <see cref="WAIT_TIMEOUT"/>:
        /// The time-out interval elapsed, but the conditions specified by the <paramref name="dwFlags"/>
        /// and <paramref name="dwWakeMask"/> parameters were not met.
        /// <see cref="WAIT_FAILED"/>:
        /// The function has failed. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="MsgWaitForMultipleObjectsEx"/> function determines whether the conditions specified
        /// by <paramref name="dwWakeMask"/> and <paramref name="dwFlags"/> have been met.
        /// If the conditions have not been met, the calling thread enters the wait state until the conditions of the wait criteria have been met
        /// or the time-out interval elapses.
        /// When <paramref name="dwFlags"/> is zero, this function checks the handles in the array in order starting with index 0,
        /// until one of the objects is signaled.
        /// If multiple objects become signaled, the function returns the index of the first handle in the array whose object was signaled.
        /// <see cref="MsgWaitForMultipleObjectsEx"/> does not return if there is unread input of the specified type in the message queue
        /// after the thread has called a function to check the queue, unless you use the <see cref="MWMO_INPUTAVAILABLE"/> flag.
        /// This is because functions such as <see cref="PeekMessage"/>, <see cref="GetMessage"/>, <see cref="GetQueueStatus"/>,
        /// and <see cref="WaitMessage"/> check the queue and then change the state information for the queue so that the input is no longer considered new.
        /// A subsequent call to <see cref="MsgWaitForMultipleObjectsEx"/> will not return until new input of the specified type arrives,
        /// unless you use the <see cref="MWMO_INPUTAVAILABLE"/> flag.
        /// If this flag is not used, the existing unread input (received prior to the last time the thread checked the queue) is ignored.
        /// The function modifies the state of some types of synchronization objects.
        /// Modification occurs only for the object or objects whose signaled state caused the function to return.
        /// For example, the system decreases the count of a semaphore object by one.
        /// For more information, see the documentation for the individual synchronization objects.
        /// The <see cref="MsgWaitForMultipleObjectsEx"/> function can specify handles of any of the following object types in the pHandles array:
        /// Change notification, Console input ,Event ,Memory resource notification, Mutex, Process, Semaphore, Thread, Waitable timer
        /// The <see cref="QS_ALLPOSTMESSAGE"/> and <see cref="QS_POSTMESSAGE"/> flags differ in when they are cleared.
        /// <see cref="QS_POSTMESSAGE"/> is cleared when you call <see cref="GetMessage"/> or <see cref="PeekMessage"/>,
        /// whether or not you are filtering messages.
        /// <see cref="QS_ALLPOSTMESSAGE"/> is cleared when you call <see cref="GetMessage"/> or <see cref="PeekMessage"/>
        /// without filtering messages (wMsgFilterMin and wMsgFilterMax are 0).
        /// This can be useful when you call <see cref="PeekMessage"/> multiple times to get messages in different ranges.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "MsgWaitForMultipleObjectsEx", SetLastError = true)]
        public static extern DWORD MsgWaitForMultipleObjectsEx([In]DWORD nCount, [MarshalAs(UnmanagedType.LPArray)][In]HANDLE[] pHandles,
            [In]DWORD dwMilliseconds, [In]QueueStatus dwWakeMask, [In]MsgWaitForMultipleObjectsExFlags dwFlags);

        /// <summary>
        /// <para>
        /// Releases a slim reader/writer (SRW) lock that was acquired in exclusive mode.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-releasesrwlockexclusive
        /// </para>
        /// </summary>
        /// <param name="SRWLock">
        /// A pointer to the SRW lock.
        /// </param>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ReleaseSRWLockExclusive", SetLastError = true)]
        public static extern void ReleaseSRWLockExclusive([In][Out]ref SRWLOCK SRWLock);

        /// <summary>
        /// <para>
        /// Releases a slim reader/writer (SRW) lock that was acquired in shared mode.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-releasesrwlockshared
        /// </para>
        /// </summary>
        /// <param name="SRWLock">
        /// A pointer to the SRW lock.
        /// </param>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ReleaseSRWLockShared", SetLastError = true)]
        public static extern void ReleaseSRWLockShared([In][Out]ref SRWLOCK SRWLock);

        /// <summary>
        /// <para>
        /// Signals one object and waits on another object as a single operation.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-signalobjectandwait
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
        /// If this parameter is <see cref="BOOL.TRUE"/>, the function returns when the system queues an I/O completion routine or APC function,
        /// and the thread calls the function.
        /// If <see cref="BOOL.FALSE"/>, the function does not return, and the thread does not call the completion routine or APC function.
        /// A completion routine is queued when the function call that queued the APC has completed.
        /// This function returns and the completion routine is called only if <paramref name="bAlertable"/> is <see langword="true"/>,
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SignalObjectAndWait", SetLastError = true)]
        public static extern DWORD SignalObjectAndWait([In]HANDLE hObjectToSignal, [In]HANDLE hObjectToWaitOn, [In]DWORD dwMilliseconds, [In]BOOL bAlertable);

        /// <summary>
        /// <para>
        /// Sleeps on the specified condition variable and releases the specified critical section as an atomic operation.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-sleepconditionvariablecs
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SleepConditionVariableCS", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SleepConditionVariableCS([In][Out]ref CONDITION_VARIABLE ConditionVariable,
            [In][Out]ref CRITICAL_SECTION CriticalSection, [In]uint dwMilliseconds);

        /// <summary>
        /// <para>
        /// Sleeps on the specified condition variable and releases the specified lock as an atomic operation.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-sleepconditionvariablesrw
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SleepConditionVariableSRW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SleepConditionVariableSRW([In][Out]ref CONDITION_VARIABLE ConditionVariable,
            [In][Out]ref CRITICAL_SECTION CriticalSection, [In]uint dwMilliseconds, [In]uint Flags);

        /// <summary>
        /// <para>
        /// Attempts to enter a critical section without blocking.
        /// If the call is successful, the calling thread takes ownership of the critical section.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-tryentercriticalsection
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InterlockedIncrement", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool TryEnterCriticalSection([In][Out]ref CRITICAL_SECTION lpCriticalSection);


        /// <summary>
        /// <para>
        /// Waits until one or all of the specified objects are in the signaled state or the time-out interval elapses.
        /// To enter an alertable wait state, use the <see cref="WaitForMultipleObjectsEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-waitformultipleobjects
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WaitForMultipleObjects", SetLastError = true)]
        public static extern uint WaitForMultipleObjects([In]uint nCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)][In]IntPtr[] lpHandles,
            [MarshalAs(UnmanagedType.Bool)][In]bool bWaitAll, [In]uint dwMilliseconds);

        /// <summary>
        /// <para>
        /// Waits until one or all of the specified objects are in the signaled state,
        /// an I/O completion routine or asynchronous procedure call (APC) is queued to the thread, or the time-out interval elapses.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-waitformultipleobjectsex
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
        /// If this parameter is <see langword="true"/> and the thread is in the waiting state,
        /// the function returns when the system queues an I/O completion routine or APC, and the thread runs the routine or function.
        /// Otherwise, the function does not return and the completion routine or APC function is not executed.
        /// A completion routine is queued when the ReadFileEx or WriteFileEx function in which it was specified has completed.
        /// The wait function returns and the completion routine is called only if <paramref name="bAlertable"/> is <see langword="true"/>
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WaitForMultipleObjectsEx", SetLastError = true)]
        public static extern uint WaitForMultipleObjectsEx([In]uint nCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)][In]IntPtr[] lpHandles,
            [MarshalAs(UnmanagedType.Bool)][In]bool bWaitAll, [In]uint dwMilliseconds, [In]bool bAlertable);

        /// <summary>
        /// <para>
        /// Waits until the specified object is in the signaled state or the time-out interval elapses.
        /// To enter an alertable wait state, use the <see cref="WaitForSingleObjectEx"/> function.
        /// To wait for multiple objects, use <see cref="WaitForMultipleObjects"/>.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-waitforsingleobject
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WaitForSingleObject", SetLastError = true)]
        public static extern uint WaitForSingleObject([In]IntPtr hHandle, [In]uint dwMilliseconds);

        /// <summary>
        /// <para>
        /// Waits until the specified object is in the signaled state,
        /// an I/O completion routine or asynchronous procedure call (APC) is queued to the thread, or the time-out interval elapses.
        /// To wait for multiple objects, use the WaitForMultipleObjectsEx.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-waitforsingleobjectex
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WaitForSingleObjectEx", SetLastError = true)]
        public static extern uint WaitForSingleObjectEx([In]IntPtr hHandle, [In]uint dwMilliseconds, [In]bool bAlertable);

        /// <summary>
        /// <para>
        /// Wake all threads waiting on the specified condition variable.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-wakeallconditionvariable
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WakeAllConditionVariable", SetLastError = true)]
        public static extern void WakeAllConditionVariable([In][Out]ref CONDITION_VARIABLE ConditionVariable);

        /// <summary>
        /// <para>
        /// Wake a single thread waiting on the specified condition variable.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-wakeconditionvariable
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WakeConditionVariable", SetLastError = true)]
        public static extern void WakeConditionVariable([In][Out]ref CONDITION_VARIABLE ConditionVariable);
    }
}
