using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A handle to a file opened by <see cref="OpenFile"/>, not <see cref="CreateFile"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/winprog/windows-data-types"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct HFILE
    {
        /// <summary>
        /// HFILE_ERROR
        /// </summary>
        public static readonly HFILE HFILE_ERROR = new HFILE { _value = -1 };

        [FieldOffset(0)]
        private int _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString("X");
    }
}
