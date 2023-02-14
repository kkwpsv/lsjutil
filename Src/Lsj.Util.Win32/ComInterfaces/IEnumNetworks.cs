using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The <see cref="IEnumNetworks"/> interface is a standard enumerator for networks.
    /// It enumerates all networks available on the local machine.
    /// This interface can be obtained from the <see cref="INetworkListManager"/> interface.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/netlistmgr/nn-netlistmgr-ienumnetworks"/>
    /// </para>
    /// </summary>
    public unsafe struct IEnumNetworks
    {
        IntPtr* _vTable;

        /// <summary>
        /// The <see cref="get__NewEnum"/> property returns an automation enumerator object
        /// that you can use to iterate through the <see cref="IEnumNetworks"/> collection.
        /// </summary>
        /// <param name="ppEnumVar">
        /// Contains the new instance of the implemented interface.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if the method succeeds.
        /// </returns>
        /// <remarks>
        /// In Microsoft Visual Basic and Microsoft C#, you do not need to use the corresponding _NewEnum property,
        /// because it is automatically used in the implementation of the For Each loop (for each in Visual C#).
        /// </remarks>
#pragma warning disable IDE1006
        public HRESULT get__NewEnum([Out] out P<IEnumVARIANT> ppEnumVar)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IEnumVARIANT>, HRESULT>)_vTable[7])(thisPtr, out ppEnumVar);
            }
        }
#pragma warning restore IDE1006

        /// <summary>
        /// The <see cref="Next"/> method gets the next specified number of elements in the enumeration sequence.
        /// </summary>
        /// <param name="celt">
        /// Number of elements requested in the enumeration.
        /// </param>
        /// <param name="rgelt">
        /// Pointer to the enumerated list of pointers returned by <see cref="INetwork"/>.
        /// </param>
        /// <param name="pceltFetched">
        /// Pointer to the number of elements supplied.
        /// This parameter is set to <see cref="NullRef{ULONG}"/> if <paramref name="celt"/> has the value of 1.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if the method succeeds.
        /// Otherwise, the method returns one of the following values.
        /// <see cref="S_FALSE"/>: The number of elements skipped was not equal to <paramref name="celt"/>.
        /// <see cref="E_OUTOFMEMORY"/>: Insufficient memory exists to perform the operation.
        /// <see cref="E_POINTER"/>: The <paramref name="rgelt"/> parameter is not a valid pointer.
        /// </returns>
        public HRESULT Next([In] ULONG celt, [Out] P<INetwork>[] rgelt, [Out] out ULONG pceltFetched)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, ULONG, P<INetwork>[], out ULONG, HRESULT>)_vTable[8])(thisPtr, celt, rgelt, out pceltFetched);
            }
        }

        /// <summary>
        /// The <see cref="Skip"/> method skips over the next specified number of elements in the enumeration sequence.
        /// </summary>
        /// <param name="celt">
        /// Number of elements to skip in the enumeration.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if the method succeeds.
        /// Otherwise, the method returns one of the following values.
        /// <see cref="S_FALSE"/>: The number of elements skipped was not <paramref name="celt"/>.
        /// <see cref="E_OUTOFMEMORY"/>: Insufficient memory exists to perform the operation.
        /// </returns>
        public HRESULT Skip([In] ULONG celt)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, ULONG, HRESULT>)_vTable[9])(thisPtr, celt);
            }
        }

        /// <summary>
        /// The <see cref="Reset"/> method resets the enumeration sequence to the beginning.
        /// </summary>
        /// <returns>
        /// Returns <see cref="S_OK"/> if the method succeeds.
        /// Otherwise, the method returns one of the following values.
        /// <see cref="E_OUTOFMEMORY"/>: Insufficient memory exists to perform the operation.
        /// </returns>
        public HRESULT Reset()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[10])(thisPtr);
            }
        }

        /// <summary>
        /// The <see cref="Clone"/> method creates an enumerator that contains the same enumeration state as the enumerator currently in use.
        /// </summary>
        /// <param name="ppEnumNetwork">
        /// Pointer to a new <see cref="IEnumNetworks"/> interface.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if the method succeeds.
        /// </returns>
        public HRESULT Clone([Out] out P<IEnumNetworks> ppEnumNetwork)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IEnumNetworks>, HRESULT>)_vTable[11])(thisPtr, out ppEnumNetwork);
            }
        }
    }
}
