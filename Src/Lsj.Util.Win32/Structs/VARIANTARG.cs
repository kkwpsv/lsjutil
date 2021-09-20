using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.OleAut32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// VARIANTARG
    /// </summary>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct VARIANTARG
    {
        /// <summary>
        /// The type of data in the union.
        /// </summary>
        [FieldOffset(0)]
        public VARTYPE vt;

        /// <summary>
        /// Reserved.
        /// </summary>
        [FieldOffset(2)]
        public WORD wReserved1;

        /// <summary>
        /// Reserved.
        /// </summary>
        [FieldOffset(4)]
        public WORD wReserved2;

        /// <summary>
        /// Reserved.
        /// </summary>
        [FieldOffset(6)]
        public WORD wReserved3;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(8)]
        public LONGLONG llVal;

        /// <summary>
        /// A 4-byte integer value.
        /// </summary>
        [FieldOffset(8)]
        public LONG lVal;

        /// <summary>
        /// An unsigned 1-byte character.
        /// </summary>
        [FieldOffset(8)]
        public BYTE bVal;

        /// <summary>
        /// A 2-byte integer value.
        /// </summary>
        [FieldOffset(8)]
        public SHORT iVal;

        /// <summary>
        /// A 4-byte real value.
        /// </summary>
        [FieldOffset(8)]
        public FLOAT fltVal;

        /// <summary>
        /// An 8-byte real value.
        /// </summary>
        [FieldOffset(8)]
        public DOUBLE dblVal;

        /// <summary>
        /// A 16-bit Boolean value.
        /// A value of 0xFFFF (all bits 1) indicates true; a value of 0 (all bits 0) indicates false.
        /// No other values are valid.
        /// </summary>
        [FieldOffset(8)]
        public VARIANT_BOOL boolVal;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(8)]
        public VARIANT_BOOL __OBSOLETE__VARIANT_BOOL;

        /// <summary>
        /// An SCODE value.
        /// </summary>
        [FieldOffset(8)]
        public SCODE scode;

        /// <summary>
        /// A currency value.
        /// </summary>
        [FieldOffset(8)]
        public CY cyVal;

        /// <summary>
        /// A date and time value.
        /// Dates are represented as double-precision numbers, where midnight, January 1, 1900 is 2.0, January 2, 1900 is 3.0, and so on.
        /// The date can be converted to and from an MS-DOS representation using <see cref="VariantTimeToDosDateTime"/>.
        /// </summary>
        [FieldOffset(8)]
        public DATE date;

        /// <summary>
        /// A string value.
        /// </summary>
        [FieldOffset(8)]
        public IntPtr bstrVal;

        /// <summary>
        /// A pointer to an object that implements the <see cref="IUnknown"/> interface.
        /// </summary>
        [FieldOffset(8)]
        public IntPtr punkVal;

        /// <summary>
        /// A pointer to an object was specified.
        /// </summary>
        [FieldOffset(8)]
        public IntPtr pdispVal;

        /// <summary>
        /// A safe array descriptor, which describes the dimensions, size, and in-memory location of the array.
        /// </summary>
        [FieldOffset(8)]
        public IntPtr parray;

        /// <summary>
        /// A reference to an unsigned 1-byte character.
        /// </summary>
        [FieldOffset(8)]
        public IntPtr pbVal;

        /// <summary>
        /// A reference to a 2-byte integer value.
        /// </summary>
        [FieldOffset(8)]
        public IntPtr piVal;

        /// <summary>
        ///  A reference to a 4-byte integer value.
        /// </summary>
        [FieldOffset(8)]
        public IntPtr plVal;

        /// <summary>
        /// A reference to an 8-byte integer value.
        /// </summary>
        [FieldOffset(8)]
        public IntPtr pllVal;

        /// <summary>
        /// A reference to a 4-byte real value.
        /// </summary>
        [FieldOffset(8)]
        public IntPtr pfltVal;

        /// <summary>
        /// A reference to an 8-byte real value.
        /// </summary>
        [FieldOffset(8)]
        public IntPtr pdblVal;

        /// <summary>
        /// A reference to a 16-bit Boolean value.
        /// </summary>
        [FieldOffset(8)]
        public IntPtr pboolVal;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(8)]
        public IntPtr __OBSOLETE__VARIANT_PBOOL;

        /// <summary>
        /// A reference to an SCODE value.
        /// </summary>
        [FieldOffset(8)]
        public IntPtr pscode;

        /// <summary>
        /// A reference to a currency value.
        /// </summary>
        [FieldOffset(8)]
        public IntPtr pcyVal;

        /// <summary>
        /// A reference to a date and time value.
        /// Dates are represented as double-precision numbers, where midnight, January 1, 1900 is 2.0, January 2, 1900 is 3.0, and so on.
        /// </summary>
        [FieldOffset(8)]
        public IntPtr pdate;

        /// <summary>
        /// A reference to a string value.
        /// </summary>
        [FieldOffset(8)]
        public IntPtr pbstrVal;

        /// <summary>
        /// A reference to an <see cref="IUnknown"/> interface pointer.
        /// </summary>
        [FieldOffset(8)]
        public IntPtr ppunkVal;

        /// <summary>
        /// A reference to an object pointer.
        /// </summary>
        [FieldOffset(8)]
        public IntPtr ppdispVal;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(8)]
        public IntPtr pparray;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(8)]
        public IntPtr pvarVal;

        /// <summary>
        /// A generic value
        /// </summary>
        [FieldOffset(8)]
        public PVOID byref;

        /// <summary>
        /// A 1-byte character value.
        /// </summary>
        [FieldOffset(8)]
        public CHAR cVal;

        /// <summary>
        ///  An unsigned 2-byte integer value.
        /// </summary>
        [FieldOffset(8)]
        public USHORT uiVal;

        /// <summary>
        /// An unsigned 4-byte integer value.
        /// </summary>
        [FieldOffset(8)]
        public ULONG ulVal;

        /// <summary>
        /// An unsigned 8-byte integer value.
        /// </summary>
        [FieldOffset(8)]
        public ULONGLONG ullVal;

        /// <summary>
        /// An integer value.
        /// </summary>
        [FieldOffset(8)]
        public INT intVal;

        /// <summary>
        /// An unsigned integer value.
        /// </summary>
        [FieldOffset(8)]
        public UINT uintVal;

        /// <summary>
        /// A decimal value, which is stored as 96-bit (12-byte) unsigned integers scaled by a variable power of 10.
        /// </summary>
        [FieldOffset(8)]
        public IntPtr pdecVal;

        /// <summary>
        /// A reference to a 1-byte character value.
        /// </summary>
        [FieldOffset(8)]
        public IntPtr pcVal;

        /// <summary>
        /// A reference to an unsigned 2-byte integer value.
        /// </summary>
        [FieldOffset(8)]
        public IntPtr puiVal;

        /// <summary>
        /// A reference to an unsigned 4-byte integer value.
        /// </summary>
        [FieldOffset(8)]
        public IntPtr pulVal;

        /// <summary>
        /// A reference to an unsigned 8-byte integer value.
        /// </summary>
        [FieldOffset(8)]
        public IntPtr pullVal;

        /// <summary>
        /// A reference to an integer value.
        /// </summary>
        [FieldOffset(8)]
        public IntPtr pintVal;

        /// <summary>
        /// A reference to an unsigned integer value.
        /// </summary>
        [FieldOffset(8)]
        public UIntPtr puintVal;

        [FieldOffset(8)]
#pragma warning disable IDE1006 // 命名样式
        private UnionStruct __VARIANT_NAME_4;
#pragma warning restore IDE1006 // 命名样式

        /// <summary>
        /// A reference to a database record.
        /// </summary>
#pragma warning disable IDE1006 // 命名样式
        public PVOID pvRecord
#pragma warning restore IDE1006 // 命名样式
        {
            get => __VARIANT_NAME_4.pvRecord;
            set => __VARIANT_NAME_4.pvRecord = value;
        }

        /// <summary>
        /// A reference to a UDT.
        /// </summary>
#pragma warning disable IDE1006 // 命名样式
        public IntPtr pRecInfo
#pragma warning restore IDE1006 // 命名样式
        {
            get => __VARIANT_NAME_4.pRecInfo;
            set => __VARIANT_NAME_4.pRecInfo = value;
        }

        /// <summary>
        ///  A decimal value.
        /// </summary>
        [FieldOffset(0)]
        public DECIMAL decVal;

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct UnionStruct
        {
            public PVOID pvRecord;
            public IntPtr pRecInfo;
        }
    }
}
