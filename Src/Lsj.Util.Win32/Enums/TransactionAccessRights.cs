using static Lsj.Util.Win32.Enums.StandardAccessRights;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Transaction Access Rights
    /// KTM defines the following transaction access masks to be used when opening a transaction.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/ktm/transaction-access-masks"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// It is recommended that resource managers, when enlisting in a transaction,
    /// specify <see cref="TRANSACTION_RESOURCE_MANAGER_RIGHTS"/> when opening a transaction.
    /// </remarks>
    public enum TransactionAccessRights : uint
    {
        /// <summary>
        /// The caller can query transaction information.
        /// </summary>
        TRANSACTION_QUERY_INFORMATION = 0x000001,

        /// <summary>
        /// The caller can set transaction information.
        /// </summary>
        TRANSACTION_SET_INFORMATION = 0x000002,

        /// <summary>
        /// The caller can enlist in this transaction.
        /// </summary>
        TRANSACTION_ENLIST = 0x000004,

        /// <summary>
        /// The caller can commit this transaction.
        /// </summary>
        TRANSACTION_COMMIT = 0x000008,

        /// <summary>
        /// The caller can roll back this transaction.
        /// </summary>
        TRANSACTION_ROLLBACK = 0x000010,

        /// <summary>
        /// The caller can propagate this transaction to a superior resource manager, such as the Distributed Transaction Coordinator (DTC).
        /// </summary>
        TRANSACTION_PROPAGATE = 0x000020,

        /// <summary>
        /// The caller has the following privileges: <see cref="STANDARD_RIGHTS_READ"/>,
        /// <see cref="TRANSACTION_QUERY_INFORMATION"/>, and <see cref="SYNCHRONIZE"/>.
        /// </summary>
        TRANSACTION_GENERIC_READ = STANDARD_RIGHTS_READ | TRANSACTION_QUERY_INFORMATION | SYNCHRONIZE,

        /// <summary>
        /// The caller has the following privileges: <see cref="STANDARD_RIGHTS_WRITE"/>, <see cref="TRANSACTION_SET_INFORMATION"/>,
        /// <see cref="TRANSACTION_COMMIT"/>, <see cref="TRANSACTION_ENLIST"/>, <see cref="TRANSACTION_ROLLBACK"/>,
        /// <see cref="TRANSACTION_PROPAGATE"/>, and <see cref="SYNCHRONIZE"/>.
        /// </summary>
        TRANSACTION_GENERIC_WRITE = STANDARD_RIGHTS_WRITE | TRANSACTION_SET_INFORMATION | TRANSACTION_COMMIT | TRANSACTION_ENLIST |
            TRANSACTION_ROLLBACK | TRANSACTION_PROPAGATE | SYNCHRONIZE,

        /// <summary>
        /// The caller has the following privileges: <see cref="STANDARD_RIGHTS_EXECUTE"/>, <see cref="TRANSACTION_COMMIT"/>,
        /// <see cref="TRANSACTION_ROLLBACK"/>, and <see cref="SYNCHRONIZE"/>.
        /// </summary>
        TRANSACTION_GENERIC_EXECUTE = STANDARD_RIGHTS_EXECUTE | TRANSACTION_COMMIT | TRANSACTION_ROLLBACK | SYNCHRONIZE,

        /// <summary>
        /// The caller has the following privilege: <see cref="STANDARD_RIGHTS_REQUIRED"/>, <see cref="TRANSACTION_GENERIC_READ"/>,
        /// <see cref="TRANSACTION_GENERIC_WRITE"/>, and <see cref="TRANSACTION_GENERIC_EXECUTE"/>.
        /// </summary>
        TRANSACTION_ALL_ACCESS = STANDARD_RIGHTS_REQUIRED | TRANSACTION_GENERIC_READ | TRANSACTION_GENERIC_WRITE | TRANSACTION_GENERIC_EXECUTE,

        /// <summary>
        /// The caller has the following privileges: <see cref="TRANSACTION_GENERIC_READ"/>, <see cref="STANDARD_RIGHTS_WRITE"/>,
        /// <see cref="TRANSACTION_SET_INFORMATION"/>, <see cref="TRANSACTION_ROLLBACK"/>, <see cref="TRANSACTION_ENLIST"/>,
        /// <see cref="TRANSACTION_PROPAGATE"/>, and <see cref="SYNCHRONIZE"/>.
        /// </summary>
        TRANSACTION_RESOURCE_MANAGER_RIGHTS = TRANSACTION_GENERIC_READ | STANDARD_RIGHTS_WRITE | TRANSACTION_SET_INFORMATION | TRANSACTION_ENLIST |
            TRANSACTION_ROLLBACK | TRANSACTION_PROPAGATE | SYNCHRONIZE,
    }
}
