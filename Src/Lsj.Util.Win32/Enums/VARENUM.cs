using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the variant types.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wtypes/ne-wtypes-varenum"/>
    /// </para>
    /// </summary>
    public enum VARENUM
    {
        /// <summary>
        /// Not specified.
        /// </summary>
        VT_EMPTY = 0,

        /// <summary>
        /// Null.
        /// </summary>
        VT_NULL = 1,

        /// <summary>
        /// A 2-byte integer.
        /// </summary>
        VT_I2 = 2,

        /// <summary>
        /// A 4-byte integer.
        /// </summary>
        VT_I4 = 3,

        /// <summary>
        /// A 4-byte real.
        /// </summary>
        VT_R4 = 4,

        /// <summary>
        /// An 8-byte real.
        /// </summary>
        VT_R8 = 5,

        /// <summary>
        /// Currency.
        /// </summary>
        VT_CY = 6,

        /// <summary>
        /// A date.
        /// </summary>
        VT_DATE = 7,

        /// <summary>
        /// A string.
        /// </summary>
        VT_BSTR = 8,

        /// <summary>
        /// An <see cref="IDispatch"/> pointer.
        /// </summary>
        VT_DISPATCH = 9,

        /// <summary>
        /// An <see cref="SCODE"/> value.
        /// </summary>
        VT_ERROR = 10,

        /// <summary>
        /// A Boolean value. True is -1 and false is 0.
        /// </summary>
        VT_BOOL = 11,

        /// <summary>
        /// /A variant pointer.
        /// </summary>
        VT_VARIANT = 12,

        /// <summary>
        /// An <see cref="IUnknown"/> pointer.
        /// </summary>
        VT_UNKNOWN = 13,

        /// <summary>
        /// A 16-byte fixed-pointer value.
        /// </summary>
        VT_DECIMAL = 14,

        /// <summary>
        /// A character.
        /// </summary>
        VT_I1 = 16,

        /// <summary>
        /// An unsigned character.
        /// </summary>
        VT_UI1 = 17,

        /// <summary>
        /// An unsigned short.
        /// </summary>
        VT_UI2 = 18,

        /// <summary>
        /// An unsigned long.
        /// </summary>
        VT_UI4 = 19,

        /// <summary>
        /// A 64-bit integer.
        /// </summary>
        VT_I8 = 20,

        /// <summary>
        /// A 64-bit unsigned integer.
        /// </summary>
        VT_UI8 = 21,

        /// <summary>
        /// An integer.
        /// </summary>
        VT_INT = 22,

        /// <summary>
        /// An unsigned integer.
        /// </summary>
        VT_UINT = 23,

        /// <summary>
        /// A C-style void.
        /// </summary>
        VT_VOID = 24,

        /// <summary>
        /// An <see cref="HRESULT"/> value.
        /// </summary>
        VT_HRESULT = 25,

        /// <summary>
        /// A pointer type.
        /// </summary>
        VT_PTR = 26,

        /// <summary>
        /// A safe array.
        /// Use <see cref="VT_ARRAY"/> in <see cref="VARIANT"/>.
        /// </summary>
        VT_SAFEARRAY = 27,

        /// <summary>
        /// A C-style array.
        /// </summary>
        VT_CARRAY = 28,

        /// <summary>
        /// A user-defined type.
        /// </summary>
        VT_USERDEFINED = 29,

        /// <summary>
        /// A null-terminated string.
        /// </summary>
        VT_LPSTR = 30,

        /// <summary>
        /// A wide null-terminated string.
        /// </summary>
        VT_LPWSTR = 31,

        /// <summary>
        /// A user-defined type.
        /// </summary>
        VT_RECORD = 36,

        /// <summary>
        /// A signed machine register size width.
        /// </summary>
        VT_INT_PTR = 37,

        /// <summary>
        /// An unsigned machine register size width.
        /// </summary>
        VT_UINT_PTR = 38,

        /// <summary>
        /// A <see cref="FILETIME"/> value.
        /// </summary>
        VT_FILETIME = 64,

        /// <summary>
        /// Length-prefixed bytes.
        /// </summary>
        VT_BLOB = 65,

        /// <summary>
        /// The name of the stream follows.
        /// </summary>
        VT_STREAM = 66,

        /// <summary>
        /// The name of the storage follows.
        /// </summary>
        VT_STORAGE = 67,

        /// <summary>
        /// The stream contains an object.
        /// </summary>
        VT_STREAMED_OBJECT = 68,

        /// <summary>
        /// The storage contains an object.
        /// </summary>
        VT_STORED_OBJECT = 69,

        /// <summary>
        /// The blob contains an object.
        /// </summary>
        VT_BLOB_OBJECT = 70,

        /// <summary>
        /// A clipboard format.
        /// </summary>
        VT_CF = 71,

        /// <summary>
        /// A class ID.
        /// </summary>
        VT_CLSID = 72,

        /// <summary>
        /// A stream with a GUID version.
        /// </summary>
        VT_VERSIONED_STREAM = 73,

        /// <summary>
        /// Reserved.
        /// </summary>
        VT_BSTR_BLOB = 0xfff,

        /// <summary>
        /// A simple counted array.
        /// </summary>
        VT_VECTOR = 0x1000,

        /// <summary>
        /// A <see cref="SAFEARRAY"/> pointer.
        /// </summary>
        VT_ARRAY = 0x2000,

        /// <summary>
        /// A void pointer for local use.
        /// </summary>
        VT_BYREF = 0x4000,

        /// <summary>
        /// 
        /// </summary>
        VT_RESERVED = 0x8000,

        /// <summary>
        /// 
        /// </summary>
        VT_ILLEGAL = 0xffff,

        /// <summary>
        /// 
        /// </summary>
        VT_ILLEGALMASKED = 0xfff,

        /// <summary>
        /// 
        /// </summary>
        VT_TYPEMASK = 0xfff
    }
}
