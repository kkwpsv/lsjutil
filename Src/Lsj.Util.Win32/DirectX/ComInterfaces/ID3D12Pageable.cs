using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// An interface from which many other core interfaces inherit from.
    /// It indicates that the object type encapsulates some amount of GPU-accessible memory;
    /// but does not strongly indicate whether the application can manipulate the object's residency.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12pageable"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// For more details, refer to Memory Management in Direct3D 12 and the <see cref="ID3D12Device.MakeResident"/> method reference.
    /// </remarks>
    [ComInterface(IID = "63ee58fb-1268-4835-86da-f008ce62f0d6", BeginVTableSlotIndex = -1, EndVTableSlotIndex = 7,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID3D12Object), typeof(ID3D12DeviceChild)])]
    public unsafe struct ID3D12Pageable
    {
        nint* _vTable;
    }
}
