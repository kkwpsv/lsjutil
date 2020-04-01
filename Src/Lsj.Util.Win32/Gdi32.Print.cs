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
        /// The AbortProc function is an application-defined callback function used with the <see cref="SetAbortProc"/> function.
        /// It is called when a print job is to be canceled during spooling.
        /// The <see cref="ABORTPROC"/> type defines a pointer to this callback function.
        /// AbortProc is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nc-wingdi-abortproc
        /// </para>
        /// </summary>
        /// <param name="Arg1"></param>
        /// <param name="Arg2"></param>
        /// <returns>
        /// The callback function should return <see cref="TRUE"/> to continue the print job or <see cref="FALSE"/> to cancel the print job.
        /// </returns>
        /// <remarks>
        /// Note
        /// This is a blocking or synchronous function and might not return immediately.
        /// How quickly this function returns depends on run-time factors such as network status, print server configuration,
        /// and printer driver implementation—factors that are difficult to predict when writing an application.
        /// Calling this function from a thread that manages interaction with the user interface could make the application appear to be unresponsive.
        /// If the iError parameter is <see cref="SP_OUTOFDISK"/>, the application need not cancel the print job.
        /// If it does not cancel the job, it must yield to Print Manager by calling the <see cref="PeekMessage"/> or <see cref="GetMessage"/> function.
        /// </remarks>
        public delegate BOOL ABORTPROC([In]HDC Arg1, [In]int Arg2);


        /// <summary>
        /// <para>
        /// The <see cref="AbortDoc"/> function stops the current print job and erases everything drawn
        /// since the last call to the <see cref="StartDoc"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-abortdoc
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to the device context for the print job.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is greater than zero.
        /// If the function fails, the return value is <see cref="SP_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// Note
        /// This is a blocking or synchronous function and might not return immediately.
        /// How quickly this function returns depends on run-time factors such as network status, print server configuration,
        /// and printer driver implementation—factors that are difficult to predict when writing an application.
        /// Calling this function from a thread that manages interaction with the user interface could make the application appear to be unresponsive.
        /// Applications should call the <see cref="AbortDoc"/> function to stop a print job if an error occurs,
        /// or to stop a print job after the user cancels that job. To end a successful print job,
        /// an application should call the <see cref="EndDoc"/> function.
        /// If Print Manager was used to start the print job, calling <see cref="AbortDoc"/> erases the entire spool job, so that the printer receives nothing.
        /// If Print Manager was not used to start the print job, the data may already have been sent to the printer.
        /// In this case, the printer driver resets the printer (when possible) and ends the print job.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AbortDoc", SetLastError = true)]
        public static extern int AbortDoc([In]HDC hdc);

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
        public static extern int StartDoc([In]HDC hdc, [In]in DOCINFO lpdi);

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
        /// The <see cref="SetAbortProc"/> function sets the application-defined abort function that allows a print job to be canceled during spooling.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setabortproc
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to the device context for the print job.
        /// </param>
        /// <param name="proc">
        /// Pointer to the application-defined abort function.
        /// For more information about the callback function, see the <see cref="ABORTPROC"/> callback function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is greater than zero.
        /// If the function fails, the return value is <see cref="SP_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// Note
        /// This is a blocking or synchronous function and might not return immediately.
        /// How quickly this function returns depends on run-time factors such as network status, print server configuration,
        /// and printer driver implementation—factors that are difficult to predict when writing an application.
        /// Calling this function from a thread that manages interaction with the user interface could make the application appear to be unresponsive.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetAbortProc", SetLastError = true)]
        public static extern int SetAbortProc([In]HDC hdc, [In]ABORTPROC proc);

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
