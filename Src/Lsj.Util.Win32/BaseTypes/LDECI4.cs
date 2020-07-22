using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// LDECI4
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct LDECI4
    {
        [FieldOffset(0)]
        private int _value;
    }
}
