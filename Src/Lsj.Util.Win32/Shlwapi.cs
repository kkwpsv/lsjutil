﻿using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HKEY;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.FormatMessageFlags;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Shlwapi.dll
    /// </summary>
    public static class Shlwapi
    {
        /// <summary>
        /// <para>
        /// Checks for specified operating systems and operating system features.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shlwapi/nf-shlwapi-isos"/>
        /// </para>
        /// </summary>
        /// <param name="dwOS"></param>
        /// <returns></returns>
        [DllImport("Shlwapi.dll", CharSet = CharSet.Unicode, EntryPoint = "IsOS", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsOS([In] OSFeatures dwOS);

        /// <summary>
        /// <para>
        /// Searches for a file.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shlwapi/nf-shlwapi-pathfindonpathw"/>
        /// </para>
        /// </summary>
        /// <param name="pszPath">
        /// A pointer to a null-terminated string of length <see cref="MAX_PATH"/> that contains the file name for which to search.
        /// If the search is successful, this parameter is used to return the fully qualified path name.
        /// </param>
        /// <param name="ppszOtherDirs">
        /// An optional, null-terminated array of directories to be searched first.
        /// This value can be <see langword="null"/>.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful, or <see cref="FALSE"/> otherwise.
        /// </returns>
        /// <remarks>
        /// <see cref="PathFindOnPath"/> searches for the file specified by <paramref name="pszPath"/>.
        /// If no directories are specified in <paramref name="ppszOtherDirs"/>,
        /// it attempts to find the file by searching standard directories such as System32 and the directories specified in the PATH environment variable.
        /// To expedite the process or enable <see cref="PathFindOnPath"/> to search a wider range of directories,
        /// use the <paramref name="ppszOtherDirs"/> parameter to specify one or more directories to be searched first.
        /// If more than one file has the name specified by <paramref name="pszPath"/>, <see cref="PathFindOnPath"/> returns the first instance it finds.
        /// </remarks>
        [DllImport("Shlwapi.dll", CharSet = CharSet.Unicode, EntryPoint = "PathFindOnPathW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL PathFindOnPath([In] LPWSTR pszPath, [In] string[] ppszOtherDirs);

        /// <summary>
        /// <para>
        /// Recursively copies the subkeys and values of the source subkey to the destination key.
        /// <see cref="SHCopyKey"/> does not copy the security attributes of the keys.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shlwapi/nf-shlwapi-shcopykeyw"/>
        /// </para>
        /// </summary>
        /// <param name="hkeySrc">
        /// A handle to the source key (for example, <see cref="HKEY_CURRENT_USER"/>).
        /// </param>
        /// <param name="pszSrcSubKey">
        /// The subkey whose subkeys and values are to be copied.
        /// </param>
        /// <param name="hkeyDest">
        /// The destination key.
        /// </param>
        /// <param name="fReserved">
        /// Reserved. Must be 0.
        /// </param>
        /// <returns>
        /// Returns <see cref="ERROR_SUCCESS"/> if successful, or one of the nonzero error codes defined in Winerror.h otherwise.
        /// Use <see cref="FormatMessage"/> with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag to retrieve a generic description of the error.
        /// </returns>
        /// <remarks>
        /// Important
        /// This function does not duplicate the security attributes of the keys and values that it copies.
        /// Rather, all security attributes in the destination key are the default attributes.
        /// The shlwapi.h header defines <see cref="SHCopyKey"/> as an alias which automatically selects the ANSI or Unicode version
        /// of this function based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead to
        /// mismatches that result in compilation or runtime errors.
        /// For more information, see Conventions for Function Prototypes.
        /// </remarks>
        [DllImport("Shlwapi.dll", CharSet = CharSet.Unicode, EntryPoint = "SHCopyKeyW", ExactSpelling = true, SetLastError = true)]
        public static extern LSTATUS SHCopyKey([In] HKEY hkeySrc, [MarshalAs(UnmanagedType.LPWStr)][In] string pszSrcSubKey,
            [In] HKEY hkeyDest, [In] DWORD fReserved);

        /// <summary>
        /// <para>
        /// Deletes a subkey and all its descendants.
        /// This function removes the key and all the key's values from the registry.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shlwapi/nf-shlwapi-shdeletekeyw"/>
        /// </para>
        /// </summary>
        /// <param name="hkey">
        /// A handle to an open registry key, or one of the following predefined keys:
        /// <see cref="HKEY_CLASSES_ROOT"/>, <see cref="HKEY_CURRENT_CONFIG"/>, <see cref="HKEY_CURRENT_USER"/>,
        /// <see cref="HKEY_LOCAL_MACHINE"/>, <see cref="HKEY_PERFORMANCE_DATA"/>, <see cref="HKEY_USERS"/>
        /// </param>
        /// <param name="pszSubKey">
        /// The address of a null-terminated string specifying the name of the key to delete.
        /// </param>
        /// <returns>
        /// Returns <see cref="ERROR_SUCCESS"/> if successful, or one of the nonzero error codes defined in Winerror.h otherwise.
        /// Use <see cref="FormatMessage"/> with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag to retrieve a generic description of the error.
        /// </returns>
        /// <remarks>
        /// Alternatively, use the <see cref="RegDeleteKey"/> or <see cref="RegDeleteTree"/> function.
        /// The shlwapi.h header defines <see cref="SHDeleteKey"/> as an alias which automatically selects
        /// the ANSI or Unicode version of this function based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead
        /// to mismatches that result in compilation or runtime errors.
        /// For more information, see Conventions for Function Prototypes.
        /// </remarks>
        [DllImport("Shlwapi.dll", CharSet = CharSet.Unicode, EntryPoint = "SHDeleteKeyW", ExactSpelling = true, SetLastError = true)]
        public static extern LSTATUS SHDeleteKey([In] HKEY hkey, [MarshalAs(UnmanagedType.LPWStr)][In] string pszSubKey);
    }
}
