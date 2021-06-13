using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Represents the type of processor cache identified in the corresponding <see cref="CACHE_DESCRIPTOR"/> structure.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ne-winnt-processor_cache_type"/>
    /// </para>
    /// </summary>
    public enum PROCESSOR_CACHE_TYPE
    {
        /// <summary>
        /// The cache is unified.
        /// </summary>
        CacheUnified,

        /// <summary>
        /// The cache is for processor instructions.
        /// </summary>
        CacheInstruction,

        /// <summary>
        /// The cache is for data.
        /// </summary>
        CacheData,

        /// <summary>
        /// The cache is for traces.
        /// </summary>
        CacheTrace
    }
}
