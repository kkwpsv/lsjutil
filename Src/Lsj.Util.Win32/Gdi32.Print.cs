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
    }
}
