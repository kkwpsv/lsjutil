using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The root signature defines what resources are bound to the graphics pipeline.
    /// A root signature is configured by the app and links command lists to the resources the shaders require.
    /// Currently, there is one graphics and one compute root signature per app.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12rootsignature"/>
    /// </para>
    /// </summary>
    [ComInterface(IID = "c54a6b66-72df-4ee8-8be5-a946a1429214", BeginVTableSlotIndex = -1, EndVTableSlotIndex = 7,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID3D12Object), typeof(ID3D12DeviceChild)])]
    public unsafe struct ID3D12RootSignature
    {
        nint* _vTable;
    }
}
