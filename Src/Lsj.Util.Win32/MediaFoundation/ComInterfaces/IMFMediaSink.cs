using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.MediaFoundation.ComInterfaces
{
    [WindowsVersionRequirement(WindowsVersion.Windows8)]
    [ComInterface(IID = "6ef2a660-47c0-4666-b13d-cbb717f2fa2c", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 11, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IMFMediaSink
    {
        IntPtr* _vTable;
    }
}
