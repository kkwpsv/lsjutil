using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.DllMainReasons;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;

namespace Lsj.Util.Win32
{
    public partial class Kernel32
    {
        /// <summary>
        /// FIBER_FLAG_FLOAT_SWITCH
        /// </summary>
        public const uint FIBER_FLAG_FLOAT_SWITCH = 0x1;


        /// <summary>
        /// <para>
        /// An application-defined function used with the <see cref="CreateFiber"/> function.
        /// It serves as the starting address for a fiber.
        /// The <see cref="LPFIBER_START_ROUTINE"/> type defines a pointer to this callback function.
        /// FiberProc is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nc-winbase-pfiber_start_routine
        /// </para>
        /// </summary>
        /// <param name="lpFiberParameter"></param>
        public delegate void LPFIBER_START_ROUTINE([In] LPVOID lpFiberParameter);


        /// <summary>
        /// <para>
        /// An application-defined function.
        /// If the FLS slot is in use, FlsCallback is called on fiber deletion, thread exit, and when an FLS index is freed.
        /// Specify this function when calling the <see cref="FlsAlloc"/> function.
        /// The <see cref="PFLS_CALLBACK_FUNCTION"/> type defines a pointer to this callback function.
        /// FlsCallback is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/nc-winnt-pfls_callback_function
        /// </para>
        /// </summary>
        /// <param name="lpFlsData">
        /// The value stored in the FLS slot for the calling fiber.
        /// </param>
        /// <remarks>
        /// Each FLS index has an associated FlsCallback function.
        /// The callback function can be used for any purpose, but it is intended to be used primarily to free memory.
        /// </remarks>
        public delegate void PFLS_CALLBACK_FUNCTION([In] PVOID lpFlsData);

        /// <summary>
        /// <para>
        /// Converts the current thread into a fiber.
        /// You must convert a thread into a fiber before you can schedule other fibers.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-convertthreadtofiber
        /// </para>
        /// </summary>
        /// <param name="lpParameter">
        /// A pointer to a variable that is passed to the fiber.
        /// The fiber can retrieve this data by using the <see cref="GetFiberData"/> macro.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the address of the fiber.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Only fibers can execute other fibers.
        /// If a thread needs to execute a fiber, it must call <see cref="ConvertThreadToFiber"/>
        /// or <see cref="ConvertThreadToFiberEx"/> to create an area in which to save fiber state information.
        /// The thread is now the current fiber.
        /// The state information for this fiber includes the fiber data specified by <paramref name="lpParameter"/>.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0400 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ConvertThreadToFiber", ExactSpelling = true, SetLastError = true)]
        public static extern LPVOID ConvertThreadToFiber([In] LPVOID lpParameter);

        /// <summary>
        /// <para>
        /// Converts the current thread into a fiber.
        /// You must convert a thread into a fiber before you can schedule other fibers.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-convertthreadtofiberex
        /// </para>
        /// </summary>
        /// <param name="lpParameter">
        /// A pointer to a variable that is passed to the fiber.
        /// The fiber can retrieve this data by using the <see cref="GetFiberData"/> macro.
        /// </param>
        /// <param name="dwFlags">
        /// If this parameter is zero, the floating-point state on x86 systems is not switched
        /// and data can be corrupted if a fiber uses floating-point arithmetic.
        /// If this parameter is <see cref="FIBER_FLAG_FLOAT_SWITCH"/>, the floating-point state is switched for the fiber.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the address of the fiber.
        /// If the function fails, the return value is NULL.
        /// To get extended error information, call GetLastError.
        /// </returns>
        /// <remarks>
        /// Only fibers can execute other fibers.
        /// If a thread needs to execute a fiber, it must call <see cref="ConvertThreadToFiber"/> or <see cref="ConvertThreadToFiberEx"/>
        /// to create an area in which to save fiber state information.
        /// The thread is now the current fiber. The state information for this fiber
        /// includes the fiber data specified by <paramref name="lpParameter"/>.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0400 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ConvertThreadToFiberEx", ExactSpelling = true, SetLastError = true)]
        public static extern LPVOID ConvertThreadToFiberEx([In] LPVOID lpParameter, [In] DWORD dwFlags);

