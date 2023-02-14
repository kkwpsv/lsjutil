using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.SetLastErrorExTypes;

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
        /// Any additional information about the type of error that caused the RIP debug event.
        /// This member can be one of the following values.
        /// <see cref="SLE_ERROR"/>:
        /// Indicates that invalid data was passed to the function that failed.
        /// This caused the application to fail.
        /// <see cref="SLE_MINORERROR"/>:
        /// Indicates that invalid data was passed to the function, but the error probably will not cause the application to fail.
        /// <see cref="SLE_WARNING"/>:
        /// Indicates that potentially invalid data was passed to the function, but the function completed processing.
        /// 0:
        /// Indicates that only <see cref="dwError"/> was set.
        /// </summary>
        public SetLastErrorExTypes dwType;
    }
}
