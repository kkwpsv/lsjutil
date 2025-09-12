using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.WLAN_INTF_OPCODE;
using static Lsj.Util.Win32.Enums.WlanAccessRights;
using static Lsj.Util.Win32.Enums.WlanProfileFlags;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Wlanapi.dll
    /// </summary>
    public static class Wlanapi
    {
        /// <summary>
        /// <para>
        /// The <see cref="WlanCloseHandle"/> function closes a connection to the server.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlanclosehandle"/>
        /// </para>
        /// </summary>
        /// <param name="hClientHandle">
        /// The client's session handle, which identifies the connection to be closed.
        /// This handle was obtained by a previous call to the <see cref="WlanOpenHandle"/> function.
        /// </param>
        /// <param name="pReserved">
        /// Reserved for future use. Set this parameter to <see cref="NULL"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is ERROR_SUCCESS.
        /// </para>
        /// <para>
        /// If the function fails, the return value may be one of the following return codes.
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
        /// <see cref="ERROR_INVALID_PARAMETER"/>
        /// </term>
        /// <term>
        /// <paramref name="hClientHandle"/> is <see cref="NULL"/> or invalid, or <paramref name="pReserved"/> is not <see cref="NULL"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_HANDLE"/>
        /// </term>
        /// <term>
        /// The handle <paramref name="hClientHandle"/> was not found in the handle table.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RPC_STATUS"/>
        /// </term>
        /// <term>
        /// Various error codes.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// After a connection has been closed, any attempted use of the closed handle can cause unexpected errors.
        /// Upon closing, all outstanding notifications are discarded.
        /// </para>
        /// <para>
        /// Do not call <see cref="WlanCloseHandle"/> from a callback function.
        /// If the client is in the middle of a notification callback when <see cref="WlanCloseHandle"/> is called,
        /// the function waits for the callback to finish before returning a value.
        /// Calling this function inside a callback function will result in the call never completing.
        /// If both the callback function and the thread that closes the handle try to acquire the same lock, a deadlock may occur.
        /// In addition, do not call <see cref="WlanCloseHandle"/> from the DllMain function in an application DLL.
        /// This could also cause a deadlock.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP, Note = "Windows XP with SP3")]
        [DllImport("Wlanapi.dll", CharSet = CharSet.Unicode, EntryPoint = "WlanCloseHandle", ExactSpelling = true)]
        public static extern SystemErrorCodes WlanCloseHandle([In] HANDLE hClientHandle, [In] PVOID pReserved);

        /// <summary>
        /// <para>
        /// The <see cref="WlanEnumInterfaces"/> function enumerates all of the wireless LAN interfaces currently enabled on the local computer.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlanenuminterfaces"/>
        /// </para>
        /// </summary>
        /// <param name="hClientHandle">
        /// The client's session handle, obtained by a previous call to the <see cref="WlanOpenHandle"/> function.
        /// </param>
        /// <param name="pReserved">
        /// Reserved for future use.
        /// This parameter must be set to <see cref="NULL"/>.
        /// </param>
        /// <param name="ppInterfaceList">
        /// <para>
        /// A pointer to storage for a pointer to receive the returned list of wireless LAN interfaces in a <see cref="WLAN_INTERFACE_INFO_LIST"/> structure.
        /// </para>
        /// <para>
        /// The buffer for the <see cref="WLAN_INTERFACE_INFO_LIST"/> returned is allocated by the <see cref="WlanEnumInterfaces"/> function if the call succeeds.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value may be one of the following return codes.
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
        /// <see cref="ERROR_INVALID_PARAMETER"/>
        /// </term>
        /// <term>
        /// A parameter is incorrect.
        /// This error is returned if the <paramref name="hClientHandle"/> or <paramref name="ppInterfaceList"/> parameter is <see cref="NULL"/>.
        /// This error is returned if the <paramref name="pReserved"/> is not <see cref="NULL"/>.
        /// This error is also returned if the <paramref name="hClientHandle"/> parameter is not valid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_HANDLE"/>
        /// </term>
        /// <term>
        /// The handle <paramref name="hClientHandle"/> was not found in the handle table.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RPC_STATUS"/>
        /// </term>
        /// <term>
        /// Various error codes.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_NOT_ENOUGH_MEMORY"/>
        /// </term>
        /// <term>
        /// Not enough memory is available to process this request and allocate memory for the query results.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// The <see cref="WlanEnumInterfaces"/> function allocates memory for the list of returned interfaces
        /// that is returned in the buffer pointed to by the <paramref name="ppInterfaceList"/> parameter when the function succeeds.
        /// The memory used for the buffer pointed to by <paramref name="ppInterfaceList"/> parameter should be released
        /// by calling the <see cref="WlanFreeMemory"/> function after the buffer is no longer needed.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP, Note = "Windows XP with SP3")]
        [DllImport("Wlanapi.dll", CharSet = CharSet.Unicode, EntryPoint = "WlanEnumInterfaces", ExactSpelling = true)]
        public static extern SystemErrorCodes WlanEnumInterfaces([In] HANDLE hClientHandle, [In] PVOID pReserved, [Out] out P<WLAN_INTERFACE_INFO_LIST> ppInterfaceList);

        /// <summary>
        /// <para>
        /// The <see cref="WlanFreeMemory"/> function frees memory.
        /// Any memory returned from Native Wifi functions must be freed.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlanfreememory"/>
        /// </para>
        /// </summary>
        /// <param name="pMemory">
        /// Pointer to the memory to be freed.
        /// </param>
        /// <remarks>
        /// <para>
        /// If <paramref name="pMemory"/> points to memory that has already been freed, an access violation or heap corruption may occur.
        /// </para>
        /// <para>
        /// There is a hotfix available for Wireless LAN API for Windows XP with Service Pack 2 (SP2) that can help improve the performance of applications
        /// that call <see cref="WlanFreeMemory"/> and <see cref="WlanGetAvailableNetworkList"/> many times.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP, Note = "Windows XP with SP3")]
        [DllImport("Wlanapi.dll", CharSet = CharSet.Unicode, EntryPoint = "WlanFreeMemory", ExactSpelling = true)]
        public static extern void WlanFreeMemory([In] PVOID pMemory);

        /// <summary>
        /// <para>
        /// The <see cref="WlanGetProfile"/> function retrieves all information about a specified wireless profile.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlangetprofile"/>
        /// </para>
        /// </summary>
        /// <param name="hClientHandle">
        /// The client's session handle, obtained by a previous call to the <see cref="WlanOpenHandle"/> function.
        /// </param>
        /// <param name="pInterfaceGuid">
        /// <para>
        /// The GUID of the wireless interface.
        /// </para>
        /// <para>
        /// A list of the GUIDs for wireless interfaces on the local computer can be retrieved using the <see cref="WlanEnumInterfaces"/> function.
        /// </para>
        /// </param>
        /// <param name="strProfileName">
        /// <para>
        /// The name of the profile.
        /// Profile names are case-sensitive.
        /// This string must be NULL-terminated.
        /// The maximum length of the profile name is 255 characters.
        /// This means that the maximum length of this string, including the NULL terminator, is 256 characters.
        /// </para>
        /// <para>
        /// Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:
        /// The name of the profile is derived automatically from the SSID of the network.
        /// For infrastructure network profiles, the name of the profile is the SSID of the network.
        /// For ad hoc network profiles, the name of the profile is the SSID of the ad hoc network followed by <c>-adhoc</c>.
        /// </para>
        /// </param>
        /// <param name="pReserved">
        /// Reserved for future use.
        /// Must be set to <see cref="NULL"/>.
        /// </param>
        /// <param name="pstrProfileXml">
        /// A string that is the XML representation of the queried profile.
        /// There is no predefined maximum string length.
        /// </param>
        /// <param name="pdwFlags">
        /// <para>
        /// On input, a pointer to the address location used to provide additional information about the request. If this parameter is <see cref="NULL"/> on input, then no information on profile flags will be returned. On output, a pointer to the address location used to receive profile flags.
        /// </para>
        /// <para>
        /// Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:  Per-user profiles are not supported. Set this parameter to <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// The <paramref name="pdwFlags"/> parameter can point to an address location that contains the following values:
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
        /// <see cref="WLAN_PROFILE_GET_PLAINTEXT_KEY"/>
        /// </term>
        /// <term>
        /// <para>
        /// On input, this flag indicates that the caller wants to retrieve the plain text key from a wireless profile.
        /// If the calling thread has the required permissions, the <see cref="WlanGetProfile"/> function
        /// returns the plain text key in the keyMaterial element of the profile returned in the buffer pointed to by the <paramref name="pstrProfileXml"/> parameter.
        /// </para>
        /// <para>
        /// For the <see cref="WlanGetProfile"/> call to return the plain text key, the <see cref="wlan_secure_get_plaintext_key"/> permissions 
        /// from the <see cref="WLAN_SECURABLE_OBJECT"/> enumerated type must be set on the calling thread.
        /// The DACL must also contain an ACE that grants <see cref="WLAN_READ_ACCESS"/> permission to the access token of the calling thread.
        /// By default, the permissions for retrieving the plain text key is allowed only to the members of the Administrators group on a local machine.
        /// </para>
        /// <para>
        /// If the calling thread lacks the required permissions, the <see cref="WlanGetProfile"/> function returns the encrypted key
        /// in the keyMaterial element of the profile returned in the buffer pointed to by the <paramref name="pstrProfileXml"/> parameter.
        /// No error is returned if the calling thread lacks the required permissions.
        /// </para>
        /// <para>
        /// Windows 7:
        /// This flag passed on input is an extension to native wireless APIs added on Windows 7 and later.
        /// The <paramref name="pdwFlags"/> parameter is an __inout_opt parameter on Windows 7 and later.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WLAN_PROFILE_GROUP_POLICY"/>
        /// </term>
        /// <term>
        /// On output when the <see cref="WlanGetProfile"/> call is successful, this flag indicates that this profile was created by group policy.
        /// A group policy profile is read-only.
        /// Neither the content nor the preference order of the profile can be changed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WLAN_PROFILE_USER"/>
        /// </term>
        /// <term>
        /// On output when the <see cref="WlanGetProfile"/> call is successful,
        /// this flag indicates that the profile is a user profile for the specific user in whose context the calling thread resides.
        /// If not set, this profile is an all-user profile.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="pdwGrantedAccess">
        /// <para>
        /// The access mask of the all-user profile.
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
        /// <see cref="WLAN_READ_ACCESS"/>
        /// </term>
        /// <term>
        /// The user can view the contents of the profile.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WLAN_EXECUTE_ACCESS"/>
        /// </term>
        /// <term>
        /// The user has read access, and the user can also connect to and disconnect from a network using the profile.
        /// If a user has <see cref="WLAN_EXECUTE_ACCESS"/>, then the user also has <see cref="WLAN_READ_ACCESS"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WLAN_WRITE_ACCESS"/>
        /// </term>
        /// <term>
        /// The user has execute access and the user can also modify the content of the profile or delete the profile.
        /// If a user has <see cref="WLAN_WRITE_ACCESS"/>, then the user also has <see cref="WLAN_EXECUTE_ACCESS"/> and <see cref="WLAN_READ_ACCESS"/>.
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
        /// If the function fails, the return value may be one of the following return codes.
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
        /// <see cref="ERROR_ACCESS_DENIED"/>
        /// </term>
        /// <term>
        /// The caller does not have sufficient permissions.
        /// This error is returned if the <paramref name="pstrProfileXml"/> parameter specifies an all-user profile,
        /// but the caller does not have read access on the profile.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_HANDLE"/>
        /// </term>
        /// <term>
        /// A handle is invalid.
        /// This error is returned if the handle specified in the <paramref name="hClientHandle"/> parameter was not found in the handle table.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_PARAMETER"/>
        /// </term>
        /// <term>
        /// <para>
        /// A parameter is incorrect.
        /// This error is returned if any of the following conditions occur:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <paramref name="hClientHandle"/> is <see cref="NULL"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <paramref name="pInterfaceGuid"/> is <see cref="NULL"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <paramref name="pstrProfileXml"/> is <see cref="NULL"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <paramref name="pReserved"/> is not <see cref="NULL"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_NOT_ENOUGH_MEMORY"/>
        /// </term>
        /// <term>
        /// Not enough storage is available to process this command.
        /// This error is returned if the system was unable to allocate memory for the profile.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_NOT_FOUND"/>
        /// </term>
        /// <term>
        /// The profile specified by <paramref name="strProfileName"/> was not found.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Other
        /// </term>
        /// <term>
        /// Various RPC and other error codes. Use <see cref="FormatMessage"/> to obtain the message string for the returned error.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the <see cref="WlanGetProfile"/> function succeeds, the wireless profile is returned
        /// in the buffer pointed to by the <paramref name="pstrProfileXml"/> parameter.
        /// The buffer contains a string that is the XML representation of the queried profile.
        /// For a description of the XML representation of the wireless profile, see WLAN_profile Schema.
        /// </para>
        /// <para>
        /// The caller is responsible for calling the <see cref="WlanFreeMemory"/> function to free the memory allocated for the buffer
        /// pointer to by the <paramref name="pstrProfileXml"/> parameter when the buffer is no longer needed.
        /// </para>
        /// <para>
        /// If <paramref name="pstrProfileXml"/> specifies an all-user profile,
        /// the <see cref="WlanGetProfile"/> caller must have read access on the profile.
        /// Otherwise, the <see cref="WlanGetProfile"/> call will fail with a return value of <see cref="ERROR_ACCESS_DENIED"/>.
        /// The permissions on an all-user profile are established when the profile is created or saved
        /// using <see cref="WlanSetProfile"/> or <see cref="WlanSaveTemporaryProfile"/>.
        /// </para>
        /// <para>
        /// Windows 7:  
        /// </para>
        /// <para>
        /// The keyMaterial element returned in the profile schema pointed to by the <paramref name="pstrProfileXml"/> may be requested as plaintext
        /// if the <see cref="WlanGetProfile"/> function is called with the <see cref="WLAN_PROFILE_GET_PLAINTEXT_KEY"/> flag
        /// set in the value pointed to by the <paramref name="pdwFlags"/> parameter on input.
        /// </para>
        /// <para>
        /// For a WEP key, both 5 ASCII characters or 10 hexadecimal characters can be used to set the plaintext key when the profile is created or updated.
        /// However, a WEP profile will be saved with 10 hexadecimal characters in the key no matter what the original input was used to create the profile.
        /// So in the profile returned by the <see cref="WlanGetProfile"/> function, the plaintext WEP key is always returned as 10 hexadecimal characters.
        /// </para>
        /// <para>
        /// For the <see cref="WlanGetProfile"/> call to return the plain text key,
        /// the <see cref="wlan_secure_get_plaintext_key"/> permissions from the <see cref="WLAN_SECURABLE_OBJECT"/> enumerated type must be set on the calling thread.
        /// The DACL must also contain an ACE that grants <see cref="WLAN_READ_ACCESS"/> permission to the access token of the calling thread.
        /// By default, the permissions for retrieving the plain text key is allowed only to the members of the Administrators group on a local machine.
        /// </para>
        /// <para>
        /// If the calling thread lacks the required permissions, the <see cref="WlanGetProfile"/> function returns the encrypted key
        /// in the keyMaterial element of the profile returned in the buffer pointed to by the <paramref name="pstrProfileXml"/> parameter.
        /// No error is returned if the calling thread lacks the required permissions.
        /// </para>
        /// <para>
        /// By default, the keyMaterial element returned in the profile pointed to by the <paramref name="pstrProfileXml"/> is encrypted.
        /// If your process runs in the context of the LocalSystem account on the same computer,
        /// then you can unencrypt key material by calling the <see cref="CryptUnprotectData"/> function.
        /// </para>
        /// <para>
        /// Windows Server 2008 and Windows Vista:
        /// The keyMaterial element returned in the profile schema pointed to by the <paramref name="pstrProfileXml"/> is always encrypted.
        /// If your process runs in the context of the LocalSystem account,
        /// then you can unencrypt key material by calling the <see cref="CryptUnprotectData"/> function.
        /// </para>
        /// <para>
        /// Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:
        /// The key material is never encrypted.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP, Note = "Windows XP with SP3")]
        [DllImport("Wlanapi.dll", CharSet = CharSet.Unicode, EntryPoint = "WlanGetProfile", ExactSpelling = true)]
        public static extern SystemErrorCodes WlanGetProfile([In] HANDLE hClientHandle, [In] in GUID pInterfaceGuid, [In] LPCWSTR strProfileName,
            [In] PVOID pReserved, [Out] out StringHandle pstrProfileXml, [In][Out] ref WlanProfileFlags pdwFlags, [Out] out WlanAccessRights pdwGrantedAccess);

        /// <summary>
        /// <para>
        /// The <see cref="WlanOpenHandle"/> function opens a connection to the server.
        /// </para>
        /// <para>
        /// From: https://learn.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlanopenhandle
        /// </para>
        /// </summary>
        /// <param name="dwClientVersion">
        /// <para>
        /// The highest version of the WLAN API that the client supports.
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
        /// 1
        /// </term>
        /// <term>
        /// Client version for Windows XP with SP3 and Wireless LAN API for Windows XP with SP2.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 2
        /// </term>
        /// <term>
        /// Client version for Windows Vista and Windows Server 2008
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="pReserved">
        /// Reserved for future use. Must be set to <see cref="NULL"/>.
        /// </param>
        /// <param name="pdwNegotiatedVersion">
        /// The version of the WLAN API that will be used in this session.
        /// This value is usually the highest version supported by both the client and server.
        /// </param>
        /// <param name="phClientHandle">
        /// A handle for the client to use in this session. This handle is used by other functions throughout the session.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value may be one of the following return codes.
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
        /// <see cref="ERROR_INVALID_PARAMETER"/>
        /// </term>
        /// <term>
        /// <paramref name="pdwNegotiatedVersion"/> is <see cref="NULL"/>, <paramref name="phClientHandle"/> is <see cref="NULL"/>,
        /// or <paramref name="pReserved"/> is not <see cref="NULL"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_NOT_ENOUGH_MEMORY"/>
        /// </term>
        /// <term>
        /// Failed to allocate memory to create the client context.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RPC_STATUS"/>
        /// </term>
        /// <term>
        /// Various error codes.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_REMOTE_SESSION_LIMIT_EXCEEDED"/>
        /// </term>
        /// <term>
        /// Too many handles have been issued by the server.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The version number specified by <paramref name="dwClientVersion"/> and <paramref name="pdwNegotiatedVersion"/>
        /// is a composite version number made up of both major and minor versions.
        /// The major version is specified by the low-order word, and the minor version is specified by the high-order word.
        /// The macros <c>WLAN_API_VERSION_MAJOR(_v)</c> and <c>WLAN_API_VERSION_MINOR(_v)</c> return the major and minor version numbers respectively.
        /// You can construct a version number using the macro <c>WLAN_API_MAKE_VERSION(_major, _minor)</c>.
        /// </para>
        /// <para>
        /// Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:
        /// <see cref="WlanOpenHandle"/> will return an error message
        /// if the Wireless Zero Configuration (WZC) service has not been started or if the WZC service is not responsive.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP, Note = "Windows XP with SP3")]
        [DllImport("Wlanapi.dll", CharSet = CharSet.Unicode, EntryPoint = "WlanOpenHandle", ExactSpelling = true)]
        public static extern SystemErrorCodes WlanOpenHandle([In] DWORD dwClientVersion, [In] PVOID pReserved, [Out] out DWORD pdwNegotiatedVersion, [Out] out HANDLE phClientHandle);

        /// <summary>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Some information relates to pre-released product, which may be substantially modified before it's commercially released.
        /// Microsoft makes no warranties, express or implied, with respect to the information provided here.
        /// </para>
        /// <para>
        ///  Important
        /// </para>
        /// <para>
        /// This API will be affected by upcoming changes to operating system behavior, planned for fall 2024.
        /// For more info, see Changes to API behavior for Wi-Fi access and location.
        /// </para>
        /// <para>
        /// The <see cref="WlanQueryInterface"/> function queries various parameters of a specified interface.
        /// </para>
        /// <para>
        /// From: https://learn.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlanqueryinterface
        /// </para>
        /// </summary>
        /// <param name="hClientHandle">
        /// The client's session handle, obtained by a previous call to the <see cref="WlanOpenHandle"/> function.
        /// </param>
        /// <param name="pInterfaceGuid">
        /// The <see cref="GUID"/> of the interface to be queried.
        /// </param>
        /// <param name="OpCode">
        /// <para>
        /// A <see cref="WLAN_INTF_OPCODE"/> value that specifies the parameter to be queried.
        /// The following table lists the valid constants along with the data type of the parameter in <paramref name="ppData"/>.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// <see cref="WLAN_INTF_OPCODE"/>
        /// </term>
        /// <term>
        /// <paramref name="ppData"/> data type
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="wlan_intf_opcode_autoconf_enabled"/>
        /// </term>
        /// <term>
        /// <see cref="BOOL"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="wlan_intf_opcode_background_scan_enabled"/>
        /// </term>
        /// <term>
        /// <see cref="BOOL"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="wlan_intf_opcode_bss_type"/>
        /// </term>
        /// <term>
        /// <see cref="DOT11_BSS_TYPE"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="wlan_intf_opcode_certified_safe_mode"/>
        /// </term>
        /// <term>
        /// <see cref="BOOL"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="wlan_intf_opcode_channel_number"/>
        /// </term>
        /// <term>
        /// <see cref="ULONG"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="wlan_intf_opcode_current_connection"/>
        /// </term>
        /// <term>
        /// <see cref="WLAN_CONNECTION_ATTRIBUTES"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="wlan_intf_opcode_current_operation_mode"/>
        /// </term>
        /// <term>
        /// <see cref="ULONG"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="wlan_intf_opcode_hosted_network_capable"/>
        /// </term>
        /// <term>
        /// <see cref="BOOL"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="wlan_intf_opcode_interface_state"/>
        /// </term>
        /// <term>
        /// <see cref="WLAN_INTERFACE_STATE"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="wlan_intf_opcode_management_frame_protection_capable"/>
        /// </term>
        /// <term>
        /// <see cref="BOOL"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="wlan_intf_opcode_media_streaming_mode"/>
        /// </term>
        /// <term>
        /// <see cref="BOOL"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="wlan_intf_opcode_qos_info"/>
        /// </term>
        /// <term>
        /// <see cref="WLAN_QOS_INFO"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="wlan_intf_opcode_radio_state"/>
        /// </term>
        /// <term>
        /// <see cref="WLAN_RADIO_STATE"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="wlan_intf_opcode_realtime_connection_quality"/>
        /// </term>
        /// <term>
        /// <see cref="WLAN_REALTIME_CONNECTION_QUALITY"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="wlan_intf_opcode_rssi"/>
        /// </term>
        /// <term>
        /// <see cref="LONG"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="wlan_intf_opcode_secondary_sta_interfaces"/>
        /// </term>
        /// <term>
        /// <see cref="WLAN_INTERFACE_INFO_LIST"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="wlan_intf_opcode_secondary_sta_synchronized_connections"/>
        /// </term>
        /// <term>
        /// <see cref="BOOL"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="wlan_intf_opcode_statistics"/>
        /// </term>
        /// <term>
        /// <see cref="WLAN_STATISTICS"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="wlan_intf_opcode_supported_adhoc_auth_cipher_pairs"/>
        /// </term>
        /// <term>
        /// <see cref="WLAN_AUTH_CIPHER_PAIR_LIST"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="wlan_intf_opcode_supported_country_or_region_string_list"/>
        /// </term>
        /// <term>
        /// <see cref="WLAN_COUNTRY_OR_REGION_STRING_LIST"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="wlan_intf_opcode_supported_infrastructure_auth_cipher_pairs"/>
        /// </term>
        /// <term>
        /// <see cref="WLAN_AUTH_CIPHER_PAIR_LIST"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="wlan_intf_opcode_supported_safe_mode"/>
        /// </term>
        /// <term>
        /// <see cref="BOOL"/>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:
        /// Only the <see cref="wlan_intf_opcode_autoconf_enabled"/>, <see cref="wlan_intf_opcode_bss_type"/>,
        /// <see cref="wlan_intf_opcode_interface_state"/>, and <see cref="wlan_intf_opcode_current_connection"/> constants are valid.
        /// </para>
        /// </param>
        /// <param name="pReserved">
        /// Reserved for future use.
        /// Must be set to <see cref="NULL"/>.
        /// </param>
        /// <param name="pdwDataSize">
        /// The size of the <paramref name="ppData"/> parameter, in bytes.
        /// </param>
        /// <param name="ppData">
        /// <para>
        /// Pointer to the memory location that contains the queried value of the parameter specified by the <paramref name="OpCode"/> parameter.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// If <paramref name="OpCode"/> is set to <see cref="wlan_intf_opcode_autoconf_enabled"/>,
        /// <see cref="wlan_intf_opcode_background_scan_enabled"/>, or <see cref="wlan_intf_opcode_media_streaming_mode"/>,
        /// then the pointer referenced by <paramref name="ppData"/> may point to an integer value.
        /// If the pointer referenced by <paramref name="ppData"/> points to 0,
        /// then the integer value should be converted to the boolean value <see cref="FALSE"/>.
        /// If the pointer referenced by ppData points to a nonzero integer,
        /// then the integer value should be converted to the boolean value <see cref="TRUE"/>.
        /// </para>
        /// </param>
        /// <param name="pWlanOpcodeValueType">
        /// If passed a non-<see cref="NullRef{WLAN_OPCODE_VALUE_TYPE}"/> value,
        /// points to a <see cref="WLAN_OPCODE_VALUE_TYPE"/> value that specifies the type of opcode returned.
        /// This parameter may be <see cref="NullRef{WLAN_OPCODE_VALUE_TYPE}"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value may be one of the following return codes.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The caller is responsible for using <see cref="WlanFreeMemory"/> to free the memory allocated for <paramref name="ppData"/>.
        /// </para>
        /// <para>
        /// When <paramref name="OpCode"/> is set to <see cref="wlan_intf_opcode_current_operation_mode"/>,
        /// <see cref="WlanQueryInterface"/> queries the current operation mode of the wireless interface.
        /// For more information about operation modes, see Native 802.11 Operation Modes.
        /// Two operation modes are supported: <see cref="DOT11_OPERATION_MODE_EXTENSIBLE_STATION"/> and <see cref="DOT11_OPERATION_MODE_NETWORK_MONITOR"/>.
        /// The operation mode constants are defined in the header file Windot11.h.
        /// <paramref name="ppData"/> will point to one of these two values.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP, Note = "Windows XP with SP3")]
        [DllImport("Wlanapi.dll", CharSet = CharSet.Unicode, EntryPoint = "WlanQueryInterface", ExactSpelling = true)]
        public static extern SystemErrorCodes WlanQueryInterface([In] HANDLE hClientHandle, [In] in GUID pInterfaceGuid, [In] WLAN_INTF_OPCODE OpCode,
            [In] PVOID pReserved, [Out] out DWORD pdwDataSize, [Out] out PVOID ppData, [Out] out WLAN_OPCODE_VALUE_TYPE pWlanOpcodeValueType);
    }
}
