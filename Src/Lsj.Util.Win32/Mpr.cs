using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Mpr.dll
    /// </summary>
    public static class Mpr
    {
        /// <summary>
        /// <para>
        /// The <see cref="WNetAddConnection"/> function enables the calling application to connect a local device to a network resource.
        /// A successful connection is persistent, meaning that the system automatically restores the connection during subsequent logon operations.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winnetwk/nf-winnetwk-wnetaddconnectionw
        /// </para>
        /// </summary>
        /// <param name="lpRemoteName">
        /// A pointer to a constant null-terminated string that specifies the network resource to connect to.
        /// </param>
        /// <param name="lpPassword">
        /// A pointer to a constant null-terminated string that specifies the password to be used to make a connection.
        /// This parameter is usually the password associated with the current user.
        /// If this parameter is <see langword="null"/>, the default password is used.
        /// If the string is empty, no password is used.
        /// Windows Me/98/95: This parameter must be <see langword="null"/> or an empty string.
        /// </param>
        /// <param name="lpLocalName">
        /// A pointer to a constant null-terminated string that specifies the name of a local device to be redirected, such as "F:" or "LPT1".
        /// The string is treated in a case-insensitive manner.
        /// If the string is <see langword="null"/>, a connection to the network resource is made without redirecting the local device.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is NO_ERROR.
        /// If the function fails, the return value is a system error code, such as one of the following values.
        /// <see cref="ERROR_ACCESS_DENIED"/>: The caller does not have access to the network resource.
        /// <see cref="ERROR_ALREADY_ASSIGNED"/>: The device specified in the lpLocalName parameter is already connected.
        /// <see cref="ERROR_BAD_DEV_TYPE"/>: The device type and the resource type do not match.
        /// <see cref="ERROR_BAD_DEVICE"/>: The value specified in the <paramref name="lpLocalName"/> parameter is invalid.
        /// <see cref="ERROR_BAD_NET_NAME"/>: The value specified in the <paramref name="lpRemoteName"/> parameter is not valid or cannot be located.
        /// <see cref="ERROR_BAD_PROFILE"/>: The user profile is in an incorrect format.
        /// <see cref="ERROR_CANNOT_OPEN_PROFILE"/>: The system is unable to open the user profile to process persistent connections.
        /// <see cref="ERROR_DEVICE_ALREADY_REMEMBERED"/>:
        /// An entry for the device specified in the <paramref name="lpLocalName"/> parameter is already in the user profile.
        /// <see cref="ERROR_EXTENDED_ERROR"/>:
        /// A network-specific error occurred. To obtain a description of the error, call the <see cref="WNetGetLastError"/> function.
        /// <see cref="ERROR_INVALID_PASSWORD"/>: The specified password is invalid.
        /// <see cref="ERROR_NO_NET_OR_BAD_PATH"/>:
        /// The operation cannot be performed because a network component is not started or because a specified name cannot be used.
        /// <see cref="ERROR_NO_NETWORK"/>: The network is unavailable.
        /// </returns>
        /// <remarks>
        /// On Windows Server 2003 and Windows XP, the WNet functions create and delete network drive letters in the MS-DOS device namespace
        /// associated with a logon session because MS-DOS devices are identified by AuthenticationID (a locally unique identifier, or LUID,
        /// associated with a logon session.)
        /// This can affect applications that call one of the WNet functions to create a network drive letter under one user logon,
        /// but query for existing network drive letters under a different user logon.
        /// An example of this situation could be when a user's second logon is created within a logon session, for example,
        /// by calling the <see cref="CreateProcessAsUser"/> function, and the second logon runs an application
        /// that calls the <see cref="GetLogicalDrives"/> function.
        /// The call to the <see cref="GetLogicalDrives"/> function does not return network drive letters created by WNet function calls under the first logon.
        /// Note that in the preceding example the first logon session still exists, and the example could apply to any logon session,
        /// including a Terminal Services session.
        /// For more information, see Defining an MS-DOS Device Name.
        /// On Windows Server 2003 and Windows XP, if a service that runs as LocalSystem calls the <see cref="WNetAddConnection"/> function,
        /// then the mapped drive is visible to all user logon sessions.
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit versions of Windows." +
            " Other Windows-based applications should call the WNetAddConnection2 or the WNetAddConnection3 function.")]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "WNetAddConnectionW", SetLastError = true)]
        public static extern SystemErrorCodes WNetAddConnection([MarshalAs(UnmanagedType.LPWStr)][In]string lpRemoteName,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpPassword, [MarshalAs(UnmanagedType.LPWStr)][In]string lpLocalName);
    }
}
