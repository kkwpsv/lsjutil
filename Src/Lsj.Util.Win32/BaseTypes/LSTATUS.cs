using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// LSTATUS
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct LSTATUS
    {
        [FieldOffset(0)]
        private int _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();
    }
}
