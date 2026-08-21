using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// 
    /// </summary>
    [WindowsVersionRequirement(WindowsVersion.Windows7)]
    [ComInterface(IID = "dc8e63f3-d12b-4952-b47b-5e45026a862d", BeginVTableSlotIndex = 7, EndVTableSlotIndex = 9,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID3D11DeviceChild)])]
    public unsafe struct ID3D11Resource
    {
        nint* _vTable;
    }
}
