using System;
using static Lsj.Util.Win32.Enums.NTSTATUS;
using static Lsj.Util.Win32.Enums.SectionAttributes;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The following are the memory-protection options; you must specify one of the following values when allocating or protecting a page in memory.
    /// Protection attributes cannot be assigned to a portion of a page; they can only be assigned to a whole page.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/memory/memory-protection-constants
    /// </para>
    /// </summary>
    [Flags]
    public enum MemoryProtectionConstants : uint
    {
        /// <summary>
        /// Enables execute access to the committed region of pages. An attempt to write to the committed region results in an access violation.
        /// This flag is not supported by the <see cref="CreateFileMapping"/> function.
        /// </summary>
        PAGE_EXECUTE = 0x10,

        /// <summary>
        /// Enables execute or read-only access to the committed region of pages.
        /// An attempt to write to the committed region results in an access violation.
        /// Windows Server 2003 and Windows XP: This attribute is not supported by the <see cref="CreateFileMapping"/> function
        /// until Windows XP with SP2 and Windows Server 2003 with SP1.
        /// </summary>
        PAGE_EXECUTE_READ = 0x20,

        /// <summary>
        /// Enables execute, read-only, or read/write access to the committed region of pages.
        /// Windows Server 2003 and Windows XP: This attribute is not supported by the <see cref="CreateFileMapping"/> function
        /// until Windows XP with SP2 and Windows Server 2003 with SP1.
        /// </summary>
        PAGE_EXECUTE_READWRITE = 0x40,

        /// <summary>
        /// Enables execute, read-only, or copy-on-write access to a mapped view of a file mapping object.
        /// An attempt to write to a committed copy-on-write page results in a private copy of the page being made for the process.
        /// The private page is marked as <see cref="PAGE_EXECUTE_READWRITE"/>, and the change is written to the new page.
        /// This flag is not supported by the <see cref="VirtualAlloc"/> or <see cref="VirtualAllocEx"/> functions.
        /// Windows Vista, Windows Server 2003 and Windows XP: This attribute is not supported by the <see cref="CreateFileMapping"/> function
        /// until Windows Vista with SP1 and Windows Server 2008.
        /// </summary>
        PAGE_EXECUTE_WRITECOPY = 0x80,

        /// <summary>
        /// Disables all access to the committed region of pages.
        /// An attempt to read from, write to, or execute the committed region results in an access violation.
        /// This flag is not supported by the <see cref="CreateFileMapping"/> function.
        /// </summary>
        PAGE_NOACCESS = 0x01,

        /// <summary>
        /// Enables read-only access to the committed region of pages.
        /// An attempt to write to the committed region results in an access violation.
        /// If Data Execution Prevention is enabled, an attempt to execute code in the committed region results in an access violation.
        /// </summary>
        PAGE_READONLY = 0x02,

        /// <summary>
        /// Enables read-only or read/write access to the committed region of pages.
        /// If Data Execution Prevention is enabled, attempting to execute code in the committed region results in an access violation.
        /// </summary>
        PAGE_READWRITE = 0x04,

        /// <summary>
        /// Enables read-only or copy-on-write access to a mapped view of a file mapping object.
        /// An attempt to write to a committed copy-on-write page results in a private copy of the page being made for the process.
        /// The private page is marked as <see cref="PAGE_READWRITE"/>, and the change is written to the new page.
        /// If Data Execution Prevention is enabled, attempting to execute code in the committed region results in an access violation.
        /// This flag is not supported by the <see cref="VirtualAlloc"/> or <see cref="VirtualAllocEx"/> functions.
        /// </summary>
        PAGE_WRITECOPY = 0x08,

        /// <summary>
        /// Sets all locations in the pages as invalid targets for CFG.
        /// Used along with any execute page protection like <see cref="PAGE_EXECUTE"/>, <see cref="PAGE_EXECUTE_READ"/>,
        /// <see cref="PAGE_EXECUTE_READWRITE"/> and <see cref="PAGE_EXECUTE_WRITECOPY"/>.
        /// Any indirect call to locations in those pages will fail CFG checks and the process will be terminated.
        /// The default behavior for executable pages allocated is to be marked valid call targets for CFG.
        /// This flag is not supported by the <see cref="VirtualProtect"/> or <see cref="CreateFileMapping"/> functions.
        /// </summary>
        PAGE_TARGETS_INVALID = 0x40000000,

        /// <summary>
        /// Pages in the region will not have their CFG information updated while the protection changes for <see cref="VirtualProtect"/>.
        /// For example, if the pages in the region was allocated using <see cref="PAGE_TARGETS_INVALID"/>,
        /// then the invalid information will be maintained while the page protection changes.
        /// This flag is only valid when the protection changes to an executable type like <see cref="PAGE_EXECUTE"/>,
        /// <see cref="PAGE_EXECUTE_READ"/>, <see cref="PAGE_EXECUTE_READWRITE"/> and <see cref="PAGE_EXECUTE_WRITECOPY"/>.
        /// The default behavior for <see cref="VirtualProtect"/> protection change to executable is to mark all locations as valid call targets for CFG.
        /// </summary>
        PAGE_TARGETS_NO_UPDATE = 0x40000000,

        /// <summary>
        /// Pages in the region become guard pages.
        /// Any attempt to access a guard page causes the system to raise a <see cref="STATUS_GUARD_PAGE_VIOLATION"/> exception
        /// and turn off the guard page status.
        /// Guard pages thus act as a one-time access alarm. For more information, see Creating Guard Pages.
        /// When an access attempt leads the system to turn off guard page status, the underlying page protection takes over.
        /// If a guard page exception occurs during a system service, the service typically returns a failure status indicator.
        /// This value cannot be used with <see cref="PAGE_NOACCESS"/>.
        /// This flag is not supported by the <see cref="CreateFileMapping"/> function.
        /// </summary>
        PAGE_GUARD = 0x100,

        /// <summary>
        /// Sets all pages to be non-cachable.
        /// Applications should not use this attribute except when explicitly required for a device.
        /// Using the interlocked functions with memory that is mapped
        /// with <see cref="SEC_NOCACHE"/> can result in an EXCEPTION_ILLEGAL_INSTRUCTION exception.
        /// The <see cref="PAGE_NOCACHE"/> flag cannot be used with the <see cref="PAGE_GUARD"/>,
        /// <see cref="PAGE_NOACCESS"/>, or <see cref="PAGE_WRITECOMBINE"/> flags.
        /// The <see cref="PAGE_NOCACHE"/> flag can be used only when allocating private memory with the <see cref="VirtualAlloc"/>,
        /// <see cref="VirtualAllocEx"/>, or <see cref="VirtualAllocExNuma"/> functions.
        /// To enable non-cached memory access for shared memory, specify the <see cref="SEC_NOCACHE"/> flag
        /// when calling the <see cref="CreateFileMapping"/> function.
        /// </summary>
        PAGE_NOCACHE = 0x200,

        /// <summary>
        /// Sets all pages to be write-combined.
        /// Applications should not use this attribute except when explicitly required for a device.
        /// Using the interlocked functions with memory that is mapped as write-combined
        /// can result in an EXCEPTION_ILLEGAL_INSTRUCTION exception.
        /// The <see cref="PAGE_WRITECOMBINE"/> flag cannot be specified with the <see cref="PAGE_NOACCESS"/>,
        /// <see cref="PAGE_GUARD"/>, and <see cref="PAGE_NOCACHE"/> flags.
        /// The <see cref="PAGE_WRITECOMBINE"/> flag can be used only when allocating private memory with the <see cref="VirtualAlloc"/>,
        /// <see cref="VirtualAllocEx"/>, or <see cref="VirtualAllocExNuma"/> functions.
        /// To enable write-combined memory access for shared memory, specify the <see cref="SEC_WRITECOMBINE"/> flag
        /// when calling the <see cref="CreateFileMapping"/> function.
        /// Windows Server 2003 and Windows XP: This flag is not supported until Windows Server 2003 with SP1.
        /// </summary>
        PAGE_WRITECOMBINE = 0x400,

        /// <summary>
        /// The page contains a thread control structure (TCS).
        /// </summary>
        PAGE_ENCLAVE_THREAD_CONTROL = 0x80000000,

        /// <summary>
        /// The page contents that you supply are excluded from measurement with the EEXTEND instruction of the Intel SGX programming model.
        /// </summary>
        PAGE_ENCLAVE_UNVALIDATED = 0x20000000,
    }
}
