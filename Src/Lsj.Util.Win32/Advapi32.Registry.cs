using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.ACCESS_MASK;
using static Lsj.Util.Win32.BaseTypes.HKEY;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.FormatMessageFlags;
using static Lsj.Util.Win32.Enums.LogonTypes;
using static Lsj.Util.Win32.Enums.RegistryKeyAccessRights;
using static Lsj.Util.Win32.Enums.RegistryKeyDispositions;
using static Lsj.Util.Win32.Enums.RegistryOptions;
using static Lsj.Util.Win32.Enums.RegistryRoutineFlags;
using static Lsj.Util.Win32.Enums.RegistryValueTypes;
using static Lsj.Util.Win32.Enums.RegRestoreKeyFlags;
using static Lsj.Util.Win32.Enums.RegSaveKeyExFlags;
using static Lsj.Util.Win32.Enums.StandardAccessRights;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.PrivilegeConstants;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Ktmw32;
using static Lsj.Util.Win32.Shlwapi;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using FILETIME = Lsj.Util.Win32.Structs.FILETIME;

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
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regclosekey"/>
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// A handle to the open key to be closed.
        /// The handle must have been opened by the <see cref="RegCreateKeyEx"/>, <see cref="RegCreateKeyTransacted"/>,
        /// <see cref="RegOpenKeyEx"/>, <see cref="RegOpenKeyTransacted"/>, or <see cref="RegConnectRegistry"/> function.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function
        /// with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag to get a generic description of the error.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The handle for a specified key should not be used after it has been closed, because it will no longer be valid.
        /// Key handles should not be left open any longer than necessary.
        /// </para>
        /// <para>
        /// The <see cref="RegCloseKey"/> function does not necessarily write information to the registry before returning;
        /// it can take as much as several seconds for the cache to be flushed to the hard disk.
        /// If an application must explicitly write registry information to the hard disk,
        /// it can use the <see cref="RegFlushKey"/> function.
        /// <see cref="RegFlushKey"/>, however, uses many system resources and should be called only when necessary.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegCloseKey", ExactSpelling = true)]
        public static extern LSTATUS RegCloseKey([In] HKEY hKey);

        /// <summary>
        /// <para>
        /// Establishes a connection to a predefined registry key on another computer.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regconnectregistryw"/>
        /// </para>
        /// </summary>
        /// <param name="lpMachineName">
        /// <para>
        /// The name of the remote computer. The string has the following form:
        /// </para>
        /// <para>
        /// \\computername
        /// </para>
        /// <para>
        /// The caller must have access to the remote computer or the function fails.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NULL"/>, the local computer name is used.
        /// </para>
        /// </param>
        /// <param name="hKey">
        /// <para>
        /// A predefined registry handle.
        /// This parameter can be one of the following predefined keys on the remote computer.
        /// </para>
        /// <para>
        /// <see cref="HKEY_LOCAL_MACHINE"/> <see cref="HKEY_PERFORMANCE_DATA"/> <see cref="HKEY_USERS"/>
        /// </para>
        /// </param>
        /// <param name="phkResult">
        /// A pointer to a variable that receives a key handle identifying the predefined handle on the remote computer.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function
        /// with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag to get a generic description of the error.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="RegConnectRegistry"/> requires the Remote Registry service to be running on the remote computer.
        /// By default, this service is configured to be started manually.
        /// To configure the Remote Registry service to start automatically,
        /// run Services.msc and change the Startup Type of the service to Automatic.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP/2000:
        /// The Remote Registry service is configured to start automatically by default.
        /// </para>
        /// <para>
        /// When a handle returned by <see cref="RegConnectRegistry"/> is no longer needed,
        /// it should be closed by calling <see cref="RegCloseKey"/>.
        /// </para>
        /// <para>
        /// If the computer is joined to a workgroup and the "Force network logons using local accounts to authenticate as Guest" policy is enabled,
        /// the function fails.
        /// Note that this policy is enabled by default if the computer is joined to a workgroup.
        /// </para>
        /// <para>
        /// If the current user does not have proper access to the remote computer, the call to <see cref="RegConnectRegistry"/> fails.
        /// To connect to a remote registry, call <see cref="LogonUser"/> with <see cref="LOGON32_LOGON_NEW_CREDENTIALS"/>
        /// and <see cref="ImpersonateLoggedOnUser"/> before calling <see cref="RegConnectRegistry"/>.
        /// </para>
        /// <para>
        /// Windows 2000:
        /// One possible workaround is to establish a session to an administrative share such as IPC$ using a different set of credentials.
        /// To specify credentials other than those of the current user, use the <see cref="WNetAddConnection2"/> function to connect to the share.
        /// When you have finished accessing the registry, cancel the connection.
        /// </para>
        /// <para>
        /// Windows XP Home Edition:
        /// You cannot use this function to connect to a remote computer running Windows XP Home Edition.
        /// This function does work with the name of the local computer even if it is running Windows XP Home Edition
        /// because this bypasses the authentication layer.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegConnectRegistryW", ExactSpelling = true)]
        public static extern LSTATUS RegConnectRegistry([In] LPCWSTR lpMachineName, [In] HKEY hKey, [Out] out HKEY phkResult);

        /// <summary>
        /// <para>
        /// Copies the specified registry key, along with its values and subkeys, to the specified destination key.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regcopytreew"/>
        /// </para>
        /// </summary>
        /// <param name="hKeySrc">
        /// <para>
        /// A handle to an open registry key.
        /// The key must have been opened with the <see cref="KEY_READ"/> access right.
        /// For more information, see Registry Key Security and Access Rights.
        /// </para>
        /// <para>
        /// This handle is returned by the <see cref="RegCreateKeyEx"/> or <see cref="RegOpenKeyEx"/> function,
        /// or it can be one of the predefined keys.
        /// </para>
        /// </param>
        /// <param name="lpSubKey">
        /// The name of the key.
        /// This key must be a subkey of the key identified by the <paramref name="hKeySrc"/> parameter.
        /// This parameter can also be <see cref="NULL"/>.
        /// </param>
        /// <param name="hKeyDest">
        /// <para>
        /// A handle to the destination key.
        /// The calling process must have <see cref="KEY_CREATE_SUB_KEY"/> access to the key.
        /// </para>
        /// <para>
        /// This handle is returned by the <see cref="RegCreateKeyEx"/> or <see cref="RegOpenKeyEx"/> function,
        /// or it can be one of the predefined keys.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function
        /// with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag to get a generic description of the error.
        /// </para>
        /// </returns>
        /// <remarks>
        /// This function also copies the security descriptor for the key.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegCopyTreeW", ExactSpelling = true)]
        public static extern LSTATUS RegCopyTree([In] HKEY hKeySrc, [In] LPCWSTR lpSubKey, [In] HKEY hKeyDest);

        /// <summary>
        /// <para>
        /// Creates the specified registry key.
        /// If the key already exists in the registry, the function opens it.
        /// </para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regcreatekeyw"/>
        /// <para>
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// <para>
        /// A handle to an open registry key.
        /// The calling process must have <see cref="KEY_CREATE_SUB_KEY"/> access to the key.
        /// For more information, see Registry Key Security and Access Rights.
        /// </para>
        /// <para>
        /// Access for key creation is checked against the security descriptor of the registry key,
        /// not the access mask specified when the handle was obtained.
        /// Therefore, even if <paramref name="hKey"/> was opened with a samDesired of <see cref="KEY_READ"/>,
        /// it can be used in operations that create keys if allowed by its security descriptor.
        /// </para>
        /// <para>
        /// This handle is returned by the <see cref="RegCreateKeyEx"/> or <see cref="RegOpenKeyEx"/> function,
        /// or it can be one of the following predefined keys:
        /// </para>
        /// <para>
        /// <see cref="HKEY_CLASSES_ROOT"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_CONFIG"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_USER"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_LOCAL_MACHINE"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_USERS"/>
        /// </para>
        /// </param>
        /// <param name="lpSubKey">
        /// <para>
        /// The name of a key that this function opens or creates.
        /// This key must be a subkey of the key identified by the <paramref name="hKey"/> parameter.
        /// </para>
        /// <para>
        /// For more information on key names, see Structure of the Registry.
        /// </para>
        /// <para>
        /// If <paramref name="hKey"/> is one of the predefined keys, <paramref name="lpSubKey"/> may be <see cref="NULL"/>.
        /// In that case, phkResult receives the same <paramref name="hKey"/> handle passed in to the function.
        /// </para>
        /// </param>
        /// <param name="phkResult">
        /// A pointer to a variable that receives a handle to the opened or created key.
        /// If the key is not one of the predefined registry keys,
        /// call the <see cref="RegCloseKey"/> function after you have finished using the handle.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function
        /// with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag to get a generic description of the error.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// An application cannot create a key that is a direct child of <see cref="HKEY_USERS"/> or <see cref="HKEY_LOCAL_MACHINE"/>.
        /// An application can create subkeys in lower levels of the <see cref="HKEY_USERS"/> or <see cref="HKEY_LOCAL_MACHINE"/> trees.
        /// </para>
        /// <para>
        /// If your service or application impersonates different users, do not use this function with <see cref="HKEY_CURRENT_USER"/>.
        /// Instead, call the <see cref="RegOpenCurrentUser"/> function.
        /// </para>
        /// <para>
        /// The <see cref="RegCreateKey"/> function creates all missing keys in the specified path.
        /// An application can take advantage of this behavior to create several keys at once.
        /// For example, an application can create a subkey four levels deep at the same time
        /// as the three preceding subkeys by specifying a string of the following form for the <paramref name="lpSubKey"/> parameter:
        /// </para>
        /// <para>
        /// subkey1\subkey2\subkey3\subkey4
        /// </para>
        /// <para>
        /// Note that this behavior will result in creation of unwanted keys if an existing key in the path is spelled incorrectly.
        /// </para>
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit versions of Windows." +
            "Applications should use the RegCreateKeyEx function." +
            "However, applications that back up or restore system state including system files" +
            "and registry hives should use the Volume Shadow Copy Service instead of the registry functions.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegCreateKeyW", ExactSpelling = true)]
        public static extern LSTATUS RegCreateKey([In] HKEY hKey, [In] LPCWSTR lpSubKey, [Out] out HKEY phkResult);

        /// <summary>
        /// <para>
        /// Creates the specified registry key.
        /// If the key already exists, the function opens it.
        /// Note that key names are not case sensitive.
        /// </para>
        /// <para>
        /// To perform transacted registry operations on a key, call the <see cref="RegCreateKeyTransacted"/> function.
        /// </para>
        /// <para>
        /// Applications that back up or restore system state including system files and registry hives
        /// should use the Volume Shadow Copy Service instead of the registry functions.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regcreatekeyexw"/>
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// <para>
        /// A handle to an open registry key.
        /// The calling process must have <see cref="KEY_CREATE_SUB_KEY"/> access to the key.
        /// For more information, see Registry Key Security and Access Rights.
        /// </para>
        /// <para>
        /// Access for key creation is checked against the security descriptor of the registry key,
        /// not the access mask specified when the handle was obtained. 
        /// Therefore, even if <paramref name="hKey"/> was opened with a <paramref name="samDesired"/> of <see cref="KEY_READ"/>,
        /// it can be used in operations that modify the registry if allowed by its security descriptor.
        /// </para>
        /// <para>
        /// This handle is returned by the <see cref="RegCreateKeyEx"/> or <see cref="RegOpenKeyEx"/> function,
        /// or it can be one of the following predefined keys:
        /// </para>
        /// <para>
        /// <see cref="HKEY_CLASSES_ROOT"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_CONFIG"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_USER"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_LOCAL_MACHINE"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_USERS"/>
        /// </para>
        /// </param>
        /// <param name="lpSubKey">
        /// <para>
        /// The name of a subkey that this function opens or creates.
        /// The subkey specified must be a subkey of the key identified by the <paramref name="hKey"/> parameter;
        /// it can be up to 32 levels deep in the registry tree.
        /// For more information on key names, see Structure of the Registry.
        /// </para>
        /// <para>
        /// If <paramref name="lpSubKey"/> is a pointer to an empty string,
        /// <paramref name="phkResult"/> receives a new handle to the key specified by <paramref name="hKey"/>.
        /// </para>
        /// <para>
        /// This parameter cannot be <see cref="NULL"/>.
        /// </para>
        /// </param>
        /// <param name="Reserved">
        /// This parameter is reserved and must be zero.
        /// </param>
        /// <param name="lpClass">
        /// The user-defined class type of this key.
        /// This parameter may be ignored.
        /// This parameter can be <see cref="NULL"/>.
        /// </param>
        /// <param name="dwOptions">
        /// <para>
        /// This parameter can be one of the following values.
        /// </para>
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
        /// <see cref="REG_OPTION_BACKUP_RESTORE"/>
        /// </para>
        /// <para>
        /// 0x00000004L
        /// </para>
        /// </term>
        /// <term>
        /// If this flag is set, the function ignores the <paramref name="samDesired"/> parameter
        /// and attempts to open the key with the access required to backup or restore the key.
        /// If the calling thread has the <see cref="SE_BACKUP_NAME"/> privilege enabled,
        /// the key is opened with the <see cref="ACCESS_SYSTEM_SECURITY"/> and <see cref="KEY_READ"/> access rights.
        /// If the calling thread has the <see cref="SE_RESTORE_NAME"/> privilege enabled, beginning with Windows Vista,
        /// the key is opened with the <see cref="ACCESS_SYSTEM_SECURITY"/>, <see cref="DELETE"/> and <see cref="KEY_WRITE"/> access rights.
        /// If both privileges are enabled, the key has the combined access rights for both privileges.
        /// For more information, see Running with Special Privileges.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="REG_OPTION_CREATE_LINK"/>
        /// </para>
        /// <para>
        /// 0x00000002L
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Registry symbolic links should only be used for application compatibility when absolutely necessary.
        /// </para>
        /// <para>
        /// This key is a symbolic link.
        /// The target path is assigned to the L"SymbolicLinkValue" value of the key.
        /// The target path must be an absolute registry path.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="REG_OPTION_NON_VOLATILE"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// This key is not volatile; this is the default.
        /// The information is stored in a file and is preserved when the system is restarted.
        /// The <see cref="RegSaveKey"/> function saves keys that are not volatile.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="REG_OPTION_VOLATILE"/>
        /// </para>
        /// <para>
        /// 0x00000001L
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// All keys created by the function are volatile.
        /// The information is stored in memory and is not preserved when the corresponding registry hive is unloaded.
        /// For <see cref="HKEY_LOCAL_MACHINE"/>, this occurs only when the system initiates a full shutdown.
        /// For registry keys loaded by the <see cref="RegLoadKey"/> function, 
        /// this occurs when the corresponding <see cref="RegUnLoadKey"/> is performed.
        /// The <see cref="RegSaveKey"/> function does not save volatile keys.
        /// This flag is ignored for keys that already exist.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// On a user selected shutdown, a fast startup shutdown is the default behavior for the system.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </param>
        /// <param name="samDesired">
        /// A mask that specifies the access rights for the key to be created.
        /// For more information, see Registry Key Security and Access Rights.
        /// </param>
        /// <param name="lpSecurityAttributes">
        /// <para>
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that determines whether the returned handle can be inherited by child processes.
        /// If <paramref name="lpSecurityAttributes"/> is <see cref="NullRef{T}"/>, the handle cannot be inherited.
        /// </para>
        /// <para>
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the new key.
        /// If <paramref name="lpSecurityAttributes"/> is <see cref="NullRef{T}"/>, the key gets a default security descriptor.
        /// The ACLs in a default security descriptor for a key are inherited from its direct parent key.
        /// </para>
        /// </param>
        /// <param name="phkResult">
        /// A pointer to a variable that receives a handle to the opened or created key.
        /// If the key is not one of the predefined registry keys,
        /// call the <see cref="RegCloseKey"/> function after you have finished using the handle.
        /// </param>
        /// <param name="lpdwDisposition">
        /// <para>
        /// A pointer to a variable that receives one of the following disposition values. 
        /// </para>
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
        /// <see cref="REG_CREATED_NEW_KEY"/>
        /// </para>
        /// <para>
        /// 0x00000001L
        /// </para>
        /// </term>
        /// <term>
        /// The key did not exist and was created.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="REG_OPENED_EXISTING_KEY"/>
        /// </para>
        /// <para>
        /// 0x00000002L
        /// </para>
        /// </term>
        /// <term>
        /// The key existed and was simply opened without being changed.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// If <paramref name="lpdwDisposition"/> is <see cref="NULL"/>, no disposition information is returned.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function
        /// with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag to get a generic description of the error.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The key that the <see cref="RegCreateKeyEx"/> function creates has no values.
        /// An application can use the <see cref="RegSetValueEx"/> function to set key values.
        /// </para>
        /// <para>
        /// The <see cref="RegCreateKeyEx"/> function creates all missing keys in the specified path.
        /// An application can take advantage of this behavior to create several keys at once.
        /// For example, an application can create a subkey four levels deep at the same time as the three preceding subkeys
        /// by specifying a string of the following form for the <paramref name="lpSubKey"/> parameter:
        /// </para>
        /// <para>
        /// subkey1\subkey2\subkey3\subkey4
        /// </para>
        /// <para>
        /// Note that this behavior will result in creation of unwanted keys if an existing key in the path is spelled incorrectly.
        /// </para>
        /// <para>
        /// An application cannot create a key that is a direct child of <see cref="HKEY_USERS"/> or <see cref="HKEY_LOCAL_MACHINE"/>.
        /// An application can create subkeys in lower levels of the <see cref="HKEY_USERS"/> or <see cref="HKEY_LOCAL_MACHINE"/> trees.
        /// </para>
        /// <para>
        /// If your service or application impersonates different users, do not use this function with <see cref="HKEY_CURRENT_USER"/>.
        /// Instead, call the <see cref="RegOpenCurrentUser"/> function.
        /// </para>
        /// <para>
        /// Note that operations that access certain registry keys are redirected.
        /// For more information, see Registry Virtualization and 32-bit and 64-bit Application Data in the Registry.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegCreateKeyExW", ExactSpelling = true)]
        public static extern LSTATUS RegCreateKeyEx([In] HKEY hKey, [In] LPCWSTR lpSubKey, [In] DWORD Reserved, [In] LPCWSTR lpClass,
            [In] RegistryOptions dwOptions, [In] REGSAM samDesired, [In] in SECURITY_ATTRIBUTES lpSecurityAttributes,
            [Out] out HKEY phkResult, [Out] out RegistryKeyDispositions lpdwDisposition);

        /// <summary>
        /// <para>
        /// Creates the specified registry key and associates it with a transaction.
        /// If the key already exists, the function opens it.
        /// Note that key names are not case sensitive.
        /// </para>
        /// <para>
        /// Applications that back up or restore system state including system files and registry hives
        /// should use the Volume Shadow Copy Service instead of the registry functions.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regcreatekeytransactedw"/>
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// <para>
        /// A handle to an open registry key.
        /// The calling process must have <see cref="KEY_CREATE_SUB_KEY"/> access to the key.
        /// For more information, see Registry Key Security and Access Rights.
        /// </para>
        /// <para>
        /// Access for key creation is checked against the security descriptor of the registry key,
        /// not the access mask specified when the handle was obtained.
        /// Therefore, even if <paramref name="hKey"/> was opened with a <paramref name="samDesired"/> of <see cref="KEY_READ"/>,
        /// it can be used in operations that create keys if allowed by its security descriptor.
        /// </para>
        /// <para>
        /// This handle is returned by the <see cref="RegCreateKeyTransacted"/> or <see cref="RegOpenKeyTransacted"/> function,
        /// or it can be one of the following predefined keys:
        /// </para>
        /// <para>
        /// <see cref="HKEY_CLASSES_ROOT"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_CONFIG"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_USER"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_LOCAL_MACHINE"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_USERS"/>
        /// </para>
        /// </param>
        /// <param name="lpSubKey">
        /// <para>
        /// The name of a subkey that this function opens or creates.
        /// The subkey specified must be a subkey of the key identified by the <paramref name="hKey"/> parameter;
        /// it can be up to 32 levels deep in the registry tree.
        /// For more information on key names, see Structure of the Registry.
        /// </para>
        /// <para>
        /// If <paramref name="lpSubKey"/> is a pointer to an empty string,
        /// <paramref name="phkResult"/> receives a new handle to the key specified by <paramref name="hKey"/>.
        /// </para>
        /// <para>
        /// This parameter cannot be <see cref="NULL"/>.
        /// </para>
        /// </param>
        /// <param name="Reserved">
        /// This parameter is reserved and must be zero.
        /// </param>
        /// <param name="lpClass">
        /// The user-defined class of this key.
        /// This parameter may be ignored.
        /// This parameter can be <see cref="NULL"/>.
        /// </param>
        /// <param name="dwOptions">
        /// <para>
        /// This parameter can be one of the following values.
        /// </para>
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
        /// <see cref="REG_OPTION_BACKUP_RESTORE"/>
        /// </para>
        /// <para>
        /// 0x00000004L
        /// </para>
        /// </term>
        /// <term>
        /// If this flag is set, the function ignores the <paramref name="samDesired"/> parameter
        /// and attempts to open the key with the access required to backup or restore the key.
        /// If the calling thread has the <see cref="SE_BACKUP_NAME"/> privilege enabled,
        /// the key is opened with the <see cref="ACCESS_SYSTEM_SECURITY"/> and <see cref="KEY_READ"/> access rights.
        /// If the calling thread has the <see cref="SE_RESTORE_NAME"/> privilege enabled,
        /// the key is opened with the <see cref="ACCESS_SYSTEM_SECURITY"/> and <see cref="KEY_WRITE"/> access rights.
        /// If both privileges are enabled, the key has the combined access rights for both privileges.
        /// For more information, see Running with Special Privileges.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="REG_OPTION_NON_VOLATILE"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// This key is not volatile; this is the default.
        /// The information is stored in a file and is preserved when the system is restarted.
        /// The <see cref="RegSaveKey"/> function saves keys that are not volatile.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="REG_OPTION_VOLATILE"/>
        /// </para>
        /// <para>
        /// 0x00000001L
        /// </para>
        /// </term>
        /// <term>
        /// All keys created by the function are volatile.
        /// The information is stored in memory and is not preserved when the corresponding registry hive is unloaded.
        /// For <see cref="HKEY_LOCAL_MACHINE"/>, this occurs when the system is shut down.
        /// For registry keys loaded by the <see cref="RegLoadKey"/> function,
        /// this occurs when the corresponding <see cref="RegUnLoadKey"/> is performed.
        /// The <see cref="RegSaveKey"/> function does not save volatile keys.
        /// This flag is ignored for keys that already exist.
        /// </term>
        /// </item>
        /// </list>
        /// </param>
        /// <param name="samDesired">
        /// A mask that specifies the access rights for the key to be created.
        /// For more information, see Registry Key Security and Access Rights.
        /// </param>
        /// <param name="lpSecurityAttributes">
        /// <para>
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that determines whether the returned handle can be inherited by child processes.
        /// If <paramref name="lpSecurityAttributes"/> is <see cref="NullRef{T}"/>, the handle cannot be inherited.
        /// </para>
        /// <para>
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the new key.
        /// If <paramref name="lpSecurityAttributes"/> is <see cref="NullRef{T}"/>, the key gets a default security descriptor.
        /// The ACLs in a default security descriptor for a key are inherited from its direct parent key.
        /// </para>
        /// </param>
        /// <param name="phkResult">
        /// A pointer to a variable that receives a handle to the opened or created key.
        /// If the key is not one of the predefined registry keys,
        /// call the <see cref="RegCloseKey"/> function after you have finished using the handle.
        /// </param>
        /// <param name="lpdwDisposition">
        /// <para>
        /// A pointer to a variable that receives one of the following disposition values. 
        /// </para>
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
        /// <see cref="REG_CREATED_NEW_KEY"/>
        /// </para>
        /// <para>
        /// 0x00000001L
        /// </para>
        /// </term>
        /// <term>
        /// The key did not exist and was created.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="REG_OPENED_EXISTING_KEY"/>
        /// </para>
        /// <para>
        /// 0x00000002L
        /// </para>
        /// </term>
        /// <term>
        /// The key existed and was simply opened without being changed.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// If <paramref name="lpdwDisposition"/> is <see cref="NULL"/>, no disposition information is returned.
        /// </para>
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
        /// You can use the <see cref="FormatMessage"/> function
        /// with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag to get a generic description of the error.
        /// </returns>
        /// <remarks>
        /// <para>
        /// When a key is created using this function, subsequent operations on the key are transacted.
        /// If a non-transacted operation is performed on the key before the transaction is committed,
        /// the transaction is rolled back.
        /// After a transaction is committed or rolled back, you must re-open the key
        /// using <see cref="RegCreateKeyTransacted"/> or <see cref="RegOpenKeyTransacted"/>
        /// with an active transaction handle to make additional operations transacted.
        /// For more information about transactions, see Kernel Transaction Manager.
        /// </para>
        /// <para>
        /// Note that subsequent operations on subkeys of this key are not automatically transacted.
        /// Therefore, <see cref="RegDeleteKeyEx"/> does not perform a transacted delete operation.
        /// Instead, use the <see cref="RegDeleteKeyTransacted"/> function to perform a transacted delete operation.
        /// </para>
        /// <para>
        /// The key that the <see cref="RegCreateKeyTransacted"/> function creates has no values.
        /// An application can use the <see cref="RegSetValueEx"/> function to set key values.
        /// </para>
        /// <para>
        /// The <see cref="RegCreateKeyTransacted"/> function creates all missing keys in the specified path.
        /// An application can take advantage of this behavior to create several keys at once.
        /// For example, an application can create a subkey four levels deep at the same time
        /// as the three preceding subkeys by specifying a string of the following form for the <paramref name="lpSubKey"/> parameter:
        /// </para>
        /// <para>
        /// subkey1\subkey2\subkey3\subkey4
        /// </para>
        /// <para>
        /// Note that this behavior will result in creation of unwanted keys if an existing key in the path is spelled incorrectly.
        /// </para>
        /// <para>
        /// An application cannot create a key that is a direct child of <see cref="HKEY_USERS"/> or <see cref="HKEY_LOCAL_MACHINE"/>. An application can create subkeys in lower levels of the <see cref="HKEY_USERS"/> or <see cref="HKEY_LOCAL_MACHINE"/> trees.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegCreateKeyTransactedW", ExactSpelling = true)]
        public static extern LSTATUS RegCreateKeyTransacted([In] HKEY hKey, [In] LPCWSTR lpSubKey, [In] DWORD Reserved, [In] LPCWSTR lpClass,
            [In] RegistryOptions dwOptions, [In] REGSAM samDesired, [In] in SECURITY_ATTRIBUTES lpSecurityAttributes, [Out] out HKEY phkResult,
            [Out] out RegistryKeyDispositions lpdwDisposition, [In] HANDLE hTransaction, PVOID pExtendedParemeter);

        /// <summary>
        /// <para>
        /// Deletes a subkey and its values. Note that key names are not case sensitive.
        /// </para>
        /// <para>
        /// 64-bit Windows:
        /// On WOW64, 32-bit applications view a registry tree that is separate from the registry tree that 64-bit applications view.
        /// To enable an application to delete an entry in the alternate registry view, use the <see cref="RegDeleteKeyEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regdeletekeyw"/>
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// <para>
        /// A handle to an open registry key.
        /// The access rights of this key do not affect the delete operation.
        /// For more information about access rights, see Registry Key Security and Access Rights.
        /// </para>
        /// <para>
        /// This handle is returned by the <see cref="RegCreateKeyEx"/> or <see cref="RegOpenKeyEx"/> function,
        /// or it can be one of the following Predefined Keys:
        /// </para>
        /// <para>
        /// <see cref="HKEY_CLASSES_ROOT"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_CONFIG"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_USER"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_LOCAL_MACHINE"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_USERS"/>
        /// </para>
        /// </param>
        /// <param name="lpSubKey">
        /// <para>
        /// The name of the key to be deleted.
        /// It must be a subkey of the key that <paramref name="hKey"/> identifies, but it cannot have subkeys.
        /// This parameter cannot be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// The function opens the subkey with the <see cref="DELETE"/> access right.
        /// </para>
        /// <para>
        /// Key names are not case sensitive.
        /// </para>
        /// <para>
        /// For more information, see Registry Element Size Limits.
        /// </para>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// To get a generic description of the error, you can use the <see cref="FormatMessage"/> function
        /// with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag.
        /// </returns>
        /// <remarks>
        /// <para>
        /// A deleted key is not removed until the last handle to it is closed.
        /// </para>
        /// <para>
        /// The subkey to be deleted must not have subkeys.
        /// To delete a key and all its subkeys, you need to enumerate the subkeys and delete them individually.
        /// To delete keys recursively, use the <see cref="RegDeleteTree"/> or <see cref="SHDeleteKey"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegDeleteKeyW", ExactSpelling = true)]
        public static extern LSTATUS RegDeleteKey([In] HKEY hKey, [In] LPCWSTR lpSubKey);

        /// <summary>
        /// <para>
        /// Deletes a subkey and its values from the specified platform-specific view of the registry.
        /// Note that key names are not case sensitive.
        /// </para>
        /// <para>
        /// To delete a subkey as a transacted operation, call the <see cref="RegDeleteKeyTransacted"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regdeletekeyexw"/>
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// <para>
        /// A handle to an open registry key.
        /// The access rights of this key do not affect the delete operation.
        /// For more information about access rights, see Registry Key Security and Access Rights.
        /// </para>
        /// <para>
        /// This handle is returned by the <see cref="RegCreateKeyEx"/> or <see cref="RegOpenKeyEx"/> function,
        /// or it can be one of the following predefined keys:
        /// </para>
        /// <para>
        /// <see cref="HKEY_CLASSES_ROOT"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_CONFIG"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_USER"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_LOCAL_MACHINE"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_USERS"/>
        /// </para>
        /// </param>
        /// <param name="lpSubKey">
        /// <para>
        /// The name of the key to be deleted.
        /// This key must be a subkey of the key specified by the value of the <paramref name="hKey"/> parameter.
        /// </para>
        /// <para>
        /// The function opens the subkey with the <see cref="DELETE"/> access right.
        /// </para>
        /// <para>
        /// Key names are not case sensitive.
        /// </para>
        /// <para>
        /// The value of this parameter cannot be <see cref="NULL"/>.
        /// </para>
        /// </param>
        /// <param name="samDesired">
        /// <para>
        /// An access mask the specifies the platform-specific view of the registry.
        /// </para>
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
        /// <see cref="KEY_WOW64_32KEY"/>
        /// </para>
        /// <para>
        /// 0x0200
        /// </para>
        /// </term>
        /// <term>
        /// Delete the key from the 32-bit registry view.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="KEY_WOW64_64KEY"/>
        /// </para>
        /// <para>
        /// 0x0100
        /// </para>
        /// </term>
        /// <term>
        /// Delete the key from the 64-bit registry view.
        /// </term>
        /// </item>
        /// </list>
        /// </param>
        /// <param name="Reserved">
        /// This parameter is reserved and must be zero.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function
        /// with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag to get a generic description of the error.
        /// </returns>
        /// <remarks>
        /// <para>
        /// A deleted key is not removed until the last handle to it is closed.
        /// </para>
        /// <para>
        /// On WOW64, 32-bit applications view a registry tree that is separate from the registry tree that 64-bit applications view.
        /// This function enables an application to delete an entry in the alternate registry view.
        /// </para>
        /// <para>
        /// The subkey to be deleted must not have subkeys.
        /// To delete a key and all its subkeys, you need to enumerate the subkeys and delete them individually.
        /// To delete keys recursively, use the <see cref="RegDeleteTree"/> or <see cref="SHDeleteKey"/> function.
        /// </para>
        /// <para>
        /// If the function succeeds, <see cref="RegDeleteKeyEx"/> removes the specified key from the registry.
        /// The entire key, including all of its values, is removed.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// On legacy versions of Windows, this API is also exposed by kernel32.dll.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista, Note = "Windows Vista, Windows XP Professional x64 Edition")]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegDeleteKeyExW", ExactSpelling = true)]
        public static extern LSTATUS RegDeleteKeyEx([In] HKEY hKey, [In] LPCWSTR lpSubKey, [In] REGSAM samDesired, [In] DWORD Reserved);

        /// <summary>
        /// <para>
        /// Deletes a subkey and its values from the specified platform-specific view of the registry as a transacted operation.
        /// Note that key names are not case sensitive.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regdeletekeytransactedw"/>
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// <para>
        /// A handle to an open registry key.
        /// The access rights of this key do not affect the delete operation.
        /// For more information about access rights, see Registry Key Security and Access Rights.
        /// </para>
        /// <para>
        /// This handle is returned by the <see cref="RegCreateKeyEx"/>, <see cref="RegCreateKeyTransacted"/>,
        /// <see cref="RegOpenKeyEx"/>, or <see cref="RegOpenKeyTransacted"/> function.
        /// It can also be one of the following predefined keys:
        /// </para>
        /// <para>
        /// <see cref="HKEY_CLASSES_ROOT"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_CONFIG"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_USER"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_LOCAL_MACHINE"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_USERS"/>
        /// </para>
        /// </param>
        /// <param name="lpSubKey">
        /// <para>
        /// The name of the key to be deleted.
        /// This key must be a subkey of the key specified by the value of the <paramref name="hKey"/> parameter.
        /// </para>
        /// <para>
        /// The function opens the subkey with the <see cref="DELETE"/> access right.
        /// </para>
        /// <para>
        /// Key names are not case sensitive.
        /// </para>
        /// <para>
        /// The value of this parameter cannot be <see cref="NULL"/>.
        /// </para>
        /// </param>
        /// <param name="samDesired">
        /// <para>
        /// An access mask the specifies the platform-specific view of the registry.
        /// </para>
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
        /// <see cref="KEY_WOW64_32KEY"/>
        /// </para>
        /// <para>
        /// 0x0200
        /// </para>
        /// </term>
        /// <term>
        /// Delete the key from the 32-bit registry view.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="KEY_WOW64_64KEY"/>
        /// </para>
        /// <para>
        /// 0x0100
        /// </para>
        /// </term>
        /// <term>
        /// Delete the key from the 64-bit registry view.
        /// </term>
        /// </item>
        /// </list>
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
        /// You can use the <see cref="FormatMessage"/> function
        /// with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag to get a generic description of the error.
        /// </returns>
        /// <remarks>
        /// <para>
        /// A deleted key is not removed until the last handle to it is closed.
        /// </para>
        /// <para>
        /// On WOW64, 32-bit applications view a registry tree that is separate from the registry tree that 64-bit applications view.
        /// This function enables an application to delete an entry in the alternate registry view.
        /// </para>
        /// <para>
        /// The subkey to be deleted must not have subkeys.
        /// To delete a key and all its subkeys, you need to enumerate the subkeys and delete them individually.
        /// To delete keys recursively, use the <see cref="RegDeleteTree"/> or <see cref="SHDeleteKey"/> function.
        /// </para>
        /// <para>
        /// If the function succeeds, <see cref="RegDeleteKeyTransacted"/> removes the specified key from the registry.
        /// The entire key, including all of its values, is removed.
        /// To remove the entire tree as a transacted operation, use the <see cref="RegDeleteTree"/> function
        /// with a handle returned from <see cref="RegCreateKeyTransacted"/> or <see cref="RegOpenKeyTransacted"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegDeleteKeyTransactedW", ExactSpelling = true)]
        public static extern LSTATUS RegDeleteKeyTransacted([In] HKEY hKey, [In] LPCWSTR lpSubKey, [In] REGSAM samDesired,
            [In] DWORD Reserved, [In] HANDLE hTransaction, [In] PVOID pExtendedParameter);

        /// <summary>
        /// <para>
        /// Deletes the subkeys and values of the specified key recursively.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regdeletetreew"/>
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// <para>
        /// A handle to an open registry key.
        /// The key must have been opened with the following access rights:
        /// <see cref="DELETE"/>, <see cref="KEY_ENUMERATE_SUB_KEYS"/>, and <see cref="KEY_QUERY_VALUE"/>.
        /// For more information, see Registry Key Security and Access Rights.
        /// </para>
        /// <para>
        /// This handle is returned by the <see cref="RegCreateKeyEx"/>, <see cref="RegCreateKeyTransacted"/>,
        /// <see cref="RegOpenKeyEx"/>, or <see cref="RegOpenKeyTransacted"/> function,
        /// or it can be one of the following Predefined Keys:
        /// </para>
        /// <para>
        /// <see cref="HKEY_CLASSES_ROOT"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_CONFIG"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_USER"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_LOCAL_MACHINE"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_USERS"/>
        /// </para>
        /// </param>
        /// <param name="lpSubKey">
        /// The name of the key.
        /// This key must be a subkey of the key identified by the <paramref name="hKey"/> parameter.
        /// If this parameter is <see cref="NULL"/>, the subkeys and values of <paramref name="hKey"/> are deleted.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function
        /// with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag to get a generic description of the error.
        /// </returns>
        /// <remarks>
        /// If the key has values, it must be opened with <see cref="KEY_SET_VALUE"/>
        /// or this function will fail with <see cref="ERROR_ACCESS_DENIED"/>.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegDeleteTreeW", ExactSpelling = true)]
        public static extern LSTATUS RegDeleteTree([In] HKEY hKey, [In] LPCWSTR lpSubKey);

        /// <summary>
        /// <para>
        /// Removes a named value from the specified registry key.
        /// Note that value names are not case sensitive.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regdeletevaluew"/>
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// <para>
        /// A handle to an open registry key.
        /// The key must have been opened with the <see cref="KEY_SET_VALUE"/> access right.
        /// For more information, see Registry Key Security and Access Rights.
        /// </para>
        /// <para>
        /// This handle is returned by the <see cref="RegCreateKeyEx"/>, <see cref="RegCreateKeyTransacted"/>,
        /// <see cref="RegOpenKeyEx"/>, or <see cref="RegOpenKeyTransacted"/> function.
        /// It can also be one of the following predefined keys:
        /// </para>
        /// <para>
        /// <see cref="HKEY_CLASSES_ROOT"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_CONFIG"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_USER"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_LOCAL_MACHINE"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_USERS"/>
        /// </para>
        /// </param>
        /// <param name="lpValueName">
        /// <para>
        /// The registry value to be removed.
        /// If this parameter is <see cref="NULL"/> or an empty string,
        /// the value set by the <see cref="RegSetValue"/> function is removed.
        /// </para>
        /// <para>
        /// For more information, see Registry Element Size Limits.
        /// </para>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function
        /// with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag to get a generic description of the error.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegDeleteValueW", ExactSpelling = true)]
        public static extern LSTATUS RegDeleteValue([In] HKEY hKey, [In] LPCWSTR lpValueName);

        /// <summary>
        /// <para>
        /// Enumerates the subkeys of the specified open registry key.
        /// The function retrieves the name of one subkey each time it is called.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regenumkeyw"/>
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// <para>
        /// A handle to an open registry key.
        /// The key must have been opened with the <see cref="KEY_ENUMERATE_SUB_KEYS"/> access right.
        /// For more information, see Registry Key Security and Access Rights.
        /// </para>
        /// <para>
        /// This handle is returned by the <see cref="RegCreateKeyEx"/>, <see cref="RegCreateKeyTransacted"/>,
        /// <see cref="RegOpenKeyEx"/>, or <see cref="RegOpenKeyTransacted"/> function.
        /// It can also be one of the following predefined keys:
        /// </para>
        /// <para>
        /// <see cref="HKEY_CLASSES_ROOT"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_CONFIG"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_USER"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_LOCAL_MACHINE"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_USERS"/>
        /// </para>
        /// </param>
        /// <param name="dwIndex">
        /// <para>
        /// The index of the subkey of <paramref name="hKey"/> to be retrieved.
        /// This value should be zero for the first call to the <see cref="RegEnumKey"/> function and then incremented for subsequent calls.
        /// </para>
        /// <para>
        /// Because subkeys are not ordered, any new subkey will have an arbitrary index.
        /// This means that the function may return subkeys in any order.
        /// </para>
        /// </param>
        /// <param name="lpName">
        /// <para>
        /// A pointer to a buffer that receives the name of the subkey, including the terminating null character.
        /// This function copies only the name of the subkey, not the full key hierarchy, to the buffer.
        /// </para>
        /// <para>
        /// For more information, see Registry Element Size Limits.
        /// </para>
        /// </param>
        /// <param name="cchName">
        /// The size of the buffer pointed to by the <paramref name="lpName"/> parameter, in TCHARs.
        /// To determine the required buffer size, use the <see cref="RegQueryInfoKey"/> function
        /// to determine the size of the largest subkey for the key identified by the <paramref name="hKey"/> parameter.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is a system error code.
        /// If there are no more subkeys available, the function returns <see cref="ERROR_NO_MORE_ITEMS"/>.
        /// </para>
        /// <para>
        /// If the <paramref name="lpName"/> buffer is too small to receive the name of the key,
        /// the function returns <see cref="ERROR_MORE_DATA"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To enumerate subkeys, an application should initially call the <see cref="RegEnumKey"/> function
        /// with the <paramref name="dwIndex"/> parameter set to zero.
        /// The application should then increment the <paramref name="dwIndex"/> parameter
        /// and call the <see cref="RegEnumKey"/> function until there are no more subkeys
        /// (meaning the function returns <see cref="ERROR_NO_MORE_ITEMS"/>).
        /// </para>
        /// <para>
        /// The application can also set <paramref name="dwIndex"/> to the index of the last key
        /// on the first call to the function and decrement the index until the subkey with index 0 is enumerated.
        /// To retrieve the index of the last subkey, use the <see cref="RegQueryInfoKey"/>.
        /// </para>
        /// <para>
        /// While an application is using the <see cref="RegEnumKey"/> function,
        /// it should not make calls to any registration functions that might change the key being queried.
        /// </para>
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit versions of Windows." +
            "Applications should use the RegEnumKeyEx function.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegEnumKeyW", ExactSpelling = true)]
        public static extern LSTATUS RegEnumKey([In] HKEY hKey, [In] DWORD dwIndex, [In] IntPtr lpName, [In] DWORD cchName);

        /// <summary>
        /// <para>
        /// Enumerates the subkeys of the specified open registry key.
        /// The function retrieves information about one subkey each time it is called.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regenumkeyexw"/>
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// <para>
        /// A handle to an open registry key.
        /// The key must have been opened with the <see cref="KEY_ENUMERATE_SUB_KEYS"/> access right.
        /// For more information, see Registry Key Security and Access Rights.
        /// </para>
        /// <para>
        /// This handle is returned by the <see cref="RegCreateKeyEx"/>, <see cref="RegCreateKeyTransacted"/>,
        /// <see cref="RegOpenKeyEx"/>, or <see cref="RegOpenKeyTransacted"/> function.
        /// It can also be one of the following predefined keys:
        /// </para>
        /// <para>
        /// <see cref="HKEY_CLASSES_ROOT"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_CONFIG"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_USER"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_LOCAL_MACHINE"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_PERFORMANCE_DATA"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_USERS"/>
        /// </para>
        /// </param>
        /// <param name="dwIndex">
        /// <para>
        /// The index of the subkey to retrieve.
        /// This parameter should be zero for the first call to the <see cref="RegEnumKeyEx"/> function
        /// and then incremented for subsequent calls.
        /// </para>
        /// <para>
        /// Because subkeys are not ordered, any new subkey will have an arbitrary index.
        /// This means that the function may return subkeys in any order.
        /// </para>
        /// </param>
        /// <param name="lpName">
        /// <para>
        /// A pointer to a buffer that receives the name of the subkey, including the terminating null character.
        /// The function copies only the name of the subkey, not the full key hierarchy, to the buffer.
        /// </para>
        /// <para>
        /// If the function fails, no information is copied to this buffer.
        /// </para>
        /// <para>
        /// For more information, see Registry Element Size Limits.
        /// </para>
        /// </param>
        /// <param name="lpcchName">
        /// <para>
        /// A pointer to a variable that specifies the size of the buffer 
        /// specified by the <paramref name="lpName"/> parameter, in characters.
        /// This size should include the terminating null character.
        /// If the function succeeds, the variable pointed to by <paramref name="lpcchName"/>
        /// contains the number of characters stored in the buffer, not including the terminating null character.
        /// </para>
        /// <para>
        /// To determine the required buffer size, use the <see cref="RegQueryInfoKey"/> function
        /// to determine the size of the largest subkey for the key identified by the <paramref name="hKey"/> parameter.
        /// </para>
        /// </param>
        /// <param name="lpReserved">
        /// This parameter is reserved and must be <see cref="NULL"/>.
        /// </param>
        /// <param name="lpClass">
        /// A pointer to a buffer that receives the user-defined class of the enumerated subkey.
        /// This parameter can be <see cref="NULL"/>.
        /// </param>
        /// <param name="lpcchClass">
        /// A pointer to a variable that specifies the size of the buffer specified by the <paramref name="lpClass"/> parameter, in characters.
        /// The size should include the terminating null character.
        /// If the function succeeds, lpcClass contains the number of characters stored in the buffer, not including the terminating null character.
        /// This parameter can be <see cref="NullRef{DWORD}"/> only if <paramref name="lpClass"/> is <see cref="NULL"/>.
        /// </param>
        /// <param name="lpftLastWriteTime">
        /// A pointer to <see cref="FILETIME"/> structure that receives the time at which the enumerated subkey was last written.
        /// This parameter can be <see cref="NullRef{FILETIME}"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is a system error code.
        /// If there are no more subkeys available, the function returns <see cref="ERROR_NO_MORE_ITEMS"/>.
        /// </para>
        /// <para>
        /// If the <paramref name="lpcchName"/> buffer is too small to receive the name of the key,
        /// the function returns <see cref="ERROR_MORE_DATA"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To enumerate subkeys, an application should initially call the <see cref="RegEnumKeyEx"/> function
        /// with the <paramref name="dwIndex"/> parameter set to zero.
        /// The application should then increment the <paramref name="dwIndex"/> parameter
        /// and call <see cref="RegEnumKeyEx"/> until there are no more subkeys
        /// (meaning the function returns <see cref="ERROR_NO_MORE_ITEMS"/>).
        /// </para>
        /// <para>
        /// The application can also set <paramref name="dwIndex"/> to the index of the last subkey
        /// on the first call to the function and decrement the index until the subkey with the index 0 is enumerated.
        /// To retrieve the index of the last subkey, use the <see cref="RegQueryInfoKey"/> function.
        /// </para>
        /// <para>
        /// While an application is using the <see cref="RegEnumKeyEx"/> function,
        /// it should not make calls to any registration functions that might change the key being enumerated.
        /// </para>
        /// <para>
        /// Note that operations that access certain registry keys are redirected.
        /// For more information, see Registry Virtualization and 32-bit and 64-bit Application Data in the Registry.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegEnumKeyExW", ExactSpelling = true)]
        public static extern LSTATUS RegEnumKeyEx([In] HKEY hKey, [In] DWORD dwIndex, [In] LPWSTR lpName, [In][Out] ref DWORD lpcchName,
            [In] IntPtr lpReserved, [In] LPWSTR lpClass, [In][Out] ref DWORD lpcchClass, [Out] out FILETIME lpftLastWriteTime);

        /// <summary>
        /// <para>
        /// Enumerates the values for the specified open registry key.
        /// The function copies one indexed value name and data block for the key each time it is called.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regenumvaluew"/>
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// <para>
        /// A handle to an open registry key.
        /// The key must have been opened with the <see cref="KEY_QUERY_VALUE"/> access right.
        /// For more information, see Registry Key Security and Access Rights.
        /// </para>
        /// <para>
        /// This handle is returned by the <see cref="RegCreateKeyEx"/>, <see cref="RegCreateKeyTransacted"/>,
        /// <see cref="RegOpenKeyEx"/>, or <see cref="RegOpenKeyTransacted"/> function.
        /// It can also be one of the following predefined keys:
        /// </para>
        /// <para>
        /// <see cref="HKEY_CLASSES_ROOT"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_CONFIG"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_USER"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_LOCAL_MACHINE"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_PERFORMANCE_DATA"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_USERS"/>
        /// </para>
        /// </param>
        /// <param name="dwIndex">
        /// <para>
        /// The index of the value to be retrieved.
        /// This parameter should be zero for the first call to the <see cref="RegEnumValue"/> function
        /// and then be incremented for subsequent calls.
        /// </para>
        /// <para>
        /// Because values are not ordered, any new value will have an arbitrary index.
        /// This means that the function may return values in any order.
        /// </para>
        /// </param>
        /// <param name="lpValueName">
        /// <para>
        /// A pointer to a buffer that receives the name of the value as a null-terminated string.
        /// </para>
        /// <para>
        /// This buffer must be large enough to include the terminating null character.
        /// </para>
        /// <para>
        /// For more information, see Registry Element Size Limits.
        /// </para>
        /// </param>
        /// <param name="lpcchValueName">
        /// <para>
        /// A pointer to a variable that specifies the size of the buffer
        /// pointed to by the <paramref name="lpValueName"/> parameter, in characters.
        /// When the function returns, the variable receives the number of characters stored in the buffer,
        /// not including the terminating null character.
        /// </para>
        /// <para>
        /// Registry value names are limited to 32,767 bytes.
        /// The ANSI version of this function treats this parameter as a <see cref="SHORT"/> value.
        /// Therefore, if you specify a value greater than 32,767 bytes,
        /// there is an overflow and the function may return <see cref="ERROR_MORE_DATA"/>.
        /// </para>
        /// </param>
        /// <param name="lpReserved">
        /// This parameter is reserved and must be <see cref="NULL"/>.
        /// </param>
        /// <param name="lpType">
        /// A pointer to a variable that receives a code indicating the type of data stored in the specified value.
        /// For a list of the possible type codes, see Registry Value Types.
        /// The <paramref name="lpType"/> parameter can be <see cref="NullRef{RegristryValueType}"/> if the type code is not required.
        /// </param>
        /// <param name="lpData">
        /// <para>
        /// A pointer to a buffer that receives the data for the value entry.
        /// This parameter can be <see cref="NULL"/> if the data is not required.
        /// </para>
        /// <para>
        /// If <paramref name="lpData"/> is <see cref="NULL"/> and <paramref name="lpcbData"/> is non-<see cref="NULL"/>,
        /// the function stores the size of the data, in bytes, in the variable pointed to by <paramref name="lpcbData"/>.
        /// This enables an application to determine the best way to allocate a buffer for the data.
        /// </para>
        /// </param>
        /// <param name="lpcbData">
        /// <para>
        /// A pointer to a variable that specifies the size of the buffer
        /// pointed to by the <paramref name="lpData"/> parameter, in bytes.
        /// When the function returns, the variable receives the number of bytes stored in the buffer.
        /// </para>
        /// <para>
        /// This parameter can be <see cref="NULL"/> only if <paramref name="lpData"/> is <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// If the data has the <see cref="REG_SZ"/>, <see cref="REG_MULTI_SZ"/> or <see cref="REG_EXPAND_SZ"/> type,
        /// this size includes any terminating null character or characters.
        /// For more information, see Remarks.
        /// </para>
        /// <para>
        /// If the buffer specified by <paramref name="lpData"/> is not large enough to hold the data,
        /// the function returns <see cref="ERROR_MORE_DATA"/>
        /// and stores the required buffer size in the variable pointed to by <paramref name="lpcbData"/>.
        /// In this case, the contents of <paramref name="lpData"/> are undefined.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is a system error code.
        /// If there are no more values available, the function returns <see cref="ERROR_NO_MORE_ITEMS"/>.
        /// </para>
        /// <para>
        /// If the <paramref name="lpData"/> buffer is too small to receive the value,
        /// the function returns <see cref="ERROR_MORE_DATA"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To enumerate values, an application should initially call the <see cref="RegEnumValue"/> function
        /// with the <paramref name="dwIndex"/> parameter set to zero.
        /// The application should then increment <paramref name="dwIndex"/>
        /// and call the <see cref="RegEnumValue"/> function until there are no more values
        /// (until the function returns <see cref="ERROR_NO_MORE_ITEMS"/>).
        /// </para>
        /// <para>
        /// The application can also set <paramref name="dwIndex"/> to the index of the last value
        /// on the first call to the function and decrement the index until the value with index 0 is enumerated.
        /// To retrieve the index of the last value, use the <see cref="RegQueryInfoKey"/> function.
        /// </para>
        /// <para>
        /// While using <see cref="RegEnumValue"/>, an application should not call any registry functions that might change the key being queried.
        /// </para>
        /// <para>
        /// If the data has the <see cref="REG_SZ"/>, <see cref="REG_MULTI_SZ"/> or <see cref="REG_EXPAND_SZ"/> type,
        /// the string may not have been stored with the proper null-terminating characters.
        /// Therefore, even if the function returns <see cref="ERROR_SUCCESS"/>,
        /// the application should ensure that the string is properly terminated before using it;
        /// otherwise, it may overwrite a buffer.
        /// (Note that <see cref="REG_MULTI_SZ"/> strings should have two null-terminating characters.)
        /// </para>
        /// <para>
        /// To determine the maximum size of the name and data buffers, use the <see cref="RegQueryInfoKey"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegEnumValueW", ExactSpelling = true)]
        public static extern LSTATUS RegEnumValue([In] HKEY hKey, [In] DWORD dwIndex, [In] LPWSTR lpValueName, [In][Out] ref DWORD lpcchValueName,
            [In] IntPtr lpReserved, [Out] out RegistryValueTypes lpType, [In] IntPtr lpData, [In][Out] ref DWORD lpcbData);

        /// <summary>
        /// <para>
        /// Writes all the attributes of the specified open registry key into the registry.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regflushkey"/>
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// <para>
        /// A handle to an open registry key.
        /// The key must have been opened with the <see cref="KEY_QUERY_VALUE"/> access right.
        /// For more information, see Registry Key Security and Access Rights.
        /// </para>
        /// <para>
        /// This handle is returned by the <see cref="RegCreateKeyEx"/>, <see cref="RegCreateKeyTransacted"/>,
        /// <see cref="RegOpenKeyEx"/>, or <see cref="RegOpenKeyTransacted"/> function.
        /// It can also be one of the following predefined keys:
        /// </para>
        /// <para>
        /// <see cref="HKEY_CLASSES_ROOT"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_CONFIG"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_USER"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_LOCAL_MACHINE"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_PERFORMANCE_DATA"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_USERS"/>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function
        /// with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag to get a generic description of the error.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Calling <see cref="RegFlushKey"/> is an expensive operation that significantly affects system-wide performance
        /// as it consumes disk bandwidth and blocks modifications to all keys by all processes in the registry hive
        /// that is being flushed until the flush operation completes.
        /// <see cref="RegFlushKey"/> should only be called explicitly
        /// when an application must guarantee that registry changes are persisted to disk immediately after modification.
        /// All modifications made to keys are visible to other processes without the need to flush them to disk.
        /// </para>
        /// <para>
        /// Alternatively, the registry has a 'lazy flush' mechanism that flushes registry modifications to disk at regular intervals of time.
        /// In addition to this regular flush operation, registry changes are also flushed to disk at system shutdown.
        /// Allowing the 'lazy flush' to flush registry changes is the most efficient way to manage registry writes to the registry store on disk.
        /// </para>
        /// <para>
        /// The <see cref="RegFlushKey"/> function returns only when all the data for the hive
        /// that contains the specified key has been written to the registry store on disk.
        /// </para>
        /// <para>
        /// The <see cref="RegFlushKey"/> function writes out the data for other keys in the hive
        /// that have been modified since the last lazy flush or system start.
        /// </para>
        /// <para>
        /// After <see cref="RegFlushKey"/> returns, use <see cref="RegCloseKey"/> to close the handle to the registry key.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegFlushKey", ExactSpelling = true)]
        public static extern LSTATUS RegFlushKey([In] HKEY hKey);

        /// <summary>
        /// <para>
        /// The <see cref="RegGetKeySecurity"/> function retrieves a copy of the security descriptor protecting the specified open registry key.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-reggetkeysecurity"/>
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// A handle to an open key for which to retrieve the security descriptor.
        /// </param>
        /// <param name="SecurityInformation">
        /// A <see cref="SECURITY_INFORMATION"/> value that indicates the requested security information.
        /// </param>
        /// <param name="pSecurityDescriptor">
        /// A pointer to a buffer that receives a copy of the requested security descriptor.
        /// </param>
        /// <param name="lpcbSecurityDescriptor">
        /// A pointer to a variable that specifies the size, in bytes, of the buffer
        /// pointed to by the <paramref name="pSecurityDescriptor"/> parameter.
        /// When the function returns, the variable contains the number of bytes written to the buffer.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the function returns <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, it returns a nonzero error code defined in WinError.h.
        /// You can use the <see cref="FormatMessage"/> function
        /// with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag to get a generic description of the error.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the buffer specified by the <paramref name="pSecurityDescriptor"/> parameter is too small,
        /// the function returns <see cref="ERROR_INSUFFICIENT_BUFFER"/>
        /// and the <paramref name="lpcbSecurityDescriptor"/> parameter contains the number of bytes required for the requested security descriptor.
        /// </para>
        /// <para>
        /// To read the owner, group, or discretionary access control list (DACL) from the key's security descriptor,
        /// the calling process must have been granted <see cref="READ_CONTROL"/> access when the handle was opened.
        /// To get <see cref="READ_CONTROL"/> access, the caller must be the owner of the key or the key's DACL must grant the access.
        /// </para>
        /// <para>
        /// To read the system access control list (SACL) from the security descriptor,
        /// the calling process must have been granted <see cref="ACCESS_SYSTEM_SECURITY"/> access when the key was opened.
        /// The correct way to get this access is to enable the <see cref="SE_SECURITY_NAME"/> privilege in the caller's current token,
        /// open the handle for <see cref="ACCESS_SYSTEM_SECURITY"/> access, and then disable the privilege.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegGetKeySecurity", ExactSpelling = true)]
        public static extern LSTATUS RegGetKeySecurity([In] HKEY hKey, [In] SECURITY_INFORMATION SecurityInformation,
            [In] PSECURITY_DESCRIPTOR pSecurityDescriptor, [In][Out] ref DWORD lpcbSecurityDescriptor);

        /// <summary>
        /// <para>
        /// Retrieves the type and data for the specified registry value.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-reggetvaluew"/>
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// <para>
        /// A handle to an open registry key.
        /// The key must have been opened with the <see cref="KEY_QUERY_VALUE"/> access right.
        /// For more information, see Registry Key Security and Access Rights.
        /// </para>
        /// <para>
        /// This handle is returned by the <see cref="RegCreateKeyEx"/>, <see cref="RegCreateKeyTransacted"/>,
        /// <see cref="RegOpenKeyEx"/>, or <see cref="RegOpenKeyTransacted"/> function.
        /// It can also be one of the following predefined keys:
        /// </para>
        /// <para>
        /// <see cref="HKEY_CLASSES_ROOT"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_CONFIG"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_USER"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_LOCAL_MACHINE"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_PERFORMANCE_DATA"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_PERFORMANCE_NLSTEXT"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_PERFORMANCE_TEXT"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_USERS"/>
        /// </para>
        /// </param>
        /// <param name="lpSubKey">
        /// <para>
        /// The path of a registry key relative to the key specified by the <paramref name="hKey"/> parameter.
        /// The registry value will be retrieved from this subkey.
        /// </para>
        /// <para>
        /// The path is not case sensitive.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NULL"/> or an empty string, "",
        /// the value will be read from the key specified by <paramref name="hKey"/> itself.
        /// </para>
        /// </param>
        /// <param name="lpValue">
        /// <para>
        /// The name of the registry value.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NULL"/> or an empty string, "",
        /// the function retrieves the type and data for the key's unnamed or default value, if any.
        /// Keys do not automatically have an unnamed or default value, and unnamed values can be of any type.
        /// </para>
        /// <para>
        /// For more information, see Registry Element Size Limits.
        /// </para>
        /// </param>
        /// <param name="dwFlags">
        /// <para>
        /// The flags that restrict the data type of value to be queried.
        /// If the data type of the value does not meet this criteria, the function fails.
        /// This parameter can be one or more of the following values. 
        /// </para>
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
        /// <see cref="RRF_RT_ANY"/>
        /// </para>
        /// <para>
        /// 0x0000ffff
        /// </para>
        /// </term>
        /// <term>
        /// No type restriction.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RRF_RT_DWORD"/>
        /// </para>
        /// <para>
        /// 0x00000018
        /// </para>
        /// </term>
        /// <term>
        /// Restrict type to 32-bit <see cref="RRF_RT_REG_BINARY"/> | <see cref="RRF_RT_REG_DWORD"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RRF_RT_QWORD"/>
        /// </para>
        /// <para>
        /// 0x00000048
        /// </para>
        /// </term>
        /// <term>
        /// Restrict type to 64-bit <see cref="RRF_RT_REG_BINARY"/> | <see cref="RRF_RT_REG_QWORD"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RRF_RT_REG_BINARY"/>
        /// </para>
        /// <para>
        /// 0x00000008
        /// </para>
        /// </term>
        /// <term>
        /// Restrict type to <see cref="REG_BINARY"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RRF_RT_REG_DWORD"/>
        /// </para>
        /// <para>
        /// 0x00000010
        /// </para>
        /// </term>
        /// <term>
        /// Restrict type to <see cref="REG_DWORD"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RRF_RT_REG_EXPAND_SZ"/>
        /// </para>
        /// <para>
        /// 0x00000004
        /// </para>
        /// </term>
        /// <term>
        /// Restrict type to <see cref="REG_EXPAND_SZ"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RRF_RT_REG_MULTI_SZ"/>
        /// </para>
        /// <para>
        /// 0x00000020
        /// </para>
        /// </term>
        /// <term>
        /// Restrict type to <see cref="REG_MULTI_SZ"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RRF_RT_REG_NONE"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// Restrict type to <see cref="REG_NONE"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RRF_RT_REG_QWORD"/>
        /// </para>
        /// <para>
        /// 0x00000040
        /// </para>
        /// </term>
        /// <term>
        /// Restrict type to <see cref="REG_QWORD"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RRF_RT_REG_SZ"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// Restrict type to <see cref="REG_SZ"/>.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// This parameter can also include one or more of the following values.
        /// </para>
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
        /// <see cref="RRF_NOEXPAND"/>
        /// </para>
        /// <para>
        /// 0x10000000
        /// </para>
        /// </term>
        /// <term>
        /// Do not automatically expand environment strings if the value is of type <see cref="REG_EXPAND_SZ"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RRF_ZEROONFAILURE"/>
        /// </para>
        /// <para>
        /// 0x20000000
        /// </para>
        /// </term>
        /// <term>
        /// If pvData is not <see cref="NULL"/>, set the contents of the buffer to zeroes on failure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RRF_SUBKEY_WOW6464KEY"/>
        /// </para>
        /// <para>
        /// 0x00010000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// If <paramref name="lpSubKey"/> is not <see cref="NULL"/>,
        /// open the subkey that <paramref name="lpSubKey"/> specifies with the <see cref="KEY_WOW64_64KEY"/> access rights.
        /// For information about these access rights, see Registry Key Security and Access Rights.
        /// </para>
        /// <para>
        /// You cannot specify <see cref="RRF_SUBKEY_WOW6464KEY"/> in combination with <see cref="RRF_SUBKEY_WOW6432KEY"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RRF_SUBKEY_WOW6432KEY"/>
        /// </para>
        /// <para>
        /// 0x00020000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// If <paramref name="lpSubKey"/> is not <see cref="NULL"/>,
        /// open the subkey that <paramref name="lpSubKey"/> specifies with the <see cref="KEY_WOW64_32KEY"/> access rights.
        /// For information about these access rights, see Registry Key Security and Access Rights.
        /// </para>
        /// <para>
        /// You cannot specify <see cref="RRF_SUBKEY_WOW6432KEY"/> in combination with <see cref="RRF_SUBKEY_WOW6464KEY"/>.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </param>
        /// <param name="pdwType">
        /// A pointer to a variable that receives a code indicating the type of data stored in the specified value.
        /// For a list of the possible type codes, see Registry Value Types.
        /// This parameter can be <see cref="NullRef{RegistryValueTypes}"/> if the type is not required.
        /// </param>
        /// <param name="pvData">
        /// <para>
        /// A pointer to a buffer that receives the value's data.
        /// This parameter can be <see cref="NULL"/> if the data is not required.
        /// </para>
        /// <para>
        /// If the data is a string, the function checks for a terminating null character.
        /// If one is not found, the string is stored with a null terminator
        /// if the buffer is large enough to accommodate the extra character.
        /// Otherwise, the function fails and returns <see cref="ERROR_MORE_DATA"/>.
        /// </para>
        /// </param>
        /// <param name="pcbData">
        /// <para>
        /// A pointer to a variable that specifies the size of the buffer
        /// pointed to by the <paramref name="pvData"/> parameter, in bytes.
        /// When the function returns, this variable contains the size of the data copied to <paramref name="pvData"/>.
        /// </para>
        /// <para>
        /// The pcbData parameter can be <see cref="NULL"/> only if <paramref name="pvData"/> is <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// If the data has the <see cref="REG_SZ"/>, <see cref="REG_MULTI_SZ"/> or <see cref="REG_EXPAND_SZ"/> type,
        /// this size includes any terminating null character or characters.
        /// For more information, see Remarks.
        /// </para>
        /// <para>
        /// If the buffer specified by <paramref name="pvData"/> parameter is not large enough to hold the data,
        /// the function returns <see cref="ERROR_MORE_DATA"/>
        /// and stores the required buffer size in the variable pointed to by <paramref name="pcbData"/>.
        /// In this case, the contents of the <paramref name="pvData"/> buffer are zeroes
        /// if <paramref name="dwFlags"/> specifies <see cref="RRF_ZEROONFAILURE"/> and undefined otherwise.
        /// </para>
        /// <para>
        /// If <paramref name="pvData"/> is <see cref="NULL"/>, and <paramref name="pcbData"/> is non-<see cref="NULL"/>,
        /// the function returns <see cref="ERROR_SUCCESS"/>
        /// and stores the size of the data, in bytes, in the variable pointed to by <paramref name="pcbData"/>.
        /// This enables an application to determine the best way to allocate a buffer for the value's data.
        /// </para>
        /// <para>
        /// If <paramref name="hKey"/> specifies <see cref="HKEY_PERFORMANCE_DATA"/>
        /// and the <paramref name="pvData"/> buffer is not large enough to contain all of the returned data,
        /// the function returns <see cref="ERROR_MORE_DATA"/>
        /// and the value returned through the <paramref name="pcbData"/> parameter is undefined.
        /// This is because the size of the performance data can change from one call to the next.
        /// In this case, you must increase the buffer size
        /// and call <see cref="RegGetValue"/> again passing the updated buffer size in the <paramref name="pcbData"/> parameter.
        /// Repeat this until the function succeeds.
        /// You need to maintain a separate variable to keep track of the buffer size,
        /// because the value returned by <paramref name="pcbData"/> is unpredictable.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is a system error code.
        /// </para>
        /// <para>
        /// If the <paramref name="pvData"/> buffer is too small to receive the value,
        /// the function returns <see cref="ERROR_MORE_DATA"/>.
        /// </para>
        /// <para>
        /// If the <paramref name="lpValue"/> registry value does not exist,
        /// the function returns <see cref="ERROR_FILE_NOT_FOUND"/>.
        /// </para>
        /// <para>
        /// If <paramref name="dwFlags"/> specifies a combination
        /// of both <see cref="RRF_SUBKEY_WOW6464KEY"/> and <see cref="RRF_SUBKEY_WOW6432KEY"/>,
        /// the function returns <see cref="ERROR_INVALID_PARAMETER"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// An application typically calls <see cref="RegEnumValue"/> to determine the value names
        /// and then <see cref="RegGetValue"/> to retrieve the data for the names.
        /// </para>
        /// <para>
        /// If the data has the <see cref="REG_SZ"/>, <see cref="REG_MULTI_SZ"/> or <see cref="REG_EXPAND_SZ"/> type,
        /// and the ANSI version of this function is used (either by explicitly calling RegGetValueA
        /// or by not defining UNICODE before including the Windows.h file),
        /// this function converts the stored Unicode string to an ANSI string
        /// before copying it to the buffer pointed to by pvData.
        /// </para>
        /// <para>
        /// When calling this function with <paramref name="hKey"/> set to the <see cref="HKEY_PERFORMANCE_DATA"/> handle
        /// and a value string of a specified object, the returned data structure sometimes has unrequested objects.
        /// Do not be surprised; this is normal behavior.
        /// You should always expect to walk the returned data structure to look for the requested object.
        /// </para>
        /// <para>
        /// Note that operations that access certain registry keys are redirected.
        /// For more information, see Registry Virtualization and 32-bit and 64-bit Application Data in the Registry.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegGetValueW", ExactSpelling = true)]
        public static extern LSTATUS RegGetValue([In] HKEY hKey, [In] LPCWSTR lpSubKey, [In] LPCWSTR lpValue,
            [In] RegistryRoutineFlags dwFlags, [Out] out RegistryValueTypes pdwType, [In] PVOID pvData, [In][Out] ref DWORD pcbData);

        /// <summary>
        /// <para>
        /// Loads the specified registry hive as an application hive.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regloadappkeyw"/>
        /// </para>
        /// </summary>
        /// <param name="lpFile">
        /// The name of the hive file.
        /// This hive must have been created with the <see cref="RegSaveKey"/> or <see cref="RegSaveKeyEx"/> function.
        /// If the file does not exist, an empty hive file is created with the specified name.
        /// </param>
        /// <param name="phkResult">
        /// <para>
        /// Pointer to the handle for the root key of the loaded hive.
        /// </para>
        /// <para>
        /// The only way to access keys in the hive is through this handle.
        /// The registry will prevent an application from accessing keys in this hive using an absolute path to the key.
        /// As a result, it is not possible to navigate to this hive through the registry's namespace.
        /// </para>
        /// </param>
        /// <param name="samDesired">
        /// A mask that specifies the access rights requested for the returned root key.
        /// For more information, see Registry Key Security and Access Rights.
        /// </param>
        /// <param name="dwOptions">
        /// If this parameter is <see cref="REG_PROCESS_APPKEY"/>,
        /// the hive cannot be loaded again while it is loaded by the caller.
        /// This prevents access to this registry hive by another caller.
        /// </param>
        /// <param name="Reserved">
        /// This parameter is reserved.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function
        /// with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag to get a generic description of the error.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Unlike <see cref="RegLoadKey"/>, <see cref="RegLoadAppKey"/> does not load
        /// the hive under <see cref="HKEY_LOCAL_MACHINE"/> or <see cref="HKEY_USERS"/>.
        /// Instead, the hive is loaded under a special root that cannot be enumerated.
        /// As a result, there is no way to enumerate hives currently loaded by <see cref="RegLoadAppKey"/>.
        /// All operations on hives loaded by <see cref="RegLoadAppKey"/> have to be performed
        /// relative to the handle returned in <paramref name="phkResult"/>.
        /// </para>
        /// <para>
        /// If two processes are required to perform operations on the same hive,
        /// each process must call <see cref="RegLoadAppKey"/> to retrieve a handle.
        /// During the <see cref="RegLoadAppKey"/> operation,
        /// the registry will verify if the file has already been loaded.
        /// If it has been loaded, the registry will return a handle to the previously loaded hive rather than re-loading the hive.
        /// </para>
        /// <para>
        /// All keys inside the hive must have the same security descriptor, otherwise the function will fail.
        /// This security descriptor must grant the caller the access
        /// specified by the <paramref name="samDesired"/> parameter or the function will fail.
        /// You cannot use the <see cref="RegSetKeySecurity"/> function on any key inside the hive.
        /// </para>
        /// <para>
        /// In Windows 8 and later, each process can call <see cref="RegLoadAppKey"/> to load multiple hives.
        /// In Windows 7 and earlier, each process can load only one hive using <see cref="RegLoadAppKey"/> at a time.
        /// </para>
        /// <para>
        /// Any hive loaded using <see cref="RegLoadAppKey"/> is automatically unloaded
        /// when all handles to the keys inside the hive are closed using <see cref="RegCloseKey"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegLoadAppKeyW", ExactSpelling = true)]
        public static extern LSTATUS RegLoadAppKey([In] LPCWSTR lpFile, [Out] out HKEY phkResult, [In] REGSAM samDesired,
            [In] DWORD dwOptions, [In] DWORD Reserved);

        /// <summary>
        /// <para>
        /// Creates a subkey under <see cref="HKEY_USERS"/> or <see cref="HKEY_LOCAL_MACHINE"/>
        /// and loads the data from the specified registry hive into that subkey.
        /// </para>
        /// <para>
        /// Applications that back up or restore system state including system files and registry hives
        /// should use the Volume Shadow Copy Service instead of the registry functions.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regloadkeyw"/>
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// <para>
        /// A handle to the key where the subkey will be created.
        /// This can be a handle returned by a call to <see cref="RegConnectRegistry"/>, or one of the following predefined handles:
        /// </para>
        /// <para>
        /// <see cref="HKEY_LOCAL_MACHINE"/> <see cref="HKEY_USERS"/>
        /// This function always loads information at the top of the registry hierarchy.
        /// The <see cref="HKEY_CLASSES_ROOT"/> and <see cref="HKEY_CURRENT_USER"/> handle values cannot be specified for this parameter,
        /// because they represent subsets of the <see cref="HKEY_LOCAL_MACHINE"/> and <see cref="HKEY_USERS"/> handle values, respectively.
        /// </para>
        /// </param>
        /// <param name="lpSubKey">
        /// <para>
        /// The name of the key to be created under <paramref name="hKey"/>.
        /// This subkey is where the registration information from the file will be loaded.
        /// </para>
        /// <para>
        /// Key names are not case sensitive.
        /// </para>
        /// <para>
        /// For more information, see Registry Element Size Limits.
        /// </para>
        /// </param>
        /// <param name="lpFile">
        /// The name of the file containing the registry data.
        /// This file must be a local file that was created with the <see cref="RegSaveKey"/> function.
        /// If this file does not exist, a file is created with the specified name.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function
        /// with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag to get a generic description of the error.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// There are two registry hive file formats.
        /// Registry hives created on current operating systems typically cannot be loaded by earlier ones.
        /// </para>
        /// <para>
        /// If <paramref name="hKey"/> is a handle returned by <see cref="RegConnectRegistry"/>,
        /// then the path specified in lpFile is relative to the remote computer.
        /// </para>
        /// <para>
        /// The calling process must have the <see cref="SE_RESTORE_NAME"/>
        /// and <see cref="SE_BACKUP_NAME"/> privileges on the computer in which the registry resides.
        /// For more information, see Running with Special Privileges.
        /// To load a hive without requiring these special privileges, use the <see cref="RegLoadAppKey"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegLoadKeyW", ExactSpelling = true)]
        public static extern LSTATUS RegLoadKey([In] HKEY hKey, [In] LPCWSTR lpSubKey, [In] LPCWSTR lpFile);

        /// <summary>
        /// <para>
        /// Notifies the caller about changes to the attributes or contents of a specified registry key.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regnotifychangekeyvalue"/>
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// <para>
        /// A handle to an open registry key.
        /// This handle is returned by the <see cref="RegCreateKeyEx"/> or <see cref="RegOpenKeyEx"/> function.
        /// It can also be one of the following predefined keys:
        /// </para>
        /// <para>
        /// <see cref="HKEY_CLASSES_ROOT"/> <see cref="HKEY_CURRENT_CONFIG"/> <see cref="HKEY_CURRENT_USER"/>
        /// <see cref="HKEY_LOCAL_MACHINE"/> <see cref="HKEY_USERS"/>
        /// This parameter must be a local handle.
        /// If <see cref="RegNotifyChangeKeyValue"/> is called with a remote handle, it returns <see cref="ERROR_INVALID_HANDLE"/>.
        /// </para>
        /// <para>
        /// The key must have been opened with the <see cref="KEY_NOTIFY"/> access right.
        /// For more information, see Registry Key Security and Access Rights.
        /// </para>
        /// </param>
        /// <param name="bWatchSubtree">
        /// If this parameter is <see cref="TRUE"/>, the function reports changes in the specified key and its subkeys.
        /// If the parameter is <see cref="FALSE"/>, the function reports changes only in the specified key.
        /// </param>
        /// <param name="dwNotifyFilter">
        /// <para>
        /// A value that indicates the changes that should be reported.
        /// This parameter can be one or more of the following values.
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
        /// <see cref="REG_NOTIFY_CHANGE_NAME"/>
        /// </para>
        /// <para>
        /// 0x00000001L
        /// </para>
        /// </term>
        /// <term>
        /// Notify the caller if a subkey is added or deleted.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="REG_NOTIFY_CHANGE_ATTRIBUTES"/>
        /// </para>
        /// <para>
        /// 0x00000002L
        /// </para>
        /// </term>
        /// <term>
        /// Notify the caller of changes to the attributes of the key, such as the security descriptor information.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="REG_NOTIFY_CHANGE_LAST_SET"/>
        /// </para>
        /// <para>
        /// 0x00000004L
        /// </para>
        /// </term>
        /// <term>
        /// Notify the caller of changes to a value of the key.
        /// This can include adding or deleting a value, or changing an existing value.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="REG_NOTIFY_CHANGE_SECURITY"/>
        /// </para>
        /// <para>
        /// 0x00000008L
        /// </para>
        /// </term>
        /// <term>
        /// Notify the caller of changes to the security descriptor of the key.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="REG_NOTIFY_THREAD_AGNOSTIC"/>
        /// </para>
        /// <para>
        /// 0x10000000L
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Indicates that the lifetime of the registration must not be tied to the lifetime of the thread
        /// issuing the <see cref="RegNotifyChangeKeyValue"/> call.
        /// </para>
        /// <para>
        /// Note 
        /// </para>
        /// <para>
        /// This flag value is only supported in Windows 8 and later.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="hEvent">
        /// A handle to an event.
        /// If the <paramref name="fAsynchronous"/> parameter is <see cref="TRUE"/>,
        /// the function returns immediately and changes are reported by signaling this event.
        /// If <paramref name="fAsynchronous"/> is <see cref="FALSE"/>, <paramref name="hEvent"/> is ignored.
        /// </param>
        /// <param name="fAsynchronous">
        /// <para>
        /// If this parameter is <see cref="TRUE"/>, the function returns immediately and reports changes by signaling the specified event.
        /// If this parameter is <see cref="FALSE"/>, the function does not return until a change has occurred.
        /// </para>
        /// <para>
        /// If <paramref name="hEvent"/> does not specify a valid event,
        /// the <paramref name="fAsynchronous"/> parameter cannot be <see cref="TRUE"/>.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function
        /// with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag to get a generic description of the error.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function detects a single change.
        /// After the caller receives a notification event, it should call the function again to receive the next notification.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// On Windows NT, Windows 2000, and Windows XP calling <see cref="RegNotifyChangeKeyValue"/> for a particular key handle
        /// causes change notifications to continue to occur for as long as the key handle is valid.
        /// This causes a second call to <see cref="RegNotifyChangeKeyValue"/> to return immediately,
        /// if any changes have occurred in the interim period between the first and second calls.
        /// If the API is being used asynchronously, the passed event handle will be signaled immediately if any interim changes have occurred.
        /// </para>
        /// <para>
        /// This function cannot be used to detect changes to the registry that result from using the <see cref="RegRestoreKey"/> function.
        /// </para>
        /// <para>
        /// If the specified key is closed, the event is signaled.
        /// This means that an application should not depend on the key being open after returning from a wait operation on the event.
        /// </para>
        /// <para>
        /// The <see cref="REG_NOTIFY_THREAD_AGNOSTIC"/> flag introduced in Windows 8
        /// enables the use of <see cref="RegNotifyChangeKeyValue"/> for ThreadPool threads.
        /// </para>
        /// <para>
        /// If the thread that called <see cref="RegNotifyChangeKeyValue"/> exits, the event is signaled.
        /// To continue to monitor additional changes in the value of the key,
        /// call <see cref="RegNotifyChangeKeyValue"/> again from another thread.
        /// </para>
        /// <para>
        /// With the exception of <see cref="RegNotifyChangeKeyValue"/> calls with <see cref="REG_NOTIFY_THREAD_AGNOSTIC"/> set,
        /// this function must be called on persistent threads.
        /// If the calling thread is from a thread pool and it is not persistent,
        /// the event is signaled every time the thread terminates, not just when there is a registry change.
        /// To ensure accurate results, run the thread pool work in a persistent thread
        /// by using the <see cref="SetThreadpoolCallbackPersistent"/> function,
        /// or create your own thread using the <see cref="CreateThread"/> function.
        /// (For the original thread pool API,
        /// specify <see cref="WT_EXECUTEINPERSISTENTTHREAD"/> using the <see cref="QueueUserWorkItem"/> function.)
        /// </para>
        /// <para>
        /// This function should not be called multiple times with the same value for the <paramref name="hKey"/>
        /// but different values for the <paramref name="bWatchSubtree"/> and <paramref name="dwNotifyFilter"/> parameters.
        /// The function will succeed but the changes will be ignored.
        /// To change the watch parameters, you must first close the key handle by calling <see cref="RegCloseKey"/>,
        /// reopen the key handle by calling <see cref="RegOpenKeyEx"/>,
        /// and then call <see cref="RegNotifyChangeKeyValue"/> with the new parameters.
        /// </para>
        /// <para>
        /// Each time a process calls <see cref="RegNotifyChangeKeyValue"/> with the same set of parameters,
        /// it establishes another wait operation, creating a resource leak.
        /// Therefore, check that you are not calling <see cref="RegNotifyChangeKeyValue"/> with the same parameters
        /// until the previous wait operation has completed.
        /// </para>
        /// <para>
        /// To monitor registry operations in more detail, see Registry.
        /// </para>
        /// <para>
        /// Windows XP/2000: 
        /// When <see cref="RegNotifyChangeKeyValue"/> is called for a particular key handle,
        /// change notifications occur for as long as the key handle is valid.
        /// This causes a second call to <see cref="RegNotifyChangeKeyValue"/> to return immediately,
        /// if any changes occur in the interim between the first and second calls.
        /// If the function is being used asynchronously,
        /// the passed event handle will be signaled immediately if any changes occur in the interim.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegNotifyChangeKeyValue", ExactSpelling = true)]
        public static extern LSTATUS RegNotifyChangeKeyValue([In] HKEY hKey, [In] BOOL bWatchSubtree, [In] DWORD dwNotifyFilter,
            [In] HANDLE hEvent, [In] BOOL fAsynchronous);

        /// <summary>
        /// <para>
        /// Retrieves a handle to the <see cref="HKEY_CURRENT_USER"/> key for the user the current thread is impersonating.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regopencurrentuser"/>
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
        /// <para>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function
        /// with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag to get a generic description of the error.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The <see cref="HKEY_CURRENT_USER"/> key maps to the root of the current user's branch in the <see cref="HKEY_USERS"/> key.
        /// It is cached for all threads in a process.
        /// Therefore, this value does not change when another user's profile is loaded.
        /// <see cref="RegOpenCurrentUser"/> uses the thread's token to access the appropriate key,
        /// or the default if the profile is not loaded.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegOpenCurrentUser", ExactSpelling = true)]
        public static extern LSTATUS RegOpenCurrentUser([In] REGSAM samDesired, [Out] out HKEY phkResult);

        /// <summary>
        /// <para>
        /// Opens the specified registry key.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This function is provided only for compatibility with 16-bit versions of Windows.
        /// Applications should use the <see cref="RegOpenKeyEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regopenkeyw"/>
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// <para>
        /// A handle to an open registry key.
        /// This handle is returned by the <see cref="RegCreateKeyEx"/> or <see cref="RegOpenKeyEx"/> function,
        /// or it can be one of the following predefined keys:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="HKEY_CLASSES_ROOT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="HKEY_CURRENT_CONFIG"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="HKEY_CURRENT_USER"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="HKEY_LOCAL_MACHINE"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="HKEY_USERS"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpSubKey">
        /// <para>
        /// The name of the registry key to be opened.
        /// This key must be a subkey of the key identified by the <paramref name="hKey"/> parameter.
        /// </para>
        /// <para>
        /// Key names are not case sensitive.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NULL"/> or a pointer to an empty string,
        /// the function returns the same handle that was passed in.
        /// </para>
        /// <para>
        /// For more information, see Registry Element Size Limits.
        /// </para>
        /// </param>
        /// <param name="phkResult">
        /// A pointer to a variable that receives a handle to the opened key.
        /// If the key is not one of the predefined registry keys,
        /// call the <see cref="RegCloseKey"/> function after you have finished using the handle.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function
        /// with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag to get a generic description of the error.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="RegOpenKey"/> function uses the default security access mask to open a key.
        /// If opening the key requires a different access right, the function fails, returning <see cref="ERROR_ACCESS_DENIED"/>.
        /// An application should use the <see cref="RegOpenKeyEx"/> function to specify an access mask in this situation.
        /// </para>
        /// <para>
        /// <see cref="RegOpenKey"/> does not create the specified key if the key does not exist in the database.
        /// </para>
        /// <para>
        /// If your service or application impersonates different users,
        /// do not use this function with <see cref="HKEY_CURRENT_USER"/>.
        /// Instead, call the <see cref="RegOpenCurrentUser"/> function.
        /// </para>
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit versions of Windows." +
            " Applications should use the RegOpenKeyEx function.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegOpenKeyW", ExactSpelling = true)]
        public static extern LSTATUS RegOpenKey([In] HKEY hKey, [In] LPCWSTR lpSubKey, [Out] out HKEY phkResult);

        /// <summary>
        /// <para>
        /// Opens the specified registry key. Note that key names are not case sensitive.
        /// </para>
        /// <para>
        /// To perform transacted registry operations on a key, call the <see cref="RegOpenKeyTransacted"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regopenkeyexw"/>
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// <para>
        /// A handle to an open registry key.
        /// This handle is returned by the <see cref="RegCreateKeyEx"/> or <see cref="RegOpenKeyEx"/> function,
        /// or it can be one of the following predefined keys:
        /// </para>
        /// <para>
        /// <see cref="HKEY_CLASSES_ROOT"/> <see cref="HKEY_CURRENT_CONFIG"/> <see cref="HKEY_CURRENT_USER"/>
        /// <see cref="HKEY_LOCAL_MACHINE"/> <see cref="HKEY_USERS"/>
        /// </para>
        /// </param>
        /// <param name="lpSubKey">
        /// <para>
        /// The name of the registry subkey to be opened.
        /// </para>
        /// <para>
        /// Key names are not case sensitive.
        /// </para>
        /// <para>
        /// If the <paramref name="lpSubKey"/> parameter is <see cref="NULL"/> or a pointer to an empty string,
        /// and if <paramref name="hKey"/> is a predefined key, then the system refreshes the predefined key,
        /// and <paramref name="phkResult"/> receives the same <paramref name="hKey"/> handle passed into the function.
        /// Otherwise, <paramref name="phkResult"/> receives a new handle to the opened key.
        /// </para>
        /// <para>
        /// For more information, see Registry Element Size Limits.
        /// </para>
        /// </param>
        /// <param name="ulOptions">
        /// <para>
        /// Specifies the option to apply when opening the key.
        /// Set this parameter to zero or the following:
        /// </para>
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
        /// <see cref="REG_OPTION_OPEN_LINK"/>
        /// </term>
        /// <term>
        /// The key is a symbolic link.
        /// Registry symbolic links should only be used when absolutely necessary.
        /// </term>
        /// </item>
        /// </list>
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
        /// <para>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function
        /// with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag to get a generic description of the error.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Unlike the <see cref="RegCreateKeyEx"/> function,
        /// the <see cref="RegOpenKeyEx"/> function does not create the specified key if the key does not exist in the registry.
        /// </para>
        /// <para>
        /// Certain registry operations perform access checks against the security descriptor of the key,
        /// not the access mask specified when the handle to the key was obtained.
        /// For example, even if a key is opened with a <paramref name="samDesired"/> of <see cref="KEY_READ"/>,
        /// it can be used to create registry keys if the key's security descriptor permits.
        /// In contrast, the <see cref="RegSetValueEx"/> function specifically requires
        /// that the key be opened with the <see cref="KEY_SET_VALUE"/> access right.
        /// </para>
        /// <para>
        /// If your service or application impersonates different users,
        /// do not use this function with <see cref="HKEY_CURRENT_USER"/>.
        /// Instead, call the <see cref="RegOpenCurrentUser"/> function.
        /// </para>
        /// <para>
        /// Note that operations that access certain registry keys are redirected.
        /// For more information, see Registry Virtualization and 32-bit and 64-bit Application Data in the Registry.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegOpenKeyExW", ExactSpelling = true)]
        public static extern LSTATUS RegOpenKeyEx([In] HKEY hKey, [In] LPCWSTR lpSubKey, [In] RegistryOptions ulOptions,
            [In] REGSAM samDesired, [Out] out HKEY phkResult);

        /// <summary>
        /// <para>
        /// Opens the specified registry key and associates it with a transaction.
        /// Note that key names are not case sensitive.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regopenkeytransactedw"/>
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// <para>
        /// A handle to an open registry key.
        /// This handle is returned by the <see cref="RegCreateKeyEx"/>, <see cref="RegCreateKeyTransacted"/>,
        /// <see cref="RegOpenKeyEx"/>, or <see cref="RegOpenKeyTransacted"/> function.
        /// It can also be one of the following predefined keys:
        /// </para>
        /// <para>
        /// <see cref="HKEY_CLASSES_ROOT"/> <see cref="HKEY_CURRENT_USER"/>
        /// <see cref="HKEY_LOCAL_MACHINE"/> <see cref="HKEY_USERS"/>
        /// </para>
        /// </param>
        /// <param name="lpSubKey">
        /// <para>
        /// The name of the registry subkey to be opened.
        /// </para>
        /// <para>
        /// Key names are not case sensitive.
        /// </para>
        /// <para>
        /// If the <paramref name="lpSubKey"/> parameter is <see cref="NULL"/> or a pointer to an empty string,
        /// and if <paramref name="hKey"/> is a predefined key, then the system refreshes the predefined key,
        /// and <paramref name="phkResult"/> receives the same <paramref name="hKey"/> handle passed into the function.
        /// Otherwise, <paramref name="phkResult"/> receives a new handle to the opened key.
        /// </para>
        /// <para>
        /// For more information, see Registry Element Size Limits.
        /// </para>
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
        /// <para>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function
        /// with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag to get a generic description of the error.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// When a key is opened using this function, subsequent operations on the key are transacted.
        /// If a non-transacted operation is performed on the key before the transaction is committed, the transaction is rolled back.
        /// After a transaction is committed or rolled back, you must re-open the key
        /// using the <see cref="RegCreateKeyTransacted"/> or <see cref="RegOpenKeyTransacted"/> function
        /// with an active transaction handle to make additional operations transacted.
        /// For more information about transactions, see Kernel Transaction Manager.
        /// </para>
        /// <para>
        /// Note that subsequent operations on subkeys of this key are not automatically transacted.
        /// Therefore, the <see cref="RegDeleteKeyEx"/> function does not perform a transacted delete operation.
        /// Instead, use the <see cref="RegDeleteKeyTransacted"/> function to perform a transacted delete operation.
        /// </para>
        /// <para>
        /// Unlike the <see cref="RegCreateKeyTransacted"/> function,
        /// the <see cref="RegOpenKeyTransacted"/> function does not create the specified key if the key does not exist in the registry.
        /// </para>
        /// <para>
        /// If your service or application impersonates different users, do not use this function with <see cref="HKEY_CURRENT_USER"/>.
        /// Instead, call the <see cref="RegOpenCurrentUser"/> function.
        /// </para>
        /// <para>
        /// If the key returned in phkResult is a predefined registry key, it is not included in the provided transaction.
        /// </para>
        /// <para>
        /// A single registry key can be opened only 65,534 times.
        /// When attempting the 65,535 open operation, this function fails with <see cref="ERROR_NO_SYSTEM_RESOURCES"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegOpenKeyTransactedW", ExactSpelling = true)]
        public static extern LSTATUS RegOpenKeyTransacted([In] HKEY hKey, [In] LPCWSTR lpSubKey, [In] RegistryOptions ulOptions,
            [In] REGSAM samDesired, [Out] out HKEY phkResult, [In] HANDLE hTransaction, [In] PVOID pExtendedParemeter);

        /// <summary>
        /// <para>
        /// Retrieves information about the specified registry key.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regqueryinfokeyw"/>
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// <para>
        /// A handle to an open registry key. The key must have been opened with the <see cref="KEY_QUERY_VALUE"/> access right.
        /// For more information, see Registry Key Security and Access Rights.
        /// </para>
        /// <para>
        /// This handle is returned by the <see cref="RegCreateKeyEx"/>, <see cref="RegCreateKeyTransacted"/>,
        /// <see cref="RegOpenKeyEx"/>, or <see cref="RegOpenKeyTransacted"/> function.
        /// It can also be one of the following predefined keys:
        /// </para>
        /// <see cref="HKEY_CLASSES_ROOT "/> <see cref="HKEY_CURRENT_CONFIG"/>
        /// <see cref="HKEY_CURRENT_USER"/> <see cref="HKEY_LOCAL_MACHINE"/>
        /// <see cref="HKEY_PERFORMANCE_DATA"/> <see cref="HKEY_USERS"/>
        /// </param>
        /// <param name="lpClass">
        /// A pointer to a buffer that receives the user-defined class of the key.
        /// This parameter can be <see cref="NULL"/>.
        /// </param>
        /// <param name="lpcchClass">
        /// <para>
        /// A pointer to a variable that specifies the size of the buffer pointed to by the <paramref name="lpClass"/> parameter, in characters.
        /// </para>
        /// <para>
        /// The size should include the terminating null character.
        /// When the function returns, this variable contains the size of the class string that is stored in the buffer.
        /// The count returned does not include the terminating null character.
        /// If the buffer is not big enough, the function returns <see cref="ERROR_MORE_DATA"/>,
        /// and the variable contains the size of the string, in characters, without counting the terminating null character.
        /// </para>
        /// <para>
        /// If lpClass is <see cref="NULL"/>, <paramref name="lpClass"/> can be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// If the <paramref name="lpClass"/> parameter is a valid address, but the <paramref name="lpClass"/> parameter is not,
        /// for example, it is <see cref="NULL"/>, then the function returns <see cref="ERROR_INVALID_PARAMETER"/>.
        /// </para>
        /// </param>
        /// <param name="lpReserved">
        /// This parameter is reserved and must be <see cref="NULL"/>.
        /// </param>
        /// <param name="lpcSubKeys">
        /// A pointer to a variable that receives the number of subkeys that are contained by the specified key.
        /// This parameter can be <see cref="NullRef{DWORD}"/>.
        /// </param>
        /// <param name="lpcbMaxSubKeyLen">
        /// A pointer to a variable that receives the size of the key's subkey with the longest name,
        /// in Unicode characters, not including the terminating null character.
        /// This parameter can be <see cref="NullRef{DWORD}"/>.
        /// </param>
        /// <param name="lpcbMaxClassLen">
        /// A pointer to a variable that receives the size of the longest string that specifies a subkey class, in Unicode characters.
        /// The count returned does not include the terminating null character.
        /// This parameter can be <see cref="NullRef{DWORD}"/>.
        /// </param>
        /// <param name="lpcValues">
        /// A pointer to a variable that receives the number of values that are associated with the key.
        /// This parameter can be <see cref="NullRef{DWORD}"/>.
        /// </param>
        /// <param name="lpcbMaxValueNameLen">
        /// A pointer to a variable that receives the size of the key's longest value name, in Unicode characters.
        /// The size does not include the terminating null character.
        /// This parameter can be <see cref="NullRef{DWORD}"/>.
        /// </param>
        /// <param name="lpcbMaxValueLen">
        /// A pointer to a variable that receives the size of the longest data component among the key's values, in bytes.
        /// This parameter can be <see cref="NullRef{DWORD}"/>.
        /// </param>
        /// <param name="lpcbSecurityDescriptor">
        /// A pointer to a variable that receives the size of the key's security descriptor, in bytes.
        /// This parameter can be <see cref="NullRef{DWORD}"/>.
        /// </param>
        /// <param name="lpftLastWriteTime">
        /// <para>
        /// A pointer to a <see cref="FILETIME"/> structure that receives the last write time.
        /// This parameter can be <see cref="NullRef{FILETIME}"/>.
        /// </para>
        /// <para>
        /// The function sets the members of the <see cref="FILETIME"/> structure to indicate
        /// the last time that the key or any of its value entries is modified.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is a system error code.
        /// </para>
        /// <para>
        /// If the <paramref name="lpClass"/> buffer is too small to receive the name of the class,
        /// the function returns <see cref="ERROR_MORE_DATA"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegQueryInfoKeyW", ExactSpelling = true)]
        public static extern LSTATUS RegQueryInfoKey([In] HKEY hKey, [In] LPWSTR lpClass, [In][Out] ref DWORD lpcchClass, [In] IntPtr lpReserved,
            [Out] out DWORD lpcSubKeys, [Out] out DWORD lpcbMaxSubKeyLen, [Out] out DWORD lpcbMaxClassLen, [Out] out DWORD lpcValues,
            [Out] out DWORD lpcbMaxValueNameLen, [Out] out DWORD lpcbMaxValueLen, [Out] out DWORD lpcbSecurityDescriptor,
            [Out] out FILETIME lpftLastWriteTime);

        /// <summary>
        /// <para>
        /// Retrieves the type and data for a list of value names associated with an open registry key.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regquerymultiplevaluesw"/>
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// <para>
        /// A handle to an open registry key.
        /// The key must have been opened with the <see cref="KEY_QUERY_VALUE"/> access right.
        /// For more information, see Registry Key Security and Access Rights.
        /// </para>
        /// <para>
        /// This handle is returned by the <see cref="RegCreateKeyEx"/>, <see cref="RegCreateKeyTransacted"/>,
        /// <see cref="RegOpenKeyEx"/>, or <see cref="RegOpenKeyTransacted"/> function.
        /// It can also be one of the following predefined keys:
        /// </para>
        /// <para>
        /// <see cref="HKEY_CLASSES_ROOT"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_CONFIG"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_USER"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_LOCAL_MACHINE"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_PERFORMANCE_DATA"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_USERS"/>
        /// </para>
        /// </param>
        /// <param name="val_list">
        /// <para>
        /// A pointer to an array of <see cref="VALENT"/> structures that describe one or more value entries.
        /// On input, the <see cref="VALENT.ve_valuename"/> member of each structure
        /// must contain a pointer to the name of a value to retrieve.
        /// The function fails if any of the specified values do not exist in the specified key.
        /// </para>
        /// <para>
        /// If the function succeeds, each element of the array contains the information for the specified value.
        /// </para>
        /// </param>
        /// <param name="num_vals">
        /// The number of elements in the <paramref name="val_list"/> array.
        /// </param>
        /// <param name="lpValueBuf">
        /// <para>
        /// A pointer to a buffer.
        /// If the function succeeds, the buffer receives the data for each value.
        /// </para>
        /// <para>
        /// If <paramref name="lpValueBuf"/> is <see cref="NULL"/>,
        /// the value pointed to by the <paramref name="ldwTotsize"/> parameter must be zero,
        /// in which case the function returns <see cref="ERROR_MORE_DATA"/>
        /// and <paramref name="ldwTotsize"/> receives the required size of the buffer, in bytes.
        /// </para>
        /// </param>
        /// <param name="ldwTotsize">
        /// A pointer to a variable that specifies the size of the buffer pointed to by the <paramref name="lpValueBuf"/> parameter, in bytes.
        /// If the function succeeds, <paramref name="ldwTotsize"/> receives the number of bytes copied to the buffer.
        /// If the function fails because the buffer is too small, <paramref name="ldwTotsize"/> receives the required size, in bytes.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is one of the following error codes.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_CANTREAD"/>
        /// </term>
        /// <term>
        /// <see cref="RegQueryMultipleValues"/> cannot instantiate or access the provider of the dynamic key.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_MORE_DATA"/>
        /// </term>
        /// <term>
        /// The buffer pointed to by <paramref name="lpValueBuf"/> was too small.
        /// In this case, <paramref name="ldwTotsize"/> receives the required buffer size.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_TRANSFER_TOO_LONG"/>
        /// </term>
        /// <term>
        /// The total size of the requested data (size of the <paramref name="val_list"/> array + <paramref name="ldwTotsize"/>)
        /// is more than the system limit of one megabyte.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="RegQueryMultipleValues"/> function allows an application to query one or more values of a static or dynamic key.
        /// If the target key is a static key, the system provides all of the values in an atomic fashion.
        /// To prevent excessive serialization, the aggregate data returned by the function cannot exceed one megabyte.
        /// </para>
        /// <para>
        /// If the target key is a dynamic key, its provider must provide all the values in an atomic fashion.
        /// This means the provider should fill the results buffer synchronously,
        /// providing a consistent view of all the values in the buffer while avoiding excessive serialization.
        /// The provider can provide at most one megabyte of total output data during an atomic call to this function.
        /// </para>
        /// <para>
        /// <see cref="RegQueryMultipleValues"/> is supported remotely;
        /// that is, the <paramref name="hKey"/> parameter passed to the function can refer to a remote computer.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegQueryMultipleValuesW", ExactSpelling = true)]
        public static extern LSTATUS RegQueryMultipleValues([In] HKEY hKey, [In][Out] VALENT[] val_list, [In] DWORD num_vals,
            [In] LPWSTR lpValueBuf, [In][Out] ref DWORD ldwTotsize);

        /// <summary>
        /// <para>
        /// Retrieves the data associated with the default or unnamed value of a specified registry key.
        /// The data must be a null-terminated string.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This function is provided only for compatibility with 16-bit versions of Windows.
        /// Applications should use the <see cref="RegQueryValueEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regqueryvaluew"/>
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// <para>
        /// A handle to an open registry key.
        /// The key must have been opened with the <see cref="KEY_QUERY_VALUE"/> access right.
        /// For more information, see Registry Key Security and Access Rights.
        /// </para>
        /// <para>
        /// This handle is returned by the <see cref="RegCreateKeyEx"/>, <see cref="RegCreateKeyTransacted"/>,
        /// <see cref="RegOpenKeyEx"/>, or <see cref="RegOpenKeyTransacted"/> function.
        /// It can also be one of the following predefined keys:
        /// </para>
        /// <para>
        /// <see cref="HKEY_CLASSES_ROOT"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_CONFIG"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_USER"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_LOCAL_MACHINE"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_USERS"/>
        /// </para>
        /// </param>
        /// <param name="lpSubKey">
        /// <para>
        /// The name of the subkey of the <paramref name="hKey"/> parameter for which the default value is retrieved.
        /// </para>
        /// <para>
        /// Key names are not case sensitive.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NULL"/> or points to an empty string,
        /// the function retrieves the default value for the key identified by <paramref name="hKey"/>.
        /// </para>
        /// <para>
        /// For more information, see Registry Element Size Limits.
        /// </para>
        /// </param>
        /// <param name="lpData">
        /// <para>
        /// A pointer to a buffer that receives the default value of the specified key.
        /// </para>
        /// <para>
        /// If lpValue is <see cref="NULL"/>, and <paramref name="lpcbData"/> is non-<see cref="NULL"/>,
        /// the function returns <see cref="ERROR_SUCCESS"/>, and stores the size of the data, in bytes,
        /// in the variable pointed to by <paramref name="lpcbData"/>.
        /// This enables an application to determine the best way to allocate a buffer for the value's data.
        /// </para>
        /// </param>
        /// <param name="lpcbData">
        /// <para>
        /// A pointer to a variable that specifies the size of the buffer pointed to by the <paramref name="lpData"/> parameter, in bytes.
        /// When the function returns, this variable contains the size of the data copied to <paramref name="lpData"/>,
        /// including any terminating null characters.
        /// </para>
        /// <para>
        /// If the data has the <see cref="REG_SZ"/>, <see cref="REG_MULTI_SZ"/> or <see cref="REG_EXPAND_SZ"/> type,
        /// this size includes any terminating null character or characters. For more information, see Remarks.
        /// </para>
        /// <para>
        /// If the buffer specified <paramref name="lpData"/> is not large enough to hold the data,
        /// the function returns <see cref="ERROR_MORE_DATA"/>
        /// and stores the required buffer size in the variable pointed to by <paramref name="lpcbData"/>.
        /// In this case, the contents of the <paramref name="lpData"/> buffer are undefined.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is a system error code.
        /// </para>
        /// <para>
        /// If the <paramref name="lpData"/> buffer is too small to receive the value, the function returns <see cref="ERROR_MORE_DATA"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the ANSI version of this function is used (either by explicitly calling RegQueryValueA
        /// or by not defining UNICODE before including the Windows.h file),
        /// this function converts the stored Unicode string to an ANSI string
        /// before copying it to the buffer specified by the <paramref name="lpData"/> parameter.
        /// </para>
        /// <para>
        /// If the data has the <see cref="REG_SZ"/>, <see cref="REG_MULTI_SZ"/> or <see cref="REG_EXPAND_SZ"/> type,
        /// the string may not have been stored with the proper null-terminating characters.
        /// Therefore, even if the function returns <see cref="ERROR_SUCCESS"/>,
        /// the application should ensure that the string is properly terminated before using it;
        /// otherwise, it may overwrite a buffer.
        /// (Note that <see cref="REG_MULTI_SZ"/> strings should have two null-terminating characters.)
        /// </para>
        /// <para>
        /// Note that operations that access certain registry keys are redirected.
        /// For more information, see Registry Virtualization and 32-bit and 64-bit Application Data in the Registry.
        /// </para>
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit versions of Windows." +
            " Applications should use the RegQueryValueEx function.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegQueryValueW", ExactSpelling = true)]
        public static extern LSTATUS RegQueryValue([In] HKEY hKey, [In] LPCWSTR lpSubKey, [In] IntPtr lpData, [Out] out LONG lpcbData);

        /// <summary>
        /// <para>
        /// Retrieves the type and data for the specified value name associated with an open registry key.
        /// </para>
        /// <para>
        ///  Warning
        /// </para>
        /// <para>
        /// If the value being queried is a string (<see cref="REG_SZ"/>, <see cref="REG_MULTI_SZ"/>,
        /// and <see cref="REG_EXPAND_SZ"/>) the value returned is NOT guaranteed to be null-terminated.
        /// Use the <see cref="RegGetValue"/> function if you want to ensure returned string values are null-terminated.
        /// More information is in the remarks below.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regqueryvalueexw"/>
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// <para>
        /// A handle to an open registry key.
        /// The key must have been opened with the <see cref="KEY_QUERY_VALUE"/> access right.
        /// For more information, see Registry Key Security and Access Rights.
        /// </para>
        /// <para>
        /// This handle is returned by the <see cref="RegCreateKeyEx"/>, <see cref="RegCreateKeyTransacted"/>,
        /// <see cref="RegOpenKeyEx"/>, or <see cref="RegOpenKeyTransacted"/> function.
        /// It can also be one of the following predefined keys:
        /// </para>
        /// <para>
        /// <see cref="HKEY_CLASSES_ROOT"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_CONFIG"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_USER"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_LOCAL_MACHINE"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_PERFORMANCE_DATA"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_PERFORMANCE_NLSTEXT"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_PERFORMANCE_TEXT"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_USERS"/>
        /// </para>
        /// </param>
        /// <param name="lpValueName">
        /// <para>
        /// The name of the registry value.
        /// </para>
        /// <para>
        /// If <paramref name="lpValueName"/> is <see cref="NULL"/> or an empty string, "",
        /// the function retrieves the type and data for the key's unnamed or default value, if any.
        /// </para>
        /// <para>
        /// If <paramref name="lpValueName"/> specifies a value that is not in the registry,
        /// the function returns <see cref="ERROR_FILE_NOT_FOUND"/>.
        /// </para>
        /// <para>
        /// Keys do not automatically have an unnamed or default value.
        /// Unnamed values can be of any type.
        /// For more information, see Registry Element Size Limits.
        /// </para>
        /// </param>
        /// <param name="lpReserved">
        /// This parameter is reserved and must be <see cref="NULL"/>.
        /// </param>
        /// <param name="lpType">
        /// A pointer to a variable that receives a code indicating the type of data stored in the specified value.
        /// For a list of the possible type codes, see Registry Value Types.
        /// The <paramref name="lpType"/> parameter can be <see cref="NullRef{RegistryValueTypes}"/> if the type code is not required.
        /// </param>
        /// <param name="lpData">
        /// A pointer to a buffer that receives the value's data.
        /// This parameter can be <see cref="NULL"/> if the data is not required.
        /// </param>
        /// <param name="lpcbData">
        /// <para>
        /// A pointer to a variable that specifies the size of the buffer pointed to by the <paramref name="lpData"/> parameter, in bytes.
        /// When the function returns, this variable contains the size of the data copied to <paramref name="lpData"/>.
        /// </para>
        /// <para>
        /// The <paramref name="lpcbData"/> parameter can be <see cref="NULL"/> only if <paramref name="lpData"/> is <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// If the data has the <see cref="REG_SZ"/>, <see cref="REG_MULTI_SZ"/> or <see cref="REG_EXPAND_SZ"/> type,
        /// this size includes any terminating null character or characters unless the data was stored without them.
        /// For more information, see Remarks.
        /// </para>
        /// <para>
        /// If the buffer specified by <paramref name="lpData"/> parameter is not large enough to hold the data,
        /// the function returns <see cref="ERROR_MORE_DATA"/>
        /// and stores the required buffer size in the variable pointed to by <paramref name="lpcbData"/>.
        /// In this case, the contents of the <paramref name="lpData"/> buffer are undefined.
        /// </para>
        /// <para>
        /// If <paramref name="lpData"/> is <see cref="NULL"/>, and <paramref name="lpcbData"/> is non-<see cref="NULL"/>,
        /// the function returns <see cref="ERROR_SUCCESS"/> and stores the size of the data,
        /// in bytes, in the variable pointed to by <paramref name="lpcbData"/>.
        /// This enables an application to determine the best way to allocate a buffer for the value's data.
        /// </para>
        /// <para>
        /// If <paramref name="hKey"/> specifies <see cref="HKEY_PERFORMANCE_DATA"/>
        /// and the <paramref name="lpData"/> buffer is not large enough to contain all of the returned data,
        /// <see cref="RegQueryValueEx"/> returns <see cref="ERROR_MORE_DATA"/>
        /// and the value returned through the <paramref name="lpcbData"/> parameter is undefined.
        /// This is because the size of the performance data can change from one call to the next.
        /// In this case, you must increase the buffer size and call <see cref="RegQueryValueEx"/> again
        /// passing the updated buffer size in the <paramref name="lpcbData"/> parameter.
        /// Repeat this until the function succeeds.
        /// You need to maintain a separate variable to keep track of the buffer size,
        /// because the value returned by <paramref name="lpcbData"/> is unpredictable.
        /// </para>
        /// <para>
        /// If the <paramref name="lpValueName"/> registry value does not exist,
        /// <see cref="RegQueryValueEx"/> returns <see cref="ERROR_FILE_NOT_FOUND"/>
        /// and the value returned through the <paramref name="lpcbData"/> parameter is undefined.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is a system error code.
        /// </para>
        /// <para>
        /// If the <paramref name="lpData"/> buffer is too small to receive the data,
        /// the function returns <see cref="ERROR_MORE_DATA"/>.
        /// </para>
        /// <para>
        /// If the <paramref name="lpValueName"/> registry value does not exist,
        /// the function returns <see cref="ERROR_FILE_NOT_FOUND"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// An application typically calls <see cref="RegEnumValue"/> to determine the value names
        /// and then <see cref="RegQueryValueEx"/> to retrieve the data for the names.
        /// </para>
        /// <para>
        /// If the data has the <see cref="REG_SZ"/>, <see cref="REG_MULTI_SZ"/> or <see cref="REG_EXPAND_SZ"/> type,
        /// the string may not have been stored with the proper terminating null characters.
        /// Therefore, even if the function returns <see cref="ERROR_SUCCESS"/>,
        /// the application should ensure that the string is properly terminated before using it; otherwise, it may overwrite a buffer.
        /// (Note that <see cref="REG_MULTI_SZ"/> strings should have two terminating null characters.)
        /// One way an application can ensure that the string is properly terminated is to use <see cref="RegGetValue"/>,
        /// which adds terminating null characters if needed.
        /// </para>
        /// <para>
        /// If the data has the <see cref="REG_SZ"/>, <see cref="REG_MULTI_SZ"/> or <see cref="REG_EXPAND_SZ"/> type,
        /// and the ANSI version of this function is used
        /// (either by explicitly calling RegQueryValueExA or by not defining UNICODE before including the Windows.h file),
        /// this function converts the stored Unicode string to an ANSI string
        /// before copying it to the buffer pointed to by <paramref name="lpData"/>.
        /// </para>
        /// <para>
        /// When calling the <see cref="RegQueryValueEx"/> function with <paramref name="hKey"/> set to the <see cref="HKEY_PERFORMANCE_DATA"/> handle
        /// and a value string of a specified object, the returned data structure sometimes has unrequested objects.
        /// Do not be surprised; this is normal behavior.
        /// When calling the <see cref="RegQueryValueEx"/> function,
        /// you should always expect to walk the returned data structure to look for the requested object.
        /// </para>
        /// <para>
        /// Note that operations that access certain registry keys are redirected.
        /// For more information, see Registry Virtualization and 32-bit and 64-bit Application Data in the Registry.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegQueryValueExW", ExactSpelling = true)]
        public static extern LSTATUS RegQueryValueEx([In] HKEY hKey, [In] LPCWSTR lpValueName, [In] IntPtr lpReserved,
            [Out] out RegistryValueTypes lpType, [In] IntPtr lpData, [In][Out] ref DWORD lpcbData);

        /// <summary>
        /// <para>
        /// Replaces the file backing a registry key and all its subkeys with another file,
        /// so that when the system is next started, the key and subkeys will have the values stored in the new file.
        /// </para>
        /// <para>
        /// Applications that back up or restore system state including system files and registry hives
        /// should use the Volume Shadow Copy Service instead of the registry functions.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regreplacekeyw"/>
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// <para>
        /// A handle to an open registry key.
        /// This handle is returned by the <see cref="RegCreateKeyEx"/> or <see cref="RegOpenKeyEx"/> function,
        /// or it can be one of the following predefined keys:
        /// </para>
        /// <para>
        /// <see cref="HKEY_CLASSES_ROOT"/> <see cref="HKEY_CURRENT_CONFIG"/> <see cref="HKEY_CURRENT_USER"/>
        /// <see cref="HKEY_LOCAL_MACHINE"/> <see cref="HKEY_USERS"/>
        /// </para>
        /// </param>
        /// <param name="lpSubKey">
        /// <para>
        /// The name of the registry key whose subkeys and values are to be replaced.
        /// If the key exists, it must be a subkey of the key identified by the <paramref name="hKey"/> parameter.
        /// If the subkey does not exist, it is created.
        /// This parameter can be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// If the specified subkey is not the root of a hive,
        /// <see cref="RegReplaceKey"/> traverses up the hive tree structure until it encounters a hive root,
        /// then it replaces the contents of that hive with the contents of the data file specified by <paramref name="lpNewFile"/>.
        /// </para>
        /// <para>
        /// For more information, see Registry Element Size Limits.
        /// </para>
        /// </param>
        /// <param name="lpNewFile">
        /// The name of the file with the registry information.
        /// This file is typically created by using the <see cref="RegSaveKey"/> function.
        /// </param>
        /// <param name="lpOldFile">
        /// The name of the file that receives a backup copy of the registry information being replaced.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function
        /// with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag to get a generic description of the error.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// There are two different registry hive file formats.
        /// Registry hives created on current operating systems typically cannot be loaded by earlier ones.
        /// </para>
        /// <para>
        /// The file specified by the <paramref name="lpNewFile"/> parameter remains open until the system is restarted.
        /// </para>
        /// <para>
        /// If <paramref name="hKey"/> is a handle returned by <see cref="RegConnectRegistry"/>,
        /// then the paths specified in <paramref name="lpNewFile"/> and <paramref name="lpOldFile"/> are relative to the remote computer.
        /// </para>
        /// <para>
        /// The calling process must have the <see cref="SE_RESTORE_NAME"/>
        /// and <see cref="SE_BACKUP_NAME"/> privileges on the computer in which the registry resides.
        /// For more information, see Running with Special Privileges.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegReplaceKeyW", ExactSpelling = true)]
        public static extern LSTATUS RegReplaceKey([In] HKEY hKey, [In] LPCWSTR lpSubKey, [In] LPCWSTR lpNewFile, [In] LPCWSTR lpOldFile);

        /// <summary>
        /// <para>
        /// Reads the registry information in a specified file and copies it over the specified key.
        /// This registry information may be in the form of a key and multiple levels of subkeys.
        /// </para>
        /// <para>
        /// Applications that back up or restore system state including system files and registry hives
        /// should use the Volume Shadow Copy Service instead of the registry functions.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regrestorekeyw"/>
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// <para>
        /// A handle to an open registry key.
        /// This handle is returned by the <see cref="RegCreateKeyEx"/> or <see cref="RegOpenKeyEx"/> function.
        /// It can also be one of the following predefined keys:
        /// </para>
        /// <para>
        /// <see cref="HKEY_CLASSES_ROOT"/> <see cref="HKEY_CURRENT_CONFIG"/> <see cref="HKEY_CURRENT_USER"/>
        /// <see cref="HKEY_LOCAL_MACHINE"/> <see cref="HKEY_USERS"/>
        /// Any information contained in this key and its descendent keys is overwritten
        /// by the information in the file pointed to by the <paramref name="lpFile"/> parameter.
        /// </para>
        /// </param>
        /// <param name="lpFile">
        /// The name of the file with the registry information.
        /// This file is typically created by using the <see cref="RegSaveKey"/> function.
        /// </param>
        /// <param name="dwFlags">
        /// <para>
        /// The flags that indicate how the key or keys are to be restored.
        /// This parameter can be one of the following values.
        /// </para>
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
        /// <see cref="REG_FORCE_RESTORE"/>
        /// </para>
        /// <para>
        /// 0x00000008L
        /// </para>
        /// </term>
        /// <term>
        /// If specified, the restore operation is executed even if open handles exist at or beneath the location
        /// in the registry hierarchy to which the <paramref name="hKey"/> parameter points.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="REG_WHOLE_HIVE_VOLATILE"/>
        /// </para>
        /// <para>
        /// 0x00000001L
        /// </para>
        /// </term>
        /// <term>
        /// If specified, a new, volatile (memory only) set of registry information, or hive, is created.
        /// If REG_WHOLE_HIVE_VOLATILE is specified, the key identified by the <paramref name="hKey"/> parameter
        /// must be either the <see cref="HKEY_USERS"/> or <see cref="HKEY_LOCAL_MACHINE"/> value.
        /// </term>
        /// </item>
        /// </list>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function
        /// with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag to get a generic description of the error.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// There are two different registry hive file formats.
        /// Registry hives created on current operating systems typically cannot be loaded by earlier ones.
        /// </para>
        /// <para>
        /// If any subkeys of the <paramref name="hKey"/> parameter are open, <see cref="RegRestoreKey"/> fails.
        /// </para>
        /// <para>
        /// The calling process must have the <see cref="SE_RESTORE_NAME"/>
        /// and <see cref="SE_BACKUP_NAME"/> privileges on the computer in which the registry resides.
        /// For more information, see Running with Special Privileges.
        /// </para>
        /// <para>
        /// This function replaces the keys and values below the specified key
        /// with the keys and values that are subsidiary to the top-level key in the file,
        /// no matter what the name of the top-level key in the file might be.
        /// For example, <paramref name="hKey"/> might identify a key A with subkeys B and C,
        /// while the <paramref name="lpFile"/> parameter specifies a file containing key X with subkeys Y and Z.
        /// After a call to <see cref="RegRestoreKey"/>, the registry would contain key A with subkeys Y and Z.
        /// The value entries of A would be replaced by the value entries of X.
        /// </para>
        /// <para>
        /// The new information in the file specified by <paramref name="lpFile"/>
        /// overwrites the contents of the key specified by the <paramref name="hKey"/> parameter, except for the key name.
        /// </para>
        /// <para>
        /// If <paramref name="hKey"/> represents a key in a remote computer,
        /// the path described by <paramref name="lpFile"/> is relative to the remote computer.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegRestoreKeyW", ExactSpelling = true)]
        public static extern LSTATUS RegRestoreKey([In] HKEY hKey, [In] LPCWSTR lpFile, [In] RegRestoreKeyFlags dwFlags);

        /// <summary>
        /// <para>
        /// Saves the specified key and all of its subkeys and values to a new file, in the standard format.
        /// </para>
        /// <para>
        /// To specify the format for the saved key or hive, use the <see cref="RegSaveKeyEx"/> function.
        /// </para>
        /// <para>
        /// Applications that back up or restore system state including system files and registry hives
        /// should use the Volume Shadow Copy Service instead of the registry functions.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regsavekeyw"/>
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// <para>
        /// A handle to an open registry key.
        /// </para>
        /// <para>
        /// This handle is returned by the <see cref="RegCreateKeyEx"/> or <see cref="RegOpenKeyEx"/> function,
        /// or it can be one of the following predefined keys:
        /// </para>
        /// <para>
        /// <see cref="HKEY_CLASSES_ROOT"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_USER"/>
        /// </para>
        /// </param>
        /// <param name="lpFile">
        /// <para>
        /// The name of the file in which the specified key and subkeys are to be saved.
        /// If the file already exists, the function fails.
        /// </para>
        /// <para>
        /// If the string does not include a path, the file is created in the current directory of the calling process for a local key,
        /// or in the %systemroot%\system32 directory for a remote key.
        /// The new file has the archive attribute.
        /// </para>
        /// </param>
        /// <param name="lpSecurityAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that specifies a security descriptor for the new file.
        /// If <paramref name="lpSecurityAttributes"/> is <see cref="NullRef{SECURITY_ATTRIBUTES}"/>, the file gets a default security descriptor.
        /// The ACLs in a default security descriptor for a file are inherited from its parent directory.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function
        /// with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag to get a generic description of the error.
        /// </para>
        /// <para>
        /// If the file already exists, the function fails with the <see cref="ERROR_ALREADY_EXISTS"/> error.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If <paramref name="hKey"/> represents a key on a remote computer,
        /// the path described by <paramref name="lpFile"/> is relative to the remote computer.
        /// </para>
        /// <para>
        /// The <see cref="RegSaveKey"/> function saves only nonvolatile keys.
        /// It does not save volatile keys.
        /// A key is made volatile or nonvolatile at its creation; see <see cref="RegCreateKeyEx"/>.
        /// </para>
        /// <para>
        /// You can use the file created by <see cref="RegSaveKey"/> in subsequent calls to the <see cref="RegLoadKey"/>,
        /// <see cref="RegReplaceKey"/>, or <see cref="RegRestoreKey"/> functions.
        /// If <see cref="RegSaveKey"/> fails part way through its operation,
        /// the file will be corrupt and subsequent calls to <see cref="RegLoadKey"/>,
        /// <see cref="RegReplaceKey"/>, or <see cref="RegRestoreKey"/> for the file will fail.
        /// </para>
        /// <para>
        /// Using <see cref="RegSaveKey"/> together with <see cref="RegRestoreKey"/> to copy subtrees in the registry is not recommended.
        /// This method does not trigger notifications and can invalidate handles used by other applications.
        /// Instead, use the <see cref="SHCopyKey"/> function or the <see cref="RegCopyTree"/> function.
        /// </para>
        /// <para>
        /// The calling process must have the <see cref="SE_BACKUP_NAME"/> privilege enabled.
        /// For more information, see Running with Special Privileges.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegSaveKeyW", ExactSpelling = true)]
        public static extern LSTATUS RegSaveKey([In] in HKEY hKey, [In] LPCWSTR lpFile, [In] in SECURITY_ATTRIBUTES lpSecurityAttributes);

        /// <summary>
        /// <para>
        /// Saves the specified key and all of its subkeys and values to a registry file, in the specified format.
        /// </para>
        /// <para>
        /// Applications that back up or restore system state including system files and registry hives
        /// should use the Volume Shadow Copy Service instead of the registry functions.
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// <para>
        /// A handle to an open registry key.
        /// </para>
        /// <para>
        /// This function does not support the <see cref="HKEY_CLASSES_ROOT"/> predefined key.
        /// </para>
        /// </param>
        /// <param name="lpFile">
        /// <para>
        /// The name of the file in which the specified key and subkeys are to be saved.
        /// If the file already exists, the function fails.
        /// </para>
        /// <para>
        /// The new file has the archive attribute.
        /// </para>
        /// <para>
        /// If the string does not include a path, the file is created in the current directory of the calling process for a local key,
        /// or in the %systemroot%\system32 directory for a remote key.
        /// </para>
        /// </param>
        /// <param name="lpSecurityAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that specifies a security descriptor for the new file.
        /// If <paramref name="lpSecurityAttributes"/> is <see cref="NullRef{SECURITY_ATTRIBUTES}"/>, the file gets a default security descriptor.
        /// The ACLs in a default security descriptor for a file are inherited from its parent directory.
        /// </param>
        /// <param name="Flags">
        /// <para>
        /// The format of the saved key or hive.
        /// This parameter can be one of the following values.
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
        /// <see cref="REG_STANDARD_FORMAT"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// The key or hive is saved in standard format.
        /// The standard format is the only format supported by Windows 2000.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="REG_LATEST_FORMAT"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// The key or hive is saved in the latest format.
        /// The latest format is supported starting with Windows XP.
        /// After the key or hive is saved in this format, it cannot be loaded on an earlier system.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="REG_NO_COMPRESSION"/>
        /// </para>
        /// <para>
        /// 4
        /// </para>
        /// </term>
        /// <term>
        /// The hive is saved with no compression, for faster save operations.
        /// The <paramref name="hKey"/> parameter must specify the root
        /// of a hive under <see cref="HKEY_LOCAL_MACHINE"/> or <see cref="HKEY_USERS"/>.
        /// For example, HKLM\SOFTWARE is the root of a hive.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function
        /// with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag to get a generic description of the error.
        /// </para>
        /// <para>
        /// If more than one of the possible values listed above for the <paramref name="Flags"/> parameter is specified
        /// in one call to this function—for example, if two or more values are OR'ed— or
        /// if <see cref="REG_NO_COMPRESSION"/> is specified and <paramref name="hKey"/> specifies a key that is not the root of a hive,
        /// this function returns <see cref="ERROR_INVALID_PARAMETER"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Unlike <see cref="RegSaveKey"/>, this function does not support the <see cref="HKEY_CLASSES_ROOT"/> predefined key.
        /// </para>
        /// <para>
        /// If <paramref name="hKey"/> represents a key on a remote computer,
        /// the path described by <paramref name="lpFile"/> is relative to the remote computer.
        /// </para>
        /// <para>
        /// The <see cref="RegSaveKeyEx"/> function saves only nonvolatile keys. It does not save volatile keys.
        /// A key is made volatile or nonvolatile at its creation; see <see cref="RegCreateKeyEx"/>.
        /// </para>
        /// <para>
        /// You can use the file created by <see cref="RegSaveKeyEx"/> in subsequent calls to the <see cref="RegLoadKey"/>,
        /// <see cref="RegReplaceKey"/>, or <see cref="RegRestoreKey"/> function.
        /// If <see cref="RegSaveKeyEx"/> fails partway through its operation,
        /// the file will be corrupt and subsequent calls to <see cref="RegLoadKey"/>,
        /// <see cref="RegReplaceKey"/>, or <see cref="RegRestoreKey"/> for the file will fail.
        /// </para>
        /// <para>
        /// Using <see cref="RegSaveKeyEx"/> together with <see cref="RegRestoreKey"/> to copy subtrees in the registry is not recommended.
        /// This method does not trigger notifications and can invalidate handles used by other applications.
        /// Instead, use the <see cref="SHCopyKey"/> function or the <see cref="RegCopyTree"/> function.
        /// </para>
        /// <para>
        /// The calling process must have the <see cref="SE_BACKUP_NAME"/> privilege enabled.
        /// For more information, see Running with Special Privileges.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegSaveKeyExW", ExactSpelling = true)]
        public static extern LSTATUS RegSaveKeyEx([In] in HKEY hKey, [In] LPCWSTR lpFile,
            [In] in SECURITY_ATTRIBUTES lpSecurityAttributes, [In] RegSaveKeyExFlags Flags);

        /// <summary>
        /// <para>
        /// The <see cref="RegSetKeySecurity"/> function sets the security of an open registry key.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regsetkeysecurity"/>
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
        /// <para>
        /// If the function succeeds, the function returns <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, it returns a nonzero error code defined in WinError.h.
        /// You can use the <see cref="FormatMessage"/> function
        /// with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag to get a generic description of the error.
        /// </para>
        /// </returns>
        /// <remarks>
        /// If <paramref name="hKey"/> is one of the predefined keys, use the <see cref="RegCloseKey"/> function to close the predefined key
        /// to ensure that the new security information is in effect the next time the predefined key is referenced.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegSetKeySecurity", ExactSpelling = true)]
        public static extern LSTATUS RegSetKeySecurity([In] HKEY hKey, [In] SECURITY_INFORMATION SecurityInformation,
            [In] PSECURITY_DESCRIPTOR pSecurityDescriptor);

        /// <summary>
        /// <para>
        /// Sets the data for the specified value in the specified registry key and subkey.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regsetkeyvaluew"/>
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// <para>
        /// A handle to an open registry key.
        /// The key must have been opened with the <see cref="KEY_SET_VALUE"/> access right.
        /// For more information, see Registry Key Security and Access Rights.
        /// </para>
        /// <para>
        /// This handle is returned by the <see cref="RegCreateKeyEx"/>, <see cref="RegCreateKeyTransacted"/>,
        /// <see cref="RegOpenKeyEx"/>, or <see cref="RegOpenKeyTransacted"/> function.
        /// It can also be one of the following predefined keys:
        /// </para>
        /// <para>
        /// <see cref="HKEY_CLASSES_ROOT"/> <see cref="HKEY_CURRENT_CONFIG"/> <see cref="HKEY_CURRENT_USER"/>
        /// <see cref="HKEY_LOCAL_MACHINE"/> <see cref="HKEY_USERS"/>
        /// </para>
        /// </param>
        /// <param name="lpSubKey">
        /// <para>
        /// The name of the subkey relative to the key identified by <paramref name="hKey"/>.
        /// If the subkey does not exist, it is created as a non-volatile key with a default security descriptor.
        /// If this parameter is <see cref="NULL"/>, then the value is created in the key specified by <paramref name="hKey"/>.
        /// </para>
        /// </param>
        /// <param name="lpValueName">
        /// The name of the registry value whose data is to be updated.
        /// </param>
        /// <param name="dwType">
        /// The type of data pointed to by the <paramref name="lpData"/> parameter.
        /// For a list of the possible types, see Registry Value Types.
        /// </param>
        /// <param name="lpData">
        /// <para>
        /// The data to be stored with the specified value name.
        /// </para>
        /// <para>
        /// For string-based types, such as <see cref="REG_SZ"/>, the string must be null-terminated.
        /// With the <see cref="REG_MULTI_SZ"/> data type, the string must be terminated with two null characters.
        /// </para>
        /// </param>
        /// <param name="cbData">
        /// The size of the information pointed to by the <paramref name="lpData"/> parameter, in bytes.
        /// If the data is of type <see cref="REG_SZ"/>, <see cref="REG_EXPAND_SZ"/>, or <see cref="REG_MULTI_SZ"/>,
        /// <paramref name="cbData"/> must include the size of the terminating null character or characters.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function
        /// with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag to get a generic description of the error.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegSetKeyValueW", ExactSpelling = true)]
        public static extern LSTATUS RegSetKeyValue([In] HKEY hKey, [In] LPCWSTR lpSubKey, [In] LPCWSTR lpValueName,
            [In] RegistryValueTypes dwType, [In] LPCVOID lpData, [In] DWORD cbData);

        /// <summary>
        /// <para>
        /// Sets the data for the default or unnamed value of a specified registry key.
        /// The data must be a text string.
        /// </para>
        /// <para>
        /// Note  This function is provided only for compatibility with 16-bit versions of Windows.
        /// Applications should use the <see cref="RegSetValueEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regsetvaluew"/>
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// <para>
        /// A handle to an open registry key. The key must have been opened with the <see cref="KEY_SET_VALUE"/> access right.
        /// For more information, see Registry Key Security and Access Rights.
        /// </para>
        /// <para>
        /// This handle is returned by the <see cref="RegCreateKeyEx"/>, <see cref="RegCreateKeyTransacted"/>,
        /// <see cref="RegOpenKeyEx"/>, or <see cref="RegOpenKeyTransacted"/> function.
        /// It can also be one of the following predefined keys:
        /// </para>
        /// <para>
        /// <see cref="HKEY_CLASSES_ROOT"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_CONFIG"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_USER"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_LOCAL_MACHINE"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_USERS"/>
        /// </para>
        /// </param>
        /// <param name="lpSubKey">
        /// <para>
        /// The name of a subkey of the <paramref name="hKey"/> parameter.
        /// The function sets the default value of the specified subkey.
        /// If <paramref name="lpSubKey"/> does not exist, the function creates it.
        /// </para>
        /// <para>
        /// Key names are not case sensitive.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NULL"/> or points to an empty string,
        /// the function sets the default value of the key identified by <paramref name="hKey"/>.
        /// </para>
        /// <para>
        /// For more information, see Registry Element Size Limits.
        /// </para>
        /// </param>
        /// <param name="dwType">
        /// The type of information to be stored.
        /// This parameter must be the <see cref="REG_SZ"/> type.
        /// To store other data types, use the <see cref="RegSetValueEx"/> function.
        /// </param>
        /// <param name="lpData">
        /// The data to be stored.
        /// This parameter cannot be <see cref="NULL"/>.
        /// </param>
        /// <param name="cbData">
        /// This parameter is ignored.
        /// The function calculates this value based on the size of the data in the <paramref name="lpData"/> parameter.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function
        /// with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag to get a generic description of the error.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the key specified by the <paramref name="lpSubKey"/> parameter does not exist,
        /// the <see cref="RegSetValue"/> function creates it.
        /// </para>
        /// <para>
        /// If the ANSI version of this function is used
        /// (either by explicitly calling RegSetValueA or by not defining UNICODE before including the Windows.h file),
        /// the <paramref name="lpData"/> parameter must be an ANSI character string.
        /// The string is converted to Unicode before it is stored in the registry.
        /// </para>
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit versions of Windows." +
            "Applications should use the RegSetValueEx function.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegSetValueW", ExactSpelling = true)]
        public static extern LSTATUS RegSetValue([In] HKEY hKey, [In] LPCWSTR lpSubKey, [In] RegistryValueTypes dwType, [In] LPCWSTR lpData, [In] DWORD cbData);

        /// <summary>
        /// <para>
        /// Sets the data and type of a specified value under a registry key.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regsetvalueexw"/>
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// <para>
        /// A handle to an open registry key.
        /// The key must have been opened with the <see cref="KEY_SET_VALUE"/> access right.
        /// For more information, see Registry Key Security and Access Rights.
        /// </para>
        /// <para>
        /// This handle is returned by the <see cref="RegCreateKeyEx"/>, <see cref="RegCreateKeyTransacted"/>,
        /// <see cref="RegOpenKeyEx"/>, or <see cref="RegOpenKeyTransacted"/> function.
        /// It can also be one of the following predefined keys:
        /// </para>
        /// <para>
        /// <see cref="HKEY_CLASSES_ROOT"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_CONFIG"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_CURRENT_USER"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_LOCAL_MACHINE"/>
        /// </para>
        /// <para>
        /// <see cref="HKEY_USERS"/>The Unicode version of this function supports the following additional predefined keys:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="HKEY_PERFORMANCE_TEXT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="HKEY_PERFORMANCE_NLSTEXT"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpValueName">
        /// <para>
        /// The name of the value to be set.
        /// If a value with this name is not already present in the key, the function adds it to the key.
        /// </para>
        /// <para>
        /// If lpValueName is <see cref="NULL"/> or an empty string, "",
        /// the function sets the type and data for the key's unnamed or default value.
        /// </para>
        /// <para>
        /// For more information, see Registry Element Size Limits.
        /// </para>
        /// <para>
        /// Registry keys do not have default values, but they can have one unnamed value, which can be of any type.
        /// </para>
        /// </param>
        /// <param name="Reserved">
        /// This parameter is reserved and must be zero.
        /// </param>
        /// <param name="dwType">
        /// The type of data pointed to by the <paramref name="lpData"/> parameter.
        /// For a list of the possible types, see Registry Value Types.
        /// </param>
        /// <param name="lpData">
        /// <para>
        /// The data to be stored.
        /// </para>
        /// <para>
        /// For string-based types, such as <see cref="REG_SZ"/>, the string must be null-terminated.
        /// With the <see cref="REG_MULTI_SZ"/> data type, the string must be terminated with two null characters.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// <paramref name="lpData"/> indicating a null value is valid,
        /// however, if this is the case, <paramref name="cbData"/> must be set to '0'.
        /// </para>
        /// </param>
        /// <param name="cbData">
        /// The size of the information pointed to by the <paramref name="lpData"/> parameter, in bytes.
        /// If the data is of type <see cref="REG_SZ"/>, <see cref="REG_EXPAND_SZ"/>, or <see cref="REG_MULTI_SZ"/>,
        /// <paramref name="cbData"/> must include the size of the terminating null character or characters.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function
        /// with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag to get a generic description of the error.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Value sizes are limited by available memory.
        /// However, storing large values in the registry can affect its performance.
        /// Long values (more than 2,048 bytes) should be stored as files, with the locations of the files stored in the registry.
        /// </para>
        /// <para>
        /// Application elements such as icons, bitmaps, and executable files should be stored as files and not be placed in the registry.
        /// </para>
        /// <para>
        /// If <paramref name="dwType"/> is the <see cref="REG_SZ"/>, <see cref="REG_MULTI_SZ"/>,
        /// or <see cref="REG_EXPAND_SZ"/> type and the ANSI version of this function is used
        /// (either by explicitly calling RegSetValueExA or by not defining UNICODE before including the Windows.h file),
        /// the data pointed to by the <paramref name="lpData"/> parameter must be an ANSI character string.
        /// The string is converted to Unicode before it is stored in the registry.
        /// </para>
        /// <para>
        /// Note that operations that access certain registry keys are redirected.
        /// For more information, see Registry Virtualization and 32-bit and 64-bit Application Data in the Registry.
        /// </para>
        /// <para>
        /// Consider using the <see cref="RegSetKeyValue"/> function, which provides a more convenient way to set the value of a registry key.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegSetValueExW", ExactSpelling = true)]
        public static extern LSTATUS RegSetValueEx([In] HKEY hKey, [In] LPWSTR lpValueName,
            [In] DWORD Reserved, [In] RegistryValueTypes dwType, [In] IntPtr lpData, [In] DWORD cbData);

        /// <summary>
        /// <para>
        /// Unloads the specified registry key and its subkeys from the registry.
        /// </para>
        /// <para>
        /// Applications that back up or restore system state including system files and registry hives
        /// should use the Volume Shadow Copy Service instead of the registry functions.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regunloadkeyw"/>
        /// </para>
        /// </summary>
        /// <param name="hKey">
        /// <para>
        /// A handle to the registry key to be unloaded.
        /// This parameter can be a handle returned by a call to <see cref="RegConnectRegistry"/> function
        /// or one of the following predefined handles:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="HKEY_LOCAL_MACHINE"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="HKEY_USERS"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpSubKey">
        /// <para>
        /// The name of the subkey to be unloaded.
        /// The key referred to by the <paramref name="lpSubKey"/> parameter must have been created by using the <see cref="RegLoadKey"/> function.
        /// </para>
        /// <para>
        /// Key names are not case sensitive.
        /// </para>
        /// <para>
        /// For more information, see Registry Element Size Limits.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is a nonzero error code defined in Winerror.h.
        /// You can use the <see cref="FormatMessage"/> function
        /// with the <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/> flag to get a generic description of the error.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function removes a hive from the registry but does not modify the file containing the registry information.
        /// A hive is a discrete body of keys, subkeys, and values that is rooted at the top of the registry hierarchy.
        /// </para>
        /// <para>
        /// The calling process must have the <see cref="SE_RESTORE_NAME"/>
        /// and <see cref="SE_BACKUP_NAME"/> privileges on the computer in which the registry resides.
        /// For more information, see Running with Special Privileges.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegUnLoadKeyW", ExactSpelling = true)]
        public static extern LSTATUS RegUnLoadKey([In] in HKEY hKey, [In] LPCWSTR lpSubKey);
    }
}
