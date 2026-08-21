using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.BaseTypes.VARIANT_BOOL;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.ComInterfaces
{
#pragma warning disable IDE1006
    /// <summary>
    /// <para>
    /// The <see cref="INetworkListManager"/> interface provides a set of methods to perform network list management functions.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/netlistmgr/nn-netlistmgr-inetworklistmanager"/>
    /// </para>
    /// </summary>
    public unsafe struct INetworkListManager
    {
        nint* _vTable;

        /// <summary>
        /// The <see cref="GetNetworks"/> method retrieves the list of networks available on the local machine.
        /// </summary>
        /// <param name="Flags">
        /// <see cref="NLM_ENUM_NETWORK"/> enumeration value that specifies the flags for the network (specifically, connected or not connected).
        /// </param>
        /// <param name="ppEnumNetwork">
        /// Pointer to a pointer that receives an <see cref="IEnumNetworks"/> interface instance that contains the enumerator for the list of available networks.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if the method succeeds.
        /// Otherwise, the method returns one of the following values.
        /// <see cref="E_POINTER"/>: The pointer passed is <see cref="NULL"/>.
        /// <see cref="E_UNEXPECTED"/>: The GUID is invalid.
        /// </returns>
        public HRESULT GetNetworks([In] NLM_ENUM_NETWORK Flags, [Out] out P<IEnumNetworks> ppEnumNetwork)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, NLM_ENUM_NETWORK, out P<IEnumNetworks>, HRESULT>)_vTable[7])(thisPtr, Flags, out ppEnumNetwork);
            }
        }

        /// <summary>
        /// The <see cref="GetNetwork"/> method retrieves a network based on a supplied network ID.
        /// </summary>
        /// <param name="gdNetworkId">
        /// GUID that specifies the network ID.
        /// </param>
        /// <param name="ppNetwork">
        /// Pointer to a pointer that receives the <see cref="INetwork"/> interface instance for this network.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if the method succeeds.
        /// Otherwise, the method returns one of the following values.
        /// <see cref="E_POINTER"/>: The pointer passed is <see cref="NULL"/>.
        /// <see cref="E_UNEXPECTED"/>: The GUID is invalid.
        /// </returns>
        public HRESULT GetNetwork([In] GUID gdNetworkId, [Out] out P<INetwork> ppNetwork)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, GUID, out P<INetwork>, HRESULT>)_vTable[8])(thisPtr, gdNetworkId, out ppNetwork);
            }
        }

        /// <summary>
        /// The <see cref="GetNetworkConnections"/> method enumerates a complete list of the network connections that have been made.
        /// </summary>
        /// <param name="ppEnum">
        /// Pointer to a pointer that receives an <see cref="IEnumNetworkConnections"/> interface instance
        /// that enumerates all network connections on the machine.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if the method succeeds.
        /// Otherwise, the method returns one of the following values.
        /// <see cref="E_POINTER"/>: The pointer passed is <see cref="NULL"/>.
        /// </returns>
        public HRESULT GetNetworkConnections([Out] out P<IEnumNetworkConnections> ppEnum)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IEnumNetworkConnections>, HRESULT>)_vTable[9])(thisPtr, out ppEnum);
            }
        }

        /// <summary>
        /// The <see cref="GetNetworkConnection"/> method retrieves a network based on a supplied Network Connection ID.
        /// </summary>
        /// <param name="gdNetworkConnectionId">
        /// A <see cref="GUID"/> that specifies the Network Connection ID.
        /// </param>
        /// <param name="ppNetworkConnection">
        /// Pointer to a pointer to the <see cref="INetworkConnection"/> object
        /// associated with the supplied <paramref name="gdNetworkConnectionId"/>.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if the method succeeds.
        /// Otherwise, the method returns one of the following values.
        /// <see cref="S_FALSE"/>: The network associated with the specified network connection ID was not found.
        /// <see cref="E_POINTER"/>: The pointer passed is <see cref="NULL"/>.
        /// <see cref="E_UNEXPECTED"/>: The specified GUID is invalid.
        /// </returns>
        /// <remarks>
        /// This method can return <see cref="S_FALSE"/> if a network connection associated with the specified ID has been removed.
        /// For example, it is possible for a client to receive a <see cref="INetworkConnectionEvents.NetworkConnectionConnectivityChanged"/> event
        /// along with a network connection ID, but find that the network connection has been disconnected
        /// or even replaced by the time <see cref="INetworkListManager.GetNetworkConnection"/> is called with the provided ID.
        /// </remarks>
        public HRESULT GetNetworkConnection([In] GUID gdNetworkConnectionId, [Out] out P<INetworkConnection> ppNetworkConnection)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, GUID, out P<INetworkConnection>, HRESULT>)_vTable[10])(thisPtr, gdNetworkConnectionId, out ppNetworkConnection);
            }
        }

        /// <summary>
        /// The <see cref="get_IsConnectedToInternet"/> property specifies if the local machine has internet connectivity.
        /// </summary>
        /// <param name="pbIsConnected">
        /// If <see cref="TRUE"/>, the local machine is connected to the internet;
        /// if <see cref="FALSE"/>, it is not.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful.
        /// </returns>
        public HRESULT get_IsConnectedToInternet([Out] out VARIANT_BOOL pbIsConnected)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out VARIANT_BOOL, HRESULT>)_vTable[11])(thisPtr, out pbIsConnected);
            }
        }

        /// <summary>
        /// The get_IsConnected property specifies if the local machine has network connectivity.
        /// </summary>
        /// <param name="pbIsConnected">
        /// If <see cref="TRUE"/>, the network has at least local connectivity via ipv4 or ipv6 or both.
        /// The network may also have internet connectivity.
        /// Thus, the network is connected.
        /// If <see cref="FALSE"/>, the network does not have local or internet connectivity.
        /// The network is not connected.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful.
        /// </returns>
        public HRESULT get_IsConnected([Out] out VARIANT_BOOL pbIsConnected)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out VARIANT_BOOL, HRESULT>)_vTable[12])(thisPtr, out pbIsConnected);
            }
        }

        /// <summary>
        /// The <see cref="GetConnectivity"/> method returns the overall connectivity state of the machine.
        /// </summary>
        /// <param name="pConnectivity">
        /// Pointer to an <see cref="NLM_CONNECTIVITY"/> enumeration value that contains a bitmask
        /// that specifies the network connectivity of this machine.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if the method succeeds.
        /// </returns>
        public HRESULT GetConnectivity([Out] out NLM_CONNECTIVITY pConnectivity)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out NLM_CONNECTIVITY, HRESULT>)_vTable[13])(thisPtr, out pConnectivity);
            }
        }

        /// <summary>
        /// The <see cref="SetSimulatedProfileInfo"/> method applies a specific set of connection profile values to the internet connection profile
        /// in support of the simulation of specific metered internet connection conditions.
        /// The simulation only applies in an RDP Child Session and does not affect the primary user session.
        /// The simulated internet connection profile is returned via the Windows Runtime API <see cref="NetworkInformation.GetInternetConnectionProfile"/>.
        /// </summary>
        /// <param name="pSimulatedInfo">
        /// Specific connection profile values to simulate on the current internet connection profile
        /// when calling <see cref="NetworkInformation.GetInternetConnectionProfile"/> from an RDP Child Session
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> on success.
        /// </returns>
        public HRESULT SetSimulatedProfileInfo([In] in NLM_SIMULATED_PROFILE_INFO pSimulatedInfo)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in NLM_SIMULATED_PROFILE_INFO, HRESULT>)_vTable[14])(thisPtr, pSimulatedInfo);
            }
        }

        /// <summary>
        /// Clears the connection profile values previously applied to the internet connection profile by <see cref="SetSimulatedProfileInfo"/>.
        /// The next internet connection query, via <see cref="NetworkInformation.GetInternetConnectionProfile"/>, will use system information.
        /// </summary>
        /// <returns>
        /// Returns <see cref="S_OK"/> on success.
        /// </returns>
        public HRESULT ClearSimulatedProfileInfo()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[15])(thisPtr);
            }
        }
    }
}
#pragma warning restore IDE1006
