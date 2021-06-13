using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Specifies attributes for a user-mode scheduling (UMS) worker thread.
    /// This structure is used with the <see cref="UpdateProcThreadAttribute"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-ums_create_thread_attributes"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct UMS_CREATE_THREAD_ATTRIBUTES
    {
        /// <summary>
        /// UMS_VERSION
        /// </summary>
        public const uint UMS_VERSION = 0x0100;

        /// <summary>
        /// The UMS version for which the application was built. This parameter must be <see cref="UMS_VERSION"/>.
        /// </summary>
        public DWORD UmsVersion;

        /// <summary>
        /// A pointer to a UMS thread context for the worker thread to be created.
        /// This pointer is provided by the <see cref="CreateUmsThreadContext"/> function.
        /// </summary>
        public PVOID UmsContext;

        /// <summary>
        /// A pointer to a UMS completion list.
        /// This pointer is provided by the <see cref="CreateUmsCompletionList"/> function.
        /// The newly created worker thread is queued to the specified completion list.
        /// </summary>
        public PVOID UmsCompletionList;
    }
}
