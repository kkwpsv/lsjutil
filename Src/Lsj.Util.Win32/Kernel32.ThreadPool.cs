using Lsj.Util.Win32.Attributes;
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
using static Lsj.Util.Win32.Enums.ThreadPoolCallbackPriorities;
using static Lsj.Util.Win32.Enums.WorkThreadFlags;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using FILETIME = Lsj.Util.Win32.Structs.FILETIME;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// PtpCleanupGroupCancelCallback
        /// </summary>
        /// <param name="ObjectContext"></param>
        /// <param name="CleanupContext"></param>
        public delegate void PtpCleanupGroupCancelCallback([In] PVOID ObjectContext, [In] PVOID CleanupContext);

        /// <summary>
        /// <para>
        /// Applications implement this callback
        /// if they call the <see cref="TrySubmitThreadpoolCallback"/> function to start a worker thread.
        /// </para>
        /// <para>
        /// The <see cref="PTP_SIMPLE_CALLBACK"/> type defines a pointer to this callback function.
        /// <see cref="SimpleCallback"/> is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms686295(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="Instance">
        /// <para>
        /// A <c>TP_CALLBACK_INSTANCE</c> structure that defines the callback instance.
        /// Applications do not modify the members of this structure.
        /// </para>
        /// <para>
        /// This structure can be passed to one of the following functions:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="CallbackMayRunLong"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DisassociateCurrentThreadFromCallback"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="FreeLibraryWhenCallbackReturns"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LeaveCriticalSectionWhenCallbackReturns"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ReleaseMutexWhenCallbackReturns"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ReleaseSemaphoreWhenCallbackReturns"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="SetEventWhenCallbackReturns"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="Context">
        /// The application-defined data.
        /// </param>
        public delegate void SimpleCallback([In] PTP_CALLBACK_INSTANCE Instance, [In] PVOID Context);

        /// <summary>
        /// <para>
        /// Applications implement this callback
        /// if they call the <see cref="SetThreadpoolWait"/> function to start a worker thread for the wait object.
        /// </para>
        /// <para>
        /// The <see cref="PTP_WAIT_CALLBACK"/> type defines a pointer to this callback function.
        /// <see cref="WaitCallback"/> is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms687017(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="Instance">
        /// <para>
        /// A <c>TP_CALLBACK_INSTANCE</c> structure that defines the callback instance.
        /// Applications do not modify the members of this structure.
        /// </para>
        /// <para>
        /// This structure can be passed to one of the following functions:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="CallbackMayRunLong"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DisassociateCurrentThreadFromCallback"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="FreeLibraryWhenCallbackReturns"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LeaveCriticalSectionWhenCallbackReturns"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ReleaseMutexWhenCallbackReturns"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ReleaseSemaphoreWhenCallbackReturns"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="SetEventWhenCallbackReturns"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="Context">
        /// The application-defined data.
        /// </param>
        /// <param name="Wait">
        /// A TP_WAIT structure that defines the wait object that generated the callback.
        /// </param>
        /// <param name="WaitResult">
        /// <para>
        /// The result of the wait operation.
        /// This parameter can be one of the following values from <see cref="WaitForMultipleObjects"/>:
        /// </para>
        /// <para>
        /// <see cref="WAIT_OBJECT_0"/>
        /// </para>
        /// <para>
        /// <see cref="WAIT_TIMEOUT"/>
        /// </para>
        /// </param>
        public delegate void WaitCallback([In] PTP_CALLBACK_INSTANCE Instance, [In] PVOID Context, [In] PTP_WAIT Wait, [In] WaitResult WaitResult);

        /// <summary>
        /// <para>
        /// An application-defined function that serves as the starting address for a timer callback or a registered wait callback.
        /// Specify this address when calling the <see cref="CreateTimerQueueTimer"/>, <see cref="RegisterWaitForSingleObject"/> function.
        /// </para>
        /// <para>
        /// The <see cref="WAITORTIMERCALLBACK"/> type defines a pointer to this callback function.
        /// <see cref="WaitOrTimerCallback"/>is a placeholder for the application-defined function name.
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
        /// If this parameter is <see cref="TRUE"/>, the wait timed out.
        /// If this parameter is <see cref="FALSE"/>, the wait event has been signaled.
        /// (This parameter is always <see cref="TRUE"/> for timer callbacks.)
        /// </param>
        /// <remarks>
        /// This callback function must not call the <see cref="TerminateThread"/> function.
        /// </remarks>
        public delegate void WaitOrTimerCallback([In] PVOID lpParameter, [In] BOOLEAN TimerOrWaitFired);

        /// <summary>
        /// <para>
        /// Applications implement this callback
        /// if they call the <see cref="StartThreadpoolIo"/> function to start a worker thread for the I/O completion object.
        /// </para>
        /// <para>
        /// The <see cref="PTP_WIN32_IO_CALLBACK"/> type defines a pointer to this callback function.
        /// <see cref="IoCompletionCallback"/> is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms684124(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="Instance">
        /// <para>
        /// A <c>TP_CALLBACK_INSTANCE</c> structure that defines the callback instance.
        /// Applications do not modify the members of this structure.
        /// </para>
        /// <para>
        /// This structure can be passed to one of the following functions:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="CallbackMayRunLong"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DisassociateCurrentThreadFromCallback"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="FreeLibraryWhenCallbackReturns"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LeaveCriticalSectionWhenCallbackReturns"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ReleaseMutexWhenCallbackReturns"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ReleaseSemaphoreWhenCallbackReturns"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="SetEventWhenCallbackReturns"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
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
        /// A <c>TP_IO</c> structure that defines the I/O completion object that generated the callback.
        /// </param>
        /// <remarks>
        /// If the file handle bound to the I/O completion object has the notification mode <see cref="FILE_SKIP_COMPLETION_PORT_ON_SUCCESS"/>
        /// and an asynchronous I/O operation returns immediately with success,
        /// the I/O completion callback function is not called and threadpool I/O notifications must be canceled.
        /// For more information, see <see cref="CancelThreadpoolIo"/>.
        /// </remarks>
        public delegate void IoCompletionCallback([In] PTP_CALLBACK_INSTANCE Instance, [In] PVOID Context, [In] PVOID Overlapped,
            [In] SystemErrorCodes IoResult, [In] ULONG_PTR NumberOfBytesTransferred, [In] PTP_IO Io);

        /// <summary>
        /// <para>
        /// Applications implement this callback
        /// if they call the <see cref="SubmitThreadpoolWork"/> function to start a worker thread for the work object.
        /// </para>
        /// <para>
        /// The <see cref="PTP_WORK_CALLBACK"/> type defines a pointer to this callback function.
        /// <see cref="WorkCallback"/> is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms687396(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="Instance">
        /// <para>
        /// A <c>TP_CALLBACK_INSTANCE</c> structure that defines the callback instance.
        /// Applications do not modify the members of this structure.
        /// </para>
        /// <para>
        /// This structure can be passed to one of the following functions:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="SetEventWhenCallbackReturns"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ReleaseSemaphoreWhenCallbackReturns"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LeaveCriticalSectionWhenCallbackReturns"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ReleaseMutexWhenCallbackReturns"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="FreeLibraryWhenCallbackReturns"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CallbackMayRunLong"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DisassociateCurrentThreadFromCallback"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="Context">
        /// The application-defined data.
        /// </param>
        /// <param name="Work">
        /// A <c>TP_WORK</c> structure that defines the work object that generated the callback.
        /// </param>
        public delegate void WorkCallback([In] PTP_CALLBACK_INSTANCE Instance, [In] PVOID Context, [In] PTP_WORK Work);

        /// <summary>
        /// <para>
        /// Applications implement this callback
        /// if they call the <see cref="SetThreadpoolTimer"/> function to start a worker thread for the timer object.
        /// </para>
        /// <para>
        /// The <see cref="PTP_TIMER_CALLBACK"/> type defines a pointer to this callback function.
        /// <see cref="TimerCallback"/> is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms686790(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="Instance">
        /// <para>
        /// A <c>TP_CALLBACK_INSTANCE</c> structure that defines the callback instance.
        /// Applications do not modify the members of this structure.
        /// </para>
        /// <para>
        /// This structure can be passed to one of the following functions:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="CallbackMayRunLong"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DisassociateCurrentThreadFromCallback"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="FreeLibraryWhenCallbackReturns"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="LeaveCriticalSectionWhenCallbackReturns"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ReleaseMutexWhenCallbackReturns"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ReleaseSemaphoreWhenCallbackReturns"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="SetEventWhenCallbackReturns"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="Context">
        /// The application-defined data.
        /// </param>
        /// <param name="Timer">
        /// A <c>TP_TIMER</c> structure that defines the timer object that generated the callback.
        /// </param>
        public delegate void TimerCallback([In] PTP_CALLBACK_INSTANCE Instance, [In] PVOID Context, [In] PTP_TIMER Timer);


        /// <summary>
        /// <para>
        /// Indicates that the callback may not return quickly.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-callbackmayrunlong"/>
        /// </para>
        /// </summary>
        /// <param name="pci">
        /// A pointer to a <c>TP_CALLBACK_INSTANCE</c> structure that defines the callback instance.
        /// The pointer is passed to the callback function.
        /// </param>
        /// <returns>
        /// <para>
        /// The function returns <see cref="TRUE"/>
        /// if another thread in the thread pool is available for processing callbacks or the thread pool was able to create a new thread.
        /// In this case, the current callback function may use the current thread indefinitely.
        /// </para>
        /// <para>
        /// The function returns <see cref="FALSE"/>
        /// if another thread in the thread pool is not available to process callbacks and the thread pool was not able to create a new thread.
        /// The thread pool will attempt to create a new thread after a delay,
        /// but if the current callback function runs long, the thread pool may lose efficiency.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The thread pool may use this information to better determine when a new thread should be created.
        /// </para>
        /// <para>
        /// The <see cref="CallbackMayRunLong"/> function should be called only by the thread that is processing the callback.
        /// Calling this function from another thread may cause a race condition.
        /// </para>
        /// <para>
        /// The <see cref="CallbackMayRunLong"/> function always marks the callback as long-running,
        /// whether or not a thread is available for processing callbacks or the threadpool is able to allocate a new thread.
        /// Therefore, this function should be called only once, even if it returns <see cref="FALSE"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallbackMayRunLong", ExactSpelling = true)]
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
        /// A <c>TP_IO</c> structure that defines the I/O completion object.
        /// The <see cref="CreateThreadpoolIo"/> function returns this structure.
        /// </param>
        /// <remarks>
        /// <para>
        /// To prevent memory leaks, you must call the <see cref="CancelThreadpoolIo"/> function for either of the following scenarios:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// An overlapped (asynchronous) I/O operation fails
        /// (that is, the asynchronous I/O function call returns failure with an error code other than <see cref="ERROR_IO_PENDING"/>).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// An asynchronous I/O operation returns immediately with success
        /// and the file handle associated with the I/O completion object has the notification mode <see cref="FILE_SKIP_COMPLETION_PORT_ON_SUCCESS"/>.
        /// The file handle will not notify the I/O completion port and the associated I/O callback function will not be called.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CancelThreadpoolIo", ExactSpelling = true)]
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
        /// A <c>TP_POOL</c> structure that defines the thread pool.
        /// The <see cref="CreateThreadpool"/> function returns this structure.
        /// </param>
        /// <remarks>
        /// The thread pool is closed immediately if there are no outstanding work, I/O, timer, or wait objects that are bound to the pool;
        /// otherwise, the thread pool is released asynchronously after the outstanding objects are freed.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseThreadpool", ExactSpelling = true)]
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
        /// A <c>TP_CLEANUP_GROUP</c> structure that defines the cleanup group.
        /// The <see cref="CreateThreadpoolCleanupGroup"/> returns this structure.
        /// </param>
        /// <remarks>
        /// The cleanup group must have no members when you call this function.
        /// For information on removing members of the group, see <see cref="CloseThreadpoolCleanupGroupMembers"/>.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseThreadpoolCleanupGroup", ExactSpelling = true)]
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
        /// A <c>TP_CLEANUP_GROUP</c> structure that defines the cleanup group.
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
        /// <para>
        /// The <see cref="CloseThreadpoolCleanupGroupMembers"/> function simplifies cleanup of thread pool callback objects
        /// by releasing, in a single operation, all work objects, wait objects, and timer objects that are members of the cleanup group.
        /// An object becomes a member of a cleanup group
        /// when the object is created with the threadpool callback environment that was specified when the cleanup group was created.
        /// For more information, see <see cref="CreateThreadpoolCleanupGroup"/>.
        /// </para>
        /// <para>
        /// The <see cref="CloseThreadpoolCleanupGroupMembers"/> function blocks until all currently executing callback functions finish.
        /// If <paramref name="fCancelPendingCallbacks"/> is TRUE, outstanding callbacks are canceled;
        /// otherwise, the function blocks until all outstanding callbacks also finish.
        /// After the <see cref="CloseThreadpoolCleanupGroupMembers"/> function returns,
        /// an application should not use any object that was a member of the cleanup group
        /// at the time <see cref="CloseThreadpoolCleanupGroupMembers"/> was called.
        /// Also, an application should not release any of the objects individually
        /// by calling a function such as <see cref="CloseThreadpoolWork"/>, because the objects have already been released.
        /// </para>
        /// <para>
        /// The <see cref="CloseThreadpoolCleanupGroupMembers"/> function does not close the cleanup group itself.
        /// Instead, the cleanup group persists until the <see cref="CloseThreadpoolCleanupGroup"/> function is called.
        /// Also, closing a cleanup group does not affect the associated threadpool callback environment.
        /// The callback environment persists until it is destroyed by calling <see cref="DestroyThreadpoolEnvironment"/>.
        /// </para>
        /// <para>
        /// As long as a cleanup group persists,
        /// new objects created with the cleanup group's associated threadpool callback environment are added to the cleanup group.
        /// This allows an application to reuse the cleanup group.
        /// However, it can lead to errors if the application does not synchronize code
        /// that calls <see cref="CloseThreadpoolCleanupGroupMembers"/> with code that creates new objects.
        /// For example, suppose a thread creates two threadpool work objects, Work1 and Work2.
        /// Another thread calls <see cref="CloseThreadpoolCleanupGroupMembers"/>.
        /// Depending on when the threads run, any of the following might occur:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Work1 and Work2 are added to the cleanup group after its existing members were released.
        /// Code that submits Work1 and Work2 will succeed.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Work1 is added to the cleanup group before its existing members are released, causing Work1 to be released along with other members.
        /// Then Work2 is added. Code that submits Work1 will generate an exception; code that submits Work2 will succeed.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Work1 and Work2 are added to the cleanup group before its existing members are released, causing both Work1 and Work2 to be released.
        /// Code that submits Work1 or Work2 will generate an exception.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// To simply wait for or cancel pending work items without releasing them,
        /// use one of the threadpool callback functions:
        /// <see cref="WaitForThreadpoolIoCallbacks"/>, <see cref="WaitForThreadpoolTimerCallbacks"/>,
        /// <see cref="WaitForThreadpoolWaitCallbacks"/>, or <see cref="WaitForThreadpoolWorkCallbacks"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseThreadpoolCleanupGroupMembers", ExactSpelling = true)]
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
        /// A <c>TP_IO</c> structure that defines the I/O completion object.
        /// The <see cref="CreateThreadpoolIo"/> function returns this structure.
        /// </param>
        /// <remarks>
        /// <para>
        /// The I/O completion object is freed immediately if there are no outstanding callbacks;
        /// otherwise, the I/O completion object is freed asynchronously after the outstanding callbacks complete.
        /// </para>
        /// <para>
        /// You should close the associated file handle and wait for all outstanding overlapped I/O operations to complete before calling this function.
        /// You must not cause any more overlapped I/O operations to occur after calling this function.
        /// </para>
        /// <para>
        /// It may be necessary to cancel threadpool I/O notifications to prevent memory leaks.
        /// For more information, see <see cref="CancelThreadpoolIo"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseThreadpoolIo", ExactSpelling = true)]
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
        /// A <c>TP_TIMER</c> structure that defines the timer object.
        /// The <see cref="CreateThreadpoolTimer"/> function returns this structure.
        /// </param>
        /// <remarks>
        /// <para>
        /// The timer object is freed immediately if there are no outstanding callbacks;
        /// otherwise, the timer object is freed asynchronously after the outstanding callback functions complete.
        /// </para>
        /// <para>
        /// In some cases, callback functions might run after <see cref="CloseThreadpoolTimer"/> has been called.
        /// To prevent this behavior:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Call the <see cref="SetThreadpoolTimer"/> function or <see cref="SetThreadpoolTimerEx"/> function
        /// with the <c>pftDueTime</c> parameter set to <see cref="NullRef{FILETIME}"/> and the <c>msPeriod</c> and <c>msWindowLength</c>parameters set to 0.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Call the <see cref="WaitForThreadpoolTimerCallbacks"/> function with the <c>fCancelPendingCallbacks</c> parameter set to <see cref="TRUE"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Call <see cref="CloseThreadpoolTimer"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If there is a cleanup group associated with the timer object, it is not necessary to call this function;
        /// calling the <see cref="CloseThreadpoolCleanupGroupMembers"/> function releases
        /// the work, wait, and timer objects associated with the cleanup group.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseThreadpoolTimer", ExactSpelling = true)]
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
        /// A <c>TP_WAIT</c> structure that defines the wait object.
        /// The <see cref="CreateThreadpoolWait"/> function returns this structure.
        /// </param>
        /// <remarks>
        /// <para>
        /// The wait object is freed immediately if there are no outstanding callbacks;
        /// otherwise, the timer object is freed asynchronously after the outstanding callbacks complete.
        /// </para>
        /// <para>
        /// In some cases, callback functions might run after <see cref="CloseThreadpoolWait"/> has been called.
        /// To prevent this behavior:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Call the <see cref="SetThreadpoolWait"/> function or <see cref="SetThreadpoolWaitEx"/> function
        /// with the <c>h</c> parameter set to <see cref="NULL"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Call the <see cref="WaitForThreadpoolWaitCallbacks"/> function with the <c>fCancelPendingCallbacks</c> parameter set to <see cref="TRUE"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Call <see cref="CloseThreadpoolWait"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If there is a cleanup group associated with the wait object, it is not necessary to call this function;
        /// calling the <see cref="CloseThreadpoolCleanupGroupMembers"/> function releases
        /// the work, wait, and timer objects associated with the cleanup group.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseThreadpoolWait", ExactSpelling = true)]
        public static extern void CloseThreadpoolWait([In] PTP_WAIT pwa);

        /// <summary>
        /// <para>
        /// Releases the specified work object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-closethreadpoolwork"/>
        /// </para>
        /// </summary>
        /// <param name="pwk">
        /// A <c>TP_WORK</c> structure that defines the work object.
        /// The <see cref="CreateThreadpoolWork"/> function returns this structure.
        /// </param>
        /// <remarks>
        /// <para>
        /// The work object is freed immediately if there are no outstanding callbacks;
        /// otherwise, the work object is freed asynchronously after the outstanding callbacks complete.
        /// </para>
        /// <para>
        /// If there is a cleanup group associated with the work object, it is not necessary to call this function;
        /// calling the <see cref="CloseThreadpoolCleanupGroupMembers"/> function releases
        /// the work, wait, and timer objects associated with the cleanup group.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseThreadpoolWork", ExactSpelling = true)]
        public static extern void CloseThreadpoolWork([In] PTP_WORK pwk);

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
        /// <para>
        /// If the function succeeds, it returns a pointer to a <c>TP_POOL</c> structure representing the newly allocated thread pool.
        /// Applications do not modify the members of this structure.
        /// </para>
        /// <para>
        /// If function fails, it returns <see cref="NULL"/>.
        /// To retrieve extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// After creating the new thread pool,
        /// you should call <see cref="SetThreadpoolThreadMaximum"/> to specify the maximum number of threads that the pool can allocate
        /// and <see cref="SetThreadpoolThreadMinimum"/> to specify the minimum number of threads available in the pool.
        /// </para>
        /// <para>
        /// To use the pool, you must associate the pool with a callback environment.
        /// To create the callback environment, call <see cref="InitializeThreadpoolEnvironment"/>.
        /// Then, call <see cref="SetThreadpoolCallbackPool"/> to associate the pool with the callback environment.
        /// </para>
        /// <para>
        /// To release the thread pool, call <see cref="CloseThreadpool"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateThreadpool", ExactSpelling = true, SetLastError = true)]
        public static extern PTP_POOL CreateThreadpool([In] PVOID reserved);

        /// <summary>
        /// <para>
        /// Creates a cleanup group that applications can use to track one or more thread pool callbacks.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-createthreadpoolcleanupgroup"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// <para>
        /// If the function succeeds, it returns a pointer to a <c>TP_CLEANUP_GROUP</c> structure of the newly allocated cleanup group.
        /// Applications do not modify the members of this structure.
        /// </para>
        /// <para>
        /// If function fails, it returns <see cref="NULL"/>.
        /// To retrieve extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// After creating the cleanup group, call <see cref="SetThreadpoolCallbackCleanupGroup"/> to associate the cleanup group with a callback environment.
        /// </para>
        /// <para>
        /// A member is added to the group each time you call one of the following functions:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="CreateThreadpoolIo"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CreateThreadpoolTimer"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CreateThreadpoolWait"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CreateThreadpoolWork"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// You use one of the following corresponding close functions to remove a member from the group.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="CloseThreadpoolIo"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CloseThreadpoolTimer"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CloseThreadpoolWait"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CloseThreadpoolWork"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// To close all the callbacks, call <see cref="CloseThreadpoolCleanupGroupMembers"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateThreadpoolCleanupGroup", ExactSpelling = true, SetLastError = true)]
        public static extern PTP_CLEANUP_GROUP CreateThreadpoolCleanupGroup();

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
        /// For details, see <see cref="IoCompletionCallback"/>.
        /// </param>
        /// <param name="pv">
        /// Optional application-defined data to pass to the callback function.
        /// </param>
        /// <param name="pcbe">
        /// <para>
        /// A pointer to a <see cref="TP_CALLBACK_ENVIRON"/> structure that defines the environment in which to execute the callback.
        /// Use the <see cref="InitializeThreadpoolEnvironment"/> function to initialize the structure before calling this function.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NullRef{TP_CALLBACK_ENVIRON}"/>, the callback executes in the default callback environment.
        /// For more information, see <see cref="InitializeThreadpoolEnvironment"/>.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// f the function succeeds, it returns a pointer to a <c>TP_IO</c> structure that defines the I/O object.
        /// Applications do not modify the members of this structure.
        /// </para>
        /// <para>
        /// If the function fails, it returns <see cref="NULL"/>.
        /// To retrieve extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To begin receiving overlapped I/O completion callbacks, call the <see cref="StartThreadpoolIo"/> function.
        /// </para>
        /// <para>
        /// If the file handle bound to the I/O completion object has the notification mode <see cref="FILE_SKIP_COMPLETION_PORT_ON_SUCCESS"/>
        /// and an asychronous I/O operation returns immediately with success,
        /// the I/O completion callback function is not called and threadpool I/O notifications must be canceled.
        /// For more information, see <see cref="CancelThreadpoolIo"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
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
        /// For details, see <see cref="TimerCallback"/>.
        /// </param>
        /// <param name="pv">
        /// Optional application-defined data to pass to the callback function.
        /// </param>
        /// <param name="pcbe">
        /// <para>
        /// A <see cref="TP_CALLBACK_ENVIRON"/> structure that defines the environment in which to execute the callback.
        /// The <see cref="InitializeThreadpoolEnvironment"/> function returns this structure.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NullRef{TP_CALLBACK_ENVIRON}"/>, the callback executes in the default callback environment.
        /// For more information, see <see cref="InitializeThreadpoolEnvironment"/>.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, it returns a pointer to a <c>TP_TIMER</c> structure that defines the timer object.
        /// Applications do not modify the members of this structure.
        /// </para>
        /// <para>
        /// If the function fails, it returns <see cref="NULL"/>.
        /// To retrieve extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// To set the timer object, call the <see cref="SetThreadpoolTimer"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateThreadpoolTimer", ExactSpelling = true, SetLastError = true)]
        public static extern PTP_TIMER CreateThreadpoolTimer([In] PTP_TIMER_CALLBACK pfnti, [In] PVOID pv, [In][Out] ref TP_CALLBACK_ENVIRON pcbe);

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
        /// For details, see <see cref="WaitCallback"/>.
        /// </param>
        /// <param name="pv">
        /// Optional application-defined data to pass to the callback function.
        /// </param>
        /// <param name="pcbe">
        /// <para>
        /// A <see cref="TP_CALLBACK_ENVIRON"/> structure that defines the environment in which to execute the callback.
        /// The <see cref="InitializeThreadpoolEnvironment"/> function returns this structure.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NullRef{TP_CALLBACK_ENVIRON}"/>, the callback executes in the default callback environment.
        /// For more information, see <see cref="InitializeThreadpoolEnvironment"/>.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, it returns a pointer to a <c>TP_WAIT</c> structure that defines the wait object.
        /// Applications do not modify the members of this structure.
        /// </para>
        /// <para>
        /// If the function fails, it returns NULL.
        /// To retrieve extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To set the wait object, call the <see cref="SetThreadpoolWait"/> or <see cref="SetThreadpoolWaitEx"/> function.
        /// </para>
        /// <para>
        /// The work item and all functions it calls must not rely on the thread after they have returned.
        /// Therefore, you cannot call an asynchronous call that requires a persistent thread,
        /// such as the <see cref="RegNotifyChangeKeyValue"/> function without the <see cref="REG_NOTIFY_THREAD_AGNOSTIC"/> flag,
        /// from the default callback environment.
        /// Instead, use a thread whose lifetime you control.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
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
        /// For details, see <see cref="WorkCallback"/>.
        /// </param>
        /// <param name="pv">
        /// Optional application-defined data to pass to the callback function.
        /// </param>
        /// <param name="pcbe">
        /// <para>
        /// A <see cref="TP_CALLBACK_ENVIRON"/> structure that defines the environment in which to execute the callback.
        /// The <see cref="InitializeThreadpoolEnvironment"/> function returns this structure.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NullRef{TP_CALLBACK_ENVIRON}"/>, the callback executes in the default callback environment.
        /// For more information, see <see cref="InitializeThreadpoolEnvironment"/>.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, it returns a pointer to a <c>TP_WORK</c> structure that defines the work object.
        /// Applications do not modify the members of this structure.
        /// </para>
        /// <para>
        /// If the function fails, it returns <see cref="NULL"/>.
        /// To retrieve extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateThreadpoolWork", ExactSpelling = true, SetLastError = true)]
        public static extern PTP_WORK CreateThreadpoolWork([In] PTP_WORK_CALLBACK pfnwk, [In] PVOID pv, [In][Out] ref TP_CALLBACK_ENVIRON pcbe);

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
        /// <para>
        /// A handle to the timer queue.
        /// This handle is returned by the <see cref="CreateTimerQueue"/> function.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NULL"/>, the timer is associated with the default timer queue.
        /// </para>
        /// </param>
        /// <param name="Callback">
        /// A pointer to the application-defined function of type <see cref="WAITORTIMERCALLBACK"/> to be executed when the timer expires.
        /// For more information, see <see cref="WaitOrTimerCallback"/>.
        /// </param>
        /// <param name="DueTime">
        /// The amount of time in milliseconds relative to the current time that must elapse before the timer is signaled for the first time.
        /// </param>
        /// <param name="Parameter">
        /// A single parameter value that will be passed to the callback function.
        /// </param>
        /// <param name="Period">
        /// The period of the timer, in milliseconds.
        /// If this parameter is zero, the timer is signaled once.
        /// If this parameter is greater than zero, the timer is periodic.
        /// A periodic timer automatically reactivates each time the period elapses, until the timer is canceled.
        /// </param>
        /// <param name="Flags">
        /// <para>
        /// This parameter can be one or more of the following values from WinNT.h.
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
        /// <see cref="WT_EXECUTEINTIMERTHREAD"/>
        /// </para>
        /// <para>
        /// 0x00000020
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The callback function is invoked by the timer thread itself.
        /// This flag should be used only for short tasks or it could affect other timer operations.
        /// </para>
        /// <para>
        /// The callback function is queued as an APC.
        /// It should not perform alertable wait operations.
        /// </para>
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
        /// This flag should be used only for short tasks or it could affect other timer operations.
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
        /// The timer will be set to the signaled state only once.
        /// If this flag is set, the <paramref name="Period"/> parameter must be zero.
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
        /// Windows XP:
        /// This flag is not supported until Windows XP with SP2 and Windows Server 2003.
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
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the <paramref name="DueTime"/> and <paramref name="Period"/> parameters are both nonzero,
        /// the timer will be signaled first at the due time, then periodically.
        /// The callback is called every time the period elapses, whether or not the previous callback has finished executing.
        /// Callback functions are queued to the thread pool.
        /// These threads are subject to scheduling delays, so the timing can vary depending on what else is happening in the application or the system.
        /// </para>
        /// <para>
        /// The time that the system spends in sleep or hibernation does not count toward the expiration of the timer.
        /// The timer is signaled when the cumulative amount of elapsed time the system spends in the waking state matches the timer's due time or period.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP:
        /// The time that the system spends in sleep or hibernation counts toward the expiration of the timer.
        /// If the timer expires while the system is sleeping, the timer is signaled immediately when the system wakes.
        /// </para>
        /// <para>
        /// To cancel a timer, call the <see cref="DeleteTimerQueueTimer"/> function.
        /// To cancel all timers in a timer queue, call the <see cref="DeleteTimerQueueEx"/> function.
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
        /// Use this macro when specifying the <paramref name="Flags"/> parameter.
        /// The macro parameters are the desired flags and the new limit (up to (2&lt;&lt;16)-1 threads).
        /// However, note that your application can improve its performance by keeping the number of worker threads low.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateTimerQueueTimer", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CreateTimerQueueTimer([Out] out HANDLE phNewTimer, [In] HANDLE TimerQueue, [In] WAITORTIMERCALLBACK Callback,
            [In] PVOID Parameter, [In] DWORD DueTime, [In] DWORD Period, [In] WorkThreadFlags Flags);

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
        /// <para>
        /// A handle to the event object to be signaled when the function is successful and all callback functions have completed.
        /// This parameter can be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="INVALID_HANDLE_VALUE"/>, the function waits for all callback functions to complete before returning.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NULL"/>, the function marks the timer for deletion and returns immediately.
        /// However, most callers should wait for the callback function to complete so they can perform any needed cleanup.
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
        /// Do not make blocking calls to <see cref="DeleteTimerQueueEx"/> from within a timer callback.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
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
        /// <para>
        /// A handle to the timer queue.
        /// This handle is returned by the <see cref="CreateTimerQueue"/> function.
        /// </para>
        /// <para>
        /// If the timer was created using the default timer queue, this parameter should be <see cref="NULL"/>.
        /// </para>
        /// </param>
        /// <param name="Timer">
        /// A handle to the timer-queue timer.
        /// This handle is returned by the <see cref="CreateTimerQueueTimer"/> function.
        /// </param>
        /// <param name="CompletionEvent">
        /// <para>
        /// A handle to the event object to be signaled when the system has canceled the timer and all callback functions have completed.
        /// This parameter can be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="INVALID_HANDLE_VALUE"/>,
        /// the function waits for any running timer callback functions to complete before returning.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NULL"/>, the function marks the timer for deletion and returns immediately.
        /// If the timer has already expired, the timer callback function will run to completion.
        /// However, there is no notification sent when the timer callback function has completed.
        /// Most callers should not use this option, and should wait for running timer callback functions to complete
        /// so they can perform any needed cleanup.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If the error code is <see cref="ERROR_IO_PENDING"/>, it is not necessary to call this function again.
        /// For any other error, you should retry the call.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function cannot be called while the thread is using impersonation. The resulting behavior is undefined.
        /// </para>
        /// <para>
        /// You can set <paramref name="CompletionEvent"/> to <see cref="INVALID_HANDLE_VALUE"/> 
        /// when calling this function from within the timer callback of another timer
        /// as long as the callback function is not executed in the timer thread.
        /// However, a deadlock may occur if two callback functions attempt a blocking <see cref="DeleteTimerQueueTimer"/> call on each others' timers.
        /// Furthermore, you cannot make a blocking deletion call on a timer associated with the callback.
        /// </para>
        /// <para>
        /// Be careful when making a blocking <see cref="DeleteTimerQueueTimer"/> call on a persistent thread.
        /// If the timer being deleted was created with <see cref="WT_EXECUTEINPERSISTENTTHREAD"/>, a deadlock may occur.
        /// </para>
        /// <para>
        /// If there are outstanding callback functions and <paramref name="CompletionEvent"/> is <see cref="NULL"/>,
        /// the function will fail and set the error code to <see cref="ERROR_IO_PENDING"/>.
        /// This indicates that there are outstanding callback functions.
        /// Those callbacks either will execute or are in the middle of executing.
        /// The timer is cleaned up when the callback function is finished executing.
        /// </para>
        /// <para>
        /// To cancel all timers in a timer queue, call the <see cref="DeleteTimerQueueEx"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
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
        /// A <c>TP_CALLBACK_INSTANCE</c> structure that defines the callback instance.
        /// The structure is passed to the callback function.
        /// </param>
        /// <remarks>
        /// <para>
        /// If this is the last thread executing a callback on behalf of the object,
        /// any threads waiting for the object's callbacks to complete will be released.
        /// </para>
        /// <para>
        /// The thread remains associated with the object's cleanup group until the thread returns to the thread pool.
        /// This lets DLL shutdown routines safely synchronize with outstanding callbacks
        /// and proceed with unloading the DLL's code when all callbacks have completed.
        /// </para>
        /// <para>
        /// The callback-generating object remains valid for the duration of the callback.
        /// The callback object may be reused or released (although synchronization with cleanup group release is still required).
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DisassociateCurrentThreadFromCallback", ExactSpelling = true)]
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
        /// A <c>TP_CALLBACK_INSTANCE</c> structure that defines the callback instance.
        /// The structure is passed to the callback function.
        /// </param>
        /// <param name="mod">
        /// A handle to the DLL.
        /// </param>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FreeLibraryWhenCallbackReturns", ExactSpelling = true)]
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
        /// A <c>TP_CALLBACK_ENVIRON</c> structure that defines a callback environment.
        /// </param>
        /// <remarks>
        /// <para>
        /// By default, a callback executes in the default thread pool for the process.
        /// No cleanup group is associated with the callback environment,
        /// the caller is responsible for keeping the callback's DLL loaded while there are outstanding callbacks,
        /// and the callback is expected to run in a reasonable amount of time for the application.
        /// </para>
        /// <para>
        /// Create a callback environment if you plan to call one of the following functions to modify the environment:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="SetThreadpoolCallbackCleanupGroup"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="SetThreadpoolCallbackLibrary"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="SetThreadpoolCallbackPool"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="SetThreadpoolCallbackPriority"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="SetThreadpoolCallbackRunsLong"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// To use the default callback environment,
        /// set the optional callback environment parameter to <see cref="NULL"/> when calling one of the following functions:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="CreateThreadpoolIo"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CreateThreadpoolTimer"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CreateThreadpoolWait"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CreateThreadpoolWork"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="TrySubmitThreadpoolCallback"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The <see cref="InitializeThreadpoolEnvironment"/> function is implemented as an inline function.
        /// </para>
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
        /// Determines whether the specified timer object is currently set.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-isthreadpooltimerset"/>
        /// </para>
        /// </summary>
        /// <param name="pti">
        /// A <c>TP_TIMER</c> structure that defines the timer object.
        /// The <see cref="CreateThreadpoolTimer"/> function returns this structure.
        /// </param>
        /// <returns>
        /// The return value is <see cref="TRUE"/> if the timer is set; otherwise, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// A timer is considered to be set if the most recent call to <see cref="SetThreadpoolTimer"/> or <see cref="SetThreadpoolTimerEx"/> function
        /// passed a non-null value for <c>pftDueTime</c>.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsThreadpoolTimerSet", ExactSpelling = true)]
        public static extern BOOL IsThreadpoolTimerSet([In] PTP_TIMER pti);

        /// <summary>
        /// <para>
        /// Specifies the critical section that the thread pool will release when the current callback completes.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-leavecriticalsectionwhencallbackreturns"/>
        /// </para>
        /// </summary>
        /// <param name="pci">
        /// A <c>TP_CALLBACK_INSTANCE</c> structure that defines the callback instance.
        /// The structure is passed to the callback function.
        /// </param>
        /// <param name="pcs">
        /// The critical section.
        /// </param>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "LeaveCriticalSectionWhenCallbackReturns", ExactSpelling = true)]
        public static extern void LeaveCriticalSectionWhenCallbackReturns([In] PTP_CALLBACK_INSTANCE pci, [In] in CRITICAL_SECTION pcs);

        /// <summary>
        /// <para>
        /// Specifies the mutex that the thread pool will release when the current callback completes.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-releasemutexwhencallbackreturns"/>
        /// </para>
        /// </summary>
        /// <param name="pci">
        /// A <c>TP_CALLBACK_INSTANCE</c> structure that defines the callback instance.
        /// The structure is passed to the callback function.
        /// </param>
        /// <param name="mut">
        /// A handle to the mutex.
        /// </param>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ReleaseMutexWhenCallbackReturns", ExactSpelling = true)]
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
        /// A <c>TP_CALLBACK_INSTANCE</c> structure that defines the callback instance.
        /// The structure is passed to the callback function.
        /// </param>
        /// <param name="sem">
        /// A handle to the semaphore.
        /// </param>
        /// <param name="crel">
        /// The amount by which to increment the semaphore object's count.
        /// </param>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ReleaseSemaphoreWhenCallbackReturns", ExactSpelling = true)]
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
        /// A <c>TP_CALLBACK_INSTANCE</c> structure that defines the callback instance.
        /// The structure is passed to the callback function.
        /// </param>
        /// <param name="evt">
        /// A handle to the event to be set.
        /// </param>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetEventWhenCallbackReturns", ExactSpelling = true)]
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
        /// A <c>TP_CLEANUP_GROUP</c> structure that defines the cleanup group.
        /// The <see cref="CreateThreadpoolCleanupGroup"/> function returns this structure.
        /// </param>
        /// <param name="pfng">
        /// The cleanup callback to be called if the cleanup group is canceled before the associated object is released.
        /// The function is called when you call <see cref="CloseThreadpoolCleanupGroupMembers"/>.
        /// </param>
        /// <remarks>
        /// This function is implemented as an inline function.
        /// </remarks>
        public static void SetThreadpoolCallbackCleanupGroup([In][Out] ref TP_CALLBACK_ENVIRON pcbe, [In] PTP_CLEANUP_GROUP ptpcg,
            [In] PTP_CLEANUP_GROUP_CANCEL_CALLBACK pfng)
        {
            pcbe.CleanupGroup = ptpcg;
            pcbe.CleanupGroupCancelCallback = pfng;
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
        /// <para>
        /// You should call this function if a callback might acquire the loader lock.
        /// This prevents a deadlock from occurring when one thread in <c>DllMain</c> is waiting for the callback to end,
        /// and another thread that is executing the callback attempts to acquire the loader lock.
        /// </para>
        /// <para>
        /// If the DLL containing the callback might be unloaded,
        /// the cleanup code in <c>DllMain</c> must cancel outstanding callbacks before releasing the object.
        /// </para>
        /// <para>
        /// Managing callbacks created with a <c>TP_CALLBACK_ENVIRON</c> that specifies a callback library is somewhat processing-intensive.
        /// You should consider other options for ensuring that the library is not unloaded while callbacks are executing,
        /// or to guarantee that callbacks which may be executing do not acquire the loader lock.
        /// </para>
        /// <para>
        /// The thread pool assumes ownership of the library reference supplied to this function.
        /// The caller should not call <see cref="FreeLibrary"/> on a module handle after passing it to this function.
        /// </para>
        /// <para>
        /// This function is implemented as an inline function.
        /// </para>
        /// </remarks>
        public static void SetThreadpoolCallbackLibrary([In][Out] ref TP_CALLBACK_ENVIRON pcbe, [In] PVOID mod)
        {
            pcbe.RaceDll = mod;
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
        /// A <c>TP_POOL</c> structure that defines the thread pool.
        /// The <see cref="CreateThreadpool"/> function returns this structure.
        /// </param>
        /// <remarks>
        /// <para>
        /// If you do not specify a thread pool, the global thread pool is used.
        /// </para>
        /// <para>
        /// This function is implemented as an inline function.
        /// </para>
        /// </remarks>
        public static void SetThreadpoolCallbackPool([In][Out] ref TP_CALLBACK_ENVIRON pcbe, [In] PTP_POOL ptpp)
        {
            pcbe.Pool = ptpp;
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
        /// <para>
        /// The thread pool may use this information to better determine when a new thread should be created.
        /// </para>
        /// <para>
        /// This function is implemented as an inline function.
        /// </para>
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
        /// A <c>TP_POOL</c> structure that defines the thread pool.
        /// The <see cref="CreateThreadpool"/> function returns this structure.
        /// </param>
        /// <param name="cthrdMost">
        /// The maximum number of threads.
        /// </param>
        /// <remarks>
        /// To specify the minimum number of threads available in the pool, call <see cref="SetThreadpoolThreadMinimum"/>.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetThreadpoolThreadMaximum", ExactSpelling = true)]
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
        /// A <c>TP_POOL</c> structure that defines the thread pool.
        /// The <see cref="CreateThreadpool"/> function returns this structure.
        /// </param>
        /// <param name="cthrdMic">
        /// The minimum number of threads.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, it returns <see cref="TRUE"/>.
        /// </para>
        /// <para>
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To retrieve extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// To specify the maximum number of threads that the pool may allocate, call <see cref="SetThreadpoolThreadMaximum"/>.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
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
        /// <para>
        /// A pointer to a <see cref="FILETIME"/> structure that specifies the absolute or relative time at which the timer should expire.
        /// If positive or zero, it indicates the absolute time since January 1, 1601 (UTC), measured in 100 nanosecond units.
        /// If negative, it indicates the amount of time to wait relative to the current time.
        /// For more information about time values, see File Times.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NullRef{FILETIME}"/>,
        /// the timer object will cease to queue new callbacks (but callbacks already queued will still occur).
        /// </para>
        /// <para>
        /// The timer is set if the <paramref name="pftDueTime"/> parameter is non-<see cref="NullRef{FILETIME}"/>.
        /// </para>
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
        /// <para>
        /// Setting the timer cancels the previous timer, if any.
        /// </para>
        /// <para>
        /// In some cases, callback functions might run after an application closes the threadpool timer.
        /// To prevent this behavior, an application should follow the steps described in <see cref="CloseThreadpoolTimer"/>.
        /// </para>
        /// <para>
        /// If the due time specified by <paramref name="pftDueTime"/> is relative,
        /// the time that the system spends in sleep or hibernation does not count toward the expiration of the timer.
        /// The timer is signaled when the cumulative amount of elapsed time the system
        /// spends in the waking state equals the timer's relative due time or period.
        /// If the due time specified by <paramref name="pftDueTime"/> is absolute,
        /// the time that the system spends in sleep or hibernation does count toward the expiration of the timer.
        /// If the timer expires while the system is sleeping, the timer is signaled immediately when the system wakes.
        /// </para>
        /// <para>
        /// If the due time specified by <paramref name="pftDueTime"/> is zero, then the timer expires immediately.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetThreadpoolTimer", ExactSpelling = true)]
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
        /// A pointer to a <c>TP_WAIT</c> structure that defines the wait object.
        /// The <see cref="CreateThreadpoolWait"/> function returns this structure.
        /// </param>
        /// <param name="h">
        /// <para>
        /// A handle.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NULL"/>,
        /// the wait object will cease to queue new callbacks (but callbacks already queued will still occur).
        /// </para>
        /// <para>
        /// If this parameter is not <see cref="NULL"/>, it must refer to a valid waitable object.
        /// </para>
        /// <para>
        /// Mutex is not supported.
        /// If a handle to a mutex is passed in, the thread pool raises a <see cref="STATUS_THREADPOOL_HANDLE_EXCEPTION"/> exception
        /// and <c>ExceptionRecord.ExceptionInformation[0]</c> will be equal to <see cref="STATUS_INVALID_PARAMETER_3"/>.
        /// </para>
        /// <para>
        /// If this handle is closed while the wait is still pending, the function's behavior is undefined.
        /// If the wait is still pending and the handle must be closed,
        /// use <see cref="CloseThreadpoolWait"/> to cancel the wait and then close the handle.
        /// </para>
        /// <para>
        /// The wait is considered set if this parameter is non-<see cref="NULL"/>.
        /// </para>
        /// </param>
        /// <param name="pftTimeout">
        /// <para>
        /// A pointer to a <see cref="FILETIME"/> structure that specifies the absolute or relative time
        /// at which the wait operation should time out.
        /// If this parameter points to a positive value,
        /// it indicates the absolute time since January 1, 1601 (UTC), in 100-nanosecond intervals.
        /// If this parameter points to a negative value,
        /// it indicates the amount of time to wait relative to the current time.
        /// For more information about time values, see File Times.
        /// </para>
        /// <para>
        /// If this parameter points to 0, the wait times out immediately.
        /// If this parameter is <see cref="NullRef{FILETIME}"/>, the wait will not time out.
        /// </para>
        /// </param>
        /// <remarks>
        /// <para>
        /// A wait object can wait for only one handle.
        /// Setting the handle for a wait object replaces the previous handle, if any.
        /// </para>
        /// <para>
        /// You must re-register the event with the wait object before signaling it each time to trigger the wait callback.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetThreadpoolWait", ExactSpelling = true, SetLastError = true)]
        public static extern void SetThreadpoolWait([In] PTP_WAIT pwa, [In] HANDLE h, [In] in FILETIME pftTimeout);

        /// <summary>
        /// <para>
        /// Notifies the thread pool that I/O operations may possibly begin for the specified I/O completion object.
        /// A worker thread calls the I/O completion object's callback function
        /// after the operation completes on the file handle bound to this object.
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
        /// <para>
        /// You must call this function before initiating each asynchronous I/O operation on the file handle bound to the I/O completion object.
        /// Failure to do so will cause the thread pool to ignore an I/O operation when it completes and will cause memory corruption.
        /// </para>
        /// <para>
        /// If the I/O operation fails, call the <see cref="CancelThreadpoolIo"/> function to cancel this notification.
        /// </para>
        /// <para>
        /// If the file handle bound to the I/O completion object has the notification mode <see cref="FILE_SKIP_COMPLETION_PORT_ON_SUCCESS"/>
        /// and an asynchronous I/O operation returns immediately with success, 
        /// the object's I/O completion callback function is not called and threadpool I/O notifications must be canceled.
        /// For more information, see <see cref="CancelThreadpoolIo"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
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
        /// A <c>TP_WORK</c> structure that defines the work object.
        /// The <see cref="CreateThreadpoolWork"/> function returns this structure.
        /// </param>
        /// <remarks>
        /// You can post a work object one or more times (up to <see cref="MAXULONG"/>) without waiting for prior callbacks to complete.
        /// The callbacks will execute in parallel.
        /// To improve efficiency, the thread pool may throttle the threads.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
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
        /// <para>
        /// A <see cref="TP_CALLBACK_ENVIRON"/> structure that defines the environment in which to execute the callback function.
        /// The <see cref="InitializeThreadpoolEnvironment"/> function returns this structure.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NullRef{TP_CALLBACK_ENVIRON}"/>, the callback executes in the default callback environment.
        /// For more information, see <see cref="InitializeThreadpoolEnvironment"/>.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, it returns <see cref="TRUE"/>.
        /// </para>
        /// <para>
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To retrieve extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "TrySubmitThreadpoolCallback", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL TrySubmitThreadpoolCallback([In] PTP_SIMPLE_CALLBACK pfns, [In] PVOID pv, [In][Out] ref TP_CALLBACK_ENVIRON pcbe);

        /// <summary>
        /// <para>
        /// Waits for outstanding I/O completion callbacks to complete and optionally cancels pending callbacks that have not yet started to execute.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-waitforthreadpooliocallbacks"/>
        /// </para>
        /// </summary>
        /// <param name="pio">
        /// A <c>TP_IO</c> structure that defines the I/O completion object.
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
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WaitForThreadpoolIoCallbacks", ExactSpelling = true)]
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
        /// A <c>TP_TIMER</c> structure that defines the timer object.
        /// The <see cref="CreateThreadpoolTimer"/> function returns the <c>TP_TIMER</c> structure.
        /// </param>
        /// <param name="fCancelPendingCallbacks">
        /// Indicates whether to cancel queued callbacks that have not yet started to execute.
        /// </param>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WaitForThreadpoolTimerCallbacks", ExactSpelling = true)]
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
        /// A <c>TP_WAIT</c> structure that defines the wait object.
        /// The <see cref="CreateThreadpoolWait"/> function returns the <c>TP_WAIT</c> structure.
        /// </param>
        /// <param name="fCancelPendingCallbacks">
        /// Indicates whether to cancel queued callbacks that have not yet started to execute.
        /// </param>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WaitForThreadpoolWaitCallbacks", ExactSpelling = true)]
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
        /// A pointer to a <c>TP_WORK</c> structure that defines the work object.
        /// The <see cref="CreateThreadpoolWork"/> function returns this pointer.
        /// </param>
        /// <param name="fCancelPendingCallbacks">
        /// Indicates whether to cancel queued callbacks that have not yet started to execute.
        /// </param>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WaitForThreadpoolWorkCallbacks", ExactSpelling = true)]
        public static extern void WaitForThreadpoolWorkCallbacks([In] PTP_WORK pwk, [In] BOOL fCancelPendingCallbacks);
    }
}
