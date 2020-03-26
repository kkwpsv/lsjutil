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
    }
}
