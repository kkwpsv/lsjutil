using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;
using static Lsj.Util.Win32.DirectX.D3D11;
using static Lsj.Util.Win32.DirectX.DXGI;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Enables creating Microsoft DirectX Graphics Infrastructure (DXGI) objects.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_3/nn-dxgi1_3-idxgifactory3"/>
    /// </para>
    /// </summary>
    [WindowsVersionRequirement(WindowsVersion.Windows8_1)]
    [ComInterface(IID = "25483823-cd46-4c7d-86ca-47aa95b837bd", BeginVTableSlotIndex = 25, EndVTableSlotIndex = 25,
        InheritedFromTypes = [typeof(IUnknown), typeof(IDXGIObject), typeof(IDXGIFactory), typeof(IDXGIFactory1), typeof(IDXGIFactory2)])]
    public unsafe struct IDXGIFactory3
    {
        IntPtr* _vTable;

        /// <summary>
        /// Gets the flags that were used when a Microsoft DirectX Graphics Infrastructure (DXGI) object was created.
        /// </summary>
        /// <returns>
        /// The creation flags.
        /// </returns>
        /// <remarks>
        /// The <see cref="GetCreationFlags"/> method returns flags that were passed to the <see cref="CreateDXGIFactory2"/> function,
        /// or were implicitly constructed by <see cref="CreateDXGIFactory"/>, <see cref="CreateDXGIFactory1"/>,
        /// <see cref="D3D11CreateDevice"/>, or <see cref="D3D11CreateDeviceAndSwapChain"/>.
        /// </remarks>
        public UINT GetCreationFlags()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT>)_vTable[25])(thisPtr);
            }
        }
    }
}
