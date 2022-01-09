using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.DOCINFOFlags;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="DOCINFO"/> structure contains the input and output file names and other information used by the <see cref="StartDoc"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/ns-wingdi-docinfow"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DOCINFO
    {
        /// <summary>
        /// The size, in bytes, of the structure.
        /// </summary>
        public int cbSize;

        /// <summary>
        /// Pointer to a null-terminated string that specifies the name of the document.
        /// </summary>
        public IntPtr lpszDocName;

        /// <summary>
        /// Pointer to a null-terminated string that specifies the name of an output file.
        /// If this pointer is <see langword="null"/>, the output will be sent to the device identified by the device context handle
        /// that was passed to the <see cref="StartDoc"/> function.
        /// </summary>
        public IntPtr lpszOutput;

        /// <summary>
        /// Pointer to a null-terminated string that specifies the type of data used to record the print job.
        /// The legal values for this member can be found by calling <see cref="EnumPrintProcessorDatatypes"/> and
        /// can include such values as raw, emf, or XPS_PASS.
        /// This member can be <see langword="null"/>. Note that the requested data type might be ignored.
        /// </summary>
        public IntPtr lpszDatatype;

        /// <summary>
        /// Specifies additional information about the print job.
        /// This member must be zero or one of the following values.
        /// <see cref="DI_APPBANDING"/>: Applications that use banding should set this flag for optimal performance during printing.
        /// <see cref="DI_ROPS_READ_DESTINATION"/>: The application will use raster operations that involve reading from the destination surface.
        /// </summary>
        public DOCINFOFlags fwType;
    }
}
