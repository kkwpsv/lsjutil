using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="CreateToolhelp32Snapshot"/> Flags.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/tlhelp32/nf-tlhelp32-createtoolhelp32snapshot
    /// </para>
    /// </summary>
    public enum Toolhelp32SnapshotFlags : uint
    {
        /// <summary>
        /// Indicates that the snapshot handle is to be inheritable.
        /// </summary>
        TH32CS_INHERIT = 0x80000000,

        /// <summary>
        /// Includes all processes and threads in the system, plus the heaps and modules of the process specified in th32ProcessID.
        /// Equivalent to specifying the <see cref="TH32CS_SNAPHEAPLIST"/>, <see cref="TH32CS_SNAPMODULE"/>, <see cref="TH32CS_SNAPPROCESS"/>,
        /// and <see cref="TH32CS_SNAPTHREAD"/> values combined using an OR operation ('|').
        /// </summary>
        TH32CS_SNAPALL = TH32CS_SNAPHEAPLIST | TH32CS_SNAPPROCESS | TH32CS_SNAPTHREAD | TH32CS_SNAPMODULE,

        /// <summary>
        /// Includes all heaps of the process specified in th32ProcessID in the snapshot.
        /// To enumerate the heaps, see <see cref="Heap32ListFirst"/>.
        /// </summary>
        TH32CS_SNAPHEAPLIST = 0x00000001,

        /// <summary>
        /// Includes all modules of the process specified in th32ProcessID in the snapshot.
        /// To enumerate the modules, see <see cref="Module32First"/>.
        /// If the function fails with <see cref="ERROR_BAD_LENGTH"/>, retry the function until it succeeds.
        /// 64-bit Windows:
        /// Using this flag in a 32-bit process includes the 32-bit modules of the process specified in th32ProcessID,
        /// while using it in a 64-bit process includes the 64-bit modules.
        /// To include the 32-bit modules of the process specified in th32ProcessID from a 64-bit process,
        /// use the <see cref="TH32CS_SNAPMODULE32"/> flag.
        /// </summary>
        TH32CS_SNAPMODULE = 0x00000008,

        /// <summary>
        /// Includes all 32-bit modules of the process specified in th32ProcessID in the snapshot when called from a 64-bit process.
        /// This flag can be combined with <see cref="TH32CS_SNAPMODULE"/> or <see cref="TH32CS_SNAPALL"/>.
        /// If the function fails with <see cref="ERROR_BAD_LENGTH"/>, retry the function until it succeeds.
        /// </summary>
        TH32CS_SNAPMODULE32 = 0x00000010,

        /// <summary>
        /// Includes all processes in the system in the snapshot.
        /// To enumerate the processes, see <see cref="Process32First"/>.
        /// </summary>
        TH32CS_SNAPPROCESS = 0x00000002,

        /// <summary>
        /// Includes all threads in the system in the snapshot.
        /// To enumerate the threads, see <see cref="Thread32First"/>.
        /// To identify the threads that belong to a specific process,
        /// compare its process identifier to the th32OwnerProcessID member of the <see cref="THREADENTRY32"/> structure when enumerating the threads.
        /// </summary>
        TH32CS_SNAPTHREAD = 0x00000004,
    }
}
