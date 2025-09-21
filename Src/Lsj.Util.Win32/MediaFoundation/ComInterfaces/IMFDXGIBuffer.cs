using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.MediaFoundation.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Represents a buffer that contains a Microsoft DirectX Graphics Infrastructure (DXGI)surface.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfobjects/nn-mfobjects-imfdxgibuffer"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// To create a DXGImedia buffer, first create the DXGIsurface.
    /// Then call <see cref="MFCreateDXGISurfaceBuffer"/>.
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows8)]
    [ComInterface(IID = "e7174cfa-1c9e-48b1-8866-626226bfc258", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 6, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IMFDXGIBuffer
    {
        IntPtr* _vTable;

        /// <summary>
        /// Queries the Microsoft DirectX Graphics Infrastructure (DXGI)surface for an interface.
        /// </summary>
        /// <param name="riid">
        /// The interface identifier (<see cref="IID"/>) of the interface being requested.
        /// </param>
        /// <param name="ppvObject">
        /// Receives a pointer to the interface. The caller must release the interface.
        /// </param>
        /// <returns>
        /// <para>
        /// This method can return one of these values.
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
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// Success.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_NOINTERFACE"/>
        /// </term>
        /// <term>
        /// The object does not support the specified interface.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_INVALIDREQUEST"/>
        /// </term>
        /// <term>
        /// Invalid request.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// You can use this method to get a pointer to the <see cref="ID3D11Texture2D"/> interface of the surface.
        /// If the buffer is locked, the method returns <see cref="MF_E_INVALIDREQUEST"/>.
        /// </remarks>
        public HRESULT GetResource([In] in IID riid, out LPVOID ppvObject)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IID, out LPVOID, HRESULT>)_vTable[3])(thisPtr, riid, out ppvObject);
            }
        }

        /// <summary>
        /// Gets the index of the subresource that is associated with this media buffer.
        /// </summary>
        /// <param name="puSubresource">
        /// Receives the zero-based index of the subresource.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The subresource index is specified when you create the media buffer object.
        /// See <see cref="MFCreateDXGISurfaceBuffer"/>.
        /// </para>
        /// <para>
        /// For more information about texture subresources, see <see cref="ID3D11Device.CreateTexture2D"/>.
        /// </para>
        /// </remarks>
        public HRESULT GetSubresourceIndex([Out] out UINT puSubresource)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out UINT, HRESULT>)_vTable[4])(thisPtr, out puSubresource);
            }
        }

        /// <summary>
        /// Gets an <see cref="IUnknown"/> pointer that was previously stored in the media buffer object.
        /// </summary>
        /// <param name="guid">
        /// The identifier of the <see cref="IUnknown"/> pointer.
        /// </param>
        /// <param name="riid">
        /// The interface identifier (<see cref="IID"/>) of the interface being requested.
        /// </param>
        /// <param name="ppvObject">
        /// Receives a pointer to the interface.
        /// The caller must release the interface.
        /// </param>
        /// <returns>
        /// <para>
        /// This method can return one of these values.
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
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// Success.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_NOINTERFACE"/>
        /// </term>
        /// <term>
        /// The object does not support the specified interface.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_NOT_FOUND"/>
        /// </term>
        /// <term>
        /// The specified key was not found.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        public HRESULT GetUnknown([In] in GUID guid, [In] in IID riid, [Out] out IntPtr ppvObject)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, in IID, out IntPtr, HRESULT>)_vTable[5])
                    (thisPtr, guid, riid, out ppvObject);
            }
        }

        /// <summary>
        /// Stores an arbitrary <see cref="IUnknown"/> pointer in the media buffer object.
        /// </summary>
        /// <param name="guid">
        /// The identifier for the <see cref="IUnknown"/> pointer.
        /// This identifier is used as a key to retrieve the value. It can be any <see cref="GUID"/> value.
        /// </param>
        /// <param name="pUnkData">
        /// A pointer to the <see cref="IUnknown"/> interface.
        /// Set this parameter to <see cref="NULL"/> to clear a pointer that was previously set.
        /// </param>
        /// <returns>
        /// <para>
        /// This method can return one of these values.
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
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// Success.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_OBJECT_ALREADY_EXISTS"/>
        /// </term>
        /// <term>
        /// An item already exists with this key.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// To retrieve the pointer from the object, call <see cref="GetUnknown"/>.
        /// </remarks>
        public HRESULT SetUnknown([In] in IID guid, [In] P<IUnknown> pUnkData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IID, P<IUnknown>, HRESULT>)_vTable[6])(thisPtr, guid, pUnkData);
            }
        }
    }
}
