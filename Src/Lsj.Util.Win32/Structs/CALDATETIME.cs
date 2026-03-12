using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Represents an instant in time, typically expressed as a date and time of day and a corresponding calendar.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/intl/caldatetime"/>
    /// </para>
    /// </summary>
    [Obsolete]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CALDATETIME
    {
        /// <summary>
        /// The calendar identifier for the instant in time.
        /// </summary>
        public CALID CalId;

        /// <summary>
        /// The era information for the instant in time.
        /// </summary>
        public UINT Era;

        /// <summary>
        /// The year for the instant in time.
        /// </summary>
        public UINT Year;

        /// <summary>
        /// The month for the instant in time.
        /// </summary>
        public UINT Month;

        /// <summary>
        /// The day for the instant in time.
        /// </summary>
        public UINT Day;

        /// <summary>
        /// The day of the week for the instant in time.
        /// </summary>
        public UINT DayOfWeek;

        /// <summary>
        /// The hour for the instant in time.
        /// </summary>
        public UINT Hour;

        /// <summary>
        /// The minute for the instant in time.
        /// </summary>
        public UINT Minute;

        /// <summary>
        /// The second for the instant in time.
        /// </summary>
        public UINT Second;

        /// <summary>
        /// The tick for the instant in time.
        /// </summary>
        public ULONG Tick;
    }
}
