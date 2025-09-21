using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Avrt.dll
    /// </summary>
    public static class Avrt
    {
        /// <summary>
        /// <para>
        /// Indicates that a thread is no longer performing work associated with the specified task.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/avrt/nf-avrt-avrevertmmthreadcharacteristics"/>
        /// </para>
        /// </summary>
        /// <param name="AvrtHandle">
        /// A handle to the task.
        /// This handle is returned by the <see cref="AvSetMmThreadCharacteristics"/> or <see cref="AvSetMmMaxThreadCharacteristics"/> function.
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
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("Avrt.dll", CharSet = CharSet.Unicode, EntryPoint = "AvRevertMmThreadCharacteristics", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AvRevertMmThreadCharacteristics([In] HANDLE AvrtHandle);

        /// <summary>
        /// <para>
        /// Associates the calling thread with the specified task.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/avrt/nf-avrt-avsetmmthreadcharacteristicsw"/>
        /// </para>
        /// </summary>
        /// <param name="TaskName">
        /// The name of the task to be performed.
        /// This name must match the name of one of the subkeys of the following key
        /// HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks.
        /// </param>
        /// <param name="TaskIndex">
        /// The unique task identifier.
        /// The first time this function is called, this value must be 0 on input.
        /// The index value is returned on output and can be used as input in subsequent calls.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, it returns a handle to the task.
        /// </para>
        /// <para>
        /// If the function fails, it returns 0.
        /// To retrieve extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// The following are possible error codes.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_TASK_INDEX"/>
        /// </term>
        /// <term>
        /// Either <paramref name="TaskIndex"/> is not 0 on the first call or is not recognized value (on subsequent calls).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_TASK_NAME"/>
        /// </term>
        /// <term>
        /// The specified task does not match any of the tasks stored in the registry.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_PRIVILEGE_NOT_HELD"/>
        /// </term>
        /// <term>
        /// The caller does not have sufficient privilege.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// When the task is completed, call the <see cref="AvRevertMmThreadCharacteristics"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("Avrt.dll", CharSet = CharSet.Unicode, EntryPoint = "AvSetMmThreadCharacteristicsW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE AvSetMmThreadCharacteristics([In] LPCWSTR TaskName, [In][Out] ref DWORD TaskIndex);
    }
}
