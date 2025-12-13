using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.JobAccessRights;
using static Lsj.Util.Win32.Enums.JobObjectInformationClasses;
using static Lsj.Util.Win32.Enums.JobObjectLimitFlags;
using static Lsj.Util.Win32.Enums.JobObjectSecurityLimitFlags;
using static Lsj.Util.Win32.Enums.ProcessAccessRights;
using static Lsj.Util.Win32.Enums.ProcessCreationFlags;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// Assigns a process to an existing job object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/jobapi2/nf-jobapi2-assignprocesstojobobject"/>
        /// </para>
        /// </summary>
        /// <param name="hJob">
        /// A handle to the job object to which the process will be associated.
        /// The <see cref="CreateJobObject"/> or <see cref="OpenJobObject"/> function returns this handle.
        /// The handle must have the <see cref="JOB_OBJECT_ASSIGN_PROCESS"/> access right.
        /// For more information, see Job Object Security and Access Rights.
        /// </param>
        /// <param name="hProcess">
        /// <para>
        /// A handle to the process to associate with the job object.
        /// The handle must have the <see cref="PROCESS_SET_QUOTA"/> and <see cref="PROCESS_TERMINATE"/> access rights.
        /// For more information, see Process Security and Access Rights.
        /// </para>
        /// <para>
        /// If the process is already associated with a job, the job specified by <paramref name="hJob"/> must be empty
        /// or it must be in the hierarchy of nested jobs to which the process already belongs,
        /// and it cannot have UI limits set (<see cref="SetInformationJobObject"/> with <see cref="JobObjectBasicUIRestrictions"/>).
        /// For more information, see Remarks.
        /// </para>
        /// <para>
        /// Windows 7, Windows Server 2008 R2, Windows XP with SP3, Windows Server 2008, Windows Vista and Windows Server 2003:
        /// The process must not already be assigned to a job; if it is, the function fails with <see cref="ERROR_ACCESS_DENIED"/>.
        /// This behavior changed starting in Windows 8 and Windows Server 2012.
        /// </para>
        /// <para>
        /// Terminal Services:
        /// All processes within a job must run within the same session as the job.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// After you associate a process with a job object using <see cref="AssignProcessToJobObject"/>,
        /// the process is subject to the limits set for the job.
        /// To set limits for a job, use the <see cref="SetInformationJobObject"/> function.
        /// </para>
        /// <para>
        /// If the job has a user-mode time limit, and the time limit has been exhausted,
        /// <see cref="AssignProcessToJobObject"/> fails and the specified process is terminated.
        /// If the time limit would be exceeded by associating the process, <see cref="AssignProcessToJobObject"/> still succeeds.
        /// However, the time limit violation will be reported.
        /// If the job has an active process limit, and the limit would be exceeded by associating this process,
        /// <see cref="AssignProcessToJobObject"/> fails, and the specified process is terminated.
        /// </para>
        /// <para>
        /// Memory operations performed by a process associated with a job that has a memory limit are subject to the memory limit.
        /// Memory operations performed by the process before it was associated with the job are not examined by <see cref="AssignProcessToJobObject"/>.
        /// </para>
        /// <para>
        /// If the process is already running and the job has security limitations, <see cref="AssignProcessToJobObject"/> may fail.
        /// For example, if the primary token of the process contains the local administrators group,
        /// but the job object has the security limitation <see cref="JOB_OBJECT_SECURITY_NO_ADMIN"/>, the function fails.
        /// If the job has the security limitation <see cref="JOB_OBJECT_SECURITY_ONLY_TOKEN"/>, the process must be created suspended.
        /// To create a suspended process, call the <see cref="CreateProcess"/> function with the <see cref="CREATE_SUSPENDED"/> flag.
        /// </para>
        /// <para>
        /// A process can be associated with more than one job in a hierarchy of nested jobs.
        /// For priority class, affinity, commit charge, per-process execution time limit,
        /// scheduling class limit, and working set minimum and maximum,
        /// the process inherits an effective limit which is the most restrictive limit of all the jobs in its parent job chain.
        /// For other resource limits, the process inherits limits from its immediate job in the hierarchy.
        /// Accounting information is added to the immediate job and aggregated in each parent job in the job chain.
        /// By default, all child processes are associated with the immediate job and every job in the parent job chain.
        /// To create a child process that is not part of the same job chain,
        /// call the <see cref="CreateProcess"/> function with the <see cref="CREATE_BREAKAWAY_FROM_JOB"/> flag.
        /// The child process breaks away from every job in the job chain unless a job in the chain does not allow breakaway.
        /// In this case, the child process does not break away from that job or any job above it in the job chain.
        /// For more information, see Nested Jobs.
        /// </para>
        /// <para>
        /// Windows 7, Windows Server 2008 R2, Windows XP with SP3, Windows Server 2008, Windows Vista and Windows Server 2003:
        /// A process can be associated only with a single job.
        /// A process inherits limits from the job it is associated with and adds its accounting information to the job.
        /// If a process is associated with a job, all child processes it creates are associated with that job by default.
        /// To create a child process that is not part of the same job,
        /// call the <see cref="CreateProcess"/> function with the <see cref="CREATE_BREAKAWAY_FROM_JOB"/> flag.
        /// A process can be associated with more than one job starting in Windows 8 and Windows Server 2012.
        /// </para>
        /// <para>
        /// Windows 7, Windows Server 2008 R2, Windows Server 2008 and Windows Vista:
        /// If the process is being monitored by the Program Compatibility Assistant (PCA), it is placed into a compatibility job.
        /// Therefore, the process must be created using <see cref="CREATE_BREAKAWAY_FROM_JOB"/> before it can be placed in another job.
        /// Alternatively, you can embed an application manifest that specifies a User Account Control (UAC) level in your application
        /// and PCA will not add the process to the compatibility job.
        /// For more information, see Application Development Requirements for User Account Control Compatibility.
        /// </para>
        /// <para>
        /// If the job or any of its parent jobs in the job chain is terminating
        /// when <see cref="AssignProcessToJobObject"/> is called, the function fails.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "AssignProcessToJobObject", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AssignProcessToJobObject([In] HANDLE hJob, [In] HANDLE hProcess);

        /// <summary>
        /// <para>
        /// Creates or opens a job object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/jobapi2/nf-jobapi2-createjobobjectw"/>
        /// </para>
        /// </summary>
        /// <param name="lpJobAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that specifies the security descriptor for the job object
        /// and determines whether child processes can inherit the returned handle.
        /// If <paramref name="lpJobAttributes"/> is <see cref="NullRef{SECURITY_ATTRIBUTES}"/>, the job object gets a default security descriptor 
        /// and the handle cannot be inherited.
        /// The ACLs in the default security descriptor for a job object come from the primary or impersonation token of the creator.
        /// </param>
        /// <param name="lpName">
        /// <para>
        /// The name of the job. The name is limited to <see cref="MAX_PATH"/> characters.
        /// Name comparison is case-sensitive.
        /// </para>
        /// <para>
        /// If <paramref name="lpName"/> is <see cref="NULL"/>, the job is created without a name.
        /// </para>
        /// <para>
        /// If <paramref name="lpName"/> matches the name of an existing event, semaphore, mutex,
        /// waitable timer, or file-mapping object, the function fails
        /// and the <see cref="GetLastError"/> function returns <see cref="ERROR_INVALID_HANDLE"/>.
        /// This occurs because these objects share the same namespace.
        /// </para>
        /// <para>
        /// The object can be created in a private namespace.
        /// For more information, see Object Namespaces.
        /// </para>
        /// <para>
        /// Terminal Services:
        /// The name can have a "Global\" or "Local\" prefix to explicitly create the object in the global or session namespace.
        /// The remainder of the name can contain any character except the backslash character (\).
        /// For more information, see Kernel Object Namespaces.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the job object.
        /// The handle has the <see cref="JOB_OBJECT_ALL_ACCESS"/> access right.
        /// If the object existed before the function call, the function returns a handle to the existing job object
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_ALREADY_EXISTS"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// When a job is created, its accounting information is initialized to zero, all limits are inactive, and there are no associated processes.
        /// To assign a process to a job object, use the <see cref="AssignProcessToJobObject"/> function.
        /// To set limits for a job, use the <see cref="SetInformationJobObject"/> function.
        /// To query accounting information, use the <see cref="QueryInformationJobObject"/> function.
        /// </para>
        /// <para>
        /// All processes associated with a job must run in the same session.
        /// A job is associated with the session of the first process to be assigned to the job.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP:
        /// A job is associated with the session of the process that created it.
        /// </para>
        /// <para>
        /// To close a job object handle, use the <see cref="CloseHandle"/> function.
        /// The job is destroyed when its last handle has been closed and all associated processes have exited.
        /// However, if the job has the <see cref="JOB_OBJECT_LIMIT_KILL_ON_JOB_CLOSE"/> flag specified,
        /// closing the last job object handle terminates all associated processes and then destroys the job object itself.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateJobObjectW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE CreateJobObject([In] in SECURITY_ATTRIBUTES lpJobAttributes, [In] LPCWSTR lpName);

        /// <summary>
        /// <para>
        /// Determines whether the process is running in the specified job.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/jobapi/nf-jobapi-isprocessinjob"/>
        /// </para>
        /// </summary>
        /// <param name="ProcessHandle">
        /// <para>
        /// A handle to the process to be tested.
        /// The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> or <see cref="PROCESS_QUERY_LIMITED_INFORMATION"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP:
        /// The handle must have the <see cref="PROCESS_QUERY_INFORMATION"/> access right.
        /// </para>
        /// </param>
        /// <param name="JobHandle">
        /// <para>
        /// A handle to the job.
        /// If this parameter is <see cref="NULL"/>, the function tests if the process is running under any job.
        /// </para>
        /// <para>
        /// If this parameter is not <see cref="NULL"/>, the handle must have the <see cref="JOB_OBJECT_QUERY"/> access right.
        /// For more information, see Job Object Security and Access Rights.
        /// </para>
        /// </param>
        /// <param name="Result">
        /// A pointer to a value that receives <see cref="TRUE"/> if the process is running in the job, and <see cref="FALSE"/> otherwise.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// An application cannot obtain a handle to the job object in which it is running unless it has the name of the job object.
        /// However, an application can call the <see cref="QueryInformationJobObject"/> function
        /// with <see cref="NULL"/> to obtain information about the job object.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsProcessInJob", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsProcessInJob([In] HANDLE ProcessHandle, [In] HANDLE JobHandle, [Out] out BOOL Result);

        /// <summary>
        /// <para>
        /// Opens an existing job object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/jobapi2/nf-jobapi2-openjobobjectw"/>
        /// </para>
        /// </summary>
        /// <param name="dwDesiredAccess">
        /// The access to the job object.
        /// This parameter can be one or more of the job object access rights.
        /// This access right is checked against any security descriptor for the object.
        /// </param>
        /// <param name="bInheritHandle">
        /// If this value is <see cref="TRUE"/>, processes created by this process will inherit the handle.
        /// Otherwise, the processes do not inherit this handle.
        /// </param>
        /// <param name="lpName">
        /// <para>
        /// The name of the job to be opened. Name comparisons are case sensitive.
        /// </para>
        /// <para>
        /// This function can open objects in a private namespace.
        /// For more information, see Object Namespaces.
        /// </para>
        /// <para>
        /// Terminal Services:
        /// The name can have a "Global\" or "Local\" prefix to explicitly open the object in the global or session namespace.
        /// The remainder of the name can contain any character except the backslash character (\).
        /// For more information, see Kernel Object Namespaces.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the job.
        /// The handle provides the requested access to the job.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// To associate a process with a job, use the <see cref="AssignProcessToJobObject"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "OpenJobObjectW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE OpenJobObject([In] ACCESS_MASK dwDesiredAccess, [In] BOOL bInheritHandle, [In] LPCWSTR lpName);

        /// <summary>
        /// <para>
        /// Retrieves limit and job state information from the job object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/jobapi2/nf-jobapi2-queryinformationjobobject"/>
        /// </para>
        /// </summary>
        /// <param name="hJob">
        /// <para>
        /// A handle to the job whose information is being queried.
        /// The <see cref="CreateJobObject"/> or <see cref="OpenJobObject"/> function returns this handle.
        /// The handle must have the <see cref="JOB_OBJECT_QUERY"/> access right.
        /// For more information, see Job Object Security and Access Rights.
        /// </para>
        /// <para>
        /// If this value is <see cref="NULL"/> and the calling process is associated with a job,
        /// the job associated with the calling process is used.
        /// If the job is nested, the immediate job of the calling process is used.
        /// </para>
        /// </param>
        /// <param name="JobObjectInformationClass">
        /// <para>
        /// The information class for the limits to be queried.
        /// This parameter can be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JobObjectBasicAccountingInformation"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// The <paramref name="lpJobObjectInformation"/> parameter is a pointer to a <see cref="JOBOBJECT_BASIC_ACCOUNTING_INFORMATION"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JobObjectBasicAndIoAccountingInformation"/>
        /// </para>
        /// <para>
        /// 8
        /// </para>
        /// </term>
        /// <term>
        /// The <paramref name="lpJobObjectInformation"/> parameter is a pointer to a <see cref="JOBOBJECT_BASIC_AND_IO_ACCOUNTING_INFORMATION"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JobObjectBasicLimitInformation"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// The <paramref name="lpJobObjectInformation"/> parameter is a pointer to a <see cref="JOBOBJECT_BASIC_LIMIT_INFORMATION"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JobObjectBasicProcessIdList"/>
        /// </para>
        /// <para>
        /// 3
        /// </para>
        /// </term>
        /// <term>
        /// The <paramref name="lpJobObjectInformation"/> parameter is a pointer to a <see cref="JOBOBJECT_BASIC_PROCESS_ID_LIST"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JobObjectBasicUIRestrictions"/>
        /// </para>
        /// <para>
        /// 4
        /// </para>
        /// </term>
        /// <term>
        /// The <paramref name="lpJobObjectInformation"/> parameter is a pointer to a <see cref="JOBOBJECT_BASIC_UI_RESTRICTIONS"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JobObjectCpuRateControlInformation"/>
        /// </para>
        /// <para>
        /// 15
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpJobObjectInformation"/> parameter is a pointer to a <see cref="JOBOBJECT_CPU_RATE_CONTROL_INFORMATION"/> structure.
        /// </para>
        /// <para>
        /// Windows 7, Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// This flag is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JobObjectEndOfJobTimeInformation"/>
        /// </para>
        /// <para>
        /// 6
        /// </para>
        /// </term>
        /// <term>
        /// The <paramref name="lpJobObjectInformation"/> parameter is a pointer to a <see cref="JOBOBJECT_END_OF_JOB_TIME_INFORMATION"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JobObjectExtendedLimitInformation"/>
        /// </para>
        /// <para>
        /// 9
        /// </para>
        /// </term>
        /// <term>
        /// The <paramref name="lpJobObjectInformation"/> parameter is a pointer to a <see cref="JOBOBJECT_EXTENDED_LIMIT_INFORMATION"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JobObjectGroupInformation"/>
        /// </para>
        /// <para>
        /// 11
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpJobObjectInformation"/> parameter is a pointer to a buffer
        /// that receives the list of processor groups to which the job is currently assigned.
        /// The variable pointed to by the <paramref name="lpReturnLength"/> parameter is set to the size of the group data.
        /// Divide this value by <c>sizeof(USHORT)</c> to determine the number of groups.
        /// </para>
        /// <para>
        /// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// This flag is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JobObjectGroupInformationEx"/>
        /// </para>
        /// <para>
        /// 14
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpJobObjectInformation"/> parameter is a pointer to a buffer
        /// that receives an array of <see cref="GROUP_AFFINITY"/> structures
        /// that indicate the affinity of the job in the processor groups to which the job is currently assigned.
        /// The variable pointed to by the <paramref name="lpReturnLength"/> parameter is set to the size of the group affinity data.
        /// Divide this value by <c>sizeof(GROUP_AFFINITY)</c> to determine the number of groups.
        /// </para>
        /// <para>
        /// Windows 7, Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// This flag is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JobObjectLimitViolationInformation"/>
        /// </para>
        /// <para>
        /// 13
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpJobObjectInformation"/> parameter is a pointer to a <see cref="JOBOBJECT_LIMIT_VIOLATION_INFORMATION"/> structure.
        /// </para>
        /// <para>
        /// Windows 7, Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// This flag is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JobObjectLimitViolationInformation2"/>
        /// </para>
        /// <para>
        /// 34
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpJobObjectInformation"/> parameter is a pointer to a <see cref="JOBOBJECT_LIMIT_VIOLATION_INFORMATION_2"/> structure.
        /// </para>
        /// <para>
        /// Windows 8.1, Windows Server 2012 R2, Windows 8, Windows Server 2012, Windows 7, Windows Server 2008 R2,
        /// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:  This flag is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JobObjectNetRateControlInformation"/>
        /// </para>
        /// <para>
        /// 32
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpJobObjectInformation"/> parameter is a pointer to a <see cref="JOBOBJECT_NET_RATE_CONTROL_INFORMATION"/> structure.
        /// </para>
        /// <para>
        /// Windows 8.1, Windows Server 2012 R2, Windows 8, Windows Server 2012, Windows 7, Windows Server 2008 R2,
        /// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// This flag is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JobObjectNotificationLimitInformation"/>
        /// </para>
        /// <para>
        /// 12
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpJobObjectInformation"/> parameter is a pointer to a <see cref="JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION"/> structure.
        /// </para>
        /// <para>
        /// Windows 7, Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// This flag is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JobObjectNotificationLimitInformation2"/>
        /// </para>
        /// <para>
        /// 33
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpJobObjectInformation"/> parameter is a pointer to a <see cref="JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION_2"/> structure.
        /// </para>
        /// <para>
        /// Windows 8.1, Windows Server 2012 R2, Windows 8, Windows Server 2012, Windows 7, Windows Server 2008 R2,
        /// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// This flag is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JobObjectSecurityLimitInformation"/>
        /// </para>
        /// <para>
        /// 5
        /// </para>
        /// </term>
        /// <term>
        /// This flag is not supported. Applications must set security limits individually for each process.
        /// Windows Server 2003 and Windows XP:
        /// The <paramref name="lpJobObjectInformation"/> parameter is a pointer to a <see cref="JOBOBJECT_SECURITY_LIMIT_INFORMATION"/> structure.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpJobObjectInformation">
        /// The limit or job state information.
        /// The format of this data depends on the value of the <paramref name="JobObjectInformationClass"/> parameter.
        /// </param>
        /// <param name="cbJobObjectInformationLength">
        /// The count of the job information being queried, in bytes.
        /// This value depends on the value of the <paramref name="JobObjectInformationClass"/> parameter.
        /// </param>
        /// <param name="lpReturnLength">
        /// A pointer to a variable that receives the length of data written to the structure
        /// pointed to by the <paramref name="lpJobObjectInformation"/> parameter.
        /// Specify <see cref="NullRef{DWORD}"/> to not receive this information.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// Use <see cref="QueryInformationJobObject"/> to obtain the current limits and modify them.
        /// Use the <see cref="SetInformationJobObject"/> function to set new limits.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "QueryInformationJobObject", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL QueryInformationJobObject([In] HANDLE hJob, [In] JobObjectInformationClasses JobObjectInformationClass,
            [In] LPVOID lpJobObjectInformation, [In] DWORD cbJobObjectInformationLength, [Out] out DWORD lpReturnLength);

        /// <summary>
        /// <para>
        /// Sets limits for a job object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/jobapi2/nf-jobapi2-setinformationjobobject"/>
        /// </para>
        /// </summary>
        /// <param name="hJob">
        /// A handle to the job whose limits are being set.
        /// The <see cref="CreateJobObject"/> or <see cref="OpenJobObject"/> function returns this handle.
        /// The handle must have the <see cref="JOB_OBJECT_SET_ATTRIBUTES"/> access right.
        /// For more information, see Job Object Security and Access Rights.
        /// </param>
        /// <param name="JobObjectInformationClass">
        /// <para>
        /// The information class for the limits to be set. This parameter can be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JobObjectAssociateCompletionPortInformation"/>
        /// </para>
        /// <para>
        /// 7
        /// </para>
        /// </term>
        /// <term>
        /// The <paramref name="lpJobObjectInfo"/> parameter is a pointer to a <see cref="JOBOBJECT_ASSOCIATE_COMPLETION_PORT"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JobObjectBasicLimitInformation"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// The <paramref name="lpJobObjectInfo"/> parameter is a pointer to a <see cref="JOBOBJECT_BASIC_LIMIT_INFORMATION"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JobObjectBasicUIRestrictions"/>
        /// </para>
        /// <para>
        /// 4
        /// </para>
        /// </term>
        /// <term>
        /// The <paramref name="lpJobObjectInfo"/> parameter is a pointer to a <see cref="JOBOBJECT_BASIC_UI_RESTRICTIONS"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JobObjectCpuRateControlInformation"/>
        /// </para>
        /// <para>
        /// 15
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpJobObjectInfo"/> parameter is a pointer to a <see cref="JOBOBJECT_CPU_RATE_CONTROL_INFORMATION"/> structure.
        /// </para>
        /// <para>
        /// Windows 7, Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:  This flag is not supported.
        /// </para>
        /// <para>
        /// If Dynamic Fair Share Scheduling (DFSS) is enabled, the CPU rate cannot be set and SetInformationJobObject will fail with error code 50 ("The request is not supported").
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JobObjectEndOfJobTimeInformation"/>
        /// </para>
        /// <para>
        /// 6
        /// </para>
        /// </term>
        /// <term>
        /// The <paramref name="lpJobObjectInfo"/> parameter is a pointer to a <see cref="JOBOBJECT_END_OF_JOB_TIME_INFORMATION"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JobObjectExtendedLimitInformation"/>
        /// </para>
        /// <para>
        /// 9
        /// </para>
        /// </term>
        /// <term>
        /// The <paramref name="lpJobObjectInfo"/> parameter is a pointer to a <see cref="JOBOBJECT_EXTENDED_LIMIT_INFORMATION"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JobObjectGroupInformation"/>
        /// </para>
        /// <para>
        /// 11
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpJobObjectInfo"/> parameter is a pointer to a <see cref="USHORT"/> value that specifies the list of processor groups to assign the job to. The <paramref name="cbJobObjectInfoLength"/> parameter is set to the size of the group data. Divide this value by <c>sizeof(USHORT)</c> to determine the number of groups.
        /// </para>
        /// <para>
        /// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:  This flag is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JobObjectGroupInformationEx"/>
        /// </para>
        /// <para>
        /// 14
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpJobObjectInfo"/> parameter is a pointer to a buffer that contains an array of <see cref="GROUP_AFFINITY"/> structures that specify the affinity of the job for the processor groups to which the job is currently assigned. The <paramref name="cbJobObjectInfoLength"/> parameter is set to the size of the group affinity data. Divide this value by <c>sizeof(GROUP_AFFINITY)</c> to determine the number of groups.
        /// </para>
        /// <para>
        /// Windows 7, Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:  This flag is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JobObjectLimitViolationInformation2"/>
        /// </para>
        /// <para>
        /// 34
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpJobObjectInfo"/> parameter is a pointer to a <see cref="JOBOBJECT_LIMIT_VIOLATION_INFORMATION_2"/> structure.
        /// </para>
        /// <para>
        /// Windows 8.1, Windows Server 2012 R2, Windows 8, Windows Server 2012, Windows 7, Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:  This flag is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JobObjectNetRateControlInformation"/>
        /// </para>
        /// <para>
        /// 32
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpJobObjectInfo"/> parameter is a pointer to a <see cref="JOBOBJECT_NET_RATE_CONTROL_INFORMATION"/> structure.
        /// </para>
        /// <para>
        /// Windows 8.1, Windows Server 2012 R2, Windows 8, Windows Server 2012, Windows 7, Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:  This flag is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JobObjectNotificationLimitInformation"/>
        /// </para>
        /// <para>
        /// 12
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpJobObjectInfo"/> parameter is a pointer to a <see cref="JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION"/> structure.
        /// </para>
        /// <para>
        /// Windows 7, Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:  This flag is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JobObjectNotificationLimitInformation2"/>
        /// </para>
        /// <para>
        /// 33
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpJobObjectInfo"/> parameter is a pointer to a <see cref="JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION_2"/> structure.
        /// </para>
        /// <para>
        /// Windows 8.1, Windows Server 2012 R2, Windows 8, Windows Server 2012, Windows 7, Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:  This flag is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="JobObjectSecurityLimitInformation"/>
        /// </para>
        /// <para>
        /// 5
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// This flag is not supported. Applications must set security limitations individually for each process.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP:  The <paramref name="lpJobObjectInfo"/> parameter is a pointer to a <see cref="JOBOBJECT_SECURITY_LIMIT_INFORMATION"/> structure. The <paramref name="hJob"/> handle must have the <see cref="JOB_OBJECT_SET_SECURITY_ATTRIBUTES"/> access right associated with it.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpJobObjectInformation">
        /// The limits or job state to be set for the job.
        /// The format of this data depends on the value of <paramref name="JobObjectInformationClass"/>.
        /// </param>
        /// <param name="cbJobObjectInformationLength">
        /// The size of the job information being set, in bytes.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Use the <see cref="SetInformationJobObject"/> function to set several limits in a single call.
        /// To establish the limits one at a time or change a subset of the limits,
        /// call the <see cref="QueryInformationJobObject"/> function to obtain the current limits,
        /// modify these limits, and then call <see cref="SetInformationJobObject"/>.
        /// </para>
        /// <para>
        /// You must set security limits individually for each process associated with a job object,
        /// rather than setting them for the job object itself.
        /// For information, see Process Security and Access Rights.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP:
        /// Use the <see cref="SetInformationJobObject"/> function to set security limits for the job object.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetInformationJobObject", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetInformationJobObject([In] HANDLE hJob, [In] JobObjectInformationClasses JobObjectInformationClass,
            [In] LPVOID lpJobObjectInformation, [In] DWORD cbJobObjectInformationLength);

        /// <summary>
        /// <para>
        /// Terminates all processes currently associated with the job.
        /// If the job is nested, this function terminates all processes currently associated with the job and all of its child jobs in the hierarchy.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/jobapi2/nf-jobapi2-terminatejobobject"/>
        /// </para>
        /// </summary>
        /// <param name="hJob">
        /// <para>
        /// A handle to the job whose processes will be terminated.
        /// The <see cref="CreateJobObject"/> or <see cref="OpenJobObject"/> function returns this handle.
        /// This handle must have the <see cref="JOB_OBJECT_TERMINATE"/> access right.
        /// For more information, see Job Object Security and Access Rights.
        /// </para>
        /// <para>
        /// The handle for each process in the job object must have the <see cref="PROCESS_TERMINATE"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </para>
        /// </param>
        /// <param name="uExitCode">
        /// The exit code to be used by all processes and threads in the job object.
        /// Use the <see cref="GetExitCodeProcess"/> function to retrieve each process's exit value.
        /// Use the <see cref="GetExitCodeThread"/> function to retrieve each thread's exit value.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// It is not possible for any of the processes associated with the job to postpone or handle the termination.
        /// It is as if <see cref="TerminateProcess"/> were called for each process associated with the job.
        /// </para>
        /// <para>
        /// Terminating a nested job additionally terminates all child job objects.
        /// Resources used by the terminated jobs are charged up the parent job chain in the hierarchy.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "TerminateJobObject", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL TerminateJobObject([In] HANDLE hJob, [In] UINT uExitCode);
    }
}
