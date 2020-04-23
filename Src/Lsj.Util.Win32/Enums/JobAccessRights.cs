using static Lsj.Util.Win32.Enums.JOBOBJECTINFOCLASS;
using static Lsj.Util.Win32.Enums.StandardAccessRights;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Job Access Rights
    /// The valid access rights for job objects include the standard access rights and some job-specific access rights.
    /// The following table lists the standard access rights used by all objects.
    /// <see cref="DELETE"/>, <see cref="READ_CONTROL"/>, <see cref="SYNCHRONIZE"/>, <see cref="WRITE_DAC"/>, <see cref="WRITE_OWNER "/>.
    /// </para>
    /// </summary>
    public enum JobAccessRights : uint
    {
        /// <summary>
        /// Combines all valid job object access rights.
        /// </summary>
        JOB_OBJECT_ALL_ACCESS = 0x1F001F,

        /// <summary>
        /// Required to call the <see cref="AssignProcessToJobObject"/> function to assign processes to the job object.
        /// </summary>
        JOB_OBJECT_ASSIGN_PROCESS = 0x0001,

        /// <summary>
        /// Required to retrieve certain information about a job object, such as attributes and accounting information
        /// (see <see cref="QueryInformationJobObject"/> and <see cref="IsProcessInJob"/>).
        /// </summary>
        JOB_OBJECT_QUERY = 0x0004,

        /// <summary>
        /// Required to call the <see cref="SetInformationJobObject"/> function to set the attributes of the job object.
        /// </summary>
        JOB_OBJECT_SET_ATTRIBUTES = 0x0002,

        /// <summary>
        /// This flag is not supported.
        /// You must set security limitations individually for each process associated with a job object.
        /// Windows Server 2003 and Windows XP:
        /// Required to call the <see cref="SetInformationJobObject"/> function with the <see cref="JobObjectSecurityLimitInformation"/> information class
        /// to set security limitations for the processes associated with the job object.
        /// Support for this flag was removed in Windows Vista and Windows Server 2008.
        /// </summary>
        JOB_OBJECT_SET_SECURITY_ATTRIBUTES = 0x0010,

        /// <summary>
        /// Required to call the <see cref="TerminateJobObject"/> function to terminate all processes in the job object.
        /// </summary>
        JOB_OBJECT_TERMINATE = 0x0008,
    }
}