        /// <summary>
        /// <para>
        /// Allocates a fiber object, assigns it a stack, and sets up execution to begin at the specified start address, typically the fiber function.
        /// This function does not schedule the fiber.
        /// To specify both a commit and reserve stack size, use the <see cref="CreateFiberEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-createfiber
        /// </para>
        /// </summary>
        /// <param name="dwStackSize">
        /// The initial committed size of the stack, in bytes.
        /// If this parameter is zero, the new fiber uses the default commit stack size for the executable.
        /// For more information, see Thread Stack Size.
        /// </param>
        /// <param name="lpStartAddress">
        /// A pointer to the application-defined function to be executed by the fiber and represents the starting address of the fiber.
        /// Execution of the newly created fiber does not begin until another fiber calls the <see cref="SwitchToFiber"/> function with this address.
        /// For more information of the fiber callback function, see FiberProc.
        /// </param>
        /// <param name="lpParameter">
        /// A pointer to a variable that is passed to the fiber.
        /// The fiber can retrieve this data by using the <see cref="GetFiberData"/> macro.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the address of the fiber.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The number of fibers a process can create is limited by the available virtual memory.
        /// For example, if you create each fiber with 1 megabyte of reserved stack space, you can create at most 2028 fibers.
        /// If you reduce the default stack size by using the STACKSIZE statement in the module definition (.def) file
        /// or by using <see cref="CreateFiberEx"/>, you can create more fibers.
        /// However, your application will have better performance if you use an alternate strategy
        /// for processing requests instead of creating such a large number of fibers.
        /// Before a thread can schedule a fiber using the <see cref="SwitchToFiber"/> function,
        /// it must call the <see cref="ConvertThreadToFiber"/> function so there is a fiber associated with the thread.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0400 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateFiber", ExactSpelling = true, SetLastError = true)]
        public static extern LPVOID CreateFiber([In] SIZE_T dwStackSize, [In] LPFIBER_START_ROUTINE lpStartAddress, [In] LPVOID lpParameter);

        /// <summary>
        /// <para>
        /// Allocates a fiber object, assigns it a stack, and sets up execution to begin at the specified start address, typically the fiber function.
        /// This function does not schedule the fiber.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-createfiberex
        /// </para>
        /// </summary>
        /// <param name="dwStackCommitSize">
        /// The initial commit size of the stack, in bytes.
        /// If this parameter is zero, the new fiber uses the default commit stack size for the executable.
        /// For more information, see Thread Stack Size.
        /// </param>
        /// <param name="dwStackReserveSize">
        /// The initial reserve size of the stack, in bytes.
        /// If this parameter is zero, the new fiber uses the default reserved stack size for the executable.
        /// For more information, see Thread Stack Size.
        /// </param>
        /// <param name="dwFlags">
        /// If this parameter is zero, the floating-point state on x86 systems is not switched and data can be corrupted
        /// if a fiber uses floating-point arithmetic.
        /// If this parameter is <see cref="FIBER_FLAG_FLOAT_SWITCH"/>, the floating-point state is switched for the fiber.
        /// Windows XP: The <see cref="FIBER_FLAG_FLOAT_SWITCH"/> flag is not supported.
        /// </param>
        /// <param name="lpStartAddress">
        /// A pointer to the application-defined function to be executed by the fiber and represents the starting address of the fiber.
        /// Execution of the newly created fiber does not begin until another fiber calls the <see cref="SwitchToFiber"/> function with this address.
        /// For more information on the fiber callback function, see FiberProc.
        /// </param>
        /// <param name="lpParameter">
        /// A pointer to a variable that is passed to the fiber.
        /// The fiber can retrieve this data by using the <see cref="GetFiberData"/> macro.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the address of the fiber.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The number of fibers a process can create is limited by the available virtual memory.
        /// By default, every fiber has 1 megabyte of reserved stack space.
        /// Therefore, you can create at most 2028 fibers.
        /// If you reduce the default stack size, you can create more fibers.
        /// However, your application will have better performance if you use an alternate strategy for processing requests.
        /// Before a thread can schedule a fiber using the <see cref="SwitchToFiber"/> function,
        /// it must call the <see cref="ConvertThreadToFiber"/> function so there is a fiber associated with the thread.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0400 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateFiberEx", ExactSpelling = true, SetLastError = true)]
        public static extern LPVOID CreateFiberEx([In] SIZE_T dwStackCommitSize, [In] SIZE_T dwStackReserveSize, [In] DWORD dwFlags,
            [In] LPFIBER_START_ROUTINE lpStartAddress, [In] LPVOID lpParameter);

        /// <summary>
        /// <para>
        /// Allocates a fiber local storage (FLS) index.
        /// Any fiber in the process can subsequently use this index to store and retrieve values that are local to the fiber.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/fibersapi/nf-fibersapi-flsalloc
        /// </para>
        /// </summary>
        /// <param name="lpCallback">
        /// A pointer to the application-defined callback function of type <see cref="PFLS_CALLBACK_FUNCTION"/>.
        /// This parameter is optional.
        /// For more information, see <see cref="PFLS_CALLBACK_FUNCTION"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is an FLS index initialized to zero.
        /// If the function fails, the return value is <see cref="FLS_OUT_OF_INDEXES"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The fibers of the process can use the FLS index in subsequent calls to the <see cref="FlsFree"/>,
        /// <see cref="FlsSetValue"/>, or <see cref="FlsGetValue"/> functions.
        /// FLS indexes are typically allocated during process or dynamic-link library (DLL) initialization.
        /// After an FLS index has been allocated, each fiber of the process can use it to access its own FLS storage slot.
        /// To store a value in its FLS slot, a fiber specifies the index in a call to <see cref="FlsSetValue"/>.
        /// The fiber specifies the same index in a subsequent call to <see cref="FlsGetValue"/> to retrieve the stored value.
        /// FLS indexes are not valid across process boundaries.
        /// A DLL cannot assume that an index assigned in one process is valid in another process.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FlsAlloc", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD FlsAlloc([In] PFLS_CALLBACK_FUNCTION lpCallback);

