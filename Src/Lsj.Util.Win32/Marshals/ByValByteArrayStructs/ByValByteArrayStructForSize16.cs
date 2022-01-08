using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Marshals.ByValByteArrayStructs
{
    /// <summary>
    /// By Val Byte Array Structs For Size 16
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Size = 16 * sizeof(byte))]
    public unsafe struct ByValByteArrayStructForSize16
    {
        byte _firstByte;
    }
}
