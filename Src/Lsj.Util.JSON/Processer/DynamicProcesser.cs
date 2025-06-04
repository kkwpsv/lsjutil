using Lsj.Util.JSON.Processer.Interfaces;
using System;

namespace Lsj.Util.JSON.Processer
{
    class DynamicProcesser : IObjectProcesser, IListProcesser, IStringProcesser, INumericProcesser, IBoolProcesser, INullableProcesser
    {
        private readonly JSONParser _parser;

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
        byte _type = 0;

        public DynamicProcesser(JSONParser parser)
        {
            _parser = parser;
        }

        object? _result;
        void EnsureInit(byte type)
        {
            if (_type != type)
            {
                if (_type != 0)
                {
                    throw _parser.Error("Internal Exception");
                }
                _type = type;
                if (type == 1)
                {
                    _result = new JSONObject();
                }
                else if (type == 2)
                {
                    _result = new JSONArray();
                }

            }
        }

        public object? GetResult() => _result;

        public Type? GetValueType(string name)
        {
            EnsureInit(1);
            return null;
        }

        public void Set(string name, object? value)
        {
            EnsureInit(1);
            (_result as JSONObject)!.Set(name, value);
        }

        public void SetEmptyObject()
        {
            EnsureInit(1);
        }

        public void SetEmptyList()
        {
            EnsureInit(2);
        }

        public Type? GetChildType()
        {
            EnsureInit(2);
            return null;
        }

        public bool IsListEmpty()
        {
            EnsureInit(2);
            return (_result as JSONArray)!.Count == 0;
        }

        public void AddChild(object? value)
        {
            EnsureInit(2);
            (_result as JSONArray)!.Add(value);
        }

        public void SetValue(string value)
        {
            EnsureInit(3);
            _result = value;
        }

        public void SetValue(bool value)
        {
            EnsureInit(5);
            _result = value;
        }

        public void SetNull()
        {
            EnsureInit(6);
            _result = null;
        }

        public void SetValue(object? value)
        {
            if (value is null)
            {
                SetNull();
            }
            else if (value is string str)
            {
                EnsureInit(3);
                _result = value;
            }
            else if (value.IsNumeric() is true)
            {
                EnsureInit(4);
                _result = value;
            }
            else if (value is bool b)
            {
                EnsureInit(5);
                _result = b;
            }
            else if (value is JSONObject obj)
            {
                foreach (var x in obj.Data)
                {
                    var processer = _parser.GetProcesserByType(this.GetValueType(x.Key));
                    processer.SetValue(x.Value);
                    this.Set(x.Key, processer.GetResult());
                }
            }
            else
            {
                throw _parser.Error("value must be string, bool, numeric or JSONObject");
            }
        }
    }
}
