using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System;

namespace Lsj.Util.Win32.WindowsRuntimeInterfaces
{
    /// <summary>
    /// <para>
    /// This represents an <see cref="IDXGISurface"/> and can be used to interop
    /// between Windows Runtime components that need to exchange <see cref="IDXGISurface"/> references.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/uwp/api/windows.graphics.directx.direct3d11.idirect3dsurface"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// To move back and forth between <see cref="IDirect3DSurface"/> and <see cref="IDXGISurface"/>,
    /// use the CreateDirect3DSurface and GetDXGIInterface(IDirect3DSurface^, DXGI_TYPE**) functions.
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows10, 10240)]
    [ComInterface(BeginVTableSlotIndex = 6, EndVTableSlotIndex = 6, IID = "0bf4a146-13c1-4694-bee3-7abf15eaf586",
        InheritedFromTypes = [typeof(IUnknown), typeof(IInspectable)])]
    public unsafe struct IDirect3DSurface
    {
        IntPtr* _vTable;
    }
}
