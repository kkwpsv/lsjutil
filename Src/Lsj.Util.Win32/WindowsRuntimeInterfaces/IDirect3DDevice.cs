using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System;
using static Lsj.Util.Win32.DirectX.D3D11;

namespace Lsj.Util.Win32.WindowsRuntimeInterfaces
{
    /// <summary>
    /// <para>
    /// This represents an <see cref="IDXGIDevice"/>, and can be used to interop
    /// between Windows Runtime components that need to exchange <see cref="IDXGIDevice"/> references.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/uwp/api/windows.graphics.directx.direct3d11.idirect3ddevice"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// If you're using C++/WinRT, then to move back and forth between <see cref="IDirect3DDevice"/> and <see cref="IDXGIDevice"/>,
    /// use the <see cref="IDirect3DDxgiInterfaceAccess.GetInterface"/> and <see cref="CreateDirect3D11DeviceFromDXGIDevice"/> functions.
    /// You can see another code example in Composition native interoperation with DirectX and Direct2D.
    /// </para>
    /// <para>
    /// If you're using C++/CX, then to move back and forth between <see cref="IDirect3DDevice"/> and <see cref="IDXGIDevice"/>,
    /// use the CreateDirect3DDevice and GetDXGIInterface(IDirect3DDevice^, DXGI_TYPE**) functions.
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows10, BuildNumbers.Windows10_1507)]
    [ComInterface(BeginVTableSlotIndex = 6, EndVTableSlotIndex = 6, IID = "a37624ab-8d5f-4650-9d3e-9eae3d9bc670",
        InheritedFromTypes = [typeof(IUnknown), typeof(IInspectable)])]
    public unsafe struct IDirect3DDevice
    {
        nint* _vTable;
    }
}
