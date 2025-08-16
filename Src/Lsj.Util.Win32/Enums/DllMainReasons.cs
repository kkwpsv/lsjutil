namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// DllMain reasons
    /// </summary>
    public enum DllMainReasons : uint
    {
        /// <summary>
        /// DLL_PROCESS_ATTACH
        /// </summary>
        DLL_PROCESS_ATTACH = 1,

        /// <summary>
        /// DLL_PROCESS_DETACH
        /// </summary>
        DLL_PROCESS_DETACH = 0,

        /// <summary>
        /// DLL_THREAD_ATTACH
        /// </summary>
        DLL_THREAD_ATTACH = 2,

        /// <summary>
        /// DLL_THREAD_DETACH
        /// </summary>
        DLL_THREAD_DETACH = 3,
    }
}
