using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information that defines the format of a currency string.
    /// The <see cref="GetCurrencyFormat"/> function uses this information to customize a currency string for a specified locale.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnls/ns-winnls-currencyfmtw"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CURRENCYFMT
    {
        /// <summary>
        /// Number of fractional digits.
        /// This number is equivalent to <see cref="LOCALE_ICURRDIGITS"/>.
        /// </summary>
        public UINT NumDigits;

        /// <summary>
        /// Value indicating if leading zeros should be used in decimal fields.
        /// This value is equivalent to <see cref="LOCALE_ILZERO"/>.
        /// </summary>
        public UINT LeadingZero;

        /// <summary>
        /// <para>
        /// Number of digits in each group of numbers to the left of the decimal separator specified by <see cref="lpDecimalSep"/>.
        /// The most significant grouping digit indicates the number of digits in the least significant group immediately to the left of the decimal separator.
        /// Each subsequent grouping digit indicates the next significant group of digits to the left of the previous group.
        /// If the last value supplied is not 0, the remaining groups repeat the last group.
        /// Typical examples of settings for this member are:
        /// 0 to group digits as in 123456789.00;
        /// 3 to group digits as in 123,456,789.00; and 32 to group digits as in 12,34,56,789.00.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// You can use settings other than the typical settings,
        /// but they will not show up in the regional and language settings portion of the Control Panel.
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
        /// Negative currency mode.
        /// This mode is equivalent to <see cref="LOCALE_INEGCURR"/>.
        /// </summary>
        public UINT NegativeOrder;

        /// <summary>
        /// Positive currency mode.
        /// This mode is equivalent to <see cref="LOCALE_INEGCURR"/>.
        /// </summary>
        public UINT PositiveOrder;

        /// <summary>
        /// Pointer to a null-terminated currency symbol string.
        /// </summary>
        public IntPtr lpCurrencySymbol;
    }
}
