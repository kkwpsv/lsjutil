using static Lsj.Util.Win32.Enums.COINITBASE;
using static Lsj.Util.Win32.Ole32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Determines the concurrency model used for incoming calls to objects created by this thread.
    /// This concurrency model can be either apartment-threaded or multithreaded.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/objbase/ne-objbase-coinit
    /// </para>
    /// </summary>
    /// <remarks>
    /// When a thread is initialized through a call to <see cref="CoInitializeEx"/>, you choose whether to initialize it
    /// as apartment-threaded or multithreaded by designating one of the members of <see cref="COINIT"/> as its second parameter.
    /// This designates how incoming calls to any object created by that thread are handled, that is, the object's concurrency.
    /// Apartment-threading, while allowing for multiple threads of execution, serializes all incoming calls
    /// by requiring that calls to methods of objects created by this thread always run on the same thread, i.e. the apartment/thread that created them.
    /// In addition, calls can arrive only at message-queue boundaries.
    /// Because of this serialization, it is not typically necessary to write concurrency control into the code for the object,
    /// other than to avoid calls to <see cref="PeekMessage"/> and <see cref="SendMessage"/> during processing
    /// that must not be interrupted by other method invocations or calls to other objects in the same apartment/thread.
    /// Multi-threading (also called free-threading) allows calls to methods of objects created by this thread to be run on any thread.
    /// There is no serialization of calls, i.e. many calls may occur to the same method or to the same object or simultaneously.
    /// Multi-threaded object concurrency offers the highest performance and takes the best advantage of multiprocessor hardware for cross-thread,
    /// cross-process, and cross-machine calling, since calls to objects are not serialized in any way.
    /// This means, however, that the code for objects must enforce its own concurrency model,
    /// typically through the use of synchronization primitives, such as critical sections, semaphores, or mutexes.
    /// In addition, because the object doesn't control the lifetime of the threads that are accessing it,
    /// no thread-specific state may be stored in the object (in Thread Local Storage).
    /// Note The multi-threaded apartment is intended for use by non-GUI threads.
    /// Threads in multi-threaded apartments should not perform UI actions.
    /// This is because UI threads require a message pump, and COM does not pump messages for threads in a multi-threaded apartment.
    /// </remarks>
    public enum COINIT
    {
        /// <summary>
        /// Initializes the thread for apartment-threaded object concurrency (see Remarks).
        /// </summary>
        COINIT_APARTMENTTHREADED = 0x2,

        /// <summary>
        /// Initializes the thread for multithreaded object concurrency (see Remarks).
        /// </summary>
        COINIT_MULTITHREADED = COINITBASE_MULTITHREADED,

        /// <summary>
        /// Disables DDE for OLE1 support.
        /// </summary>
        COINIT_DISABLE_OLE1DDE = 0x4,

        /// <summary>
        /// Increase memory usage in an attempt to increase performance.
        /// </summary>
        COINIT_SPEED_OVER_MEMORY = 0x8,
    }
}
