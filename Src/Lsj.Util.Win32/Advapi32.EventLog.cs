using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.PrivilegeConstants;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32
{
    public static partial class Advapi32
    {
        /// <summary>
        /// <para>
        /// Saves the specified event log to a backup file.
        /// The function does not clear the event log.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-backupeventlogw"/>
        /// </para>
        /// </summary>
        /// <param name="hEventLog">
        /// A handle to the open event log.
        /// The <see cref="OpenEventLog"/> function returns this handle.
        /// </param>
        /// <param name="lpBackupFileName">
        /// The absolute or relative path of the backup file.
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
        /// The <see cref="BackupEventLog"/> function fails with the <see cref="ERROR_PRIVILEGE_NOT_HELD"/> error
        /// if the user does not have the <see cref="SE_BACKUP_NAME"/> privilege.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "BackupEventLogW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL BackupEventLog([In] HANDLE hEventLog, [In] LPCWSTR lpBackupFileName);

        /// <summary>
        /// <para>
        /// Clears the specified event log, and optionally saves the current copy of the log to a backup file.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-cleareventlogw"/>
        /// </para>
        /// </summary>
        /// <param name="hEventLog">
        /// A handle to the event log to be cleared.
        /// The <see cref="OpenEventLog"/> function returns this handle.
        /// </param>
        /// <param name="lpBackupFileName">
        /// <para>
        /// The absolute or relative path of the backup file.
        /// If this file already exists, the function fails.
        /// </para>
        /// <para>
        /// If the <paramref name="lpBackupFileName"/> parameter is <see cref="NULL"/>, the event log is not backed up.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// The <see cref="ClearEventLog"/> function can fail if the event log is empty or the backup file already exists.
        /// </para>
        /// </returns>
        /// <remarks>
        /// After this function returns, any handles that reference the cleared event log cannot be used to read the log.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ClearEventLogW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ClearEventLogW([In] HANDLE hEventLog, [In] LPCWSTR lpBackupFileName);

        /// <summary>
        /// <para>
        /// Closes the specified event log.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-closeeventlog"/>
        /// </para>
        /// </summary>
        /// <param name="hEventLog">
        /// A handle to the event log to be closed.
        /// The <see cref="OpenEventLog"/> or <see cref="OpenBackupEventLog"/> function returns this handle.
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
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseEventLog", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CloseEventLog([In] HANDLE hEventLog);

        /// <summary>
        /// <para>
        /// Closes the specified event log.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-deregistereventsource"/>
        /// </para>
        /// </summary>
        /// <param name="hEventLog">
        /// A handle to the event log.
        /// The <see cref="RegisterEventSource"/> function returns this handle.
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
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeregisterEventSource", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DeregisterEventSource([In] HANDLE hEventLog);

        /// <summary>
        /// <para>
        /// Retrieves the number of records in the specified event log.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getnumberofeventlogrecords"/>
        /// </para>
        /// </summary>
        /// <param name="hEventLog">
        /// A handle to the open event log.
        /// The <see cref="OpenEventLog"/> or <see cref="OpenBackupEventLog"/> function returns this handle.
        /// </param>
        /// <param name="NumberOfRecords">
        /// A pointer to a variable that receives the number of records in the specified event log.
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
        /// The oldest record in an event log is not necessarily record number 1.
        /// To determine the oldest record number in an event log, use the <see cref="GetOldestEventLogRecord"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetNumberOfEventLogRecords", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetNumberOfEventLogRecords([In] HANDLE hEventLog, [Out] out DWORD NumberOfRecords);

        /// <summary>
        /// <para>
        /// Retrieves the absolute record number of the oldest record in the specified event log.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getoldesteventlogrecord"/>
        /// </para>
        /// </summary>
        /// <param name="hEventLog">
        /// A handle to the open event log.
        /// The <see cref="OpenEventLog"/> or <see cref="OpenBackupEventLog"/> function returns this handle.
        /// </param>
        /// <param name="NumberOfRecords">
        /// A pointer to a variable that receives the absolute record number of the oldest record in the specified event log.
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
        /// The oldest record in an event log is not necessarily record number 1.
        /// For more information, see Event Log Records.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetOldestEventLogRecord", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetOldestEventLogRecord([In] HANDLE hEventLog, [Out] out DWORD NumberOfRecords);

        /// <summary>
        /// <para>
        /// Enables an application to receive notification when an event is written to the specified event log.
        /// When the event is written to the log, the specified event object is set to the signaled state.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-notifychangeeventlog"/>
        /// </para>
        /// </summary>
        /// <param name="hEventLog">
        /// A handle to an event log.
        /// The <see cref="OpenEventLog"/> function returns this handle.
        /// </param>
        /// <param name="hEvent">
        /// A handle to a manual-reset or auto-reset event object.
        /// Use the <see cref="CreateEvent"/> function to create the event object.
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
        /// The <see cref="NotifyChangeEventLog"/> function does not work with remote handles.
        /// If the <paramref name="hEventLog"/> parameter is the handle to an event log on a remote computer,
        /// <see cref="NotifyChangeEventLog"/> returns zero, and <see cref="GetLastError"/> returns <see cref="ERROR_INVALID_HANDLE"/>.
        /// </para>
        /// <para>
        /// If the thread is not waiting on the event when the system calls <see cref="PulseEvent"/>,
        /// the thread will not receive the notification.
        /// Therefore, you should create a separate thread to wait for notifications.
        /// </para>
        /// <para>
        /// The system will continue to notify you of changes until you close the handle to the event log.
        /// To close the event log, use the <see cref="CloseEventLog"/> or <see cref="DeregisterEventSource"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "NotifyChangeEventLog", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL NotifyChangeEventLog([In] HANDLE hEventLog, [In] HANDLE hEvent);

        /// <summary>
        /// <para>
        /// Opens a handle to a backup event log created by the <see cref="BackupEventLog"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-openbackupeventlogw"/>
        /// </para>
        /// </summary>
        /// <param name="lpUNCServerName">
        /// The Universal Naming Convention (UNC) name of the remote server on which this operation is to be performed.
        /// If this parameter is <see cref="NULL"/>, the local computer is used.
        /// </param>
        /// <param name="lpFileName">
        /// The full path of the backup file.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the backup event log.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the backup filename specifies a remote server,
        /// the <paramref name="lpUNCServerName"/> parameter must be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// When this function is used on Windows Vista and later computers, only backup event logs
        /// that were saved with the <see cref="BackupEventLog"/> function on Windows Vista and later computers can be opened.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "OpenBackupEventLogW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE OpenBackupEventLog([In] LPCWSTR lpUNCServerName, [In] LPCWSTR lpFileName);

        /// <summary>
        /// <para>
        /// Opens a handle to the specified event log.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-openeventlogw"/>
        /// </para>
        /// </summary>
        /// <param name="lpUNCServerName">
        /// The Universal Naming Convention (UNC) name of the remote server on which the event log is to be opened.
        /// If this parameter is <see cref="NULL"/>, the local computer is used.
        /// </param>
        /// <param name="lpSourceName">
        /// <para>
        /// The name of the log.
        /// </para>
        /// <para>
        /// If you specify a custom log and it cannot be found, the event logging service opens the <c>Application</c> log;
        /// however, there will be no associated message or category string file.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the handle to an event log.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// To close the handle to the event log, use the <see cref="CloseEventLog"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "OpenEventLogW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE OpenEventLog([In] LPCWSTR lpUNCServerName, [In] LPCWSTR lpSourceName);

        /// <summary>
        /// <para>
        /// Reads the specified number of entries from the specified event log.
        /// The function can be used to read log entries in chronological or reverse chronological order.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-readeventlogw"/>
        /// </para>
        /// </summary>
        /// <param name="hEventLog">
        /// A handle to the event log to be read.
        /// The <see cref="OpenEventLog"/> function returns this handle.
        /// </param>
        /// <param name="dwReadFlags">
        /// <para>
        /// Use the following flag values to indicate how to read the log file.
        /// This parameter must include one of the following values (the flags are mutually exclusive).
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
        /// <see cref="EVENTLOG_SEEK_READ"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Begin reading from the record specified in the <paramref name="dwRecordOffset"/> parameter.
        /// </para>
        /// <para>
        /// This option may not work with large log files if the function cannot determine the log file's size.
        /// For details, see Knowledge Base article, 177199.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EVENTLOG_SEQUENTIAL_READ"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Read the records sequentially.
        /// </para>
        /// <para>
        /// If this is the first read operation,
        /// the <see cref="EVENTLOG_FORWARDS_READ"/> <see cref="EVENTLOG_BACKWARDS_READ"/> flags determines which record is read first.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// You must specify one of the following flags to indicate the direction for successive read operations
        /// (the flags are mutually exclusive).
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
        /// <see cref="EVENTLOG_FORWARDS_READ"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The log is read in chronological order (oldest to newest).
        /// </para>
        /// <para>
        /// The default.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EVENTLOG_BACKWARDS_READ"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// The log is read in reverse chronological order (newest to oldest).
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="dwRecordOffset">
        /// The record number of the log-entry at which the read operation should start.
        /// This parameter is ignored unless <paramref name="dwReadFlags"/> includes the <see cref="EVENTLOG_SEEK_READ"/> flag.
        /// </param>
        /// <param name="lpBuffer">
        /// <para>
        /// An application-allocated buffer that will receive one or more <see cref="EVENTLOGRECORD"/> structures.
        /// This parameter cannot be <see cref="NULL"/>, even if the <paramref name="nNumberOfBytesToRead"/> parameter is zero.
        /// </para>
        /// <para>
        /// The maximum size of this buffer is 0x7ffff bytes.
        /// </para>
        /// </param>
        /// <param name="nNumberOfBytesToRead">
        /// The size of the <paramref name="lpBuffer"/> buffer, in bytes.
        /// This function will read as many log entries as will fit in the buffer;
        /// the function will not return partial entries.
        /// </param>
        /// <param name="pnBytesRead">
        /// A pointer to a variable that receives the number of bytes read by the function.
        /// </param>
        /// <param name="pnMinNumberOfBytesNeeded">
        /// A pointer to a variable that receives the required size of the <paramref name="lpBuffer"/> buffer.
        /// This value is valid only this function returns zero
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_INSUFFICIENT_BUFFER"/>.
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
        /// When this function returns successfully, the read position in the event log is adjusted by the number of records read.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// The configured file name for this source may also be the configured file name for other sources
        /// (several sources can exist as subkeys under a single log).
        /// Therefore, this function may return events that were logged by more than one source.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ReadEventLogW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE ReadEventLog([In] HANDLE hEventLog, [In] DWORD dwReadFlags, [In] DWORD dwRecordOffset,
            [In] LPVOID lpBuffer, [In] DWORD nNumberOfBytesToRead, [Out] out DWORD pnBytesRead, [Out] out DWORD pnMinNumberOfBytesNeeded);

        /// <summary>
        /// <para>
        /// Retrieves a registered handle to the specified event log.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-registereventsourcew"/>
        /// </para>
        /// </summary>
        /// <param name="lpUNCServerName">
        /// The Universal Naming Convention (UNC) name of the remote server on which this operation is to be performed.
        /// If this parameter is <see cref="NULL"/>, the local computer is used.
        /// </param>
        /// <param name="lpSourceName">
        /// <para>
        /// The name of the event source whose handle is to be retrieved.
        /// The source name must be a subkey of a log under the <c>Eventlog</c> registry key.
        /// Note that the <c>Security</c> log is for system use only.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This string must not contain characters prohibited in XML Attributes,
        /// with the exception of XML Escape sequences such as <c>&amp;lt;</c> or <c>&amp;gt;</c>.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the event log.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// The function returns <see cref="ERROR_ACCESS_DENIED"/>
        /// if <paramref name="lpSourceName"/> specifies the <c>Security</c> event log.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the source name cannot be found, the event logging service uses the <c>Application</c> log.
        /// Although events will be reported , the events will not include descriptions
        /// because there are no message and category message files for looking up descriptions related to the event identifiers.
        /// </para>
        /// <para>
        /// To close the handle to the event log, use the <see cref="DeregisterEventSource"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegisterEventSourceW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE RegisterEventSource([In] LPCWSTR lpUNCServerName, [In] LPCWSTR lpSourceName);

        /// <summary>
        /// <para>
        /// Writes an entry at the end of the specified event log.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-reporteventw"/>
        /// </para>
        /// </summary>
        /// <param name="hEventLog">
        /// <para>
        /// A handle to the event log. The <see cref="RegisterEventSource"/> function returns this handle.
        /// </para>
        /// <para>
        /// As of Windows XP with SP2, this parameter cannot be a handle to the <c>Security</c> log.
        /// To write an event to the <c>Security</c> log, use the <see cref="AuthzReportSecurityEvent"/> function.
        /// </para>
        /// </param>
        /// <param name="wType">
        /// <para>
        /// The type of event to be logged.
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
        /// <see cref="EVENTLOG_SUCCESS"/>
        /// </para>
        /// <para>
        /// 0x0000
        /// </para>
        /// </term>
        /// <term>
        /// Information event
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EVENTLOG_AUDIT_FAILURE"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// Failure Audit event
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EVENTLOG_AUDIT_SUCCESS"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// Success Audit event
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EVENTLOG_ERROR_TYPE"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// Error event
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EVENTLOG_INFORMATION_TYPE"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// Information event
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EVENTLOG_WARNING_TYPE"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// Warning event
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// For more information about event types, see Event Types.
        /// </para>
        /// </param>
        /// <param name="wCategory">
        /// The event category.
        /// This is source-specific information; the category can have any value.
        /// For more information, see Event Categories.
        /// </param>
        /// <param name="dwEventID">
        /// The event identifier.
        /// The event identifier specifies the entry in the message file associated with the event source.
        /// For more information, see Event Identifiers.
        /// </param>
        /// <param name="lpUserSid">
        /// A pointer to the current user's security identifier.
        /// This parameter can be <see cref="NULL"/> if the security identifier is not required.
        /// </param>
        /// <param name="wNumStrings">
        /// The number of insert strings in the array pointed to by the <paramref name="lpStrings"/> parameter.
        /// A value of zero indicates that no strings are present.
        /// </param>
        /// <param name="dwDataSize">
        /// The number of bytes of event-specific raw (binary) data to write to the log.
        /// If this parameter is zero, no event-specific data is present.
        /// </param>
        /// <param name="lpStrings">
        /// <para>
        /// A pointer to a buffer containing an array of null-terminated strings
        /// that are merged into the message before Event Viewer displays the string to the user.
        /// This parameter must be a valid pointer (or <see langword="null"/>), even if <paramref name="wNumStrings"/> is zero.
        /// Each string is limited to 31,839 characters.
        /// </para>
        /// <para>
        /// Prior to Windows Vista:  Each string is limited to 32K characters.
        /// </para>
        /// </param>
        /// <param name="lpRawData">
        /// A pointer to the buffer containing the binary data.
        /// This parameter must be a valid pointer (or <see cref="NULL"/>),
        /// even if the <paramref name="dwDataSize"/> parameter is zero.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero, indicating that the entry was written to the log.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>,
        /// which returns one of the following extended error codes.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Error code
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_PARAMETER"/>
        /// </term>
        /// <term>
        /// <para>
        /// One of the parameters is not valid.
        /// </para>
        /// <para>
        /// This error is returned on Windows Server 2003 if the message data to be logged is too large.
        /// This error is returned by the RPC server on Windows Server 2003
        /// if the <paramref name="dwDataSize"/> parameter is larger than 261,991 (0x3ff67).
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_NOT_ENOUGH_MEMORY"/>
        /// </term>
        /// <term>
        /// Insufficient memory resources are available to complete the operation.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RPC_S_INVALID_BOUND"/>
        /// </term>
        /// <term>
        /// <para>
        /// The array bounds are invalid.
        /// </para>
        /// <para>
        /// This error is returned if the message data to be logged is too large.
        /// On Windows Vista and later, this error is returned
        /// if the <paramref name="dwDataSize"/> parameter is larger than 61,440 (0xf000).
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RPC_X_BAD_STUB_DATA"/>
        /// </term>
        /// <term>
        /// <para>
        /// The stub received bad data.
        /// </para>
        /// <para>
        /// This error is returned on Windows XP if the message data to be logged is too large.
        /// This error is returned by the RPC server on Windows XP,
        /// if the <paramref name="dwDataSize"/> parameter is larger than 262,143 (0x3ffff).
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="Other"/>
        /// </term>
        /// <term>
        /// Use <see cref="FormatMessage"/> to obtain the message string for the returned error.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function is used to log an event.
        /// The entry is written to the end of the configured log
        /// for the source identified by the <paramref name="hEventLog"/> parameter.
        /// The <see cref="ReportEvent"/> function adds the time, the entry's length,
        /// and the offsets before storing the entry in the log.
        /// To enable the function to add the user name,
        /// you must supply the user's SID in the <paramref name="lpUserSid"/> parameter.
        /// </para>
        /// <para>
        /// There are different size limits on the size of the message data that can be logged
        /// depending on the version of Windows used by both the client
        /// where the application is run and the server where the message is logged.
        /// The server is determined by the <c>lpUNCServerName</c> parameter
        /// passed to the <see cref="RegisterEventSource"/> function.
        /// Different errors are returned when the size limit is exceeded that depend on the version of Windows.
        /// </para>
        /// <para>
        /// If the string that you log contains <c>%n</c>,
        /// where <c>n</c> is an integer value (for example, %1),
        /// the event viewer treats it as an insertion string.
        /// Because an IPv6 address can contain this character sequence,
        /// you must provide a format specifier (<c>!S!</c>) to log an event message that contains an IPv6 address.
        /// This specifier tells the formatting code to use the string literally
        /// and not perform any further expansions (for example, "my IPv6 address is: %1!S!").
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ReportEventW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE ReportEvent([In] HANDLE hEventLog, [In] WORD wType, [In] WORD wCategory, [In] DWORD dwEventID,
            [In] PSID lpUserSid, [In] WORD wNumStrings, [In] DWORD dwDataSize, [In] LPCWSTR[]? lpStrings, [In] LPVOID lpRawData);
    }
}
