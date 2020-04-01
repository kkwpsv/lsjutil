using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32
{
    public partial class Gdi32
    {
        /// <summary>
        /// <para>
        /// The <see cref="StartDoc"/> function starts a print job.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-startdocw
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context for the print job.
        /// </param>
        /// <param name="lpdi">
        /// A pointer to a <see cref="DOCINFO"/> structure containing the name of the document file and the name of the output file.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is greater than zero.
        /// This value is the print job identifier for the document.
        /// If the function fails, the return value is less than or equal to zero.
        /// </returns>
        /// <remarks>
        /// Note
        /// This is a blocking or synchronous function and might not return immediately.
        /// How quickly this function returns depends on run-time factors such as network status, print server configuration,
        /// and printer driver implementation—factors that are difficult to predict when writing an application.
        /// Calling this function from a thread that manages interaction with the user interface could make the application appear to be unresponsive.
        /// Applications should call the <see cref="StartDoc"/> function immediately before beginning a print job.
        /// Using this function ensures that multipage documents are not interspersed with other print jobs.
        /// Applications can use the value returned by <see cref="StartDoc"/> to retrieve or set the priority of a print job.
        /// Call the <see cref="GetJob"/> or <see cref="SetJob"/> function and supply this value as one of the required arguments.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "StartDocW", SetLastError = true)]
        public static extern int StartDoc([In]HDC hdc, [MarshalAs(UnmanagedType.LPStruct)][In]DOCINFO lpdi);

        /// <summary>
        /// <para>
        /// The <see cref="StartPage"/> function prepares the printer driver to accept data.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-startpage
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context for the print job.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is greater than zero.
        /// If the function fails, the return value is less than or equal to zero.
        /// </returns>
        /// <remarks>
        /// Note
        /// This is a blocking or synchronous function and might not return immediately.
        /// How quickly this function returns depends on run-time factors such as network status, print server configuration,
        /// and printer driver implementation—factors that are difficult to predict when writing an application.
        /// Calling this function from a thread that manages interaction with the user interface could make the application appear to be unresponsive.
        /// The system disables the <see cref="ResetDC"/> function between calls to the <see cref="StartPage"/> and <see cref="EndPage"/> functions.
        /// This means that you cannot change the device mode except at page boundaries.
        /// After calling <see cref="EndPage"/>, you can call <see cref="ResetDC"/> to change the device mode, if necessary.
        /// Note that a call to <see cref="ResetDC"/> resets all device context attributes back to default values.
        /// Neither <see cref="EndPage"/> nor <see cref="StartPage"/> resets the device context attributes.
        /// Device context attributes remain constant across subsequent pages.
        /// You do not need to re-select objects and set up the mapping mode again before printing the next page;
        /// however, doing so will produce the same results and reduce code differences between versions of Windows.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "StartPage", SetLastError = true)]
        public static extern int StartPage([In]HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="EndDoc"/> function ends a print job.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-enddoc
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to the device context for the print job.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is greater than zero.
        /// If the function fails, the return value is less than or equal to zero.
        /// </returns>
        /// <remarks>
        /// Note
        /// This is a blocking or synchronous function and might not return immediately.
        /// How quickly this function returns depends on run-time factors such as network status, print server configuration,
        /// and printer driver implementation—factors that are difficult to predict when writing an application.
        /// Calling this function from a thread that manages interaction with the user interface could make the application appear to be unresponsive.
        /// Applications should call <see cref="EndDoc"/> immediately after finishing a print job.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "EndDoc", SetLastError = true)]
        public static extern int EndDoc([In]HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="EndPage"/> function notifies the device that the application has finished writing to a page.
        /// This function is typically used to direct the device driver to advance to a new page.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-endpage
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context for the print job.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is greater than zero.
        /// If the function fails, the return value is less than or equal to zero.
        /// </returns>
        /// <remarks>
        /// Note
        /// This is a blocking or synchronous function and might not return immediately.
        /// How quickly this function returns depends on run-time factors such as network status, print server configuration,
        /// and printer driver implementation—factors that are difficult to predict when writing an application.
        /// Calling this function from a thread that manages interaction with the user interface could make the application appear to be unresponsive.
        /// Use the <see cref="ResetDC"/> function to change the device mode, if necessary, after calling the <see cref="EndPage"/> function.
        /// Note that a call to <see cref="ResetDC"/> resets all device context attributes back to default values.
        /// Neither <see cref="EndPage"/> nor <see cref="StartPage"/> resets the device context attributes.
        /// Device context attributes remain constant across subsequent pages.
        /// You do not need to re-select objects and set up the mapping mode again before printing the next page;
        /// however, doing so will produce the same results and reduce code differences between versions of Windows.
        /// When a page in a spooled file exceeds approximately 350 MB, it may fail to print and not send an error message.
        /// For example, this can occur when printing large EMF files.
        /// The page size limit depends on many factors including the amount of virtual memory available,
        /// the amount of memory allocated by calling processes, and the amount of fragmentation in the process heap.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "EndPage", SetLastError = true)]
        public static extern int EndPage([In]HDC hdc);
    }
}
