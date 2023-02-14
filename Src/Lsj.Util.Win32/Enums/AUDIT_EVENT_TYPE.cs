using static Lsj.Util.Win32.Advapi32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="AUDIT_EVENT_TYPE"/> enumeration type defines values that indicate the type of object being audited.
    /// The <see cref="AccessCheckByTypeAndAuditAlarm"/> and <see cref="AccessCheckByTypeResultListAndAuditAlarm"/> functions use these values.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ne-winnt-audit_event_type"/>
    /// </para>
    /// </summary>
    public enum AUDIT_EVENT_TYPE
    {
        /// <summary>
        /// Indicates an object that generates audit messages only if the system administrator has enabled auditing access to files and objects.
        /// </summary>
        AuditEventObjectAccess,

        /// <summary>
        /// Indicates a directory service object that generates audit messages only if the system administrator has enabled auditing access to directory service objects.
        /// </summary>
        AuditEventDirectoryServiceAccess,
    }
}
