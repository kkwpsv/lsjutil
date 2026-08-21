using Lsj.Util.Win32.Callbacks;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Specifies the <c>ServiceMain</c> function for a service that can run in the calling process.
    /// It is used by the <see cref="StartServiceCtrlDispatcher"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/ns-winsvc-service_table_entryw"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SERVICE_TABLE_ENTRY
    {
        /// <summary>
        /// <para>
        /// The name of a service to be run in this service process.
        /// </para>
        /// <para>
        /// If the service is installed with the <see cref="SERVICE_WIN32_OWN_PROCESS"/> service type,
        /// this member is ignored, but cannot be <see cref="NULL"/>.
        /// This member can be an empty string ("").
        /// </para>
        /// <para>
        /// If the service is installed with the <see cref="SERVICE_WIN32_SHARE_PROCESS"/> service type,
        /// this member specifies the name of the service that uses the <c>ServiceMain</c> function
        /// pointed to by the <see cref="lpServiceProc"/> member.
        /// </para>
        /// </summary>
        public nint lpServiceName;

        /// <summary>
        /// A pointer to a <c>ServiceMain</c> function.
        /// </summary>
        public LPSERVICE_MAIN_FUNCTION lpServiceProc;
    }
}
