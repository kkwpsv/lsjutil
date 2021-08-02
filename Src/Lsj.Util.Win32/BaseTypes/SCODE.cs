using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A 32-bit status value that is used to describe an error or warning.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/office/client-developer/outlook/mapi/scode"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="SCODE"/> data type is the same as the <see cref="HRESULT"/> data type.
    /// An SCODE value is divided into four fields:
    /// A single-bit severity code which is set to 0 to indicate success and 1 to indicate failure.
    /// An 11-bit reserved field
    /// A 4-bit facility code which indicates the area responsible for the error or warning.
    /// A 16-bit error or warning code which describes the problem that is causing the error or warning.
    /// Many of the MAPI functions and methods return <see cref="SCODE"/> values defined as <see cref="HRESULT"/> data types as do the OLE methods and functions.
    /// OLE defines several macros that can be used to convert between an <see cref="SCODE"/> and an <see cref="HRESULT"/>.
    /// Note
    /// In 64-bit MAPI, SCODE is still a 32-bit value.
    /// For more information about how MAPI uses the <see cref="SCODE"/> data type, see Error Handling.
    /// For more information about OLE and the SCODE data type, see the OLE Programmer's Reference.
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct SCODE
    {
        [FieldOffset(0)]
        private uint _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator uint(SCODE val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator SCODE(uint val) => new SCODE { _value = val };
    }
}
