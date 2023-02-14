using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.VARENUM;
using FILETIME = Lsj.Util.Win32.Structs.FILETIME;
using static Lsj.Util.Win32.OleAut32;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The <see cref="INetwork"/> interface represents a network on the local machine.
    /// It can also represent a collection of network connections with a similar network signature.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/netlistmgr/nn-netlistmgr-inetwork"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The COM Object that implements <see cref="INetwork"/> also implements a property bag for additional properties.
    /// To get access to this property bag you can use the <see cref="INetwork"/> interface and <see cref="IUnknown.QueryInterface"/> for <see cref="IPropertyBag"/>.
    /// The property bag on this COM Object contains the following properties:
    /// <see cref="NA_DomainAuthenticationFailed"/>
    /// <see cref="VT_BOOL"/>
    /// Specifies that a domain network is not able to authenticate against the domain controller.
    /// <see cref="NA_NetworkClass"/>
    /// <see cref="NLM_NETWORK_CLASS"/> value stored as <see cref="VT_UINT"/>
    /// Specifies the class of network. Possible values include:
    /// <see cref="NLM_NETWORK_IDENTIFYING"/>(0x01)
    /// This is the special "Identifying" network. No properties on this network class can be changed.
    /// <see cref="NLM_NETWORK_IDENTIFIED"/> (0x02)
    /// This is an Identified network.
    /// <see cref="NLM_NETWORK_UNIDENTIFIED"/> (0x03)
    /// This is the special "Unidentified" network. The category of this network can be changed, but it will not persist when the network is disconnected.
    /// <see cref="NA_InternetConnectivityV4"/> or <see cref="NA_InternetConnectivityV6"/>
    /// <see cref="NLM_INTERNET_CONNECTIVITY"/> value stored as <see cref="VT_UINT"/>
    /// Provides details regarding IPv4 or IPv6 network connectivity. Possible values include:
    /// <see cref="LM_INTERNET_CONNECTIVITY_WEBHIJACK"/>(0x1)
    /// The detected network is a hotspot.
    /// For example, when connected to a coffee Wi-Fi hotspot network and the local HTTP traffic is being redirected to a captive portal, this flag will be set.
    /// <see cref="NLM_INTERNET_CONNECTIVITY_PROXIED"/> (0x2)
    /// The detected network has a proxy configuration.
    /// For example, when connected to a corporate network using a proxy for HTTP access, this flag will be set.
    /// <see cref="NLM_INTERNET_CONNECTIVITY_CORPORATE"/> (0x4)
    /// The machine has been configured for Direct Access and access is detected to the corporate domain network Direct Access has been configured for.
    /// <see cref="NA_NameSetByPolicy"/>
    /// <see cref="VT_BOOL"/>
    /// The name of the network has been set by group policy.
    /// <see cref="NA_IconSetByPolicy"/>
    /// <see cref="VT_BOOL"/>
    /// The icon of the network has been set by group policy.
    /// <see cref="NA_DescriptionSetByPolicy"/>
    /// <see cref="VT_BOOL"/>
    /// The description of the network has been set by group policy.
    /// <see cref="NA_CategorySetByPolicy"/>
    /// <see cref="VT_BOOL"/>
    /// The category of the network has been set by group policy.
    /// <see cref="NA_NameReadOnly"/>
    /// <see cref="VT_BOOL"/>
    /// The name of the network is read only.
    /// <see cref="NA_IconReadOnly"/>
    /// <see cref="VT_BOOL"/>
    /// The icon of the network is read only.
    /// <see cref="NA_DescriptionReadOnly"/>
    /// <see cref="VT_BOOL"/>
    /// The description of the network is read only.
    /// <see cref="NA_CategoryReadOnly"/>
    /// <see cref="VT_BOOL"/>
    /// The category of the network is read only.
    /// <see cref="NA_AllowMerge"/>
    /// <see cref="VT_BOOL"/>
    /// The network can be merged with another network.
    /// The <see cref="IPropertyBag"/> interface accepts <see cref="LPCOLESTR"/> as part of the <see cref="IPropertyBag.Read"/> and <see cref="IPropertyBag.Write"/> methods.
    /// For convenience, the string values for these properties are defined inside netlistmgr.h using the same names.
    /// </remarks>
    public unsafe struct INetwork
    {
        IntPtr* _vTable;

        /// <summary>
        /// The <see cref="GetName"/> method returns the name of a network.
        /// </summary>
        /// <param name="pszNetworkName">
        /// Pointer to the name of the network.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if the method succeeds.
        /// Otherwise, the method returns the following value.
        /// <see cref="E_POINTER"/> The pointer passed is <see cref="NULL"/>.
        /// </returns>
        public HRESULT GetName([Out] out BSTR pszNetworkName)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out BSTR, HRESULT>)_vTable[7])(thisPtr, out pszNetworkName);
            }
        }

        /// <summary>
        /// The <see cref="SetName"/> method sets or renames a network.
        /// </summary>
        /// <param name="szNetworkNewName">
        /// Zero-terminated string that contains the new name of the network.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if the method succeeds.
        /// Otherwise, the method returns one of the following values.
        /// <see cref="E_POINTER"/>: <paramref name="szNetworkNewName"/> is <see cref="NULL"/>.
        /// <code>HRESULT_FROM_WIN32(ERROR_FILENAME_EXCED_RANGE)</code>: The name provided is too long.
        /// </returns>
        /// <remarks>
        /// The maximum length of a network name can be 128 characters and cannot contain spaces only, tab or "\ /: * ? " &gt; > |".
        /// </remarks>
        public HRESULT SetName([In] BSTR szNetworkNewName)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BSTR, HRESULT>)_vTable[8])(thisPtr, szNetworkNewName);
            }
        }

        /// <summary>
        /// The <see cref="GetDescription"/> method returns a description string for the network.
        /// </summary>
        /// <param name="pszDescription">
        /// Pointer to a string that specifies the text description of the network.
        /// This value must be freed using the <see cref="SysFreeString"/> API.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if the method succeeds.
        /// Otherwise, the method returns the following value.
        /// <see cref="E_POINTER"/> The pointer passed is <see cref="NULL"/>.
        /// </returns>
        public HRESULT GetDescription([Out] out BSTR pszDescription)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out BSTR, HRESULT>)_vTable[9])(thisPtr, out pszDescription);
            }
        }

        /// <summary>
        /// The <see cref="SetDescription"/> method sets or replaces the description for a network.
        /// </summary>
        /// <param name="szDescription">
        /// Zero-terminated string that contains the description of the network.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if the method succeeds.
        /// Otherwise, the method returns one of the following values.
        /// <see cref="E_POINTER"/>: <paramref name="szDescription"/> is <see cref="NULL"/>.
        /// <code>HRESULT_FROM_WIN32(ERROR_FILENAME_EXCED_RANGE)</code>: The name provided is too long.
        /// </returns>
        /// <remarks>
        /// The maximum length for a network description is 1024 characters.
        /// </remarks>
        public HRESULT SetDescription([In] BSTR szDescription)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BSTR, HRESULT>)_vTable[10])(thisPtr, szDescription);
            }
        }

        /// <summary>
        /// The <see cref="GetNetworkId"/> method returns the unique identifier of a network.
        /// </summary>
        /// <param name="pgdGuidNetworkId">
        /// Pointer to a GUID that specifies the network ID.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if the method succeeds.
        /// </returns>
        /// <remarks>
        /// The caller is responsible for allocating the buffer pointed to by <paramref name="pgdGuidNetworkId"/>.
        /// This buffer must be large enough to hold a GUID.
        /// Calling <see cref="GetNetworkId"/> will return <see cref="S_OK"/> even if the network requested has been deleted.
        /// </remarks>
        public HRESULT GetNetworkId([Out] out GUID pgdGuidNetworkId)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out GUID, HRESULT>)_vTable[11])(thisPtr, out pgdGuidNetworkId);
            }
        }

        /// <summary>
        /// The <see cref="GetDomainType"/> method returns the domain type of a network.
        /// </summary>
        /// <param name="pNetworkType">
        /// Pointer to an <see cref="NLM_DOMAIN_TYPE"/> enumeration value that specifies the domain type of the network.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if the method succeeds.
        /// </returns>
        public HRESULT GetDomainType([Out] out NLM_DOMAIN_TYPE pNetworkType)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out NLM_DOMAIN_TYPE, HRESULT>)_vTable[12])(thisPtr, out pNetworkType);
            }
        }

        /// <summary>
        /// The <see cref="GetNetworkConnections"/> method returns an enumeration of all network connections for a network.
        /// A network can have multiple connections to it from different interfaces or different links from the same interface.
        /// </summary>
        /// <param name="ppEnumNetworkConnection">
        /// Pointer to an <see cref="IEnumNetworkConnections"/> interface instance that enumerates the list of local connections to this network.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if the method succeeds.
        /// </returns>
        public HRESULT GetNetworkConnections([Out] out P<IEnumNetworkConnections> ppEnumNetworkConnection)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IEnumNetworkConnections>, HRESULT>)_vTable[13])(thisPtr, out ppEnumNetworkConnection);
            }
        }

        /// <summary>
        /// The <see cref="GetTimeCreatedAndConnected"/> method returns the local date and time when the network was created and connected.
        /// </summary>
        /// <param name="pdwLowDateTimeCreated">
        /// Pointer to a datetime when the network was created.
        /// Specifically, it contains the low <see cref="DWORD"/> of <see cref="FILETIME.dwLowDateTime"/>.
        /// </param>
        /// <param name="pdwHighDateTimeCreated">
        /// Pointer to a datetime when the network was created.
        /// Specifically, it contains the high <see cref="DWORD"/> of <see cref="FILETIME.dwLowDateTime"/>.
        /// </param>
        /// <param name="pdwLowDateTimeConnected">
        /// Pointer to a datetime when the network was last connected to.
        /// Specifically, it contains the low <see cref="DWORD"/> of <see cref="FILETIME.dwLowDateTime"/>.
        /// </param>
        /// <param name="pdwHighDateTimeConnected">
        /// Pointer to a datetime when the network was last connected to.
        /// Specifically, it contains the hight <see cref="DWORD"/> of <see cref="FILETIME.dwLowDateTime"/>.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if the method succeeds.
        /// Otherwise, the method returns the following value.
        /// <see cref="E_POINTER"/> The pointer passed is <see cref="NULL"/>.
        /// </returns>
        public HRESULT GetTimeCreatedAndConnected([Out] out DWORD pdwLowDateTimeCreated, [Out] out DWORD pdwHighDateTimeCreated,
            [Out] out DWORD pdwLowDateTimeConnected, [Out] out DWORD pdwHighDateTimeConnected)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out DWORD, out DWORD, out DWORD, out DWORD, HRESULT>)_vTable[14])
                    (thisPtr, out pdwLowDateTimeCreated, out pdwHighDateTimeCreated, out pdwLowDateTimeConnected, out pdwHighDateTimeConnected);
            }
        }

