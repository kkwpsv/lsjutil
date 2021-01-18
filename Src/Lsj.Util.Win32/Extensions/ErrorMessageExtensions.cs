using Lsj.Util.Win32.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Extensions
{
    /// <summary>
    /// Error Message Extensions
    /// </summary>
    public static class ErrorMessageExtensions
    {
        /// <summary>
        /// Get System Error Message From Code
        /// </summary>
        /// <param name="code">Error Code</param>
        /// <returns>Error Message</returns>
        public unsafe static string GetSystemErrorMessageFromCode(uint code)
        {
            var strPtr = IntPtr.Zero;
            if (FormatMessage(FormatMessageFlags.FORMAT_MESSAGE_ALLOCATE_BUFFER | FormatMessageFlags.FORMAT_MESSAGE_FROM_SYSTEM, IntPtr.Zero,
                code, 0, (IntPtr)(&strPtr), 0, IntPtr.Zero) != 0)
            {
                var str = Marshal.PtrToStringUni(strPtr);
                LocalFree(strPtr);
                return str;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Get System Error Message From Code
        /// </summary>
        /// <param name="code">Error Code</param>
        /// <returns>Error Message</returns>
        public static string GetSystemErrorMessageFromCode(SystemErrorCodes code) => GetSystemErrorMessageFromCode((uint)code);

        /// <summary>
        /// Get System Error Message From Code
        /// </summary>
        /// <param name="code">Error Code</param>
        /// <returns>Error Message</returns>
        public static string GetSystemErrorMessageFromCode(int code) => GetSystemErrorMessageFromCode(unchecked((uint)code));
    }
}
