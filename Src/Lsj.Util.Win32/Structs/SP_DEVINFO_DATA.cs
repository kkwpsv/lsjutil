using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SP_DEVINFO_DATA
    {
        public DWORD cbSize;
        public GUID ClassGuid;
        public DWORD DevInst;
        public ULONG_PTR Reserved;
    }
}
