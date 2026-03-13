using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// GUID
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public struct GUID
    {
        [FieldOffset(0)]
        private Guid _value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator Guid(GUID val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator GUID(Guid val) => new GUID { _value = val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator GUID(string val) => new GUID { _value = new Guid(val) };

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        public static bool operator ==(GUID left, GUID right) => left._value == right._value;

        /// <summary>
        /// 
        /// </summary>
        public static bool operator !=(GUID left, GUID right) => !(left == right);

        /// <inheritdoc/>
        public override bool Equals(object? obj) => obj is GUID guid && _value == guid._value;

        /// <inheritdoc/>
        public override int GetHashCode() => _value.GetHashCode();
    }
}
