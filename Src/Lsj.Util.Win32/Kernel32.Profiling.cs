using Lsj.Util.IL;
using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.LCID;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.DEP_SYSTEM_POLICY_TYPE;
using static Lsj.Util.Win32.Enums.GetDateFormatFlags;
using static Lsj.Util.Win32.Enums.NTSTATUS;
using static Lsj.Util.Win32.Enums.PrivilegeConstants;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Shell32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// Disables thread profiling.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-disablethreadprofiling"/>
        /// </para>
        /// </summary>
        /// <param name="PerformanceDataHandle">
        /// The handle that the <see cref="EnableThreadProfiling"/> function returned.
        /// </param>
        /// <returns>
        /// Returns <see cref="ERROR_SUCCESS"/> if the call is successful; otherwise, a system error code (see Winerror.h).
        /// </returns>
        /// <remarks>
        /// You must call this function from the same thread that enabled profiling for the specified handle.
        /// You must call this function before exiting the thread;
        /// otherwise, you will leak resources (the resources are not reclaimed until the process exits).
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DisableThreadProfiling", ExactSpelling = true)]
        public static extern DWORD DisableThreadProfiling([In] HANDLE PerformanceDataHandle);

        /// <summary>
        /// <para>
        /// Enables thread profiling on the specified thread.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-enablethreadprofiling"/>
        /// </para>
        /// </summary>
        /// <param name="ThreadHandle">
        /// The handle to the thread on which you want to enable profiling.
        /// This must be the current thread.
        /// </param>
        /// <param name="Flags">
        /// To receive thread profiling data such as context switch count,
        /// set this parameter to <see cref="THREAD_PROFILING_FLAG_DISPATCH"/>; otherwise, set to 0.
        /// </param>
        /// <param name="HardwareCounters">
        /// To receive hardware performance counter data,
        /// set this parameter to a bitmask that identifies the hardware counters to collect.
        /// You can specify up to 16 performance counters.
        /// Each bit relates directly to the zero-based hardware counter index for the hardware performance counters that you configured.
        /// Set to zero if you are not collecting hardware counter data.
        /// If you set a bit for a hardware counter that has not been configured, the counter value that is read for that counter is zero.
        /// </param>
        /// <param name="PerformanceDataHandle">
        /// An opaque handle that you use when calling the <see cref="ReadThreadProfilingData"/> and <see cref="DisableThreadProfiling"/> functions.
        /// </param>
        /// <returns>
        /// Returns <see cref="ERROR_SUCCESS"/> if the call is successful; otherwise, a system error code (see Winerror.h).
        /// </returns>
        /// <remarks>
        /// <para>
        /// You must call the <see cref="DisableThreadProfiling"/> function before exiting the thread.
        /// </para>
        /// <para>
        /// To profile hardware performance counters, you need a driver to configure the counters.
        /// The performance counters are configured globally for the system, so every thread has access to the same hardware counter data.
        /// The counters must be configured before you enable profiling.
        /// For information on configuring hardware performance counters,
        /// see the <c>KeSetHardwareCounterConfiguration</c> function in the Windows Driver Kit (WDK).
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnableThreadProfiling", ExactSpelling = true)]
        public static extern DWORD EnableThreadProfiling([In] HANDLE ThreadHandle, [In] DWORD Flags,
            [In] DWORD64 HardwareCounters, [Out] out HANDLE PerformanceDataHandle);

        /// <summary>
        /// <para>
        /// Determines whether thread profiling is enabled for the specified thread.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-querythreadprofiling"/>
        /// </para>
        /// </summary>
        /// <param name="ThreadHandle">
        /// The handle to the thread of interest.
        /// </param>
        /// <param name="Enabled">
        /// Is <see cref="TRUE"/> if thread profiling is enabled for the specified thread; otherwise, <see cref="FALSE"/>.
        /// </param>
        /// <returns>
        /// Returns <see cref="ERROR_SUCCESS"/> if the call is successful; otherwise, a system error code (see Winerror.h).
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "QueryThreadProfiling", ExactSpelling = true)]
        public static extern DWORD QueryThreadProfiling([In] HANDLE ThreadHandle, [Out] out BOOLEAN Enabled);

        /// <summary>
        /// <para>
        /// Reads the specified profiling data associated with the thread.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-readthreadprofilingdata"/>
        /// </para>
        /// </summary>
        /// <param name="PerformanceDataHandle">
        /// The handle that the <see cref="EnableThreadProfiling"/> function returned.
        /// </param>
        /// <param name="Flags">
        /// <para>
        /// One or more of the following flags that specify the counter data to read.
        /// The flags must have been set when you called the <see cref="EnableThreadProfiling"/> function.
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
        /// <see cref="READ_THREAD_PROFILING_FLAG_DISPATCHING"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// Get the thread profiling data.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="READ_THREAD_PROFILING_FLAG_HARDWARE_COUNTERS"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// Get the hardware performance counters data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="PerformanceData">
        /// A <see cref="PERFORMANCE_DATA"/> structure that contains the thread profiling and hardware counter data.
        /// </param>
        /// <returns>
        /// Returns <see cref="ERROR_SUCCESS"/> if the call is successful; otherwise, a system error code (see Winerror.h).
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows7)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ReadThreadProfilingData", ExactSpelling = true)]
        public static extern DWORD ReadThreadProfilingData([In] HANDLE PerformanceDataHandle, [In] DWORD Flags, [Out] out PERFORMANCE_DATA PerformanceData);
    }
}