#pragma warning disable IDE1006
        /// <summary>
        /// The <see cref="get_IsConnectedToInternet"/> property specifies if the network has internet connectivity.
        /// </summary>
        /// <param name="pbIsConnected">
        /// If <see cref="TRUE"/>, this network has connectivity to the internet; if <see cref="FALSE"/>, it does not.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if the method succeeds.
        /// </returns>
        public HRESULT get_IsConnectedToInternet([Out] out VARIANT_BOOL pbIsConnected)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out VARIANT_BOOL, HRESULT>)_vTable[15])(thisPtr, out pbIsConnected);
            }
        }

        /// <summary>
        /// The <see cref="get_IsConnected"/> property specifies if the network has any network connectivity.
        /// </summary>
        /// <param name="pbIsConnected">
        /// If <see cref="TRUE"/>, this network is connected; if <see cref="FALSE"/>, it does not.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if the method succeeds.
        /// </returns>
        public HRESULT get_IsConnected([Out] out VARIANT_BOOL pbIsConnected)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out VARIANT_BOOL, HRESULT>)_vTable[16])(thisPtr, out pbIsConnected);
            }
        }
#pragma warning restore IDE1006

        /// <summary>
        /// The <see cref="GetConnectivity"/> method returns the connectivity state of the network.
        /// </summary>
        /// <param name="pConnectivity">
        /// Pointer to a <see cref="NLM_CONNECTIVITY"/> enumeration value that contains a bitmask
        /// that specifies the connectivity state of this network.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if the method succeeds.
        /// </returns>
        public HRESULT GetConnectivity([Out] out NLM_CONNECTIVITY pConnectivity)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out NLM_CONNECTIVITY, HRESULT>)_vTable[17])(thisPtr, out pConnectivity);
            }
        }

        /// <summary>
        /// The <see cref="GetCategory"/> method returns the category of a network.
        /// </summary>
        /// <param name="pCategory">
        /// Pointer to a <see cref="NLM_NETWORK_CATEGORY"/> enumeration value that specifies the category information for the network.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if the method succeeds.
        /// </returns>
        /// <remarks>
        /// The private or public network categories must never be used to assume which Windows Firewall ports are open,
        /// as the user can change the default settings of these categories.
        /// Instead, Windows Firewall APIs should be called to ensure the ports that the required ports are open.
        /// </remarks>
        public HRESULT GetCategory([Out] out NLM_NETWORK_CATEGORY pCategory)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out NLM_NETWORK_CATEGORY, HRESULT>)_vTable[18])(thisPtr, out pCategory);
            }
        }

        /// <summary>
        /// The <see cref="SetCategory"/> method sets the category of a network.
        /// Changes made take effect immediately.
        /// Callers of this API must be members of the Administrators group.
        /// </summary>
        /// <param name="pCategory">
        /// Pointer to a <see cref="NLM_NETWORK_CATEGORY"/> enumeration value that specifies the new category of the network.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if the method succeeds.
        /// </returns>
        public HRESULT SetCategory([In] NLM_NETWORK_CATEGORY pCategory)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, NLM_NETWORK_CATEGORY, HRESULT>)_vTable[19])(thisPtr, pCategory);
            }
        }
    }
}
