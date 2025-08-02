using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using System;
using System.Runtime.InteropServices;
using Lsj.Util.Win32.Attributes;

namespace Lsj.Util.Win32.WindowsRuntimeInterfaces
{
    /// <summary>
    /// <para>
    /// <see cref="IDirect3DDxgiInterfaceAccess"/> is a COM interface, which must be implemented
    /// by anything that implements <see cref="IDirect3DDevice"/> or <see cref="IDirect3DSurface"/>.
    /// <see cref="ID3D12GraphicsCommandList5"/> inherits from the <see cref="IUnknown"/> interface.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/windows.graphics.directx.direct3d11.interop/ns-windows-graphics-directx-direct3d11-interop-idirect3ddxgiinterfaceaccess"/>
    /// </para>
    /// </summary>
    [WindowsVersionRequirement(WindowsVersion.Windows10, 10240)]
    [ComInterface(BeginVTableSlotIndex = 3, EndVTableSlotIndex = 3, IID = "A9B3D012-3DF2-4EE3-B8D1-8695F457D3C1",
        InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IDirect3DDxgiInterfaceAccess
    {
        IntPtr* _vTable;

        /// <summary>
        /// Retrieves the DXGI interface that is wrapped by the <see cref="IDirect3DDxgiInterfaceAccess"/> object.
        /// </summary>
        /// <param name="iid">
        /// A reference to the globally unique identifier (GUID) of the interface that you wish to be returned in <paramref name="p"/>.
        /// </param>
        /// <param name="p">
        /// A pointer to a memory block that receives a pointer to the DXGI interface.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT GetInterface([In] in IID iid, out IntPtr p)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IID, out IntPtr, HRESULT>)_vTable[3])(thisPtr, iid, out p);
            }
        }
    }
}
