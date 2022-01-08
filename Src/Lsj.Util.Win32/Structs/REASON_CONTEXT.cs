using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about a power request.
    /// This structure is used by the <see cref="PowerCreateRequest"/> and <see cref="SetWaitableTimerEx"/> functions.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/minwinbase/ns-minwinbase-reason_context"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// It is safe to pass read-only strings as the <see cref="SimpleReasonString"/> or <see cref="ReasonStrings"/>
    /// because the <see cref="PowerCreateRequest"/> and <see cref="SetWaitableTimerEx"/> functions read from the strings and do not write to them.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct REASON_CONTEXT
    {
        /// <summary>
        /// The version number of the structure.
        /// This parameter must be set to <see cref="POWER_REQUEST_CONTEXT_VERSION"/>.
        /// </summary>
        public ULONG Version;

        /// <summary>
        /// The format of the reason for the power request. This parameter can be one of the following values:
        /// <see cref="POWER_REQUEST_CONTEXT_DETAILED_STRING"/>:
        /// The <see cref="Detailed"/> structure identifies a localizable string resource that describes the reason for the power request.
        /// <see cref="POWER_REQUEST_CONTEXT_SIMPLE_STRING"/>:
        /// The <see cref="SimpleReasonString"/> parameter contains a simple, non-localizable string that describes the reason for the power request.
        /// </summary>
        public DWORD Flags;

        /// <summary>
        /// A union that consists of either a <see cref="REASON_CONTEXT_Detailed"/> structure or a string.
        /// </summary>
        public REASON_CONTEXT_Reason Reason;

        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
        public struct REASON_CONTEXT_Reason
        {
            /// <summary>
            /// A structure that identifies a localizable string resource to describe the reason for the power request.
            /// </summary>
            [FieldOffset(0)]
            public REASON_CONTEXT_Detailed Detailed;

            /// <summary>
            /// A non-localized string that describes the reason for the power request.
            /// </summary>
            [FieldOffset(0)]
            public LPWSTR SimpleReasonString;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct REASON_CONTEXT_Detailed
        {
            /// <summary>
            /// The module that contains the string resource.
            /// </summary>
            public HMODULE LocalizedReasonModule;

            /// <summary>
            /// The ID of the string resource.
            /// </summary>
            public ULONG LocalizedReasonId;

            /// <summary>
            /// The number of strings in the <see cref="ReasonStrings"/> parameter.
            /// </summary>
            public ULONG ReasonStringCount;

            /// <summary>
            /// An array of strings to be substituted in the string resource at run time.
            /// </summary>
            public IntPtr ReasonStrings;
        }
    }
}
