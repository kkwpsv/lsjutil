using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A <see cref="MEMBERID"/> type is a 32-bit value that identifies a data or method member of a type.
    /// </para>
    /// <para>
    /// From: https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-oaut/ace8758f-ee2b-4cb6-8645-973994d12530
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct MEMBERID
    {
        /// <summary>
        /// MEMBERID_NIL
        /// </summary>
        public static readonly MEMBERID MEMBERID_NIL = new MEMBERID { _value = -1 };

        [FieldOffset(0)]
        private int _value;
    }
}
