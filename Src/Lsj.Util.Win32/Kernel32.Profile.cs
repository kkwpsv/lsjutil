using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HKEY;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32
{
    public partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// Retrieves an integer associated with a key in the specified section of an initialization file.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getprivateprofileintw"/>
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
        /// <para>
        /// The function searches the file for a key that matches the name specified by the <paramref name="lpKeyName"/> parameter
        /// under the section name specified by the <paramref name="lpAppName"/> parameter.
        /// A section in the initialization file must have the following form:
        /// </para>
        /// <code>
        /// [section]
        /// key=value
        /// .
        /// .
        /// .
        /// </code>
        /// <para>
        /// The <see cref="GetPrivateProfileInt"/> function is not case-sensitive;
        /// the strings in <paramref name="lpAppName"/> and <paramref name="lpKeyName"/> can be a combination of uppercase and lowercase letters.
        /// </para>
        /// <para>
        /// An application can use the <see cref="GetProfileInt"/> function to retrieve an integer value from the Win.ini file.
        /// </para>
        /// <para>
        /// The system maps most .ini file references to the registry, using the mapping defined under the following registry key:
        /// <c>HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\IniFileMapping</c>
        /// </para>
        /// <para>
        /// This mapping is likely if an application modifies system-component initialization files,
        /// such as Control.ini, System.ini, and Winfile.ini.
        /// In these cases, the function retrieves information from the registry, not from the initialization file;
        /// the change in the storage location has no effect on the function's behavior.
        /// </para>
        /// <para>
        /// The profile functions use the following steps to locate initialization information:
        /// </para>
        /// <para>
        /// <list type="number">
        /// <item>
        /// <description>
        /// Look in the registry for the name of the initialization file under the <c>IniFileMapping</c> key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Look for the section name specified by <paramref name="lpAppName"/>.
        /// This will be a named value under the key that has the name of the initialization file,
        /// or a subkey with this name, or the name will not exist as either a value or subkey.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <paramref name="lpAppName"/> is a named value,
        /// then that value specifies where in the registry you will find the keys for the section.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <paramref name="lpAppName"/> is a subkey,
        /// then named values under that subkey specify where in the registry you will find the keys for the section.
        /// If the key you are looking for does not exist as a named value,
        /// then there will be an unnamed value (shown as &lt;No Name&gt;)
        /// that specifies the default location in the registry where you will find the key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <paramref name="lpAppName"/> does not exist as a named value or as a subkey,
        /// then there will be an unnamed value (shown as &lt;No Name&gt;)
        /// that specifies the default location in the registry where you will find the keys for the section.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If there is no subkey or entry for the section name,
        /// then look for the actual initialization file on the disk and read its contents.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// When looking at values in the registry that specify other registry locations,
        /// there are several prefixes that change the behavior of the .ini file mapping:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// ! - this character forces all writes to go both to the registry and to the .ini file on disk.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// # - this character causes the registry value to be set to the value 
        /// in the Windows 3.1 .ini file when a new user logs in for the first time after setup.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// @ - this character prevents any reads from going to the .ini file on disk if the requested data is not found in the registry.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// USR: - this prefix stands for <see cref="HKEY_CURRENT_USER"/>, and the text after the prefix is relative to that key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// SYS: - this prefix stands for <c>HKEY_LOCAL_MACHINE\SOFTWARE</c>, and the text after the prefix is relative to that key.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit Windows-based applications. " +
            "Applications should store initialization information in the registry.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPrivateProfileIntW", ExactSpelling = true)]
        public static extern UINT GetPrivateProfileInt([In] LPCWSTR lpAppName, [In] LPCWSTR lpKeyName, [In] INT nDefault, [In] LPCWSTR lpFileName);

        /// <summary>
        /// <para>
        /// Retrieves all the keys and values for the specified section of an initialization file.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getprivateprofilesectionw"/>
        /// </para>
        /// </summary>
        /// <param name="lpAppName">
        /// The name of the section in the initialization file.
        /// </param>
        /// <param name="lpReturnedString">
        /// A pointer to a buffer that receives the key name and value pairs associated with the named section.
        /// The buffer is filled with one or more null-terminated strings;
        /// the last string is followed by a second null character.
        /// </param>
        /// <param name="nSize">
        /// <para>
        /// The size of the buffer pointed to by the <paramref name="lpReturnedString"/> parameter, in characters.
        /// </para>
        /// <para>
        /// Note: In earlier Windows versions, the maximum profile section size is 32,767 characters.
        /// Windows 7 and newer versions don't have this limitation.
        /// </para>
        /// </param>
        /// <param name="lpFileName">
        /// The name of the initialization file.
        /// If this parameter does not contain a full path to the file, the system searches for the file in the Windows directory.
        /// </param>
        /// <returns>
        /// The return value specifies the number of characters copied to the buffer, not including the terminating null character.
        /// If the buffer is not large enough to contain all the key name and value pairs associated with the named section,
        /// the return value is equal to <paramref name="nSize"/> minus two.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The data in the buffer pointed to by the <paramref name="lpReturnedString"/> parameter consists of one or more null-terminated strings,
        /// followed by a final null character. Each string has the following format:
        /// </para>
        /// <para>
        /// <c.key=string
        /// </para>
        /// <para>
        /// The <see cref="GetPrivateProfileSection"/> function is not case-sensitive;
        /// the string pointed to by the <paramref name="lpAppName"/> parameter can be a combination of uppercase and lowercase letters.
        /// </para>
        /// <para>
        /// This operation is atomic; no updates to the specified initialization file are allowed
        /// while the key name and value pairs for the section are being copied to the buffer
        /// pointed to by the <paramref name="lpReturnedString"/> parameter.
        /// </para>
        /// <para>
        /// The system maps most .ini file references to the registry,
        /// using the mapping defined under the following registry key:
        /// <c>HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\IniFileMapping</c>
        /// </para>
        /// <para>
        /// This mapping is likely if an application modifies system-component initialization files,
        /// such as Control.ini, System.ini, and Winfile.ini.
        /// In these cases, the function retrieves information from the registry, not from the initialization file;
        /// the change in the storage location has no effect on the function's behavior.
        /// </para>
        /// <para>
        /// The profile functions use the following steps to locate initialization information:
        /// </para>
        /// <para>
        /// <list type="number">
        /// <item>
        /// <description>
        /// Look in the registry for the name of the initialization file under the <c>IniFileMapping</c> key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Look for the section name specified by <paramref name="lpAppName"/>.
        /// This will be a named value under the key that has the name of the initialization file,
        /// or a subkey with this name, or the name will not exist as either a value or subkey.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <paramref name="lpAppName"/> is a named value,
        /// then that value specifies where in the registry you will find the keys for the section.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <paramref name="lpAppName"/> is a subkey,
        /// then named values under that subkey specify where in the registry you will find the keys for the section.
        /// If the key you are looking for does not exist as a named value,
        /// then there will be an unnamed value (shown as &lt;No Name&gt;)
        /// that specifies the default location in the registry where you will find the key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <paramref name="lpAppName"/> does not exist as a named value or as a subkey,
        /// then there will be an unnamed value (shown as &lt;No Name&gt;)
        /// that specifies the default location in the registry where you will find the keys for the section.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If there is no subkey or entry for the section name,
        /// then look for the actual initialization file on the disk and read its contents.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// When looking at values in the registry that specify other registry locations,
        /// there are several prefixes that change the behavior of the .ini file mapping:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// ! - this character forces all writes to go both to the registry and to the .ini file on disk.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// # - this character causes the registry value to be set to the value in the Windows 3.1 .ini file
        /// when a new user logs in for the first time after setup.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// @ - this character prevents any reads from going to the .ini file on disk
        /// if the requested data is not found in the registry.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// USR: - this prefix stands for <see cref="HKEY_CURRENT_USER"/>,
        /// and the text after the prefix is relative to that key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// SYS: - this prefix stands for <c>HKEY_LOCAL_MACHINE\SOFTWARE</c>,
        /// and the text after the prefix is relative to that key.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Comments (any line that starts with a semicolon) are stripped out and not returned in the <paramref name="lpReturnedString"/> buffer.
        /// </para>
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit Windows-based applications. " +
            "Applications should store initialization information in the registry.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPrivateProfileSectionW", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetPrivateProfileSection([In] LPCWSTR lpAppName, [In] LPWSTR lpReturnedString,
            [In] DWORD nSize, [In] LPCWSTR lpFileName);

        /// <summary>
        /// <para>
        /// Retrieves the names of all sections in an initialization file.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getprivateprofilesectionnamesw"/>
        /// </para>
        /// </summary>
        /// <param name="lpszReturnBuffer">
        /// A pointer to a buffer that receives the section names associated with the named file.
        /// The buffer is filled with one or more <c>null</c>-terminated strings;
        /// the last string is followed by a second <c>null</c> character.
        /// </param>
        /// <param name="nSize">
        /// The size of the buffer pointed to by the <paramref name="lpszReturnBuffer"/> parameter, in characters.
        /// </param>
        /// <param name="lpFileName">
        /// The name of the initialization file.
        /// If this parameter is <see cref="NULL"/>, the function searches the Win.ini file.
        /// If this parameter does not contain a full path to the file, the system searches for the file in the Windows directory.
        /// </param>
        /// <returns>
        /// The return value specifies the number of characters copied to the specified buffer, not including the terminating null character.
        /// If the buffer is not large enough to contain all the section names associated with the specified initialization file,
        /// the return value is equal to the size specified by <paramref name="nSize"/> minus two.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This operation is atomic; no updates to the initialization file are allowed while the section names are being copied to the buffer.
        /// </para>
        /// <para>
        /// The system maps most .ini file references to the registry, using the mapping defined under the following registry key:
        /// <c>HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\IniFileMapping</c>
        /// </para>
        /// <para>
        /// This mapping is likely if an application modifies system-component initialization files, such as Control.ini, System.ini, and Winfile.ini.
        /// In these cases, the function retrieves information from the registry, not from the initialization file;
        /// the change in the storage location has no effect on the function's behavior.
        /// </para>
        /// <para>
        /// The profile functions use the following steps to locate initialization information:
        /// </para>
        /// <para>
        /// <list type="number">
        /// <item>
        /// <description>
        /// Look in the registry for the name of the initialization file under the <c>IniFileMapping</c> key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Look for the section name specified by <c>lpAppName</c>.
        /// This will be a named value under the key that has the name of the initialization file,
        /// or a subkey with this name, or the name will not exist as either a value or subkey.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <c>lpAppName</c> is a named value,
        /// then that value specifies where in the registry you will find the keys for the section.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <c>lpAppName</c> is a subkey,
        /// then named values under that subkey specify where in the registry you will find the keys for the section.
        /// If the key you are looking for does not exist as a named value,
        /// then there will be an unnamed value (shown as &lt;No Name&gt;)
        /// that specifies the default location in the registry where you will find the key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <c>lpAppName</c> does not exist as a named value or as a subkey,
        /// then there will be an unnamed value (shown as &lt;No Name&gt;)
        /// that specifies the default location in the registry where you will find the keys for the section.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If there is no subkey or entry for the section name,
        /// then look for the actual initialization file on the disk and read its contents.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// When looking at values in the registry that specify other registry locations,
        /// there are several prefixes that change the behavior of the .ini file mapping:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// ! - this character forces all writes to go both to the registry and to the .ini file on disk.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// # - this character causes the registry value to be set to the value in the Windows 3.1 .ini file
        /// when a new user logs in for the first time after setup.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// @ - this character prevents any reads from going to the .ini file on disk
        /// if the requested data is not found in the registry.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// USR: - this prefix stands for <see cref="HKEY_CURRENT_USER"/>,
        /// and the text after the prefix is relative to that key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// SYS: - this prefix stands for <c>HKEY_LOCAL_MACHINE\SOFTWARE</c>,
        /// and the text after the prefix is relative to that key.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit Windows-based applications. " +
            "Applications should store initialization information in the registry.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPrivateProfileSectionNamesW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetPrivateProfileSectionNames([In] LPWSTR lpszReturnBuffer, [In] DWORD nSize, [In] LPCWSTR lpFileName);

        /// <summary>
        /// <para>
        /// Retrieves a string from the specified section in an initialization file.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getprivateprofilestringw"/>
        /// </para>
        /// </summary>
        /// <param name="lpAppName">
        /// The name of the section containing the key name.
        /// If this parameter is <see cref="NULL"/>,
        /// the <see cref="GetPrivateProfileString"/> function copies all section names in the file to the supplied buffer.
        /// </param>
        /// <param name="lpKeyName">
        /// The name of the key whose associated string is to be retrieved.
        /// If this parameter is <see cref="NULL"/>, all key names in the section specified by the <paramref name="lpAppName"/> parameter
        /// are copied to the buffer specified by the <paramref name="lpReturnedString"/> parameter.
        /// </param>
        /// <param name="lpDefault">
        /// <para>
        /// A default string.
        /// If the <paramref name="lpKeyName"/> key cannot be found in the initialization file,
        /// <see cref="GetPrivateProfileString"/> copies the default string to the <paramref name="lpReturnedString"/> buffer.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NULL"/>, the default is an empty string, "".
        /// </para>
        /// <para>
        /// Avoid specifying a default string with trailing blank characters. 
        /// The function inserts a null character in the <paramref name="lpReturnedString"/> buffer to strip any trailing blanks.
        /// </para>
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
        /// <para>
        /// The return value is the number of characters copied to the buffer,
        /// not including the terminating <c>null</c> character.
        /// </para>
        /// <para>
        /// If neither <paramref name="lpAppName"/> nor <paramref name="lpKeyName"/> is <see cref="NULL"/>
        /// and the supplied destination buffer is too small to hold the requested string,
        /// the string is truncated and followed by a <c>null</c> character,
        /// and the return value is equal to <paramref name="nSize"/> minus one.
        /// </para>
        /// <para>
        /// If either <paramref name="lpAppName"/> or <paramref name="lpKeyName"/> is <see cref="NULL"/>
        /// and the supplied destination buffer is too small to hold all the strings,
        /// the last string is truncated and followed by two <c>null</c> characters.
        /// In this case, the return value is equal to <paramref name="nSize"/> minus two.
        /// </para>
        /// <para>
        /// In the event the initialization file specified by <paramref name="lpFileName"/> is not found, or contains invalid values,
        /// this function will set <c>errorno</c> with a value of '0x2' (File Not Found).
        /// To retrieve extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="GetPrivateProfileString"/> function searches the specified initialization file for a key
        /// that matches the name specified by the <paramref name="lpKeyName"/> parameter under the section heading specified by the lpAppName parameter.
        /// If it finds the key, the function copies the corresponding string to the buffer.
        /// If the key does not exist, the function copies the default character string specified by the <paramref name="lpDefault"/> parameter.
        /// A section in the initialization file must have the following form:
        /// </para>
        /// <code>
        /// [section]
        /// key=value
        /// .
        /// .
        /// .
        /// </code>
        /// <para>
        /// If <paramref name="lpAppName"/> is <see cref="NULL"/>,
        /// <see cref="GetPrivateProfileString"/> copies all section names in the specified file to the supplied buffer.
        /// If <paramref name="lpKeyName"/> is <see cref="NULL"/>,
        /// the function copies all key names in the specified section to the supplied buffer.
        /// An application can use this method to enumerate all of the sections and keys in a file.
        /// In either case, each string is followed by a <c>null</c> character
        /// and the final string is followed by a second <c>null</c> character.
        /// If the supplied destination buffer is too small to hold all the strings,
        /// the last string is truncated and followed by two <c>null</c> characters.
        /// </para>
        /// <para>
        /// If the string associated with <paramref name="lpKeyName"/> is enclosed in single or double quotation marks,
        /// the marks are discarded when the <see cref="GetPrivateProfileString"/> function retrieves the string.
        /// </para>
        /// <para>
        /// The <see cref="GetPrivateProfileString"/> function is not case-sensitive;
        /// the strings can be a combination of uppercase and lowercase letters.
        /// </para>
        /// <para>
        /// To retrieve a string from the Win.ini file, use the <see cref="GetProfileString"/> function.
        /// </para>
        /// <para>
        /// The system maps most .ini file references to the registry, using the mapping defined under the following registry key:
        /// <c>HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\IniFileMapping</c>
        /// </para>
        /// <para>
        /// This mapping is likely if an application modifies system-component initialization files,
        /// such as Control.ini, System.ini, and Winfile.ini.
        /// In these cases, the function retrieves information from the registry, not from the initialization file;
        /// the change in the storage location has no effect on the function's behavior.
        /// </para>
        /// <para>
        /// The profile functions use the following steps to locate initialization information:
        /// </para>
        /// <para>
        /// <list type="number">
        /// <item>
        /// <description>
        /// Look in the registry for the name of the initialization file under the <c>IniFileMapping</c> key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Look for the section name specified by <paramref name="lpAppName"/>.
        /// This will be a named value under the key that has the name of the initialization file,
        /// or a subkey with this name, or the name will not exist as either a value or subkey.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <paramref name="lpAppName"/> is a named value,
        /// then that value specifies where in the registry you will find the keys for the section.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <paramref name="lpAppName"/> is a subkey
        /// , then named values under that subkey specify where in the registry you will find the keys for the section.
        /// If the key you are looking for does not exist as a named value,
        /// then there will be an unnamed value (shown as &lt;No Name&gt;)
        /// that specifies the default location in the registry where you will find the key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <paramref name="lpAppName"/> does not exist as a named value or as a subkey,
        /// then there will be an unnamed value (shown as &lt;No Name&gt;)
        /// that specifies the default location in the registry where you will find the keys for the section.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If there is no subkey or entry for the section name,
        /// then look for the actual initialization file on the disk and read its contents.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// When looking at values in the registry that specify other registry locations,
        /// there are several prefixes that change the behavior of the .ini file mapping:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// ! - this character forces all writes to go both to the registry and to the .ini file on disk.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// # - this character causes the registry value to be set to the value 
        /// in the Windows 3.1 .ini file when a new user logs in for the first time after setup.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// @ - this character prevents any reads from going to the .ini file on disk if the requested data is not found in the registry.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// USR: - this prefix stands for <see cref="HKEY_CURRENT_USER"/>, and the text after the prefix is relative to that key.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit Windows-based applications. " +
            "Applications should store initialization information in the registry.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPrivateProfileStringW", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetPrivateProfileString([In] LPCWSTR lpAppName, [In] LPCWSTR lpKeyName, [In] LPCWSTR lpDefault,
            [In] LPWSTR lpReturnedString, [In] DWORD nSize, [In] LPCWSTR lpFileName);

        /// <summary>
        /// <para>
        /// Retrieves the data associated with a key in the specified section of an initialization file.
        /// As it retrieves the data, the function calculates a checksum
        /// and compares it with the checksum calculated by the <see cref="WritePrivateProfileStruct"/> function
        /// when the data was added to the file.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getprivateprofilestructw"/>
        /// </para>
        /// </summary>
        /// <param name="lpAppName">
        /// The name of the section in the initialization file.
        /// </param>
        /// <param name="lpszKey">
        /// The name of the key whose data is to be retrieved.
        /// </param>
        /// <param name="lpStruct">
        /// A pointer to the buffer that receives the data associated with the file, section, and key names.
        /// </param>
        /// <param name="uSizeStruct">
        /// The size of the buffer pointed to by the <paramref name="lpStruct"/> parameter, in bytes.
        /// </param>
        /// <param name="szFile">
        /// The name of the initialization file.
        /// If this parameter does not contain a full path to the file, the system searches for the file in the Windows directory.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// A section in the initialization file must have the following form:syntax
        /// </para>
        /// <code>
        /// [section]
        /// key=data
        ///       .
        ///       .
        ///       .
        /// </code>
        /// <para>
        /// The system maps most .ini file references to the registry, using the mapping defined under the following registry key:
        /// <c>HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\IniFileMappings</c>
        /// </para>
        /// <para>
        /// This mapping is likely if an application modifies system-component initialization files,
        /// such as Control.ini, System.ini, and Winfile.ini.
        /// In these cases, the function retrieves information from the registry, not from the initialization file;
        /// the change in the storage location has no effect on the function's behavior.
        /// </para>
        /// <para>
        /// The profile functions use the following steps to locate initialization information:
        /// </para>
        /// <para>
        /// <list type="number">
        /// <item>
        /// <description>
        /// Look in the registry for the name of the initialization file, say MyFile.ini, under IniFileMapping.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Look for the section name specified by <paramref name="lpAppName"/>.
        /// This will be a named value under myfile.ini, or a subkey of myfile.ini, or will not exist.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <paramref name="lpAppName"/> is a named value under myfile.ini,
        /// then that value specifies where in the registry you will find the keys for the section.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <paramref name="lpAppName"/> is a subkey of myfile.ini,
        /// then named values under that subkey specify where in the registry you will find the keys for the section.
        /// If the key you are looking for does not exist as a named value,
        /// then there will be an unnamed value (shown as &lt;No Name&gt;)
        /// that specifies the default location in the registry where you will find the key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <paramref name="lpAppName"/>
        /// does not exist as a named value or as a subkey under myfile.ini,
        /// then there will be an unnamed value (shown as &lt;No Name&gt;)
        /// under myfile.ini that specifies the default location in the registry where you will find the keys for the section.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If there is no myfile.ini subkey, or if it does not contain an entry for the section name,
        /// then look for the actual MyFile.ini on the disk and read its contents.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// When looking at values in the registry that specify other registry locations,
        /// there are several prefixes that change the behavior of the .ini file mapping:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// ! - this character forces all writes to go both to the registry and to the .ini file on disk.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// # - this character causes the registry value to be set to the value in the Windows 3.1 .ini file
        /// when a new user logs in for the first time after setup.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// @ - this character prevents any reads from going to the .ini file on disk
        /// if the requested data is not found in the registry.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// USR: - this prefix stands for <see cref="HKEY_CURRENT_USER"/>,
        /// and the text after the prefix is relative to that key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// SYS: - this prefix stands for <c>HKEY_LOCAL_MACHINE\SOFTWARE</c>,
        /// and the text after the prefix is relative to that key.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit Windows-based applications. " +
            "Applications should store initialization information in the registry.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPrivateProfileStructW", ExactSpelling = true)]
        public static extern DWORD GetPrivateProfileStruct([In] LPWSTR lpAppName, [In] LPCWSTR lpszKey, [In] LPVOID lpStruct,
            [In] DWORD uSizeStruct, [In] LPCWSTR szFile);

        /// <summary>
        /// <para>
        /// Retrieves an integer from a key in the specified section of the Win.ini file.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getprofileintw"/>
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
        /// If the function cannot find the key, the return value is the default value.
        /// If the value of the key is less than zero, the return value is zero.
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the key name consists of digits followed by characters that are not numeric, the function returns only the value of the digits.
        /// For example, the function returns 102 for the following line: KeyName=102abc.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP/2000:
        /// Calls to profile functions may be mapped to the registry instead of to the initialization files.
        /// This mapping occurs when the initialization file and section are specified in the registry under the following key:
        /// <c>HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\IniFileMapping</c>
        /// </para>
        /// <para>
        /// When the operation has been mapped, the <see cref="GetProfileInt"/> function retrieves information from the registry,
        /// not from the initialization file; the change in the storage location has no effect on the function's behavior.
        /// </para>
        /// <para>
        /// The profile functions use the following steps to locate initialization information:
        /// </para>
        /// <para>
        /// <list type="number">
        /// <item>
        /// <description>
        /// Look in the registry for the name of the initialization file under the <c>IniFileMapping</c> key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Look for the section name specified by <paramref name="lpAppName"/>.
        /// This will be a named value under the key that has the name of the initialization file,
        /// or a subkey with this name, or the name will not exist as either a value or subkey.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <paramref name="lpAppName"/> is a named value,
        /// then that value specifies where in the registry you will find the keys for the section.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <paramref name="lpAppName"/> is a subkey,
        /// then named values under that subkey specify where in the registry you will find the keys for the section.
        /// If the key you are looking for does not exist as a named value,
        /// then there will be an unnamed value (shown as &lt;No Name&gt;)
        /// that specifies the default location in the registry where you will find the key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <paramref name="lpAppName"/> does not exist as a named value or as a subkey,
        /// then there will be an unnamed value (shown as &lt;No Name&gt;)
        /// that specifies the default location in the registry where you will find the keys for the section.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If there is no subkey or entry for the section name,
        /// then look for the actual initialization file on the disk and read its contents.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// When looking at values in the registry that specify other registry locations,
        /// there are several prefixes that change the behavior of the .ini file mapping:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// ! - this character forces all writes to go both to the registry and to the .ini file on disk.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// # - this character causes the registry value to be set to the value 
        /// in the Windows 3.1 .ini file when a new user logs in for the first time after setup.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// @ - this character prevents any reads from going to the .ini file on disk if the requested data is not found in the registry.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// USR: - this prefix stands for <see cref="HKEY_CURRENT_USER"/>, and the text after the prefix is relative to that key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// SYS: - this prefix stands for <c>HKEY_LOCAL_MACHINE\SOFTWARE</c>, and the text after the prefix is relative to that key.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit Windows-based applications. " +
            "Applications should store initialization information in the registry.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetProfileIntW", ExactSpelling = true)]
        public static extern UINT GetProfileInt([In] LPCWSTR lpAppName, [In] LPCWSTR lpKeyName, [In] INT nDefault);

        /// <summary>
        /// <para>
        /// Retrieves all the keys and values for the specified section of the Win.ini file.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getprofilesectionw"/>
        /// </para>
        /// </summary>
        /// <param name="lpAppName">
        /// The name of the section in the Win.ini file.
        /// </param>
        /// <param name="lpReturnedString">
        /// A pointer to a buffer that receives the keys and values associated with the named section.
        /// The buffer is filled with one or more null-terminated strings;
        /// the last string is followed by a second null character.
        /// </param>
        /// <param name="nSize">
        /// <para>
        /// The size of the buffer pointed to by the <paramref name="lpReturnedString"/> parameter, in characters.
        /// </para>
        /// <para>
        /// The maximum profile section size is 32,767 characters.
        /// </para>
        /// </param>
        /// <returns>
        /// The return value specifies the number of characters copied to the specified buffer, not including the terminating null character.
        /// If the buffer is not large enough to contain all the keys and values associated with the named section,
        /// the return value is equal to the size specified by <paramref name="nSize"/> minus two.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The format of the returned keys and values is one or more null-terminated strings, followed by a final null character.
        /// Each string has the following form: <c>key=string</c>
        /// </para>
        /// <para>
        /// The <see cref="GetProfileSection"/> function is not case-sensitive;
        /// the strings can be a combination of uppercase and lowercase letters.
        /// </para>
        /// <para>
        /// This operation is atomic; no updates to the Win.ini file are allowed
        /// while the keys and values for the section are being copied to the buffer.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP/2000:
        /// Calls to profile functions may be mapped to the registry instead of to the initialization files.
        /// This mapping occurs when the initialization file and section are specified in the registry under the following key:
        /// <c>HKEY_LOCAL_MACHINE\Software\Microsoft\Windows NT\CurrentVersion\IniFileMapping</c>.
        /// </para>
        /// <para>
        /// When the operation has been mapped, the <see cref="GetProfileSection"/> function retrieves information
        /// from the registry, not from the initialization file;
        /// the change in the storage location has no effect on the function's behavior.
        /// </para>
        /// <para>
        /// The profile functions use the following steps to locate initialization information:
        /// </para>
        /// <para>
        /// <list type="number">
        /// <item>
        /// <description>
        /// Look in the registry for the name of the initialization file under the IniFileMapping key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Look for the section name specified by <paramref name="lpAppName"/>.
        /// This will be a named value under the key that has the name of the initialization file
        /// , or a subkey with this name, or the name will not exist as either a value or subkey.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <paramref name="lpAppName"/> is a named value,
        /// then that value specifies where in the registry you will find the keys for the section.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <paramref name="lpAppName"/> is a subkey,
        /// then named values under that subkey specify where in the registry you will find the keys for the section.
        /// If the key you are looking for does not exist as a named value,
        /// then there will be an unnamed value (shown as &lt;No Name&gt;)
        /// that specifies the default location in the registry where you will find the key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <paramref name="lpAppName"/> does not exist as a named value or as a subkey,
        /// then there will be an unnamed value (shown as &lt;No Name&gt;)
        /// that specifies the default location in the registry where you will find the keys for the section.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If there is no subkey or entry for the section name,
        /// then look for the actual initialization file on the disk and read its contents.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// When looking at values in the registry that specify other registry locations,
        /// there are several prefixes that change the behavior of the .ini file mapping:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// ! - this character forces all writes to go both to the registry and to the .ini file on disk.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// # - this character causes the registry value to be set to the value
        /// in the Windows 3.1 .ini file when a new user logs in for the first time after setup.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// @ - this character prevents any reads from going to the .ini file on disk
        /// if the requested data is not found in the registry.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// USR: - this prefix stands for <see cref="HKEY_CURRENT_USER"/>,
        /// and the text after the prefix is relative to that key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// SYS: - this prefix stands for <c>HKEY_LOCAL_MACHINE\SOFTWARE</c>,
        /// and the text after the prefix is relative to that key.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit Windows-based applications. " +
            "Applications should store initialization information in the registry.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetProfileSectionW", ExactSpelling = true)]
        public static extern DWORD GetProfileSection([In] LPCWSTR lpAppName, [In] LPWSTR lpReturnedString, [In] DWORD nSize);

        /// <summary>
        /// <para>
        /// Retrieves the string associated with a key in the specified section of the Win.ini file.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getprofilestringw"/>
        /// </para>
        /// </summary>
        /// <param name="lpAppName">
        /// The name of the section containing the key.
        /// If this parameter is <see cref="NULL"/>, the function copies all section names in the file to the supplied buffer.
        /// </param>
        /// <param name="lpKeyName">
        /// The name of the key whose associated string is to be retrieved.
        /// If this parameter is <see cref="NULL"/>, the function copies all keys in the given section to the supplied buffer.
        /// Each string is followed by a null character, and the final string is followed by a second null character.
        /// </param>
        /// <param name="lpDefault">
        /// <para>
        /// A default string.
        /// If the <paramref name="lpKeyName"/> key cannot be found in the initialization file,
        /// <see cref="GetProfileString"/> copies the default string to the <paramref name="lpReturnedString"/> buffer.
        /// If this parameter is <see cref="NULL"/>, the default is an empty string, "".
        /// </para>
        /// <para>
        /// Avoid specifying a default string with trailing blank characters. 
        /// The function inserts a null character in the <paramref name="lpReturnedString"/> buffer to strip any trailing blanks.
        /// </para>
        /// </param>
        /// <param name="lpReturnedString">
        /// A pointer to a buffer that receives the character string.
        /// </param>
        /// <param name="nSize">
        /// The size of the buffer pointed to by the <paramref name="lpReturnedString"/> parameter, in characters.
        /// </param>
        /// <returns>
        /// <para>
        /// The return value is the number of characters copied to the buffer,
        /// not including the terminating <c>null</c> character.
        /// </para>
        /// <para>
        /// If neither <paramref name="lpAppName"/> nor <paramref name="lpKeyName"/> is <see cref="NULL"/>
        /// and the supplied destination buffer is too small to hold the requested string,
        /// the string is truncated and followed by a <c>null</c> character,
        /// and the return value is equal to <paramref name="nSize"/> minus one.
        /// </para>
        /// <para>
        /// If either <paramref name="lpAppName"/> or <paramref name="lpKeyName"/> is <see cref="NULL"/>
        /// and the supplied destination buffer is too small to hold all the strings,
        /// the last string is truncated and followed by two <c>null</c> characters.
        /// In this case, the return value is equal to <paramref name="nSize"/> minus two.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the string associated with the <paramref name="lpKeyName"/> parameter is enclosed in single or double quotation marks,
        /// the marks are discarded when the <see cref="GetProfileString"/> function returns the string.
        /// </para>
        /// <para>
        /// The <see cref="GetProfileString"/> function is not case-sensitive;
        /// the strings can contain a combination of uppercase and lowercase letters.
        /// </para>
        /// <para>
        /// A section in the Win.ini file must have the following form:
        /// </para>
        /// <code>
        /// [section]
        /// key=string
        /// .
        /// .
        /// .
        /// </code>
        /// <para>
        /// An application can use the <see cref="GetPrivateProfileString"/> function to retrieve a string from a specified initialization file.
        /// </para>
        /// <para>
        /// The <paramref name="lpDefault"/> parameter must point to a valid string,
        /// even if the string is empty (that is, even if its first character is a <c>null</c> character).
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP/2000:
        /// Calls to profile functions may be mapped to the registry instead of to the initialization files.
        /// This mapping occurs when the initialization file and section are specified in the registry under the following keys:
        /// </para>
        /// <para>
        /// <c>HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\IniFileMapping</c>
        /// </para>
        /// <para>
        /// When the operation has been mapped, the <see cref="GetProfileString"/> function retrieves information from the registry,
        /// not from the initialization file; the change in the storage location has no effect on the function's behavior.
        /// </para>
        /// <para>
        /// The profile functions use the following steps to locate initialization information:
        /// </para>
        /// <para>
        /// <list type="number">
        /// <item>
        /// <description>
        /// Look in the registry for the name of the initialization file under the <c>IniFileMapping</c> key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Look for the section name specified by <paramref name="lpAppName"/>.
        /// This will be a named value under the key that has the name of the initialization file,
        /// or a subkey with this name, or the name will not exist as either a value or subkey.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <paramref name="lpAppName"/> is a named value,
        /// then that value specifies where in the registry you will find the keys for the section.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <paramref name="lpAppName"/> is a subkey
        /// , then named values under that subkey specify where in the registry you will find the keys for the section.
        /// If the key you are looking for does not exist as a named value,
        /// then there will be an unnamed value (shown as &lt;No Name&gt;)
        /// that specifies the default location in the registry where you will find the key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <paramref name="lpAppName"/> does not exist as a named value or as a subkey,
        /// then there will be an unnamed value (shown as &lt;No Name&gt;)
        /// that specifies the default location in the registry where you will find the keys for the section.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If there is no subkey or entry for the section name,
        /// then look for the actual initialization file on the disk and read its contents.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// When looking at values in the registry that specify other registry locations,
        /// there are several prefixes that change the behavior of the .ini file mapping:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// ! - this character forces all writes to go both to the registry and to the .ini file on disk.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// # - this character causes the registry value to be set to the value 
        /// in the Windows 3.1 .ini file when a new user logs in for the first time after setup.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// @ - this character prevents any reads from going to the .ini file on disk if the requested data is not found in the registry.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// USR: - this prefix stands for <see cref="HKEY_CURRENT_USER"/>, and the text after the prefix is relative to that key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// SYS: - this prefix stands for <c>HKEY_LOCAL_MACHINE\SOFTWARE</c>, and the text after the prefix is relative to that key.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit Windows-based applications, " +
            "therefore this function should not be called from server code. Applications should store initialization information in the registry.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetProfileStringW", ExactSpelling = true)]
        public static extern DWORD GetProfileString([In] LPCWSTR lpAppName, [In] LPCWSTR lpKeyName, [In] LPCWSTR lpDefault,
            [In] LPWSTR lpReturnedString, [In] DWORD nSize);

        /// <summary>
        /// <para>
        /// Replaces the keys and values for the specified section in an initialization file.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-writeprivateprofilesectionw"/>
        /// </para>
        /// </summary>
        /// <param name="lpAppName">
        /// The name of the section in which data is written.
        /// This section name is typically the name of the calling application.
        /// </param>
        /// <param name="lpString">
        /// The new key names and associated values that are to be written to the named section.
        /// This string is limited to 65,535 bytes.
        /// </param>
        /// <param name="lpFileName">
        /// <para>
        /// The name of the initialization file.
        /// If this parameter does not contain a full path for the file,
        /// the function searches the Windows directory for the file.
        /// If the file does not exist and <paramref name="lpFileName"/> does not contain a full path,
        /// the function creates the file in the Windows directory.
        /// </para>
        /// <para>
        /// If the file exists and was created using Unicode characters,
        /// the function writes Unicode characters to the file.
        /// Otherwise, the function creates a file using ANSI characters.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The data in the buffer pointed to by the <paramref name="lpString"/> parameter
        /// consists of one or more null-terminated strings, followed by a final null character.
        /// Each string has the following form:
        /// </para>
        /// <para>
        /// <c>key=string</c>
        /// </para>
        /// <para>
        /// The <see cref="WritePrivateProfileSection"/> function is not case-sensitive;
        /// the string pointed to by the <paramref name="lpAppName"/> parameter can be a combination of uppercase and lowercase letters.
        /// </para>
        /// <para>
        /// If no section name matches the string pointed to by the <paramref name="lpAppName"/> parameter,
        /// <see cref="WritePrivateProfileSection"/> creates the section at the end of the specified initialization file
        /// and initializes the new section with the specified key name and value pairs.
        /// </para>
        /// <para>
        /// <see cref="WritePrivateProfileSection"/> deletes the existing keys and values for the named section
        /// and inserts the key names and values in the buffer pointed to by the <paramref name="lpString"/> parameter.
        /// The function does not attempt to correlate old and new key names;
        /// if the new names appear in a different order from the old names,
        /// any comments associated with preexisting keys and values in the initialization file
        /// will probably be associated with incorrect keys and values.
        /// </para>
        /// <para>
        /// This operation is atomic; no operations that read from or write to the specified initialization file
        /// are allowed while the information is being written.
        /// </para>
        /// <para>
        /// The system keeps a cached version of the most recent registry file mapping to improve performance.
        /// If all parameters are <see cref="NULL"/>, the function flushes the cache.
        /// While the system is editing the cached version of the file,
        /// processes that edit the file itself will use the original file until the cache has been cleared.
        /// </para>
        /// <para>
        /// The system maps most .ini file references to the registry, using the mapping defined under the following registry key:
        /// </para>
        /// <c>HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\IniFileMapping</c>
        /// <para>
        /// This mapping is likely if an application modifies system-component initialization files,
        /// such as Control.ini, System.ini, and Winfile.ini.
        /// In this case, the function writes information to the registry, not to the initialization file;
        /// the change in the storage location has no effect on the function's behavior.
        /// </para>
        /// <para>
        /// The profile functions use the following steps to locate initialization information:
        /// </para>
        /// <para>
        /// <list type="number">
        /// <item>
        /// <description>
        /// Look in the registry for the name of the initialization file under the IniFileMapping key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Look for the section name specified by <paramref name="lpAppName"/>.
        /// This will be a named value under the key that has the name of the initialization file,
        /// or a subkey with this name, or the name will not exist as either a value or subkey.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <paramref name="lpAppName"/> is a named value,
        /// then that value specifies where in the registry you will find the keys for the section.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <paramref name="lpAppName"/> is a subkey,
        /// then named values under that subkey specify where in the registry you will find the keys for the section.
        /// If the key you are looking for does not exist as a named value,
        /// then there will be an unnamed value (shown as &lt;No Name&gt;)
        /// that specifies the default location in the registry where you will find the key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <paramref name="lpAppName"/> does not exist as a named value or as a subkey,
        /// then there will be an unnamed value (shown as &lt;No Name&gt;)
        /// that specifies the default location in the registry where you will find the keys for the section.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If there is no subkey or entry for the section name,
        /// then look for the actual initialization file on the disk and read its contents.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// When looking at values in the registry that specify other registry locations,
        /// there are several prefixes that change the behavior of the .ini file mapping:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// ! - this character forces all writes to go both to the registry and to the .ini file on disk.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// # - this character causes the registry value to be set to the value in the Windows 3.1 .ini file
        /// when a new user logs in for the first time after setup.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// @ - this character prevents any reads from going to the .ini file on disk
        /// if the requested data is not found in the registry.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// USR: - this prefix stands for <see cref="HKEY_CURRENT_USER"/>,
        /// and the text after the prefix is relative to that key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// SYS: - this prefix stands for <c>HKEY_LOCAL_MACHINE\SOFTWARE</c>,
        /// and the text after the prefix is relative to that key.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit Windows-based applications. " +
            "Applications should store initialization information in the registry.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WritePrivateProfileSectionW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL WritePrivateProfileSection([In] LPCWSTR lpAppName, [In] LPCWSTR lpString, [In] LPCWSTR lpFileName);

        /// <summary>
        /// <para>
        /// Copies a string into the specified section of an initialization file.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-writeprivateprofilestringw"/>
        /// </para>
        /// </summary>
        /// <param name="lpAppName">
        /// The name of the section to which the string will be copied. If the section does not exist, it is created.
        /// The name of the section is case-independent; the string can be any combination of uppercase and lowercase letters.
        /// </param>
        /// <param name="lpKeyName">
        /// The name of the key to be associated with a string. If the key does not exist in the specified section, it is created.
        /// If this parameter is <see cref="NULL"/>, the entire section, including all entries within the section, is deleted.
        /// </param>
        /// <param name="lpString">
        /// A null-terminated string to be written to the file.
        /// If this parameter is <see cref="NULL"/>, the key pointed to by the <paramref name="lpKeyName"/> parameter is deleted.
        /// </param>
        /// <param name="lpFileName">
        /// <para>
        /// The name of the initialization file.
        /// </para>
        /// <para>
        /// If the file already exists and consists of Unicode characters, the function writes Unicode characters to the file.
        /// Otherwise, the function writes ANSI characters.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function successfully copies the string to the initialization file, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, or if it flushes the cached version of the most recently accessed initialization file, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
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
        /// <para>
        /// If the <paramref name="lpFileName"/> parameter does not contain a full path and file name for the file,
        /// <see cref="WritePrivateProfileString"/> searches the Windows directory for the file.
        /// If the file does not exist, this function creates the file in the Windows directory.
        /// </para>
        /// <para>
        /// If <paramref name="lpFileName"/> contains a full path and file name and the file does not exist,
        /// <see cref="WritePrivateProfileString"/> creates the file.
        /// The specified directory must already exist.
        /// </para>
        /// <para>
        /// The system keeps a cached version of the most recent registry file mapping to improve performance.
        /// If all parameters are <see cref="NULL"/>, the function flushes the cache.
        /// While the system is editing the cached version of the file,
        /// processes that edit the file itself will use the original file until the cache has been cleared.
        /// </para>
        /// <para>
        /// The system maps most .ini file references to the registry, using the mapping defined under the following registry key:
        /// </para>
        /// <para>
        /// <c>HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\IniFileMapping</c>
        /// </para>
        /// <para>
        /// This mapping is likely if an application modifies system-component initialization files,
        /// such as Control.ini, System.ini, and Winfile.ini. In this case, the function writes information to the registry,
        /// not to the initialization file; the change in the storage location has no effect on the function's behavior.
        /// </para>
        /// <para>
        /// The profile functions use the following steps to locate initialization information:
        /// </para>
        /// <para>
        /// <list type="number">
        /// <item>
        /// <description>
        /// Look in the registry for the name of the initialization file under the <c>IniFileMapping</c> key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Look for the section name specified by <paramref name="lpAppName"/>.
        /// This will be a named value under the key that has the name of the initialization file,
        /// or a subkey with this name, or the name will not exist as either a value or subkey.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <paramref name="lpAppName"/> is a named value,
        /// then that value specifies where in the registry you will find the keys for the section.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <paramref name="lpAppName"/> is a subkey,
        /// then named values under that subkey specify where in the registry you will find the keys for the section.
        /// If the key you are looking for does not exist as a named value,
        /// then there will be an unnamed value (shown as &lt;No Name&gt;)
        /// that specifies the default location in the registry where you will find the key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <paramref name="lpAppName"/> does not exist as a named value or as a subkey,
        /// then there will be an unnamed value (shown as &lt;No Name&gt;)
        /// that specifies the default location in the registry where you will find the keys for the section.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If there is no subkey or entry for the section name,
        /// then look for the actual initialization file on the disk and read its contents.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// When looking at values in the registry that specify other registry locations,
        /// there are several prefixes that change the behavior of the .ini file mapping:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// ! - this character forces all writes to go both to the registry and to the .ini file on disk.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// # - this character causes the registry value to be set to the value 
        /// in the Windows 3.1 .ini file when a new user logs in for the first time after setup.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// @ - this character prevents any reads from going to the .ini file on disk if the requested data is not found in the registry.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// USR: - this prefix stands for <see cref="HKEY_CURRENT_USER"/>, and the text after the prefix is relative to that key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// SYS: - this prefix stands for <c>HKEY_LOCAL_MACHINE\SOFTWARE</c>, and the text after the prefix is relative to that key.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// An application using the <see cref="WritePrivateProfileString"/> function to enter .ini file information into the registry should follow these guidelines:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Ensure that no .ini file of the specified name exists on the system.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Ensure that there is a key entry in the registry that specifies the .ini file.
        /// This entry should be under the path <c>HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\IniFileMapping</c>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Specify a value for that .ini file key entry that specifies a section.
        /// That is to say, an application must specify a section name, as it would appear within an .ini file or registry entry.
        /// Here is an example: <c>[My Section]</c>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// For system files, specify SYS for an added value.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// For application files, specify USR within the added value.
        /// Here is an example: "My Section: USR: App Name\Section".
        /// And, since USR indicates a mapping under <see cref="HKEY_CURRENT_USER"/>,
        /// the application should also create a key under <see cref="HKEY_CURRENT_USER"/>
        /// that specifies the application name listed in the added value.
        /// For the example just given, that would be "App Name".
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// After following the preceding steps, an application setup program should call <see cref="WritePrivateProfileString"/>
        /// with the first three parameters set to <see cref="NULL"/>, and the fourth parameter set to the INI file name.
        /// For example:
        /// </para>
        /// <para>
        /// <c>WritePrivateProfileString( NULL, NULL, NULL, L"appname.ini" );</c>
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Such a call causes the mapping of an .ini file to the registry to take effect before the next system reboot.
        /// The system rereads the mapping information into shared memory.
        /// A user will not have to reboot their computer after installing an application
        /// in order to have future invocations of the application see the mapping of the .ini file to the registry.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit Windows-based applications. " +
            "Applications should store initialization information in the registry.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WritePrivateProfileStringW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL WritePrivateProfileString([In] LPCWSTR lpAppName, [In] LPCWSTR lpKeyName,
            [In] LPCWSTR lpString, [In] LPCWSTR lpFileName);

        /// <summary>
        /// Copies data into a key in the specified section of an initialization file.
        /// As it copies the data, the function calculates a checksum and appends it to the end of the data.
        /// The <see cref="GetPrivateProfileStruct"/> function uses the checksum to ensure the integrity of the data.
        /// </summary>
        /// <param name="lpszSection">
        /// The name of the section to which the struct data will be copied.
        /// If the section does not exist, it is created.
        /// The name of the section is case independent.
        /// </param>
        /// <param name="lpszKey">
        /// The name of the key to be associated with a struct.
        /// If the key does not exist in the specified section, it is created.
        /// If this parameter is <see cref="NULL"/>, the entire section,
        /// including all keys and entries within the section, is deleted.
        /// </param>
        /// <param name="lpStruct">
        /// The data to be copied.
        /// If this parameter is <see cref="NULL"/>, the key is deleted.
        /// </param>
        /// <param name="uSizeStruct">
        /// The size of the buffer pointed to by the <paramref name="lpStruct"/> parameter, in bytes.
        /// </param>
        /// <param name="szFile">
        /// <para>
        /// The name of the initialization file.
        /// If this parameter is <see cref="NULL"/>, the information is copied into the Win.ini file.
        /// </para>
        /// <para>
        /// If the file was created using Unicode characters, the function writes Unicode characters to the file.
        /// Otherwise, the function writes ANSI characters.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function successfully copies the struct to the initialization file, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, or if it flushes the cached version of the most recently accessed initialization file,
        /// the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// A section in the initialization file must have the following form:
        /// </para>
        /// <code>
        /// [section]
        /// key=struct
        /// 
        ///       .
        ///       .
        ///       .
        /// </code>
        /// <para>
        /// If the <paramref name="szFile"/> parameter does not contain a full path and file name for the file,
        /// <see cref="WritePrivateProfileString"/> searches the Windows directory for the file.
        /// If the file does not exist, this function creates the file in the Windows directory.
        /// </para>
        /// <para>
        /// If <paramref name="szFile"/> contains a full path and file name and the file does not exist,
        /// <see cref="WriteProfileString"/> creates the file. The specified directory must already exist.
        /// </para>
        /// <para>
        /// The system keeps a cached version of the most recent registry file mapping to improve performance.
        /// If all parameters are <see cref="NULL"/>, the function flushes the cache.
        /// While the system is editing the cached version of the file,
        /// processes that edit the file itself will use the original file until the cache has been cleared.
        /// </para>
        /// <para>
        /// The system maps most .ini file references to the registry,
        /// using the mapping defined under the following registry key:
        /// </para>
        /// <para>
        /// This mapping is likely if an application modifies system-component initialization files,
        /// such as Control.ini, System.ini, and Winfile.ini.
        /// In this case, the function writes information to the registry, not to the initialization file;
        /// the change in the storage location has no effect on the function's behavior.
        /// </para>
        /// <para>
        /// The profile functions use the following steps to locate initialization information:
        /// </para>
        /// <para>
        /// <list type="number">
        /// <item>
        /// <description>
        /// Look in the registry for the name of the initialization file under the IniFileMapping key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Look for the section name specified by <c>lpAppName</c>.
        /// This will be a named value under the key that has the name of the initialization file,
        /// or a subkey with this name, or the name will not exist as either a value or subkey.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <c>lpAppName</c> is a named value,
        /// then that value specifies where in the registry you will find the keys for the section.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <c>lpAppName</c> is a subkey,
        /// then named values under that subkey specify where in the registry you will find the keys for the section.
        /// If the key you are looking for does not exist as a named value,
        /// then there will be an unnamed value (shown as &lt;No Name&gt;)
        /// that specifies the default location in the registry where you will find the key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <c>lpAppName</c> does not exist as a named value or as a subkey,
        /// then there will be an unnamed value (shown as &lt;No Name&gt;)
        /// that specifies the default location in the registry where you will find the keys for the section.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If there is no subkey or entry for the section name,
        /// then look for the actual initialization file on the disk and read its contents.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// When looking at values in the registry that specify other registry locations,
        /// there are several prefixes that change the behavior of the .ini file mapping:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// ! - this character forces all writes to go both to the registry and to the .ini file on disk.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// # - this character causes the registry value to be set to the value in the Windows 3.1 .ini file
        /// when a new user logs in for the first time after setup.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// @ - this character prevents any reads from going to the .ini file on disk
        /// if the requested data is not found in the registry.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// USR: - this prefix stands for <see cref="HKEY_CURRENT_USER"/>,
        /// and the text after the prefix is relative to that key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// SYS: - this prefix stands for <c>HKEY_LOCAL_MACHINE\SOFTWARE</c>,
        /// and the text after the prefix is relative to that key.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit Windows-based applications. " +
            "Applications should store initialization information in the registry.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WritePrivateProfileStructW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL WritePrivateProfileStruct([In] LPCWSTR lpszSection, [In] LPCWSTR lpszKey, [In] LPVOID lpStruct,
            [In] UINT uSizeStruct, [In] LPCWSTR szFile);

        /// <summary>
        /// <para>
        /// Replaces the contents of the specified section in the Win.ini file with specified keys and values.
        /// If Win.ini uses Unicode characters, the function writes Unicode characters to the file.
        /// Otherwise, the function writes ANSI characters.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-writeprofilesectionw"/>
        /// </para>
        /// </summary>
        /// <param name="lpAppName">
        /// The name of the section.
        /// This section name is typically the name of the calling application.
        /// </param>
        /// <param name="lpString">
        /// <para>
        /// The new key names and associated values that are to be written to the named section.
        /// This string is limited to 65,535 bytes.
        /// </para>
        /// <para>
        /// If the file exists and was created using Unicode characters, the function writes Unicode characters to the file.
        /// Otherwise, the function creates a file using ANSI characters.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Keys and values in the <paramref name="lpString"/> buffer consist of one or more null-terminated strings,
        /// followed by a final null character.
        /// Each string has the following form: <c>key=string</c>.
        /// </para>
        /// <para>
        /// The <see cref="WriteProfileSection"/> function is not case-sensitive;
        /// the strings can be a combination of uppercase and lowercase letters.
        /// </para>
        /// <para>
        /// <see cref="WriteProfileSection"/> deletes the existing keys and values for the named section
        /// and inserts the key names and values in the buffer pointed to by <paramref name="lpString"/>.
        /// The function does not attempt to correlate old and new key names;
        /// if the new names appear in a different order from the old names,
        /// any comments associated with preexisting keys and values in the initialization file
        /// will probably be associated with incorrect keys and values.
        /// </para>
        /// <para>
        /// This operation is atomic; no other operations that read from or write to the initialization file
        /// are allowed while the information is being written.
        /// </para>
        /// <para>
        /// The system keeps a cached version of the most recent registry file mapping to improve performance.
        /// If all parameters are <see cref="NULL"/>, the function flushes the cache.
        /// While the system is editing the cached version of the file,
        /// processes that edit the file itself will use the original file until the cache has been cleared.
        /// </para>
        /// <para>
        /// The system maps most .ini file references to the registry, using the mapping defined under the following registry key:
        /// </para>
        /// <para>
        /// <c>
        /// HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\IniFileMapping
        /// </c>
        /// <para>
        /// When the operation has been mapped, the <see cref="WriteProfileSection"/> function writes information to the registry,
        /// not to the initialization file; the change in the storage location has no effect on the function's behavior.
        /// </para>
        /// <para>
        /// The profile functions use the following steps to locate initialization information:
        /// </para>
        /// <para>
        /// <list type="number">
        /// <item>
        /// <description>
        /// Look in the registry for the name of the initialization file under the IniFileMapping key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Look for the section name specified by <paramref name="lpAppName"/>.
        /// This will be a named value under the key that has the name of the initialization file,
        /// or a subkey with this name, or the name will not exist as either a value or subkey.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <paramref name="lpAppName"/> is a named value,
        /// then that value specifies where in the registry you will find the keys for the section.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <paramref name="lpAppName"/> is a subkey,
        /// then named values under that subkey specify where in the registry you will find the keys for the section.
        /// If the key you are looking for does not exist as a named value,
        /// then there will be an unnamed value (shown as &lt;No Name&gt;)
        /// that specifies the default location in the registry where you will find the key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <paramref name="lpAppName"/> does not exist as a named value or as a subkey,
        /// then there will be an unnamed value (shown as &lt;No Name&gt;)
        /// that specifies the default location in the registry where you will find the keys for the section.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If there is no subkey or entry for the section name,
        /// then look for the actual initialization file on the disk and read its contents.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// When looking at values in the registry that specify other registry locations,
        /// there are several prefixes that change the behavior of the .ini file mapping:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// ! - this character forces all writes to go both to the registry and to the .ini file on disk.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// # - this character causes the registry value to be set to the value in the Windows 3.1 .ini file
        /// when a new user logs in for the first time after setup.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// @ - this character prevents any reads from going to the .ini file on disk
        /// if the requested data is not found in the registry.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// USR: - this prefix stands for <see cref="HKEY_CURRENT_USER"/>,
        /// and the text after the prefix is relative to that key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// SYS: - this prefix stands for <c>HKEY_LOCAL_MACHINE\SOFTWARE</c>,
        /// and the text after the prefix is relative to that key.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit Windows-based applications. " +
            "Applications should store initialization information in the registry.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WriteProfileSectionW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL WriteProfileSection([In] LPCWSTR lpAppName, [In] LPCWSTR lpString);

        /// <summary>
        /// <para>
        /// Copies a string into the specified section of the Win.ini file.
        /// If Win.ini uses Unicode characters, the function writes Unicode characters to the file.
        /// Otherwise, the function writes ANSI characters.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-writeprofilestringw"/>
        /// </para>
        /// </summary>
        /// <param name="lpAppName">
        /// The section to which the string is to be copied. If the section does not exist, it is created.
        /// The name of the section is not case-sensitive; the string can be any combination of uppercase and lowercase letters.
        /// </param>
        /// <param name="lpKeyName">
        /// The key to be associated with the string.
        /// If the key does not exist in the specified section, it is created.
        /// If this parameter is <see cref="NULL"/>, the entire section, including all entries in the section, is deleted.
        /// </param>
        /// <param name="lpString">
        /// A null-terminated string to be written to the file.
        /// If this parameter is <see cref="NULL"/>, the key pointed to by the <paramref name="lpKeyName"/> parameter is deleted.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function successfully copies the string to the Win.ini file, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, or if it flushes the cached version of Win.ini, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// A section in the Win.ini file must have the following form: <c>key=string</c>.
        /// </para>
        /// <para>
        /// The system keeps a cached version of the most recent registry file mapping to improve performance.
        /// If all parameters are <see cref="NULL"/>, the function flushes the cache.
        /// While the system is editing the cached version of the file,
        /// processes that edit the file itself will use the original file until the cache has been cleared.
        /// </para>
        /// <para>
        /// The system maps most .ini file references to the registry, using the mapping defined under the following registry key:
        /// </para>
        /// <para>
        /// <c>HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\IniFileMapping</c>
        /// </para>
        /// <para>
        /// When the operation has been mapped, the <see cref="WriteProfileString"/> function writes information to the registry,
        /// not to the initialization file; the change in the storage location has no effect on the function's behavior.
        /// </para>
        /// <para>
        /// The profile functions use the following steps to locate initialization information:
        /// </para>
        /// <para>
        /// <list type="number">
        /// <item>
        /// <description>
        /// Look in the registry for the name of the initialization file under the <c>IniFileMapping</c> key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Look for the section name specified by <paramref name="lpAppName"/>.
        /// This will be a named value under the key that has the name of the initialization file,
        /// or a subkey with this name, or the name will not exist as either a value or subkey.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <paramref name="lpAppName"/> is a named value,
        /// then that value specifies where in the registry you will find the keys for the section.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <paramref name="lpAppName"/> is a subkey,
        /// then named values under that subkey specify where in the registry you will find the keys for the section.
        /// If the key you are looking for does not exist as a named value,
        /// then there will be an unnamed value (shown as &lt;No Name&gt;)
        /// that specifies the default location in the registry where you will find the key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the section name specified by <paramref name="lpAppName"/> does not exist as a named value or as a subkey,
        /// then there will be an unnamed value (shown as &lt;No Name&gt;)
        /// that specifies the default location in the registry where you will find the keys for the section.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If there is no subkey or entry for the section name,
        /// then look for the actual initialization file on the disk and read its contents.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// When looking at values in the registry that specify other registry locations,
        /// there are several prefixes that change the behavior of the .ini file mapping:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// ! - this character forces all writes to go both to the registry and to the .ini file on disk.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// # - this character causes the registry value to be set to the value 
        /// in the Windows 3.1 .ini file when a new user logs in for the first time after setup.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// @ - this character prevents any reads from going to the .ini file on disk if the requested data is not found in the registry.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// USR: - this prefix stands for <see cref="HKEY_CURRENT_USER"/>, and the text after the prefix is relative to that key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// SYS: - this prefix stands for <c>HKEY_LOCAL_MACHINE\SOFTWARE</c>, and the text after the prefix is relative to that key.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit Windows-based applications. " +
            "Applications should store initialization information in the registry.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WriteProfileStringW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL WriteProfileString([In] LPCWSTR lpAppName, [In] LPCWSTR lpKeyName, [In] LPCWSTR lpString);
    }
}
