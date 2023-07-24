using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SP_DEVICE_INTERFACE_DETAIL_DATA
    {
        public DWORD cbSize;
        public WCHAR DevicePath;
    }
}
