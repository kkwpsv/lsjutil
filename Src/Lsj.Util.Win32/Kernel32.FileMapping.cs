using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.ExceptionCodes;
using static Lsj.Util.Win32.Enums.FileMapAccessRights;
using static Lsj.Util.Win32.Enums.GenericAccessRights;
using static Lsj.Util.Win32.Enums.MemoryAllocationTypes;
using static Lsj.Util.Win32.Enums.MemoryProtectionConstants;
using static Lsj.Util.Win32.Enums.SectionAttributes;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.VirtualFreeTypes;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// Creates or opens a named or unnamed file mapping object for a specified file.
        /// To specify the NUMA node for the physical memory, see <see cref="CreateFileMappingNuma"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-createfilemappingw"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the file from which to create a file mapping object.
        /// The file must be opened with access rights that are compatible with the protection flags
        /// that the <paramref name="flProtect"/> parameter specifies.
        /// It is not required, but it is recommended that files you intend to map be opened for exclusive access.
        /// For more information, see File Security and Access Rights.
        /// If hFile is <see cref="INVALID_HANDLE_VALUE"/>, the calling process must also specify a size for the file mapping object
        /// in the <paramref name="dwMaximumSizeHigh"/> and <paramref name="dwMaximumSizeLow"/> parameters.
        /// In this scenario, <see cref="CreateFileMapping"/> creates a file mapping object of a specified size
        /// that is backed by the system paging file instead of by a file in the file system.
        /// </param>
        /// <param name="lpFileMappingAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that determines whether a returned handle can be inherited by child processes.
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the <see cref="SECURITY_ATTRIBUTES"/> structure
        /// specifies a security descriptor for a new file mapping object.
        /// If <paramref name="lpFileMappingAttributes"/> is <see langword="null"/>, the handle cannot be inherited
        /// and the file mapping object gets a default security descriptor.
        /// The access control lists (ACL) in the default security descriptor for a file mapping object come from the primary
        /// or impersonation token of the creator.
        /// For more information, see File Mapping Security and Access Rights.
        /// </param>
        /// <param name="flProtect">
        /// Specifies the page protection of the file mapping object.
        /// All mapped views of the object must be compatible with this protection.
        /// This parameter can be one of the following values.
        /// <see cref="PAGE_EXECUTE_READ"/> :
        /// Allows views to be mapped for read-only, copy-on-write, or execute access.
        /// The file handle specified by the <paramref name="hFile"/> parameter must be created
        /// with the <see cref="GENERIC_READ"/> and <see cref="GENERIC_WRITE"/> access rights.
        /// Windows Server 2003 and Windows XP:  This value is not available until Windows XP with SP2 and Windows Server 2003 with SP1.
        /// <see cref="PAGE_EXECUTE_READWRITE"/>:
        /// Allows views to be mapped for read-only, copy-on-write, read/write, or execute access.
        /// The file handle that the <paramref name="hFile"/> parameter specifies must be created
        /// with the <see cref="GENERIC_READ"/>, <see cref="GENERIC_WRITE"/>,
        /// and <see cref="GENERIC_EXECUTE"/> access rights.
        /// Windows Server 2003 and Windows XP:  This value is not available until Windows XP with SP2 and Windows Server 2003 with SP1.
        /// <see cref="PAGE_EXECUTE_WRITECOPY"/>:
        /// Allows views to be mapped for read-only, copy-on-write, or execute access.
        /// This value is equivalent to <see cref="PAGE_EXECUTE_READ"/>.
        /// The file handle specified by the <paramref name="hFile"/> parameter must be created
        /// with the <see cref="GENERIC_READ"/> and <see cref="GENERIC_WRITE"/> access rights.
        /// Windows Vista:  This value is not available until Windows Vista with SP1.
        /// Windows Server 2003 and Windows XP:  This value is not supported.
        /// <see cref="PAGE_READONLY"/>:
        /// Allows views to be mapped for read-only or copy-on-write access.
        /// An attempt to write to a specific region results in an access violation.
        /// The file handle that the <paramref name="hFile"/> parameter specifies must be created
        /// with the <see cref="GENERIC_READ"/> access right.
        /// <see cref="PAGE_READWRITE"/>:
        /// Allows views to be mapped for read-only, copy-on-write, or read/write access.
        /// The file handle specified by the <paramref name="hFile"/> parameter must be created
        /// with the <see cref="GENERIC_READ"/> and <see cref="GENERIC_WRITE"/> access rights.
        /// <see cref="PAGE_WRITECOPY"/>:
        /// Allows views to be mapped for read-only or copy-on-write access.
        /// This value is equivalent to <see cref="PAGE_READONLY"/>.
        /// The file handle that the <paramref name="hFile"/> parameter specifies must be created
        /// with the <see cref="GENERIC_READ"/> access right.
        /// An application can specify one or more of the following attributes for the file mapping object by combining them
        /// with one of the preceding page protection values.
        /// <see cref="SEC_COMMIT"/>:
        /// If the file mapping object is backed by the operating system paging file 
        /// (the <paramref name="hFile"/> parameter is <see cref="INVALID_HANDLE_VALUE"/>),
        /// specifies that when a view of the file is mapped into a process address space,
        /// the entire range of pages is committed rather than reserved.
        /// The system must have enough committable pages to hold the entire mapping.
        /// Otherwise, <see cref="CreateFileMapping"/> fails.
        /// This attribute has no effect for file mapping objects that are backed by executable image files or data files 
        /// (the <paramref name="hFile"/> parameter is a handle to a file).
        /// <see cref="SEC_COMMIT"/> cannot be combined with <see cref="SEC_RESERVE"/>.
        /// <see cref="SEC_IMAGE"/>:
        /// Specifies that the file that the <paramref name="hFile"/> parameter specifies is an executable image file.
        /// The <see cref="SEC_IMAGE"/> attribute must be combined
        /// with a page protection value such as <see cref="PAGE_READONLY"/>.
        /// However, this page protection value has no effect on views of the executable image file.
        /// Page protection for views of an executable image file is determined by the executable file itself.
        /// No other attributes are valid with <see cref="SEC_IMAGE"/>.
        /// <see cref="SEC_IMAGE_NO_EXECUTE"/>:
        /// Specifies that the file that the hFile parameter specifies is an executable image file that will not be executed
        /// and the loaded image file will have no forced integrity checks run.
        /// Additionally, mapping a view of a file mapping object created with the <see cref="SEC_IMAGE_NO_EXECUTE"/> attribute
        /// will not invoke driver callbacks registered using the PsSetLoadImageNotifyRoutine kernel API.
        /// The <see cref="SEC_IMAGE_NO_EXECUTE"/> attribute must be combined
        /// with the <see cref="PAGE_READONLY"/> page protection value.
        /// No other attributes are valid with <see cref="SEC_IMAGE_NO_EXECUTE"/>.
        /// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// This value is not supported before Windows Server 2012 and Windows 8.
        /// <see cref="SEC_LARGE_PAGES"/>:
        /// Enables large pages to be used for file mapping objects that are backed by the operating system paging file
        /// (the <paramref name="hFile"/> parameter is <see cref="INVALID_HANDLE_VALUE"/>).
        /// This attribute is not supported for file mapping objects that are backed by executable image files or data files
        /// (the <paramref name="hFile"/> parameter is a handle to an executable image or data file).
        /// The maximum size of the file mapping object must be a multiple of the minimum size of a large page
        /// returned by the <see cref="GetLargePageMinimum"/> function.
        /// If it is not, <see cref="CreateFileMapping"/> fails.
        /// When mapping a view of a file mapping object created with <see cref="SEC_LARGE_PAGES"/>,
        /// the base address and view size must also be multiples of the minimum large page size.
        /// <see cref="SEC_LARGE_PAGES"/> requires the SeLockMemoryPrivilege privilege
        /// to be enabled in the caller's token.
        /// If <see cref="SEC_LARGE_PAGES"/> is specified, <see cref="SEC_COMMIT"/> must also be specified.
        /// Windows Server 2003:  This value is not supported until Windows Server 2003 with SP1.
        /// Windows XP:  This value is not supported.
        /// <see cref="SEC_NOCACHE"/>:
        /// Sets all pages to be non-cachable.
        /// Applications should not use this attribute except when explicitly required for a device.
        /// Using the interlocked functions with memory that is mapped with <see cref="SEC_NOCACHE"/>
        /// can result in an EXCEPTION_ILLEGAL_INSTRUCTION exception.
        /// <see cref="SEC_NOCACHE"/> requires either
        /// the <see cref="SEC_RESERVE"/> or <see cref="SEC_COMMIT"/> attribute to be set.
        /// <see cref="SEC_RESERVE"/>:
        /// If the file mapping object is backed by the operating system paging file
        /// (the <paramref name="hFile"/> parameter is <see cref="INVALID_HANDLE_VALUE"/>),
        /// specifies that when a view of the file is mapped into a process address space,
        /// the entire range of pages is reserved for later use by the process rather than committed.
        /// Reserved pages can be committed in subsequent calls to the <see cref="VirtualAlloc"/> function.
        /// After the pages are committed, they cannot be freed or decommitted with the <see cref="VirtualFree"/> function.
        /// This attribute has no effect for file mapping objects that are backed by executable image files or data files
        /// (the <paramref name="hFile"/> parameter is a handle to a file).
        /// <see cref="SEC_RESERVE"/> cannot be combined with <see cref="SEC_COMMIT"/>.
        /// <see cref="SEC_WRITECOMBINE"/>:
        /// Sets all pages to be write-combined.
        /// Applications should not use this attribute except when explicitly required for a device.
        /// Using the interlocked functions with memory that is mapped with <see cref="SEC_WRITECOMBINE"/>
        /// can result in an EXCEPTION_ILLEGAL_INSTRUCTION exception.
        /// <see cref="SEC_WRITECOMBINE"/> requires either
        /// the <see cref="SEC_RESERVE"/> or <see cref="SEC_COMMIT"/> attribute to be set.
        /// Windows Server 2003 and Windows XP:  This flag is not supported until Windows Vista.
        /// </param>
        /// <param name="dwMaximumSizeHigh">
        /// The high-order DWORD of the maximum size of the file mapping object.
        /// </param>
        /// <param name="dwMaximumSizeLow">
        /// The low-order DWORD of the maximum size of the file mapping object.
        /// If this parameter and <paramref name="dwMaximumSizeHigh"/> are 0 (zero),
        /// the maximum size of the file mapping object is equal to the current size of the file that <paramref name="hFile"/> identifies.
        /// An attempt to map a file with a length of 0 (zero) fails with an error code of <see cref="ERROR_FILE_INVALID"/>.
        /// Applications should test for files with a length of 0 (zero) and reject those files.
        /// </param>
        /// <param name="lpName">
        /// The name of the file mapping object.
        /// If this parameter matches the name of an existing mapping object,
        /// the function requests access to the object with the protection that <paramref name="flProtect"/> specifies.
        /// If this parameter is <see langword="null"/>, the file mapping object is created without a name.
        /// If <paramref name="lpName"/> matches the name of an existing event, semaphore, mutex, waitable timer, or job object,
        /// the function fails, and the <see cref="GetLastError"/> function returns <see cref="ERROR_INVALID_HANDLE"/>.
        /// This occurs because these objects share the same namespace.
        /// The name can have a "Global" or "Local" prefix to explicitly create the object in the global or session namespace.
        /// The remainder of the name can contain any character except the backslash character ().
        /// Creating a file mapping object in the global namespace from a session other than session zero
        /// requires the SeCreateGlobalPrivilege privilege.
        /// For more information, see Kernel Object Namespaces.
        /// Fast user switching is implemented by using Terminal Services sessions.
        /// The first user to log on uses session 0 (zero), the next user to log on uses session 1 (one), and so on.
        /// Kernel object names must follow the guidelines that are outlined for Terminal Services so that applications can support multiple users.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the newly created file mapping object.
        /// If the object exists before the function call, the function returns a handle to the existing object (with its current size,
        /// not the specified size), and <see cref="GetLastError"/> returns <see cref="ERROR_ALREADY_EXISTS"/>.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// After a file mapping object is created, the size of the file must not exceed the size of the file mapping object;
        /// if it does, not all of the file contents are available for sharing.
        /// If an application specifies a size for the file mapping object that is larger than the size of the actual named file on disk
        /// and if the page protection allows write access (that is, the <paramref name="flProtect"/> parameter specifies <see cref="PAGE_READWRITE"/> 
        /// or <see cref="PAGE_EXECUTE_READWRITE"/>), then the file on disk is increased to match the specified size of the file mapping object.
        /// If the file is extended, the contents of the file between the old end of the file and the new end of the file are not guaranteed to be zero;
        /// the behavior is defined by the file system.
        /// If the file on disk cannot be increased, <see cref="CreateFileMapping"/> fails
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_DISK_FULL"/>.
        /// The initial contents of the pages in a file mapping object backed by the operating system paging file are 0 (zero).
        /// The handle that <see cref="CreateFileMapping"/> returns has full access to a new file mapping object,
        /// and can be used with any function that requires a handle to a file mapping object.
        /// Multiple processes can share a view of the same file by either using a single shared file mapping object
        /// or creating separate file mapping objects backed by the same file.
        /// A single file mapping object can be shared by multiple processes through inheriting the handle at process creation,
        /// duplicating the handle, or opening the file mapping object by name.
        /// For more information, see the <see cref="CreateProcess"/>, <see cref="DuplicateHandle"/> and <see cref="OpenFileMapping"/> functions.
        /// Creating a file mapping object does not actually map the view into a process address space.
        /// The <see cref="MapViewOfFile"/> and <see cref="MapViewOfFileEx"/> functions map a view of a file into a process address space.
        /// With one important exception, file views derived from any file mapping object that is backed by the same file are coherent
        /// or identical at a specific time.
        /// Coherency is guaranteed for views within a process and for views that are mapped by different processes.
        /// The exception is related to remote files.
        /// Although <see cref="CreateFileMapping"/> works with remote files, it does not keep them coherent.
        /// For example, if two computers both map a file as writable, and both change the same page, each computer only sees its own writes to the page.
        /// When the data gets updated on the disk, it is not merged.
        /// A mapped file and a file that is accessed by using the input and output (I/O) functions
        /// (<see cref="ReadFile"/> and <see cref="WriteFile"/>) are not necessarily coherent.
        /// Mapped views of a file mapping object maintain internal references to the object,
        /// and a file mapping object does not close until all references to it are released.
        /// Therefore, to fully close a file mapping object, an application must unmap all mapped views of the file mapping object
        /// by calling <see cref="UnmapViewOfFile"/> and close the file mapping object handle by calling <see cref="CloseHandle"/>.
        /// These functions can be called in any order.
        /// When modifying a file through a mapped view, the last modification timestamp may not be updated automatically.
        /// If required, the caller should use <see cref="SetFileTime"/> to set the timestamp.
        /// Creating a file mapping object in the global namespace from a session other than session zero
        /// requires the SeCreateGlobalPrivilege privilege.
        /// Note that this privilege check is limited to the creation of file mapping objects and does not apply to opening existing ones.
        /// For example, if a service or the system creates a file mapping object in the global namespace, any process running
        /// in any session can access that file mapping object provided that the caller has the required access rights.
        /// Windows XP:  The requirement described in the previous paragraph was introduced with Windows Server 2003 and Windows XP with SP2
        /// Use structured exception handling to protect any code that writes to or reads from a file view.
        /// For more information, see Reading and Writing From a File View.
        /// To have a mapping with executable permissions, an application must call <see cref="CreateFileMapping"/> with
        /// either <see cref="PAGE_EXECUTE_READWRITE"/> or <see cref="PAGE_EXECUTE_READ"/>,
        /// and then call <see cref="MapViewOfFile"/> with <see cref="FILE_MAP_EXECUTE"/> | <see cref="FILE_MAP_WRITE"/>
        /// or <see cref="FILE_MAP_EXECUTE"/> | <see cref="FILE_MAP_READ"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateFileMappingW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE CreateFileMapping([In] HANDLE hFile, [In] in SECURITY_ATTRIBUTES lpFileMappingAttributes, [In] DWORD flProtect,
            [In] DWORD dwMaximumSizeHigh, [In] DWORD dwMaximumSizeLow, [In] LPWSTR lpName);

        /// <summary>
        /// <para>
        /// Creates or opens a named or unnamed file mapping object for a specified file and specifies the NUMA node for the physical memory.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-createfilemappingnumaw"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the file from which to create a file mapping object.
        /// The file must be opened with access rights that are compatible with the protection flags
        /// that the <paramref name="flProtect"/> parameter specifies.
        /// It is not required, but it is recommended that files you intend to map be opened for exclusive access.
        /// For more information, see File Security and Access Rights.
        /// If hFile is <see cref="INVALID_HANDLE_VALUE"/>, the calling process must also specify a size for the file mapping object
        /// in the <paramref name="dwMaximumSizeHigh"/> and <paramref name="dwMaximumSizeLow"/> parameters.
        /// In this scenario, <see cref="CreateFileMapping"/> creates a file mapping object of a specified size
        /// that is backed by the system paging file instead of by a file in the file system.
        /// </param>
        /// <param name="lpFileMappingAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that determines whether a returned handle can be inherited by child processes.
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the <see cref="SECURITY_ATTRIBUTES"/> structure
        /// specifies a security descriptor for a new file mapping object.
        /// If <paramref name="lpFileMappingAttributes"/> is <see langword="null"/>, the handle cannot be inherited
        /// and the file mapping object gets a default security descriptor.
        /// The access control lists (ACL) in the default security descriptor for a file mapping object come from the primary
        /// or impersonation token of the creator.
        /// For more information, see File Mapping Security and Access Rights.
        /// </param>
        /// <param name="flProtect">
        /// Specifies the page protection of the file mapping object.
        /// All mapped views of the object must be compatible with this protection.
        /// This parameter can be one of the following values.
        /// <see cref="PAGE_EXECUTE_READ"/> :
        /// Allows views to be mapped for read-only, copy-on-write, or execute access.
        /// The file handle specified by the <paramref name="hFile"/> parameter must be created
        /// with the <see cref="GENERIC_READ"/> and <see cref="GENERIC_WRITE"/> access rights.
        /// Windows Server 2003 and Windows XP:  This value is not available until Windows XP with SP2 and Windows Server 2003 with SP1.
        /// <see cref="PAGE_EXECUTE_READWRITE"/>:
        /// Allows views to be mapped for read-only, copy-on-write, read/write, or execute access.
        /// The file handle that the <paramref name="hFile"/> parameter specifies must be created
        /// with the <see cref="GENERIC_READ"/>, <see cref="GENERIC_WRITE"/>,
        /// and <see cref="GENERIC_EXECUTE"/> access rights.
        /// Windows Server 2003 and Windows XP:  This value is not available until Windows XP with SP2 and Windows Server 2003 with SP1.
        /// <see cref="PAGE_EXECUTE_WRITECOPY"/>:
        /// Allows views to be mapped for read-only, copy-on-write, or execute access.
        /// This value is equivalent to <see cref="PAGE_EXECUTE_READ"/>.
        /// The file handle specified by the <paramref name="hFile"/> parameter must be created
        /// with the <see cref="GENERIC_READ"/> and <see cref="GENERIC_WRITE"/> access rights.
        /// Windows Vista:  This value is not available until Windows Vista with SP1.
        /// Windows Server 2003 and Windows XP:  This value is not supported.
        /// <see cref="PAGE_READONLY"/>:
        /// Allows views to be mapped for read-only or copy-on-write access.
        /// An attempt to write to a specific region results in an access violation.
        /// The file handle that the <paramref name="hFile"/> parameter specifies must be created
        /// with the <see cref="GENERIC_READ"/> access right.
        /// <see cref="PAGE_READWRITE"/>:
        /// Allows views to be mapped for read-only, copy-on-write, or read/write access.
        /// The file handle specified by the <paramref name="hFile"/> parameter must be created
        /// with the <see cref="GENERIC_READ"/> and <see cref="GENERIC_WRITE"/> access rights.
        /// <see cref="PAGE_WRITECOPY"/>:
        /// Allows views to be mapped for read-only or copy-on-write access.
        /// This value is equivalent to <see cref="PAGE_READONLY"/>.
        /// The file handle that the <paramref name="hFile"/> parameter specifies must be created
        /// with the <see cref="GENERIC_READ"/> access right.
        /// An application can specify one or more of the following attributes for the file mapping object by combining them
        /// with one of the preceding page protection values.
        /// <see cref="SEC_COMMIT"/>:
        /// If the file mapping object is backed by the operating system paging file 
        /// (the <paramref name="hFile"/> parameter is <see cref="INVALID_HANDLE_VALUE"/>),
        /// specifies that when a view of the file is mapped into a process address space,
        /// the entire range of pages is committed rather than reserved.
        /// The system must have enough committable pages to hold the entire mapping.
        /// Otherwise, <see cref="CreateFileMapping"/> fails.
        /// This attribute has no effect for file mapping objects that are backed by executable image files or data files 
        /// (the <paramref name="hFile"/> parameter is a handle to a file).
        /// <see cref="SEC_COMMIT"/> cannot be combined with <see cref="SEC_RESERVE"/>.
        /// <see cref="SEC_IMAGE"/>:
        /// Specifies that the file that the <paramref name="hFile"/> parameter specifies is an executable image file.
        /// The <see cref="SEC_IMAGE"/> attribute must be combined
        /// with a page protection value such as <see cref="PAGE_READONLY"/>.
        /// However, this page protection value has no effect on views of the executable image file.
        /// Page protection for views of an executable image file is determined by the executable file itself.
        /// No other attributes are valid with <see cref="SEC_IMAGE"/>.
        /// <see cref="SEC_IMAGE_NO_EXECUTE"/>:
        /// Specifies that the file that the hFile parameter specifies is an executable image file that will not be executed
        /// and the loaded image file will have no forced integrity checks run.
        /// Additionally, mapping a view of a file mapping object created with the <see cref="SEC_IMAGE_NO_EXECUTE"/> attribute
        /// will not invoke driver callbacks registered using the PsSetLoadImageNotifyRoutine kernel API.
        /// The <see cref="SEC_IMAGE_NO_EXECUTE"/> attribute must be combined
        /// with the <see cref="PAGE_READONLY"/> page protection value.
        /// No other attributes are valid with <see cref="SEC_IMAGE_NO_EXECUTE"/>.
        /// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// This value is not supported before Windows Server 2012 and Windows 8.
        /// <see cref="SEC_LARGE_PAGES"/>:
        /// Enables large pages to be used for file mapping objects that are backed by the operating system paging file
        /// (the <paramref name="hFile"/> parameter is <see cref="INVALID_HANDLE_VALUE"/>).
        /// This attribute is not supported for file mapping objects that are backed by executable image files or data files
        /// (the <paramref name="hFile"/> parameter is a handle to an executable image or data file).
        /// The maximum size of the file mapping object must be a multiple of the minimum size of a large page
        /// returned by the <see cref="GetLargePageMinimum"/> function.
        /// If it is not, <see cref="CreateFileMapping"/> fails.
        /// When mapping a view of a file mapping object created with <see cref="SEC_LARGE_PAGES"/>,
        /// the base address and view size must also be multiples of the minimum large page size.
        /// <see cref="SEC_LARGE_PAGES"/> requires the SeLockMemoryPrivilege privilege
        /// to be enabled in the caller's token.
        /// If <see cref="SEC_LARGE_PAGES"/> is specified, <see cref="SEC_COMMIT"/> must also be specified.
        /// Windows Server 2003:  This value is not supported until Windows Server 2003 with SP1.
        /// Windows XP:  This value is not supported.
        /// <see cref="SEC_NOCACHE"/>:
        /// Sets all pages to be non-cachable.
        /// Applications should not use this attribute except when explicitly required for a device.
        /// Using the interlocked functions with memory that is mapped with <see cref="SEC_NOCACHE"/>
        /// can result in an EXCEPTION_ILLEGAL_INSTRUCTION exception.
        /// <see cref="SEC_NOCACHE"/> requires either
        /// the <see cref="SEC_RESERVE"/> or <see cref="SEC_COMMIT"/> attribute to be set.
        /// <see cref="SEC_RESERVE"/>:
        /// If the file mapping object is backed by the operating system paging file
        /// (the <paramref name="hFile"/> parameter is <see cref="Constants.INVALID_HANDLE_VALUE"/>),
        /// specifies that when a view of the file is mapped into a process address space,
        /// the entire range of pages is reserved for later use by the process rather than committed.
        /// Reserved pages can be committed in subsequent calls to the <see cref="VirtualAlloc"/> function.
        /// After the pages are committed, they cannot be freed or decommitted with the <see cref="VirtualFree"/> function.
        /// This attribute has no effect for file mapping objects that are backed by executable image files or data files
        /// (the <paramref name="hFile"/> parameter is a handle to a file).
        /// <see cref="SEC_RESERVE"/> cannot be combined with <see cref="SEC_COMMIT"/>.
        /// <see cref="SEC_WRITECOMBINE"/>:
        /// Sets all pages to be write-combined.
        /// Applications should not use this attribute except when explicitly required for a device.
        /// Using the interlocked functions with memory that is mapped with <see cref="SEC_WRITECOMBINE"/>
        /// can result in an EXCEPTION_ILLEGAL_INSTRUCTION exception.
        /// <see cref="SEC_WRITECOMBINE"/> requires either
        /// the <see cref="SEC_RESERVE"/> or <see cref="SEC_COMMIT"/> attribute to be set.
        /// Windows Server 2003 and Windows XP:  This flag is not supported until Windows Vista.
        /// </param>
        /// <param name="dwMaximumSizeHigh">
        /// The high-order DWORD of the maximum size of the file mapping object.
        /// </param>
        /// <param name="dwMaximumSizeLow">
        /// The low-order DWORD of the maximum size of the file mapping object.
        /// If this parameter and <paramref name="dwMaximumSizeHigh"/> are 0 (zero),
        /// the maximum size of the file mapping object is equal to the current size of the file that <paramref name="hFile"/> identifies.
        /// An attempt to map a file with a length of 0 (zero) fails with an error code of <see cref="ERROR_FILE_INVALID"/>.
        /// Applications should test for files with a length of 0 (zero) and reject those files.
        /// </param>
        /// <param name="lpName">
        /// The name of the file mapping object.
        /// If this parameter matches the name of an existing mapping object,
        /// the function requests access to the object with the protection that <paramref name="flProtect"/> specifies.
        /// If this parameter is <see langword="null"/>, the file mapping object is created without a name.
        /// If <paramref name="lpName"/> matches the name of an existing event, semaphore, mutex, waitable timer, or job object,
        /// the function fails, and the <see cref="GetLastError"/> function returns <see cref="ERROR_INVALID_HANDLE"/>.
        /// This occurs because these objects share the same namespace.
        /// The name can have a "Global" or "Local" prefix to explicitly create the object in the global or session namespace.
        /// The remainder of the name can contain any character except the backslash character ().
        /// Creating a file mapping object in the global namespace from a session other than session zero
        /// requires the SeCreateGlobalPrivilege privilege.
        /// For more information, see Kernel Object Namespaces.
        /// Fast user switching is implemented by using Terminal Services sessions.
        /// The first user to log on uses session 0 (zero), the next user to log on uses session 1 (one), and so on.
        /// Kernel object names must follow the guidelines that are outlined for Terminal Services so that applications can support multiple users.
        /// </param>
        /// <param name="nndPreferred">
        /// The NUMA node where the physical memory should reside.
        /// <see cref="NUMA_NO_PREFERRED_NODE"/>:
        /// No NUMA node is preferred.
        /// This is the same as calling the <see cref="CreateFileMapping"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the newly created file mapping object.
        /// If the object exists before the function call, the function returns a handle to the existing object (with its current size,
        /// not the specified size), and <see cref="GetLastError"/> returns <see cref="ERROR_ALREADY_EXISTS"/>.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// After a file mapping object is created, the size of the file must not exceed the size of the file mapping object;
        /// if it does, not all of the file contents are available for sharing.
        /// The file mapping object can be shared by duplication, inheritance, or by name.
        /// The initial contents of the pages in a file mapping object backed by the page file are 0 (zero).
        /// If an application specifies a size for the file mapping object that is larger than the size of the actual named file on disk
        /// and if the page protection allows write access (that is, the <paramref name="flProtect"/> parameter specifies
        /// <see cref="PAGE_READWRITE"/> or <see cref="PAGE_EXECUTE_READWRITE"/>),
        /// then the file on disk is increased to match the specified size of the file mapping object.
        /// If the file is extended, the contents of the file between the old end of the file and the new end of the file are not guaranteed to be zero;
        /// the behavior is defined by the file system.
        /// If the file on disk cannot be increased, <see cref="CreateFileMapping"/> fails
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_DISK_FULL"/>.
        /// The handle that the <see cref="CreateFileMappingNuma"/> function returns has full access to a new file mapping object
        /// and can be used with any function that requires a handle to a file mapping object.
        /// A file mapping object can be shared through process creation, handle duplication, or by name.
        /// For more information, see the <see cref="DuplicateHandle"/> and <see cref="OpenFileMapping"/> functions.
        /// Creating a file mapping object creates the potential for mapping a view of the file but does not map the view.
        /// The <see cref="MapViewOfFileExNuma"/> function maps a view of a file into a process address space.
        /// With one important exception, file views derived from a single file mapping object are coherent or identical at a specific time.
        /// If multiple processes have handles of the same file mapping object, they see a coherent view of the data when they map a view of the file.
        /// The exception is related to remote files.
        /// Although <see cref="CreateFileMappingNuma"/> works with remote files, it does not keep them coherent.
        /// For example, if two computers both map a file as writable, and both change the same page, each computer only sees its own writes to the page.
        /// When the data gets updated on the disk, the page is not merged.
        /// A mapped file and a file that is accessed by using the input and output (I/O) functions
        /// (<see cref="ReadFile"/> and <see cref="WriteFile"/>) are not necessarily coherent.
        /// To fully close a file mapping object, an application must unmap all mapped views of the file mapping object
        /// by calling <see cref="UnmapViewOfFile"/> and close the file mapping object handle by calling <see cref="CloseHandle"/>.
        /// These functions can be called in any order.
        /// The call to the <see cref="UnmapViewOfFile"/> function is necessary,
        /// because mapped views of a file mapping object maintain internal open handles to the object,
        /// and a file mapping object does not close until all open handles to it are closed.
        /// When modifying a file through a mapped view, the last modification timestamp may not be updated automatically.
        /// If required, the caller should use <see cref="SetFileTime"/> to set the timestamp.
        /// Creating a file mapping object in the global namespace from a session other than session zero
        /// requires the SeCreateGlobalPrivilege privilege.
        /// Note that this privilege check is limited to the creation of file mapping objects and does not apply to opening existing ones.
        /// For example, if a service or the system creates a file mapping object in the global namespace, any process running
        /// in any session can access that file mapping object provided that the caller has the required access rights.
        /// Use structured exception handling to protect any code that writes to or reads from a file view.
        /// For more information, see Reading and Writing From a File View.
        /// To have a mapping with executable permissions, an application must call <see cref="CreateFileMappingNuma"/> with
        /// either <see cref="PAGE_EXECUTE_READWRITE"/> or <see cref="PAGE_EXECUTE_READ"/>,
        /// and then call <see cref="MapViewOfFile"/> with <see cref="FILE_MAP_EXECUTE"/> | <see cref="FILE_MAP_WRITE"/>
        /// or <see cref="FILE_MAP_EXECUTE"/> | <see cref="FILE_MAP_READ"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateFileMappingNumaW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE CreateFileMappingNuma([In] HANDLE hFile, [In] in SECURITY_ATTRIBUTES lpFileMappingAttributes, [In] DWORD flProtect,
            [In] DWORD dwMaximumSizeHigh, [In] DWORD dwMaximumSizeLow, [MarshalAs(UnmanagedType.LPWStr)][In] string lpName, [In] DWORD nndPreferred);

        /// <summary>
        /// <para>
        /// Writes to the disk a byte range within a mapped view of a file.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-flushviewoffile"/>
        /// </para>
        /// </summary>
        /// <param name="lpBaseAddress">
        /// A pointer to the base address of the byte range to be flushed to the disk representation of the mapped file.
        /// </param>
        /// <param name="dwNumberOfBytesToFlush">
        /// The number of bytes to be flushed.
        /// If <paramref name="dwNumberOfBytesToFlush"/> is zero, the file is flushed from the base address to the end of the mapping.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Flushing a range of a mapped view initiates writing of dirty pages within that range to the disk.
        /// Dirty pages are those whose contents have changed since the file view was mapped.
        /// The <see cref="FlushViewOfFile"/> function does not flush the file metadata,
        /// and it does not wait to return until the changes are flushed from the underlying hardware disk cache and physically written to disk.
        /// To flush all the dirty pages plus the metadata for the file and ensure that they are physically written to disk,
        /// call <see cref="FlushViewOfFile"/> and then call the <see cref="FlushFileBuffers"/> function.
        /// When flushing a memory-mapped file over a network, <see cref="FlushViewOfFile"/> guarantees that the data has been written
        /// from the local computer, but not that the data resides on the remote computer.
        /// The server can cache the data on the remote side.
        /// Therefore, <see cref="FlushViewOfFile"/> can return before the data has been physically written to disk.
        /// When modifying a file through a mapped view, the last modification timestamp may not be updated automatically.
        /// If required, the caller should use <see cref="SetFileTime"/> to set the timestamp.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FlushViewOfFile", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL FlushViewOfFile([In] LPCVOID lpBaseAddress, [In] SIZE_T dwNumberOfBytesToFlush);

        /// <summary>
        /// <para>
        /// Maps a view of a file mapping into the address space of a calling process.
        /// To specify a suggested base address for the view, use the <see cref="MapViewOfFileEx"/> function.
        /// However, this practice is not recommended.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-mapviewoffile"/>
        /// </para>
        /// </summary>
        /// <param name="hFileMappingObject">
        /// A handle to a file mapping object.
        /// The <see cref="CreateFileMapping"/> and <see cref="OpenFileMapping"/> functions return this handle.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// The type of access to a file mapping object, which determines the page protection of the pages.
        /// This parameter can be one of the following values, or a bitwise OR combination of multiple values where appropriate.
        /// <see cref="FILE_MAP_ALL_ACCESS"/>:
        /// A read/write view of the file is mapped.
        /// The file mapping object must have been created with <see cref="PAGE_READWRITE"/> or <see cref="PAGE_EXECUTE_READWRITE"/> protection.
        /// When used with the <see cref="MapViewOfFile"/> function, <see cref="FILE_MAP_ALL_ACCESS"/> is equivalent to <see cref="FILE_MAP_WRITE"/>.
        /// <see cref="FILE_MAP_READ"/>:
        /// A read-only view of the file is mapped. An attempt to write to the file view results in an access violation.
        /// The file mapping object must have been created with <see cref="PAGE_READONLY"/>, <see cref="PAGE_READWRITE"/>,
        /// <see cref="PAGE_EXECUTE_READ"/>, or <see cref="PAGE_EXECUTE_READWRITE"/> protection.
        /// <see cref="FILE_MAP_WRITE"/>:
        /// A read/write view of the file is mapped.
        /// The file mapping object must have been created with <see cref="PAGE_READWRITE"/> or <see cref="PAGE_EXECUTE_READWRITE"/> protection.
        /// When used with <see cref="MapViewOfFile"/>, <code>(FILE_MAP_WRITE | FILE_MAP_READ)</code> and <see cref="FILE_MAP_ALL_ACCESS"/>
        /// are equivalent to <see cref="FILE_MAP_WRITE"/>.
        /// Using bitwise OR, you can combine the values above with these values.
        /// <see cref="FILE_MAP_COPY"/>:
        /// A copy-on-write view of the file is mapped.
        /// The file mapping object must have been created with <see cref="PAGE_READONLY"/>, <see cref="PAGE_EXECUTE_READ"/>, <see cref="PAGE_WRITECOPY"/>,
        /// <see cref="PAGE_EXECUTE_WRITECOPY"/>, <see cref="PAGE_READWRITE"/>, or <see cref="PAGE_EXECUTE_READWRITE"/> protection.
        /// When a process writes to a copy-on-write page, the system copies the original page to a new page that is private to the process.
        /// The new page is backed by the paging file. The protection of the new page changes from copy-on-write to read/write.
        /// When copy-on-write access is specified, the system and process commit charge taken is for the entire view
        /// because the calling process can potentially write to every page in the view, making all pages private.
        /// The contents of the new page are never written back to the original file and are lost when the view is unmapped.
        /// <see cref="FILE_MAP_EXECUTE"/>:
        /// An executable view of the file is mapped (mapped memory can be run as code).
        /// The file mapping object must have been created with <see cref="PAGE_EXECUTE_READ"/>,
        /// <see cref="PAGE_EXECUTE_WRITECOPY"/>, or <see cref="PAGE_EXECUTE_READWRITE"/> protection.
        /// Windows Server 2003 and Windows XP: This value is available starting with Windows XP with SP2 and Windows Server 2003 with SP1.
        /// <see cref="FILE_MAP_LARGE_PAGES"/>:
        /// Starting with Windows 10, version 1703, this flag specifies that the view should be mapped using large page support.
        /// The size of the view must be a multiple of the size of a large page reported by the <see cref="GetLargePageMinimum"/> function,
        /// and the file-mapping object must have been created using the <see cref="SEC_LARGE_PAGES"/> option.
        /// If you provide a non-null value for lpBaseAddress, then the value must be a multiple of <see cref="GetLargePageMinimum"/>.
        /// Note: On OS versions before Windows 10, version 1703, the <see cref="FILE_MAP_LARGE_PAGES"/> flag has no effect.
        /// On these releases, the view is automatically mapped using large pages if the section was created with the <see cref="SEC_LARGE_PAGES"/> flag set.
        /// <see cref="FILE_MAP_TARGETS_INVALID"/>:
        /// Sets all the locations in the mapped file as invalid targets for Control Flow Guard (CFG).
        /// This flag is similar to <see cref="PAGE_TARGETS_INVALID"/>.
        /// Use this flag in combination with the execute access right <see cref="FILE_MAP_EXECUTE"/>.
        /// Any indirect call to locations in those pages will fail CFG checks, and the process will be terminated.
        /// The default behavior for executable pages allocated is to be marked valid call targets for CFG.
        /// For file mapping objects created with the <see cref="SEC_IMAGE"/> attribute, the <paramref name="dwDesiredAccess"/> parameter has no effect,
        /// and should be set to any valid value such as <see cref="FILE_MAP_READ"/>.
        /// For more information about access to file mapping objects, see File Mapping Security and Access Rights.
        /// </param>
        /// <param name="dwFileOffsetHigh">
        /// A high-order <see cref="DWORD"/> of the file offset where the view begins.
        /// </param>
        /// <param name="dwFileOffsetLow">
        /// A low-order <see cref="DWORD"/> of the file offset where the view is to begin.
        /// The combination of the high and low offsets must specify an offset within the file mapping.
        /// They must also match the memory allocation granularity of the system.
        /// That is, the offset must be a multiple of the allocation granularity.
        /// To obtain the memory allocation granularity of the system, use the <see cref="GetSystemInfo"/> function,
        /// which fills in the members of a <see cref="SYSTEM_INFO"/> structure.
        /// </param>
        /// <param name="dwNumberOfBytesToMap">
        /// The number of bytes of a file mapping to map to the view.
        /// All bytes must be within the maximum size specified by <see cref="CreateFileMapping"/>.
        /// If this parameter is 0 (zero), the mapping extends from the specified offset to the end of the file mapping.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the starting address of the mapped view.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Mapping a file makes the specified portion of a file visible in the address space of the calling process.
        /// For files that are larger than the address space, you can only map a small portion of the file data at one time.
        /// When the first view is complete, you can unmap it and map a new view.
        /// To obtain the size of a view, use the <see cref="VirtualQuery"/> function.
        /// Multiple views of a file (or a file mapping object and its mapped file) are coherent if they contain identical data at a specified time.
        /// This occurs if the file views are derived from any file mapping object that is backed by the same file.
        /// A process can duplicate a file mapping object handle into another process by using the <see cref="DuplicateHandle"/> function,
        /// or another process can open a file mapping object by name by using the <see cref="OpenFileMapping"/> function.
        /// With one important exception, file views derived from any file mapping object that is backed by the same file are coherent
        /// or identical at a specific time.
        /// Coherency is guaranteed for views within a process and for views that are mapped by different processes.
        /// The exception is related to remote files.
        /// Although <see cref="MapViewOfFile"/> works with remote files, it does not keep them coherent.
        /// For example, if two computers both map a file as writable, and both change the same page, each computer only sees its own writes to the page.
        /// When the data gets updated on the disk, it is not merged.
        /// A mapped view of a file is not guaranteed to be coherent with a file
        /// that is being accessed by the <see cref="ReadFile"/> or <see cref="WriteFile"/> function.
        /// Do not store pointers in the memory mapped file; store offsets from the base of the file mapping so that the mapping can be used at any address.
        /// To guard against <see cref="EXCEPTION_IN_PAGE_ERROR"/> exceptions, use structured exception handling 
        /// to protect any code that writes to or reads from a memory mapped view of a file other than the page file.
        /// For more information, see Reading and Writing From a File View.
        /// When modifying a file through a mapped view, the last modification timestamp may not be updated automatically.
        /// If required, the caller should use <see cref="SetFileTime"/> to set the timestamp.
        /// If a file mapping object is backed by the paging file (<see cref="CreateFileMapping"/> is called with the hFile parameter
        /// set to <see cref="INVALID_HANDLE_VALUE"/>), the paging file must be large enough to hold the entire mapping.
        /// If it is not, <see cref="MapViewOfFile"/> fails.
        /// The initial contents of the pages in a file mapping object backed by the paging file are 0 (zero).
        /// When a file mapping object that is backed by the paging file is created, the caller can specify whether <see cref="MapViewOfFile"/> should
        /// reserve and commit pages at the same time (<see cref="SEC_COMMIT"/>) or simply reserve pages (<see cref="SEC_RESERVE"/>).
        /// Mapping the file makes the entire mapped virtual address range unavailable to other allocations in the process.
        /// After a page from the reserved range is committed, it cannot be freed or decommitted by calling <see cref="VirtualFree"/>.
        /// Reserved and committed pages are released when the view is unmapped and the file mapping object is closed.
        /// For details, see the <see cref="UnmapViewOfFile"/> and <see cref="CloseHandle"/> functions.
        /// To have a file with executable permissions, an application must call <see cref="CreateFileMapping"/>
        /// with either <see cref="PAGE_EXECUTE_READWRITE"/> or <see cref="PAGE_EXECUTE_READ"/>,
        /// and then call <see cref="MapViewOfFile"/> with <code>FILE_MAP_EXECUTE | FILE_MAP_WRITE or FILE_MAP_EXECUTE | FILE_MAP_READ</code>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "MapViewOfFile", ExactSpelling = true, SetLastError = true)]
        public static extern LPVOID MapViewOfFile([In] HANDLE hFileMappingObject, [In] ACCESS_MASK dwDesiredAccess, [In] DWORD dwFileOffsetHigh,
            [In] DWORD dwFileOffsetLow, [In] SIZE_T dwNumberOfBytesToMap);

        /// <summary>
        /// <para>
        /// Maps a view of a file mapping into the address space of a calling process.
        /// A caller can optionally specify a suggested base memory address for the view.
        /// To specify the NUMA node for the physical memory, see <see cref="MapViewOfFileExNuma"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-mapviewoffileex"/>
        /// </para>
        /// </summary>
        /// <param name="hFileMappingObject">
        /// A handle to a file mapping object.
        /// The <see cref="CreateFileMapping"/> and <see cref="OpenFileMapping"/> functions return this handle.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// The type of access to a file mapping object, which determines the page protection of the pages.
        /// This parameter can be one of the following values, or a bitwise OR combination of multiple values where appropriate.
        /// <see cref="FILE_MAP_ALL_ACCESS"/>:
        /// A read/write view of the file is mapped.
        /// The file mapping object must have been created with <see cref="PAGE_READWRITE"/> or <see cref="PAGE_EXECUTE_READWRITE"/> protection.
        /// When used with the <see cref="MapViewOfFileEx"/> function, <see cref="FILE_MAP_ALL_ACCESS"/> is equivalent to <see cref="FILE_MAP_WRITE"/>.
        /// <see cref="FILE_MAP_READ"/>:
        /// A read-only view of the file is mapped. An attempt to write to the file view results in an access violation.
        /// The file mapping object must have been created with <see cref="PAGE_READONLY"/>, <see cref="PAGE_READWRITE"/>,
        /// <see cref="PAGE_EXECUTE_READ"/>, or <see cref="PAGE_EXECUTE_READWRITE"/> protection.
        /// <see cref="FILE_MAP_WRITE"/>:
        /// A read/write view of the file is mapped.
        /// The file mapping object must have been created with <see cref="PAGE_READWRITE"/> or <see cref="PAGE_EXECUTE_READWRITE"/> protection.
        /// When used with <see cref="MapViewOfFileEx"/>, <code>(FILE_MAP_WRITE | FILE_MAP_READ)</code> and <see cref="FILE_MAP_ALL_ACCESS"/>
        /// are equivalent to <see cref="FILE_MAP_WRITE"/>.
        /// Using bitwise OR, you can combine the values above with these values.
        /// <see cref="FILE_MAP_COPY"/>:
        /// A copy-on-write view of the file is mapped.
        /// The file mapping object must have been created with <see cref="PAGE_READONLY"/>, <see cref="PAGE_EXECUTE_READ"/>, <see cref="PAGE_WRITECOPY"/>,
        /// <see cref="PAGE_EXECUTE_WRITECOPY"/>, <see cref="PAGE_READWRITE"/>, or <see cref="PAGE_EXECUTE_READWRITE"/> protection.
        /// When a process writes to a copy-on-write page, the system copies the original page to a new page that is private to the process.
        /// The new page is backed by the paging file. The protection of the new page changes from copy-on-write to read/write.
        /// When copy-on-write access is specified, the system and process commit charge taken is for the entire view
        /// because the calling process can potentially write to every page in the view, making all pages private.
        /// The contents of the new page are never written back to the original file and are lost when the view is unmapped.
        /// <see cref="FILE_MAP_LARGE_PAGES"/>:
        /// Starting with Windows 10, version 1703, this flag specifies that the view should be mapped using large page support.
        /// The size of the view must be a multiple of the size of a large page reported by the <see cref="GetLargePageMinimum"/> function,
        /// and the file-mapping object must have been created using the <see cref="SEC_LARGE_PAGES"/> option.
        /// If you provide a non-null value for <paramref name="lpBaseAddress"/>, then the value must be a multiple of <see cref="GetLargePageMinimum"/>.
        /// <see cref="FILE_MAP_EXECUTE"/>:
        /// An executable view of the file is mapped (mapped memory can be run as code).
        /// The file mapping object must have been created with <see cref="PAGE_EXECUTE_READ"/>,
        /// <see cref="PAGE_EXECUTE_WRITECOPY"/>, or <see cref="PAGE_EXECUTE_READWRITE"/> protection.
        /// Windows Server 2003 and Windows XP: This value is available starting with Windows XP with SP2 and Windows Server 2003 with SP1.
        /// <see cref="FILE_MAP_TARGETS_INVALID"/>:
        /// Sets all the locations in the mapped file as invalid targets for Control Flow Guard (CFG).
        /// This flag is similar to <see cref="PAGE_TARGETS_INVALID"/>.
        /// Use this flag in combination with the execute access right <see cref="FILE_MAP_EXECUTE"/>.
        /// Any indirect call to locations in those pages will fail CFG checks, and the process will be terminated.
        /// The default behavior for executable pages allocated is to be marked valid call targets for CFG.
        /// For file mapping objects created with the <see cref="SEC_IMAGE"/> attribute, the <paramref name="dwDesiredAccess"/> parameter has no effect,
        /// and should be set to any valid value such as <see cref="FILE_MAP_READ"/>.
        /// For more information about access to file mapping objects, see File Mapping Security and Access Rights.
        /// </param>
        /// <param name="dwFileOffsetHigh">
        /// A high-order <see cref="DWORD"/> of the file offset where the view begins.
        /// </param>
        /// <param name="dwFileOffsetLow">
        /// A low-order <see cref="DWORD"/> of the file offset where the view is to begin.
        /// The combination of the high and low offsets must specify an offset within the file mapping.
        /// They must also match the memory allocation granularity of the system.
        /// That is, the offset must be a multiple of the allocation granularity.
        /// To obtain the memory allocation granularity of the system, use the <see cref="GetSystemInfo"/> function,
        /// which fills in the members of a <see cref="SYSTEM_INFO"/> structure.
        /// </param>
        /// <param name="dwNumberOfBytesToMap">
        /// The number of bytes of a file mapping to map to the view.
        /// All bytes must be within the maximum size specified by <see cref="CreateFileMapping"/>.
        /// If this parameter is 0 (zero), the mapping extends from the specified offset to the end of the file mapping.
        /// </param>
        /// <param name="lpBaseAddress">
        /// A pointer to the memory address in the calling process address space where mapping begins.
        /// This must be a multiple of the system's memory allocation granularity, or the function fails.
        /// To determine the memory allocation granularity of the system, use the <see cref="GetSystemInfo"/> function.
        /// If there is not enough address space at the specified address, the function fails.
        /// If <paramref name="lpBaseAddress"/> is <see cref="NULL"/>, the operating system chooses the mapping address.
        /// In this scenario, the function is equivalent to the <see cref="MapViewOfFile"/> function.
        /// While it is possible to specify an address that is safe now (not used by the operating system),
        /// there is no guarantee that the address will remain safe over time.
        /// Therefore, it is better to let the operating system choose the address.
        /// In this case, you would not store pointers in the memory mapped file,
        /// you would store offsets from the base of the file mapping so that the mapping can be used at any address.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the starting address of the mapped view.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Mapping a file makes the specified portion of the file visible in the address space of the calling process.
        /// For files that are larger than the address space, you can only map a small portion of the file data at one time.
        /// When the first view is complete, then you unmap it and map a new view.
        /// To obtain the size of a view, use the <see cref="VirtualQueryEx"/> function.
        /// The initial contents of the pages in a file mapping object backed by the page file are 0 (zero).
        /// Typically, the suggested address is used to specify that a file should be mapped at the same address in multiple processes.
        /// This requires the region of address space to be available in all involved processes.
        /// No other memory allocation can take place in the region that is used for mapping,
        /// including the use of the <see cref="VirtualAlloc"/> or <see cref="VirtualAllocEx"/> function to reserve memory.
        /// If the <paramref name="lpBaseAddress"/> parameter specifies a base offset,
        /// the function succeeds if the specified memory region is not already in use by the calling process.
        /// The system does not ensure that the same memory region is available for the memory mapped file in other 32-bit processes.
        /// Multiple views of a file (or a file mapping object and its mapped file) are coherent if they contain identical data at a specified time.
        /// This occurs if the file views are derived from the same file mapping object.
        /// A process can duplicate a file mapping object handle into another process by using the <see cref="DuplicateHandle"/> function,
        /// or another process can open a file mapping object by name by using the <see cref="OpenFileMapping"/> function.
        /// With one important exception, file views derived from any file mapping object
        /// that is backed by the same file are coherent or identicalat a specific time.
        /// Coherency is guaranteed for views within a process and for views that are mapped by different processes.
        /// The exception is related to remote files. Although <see cref="MapViewOfFileEx"/> works with remote files, it does not keep them coherent.
        /// For example, if two computers both map a file as writable, and both change the same page, each computer only sees its own writes to the page.
        /// When the data gets updated on the disk, it is not merged.
        /// A mapped view of a file is not guaranteed to be coherent with a file
        /// being accessed by the <see cref="ReadFile"/> or <see cref="WriteFile"/> function.
        /// To guard against <see cref="EXCEPTION_IN_PAGE_ERROR"/> exceptions,
        /// use structured exception handling to protect any code that writes to or reads from a memory mapped view of a file other than the page file.
        /// For more information, see Reading and Writing From a File View.
        /// When modifying a file through a mapped view, the last modification timestamp may not be updated automatically.
        /// If required, the caller should use <see cref="SetFileTime"/> to set the timestamp.
        /// To have a file with executable permissions, an application must call <see cref="CreateFileMapping"/>
        /// with either <see cref="PAGE_EXECUTE_READWRITE"/> or <see cref="PAGE_EXECUTE_READ"/>,
        /// and then call <see cref="MapViewOfFileEx"/> with <code>FILE_MAP_EXECUTE | FILE_MAP_WRITE or FILE_MAP_EXECUTE | FILE_MAP_READ</code>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "MapViewOfFileEx", ExactSpelling = true, SetLastError = true)]
        public static extern LPVOID MapViewOfFileEx([In] HANDLE hFileMappingObject, [In] ACCESS_MASK dwDesiredAccess, [In] DWORD dwFileOffsetHigh,
            [In] DWORD dwFileOffsetLow, [In] SIZE_T dwNumberOfBytesToMap, [In] LPVOID lpBaseAddress);

        /// <summary>
        /// <para>
        /// Maps a view of a file mapping into the address space of a calling process and specifies the NUMA node for the physical memory.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-mapviewoffileexnuma"/>
        /// </para>
        /// </summary>
        /// <param name="hFileMappingObject">
        /// A handle to a file mapping object.
        /// The <see cref="CreateFileMappingNuma"/> and <see cref="OpenFileMapping"/> functions return this handle.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// The type of access to a file mapping object, which determines the page protection of the pages.
        /// This parameter can be one of the following values, or a bitwise OR combination of multiple values where appropriate.
        /// <see cref="FILE_MAP_ALL_ACCESS"/>:
        /// A read/write view of the file is mapped.
        /// The file mapping object must have been created with <see cref="PAGE_READWRITE"/> or <see cref="PAGE_EXECUTE_READWRITE"/> protection.
        /// When used with the <see cref="MapViewOfFileExNuma"/> function, <see cref="FILE_MAP_ALL_ACCESS"/> is equivalent to <see cref="FILE_MAP_WRITE"/>.
        /// <see cref="FILE_MAP_READ"/>:
        /// A read-only view of the file is mapped. An attempt to write to the file view results in an access violation.
        /// The file mapping object must have been created with <see cref="PAGE_READONLY"/>, <see cref="PAGE_READWRITE"/>,
        /// <see cref="PAGE_EXECUTE_READ"/>, or <see cref="PAGE_EXECUTE_READWRITE"/> protection.
        /// <see cref="FILE_MAP_WRITE"/>:
        /// A read/write view of the file is mapped.
        /// The file mapping object must have been created with <see cref="PAGE_READWRITE"/> or <see cref="PAGE_EXECUTE_READWRITE"/> protection.
        /// When used with <see cref="MapViewOfFileExNuma"/>, <code>(FILE_MAP_WRITE | FILE_MAP_READ)</code> and <see cref="FILE_MAP_ALL_ACCESS"/>
        /// are equivalent to <see cref="FILE_MAP_WRITE"/>.
        /// Using bitwise OR, you can combine the values above with these values.
        /// <see cref="FILE_MAP_COPY"/>:
        /// A copy-on-write view of the file is mapped.
        /// The file mapping object must have been created with <see cref="PAGE_READONLY"/>, <see cref="PAGE_EXECUTE_READ"/>, <see cref="PAGE_WRITECOPY"/>,
        /// <see cref="PAGE_EXECUTE_WRITECOPY"/>, <see cref="PAGE_READWRITE"/>, or <see cref="PAGE_EXECUTE_READWRITE"/> protection.
        /// When a process writes to a copy-on-write page, the system copies the original page to a new page that is private to the process.
        /// The new page is backed by the paging file. The protection of the new page changes from copy-on-write to read/write.
        /// When copy-on-write access is specified, the system and process commit charge taken is for the entire view
        /// because the calling process can potentially write to every page in the view, making all pages private.
        /// The contents of the new page are never written back to the original file and are lost when the view is unmapped.
        /// <see cref="FILE_MAP_EXECUTE"/>:
        /// An executable view of the file is mapped (mapped memory can be run as code).
        /// The file mapping object must have been created with <see cref="PAGE_EXECUTE_READ"/>,
        /// <see cref="PAGE_EXECUTE_WRITECOPY"/>, or <see cref="PAGE_EXECUTE_READWRITE"/> protection.
        /// <see cref="FILE_MAP_LARGE_PAGES"/>:
        /// Starting with Windows 10, version 1703, this flag specifies that the view should be mapped using large page support.
        /// The size of the view must be a multiple of the size of a large page reported by the <see cref="GetLargePageMinimum"/> function,
        /// and the file-mapping object must have been created using the <see cref="SEC_LARGE_PAGES"/> option.
        /// If you provide a non-null value for <paramref name="lpBaseAddress"/>, then the value must be a multiple of <see cref="GetLargePageMinimum"/>.
        /// <see cref="FILE_MAP_TARGETS_INVALID"/>:
        /// Sets all the locations in the mapped file as invalid targets for Control Flow Guard (CFG).
        /// This flag is similar to <see cref="PAGE_TARGETS_INVALID"/>.
        /// Use this flag in combination with the execute access right <see cref="FILE_MAP_EXECUTE"/>.
        /// Any indirect call to locations in those pages will fail CFG checks, and the process will be terminated.
        /// The default behavior for executable pages allocated is to be marked valid call targets for CFG. 
        /// For file mapping objects created with the <see cref="SEC_IMAGE"/> attribute, the <paramref name="dwDesiredAccess"/> parameter has no effect,
        /// and should be set to any valid value such as <see cref="FILE_MAP_READ"/>.
        /// For more information about access to file mapping objects, see File Mapping Security and Access Rights.
        /// </param>
        /// <param name="dwFileOffsetHigh">
        /// A high-order <see cref="DWORD"/> of the file offset where the view begins.
        /// </param>
        /// <param name="dwFileOffsetLow">
        /// A low-order <see cref="DWORD"/> of the file offset where the view is to begin.
        /// The combination of the high and low offsets must specify an offset within the file mapping.
        /// They must also match the memory allocation granularity of the system.
        /// That is, the offset must be a multiple of the allocation granularity.
        /// To obtain the memory allocation granularity of the system, use the <see cref="GetSystemInfo"/> function,
        /// which fills in the members of a <see cref="SYSTEM_INFO"/> structure.
        /// </param>
        /// <param name="dwNumberOfBytesToMap">
        /// The number of bytes of a file mapping to map to the view.
        /// All bytes must be within the maximum size specified by <see cref="CreateFileMapping"/>.
        /// If this parameter is 0 (zero), the mapping extends from the specified offset to the end of the file mapping.
        /// </param>
        /// <param name="lpBaseAddress">
        /// A pointer to the memory address in the calling process address space where mapping begins.
        /// This must be a multiple of the system's memory allocation granularity, or the function fails.
        /// To determine the memory allocation granularity of the system, use the <see cref="GetSystemInfo"/> function.
        /// If there is not enough address space at the specified address, the function fails.
        /// If <paramref name="lpBaseAddress"/> is <see cref="NULL"/>, the operating system chooses the mapping address.
        /// In this scenario, the function is equivalent to the <see cref="MapViewOfFile"/> function.
        /// While it is possible to specify an address that is safe now (not used by the operating system),
        /// there is no guarantee that the address will remain safe over time.
        /// Therefore, it is better to let the operating system choose the address.
        /// In this case, you would not store pointers in the memory mapped file,
        /// you would store offsets from the base of the file mapping so that the mapping can be used at any address.
        /// </param>
        /// <param name="nndPreferred">
        /// The NUMA node where the physical memory should reside.
        /// <see cref="NUMA_NO_PREFERRED_NODE"/>: No NUMA node is preferred. This is the same as calling the <see cref="MapViewOfFileEx"/> function. 
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the starting address of the mapped view.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call the <see cref="GetLastError"/> function.
        /// </returns>
        /// <remarks>
        /// Mapping a file makes the specified portion of the file visible in the address space of the calling process.
        /// For files that are larger than the address space, you can map only a small portion of the file data at one time.
        /// When the first view is complete, then you unmap it and map a new view.
        /// To obtain the size of a view, use the <see cref="VirtualQueryEx"/> function.
        /// The initial contents of the pages in a file mapping object backed by the page file are 0 (zero).
        /// If a suggested mapping address is supplied, the file is mapped at the specified address (rounded down to the nearest 64-KB boundary)
        /// if there is enough address space at the specified address.
        /// If there is not enough address space, the function fails.
        /// Typically, the suggested address is used to specify that a file should be mapped at the same address in multiple processes.
        /// This requires the region of address space to be available in all involved processes.
        /// No other memory allocation can take place in the region that is used for mapping,
        /// including the use of the <see cref="VirtualAllocExNuma"/> function to reserve memory.
        /// If the <paramref name="lpBaseAddress"/> parameter specifies a base offset, the function succeeds
        /// if the specified memory region is not already in use by the calling process.
        /// The system does not ensure that the same memory region is available for the memory mapped file in other 32-bit processes.
        /// Multiple views of a file (or a file mapping object and its mapped file) are coherent if they contain identical data at a specified time.
        /// This occurs if the file views are derived from the same file mapping object.
        /// A process can duplicate a file mapping object handle into another process by using the <see cref="DuplicateHandle"/> function,
        /// or another process can open a file mapping object by name by using the <see cref="OpenFileMapping"/> function.
        /// With one important exception, file views derived from any file mapping object that is backed
        /// by the same file are coherent or identical at a specific time.
        /// Coherency is guaranteed for views within a process and for views that are mapped by different processes.
        /// The exception is related to remote files.
        /// Although <see cref="MapViewOfFileExNuma"/> works with remote files, it does not keep them coherent.
        /// For example, if two computers both map a file as writable, and both change the same page,
        /// each computer only sees its own writes to the page.
        /// When the data gets updated on the disk, it is not merged.
        /// A mapped view of a file is not guaranteed to be coherent with a file
        /// being accessed by the <see cref="ReadFile"/> or <see cref="WriteFile"/> function.
        /// To guard against <see cref="EXCEPTION_IN_PAGE_ERROR"/> exceptions, use structured exception handling
        /// to protect any code that writes to or reads from a memory mapped view of a file other than the page file.
        /// For more information, see Reading and Writing From a File View.
        /// When modifying a file through a mapped view, the last modification timestamp may not be updated automatically.
        /// If required, the caller should use <see cref="SetFileTime"/> to set the timestamp.
        /// To have a file with executable permissions, an application must call the <see cref="CreateFileMappingNuma"/> function
        /// with either <see cref="PAGE_EXECUTE_READWRITE"/> or <see cref="PAGE_EXECUTE_READ"/> and then call the <see cref="MapViewOfFileExNuma"/>
        /// function with <code>FILE_MAP_EXECUTE | FILE_MAP_WRITE or FILE_MAP_EXECUTE | FILE_MAP_READ</code>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "MapViewOfFileExNuma", ExactSpelling = true, SetLastError = true)]
        public static extern LPVOID MapViewOfFileExNuma([In] HANDLE hFileMappingObject, [In] DWORD dwDesiredAccess, [In] DWORD dwFileOffsetHigh,
            [In] DWORD dwFileOffsetLow, [In] SIZE_T dwNumberOfBytesToMap, [In] LPVOID lpBaseAddress, [In] DWORD nndPreferred);

        /// <summary>
        /// <para>
        /// Opens a named file mapping object.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-openfilemappingw"/>
        /// </para>
        /// </summary>
        /// <param name="dwDesiredAccess">
        /// The access to the file mapping object. This access is checked against any security descriptor on the target file mapping object.
        /// For a list of values, see File Mapping Security and Access Rights.
        /// </param>
        /// <param name="bInheritHandle">
        /// If this parameter is TRUE, a process created by the <see cref="CreateProcess"/> function can inherit the handle;
        /// otherwise, the handle cannot be inherited.
        /// </param>
        /// <param name="lpName">
        /// The name of the file mapping object to be opened.
        /// If there is an open handle to a file mapping object by this name and the security descriptor
        /// on the mapping object does not conflict with the <paramref name="dwDesiredAccess"/> parameter, the open operation succeeds.
        /// The name can have a "Global" or "Local" prefix to explicitly open an object in the global or session namespace.
        /// The remainder of the name can contain any character except the backslash character ().
        /// For more information, see Kernel Object Namespaces.
        /// Fast user switching is implemented using Terminal Services sessions.
        /// The first user to log on uses session 0, the next user to log on uses session 1, and so on.
        /// Kernel object names must follow the guidelines outlined for Terminal Services so that applications can support multiple users.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is an open handle to the specified file mapping object.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The handle that OpenFileMapping returns can be used with any function that requires a handle to a file mapping object.
        /// When modifying a file through a mapped view, the last modification timestamp may not be updated automatically.
        /// If required, the caller should use <see cref="SetFileTime"/> to set the timestamp.
        /// When it is no longer needed, the caller should call release
        /// the handle returned by <see cref="OpenFileMapping"/> with a call to <see cref="CloseHandle"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "OpenFileMappingW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE OpenFileMapping([In] ACCESS_MASK dwDesiredAccess, [In] BOOL bInheritHandle, [In] LPWSTR lpName);

        /// <summary>
        /// <para>
        /// Unmaps a mapped view of a file from the calling process's address space.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-unmapviewoffile"/>
        /// </para>
        /// </summary>
        /// <param name="lpBaseAddress">
        /// A pointer to the base address of the mapped view of a file that is to be unmapped.
        /// This value must be identical to the value returned
        /// by a previous call to the <see cref="MapViewOfFile"/> or <see cref="MapViewOfFileEx"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Unmapping a mapped view of a file invalidates the range occupied by the view in the address space of the process
        /// and makes the range available for other allocations.
        /// It removes the working set entry for each unmapped virtual page that was part of the working set of the process
        /// and reduces the working set size of the process.
        /// It also decrements the share count of the corresponding physical page.
        /// Modified pages in the unmapped view are not written to disk until their share count reaches zero,
        /// or in other words, until they are unmapped or trimmed from the working sets of all processes that share the pages.
        /// Even then, the modified pages are written "lazily" to disk; that is, modifications may be cached in memory and written to disk at a later time.
        /// To minimize the risk of data loss in the event of a power failure or a system crash,
        /// applications should explicitly flush modified pages using the <see cref="FlushViewOfFile"/> function.
        /// Although an application may close the file handle used to create a file mapping object,
        /// the system holds the corresponding file open until the last view of the file is unmapped.
        /// Files for which the last view has not yet been unmapped are held open with no sharing restrictions.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "UnmapViewOfFile", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL UnmapViewOfFile([In] LPCVOID lpBaseAddress);

        /// <summary>
        /// <para>
        /// This is an extended version of <see cref="UnmapViewOfFile"/> that takes an additional flags parameter.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-unmapviewoffileex"/>
        /// </para>
        /// </summary>
        /// <param name="BaseAddress">
        /// A pointer to the base address of the mapped view of a file that is to be unmapped.
        /// This value must be identical to the value returned by a previous call to
        /// the <see cref="MapViewOfFile"/> or <see cref="MapViewOfFileEx"/> function.
        /// </param>
        /// <param name="UnmapFlags">
        /// This parameter can be one of the following values.
        /// <see cref="MEM_UNMAP_WITH_TRANSIENT_BOOST"/>:
        /// Specifies that the priority of the pages being unmapped should be temporarily boosted (with automatic short term decay)
        /// because the caller expects that these pages will be accessed again shortly from another thread.
        /// For more information about memory priorities, see the <code>SetThreadInformation(ThreadMemoryPriority)</code> function.
        /// <see cref="MEM_PRESERVE_PLACEHOLDER"/>:
        /// Unmaps a mapped view back to a placeholder (after you've replaced a placeholder with a mapped view
        /// using <see cref="MapViewOfFile2"/> or MapViewOfFile2FromApp).
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// For more information about the behavior of this function, see the <see cref="UnmapViewOfFile"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "UnmapViewOfFileEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL UnmapViewOfFileEx([In] PVOID BaseAddress, [In] ULONG UnmapFlags);
    }
}
