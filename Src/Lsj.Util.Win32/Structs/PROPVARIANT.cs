using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Marshals;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOLEAN;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.StandardClipboardFormats;
using static Lsj.Util.Win32.Enums.VARENUM;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.OleAut32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="PROPVARIANT"/> structure is used in the <see cref="IPropertyStorage.ReadMultiple"/>
    /// and <see cref="IPropertyStorage.WriteMultiple"/> methods of <see cref="IPropertyStorage"/>
    /// to define the type tag and the value of a property in a property set.
    /// </para>
    /// <para>
    /// The <see cref="PROPVARIANT"/> structure is also used by the <see cref="IPropertyStorage.GetValue"/>
    /// and <see cref="IPropertyStorage.SetValue"/> methods of <see cref="IPropertyStore"/>,
    /// which replaces <see cref="IPropertySetStorage"/> as the primary way to program item properties in Windows Vista.
    /// For more information, see Property Handlers.
    /// </para>
    /// <para>
    /// There are five members.
    /// The first member, the value-type tag, and the last member, the value of the property, are significant.
    /// The middle three members are reserved for future use.
    /// For more information, see Property Handlers.
    /// </para>
    /// <para>
    /// Note
    /// For more information, see Property Handlers.
    /// </para>
    /// <para>
    /// The bool member in previous definitions of this structure has been renamed to <see cref="boolVal"/>,
    /// because some compilers now recognize bool as a keyword.
    /// For more information, see Property Handlers.
    /// </para>
    /// <para>
    /// Note
    /// For more information, see Property Handlers.
    /// </para>
    /// <para>
    /// The <see cref="PROPVARIANT"/> structure, defined below,
    /// includes types that can be serialized in the version 1 property set serialization format.
    /// The version 1 format supports all types allowed in the version 0 format plus some additional types.
    /// The added types include "Version 1" in the comment field below.
    /// Use these types only if a version 1 property set is intended.
    /// For more information, see Property Set Serialization.
    /// For more information, see Property Handlers.
    /// </para>
    /// <para>
    /// The <see cref="PROPVARIANT"/> structure is defined as follows:
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/propidlbase/ns-propidlbase-propvariant"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The <see cref="PROPVARIANT"/> structure can also hold a value of <see cref="VT_DECIMAL"/>:syntax
    /// </para>
    /// <code>
    /// DECIMAL       decVal;        //VT_DECIMAL
    /// </code>
    /// <para>
    /// However, the value of the <see cref="DECIMAL"/> structure requires special handling.
    /// The <see cref="DECIMAL"/> structure is the same size as an entire <see cref="PROPVARIANT"/> structure
    /// and does not fit into the union that holds all other types of values.
    /// Instead, the value of the <see cref="DECIMAL"/> structure occupies the entire <see cref="PROPVARIANT"/> structure,
    /// including the reserved fields and the <see cref="vt"/> member.
    /// However, the first member of the <see cref="DECIMAL"/> structure is not used
    /// and is equal in size to the <see cref="vt"/> member of the <see cref="PROPVARIANT"/> structure.
    /// Therefore, the <see cref="PROPVARIANT"/> structure declaration in the Propidl.h header file
    /// of Win32 defines the <see cref="decVal"/> member in such a way
    /// that it corresponds to the beginning of the <see cref="PROPVARIANT"/> structure.
    /// Therefore, to put the value of the <see cref="DECIMAL"/> structure into a <see cref="PROPVARIANT"/> structure,
    /// the value must be loaded into the <see cref="decVal"/> member
    /// and the <see cref="vt"/> member is set to <see cref="VT_DECIMAL"/>, just as for any other value.
    /// </para>
    /// <para>
    /// <see cref="PROPVARIANT"/> is the fundamental data type by which property values
    /// are read and written through the <see cref="IPropertyStorage"/> interface.
    /// </para>
    /// <para>
    /// The data type <see cref="PROPVARIANT"/> is related to the data type <see cref="VARIANT"/>,
    /// defined as part of Automation in OLE2.
    /// Several definitions are reused from Automation, as follows:
    /// </para>
    /// <code>
    /// typedef struct  tagCY {
    ///     unsigned long      Lo;
    ///     long               Hi;
    ///     } CY;
    ///  
    /// typedef struct  tagDEC {
    ///     USHORT             wReserved;
    ///     BYTE               scale;
    ///     BYTE               sign;
    ///     ULONG              Hi32;
    ///     ULONGLONG          Lo64;
    ///     } DECIMAL;
    ///  
    /// typedef struct  tagSAFEARRAYBOUND {
    ///     ULONG              cElements;
    ///     LONG               lLbound;
    ///     } SAFEARRAYBOUND;
    ///  
    /// typedef struct  tagSAFEARRAY {
    ///     USHORT             cDims;
    ///     USHORT             fFeatures;
    ///     ULONG              cbElements;
    ///     ULONG              cLocks;
    ///     PVOID              pvData;
    ///     SAFEARRAYBOUND     rgsabound [ * ];
    ///     } SAFEARRAY;
    ///  
    /// typedef CY             CURRENCY;
    /// typedef short          VARIANT_BOOL;
    /// typedef unsigned short VARTYPE;
    /// typedef double         DATE;
    /// typedef OLECHAR*       BSTR;
    /// </code>
    /// <para>
    /// In addition, some types are unique to the <see cref="PROPVARIANT"/> structure:syntax
    /// </para>
    /// <code>
    /// typedef struct  tagCLIPDATA {
    ///     // cbSize is the size of the buffer pointed to 
    ///     // by pClipData, plus sizeof(ulClipFmt)
    ///     ULONG              cbSize;
    ///     long               ulClipFmt;
    ///     BYTE*              pClipData;
    ///     } CLIPDATA;
    /// </code>
    /// <para>
    /// Among the unique <see cref="PROPVARIANT"/> types are several data types
    /// that define counted arrays of other data types.
    /// The data types of all counted arrays begin with the letters CA, for example <see cref="CAUB"/>,
    /// and have an OR operator vt value (the VarType of the element and an OR operator with <see cref="VT_VECTOR"/>).
    /// The counted array structure has the following form (where name is the specific name of the counted array).
    /// </para>
    /// <code>
    /// #define TYPEDEF_CA(type, name) 
    ///  
    ///     typedef struct tag ## name {\
    ///         ULONG cElems;\
    ///         type *pElems;\
    ///         } name
    /// </code>
    /// <para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Propvariant type
    /// </term>
    /// <term>
    /// Code
    /// </term>
    /// <term>
    /// Propvariant member
    /// </term>
    /// <term>
    /// Value representation
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// <see cref="VT_EMPTY"/>
    /// </term>
    /// <term>
    /// 0
    /// </term>
    /// <term>
    /// None
    /// </term>
    /// <term>
    /// A property with a type indicator of <see cref="VT_EMPTY"/> has no data associated with it;
    /// that is, the size of the value is zero.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_NULL"/>
    /// </term>
    /// <term>
    /// 1
    /// </term>
    /// <term>
    /// None
    /// </term>
    /// <term>
    /// This is like a pointer to <see cref="NULL"/>.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_I1"/>
    /// </term>
    /// <term>
    /// 16
    /// </term>
    /// <term>
    /// <see cref="cVal"/>
    /// </term>
    /// <term>
    /// 1-byte signed integer.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_UI1"/>
    /// </term>
    /// <term>
    /// 17
    /// </term>
    /// <term>
    /// <see cref="bVal"/>
    /// </term>
    /// <term>
    /// 1-byte unsigned integer.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_I2"/>
    /// </term>
    /// <term>
    /// 2
    /// </term>
    /// <term>
    /// <see cref="iVal"/>
    /// </term>
    /// <term>
    /// Two bytes representing a 2-byte signed integer value.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_UI2"/>
    /// </term>
    /// <term>
    /// 18
    /// </term>
    /// <term>
    /// <see cref="uiVal"/>
    /// </term>
    /// <term>
    /// 2-byte unsigned integer.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_I4"/>
    /// </term>
    /// <term>
    /// 3
    /// </term>
    /// <term>
    /// <see cref="lVal"/>
    /// </term>
    /// <term>
    /// 4-byte signed integer value.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_UI4"/>
    /// </term>
    /// <term>
    /// 19
    /// </term>
    /// <term>
    /// <see cref="ulVal"/>
    /// </term>
    /// <term>
    /// 4-byte unsigned integer.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_INT"/>
    /// </term>
    /// <term>
    /// 22
    /// </term>
    /// <term>
    /// <see cref="intVal"/>
    /// </term>
    /// <term>
    /// 4-byte signed integer value (equivalent to <see cref="VT_I4"/>).
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_UINT"/>
    /// </term>
    /// <term>
    /// 23
    /// </term>
    /// <term>
    /// <see cref="uintVal"/>
    /// </term>
    /// <term>
    /// 4-byte unsigned integer (equivalent to <see cref="VT_UI4"/>).
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_I8"/>
    /// </term>
    /// <term>
    /// 20
    /// </term>
    /// <term>
    /// <see cref="hVal"/>
    /// </term>
    /// <term>
    /// 8-byte signed integer.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_UI8"/>
    /// </term>
    /// <term>
    /// 21
    /// </term>
    /// <term>
    /// <see cref="uhVal"/>
    /// </term>
    /// <term>
    /// 8-byte unsigned integer.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_R4"/>
    /// </term>
    /// <term>
    /// 4
    /// </term>
    /// <term>
    /// <see cref="fltVal"/>
    /// </term>
    /// <term>
    /// 32-bit IEEE floating point value.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_R8"/>
    /// </term>
    /// <term>
    /// 5
    /// </term>
    /// <term>
    /// <see cref="dblVal"/>
    /// </term>
    /// <term>
    /// 64-bit IEEE floating point value.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_BOOL"/>
    /// </term>
    /// <term>
    /// 11
    /// </term>
    /// <term>
    /// <see cref="boolVal"/> (bool in earlier designs)
    /// </term>
    /// <term>
    /// Boolean value, a <see cref="WORD"/> that contains 0 (<see cref="FALSE"/>) or -1 (<see cref="TRUE"/>).
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_ERROR"/>
    /// </term>
    /// <term>
    /// 10
    /// </term>
    /// <term>
    /// scode
    /// </term>
    /// <term>
    /// A <see cref="DWORD"/> that contains a status code.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_CY"/>
    /// </term>
    /// <term>
    /// 6
    /// </term>
    /// <term>
    /// <see cref="cyVal"/>
    /// </term>
    /// <term>
    /// 8-byte two's complement integer (scaled by 10,000). This type is commonly used for currency amounts.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_DATE"/>
    /// </term>
    /// <term>
    /// 7
    /// </term>
    /// <term>
    /// <see cref="date"/>
    /// </term>
    /// <term>
    /// A 64-bit floating point number representing the number of days (not seconds) since December 31, 1899.
    /// For example, January 1, 1900, is 2.0, January 2, 1900, is 3.0, and so on).
    /// This is stored in the same representation as <see cref="VT_R8"/>.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_FILETIME"/>
    /// </term>
    /// <term>
    /// 64
    /// </term>
    /// <term>
    /// <see cref="filetime"/>
    /// </term>
    /// <term>
    /// 64-bit <see cref="FILETIME"/> structure as defined by Win32.
    /// It is recommended that all times be stored in Universal Coordinate Time (UTC).
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_CLSID"/>
    /// </term>
    /// <term>
    /// 72
    /// </term>
    /// <term>
    /// <see cref="puuid"/>
    /// </term>
    /// <term>
    /// Pointer to a class identifier (CLSID) (or other globally unique identifier (GUID)).
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_CF"/>
    /// </term>
    /// <term>
    /// 71
    /// </term>
    /// <term>
    /// <see cref="pclipdata"/>
    /// </term>
    /// <term>
    /// Pointer to a <see cref="CLIPDATA"/> structure, described above.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_BSTR"/>
    /// </term>
    /// <term>
    /// 8
    /// </term>
    /// <term>
    /// <see cref="bstrVal"/>
    /// </term>
    /// <term>
    /// Pointer to a null-terminated Unicode string.
    /// The string is immediately preceded by a <see cref="DWORD"/> representing the byte count,
    /// but <see cref="bstrVal"/> points past this <see cref="DWORD"/> to the first character of the string.
    /// <see cref="BSTR"/>s must be allocated and freed
    /// using the Automation <see cref="SysAllocString"/> and <see cref="SysFreeString"/> calls.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_BSTR_BLOB"/>
    /// </term>
    /// <term>
    /// 0xfff
    /// </term>
    /// <term>
    /// <see cref="bstrblobVal"/>
    /// </term>
    /// <term>
    /// For system use only.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_BLOB"/>
    /// </term>
    /// <term>
    /// 65
    /// </term>
    /// <term>
    /// <see cref="blob"/>
    /// </term>
    /// <term>
    /// <see cref="DWORD"/> count of bytes, followed by that many bytes of data.
    /// The byte count does not include the four bytes for the length of the count itself;
    /// an empty blob member would have a count of zero, followed by zero bytes.
    /// This is similar to the value <see cref="VT_BSTR"/>,
    /// but does not guarantee a null byte at the end of the data.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_BLOB_OBJECT"/>
    /// </term>
    /// <term>
    /// 70
    /// </term>
    /// <term>
    /// <see cref="blob"/>
    /// </term>
    /// <term>
    /// <para>
    /// A blob member that contains a serialized object in the same representation
    /// that would appear in <see cref="VT_STREAMED_OBJECT"/>.
    /// That is, a <see cref="DWORD"/> byte count (where the byte count does not include the size of itself)
    /// which is in the format of a class identifier followed by initialization data for that class.
    /// </para>
    /// <para>
    /// The only significant difference between <see cref="VT_BLOB_OBJECT"/> and <see cref="VT_STREAMED_OBJECT"/>
    /// is that the former does not have the system-level storage overhead that the latter would have,
    /// and is therefore more suitable for scenarios involving numbers of small objects.
    /// </para>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_LPSTR"/>
    /// </term>
    /// <term>
    /// 30
    /// </term>
    /// <term>
    /// <see cref="pszVal"/>
    /// </term>
    /// <term>
    /// A pointer to a null-terminated ANSI string in the system default code page.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_LPWSTR"/>
    /// </term>
    /// <term>
    /// 31
    /// </term>
    /// <term>
    /// <see cref="pwszVal"/>
    /// </term>
    /// <term>
    /// A pointer to a null-terminated Unicode string in the user default locale.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_UNKNOWN"/>
    /// </term>
    /// <term>
    /// 13
    /// </term>
    /// <term>
    /// <see cref="punkVal"/>
    /// </term>
    /// <term>
    /// New.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_DISPATCH"/>
    /// </term>
    /// <term>
    /// 9
    /// </term>
    /// <term>
    /// <see cref="pdispVal"/>
    /// </term>
    /// <term>
    /// New.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_STREAM"/>
    /// </term>
    /// <term>
    /// 66
    /// </term>
    /// <term>
    /// <see cref="pStream"/>
    /// </term>
    /// <term>
    /// A pointer to an <see cref="IStream"/> interface that represents a stream which is a sibling to the "Contents" stream.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_STREAMED_OBJECT"/>
    /// </term>
    /// <term>
    /// 68
    /// </term>
    /// <term>
    /// <see cref="pStream"/>
    /// </term>
    /// <term>
    /// As in <see cref="VT_STREAM"/>, but indicates that the stream contains a serialized object,
    /// which is a CLSID followed by initialization data for the class.
    /// The stream is a sibling to the "Contents" stream that contains the property set.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_STORAGE"/>
    /// </term>
    /// <term>
    /// 67
    /// </term>
    /// <term>
    /// <see cref="pStorage"/>
    /// </term>
    /// <term>
    /// A pointer to an <see cref="IStorage"/> interface,
    /// representing a storage object that is a sibling to the "Contents" stream.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_STORED_OBJECT"/>
    /// </term>
    /// <term>
    /// 69
    /// </term>
    /// <term>
    /// <see cref="pStorage"/>
    /// </term>
    /// <term>
    /// As in <see cref="VT_STORAGE"/>,
    /// but indicates that the designated <see cref="IStorage"/> contains a loadable object.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_VERSIONED_STREAM"/>
    /// </term>
    /// <term>
    /// 73
    /// </term>
    /// <term>
    /// <see cref="pVersionedStream"/>
    /// </term>
    /// <term>
    /// A stream with a GUID version.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_DECIMAL"/>
    /// </term>
    /// <term>
    /// 14
    /// </term>
    /// <term>
    /// <see cref="decVal"/>
    /// </term>
    /// <term>
    /// A <see cref="DECIMAL"/> structure.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_VECTOR"/>
    /// </term>
    /// <term>
    /// 0x1000
    /// </term>
    /// <term>
    /// ca*
    /// </term>
    /// <term>
    /// <para>
    /// If the type indicator is combined with <see cref="VT_VECTOR"/> by using an OR operator,
    /// the value is one of the counted array values.
    /// This creates a <see cref="DWORD"/> count of elements,
    /// followed by a pointer to the specified repetitions of the value.
    /// </para>
    /// <para>
    /// For example, a type indicator of <see cref="VT_LPSTR"/>|<see cref="VT_VECTOR"/> has a <see cref="DWORD"/> element count,
    /// followed by a pointer to an array of LPSTR elements.
    /// </para>
    /// <para>
    /// <see cref="VT_VECTOR"/> can be combined by an OR operator with the following types:
    /// <see cref="VT_I1"/>, <see cref="VT_UI1"/>, <see cref="VT_I2"/>, <see cref="VT_UI2"/>,
    /// <see cref="VT_BOOL"/>, <see cref="VT_I4"/>, <see cref="VT_UI4"/>, <see cref="VT_R4"/>,
    /// <see cref="VT_R8"/>, <see cref="VT_ERROR"/>, <see cref="VT_I8"/>, <see cref="VT_UI8"/>,
    /// <see cref="VT_CY"/>, <see cref="VT_DATE"/>, <see cref="VT_FILETIME"/>, <see cref="VT_CLSID"/>,
    /// <see cref="VT_CF"/>, <see cref="VT_BSTR"/>, <see cref="VT_LPSTR"/>, <see cref="VT_LPWSTR"/>,
    /// and <see cref="VT_VARIANT"/>. <see cref="VT_VECTOR"/> can also be combined
    /// by an OR operation with <see cref="VT_BSTR_BLOB"/>, however it is for system use only.
    /// </para>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_ARRAY"/>
    /// </term>
    /// <term>
    /// 0x2000
    /// </term>
    /// <term>
    /// <see cref="parray"/>
    /// </term>
    /// <term>
    /// If the type indicator is combined with <see cref="VT_ARRAY"/> by an OR operator,
    /// the value is a pointer to a SAFEARRAY.
    /// <see cref="VT_ARRAY"/> can use the OR with the following data types:
    /// <see cref="VT_I1"/>, <see cref="VT_UI1"/>, <see cref="VT_I2"/>, <see cref="VT_UI2"/>,
    /// <see cref="VT_I4"/>, <see cref="VT_UI4"/>, <see cref="VT_INT"/>, <see cref="VT_UINT"/>,
    /// <see cref="VT_R4"/>, <see cref="VT_R8"/>, <see cref="VT_BOOL"/>, <see cref="VT_DECIMAL"/>,
    /// <see cref="VT_ERROR"/>, <see cref="VT_CY"/>, <see cref="VT_DATE"/>, <see cref="VT_BSTR"/>,
    /// <see cref="VT_DISPATCH"/>, <see cref="VT_UNKNOWN"/>, and <see cref="VT_VARIANT"/>.
    /// <see cref="VT_ARRAY"/> cannot use OR with <see cref="VT_VECTOR"/>.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_BYREF"/>
    /// </term>
    /// <term>
    /// 0x4000
    /// </term>
    /// <term>
    /// p*
    /// </term>
    /// <term>
    /// <para>
    /// If the type indicator is combined with <see cref="VT_BYREF"/> by an OR operator, the value is a reference.
    /// Reference types are interpreted as a reference to data, similar to the reference type in C++ (for example, "int&amp;").
    /// </para>
    /// <para>
    /// <see cref="VT_BYREF"/> can use OR with the following types:
    /// <see cref="VT_I1"/>, <see cref="VT_UI1"/>, <see cref="VT_I2"/>, <see cref="VT_UI2"/>,
    /// <see cref="VT_I4"/>, <see cref="VT_UI4"/>, <see cref="VT_INT"/>, <see cref="VT_UINT"/>,
    /// <see cref="VT_R4"/>, <see cref="VT_R8"/>, <see cref="VT_BOOL"/>, <see cref="VT_DECIMAL"/>,
    /// <see cref="VT_ERROR"/>, <see cref="VT_CY"/>, <see cref="VT_DATE"/>, <see cref="VT_BSTR"/>,
    /// <see cref="VT_UNKNOWN"/>, <see cref="VT_DISPATCH"/>, <see cref="VT_ARRAY"/>, and <see cref="VT_VARIANT"/>.
    /// </para>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_VARIANT"/>
    /// </term>
    /// <term>
    /// 12
    /// </term>
    /// <term>
    /// <see cref="capropvar"/>
    /// </term>
    /// <term>
    /// A <see cref="DWORD"/> type indicator followed by the corresponding value.
    /// <see cref="VT_VARIANT"/> can be used only with <see cref="VT_VECTOR"/> or <see cref="VT_BYREF"/>.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="VT_TYPEMASK"/>
    /// </term>
    /// <term>
    /// 0xFFF
    /// </term>
    /// <term>
    /// </term>
    /// <term>
    /// Used as a mask for <see cref="VT_VECTOR"/> and other modifiers to extract the raw VT value.
    /// </term>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// Clipboard format identifiers, stored with the tag <see cref="VT_CF"/>, use one of five representations,
    /// identified in the <see cref="CLIPDATA.ulClipFmt"/> member of the <see cref="CLIPDATA"/> structure 
    /// using the <see cref="CLIPDATA.pClipData"/> pointer to the particular data type.
    /// </para>
    /// <para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// <see cref="CLIPDATA.ulClipFmt"/> value
    /// </term>
    /// <term>
    /// <see cref="CLIPDATA.pClipData"/> value
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// -1L
    /// </term>
    /// <term>
    /// A <see cref="DWORD"/> that contains a built-in Windows clipboard format value.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// -2L
    /// </term>
    /// <term>
    /// A <see cref="DWORD"/> that contains a Macintosh clipboard format value.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// -3L
    /// </term>
    /// <term>
    /// A GUID that contains a format identifier (FMTID). This is rarely used.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// any positive value
    /// </term>
    /// <term>
    /// A null-terminated string that contains a Windows clipboard format name,
    /// one suitable for passing to the <see cref="RegisterClipboardFormat"/> function.
    /// This function registers a new clipboard format.
    /// If a registered format with the specified name already exists,
    /// a new format is not registered and the return value identifies the existing format.
    /// This enables more than one application to copy and paste data using the same registered clipboard format.
    /// The format name comparison is case insensitive and is identified by values in the range from 0xC000 through 0xFFFF.
    /// The code page used for characters in the string is according to the code-page indicator.
    /// The "positive value" here is the string length, including the null byte at the end.
    /// When register clipboard formats are placed on or retrieved from the clipboard,
    /// they must be in the form of an <see cref="HGLOBAL"/> data-type value, which provides the handle to the object.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// 0L
    /// </term>
    /// <term>
    /// No data (rarely used).
    /// </term>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// If the value of the <see cref="CLIPDATA.ulClipFmt"/> member is -1, the data is in the form of a built-in Windows format.
    /// In this case, the first <see cref="DWORD"/> of the buffer
    /// pointed to by <see cref="CLIPDATA.pClipData"/> is the clipboard format identifier, for example <see cref="CF_METAFILEPICT"/>.
    /// In the case of <see cref="CF_METAFILEPICT"/>,
    /// what follows is a variation on the <see cref="METAFILEPICT"/> structure
    /// (it uses <see cref="WORD"/>, rather than <see cref="DWORD"/> data types).
    /// That is, this data is in the following form:
    /// </para>
    /// <code>
    /// struct PACKEDMETA
    /// {
    ///     WORD mm;
    ///     WORD xExt;
    ///     WORD yExt
    ///     WORD reserved;
    /// };
    /// </code>
    /// <para>
    /// After the <see cref="METAFILEPICT"/> structure is the metafile data,
    /// suitable to be passed to the <see cref="SetMetaFileBitsEx"/> function.
    /// This function creates a memory-based, Windows-format metafile from the supplied data.
    /// This function is provided for compatibility with 16-bit versions of Windows.
    /// Win32-based applications should use the <see cref="SetEnhMetaFileBits"/> function.
    /// This function retrieves the contents of the specified enhanced-format metafile and copies them into a buffer.
    /// If the function succeeds and the buffer pointer is <see cref="NULL"/>,
    /// the return value is the size of the enhanced metafile in bytes.
    /// If the function succeeds and the buffer pointer is a valid pointer,
    /// the return value is the number of bytes copied to the buffer.
    /// If the function fails, the return value is zero.
    /// </para>
    /// <para>
    /// When register clipboard formats are placed on or retrieved from the clipboard,
    /// they must be in the form of an <see cref="HGLOBAL"/> value.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PROPVARIANT
    {
        /// <summary>
        /// 
        /// </summary>
        public VARTYPE vt;

        /// <summary>
        /// 
        /// </summary>
        public WORD wReserved1;

        /// <summary>
        /// 
        /// </summary>
        public WORD wReserved2;

        /// <summary>
        /// 
        /// </summary>
        public WORD wReserved3;

        private PROPVARIANT__UNION _union;

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
        public struct PROPVARIANT__UNION
        {
            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public CHAR cVal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public UCHAR bVal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public SHORT iVal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public USHORT uiVal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public LONG lVal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public ULONG ulVal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public INT intVal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public UINT uintVal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public LARGE_INTEGER hVal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public ULARGE_INTEGER uhVal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public FLOAT fltVal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public DOUBLE dblVal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public VARIANT_BOOL boolVal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public VARIANT_BOOL __OBSOLETE__VARIANT_BOOL;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public SCODE scode;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public CY cyVal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public DATE date;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public FILETIME filetime;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public P<CLSID> puuid;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public P<CLIPDATA> pclipdata;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public nint bstrVal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public BSTRBLOB bstrblobVal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public nint blob;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public nint pszVal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public nint pwszVal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public P<IUnknown> punkVal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public P<IDispatch> pdispVal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public P<IStream> pStream;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public P<IStorage> pStorage;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public nint pVersionedStream;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public nint parray;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public CAC cac;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public CAUB caub;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public CAI cai;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public CAUI caui;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public CAL cal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public CAUL caul;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public CAH cah;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public CAUH cauh;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public CAFLT caflt;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public CADBL cadbl;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public CABOOL cabool;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public CASCODE cascode;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public CACY cacy;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public CADATE cadate;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public CAFILETIME cafiletime;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public CACLSID cauuid;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public CACLIPDATA caclipdata;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public CABSTR cabstr;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public CABSTRBLOB cabstrblob;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public CALPSTR calpstr;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public CALPWSTR calpwstr;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public CAPROPVARIANT capropvar;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public P<CHAR> pcVal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public P<UCHAR> pbVal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public P<SHORT> piVal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public P<USHORT> puiVal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public P<LONG> plVal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public P<ULONG> pulVal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public P<INT> pintVal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public P<UINT> puintVal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public P<FLOAT> pfltVal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public P<DOUBLE> pdblVal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public P<VARIANT_BOOL> pboolVal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public P<DECIMAL> pdecVal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public P<SCODE> pscode;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public P<CY> pcyVal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public P<DATE> pdate;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public nint pbstrVal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public P<P<IUnknown>> ppunkVal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public P<P<IDispatch>> ppdispVal;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public nint pparray;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public nint pvarVal;
        }

#pragma warning disable IDE1006
        /// <summary>
        /// 
        /// </summary>
        public CHAR cVal
        {
            get => _union.cVal;
            set => _union.cVal = value;
        }

        /// <summary>
        /// 
        /// </summary>

        public UCHAR bVal
        {
            get => _union.bVal;
            set => _union.bVal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public SHORT iVal
        {
            get => _union.iVal;
            set => _union.iVal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public USHORT uiVal
        {
            get => _union.uiVal;
            set => _union.uiVal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public LONG lVal
        {
            get => _union.lVal;
            set => _union.lVal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public ULONG ulVal
        {
            get => _union.ulVal;
            set => _union.ulVal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public INT intVal
        {
            get => _union.intVal;
            set => _union.intVal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public UINT uintVal
        {
            get => _union.uintVal;
            set => _union.uintVal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public LARGE_INTEGER hVal
        {
            get => _union.hVal;
            set => _union.hVal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public ULARGE_INTEGER uhVal
        {
            get => _union.uhVal;
            set => _union.uhVal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public FLOAT fltVal
        {
            get => _union.fltVal;
            set => _union.fltVal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public DOUBLE dblVal
        {
            get => _union.dblVal;
            set => _union.dblVal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public VARIANT_BOOL boolVal
        {
            get => _union.boolVal;
            set => _union.boolVal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public VARIANT_BOOL __OBSOLETE__VARIANT_BOOL
        {
            get => _union.__OBSOLETE__VARIANT_BOOL;
            set => _union.__OBSOLETE__VARIANT_BOOL = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public SCODE scode
        {
            get => _union.scode;
            set => _union.scode = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public CY cyVal
        {
            get => _union.cyVal;
            set => _union.cyVal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public DATE date
        {
            get => _union.date;
            set => _union.date = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public FILETIME filetime
        {
            get => _union.filetime;
            set => _union.filetime = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public P<CLSID> puuid
        {
            get => _union.puuid;
            set => _union.puuid = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public P<CLIPDATA> pclipdata
        {
            get => _union.pclipdata;
            set => _union.pclipdata = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public nint bstrVal
        {
            get => _union.bstrVal;
            set => _union.bstrVal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public BSTRBLOB bstrblobVal
        {
            get => _union.bstrblobVal;
            set => _union.bstrblobVal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public nint blob
        {
            get => _union.blob;
            set => _union.blob = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public nint pszVal
        {
            get => _union.pszVal;
            set => _union.pszVal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public nint pwszVal
        {
            get => _union.pwszVal;
            set => _union.pwszVal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public P<IUnknown> punkVal
        {
            get => _union.punkVal;
            set => _union.punkVal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public P<IDispatch> pdispVal
        {
            get => _union.pdispVal;
            set => _union.pdispVal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public P<IStream> pStream
        {
            get => _union.pStream;
            set => _union.pStream = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public P<IStorage> pStorage
        {
            get => _union.pStorage;
            set => _union.pStorage = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public nint pVersionedStream
        {
            get => _union.pVersionedStream;
            set => _union.pVersionedStream = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public nint parray
        {
            get => _union.parray;
            set => _union.parray = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public CAC cac
        {
            get => _union.cac;
            set => _union.cac = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public CAUB caub
        {
            get => _union.caub;
            set => _union.caub = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public CAI cai
        {
            get => _union.cai;
            set => _union.cai = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public CAUI caui
        {
            get => _union.caui;
            set => _union.caui = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public CAL cal
        {
            get => _union.cal;
            set => _union.cal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public CAUL caul
        {
            get => _union.caul;
            set => _union.caul = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public CAH cah
        {
            get => _union.cah;
            set => _union.cah = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public CAUH cauh
        {
            get => _union.cauh;
            set => _union.cauh = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public CAFLT caflt
        {
            get => _union.caflt;
            set => _union.caflt = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public CADBL cadbl
        {
            get => _union.cadbl;
            set => _union.cadbl = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public CABOOL cabool
        {
            get => _union.cabool;
            set => _union.cabool = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public CASCODE cascode
        {
            get => _union.cascode;
            set => _union.cascode = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public CACY cacy
        {
            get => _union.cacy;
            set => _union.cacy = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public CADATE cadate
        {
            get => _union.cadate;
            set => _union.cadate = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public CAFILETIME cafiletime
        {
            get => _union.cafiletime;
            set => _union.cafiletime = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public CACLSID cauuid
        {
            get => _union.cauuid;
            set => _union.cauuid = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public CACLIPDATA caclipdata
        {
            get => _union.caclipdata;
            set => _union.caclipdata = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public CABSTR cabstr
        {
            get => _union.cabstr;
            set => _union.cabstr = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public CABSTRBLOB cabstrblob
        {
            get => _union.cabstrblob;
            set => _union.cabstrblob = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public CALPSTR calpstr
        {
            get => _union.calpstr;
            set => _union.calpstr = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public CALPWSTR calpwstr
        {
            get => _union.calpwstr;
            set => _union.calpwstr = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public CAPROPVARIANT capropvar
        {
            get => _union.capropvar;
            set => _union.capropvar = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public P<CHAR> pcVal
        {
            get => _union.pcVal;
            set => _union.pcVal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public P<UCHAR> pbVal
        {
            get => _union.pbVal;
            set => _union.pbVal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public P<SHORT> piVal
        {
            get => _union.piVal;
            set => _union.piVal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public P<USHORT> puiVal
        {
            get => _union.puiVal;
            set => _union.puiVal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public P<LONG> plVal
        {
            get => _union.plVal;
            set => _union.plVal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public P<ULONG> pulVal
        {
            get => _union.pulVal;
            set => _union.pulVal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public P<INT> pintVal
        {
            get => _union.pintVal;
            set => _union.pintVal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public P<UINT> puintVal
        {
            get => _union.puintVal;
            set => _union.puintVal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public P<FLOAT> pfltVal
        {
            get => _union.pfltVal;
            set => _union.pfltVal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public P<DOUBLE> pdblVal
        {
            get => _union.pdblVal;
            set => _union.pdblVal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public P<VARIANT_BOOL> pboolVal
        {
            get => _union.pboolVal;
            set => _union.pboolVal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public P<DECIMAL> pdecVal
        {
            get => _union.pdecVal;
            set => _union.pdecVal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public P<SCODE> pscode
        {
            get => _union.pscode;
            set => _union.pscode = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public P<CY> pcyVal
        {
            get => _union.pcyVal;
            set => _union.pcyVal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public P<DATE> pdate
        {
            get => _union.pdate;
            set => _union.pdate = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public nint pbstrVal
        {
            get => _union.pbstrVal;
            set => _union.pbstrVal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public P<P<IUnknown>> ppunkVal
        {
            get => _union.ppunkVal;
            set => _union.ppunkVal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public P<P<IDispatch>> ppdispVal
        {
            get => _union.ppdispVal;
            set => _union.ppdispVal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public nint pparray
        {
            get => _union.pparray;
            set => _union.pparray = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public P<PROPVARIANT> pvarVal
        {
            get => _union.pvarVal;
            set => _union.pvarVal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public DECIMAL decVal;
#pragma warning restore IDE1006
    }
}
