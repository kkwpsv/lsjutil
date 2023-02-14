using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A <see cref="BOOLEAN"/> is an 8-bit field that is set to 1 to indicate <see cref="TRUE"/>, or 0 to indicate <see cref="FALSE"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-dtyp/51bbfbb1-08e2-4c13-a95e-1eaa7d310670"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 1)]
    public struct BOOLEAN
    {
        /// <summary>
        /// TRUE
        /// </summary>
        public static readonly BOOLEAN TRUE = new BOOLEAN { _value = 1 };

        /// <summary>
        /// FALSE
        /// </summary>
        public static readonly BOOLEAN FALSE = new BOOLEAN { _value = 0 };

        [FieldOffset(0)]
        private byte _value;

        /// <inheritdoc/>
        public override string ToString() => ((bool)this).ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator bool(BOOLEAN val) => val._value != 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator BOOLEAN(bool val) => val ? TRUE : FALSE;
    }
}
