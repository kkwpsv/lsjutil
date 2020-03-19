using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Marshals
{
    /// <summary>
    /// UnionStruct
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
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
    /// UnionStruct
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct UnionStruct<T1, T2, T3, T4> where T1 : struct where T2 : struct where T3 : struct where T4 : struct
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
    }
}
