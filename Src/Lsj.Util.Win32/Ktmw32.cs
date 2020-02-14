using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Ktmw32.dll
    /// </summary>
    public static class Ktmw32
    {
        /// <summary>
        /// <para>
        /// Requests that the specified transaction be committed.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/ktmw32/nf-ktmw32-committransaction
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
        /// To get extended error information, call the <see cref="Marshal.GetLastWin32Error"/> function.
        /// </returns>
        /// <remarks>
        /// You can commit any transaction handle that has been opened or created using the <see cref="TRANSACTION_COMMIT"/> permission;
        /// any application can commit a transaction, not just the creator.
        /// This function can only be called if the transaction is still active, not prepared, pre-prepared, or rolled back.
        /// </remarks>
        [DllImport("Ktmw32.dll", CharSet = CharSet.Unicode, EntryPoint = "CommitTransaction", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CommitTransaction([In]IntPtr TransactionHandle);
    }
}
