using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.SpoolerErrorCodes;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using static Lsj.Util.Win32.User32;

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
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nc-wingdi-abortproc"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1"></param>
        /// <param name="unnamedParam2"></param>
        /// <returns>
        /// The callback function should return <see cref="TRUE"/> to continue the print job or <see cref="FALSE"/> to cancel the print job.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This is a blocking or synchronous function and might not return immediately.
        /// How quickly this function returns depends on run-time factors such as network status, print server configuration,
        /// and printer driver implementation—factors that are difficult to predict when writing an application.
        /// Calling this function from a thread that manages interaction with the user interface could make the application appear to be unresponsive.
        /// </para>
        /// <para>
        /// If the <paramref name="unnamedParam2"/> parameter is <see cref="SP_OUTOFDISK"/>, the application need not cancel the print job.
        /// If it does not cancel the job, it must yield to Print Manager by calling the <see cref="PeekMessage"/> or <see cref="GetMessage"/> function.
        /// </para>
        /// </remarks>
        public delegate BOOL Abortproc([In] HDC unnamedParam1, [In] int unnamedParam2);


        /// <summary>
        /// <para>
        /// The <see cref="AbortDoc"/> function stops the current print job and erases everything drawn
        /// since the last call to the <see cref="StartDoc"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-abortdoc"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to the device context for the print job.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is greater than zero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="SP_ERROR"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This is a blocking or synchronous function and might not return immediately.
        /// How quickly this function returns depends on run-time factors such as network status, print server configuration,
        /// and printer driver implementation—factors that are difficult to predict when writing an application.
        /// Calling this function from a thread that manages interaction with the user interface could make the application appear to be unresponsive.
        /// </para>
        /// <para>
        /// Applications should call the <see cref="AbortDoc"/> function to stop a print job if an error occurs,
        /// or to stop a print job after the user cancels that job.
        /// To end a successful print job, an application should call the <see cref="EndDoc"/> function.
        /// </para>
        /// <para>
        /// If Print Manager was used to start the print job, calling <see cref="AbortDoc"/> erases the entire spool job, so that the printer receives nothing.
        /// If Print Manager was not used to start the print job, the data may already have been sent to the printer.
        /// In this case, the printer driver resets the printer (when possible) and ends the print job.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AbortDoc", ExactSpelling = true, SetLastError = true)]
        public static extern int AbortDoc([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="EndDoc"/> function ends a print job.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-enddoc"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to the device context for the print job.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is greater than zero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is less than or equal to zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This is a blocking or synchronous function and might not return immediately.
        /// How quickly this function returns depends on run-time factors such as network status, print server configuration,
        /// and printer driver implementation—factors that are difficult to predict when writing an application.
        /// Calling this function from a thread that manages interaction with the user interface could make the application appear to be unresponsive.
        /// </para>
        /// <para>
        /// Applications should call <see cref="EndDoc"/> immediately after finishing a print job.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "EndDoc", ExactSpelling = true, SetLastError = true)]
        public static extern int EndDoc([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="EndPage"/> function notifies the device that the application has finished writing to a page.
        /// This function is typically used to direct the device driver to advance to a new page.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-endpage"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context for the print job.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is greater than zero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is less than or equal to zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This is a blocking or synchronous function and might not return immediately.
        /// How quickly this function returns depends on run-time factors such as network status, print server configuration,
        /// and printer driver implementation—factors that are difficult to predict when writing an application.
        /// Calling this function from a thread that manages interaction with the user interface could make the application appear to be unresponsive.
        /// </para>
        /// <para>
        /// Use the <see cref="ResetDC"/> function to change the device mode, if necessary, after calling the <see cref="EndPage"/> function.
        /// Note that a call to <see cref="ResetDC"/> resets all device context attributes back to default values.
        /// Neither <see cref="EndPage"/> nor <see cref="StartPage"/> resets the device context attributes.
        /// Device context attributes remain constant across subsequent pages.
        /// You do not need to re-select objects and set up the mapping mode again before printing the next page;
        /// however, doing so will produce the same results and reduce code differences between versions of Windows.
        /// </para>
        /// <para>
        /// When a page in a spooled file exceeds approximately 350 MB, it may fail to print and not send an error message.
        /// For example, this can occur when printing large EMF files.
        /// The page size limit depends on many factors including the amount of virtual memory available,
        /// the amount of memory allocated by calling processes, and the amount of fragmentation in the process heap.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "EndPage", ExactSpelling = true, SetLastError = true)]
        public static extern int EndPage([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="GdiDeleteSpoolFileHandle"/> function releases a spool file handle.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/winppi/nf-winppi-gdideletespoolfilehandle"/>
        /// </para>
        /// </summary>
        /// <param name="SpoolFileHandle">
        /// Caller-supplied spool file handle, obtained by a previous call to <see cref="GdiGetSpoolFileHandle"/>.
        /// </param>
        /// <returns>
        /// If the operation succeeds, the function returns <see cref="TRUE"/>.
        /// Otherwise the function returns <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="GdiDeleteSpoolFileHandle"/> function is exported by gdi32.dll
        /// for use within a print processor's <c>PrintDocumentOnPrintProcessor</c> function.
        /// </para>
        /// <para>
        /// Print processors should call <see cref="GdiDeleteSpoolFileHandle"/> after calling <see cref="GdiEndDocEMF"/>,
        /// when processing a print job's EMF data stream has been completed.
        /// The function calls <see cref="ClosePrinter"/> (described in the Microsoft Window SDK documentation) to close the printer connection.
        /// </para>
        /// <para>
        /// For additional information, see Using GDI Functions in Print Processors.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GdiDeleteSpoolFileHandle", ExactSpelling = true)]
        public static extern BOOL GdiDeleteSpoolFileHandle([In] HANDLE SpoolFileHandle);

        /// <summary>
        /// <para>
        /// The <see cref="GdiEndDocEMF"/> function ends EMF playback operations for an EMF-formatted print job.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/winppi/nf-winppi-gdienddocemf"/>
        /// </para>
        /// </summary>
        /// <param name="SpoolFileHandle">
        /// Caller-supplied spool file handle, obtained by a previous call to <see cref="GdiGetSpoolFileHandle"/>.
        /// </param>
        /// <returns>
        /// If the operation succeeds, the function returns <see cref="TRUE"/>.
        /// Otherwise the function returns <see cref="FALSE"/>,
        /// and an error code can be obtained by calling <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="GdiEndDocEMF"/> function is exported by gdi32.dll
        /// for use within a print processor's <c>PrintDocumentOnPrintProcessor</c> function.
        /// </para>
        /// <para>
        /// The function performs operations that must be performed after a print job's EMF records have been played.
        /// The function calls the spooler's <see cref="EndDoc"/> function (described in the Microsoft Window SDK documentation),
        /// which in turn calls the printer driver's <c>DrvEndDoc</c> function.
        /// </para>
        /// <para>
        /// For additional information, see Using GDI Functions in Print Processors.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GdiEndDocEMF", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GdiEndDocEMF([In] HANDLE SpoolFileHandle);

        /// <summary>
        /// <para>
        /// The <see cref="GdiEndPageEMF"/> function ends EMF playback operations for a physical page of an EMF-formatted print job.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/winppi/nf-winppi-gdiendpageemf"/>
        /// </para>
        /// </summary>
        /// <param name="SpoolFileHandle">
        /// Caller-supplied spool file handle, obtained by a previous call to <see cref="GdiGetSpoolFileHandle"/>.
        /// </param>
        /// <param name="dwOptimization">
        /// <para>
        /// Caller-supplied flags. The following flag is defined:
        /// </para>
        /// <para>
        /// <see cref="EMF_PP_COLOR_OPTIMIZATION"/>
        /// </para>
        /// <para>
        /// Enable color optimization. For more information, see Remarks.
        /// </para>
        /// </param>
        /// <returns>
        /// If the operation succeeds, the function returns <see cref="TRUE"/>.
        /// Otherwise the function returns <see cref="FALSE"/>,
        /// and an error code can be obtained by calling <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="GdiEndPageEMF"/> function is exported by gdi32.dll
        /// for use within a print processor's <c>PrintDocumentOnPrintProcessor</c> function.
        /// </para>
        /// <para>
        /// The <see cref="GdiEndPageEMF"/> function ends the processing of a physical page
        /// and causes it to be ejected from the printer.
        /// A print processor should call <see cref="GdiEndPageEMF"/> at the following times:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// After the appropriate number of document pages have been placed on the physical page by making calls to <see cref="GdiPlayPageEMF"/>.
        /// Note that <see cref="GdiPlayPageEMF"/> does not actually print on the device context,
        /// but instead prepares a data structure that describes the text and graphics
        /// that are to be printed on the physical page(s).
        /// The text and graphics are printed to the device context when <see cref="GdiEndPageEMF"/> is called.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Whenever a call to <see cref="GdiGetDevmodeForPage"/> indicates a document page's <see cref="DEVMODE"/> structure
        /// is different from the previous page's <see cref="DEVMODE"/> structure.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If this function is called with the <paramref name="dwOptimization"/> parameter
        /// set to <see cref="EMF_PP_COLOR_OPTIMIZATION"/>, color optimization is enabled.
        /// If <paramref name="dwOptimization"/> is set to 0, no optimization is performed.
        /// When color optimization is enabled, the presence of color in the spool file causes the spool file to be played in color;
        /// the lack of color in the spool file causes the spool file to be played in monochrome.
        /// </para>
        /// <para>
        /// If you are creating a Unidrv rendering plug-in to generate color watermarks,
        /// be advised that color optimization causes color watermarks to be printed in black and white
        /// when they are printed on black-and-white documents.
        /// To ensure that color watermarks print correctly with color and black-and-white documents, disable color optimization.
        /// </para>
        /// <para>
        /// The color optimization controlled by the <paramref name="dwOptimization"/> parameter
        /// can also be controlled by setting the <c>dwColorOptimization</c> member
        /// of the <see cref="ATTRIBUTE_INFO_2"/> or <see cref="ATTRIBUTE_INFO_3"/> structures.
        /// This optimization also can be controlled by the Unidrv <c>*ChangeColorModeOnDoc?</c> color attribute (see Color Attributes).
        /// </para>
        /// <para>
        /// For additional information, see Using GDI Functions in Print Processors.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GdiEndPageEMF", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GdiEndPageEMF([In] HANDLE SpoolFileHandle, [In] DWORD dwOptimization);

        /// <summary>
        /// <para>
        /// The <see cref="GdiGetDC"/> function returns a handle to a printer's device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/winppi/nf-winppi-gdigetdc"/>
        /// </para>
        /// </summary>
        /// <param name="SpoolFileHandle">
        /// Caller-supplied spool file handle, obtained by a previous call to <see cref="GdiGetSpoolFileHandle"/>.
        /// </param>
        /// <returns>
        /// If the operation succeeds, the function returns a device context handle.
        /// Otherwise the function returns <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="GdiGetDC"/> function is exported by gdi32.dll
        /// for use within a print processor's <c>PrintDocumentOnPrintProcessor</c> function.
        /// </para>
        /// <para>
        /// A print processor can call <see cref="GdiGetDC"/> to obtain a printer's device context handle
        /// anytime after calling <see cref="GdiGetSpoolFileHandle"/>.
        /// The print processor can use the context handle to call Win32 device context functions,
        /// in order to perform such operations as applying transformations on the print image.
        /// </para>
        /// <para>
        /// For additional information, see Using GDI Functions in Print Processors.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GdiGetDC", ExactSpelling = true)]
        public static extern HDC GdiGetDC([In] HANDLE SpoolFileHandle);

        /// <summary>
        /// <para>
        /// The <see cref="GdiGetDevmodeForPage"/> function returns <see cref="DEVMODE"/> structures
        /// for the specified and previous pages of a print job.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/winppi/nf-winppi-gdigetdevmodeforpage"/>
        /// </para>
        /// </summary>
        /// <param name="SpoolFileHandle">
        /// Caller-supplied spool file handle, obtained by a previous call to <see cref="GdiGetSpoolFileHandle"/>.
        /// </param>
        /// <param name="dwPageNumber">
        /// Caller-supplied number of the page for which <see cref="DEVMODE"/> contents are to be returned.
        /// </param>
        /// <param name="pCurrDM">
        /// Caller-supplied location to receive a pointer to a <see cref="DEVMODE"/> structure
        /// for the page specified by <paramref name="dwPageNumber"/>.
        /// </param>
        /// <param name="pLastDM">
        /// Caller-supplied location to receive a pointer to a <see cref="DEVMODE"/> structure
        /// for the page previous to the one specified by <paramref name="dwPageNumber"/>.
        /// </param>
        /// <returns>
        /// If the operation succeeds, the function returns <see cref="TRUE"/>.
        /// Otherwise it returns <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="GdiGetDevmodeForPage"/> function is exported by gdi32.dll
        /// for use within a print processor's <c>PrintDocumentOnPrintProcessor</c> function.
        /// </para>
        /// <para>
        /// Before calling <see cref="GdiPlayPageEMF"/> to execute a page's EMF instructions,
        /// a print processor must call <see cref="GdiGetDevmodeForPage"/> to determine
        /// if the <see cref="DEVMODE"/> structure associated with the page to be printed is the same as that of the last page printed.
        /// If the two returned <see cref="DEVMODE"/> structures are not identical,
        /// the print processor must perform the following steps, in order,
        /// before calling <see cref="GdiPlayPageEMF"/> for the page:
        /// </para>
        /// <para>
        /// <list type="number">
        /// <item>
        /// <description>
        /// Call <see cref="GdiEndPageEMF"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Call <see cref="GdiResetDCEMF"/>, specifying the <see cref="DEVMODE"/> pointed to by <paramref name="pCurrDM"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Call <see cref="GdiStartPageEMF"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// For additional information, see Using GDI Functions in Print Processors.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GdiGetDevmodeForPage", ExactSpelling = true)]
        public static extern BOOL GdiGetDevmodeForPage([In] HANDLE SpoolFileHandle, [In] DWORD dwPageNumber,
            [Out] out DEVMODE pCurrDM, [Out] out DEVMODE pLastDM);

        /// <summary>
        /// <para>
        /// The <see cref="GdiGetPageCount"/> function returns the number of pages in a print job.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/winppi/nf-winppi-gdigetpagecount"/>
        /// </para>
        /// </summary>
        /// <param name="SpoolFileHandle">
        /// Caller-supplied spool file handle, obtained by a previous call to <see cref="GdiGetSpoolFileHandle"/>.
        /// </param>
        /// <returns>
        /// If the operation succeeds, the function returns the number of pages in the current print job.
        /// Otherwise the function returns zero.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The GdiGetPageCount function is exported by gdi32.dll for use
        /// within a print processor's <c>PrintDocumentOnPrintProcessor</c> function.
        /// </para>
        /// <para>
        /// The GdiGetPageCount function does not return until all pages have been spooled,
        /// even if the print server administrator has specified that print jobs should be printed during spooling.
        /// Therefore, this function should not be used unless it is necessary to obtain the total page count
        /// before document processing can begin, such as for printing pages in reverse order.
        /// </para>
        /// <para>
        /// Usually, a better method for determining the page count is to count the number of calls made to <see cref="GdiGetPageHandle"/>.
        /// </para>
        /// <para>
        /// For additional information about this set of functions, see Using GDI Functions in Print Processors.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GdiGetPageCount", ExactSpelling = true)]
        public static extern DWORD GdiGetPageCount([In] HANDLE SpoolFileHandle);

        /// <summary>
        /// <para>
        /// The <see cref="GdiGetPageHandle"/> function returns a handle to the specified page within a print job.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/winppi/nf-winppi-gdigetpagehandle"/>
        /// </para>
        /// </summary>
        /// <param name="SpoolFileHandle">
        /// Caller-supplied spool file handle, obtained by a previous call to <see cref="GdiGetSpoolFileHandle"/>.
        /// </param>
        /// <param name="Page">
        /// Caller-supplied page number.
        /// </param>
        /// <param name="pdwPageType">
        /// <para>
        /// Caller-supplied pointer to a location that receives the page type.
        /// The possible page types are shown in the following table:
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Page Type
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="EMF_PP_FORM"/>
        /// </term>
        /// <term>
        /// The page is a form or has a watermark. (Not currently supported.)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="EMF_PP_NORMAL"/>
        /// </term>
        /// <term>
        /// The page is a normal page.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// If the operation succeeds, the function returns <see cref="TRUE"/>.
        /// Otherwise the function returns <see cref="FALSE"/>,
        /// and an error code can be obtained by calling <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="GdiGetPageHandle"/> function is exported by gdi32.dll
        /// for use within a print processor's <see cref="PrintDocumentOnPrintProcessor"/> function.
        /// </para>
        /// <para>
        /// Print processors must obtain a page handle before calling <see cref="GdiPlayPageEMF"/> to draw a page.
        /// If a Page value is specified that is too large, the function returns <see cref="ERROR_NO_MORE_ITEMS"/>.
        /// </para>
        /// <para>
        /// For additional information, see Using GDI Functions in Print Processors.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GdiGetPageHandle", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE GdiGetPageHandle([In] HANDLE SpoolFileHandle, [In] DWORD Page, [Out] out DWORD pdwPageType);

        /// <summary>
        /// <para>
        /// The <see cref="GdiGetSpoolFileHandle"/> function returns a handle to a print job's EMF file.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/winppi/nf-winppi-gdigetspoolfilehandle"/>
        /// </para>
        /// </summary>
        /// <param name="pwszPrinterName">
        /// Caller-supplied pointer to a string representing the name of the target printer.
        /// See the following Remarks section.
        /// </param>
        /// <param name="pDevmode">
        /// Caller-supplied pointer to a <see cref="DEVMODE"/> structure.
        /// See the following Remarks section.
        /// </param>
        /// <param name="pwszDocName">
        /// Caller-supplied pointer to the print job's document name.
        /// See the following Remarks section.
        /// </param>
        /// <returns>
        /// If the operation succeeds, the function returns a spool file handle.
        /// Otherwise the function returns <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="GdiGetSpoolFileHandle"/> function is exported by gdi32.dll
        /// for use within a print processor's <c>PrintDocumentOnPrintProcessor</c> function.
        /// </para>
        /// <para>
        /// When a print processor calls <see cref="GdiGetSpoolFileHandle"/>,
        /// it should supply arguments as illustrated in the following table.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Parameter
        /// </term>
        /// <term>
        /// Argument
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <paramref name="pwszPrinterName"/>
        /// </term>
        /// <term>
        /// Pointer to the printer name received by the print processor's <see cref="OpenPrintProcessor"/> function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <paramref name="pDevmode"/>
        /// </term>
        /// <term>
        /// Pointer to the <see cref="DEVMODE"/> structure contained in the <see cref="PRINTPROCESSOROPENDATA"/> structure,
        /// received by the print processor's <see cref="OpenPrintProcessor"/> function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <paramref name="pwszDocName"/>
        /// </term>
        /// <term>
        /// Document name pointer received by the print processor's <c>PrintDocumentOnPrintProcessor</c> function.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// A print processor must call the <see cref="GdiGetSpoolFileHandle"/> function before calling any other GDI printing functions,
        /// because the returned handle must be passed to the other functions.
        /// The function calls <see cref="OpenPrinter"/> to open a connection to the printer,
        /// and <see cref="CreateDC"/> to create a device context for drawing.
        /// The print processor can obtain the device context's handle by calling <see cref="GdiGetDC"/>.
        /// </para>
        /// <para>
        /// For additional information, see Using GDI Functions in Print Processors.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GdiGetSpoolFileHandle", ExactSpelling = true)]
        public static extern HANDLE GdiGetSpoolFileHandle([In] LPWSTR pwszPrinterName, [In] in DEVMODE pDevmode, [In] LPWSTR pwszDocName);

        /// <summary>
        /// <para>
        /// The <see cref="GdiPlayPageEMF"/> function plays the EMF records
        /// within a specified rectangle for one document page of a spooled print job.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/winppi/nf-winppi-gdiplaypageemf"/>
        /// </para>
        /// </summary>
        /// <param name="SpoolFileHandle">
        /// Caller-supplied spool file handle, obtained by a previous call to <see cref="GdiGetSpoolFileHandle"/>.
        /// </param>
        /// <param name="hemf">
        /// Caller-supplied page handle, obtained by calling <see cref="GdiGetPageHandle"/>,
        /// identifying the page for which records are to be played.
        /// </param>
        /// <param name="prectDocument">
        /// Caller-supplied pointer to a <see cref="RECT"/> structure
        /// specifying the rectangle into which the page is to be drawn.
        /// </param>
        /// <param name="prectBorder">
        /// Caller-supplied pointer to a <see cref="RECT"/> structure specifying the page's border rectangle (if any).
        /// Can be <see cref="NullRef{RECT}"/>.
        /// </param>
        /// <param name="prectClip">
        /// Caller-supplied pointer to a <see cref="RECT"/> structure specifying the coordinates of the page's clip region (if any).
        /// Can be <see cref="NullRef{RECT}"/>.
        /// </param>
        /// <returns>
        /// If the operation succeeds, the function returns <see cref="TRUE"/>.
        /// Otherwise the function returns <see cref="FALSE"/>,
        /// and an error code can be obtained by calling <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="GdiPlayPageEMF"/> function is exported by gdi32.dll
        /// for use within a print processor's <c>PrintDocumentOnPrintProcessor</c> function.
        /// </para>
        /// <para>
        /// The <see cref="GdiPlayPageEMF"/> function is the means by which a print processor
        /// positions a document page or a specified rectangular region of a document page on a physical page.
        /// Note that <see cref="GdiPlayPageEMF"/> does not actually print on the device context,
        /// but instead prepares a data structure that describes the text and graphics that are to be printed on the physical page(s).
        /// The text and graphics are printed to the device context when <see cref="GdiEndPageEMF"/> is called.
        /// </para>
        /// <para>
        /// The print processor uses <paramref name="prectClip"/> to describe the rectangular region to be printed,
        /// and <paramref name="prectDocument"/> to describe a rectangle into which the document page (or clipped region) must fit.
        /// If prectClip is <see cref="NULL"/>, the entire document page will be printed.
        /// For non-<see cref="NULL"/> values of <paramref name="prectClip"/>,
        /// only the portion of the document page within the clip region will be printed.
        /// The <see cref="GdiPlayPageEMF"/> function then performs the scaling and translation operations
        /// required to make the document page (or selected portion) fit into the rectangle.
        /// </para>
        /// <para>
        /// The <paramref name="prectBorder"/> parameter, if it is non-<see cref="NULL"/>,
        /// describes a solid-line border rectangle to be drawn around the document page.
        /// If <paramref name="prectBorder"/> is <see cref="NULL"/>, no such border will be drawn.
        /// </para>
        /// <para>
        /// For additional information, see Using GDI Functions in Print Processors.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GdiPlayPageEMF", ExactSpelling = true)]
        public static extern BOOL GdiPlayPageEMF([In] HANDLE SpoolFileHandle, [In] HANDLE hemf, [Out] out RECT prectDocument,
            [Out] out RECT prectBorder, [Out] out RECT prectClip);

        /// <summary>
        /// <para>
        /// The <see cref="GdiResetDCEMF"/> function resets a printer's device context during playback of a spooled EMF print job.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/winppi/nf-winppi-gdiresetdcemf"/>
        /// </para>
        /// </summary>
        /// <param name="SpoolFileHandle">
        /// Caller-supplied spool file handle, obtained by a previous call to <see cref="GdiGetSpoolFileHandle"/>.
        /// </param>
        /// <param name="pCurrDM">
        /// Caller-supplied pointer to a <see cref="DEVMODE"/> structure,
        /// obtained by a previous call to <see cref="GdiGetDevmodeForPage"/>.
        /// </param>
        /// <returns>
        /// If the operation succeeds, the function returns <see cref="TRUE"/>.
        /// Otherwise the function returns <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="GdiResetDCEMF"/> function is exported by gdi32.dll
        /// for use within a print processor's <c>PrintDocumentOnPrintProcessor</c> function.
        /// </para>
        /// <para>
        /// Print processors must call <see cref="GdiResetDCEMF"/> whenever it is necessary to reset the printer's device context.
        /// The function must be called whenever the <see cref="GdiGetDevmodeForPage"/> function
        /// indicates that the current document page's <see cref="DEVMODE"/> structure is not identical to that of the previous document page.
        /// </para>
        /// <para>
        /// For additional information, see Using GDI Functions in Print Processors.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GdiResetDCEMF", ExactSpelling = true)]
        public static extern BOOL GdiResetDCEMF([In] HANDLE SpoolFileHandle, [In] in DEVMODE pCurrDM);

        /// <summary>
        /// <para>
        /// The <see cref="GdiStartDocEMF"/> function performs initialization operations for an EMF-formatted print job.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/winppi/nf-winppi-gdistartdocemf"/>
        /// </para>
        /// </summary>
        /// <param name="SpoolFileHandle">
        /// Caller-supplied spool file handle, obtained by a previous call to <see cref="GdiGetSpoolFileHandle"/>.
        /// </param>
        /// <param name="pDocInfo">
        /// Caller-supplied pointer to a <see cref="DOCINFO"/> structure (described in the Microsoft Window SDK documentation).
        /// </param>
        /// <returns>
        /// If the operation succeeds, the function returns <see cref="TRUE"/>.
        /// Otherwise the function returns <see cref="FALSE"/>,
        /// and an error code can be obtained by calling <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="GdiStartDocEMF"/> function is exported by gdi32.dll
        /// for use within a print processor's <c>PrintDocumentOnPrintProcessor</c> function.
        /// </para>
        /// <para>
        /// The function performs initializations that must take place before a print job's EMF records can be played.
        /// The function calls the spooler's <see cref="StartDoc"/> function (described in the Window SDK documentation),
        /// which in turn calls the printer driver's <c>DrvStartDoc</c> function.
        /// </para>
        /// <para>
        /// The print processor must set the <see cref="DOCINFO.lpszOutput"/> member of the <see cref="DOCINFO"/> structure
        /// to the output file name contained in the <see cref="PRINTPROCESSOROPENDATA"/> structure,
        /// previously received by the <c>OpenPrintProcessor</c> function.
        /// </para>
        /// <para>
        /// The print processor must set the <see cref="DOCINFO.lpszDocName"/> member of the <see cref="DOCINFO"/> structure
        /// to the document name pointer, previously received by the <c>PrintDocumentOnPrintProcessor</c> function.
        /// </para>
        /// <para>
        /// For additional information, see Using GDI Functions in Print Processors.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GdiStartDocEMF", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GdiStartDocEMF([In] HANDLE SpoolFileHandle, [In] in DOCINFO pDocInfo);

        /// <summary>
        /// <para>
        /// The <see cref="GdiStartPageEMF"/> function performs initialization operations for a physical page of an EMF-formatted print job.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/winppi/nf-winppi-gdistartpageemf"/>
        /// </para>
        /// </summary>
        /// <param name="SpoolFileHandle">
        /// Caller-supplied spool file handle, obtained by a previous call to <see cref="GdiGetSpoolFileHandle"/>.
        /// </param>
        /// <returns>
        /// If the operation succeeds, the function returns <see cref="TRUE"/>.
        /// Otherwise the function returns <see cref="FALSE"/>,
        /// and an error code can be obtained by calling <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="GdiStartPageEMF"/> function is exported by gdi32.dll
        /// for use within a print processor's <c>PrintDocumentOnPrintProcessor</c> function.
        /// </para>
        /// <para>
        /// A print processor must call the <see cref="GdiStartPageEMF"/> function each time a new physical page is to be created.
        /// It can then call <see cref="GdiPlayPageEMF"/> for each document page that is to be placed on the physical page.
        /// </para>
        /// <para>
        /// For additional information, see Using GDI Functions in Print Processors.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GdiStartPageEMF", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GdiStartPageEMF([In] HANDLE SpoolFileHandle);

        /// <summary>
        /// <para>
        /// The <see cref="SetAbortProc"/> function sets the application-defined abort function that allows a print job to be canceled during spooling.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setabortproc"/>
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
        /// <para>
        /// If the function succeeds, the return value is greater than zero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="SP_ERROR"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This is a blocking or synchronous function and might not return immediately.
        /// How quickly this function returns depends on run-time factors such as network status, print server configuration,
        /// and printer driver implementation—factors that are difficult to predict when writing an application.
        /// Calling this function from a thread that manages interaction with the user interface could make the application appear to be unresponsive.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetAbortProc", ExactSpelling = true, SetLastError = true)]
        public static extern int SetAbortProc([In] HDC hdc, [In] ABORTPROC proc);

        /// <summary>
        /// <para>
        /// The <see cref="StartDoc"/> function starts a print job.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-startdocw"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context for the print job.
        /// </param>
        /// <param name="lpdi">
        /// A pointer to a <see cref="DOCINFO"/> structure containing the name of the document file and the name of the output file.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is greater than zero.
        /// This value is the print job identifier for the document.
        /// </para>
        /// <para>
        /// If the function fails, the return value is less than or equal to zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This is a blocking or synchronous function and might not return immediately.
        /// How quickly this function returns depends on run-time factors such as network status, print server configuration,
        /// and printer driver implementation—factors that are difficult to predict when writing an application.
        /// Calling this function from a thread that manages interaction with the user interface could make the application appear to be unresponsive.
        /// </para>
        /// <para>
        /// Applications should call the <see cref="StartDoc"/> function immediately before beginning a print job.
        /// Using this function ensures that multipage documents are not interspersed with other print jobs.
        /// </para>
        /// <para>
        /// Applications can use the value returned by <see cref="StartDoc"/> to retrieve or set the priority of a print job.
        /// Call the <see cref="GetJob"/> or <see cref="SetJob"/> function and supply this value as one of the required arguments.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "StartDocW", ExactSpelling = true, SetLastError = true)]
        public static extern int StartDoc([In] HDC hdc, [In] in DOCINFO lpdi);

        /// <summary>
        /// <para>
        /// The <see cref="StartPage"/> function prepares the printer driver to accept data.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-startpage"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context for the print job.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is greater than zero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is less than or equal to zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This is a blocking or synchronous function and might not return immediately.
        /// How quickly this function returns depends on run-time factors such as network status, print server configuration,
        /// and printer driver implementation—factors that are difficult to predict when writing an application.
        /// Calling this function from a thread that manages interaction with the user interface could make the application appear to be unresponsive.
        /// </para>
        /// <para>
        /// The system disables the <see cref="ResetDC"/> function between calls to the <see cref="StartPage"/> and <see cref="EndPage"/> functions.
        /// This means that you cannot change the device mode except at page boundaries.
        /// After calling <see cref="EndPage"/>, you can call <see cref="ResetDC"/> to change the device mode, if necessary.
        /// Note that a call to <see cref="ResetDC"/> resets all device context attributes back to default values.
        /// </para>
        /// <para>
        /// Neither <see cref="EndPage"/> nor <see cref="StartPage"/> resets the device context attributes.
        /// Device context attributes remain constant across subsequent pages.
        /// You do not need to re-select objects and set up the mapping mode again before printing the next
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "StartPage", ExactSpelling = true, SetLastError = true)]
        public static extern int StartPage([In] HDC hdc);
    }
}
