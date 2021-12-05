namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Determines the concurrency model used for incoming calls to the objects created by this thread.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/roapi/ne-roapi-ro_init_type"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Pass the <see cref="RO_INIT_TYPE"/> enumeration to the RoInitialize function to initialize a thread in the Windows Runtime.
    /// </remarks>
    public enum RO_INIT_TYPE
    {
        /// <summary>
        /// 
        /// </summary>
        RO_INIT_SINGLETHREADED,

        /// <summary>
        /// Initializes the thread for multi-threaded concurrency.
        /// The current thread is initialized in the MTA.
        /// </summary>
        RO_INIT_MULTITHREADED
    }
}
