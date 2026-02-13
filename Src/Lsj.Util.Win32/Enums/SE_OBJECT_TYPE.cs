namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="SE_OBJECT_TYPE"/> enumeration contains values
    /// that correspond to the types of Windows objects that support security.
    /// The functions, such as <see cref="GetSecurityInfo"/> and <see cref="SetSecurityInfo"/>,
    /// that set and retrieve the security information of an object, use these values to indicate the type of object.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/accctrl/ne-accctrl-se_object_type"/>
    /// </para>
    /// </summary>
    public enum SE_OBJECT_TYPE
    {
        /// <summary>
        /// Unknown object type.
        /// </summary>
        SE_UNKNOWN_OBJECT_TYPE,

        /// <summary>
        /// <para>
        /// Indicates a file or directory.
        /// The name string that identifies a file or directory object can be in one of the following formats:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// A relative path, such as <c>FileName.dat</c> or <c>..\FileName</c>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// An absolute path, such as <c>FileName.dat</c>, <c>C:\DirectoryName\FileName.dat</c>,
        /// or <c>G:\RemoteDirectoryName\FileName.dat</c>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A UNC name, such as <c>\\ComputerName\ShareName\FileName.dat</c>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        SE_FILE_OBJECT,

        /// <summary>
        /// Indicates a Windows service.
        /// A service object can be a local service, such as <c>ServiceName</c>,
        /// or a remote service, such as <c>\\ComputerName\ServiceName</c>.
        /// </summary>
        SE_SERVICE,

        /// <summary>
        /// Indicates a printer.
        /// A printer object can be a local printer, such as <c>PrinterName</c>,
        /// or a remote printer, such as <c>\\ComputerName\PrinterName</c>.
        /// </summary>
        SE_PRINTER,

        /// <summary>
        /// <para>
        /// Indicates a registry key.
        /// A registry key object can be in the local registry,
        /// such as <c>CLASSES_ROOT\SomePath</c> or in a remote registry,
        /// such as <c>\\ComputerName\CLASSES_ROOT\SomePath</c>.
        /// </para>
        /// <para>
        /// The names of registry keys must use the following literal strings to identify the predefined registry keys:
        /// "CLASSES_ROOT", "CURRENT_USER", "MACHINE", and "USERS".
        /// </para>
        /// </summary>
        SE_REGISTRY_KEY,

        /// <summary>
        /// Indicates a network share.
        /// A share object can be local, such as <c>ShareName</c>, or remote, such as <c>\\ComputerName\ShareName</c>.
        /// </summary>
        SE_LMSHARE,

        /// <summary>
        /// <para>
        /// Indicates a local kernel object.
        /// </para>
        /// <para>
        /// The <see cref="GetSecurityInfo"/> and <see cref="SetSecurityInfo"/> functions support all types of kernel objects.
        /// The <see cref="GetNamedSecurityInfo"/> and <see cref="SetNamedSecurityInfo"/> functions work only with the following kernel objects:
        /// semaphore, event, mutex, waitable timer, and file mapping.
        /// </para>
        /// </summary>
        SE_KERNEL_OBJECT,

        /// <summary>
        /// <para>
        /// Indicates a window station or desktop object on the local computer.
        /// You cannot use <see cref="GetNamedSecurityInfo"/> and <see cref="SetNamedSecurityInfo"/> with these objects
        /// because the names of window stations or desktops are not unique.
        /// </para>
        /// </summary>
        SE_WINDOW_OBJECT,

        /// <summary>
        /// <para>
        /// Indicates a directory service object or a property set or property of a directory service object.
        /// </para>
        /// <para>
        /// The name string for a directory service object must be in X.500 form, for example:
        /// </para>
        /// <para>
        /// <c>CN=SomeObject,OU=ou2,OU=ou1,DC=DomainName,DC=CompanyName,DC=com,O=internet</c>
        /// </para>
        /// </summary>
        SE_DS_OBJECT,

        /// <summary>
        /// Indicates a directory service object and all of its property sets and properties.
        /// </summary>
        SE_DS_OBJECT_ALL,

        /// <summary>
        /// Indicates a provider-defined object.
        /// </summary>
        SE_PROVIDER_DEFINED_OBJECT,

        /// <summary>
        /// Indicates a WMI object.
        /// </summary>
        SE_WMIGUID_OBJECT,

        /// <summary>
        /// Indicates an object for a registry entry under WOW64.
        /// </summary>
        SE_REGISTRY_WOW64_32KEY,

        /// <summary>
        /// 
        /// </summary>
        SE_REGISTRY_WOW64_64KEY
    }
}
