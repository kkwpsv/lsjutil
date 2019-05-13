using Lsj.Util.JSON.Processer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.JSON.Processer
{
    class EnumProcesser : IStringProcesser, INumericProcesser
    {
        object result;
        Type type;

        public EnumProcesser(Type type)
        {
            this.type = type;
        }

        public object GetResult() => result;

        public void SetValue(string val)
        {
            result = Enum.Parse(type, val);
        }

        public void SetValue(int val)
        {
            result = Convert.ChangeType(val, type);
        }

        public void SetValue(object value)
        {
            if (value is int intVal)
            {
                SetValue(intVal);
            }
            else
            {
                SetValue(value.ToString());
            }
        }
    }
}
