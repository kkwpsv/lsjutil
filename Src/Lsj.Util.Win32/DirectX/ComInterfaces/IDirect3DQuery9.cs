using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3DERR;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Applications use the methods of the <see cref="IDirect3DQuery9"/> interface to perform asynchronous queries on a driver.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d9helper/nn-d3d9helper-idirect3dquery9"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The LPDIRECT3DQUERY9 and PDIRECT3DQUERY9 types are defined as pointers to the <see cref="IDirect3DQuery9"/> interface.
    /// </para>
    /// <code>
    /// typedef struct IDirect3DQuery9 *LPDIRECT3DQUERY9, *PDIRECT3DQUERY9;
    /// </code>
    /// </remarks>
    [ComInterface(IID = "d9771460-a695-4f26-bbd3-27b840b541cc", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 6, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IDirect3DQuery9
    {
        IntPtr* _vTable;

        /// <summary>
        /// Gets the device that is being queried.
        /// </summary>
        /// <param name="ppDevice">
        /// Pointer to the device being queried.
        /// See <see cref="IDirect3DDevice9"/>.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        public HRESULT GetDevice([Out] out P<IDirect3DDevice9> ppDevice)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IDirect3DDevice9>, HRESULT>)_vTable[3])(thisPtr, out ppDevice);
            }
        }

        /// <summary>
        /// Gets the query type.
        /// </summary>
        /// <returns>
        /// Returns the query type.
        /// See <see cref="D3DQUERYTYPE"/>.
        /// </returns>
        public new D3DQUERYTYPE GetType()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3DQUERYTYPE>)_vTable[4])(thisPtr);
            }
        }

        /// <summary>
        /// Gets the number of bytes in the query data.
        /// </summary>
        /// <returns>
        /// Returns the number of bytes of query data.
        /// </returns>
        public DWORD GetDataSize()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD>)_vTable[5])(thisPtr);
            }
        }

        /// <summary>
        /// Issue a query.
        /// </summary>
        /// <param name="dwIssueFlags">
        /// Query flags specify the type of state change for the query.
        /// See <see cref="D3DISSUE_BEGIN"/> and <see cref="D3DISSUE_END"/>.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// A signaled query means the query has completed, the data is available,
        /// and <see cref="GetData"/> will return <see cref="S_OK"/>.
        /// </remarks>
        public HRESULT Issue([In] DWORD dwIssueFlags)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, HRESULT>)_vTable[6])(thisPtr, dwIssueFlags);
            }
        }

        /// <summary>
        /// Polls a queried resource to get the query state or a query result.
        /// For more information about queries, see Queries (Direct3D 9).
        /// </summary>
        /// <param name="pData">
        /// Pointer to a buffer containing the query data.
        /// The user is responsible for allocating this.
        /// <paramref name="pData"/> may be <see cref="NULL"/> only if <paramref name="dwSize"/> is 0.
        /// </param>
        /// <param name="dwSize">
        /// Number of bytes of data in <paramref name="pData"/>.
        /// If you set <paramref name="dwSize"/> to zero, you can use this method to poll the resource for the query status.
        /// See remarks.
        /// </param>
        /// <param name="dwGetDataFlags">
        /// Data flags specifying the query type.
        /// Valid values are either 0 or <see cref="D3DGETDATA_FLUSH"/>.
        /// Use 0 to avoid flushing batched queries to the driver
        /// and use <see cref="D3DGETDATA_FLUSH"/> to go ahead and flush them.
        /// For applications writing their own version of waiting,
        /// a query result is not realized until the driver receives a flush.
        /// </param>
        /// <returns>
        /// The return type identifies the query state (see Queries (Direct3D 9)).
        /// The method returns <see cref="S_OK"/> if the query data is available and <see cref="S_FALSE"/> if it is not.
        /// These are considered successful return values.
        /// If the method fails when <see cref="D3DGETDATA_FLUSH"/> is used,
        /// the return value can be <see cref="D3DERR_DEVICELOST"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// It is possible to lose the device while polling for query status.
        /// When <see cref="D3DGETDATA_FLUSH"/> is specified,
        /// this method will return <see cref="D3DERR_DEVICELOST"/> in response to a lost device.
        /// This allows an application to prevent threads from endlessly polling due to a lost device
        /// (which cannot respond to the query).
        /// </para>
        /// <para>
        /// An application must never write code that only invokes GetData ( ... , 0 ),
        /// expecting that <see cref="GetData"/> will eventually return S_OK by itself over time.
        /// This is true, even if the application has used the <see cref="D3DGETDATA_FLUSH"/> flag
        /// with <see cref="GetData"/> in the past.
        /// For example:
        /// </para>
        /// <code>
        /// // Enables an infinite loop:
        /// while( pQuery->GetData( ... , 0 ) == S_FALSE ) ;
        /// 
        /// // Still enables an infinite loop:
        /// pQuery->GetData( ... , D3DGETDATA_FLUSH );
        /// while( pQuery->GetData( ... , 0 ) == S_FALSE ) ;
        /// 
        /// // Does not enable an infinite loop because eventually the command
        /// // buffer will fill up and that will cause a flush to occur.
        /// while( pQuery->GetData( ..., 0 ) == S_FALSE ) {
        ///     pDevice->SetTexture(...);
        ///     pDevice->Draw(...);
        /// }
        /// </code>
        /// </remarks>
        public HRESULT GetData([In] IntPtr pData, [In] DWORD dwSize, [In] DWORD dwGetDataFlags)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, IntPtr, DWORD, DWORD, HRESULT>)_vTable[6])(thisPtr, pData, dwSize, dwGetDataFlags);
            }
        }
    }
}
