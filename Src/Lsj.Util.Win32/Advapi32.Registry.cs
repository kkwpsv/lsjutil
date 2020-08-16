using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.ACCESS_MASK;
using static Lsj.Util.Win32.BaseTypes.HKEY;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.FormatMessageFlags;
using static Lsj.Util.Win32.Enums.LogonTypes;
using static Lsj.Util.Win32.Enums.RegistryKeyAccessRights;
using static Lsj.Util.Win32.Enums.RegistryKeyDispositions;
using static Lsj.Util.Win32.Enums.RegistryOptions;
using static Lsj.Util.Win32.Enums.RegistryValueTypes;
using static Lsj.Util.Win32.Enums.RegSaveKeyExFlags;
using static Lsj.Util.Win32.Enums.RegRestoreKeyFlags;
using static Lsj.Util.Win32.Enums.StandardAccessRights;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Ktmw32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32
{
    public partial class Advapi32
    {
        /// <summary>
        /// REG_PROCESS_APPKEY
        /// </summary>
        public static readonly DWORD REG_PROCESS_APPKEY = 0x00000001;


        /// <summary>
        /// <para>
        /// Closes a handle to the specified registry key.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winreg/nf-winreg-regclosekey
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// A handle to the open key to be closed.
        /// The handle must have been opened by the <see cref="RegCreateKeyEx"/>, <see cref="RegCreateKeyTransacted"/>,
        /// <see cref="RegOpenKeyEx"/>, <see cref="RegOpenKeyTransacted"/>, or <see cref="RegConnectRegistry"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag
        /// to get a generic description of the error.
        /// </returns>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegCloseKey", ExactSpelling = true, SetLastError = true)]
        public static extern LSTATUS RegCloseKey([In] HKEY hKey);

        /// <summary>
        /// <para>
        /// Establishes a connection to a predefined registry key on another computer.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winreg/nf-winreg-regconnectregistryw
        /// </para>
        /// </summary>
        /// <param name="lpMachineName">
        /// The name of the remote computer.
        /// The string has the following form:
        /// \computername
        /// The caller must have access to the remote computer or the function fails.
        /// If this parameter is <see langword="null"/>, the local computer name is used.
        /// </param>
        /// <param name="hKey">
        /// A predefined registry handle.
        /// This parameter can be one of the following predefined keys on the remote computer.
        /// <see cref="HKEY_LOCAL_MACHINE"/> <see cref="HKEY_PERFORMANCE_DATA"/> <see cref="HKEY_USERS"/>
        /// </param>
        /// <param name="phkResult">
        /// A pointer to a variable that receives a key handle identifying the predefined handle on the remote computer.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag
        /// to get a generic description of the error.
        /// </returns>
        /// <remarks>
        /// <see cref="RegConnectRegistry"/> requires the Remote Registry service to be running on the remote computer.
        /// By default, this service is configured to be started manually.
        /// To configure the Remote Registry service to start automatically,
        /// run Services.msc and change the Startup Type of the service to Automatic.
        /// Windows Server 2003 and Windows XP/2000:  The Remote Registry service is configured to start automatically by default.
        /// When a handle returned by <see cref="RegConnectRegistry"/> is no longer needed, it should be closed by calling <see cref="RegCloseKey"/>.
        /// If the computer is joined to a workgroup and the "Force network logons
        /// using local accounts to authenticate as Guest" policy is enabled, the function fails.
        /// Note that this policy is enabled by default if the computer is joined to a workgroup.
        /// If the current user does not have proper access to the remote computer, the call to <see cref="RegConnectRegistry"/> fails.
        /// To connect to a remote registry, call <see cref="LogonUser"/> with <see cref="LOGON32_LOGON_NEW_CREDENTIALS"/>
        /// and <see cref="ImpersonateLoggedOnUser"/> before calling <see cref="RegConnectRegistry"/>.
        /// Windows 2000:  One possible workaround is to establish a session to an administrative share
        /// such as IPC$ using a different set of credentials.
        /// To specify credentials other than those of the current user, use the <see cref="WNetAddConnection2"/> function to connect to the share.
        /// When you have finished accessing the registry, cancel the connection.
        /// Windows XP Home Edition:  You cannot use this function to connect to a remote computer running Windows XP Home Edition.
        /// This function does work with the name of the local computer even if it is running Windows XP Home Edition
        /// because this bypasses the authentication layer.
        /// The winreg.h header defines <see cref="RegConnectRegistry"/> as an alias which automatically
        /// selects the ANSI or Unicode version of this function based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead to mismatches
        /// that result in compilation or runtime errors. For more information, see Conventions for Function Prototypes.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegConnectRegistryW", ExactSpelling = true, SetLastError = true)]
        public static extern LSTATUS RegConnectRegistry([MarshalAs(UnmanagedType.LPWStr)][In] string lpMachineName,
            [In] HKEY hKey, [Out] out HKEY phkResult);

        /// <summary>
        /// <para>
        /// Copies the specified registry key, along with its values and subkeys, to the specified destination key.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winreg/nf-winreg-regcopytreew
        /// </para>
        /// </summary>
        /// <param name="hKeySrc">
        /// A handle to an open registry key.
        /// The key must have been opened with the <see cref="KEY_READ"/> access right.
        /// For more information, see Registry Key Security and Access Rights.
        /// This handle is returned by the <see cref="RegCreateKeyEx"/> or <see cref="RegOpenKeyEx"/> function,
        /// or it can be one of the predefined keys.
        /// </param>
        /// <param name="lpSubKey">
        /// The name of the key.
        /// This key must be a subkey of the key identified by the <paramref name="hKeySrc"/> parameter.
        /// This parameter can also be <see langword="null"/>.
        /// </param>
        /// <param name="hKeyDest">
        /// A handle to the destination key.
        /// The calling process must have <see cref="KEY_CREATE_SUB_KEY"/> access to the key.
        /// This handle is returned by the <see cref="RegCreateKeyEx"/> or <see cref="RegOpenKeyEx"/> function,
        /// or it can be one of the predefined keys.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag
        /// to get a generic description of the error.
        /// </returns>
        /// <remarks>
        /// This function also copies the security descriptor for the key.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or later.
        /// For more information, see Using the Windows Headers.
        /// The winreg.h header defines RegCopyTree as an alias which automatically selects
        /// the ANSI or Unicode version of this function based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead to mismatches
        /// that result in compilation or runtime errors.
        /// For more information, see Conventions for Function Prototypes.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegCopyTreeW", ExactSpelling = true, SetLastError = true)]
        public static extern LSTATUS RegCopyTree([In] HKEY hKeySrc, [MarshalAs(UnmanagedType.LPWStr)][In] string lpSubKey, [In] HKEY hKeyDest);

        /// <summary>
        /// <para>
        /// Creates the specified registry key.
        /// If the key already exists in the registry, the function opens it.
        /// </para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winreg/nf-winreg-regcreatekeyw
        /// <para>
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// A handle to an open registry key.
        /// The calling process must have <see cref="KEY_CREATE_SUB_KEY"/> access to the key.
        /// For more information, see Registry Key Security and Access Rights.
        /// Access for key creation is checked against the security descriptor of the registry key,
        /// not the access mask specified when the handle was obtained.
        /// Therefore, even if hKey was opened with a samDesired of <see cref="KEY_READ"/>,
        /// it can be used in operations that create keys if allowed by its security descriptor.
        /// This handle is returned by the <see cref="RegCreateKeyEx"/> or <see cref="RegOpenKeyEx"/> function,
        /// or it can be one of the following predefined keys:
        /// <see cref="HKEY_CLASSES_ROOT"/>, <see cref="HKEY_CURRENT_CONFIG"/>, <see cref="HKEY_CURRENT_USER"/>,
        /// <see cref="HKEY_LOCAL_MACHINE"/>, <see cref="HKEY_USERS"/>
        /// </param>
        /// <param name="lpSubKey">
        /// The name of a key that this function opens or creates.
        /// This key must be a subkey of the key identified by the <paramref name="hKey"/> parameter.
        /// For more information on key names, see Structure of the Registry.
        /// If <paramref name="hKey"/> is one of the predefined keys, <paramref name="lpSubKey"/> may be <see langword="null"/>.
        /// In that case, <paramref name="phkResult"/> receives the same <paramref name="hKey"/> handle passed in to the function.
        /// </param>
        /// <param name="phkResult">
        /// A pointer to a variable that receives a handle to the opened or created key.
        /// If the key is not one of the predefined registry keys,
        /// call the <see cref="RegCloseKey"/> function after you have finished using the handle.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag
        /// to get a generic description of the error.
        /// </returns>
        /// <remarks>
        /// An application cannot create a key that is a direct child of <see cref="HKEY_USERS"/> or <see cref="HKEY_LOCAL_MACHINE"/>.
        /// An application can create subkeys in lower levels of the <see cref="HKEY_USERS"/> or <see cref="HKEY_LOCAL_MACHINE"/> trees.
        /// If your service or application impersonates different users, do not use this function with <see cref="HKEY_CURRENT_USER"/>.
        /// Instead, call the <see cref="RegOpenCurrentUser"/> function.
        /// The <see cref="RegCreateKey"/> function creates all missing keys in the specified path.
        /// An application can take advantage of this behavior to create several keys at once.
        /// For example, an application can create a subkey four levels deep at the same time as the three preceding subkeys
        /// by specifying a string of the following form for the <paramref name="lpSubKey"/> parameter:
        /// subkey1\subkey2\subkey3\subkey4
        /// Note that this behavior will result in creation of unwanted keys if an existing key in the path is spelled incorrectly.
        /// The winreg.h header defines <see cref="RegCreateKey"/> as an alias which automatically selects
        /// the ANSI or Unicode version of this function based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral
        /// can lead to mismatches that result in compilation or runtime errors.
        /// For more information, see Conventions for Function Prototypes.
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit versions of Windows." +
            "Applications should use the RegCreateKeyEx function." +
            "However, applications that back up or restore system state including system files" +
            "and registry hives should use the Volume Shadow Copy Service instead of the registry functions.")]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegCreateKeyW", ExactSpelling = true, SetLastError = true)]
        public static extern LSTATUS RegCreateKey([In] HKEY hKey, [MarshalAs(UnmanagedType.LPWStr)][In] string lpSubKey, [Out] out HKEY phkResult);

        /// <summary>
        /// <para>
        /// Creates the specified registry key. If the key already exists, the function opens it.
        /// Note that key names are not case sensitive.
        /// To perform transacted registry operations on a key, call the <see cref="RegCreateKeyTransacted"/> function.
        /// Applications that back up or restore system state including system files and registry hives
        /// should use the Volume Shadow Copy Service instead of the registry functions.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winreg/nf-winreg-regcreatekeyexw
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// A handle to an open registry key.
        /// The calling process must have <see cref="KEY_CREATE_SUB_KEY"/> access to the key.
        /// For more information, see Registry Key Security and Access Rights.
        /// Access for key creation is checked against the security descriptor of the registry key,
        /// not the access mask specified when the handle was obtained.
        /// Therefore, even if <paramref name="hKey"/> was opened with a <paramref name="samDesired"/> of <see cref="KEY_READ"/>,
        /// it can be used in operations that modify the registry if allowed by its security descriptor.
        /// This handle is returned by the <see cref="RegCreateKeyEx"/> or <see cref="RegOpenKeyEx"/> function,
        /// or it can be one of the following predefined keys:
        /// <see cref="HKEY_CLASSES_ROOT"/>, <see cref="HKEY_CURRENT_CONFIG"/>, <see cref="HKEY_CURRENT_USER"/>,
        /// <see cref="HKEY_LOCAL_MACHINE"/>, <see cref="HKEY_USERS"/> 
        /// </param>
        /// <param name="lpSubKey">
        /// The name of a subkey that this function opens or creates.
        /// The subkey specified must be a subkey of the key identified by the <paramref name="hKey"/> parameter;
        /// it can be up to 32 levels deep in the registry tree.
        /// For more information on key names, see Structure of the Registry.
        /// If <paramref name="lpSubKey"/> is a pointer to an empty string,
        /// <paramref name="phkResult"/> receives a new handle to the key specified by <paramref name="hKey"/>.
        /// This parameter cannot be <see langword="null"/>.
        /// </param>
        /// <param name="Reserved">
        /// This parameter is reserved and must be zero.
        /// </param>
        /// <param name="lpClass">
        /// The user-defined class type of this key.
        /// This parameter may be ignored.
        /// This parameter can be <see langword="null"/>.
        /// </param>
        /// <param name="dwOptions">
        /// This parameter can be one of the following values.
        /// <see cref="REG_OPTION_BACKUP_RESTORE"/>:
        /// If this flag is set, the function ignores the <paramref name="samDesired"/> parameter and attempts to open the key
        /// with the access required to backup or restore the key.
        /// If the calling thread has the SE_BACKUP_NAME privilege enabled,
        /// the key is opened with the <see cref="ACCESS_SYSTEM_SECURITY"/> and <see cref="KEY_READ"/> access rights.
        /// If the calling thread has the SE_RESTORE_NAME privilege enabled, beginning with Windows Vista,
        /// the key is opened with the <see cref="ACCESS_SYSTEM_SECURITY"/>, <see cref="DELETE"/> and <see cref="KEY_WRITE"/> access rights.
        /// If both privileges are enabled, the key has the combined access rights for both privileges.
        /// For more information, see Running with Special Privileges.
        /// <see cref="REG_OPTION_CREATE_LINK"/>:
        /// Note Registry symbolic links should only be used for for application compatibility when absolutely necessary.
        /// This key is a symbolic link. The target path is assigned to the L"SymbolicLinkValue" value of the key.
        /// The target path must be an absolute registry path.
        /// <see cref="REG_OPTION_NON_VOLATILE"/>:
        /// This key is not volatile; this is the default.
        /// The information is stored in a file and is preserved when the system is restarted.
        /// The <see cref="RegSaveKey"/> function saves keys that are not volatile.
        /// <see cref="REG_OPTION_VOLATILE"/>:
        /// All keys created by the function are volatile.
        /// The information is stored in memory and is not preserved when the corresponding registry hive is unloaded.
        /// For <see cref="HKEY_LOCAL_MACHINE"/>, this occurs only when the system initiates a full shutdown.
        /// For registry keys loaded by the <see cref="RegLoadKey"/> function,
        /// this occurs when the corresponding <see cref="RegUnLoadKey"/> is performed.
        /// The <see cref="RegSaveKey"/> function does not save volatile keys.
        /// This flag is ignored for keys that already exist.
        /// Note On a user selected shutdown, a fast startup shutdown is the default behavior for the system.
        /// </param>
        /// <param name="samDesired">
        /// A mask that specifies the access rights for the key to be created.
        /// For more information, see Registry Key Security and Access Rights.
        /// </param>
        /// <param name="lpSecurityAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that determines
        /// whether the returned handle can be inherited by child processes.
        /// If <paramref name="lpSecurityAttributes"/> is <see cref="NullRef{SECURITY_ATTRIBUTES}"/>, the handle cannot be inherited.
        /// The <paramref name="lpSecurityAttributes"/> member of the structure specifies a security descriptor for the new key.
        /// If <paramref name="lpSecurityAttributes"/> is <see cref="NullRef{SECURITY_ATTRIBUTES}"/>, the key gets a default security descriptor.
        /// The ACLs in a default security descriptor for a key are inherited from its direct parent key.
        /// </param>
        /// <param name="phkResult">
        /// A pointer to a variable that receives a handle to the opened or created key.
        /// If the key is not one of the predefined registry keys,
        /// call the <see cref="RegCloseKey"/> function after you have finished using the handle.
        /// </param>
        /// <param name="lpdwDisposition">
        /// A pointer to a variable that receives one of the following disposition values.
        /// <see cref="REG_CREATED_NEW_KEY"/>, <see cref="REG_OPENED_EXISTING_KEY"/>
        /// If <paramref name="lpdwDisposition"/> is <see cref="NullRef{RegistryKeyDispositions}"/>, no disposition information is returned.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag
        /// to get a generic description of the error.
        /// </returns>
        /// <remarks>
        /// The key that the <see cref="RegCreateKeyEx"/> function creates has no values.
        /// An application can use the <see cref="RegSetValueEx"/> function to set key values.
        /// The <see cref="RegCreateKeyEx"/> function creates all missing keys in the specified path.
        /// An application can take advantage of this behavior to create several keys at once.
        /// For example, an application can create a subkey four levels deep at the same time
        /// as the three preceding subkeys by specifying a string of the following form for the <paramref name="lpSubKey"/> parameter:
        /// subkey1\subkey2\subkey3\subkey4
        /// Note that this behavior will result in creation of unwanted keys if an existing key in the path is spelled incorrectly.
        /// An application cannot create a key that is a direct child of <see cref="HKEY_USERS"/> or <see cref="HKEY_LOCAL_MACHINE"/>.
        /// An application can create subkeys in lower levels of the <see cref="HKEY_USERS"/> or <see cref="HKEY_LOCAL_MACHINE"/> trees.
        /// If your service or application impersonates different users, do not use this function with <see cref="HKEY_CURRENT_USER"/>.
        /// Instead, call the <see cref="RegOpenCurrentUser"/> function.
        /// Note that operations that access certain registry keys are redirected.
        /// For more information, see Registry Virtualization and 32-bit and 64-bit Application Data in the Registry.
        /// The winreg.h header defines <see cref="RegCreateKeyEx"/> as an alias which automatically selects the ANSI or Unicode version
        /// of this function based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead to mismatches
        /// that result in compilation or runtime errors.
        /// For more information, see Conventions for Function Prototypes.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegCreateKeyExW", ExactSpelling = true, SetLastError = true)]
        public static extern LSTATUS RegCreateKeyEx([In] HKEY hKey, [MarshalAs(UnmanagedType.LPWStr)][In] string lpSubKey, [In] DWORD Reserved,
            [MarshalAs(UnmanagedType.LPWStr)][In] string lpClass, [In] RegistryOptions dwOptions, [In] REGSAM samDesired,
            [In] in SECURITY_ATTRIBUTES lpSecurityAttributes, [Out] out HKEY phkResult, [Out] out RegistryKeyDispositions lpdwDisposition);

        /// <summary>
        /// <para>
        /// Creates the specified registry key and associates it with a transaction.
        /// If the key already exists, the function opens it. Note that key names are not case sensitive.
        /// Applications that back up or restore system state including system files and registry hives
        /// should use the Volume Shadow Copy Service instead of the registry functions.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winreg/nf-winreg-regcreatekeytransactedw
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// A handle to an open registry key.
        /// The calling process must have <see cref="KEY_CREATE_SUB_KEY"/> access to the key.
        /// For more information, see Registry Key Security and Access Rights.
        /// Access for key creation is checked against the security descriptor of the registry key,
        /// not the access mask specified when the handle was obtained.
        /// Therefore, even if <paramref name="hKey"/> was opened with a <paramref name="samDesired"/> of <see cref="KEY_READ"/>,
        /// it can be used in operations that create keys if allowed by its security descriptor.
        /// This handle is returned by the <see cref="RegCreateKeyTransacted"/> or <see cref="RegOpenKeyTransacted"/> function,
        /// or it can be one of the following predefined keys:
        /// <see cref="HKEY_CLASSES_ROOT"/> <see cref="HKEY_CURRENT_CONFIG"/> <see cref="HKEY_CURRENT_USER"/>
        /// <see cref="HKEY_LOCAL_MACHINE"/> <see cref="HKEY_USERS"/> 
        /// </param>
        /// <param name="lpSubKey">
        /// The name of a subkey that this function opens or creates.
        /// The subkey specified must be a subkey of the key identified by the <paramref name="hKey"/> parameter;
        /// it can be up to 32 levels deep in the registry tree.
        /// For more information on key names, see Structure of the Registry.
        /// If <paramref name="lpSubKey"/> is a pointer to an empty string,
        /// <paramref name="phkResult"/> receives a new handle to the key specified by <paramref name="hKey"/>.
        /// This parameter cannot be <see langword="null"/>.
        /// </param>
        /// <param name="Reserved">
        /// This parameter is reserved and must be zero.
        /// </param>
        /// <param name="lpClass">
        /// The user-defined class of this key.
        /// This parameter may be ignored.
        /// This parameter can be <see langword="null"/>.
        /// </param>
        /// <param name="dwOptions">
        /// This parameter can be one of the following values.
        /// <see cref="REG_OPTION_BACKUP_RESTORE"/>:
        /// If this flag is set, the function ignores the <paramref name="samDesired"/> parameter
        /// and attempts to open the key with the access required to backup or restore the key.
        /// If the calling thread has the SE_BACKUP_NAME privilege enabled, the key is opened
        /// with the <see cref="ACCESS_SYSTEM_SECURITY"/> and <see cref="KEY_READ"/> access rights.
        /// If the calling thread has the SE_RESTORE_NAME privilege enabled, the key is opened
        /// with the <see cref="ACCESS_SYSTEM_SECURITY"/> and <see cref="KEY_WRITE"/> access rights.
        /// If both privileges are enabled, the key has the combined access rights for both privileges.
        /// For more information, see Running with Special Privileges.
        /// <see cref="REG_OPTION_NON_VOLATILE"/>:
        /// This key is not volatile; this is the default.
        /// The information is stored in a file and is preserved when the system is restarted.
        /// The <see cref="RegSaveKey"/> function saves keys that are not volatile.
        /// <see cref="REG_OPTION_VOLATILE"/>:
        /// All keys created by the function are volatile.
        /// The information is stored in memory and is not preserved when the corresponding registry hive is unloaded.
        /// For <see cref="HKEY_LOCAL_MACHINE"/>, this occurs when the system is shut down.
        /// For registry keys loaded by the <see cref="RegLoadKey"/> function,
        /// this occurs when the corresponding <see cref="RegUnLoadKey"/> is performed.
        /// The <see cref="RegSaveKey"/> function does not save volatile keys.
        /// This flag is ignored for keys that already exist. 
        /// </param>
        /// <param name="samDesired">
        /// A mask that specifies the access rights for the key to be created.
        /// For more information, see Registry Key Security and Access Rights.
        /// </param>
        /// <param name="lpSecurityAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that determines
        /// whether the returned handle can be inherited by child processes.
        /// If <paramref name="lpSecurityAttributes"/> is <see cref="NullRef{SECURITY_ATTRIBUTES}"/>, the handle cannot be inherited.
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the new key.
        /// If <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> is <see cref="NULL"/>, the key gets a default security descriptor.
        /// The ACLs in a default security descriptor for a key are inherited from its direct parent key.
        /// </param>
        /// <param name="phkResult">
        /// A pointer to a variable that receives a handle to the opened or created key.
        /// If the key is not one of the predefined registry keys,
        /// call the <see cref="RegCloseKey"/> function after you have finished using the handle.
        /// </param>
        /// <param name="lpdwDisposition">
        /// A pointer to a variable that receives one of the following disposition values.
        /// <see cref="REG_CREATED_NEW_KEY"/>: The key did not exist and was created. 
        /// <see cref="REG_OPENED_EXISTING_KEY"/>: The key existed and was simply opened without being changed.
        /// If <paramref name="lpdwDisposition"/> is <see cref="NullRef{RegistryKeyDispositions}"/>, no disposition information is returned.
        /// </param>
        /// <param name="hTransaction">
        /// A handle to an active transaction.
        /// This handle is returned by the <see cref="CreateTransaction"/> function.
        /// </param>
        /// <param name="pExtendedParemeter">
        /// This parameter is reserved and must be <see cref="NULL"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag
        /// to get a generic description of the error.
        /// </returns>
        /// <remarks>
        /// When a key is created using this function, subsequent operations on the key are transacted.
        /// If a non-transacted operation is performed on the key before the transaction is committed, the transaction is rolled back.
        /// After a transaction is committed or rolled back, you must re-open the key
        /// using <see cref="RegCreateKeyTransacted"/> or <see cref="RegOpenKeyTransacted"/>
        /// with an active transaction handle to make additional operations transacted.
        /// For more information about transactions, see Kernel Transaction Manager.
        /// Note that subsequent operations on subkeys of this key are not automatically transacted.
        /// Therefore, <see cref="RegDeleteKeyEx"/> does not perform a transacted delete operation.
        /// Instead, use the <see cref="RegDeleteKeyTransacted"/> function to perform a transacted delete operation.
        /// The key that the <see cref="RegCreateKeyTransacted"/> function creates has no values.
        /// An application can use the <see cref="RegSetValueEx"/> function to set key values.
        /// The <see cref="RegCreateKeyTransacted"/> function creates all missing keys in the specified path.
        /// An application can take advantage of this behavior to create several keys at once.
        /// For example, an application can create a subkey four levels deep at the same time as the three preceding subkeys
        /// by specifying a string of the following form for the <paramref name="lpSubKey"/> parameter:
        /// subkey1\subkey2\subkey3\subkey4
        /// Note that this behavior will result in creation of unwanted keys if an existing key in the path is spelled incorrectly.
        /// An application cannot create a key that is a direct child of <see cref="HKEY_USERS"/> or <see cref="HKEY_LOCAL_MACHINE"/>.
        /// An application can create subkeys in lower levels of the <see cref="HKEY_USERS"/> or <see cref="HKEY_LOCAL_MACHINE"/> trees.
        /// The winreg.h header defines <see cref="RegCreateKeyTransacted"/> as an alias which automatically selects
        /// the ANSI or Unicode version of this function based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead to mismatches
        /// that result in compilation or runtime errors.
        /// For more information, see Conventions for Function Prototypes.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegCreateKeyTransactedW", ExactSpelling = true, SetLastError = true)]
        public static extern LSTATUS RegCreateKeyTransacted([In] HKEY hKey, [MarshalAs(UnmanagedType.LPWStr)][In] string lpSubKey,
            [In] DWORD Reserved, [MarshalAs(UnmanagedType.LPWStr)][In] string lpClass, [In] RegistryOptions dwOptions, [In] REGSAM samDesired,
            [In] in SECURITY_ATTRIBUTES lpSecurityAttributes, [Out] out HKEY phkResult, [Out] out RegistryKeyDispositions lpdwDisposition,
            [In] HANDLE hTransaction, PVOID pExtendedParemeter);

        /// <summary>
        /// <para>
        /// Deletes a subkey and its values from the specified platform-specific view of the registry.
        /// Note that key names are not case sensitive.
        /// To delete a subkey as a transacted operation, call the <see cref="RegDeleteKeyTransacted"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winreg/nf-winreg-regdeletekeyexw
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// A handle to an open registry key.
        /// The access rights of this key do not affect the delete operation.
        /// For more information about access rights, see Registry Key Security and Access Rights.
        /// This handle is returned by the <see cref="RegCreateKeyEx"/> or <see cref="RegOpenKeyEx"/> function,
        /// or it can be one of the following predefined keys:
        /// <see cref="HKEY_CLASSES_ROOT"/>, <see cref="HKEY_CURRENT_CONFIG"/>,  <see cref="HKEY_CURRENT_USER"/>,
        /// <see cref="HKEY_LOCAL_MACHINE"/>, <see cref="HKEY_USERS"/>
        /// </param>
        /// <param name="lpSubKey">
        /// The name of the key to be deleted.
        /// This key must be a subkey of the key specified by the value of the hKey parameter.
        /// The function opens the subkey with the <see cref="DELETE"/> access right.
        /// Key names are not case sensitive.
        /// The value of this parameter cannot be <see langword="null"/>.
        /// </param>
        /// <param name="samDesired">
        /// An access mask the specifies the platform-specific view of the registry.
        /// <see cref="KEY_WOW64_32KEY"/>: Delete the key from the 32-bit registry view.
        /// <see cref="KEY_WOW64_64KEY"/>: Delete the key from the 64-bit registry view. 
        /// </param>
        /// <param name="Reserved">
        /// This parameter is reserved and must be zero.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag
        /// to get a generic description of the error.
        /// </returns>
        /// <remarks>
        /// A deleted key is not removed until the last handle to it is closed.
        /// On WOW64, 32-bit applications view a registry tree that is separate from the registry tree that 64-bit applications view.
        /// This function enables an application to delete an entry in the alternate registry view.
        /// The subkey to be deleted must not have subkeys.
        /// To delete a key and all its subkeys, you need to enumerate the subkeys and delete them individually.
        /// To delete keys recursively, use the <see cref="RegDeleteTree"/> or <see cref="SHDeleteKey"/> function.
        /// If the function succeeds, RegDeleteKeyEx removes the specified key from the registry.
        /// The entire key, including all of its values, is removed.
        /// On legacy versions of Windows, this API is also exposed by kernel32.dll.
        /// The winreg.h header defines <see cref="RegDeleteKeyEx"/> as an alias which automatically selects
        /// the ANSI or Unicode version of this function based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead to mismatches
        /// that result in compilation or runtime errors.
        /// For more information, see Conventions for Function Prototypes.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegDeleteKeyExW", ExactSpelling = true, SetLastError = true)]
        public static extern LSTATUS RegDeleteKeyEx([In] HKEY hKey, [MarshalAs(UnmanagedType.LPWStr)][In] string lpSubKey,
            [In] REGSAM samDesired, [In] DWORD Reserved);

        /// <summary>
        /// <para>
        /// Deletes a subkey and its values from the specified platform-specific view of the registry as a transacted operation.
        /// Note that key names are not case sensitive.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winreg/nf-winreg-regdeletekeytransactedw
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// A handle to an open registry key. The access rights of this key do not affect the delete operation.
        /// For more information about access rights, see Registry Key Security and Access Rights.
        /// This handle is returned by the <see cref="RegCreateKeyEx"/>, <see cref="RegCreateKeyTransacted"/>,
        /// <see cref="RegOpenKeyEx"/>, or <see cref="RegOpenKeyTransacted"/> function.
        /// It can also be one of the following predefined keys:
        /// <see cref="HKEY_CLASSES_ROOT"/>, <see cref="HKEY_CURRENT_CONFIG"/>, <see cref="HKEY_CURRENT_USER"/>,
        /// <see cref="HKEY_LOCAL_MACHINE"/>, <see cref="HKEY_USERS"/>
        /// </param>
        /// <param name="lpSubKey">
        /// The name of the key to be deleted.
        /// This key must be a subkey of the key specified by the value of the <paramref name="hKey"/> parameter.
        /// The function opens the subkey with the <see cref="DELETE"/> access right.
        /// Key names are not case sensitive.
        /// The value of this parameter cannot be <see langword="null"/>.
        /// </param>
        /// <param name="samDesired">
        /// An access mask the specifies the platform-specific view of the registry.
        /// <see cref="KEY_WOW64_32KEY"/>: Delete the key from the 32-bit registry view.
        /// <see cref="KEY_WOW64_64KEY"/>: Delete the key from the 64-bit registry view. 
        /// </param>
        /// <param name="Reserved">
        /// This parameter is reserved and must be zero.
        /// </param>
        /// <param name="hTransaction">
        /// A handle to an active transaction.
        /// This handle is returned by the <see cref="CreateTransaction"/> function.
        /// </param>
        /// <param name="pExtendedParameter">
        /// This parameter is reserved and must be <see cref="NULL"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag
        /// to get a generic description of the error.
        /// </returns>
        /// <remarks>
        /// A deleted key is not removed until the last handle to it is closed.
        /// On WOW64, 32-bit applications view a registry tree that is separate from the registry tree that 64-bit applications view.
        /// This function enables an application to delete an entry in the alternate registry view.
        /// The subkey to be deleted must not have subkeys.
        /// To delete a key and all its subkeys, you need to enumerate the subkeys and delete them individually.
        /// To delete keys recursively, use the <see cref="RegDeleteTree"/> or <see cref="SHDeleteKey"/> function.
        /// If the function succeeds, <see cref="RegDeleteKeyTransacted"/> removes the specified key from the registry.
        /// The entire key, including all of its values, is removed.
        /// To remove the entire tree as a transacted operation, use the <see cref="RegDeleteTree"/> function
        /// with a handle returned from <see cref="RegCreateKeyTransacted"/> or <see cref="RegOpenKeyTransacted"/>.
        /// The winreg.h header defines <see cref="RegDeleteKeyTransacted"/> as an alias which automatically selects
        /// the ANSI or Unicode version of this function based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead to mismatches
        /// that result in compilation or runtime errors.
        /// For more information, see Conventions for Function Prototypes.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegDeleteKeyTransactedW", ExactSpelling = true, SetLastError = true)]
        public static extern LSTATUS RegDeleteKeyTransacted([In] HKEY hKey, [MarshalAs(UnmanagedType.LPWStr)][In] string lpSubKey,
            [In] REGSAM samDesired, [In] DWORD Reserved, [In] HANDLE hTransaction, [In] PVOID pExtendedParameter);

        /// <summary>
        /// <para>
        /// Deletes the subkeys and values of the specified key recursively.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winreg/nf-winreg-regdeletetreew
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// A handle to an open registry key.
        /// The key must have been opened with the following access rights:
        /// <see cref="DELETE"/>, <see cref="KEY_ENUMERATE_SUB_KEYS"/>, and <see cref="KEY_QUERY_VALUE"/>.
        /// For more information, see Registry Key Security and Access Rights.
        /// This handle is returned by the <see cref="RegCreateKeyEx"/> or <see cref="RegOpenKeyEx"/> function,
        /// or it can be one of the following Predefined Keys:
        /// <see cref="HKEY_CLASSES_ROOT"/>, <see cref="HKEY_CURRENT_CONFIG"/>, <see cref="HKEY_CURRENT_USER"/>,
        /// <see cref="HKEY_LOCAL_MACHINE"/>, <see cref="HKEY_USERS"/>
        /// </param>
        /// <param name="lpSubKey">
        /// The name of the key.
        /// This key must be a subkey of the key identified by the <paramref name="hKey"/> parameter.
        /// If this parameter is <see langword="null"/>, the subkeys and values of <paramref name="hKey"/> are deleted.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag
        /// to get a generic description of the error.
        /// </returns>
        /// <remarks>
        /// If the key has values, it must be opened with <see cref="KEY_SET_VALUE"/>
        /// or this function will fail with <see cref="ERROR_ACCESS_DENIED"/>.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or later.
        /// For more information, see Using the Windows Headers.
        /// On legacy versions of Windows, this API is also exposed by kernel32.dll.
        /// The winreg.h header defines <see cref="RegDeleteTree"/> as an alias which automatically selects
        /// the ANSI or Unicode version of this function based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead to mismatches
        /// that result in compilation or runtime errors.
        /// For more information, see Conventions for Function Prototypes.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegDeleteTreeW", ExactSpelling = true, SetLastError = true)]
        public static extern LSTATUS RegDeleteTree([In] HKEY hKey, [MarshalAs(UnmanagedType.LPWStr)][In] string lpSubKey);

        /// <summary>
        /// <para>
        /// Loads the specified registry hive as an application hive.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winreg/nf-winreg-regloadappkeyw
        /// </para>
        /// </summary>
        /// <param name="lpFile">
        /// The name of the hive file.
        /// This hive must have been created with the <see cref="RegSaveKey"/> or <see cref="RegSaveKeyEx"/> function.
        /// If the file does not exist, an empty hive file is created with the specified name.
        /// </param>
        /// <param name="phkResult">
        /// Pointer to the handle for the root key of the loaded hive.
        /// The only way to access keys in the hive is through this handle.
        /// The registry will prevent an application from accessing keys in this hive using an absolute path to the key.
        /// As a result, it is not possible to navigate to this hive through the registry's namespace.
        /// </param>
        /// <param name="samDesired">
        /// A mask that specifies the access rights requested for the returned root key.
        /// For more information, see Registry Key Security and Access Rights.
        /// </param>
        /// <param name="dwOptions">
        /// If this parameter is <see cref="REG_PROCESS_APPKEY"/>, the hive cannot be loaded again while it is loaded by the caller.
        /// This prevents access to this registry hive by another caller.
        /// </param>
        /// <param name="Reserved">
        /// This parameter is reserved.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag
        /// to get a generic description of the error.
        /// </returns>
        /// <remarks>
        /// Unlike <see cref="RegLoadKey"/>, <see cref="RegLoadAppKey"/> does not load
        /// the hive under <see cref="HKEY_LOCAL_MACHINE"/> or <see cref="HKEY_USERS"/>.
        /// Instead, the hive is loaded under a special root that cannot be enumerated.
        /// As a result, there is no way to enumerate hives currently loaded by <see cref="RegLoadAppKey"/>.
        /// All operations on hives loaded by <see cref="RegLoadAppKey"/> have to be performed relative
        /// to the handle returned in <paramref name="phkResult"/>.
        /// If two processes are required to perform operations on the same hive,
        /// each process must call <see cref="RegLoadAppKey"/> to retrieve a handle.
        /// During the <see cref="RegLoadAppKey"/> operation, the registry will verify if the file has already been loaded.
        /// If it has been loaded, the registry will return a handle to the previously loaded hive rather than re-loading the hive.
        /// All keys inside the hive must have the same security descriptor, otherwise the function will fail.
        /// This security descriptor must grant the caller the access specified by
        /// the <paramref name="samDesired"/> parameter or the function will fail.
        /// You cannot use the <see cref="RegSetKeySecurity"/> function on any key inside the hive.
        /// In Windows 8 and later, each process can call <see cref="RegLoadAppKey"/> to load multiple hives.
        /// In Windows 7 and earlier, each process can load only one hive using <see cref="RegLoadAppKey"/> at a time.
        /// Any hive loaded using <see cref="RegLoadAppKey"/> is automatically unloaded
        /// when all handles to the keys inside the hive are closed using <see cref="RegCloseKey"/>.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or later.
        /// For more information, see Using the Windows Headers.
        /// The winreg.h header defines <see cref="RegLoadAppKey"/> as an alias which automatically selects
        /// the ANSI or Unicode version of this function based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead to mismatches
        /// that result in compilation or runtime errors.
        /// For more information, see Conventions for Function Prototypes.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegLoadAppKeyW", ExactSpelling = true, SetLastError = true)]
        public static extern LSTATUS RegLoadAppKey([MarshalAs(UnmanagedType.LPWStr)][In] string lpFile, [Out] out HKEY phkResult,
            [In] REGSAM samDesired, [In] DWORD dwOptions, [In] DWORD Reserved);

        /// <summary>
        /// <para>
        /// Creates a subkey under <see cref="HKEY_USERS"/> or <see cref="HKEY_LOCAL_MACHINE"/>
        /// and loads the data from the specified registry hive into that subkey.
        /// Applications that back up or restore system state including system files and registry hives
        /// should use the Volume Shadow Copy Service instead of the registry functions.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winreg/nf-winreg-regloadkeyw
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// A handle to the key where the subkey will be created.
        /// This can be a handle returned by a call to <see cref="RegConnectRegistry"/>, or one of the following predefined handles:
        /// <see cref="HKEY_LOCAL_MACHINE"/> <see cref="HKEY_USERS"/>
        /// This function always loads information at the top of the registry hierarchy.
        /// The <see cref="HKEY_CLASSES_ROOT"/> and <see cref="HKEY_CURRENT_USER"/> handle values cannot be specified for this parameter,
        /// because they represent subsets of the <see cref="HKEY_LOCAL_MACHINE"/> and <see cref="HKEY_USERS"/> handle values, respectively.
        /// </param>
        /// <param name="lpSubKey">
        /// The name of the key to be created under <paramref name="hKey"/>.
        /// This subkey is where the registration information from the file will be loaded.
        /// Key names are not case sensitive.
        /// For more information, see Registry Element Size Limits.
        /// </param>
        /// <param name="lpFile">
        /// The name of the file containing the registry data.
        /// This file must be a local file that was created with the <see cref="RegSaveKey"/> function.
        /// If this file does not exist, a file is created with the specified name.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag
        /// to get a generic description of the error.
        /// </returns>
        /// <remarks>
        /// There are two registry hive file formats.
        /// Registry hives created on current operating systems typically cannot be loaded by earlier ones.
        /// If <paramref name="hKey"/> is a handle returned by <see cref="RegConnectRegistry"/>,
        /// then the path specified in <paramref name="lpFile"/> is relative to the remote computer.
        /// The calling process must have the SE_RESTORE_NAME and SE_BACKUP_NAME privileges on the computer in which the registry resides.
        /// For more information, see Running with Special Privileges.
        /// To load a hive without requiring these special privileges, use the <see cref="RegLoadAppKey"/> function.
        /// The winreg.h header defines <see cref="RegLoadKey"/> as an alias which automatically selects the ANSI or Unicode version
        /// of this function based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead to mismatches
        /// that result in compilation or runtime errors. For more information, see Conventions for Function Prototypes.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegLoadKeyW", ExactSpelling = true, SetLastError = true)]
        public static extern LSTATUS RegLoadKey([In] HKEY hKey, [MarshalAs(UnmanagedType.LPWStr)][In] string lpSubKey,
            [MarshalAs(UnmanagedType.LPWStr)][In] string lpFile);

        /// <summary>
        /// <para>
        /// Retrieves a handle to the <see cref="HKEY_CURRENT_USER"/> key for the user the current thread is impersonating.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winreg/nf-winreg-regopencurrentuser
        /// </para>
        /// </summary>
        /// <param name="samDesired">
        /// A mask that specifies the desired access rights to the key.
        /// The function fails if the security descriptor of the key does not permit the requested access for the calling process.
        /// For more information, see Registry Key Security and Access Rights.
        /// </param>
        /// <param name="phkResult">
        /// A pointer to a variable that receives a handle to the opened key.
        /// When you no longer need the returned handle, call the <see cref="RegCloseKey"/> function to close it.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag
        /// to get a generic description of the error.
        /// </returns>
        /// <remarks>
        /// The <see cref="HKEY_CURRENT_USER"/> key maps to the root of the current user's branch in the <see cref="HKEY_USERS"/> key.
        /// It is cached for all threads in a process. Therefore, this value does not change when another user's profile is loaded.
        /// <see cref="RegOpenCurrentUser"/> uses the thread's token to access the appropriate key, or the default if the profile is not loaded.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegOpenCurrentUser", ExactSpelling = true, SetLastError = true)]
        public static extern LSTATUS RegOpenCurrentUser([In] REGSAM samDesired, [Out] out HKEY phkResult);

        /// <summary>
        /// <para>
        /// Opens the specified registry key.
        /// Note that key names are not case sensitive.
        /// To perform transacted registry operations on a key, call the <see cref="RegOpenKeyTransacted"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winreg/nf-winreg-regopenkeyexw
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// A handle to an open registry key.
        /// This handle is returned by the <see cref="RegCreateKeyEx"/> or <see cref="RegOpenKeyEx"/> function,
        /// or it can be one of the following predefined keys:
        /// <see cref="HKEY_CLASSES_ROOT"/> <see cref="HKEY_CURRENT_CONFIG"/>
        /// <see cref="HKEY_CURRENT_USER"/> <see cref="HKEY_LOCAL_MACHINE"/>
        /// <see cref="HKEY_USERS"/>
        /// </param>
        /// <param name="lpSubKey">
        /// The name of the registry subkey to be opened.
        /// Key names are not case sensitive.
        /// The <paramref name="lpSubKey"/> parameter can be a pointer to an empty string.
        /// If <paramref name="lpSubKey"/> is a pointer to an empty string and <paramref name="hKey"/> is <see cref="HKEY_CLASSES_ROOT"/>,
        /// <paramref name="phkResult"/> receives the same <paramref name="hKey"/> handle passed into the function.
        /// Otherwise, <paramref name="phkResult"/> receives a new handle to the key specified by hKey.
        /// The <paramref name="lpSubKey"/> parameter can be <see langword="null"/> only if hKey is one of the predefined keys.
        /// If <paramref name="lpSubKey"/> is <see langword="null"/> and <paramref name="hKey"/> is <see cref="HKEY_CLASSES_ROOT"/>,
        /// <paramref name="phkResult"/> receives a new handle to the key specified by <paramref name="hKey"/>.
        /// Otherwise, <paramref name="phkResult"/> receives the same <paramref name="hKey"/> handle passed in to the function.
        /// For more information, see Registry Element Size Limits.
        /// </param>
        /// <param name="ulOptions">
        /// Specifies the option to apply when opening the key.
        /// Set this parameter to zero or the following:
        /// <see cref="REG_OPTION_OPEN_LINK"/>:
        /// The key is a symbolic link.
        /// Registry symbolic links should only be used when absolutely necessary.
        /// </param>
        /// <param name="samDesired">
        /// A mask that specifies the desired access rights to the key to be opened.
        /// The function fails if the security descriptor of the key does not permit the requested access for the calling process.
        /// For more information, see Registry Key Security and Access Rights.
        /// </param>
        /// <param name="phkResult">
        /// A pointer to a variable that receives a handle to the opened key.
        /// If the key is not one of the predefined registry keys,
        /// call the <see cref="RegCloseKey"/> function after you have finished using the handle.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag
        /// to get a generic description of the error.
        /// </returns>
        /// <remarks>
        /// Unlike the <see cref="RegCreateKeyEx"/> function, the <see cref="RegOpenKeyEx"/> function does not create the specified key
        /// if the key does not exist in the registry.
        /// Certain registry operations perform access checks against the security descriptor of the key, not the access mask specified
        /// when the handle to the key was obtained.
        /// For example, even if a key is opened with a <paramref name="samDesired"/> of <see cref="KEY_READ"/>,
        /// it can be used to create registry keys if the key's security descriptor permits.
        /// In contrast, the <see cref="RegSetValueEx"/> function specifically requires
        /// that the key be opened with the <see cref="KEY_SET_VALUE"/> access right.
        /// If your service or application impersonates different users, do not use this function with <see cref="HKEY_CURRENT_USER"/>.
        /// Instead, call the <see cref="RegOpenCurrentUser"/> function.
        /// Note that operations that access certain registry keys are redirected.
        /// For more information, see Registry Virtualization and 32-bit and 64-bit Application Data in the Registry.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegOpenKeyExW", ExactSpelling = true, SetLastError = true)]
        public static extern LSTATUS RegOpenKeyEx([In] HKEY hKey, [MarshalAs(UnmanagedType.LPWStr)][In] string lpSubKey,
            [In] RegistryOptions ulOptions, [In] REGSAM samDesired, [Out] out HKEY phkResult);

        /// <summary>
        /// <para>
        /// Opens the specified registry key and associates it with a transaction.
        /// Note that key names are not case sensitive.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winreg/nf-winreg-regopenkeytransactedw
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// A handle to an open registry key.
        /// This handle is returned by the <see cref="RegCreateKeyEx"/>, <see cref="RegCreateKeyTransacted"/>,
        /// <see cref="RegOpenKeyEx"/>, or <see cref="RegOpenKeyTransacted"/> function.
        /// It can also be one of the following predefined keys:
        /// <see cref="RegOpenKeyTransacted"/> <see cref="HKEY_CURRENT_USER"/>
        /// <see cref="HKEY_LOCAL_MACHINE"/> <see cref="HKEY_USERS"/>
        /// </param>
        /// <param name="lpSubKey">
        /// The name of the registry subkey to be opened.
        /// Key names are not case sensitive.
        /// If this parameter is <see langword="null"/> or a pointer to an empty string,
        /// the function will open a new handle to the key identified by the <paramref name="hKey"/> parameter.
        /// For more information, see Registry Element Size Limits.
        /// </param>
        /// <param name="ulOptions">
        /// This parameter is reserved and must be zero.
        /// </param>
        /// <param name="samDesired">
        /// A mask that specifies the desired access rights to the key.
        /// The function fails if the security descriptor of the key does not permit the requested access for the calling process.
        /// For more information, see Registry Key Security and Access Rights.
        /// </param>
        /// <param name="phkResult">
        /// A pointer to a variable that receives a handle to the opened key.
        /// If the key is not one of the predefined registry keys,
        /// call the <see cref="RegCloseKey"/> function after you have finished using the handle.
        /// </param>
        /// <param name="hTransaction">
        /// A handle to an active transaction.
        /// This handle is returned by the <see cref="CreateTransaction"/> function.
        /// </param>
        /// <param name="pExtendedParemeter">
        /// This parameter is reserved and must be <see cref="NULL"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag
        /// to get a generic description of the error.
        /// </returns>
        /// <remarks>
        /// When a key is opened using this function, subsequent operations on the key are transacted.
        /// If a non-transacted operation is performed on the key before the transaction is committed, the transaction is rolled back.
        /// After a transaction is committed or rolled back, you must re-open the key using the <see cref="RegCreateKeyTransacted"/>
        /// or <see cref="RegOpenKeyTransacted"/> function with an active transaction handle to make additional operations transacted.
        /// For more information about transactions, see Kernel Transaction Manager.
        /// Note that subsequent operations on subkeys of this key are not automatically transacted.
        /// Therefore, the <see cref="RegDeleteKeyEx"/> function does not perform a transacted delete operation.
        /// Instead, use the <see cref="RegDeleteKeyTransacted"/> function to perform a transacted delete operation.
        /// Unlike the <see cref="RegCreateKeyTransacted"/> function, the <see cref="RegOpenKeyTransacted"/> function
        /// does not create the specified key if the key does not exist in the registry.
        /// If your service or application impersonates different users, do not use this function with <see cref="HKEY_CURRENT_USER"/>.
        /// Instead, call the <see cref="RegOpenCurrentUser"/> function.
        /// A single registry key can be opened only 65,534 times. When attempting the 65,535th open operation,
        /// this function fails with <see cref="ERROR_NO_SYSTEM_RESOURCES"/>.
        /// The winreg.h header defines <see cref="RegOpenKeyTransacted"/> as an alias which automatically selects
        /// the ANSI or Unicode version of this function based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead to mismatches
        /// that result in compilation or runtime errors.
        /// For more information, see Conventions for Function Prototypes.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegOpenKeyTransactedW", ExactSpelling = true, SetLastError = true)]
        public static extern LSTATUS RegOpenKeyTransacted([In] HKEY hKey, [MarshalAs(UnmanagedType.LPWStr)][In] string lpSubKey,
            [In] RegistryOptions ulOptions, [In] REGSAM samDesired, [Out] out HKEY phkResult, [In] HANDLE hTransaction, [In] PVOID pExtendedParemeter);

        /// <summary>
        /// <para>
        /// Replaces the file backing a registry key and all its subkeys with another file, so that when the system is next started,
        /// the key and subkeys will have the values stored in the new file.
        /// Applications that back up or restore system state including system files and registry hives
        /// should use the Volume Shadow Copy Service instead of the registry functions.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winreg/nf-winreg-regreplacekeyw
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// A handle to an open registry key.
        /// This handle is returned by the <see cref="RegCreateKeyEx"/> or <see cref="RegOpenKeyEx"/> function,
        /// or it can be one of the following predefined keys:
        /// <see cref="HKEY_CLASSES_ROOT"/> <see cref="HKEY_CURRENT_CONFIG"/> <see cref="HKEY_CURRENT_USER"/>
        /// <see cref="HKEY_LOCAL_MACHINE"/> <see cref="HKEY_USERS"/>
        /// </param>
        /// <param name="lpSubKey">
        /// The name of the registry key whose subkeys and values are to be replaced.
        /// If the key exists, it must be a subkey of the key identified by the <paramref name="hKey"/> parameter.
        /// If the subkey does not exist, it is created. This parameter can be <see langword="null"/>.
        /// If the specified subkey is not the root of a hive, <see cref="RegReplaceKey"/> traverses up the hive tree structure
        /// until it encounters a hive root, then it replaces the contents of that hive with the contents of the data file
        /// specified by <paramref name="lpNewFile"/>.
        /// For more information, see Registry Element Size Limits.
        /// </param>
        /// <param name="lpNewFile">
        /// The name of the file with the registry information.
        /// This file is typically created by using the <see cref="RegSaveKey"/> function.
        /// </param>
        /// <param name="lpOldFile">
        /// The name of the file that receives a backup copy of the registry information being replaced.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag
        /// to get a generic description of the error.
        /// </returns>
        /// <remarks>
        /// There are two different registry hive file formats.
        /// Registry hives created on current operating systems typically cannot be loaded by earlier ones.
        /// The file specified by the <paramref name="lpNewFile"/> parameter remains open until the system is restarted.
        /// If <paramref name="hKey"/> is a handle returned by <see cref="RegConnectRegistry"/>, then the paths specified
        /// in <paramref name="lpNewFile"/> and <paramref name="lpOldFile"/> are relative to the remote computer.
        /// The calling process must have the SE_RESTORE_NAME and SE_BACKUP_NAME privileges on the computer in which the registry resides.
        /// For more information, see Running with Special Privileges.
        /// The winreg.h header defines <see cref="RegReplaceKey"/> as an alias which automatically selects
        /// the ANSI or Unicode version of this function based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead to mismatches
        /// that result in compilation or runtime errors.
        /// For more information, see Conventions for Function Prototypes.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegReplaceKeyW", ExactSpelling = true, SetLastError = true)]
        public static extern LSTATUS RegReplaceKey([In] HKEY hKey, [MarshalAs(UnmanagedType.LPWStr)][In] string lpSubKey,
            [MarshalAs(UnmanagedType.LPWStr)][In] string lpNewFile, [MarshalAs(UnmanagedType.LPWStr)][In] string lpOldFile);

        /// <summary>
        /// <para>
        /// Reads the registry information in a specified file and copies it over the specified key.
        /// This registry information may be in the form of a key and multiple levels of subkeys.
        /// Applications that back up or restore system state including system files and registry hives
        /// should use the Volume Shadow Copy Service instead of the registry functions.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winreg/nf-winreg-regrestorekeyw
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// A handle to an open registry key.
        /// This handle is returned by the <see cref="RegCreateKeyEx"/> or <see cref="RegOpenKeyEx"/> function.
        /// It can also be one of the following predefined keys:
        /// <see cref="HKEY_CLASSES_ROOT"/> <see cref="HKEY_CURRENT_CONFIG"/> <see cref="HKEY_CURRENT_USER"/>
        /// <see cref="HKEY_LOCAL_MACHINE"/> <see cref="HKEY_USERS"/>
        /// Any information contained in this key and its descendent keys is overwritten
        /// by the information in the file pointed to by the <paramref name="lpFile"/> parameter.
        /// </param>
        /// <param name="lpFile">
        /// The name of the file with the registry information.
        /// This file is typically created by using the <see cref="RegSaveKey"/> function.
        /// </param>
        /// <param name="dwFlags">
        /// The flags that indicate how the key or keys are to be restored. This parameter can be one of the following values.
        /// <see cref="REG_FORCE_RESTORE"/> <see cref="REG_WHOLE_HIVE_VOLATILE"/>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag
        /// to get a generic description of the error.
        /// </returns>
        /// <remarks>
        /// There are two different registry hive file formats.
        /// Registry hives created on current operating systems typically cannot be loaded by earlier ones.
        /// If any subkeys of the <paramref name="hKey"/> parameter are open, <see cref="RegRestoreKey"/> fails.
        /// The calling process must have the SE_RESTORE_NAME and SE_BACKUP_NAME privileges on the computer in which the registry resides.
        /// For more information, see Running with Special Privileges.
        /// This function replaces the keys and values below the specified key with the keys and values
        /// that are subsidiary to the top-level key in the file, no matter what the name of the top-level key in the file might be.
        /// For example, <paramref name="hKey"/> might identify a key A with subkeys B and C, while the <paramref name="lpFile"/> parameter
        /// specifies a file containing key X with subkeys Y and Z.
        /// After a call to <see cref="RegRestoreKey"/>, the registry would contain key A with subkeys Y and Z.
        /// The value entries of A would be replaced by the value entries of X.
        /// The new information in the file specified by lpFile overwrites the contents of the key
        /// specified by the <paramref name="hKey"/> parameter, except for the key name.
        /// If <paramref name="hKey"/> represents a key in a remote computer,
        /// the path described by <paramref name="lpFile"/> is relative to the remote computer.
        /// The winreg.h header defines RegRestoreKey as an alias which automatically selects
        /// the ANSI or Unicode version of this function based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead to mismatches
        /// that result in compilation or runtime errors.
        /// For more information, see Conventions for Function Prototypes.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegRestoreKeyW", ExactSpelling = true, SetLastError = true)]
        public static extern LSTATUS RegRestoreKey([In] HKEY hKey, [MarshalAs(UnmanagedType.LPWStr)][In] string lpFile, [In] RegRestoreKeyFlags dwFlags);

        /// <summary>
        /// <para>
        /// Saves the specified key and all of its subkeys and values to a new file, in the standard format.
        /// To specify the format for the saved key or hive, use the <see cref="RegSaveKeyEx"/> function.
        /// Applications that back up or restore system state including system files and registry hives
        /// should use the Volume Shadow Copy Service instead of the registry functions.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winreg/nf-winreg-regsavekeyw
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// A handle to an open registry key.
        /// This handle is returned by the <see cref="RegCreateKeyEx"/> or <see cref="RegOpenKeyEx"/> function,
        /// or it can be one of the following predefined keys:
        /// <see cref="HKEY_CLASSES_ROOT"/> <see cref="HKEY_CURRENT_USER"/> 
        /// </param>
        /// <param name="lpFile">
        /// The name of the file in which the specified key and subkeys are to be saved.
        /// If the file already exists, the function fails.
        /// If the string does not include a path, the file is created in the current directory of the calling process for a local key,
        /// or in the %systemroot%\system32 directory for a remote key.
        /// The new file has the archive attribute.
        /// </param>
        /// <param name="lpSecurityAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that specifies a security descriptor for the new file.
        /// If <paramref name="lpSecurityAttributes"/> is <see cref="NullRef{SECURITY_ATTRIBUTES}"/>, the file gets a default security descriptor.
        /// The ACLs in a default security descriptor for a file are inherited from its parent directory.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag
        /// to get a generic description of the error.
        /// If the file already exists, the function fails with the <see cref="ERROR_ALREADY_EXISTS"/> error.
        /// </returns>
        /// <remarks>
        /// If <paramref name="hKey"/> represents a key on a remote computer,
        /// the path described by <paramref name="lpFile"/> is relative to the remote computer.
        /// The <see cref="RegSaveKey"/> function saves only nonvolatile keys.
        /// It does not save volatile keys. A key is made volatile or nonvolatile at its creation; see <see cref="RegCreateKeyEx"/>.
        /// You can use the file created by <see cref="RegSaveKey"/> in subsequent calls to the <see cref="RegLoadKey"/>,
        /// <see cref="RegReplaceKey"/>, or <see cref="RegRestoreKey"/> functions.
        /// If <see cref="RegSaveKey"/> fails part way through its operation, the file will be corrupt
        /// and subsequent calls to <see cref="RegLoadKey"/>, <see cref="RegReplaceKey"/>, or <see cref="RegRestoreKey"/> for the file will fail.
        /// Using <see cref="RegSaveKey"/> together with <see cref="RegRestoreKey"/> to copy subtrees in the registry is not recommended.
        /// This method does not trigger notifications and can invalidate handles used by other applications.
        /// Instead, use the <see cref="SHCopyKey"/> function or the <see cref="RegCopyTree"/> function.
        /// The calling process must have the SE_BACKUP_NAME privilege enabled. For more information, see Running with Special Privileges.
        /// The winreg.h header defines <see cref="RegSaveKey"/> as an alias which automatically selects the ANSI or Unicode version
        /// of this function based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead to mismatches
        /// that result in compilation or runtime errors. For more information, see Conventions for Function Prototypes.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegSaveKeyW", ExactSpelling = true, SetLastError = true)]
        public static extern LSTATUS RegSaveKey([In] in HKEY hKey, [MarshalAs(UnmanagedType.LPWStr)][In] string lpFile,
            [In] in SECURITY_ATTRIBUTES lpSecurityAttributes);

        /// <summary>
        /// <para>
        /// Saves the specified key and all of its subkeys and values to a registry file, in the specified format.
        /// Applications that back up or restore system state including system files and registry hives
        /// should use the Volume Shadow Copy Service instead of the registry functions.
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// A handle to an open registry key.
        /// This function does not support the <see cref="HKEY_CLASSES_ROOT"/> predefined key.
        /// </param>
        /// <param name="lpFile">
        /// The name of the file in which the specified key and subkeys are to be saved.
        /// If the file already exists, the function fails.
        /// The new file has the archive attribute.
        /// If the string does not include a path, the file is created in the current directory of the calling process for a local key,
        /// or in the %systemroot%\system32 directory for a remote key.
        /// </param>
        /// <param name="lpSecurityAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that specifies a security descriptor for the new file.
        /// If <paramref name="lpSecurityAttributes"/> is <see cref="NullRef{SECURITY_ATTRIBUTES}"/>, the file gets a default security descriptor.
        /// The ACLs in a default security descriptor for a file are inherited from its parent directory.
        /// </param>
        /// <param name="Flags">
        /// The format of the saved key or hive. This parameter can be one of the following values.
        /// <see cref="REG_STANDARD_FORMAT"/>, <see cref="REG_LATEST_FORMAT"/>, <see cref="REG_NO_COMPRESSION"/>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag
        /// to get a generic description of the error.
        /// If the file already exists, the function fails with the <see cref="ERROR_ALREADY_EXISTS"/> error.
        /// If more than one of the possible values listed above for the <paramref name="Flags"/> parameter is specified
        /// in one call to this function—for example, if two or more values are OR'ed— or if <see cref="REG_NO_COMPRESSION"/> is specified
        /// and <paramref name="hKey"/> specifies a key that is not the root of a hive, this function returns <see cref="ERROR_INVALID_PARAMETER"/>.
        /// </returns>
        /// <remarks>
        /// Unlike <see cref="RegSaveKey"/>, this function does not support the <see cref="HKEY_CLASSES_ROOT"/> predefined key.
        /// If <paramref name="hKey"/> represents a key on a remote computer,
        /// the path described by <paramref name="lpFile"/> is relative to the remote computer.
        /// The <see cref="RegSaveKeyEx"/> function saves only nonvolatile keys. It does not save volatile keys.
        /// A key is made volatile or nonvolatile at its creation; see <see cref="RegCreateKeyEx"/>.
        /// You can use the file created by <see cref="RegSaveKeyEx"/> in subsequent calls
        /// to the <see cref="RegLoadKey"/>, <see cref="RegReplaceKey"/>, or <see cref="RegRestoreKey"/> function.
        /// If <see cref="RegSaveKeyEx"/> fails partway through its operation, the file will be corrupt and subsequent calls
        /// to <see cref="RegLoadKey"/>, <see cref="RegReplaceKey"/>, or <see cref="RegRestoreKey"/> for the file will fail.
        /// Using <see cref="RegSaveKeyEx"/> together with <see cref="RegRestoreKey"/> to copy subtrees in the registry is not recommended.
        /// This method does not trigger notifications and can invalidate handles used by other applications.
        /// Instead, use the <see cref="SHCopyKey"/> function or the <see cref="RegCopyTree"/> function.
        /// The calling process must have the SE_BACKUP_NAME privilege enabled.
        /// For more information, see Running with Special Privileges.
        /// The winreg.h header defines <see cref="RegSaveKeyEx"/> as an alias which automatically selects
        /// the ANSI or Unicode version of this function based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead to mismatches
        /// that result in compilation or runtime errors.
        /// For more information, see Conventions for Function Prototypes.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegSaveKeyExW", ExactSpelling = true, SetLastError = true)]
        public static extern LSTATUS RegSaveKeyEx([In] in HKEY hKey, [MarshalAs(UnmanagedType.LPWStr)][In] string lpFile,
            [In] in SECURITY_ATTRIBUTES lpSecurityAttributes, [In] RegSaveKeyExFlags Flags);

        /// <summary>
        /// <para>
        /// The <see cref="RegSetKeySecurity"/> function sets the security of an open registry key.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winreg/nf-winreg-regsetkeysecurity
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// A handle to an open key for which the security descriptor is set.
        /// </param>
        /// <param name="SecurityInformation">
        /// A set of bit flags that indicate the type of security information to set.
        /// This parameter can be a combination of the <see cref="SECURITY_INFORMATION"/> bit flags.
        /// </param>
        /// <param name="pSecurityDescriptor">
        /// A pointer to a <see cref="SECURITY_DESCRIPTOR"/> structure that specifies the security attributes to set for the specified key.
        /// </param>
        /// <returns>
        /// If the function succeeds, the function returns <see cref="ERROR_SUCCESS"/>.
        /// If the function fails, it returns a nonzero error code defined in WinError.h.
        /// You can use the <see cref="FormatMessage"/> function with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag
        /// to get a generic description of the error.
        /// </returns>
        /// <remarks>
        /// If <paramref name="hKey"/> is one of the predefined keys, use the <see cref="RegCloseKey"/> function to close the predefined key
        /// to ensure that the new security information is in effect the next time the predefined key is referenced.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegSetKeySecurity", ExactSpelling = true, SetLastError = true)]
        public static extern LSTATUS RegSetKeySecurity([In] HKEY hKey, [In] SECURITY_INFORMATION SecurityInformation,
            [In] PSECURITY_DESCRIPTOR pSecurityDescriptor);

        /// <summary>
        /// <para>
        /// Sets the data for the specified value in the specified registry key and subkey.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winreg/nf-winreg-regsetkeyvaluew
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// A handle to an open registry key.
        /// The key must have been opened with the <see cref="KEY_SET_VALUE"/> access right.
        /// For more information, see Registry Key Security and Access Rights.
        /// This handle is returned by the <see cref="RegCreateKeyEx"/>, <see cref="RegCreateKeyTransacted"/>,
        /// <see cref="RegOpenKeyEx"/>, or <see cref="RegOpenKeyTransacted"/> function.
        /// It can also be one of the following predefined keys:
        /// <see cref="HKEY_CLASSES_ROOT"/> <see cref="HKEY_CURRENT_CONFIG"/>  <see cref="HKEY_CURRENT_USER"/>
        /// <see cref="HKEY_LOCAL_MACHINE"/> <see cref="HKEY_USERS"/>
        /// </param>
        /// <param name="lpSubKey">
        /// The name of a key and a subkey to the key identified by <paramref name="hKey"/>.
        /// If this parameter is <see langword="null"/>, then this value is created in the key
        /// using the <paramref name="hKey"/> value and the key gets a default security descriptor.
        /// </param>
        /// <param name="lpValueName">
        /// The name of the registry value whose data is to be updated.
        /// </param>
        /// <param name="dwType">
        /// The type of data pointed to by the <paramref name="lpData"/> parameter.
        /// For a list of the possible types, see Registry Value Types.
        /// </param>
        /// <param name="lpData">
        /// The data to be stored with the specified value name.
        /// For string-based types, such as <see cref="REG_SZ"/>, the string must be null-terminated.
        /// With the <see cref="REG_MULTI_SZ"/> data type, the string must be terminated with two null characters.
        /// </param>
        /// <param name="cbData">
        /// The size of the information pointed to by the <paramref name="lpData"/> parameter, in bytes.
        /// If the data is of type <see cref="REG_SZ"/>, <see cref="REG_EXPAND_SZ"/>, or <see cref="REG_MULTI_SZ"/>,
        /// <paramref name="cbData"/> must include the size of the terminating null character or characters.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag
        /// to get a generic description of the error.
        /// </returns>
        /// <remarks>
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or later.
        /// For more information, see Using the Windows Headers.
        /// The winreg.h header defines <see cref="RegSetKeyValue"/> as an alias which automatically
        /// selects the ANSI or Unicode version of this function based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead to mismatches
        /// that result in compilation or runtime errors.
        /// For more information, see Conventions for Function Prototypes.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegSetKeyValueW", ExactSpelling = true, SetLastError = true)]
        public static extern LSTATUS RegSetKeyValue([In] HKEY hKey, [MarshalAs(UnmanagedType.LPWStr)][In] string lpSubKey,
             [MarshalAs(UnmanagedType.LPWStr)][In] string lpValueName, [In] RegistryValueTypes dwType, [In] LPCVOID lpData, [In] DWORD cbData);

        /// <summary>
        /// <para>
        /// Sets the data and type of a specified value under a registry key.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winreg/nf-winreg-regsetvalueexw
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// A handle to an open registry key.
        /// The key must have been opened with the <see cref="KEY_SET_VALUE"/> access right.
        /// For more information, see Registry Key Security and Access Rights.
        /// This handle is returned by the <see cref="RegCreateKeyEx"/>, <see cref="RegCreateKeyTransacted"/>,
        /// <see cref="RegOpenKeyEx"/>, or <see cref="RegOpenKeyTransacted"/> function.
        /// It can also be one of the following predefined keys:
        /// <see cref="HKEY_CLASSES_ROOT"/> <see cref="HKEY_CURRENT_CONFIG"/> <see cref="HKEY_CURRENT_USER"/>
        /// <see cref="HKEY_LOCAL_MACHINE"/> <see cref="HKEY_USERS"/>
        /// The Unicode version of this function supports the following additional predefined keys:
        /// <see cref="HKEY_PERFORMANCE_TEXT"/> <see cref="HKEY_PERFORMANCE_NLSTEXT"/>
        /// </param>
        /// <param name="lpValueName">
        /// The name of the value to be set.
        /// If a value with this name is not already present in the key, the function adds it to the key.
        /// If <paramref name="lpValueName"/> is <see langword="null"/> or an empty string, "",
        /// the function sets the type and data for the key's unnamed or default value.
        /// For more information, see Registry Element Size Limits.
        /// Registry keys do not have default values, but they can have one unnamed value, which can be of any type.
        /// </param>
        /// <param name="Reserved">
        /// This parameter is reserved and must be zero.
        /// </param>
        /// <param name="dwType">
        /// The type of data pointed to by the <paramref name="lpData"/> parameter.
        /// For a list of the possible types, see Registry Value Types.
        /// </param>
        /// <param name="lpData">
        /// The data to be stored.
        /// For string-based types, such as <see cref="REG_SZ"/>, the string must be null-terminated.
        /// With the <see cref="REG_MULTI_SZ"/> data type, the string must be terminated with two null characters.
        /// Note <paramref name="lpData"/> indicating a null value is valid, however,
        /// if this is the case, <paramref name="cbData"/> must be set to '0'.
        /// </param>
        /// <param name="cbData">
        /// The size of the information pointed to by the <paramref name="lpData"/> parameter, in bytes.
        /// If the data is of type <see cref="REG_SZ"/>, <see cref="REG_EXPAND_SZ"/>, or <see cref="REG_MULTI_SZ"/>,
        /// <paramref name="cbData"/> must include the size of the terminating null character or characters.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag
        /// to get a generic description of the error.
        /// </returns>
        /// <remarks>
        /// Value sizes are limited by available memory. However, storing large values in the registry can affect its performance.
        /// Long values (more than 2,048 bytes) should be stored as files, with the locations of the files stored in the registry.
        /// Application elements such as icons, bitmaps, and executable files should be stored as files and not be placed in the registry.
        /// If <paramref name="dwType"/> is the <see cref="REG_SZ"/>, <see cref="REG_MULTI_SZ"/>, or <see cref="REG_EXPAND_SZ"/> type
        /// and the ANSI version of this function is used (either by explicitly calling RegSetValueExA or by not defining UNICODE
        /// before including the Windows.h file), the data pointed to by the <paramref name="lpData"/> parameter must be an ANSI character string.
        /// The string is converted to Unicode before it is stored in the registry.
        /// Note that operations that access certain registry keys are redirected.
        /// For more information, see Registry Virtualization and 32-bit and 64-bit Application Data in the Registry.
        /// Consider using the <see cref="RegSetKeyValue"/> function, which provides a more convenient way to set the value of a registry key.
        /// The winreg.h header defines <see cref="RegSetValueEx"/> as an alias which automatically selects
        /// the ANSI or Unicode version of this function based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead to mismatches
        /// that result in compilation or runtime errors.
        /// For more information, see Conventions for Function Prototypes.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegSetValueExW", ExactSpelling = true, SetLastError = true)]
        public static extern LSTATUS RegSetValueEx([In] HKEY hKey, [MarshalAs(UnmanagedType.LPWStr)][In] string lpValueName,
            [In] DWORD Reserved, [In] RegistryValueTypes dwType, [In] IntPtr lpData, [In] DWORD cbData);

        /// <summary>
        /// <para>
        /// Unloads the specified registry key and its subkeys from the registry.
        /// Applications that back up or restore system state including system files and registry hives
        /// should use the Volume Shadow Copy Service instead of the registry functions.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winreg/nf-winreg-regunloadkeyw
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// A handle to the registry key to be unloaded.
        /// This parameter can be a handle returned by a call to <see cref="RegConnectRegistry"/> function
        /// or one of the following predefined handles:
        /// <see cref="HKEY_LOCAL_MACHINE"/> <see cref="HKEY_USERS"/>
        /// </param>
        /// <param name="lpSubKey">
        /// The name of the subkey to be unloaded.
        /// The key referred to by the <paramref name="lpSubKey"/> parameter must have been created by using the <see cref="RegLoadKey"/> function.
        /// Key names are not case sensitive.
        /// For more information, see Registry Element Size Limits.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag
        /// to get a generic description of the error.
        /// </returns>
        /// <remarks>
        /// This function removes a hive from the registry but does not modify the file containing the registry information.
        /// A hive is a discrete body of keys, subkeys, and values that is rooted at the top of the registry hierarchy.
        /// The calling process must have the SE_RESTORE_NAME and SE_BACKUP_NAME privileges on the computer in which the registry resides.
        /// For more information, see Running with Special Privileges.
        /// The winreg.h header defines RegUnLoadKey as an alias which automatically selects the ANSI or Unicode version
        /// of this function based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead to mismatches
        /// that result in compilation or runtime errors. For more information, see Conventions for Function Prototypes.
        /// </remarks>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegUnLoadKeyW", ExactSpelling = true, SetLastError = true)]
        public static extern LSTATUS RegUnLoadKey([In] in HKEY hKey, [MarshalAs(UnmanagedType.LPWStr)][In] string lpSubKey);
    }
}
