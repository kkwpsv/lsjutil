using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.TransactionAccessRights;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Ktmw32.dll
    /// </summary>
    public static class Ktmw32
    {
        /// <summary>
        /// TRANSACTION_DO_NOT_PROMOTE
        /// </summary>
        public const uint TRANSACTION_DO_NOT_PROMOTE = 0x00000001;

        /// <summary>
        /// <para>
        /// Requests that the specified transaction be committed.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/ktmw32/nf-ktmw32-committransaction"/>
        /// </para>
        /// </summary>
        /// <param name="TransactionHandle">
        /// A handle to the transaction to be committed.
        /// This handle must have been opened with the <see cref="TRANSACTION_COMMIT"/> access right.
        /// For more information, see KTM Security and Access Rights.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call the <see cref="GetLastError"/> function.
        /// </returns>
        /// <remarks>
        /// You can commit any transaction handle that has been opened or created using the <see cref="TRANSACTION_COMMIT"/> permission;
        /// any application can commit a transaction, not just the creator.
        /// This function can only be called if the transaction is still active, not prepared, pre-prepared, or rolled back.
        /// </remarks>
        [DllImport("Ktmw32.dll", CharSet = CharSet.Unicode, EntryPoint = "CommitTransaction", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CommitTransaction([In] HANDLE TransactionHandle);

        /// <summary>
        /// <para>
        /// Creates a new transaction object.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/ktmw32/nf-ktmw32-createtransaction"/>
        /// </para>
        /// </summary>
        /// <param name="lpTransactionAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that determines whether the returned handle can be inherited by child processes.
        /// If this parameter is <see langword="null"/>, the handle cannot be inherited.
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the new event.
        /// If <paramref name="lpTransactionAttributes"/> is <see langword="null"/>, the object gets a default security descriptor.
        /// The access control lists (ACL) in the default security descriptor for a transaction come from the primary or impersonation token of the creator.
        /// </param>
        /// <param name="UOW">
        /// Reserved. Must be <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <param name="CreateOptions">
        /// Any optional transaction instructions.
        /// <see cref="TRANSACTION_DO_NOT_PROMOTE"/>: The transaction cannot be distributed.
        /// </param>
        /// <param name="IsolationLevel">
        /// Reserved; specify zero (0).
        /// </param>
        /// <param name="IsolationFlags">
        /// Reserved; specify zero (0).
        /// </param>
        /// <param name="Timeout">
        /// The time-out interval, in milliseconds.
        /// If a nonzero value is specified, the transaction will be aborted when the interval elapses if it has not already reached the prepared state.
        /// Specify zero (0) or <see cref="Constants.INFINITE"/> to provide an infinite time-out.
        /// </param>
        /// <param name="Description">
        /// A user-readable description of the transaction.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the transaction.
        /// If the function fails, the return value is <see cref="Constants.INVALID_HANDLE_VALUE"/>.
        /// To get extended error information, call the <see cref="GetLastError"/> function.
        /// </returns>
        /// <remarks>
        /// Use the <see cref="CloseHandle"/> function to close the transaction handle.
        /// If the last transaction handle is closed before a client calls the <see cref="CommitTransaction"/> function with the transaction handle,
        /// then KTM rolls back the transaction.
        /// If the transaction might need to be promotable to a distributed transaction,
        /// then you must grant the Distributed Transaction Coordinator (DTC) access rights to enlist in the transaction.
        /// To do this, the <paramref name="lpTransactionAttributes"/> parameter needs to contain an access control entry
        /// with the DTC’s SID (S-1-5-80-2818357584-3387065753-4000393942-342927828-138088443) and the <see cref="TRANSACTION_ENLIST"/> right.
        /// For more information, see Distributed Transaction Coordinator and Access Control Components.
        /// </remarks>
        [DllImport("Ktmw32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateTransaction", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE CreateTransaction([In] in SECURITY_ATTRIBUTES lpTransactionAttributes, [In] in GUID UOW,
            [In] DWORD CreateOptions, [In] DWORD IsolationLevel, [In] DWORD IsolationFlags, [In] DWORD Timeout,
            [MarshalAs(UnmanagedType.LPWStr)][In] string Description);
    }
}
