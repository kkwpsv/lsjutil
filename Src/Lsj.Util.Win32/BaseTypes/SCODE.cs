using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A 32-bit status value that is used to describe an error or warning.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/office/client-developer/outlook/mapi/scode"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The <see cref="SCODE"/> data type is the same as the <see cref="HRESULT"/> data type.
    /// </para>
    /// <para>
    /// An <see cref="SCODE"/> value is divided into four fields:
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// A single-bit severity code which is set to 0 to indicate success and 1 to indicate failure.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// An 11-bit reserved field
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// A 4-bit facility code which indicates the area responsible for the error or warning.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// A 16-bit error or warning code which describes the problem that is causing the error or warning.
    /// </description>
    /// </item>
    /// </list>
    /// <para>
    /// Many of the MAPI functions and methods return <see cref="SCODE"/> values
    /// defined as <see cref="HRESULT"/> data types as do the OLE methods and functions.
    /// OLE defines several macros that can be used to convert between an <see cref="SCODE"/> and an <see cref="HRESULT"/>.
    /// </para>
    /// <para>
    /// Note
    /// </para>
    /// <para>
    /// In 64-bit MAPI, <see cref="SCODE"/> is still a 32-bit value.
    /// </para>
    /// <para>
    /// For more information about how MAPI uses the <see cref="SCODE"/> data type, see Error Handling.
    /// For more information about OLE and the <see cref="SCODE"/> data type, see the .
    /// </para>
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
