using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="FormatMessage"/> Flags/
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-formatmessagew"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum FormatMessageFlags : uint
    {
        /// <summary>
        /// The function allocates a buffer large enough to hold the formatted message, 
        /// and places a pointer to the allocated buffer at the address specified by lpBuffer. 
        /// The lpBuffer parameter is a pointer to an LPTSTR; you must cast the pointer to an LPTSTR (for example, (LPTSTR)&amp;lpBuffer).
        /// The nSize parameter specifies the minimum number of TCHARs to allocate for an output message buffer. 
        /// The caller should use the <see cref="LocalFree"/> function to free the buffer when it is no longer needed.
        /// If the length of the formatted message exceeds 128K bytes, then FormatMessage will fail and 
        /// a subsequent call to <see cref="GetLastError"/> will return ERROR_MORE_DATA.
        /// In previous versions of Windows, this value was not available for use when compiling Windows Store apps.
        /// As of Windows 10 this value can be used.
        /// Windows Server 2003 and Windows XP:
        /// If the length of the formatted message exceeds 128K bytes, then FormatMessage will not automatically fail with an error of ERROR_MORE_DATA.
        /// Windows 10:
        /// LocalAlloc() has different options: LMEM_FIXED, and LMEM_MOVABLE. 
        /// <see cref="FormatMessage"/>uses LMEM_FIXED, so HeapFree can be used. 
        /// If LMEM_MOVABLE is used, HeapFree cannot be used.
        /// </summary>
        FORMAT_MESSAGE_ALLOCATE_BUFFER = 0x00000100,

        /// <summary>
        /// The Arguments parameter is not a va_list structure, but is a pointer to an array of values that represent the arguments.
        /// This flag cannot be used with 64-bit integer values. If you are using a 64-bit integer, you must use the va_list structure.
        /// </summary>
        FORMAT_MESSAGE_ARGUMENT_ARRAY = 0x00002000,

        /// <summary>
        /// The lpSource parameter is a module handle containing the message-table resource(s) to search.
        /// If this lpSource handle is NULL, the current process's application image file will be searched.
        /// This flag cannot be used with <see cref="FORMAT_MESSAGE_FROM_STRING"/>.
        /// If the module has no message table resource, the function fails with ERROR_RESOURCE_TYPE_NOT_FOUND.
        /// </summary>
        FORMAT_MESSAGE_FROM_HMODULE = 0x00000800,

        /// <summary>
        /// The lpSource parameter is a pointer to a null-terminated string that contains a message definition.
        /// The message definition may contain insert sequences, just as the message text in a message table resource may.
        /// This flag cannot be used with <see cref="FORMAT_MESSAGE_FROM_HMODULE"/> or <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/>.
        /// </summary>
        FORMAT_MESSAGE_FROM_STRING = 0x00000400,

        /// <summary>
        /// The function should search the system message-table resource(s) for the requested message.
        /// If this flag is specified with <see cref="FORMAT_MESSAGE_FROM_HMODULE"/>, 
        /// the function searches the system message table if the message is not found in the module specified by lpSource. 
        /// This flag cannot be used with <see cref="FORMAT_MESSAGE_FROM_STRING"/>.
        /// If this flag is specified, an application can pass the result of the <see cref="GetLastError"/> function 
        /// to retrieve the message text for a system-defined error.
        /// </summary>
        FORMAT_MESSAGE_FROM_SYSTEM = 0x00001000,

        /// <summary>
        /// Insert sequences in the message definition are to be ignored and passed through to the output buffer unchanged.
        /// This flag is useful for fetching a message for later formatting. If this flag is set, the Arguments parameter is ignored.
        /// </summary>
        FORMAT_MESSAGE_IGNORE_INSERTS = 0x00000200,

        /// <summary>
        /// The function ignores regular line breaks in the message definition text. 
        /// The function stores hard-coded line breaks in the message definition text into the output buffer. 
        /// The function generates no new line breaks.
        /// </summary>
        FORMAT_MESSAGE_MAX_WIDTH_MASK = 0x000000FF,
    }
}
