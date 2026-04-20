using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// A command signature object enables apps to specify indirect drawing,
    /// including the buffer format, command type and resource bindings to be used.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12commandsignature"/>
    /// </para>
    /// </summary>
    [ComInterface(IID = "c36a797c-ec80-4f0a-8985-a7b2475082d1", BeginVTableSlotIndex = -1, EndVTableSlotIndex = 7,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID3D12Object), typeof(ID3D12DeviceChild), typeof(ID3D12Pageable)])]
    public unsafe struct ID3D12CommandSignature
    {
        IntPtr* _vTable;
    }
}
