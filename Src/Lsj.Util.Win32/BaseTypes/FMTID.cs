using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// Property set values are stored in a section tagged with a unique <see cref="FMTID"/>.
    /// For example, the <see cref="FMTID"/> for the COM Summary Information property set is F29F85E0-4FF9-1068-AB91-08002B27B3D9.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/stg/format-identifiers"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public struct FMTID
    {
        [FieldOffset(0)]
        private Guid _value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator Guid(FMTID val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator FMTID(Guid val) => new FMTID { _value = val };

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();
    }
}
