using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Marshals
{
    public class StructPointerOrNullObject<T> where T : struct
    {
        public T? Value { get; private set; }
        public StructPointerOrNullObject(T val)
        {
            Value = val;
        }

        public static implicit operator StructPointerOrNullObject<T>(T val) => new StructPointerOrNullObject<T>(val);
    }
}
