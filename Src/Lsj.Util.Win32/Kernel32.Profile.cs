﻿using Lsj.Util.Win32.BaseTypes;
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetProfileIntW", SetLastError = true)]
        public static extern UINT GetProfileInt([MarshalAs(UnmanagedType.LPWStr)][In]string lpAppName,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpKeyName, [In]INT nDefault);

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
        /// When the operation has been mapped, the <see cref="GetProfileString "/> function retrieves information from the registry,
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetProfileStringW", SetLastError = true)]
        public static extern DWORD GetProfileString([MarshalAs(UnmanagedType.LPWStr)][In]string lpAppName,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpKeyName, [MarshalAs(UnmanagedType.LPWStr)][In]string lpDefault,
            [MarshalAs(UnmanagedType.LPWStr)][Out]StringBuilder lpReturnedString, [In]DWORD nSize);
    }
}
