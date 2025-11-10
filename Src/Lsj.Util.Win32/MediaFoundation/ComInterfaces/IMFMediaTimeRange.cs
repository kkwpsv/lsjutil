using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.MediaFoundation.ComInterfaces
{
    [WindowsVersionRequirement(WindowsVersion.Windows8)]
    [ComInterface(IID = "db71a2fc-078a-414e-9df9-8c2531b0aa6c", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 8, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IMFMediaTimeRange
    {
        IntPtr* _vTable;
    }
}
