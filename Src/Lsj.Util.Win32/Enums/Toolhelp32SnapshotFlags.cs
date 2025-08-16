using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="CreateToolhelp32Snapshot"/> flags
    /// </summary>
    public enum Toolhelp32SnapshotFlags : uint
    {
        /// <summary>
        /// TH32CS_INHERIT
        /// </summary>
        TH32CS_INHERIT = 0x80000000,

        /// <summary>
        /// TH32CS_SNAPALL
        /// </summary>
        TH32CS_SNAPALL = TH32CS_SNAPHEAPLIST | TH32CS_SNAPPROCESS | TH32CS_SNAPTHREAD | TH32CS_SNAPMODULE,

        /// <summary>
        /// TH32CS_SNAPHEAPLIST
        /// </summary>
        TH32CS_SNAPHEAPLIST = 0x00000001,

        /// <summary>
        /// TH32CS_SNAPMODULE
        /// </summary>
        TH32CS_SNAPMODULE = 0x00000008,

        /// <summary>
        /// TH32CS_SNAPMODULE32
        /// </summary>
        TH32CS_SNAPMODULE32 = 0x00000010,

        /// <summary>
        /// TH32CS_SNAPPROCESS
        /// </summary>
        TH32CS_SNAPPROCESS = 0x00000002,

        /// <summary>
        /// TH32CS_SNAPTHREAD
        /// </summary>
        TH32CS_SNAPTHREAD = 0x00000004,
    }
}
