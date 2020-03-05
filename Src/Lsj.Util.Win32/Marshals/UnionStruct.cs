using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

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
}
