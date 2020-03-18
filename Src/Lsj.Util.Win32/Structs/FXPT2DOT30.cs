using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// FXPT2DOT30
    /// </summary>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode, Size = 4)]
    public struct FXPT2DOT30
    {
        [FieldOffset(0)]
        private int value;
    }
}
