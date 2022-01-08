using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Marshals.ByValByteArrayStructs
{
    /// <summary>
    /// By Val Byte Array Structs For Size 8
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Size = 8 * sizeof(byte))]
    public unsafe struct ByValByteArrayStructForSize8
    {
        byte _firstByte;
    }
}
