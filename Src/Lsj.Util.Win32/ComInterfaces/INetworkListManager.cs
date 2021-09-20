using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The <see cref="INetworkListManager"/> interface provides a set of methods to perform network list management functions.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/netlistmgr/nn-netlistmgr-inetworklistmanager"/>
    /// </para>
    /// </summary>
    public unsafe struct INetworkListManager
    {
        IntPtr* _vTable;

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
    }
}
