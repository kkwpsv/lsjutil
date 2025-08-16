using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.SystemErrorLevels;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains the error that caused the RIP debug event.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/minwinbase/ns-minwinbase-rip_info"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct RIP_INFO
    {
        /// <summary>
        /// The error that caused the RIP debug event. For more information, see Error Handling.
        /// </summary>
        public DWORD dwError;

        /// <summary>
        /// <para>
        /// Any additional information about the type of error that caused the RIP debug event.
        /// This member can be one of the following values.
        /// </para>
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
        /// <see cref="SLE_ERROR"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that invalid data was passed to the function that failed. This caused the application to fail.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SLE_MINORERROR"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that invalid data was passed to the function, but the error probably will not cause the application to fail.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SLE_WARNING"/>
        /// </para>
        /// <para>
        /// 0x00000003
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that potentially invalid data was passed to the function, but the function completed processing.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 0
        /// </term>
        /// <term>
        /// Indicates that only <see cref="dwError"/> was set.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public SystemErrorLevels dwType;
    }
}
