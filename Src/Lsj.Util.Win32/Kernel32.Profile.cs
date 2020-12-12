using Lsj.Util.Win32.BaseTypes;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32
{
    public partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// Retrieves an integer associated with a key in the specified section of an initialization file.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-getprivateprofileintw
        /// </para>
        /// </summary>
        /// <param name="lpAppName">
        /// The name of the section in the initialization file.
        /// </param>
        /// <param name="lpKeyName">
        /// The name of the key whose value is to be retrieved.
        /// This value is in the form of a string; the <see cref="GetPrivateProfileInt"/> function converts the string into an integer and returns the integer.
        /// </param>
        /// <param name="nDefault">
        /// The default value to return if the key name cannot be found in the initialization file.
        /// </param>
        /// <param name="lpFileName">
        /// The name of the initialization file.
        /// If this parameter does not contain a full path to the file, the system searches for the file in the Windows directory.
        /// </param>
        /// <returns>
        /// The return value is the integer equivalent of the string following the specified key name in the specified initialization file.
        /// If the key is not found, the return value is the specified default value.
        /// </returns>
        /// <remarks>
        /// The function searches the file for a key that matches the name specified by the <paramref name="lpKeyName"/> parameter
        /// under the section name specified by the <paramref name="lpAppName"/> parameter.
        /// A section in the initialization file must have the following form:
        /// <code>
        /// [section]
        /// key=value
        /// .
        /// .
        /// .
        /// </code>
        /// The <see cref="GetPrivateProfileInt"/> function is not case-sensitive;
        /// the strings in <paramref name="lpAppName"/> and <paramref name="lpKeyName"/> can be a combination of uppercase and lowercase letters.
        /// An application can use the <see cref="GetProfileInt"/> function to retrieve an integer value from the Win.ini file.
        /// The system maps most .ini file references to the registry, using the mapping defined under the following registry key:
        /// HKEY_LOCAL_MACHINE\Software\Microsoft\Windows NT\CurrentVersion\IniFileMapping
        /// This mapping is likely if an application modifies system-component initialization files, such as Control.ini, System.ini, and Winfile.ini.
        /// In these cases, the function retrieves information from the registry, not from the initialization file;
        /// the change in the storage location has no effect on the function's behavior.
        /// The profile functions use the following steps to locate initialization information:
        /// Look in the registry for the name of the initialization file under the IniFileMapping key.
        /// Look for the section name specified by <paramref name="lpAppName"/>.
        /// This will be a named value under the key that has the name of the initialization file, or a subkey with this name,
        /// or the name will not exist as either a value or subkey.
        /// If the section name specified by <paramref name="lpAppName"/> is a named value,
        /// then that value specifies where in the registry you will find the keys for the section
        /// If the section name specified by <paramref name="lpAppName"/> is a subkey,
        /// then named values under that subkey specify where in the registry you will find the keys for the section.
        /// If the key you are looking for does not exist as a named value, then there will be an unnamed value (shown as &lt;No Name&gt;) that
        /// specifies the default location in the registry where you will find the key.
        /// If the section name specified by <paramref name="lpAppName"/> does not exist as a named value or as a subkey,
        /// then there will be an unnamed value (shown as &lt;No Name&gt;) that specifies the default location in the registry
        /// where you will find the keys for the section.
        /// If there is no subkey or entry for the section name, then look for the actual initialization file on the disk and read its contents.
        /// When looking at values in the registry that specify other registry locations,
        /// there are several prefixes that change the behavior of the .ini file mapping:
        /// ! - this character forces all writes to go both to the registry and to the .ini file on disk.
        /// # - this character causes the registry value to be set to the value in the Windows 3.1 .ini file
        /// when a new user logs in for the first time after setup.
        /// @ - this character prevents any reads from going to the .ini file on disk if the requested data is not found in the registry.
        /// USR: - this prefix stands for HKEY_CURRENT_USER, and the text after the prefix is relative to that key.
        /// SYS: - this prefix stands for HKEY_LOCAL_MACHINE\SOFTWARE, and the text after the prefix is relative to that key.
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit Windows-based applications." +
            "Applications should store initialization information in the registry.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPrivateProfileIntW", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GetPrivateProfileInt([MarshalAs(UnmanagedType.LPWStr)][In] string lpAppName,
            [MarshalAs(UnmanagedType.LPWStr)][In] string lpKeyName, [In] INT nDefault, [MarshalAs(UnmanagedType.LPWStr)][In] string lpFileName);

        /// <summary>
        /// <para>
        /// Retrieves a string from the specified section in an initialization file.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-getprivateprofilestringw
        /// </para>
        /// </summary>
        /// <param name="lpAppName">
        /// The name of the section containing the key name.
        /// If this parameter is <see langword="null"/>,
        /// the <see cref="GetPrivateProfileString"/> function copies all section names in the file to the supplied buffer.
        /// </param>
        /// <param name="lpKeyName">
        /// The name of the key whose associated string is to be retrieved.
        /// If this parameter is <see langword="null"/>, all key names in the section specified by the <paramref name="lpAppName"/> parameter
        /// are copied to the buffer specified by the <paramref name="lpReturnedString"/> parameter.
        /// </param>
        /// <param name="lpDefault">
        /// A default string.
        /// If the <paramref name="lpKeyName"/> key cannot be found in the initialization file,
        /// <see cref="GetPrivateProfileString"/> copies the default string to the <paramref name="lpReturnedString"/> buffer.
        /// If this parameter is <see langword="null"/>, the default is an empty string, "".
        /// Avoid specifying a default string with trailing blank characters.
        /// The function inserts a null character in the <paramref name="lpReturnedString"/> buffer to strip any trailing blanks.
        /// </param>
        /// <param name="lpReturnedString">
        /// A pointer to the buffer that receives the retrieved string.
        /// </param>
        /// <param name="nSize">
        /// The size of the buffer pointed to by the <paramref name="lpReturnedString"/> parameter, in characters.
        /// </param>
        /// <param name="lpFileName">
        /// The name of the initialization file.
        /// If this parameter does not contain a full path to the file, the system searches for the file in the Windows directory.
        /// </param>
        /// <returns>
        /// The return value is the number of characters copied to the buffer, not including the terminating null character.
        /// If neither <paramref name="lpAppName"/> nor <paramref name="lpKeyName"/> is <see langword="null"/>
        /// and the supplied destination buffer is too small to hold the requested string, the string is truncated and followed by a null character,
        /// and the return value is equal to <paramref name="nSize"/> minus one.
        /// If either <paramref name="lpAppName"/> or <paramref name="lpKeyName"/> is <see langword="null"/>
        /// and the supplied destination buffer is too small to hold all the strings, the last string is truncated and followed by two null characters.
        /// In this case, the return value is equal to <paramref name="nSize"/> minus two.
        /// In the event the initialization file specified by <paramref name="lpFileName"/> is not found, or contains invalid values,
        /// this function will set errorno with a value of '0x2' (File Not Found).
        /// To retrieve extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="GetPrivateProfileString"/> function searches the specified initialization file for a key
        /// that matches the name specified by the <paramref name="lpKeyName"/> parameter under the section heading specified by the lpAppName parameter.
        /// If it finds the key, the function copies the corresponding string to the buffer.
        /// If the key does not exist, the function copies the default character string specified by the <paramref name="lpDefault"/> parameter.
        /// A section in the initialization file must have the following form:
        /// <code>
        /// [section]
        /// key=value
        /// .
        /// .
        /// .
        /// </code>
        /// If <paramref name="lpAppName"/> is <see langword="null"/>,
        /// <see cref="GetPrivateProfileString"/> copies all section names in the specified file to the supplied buffer.
        /// If <paramref name="lpKeyName"/> is <see langword="null"/>, the function copies all key names in the specified section to the supplied buffer.
        /// An application can use this method to enumerate all of the sections and keys in a file.
        /// In either case, each string is followed by a null character and the final string is followed by a second null character.
        /// If the supplied destination buffer is too small to hold all the strings, the last string is truncated and followed by two null characters.
        /// If the string associated with <paramref name="lpKeyName"/> is enclosed in single or double quotation marks,
        /// the marks are discarded when the <see cref="GetPrivateProfileString"/> function retrieves the string.
        /// The <see cref="GetPrivateProfileString"/> function is not case-sensitive; the strings can be a combination of uppercase and lowercase letters.
        /// To retrieve a string from the Win.ini file, use the <see cref="GetProfileString"/> function.
        /// The system maps most .ini file references to the registry, using the mapping defined under the following registry key:
        /// HKEY_LOCAL_MACHINE\Software\Microsoft\Windows NT\CurrentVersion\IniFileMapping
        /// This mapping is likely if an application modifies system-component initialization files, such as Control.ini, System.ini, and Winfile.ini.
        /// In these cases, the function retrieves information from the registry, not from the initialization file;
        /// the change in the storage location has no effect on the function's behavior.
        /// The profile functions use the following steps to locate initialization information:
        /// Look in the registry for the name of the initialization file under the IniFileMapping key.
        /// Look for the section name specified by <paramref name="lpAppName"/>.
        /// This will be a named value under the key that has the name of the initialization file, or a subkey with this name,
        /// or the name will not exist as either a value or subkey.
        /// If the section name specified by <paramref name="lpAppName"/> is a named value,
        /// then that value specifies where in the registry you will find the keys for the section
        /// If the section name specified by <paramref name="lpAppName"/> is a subkey,
        /// then named values under that subkey specify where in the registry you will find the keys for the section.
        /// If the key you are looking for does not exist as a named value, then there will be an unnamed value (shown as &lt;No Name&gt;) that
        /// specifies the default location in the registry where you will find the key.
        /// If the section name specified by <paramref name="lpAppName"/> does not exist as a named value or as a subkey,
        /// then there will be an unnamed value (shown as &lt;No Name&gt;) that specifies the default location in the registry
        /// where you will find the keys for the section.
        /// If there is no subkey or entry for the section name, then look for the actual initialization file on the disk and read its contents.
        /// When looking at values in the registry that specify other registry locations,
        /// there are several prefixes that change the behavior of the .ini file mapping:
        /// ! - this character forces all writes to go both to the registry and to the .ini file on disk.
        /// # - this character causes the registry value to be set to the value in the Windows 3.1 .ini file
        /// when a new user logs in for the first time after setup.
        /// @ - this character prevents any reads from going to the .ini file on disk if the requested data is not found in the registry.
        /// USR: - this prefix stands for HKEY_CURRENT_USER, and the text after the prefix is relative to that key.
        /// SYS: - this prefix stands for HKEY_LOCAL_MACHINE\SOFTWARE, and the text after the prefix is relative to that key.
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit Windows-based applications." +
            "Applications should store initialization information in the registry.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPrivateProfileStringW", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetPrivateProfileString([MarshalAs(UnmanagedType.LPWStr)][In] string lpAppName,
            [MarshalAs(UnmanagedType.LPWStr)][In] string lpKeyName, [MarshalAs(UnmanagedType.LPWStr)][In] string lpDefault,
            [MarshalAs(UnmanagedType.LPWStr)][In] string lpReturnedString, [In] DWORD nSize, [MarshalAs(UnmanagedType.LPWStr)][In] string lpFileName);

        /// <summary>
        /// <para>
        /// Retrieves an integer from a key in the specified section of the Win.ini file.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-getprofileintw
        /// </para>
        /// </summary>
        /// <param name="lpAppName">
        /// The name of the section containing the key name.
        /// </param>
        /// <param name="lpKeyName">
        /// The name of the key whose value is to be retrieved.
        /// This value is in the form of a string; the <see cref="GetProfileInt"/> function converts the string into an integer and returns the integer.
        /// </param>
        /// <param name="nDefault">
        /// The default value to return if the key name cannot be found in the initialization file.
        /// </param>
        /// <returns>
        /// The return value is the integer equivalent of the string following the key name in Win.ini.
        /// If the function cannot find the key, the return value is the default value. If the value of the key is less than zero, the return value is zero.
        /// </returns>
        /// <remarks>
        /// If the key name consists of digits followed by characters that are not numeric, the function returns only the value of the digits.
        /// For example, the function returns 102 for the following line: KeyName=102abc.
        /// Windows Server 2003 and Windows XP/2000:
        /// Calls to profile functions may be mapped to the registry instead of to the initialization files.
        /// This mapping occurs when the initialization file and section are specified in the registry under the following key:
        /// HKEY_LOCAL_MACHINE\Software\Microsoft\Windows NT\CurrentVersion\IniFileMapping
        /// When the operation has been mapped, the <see cref="GetProfileInt"/> function retrieves information from the registry,
        /// not from the initialization file; the change in the storage location has no effect on the function's behavior.
        /// The profile functions use the following steps to locate initialization information:
        /// Look in the registry for the name of the initialization file under the IniFileMapping key.
        /// Look for the section name specified by <paramref name="lpAppName"/>.
        /// This will be a named value under the key that has the name of the initialization file, or a subkey with this name,
        /// or the name will not exist as either a value or subkey.
        /// If the section name specified by <paramref name="lpAppName"/> is a named value,
        /// then that value specifies where in the registry you will find the keys for the section
        /// If the section name specified by <paramref name="lpAppName"/> is a subkey,
        /// then named values under that subkey specify where in the registry you will find the keys for the section.
        /// If the key you are looking for does not exist as a named value, then there will be an unnamed value (shown as &lt;No Name&gt;) that
        /// specifies the default location in the registry where you will find the key.
        /// If the section name specified by <paramref name="lpAppName"/> does not exist as a named value or as a subkey,
        /// then there will be an unnamed value (shown as &lt;No Name&gt;) that specifies the default location in the registry
        /// where you will find the keys for the section.
        /// If there is no subkey or entry for the section name, then look for the actual initialization file on the disk and read its contents.
        /// When looking at values in the registry that specify other registry locations,
        /// there are several prefixes that change the behavior of the .ini file mapping:
        /// ! - this character forces all writes to go both to the registry and to the .ini file on disk.
        /// # - this character causes the registry value to be set to the value in the Windows 3.1 .ini file
        /// when a new user logs in for the first time after setup.
        /// @ - this character prevents any reads from going to the .ini file on disk if the requested data is not found in the registry.
        /// USR: - this prefix stands for HKEY_CURRENT_USER, and the text after the prefix is relative to that key.
        /// SYS: - this prefix stands for HKEY_LOCAL_MACHINE\SOFTWARE, and the text after the prefix is relative to that key.
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit Windows-based applications." +
            "Applications should store initialization information in the registry.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetProfileIntW", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GetProfileInt([MarshalAs(UnmanagedType.LPWStr)][In] string lpAppName,
            [MarshalAs(UnmanagedType.LPWStr)][In] string lpKeyName, [In] INT nDefault);

        /// <summary>
        /// <para>
        /// Retrieves the string associated with a key in the specified section of the Win.ini file.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-getprofilestringw
        /// </para>
        /// </summary>
        /// <param name="lpAppName">
        /// The name of the section containing the key.
        /// If this parameter is <see langword="null"/>, the function copies all section names in the file to the supplied buffer.
        /// </param>
        /// <param name="lpKeyName">
        /// The name of the key whose associated string is to be retrieved.
        /// If this parameter is <see langword="null"/>, the function copies all keys in the given section to the supplied buffer.
        /// Each string is followed by a null character, and the final string is followed by a second null character.
        /// </param>
        /// <param name="lpDefault">
        /// A default string.
        /// If the <paramref name="lpKeyName"/> key cannot be found in the initialization file,
        /// <see cref="GetProfileString"/> copies the default string to the <paramref name="lpReturnedString"/> buffer.
        /// If this parameter is <see langword="null"/>, the default is an empty string, "".
        /// Avoid specifying a default string with trailing blank characters.
        /// The function inserts a null character in the <paramref name="lpReturnedString"/> buffer to strip any trailing blanks.
        /// </param>
        /// <param name="lpReturnedString">
        /// A pointer to a buffer that receives the character string.
        /// </param>
        /// <param name="nSize">
        /// The size of the buffer pointed to by the <paramref name="lpReturnedString"/> parameter, in characters.
        /// </param>
        /// <returns>
        /// The return value is the number of characters copied to the buffer, not including the null-terminating character.
        /// If neither <paramref name="lpAppName"/> nor <paramref name="lpKeyName"/> is <see langword="null"/> and
        /// the supplied destination buffer is too small to hold the requested string, the string is truncated and followed by a null character,
        /// and the return value is equal to <paramref name="nSize"/> minus one.
        /// If either <paramref name="lpAppName"/> or <paramref name="lpKeyName"/> is <see langword="null"/> and
        /// the supplied destination buffer is too small to hold all the strings, the last string is truncated and followed by two null characters.
        /// In this case, the return value is equal to <paramref name="nSize"/> minus two.
        /// </returns>
        /// <remarks>
        /// If the string associated with the <paramref name="lpKeyName"/> parameter is enclosed in single or double quotation marks,
        /// the marks are discarded when the <see cref="GetProfileString"/> function returns the string.
        /// The <see cref="GetProfileString"/> function is not case-sensitive; the strings can contain a combination of uppercase and lowercase letters.
        /// A section in the Win.ini file must have the following form:
        /// <code>
        /// [section]
        /// key=string
        /// .
        /// .
        /// .
        /// </code>
        /// An application can use the <see cref="GetPrivateProfileString"/> function to retrieve a string from a specified initialization file.
        /// The <paramref name="lpDefault"/> parameter must point to a valid string,
        /// even if the string is empty (that is, even if its first character is a null character).
        /// Windows Server 2003 and Windows XP/2000:
        /// Calls to profile functions may be mapped to the registry instead of to the initialization files.
        /// This mapping occurs when the initialization file and section are specified in the registry under the following key:
        /// HKEY_LOCAL_MACHINE\Software\Microsoft\Windows NT\CurrentVersion\IniFileMapping
        /// When the operation has been mapped, the <see cref="GetProfileString"/> function retrieves information from the registry,
        /// not from the initialization file; the change in the storage location has no effect on the function's behavior.
        /// The profile functions use the following steps to locate initialization information:
        /// Look in the registry for the name of the initialization file under the IniFileMapping key.
        /// Look for the section name specified by <paramref name="lpAppName"/>.
        /// This will be a named value under the key that has the name of the initialization file, or a subkey with this name,
        /// or the name will not exist as either a value or subkey.
        /// If the section name specified by <paramref name="lpAppName"/> is a named value,
        /// then that value specifies where in the registry you will find the keys for the section
        /// If the section name specified by <paramref name="lpAppName"/> is a subkey,
        /// then named values under that subkey specify where in the registry you will find the keys for the section.
        /// If the key you are looking for does not exist as a named value, then there will be an unnamed value (shown as &lt;No Name&gt;) that
        /// specifies the default location in the registry where you will find the key.
        /// If the section name specified by <paramref name="lpAppName"/> does not exist as a named value or as a subkey,
        /// then there will be an unnamed value (shown as &lt;No Name&gt;) that specifies the default location in the registry
        /// where you will find the keys for the section.
        /// If there is no subkey or entry for the section name, then look for the actual initialization file on the disk and read its contents.
        /// When looking at values in the registry that specify other registry locations,
        /// there are several prefixes that change the behavior of the .ini file mapping:
        /// ! - this character forces all writes to go both to the registry and to the .ini file on disk.
        /// # - this character causes the registry value to be set to the value in the Windows 3.1 .ini file
        /// when a new user logs in for the first time after setup.
        /// @ - this character prevents any reads from going to the .ini file on disk if the requested data is not found in the registry.
        /// USR: - this prefix stands for HKEY_CURRENT_USER, and the text after the prefix is relative to that key.
        /// SYS: - this prefix stands for HKEY_LOCAL_MACHINE\SOFTWARE, and the text after the prefix is relative to that key.
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit Windows-based applications," +
            "therefore this function should not be called from server code. Applications should store initialization information in the registry.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetProfileStringW", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetProfileString([MarshalAs(UnmanagedType.LPWStr)][In] string lpAppName,
            [MarshalAs(UnmanagedType.LPWStr)][In] string lpKeyName, [MarshalAs(UnmanagedType.LPWStr)][In] string lpDefault,
            [In] IntPtr lpReturnedString, [In] DWORD nSize);

        /// <summary>
        /// <para>
        /// Copies a string into the specified section of an initialization file.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-writeprivateprofilestringw
        /// </para>
        /// </summary>
        /// <param name="lpAppName">
        /// The name of the section to which the string will be copied. If the section does not exist, it is created.
        /// The name of the section is case-independent; the string can be any combination of uppercase and lowercase letters.
        /// </param>
        /// <param name="lpKeyName">
        /// The name of the key to be associated with a string. If the key does not exist in the specified section, it is created.
        /// If this parameter is <see langword="null"/>, the entire section, including all entries within the section, is deleted.
        /// </param>
        /// <param name="lpString">
        /// A null-terminated string to be written to the file.
        /// If this parameter is <see langword="null"/>, the key pointed to by the <paramref name="lpKeyName"/> parameter is deleted.
        /// </param>
        /// <param name="lpFileName">
        /// The name of the initialization file.
        /// If the file was created using Unicode characters, the function writes Unicode characters to the file.
        /// Otherwise, the function writes ANSI characters.
        /// </param>
        /// <returns>
        /// If the function successfully copies the string to the initialization file, the return value is <see cref="BOOL.TRUE"/>.
        /// If the function fails, or if it flushes the cached version of the most recently accessed initialization file,
        /// the return value is <see cref="BOOL.FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// A section in the Win.ini file must have the following form:
        /// <code>
        /// [section]
        /// key=string
        /// .
        /// .
        /// .
        /// </code>
        /// If the <paramref name="lpFileName"/> parameter does not contain a full path and file name for the file,
        /// <see cref="WritePrivateProfileString"/> searches the Windows directory for the file.
        /// If the file does not exist, this function creates the file in the Windows directory.
        /// If <paramref name="lpFileName"/> contains a full path and file name and the file does not exist,
        /// <see cref="WritePrivateProfileString"/> creates the file.
        /// The specified directory must already exist.
        /// The system keeps a cached version of the most recent registry file mapping to improve performance.
        /// If all parameters are <see langword="null"/>, the function flushes the cache.
        /// While the system is editing the cached version of the file, processes that edit the file itself will use the original file
        /// until the cache has been cleared.
        /// The system maps most .ini file references to the registry, using the mapping defined under the following registry key:
        /// HKEY_LOCAL_MACHINE\Software\Microsoft\Windows NT\CurrentVersion\IniFileMapping
        /// When the operation has been mapped, the <see cref="GetProfileString"/> function retrieves information from the registry,
        /// not from the initialization file; the change in the storage location has no effect on the function's behavior.
        /// The profile functions use the following steps to locate initialization information:
        /// Look in the registry for the name of the initialization file under the IniFileMapping key.
        /// Look for the section name specified by <paramref name="lpAppName"/>.
        /// This will be a named value under the key that has the name of the initialization file, or a subkey with this name,
        /// or the name will not exist as either a value or subkey.
        /// If the section name specified by <paramref name="lpAppName"/> is a named value,
        /// then that value specifies where in the registry you will find the keys for the section
        /// If the section name specified by <paramref name="lpAppName"/> is a subkey,
        /// then named values under that subkey specify where in the registry you will find the keys for the section.
        /// If the key you are looking for does not exist as a named value, then there will be an unnamed value (shown as &lt;No Name&gt;) that
        /// specifies the default location in the registry where you will find the key.
        /// If the section name specified by <paramref name="lpAppName"/> does not exist as a named value or as a subkey,
        /// then there will be an unnamed value (shown as &lt;No Name&gt;) that specifies the default location in the registry
        /// where you will find the keys for the section.
        /// If there is no subkey or entry for the section name, then look for the actual initialization file on the disk and read its contents.
        /// When looking at values in the registry that specify other registry locations,
        /// there are several prefixes that change the behavior of the .ini file mapping:
        /// ! - this character forces all writes to go both to the registry and to the .ini file on disk.
        /// # - this character causes the registry value to be set to the value in the Windows 3.1 .ini file
        /// when a new user logs in for the first time after setup.
        /// @ - this character prevents any reads from going to the .ini file on disk if the requested data is not found in the registry.
        /// USR: - this prefix stands for HKEY_CURRENT_USER, and the text after the prefix is relative to that key.
        /// SYS: - this prefix stands for HKEY_LOCAL_MACHINE\SOFTWARE, and the text after the prefix is relative to that key.
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit Windows-based applications," +
            "therefore this function should not be called from server code. Applications should store initialization information in the registry.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WritePrivateProfileStringW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL WritePrivateProfileString([MarshalAs(UnmanagedType.LPWStr)][In] string lpAppName,
            [MarshalAs(UnmanagedType.LPWStr)][In] string lpKeyName, [MarshalAs(UnmanagedType.LPWStr)][In] string lpString,
            [MarshalAs(UnmanagedType.LPWStr)][In] string lpFileName);

        /// <summary>
        /// <para>
        /// Copies a string into the specified section of the Win.ini file.
        /// If Win.ini uses Unicode characters, the function writes Unicode characters to the file.
        /// Otherwise, the function writes ANSI characters.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-writeprofilestringw
        /// </para>
        /// </summary>
        /// <param name="lpAppName">
        /// The section to which the string is to be copied. If the section does not exist, it is created.
        /// The name of the section is not case-sensitive; the string can be any combination of uppercase and lowercase letters.
        /// </param>
        /// <param name="lpKeyName">
        /// The key to be associated with the string.
        /// If the key does not exist in the specified section, it is created.
        /// If this parameter is <see langword="null"/>, the entire section, including all entries in the section, is deleted.
        /// </param>
        /// <param name="lpString">
        /// A null-terminated string to be written to the file.
        /// If this parameter is <see langword="null"/>, the key pointed to by the <paramref name="lpKeyName"/> parameter is deleted.
        /// </param>
        /// <returns>
        /// If the function successfully copies the string to the Win.ini file, the return value is <see langword="true"/>.
        /// If the function fails, or if it flushes the cached version of Win.ini, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// A section in the Win.ini file must have the following form: key=string.
        /// The system keeps a cached version of the most recent registry file mapping to improve performance.
        /// If all parameters are <see langword="null"/>, the function flushes the cache.
        /// While the system is editing the cached version of the file, processes that edit the file itself will use the original file
        /// until the cache has been cleared.
        /// The system maps most .ini file references to the registry, using the mapping defined under the following registry key:
        /// HKEY_LOCAL_MACHINE\Software\Microsoft\Windows NT\CurrentVersion\IniFileMapping
        /// When the operation has been mapped, the <see cref="WriteProfileString"/> function retrieves information from the registry,
        /// not from the initialization file; the change in the storage location has no effect on the function's behavior.
        /// The profile functions use the following steps to locate initialization information:
        /// Look in the registry for the name of the initialization file under the IniFileMapping key.
        /// Look for the section name specified by <paramref name="lpAppName"/>.
        /// This will be a named value under the key that has the name of the initialization file, or a subkey with this name,
        /// or the name will not exist as either a value or subkey.
        /// If the section name specified by <paramref name="lpAppName"/> is a named value,
        /// then that value specifies where in the registry you will find the keys for the section
        /// If the section name specified by <paramref name="lpAppName"/> is a subkey,
        /// then named values under that subkey specify where in the registry you will find the keys for the section.
        /// If the key you are looking for does not exist as a named value, then there will be an unnamed value (shown as &lt;No Name&gt;) that
        /// specifies the default location in the registry where you will find the key.
        /// If the section name specified by <paramref name="lpAppName"/> does not exist as a named value or as a subkey,
        /// then there will be an unnamed value (shown as &lt;No Name&gt;) that specifies the default location in the registry
        /// where you will find the keys for the section.
        /// If there is no subkey or entry for the section name, then look for the actual initialization file on the disk and read its contents.
        /// When looking at values in the registry that specify other registry locations,
        /// there are several prefixes that change the behavior of the .ini file mapping:
        /// ! - this character forces all writes to go both to the registry and to the .ini file on disk.
        /// # - this character causes the registry value to be set to the value in the Windows 3.1 .ini file
        /// when a new user logs in for the first time after setup.
        /// @ - this character prevents any reads from going to the .ini file on disk if the requested data is not found in the registry.
        /// USR: - this prefix stands for HKEY_CURRENT_USER, and the text after the prefix is relative to that key.
        /// SYS: - this prefix stands for HKEY_LOCAL_MACHINE\SOFTWARE, and the text after the prefix is relative to that key.
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit Windows-based applications," +
            "therefore this function should not be called from server code. Applications should store initialization information in the registry.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WriteProfileStringW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL WriteProfileString([MarshalAs(UnmanagedType.LPWStr)][In] string lpAppName,
            [MarshalAs(UnmanagedType.LPWStr)][In] string lpKeyName, [MarshalAs(UnmanagedType.LPWStr)][In] string lpString);
    }
}
