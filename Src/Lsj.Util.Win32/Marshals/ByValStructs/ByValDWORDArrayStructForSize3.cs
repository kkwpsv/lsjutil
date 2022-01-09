using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Marshals.ByValStructs
{
    /// <summary>
    /// By Val <see cref="DWORD"/> Array Struct For Size 3
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Size = 3 * 4)]
    public unsafe struct ByValDWORDArrayStructForSize3
    {
    }
}
