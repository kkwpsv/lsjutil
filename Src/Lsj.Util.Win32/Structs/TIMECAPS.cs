using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="TIMECAPS"/> structure contains information about the resolution of the timer.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/timeapi/ns-timeapi-timecaps
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct TIMECAPS
    {
        /// <summary>
        /// The minimum supported resolution, in milliseconds.
        /// </summary>
        public UINT wPeriodMin;

        /// <summary>
        /// The maximum supported resolution, in milliseconds.
        /// </summary>
        public UINT wPeriodMax;
    }
}
