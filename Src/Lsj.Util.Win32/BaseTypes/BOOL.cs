using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A <see cref="BOOL"/> is a 32-bit field that is set to 1 to indicate <see cref="TRUE"/>, or 0 to indicate <see cref="FALSE"/>.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/openspecs/windows_protocols/ms-dtyp/9d81be47-232e-42cf-8f0d-7a3b29bf2eb2
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct BOOL
    {
        /// <summary>
        /// TRUE
        /// </summary>
        public static readonly BOOL TRUE = new BOOL { _value = 1 };

        /// <summary>
        /// FALSE
        /// </summary>
        public static readonly BOOL FALSE = new BOOL { _value = 0 };

        [FieldOffset(0)]
        private int _value;

        /// <inheritdoc/>
        public override string ToString() => ((bool)this).ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator bool(BOOL val) => val._value != 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator BOOL(bool val) => val ? TRUE : FALSE;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator int(BOOL val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator BOOL(int val) => new BOOL { _value = val };
    }
}
