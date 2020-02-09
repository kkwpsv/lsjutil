using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32.Marshals
{
    /// <summary>
    /// Alternative Struct Object For P/Invoke
    /// </summary>
    public class AlternativeStructObject<T1, T2> where T1 : struct where T2 : struct
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public AlternativeStructObject(T1 val)
        {
            IsStruct1 = true;
            T1Val = val;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public AlternativeStructObject(T2 val)
        {
            IsStruct1 = false;
            T2Val = val;
        }

        /// <summary>
        /// Is String
        /// </summary>
        public bool IsStruct1 { get; private set; }

        /// <summary>
        /// The Value of <typeparamref name="T1"/>
        /// </summary>
        public T1 T1Val { get; private set; }

        /// <summary>
        /// The Value of <typeparamref name="T2"/>
        /// </summary>
        public T2 T2Val { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator AlternativeStructObject<T1, T2>(T1 val) => new AlternativeStructObject<T1, T2>(val);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator AlternativeStructObject<T1, T2>(T2 val) => new AlternativeStructObject<T1, T2>(val);
    }
}
