using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.MediaFoundation.ComInterfaces
{
    [WindowsVersionRequirement(WindowsVersion.Windows8)]
    [ComInterface(IID = "fc0e10d2-ab2a-4501-a951-06bb1075184c", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 6, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IMFMediaError
    {
        IntPtr* _vTable;
    }
}
