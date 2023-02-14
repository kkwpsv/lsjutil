using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Suite Masks
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-osversioninfoexw"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum SuiteMasks : uint
    {
        /// <summary>
        /// Microsoft BackOffice components are installed.
        /// </summary>
        VER_SUITE_BACKOFFICE = 0x00000004,

        /// <summary>
        /// Windows Server 2003, Web Edition is installed.
        /// </summary>
        VER_SUITE_BLADE = 0x00000400,

        /// <summary>
        /// Windows Server 2003, Compute Cluster Edition is installed.
        /// </summary>
        VER_SUITE_COMPUTE_SERVER = 0x00004000,

        /// <summary>
        /// Windows Server 2008 Datacenter, Windows Server 2003, Datacenter Edition, or Windows 2000 Datacenter Server is installed.
        /// </summary>
        VER_SUITE_DATACENTER = 0x00000080,

        /// <summary>
        /// Windows Server 2008 Enterprise, Windows Server 2003, Enterprise Edition, or Windows 2000 Advanced Server is installed.
        /// Refer to the Remarks section for more information about this bit flag.
        /// </summary>
        VER_SUITE_ENTERPRISE = 0x00000002,

        /// <summary>
        /// Windows XP Embedded is installed.
        /// </summary>
        VER_SUITE_EMBEDDEDNT = 0x00000040,

        /// <summary>
        /// Windows Vista Home Premium, Windows Vista Home Basic, or Windows XP Home Edition is installed.
        /// </summary>
        VER_SUITE_PERSONAL = 0x00000200,

        /// <summary>
        /// Remote Desktop is supported, but only one interactive session is supported.
        /// This value is set unless the system is running in application server mode.
        /// </summary>
        VER_SUITE_SINGLEUSERTS = 0x00000100,

        /// <summary>
        /// Microsoft Small Business Server was once installed on the system, but may have been upgraded to another version of Windows.
        /// Refer to the Remarks section for more information about this bit flag.
        /// </summary>
        VER_SUITE_SMALLBUSINESS = 0x00000001,

        /// <summary>
        /// Microsoft Small Business Server is installed with the restrictive client license in force.
        /// Refer to the Remarks section for more information about this bit flag.
        /// </summary>
        VER_SUITE_SMALLBUSINESS_RESTRICTED = 0x00000020,

        /// <summary>
        /// Windows Storage Server 2003 R2 or Windows Storage Server 2003 is installed.
        /// </summary>
        VER_SUITE_STORAGE_SERVER = 0x00002000,

        /// <summary>
        /// Terminal Services is installed. This value is always set.
        /// If <see cref="VER_SUITE_TERMINAL"/> is set but <see cref="VER_SUITE_SINGLEUSERTS"/> is not set,
        /// the system is running in application server mode.
        /// </summary>
        VER_SUITE_TERMINAL = 0x00000010,

        /// <summary>
        /// Windows Home Server is installed.
        /// </summary>
        VER_SUITE_WH_SERVER = 0x00008000,

        /// <summary>
        /// AppServer mode is enabled.
        /// </summary>
        VER_SUITE_MULTIUSERTS = 0x00020000,
    }
}
