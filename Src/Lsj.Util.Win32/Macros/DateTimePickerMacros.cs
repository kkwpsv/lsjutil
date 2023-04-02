using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.DateTimePickerMessages;
using static Lsj.Util.Win32.Enums.DateTimePickerNotifications;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Macros
{
    /// <summary>
    /// <para>
    /// Date and Time Picker Macros
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/controls/bumper-date-and-time-picker-control-reference-macros"/>
    /// </para>
    /// </summary>
    public static class DateTimePickerMacros
    {
        /// <summary>
        /// Closes the date and time picker (DTP) control.
        /// Use this macro or send the <see cref="DTM_CLOSEMONTHCAL"/> message explicitly.
        /// </summary>
        /// <param name="hdp">
        /// A handle to the DTP control.
        /// </param>
        /// <remarks>
        /// Destroys the control and sends a <see cref="DTN_CLOSEUP"/> notification that the control is closing—as opposed to the control is opening
        /// (dropping-down as in the <see cref="DTN_DROPDOWN"/> notification)—to the control's parent.
        /// </remarks>
        public static LRESULT DateTime_CloseMonthCal([In] HWND hdp) => SendMessage(hdp, (WindowMessages)DTM_CLOSEMONTHCAL, 0, 0);

        /// <summary>
        /// Gets the size needed to display the control without clipping.
        /// Use this macro or send the <see cref="DTM_GETIDEALSIZE"/> message explicitly.
        /// </summary>
        /// <param name="hdp">
        /// A handle to the DTP control.
        /// </param>
        /// <param name="psize">
        /// A pointer to a <see cref="SIZE"/> structure to receive the size.
        /// The caller is responsible for allocating this structure.
        /// </param>
        public static BOOL DateTime_GetIdealSize([In] HWND hdp, [Out] out SIZE psize)
        {
            psize = default(SIZE);
            return (BOOL)SendMessage(hdp, (WindowMessages)DTM_GETIDEALSIZE, 0, UnsafePInvokeExtensions.AsPointer(ref psize)).SafeToInt32();
        }


    }
}
