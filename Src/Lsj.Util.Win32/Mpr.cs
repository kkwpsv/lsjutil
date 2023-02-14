using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using System.Text;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Kernel32;

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
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnetwk/nf-winnetwk-wnetaddconnectionw"/>
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
        [DllImport("Mpr.dll", CharSet = CharSet.Unicode, EntryPoint = "WNetAddConnectionW", ExactSpelling = true, SetLastError = true)]
        public static extern SystemErrorCodes WNetAddConnection([MarshalAs(UnmanagedType.LPWStr)][In]string lpRemoteName,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpPassword, [MarshalAs(UnmanagedType.LPWStr)][In]string lpLocalName);

        /// <summary>
        /// <para>
        /// The <see cref="WNetCancelConnection"/> function cancels an existing network connection.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnetwk/nf-winnetwk-wnetcancelconnectionw"/>
        /// </para>
        /// </summary>
        /// <param name="lpName">
        /// Pointer to a constant null-terminated string that specifies the name of either the redirected local device
        /// or the remote network resource to disconnect from.
        /// When this parameter specifies a redirected local device, the function cancels only the specified device redirection.
        /// If the parameter specifies a remote network resource, only the connections to remote networks without devices are canceled.
        /// </param>
        /// <param name="fForce">
        /// Specifies whether or not the disconnection should occur if there are open files or jobs on the connection.
        /// If this parameter is <see cref="BOOL.FALSE"/>, the function fails if there are open files or jobs.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="NO_ERROR"/>.
        /// If the function fails, the return value is a system error code, such as one of the following values.
        /// <see cref="ERROR_BAD_PROFILE"/>: The user profile is in an incorrect format.
        /// <see cref="ERROR_CANNOT_OPEN_PROFILE"/>: The system is unable to open the user profile to process persistent connections.
        /// <see cref="ERROR_DEVICE_IN_USE"/>: The device is in use by an active process and cannot be disconnected.
        /// <see cref="ERROR_EXTENDED_ERROR"/>:
        /// A network-specific error occurred. To obtain a description of the error, call the <see cref="WNetGetLastError"/> function.
        /// <see cref="ERROR_NOT_CONNECTED"/>:
        /// The name specified by the <paramref name="lpName"/> parameter is not a redirected device, or the system is not currently connected
        /// to the device specified by the parameter.
        /// <see cref="ERROR_OPEN_FILES"/>:
        /// There are open files, and the <paramref name="fForce"/> parameter is <see cref="BOOL.FALSE"/>.
        /// </returns>
        /// <remarks>
        /// Windows Server 2003 and Windows XP:
        /// The WNet functions create and delete network drive letters in the MS-DOS device namespace associated with a logon session
        /// because MS-DOS devices are identified by AuthenticationID.
        /// (An AuthenticationID is the locally unique identifier, or LUID, associated with a logon session.)
        /// This can affect applications that call one of the WNet functions to create a network drive letter under one user logon,
        /// but query for existing network drive letters under a different user logon.
        /// An example of this situation could be when a user's second logon is created within a logon session, for example,
        /// by calling the <see cref="CreateProcessAsUser"/> function, and the second logon runs an application
        /// that calls the <see cref="GetLogicalDrives"/> function.
        /// <see cref="GetLogicalDrives"/> does not return network drive letters created by a WNet function under the first logon.
        /// Note that in the preceding example the first logon session still exists, and the example could apply to any logon session,
        /// including a Terminal Services session.
        /// For more information, see Defining an MS-DOS Device Name.
        /// </remarks>
        [Obsolete("The WNetCancelConnection function is provided for compatibility with 16-bit versions of Windows." +
            " Other Windows-based applications should call the WNetCancelConnection2 function.")]
        [DllImport("Mpr.dll", CharSet = CharSet.Unicode, EntryPoint = "WNetCancelConnectionW", ExactSpelling = true, SetLastError = true)]
        public static extern SystemErrorCodes WNetCancelConnection([MarshalAs(UnmanagedType.LPWStr)][In]string lpName, [In]BOOL fForce);

        /// <summary>
        /// <para>
        /// The <see cref="WNetGetConnection"/> function retrieves the name of the network resource associated with a local device.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnetwk/nf-winnetwk-wnetgetconnectionw"/>
        /// </para>
        /// </summary>
        /// <param name="lpLocalName">
        /// Pointer to a constant null-terminated string that specifies the name of the local device to get the network name for.
        /// </param>
        /// <param name="lpRemoteName">
        /// Pointer to a null-terminated string that receives the remote name used to make the connection.
        /// </param>
        /// <param name="lpnLength">
        /// Pointer to a variable that specifies the size of the buffer pointed to by the <paramref name="lpRemoteName"/> parameter, in characters.
        /// If the function fails because the buffer is not large enough, this parameter returns the required buffer size.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="NO_ERROR"/>.
        /// If the function fails, the return value is a system error code, such as one of the following values.
        /// <see cref="ERROR_BAD_DEVICE"/>: The string pointed to by the <paramref name="lpLocalName"/> parameter is invalid.
        /// <see cref="ERROR_NOT_CONNECTED"/>:
        /// The device specified by <paramref name="lpLocalName"/> is not a redirected device. For more information, see the following Remarks section.
        /// <see cref="ERROR_MORE_DATA"/>:
        /// The buffer is too small. The lpnLength parameter points to a variable that contains the required buffer size.
        /// More entries are available with subsequent calls.
        /// <see cref="ERROR_CONNECTION_UNAVAIL"/>:
        /// The device is not currently connected, but it is a persistent connection. For more information, see the following Remarks section.
        /// <see cref="ERROR_NO_NETWORK"/>: The network is unavailable.
        /// <see cref="ERROR_EXTENDED_ERROR"/>:
        /// A network-specific error occurred. To obtain a description of the error, call the <see cref="WNetGetLastError"/> function.
        /// <see cref="ERROR_NO_NET_OR_BAD_PATH"/>:
        /// None of the providers recognize the local name as having a connection.
        /// However, the network is not available for at least one provider to whom the connection may belong.
        /// </returns>
        /// <remarks>
        /// If the network connection was made using the Microsoft LAN Manager network, and the calling application is running in a different logon session
        /// than the application that made the connection, a call to the <see cref="WNetGetConnection"/> function for the associated local device will fail.
        /// The function fails with <see cref="ERROR_NOT_CONNECTED"/> or <see cref="ERROR_CONNECTION_UNAVAIL"/>.
        /// This is because a connection made using Microsoft LAN Manager is visible only to applications running in the same logon session
        /// as the application that made the connection.
        /// (To prevent the call to <see cref="WNetGetConnection"/> from failing it is not sufficient for the application to be running in the user account
        /// that created the connection.)
        /// Windows Server 2003 and Windows XP: 
        /// This function queries the MS-DOS device namespaces associated with a logon session because MS-DOS devices are identified by AuthenticationID.
        /// (An AuthenticationID is the locally unique identifier, or LUID, associated with a logon session.)
        /// This can affect applications that call one of the WNet functions to create a network drive letter under one user logon,
        /// but query for existing network drive letters under a different user logon.
        /// An example of this situation could be when a user's second logon is created within a logon session, for example,
        /// by calling the <see cref="CreateProcessAsUser"/> function, and the second logon runs an application
        /// that calls the <see cref="GetLogicalDrives"/> function.
        /// <see cref="GetLogicalDrives"/> does not return network drive letters created by a WNet function under the first logon.
        /// Note that in the preceding example the first logon session still exists, and the example could apply to any logon session,
        /// including a Terminal Services session.
        /// For more information, see Defining an MS-DOS Device Name.
        /// </remarks>
        [DllImport("Mpr.dll", CharSet = CharSet.Unicode, EntryPoint = "WNetGetConnectionW", ExactSpelling = true, SetLastError = true)]
        public static extern SystemErrorCodes WNetGetConnection([MarshalAs(UnmanagedType.LPWStr)][In]string lpLocalName,
            [In] IntPtr lpRemoteName, [In][Out]ref DWORD lpnLength);
    }
}
