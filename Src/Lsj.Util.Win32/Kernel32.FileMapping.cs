using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.FileMapAccessRights;
using static Lsj.Util.Win32.Enums.GenericAccessRights;
using static Lsj.Util.Win32.Enums.MemoryProtectionConstants;
using static Lsj.Util.Win32.Enums.SectionAttributes;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;

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
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-createfilemappingw
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
        /// <see cref="SEC_LARGE_PAGES"/> requires the <see cref="SeLockMemoryPrivilege"/> privilege
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
        /// requires the <see cref="SeCreateGlobalPrivilege"/> privilege.
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
        /// requires the <see cref="SeCreateGlobalPrivilege"/> privilege.
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
        public static extern IntPtr CreateFileMapping([In]IntPtr hFile,
             [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))]
             [In] StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpFileMappingAttributes, [In]uint flProtect, [In]uint dwMaximumSizeHigh,
             [In]uint dwMaximumSizeLow, [MarshalAs(UnmanagedType.LPWStr)][In]string lpName);

        /// <summary>
        /// <para>
        /// Creates or opens a named or unnamed file mapping object for a specified file and specifies the NUMA node for the physical memory.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/memoryapi/nf-memoryapi-createfilemappingnumaw
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
        /// (the <paramref name="hFile"/> parameter is <see cref="Constants.INVALID_HANDLE_VALUE"/>).
        /// This attribute is not supported for file mapping objects that are backed by executable image files or data files
        /// (the <paramref name="hFile"/> parameter is a handle to an executable image or data file).
        /// The maximum size of the file mapping object must be a multiple of the minimum size of a large page
        /// returned by the <see cref="GetLargePageMinimum"/> function.
        /// If it is not, <see cref="CreateFileMapping"/> fails.
        /// When mapping a view of a file mapping object created with <see cref="SEC_LARGE_PAGES"/>,
        /// the base address and view size must also be multiples of the minimum large page size.
        /// <see cref="SEC_LARGE_PAGES"/> requires the <see cref="SeLockMemoryPrivilege"/> privilege
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
        /// requires the <see cref="SeCreateGlobalPrivilege"/> privilege.
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
        /// requires the <see cref="SeCreateGlobalPrivilege"/> privilege.
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
        public static extern IntPtr CreateFileMappingNuma([In]IntPtr hFile,
             [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))]
             [In] StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpFileMappingAttributes, [In]uint flProtect, [In]uint dwMaximumSizeHigh,
             [In]uint dwMaximumSizeLow, [MarshalAs(UnmanagedType.LPWStr)][In]string lpName, [In]uint nndPreferred);
    }
}
