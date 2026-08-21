using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
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
        /// <para>
        /// Closes the date and time picker (DTP) control. Use this macro or send the <see cref="DTM_CLOSEMONTHCAL"/> message explicitly.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commctrl/nf-commctrl-datetime_closemonthcal"/>
        /// </para>
        /// </summary>
        /// <param name="hdp">
        /// A handle to the DTP control.
        /// </param>
        /// <returns>
        /// Returns zero.
        /// </returns>
        /// <remarks>
        /// Destroys the control and sends a <see cref="DTN_CLOSEUP"/> notification that the control is closing—as opposed to the control is opening
        /// (dropping-down as in the <see cref="DTN_DROPDOWN"/> notification)—to the control's parent.
        /// </remarks>
        public static LRESULT DateTime_CloseMonthCal([In] HWND hdp) => SendMessage(hdp, (WindowMessages)DTM_CLOSEMONTHCAL, 0, 0);

        /// <summary>
        /// <para>
        /// Gets the size needed to display the control without clipping. Use this macro or send the <see cref="DTM_GETIDEALSIZE"/> message explicitly.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commctrl/nf-commctrl-datetime_getidealsize"/>
        /// </para>
        /// </summary>
        /// <param name="hdp">
        /// A handle to the DTP control.
        /// </param>
        /// <param name="psize">
        /// A pointer to a <see cref="SIZE"/> structure to receive the size.
        /// The caller is responsible for allocating this structure.
        /// </param>
        public static unsafe BOOL DateTime_GetIdealSize([In] HWND hdp, [Out] out SIZE psize)
        {
            var size = new SIZE();
            var result = SendMessage(hdp, (WindowMessages)DTM_GETIDEALSIZE, 0, (nint)(&size));
            psize = size;
            return result != 0;
        }
    }
}
