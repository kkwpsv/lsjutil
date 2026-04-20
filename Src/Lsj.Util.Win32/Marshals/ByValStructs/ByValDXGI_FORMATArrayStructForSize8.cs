using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Marshals.ByValStructs
{
    /// <summary>
    /// By Val <see cref="DXGI_FORMAT"/> Struct For Size8
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Size = 8 * sizeof(DXGI_FORMAT))]
    public unsafe struct ByValDXGI_FORMATArrayStructForSize8
    {
    }
}
