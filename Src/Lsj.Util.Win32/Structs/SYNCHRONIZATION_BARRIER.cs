using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// SYNCHRONIZATION_BARRIER
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SYNCHRONIZATION_BARRIER
    {
#pragma warning disable IDE1006
        DWORD Reserved1;
        DWORD Reserved2;
        ULONG_PTR Reserved3_1;
        ULONG_PTR Reserved3_2;
        DWORD Reserved4;
        DWORD Reserved5;
#pragma warning restore IDE1006
    }
}
