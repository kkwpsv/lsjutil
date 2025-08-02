using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// 
    /// </summary>
    [WindowsVersionRequirement(WindowsVersion.Windows7)]
    [ComInterface(IID = "1841e5c8-16b0-489b-bcc8-44cfb0d5deae", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 6, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct ID3D11DeviceChild
    {
        IntPtr* _vTable;
    }
}
