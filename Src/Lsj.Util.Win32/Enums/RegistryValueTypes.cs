using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.Enums.RegistryOptions;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// A registry value can store data in various formats.
    /// When you store data under a registry value, for instance by calling the <see cref="RegSetValueEx"/> function,
    /// you can specify one of the following values to indicate the type of data being stored.
    /// When you retrieve a registry value, functions such as <see cref="RegQueryValueEx"/> use these values to indicate the type of data retrieved.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/sysinfo/registry-value-types"/>
    /// </para>
    /// </summary>
    public enum RegistryValueTypes : uint
    {
        /// <summary>
        /// Binary data in any form.
        /// </summary>
        REG_BINARY = 3,

        /// <summary>
        /// A 32-bit number.
        /// </summary>
        REG_DWORD = 4,

        /// <summary>
        /// A 32-bit number in little-endian format.
        /// Windows is designed to run on little-endian computer architectures.
        /// Therefore, this value is defined as <see cref="REG_DWORD"/> in the Windows header files.
        /// </summary>
        REG_DWORD_LITTLE_ENDIAN = 4,

        /// <summary>
        /// A 32-bit number in big-endian format.
        /// Some UNIX systems support big-endian architectures.
        /// </summary>
        REG_DWORD_BIG_ENDIAN = 5,

        /// <summary>
        /// A null-terminated string that contains unexpanded references to environment variables (for example, "%PATH%").
        /// It will be a Unicode or ANSI string depending on whether you use the Unicode or ANSI functions.
        /// To expand the environment variable references, use the <see cref="ExpandEnvironmentStrings"/> function.
        /// </summary>
        REG_EXPAND_SZ = 2,

        /// <summary>
        /// A null-terminated Unicode string that contains the target path of a symbolic link that was created
        /// by calling the <see cref="RegCreateKeyEx"/> function with <see cref="REG_OPTION_CREATE_LINK"/>.
        /// </summary>
        REG_LINK = 6,

        /// <summary>
        /// A sequence of null-terminated strings, terminated by an empty string (\0).
        /// The following is an example:
        /// String1\0String2\0String3\0LastString\0\0
        /// The first \0 terminates the first string, the second to the last \0 terminates the last string,
        /// and the final \0 terminates the sequence.
        /// Note that the final terminator must be factored into the length of the string.
        /// </summary>
        REG_MULTI_SZ = 7,

        /// <summary>
        /// No defined value type.
        /// </summary>
        REG_NONE = 0,

        /// <summary>
        /// A 64-bit number.
        /// </summary>
        REG_QWORD = 11,

        /// <summary>
        /// A 64-bit number in little-endian format.
        /// Windows is designed to run on little-endian computer architectures.
        /// Therefore, this value is defined as <see cref="REG_QWORD"/> in the Windows header files.
        /// </summary>
        REG_QWORD_LITTLE_ENDIAN = 11,

        /// <summary>
        /// A null-terminated string.
        /// This will be either a Unicode or an ANSI string, depending on whether you use the Unicode or ANSI functions.
        /// </summary>
        REG_SZ = 1,
    }
}
