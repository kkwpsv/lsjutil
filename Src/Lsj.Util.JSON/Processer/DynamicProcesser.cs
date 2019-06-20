using Lsj.Util.JSON.Processer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.JSON.Processer
{
    class DynamicProcesser : IObjectProcesser, IListProcesser, IStringProcesser, INumericProcesser, IBoolProcesser, INullableProcesser
    {
        /// <summary>
        /// type
        /// 0 Not Initialized
        /// 1 Object
        /// 2 Array
        /// 3 String
        /// 4 Numeric
        /// 5 Bool
        /// 6 Null
        /// </summary>
        byte type = 0;

        object result = new JSONObject();
        void EnsureInit(byte type)
        {
            if (this.type != type)
            {
                if (this.type != 0)
                {
                    JSONParser.Error("Internal Exception");
                }
                this.type = type;
                if (type == 2)
                {
                    result = new JSONArray();
                }

            }
        }

        public object GetResult() => result;

        public Type GetValueType(string name)
        {
            EnsureInit(1);
            return null;
        }

        public void Set(string name, object value)
        {
            EnsureInit(1);
            (result as JSONObject).Set(name, value);
        }

        public void SetEmptyObject()
        {
            EnsureInit(1);
        }

        public Type GetChildType()
        {
            EnsureInit(2);
            return null;
        }

        public bool IsListEmpty()
        {
            EnsureInit(2);
            return (result as JSONArray).Count == 0;
        }

        public void AddChild(object value)
        {
            EnsureInit(2);
            (result as JSONArray).Add(value);
        }

        public void SetValue(string value)
        {
            EnsureInit(3);
            result = value;
        }

        public void SetValue(bool value)
        {
            EnsureInit(5);
            result = value;
        }

        public void SetNull()
        {
            EnsureInit(6);
            result = null;
        }

        public void SetValue(object value)
        {
            if (value is string str)
            {
                EnsureInit(3);
                result = value;
            }
            else if (value.IsNumeric())
            {
                EnsureInit(4);
                result = value;
            }
            else if (value is bool b)
            {
                EnsureInit(5);
                result = b;
            }
            else if (value is JSONObject obj)
            {
                foreach (var x in obj.data)
                {
                    var processer = JSONParser.GetProcesserByType(this.GetValueType(x.Key));
                    processer.SetValue(x.Value);
                    this.Set(x.Key, processer.GetResult());
                }
            }
            else
            {
                JSONParser.Error("value must be string, bool, numeric or JSONObject");
            }
        }
    }
}
