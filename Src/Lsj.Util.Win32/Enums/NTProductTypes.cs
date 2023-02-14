namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Product Types
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-osversioninfoexw"/>
    /// </para>
    /// </summary>
    public enum NTProductTypes : byte
    {
        /// <summary>
        /// The system is a domain controller and the operating system is Windows Server 2012 , Windows Server 2008 R2,
        /// Windows Server 2008, Windows Server 2003, or Windows 2000 Server.
        /// </summary>
        VER_NT_DOMAIN_CONTROLLER = 2,

        /// <summary>
        /// The operating system is Windows Server 2012, Windows Server 2008 R2, Windows Server 2008, Windows Server 2003, or Windows 2000 Server.
        /// Note that a server that is also a domain controller is reported as <see cref="VER_NT_DOMAIN_CONTROLLER"/>, not <see cref="VER_NT_SERVER"/>.
        /// </summary>
        VER_NT_SERVER = 3,

        /// <summary>
        /// The operating system is Windows 8, Windows 7, Windows Vista, Windows XP Professional, Windows XP Home Edition, or Windows 2000 Professional.
        /// </summary>
        VER_NT_WORKSTATION = 1,
    }
}
