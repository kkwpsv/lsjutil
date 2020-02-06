using Lsj.Util.Win32.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Extensions
{
    public static class ErrorMessageExtensions
    {
        public static string GetSystemErrorMessageFromCode(uint code)
        {
            if (FormatMessage(FormatMessageFlags.FORMAT_MESSAGE_ALLOCATE_BUFFER | FormatMessageFlags.FORMAT_MESSAGE_FROM_SYSTEM, IntPtr.Zero,
                code, 0, out var strPtr, 0, IntPtr.Zero) != 0)
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
    }
}
