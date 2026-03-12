using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Marshals;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.LANGID;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32
{
    public partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// An application-defined callback function used with the <see cref="EnumResourceLanguages"/> and the <see cref="EnumResourceLanguagesEx"/> functions.
        /// It receives the type, name, and language of a resource item.
        /// The <see cref="ENUMRESLANGPROC"/> type defines a pointer to this callback function.
        /// <see cref="EnumResLangProc"/> is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/libloaderapi/nc-libloaderapi-enumreslangprocw"/>
        /// </para>
        /// </summary>
        /// <param name="hModule">
        /// A handle to the module whose executable file contains the resources for which the languages are being enumerated.
        /// If this parameter is <see cref="NULL"/>,
        /// the function enumerates the resource languages in the module used to create the current process.
        /// </param>
        /// <param name="lpszType">
        /// The type of resource for which the language is being enumerated.
        /// Alternately, rather than a pointer, this parameter can be <see cref="MAKEINTRESOURCE"/>(ID),
        /// where ID is an integer value representing a predefined resource type.
        /// For standard resource types, see Resource Types.
        /// For more information, see the Remarks section below.
        /// </param>
        /// <param name="lpszName">
        /// The name of the resource for which the language is being enumerated.
        /// Alternately, rather than a pointer, this parameter can be <see cref="MAKEINTRESOURCE"/>(ID),
        /// where ID is the integer identifier of the resource.
        /// For more information, see the Remarks section below.
        /// </param>
        /// <param name="wIDLanguage">
        /// The language identifier for the resource for which the language is being enumerated.
        /// The <see cref="EnumResourceLanguages"/> or <see cref="EnumResourceLanguagesEx"/> function provides this value.
        /// For a list of the primary language identifiers and sublanguage identifiers
        /// that constitute a language identifier, see <see cref="MAKELANGID"/>.
        /// </param>
        /// <param name="lParam">
        /// The application-defined parameter passed to the <see cref="EnumResourceLanguages"/> or <see cref="EnumResourceLanguagesEx"/> function.
        /// This parameter can be used in error checking.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> to continue enumeration or <see cref="FALSE"/> to stop enumeration.
        /// </returns>
        /// <remarks>
        /// <para>
        /// If <c>IS_INTRESOURCE(lpszType)</c> is <see cref="TRUE"/>,
        /// then <paramref name="lpszType"/> specifies the integer identifier of the given resource type.
        /// Otherwise, it is a pointer to a null-terminated string.
        /// If the first character of the string is a pound sign (#),
        /// then the remaining characters represent a decimal number that specifies the integer identifier of the resource type.
        /// For example, the string "#258" represents the identifier 258.
        /// </para>
        /// <para>
        /// Similarly, if <c>IS_INTRESOURCE(lpszName)</c> is <see cref="TRUE"/>,
        /// then <paramref name="lpszName"/> specifies the integer identifier of the given resource.
        /// Otherwise, it is a pointer to a null-terminated string.
        /// If the first character of the string is a pound sign (#),
        /// then the remaining characters represent a decimal number that specifies the integer identifier of the resource.
        /// </para>
        /// <para>
        /// An application must register this function by passing its address
        /// to the <see cref="EnumResourceLanguages"/> or <see cref="EnumResourceLanguagesEx"/> function.
        /// </para>
        /// <para>
        /// If the callback function returns <see cref="FALSE"/>,
        /// then <see cref="EnumResourceLanguages"/> or <see cref="EnumResourceLanguagesEx"/> will stop enumeration and return <see cref="FALSE"/>.
        /// The value obtained from <see cref="GetLastError"/> will be <see cref="ERROR_RESOURCE_ENUM_USER_STOP"/>.
        /// </para>
        /// </remarks>
        public delegate BOOL EnumResLangProc([In] HMODULE hModule, [In] LPCWSTR lpszType, [In] LPCWSTR lpszName, [In] WORD wIDLanguage, [In] LONG_PTR lParam);

        /// <summary>
        /// <para>
        /// An application-defined callback function used with the <see cref="EnumResourceNames"/> and <see cref="EnumResourceNamesEx"/> functions.
        /// It receives the type and name of a resource.
        /// The <see cref="ENUMRESNAMEPROC"/> type defines a pointer to this callback function.
        /// <c>EnumResNameProc</c> is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/libloaderapi/nc-libloaderapi-enumresnameprocw"/>
        /// </para>
        /// </summary>
        /// <param name="hModule">
        /// A handle to the module whose executable file contains the resources that are being enumerated.
        /// If this parameter is <see cref="NULL"/>,
        /// the function enumerates the resource names in the module used to create the current process.
        /// </param>
        /// <param name="lpType">
        /// The type of resource for which the name is being enumerated.
        /// Alternately, rather than a pointer, this parameter can be <c>MAKEINTRESOURCE(ID)</c>,
        /// where ID is an integer value representing a predefined resource type.
        /// For standard resource types, see Resource Types.
        /// For more information, see the Remarks section below.
        /// </param>
        /// <param name="lpName">
        /// The name of a resource of the type being enumerated.
        /// Alternately, rather than a pointer, this parameter can be <c>MAKEINTRESOURCE(ID)</c>,
        /// where ID is the integer identifier of the resource.
        /// For more information, see the Remarks section below.
        /// </param>
        /// <param name="lParam">
        /// An application-defined parameter passed to the <see cref="EnumResourceNames"/> or <see cref="EnumResourceNamesEx"/> function.
        /// This parameter can be used in error checking.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> to continue enumeration or <see cref="FALSE"/> to stop enumeration.
        /// </returns>
        /// <remarks>
        /// <para>
        /// If <c>IS_INTRESOURCE(lpType)</c> is <see cref="TRUE"/>,
        /// then <paramref name="lpType"/> specifies the integer identifier of the given resource type.
        /// Otherwise, it is a pointer to a null-terminated string.
        /// If the first character of the string is a pound sign (#),
        /// then the remaining characters represent a decimal number that specifies the integer identifier of the resource type.
        /// For example, the string "#258" represents the identifier 258.
        /// </para>
        /// <para>
        /// Similarly, if <c>if IS_INTRESOURCE(lpName)</c> is <see cref="TRUE"/>,
        /// then <paramref name="lpName"/> specifies the integer identifier of the given resource.
        /// Otherwise, it is a pointer to a null-terminated string.
        /// If the first character of the string is a pound sign (#),
        /// then the remaining characters represent a decimal number that specifies the integer identifier of the resource.
        /// </para>
        /// <para>
        /// An application must register this function by passing its address
        /// to the <see cref="EnumResourceNames"/> or <see cref="EnumResourceNamesEx"/> function.
        /// </para>
        /// <para>
        /// If the callback function returns <see cref="FALSE"/>,
        /// then <see cref="EnumResourceNames"/> or <see cref="EnumResourceNamesEx"/> will stop enumeration and return <see cref="FALSE"/>.
        /// On Windows XP and earlier the value obtained from <see cref="GetLastError"/> will be <see cref="ERROR_SUCCESS"/>;
        /// starting with Windows Vista, the last error value will be <see cref="ERROR_RESOURCE_ENUM_USER_STOP"/>.
        /// </para>
        /// </remarks>
        public delegate BOOL Enumresnameprocw([In] HMODULE hModule, [In] LPCWSTR lpType, [In] LPCWSTR lpName, [In] LONG_PTR lParam);

        /// <summary>
        /// <para>
        /// An application-defined callback function used with the <see cref="EnumResourceTypes"/> and <see cref="EnumResourceTypesEx"/> functions.
        /// It receives resource types.
        /// The <see cref="ENUMRESTYPEPROC"/> type defines a pointer to this callback function.
        /// <paramref name="EnumResTypeProc"/> is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/libloaderapi/nc-libloaderapi-enumrestypeprocw"/>
        /// </para>
        /// </summary>
        /// <param name="hModule">
        /// A handle to the module whose executable file contains the resources for which the types are to be enumerated.
        /// If this parameter is <see cref="NULL"/>,
        /// the function enumerates the resource types in the module used to create the current process.
        /// </param>
        /// <param name="lpType">
        /// <para>
        /// The type of resource for which the type is being enumerated.
        /// </para>
        /// <para>
        /// Alternately, rather than a pointer, this parameter can be <c>MAKEINTRESOURCE(ID)</c>,
        /// where ID is the integer identifier of the given resource type.
        /// For standard resource types, see Resource Types.
        /// For more information, see the Remarks section below.
        /// </para>
        /// </param>
        /// <param name="lParam">
        /// An application-defined parameter passed to the <see cref="EnumResourceTypes"/> or <see cref="EnumResourceTypesEx"/> function.
        /// This parameter can be used in error checking.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> to continue enumeration or <see cref="FALSE"/> to stop enumeration.
        /// </returns>
        /// <remarks>
        /// <para>
        /// If <c>IS_INTRESOURCE(lpType)</c> is <see cref="TRUE"/>,
        /// then <paramref name="lpType"/> specifies the integer identifier of the given resource type.
        /// Otherwise, it is a pointer to a null-terminated string.
        /// If the first character of the string is a pound sign (#),
        /// then the remaining characters represent a decimal number that specifies the integer identifier of the resource type.
        /// For example, the string "#258" represents the identifier 258.
        /// </para>
        /// <para>
        /// An application must register this function by passing its address
        /// to the <see cref="EnumResourceTypes"/> or <see cref="EnumResourceTypesEx"/> function.
        /// </para>
        /// <para>
        /// If the callback function returns <see cref="FALSE"/>,
        /// then <see cref="EnumResourceTypes"/> or <see cref="EnumResourceTypesEx"/> will stop enumeration and return <see cref="FALSE"/>.
        /// On Windows XP and earlier the value obtained from <see cref="GetLastError"/> will be <see cref="ERROR_SUCCESS"/>;
        /// starting with Windows Vista, the last error value will be <see cref="ERROR_RESOURCE_ENUM_USER_STOP"/>.
        /// </para>
        /// </remarks>
        public delegate BOOL Enumrestypeproc([In] HMODULE hModule, [In] LPWSTR lpType, [In] LONG_PTR lParam);


        /// <summary>
        /// <para>
        /// Retrieves a handle that can be used by the <see cref="UpdateResource"/> function
        /// to add, delete, or replace resources in a binary module.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-beginupdateresourcew"/>
        /// </para>
        /// </summary>
        /// <param name="pFileName">
        /// The binary file in which to update resources.
        /// An application must be able to obtain write-access to this file;
        /// the file referenced by <paramref name="pFileName"/> cannot be currently executing.
        /// If <paramref name="pFileName"/> does not specify a full path, the system searches for the file in the current directory.
        /// </param>
        /// <param name="bDeleteExistingResources">
        /// Indicates whether to delete the <paramref name="pFileName"/> parameter's existing resources.
        /// If this parameter is <see cref="TRUE"/>, existing resources are deleted
        /// and the updated file includes only resources added with the <see cref="UpdateResource"/> function.
        /// If this parameter is <see cref="FALSE"/>, the updated file includes existing resources
        /// unless they are explicitly deleted or replaced by using <see cref="UpdateResource"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle
        /// that can be used by the <see cref="UpdateResource"/> and <see cref="EndUpdateResource"/> functions.
        /// The return value is <see cref="NULL"/> if the specified file is not a PE,
        /// the file does not exist, or the file cannot be opened for writing.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// It is recommended that the resource file is not loaded before this function is called.
        /// However, if that file is already loaded, it will not cause an error to be returned.
        /// </para>
        /// <para>
        /// There are some restrictions on resource updates in files that contain Resource Configuration(RC Config) data:
        /// LN files and the associated .mui files.
        /// Details on which types of resources are allowed to be updated in these files
        /// are in the Remarks section for the <see cref="UpdateResource"/> function.
        /// </para>
        /// <para>
        /// This function can update resources within modules that contain both code and resources.
        /// As noted above, there are restrictions on resource updates in LN files and .mui files, both of which contain RC Config data;
        /// details of the restrictions are in the reference for the <see cref="UpdateResource"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "BeginUpdateResourceW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE BeginUpdateResource([In] LPCWSTR pFileName, [In] BOOL bDeleteExistingResources);

        /// <summary>
        /// <para>
        /// Commits or discards changes made prior to a call to <see cref="UpdateResource"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-endupdateresourcew"/>
        /// </para>
        /// </summary>
        /// <param name="hUpdate">
        /// A module handle returned by the <see cref="BeginUpdateResource"/> function,
        /// and used by <see cref="UpdateResource"/>, referencing the file to be updated.
        /// </param>
        /// <param name="fDiscard">
        /// Indicates whether to write the resource updates to the file.
        /// If this parameter is <see cref="TRUE"/>, no changes are made.
        /// If it is <see cref="FALSE"/>, the changes are made: the resource updates will take effect.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if the function succeeds; <see cref="FALSE"/> otherwise.
        /// If the function succeeds and <paramref name="fDiscard"/> is <see cref="TRUE"/>,
        /// then no resource updates are made to the file;
        /// otherwise all successful resource updates are made to the file.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Before you call this function, make sure all file handles other than the one returned by <see cref="BeginUpdateResource"/> are closed.
        /// </para>
        /// <para>
        /// This function can update resources within modules that contain both code and resources.
        /// There are restrictions on resource updates in LN files and .mui files, both of which contain Resource Configuration data;
        /// details of the restrictions are in the reference for the <see cref="UpdateResource"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "EndUpdateResourceW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EndUpdateResource([In] HANDLE hUpdate, [In] BOOL fDiscard);

        /// <summary>
        /// <para>
        /// Enumerates language-specific resources, of the specified type and name, associated with a binary module.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-enumresourcelanguagesw"/>
        /// </para>
        /// </summary>
        /// <param name="hModule">
        /// <para>
        /// The handle to a module to be searched.
        /// Starting with Windows Vista, if this is a language-neutral Portable Executable (LN file),
        /// then appropriate .mui files (if any exist) are included in the search.
        /// If this is a specific .mui file, only that file is searched for resources.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NULL"/>,
        /// that is equivalent to passing in a handle to the module used to create the current process.
        /// </para>
        /// </param>
        /// <param name="lpType">
        /// The type of resource for which the language is being enumerated.
        /// Alternately, rather than a pointer, this parameter can be <see cref="MAKEINTRESOURCE"/>(ID),
        /// where ID is an integer value representing a predefined resource type.
        /// For a list of predefined resource types, see Resource Types.
        /// For more information, see the Remarks section below.
        /// </param>
        /// <param name="lpName">
        /// The name of the resource for which the language is being enumerated.
        /// Alternately, rather than a pointer, this parameter can be <see cref="MAKEINTRESOURCE"/>(ID),
        /// where ID is the integer identifier of the resource.
        /// For more information, see the Remarks section below.
        /// </param>
        /// <param name="lpEnumFunc">
        /// A pointer to the callback function to be called for each enumerated resource language.
        /// For more information, see <see cref="EnumResLangProc"/>.
        /// </param>
        /// <param name="lParam">
        /// An application-defined value passed to the callback function.
        /// This parameter can be used in error checking.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful or <see cref="FALSE"/> otherwise.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// If <c>IS_INTRESOURCE(lpType)</c> is <see cref="TRUE"/>,
        /// then <paramref name="lpType"/> specifies the integer identifier of the given resource type.
        /// Otherwise, it is a pointer to a null-terminated string.
        /// If the first character of the string is a pound sign (#),
        /// then the remaining characters represent a decimal number that specifies the integer identifier of the resource type.
        /// For example, the string "#258" represents the identifier 258.
        /// </para>
        /// <para>
        /// Similarly, if <c>IS_INTRESOURCE(lpName)</c> is <see cref="TRUE"/>,
        /// then <paramref name="lpName"/> specifies the integer identifier of the given resource.
        /// Otherwise, it is a pointer to a null-terminated string.
        /// If the first character of the string is a pound sign (#),
        /// then the remaining characters represent a decimal number that specifies the integer identifier of the resource.
        /// </para>
        /// <para>
        /// Starting with Windows Vista, the binary module is typically a language-neutral Portable Executable (LN file),
        /// and the enumeration will also include resources from the corresponding language-specific resource files (.mui files)
        /// that contain localizable language resources.
        /// </para>
        /// <para>
        /// For each resource found, <see cref="EnumResourceLanguages"/> calls an application-defined callback function <paramref name="lpEnumFunc"/>,
        /// passing the language identifier (see Language Identifiers) of the language for which a resource was found,
        /// as well as the various other parameters that were passed to <see cref="EnumResourceLanguages"/>.
        /// </para>
        /// <para>
        /// Alternately, applications can call <see cref="EnumResourceLanguagesEx"/>,
        /// which provides more precise control of what resources are enumerated.
        /// </para>
        /// <para>
        /// The <see cref="EnumResourceLanguages"/> function continues to enumerate resource languages
        /// until the callback function returns <see cref="FALSE"/> or all resource languages have been enumerated.
        /// </para>
        /// <para>
        /// In Windows Vista and later, if <paramref name="hModule"/> specifies an LN file,
        /// then the resources enumerated can reside either in the LN file or in an .mui file associated with it.
        /// If no .mui files are found, only resources from the LN file are returned.
        /// Unlike <see cref="EnumResourceNames"/> and <see cref="EnumResourceTypes"/>, this search will look at multiple .mui files.
        /// The enumeration begins with .mui files in the folders associated with <see cref="EnumUILanguages"/>.
        /// These are followed by any other .mui files whose paths conform to the scheme described at MUI Resource Management.
        /// Finally, the file designated by <paramref name="hModule"/> is also searched.
        /// </para>
        /// <para>
        /// The enumeration never includes duplicates:
        /// if a resource with the same name, type, and language is contained in both the LN file and in an .mui file,
        /// the resource will only be enumerated once.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumResourceLanguagesW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnumResourceLanguages([In] HMODULE hModule, [In] LPCWSTR lpType, [In] LPCWSTR lpName,
            [In] ENUMRESLANGPROC lpEnumFunc, [In] LONG_PTR lParam);

        /// <summary>
        /// <para>
        /// Enumerates language-specific resources, of the specified type and name, associated with a specified binary module.
        /// Extends <see cref="EnumResourceLanguages"/> by allowing more control over the enumeration.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/libloaderapi/nf-libloaderapi-enumresourcelanguagesexw"/>
        /// </para>
        /// </summary>
        /// <param name="hModule">
        /// <para>
        /// The handle to a module to search.
        /// Typically this is a language-neutral Portable Executable (LN file),
        /// and if flag <see cref="RESOURCE_ENUM_MUI"/> is set, then appropriate .mui files are included in the search.
        /// Alternately, this can be a handle to an .mui file or other LN file.
        /// If this is a specific .mui file, only that file is searched for resources.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NULL"/>,
        /// it is equivalent to passing in a handle to the module used to create the current process.
        /// </para>
        /// </param>
        /// <param name="lpType">
        /// <para>
        /// The type of the resource for which the language is being enumerated.
        /// Alternately, rather than a pointer, this parameter can be <see cref="MAKEINTRESOURCE"/>(ID),
        /// where ID is an integer value representing a predefined resource type.
        /// For a list of predefined resource types, see Resource Types.
        /// For more information, see the Remarks section below.
        /// </para>
        /// </param>
        /// <param name="lpName">
        /// The name of the resource for which the language is being enumerated.
        /// Alternately, rather than a pointer, this parameter can be <see cref="MAKEINTRESOURCE"/>(ID),
        /// where ID is the integer identifier of the resource.
        /// For more information, see the Remarks section below.
        /// </param>
        /// <param name="lpEnumFunc">
        /// A pointer to the callback function to be called for each enumerated resource language.
        /// For more information, see <c>EnumResLangProcW</c>.
        /// </param>
        /// <param name="lParam">
        /// An application-defined value passed to the callback function.
        /// This parameter can be used in error checking.
        /// </param>
        /// <param name="dwFlags">
        /// <para>
        /// The type of file to be searched.
        /// The following values are supported.
        /// Note that if <paramref name="dwFlags"/> is zero,
        /// then the <see cref="RESOURCE_ENUM_LN"/> and <see cref="RESOURCE_ENUM_MUI"/> flags are assumed to be specified.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RESOURCE_ENUM_MUI"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// Search for language-specific resources in .mui files associated with the LN file specified by <paramref name="hModule"/>.
        /// Alternately, if <paramref name="LangId"/> is nonzero,
        /// the only .mui file searched will be the one matching the specified <paramref name="LangId"/>.
        /// Typically this flag should be used only if <paramref name="hModule"/> references an LN file.
        /// If <paramref name="hModule"/> references an .mui file,
        /// then that file is actually covered by the <see cref="RESOURCE_LN"/> flag, despite the name of the flag.
        /// See the Remarks section below for sequence of search.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RESOURCE_ENUM_LN"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// Searches the file specified by <paramref name="hModule"/>,
        /// regardless of whether the file is an LN file, another type of LN file, or an .mui file.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RESOURCE_ENUM_MUI_SYSTEM"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// Restricts the .mui files search to system-installed MUI languages.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RESOURCE_ENUM_VALIDATE"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// Performs extra validation on the resource section and its reference in the PE header
        /// while doing the enumeration to ensure that resources are properly formatted.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="LangId">
        /// The localization language used to filter the search in the .mui file.
        /// This parameter is used only when the <see cref="RESOURCE_ENUM_MUI"/> flag is set in <paramref name="dwFlags"/>.
        /// If zero is specified, then all .mui files are included in the search.
        /// If a nonzero <paramref name="LangId"/> is specified,
        /// then the only .mui file searched will be the one matching the specified <paramref name="LangId"/>.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if the function succeeds
        /// or <see cref="FALSE"/> if the function does not find a resource of the type specified,
        /// or if the function fails for another reason.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// If <c>IS_INTRESOURCE(lpType)</c> is <see cref="TRUE"/>,
        /// then <paramref name="lpType"/> specifies the integer identifier of the given resource type.
        /// Otherwise, it is a pointer to a null-terminated string.
        /// If the first character of the string is a pound sign (#),
        /// then the remaining characters represent a decimal number that specifies the integer identifier of the resource type.
        /// For example, the string "#258" represents the identifier 258.
        /// </para>
        /// <para>
        /// Similarly, if <c>if IS_INTRESOURCE(lpName)</c> is <see cref="TRUE"/>,
        /// then <paramref name="lpName"/> specifies the integer identifier of the given resource.
        /// Otherwise, it is a pointer to a null-terminated string.
        /// If the first character of the string is a pound sign (#),
        /// then the remaining characters represent a decimal number that specifies the
        /// </para>
        /// <para>
        /// integer identifier of the resource.
        /// </para>
        /// <para>
        /// Starting with Windows Vista, the binary module is typically an LN file,
        /// and the enumeration will also include resources from the corresponding language-specific resource files (.mui files)
        /// that contain localizable language resources.
        /// </para>
        /// <para>
        /// For each such resource found, <see cref="EnumResourceLanguagesEx"/> calls
        /// an application-defined callback function <paramref name="lpEnumFunc"/>,
        /// passing to the callback function the language identifier (see Language Identifiers) of the language
        /// for which a resource was found (as well as the various other parameters
        /// that were passed to <see cref="EnumResourceLanguagesEx"/>).
        /// </para>
        /// <para>
        /// The search can include both an LN file and its associated .mui files,
        /// or it can be limited either to a single binary module of any type,
        /// or to the .mui files associated with a single LN file.
        /// Also, by specifying an LN file for the <paramref name="hModule"/> parameter
        /// and a nonzero <paramref name="LangId"/> parameter,
        /// the search can be limited to the unique .mui file associated with that LN file and language.
        /// </para>
        /// <para>
        /// The <see cref="EnumResourceLanguagesEx"/> function continues to enumerate resource languages
        /// until the callback function returns <see cref="FALSE"/> or all resource languages have been enumerated.
        /// </para>
        /// <para>
        /// If <paramref name="hModule"/> specifies an LN file, and both flags are selected,
        /// the languages enumerated include all languages
        /// whose resources reside either in the LN file or in any .mui files associated with it.
        /// If no .mui files are found, only languages from the LN file are returned.
        /// </para>
        /// <para>
        /// If <paramref name="dwFlags"/> contains <see cref="RESOURCE_ENUM_MUI"/> or <see cref="NULL"/>
        /// and <paramref name="LangId"/> is 0, then the enumeration first includes the languages
        /// associated with all system-installed .mui files, using languages retrieved from <see cref="EnumUILanguages"/>.
        /// Finally, if the <see cref="RESOURCE_ENUM_LN"/> flag is also set,
        /// the file designated by <paramref name="hModule"/> is also searched.
        /// </para>
        /// <para>
        /// If the <paramref name="LangId"/> is nonzero, then only the .mui file corresponding to that language identifier will be searched.
        /// Language fallbacks will not be used.
        /// If an .mui file for that language does not exist, the enumeration will be empty
        /// (unless resources for that language exist in the LN file, and the flag is set to search the LN file as well).
        /// </para>
        /// <para>
        /// The enumeration never includes duplicates:
        /// if resources for a particular language are contained in both the LN file and in an .mui file,
        /// the type will only be enumerated once.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumResourceLanguagesExW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnumResourceLanguagesEx([In] HMODULE hModule, [In] LPCWSTR lpType, [In] LPCWSTR lpName,
            [In] ENUMRESLANGPROC lpEnumFunc, [In] LONG_PTR lParam, [In] DWORD dwFlags, [In] LANGID LangId);

        /// <summary>
        /// <para>
        /// Enumerates resources of a specified type within a binary module.
        /// For Windows Vista and later, this is typically a language-neutral Portable Executable (LN file),
        /// and the enumeration will also include resources from the corresponding language-specific resource files (.mui files)
        /// that contain localizable language resources.
        /// It is also possible for <paramref name="hModule"/> to specify an .mui file, in which case only that file is searched for resources.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/libloaderapi/nf-libloaderapi-enumresourcenamesw"/>
        /// </para>
        /// </summary>
        /// <param name="hModule">
        /// <para>
        /// A handle to a module to be searched.
        /// Starting with Windows Vista, if this is an LN file, then appropriate .mui files (if any exist) are included in the search.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NULL"/>,
        /// that is equivalent to passing in a handle to the module used to create the current process.
        /// </para>
        /// </param>
        /// <param name="lpType">
        /// The type of the resource for which the name is being enumerated.
        /// Alternately, rather than a pointer, this parameter can be <c>MAKEINTRESOURCE(ID)</c>,
        /// where ID is an integer value representing a predefined resource type.
        /// For a list of predefined resource types, see Resource Types.
        /// For more information, see the Remarks section below.
        /// </param>
        /// <param name="lpEnumFunc">
        /// A pointer to the callback function to be called for each enumerated resource name or ID.
        /// For more information, see <see cref="ENUMRESNAMEPROC"/>.
        /// </param>
        /// <param name="lParam">
        /// An application-defined value passed to the callback function.
        /// This parameter can be used in error checking.
        /// </param>
        /// <returns>
        /// The return value is <see cref="TRUE"/> if the function succeeds
        /// or <see cref="FALSE"/> if the function does not find a resource of the type specified,
        /// or if the function fails for another reason.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// If <c>IS_INTRESOURCE(lpType)</c> is <see cref="TRUE"/>,
        /// then <paramref name="lpType"/> specifies the integer identifier of the given resource type.
        /// Otherwise, it is a pointer to a null-terminated string.
        /// If the first character of the string is a pound sign (#),
        /// then the remaining characters represent a decimal number that specifies the integer identifier of the resource type.
        /// For example, the string "#258" represents the identifier 258.
        /// </para>
        /// <para>
        /// For each resource found, <see cref="EnumResourceNames"/> calls an application-defined callback function <paramref name="lpEnumFunc"/>,
        /// passing the name or the ID of each resource it finds,
        /// as well as the various other parameters that were passed to <see cref="EnumResourceNames"/>.
        /// The passed name is only valid inside the callback -
        /// if the passed name is a string pointer, it points to an internal buffer that is reused for all callback invocations.
        /// </para>
        /// <para>
        /// Alternately, applications can call <see cref="EnumResourceNamesEx"/>,
        /// which provides more precise control of what resources are enumerated.
        /// </para>
        /// <para>
        /// If a resource has an ID, the ID is passed to the callback function;
        /// otherwise the resource name is passed to the callback function.
        /// For more information, see <see cref="ENUMRESNAMEPROC"/>.
        /// </para>
        /// <para>
        /// The <see cref="EnumResourceNames"/> function continues to enumerate resources
        /// until the callback function returns <see cref="FALSE"/> or all resources have been enumerated.
        /// </para>
        /// <para>
        /// Starting with Windows Vista, if <paramref name="hModule"/> specifies an LN file,
        /// then the resources enumerated can reside either in the LN file or in a .mui file associated with it.
        /// If no .mui files are found, only resources from the LN file are returned.
        /// The order in which .mui files are searched is the usual Resource Loader search order;
        /// see User Interface Language Management for details.
        /// Once one appropriate .mui file is found, the .mui file search stops.
        /// Because all .mui files that correspond to a single LN file have the same resource types,
        /// only the resources in the found .mui file need to be enumerated.
        /// </para>
        /// <para>
        /// The enumeration never includes duplicates:
        /// if resources with the same name are contained in both the LN file and in an .mui file, the resource will only be enumerated once.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumResourceNamesW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnumResourceNames([In] HMODULE hModule, [In] LPCWSTR lpType, [In] ENUMRESNAMEPROC lpEnumFunc, [In] LONG_PTR lParam);

        /// <summary>
        /// <para>
        /// Enumerates resources of a specified type that are associated with a specified binary module.
        /// The search can include both an LN file and its associated .mui files, or it can be limited in several ways.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/libloaderapi/nf-libloaderapi-enumresourcenamesexw"/>
        /// </para>
        /// </summary>
        /// <param name="hModule">
        /// <para>
        /// The handle to a module to search.
        /// Typically this is an LN file, and if flag <see cref="RESOURCE_ENUM_MUI"/> is set,
        /// then appropriate .mui files are included in the search.
        /// Alternately, this can be a handle to an .mui file or other LN file.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NULL"/>, it is equivalent to passing in a handle to the module used to create the current process.
        /// </para>
        /// </param>
        /// <param name="lpType">
        /// The type of the resource for which the name is being enumerated.
        /// Alternately, rather than a pointer, this parameter can be <c>MAKEINTRESOURCE(ID)</c>,
        /// where ID is an integer value representing a predefined resource type.
        /// For a list of predefined resource types, see Resource Types.
        /// For more information, see the Remarks section below.
        /// </param>
        /// <param name="lpEnumFunc">
        /// A pointer to the callback function to be called for each enumerated resource name.
        /// For more information, see <c>EnumResNameProc</c>.
        /// </param>
        /// <param name="lParam">
        /// An application-defined value passed to the callback function.
        /// This parameter can be used in error checking.
        /// </param>
        /// <param name="dwFlags">
        /// <para>
        /// The type of file to search. The following values are supported.
        /// Note that if <paramref name="dwFlags"/> is zero,
        /// then the <see cref="RESOURCE_ENUM_LN"/> and <see cref="RESOURCE_ENUM_MUI"/> flags are assumed to be specified.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RESOURCE_ENUM_MUI"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// Search for resources in .mui files associated with the LN file specified by <paramref name="hModule"/>
        /// and with the current language preferences,
        /// following the usual Resource Loader strategy (see User Interface Language Management).
        /// Alternately, if <paramref name="LangId"/> is nonzero, then only the specified .mui file will be searched.
        /// Typically this flag should be used only if <paramref name="hModule"/> references an LN file.
        /// If <paramref name="hModule"/> references an .mui file,
        /// then that file is actually covered by the <see cref="RESOURCE_ENUM_LN"/> flag, despite the name of the flag.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RESOURCE_ENUM_LN"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// Searches the file specified by <paramref name="hModule"/>,
        /// regardless of whether the file is an LN file, another type of LN file, or an .mui file.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RESOURCE_ENUM_VALIDATE"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// Performs extra validation on the resource section and its reference in the PE header
        /// while doing the enumeration to ensure that resources are properly formatted.
        /// The validation sets a maximum limit of 260 characters for each name that is enumerated.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="LangId">
        /// The localization language used to filter the search in the MUI module.
        /// This parameter is used only when the <see cref="RESOURCE_ENUM_MUI"/> flag is set in <paramref name="dwFlags"/>.
        /// If zero is specified, then all .mui files that match current language preferences are included in the search,
        /// following the usual Resource Loader strategy (see User Interface Language Management).
        /// If a nonzero <paramref name="LangId"/> is specified,
        /// then the only .mui file searched will be the one matching the specified <paramref name="LangId"/>.
        /// </param>
        /// <returns>
        /// The function <see cref="TRUE"/> if successful,
        /// or <see cref="FALSE"/> if the function does not find a resource of the type specified,
        /// or if the function fails for another reason.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// If <c>IS_INTRESOURCE(lpType)</c> is <see cref="TRUE"/>,
        /// then <paramref name="lpType"/> specifies the integer identifier of the given resource type.
        /// Otherwise, it is a pointer to a null-terminated string.
        /// If the first character of the string is a pound sign (#),
        /// then the remaining characters represent a decimal number that specifies the integer identifier of the resource type.
        /// For example, the string "#258" represents the identifier 258.
        /// </para>
        /// <para>
        /// The enumeration search can include both an LN file and its associated .mui files.
        /// It can be limited to a single binary module of any type.
        /// It can also be limited to the .mui files associated with a single LN file.
        /// By specifying an LN file for the <paramref name="hModule"/> parameter
        /// and a nonzero <paramref name="LangId"/> parameter,
        /// the search can be limited to the unique .mui file associated with that LN file and language.
        /// </para>
        /// <para>
        /// For each resource found, <see cref="EnumResourceNamesEx"/> calls
        /// an application-defined callback function <paramref name="lpEnumFunc"/>,
        /// passing the name or the ID of each resource it finds,
        /// as well as the various other parameters that were passed to <see cref="EnumResourceNamesEx"/>.
        /// The passed name is only valid inside the callback -
        /// if the passed name is a string pointer, it points to an internal buffer that is reused for all callback invocations.
        /// </para>
        /// <para>
        /// If a resource has an ID, the ID is returned to the callback function;
        /// otherwise the resource name is returned to the callback function.
        /// For more information, see <see cref="EnumResNameProc"/>.
        /// </para>
        /// <para>
        /// The <see cref="EnumResourceNamesEx"/> function continues to enumerate resource names
        /// until the callback function returns <see cref="FALSE"/> or all resource names for this type have been enumerated.
        /// </para>
        /// <para>
        /// If <paramref name="hModule"/> specifies an LN file, and both flags are selected,
        /// the names enumerated correspond to resources residing either in that LN file or the .mui files associated with it.
        /// If no .mui files are found, only names from the LN file are returned.
        /// After one appropriate .mui file is found the search will not continue further,
        /// because all .mui files corresponding to a single LN file have the same resource names.
        /// </para>
        /// <para>
        /// If <paramref name="dwFlags"/> and <paramref name="LangId"/> are both zero,
        /// then the function behaves like <see cref="EnumResourceNames"/>.
        /// </para>
        /// <para>
        /// If <paramref name="LangId"/> is nonzero, then only the .mui file corresponding to that Language identifier will be searched.
        /// Language fallbacks will not be used.
        /// If an .mui file for that language does not exist, the enumeration will be empty
        /// (unless resources for that language exist in the LN file, and the flag is set to search the LN file as well).
        /// </para>
        /// <para>
        /// The enumeration never includes duplicates:
        /// if resources for a particular language are contained in both the LN file and in an .mui file, the name will only be enumerated once.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumResourceNamesExW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnumResourceNamesEx([In] HMODULE hModule, [In] LPCWSTR lpType, [In] ENUMRESNAMEPROC lpEnumFunc,
            [In] LONG_PTR lParam, [In] DWORD dwFlags, [In] LANGID LangId);

        /// <summary>
        /// <para>
        /// Enumerates resource types within a binary module.
        /// Starting with Windows Vista, this is typically a language-neutral Portable Executable (LN file),
        /// and the enumeration also includes resources from one of the corresponding language-specific resource files (.mui files)—
        /// if one exists—that contain localizable language resources.
        /// It is also possible to use <paramref name="hModule"/> to specify a .mui file,
        /// in which case only that file is searched for resource types.
        /// </para>
        /// <para>
        /// Alternately, applications can call <see cref="EnumResourceTypesEx"/>,
        /// which provides more precise control over which resource files to enumerate.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-enumresourcetypesw"/>
        /// </para>
        /// </summary>
        /// <param name="hModule">
        /// <para>
        /// A handle to a module to be searched.
        /// This handle must be obtained through <see cref="LoadLibrary"/> or <see cref="LoadLibraryEx"/>.
        /// </para>
        /// <para>
        /// See Remarks for more information.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NULL"/>,
        /// that is equivalent to passing in a handle to the module used to create the current process.
        /// </para>
        /// </param>
        /// <param name="lpEnumFunc">
        /// A pointer to the callback function to be called for each enumerated resource type.
        /// For more information, see the <c>EnumResTypeProc</c> function.
        /// </param>
        /// <param name="lParam">
        /// An application-defined value passed to the callback function.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful; otherwise, <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// For each resource type found, <see cref="EnumResourceTypes"/> calls an application-defined callback function <paramref name="lpEnumFunc"/>,
        /// passing each resource type it finds, as well as the various other parameters that were passed to <see cref="EnumResourceTypes"/>.
        /// </para>
        /// <para>
        /// <see cref="EnumResourceTypes"/> continues to enumerate resource types
        /// until the callback function returns <see cref="FALSE"/> or all resource types have been enumerated.
        /// </para>
        /// <para>
        /// Starting with Windows Vista, if <paramref name="hModule"/> specifies an LN file,
        /// then the types enumerated correspond to resources that reside in the LN file and in the .mui file associated with it.
        /// If no .mui files are found, only types from the LN file are returned.
        /// The order in which .mui files are searched is the usual Resource Loader search order;
        /// see User Interface Language Management for details.
        /// After one appropriate .mui file is found, the search does not continue further to other .mui files associated with the LN file,
        /// because all .mui files that correspond to a single LN file have the same set of resource types.
        /// </para>
        /// <para>
        /// The enumeration never includes duplicates:
        /// if a given resource type is contained in both the LN file and in an .mui file, the type is enumerated only once.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumResourceTypesW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnumResourceTypes([In] HMODULE hModule, [In] ENUMRESTYPEPROC lpEnumFunc, [In] LONG_PTR lParam);

        /// <summary>
        /// <para>
        /// Enumerates resource types associated with a specified binary module.
        /// The search can include both a language-neutral Portable Executable file (LN file) and its associated .mui files.
        /// Alternately, it can be limited to a single binary module of any type,
        /// or to the .mui files associated with a single LN file.
        /// The search can also be limited to a single associated .mui file that contains resources for a specific language.
        /// </para>
        /// <para>
        /// For each resource type found, <see cref="EnumResourceTypesEx"/> calls
        /// an application-defined callback function <paramref name="lpEnumFunc"/>,
        /// passing the resource type it finds,
        /// as well as the various other parameters that were passed to <see cref="EnumResourceTypesEx"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/libloaderapi/nf-libloaderapi-enumresourcetypesexw"/>
        /// </para>
        /// </summary>
        /// <param name="hModule">
        /// <para>
        /// The handle to a module to be searched.
        /// Typically this is an LN file, and if flag <see cref="RESOURCE_ENUM_MUI"/> is set,
        /// then appropriate .mui files can be included in the search.
        /// Alternately, this can be a handle to an .mui file or other LN file.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NULL"/>,
        /// it is equivalent to passing in a handle to the module used to create the current process.
        /// </para>
        /// </param>
        /// <param name="lpEnumFunc">
        /// A pointer to the callback function to be called for each enumerated resource type.
        /// For more information, see <c>EnumResTypeProc</c>.
        /// </param>
        /// <param name="lParam">
        /// An application-defined value passed to the callback function.
        /// </param>
        /// <param name="dwFlags">
        /// <para>
        /// The type of file to be searched.
        /// The following values are supported. Note that if <paramref name="dwFlags"/> is zero,
        /// then the <see cref="RESOURCE_ENUM_LN"/> and <see cref="RESOURCE_ENUM_MUI"/> flags are assumed to be specified.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RESOURCE_ENUM_MUI"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// Search for resource types in one of the .mui files associated with the file
        /// specified by <paramref name="hModule"/> and with the current language preferences,
        /// following the usual Resource Loader strategy (see User Interface Language Management).
        /// Alternately, if <paramref name="LangId"/> is nonzero,
        /// then only the .mui file of the language as specified by <paramref name="LangId"/> will be searched.
        /// Typically this flag should be used only if <paramref name="hModule"/> references an LN file.
        /// If <paramref name="hModule"/> references an .mui file,
        /// then that file is actually covered by the <see cref="RESOURCE_ENUM_LN"/> flag, despite the name of the flag.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RESOURCE_ENUM_LN"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// Searches only the file specified by <paramref name="hModule"/>,
        /// regardless of whether the file is an LN file or an .mui file.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RESOURCE_ENUM_VALIDATE"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// Performs extra validation on the resource section and its reference in the PE header
        /// while doing the enumeration to ensure that resources are properly formatted.
        /// The validation sets a maximum limit of 260 characters for each type that is enumerated.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="LangId">
        /// The language used to filter the search in the MUI module.
        /// This parameter is used only when the <see cref="RESOURCE_ENUM_MUI"/> flag is set in <paramref name="dwFlags"/>.
        /// If zero is specified, then all .mui files that match current language preferences are included in the search,
        /// following the usual Resource Loader strategy (see User Interface Language Management).
        /// If a nonzero <paramref name="LangId"/> is specified,
        /// then the only .mui file searched will be the one matching the specified <paramref name="LangId"/>.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful
        /// or <see cref="FALSE"/> if the function does not find a resource of the type specified,
        /// or if the function fails for another reason.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="EnumResourceTypesEx"/> function continues to enumerate resource types
        /// until the callback function returns <see cref="FALSE"/> or all resource types have been enumerated.
        /// </para>
        /// <para>
        /// If <paramref name="hModule"/> specifies an LN file, and both flags are selected,
        /// the types enumerated correspond to resources residing either in the LN file or in the .mui files associated with it.
        /// If no .mui files are found, only types from the LN file are returned.
        /// Once one appropriate .mui file is found the search will not continue further,
        /// because all .mui files corresponding to a single LN file have the same resource types.
        /// </para>
        /// <para>
        /// If <paramref name="dwFlags"/> and <paramref name="LangId"/> are both zero,
        /// then the function behaves like <see cref="EnumResourceTypes"/>.
        /// </para>
        /// <para>
        /// If <paramref name="LangId"/> is nonzero, then only the .mui file corresponding to that language identifier will be searched.
        /// Language fallbacks will not be used.
        /// If an .mui file for that language does not exist, the enumeration will be empty
        /// (unless resources for that language exist in the LN file, and the flag is set to search the LN file as well).
        /// </para>
        /// <para>
        /// The enumeration never includes duplicates:
        /// if resources for a particular language are contained in both the LN file and in an .mui file, the type will only be enumerated once.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumResourceTypesExW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnumResourceTypesEx([In] HMODULE hModule, [In] ENUMRESTYPEPROC lpEnumFunc, [In] LONG_PTR lParam,
            [In] DWORD dwFlags, [In] LANGID LangId);

        /// <summary>
        /// <para>
        /// Determines the location of a resource with the specified type and name in the specified module.
        /// </para>
        /// <para>
        /// To specify a language, use the <see cref="FindResourceEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/libloaderapi/nf-libloaderapi-findresourcew"/>
        /// </para>
        /// </summary>
        /// <param name="hModule">
        /// A handle to the module whose portable executable file or an accompanying MUI file contains the resource.
        /// If this parameter is <see cref="NULL"/>, the function searches the module used to create the current process.
        /// </param>
        /// <param name="lpName">
        /// The name of the resource.
        /// Alternately, rather than a pointer, this parameter can be <c>MAKEINTRESOURCE(ID)</c>, where ID is the integer identifier of the resource.
        /// For more information, see the Remarks section below.
        /// </param>
        /// <param name="lpType">
        /// The resource type. 
        /// Alternately, rather than a pointer, this parameter can be <c>MAKEINTRESOURCE(ID)</c>,
        /// where ID is the integer identifier of the given resource type.
        /// For standard resource types, see Resource Types. 
        /// For more information, see the Remarks section below.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the specified resource's information block.
        /// To obtain a handle to the resource, pass this handle to the <see cref="LoadResource"/> function.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If <see cref="IS_INTRESOURCE"/> is <see cref="TRUE"/> for x = <paramref name="lpName"/> or <paramref name="lpType"/>,
        /// x specifies the integer identifier of the name or type of the given resource.
        /// Otherwise, those parameters are long pointers to null-terminated strings.
        /// If the first character of the string is a pound sign (#), the remaining characters represent a decimal number
        /// that specifies the integer identifier of the resource's name or type.
        /// For example, the string "#258" represents the integer identifier 258.
        /// </para>
        /// <para>
        /// To reduce the amount of memory required for a resource,
        /// an application should refer to it by integer identifier instead of by name.
        /// </para>
        /// <para>
        /// An application can use <see cref="FindResource"/> to find any type of resource,
        /// but this function should be used only if the application must access the binary resource data
        /// by making subsequent calls to <see cref="LoadResource"/> and then to <see cref="LockResource"/>.
        /// </para>
        /// <para>
        /// To use a resource immediately, an application should use one of the following resource-specific functions
        /// to find the resource and convert the data into a more usable form.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Function
        /// </term>
        /// <term>
        /// Action
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="FormatMessage"/>
        /// </term>
        /// <term>
        /// Loads and formats a message-table entry.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LoadAccelerators"/>
        /// </term>
        /// <term>
        /// Loads an accelerator table.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LoadBitmap"/>
        /// </term>
        /// <term>
        /// Loads a bitmap resource.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LoadCursor"/>
        /// </term>
        /// <term>
        /// Loads a cursor resource.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LoadIcon"/>
        /// </term>
        /// <term>
        /// Loads an icon resource.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LoadMenu"/>
        /// </term>
        /// <term>
        /// Loads a menu resource.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LoadString"/>
        /// </term>
        /// <term>
        /// Loads a string-table entry.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// For example, an application can use the <see cref="LoadIcon"/> function to load an icon for display on the screen.
        /// However, the application should use <see cref="FindResource"/> and <see cref="LoadResource"/>
        /// if it is loading the icon to copy its data to another application.
        /// </para>
        /// <para>
        /// String resources are stored in sections of up to 16 strings per section.
        /// The strings in each section are stored as a sequence of counted (not necessarily null-terminated) Unicode strings.
        /// The <see cref="LoadString"/> function will extract the string resource from its corresponding section.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindResourceW", ExactSpelling = true, SetLastError = true)]
        public static extern HRSRC FindResource([In] HMODULE hModule, [In] LPCWSTR lpName, [In] LPCWSTR lpType);

        /// <summary>
        /// <para>
        /// Determines the location of the resource with the specified type, name, and language in the specified module.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-findresourceexa"/>
        /// </para>
        /// </summary>
        /// <param name="hModule">
        /// A handle to the module whose portable executable file or an accompanying MUI file contains the resource.
        /// If this parameter is <see cref="NULL"/>, the function searches the module used to create the current process.
        /// </param>
        /// <param name="lpType">
        /// The resource type.
        /// Alternately, rather than a pointer, this parameter can be <c>MAKEINTRESOURCE(ID)</c>,
        /// where ID is the integer identifier of the given resource type.
        /// For standard resource types, see Resource Types.
        /// For more information, see the Remarks section below.
        /// </param>
        /// <param name="lpName">
        /// The name of the resource. Alternately, rather than a pointer, this parameter can be <c>MAKEINTRESOURCE(ID)</c>,
        /// where ID is the integer identifier of the resource.
        /// For more information, see the Remarks section below.
        /// </param>
        /// <param name="wLanguage">
        /// <para>
        /// The language of the resource.
        /// If this parameter is <c>MAKELANGID(LANG_NEUTRAL, SUBLANG_NEUTRAL)</c>,
        /// the current language associated with the calling thread is used.
        /// </para>
        /// <para>
        /// To specify a language other than the current language, use the <see cref="MAKELANGID"/> macro to create this parameter.
        /// For more information, see <see cref="MAKELANGID"/>.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the specified resource's information block.
        /// To obtain a handle to the resource, pass this handle to the <see cref="LoadResource"/> function.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If <see cref="IS_INTRESOURCE"/> is <see cref="TRUE"/> for x = <paramref name="lpName"/> or <paramref name="lpType"/>,
        /// x specifies the integer identifier of the name or type of the given resource.
        /// Otherwise, those parameters are long pointers to null-terminated strings.
        /// If the first character of the string is a pound sign (#), the remaining characters represent a decimal number
        /// that specifies the integer identifier of the resource's name or type.
        /// For example, the string "#258" represents the integer identifier 258.
        /// </para>
        /// <para>
        /// To reduce the amount of memory required for a resource,
        /// an application should refer to it by integer identifier instead of by name.
        /// </para>
        /// <para>
        /// An application can use <see cref="FindResourceEx"/> to find any type of resource,
        /// but this function should be used only if the application must access the binary resource data
        /// by making subsequent calls to <see cref="LoadResource"/> and then to <see cref="LockResource"/>.
        /// </para>
        /// <para>
        /// To use a resource immediately, an application should use one of the following resource-specific functions
        /// to find the resource and convert the data into a more usable form.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Function
        /// </term>
        /// <term>
        /// Action
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="FormatMessage"/>
        /// </term>
        /// <term>
        /// Loads and formats a message-table entry.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LoadAccelerators"/>
        /// </term>
        /// <term>
        /// Loads an accelerator table.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LoadBitmap"/>
        /// </term>
        /// <term>
        /// Loads a bitmap resource.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LoadCursor"/>
        /// </term>
        /// <term>
        /// Loads a cursor resource.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LoadIcon"/>
        /// </term>
        /// <term>
        /// Loads an icon resource.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LoadMenu"/>
        /// </term>
        /// <term>
        /// Loads a menu resource.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LoadString"/>
        /// </term>
        /// <term>
        /// Loads a string-table entry.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// For example, an application can use the <see cref="LoadIcon"/> function to load an icon for display on the screen.
        /// However, the application should use <see cref="FindResourceEx"/> and <see cref="LoadResource"/>
        /// if it is loading the icon to copy its data to another application.
        /// </para>
        /// <para>
        /// String resources are stored in sections of up to 16 strings per section.
        /// The strings in each section are stored as a sequence of counted (not necessarily null-terminated) Unicode strings.
        /// The <see cref="LoadString"/> function will extract the string resource from its corresponding section.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindResourceExW", ExactSpelling = true, SetLastError = true)]
        public static extern HRSRC FindResourceEx([In] HMODULE hModule, [In] LPCWSTR lpType, [In] LPCWSTR lpName, [In] WORD wLanguage);

        /// <summary>
        /// <para>
        /// Decrements (decreases by one) the reference count of a loaded resource.
        /// When the reference count reaches zero, the memory occupied by the resource is freed.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/libloaderapi/nf-libloaderapi-freeresource"/>
        /// </para>
        /// </summary>
        /// <param name="hResData">
        /// A handle of the resource.
        /// It is assumed that <paramref name="hResData"/> was created by <see cref="LoadResource"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is zero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is nonzero, which indicates that the resource has not been freed.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// For resources loaded with other functions, <see cref="FreeResource"/> has been replaced by the following functions:
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Resource type
        /// </term>
        /// <term>
        /// FreeResource replacement
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Accelerator
        /// </term>
        /// <term>
        /// <see cref="DestroyAcceleratorTable"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Bitmap
        /// </term>
        /// <term>
        /// <see cref="DeleteObject"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Cursor
        /// </term>
        /// <term>
        /// <see cref="DestroyCursor"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Icon
        /// </term>
        /// <term>
        /// <see cref="DestroyIcon"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Menu
        /// </term>
        /// <term>
        /// <see cref="DestroyMenu"/>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The reference count for a resource is incremented (increased by one) each time
        /// an application calls the <see cref="LoadResource"/> function for the resource.
        /// </para>
        /// <para>
        /// The system automatically deletes these resources when the process that created them terminates.
        /// However, calling the appropriate function saves memory. For more information, see <see cref="LoadResource"/>.
        /// </para>
        /// </remarks>
        [Obsolete("This function is obsolete and is only supported for backward compatibility with 16-bit Windows." +
            "For 32-bit Windows applications, it is not necessary to free the resources loaded using LoadResource." +
            "If used on 32 or 64-bit Windows systems, this function will return FALSE.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FreeResource", ExactSpelling = true)]
        public static extern BOOL FreeResource([In] HGLOBAL hResData);

        /// <summary>
        /// <para>
        /// Retrieves a handle that can be used to obtain a pointer to the first byte of the specified resource in memory.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/libloaderapi/nf-libloaderapi-loadresource"/>
        /// </para>
        /// </summary>
        /// <param name="hModule">
        /// A handle to the module whose executable file contains the resource.
        /// If <paramref name="hModule"/> is <see cref="NULL"/>,
        /// the system loads the resource from the module that was used to create the current process.
        /// </param>
        /// <param name="hResInfo">
        /// A handle to the resource to be loaded.
        /// This handle is returned by the <see cref="FindResource"/> or <see cref="FindResourceEx"/> function.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the data associated with the resource.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The return type of <see cref="LoadResource"/> is <see cref="HGLOBAL"/> for backward compatibility,
        /// not because the function returns a handle to a global memory block.
        /// Do not pass this handle to the <see cref="GlobalLock"/> or <see cref="GlobalFree"/> function.
        /// To obtain a pointer to the first byte of the resource data, call the <see cref="LockResource"/> function;
        /// to obtain the size of the resource, call <see cref="SizeofResource"/>.
        /// </para>
        /// <para>
        /// <see cref="GlobalSize"/> returns 0 for a resource <see cref="HGLOBAL"/>.
        /// As a result, any APIs that depend on <see cref="GlobalSize"/> to determine the size of the <see cref="HGLOBAL"/> will not function correctly.
        /// For example, use <see cref="SHCreateMemStream"/> instead of <see cref="CreateStreamOnHGlobal"/>.
        /// </para>
        /// <para>
        /// To use a resource immediately, an application should use the following resource-specific functions to find and load the resource in one call.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Function
        /// </term>
        /// <term>
        /// Action
        /// </term>
        /// <term>
        /// To remove resource
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="FormatMessage"/>
        /// </term>
        /// <term>
        /// Loads and formats a message-table entry
        /// </term>
        /// <term>
        /// No action needed
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LoadAccelerators"/>
        /// </term>
        /// <term>
        /// Loads an accelerator table
        /// </term>
        /// <term>
        /// <see cref="DestroyAcceleratorTable"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LoadBitmap"/>
        /// </term>
        /// <term>
        /// Loads a bitmap resource
        /// </term>
        /// <term>
        /// <see cref="DeleteObject"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LoadCursor"/>
        /// </term>
        /// <term>
        /// Loads a cursor resource
        /// </term>
        /// <term>
        /// <see cref="DestroyCursor"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LoadIcon"/>
        /// </term>
        /// <term>
        /// Loads an icon resource
        /// </term>
        /// <term>
        /// <see cref="DestroyIcon"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LoadMenu"/>
        /// </term>
        /// <term>
        /// Loads a menu resource
        /// </term>
        /// <term>
        /// <see cref="DestroyMenu"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LoadString"/>
        /// </term>
        /// <term>
        /// Loads a string resource
        /// </term>
        /// <term>
        /// No action needed
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// For example, an application can use the <see cref="LoadIcon"/> function to load an icon for display on the screen,
        /// followed by <see cref="DestroyIcon"/> when done.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadResource", ExactSpelling = true, SetLastError = true)]
        public static extern HGLOBAL LoadResource([In] HMODULE hModule, [In] HRSRC hResInfo);

        /// <summary>
        /// <para>
        /// Retrieves a pointer to the specified resource in memory.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/libloaderapi/nf-libloaderapi-lockresource"/>
        /// </para>
        /// </summary>
        /// <param name="hResData">
        /// A handle to the resource to be accessed.
        /// The <see cref="LoadResource"/> function returns this handle.
        /// Note that this parameter is listed as an <see cref="HGLOBAL"/> variable only for backward compatibility.
        /// Do not pass any value as a parameter other than a successful return value from the <see cref="LoadResource"/> function.
        /// </param>
        /// <returns>
        /// If the loaded resource is available, the return value is a pointer to the first byte of the resource; otherwise, it is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The pointer returned by <see cref="LockResource"/> is valid until the module containing the resource is unloaded.
        /// It is not necessary to unlock resources because the system automatically deletes them when the process that created them terminates.
        /// </para>
        /// <para>
        /// Do not try to lock a resource by using the handle returned by the <c>FindResourceA</c> function or <c>FindResourceExA</c> function.
        /// Such a handle points to random data.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "LockResource", ExactSpelling = true)]
        public static extern LPVOID LockResource([In] HGLOBAL hResData);

        /// <summary>
        /// <para>
        /// Converts an integer value to a resource type compatible with the resource-management functions.
        /// This macro is used in place of a string containing the name of the resource.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-makeintresourcew"/>
        /// </para>
        /// </summary>
        /// <param name="i">
        /// The integer value to be converted.
        /// </param>
        /// <returns>
        /// The return value should be passed only to functions which explicitly indicate that they accept <see cref="MAKEINTRESOURCE"/> as a parameter.
        /// For example, the resource management functions allow the return value of <see cref="MAKEINTRESOURCE"/>
        /// to be passed as the <c>lpType</c> or <c>lpName</c> parameters.
        /// </returns>
        public static IntPtr MAKEINTRESOURCE(WORD i) => (IntPtr)(int)i;

        /// <summary>
        /// <para>
        /// Retrieves the size, in bytes, of the specified resource.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/libloaderapi/nf-libloaderapi-sizeofresource"/>
        /// </para>
        /// </summary>
        /// <param name="hModule">
        /// A handle to the module whose executable file contains the resource.
        /// Default is the module used to create the current process.
        /// </param>
        /// <param name="hResInfo">
        /// A handle to the resource.
        /// This handle must be created by using the <see cref="FindResource"/> or <see cref="FindResourceEx"/> function.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the number of bytes in the resource.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SizeofResource", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD SizeofResource([In] HMODULE hModule, [In] HRSRC hResInfo);

        /// <summary>
        /// <para>
        /// Adds, deletes, or replaces a resource in a portable executable (PE) file.
        /// There are some restrictions on resource updates in files that contain Resource Configuration (RC Config) data:
        /// language-neutral (LN) files and language-specific resource (.mui) files.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-updateresourcew"/>
        /// </para>
        /// </summary>
        /// <param name="hUpdate">
        /// A module handle returned by the <see cref="BeginUpdateResource"/> function, referencing the file to be updated.
        /// </param>
        /// <param name="lpType">
        /// <para>
        /// The resource type to be updated.
        /// Alternatively, rather than a pointer, this parameter can be <see cref="MAKEINTRESOURCE"/>(ID),
        /// where ID is an integer value representing a predefined resource type.
        /// If the first character of the string is a pound sign (#),
        /// then the remaining characters represent a decimal number that specifies the integer identifier of the resource type.
        /// For example, the string "#258" represents the identifier 258.
        /// </para>
        /// <para>
        /// For a list of predefined resource types, see Resource Types.
        /// </para>
        /// </param>
        /// <param name="lpName">
        /// The name of the resource to be updated.
        /// Alternatively, rather than a pointer, this parameter can be <see cref="MAKEINTRESOURCE"/>(ID), where ID is a resource ID.
        /// When creating a new resource do not use a string that begins with a '#' character for this parameter.
        /// </param>
        /// <param name="wLanguage">
        /// The language identifier of the resource to be updated.
        /// For a list of the primary language identifiers and sublanguage identifiers
        /// that make up a language identifier, see the <see cref="MAKELANGID"/> macro.
        /// </param>
        /// <param name="lpData">
        /// <para>
        /// The resource data to be inserted into the file indicated by <paramref name="hUpdate"/>.
        /// If the resource is one of the predefined types, the data must be valid and properly aligned.
        /// Note that this is the raw binary data to be stored in the file indicated by <paramref name="hUpdate"/>,
        /// not the data provided by <see cref="LoadIcon"/>, <see cref="LoadString"/>, or other resource-specific load functions.
        /// All data containing strings or text must be in Unicode format. <paramref name="lpData"/> must not point to ANSI data.
        /// </para>
        /// <para>
        /// If <paramref name="lpData"/> is <see cref="NULL"/> and <paramref name="cb"/> is 0,
        /// the specified resource is deleted from the file indicated by <paramref name="hUpdate"/>.
        /// </para>
        /// </param>
        /// <param name="cb">
        /// The size, in bytes, of the resource data at <paramref name="lpData"/>.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful or <see cref="FALSE"/> otherwise.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// It is recommended that the resource file is not loaded before this function is called.
        /// However, if that file is already loaded, it will not cause an error to be returned.
        /// </para>
        /// <para>
        /// An application can use <see cref="UpdateResource"/> repeatedly to make changes to the resource data.
        /// Each call to <see cref="UpdateResource"/> contributes to an internal list of additions, deletions, and replacements
        /// but does not actually write the data to the file indicated by <paramref name="hUpdate"/>.
        /// The application must use the <see cref="EndUpdateResource"/> function to write the accumulated changes to the file.
        /// </para>
        /// <para>
        /// This function can update resources within modules that contain both code and resources.
        /// </para>
        /// <para>
        /// Prior to Windows 7:
        /// If <paramref name="lpData"/> is <see cref="NULL"/> and <paramref name="cb"/> is nonzero,
        /// the specified resource is NOT deleted and an exception is thrown.
        /// </para>
        /// <para>
        /// Starting with Windows Vista:
        /// As noted above, there are restrictions on resource updates in files that contain RC Config data: LN files and .mui files.
        /// The restrictions are as follows:
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Action
        /// </term>
        /// <term>
        /// LN file
        /// </term>
        /// <term>
        /// .mui file
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 1. Add a new type that doesn't exist in the LN or .mui files.
        /// </term>
        /// <term>
        /// Add type in the LN file and treat as language-neutral (non-localizable) and add new type or item in the RC Config data
        /// </term>
        /// <term>
        /// The only additions allowed are the following types:
        /// file Version, RC Config data, Side-by-side Assembly XML Manifest.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 2. Add a new resource item to an existing type.
        /// </term>
        /// <term>
        /// Uses the RC Config data to check whether the type exists in the .mui files associated with this LN file.
        /// If the type doesn't exist in the .mui files, add the item and treat new item as un-localizable.
        /// If the type exists in the .mui files, then adding is not allowed.
        /// </term>
        /// <term>
        /// Only items of the following types may be added:
        /// File Version, RC Config data, Side-by-side Assembly XML Manifest.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 3. Update a resource item.
        /// </term>
        /// <term>
        /// Uses the RC Config data to check whether the type exists in the .mui files associated with the LN file.
        /// If the type doesn't exist in the .mui files, then this resource item update is allowed in the LN file.
        /// Otherwise, if the type exists in the .mui files associated with this LN file, then this update is not allowed.
        /// </term>
        /// <term>
        /// The only updates allowed are items of the following types:
        /// file Version, RC Config data, Side-by-side Assembly XML Manifest.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 4. Add a type/item for a new language.
        /// </term>
        /// <term>
        /// Not allowed.
        /// </term>
        /// <term>
        /// Not allowed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 5. Remove an existing type/item.
        /// </term>
        /// <term>
        /// Works similarly to case 3.
        /// Uses the RC Config data to check whether the type exists in the .mui files associated with the LN file.
        /// If not, then the removal of the type/item from the LN file is allowed.
        /// Otherwise, if the type/item exists in the .mui files associated with this LN file, then the removal is not allowed.
        /// </term>
        /// <term>
        /// The only types allowed to be removed are:
        /// file Version, RC Config data, Side-by-side Assembly XML Manifest; also, only items of these types may be removed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 6. Add/delete/update a type not included in the RC Config data
        /// (such as Version, Side-by-side Assembly XML Manifest, or RC Config data itself).
        /// </term>
        /// <term>
        /// Allowed.
        /// </term>
        /// <term>
        /// Allowed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 7. Other update of non-localizable data, such as TYPELIB, reginst, and so on.
        /// </term>
        /// <term>
        /// Update type or item in the LN file, treat as non-localizable, and add new type or item in the RC Config data.
        /// </term>
        /// <term>
        /// Not applicable.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 8. Add RC Config data.
        /// </term>
        /// <term>
        /// Can be done but the integrity of the RC Config data is not checked.
        /// </term>
        /// <term>
        /// Can be done but the integrity of the RC Config data is not checked.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "UpdateResourceW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL UpdateResource([In] HANDLE hUpdate, [In] LPCWSTR lpType, [In] LPCWSTR lpName,
            [In] WORD wLanguage, [In] LPVOID lpData, [In] DWORD cb);
    }
}
