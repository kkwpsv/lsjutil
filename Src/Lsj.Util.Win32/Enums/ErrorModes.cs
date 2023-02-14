using System;
using static Lsj.Util.Win32.Enums.OpenFileFlags;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Error Modes
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/errhandlingapi/nf-errhandlingapi-seterrormode"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum ErrorModes : uint
    {
        /// <summary>
        /// The system does not display the critical-error-handler message box.
        /// Instead, the system sends the error to the calling process.
        /// Best practice is that all applications call the process-wide <see cref="SetErrorMode"/> function
        /// with a parameter of <see cref="SEM_FAILCRITICALERRORS"/> at startup.
        /// This is to prevent error mode dialogs from hanging the application.
        /// </summary>
        SEM_FAILCRITICALERRORS = 0x0001,

        /// <summary>
        /// The system automatically fixes memory alignment faults and makes them invisible to the application.
        /// It does this for the calling process and any descendant processes.
        /// This feature is only supported by certain processor architectures.
        /// For more information, see the Remarks section.
        /// After this value is set for a process, subsequent attempts to clear the value are ignored.
        /// </summary>
        SEM_NOALIGNMENTFAULTEXCEPT = 0x0004,

        /// <summary>
        /// The system does not display the Windows Error Reporting dialog.
        /// </summary>
        SEM_NOGPFAULTERRORBOX = 0x0002,

        /// <summary>
        /// The <see cref="OpenFile"/> function does not display a message box when it fails to find a file. 
        /// Instead, the error is returned to the caller.
        /// This error mode overrides the <see cref="OF_PROMPT"/> flag.
        /// </summary>
        SEM_NOOPENFILEERRORBOX = 0x8000,
    }
}
