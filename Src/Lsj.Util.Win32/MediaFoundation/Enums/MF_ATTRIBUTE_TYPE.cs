using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Enums;

namespace Lsj.Util.Win32.MediaFoundation.Enums
{
    /// <summary>
    /// <para>
    /// Defines the data type for a key/value pair.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfobjects/ne-mfobjects-mf_attribute_type"/>
    /// </para>
    /// </summary>
    public enum MF_ATTRIBUTE_TYPE
    {
        /// <summary>
        /// Unsigned 32-bit integer.
        /// </summary>
        MF_ATTRIBUTE_UINT32 = VARENUM.VT_UI4,

        /// <summary>
        /// Unsigned 64-bit integer.
        /// </summary>
        MF_ATTRIBUTE_UINT64 = VARENUM.VT_UI8,

        /// <summary>
        /// Floating-point number.
        /// </summary>
        MF_ATTRIBUTE_DOUBLE = VARENUM.VT_R8,

        /// <summary>
        /// <see cref="GUID"/> value.
        /// </summary>
        MF_ATTRIBUTE_GUID = VARENUM.VT_CLSID,

        /// <summary>
        /// NULL-terminated wide-character string.
        /// </summary>
        MF_ATTRIBUTE_STRING = VARENUM.VT_LPWSTR,

        /// <summary>
        /// Byte array.
        /// </summary>
        MF_ATTRIBUTE_BLOB,

        /// <summary>
        /// <see cref="IUnknown"/> pointer.
        /// </summary>
        MF_ATTRIBUTE_IUNKNOWN = VARENUM.VT_UNKNOWN,
    }
}
