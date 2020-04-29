using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Marshals
{
    /// <summary>
    /// UnionStruct
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    [Obsolete]
    public struct UnionStruct<T1, T2> where T1 : struct where T2 : struct
    {
        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(0)]
        public T1 Struct1;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(0)]
        public T2 Struct2;
    }

    /// <summary>
    /// UnionStruct
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    [Obsolete]
    public struct UnionStruct<T1, T2, T3> where T1 : struct where T2 : struct where T3 : struct
    {
        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(0)]
        public T1 Struct1;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(0)]
        public T2 Struct2;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(0)]
        public T3 Struct3;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    [Obsolete]
    public struct UnionStruct<T1, T2, T3, T4, T5> where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct
    {
        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(0)]
        public T1 Struct1;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(0)]
        public T2 Struct2;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(0)]
        public T3 Struct3;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(0)]
        public T4 Struct4;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(0)]
        public T5 Struct5;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    /// <typeparam name="T8"></typeparam>
    /// <typeparam name="T9"></typeparam>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    [Obsolete]
    public struct UnionStruct<T1, T2, T3, T4, T5, T6, T7, T8, T9> where T1 : struct where T2 : struct where T3 : struct where T4 : struct
                                                                  where T5 : struct where T6 : struct where T7 : struct where T8 : struct
                                                                  where T9 : struct
    {
        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(0)]
        public T1 Struct1;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(0)]
        public T2 Struct2;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(0)]
        public T3 Struct3;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(0)]
        public T4 Struct4;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(0)]
        public T5 Struct5;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(0)]
        public T6 Struct6;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(0)]
        public T7 Struct7;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(0)]
        public T8 Struct8;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(0)]
        public T9 Struct9;
    }
}
