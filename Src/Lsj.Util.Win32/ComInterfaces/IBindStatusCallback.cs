using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Enums.CLIPFORMAT;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Accepts information on an asynchronous bind operation.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775060(v=vs.85)"/>
    /// </para>
    /// </summary>
    public unsafe struct IBindStatusCallback
    {
        IntPtr* _vTable;

        /// <summary>
        /// Provides data to the client as it becomes available during asynchronous bind operations.
        /// </summary>
        /// <param name="grfBSCF">
        /// An unsigned long integer value from the <see cref="BSCF"/> enumeration that indicates the kind of data available.
        /// </param>
        /// <param name="dwSize">
        /// An unsigned long integer value that contains the size, in bytes, of the total data available from the current bind operation.
        /// </param>
        /// <param name="pformatetc">
        /// The address of the <see cref="FORMATETC"/> structure that indicates the format of the available data.
        /// This parameter is used when the bind operation results from the <see cref="IMoniker.BindToStorage"/> method.
        /// If there is no format associated with the available data, <paramref name="pformatetc"/> might contain <see cref="CF_NULL"/>.
        /// Each different call to <see cref="IBindStatusCallback.OnDataAvailable"/> can pass in a new value for this parameter; every call always points to the same data.
        /// </param>
        /// <param name="pstgmed">
        /// The address of the <see cref="STGMEDIUM"/> structure that contains pointers to the interfaces
        /// (such as <see cref="IStream"/> and <see cref="IStorage"/>) that can be used to access the data.
        /// In the asynchronous case, client applications might receive a second pointer to the <see cref="IStream"/> or <see cref="IStorage"/> interface
        /// from the <see cref="IMoniker.BindToStorage"/> method.
        /// The client application must call <see cref="IUnknown.Release"/> on the interfaces to avoid memory leaks.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful, or <see cref="E_INVALIDARG"/> if one or more parameters are invalid.
        /// </returns>
        /// <remarks>
        /// During asynchronous <see cref="IMoniker.BindToStorage"/> bind operations,
        /// an asynchronous moniker calls this method to provide data to the client as it becomes available.
        /// Note that the behavior of the storage returned in pstgmed depends on the <see cref="BINDF"/> flags returned in the <see cref="GetBindInfo"/> method.
        /// This storage can be asynchronous or blocking, and the bind operation can follow a data pull model or a data push model.
        /// For <see cref="BINDF"/> bind operations, it is not possible to seek backward into data streams that are provided in <see cref="OnDataAvailable"/>.
        /// On the other hand, for data push model bind operations, it is possible to seek back into a data stream,
        /// and to read any data that has been downloaded for an ongoing <see cref="IMoniker.BindToStorage"/> operation.
        /// </remarks>
        public HRESULT OnDataAvailable([In] BSCF grfBSCF, [In] DWORD dwSize, [In] in FORMATETC pformatetc, [In] in STGMEDIUM pstgmed)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BSCF, DWORD, in FORMATETC, in STGMEDIUM, HRESULT>)_vTable[10])(thisPtr, grfBSCF, dwSize, pformatetc, pstgmed);
            }
        }
    }
}
