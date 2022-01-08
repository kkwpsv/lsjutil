using System;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="GetTimeFormat"/> Flags
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/datetimeapi/nf-datetimeapi-gettimeformatex"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum GetTimeFormatFlags : uint
    {
        /// <summary>
        /// Do not use minutes or seconds.
        /// </summary>
        TIME_NOMINUTESORSECONDS = 0x00000001,

        /// <summary>
        /// Do not use seconds.
        /// </summary>
        TIME_NOSECONDS = 0x00000002,

        /// <summary>
        /// Do not use a time marker.
        /// </summary>
        TIME_NOTIMEMARKER = 0x00000004,

        /// <summary>
        /// Always use a 24-hour time format.
        /// </summary>
        TIME_FORCE24HOURFORMAT = 0x00000008,
    }
}
