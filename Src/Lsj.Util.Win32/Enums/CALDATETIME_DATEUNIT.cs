using Lsj.Util.Win32.Structs;
using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the date units for adjusting the <see cref="CALDATETIME"/> structure.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/intl/caldatetime-dateunit"/>
    /// </para>
    /// </summary>
    [Obsolete]
    public enum CALDATETIME_DATEUNIT
    {
        /// <summary>
        /// The era date time unit.
        /// </summary>
        EraUnit,

        /// <summary>
        /// The year date time unit.
        /// </summary>
        YearUnit,

        /// <summary>
        /// The month date time unit.
        /// </summary>
        MonthUnit,

        /// <summary>
        /// The week date time unit.
        /// </summary>
        WeekUnit,

        /// <summary>
        /// The day date time unit.
        /// </summary>
        DayUnit,

        /// <summary>
        /// The hour date time unit.
        /// </summary>
        HourUnit,

        /// <summary>
        /// The minute date time unit.
        /// </summary>
        MinuteUnit,

        /// <summary>
        /// The second date time unit.
        /// </summary>
        SecondUnit,

        /// <summary>
        /// The tick date time unit.
        /// </summary>
        TickUnit,
    }
}