        /// <summary>
        /// <para>
        /// Releases a fiber local storage (FLS) index, making it available for reuse.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/fibersapi/nf-fibersapi-flsfree
        /// </para>
        /// </summary>
        /// <param name="dwFlsIndex">
        /// The FLS index that was allocated by the <see cref="FlsAlloc"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Freeing an FLS index frees the index for all instances of FLS in the current process.
        /// Freeing an FLS index also causes the associated callback routine to be called for each fiber,
        /// if the corresponding FLS slot contains a non-NULL value.
        /// If the fibers of the process have allocated memory and stored a pointer to the memory in an FLS slot,
        /// they should free the memory before calling <see cref="FlsFree"/>.
        /// The <see cref="FlsFree"/> function does not free memory blocks whose addresses have been stored in the FLS slots associated with the FLS index.
        /// It is expected that DLLs call this function (if at all) only during <see cref="DLL_PROCESS_DETACH"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FlsFree", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL FlsFree([In] DWORD dwFlsIndex);

        /// <summary>
        /// <para>
        /// Retrieves the value in the calling fiber's fiber local storage (FLS) slot for the specified FLS index.
        /// Each fiber has its own slot for each FLS index.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/fibersapi/nf-fibersapi-flsgetvalue
        /// </para>
        /// </summary>
        /// <param name="dwFlsIndex">
        /// The FLS index that was allocated by the <see cref="FlsAlloc"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the value stored in the calling fiber's FLS slot associated with the specified index.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// FLS indexes are typically allocated by the <see cref="FlsAlloc"/> function during process or DLL initialization.
        /// After an FLS index is allocated, each fiber of the process can use it to access its own FLS slot for that index.
        /// A fiber specifies an FLS index in a call to FlsSetValue to store a value in its slot.
        /// The thread specifies the same index in a subsequent call to <see cref="FlsSetValue"/> to retrieve the stored value.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FlsGetValue", ExactSpelling = true, SetLastError = true)]
        public static extern PVOID FlsGetValue([In] DWORD dwFlsIndex);

        /// <summary>
        /// <para>
        /// Stores a value in the calling fiber's fiber local storage (FLS) slot for the specified FLS index.
        /// Each fiber has its own slot for each FLS index.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/fibersapi/nf-fibersapi-flssetvalue
        /// </para>
        /// </summary>
        /// <param name="dwFlsIndex">
        /// The FLS index that was allocated by the FlsAlloc function.
        /// </param>
        /// <param name="lpFlsData">
        /// The value to be stored in the FLS slot for the calling fiber.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// The following errors can be returned.
        /// <see cref="ERROR_INVALID_PARAMETER"/>: The index is not in range.
        /// ERROR_NO_MEMORY: The FLS array has not been allocated.
        /// </returns>
        /// <remarks>
        /// FLS indexes are typically allocated by the <see cref="FlsAlloc"/> function during process or DLL initialization.
        /// After an FLS index is allocated, each fiber of the process can use it to access its own FLS slot for that index.
        /// A thread specifies an FLS index in a call to <see cref="FlsSetValue"/> to store a value in its slot.
        /// The thread specifies the same index in a subsequent call to <see cref="FlsGetValue"/> to retrieve the stored value.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FlsSetValue", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL FlsSetValue([In] DWORD dwFlsIndex, [In] PVOID lpFlsData);

        /// <summary>
        /// <para>
        /// Schedules a fiber. The function must be called on a fiber.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-switchtofiber
        /// </para>
        /// </summary>
        /// <param name="lpFiber">
        /// The address of the fiber to be scheduled.
        /// </param>
        /// <remarks>
        /// You create fibers with the <see cref="CreateFiber"/> function.
        /// Before you can schedule fibers associated with a thread,
        /// you must call <see cref="ConvertThreadToFiber"/> to set up an area in which to save the fiber state information.
        /// The thread is now the currently executing fiber.
        /// The <see cref="SwitchToFiber"/> function saves the state information of the current fiber and restores the state of the specified fiber.
        /// You can call <see cref="SwitchToFiber"/> with the address of a fiber created by a different thread.
        /// To do this, you must have the address returned to the other thread
        /// when it called <see cref="CreateFiber"/> and you must use proper synchronization.
        /// Avoid making the following call:
        /// <code>SwitchToFiber( GetCurrentFiber() );</code>
        /// This call can cause unpredictable problems.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0400 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SwitchToFiber", ExactSpelling = true, SetLastError = true)]
        public static extern void SwitchToFiber([In] LPVOID lpFiber);
    }
}
