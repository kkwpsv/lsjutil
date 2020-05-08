namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// MemoryTypes
    /// </summary>
    public enum MemoryTypes : uint
    {
        /// <summary>
        /// MEM_PRIVATE
        /// </summary>
        MEM_PRIVATE = 0x00020000,

        /// <summary>
        /// MEM_MAPPED
        /// </summary>
        MEM_MAPPED = 0x00040000,

        /// <summary>
        /// MEM_IMAGE
        /// </summary>
        MEM_IMAGE = 0x01000000,
    }
}
