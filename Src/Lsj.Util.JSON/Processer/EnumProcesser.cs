using Lsj.Util.JSON.Processer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.JSON.Processer
{
    class EnumProcesser : IStringProcesser
    {
        object result;
        Type type;

        EnumProcesser(Type type)
        {
            this.type = type;
        }

        public object GetResult() => result;

        public void SetValue(string val)
        {
            result = Enum.Parse(type, val);
        }

        public void SetValue(object value) => SetValue(value.ToString());
    }
}
