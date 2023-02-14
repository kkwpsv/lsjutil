using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.ULONG;
using static Lsj.Util.Win32.BaseTypes.WaitResult;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.FileCompletionNotificationModes;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.ThreadPoolFlags;
using static Lsj.Util.Win32.Enums.TP_CALLBACK_PRIORITY;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using FILETIME = Lsj.Util.Win32.Structs.FILETIME;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// Applications implement this callback if they call the <see cref="SetThreadpoolCallbackCleanupGroup"/> function
        /// to specify the callback to use when CloseThreadpoolCleanupGroup is called.
        /// The <see cref="PTP_CLEANUP_GROUP_CANCEL_CALLBACK"/> type defines a pointer to this callback function.
        /// CleanupGroupCancelCallback is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/nc-winnt-ptp_cleanup_group_cancel_callback"/>
        /// </para>
        /// </summary>
        /// <param name="ObjectContext">
        /// Optional application-defined data specified during creation of the object.
        /// </param>
        /// <param name="CleanupContext">
        /// Optional application-defined data specified using <see cref="CloseThreadpoolCleanupGroupMembers"/>.
        /// </param>
        public delegate void PtpCleanupGroupCancelCallback([In] PVOID ObjectContext, [In] PVOID CleanupContext);

        /// <summary>
        /// <para>
        /// Applications implement this callback if they call the <see cref="TrySubmitThreadpoolCallback"/> function to start a worker thread.
        /// The <see cref="PTP_SIMPLE_CALLBACK"/> type defines a pointer to this callback function.
        /// SimpleCallback is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms686295(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="Instance">
        /// A TP_CALLBACK_INSTANCE structure that defines the callback instance. Applications do not modify the members of this structure.
        /// This structure can be passed to one of the following functions:
        /// <see cref="CallbackMayRunLong"/>
        /// <see cref="DisassociateCurrentThreadFromCallback"/>
        /// <see cref="FreeLibraryWhenCallbackReturns"/>
        /// <see cref="LeaveCriticalSectionWhenCallbackReturns"/>
        /// <see cref="ReleaseMutexWhenCallbackReturns"/>
        /// <see cref="ReleaseSemaphoreWhenCallbackReturns"/>
        /// <see cref="SetEventWhenCallbackReturns"/>
        /// </param>
        /// <param name="Context">
        /// The application-defined data.
        /// </param>
        public delegate void Ptpsimplecallback([In] PTP_CALLBACK_INSTANCE Instance, [In] PVOID Context);

        /// <summary>
        /// <para>
        /// Applications implement this callback if they call the <see cref="SetThreadpoolWait"/> function to start a worker thread for the wait object.
        /// The <see cref="PTP_WAIT_CALLBACK"/> type defines a pointer to this callback function.
        /// WaitCallback is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms687017(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="Instance">
        /// A TP_CALLBACK_INSTANCE structure that defines the callback instance.
        /// Applications do not modify the members of this structure.
        /// This structure can be passed to one of the following functions:
        /// <see cref="CallbackMayRunLong"/>
        /// <see cref="DisassociateCurrentThreadFromCallback"/>
        /// <see cref="FreeLibraryWhenCallbackReturns"/>
        /// <see cref="LeaveCriticalSectionWhenCallbackReturns"/>
        /// <see cref="ReleaseMutexWhenCallbackReturns"/>
        /// <see cref="ReleaseSemaphoreWhenCallbackReturns"/>
        /// <see cref="SetEventWhenCallbackReturns"/>
        /// </param>
        /// <param name="Context">
        /// The application-defined data.
        /// </param>
        /// <param name="Wait">
        /// A TP_WAIT structure that defines the wait object that generated the callback.
        /// </param>
        /// <param name="WaitResult">
        /// The result of the wait operation.
        /// This parameter can be one of the following values from <see cref="WaitForMultipleObjects"/>:
        /// <see cref="WAIT_OBJECT_0"/>
        /// <see cref="WAIT_TIMEOUT"/>
        /// </param>
        public delegate void Ptpwaitcallback([In] PTP_CALLBACK_INSTANCE Instance, [In] PVOID Context, [In] PTP_WAIT Wait, [In] WaitResult WaitResult);

        /// <summary>
        /// <para>
        /// Applications implement this callback if they call the <see cref="StartThreadpoolIo"/> function
        /// to start a worker thread for the I/O completion object.
        /// The <see cref="PTP_WIN32_IO_CALLBACK"/> type defines a pointer to this callback function.
        /// IoCompletionCallback is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms684124(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="Instance">
        /// A TP_CALLBACK_INSTANCE structure that defines the callback instance.
        /// Applications do not modify the members of this structure.
        /// This structure can be passed to one of the following functions:
        /// <see cref="CallbackMayRunLong"/>
        /// <see cref="DisassociateCurrentThreadFromCallback"/>
        /// <see cref="FreeLibraryWhenCallbackReturns"/>
        /// <see cref="LeaveCriticalSectionWhenCallbackReturns"/>
        /// <see cref="ReleaseMutexWhenCallbackReturns"/>
        /// <see cref="ReleaseSemaphoreWhenCallbackReturns"/>
        /// <see cref="SetEventWhenCallbackReturns"/>
        /// </param>
        /// <param name="Context">
        /// The application-defined data.
        /// </param>
        /// <param name="Overlapped">
        /// A pointer to a variable that receives the address of the <see cref="OVERLAPPED"/> structure
        /// that was specified when the completed I/O operation was started.
        /// </param>
        /// <param name="IoResult">
        /// The result of the I/O operation.
        /// If the I/O is successful, this parameter is <see cref="NO_ERROR"/>.
        /// Otherwise, this parameter is one of the system error codes.
        /// </param>
        /// <param name="NumberOfBytesTransferred">
        /// The number of bytes transferred during the I/O operation that has completed.
        /// </param>
        /// <param name="Io">
        /// A TP_IO structure that defines the I/O completion object that generated the callback.
        /// </param>
        /// <remarks>
        /// If the file handle bound to the I/O completion object has the notification mode <see cref="FILE_SKIP_COMPLETION_PORT_ON_SUCCESS"/>
        /// and an asynchronous I/O operation returns immediately with success,
        /// the I/O completion callback function is not called and threadpool I/O notifications must be canceled.
        /// For more information, see <see cref="CancelThreadpoolIo"/>.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        public delegate void Ptpwin32iocallback([In] PTP_CALLBACK_INSTANCE Instance, [In] PVOID Context, [In] PVOID Overlapped,
            [In] SystemErrorCodes IoResult, [In] ULONG_PTR NumberOfBytesTransferred, [In] PTP_IO Io);

        /// <summary>
        /// <para>
        /// Applications implement this callback if they call the <see cref="SubmitThreadpoolWork"/> function
        /// to start a worker thread for the work object.
        /// The <see cref="PTP_WORK_CALLBACK"/> type defines a pointer to this callback function.
        /// WorkCallback is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms687396(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="Instance">
        /// A TP_CALLBACK_INSTANCE structure that defines the callback instance.
        /// Applications do not modify the members of this structure.
        /// This structure can be passed to one of the following functions:
        /// <see cref="SetEventWhenCallbackReturns"/>
        /// <see cref="ReleaseSemaphoreWhenCallbackReturns"/>
        /// <see cref="LeaveCriticalSectionWhenCallbackReturns"/>
        /// <see cref="ReleaseMutexWhenCallbackReturns"/>
        /// <see cref="FreeLibraryWhenCallbackReturns"/>
        /// <see cref="CallbackMayRunLong"/>
        /// <see cref="DisassociateCurrentThreadFromCallback"/>
        /// </param>
        /// <param name="Context">
        /// The application-defined data.
        /// </param>
        /// <param name="Work">
        /// A TP_WORK structure that defines the work object that generated the callback.
        /// </param>
        public delegate void Ptpworkcallback([In] PTP_CALLBACK_INSTANCE Instance, [In] PVOID Context, [In] PTP_WORK Work);

        /// <summary>
        /// <para>
        /// Applications implement this callback if they call the <see cref="SetThreadpoolTimer"/> function to start a worker thread for the timer object.
        /// The <see cref="PTP_TIMER_CALLBACK"/> type defines a pointer to this callback function.
        /// TimerCallback is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms686790(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="Instance">
        /// A TP_CALLBACK_INSTANCE structure that defines the callback instance.
        /// Applications do not modify the members of this structure.
        /// This structure can be passed to one of the following functions:
        /// <see cref="CallbackMayRunLong"/>, <see cref="DisassociateCurrentThreadFromCallback"/>, <see cref="FreeLibraryWhenCallbackReturns"/>,
        /// <see cref="LeaveCriticalSectionWhenCallbackReturns"/>, <see cref="ReleaseMutexWhenCallbackReturns"/>,
        /// <see cref="ReleaseSemaphoreWhenCallbackReturns"/>, <see cref="SetEventWhenCallbackReturns"/>
        /// </param>
        /// <param name="Context">
        /// The application-defined data.
        /// </param>
        /// <param name="Timer">
        /// A TP_TIMER structure that defines the timer object that generated the callback.
        /// </param>
        public delegate void Ptptimercallback([In] PTP_CALLBACK_INSTANCE Instance, [In] PVOID Context, [In] PTP_TIMER Timer);


        /// <summary>
        /// <para>
        /// Indicates that the callback may not return quickly.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-callbackmayrunlong"/>
        /// </para>
        /// </summary>
        /// <param name="pci">
        /// A TP_CALLBACK_INSTANCE structure that defines the callback instance. The structure is passed to the callback function.
        /// </param>
        /// <returns>
        /// The function returns <see cref="TRUE"/> if another thread in the thread pool is available for processing callbacks
        /// or the thread pool was able to spin up a new thread. In this case, the current callback function may use the current thread indefinitely.
        /// The function returns <see cref="FALSE"/> if another thread in the thread pool is not available to process callbacks
        /// and the thread pool was not able to spin up a new thread.
        /// The thread pool will attempt to spin up a new thread after a delay, but if the current callback function runs long,
        /// the thread pool may lose efficiency.
        /// </returns>
        /// <remarks>
        /// The thread pool may use this information to better determine when a new thread should be created.
        /// The <see cref="CallbackMayRunLong"/> function should be called only by the thread that is processing the callback.
        /// Calling this function from another thread may cause a race condition.
        /// The <see cref="CallbackMayRunLong"/> function always marks the callback as long-running,
        /// whether or not a thread is available for processing callbacks or the threadpool is able to allocate a new thread.
        /// Therefore, this function should be called only once, even if it returns <see cref="FALSE"/>.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallbackMayRunLong", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CallbackMayRunLong([In] PTP_CALLBACK_INSTANCE pci);

        /// <summary>
        /// <para>
        /// Cancels the notification from the <see cref="StartThreadpoolIo"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-cancelthreadpoolio"/>
        /// </para>
        /// </summary>
        /// <param name="pio">
        /// A TP_IO structure that defines the I/O completion object.
        /// The <see cref="CreateThreadpoolIo"/> function returns this structure.
        /// </param>
        /// <remarks>
        /// To prevent memory leaks, you must call the <see cref="CancelThreadpoolIo"/> function for either of the following scenarios:
        /// An overlapped (asynchronous) I/O operation fails (that is, the asynchronous I/O function call returns failure
        /// with an error code other than <see cref="ERROR_IO_PENDING"/>).
        /// An asynchronous I/O operation returns immediately with success and the file handle associated with the I/O completion object
        /// has the notification mode <see cref="FILE_SKIP_COMPLETION_PORT_ON_SUCCESS"/>.
        /// The file handle will not notify the I/O completion port and the associated I/O callback function will not be called.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher. 
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CancelThreadpoolIo", ExactSpelling = true, SetLastError = true)]
        public static extern void CancelThreadpoolIo([In] PTP_IO pio);

        /// <summary>
        /// <para>
        /// Closes the specified thread pool.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-closethreadpool"/>
        /// </para>
        /// </summary>
        /// <param name="ptpp">
        /// A TP_POOL structure that defines the thread pool.
        /// The <see cref="CreateThreadpool"/> function returns this structure.
        /// </param>
        /// <remarks>
        /// The thread pool is closed immediately if there are no outstanding work, I/O, timer, or wait objects that are bound to the pool;
        /// otherwise, the thread pool is released asynchronously after the outstanding objects are freed.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseThreadpool", ExactSpelling = true, SetLastError = true)]
        public static extern void CloseThreadpool([In] PTP_POOL ptpp);

        /// <summary>
        /// <para>
        /// Closes the specified cleanup group.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-closethreadpoolcleanupgroup"/>
        /// </para>
        /// </summary>
        /// <param name="ptpcg">
        /// A TP_CLEANUP_GROUP structure that defines the cleanup group.
        /// The <see cref="CreateThreadpoolCleanupGroup"/> returns this structure.
        /// </param>
        /// <remarks>
        /// The cleanup group must have no members when you call this function.
        /// For information on removing members of the group, see <see cref="CloseThreadpoolCleanupGroupMembers"/>.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseThreadpoolCleanupGroup", ExactSpelling = true, SetLastError = true)]
        public static extern void CloseThreadpoolCleanupGroup([In] PTP_CLEANUP_GROUP ptpcg);

        /// <summary>
        /// <para>
        /// Releases the members of the specified cleanup group, waits for all callback functions to complete,
        /// and optionally cancels any outstanding callback functions.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-closethreadpoolcleanupgroupmembers"/>
        /// </para>
        /// </summary>
        /// <param name="ptpcg">
        /// A TP_CLEANUP_GROUP structure that defines the cleanup group.
        /// The <see cref="CreateThreadpoolCleanupGroup"/> function returns this structure.
        /// </param>
        /// <param name="fCancelPendingCallbacks">
        /// If this parameter is <see cref="TRUE"/>, the function cancels outstanding callbacks that have not yet started.
        /// If this parameter is <see cref="FALSE"/>, the function waits for outstanding callback functions to complete.
        /// </param>
        /// <param name="pvCleanupContext">
        /// The application-defined data to pass to the application's cleanup group callback function.
        /// You can specify the callback function when you call <see cref="SetThreadpoolCallbackCleanupGroup"/>.
        /// </param>
        /// <remarks>
        /// The <see cref="CloseThreadpoolCleanupGroupMembers"/> function simplifies cleanup of thread pool callback objects by releasing,
        /// in a single operation, all work objects, wait objects, and timer objects that are members of the cleanup group.
        /// An object becomes a member of a cleanup group when the object is created with the threadpool callback environment
        /// that was specified when the cleanup group was created.
        /// For more information, see <see cref="CreateThreadpoolCleanupGroup"/>.
        /// The <see cref="CloseThreadpoolCleanupGroupMembers"/> function blocks until all currently executing callback functions finish.
        /// If <paramref name="fCancelPendingCallbacks"/> is <see cref="TRUE"/>, outstanding callbacks are canceled;
        /// otherwise, the function blocks until all outstanding callbacks also finish.
        /// After the <see cref="CloseThreadpoolCleanupGroupMembers"/> function returns, an application should not use any object
        /// that was a member of the cleanup group at the time <see cref="CloseThreadpoolCleanupGroupMembers"/> was called.
        /// Also, an application should not release any of the objects individually by calling a function such as <see cref="CloseThreadpoolWork"/>,
        /// because the objects have already been released.
        /// The <see cref="CloseThreadpoolCleanupGroupMembers"/> function does not close the cleanup group itself.
        /// Instead, the cleanup group persists until the <see cref="CloseThreadpoolCleanupGroup"/> function is called.
        /// Also, closing a cleanup group does not affect the associated threadpool callback environment.
        /// The callback environment persists until it is destroyed by calling DestroyThreadpoolEnvironment.
        /// As long as a cleanup group persists, new objects created with the cleanup group's associated threadpool
        /// callback environment are added to the cleanup group.
        /// This allows an application to reuse the cleanup group.
        /// However, it can lead to errors if the application does not synchronize code
        /// that calls <see cref="CloseThreadpoolCleanupGroupMembers"/> with code that creates new objects.
        /// For example, suppose a thread creates two threadpool work objects, Work1 and Work2.
        /// Another thread calls <see cref="CloseThreadpoolCleanupGroupMembers"/>. Depending on when the threads run, any of the following might occur:
        /// Work1 and Work2 are added to the cleanup group after its existing members were released. Code that submits Work1 and Work2 will succeed.
        /// Work1 is added to the cleanup group before its existing members are released, causing Work1 to be released along with other members.
        /// Then Work2 is added. Code that submits Work1 will generate an exception; code that submits Work2 will succeed.
        /// Work1 and Work2 are added to the cleanup group before its existing members are released, causing both Work1 and Work2 to be released.
        /// Code that submits Work1 or Work2 will generate an exception.
        /// To simply wait for or cancel pending work items without releasing them, use one of the threadpool callback functions:
        /// <see cref="WaitForThreadpoolIoCallbacks"/>, <see cref="WaitForThreadpoolTimerCallbacks"/>,
        /// <see cref="WaitForThreadpoolWaitCallbacks"/>, or <see cref="WaitForThreadpoolWorkCallbacks"/>.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseThreadpoolCleanupGroupMembers", ExactSpelling = true, SetLastError = true)]
        public static extern void CloseThreadpoolCleanupGroupMembers([In] PTP_CLEANUP_GROUP ptpcg, [In] BOOL fCancelPendingCallbacks,
            [In] PVOID pvCleanupContext);

        /// <summary>
        /// <para>
        /// Releases the specified I/O completion object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-closethreadpoolio"/>
        /// </para>
        /// </summary>
        /// <param name="pio">
        /// A TP_IO structure that defines the I/O completion object.
        /// The <see cref="CreateThreadpoolIo"/> function returns this structure.
        /// </param>
        /// <remarks>
        /// The I/O completion object is freed immediately if there are no outstanding callbacks;
        /// otherwise, the I/O completion object is freed asynchronously after the outstanding callbacks complete.
        /// You should close the associated file handle and wait for all outstanding overlapped I/O operations to complete
        /// before calling this function—you must not cause any more overlapped I/O operations to occur after calling this function.
        /// It may be necessary to cancel threadpool I/O notifications to prevent memory leaks.
        /// For more information, see <see cref="CancelThreadpoolIo"/>.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseThreadpoolIo", ExactSpelling = true, SetLastError = true)]
        public static extern void CloseThreadpoolIo([In] PTP_IO pio);

        /// <summary>
        /// <para>
        /// Releases the specified timer object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-closethreadpooltimer"/>
        /// </para>
        /// </summary>
        /// <param name="pti">
        /// A TP_TIMER structure that defines the timer object.
        /// The <see cref="CreateThreadpoolTimer"/> function returns this structure.
        /// </param>
        /// <remarks>
        /// The timer object is freed immediately if there are no outstanding callbacks;
        /// otherwise, the timer object is freed asynchronously after the outstanding callback functions complete.
        /// In some cases, callback functions might run after <see cref="CloseThreadpoolTimer"/> has been called.
        /// To prevent this behavior:
        /// Call the <see cref="SetThreadpoolTimer"/> function with the pftDueTime parameter set to <see cref="NullRef{FILETIME}"/>
        /// and the msPeriod and msWindowLength parameters set to 0.
        /// Call the <see cref="WaitForThreadpoolTimerCallbacks"/> function.
        /// Call <see cref="CloseThreadpoolTimer"/>.
        /// If there is a cleanup group associated with the timer object, it is not necessary to call this function;
        /// calling the <see cref="CloseThreadpoolCleanupGroupMembers"/> function releases the work,
        /// wait, and timer objects associated with the cleanup group.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseThreadpoolTimer", ExactSpelling = true, SetLastError = true)]
        public static extern void CloseThreadpoolTimer([In] PTP_TIMER pti);

        /// <summary>
        /// <para>
        /// Releases the specified wait object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-closethreadpoolwait"/>
        /// </para>
        /// </summary>
        /// <param name="pwa">
        /// A TP_WAIT structure that defines the wait object.
        /// The <see cref="CreateThreadpoolWait"/> function returns this structure.
        /// </param>
        /// <remarks>
        /// The wait object is freed immediately if there are no outstanding callbacks;
        /// otherwise, the timer object is freed asynchronously after the outstanding callbacks complete.
        /// If there is a cleanup group associated with the wait object, it is not necessary to call this function;
        /// calling the <see cref="CloseThreadpoolCleanupGroupMembers"/> function releases the work,
        /// wait, and timer objects associated with the cleanup group.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseThreadpoolWait", ExactSpelling = true, SetLastError = true)]
        public static extern void CloseThreadpoolWait([In] PTP_WAIT pwa);

        /// <summary>
        /// <para>
        /// Allocates a new pool of threads to execute callbacks.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-createthreadpool"/>
        /// </para>
        /// </summary>
        /// <param name="reserved">
        /// This parameter is reserved and must be <see cref="NULL"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns a TP_POOL structure representing the newly allocated thread pool.
        /// Applications do not modify the members of this structure.
        /// If function fails, it returns <see cref="NULL"/>.
        /// To retrieve extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// After creating the new thread pool, you should call <see cref="SetThreadpoolThreadMaximum"/> to specify the maximum number of threads
        /// that the pool can allocate and <see cref="SetThreadpoolThreadMinimum"/> to specify the minimum number of threads available in the pool.
        /// To use the pool, you must associate the pool with a callback environment.
        /// To create the callback environment, call <see cref="InitializeThreadpoolEnvironment"/>.
        /// Then, call <see cref="SetThreadpoolCallbackPool"/> to associate the pool with the callback environment.
        /// To release the thread pool, call <see cref="CloseThreadpool"/>.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateThreadpool", ExactSpelling = true, SetLastError = true)]
        public static extern PTP_POOL CreateThreadpool([In] PVOID reserved);

        /// <summary>
        /// <para>
        /// Releases the specified work object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-closethreadpoolwork"/>
        /// </para>
        /// </summary>
        /// <param name="pwk">
        /// A TP_WORK structure that defines the work object.
        /// The <see cref="CreateThreadpoolWork"/> function returns this structure.
        /// </param>
        /// <remarks>
        /// The work object is freed immediately if there are no outstanding callbacks;
        /// otherwise, the work object is freed asynchronously after the outstanding callbacks complete.
        /// If there is a cleanup group associated with the work object, it is not necessary to call this function;
        /// calling the <see cref="CloseThreadpoolCleanupGroupMembers"/> function releases the work,
        /// wait, and timer objects associated with the cleanup group.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseThreadpoolWork", ExactSpelling = true, SetLastError = true)]
        public static extern void CloseThreadpoolWork([In] PTP_WORK pwk);

        /// <summary>
        /// <para>
        /// Creates a new I/O completion object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-createthreadpoolio"/>
        /// </para>
        /// </summary>
        /// <param name="fl">
        /// The file handle to bind to this I/O completion object.
        /// </param>
        /// <param name="pfnio">
        /// The callback function to be called each time an overlapped I/O operation completes on the file.
        /// For details, see IoCompletionCallback.
        /// </param>
        /// <param name="pv">
        /// Optional application-defined data to pass to the callback function.
        /// </param>
        /// <param name="pcbe">
        /// A <see cref="TP_CALLBACK_ENVIRON"/> structure that defines the environment in which to execute the callback.
        /// The <see cref="InitializeThreadpoolEnvironment"/> function returns this structure.
        /// If this parameter is <see cref="NullRef{TP_CALLBACK_ENVIRON}"/>, the callback executes in the default callback environment.
        /// For more information, see <see cref="InitializeThreadpoolEnvironment"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns a TP_IO structure that defines the I/O object.
        /// Applications do not modify the members of this structure.
        /// If the function fails, it returns <see cref="NULL"/>.
        /// To retrieve extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// To begin receiving overlapped I/O completion callbacks, call the <see cref="StartThreadpoolIo"/> function.
        /// If the file handle bound to the I/O completion object has the notification mode <see cref="FILE_SKIP_COMPLETION_PORT_ON_SUCCESS"/>
        /// and an asychronous I/O operation returns immediately with success,
        /// the I/O completion callback function is not called and threadpool I/O notifications must be canceled.
        /// For more information, see <see cref="CancelThreadpoolIo"/>.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateThreadpoolIo", ExactSpelling = true, SetLastError = true)]
        public static extern PTP_IO CreateThreadpoolIo([In] HANDLE fl, [In] PTP_WIN32_IO_CALLBACK pfnio, [In] PVOID pv,
            [In][Out] ref TP_CALLBACK_ENVIRON pcbe);

        /// <summary>
        /// <para>
        /// Creates a new timer object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-createthreadpooltimer"/>
        /// </para>
        /// </summary>
        /// <param name="pfnti">
        /// The callback function to call each time the timer object expires.
        /// For details, see <see cref="PTP_TIMER_CALLBACK"/>.
        /// </param>
        /// <param name="pv">
        /// Optional application-defined data to pass to the callback function.
        /// </param>
        /// <param name="pcbe">
        /// A <see cref="TP_CALLBACK_ENVIRON"/> structure that defines the environment in which to execute the callback.
        /// The <see cref="InitializeThreadpoolEnvironment"/> function returns this structure.
        /// If this parameter is <see cref="NullRef{TP_CALLBACK_ENVIRON}"/>, the callback executes in the default callback environment.
        /// For more information, see <see cref="InitializeThreadpoolEnvironment"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns a TP_TIMER structure that defines the timer object.
        /// Applications do not modify the members of this structure.
        /// If the function fails, it returns <see cref="IntPtr.Zero"/>.
        /// To retrieve extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// To set the timer object, call the <see cref="SetThreadpoolTimer"/> function.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateThreadpoolTimer", ExactSpelling = true, SetLastError = true)]
        public static extern PTP_TIMER CreateThreadpoolTimer([MarshalAs(UnmanagedType.FunctionPtr)][In] PTP_TIMER_CALLBACK pfnti,
          [In] PVOID pv, [In][Out] ref TP_CALLBACK_ENVIRON pcbe);

        /// <summary>
        /// <para>
        /// Creates a cleanup group that applications can use to track one or more thread pool callbacks.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-createthreadpoolcleanupgroup"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// If the function succeeds, it returns a TP_CLEANUP_GROUP structure of the newly allocated cleanup group.
        /// Applications do not modify the members of this structure.
        /// If function fails, it returns <see cref="NULL"/>.
        /// To retrieve extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// After creating the cleanup group, call <see cref="SetThreadpoolCallbackCleanupGroup"/> to associate the cleanup group with a callback environment.
        /// A member is added to the group each time you call one of the following functions:
        /// <see cref="CreateThreadpoolIo"/>
        /// <see cref="CreateThreadpoolTimer"/>
        /// <see cref="CreateThreadpoolWait"/>
        /// <see cref="CreateThreadpoolWork"/>
        /// You use one of the following corresponding close functions to remove a member from the group.
        /// <see cref="CloseThreadpoolIo"/>
        /// <see cref="CloseThreadpoolTimer"/>
        /// <see cref="CloseThreadpoolWait"/>
        /// <see cref="CloseThreadpoolWork"/>
        /// To close all the callbacks, call <see cref="CloseThreadpoolCleanupGroupMembers"/>.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateThreadpoolCleanupGroup", ExactSpelling = true, SetLastError = true)]
        public static extern PTP_CLEANUP_GROUP CreateThreadpoolCleanupGroup();

        /// <summary>
        /// <para>
        /// Creates a new wait object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-createthreadpoolwait"/>
        /// </para>
        /// </summary>
        /// <param name="pfnwa">
        /// The callback function to call when the wait completes or times out.
        /// For details, see WaitCallback.
        /// </param>
        /// <param name="pv">
        /// Optional application-defined data to pass to the callback function.
        /// </param>
        /// <param name="pcbe">
        /// A <see cref="TP_CALLBACK_ENVIRON"/> structure that defines the environment in which to execute the callback.
        /// The <see cref="InitializeThreadpoolEnvironment"/> function returns this structure.
        /// If this parameter is <see cref="IntPtr.Zero"/>, the callback executes in the default callback environment.
        /// For more information, see <see cref="InitializeThreadpoolEnvironment"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns a TP_WAIT structure that defines the wait object.
        /// Applications do not modify the members of this structure.
        /// If the function fails, it returns <see cref="NULL"/>.
        /// To retrieve extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// To set the wait object, call the <see cref="SetThreadpoolWait"/> function.
        /// The work item and all functions it calls must be thread-pool safe.
        /// Therefore, you cannot call an asynchronous call that requires a persistent thread,
        /// such as the <see cref="RegNotifyChangeKeyValue"/> function, from the default callback environment.
        /// Instead, set the thread pool maximum equal to the thread pool minimum
        /// using the <see cref="SetThreadpoolThreadMaximum"/> and <see cref="SetThreadpoolThreadMinimum"/> functions,
        /// or create your own thread using the <see cref="CreateThread"/> function.
        /// Windows 8:  <see cref="RegNotifyChangeKeyValue"/> can be called from a work item
        /// by setting the <see cref="REG_NOTIFY_THREAD_AGNOSTIC"/> flag.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateThreadpoolWait", ExactSpelling = true, SetLastError = true)]
        public static extern PTP_WAIT CreateThreadpoolWait([In] PTP_WAIT_CALLBACK pfnwa, [In] PVOID pv, [In][Out] ref TP_CALLBACK_ENVIRON pcbe);

        /// <summary>
        /// <para>
        /// Creates a new work object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-createthreadpoolwork"/>
        /// </para>
        /// </summary>
        /// <param name="pfnwk">
        /// The callback function.
        /// A worker thread calls this callback each time you call <see cref="SubmitThreadpoolWork"/> to post the work object.
        /// For details, see WorkCallback.
        /// </param>
        /// <param name="pv">
        /// Optional application-defined data to pass to the callback function.
        /// </param>
        /// <param name="pcbe">
        /// A <see cref="TP_CALLBACK_ENVIRON"/> structure that defines the environment in which to execute the callback.
        /// The <see cref="InitializeThreadpoolEnvironment"/> function returns this structure.
        /// If this parameter is <see cref="NullRef{TP_CALLBACK_ENVIRON}"/>, the callback executes in the default callback environment.
        /// For more information, see <see cref="InitializeThreadpoolEnvironment"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns a TP_WORK structure that defines the work object.
        /// Applications do not modify the members of this structure.
        /// If the function fails, it returns <see cref="NULL"/>.
        /// To retrieve extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateThreadpoolWork", ExactSpelling = true, SetLastError = true)]
        public static extern PTP_WORK CreateThreadpoolWork([In] PTP_WORK_CALLBACK pfnwk, [In] PVOID pv, [In][Out] ref TP_CALLBACK_ENVIRON pcbe);

        /// <summary>
        /// <para>
        /// Creates a queue for timers.
        /// Timer-queue timers are lightweight objects that enable you to specify a callback function to be called at a specified time.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoollegacyapiset/nf-threadpoollegacyapiset-createtimerqueue"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the timer queue.
        /// This handle can be used only in functions that require a handle to a timer queue.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// To add a timer to the queue, call the <see cref="CreateTimerQueueTimer"/> function.
        /// To remove a timer from the queue, call the <see cref="DeleteTimerQueueTimer"/> function.
        /// When you are finished with the queue of timers, call the <see cref="DeleteTimerQueueEx"/> function to delete the timer queue.
        /// Any pending timers in the queue are canceled and deleted.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0500 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateTimerQueue", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE CreateTimerQueue();

        /// <summary>
        /// <para>
        /// Creates a timer-queue timer.
        /// This timer expires at the specified due time, then after every specified period.
        /// When the timer expires, the callback function is called.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoollegacyapiset/nf-threadpoollegacyapiset-createtimerqueuetimer"/>
        /// </para>
        /// </summary>
        /// <param name="phNewTimer">
        /// A pointer to a buffer that receives a handle to the timer-queue timer on return.
        /// When this handle has expired and is no longer required, release it by calling <see cref="DeleteTimerQueueTimer"/>.
        /// </param>
        /// <param name="TimerQueue">
        /// A handle to the timer queue. This handle is returned by the <see cref="CreateTimerQueue"/> function.
        /// If this parameter is <see cref="NULL"/>, the timer is associated with the default timer queue.
        /// </param>
        /// <param name="Callback">
        /// A pointer to the application-defined function of type <see cref="WAITORTIMERCALLBACK"/> to be executed when the timer expires.
        /// For more information, see WaitOrTimerCallback.
        /// </param>
        /// <param name="DueTime">
        /// The amount of time in milliseconds relative to the current time that must elapse before the timer is signaled for the first time.
        /// </param>
        /// <param name="Period">
        /// The period of the timer, in milliseconds.
        /// If this parameter is zero, the timer is signaled once.
        /// If this parameter is greater than zero, the timer is periodic.
        /// A periodic timer automatically reactivates each time the period elapses, until the timer is canceled.
        /// </param>
        /// <param name="Flags">
        /// This parameter can be one or more of the following values from WinNT.h.
        /// <see cref="WT_EXECUTEDEFAULT"/>, <see cref="WT_EXECUTEINTIMERTHREAD"/>, <see cref="WT_EXECUTEINIOTHREAD"/>,
        /// <see cref="WT_EXECUTEINPERSISTENTTHREAD"/>, <see cref="WT_EXECUTELONGFUNCTION"/>, <see cref="WT_EXECUTEONLYONCE"/>,
        /// <see cref="WT_TRANSFER_IMPERSONATION"/>
        /// </param>
        /// <param name="Parameter">
        /// A single parameter value that will be passed to the callback function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If the DueTime and Period parameters are both nonzero, the timer will be signaled first at the due time, then periodically.
        /// The callback is called every time the period elapses, whether or not the previous callback has finished executing.
        /// Callback functions are queued to the thread pool.
        /// These threads are subject to scheduling delays, so the timing can vary depending on what else is happening in the application or the system.
        /// The time that the system spends in sleep or hibernation does not count toward the expiration of the timer.
        /// The timer is signaled when the cumulative amount of elapsed time the system spends in the waking state matches the timer's due time or period.
        /// Windows Server 2003 and Windows XP:
        /// The time that the system spends in sleep or hibernation counts toward the expiration of the timer.
        /// If the timer expires while the system is sleeping, the timer is signaled immediately when the system wakes.
        /// To cancel a timer, call the <see cref="DeleteTimerQueueTimer"/> function.
        /// To cancel all timers in a timer queue, call the <see cref="DeleteTimerQueueEx"/> function.
        /// By default, the thread pool has a maximum of 500 threads.
        /// To raise this limit, use the <see cref="WT_SET_MAX_THREADPOOL_THREAD"/> macro defined in WinNT.h.
        /// <code>
        /// #define WT_SET_MAX_THREADPOOL_THREADS(Flags,Limit) \
        /// ((Flags)|=(Limit)&lt;&lt;16)
        /// </code>
        /// Use this macro when specifying the <paramref name="Flags"/> parameter.
        /// The macro parameters are the desired flags and the new limit (up to (2&lt;&lt;16)-1 threads).
        /// However, note that your application can improve its performance by keeping the number of worker threads low.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0500 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateTimerQueueTimer", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CreateTimerQueueTimer([Out] out HANDLE phNewTimer, [In] HANDLE TimerQueue, [In] WAITORTIMERCALLBACK Callback,
            [In] PVOID DueTime, [In] DWORD Period, [In] ThreadPoolFlags Flags, [In] ULONG Parameter);

        /// <summary>
        /// <para>
        /// Deletes a timer queue. Any pending timers in the queue are canceled and deleted.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoollegacyapiset/nf-threadpoollegacyapiset-deletetimerqueueex"/>
        /// </para>
        /// </summary>
        /// <param name="TimerQueue">
        /// A handle to the timer queue. This handle is returned by the <see cref="CreateTimerQueue"/> function.
        /// </param>
        /// <param name="CompletionEvent">
        /// A handle to the event object to be signaled when the function is successful and all callback functions have completed.
        /// This parameter can be <see cref="NULL"/>.
        /// If this parameter is <see cref="INVALID_HANDLE_VALUE"/>, the function waits for all callback functions to complete before returning.
        /// If this parameter is <see cref="NULL"/>, the function marks the timer for deletion and returns immediately.
        /// However, most callers should wait for the callback function to complete so they can perform any needed cleanup.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Do not make blocking calls to <see cref="DeleteTimerQueueEx"/> from within a timer callback.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0500 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteTimerQueueEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DeleteTimerQueueEx([In] HANDLE TimerQueue, [In] HANDLE CompletionEvent);

        /// <summary>
        /// <para>
        /// Removes a timer from the timer queue and optionally waits for currently running timer callback functions to complete before deleting the timer.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoollegacyapiset/nf-threadpoollegacyapiset-deletetimerqueuetimer"/>
        /// </para>
        /// </summary>
        /// <param name="TimerQueue">
        /// A handle to the timer queue.
        /// This handle is returned by the <see cref="CreateTimerQueue"/> function.
        /// If the timer was created using the default timer queue, this parameter should be <see cref="NULL"/>.
        /// </param>
        /// <param name="Timer">
        /// A handle to the timer-queue timer.
        /// This handle is returned by the <see cref="CreateTimerQueueTimer"/> function.
        /// </param>
        /// <param name="CompletionEvent">
        /// A handle to the event object to be signaled when the system has canceled the timer and all callback functions have completed.
        /// This parameter can be <see cref="NULL"/>.
        /// If this parameter is <see cref="INVALID_HANDLE_VALUE"/>, 
        /// the function waits for any running timer callback functions to complete before returning.
        /// If this parameter is <see cref="NULL"/>, the function marks the timer for deletion and returns immediately.
        /// If the timer has already expired, the timer callback function will run to completion.
        /// However, there is no notification sent when the timer callback function has completed.
        /// Most callers should not use this option, and should wait for running timer callback functions to complete
        /// so they can perform any needed cleanup.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If the error code is <see cref="ERROR_IO_PENDING"/>, it is not necessary to call this function again.
        /// For any other error, you should retry the call.
        /// </returns>
        /// <remarks>
        /// This function cannot be called while the thread is using impersonation.
        /// The resulting behavior is undefined.
        /// You can set <paramref name="CompletionEvent"/> to <see cref="INVALID_HANDLE_VALUE"/> when calling this function
        /// from within the timer callback of another timer as long as the callback function is not executed in the timer thread.
        /// However, a deadlock may occur if two callback functions attempt a blocking <see cref="DeleteTimerQueueTimer"/> call on each others' timers.
        /// Furthermore, you cannot make a blocking deletion call on a timer associated with the callback.
        /// Be careful when making a blocking <see cref="DeleteTimerQueueTimer"/> call on a persistent thread.
        /// If the timer being deleted was created with <see cref="WT_EXECUTEINPERSISTENTTHREAD"/>, a deadlock may occur.
        /// If there are outstanding callback functions and <paramref name="CompletionEvent"/> is <see cref="NULL"/>,
        /// the function will fail and set the error code to <see cref="ERROR_IO_PENDING"/>.
        /// This indicates that there are outstanding callback functions.
        /// Those callbacks either will execute or are in the middle of executing.
        /// The timer is cleaned up when the callback function is finished executing.
        /// To cancel all timers in a timer queue, call the <see cref="DeleteTimerQueueEx"/> function.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0500 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteTimerQueueTimer", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DeleteTimerQueueTimer([In] HANDLE TimerQueue, [In] HANDLE Timer, [In] HANDLE CompletionEvent);

        /// <summary>
        /// <para>
        /// Deletes the specified callback environment.
        /// Call this function when the callback environment is no longer needed for creating new thread pool objects.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-destroythreadpoolenvironment"/>
        /// </para>
        /// </summary>
        /// <param name="pcbe">
        /// A <see cref="TP_CALLBACK_ENVIRON"/> structure that defines the callback environment.
        /// The <see cref="InitializeThreadpoolEnvironment"/> function returns this structure.
        /// </param>
        /// <remarks>
        /// This function is implemented as an inline function.
        /// </remarks>
        public static void DestroyThreadpoolEnvironment([In][Out] ref TP_CALLBACK_ENVIRON pcbe)
        {
        }

        /// <summary>
        /// <para>
        /// Removes the association between the currently executing callback function and the object that initiated the callback.
        /// The current thread will no longer count as executing a callback on behalf of the object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-disassociatecurrentthreadfromcallback"/>
        /// </para>
        /// </summary>
        /// <param name="pci">
        /// A TP_CALLBACK_INSTANCE structure that defines the callback instance.
        /// The structure is passed to the callback function.
        /// </param>
        /// <remarks>
        /// If this is the last thread executing a callback on behalf of the object,
        /// any threads waiting for the object's callbacks to complete will be released.
        /// The thread remains associated with the object's cleanup group until the thread returns to the thread pool.
        /// This lets DLL shutdown routines safely synchronize with outstanding callbacks
        /// and proceed with unloading the DLL's code when all callbacks have completed.
        /// The callback-generating object remains valid for the duration of the callback.
        /// The callback object may be reused or released (although synchronization with cleanup group release is still required).
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DisassociateCurrentThreadFromCallback", ExactSpelling = true, SetLastError = true)]
        public static extern void DisassociateCurrentThreadFromCallback([In] PTP_CALLBACK_INSTANCE pci);

        /// <summary>
        /// <para>
        /// Specifies the DLL that the thread pool will unload when the current callback completes.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-freelibrarywhencallbackreturns"/>
        /// </para>
        /// </summary>
        /// <param name="pci">
        /// A TP_CALLBACK_INSTANCE structure that defines the callback instance.
        /// The structure is passed to the callback function.
        /// </param>
        /// <param name="mod">
        /// A handle to the DLL.
        /// </param>
        /// <remarks>
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FreeLibraryWhenCallbackReturns", ExactSpelling = true, SetLastError = true)]
        public static extern void FreeLibraryWhenCallbackReturns([In] PTP_CALLBACK_INSTANCE pci, [In] HMODULE mod);

        /// <summary>
        /// <para>
        /// Initializes a callback environment.
        /// </para>
        /// <para>
        /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-initializethreadpoolenvironment
        /// </para>
        /// </summary>
        /// <param name="pcbe">
        /// A TP_CALLBACK_ENVIRON structure that defines a callback environment.
        /// </param>
        /// <remarks>
        /// By default, a callback executes in the default thread pool for the process.
        /// No cleanup group is associated with the callback environment, the caller is responsible for
        /// keeping the callback's DLL loaded while there are outstanding callbacks,
        /// and the callback is expected to run in a reasonable amount of time for the application.
        /// Create a callback environment if you plan to call one of the following functions to modify the environment:
        /// <see cref="SetThreadpoolCallbackCleanupGroup"/>
        /// <see cref="SetThreadpoolCallbackLibrary"/>
        /// <see cref="SetThreadpoolCallbackPool"/>
        /// <see cref="SetThreadpoolCallbackPriority"/>
        /// <see cref="SetThreadpoolCallbackRunsLong"/>
        /// To use the default callback environment, set the optional callback environment parameter to <see cref="NULL"/>
        /// when calling one of the following functions:
        /// <see cref="CreateThreadpoolIo"/>
        /// <see cref="CreateThreadpoolTimer"/>
        /// <see cref="CreateThreadpoolWait"/>
        /// <see cref="CreateThreadpoolWork"/>
        /// <see cref="TrySubmitThreadpoolCallback"/>
        /// The <see cref="InitializeThreadpoolEnvironment"/> function is implemented as an inline function.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        public static void InitializeThreadpoolEnvironment([In][Out] ref TP_CALLBACK_ENVIRON pcbe)
        {
            pcbe.Version = 3;
            pcbe.Pool = NULL;
            pcbe.CleanupGroup = NULL;
            pcbe.CleanupGroupCancelCallback = (PTP_CLEANUP_GROUP_CANCEL_CALLBACK)NULL;
            pcbe.RaceDll = NULL;
            pcbe.ActivationContext = NULL;
            pcbe.FinalizationCallback = (PTP_SIMPLE_CALLBACK)NULL;
            pcbe.u.Flags = 0;
            pcbe.CallbackPriority = TP_CALLBACK_PRIORITY_NORMAL;
            pcbe.Size = SizeOf<TP_CALLBACK_ENVIRON>();

        }

        /// <summary>
        /// <para>
        /// Specifies the critical section that the thread pool will release when the current callback completes.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-leavecriticalsectionwhencallbackreturns"/>
        /// </para>
        /// </summary>
        /// <param name="pci">
        /// A TP_CALLBACK_INSTANCE structure that defines the callback instance.
        /// The structure is passed to the callback function.
        /// </param>
        /// <param name="pcs">
        /// The critical section.
        /// </param>
        /// <remarks>
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "LeaveCriticalSectionWhenCallbackReturns", ExactSpelling = true, SetLastError = true)]
        public static extern void LeaveCriticalSectionWhenCallbackReturns([In] PTP_CALLBACK_INSTANCE pci, [In] in CRITICAL_SECTION pcs);

        /// <summary>
        /// <para>
        /// Determines whether the specified timer object is currently set.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-isthreadpooltimerset"/>
        /// </para>
        /// </summary>
        /// <param name="pti">
        /// A TP_TIMER structure that defines the timer object.
        /// The <see cref="CreateThreadpoolTimer"/> function returns this structure.
        /// </param>
        /// <returns>
        /// The return value is <see cref="TRUE"/> if the timer is set; otherwise, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsThreadpoolTimerSet", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsThreadpoolTimerSet([In] PTP_TIMER pti);

        /// <summary>
        /// <para>
        /// Specifies the mutex that the thread pool will release when the current callback completes.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-releasemutexwhencallbackreturns"/>
        /// </para>
        /// </summary>
        /// <param name="pci">
        /// A TP_CALLBACK_INSTANCE structure that defines the callback instance.
        /// The structure is passed to the callback function.
        /// </param>
        /// <param name="mut">
        /// A handle to the mutex.
        /// </param>
        /// <remarks>
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ReleaseMutexWhenCallbackReturns", ExactSpelling = true, SetLastError = true)]
        public static extern void ReleaseMutexWhenCallbackReturns([In] PTP_CALLBACK_INSTANCE pci, [In] HANDLE mut);

        /// <summary>
        /// <para>
        /// Specifies the semaphore that the thread pool will release when the current callback completes.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-releasesemaphorewhencallbackreturns"/>
        /// </para>
        /// </summary>
        /// <param name="pci">
        /// A TP_CALLBACK_INSTANCE structure that defines the callback instance.
        /// The structure is passed to the callback function.
        /// </param>
        /// <param name="sem">
        /// A handle to the semaphore.
        /// </param>
        /// <param name="crel">
        /// The amount by which to increment the semaphore object's count.
        /// </param>
        /// <remarks>
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ReleaseSemaphoreWhenCallbackReturns", ExactSpelling = true, SetLastError = true)]
        public static extern void ReleaseSemaphoreWhenCallbackReturns([In] PTP_CALLBACK_INSTANCE pci, [In] HANDLE sem, [In] DWORD crel);

        /// <summary>
        /// <para>
        /// Specifies the event that the thread pool will set when the current callback completes.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-seteventwhencallbackreturns"/>
        /// </para>
        /// </summary>
        /// <param name="pci">
        /// A TP_CALLBACK_INSTANCE structure that defines the callback instance. The structure is passed to the callback function.
        /// </param>
        /// <param name="evt">
        /// A handle to the event to be set.
        /// </param>
        /// <remarks>
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetEventWhenCallbackReturns", ExactSpelling = true, SetLastError = true)]
        public static extern void SetEventWhenCallbackReturns([In] PTP_CALLBACK_INSTANCE pci, [In] HANDLE evt);

        /// <summary>
        /// <para>
        /// Associates the specified cleanup group with the specified callback environment.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-setthreadpoolcallbackcleanupgroup"/>
        /// </para>
        /// </summary>
        /// <param name="pcbe">
        /// A <see cref="TP_CALLBACK_ENVIRON"/> structure that defines the callback environment.
        /// The <see cref="InitializeThreadpoolEnvironment"/> function returns this structure.
        /// </param>
        /// <param name="ptpcg">
        /// A TP_CLEANUP_GROUP structure that defines the cleanup group.
        /// The <see cref="CreateThreadpoolCleanupGroup"/> function returns this structure.
        /// </param>
        /// <param name="pfng">
        /// The cleanup callback to be called if the cleanup group is canceled before the associated object is released.
        /// The function is called when you call <see cref="CloseThreadpoolCleanupGroupMembers"/>.
        /// </param>
        /// <remarks>
        /// This function is implemented as an inline function.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        public static void SetThreadpoolCallbackCleanupGroup([In][Out] ref TP_CALLBACK_ENVIRON pcbe, [In] PTP_CLEANUP_GROUP ptpcg,
            [In] PTP_CLEANUP_GROUP_CANCEL_CALLBACK pfng)
        {
            pcbe.CleanupGroup = ptpcg;
            pcbe.CleanupGroupCancelCallback = pfng;
        }

        /// <summary>
        /// <para>
        /// Sets the thread pool to be used when generating callbacks.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-setthreadpoolcallbackpool"/>
        /// </para>
        /// </summary>
        /// <param name="pcbe">
        /// A <see cref="TP_CALLBACK_ENVIRON"/> structure that defines the callback environment.
        /// The <see cref="InitializeThreadpoolEnvironment"/> function returns this structure.
        /// </param>
        /// <param name="ptpp">
        /// A TP_POOL structure that defines the thread pool.
        /// The <see cref="CreateThreadpool"/> function returns this structure.
        /// </param>
        /// <remarks>
        /// If you do not specify a thread pool, the global thread pool is used.
        /// This function is implemented as an inline function.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        public static void SetThreadpoolCallbackPool([In][Out] ref TP_CALLBACK_ENVIRON pcbe, [In] PTP_POOL ptpp)
        {
            pcbe.Pool = ptpp;
        }

        /// <summary>
        /// <para>
        /// Ensures that the specified DLL remains loaded as long as there are outstanding callbacks.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-setthreadpoolcallbacklibrary"/>
        /// </para>
        /// </summary>
        /// <param name="pcbe">
        /// A <see cref="TP_CALLBACK_ENVIRON"/> structure that defines the callback environment.
        /// The <see cref="InitializeThreadpoolEnvironment"/> function returns this structure.
        /// </param>
        /// <param name="mod">
        /// A handle to the DLL.
        /// </param>
        /// <remarks>
        /// You should call this function if a callback might acquire the loader lock.
        /// This prevents a deadlock from occurring when one thread in DllMain is waiting for the callback to end,
        /// and another thread that is executing the callback attempts to acquire the loader lock.
        /// If the DLL containing the callback might be unloaded, the cleanup code in DllMain must cancel outstanding callbacks before releasing the object.
        /// Managing callbacks created with a <see cref="TP_CALLBACK_ENVIRON"/> that specifies a callback library is somewhat processing-intensive.
        /// You should consider other options for ensuring that the library is not unloaded while callbacks are executing,
        /// or to guarantee that callbacks which may be executing do not acquire the loader lock.
        /// The thread pool assumes ownership of the library reference supplied to this function.
        /// The caller should not call <see cref="FreeLibrary"/> on a module handle after passing it to this function.
        /// This function is implemented as an inline function.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        public static void SetThreadpoolCallbackLibrary([In][Out] ref TP_CALLBACK_ENVIRON pcbe, [In] PVOID mod)
        {
            pcbe.RaceDll = mod;
        }

        /// <summary>
        /// <para>
        /// Indicates that callbacks associated with this callback environment may not return quickly.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-setthreadpoolcallbackrunslong"/>
        /// </para>
        /// </summary>
        /// <param name="pcbe">
        /// A <see cref="TP_CALLBACK_ENVIRON"/> structure that defines the callback environment.
        /// The <see cref="InitializeThreadpoolEnvironment"/> function returns this structure.
        /// </param>
        /// <remarks>
        /// The thread pool may use this information to better determine when a new thread should be created.
        /// This function is implemented as an inline function.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        public static void SetThreadpoolCallbackRunsLong([In][Out] ref TP_CALLBACK_ENVIRON pcbe)
        {
            pcbe.u.Flags |= 0xF000;
        }

        /// <summary>
        /// <para>
        /// ets the maximum number of threads that the specified thread pool can allocate to process callbacks.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-setthreadpoolthreadmaximum"/>
        /// </para>
        /// </summary>
        /// <param name="ptpp">
        /// A TP_POOL structure that defines the thread pool.
        /// The <see cref="CreateThreadpool"/> function returns this structure.
        /// </param>
        /// <param name="cthrdMost">
        /// The maximum number of threads.
        /// </param>
        /// <remarks>
        /// To specify the minimum number of threads available in the pool, call <see cref="SetThreadpoolThreadMinimum"/>.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetThreadpoolThreadMaximum", ExactSpelling = true, SetLastError = true)]
        public static extern void SetThreadpoolThreadMaximum([In] PTP_POOL ptpp, [In] DWORD cthrdMost);

        /// <summary>
        /// <para>
        /// Sets the minimum number of threads that the specified thread pool must make available to process callbacks.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-setthreadpoolthreadminimum"/>
        /// </para>
        /// </summary>
        /// <param name="ptpp">
        /// A TP_POOL structure that defines the thread pool.
        /// The <see cref="CreateThreadpool"/> function returns this structure.
        /// </param>
        /// <param name="cthrdMic">
        /// The minimum number of threads.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To retrieve extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// To specify the maximum number of threads that the pool may allocate, call <see cref="SetThreadpoolThreadMaximum"/>.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetThreadpoolThreadMinimum", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetThreadpoolThreadMinimum([In] PTP_POOL ptpp, [In] DWORD cthrdMic);

        /// <summary>
        /// <para>
        /// Sets the timer object—, replacing the previous timer, if any.
        /// A worker thread calls the timer object's callback after the specified timeout expires.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-setthreadpooltimer"/>
        /// </para>
        /// </summary>
        /// <param name="pti">
        /// A pointer to a TP_TIMER structure that defines the timer object to set.
        /// The <see cref="CreateThreadpoolTimer"/> function returns this structure.
        /// </param>
        /// <param name="pftDueTime">
        /// A pointer to a <see cref="FILETIME"/> structure that specifies the absolute or relative time at which the timer should expire.
        /// If positive or zero, it indicates the absolute time since January 1, 1601 (UTC), measured in 100 nanosecond units.
        /// If negative, it indicates the amount of time to wait relative to the current time.
        /// For more information about time values, see File Times.
        /// If this parameter is <see cref="NullRef{FILETIME}"/>, the timer object will cease to queue new callbacks
        /// (but callbacks already queued will still occur).
        /// Note that if this parameter is zero, the timer will expire immediately.
        /// </param>
        /// <param name="msPeriod">
        /// The timer period, in milliseconds.
        /// If this parameter is zero, the timer is signaled once.
        /// If this parameter is greater than zero, the timer is periodic.
        /// A periodic timer automatically reactivates each time the period elapses, until the timer is canceled.
        /// </param>
        /// <param name="msWindowLength">
        /// The maximum amount of time the system can delay before calling the timer callback.
        /// If this parameter is set, the system can batch calls to conserve power.
        /// </param>
        /// <remarks>
        /// Setting the timer cancels the previous timer, if any.
        /// In some cases, callback functions might run after an application closes the threadpool timer.
        /// To prevent this behavior, an application should call <see cref="SetThreadpoolTimer"/>
        /// with the <paramref name="pftDueTime"/> parameter set to <see cref="NullRef{FILETIME}"/>
        /// and the <paramref name="msPeriod"/> and <paramref name="msWindowLength"/> parameters set to 0.
        /// For more information, see <see cref="CloseThreadpoolTimer"/>.
        /// If the due time specified by <paramref name="pftDueTime"/> is relative, the time that the system spends in sleep
        /// or hibernation does not count toward the expiration of the timer.
        /// The timer is signaled when the cumulative amount of elapsed time the system spends in the waking state
        /// equals the timer's relative due time or period.
        /// If the due time specified by <paramref name="pftDueTime"/> is absolute, the time that the system spends in sleep
        /// or hibernation does count toward the expiration of the timer.
        /// If the timer expires while the system is sleeping, the timer is signaled immediately when the system wakes.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetThreadpoolTimer", ExactSpelling = true, SetLastError = true)]
        public static extern void SetThreadpoolTimer([In] PTP_TIMER pti, [In] in FILETIME pftDueTime, [In] DWORD msPeriod, [In] DWORD msWindowLength);

        /// <summary>
        /// <para>
        /// Sets the wait object—replacing the previous wait object, if any.
        /// A worker thread calls the wait object's callback function after the handle becomes signaled or after the specified timeout expires.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-setthreadpoolwait"/>
        /// </para>
        /// </summary>
        /// <param name="pwa">
        /// A pointer to a TP_WAIT structure that defines the wait object.
        /// The <see cref="CreateThreadpoolWait"/> function returns this structure.
        /// </param>
        /// <param name="h">
        /// If this parameter is <see cref="NULL"/>, the wait object will cease to queue new callbacks
        /// (but callbacks already queued will still occur).
        /// If this parameter is not <see cref="NULL"/>, it must refer to a valid waitable object.
        /// If this handle is closed while the wait is still pending, the function's behavior is undefined.
        /// If the wait is still pending and the handle must be closed,
        /// use <see cref="CloseThreadpoolWait"/> to cancel the wait and then close the handle.
        /// </param>
        /// <param name="pftTimeout">
        /// A pointer to a <see cref="FILETIME"/> structure that specifies the absolute or relative time at which the wait operation should time out.
        /// If this parameter points to a positive value, it indicates the absolute time since January 1, 1601 (UTC), in 100-nanosecond intervals.
        /// If this parameter points to a negative value, it indicates the amount of time to wait relative to the current time.
        /// For more information about time values, see File Times.
        /// If this parameter points to 0, the wait times out immediately.
        /// If this parameter is <see cref="NullRef{FILETIME}"/>, the wait will not time out.
        /// </param>
        /// <remarks>
        /// A wait object can wait for only one handle.
        /// Setting the handle for a wait object replaces the previous handle, if any.
        /// You must re-register the event with the wait object before signaling it each time to trigger the wait callback.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetThreadpoolWait", ExactSpelling = true, SetLastError = true)]
        public static extern void SetThreadpoolWait([In] PTP_WAIT pwa, [In] HANDLE h, [In] in FILETIME pftTimeout);

        /// <summary>
        /// <para>
        /// Notifies the thread pool that I/O operations may possibly begin for the specified I/O completion object.
        /// A worker thread calls the I/O completion object's callback function after the operation completes on the file handle bound to this object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-startthreadpoolio"/>
        /// </para>
        /// </summary>
        /// <param name="pio">
        /// A TP_IO structure that defines the I/O completion object.
        /// The <see cref="CreateThreadpoolIo"/> function returns this structure.
        /// </param>
        /// <remarks>
        /// You must call this function before initiating each asynchronous I/O operation on the file handle bound to the I/O completion object.
        /// Failure to do so will cause the thread pool to ignore an I/O operation when it completes and will cause memory corruption.
        /// If the I/O operation fails, call the <see cref="CancelThreadpoolIo"/> function to cancel this notification.
        /// If the file handle bound to the I/O completion object has the notification mode <see cref="FILE_SKIP_COMPLETION_PORT_ON_SUCCESS"/>
        /// and an asynchronous I/O operation returns immediately with success,
        /// the object's I/O completion callback function is not called and threadpool I/O notifications must be canceled.
        /// For more information, see <see cref="CancelThreadpoolIo"/>.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "StartThreadpoolIo", ExactSpelling = true, SetLastError = true)]
        public static extern void StartThreadpoolIo([In] PTP_IO pio);

        /// <summary>
        /// <para>
        /// Posts a work object to the thread pool.
        /// A worker thread calls the work object's callback function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-submitthreadpoolwork"/>
        /// </para>
        /// </summary>
        /// <param name="pwk">
        /// A TP_WORK structure that defines the work object.
        /// The <see cref="CreateThreadpoolWork"/> function returns this structure.
        /// </param>
        /// <remarks>
        /// You can post a work object one or more times (up to <see cref="MAXULONG"/>) without waiting for prior callbacks to complete.
        /// The callbacks will execute in parallel.
        /// To improve efficiency, the thread pool may throttle the threads.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SubmitThreadpoolWork", ExactSpelling = true, SetLastError = true)]
        public static extern void SubmitThreadpoolWork([In] PTP_WORK pwk);

        /// <summary>
        /// <para>
        /// Requests that a thread pool worker thread call the specified callback function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-trysubmitthreadpoolcallback"/>
        /// </para>
        /// </summary>
        /// <param name="pfns">
        /// The callback function. For details, see <see cref="PTP_SIMPLE_CALLBACK"/>.
        /// </param>
        /// <param name="pv">
        /// Optional application-defined data to pass to the callback function.
        /// </param>
        /// <param name="pcbe">
        /// A <see cref="TP_CALLBACK_ENVIRON"/> structure that defines the environment in which to execute the callback function.
        /// The <see cref="InitializeThreadpoolEnvironment"/> function returns this structure.
        /// If this parameter is <see cref="NullRef{TP_CALLBACK_ENVIRON}"/>, the callback executes in the default callback environment.
        /// For more information, see <see cref="InitializeThreadpoolEnvironment"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To retrieve extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "TrySubmitThreadpoolCallback", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL TrySubmitThreadpoolCallback([In] PTP_SIMPLE_CALLBACK pfns, [In] PVOID pv, [In][Out] ref TP_CALLBACK_ENVIRON pcbe);

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
        /// A handle to the event object to be signaled when the wait operation has been unregistered.
        /// This parameter can be <see cref="NULL"/>.
        /// If this parameter is <see cref="INVALID_HANDLE_VALUE"/>, the function waits for all callback functions to complete before returning.
        /// If this parameter is <see cref="NULL"/>, the function marks the timer for deletion and returns immediately.
        /// However, most callers should wait for the callback function to complete so they can perform any needed cleanup.
        /// If the caller provides this event and the function succeeds or the function fails with <see cref="ERROR_IO_PENDING"/>,
        /// do not close the event until it is signaled.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// You cannot make a blocking call to <see cref="UnregisterWaitEx"/> from within a callback function for the same wait operation.
        /// Otherwise, the callback will be waiting for itself to finish.
        /// In general, a blocking call to <see cref="UnregisterWaitEx"/> creates a dependency between the current thread and the callback,
        /// so to make a blocking unregister call on another wait operation, you must ensure that the callback functions do not depend on
        /// one another and that the second wait operation does not also perform a blocking unregister call on the first operation.
        /// Be careful when making a blocking <see cref="UnregisterWaitEx"/> call on a persistent thread.
        /// If the wait operation being unregistered was created with <see cref="WT_EXECUTEINPERSISTENTTHREAD"/>, a deadlock may occur.
        /// After making non-blocking call to <see cref="UnregisterWaitEx"/>,
        /// no new callback functions associated with <paramref name="WaitHandle"/> can be queued.
        /// However, there may be pending callback functions already queued to worker threads.
        /// Under some conditions, the function will fail with <see cref="ERROR_IO_PENDING"/> if <paramref name="CompletionEvent"/> is <see cref="NULL"/>.
        /// This indicates that there are outstanding callback functions. Those callbacks either will execute or are in the middle of executing.
        /// If <paramref name="CompletionEvent"/> is a handle to an event provided by the caller, it is possible for the function to succeed,
        /// fail with <see cref="ERROR_IO_PENDING"/>, or fail with a different error code.
        /// If the function succeeds, or if the function fails with <see cref="ERROR_IO_PENDING"/>,
        /// the caller should always wait until the event is signaled to close the event.
        /// If the function fails with a different error code, it is not necessary to wait until the event is signaled to close the event.
        /// Windows XP: If <paramref name="CompletionEvent"/> is a handle to an event provided by the caller
        /// and the function fails with <see cref="ERROR_IO_PENDING"/>, the caller should wait until the event is signaled to close the event.
        /// This behavior changed starting with Windows Vista.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0500 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "UnregisterWaitEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL UnregisterWaitEx([In] HANDLE WaitHandle, [In] HANDLE CompletionEvent);

        /// <summary>
        /// <para>
        /// Waits for outstanding I/O completion callbacks to complete and optionally cancels pending callbacks that have not yet started to execute.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-waitforthreadpooliocallbacks"/>
        /// </para>
        /// </summary>
        /// <param name="pio">
        /// A TP_IO structure that defines the I/O completion object.
        /// The <see cref="CreateThreadpoolIo"/> function returns this structure.
        /// </param>
        /// <param name="fCancelPendingCallbacks">
        /// Indicates whether to cancel queued callbacks that have not yet started to execute.
        /// </param>
        /// <remarks>
        /// When <paramref name="fCancelPendingCallbacks"/> is set to <see cref="TRUE"/>, only queued callbacks are canceled.
        /// Pending I/O requests are not canceled.
        /// Therefore, the caller should call <see cref="GetOverlappedResult"/> for the <see cref="OVERLAPPED"/> structure
        /// to check whether the I/O operation has completed before freeing the structure.
        /// As an alternative, set <paramref name="fCancelPendingCallbacks"/> to <see cref="FALSE"/>
        /// and have the associated I/O completion callback free the <see cref="OVERLAPPED"/> structure.
        /// Be careful not to free the <see cref="OVERLAPPED"/> structure while I/O requests are still pending;
        /// use <see cref="GetOverlappedResult"/> to determine the status of the I/O operation and wait for the operation to complete.
        /// The <see cref="CancelIoEx"/> function can optionally be used first to cancel outstanding I/O requests, potentially shortening the wait.
        /// For more information, see Canceling Pending I/O Operations.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WaitForThreadpoolIoCallbacks", ExactSpelling = true, SetLastError = true)]
        public static extern void WaitForThreadpoolIoCallbacks([In] PTP_IO pio, [In] BOOL fCancelPendingCallbacks);

        /// <summary>
        /// <para>
        /// Waits for outstanding timer callbacks to complete and optionally cancels pending callbacks that have not yet started to execute.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-waitforthreadpooltimercallbacks"/>
        /// </para>
        /// </summary>
        /// <param name="pti">
        /// A TP_TIMER structure that defines the timer object.
        /// The <see cref="CreateThreadpoolTimer"/> function returns the TP_TIMER structure.
        /// </param>
        /// <param name="fCancelPendingCallbacks">
        /// Indicates whether to cancel queued callbacks that have not yet started to execute.
        /// </param>
        /// <remarks>
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WaitForThreadpoolTimerCallbacks", ExactSpelling = true, SetLastError = true)]
        public static extern void WaitForThreadpoolTimerCallbacks([In] PTP_TIMER pti, [In] BOOL fCancelPendingCallbacks);

        /// <summary>
        /// <para>
        /// Waits for outstanding wait callbacks to complete and optionally cancels pending callbacks that have not yet started to execute.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-waitforthreadpoolwaitcallbacks"/>
        /// </para>
        /// </summary>
        /// <param name="pwa">
        /// A TP_WAIT structure that defines the wait object.
        /// The <see cref="CreateThreadpoolWait"/> function returns the TP_WAIT structure.
        /// </param>
        /// <param name="fCancelPendingCallbacks">
        /// Indicates whether to cancel queued callbacks that have not yet started to execute.
        /// </param>
        /// <remarks>
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WaitForThreadpoolWaitCallbacks", ExactSpelling = true, SetLastError = true)]
        public static extern void WaitForThreadpoolWaitCallbacks([In] PTP_WAIT pwa, [In] BOOL fCancelPendingCallbacks);

        /// <summary>
        /// <para>
        /// Waits for outstanding work callbacks to complete and optionally cancels pending callbacks that have not yet started to execute.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-waitforthreadpoolworkcallbacks"/>
        /// </para>
        /// </summary>
        /// <param name="pwk">
        /// A TP_WORK structure that defines the work object.
        /// The <see cref="CreateThreadpoolWork"/> function returns this structure.
        /// </param>
        /// <param name="fCancelPendingCallbacks">
        /// Indicates whether to cancel queued callbacks that have not yet started to execute.
        /// </param>
        /// <remarks>
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WaitForThreadpoolWorkCallbacks", ExactSpelling = true, SetLastError = true)]
        public static extern void WaitForThreadpoolWorkCallbacks([In] PTP_WORK pwk, [In] BOOL fCancelPendingCallbacks);
    }
}
