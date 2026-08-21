using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains the name of a service in a service control manager database and information about that service.
    /// It is used by the <see cref="EnumDependentServices"/> and <see cref="EnumServicesStatus"/> functions.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/ns-winsvc-enum_service_statusw"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ENUM_SERVICE_STATUS
    {
        /// <summary>
        /// The name of a service in the service control manager database.
        /// The maximum string length is 256 characters.
        /// The service control manager database preserves the case of the characters,
        /// but service name comparisons are always case insensitive.
        /// A slash (/), backslash (\), comma, and space are invalid service name characters.
        /// </summary>
        public nint lpServiceName;

        /// <summary>
        /// A display name that can be used by service control programs,
        /// such as Services in Control Panel, to identify the service.
        /// This string has a maximum length of 256 characters.
        /// The name is case-preserved in the service control manager.
        /// Display name comparisons are always case-insensitive.
        /// </summary>
        public nint lpDisplayName;

        /// <summary>
        /// A <see cref="SERVICE_STATUS"/> structure that contains status information for the <see cref="lpServiceName"/> service.
        /// </summary>
        public SERVICE_STATUS ServiceStatus;
    }
}
