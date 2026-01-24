using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information that defines the format of a number string.
    /// The <see cref="GetNumberFormat"/> function uses this information to customize a number string for a specified locale.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnls/ns-winnls-numberfmtw"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct NUMBERFMT
    {
        /// <summary>
        /// Number of fractional digits.
        /// This value is equivalent to the locale information specified by the value <see cref="LOCALE_IDIGITS"/>.
        /// </summary>
        public UINT NumDigits;

        /// <summary>
        /// A value indicating if leading zeros should be used in decimal fields.
        /// This value is equivalent to the locale information specified by the value <see cref="LOCALE_ILZERO"/>.
        /// </summary>
        public UINT LeadingZero;

        /// <summary>
        /// <para>
        /// Number of digits in each group of numbers to the left of the decimal separator specified by <see cref="lpDecimalSep"/>.
        /// Values in the range 0 through 9 and 32 are valid.
        /// The most significant grouping digit indicates the number of digits in the least significant group
        /// immediately to the left of the decimal separator.
        /// Each subsequent grouping digit indicates the next significant group of digits to the left of the previous group.
        /// If the last value supplied is not 0, the remaining groups repeat the last group.
        /// Typical examples of settings for this member are: 0 to group digits as in 123456789.00;
        /// 3 to group digits as in 123,456,789.00; and 32 to group digits as in 12,34,56,789.00.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// You can use settings other than the typical settings,
        /// but they will not show up in the regional and language options portion of the Control Panel.
        /// Such settings are extremely uncommon and might have unexpected results.
        /// </para>
        /// </summary>
        public UINT Grouping;

        /// <summary>
        /// Pointer to a null-terminated decimal separator string.
        /// </summary>
        public IntPtr lpDecimalSep;

        /// <summary>
        /// Pointer to a null-terminated thousand separator string.
        /// </summary>
        public IntPtr lpThousandSep;

        /// <summary>
        /// Negative number mode.
        /// This mode is equivalent to the locale information specified by the value <see cref="LOCALE_INEGNUMBER"/>.
        /// </summary>
        public UINT NegativeOrder;
    }
}
