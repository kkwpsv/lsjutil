using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.MediaFoundation.ComInterfaces
{
    [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
    [ComInterface(IID = "c40a00f2-b93a-4d80-ae8c-5a1c634f58e4", BeginVTableSlotIndex = 33, EndVTableSlotIndex = 37,
        InheritedFromTypes = [typeof(IUnknown), typeof(IMFAttributes)])]
    public unsafe struct IMFSample
    {
        IntPtr* _vTable;
    }
}
